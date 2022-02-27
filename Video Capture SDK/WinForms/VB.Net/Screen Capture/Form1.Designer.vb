Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If

        _mp4SettingsDialog?.Dispose()
        _mp4SettingsDialog = Nothing

        mp4HWSettingsDialog?.Dispose()
        mp4HWSettingsDialog = Nothing

        mpegTSSettingsDialog?.Dispose()
        mpegTSSettingsDialog = Nothing

        movSettingsDialog?.Dispose()
        movSettingsDialog = Nothing

        aviSettingsDialog?.Dispose()
        aviSettingsDialog = Nothing

        wmvSettingsDialog?.Dispose()
        wmvSettingsDialog = Nothing

        gifSettingsDialog?.Dispose()
        gifSettingsDialog = Nothing

        screenshotSaveDialog?.Dispose()
        screenshotSaveDialog = Nothing

        tmRecording?.Dispose()
        tmRecording = Nothing

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
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbFlipY = New System.Windows.Forms.CheckBox()
        Me.cbFlipX = New System.Windows.Forms.CheckBox()
        Me.cbInvert = New System.Windows.Forms.CheckBox()
        Me.cbGreyscale = New System.Windows.Forms.CheckBox()
        Me.label201 = New System.Windows.Forms.Label()
        Me.tbDarkness = New System.Windows.Forms.TrackBar()
        Me.label200 = New System.Windows.Forms.Label()
        Me.label199 = New System.Windows.Forms.Label()
        Me.label198 = New System.Windows.Forms.Label()
        Me.tbContrast = New System.Windows.Forms.TrackBar()
        Me.tbLightness = New System.Windows.Forms.TrackBar()
        Me.tbSaturation = New System.Windows.Forms.TrackBar()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btTextLogoAdd = New System.Windows.Forms.Button()
        Me.btLogoRemove = New System.Windows.Forms.Button()
        Me.btLogoEdit = New System.Windows.Forms.Button()
        Me.lbLogos = New System.Windows.Forms.ListBox()
        Me.btImageLogoAdd = New System.Windows.Forms.Button()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.cbUseBestAudioInputFormat = New System.Windows.Forms.CheckBox()
        Me.btAudioInputDeviceSettings = New System.Windows.Forms.Button()
        Me.cbAudioInputLine = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputFormat = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputDevice = New System.Windows.Forms.ComboBox()
        Me.label22 = New System.Windows.Forms.Label()
        Me.label23 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.cbRecordAudio = New System.Windows.Forms.CheckBox()
        Me.btScreenCaptureUpdate = New System.Windows.Forms.Button()
        Me.cbScreenCapture_GrabMouseCursor = New System.Windows.Forms.CheckBox()
        Me.label79 = New System.Windows.Forms.Label()
        Me.edScreenFrameRate = New System.Windows.Forms.TextBox()
        Me.label43 = New System.Windows.Forms.Label()
        Me.edScreenBottom = New System.Windows.Forms.TextBox()
        Me.label42 = New System.Windows.Forms.Label()
        Me.edScreenTop = New System.Windows.Forms.TextBox()
        Me.label26 = New System.Windows.Forms.Label()
        Me.edScreenRight = New System.Windows.Forms.TextBox()
        Me.label40 = New System.Windows.Forms.Label()
        Me.fontDialog1 = New System.Windows.Forms.FontDialog()
        Me.edScreenLeft = New System.Windows.Forms.TextBox()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbScreenSourceWindowText = New System.Windows.Forms.Label()
        Me.btScreenSourceWindowSelect = New System.Windows.Forms.Button()
        Me.rbScreenCaptureWindow = New System.Windows.Forms.RadioButton()
        Me.cbScreenCapture_DesktopDuplication = New System.Windows.Forms.CheckBox()
        Me.cbScreenCaptureDisplayIndex = New System.Windows.Forms.ComboBox()
        Me.label93 = New System.Windows.Forms.Label()
        Me.label24 = New System.Windows.Forms.Label()
        Me.rbScreenCustomArea = New System.Windows.Forms.RadioButton()
        Me.rbScreenFullScreen = New System.Windows.Forms.RadioButton()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btOutputConfigure = New System.Windows.Forms.Button()
        Me.cbOutputFormat = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.llVideoTutorials = New System.Windows.Forms.LinkLabel()
        Me.label34 = New System.Windows.Forms.Label()
        Me.lbTimestamp = New System.Windows.Forms.Label()
        Me.rbCapture = New System.Windows.Forms.RadioButton()
        Me.rbPreview = New System.Windows.Forms.RadioButton()
        Me.btSaveScreenshot = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        Me.tabPage3.SuspendLayout()
        CType(Me.tbDarkness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage4.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(454, 387)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(62, 23)
        Me.btStop.TabIndex = 54
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(389, 387)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(62, 23)
        Me.btStart.TabIndex = 53
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.Label5)
        Me.tabPage3.Controls.Add(Me.cbFlipY)
        Me.tabPage3.Controls.Add(Me.cbFlipX)
        Me.tabPage3.Controls.Add(Me.cbInvert)
        Me.tabPage3.Controls.Add(Me.cbGreyscale)
        Me.tabPage3.Controls.Add(Me.label201)
        Me.tabPage3.Controls.Add(Me.tbDarkness)
        Me.tabPage3.Controls.Add(Me.label200)
        Me.tabPage3.Controls.Add(Me.label199)
        Me.tabPage3.Controls.Add(Me.label198)
        Me.tabPage3.Controls.Add(Me.tbContrast)
        Me.tabPage3.Controls.Add(Me.tbLightness)
        Me.tabPage3.Controls.Add(Me.tbSaturation)
        Me.tabPage3.Controls.Add(Me.label3)
        Me.tabPage3.Controls.Add(Me.btTextLogoAdd)
        Me.tabPage3.Controls.Add(Me.btLogoRemove)
        Me.tabPage3.Controls.Add(Me.btLogoEdit)
        Me.tabPage3.Controls.Add(Me.lbLogos)
        Me.tabPage3.Controls.Add(Me.btImageLogoAdd)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(370, 380)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Video effects"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 336)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(239, 13)
        Me.Label5.TabIndex = 142
        Me.Label5.Text = "More effects and settings available in Main Demo"
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = True
        Me.cbFlipY.Location = New System.Drawing.Point(218, 287)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipY.TabIndex = 141
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = True
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = True
        Me.cbFlipX.Location = New System.Drawing.Point(158, 287)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipX.TabIndex = 140
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = True
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = True
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(98, 287)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbInvert.TabIndex = 139
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = True
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = True
        Me.cbGreyscale.Location = New System.Drawing.Point(18, 287)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGreyscale.TabIndex = 138
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = True
        '
        'label201
        '
        Me.label201.AutoSize = True
        Me.label201.Location = New System.Drawing.Point(151, 217)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(52, 13)
        Me.label201.TabIndex = 137
        Me.label201.Text = "Darkness"
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(151, 236)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbDarkness.TabIndex = 136
        '
        'label200
        '
        Me.label200.AutoSize = True
        Me.label200.Location = New System.Drawing.Point(15, 217)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(46, 13)
        Me.label200.TabIndex = 135
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = True
        Me.label199.Location = New System.Drawing.Point(151, 165)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(55, 13)
        Me.label199.TabIndex = 134
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = True
        Me.label198.Location = New System.Drawing.Point(15, 165)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(52, 13)
        Me.label198.TabIndex = 133
        Me.label198.Text = "Lightness"
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(12, 236)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbContrast.TabIndex = 132
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(12, 180)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(130, 45)
        Me.tbLightness.TabIndex = 131
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(151, 180)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbSaturation.TabIndex = 130
        Me.tbSaturation.Value = 255
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(9, 11)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(95, 13)
        Me.label3.TabIndex = 129
        Me.label3.Text = "Text / image logos"
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(117, 128)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(99, 23)
        Me.btTextLogoAdd.TabIndex = 128
        Me.btTextLogoAdd.Text = "Add text logo"
        Me.btTextLogoAdd.UseVisualStyleBackColor = True
        '
        'btLogoRemove
        '
        Me.btLogoRemove.Location = New System.Drawing.Point(298, 128)
        Me.btLogoRemove.Name = "btLogoRemove"
        Me.btLogoRemove.Size = New System.Drawing.Size(59, 23)
        Me.btLogoRemove.TabIndex = 127
        Me.btLogoRemove.Text = "Remove"
        Me.btLogoRemove.UseVisualStyleBackColor = True
        '
        'btLogoEdit
        '
        Me.btLogoEdit.Location = New System.Drawing.Point(233, 128)
        Me.btLogoEdit.Name = "btLogoEdit"
        Me.btLogoEdit.Size = New System.Drawing.Size(59, 23)
        Me.btLogoEdit.TabIndex = 126
        Me.btLogoEdit.Text = "Edit"
        Me.btLogoEdit.UseVisualStyleBackColor = True
        '
        'lbLogos
        '
        Me.lbLogos.FormattingEnabled = True
        Me.lbLogos.Location = New System.Drawing.Point(12, 27)
        Me.lbLogos.Name = "lbLogos"
        Me.lbLogos.Size = New System.Drawing.Size(347, 95)
        Me.lbLogos.TabIndex = 125
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(12, 128)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(99, 23)
        Me.btImageLogoAdd.TabIndex = 124
        Me.btImageLogoAdd.Text = "Add image logo"
        Me.btImageLogoAdd.UseVisualStyleBackColor = True
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.cbDebugMode)
        Me.tabPage4.Controls.Add(Me.mmLog)
        Me.tabPage4.Location = New System.Drawing.Point(4, 22)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage4.Size = New System.Drawing.Size(370, 380)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "Log"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(6, 6)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 81
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'mmLog
        '
        Me.mmLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mmLog.Location = New System.Drawing.Point(6, 29)
        Me.mmLog.Multiline = True
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(358, 345)
        Me.mmLog.TabIndex = 80
        '
        'cbUseBestAudioInputFormat
        '
        Me.cbUseBestAudioInputFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUseBestAudioInputFormat.AutoSize = True
        Me.cbUseBestAudioInputFormat.Location = New System.Drawing.Point(296, 309)
        Me.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat"
        Me.cbUseBestAudioInputFormat.Size = New System.Drawing.Size(68, 17)
        Me.cbUseBestAudioInputFormat.TabIndex = 83
        Me.cbUseBestAudioInputFormat.Text = "Use best"
        Me.cbUseBestAudioInputFormat.UseVisualStyleBackColor = True
        '
        'btAudioInputDeviceSettings
        '
        Me.btAudioInputDeviceSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAudioInputDeviceSettings.Location = New System.Drawing.Point(288, 277)
        Me.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings"
        Me.btAudioInputDeviceSettings.Size = New System.Drawing.Size(76, 23)
        Me.btAudioInputDeviceSettings.TabIndex = 82
        Me.btAudioInputDeviceSettings.Text = "Settings"
        Me.btAudioInputDeviceSettings.UseVisualStyleBackColor = True
        '
        'cbAudioInputLine
        '
        Me.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputLine.FormattingEnabled = True
        Me.cbAudioInputLine.Location = New System.Drawing.Point(10, 327)
        Me.cbAudioInputLine.Name = "cbAudioInputLine"
        Me.cbAudioInputLine.Size = New System.Drawing.Size(161, 21)
        Me.cbAudioInputLine.TabIndex = 81
        '
        'cbAudioInputFormat
        '
        Me.cbAudioInputFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputFormat.FormattingEnabled = True
        Me.cbAudioInputFormat.Location = New System.Drawing.Point(184, 326)
        Me.cbAudioInputFormat.Name = "cbAudioInputFormat"
        Me.cbAudioInputFormat.Size = New System.Drawing.Size(180, 21)
        Me.cbAudioInputFormat.TabIndex = 80
        '
        'cbAudioInputDevice
        '
        Me.cbAudioInputDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputDevice.FormattingEnabled = True
        Me.cbAudioInputDevice.Location = New System.Drawing.Point(10, 279)
        Me.cbAudioInputDevice.Name = "cbAudioInputDevice"
        Me.cbAudioInputDevice.Size = New System.Drawing.Size(272, 21)
        Me.cbAudioInputDevice.TabIndex = 79
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(7, 311)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(50, 13)
        Me.label22.TabIndex = 78
        Me.label22.Text = "Input line"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(7, 261)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(66, 13)
        Me.label23.TabIndex = 77
        Me.label23.Text = "Input device"
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(181, 309)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(63, 13)
        Me.label25.TabIndex = 76
        Me.label25.Text = "Input format"
        '
        'cbRecordAudio
        '
        Me.cbRecordAudio.AutoSize = True
        Me.cbRecordAudio.Location = New System.Drawing.Point(10, 234)
        Me.cbRecordAudio.Name = "cbRecordAudio"
        Me.cbRecordAudio.Size = New System.Drawing.Size(90, 17)
        Me.cbRecordAudio.TabIndex = 66
        Me.cbRecordAudio.Text = "Record audio"
        Me.cbRecordAudio.UseVisualStyleBackColor = True
        '
        'btScreenCaptureUpdate
        '
        Me.btScreenCaptureUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btScreenCaptureUpdate.Location = New System.Drawing.Point(244, 76)
        Me.btScreenCaptureUpdate.Name = "btScreenCaptureUpdate"
        Me.btScreenCaptureUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btScreenCaptureUpdate.TabIndex = 65
        Me.btScreenCaptureUpdate.Text = "Update"
        Me.btScreenCaptureUpdate.UseVisualStyleBackColor = True
        '
        'cbScreenCapture_GrabMouseCursor
        '
        Me.cbScreenCapture_GrabMouseCursor.AutoSize = True
        Me.cbScreenCapture_GrabMouseCursor.Location = New System.Drawing.Point(10, 180)
        Me.cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor"
        Me.cbScreenCapture_GrabMouseCursor.Size = New System.Drawing.Size(129, 17)
        Me.cbScreenCapture_GrabMouseCursor.TabIndex = 61
        Me.cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor"
        Me.cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = True
        '
        'label79
        '
        Me.label79.AutoSize = True
        Me.label79.Location = New System.Drawing.Point(131, 131)
        Me.label79.Name = "label79"
        Me.label79.Size = New System.Drawing.Size(21, 13)
        Me.label79.TabIndex = 60
        Me.label79.Text = "fps"
        '
        'edScreenFrameRate
        '
        Me.edScreenFrameRate.Location = New System.Drawing.Point(80, 128)
        Me.edScreenFrameRate.Name = "edScreenFrameRate"
        Me.edScreenFrameRate.Size = New System.Drawing.Size(45, 20)
        Me.edScreenFrameRate.TabIndex = 59
        Me.edScreenFrameRate.Text = "5"
        '
        'label43
        '
        Me.label43.AutoSize = True
        Me.label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label43.Location = New System.Drawing.Point(7, 131)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(67, 13)
        Me.label43.TabIndex = 58
        Me.label43.Text = "Frame rate"
        '
        'edScreenBottom
        '
        Me.edScreenBottom.Location = New System.Drawing.Point(174, 89)
        Me.edScreenBottom.Name = "edScreenBottom"
        Me.edScreenBottom.Size = New System.Drawing.Size(44, 20)
        Me.edScreenBottom.TabIndex = 57
        Me.edScreenBottom.Text = "480"
        '
        'label42
        '
        Me.label42.AutoSize = True
        Me.label42.Location = New System.Drawing.Point(131, 92)
        Me.label42.Name = "label42"
        Me.label42.Size = New System.Drawing.Size(40, 13)
        Me.label42.TabIndex = 56
        Me.label42.Text = "Bottom"
        '
        'edScreenTop
        '
        Me.edScreenTop.Location = New System.Drawing.Point(174, 63)
        Me.edScreenTop.Name = "edScreenTop"
        Me.edScreenTop.Size = New System.Drawing.Size(44, 20)
        Me.edScreenTop.TabIndex = 53
        Me.edScreenTop.Text = "0"
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label26.Location = New System.Drawing.Point(131, 66)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(29, 13)
        Me.label26.TabIndex = 52
        Me.label26.Text = "Top"
        '
        'edScreenRight
        '
        Me.edScreenRight.Location = New System.Drawing.Point(70, 89)
        Me.edScreenRight.Name = "edScreenRight"
        Me.edScreenRight.Size = New System.Drawing.Size(44, 20)
        Me.edScreenRight.TabIndex = 55
        Me.edScreenRight.Text = "640"
        '
        'label40
        '
        Me.label40.AutoSize = True
        Me.label40.Location = New System.Drawing.Point(29, 92)
        Me.label40.Name = "label40"
        Me.label40.Size = New System.Drawing.Size(32, 13)
        Me.label40.TabIndex = 54
        Me.label40.Text = "Right"
        '
        'fontDialog1
        '
        Me.fontDialog1.Color = System.Drawing.Color.White
        Me.fontDialog1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fontDialog1.FontMustExist = True
        Me.fontDialog1.ShowColor = True
        '
        'edScreenLeft
        '
        Me.edScreenLeft.Location = New System.Drawing.Point(70, 63)
        Me.edScreenLeft.Name = "edScreenLeft"
        Me.edScreenLeft.Size = New System.Drawing.Size(44, 20)
        Me.edScreenLeft.TabIndex = 51
        Me.edScreenLeft.Text = "0"
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Controls.Add(Me.tabPage1)
        Me.tcMain.Controls.Add(Me.tabPage2)
        Me.tcMain.Controls.Add(Me.tabPage3)
        Me.tcMain.Controls.Add(Me.tabPage4)
        Me.tcMain.Location = New System.Drawing.Point(3, 4)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(378, 406)
        Me.tcMain.TabIndex = 49
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.textBox1)
        Me.tabPage1.Controls.Add(Me.Label1)
        Me.tabPage1.Controls.Add(Me.lbScreenSourceWindowText)
        Me.tabPage1.Controls.Add(Me.btScreenSourceWindowSelect)
        Me.tabPage1.Controls.Add(Me.rbScreenCaptureWindow)
        Me.tabPage1.Controls.Add(Me.cbScreenCapture_DesktopDuplication)
        Me.tabPage1.Controls.Add(Me.cbScreenCaptureDisplayIndex)
        Me.tabPage1.Controls.Add(Me.label93)
        Me.tabPage1.Controls.Add(Me.cbUseBestAudioInputFormat)
        Me.tabPage1.Controls.Add(Me.btAudioInputDeviceSettings)
        Me.tabPage1.Controls.Add(Me.cbAudioInputLine)
        Me.tabPage1.Controls.Add(Me.cbAudioInputFormat)
        Me.tabPage1.Controls.Add(Me.cbAudioInputDevice)
        Me.tabPage1.Controls.Add(Me.label22)
        Me.tabPage1.Controls.Add(Me.label23)
        Me.tabPage1.Controls.Add(Me.label25)
        Me.tabPage1.Controls.Add(Me.cbRecordAudio)
        Me.tabPage1.Controls.Add(Me.btScreenCaptureUpdate)
        Me.tabPage1.Controls.Add(Me.cbScreenCapture_GrabMouseCursor)
        Me.tabPage1.Controls.Add(Me.label79)
        Me.tabPage1.Controls.Add(Me.edScreenFrameRate)
        Me.tabPage1.Controls.Add(Me.label43)
        Me.tabPage1.Controls.Add(Me.edScreenBottom)
        Me.tabPage1.Controls.Add(Me.label42)
        Me.tabPage1.Controls.Add(Me.edScreenRight)
        Me.tabPage1.Controls.Add(Me.label40)
        Me.tabPage1.Controls.Add(Me.edScreenTop)
        Me.tabPage1.Controls.Add(Me.label26)
        Me.tabPage1.Controls.Add(Me.edScreenLeft)
        Me.tabPage1.Controls.Add(Me.label24)
        Me.tabPage1.Controls.Add(Me.rbScreenCustomArea)
        Me.tabPage1.Controls.Add(Me.rbScreenFullScreen)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(370, 380)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Input"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.Color.White
        Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBox1.Location = New System.Drawing.Point(196, 14)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(167, 47)
        Me.textBox1.TabIndex = 94
        Me.textBox1.Text = "You can update left/top position and mouse cursor capturing on-the-fly"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "(You can capture background window)"
        '
        'lbScreenSourceWindowText
        '
        Me.lbScreenSourceWindowText.AutoSize = True
        Me.lbScreenSourceWindowText.Location = New System.Drawing.Point(193, 164)
        Me.lbScreenSourceWindowText.Name = "lbScreenSourceWindowText"
        Me.lbScreenSourceWindowText.Size = New System.Drawing.Size(107, 13)
        Me.lbScreenSourceWindowText.TabIndex = 92
        Me.lbScreenSourceWindowText.Text = "(no window selected)"
        '
        'btScreenSourceWindowSelect
        '
        Me.btScreenSourceWindowSelect.Location = New System.Drawing.Point(296, 131)
        Me.btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect"
        Me.btScreenSourceWindowSelect.Size = New System.Drawing.Size(49, 23)
        Me.btScreenSourceWindowSelect.TabIndex = 91
        Me.btScreenSourceWindowSelect.Text = "Select"
        Me.btScreenSourceWindowSelect.UseVisualStyleBackColor = True
        '
        'rbScreenCaptureWindow
        '
        Me.rbScreenCaptureWindow.AutoSize = True
        Me.rbScreenCaptureWindow.Location = New System.Drawing.Point(178, 134)
        Me.rbScreenCaptureWindow.Name = "rbScreenCaptureWindow"
        Me.rbScreenCaptureWindow.Size = New System.Drawing.Size(101, 17)
        Me.rbScreenCaptureWindow.TabIndex = 90
        Me.rbScreenCaptureWindow.TabStop = True
        Me.rbScreenCaptureWindow.Text = "Capture window"
        Me.rbScreenCaptureWindow.UseVisualStyleBackColor = True
        '
        'cbScreenCapture_DesktopDuplication
        '
        Me.cbScreenCapture_DesktopDuplication.AutoSize = True
        Me.cbScreenCapture_DesktopDuplication.Location = New System.Drawing.Point(10, 203)
        Me.cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication"
        Me.cbScreenCapture_DesktopDuplication.Size = New System.Drawing.Size(182, 17)
        Me.cbScreenCapture_DesktopDuplication.TabIndex = 89
        Me.cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage"
        Me.cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = True
        '
        'cbScreenCaptureDisplayIndex
        '
        Me.cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbScreenCaptureDisplayIndex.FormattingEnabled = True
        Me.cbScreenCaptureDisplayIndex.Location = New System.Drawing.Point(80, 153)
        Me.cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex"
        Me.cbScreenCaptureDisplayIndex.Size = New System.Drawing.Size(80, 21)
        Me.cbScreenCaptureDisplayIndex.TabIndex = 85
        '
        'label93
        '
        Me.label93.AutoSize = True
        Me.label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label93.Location = New System.Drawing.Point(7, 156)
        Me.label93.Name = "label93"
        Me.label93.Size = New System.Drawing.Size(65, 13)
        Me.label93.TabIndex = 84
        Me.label93.Text = "Display ID"
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label24.Location = New System.Drawing.Point(29, 66)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(29, 13)
        Me.label24.TabIndex = 50
        Me.label24.Text = "Left"
        '
        'rbScreenCustomArea
        '
        Me.rbScreenCustomArea.AutoSize = True
        Me.rbScreenCustomArea.Location = New System.Drawing.Point(10, 36)
        Me.rbScreenCustomArea.Name = "rbScreenCustomArea"
        Me.rbScreenCustomArea.Size = New System.Drawing.Size(84, 17)
        Me.rbScreenCustomArea.TabIndex = 49
        Me.rbScreenCustomArea.Text = "Custom area"
        Me.rbScreenCustomArea.UseVisualStyleBackColor = True
        '
        'rbScreenFullScreen
        '
        Me.rbScreenFullScreen.AutoSize = True
        Me.rbScreenFullScreen.Checked = True
        Me.rbScreenFullScreen.Location = New System.Drawing.Point(10, 12)
        Me.rbScreenFullScreen.Name = "rbScreenFullScreen"
        Me.rbScreenFullScreen.Size = New System.Drawing.Size(76, 17)
        Me.rbScreenFullScreen.TabIndex = 48
        Me.rbScreenFullScreen.TabStop = True
        Me.rbScreenFullScreen.Text = "Full screen"
        Me.rbScreenFullScreen.UseVisualStyleBackColor = True
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.btSelectOutput)
        Me.tabPage2.Controls.Add(Me.edOutput)
        Me.tabPage2.Controls.Add(Me.lbInfo)
        Me.tabPage2.Controls.Add(Me.btOutputConfigure)
        Me.tabPage2.Controls.Add(Me.cbOutputFormat)
        Me.tabPage2.Controls.Add(Me.label4)
        Me.tabPage2.Controls.Add(Me.label7)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(370, 380)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Output"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'btSelectOutput
        '
        Me.btSelectOutput.Location = New System.Drawing.Point(340, 156)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(24, 23)
        Me.btSelectOutput.TabIndex = 133
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = True
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(16, 158)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(318, 20)
        Me.edOutput.TabIndex = 132
        Me.edOutput.Text = "c:\capture.avi"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Location = New System.Drawing.Point(13, 58)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(267, 13)
        Me.lbInfo.TabIndex = 131
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btOutputConfigure
        '
        Me.btOutputConfigure.Location = New System.Drawing.Point(16, 74)
        Me.btOutputConfigure.Name = "btOutputConfigure"
        Me.btOutputConfigure.Size = New System.Drawing.Size(75, 23)
        Me.btOutputConfigure.TabIndex = 130
        Me.btOutputConfigure.Text = "Configure"
        Me.btOutputConfigure.UseVisualStyleBackColor = True
        '
        'cbOutputFormat
        '
        Me.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputFormat.FormattingEnabled = True
        Me.cbOutputFormat.Items.AddRange(New Object() {"AVI", "WMV (Windows Media Video)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "MPEG-TS", "MOV"})
        Me.cbOutputFormat.Location = New System.Drawing.Point(16, 30)
        Me.cbOutputFormat.Name = "cbOutputFormat"
        Me.cbOutputFormat.Size = New System.Drawing.Size(279, 21)
        Me.cbOutputFormat.TabIndex = 129
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(13, 142)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(52, 13)
        Me.label4.TabIndex = 128
        Me.label4.Text = "File name"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(13, 13)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(39, 13)
        Me.label7.TabIndex = 127
        Me.label7.Text = "Format"
        '
        'openFileDialog2
        '
        Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
        '
        'llVideoTutorials
        '
        Me.llVideoTutorials.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llVideoTutorials.AutoSize = True
        Me.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.llVideoTutorials.Location = New System.Drawing.Point(749, 4)
        Me.llVideoTutorials.Name = "llVideoTutorials"
        Me.llVideoTutorials.Size = New System.Drawing.Size(68, 13)
        Me.llVideoTutorials.TabIndex = 92
        Me.llVideoTutorials.TabStop = True
        Me.llVideoTutorials.Text = "Video tutorial"
        '
        'label34
        '
        Me.label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(484, 4)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(214, 13)
        Me.label34.TabIndex = 101
        Me.label34.Text = "Much more features available in Main Demo"
        '
        'lbTimestamp
        '
        Me.lbTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTimestamp.AutoSize = True
        Me.lbTimestamp.Location = New System.Drawing.Point(534, 359)
        Me.lbTimestamp.Name = "lbTimestamp"
        Me.lbTimestamp.Size = New System.Drawing.Size(126, 13)
        Me.lbTimestamp.TabIndex = 106
        Me.lbTimestamp.Text = "Recording time: 00:00:00"
        '
        'rbCapture
        '
        Me.rbCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbCapture.AutoSize = True
        Me.rbCapture.Location = New System.Drawing.Point(458, 357)
        Me.rbCapture.Name = "rbCapture"
        Me.rbCapture.Size = New System.Drawing.Size(62, 17)
        Me.rbCapture.TabIndex = 105
        Me.rbCapture.Text = "Capture"
        Me.rbCapture.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(389, 357)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(63, 17)
        Me.rbPreview.TabIndex = 104
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'btSaveScreenshot
        '
        Me.btSaveScreenshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSaveScreenshot.Location = New System.Drawing.Point(690, 387)
        Me.btSaveScreenshot.Name = "btSaveScreenshot"
        Me.btSaveScreenshot.Size = New System.Drawing.Size(127, 23)
        Me.btSaveScreenshot.TabIndex = 109
        Me.btSaveScreenshot.Text = "Save snapshot"
        Me.btSaveScreenshot.UseVisualStyleBackColor = True
        '
        'btResume
        '
        Me.btResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btResume.Location = New System.Drawing.Point(598, 387)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(55, 23)
        Me.btResume.TabIndex = 108
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPause.Location = New System.Drawing.Point(537, 387)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(55, 23)
        Me.btPause.TabIndex = 107
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(389, 26)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(428, 312)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 110
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 416)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.btSaveScreenshot)
        Me.Controls.Add(Me.btResume)
        Me.Controls.Add(Me.btPause)
        Me.Controls.Add(Me.lbTimestamp)
        Me.Controls.Add(Me.rbCapture)
        Me.Controls.Add(Me.rbPreview)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.llVideoTutorials)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.tcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Screen Capture Demo - Video Capture SDK .Net"
        Me.tabPage3.ResumeLayout(false)
        Me.tabPage3.PerformLayout
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage4.ResumeLayout(false)
        Me.tabPage4.PerformLayout
        Me.tcMain.ResumeLayout(false)
        Me.tabPage1.ResumeLayout(false)
        Me.tabPage1.PerformLayout
        Me.tabPage2.ResumeLayout(false)
        Me.tabPage2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents cbUseBestAudioInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents btAudioInputDeviceSettings As System.Windows.Forms.Button
    Private WithEvents cbAudioInputLine As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents cbRecordAudio As System.Windows.Forms.CheckBox
    Private WithEvents btScreenCaptureUpdate As System.Windows.Forms.Button
    Private WithEvents cbScreenCapture_GrabMouseCursor As System.Windows.Forms.CheckBox
    Private WithEvents label79 As System.Windows.Forms.Label
    Private WithEvents edScreenFrameRate As System.Windows.Forms.TextBox
    Private WithEvents label43 As System.Windows.Forms.Label
    Private WithEvents edScreenBottom As System.Windows.Forms.TextBox
    Private WithEvents label42 As System.Windows.Forms.Label
    Private WithEvents edScreenTop As System.Windows.Forms.TextBox
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents edScreenRight As System.Windows.Forms.TextBox
    Private WithEvents label40 As System.Windows.Forms.Label
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents edScreenLeft As System.Windows.Forms.TextBox
    Private WithEvents tcMain As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents rbScreenCustomArea As System.Windows.Forms.RadioButton
    Private WithEvents rbScreenFullScreen As System.Windows.Forms.RadioButton
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents openFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents llVideoTutorials As System.Windows.Forms.LinkLabel
    Private WithEvents cbScreenCaptureDisplayIndex As System.Windows.Forms.ComboBox
    Private WithEvents label93 As System.Windows.Forms.Label
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents cbScreenCapture_DesktopDuplication As System.Windows.Forms.CheckBox
    Private WithEvents cbDebugMode As CheckBox
    Private WithEvents mmLog As TextBox
    Private WithEvents edOutput As TextBox
    Private WithEvents lbInfo As Label
    Private WithEvents btOutputConfigure As Button
    Private WithEvents cbOutputFormat As ComboBox
    Private WithEvents label4 As Label
    Private WithEvents label7 As Label
    Private WithEvents btSelectOutput As Button
    Private WithEvents lbTimestamp As Label
    Private WithEvents rbCapture As RadioButton
    Private WithEvents rbPreview As RadioButton
    Private WithEvents btSaveScreenshot As Button
    Private WithEvents btResume As Button
    Private WithEvents btPause As Button
    Private WithEvents Label5 As Label
    Private WithEvents cbFlipY As CheckBox
    Private WithEvents cbFlipX As CheckBox
    Private WithEvents cbInvert As CheckBox
    Private WithEvents cbGreyscale As CheckBox
    Private WithEvents label201 As Label
    Private WithEvents tbDarkness As TrackBar
    Private WithEvents label200 As Label
    Private WithEvents label199 As Label
    Private WithEvents label198 As Label
    Private WithEvents tbContrast As TrackBar
    Private WithEvents tbLightness As TrackBar
    Private WithEvents tbSaturation As TrackBar
    Private WithEvents label3 As Label
    Private WithEvents btTextLogoAdd As Button
    Private WithEvents btLogoRemove As Button
    Private WithEvents btLogoEdit As Button
    Private WithEvents lbLogos As ListBox
    Private WithEvents btImageLogoAdd As Button
    Private WithEvents Label1 As Label
    Private WithEvents lbScreenSourceWindowText As Label
    Private WithEvents btScreenSourceWindowSelect As Button
    Private WithEvents rbScreenCaptureWindow As RadioButton
    Private WithEvents textBox1 As TextBox
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
