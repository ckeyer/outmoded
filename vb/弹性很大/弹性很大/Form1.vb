Public Class Form1
    Public speed As Integer = 4
    Public funx As Integer = speed
    Public funy As Integer = speed
    Private WithEvents Ball1 As Ball

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Ball1 = New Ball
        Me.Controls.Add(Ball1)
    End Sub



    'Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MyMove()
    End Sub


    Private Sub ccom(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        funx = speed
        funy = speed
        Timer1.Stop()
        Timer1.Enabled = False
        MyMove()
    End Sub

    Public Sub MyMove()
        If Label1.Left < 0 Or (Label1.Left + Label1.Width + 15) > Width Then
            funx = -funx
        End If

        If Label1.Top < 0 Or (Label1.Top + Label1.Height * 2) > Height Then
            funy = -funy
        End If
        Label1.Left += funx
        Label1.Top += funy

    End Sub

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Button1.Top = Height - 150
        Button1.Left = Width - 150
        Button2.Left = Width - 150
        Button2.Top = Height - 100
        Button3.Left = Width / 2 - 60
        Button3.Top = Height / 2 - 35

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        funy = -funy
        funx = -funx
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        funy = -funy
        funx = -funx
    End Sub
End Class
