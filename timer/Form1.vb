Imports System.Drawing.Imaging
Imports System.Threading
Imports System.IO
Imports System.Timers

Public Class iBaseTools
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MessageBox.Show("This program is unoptimized, badly coded and still in Beta!" & vbCrLf & "Be aware that you may have a higher CPU usage due to this program." & vbCrLf & vbCrLf & "Also it does not work in Fullscreen. You have to set your Game to 'Windowed' / 'Fullscreen Windowed' / 'Borderless'." & vbCrLf & vbCrLf & "iBaseTools - coded by Baseult (iBaseult)", "Information - iBaseTools - Coded by Baseult")
        Form2.Show()
        Controls.Add(Canvas)


    End Sub

    Public myTimer As System.Threading.Timer

    Public Property Pixeldistance As Integer
    Public Property Bombvariation As Integer = 0
    Public Property Bombdefusetimes As Integer
    Public Property Bombexplodetime As Integer
    Public Property Bombcolor As Color
    Public Property Bombfinder As Boolean = False
    Public Property Clicked As Boolean = False
    Public Property Clicked2 As Boolean = False
    Public Property Warning As Boolean = False
    Public Property Warning2 As Boolean = False
    Public Property Setbomb As Boolean
    Public Property Saveme2 As Boolean = False
    Public Property Saveme As Boolean = True
    Public Property Colorpicked As Boolean = False
    Public Property Form2Location
    Public Property Form2Size
    Public Property Form2Left As Integer
    Public Property Form2Top As Integer
    Public Property Form2width As Integer
    Public Property Form2Height As Integer
    Public Property Multitarget As Boolean = False
    Public Property Fadeint As Integer = 50
    Public Property Alarm As Boolean = True
    Public Property Pixelcolor As Color = Color.Red
    Public Property Markersize As Integer = 10
    Public Property Fadetime As Integer = 1
    Public Property Delay As Integer = 500
    Public Property Variation As Integer = 15
    Public Property Precise As Integer = 2
    Public Property Valorant As Boolean = False
    Public Property Alarmsound As Boolean = True
    Public Property Alarmsound2 As Boolean = False
    Public Property Bombtimer As Boolean
    Public Property Bombtimer2 As Boolean
    Public Property Questiontrue As Boolean = False
    Public Property Maptracker As Boolean = True
    Public Property Bombcoordinatesx As String
    Public Property Bombcoordinatesy As String
    Public Property Colorx As Color
    Public Property Colorx2 As Color
    Public Property Colorx3 As Color
    Public Property Colorx4 As Color
    Public Property Colorx5 As Color

    Dim audiolol As Boolean = False

    Public Sub Execute()

        If Valorant Then

            If Bombtimer Then
                Bomb.Show()
            End If

            If alarmsound Then
                Bomb.Show()
            End If

            If maptracker Then
                Try
                    Dim myCallback As New System.Threading.TimerCallback(AddressOf FindPixels)
                    myTimer = New System.Threading.Timer(myCallback, Nothing, 0, Delay)
                Catch
                End Try

            Else
                Try
                    myTimer.Change(Timeout.Infinite, Timeout.Infinite)
                    Canvas.Hide()
                Catch
                End Try

            End If

        Else

            If Bombtimer2 Then
                Bomb.Show()
            Else
            End If

            If Alarmsound2 Then
                Bomb.Show()
            End If

            If maptracker Then
                Try
                    Dim myCallback As New System.Threading.TimerCallback(AddressOf FindPixels)
                    myTimer = New System.Threading.Timer(myCallback, Nothing, 0, Delay)
                Catch
                End Try

            Else
                Try
                    myTimer.Change(Timeout.Infinite, Timeout.Infinite)
                    Canvas.Hide()
                Catch
                End Try

            End If


        End If

        Dim xd As Point

        Me.Location = xd
        Me.Size = Form2Size
        Me.Left = Form2Left
        Me.Top = Form2Top
        Me.Width = Form2width
        Me.Height = Form2Height

        If Valorant = True And Saveme = True Then

            My.Settings.Width1 = Form2width
            My.Settings.Height1 = Form2Height
            My.Settings.Location1 = Form2Location
            My.Settings.Size1 = Form2Size
            My.Settings.Left1 = Form2Left
            My.Settings.Top1 = Form2Top
            My.Settings.Valorant1 = Valorant
            My.Settings.Fadeint1 = fadeint
            My.Settings.Markersize1 = markersize
            My.Settings.Variation1 = Variation
            My.Settings.Fadetime1 = fadetime
            My.Settings.Delay1 = Delay
            My.Settings.Pixelcolor1 = pixelcolor
            My.Settings.Alarmsound1 = alarmsound
            My.Settings.Maptracker1 = maptracker
            My.Settings.Bombtimer1 = Bombtimer
            My.Settings.Bombcoordinatesx1 = Bombcoordinatesx
            My.Settings.Bombcoordinatesy1 = Bombcoordinatesy
            My.Settings.Saved = "exist"
            My.Settings.Save()

            File.Create(My.Computer.FileSystem.CurrentDirectory & "\Settings.txt").Dispose()

            Saveme = False
        ElseIf Valorant = False And Saveme = True Then

            My.Settings.Width2 = Form2width
            My.Settings.Height2 = Form2Height
            My.Settings.Location2 = Form2Location
            My.Settings.Size2 = Form2Size
            My.Settings.Left2 = Form2Left
            My.Settings.Top2 = Form2Top
            My.Settings.Valorant2 = Valorant
            My.Settings.Fadeint2 = fadeint
            My.Settings.Markersize2 = markersize
            My.Settings.Variation2 = Variation
            My.Settings.Fadetime2 = fadetime
            My.Settings.Delay2 = Delay
            My.Settings.Pixelcolor2 = pixelcolor
            My.Settings.Alarmsound2 = Alarmsound2
            My.Settings.Maptracker2 = maptracker
            My.Settings.Alarm2 = alarm
            My.Settings.Multitarget2 = multitarget
            My.Settings.Precise2 = Precise
            My.Settings.Bombtimer2 = Bombtimer2
            My.Settings.Saved = "exist"
            My.Settings.Save()

            File.Create(My.Computer.FileSystem.CurrentDirectory & "\Settings2.txt").Dispose()

            Saveme = False
        End If
        Try
            myTimer.Change(0, Delay)
        Catch
        End Try

    End Sub


    Private Shared Sub Audio2()
        My.Computer.Audio.Play(My.Resources.alarm, AudioPlayMode.Background)
    End Sub


    Private Shared Function Color_Is_In_The_Target_Variations(variation As Integer, tested As Color, target As Color) As Boolean

        If tested.R >= target.R - variation And tested.R <= target.R + variation And
           tested.G >= target.G - variation And tested.G <= target.G + variation And
           tested.B >= target.B - variation And tested.B <= target.B + variation Then

            Return True
        Else
            Return False

        End If

    End Function

    Public WithEvents Canvas As New PictureBox With {.BackColor = Color.Black, .Dock = DockStyle.Fill}
    Private ReadOnly pixels As New List(Of PixelInfo)

    Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles Canvas.Paint
        'Draw a pixel as a 3x3 square.

        If Valorant = False Then
            markersizex = markersize
            markersizey = markersize
        Else
            markersizex = markersize
            markersizey = markersize
        End If
        Dim pixelSize As New Size(markersizex, markersizey)

        Try
            Dim currentTime = Date.Now

            'Start fading a pixel after 1 second.
            Dim nonFadePeriod = TimeSpan.FromSeconds(fadetime)

            For i = pixels.Count - 1 To 0 Step -1
                Dim pixel = pixels(i)

                If pixel IsNot Nothing Then
                    Using brush As New SolidBrush(pixel.Colour)
                        'Draw the pixel at its own location.
                        e.Graphics.FillRectangle(brush, New Rectangle(pixel.Location, pixelSize))
                    End Using


                    If currentTime - pixel.CreatedTime > nonFadePeriod Or pixels.Count > 74000 Then
                        'Increase the transparency of the pixel.
                        Dim pixelAlpha = pixel.Colour.A - 3

                        If i < pixels.Count Then
                            If pixelAlpha <= 0 Then
                                'Remove fully transparent pixels.
                                pixels.RemoveAt(i)
                            Else
                                pixel.Colour = Color.FromArgb(pixelAlpha, &HFF, 0, 0)
                            End If
                        End If
                    End If
                End If

            Next
        Catch
        End Try

        'Repaint the drawing surface.

        If pixels.Count = 0 Then
            audiolol = False
            pixels.Clear()
        End If

        If pixels.Count > 0 Then
            Canvas.Invalidate()
        End If


    End Sub

    Dim xd3 As Color
    Dim xd4 As Color
    Dim xd5 As Color
    Dim xd6 As Color
    Dim xd7 As Color

    Dim markersizex
    Dim markersizey

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

    Dim muchwidth As Boolean
    Dim muchheight As Boolean
    Dim smallx As Boolean
    Dim smally As Boolean


    Private Sub FindPixels()
        If Maptracker Then
            If pixels.Count < 75000 Then
                If Valorant Then
                    xd3 = Color.FromArgb(255, 255, 75, 67)
                Else
                    xd3 = Colorx
                    xd4 = Colorx2
                    xd5 = Colorx3
                    xd6 = Colorx4
                    xd7 = Colorx5
                End If

                Using b As New Bitmap(Me.Width, Me.Height)
                    Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(b)
                        Try
                            g.CopyFromScreen(Me.Left, Me.Top, 0, 0, b.Size)
                        Catch
                        End Try


                        For i = 0 To (b.Width - 1)
                            If pixels.Count < 75000 Then
                                For j = 0 To (b.Height - 1)
                                    If pixels.Count < 75000 Then
                                        If Valorant Then
                                            If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(i, j), xd3) Then
                                                Try
                                                    pixels.Add(New PixelInfo With {.Location = New Point(i, j),
                                                                       .CreatedTime = Date.Now,
                                                                       .Colour = Pixelcolor})

                                                    'Repaint the drawing surface.
                                                    Canvas.Invalidate()
                                                Catch
                                                    GoTo Nexx
                                                End Try

                                            End If
                                        Else
                                            If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(i, j), xd3) Then

                                                number = 1

                                                Dim number1 As Boolean = False
                                                Dim number2 As Boolean = False
                                                Dim number3 As Boolean = False
                                                Dim number4 As Boolean = False

                                                posi = i
                                                posj = j

                                                If Precise > 1 Then

                                                    posi1 = i + Pixeldistance
                                                    posj1 = j + Pixeldistance

                                                    posi2 = i - Pixeldistance
                                                    posj2 = j - Pixeldistance

                                                    muchwidth = False
                                                    muchheight = False
                                                    smallx = False
                                                    smally = False

                                                    If i > Pixeldistance Then
                                                        smallx = True
                                                    End If

                                                    If j > Pixeldistance Then
                                                        smally = True
                                                    End If

                                                    If i + Pixeldistance < Me.Width Then
                                                        muchwidth = True
                                                    End If

                                                    If j + Pixeldistance < Me.Height Then
                                                        muchheight = True
                                                    End If

                                                    Try

                                                        For poi1 = posi1 - 2 To (posi1 + 2)
                                                            For poj1 = posj1 - 2 To (posj1 + 2)
                                                                If muchwidth And muchheight Then
                                                                    If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(poi1, poj1), xd4) Then
                                                                        number1 = True



                                                                    End If
                                                                End If
                                                            Next
                                                        Next

                                                        For poi2 = posi2 - 2 To (posi2 + 2)
                                                            For poj2 = posj1 - 2 To (posj1 + 2)
                                                                If smallx And muchheight Then
                                                                    If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(poi2, poj2), xd5) Then
                                                                        number2 = True

                                                                    End If
                                                                End If
                                                            Next
                                                        Next


                                                        For poi3 = posi1 - 2 To (posi1 + 2)
                                                            For poj3 = posj2 - 2 To (posj2 + 2)
                                                                If muchheight And smally Then
                                                                    If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(poi3, poj3), xd6) Then
                                                                        number3 = True

                                                                    End If
                                                                End If
                                                            Next
                                                        Next

                                                        For poi4 = posi2 - 2 To (posi2 + 2)
                                                            For poj4 = posj2 - 2 To (posj2 + 2)
                                                                If smallx And smally Then
                                                                    If Color_Is_In_The_Target_Variations(Variation, b.GetPixel(poi4, poj4), xd7) Then
                                                                        number4 = True


                                                                    End If
                                                                End If
                                                            Next
                                                        Next

                                                        If number1 = True Then
                                                            number = number + 1

                                                        End If

                                                        If number2 = True Then
                                                            number = number + 1

                                                        End If

                                                        If number3 = True Then
                                                            number = number + 1

                                                        End If

                                                        If number4 = True Then
                                                            number = number + 1
                                                        End If

                                                    Catch
                                                        GoTo Nexx
                                                    End Try
                                                End If


                                                If number >= Precise Then
                                                    pixels.Add(New PixelInfo With {.Location = New Point(posi - (markersizex / 2), posj - (markersizey / 2)),
                                                                           .CreatedTime = Date.Now,
                                                                           .Colour = Pixelcolor})

                                                    'Repaint the drawing surface

                                                    If audiolol = False And Alarm = True Then
                                                        Audio2()
                                                        audiolol = True
                                                    End If

                                                    If Multitarget = False Then
                                                        GoTo Nexx
                                                    End If

                                                End If
                                                Canvas.Invalidate()
                                            End If
                                        End If
                                    End If
prenex:

                                Next
                            End If

                        Next

Nexx:
                    End Using

                End Using
            End If

        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Valorant Then
            Form4.Show()
        Else
            Form3.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class

Public Class PixelInfo

    'The location of the pixel.
    Public Property Location As Point

    'The time the pixel was created. used to determine when to fade.
    Public Property CreatedTime As Date

    'The colour of the pixel.
    Public Property Colour As Color

End Class
