Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            _memoryStream?.Dispose()
            _memoryStream = Nothing

            _fileStream?.Dispose()
            _fileStream = Nothing

            MediaPlayer1?.Dispose()
            MediaPlayer1 = Nothing
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.rbAudioFile = New System.Windows.Forms.RadioButton()
        Me.rbVideoWithoutAudio = New System.Windows.Forms.RadioButton()
        Me.rbVideoWithAudio = New System.Windows.Forms.RadioButton()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tbBalance1 = New System.Windows.Forms.TrackBar()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tbVolume1 = New System.Windows.Forms.TrackBar()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbLicensing = New System.Windows.Forms.CheckBox()
        Me.mmError = New System.Windows.Forms.TextBox()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbLoop = New System.Windows.Forms.CheckBox()
        Me.btNextFrame = New System.Windows.Forms.Button()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.label16 = New System.Windows.Forms.Label()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.tbTimeline = New System.Windows.Forms.TrackBar()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btSelectFile = New System.Windows.Forms.Button()
        Me.edFilename = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbStreamTypeMemory = New System.Windows.Forms.RadioButton()
        Me.rbSTreamTypeFile = New System.Windows.Forms.RadioButton()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        Me.groupBox4.SuspendLayout()
        CType(Me.tbBalance1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVolume1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTimeline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbAudioFile
        '
        Me.rbAudioFile.AutoSize = True
        Me.rbAudioFile.Location = New System.Drawing.Point(286, 58)
        Me.rbAudioFile.Name = "rbAudioFile"
        Me.rbAudioFile.Size = New System.Drawing.Size(68, 17)
        Me.rbAudioFile.TabIndex = 57
        Me.rbAudioFile.Text = "Audio file"
        Me.rbAudioFile.UseVisualStyleBackColor = True
        '
        'rbVideoWithoutAudio
        '
        Me.rbVideoWithoutAudio.AutoSize = True
        Me.rbVideoWithoutAudio.Location = New System.Drawing.Point(140, 58)
        Me.rbVideoWithoutAudio.Name = "rbVideoWithoutAudio"
        Me.rbVideoWithoutAudio.Size = New System.Drawing.Size(140, 17)
        Me.rbVideoWithoutAudio.TabIndex = 56
        Me.rbVideoWithoutAudio.Text = "Video file (without audio)"
        Me.rbVideoWithoutAudio.UseVisualStyleBackColor = True
        '
        'rbVideoWithAudio
        '
        Me.rbVideoWithAudio.AutoSize = True
        Me.rbVideoWithAudio.Checked = True
        Me.rbVideoWithAudio.Location = New System.Drawing.Point(12, 58)
        Me.rbVideoWithAudio.Name = "rbVideoWithAudio"
        Me.rbVideoWithAudio.Size = New System.Drawing.Size(125, 17)
        Me.rbVideoWithAudio.TabIndex = 55
        Me.rbVideoWithAudio.TabStop = True
        Me.rbVideoWithAudio.Text = "Video file (with audio)"
        Me.rbVideoWithAudio.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox4.Controls.Add(Me.label7)
        Me.groupBox4.Controls.Add(Me.tbBalance1)
        Me.groupBox4.Controls.Add(Me.label6)
        Me.groupBox4.Controls.Add(Me.tbVolume1)
        Me.groupBox4.Location = New System.Drawing.Point(434, 148)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(221, 107)
        Me.groupBox4.TabIndex = 53
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Audio output"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(109, 28)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(46, 13)
        Me.label7.TabIndex = 11
        Me.label7.Text = "Balance"
        '
        'tbBalance1
        '
        Me.tbBalance1.BackColor = System.Drawing.SystemColors.Window
        Me.tbBalance1.Location = New System.Drawing.Point(112, 44)
        Me.tbBalance1.Maximum = 100
        Me.tbBalance1.Minimum = -100
        Me.tbBalance1.Name = "tbBalance1"
        Me.tbBalance1.Size = New System.Drawing.Size(85, 45)
        Me.tbBalance1.TabIndex = 10
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(16, 28)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(42, 13)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Volume"
        '
        'tbVolume1
        '
        Me.tbVolume1.BackColor = System.Drawing.SystemColors.Window
        Me.tbVolume1.Location = New System.Drawing.Point(19, 44)
        Me.tbVolume1.Maximum = 100
        Me.tbVolume1.Minimum = 20
        Me.tbVolume1.Name = "tbVolume1"
        Me.tbVolume1.Size = New System.Drawing.Size(85, 45)
        Me.tbVolume1.TabIndex = 8
        Me.tbVolume1.Value = 80
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.cbLicensing)
        Me.groupBox1.Controls.Add(Me.mmError)
        Me.groupBox1.Controls.Add(Me.cbDebugMode)
        Me.groupBox1.Location = New System.Drawing.Point(434, 16)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(221, 126)
        Me.groupBox1.TabIndex = 52
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Errors and warnings"
        '
        'cbLicensing
        '
        Me.cbLicensing.AutoSize = True
        Me.cbLicensing.Location = New System.Drawing.Point(106, 19)
        Me.cbLicensing.Name = "cbLicensing"
        Me.cbLicensing.Size = New System.Drawing.Size(91, 17)
        Me.cbLicensing.TabIndex = 4
        Me.cbLicensing.Text = "Licensing info"
        Me.cbLicensing.UseVisualStyleBackColor = True
        '
        'mmError
        '
        Me.mmError.Location = New System.Drawing.Point(6, 42)
        Me.mmError.Multiline = True
        Me.mmError.Name = "mmError"
        Me.mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.mmError.Size = New System.Drawing.Size(209, 78)
        Me.mmError.TabIndex = 3
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(6, 19)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 2
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(83, 515)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(244, 13)
        Me.label1.TabIndex = 51
        Me.label1.Text = "Much more features are shown in Main Demo!"
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.cbLoop)
        Me.groupBox2.Controls.Add(Me.btNextFrame)
        Me.groupBox2.Controls.Add(Me.btStop)
        Me.groupBox2.Controls.Add(Me.btPause)
        Me.groupBox2.Controls.Add(Me.btResume)
        Me.groupBox2.Controls.Add(Me.btStart)
        Me.groupBox2.Controls.Add(Me.tbSpeed)
        Me.groupBox2.Controls.Add(Me.label16)
        Me.groupBox2.Controls.Add(Me.lbTime)
        Me.groupBox2.Controls.Add(Me.tbTimeline)
        Me.groupBox2.Location = New System.Drawing.Point(12, 408)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(416, 90)
        Me.groupBox2.TabIndex = 50
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Controls"
        '
        'cbLoop
        '
        Me.cbLoop.AutoSize = True
        Me.cbLoop.Location = New System.Drawing.Point(337, 62)
        Me.cbLoop.Name = "cbLoop"
        Me.cbLoop.Size = New System.Drawing.Size(50, 17)
        Me.cbLoop.TabIndex = 10
        Me.cbLoop.Text = "Loop"
        Me.cbLoop.UseVisualStyleBackColor = True
        '
        'btNextFrame
        '
        Me.btNextFrame.Location = New System.Drawing.Point(249, 58)
        Me.btNextFrame.Name = "btNextFrame"
        Me.btNextFrame.Size = New System.Drawing.Size(75, 23)
        Me.btNextFrame.TabIndex = 8
        Me.btNextFrame.Text = "Next frame"
        Me.btNextFrame.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(180, 58)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(46, 23)
        Me.btStop.TabIndex = 7
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Location = New System.Drawing.Point(122, 58)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(52, 23)
        Me.btPause.TabIndex = 6
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'btResume
        '
        Me.btResume.Location = New System.Drawing.Point(55, 58)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(61, 23)
        Me.btResume.TabIndex = 5
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(6, 58)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(43, 23)
        Me.btStart.TabIndex = 4
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(321, 27)
        Me.tbSpeed.Maximum = 25
        Me.tbSpeed.Minimum = 5
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(89, 45)
        Me.tbSpeed.TabIndex = 3
        Me.tbSpeed.Value = 10
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(322, 11)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(38, 13)
        Me.label16.TabIndex = 2
        Me.label16.Text = "Speed"
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Location = New System.Drawing.Point(219, 27)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(96, 13)
        Me.lbTime.TabIndex = 1
        Me.lbTime.Text = "00:00:00/00:00:00"
        '
        'tbTimeline
        '
        Me.tbTimeline.Location = New System.Drawing.Point(6, 19)
        Me.tbTimeline.Maximum = 100
        Me.tbTimeline.Name = "tbTimeline"
        Me.tbTimeline.Size = New System.Drawing.Size(207, 45)
        Me.tbTimeline.TabIndex = 0
        '
        'linkLabel1
        '
        Me.linkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(318, 10)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(110, 13)
        Me.linkLabel1.TabIndex = 49
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Watch video tutorials!"
        '
        'btSelectFile
        '
        Me.btSelectFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSelectFile.Location = New System.Drawing.Point(405, 27)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(23, 23)
        Me.btSelectFile.TabIndex = 48
        Me.btSelectFile.Text = "..."
        Me.btSelectFile.UseVisualStyleBackColor = True
        '
        'edFilename
        '
        Me.edFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edFilename.Location = New System.Drawing.Point(12, 29)
        Me.edFilename.Name = "edFilename"
        Me.edFilename.Size = New System.Drawing.Size(387, 20)
        Me.edFilename.TabIndex = 47
        Me.edFilename.Text = "C:\video.avi"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(9, 13)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(52, 13)
        Me.label14.TabIndex = 46
        Me.label14.Text = "File name"
        '
        'timer1
        '
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.rbStreamTypeMemory)
        Me.groupBox3.Controls.Add(Me.rbSTreamTypeFile)
        Me.groupBox3.Location = New System.Drawing.Point(440, 260)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.groupBox3.Size = New System.Drawing.Size(207, 81)
        Me.groupBox3.TabIndex = 59
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Stream type"
        '
        'rbStreamTypeMemory
        '
        Me.rbStreamTypeMemory.AutoSize = True
        Me.rbStreamTypeMemory.Location = New System.Drawing.Point(12, 49)
        Me.rbStreamTypeMemory.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStreamTypeMemory.Name = "rbStreamTypeMemory"
        Me.rbStreamTypeMemory.Size = New System.Drawing.Size(153, 17)
        Me.rbStreamTypeMemory.TabIndex = 1
        Me.rbStreamTypeMemory.Text = "Load entire file into memory"
        Me.rbStreamTypeMemory.UseVisualStyleBackColor = True
        '
        'rbSTreamTypeFile
        '
        Me.rbSTreamTypeFile.AutoSize = True
        Me.rbSTreamTypeFile.Checked = True
        Me.rbSTreamTypeFile.Location = New System.Drawing.Point(12, 21)
        Me.rbSTreamTypeFile.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSTreamTypeFile.Name = "rbSTreamTypeFile"
        Me.rbSTreamTypeFile.Size = New System.Drawing.Size(94, 17)
        Me.rbSTreamTypeFile.TabIndex = 0
        Me.rbSTreamTypeFile.TabStop = True
        Me.rbSTreamTypeFile.Text = "Use file stream"
        Me.rbSTreamTypeFile.UseVisualStyleBackColor = True
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(12, 81)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(416, 321)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 60
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 535)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.rbAudioFile)
        Me.Controls.Add(Me.rbVideoWithoutAudio)
        Me.Controls.Add(Me.rbVideoWithAudio)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.btSelectFile)
        Me.Controls.Add(Me.edFilename)
        Me.Controls.Add(Me.label14)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Media Player SDK .Net - Memory Playback Demo"
        Me.groupBox4.ResumeLayout(false)
        Me.groupBox4.PerformLayout
        CType(Me.tbBalance1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbVolume1,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.groupBox2.ResumeLayout(false)
        Me.groupBox2.PerformLayout
        CType(Me.tbSpeed,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbTimeline,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox3.ResumeLayout(false)
        Me.groupBox3.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents rbAudioFile As System.Windows.Forms.RadioButton
    Private WithEvents rbVideoWithoutAudio As System.Windows.Forms.RadioButton
    Private WithEvents rbVideoWithAudio As System.Windows.Forms.RadioButton
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tbBalance1 As System.Windows.Forms.TrackBar
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tbVolume1 As System.Windows.Forms.TrackBar
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents mmError As System.Windows.Forms.TextBox
    Private WithEvents cbDebugMode As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents cbLoop As System.Windows.Forms.CheckBox
    Private WithEvents btNextFrame As System.Windows.Forms.Button
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btPause As System.Windows.Forms.Button
    Private WithEvents btResume As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents tbSpeed As System.Windows.Forms.TrackBar
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents lbTime As System.Windows.Forms.Label
    Private WithEvents tbTimeline As System.Windows.Forms.TrackBar
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents btSelectFile As System.Windows.Forms.Button
    Private WithEvents edFilename As System.Windows.Forms.TextBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents cbLicensing As CheckBox
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents rbStreamTypeMemory As RadioButton
    Private WithEvents rbSTreamTypeFile As RadioButton
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
