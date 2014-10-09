Public Class Form2
    Dim chgd As Boolean
    Dim d As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Button1.Text = Me.BindingSource1.Count
        'Dim a As DataTable = Me.ClassesDataSet.Tables("选课表")
        'Dim adr As DataRow = a.Rows(d)
        'Dim sql As String
        'sql = "delete from Students where 学号='10101' "
        'sql = "insert into Students(学号,姓名,性别) values(10101,'fuck','男')"
        'Dim myada As New OleDb.OleDbDataAdapter(sql, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Classes.mdb")
        'Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\WCJ\VB\学生管理系统\学生管理系统\Classes.mdb")
        'Dim mycomb As New OleDb.OleDbCommand
        'conn.Open()
        'mycomb.Connection = conn
        'mycomb.CommandType = CommandType.Text
        'mycomb.CommandText = sql
        'mycomb.ExecuteNonQuery()
        'mycomb.Clone()
        'conn.Close()
        'Dim mydset As New DataSet
        'myada.Fill(mydset, sql)
        'Label1.Text = mydset.Tables(0).Rows(d).Item(1)
        'Label2.Text = mydset.Tables(0).Rows.Count
        'Label2.Text = adr.Item(1)
        'Label3.Text = adr.Item(2)
        'If d < mydset.Tables(0).Rows.Count - 1 Then
        '    d += 1
        'End If
        Dim t As Integer
        Try
            t = Me.StudentsTableAdapter.Update(Me.ClassesDataSet.Students)
        Catch ex As Exception
            MsgBox("提交错误")
        End Try
        If t <> 0 Then
            MsgBox("提交成功")
        Else
            MsgBox("提交失败")
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“ClassesDataSet1.Students”中。您可以根据需要移动或删除它。
        'TODO: 这行代码将数据加载到表“ClassesDataSet.Students”中。您可以根据需要移动或删除它。
        Me.StudentsTableAdapter.Fill(Me.ClassesDataSet.Students)
        'TODO: 这行代码将数据加载到表“ClassesDataSet.选课表”中。您可以根据需要移动或删除它。
        Me.选课表TableAdapter.Fill(Me.ClassesDataSet.选课表)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
    End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    BindingSource1.Dispose()
    '    ClassesDataSet.Dispose()
    '    Me.Close()
    'End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.StudentsTableAdapter.FillBy(Me.ClassesDataSet.Students)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub 学号TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 学号TextBox.TextChanged
        If Me.学号TextBox.Text.Length <> 6 Then
            Me.学号TextBox.BackColor = Color.Red
        Else
            Me.学号TextBox.BackColor = Color.White
        End If
    End Sub

    Private Sub 学号TextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 学号TextBox.Leave
        If Me.学号TextBox.Text.Length <> 6 Then
            MsgBox("学号必须为六位数字")
        End If

    End Sub

    Private Sub StudentsBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudentsBindingSource.PositionChanged

        If Me.StudentsBindingSource.Current(2) = "男" Then
            Me.RadioButton1.Checked = True
            Me.RadioButton2.Checked = False
        Else
            Me.RadioButton1.Checked = False
            Me.RadioButton2.Checked = True
        End If
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.Click, RadioButton1.Click
        If Me.RadioButton1.Checked = True Then
            Me.StudentsBindingSource.Current(2) = "男"
            Me.性别TextBox.Text = "男"
        End If
        If Me.RadioButton2.Checked = True Then
            Me.StudentsBindingSource.Current(2) = "女"
            Me.性别TextBox.Text = "女"
        End If
    End Sub

    Private Sub 照片PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 照片PictureBox.Click
        OpenFileDialog1.DefaultExt = ".bmp"
        OpenFileDialog1.ShowDialog()
        Dim s As String = OpenFileDialog1.FileName

        Try
            照片PictureBox.Image = Image.FromFile(s)
        Catch ex As Exception
            MsgBox("图片打开错误")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        StudentsBindingSource.AddNew()
        StudentsBindingSource.Position = StudentsBindingSource.Count - 1

    End Sub
End Class