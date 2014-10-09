Imports System.Net
Imports System.Net.Sockets

Public Class Form4
    Dim localip As System.Net.IPAddress
    Dim localport As Integer = 6021
    Dim ipend As Net.IPEndPoint
    Dim Ssco As Net.Sockets.Socket
    Dim ctcp As Net.Sockets.TcpClient


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ipend = New Net.IPEndPoint(Net.IPAddress.Parse("127.0.0.1"), localport)
        Ssco = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Ssco.Connect(ipend)
        If Ssco.Connected Then
            Label1.Text = " 已连接"
        End If
    End Sub
End Class