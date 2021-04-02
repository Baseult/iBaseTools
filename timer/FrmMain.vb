Imports System.Drawing.Imaging
Imports System.Threading
Imports System.IO
Imports System.Timers

Public Class FrmMain

    Sub New()
        InitializeComponent()
    End Sub

    Private Sub TM_Tick(sender As Object, e As EventArgs) Handles TM.Tick


        Dim NewBitmap As New Bitmap(50, 50)
        Dim G As Graphics = Graphics.FromImage(NewBitmap)
        Dim MyMouse As New Point(Control.MousePosition.X - 25, Control.MousePosition.Y - 25)
        G.CopyFromScreen(MyMouse, New Point(0, 0), New Size(50, 50))
        Dim MyPixel As Color = NewBitmap.GetPixel(25, 25)
        Dim MyPixel2 As Color = NewBitmap.GetPixel(25 + pixeldistance, 25 + pixeldistance)
        Dim MyPixel3 As Color = NewBitmap.GetPixel(25 - pixeldistance, 25 + pixeldistance)
        Dim MyPixel4 As Color = NewBitmap.GetPixel(25 + pixeldistance, 25 - pixeldistance)
        Dim MyPixel5 As Color = NewBitmap.GetPixel(25 - pixeldistance, 25 - pixeldistance)
        JColor1.BackColor = MyPixel

        JColor2.Image = NewBitmap
        If LVCores.Items.Count = 0 Then
            GoTo POO
        End If
        If Not LVCores.Items(LVCores.Items.Count - 1).Tag = MyPixel Then
POO:

            If GetAsyncKeyState(Keys.X) Then

                iBaseTools.Show()
                iBaseTools.Pixeldistance = pixeldistance
                iBaseTools.Colorx = MyPixel
                iBaseTools.Colorx2 = MyPixel2
                iBaseTools.Colorx3 = MyPixel3
                iBaseTools.Colorx4 = MyPixel4
                iBaseTools.Colorx5 = MyPixel5
                iBaseTools.Execute()

                Using MyBackColor As New Bitmap(16, 16)
                    Dim GG As Graphics = Graphics.FromImage(MyBackColor) : GG.FillRectangle(New SolidBrush(JColor1.BackColor), 0, 0, 16, 16) : GList.Images.Add(MyBackColor)
                End Using
                Dim NewItem As New ListViewItem
                NewItem.Text = MyPixel.R & ", " & MyPixel.G & ", " & MyPixel.B
                NewItem.Tag = MyPixel
                NewItem.ImageIndex = GList.Images.Count - 1
                LVCores.Items.Add(NewItem).EnsureVisible()
            End If
        End If


    End Sub

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Integer

    Private Sub LVCores_DoubleClick(sender As Object, e As EventArgs) Handles LVCores.DoubleClick
        Clipboard.SetText(LVCores.SelectedItems(0).Text)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If iBaseTools.Saveme2 Then
            Me.Close()
            iBaseTools.Saveme2 = False
            Try
                iBaseTools.myTimer.Change(0, iBaseTools.Delay)
                iBaseTools.Canvas.Show()
            Catch
            End Try
        Else
            Form3.Show()
            Me.Close()
            Try
                iBaseTools.myTimer.Change(0, iBaseTools.Delay)
                iBaseTools.Canvas.Show()
            Catch
            End Try
        End If

    End Sub

    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            iBaseTools.myTimer.Change(Timeout.Infinite, Timeout.Infinite)
            iBaseTools.Canvas.Hide()
        Catch
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pixeldistance = TrackBar1.Value
    End Sub

    Dim pixeldistance As Integer

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label3.Text = "Pixel Distance: " & TrackBar1.Value.ToString
        pixeldistance = TrackBar1.Value
    End Sub

    Private Sub JColor2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        MessageBox.Show("Default is 5. If you have a small screen (less than 1920 x 1080) use something from 2-5. If you have a 4K Screen you can use something between 5 and 10. This sets the Distance between the Center Pixel and the 4 other pixels that it will scan and detect. As explanation, If you set 'Precision' to something more than 5 it will search for more than 1 Pixels (maxmium 5 pixels). These pixels are selected around the main pixel means it picks 4 other pixels in a square around the middle main pixel that you want to search for. You can set the Pixeldistance here how much the pixeldistance between the Main Pixel and the other 4 Pixels should be. If you still don't understand this (I know its complicated) just leave it at 5 that should work too.")
    End Sub
End Class
