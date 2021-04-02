Imports System.Threading

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
        Timer2.Start()
    End Sub

    Private ReadOnly Stpw As New Stopwatch
    Private CountDown As TimeSpan = TimeSpan.FromSeconds(5.0#)

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Stpw.Elapsed >= CountDown Then

            Dim myBmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Dim g As Graphics = Graphics.FromImage(myBmp)
            g.CopyFromScreen(Point.Empty, Point.Empty, myBmp.Size)
            g.Dispose()
            iBaseTools.Bombcolor = myBmp.GetPixel(MousePosition.X, MousePosition.Y)
            myBmp.Dispose()
            Stpw.Stop()
            iBaseTools.Bombcoordinatesx = Cursor.Position.X

            iBaseTools.Bombcoordinatesy = Cursor.Position.Y

            If iBaseTools.Valorant = True Then
                Form4.Show()
                iBaseTools.Bombtimer = True
            Else
                Form3.Show()
                iBaseTools.Bombtimer2 = True
            End If

            iBaseTools.Bombfinder = False
            iBaseTools.Setbomb = True

            Me.Close()
            Try
                iBaseTools.myTimer.Change(0, iBaseTools.Delay)
                iBaseTools.Canvas.Show()
            Catch
            End Try
        Else
            Dim ToGo As TimeSpan = CountDown - Stpw.Elapsed
            Label1.Text = "Scanning Coordinates in: " & ToGo.ToString("ss\,f") & " Seconds"

            Select Case ToGo.TotalSeconds

            End Select
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
        Timer1.Enabled = True
        Timer1.Start()
        Stpw.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label2.Text = "Coordinates: X." & Cursor.Position.X & " - Y." & Cursor.Position.Y
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Me.TopMost = False
        Me.SendToBack()
    End Sub


    Private Sub CheckBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles CheckBox1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub CheckBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, iBaseTools.Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

End Class