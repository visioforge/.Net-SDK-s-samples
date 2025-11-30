<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If

        VideoCapture1?.Dispose()
        VideoCapture1 = Nothing

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label11 = New System.Windows.Forms.Label()
        Me.cbVideoInputDevice = New System.Windows.Forms.ComboBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.cbVideoInputFormat = New System.Windows.Forms.ComboBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.cbVideoInputFrameRate = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btStart = New System.Windows.Forms.Button()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btSnapshot = New System.Windows.Forms.Button()
        Me.pbSnapshot = New System.Windows.Forms.PictureBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        CType(Me.pbSnapshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(12, 15)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(138, 20)
        Me.label11.TabIndex = 0
        Me.label11.Text = "Video input device"
        '
        'cbVideoInputDevice
        '
        Me.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputDevice.FormattingEnabled = True
        Me.cbVideoInputDevice.Location = New System.Drawing.Point(12, 38)
        Me.cbVideoInputDevice.Name = "cbVideoInputDevice"
        Me.cbVideoInputDevice.Size = New System.Drawing.Size(300, 28)
        Me.cbVideoInputDevice.TabIndex = 1
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(12, 75)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(139, 20)
        Me.label13.TabIndex = 2
        Me.label13.Text = "Video input format"
        '
        'cbVideoInputFormat
        '
        Me.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFormat.FormattingEnabled = True
        Me.cbVideoInputFormat.Location = New System.Drawing.Point(12, 98)
        Me.cbVideoInputFormat.Name = "cbVideoInputFormat"
        Me.cbVideoInputFormat.Size = New System.Drawing.Size(300, 28)
        Me.cbVideoInputFormat.TabIndex = 3
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(318, 75)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(87, 20)
        Me.label18.TabIndex = 4
        Me.label18.Text = "Frame rate"
        '
        'cbVideoInputFrameRate
        '
        Me.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFrameRate.FormattingEnabled = True
        Me.cbVideoInputFrameRate.Location = New System.Drawing.Point(318, 98)
        Me.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate"
        Me.cbVideoInputFrameRate.Size = New System.Drawing.Size(80, 28)
        Me.cbVideoInputFrameRate.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(404, 101)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(31, 20)
        Me.label1.TabIndex = 6
        Me.label1.Text = "fps"
        '
        'btStart
        '
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(12, 140)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(100, 35)
        Me.btStart.TabIndex = 7
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(118, 140)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(100, 35)
        Me.btStop.TabIndex = 8
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btSnapshot
        '
        Me.btSnapshot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSnapshot.Location = New System.Drawing.Point(274, 140)
        Me.btSnapshot.Name = "btSnapshot"
        Me.btSnapshot.Size = New System.Drawing.Size(140, 35)
        Me.btSnapshot.TabIndex = 9
        Me.btSnapshot.Text = "Take Snapshot"
        Me.btSnapshot.UseVisualStyleBackColor = True
        '
        'pbSnapshot
        '
        Me.pbSnapshot.BackColor = System.Drawing.Color.Black
        Me.pbSnapshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSnapshot.Location = New System.Drawing.Point(460, 208)
        Me.pbSnapshot.Name = "pbSnapshot"
        Me.pbSnapshot.Size = New System.Drawing.Size(400, 300)
        Me.pbSnapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSnapshot.TabIndex = 10
        Me.pbSnapshot.TabStop = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 185)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(108, 20)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Video Preview"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(456, 185)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(75, 20)
        Me.label3.TabIndex = 12
        Me.label3.Text = "Snapshot"
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(12, 208)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(440, 300)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 13
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(872, 524)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.pbSnapshot)
        Me.Controls.Add(Me.btSnapshot)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cbVideoInputFrameRate)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.cbVideoInputFormat)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.cbVideoInputDevice)
        Me.Controls.Add(Me.label11)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Snapshot Sample - Video Capture SDK .Net"
        CType(Me.pbSnapshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents cbVideoInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents cbVideoInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbVideoInputFrameRate As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btSnapshot As System.Windows.Forms.Button
    Private WithEvents pbSnapshot As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
