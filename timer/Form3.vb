Imports System.IO
Imports System.Threading

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Settings2.txt") Then
            audiolol = False
            fadeint = 50
            pixelcolor = Color.FromArgb(120, 0, 255, 0)
            fadetime = 1
            Variation = 15
            Precise = 2
            Delay = 500
            markersize = 10
            alarm = True
            maptracker = True
            alarmsound = False
            Bombtimer = False


        Else

            iBaseTools.Valorant = My.Settings.Valorant2
            iBaseTools.Fadeint = My.Settings.Fadeint2
            iBaseTools.Markersize = My.Settings.Markersize2
            iBaseTools.Variation = My.Settings.Variation2
            iBaseTools.Fadetime = My.Settings.Fadetime2
            iBaseTools.Delay = My.Settings.Delay2
            iBaseTools.Pixelcolor = My.Settings.Pixelcolor2
            iBaseTools.Alarm = My.Settings.Alarm2
            iBaseTools.Multitarget = My.Settings.Multitarget2
            iBaseTools.Maptracker = My.Settings.Maptracker2
            iBaseTools.Bombtimer2 = My.Settings.Bombtimer2
            iBaseTools.Alarmsound2 = My.Settings.Alarmsound2
            iBaseTools.Bombdefusetimes = My.Settings.Bomdefusetime
            iBaseTools.Bombexplodetime = My.Settings.Bombexplodetime
            iBaseTools.Bombvariation = My.Settings.Bombvariation
            iBaseTools.Precise = My.Settings.Precise2

            TextBox1.Text = My.Settings.Bombexplodetime.ToString
            TextBox2.Text = My.Settings.Bomdefusetime.ToString
            Bombtimer = My.Settings.Bombtimer2
            maptracker = My.Settings.Maptracker2
            markersize = My.Settings.Markersize2
            Variation = My.Settings.Variation2
            fadetime = My.Settings.Fadetime2
            Delay = My.Settings.Delay2
            pixelcolor = My.Settings.Pixelcolor2
            alarm = My.Settings.Alarm2
            multitarget = My.Settings.Multitarget2


            TrackBar5.Value = My.Settings.Markersize2
            TrackBar2.Value = My.Settings.Variation2
            TrackBar4.Value = My.Settings.Fadetime2
            TrackBar3.Value = My.Settings.Delay2
            TrackBar1.Value = My.Settings.Precise2
            TrackBar6.Value = My.Settings.Bombvariation

            If My.Settings.Alarmsound2 Then
                CheckBox6.Checked = True
            Else
                CheckBox6.Checked = False
            End If

            If My.Settings.Bombtimer2 Then
                CheckBox5.Checked = True
            Else
                CheckBox5.Checked = False
            End If

            If My.Settings.Maptracker2 Then
                CheckBox7.Checked = True
            Else
                CheckBox7.Checked = False
            End If

            If My.Settings.Multitarget2 Then
                CheckBox3.Checked = True
            Else
                CheckBox3.Checked = False
            End If

            If My.Settings.Fadeint2 = 100 Then
                CheckBox1.Checked = False
                fadeint = 100
            Else
                CheckBox1.Checked = True
                fadeint = 50
            End If

            If My.Settings.Alarm2 Then
                CheckBox2.Checked = True
            Else
                CheckBox2.Checked = False
            End If


        End If

        Label6.Text = "Marker Size: " & TrackBar5.Value.ToString
        Label1.Text = "Precision: " & TrackBar1.Value.ToString
        Label2.Text = "Variation: " & TrackBar2.Value.ToString
        Label5.Text = "Fade Time: " & TrackBar4.Value.ToString
        Label3.Text = "Search every X milliseconds for Target: " & TrackBar3.Value.ToString
        Label11.Text = "Bombvariation: " & TrackBar6.Value.ToString

        Control.CheckForIllegalCrossThreadCalls = False 'Please don't kill me for that..

        Dim myCallback As New System.Threading.TimerCallback(AddressOf FindPixels)
        Dim myCallback2 As New System.Threading.TimerCallback(AddressOf RemoveColor)

        myTimer = New System.Threading.Timer(myCallback, Nothing, 0, TrackBar3.Value)
        myTimer2 = New System.Threading.Timer(myCallback2, Nothing, Timeout.Infinite, Timeout.Infinite)

    End Sub


    Private myTimer As System.Threading.Timer
    Private myTimer2 As System.Threading.Timer

    Private ReadOnly pixels As New List(Of PixelInfo)
    Dim audiolol As Boolean
    Dim pixelcolor As Color
    Dim fadeint As Integer
    Dim fadetime As Integer
    Dim Variation As Integer
    Dim Precise As Integer
    Dim Delay As Integer
    Dim markersize As Integer
    Dim alarm As Boolean
    Dim maptracker As Boolean
    Dim Bombtimer As Boolean
    Dim alarmsound As Boolean
    Dim markersizex As Integer
    Dim markersizey As Integer

    ReadOnly xd3 As Color = Color.FromArgb(255, 12, 218, 241)
    ReadOnly xd4 As Color = Color.FromArgb(255, 79, 84, 59)
    ReadOnly xd5 As Color = Color.FromArgb(255, 161, 142, 107)
    ReadOnly xd6 As Color = Color.FromArgb(255, 25, 142, 185)
    ReadOnly xd7 As Color = Color.FromArgb(255, 8, 100, 132)


    Dim posi As Integer
    Dim posj As Integer

    Dim posi1 As Integer
    Dim posj1 As Integer

    Dim posi2 As Integer
    Dim posj2 As Integer

    Dim posi3 As Integer
    Dim posj3 As Integer

    Dim posi4 As Integer
    Dim posj4 As Integer

    Dim number As Integer

    Private Shared Function Color_Is_In_The_Target_Variations(variation As Integer, tested As Color, target As Color) As Boolean

        If tested.R >= target.R - variation And tested.R <= target.R + variation And
           tested.G >= target.G - variation And tested.G <= target.G + variation And
           tested.B >= target.B - variation And tested.B <= target.B + variation Then

            Return True
        Else
            Return False

        End If

    End Function

    Private Shared Sub Audio2()
        My.Computer.Audio.Play(My.Resources.alarm, AudioPlayMode.Background)
    End Sub


    Private Sub FindPixels()
        If maptracker Then

            Using bx As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using gx As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bx)
                    Try
                        gx.CopyFromScreen(Me.Left, Me.Top, 0, 0, bx.Size)
                    Catch
                    End Try

                    For i = 0 To (bx.Width - 1)
                        For j = 0 To (bx.Height - 1)

                            If Color_Is_In_The_Target_Variations(Variation, bx.GetPixel(i, j), xd3) Then
                                Try
                                    posi = i
                                    posj = j

                                    posi1 = i + 10
                                    posj1 = j + 10

                                    posi4 = i - 10
                                    posj4 = j - 10

                                    posi2 = i - 10
                                    posj2 = j + 10

                                    posi3 = i + 10
                                    posj3 = j - 10

                                    number = 1


                                    If Color_Is_In_The_Target_Variations(Variation, bx.GetPixel(posi1, posj1), xd4) Then
                                        number = number + 1
                                    End If

                                    If Color_Is_In_The_Target_Variations(Variation, bx.GetPixel(posi2, posj2), xd5) Then
                                        number = number + 1
                                    End If

                                    If Color_Is_In_The_Target_Variations(Variation, bx.GetPixel(posi3, posj3), xd6) Then
                                        number = number + 1
                                    End If

                                    If Color_Is_In_The_Target_Variations(Variation, bx.GetPixel(posi4, posj4), xd7) Then
                                        number = number + 1
                                    End If

                                    If number >= Precise Then
                                        pixels.Add(New PixelInfo With {.Location = New Point(posi - (markersizex / 2), posj - (markersizey / 2)),
                                                                       .CreatedTime = Date.Now,
                                                                       .Colour = pixelcolor})

                                        'Repaint the drawing surface.
                                        PictureBox1.Invalidate()

                                        myTimer2.Change(0, 250)

                                        If audiolol = False And alarm = True Then
                                            Audio2()
                                            audiolol = True
                                        End If

                                        If multitarget = False Then
                                            GoTo Nexx
                                        Else
                                        End If

                                    End If
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

    Private Sub RemoveColor()
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
                audiolol = False
            End If
        Catch
        End Try

    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Label2.Text = "Color Variation: " & TrackBar2.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        Variation = TrackBar2.Value
        iBaseTools.Variation = TrackBar2.Value
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Label1.Text = "Precision: " & TrackBar1.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        Precise = TrackBar1.Value
        iBaseTools.Precise = TrackBar1.Value
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

        Label3.Text = "Check Interval - Milliseconds: " & TrackBar3.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        If TrackBar3.Value <= 200 And TrackBar3.Value >= 51 Then
            Label3.ForeColor = Color.DarkOrange
        ElseIf TrackBar3.Value <= 50 Then
            Label3.ForeColor = Color.Red
        Else
            Label3.ForeColor = Color.Black
        End If

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
            iBaseTools.Fadeint = 3
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

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked Then
            alarm = True
            iBaseTools.Alarm = True
        Else
            alarm = False
            iBaseTools.Alarm = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("This will change the Size of the Markers shown on the Minimap once the Target (Enemy) has been found")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Use a Value between 1 and 5 - (Default = 1)" & vbCrLf & vbCrLf & "Read the text and you will probably improve the detection a lot!" & vbCrLf & vbCrLf & "Precision - Instructions:" & vbCrLf & "I will take League of Legends as the example-game here but it works for all other games with Minimap too. Let's say you want to track and mark the Enemy Jungler on your Minimap. Now, how could a simple 'Pixelscan' Program like this find the Icon of your Enemy Jungle on your Minimap? Well it is easier than you think. You probably know what a Color Picker is right? It is for example in the Windows Program 'Paint' or 'Photoshop'. If you don't know which color a Pixel of the Image has you can use a Color Picker to get that RGB Color Information. We do the same thing in the game. First, this Program will Open Up a Colorpicker. Once your Enemys Icon is visible on your Minimap you have to select a Pixel/Color of your Enemys Jungles Icon with the Color Picker. This program saves this colorinformation and now searches continuously for exactly this color pixel on your minimap. If it finds this color pixel it will mark it on your Minimap with a Color and an alarm will sound. Sadly it would be to easy to use just 'one' Pixel because the color you choose won't be only in the Icon of your Enemys Jungle but maybe also on some Trees or in a River or a Path or something else. So we add a Second or a Third or a Fourth or even a Fifth Pixel to the detection that is near to the first Pixel. If all 5 Pixels that you Colorpicked have the Same Color as the Icon on the Map it will mark the Icon. So You can choose between 1 and 5 for either 1, 2, 3, 4, or 5 scanned Pixel. Using More Pixels (5) Will be more precise (less false detections) but also will probably be slower and less detect the Enemy Jungle since all 5 Pixels aren't always Visible if the Enemy Jungler is near to for example your Top Player both Icons will overlap and the Icon of the Enemy Jungler might only be visible for 1/4. If you want to be safe choose a Number between 2 and 3.")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show("Enter a value between 0 and 35 - (Default = 5)" & vbCrLf & vbCrLf & "Read the text and you will probably improve the detection a lot!" & vbCrLf & vbCrLf & "Color Variation - Instructions:" & vbCrLf & "If you read the Text before you should know now that this Program searches between 1 - 5 Pixels with the Same Color as for example the Icon of your Enemy Jungle at your Minimap has. If these Pixels have the Same Color as you picked before it will mark these in a Color and play an Alarmsound. The issue is that Riot did some prevention against that. For example say, you want to track the Enemy Khazix. He has a yellow Eye which is a good Spot to track a Color because it is bright and different to all others. Now it will always search for the yellow color that you picked from KhaZixs eye. But bad news.. this color wont be the same everytime. Yes even if you dont see it the color in the icons slightly changes a bit from for example 'Red=100' 'Green=100' 'Blue=100' to 'Red=110' 'Green=105' 'Blue=90'. As you can see the Color changed and the Program wouldn't be able to detect the Color anymore. That's why I added Colorvariation. If you use for example the Value '10' It will search the color you picked but with a variation of 10 points + and -. That means instead of only searching the Color 'Red=100' 'Green=100' 'Blue=100' It will also search all other colors from 'Red=90' 'Green=90' 'Blue=90' to 'Red=110' 'Green=110' 'Blue=110'. Thats great right, but be careful. Higher numbers means it could also pick up other colors at the Minimap that you don't want to search so better use a Color Variation between 5-20.")
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

        If CheckBox5.Checked And iBaseTools.Setbomb = False Then
            MessageBox.Show("Since you have Bomb Timer enabled you have to specify the Bomb Position first.")
            Me.Hide()
            Form5.Show()
            Return
        End If

        If CheckBox6.Checked And iBaseTools.Setbomb = False Then
            MessageBox.Show("Since you have Alarmsound enabled you have to specify the Bomb Position first.")
            Me.Hide()
            Form5.Show()
            Return
        End If

        If maptracker Then
            If iBaseTools.Colorpicked = False Then
                MessageBox.Show("You have to select a Color that you want to Track first." & vbCrLf & "Click on the 'Track Color' Button.")
                Return
            End If
        End If

        MessageBox.Show("The Program is Tracking your Minimap right now. The Window will be transparent so don't wonder if you can't see any program on your Screen.")

        If CheckBox1.Checked Then
            iBaseTools.Fadeint = 3
        Else
            iBaseTools.Fadeint = 100
        End If

        If CheckBox2.Checked Then
            iBaseTools.Alarm = True
        Else
            iBaseTools.Alarm = False
        End If

        iBaseTools.Markersize = TrackBar5.Value
        iBaseTools.Precise = TrackBar1.Value
        iBaseTools.Variation = TrackBar2.Value
        iBaseTools.Fadetime = TrackBar4.Value
        iBaseTools.Delay = TrackBar3.Value

        If CheckBox7.Checked = False Then
            iBaseTools.Show()
            iBaseTools.Execute()
        End If

        Me.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        myTimer.Change(Timeout.Infinite, Timeout.Infinite)
        myTimer2.Change(Timeout.Infinite, Timeout.Infinite)
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try


        My.Settings.Bomdefusetime = Convert.ToInt32(TextBox2.Text)
        My.Settings.Bombexplodetime = Convert.ToInt32(TextBox1.Text)
        My.Settings.Maptracker2 = maptracker
        My.Settings.Alarmsound2 = iBaseTools.Alarmsound2
        My.Settings.Bombtimer2 = Bombtimer
        My.Settings.Fadeint2 = iBaseTools.Fadeint
        My.Settings.Markersize2 = markersize
        My.Settings.Variation2 = Variation
        My.Settings.Fadetime2 = fadetime
        My.Settings.Delay2 = Delay
        My.Settings.Pixelcolor2 = pixelcolor
        My.Settings.Alarm2 = alarm
        My.Settings.Multitarget2 = multitarget
        My.Settings.Precise2 = Precise
        My.Settings.Saved = "exist"
        My.Settings.Save()
        FrmMain.Show()
        Me.Close()
        iBaseTools.Colorpicked = True
    End Sub

    Dim multitarget As Boolean = False

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            multitarget = True
            iBaseTools.Multitarget = True
        Else
            multitarget = False
            iBaseTools.Multitarget = False
        End If
    End Sub

    Private CPUPerf As New PerformanceCounter()

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        My.Settings.Bomdefusetime = Convert.ToInt32(TextBox2.Text)
        My.Settings.Bombexplodetime = Convert.ToInt32(TextBox1.Text)
        My.Settings.Maptracker2 = maptracker
        My.Settings.Alarmsound2 = iBaseTools.Alarmsound2
        My.Settings.Bombcoordinatesx1 = iBaseTools.Bombcoordinatesx
        My.Settings.Bombcoordinatesy1 = iBaseTools.Bombcoordinatesy
        My.Settings.Bombtimer2 = Bombtimer
        My.Settings.Fadeint2 = iBaseTools.Fadeint
        My.Settings.Markersize2 = markersize
        My.Settings.Variation2 = Variation
        My.Settings.Fadetime2 = fadetime
        My.Settings.Delay2 = Delay
        My.Settings.Pixelcolor2 = pixelcolor
        My.Settings.Alarm2 = alarm
        My.Settings.Multitarget2 = multitarget
        My.Settings.Precise2 = Precise
        My.Settings.Saved = "exist"
        My.Settings.Save()
    End Sub

    Private Sub TrackBar3_DragOver(sender As Object, e As DragEventArgs)

    End Sub

    Private Sub TrackBar3_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = False Then
            iBaseTools.Bombtimer2 = False
            Bombtimer = False
        Else
            Bombtimer = True
            iBaseTools.Bombtimer2 = True
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            iBaseTools.Alarmsound2 = True
            alarmsound = True
        Else
            iBaseTools.Alarmsound2 = False
            alarmsound = False
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = False Then

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


    Private Shown = False
    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Shown = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            iBaseTools.Bombexplodetime = Convert.ToInt32(TextBox1.Text)
        Catch
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            iBaseTools.Bombdefusetimes = Convert.ToInt32(TextBox2.Text)
        Catch
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MessageBox.Show("If the game you want to play has a visible Bomb Icon (CS:GO - Red Bomb Icon) (Valorant - Red Spike Icon) then you can use this Feature. It will show you in the left top corner how much time is left to defuse the Bomb.")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        MessageBox.Show("This is the Amount of Time in Seconds how long it takes for the Bomb to explode from planted until the explosion. For example in Valorant and CS:GO the Bomb explodes after 45 Seconds. So enter the Number 45.")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        MessageBox.Show("This is the Amount of Time you need to defuse the Bomb. For example in CS:GO you need 10 Seconds, in Valorant you need 7. So enter the Number 10 if you play CS:GO.")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MessageBox.Show("If the game you want to play has a visible Bomb Icon (CS:GO - Red Bomb Icon) (Valorant - Red Spike Icon) then you can use this Feature. It will 'Beep' an Alarmsound 4 times before it is too late to defuse the Bomb. The last (4.) Beep indicates that it is too late to defuse the Bomb now.")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        MessageBox.Show("Use this checkbox if you play something like Battlefield or COD and want to detect multiple Targets (for example the red dot enemys) on your Mininmap at once. Without this checkbox it will always only search 1 Target and Mark it if it has found it. This may increases your CPU Usage and slows down the Program." & vbCrLf & vbCrLf & "This works best with a Small Marker Size and Precision at Value '1'.")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        MessageBox.Show("Once the Target / Enemy has been found on your Minimap it will play a Sound so you know that you are going to get ganked or that the Enemy you want to track is visible on the map")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        MessageBox.Show("This is the Map Tracking which you can see on the left gif animation and in your game as map overlay. It will show the Marks over the Enemys.")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        MessageBox.Show("After a few Seconds the Markers on the Minimap will disappear slowly. If you want them to instantly Hide disable / uncheck this Checkbox")
    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As EventArgs) Handles CheckBox5.Click
        If CheckBox5.Checked = True Then

            Bomb.Close()

            myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            myTimer2.Change(Timeout.Infinite, Timeout.Infinite)

            My.Settings.Bomdefusetime = Convert.ToInt32(TextBox2.Text)
            My.Settings.Bombexplodetime = Convert.ToInt32(TextBox1.Text)
            My.Settings.Maptracker2 = maptracker
            My.Settings.Alarmsound2 = iBaseTools.Alarmsound2
            My.Settings.Bombcoordinatesx1 = iBaseTools.Bombcoordinatesx
            My.Settings.Bombcoordinatesy1 = iBaseTools.Bombcoordinatesy
            My.Settings.Bombtimer2 = Bombtimer
            My.Settings.Fadeint2 = iBaseTools.Fadeint
            My.Settings.Markersize2 = markersize
            My.Settings.Variation2 = Variation
            My.Settings.Fadetime2 = fadetime
            My.Settings.Delay2 = Delay
            My.Settings.Pixelcolor2 = pixelcolor
            My.Settings.Alarm2 = alarm
            My.Settings.Multitarget2 = multitarget
            My.Settings.Precise2 = Precise
            My.Settings.Saved = "exist"
            My.Settings.Save()

            iBaseTools.Bombfinder = True
            iBaseTools.Setbomb = True

            Me.Close()
            Form5.Show()
        End If
    End Sub

    Private Sub CheckBox6_Click(sender As Object, e As EventArgs) Handles CheckBox6.Click
        If CheckBox6.Checked = True Then
            If iBaseTools.Bombtimer2 = False Then
                myTimer.Change(Timeout.Infinite, Timeout.Infinite)
                myTimer2.Change(Timeout.Infinite, Timeout.Infinite)

                My.Settings.Bomdefusetime = Convert.ToInt32(TextBox2.Text)
                My.Settings.Bombexplodetime = Convert.ToInt32(TextBox1.Text)
                My.Settings.Maptracker2 = maptracker
                My.Settings.Alarmsound2 = iBaseTools.Alarmsound2
                My.Settings.Bombcoordinatesx1 = iBaseTools.Bombcoordinatesx
                My.Settings.Bombcoordinatesy1 = iBaseTools.Bombcoordinatesy
                My.Settings.Bombtimer2 = Bombtimer
                My.Settings.Fadeint2 = iBaseTools.Fadeint
                My.Settings.Markersize2 = markersize
                My.Settings.Variation2 = Variation
                My.Settings.Fadetime2 = fadetime
                My.Settings.Delay2 = Delay
                My.Settings.Pixelcolor2 = pixelcolor
                My.Settings.Alarm2 = alarm
                My.Settings.Multitarget2 = multitarget
                My.Settings.Precise2 = Precise
                My.Settings.Saved = "exist"
                My.Settings.Save()

                iBaseTools.Bombfinder = True
                iBaseTools.Setbomb = True

                Me.Close()
                Form5.Show()
            End If
        End If
    End Sub

    Private Sub Button10_MouseDown(sender As Object, e As MouseEventArgs) Handles Button6.MouseDown, Button5.MouseDown, Button4.MouseDown, Button3.MouseDown, Button2.MouseDown, Button17.MouseDown, Button16.MouseDown, Button15.MouseDown, Button14.MouseDown, Button13.MouseDown, Button12.MouseDown, Button11.MouseDown, Button10.MouseDown, TrackBar5.MouseDown, TrackBar4.MouseDown, TrackBar3.MouseDown, TrackBar2.MouseDown, MyBase.MouseDown, CheckBox3.MouseDown, CheckBox2.MouseDown, CheckBox1.MouseDown, Button9.MouseDown, Button8.MouseDown, Button7.MouseDown, Button18.MouseDown, Button1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub Button10_MouseUp(sender As Object, e As MouseEventArgs) Handles Button6.MouseUp, Button5.MouseUp, Button4.MouseUp, Button3.MouseUp, Button2.MouseUp, Button17.MouseUp, Button16.MouseUp, Button15.MouseUp, Button14.MouseUp, Button13.MouseUp, Button12.MouseUp, Button11.MouseUp, Button10.MouseUp, TrackBar5.MouseUp, TrackBar4.MouseUp, TrackBar3.MouseUp, TrackBar2.MouseUp, MyBase.MouseUp, CheckBox3.MouseUp, CheckBox2.MouseUp, CheckBox1.MouseUp, Button9.MouseUp, Button8.MouseUp, Button7.MouseUp, Button18.MouseUp, Button1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub CheckBox5_MouseDown(sender As Object, e As MouseEventArgs) Handles CheckBox7.MouseDown, CheckBox6.MouseDown, CheckBox5.MouseDown, CheckBox3.MouseDown, CheckBox2.MouseDown, CheckBox1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub CheckBox5_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox7.MouseUp, CheckBox6.MouseUp, CheckBox5.MouseUp, CheckBox3.MouseUp, CheckBox2.MouseUp, CheckBox1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseDown, TextBox1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseUp, TextBox1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub Button8_MouseDown(sender As Object, e As MouseEventArgs) Handles Button9.MouseDown, Button8.MouseDown, Button7.MouseDown, Button1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub Button8_MouseUp(sender As Object, e As MouseEventArgs) Handles Button9.MouseUp, Button8.MouseUp, Button7.MouseUp, Button1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub TrackBar5_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBar5.MouseDown, TrackBar4.MouseDown, TrackBar3.MouseDown, TrackBar2.MouseDown, TrackBar1.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub TrackBar5_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar5.MouseUp, TrackBar4.MouseUp, TrackBar3.MouseUp, TrackBar2.MouseUp, TrackBar1.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        MessageBox.Show("If you play for example CS:GO, the Background of the Bombicon or the Icon itself is 50% transparent. Means you can see a bit trough it. If that is the case you HAVE TO use this feature. Why? Because when you have to locate the Bomb and move your Mouse over the Bomb Icon it tracks the location and the Color of the Bomb Icon. But if the Icon is transparent it also picks up the color behind the Bomb Icon so it distorts the result. You won't have the exact Color Value of only the Bomb, but the Background Color too. So you use this 'Bombvariation' to fix that. If you change the Value up to 10 instead of only searching for the bomb icon color for example 'Red:100' 'Green:100' 'Blue:100' it will also search for all other Color Values between 'Red:90' and 'Red:110', 'Green:90' and 'Green:110', 'Blue:90' and 'Blue:110'. Because the Iconcolor changes with the Background. Use higher Values like 20 or even 40 if it doesn't detect the Bomb Icon!")
    End Sub

    Private Sub TrackBar6_Scroll(sender As Object, e As EventArgs) Handles TrackBar6.Scroll
        Label11.Text = "Bombvariation: " & TrackBar6.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
        iBaseTools.Bombvariation = TrackBar6.Value
    End Sub

    Private Sub Button19_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBar6.MouseDown, Label11.MouseDown, Button19.MouseDown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub Button19_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar6.MouseUp, Label11.MouseUp, Button19.MouseUp
        Try
            iBaseTools.myTimer.Change(0, Delay)
            iBaseTools.Canvas.Show()
        Catch
        End Try
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        MessageBox.Show("This is not a replacement for the 'Save' Button above." & vbCrLf & "This saves only the Track Color!" & vbCrLf & vbCrLf & "For example let's say you play League of Legends and you have an enemy Jax in Jungle. You already Tracked his color and it works great but on next Restart you probably wont play against Jax and have to choose a different color so it will remove the old Color and choose the new one you want to Track. Next time you play against Jax you have to retrack his color again.. annoying right. This Feature allows you to Save the Tracked Color. In the field on your left you can for example write the name 'Jax' and press Save. It will then Save the tracked color of Jax and everytime you play against Jax you can also write into the left field 'Jax' and press the 'load' Button. Then it will load the saved Settings for Jax and track him. This way you can also share your saved Jax.txt file with others since this works for everyone else too.")
        File.Create(My.Computer.FileSystem.CurrentDirectory & "\" & TextBox3.Text & ".txt").Dispose()
        Dim data As String() = {Variation, Precise, iBaseTools.Pixeldistance, iBaseTools.Colorx.ToArgb.ToString, iBaseTools.Colorx2.ToArgb.ToString, iBaseTools.Colorx3.ToArgb.ToString, iBaseTools.Colorx4.ToArgb.ToString, iBaseTools.Colorx5.ToArgb.ToString}
        File.WriteAllLines(My.Computer.FileSystem.CurrentDirectory & "\" & TextBox3.Text & ".txt", data)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Try
            Dim reader As New System.IO.StreamReader(My.Computer.FileSystem.CurrentDirectory & "\" & TextBox3.Text & ".txt")
            Dim allLines As List(Of String) = New List(Of String)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()
            iBaseTools.Variation = ReadLine(1, allLines)
            iBaseTools.Precise = ReadLine(2, allLines)
            iBaseTools.Pixeldistance = ReadLine(1, allLines)
            iBaseTools.Colorx = Color.FromArgb(CInt(ReadLine(3, allLines)))
            iBaseTools.Colorx2 = Color.FromArgb(CInt(ReadLine(4, allLines)))
            iBaseTools.Colorx3 = Color.FromArgb(CInt(ReadLine(5, allLines)))
            iBaseTools.Colorx4 = Color.FromArgb(CInt(ReadLine(6, allLines)))
            iBaseTools.Colorx5 = Color.FromArgb(CInt(ReadLine(7, allLines)))
        Catch
            MessageBox.Show("Settings don't exist!" & vbCrLf & "You probably have not saved any Settings for the Name: " & TextBox3.Text)
        End Try


    End Sub


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

End Class
