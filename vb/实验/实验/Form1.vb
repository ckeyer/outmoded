Public Class Form1
    Dim start, now As Long
    Dim player As New System.Media.SoundPlayer
    Dim io As System.IO.Stream
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'player.SoundLocation = "H:\Sad Angel.wav"
        player.Stream = New IO.FileStream("H:\Sad Angel.wav", System.IO.FileMode.Open)
        start = player.Stream.Position
            player.LoadAsync()
            player.Play()
    End Sub
End Class
