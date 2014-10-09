Public Class Form1

    Private Sub StudentsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.StudentsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClassesDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“ClassesDataSet.Students”中。您可以根据需要移动或删除它。
        Me.StudentsTableAdapter.Fill(Me.ClassesDataSet.Students)
        Me.ToolTip1.UseFading = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.StudentsBindingSource.Position += 1
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If StudentsDataGridView.Visible = False Then
            Button1.Top += 160
            Button1.Text = "收起"
            StudentsDataGridView.Visible = True
            Me.Height += 170
        Else
            Me.Height -= 170
            StudentsDataGridView.Visible = False
            Button1.Text = "展开列表"
            Button1.Top -= 160
        End If
    End Sub
End Class
