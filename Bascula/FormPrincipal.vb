Imports System.Text
Imports MQTTnet
Imports MQTTnet.Server

Public Class FormPrincipal

    Private mqttServer As IMqttServer

    Private Async Sub IniciarServidor()
        Try
            Dim factory As New MqttFactory()
            mqttServer = factory.CreateMqttServer()

            ' Configurar opciones del servidor
            Dim options = New MqttServerOptionsBuilder() _
                .WithDefaultEndpoint() _
                .WithDefaultEndpointPort(1883) _
                .Build()

            ' Asignar manejador de mensajes recibidos
            mqttServer.UseApplicationMessageReceivedHandler(AddressOf ManejadorDeMensajes)

            ' Iniciar el servidor
            Await mqttServer.StartAsync(options)
            AgregarALaConsola("✅ Servidor MQTT iniciado en puerto 1883.")

        Catch ex As Exception
            AgregarALaConsola("❌ Error al iniciar el servidor MQTT: " & ex.Message)
        End Try
    End Sub

    Private Async Sub DetenerServidor()
        If mqttServer IsNot Nothing Then
            Await mqttServer.StopAsync()
            AgregarALaConsola("🛑 Servidor MQTT detenido.")
        End If
    End Sub

    ' Manejador para los mensajes entrantes
    Private Sub ManejadorDeMensajes(e As MqttApplicationMessageReceivedEventArgs)
        Dim topic = e.ApplicationMessage.Topic
        Dim payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload)

        ' Invocar en el hilo de la interfaz gráfica
        Invoke(Sub()
                   AgregarALaConsola($"📨 Tópico: {topic}{Environment.NewLine}    Mensaje: {payload}")
               End Sub)
    End Sub

    ' Agrega texto al TextBox de consola con scroll automático
    Private Sub AgregarALaConsola(mensaje As String)
        txtConsola.AppendText(mensaje & Environment.NewLine)
        txtConsola.SelectionStart = txtConsola.Text.Length
        txtConsola.ScrollToCaret()
    End Sub

    Private Sub BtnConectar_Click(sender As Object, e As EventArgs) Handles BtnConectar.Click
        IniciarServidor()
    End Sub

    Private Sub BtnDesconectar_Click(sender As Object, e As EventArgs) Handles BtnDesconectar.Click
        DetenerServidor()
    End Sub

    ' Configurar estilo visual desde código
    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Estilo general del formulario
        Me.BackColor = Color.FromArgb(30, 30, 30) ' Gris oscuro
        Me.ForeColor = Color.White
        Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)

        ' Estilo del txtConsola
        With txtConsola
            .Multiline = True
            .ScrollBars = ScrollBars.Vertical
            .ReadOnly = True
            .BackColor = Color.Black
            .ForeColor = Color.LimeGreen
            .Font = New Font("Consolas", 10, FontStyle.Regular)
            .WordWrap = False
            .BorderStyle = BorderStyle.FixedSingle
        End With

        ' Estilo botones
        ConfigurarBoton(BtnConectar, Color.ForestGreen)
        ConfigurarBoton(BtnDesconectar, Color.IndianRed)
    End Sub

    ' Aplicar estilo visual a los botones
    Private Sub ConfigurarBoton(boton As Button, colorFondo As Color)
        With boton
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = colorFondo
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Cursor = Cursors.Hand
        End With
    End Sub

End Class