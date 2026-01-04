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
        gbScreenMode = New GroupBox()
        rbScreenFullScreen = New RadioButton()
        rbScreenCustomArea = New RadioButton()
        gbAudioSource = New GroupBox()
        rbSystemAudio = New RadioButton()
        cbAudioInputDevice = New ComboBox()
        rbLoopback = New RadioButton()
        gbMode = New GroupBox()
        rbPreview = New RadioButton()
        rbCapture = New RadioButton()
        btStart = New Button()
        btStop = New Button()
        cbDebugMode = New CheckBox()
        cbRecordAudio = New CheckBox()
        cbScreenCaptureDisplayIndex = New ComboBox()
        cbScreenCapture_GrabMouseCursor = New CheckBox()
        edOutput = New TextBox()
        btSelectOutput = New Button()
        edScreenBottom = New TextBox()
        edScreenFrameRate = New TextBox()
        edScreenLeft = New TextBox()
        edScreenRight = New TextBox()
        edScreenTop = New TextBox()
        lbTimestamp = New Label()
        mmLog = New TextBox()
        cbAudioLoopbackDevice = New ComboBox()
        gbScreenMode.SuspendLayout()
        gbAudioSource.SuspendLayout()
        gbMode.SuspendLayout()
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
        ' gbScreenMode
        ' 
        gbScreenMode.Controls.Add(rbScreenFullScreen)
        gbScreenMode.Controls.Add(rbScreenCustomArea)
        gbScreenMode.Location = New Point(900, 20)
        gbScreenMode.Margin = New Padding(4, 5, 4, 5)
        gbScreenMode.Name = "gbScreenMode"
        gbScreenMode.Padding = New Padding(4, 5, 4, 5)
        gbScreenMode.Size = New Size(320, 117)
        gbScreenMode.TabIndex = 1
        gbScreenMode.TabStop = False
        gbScreenMode.Text = "Screen Mode"
        ' 
        ' rbScreenFullScreen
        ' 
        rbScreenFullScreen.AutoSize = True
        rbScreenFullScreen.Checked = True
        rbScreenFullScreen.Location = New Point(9, 37)
        rbScreenFullScreen.Margin = New Padding(4, 5, 4, 5)
        rbScreenFullScreen.Name = "rbScreenFullScreen"
        rbScreenFullScreen.Size = New Size(121, 29)
        rbScreenFullScreen.TabIndex = 0
        rbScreenFullScreen.TabStop = True
        rbScreenFullScreen.Text = "Full Screen"
        ' 
        ' rbScreenCustomArea
        ' 
        rbScreenCustomArea.AutoSize = True
        rbScreenCustomArea.Location = New Point(9, 73)
        rbScreenCustomArea.Margin = New Padding(4, 5, 4, 5)
        rbScreenCustomArea.Name = "rbScreenCustomArea"
        rbScreenCustomArea.Size = New Size(140, 29)
        rbScreenCustomArea.TabIndex = 1
        rbScreenCustomArea.Text = "Custom Area"
        ' 
        ' gbAudioSource
        ' 
        gbAudioSource.Controls.Add(cbAudioLoopbackDevice)
        gbAudioSource.Controls.Add(rbSystemAudio)
        gbAudioSource.Controls.Add(cbAudioInputDevice)
        gbAudioSource.Controls.Add(rbLoopback)
        gbAudioSource.Location = New Point(900, 379)
        gbAudioSource.Margin = New Padding(4, 5, 4, 5)
        gbAudioSource.Name = "gbAudioSource"
        gbAudioSource.Padding = New Padding(4, 5, 4, 5)
        gbAudioSource.Size = New Size(320, 214)
        gbAudioSource.TabIndex = 10
        gbAudioSource.TabStop = False
        gbAudioSource.Text = "Audio Source"
        ' 
        ' rbSystemAudio
        ' 
        rbSystemAudio.AutoSize = True
        rbSystemAudio.Checked = True
        rbSystemAudio.Location = New Point(9, 37)
        rbSystemAudio.Margin = New Padding(4, 5, 4, 5)
        rbSystemAudio.Name = "rbSystemAudio"
        rbSystemAudio.Size = New Size(147, 29)
        rbSystemAudio.TabIndex = 0
        rbSystemAudio.TabStop = True
        rbSystemAudio.Text = "System Audio"
        ' 
        ' cbAudioInputDevice
        ' 
        cbAudioInputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioInputDevice.Location = New Point(9, 73)
        cbAudioInputDevice.Margin = New Padding(4, 5, 4, 5)
        cbAudioInputDevice.Name = "cbAudioInputDevice"
        cbAudioInputDevice.Size = New Size(291, 33)
        cbAudioInputDevice.TabIndex = 1
        ' 
        ' rbLoopback
        ' 
        rbLoopback.AutoSize = True
        rbLoopback.Location = New Point(9, 122)
        rbLoopback.Margin = New Padding(4, 5, 4, 5)
        rbLoopback.Name = "rbLoopback"
        rbLoopback.Size = New Size(115, 29)
        rbLoopback.TabIndex = 2
        rbLoopback.Text = "Loopback"
        ' 
        ' gbMode
        ' 
        gbMode.Controls.Add(rbPreview)
        gbMode.Controls.Add(rbCapture)
        gbMode.Location = New Point(900, 603)
        gbMode.Margin = New Padding(4, 5, 4, 5)
        gbMode.Name = "gbMode"
        gbMode.Padding = New Padding(4, 5, 4, 5)
        gbMode.Size = New Size(320, 117)
        gbMode.TabIndex = 12
        gbMode.TabStop = False
        gbMode.Text = "Mode"
        ' 
        ' rbPreview
        ' 
        rbPreview.AutoSize = True
        rbPreview.Checked = True
        rbPreview.Location = New Point(9, 37)
        rbPreview.Margin = New Padding(4, 5, 4, 5)
        rbPreview.Name = "rbPreview"
        rbPreview.Size = New Size(97, 29)
        rbPreview.TabIndex = 0
        rbPreview.TabStop = True
        rbPreview.Text = "Preview"
        ' 
        ' rbCapture
        ' 
        rbCapture.AutoSize = True
        rbCapture.Location = New Point(9, 73)
        rbCapture.Margin = New Padding(4, 5, 4, 5)
        rbCapture.Name = "rbCapture"
        rbCapture.Size = New Size(99, 29)
        rbCapture.TabIndex = 1
        rbCapture.Text = "Capture"
        ' 
        ' btStart
        ' 
        btStart.Location = New Point(15, 711)
        btStart.Margin = New Padding(4, 5, 4, 5)
        btStart.Name = "btStart"
        btStart.Size = New Size(107, 38)
        btStart.TabIndex = 15
        btStart.Text = "Start"
        ' 
        ' btStop
        ' 
        btStop.Location = New Point(131, 711)
        btStop.Margin = New Padding(4, 5, 4, 5)
        btStop.Name = "btStop"
        btStop.Size = New Size(107, 38)
        btStop.TabIndex = 16
        btStop.Text = "Stop"
        ' 
        ' cbDebugMode
        ' 
        cbDebugMode.AutoSize = True
        cbDebugMode.Location = New Point(730, 716)
        cbDebugMode.Margin = New Padding(4, 5, 4, 5)
        cbDebugMode.Name = "cbDebugMode"
        cbDebugMode.Size = New Size(144, 29)
        cbDebugMode.TabIndex = 14
        cbDebugMode.Text = "Debug Mode"
        ' 
        ' cbRecordAudio
        ' 
        cbRecordAudio.AutoSize = True
        cbRecordAudio.Location = New Point(1074, 340)
        cbRecordAudio.Margin = New Padding(4, 5, 4, 5)
        cbRecordAudio.Name = "cbRecordAudio"
        cbRecordAudio.Size = New Size(146, 29)
        cbRecordAudio.TabIndex = 9
        cbRecordAudio.Text = "Record Audio"
        ' 
        ' cbScreenCaptureDisplayIndex
        ' 
        cbScreenCaptureDisplayIndex.DropDownStyle = ComboBoxStyle.DropDownList
        cbScreenCaptureDisplayIndex.Location = New Point(900, 147)
        cbScreenCaptureDisplayIndex.Margin = New Padding(4, 5, 4, 5)
        cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex"
        cbScreenCaptureDisplayIndex.Size = New Size(320, 33)
        cbScreenCaptureDisplayIndex.TabIndex = 2
        ' 
        ' cbScreenCapture_GrabMouseCursor
        ' 
        cbScreenCapture_GrabMouseCursor.AutoSize = True
        cbScreenCapture_GrabMouseCursor.Checked = True
        cbScreenCapture_GrabMouseCursor.CheckState = CheckState.Checked
        cbScreenCapture_GrabMouseCursor.Location = New Point(900, 340)
        cbScreenCapture_GrabMouseCursor.Margin = New Padding(4, 5, 4, 5)
        cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor"
        cbScreenCapture_GrabMouseCursor.Size = New Size(133, 29)
        cbScreenCapture_GrabMouseCursor.TabIndex = 8
        cbScreenCapture_GrabMouseCursor.Text = "Grab Cursor"
        ' 
        ' edOutput
        ' 
        edOutput.Location = New Point(900, 730)
        edOutput.Margin = New Padding(4, 5, 4, 5)
        edOutput.Name = "edOutput"
        edOutput.PlaceholderText = "Output file"
        edOutput.Size = New Size(279, 31)
        edOutput.TabIndex = 13

        ' btSelectOutput
        ' 
        btSelectOutput.Location = New Point(1188, 730)
        btSelectOutput.Margin = New Padding(4, 5, 4, 5)
        btSelectOutput.Name = "btSelectOutput"
        btSelectOutput.Size = New Size(32, 31)
        btSelectOutput.TabIndex = 19
        btSelectOutput.Text = "..."
        ' 
        ' edScreenBottom
        ' 
        edScreenBottom.Location = New Point(1146, 195)
        edScreenBottom.Margin = New Padding(4, 5, 4, 5)
        edScreenBottom.Name = "edScreenBottom"
        edScreenBottom.PlaceholderText = "Bottom"
        edScreenBottom.Size = New Size(74, 31)
        edScreenBottom.TabIndex = 6
        edScreenBottom.Text = "1080"
        ' 
        ' edScreenFrameRate
        ' 
        edScreenFrameRate.Location = New Point(900, 247)
        edScreenFrameRate.Margin = New Padding(4, 5, 4, 5)
        edScreenFrameRate.Name = "edScreenFrameRate"
        edScreenFrameRate.PlaceholderText = "Frame Rate"
        edScreenFrameRate.Size = New Size(74, 31)
        edScreenFrameRate.TabIndex = 7
        edScreenFrameRate.Text = "30"
        ' 
        ' edScreenLeft
        ' 
        edScreenLeft.Location = New Point(900, 195)
        edScreenLeft.Margin = New Padding(4, 5, 4, 5)
        edScreenLeft.Name = "edScreenLeft"
        edScreenLeft.PlaceholderText = "Left"
        edScreenLeft.Size = New Size(74, 31)
        edScreenLeft.TabIndex = 3
        edScreenLeft.Text = "0"
        ' 
        ' edScreenRight
        ' 
        edScreenRight.Location = New Point(1064, 195)
        edScreenRight.Margin = New Padding(4, 5, 4, 5)
        edScreenRight.Name = "edScreenRight"
        edScreenRight.PlaceholderText = "Right"
        edScreenRight.Size = New Size(74, 31)
        edScreenRight.TabIndex = 5
        edScreenRight.Text = "1920"
        ' 
        ' edScreenTop
        ' 
        edScreenTop.Location = New Point(982, 195)
        edScreenTop.Margin = New Padding(4, 5, 4, 5)
        edScreenTop.Name = "edScreenTop"
        edScreenTop.PlaceholderText = "Top"
        edScreenTop.Size = New Size(74, 31)
        edScreenTop.TabIndex = 4
        edScreenTop.Text = "0"
        ' 
        ' lbTimestamp
        ' 
        lbTimestamp.AutoSize = True
        lbTimestamp.Location = New Point(284, 717)
        lbTimestamp.Margin = New Padding(4, 0, 4, 0)
        lbTimestamp.Name = "lbTimestamp"
        lbTimestamp.Size = New Size(209, 25)
        lbTimestamp.TabIndex = 17
        lbTimestamp.Text = "Recording time: 00:00:00"
        ' 
        ' mmLog
        ' 
        mmLog.Location = New Point(17, 769)
        mmLog.Margin = New Padding(4, 5, 4, 5)
        mmLog.Multiline = True
        mmLog.Name = "mmLog"
        mmLog.ScrollBars = ScrollBars.Vertical
        mmLog.Size = New Size(857, 93)
        mmLog.TabIndex = 18
        ' 
        ' cbAudioLoopbackDevice
        ' 
        cbAudioLoopbackDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioLoopbackDevice.Location = New Point(9, 161)
        cbAudioLoopbackDevice.Margin = New Padding(4, 5, 4, 5)
        cbAudioLoopbackDevice.Name = "cbAudioLoopbackDevice"
        cbAudioLoopbackDevice.Size = New Size(291, 33)
        cbAudioLoopbackDevice.TabIndex = 12
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1241, 898)
        Controls.Add(VideoView1)
        Controls.Add(gbScreenMode)
        Controls.Add(cbScreenCaptureDisplayIndex)
        Controls.Add(edScreenLeft)
        Controls.Add(edScreenTop)
        Controls.Add(edScreenRight)
        Controls.Add(edScreenBottom)
        Controls.Add(edScreenFrameRate)
        Controls.Add(cbScreenCapture_GrabMouseCursor)
        Controls.Add(cbRecordAudio)
        Controls.Add(gbAudioSource)
        Controls.Add(gbMode)
        Controls.Add(edOutput)
        Controls.Add(btSelectOutput)
        Controls.Add(cbDebugMode)
        Controls.Add(btStart)
        Controls.Add(btStop)
        Controls.Add(lbTimestamp)
        Controls.Add(mmLog)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        Text = "Screen Capture Demo X - Video Capture SDK .Net"
        gbScreenMode.ResumeLayout(False)
        gbScreenMode.PerformLayout()
        gbAudioSource.ResumeLayout(False)
        gbAudioSource.PerformLayout()
        gbMode.ResumeLayout(False)
        gbMode.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
    Friend WithEvents gbScreenMode As GroupBox
    Friend WithEvents gbAudioSource As GroupBox
    Friend WithEvents gbMode As GroupBox
    Friend WithEvents btStart As Button
    Friend WithEvents btStop As Button
    Friend WithEvents cbAudioInputDevice As ComboBox
    Friend WithEvents cbDebugMode As CheckBox
    Friend WithEvents cbRecordAudio As CheckBox
    Friend WithEvents cbScreenCaptureDisplayIndex As ComboBox
    Friend WithEvents cbScreenCapture_GrabMouseCursor As CheckBox
    Friend WithEvents edOutput As TextBox
    Friend WithEvents btSelectOutput As Button
    Friend WithEvents edScreenBottom As TextBox
    Friend WithEvents edScreenFrameRate As TextBox
    Friend WithEvents edScreenLeft As TextBox
    Friend WithEvents edScreenRight As TextBox
    Friend WithEvents edScreenTop As TextBox
    Friend WithEvents lbTimestamp As Label
    Friend WithEvents mmLog As TextBox
    Friend WithEvents rbScreenFullScreen As RadioButton
    Friend WithEvents rbScreenCustomArea As RadioButton
    Friend WithEvents rbSystemAudio As RadioButton
    Friend WithEvents rbLoopback As RadioButton
    Friend WithEvents rbCapture As RadioButton
    Friend WithEvents rbPreview As RadioButton
    Friend WithEvents cbAudioLoopbackDevice As ComboBox
End Class
