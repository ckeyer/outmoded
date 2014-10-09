Imports System.Net
Imports System.Net.Sockets

Public Class Form3
    Dim localip As System.Net.IPAddress
    Dim localport As Integer = 6021
    Dim ipend As Net.IPEndPoint
    Dim Ssco As Net.Sockets.Socket
    Dim listener As Net.Sockets.TcpListener
    Dim bloklog As Integer = 100

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        localip = Net.IPAddress.Parse("127.0.0.1")
        ipend = New Net.IPEndPoint(localip, localport)
        Ssco = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Ssco.Bind(ipend)
        Ssco.Listen(100)
        'listener = New Sockets.TcpListener(Net.IPAddress.Parse("127.0.0.1"), localport)
        'listener.Start(bloklog)


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Ssco.Close()
        'Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form4.Show()
    End Sub
End Class