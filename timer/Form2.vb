Imports System.IO

Public Class Form2

    Private Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Label2.Text = "Resize and Move me until I fit onto your Minimap.

Then Click on Me (this label).

Make sure you have following Minimap Settings:
Rotate = Fixed
Keep Player Centered = Off
"
        iBaseTools.Valorant = True
        Button2.Hide()
        Button3.Hide()
        Button1.Hide()
        Button4.Hide()
        Label1.Hide()
        PictureBox2.Hide()
        PictureBox3.Hide()
        Label2.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Hide()
        Button2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        iBaseTools.Valorant = False
        Button1.Hide()
        Button4.Hide()
        Button2.Hide()
        Button3.Hide()
        Label1.Hide()
        PictureBox2.Hide()
        PictureBox3.Hide()
        Label2.Show()

    End Sub

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        iBaseTools.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        iBaseTools.Form2width = Me.Width
        iBaseTools.Form2Height = Me.Height
        iBaseTools.Form2Location = Me.Location
        iBaseTools.Form2Size = Me.Size
        iBaseTools.Form2Left = Me.Left
        iBaseTools.Form2Top = Me.Top

        If iBaseTools.Valorant Then
            Me.Close()
            Form4.Show()
        Else
            Me.Close()
            Form3.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Settings.txt") Then

            iBaseTools.Form2width = My.Settings.Width1
            iBaseTools.Form2Height = My.Settings.Height1
            iBaseTools.Form2Location = My.Settings.Location1
            iBaseTools.Form2Size = My.Settings.Size1
            iBaseTools.Form2Left = My.Settings.Left1
            iBaseTools.Form2Top = My.Settings.Top1
            iBaseTools.Valorant = My.Settings.Valorant1
            iBaseTools.Fadeint = My.Settings.Fadeint1
            iBaseTools.Markersize = My.Settings.Markersize1
            iBaseTools.Variation = My.Settings.Variation1
            iBaseTools.Fadetime = My.Settings.Fadetime1
            iBaseTools.Delay = My.Settings.Delay1
            iBaseTools.Pixelcolor = My.Settings.Pixelcolor1
            iBaseTools.Alarmsound = My.Settings.Alarmsound1
            iBaseTools.Maptracker = My.Settings.Maptracker1
            iBaseTools.Bombtimer = My.Settings.Bombtimer1
            iBaseTools.Bombcoordinatesx = My.Settings.Bombcoordinatesx1
            iBaseTools.Bombcoordinatesy = My.Settings.Bombcoordinatesy1

            iBaseTools.Saveme = False
            iBaseTools.Setbomb = True

            Me.Close()
            iBaseTools.Show()
            iBaseTools.Execute()
            Return
        Else
            MessageBox.Show("No Saved Settings Yet!")
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Settings2.txt") Then

            iBaseTools.Form2width = My.Settings.Width2
            iBaseTools.Form2Height = My.Settings.Height2
            iBaseTools.Form2Location = My.Settings.Location2
            iBaseTools.Form2Size = My.Settings.Size2
            iBaseTools.Form2Left = My.Settings.Left2
            iBaseTools.Form2Top = My.Settings.Top2
            iBaseTools.Valorant = My.Settings.Valorant2
            iBaseTools.Fadeint = My.Settings.Fadeint2
            iBaseTools.Markersize = My.Settings.Markersize2
            iBaseTools.Variation = My.Settings.Variation2
            iBaseTools.Fadetime = My.Settings.Fadetime2
            iBaseTools.Delay = My.Settings.Delay2
            iBaseTools.Pixelcolor = My.Settings.Pixelcolor2
            iBaseTools.Alarmsound = My.Settings.Alarmsound2
            iBaseTools.Maptracker = My.Settings.Maptracker2
            iBaseTools.Alarm = My.Settings.Alarm2
            iBaseTools.Multitarget = My.Settings.Multitarget2
            iBaseTools.Maptracker = My.Settings.Maptracker2
            iBaseTools.Bombtimer2 = My.Settings.Bombtimer2
            iBaseTools.Bombdefusetimes = My.Settings.Bomdefusetime
            iBaseTools.Bombexplodetime = My.Settings.Bombexplodetime
            iBaseTools.Saveme = False
            iBaseTools.Saveme2 = True

            Me.Close()
            iBaseTools.Show()
            iBaseTools.Execute()
            Return
        Else
            MessageBox.Show("No Saved Settings Yet!")
        End If
    End Sub


End Class