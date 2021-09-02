Imports System.Net
Imports System.Environment



Public Class Form1
    Private Sub panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click

        Dim CSI As String = "Provider=SAOLEDB; Data Source=ESTLPTSIS13;UID=usuario;PWD=revuelta"
        Dim CN As New OleDb.OleDbConnection(CSI)
        Dim DR As OleDb.OleDbDataAdapter
        'Dim query, unidad

        'query = "select pes_Placas,dba.Pesadas where Pes_ID==" & txtTicket.Text

        'Dim CMD As New OleDb.OleDbConnection(query, CN)
        'CN.Open()
        'DR = cmd.Ex








    End Sub

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtTicket.TextChanged

    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub
End Class