Imports System.Text
Imports MQTTnet
Imports MQTTnet.Server

Public Class FormPrincipal

    Private mqttServer As IMqttServer

    Private Async Sub IniciarServidor()
        Try
            BtnConectar.Enabled = False ' 🔒 Deshabilitar botón Conectar
            BtnDesconectar.Enabled = False ' Por precaución

            Dim factory As New MqttFactory()
            mqttServer = factory.CreateMqttServer()

            Dim options = New MqttServerOptionsBuilder() _
            .WithDefaultEndpoint() _
            .WithDefaultEndpointPort(1883) _
            .Build()

            mqttServer.UseApplicationMessageReceivedHandler(AddressOf ManejadorDeMensajes)

            Await mqttServer.StartAsync(options)
            AgregarALaConsola("✅ Servidor MQTT iniciado en puerto 1883.")

            BtnDesconectar.Enabled = True ' 🔓 Habilitar botón Detener
        Catch ex As Exception
            AgregarALaConsola("❌ Error al iniciar el servidor MQTT: " & ex.Message)
            BtnConectar.Enabled = True ' Volver a habilitar si falló
        End Try
    End Sub

    Private Async Sub DetenerServidor()
        Try
            BtnDesconectar.Enabled = False ' 🔒 Deshabilitar botón Detener
            BtnConectar.Enabled = False

            If mqttServer IsNot Nothing Then
                Await mqttServer.StopAsync()
                AgregarALaConsola("🛑 Servidor MQTT detenido.")
            End If

            BtnConectar.Enabled = True ' 🔓 Habilitar botón Conectar
        Catch ex As Exception
            AgregarALaConsola("❌ Error al detener el servidor: " & ex.Message)
            BtnDesconectar.Enabled = True ' Volver a habilitar si falló
        End Try
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

        Talertar.Enabled = True

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

    Private Sub Talertar_Tick(sender As Object, e As EventArgs) Handles Talertar.Tick
        txtConsola.Clear()
    End Sub
End Class