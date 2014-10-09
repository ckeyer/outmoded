<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Feed
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Feed))
        Me.ImageListfeed = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ImageListfeed
        '
        Me.ImageListfeed.ImageStream = CType(resources.GetObject("ImageListfeed.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListfeed.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListfeed.Images.SetKeyName(0, "color (2).png")
        Me.ImageListfeed.Images.SetKeyName(1, "color (7).png")
        Me.ImageListfeed.Images.SetKeyName(2, "color (9).png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Feed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DoubleBuffered = True
        Me.Name = "Feed"
        Me.Size = New System.Drawing.Size(189, 196)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageListfeed As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
