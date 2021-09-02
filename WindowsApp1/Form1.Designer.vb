<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.Placas = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.textBox3)
        Me.panel1.Controls.Add(Me.textBox2)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.txtPlacas)
        Me.panel1.Controls.Add(Me.Placas)
        Me.panel1.Location = New System.Drawing.Point(9, 46)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(676, 302)
        Me.panel1.TabIndex = 7
        Me.panel1.Visible = False
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(100, 82)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(147, 20)
        Me.textBox3.TabIndex = 6
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(100, 139)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(147, 20)
        Me.textBox2.TabIndex = 5
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(3, 130)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(98, 29)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Placas:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(3, 73)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(98, 29)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Chofer:"
        '
        'txtPlacas
        '
        Me.txtPlacas.Location = New System.Drawing.Point(100, 21)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(147, 20)
        Me.txtPlacas.TabIndex = 2
        '
        'Placas
        '
        Me.Placas.AutoSize = True
        Me.Placas.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Placas.Location = New System.Drawing.Point(3, 12)
        Me.Placas.Name = "Placas"
        Me.Placas.Size = New System.Drawing.Size(98, 29)
        Me.Placas.TabIndex = 1
        Me.Placas.Text = "Placas:"
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(284, -2)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(110, 40)
        Me.button1.TabIndex = 6
        Me.button1.Text = "Consultar"
        Me.button1.UseVisualStyleBackColor = False
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(109, 18)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(147, 20)
        Me.txtTicket.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 29)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Ticket:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.txtTicket)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents textBox3 As TextBox
    Private WithEvents textBox2 As TextBox
    Private WithEvents label3 As Label
    Private WithEvents label2 As Label
    Private WithEvents txtPlacas As TextBox
    Private WithEvents Placas As Label
    Private WithEvents button1 As Button
    Private WithEvents txtTicket As TextBox
    Private WithEvents label1 As Label
End Class
