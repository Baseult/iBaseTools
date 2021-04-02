Imports System.IO
Imports System.Threading

Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Settings.txt") Then
            fadeint = 50
            pixelcolor = Color.FromArgb(200, 255, 255, 0)
            fadetime = 1
            Variation = 15
            Delay = 500
            markersize = 10
            maptracker = True
        Else

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

                fadeint = My.Settings.Fadeint1
                markersize = My.Settings.Markersize1
                Variation = My.Settings.Variation1
                fadetime = My.Settings.Fadetime1
                Delay = My.Settings.Delay1
                pixelcolor = My.Settings.Pixelcolor1

            TrackBar5.Value = My.Settings.Markersize1
            TrackBar2.Value = My.Settings.Variation1

            TrackBar4.Value = My.Settings.Fadetime1
                TrackBar3.Value = My.Settings.Delay1

                If My.Settings.Bombtimer1 Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If

                If My.Settings.Maptracker1 Then
                    CheckBox3.Checked = True
                Else
                    CheckBox3.Checked = False
                End If

                If My.Settings.Fadeint1 = 100 Then
                    CheckBox1.Checked = False
                Else
                    CheckBox1.Checked = True
                End If

                If My.Settings.Alarmsound1 Then
                    CheckBox4.Checked = True
                Else
                    CheckBox4.Checked = False
                End If


            maptracker = My.Settings.Maptracker1

        End If

        Label6.Text = "Marker Size: " & TrackBar5.Value
        Label2.Text = "Variation: " & TrackBar2.Value
        Label5.Text = "Fade Time: " & TrackBar4.Value
        Label3.Text = "Search every X milliseconds for Target: " & TrackBar3.Value

        Control.CheckForIllegalCrossThreadCalls = False 'Please dont kill me for that..

        Dim myCallback As New System.Threading.TimerCallback(AddressOf FindPixels)
        Dim myCallback2 As New System.Threading.TimerCallback(AddressOf Removecolor)

        myTimer = New System.Threading.Timer(myCallback, Nothing, 0, TrackBar3.Value)
        myTimer2 = New System.Threading.Timer(myCallback2, Nothing, Timeout.Infinite, Timeout.Infinite)


    End Sub


    Private call1
    Private call2

    Private myTimer As System.Threading.Timer
    Private myTimer2 As System.Threading.Timer

    Private ReadOnly pixels As New List(Of PixelInfo)
    Dim pixelcolor As Color
    Dim fadeint As Integer
    Dim fadetime As Integer
    Dim Variation As Integer
    Dim Delay As Integer
    Dim markersize As Integer
    Dim maptracker As Boolean
    Dim markersizex As Integer
    Dim markersizey As Integer

    ReadOnly xd3 As Color = Color.FromArgb(255, 231, 90, 60)

    Private Shared Function Color_Is_In_The_Target_Variations(variation As Integer, tested As Color, target As Color) As Boolean

        If tested.R >= target.R - variation And tested.R <= target.R + variation And
           tested.G >= target.G - variation And tested.G <= target.G + variation And
           tested.B >= target.B - variation And tested.B <= target.B + variation Then

            Return True
        Else
            Return False

        End If

    End Function

    Private Sub FindPixels(ByVal myLabel As Label)

        If maptracker Then

            Using by As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using gy As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(by)
                    Try
                        gy.CopyFromScreen(Me.Left, Me.Top, 0, 0, by.Size)
                    Catch
                    End Try

                    For i = 0 To (by.Width - 1)
                        For j = 0 To (by.Height - 1)

                            If Color_Is_In_The_Target_Variations(Variation, by.GetPixel(i, j), xd3) Then
                                Try
                                    pixels.Add(New PixelInfo With {.Location = New Point(i - (markersizex / 2), j - (markersizey / 2)),
                                                                   .CreatedTime = Date.Now,
                                                                   .Colour = pixelcolor})

                                    'Repaint the drawing surface.
                                    PictureBox1.Invalidate()

                                    Dim v = myTimer2.Change(0, 250)

                                Catch

                                    GoTo Nexx
                                End Try
                            End If
                        Next
                    Next
