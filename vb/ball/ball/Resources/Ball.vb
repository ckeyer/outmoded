Public Class Ball
    Public xSpeed, ySpeed, v As Double
    Public x, y As Double
    Public xMax, yMax As Double
    Public r As Double
    Dim chaged() As Boolean
    Dim friends() As Ball
    Dim friCount As Integer

    Sub New()
        friCount = 0
    End Sub

    Sub setSpeed(ByVal px As Double, ByVal py As Double)
        Me.xSpeed = px
        Me.ySpeed = py
        Me.v = Math.Sqrt(Me.xSpeed * Me.xSpeed + Me.ySpeed * Me.ySpeed)
    End Sub

    Sub setSite(ByVal px As Double, ByVal py As Double)
        Me.x = px
        Me.y = py
    End Sub

    Sub setBall(ByVal px As Double, ByVal py As Double, ByVal pr As Double)
        Me.x = px
        Me.y = py
        Me.r = pr
    End Sub

    Sub setRange(ByVal px As Double, ByVal py As Double)
        Me.xMax = px
        Me.yMax = py
    End Sub

    Sub addFriend(ByVal b As Ball)
        friCount += 1
        ReDim Preserve Me.friends(friCount - 1)
        ReDim Preserve Me.chaged(friCount - 1)
        Me.friends(friCount - 1) = b
        If friCount > 1 Then
            Dim i As Integer
            For i = 0 To friCount - 2
                Me.friends(i).addFriend(b)
            Next
        End If
    End Sub

    Sub isCrash()
        If Me.x + Me.xSpeed > Me.xMax Or Me.x + Me.xSpeed - Me.r < 0 Then
            Me.xSpeed *= -1
        End If
        If Me.y + Me.ySpeed > Me.yMax Or Me.y + Me.ySpeed - Me.r < 0 Then
            Me.ySpeed *= -1
        End If
        If Me.friCount > 0 Then
            Dim i As Integer
            For i = 0 To friCount - 1
                Dim xL, yL As Double
                Dim L As Double
                xL = Math.Abs(Me.x - friends(i).x)
                yL = Math.Abs(Me.y - friends(i).y)
                L = Math.Sqrt(xL * xL + yL * yL)
                If Not chaged(i) And L <= Me.r + friends(i).r Then 'And (L > Me.r - Me.xSpeed + friends(i).r - friends(i).xSpeed Or L > Me.r - Me.ySpeed + friends(i).r - friends(i).ySpeed) Then
                    chaged(i) = True
                    Dim cosa, sina As Double
                    cosa = xL / L
                    sina = yL / L
                    Dim vax, vay, vbx, vby As Double
                    Dim va, vb As Double
                    'va = (friends(i).xSpeed * cosa - friends(i).ySpeed * sina)
                    'vb = (Me.ySpeed * cosa + Me.xSpeed * sina)
                    'vax = va * cosa + vb * sina
                    'vay = va * sina - vb * cosa
                    va = Me.xSpeed * sina - Me.ySpeed * cosa
                    vb = friends(i).xSpeed * cosa + friends(i).ySpeed * sina
                    vax = va * sina + vb * cosa
                    vay = va * cosa - vb * sina

                    va = friends(i).xSpeed * sina - friends(i).ySpeed * cosa
                    vb = Me.xSpeed * cosa + Me.ySpeed * sina
                    vbx = va * sina + vb * cosa
                    vby = va * cosa - vb * sina
                    'va = (Me.ySpeed * sina - Me.xSpeed * cosa)
                    'vb = (friends(i).xSpeed * sina + friends(i).ySpeed * cosa)
                    'vbx = va * cosa + vb * sina
                    'vby = va * sina = vb * cosa
                    'vay = (friends(i).xSpeed * cosa + friends(i).ySpeed * sina) * sina + (Me.ySpeed * cosa + Me.xSpeed * sina) * cosa
                    'vbx = (Me.ySpeed * sina - Me.xSpeed * cosa) * cosa + (friends(i).xSpeed * sina + friends(i).ySpeed * cosa) * sina
                    'vby = (Me.ySpeed * sina + Me.xSpeed * cosa) * sina - (friends(i).xSpeed * sina + friends(i).ySpeed * cosa) * cosa
                    Me.xSpeed = vax
                    Me.ySpeed = vay
                    friends(i).xSpeed = vbx
                    friends(i).ySpeed = vby
                ElseIf chaged(i) And L <= Me.r + friends(i).r Then
                    chaged(i) = True
                Else
                    chaged(i) = False

                End If

            Next
        End If
    End Sub

    Sub move()
        Me.isCrash()
        Me.x += Me.xSpeed
        Me.y += Me.ySpeed
        If friCount > 0 Then
            Dim i As Integer
            For i = 0 To friCount - 1
                Me.friends(i).move()
            Next
        End If
    End Sub
End Class
