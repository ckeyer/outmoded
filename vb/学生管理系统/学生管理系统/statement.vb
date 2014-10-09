Public Class statement

    Private Sub statement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“ClassesDataSet.Students”中。您可以根据需要移动或删除它。
        Me.StudentsTableAdapter.Fill(Me.ClassesDataSet.Students)
        'TODO: 这行代码将数据加载到表“ClassesDataSet.选课表”中。您可以根据需要移动或删除它。
        Me.选课表TableAdapter.Fill(Me.ClassesDataSet.选课表)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class