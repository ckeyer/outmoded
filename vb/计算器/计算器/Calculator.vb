Public Class Calculator

    Dim movex, movey As Integer   '''''窗口移动的相对鼠标指针位置

    Dim a, b, tmp As Double           '''''计算器的两个主要参数
    Dim aisok As Boolean        '''''a已经准备好了
    Dim havedot As Boolean      '''''已存在点号
    Dim sign As Integer         ''''' 符号位，1234为+-*/ 5用于二次运算判断
    Dim isrun As Boolean


    ''' 程序的初始化
    Private Sub Calculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.init()
    End Sub

    '*** 以下函数为窗口移动的相关函数 ***
    '*** CJ_Studio ***
    Private Sub Calculator_MouseDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'MsgBox(e.Button)
        If e.Button = MouseButtons.Left Then
            movex = Me.Left - MousePosition.X
            movey = Me.Top - MousePosition.Y
            Me.Timer1.Start()
            Me.Timer1.Enabled = True
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Left = MousePosition.X + Me.movex
        Me.Top = MousePosition.Y + Me.movey
    End Sub
    Private Sub Calculator_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        Me.Timer1.Enabled = False
    End Sub
    '''''********************************************************''''''


    '*** 退出函数 ***
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Me.Close()
    End Sub

    '*** CE 相关函数 ***
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Me.init()
    End Sub

    '*** Backspace 相关函数 ***
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        If Not isrun Then
            If TextBox2.Text.Length > 0 Then
                TextBox2.Text = TextBox2.Text.Remove(TextBox2.Text.Length - 1, 1)
            End If
        End If
    End Sub

    '*** 初始化相关函数 ***
    Private Sub init()
        a = 0
        b = 0
        aisok = False
        havedot = False
        sign = 0
        isrun = False
        Me.TextBox1.Text = "Download you all my life."
        Me.TextBox2.Text = ""
    End Sub

    '*** 按键处理相关函数 ***
    Public Sub inputword(ByVal k As Integer)
        Select Case k
            Case 0 To 9
                If sign > 4 Then
                    sign -= 4
                    aisok = True
                    a = tmp
                    TextBox1.Text = a.ToString
                    TextBox2.Text = ""
                    Select Case sign
                        Case 1
                            TextBox1.Text &= " + "
                        Case 2
                            TextBox1.Text &= " - "
                        Case 3
                            TextBox1.Text &= " * "
                        Case 4
                            TextBox1.Text &= " / "
                    End Select
                ElseIf isrun Then
                    init()
                End If
                inputnum(k)
                isrun = False
            Case 10
                If sign > 4 And isrun Then
                    sign -= 4
                    aisok = True
                    a = tmp
                    TextBox1.Text = a.ToString
                    TextBox2.Text = ""
                    Select Case sign
                        Case 1
                            TextBox1.Text &= " + "
                        Case 2
                            TextBox1.Text &= " - "
                        Case 3
                            TextBox1.Text &= " * "
                        Case 4
                            TextBox1.Text &= " / "
                    End Select
                ElseIf isrun Then
                    init()
                End If
                inputdot()
                isrun = False
            Case 11
                If sign > 4 And isrun Then
                    sign -= 4
                    aisok = True
                    a = tmp
                    TextBox1.Text = a.ToString
                    TextBox2.Text = ""
                    Select Case sign
                        Case 1
                            TextBox1.Text &= " + "
                        Case 2
                            TextBox1.Text &= " - "
                        Case 3
                            TextBox1.Text &= " * "
                        Case 4
                            TextBox1.Text &= " / "
                    End Select
                ElseIf isrun Then
                    init()
                End If
                inputminus()
                isrun = False
            Case 12 To 15
                inputsign(k)
            Case 16
                inputenter()
        End Select
    End Sub
    Public Sub inputnum(ByVal k As Integer)
        If TextBox2.Text.Length = 0 Or TextBox2.Text = "0" Then
            TextBox2.Text = k.ToString
        ElseIf TextBox2.Text = "-0" Then
            TextBox2.Text = "-" & k.ToString
        Else
            TextBox2.Text &= k.ToString
        End If
    End Sub
    Public Sub inputdot()
        If Not TextBox2.Text.IndexOf(".") = -1 Then
            havedot = True
        Else
            havedot = False
        End If
        If TextBox2.Text.Length = 0 Then
            TextBox2.Text = "0."
            havedot = True
        ElseIf Not havedot Then
            TextBox2.Text &= "."
            havedot = True
        End If
    End Sub
    Public Sub inputminus()
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.First() = "-" Then
                TextBox2.Text = TextBox2.Text.Remove(0, 1)
            Else
                TextBox2.Text = TextBox2.Text.Insert(0, "-")
            End If
        Else
            TextBox2.Text = "-"
        End If
    End Sub
    Public Sub inputsign(ByVal k As Integer)
        havedot = False
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            If isrun Then
                a = tmp
                aisok = True
                sign = k - 7
                TextBox1.Text = a.ToString
                Select Case sign - 4
                    Case 1
                        TextBox1.Text &= " + "
                    Case 2
                        TextBox1.Text &= " - "
                    Case 3
                        TextBox1.Text &= " * "
                    Case 4
                        TextBox1.Text &= " / "
                End Select
                isrun = False
            ElseIf Not aisok Then
                sign = k - 11
                a = CDbl(TextBox2.Text)
                TextBox1.Text = a.ToString
                Select Case sign
                    Case 1
                        TextBox1.Text &= " + "
                    Case 2
                        TextBox1.Text &= " - "
                    Case 3
                        TextBox1.Text &= " * "
                    Case 4
                        TextBox1.Text &= " / "
                End Select
                aisok = True
                isrun = False
                TextBox2.Text = ""
            Else
                b = CDbl(TextBox2.Text)
                aisok = True
                run()
                sign = k - 7
            End If
        ElseIf aisok Then
            sign = k - 11
            isrun = False
            TextBox1.Text = a.ToString
            Select Case sign
                Case 1
                    TextBox1.Text &= " + "
                Case 2
                    TextBox1.Text &= " - "
                Case 3
                    TextBox1.Text &= " * "
                Case 4
                    TextBox1.Text &= " / "
            End Select
        End If
    End Sub
    Public Sub inputenter()
        havedot = False
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            If Not aisok Then
                a = CDbl(TextBox2.Text)
                TextBox1.Text = a.ToString
                aisok = True
                TextBox2.Text = ""
            Else
                b = CDbl(TextBox2.Text)
                run()
            End If
        End If
    End Sub
    Public Sub run()
        isrun = True
        havedot = False
        Select Case sign
            Case 1
                tmp = a + b
                TextBox1.Text = a.ToString & " + " & b.ToString & " ="
            Case 2
                tmp = a - b
                TextBox1.Text = a.ToString & " - " & b.ToString & " ="
            Case 3
                tmp = a * b
                TextBox1.Text = a.ToString & " * " & b.ToString & " ="
            Case 4
                If b = 0 Then
                    Return
                Else
                    tmp = a / b
                    TextBox1.Text = a.ToString & " / " & b.ToString & " ="
                End If
        End Select
        Dim str As String = tmp.ToString
        If str.Length > 15 Then
            Dim laste = str.LastIndexOf("E")
            If Not laste = -1 Then
                str = str.Remove(15 - str.Length + laste, str.Length - 15)
            Else
                str = str.Remove(15, str.Length - 15)
            End If
        End If
        TextBox2.Text = str
    End Sub





    '*** 以下函数数字按钮或键盘事件相关函数 ***
    '参数k说明:
    '   0~9 为数字0~9 
    '   10 .
    '   11 -/+
    '   12~15 +-*/
    '   16 Enter
    '*** CJ_Studio ***
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        inputword(0)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        inputword(1)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        inputword(2)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        inputword(3)
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        inputword(4)
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        inputword(5)
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        inputword(6)
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        inputword(7)
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        inputword(8)
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        inputword(9)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        inputword(10)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        inputword(11)
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        inputword(12)
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        inputword(13)
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        inputword(14)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        inputword(15)
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        inputword(16)
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown, TextBox1.KeyDown, MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.NumPad0
                inputword(0)
            Case Keys.NumPad1
                inputword(1)
            Case Keys.NumPad2
                inputword(2)
            Case Keys.NumPad3
                inputword(3)
            Case Keys.NumPad4
                inputword(4)
            Case Keys.NumPad5
                inputword(5)
            Case Keys.NumPad6
                inputword(6)
            Case Keys.NumPad7
                inputword(7)
            Case Keys.NumPad8
                inputword(8)
            Case Keys.NumPad9
                inputword(9)
            Case Keys.Decimal
                inputword(10)
            Case Keys.Add
                inputword(12)
            Case Keys.Subtract
                inputword(13)
            Case Keys.Multiply
                inputword(14)
            Case Keys.Divide
                inputword(15)
            Case Keys.Enter
                inputword(16)
            Case Keys.Back
                If Not isrun Then
                    If TextBox2.Text.Length > 0 Then
                        TextBox2.Text = TextBox2.Text.Remove(TextBox2.Text.Length - 1, 1)
                    End If
                End If
        End Select
    End Sub
    '''''********************************************************''''''


    '*** 其他功能函数 ***
    '*** CJ_Studio ***
    ''' n的阶乘
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Then
                TextBox2.Text = TextBox2.Text.Remove(TextBox2.Text.Length - 1, 1)
            ElseIf TextBox2.Text.First = "-" Then
                TextBox2.Text = TextBox2.Text.Remove(0, 1)
            Else
                a = CInt(TextBox2.Text)
                If a > 100 Then
                    MsgBox("本计算器暂不支持100以上的阶乘")
                    Return
                ElseIf Not a = 0 Then
                    TextBox1.Text = a.ToString & "! = "
                    Dim i As Integer
                    tmp = 1
                    For i = 1 To a
                        tmp *= i
                    Next
                    Dim str As String = tmp.ToString
                    If str.Length > 15 Then
                        Dim laste = str.LastIndexOf("E")
                        str = str.Remove(15 - str.Length + laste, str.Length - 15)
                    End If
                    TextBox2.Text = str
                End If
            End If
        End If
    End Sub

    ''' 1/x
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            a = CDbl(TextBox2.Text)
            If a = 0 Then
                MsgBox("分母不能为0")
                Return
            End If
            tmp = 1 / a
            TextBox1.Text = "1 / " & a.ToString & " = "
            TextBox2.Text = tmp.ToString
        End If
    End Sub

    ''' n%
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            a = CDbl(TextBox2.Text)
            tmp = a / 100
            TextBox1.Text = a.ToString & "% = "
            TextBox2.Text = tmp.ToString
        End If
    End Sub

    ''' 开方
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            a = CDbl(TextBox2.Text)
            If a <= 0 Then
                MsgBox("不能开平方一个负数")
                Return
            End If
            tmp = Math.Sqrt(a)
            TextBox1.Text = "√" & a.ToString & " = "
            TextBox2.Text = tmp.ToString
        End If
    End Sub

    ''' 平方
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If TextBox2.Text.Length > 0 Then
            If TextBox2.Text.Last = "." Or TextBox2.Text = "-" Then
                TextBox2.Text &= "0"
            End If
            a = CDbl(TextBox2.Text)
            tmp = Math.Pow(a, 2)
            TextBox1.Text = a.ToString & "² = "
            Dim str As String = tmp.ToString
            If str.Length > 15 Then
                Dim laste = str.LastIndexOf("E")
                If Not laste = -1 Then
                    str = str.Remove(15 - str.Length + laste, str.Length - 15)
                Else
                    str = str.Remove(15, str.Length - 15)
                End If
            End If
            TextBox2.Text = str
        End If
    End Sub
End Class