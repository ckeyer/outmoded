Public Class Form5
    Dim dbfile As String = "H:\WCJ\VB\学生管理系统\学生管理系统\Classes.mdb"
    Public sqlfirst As String = "select * from Students,选课表 "
    Dim sql As String
    Private Sub StudentsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.StudentsBindingSource.EndEdit()

    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“ClassesDataSet.Students”中。您可以根据需要移动或删除它。
        Me.StudentsTableAdapter.Fill(Me.ClassesDataSet.Students)
        'TODO: 这行代码将数据加载到表“ClassesDataSet.Students”中。您可以根据需要移动或删除它。
        Me.StudentsTableAdapter.Fill(Me.ClassesDataSet.Students)


        Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbfile)
        Dim mycomb As New OleDb.OleDbCommand
        Dim mydat As New DataSet
        Dim sqlload As String = "select distinct Students.专业 from Students"
        Dim myadr As New OleDb.OleDbDataAdapter(sqlload, conn)

        Try
            myadr.Fill(mydat, "Students1")
        Catch ex As Exception
            MsgBox("查询出错")
            MsgBox(sql)
        End Try
        TextBox1.Text = ""
        Dim i As Integer
        For i = 0 To mydat.Tables("Students1").Rows.Count - 1
            ComboBox1.Items.Add(mydat.Tables("Students1").Rows(i).Item(0))
        Next
        ComboBox1.Text = mydat.Tables("Students1").Rows(1).Item(0)
        'ComboBox1.DataSource = mydat.Tables("Students1").Rows(1)
    End Sub

    Private Sub FillBy1ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.StudentsTableAdapter.FillBy1(Me.ClassesDataSet.Students)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Panel1.Left > 120 Then
            Panel1.Left -= 150
            Me.Width += 150
            DataGridView1.Visible = True
        End If
        Dim sqlstr As String = " where Students.学号 = 选课表.学号 "
        If CheckBox1.Checked = True Then
            sqlstr &= "and Students.姓名 like('%" & TextBox1.Text & "%') "
        End If

        If CheckBox2.Checked = True Then

            sqlstr &= "and Students.学号 ='" & TextBox2.Text & "' "
        End If

        If CheckBox3.Checked = True Then
            If RadioButton1.Checked = True Then
                sqlstr &= "and Students.性别 ='男' "
            ElseIf RadioButton2.Checked = True Then
                sqlstr &= "and Students.性别 ='女' "
            End If
        End If

        If CheckBox4.Checked = True Then
            If RadioButton3.Checked = True Then
                sqlstr &= "and Students.党员 =false "
            ElseIf RadioButton4.Checked = True Then
                sqlstr &= "and Students.党员 =true "
            End If
        End If

        If CheckBox5.Checked = True Then
            sqlstr &= "and Students.专业 ='" & ComboBox1.Text & "'"
        End If

        If CheckBox6.Checked = True Then
            sqlstr &= "and Students.助学金 " & ComboBox2.Text & TextBox3.Text
        End If

        sql = sqlfirst & sqlstr
        Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbfile)
        Dim mycomb As New OleDb.OleDbCommand
        Dim mydat As New DataSet
        Dim myadr As New OleDb.OleDbDataAdapter(sql, conn)
        Try
            myadr.Fill(mydat, "Students2")
        Catch ex As Exception
            MsgBox("查询出错")
            'MsgBox(sql)
        End Try
        TextBox1.Text = ""
        DataGridView1.DataSource = mydat.Tables("Students2")

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Me.RadioButton1.Enabled = True
            Me.RadioButton2.Enabled = True
        Else
            Me.RadioButton1.Enabled = False
            Me.RadioButton2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Me.RadioButton3.Enabled = True
            Me.RadioButton4.Enabled = True
        Else
            Me.RadioButton3.Enabled = False
            Me.RadioButton4.Enabled = False
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            ComboBox2.Enabled = True
            TextBox3.Enabled = True
        Else
            ComboBox2.Enabled = False
            TextBox3.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form6.Show(Me)

    End Sub

End Class