Public Class Form7

    Dim dbfile As String = "H:\WCJ\VB\学生管理系统\学生管理系统\Classes.mdb"
    Dim conn As OleDb.OleDbConnection
    Dim mycomb As New OleDb.OleDbCommand
    Dim mydat As New DataSet

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        


        conn = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbfile)

        Dim sqlload As String = "select distinct 选课表.课程 from 选课表"
        Dim myadr As New OleDb.OleDbDataAdapter(sqlload, conn)

        Try
            myadr.Fill(mydat, "Students1")
        Catch ex As Exception
            MsgBox("统计查询出错1")
        End Try
            Dim i As Integer
        For i = 0 To mydat.Tables("Students1").Rows.Count - 1
            ComboBox1.Items.Add(mydat.Tables("Students1").Rows(i).Item(0))
        Next
        ComboBox1.Text = "全部"

        mydat = New DataSet
        sqlload = "select distinct Students.学号,Students.姓名,Students.专业,选课表.课程,选课表.成绩 " &
                "from Students,选课表 " &
                "where 选课表.学号 = Students.学号 " 

        myadr = New OleDb.OleDbDataAdapter(sqlload, conn)

        Try
            myadr.Fill(mydat, "select0")
        Catch ex As Exception
            MsgBox("统计查询出错2")
        End Try
        DataGridView1.DataSource = mydat.Tables("select0")

        Dim max, min, sum As Double
        max = 0
        min = 100
        sum = 0

        For i = 0 To mydat.Tables("select0").Rows.Count - 1
            If max < CDbl(mydat.Tables("select0").Rows(i).Item("成绩")) Then
                max = CDbl(mydat.Tables("select0").Rows(i).Item("成绩"))
            End If
            If min > CDbl(mydat.Tables("select0").Rows(i).Item("成绩")) Then
                min = CDbl(mydat.Tables("select0").Rows(i).Item("成绩"))
            End If
            sum += CDbl(mydat.Tables("select0").Rows(i).Item("成绩"))
        Next
        TextBox1.Text = max.ToString
        TextBox2.Text = min.ToString
        TextBox3.Text = sum / mydat.Tables("select0").Rows.Count
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        mydat = New DataSet
        Dim sqlload As String = "select distinct Students.学号,Students.姓名,Students.专业,选课表.课程,选课表.成绩 " &
                "from Students,选课表 " &
                "where 选课表.学号 = Students.学号 " &
                " and 选课表.课程 = '" & ComboBox1.Text & "'"

        Dim myadr As New OleDb.OleDbDataAdapter(sqlload, conn)

        Try
            myadr.Fill(mydat, "select1")
        Catch ex As Exception
            MsgBox("统计查询出错")
        End Try
        DataGridView1.DataSource = mydat.Tables("select1")

        TextBox4.Enabled = True
        TextBox5.Enabled = True
        Label4.Enabled = True
        Label5.Enabled = True

        Dim max, min, sum, jige As Double
        max = 0
        min = 100
        sum = 0
        jige = 0
        Dim i As Integer = 0
        For i = 0 To mydat.Tables("select1").Rows.Count - 1
            If max < CDbl(mydat.Tables("select1").Rows(i).Item("成绩")) Then
                max = CDbl(mydat.Tables("select1").Rows(i).Item("成绩"))
            End If
            If min > CDbl(mydat.Tables("select1").Rows(i).Item("成绩")) Then
                min = CDbl(mydat.Tables("select1").Rows(i).Item("成绩"))
            End If
            If 60 <= CDbl(mydat.Tables("select1").Rows(i).Item("成绩")) Then
                jige += 1
            Else
                DataGridView1.Rows(i).Selected = True
            End If
            sum += CDbl(mydat.Tables("select1").Rows(i).Item("成绩"))
        Next
        TextBox1.Text = max.ToString
        TextBox2.Text = min.ToString
        TextBox3.Text = sum / mydat.Tables("select1").Rows.Count
        TextBox4.Text = mydat.Tables("select1").Rows.Count
        TextBox5.Text = jige
    End Sub

End Class