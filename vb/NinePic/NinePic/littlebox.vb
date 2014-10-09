Imports System.Random

Public Class littlebox
    Dim mdnow As Integer = 0
    Dim latetm As Integer = 300
    Dim piccount As Integer = NinePic.mypics.Images.Count
    Public backcl As Color = Color.DeepSkyBlue

    Private Sub Timerptop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerptop.Tick
        Dim num As Integer
        Dim md As Integer
        Randomize()
        num = Int(Rnd() * piccount)
        md = Int(Rnd() * (8) + 1) / 3
        Me.changepic(md, num)
    End Sub

    Public Sub changepic(ByVal mdinchg As Integer, ByVal pioutchg As Integer)
        Randomize()
        Select Case mdnow
            Case 0
                Select Case mdinchg
                    Case 1
                        Me.zetoon(pioutchg)
                        mdnow = 1
                    Case 2
                        Me.zetotw(pioutchg)
                        mdnow = 2
                End Select
            Case 1
                Select Case mdinchg
                    Case 0
                        Me.ontoze(pioutchg)
                        mdnow = 0
                    Case 2
                        Me.ontotw(pioutchg)
                        mdnow = 2
                End Select
            Case 2
                Select Case mdinchg
                    Case 0
                        Me.twtoze(pioutchg)
                        mdnow = 0
                    Case 1
                        Me.twtoon(pioutchg)
                        mdnow = 1
                End Select
        End Select
    End Sub

    Private Sub zetoon(ByVal pioutchag As Integer)
        With PictureBoxbut
            .Width = 150
            .Height = 10
            .Top = 70
            .Left = 0
            .BackColor = backcl
            .Visible = True
        End With
        With PictureBoxtop
            .Visible = False
        End With
        Timerzetoon.Enabled = True
        Timerptop.Enabled = False
        mdnow = 1
    End Sub

    Private Sub zetotw(ByVal pioutchag As Integer)
        With PictureBoxtop
            .Width = 150
            .Height = 10
            .Top = 70
            .Left = 0
            .Visible = True
            .Image = NinePic.mypics.Images(pioutchag)
        End With
        PictureBoxbut.Visible = False
        PictureBoxbut.BackColor = backcl
        Timerptop.Enabled = False
        Timerzetotw.Enabled = True
        mdnow = 2
    End Sub

    Private Sub ontoze(ByVal pioutchag As Integer)
        Timerontoze.Enabled = True
        Timerptop.Enabled = False
        PictureBoxtop.Visible = False
        mdnow = 0
    End Sub

    Private Sub ontotw(ByVal pioutchag As Integer)
        With PictureBoxtop
            .Width = 150
            .Height = 10
            .Top = 70
            .Left = 0
            .Visible = True
            .Image = NinePic.mypics.Images(pioutchag)
        End With
        PictureBoxbut.BackColor = backcl
        Timerptop.Enabled = False
        Timerontotw.Enabled = True
        mdnow = 2
    End Sub

    Private Sub twtoze(ByVal pioutchag As Integer)
        Timertwtoze.Enabled = True
        Timerptop.Enabled = False
        PictureBoxbut.Visible = False
        mdnow = 0
    End Sub

    Private Sub twtoon(ByVal pioutchag As Integer)
        Timertwtoon.Enabled = True
        Timerptop.Enabled = False
        mdnow = 1
    End Sub

    Private Sub metome(ByVal pioutchag As Integer)

    End Sub

    Private Sub Timermdzetoon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerzetoon.Tick
        If (PictureBoxbut.Top > 0) Then
            PictureBoxbut.Top -= 5
        End If
        If (PictureBoxbut.Height < 150) Then
            PictureBoxbut.Height += 10
        End If
        If (PictureBoxbut.Top <= 0 And PictureBoxbut.Height >= 150) Then
            Timerzetoon.Enabled = False
            Dim timetmp As Integer
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If

    End Sub

    Private Sub Timerzetotw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerzetotw.Tick
        If (PictureBoxtop.Top > 0) Then
            PictureBoxtop.Top -= 5
        End If
        If (PictureBoxtop.Height < 150) Then
            PictureBoxtop.Height += 10
        End If
        If (PictureBoxtop.Top <= 0 And PictureBoxtop.Height >= 150) Then
            Timerzetotw.Enabled = False
            Dim timetmp As Integer
            Randomize()
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If
    End Sub

    Private Sub Timerontoze_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerontoze.Tick
        If (PictureBoxbut.Top < 70) Then
            PictureBoxbut.Top += 5
        End If
        If (PictureBoxbut.Height > 10) Then
            PictureBoxbut.Height -= 10
        End If
        If (PictureBoxbut.Top >= 70 And PictureBoxbut.Height <= 10) Then
            Timerontoze.Enabled = False
            PictureBoxbut.Visible = False
            Dim timetmp As Integer
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If
    End Sub

    Private Sub Timerontotw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerontotw.Tick
        If (PictureBoxtop.Top > 0) Then
            PictureBoxtop.Top -= 5
        End If
        If (PictureBoxtop.Height < 150) Then
            PictureBoxtop.Height += 10
        End If
        If (PictureBoxtop.Top <= 0 And PictureBoxtop.Height >= 150) Then
            Timerontotw.Enabled = False
            Dim timetmp As Integer
            Randomize()
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If
    End Sub

    Private Sub Timertwtoze_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timertwtoze.Tick
        If (PictureBoxtop.Top < 70) Then
            PictureBoxtop.Top += 5
        End If
        If (PictureBoxtop.Height > 10) Then
            PictureBoxtop.Height -= 10
        End If
        If (PictureBoxtop.Top >= 70 And PictureBoxtop.Height <= 10) Then
            Timertwtoze.Enabled = False
            PictureBoxtop.Visible = False
            Dim timetmp As Integer
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If
    End Sub

    Private Sub Timertwtoon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timertwtoon.Tick
        If (PictureBoxtop.Top < 70) Then
            PictureBoxtop.Top += 5
        End If
        If (PictureBoxtop.Height > 10) Then
            PictureBoxtop.Height -= 10
        End If
        If (PictureBoxtop.Top >= 70 And PictureBoxtop.Height <= 10) Then
            Timertwtoon.Enabled = False
            PictureBoxtop.Visible = False
            Dim timetmp As Integer
            timetmp = Int(Rnd() * 15 + 1) * latetm
            Timerptop.Interval = timetmp
            Timerptop.Enabled = True
        End If
    End Sub

    Public Sub clossall()
        NinePic.Close()
    End Sub

    Private Sub PictureBoxtop_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxtop.DoubleClick
        clossall()
    End Sub

    Private Sub PictureBoxbut_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxbut.DoubleClick
        clossall()
    End Sub

    Private Sub littlebox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        clossall()
    End Sub
End Class
