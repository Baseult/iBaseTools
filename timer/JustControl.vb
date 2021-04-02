Public Class JustControl
    Inherits Panel

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
    End Sub

    Private _ShowLine As Boolean = True
    Public Property ShowLine As Boolean
        Get
            Return _ShowLine
        End Get
        Set(value As Boolean)
            _ShowLine = value : Invalidate()
        End Set
    End Property

    Private _ColorLine As Color = Color.Red
    Public Property ColorLine As Color
        Get
            Return _ColorLine
        End Get
        Set(value As Color)
            _ColorLine = value : Invalidate()
        End Set
    End Property

    Private _Image As Image = Nothing
    Public Property Image As Image
        Get
            Return _Image
        End Get
        Set(value As Image)
            _Image = value : Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)
            Dim myPen As New Pen(Color.Red, 2) 'to set width of pen
            G.Clear(BackColor)
            If _Image IsNot Nothing Then
                G.DrawImage(_Image, -50, -50, Width + 100, Height + 100)
            End If
            If _ShowLine = True Then
                G.DrawLine(New Pen(_ColorLine, 1), CInt(Width / 2), 0, CInt(Width / 2), Height)
                G.DrawLine(New Pen(_ColorLine, 1), 0, CInt(Height / 2), Width, CInt(Height / 2))
            End If
            e.Graphics.DrawImage(B, 0, 0) : B.Dispose()
            G.Dispose()
        End Using
        MyBase.OnPaint(e)
    End Sub

End Class
