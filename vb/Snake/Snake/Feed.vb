Public Class Feed
    Dim picky As Integer = 0
    Dim x As Integer
    Dim y As Integer


    Private Sub Feed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .Width = Form1.stp
            .Height = Form1.stp
        End With
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Select Case picky
            Case 0
                Me.BackgroundImage = ImageListfeed.Images(picky)
                picky = 1
            Case 1
                Me.BackgroundImage = ImageListfeed.Images(picky)
                picky = 2
            Case 2
                Me.BackgroundImage = ImageListfeed.Images(picky)
                picky = 0
        End Select
        Form1.insnet(x, y, 2)
    End Sub


    '测试用new方法
    Sub New(ByVal p As Point)
        InitializeComponent()
        With Me
            .Width = Form1.stp
            .Height = Form1.stp
        End With
        With Me
            .Left = p.X * .Width
            .Top = p.Y * .Height
            .Timer1.Enabled = True
            .Timer1.Start()
        End With
        Form1.insnet(p, 2)
    End Sub

    Sub New()
        InitializeComponent()
        With Me
            .Width = Form1.stp
            .Height = Form1.stp
        End With
        Randomize()
        Me.x = Rnd() * (Form1.column - 1)
        Me.y = Rnd() * (Form1.line - 1)
            Do While Form1.getnet(x, y) <> 0
            Randomize()
            Me.x = Rnd() * (Form1.column - 1)
            Me.y = Rnd() * (Form1.line - 1)
            Loop

        With Me
            .Left = x * Width
            .Top = y * .Height
            .Timer1.Enabled = True
            .Timer1.Start()
        End With
        Form1.insnet(x, y, 2)
    End Sub

    Public Function getfeed() As Point
        Dim p As Point
        p.X = Me.x
        p.Y = Me.y
        getfeed = p
    End Function

    Function hashcode() As Integer
        hashcode = x * 100 + y
    End Function


    Overrides Function GetHashCode() As Integer
        GetHashCode = x * 100 + y
    End Function

End Class
