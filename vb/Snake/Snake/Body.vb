Public Class Body
    Public site As Point
    Public stp As Integer = 10

    Private Sub Body_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With PictureBox1
            .Top = 0
            .Left = 0
            .Width = Me.Width
            .Height = Me.Height
            .Enabled = True
            .Visible = True
            .Show()
        End With

    End Sub

    Sub New(ByVal stp As Integer)
        InitializeComponent()
        Height = stp
        Width = stp
        Me.BackgroundImage = ImageList1.Images(2)
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Sub New(ByVal stp As Integer, ByVal p As Point)
        InitializeComponent()
        Me.site = p
        Me.stp = stp
        Height = stp
        Width = stp
        Top = p.Y * stp
        Left = p.X * stp
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Sub New(ByVal p As Point)
        InitializeComponent()
        Me.site = p
        Me.stp = Form1.stp
        Height = stp
        Width = stp
        Left = p.X * stp
        Top = p.Y * stp
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Public Function getbody() As Point
        With site
            .X = Left / stp
            .Y = Top / stp
        End With
        getbody = site
    End Function

    '有方向的下一个
    Public Function getnext(ByVal ori As Integer) As Point
        Dim nxt As Point
        With site
            .X = Left / stp
            .Y = Top / stp
        End With
        nxt.X = site.X
        nxt.Y = site.Y
        Select Case ori
            Case 1
                If (nxt.Y <= 0) Then
                    nxt.Y = Form1.snake.dr.Y - 1
                Else
                    nxt.Y -= 1
                End If
            Case 2
                If (nxt.Y >= Form1.snake.dr.Y - 1) Then
                    nxt.Y = 0
                Else
                    nxt.Y += 1
                End If
            Case 3
                If (nxt.X = 0) Then
                    nxt.X = Form1.snake.dr.X - 1
                Else
                    nxt.X -= 1
                End If
            Case 4
                If (nxt.X = Form1.snake.dr.X - 1) Then
                    nxt.X = 0
                Else
                    nxt.X += 1
                End If
        End Select
        getnext = nxt
    End Function

    '移动到下一个
    Public Sub move(ByVal ori As Integer)
        Select Case ori
            Case 1
                Me.moveto(Me.getnext(1))
            Case 2
                Me.moveto(Me.getnext(2))
            Case 3
                Me.moveto(Me.getnext(3))
            Case 4
                Me.moveto(Me.getnext(4))
        End Select
    End Sub

    '移动或者跟换位置方法
    Public Sub moveto(ByVal p As Point)
        With site
            .X = Left / stp
            .Y = Top / stp
        End With
        Form1.insnet(site, 0)
        Me.Left = p.X * stp
        Me.Top = p.Y * stp
        Form1.insnet(p, 1)
    End Sub

    Private Sub Body_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                Form1.snake.setori(1)
            Case Keys.Down
                Form1.snake.setori(2)
            Case Keys.Left
                Form1.snake.setori(3)
            Case Keys.Right
                Form1.snake.setori(4)
        End Select
    End Sub
End Class
