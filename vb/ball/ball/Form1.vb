Public Class Form1
    Dim a, b, c As New Ball
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.BackColor = Color.Transparent
        PictureBox2.BackColor = Color.Transparent
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
        Else
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Form5.Show(Me)
        Form6.Show(Me)
        Form7.Show(Me)

        Form5.Width = 120
        Form5.Height = 120
        Form6.Width = 120
        Form6.Height = 120
        Form7.Width = 120
        Form7.Height = 120

        Form5.BackgroundImage = Me.ImageList1.Images(0)
        Form6.BackgroundImage = Me.ImageList1.Images(1)
        Form7.BackgroundImage = Me.ImageList1.Images(0)

        a.setBall(80, 80, 60)
        a.setRange(1200 - 80, 800 - 80)
        a.setSpeed(3, 4)
        a.addFriend(b)
        b.setBall(160, 160, 60)
        b.setRange(1200 - 80, 800 - 80)
        b.setSpeed(-4, -4)
        a.addFriend(c)
        c.setBall(600, 160, 60)
        c.setRange(1200 - 80, 800 - 80)
        c.setSpeed(-4, -2)
        setAB()

    End Sub

    Sub setAB()
        Form5.Left = a.x - a.r
        Form5.Top = a.y - a.r
        Form6.Left = b.x - b.r
        Form6.Top = b.y - b.r
        Form7.Left = c.x - c.r
        Form7.Top = c.y - c.r
    End Sub

    Private Sub Form1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        setAB()
        a.move()
    End Sub
End Class
