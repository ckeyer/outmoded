Public Class Form1
    Public stp As Integer = 10
    Public line As Integer = 25
    Public column As Integer = 45
    Dim net(column - 1, line - 1) As Integer
    Public snake As Snake
    Dim feed As Feed
    Private Sub Form1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Me.Close()
    End Sub


    'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'TextBox1.Text = getnet(Me.feed.getfeed())
    '    feed = New Feed()
    '    Me.snake.Controls.Add(feed)
    '    With Me.snake.Timersnake
    '        .Enabled = True
    '        .Start()
    '    End With
    'End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.run()
    End Sub

    Sub run()
        snake = New Snake
        Me.Controls.Add(snake)
        With snake
            .Show()
        End With
        feed = New Feed()
        Me.snake.Controls.Add(feed)
    End Sub

    Public Sub insnet(ByVal p As Point, ByVal key As Integer)
        net(p.X, p.Y) = key
    End Sub

    Public Sub insnet(ByVal x As Integer, ByVal y As Integer, ByVal key As Integer)
        net(x, y) = key
    End Sub

    Public Function getnet(ByVal p As Point) As Integer
        getnet = net(p.X, p.Y)
    End Function

    Public Function getnet(ByVal x As Integer, ByVal y As Integer) As Integer
        getnet = net(x, y)
    End Function

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                snake.setori(1)
                MsgBox("ms001:hhhhhh")
            Case Keys.Down
                snake.setori(2)
            Case Keys.Left
                snake.setori(3)
            Case Keys.Right
                snake.setori(4)
        End Select
    End Sub

    Private Sub Butstart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butstart.Click
        If (Butstart.Text = "开始") Then
            Butstart.Text = "暂停"
            snake.Timersnake.Enabled = True

        ElseIf (Butstart.Text = "继续") Then
            Butstart.Text = "暂停"
            snake.Timersnake.Enabled = True
        Else
            snake.Timersnake.Enabled = False
            Butstart.Text = "继续"
        End If
    End Sub
End Class
