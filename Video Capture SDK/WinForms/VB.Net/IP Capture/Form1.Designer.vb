Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()

            If (onvifControl IsNot Nothing) Then
                onvifControl.Dispose()
                onvifControl = Nothing
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
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.tabControl15 = New System.Windows.Forms.TabControl()
        Me.tabPage144 = New System.Windows.Forms.TabPage()
        Me.btListONVIFSources = New System.Windows.Forms.Button()
        Me.cbIPURL = New System.Windows.Forms.ComboBox()
        Me.btListNDISources = New System.Windows.Forms.Button()
        Me.lbNDI = New System.Windows.Forms.LinkLabel()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label165 = New System.Windows.Forms.Label()
        Me.cbIPCameraONVIF = New System.Windows.Forms.CheckBox()
        Me.cbIPDisconnect = New System.Windows.Forms.CheckBox()
        Me.edIPForcedFramerateID = New System.Windows.Forms.TextBox()
        Me.label344 = New System.Windows.Forms.Label()
        Me.edIPForcedFramerate = New System.Windows.Forms.TextBox()
        Me.label295 = New System.Windows.Forms.Label()
        Me.cbIPCameraType = New System.Windows.Forms.ComboBox()
        Me.edIPPassword = New System.Windows.Forms.TextBox()
        Me.label167 = New System.Windows.Forms.Label()
        Me.edIPLogin = New System.Windows.Forms.TextBox()
        Me.label166 = New System.Windows.Forms.Label()
        Me.cbIPAudioCapture = New System.Windows.Forms.CheckBox()
        Me.label168 = New System.Windows.Forms.Label()
        Me.tabPage146 = New System.Windows.Forms.TabPage()
        Me.cbVLCZeroClockJitter = New System.Windows.Forms.CheckBox()
        Me.edVLCCacheSize = New System.Windows.Forms.TextBox()
        Me.label312 = New System.Windows.Forms.Label()
        Me.tabPage145 = New System.Windows.Forms.TabPage()
        Me.edONVIFPassword = New System.Windows.Forms.TextBox()
        Me.Label379 = New System.Windows.Forms.Label()
        Me.edONVIFLogin = New System.Windows.Forms.TextBox()
        Me.Label380 = New System.Windows.Forms.Label()
        Me.edONVIFURL = New System.Windows.Forms.TextBox()
        Me.lbONVIFCameraInfo = New System.Windows.Forms.Label()
        Me.edONVIFLiveVideoURL = New System.Windows.Forms.TextBox()
        Me.label513 = New System.Windows.Forms.Label()
        Me.groupBox42 = New System.Windows.Forms.GroupBox()
        Me.btONVIFPTZSetDefault = New System.Windows.Forms.Button()
        Me.btONVIFRight = New System.Windows.Forms.Button()
        Me.btONVIFLeft = New System.Windows.Forms.Button()
        Me.btONVIFZoomOut = New System.Windows.Forms.Button()
        Me.btONVIFZoomIn = New System.Windows.Forms.Button()
        Me.btONVIFDown = New System.Windows.Forms.Button()
        Me.btONVIFUp = New System.Windows.Forms.Button()
        Me.cbONVIFProfile = New System.Windows.Forms.ComboBox()
        Me.label510 = New System.Windows.Forms.Label()
        Me.btONVIFConnect = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btOutputConfigure = New System.Windows.Forms.Button()
        Me.cbOutputFormat = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
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
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.rbPreview = New System.Windows.Forms.RadioButton()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.llVideoTutorials = New System.Windows.Forms.LinkLabel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.rbCapture = New System.Windows.Forms.RadioButton()
        Me.lbTimestamp = New System.Windows.Forms.Label()
        Me.btSaveScreenshot = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        Me.tcMain.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabControl15.SuspendLayout()
        Me.tabPage144.SuspendLayout()
        Me.tabPage146.SuspendLayout()
        Me.tabPage145.SuspendLayout()
        Me.groupBox42.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.tbDarkness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tabPage1)
        Me.tcMain.Controls.Add(Me.tabPage2)
        Me.tcMain.Controls.Add(Me.TabPage3)
        Me.tcMain.Controls.Add(Me.TabPage7)
        Me.tcMain.Location = New System.Drawing.Point(4, 4)
        Me.tcMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(708, 526)
        Me.tcMain.TabIndex = 53
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.tabControl15)
        Me.tabPage1.Location = New System.Drawing.Point(4, 29)
        Me.tabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage1.Size = New System.Drawing.Size(700, 493)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Input"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'tabControl15
        '
        Me.tabControl15.Controls.Add(Me.tabPage144)
        Me.tabControl15.Controls.Add(Me.tabPage146)
        Me.tabControl15.Controls.Add(Me.tabPage145)
        Me.tabControl15.Location = New System.Drawing.Point(18, 9)
        Me.tabControl15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabControl15.Name = "tabControl15"
        Me.tabControl15.SelectedIndex = 0
        Me.tabControl15.Size = New System.Drawing.Size(670, 448)
        Me.tabControl15.TabIndex = 68
        '
        'tabPage144
        '
        Me.tabPage144.Controls.Add(Me.btListONVIFSources)
        Me.tabPage144.Controls.Add(Me.cbIPURL)
        Me.tabPage144.Controls.Add(Me.btListNDISources)
        Me.tabPage144.Controls.Add(Me.lbNDI)
        Me.tabPage144.Controls.Add(Me.label25)
        Me.tabPage144.Controls.Add(Me.label165)
        Me.tabPage144.Controls.Add(Me.cbIPCameraONVIF)
        Me.tabPage144.Controls.Add(Me.cbIPDisconnect)
        Me.tabPage144.Controls.Add(Me.edIPForcedFramerateID)
        Me.tabPage144.Controls.Add(Me.label344)
        Me.tabPage144.Controls.Add(Me.edIPForcedFramerate)
        Me.tabPage144.Controls.Add(Me.label295)
        Me.tabPage144.Controls.Add(Me.cbIPCameraType)
        Me.tabPage144.Controls.Add(Me.edIPPassword)
        Me.tabPage144.Controls.Add(Me.label167)
        Me.tabPage144.Controls.Add(Me.edIPLogin)
        Me.tabPage144.Controls.Add(Me.label166)
        Me.tabPage144.Controls.Add(Me.cbIPAudioCapture)
        Me.tabPage144.Controls.Add(Me.label168)
        Me.tabPage144.Location = New System.Drawing.Point(4, 29)
        Me.tabPage144.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage144.Name = "tabPage144"
        Me.tabPage144.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage144.Size = New System.Drawing.Size(662, 415)
        Me.tabPage144.TabIndex = 0
        Me.tabPage144.Text = "Main"
        Me.tabPage144.UseVisualStyleBackColor = True
        '
        'btListONVIFSources
        '
        Me.btListONVIFSources.Location = New System.Drawing.Point(440, 152)
        Me.btListONVIFSources.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btListONVIFSources.Name = "btListONVIFSources"
        Me.btListONVIFSources.Size = New System.Drawing.Size(184, 33)
        Me.btListONVIFSources.TabIndex = 92
        Me.btListONVIFSources.Text = "List ONVIF sources"
        Me.btListONVIFSources.UseVisualStyleBackColor = True
        '
        'cbIPURL
        '
        Me.cbIPURL.FormattingEnabled = True
        Me.cbIPURL.Location = New System.Drawing.Point(84, 22)
        Me.cbIPURL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbIPURL.Name = "cbIPURL"
        Me.cbIPURL.Size = New System.Drawing.Size(538, 28)
        Me.cbIPURL.TabIndex = 91
        Me.cbIPURL.Text = "rtsp://192.168.1.101:554/stream1"
        '
        'btListNDISources
        '
        Me.btListNDISources.Location = New System.Drawing.Point(440, 110)
        Me.btListNDISources.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btListNDISources.Name = "btListNDISources"
        Me.btListNDISources.Size = New System.Drawing.Size(184, 33)
        Me.btListNDISources.TabIndex = 90
        Me.btListNDISources.Text = "List NDI sources"
        Me.btListNDISources.UseVisualStyleBackColor = True
        '
        'lbNDI
        '
        Me.lbNDI.AutoSize = True
        Me.lbNDI.Location = New System.Drawing.Point(390, 314)
        Me.lbNDI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNDI.Name = "lbNDI"
        Me.lbNDI.Size = New System.Drawing.Size(126, 20)
        Me.lbNDI.TabIndex = 89
        Me.lbNDI.TabStop = True
        Me.lbNDI.Text = "vendor's website"
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(16, 314)
        Me.label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(380, 20)
        Me.label25.TabIndex = 88
        Me.label25.Text = "To use NDI please install NDI SDK for Windows from"
        '
        'label165
        '
        Me.label165.AutoSize = True
        Me.label165.Location = New System.Drawing.Point(16, 26)
        Me.label165.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label165.Name = "label165"
        Me.label165.Size = New System.Drawing.Size(42, 20)
        Me.label165.TabIndex = 79
        Me.label165.Text = "URL"
        '
        'cbIPCameraONVIF
        '
        Me.cbIPCameraONVIF.AutoSize = True
        Me.cbIPCameraONVIF.Location = New System.Drawing.Point(440, 68)
        Me.cbIPCameraONVIF.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbIPCameraONVIF.Name = "cbIPCameraONVIF"
        Me.cbIPCameraONVIF.Size = New System.Drawing.Size(141, 24)
        Me.cbIPCameraONVIF.TabIndex = 78
        Me.cbIPCameraONVIF.Text = "ONVIF camera"
        Me.cbIPCameraONVIF.UseVisualStyleBackColor = True
        '
        'cbIPDisconnect
        '
        Me.cbIPDisconnect.AutoSize = True
        Me.cbIPDisconnect.Location = New System.Drawing.Point(21, 234)
        Me.cbIPDisconnect.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbIPDisconnect.Name = "cbIPDisconnect"
        Me.cbIPDisconnect.Size = New System.Drawing.Size(198, 24)
        Me.cbIPDisconnect.TabIndex = 75
        Me.cbIPDisconnect.Text = "Notify if connection lost"
        Me.cbIPDisconnect.UseVisualStyleBackColor = True
        '
        'edIPForcedFramerateID
        '
        Me.edIPForcedFramerateID.Location = New System.Drawing.Point(399, 195)
        Me.edIPForcedFramerateID.Name = "edIPForcedFramerateID"
        Me.edIPForcedFramerateID.Size = New System.Drawing.Size(46, 26)
        Me.edIPForcedFramerateID.TabIndex = 71
        Me.edIPForcedFramerateID.Text = "0"
        '
        'label344
        '
        Me.label344.AutoSize = True
        Me.label344.Location = New System.Drawing.Point(246, 197)
        Me.label344.Name = "label344"
        Me.label344.Size = New System.Drawing.Size(148, 20)
        Me.label344.TabIndex = 70
        Me.label344.Text = "Force frame rate ID"
        '
        'edIPForcedFramerate
        '
        Me.edIPForcedFramerate.Location = New System.Drawing.Point(170, 195)
        Me.edIPForcedFramerate.Name = "edIPForcedFramerate"
        Me.edIPForcedFramerate.Size = New System.Drawing.Size(46, 26)
        Me.edIPForcedFramerate.TabIndex = 69
        Me.edIPForcedFramerate.Text = "0"
        '
        'label295
        '
        Me.label295.AutoSize = True
        Me.label295.Location = New System.Drawing.Point(16, 197)
        Me.label295.Name = "label295"
        Me.label295.Size = New System.Drawing.Size(127, 20)
        Me.label295.TabIndex = 68
        Me.label295.Text = "Force frame rate"
        '
        'cbIPCameraType
        '
        Me.cbIPCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIPCameraType.FormattingEnabled = True
        Me.cbIPCameraType.Items.AddRange(New Object() {"Auto (VLC engine)", "Auto (FFMPEG engine)", "Auto (LAV engine)", "Auto (GPU decoding, LAV)", "MMS - WMV", "HTTP MJPEG Low Latency", "RTSP Low Latency TCP", "RTSP Low Latency UDP", "NDI", "NDI (Legacy)"})
        Me.cbIPCameraType.Location = New System.Drawing.Point(84, 65)
        Me.cbIPCameraType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbIPCameraType.Name = "cbIPCameraType"
        Me.cbIPCameraType.Size = New System.Drawing.Size(338, 28)
        Me.cbIPCameraType.TabIndex = 67
        '
        'edIPPassword
        '
        Me.edIPPassword.Location = New System.Drawing.Point(250, 134)
        Me.edIPPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edIPPassword.Name = "edIPPassword"
        Me.edIPPassword.Size = New System.Drawing.Size(148, 26)
        Me.edIPPassword.TabIndex = 66
        '
        'label167
        '
        Me.label167.AutoSize = True
        Me.label167.Location = New System.Drawing.Point(246, 110)
        Me.label167.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label167.Name = "label167"
        Me.label167.Size = New System.Drawing.Size(78, 20)
        Me.label167.TabIndex = 65
        Me.label167.Text = "Password"
        '
        'edIPLogin
        '
        Me.edIPLogin.Location = New System.Drawing.Point(21, 134)
        Me.edIPLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edIPLogin.Name = "edIPLogin"
        Me.edIPLogin.Size = New System.Drawing.Size(148, 26)
        Me.edIPLogin.TabIndex = 64
        '
        'label166
        '
        Me.label166.AutoSize = True
        Me.label166.Location = New System.Drawing.Point(15, 110)
        Me.label166.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label166.Name = "label166"
        Me.label166.Size = New System.Drawing.Size(48, 20)
        Me.label166.TabIndex = 63
        Me.label166.Text = "Login"
        '
        'cbIPAudioCapture
        '
        Me.cbIPAudioCapture.AutoSize = True
        Me.cbIPAudioCapture.Checked = True
        Me.cbIPAudioCapture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIPAudioCapture.Location = New System.Drawing.Point(250, 234)
        Me.cbIPAudioCapture.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbIPAudioCapture.Name = "cbIPAudioCapture"
        Me.cbIPAudioCapture.Size = New System.Drawing.Size(135, 24)
        Me.cbIPAudioCapture.TabIndex = 62
        Me.cbIPAudioCapture.Text = "Capture audio"
        Me.cbIPAudioCapture.UseVisualStyleBackColor = True
        '
        'label168
        '
        Me.label168.AutoSize = True
        Me.label168.Location = New System.Drawing.Point(15, 70)
        Me.label168.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label168.Name = "label168"
        Me.label168.Size = New System.Drawing.Size(59, 20)
        Me.label168.TabIndex = 61
        Me.label168.Text = "Engine"
        '
        'tabPage146
        '
        Me.tabPage146.Controls.Add(Me.cbVLCZeroClockJitter)
        Me.tabPage146.Controls.Add(Me.edVLCCacheSize)
        Me.tabPage146.Controls.Add(Me.label312)
        Me.tabPage146.Location = New System.Drawing.Point(4, 29)
        Me.tabPage146.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage146.Name = "tabPage146"
        Me.tabPage146.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage146.Size = New System.Drawing.Size(662, 415)
        Me.tabPage146.TabIndex = 2
        Me.tabPage146.Text = "VLC"
        Me.tabPage146.UseVisualStyleBackColor = True
        '
        'cbVLCZeroClockJitter
        '
        Me.cbVLCZeroClockJitter.AutoSize = True
        Me.cbVLCZeroClockJitter.Location = New System.Drawing.Point(260, 23)
        Me.cbVLCZeroClockJitter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter"
        Me.cbVLCZeroClockJitter.Size = New System.Drawing.Size(175, 24)
        Me.cbVLCZeroClockJitter.TabIndex = 78
        Me.cbVLCZeroClockJitter.Text = "VLC zero clock jitter"
        Me.cbVLCZeroClockJitter.UseVisualStyleBackColor = True
        '
        'edVLCCacheSize
        '
        Me.edVLCCacheSize.Location = New System.Drawing.Point(178, 20)
        Me.edVLCCacheSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edVLCCacheSize.Name = "edVLCCacheSize"
        Me.edVLCCacheSize.Size = New System.Drawing.Size(46, 26)
        Me.edVLCCacheSize.TabIndex = 77
        Me.edVLCCacheSize.Text = "1000"
        '
        'label312
        '
        Me.label312.AutoSize = True
        Me.label312.Location = New System.Drawing.Point(26, 25)
        Me.label312.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label312.Name = "label312"
        Me.label312.Size = New System.Drawing.Size(154, 20)
        Me.label312.TabIndex = 76
        Me.label312.Text = "VLC cache size (ms)"
        '
        'tabPage145
        '
        Me.tabPage145.Controls.Add(Me.edONVIFPassword)
        Me.tabPage145.Controls.Add(Me.Label379)
        Me.tabPage145.Controls.Add(Me.edONVIFLogin)
        Me.tabPage145.Controls.Add(Me.Label380)
        Me.tabPage145.Controls.Add(Me.edONVIFURL)
        Me.tabPage145.Controls.Add(Me.lbONVIFCameraInfo)
        Me.tabPage145.Controls.Add(Me.edONVIFLiveVideoURL)
        Me.tabPage145.Controls.Add(Me.label513)
        Me.tabPage145.Controls.Add(Me.groupBox42)
        Me.tabPage145.Controls.Add(Me.cbONVIFProfile)
        Me.tabPage145.Controls.Add(Me.label510)
        Me.tabPage145.Controls.Add(Me.btONVIFConnect)
        Me.tabPage145.Location = New System.Drawing.Point(4, 29)
        Me.tabPage145.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage145.Name = "tabPage145"
        Me.tabPage145.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage145.Size = New System.Drawing.Size(662, 415)
        Me.tabPage145.TabIndex = 1
        Me.tabPage145.Text = "ONVIF"
        Me.tabPage145.UseVisualStyleBackColor = True
        '
        'edONVIFPassword
        '
        Me.edONVIFPassword.Location = New System.Drawing.Point(362, 68)
        Me.edONVIFPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edONVIFPassword.Name = "edONVIFPassword"
        Me.edONVIFPassword.Size = New System.Drawing.Size(148, 26)
        Me.edONVIFPassword.TabIndex = 81
        '
        'Label379
        '
        Me.Label379.AutoSize = True
        Me.Label379.Location = New System.Drawing.Point(274, 72)
        Me.Label379.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label379.Name = "Label379"
        Me.Label379.Size = New System.Drawing.Size(78, 20)
        Me.Label379.TabIndex = 80
        Me.Label379.Text = "Password"
        '
        'edONVIFLogin
        '
        Me.edONVIFLogin.Location = New System.Drawing.Point(114, 68)
        Me.edONVIFLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edONVIFLogin.Name = "edONVIFLogin"
        Me.edONVIFLogin.Size = New System.Drawing.Size(148, 26)
        Me.edONVIFLogin.TabIndex = 79
        '
        'Label380
        '
        Me.Label380.AutoSize = True
        Me.Label380.Location = New System.Drawing.Point(18, 72)
        Me.Label380.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label380.Name = "Label380"
        Me.Label380.Size = New System.Drawing.Size(48, 20)
        Me.Label380.TabIndex = 78
        Me.Label380.Text = "Login"
        '
        'edONVIFURL
        '
        Me.edONVIFURL.Location = New System.Drawing.Point(22, 25)
        Me.edONVIFURL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edONVIFURL.Name = "edONVIFURL"
        Me.edONVIFURL.Size = New System.Drawing.Size(487, 26)
        Me.edONVIFURL.TabIndex = 77
        Me.edONVIFURL.Text = "http://192.168.1.200/onvif/device_service"
        '
        'lbONVIFCameraInfo
        '
        Me.lbONVIFCameraInfo.AutoSize = True
        Me.lbONVIFCameraInfo.Location = New System.Drawing.Point(16, 106)
        Me.lbONVIFCameraInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbONVIFCameraInfo.Name = "lbONVIFCameraInfo"
        Me.lbONVIFCameraInfo.Size = New System.Drawing.Size(102, 20)
        Me.lbONVIFCameraInfo.TabIndex = 76
        Me.lbONVIFCameraInfo.Text = "Status: None"
        '
        'edONVIFLiveVideoURL
        '
        Me.edONVIFLiveVideoURL.Location = New System.Drawing.Point(112, 209)
        Me.edONVIFLiveVideoURL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL"
        Me.edONVIFLiveVideoURL.ReadOnly = True
        Me.edONVIFLiveVideoURL.Size = New System.Drawing.Size(517, 26)
        Me.edONVIFLiveVideoURL.TabIndex = 28
        '
        'label513
        '
        Me.label513.AutoSize = True
        Me.label513.Location = New System.Drawing.Point(16, 214)
        Me.label513.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label513.Name = "label513"
        Me.label513.Size = New System.Drawing.Size(87, 20)
        Me.label513.TabIndex = 27
        Me.label513.Text = "Video URL"
        '
        'groupBox42
        '
        Me.groupBox42.Controls.Add(Me.btONVIFPTZSetDefault)
        Me.groupBox42.Controls.Add(Me.btONVIFRight)
        Me.groupBox42.Controls.Add(Me.btONVIFLeft)
        Me.groupBox42.Controls.Add(Me.btONVIFZoomOut)
        Me.groupBox42.Controls.Add(Me.btONVIFZoomIn)
        Me.groupBox42.Controls.Add(Me.btONVIFDown)
        Me.groupBox42.Controls.Add(Me.btONVIFUp)
        Me.groupBox42.Location = New System.Drawing.Point(21, 253)
        Me.groupBox42.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox42.Name = "groupBox42"
        Me.groupBox42.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox42.Size = New System.Drawing.Size(406, 150)
        Me.groupBox42.TabIndex = 26
        Me.groupBox42.TabStop = False
        Me.groupBox42.Text = "PTZ"
        '
        'btONVIFPTZSetDefault
        '
        Me.btONVIFPTZSetDefault.Location = New System.Drawing.Point(195, 64)
        Me.btONVIFPTZSetDefault.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFPTZSetDefault.Name = "btONVIFPTZSetDefault"
        Me.btONVIFPTZSetDefault.Size = New System.Drawing.Size(174, 33)
        Me.btONVIFPTZSetDefault.TabIndex = 6
        Me.btONVIFPTZSetDefault.Text = "Set default position"
        Me.btONVIFPTZSetDefault.UseVisualStyleBackColor = True
        '
        'btONVIFRight
        '
        Me.btONVIFRight.Location = New System.Drawing.Point(128, 47)
        Me.btONVIFRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFRight.Name = "btONVIFRight"
        Me.btONVIFRight.Size = New System.Drawing.Size(32, 69)
        Me.btONVIFRight.TabIndex = 5
        Me.btONVIFRight.Text = "R"
        Me.btONVIFRight.UseVisualStyleBackColor = True
        '
        'btONVIFLeft
        '
        Me.btONVIFLeft.Location = New System.Drawing.Point(20, 46)
        Me.btONVIFLeft.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFLeft.Name = "btONVIFLeft"
        Me.btONVIFLeft.Size = New System.Drawing.Size(32, 69)
        Me.btONVIFLeft.TabIndex = 4
        Me.btONVIFLeft.Text = "L"
        Me.btONVIFLeft.UseVisualStyleBackColor = True
        '
        'btONVIFZoomOut
        '
        Me.btONVIFZoomOut.Location = New System.Drawing.Point(92, 65)
        Me.btONVIFZoomOut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFZoomOut.Name = "btONVIFZoomOut"
        Me.btONVIFZoomOut.Size = New System.Drawing.Size(34, 33)
        Me.btONVIFZoomOut.TabIndex = 3
        Me.btONVIFZoomOut.Text = "-"
        Me.btONVIFZoomOut.UseVisualStyleBackColor = True
        '
        'btONVIFZoomIn
        '
        Me.btONVIFZoomIn.Location = New System.Drawing.Point(52, 65)
        Me.btONVIFZoomIn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFZoomIn.Name = "btONVIFZoomIn"
        Me.btONVIFZoomIn.Size = New System.Drawing.Size(33, 33)
        Me.btONVIFZoomIn.TabIndex = 2
        Me.btONVIFZoomIn.Text = "+"
        Me.btONVIFZoomIn.UseVisualStyleBackColor = True
        '
        'btONVIFDown
        '
        Me.btONVIFDown.Location = New System.Drawing.Point(51, 100)
        Me.btONVIFDown.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFDown.Name = "btONVIFDown"
        Me.btONVIFDown.Size = New System.Drawing.Size(76, 33)
        Me.btONVIFDown.TabIndex = 1
        Me.btONVIFDown.Text = "Down"
        Me.btONVIFDown.UseVisualStyleBackColor = True
        '
        'btONVIFUp
        '
        Me.btONVIFUp.Location = New System.Drawing.Point(51, 28)
        Me.btONVIFUp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFUp.Name = "btONVIFUp"
        Me.btONVIFUp.Size = New System.Drawing.Size(76, 33)
        Me.btONVIFUp.TabIndex = 0
        Me.btONVIFUp.Text = "Up"
        Me.btONVIFUp.UseVisualStyleBackColor = True
        '
        'cbONVIFProfile
        '
        Me.cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbONVIFProfile.FormattingEnabled = True
        Me.cbONVIFProfile.Location = New System.Drawing.Point(112, 172)
        Me.cbONVIFProfile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbONVIFProfile.Name = "cbONVIFProfile"
        Me.cbONVIFProfile.Size = New System.Drawing.Size(517, 28)
        Me.cbONVIFProfile.TabIndex = 4
        '
        'label510
        '
        Me.label510.AutoSize = True
        Me.label510.Location = New System.Drawing.Point(18, 176)
        Me.label510.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label510.Name = "label510"
        Me.label510.Size = New System.Drawing.Size(53, 20)
        Me.label510.TabIndex = 3
        Me.label510.Text = "Profile"
        '
        'btONVIFConnect
        '
        Me.btONVIFConnect.Location = New System.Drawing.Point(519, 22)
        Me.btONVIFConnect.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btONVIFConnect.Name = "btONVIFConnect"
        Me.btONVIFConnect.Size = New System.Drawing.Size(112, 33)
        Me.btONVIFConnect.TabIndex = 0
        Me.btONVIFConnect.Text = "Connect"
        Me.btONVIFConnect.UseVisualStyleBackColor = True
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
        Me.tabPage2.Location = New System.Drawing.Point(4, 29)
        Me.tabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabPage2.Size = New System.Drawing.Size(700, 493)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Output"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'btSelectOutput
        '
        Me.btSelectOutput.Location = New System.Drawing.Point(650, 225)
        Me.btSelectOutput.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(36, 33)
        Me.btSelectOutput.TabIndex = 127
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = True
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(18, 228)
        Me.edOutput.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(620, 26)
        Me.edOutput.TabIndex = 126
        Me.edOutput.Text = "c:\capture.avi"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Location = New System.Drawing.Point(14, 84)
        Me.lbInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(399, 20)
        Me.lbInfo.TabIndex = 125
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btOutputConfigure
        '
        Me.btOutputConfigure.Location = New System.Drawing.Point(18, 106)
        Me.btOutputConfigure.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btOutputConfigure.Name = "btOutputConfigure"
        Me.btOutputConfigure.Size = New System.Drawing.Size(112, 33)
        Me.btOutputConfigure.TabIndex = 124
        Me.btOutputConfigure.Text = "Configure"
        Me.btOutputConfigure.UseVisualStyleBackColor = True
        '
        'cbOutputFormat
        '
        Me.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputFormat.FormattingEnabled = True
        Me.cbOutputFormat.Items.AddRange(New Object() {"AVI", "WMV (Windows Media Video)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "MPEG-TS", "MOV"})
        Me.cbOutputFormat.Location = New System.Drawing.Point(18, 44)
        Me.cbOutputFormat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbOutputFormat.Name = "cbOutputFormat"
        Me.cbOutputFormat.Size = New System.Drawing.Size(416, 28)
        Me.cbOutputFormat.TabIndex = 123
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 205)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(78, 20)
        Me.label4.TabIndex = 122
        Me.label4.Text = "File name"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(14, 19)
        Me.label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(60, 20)
        Me.label7.TabIndex = 121
        Me.label7.Text = "Format"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.cbFlipY)
        Me.TabPage3.Controls.Add(Me.cbFlipX)
        Me.TabPage3.Controls.Add(Me.cbInvert)
        Me.TabPage3.Controls.Add(Me.cbGreyscale)
        Me.TabPage3.Controls.Add(Me.label201)
        Me.TabPage3.Controls.Add(Me.tbDarkness)
        Me.TabPage3.Controls.Add(Me.label200)
        Me.TabPage3.Controls.Add(Me.label199)
        Me.TabPage3.Controls.Add(Me.label198)
        Me.TabPage3.Controls.Add(Me.tbContrast)
        Me.TabPage3.Controls.Add(Me.tbLightness)
        Me.TabPage3.Controls.Add(Me.tbSaturation)
        Me.TabPage3.Controls.Add(Me.label3)
        Me.TabPage3.Controls.Add(Me.btTextLogoAdd)
        Me.TabPage3.Controls.Add(Me.btLogoRemove)
        Me.TabPage3.Controls.Add(Me.btLogoEdit)
        Me.TabPage3.Controls.Add(Me.lbLogos)
        Me.TabPage3.Controls.Add(Me.btImageLogoAdd)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage3.Size = New System.Drawing.Size(700, 493)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Video effects"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 453)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(355, 20)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "More effects and settings available in Main Demo"
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = True
        Me.cbFlipY.Location = New System.Drawing.Point(330, 416)
        Me.cbFlipY.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(75, 24)
        Me.cbFlipY.TabIndex = 122
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = True
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = True
        Me.cbFlipX.Location = New System.Drawing.Point(240, 416)
        Me.cbFlipX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(75, 24)
        Me.cbFlipX.TabIndex = 121
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = True
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = True
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(150, 416)
        Me.cbInvert.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(75, 24)
        Me.cbInvert.TabIndex = 120
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = True
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = True
        Me.cbGreyscale.Location = New System.Drawing.Point(30, 416)
        Me.cbGreyscale.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(106, 24)
        Me.cbGreyscale.TabIndex = 119
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = True
        '
        'label201
        '
        Me.label201.AutoSize = True
        Me.label201.Location = New System.Drawing.Point(230, 314)
        Me.label201.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(77, 20)
        Me.label201.TabIndex = 118
        Me.label201.Text = "Darkness"
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(230, 342)
        Me.tbDarkness.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(195, 69)
        Me.tbDarkness.TabIndex = 117
        '
        'label200
        '
        Me.label200.AutoSize = True
        Me.label200.Location = New System.Drawing.Point(26, 314)
        Me.label200.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(70, 20)
        Me.label200.TabIndex = 116
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = True
        Me.label199.Location = New System.Drawing.Point(230, 239)
        Me.label199.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(83, 20)
        Me.label199.TabIndex = 115
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = True
        Me.label198.Location = New System.Drawing.Point(26, 239)
        Me.label198.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(78, 20)
        Me.label198.TabIndex = 114
        Me.label198.Text = "Lightness"
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(21, 342)
        Me.tbContrast.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(195, 69)
        Me.tbContrast.TabIndex = 113
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(21, 261)
        Me.tbLightness.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(195, 69)
        Me.tbLightness.TabIndex = 112
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(230, 261)
        Me.tbSaturation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(195, 69)
        Me.tbSaturation.TabIndex = 111
        Me.tbSaturation.Value = 255
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(16, 17)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(136, 20)
        Me.label3.TabIndex = 110
        Me.label3.Text = "Text / image logos"
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(178, 186)
        Me.btTextLogoAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(148, 33)
        Me.btTextLogoAdd.TabIndex = 109
        Me.btTextLogoAdd.Text = "Add text logo"
        Me.btTextLogoAdd.UseVisualStyleBackColor = True
        '
        'btLogoRemove
        '
        Me.btLogoRemove.Location = New System.Drawing.Point(450, 186)
        Me.btLogoRemove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btLogoRemove.Name = "btLogoRemove"
        Me.btLogoRemove.Size = New System.Drawing.Size(88, 33)
        Me.btLogoRemove.TabIndex = 108
        Me.btLogoRemove.Text = "Remove"
        Me.btLogoRemove.UseVisualStyleBackColor = True
        '
        'btLogoEdit
        '
        Me.btLogoEdit.Location = New System.Drawing.Point(352, 186)
        Me.btLogoEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btLogoEdit.Name = "btLogoEdit"
        Me.btLogoEdit.Size = New System.Drawing.Size(88, 33)
        Me.btLogoEdit.TabIndex = 107
        Me.btLogoEdit.Text = "Edit"
        Me.btLogoEdit.UseVisualStyleBackColor = True
        '
        'lbLogos
        '
        Me.lbLogos.FormattingEnabled = True
        Me.lbLogos.ItemHeight = 20
        Me.lbLogos.Location = New System.Drawing.Point(21, 40)
        Me.lbLogos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbLogos.Name = "lbLogos"
        Me.lbLogos.Size = New System.Drawing.Size(516, 124)
        Me.lbLogos.TabIndex = 106
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(21, 186)
        Me.btImageLogoAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(148, 33)
        Me.btImageLogoAdd.TabIndex = 105
        Me.btImageLogoAdd.Text = "Add image logo"
        Me.btImageLogoAdd.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.cbDebugMode)
        Me.TabPage7.Controls.Add(Me.mmLog)
        Me.TabPage7.Location = New System.Drawing.Point(4, 29)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage7.Size = New System.Drawing.Size(700, 493)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.Text = "Log"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(18, 20)
        Me.cbDebugMode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(127, 24)
        Me.cbDebugMode.TabIndex = 78
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'mmLog
        '
        Me.mmLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mmLog.Location = New System.Drawing.Point(18, 53)
        Me.mmLog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mmLog.Multiline = True
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(656, 396)
        Me.mmLog.TabIndex = 77
        '
        'rbPreview
        '
        Me.rbPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(10, 546)
        Me.rbPreview.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(88, 24)
        Me.rbPreview.TabIndex = 58
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(820, 541)
        Me.btStop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(93, 33)
        Me.btStop.TabIndex = 57
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(723, 541)
        Me.btStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(93, 33)
        Me.btStart.TabIndex = 56
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'llVideoTutorials
        '
        Me.llVideoTutorials.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llVideoTutorials.AutoSize = True
        Me.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.llVideoTutorials.Location = New System.Drawing.Point(1262, 11)
        Me.llVideoTutorials.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.llVideoTutorials.Name = "llVideoTutorials"
        Me.llVideoTutorials.Size = New System.Drawing.Size(102, 20)
        Me.llVideoTutorials.TabIndex = 92
        Me.llVideoTutorials.TabStop = True
        Me.llVideoTutorials.Text = "Video tutorial"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(856, 11)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(317, 20)
        Me.label2.TabIndex = 96
        Me.label2.Text = "Much more features available in Main Demo"
        '
        'rbCapture
        '
        Me.rbCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbCapture.AutoSize = True
        Me.rbCapture.Location = New System.Drawing.Point(114, 546)
        Me.rbCapture.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbCapture.Name = "rbCapture"
        Me.rbCapture.Size = New System.Drawing.Size(91, 24)
        Me.rbCapture.TabIndex = 97
        Me.rbCapture.Text = "Capture"
        Me.rbCapture.UseVisualStyleBackColor = True
        '
        'lbTimestamp
        '
        Me.lbTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTimestamp.AutoSize = True
        Me.lbTimestamp.Location = New System.Drawing.Point(348, 548)
        Me.lbTimestamp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTimestamp.Name = "lbTimestamp"
        Me.lbTimestamp.Size = New System.Drawing.Size(186, 20)
        Me.lbTimestamp.TabIndex = 103
        Me.lbTimestamp.Text = "Recording time: 00:00:00"
        '
        'btSaveScreenshot
        '
        Me.btSaveScreenshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSaveScreenshot.Location = New System.Drawing.Point(1173, 541)
        Me.btSaveScreenshot.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btSaveScreenshot.Name = "btSaveScreenshot"
        Me.btSaveScreenshot.Size = New System.Drawing.Size(190, 33)
        Me.btSaveScreenshot.TabIndex = 106
        Me.btSaveScreenshot.Text = "Save snapshot"
        Me.btSaveScreenshot.UseVisualStyleBackColor = True
        '
        'btResume
        '
        Me.btResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btResume.Location = New System.Drawing.Point(1035, 541)
        Me.btResume.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(82, 33)
        Me.btResume.TabIndex = 105
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPause.Location = New System.Drawing.Point(944, 541)
        Me.btPause.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(82, 33)
        Me.btPause.TabIndex = 104
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(723, 36)
        Me.VideoView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(640, 489)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 107
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1383, 590)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.btSaveScreenshot)
        Me.Controls.Add(Me.btResume)
        Me.Controls.Add(Me.btPause)
        Me.Controls.Add(Me.lbTimestamp)
        Me.Controls.Add(Me.rbCapture)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.llVideoTutorials)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.rbPreview)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IP Capture Demo - Video Capture SDK .Net"
        Me.tcMain.ResumeLayout(false)
        Me.tabPage1.ResumeLayout(false)
        Me.tabControl15.ResumeLayout(false)
        Me.tabPage144.ResumeLayout(false)
        Me.tabPage144.PerformLayout
        Me.tabPage146.ResumeLayout(false)
        Me.tabPage146.PerformLayout
        Me.tabPage145.ResumeLayout(false)
        Me.tabPage145.PerformLayout
        Me.groupBox42.ResumeLayout(false)
        Me.tabPage2.ResumeLayout(false)
        Me.tabPage2.PerformLayout
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage7.ResumeLayout(false)
        Me.TabPage7.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents tcMain As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents rbPreview As System.Windows.Forms.RadioButton
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents llVideoTutorials As System.Windows.Forms.LinkLabel
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents rbCapture As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage7 As TabPage
    Private WithEvents tabControl15 As TabControl
    Private WithEvents tabPage144 As TabPage
    Private WithEvents cbIPCameraONVIF As CheckBox
    Private WithEvents cbIPDisconnect As CheckBox
    Private WithEvents edIPForcedFramerateID As TextBox
    Private WithEvents label344 As Label
    Private WithEvents edIPForcedFramerate As TextBox
    Private WithEvents label295 As Label
    Private WithEvents cbIPCameraType As ComboBox
    Private WithEvents edIPPassword As TextBox
    Private WithEvents label167 As Label
    Private WithEvents edIPLogin As TextBox
    Private WithEvents label166 As Label
    Private WithEvents cbIPAudioCapture As CheckBox
    Private WithEvents label168 As Label
    Private WithEvents tabPage146 As TabPage
    Private WithEvents cbVLCZeroClockJitter As CheckBox
    Private WithEvents edVLCCacheSize As TextBox
    Private WithEvents label312 As Label
    Private WithEvents tabPage145 As TabPage
    Private WithEvents edONVIFLiveVideoURL As TextBox
    Private WithEvents label513 As Label
    Private WithEvents groupBox42 As GroupBox
    Private WithEvents btONVIFPTZSetDefault As Button
    Private WithEvents btONVIFRight As Button
    Private WithEvents btONVIFLeft As Button
    Private WithEvents btONVIFZoomOut As Button
    Private WithEvents btONVIFZoomIn As Button
    Private WithEvents btONVIFDown As Button
    Private WithEvents btONVIFUp As Button
    Private WithEvents cbONVIFProfile As ComboBox
    Private WithEvents label510 As Label
    Private WithEvents btONVIFConnect As Button
    Private WithEvents cbDebugMode As CheckBox
    Private WithEvents mmLog As TextBox
    Private WithEvents label165 As Label
    Private WithEvents edONVIFPassword As TextBox
    Private WithEvents Label379 As Label
    Private WithEvents edONVIFLogin As TextBox
    Private WithEvents Label380 As Label
    Private WithEvents edONVIFURL As TextBox
    Private WithEvents lbONVIFCameraInfo As Label
    Private WithEvents lbTimestamp As Label
    Private WithEvents btSaveScreenshot As Button
    Private WithEvents btResume As Button
    Private WithEvents btPause As Button
    Private WithEvents btSelectOutput As Button
    Private WithEvents edOutput As TextBox
    Private WithEvents lbInfo As Label
    Private WithEvents btOutputConfigure As Button
    Private WithEvents cbOutputFormat As ComboBox
    Private WithEvents label4 As Label
    Private WithEvents label7 As Label
    Friend WithEvents TabPage3 As TabPage
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
    Private WithEvents lbNDI As LinkLabel
    Private WithEvents label25 As Label
    Private WithEvents btListNDISources As Button
    Private WithEvents cbIPURL As ComboBox
    Private WithEvents btListONVIFSources As Button
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
