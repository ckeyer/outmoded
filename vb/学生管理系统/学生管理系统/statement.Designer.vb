<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class statement
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.选课表BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClassesDataSet = New 学生管理系统.ClassesDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.选课表TableAdapter = New 学生管理系统.ClassesDataSetTableAdapters.选课表TableAdapter()
        Me.StudentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StudentsTableAdapter = New 学生管理系统.ClassesDataSetTableAdapters.StudentsTableAdapter()
        CType(Me.选课表BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StudentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '选课表BindingSource
        '
        Me.选课表BindingSource.DataMember = "选课表"
        Me.选课表BindingSource.DataSource = Me.ClassesDataSet
        '
        'ClassesDataSet
        '
        Me.ClassesDataSet.DataSetName = "ClassesDataSet"
        Me.ClassesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.StudentsBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "学生管理系统.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, -2)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(629, 333)
        Me.ReportViewer1.TabIndex = 0
        '
        '选课表TableAdapter
        '
        Me.选课表TableAdapter.ClearBeforeFill = True
        '
        'StudentsBindingSource
        '
        Me.StudentsBindingSource.DataMember = "Students"
        Me.StudentsBindingSource.DataSource = Me.ClassesDataSet
        '
        'StudentsTableAdapter
        '
        Me.StudentsTableAdapter.ClearBeforeFill = True
        '
        'statement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 331)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "statement"
        Me.Text = "statement"
        CType(Me.选课表BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StudentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents 选课表BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClassesDataSet As 学生管理系统.ClassesDataSet
    Friend WithEvents 选课表TableAdapter As 学生管理系统.ClassesDataSetTableAdapters.选课表TableAdapter
    Friend WithEvents StudentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StudentsTableAdapter As 学生管理系统.ClassesDataSetTableAdapters.StudentsTableAdapter
End Class
