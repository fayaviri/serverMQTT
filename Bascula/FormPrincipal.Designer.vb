<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Me.puertoserial = New System.IO.Ports.SerialPort(Me.components)
        Me.TLevantarConexion = New System.Windows.Forms.Timer(Me.components)
        Me.Talertar = New System.Windows.Forms.Timer(Me.components)
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.BtnDesconectar = New System.Windows.Forms.Button()
        Me.lblEstadoSerial = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TBorrar = New System.Windows.Forms.Timer(Me.components)
        Me.txtConsola = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TLevantarConexion
        '
        Me.TLevantarConexion.Interval = 3000
        '
        'Talertar
        '
        Me.Talertar.Interval = 5000
        '
        'BtnConectar
        '
        Me.BtnConectar.Location = New System.Drawing.Point(17, 72)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(75, 23)
        Me.BtnConectar.TabIndex = 14
        Me.BtnConectar.Text = "Iniciar"
        Me.BtnConectar.UseVisualStyleBackColor = True
        '
        'BtnDesconectar
        '
        Me.BtnDesconectar.Location = New System.Drawing.Point(98, 72)
        Me.BtnDesconectar.Name = "BtnDesconectar"
        Me.BtnDesconectar.Size = New System.Drawing.Size(75, 23)
        Me.BtnDesconectar.TabIndex = 15
        Me.BtnDesconectar.Text = "Detener"
        Me.BtnDesconectar.UseVisualStyleBackColor = True
        '
        'lblEstadoSerial
        '
        Me.lblEstadoSerial.AutoSize = True
        Me.lblEstadoSerial.Location = New System.Drawing.Point(14, 35)
        Me.lblEstadoSerial.Name = "lblEstadoSerial"
        Me.lblEstadoSerial.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoSerial.TabIndex = 16
        Me.lblEstadoSerial.Text = "Estado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnConectar)
        Me.GroupBox1.Controls.Add(Me.lblEstadoSerial)
        Me.GroupBox1.Controls.Add(Me.BtnDesconectar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 137)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conectar"
        '
        'TBorrar
        '
        Me.TBorrar.Interval = 4000
        '
        'txtConsola
        '
        Me.txtConsola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConsola.Location = New System.Drawing.Point(12, 155)
        Me.txtConsola.Multiline = True
        Me.txtConsola.Name = "txtConsola"
        Me.txtConsola.Size = New System.Drawing.Size(369, 444)
        Me.txtConsola.TabIndex = 31
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(97, 26)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Server MQTT"
        Me.NotifyIcon1.Visible = True
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(396, 611)
        Me.Controls.Add(Me.txtConsola)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema Bascula Digital"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents puertoserial As System.IO.Ports.SerialPort
    Friend WithEvents TLevantarConexion As System.Windows.Forms.Timer
    Friend WithEvents Talertar As System.Windows.Forms.Timer
    Friend WithEvents BtnConectar As Button
    Friend WithEvents BtnDesconectar As Button
    Friend WithEvents lblEstadoSerial As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TBorrar As Timer
    Friend WithEvents txtConsola As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
End Class
