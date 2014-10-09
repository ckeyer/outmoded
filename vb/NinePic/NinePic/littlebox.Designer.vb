<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class littlebox
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
        Me.PictureBoxbut = New System.Windows.Forms.PictureBox()
        Me.PictureBoxtop = New System.Windows.Forms.PictureBox()
        Me.Timerzetoon = New System.Windows.Forms.Timer(Me.components)
        Me.Timerptop = New System.Windows.Forms.Timer(Me.components)
        Me.Timerzetotw = New System.Windows.Forms.Timer(Me.components)
        Me.Timerontoze = New System.Windows.Forms.Timer(Me.components)
        Me.Timerontotw = New System.Windows.Forms.Timer(Me.components)
        Me.Timertwtoze = New System.Windows.Forms.Timer(Me.components)
        Me.Timertwtoon = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBoxbut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxtop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxbut
        '
        Me.PictureBoxbut.BackColor = System.Drawing.Color.CornflowerBlue
        Me.PictureBoxbut.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxbut.Name = "PictureBoxbut"
        Me.PictureBoxbut.Size = New System.Drawing.Size(150, 150)
        Me.PictureBoxbut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxbut.TabIndex = 0
        Me.PictureBoxbut.TabStop = False
        Me.PictureBoxbut.Visible = False
        '
        'PictureBoxtop
        '
        Me.PictureBoxtop.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxtop.Name = "PictureBoxtop"
        Me.PictureBoxtop.Size = New System.Drawing.Size(150, 150)
        Me.PictureBoxtop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxtop.TabIndex = 1
        Me.PictureBoxtop.TabStop = False
        Me.PictureBoxtop.Visible = False
        '
        'Timerzetoon
        '
        Me.Timerzetoon.Interval = 30
        '
        'Timerptop
        '
        Me.Timerptop.Enabled = True
        Me.Timerptop.Interval = 2000
        '
        'Timerzetotw
        '
        Me.Timerzetotw.Interval = 30
        '
        'Timerontoze
        '
        Me.Timerontoze.Interval = 30
        '
        'Timerontotw
        '
        Me.Timerontotw.Interval = 30
        '
        'Timertwtoze
        '
        Me.Timertwtoze.Interval = 30
        '
        'Timertwtoon
        '
        Me.Timertwtoon.Interval = 30
        '
        'littlebox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PictureBoxtop)
        Me.Controls.Add(Me.PictureBoxbut)
        Me.Name = "littlebox"
        CType(Me.PictureBoxbut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxtop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxbut As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxtop As System.Windows.Forms.PictureBox
    Friend WithEvents Timerzetoon As System.Windows.Forms.Timer
    Friend WithEvents Timerptop As System.Windows.Forms.Timer
    Friend WithEvents Timerzetotw As System.Windows.Forms.Timer
    Friend WithEvents Timerontoze As System.Windows.Forms.Timer
    Friend WithEvents Timerontotw As System.Windows.Forms.Timer
    Friend WithEvents Timertwtoze As System.Windows.Forms.Timer
    Friend WithEvents Timertwtoon As System.Windows.Forms.Timer

End Class
