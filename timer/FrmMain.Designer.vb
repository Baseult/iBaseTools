<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LVCores = New System.Windows.Forms.ListView()
        Me.GList = New System.Windows.Forms.ImageList(Me.components)
        Me.TM = New System.Windows.Forms.Timer(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.JColor1 = New JustControl()
        Me.JColor2 = New JustControl()
        Me.Button12 = New System.Windows.Forms.Button()
        ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        ColumnHeader1.Width = 205
        '
        'LVCores
        '
        Me.LVCores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader1})
        Me.LVCores.ForeColor = System.Drawing.Color.Black
        Me.LVCores.FullRowSelect = True
        Me.LVCores.GridLines = True
        Me.LVCores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LVCores.HideSelection = False
        Me.LVCores.Location = New System.Drawing.Point(9, 234)
        Me.LVCores.Name = "LVCores"
        Me.LVCores.Size = New System.Drawing.Size(313, 33)
        Me.LVCores.SmallImageList = Me.GList
        Me.LVCores.TabIndex = 1
        Me.LVCores.UseCompatibleStateImageBehavior = False
        Me.LVCores.View = System.Windows.Forms.View.Details
        '
        'GList
        '
        Me.GList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.GList.ImageSize = New System.Drawing.Size(16, 16)
        Me.GList.TransparentColor = System.Drawing.Color.Transparent
        '
        'TM
        '
        Me.TM.Enabled = True
        Me.TM.Interval = 20
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Location = New System.Drawing.Point(202, 273)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "GetColor:  Press X"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(7, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 92)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Location = New System.Drawing.Point(120, 207)
        Me.TrackBar1.Maximum = 20
        Me.TrackBar1.Minimum = 1
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(202, 21)
        Me.TrackBar1.TabIndex = 13
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar1.Value = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Pixel Distance: 5"
        '
        'JColor1
        '
        Me.JColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JColor1.ColorLine = System.Drawing.Color.Red
        Me.JColor1.Image = Nothing
        Me.JColor1.Location = New System.Drawing.Point(10, 12)
        Me.JColor1.Name = "JColor1"
        Me.JColor1.ShowLine = False
        Me.JColor1.Size = New System.Drawing.Size(152, 96)
        Me.JColor1.TabIndex = 7
        '
        'JColor2
        '
        Me.JColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JColor2.ColorLine = System.Drawing.Color.Red
        Me.JColor2.Image = Nothing
        Me.JColor2.Location = New System.Drawing.Point(168, 12)
        Me.JColor2.Name = "JColor2"
        Me.JColor2.ShowLine = True
        Me.JColor2.Size = New System.Drawing.Size(154, 95)
        Me.JColor2.TabIndex = 6
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Yellow
        Me.Button12.Location = New System.Drawing.Point(9, 209)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(15, 15)
        Me.Button12.TabIndex = 54
        Me.Button12.Text = "I"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(334, 310)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.JColor1)
        Me.Controls.Add(Me.JColor2)
        Me.Controls.Add(Me.LVCores)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose a Color to track"
        Me.TopMost = True
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LVCores As System.Windows.Forms.ListView
    Friend WithEvents TM As System.Windows.Forms.Timer
    Friend WithEvents GList As System.Windows.Forms.ImageList
    Friend WithEvents JColor2 As JustControl
    Friend WithEvents JColor1 As JustControl
    Friend WithEvents btnOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Button12 As Button
End Class
