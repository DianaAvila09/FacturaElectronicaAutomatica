using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
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
                string sUrl = "http://estdtcaseta3:8060/Revuelta/InformacionBascula";
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

                //Como se puede apreciar, se ha cargado la variable sGetResponse, que contiene el
                //    código HTML, como  un objeto de tipo HtmlDocument. Con esto ya podemos navegar 
                //        entre los TAG'S HTML y poder quitar los datos redundante y solo obtener los que 
                //necesitamos. Estos datos los colocaremos en una tabla que contendrá 3 columnas (día, compra y venta).

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

       
    }
}
