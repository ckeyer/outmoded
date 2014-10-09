Public Class Form6

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i, j As Integer
        For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(CType(i, Integer), True)
        Next

        For i = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(CType(i, Integer), True)
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j As Integer
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(CType(i, Integer), True)
        Next

        For i = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(CType(i, Integer), True)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j As Integer
        Dim str As String = ""
        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
            If i <> 0 Then
                str &= ","
            End If
            str &= " Students." & CheckedListBox1.CheckedItems(i) & " as " & CheckedListBox1.CheckedItems(i)
        Next
        For i = 0 To CheckedListBox2.CheckedItems.Count - 1
            str &= ", 选课表." & CheckedListBox2.CheckedItems(i) & " as " & CheckedListBox2.CheckedItems(i)
        Next
        Form5.sqlfirst = "select " & str & " from Students,选课表 "
        Me.Close()
    End Sub
End Class