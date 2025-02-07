<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        groupBox4 = New GroupBox()
        label6 = New Label()
        groupBox1 = New GroupBox()
        cbLicensing = New CheckBox()
        edLog = New TextBox()
        cbDebugMode = New CheckBox()
        label1 = New Label()
        groupBox2 = New GroupBox()
        btStop = New Button()
        btPause = New Button()
        btResume = New Button()
        btStart = New Button()
        tbSpeed = New TrackBar()
        label16 = New Label()
        lbTime = New Label()
        tbTimeline = New TrackBar()
        btSelectFile = New Button()
        edFilename = New TextBox()
        label14 = New Label()
        VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        tbVolume1 = New TrackBar()
        cbAudioOutput = New ComboBox()
        groupBox4.SuspendLayout()
        groupBox1.SuspendLayout()
        groupBox2.SuspendLayout()
        CType(tbSpeed, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbTimeline, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbVolume1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' groupBox4
        ' 
        groupBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        groupBox4.Controls.Add(cbAudioOutput)
        groupBox4.Controls.Add(label6)
        groupBox4.Controls.Add(tbVolume1)
        groupBox4.Location = New Point(719, 288)
        groupBox4.Margin = New Padding(5, 6, 5, 6)
        groupBox4.Name = "groupBox4"
        groupBox4.Padding = New Padding(5, 6, 5, 6)
        groupBox4.Size = New Size(368, 198)
        groupBox4.TabIndex = 59
        groupBox4.TabStop = False
        groupBox4.Text = "Audio output"
        ' 
        ' label6
        ' 
        label6.AutoSize = True
        label6.Location = New Point(13, 105)
        label6.Margin = New Padding(5, 0, 5, 0)
        label6.Name = "label6"
        label6.Size = New Size(72, 25)
        label6.TabIndex = 9
        label6.Text = "Volume"
        ' 
        ' groupBox1
        ' 
        groupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        groupBox1.Controls.Add(cbLicensing)
        groupBox1.Controls.Add(edLog)
        groupBox1.Controls.Add(cbDebugMode)
        groupBox1.Location = New Point(719, 34)
        groupBox1.Margin = New Padding(5, 6, 5, 6)
        groupBox1.Name = "groupBox1"
        groupBox1.Padding = New Padding(5, 6, 5, 6)
        groupBox1.Size = New Size(368, 242)
        groupBox1.TabIndex = 58
        groupBox1.TabStop = False
        groupBox1.Text = "Errors and warnings"
        ' 
        ' cbLicensing
        ' 
        cbLicensing.AutoSize = True
        cbLicensing.Location = New Point(167, 40)
        cbLicensing.Margin = New Padding(5, 6, 5, 6)
        cbLicensing.Name = "cbLicensing"
        cbLicensing.Size = New Size(146, 29)
        cbLicensing.TabIndex = 4
        cbLicensing.Text = "Licensing info"
        cbLicensing.UseVisualStyleBackColor = True
        ' 
        ' edLog
        ' 
        edLog.Location = New Point(10, 81)
        edLog.Margin = New Padding(5, 6, 5, 6)
        edLog.Multiline = True
        edLog.Name = "edLog"
        edLog.ScrollBars = ScrollBars.Both
        edLog.Size = New Size(346, 146)
        edLog.TabIndex = 3
        ' 
        ' cbDebugMode
        ' 
        cbDebugMode.AutoSize = True
        cbDebugMode.Location = New Point(12, 40)
        cbDebugMode.Margin = New Padding(5, 6, 5, 6)
        cbDebugMode.Name = "cbDebugMode"
        cbDebugMode.Size = New Size(144, 29)
        cbDebugMode.TabIndex = 2
        cbDebugMode.Text = "Debug mode"
        cbDebugMode.UseVisualStyleBackColor = True
        ' 
        ' label1
        ' 
        label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        label1.AutoSize = True
        label1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold)
        label1.Location = New Point(134, 920)
        label1.Margin = New Padding(5, 0, 5, 0)
        label1.Name = "label1"
        label1.Size = New Size(397, 20)
        label1.TabIndex = 57
        label1.Text = "Much more features are shown in Main Demo!"
        ' 
        ' groupBox2
        ' 
        groupBox2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        groupBox2.Controls.Add(btStop)
        groupBox2.Controls.Add(btPause)
        groupBox2.Controls.Add(btResume)
        groupBox2.Controls.Add(btStart)
        groupBox2.Controls.Add(tbSpeed)
        groupBox2.Controls.Add(label16)
        groupBox2.Controls.Add(lbTime)
        groupBox2.Controls.Add(tbTimeline)
        groupBox2.Location = New Point(16, 715)
        groupBox2.Margin = New Padding(5, 6, 5, 6)
        groupBox2.Name = "groupBox2"
        groupBox2.Padding = New Padding(5, 6, 5, 6)
        groupBox2.Size = New Size(693, 173)
        groupBox2.TabIndex = 56
        groupBox2.TabStop = False
        groupBox2.Text = "Controls"
        ' 
        ' btStop
        ' 
        btStop.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold)
        btStop.Location = New Point(300, 112)
        btStop.Margin = New Padding(5, 6, 5, 6)
        btStop.Name = "btStop"
        btStop.Size = New Size(77, 44)
        btStop.TabIndex = 7
        btStop.Text = "Stop"
        btStop.UseVisualStyleBackColor = True
        ' 
        ' btPause
        ' 
        btPause.Location = New Point(203, 112)
        btPause.Margin = New Padding(5, 6, 5, 6)
        btPause.Name = "btPause"
        btPause.Size = New Size(87, 44)
        btPause.TabIndex = 6
        btPause.Text = "Pause"
        btPause.UseVisualStyleBackColor = True
        ' 
        ' btResume
        ' 
        btResume.Location = New Point(92, 112)
        btResume.Margin = New Padding(5, 6, 5, 6)
        btResume.Name = "btResume"
        btResume.Size = New Size(102, 44)
        btResume.TabIndex = 5
        btResume.Text = "Resume"
        btResume.UseVisualStyleBackColor = True
        ' 
        ' btStart
        ' 
        btStart.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold)
        btStart.Location = New Point(10, 112)
        btStart.Margin = New Padding(5, 6, 5, 6)
        btStart.Name = "btStart"
        btStart.Size = New Size(72, 44)
        btStart.TabIndex = 4
        btStart.Text = "Start"
        btStart.UseVisualStyleBackColor = True
        ' 
        ' tbSpeed
        ' 
        tbSpeed.Location = New Point(535, 52)
        tbSpeed.Margin = New Padding(5, 6, 5, 6)
        tbSpeed.Maximum = 25
        tbSpeed.Minimum = 5
        tbSpeed.Name = "tbSpeed"
        tbSpeed.Size = New Size(148, 69)
        tbSpeed.TabIndex = 3
        tbSpeed.Value = 10
        ' 
        ' label16
        ' 
        label16.AutoSize = True
        label16.Location = New Point(539, 24)
        label16.Margin = New Padding(5, 0, 5, 0)
        label16.Name = "label16"
        label16.Size = New Size(62, 25)
        label16.TabIndex = 2
        label16.Text = "Speed"
        ' 
        ' lbTime
        ' 
        lbTime.AutoSize = True
        lbTime.Location = New Point(362, 66)
        lbTime.Margin = New Padding(5, 0, 5, 0)
        lbTime.Name = "lbTime"
        lbTime.Size = New Size(155, 25)
        lbTime.TabIndex = 1
        lbTime.Text = "00:00:00/00:00:00"
        ' 
        ' tbTimeline
        ' 
        tbTimeline.Location = New Point(10, 37)
        tbTimeline.Margin = New Padding(5, 6, 5, 6)
        tbTimeline.Maximum = 100
        tbTimeline.Name = "tbTimeline"
        tbTimeline.Size = New Size(345, 69)
        tbTimeline.TabIndex = 0
        ' 
        ' btSelectFile
        ' 
        btSelectFile.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btSelectFile.Location = New Point(671, 55)
        btSelectFile.Margin = New Padding(5, 6, 5, 6)
        btSelectFile.Name = "btSelectFile"
        btSelectFile.Size = New Size(38, 44)
        btSelectFile.TabIndex = 54
        btSelectFile.Text = "..."
        btSelectFile.UseVisualStyleBackColor = True
        ' 
        ' edFilename
        ' 
        edFilename.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        edFilename.Location = New Point(16, 59)
        edFilename.Margin = New Padding(5, 6, 5, 6)
        edFilename.Name = "edFilename"
        edFilename.Size = New Size(642, 31)
        edFilename.TabIndex = 53
        edFilename.Text = "C:\samples\!video.mp4"
        ' 
        ' label14
        ' 
        label14.AutoSize = True
        label14.Location = New Point(11, 28)
        label14.Margin = New Padding(5, 0, 5, 0)
        label14.Name = "label14"
        label14.Size = New Size(87, 25)
        label14.TabIndex = 52
        label14.Text = "File name"
        ' 
        ' VideoView1
        ' 
        VideoView1.BackColor = Color.Black
        VideoView1.Location = New Point(16, 115)
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(693, 522)
        VideoView1.TabIndex = 62
        ' 
        ' tbVolume1
        ' 
        tbVolume1.BackColor = SystemColors.Window
        tbVolume1.Location = New Point(16, 133)
        tbVolume1.Margin = New Padding(5, 6, 5, 6)
        tbVolume1.Maximum = 100
        tbVolume1.Name = "tbVolume1"
        tbVolume1.Size = New Size(142, 69)
        tbVolume1.TabIndex = 8
        tbVolume1.Value = 80
        ' 
        ' cbAudioOutput
        ' 
        cbAudioOutput.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioOutput.FormattingEnabled = True
        cbAudioOutput.Location = New Point(21, 51)
        cbAudioOutput.Name = "cbAudioOutput"
        cbAudioOutput.Size = New Size(326, 33)
        cbAudioOutput.TabIndex = 12
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1099, 963)
        Controls.Add(VideoView1)
        Controls.Add(groupBox4)
        Controls.Add(groupBox1)
        Controls.Add(label1)
        Controls.Add(groupBox2)
        Controls.Add(btSelectFile)
        Controls.Add(edFilename)
        Controls.Add(label14)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Media Player SDK .Net - Simple Video Player Demo"
        groupBox4.ResumeLayout(False)
        groupBox4.PerformLayout()
        groupBox1.ResumeLayout(False)
        groupBox1.PerformLayout()
        groupBox2.ResumeLayout(False)
        groupBox2.PerformLayout()
        CType(tbSpeed, ComponentModel.ISupportInitialize).EndInit()
        CType(tbTimeline, ComponentModel.ISupportInitialize).EndInit()
        CType(tbVolume1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Private WithEvents groupBox4 As GroupBox
    Private WithEvents label6 As Label
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents cbLicensing As CheckBox
    Private WithEvents edLog As TextBox
    Private WithEvents cbDebugMode As CheckBox
    Private WithEvents label1 As Label
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents btStop As Button
    Private WithEvents btPause As Button
    Private WithEvents btResume As Button
    Private WithEvents btStart As Button
    Private WithEvents tbSpeed As TrackBar
    Private WithEvents label16 As Label
    Private WithEvents lbTime As Label
    Private WithEvents tbTimeline As TrackBar
    Private WithEvents btSelectFile As Button
    Private WithEvents edFilename As TextBox
    Private WithEvents label14 As Label
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
    Private WithEvents tbVolume1 As TrackBar
    Friend WithEvents cbAudioOutput As ComboBox

End Class
