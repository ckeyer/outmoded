Option Explicit On

Public Class Money
    Public par As Double
    Public naem As String
    Public id As Integer
    Public Const parurl As String = "http://www.usd-cny.com/usd-rmb.htm"

    Public Sub USDtoCNY()

        Dim vDoc, vTag
        Dim i As Integer
        vDoc = Form1.WebBrowser1.Document
        If vDoc Is Nothing Then Exit Sub
        For i = 0 To vDoc.All.length - 1
            If UCase(vDoc.All(i).tagname) = "select" Then
                vTag = vDoc.All(i)
                Select Case vTag.Name
                    Case "from_tkc"
                        vTag.Value = "CNY:CUR"
                End Select
            End If
        Next i
    End Sub
End Class
