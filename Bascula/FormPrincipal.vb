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
            MsgBox("✅ Servidor MQTT iniciado en puerto 1883.")

        Catch ex As Exception
            MsgBox("❌ Error al iniciar el servidor MQTT: " & ex.Message)
        End Try
    End Sub

    Private Async Sub DetenerServidor()
        If mqttServer IsNot Nothing Then
            Await mqttServer.StopAsync()
            MsgBox("🛑 Servidor MQTT detenido.")
        End If
    End Sub

    ' Manejador para los mensajes entrantes
    Private Sub ManejadorDeMensajes(e As MqttApplicationMessageReceivedEventArgs)
        Dim topic = e.ApplicationMessage.Topic
        Dim payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
        Invoke(Sub()
                   MsgBox("📨 Mensaje recibido en tópico '" & topic & "': " & payload)
               End Sub)
    End Sub

    Private Sub BtnConectar_Click(sender As Object, e As EventArgs) Handles BtnConectar.Click
        IniciarServidor()
    End Sub

    Private Sub BtnDesconectar_Click(sender As Object, e As EventArgs) Handles BtnDesconectar.Click
        DetenerServidor()
    End Sub

End Class
