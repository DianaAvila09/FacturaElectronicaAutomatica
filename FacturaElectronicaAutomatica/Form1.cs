using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturaElectronicaAutomatica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //Ahora nos toca implementar el código que se encargará de conectarse a la pagina web y obtener el documento HTML.
                //string sUrl = "http://estdtcaseta3:8060/Revuelta/InformacionBascula";
                string sUrl = "http://localhost:54828/test.html";
                Encoding objEncoding = Encoding.GetEncoding("ISO-8859-1");
                CookieCollection objCookies = new CookieCollection();

                //USANDO GET
                HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                getRequest.Method = "GET";
                getRequest.CookieContainer = new CookieContainer();
                getRequest.CookieContainer.Add(objCookies);

                //Como se puede ver usamos el Httpwebrequest para realizar la petición a la web de 
                //    SUNAT y con esto deberíamos obtener una respuesta que se cargara en el 
                //Httpwebresponse que se muestra continuación.

                string sGetResponse = string.Empty;
                using (HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse())
                {
                    objCookies = getResponse.Cookies;
                    using (System.IO.StreamReader srGetResponse = new System.IO.StreamReader(getResponse.GetResponseStream(), objEncoding))
                    {
                        sGetResponse = srGetResponse.ReadToEnd();
                    }

                    txtPrueba.Text = sGetResponse;
                }
                //Se ve que el resultado de la consulta se guarda en la variable sGetResponse y 
                //    esta contendrá el código HTML de la web de tipo de cambio. Con esta información 
                //        ya podremos saber cuales son los tipos de cambio de este mes pero nos faltaría 
                //obtener los valores de día, venta y compra sin los demás datos redundante del HTML. 
                //Para ello, usaremos la librería HtmlAgilityPack que ya tenemos en nuestro proyecto.

                //En este ejemplo se esta usando la libreria HtmlAgilityPack ... la pueden conseguir en internet
                //para el framework que deseen o que utilicen ... Go ! 

                //Obtenemos Informacion
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(sGetResponse);





                //AQUI TRANSFORMA EL HTML EN UN DATATABLE


                HtmlNodeCollection nodosTabla = document.DocumentNode.SelectNodes("//table");
                if (nodosTabla.Any())
                {
                    DataTable dTable = HTMLTable_to_DataTable(nodosTabla.FirstOrDefault().OuterHtml);
                }
                    













                HtmlNodeCollection NodesTr = document.DocumentNode.SelectNodes("//table[@class='class=\"form-table\"']//tr");

                if (NodesTr != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Dia", typeof(String));
                    dt.Columns.Add("Compra", typeof(String));
                    dt.Columns.Add("Venta", typeof(String));
                    int iNumFila = 0;
                    foreach (HtmlNode Node in NodesTr)
                    {
                        if (iNumFila > 0)
                        {
                            int iNumColumna = 0;
                            DataRow dr = dt.NewRow();
                            foreach (HtmlNode subNode in Node.Elements("td"))
                            {
                                if (iNumColumna == 0) dr = dt.NewRow();
                                string sValue = subNode.InnerHtml.ToString().Trim();
                                sValue = System.Text.RegularExpressions.Regex.Replace(sValue, "<.*?>", " ");
                                dr[iNumColumna] = sValue;
                                iNumColumna++;
                                if (iNumColumna == 3)
                                {
                                    dt.Rows.Add(dr);
                                    iNumColumna = 0;
                                }
                            }
                        }
                        iNumFila++;
                    }
                    dt.AcceptChanges();
                    // La idea es muy parecida (por no decir igual) a los otros proyectos colgados
                    //Suerte :)
                   // this.dgvHtml.DataSource = dt;
                    //Obtener los ultimos valores es facil, porque esto devuelve una tabla y 
                    //pues obtenemos los datos de la ultima fila, en la linea de abajo se daran cuenta
                    // :)
                    label1.Text = dt.Rows[dt.Rows.Count - 1].ItemArray[1].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable HTMLTable_to_DataTable(string HTML)
        {
            DataTable dt = null;
            DataRow dr = null;
            DataColumn dc = null;
            string TableExpression = "<table[^>]*>(.*?)</table>";
            string HeaderExpression = "<th[^>]*>(.*?)</th>";
            string RowExpression = "<tr[^>]*>(.*?)</tr>";
            string ColumnExpression = "<td[^>]*>(.*?)</td>";
            bool HeadersExist = false;
            int iCurrentColumn = 0;
            int iCurrentRow = 0;
            MatchCollection Tables = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            foreach (Match Table in Tables)
            {
                iCurrentRow = 0;
                HeadersExist = false;
                dt = new DataTable();
                if (Table.Value.Contains("<th"))
                {
                    HeadersExist = true;
                    MatchCollection Headers = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    foreach (Match Header in Headers)
                        dt.Columns.Add(Header.Groups[1].ToString());
                }
                else
                {
                    for (int iColumns = 1; iColumns <= Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase).Count; iColumns++)
                    {
                        dt.Columns.Add("Column " + iColumns);
                    }
                }
                MatchCollection Rows = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                foreach (Match Row in Rows)
                {
                    if (!(iCurrentRow == 0 & HeadersExist == true))
                    {
                        dr = dt.NewRow();
                        iCurrentColumn = 0;
                        MatchCollection Columns = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        foreach (Match Column in Columns)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (!columns.Contains("Column " + iCurrentColumn))
                            {
                                dt.Columns.Add("Column " + iCurrentColumn);
                            }
                            dr[iCurrentColumn] = Column.Groups[1].ToString();
                            iCurrentColumn += 1;
                        }
                        dt.Rows.Add(dr);
                    }
                    iCurrentRow += 1;
                }
            }
            return (dt);
        }

    }
}
