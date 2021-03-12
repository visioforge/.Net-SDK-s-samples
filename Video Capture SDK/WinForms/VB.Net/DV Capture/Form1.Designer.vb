Imports VisioForge.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
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
        Me.rbCapture = New System.Windows.Forms.RadioButton()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.cbDeinterlaceCAVT = New System.Windows.Forms.CheckBox()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.btDVFF = New System.Windows.Forms.Button()
        Me.groupBox21 = New System.Windows.Forms.GroupBox()
        Me.rbDVResDC = New System.Windows.Forms.RadioButton()
        Me.rbDVResQuarter = New System.Windows.Forms.RadioButton()
        Me.rbDVResHalf = New System.Windows.Forms.RadioButton()
        Me.rbDVResFull = New System.Windows.Forms.RadioButton()
        Me.btDVPause = New System.Windows.Forms.Button()
        Me.btDVRewind = New System.Windows.Forms.Button()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.btDVStepFWD = New System.Windows.Forms.Button()
        Me.btDVStepRev = New System.Windows.Forms.Button()
        Me.btDVStop = New System.Windows.Forms.Button()
        Me.btDVPlay = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cbUseBestVideoInputFormat = New System.Windows.Forms.CheckBox()
        Me.btVideoCaptureDeviceSettings = New System.Windows.Forms.Button()
        Me.label18 = New System.Windows.Forms.Label()
        Me.cbFramerate = New System.Windows.Forms.ComboBox()
        Me.cbVideoInputFormat = New System.Windows.Forms.ComboBox()
        Me.rbPreview = New System.Windows.Forms.RadioButton()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.cbVideoInputDevice = New System.Windows.Forms.ComboBox()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label55 = New System.Windows.Forms.Label()
        Me.tbAudioBalance = New System.Windows.Forms.TrackBar()
        Me.label54 = New System.Windows.Forms.Label()
        Me.tbAudioVolume = New System.Windows.Forms.TrackBar()
        Me.cbRecordAudio = New System.Windows.Forms.CheckBox()
        Me.cbAudioOutputDevice = New System.Windows.Forms.ComboBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btOutputConfigure = New System.Windows.Forms.Button()
        Me.cbOutputFormat = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.fontDialog1 = New System.Windows.Forms.FontDialog()
        Me.llVideoTutorials = New System.Windows.Forms.LinkLabel()
        Me.VideoCapture1 = New VisioForge.Controls.UI.WinForms.VideoCapture()
        Me.btSaveScreenshot = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.lbTimestamp = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tabPage3.SuspendLayout
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage4.SuspendLayout
        Me.groupBox21.SuspendLayout
        Me.groupBox3.SuspendLayout
        Me.tcMain.SuspendLayout
        Me.tabPage1.SuspendLayout
        CType(Me.tbAudioBalance,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioVolume,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage2.SuspendLayout
        Me.SuspendLayout
        '
        'rbCapture
        '
        Me.rbCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.rbCapture.AutoSize = true
        Me.rbCapture.Location = New System.Drawing.Point(458, 389)
        Me.rbCapture.Name = "rbCapture"
        Me.rbCapture.Size = New System.Drawing.Size(62, 17)
        Me.rbCapture.TabIndex = 72
        Me.rbCapture.Text = "Capture"
        Me.rbCapture.UseVisualStyleBackColor = true
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.cbDeinterlaceCAVT)
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
        Me.tabPage3.Controls.Add(Me.Label5)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(370, 380)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Video effects"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'cbDeinterlaceCAVT
        '
        Me.cbDeinterlaceCAVT.AutoSize = True
        Me.cbDeinterlaceCAVT.Checked = True
        Me.cbDeinterlaceCAVT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDeinterlaceCAVT.Location = New System.Drawing.Point(20, 307)
        Me.cbDeinterlaceCAVT.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDeinterlaceCAVT.Name = "cbDeinterlaceCAVT"
        Me.cbDeinterlaceCAVT.Size = New System.Drawing.Size(117, 17)
        Me.cbDeinterlaceCAVT.TabIndex = 106
        Me.cbDeinterlaceCAVT.Text = "Deinterlace (CAVT)"
        Me.cbDeinterlaceCAVT.UseVisualStyleBackColor = True
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = True
        Me.cbFlipY.Location = New System.Drawing.Point(220, 281)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipY.TabIndex = 104
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = True
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = True
        Me.cbFlipX.Location = New System.Drawing.Point(160, 281)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipX.TabIndex = 103
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = True
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = True
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(100, 281)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbInvert.TabIndex = 102
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = True
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = True
        Me.cbGreyscale.Location = New System.Drawing.Point(20, 281)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGreyscale.TabIndex = 101
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = True
        '
        'label201
        '
        Me.label201.AutoSize = True
        Me.label201.Location = New System.Drawing.Point(153, 211)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(52, 13)
        Me.label201.TabIndex = 100
        Me.label201.Text = "Darkness"
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(153, 230)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbDarkness.TabIndex = 99
        '
        'label200
        '
        Me.label200.AutoSize = True
        Me.label200.Location = New System.Drawing.Point(17, 211)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(46, 13)
        Me.label200.TabIndex = 98
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = True
        Me.label199.Location = New System.Drawing.Point(153, 159)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(55, 13)
        Me.label199.TabIndex = 97
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = True
        Me.label198.Location = New System.Drawing.Point(17, 159)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(52, 13)
        Me.label198.TabIndex = 96
        Me.label198.Text = "Lightness"
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(14, 230)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbContrast.TabIndex = 95
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(14, 174)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(130, 45)
        Me.tbLightness.TabIndex = 94
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(153, 174)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbSaturation.TabIndex = 93
        Me.tbSaturation.Value = 255
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(11, 5)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(95, 13)
        Me.label3.TabIndex = 92
        Me.label3.Text = "Text / image logos"
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(119, 122)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(99, 23)
        Me.btTextLogoAdd.TabIndex = 91
        Me.btTextLogoAdd.Text = "Add text logo"
        Me.btTextLogoAdd.UseVisualStyleBackColor = True
        '
        'btLogoRemove
        '
        Me.btLogoRemove.Location = New System.Drawing.Point(300, 122)
        Me.btLogoRemove.Name = "btLogoRemove"
        Me.btLogoRemove.Size = New System.Drawing.Size(59, 23)
        Me.btLogoRemove.TabIndex = 90
        Me.btLogoRemove.Text = "Remove"
        Me.btLogoRemove.UseVisualStyleBackColor = True
        '
        'btLogoEdit
        '
        Me.btLogoEdit.Location = New System.Drawing.Point(235, 122)
        Me.btLogoEdit.Name = "btLogoEdit"
        Me.btLogoEdit.Size = New System.Drawing.Size(59, 23)
        Me.btLogoEdit.TabIndex = 89
        Me.btLogoEdit.Text = "Edit"
        Me.btLogoEdit.UseVisualStyleBackColor = True
        '
        'lbLogos
        '
        Me.lbLogos.FormattingEnabled = True
        Me.lbLogos.Location = New System.Drawing.Point(14, 21)
        Me.lbLogos.Name = "lbLogos"
        Me.lbLogos.Size = New System.Drawing.Size(345, 95)
        Me.lbLogos.TabIndex = 88
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(14, 122)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(99, 23)
        Me.btImageLogoAdd.TabIndex = 87
        Me.btImageLogoAdd.Text = "Add image logo"
        Me.btImageLogoAdd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(239, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "More effects and settings available in Main Demo"
        '
        'openFileDialog2
        '
        Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
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
        Me.cbDebugMode.Location = New System.Drawing.Point(12, 11)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 78
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'mmLog
        '
        Me.mmLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mmLog.Location = New System.Drawing.Point(12, 34)
        Me.mmLog.Multiline = True
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(346, 343)
        Me.mmLog.TabIndex = 77
        '
        'btDVFF
        '
        Me.btDVFF.Location = New System.Drawing.Point(282, 22)
        Me.btDVFF.Name = "btDVFF"
        Me.btDVFF.Size = New System.Drawing.Size(60, 23)
        Me.btDVFF.TabIndex = 4
        Me.btDVFF.Text = "F.F."
        Me.btDVFF.UseVisualStyleBackColor = True
        '
        'groupBox21
        '
        Me.groupBox21.Controls.Add(Me.rbDVResDC)
        Me.groupBox21.Controls.Add(Me.rbDVResQuarter)
        Me.groupBox21.Controls.Add(Me.rbDVResHalf)
        Me.groupBox21.Controls.Add(Me.rbDVResFull)
        Me.groupBox21.Location = New System.Drawing.Point(1, 115)
        Me.groupBox21.Name = "groupBox21"
        Me.groupBox21.Size = New System.Drawing.Size(361, 45)
        Me.groupBox21.TabIndex = 130
        Me.groupBox21.TabStop = False
        Me.groupBox21.Text = "Resolution"
        '
        'rbDVResDC
        '
        Me.rbDVResDC.AutoSize = True
        Me.rbDVResDC.Location = New System.Drawing.Point(275, 18)
        Me.rbDVResDC.Name = "rbDVResDC"
        Me.rbDVResDC.Size = New System.Drawing.Size(40, 17)
        Me.rbDVResDC.TabIndex = 3
        Me.rbDVResDC.Text = "DC"
        Me.rbDVResDC.UseVisualStyleBackColor = True
        '
        'rbDVResQuarter
        '
        Me.rbDVResQuarter.AutoSize = True
        Me.rbDVResQuarter.Location = New System.Drawing.Point(179, 18)
        Me.rbDVResQuarter.Name = "rbDVResQuarter"
        Me.rbDVResQuarter.Size = New System.Drawing.Size(60, 17)
        Me.rbDVResQuarter.TabIndex = 2
        Me.rbDVResQuarter.Text = "Quarter"
        Me.rbDVResQuarter.UseVisualStyleBackColor = True
        '
        'rbDVResHalf
        '
        Me.rbDVResHalf.AutoSize = True
        Me.rbDVResHalf.Location = New System.Drawing.Point(100, 18)
        Me.rbDVResHalf.Name = "rbDVResHalf"
        Me.rbDVResHalf.Size = New System.Drawing.Size(44, 17)
        Me.rbDVResHalf.TabIndex = 1
        Me.rbDVResHalf.Text = "Half"
        Me.rbDVResHalf.UseVisualStyleBackColor = True
        '
        'rbDVResFull
        '
        Me.rbDVResFull.AutoSize = True
        Me.rbDVResFull.Checked = True
        Me.rbDVResFull.Location = New System.Drawing.Point(18, 18)
        Me.rbDVResFull.Name = "rbDVResFull"
        Me.rbDVResFull.Size = New System.Drawing.Size(41, 17)
        Me.rbDVResFull.TabIndex = 0
        Me.rbDVResFull.TabStop = True
        Me.rbDVResFull.Text = "Full"
        Me.rbDVResFull.UseVisualStyleBackColor = True
        '
        'btDVPause
        '
        Me.btDVPause.Location = New System.Drawing.Point(150, 22)
        Me.btDVPause.Name = "btDVPause"
        Me.btDVPause.Size = New System.Drawing.Size(60, 23)
        Me.btDVPause.TabIndex = 2
        Me.btDVPause.Text = "Pause"
        Me.btDVPause.UseVisualStyleBackColor = True
        '
        'btDVRewind
        '
        Me.btDVRewind.Location = New System.Drawing.Point(18, 22)
        Me.btDVRewind.Name = "btDVRewind"
        Me.btDVRewind.Size = New System.Drawing.Size(60, 23)
        Me.btDVRewind.TabIndex = 0
        Me.btDVRewind.Text = "Rewind"
        Me.btDVRewind.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.btDVStepFWD)
        Me.groupBox3.Controls.Add(Me.btDVStepRev)
        Me.groupBox3.Controls.Add(Me.btDVFF)
        Me.groupBox3.Controls.Add(Me.btDVStop)
        Me.groupBox3.Controls.Add(Me.btDVPause)
        Me.groupBox3.Controls.Add(Me.btDVPlay)
        Me.groupBox3.Controls.Add(Me.btDVRewind)
        Me.groupBox3.Location = New System.Drawing.Point(1, 266)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(361, 100)
        Me.groupBox3.TabIndex = 129
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Controls"
        '
        'btDVStepFWD
        '
        Me.btDVStepFWD.Location = New System.Drawing.Point(247, 57)
        Me.btDVStepFWD.Name = "btDVStepFWD"
        Me.btDVStepFWD.Size = New System.Drawing.Size(68, 23)
        Me.btDVStepFWD.TabIndex = 6
        Me.btDVStepFWD.Text = "Step FWD"
        Me.btDVStepFWD.UseVisualStyleBackColor = True
        '
        'btDVStepRev
        '
        Me.btDVStepRev.Location = New System.Drawing.Point(48, 57)
        Me.btDVStepRev.Name = "btDVStepRev"
        Me.btDVStepRev.Size = New System.Drawing.Size(68, 23)
        Me.btDVStepRev.TabIndex = 5
        Me.btDVStepRev.Text = "Step REV"
        Me.btDVStepRev.UseVisualStyleBackColor = True
        '
        'btDVStop
        '
        Me.btDVStop.Location = New System.Drawing.Point(216, 22)
        Me.btDVStop.Name = "btDVStop"
        Me.btDVStop.Size = New System.Drawing.Size(60, 23)
        Me.btDVStop.TabIndex = 3
        Me.btDVStop.Text = "Stop"
        Me.btDVStop.UseVisualStyleBackColor = True
        '
        'btDVPlay
        '
        Me.btDVPlay.Location = New System.Drawing.Point(84, 22)
        Me.btDVPlay.Name = "btDVPlay"
        Me.btDVPlay.Size = New System.Drawing.Size(60, 23)
        Me.btDVPlay.TabIndex = 1
        Me.btDVPlay.Text = "Play"
        Me.btDVPlay.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(335, 91)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(21, 13)
        Me.label1.TabIndex = 128
        Me.label1.Text = "fps"
        '
        'cbUseBestVideoInputFormat
        '
        Me.cbUseBestVideoInputFormat.AutoSize = True
        Me.cbUseBestVideoInputFormat.Location = New System.Drawing.Point(184, 71)
        Me.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat"
        Me.cbUseBestVideoInputFormat.Size = New System.Drawing.Size(68, 17)
        Me.cbUseBestVideoInputFormat.TabIndex = 127
        Me.cbUseBestVideoInputFormat.Text = "Use best"
        Me.cbUseBestVideoInputFormat.UseVisualStyleBackColor = True
        '
        'btVideoCaptureDeviceSettings
        '
        Me.btVideoCaptureDeviceSettings.Location = New System.Drawing.Point(265, 33)
        Me.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings"
        Me.btVideoCaptureDeviceSettings.Size = New System.Drawing.Size(66, 23)
        Me.btVideoCaptureDeviceSettings.TabIndex = 126
        Me.btVideoCaptureDeviceSettings.Text = "Settings"
        Me.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = True
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(262, 72)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(57, 13)
        Me.label18.TabIndex = 125
        Me.label18.Text = "Frame rate"
        '
        'cbFramerate
        '
        Me.cbFramerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFramerate.FormattingEnabled = True
        Me.cbFramerate.Location = New System.Drawing.Point(265, 88)
        Me.cbFramerate.Name = "cbFramerate"
        Me.cbFramerate.Size = New System.Drawing.Size(65, 21)
        Me.cbFramerate.TabIndex = 124
        '
        'cbVideoInputFormat
        '
        Me.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFormat.FormattingEnabled = True
        Me.cbVideoInputFormat.Location = New System.Drawing.Point(5, 88)
        Me.cbVideoInputFormat.Name = "cbVideoInputFormat"
        Me.cbVideoInputFormat.Size = New System.Drawing.Size(247, 21)
        Me.cbVideoInputFormat.TabIndex = 123
        '
        'rbPreview
        '
        Me.rbPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(389, 389)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(63, 17)
        Me.rbPreview.TabIndex = 71
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(762, 386)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(62, 23)
        Me.btStop.TabIndex = 70
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(697, 386)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(62, 23)
        Me.btStart.TabIndex = 69
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'cbVideoInputDevice
        '
        Me.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputDevice.FormattingEnabled = True
        Me.cbVideoInputDevice.Location = New System.Drawing.Point(5, 35)
        Me.cbVideoInputDevice.Name = "cbVideoInputDevice"
        Me.cbVideoInputDevice.Size = New System.Drawing.Size(247, 21)
        Me.cbVideoInputDevice.TabIndex = 122
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tabPage1)
        Me.tcMain.Controls.Add(Me.tabPage2)
        Me.tcMain.Controls.Add(Me.tabPage3)
        Me.tcMain.Controls.Add(Me.tabPage4)
        Me.tcMain.Location = New System.Drawing.Point(3, 3)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(378, 406)
        Me.tcMain.TabIndex = 65
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.groupBox21)
        Me.tabPage1.Controls.Add(Me.groupBox3)
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Controls.Add(Me.cbUseBestVideoInputFormat)
        Me.tabPage1.Controls.Add(Me.btVideoCaptureDeviceSettings)
        Me.tabPage1.Controls.Add(Me.label18)
        Me.tabPage1.Controls.Add(Me.cbFramerate)
        Me.tabPage1.Controls.Add(Me.cbVideoInputFormat)
        Me.tabPage1.Controls.Add(Me.cbVideoInputDevice)
        Me.tabPage1.Controls.Add(Me.label13)
        Me.tabPage1.Controls.Add(Me.label11)
        Me.tabPage1.Controls.Add(Me.label55)
        Me.tabPage1.Controls.Add(Me.tbAudioBalance)
        Me.tabPage1.Controls.Add(Me.label54)
        Me.tabPage1.Controls.Add(Me.tbAudioVolume)
        Me.tabPage1.Controls.Add(Me.cbRecordAudio)
        Me.tabPage1.Controls.Add(Me.cbAudioOutputDevice)
        Me.tabPage1.Controls.Add(Me.label15)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(370, 380)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Input"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(1, 72)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(92, 13)
        Me.label13.TabIndex = 121
        Me.label13.Text = "Video input format"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(2, 19)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(95, 13)
        Me.label11.TabIndex = 120
        Me.label11.Text = "Video input device"
        '
        'label55
        '
        Me.label55.AutoSize = True
        Me.label55.Location = New System.Drawing.Point(193, 220)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(46, 13)
        Me.label55.TabIndex = 90
        Me.label55.Text = "Balance"
        '
        'tbAudioBalance
        '
        Me.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioBalance.Location = New System.Drawing.Point(244, 215)
        Me.tbAudioBalance.Maximum = 100
        Me.tbAudioBalance.Minimum = -100
        Me.tbAudioBalance.Name = "tbAudioBalance"
        Me.tbAudioBalance.Size = New System.Drawing.Size(114, 45)
        Me.tbAudioBalance.TabIndex = 89
        Me.tbAudioBalance.TickFrequency = 5
        Me.tbAudioBalance.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'label54
        '
        Me.label54.AutoSize = True
        Me.label54.Location = New System.Drawing.Point(2, 220)
        Me.label54.Name = "label54"
        Me.label54.Size = New System.Drawing.Size(42, 13)
        Me.label54.TabIndex = 88
        Me.label54.Text = "Volume"
        '
        'tbAudioVolume
        '
        Me.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioVolume.Location = New System.Drawing.Point(49, 215)
        Me.tbAudioVolume.Maximum = 100
        Me.tbAudioVolume.Minimum = 20
        Me.tbAudioVolume.Name = "tbAudioVolume"
        Me.tbAudioVolume.Size = New System.Drawing.Size(116, 45)
        Me.tbAudioVolume.TabIndex = 87
        Me.tbAudioVolume.TickFrequency = 10
        Me.tbAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAudioVolume.Value = 80
        '
        'cbRecordAudio
        '
        Me.cbRecordAudio.AutoSize = True
        Me.cbRecordAudio.Checked = True
        Me.cbRecordAudio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRecordAudio.Location = New System.Drawing.Point(248, 171)
        Me.cbRecordAudio.Name = "cbRecordAudio"
        Me.cbRecordAudio.Size = New System.Drawing.Size(115, 17)
        Me.cbRecordAudio.TabIndex = 86
        Me.cbRecordAudio.Text = "Play/Record audio"
        Me.cbRecordAudio.UseVisualStyleBackColor = True
        '
        'cbAudioOutputDevice
        '
        Me.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioOutputDevice.FormattingEnabled = True
        Me.cbAudioOutputDevice.Location = New System.Drawing.Point(4, 188)
        Me.cbAudioOutputDevice.Name = "cbAudioOutputDevice"
        Me.cbAudioOutputDevice.Size = New System.Drawing.Size(354, 21)
        Me.cbAudioOutputDevice.TabIndex = 85
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(1, 172)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(102, 13)
        Me.label15.TabIndex = 84
        Me.label15.Text = "Audio output device"
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.btSelectOutput)
        Me.tabPage2.Controls.Add(Me.edOutput)
        Me.tabPage2.Controls.Add(Me.label4)
        Me.tabPage2.Controls.Add(Me.lbInfo)
        Me.tabPage2.Controls.Add(Me.btOutputConfigure)
        Me.tabPage2.Controls.Add(Me.cbOutputFormat)
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
        Me.btSelectOutput.Location = New System.Drawing.Point(341, 146)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(24, 23)
        Me.btSelectOutput.TabIndex = 121
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = True
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(13, 148)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(322, 20)
        Me.edOutput.TabIndex = 120
        Me.edOutput.Text = "c:\capture.avi"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(10, 132)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(52, 13)
        Me.label4.TabIndex = 119
        Me.label4.Text = "File name"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Location = New System.Drawing.Point(10, 57)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(267, 13)
        Me.lbInfo.TabIndex = 118
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btOutputConfigure
        '
        Me.btOutputConfigure.Location = New System.Drawing.Point(13, 73)
        Me.btOutputConfigure.Name = "btOutputConfigure"
        Me.btOutputConfigure.Size = New System.Drawing.Size(75, 23)
        Me.btOutputConfigure.TabIndex = 117
        Me.btOutputConfigure.Text = "Configure"
        Me.btOutputConfigure.UseVisualStyleBackColor = True
        '
        'cbOutputFormat
        '
        Me.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputFormat.FormattingEnabled = True
        Me.cbOutputFormat.Items.AddRange(New Object() {"DV", "DV (Without reencoding)", "AVI", "WMV (Windows Media Video)", "MP4 (v10 engine)", "MP4 (v11 engine, CPU/GPU)", "Animated GIF", "MPEG-TS", "MOV"})
        Me.cbOutputFormat.Location = New System.Drawing.Point(13, 29)
        Me.cbOutputFormat.Name = "cbOutputFormat"
        Me.cbOutputFormat.Size = New System.Drawing.Size(279, 21)
        Me.cbOutputFormat.TabIndex = 116
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(10, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(39, 13)
        Me.label7.TabIndex = 114
        Me.label7.Text = "Format"
        '
        'fontDialog1
        '
        Me.fontDialog1.Color = System.Drawing.Color.White
        Me.fontDialog1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fontDialog1.FontMustExist = True
        Me.fontDialog1.ShowColor = True
        '
        'llVideoTutorials
        '
        Me.llVideoTutorials.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llVideoTutorials.AutoSize = True
        Me.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.llVideoTutorials.Location = New System.Drawing.Point(756, 9)
        Me.llVideoTutorials.Name = "llVideoTutorials"
        Me.llVideoTutorials.Size = New System.Drawing.Size(68, 13)
        Me.llVideoTutorials.TabIndex = 92
        Me.llVideoTutorials.TabStop = True
        Me.llVideoTutorials.Text = "Video tutorial"
        '
        'VideoCapture1
        '
        Me.VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = False
        Me.VideoCapture1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VideoCapture1.Audio_CaptureDevice = ""
        Me.VideoCapture1.Audio_CaptureDevice_CustomLatency = 0
        Me.VideoCapture1.Audio_CaptureDevice_Format = ""
        Me.VideoCapture1.Audio_CaptureDevice_Format_UseBest = True
        Me.VideoCapture1.Audio_CaptureDevice_Line = ""
        Me.VideoCapture1.Audio_CaptureDevice_MasterDevice = Nothing
        Me.VideoCapture1.Audio_CaptureDevice_MasterDevice_Format = Nothing
        Me.VideoCapture1.Audio_CaptureDevice_Path = Nothing
        Me.VideoCapture1.Audio_CaptureSourceFilter = Nothing
        Me.VideoCapture1.Audio_Channel_Mapper = Nothing
        Me.VideoCapture1.Audio_Decoder = Nothing
        Me.VideoCapture1.Audio_Effects_Enabled = False
        Me.VideoCapture1.Audio_Effects_UseLegacyEffects = False
        Me.VideoCapture1.Audio_Enhancer_Enabled = False
        Me.VideoCapture1.Audio_OutputDevice = "Default DirectSound Device"
        Me.VideoCapture1.Audio_PCM_Converter = Nothing
        Me.VideoCapture1.Audio_PlayAudio = True
        Me.VideoCapture1.Audio_RecordAudio = True
        Me.VideoCapture1.Audio_Sample_Grabber_Enabled = False
        Me.VideoCapture1.Audio_VUMeter_Enabled = False
        Me.VideoCapture1.Audio_VUMeter_Pro_Enabled = False
        Me.VideoCapture1.Audio_VUMeter_Pro_Volume = 100
        Me.VideoCapture1.BackColor = System.Drawing.Color.Black
        Me.VideoCapture1.Barcode_Reader_Enabled = False
        Me.VideoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.[Auto]
        Me.VideoCapture1.BDA_Source = Nothing
        Me.VideoCapture1.ChromaKey = Nothing
        Me.VideoCapture1.Custom_Source = Nothing
        Me.VideoCapture1.CustomRedist_Auto = True
        Me.VideoCapture1.CustomRedist_Enabled = False
        Me.VideoCapture1.CustomRedist_Path = Nothing
        Me.VideoCapture1.Debug_Dir = ""
        Me.VideoCapture1.Debug_DisableMessageDialogs = False
        Me.VideoCapture1.Debug_Mode = False
        Me.VideoCapture1.Debug_Telemetry = False
        Me.VideoCapture1.Decklink_Input = VisioForge.Types.DecklinkInput.[Auto]
        Me.VideoCapture1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.[Auto]
        Me.VideoCapture1.Decklink_Input_IREUSA = False
        Me.VideoCapture1.Decklink_Input_SMPTE = False
        Me.VideoCapture1.Decklink_Output = Nothing
        Me.VideoCapture1.Decklink_Source = Nothing
        Me.VideoCapture1.DirectCapture_Muxer = Nothing
        Me.VideoCapture1.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full
        Me.VideoCapture1.Face_Tracking = Nothing
        Me.VideoCapture1.IP_Camera_Source = Nothing
        Me.VideoCapture1.Location = New System.Drawing.Point(388, 25)
        Me.VideoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture
        Me.VideoCapture1.Motion_Detection = Nothing
        Me.VideoCapture1.Motion_DetectionEx = Nothing
        Me.VideoCapture1.MPEG_Audio_Decoder = ""
        Me.VideoCapture1.MPEG_Demuxer = Nothing
        Me.VideoCapture1.MPEG_Video_Decoder = ""
        Me.VideoCapture1.MultiScreen_Enabled = False
        Me.VideoCapture1.Name = "VideoCapture1"
        Me.VideoCapture1.Network_Streaming_Audio_Enabled = False
        Me.VideoCapture1.Network_Streaming_Enabled = False
        Me.VideoCapture1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV
        Me.VideoCapture1.Network_Streaming_Network_Port = 100
        Me.VideoCapture1.Network_Streaming_Output = Nothing
        Me.VideoCapture1.Network_Streaming_URL = ""
        Me.VideoCapture1.Network_Streaming_WMV_Maximum_Clients = 10
        Me.VideoCapture1.OSD_Enabled = False
        Me.VideoCapture1.Output_Filename = ""
        Me.VideoCapture1.Output_Format = Nothing
        Me.VideoCapture1.PIP_AddSampleGrabbers = False
        Me.VideoCapture1.PIP_ChromaKeySettings = Nothing
        Me.VideoCapture1.PIP_Mode = VisioForge.Types.VFPIPMode.Custom
        Me.VideoCapture1.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN
        Me.VideoCapture1.Push_Source = Nothing
        Me.VideoCapture1.Screen_Capture_Source = Nothing
        Me.VideoCapture1.SeparateCapture_AutostartCapture = False
        Me.VideoCapture1.SeparateCapture_Enabled = False
        Me.VideoCapture1.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext"
        Me.VideoCapture1.SeparateCapture_FileSizeThreshold = CType(0, Long)
        Me.VideoCapture1.SeparateCapture_GMFMode = True
        Me.VideoCapture1.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal
        Me.VideoCapture1.SeparateCapture_TimeThreshold = System.TimeSpan.Parse("00:00:00")
        Me.VideoCapture1.Size = New System.Drawing.Size(435, 326)
        Me.VideoCapture1.Start_DelayEnabled = False
        Me.VideoCapture1.TabIndex = 93
        Me.VideoCapture1.Tags = Nothing
        Me.VideoCapture1.Timeshift_Settings = Nothing
        Me.VideoCapture1.TVTuner_Channel = 0
        Me.VideoCapture1.TVTuner_Country = ""
        Me.VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 80000000
        Me.VideoCapture1.TVTuner_FM_Tuning_Step = 160000000
        Me.VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 0
        Me.VideoCapture1.TVTuner_Frequency = 0
        Me.VideoCapture1.TVTuner_InputType = ""
        Me.VideoCapture1.TVTuner_Mode = VisioForge.Types.VFTVTunerMode.[Default]
        Me.VideoCapture1.TVTuner_Name = ""
        Me.VideoCapture1.TVTuner_TVFormat = VisioForge.Types.VFTVTunerVideoFormat.PAL_D
        Me.VideoCapture1.Video_CaptureDevice = ""
        Me.VideoCapture1.Video_CaptureDevice_Format = ""
        Me.VideoCapture1.Video_CaptureDevice_Format_UseBest = True
        Me.VideoCapture1.Video_CaptureDevice_FrameRate = 0R
        Me.VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = ""
        Me.VideoCapture1.Video_CaptureDevice_IsAudioSource = False
        Me.VideoCapture1.Video_CaptureDevice_Path = Nothing
        Me.VideoCapture1.Video_CaptureDevice_UseClosedCaptions = False
        Me.VideoCapture1.Video_CaptureDevice_UseRAWSampleGrabber = False
        Me.VideoCapture1.Video_Crop = Nothing
        Me.VideoCapture1.Video_Decoder = Nothing
        Me.VideoCapture1.Video_Effects_AllowMultipleStreams = False
        Me.VideoCapture1.Video_Effects_Enabled = False
        Me.VideoCapture1.Video_Effects_GPU_Enabled = False
        Me.VideoCapture1.Video_Effects_MergeImageLogos = False
        Me.VideoCapture1.Video_Effects_MergeTextLogos = False
        Me.VideoCapture1.Video_Resize = Nothing
        Me.VideoCapture1.Video_ResizeOrCrop_Enabled = False
        Me.VideoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone
        Me.VideoCapture1.Video_Sample_Grabber_Enabled = False
        Me.VideoCapture1.Video_Sample_Grabber_UseForVideoEffects = False
        Me.VideoCapture1.Video_Still_Frames_Grabber_Enabled = False
        Me.VideoCapture1.Virtual_Camera_Output_Enabled = False
        Me.VideoCapture1.Virtual_Camera_Output_LicenseKey = Nothing
        Me.VideoCapture1.VLC_Path = Nothing
        '
        'btSaveScreenshot
        '
        Me.btSaveScreenshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSaveScreenshot.Location = New System.Drawing.Point(697, 357)
        Me.btSaveScreenshot.Name = "btSaveScreenshot"
        Me.btSaveScreenshot.Size = New System.Drawing.Size(126, 23)
        Me.btSaveScreenshot.TabIndex = 103
        Me.btSaveScreenshot.Text = "Save snapshot"
        Me.btSaveScreenshot.UseVisualStyleBackColor = true
        '
        'btResume
        '
        Me.btResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btResume.Location = New System.Drawing.Point(614, 386)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(55, 23)
        Me.btResume.TabIndex = 102
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = true
        '
        'btPause
        '
        Me.btPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btPause.Location = New System.Drawing.Point(553, 386)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(55, 23)
        Me.btPause.TabIndex = 101
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = true
        '
        'lbTimestamp
        '
        Me.lbTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lbTimestamp.AutoSize = true
        Me.lbTimestamp.Location = New System.Drawing.Point(385, 362)
        Me.lbTimestamp.Name = "lbTimestamp"
        Me.lbTimestamp.Size = New System.Drawing.Size(126, 13)
        Me.lbTimestamp.TabIndex = 100
        Me.lbTimestamp.Text = "Recording time: 00:00:00"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = true
        Me.label2.Location = New System.Drawing.Point(486, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(214, 13)
        Me.label2.TabIndex = 104
        Me.label2.Text = "Much more features available in Main Demo"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 421)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btSaveScreenshot)
        Me.Controls.Add(Me.btResume)
        Me.Controls.Add(Me.btPause)
        Me.Controls.Add(Me.lbTimestamp)
        Me.Controls.Add(Me.VideoCapture1)
        Me.Controls.Add(Me.llVideoTutorials)
        Me.Controls.Add(Me.rbCapture)
        Me.Controls.Add(Me.rbPreview)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.tcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "DV Capture Demo - Video Capture SDK .Net"
        Me.tabPage3.ResumeLayout(false)
        Me.tabPage3.PerformLayout
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage4.ResumeLayout(false)
        Me.tabPage4.PerformLayout
        Me.groupBox21.ResumeLayout(false)
        Me.groupBox21.PerformLayout
        Me.groupBox3.ResumeLayout(false)
        Me.tcMain.ResumeLayout(false)
        Me.tabPage1.ResumeLayout(false)
        Me.tabPage1.PerformLayout
        CType(Me.tbAudioBalance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage2.ResumeLayout(false)
        Me.tabPage2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents rbCapture As System.Windows.Forms.RadioButton
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents openFileDialog2 As System.Windows.Forms.OpenFileDialog
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents btDVFF As System.Windows.Forms.Button
    Private WithEvents groupBox21 As System.Windows.Forms.GroupBox
    Private WithEvents rbDVResDC As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResQuarter As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResHalf As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResFull As System.Windows.Forms.RadioButton
    Private WithEvents btDVPause As System.Windows.Forms.Button
    Private WithEvents btDVRewind As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btDVStepFWD As System.Windows.Forms.Button
    Private WithEvents btDVStepRev As System.Windows.Forms.Button
    Private WithEvents btDVStop As System.Windows.Forms.Button
    Private WithEvents btDVPlay As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cbUseBestVideoInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents btVideoCaptureDeviceSettings As System.Windows.Forms.Button
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbFramerate As System.Windows.Forms.ComboBox
    Private WithEvents cbVideoInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents rbPreview As System.Windows.Forms.RadioButton
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents cbVideoInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents tcMain As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label55 As System.Windows.Forms.Label
    Private WithEvents tbAudioBalance As System.Windows.Forms.TrackBar
    Private WithEvents label54 As System.Windows.Forms.Label
    Private WithEvents tbAudioVolume As System.Windows.Forms.TrackBar
    Private WithEvents cbRecordAudio As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioOutputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents llVideoTutorials As System.Windows.Forms.LinkLabel
    Friend WithEvents VideoCapture1 As VisioForge.Controls.UI.WinForms.VideoCapture
    Private WithEvents lbInfo As Label
    Private WithEvents btOutputConfigure As Button
    Private WithEvents cbOutputFormat As ComboBox
    Private WithEvents label7 As Label
    Private WithEvents cbDebugMode As CheckBox
    Private WithEvents mmLog As TextBox
    Private WithEvents btSelectOutput As Button
    Private WithEvents edOutput As TextBox
    Private WithEvents label4 As Label
    Private WithEvents btSaveScreenshot As Button
    Private WithEvents btResume As Button
    Private WithEvents btPause As Button
    Private WithEvents lbTimestamp As Label
    Private WithEvents label2 As Label
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
    Private WithEvents Label5 As Label
    Private WithEvents cbDeinterlaceCAVT As CheckBox
End Class
