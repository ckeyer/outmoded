Public Class NinePic
    Public cusbox(9) As littlebox
    Dim backgdnum As Integer = 0
    Private Sub NinePic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timerbackgd.Enabled = True
        Timerbackgd.Start()
        BackgroundImage = mypics.Images(backgdnum)
        BackgroundImageLayout = ImageLayout.Stretch
        Dim i As Integer
        For i = 0 To 8
            cusbox(i) = New littlebox
            Me.Controls.Add(cusbox(i))
        Next
        Dim j As Integer
        Dim n As Integer
        For i = 0 To 2
            For j = 0 To 2
                n = i * 3 + j
                With cusbox(n)
                    .Top = 150 * i
                    .Left = 150 * j
                    .Width = 150
                    .Height = 150
                End With
                If (i = 1 And j = 1) Then
                    cusbox(n).backcl = Color.BlueViolet
                ElseIf (i = 1 Or j = 1) Then
                    cusbox(n).backcl = Color.SkyBlue
                End If
            Next
        Next

    End Sub

    Private Sub NinePic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click

    End Sub

    Private Sub Timerbackgd_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerbackgd.Tick
        If (backgdnum < backgdpics.Images.Count - 1) Then
            backgdnum += 1
        Else
            backgdnum = 0
        End If
        Me.BackgroundImage = backgdpics.Images(backgdnum)
    End Sub

End Class