Nexx:
                End Using

            End Using
        End If
    End Sub

    Private Sub Removecolor()
        Try

            Dim currentTime = Date.Now

            'Start fading a pixel after 1 second.
            Dim nonFadePeriod = TimeSpan.FromSeconds(fadetime)

            For i = pixels.Count - 1 To 0 Step -1
                Dim pixel = pixels(i)

                If currentTime - pixel.CreatedTime > nonFadePeriod Then
                    'Increase the transparency of the pixel.
                    Dim pixelAlpha = pixel.Colour.A - fadeint

                    If pixelAlpha <= 0 Then
                        'Remove fully transparent pixels.
                        pixels.RemoveAt(i)
                    Else
                        pixel.Colour = Color.FromArgb(pixelAlpha, &HFF, 0, 0)
                    End If
                End If
            Next

            'Repaint the drawing surface.
            PictureBox1.Invalidate()

            If pixels.Count = 0 Then
                myTimer2.Change(Timeout.Infinite, Timeout.Infinite)
            End If
        Catch
        End Try

    End Sub



    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Label2.Text = "Color Variation: " & TrackBar2.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        Variation = TrackBar2.Value
        iBaseTools.Variation = TrackBar2.Value
    End Sub

    Private Sub TrackBar3_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar3.ValueChanged
        If TrackBar3.Value <= 200 And TrackBar3.Value >= 51 And iBaseTools.Warning = False Then
            If Shown Then
                iBaseTools.Warning = True
                MessageBox.Show("Changing this Value below 200 will increase the CPU Usage and might slow down the Program or even your game. If you experience lags or a bad performance, then increase this Value!")
            End If
        End If
        If TrackBar3.Value <= 50 And iBaseTools.Warning2 = False Then
            If Shown Then
                iBaseTools.Warning2 = True
                MessageBox.Show("Are you sure about that? Using a Value below 50 milliseconds is extreme and will definitely increase your CPU a lot." & vbCrLf & vbCrLf & "It will cause the program to lag and hang on low performance computers. Don't go below 50 on a bad computer.")
            End If
        End If

        If Shown Then
            myTimer.Change(0, TrackBar3.Value)
        End If

        If TrackBar3.Value <= 200 And TrackBar3.Value >= 51 Then
            Label3.ForeColor = Color.DarkOrange
        ElseIf TrackBar3.Value <= 50 Then
            Label3.ForeColor = Color.Red
        Else
            Label3.ForeColor = Color.Black
        End If

        Label3.Text = "Check Interval - Milliseconds: " & TrackBar3.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        Delay = TrackBar3.Value
        iBaseTools.Delay = TrackBar3.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cDialog As New ColorDialog()


            If (cDialog.ShowDialog() = DialogResult.OK) Then
                pixelcolor = cDialog.Color ' update with user selected color.
                iBaseTools.Pixelcolor = cDialog.Color
            End If
        End Using

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        'Draw a pixel as a 3x3 square.

        markersizex = markersize
        markersizey = markersize

        Dim pixelSize As New Size(markersizex, markersizey)
        Try
            For Each pixel In pixels
                'Draw the pixel in its own colour.
                Using brush As New SolidBrush(pixel.Colour)
                    'Draw the pixel at its own location.
                    e.Graphics.FillRectangle(brush, New Rectangle(pixel.Location, pixelSize))
                End Using
            Next
        Catch
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            fadeint = 50
            iBaseTools.Fadeint = 50
        Else
            fadeint = 100
            iBaseTools.Fadeint = 100
        End If
    End Sub

    Private Sub TrackBar4_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar4.ValueChanged
        fadetime = TrackBar4.Value
        iBaseTools.Fadetime = TrackBar4.Value
        Label5.Text = "Fade Time: " & TrackBar4.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
    End Sub

    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles TrackBar5.Scroll
        markersize = TrackBar5.Value
        iBaseTools.Markersize = TrackBar5.Value
        Label6.Text = "Marker Size: " & TrackBar5.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("This will change the Size of the Markers shown on the Minimap once the Target (Enemy) has been found")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Use a Value between 1 and 5 - (Default = 1)" & vbCrLf & vbCrLf & "Read the text and you will probably improve the detection a lot!" & vbCrLf & vbCrLf & "Precision - Instructions:" & vbCrLf & "I will take League of Legends as the example-game here but it works for all other games with Minimap too. Let's say you want to track and mark the Enemy Jungler on your Minimap. Now, how could a simple 'Pixelscan' Program like this find the Icon of your Enemy Jungle on your Minimap? Well it is easier than you think. You probably know what a Color Picker is right? It is for example in the Windows Program 'Paint' or 'Photoshop'. If you don't know which color a Pixel of the Image has you can use a Color Picker to get that RGB Color Information. We do the same thing in the game. First, this Program will Open Up a Colorpicker. Once your Enemys Icon is visible on your Minimap you have to select a Pixel/Color of your Enemys Jungles Icon with the Color Picker. This program saves this colorinformation and now searches continuously for exactly this color pixel on your minimap. If it finds this color pixel it will mark it on your Minimap with a Color and an alarm will sound. Sadly it would be to easy to use just 'one' Pixel because the color you choose won't be only in the Icon of your Enemys Jungle but maybe also on some Trees or in a River or a Path or something else. So we add a Second or a Third or a Fourth or even a Fifth Pixel to the detection that is near to the first Pixel. If all 5 Pixels that you Colorpicked have the Same Color as the Icon on the Map it will mark the Icon. So You can choose between 1 and 5 for either 1, 2, 3, 4, or 5 scanned Pixel. Using More Pixels (5) Will be more precise (less false detections) but also will probably be slower and less detect the Enemy Jungle since all 5 Pixels aren't always Visible if the Enemy Jungler is near to for example your Top Player both Icons will overlap and the Icon of the Enemy Jungler might only be visible for 1/4. If you want to be safe choose a Number between 2 and 3.")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show("Enter a value between 0 and 35 - (Default = 5)" & vbCrLf & vbCrLf & "Read the text and you will probably improve the detection a lot!" & vbCrLf & vbCrLf & "Color Variation - Instructions:" & vbCrLf & "This Program searches for Pixels with the Same Color as the Icon of your Enemy at your Minimap has. If a Pixel has the same Color as the Enemy Icons Color it will mark this one in a Color. The issue is that Riot did some prevention against that. The Enemy color wont be the same everytime. Yes even if you dont see it the color in the icons slightly changes a bit from for example 'Red=100' 'Green=100' 'Blue=100' to 'Red=110' 'Green=105' 'Blue=90'. As you can see the Color changed and the Program wouldn't be able to detect the Color anymore. That's why I added Colorvariation. If you use for example the Value '10' It will search the Enemys Color but with a variation of 10 points + and - . That means instead of only searching the Color 'Red=100' 'Green=100' 'Blue=100' It will also search all other colors from 'Red=90' 'Green=90' 'Blue=90' to 'Red=110' 'Green=110' 'Blue=110'. Thats great right, but be careful. Higher numbers means it could also pick up other colors at the Minimap that you don't want to search so better don't use higher Numbers than 20.")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("After X Seconds the Marker Color will turn red so you know that the Marker is 'older' than the new color that you can pick above as Marker Color. You can change the time how much time it will need to change from the Original Color to the Fade Color")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MessageBox.Show("You can change the refresh rate of the Program searching for the Target. Lower Values needs more CPU. Higher Values needs less CPU.")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        myTimer.Change(Timeout.Infinite, Timeout.Infinite)
        myTimer2.Change(Timeout.Infinite, Timeout.Infinite)

        iBaseTools.Saveme = True

        If CheckBox2.Checked = True Or CheckBox4.Checked = True Then
            If iBaseTools.Setbomb = False Then
                MessageBox.Show("Please locate the Bomb Position first. Click on 'Set Bomb Position'.")
                Return
            End If
        End If

        If CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False Then
            MessageBox.Show("You just disabled all features of this Program. You disbaled the Bomb Countdown, the Alarmsound and the Map Tracking so there are no features left. If you don't want to use any of these features why are you using this program then?" & vbCrLf & vbCrLf & "Please choose at least 1 Feature to use this Program!")
            Return
        End If

        MessageBox.Show("The Program is Tracking your Minimap right now. The Window will be transparent so don't wonder if you can't see any program on your Screen.")

        iBaseTools.Show()
        iBaseTools.Execute()

        If CheckBox1.Checked Then
            iBaseTools.Fadeint = 50
        Else
            iBaseTools.Fadeint = 100
        End If

        iBaseTools.Markersize = TrackBar5.Value
        iBaseTools.Variation = TrackBar2.Value
        iBaseTools.Fadetime = TrackBar4.Value
        iBaseTools.Delay = TrackBar3.Value

        iBaseTools.Valorant = True

        Me.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        iBaseTools.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = False Then
            iBaseTools.Alarmsound = False
        Else
            iBaseTools.Alarmsound = True
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = False Then
            maptracker = False
            iBaseTools.Maptracker = False
            Try
                iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            Catch
            End Try
        Else

            maptracker = True
            iBaseTools.Maptracker = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            iBaseTools.Bombtimer = False
        Else
            iBaseTools.Bombtimer = True
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        myTimer.Change(Timeout.Infinite, Timeout.Infinite)
        myTimer2.Change(Timeout.Infinite, Timeout.Infinite)

        My.Settings.Fadeint1 = fadeint
        My.Settings.Markersize1 = markersize
        My.Settings.Variation1 = Variation
        My.Settings.Fadetime1 = fadetime
        My.Settings.Delay1 = Delay
        My.Settings.Pixelcolor1 = pixelcolor
        My.Settings.Maptracker1 = maptracker
        My.Settings.Saved = "exist"
        My.Settings.Alarmsound1 = iBaseTools.Alarmsound
        My.Settings.Bombtimer1 = iBaseTools.Bombtimer
        My.Settings.Save()

        iBaseTools.Bombfinder = True

        Me.Close()
        Form5.Show()
        iBaseTools.Show()
        iBaseTools.Execute()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        My.Settings.Fadeint1 = fadeint
        My.Settings.Markersize1 = markersize
        My.Settings.Variation1 = Variation
        My.Settings.Fadetime1 = fadetime
        My.Settings.Delay1 = Delay
        My.Settings.Pixelcolor1 = pixelcolor
        My.Settings.Maptracker1 = maptracker
        My.Settings.Saved = "exist"
        My.Settings.Alarmsound1 = iBaseTools.Alarmsound
        My.Settings.Bombtimer1 = iBaseTools.Bombtimer
        My.Settings.Bombcoordinatesx1 = iBaseTools.Bombcoordinatesx
        My.Settings.Bombcoordinatesy1 = iBaseTools.Bombcoordinatesy
        My.Settings.Save()
    End Sub

    Dim Shown = False

    Private Sub Form4_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Bomb.Close()
        Shown = True
    End Sub

    Private Sub TrackBar3_DragOver(sender As Object, e As DragEventArgs)

    End Sub

    Private Sub TrackBar3_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MessageBox.Show("This is the Map Tracking which you can see on the left gif animation and on your ingame Minimap Overlay. If disabled it won't mark the enemys anymore.")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MessageBox.Show("After a few Seconds the Markers on the Minimap will disappear slowly. If you want them to instantly Hide disable / uncheck this Checkbox.")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MessageBox.Show("This is the Bomb countdown. You will see how much time is left to defuse the Bomb and how much time is left until the Bomb explodes.")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        MessageBox.Show("This is the Alarmsound that you will hear in the last 4 Seconds before you can not defuse the Bomb anymore. It will beep 4 times from 10 to 7 Seconds left before the Bomb explodes. If it beeps the 4. time there won't be time left to defuse the Bomb." & vbCrLf & "If you start defusing the Bomb at the 4. beep and have the right timing you will either have luck and get a 0.01 Second Defuse or you get unlucky and dont have time left to defuse the Bomb.")
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Try
            myTimer.Change(0, TrackBar3.Value)
        Catch

        End Try
    End Sub

    Private Sub Button10_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBar5.MouseDown, TrackBar4.MouseDown, TrackBar3.MouseDown, TrackBar2.MouseDown, MyBase.MouseDown, CheckBox4.MouseDown, CheckBox3.MouseDown, CheckBox2.MouseDown, CheckBox1.MouseDown, Button9.MouseDown, Button8.MouseDown, Button7.MouseDown, Button6.MouseDown, Button5.MouseDown, Button4.MouseDown, Button3.MouseDown, Button2.MouseDown, Button18.MouseDown, Button12.MouseDown, Button11.MouseDown, Button10.MouseDown, Button1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub Button10_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar5.MouseUp, TrackBar4.MouseUp, TrackBar3.MouseUp, TrackBar2.MouseUp, MyBase.MouseUp, CheckBox4.MouseUp, CheckBox3.MouseUp, CheckBox2.MouseUp, CheckBox1.MouseUp, Button9.MouseUp, Button8.MouseUp, Button7.MouseUp, Button6.MouseUp, Button5.MouseUp, Button4.MouseUp, Button3.MouseUp, Button2.MouseUp, Button18.MouseUp, Button12.MouseUp, Button11.MouseUp, Button10.MouseUp, Button1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub
End Class