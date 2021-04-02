Imports System.Drawing.Imaging
Imports System.Threading

Public Class Bomb
    Private Sub Bomb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If iBaseTools.Bombfinder = False Then

            Timer1.Enabled = True
            Timer1.Start()

            If iBaseTools.Bombtimer Or iBaseTools.Bombtimer2 Then
                Label1.Show()
                Label2.Show()
            Else
                Label1.Hide()
                Label2.Hide()
            End If
        End If

        Bombcoordinatesx = My.Settings.Bombcoordinatesx1
        Bombcoordinatesy = My.Settings.Bombcoordinatesy1

        If iBaseTools.Valorant And iBaseTools.Alarmsound Then
            alarmsound = True
        End If

        If iBaseTools.Valorant = False And iBaseTools.Alarmsound2 Then
            alarmsound = True
        End If

        valorant = iBaseTools.Valorant

        If valorant Then
            explode = 45
            defuse = 7
            bombvariation = 0

        Else
            explode = iBaseTools.Bombexplodetime
            defuse = iBaseTools.Bombdefusetimes
            bombvariation = iBaseTools.Bombvariation
        End If

        explode2 = Convert.ToDouble(explode)

        Console.WriteLine(explode2)
        xd2 = iBaseTools.Bombcolor
        CountDown = TimeSpan.FromSeconds(explode2)

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
    Dim explode2 As Double
    Dim xd2 As Color
    Dim alarmsound As Boolean
    Dim search As Boolean = True
    Dim bomb As Boolean = False
    Dim playaudio As Boolean = False
    Dim changes As Boolean = False
    Dim valorant As Boolean
    Dim explode As Integer
    Dim defuse As Integer
    Dim bombvariation As Integer

    Public Bombcoordinatesx As Integer
    Public Bombcoordinatesy As Integer

    Private Shared Sub Audio()
        My.Computer.Audio.Play(My.Resources.txt, AudioPlayMode.Background)
    End Sub

    Dim xd As Color = Color.FromArgb(255, 170, 0, 0)
    Dim xd1 As Color = Color.FromArgb(255, 169, 0, 0)

    Dim Stpw As New Stopwatch
    Dim CountDown As TimeSpan
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If search Then
            Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Using screenGrab As New Bitmap(1, 1, PixelFormat.Format32bppArgb)
                Graphics.FromImage(screenGrab).CopyFromScreen(Bombcoordinatesx, Bombcoordinatesy, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)

                If valorant = False Then
                    If Color_Is_In_The_Target_Variations(bombvariation, screenGrab.GetPixel(0, 0), xd2) Then
                        search = False
                        Stpw.Start()
                        bomb = True
                    End If
                Else
                    If screenGrab.GetPixel(0, 0).Equals(xd) Or screenGrab.GetPixel(0, 0).Equals(xd1) Or screenGrab.GetPixel(0, 0).Equals(xd2) Then
                        search = False
                        Stpw.Start()
                        bomb = True
                    End If
                End If

            End Using
        End If

        If bomb Then
            Try
                iBaseTools.Canvas.Hide()
                iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            Catch
            End Try

            If Stpw.Elapsed >= CountDown Then
                Stpw.Stop()
                Stpw.Reset()
                search = True
                playaudio = False
                changes = False
                Label1.ForeColor = Color.Chartreuse
                Label2.ForeColor = Color.Chartreuse
                Label1.Text = "Waiting.."
                Label2.Text = ""
                bomb = False
                Try
                    iBaseTools.Canvas.Show()
                    iBaseTools.myTimer.Change(0, iBaseTools.Delay)
                Catch
                End Try

            Else
                Dim ToGo As TimeSpan = CountDown - Stpw.Elapsed
                Me.Label1.Text = "Explodes in " & ToGo.ToString("ss\,f")
                Me.Label2.Text = "Defuse in " & ToGo.TotalSeconds - defuse + 0.1

                If ToGo.TotalSeconds <= defuse + 3 And ToGo.TotalSeconds >= defuse Then
                    If playaudio = False Then
                        If alarmsound Then
                            Audio()
                        End If
                        playaudio = True
                        Label1.ForeColor = Color.Yellow
                        Label2.ForeColor = Color.Yellow
                    End If
                ElseIf ToGo.TotalSeconds <= defuse And ToGo.TotalSeconds >= 0 Then
                    If changes = False Then
                        Label1.ForeColor = Color.Red
                        Label2.ForeColor = Color.Red
                        changes = True
                    End If
                End If

                Select Case ToGo.TotalSeconds

                End Select
            End If
        End If
    End Sub

    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property

    Private Sub Bomb_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If iBaseTools.Bombfinder = False Then

            Timer1.Enabled = True
            Timer1.Start()

            If iBaseTools.Bombtimer Or iBaseTools.Bombtimer2 Then
                Label1.Show()
                Label2.Show()
            Else
                Label1.Hide()
                Label2.Hide()
            End If
        End If

        Bombcoordinatesx = My.Settings.Bombcoordinatesx1
        Bombcoordinatesy = My.Settings.Bombcoordinatesy1

        If iBaseTools.Valorant And iBaseTools.Alarmsound Then
            alarmsound = True
        End If

        If iBaseTools.Valorant = False And iBaseTools.Alarmsound2 Then
            alarmsound = True
        End If

        valorant = iBaseTools.Valorant

        If valorant Then
            explode = 45
            defuse = 7
        Else
            explode = iBaseTools.Bombexplodetime
            defuse = iBaseTools.Bombdefusetimes
        End If

        explode = iBaseTools.Bombexplodetime
        explode2 = Convert.ToDouble(explode)

        defuse = iBaseTools.Bombdefusetimes
        xd2 = iBaseTools.Bombcolor
        CountDown = TimeSpan.FromSeconds(explode2)
    End Sub
End Class