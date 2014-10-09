<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NinePic
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NinePic))
        Me.mypics = New System.Windows.Forms.ImageList(Me.components)
        Me.Timerbackgd = New System.Windows.Forms.Timer(Me.components)
        Me.backgdpics = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'mypics
        '
        Me.mypics.ImageStream = CType(resources.GetObject("mypics.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.mypics.TransparentColor = System.Drawing.Color.Transparent
        Me.mypics.Images.SetKeyName(0, "1393.jpg")
        '
        'Timerbackgd
        '
        Me.Timerbackgd.Enabled = True
        Me.Timerbackgd.Interval = 10000
        '
        'backgdpics
        '
        Me.backgdpics.ImageStream = CType(resources.GetObject("backgdpics.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.backgdpics.TransparentColor = System.Drawing.Color.Transparent
        Me.backgdpics.Images.SetKeyName(0, "ima (1).gif")
        Me.backgdpics.Images.SetKeyName(1, "ima (2).jpg")
        Me.backgdpics.Images.SetKeyName(2, "ima (3).jpg")
        Me.backgdpics.Images.SetKeyName(3, "ima (4).jpg")
        Me.backgdpics.Images.SetKeyName(4, "ima (5).jpg")
        Me.backgdpics.Images.SetKeyName(5, "ima (6).jpg")
        Me.backgdpics.Images.SetKeyName(6, "ima (8).jpg")
        Me.backgdpics.Images.SetKeyName(7, "ima (9).jpg")
        Me.backgdpics.Images.SetKeyName(8, "ima (13).jpg")
        Me.backgdpics.Images.SetKeyName(9, "ima (18).jpg")
        '
        'NinePic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(450, 450)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NinePic"
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mypics As System.Windows.Forms.ImageList
    Friend WithEvents Timerbackgd As System.Windows.Forms.Timer
    Friend WithEvents backgdpics As System.Windows.Forms.ImageList

End Class
