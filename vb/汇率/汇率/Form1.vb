Public Class Form1
    Public dDtoR As Double
    Public money As Money
    Public fromm As String
    Public tom As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RePar()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("亲，忘记填写金额了哦")
            Return
        End If
        If TextBox1.Text = "" Then
            RePar()
        End If
        Label3.Text = tom + (CDbl(TextBox2.Text) * CDbl(TextBox1.Text)).ToString()
    End Sub

    Public Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        RePar()
    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        Button2.Text = ComboBox1.Text
        If ComboBox1.Text = "￥->$" Then
            fromm = "￥"
            tom = "$"
            Label2.Text = "金额 " + fromm
        ElseIf ComboBox1.Text = "$->￥" Then
            fromm = "$"
            tom = "￥"
            Label2.Text = "金额 " + fromm
        End If
    End Sub

    Public Sub RePar()
        If WebBrowser1.Document.Forms.Count = 0 Then
            MessageBox.Show("网管大叔下班了吧，自己说了算好啦")
        End If
        WebBrowser1.Document.GetElementsByTagName("input").GetElementsByName("cal").Item(0).InvokeMember("Click")
        dDtoR = CDbl(WebBrowser1.Document.GetElementById("crncyres").OuterText.ToString.Substring(12).ToString().Remove(6).ToString())
        'TextBox1.Text = dDtoR.ToString()
        If ComboBox1.Text = "￥->$" Then
            fromm = "￥"
            tom = "$"
            dDtoR = CDbl(1 / dDtoR).ToString().Remove(6)
            TextBox1.Text = (dDtoR).ToString()
            Label2.Text = "金额 " + fromm
        ElseIf ComboBox1.Text = "$->￥" Then
            TextBox1.Text = (dDtoR).ToString()
            fromm = "$"
            tom = "￥"
            Label2.Text = "金额 " + fromm
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://www.usd-cny.com/usd-rmb.htm")
        ComboBox1.Text = "$->￥"
    End Sub
End Class
