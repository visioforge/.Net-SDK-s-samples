<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        btPause = New Button()
        btResume = New Button()
        btSaveScreenshot = New Button()
        btStart = New Button()
        btStop = New Button()
        cbAudioInputDevice = New ComboBox()
        cbAudioInputFormat = New ComboBox()
        cbAudioOutputDevice = New ComboBox()
        cbDebugMode = New CheckBox()
        cbRecordAudio = New CheckBox()
        cbVideoInputDevice = New ComboBox()
        cbVideoInputFormat = New ComboBox()
        cbVideoInputFrameRate = New ComboBox()
        edOutput = New TextBox()
        btSelectOutputFile = New Button()
        lbTimestamp = New Label()
        mmLog = New TextBox()
        tbAudioVolume = New TrackBar()
        rbPreview = New RadioButton()
        rbCapture = New RadioButton()
        CType(tbAudioVolume, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' VideoView1
        ' 
        VideoView1.BackColor = Color.Black
        VideoView1.Location = New Point(17, 20)
        VideoView1.Margin = New Padding(4, 5, 4, 5)
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(857, 667)
        VideoView1.TabIndex = 0
        ' 
        ' btPause
        ' 
        btPause.Location = New Point(133, 710)
        btPause.Margin = New Padding(4, 5, 4, 5)
        btPause.Name = "btPause"
        btPause.Size = New Size(107, 38)
        btPause.TabIndex = 17
        btPause.Text = "Pause"
        ' 
        ' btResume
        ' 
        btResume.Location = New Point(249, 710)
        btResume.Margin = New Padding(4, 5, 4, 5)
        btResume.Name = "btResume"
        btResume.Size = New Size(107, 38)
        btResume.TabIndex = 18
        btResume.Text = "Resume"
        ' 
        ' btSaveScreenshot
        ' 
        btSaveScreenshot.Location = New Point(1099, 491)
        btSaveScreenshot.Margin = New Padding(4, 5, 4, 5)
        btSaveScreenshot.Name = "btSaveScreenshot"
        btSaveScreenshot.Size = New Size(143, 38)
        btSaveScreenshot.TabIndex = 20
        btSaveScreenshot.Text = "Screenshot"
        ' 
        ' btStart
        ' 
        btStart.Location = New Point(17, 710)
        btStart.Margin = New Padding(4, 5, 4, 5)
        btStart.Name = "btStart"
        btStart.Size = New Size(107, 38)
        btStart.TabIndex = 16
        btStart.Text = "Start"
        ' 
        ' btStop
        ' 
        btStop.Location = New Point(364, 710)
        btStop.Margin = New Padding(4, 5, 4, 5)
        btStop.Name = "btStop"
        btStop.Size = New Size(107, 38)
        btStop.TabIndex = 19
        btStop.Text = "Stop"
        ' 
        ' cbAudioInputDevice
        ' 
        cbAudioInputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioInputDevice.Location = New Point(900, 139)
        cbAudioInputDevice.Margin = New Padding(4, 5, 4, 5)
        cbAudioInputDevice.Name = "cbAudioInputDevice"
        cbAudioInputDevice.Size = New Size(348, 33)
        cbAudioInputDevice.TabIndex = 4
        ' 
        ' cbAudioInputFormat
        ' 
        cbAudioInputFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioInputFormat.Location = New Point(900, 182)
        cbAudioInputFormat.Margin = New Padding(4, 5, 4, 5)
        cbAudioInputFormat.Name = "cbAudioInputFormat"
        cbAudioInputFormat.Size = New Size(348, 33)
        cbAudioInputFormat.TabIndex = 6
        ' 
        ' cbAudioOutputDevice
        ' 
        cbAudioOutputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioOutputDevice.Location = New Point(900, 272)
        cbAudioOutputDevice.Margin = New Padding(4, 5, 4, 5)
        cbAudioOutputDevice.Name = "cbAudioOutputDevice"
        cbAudioOutputDevice.Size = New Size(348, 33)
        cbAudioOutputDevice.TabIndex = 7
        ' 
        ' cbDebugMode
        ' 
        cbDebugMode.AutoSize = True
        cbDebugMode.Location = New Point(894, 497)
        cbDebugMode.Margin = New Padding(4, 5, 4, 5)
        cbDebugMode.Name = "cbDebugMode"
        cbDebugMode.Size = New Size(144, 29)
        cbDebugMode.TabIndex = 15
        cbDebugMode.Text = "Debug Mode"
        ' 
        ' cbRecordAudio
        ' 
        cbRecordAudio.AutoSize = True
        cbRecordAudio.Location = New Point(900, 229)
        cbRecordAudio.Margin = New Padding(4, 5, 4, 5)
        cbRecordAudio.Name = "cbRecordAudio"
        cbRecordAudio.Size = New Size(146, 29)
        cbRecordAudio.TabIndex = 5
        cbRecordAudio.Text = "Record Audio"
        cbRecordAudio.UseVisualStyleBackColor = True
        ' 
        ' cbVideoInputDevice
        ' 
        cbVideoInputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbVideoInputDevice.Location = New Point(900, 20)
        cbVideoInputDevice.Margin = New Padding(4, 5, 4, 5)
        cbVideoInputDevice.Name = "cbVideoInputDevice"
        cbVideoInputDevice.Size = New Size(348, 33)
        cbVideoInputDevice.TabIndex = 1
        ' 
        ' cbVideoInputFormat
        ' 
        cbVideoInputFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbVideoInputFormat.Location = New Point(900, 63)
        cbVideoInputFormat.Margin = New Padding(4, 5, 4, 5)
        cbVideoInputFormat.Name = "cbVideoInputFormat"
        cbVideoInputFormat.Size = New Size(238, 33)
        cbVideoInputFormat.TabIndex = 2
        ' 
        ' cbVideoInputFrameRate
        ' 
        cbVideoInputFrameRate.DropDownStyle = ComboBoxStyle.DropDownList
        cbVideoInputFrameRate.Location = New Point(1167, 63)
        cbVideoInputFrameRate.Margin = New Padding(4, 5, 4, 5)
        cbVideoInputFrameRate.Name = "cbVideoInputFrameRate"
        cbVideoInputFrameRate.Size = New Size(81, 33)
        cbVideoInputFrameRate.TabIndex = 3
        ' 
        ' edOutput
        ' 
        edOutput.Location = New Point(894, 431)
        edOutput.Margin = New Padding(4, 5, 4, 5)
        edOutput.Name = "edOutput"
        edOutput.PlaceholderText = "Output file"
        edOutput.Size = New Size(308, 31)
        edOutput.TabIndex = 13
        ' 
        ' btSelectOutputFile
        ' 
        btSelectOutputFile.Location = New Point(1210, 431)
        btSelectOutputFile.Margin = New Padding(4, 5, 4, 5)
        btSelectOutputFile.Name = "btSelectOutputFile"
        btSelectOutputFile.Size = New Size(38, 31)
        btSelectOutputFile.TabIndex = 14
        btSelectOutputFile.Text = "..."
        ' 
        ' lbTimestamp
        ' 
        lbTimestamp.AutoSize = True
        lbTimestamp.Location = New Point(665, 717)
        lbTimestamp.Margin = New Padding(4, 0, 4, 0)
        lbTimestamp.Name = "lbTimestamp"
        lbTimestamp.Size = New Size(209, 25)
        lbTimestamp.TabIndex = 21
        lbTimestamp.Text = "Recording time: 00:00:00"
        ' 
        ' mmLog
        ' 
        mmLog.Location = New Point(900, 556)
        mmLog.Margin = New Padding(4, 5, 4, 5)
        mmLog.Multiline = True
        mmLog.Name = "mmLog"
        mmLog.ScrollBars = ScrollBars.Vertical
        mmLog.Size = New Size(348, 203)
        mmLog.TabIndex = 23
        ' 
        ' tbAudioVolume
        ' 
        tbAudioVolume.Location = New Point(1034, 315)
        tbAudioVolume.Margin = New Padding(4, 5, 4, 5)
        tbAudioVolume.Name = "tbAudioVolume"
        tbAudioVolume.Size = New Size(214, 69)
        tbAudioVolume.TabIndex = 8
        tbAudioVolume.Value = 10
        ' 
        ' rbPreview
        ' 
        rbPreview.AutoSize = True
        rbPreview.Checked = True
        rbPreview.Location = New Point(894, 382)
        rbPreview.Margin = New Padding(4, 5, 4, 5)
        rbPreview.Name = "rbPreview"
        rbPreview.Size = New Size(97, 29)
        rbPreview.TabIndex = 11
        rbPreview.TabStop = True
        rbPreview.Text = "Preview"
        ' 
        ' rbCapture
        ' 
        rbCapture.AutoSize = True
        rbCapture.Location = New Point(1020, 382)
        rbCapture.Margin = New Padding(4, 5, 4, 5)
        rbCapture.Name = "rbCapture"
        rbCapture.Size = New Size(99, 29)
        rbCapture.TabIndex = 12
        rbCapture.Text = "Capture"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1261, 792)
        Controls.Add(VideoView1)
        Controls.Add(cbVideoInputDevice)
        Controls.Add(cbVideoInputFormat)
        Controls.Add(cbVideoInputFrameRate)
        Controls.Add(cbAudioInputDevice)
        Controls.Add(cbAudioInputFormat)
        Controls.Add(cbRecordAudio)
        Controls.Add(cbAudioOutputDevice)
        Controls.Add(tbAudioVolume)
        Controls.Add(rbPreview)
        Controls.Add(rbCapture)
        Controls.Add(edOutput)
        Controls.Add(btSelectOutputFile)
        Controls.Add(cbDebugMode)
        Controls.Add(btStart)
        Controls.Add(btPause)
        Controls.Add(btResume)
        Controls.Add(btStop)
        Controls.Add(btSaveScreenshot)
        Controls.Add(lbTimestamp)
        Controls.Add(mmLog)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        Text = "Simple Video Capture Demo X - Video Capture SDK .Net"
        CType(tbAudioVolume, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
    Friend WithEvents btPause As Button
    Friend WithEvents btResume As Button
    Friend WithEvents btSaveScreenshot As Button
    Friend WithEvents btStart As Button
    Friend WithEvents btStop As Button
    Friend WithEvents cbAudioInputDevice As ComboBox
    Friend WithEvents cbAudioInputFormat As ComboBox
    Friend WithEvents cbAudioOutputDevice As ComboBox
    Friend WithEvents cbDebugMode As CheckBox
    Friend WithEvents cbRecordAudio As CheckBox
    Friend WithEvents cbVideoInputDevice As ComboBox
    Friend WithEvents cbVideoInputFormat As ComboBox
    Friend WithEvents cbVideoInputFrameRate As ComboBox
    Friend WithEvents edOutput As TextBox
    Friend WithEvents btSelectOutputFile As Button
    Friend WithEvents lbTimestamp As Label
    Friend WithEvents mmLog As TextBox
    Friend WithEvents tbAudioVolume As TrackBar
    Friend WithEvents rbPreview As RadioButton
    Friend WithEvents rbCapture As RadioButton
End Class
