Public Class NinePic
    Dim backgdnum As Integer = 0
    Private Sub NinePic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        BackgroundImage = mypics.Images(backgdnum)
        BackgroundImageLayout = ImageLayout.Stretch
      
    End Sub


End Class

