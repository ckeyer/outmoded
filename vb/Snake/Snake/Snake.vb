Public Class Snake
    Public stp As Integer = 10
    Public dr As Point          'net 的范围
    Public len As Integer = 0
    Public bodys() As Body
    Dim oldbodys() As Body
    Dim ori As Integer = 4
    Dim oldori As Integer = 4

    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()
        With Me
            .stp = Form1.stp
            .dr.X = Form1.column
            .dr.Y = Form1.line
            .Top = 5
            .Left = 5
            .len = 0
            .Width = .dr.X * stp
            .Height = .dr.Y * stp
            .Enabled = True
            .Visible = True
        End With
        Dim p As Point
        p = New Point(dr.X / 2, dr.Y / 2)
        addbody(p)
        'p = New Point((dr.X + 1) / 2, dr.Y / 2)
        'Dim q As Feed
        'q = New Feed(p)
        'eat(q)
    End Sub


    Sub addbody(ByVal p As Point)
        Form1.insnet(p, 1)
        Dim i As Integer
        ReDim bodys(1)
        Me.len = bodys.Length
        bodys(0) = New Body(stp, p)
        With bodys(0)
            .PictureBox1.Image = .ImageList1.Images(5)
            .Enabled = True
            .Visible = True
            .Show()
        End With
        p.X = p.X - 1
        Form1.insnet(p, 1)
        bodys(1) = New Body(stp, p)
        With bodys(1)
            .PictureBox1.Image = .ImageList1.Images(3)
            .Enabled = True
            .Visible = True
            .Show()
        End With
        ReDim oldbodys(1)
        For i = 0 To Me.len - 1
            oldbodys(i) = bodys(i)
            Me.Controls.Add(oldbodys(i))
        Next
    End Sub

    Sub eat(ByVal feed As Feed)
        Form1.insnet(feed.getfeed, 1)
        Dim tmp As Body
        tmp = New Body(feed.getfeed)
        feed.Dispose()
        Dim i, j As Integer
        ReDim bodys(Me.len)
        For i = 1 To Me.len
            j = Me.len - i + 1
            bodys(j) = oldbodys(j - 1)
        Next
        bodys(1).PictureBox1.Image = bodys(1).ImageList1.Images(3)
        With tmp
            .PictureBox1.Image = .ImageList1.Images(5)
            .Enabled = True
            .Visible = True
            .Show()
        End With
        bodys(0) = tmp
        ReDim oldbodys(Me.len)
        For i = 0 To Me.len
            oldbodys(i) = bodys(i)
            Me.Controls.Add(oldbodys(i))
        Next
        Me.len = oldbodys.Length
        Dim feedtmp As Feed
        feedtmp = New Feed()
        Me.Controls.Add(feedtmp)
    End Sub

    'Function moveup() As Boolean
    '    Dim nxt As Point = bodys(0).getnext(1)
    '    If (bodys(0).getbody.Y <= 0 And Form1.getnet(bodys(0).getbody.X, (dr.Y - 1)) = 1) Then
    '        Me.Timersnake.Enabled = False
    '        moveup = False
    '        Exit Function
    '    ElseIf (bodys(0).getbody.Y <= 0 And Form1.getnet(bodys(0).getbody.X, (dr.Y - 1)) = 0) Then
    '        Dim i, j As Integer
    '        For i = 1 To Me.len - 1
    '            j = Me.len - i
    '            bodys(j).moveto(bodys(j - 1).getbody)
    '        Next
    '        If (bodys(0).getbody.Y <= 0) Then
    '            bodys(0).Top = (dr.Y - 1) * stp
    '        Else
    '            bodys(0).move(1)
    '        End If
    '        moveup = True
    '        Exit Function
    '    ElseIf (bodys(0).getbody.Y <= 0 And Form1.getnet(bodys(0).getbody.X, (dr.Y - 1)) = 2) Then
    '        Dim p As Point
    '        With p
    '            .X = bodys(0).getbody.X
    '            .Y = (dr.Y - 1)
    '        End With
    '        Me.eat(p)
    '        moveup = True
    '        Exit Function
    '    ElseIf (Form1.getnet(bodys(0).getbody.X, bodys(0).getbody.Y - 1) = 2) Then
    '        Dim p As Point
    '        With p
    '            .X = bodys(0).getbody.X
    '            .Y = bodys(0).getbody.Y - 1
    '        End With
    '        Me.eat(p)
    '        moveup = True
    '        Exit Function
    '    End If
    '    moveup = False
    'End Function

    'Function movedown() As Boolean
    '    Dim nxt As Point = bodys(0).getnext(2)
    '    Dim i, j As Integer
    '    If (Form1.getnet(nxt) = 1) Then
    '        movedown = False
    '        Exit Function
    '    ElseIf (Form1.getnet(nxt) = 2) Then
    '        Me.eat(nxt)
    '    Else
    '        For i = 1 To Me.len - 1
    '            j = Me.len - i
    '            bodys(j).moveto(bodys(j - 1).getbody)
    '        Next
    '        If (bodys(0).getbody.Y >= dr.Y - 1) Then
    '            bodys(0).Top = 0
    '        Else
    '            bodys(0).move(2)
    '        End If
    '    End If
    '    movedown = True
    'End Function

    'Sub moveleft()
    '    Dim nxt As Point = bodys(0).getnext(3)
    '    Dim i, j As Integer
    '    For i = 1 To Me.len - 1
    '        j = Me.len - i
    '        bodys(j).moveto(bodys(j - 1).getbody)
    '    Next
    '    If (bodys(0).getbody.X <= 0) Then
    '        bodys(0).Left = (dr.X - 1) * stp
    '    Else
    '        bodys(0).move(3)
    '    End If
    'End Sub

    'Sub moveright()
    '    Dim nxt As Point = bodys(0).getnext(4)

    '    Dim i, j As Integer
    '    For i = 1 To Me.len - 1
    '        j = Me.len - i
    '        bodys(j).moveto(bodys(j - 1).getbody)
    '    Next
    '    If (bodys(0).getbody.X >= dr.X - 1) Then
    '        bodys(0).Left = 0
    '    Else
    '        bodys(0).move(4)
    '    End If
    'End Sub

    Function moving() As Boolean
        len = bodys.Length
        Dim nxt As Point = New Point()
        nxt = bodys(0).getnext(ori)
        Dim i, j As Integer
        If (Form1.getnet(nxt) = 1) Then
            moving = False
            Exit Function
        ElseIf (Form1.getnet(nxt) = 2) Then
            For i = 0 To Me.Controls.Count - 1
                If (Me.Controls(i).GetHashCode = nxt.X * 100 + nxt.Y) Then
                    Exit For
                End If
            Next
            Me.eat(Me.Controls(i))
        Else
            For i = 1 To Me.len - 1
                j = Me.len - i
                bodys(j).moveto(bodys(j - 1).getbody)
            Next
            If (bodys(0).getbody.Y >= dr.Y - 1) Then
                bodys(0).Top = 0
            Else
                bodys(0).move(ori)
            End If
        End If
        moving = True
    End Function

    Private Sub Timersnake_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timersnake.Tick
        'Me.moveright()
        'Me.moveleft()
        'Me.moveup()
        'Me.movedown()
        If (moving() = False) Then
            Me.Timersnake.Enabled = False
            MsgBox("GAME OVER!!!")
            Form1.Butstart.Text = "开始"
        End If
    End Sub

    Public Sub setori(ByVal ori As Integer)
        If (ori + oldori = 7 Or ori + oldori = 3) Then
            ori = oldori
        Else
            oldori = ori
        End If
    End Sub

    Private Sub Snake_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                Me.setori(1)
                MsgBox("ms002:dsfgsdfds")
            Case Keys.Down
                Me.setori(2)
            Case Keys.Left
                Me.setori(3)
            Case Keys.Right
                Me.setori(4)
        End Select
    End Sub
End Class
