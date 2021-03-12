Imports VisioForge.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If onvifControl IsNot Nothing Then
            onvifControl.Dispose()
        End If

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.fontDialog1 = New System.Windows.Forms.FontDialog()
        Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.tabControl12 = New System.Windows.Forms.TabControl()
        Me.tabPage53 = New System.Windows.Forms.TabPage()
        Me.cbTelemetry = New System.Windows.Forms.CheckBox()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.tabControl10 = New System.Windows.Forms.TabControl()
        Me.tabPage46 = New System.Windows.Forms.TabPage()
        Me.tabControl2 = New System.Windows.Forms.TabControl()
        Me.tabPage8 = New System.Windows.Forms.TabPage()
        Me.btSignal = New System.Windows.Forms.Button()
        Me.label28 = New System.Windows.Forms.Label()
        Me.cbUseBestVideoInputFormat = New System.Windows.Forms.CheckBox()
        Me.btVideoCaptureDeviceSettings = New System.Windows.Forms.Button()
        Me.label18 = New System.Windows.Forms.Label()
        Me.cbFramerate = New System.Windows.Forms.ComboBox()
        Me.cbVideoInputFormat = New System.Windows.Forms.ComboBox()
        Me.cbVideoInputDevice = New System.Windows.Forms.ComboBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.tabPage52 = New System.Windows.Forms.TabPage()
        Me.cbCrossBarAvailable = New System.Windows.Forms.CheckBox()
        Me.lbRotes = New System.Windows.Forms.ListBox()
        Me.label61 = New System.Windows.Forms.Label()
        Me.label60 = New System.Windows.Forms.Label()
        Me.cbConnectRelated = New System.Windows.Forms.CheckBox()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.cbCrossbarVideoInput = New System.Windows.Forms.ComboBox()
        Me.label59 = New System.Windows.Forms.Label()
        Me.rbCrossbarAdvanced = New System.Windows.Forms.RadioButton()
        Me.rbCrossbarSimple = New System.Windows.Forms.RadioButton()
        Me.cbCrossbarOutput = New System.Windows.Forms.ComboBox()
        Me.cbCrossbarInput = New System.Windows.Forms.ComboBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.tabPage10 = New System.Windows.Forms.TabPage()
        Me.tabControl3 = New System.Windows.Forms.TabControl()
        Me.tabPage14 = New System.Windows.Forms.TabPage()
        Me.cbUseClosedCaptions = New System.Windows.Forms.CheckBox()
        Me.edTVDefaultFormat = New System.Windows.Forms.TextBox()
        Me.label57 = New System.Windows.Forms.Label()
        Me.cbTVCountry = New System.Windows.Forms.ComboBox()
        Me.label56 = New System.Windows.Forms.Label()
        Me.cbTVMode = New System.Windows.Forms.ComboBox()
        Me.cbTVInput = New System.Windows.Forms.ComboBox()
        Me.cbTVTuner = New System.Windows.Forms.ComboBox()
        Me.label33 = New System.Windows.Forms.Label()
        Me.label32 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.tabPage15 = New System.Windows.Forms.TabPage()
        Me.edChannel = New System.Windows.Forms.TextBox()
        Me.btUseThisChannel = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbTVChannel = New System.Windows.Forms.ComboBox()
        Me.label58 = New System.Windows.Forms.Label()
        Me.pbChannels = New System.Windows.Forms.ProgressBar()
        Me.btStopTune = New System.Windows.Forms.Button()
        Me.btStartTune = New System.Windows.Forms.Button()
        Me.cbTVSystem = New System.Windows.Forms.ComboBox()
        Me.edAudioFreq = New System.Windows.Forms.TextBox()
        Me.label36 = New System.Windows.Forms.Label()
        Me.edVideoFreq = New System.Windows.Forms.TextBox()
        Me.label37 = New System.Windows.Forms.Label()
        Me.label34 = New System.Windows.Forms.Label()
        Me.tabPage21 = New System.Windows.Forms.TabPage()
        Me.btMPEGEncoderShowDialog = New System.Windows.Forms.Button()
        Me.cbMPEGEncoder = New System.Windows.Forms.ComboBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.tabPage33 = New System.Windows.Forms.TabPage()
        Me.btMPEGAudDecSettings = New System.Windows.Forms.Button()
        Me.cbMPEGAudioDecoder = New System.Windows.Forms.ComboBox()
        Me.label121 = New System.Windows.Forms.Label()
        Me.btMPEGVidDecSetting = New System.Windows.Forms.Button()
        Me.cbMPEGVideoDecoder = New System.Windows.Forms.ComboBox()
        Me.label120 = New System.Windows.Forms.Label()
        Me.tabPage11 = New System.Windows.Forms.TabPage()
        Me.groupBox21 = New System.Windows.Forms.GroupBox()
        Me.rbDVResDC = New System.Windows.Forms.RadioButton()
        Me.rbDVResQuarter = New System.Windows.Forms.RadioButton()
        Me.rbDVResHalf = New System.Windows.Forms.RadioButton()
        Me.rbDVResFull = New System.Windows.Forms.RadioButton()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btDVStepFWD = New System.Windows.Forms.Button()
        Me.btDVStepRev = New System.Windows.Forms.Button()
        Me.btDVFF = New System.Windows.Forms.Button()
        Me.btDVStop = New System.Windows.Forms.Button()
        Me.btDVPause = New System.Windows.Forms.Button()
        Me.btDVPlay = New System.Windows.Forms.Button()
        Me.btDVRewind = New System.Windows.Forms.Button()
        Me.tabPage57 = New System.Windows.Forms.TabPage()
        Me.lbAdjSaturationCurrent = New System.Windows.Forms.Label()
        Me.lbAdjSaturationMax = New System.Windows.Forms.Label()
        Me.cbAdjSaturationAuto = New System.Windows.Forms.CheckBox()
        Me.lbAdjSaturationMin = New System.Windows.Forms.Label()
        Me.tbAdjSaturation = New System.Windows.Forms.TrackBar()
        Me.label45 = New System.Windows.Forms.Label()
        Me.lbAdjHueCurrent = New System.Windows.Forms.Label()
        Me.lbAdjHueMax = New System.Windows.Forms.Label()
        Me.cbAdjHueAuto = New System.Windows.Forms.CheckBox()
        Me.lbAdjHueMin = New System.Windows.Forms.Label()
        Me.tbAdjHue = New System.Windows.Forms.TrackBar()
        Me.label41 = New System.Windows.Forms.Label()
        Me.lbAdjContrastCurrent = New System.Windows.Forms.Label()
        Me.lbAdjContrastMax = New System.Windows.Forms.Label()
        Me.cbAdjContrastAuto = New System.Windows.Forms.CheckBox()
        Me.lbAdjContrastMin = New System.Windows.Forms.Label()
        Me.tbAdjContrast = New System.Windows.Forms.TrackBar()
        Me.label23 = New System.Windows.Forms.Label()
        Me.lbAdjBrightnessCurrent = New System.Windows.Forms.Label()
        Me.lbAdjBrightnessMax = New System.Windows.Forms.Label()
        Me.cbAdjBrightnessAuto = New System.Windows.Forms.CheckBox()
        Me.lbAdjBrightnessMin = New System.Windows.Forms.Label()
        Me.tbAdjBrightness = New System.Windows.Forms.TrackBar()
        Me.label17 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btCCFocusApply = New System.Windows.Forms.Button()
        Me.btCCZoomApply = New System.Windows.Forms.Button()
        Me.cbCCFocusRelative = New System.Windows.Forms.CheckBox()
        Me.cbCCFocusManual = New System.Windows.Forms.CheckBox()
        Me.cbCCFocusAuto = New System.Windows.Forms.CheckBox()
        Me.lbCCFocusCurrent = New System.Windows.Forms.Label()
        Me.lbCCFocusMax = New System.Windows.Forms.Label()
        Me.lbCCFocusMin = New System.Windows.Forms.Label()
        Me.tbCCFocus = New System.Windows.Forms.TrackBar()
        Me.label4 = New System.Windows.Forms.Label()
        Me.cbCCZoomRelative = New System.Windows.Forms.CheckBox()
        Me.cbCCZoomManual = New System.Windows.Forms.CheckBox()
        Me.cbCCZoomAuto = New System.Windows.Forms.CheckBox()
        Me.lbCCZoomCurrent = New System.Windows.Forms.Label()
        Me.lbCCZoomMax = New System.Windows.Forms.Label()
        Me.lbCCZoomMin = New System.Windows.Forms.Label()
        Me.tbCCZoom = New System.Windows.Forms.TrackBar()
        Me.label20 = New System.Windows.Forms.Label()
        Me.btCCTiltApply = New System.Windows.Forms.Button()
        Me.btCCPanApply = New System.Windows.Forms.Button()
        Me.cbCCTiltRelative = New System.Windows.Forms.CheckBox()
        Me.cbCCTiltManual = New System.Windows.Forms.CheckBox()
        Me.cbCCTiltAuto = New System.Windows.Forms.CheckBox()
        Me.lbCCTiltCurrent = New System.Windows.Forms.Label()
        Me.lbCCTiltMax = New System.Windows.Forms.Label()
        Me.lbCCTiltMin = New System.Windows.Forms.Label()
        Me.tbCCTilt = New System.Windows.Forms.TrackBar()
        Me.label97 = New System.Windows.Forms.Label()
        Me.cbCCPanRelative = New System.Windows.Forms.CheckBox()
        Me.cbCCPanManual = New System.Windows.Forms.CheckBox()
        Me.cbCCPanAuto = New System.Windows.Forms.CheckBox()
        Me.btCCReadValues = New System.Windows.Forms.Button()
        Me.lbCCPanCurrent = New System.Windows.Forms.Label()
        Me.lbCCPanMax = New System.Windows.Forms.Label()
        Me.lbCCPanMin = New System.Windows.Forms.Label()
        Me.tbCCPan = New System.Windows.Forms.TrackBar()
        Me.label96 = New System.Windows.Forms.Label()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.tabControl19 = New System.Windows.Forms.TabControl()
        Me.tabPage96 = New System.Windows.Forms.TabPage()
        Me.cbUseBestAudioInputFormat = New System.Windows.Forms.CheckBox()
        Me.cbUseAudioInputFromVideoCaptureDevice = New System.Windows.Forms.CheckBox()
        Me.btAudioInputDeviceSettings = New System.Windows.Forms.Button()
        Me.cbAudioInputLine = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputFormat = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputDevice = New System.Windows.Forms.ComboBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.tabPage97 = New System.Windows.Forms.TabPage()
        Me.label55 = New System.Windows.Forms.Label()
        Me.tbAudioBalance = New System.Windows.Forms.TrackBar()
        Me.label54 = New System.Windows.Forms.Label()
        Me.tbAudioVolume = New System.Windows.Forms.TrackBar()
        Me.cbPlayAudio = New System.Windows.Forms.CheckBox()
        Me.cbAudioOutputDevice = New System.Windows.Forms.ComboBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.tabPage98 = New System.Windows.Forms.TabPage()
        Me.peakMeterCtrl1 = New VisioForge.Controls.UI.WinForms.PeakMeterCtrl()
        Me.cbVUMeter = New System.Windows.Forms.CheckBox()
        Me.TabPage111 = New System.Windows.Forms.TabPage()
        Me.tbVUMeterBoost = New System.Windows.Forms.TrackBar()
        Me.label382 = New System.Windows.Forms.Label()
        Me.label381 = New System.Windows.Forms.Label()
        Me.tbVUMeterAmplification = New System.Windows.Forms.TrackBar()
        Me.cbVUMeterPro = New System.Windows.Forms.CheckBox()
        Me.waveformPainter2 = New VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter()
        Me.waveformPainter1 = New VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter()
        Me.volumeMeter2 = New VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter()
        Me.volumeMeter1 = New VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter()
        Me.tabPage99 = New System.Windows.Forms.TabPage()
        Me.rbAddAudioStreamsIndependent = New System.Windows.Forms.RadioButton()
        Me.rbAddAudioStreamsMix = New System.Windows.Forms.RadioButton()
        Me.label319 = New System.Windows.Forms.Label()
        Me.label318 = New System.Windows.Forms.Label()
        Me.btAddAdditionalAudioSource = New System.Windows.Forms.Button()
        Me.cbAdditionalAudioSource = New System.Windows.Forms.ComboBox()
        Me.label180 = New System.Windows.Forms.Label()
        Me.tabPage47 = New System.Windows.Forms.TabPage()
        Me.label3 = New System.Windows.Forms.Label()
        Me.lbScreenSourceWindowText = New System.Windows.Forms.Label()
        Me.btScreenSourceWindowSelect = New System.Windows.Forms.Button()
        Me.rbScreenCaptureWindow = New System.Windows.Forms.RadioButton()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.cbScreenCapture_DesktopDuplication = New System.Windows.Forms.CheckBox()
        Me.cbScreenCaptureDisplayIndex = New System.Windows.Forms.ComboBox()
        Me.label93 = New System.Windows.Forms.Label()
        Me.btScreenCaptureUpdate = New System.Windows.Forms.Button()
        Me.cbScreenCapture_GrabMouseCursor = New System.Windows.Forms.CheckBox()
        Me.label79 = New System.Windows.Forms.Label()
        Me.edScreenFrameRate = New System.Windows.Forms.TextBox()
        Me.label43 = New System.Windows.Forms.Label()
        Me.edScreenBottom = New System.Windows.Forms.TextBox()
        Me.label42 = New System.Windows.Forms.Label()
        Me.edScreenRight = New System.Windows.Forms.TextBox()
        Me.label40 = New System.Windows.Forms.Label()
        Me.edScreenTop = New System.Windows.Forms.TextBox()
        Me.label26 = New System.Windows.Forms.Label()
        Me.edScreenLeft = New System.Windows.Forms.TextBox()
        Me.label24 = New System.Windows.Forms.Label()
        Me.rbScreenCustomArea = New System.Windows.Forms.RadioButton()
        Me.rbScreenFullScreen = New System.Windows.Forms.RadioButton()
        Me.tabPage48 = New System.Windows.Forms.TabPage()
        Me.tabControl15 = New System.Windows.Forms.TabControl()
        Me.tabPage144 = New System.Windows.Forms.TabPage()
        Me.cbIPURL = New System.Windows.Forms.ComboBox()
        Me.btListNDISources = New System.Windows.Forms.Button()
        Me.lbNDI = New System.Windows.Forms.LinkLabel()
        Me.label25 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.linkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.label165 = New System.Windows.Forms.Label()
        Me.cbIPCameraONVIF = New System.Windows.Forms.CheckBox()
        Me.btShowIPCamDatabase = New System.Windows.Forms.Button()
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
        Me.lbONVIFCameraInfo = New System.Windows.Forms.Label()
        Me.btONVIFConnect = New System.Windows.Forms.Button()
        Me.TabPage61 = New System.Windows.Forms.TabPage()
        Me.cbDecklinkCaptureVideoFormat = New System.Windows.Forms.ComboBox()
        Me.label66 = New System.Windows.Forms.Label()
        Me.cbDecklinkCaptureDevice = New System.Windows.Forms.ComboBox()
        Me.label39 = New System.Windows.Forms.Label()
        Me.cbDecklinkSourceTimecode = New System.Windows.Forms.ComboBox()
        Me.label341 = New System.Windows.Forms.Label()
        Me.cbDecklinkSourceComponentLevels = New System.Windows.Forms.ComboBox()
        Me.label339 = New System.Windows.Forms.Label()
        Me.cbDecklinkSourceNTSC = New System.Windows.Forms.ComboBox()
        Me.label340 = New System.Windows.Forms.Label()
        Me.cbDecklinkSourceInput = New System.Windows.Forms.ComboBox()
        Me.label338 = New System.Windows.Forms.Label()
        Me.TabPage66 = New System.Windows.Forms.TabPage()
        Me.tabControl22 = New System.Windows.Forms.TabControl()
        Me.tabPage82 = New System.Windows.Forms.TabPage()
        Me.cbBDADeviceStandard = New System.Windows.Forms.ComboBox()
        Me.label129 = New System.Windows.Forms.Label()
        Me.cbBDAReceiver = New System.Windows.Forms.ComboBox()
        Me.label270 = New System.Windows.Forms.Label()
        Me.cbBDASourceDevice = New System.Windows.Forms.ComboBox()
        Me.label272 = New System.Windows.Forms.Label()
        Me.tabPage83 = New System.Windows.Forms.TabPage()
        Me.tabControl23 = New System.Windows.Forms.TabControl()
        Me.tabPage84 = New System.Windows.Forms.TabPage()
        Me.btDVBTTune = New System.Windows.Forms.Button()
        Me.edDVBTSID = New System.Windows.Forms.TextBox()
        Me.edDVBTTSID = New System.Windows.Forms.TextBox()
        Me.edDVBTONID = New System.Windows.Forms.TextBox()
        Me.label273 = New System.Windows.Forms.Label()
        Me.edDVBTFrequency = New System.Windows.Forms.TextBox()
        Me.label274 = New System.Windows.Forms.Label()
        Me.label275 = New System.Windows.Forms.Label()
        Me.label276 = New System.Windows.Forms.Label()
        Me.label277 = New System.Windows.Forms.Label()
        Me.tabPage85 = New System.Windows.Forms.TabPage()
        Me.cbDVBSPolarisation = New System.Windows.Forms.ComboBox()
        Me.label278 = New System.Windows.Forms.Label()
        Me.edDVBSSymbolRate = New System.Windows.Forms.TextBox()
        Me.label279 = New System.Windows.Forms.Label()
        Me.btDVBSTune = New System.Windows.Forms.Button()
        Me.edDVBSSID = New System.Windows.Forms.TextBox()
        Me.edDVBSTSID = New System.Windows.Forms.TextBox()
        Me.edDVBSONIT = New System.Windows.Forms.TextBox()
        Me.label280 = New System.Windows.Forms.Label()
        Me.edDVBSFrequency = New System.Windows.Forms.TextBox()
        Me.label281 = New System.Windows.Forms.Label()
        Me.label282 = New System.Windows.Forms.Label()
        Me.label283 = New System.Windows.Forms.Label()
        Me.label284 = New System.Windows.Forms.Label()
        Me.tabPage86 = New System.Windows.Forms.TabPage()
        Me.groupBox35 = New System.Windows.Forms.GroupBox()
        Me.edDVBCMinorChannel = New System.Windows.Forms.TextBox()
        Me.label285 = New System.Windows.Forms.Label()
        Me.edDVBCPhysicalChannel = New System.Windows.Forms.TextBox()
        Me.label286 = New System.Windows.Forms.Label()
        Me.edDVBCVirtualChannel = New System.Windows.Forms.TextBox()
        Me.label287 = New System.Windows.Forms.Label()
        Me.groupBox36 = New System.Windows.Forms.GroupBox()
        Me.edDVBCSymbolRate = New System.Windows.Forms.TextBox()
        Me.label288 = New System.Windows.Forms.Label()
        Me.edDVBCProgramNumber = New System.Windows.Forms.TextBox()
        Me.label289 = New System.Windows.Forms.Label()
        Me.cbDVBCModulation = New System.Windows.Forms.ComboBox()
        Me.label290 = New System.Windows.Forms.Label()
        Me.label291 = New System.Windows.Forms.Label()
        Me.edDVBCCarrierFrequency = New System.Windows.Forms.TextBox()
        Me.label292 = New System.Windows.Forms.Label()
        Me.btBDADVBCTune = New System.Windows.Forms.Button()
        Me.tabPage87 = New System.Windows.Forms.TabPage()
        Me.label293 = New System.Windows.Forms.Label()
        Me.TabPage104 = New System.Windows.Forms.TabPage()
        Me.btBDAChannelScanningStart = New System.Windows.Forms.Button()
        Me.lvBDAChannels = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.label342 = New System.Windows.Forms.Label()
        Me.tabPage49 = New System.Windows.Forms.TabPage()
        Me.tabControl20 = New System.Windows.Forms.TabControl()
        Me.tabPage67 = New System.Windows.Forms.TabPage()
        Me.tabControl21 = New System.Windows.Forms.TabControl()
        Me.tabPage78 = New System.Windows.Forms.TabPage()
        Me.btPIPAddDevice = New System.Windows.Forms.Button()
        Me.groupBox30 = New System.Windows.Forms.GroupBox()
        Me.edPIPVidCapHeight = New System.Windows.Forms.TextBox()
        Me.label94 = New System.Windows.Forms.Label()
        Me.edPIPVidCapWidth = New System.Windows.Forms.TextBox()
        Me.label98 = New System.Windows.Forms.Label()
        Me.edPIPVidCapTop = New System.Windows.Forms.TextBox()
        Me.label99 = New System.Windows.Forms.Label()
        Me.edPIPVidCapLeft = New System.Windows.Forms.TextBox()
        Me.label100 = New System.Windows.Forms.Label()
        Me.cbPIPInput = New System.Windows.Forms.ComboBox()
        Me.label170 = New System.Windows.Forms.Label()
        Me.cbPIPFrameRate = New System.Windows.Forms.ComboBox()
        Me.label128 = New System.Windows.Forms.Label()
        Me.cbPIPFormatUseBest = New System.Windows.Forms.CheckBox()
        Me.cbPIPFormat = New System.Windows.Forms.ComboBox()
        Me.label127 = New System.Windows.Forms.Label()
        Me.label126 = New System.Windows.Forms.Label()
        Me.cbPIPDevice = New System.Windows.Forms.ComboBox()
        Me.label125 = New System.Windows.Forms.Label()
        Me.tabPage79 = New System.Windows.Forms.TabPage()
        Me.groupBox31 = New System.Windows.Forms.GroupBox()
        Me.edPIPIPCapHeight = New System.Windows.Forms.TextBox()
        Me.label101 = New System.Windows.Forms.Label()
        Me.edPIPIPCapWidth = New System.Windows.Forms.TextBox()
        Me.label102 = New System.Windows.Forms.Label()
        Me.edPIPIPCapTop = New System.Windows.Forms.TextBox()
        Me.label103 = New System.Windows.Forms.Label()
        Me.edPIPIPCapLeft = New System.Windows.Forms.TextBox()
        Me.label229 = New System.Windows.Forms.Label()
        Me.btPIPAddIPCamera = New System.Windows.Forms.Button()
        Me.tabPage80 = New System.Windows.Forms.TabPage()
        Me.groupBox32 = New System.Windows.Forms.GroupBox()
        Me.edPIPScreenCapHeight = New System.Windows.Forms.TextBox()
        Me.label256 = New System.Windows.Forms.Label()
        Me.edPIPScreenCapWidth = New System.Windows.Forms.TextBox()
        Me.label260 = New System.Windows.Forms.Label()
        Me.edPIPScreenCapTop = New System.Windows.Forms.TextBox()
        Me.label266 = New System.Windows.Forms.Label()
        Me.edPIPScreenCapLeft = New System.Windows.Forms.TextBox()
        Me.label268 = New System.Windows.Forms.Label()
        Me.btPIPAddScreenCapture = New System.Windows.Forms.Button()
        Me.TabPage93 = New System.Windows.Forms.TabPage()
        Me.groupBox44 = New System.Windows.Forms.GroupBox()
        Me.edPIPFileHeight = New System.Windows.Forms.TextBox()
        Me.label321 = New System.Windows.Forms.Label()
        Me.edPIPFileWidth = New System.Windows.Forms.TextBox()
        Me.label322 = New System.Windows.Forms.Label()
        Me.edPIPFileTop = New System.Windows.Forms.TextBox()
        Me.label323 = New System.Windows.Forms.Label()
        Me.edPIPFileLeft = New System.Windows.Forms.TextBox()
        Me.label324 = New System.Windows.Forms.Label()
        Me.btPIPFileSourceAdd = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.edPIPFileSoureFilename = New System.Windows.Forms.TextBox()
        Me.label320 = New System.Windows.Forms.Label()
        Me.tabPage77 = New System.Windows.Forms.TabPage()
        Me.cbPIPResizeMode = New System.Windows.Forms.ComboBox()
        Me.label317 = New System.Windows.Forms.Label()
        Me.groupBox34 = New System.Windows.Forms.GroupBox()
        Me.btPIPSet = New System.Windows.Forms.Button()
        Me.tbPIPTransparency = New System.Windows.Forms.TrackBar()
        Me.groupBox33 = New System.Windows.Forms.GroupBox()
        Me.btPIPSetOutputSize = New System.Windows.Forms.Button()
        Me.edPIPOutputHeight = New System.Windows.Forms.TextBox()
        Me.label269 = New System.Windows.Forms.Label()
        Me.edPIPOutputWidth = New System.Windows.Forms.TextBox()
        Me.label271 = New System.Windows.Forms.Label()
        Me.cbPIPDevices = New System.Windows.Forms.ComboBox()
        Me.cbPIPMode = New System.Windows.Forms.ComboBox()
        Me.label169 = New System.Windows.Forms.Label()
        Me.btPIPDevicesClear = New System.Windows.Forms.Button()
        Me.label134 = New System.Windows.Forms.Label()
        Me.groupBox20 = New System.Windows.Forms.GroupBox()
        Me.btPIPUpdate = New System.Windows.Forms.Button()
        Me.edPIPHeight = New System.Windows.Forms.TextBox()
        Me.label132 = New System.Windows.Forms.Label()
        Me.edPIPWidth = New System.Windows.Forms.TextBox()
        Me.label133 = New System.Windows.Forms.Label()
        Me.edPIPTop = New System.Windows.Forms.TextBox()
        Me.label130 = New System.Windows.Forms.Label()
        Me.edPIPLeft = New System.Windows.Forms.TextBox()
        Me.label131 = New System.Windows.Forms.Label()
        Me.TabPage113 = New System.Windows.Forms.TabPage()
        Me.lbPIPChromaKeyTolerance2 = New System.Windows.Forms.Label()
        Me.label518 = New System.Windows.Forms.Label()
        Me.tbPIPChromaKeyTolerance2 = New System.Windows.Forms.TrackBar()
        Me.lbPIPChromaKeyTolerance1 = New System.Windows.Forms.Label()
        Me.label515 = New System.Windows.Forms.Label()
        Me.tbPIPChromaKeyTolerance1 = New System.Windows.Forms.TrackBar()
        Me.pnPIPChromaKeyColor = New System.Windows.Forms.Panel()
        Me.label514 = New System.Windows.Forms.Label()
        Me.tabPage50 = New System.Windows.Forms.TabPage()
        Me.cbMultiscreenDrawOnExternalDisplays = New System.Windows.Forms.CheckBox()
        Me.cbMultiscreenDrawOnPanels = New System.Windows.Forms.CheckBox()
        Me.cbFlipHorizontal3 = New System.Windows.Forms.CheckBox()
        Me.cbFlipVertical3 = New System.Windows.Forms.CheckBox()
        Me.cbStretch3 = New System.Windows.Forms.CheckBox()
        Me.cbFlipHorizontal2 = New System.Windows.Forms.CheckBox()
        Me.cbFlipVertical2 = New System.Windows.Forms.CheckBox()
        Me.cbStretch2 = New System.Windows.Forms.CheckBox()
        Me.cbFlipHorizontal1 = New System.Windows.Forms.CheckBox()
        Me.cbFlipVertical1 = New System.Windows.Forms.CheckBox()
        Me.cbStretch1 = New System.Windows.Forms.CheckBox()
        Me.pnScreen3 = New System.Windows.Forms.Panel()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.pnScreen2 = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.pnScreen1 = New System.Windows.Forms.Panel()
        Me.tabPage51 = New System.Windows.Forms.TabPage()
        Me.tabControl26 = New System.Windows.Forms.TabControl()
        Me.tabPage115 = New System.Windows.Forms.TabPage()
        Me.pnVideoRendererBGColor = New System.Windows.Forms.Panel()
        Me.label394 = New System.Windows.Forms.Label()
        Me.btFullScreen = New System.Windows.Forms.Button()
        Me.groupBox28 = New System.Windows.Forms.GroupBox()
        Me.btZoomReset = New System.Windows.Forms.Button()
        Me.btZoomShiftRight = New System.Windows.Forms.Button()
        Me.btZoomShiftLeft = New System.Windows.Forms.Button()
        Me.btZoomOut = New System.Windows.Forms.Button()
        Me.btZoomIn = New System.Windows.Forms.Button()
        Me.btZoomShiftDown = New System.Windows.Forms.Button()
        Me.btZoomShiftUp = New System.Windows.Forms.Button()
        Me.cbScreenFlipVertical = New System.Windows.Forms.CheckBox()
        Me.cbScreenFlipHorizontal = New System.Windows.Forms.CheckBox()
        Me.cbStretch = New System.Windows.Forms.CheckBox()
        Me.groupBox13 = New System.Windows.Forms.GroupBox()
        Me.rbDirect2D = New System.Windows.Forms.RadioButton()
        Me.rbNone = New System.Windows.Forms.RadioButton()
        Me.rbEVR = New System.Windows.Forms.RadioButton()
        Me.rbVMR9 = New System.Windows.Forms.RadioButton()
        Me.rbVR = New System.Windows.Forms.RadioButton()
        Me.tabPage116 = New System.Windows.Forms.TabPage()
        Me.label393 = New System.Windows.Forms.Label()
        Me.cbDirect2DRotate = New System.Windows.Forms.ComboBox()
        Me.TabPage23 = New System.Windows.Forms.TabPage()
        Me.label376 = New System.Windows.Forms.Label()
        Me.edSeparateCaptureFileSize = New System.Windows.Forms.TextBox()
        Me.label375 = New System.Windows.Forms.Label()
        Me.label374 = New System.Windows.Forms.Label()
        Me.edSeparateCaptureDuration = New System.Windows.Forms.TextBox()
        Me.label373 = New System.Windows.Forms.Label()
        Me.rbSeparateCaptureSplitBySize = New System.Windows.Forms.RadioButton()
        Me.rbSeparateCaptureSplitByDuration = New System.Windows.Forms.RadioButton()
        Me.rbSeparateCaptureStartManually = New System.Windows.Forms.RadioButton()
        Me.btSeparateCaptureResume = New System.Windows.Forms.Button()
        Me.btSeparateCapturePause = New System.Windows.Forms.Button()
        Me.groupBox8 = New System.Windows.Forms.GroupBox()
        Me.btSeparateCaptureChangeFilename = New System.Windows.Forms.Button()
        Me.edNewFilename = New System.Windows.Forms.TextBox()
        Me.label84 = New System.Windows.Forms.Label()
        Me.btSeparateCaptureStop = New System.Windows.Forms.Button()
        Me.btSeparateCaptureStart = New System.Windows.Forms.Button()
        Me.cbSeparateCaptureEnabled = New System.Windows.Forms.CheckBox()
        Me.label83 = New System.Windows.Forms.Label()
        Me.label82 = New System.Windows.Forms.Label()
        Me.TabPage123 = New System.Windows.Forms.TabPage()
        Me.tabControl28 = New System.Windows.Forms.TabControl()
        Me.tabPage125 = New System.Windows.Forms.TabPage()
        Me.edCustomVideoSourceURL = New System.Windows.Forms.TextBox()
        Me.label516 = New System.Windows.Forms.Label()
        Me.cbCustomVideoSourceFrameRate = New System.Windows.Forms.ComboBox()
        Me.label438 = New System.Windows.Forms.Label()
        Me.label435 = New System.Windows.Forms.Label()
        Me.cbCustomVideoSourceFormat = New System.Windows.Forms.ComboBox()
        Me.label434 = New System.Windows.Forms.Label()
        Me.cbCustomVideoSourceFilter = New System.Windows.Forms.ComboBox()
        Me.cbCustomVideoSourceCategory = New System.Windows.Forms.ComboBox()
        Me.label432 = New System.Windows.Forms.Label()
        Me.tabPage126 = New System.Windows.Forms.TabPage()
        Me.edCustomAudioSourceURL = New System.Windows.Forms.TextBox()
        Me.label517 = New System.Windows.Forms.Label()
        Me.label437 = New System.Windows.Forms.Label()
        Me.cbCustomAudioSourceFormat = New System.Windows.Forms.ComboBox()
        Me.label436 = New System.Windows.Forms.Label()
        Me.cbCustomAudioSourceFilter = New System.Windows.Forms.ComboBox()
        Me.label433 = New System.Windows.Forms.Label()
        Me.cbCustomAudioSourceCategory = New System.Windows.Forms.ComboBox()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.cbMode = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btOutputConfigure = New System.Windows.Forms.Button()
        Me.cbOutputFormat = New System.Windows.Forms.ComboBox()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.cbRecordAudio = New System.Windows.Forms.CheckBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.tabControl17 = New System.Windows.Forms.TabControl()
        Me.tabPage68 = New System.Windows.Forms.TabPage()
        Me.cbFlipY = New System.Windows.Forms.CheckBox()
        Me.cbFlipX = New System.Windows.Forms.CheckBox()
        Me.label201 = New System.Windows.Forms.Label()
        Me.label200 = New System.Windows.Forms.Label()
        Me.label199 = New System.Windows.Forms.Label()
        Me.label198 = New System.Windows.Forms.Label()
        Me.tabControl7 = New System.Windows.Forms.TabControl()
        Me.tabPage29 = New System.Windows.Forms.TabPage()
        Me.cbMergeTextLogos = New System.Windows.Forms.CheckBox()
        Me.btTextLogoRemove = New System.Windows.Forms.Button()
        Me.btTextLogoEdit = New System.Windows.Forms.Button()
        Me.lbTextLogos = New System.Windows.Forms.ListBox()
        Me.btTextLogoAdd = New System.Windows.Forms.Button()
        Me.tabPage42 = New System.Windows.Forms.TabPage()
        Me.cbMergeImageLogos = New System.Windows.Forms.CheckBox()
        Me.btImageLogoRemove = New System.Windows.Forms.Button()
        Me.btImageLogoEdit = New System.Windows.Forms.Button()
        Me.lbImageLogos = New System.Windows.Forms.ListBox()
        Me.btImageLogoAdd = New System.Windows.Forms.Button()
        Me.TabPage88 = New System.Windows.Forms.TabPage()
        Me.groupBox37 = New System.Windows.Forms.GroupBox()
        Me.btEffZoomRight = New System.Windows.Forms.Button()
        Me.btEffZoomLeft = New System.Windows.Forms.Button()
        Me.btEffZoomOut = New System.Windows.Forms.Button()
        Me.btEffZoomIn = New System.Windows.Forms.Button()
        Me.btEffZoomDown = New System.Windows.Forms.Button()
        Me.btEffZoomUp = New System.Windows.Forms.Button()
        Me.cbZoom = New System.Windows.Forms.CheckBox()
        Me.TabPage91 = New System.Windows.Forms.TabPage()
        Me.groupBox40 = New System.Windows.Forms.GroupBox()
        Me.edPanDestHeight = New System.Windows.Forms.TextBox()
        Me.label302 = New System.Windows.Forms.Label()
        Me.edPanDestWidth = New System.Windows.Forms.TextBox()
        Me.label303 = New System.Windows.Forms.Label()
        Me.edPanDestTop = New System.Windows.Forms.TextBox()
        Me.label304 = New System.Windows.Forms.Label()
        Me.edPanDestLeft = New System.Windows.Forms.TextBox()
        Me.label305 = New System.Windows.Forms.Label()
        Me.groupBox39 = New System.Windows.Forms.GroupBox()
        Me.edPanSourceHeight = New System.Windows.Forms.TextBox()
        Me.label298 = New System.Windows.Forms.Label()
        Me.edPanSourceWidth = New System.Windows.Forms.TextBox()
        Me.label299 = New System.Windows.Forms.Label()
        Me.edPanSourceTop = New System.Windows.Forms.TextBox()
        Me.label300 = New System.Windows.Forms.Label()
        Me.edPanSourceLeft = New System.Windows.Forms.TextBox()
        Me.label301 = New System.Windows.Forms.Label()
        Me.groupBox38 = New System.Windows.Forms.GroupBox()
        Me.edPanStopTime = New System.Windows.Forms.TextBox()
        Me.label296 = New System.Windows.Forms.Label()
        Me.edPanStartTime = New System.Windows.Forms.TextBox()
        Me.label297 = New System.Windows.Forms.Label()
        Me.cbPan = New System.Windows.Forms.CheckBox()
        Me.TabPage101 = New System.Windows.Forms.TabPage()
        Me.rbFadeOut = New System.Windows.Forms.RadioButton()
        Me.rbFadeIn = New System.Windows.Forms.RadioButton()
        Me.groupBox45 = New System.Windows.Forms.GroupBox()
        Me.edFadeInOutStopTime = New System.Windows.Forms.TextBox()
        Me.label329 = New System.Windows.Forms.Label()
        Me.edFadeInOutStartTime = New System.Windows.Forms.TextBox()
        Me.label330 = New System.Windows.Forms.Label()
        Me.cbFadeInOut = New System.Windows.Forms.CheckBox()
        Me.TabPage112 = New System.Windows.Forms.TabPage()
        Me.label391 = New System.Windows.Forms.Label()
        Me.cbLiveRotationStretch = New System.Windows.Forms.CheckBox()
        Me.label392 = New System.Windows.Forms.Label()
        Me.tbLiveRotationAngle = New System.Windows.Forms.TrackBar()
        Me.label390 = New System.Windows.Forms.Label()
        Me.cbLiveRotation = New System.Windows.Forms.CheckBox()
        Me.tbContrast = New System.Windows.Forms.TrackBar()
        Me.tbDarkness = New System.Windows.Forms.TrackBar()
        Me.tbLightness = New System.Windows.Forms.TrackBar()
        Me.tbSaturation = New System.Windows.Forms.TrackBar()
        Me.cbInvert = New System.Windows.Forms.CheckBox()
        Me.cbGreyscale = New System.Windows.Forms.CheckBox()
        Me.cbEffects = New System.Windows.Forms.CheckBox()
        Me.tabPage69 = New System.Windows.Forms.TabPage()
        Me.label211 = New System.Windows.Forms.Label()
        Me.edDeintTriangleWeight = New System.Windows.Forms.TextBox()
        Me.label212 = New System.Windows.Forms.Label()
        Me.label210 = New System.Windows.Forms.Label()
        Me.label209 = New System.Windows.Forms.Label()
        Me.label206 = New System.Windows.Forms.Label()
        Me.edDeintBlendConstants2 = New System.Windows.Forms.TextBox()
        Me.label207 = New System.Windows.Forms.Label()
        Me.edDeintBlendConstants1 = New System.Windows.Forms.TextBox()
        Me.label208 = New System.Windows.Forms.Label()
        Me.label204 = New System.Windows.Forms.Label()
        Me.edDeintBlendThreshold2 = New System.Windows.Forms.TextBox()
        Me.label205 = New System.Windows.Forms.Label()
        Me.edDeintBlendThreshold1 = New System.Windows.Forms.TextBox()
        Me.label203 = New System.Windows.Forms.Label()
        Me.label202 = New System.Windows.Forms.Label()
        Me.edDeintCAVTThreshold = New System.Windows.Forms.TextBox()
        Me.label104 = New System.Windows.Forms.Label()
        Me.rbDeintTriangleEnabled = New System.Windows.Forms.RadioButton()
        Me.rbDeintBlendEnabled = New System.Windows.Forms.RadioButton()
        Me.rbDeintCAVTEnabled = New System.Windows.Forms.RadioButton()
        Me.cbDeinterlace = New System.Windows.Forms.CheckBox()
        Me.TabPage59 = New System.Windows.Forms.TabPage()
        Me.rbDenoiseCAST = New System.Windows.Forms.RadioButton()
        Me.rbDenoiseMosquito = New System.Windows.Forms.RadioButton()
        Me.cbDenoise = New System.Windows.Forms.CheckBox()
        Me.TabPage63 = New System.Windows.Forms.TabPage()
        Me.label5 = New System.Windows.Forms.Label()
        Me.tbGPUBlur = New System.Windows.Forms.TrackBar()
        Me.cbVideoEffectsGPUEnabled = New System.Windows.Forms.CheckBox()
        Me.cbGPUOldMovie = New System.Windows.Forms.CheckBox()
        Me.cbGPUDeinterlace = New System.Windows.Forms.CheckBox()
        Me.cbGPUDenoise = New System.Windows.Forms.CheckBox()
        Me.cbGPUPixelate = New System.Windows.Forms.CheckBox()
        Me.cbGPUNightVision = New System.Windows.Forms.CheckBox()
        Me.label383 = New System.Windows.Forms.Label()
        Me.label384 = New System.Windows.Forms.Label()
        Me.label385 = New System.Windows.Forms.Label()
        Me.label386 = New System.Windows.Forms.Label()
        Me.tbGPUContrast = New System.Windows.Forms.TrackBar()
        Me.tbGPUDarkness = New System.Windows.Forms.TrackBar()
        Me.tbGPULightness = New System.Windows.Forms.TrackBar()
        Me.tbGPUSaturation = New System.Windows.Forms.TrackBar()
        Me.cbGPUInvert = New System.Windows.Forms.CheckBox()
        Me.cbGPUGreyscale = New System.Windows.Forms.CheckBox()
        Me.TabPage92 = New System.Windows.Forms.TabPage()
        Me.label92 = New System.Windows.Forms.Label()
        Me.cbRotate = New System.Windows.Forms.ComboBox()
        Me.edCropRight = New System.Windows.Forms.TextBox()
        Me.label52 = New System.Windows.Forms.Label()
        Me.edCropBottom = New System.Windows.Forms.TextBox()
        Me.label53 = New System.Windows.Forms.Label()
        Me.edCropLeft = New System.Windows.Forms.TextBox()
        Me.label50 = New System.Windows.Forms.Label()
        Me.edCropTop = New System.Windows.Forms.TextBox()
        Me.label51 = New System.Windows.Forms.Label()
        Me.cbCrop = New System.Windows.Forms.CheckBox()
        Me.cbResizeMode = New System.Windows.Forms.ComboBox()
        Me.label49 = New System.Windows.Forms.Label()
        Me.cbResizeLetterbox = New System.Windows.Forms.CheckBox()
        Me.edResizeHeight = New System.Windows.Forms.TextBox()
        Me.label35 = New System.Windows.Forms.Label()
        Me.edResizeWidth = New System.Windows.Forms.TextBox()
        Me.label29 = New System.Windows.Forms.Label()
        Me.cbResize = New System.Windows.Forms.CheckBox()
        Me.TabPage60 = New System.Windows.Forms.TabPage()
        Me.pnChromaKeyColor = New System.Windows.Forms.Panel()
        Me.btChromaKeySelectBGImage = New System.Windows.Forms.Button()
        Me.edChromaKeyImage = New System.Windows.Forms.TextBox()
        Me.label216 = New System.Windows.Forms.Label()
        Me.label215 = New System.Windows.Forms.Label()
        Me.tbChromaKeySmoothing = New System.Windows.Forms.TrackBar()
        Me.label214 = New System.Windows.Forms.Label()
        Me.tbChromaKeyThresholdSensitivity = New System.Windows.Forms.TrackBar()
        Me.label213 = New System.Windows.Forms.Label()
        Me.cbChromaKeyEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage70 = New System.Windows.Forms.TabPage()
        Me.btFilterDeleteAll = New System.Windows.Forms.Button()
        Me.btFilterSettings2 = New System.Windows.Forms.Button()
        Me.lbFilters = New System.Windows.Forms.ListBox()
        Me.label106 = New System.Windows.Forms.Label()
        Me.btFilterSettings = New System.Windows.Forms.Button()
        Me.btFilterAdd = New System.Windows.Forms.Button()
        Me.cbFilters = New System.Windows.Forms.ComboBox()
        Me.label105 = New System.Windows.Forms.Label()
        Me.tabControl14 = New System.Windows.Forms.TabControl()
        Me.tabPage5 = New System.Windows.Forms.TabPage()
        Me.tabPage58 = New System.Windows.Forms.TabPage()
        Me.tabPage27 = New System.Windows.Forms.TabPage()
        Me.Label250 = New System.Windows.Forms.Label()
        Me.tabControl18 = New System.Windows.Forms.TabControl()
        Me.tabPage71 = New System.Windows.Forms.TabPage()
        Me.label231 = New System.Windows.Forms.Label()
        Me.label230 = New System.Windows.Forms.Label()
        Me.tbAudAmplifyAmp = New System.Windows.Forms.TrackBar()
        Me.label95 = New System.Windows.Forms.Label()
        Me.cbAudAmplifyEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage72 = New System.Windows.Forms.TabPage()
        Me.btAudEqRefresh = New System.Windows.Forms.Button()
        Me.cbAudEqualizerPreset = New System.Windows.Forms.ComboBox()
        Me.label243 = New System.Windows.Forms.Label()
        Me.label242 = New System.Windows.Forms.Label()
        Me.label241 = New System.Windows.Forms.Label()
        Me.label240 = New System.Windows.Forms.Label()
        Me.label239 = New System.Windows.Forms.Label()
        Me.label238 = New System.Windows.Forms.Label()
        Me.label237 = New System.Windows.Forms.Label()
        Me.label236 = New System.Windows.Forms.Label()
        Me.label235 = New System.Windows.Forms.Label()
        Me.label234 = New System.Windows.Forms.Label()
        Me.label233 = New System.Windows.Forms.Label()
        Me.label232 = New System.Windows.Forms.Label()
        Me.tbAudEq9 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq8 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq7 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq6 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq5 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq4 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq3 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq2 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq1 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq0 = New System.Windows.Forms.TrackBar()
        Me.cbAudEqualizerEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage73 = New System.Windows.Forms.TabPage()
        Me.tbAudRelease = New System.Windows.Forms.TrackBar()
        Me.label248 = New System.Windows.Forms.Label()
        Me.label249 = New System.Windows.Forms.Label()
        Me.label246 = New System.Windows.Forms.Label()
        Me.tbAudAttack = New System.Windows.Forms.TrackBar()
        Me.label247 = New System.Windows.Forms.Label()
        Me.label244 = New System.Windows.Forms.Label()
        Me.tbAudDynAmp = New System.Windows.Forms.TrackBar()
        Me.label245 = New System.Windows.Forms.Label()
        Me.cbAudDynamicAmplifyEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage75 = New System.Windows.Forms.TabPage()
        Me.tbAud3DSound = New System.Windows.Forms.TrackBar()
        Me.label253 = New System.Windows.Forms.Label()
        Me.cbAudSound3DEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage76 = New System.Windows.Forms.TabPage()
        Me.tbAudTrueBass = New System.Windows.Forms.TrackBar()
        Me.label254 = New System.Windows.Forms.Label()
        Me.cbAudTrueBassEnabled = New System.Windows.Forms.CheckBox()
        Me.cbAudioEffectsEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage124 = New System.Windows.Forms.TabPage()
        Me.lbAudioTimeshift = New System.Windows.Forms.Label()
        Me.tbAudioTimeshift = New System.Windows.Forms.TrackBar()
        Me.Label430 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbAudioOutputGainLFE = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainLFE = New System.Windows.Forms.TrackBar()
        Me.Label431 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainSR = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainSR = New System.Windows.Forms.TrackBar()
        Me.Label439 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainSL = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainSL = New System.Windows.Forms.TrackBar()
        Me.Label440 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainR = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainR = New System.Windows.Forms.TrackBar()
        Me.Label441 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainC = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainC = New System.Windows.Forms.TrackBar()
        Me.Label442 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainL = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainL = New System.Windows.Forms.TrackBar()
        Me.Label443 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lbAudioInputGainLFE = New System.Windows.Forms.Label()
        Me.tbAudioInputGainLFE = New System.Windows.Forms.TrackBar()
        Me.Label444 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainSR = New System.Windows.Forms.Label()
        Me.tbAudioInputGainSR = New System.Windows.Forms.TrackBar()
        Me.Label445 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainSL = New System.Windows.Forms.Label()
        Me.tbAudioInputGainSL = New System.Windows.Forms.TrackBar()
        Me.Label446 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainR = New System.Windows.Forms.Label()
        Me.tbAudioInputGainR = New System.Windows.Forms.TrackBar()
        Me.Label447 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainC = New System.Windows.Forms.Label()
        Me.tbAudioInputGainC = New System.Windows.Forms.TrackBar()
        Me.Label448 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainL = New System.Windows.Forms.Label()
        Me.tbAudioInputGainL = New System.Windows.Forms.TrackBar()
        Me.Label449 = New System.Windows.Forms.Label()
        Me.cbAudioAutoGain = New System.Windows.Forms.CheckBox()
        Me.cbAudioNormalize = New System.Windows.Forms.CheckBox()
        Me.cbAudioEnhancementEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage22 = New System.Windows.Forms.TabPage()
        Me.btAudioChannelMapperClear = New System.Windows.Forms.Button()
        Me.groupBox41 = New System.Windows.Forms.GroupBox()
        Me.btAudioChannelMapperAddNewRoute = New System.Windows.Forms.Button()
        Me.label311 = New System.Windows.Forms.Label()
        Me.tbAudioChannelMapperVolume = New System.Windows.Forms.TrackBar()
        Me.label310 = New System.Windows.Forms.Label()
        Me.edAudioChannelMapperTargetChannel = New System.Windows.Forms.TextBox()
        Me.label309 = New System.Windows.Forms.Label()
        Me.edAudioChannelMapperSourceChannel = New System.Windows.Forms.TextBox()
        Me.label308 = New System.Windows.Forms.Label()
        Me.label307 = New System.Windows.Forms.Label()
        Me.edAudioChannelMapperOutputChannels = New System.Windows.Forms.TextBox()
        Me.label306 = New System.Windows.Forms.Label()
        Me.lbAudioChannelMapperRoutes = New System.Windows.Forms.ListBox()
        Me.cbAudioChannelMapperEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage7 = New System.Windows.Forms.TabPage()
        Me.cbNetworkStreamingMode = New System.Windows.Forms.ComboBox()
        Me.tabControl5 = New System.Windows.Forms.TabControl()
        Me.tpWMV = New System.Windows.Forms.TabPage()
        Me.label48 = New System.Windows.Forms.Label()
        Me.edNetworkURL = New System.Windows.Forms.TextBox()
        Me.edWMVNetworkPort = New System.Windows.Forms.TextBox()
        Me.label47 = New System.Windows.Forms.Label()
        Me.btRefreshClients = New System.Windows.Forms.Button()
        Me.lbNetworkClients = New System.Windows.Forms.ListBox()
        Me.rbNetworkStreamingUseExternalProfile = New System.Windows.Forms.RadioButton()
        Me.rbNetworkStreamingUseMainWMVSettings = New System.Windows.Forms.RadioButton()
        Me.label81 = New System.Windows.Forms.Label()
        Me.label80 = New System.Windows.Forms.Label()
        Me.edMaximumClients = New System.Windows.Forms.TextBox()
        Me.label46 = New System.Windows.Forms.Label()
        Me.btSelectWMVProfileNetwork = New System.Windows.Forms.Button()
        Me.edNetworkStreamingWMVProfile = New System.Windows.Forms.TextBox()
        Me.label44 = New System.Windows.Forms.Label()
        Me.tpRTSP = New System.Windows.Forms.TabPage()
        Me.edNetworkRTSPURL = New System.Windows.Forms.TextBox()
        Me.label367 = New System.Windows.Forms.Label()
        Me.label366 = New System.Windows.Forms.Label()
        Me.tpRTMP = New System.Windows.Forms.TabPage()
        Me.cbNetworkRTMPFFMPEGUsePipes = New System.Windows.Forms.CheckBox()
        Me.linkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.rbNetworkRTMPFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkRTMPFFMPEG = New System.Windows.Forms.RadioButton()
        Me.edNetworkRTMPURL = New System.Windows.Forms.TextBox()
        Me.label368 = New System.Windows.Forms.Label()
        Me.label369 = New System.Windows.Forms.Label()
        Me.tpNDI = New System.Windows.Forms.TabPage()
        Me.linkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.label38 = New System.Windows.Forms.Label()
        Me.label31 = New System.Windows.Forms.Label()
        Me.edNDIURL = New System.Windows.Forms.TextBox()
        Me.edNDIName = New System.Windows.Forms.TextBox()
        Me.label30 = New System.Windows.Forms.Label()
        Me.tpUDP = New System.Windows.Forms.TabPage()
        Me.cbNetworkUDPFFMPEGUsePipes = New System.Windows.Forms.CheckBox()
        Me.label314 = New System.Windows.Forms.Label()
        Me.label313 = New System.Windows.Forms.Label()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.label484 = New System.Windows.Forms.Label()
        Me.edNetworkUDPURL = New System.Windows.Forms.TextBox()
        Me.label372 = New System.Windows.Forms.Label()
        Me.rbNetworkUDPFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkUDPFFMPEG = New System.Windows.Forms.RadioButton()
        Me.tpSSF = New System.Windows.Forms.TabPage()
        Me.cbNetworkSSUsePipes = New System.Windows.Forms.CheckBox()
        Me.linkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.rbNetworkSSFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkSSFFMPEGDefault = New System.Windows.Forms.RadioButton()
        Me.linkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.edNetworkSSURL = New System.Windows.Forms.TextBox()
        Me.label370 = New System.Windows.Forms.Label()
        Me.label371 = New System.Windows.Forms.Label()
        Me.rbNetworkSSSoftware = New System.Windows.Forms.RadioButton()
        Me.tpHLS = New System.Windows.Forms.TabPage()
        Me.edHLSURL = New System.Windows.Forms.TextBox()
        Me.label19 = New System.Windows.Forms.Label()
        Me.edHLSEmbeddedHTTPServerPort = New System.Windows.Forms.TextBox()
        Me.cbHLSEmbeddedHTTPServerEnabled = New System.Windows.Forms.CheckBox()
        Me.cbHLSMode = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.lbHLSConfigure = New System.Windows.Forms.LinkLabel()
        Me.label532 = New System.Windows.Forms.Label()
        Me.label531 = New System.Windows.Forms.Label()
        Me.label530 = New System.Windows.Forms.Label()
        Me.label529 = New System.Windows.Forms.Label()
        Me.edHLSSegmentCount = New System.Windows.Forms.TextBox()
        Me.label519 = New System.Windows.Forms.Label()
        Me.edHLSSegmentDuration = New System.Windows.Forms.TextBox()
        Me.btSelectHLSOutputFolder = New System.Windows.Forms.Button()
        Me.edHLSOutputFolder = New System.Windows.Forms.TextBox()
        Me.Label500 = New System.Windows.Forms.Label()
        Me.tpExternal = New System.Windows.Forms.TabPage()
        Me.linkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.cbNetworkStreamingAudioEnabled = New System.Windows.Forms.CheckBox()
        Me.cbNetworkStreaming = New System.Windows.Forms.CheckBox()
        Me.tabPage28 = New System.Windows.Forms.TabPage()
        Me.btOSDRenderLayers = New System.Windows.Forms.Button()
        Me.lbOSDLayers = New System.Windows.Forms.CheckedListBox()
        Me.cbOSDEnabled = New System.Windows.Forms.CheckBox()
        Me.groupBox19 = New System.Windows.Forms.GroupBox()
        Me.btOSDClearLayer = New System.Windows.Forms.Button()
        Me.tabControl6 = New System.Windows.Forms.TabControl()
        Me.tabPage30 = New System.Windows.Forms.TabPage()
        Me.btOSDImageDraw = New System.Windows.Forms.Button()
        Me.pnOSDColorKey = New System.Windows.Forms.Panel()
        Me.cbOSDImageTranspColor = New System.Windows.Forms.CheckBox()
        Me.edOSDImageTop = New System.Windows.Forms.TextBox()
        Me.label115 = New System.Windows.Forms.Label()
        Me.edOSDImageLeft = New System.Windows.Forms.TextBox()
        Me.label114 = New System.Windows.Forms.Label()
        Me.btOSDSelectImage = New System.Windows.Forms.Button()
        Me.edOSDImageFilename = New System.Windows.Forms.TextBox()
        Me.label113 = New System.Windows.Forms.Label()
        Me.tabPage31 = New System.Windows.Forms.TabPage()
        Me.edOSDTextTop = New System.Windows.Forms.TextBox()
        Me.label117 = New System.Windows.Forms.Label()
        Me.edOSDTextLeft = New System.Windows.Forms.TextBox()
        Me.label118 = New System.Windows.Forms.Label()
        Me.label116 = New System.Windows.Forms.Label()
        Me.btOSDSelectFont = New System.Windows.Forms.Button()
        Me.edOSDText = New System.Windows.Forms.TextBox()
        Me.btOSDTextDraw = New System.Windows.Forms.Button()
        Me.tabPage32 = New System.Windows.Forms.TabPage()
        Me.tbOSDTranspLevel = New System.Windows.Forms.TrackBar()
        Me.btOSDSetTransp = New System.Windows.Forms.Button()
        Me.label119 = New System.Windows.Forms.Label()
        Me.btOSDClearLayers = New System.Windows.Forms.Button()
        Me.groupBox15 = New System.Windows.Forms.GroupBox()
        Me.btOSDLayerAdd = New System.Windows.Forms.Button()
        Me.edOSDLayerHeight = New System.Windows.Forms.TextBox()
        Me.label111 = New System.Windows.Forms.Label()
        Me.edOSDLayerWidth = New System.Windows.Forms.TextBox()
        Me.label112 = New System.Windows.Forms.Label()
        Me.edOSDLayerTop = New System.Windows.Forms.TextBox()
        Me.label110 = New System.Windows.Forms.Label()
        Me.edOSDLayerLeft = New System.Windows.Forms.TextBox()
        Me.label109 = New System.Windows.Forms.Label()
        Me.label108 = New System.Windows.Forms.Label()
        Me.tabPage43 = New System.Windows.Forms.TabPage()
        Me.tabControl9 = New System.Windows.Forms.TabControl()
        Me.tabPage44 = New System.Windows.Forms.TabPage()
        Me.pbMotionLevel = New System.Windows.Forms.ProgressBar()
        Me.label158 = New System.Windows.Forms.Label()
        Me.mmMotDetMatrix = New System.Windows.Forms.TextBox()
        Me.tabPage45 = New System.Windows.Forms.TabPage()
        Me.groupBox25 = New System.Windows.Forms.GroupBox()
        Me.cbMotDetHLColor = New System.Windows.Forms.ComboBox()
        Me.label161 = New System.Windows.Forms.Label()
        Me.label160 = New System.Windows.Forms.Label()
        Me.cbMotDetHLEnabled = New System.Windows.Forms.CheckBox()
        Me.tbMotDetHLThreshold = New System.Windows.Forms.TrackBar()
        Me.btMotDetUpdateSettings = New System.Windows.Forms.Button()
        Me.groupBox27 = New System.Windows.Forms.GroupBox()
        Me.edMotDetMatrixHeight = New System.Windows.Forms.TextBox()
        Me.label163 = New System.Windows.Forms.Label()
        Me.edMotDetMatrixWidth = New System.Windows.Forms.TextBox()
        Me.label164 = New System.Windows.Forms.Label()
        Me.groupBox26 = New System.Windows.Forms.GroupBox()
        Me.label162 = New System.Windows.Forms.Label()
        Me.tbMotDetDropFramesThreshold = New System.Windows.Forms.TrackBar()
        Me.cbMotDetDropFramesEnabled = New System.Windows.Forms.CheckBox()
        Me.groupBox24 = New System.Windows.Forms.GroupBox()
        Me.edMotDetFrameInterval = New System.Windows.Forms.TextBox()
        Me.label159 = New System.Windows.Forms.Label()
        Me.cbCompareGreyscale = New System.Windows.Forms.CheckBox()
        Me.cbCompareBlue = New System.Windows.Forms.CheckBox()
        Me.cbCompareGreen = New System.Windows.Forms.CheckBox()
        Me.cbCompareRed = New System.Windows.Forms.CheckBox()
        Me.cbMotDetEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage26 = New System.Windows.Forms.TabPage()
        Me.label505 = New System.Windows.Forms.Label()
        Me.rbMotionDetectionExProcessor = New System.Windows.Forms.ComboBox()
        Me.label389 = New System.Windows.Forms.Label()
        Me.rbMotionDetectionExDetector = New System.Windows.Forms.ComboBox()
        Me.label64 = New System.Windows.Forms.Label()
        Me.cbMotionDetectionEx = New System.Windows.Forms.CheckBox()
        Me.label65 = New System.Windows.Forms.Label()
        Me.pbAFMotionLevel = New System.Windows.Forms.ProgressBar()
        Me.TabPage25 = New System.Windows.Forms.TabPage()
        Me.edBarcodeMetadata = New System.Windows.Forms.TextBox()
        Me.label91 = New System.Windows.Forms.Label()
        Me.cbBarcodeType = New System.Windows.Forms.ComboBox()
        Me.label90 = New System.Windows.Forms.Label()
        Me.btBarcodeReset = New System.Windows.Forms.Button()
        Me.edBarcode = New System.Windows.Forms.TextBox()
        Me.label89 = New System.Windows.Forms.Label()
        Me.cbBarcodeDetectionEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage100 = New System.Windows.Forms.TabPage()
        Me.label328 = New System.Windows.Forms.Label()
        Me.label327 = New System.Windows.Forms.Label()
        Me.label326 = New System.Windows.Forms.Label()
        Me.label325 = New System.Windows.Forms.Label()
        Me.cbVirtualCamera = New System.Windows.Forms.CheckBox()
        Me.TabPage102 = New System.Windows.Forms.TabPage()
        Me.cbDecklinkOutputDownConversionAnalogOutput = New System.Windows.Forms.CheckBox()
        Me.cbDecklinkOutputDownConversion = New System.Windows.Forms.ComboBox()
        Me.label337 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputHDTVPulldown = New System.Windows.Forms.ComboBox()
        Me.label336 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputBlackToDeck = New System.Windows.Forms.ComboBox()
        Me.label335 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputSingleField = New System.Windows.Forms.ComboBox()
        Me.label334 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputComponentLevels = New System.Windows.Forms.ComboBox()
        Me.label333 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputNTSC = New System.Windows.Forms.ComboBox()
        Me.label332 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputDualLink = New System.Windows.Forms.ComboBox()
        Me.label331 = New System.Windows.Forms.Label()
        Me.cbDecklinkOutputAnalog = New System.Windows.Forms.ComboBox()
        Me.label87 = New System.Windows.Forms.Label()
        Me.cbDecklinkDV = New System.Windows.Forms.CheckBox()
        Me.cbDecklinkOutput = New System.Windows.Forms.CheckBox()
        Me.TabPage105 = New System.Windows.Forms.TabPage()
        Me.groupBox48 = New System.Windows.Forms.GroupBox()
        Me.label343 = New System.Windows.Forms.Label()
        Me.edEncryptionKeyHEX = New System.Windows.Forms.TextBox()
        Me.rbEncryptionKeyBinary = New System.Windows.Forms.RadioButton()
        Me.btEncryptionOpenFile = New System.Windows.Forms.Button()
        Me.edEncryptionKeyFile = New System.Windows.Forms.TextBox()
        Me.rbEncryptionKeyFile = New System.Windows.Forms.RadioButton()
        Me.edEncryptionKeyString = New System.Windows.Forms.TextBox()
        Me.rbEncryptionKeyString = New System.Windows.Forms.RadioButton()
        Me.groupBox47 = New System.Windows.Forms.GroupBox()
        Me.rbEncryptionModeAES256 = New System.Windows.Forms.RadioButton()
        Me.rbEncryptionModeAES128 = New System.Windows.Forms.RadioButton()
        Me.groupBox43 = New System.Windows.Forms.GroupBox()
        Me.rbEncryptedH264CUDA = New System.Windows.Forms.RadioButton()
        Me.rbEncryptedH264SW = New System.Windows.Forms.RadioButton()
        Me.TabPage106 = New System.Windows.Forms.TabPage()
        Me.label365 = New System.Windows.Forms.Label()
        Me.edFaceTrackingFaces = New System.Windows.Forms.TextBox()
        Me.label364 = New System.Windows.Forms.Label()
        Me.label363 = New System.Windows.Forms.Label()
        Me.cbFaceTrackingScalingMode = New System.Windows.Forms.ComboBox()
        Me.label362 = New System.Windows.Forms.Label()
        Me.edFaceTrackingScaleFactor = New System.Windows.Forms.TextBox()
        Me.label361 = New System.Windows.Forms.Label()
        Me.cbFaceTrackingSearchMode = New System.Windows.Forms.ComboBox()
        Me.cbFaceTrackingColorMode = New System.Windows.Forms.ComboBox()
        Me.label346 = New System.Windows.Forms.Label()
        Me.edFaceTrackingMinimumWindowSize = New System.Windows.Forms.TextBox()
        Me.label345 = New System.Windows.Forms.Label()
        Me.cbFaceTrackingCHL = New System.Windows.Forms.CheckBox()
        Me.cbFaceTrackingEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage141 = New System.Windows.Forms.TabPage()
        Me.TabControl32 = New System.Windows.Forms.TabControl()
        Me.TabPage142 = New System.Windows.Forms.TabPage()
        Me.edTagTrackID = New System.Windows.Forms.TextBox()
        Me.Label496 = New System.Windows.Forms.Label()
        Me.edTagYear = New System.Windows.Forms.TextBox()
        Me.Label495 = New System.Windows.Forms.Label()
        Me.edTagComment = New System.Windows.Forms.TextBox()
        Me.Label493 = New System.Windows.Forms.Label()
        Me.edTagAlbum = New System.Windows.Forms.TextBox()
        Me.Label491 = New System.Windows.Forms.Label()
        Me.edTagArtists = New System.Windows.Forms.TextBox()
        Me.Label490 = New System.Windows.Forms.Label()
        Me.edTagCopyright = New System.Windows.Forms.TextBox()
        Me.Label489 = New System.Windows.Forms.Label()
        Me.edTagTitle = New System.Windows.Forms.TextBox()
        Me.Label488 = New System.Windows.Forms.Label()
        Me.TabPage143 = New System.Windows.Forms.TabPage()
        Me.imgTagCover = New System.Windows.Forms.PictureBox()
        Me.Label499 = New System.Windows.Forms.Label()
        Me.Label498 = New System.Windows.Forms.Label()
        Me.edTagLyrics = New System.Windows.Forms.TextBox()
        Me.Label497 = New System.Windows.Forms.Label()
        Me.cbTagGenre = New System.Windows.Forms.ComboBox()
        Me.Label494 = New System.Windows.Forms.Label()
        Me.edTagComposers = New System.Windows.Forms.TextBox()
        Me.Label492 = New System.Windows.Forms.Label()
        Me.cbTagEnabled = New System.Windows.Forms.CheckBox()
        Me.openFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.VideoCapture1 = New VisioForge.Controls.UI.WinForms.VideoCapture()
        Me.btSaveScreenshot = New System.Windows.Forms.Button()
        Me.lbTimestamp = New System.Windows.Forms.Label()
        Me.tabControl12.SuspendLayout
        Me.tabPage53.SuspendLayout
        Me.tabControl10.SuspendLayout
        Me.tabPage46.SuspendLayout
        Me.tabControl2.SuspendLayout
        Me.tabPage8.SuspendLayout
        Me.tabPage52.SuspendLayout
        Me.tabPage10.SuspendLayout
        Me.tabControl3.SuspendLayout
        Me.tabPage14.SuspendLayout
        Me.tabPage15.SuspendLayout
        Me.groupBox1.SuspendLayout
        Me.tabPage21.SuspendLayout
        Me.tabPage33.SuspendLayout
        Me.tabPage11.SuspendLayout
        Me.groupBox21.SuspendLayout
        Me.groupBox2.SuspendLayout
        Me.tabPage57.SuspendLayout
        CType(Me.tbAdjSaturation,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAdjHue,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAdjContrast,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAdjBrightness,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage3.SuspendLayout
        CType(Me.tbCCFocus,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbCCZoom,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbCCTilt,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbCCPan,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage9.SuspendLayout
        Me.tabControl19.SuspendLayout
        Me.tabPage96.SuspendLayout
        Me.tabPage97.SuspendLayout
        CType(Me.tbAudioBalance,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioVolume,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage98.SuspendLayout
        Me.TabPage111.SuspendLayout
        CType(Me.tbVUMeterBoost,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbVUMeterAmplification,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage99.SuspendLayout
        Me.tabPage47.SuspendLayout
        Me.tabPage48.SuspendLayout
        Me.tabControl15.SuspendLayout
        Me.tabPage144.SuspendLayout
        Me.tabPage146.SuspendLayout
        Me.tabPage145.SuspendLayout
        Me.groupBox42.SuspendLayout
        Me.TabPage61.SuspendLayout
        Me.TabPage66.SuspendLayout
        Me.tabControl22.SuspendLayout
        Me.tabPage82.SuspendLayout
        Me.tabPage83.SuspendLayout
        Me.tabControl23.SuspendLayout
        Me.tabPage84.SuspendLayout
        Me.tabPage85.SuspendLayout
        Me.tabPage86.SuspendLayout
        Me.groupBox35.SuspendLayout
        Me.groupBox36.SuspendLayout
        Me.tabPage87.SuspendLayout
        Me.TabPage104.SuspendLayout
        Me.tabPage49.SuspendLayout
        Me.tabControl20.SuspendLayout
        Me.tabPage67.SuspendLayout
        Me.tabControl21.SuspendLayout
        Me.tabPage78.SuspendLayout
        Me.groupBox30.SuspendLayout
        Me.tabPage79.SuspendLayout
        Me.groupBox31.SuspendLayout
        Me.tabPage80.SuspendLayout
        Me.groupBox32.SuspendLayout
        Me.TabPage93.SuspendLayout
        Me.groupBox44.SuspendLayout
        Me.tabPage77.SuspendLayout
        Me.groupBox34.SuspendLayout
        CType(Me.tbPIPTransparency,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox33.SuspendLayout
        Me.groupBox20.SuspendLayout
        Me.TabPage113.SuspendLayout
        CType(Me.tbPIPChromaKeyTolerance2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbPIPChromaKeyTolerance1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage50.SuspendLayout
        Me.tabPage51.SuspendLayout
        Me.tabControl26.SuspendLayout
        Me.tabPage115.SuspendLayout
        Me.groupBox28.SuspendLayout
        Me.groupBox13.SuspendLayout
        Me.tabPage116.SuspendLayout
        Me.TabPage23.SuspendLayout
        Me.groupBox8.SuspendLayout
        Me.TabPage123.SuspendLayout
        Me.tabControl28.SuspendLayout
        Me.tabPage125.SuspendLayout
        Me.tabPage126.SuspendLayout
        Me.tabControl1.SuspendLayout
        Me.tabPage1.SuspendLayout
        Me.tabPage2.SuspendLayout
        Me.tabControl17.SuspendLayout
        Me.tabPage68.SuspendLayout
        Me.tabControl7.SuspendLayout
        Me.tabPage29.SuspendLayout
        Me.tabPage42.SuspendLayout
        Me.TabPage88.SuspendLayout
        Me.groupBox37.SuspendLayout
        Me.TabPage91.SuspendLayout
        Me.groupBox40.SuspendLayout
        Me.groupBox39.SuspendLayout
        Me.groupBox38.SuspendLayout
        Me.TabPage101.SuspendLayout
        Me.groupBox45.SuspendLayout
        Me.TabPage112.SuspendLayout
        CType(Me.tbLiveRotationAngle,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage69.SuspendLayout
        Me.TabPage59.SuspendLayout
        Me.TabPage63.SuspendLayout
        CType(Me.tbGPUBlur,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbGPUContrast,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbGPUDarkness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbGPULightness,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbGPUSaturation,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage92.SuspendLayout
        Me.TabPage60.SuspendLayout
        CType(Me.tbChromaKeySmoothing,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbChromaKeyThresholdSensitivity,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage70.SuspendLayout
        Me.tabControl14.SuspendLayout
        Me.tabPage27.SuspendLayout
        Me.tabControl18.SuspendLayout
        Me.tabPage71.SuspendLayout
        CType(Me.tbAudAmplifyAmp,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage72.SuspendLayout
        CType(Me.tbAudEq9,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq7,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq6,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudEq0,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage73.SuspendLayout
        CType(Me.tbAudRelease,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudAttack,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudDynAmp,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage75.SuspendLayout
        CType(Me.tbAud3DSound,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage76.SuspendLayout
        CType(Me.tbAudTrueBass,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage124.SuspendLayout
        CType(Me.tbAudioTimeshift,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox3.SuspendLayout
        CType(Me.tbAudioOutputGainLFE,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioOutputGainSR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioOutputGainSL,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioOutputGainR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioOutputGainC,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioOutputGainL,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox7.SuspendLayout
        CType(Me.tbAudioInputGainLFE,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioInputGainSR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioInputGainSL,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioInputGainR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioInputGainC,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbAudioInputGainL,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage22.SuspendLayout
        Me.groupBox41.SuspendLayout
        CType(Me.tbAudioChannelMapperVolume,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPage7.SuspendLayout
        Me.tabControl5.SuspendLayout
        Me.tpWMV.SuspendLayout
        Me.tpRTSP.SuspendLayout
        Me.tpRTMP.SuspendLayout
        Me.tpNDI.SuspendLayout
        Me.tpUDP.SuspendLayout
        Me.tpSSF.SuspendLayout
        Me.tpHLS.SuspendLayout
        Me.tpExternal.SuspendLayout
        Me.tabPage28.SuspendLayout
        Me.groupBox19.SuspendLayout
        Me.tabControl6.SuspendLayout
        Me.tabPage30.SuspendLayout
        Me.tabPage31.SuspendLayout
        Me.tabPage32.SuspendLayout
        CType(Me.tbOSDTranspLevel,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox15.SuspendLayout
        Me.tabPage43.SuspendLayout
        Me.tabControl9.SuspendLayout
        Me.tabPage44.SuspendLayout
        Me.tabPage45.SuspendLayout
        Me.groupBox25.SuspendLayout
        CType(Me.tbMotDetHLThreshold,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox27.SuspendLayout
        Me.groupBox26.SuspendLayout
        CType(Me.tbMotDetDropFramesThreshold,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox24.SuspendLayout
        Me.TabPage26.SuspendLayout
        Me.TabPage25.SuspendLayout
        Me.TabPage100.SuspendLayout
        Me.TabPage102.SuspendLayout
        Me.TabPage105.SuspendLayout
        Me.groupBox48.SuspendLayout
        Me.groupBox47.SuspendLayout
        Me.groupBox43.SuspendLayout
        Me.TabPage106.SuspendLayout
        Me.TabPage141.SuspendLayout
        Me.TabControl32.SuspendLayout
        Me.TabPage142.SuspendLayout
        Me.TabPage143.SuspendLayout
        CType(Me.imgTagCover,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fontDialog1
        '
        Me.fontDialog1.Color = System.Drawing.Color.White
        Me.fontDialog1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.fontDialog1.FontMustExist = true
        Me.fontDialog1.ShowColor = true
        '
        'openFileDialog2
        '
        Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = true
        Me.linkLabel1.Location = New System.Drawing.Point(6, 691)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(78, 13)
        Me.linkLabel1.TabIndex = 87
        Me.linkLabel1.TabStop = true
        Me.linkLabel1.Text = "Watch tutorials"
        '
        'tabControl12
        '
        Me.tabControl12.Controls.Add(Me.tabPage53)
        Me.tabControl12.Location = New System.Drawing.Point(9, 519)
        Me.tabControl12.Name = "tabControl12"
        Me.tabControl12.SelectedIndex = 0
        Me.tabControl12.Size = New System.Drawing.Size(315, 169)
        Me.tabControl12.TabIndex = 86
        '
        'tabPage53
        '
        Me.tabPage53.Controls.Add(Me.cbTelemetry)
        Me.tabPage53.Controls.Add(Me.cbDebugMode)
        Me.tabPage53.Controls.Add(Me.mmLog)
        Me.tabPage53.Location = New System.Drawing.Point(4, 22)
        Me.tabPage53.Name = "tabPage53"
        Me.tabPage53.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage53.Size = New System.Drawing.Size(307, 143)
        Me.tabPage53.TabIndex = 2
        Me.tabPage53.Text = "Errors"
        Me.tabPage53.UseVisualStyleBackColor = true
        '
        'cbTelemetry
        '
        Me.cbTelemetry.AutoSize = true
        Me.cbTelemetry.Checked = true
        Me.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbTelemetry.Location = New System.Drawing.Point(102, 6)
        Me.cbTelemetry.Name = "cbTelemetry"
        Me.cbTelemetry.Size = New System.Drawing.Size(72, 17)
        Me.cbTelemetry.TabIndex = 78
        Me.cbTelemetry.Text = "Telemetry"
        Me.cbTelemetry.UseVisualStyleBackColor = true
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = true
        Me.cbDebugMode.Location = New System.Drawing.Point(9, 6)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 73
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = true
        '
        'mmLog
        '
        Me.mmLog.Location = New System.Drawing.Point(9, 29)
        Me.mmLog.Multiline = true
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(278, 106)
        Me.mmLog.TabIndex = 72
        '
        'tabControl10
        '
        Me.tabControl10.Controls.Add(Me.tabPage46)
        Me.tabControl10.Controls.Add(Me.TabPage9)
        Me.tabControl10.Controls.Add(Me.tabPage47)
        Me.tabControl10.Controls.Add(Me.tabPage48)
        Me.tabControl10.Controls.Add(Me.TabPage61)
        Me.tabControl10.Controls.Add(Me.TabPage66)
        Me.tabControl10.Controls.Add(Me.tabPage49)
        Me.tabControl10.Controls.Add(Me.tabPage50)
        Me.tabControl10.Controls.Add(Me.tabPage51)
        Me.tabControl10.Controls.Add(Me.TabPage23)
        Me.tabControl10.Controls.Add(Me.TabPage123)
        Me.tabControl10.Location = New System.Drawing.Point(334, 7)
        Me.tabControl10.Name = "tabControl10"
        Me.tabControl10.SelectedIndex = 0
        Me.tabControl10.Size = New System.Drawing.Size(467, 311)
        Me.tabControl10.TabIndex = 85
        '
        'tabPage46
        '
        Me.tabPage46.Controls.Add(Me.tabControl2)
        Me.tabPage46.Location = New System.Drawing.Point(4, 22)
        Me.tabPage46.Name = "tabPage46"
        Me.tabPage46.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage46.Size = New System.Drawing.Size(459, 285)
        Me.tabPage46.TabIndex = 0
        Me.tabPage46.Text = "Video capture device"
        Me.tabPage46.UseVisualStyleBackColor = true
        '
        'tabControl2
        '
        Me.tabControl2.Controls.Add(Me.tabPage8)
        Me.tabControl2.Controls.Add(Me.tabPage52)
        Me.tabControl2.Controls.Add(Me.tabPage10)
        Me.tabControl2.Controls.Add(Me.tabPage11)
        Me.tabControl2.Controls.Add(Me.tabPage57)
        Me.tabControl2.Controls.Add(Me.TabPage3)
        Me.tabControl2.Location = New System.Drawing.Point(3, 6)
        Me.tabControl2.Name = "tabControl2"
        Me.tabControl2.SelectedIndex = 0
        Me.tabControl2.Size = New System.Drawing.Size(456, 272)
        Me.tabControl2.TabIndex = 66
        '
        'tabPage8
        '
        Me.tabPage8.Controls.Add(Me.btSignal)
        Me.tabPage8.Controls.Add(Me.label28)
        Me.tabPage8.Controls.Add(Me.cbUseBestVideoInputFormat)
        Me.tabPage8.Controls.Add(Me.btVideoCaptureDeviceSettings)
        Me.tabPage8.Controls.Add(Me.label18)
        Me.tabPage8.Controls.Add(Me.cbFramerate)
        Me.tabPage8.Controls.Add(Me.cbVideoInputFormat)
        Me.tabPage8.Controls.Add(Me.cbVideoInputDevice)
        Me.tabPage8.Controls.Add(Me.label13)
        Me.tabPage8.Controls.Add(Me.label11)
        Me.tabPage8.Location = New System.Drawing.Point(4, 22)
        Me.tabPage8.Name = "tabPage8"
        Me.tabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage8.Size = New System.Drawing.Size(448, 246)
        Me.tabPage8.TabIndex = 0
        Me.tabPage8.Text = "Video input"
        Me.tabPage8.UseVisualStyleBackColor = true
        '
        'btSignal
        '
        Me.btSignal.Location = New System.Drawing.Point(308, 33)
        Me.btSignal.Name = "btSignal"
        Me.btSignal.Size = New System.Drawing.Size(65, 23)
        Me.btSignal.TabIndex = 137
        Me.btSignal.Text = "Signal"
        Me.btSignal.UseVisualStyleBackColor = true
        '
        'label28
        '
        Me.label28.AutoSize = true
        Me.label28.Location = New System.Drawing.Point(308, 102)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(21, 13)
        Me.label28.TabIndex = 119
        Me.label28.Text = "fps"
        '
        'cbUseBestVideoInputFormat
        '
        Me.cbUseBestVideoInputFormat.AutoSize = true
        Me.cbUseBestVideoInputFormat.Location = New System.Drawing.Point(160, 75)
        Me.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat"
        Me.cbUseBestVideoInputFormat.Size = New System.Drawing.Size(68, 17)
        Me.cbUseBestVideoInputFormat.TabIndex = 118
        Me.cbUseBestVideoInputFormat.Text = "Use best"
        Me.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true
        '
        'btVideoCaptureDeviceSettings
        '
        Me.btVideoCaptureDeviceSettings.Location = New System.Drawing.Point(237, 33)
        Me.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings"
        Me.btVideoCaptureDeviceSettings.Size = New System.Drawing.Size(65, 23)
        Me.btVideoCaptureDeviceSettings.TabIndex = 117
        Me.btVideoCaptureDeviceSettings.Text = "Settings"
        Me.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true
        '
        'label18
        '
        Me.label18.AutoSize = true
        Me.label18.Location = New System.Drawing.Point(234, 76)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(57, 13)
        Me.label18.TabIndex = 116
        Me.label18.Text = "Frame rate"
        '
        'cbFramerate
        '
        Me.cbFramerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFramerate.FormattingEnabled = true
        Me.cbFramerate.Location = New System.Drawing.Point(237, 97)
        Me.cbFramerate.Name = "cbFramerate"
        Me.cbFramerate.Size = New System.Drawing.Size(65, 21)
        Me.cbFramerate.TabIndex = 115
        '
        'cbVideoInputFormat
        '
        Me.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFormat.FormattingEnabled = true
        Me.cbVideoInputFormat.Location = New System.Drawing.Point(23, 97)
        Me.cbVideoInputFormat.Name = "cbVideoInputFormat"
        Me.cbVideoInputFormat.Size = New System.Drawing.Size(208, 21)
        Me.cbVideoInputFormat.TabIndex = 114
        '
        'cbVideoInputDevice
        '
        Me.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputDevice.FormattingEnabled = true
        Me.cbVideoInputDevice.Location = New System.Drawing.Point(23, 35)
        Me.cbVideoInputDevice.Name = "cbVideoInputDevice"
        Me.cbVideoInputDevice.Size = New System.Drawing.Size(208, 21)
        Me.cbVideoInputDevice.TabIndex = 113
        '
        'label13
        '
        Me.label13.AutoSize = true
        Me.label13.Location = New System.Drawing.Point(20, 76)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(63, 13)
        Me.label13.TabIndex = 112
        Me.label13.Text = "Input format"
        '
        'label11
        '
        Me.label11.AutoSize = true
        Me.label11.Location = New System.Drawing.Point(20, 13)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(66, 13)
        Me.label11.TabIndex = 111
        Me.label11.Text = "Input device"
        '
        'tabPage52
        '
        Me.tabPage52.Controls.Add(Me.cbCrossBarAvailable)
        Me.tabPage52.Controls.Add(Me.lbRotes)
        Me.tabPage52.Controls.Add(Me.label61)
        Me.tabPage52.Controls.Add(Me.label60)
        Me.tabPage52.Controls.Add(Me.cbConnectRelated)
        Me.tabPage52.Controls.Add(Me.btConnect)
        Me.tabPage52.Controls.Add(Me.cbCrossbarVideoInput)
        Me.tabPage52.Controls.Add(Me.label59)
        Me.tabPage52.Controls.Add(Me.rbCrossbarAdvanced)
        Me.tabPage52.Controls.Add(Me.rbCrossbarSimple)
        Me.tabPage52.Controls.Add(Me.cbCrossbarOutput)
        Me.tabPage52.Controls.Add(Me.cbCrossbarInput)
        Me.tabPage52.Controls.Add(Me.label16)
        Me.tabPage52.Location = New System.Drawing.Point(4, 22)
        Me.tabPage52.Name = "tabPage52"
        Me.tabPage52.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage52.Size = New System.Drawing.Size(448, 246)
        Me.tabPage52.TabIndex = 7
        Me.tabPage52.Text = "Crossbar (Source)"
        Me.tabPage52.UseVisualStyleBackColor = true
        '
        'cbCrossBarAvailable
        '
        Me.cbCrossBarAvailable.AutoSize = true
        Me.cbCrossBarAvailable.Enabled = false
        Me.cbCrossBarAvailable.Location = New System.Drawing.Point(279, 21)
        Me.cbCrossBarAvailable.Name = "cbCrossBarAvailable"
        Me.cbCrossBarAvailable.Size = New System.Drawing.Size(112, 17)
        Me.cbCrossBarAvailable.TabIndex = 94
        Me.cbCrossBarAvailable.Text = "Crossbar available"
        Me.cbCrossBarAvailable.UseVisualStyleBackColor = true
        '
        'lbRotes
        '
        Me.lbRotes.FormattingEnabled = true
        Me.lbRotes.Location = New System.Drawing.Point(99, 164)
        Me.lbRotes.Name = "lbRotes"
        Me.lbRotes.Size = New System.Drawing.Size(246, 43)
        Me.lbRotes.TabIndex = 93
        '
        'label61
        '
        Me.label61.AutoSize = true
        Me.label61.Location = New System.Drawing.Point(52, 186)
        Me.label61.Name = "label61"
        Me.label61.Size = New System.Drawing.Size(36, 13)
        Me.label61.TabIndex = 92
        Me.label61.Text = "routes"
        '
        'label60
        '
        Me.label60.AutoSize = true
        Me.label60.Location = New System.Drawing.Point(52, 164)
        Me.label60.Name = "label60"
        Me.label60.Size = New System.Drawing.Size(41, 13)
        Me.label60.TabIndex = 91
        Me.label60.Text = "Current"
        '
        'cbConnectRelated
        '
        Me.cbConnectRelated.AutoSize = true
        Me.cbConnectRelated.Checked = true
        Me.cbConnectRelated.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbConnectRelated.Location = New System.Drawing.Point(244, 112)
        Me.cbConnectRelated.Name = "cbConnectRelated"
        Me.cbConnectRelated.Size = New System.Drawing.Size(101, 17)
        Me.cbConnectRelated.TabIndex = 90
        Me.cbConnectRelated.Text = "Connect related"
        Me.cbConnectRelated.UseVisualStyleBackColor = true
        '
        'btConnect
        '
        Me.btConnect.Location = New System.Drawing.Point(279, 135)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(66, 23)
        Me.btConnect.TabIndex = 89
        Me.btConnect.Text = "Connect"
        Me.btConnect.UseVisualStyleBackColor = true
        '
        'cbCrossbarVideoInput
        '
        Me.cbCrossbarVideoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCrossbarVideoInput.FormattingEnabled = true
        Me.cbCrossbarVideoInput.Location = New System.Drawing.Point(127, 44)
        Me.cbCrossbarVideoInput.Name = "cbCrossbarVideoInput"
        Me.cbCrossbarVideoInput.Size = New System.Drawing.Size(93, 21)
        Me.cbCrossbarVideoInput.TabIndex = 88
        '
        'label59
        '
        Me.label59.AutoSize = true
        Me.label59.Location = New System.Drawing.Point(52, 47)
        Me.label59.Name = "label59"
        Me.label59.Size = New System.Drawing.Size(60, 13)
        Me.label59.TabIndex = 87
        Me.label59.Text = "Video input"
        '
        'rbCrossbarAdvanced
        '
        Me.rbCrossbarAdvanced.AutoSize = true
        Me.rbCrossbarAdvanced.Location = New System.Drawing.Point(19, 87)
        Me.rbCrossbarAdvanced.Name = "rbCrossbarAdvanced"
        Me.rbCrossbarAdvanced.Size = New System.Drawing.Size(74, 17)
        Me.rbCrossbarAdvanced.TabIndex = 86
        Me.rbCrossbarAdvanced.Text = "Advanced"
        Me.rbCrossbarAdvanced.UseVisualStyleBackColor = true
        '
        'rbCrossbarSimple
        '
        Me.rbCrossbarSimple.AutoSize = true
        Me.rbCrossbarSimple.Checked = true
        Me.rbCrossbarSimple.Location = New System.Drawing.Point(19, 20)
        Me.rbCrossbarSimple.Name = "rbCrossbarSimple"
        Me.rbCrossbarSimple.Size = New System.Drawing.Size(56, 17)
        Me.rbCrossbarSimple.TabIndex = 85
        Me.rbCrossbarSimple.TabStop = true
        Me.rbCrossbarSimple.Text = "Simple"
        Me.rbCrossbarSimple.UseVisualStyleBackColor = true
        '
        'cbCrossbarOutput
        '
        Me.cbCrossbarOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCrossbarOutput.FormattingEnabled = true
        Me.cbCrossbarOutput.Location = New System.Drawing.Point(163, 137)
        Me.cbCrossbarOutput.Name = "cbCrossbarOutput"
        Me.cbCrossbarOutput.Size = New System.Drawing.Size(100, 21)
        Me.cbCrossbarOutput.TabIndex = 84
        '
        'cbCrossbarInput
        '
        Me.cbCrossbarInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCrossbarInput.FormattingEnabled = true
        Me.cbCrossbarInput.Location = New System.Drawing.Point(55, 137)
        Me.cbCrossbarInput.Name = "cbCrossbarInput"
        Me.cbCrossbarInput.Size = New System.Drawing.Size(100, 21)
        Me.cbCrossbarInput.TabIndex = 83
        '
        'label16
        '
        Me.label16.AutoSize = true
        Me.label16.Location = New System.Drawing.Point(52, 113)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(144, 13)
        Me.label16.TabIndex = 82
        Me.label16.Text = "Crossbar (INPUT - OUTPUT)"
        '
        'tabPage10
        '
        Me.tabPage10.Controls.Add(Me.tabControl3)
        Me.tabPage10.Location = New System.Drawing.Point(4, 22)
        Me.tabPage10.Name = "tabPage10"
        Me.tabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage10.Size = New System.Drawing.Size(448, 246)
        Me.tabPage10.TabIndex = 2
        Me.tabPage10.Text = "TV Tuner"
        Me.tabPage10.UseVisualStyleBackColor = true
        '
        'tabControl3
        '
        Me.tabControl3.Controls.Add(Me.tabPage14)
        Me.tabControl3.Controls.Add(Me.tabPage15)
        Me.tabControl3.Controls.Add(Me.tabPage21)
        Me.tabControl3.Controls.Add(Me.tabPage33)
        Me.tabControl3.Location = New System.Drawing.Point(3, 6)
        Me.tabControl3.Name = "tabControl3"
        Me.tabControl3.SelectedIndex = 0
        Me.tabControl3.Size = New System.Drawing.Size(439, 234)
        Me.tabControl3.TabIndex = 0
        '
        'tabPage14
        '
        Me.tabPage14.Controls.Add(Me.cbUseClosedCaptions)
        Me.tabPage14.Controls.Add(Me.edTVDefaultFormat)
        Me.tabPage14.Controls.Add(Me.label57)
        Me.tabPage14.Controls.Add(Me.cbTVCountry)
        Me.tabPage14.Controls.Add(Me.label56)
        Me.tabPage14.Controls.Add(Me.cbTVMode)
        Me.tabPage14.Controls.Add(Me.cbTVInput)
        Me.tabPage14.Controls.Add(Me.cbTVTuner)
        Me.tabPage14.Controls.Add(Me.label33)
        Me.tabPage14.Controls.Add(Me.label32)
        Me.tabPage14.Controls.Add(Me.label27)
        Me.tabPage14.Location = New System.Drawing.Point(4, 22)
        Me.tabPage14.Name = "tabPage14"
        Me.tabPage14.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage14.Size = New System.Drawing.Size(431, 208)
        Me.tabPage14.TabIndex = 0
        Me.tabPage14.Text = "Main settings"
        Me.tabPage14.UseVisualStyleBackColor = true
        '
        'cbUseClosedCaptions
        '
        Me.cbUseClosedCaptions.AutoSize = true
        Me.cbUseClosedCaptions.Location = New System.Drawing.Point(26, 145)
        Me.cbUseClosedCaptions.Name = "cbUseClosedCaptions"
        Me.cbUseClosedCaptions.Size = New System.Drawing.Size(160, 17)
        Me.cbUseClosedCaptions.TabIndex = 61
        Me.cbUseClosedCaptions.Text = "Allow closed captions usage"
        Me.cbUseClosedCaptions.UseVisualStyleBackColor = true
        '
        'edTVDefaultFormat
        '
        Me.edTVDefaultFormat.Location = New System.Drawing.Point(232, 102)
        Me.edTVDefaultFormat.Name = "edTVDefaultFormat"
        Me.edTVDefaultFormat.ReadOnly = true
        Me.edTVDefaultFormat.Size = New System.Drawing.Size(83, 20)
        Me.edTVDefaultFormat.TabIndex = 59
        '
        'label57
        '
        Me.label57.AutoSize = true
        Me.label57.Location = New System.Drawing.Point(229, 83)
        Me.label57.Name = "label57"
        Me.label57.Size = New System.Drawing.Size(73, 13)
        Me.label57.TabIndex = 58
        Me.label57.Text = "Default format"
        '
        'cbTVCountry
        '
        Me.cbTVCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVCountry.FormattingEnabled = true
        Me.cbTVCountry.Location = New System.Drawing.Point(73, 102)
        Me.cbTVCountry.Name = "cbTVCountry"
        Me.cbTVCountry.Size = New System.Drawing.Size(150, 21)
        Me.cbTVCountry.TabIndex = 57
        '
        'label56
        '
        Me.label56.AutoSize = true
        Me.label56.Location = New System.Drawing.Point(23, 105)
        Me.label56.Name = "label56"
        Me.label56.Size = New System.Drawing.Size(43, 13)
        Me.label56.TabIndex = 56
        Me.label56.Text = "Country"
        '
        'cbTVMode
        '
        Me.cbTVMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVMode.FormattingEnabled = true
        Me.cbTVMode.Items.AddRange(New Object() {"Default", "TV", "FM Radio", "AM Radio", "DSS"})
        Me.cbTVMode.Location = New System.Drawing.Point(72, 51)
        Me.cbTVMode.Name = "cbTVMode"
        Me.cbTVMode.Size = New System.Drawing.Size(86, 21)
        Me.cbTVMode.TabIndex = 55
        '
        'cbTVInput
        '
        Me.cbTVInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVInput.FormattingEnabled = true
        Me.cbTVInput.Items.AddRange(New Object() {"Cable", "Antenna"})
        Me.cbTVInput.Location = New System.Drawing.Point(229, 51)
        Me.cbTVInput.Name = "cbTVInput"
        Me.cbTVInput.Size = New System.Drawing.Size(86, 21)
        Me.cbTVInput.TabIndex = 54
        '
        'cbTVTuner
        '
        Me.cbTVTuner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVTuner.FormattingEnabled = true
        Me.cbTVTuner.Location = New System.Drawing.Point(72, 16)
        Me.cbTVTuner.Name = "cbTVTuner"
        Me.cbTVTuner.Size = New System.Drawing.Size(243, 21)
        Me.cbTVTuner.TabIndex = 53
        '
        'label33
        '
        Me.label33.AutoSize = true
        Me.label33.Location = New System.Drawing.Point(23, 54)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(34, 13)
        Me.label33.TabIndex = 52
        Me.label33.Text = "Mode"
        '
        'label32
        '
        Me.label32.AutoSize = true
        Me.label32.Location = New System.Drawing.Point(192, 54)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(31, 13)
        Me.label32.TabIndex = 51
        Me.label32.Text = "Input"
        '
        'label27
        '
        Me.label27.AutoSize = true
        Me.label27.Location = New System.Drawing.Point(23, 19)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(41, 13)
        Me.label27.TabIndex = 50
        Me.label27.Text = "Device"
        '
        'tabPage15
        '
        Me.tabPage15.Controls.Add(Me.edChannel)
        Me.tabPage15.Controls.Add(Me.btUseThisChannel)
        Me.tabPage15.Controls.Add(Me.groupBox1)
        Me.tabPage15.Controls.Add(Me.cbTVSystem)
        Me.tabPage15.Controls.Add(Me.edAudioFreq)
        Me.tabPage15.Controls.Add(Me.label36)
        Me.tabPage15.Controls.Add(Me.edVideoFreq)
        Me.tabPage15.Controls.Add(Me.label37)
        Me.tabPage15.Controls.Add(Me.label34)
        Me.tabPage15.Location = New System.Drawing.Point(4, 22)
        Me.tabPage15.Name = "tabPage15"
        Me.tabPage15.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage15.Size = New System.Drawing.Size(431, 208)
        Me.tabPage15.TabIndex = 1
        Me.tabPage15.Text = "Tuning"
        Me.tabPage15.UseVisualStyleBackColor = true
        '
        'edChannel
        '
        Me.edChannel.Location = New System.Drawing.Point(334, 136)
        Me.edChannel.Name = "edChannel"
        Me.edChannel.Size = New System.Drawing.Size(79, 20)
        Me.edChannel.TabIndex = 59
        Me.edChannel.Text = "22"
        '
        'btUseThisChannel
        '
        Me.btUseThisChannel.Location = New System.Drawing.Point(224, 133)
        Me.btUseThisChannel.Name = "btUseThisChannel"
        Me.btUseThisChannel.Size = New System.Drawing.Size(104, 23)
        Me.btUseThisChannel.TabIndex = 58
        Me.btUseThisChannel.Text = "Set channel/freq."
        Me.btUseThisChannel.UseVisualStyleBackColor = true
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbTVChannel)
        Me.groupBox1.Controls.Add(Me.label58)
        Me.groupBox1.Controls.Add(Me.pbChannels)
        Me.groupBox1.Controls.Add(Me.btStopTune)
        Me.groupBox1.Controls.Add(Me.btStartTune)
        Me.groupBox1.Location = New System.Drawing.Point(16, 19)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(262, 97)
        Me.groupBox1.TabIndex = 57
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "AutoTune"
        '
        'cbTVChannel
        '
        Me.cbTVChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVChannel.FormattingEnabled = true
        Me.cbTVChannel.Location = New System.Drawing.Point(165, 56)
        Me.cbTVChannel.Name = "cbTVChannel"
        Me.cbTVChannel.Size = New System.Drawing.Size(82, 21)
        Me.cbTVChannel.TabIndex = 4
        '
        'label58
        '
        Me.label58.AutoSize = true
        Me.label58.Location = New System.Drawing.Point(17, 59)
        Me.label58.Name = "label58"
        Me.label58.Size = New System.Drawing.Size(142, 13)
        Me.label58.TabIndex = 3
        Me.label58.Text = "TV Channel / FM Frequency"
        '
        'pbChannels
        '
        Me.pbChannels.Location = New System.Drawing.Point(147, 23)
        Me.pbChannels.Name = "pbChannels"
        Me.pbChannels.Size = New System.Drawing.Size(100, 15)
        Me.pbChannels.TabIndex = 2
        '
        'btStopTune
        '
        Me.btStopTune.Location = New System.Drawing.Point(76, 19)
        Me.btStopTune.Name = "btStopTune"
        Me.btStopTune.Size = New System.Drawing.Size(50, 23)
        Me.btStopTune.TabIndex = 1
        Me.btStopTune.Text = "Stop"
        Me.btStopTune.UseVisualStyleBackColor = true
        '
        'btStartTune
        '
        Me.btStartTune.Location = New System.Drawing.Point(20, 19)
        Me.btStartTune.Name = "btStartTune"
        Me.btStartTune.Size = New System.Drawing.Size(50, 23)
        Me.btStartTune.TabIndex = 0
        Me.btStartTune.Text = "Start"
        Me.btStartTune.UseVisualStyleBackColor = true
        '
        'cbTVSystem
        '
        Me.cbTVSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVSystem.FormattingEnabled = true
        Me.cbTVSystem.Location = New System.Drawing.Point(101, 136)
        Me.cbTVSystem.Name = "cbTVSystem"
        Me.cbTVSystem.Size = New System.Drawing.Size(86, 21)
        Me.cbTVSystem.TabIndex = 56
        '
        'edAudioFreq
        '
        Me.edAudioFreq.Location = New System.Drawing.Point(384, 76)
        Me.edAudioFreq.Name = "edAudioFreq"
        Me.edAudioFreq.Size = New System.Drawing.Size(29, 20)
        Me.edAudioFreq.TabIndex = 55
        '
        'label36
        '
        Me.label36.AutoSize = true
        Me.label36.Location = New System.Drawing.Point(289, 78)
        Me.label36.Name = "label36"
        Me.label36.Size = New System.Drawing.Size(84, 13)
        Me.label36.TabIndex = 54
        Me.label36.Text = "Audio frequency"
        '
        'edVideoFreq
        '
        Me.edVideoFreq.Location = New System.Drawing.Point(384, 35)
        Me.edVideoFreq.Name = "edVideoFreq"
        Me.edVideoFreq.Size = New System.Drawing.Size(29, 20)
        Me.edVideoFreq.TabIndex = 53
        '
        'label37
        '
        Me.label37.AutoSize = true
        Me.label37.Location = New System.Drawing.Point(289, 38)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(84, 13)
        Me.label37.TabIndex = 52
        Me.label37.Text = "Video frequency"
        '
        'label34
        '
        Me.label34.AutoSize = true
        Me.label34.Location = New System.Drawing.Point(13, 139)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(82, 13)
        Me.label34.TabIndex = 51
        Me.label34.Text = "TV video format"
        '
        'tabPage21
        '
        Me.tabPage21.Controls.Add(Me.btMPEGEncoderShowDialog)
        Me.tabPage21.Controls.Add(Me.cbMPEGEncoder)
        Me.tabPage21.Controls.Add(Me.label21)
        Me.tabPage21.Location = New System.Drawing.Point(4, 22)
        Me.tabPage21.Name = "tabPage21"
        Me.tabPage21.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage21.Size = New System.Drawing.Size(431, 208)
        Me.tabPage21.TabIndex = 3
        Me.tabPage21.Text = "MPEG Encoder"
        Me.tabPage21.UseVisualStyleBackColor = true
        '
        'btMPEGEncoderShowDialog
        '
        Me.btMPEGEncoderShowDialog.Location = New System.Drawing.Point(241, 30)
        Me.btMPEGEncoderShowDialog.Name = "btMPEGEncoderShowDialog"
        Me.btMPEGEncoderShowDialog.Size = New System.Drawing.Size(75, 23)
        Me.btMPEGEncoderShowDialog.TabIndex = 2
        Me.btMPEGEncoderShowDialog.Text = "Settings"
        Me.btMPEGEncoderShowDialog.UseVisualStyleBackColor = true
        '
        'cbMPEGEncoder
        '
        Me.cbMPEGEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMPEGEncoder.FormattingEnabled = true
        Me.cbMPEGEncoder.Location = New System.Drawing.Point(19, 32)
        Me.cbMPEGEncoder.Name = "cbMPEGEncoder"
        Me.cbMPEGEncoder.Size = New System.Drawing.Size(216, 21)
        Me.cbMPEGEncoder.TabIndex = 1
        '
        'label21
        '
        Me.label21.AutoSize = true
        Me.label21.Location = New System.Drawing.Point(16, 16)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(81, 13)
        Me.label21.TabIndex = 0
        Me.label21.Text = "MPEG Encoder"
        '
        'tabPage33
        '
        Me.tabPage33.Controls.Add(Me.btMPEGAudDecSettings)
        Me.tabPage33.Controls.Add(Me.cbMPEGAudioDecoder)
        Me.tabPage33.Controls.Add(Me.label121)
        Me.tabPage33.Controls.Add(Me.btMPEGVidDecSetting)
        Me.tabPage33.Controls.Add(Me.cbMPEGVideoDecoder)
        Me.tabPage33.Controls.Add(Me.label120)
        Me.tabPage33.Location = New System.Drawing.Point(4, 22)
        Me.tabPage33.Name = "tabPage33"
        Me.tabPage33.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage33.Size = New System.Drawing.Size(431, 208)
        Me.tabPage33.TabIndex = 4
        Me.tabPage33.Text = "MPEG Decoding"
        Me.tabPage33.UseVisualStyleBackColor = true
        '
        'btMPEGAudDecSettings
        '
        Me.btMPEGAudDecSettings.Location = New System.Drawing.Point(294, 84)
        Me.btMPEGAudDecSettings.Name = "btMPEGAudDecSettings"
        Me.btMPEGAudDecSettings.Size = New System.Drawing.Size(75, 23)
        Me.btMPEGAudDecSettings.TabIndex = 5
        Me.btMPEGAudDecSettings.Text = "Settings"
        Me.btMPEGAudDecSettings.UseVisualStyleBackColor = true
        '
        'cbMPEGAudioDecoder
        '
        Me.cbMPEGAudioDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMPEGAudioDecoder.FormattingEnabled = true
        Me.cbMPEGAudioDecoder.Location = New System.Drawing.Point(26, 86)
        Me.cbMPEGAudioDecoder.Name = "cbMPEGAudioDecoder"
        Me.cbMPEGAudioDecoder.Size = New System.Drawing.Size(262, 21)
        Me.cbMPEGAudioDecoder.TabIndex = 4
        '
        'label121
        '
        Me.label121.AutoSize = true
        Me.label121.Location = New System.Drawing.Point(23, 70)
        Me.label121.Name = "label121"
        Me.label121.Size = New System.Drawing.Size(78, 13)
        Me.label121.TabIndex = 3
        Me.label121.Text = "Audio Decoder"
        '
        'btMPEGVidDecSetting
        '
        Me.btMPEGVidDecSetting.Location = New System.Drawing.Point(294, 39)
        Me.btMPEGVidDecSetting.Name = "btMPEGVidDecSetting"
        Me.btMPEGVidDecSetting.Size = New System.Drawing.Size(75, 23)
        Me.btMPEGVidDecSetting.TabIndex = 2
        Me.btMPEGVidDecSetting.Text = "Settings"
        Me.btMPEGVidDecSetting.UseVisualStyleBackColor = true
        '
        'cbMPEGVideoDecoder
        '
        Me.cbMPEGVideoDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMPEGVideoDecoder.FormattingEnabled = true
        Me.cbMPEGVideoDecoder.Location = New System.Drawing.Point(26, 41)
        Me.cbMPEGVideoDecoder.Name = "cbMPEGVideoDecoder"
        Me.cbMPEGVideoDecoder.Size = New System.Drawing.Size(262, 21)
        Me.cbMPEGVideoDecoder.TabIndex = 1
        '
        'label120
        '
        Me.label120.AutoSize = true
        Me.label120.Location = New System.Drawing.Point(23, 25)
        Me.label120.Name = "label120"
        Me.label120.Size = New System.Drawing.Size(78, 13)
        Me.label120.TabIndex = 0
        Me.label120.Text = "Video Decoder"
        '
        'tabPage11
        '
        Me.tabPage11.Controls.Add(Me.groupBox21)
        Me.tabPage11.Controls.Add(Me.groupBox2)
        Me.tabPage11.Location = New System.Drawing.Point(4, 22)
        Me.tabPage11.Name = "tabPage11"
        Me.tabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage11.Size = New System.Drawing.Size(448, 246)
        Me.tabPage11.TabIndex = 3
        Me.tabPage11.Text = "DV"
        Me.tabPage11.UseVisualStyleBackColor = true
        '
        'groupBox21
        '
        Me.groupBox21.Controls.Add(Me.rbDVResDC)
        Me.groupBox21.Controls.Add(Me.rbDVResQuarter)
        Me.groupBox21.Controls.Add(Me.rbDVResHalf)
        Me.groupBox21.Controls.Add(Me.rbDVResFull)
        Me.groupBox21.Location = New System.Drawing.Point(19, 140)
        Me.groupBox21.Name = "groupBox21"
        Me.groupBox21.Size = New System.Drawing.Size(361, 45)
        Me.groupBox21.TabIndex = 1
        Me.groupBox21.TabStop = false
        Me.groupBox21.Text = "Resolution"
        '
        'rbDVResDC
        '
        Me.rbDVResDC.AutoSize = true
        Me.rbDVResDC.Location = New System.Drawing.Point(279, 19)
        Me.rbDVResDC.Name = "rbDVResDC"
        Me.rbDVResDC.Size = New System.Drawing.Size(40, 17)
        Me.rbDVResDC.TabIndex = 3
        Me.rbDVResDC.Text = "DC"
        Me.rbDVResDC.UseVisualStyleBackColor = true
        '
        'rbDVResQuarter
        '
        Me.rbDVResQuarter.AutoSize = true
        Me.rbDVResQuarter.Location = New System.Drawing.Point(183, 19)
        Me.rbDVResQuarter.Name = "rbDVResQuarter"
        Me.rbDVResQuarter.Size = New System.Drawing.Size(60, 17)
        Me.rbDVResQuarter.TabIndex = 2
        Me.rbDVResQuarter.Text = "Quarter"
        Me.rbDVResQuarter.UseVisualStyleBackColor = true
        '
        'rbDVResHalf
        '
        Me.rbDVResHalf.AutoSize = true
        Me.rbDVResHalf.Location = New System.Drawing.Point(104, 19)
        Me.rbDVResHalf.Name = "rbDVResHalf"
        Me.rbDVResHalf.Size = New System.Drawing.Size(44, 17)
        Me.rbDVResHalf.TabIndex = 1
        Me.rbDVResHalf.Text = "Half"
        Me.rbDVResHalf.UseVisualStyleBackColor = true
        '
        'rbDVResFull
        '
        Me.rbDVResFull.AutoSize = true
        Me.rbDVResFull.Checked = true
        Me.rbDVResFull.Location = New System.Drawing.Point(22, 19)
        Me.rbDVResFull.Name = "rbDVResFull"
        Me.rbDVResFull.Size = New System.Drawing.Size(41, 17)
        Me.rbDVResFull.TabIndex = 0
        Me.rbDVResFull.TabStop = true
        Me.rbDVResFull.Text = "Full"
        Me.rbDVResFull.UseVisualStyleBackColor = true
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btDVStepFWD)
        Me.groupBox2.Controls.Add(Me.btDVStepRev)
        Me.groupBox2.Controls.Add(Me.btDVFF)
        Me.groupBox2.Controls.Add(Me.btDVStop)
        Me.groupBox2.Controls.Add(Me.btDVPause)
        Me.groupBox2.Controls.Add(Me.btDVPlay)
        Me.groupBox2.Controls.Add(Me.btDVRewind)
        Me.groupBox2.Location = New System.Drawing.Point(19, 24)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(361, 100)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = false
        Me.groupBox2.Text = "Controls"
        '
        'btDVStepFWD
        '
        Me.btDVStepFWD.Location = New System.Drawing.Point(251, 58)
        Me.btDVStepFWD.Name = "btDVStepFWD"
        Me.btDVStepFWD.Size = New System.Drawing.Size(68, 23)
        Me.btDVStepFWD.TabIndex = 6
        Me.btDVStepFWD.Text = "Step FWD"
        Me.btDVStepFWD.UseVisualStyleBackColor = true
        '
        'btDVStepRev
        '
        Me.btDVStepRev.Location = New System.Drawing.Point(52, 58)
        Me.btDVStepRev.Name = "btDVStepRev"
        Me.btDVStepRev.Size = New System.Drawing.Size(68, 23)
        Me.btDVStepRev.TabIndex = 5
        Me.btDVStepRev.Text = "Step REV"
        Me.btDVStepRev.UseVisualStyleBackColor = true
        '
        'btDVFF
        '
        Me.btDVFF.Location = New System.Drawing.Point(286, 23)
        Me.btDVFF.Name = "btDVFF"
        Me.btDVFF.Size = New System.Drawing.Size(60, 23)
        Me.btDVFF.TabIndex = 4
        Me.btDVFF.Text = "F.F."
        Me.btDVFF.UseVisualStyleBackColor = true
        '
        'btDVStop
        '
        Me.btDVStop.Location = New System.Drawing.Point(220, 23)
        Me.btDVStop.Name = "btDVStop"
        Me.btDVStop.Size = New System.Drawing.Size(60, 23)
        Me.btDVStop.TabIndex = 3
        Me.btDVStop.Text = "Stop"
        Me.btDVStop.UseVisualStyleBackColor = true
        '
        'btDVPause
        '
        Me.btDVPause.Location = New System.Drawing.Point(154, 23)
        Me.btDVPause.Name = "btDVPause"
        Me.btDVPause.Size = New System.Drawing.Size(60, 23)
        Me.btDVPause.TabIndex = 2
        Me.btDVPause.Text = "Pause"
        Me.btDVPause.UseVisualStyleBackColor = true
        '
        'btDVPlay
        '
        Me.btDVPlay.Location = New System.Drawing.Point(88, 23)
        Me.btDVPlay.Name = "btDVPlay"
        Me.btDVPlay.Size = New System.Drawing.Size(60, 23)
        Me.btDVPlay.TabIndex = 1
        Me.btDVPlay.Text = "Play"
        Me.btDVPlay.UseVisualStyleBackColor = true
        '
        'btDVRewind
        '
        Me.btDVRewind.Location = New System.Drawing.Point(22, 23)
        Me.btDVRewind.Name = "btDVRewind"
        Me.btDVRewind.Size = New System.Drawing.Size(60, 23)
        Me.btDVRewind.TabIndex = 0
        Me.btDVRewind.Text = "Rewind"
        Me.btDVRewind.UseVisualStyleBackColor = true
        '
        'tabPage57
        '
        Me.tabPage57.Controls.Add(Me.lbAdjSaturationCurrent)
        Me.tabPage57.Controls.Add(Me.lbAdjSaturationMax)
        Me.tabPage57.Controls.Add(Me.cbAdjSaturationAuto)
        Me.tabPage57.Controls.Add(Me.lbAdjSaturationMin)
        Me.tabPage57.Controls.Add(Me.tbAdjSaturation)
        Me.tabPage57.Controls.Add(Me.label45)
        Me.tabPage57.Controls.Add(Me.lbAdjHueCurrent)
        Me.tabPage57.Controls.Add(Me.lbAdjHueMax)
        Me.tabPage57.Controls.Add(Me.cbAdjHueAuto)
        Me.tabPage57.Controls.Add(Me.lbAdjHueMin)
        Me.tabPage57.Controls.Add(Me.tbAdjHue)
        Me.tabPage57.Controls.Add(Me.label41)
        Me.tabPage57.Controls.Add(Me.lbAdjContrastCurrent)
        Me.tabPage57.Controls.Add(Me.lbAdjContrastMax)
        Me.tabPage57.Controls.Add(Me.cbAdjContrastAuto)
        Me.tabPage57.Controls.Add(Me.lbAdjContrastMin)
        Me.tabPage57.Controls.Add(Me.tbAdjContrast)
        Me.tabPage57.Controls.Add(Me.label23)
        Me.tabPage57.Controls.Add(Me.lbAdjBrightnessCurrent)
        Me.tabPage57.Controls.Add(Me.lbAdjBrightnessMax)
        Me.tabPage57.Controls.Add(Me.cbAdjBrightnessAuto)
        Me.tabPage57.Controls.Add(Me.lbAdjBrightnessMin)
        Me.tabPage57.Controls.Add(Me.tbAdjBrightness)
        Me.tabPage57.Controls.Add(Me.label17)
        Me.tabPage57.Location = New System.Drawing.Point(4, 22)
        Me.tabPage57.Name = "tabPage57"
        Me.tabPage57.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage57.Size = New System.Drawing.Size(448, 246)
        Me.tabPage57.TabIndex = 8
        Me.tabPage57.Text = "Video adjustments"
        Me.tabPage57.UseVisualStyleBackColor = true
        '
        'lbAdjSaturationCurrent
        '
        Me.lbAdjSaturationCurrent.AutoSize = true
        Me.lbAdjSaturationCurrent.Location = New System.Drawing.Point(341, 125)
        Me.lbAdjSaturationCurrent.Name = "lbAdjSaturationCurrent"
        Me.lbAdjSaturationCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbAdjSaturationCurrent.TabIndex = 36
        Me.lbAdjSaturationCurrent.Text = "Current = 40"
        '
        'lbAdjSaturationMax
        '
        Me.lbAdjSaturationMax.AutoSize = true
        Me.lbAdjSaturationMax.Location = New System.Drawing.Point(278, 128)
        Me.lbAdjSaturationMax.Name = "lbAdjSaturationMax"
        Me.lbAdjSaturationMax.Size = New System.Drawing.Size(57, 13)
        Me.lbAdjSaturationMax.TabIndex = 35
        Me.lbAdjSaturationMax.Text = "Max = 100"
        '
        'cbAdjSaturationAuto
        '
        Me.cbAdjSaturationAuto.AutoSize = true
        Me.cbAdjSaturationAuto.Location = New System.Drawing.Point(367, 79)
        Me.cbAdjSaturationAuto.Name = "cbAdjSaturationAuto"
        Me.cbAdjSaturationAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbAdjSaturationAuto.TabIndex = 34
        Me.cbAdjSaturationAuto.Text = "Auto"
        Me.cbAdjSaturationAuto.UseVisualStyleBackColor = true
        '
        'lbAdjSaturationMin
        '
        Me.lbAdjSaturationMin.AutoSize = true
        Me.lbAdjSaturationMin.Location = New System.Drawing.Point(230, 125)
        Me.lbAdjSaturationMin.Name = "lbAdjSaturationMin"
        Me.lbAdjSaturationMin.Size = New System.Drawing.Size(42, 13)
        Me.lbAdjSaturationMin.TabIndex = 33
        Me.lbAdjSaturationMin.Text = "Min = 1"
        '
        'tbAdjSaturation
        '
        Me.tbAdjSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbAdjSaturation.Location = New System.Drawing.Point(224, 96)
        Me.tbAdjSaturation.Maximum = 100
        Me.tbAdjSaturation.Name = "tbAdjSaturation"
        Me.tbAdjSaturation.Size = New System.Drawing.Size(191, 45)
        Me.tbAdjSaturation.TabIndex = 32
        Me.tbAdjSaturation.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAdjSaturation.Value = 50
        '
        'label45
        '
        Me.label45.AutoSize = true
        Me.label45.Location = New System.Drawing.Point(221, 80)
        Me.label45.Name = "label45"
        Me.label45.Size = New System.Drawing.Size(55, 13)
        Me.label45.TabIndex = 31
        Me.label45.Text = "Saturation"
        '
        'lbAdjHueCurrent
        '
        Me.lbAdjHueCurrent.AutoSize = true
        Me.lbAdjHueCurrent.Location = New System.Drawing.Point(341, 57)
        Me.lbAdjHueCurrent.Name = "lbAdjHueCurrent"
        Me.lbAdjHueCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbAdjHueCurrent.TabIndex = 30
        Me.lbAdjHueCurrent.Text = "Current = 40"
        '
        'lbAdjHueMax
        '
        Me.lbAdjHueMax.AutoSize = true
        Me.lbAdjHueMax.Location = New System.Drawing.Point(278, 57)
        Me.lbAdjHueMax.Name = "lbAdjHueMax"
        Me.lbAdjHueMax.Size = New System.Drawing.Size(57, 13)
        Me.lbAdjHueMax.TabIndex = 29
        Me.lbAdjHueMax.Text = "Max = 100"
        '
        'cbAdjHueAuto
        '
        Me.cbAdjHueAuto.AutoSize = true
        Me.cbAdjHueAuto.Location = New System.Drawing.Point(367, 11)
        Me.cbAdjHueAuto.Name = "cbAdjHueAuto"
        Me.cbAdjHueAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbAdjHueAuto.TabIndex = 28
        Me.cbAdjHueAuto.Text = "Auto"
        Me.cbAdjHueAuto.UseVisualStyleBackColor = true
        '
        'lbAdjHueMin
        '
        Me.lbAdjHueMin.AutoSize = true
        Me.lbAdjHueMin.Location = New System.Drawing.Point(230, 57)
        Me.lbAdjHueMin.Name = "lbAdjHueMin"
        Me.lbAdjHueMin.Size = New System.Drawing.Size(42, 13)
        Me.lbAdjHueMin.TabIndex = 27
        Me.lbAdjHueMin.Text = "Min = 1"
        '
        'tbAdjHue
        '
        Me.tbAdjHue.BackColor = System.Drawing.SystemColors.Window
        Me.tbAdjHue.Location = New System.Drawing.Point(224, 28)
        Me.tbAdjHue.Maximum = 100
        Me.tbAdjHue.Name = "tbAdjHue"
        Me.tbAdjHue.Size = New System.Drawing.Size(191, 45)
        Me.tbAdjHue.TabIndex = 26
        Me.tbAdjHue.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAdjHue.Value = 50
        '
        'label41
        '
        Me.label41.AutoSize = true
        Me.label41.Location = New System.Drawing.Point(221, 12)
        Me.label41.Name = "label41"
        Me.label41.Size = New System.Drawing.Size(27, 13)
        Me.label41.TabIndex = 25
        Me.label41.Text = "Hue"
        '
        'lbAdjContrastCurrent
        '
        Me.lbAdjContrastCurrent.AutoSize = true
        Me.lbAdjContrastCurrent.Location = New System.Drawing.Point(132, 125)
        Me.lbAdjContrastCurrent.Name = "lbAdjContrastCurrent"
        Me.lbAdjContrastCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbAdjContrastCurrent.TabIndex = 24
        Me.lbAdjContrastCurrent.Text = "Current = 40"
        '
        'lbAdjContrastMax
        '
        Me.lbAdjContrastMax.AutoSize = true
        Me.lbAdjContrastMax.Location = New System.Drawing.Point(69, 125)
        Me.lbAdjContrastMax.Name = "lbAdjContrastMax"
        Me.lbAdjContrastMax.Size = New System.Drawing.Size(57, 13)
        Me.lbAdjContrastMax.TabIndex = 23
        Me.lbAdjContrastMax.Text = "Max = 100"
        '
        'cbAdjContrastAuto
        '
        Me.cbAdjContrastAuto.AutoSize = true
        Me.cbAdjContrastAuto.Location = New System.Drawing.Point(158, 79)
        Me.cbAdjContrastAuto.Name = "cbAdjContrastAuto"
        Me.cbAdjContrastAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbAdjContrastAuto.TabIndex = 22
        Me.cbAdjContrastAuto.Text = "Auto"
        Me.cbAdjContrastAuto.UseVisualStyleBackColor = true
        '
        'lbAdjContrastMin
        '
        Me.lbAdjContrastMin.AutoSize = true
        Me.lbAdjContrastMin.Location = New System.Drawing.Point(21, 125)
        Me.lbAdjContrastMin.Name = "lbAdjContrastMin"
        Me.lbAdjContrastMin.Size = New System.Drawing.Size(42, 13)
        Me.lbAdjContrastMin.TabIndex = 21
        Me.lbAdjContrastMin.Text = "Min = 1"
        '
        'tbAdjContrast
        '
        Me.tbAdjContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbAdjContrast.Location = New System.Drawing.Point(15, 96)
        Me.tbAdjContrast.Maximum = 100
        Me.tbAdjContrast.Name = "tbAdjContrast"
        Me.tbAdjContrast.Size = New System.Drawing.Size(191, 45)
        Me.tbAdjContrast.TabIndex = 20
        Me.tbAdjContrast.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAdjContrast.Value = 50
        '
        'label23
        '
        Me.label23.AutoSize = true
        Me.label23.Location = New System.Drawing.Point(12, 80)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(46, 13)
        Me.label23.TabIndex = 19
        Me.label23.Text = "Contrast"
        '
        'lbAdjBrightnessCurrent
        '
        Me.lbAdjBrightnessCurrent.AutoSize = true
        Me.lbAdjBrightnessCurrent.Location = New System.Drawing.Point(132, 57)
        Me.lbAdjBrightnessCurrent.Name = "lbAdjBrightnessCurrent"
        Me.lbAdjBrightnessCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbAdjBrightnessCurrent.TabIndex = 18
        Me.lbAdjBrightnessCurrent.Text = "Current = 40"
        '
        'lbAdjBrightnessMax
        '
        Me.lbAdjBrightnessMax.AutoSize = true
        Me.lbAdjBrightnessMax.Location = New System.Drawing.Point(69, 57)
        Me.lbAdjBrightnessMax.Name = "lbAdjBrightnessMax"
        Me.lbAdjBrightnessMax.Size = New System.Drawing.Size(57, 13)
        Me.lbAdjBrightnessMax.TabIndex = 17
        Me.lbAdjBrightnessMax.Text = "Max = 100"
        '
        'cbAdjBrightnessAuto
        '
        Me.cbAdjBrightnessAuto.AutoSize = true
        Me.cbAdjBrightnessAuto.Location = New System.Drawing.Point(158, 11)
        Me.cbAdjBrightnessAuto.Name = "cbAdjBrightnessAuto"
        Me.cbAdjBrightnessAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbAdjBrightnessAuto.TabIndex = 16
        Me.cbAdjBrightnessAuto.Text = "Auto"
        Me.cbAdjBrightnessAuto.UseVisualStyleBackColor = true
        '
        'lbAdjBrightnessMin
        '
        Me.lbAdjBrightnessMin.AutoSize = true
        Me.lbAdjBrightnessMin.Location = New System.Drawing.Point(21, 57)
        Me.lbAdjBrightnessMin.Name = "lbAdjBrightnessMin"
        Me.lbAdjBrightnessMin.Size = New System.Drawing.Size(42, 13)
        Me.lbAdjBrightnessMin.TabIndex = 15
        Me.lbAdjBrightnessMin.Text = "Min = 1"
        '
        'tbAdjBrightness
        '
        Me.tbAdjBrightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbAdjBrightness.Location = New System.Drawing.Point(15, 28)
        Me.tbAdjBrightness.Maximum = 100
        Me.tbAdjBrightness.Name = "tbAdjBrightness"
        Me.tbAdjBrightness.Size = New System.Drawing.Size(191, 45)
        Me.tbAdjBrightness.TabIndex = 14
        Me.tbAdjBrightness.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAdjBrightness.Value = 50
        '
        'label17
        '
        Me.label17.AutoSize = true
        Me.label17.Location = New System.Drawing.Point(12, 12)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(56, 13)
        Me.label17.TabIndex = 13
        Me.label17.Text = "Brightness"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.label1)
        Me.TabPage3.Controls.Add(Me.btCCFocusApply)
        Me.TabPage3.Controls.Add(Me.btCCZoomApply)
        Me.TabPage3.Controls.Add(Me.cbCCFocusRelative)
        Me.TabPage3.Controls.Add(Me.cbCCFocusManual)
        Me.TabPage3.Controls.Add(Me.cbCCFocusAuto)
        Me.TabPage3.Controls.Add(Me.lbCCFocusCurrent)
        Me.TabPage3.Controls.Add(Me.lbCCFocusMax)
        Me.TabPage3.Controls.Add(Me.lbCCFocusMin)
        Me.TabPage3.Controls.Add(Me.tbCCFocus)
        Me.TabPage3.Controls.Add(Me.label4)
        Me.TabPage3.Controls.Add(Me.cbCCZoomRelative)
        Me.TabPage3.Controls.Add(Me.cbCCZoomManual)
        Me.TabPage3.Controls.Add(Me.cbCCZoomAuto)
        Me.TabPage3.Controls.Add(Me.lbCCZoomCurrent)
        Me.TabPage3.Controls.Add(Me.lbCCZoomMax)
        Me.TabPage3.Controls.Add(Me.lbCCZoomMin)
        Me.TabPage3.Controls.Add(Me.tbCCZoom)
        Me.TabPage3.Controls.Add(Me.label20)
        Me.TabPage3.Controls.Add(Me.btCCTiltApply)
        Me.TabPage3.Controls.Add(Me.btCCPanApply)
        Me.TabPage3.Controls.Add(Me.cbCCTiltRelative)
        Me.TabPage3.Controls.Add(Me.cbCCTiltManual)
        Me.TabPage3.Controls.Add(Me.cbCCTiltAuto)
        Me.TabPage3.Controls.Add(Me.lbCCTiltCurrent)
        Me.TabPage3.Controls.Add(Me.lbCCTiltMax)
        Me.TabPage3.Controls.Add(Me.lbCCTiltMin)
        Me.TabPage3.Controls.Add(Me.tbCCTilt)
        Me.TabPage3.Controls.Add(Me.label97)
        Me.TabPage3.Controls.Add(Me.cbCCPanRelative)
        Me.TabPage3.Controls.Add(Me.cbCCPanManual)
        Me.TabPage3.Controls.Add(Me.cbCCPanAuto)
        Me.TabPage3.Controls.Add(Me.btCCReadValues)
        Me.TabPage3.Controls.Add(Me.lbCCPanCurrent)
        Me.TabPage3.Controls.Add(Me.lbCCPanMax)
        Me.TabPage3.Controls.Add(Me.lbCCPanMin)
        Me.TabPage3.Controls.Add(Me.tbCCPan)
        Me.TabPage3.Controls.Add(Me.label96)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(448, 246)
        Me.TabPage3.TabIndex = 9
        Me.TabPage3.Text = "Camera control"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(11, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(208, 13)
        Me.label1.TabIndex = 96
        Me.label1.Text = "Many other parameters available using API"
        '
        'btCCFocusApply
        '
        Me.btCCFocusApply.Location = New System.Drawing.Point(235, 219)
        Me.btCCFocusApply.Name = "btCCFocusApply"
        Me.btCCFocusApply.Size = New System.Drawing.Size(75, 23)
        Me.btCCFocusApply.TabIndex = 95
        Me.btCCFocusApply.Text = "Apply"
        Me.btCCFocusApply.UseVisualStyleBackColor = true
        '
        'btCCZoomApply
        '
        Me.btCCZoomApply.Location = New System.Drawing.Point(23, 219)
        Me.btCCZoomApply.Name = "btCCZoomApply"
        Me.btCCZoomApply.Size = New System.Drawing.Size(75, 23)
        Me.btCCZoomApply.TabIndex = 94
        Me.btCCZoomApply.Text = "Apply"
        Me.btCCZoomApply.UseVisualStyleBackColor = true
        '
        'cbCCFocusRelative
        '
        Me.cbCCFocusRelative.AutoSize = true
        Me.cbCCFocusRelative.Location = New System.Drawing.Point(346, 196)
        Me.cbCCFocusRelative.Name = "cbCCFocusRelative"
        Me.cbCCFocusRelative.Size = New System.Drawing.Size(65, 17)
        Me.cbCCFocusRelative.TabIndex = 93
        Me.cbCCFocusRelative.Text = "Relative"
        Me.cbCCFocusRelative.UseVisualStyleBackColor = true
        '
        'cbCCFocusManual
        '
        Me.cbCCFocusManual.AutoSize = true
        Me.cbCCFocusManual.Location = New System.Drawing.Point(283, 196)
        Me.cbCCFocusManual.Name = "cbCCFocusManual"
        Me.cbCCFocusManual.Size = New System.Drawing.Size(61, 17)
        Me.cbCCFocusManual.TabIndex = 92
        Me.cbCCFocusManual.Text = "Manual"
        Me.cbCCFocusManual.UseVisualStyleBackColor = true
        '
        'cbCCFocusAuto
        '
        Me.cbCCFocusAuto.AutoSize = true
        Me.cbCCFocusAuto.Location = New System.Drawing.Point(235, 196)
        Me.cbCCFocusAuto.Name = "cbCCFocusAuto"
        Me.cbCCFocusAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbCCFocusAuto.TabIndex = 91
        Me.cbCCFocusAuto.Text = "Auto"
        Me.cbCCFocusAuto.UseVisualStyleBackColor = true
        '
        'lbCCFocusCurrent
        '
        Me.lbCCFocusCurrent.AutoSize = true
        Me.lbCCFocusCurrent.Location = New System.Drawing.Point(343, 172)
        Me.lbCCFocusCurrent.Name = "lbCCFocusCurrent"
        Me.lbCCFocusCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbCCFocusCurrent.TabIndex = 90
        Me.lbCCFocusCurrent.Text = "Current = 40"
        '
        'lbCCFocusMax
        '
        Me.lbCCFocusMax.AutoSize = true
        Me.lbCCFocusMax.Location = New System.Drawing.Point(280, 172)
        Me.lbCCFocusMax.Name = "lbCCFocusMax"
        Me.lbCCFocusMax.Size = New System.Drawing.Size(57, 13)
        Me.lbCCFocusMax.TabIndex = 89
        Me.lbCCFocusMax.Text = "Max = 100"
        '
        'lbCCFocusMin
        '
        Me.lbCCFocusMin.AutoSize = true
        Me.lbCCFocusMin.Location = New System.Drawing.Point(232, 172)
        Me.lbCCFocusMin.Name = "lbCCFocusMin"
        Me.lbCCFocusMin.Size = New System.Drawing.Size(42, 13)
        Me.lbCCFocusMin.TabIndex = 88
        Me.lbCCFocusMin.Text = "Min = 1"
        '
        'tbCCFocus
        '
        Me.tbCCFocus.BackColor = System.Drawing.SystemColors.Window
        Me.tbCCFocus.Location = New System.Drawing.Point(258, 145)
        Me.tbCCFocus.Maximum = 100
        Me.tbCCFocus.Name = "tbCCFocus"
        Me.tbCCFocus.Size = New System.Drawing.Size(159, 45)
        Me.tbCCFocus.TabIndex = 87
        Me.tbCCFocus.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbCCFocus.Value = 50
        '
        'label4
        '
        Me.label4.AutoSize = true
        Me.label4.Location = New System.Drawing.Point(223, 149)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(36, 13)
        Me.label4.TabIndex = 86
        Me.label4.Text = "Focus"
        '
        'cbCCZoomRelative
        '
        Me.cbCCZoomRelative.AutoSize = true
        Me.cbCCZoomRelative.Location = New System.Drawing.Point(134, 196)
        Me.cbCCZoomRelative.Name = "cbCCZoomRelative"
        Me.cbCCZoomRelative.Size = New System.Drawing.Size(65, 17)
        Me.cbCCZoomRelative.TabIndex = 85
        Me.cbCCZoomRelative.Text = "Relative"
        Me.cbCCZoomRelative.UseVisualStyleBackColor = true
        '
        'cbCCZoomManual
        '
        Me.cbCCZoomManual.AutoSize = true
        Me.cbCCZoomManual.Location = New System.Drawing.Point(71, 196)
        Me.cbCCZoomManual.Name = "cbCCZoomManual"
        Me.cbCCZoomManual.Size = New System.Drawing.Size(61, 17)
        Me.cbCCZoomManual.TabIndex = 84
        Me.cbCCZoomManual.Text = "Manual"
        Me.cbCCZoomManual.UseVisualStyleBackColor = true
        '
        'cbCCZoomAuto
        '
        Me.cbCCZoomAuto.AutoSize = true
        Me.cbCCZoomAuto.Location = New System.Drawing.Point(23, 196)
        Me.cbCCZoomAuto.Name = "cbCCZoomAuto"
        Me.cbCCZoomAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbCCZoomAuto.TabIndex = 83
        Me.cbCCZoomAuto.Text = "Auto"
        Me.cbCCZoomAuto.UseVisualStyleBackColor = true
        '
        'lbCCZoomCurrent
        '
        Me.lbCCZoomCurrent.AutoSize = true
        Me.lbCCZoomCurrent.Location = New System.Drawing.Point(131, 172)
        Me.lbCCZoomCurrent.Name = "lbCCZoomCurrent"
        Me.lbCCZoomCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbCCZoomCurrent.TabIndex = 82
        Me.lbCCZoomCurrent.Text = "Current = 40"
        '
        'lbCCZoomMax
        '
        Me.lbCCZoomMax.AutoSize = true
        Me.lbCCZoomMax.Location = New System.Drawing.Point(68, 172)
        Me.lbCCZoomMax.Name = "lbCCZoomMax"
        Me.lbCCZoomMax.Size = New System.Drawing.Size(57, 13)
        Me.lbCCZoomMax.TabIndex = 81
        Me.lbCCZoomMax.Text = "Max = 100"
        '
        'lbCCZoomMin
        '
        Me.lbCCZoomMin.AutoSize = true
        Me.lbCCZoomMin.Location = New System.Drawing.Point(20, 172)
        Me.lbCCZoomMin.Name = "lbCCZoomMin"
        Me.lbCCZoomMin.Size = New System.Drawing.Size(42, 13)
        Me.lbCCZoomMin.TabIndex = 80
        Me.lbCCZoomMin.Text = "Min = 1"
        '
        'tbCCZoom
        '
        Me.tbCCZoom.BackColor = System.Drawing.SystemColors.Window
        Me.tbCCZoom.Location = New System.Drawing.Point(46, 145)
        Me.tbCCZoom.Maximum = 100
        Me.tbCCZoom.Name = "tbCCZoom"
        Me.tbCCZoom.Size = New System.Drawing.Size(159, 45)
        Me.tbCCZoom.TabIndex = 79
        Me.tbCCZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbCCZoom.Value = 50
        '
        'label20
        '
        Me.label20.AutoSize = true
        Me.label20.Location = New System.Drawing.Point(11, 149)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(34, 13)
        Me.label20.TabIndex = 78
        Me.label20.Text = "Zoom"
        '
        'btCCTiltApply
        '
        Me.btCCTiltApply.Location = New System.Drawing.Point(235, 103)
        Me.btCCTiltApply.Name = "btCCTiltApply"
        Me.btCCTiltApply.Size = New System.Drawing.Size(75, 23)
        Me.btCCTiltApply.TabIndex = 77
        Me.btCCTiltApply.Text = "Apply"
        Me.btCCTiltApply.UseVisualStyleBackColor = true
        '
        'btCCPanApply
        '
        Me.btCCPanApply.Location = New System.Drawing.Point(23, 103)
        Me.btCCPanApply.Name = "btCCPanApply"
        Me.btCCPanApply.Size = New System.Drawing.Size(75, 23)
        Me.btCCPanApply.TabIndex = 76
        Me.btCCPanApply.Text = "Apply"
        Me.btCCPanApply.UseVisualStyleBackColor = true
        '
        'cbCCTiltRelative
        '
        Me.cbCCTiltRelative.AutoSize = true
        Me.cbCCTiltRelative.Location = New System.Drawing.Point(346, 80)
        Me.cbCCTiltRelative.Name = "cbCCTiltRelative"
        Me.cbCCTiltRelative.Size = New System.Drawing.Size(65, 17)
        Me.cbCCTiltRelative.TabIndex = 75
        Me.cbCCTiltRelative.Text = "Relative"
        Me.cbCCTiltRelative.UseVisualStyleBackColor = true
        '
        'cbCCTiltManual
        '
        Me.cbCCTiltManual.AutoSize = true
        Me.cbCCTiltManual.Location = New System.Drawing.Point(283, 80)
        Me.cbCCTiltManual.Name = "cbCCTiltManual"
        Me.cbCCTiltManual.Size = New System.Drawing.Size(61, 17)
        Me.cbCCTiltManual.TabIndex = 74
        Me.cbCCTiltManual.Text = "Manual"
        Me.cbCCTiltManual.UseVisualStyleBackColor = true
        '
        'cbCCTiltAuto
        '
        Me.cbCCTiltAuto.AutoSize = true
        Me.cbCCTiltAuto.Location = New System.Drawing.Point(235, 80)
        Me.cbCCTiltAuto.Name = "cbCCTiltAuto"
        Me.cbCCTiltAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbCCTiltAuto.TabIndex = 73
        Me.cbCCTiltAuto.Text = "Auto"
        Me.cbCCTiltAuto.UseVisualStyleBackColor = true
        '
        'lbCCTiltCurrent
        '
        Me.lbCCTiltCurrent.AutoSize = true
        Me.lbCCTiltCurrent.Location = New System.Drawing.Point(343, 56)
        Me.lbCCTiltCurrent.Name = "lbCCTiltCurrent"
        Me.lbCCTiltCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbCCTiltCurrent.TabIndex = 72
        Me.lbCCTiltCurrent.Text = "Current = 40"
        '
        'lbCCTiltMax
        '
        Me.lbCCTiltMax.AutoSize = true
        Me.lbCCTiltMax.Location = New System.Drawing.Point(280, 56)
        Me.lbCCTiltMax.Name = "lbCCTiltMax"
        Me.lbCCTiltMax.Size = New System.Drawing.Size(57, 13)
        Me.lbCCTiltMax.TabIndex = 71
        Me.lbCCTiltMax.Text = "Max = 100"
        '
        'lbCCTiltMin
        '
        Me.lbCCTiltMin.AutoSize = true
        Me.lbCCTiltMin.Location = New System.Drawing.Point(232, 56)
        Me.lbCCTiltMin.Name = "lbCCTiltMin"
        Me.lbCCTiltMin.Size = New System.Drawing.Size(42, 13)
        Me.lbCCTiltMin.TabIndex = 70
        Me.lbCCTiltMin.Text = "Min = 1"
        '
        'tbCCTilt
        '
        Me.tbCCTilt.BackColor = System.Drawing.SystemColors.Window
        Me.tbCCTilt.Location = New System.Drawing.Point(254, 29)
        Me.tbCCTilt.Maximum = 100
        Me.tbCCTilt.Name = "tbCCTilt"
        Me.tbCCTilt.Size = New System.Drawing.Size(163, 45)
        Me.tbCCTilt.TabIndex = 69
        Me.tbCCTilt.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbCCTilt.Value = 50
        '
        'label97
        '
        Me.label97.AutoSize = true
        Me.label97.Location = New System.Drawing.Point(223, 32)
        Me.label97.Name = "label97"
        Me.label97.Size = New System.Drawing.Size(21, 13)
        Me.label97.TabIndex = 68
        Me.label97.Text = "Tilt"
        '
        'cbCCPanRelative
        '
        Me.cbCCPanRelative.AutoSize = true
        Me.cbCCPanRelative.Location = New System.Drawing.Point(134, 80)
        Me.cbCCPanRelative.Name = "cbCCPanRelative"
        Me.cbCCPanRelative.Size = New System.Drawing.Size(65, 17)
        Me.cbCCPanRelative.TabIndex = 67
        Me.cbCCPanRelative.Text = "Relative"
        Me.cbCCPanRelative.UseVisualStyleBackColor = true
        '
        'cbCCPanManual
        '
        Me.cbCCPanManual.AutoSize = true
        Me.cbCCPanManual.Location = New System.Drawing.Point(71, 80)
        Me.cbCCPanManual.Name = "cbCCPanManual"
        Me.cbCCPanManual.Size = New System.Drawing.Size(61, 17)
        Me.cbCCPanManual.TabIndex = 66
        Me.cbCCPanManual.Text = "Manual"
        Me.cbCCPanManual.UseVisualStyleBackColor = true
        '
        'cbCCPanAuto
        '
        Me.cbCCPanAuto.AutoSize = true
        Me.cbCCPanAuto.Location = New System.Drawing.Point(23, 80)
        Me.cbCCPanAuto.Name = "cbCCPanAuto"
        Me.cbCCPanAuto.Size = New System.Drawing.Size(48, 17)
        Me.cbCCPanAuto.TabIndex = 65
        Me.cbCCPanAuto.Text = "Auto"
        Me.cbCCPanAuto.UseVisualStyleBackColor = true
        '
        'btCCReadValues
        '
        Me.btCCReadValues.AccessibleDescription = ""
        Me.btCCReadValues.Location = New System.Drawing.Point(346, 5)
        Me.btCCReadValues.Name = "btCCReadValues"
        Me.btCCReadValues.Size = New System.Drawing.Size(91, 23)
        Me.btCCReadValues.TabIndex = 64
        Me.btCCReadValues.Text = "Read values"
        Me.btCCReadValues.UseVisualStyleBackColor = true
        '
        'lbCCPanCurrent
        '
        Me.lbCCPanCurrent.AutoSize = true
        Me.lbCCPanCurrent.Location = New System.Drawing.Point(131, 56)
        Me.lbCCPanCurrent.Name = "lbCCPanCurrent"
        Me.lbCCPanCurrent.Size = New System.Drawing.Size(65, 13)
        Me.lbCCPanCurrent.TabIndex = 63
        Me.lbCCPanCurrent.Text = "Current = 40"
        '
        'lbCCPanMax
        '
        Me.lbCCPanMax.AutoSize = true
        Me.lbCCPanMax.Location = New System.Drawing.Point(68, 56)
        Me.lbCCPanMax.Name = "lbCCPanMax"
        Me.lbCCPanMax.Size = New System.Drawing.Size(57, 13)
        Me.lbCCPanMax.TabIndex = 62
        Me.lbCCPanMax.Text = "Max = 100"
        '
        'lbCCPanMin
        '
        Me.lbCCPanMin.AutoSize = true
        Me.lbCCPanMin.Location = New System.Drawing.Point(20, 56)
        Me.lbCCPanMin.Name = "lbCCPanMin"
        Me.lbCCPanMin.Size = New System.Drawing.Size(42, 13)
        Me.lbCCPanMin.TabIndex = 61
        Me.lbCCPanMin.Text = "Min = 1"
        '
        'tbCCPan
        '
        Me.tbCCPan.BackColor = System.Drawing.SystemColors.Window
        Me.tbCCPan.Location = New System.Drawing.Point(46, 29)
        Me.tbCCPan.Maximum = 100
        Me.tbCCPan.Name = "tbCCPan"
        Me.tbCCPan.Size = New System.Drawing.Size(159, 45)
        Me.tbCCPan.TabIndex = 60
        Me.tbCCPan.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbCCPan.Value = 50
        '
        'label96
        '
        Me.label96.AutoSize = true
        Me.label96.Location = New System.Drawing.Point(11, 32)
        Me.label96.Name = "label96"
        Me.label96.Size = New System.Drawing.Size(26, 13)
        Me.label96.TabIndex = 59
        Me.label96.Text = "Pan"
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.tabControl19)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage9.Size = New System.Drawing.Size(459, 285)
        Me.TabPage9.TabIndex = 8
        Me.TabPage9.Text = "Audio input / output"
        Me.TabPage9.UseVisualStyleBackColor = true
        '
        'tabControl19
        '
        Me.tabControl19.Controls.Add(Me.tabPage96)
        Me.tabControl19.Controls.Add(Me.tabPage97)
        Me.tabControl19.Controls.Add(Me.tabPage98)
        Me.tabControl19.Controls.Add(Me.TabPage111)
        Me.tabControl19.Controls.Add(Me.tabPage99)
        Me.tabControl19.Location = New System.Drawing.Point(3, 6)
        Me.tabControl19.Margin = New System.Windows.Forms.Padding(2)
        Me.tabControl19.Name = "tabControl19"
        Me.tabControl19.SelectedIndex = 0
        Me.tabControl19.Size = New System.Drawing.Size(455, 277)
        Me.tabControl19.TabIndex = 1
        '
        'tabPage96
        '
        Me.tabPage96.Controls.Add(Me.cbUseBestAudioInputFormat)
        Me.tabPage96.Controls.Add(Me.cbUseAudioInputFromVideoCaptureDevice)
        Me.tabPage96.Controls.Add(Me.btAudioInputDeviceSettings)
        Me.tabPage96.Controls.Add(Me.cbAudioInputLine)
        Me.tabPage96.Controls.Add(Me.cbAudioInputFormat)
        Me.tabPage96.Controls.Add(Me.cbAudioInputDevice)
        Me.tabPage96.Controls.Add(Me.label14)
        Me.tabPage96.Controls.Add(Me.label12)
        Me.tabPage96.Controls.Add(Me.label10)
        Me.tabPage96.Location = New System.Drawing.Point(4, 22)
        Me.tabPage96.Margin = New System.Windows.Forms.Padding(2)
        Me.tabPage96.Name = "tabPage96"
        Me.tabPage96.Padding = New System.Windows.Forms.Padding(2)
        Me.tabPage96.Size = New System.Drawing.Size(447, 251)
        Me.tabPage96.TabIndex = 0
        Me.tabPage96.Text = "Main audio input"
        Me.tabPage96.UseVisualStyleBackColor = true
        '
        'cbUseBestAudioInputFormat
        '
        Me.cbUseBestAudioInputFormat.AutoSize = true
        Me.cbUseBestAudioInputFormat.Location = New System.Drawing.Point(299, 114)
        Me.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat"
        Me.cbUseBestAudioInputFormat.Size = New System.Drawing.Size(68, 17)
        Me.cbUseBestAudioInputFormat.TabIndex = 93
        Me.cbUseBestAudioInputFormat.Text = "Use best"
        Me.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true
        '
        'cbUseAudioInputFromVideoCaptureDevice
        '
        Me.cbUseAudioInputFromVideoCaptureDevice.AutoSize = true
        Me.cbUseAudioInputFromVideoCaptureDevice.Location = New System.Drawing.Point(246, 15)
        Me.cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice"
        Me.cbUseAudioInputFromVideoCaptureDevice.Size = New System.Drawing.Size(187, 17)
        Me.cbUseAudioInputFromVideoCaptureDevice.TabIndex = 92
        Me.cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source"
        Me.cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true
        '
        'btAudioInputDeviceSettings
        '
        Me.btAudioInputDeviceSettings.Location = New System.Drawing.Point(373, 32)
        Me.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings"
        Me.btAudioInputDeviceSettings.Size = New System.Drawing.Size(54, 23)
        Me.btAudioInputDeviceSettings.TabIndex = 91
        Me.btAudioInputDeviceSettings.Text = "Settings"
        Me.btAudioInputDeviceSettings.UseVisualStyleBackColor = true
        '
        'cbAudioInputLine
        '
        Me.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputLine.FormattingEnabled = true
        Me.cbAudioInputLine.Location = New System.Drawing.Point(21, 81)
        Me.cbAudioInputLine.Name = "cbAudioInputLine"
        Me.cbAudioInputLine.Size = New System.Drawing.Size(346, 21)
        Me.cbAudioInputLine.TabIndex = 88
        '
        'cbAudioInputFormat
        '
        Me.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputFormat.FormattingEnabled = true
        Me.cbAudioInputFormat.Location = New System.Drawing.Point(21, 131)
        Me.cbAudioInputFormat.Name = "cbAudioInputFormat"
        Me.cbAudioInputFormat.Size = New System.Drawing.Size(346, 21)
        Me.cbAudioInputFormat.TabIndex = 87
        '
        'cbAudioInputDevice
        '
        Me.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputDevice.FormattingEnabled = true
        Me.cbAudioInputDevice.Location = New System.Drawing.Point(21, 33)
        Me.cbAudioInputDevice.Name = "cbAudioInputDevice"
        Me.cbAudioInputDevice.Size = New System.Drawing.Size(346, 21)
        Me.cbAudioInputDevice.TabIndex = 86
        '
        'label14
        '
        Me.label14.AutoSize = true
        Me.label14.Location = New System.Drawing.Point(18, 65)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(50, 13)
        Me.label14.TabIndex = 85
        Me.label14.Text = "Input line"
        '
        'label12
        '
        Me.label12.AutoSize = true
        Me.label12.Location = New System.Drawing.Point(18, 15)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(66, 13)
        Me.label12.TabIndex = 84
        Me.label12.Text = "Input device"
        '
        'label10
        '
        Me.label10.AutoSize = true
        Me.label10.Location = New System.Drawing.Point(18, 115)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(63, 13)
        Me.label10.TabIndex = 83
        Me.label10.Text = "Input format"
        '
        'tabPage97
        '
        Me.tabPage97.Controls.Add(Me.label55)
        Me.tabPage97.Controls.Add(Me.tbAudioBalance)
        Me.tabPage97.Controls.Add(Me.label54)
        Me.tabPage97.Controls.Add(Me.tbAudioVolume)
        Me.tabPage97.Controls.Add(Me.cbPlayAudio)
        Me.tabPage97.Controls.Add(Me.cbAudioOutputDevice)
        Me.tabPage97.Controls.Add(Me.label15)
        Me.tabPage97.Location = New System.Drawing.Point(4, 22)
        Me.tabPage97.Margin = New System.Windows.Forms.Padding(2)
        Me.tabPage97.Name = "tabPage97"
        Me.tabPage97.Padding = New System.Windows.Forms.Padding(2)
        Me.tabPage97.Size = New System.Drawing.Size(447, 251)
        Me.tabPage97.TabIndex = 1
        Me.tabPage97.Text = "Audio output"
        Me.tabPage97.UseVisualStyleBackColor = true
        '
        'label55
        '
        Me.label55.AutoSize = true
        Me.label55.Location = New System.Drawing.Point(338, 20)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(46, 13)
        Me.label55.TabIndex = 105
        Me.label55.Text = "Balance"
        '
        'tbAudioBalance
        '
        Me.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioBalance.Location = New System.Drawing.Point(340, 35)
        Me.tbAudioBalance.Maximum = 100
        Me.tbAudioBalance.Minimum = -100
        Me.tbAudioBalance.Name = "tbAudioBalance"
        Me.tbAudioBalance.Size = New System.Drawing.Size(82, 45)
        Me.tbAudioBalance.TabIndex = 104
        Me.tbAudioBalance.TickFrequency = 5
        '
        'label54
        '
        Me.label54.AutoSize = true
        Me.label54.Location = New System.Drawing.Point(230, 20)
        Me.label54.Name = "label54"
        Me.label54.Size = New System.Drawing.Size(42, 13)
        Me.label54.TabIndex = 103
        Me.label54.Text = "Volume"
        '
        'tbAudioVolume
        '
        Me.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioVolume.Location = New System.Drawing.Point(231, 35)
        Me.tbAudioVolume.Maximum = 100
        Me.tbAudioVolume.Name = "tbAudioVolume"
        Me.tbAudioVolume.Size = New System.Drawing.Size(82, 45)
        Me.tbAudioVolume.TabIndex = 102
        Me.tbAudioVolume.TickFrequency = 10
        Me.tbAudioVolume.Value = 80
        '
        'cbPlayAudio
        '
        Me.cbPlayAudio.AutoSize = true
        Me.cbPlayAudio.Checked = true
        Me.cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPlayAudio.Location = New System.Drawing.Point(131, 20)
        Me.cbPlayAudio.Name = "cbPlayAudio"
        Me.cbPlayAudio.Size = New System.Drawing.Size(75, 17)
        Me.cbPlayAudio.TabIndex = 101
        Me.cbPlayAudio.Text = "Play audio"
        Me.cbPlayAudio.UseVisualStyleBackColor = true
        '
        'cbAudioOutputDevice
        '
        Me.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioOutputDevice.FormattingEnabled = true
        Me.cbAudioOutputDevice.Location = New System.Drawing.Point(16, 37)
        Me.cbAudioOutputDevice.Name = "cbAudioOutputDevice"
        Me.cbAudioOutputDevice.Size = New System.Drawing.Size(190, 21)
        Me.cbAudioOutputDevice.TabIndex = 100
        '
        'label15
        '
        Me.label15.AutoSize = true
        Me.label15.Location = New System.Drawing.Point(14, 20)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(74, 13)
        Me.label15.TabIndex = 99
        Me.label15.Text = "Output device"
        '
        'tabPage98
        '
        Me.tabPage98.Controls.Add(Me.peakMeterCtrl1)
        Me.tabPage98.Controls.Add(Me.cbVUMeter)
        Me.tabPage98.Location = New System.Drawing.Point(4, 22)
        Me.tabPage98.Margin = New System.Windows.Forms.Padding(2)
        Me.tabPage98.Name = "tabPage98"
        Me.tabPage98.Padding = New System.Windows.Forms.Padding(2)
        Me.tabPage98.Size = New System.Drawing.Size(447, 251)
        Me.tabPage98.TabIndex = 2
        Me.tabPage98.Text = "VU meter"
        Me.tabPage98.UseVisualStyleBackColor = true
        '
        'peakMeterCtrl1
        '
        Me.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red
        Me.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(150,Byte),Integer), CType(CType(150,Byte),Integer))
        Me.peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow
        Me.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(150,Byte),Integer))
        Me.peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green
        Me.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(CType(CType(150,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(150,Byte),Integer))
        Me.peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb(CType(CType(180,Byte),Integer), CType(CType(180,Byte),Integer), CType(CType(180,Byte),Integer))
        Me.peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro
        Me.peakMeterCtrl1.Location = New System.Drawing.Point(128, 11)
        Me.peakMeterCtrl1.Name = "peakMeterCtrl1"
        Me.peakMeterCtrl1.Size = New System.Drawing.Size(105, 61)
        Me.peakMeterCtrl1.TabIndex = 102
        Me.peakMeterCtrl1.Text = "peakMeterCtrl1"
        '
        'cbVUMeter
        '
        Me.cbVUMeter.AutoSize = true
        Me.cbVUMeter.Location = New System.Drawing.Point(13, 17)
        Me.cbVUMeter.Name = "cbVUMeter"
        Me.cbVUMeter.Size = New System.Drawing.Size(107, 17)
        Me.cbVUMeter.TabIndex = 101
        Me.cbVUMeter.Text = "Enable VU Meter"
        Me.cbVUMeter.UseVisualStyleBackColor = true
        '
        'TabPage111
        '
        Me.TabPage111.Controls.Add(Me.tbVUMeterBoost)
        Me.TabPage111.Controls.Add(Me.label382)
        Me.TabPage111.Controls.Add(Me.label381)
        Me.TabPage111.Controls.Add(Me.tbVUMeterAmplification)
        Me.TabPage111.Controls.Add(Me.cbVUMeterPro)
        Me.TabPage111.Controls.Add(Me.waveformPainter2)
        Me.TabPage111.Controls.Add(Me.waveformPainter1)
        Me.TabPage111.Controls.Add(Me.volumeMeter2)
        Me.TabPage111.Controls.Add(Me.volumeMeter1)
        Me.TabPage111.Location = New System.Drawing.Point(4, 22)
        Me.TabPage111.Name = "TabPage111"
        Me.TabPage111.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage111.Size = New System.Drawing.Size(447, 251)
        Me.TabPage111.TabIndex = 4
        Me.TabPage111.Text = "VU meter Pro"
        Me.TabPage111.UseVisualStyleBackColor = true
        '
        'tbVUMeterBoost
        '
        Me.tbVUMeterBoost.Location = New System.Drawing.Point(171, 188)
        Me.tbVUMeterBoost.Maximum = 30
        Me.tbVUMeterBoost.Name = "tbVUMeterBoost"
        Me.tbVUMeterBoost.Size = New System.Drawing.Size(104, 45)
        Me.tbVUMeterBoost.TabIndex = 124
        Me.tbVUMeterBoost.Value = 10
        '
        'label382
        '
        Me.label382.AutoSize = true
        Me.label382.Location = New System.Drawing.Point(168, 172)
        Me.label382.Name = "label382"
        Me.label382.Size = New System.Drawing.Size(68, 13)
        Me.label382.TabIndex = 123
        Me.label382.Text = "Meters boost"
        '
        'label381
        '
        Me.label381.AutoSize = true
        Me.label381.Location = New System.Drawing.Point(20, 172)
        Me.label381.Name = "label381"
        Me.label381.Size = New System.Drawing.Size(120, 13)
        Me.label381.TabIndex = 119
        Me.label381.Text = "Volume amplification (%)"
        '
        'tbVUMeterAmplification
        '
        Me.tbVUMeterAmplification.Location = New System.Drawing.Point(23, 188)
        Me.tbVUMeterAmplification.Maximum = 100
        Me.tbVUMeterAmplification.Name = "tbVUMeterAmplification"
        Me.tbVUMeterAmplification.Size = New System.Drawing.Size(105, 45)
        Me.tbVUMeterAmplification.TabIndex = 118
        Me.tbVUMeterAmplification.Value = 100
        '
        'cbVUMeterPro
        '
        Me.cbVUMeterPro.AutoSize = true
        Me.cbVUMeterPro.Location = New System.Drawing.Point(13, 17)
        Me.cbVUMeterPro.Name = "cbVUMeterPro"
        Me.cbVUMeterPro.Size = New System.Drawing.Size(125, 17)
        Me.cbVUMeterPro.TabIndex = 117
        Me.cbVUMeterPro.Text = "Enable VU meter Pro"
        Me.cbVUMeterPro.UseVisualStyleBackColor = true
        '
        'waveformPainter2
        '
        Me.waveformPainter2.Boost = 1!
        Me.waveformPainter2.Location = New System.Drawing.Point(101, 106)
        Me.waveformPainter2.Name = "waveformPainter2"
        Me.waveformPainter2.Size = New System.Drawing.Size(270, 60)
        Me.waveformPainter2.TabIndex = 122
        Me.waveformPainter2.Text = "waveformPainter2"
        '
        'waveformPainter1
        '
        Me.waveformPainter1.Boost = 1!
        Me.waveformPainter1.Location = New System.Drawing.Point(101, 40)
        Me.waveformPainter1.Name = "waveformPainter1"
        Me.waveformPainter1.Size = New System.Drawing.Size(270, 60)
        Me.waveformPainter1.TabIndex = 121
        Me.waveformPainter1.Text = "waveformPainter1"
        '
        'volumeMeter2
        '
        Me.volumeMeter2.Amplitude = 0!
        Me.volumeMeter2.BackColor = System.Drawing.Color.LightGray
        Me.volumeMeter2.Boost = 1!
        Me.volumeMeter2.Location = New System.Drawing.Point(51, 40)
        Me.volumeMeter2.MaxDb = 18!
        Me.volumeMeter2.MinDb = -60!
        Me.volumeMeter2.Name = "volumeMeter2"
        Me.volumeMeter2.Size = New System.Drawing.Size(22, 126)
        Me.volumeMeter2.TabIndex = 120
        '
        'volumeMeter1
        '
        Me.volumeMeter1.Amplitude = 0!
        Me.volumeMeter1.BackColor = System.Drawing.Color.LightGray
        Me.volumeMeter1.Boost = 1!
        Me.volumeMeter1.Location = New System.Drawing.Point(23, 40)
        Me.volumeMeter1.MaxDb = 18!
        Me.volumeMeter1.MinDb = -60!
        Me.volumeMeter1.Name = "volumeMeter1"
        Me.volumeMeter1.Size = New System.Drawing.Size(22, 126)
        Me.volumeMeter1.TabIndex = 116
        '
        'tabPage99
        '
        Me.tabPage99.Controls.Add(Me.rbAddAudioStreamsIndependent)
        Me.tabPage99.Controls.Add(Me.rbAddAudioStreamsMix)
        Me.tabPage99.Controls.Add(Me.label319)
        Me.tabPage99.Controls.Add(Me.label318)
        Me.tabPage99.Controls.Add(Me.btAddAdditionalAudioSource)
        Me.tabPage99.Controls.Add(Me.cbAdditionalAudioSource)
        Me.tabPage99.Controls.Add(Me.label180)
        Me.tabPage99.Location = New System.Drawing.Point(4, 22)
        Me.tabPage99.Margin = New System.Windows.Forms.Padding(2)
        Me.tabPage99.Name = "tabPage99"
        Me.tabPage99.Padding = New System.Windows.Forms.Padding(2)
        Me.tabPage99.Size = New System.Drawing.Size(447, 251)
        Me.tabPage99.TabIndex = 3
        Me.tabPage99.Text = "Additional audio inputs"
        Me.tabPage99.UseVisualStyleBackColor = true
        '
        'rbAddAudioStreamsIndependent
        '
        Me.rbAddAudioStreamsIndependent.AutoSize = true
        Me.rbAddAudioStreamsIndependent.Location = New System.Drawing.Point(17, 88)
        Me.rbAddAudioStreamsIndependent.Name = "rbAddAudioStreamsIndependent"
        Me.rbAddAudioStreamsIndependent.Size = New System.Drawing.Size(124, 17)
        Me.rbAddAudioStreamsIndependent.TabIndex = 95
        Me.rbAddAudioStreamsIndependent.Text = "Independent streams"
        Me.rbAddAudioStreamsIndependent.UseVisualStyleBackColor = true
        '
        'rbAddAudioStreamsMix
        '
        Me.rbAddAudioStreamsMix.AutoSize = true
        Me.rbAddAudioStreamsMix.Checked = true
        Me.rbAddAudioStreamsMix.Location = New System.Drawing.Point(17, 65)
        Me.rbAddAudioStreamsMix.Name = "rbAddAudioStreamsMix"
        Me.rbAddAudioStreamsMix.Size = New System.Drawing.Size(297, 17)
        Me.rbAddAudioStreamsMix.TabIndex = 94
        Me.rbAddAudioStreamsMix.TabStop = true
        Me.rbAddAudioStreamsMix.Text = "Mix into one stream (one additional stream only supported)"
        Me.rbAddAudioStreamsMix.UseVisualStyleBackColor = true
        '
        'label319
        '
        Me.label319.AutoSize = true
        Me.label319.Location = New System.Drawing.Point(44, 133)
        Me.label319.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label319.Name = "label319"
        Me.label319.Size = New System.Drawing.Size(291, 13)
        Me.label319.TabIndex = 91
        Me.label319.Text = "Please contact support if additional formats support required."
        '
        'label318
        '
        Me.label318.AutoSize = true
        Me.label318.Location = New System.Drawing.Point(44, 115)
        Me.label318.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label318.Name = "label318"
        Me.label318.Size = New System.Drawing.Size(270, 13)
        Me.label318.TabIndex = 90
        Me.label318.Text = "Currently AVI and WMV with a special profile supported."
        '
        'btAddAdditionalAudioSource
        '
        Me.btAddAdditionalAudioSource.Location = New System.Drawing.Point(368, 32)
        Me.btAddAdditionalAudioSource.Margin = New System.Windows.Forms.Padding(2)
        Me.btAddAdditionalAudioSource.Name = "btAddAdditionalAudioSource"
        Me.btAddAdditionalAudioSource.Size = New System.Drawing.Size(56, 23)
        Me.btAddAdditionalAudioSource.TabIndex = 89
        Me.btAddAdditionalAudioSource.Text = "Add"
        Me.btAddAdditionalAudioSource.UseVisualStyleBackColor = true
        '
        'cbAdditionalAudioSource
        '
        Me.cbAdditionalAudioSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAdditionalAudioSource.FormattingEnabled = true
        Me.cbAdditionalAudioSource.Location = New System.Drawing.Point(17, 33)
        Me.cbAdditionalAudioSource.Name = "cbAdditionalAudioSource"
        Me.cbAdditionalAudioSource.Size = New System.Drawing.Size(346, 21)
        Me.cbAdditionalAudioSource.TabIndex = 88
        '
        'label180
        '
        Me.label180.AutoSize = true
        Me.label180.Location = New System.Drawing.Point(14, 15)
        Me.label180.Name = "label180"
        Me.label180.Size = New System.Drawing.Size(66, 13)
        Me.label180.TabIndex = 87
        Me.label180.Text = "Input device"
        '
        'tabPage47
        '
        Me.tabPage47.Controls.Add(Me.label3)
        Me.tabPage47.Controls.Add(Me.lbScreenSourceWindowText)
        Me.tabPage47.Controls.Add(Me.btScreenSourceWindowSelect)
        Me.tabPage47.Controls.Add(Me.rbScreenCaptureWindow)
        Me.tabPage47.Controls.Add(Me.textBox1)
        Me.tabPage47.Controls.Add(Me.cbScreenCapture_DesktopDuplication)
        Me.tabPage47.Controls.Add(Me.cbScreenCaptureDisplayIndex)
        Me.tabPage47.Controls.Add(Me.label93)
        Me.tabPage47.Controls.Add(Me.btScreenCaptureUpdate)
        Me.tabPage47.Controls.Add(Me.cbScreenCapture_GrabMouseCursor)
        Me.tabPage47.Controls.Add(Me.label79)
        Me.tabPage47.Controls.Add(Me.edScreenFrameRate)
        Me.tabPage47.Controls.Add(Me.label43)
        Me.tabPage47.Controls.Add(Me.edScreenBottom)
        Me.tabPage47.Controls.Add(Me.label42)
        Me.tabPage47.Controls.Add(Me.edScreenRight)
        Me.tabPage47.Controls.Add(Me.label40)
        Me.tabPage47.Controls.Add(Me.edScreenTop)
        Me.tabPage47.Controls.Add(Me.label26)
        Me.tabPage47.Controls.Add(Me.edScreenLeft)
        Me.tabPage47.Controls.Add(Me.label24)
        Me.tabPage47.Controls.Add(Me.rbScreenCustomArea)
        Me.tabPage47.Controls.Add(Me.rbScreenFullScreen)
        Me.tabPage47.Location = New System.Drawing.Point(4, 22)
        Me.tabPage47.Name = "tabPage47"
        Me.tabPage47.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage47.Size = New System.Drawing.Size(459, 285)
        Me.tabPage47.TabIndex = 1
        Me.tabPage47.Text = "Screen capture"
        Me.tabPage47.UseVisualStyleBackColor = true
        '
        'label3
        '
        Me.label3.AutoSize = true
        Me.label3.Location = New System.Drawing.Point(268, 209)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(191, 13)
        Me.label3.TabIndex = 62
        Me.label3.Text = "(You can capture background window)"
        '
        'lbScreenSourceWindowText
        '
        Me.lbScreenSourceWindowText.AutoSize = true
        Me.lbScreenSourceWindowText.Location = New System.Drawing.Point(289, 192)
        Me.lbScreenSourceWindowText.Name = "lbScreenSourceWindowText"
        Me.lbScreenSourceWindowText.Size = New System.Drawing.Size(107, 13)
        Me.lbScreenSourceWindowText.TabIndex = 61
        Me.lbScreenSourceWindowText.Text = "(no window selected)"
        '
        'btScreenSourceWindowSelect
        '
        Me.btScreenSourceWindowSelect.Location = New System.Drawing.Point(392, 159)
        Me.btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect"
        Me.btScreenSourceWindowSelect.Size = New System.Drawing.Size(49, 23)
        Me.btScreenSourceWindowSelect.TabIndex = 60
        Me.btScreenSourceWindowSelect.Text = "Select"
        Me.btScreenSourceWindowSelect.UseVisualStyleBackColor = true
        '
        'rbScreenCaptureWindow
        '
        Me.rbScreenCaptureWindow.AutoSize = true
        Me.rbScreenCaptureWindow.Location = New System.Drawing.Point(274, 162)
        Me.rbScreenCaptureWindow.Name = "rbScreenCaptureWindow"
        Me.rbScreenCaptureWindow.Size = New System.Drawing.Size(101, 17)
        Me.rbScreenCaptureWindow.TabIndex = 59
        Me.rbScreenCaptureWindow.TabStop = true
        Me.rbScreenCaptureWindow.Text = "Capture window"
        Me.rbScreenCaptureWindow.UseVisualStyleBackColor = true
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.Color.White
        Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBox1.Location = New System.Drawing.Point(274, 19)
        Me.textBox1.Multiline = true
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = true
        Me.textBox1.Size = New System.Drawing.Size(167, 59)
        Me.textBox1.TabIndex = 58
        Me.textBox1.Text = "You can update left/top position and mouse cursor capturing on-the-fly"
        '
        'cbScreenCapture_DesktopDuplication
        '
        Me.cbScreenCapture_DesktopDuplication.AutoSize = true
        Me.cbScreenCapture_DesktopDuplication.Location = New System.Drawing.Point(19, 243)
        Me.cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication"
        Me.cbScreenCapture_DesktopDuplication.Size = New System.Drawing.Size(210, 17)
        Me.cbScreenCapture_DesktopDuplication.TabIndex = 56
        Me.cbScreenCapture_DesktopDuplication.Text = "Allow Win8 Desktop Duplication usage"
        Me.cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true
        '
        'cbScreenCaptureDisplayIndex
        '
        Me.cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbScreenCaptureDisplayIndex.FormattingEnabled = true
        Me.cbScreenCaptureDisplayIndex.Location = New System.Drawing.Point(88, 187)
        Me.cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex"
        Me.cbScreenCaptureDisplayIndex.Size = New System.Drawing.Size(44, 21)
        Me.cbScreenCaptureDisplayIndex.TabIndex = 51
        '
        'label93
        '
        Me.label93.AutoSize = true
        Me.label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.label93.Location = New System.Drawing.Point(16, 190)
        Me.label93.Name = "label93"
        Me.label93.Size = New System.Drawing.Size(65, 13)
        Me.label93.TabIndex = 50
        Me.label93.Text = "Display ID"
        '
        'btScreenCaptureUpdate
        '
        Me.btScreenCaptureUpdate.Location = New System.Drawing.Point(314, 96)
        Me.btScreenCaptureUpdate.Name = "btScreenCaptureUpdate"
        Me.btScreenCaptureUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btScreenCaptureUpdate.TabIndex = 47
        Me.btScreenCaptureUpdate.Text = "Update"
        Me.btScreenCaptureUpdate.UseVisualStyleBackColor = true
        '
        'cbScreenCapture_GrabMouseCursor
        '
        Me.cbScreenCapture_GrabMouseCursor.AutoSize = true
        Me.cbScreenCapture_GrabMouseCursor.Location = New System.Drawing.Point(19, 220)
        Me.cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor"
        Me.cbScreenCapture_GrabMouseCursor.Size = New System.Drawing.Size(129, 17)
        Me.cbScreenCapture_GrabMouseCursor.TabIndex = 43
        Me.cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor"
        Me.cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true
        '
        'label79
        '
        Me.label79.AutoSize = true
        Me.label79.Location = New System.Drawing.Point(137, 160)
        Me.label79.Name = "label79"
        Me.label79.Size = New System.Drawing.Size(21, 13)
        Me.label79.TabIndex = 42
        Me.label79.Text = "fps"
        '
        'edScreenFrameRate
        '
        Me.edScreenFrameRate.Location = New System.Drawing.Point(88, 157)
        Me.edScreenFrameRate.Name = "edScreenFrameRate"
        Me.edScreenFrameRate.Size = New System.Drawing.Size(44, 20)
        Me.edScreenFrameRate.TabIndex = 41
        Me.edScreenFrameRate.Text = "5"
        '
        'label43
        '
        Me.label43.AutoSize = true
        Me.label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.label43.Location = New System.Drawing.Point(16, 160)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(67, 13)
        Me.label43.TabIndex = 40
        Me.label43.Text = "Frame rate"
        '
        'edScreenBottom
        '
        Me.edScreenBottom.Location = New System.Drawing.Point(204, 119)
        Me.edScreenBottom.Name = "edScreenBottom"
        Me.edScreenBottom.Size = New System.Drawing.Size(44, 20)
        Me.edScreenBottom.TabIndex = 39
        Me.edScreenBottom.Text = "480"
        '
        'label42
        '
        Me.label42.AutoSize = true
        Me.label42.Location = New System.Drawing.Point(161, 122)
        Me.label42.Name = "label42"
        Me.label42.Size = New System.Drawing.Size(40, 13)
        Me.label42.TabIndex = 38
        Me.label42.Text = "Bottom"
        '
        'edScreenRight
        '
        Me.edScreenRight.Location = New System.Drawing.Point(88, 119)
        Me.edScreenRight.Name = "edScreenRight"
        Me.edScreenRight.Size = New System.Drawing.Size(44, 20)
        Me.edScreenRight.TabIndex = 37
        Me.edScreenRight.Text = "640"
        '
        'label40
        '
        Me.label40.AutoSize = true
        Me.label40.Location = New System.Drawing.Point(47, 122)
        Me.label40.Name = "label40"
        Me.label40.Size = New System.Drawing.Size(32, 13)
        Me.label40.TabIndex = 36
        Me.label40.Text = "Right"
        '
        'edScreenTop
        '
        Me.edScreenTop.Location = New System.Drawing.Point(204, 79)
        Me.edScreenTop.Name = "edScreenTop"
        Me.edScreenTop.Size = New System.Drawing.Size(44, 20)
        Me.edScreenTop.TabIndex = 35
        Me.edScreenTop.Text = "0"
        '
        'label26
        '
        Me.label26.AutoSize = true
        Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.label26.Location = New System.Drawing.Point(161, 82)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(29, 13)
        Me.label26.TabIndex = 34
        Me.label26.Text = "Top"
        '
        'edScreenLeft
        '
        Me.edScreenLeft.Location = New System.Drawing.Point(88, 79)
        Me.edScreenLeft.Name = "edScreenLeft"
        Me.edScreenLeft.Size = New System.Drawing.Size(44, 20)
        Me.edScreenLeft.TabIndex = 33
        Me.edScreenLeft.Text = "0"
        '
        'label24
        '
        Me.label24.AutoSize = true
        Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.label24.Location = New System.Drawing.Point(47, 82)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(29, 13)
        Me.label24.TabIndex = 32
        Me.label24.Text = "Left"
        '
        'rbScreenCustomArea
        '
        Me.rbScreenCustomArea.AutoSize = true
        Me.rbScreenCustomArea.Location = New System.Drawing.Point(19, 41)
        Me.rbScreenCustomArea.Name = "rbScreenCustomArea"
        Me.rbScreenCustomArea.Size = New System.Drawing.Size(84, 17)
        Me.rbScreenCustomArea.TabIndex = 31
        Me.rbScreenCustomArea.Text = "Custom area"
        Me.rbScreenCustomArea.UseVisualStyleBackColor = true
        '
        'rbScreenFullScreen
        '
        Me.rbScreenFullScreen.AutoSize = true
        Me.rbScreenFullScreen.Checked = true
        Me.rbScreenFullScreen.Location = New System.Drawing.Point(19, 17)
        Me.rbScreenFullScreen.Name = "rbScreenFullScreen"
        Me.rbScreenFullScreen.Size = New System.Drawing.Size(76, 17)
        Me.rbScreenFullScreen.TabIndex = 30
        Me.rbScreenFullScreen.TabStop = true
        Me.rbScreenFullScreen.Text = "Full screen"
        Me.rbScreenFullScreen.UseVisualStyleBackColor = true
        '
        'tabPage48
        '
        Me.tabPage48.Controls.Add(Me.tabControl15)
        Me.tabPage48.Location = New System.Drawing.Point(4, 22)
        Me.tabPage48.Name = "tabPage48"
        Me.tabPage48.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage48.Size = New System.Drawing.Size(459, 285)
        Me.tabPage48.TabIndex = 2
        Me.tabPage48.Text = "IP camera / Network stream"
        Me.tabPage48.UseVisualStyleBackColor = true
        '
        'tabControl15
        '
        Me.tabControl15.Controls.Add(Me.tabPage144)
        Me.tabControl15.Controls.Add(Me.tabPage146)
        Me.tabControl15.Controls.Add(Me.tabPage145)
        Me.tabControl15.Location = New System.Drawing.Point(6, 6)
        Me.tabControl15.Name = "tabControl15"
        Me.tabControl15.SelectedIndex = 0
        Me.tabControl15.Size = New System.Drawing.Size(447, 273)
        Me.tabControl15.TabIndex = 63
        '
        'tabPage144
        '
        Me.tabPage144.Controls.Add(Me.cbIPURL)
        Me.tabPage144.Controls.Add(Me.btListNDISources)
        Me.tabPage144.Controls.Add(Me.lbNDI)
        Me.tabPage144.Controls.Add(Me.label25)
        Me.tabPage144.Controls.Add(Me.LinkLabel3)
        Me.tabPage144.Controls.Add(Me.Label2)
        Me.tabPage144.Controls.Add(Me.linkLabel7)
        Me.tabPage144.Controls.Add(Me.label165)
        Me.tabPage144.Controls.Add(Me.cbIPCameraONVIF)
        Me.tabPage144.Controls.Add(Me.btShowIPCamDatabase)
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
        Me.tabPage144.Location = New System.Drawing.Point(4, 22)
        Me.tabPage144.Name = "tabPage144"
        Me.tabPage144.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage144.Size = New System.Drawing.Size(439, 247)
        Me.tabPage144.TabIndex = 0
        Me.tabPage144.Text = "Main"
        Me.tabPage144.UseVisualStyleBackColor = true
        '
        'cbIPURL
        '
        Me.cbIPURL.FormattingEnabled = true
        Me.cbIPURL.Location = New System.Drawing.Point(58, 11)
        Me.cbIPURL.Name = "cbIPURL"
        Me.cbIPURL.Size = New System.Drawing.Size(360, 21)
        Me.cbIPURL.TabIndex = 92
        Me.cbIPURL.Text = "rtsp://192.168.1.101:554/stream1"
        '
        'btListNDISources
        '
        Me.btListNDISources.Location = New System.Drawing.Point(16, 209)
        Me.btListNDISources.Name = "btListNDISources"
        Me.btListNDISources.Size = New System.Drawing.Size(123, 23)
        Me.btListNDISources.TabIndex = 91
        Me.btListNDISources.Text = "List NDI sources"
        Me.btListNDISources.UseVisualStyleBackColor = true
        '
        'lbNDI
        '
        Me.lbNDI.AutoSize = true
        Me.lbNDI.Location = New System.Drawing.Point(262, 185)
        Me.lbNDI.Name = "lbNDI"
        Me.lbNDI.Size = New System.Drawing.Size(86, 13)
        Me.lbNDI.TabIndex = 90
        Me.lbNDI.TabStop = true
        Me.lbNDI.Text = "vendor's website"
        '
        'label25
        '
        Me.label25.AutoSize = true
        Me.label25.Location = New System.Drawing.Point(13, 185)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(257, 13)
        Me.label25.TabIndex = 89
        Me.label25.Text = "To use NDI please install NDI SDK for Windows from"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = true
        Me.LinkLabel3.Location = New System.Drawing.Point(376, 158)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(24, 13)
        Me.LinkLabel3.TabIndex = 88
        Me.LinkLabel3.TabStop = true
        Me.LinkLabel3.Text = "x64"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(13, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(327, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Please install VLC redist EXE or NuGet package to use VLC engine "
        '
        'linkLabel7
        '
        Me.linkLabel7.AutoSize = true
        Me.linkLabel7.Location = New System.Drawing.Point(346, 158)
        Me.linkLabel7.Name = "linkLabel7"
        Me.linkLabel7.Size = New System.Drawing.Size(24, 13)
        Me.linkLabel7.TabIndex = 86
        Me.linkLabel7.TabStop = true
        Me.linkLabel7.Text = "x86"
        '
        'label165
        '
        Me.label165.AutoSize = true
        Me.label165.Location = New System.Drawing.Point(13, 14)
        Me.label165.Name = "label165"
        Me.label165.Size = New System.Drawing.Size(29, 13)
        Me.label165.TabIndex = 79
        Me.label165.Text = "URL"
        '
        'cbIPCameraONVIF
        '
        Me.cbIPCameraONVIF.AutoSize = true
        Me.cbIPCameraONVIF.Location = New System.Drawing.Point(295, 42)
        Me.cbIPCameraONVIF.Name = "cbIPCameraONVIF"
        Me.cbIPCameraONVIF.Size = New System.Drawing.Size(96, 17)
        Me.cbIPCameraONVIF.TabIndex = 78
        Me.cbIPCameraONVIF.Text = "ONVIF camera"
        Me.cbIPCameraONVIF.UseVisualStyleBackColor = true
        '
        'btShowIPCamDatabase
        '
        Me.btShowIPCamDatabase.Location = New System.Drawing.Point(283, 209)
        Me.btShowIPCamDatabase.Name = "btShowIPCamDatabase"
        Me.btShowIPCamDatabase.Size = New System.Drawing.Size(135, 23)
        Me.btShowIPCamDatabase.TabIndex = 77
        Me.btShowIPCamDatabase.Text = "Show IP cam database"
        Me.btShowIPCamDatabase.UseVisualStyleBackColor = true
        '
        'cbIPDisconnect
        '
        Me.cbIPDisconnect.AutoSize = true
        Me.cbIPDisconnect.Location = New System.Drawing.Point(295, 88)
        Me.cbIPDisconnect.Name = "cbIPDisconnect"
        Me.cbIPDisconnect.Size = New System.Drawing.Size(136, 17)
        Me.cbIPDisconnect.TabIndex = 75
        Me.cbIPDisconnect.Text = "Notify if connection lost"
        Me.cbIPDisconnect.UseVisualStyleBackColor = true
        '
        'edIPForcedFramerateID
        '
        Me.edIPForcedFramerateID.Location = New System.Drawing.Point(268, 130)
        Me.edIPForcedFramerateID.Margin = New System.Windows.Forms.Padding(2)
        Me.edIPForcedFramerateID.Name = "edIPForcedFramerateID"
        Me.edIPForcedFramerateID.Size = New System.Drawing.Size(32, 20)
        Me.edIPForcedFramerateID.TabIndex = 71
        Me.edIPForcedFramerateID.Text = "0"
        '
        'label344
        '
        Me.label344.AutoSize = true
        Me.label344.Location = New System.Drawing.Point(166, 132)
        Me.label344.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label344.Name = "label344"
        Me.label344.Size = New System.Drawing.Size(98, 13)
        Me.label344.TabIndex = 70
        Me.label344.Text = "Force frame rate ID"
        '
        'edIPForcedFramerate
        '
        Me.edIPForcedFramerate.Location = New System.Drawing.Point(115, 130)
        Me.edIPForcedFramerate.Margin = New System.Windows.Forms.Padding(2)
        Me.edIPForcedFramerate.Name = "edIPForcedFramerate"
        Me.edIPForcedFramerate.Size = New System.Drawing.Size(32, 20)
        Me.edIPForcedFramerate.TabIndex = 69
        Me.edIPForcedFramerate.Text = "0"
        '
        'label295
        '
        Me.label295.AutoSize = true
        Me.label295.Location = New System.Drawing.Point(13, 132)
        Me.label295.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label295.Name = "label295"
        Me.label295.Size = New System.Drawing.Size(84, 13)
        Me.label295.TabIndex = 68
        Me.label295.Text = "Force frame rate"
        '
        'cbIPCameraType
        '
        Me.cbIPCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIPCameraType.FormattingEnabled = true
        Me.cbIPCameraType.Items.AddRange(New Object() {"Auto (VLC engine)", "Auto (FFMPEG engine)", "Auto (LAV engine)", "RTSP (Live555 engine)", "MMS - WMV", "HTTP MJPEG Low Latency", "RTSP Low Latency TCP", "RTSP Low Latency UDP", "NDI", "NDI (Legacy)"})
        Me.cbIPCameraType.Location = New System.Drawing.Point(58, 40)
        Me.cbIPCameraType.Name = "cbIPCameraType"
        Me.cbIPCameraType.Size = New System.Drawing.Size(227, 21)
        Me.cbIPCameraType.TabIndex = 67
        '
        'edIPPassword
        '
        Me.edIPPassword.Location = New System.Drawing.Point(169, 88)
        Me.edIPPassword.Name = "edIPPassword"
        Me.edIPPassword.Size = New System.Drawing.Size(100, 20)
        Me.edIPPassword.TabIndex = 66
        '
        'label167
        '
        Me.label167.AutoSize = true
        Me.label167.Location = New System.Drawing.Point(166, 71)
        Me.label167.Name = "label167"
        Me.label167.Size = New System.Drawing.Size(53, 13)
        Me.label167.TabIndex = 65
        Me.label167.Text = "Password"
        '
        'edIPLogin
        '
        Me.edIPLogin.Location = New System.Drawing.Point(16, 88)
        Me.edIPLogin.Name = "edIPLogin"
        Me.edIPLogin.Size = New System.Drawing.Size(100, 20)
        Me.edIPLogin.TabIndex = 64
        '
        'label166
        '
        Me.label166.AutoSize = true
        Me.label166.Location = New System.Drawing.Point(12, 71)
        Me.label166.Name = "label166"
        Me.label166.Size = New System.Drawing.Size(33, 13)
        Me.label166.TabIndex = 63
        Me.label166.Text = "Login"
        '
        'cbIPAudioCapture
        '
        Me.cbIPAudioCapture.AutoSize = true
        Me.cbIPAudioCapture.Checked = true
        Me.cbIPAudioCapture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIPAudioCapture.Location = New System.Drawing.Point(295, 65)
        Me.cbIPAudioCapture.Name = "cbIPAudioCapture"
        Me.cbIPAudioCapture.Size = New System.Drawing.Size(92, 17)
        Me.cbIPAudioCapture.TabIndex = 62
        Me.cbIPAudioCapture.Text = "Capture audio"
        Me.cbIPAudioCapture.UseVisualStyleBackColor = true
        '
        'label168
        '
        Me.label168.AutoSize = true
        Me.label168.Location = New System.Drawing.Point(12, 44)
        Me.label168.Name = "label168"
        Me.label168.Size = New System.Drawing.Size(40, 13)
        Me.label168.TabIndex = 61
        Me.label168.Text = "Engine"
        '
        'tabPage146
        '
        Me.tabPage146.Controls.Add(Me.cbVLCZeroClockJitter)
        Me.tabPage146.Controls.Add(Me.edVLCCacheSize)
        Me.tabPage146.Controls.Add(Me.label312)
        Me.tabPage146.Location = New System.Drawing.Point(4, 22)
        Me.tabPage146.Name = "tabPage146"
        Me.tabPage146.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage146.Size = New System.Drawing.Size(439, 247)
        Me.tabPage146.TabIndex = 2
        Me.tabPage146.Text = "VLC"
        Me.tabPage146.UseVisualStyleBackColor = true
        '
        'cbVLCZeroClockJitter
        '
        Me.cbVLCZeroClockJitter.AutoSize = true
        Me.cbVLCZeroClockJitter.Location = New System.Drawing.Point(173, 16)
        Me.cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter"
        Me.cbVLCZeroClockJitter.Size = New System.Drawing.Size(134, 17)
        Me.cbVLCZeroClockJitter.TabIndex = 78
        Me.cbVLCZeroClockJitter.Text = "VLC  low latency mode"
        Me.cbVLCZeroClockJitter.UseVisualStyleBackColor = true
        '
        'edVLCCacheSize
        '
        Me.edVLCCacheSize.Location = New System.Drawing.Point(119, 14)
        Me.edVLCCacheSize.Name = "edVLCCacheSize"
        Me.edVLCCacheSize.Size = New System.Drawing.Size(32, 20)
        Me.edVLCCacheSize.TabIndex = 77
        Me.edVLCCacheSize.Text = "250"
        '
        'label312
        '
        Me.label312.AutoSize = true
        Me.label312.Location = New System.Drawing.Point(17, 17)
        Me.label312.Name = "label312"
        Me.label312.Size = New System.Drawing.Size(103, 13)
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
        Me.tabPage145.Controls.Add(Me.edONVIFLiveVideoURL)
        Me.tabPage145.Controls.Add(Me.label513)
        Me.tabPage145.Controls.Add(Me.groupBox42)
        Me.tabPage145.Controls.Add(Me.cbONVIFProfile)
        Me.tabPage145.Controls.Add(Me.label510)
        Me.tabPage145.Controls.Add(Me.lbONVIFCameraInfo)
        Me.tabPage145.Controls.Add(Me.btONVIFConnect)
        Me.tabPage145.Location = New System.Drawing.Point(4, 22)
        Me.tabPage145.Name = "tabPage145"
        Me.tabPage145.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage145.Size = New System.Drawing.Size(439, 247)
        Me.tabPage145.TabIndex = 1
        Me.tabPage145.Text = "ONVIF"
        Me.tabPage145.UseVisualStyleBackColor = true
        '
        'edONVIFPassword
        '
        Me.edONVIFPassword.Location = New System.Drawing.Point(242, 38)
        Me.edONVIFPassword.Name = "edONVIFPassword"
        Me.edONVIFPassword.Size = New System.Drawing.Size(100, 20)
        Me.edONVIFPassword.TabIndex = 75
        '
        'Label379
        '
        Me.Label379.AutoSize = true
        Me.Label379.Location = New System.Drawing.Point(184, 41)
        Me.Label379.Name = "Label379"
        Me.Label379.Size = New System.Drawing.Size(53, 13)
        Me.Label379.TabIndex = 74
        Me.Label379.Text = "Password"
        '
        'edONVIFLogin
        '
        Me.edONVIFLogin.Location = New System.Drawing.Point(77, 38)
        Me.edONVIFLogin.Name = "edONVIFLogin"
        Me.edONVIFLogin.Size = New System.Drawing.Size(100, 20)
        Me.edONVIFLogin.TabIndex = 73
        '
        'Label380
        '
        Me.Label380.AutoSize = true
        Me.Label380.Location = New System.Drawing.Point(13, 41)
        Me.Label380.Name = "Label380"
        Me.Label380.Size = New System.Drawing.Size(33, 13)
        Me.Label380.TabIndex = 72
        Me.Label380.Text = "Login"
        '
        'edONVIFURL
        '
        Me.edONVIFURL.Location = New System.Drawing.Point(16, 8)
        Me.edONVIFURL.Name = "edONVIFURL"
        Me.edONVIFURL.Size = New System.Drawing.Size(326, 20)
        Me.edONVIFURL.TabIndex = 71
        Me.edONVIFURL.Text = "http://192.168.1.200/onvif/device_service"
        '
        'edONVIFLiveVideoURL
        '
        Me.edONVIFLiveVideoURL.Location = New System.Drawing.Point(76, 111)
        Me.edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL"
        Me.edONVIFLiveVideoURL.ReadOnly = true
        Me.edONVIFLiveVideoURL.Size = New System.Drawing.Size(346, 20)
        Me.edONVIFLiveVideoURL.TabIndex = 28
        '
        'label513
        '
        Me.label513.AutoSize = true
        Me.label513.Location = New System.Drawing.Point(12, 114)
        Me.label513.Name = "label513"
        Me.label513.Size = New System.Drawing.Size(59, 13)
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
        Me.groupBox42.Location = New System.Drawing.Point(15, 137)
        Me.groupBox42.Name = "groupBox42"
        Me.groupBox42.Size = New System.Drawing.Size(271, 104)
        Me.groupBox42.TabIndex = 26
        Me.groupBox42.TabStop = false
        Me.groupBox42.Text = "PTZ"
        '
        'btONVIFPTZSetDefault
        '
        Me.btONVIFPTZSetDefault.Location = New System.Drawing.Point(130, 44)
        Me.btONVIFPTZSetDefault.Name = "btONVIFPTZSetDefault"
        Me.btONVIFPTZSetDefault.Size = New System.Drawing.Size(116, 23)
        Me.btONVIFPTZSetDefault.TabIndex = 6
        Me.btONVIFPTZSetDefault.Text = "Set default position"
        Me.btONVIFPTZSetDefault.UseVisualStyleBackColor = true
        '
        'btONVIFRight
        '
        Me.btONVIFRight.Location = New System.Drawing.Point(85, 33)
        Me.btONVIFRight.Name = "btONVIFRight"
        Me.btONVIFRight.Size = New System.Drawing.Size(21, 48)
        Me.btONVIFRight.TabIndex = 5
        Me.btONVIFRight.Text = "R"
        Me.btONVIFRight.UseVisualStyleBackColor = true
        '
        'btONVIFLeft
        '
        Me.btONVIFLeft.Location = New System.Drawing.Point(13, 32)
        Me.btONVIFLeft.Name = "btONVIFLeft"
        Me.btONVIFLeft.Size = New System.Drawing.Size(21, 48)
        Me.btONVIFLeft.TabIndex = 4
        Me.btONVIFLeft.Text = "L"
        Me.btONVIFLeft.UseVisualStyleBackColor = true
        '
        'btONVIFZoomOut
        '
        Me.btONVIFZoomOut.Location = New System.Drawing.Point(61, 45)
        Me.btONVIFZoomOut.Name = "btONVIFZoomOut"
        Me.btONVIFZoomOut.Size = New System.Drawing.Size(23, 23)
        Me.btONVIFZoomOut.TabIndex = 3
        Me.btONVIFZoomOut.Text = "-"
        Me.btONVIFZoomOut.UseVisualStyleBackColor = true
        '
        'btONVIFZoomIn
        '
        Me.btONVIFZoomIn.Location = New System.Drawing.Point(35, 45)
        Me.btONVIFZoomIn.Name = "btONVIFZoomIn"
        Me.btONVIFZoomIn.Size = New System.Drawing.Size(22, 23)
        Me.btONVIFZoomIn.TabIndex = 2
        Me.btONVIFZoomIn.Text = "+"
        Me.btONVIFZoomIn.UseVisualStyleBackColor = true
        '
        'btONVIFDown
        '
        Me.btONVIFDown.Location = New System.Drawing.Point(34, 69)
        Me.btONVIFDown.Name = "btONVIFDown"
        Me.btONVIFDown.Size = New System.Drawing.Size(51, 23)
        Me.btONVIFDown.TabIndex = 1
        Me.btONVIFDown.Text = "Down"
        Me.btONVIFDown.UseVisualStyleBackColor = true
        '
        'btONVIFUp
        '
        Me.btONVIFUp.Location = New System.Drawing.Point(34, 20)
        Me.btONVIFUp.Name = "btONVIFUp"
        Me.btONVIFUp.Size = New System.Drawing.Size(51, 23)
        Me.btONVIFUp.TabIndex = 0
        Me.btONVIFUp.Text = "Up"
        Me.btONVIFUp.UseVisualStyleBackColor = true
        '
        'cbONVIFProfile
        '
        Me.cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbONVIFProfile.FormattingEnabled = true
        Me.cbONVIFProfile.Location = New System.Drawing.Point(76, 85)
        Me.cbONVIFProfile.Name = "cbONVIFProfile"
        Me.cbONVIFProfile.Size = New System.Drawing.Size(346, 21)
        Me.cbONVIFProfile.TabIndex = 4
        '
        'label510
        '
        Me.label510.AutoSize = true
        Me.label510.Location = New System.Drawing.Point(13, 88)
        Me.label510.Name = "label510"
        Me.label510.Size = New System.Drawing.Size(36, 13)
        Me.label510.TabIndex = 3
        Me.label510.Text = "Profile"
        '
        'lbONVIFCameraInfo
        '
        Me.lbONVIFCameraInfo.AutoSize = true
        Me.lbONVIFCameraInfo.Location = New System.Drawing.Point(12, 65)
        Me.lbONVIFCameraInfo.Name = "lbONVIFCameraInfo"
        Me.lbONVIFCameraInfo.Size = New System.Drawing.Size(69, 13)
        Me.lbONVIFCameraInfo.TabIndex = 1
        Me.lbONVIFCameraInfo.Text = "Status: None"
        '
        'btONVIFConnect
        '
        Me.btONVIFConnect.Location = New System.Drawing.Point(347, 6)
        Me.btONVIFConnect.Name = "btONVIFConnect"
        Me.btONVIFConnect.Size = New System.Drawing.Size(75, 23)
        Me.btONVIFConnect.TabIndex = 0
        Me.btONVIFConnect.Text = "Connect"
        Me.btONVIFConnect.UseVisualStyleBackColor = true
        '
        'TabPage61
        '
        Me.TabPage61.Controls.Add(Me.cbDecklinkCaptureVideoFormat)
        Me.TabPage61.Controls.Add(Me.label66)
        Me.TabPage61.Controls.Add(Me.cbDecklinkCaptureDevice)
        Me.TabPage61.Controls.Add(Me.label39)
        Me.TabPage61.Controls.Add(Me.cbDecklinkSourceTimecode)
        Me.TabPage61.Controls.Add(Me.label341)
        Me.TabPage61.Controls.Add(Me.cbDecklinkSourceComponentLevels)
        Me.TabPage61.Controls.Add(Me.label339)
        Me.TabPage61.Controls.Add(Me.cbDecklinkSourceNTSC)
        Me.TabPage61.Controls.Add(Me.label340)
        Me.TabPage61.Controls.Add(Me.cbDecklinkSourceInput)
        Me.TabPage61.Controls.Add(Me.label338)
        Me.TabPage61.Location = New System.Drawing.Point(4, 22)
        Me.TabPage61.Name = "TabPage61"
        Me.TabPage61.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage61.Size = New System.Drawing.Size(459, 285)
        Me.TabPage61.TabIndex = 10
        Me.TabPage61.Text = "Decklink"
        Me.TabPage61.UseVisualStyleBackColor = true
        '
        'cbDecklinkCaptureVideoFormat
        '
        Me.cbDecklinkCaptureVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkCaptureVideoFormat.FormattingEnabled = true
        Me.cbDecklinkCaptureVideoFormat.Location = New System.Drawing.Point(17, 77)
        Me.cbDecklinkCaptureVideoFormat.Name = "cbDecklinkCaptureVideoFormat"
        Me.cbDecklinkCaptureVideoFormat.Size = New System.Drawing.Size(182, 21)
        Me.cbDecklinkCaptureVideoFormat.TabIndex = 35
        '
        'label66
        '
        Me.label66.AutoSize = true
        Me.label66.Location = New System.Drawing.Point(14, 61)
        Me.label66.Name = "label66"
        Me.label66.Size = New System.Drawing.Size(159, 13)
        Me.label66.TabIndex = 34
        Me.label66.Text = "Video format (original format first)"
        '
        'cbDecklinkCaptureDevice
        '
        Me.cbDecklinkCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkCaptureDevice.FormattingEnabled = true
        Me.cbDecklinkCaptureDevice.Location = New System.Drawing.Point(17, 33)
        Me.cbDecklinkCaptureDevice.Name = "cbDecklinkCaptureDevice"
        Me.cbDecklinkCaptureDevice.Size = New System.Drawing.Size(182, 21)
        Me.cbDecklinkCaptureDevice.TabIndex = 33
        '
        'label39
        '
        Me.label39.AutoSize = true
        Me.label39.Location = New System.Drawing.Point(14, 17)
        Me.label39.Name = "label39"
        Me.label39.Size = New System.Drawing.Size(41, 13)
        Me.label39.TabIndex = 32
        Me.label39.Text = "Device"
        '
        'cbDecklinkSourceTimecode
        '
        Me.cbDecklinkSourceTimecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkSourceTimecode.FormattingEnabled = true
        Me.cbDecklinkSourceTimecode.Items.AddRange(New Object() {"Auto", "VITC", "HANC"})
        Me.cbDecklinkSourceTimecode.Location = New System.Drawing.Point(168, 244)
        Me.cbDecklinkSourceTimecode.Name = "cbDecklinkSourceTimecode"
        Me.cbDecklinkSourceTimecode.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkSourceTimecode.TabIndex = 31
        '
        'label341
        '
        Me.label341.AutoSize = true
        Me.label341.Location = New System.Drawing.Point(165, 228)
        Me.label341.Name = "label341"
        Me.label341.Size = New System.Drawing.Size(89, 13)
        Me.label341.TabIndex = 30
        Me.label341.Text = "Timecode source"
        '
        'cbDecklinkSourceComponentLevels
        '
        Me.cbDecklinkSourceComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkSourceComponentLevels.FormattingEnabled = true
        Me.cbDecklinkSourceComponentLevels.Items.AddRange(New Object() {"SMPTE", "Betacam"})
        Me.cbDecklinkSourceComponentLevels.Location = New System.Drawing.Point(320, 244)
        Me.cbDecklinkSourceComponentLevels.Name = "cbDecklinkSourceComponentLevels"
        Me.cbDecklinkSourceComponentLevels.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkSourceComponentLevels.TabIndex = 29
        '
        'label339
        '
        Me.label339.AutoSize = true
        Me.label339.Location = New System.Drawing.Point(317, 228)
        Me.label339.Name = "label339"
        Me.label339.Size = New System.Drawing.Size(91, 13)
        Me.label339.TabIndex = 28
        Me.label339.Text = "Component levels"
        '
        'cbDecklinkSourceNTSC
        '
        Me.cbDecklinkSourceNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkSourceNTSC.FormattingEnabled = true
        Me.cbDecklinkSourceNTSC.Items.AddRange(New Object() {"USA", "Japan"})
        Me.cbDecklinkSourceNTSC.Location = New System.Drawing.Point(320, 199)
        Me.cbDecklinkSourceNTSC.Name = "cbDecklinkSourceNTSC"
        Me.cbDecklinkSourceNTSC.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkSourceNTSC.TabIndex = 27
        '
        'label340
        '
        Me.label340.AutoSize = true
        Me.label340.Location = New System.Drawing.Point(317, 183)
        Me.label340.Name = "label340"
        Me.label340.Size = New System.Drawing.Size(80, 13)
        Me.label340.TabIndex = 26
        Me.label340.Text = "NTSC standard"
        '
        'cbDecklinkSourceInput
        '
        Me.cbDecklinkSourceInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkSourceInput.FormattingEnabled = true
        Me.cbDecklinkSourceInput.Items.AddRange(New Object() {"Auto", "SDI", "Composite", "Component", "S-Video", "HDMI", "Optical SDI"})
        Me.cbDecklinkSourceInput.Location = New System.Drawing.Point(168, 199)
        Me.cbDecklinkSourceInput.Name = "cbDecklinkSourceInput"
        Me.cbDecklinkSourceInput.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkSourceInput.TabIndex = 25
        '
        'label338
        '
        Me.label338.AutoSize = true
        Me.label338.Location = New System.Drawing.Point(165, 183)
        Me.label338.Name = "label338"
        Me.label338.Size = New System.Drawing.Size(31, 13)
        Me.label338.TabIndex = 24
        Me.label338.Text = "Input"
        '
        'TabPage66
        '
        Me.TabPage66.Controls.Add(Me.tabControl22)
        Me.TabPage66.Location = New System.Drawing.Point(4, 22)
        Me.TabPage66.Name = "TabPage66"
        Me.TabPage66.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage66.Size = New System.Drawing.Size(459, 285)
        Me.TabPage66.TabIndex = 7
        Me.TabPage66.Text = "DVB-x / ATSC"
        Me.TabPage66.UseVisualStyleBackColor = true
        '
        'tabControl22
        '
        Me.tabControl22.Controls.Add(Me.tabPage82)
        Me.tabControl22.Controls.Add(Me.tabPage83)
        Me.tabControl22.Controls.Add(Me.TabPage104)
        Me.tabControl22.Location = New System.Drawing.Point(6, 6)
        Me.tabControl22.Name = "tabControl22"
        Me.tabControl22.SelectedIndex = 0
        Me.tabControl22.Size = New System.Drawing.Size(447, 273)
        Me.tabControl22.TabIndex = 13
        '
        'tabPage82
        '
        Me.tabPage82.Controls.Add(Me.cbBDADeviceStandard)
        Me.tabPage82.Controls.Add(Me.label129)
        Me.tabPage82.Controls.Add(Me.cbBDAReceiver)
        Me.tabPage82.Controls.Add(Me.label270)
        Me.tabPage82.Controls.Add(Me.cbBDASourceDevice)
        Me.tabPage82.Controls.Add(Me.label272)
        Me.tabPage82.Location = New System.Drawing.Point(4, 22)
        Me.tabPage82.Name = "tabPage82"
        Me.tabPage82.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage82.Size = New System.Drawing.Size(439, 247)
        Me.tabPage82.TabIndex = 0
        Me.tabPage82.Text = "Input device"
        Me.tabPage82.UseVisualStyleBackColor = true
        '
        'cbBDADeviceStandard
        '
        Me.cbBDADeviceStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBDADeviceStandard.FormattingEnabled = true
        Me.cbBDADeviceStandard.Items.AddRange(New Object() {"DVB-T", "DVB-S", "DVB-C", "ATSC (not supported now)"})
        Me.cbBDADeviceStandard.Location = New System.Drawing.Point(14, 130)
        Me.cbBDADeviceStandard.Name = "cbBDADeviceStandard"
        Me.cbBDADeviceStandard.Size = New System.Drawing.Size(269, 21)
        Me.cbBDADeviceStandard.TabIndex = 17
        '
        'label129
        '
        Me.label129.AutoSize = true
        Me.label129.Location = New System.Drawing.Point(11, 114)
        Me.label129.Name = "label129"
        Me.label129.Size = New System.Drawing.Size(85, 13)
        Me.label129.TabIndex = 16
        Me.label129.Text = "Device standard"
        '
        'cbBDAReceiver
        '
        Me.cbBDAReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBDAReceiver.FormattingEnabled = true
        Me.cbBDAReceiver.Items.AddRange(New Object() {""})
        Me.cbBDAReceiver.Location = New System.Drawing.Point(14, 81)
        Me.cbBDAReceiver.Name = "cbBDAReceiver"
        Me.cbBDAReceiver.Size = New System.Drawing.Size(269, 21)
        Me.cbBDAReceiver.TabIndex = 15
        '
        'label270
        '
        Me.label270.AutoSize = true
        Me.label270.Location = New System.Drawing.Point(11, 65)
        Me.label270.Name = "label270"
        Me.label270.Size = New System.Drawing.Size(158, 13)
        Me.label270.TabIndex = 14
        Me.label270.Text = "Receiver device (can be empty)"
        '
        'cbBDASourceDevice
        '
        Me.cbBDASourceDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBDASourceDevice.FormattingEnabled = true
        Me.cbBDASourceDevice.Location = New System.Drawing.Point(14, 32)
        Me.cbBDASourceDevice.Name = "cbBDASourceDevice"
        Me.cbBDASourceDevice.Size = New System.Drawing.Size(269, 21)
        Me.cbBDASourceDevice.TabIndex = 13
        '
        'label272
        '
        Me.label272.AutoSize = true
        Me.label272.Location = New System.Drawing.Point(11, 16)
        Me.label272.Name = "label272"
        Me.label272.Size = New System.Drawing.Size(76, 13)
        Me.label272.TabIndex = 12
        Me.label272.Text = "Source device"
        '
        'tabPage83
        '
        Me.tabPage83.Controls.Add(Me.tabControl23)
        Me.tabPage83.Location = New System.Drawing.Point(4, 22)
        Me.tabPage83.Name = "tabPage83"
        Me.tabPage83.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage83.Size = New System.Drawing.Size(439, 247)
        Me.tabPage83.TabIndex = 1
        Me.tabPage83.Text = "Tuning"
        Me.tabPage83.UseVisualStyleBackColor = true
        '
        'tabControl23
        '
        Me.tabControl23.Controls.Add(Me.tabPage84)
        Me.tabControl23.Controls.Add(Me.tabPage85)
        Me.tabControl23.Controls.Add(Me.tabPage86)
        Me.tabControl23.Controls.Add(Me.tabPage87)
        Me.tabControl23.Location = New System.Drawing.Point(6, 4)
        Me.tabControl23.Name = "tabControl23"
        Me.tabControl23.SelectedIndex = 0
        Me.tabControl23.Size = New System.Drawing.Size(427, 240)
        Me.tabControl23.TabIndex = 8
        '
        'tabPage84
        '
        Me.tabPage84.Controls.Add(Me.btDVBTTune)
        Me.tabPage84.Controls.Add(Me.edDVBTSID)
        Me.tabPage84.Controls.Add(Me.edDVBTTSID)
        Me.tabPage84.Controls.Add(Me.edDVBTONID)
        Me.tabPage84.Controls.Add(Me.label273)
        Me.tabPage84.Controls.Add(Me.edDVBTFrequency)
        Me.tabPage84.Controls.Add(Me.label274)
        Me.tabPage84.Controls.Add(Me.label275)
        Me.tabPage84.Controls.Add(Me.label276)
        Me.tabPage84.Controls.Add(Me.label277)
        Me.tabPage84.Location = New System.Drawing.Point(4, 22)
        Me.tabPage84.Name = "tabPage84"
        Me.tabPage84.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage84.Size = New System.Drawing.Size(419, 214)
        Me.tabPage84.TabIndex = 0
        Me.tabPage84.Text = "DVB-T"
        Me.tabPage84.UseVisualStyleBackColor = true
        '
        'btDVBTTune
        '
        Me.btDVBTTune.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btDVBTTune.Location = New System.Drawing.Point(6, 185)
        Me.btDVBTTune.Name = "btDVBTTune"
        Me.btDVBTTune.Size = New System.Drawing.Size(46, 23)
        Me.btDVBTTune.TabIndex = 21
        Me.btDVBTTune.Text = "Tune"
        Me.btDVBTTune.UseVisualStyleBackColor = true
        '
        'edDVBTSID
        '
        Me.edDVBTSID.Location = New System.Drawing.Point(102, 94)
        Me.edDVBTSID.Name = "edDVBTSID"
        Me.edDVBTSID.Size = New System.Drawing.Size(94, 20)
        Me.edDVBTSID.TabIndex = 20
        Me.edDVBTSID.Text = "3"
        '
        'edDVBTTSID
        '
        Me.edDVBTTSID.Location = New System.Drawing.Point(102, 66)
        Me.edDVBTTSID.Name = "edDVBTTSID"
        Me.edDVBTTSID.Size = New System.Drawing.Size(94, 20)
        Me.edDVBTTSID.TabIndex = 19
        Me.edDVBTTSID.Text = "3"
        '
        'edDVBTONID
        '
        Me.edDVBTONID.Location = New System.Drawing.Point(102, 37)
        Me.edDVBTONID.Name = "edDVBTONID"
        Me.edDVBTONID.Size = New System.Drawing.Size(94, 20)
        Me.edDVBTONID.TabIndex = 18
        Me.edDVBTONID.Text = "0"
        '
        'label273
        '
        Me.label273.AutoSize = true
        Me.label273.Location = New System.Drawing.Point(202, 11)
        Me.label273.Name = "label273"
        Me.label273.Size = New System.Drawing.Size(27, 13)
        Me.label273.TabIndex = 17
        Me.label273.Text = "KHz"
        '
        'edDVBTFrequency
        '
        Me.edDVBTFrequency.Location = New System.Drawing.Point(102, 8)
        Me.edDVBTFrequency.Name = "edDVBTFrequency"
        Me.edDVBTFrequency.Size = New System.Drawing.Size(94, 20)
        Me.edDVBTFrequency.TabIndex = 16
        Me.edDVBTFrequency.Text = "586000"
        '
        'label274
        '
        Me.label274.AutoSize = true
        Me.label274.Location = New System.Drawing.Point(6, 97)
        Me.label274.Name = "label274"
        Me.label274.Size = New System.Drawing.Size(25, 13)
        Me.label274.TabIndex = 15
        Me.label274.Text = "SID"
        '
        'label275
        '
        Me.label275.AutoSize = true
        Me.label275.Location = New System.Drawing.Point(6, 69)
        Me.label275.Name = "label275"
        Me.label275.Size = New System.Drawing.Size(32, 13)
        Me.label275.TabIndex = 14
        Me.label275.Text = "TSID"
        '
        'label276
        '
        Me.label276.AutoSize = true
        Me.label276.Location = New System.Drawing.Point(6, 40)
        Me.label276.Name = "label276"
        Me.label276.Size = New System.Drawing.Size(34, 13)
        Me.label276.TabIndex = 13
        Me.label276.Text = "ONID"
        '
        'label277
        '
        Me.label277.AutoSize = true
        Me.label277.Location = New System.Drawing.Point(6, 11)
        Me.label277.Name = "label277"
        Me.label277.Size = New System.Drawing.Size(90, 13)
        Me.label277.TabIndex = 12
        Me.label277.Text = "Carrier Frequency"
        '
        'tabPage85
        '
        Me.tabPage85.Controls.Add(Me.cbDVBSPolarisation)
        Me.tabPage85.Controls.Add(Me.label278)
        Me.tabPage85.Controls.Add(Me.edDVBSSymbolRate)
        Me.tabPage85.Controls.Add(Me.label279)
        Me.tabPage85.Controls.Add(Me.btDVBSTune)
        Me.tabPage85.Controls.Add(Me.edDVBSSID)
        Me.tabPage85.Controls.Add(Me.edDVBSTSID)
        Me.tabPage85.Controls.Add(Me.edDVBSONIT)
        Me.tabPage85.Controls.Add(Me.label280)
        Me.tabPage85.Controls.Add(Me.edDVBSFrequency)
        Me.tabPage85.Controls.Add(Me.label281)
        Me.tabPage85.Controls.Add(Me.label282)
        Me.tabPage85.Controls.Add(Me.label283)
        Me.tabPage85.Controls.Add(Me.label284)
        Me.tabPage85.Location = New System.Drawing.Point(4, 22)
        Me.tabPage85.Name = "tabPage85"
        Me.tabPage85.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage85.Size = New System.Drawing.Size(419, 214)
        Me.tabPage85.TabIndex = 1
        Me.tabPage85.Text = "DVB-S"
        Me.tabPage85.UseVisualStyleBackColor = true
        '
        'cbDVBSPolarisation
        '
        Me.cbDVBSPolarisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVBSPolarisation.Items.AddRange(New Object() {"Not Set", "Not Defined", "Linear Horizontal", "Linear Vertical", "Circular Left", "Circular Right", "Max"})
        Me.cbDVBSPolarisation.Location = New System.Drawing.Point(102, 60)
        Me.cbDVBSPolarisation.Name = "cbDVBSPolarisation"
        Me.cbDVBSPolarisation.Size = New System.Drawing.Size(94, 21)
        Me.cbDVBSPolarisation.TabIndex = 34
        '
        'label278
        '
        Me.label278.AutoSize = true
        Me.label278.Location = New System.Drawing.Point(6, 63)
        Me.label278.Name = "label278"
        Me.label278.Size = New System.Drawing.Size(93, 13)
        Me.label278.TabIndex = 33
        Me.label278.Text = "Signal Polarisation"
        '
        'edDVBSSymbolRate
        '
        Me.edDVBSSymbolRate.Location = New System.Drawing.Point(102, 34)
        Me.edDVBSSymbolRate.Name = "edDVBSSymbolRate"
        Me.edDVBSSymbolRate.Size = New System.Drawing.Size(94, 20)
        Me.edDVBSSymbolRate.TabIndex = 32
        Me.edDVBSSymbolRate.Text = "-1"
        '
        'label279
        '
        Me.label279.AutoSize = true
        Me.label279.Location = New System.Drawing.Point(6, 37)
        Me.label279.Name = "label279"
        Me.label279.Size = New System.Drawing.Size(67, 13)
        Me.label279.TabIndex = 31
        Me.label279.Text = "Symbol Rate"
        '
        'btDVBSTune
        '
        Me.btDVBSTune.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btDVBSTune.Location = New System.Drawing.Point(6, 185)
        Me.btDVBSTune.Name = "btDVBSTune"
        Me.btDVBSTune.Size = New System.Drawing.Size(46, 23)
        Me.btDVBSTune.TabIndex = 30
        Me.btDVBSTune.Text = "Tune"
        Me.btDVBSTune.UseVisualStyleBackColor = true
        '
        'edDVBSSID
        '
        Me.edDVBSSID.Location = New System.Drawing.Point(102, 144)
        Me.edDVBSSID.Name = "edDVBSSID"
        Me.edDVBSSID.Size = New System.Drawing.Size(94, 20)
        Me.edDVBSSID.TabIndex = 29
        Me.edDVBSSID.Text = "-1"
        '
        'edDVBSTSID
        '
        Me.edDVBSTSID.Location = New System.Drawing.Point(102, 116)
        Me.edDVBSTSID.Name = "edDVBSTSID"
        Me.edDVBSTSID.Size = New System.Drawing.Size(94, 20)
        Me.edDVBSTSID.TabIndex = 28
        Me.edDVBSTSID.Text = "-1"
        '
        'edDVBSONIT
        '
        Me.edDVBSONIT.Location = New System.Drawing.Point(102, 87)
        Me.edDVBSONIT.Name = "edDVBSONIT"
        Me.edDVBSONIT.Size = New System.Drawing.Size(94, 20)
        Me.edDVBSONIT.TabIndex = 27
        Me.edDVBSONIT.Text = "-1"
        '
        'label280
        '
        Me.label280.AutoSize = true
        Me.label280.Location = New System.Drawing.Point(202, 11)
        Me.label280.Name = "label280"
        Me.label280.Size = New System.Drawing.Size(27, 13)
        Me.label280.TabIndex = 26
        Me.label280.Text = "KHz"
        '
        'edDVBSFrequency
        '
        Me.edDVBSFrequency.Location = New System.Drawing.Point(102, 8)
        Me.edDVBSFrequency.Name = "edDVBSFrequency"
        Me.edDVBSFrequency.Size = New System.Drawing.Size(94, 20)
        Me.edDVBSFrequency.TabIndex = 25
        Me.edDVBSFrequency.Text = "-1"
        '
        'label281
        '
        Me.label281.AutoSize = true
        Me.label281.Location = New System.Drawing.Point(6, 147)
        Me.label281.Name = "label281"
        Me.label281.Size = New System.Drawing.Size(25, 13)
        Me.label281.TabIndex = 24
        Me.label281.Text = "SID"
        '
        'label282
        '
        Me.label282.AutoSize = true
        Me.label282.Location = New System.Drawing.Point(6, 119)
        Me.label282.Name = "label282"
        Me.label282.Size = New System.Drawing.Size(32, 13)
        Me.label282.TabIndex = 23
        Me.label282.Text = "TSID"
        '
        'label283
        '
        Me.label283.AutoSize = true
        Me.label283.Location = New System.Drawing.Point(6, 90)
        Me.label283.Name = "label283"
        Me.label283.Size = New System.Drawing.Size(33, 13)
        Me.label283.TabIndex = 22
        Me.label283.Text = "ONIT"
        '
        'label284
        '
        Me.label284.AutoSize = true
        Me.label284.Location = New System.Drawing.Point(6, 11)
        Me.label284.Name = "label284"
        Me.label284.Size = New System.Drawing.Size(90, 13)
        Me.label284.TabIndex = 21
        Me.label284.Text = "Carrier Frequency"
        '
        'tabPage86
        '
        Me.tabPage86.Controls.Add(Me.groupBox35)
        Me.tabPage86.Controls.Add(Me.groupBox36)
        Me.tabPage86.Controls.Add(Me.btBDADVBCTune)
        Me.tabPage86.Location = New System.Drawing.Point(4, 22)
        Me.tabPage86.Name = "tabPage86"
        Me.tabPage86.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage86.Size = New System.Drawing.Size(419, 214)
        Me.tabPage86.TabIndex = 2
        Me.tabPage86.Text = "DVB-C"
        Me.tabPage86.UseVisualStyleBackColor = true
        '
        'groupBox35
        '
        Me.groupBox35.Controls.Add(Me.edDVBCMinorChannel)
        Me.groupBox35.Controls.Add(Me.label285)
        Me.groupBox35.Controls.Add(Me.edDVBCPhysicalChannel)
        Me.groupBox35.Controls.Add(Me.label286)
        Me.groupBox35.Controls.Add(Me.edDVBCVirtualChannel)
        Me.groupBox35.Controls.Add(Me.label287)
        Me.groupBox35.Location = New System.Drawing.Point(232, 9)
        Me.groupBox35.Name = "groupBox35"
        Me.groupBox35.Size = New System.Drawing.Size(181, 107)
        Me.groupBox35.TabIndex = 46
        Me.groupBox35.TabStop = false
        Me.groupBox35.Text = "Tune request"
        '
        'edDVBCMinorChannel
        '
        Me.edDVBCMinorChannel.Location = New System.Drawing.Point(98, 76)
        Me.edDVBCMinorChannel.Name = "edDVBCMinorChannel"
        Me.edDVBCMinorChannel.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCMinorChannel.TabIndex = 57
        Me.edDVBCMinorChannel.Text = "-1"
        '
        'label285
        '
        Me.label285.AutoSize = true
        Me.label285.Location = New System.Drawing.Point(6, 79)
        Me.label285.Name = "label285"
        Me.label285.Size = New System.Drawing.Size(74, 13)
        Me.label285.TabIndex = 56
        Me.label285.Text = "Minor channel"
        '
        'edDVBCPhysicalChannel
        '
        Me.edDVBCPhysicalChannel.Location = New System.Drawing.Point(98, 51)
        Me.edDVBCPhysicalChannel.Name = "edDVBCPhysicalChannel"
        Me.edDVBCPhysicalChannel.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCPhysicalChannel.TabIndex = 55
        Me.edDVBCPhysicalChannel.Text = "103"
        '
        'label286
        '
        Me.label286.AutoSize = true
        Me.label286.Location = New System.Drawing.Point(6, 54)
        Me.label286.Name = "label286"
        Me.label286.Size = New System.Drawing.Size(87, 13)
        Me.label286.TabIndex = 54
        Me.label286.Text = "Physical channel"
        '
        'edDVBCVirtualChannel
        '
        Me.edDVBCVirtualChannel.Location = New System.Drawing.Point(98, 24)
        Me.edDVBCVirtualChannel.Name = "edDVBCVirtualChannel"
        Me.edDVBCVirtualChannel.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCVirtualChannel.TabIndex = 53
        Me.edDVBCVirtualChannel.Text = "-1"
        '
        'label287
        '
        Me.label287.AutoSize = true
        Me.label287.Location = New System.Drawing.Point(6, 27)
        Me.label287.Name = "label287"
        Me.label287.Size = New System.Drawing.Size(77, 13)
        Me.label287.TabIndex = 52
        Me.label287.Text = "Virtual channel"
        '
        'groupBox36
        '
        Me.groupBox36.Controls.Add(Me.edDVBCSymbolRate)
        Me.groupBox36.Controls.Add(Me.label288)
        Me.groupBox36.Controls.Add(Me.edDVBCProgramNumber)
        Me.groupBox36.Controls.Add(Me.label289)
        Me.groupBox36.Controls.Add(Me.cbDVBCModulation)
        Me.groupBox36.Controls.Add(Me.label290)
        Me.groupBox36.Controls.Add(Me.label291)
        Me.groupBox36.Controls.Add(Me.edDVBCCarrierFrequency)
        Me.groupBox36.Controls.Add(Me.label292)
        Me.groupBox36.Location = New System.Drawing.Point(6, 9)
        Me.groupBox36.Name = "groupBox36"
        Me.groupBox36.Size = New System.Drawing.Size(220, 139)
        Me.groupBox36.TabIndex = 45
        Me.groupBox36.TabStop = false
        Me.groupBox36.Text = "Current locator properties"
        '
        'edDVBCSymbolRate
        '
        Me.edDVBCSymbolRate.Location = New System.Drawing.Point(106, 104)
        Me.edDVBCSymbolRate.Name = "edDVBCSymbolRate"
        Me.edDVBCSymbolRate.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCSymbolRate.TabIndex = 53
        Me.edDVBCSymbolRate.Text = "6875"
        '
        'label288
        '
        Me.label288.AutoSize = true
        Me.label288.Location = New System.Drawing.Point(10, 107)
        Me.label288.Name = "label288"
        Me.label288.Size = New System.Drawing.Size(62, 13)
        Me.label288.TabIndex = 52
        Me.label288.Text = "Symbol rate"
        '
        'edDVBCProgramNumber
        '
        Me.edDVBCProgramNumber.Location = New System.Drawing.Point(106, 78)
        Me.edDVBCProgramNumber.Name = "edDVBCProgramNumber"
        Me.edDVBCProgramNumber.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCProgramNumber.TabIndex = 51
        Me.edDVBCProgramNumber.Text = "8"
        '
        'label289
        '
        Me.label289.AutoSize = true
        Me.label289.Location = New System.Drawing.Point(10, 81)
        Me.label289.Name = "label289"
        Me.label289.Size = New System.Drawing.Size(84, 13)
        Me.label289.TabIndex = 50
        Me.label289.Text = "Program number"
        '
        'cbDVBCModulation
        '
        Me.cbDVBCModulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVBCModulation.Items.AddRange(New Object() {"ModNotSet", "ModNotDefined", "Mod16Qam", "Mod32Qam", "Mod64Qam", "Mod80Qam", "Mod96Qam", "Mod112Qam", "Mod128Qam", "Mod160Qam", "Mod192Qam", "Mod224Qam", "Mod256Qam", "Mod320Qam", "Mod384Qam", "Mod448Qam", "Mod512Qam", "Mod640Qam", "Mod768Qam", "Mod896Qam", "Mod1024Qam", "ModQpsk", "ModBpsk", "ModOqpsk", "Mod8Vsb", "Mod16Vsb", "ModAnalogAmplitude ", "ModAnalogFrequency ", "Mod8Psk", "ModRF", "Mod16Apsk", "Mod32Apsk", "ModNbcQpsk", "ModNbc8Psk", "ModDirectTv", "ModMax"})
        Me.cbDVBCModulation.Location = New System.Drawing.Point(106, 51)
        Me.cbDVBCModulation.Name = "cbDVBCModulation"
        Me.cbDVBCModulation.Size = New System.Drawing.Size(77, 21)
        Me.cbDVBCModulation.TabIndex = 49
        '
        'label290
        '
        Me.label290.AutoSize = true
        Me.label290.Location = New System.Drawing.Point(10, 54)
        Me.label290.Name = "label290"
        Me.label290.Size = New System.Drawing.Size(59, 13)
        Me.label290.TabIndex = 48
        Me.label290.Text = "Modulation"
        '
        'label291
        '
        Me.label291.AutoSize = true
        Me.label291.Location = New System.Drawing.Point(189, 28)
        Me.label291.Name = "label291"
        Me.label291.Size = New System.Drawing.Size(27, 13)
        Me.label291.TabIndex = 47
        Me.label291.Text = "KHz"
        '
        'edDVBCCarrierFrequency
        '
        Me.edDVBCCarrierFrequency.Location = New System.Drawing.Point(106, 24)
        Me.edDVBCCarrierFrequency.Name = "edDVBCCarrierFrequency"
        Me.edDVBCCarrierFrequency.Size = New System.Drawing.Size(77, 20)
        Me.edDVBCCarrierFrequency.TabIndex = 46
        Me.edDVBCCarrierFrequency.Text = "303250"
        '
        'label292
        '
        Me.label292.AutoSize = true
        Me.label292.Location = New System.Drawing.Point(10, 27)
        Me.label292.Name = "label292"
        Me.label292.Size = New System.Drawing.Size(87, 13)
        Me.label292.TabIndex = 45
        Me.label292.Text = "Carrier frequency"
        '
        'btBDADVBCTune
        '
        Me.btBDADVBCTune.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btBDADVBCTune.Location = New System.Drawing.Point(6, 185)
        Me.btBDADVBCTune.Name = "btBDADVBCTune"
        Me.btBDADVBCTune.Size = New System.Drawing.Size(46, 23)
        Me.btBDADVBCTune.TabIndex = 36
        Me.btBDADVBCTune.Text = "Tune"
        Me.btBDADVBCTune.UseVisualStyleBackColor = true
        '
        'tabPage87
        '
        Me.tabPage87.Controls.Add(Me.label293)
        Me.tabPage87.Location = New System.Drawing.Point(4, 22)
        Me.tabPage87.Name = "tabPage87"
        Me.tabPage87.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage87.Size = New System.Drawing.Size(419, 214)
        Me.tabPage87.TabIndex = 3
        Me.tabPage87.Text = "ATSC"
        Me.tabPage87.UseVisualStyleBackColor = true
        '
        'label293
        '
        Me.label293.AutoSize = true
        Me.label293.Location = New System.Drawing.Point(10, 11)
        Me.label293.Name = "label293"
        Me.label293.Size = New System.Drawing.Size(101, 13)
        Me.label293.TabIndex = 0
        Me.label293.Text = "not implemented yet"
        '
        'TabPage104
        '
        Me.TabPage104.Controls.Add(Me.btBDAChannelScanningStart)
        Me.TabPage104.Controls.Add(Me.lvBDAChannels)
        Me.TabPage104.Controls.Add(Me.label342)
        Me.TabPage104.Location = New System.Drawing.Point(4, 22)
        Me.TabPage104.Name = "TabPage104"
        Me.TabPage104.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage104.Size = New System.Drawing.Size(439, 247)
        Me.TabPage104.TabIndex = 2
        Me.TabPage104.Text = "Channel scanning"
        Me.TabPage104.UseVisualStyleBackColor = true
        '
        'btBDAChannelScanningStart
        '
        Me.btBDAChannelScanningStart.Location = New System.Drawing.Point(365, 207)
        Me.btBDAChannelScanningStart.Name = "btBDAChannelScanningStart"
        Me.btBDAChannelScanningStart.Size = New System.Drawing.Size(56, 23)
        Me.btBDAChannelScanningStart.TabIndex = 5
        Me.btBDAChannelScanningStart.Text = "Start"
        Me.btBDAChannelScanningStart.UseVisualStyleBackColor = true
        '
        'lvBDAChannels
        '
        Me.lvBDAChannels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
        Me.lvBDAChannels.HideSelection = false
        Me.lvBDAChannels.Location = New System.Drawing.Point(20, 33)
        Me.lvBDAChannels.Name = "lvBDAChannels"
        Me.lvBDAChannels.Size = New System.Drawing.Size(401, 168)
        Me.lvBDAChannels.TabIndex = 4
        Me.lvBDAChannels.UseCompatibleStateImageBehavior = false
        Me.lvBDAChannels.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Name"
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Frequency"
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Audio PID"
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Video PID"
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "SID"
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Symbol rate"
        '
        'label342
        '
        Me.label342.AutoSize = true
        Me.label342.Location = New System.Drawing.Point(17, 17)
        Me.label342.Name = "label342"
        Me.label342.Size = New System.Drawing.Size(288, 13)
        Me.label342.TabIndex = 3
        Me.label342.Text = "Please tune to a required frequency or other parameters first"
        '
        'tabPage49
        '
        Me.tabPage49.Controls.Add(Me.tabControl20)
        Me.tabPage49.Location = New System.Drawing.Point(4, 22)
        Me.tabPage49.Name = "tabPage49"
        Me.tabPage49.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage49.Size = New System.Drawing.Size(459, 285)
        Me.tabPage49.TabIndex = 3
        Me.tabPage49.Text = "Picture-In-Picture"
        Me.tabPage49.UseVisualStyleBackColor = true
        '
        'tabControl20
        '
        Me.tabControl20.Controls.Add(Me.tabPage67)
        Me.tabControl20.Controls.Add(Me.tabPage77)
        Me.tabControl20.Controls.Add(Me.TabPage113)
        Me.tabControl20.Location = New System.Drawing.Point(4, 5)
        Me.tabControl20.Name = "tabControl20"
        Me.tabControl20.SelectedIndex = 0
        Me.tabControl20.Size = New System.Drawing.Size(450, 275)
        Me.tabControl20.TabIndex = 1
        '
        'tabPage67
        '
        Me.tabPage67.Controls.Add(Me.tabControl21)
        Me.tabPage67.Location = New System.Drawing.Point(4, 22)
        Me.tabPage67.Name = "tabPage67"
        Me.tabPage67.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage67.Size = New System.Drawing.Size(442, 249)
        Me.tabPage67.TabIndex = 0
        Me.tabPage67.Text = "Sources"
        Me.tabPage67.UseVisualStyleBackColor = true
        '
        'tabControl21
        '
        Me.tabControl21.Controls.Add(Me.tabPage78)
        Me.tabControl21.Controls.Add(Me.tabPage79)
        Me.tabControl21.Controls.Add(Me.tabPage80)
        Me.tabControl21.Controls.Add(Me.TabPage93)
        Me.tabControl21.Location = New System.Drawing.Point(6, 6)
        Me.tabControl21.Name = "tabControl21"
        Me.tabControl21.SelectedIndex = 0
        Me.tabControl21.Size = New System.Drawing.Size(433, 240)
        Me.tabControl21.TabIndex = 0
        '
        'tabPage78
        '
        Me.tabPage78.Controls.Add(Me.btPIPAddDevice)
        Me.tabPage78.Controls.Add(Me.groupBox30)
        Me.tabPage78.Controls.Add(Me.cbPIPInput)
        Me.tabPage78.Controls.Add(Me.label170)
        Me.tabPage78.Controls.Add(Me.cbPIPFrameRate)
        Me.tabPage78.Controls.Add(Me.label128)
        Me.tabPage78.Controls.Add(Me.cbPIPFormatUseBest)
        Me.tabPage78.Controls.Add(Me.cbPIPFormat)
        Me.tabPage78.Controls.Add(Me.label127)
        Me.tabPage78.Controls.Add(Me.label126)
        Me.tabPage78.Controls.Add(Me.cbPIPDevice)
        Me.tabPage78.Controls.Add(Me.label125)
        Me.tabPage78.Location = New System.Drawing.Point(4, 22)
        Me.tabPage78.Name = "tabPage78"
        Me.tabPage78.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage78.Size = New System.Drawing.Size(425, 214)
        Me.tabPage78.TabIndex = 0
        Me.tabPage78.Text = "Video capture device"
        Me.tabPage78.UseVisualStyleBackColor = true
        '
        'btPIPAddDevice
        '
        Me.btPIPAddDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btPIPAddDevice.Location = New System.Drawing.Point(11, 180)
        Me.btPIPAddDevice.Name = "btPIPAddDevice"
        Me.btPIPAddDevice.Size = New System.Drawing.Size(54, 23)
        Me.btPIPAddDevice.TabIndex = 63
        Me.btPIPAddDevice.Text = "Add"
        Me.btPIPAddDevice.UseVisualStyleBackColor = true
        '
        'groupBox30
        '
        Me.groupBox30.Controls.Add(Me.edPIPVidCapHeight)
        Me.groupBox30.Controls.Add(Me.label94)
        Me.groupBox30.Controls.Add(Me.edPIPVidCapWidth)
        Me.groupBox30.Controls.Add(Me.label98)
        Me.groupBox30.Controls.Add(Me.edPIPVidCapTop)
        Me.groupBox30.Controls.Add(Me.label99)
        Me.groupBox30.Controls.Add(Me.edPIPVidCapLeft)
        Me.groupBox30.Controls.Add(Me.label100)
        Me.groupBox30.Location = New System.Drawing.Point(215, 137)
        Me.groupBox30.Name = "groupBox30"
        Me.groupBox30.Size = New System.Drawing.Size(204, 71)
        Me.groupBox30.TabIndex = 62
        Me.groupBox30.TabStop = false
        Me.groupBox30.Text = "Position"
        '
        'edPIPVidCapHeight
        '
        Me.edPIPVidCapHeight.Location = New System.Drawing.Point(150, 45)
        Me.edPIPVidCapHeight.Name = "edPIPVidCapHeight"
        Me.edPIPVidCapHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPVidCapHeight.TabIndex = 40
        Me.edPIPVidCapHeight.Text = "200"
        Me.edPIPVidCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label94
        '
        Me.label94.AutoSize = true
        Me.label94.Location = New System.Drawing.Point(112, 48)
        Me.label94.Name = "label94"
        Me.label94.Size = New System.Drawing.Size(38, 13)
        Me.label94.TabIndex = 39
        Me.label94.Text = "Height"
        '
        'edPIPVidCapWidth
        '
        Me.edPIPVidCapWidth.Location = New System.Drawing.Point(150, 19)
        Me.edPIPVidCapWidth.Name = "edPIPVidCapWidth"
        Me.edPIPVidCapWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPVidCapWidth.TabIndex = 38
        Me.edPIPVidCapWidth.Text = "300"
        Me.edPIPVidCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label98
        '
        Me.label98.AutoSize = true
        Me.label98.Location = New System.Drawing.Point(112, 22)
        Me.label98.Name = "label98"
        Me.label98.Size = New System.Drawing.Size(35, 13)
        Me.label98.TabIndex = 37
        Me.label98.Text = "Width"
        '
        'edPIPVidCapTop
        '
        Me.edPIPVidCapTop.Location = New System.Drawing.Point(48, 45)
        Me.edPIPVidCapTop.Name = "edPIPVidCapTop"
        Me.edPIPVidCapTop.Size = New System.Drawing.Size(39, 20)
        Me.edPIPVidCapTop.TabIndex = 36
        Me.edPIPVidCapTop.Text = "0"
        Me.edPIPVidCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label99
        '
        Me.label99.AutoSize = true
        Me.label99.Location = New System.Drawing.Point(15, 48)
        Me.label99.Name = "label99"
        Me.label99.Size = New System.Drawing.Size(26, 13)
        Me.label99.TabIndex = 35
        Me.label99.Text = "Top"
        '
        'edPIPVidCapLeft
        '
        Me.edPIPVidCapLeft.Location = New System.Drawing.Point(48, 19)
        Me.edPIPVidCapLeft.Name = "edPIPVidCapLeft"
        Me.edPIPVidCapLeft.Size = New System.Drawing.Size(39, 20)
        Me.edPIPVidCapLeft.TabIndex = 34
        Me.edPIPVidCapLeft.Text = "0"
        Me.edPIPVidCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label100
        '
        Me.label100.AutoSize = true
        Me.label100.Location = New System.Drawing.Point(15, 22)
        Me.label100.Name = "label100"
        Me.label100.Size = New System.Drawing.Size(25, 13)
        Me.label100.TabIndex = 33
        Me.label100.Text = "Left"
        '
        'cbPIPInput
        '
        Me.cbPIPInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPInput.FormattingEnabled = true
        Me.cbPIPInput.Location = New System.Drawing.Point(85, 94)
        Me.cbPIPInput.Name = "cbPIPInput"
        Me.cbPIPInput.Size = New System.Drawing.Size(205, 21)
        Me.cbPIPInput.TabIndex = 61
        '
        'label170
        '
        Me.label170.AutoSize = true
        Me.label170.Location = New System.Drawing.Point(8, 97)
        Me.label170.Name = "label170"
        Me.label170.Size = New System.Drawing.Size(31, 13)
        Me.label170.TabIndex = 60
        Me.label170.Text = "Input"
        '
        'cbPIPFrameRate
        '
        Me.cbPIPFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPFrameRate.FormattingEnabled = true
        Me.cbPIPFrameRate.Location = New System.Drawing.Point(85, 121)
        Me.cbPIPFrameRate.Name = "cbPIPFrameRate"
        Me.cbPIPFrameRate.Size = New System.Drawing.Size(74, 21)
        Me.cbPIPFrameRate.TabIndex = 59
        '
        'label128
        '
        Me.label128.AutoSize = true
        Me.label128.Location = New System.Drawing.Point(8, 124)
        Me.label128.Name = "label128"
        Me.label128.Size = New System.Drawing.Size(57, 13)
        Me.label128.TabIndex = 58
        Me.label128.Text = "Frame rate"
        '
        'cbPIPFormatUseBest
        '
        Me.cbPIPFormatUseBest.AutoSize = true
        Me.cbPIPFormatUseBest.Location = New System.Drawing.Point(296, 69)
        Me.cbPIPFormatUseBest.Name = "cbPIPFormatUseBest"
        Me.cbPIPFormatUseBest.Size = New System.Drawing.Size(68, 17)
        Me.cbPIPFormatUseBest.TabIndex = 57
        Me.cbPIPFormatUseBest.Text = "Use best"
        Me.cbPIPFormatUseBest.UseVisualStyleBackColor = true
        '
        'cbPIPFormat
        '
        Me.cbPIPFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPFormat.FormattingEnabled = true
        Me.cbPIPFormat.Location = New System.Drawing.Point(85, 67)
        Me.cbPIPFormat.Name = "cbPIPFormat"
        Me.cbPIPFormat.Size = New System.Drawing.Size(205, 21)
        Me.cbPIPFormat.TabIndex = 56
        '
        'label127
        '
        Me.label127.AutoSize = true
        Me.label127.Location = New System.Drawing.Point(8, 70)
        Me.label127.Name = "label127"
        Me.label127.Size = New System.Drawing.Size(66, 13)
        Me.label127.TabIndex = 55
        Me.label127.Text = "Video format"
        '
        'label126
        '
        Me.label126.AutoSize = true
        Me.label126.Location = New System.Drawing.Point(8, 12)
        Me.label126.Name = "label126"
        Me.label126.Size = New System.Drawing.Size(184, 13)
        Me.label126.TabIndex = 54
        Me.label126.Text = "Don't add main video capture device!"
        '
        'cbPIPDevice
        '
        Me.cbPIPDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPDevice.FormattingEnabled = true
        Me.cbPIPDevice.Location = New System.Drawing.Point(85, 40)
        Me.cbPIPDevice.Name = "cbPIPDevice"
        Me.cbPIPDevice.Size = New System.Drawing.Size(205, 21)
        Me.cbPIPDevice.TabIndex = 53
        '
        'label125
        '
        Me.label125.AutoSize = true
        Me.label125.Location = New System.Drawing.Point(8, 43)
        Me.label125.Name = "label125"
        Me.label125.Size = New System.Drawing.Size(70, 13)
        Me.label125.TabIndex = 52
        Me.label125.Text = "Device name"
        '
        'tabPage79
        '
        Me.tabPage79.Controls.Add(Me.groupBox31)
        Me.tabPage79.Controls.Add(Me.btPIPAddIPCamera)
        Me.tabPage79.Location = New System.Drawing.Point(4, 22)
        Me.tabPage79.Name = "tabPage79"
        Me.tabPage79.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage79.Size = New System.Drawing.Size(425, 214)
        Me.tabPage79.TabIndex = 1
        Me.tabPage79.Text = "IP camera"
        Me.tabPage79.UseVisualStyleBackColor = true
        '
        'groupBox31
        '
        Me.groupBox31.Controls.Add(Me.edPIPIPCapHeight)
        Me.groupBox31.Controls.Add(Me.label101)
        Me.groupBox31.Controls.Add(Me.edPIPIPCapWidth)
        Me.groupBox31.Controls.Add(Me.label102)
        Me.groupBox31.Controls.Add(Me.edPIPIPCapTop)
        Me.groupBox31.Controls.Add(Me.label103)
        Me.groupBox31.Controls.Add(Me.edPIPIPCapLeft)
        Me.groupBox31.Controls.Add(Me.label229)
        Me.groupBox31.Location = New System.Drawing.Point(215, 137)
        Me.groupBox31.Name = "groupBox31"
        Me.groupBox31.Size = New System.Drawing.Size(204, 71)
        Me.groupBox31.TabIndex = 63
        Me.groupBox31.TabStop = false
        Me.groupBox31.Text = "Position"
        '
        'edPIPIPCapHeight
        '
        Me.edPIPIPCapHeight.Location = New System.Drawing.Point(150, 45)
        Me.edPIPIPCapHeight.Name = "edPIPIPCapHeight"
        Me.edPIPIPCapHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPIPCapHeight.TabIndex = 40
        Me.edPIPIPCapHeight.Text = "200"
        Me.edPIPIPCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label101
        '
        Me.label101.AutoSize = true
        Me.label101.Location = New System.Drawing.Point(112, 48)
        Me.label101.Name = "label101"
        Me.label101.Size = New System.Drawing.Size(38, 13)
        Me.label101.TabIndex = 39
        Me.label101.Text = "Height"
        '
        'edPIPIPCapWidth
        '
        Me.edPIPIPCapWidth.Location = New System.Drawing.Point(150, 19)
        Me.edPIPIPCapWidth.Name = "edPIPIPCapWidth"
        Me.edPIPIPCapWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPIPCapWidth.TabIndex = 38
        Me.edPIPIPCapWidth.Text = "300"
        Me.edPIPIPCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label102
        '
        Me.label102.AutoSize = true
        Me.label102.Location = New System.Drawing.Point(112, 22)
        Me.label102.Name = "label102"
        Me.label102.Size = New System.Drawing.Size(35, 13)
        Me.label102.TabIndex = 37
        Me.label102.Text = "Width"
        '
        'edPIPIPCapTop
        '
        Me.edPIPIPCapTop.Location = New System.Drawing.Point(48, 45)
        Me.edPIPIPCapTop.Name = "edPIPIPCapTop"
        Me.edPIPIPCapTop.Size = New System.Drawing.Size(39, 20)
        Me.edPIPIPCapTop.TabIndex = 36
        Me.edPIPIPCapTop.Text = "0"
        Me.edPIPIPCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label103
        '
        Me.label103.AutoSize = true
        Me.label103.Location = New System.Drawing.Point(15, 48)
        Me.label103.Name = "label103"
        Me.label103.Size = New System.Drawing.Size(26, 13)
        Me.label103.TabIndex = 35
        Me.label103.Text = "Top"
        '
        'edPIPIPCapLeft
        '
        Me.edPIPIPCapLeft.Location = New System.Drawing.Point(48, 19)
        Me.edPIPIPCapLeft.Name = "edPIPIPCapLeft"
        Me.edPIPIPCapLeft.Size = New System.Drawing.Size(39, 20)
        Me.edPIPIPCapLeft.TabIndex = 34
        Me.edPIPIPCapLeft.Text = "0"
        Me.edPIPIPCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label229
        '
        Me.label229.AutoSize = true
        Me.label229.Location = New System.Drawing.Point(15, 22)
        Me.label229.Name = "label229"
        Me.label229.Size = New System.Drawing.Size(25, 13)
        Me.label229.TabIndex = 33
        Me.label229.Text = "Left"
        '
        'btPIPAddIPCamera
        '
        Me.btPIPAddIPCamera.Location = New System.Drawing.Point(101, 56)
        Me.btPIPAddIPCamera.Name = "btPIPAddIPCamera"
        Me.btPIPAddIPCamera.Size = New System.Drawing.Size(218, 23)
        Me.btPIPAddIPCamera.TabIndex = 0
        Me.btPIPAddIPCamera.Text = "Add using settings from IP Camera tab"
        Me.btPIPAddIPCamera.UseVisualStyleBackColor = true
        '
        'tabPage80
        '
        Me.tabPage80.Controls.Add(Me.groupBox32)
        Me.tabPage80.Controls.Add(Me.btPIPAddScreenCapture)
        Me.tabPage80.Location = New System.Drawing.Point(4, 22)
        Me.tabPage80.Name = "tabPage80"
        Me.tabPage80.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage80.Size = New System.Drawing.Size(425, 214)
        Me.tabPage80.TabIndex = 2
        Me.tabPage80.Text = "Screen source"
        Me.tabPage80.UseVisualStyleBackColor = true
        '
        'groupBox32
        '
        Me.groupBox32.Controls.Add(Me.edPIPScreenCapHeight)
        Me.groupBox32.Controls.Add(Me.label256)
        Me.groupBox32.Controls.Add(Me.edPIPScreenCapWidth)
        Me.groupBox32.Controls.Add(Me.label260)
        Me.groupBox32.Controls.Add(Me.edPIPScreenCapTop)
        Me.groupBox32.Controls.Add(Me.label266)
        Me.groupBox32.Controls.Add(Me.edPIPScreenCapLeft)
        Me.groupBox32.Controls.Add(Me.label268)
        Me.groupBox32.Location = New System.Drawing.Point(215, 137)
        Me.groupBox32.Name = "groupBox32"
        Me.groupBox32.Size = New System.Drawing.Size(204, 71)
        Me.groupBox32.TabIndex = 63
        Me.groupBox32.TabStop = false
        Me.groupBox32.Text = "Position"
        '
        'edPIPScreenCapHeight
        '
        Me.edPIPScreenCapHeight.Location = New System.Drawing.Point(150, 45)
        Me.edPIPScreenCapHeight.Name = "edPIPScreenCapHeight"
        Me.edPIPScreenCapHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPScreenCapHeight.TabIndex = 40
        Me.edPIPScreenCapHeight.Text = "200"
        Me.edPIPScreenCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label256
        '
        Me.label256.AutoSize = true
        Me.label256.Location = New System.Drawing.Point(112, 48)
        Me.label256.Name = "label256"
        Me.label256.Size = New System.Drawing.Size(38, 13)
        Me.label256.TabIndex = 39
        Me.label256.Text = "Height"
        '
        'edPIPScreenCapWidth
        '
        Me.edPIPScreenCapWidth.Location = New System.Drawing.Point(150, 19)
        Me.edPIPScreenCapWidth.Name = "edPIPScreenCapWidth"
        Me.edPIPScreenCapWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPScreenCapWidth.TabIndex = 38
        Me.edPIPScreenCapWidth.Text = "300"
        Me.edPIPScreenCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label260
        '
        Me.label260.AutoSize = true
        Me.label260.Location = New System.Drawing.Point(112, 22)
        Me.label260.Name = "label260"
        Me.label260.Size = New System.Drawing.Size(35, 13)
        Me.label260.TabIndex = 37
        Me.label260.Text = "Width"
        '
        'edPIPScreenCapTop
        '
        Me.edPIPScreenCapTop.Location = New System.Drawing.Point(48, 45)
        Me.edPIPScreenCapTop.Name = "edPIPScreenCapTop"
        Me.edPIPScreenCapTop.Size = New System.Drawing.Size(39, 20)
        Me.edPIPScreenCapTop.TabIndex = 36
        Me.edPIPScreenCapTop.Text = "0"
        Me.edPIPScreenCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label266
        '
        Me.label266.AutoSize = true
        Me.label266.Location = New System.Drawing.Point(15, 48)
        Me.label266.Name = "label266"
        Me.label266.Size = New System.Drawing.Size(26, 13)
        Me.label266.TabIndex = 35
        Me.label266.Text = "Top"
        '
        'edPIPScreenCapLeft
        '
        Me.edPIPScreenCapLeft.Location = New System.Drawing.Point(48, 19)
        Me.edPIPScreenCapLeft.Name = "edPIPScreenCapLeft"
        Me.edPIPScreenCapLeft.Size = New System.Drawing.Size(39, 20)
        Me.edPIPScreenCapLeft.TabIndex = 34
        Me.edPIPScreenCapLeft.Text = "0"
        Me.edPIPScreenCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label268
        '
        Me.label268.AutoSize = true
        Me.label268.Location = New System.Drawing.Point(15, 22)
        Me.label268.Name = "label268"
        Me.label268.Size = New System.Drawing.Size(25, 13)
        Me.label268.TabIndex = 33
        Me.label268.Text = "Left"
        '
        'btPIPAddScreenCapture
        '
        Me.btPIPAddScreenCapture.Location = New System.Drawing.Point(101, 56)
        Me.btPIPAddScreenCapture.Name = "btPIPAddScreenCapture"
        Me.btPIPAddScreenCapture.Size = New System.Drawing.Size(218, 23)
        Me.btPIPAddScreenCapture.TabIndex = 1
        Me.btPIPAddScreenCapture.Text = "Add using settings from Screen Capture tab"
        Me.btPIPAddScreenCapture.UseVisualStyleBackColor = true
        '
        'TabPage93
        '
        Me.TabPage93.Controls.Add(Me.groupBox44)
        Me.TabPage93.Controls.Add(Me.btPIPFileSourceAdd)
        Me.TabPage93.Controls.Add(Me.button1)
        Me.TabPage93.Controls.Add(Me.edPIPFileSoureFilename)
        Me.TabPage93.Controls.Add(Me.label320)
        Me.TabPage93.Location = New System.Drawing.Point(4, 22)
        Me.TabPage93.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage93.Name = "TabPage93"
        Me.TabPage93.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage93.Size = New System.Drawing.Size(425, 214)
        Me.TabPage93.TabIndex = 3
        Me.TabPage93.Text = "Video file"
        Me.TabPage93.UseVisualStyleBackColor = true
        '
        'groupBox44
        '
        Me.groupBox44.Controls.Add(Me.edPIPFileHeight)
        Me.groupBox44.Controls.Add(Me.label321)
        Me.groupBox44.Controls.Add(Me.edPIPFileWidth)
        Me.groupBox44.Controls.Add(Me.label322)
        Me.groupBox44.Controls.Add(Me.edPIPFileTop)
        Me.groupBox44.Controls.Add(Me.label323)
        Me.groupBox44.Controls.Add(Me.edPIPFileLeft)
        Me.groupBox44.Controls.Add(Me.label324)
        Me.groupBox44.Location = New System.Drawing.Point(214, 134)
        Me.groupBox44.Name = "groupBox44"
        Me.groupBox44.Size = New System.Drawing.Size(204, 71)
        Me.groupBox44.TabIndex = 69
        Me.groupBox44.TabStop = false
        Me.groupBox44.Text = "Position"
        '
        'edPIPFileHeight
        '
        Me.edPIPFileHeight.Location = New System.Drawing.Point(150, 45)
        Me.edPIPFileHeight.Name = "edPIPFileHeight"
        Me.edPIPFileHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPFileHeight.TabIndex = 40
        Me.edPIPFileHeight.Text = "200"
        Me.edPIPFileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label321
        '
        Me.label321.AutoSize = true
        Me.label321.Location = New System.Drawing.Point(112, 48)
        Me.label321.Name = "label321"
        Me.label321.Size = New System.Drawing.Size(38, 13)
        Me.label321.TabIndex = 39
        Me.label321.Text = "Height"
        '
        'edPIPFileWidth
        '
        Me.edPIPFileWidth.Location = New System.Drawing.Point(150, 19)
        Me.edPIPFileWidth.Name = "edPIPFileWidth"
        Me.edPIPFileWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPFileWidth.TabIndex = 38
        Me.edPIPFileWidth.Text = "300"
        Me.edPIPFileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label322
        '
        Me.label322.AutoSize = true
        Me.label322.Location = New System.Drawing.Point(112, 22)
        Me.label322.Name = "label322"
        Me.label322.Size = New System.Drawing.Size(35, 13)
        Me.label322.TabIndex = 37
        Me.label322.Text = "Width"
        '
        'edPIPFileTop
        '
        Me.edPIPFileTop.Location = New System.Drawing.Point(48, 45)
        Me.edPIPFileTop.Name = "edPIPFileTop"
        Me.edPIPFileTop.Size = New System.Drawing.Size(39, 20)
        Me.edPIPFileTop.TabIndex = 36
        Me.edPIPFileTop.Text = "0"
        Me.edPIPFileTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label323
        '
        Me.label323.AutoSize = true
        Me.label323.Location = New System.Drawing.Point(15, 48)
        Me.label323.Name = "label323"
        Me.label323.Size = New System.Drawing.Size(26, 13)
        Me.label323.TabIndex = 35
        Me.label323.Text = "Top"
        '
        'edPIPFileLeft
        '
        Me.edPIPFileLeft.Location = New System.Drawing.Point(48, 19)
        Me.edPIPFileLeft.Name = "edPIPFileLeft"
        Me.edPIPFileLeft.Size = New System.Drawing.Size(39, 20)
        Me.edPIPFileLeft.TabIndex = 34
        Me.edPIPFileLeft.Text = "0"
        Me.edPIPFileLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label324
        '
        Me.label324.AutoSize = true
        Me.label324.Location = New System.Drawing.Point(15, 22)
        Me.label324.Name = "label324"
        Me.label324.Size = New System.Drawing.Size(25, 13)
        Me.label324.TabIndex = 33
        Me.label324.Text = "Left"
        '
        'btPIPFileSourceAdd
        '
        Me.btPIPFileSourceAdd.Location = New System.Drawing.Point(303, 27)
        Me.btPIPFileSourceAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btPIPFileSourceAdd.Name = "btPIPFileSourceAdd"
        Me.btPIPFileSourceAdd.Size = New System.Drawing.Size(56, 22)
        Me.btPIPFileSourceAdd.TabIndex = 68
        Me.btPIPFileSourceAdd.Text = "Add"
        Me.btPIPFileSourceAdd.UseVisualStyleBackColor = true
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(276, 27)
        Me.button1.Margin = New System.Windows.Forms.Padding(2)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(22, 22)
        Me.button1.TabIndex = 67
        Me.button1.Text = "..."
        Me.button1.UseVisualStyleBackColor = true
        '
        'edPIPFileSoureFilename
        '
        Me.edPIPFileSoureFilename.Location = New System.Drawing.Point(11, 28)
        Me.edPIPFileSoureFilename.Margin = New System.Windows.Forms.Padding(2)
        Me.edPIPFileSoureFilename.Name = "edPIPFileSoureFilename"
        Me.edPIPFileSoureFilename.Size = New System.Drawing.Size(261, 20)
        Me.edPIPFileSoureFilename.TabIndex = 66
        '
        'label320
        '
        Me.label320.AutoSize = true
        Me.label320.Location = New System.Drawing.Point(9, 12)
        Me.label320.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label320.Name = "label320"
        Me.label320.Size = New System.Drawing.Size(52, 13)
        Me.label320.TabIndex = 65
        Me.label320.Text = "File name"
        '
        'tabPage77
        '
        Me.tabPage77.Controls.Add(Me.cbPIPResizeMode)
        Me.tabPage77.Controls.Add(Me.label317)
        Me.tabPage77.Controls.Add(Me.groupBox34)
        Me.tabPage77.Controls.Add(Me.groupBox33)
        Me.tabPage77.Controls.Add(Me.cbPIPDevices)
        Me.tabPage77.Controls.Add(Me.cbPIPMode)
        Me.tabPage77.Controls.Add(Me.label169)
        Me.tabPage77.Controls.Add(Me.btPIPDevicesClear)
        Me.tabPage77.Controls.Add(Me.label134)
        Me.tabPage77.Controls.Add(Me.groupBox20)
        Me.tabPage77.Location = New System.Drawing.Point(4, 22)
        Me.tabPage77.Name = "tabPage77"
        Me.tabPage77.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage77.Size = New System.Drawing.Size(442, 249)
        Me.tabPage77.TabIndex = 1
        Me.tabPage77.Text = "Configuration"
        Me.tabPage77.UseVisualStyleBackColor = true
        '
        'cbPIPResizeMode
        '
        Me.cbPIPResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPResizeMode.FormattingEnabled = true
        Me.cbPIPResizeMode.Items.AddRange(New Object() {"Nearest neighbor", "Linear", "Cubic", "Lanczos"})
        Me.cbPIPResizeMode.Location = New System.Drawing.Point(232, 200)
        Me.cbPIPResizeMode.Name = "cbPIPResizeMode"
        Me.cbPIPResizeMode.Size = New System.Drawing.Size(189, 21)
        Me.cbPIPResizeMode.TabIndex = 56
        '
        'label317
        '
        Me.label317.AutoSize = true
        Me.label317.Location = New System.Drawing.Point(229, 180)
        Me.label317.Name = "label317"
        Me.label317.Size = New System.Drawing.Size(62, 13)
        Me.label317.TabIndex = 55
        Me.label317.Text = "Resize type"
        '
        'groupBox34
        '
        Me.groupBox34.Controls.Add(Me.btPIPSet)
        Me.groupBox34.Controls.Add(Me.tbPIPTransparency)
        Me.groupBox34.Location = New System.Drawing.Point(18, 170)
        Me.groupBox34.Name = "groupBox34"
        Me.groupBox34.Size = New System.Drawing.Size(204, 73)
        Me.groupBox34.TabIndex = 52
        Me.groupBox34.TabStop = false
        Me.groupBox34.Text = "Source transparency"
        '
        'btPIPSet
        '
        Me.btPIPSet.Location = New System.Drawing.Point(150, 28)
        Me.btPIPSet.Name = "btPIPSet"
        Me.btPIPSet.Size = New System.Drawing.Size(48, 23)
        Me.btPIPSet.TabIndex = 1
        Me.btPIPSet.Text = "Set"
        Me.btPIPSet.UseVisualStyleBackColor = true
        '
        'tbPIPTransparency
        '
        Me.tbPIPTransparency.Location = New System.Drawing.Point(11, 19)
        Me.tbPIPTransparency.Maximum = 255
        Me.tbPIPTransparency.Name = "tbPIPTransparency"
        Me.tbPIPTransparency.Size = New System.Drawing.Size(123, 45)
        Me.tbPIPTransparency.TabIndex = 0
        Me.tbPIPTransparency.Value = 255
        '
        'groupBox33
        '
        Me.groupBox33.Controls.Add(Me.btPIPSetOutputSize)
        Me.groupBox33.Controls.Add(Me.edPIPOutputHeight)
        Me.groupBox33.Controls.Add(Me.label269)
        Me.groupBox33.Controls.Add(Me.edPIPOutputWidth)
        Me.groupBox33.Controls.Add(Me.label271)
        Me.groupBox33.Location = New System.Drawing.Point(232, 70)
        Me.groupBox33.Name = "groupBox33"
        Me.groupBox33.Size = New System.Drawing.Size(204, 100)
        Me.groupBox33.TabIndex = 51
        Me.groupBox33.TabStop = false
        Me.groupBox33.Text = "Set custom output size"
        '
        'btPIPSetOutputSize
        '
        Me.btPIPSetOutputSize.Location = New System.Drawing.Point(60, 71)
        Me.btPIPSetOutputSize.Name = "btPIPSetOutputSize"
        Me.btPIPSetOutputSize.Size = New System.Drawing.Size(74, 23)
        Me.btPIPSetOutputSize.TabIndex = 41
        Me.btPIPSetOutputSize.Text = "Set"
        Me.btPIPSetOutputSize.UseVisualStyleBackColor = true
        '
        'edPIPOutputHeight
        '
        Me.edPIPOutputHeight.Location = New System.Drawing.Point(150, 19)
        Me.edPIPOutputHeight.Name = "edPIPOutputHeight"
        Me.edPIPOutputHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPOutputHeight.TabIndex = 38
        Me.edPIPOutputHeight.Text = "600"
        Me.edPIPOutputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label269
        '
        Me.label269.AutoSize = true
        Me.label269.Location = New System.Drawing.Point(112, 22)
        Me.label269.Name = "label269"
        Me.label269.Size = New System.Drawing.Size(38, 13)
        Me.label269.TabIndex = 37
        Me.label269.Text = "Height"
        '
        'edPIPOutputWidth
        '
        Me.edPIPOutputWidth.Location = New System.Drawing.Point(48, 19)
        Me.edPIPOutputWidth.Name = "edPIPOutputWidth"
        Me.edPIPOutputWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPOutputWidth.TabIndex = 34
        Me.edPIPOutputWidth.Text = "800"
        Me.edPIPOutputWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label271
        '
        Me.label271.AutoSize = true
        Me.label271.Location = New System.Drawing.Point(15, 22)
        Me.label271.Name = "label271"
        Me.label271.Size = New System.Drawing.Size(35, 13)
        Me.label271.TabIndex = 33
        Me.label271.Text = "Width"
        '
        'cbPIPDevices
        '
        Me.cbPIPDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPDevices.FormattingEnabled = true
        Me.cbPIPDevices.Location = New System.Drawing.Point(66, 37)
        Me.cbPIPDevices.Name = "cbPIPDevices"
        Me.cbPIPDevices.Size = New System.Drawing.Size(245, 21)
        Me.cbPIPDevices.TabIndex = 50
        '
        'cbPIPMode
        '
        Me.cbPIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPIPMode.FormattingEnabled = true
        Me.cbPIPMode.Items.AddRange(New Object() {"Custom (Specify coordinates for each device)", "Horizontal", "Vertical", "2x2", "Multiple video streams (Use WMV, external profile for multiple video streams)", "Chroma-key"})
        Me.cbPIPMode.Location = New System.Drawing.Point(66, 6)
        Me.cbPIPMode.Name = "cbPIPMode"
        Me.cbPIPMode.Size = New System.Drawing.Size(370, 21)
        Me.cbPIPMode.TabIndex = 49
        '
        'label169
        '
        Me.label169.AutoSize = true
        Me.label169.Location = New System.Drawing.Point(8, 9)
        Me.label169.Name = "label169"
        Me.label169.Size = New System.Drawing.Size(34, 13)
        Me.label169.TabIndex = 48
        Me.label169.Text = "Mode"
        '
        'btPIPDevicesClear
        '
        Me.btPIPDevicesClear.Location = New System.Drawing.Point(317, 37)
        Me.btPIPDevicesClear.Name = "btPIPDevicesClear"
        Me.btPIPDevicesClear.Size = New System.Drawing.Size(59, 23)
        Me.btPIPDevicesClear.TabIndex = 46
        Me.btPIPDevicesClear.Text = "Clear"
        Me.btPIPDevicesClear.UseVisualStyleBackColor = true
        '
        'label134
        '
        Me.label134.AutoSize = true
        Me.label134.Location = New System.Drawing.Point(8, 40)
        Me.label134.Name = "label134"
        Me.label134.Size = New System.Drawing.Size(46, 13)
        Me.label134.TabIndex = 43
        Me.label134.Text = "Devices"
        '
        'groupBox20
        '
        Me.groupBox20.Controls.Add(Me.btPIPUpdate)
        Me.groupBox20.Controls.Add(Me.edPIPHeight)
        Me.groupBox20.Controls.Add(Me.label132)
        Me.groupBox20.Controls.Add(Me.edPIPWidth)
        Me.groupBox20.Controls.Add(Me.label133)
        Me.groupBox20.Controls.Add(Me.edPIPTop)
        Me.groupBox20.Controls.Add(Me.label130)
        Me.groupBox20.Controls.Add(Me.edPIPLeft)
        Me.groupBox20.Controls.Add(Me.label131)
        Me.groupBox20.Location = New System.Drawing.Point(18, 70)
        Me.groupBox20.Name = "groupBox20"
        Me.groupBox20.Size = New System.Drawing.Size(204, 100)
        Me.groupBox20.TabIndex = 42
        Me.groupBox20.TabStop = false
        Me.groupBox20.Text = "Position"
        '
        'btPIPUpdate
        '
        Me.btPIPUpdate.Location = New System.Drawing.Point(60, 71)
        Me.btPIPUpdate.Name = "btPIPUpdate"
        Me.btPIPUpdate.Size = New System.Drawing.Size(74, 23)
        Me.btPIPUpdate.TabIndex = 41
        Me.btPIPUpdate.Text = "Update"
        Me.btPIPUpdate.UseVisualStyleBackColor = true
        '
        'edPIPHeight
        '
        Me.edPIPHeight.Location = New System.Drawing.Point(150, 45)
        Me.edPIPHeight.Name = "edPIPHeight"
        Me.edPIPHeight.Size = New System.Drawing.Size(39, 20)
        Me.edPIPHeight.TabIndex = 40
        Me.edPIPHeight.Text = "200"
        Me.edPIPHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label132
        '
        Me.label132.AutoSize = true
        Me.label132.Location = New System.Drawing.Point(112, 48)
        Me.label132.Name = "label132"
        Me.label132.Size = New System.Drawing.Size(38, 13)
        Me.label132.TabIndex = 39
        Me.label132.Text = "Height"
        '
        'edPIPWidth
        '
        Me.edPIPWidth.Location = New System.Drawing.Point(150, 19)
        Me.edPIPWidth.Name = "edPIPWidth"
        Me.edPIPWidth.Size = New System.Drawing.Size(39, 20)
        Me.edPIPWidth.TabIndex = 38
        Me.edPIPWidth.Text = "300"
        Me.edPIPWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label133
        '
        Me.label133.AutoSize = true
        Me.label133.Location = New System.Drawing.Point(112, 22)
        Me.label133.Name = "label133"
        Me.label133.Size = New System.Drawing.Size(35, 13)
        Me.label133.TabIndex = 37
        Me.label133.Text = "Width"
        '
        'edPIPTop
        '
        Me.edPIPTop.Location = New System.Drawing.Point(48, 45)
        Me.edPIPTop.Name = "edPIPTop"
        Me.edPIPTop.Size = New System.Drawing.Size(39, 20)
        Me.edPIPTop.TabIndex = 36
        Me.edPIPTop.Text = "0"
        Me.edPIPTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label130
        '
        Me.label130.AutoSize = true
        Me.label130.Location = New System.Drawing.Point(15, 48)
        Me.label130.Name = "label130"
        Me.label130.Size = New System.Drawing.Size(26, 13)
        Me.label130.TabIndex = 35
        Me.label130.Text = "Top"
        '
        'edPIPLeft
        '
        Me.edPIPLeft.Location = New System.Drawing.Point(48, 19)
        Me.edPIPLeft.Name = "edPIPLeft"
        Me.edPIPLeft.Size = New System.Drawing.Size(39, 20)
        Me.edPIPLeft.TabIndex = 34
        Me.edPIPLeft.Text = "0"
        Me.edPIPLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label131
        '
        Me.label131.AutoSize = true
        Me.label131.Location = New System.Drawing.Point(15, 22)
        Me.label131.Name = "label131"
        Me.label131.Size = New System.Drawing.Size(25, 13)
        Me.label131.TabIndex = 33
        Me.label131.Text = "Left"
        '
        'TabPage113
        '
        Me.TabPage113.Controls.Add(Me.lbPIPChromaKeyTolerance2)
        Me.TabPage113.Controls.Add(Me.label518)
        Me.TabPage113.Controls.Add(Me.tbPIPChromaKeyTolerance2)
        Me.TabPage113.Controls.Add(Me.lbPIPChromaKeyTolerance1)
        Me.TabPage113.Controls.Add(Me.label515)
        Me.TabPage113.Controls.Add(Me.tbPIPChromaKeyTolerance1)
        Me.TabPage113.Controls.Add(Me.pnPIPChromaKeyColor)
        Me.TabPage113.Controls.Add(Me.label514)
        Me.TabPage113.Location = New System.Drawing.Point(4, 22)
        Me.TabPage113.Name = "TabPage113"
        Me.TabPage113.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage113.Size = New System.Drawing.Size(442, 249)
        Me.TabPage113.TabIndex = 2
        Me.TabPage113.Text = "Chroma-key"
        Me.TabPage113.UseVisualStyleBackColor = true
        '
        'lbPIPChromaKeyTolerance2
        '
        Me.lbPIPChromaKeyTolerance2.AutoSize = true
        Me.lbPIPChromaKeyTolerance2.Location = New System.Drawing.Point(378, 88)
        Me.lbPIPChromaKeyTolerance2.Name = "lbPIPChromaKeyTolerance2"
        Me.lbPIPChromaKeyTolerance2.Size = New System.Drawing.Size(19, 13)
        Me.lbPIPChromaKeyTolerance2.TabIndex = 43
        Me.lbPIPChromaKeyTolerance2.Text = "30"
        '
        'label518
        '
        Me.label518.AutoSize = true
        Me.label518.Location = New System.Drawing.Point(248, 57)
        Me.label518.Name = "label518"
        Me.label518.Size = New System.Drawing.Size(64, 13)
        Me.label518.TabIndex = 42
        Me.label518.Text = "Tolerance 2"
        '
        'tbPIPChromaKeyTolerance2
        '
        Me.tbPIPChromaKeyTolerance2.Location = New System.Drawing.Point(251, 73)
        Me.tbPIPChromaKeyTolerance2.Maximum = 100
        Me.tbPIPChromaKeyTolerance2.Minimum = 5
        Me.tbPIPChromaKeyTolerance2.Name = "tbPIPChromaKeyTolerance2"
        Me.tbPIPChromaKeyTolerance2.Size = New System.Drawing.Size(110, 45)
        Me.tbPIPChromaKeyTolerance2.TabIndex = 41
        Me.tbPIPChromaKeyTolerance2.TickFrequency = 3
        Me.tbPIPChromaKeyTolerance2.Value = 30
        '
        'lbPIPChromaKeyTolerance1
        '
        Me.lbPIPChromaKeyTolerance1.AutoSize = true
        Me.lbPIPChromaKeyTolerance1.Location = New System.Drawing.Point(145, 88)
        Me.lbPIPChromaKeyTolerance1.Name = "lbPIPChromaKeyTolerance1"
        Me.lbPIPChromaKeyTolerance1.Size = New System.Drawing.Size(19, 13)
        Me.lbPIPChromaKeyTolerance1.TabIndex = 40
        Me.lbPIPChromaKeyTolerance1.Text = "10"
        '
        'label515
        '
        Me.label515.AutoSize = true
        Me.label515.Location = New System.Drawing.Point(15, 57)
        Me.label515.Name = "label515"
        Me.label515.Size = New System.Drawing.Size(64, 13)
        Me.label515.TabIndex = 39
        Me.label515.Text = "Tolerance 1"
        '
        'tbPIPChromaKeyTolerance1
        '
        Me.tbPIPChromaKeyTolerance1.Location = New System.Drawing.Point(18, 73)
        Me.tbPIPChromaKeyTolerance1.Maximum = 100
        Me.tbPIPChromaKeyTolerance1.Minimum = 5
        Me.tbPIPChromaKeyTolerance1.Name = "tbPIPChromaKeyTolerance1"
        Me.tbPIPChromaKeyTolerance1.Size = New System.Drawing.Size(110, 45)
        Me.tbPIPChromaKeyTolerance1.TabIndex = 38
        Me.tbPIPChromaKeyTolerance1.TickFrequency = 3
        Me.tbPIPChromaKeyTolerance1.Value = 10
        '
        'pnPIPChromaKeyColor
        '
        Me.pnPIPChromaKeyColor.BackColor = System.Drawing.Color.ForestGreen
        Me.pnPIPChromaKeyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnPIPChromaKeyColor.Location = New System.Drawing.Point(148, 21)
        Me.pnPIPChromaKeyColor.Name = "pnPIPChromaKeyColor"
        Me.pnPIPChromaKeyColor.Size = New System.Drawing.Size(24, 24)
        Me.pnPIPChromaKeyColor.TabIndex = 37
        '
        'label514
        '
        Me.label514.AutoSize = true
        Me.label514.Location = New System.Drawing.Point(14, 24)
        Me.label514.Name = "label514"
        Me.label514.Size = New System.Drawing.Size(105, 13)
        Me.label514.TabIndex = 36
        Me.label514.Text = "Color (click to select)"
        '
        'tabPage50
        '
        Me.tabPage50.Controls.Add(Me.cbMultiscreenDrawOnExternalDisplays)
        Me.tabPage50.Controls.Add(Me.cbMultiscreenDrawOnPanels)
        Me.tabPage50.Controls.Add(Me.cbFlipHorizontal3)
        Me.tabPage50.Controls.Add(Me.cbFlipVertical3)
        Me.tabPage50.Controls.Add(Me.cbStretch3)
        Me.tabPage50.Controls.Add(Me.cbFlipHorizontal2)
        Me.tabPage50.Controls.Add(Me.cbFlipVertical2)
        Me.tabPage50.Controls.Add(Me.cbStretch2)
        Me.tabPage50.Controls.Add(Me.cbFlipHorizontal1)
        Me.tabPage50.Controls.Add(Me.cbFlipVertical1)
        Me.tabPage50.Controls.Add(Me.cbStretch1)
        Me.tabPage50.Controls.Add(Me.pnScreen3)
        Me.tabPage50.Controls.Add(Me.panel3)
        Me.tabPage50.Controls.Add(Me.pnScreen2)
        Me.tabPage50.Controls.Add(Me.panel2)
        Me.tabPage50.Controls.Add(Me.pnScreen1)
        Me.tabPage50.Location = New System.Drawing.Point(4, 22)
        Me.tabPage50.Name = "tabPage50"
        Me.tabPage50.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage50.Size = New System.Drawing.Size(459, 285)
        Me.tabPage50.TabIndex = 4
        Me.tabPage50.Text = "Multiscreen"
        Me.tabPage50.UseVisualStyleBackColor = true
        '
        'cbMultiscreenDrawOnExternalDisplays
        '
        Me.cbMultiscreenDrawOnExternalDisplays.AutoSize = true
        Me.cbMultiscreenDrawOnExternalDisplays.Location = New System.Drawing.Point(180, 17)
        Me.cbMultiscreenDrawOnExternalDisplays.Name = "cbMultiscreenDrawOnExternalDisplays"
        Me.cbMultiscreenDrawOnExternalDisplays.Size = New System.Drawing.Size(175, 17)
        Me.cbMultiscreenDrawOnExternalDisplays.TabIndex = 17
        Me.cbMultiscreenDrawOnExternalDisplays.Text = "Draw video on external displays"
        Me.cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = true
        '
        'cbMultiscreenDrawOnPanels
        '
        Me.cbMultiscreenDrawOnPanels.AutoSize = true
        Me.cbMultiscreenDrawOnPanels.Location = New System.Drawing.Point(18, 17)
        Me.cbMultiscreenDrawOnPanels.Name = "cbMultiscreenDrawOnPanels"
        Me.cbMultiscreenDrawOnPanels.Size = New System.Drawing.Size(129, 17)
        Me.cbMultiscreenDrawOnPanels.TabIndex = 16
        Me.cbMultiscreenDrawOnPanels.Text = "Draw video on panels"
        Me.cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = true
        '
        'cbFlipHorizontal3
        '
        Me.cbFlipHorizontal3.AutoSize = true
        Me.cbFlipHorizontal3.Location = New System.Drawing.Point(341, 107)
        Me.cbFlipHorizontal3.Name = "cbFlipHorizontal3"
        Me.cbFlipHorizontal3.Size = New System.Drawing.Size(90, 17)
        Me.cbFlipHorizontal3.TabIndex = 14
        Me.cbFlipHorizontal3.Text = "Flip horizontal"
        Me.cbFlipHorizontal3.UseVisualStyleBackColor = true
        '
        'cbFlipVertical3
        '
        Me.cbFlipVertical3.AutoSize = true
        Me.cbFlipVertical3.Location = New System.Drawing.Point(341, 84)
        Me.cbFlipVertical3.Name = "cbFlipVertical3"
        Me.cbFlipVertical3.Size = New System.Drawing.Size(79, 17)
        Me.cbFlipVertical3.TabIndex = 13
        Me.cbFlipVertical3.Text = "Flip vertical"
        Me.cbFlipVertical3.UseVisualStyleBackColor = true
        '
        'cbStretch3
        '
        Me.cbStretch3.AutoSize = true
        Me.cbStretch3.Location = New System.Drawing.Point(341, 61)
        Me.cbStretch3.Name = "cbStretch3"
        Me.cbStretch3.Size = New System.Drawing.Size(60, 17)
        Me.cbStretch3.TabIndex = 12
        Me.cbStretch3.Text = "Stretch"
        Me.cbStretch3.UseVisualStyleBackColor = true
        '
        'cbFlipHorizontal2
        '
        Me.cbFlipHorizontal2.AutoSize = true
        Me.cbFlipHorizontal2.Location = New System.Drawing.Point(224, 215)
        Me.cbFlipHorizontal2.Name = "cbFlipHorizontal2"
        Me.cbFlipHorizontal2.Size = New System.Drawing.Size(90, 17)
        Me.cbFlipHorizontal2.TabIndex = 11
        Me.cbFlipHorizontal2.Text = "Flip horizontal"
        Me.cbFlipHorizontal2.UseVisualStyleBackColor = true
        '
        'cbFlipVertical2
        '
        Me.cbFlipVertical2.AutoSize = true
        Me.cbFlipVertical2.Location = New System.Drawing.Point(224, 195)
        Me.cbFlipVertical2.Name = "cbFlipVertical2"
        Me.cbFlipVertical2.Size = New System.Drawing.Size(79, 17)
        Me.cbFlipVertical2.TabIndex = 10
        Me.cbFlipVertical2.Text = "Flip vertical"
        Me.cbFlipVertical2.UseVisualStyleBackColor = true
        '
        'cbStretch2
        '
        Me.cbStretch2.AutoSize = true
        Me.cbStretch2.Location = New System.Drawing.Point(147, 195)
        Me.cbStretch2.Name = "cbStretch2"
        Me.cbStretch2.Size = New System.Drawing.Size(60, 17)
        Me.cbStretch2.TabIndex = 9
        Me.cbStretch2.Text = "Stretch"
        Me.cbStretch2.UseVisualStyleBackColor = true
        '
        'cbFlipHorizontal1
        '
        Me.cbFlipHorizontal1.AutoSize = true
        Me.cbFlipHorizontal1.Location = New System.Drawing.Point(18, 192)
        Me.cbFlipHorizontal1.Name = "cbFlipHorizontal1"
        Me.cbFlipHorizontal1.Size = New System.Drawing.Size(90, 17)
        Me.cbFlipHorizontal1.TabIndex = 8
        Me.cbFlipHorizontal1.Text = "Flip horizontal"
        Me.cbFlipHorizontal1.UseVisualStyleBackColor = true
        '
        'cbFlipVertical1
        '
        Me.cbFlipVertical1.AutoSize = true
        Me.cbFlipVertical1.Location = New System.Drawing.Point(18, 169)
        Me.cbFlipVertical1.Name = "cbFlipVertical1"
        Me.cbFlipVertical1.Size = New System.Drawing.Size(79, 17)
        Me.cbFlipVertical1.TabIndex = 7
        Me.cbFlipVertical1.Text = "Flip vertical"
        Me.cbFlipVertical1.UseVisualStyleBackColor = true
        '
        'cbStretch1
        '
        Me.cbStretch1.AutoSize = true
        Me.cbStretch1.Location = New System.Drawing.Point(18, 146)
        Me.cbStretch1.Name = "cbStretch1"
        Me.cbStretch1.Size = New System.Drawing.Size(60, 17)
        Me.cbStretch1.TabIndex = 6
        Me.cbStretch1.Text = "Stretch"
        Me.cbStretch1.UseVisualStyleBackColor = true
        '
        'pnScreen3
        '
        Me.pnScreen3.BackColor = System.Drawing.Color.Black
        Me.pnScreen3.Location = New System.Drawing.Point(332, 132)
        Me.pnScreen3.Name = "pnScreen3"
        Me.pnScreen3.Size = New System.Drawing.Size(120, 100)
        Me.pnScreen3.TabIndex = 5
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.DimGray
        Me.panel3.Location = New System.Drawing.Point(326, 40)
        Me.panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(3, 196)
        Me.panel3.TabIndex = 4
        '
        'pnScreen2
        '
        Me.pnScreen2.BackColor = System.Drawing.Color.Black
        Me.pnScreen2.Location = New System.Drawing.Point(147, 40)
        Me.pnScreen2.Name = "pnScreen2"
        Me.pnScreen2.Size = New System.Drawing.Size(176, 149)
        Me.pnScreen2.TabIndex = 3
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.Gray
        Me.panel2.Location = New System.Drawing.Point(141, 40)
        Me.panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(3, 197)
        Me.panel2.TabIndex = 2
        '
        'pnScreen1
        '
        Me.pnScreen1.BackColor = System.Drawing.Color.Black
        Me.pnScreen1.Location = New System.Drawing.Point(18, 40)
        Me.pnScreen1.Name = "pnScreen1"
        Me.pnScreen1.Size = New System.Drawing.Size(120, 100)
        Me.pnScreen1.TabIndex = 1
        '
        'tabPage51
        '
        Me.tabPage51.Controls.Add(Me.tabControl26)
        Me.tabPage51.Location = New System.Drawing.Point(4, 22)
        Me.tabPage51.Name = "tabPage51"
        Me.tabPage51.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage51.Size = New System.Drawing.Size(459, 285)
        Me.tabPage51.TabIndex = 5
        Me.tabPage51.Text = "Display"
        Me.tabPage51.UseVisualStyleBackColor = true
        '
        'tabControl26
        '
        Me.tabControl26.Controls.Add(Me.tabPage115)
        Me.tabControl26.Controls.Add(Me.tabPage116)
        Me.tabControl26.Location = New System.Drawing.Point(3, 5)
        Me.tabControl26.Name = "tabControl26"
        Me.tabControl26.SelectedIndex = 0
        Me.tabControl26.Size = New System.Drawing.Size(452, 275)
        Me.tabControl26.TabIndex = 1
        '
        'tabPage115
        '
        Me.tabPage115.Controls.Add(Me.pnVideoRendererBGColor)
        Me.tabPage115.Controls.Add(Me.label394)
        Me.tabPage115.Controls.Add(Me.btFullScreen)
        Me.tabPage115.Controls.Add(Me.groupBox28)
        Me.tabPage115.Controls.Add(Me.cbScreenFlipVertical)
        Me.tabPage115.Controls.Add(Me.cbScreenFlipHorizontal)
        Me.tabPage115.Controls.Add(Me.cbStretch)
        Me.tabPage115.Controls.Add(Me.groupBox13)
        Me.tabPage115.Location = New System.Drawing.Point(4, 22)
        Me.tabPage115.Name = "tabPage115"
        Me.tabPage115.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage115.Size = New System.Drawing.Size(444, 249)
        Me.tabPage115.TabIndex = 0
        Me.tabPage115.Text = "Main"
        Me.tabPage115.UseVisualStyleBackColor = true
        '
        'pnVideoRendererBGColor
        '
        Me.pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black
        Me.pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnVideoRendererBGColor.Location = New System.Drawing.Point(120, 168)
        Me.pnVideoRendererBGColor.Name = "pnVideoRendererBGColor"
        Me.pnVideoRendererBGColor.Size = New System.Drawing.Size(24, 24)
        Me.pnVideoRendererBGColor.TabIndex = 28
        '
        'label394
        '
        Me.label394.AutoSize = true
        Me.label394.Location = New System.Drawing.Point(13, 173)
        Me.label394.Name = "label394"
        Me.label394.Size = New System.Drawing.Size(91, 13)
        Me.label394.TabIndex = 27
        Me.label394.Text = "Background color"
        '
        'btFullScreen
        '
        Me.btFullScreen.Location = New System.Drawing.Point(164, 168)
        Me.btFullScreen.Name = "btFullScreen"
        Me.btFullScreen.Size = New System.Drawing.Size(119, 23)
        Me.btFullScreen.TabIndex = 26
        Me.btFullScreen.Text = "Full screen"
        Me.btFullScreen.UseVisualStyleBackColor = true
        '
        'groupBox28
        '
        Me.groupBox28.Controls.Add(Me.btZoomReset)
        Me.groupBox28.Controls.Add(Me.btZoomShiftRight)
        Me.groupBox28.Controls.Add(Me.btZoomShiftLeft)
        Me.groupBox28.Controls.Add(Me.btZoomOut)
        Me.groupBox28.Controls.Add(Me.btZoomIn)
        Me.groupBox28.Controls.Add(Me.btZoomShiftDown)
        Me.groupBox28.Controls.Add(Me.btZoomShiftUp)
        Me.groupBox28.Location = New System.Drawing.Point(299, 99)
        Me.groupBox28.Name = "groupBox28"
        Me.groupBox28.Size = New System.Drawing.Size(119, 130)
        Me.groupBox28.TabIndex = 25
        Me.groupBox28.TabStop = false
        Me.groupBox28.Text = "Zoom"
        '
        'btZoomReset
        '
        Me.btZoomReset.Location = New System.Drawing.Point(34, 98)
        Me.btZoomReset.Name = "btZoomReset"
        Me.btZoomReset.Size = New System.Drawing.Size(51, 23)
        Me.btZoomReset.TabIndex = 7
        Me.btZoomReset.Text = "Reset"
        Me.btZoomReset.UseVisualStyleBackColor = true
        '
        'btZoomShiftRight
        '
        Me.btZoomShiftRight.Location = New System.Drawing.Point(85, 33)
        Me.btZoomShiftRight.Name = "btZoomShiftRight"
        Me.btZoomShiftRight.Size = New System.Drawing.Size(21, 48)
        Me.btZoomShiftRight.TabIndex = 5
        Me.btZoomShiftRight.Text = "R"
        Me.btZoomShiftRight.UseVisualStyleBackColor = true
        '
        'btZoomShiftLeft
        '
        Me.btZoomShiftLeft.Location = New System.Drawing.Point(13, 32)
        Me.btZoomShiftLeft.Name = "btZoomShiftLeft"
        Me.btZoomShiftLeft.Size = New System.Drawing.Size(21, 48)
        Me.btZoomShiftLeft.TabIndex = 4
        Me.btZoomShiftLeft.Text = "L"
        Me.btZoomShiftLeft.UseVisualStyleBackColor = true
        '
        'btZoomOut
        '
        Me.btZoomOut.Location = New System.Drawing.Point(61, 45)
        Me.btZoomOut.Name = "btZoomOut"
        Me.btZoomOut.Size = New System.Drawing.Size(23, 23)
        Me.btZoomOut.TabIndex = 3
        Me.btZoomOut.Text = "-"
        Me.btZoomOut.UseVisualStyleBackColor = true
        '
        'btZoomIn
        '
        Me.btZoomIn.Location = New System.Drawing.Point(35, 45)
        Me.btZoomIn.Name = "btZoomIn"
        Me.btZoomIn.Size = New System.Drawing.Size(22, 23)
        Me.btZoomIn.TabIndex = 2
        Me.btZoomIn.Text = "+"
        Me.btZoomIn.UseVisualStyleBackColor = true
        '
        'btZoomShiftDown
        '
        Me.btZoomShiftDown.Location = New System.Drawing.Point(34, 69)
        Me.btZoomShiftDown.Name = "btZoomShiftDown"
        Me.btZoomShiftDown.Size = New System.Drawing.Size(51, 23)
        Me.btZoomShiftDown.TabIndex = 1
        Me.btZoomShiftDown.Text = "Down"
        Me.btZoomShiftDown.UseVisualStyleBackColor = true
        '
        'btZoomShiftUp
        '
        Me.btZoomShiftUp.Location = New System.Drawing.Point(34, 20)
        Me.btZoomShiftUp.Name = "btZoomShiftUp"
        Me.btZoomShiftUp.Size = New System.Drawing.Size(51, 23)
        Me.btZoomShiftUp.TabIndex = 0
        Me.btZoomShiftUp.Text = "Up"
        Me.btZoomShiftUp.UseVisualStyleBackColor = true
        '
        'cbScreenFlipVertical
        '
        Me.cbScreenFlipVertical.AutoSize = true
        Me.cbScreenFlipVertical.Location = New System.Drawing.Point(299, 47)
        Me.cbScreenFlipVertical.Name = "cbScreenFlipVertical"
        Me.cbScreenFlipVertical.Size = New System.Drawing.Size(79, 17)
        Me.cbScreenFlipVertical.TabIndex = 18
        Me.cbScreenFlipVertical.Text = "Flip vertical"
        Me.cbScreenFlipVertical.UseVisualStyleBackColor = true
        '
        'cbScreenFlipHorizontal
        '
        Me.cbScreenFlipHorizontal.AutoSize = true
        Me.cbScreenFlipHorizontal.Location = New System.Drawing.Point(299, 70)
        Me.cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal"
        Me.cbScreenFlipHorizontal.Size = New System.Drawing.Size(90, 17)
        Me.cbScreenFlipHorizontal.TabIndex = 17
        Me.cbScreenFlipHorizontal.Text = "Flip horizontal"
        Me.cbScreenFlipHorizontal.UseVisualStyleBackColor = true
        '
        'cbStretch
        '
        Me.cbStretch.AutoSize = true
        Me.cbStretch.Location = New System.Drawing.Point(299, 22)
        Me.cbStretch.Name = "cbStretch"
        Me.cbStretch.Size = New System.Drawing.Size(89, 17)
        Me.cbStretch.TabIndex = 16
        Me.cbStretch.Text = "Stretch video"
        Me.cbStretch.UseVisualStyleBackColor = true
        '
        'groupBox13
        '
        Me.groupBox13.Controls.Add(Me.rbDirect2D)
        Me.groupBox13.Controls.Add(Me.rbNone)
        Me.groupBox13.Controls.Add(Me.rbEVR)
        Me.groupBox13.Controls.Add(Me.rbVMR9)
        Me.groupBox13.Controls.Add(Me.rbVR)
        Me.groupBox13.Location = New System.Drawing.Point(16, 16)
        Me.groupBox13.Name = "groupBox13"
        Me.groupBox13.Size = New System.Drawing.Size(267, 138)
        Me.groupBox13.TabIndex = 15
        Me.groupBox13.TabStop = false
        Me.groupBox13.Text = "Video Renderer"
        '
        'rbDirect2D
        '
        Me.rbDirect2D.AutoSize = true
        Me.rbDirect2D.Location = New System.Drawing.Point(12, 90)
        Me.rbDirect2D.Name = "rbDirect2D"
        Me.rbDirect2D.Size = New System.Drawing.Size(67, 17)
        Me.rbDirect2D.TabIndex = 4
        Me.rbDirect2D.TabStop = true
        Me.rbDirect2D.Text = "Direct2D"
        Me.rbDirect2D.UseVisualStyleBackColor = true
        '
        'rbNone
        '
        Me.rbNone.AutoSize = true
        Me.rbNone.Location = New System.Drawing.Point(12, 113)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(51, 17)
        Me.rbNone.TabIndex = 3
        Me.rbNone.TabStop = true
        Me.rbNone.Text = "None"
        Me.rbNone.UseVisualStyleBackColor = true
        '
        'rbEVR
        '
        Me.rbEVR.AutoSize = true
        Me.rbEVR.Location = New System.Drawing.Point(12, 67)
        Me.rbEVR.Name = "rbEVR"
        Me.rbEVR.Size = New System.Drawing.Size(227, 17)
        Me.rbEVR.TabIndex = 2
        Me.rbEVR.Text = "Enhanced Video Renderer (Vista and later)"
        Me.rbEVR.UseVisualStyleBackColor = true
        '
        'rbVMR9
        '
        Me.rbVMR9.AutoSize = true
        Me.rbVMR9.Checked = true
        Me.rbVMR9.Location = New System.Drawing.Point(12, 44)
        Me.rbVMR9.Name = "rbVMR9"
        Me.rbVMR9.Size = New System.Drawing.Size(182, 17)
        Me.rbVMR9.TabIndex = 1
        Me.rbVMR9.TabStop = true
        Me.rbVMR9.Text = "Video Mixing Renderer 9 (default)"
        Me.rbVMR9.UseVisualStyleBackColor = true
        '
        'rbVR
        '
        Me.rbVR.AutoSize = true
        Me.rbVR.Location = New System.Drawing.Point(12, 21)
        Me.rbVR.Name = "rbVR"
        Me.rbVR.Size = New System.Drawing.Size(147, 17)
        Me.rbVR.TabIndex = 0
        Me.rbVR.Text = "Video Renderer Filter (old)"
        Me.rbVR.UseVisualStyleBackColor = true
        '
        'tabPage116
        '
        Me.tabPage116.Controls.Add(Me.label393)
        Me.tabPage116.Controls.Add(Me.cbDirect2DRotate)
        Me.tabPage116.Location = New System.Drawing.Point(4, 22)
        Me.tabPage116.Name = "tabPage116"
        Me.tabPage116.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage116.Size = New System.Drawing.Size(444, 249)
        Me.tabPage116.TabIndex = 1
        Me.tabPage116.Text = "Advanced"
        Me.tabPage116.UseVisualStyleBackColor = true
        '
        'label393
        '
        Me.label393.AutoSize = true
        Me.label393.Location = New System.Drawing.Point(16, 16)
        Me.label393.Name = "label393"
        Me.label393.Size = New System.Drawing.Size(79, 13)
        Me.label393.TabIndex = 26
        Me.label393.Text = "Direct2D rotate"
        '
        'cbDirect2DRotate
        '
        Me.cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDirect2DRotate.FormattingEnabled = true
        Me.cbDirect2DRotate.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.cbDirect2DRotate.Location = New System.Drawing.Point(19, 32)
        Me.cbDirect2DRotate.Name = "cbDirect2DRotate"
        Me.cbDirect2DRotate.Size = New System.Drawing.Size(130, 21)
        Me.cbDirect2DRotate.TabIndex = 25
        '
        'TabPage23
        '
        Me.TabPage23.Controls.Add(Me.label376)
        Me.TabPage23.Controls.Add(Me.edSeparateCaptureFileSize)
        Me.TabPage23.Controls.Add(Me.label375)
        Me.TabPage23.Controls.Add(Me.label374)
        Me.TabPage23.Controls.Add(Me.edSeparateCaptureDuration)
        Me.TabPage23.Controls.Add(Me.label373)
        Me.TabPage23.Controls.Add(Me.rbSeparateCaptureSplitBySize)
        Me.TabPage23.Controls.Add(Me.rbSeparateCaptureSplitByDuration)
        Me.TabPage23.Controls.Add(Me.rbSeparateCaptureStartManually)
        Me.TabPage23.Controls.Add(Me.btSeparateCaptureResume)
        Me.TabPage23.Controls.Add(Me.btSeparateCapturePause)
        Me.TabPage23.Controls.Add(Me.groupBox8)
        Me.TabPage23.Controls.Add(Me.btSeparateCaptureStop)
        Me.TabPage23.Controls.Add(Me.btSeparateCaptureStart)
        Me.TabPage23.Controls.Add(Me.cbSeparateCaptureEnabled)
        Me.TabPage23.Controls.Add(Me.label83)
        Me.TabPage23.Controls.Add(Me.label82)
        Me.TabPage23.Location = New System.Drawing.Point(4, 22)
        Me.TabPage23.Name = "TabPage23"
        Me.TabPage23.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage23.Size = New System.Drawing.Size(459, 285)
        Me.TabPage23.TabIndex = 6
        Me.TabPage23.Text = "Separate capture"
        Me.TabPage23.UseVisualStyleBackColor = true
        '
        'label376
        '
        Me.label376.AutoSize = true
        Me.label376.Location = New System.Drawing.Point(369, 248)
        Me.label376.Name = "label376"
        Me.label376.Size = New System.Drawing.Size(23, 13)
        Me.label376.TabIndex = 35
        Me.label376.Text = "MB"
        '
        'edSeparateCaptureFileSize
        '
        Me.edSeparateCaptureFileSize.Location = New System.Drawing.Point(310, 244)
        Me.edSeparateCaptureFileSize.Name = "edSeparateCaptureFileSize"
        Me.edSeparateCaptureFileSize.Size = New System.Drawing.Size(53, 20)
        Me.edSeparateCaptureFileSize.TabIndex = 34
        Me.edSeparateCaptureFileSize.Text = "50"
        '
        'label375
        '
        Me.label375.AutoSize = true
        Me.label375.Location = New System.Drawing.Point(237, 247)
        Me.label375.Name = "label375"
        Me.label375.Size = New System.Drawing.Size(44, 13)
        Me.label375.TabIndex = 33
        Me.label375.Text = "File size"
        '
        'label374
        '
        Me.label374.AutoSize = true
        Me.label374.Location = New System.Drawing.Point(166, 248)
        Me.label374.Name = "label374"
        Me.label374.Size = New System.Drawing.Size(20, 13)
        Me.label374.TabIndex = 32
        Me.label374.Text = "ms"
        '
        'edSeparateCaptureDuration
        '
        Me.edSeparateCaptureDuration.Location = New System.Drawing.Point(107, 245)
        Me.edSeparateCaptureDuration.Name = "edSeparateCaptureDuration"
        Me.edSeparateCaptureDuration.Size = New System.Drawing.Size(53, 20)
        Me.edSeparateCaptureDuration.TabIndex = 31
        Me.edSeparateCaptureDuration.Text = "20000"
        '
        'label373
        '
        Me.label373.AutoSize = true
        Me.label373.Location = New System.Drawing.Point(34, 248)
        Me.label373.Name = "label373"
        Me.label373.Size = New System.Drawing.Size(47, 13)
        Me.label373.TabIndex = 30
        Me.label373.Text = "Duration"
        '
        'rbSeparateCaptureSplitBySize
        '
        Me.rbSeparateCaptureSplitBySize.AutoSize = true
        Me.rbSeparateCaptureSplitBySize.Location = New System.Drawing.Point(220, 223)
        Me.rbSeparateCaptureSplitBySize.Name = "rbSeparateCaptureSplitBySize"
        Me.rbSeparateCaptureSplitBySize.Size = New System.Drawing.Size(96, 17)
        Me.rbSeparateCaptureSplitBySize.TabIndex = 29
        Me.rbSeparateCaptureSplitBySize.Text = "Split by file size"
        Me.rbSeparateCaptureSplitBySize.UseVisualStyleBackColor = true
        '
        'rbSeparateCaptureSplitByDuration
        '
        Me.rbSeparateCaptureSplitByDuration.AutoSize = true
        Me.rbSeparateCaptureSplitByDuration.Location = New System.Drawing.Point(17, 223)
        Me.rbSeparateCaptureSplitByDuration.Name = "rbSeparateCaptureSplitByDuration"
        Me.rbSeparateCaptureSplitByDuration.Size = New System.Drawing.Size(100, 17)
        Me.rbSeparateCaptureSplitByDuration.TabIndex = 28
        Me.rbSeparateCaptureSplitByDuration.Text = "Split by duration"
        Me.rbSeparateCaptureSplitByDuration.UseVisualStyleBackColor = true
        '
        'rbSeparateCaptureStartManually
        '
        Me.rbSeparateCaptureStartManually.AutoSize = true
        Me.rbSeparateCaptureStartManually.Checked = true
        Me.rbSeparateCaptureStartManually.Location = New System.Drawing.Point(17, 92)
        Me.rbSeparateCaptureStartManually.Name = "rbSeparateCaptureStartManually"
        Me.rbSeparateCaptureStartManually.Size = New System.Drawing.Size(91, 17)
        Me.rbSeparateCaptureStartManually.TabIndex = 27
        Me.rbSeparateCaptureStartManually.TabStop = true
        Me.rbSeparateCaptureStartManually.Text = "Start manually"
        Me.rbSeparateCaptureStartManually.UseVisualStyleBackColor = true
        '
        'btSeparateCaptureResume
        '
        Me.btSeparateCaptureResume.Location = New System.Drawing.Point(236, 116)
        Me.btSeparateCaptureResume.Name = "btSeparateCaptureResume"
        Me.btSeparateCaptureResume.Size = New System.Drawing.Size(95, 23)
        Me.btSeparateCaptureResume.TabIndex = 26
        Me.btSeparateCaptureResume.Text = "Resume capture"
        Me.btSeparateCaptureResume.UseVisualStyleBackColor = true
        '
        'btSeparateCapturePause
        '
        Me.btSeparateCapturePause.Location = New System.Drawing.Point(135, 116)
        Me.btSeparateCapturePause.Name = "btSeparateCapturePause"
        Me.btSeparateCapturePause.Size = New System.Drawing.Size(95, 23)
        Me.btSeparateCapturePause.TabIndex = 25
        Me.btSeparateCapturePause.Text = "Pause capture"
        Me.btSeparateCapturePause.UseVisualStyleBackColor = true
        '
        'groupBox8
        '
        Me.groupBox8.Controls.Add(Me.btSeparateCaptureChangeFilename)
        Me.groupBox8.Controls.Add(Me.edNewFilename)
        Me.groupBox8.Controls.Add(Me.label84)
        Me.groupBox8.Location = New System.Drawing.Point(37, 145)
        Me.groupBox8.Name = "groupBox8"
        Me.groupBox8.Size = New System.Drawing.Size(392, 55)
        Me.groupBox8.TabIndex = 24
        Me.groupBox8.TabStop = false
        Me.groupBox8.Text = "Change file name on the fly"
        '
        'btSeparateCaptureChangeFilename
        '
        Me.btSeparateCaptureChangeFilename.Location = New System.Drawing.Point(326, 20)
        Me.btSeparateCaptureChangeFilename.Name = "btSeparateCaptureChangeFilename"
        Me.btSeparateCaptureChangeFilename.Size = New System.Drawing.Size(60, 23)
        Me.btSeparateCaptureChangeFilename.TabIndex = 9
        Me.btSeparateCaptureChangeFilename.Text = "Change"
        Me.btSeparateCaptureChangeFilename.UseVisualStyleBackColor = true
        '
        'edNewFilename
        '
        Me.edNewFilename.Location = New System.Drawing.Point(98, 22)
        Me.edNewFilename.Name = "edNewFilename"
        Me.edNewFilename.Size = New System.Drawing.Size(224, 20)
        Me.edNewFilename.TabIndex = 8
        '
        'label84
        '
        Me.label84.AutoSize = true
        Me.label84.Location = New System.Drawing.Point(18, 24)
        Me.label84.Name = "label84"
        Me.label84.Size = New System.Drawing.Size(74, 13)
        Me.label84.TabIndex = 7
        Me.label84.Text = "New file name"
        '
        'btSeparateCaptureStop
        '
        Me.btSeparateCaptureStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btSeparateCaptureStop.Location = New System.Drawing.Point(337, 116)
        Me.btSeparateCaptureStop.Name = "btSeparateCaptureStop"
        Me.btSeparateCaptureStop.Size = New System.Drawing.Size(92, 23)
        Me.btSeparateCaptureStop.TabIndex = 23
        Me.btSeparateCaptureStop.Text = "Stop capture"
        Me.btSeparateCaptureStop.UseVisualStyleBackColor = true
        '
        'btSeparateCaptureStart
        '
        Me.btSeparateCaptureStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btSeparateCaptureStart.Location = New System.Drawing.Point(37, 116)
        Me.btSeparateCaptureStart.Name = "btSeparateCaptureStart"
        Me.btSeparateCaptureStart.Size = New System.Drawing.Size(92, 23)
        Me.btSeparateCaptureStart.TabIndex = 22
        Me.btSeparateCaptureStart.Text = "Start capture"
        Me.btSeparateCaptureStart.UseVisualStyleBackColor = true
        '
        'cbSeparateCaptureEnabled
        '
        Me.cbSeparateCaptureEnabled.AutoSize = true
        Me.cbSeparateCaptureEnabled.Location = New System.Drawing.Point(17, 58)
        Me.cbSeparateCaptureEnabled.Name = "cbSeparateCaptureEnabled"
        Me.cbSeparateCaptureEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbSeparateCaptureEnabled.TabIndex = 21
        Me.cbSeparateCaptureEnabled.Text = "Enabled"
        Me.cbSeparateCaptureEnabled.UseVisualStyleBackColor = true
        '
        'label83
        '
        Me.label83.AutoSize = true
        Me.label83.Location = New System.Drawing.Point(14, 37)
        Me.label83.Name = "label83"
        Me.label83.Size = New System.Drawing.Size(302, 13)
        Me.label83.TabIndex = 20
        Me.label83.Text = "from preview. You must enable it before you press Start button."
        '
        'label82
        '
        Me.label82.AutoSize = true
        Me.label82.Location = New System.Drawing.Point(14, 19)
        Me.label82.Name = "label82"
        Me.label82.Size = New System.Drawing.Size(430, 13)
        Me.label82.TabIndex = 19
        Me.label82.Text = """Separate capture"" option allows you to start and stop video/audio capture indepe"& _ 
    "ndently"
        '
        'TabPage123
        '
        Me.TabPage123.Controls.Add(Me.tabControl28)
        Me.TabPage123.Location = New System.Drawing.Point(4, 22)
        Me.TabPage123.Name = "TabPage123"
        Me.TabPage123.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage123.Size = New System.Drawing.Size(459, 285)
        Me.TabPage123.TabIndex = 9
        Me.TabPage123.Text = "Custom source"
        Me.TabPage123.UseVisualStyleBackColor = true
        '
        'tabControl28
        '
        Me.tabControl28.Controls.Add(Me.tabPage125)
        Me.tabControl28.Controls.Add(Me.tabPage126)
        Me.tabControl28.Location = New System.Drawing.Point(4, 6)
        Me.tabControl28.Name = "tabControl28"
        Me.tabControl28.SelectedIndex = 0
        Me.tabControl28.Size = New System.Drawing.Size(450, 273)
        Me.tabControl28.TabIndex = 7
        '
        'tabPage125
        '
        Me.tabPage125.Controls.Add(Me.edCustomVideoSourceURL)
        Me.tabPage125.Controls.Add(Me.label516)
        Me.tabPage125.Controls.Add(Me.cbCustomVideoSourceFrameRate)
        Me.tabPage125.Controls.Add(Me.label438)
        Me.tabPage125.Controls.Add(Me.label435)
        Me.tabPage125.Controls.Add(Me.cbCustomVideoSourceFormat)
        Me.tabPage125.Controls.Add(Me.label434)
        Me.tabPage125.Controls.Add(Me.cbCustomVideoSourceFilter)
        Me.tabPage125.Controls.Add(Me.cbCustomVideoSourceCategory)
        Me.tabPage125.Controls.Add(Me.label432)
        Me.tabPage125.Location = New System.Drawing.Point(4, 22)
        Me.tabPage125.Name = "tabPage125"
        Me.tabPage125.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage125.Size = New System.Drawing.Size(442, 247)
        Me.tabPage125.TabIndex = 0
        Me.tabPage125.Text = "Video source"
        Me.tabPage125.UseVisualStyleBackColor = true
        '
        'edCustomVideoSourceURL
        '
        Me.edCustomVideoSourceURL.Location = New System.Drawing.Point(14, 131)
        Me.edCustomVideoSourceURL.Name = "edCustomVideoSourceURL"
        Me.edCustomVideoSourceURL.Size = New System.Drawing.Size(414, 20)
        Me.edCustomVideoSourceURL.TabIndex = 16
        '
        'label516
        '
        Me.label516.AutoSize = true
        Me.label516.Location = New System.Drawing.Point(11, 114)
        Me.label516.Name = "label516"
        Me.label516.Size = New System.Drawing.Size(189, 13)
        Me.label516.TabIndex = 15
        Me.label516.Text = "File name or URL (if supported by filter)"
        '
        'cbCustomVideoSourceFrameRate
        '
        Me.cbCustomVideoSourceFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomVideoSourceFrameRate.FormattingEnabled = true
        Me.cbCustomVideoSourceFrameRate.Location = New System.Drawing.Point(343, 81)
        Me.cbCustomVideoSourceFrameRate.Name = "cbCustomVideoSourceFrameRate"
        Me.cbCustomVideoSourceFrameRate.Size = New System.Drawing.Size(85, 21)
        Me.cbCustomVideoSourceFrameRate.TabIndex = 12
        '
        'label438
        '
        Me.label438.AutoSize = true
        Me.label438.Location = New System.Drawing.Point(340, 64)
        Me.label438.Name = "label438"
        Me.label438.Size = New System.Drawing.Size(57, 13)
        Me.label438.TabIndex = 11
        Me.label438.Text = "Frame rate"
        '
        'label435
        '
        Me.label435.AutoSize = true
        Me.label435.Location = New System.Drawing.Point(11, 14)
        Me.label435.Name = "label435"
        Me.label435.Size = New System.Drawing.Size(49, 13)
        Me.label435.TabIndex = 10
        Me.label435.Text = "Category"
        '
        'cbCustomVideoSourceFormat
        '
        Me.cbCustomVideoSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomVideoSourceFormat.FormattingEnabled = true
        Me.cbCustomVideoSourceFormat.Location = New System.Drawing.Point(14, 81)
        Me.cbCustomVideoSourceFormat.Name = "cbCustomVideoSourceFormat"
        Me.cbCustomVideoSourceFormat.Size = New System.Drawing.Size(323, 21)
        Me.cbCustomVideoSourceFormat.TabIndex = 9
        '
        'label434
        '
        Me.label434.AutoSize = true
        Me.label434.Location = New System.Drawing.Point(11, 64)
        Me.label434.Name = "label434"
        Me.label434.Size = New System.Drawing.Size(39, 13)
        Me.label434.TabIndex = 8
        Me.label434.Text = "Format"
        '
        'cbCustomVideoSourceFilter
        '
        Me.cbCustomVideoSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomVideoSourceFilter.FormattingEnabled = true
        Me.cbCustomVideoSourceFilter.Location = New System.Drawing.Point(165, 30)
        Me.cbCustomVideoSourceFilter.Name = "cbCustomVideoSourceFilter"
        Me.cbCustomVideoSourceFilter.Size = New System.Drawing.Size(263, 21)
        Me.cbCustomVideoSourceFilter.TabIndex = 7
        '
        'cbCustomVideoSourceCategory
        '
        Me.cbCustomVideoSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomVideoSourceCategory.FormattingEnabled = true
        Me.cbCustomVideoSourceCategory.Items.AddRange(New Object() {"Video capture source", "DirectShow filter"})
        Me.cbCustomVideoSourceCategory.Location = New System.Drawing.Point(14, 30)
        Me.cbCustomVideoSourceCategory.Name = "cbCustomVideoSourceCategory"
        Me.cbCustomVideoSourceCategory.Size = New System.Drawing.Size(133, 21)
        Me.cbCustomVideoSourceCategory.TabIndex = 6
        '
        'label432
        '
        Me.label432.AutoSize = true
        Me.label432.Location = New System.Drawing.Point(162, 14)
        Me.label432.Name = "label432"
        Me.label432.Size = New System.Drawing.Size(35, 13)
        Me.label432.TabIndex = 5
        Me.label432.Text = "Name"
        '
        'tabPage126
        '
        Me.tabPage126.Controls.Add(Me.edCustomAudioSourceURL)
        Me.tabPage126.Controls.Add(Me.label517)
        Me.tabPage126.Controls.Add(Me.label437)
        Me.tabPage126.Controls.Add(Me.cbCustomAudioSourceFormat)
        Me.tabPage126.Controls.Add(Me.label436)
        Me.tabPage126.Controls.Add(Me.cbCustomAudioSourceFilter)
        Me.tabPage126.Controls.Add(Me.label433)
        Me.tabPage126.Controls.Add(Me.cbCustomAudioSourceCategory)
        Me.tabPage126.Location = New System.Drawing.Point(4, 22)
        Me.tabPage126.Name = "tabPage126"
        Me.tabPage126.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage126.Size = New System.Drawing.Size(442, 247)
        Me.tabPage126.TabIndex = 1
        Me.tabPage126.Text = "Audio source"
        Me.tabPage126.UseVisualStyleBackColor = true
        '
        'edCustomAudioSourceURL
        '
        Me.edCustomAudioSourceURL.Location = New System.Drawing.Point(14, 131)
        Me.edCustomAudioSourceURL.Name = "edCustomAudioSourceURL"
        Me.edCustomAudioSourceURL.Size = New System.Drawing.Size(414, 20)
        Me.edCustomAudioSourceURL.TabIndex = 18
        '
        'label517
        '
        Me.label517.AutoSize = true
        Me.label517.Location = New System.Drawing.Point(11, 114)
        Me.label517.Name = "label517"
        Me.label517.Size = New System.Drawing.Size(189, 13)
        Me.label517.TabIndex = 17
        Me.label517.Text = "File name or URL (if supported by filter)"
        '
        'label437
        '
        Me.label437.AutoSize = true
        Me.label437.Location = New System.Drawing.Point(11, 14)
        Me.label437.Name = "label437"
        Me.label437.Size = New System.Drawing.Size(49, 13)
        Me.label437.TabIndex = 12
        Me.label437.Text = "Category"
        '
        'cbCustomAudioSourceFormat
        '
        Me.cbCustomAudioSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomAudioSourceFormat.FormattingEnabled = true
        Me.cbCustomAudioSourceFormat.Location = New System.Drawing.Point(14, 79)
        Me.cbCustomAudioSourceFormat.Name = "cbCustomAudioSourceFormat"
        Me.cbCustomAudioSourceFormat.Size = New System.Drawing.Size(414, 21)
        Me.cbCustomAudioSourceFormat.TabIndex = 11
        '
        'label436
        '
        Me.label436.AutoSize = true
        Me.label436.Location = New System.Drawing.Point(11, 62)
        Me.label436.Name = "label436"
        Me.label436.Size = New System.Drawing.Size(39, 13)
        Me.label436.TabIndex = 10
        Me.label436.Text = "Format"
        '
        'cbCustomAudioSourceFilter
        '
        Me.cbCustomAudioSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomAudioSourceFilter.FormattingEnabled = true
        Me.cbCustomAudioSourceFilter.Location = New System.Drawing.Point(165, 30)
        Me.cbCustomAudioSourceFilter.Name = "cbCustomAudioSourceFilter"
        Me.cbCustomAudioSourceFilter.Size = New System.Drawing.Size(263, 21)
        Me.cbCustomAudioSourceFilter.TabIndex = 8
        '
        'label433
        '
        Me.label433.AutoSize = true
        Me.label433.Location = New System.Drawing.Point(162, 14)
        Me.label433.Name = "label433"
        Me.label433.Size = New System.Drawing.Size(35, 13)
        Me.label433.TabIndex = 7
        Me.label433.Text = "Name"
        '
        'cbCustomAudioSourceCategory
        '
        Me.cbCustomAudioSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomAudioSourceCategory.FormattingEnabled = true
        Me.cbCustomAudioSourceCategory.Items.AddRange(New Object() {"Audio capture source", "DirectShow filter"})
        Me.cbCustomAudioSourceCategory.Location = New System.Drawing.Point(14, 30)
        Me.cbCustomAudioSourceCategory.Name = "cbCustomAudioSourceCategory"
        Me.cbCustomAudioSourceCategory.Size = New System.Drawing.Size(133, 21)
        Me.cbCustomAudioSourceCategory.TabIndex = 6
        '
        'btResume
        '
        Me.btResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btResume.Location = New System.Drawing.Point(594, 682)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(55, 23)
        Me.btResume.TabIndex = 84
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = true
        '
        'btPause
        '
        Me.btPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btPause.Location = New System.Drawing.Point(533, 682)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(55, 23)
        Me.btPause.TabIndex = 83
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = true
        '
        'cbMode
        '
        Me.cbMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMode.FormattingEnabled = true
        Me.cbMode.Items.AddRange(New Object() {"Video Preview", "Video Capture", "Audio Preview", "Audio Capture", "Screen Preview", "Screen Capture", "IP Preview", "IP Capture", "DVB-x Preview", "DVB-x Capture", "Custom Source Preview", "Custom Source Capture", "DeckLink Source Preview", "DeckLink Source Capture"})
        Me.cbMode.Location = New System.Drawing.Point(376, 684)
        Me.cbMode.Name = "cbMode"
        Me.cbMode.Size = New System.Drawing.Size(151, 21)
        Me.cbMode.TabIndex = 82
        '
        'label8
        '
        Me.label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label8.AutoSize = true
        Me.label8.Location = New System.Drawing.Point(334, 687)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(34, 13)
        Me.label8.TabIndex = 81
        Me.label8.Text = "Mode"
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btStop.Location = New System.Drawing.Point(734, 682)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(62, 23)
        Me.btStop.TabIndex = 80
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = true
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btStart.Location = New System.Drawing.Point(669, 682)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(62, 23)
        Me.btStart.TabIndex = 79
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = true
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage27)
        Me.tabControl1.Controls.Add(Me.TabPage124)
        Me.tabControl1.Controls.Add(Me.TabPage22)
        Me.tabControl1.Controls.Add(Me.tabPage7)
        Me.tabControl1.Controls.Add(Me.tabPage28)
        Me.tabControl1.Controls.Add(Me.tabPage43)
        Me.tabControl1.Controls.Add(Me.TabPage26)
        Me.tabControl1.Controls.Add(Me.TabPage25)
        Me.tabControl1.Controls.Add(Me.TabPage100)
        Me.tabControl1.Controls.Add(Me.TabPage102)
        Me.tabControl1.Controls.Add(Me.TabPage105)
        Me.tabControl1.Controls.Add(Me.TabPage106)
        Me.tabControl1.Controls.Add(Me.TabPage141)
        Me.tabControl1.Location = New System.Drawing.Point(9, 7)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(315, 510)
        Me.tabControl1.TabIndex = 78
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.lbInfo)
        Me.tabPage1.Controls.Add(Me.btOutputConfigure)
        Me.tabPage1.Controls.Add(Me.cbOutputFormat)
        Me.tabPage1.Controls.Add(Me.btSelectOutput)
        Me.tabPage1.Controls.Add(Me.edOutput)
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.cbRecordAudio)
        Me.tabPage1.Controls.Add(Me.label7)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(307, 484)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Capture"
        Me.tabPage1.UseVisualStyleBackColor = true
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = true
        Me.lbInfo.Location = New System.Drawing.Point(16, 61)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(267, 13)
        Me.lbInfo.TabIndex = 52
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btOutputConfigure
        '
        Me.btOutputConfigure.Location = New System.Drawing.Point(19, 84)
        Me.btOutputConfigure.Name = "btOutputConfigure"
        Me.btOutputConfigure.Size = New System.Drawing.Size(75, 23)
        Me.btOutputConfigure.TabIndex = 46
        Me.btOutputConfigure.Text = "Configure"
        Me.btOutputConfigure.UseVisualStyleBackColor = true
        '
        'cbOutputFormat
        '
        Me.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputFormat.FormattingEnabled = true
        Me.cbOutputFormat.Items.AddRange(New Object() {"AVI", "MKV (Matroska)", "WMV (Windows Media Video)", "DV", "PCM/ACM", "MP3 (Lame)", "M4A (AAC)", "WMA (Windows Media Audio)", "FLAC", "Ogg Vorbis", "Speex", "Custom", "DirectCapture DV (DV devices only)", "DirectCapture AVI (some specific devices)", "DirectCapture MPEG (MPEG 1/2/4 devices only)", "DirectCapture MKV (IP cameras / H264 devices)", "DirectCapture MP4 GDCL Mux (IP cameras / H264 devices)", "DirectCapture MP4 Monogram Mux (IP cameras / H264 devices)", "DirectCapture Custom (IP Cameras / H264 devices)", "WebM", "FFMPEG (DLL)", "FFMPEG (external exe)", "MP4 v8/v10", "MP4 v11", "Animated GIF", "Encrypted video", "MPEG-TS", "MOV"})
        Me.cbOutputFormat.Location = New System.Drawing.Point(19, 33)
        Me.cbOutputFormat.Name = "cbOutputFormat"
        Me.cbOutputFormat.Size = New System.Drawing.Size(275, 21)
        Me.cbOutputFormat.TabIndex = 45
        '
        'btSelectOutput
        '
        Me.btSelectOutput.Location = New System.Drawing.Point(270, 176)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(24, 23)
        Me.btSelectOutput.TabIndex = 41
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = true
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(19, 178)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(245, 20)
        Me.edOutput.TabIndex = 40
        Me.edOutput.Text = "c:\capture.avi"
        '
        'label9
        '
        Me.label9.AutoSize = true
        Me.label9.Location = New System.Drawing.Point(16, 162)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(52, 13)
        Me.label9.TabIndex = 39
        Me.label9.Text = "File name"
        '
        'cbRecordAudio
        '
        Me.cbRecordAudio.AutoSize = true
        Me.cbRecordAudio.Location = New System.Drawing.Point(19, 125)
        Me.cbRecordAudio.Name = "cbRecordAudio"
        Me.cbRecordAudio.Size = New System.Drawing.Size(90, 17)
        Me.cbRecordAudio.TabIndex = 7
        Me.cbRecordAudio.Text = "Record audio"
        Me.cbRecordAudio.UseVisualStyleBackColor = true
        '
        'label7
        '
        Me.label7.AutoSize = true
        Me.label7.Location = New System.Drawing.Point(16, 16)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(39, 13)
        Me.label7.TabIndex = 2
        Me.label7.Text = "Format"
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.tabControl17)
        Me.tabPage2.Controls.Add(Me.tabControl14)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(307, 484)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Video processing"
        Me.tabPage2.UseVisualStyleBackColor = true
        '
        'tabControl17
        '
        Me.tabControl17.Controls.Add(Me.tabPage68)
        Me.tabControl17.Controls.Add(Me.tabPage69)
        Me.tabControl17.Controls.Add(Me.TabPage59)
        Me.tabControl17.Controls.Add(Me.TabPage63)
        Me.tabControl17.Controls.Add(Me.TabPage92)
        Me.tabControl17.Controls.Add(Me.TabPage60)
        Me.tabControl17.Controls.Add(Me.tabPage70)
        Me.tabControl17.Location = New System.Drawing.Point(6, 3)
        Me.tabControl17.Name = "tabControl17"
        Me.tabControl17.SelectedIndex = 0
        Me.tabControl17.Size = New System.Drawing.Size(298, 485)
        Me.tabControl17.TabIndex = 36
        '
        'tabPage68
        '
        Me.tabPage68.Controls.Add(Me.cbFlipY)
        Me.tabPage68.Controls.Add(Me.cbFlipX)
        Me.tabPage68.Controls.Add(Me.label201)
        Me.tabPage68.Controls.Add(Me.label200)
        Me.tabPage68.Controls.Add(Me.label199)
        Me.tabPage68.Controls.Add(Me.label198)
        Me.tabPage68.Controls.Add(Me.tabControl7)
        Me.tabPage68.Controls.Add(Me.tbContrast)
        Me.tabPage68.Controls.Add(Me.tbDarkness)
        Me.tabPage68.Controls.Add(Me.tbLightness)
        Me.tabPage68.Controls.Add(Me.tbSaturation)
        Me.tabPage68.Controls.Add(Me.cbInvert)
        Me.tabPage68.Controls.Add(Me.cbGreyscale)
        Me.tabPage68.Controls.Add(Me.cbEffects)
        Me.tabPage68.Location = New System.Drawing.Point(4, 22)
        Me.tabPage68.Name = "tabPage68"
        Me.tabPage68.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage68.Size = New System.Drawing.Size(290, 459)
        Me.tabPage68.TabIndex = 0
        Me.tabPage68.Text = "Effects"
        Me.tabPage68.UseVisualStyleBackColor = true
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = true
        Me.cbFlipY.Location = New System.Drawing.Point(210, 158)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipY.TabIndex = 69
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = true
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = true
        Me.cbFlipX.Location = New System.Drawing.Point(150, 158)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipX.TabIndex = 68
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = true
        '
        'label201
        '
        Me.label201.AutoSize = true
        Me.label201.Location = New System.Drawing.Point(142, 88)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(52, 13)
        Me.label201.TabIndex = 63
        Me.label201.Text = "Darkness"
        '
        'label200
        '
        Me.label200.AutoSize = true
        Me.label200.Location = New System.Drawing.Point(6, 88)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(46, 13)
        Me.label200.TabIndex = 62
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = true
        Me.label199.Location = New System.Drawing.Point(142, 36)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(55, 13)
        Me.label199.TabIndex = 61
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = true
        Me.label198.Location = New System.Drawing.Point(6, 36)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(52, 13)
        Me.label198.TabIndex = 60
        Me.label198.Text = "Lightness"
        '
        'tabControl7
        '
        Me.tabControl7.Controls.Add(Me.tabPage29)
        Me.tabControl7.Controls.Add(Me.tabPage42)
        Me.tabControl7.Controls.Add(Me.TabPage88)
        Me.tabControl7.Controls.Add(Me.TabPage91)
        Me.tabControl7.Controls.Add(Me.TabPage101)
        Me.tabControl7.Controls.Add(Me.TabPage112)
        Me.tabControl7.Location = New System.Drawing.Point(3, 185)
        Me.tabControl7.Name = "tabControl7"
        Me.tabControl7.SelectedIndex = 0
        Me.tabControl7.Size = New System.Drawing.Size(283, 274)
        Me.tabControl7.TabIndex = 59
        '
        'tabPage29
        '
        Me.tabPage29.Controls.Add(Me.cbMergeTextLogos)
        Me.tabPage29.Controls.Add(Me.btTextLogoRemove)
        Me.tabPage29.Controls.Add(Me.btTextLogoEdit)
        Me.tabPage29.Controls.Add(Me.lbTextLogos)
        Me.tabPage29.Controls.Add(Me.btTextLogoAdd)
        Me.tabPage29.Location = New System.Drawing.Point(4, 22)
        Me.tabPage29.Name = "tabPage29"
        Me.tabPage29.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage29.Size = New System.Drawing.Size(275, 248)
        Me.tabPage29.TabIndex = 0
        Me.tabPage29.Text = "Text logo"
        Me.tabPage29.UseVisualStyleBackColor = true
        '
        'cbMergeTextLogos
        '
        Me.cbMergeTextLogos.AutoSize = true
        Me.cbMergeTextLogos.Location = New System.Drawing.Point(9, 11)
        Me.cbMergeTextLogos.Name = "cbMergeTextLogos"
        Me.cbMergeTextLogos.Size = New System.Drawing.Size(145, 17)
        Me.cbMergeTextLogos.TabIndex = 88
        Me.cbMergeTextLogos.Text = "Merge text logos into one"
        Me.cbMergeTextLogos.UseVisualStyleBackColor = true
        '
        'btTextLogoRemove
        '
        Me.btTextLogoRemove.Location = New System.Drawing.Point(207, 214)
        Me.btTextLogoRemove.Name = "btTextLogoRemove"
        Me.btTextLogoRemove.Size = New System.Drawing.Size(59, 23)
        Me.btTextLogoRemove.TabIndex = 7
        Me.btTextLogoRemove.Text = "Remove"
        Me.btTextLogoRemove.UseVisualStyleBackColor = true
        '
        'btTextLogoEdit
        '
        Me.btTextLogoEdit.Location = New System.Drawing.Point(73, 214)
        Me.btTextLogoEdit.Name = "btTextLogoEdit"
        Me.btTextLogoEdit.Size = New System.Drawing.Size(59, 23)
        Me.btTextLogoEdit.TabIndex = 6
        Me.btTextLogoEdit.Text = "Edit"
        Me.btTextLogoEdit.UseVisualStyleBackColor = true
        '
        'lbTextLogos
        '
        Me.lbTextLogos.FormattingEnabled = true
        Me.lbTextLogos.Location = New System.Drawing.Point(9, 37)
        Me.lbTextLogos.Name = "lbTextLogos"
        Me.lbTextLogos.Size = New System.Drawing.Size(257, 173)
        Me.lbTextLogos.TabIndex = 5
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(8, 214)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(59, 23)
        Me.btTextLogoAdd.TabIndex = 4
        Me.btTextLogoAdd.Text = "Add"
        Me.btTextLogoAdd.UseVisualStyleBackColor = true
        '
        'tabPage42
        '
        Me.tabPage42.Controls.Add(Me.cbMergeImageLogos)
        Me.tabPage42.Controls.Add(Me.btImageLogoRemove)
        Me.tabPage42.Controls.Add(Me.btImageLogoEdit)
        Me.tabPage42.Controls.Add(Me.lbImageLogos)
        Me.tabPage42.Controls.Add(Me.btImageLogoAdd)
        Me.tabPage42.Location = New System.Drawing.Point(4, 22)
        Me.tabPage42.Name = "tabPage42"
        Me.tabPage42.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage42.Size = New System.Drawing.Size(275, 248)
        Me.tabPage42.TabIndex = 1
        Me.tabPage42.Text = "Image logo"
        Me.tabPage42.UseVisualStyleBackColor = true
        '
        'cbMergeImageLogos
        '
        Me.cbMergeImageLogos.AutoSize = true
        Me.cbMergeImageLogos.Location = New System.Drawing.Point(9, 11)
        Me.cbMergeImageLogos.Name = "cbMergeImageLogos"
        Me.cbMergeImageLogos.Size = New System.Drawing.Size(156, 17)
        Me.cbMergeImageLogos.TabIndex = 87
        Me.cbMergeImageLogos.Text = "Merge image logos into one"
        Me.cbMergeImageLogos.UseVisualStyleBackColor = true
        '
        'btImageLogoRemove
        '
        Me.btImageLogoRemove.Location = New System.Drawing.Point(207, 214)
        Me.btImageLogoRemove.Name = "btImageLogoRemove"
        Me.btImageLogoRemove.Size = New System.Drawing.Size(59, 23)
        Me.btImageLogoRemove.TabIndex = 11
        Me.btImageLogoRemove.Text = "Remove"
        Me.btImageLogoRemove.UseVisualStyleBackColor = true
        '
        'btImageLogoEdit
        '
        Me.btImageLogoEdit.Location = New System.Drawing.Point(73, 214)
        Me.btImageLogoEdit.Name = "btImageLogoEdit"
        Me.btImageLogoEdit.Size = New System.Drawing.Size(59, 23)
        Me.btImageLogoEdit.TabIndex = 10
        Me.btImageLogoEdit.Text = "Edit"
        Me.btImageLogoEdit.UseVisualStyleBackColor = true
        '
        'lbImageLogos
        '
        Me.lbImageLogos.FormattingEnabled = true
        Me.lbImageLogos.Location = New System.Drawing.Point(9, 37)
        Me.lbImageLogos.Name = "lbImageLogos"
        Me.lbImageLogos.Size = New System.Drawing.Size(257, 173)
        Me.lbImageLogos.TabIndex = 9
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(8, 214)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(59, 23)
        Me.btImageLogoAdd.TabIndex = 8
        Me.btImageLogoAdd.Text = "Add"
        Me.btImageLogoAdd.UseVisualStyleBackColor = true
        '
        'TabPage88
        '
        Me.TabPage88.Controls.Add(Me.groupBox37)
        Me.TabPage88.Controls.Add(Me.cbZoom)
        Me.TabPage88.Location = New System.Drawing.Point(4, 22)
        Me.TabPage88.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage88.Name = "TabPage88"
        Me.TabPage88.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage88.Size = New System.Drawing.Size(275, 248)
        Me.TabPage88.TabIndex = 2
        Me.TabPage88.Text = "Zoom"
        Me.TabPage88.UseVisualStyleBackColor = true
        '
        'groupBox37
        '
        Me.groupBox37.Controls.Add(Me.btEffZoomRight)
        Me.groupBox37.Controls.Add(Me.btEffZoomLeft)
        Me.groupBox37.Controls.Add(Me.btEffZoomOut)
        Me.groupBox37.Controls.Add(Me.btEffZoomIn)
        Me.groupBox37.Controls.Add(Me.btEffZoomDown)
        Me.groupBox37.Controls.Add(Me.btEffZoomUp)
        Me.groupBox37.Location = New System.Drawing.Point(79, 52)
        Me.groupBox37.Name = "groupBox37"
        Me.groupBox37.Size = New System.Drawing.Size(119, 104)
        Me.groupBox37.TabIndex = 18
        Me.groupBox37.TabStop = false
        Me.groupBox37.Text = "Zoom"
        '
        'btEffZoomRight
        '
        Me.btEffZoomRight.Location = New System.Drawing.Point(85, 33)
        Me.btEffZoomRight.Name = "btEffZoomRight"
        Me.btEffZoomRight.Size = New System.Drawing.Size(21, 48)
        Me.btEffZoomRight.TabIndex = 5
        Me.btEffZoomRight.Text = "R"
        Me.btEffZoomRight.UseVisualStyleBackColor = true
        '
        'btEffZoomLeft
        '
        Me.btEffZoomLeft.Location = New System.Drawing.Point(13, 32)
        Me.btEffZoomLeft.Name = "btEffZoomLeft"
        Me.btEffZoomLeft.Size = New System.Drawing.Size(21, 48)
        Me.btEffZoomLeft.TabIndex = 4
        Me.btEffZoomLeft.Text = "L"
        Me.btEffZoomLeft.UseVisualStyleBackColor = true
        '
        'btEffZoomOut
        '
        Me.btEffZoomOut.Location = New System.Drawing.Point(61, 45)
        Me.btEffZoomOut.Name = "btEffZoomOut"
        Me.btEffZoomOut.Size = New System.Drawing.Size(23, 23)
        Me.btEffZoomOut.TabIndex = 3
        Me.btEffZoomOut.Text = "-"
        Me.btEffZoomOut.UseVisualStyleBackColor = true
        '
        'btEffZoomIn
        '
        Me.btEffZoomIn.Location = New System.Drawing.Point(35, 45)
        Me.btEffZoomIn.Name = "btEffZoomIn"
        Me.btEffZoomIn.Size = New System.Drawing.Size(22, 23)
        Me.btEffZoomIn.TabIndex = 2
        Me.btEffZoomIn.Text = "+"
        Me.btEffZoomIn.UseVisualStyleBackColor = true
        '
        'btEffZoomDown
        '
        Me.btEffZoomDown.Location = New System.Drawing.Point(34, 69)
        Me.btEffZoomDown.Name = "btEffZoomDown"
        Me.btEffZoomDown.Size = New System.Drawing.Size(51, 23)
        Me.btEffZoomDown.TabIndex = 1
        Me.btEffZoomDown.Text = "Down"
        Me.btEffZoomDown.UseVisualStyleBackColor = true
        '
        'btEffZoomUp
        '
        Me.btEffZoomUp.Location = New System.Drawing.Point(34, 20)
        Me.btEffZoomUp.Name = "btEffZoomUp"
        Me.btEffZoomUp.Size = New System.Drawing.Size(51, 23)
        Me.btEffZoomUp.TabIndex = 0
        Me.btEffZoomUp.Text = "Up"
        Me.btEffZoomUp.UseVisualStyleBackColor = true
        '
        'cbZoom
        '
        Me.cbZoom.AutoSize = true
        Me.cbZoom.Location = New System.Drawing.Point(8, 16)
        Me.cbZoom.Name = "cbZoom"
        Me.cbZoom.Size = New System.Drawing.Size(65, 17)
        Me.cbZoom.TabIndex = 17
        Me.cbZoom.Text = "Enabled"
        Me.cbZoom.UseVisualStyleBackColor = true
        '
        'TabPage91
        '
        Me.TabPage91.Controls.Add(Me.groupBox40)
        Me.TabPage91.Controls.Add(Me.groupBox39)
        Me.TabPage91.Controls.Add(Me.groupBox38)
        Me.TabPage91.Controls.Add(Me.cbPan)
        Me.TabPage91.Location = New System.Drawing.Point(4, 22)
        Me.TabPage91.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage91.Name = "TabPage91"
        Me.TabPage91.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage91.Size = New System.Drawing.Size(275, 248)
        Me.TabPage91.TabIndex = 3
        Me.TabPage91.Text = "Pan"
        Me.TabPage91.UseVisualStyleBackColor = true
        '
        'groupBox40
        '
        Me.groupBox40.Controls.Add(Me.edPanDestHeight)
        Me.groupBox40.Controls.Add(Me.label302)
        Me.groupBox40.Controls.Add(Me.edPanDestWidth)
        Me.groupBox40.Controls.Add(Me.label303)
        Me.groupBox40.Controls.Add(Me.edPanDestTop)
        Me.groupBox40.Controls.Add(Me.label304)
        Me.groupBox40.Controls.Add(Me.edPanDestLeft)
        Me.groupBox40.Controls.Add(Me.label305)
        Me.groupBox40.Location = New System.Drawing.Point(12, 167)
        Me.groupBox40.Margin = New System.Windows.Forms.Padding(2)
        Me.groupBox40.Name = "groupBox40"
        Me.groupBox40.Padding = New System.Windows.Forms.Padding(2)
        Me.groupBox40.Size = New System.Drawing.Size(168, 77)
        Me.groupBox40.TabIndex = 58
        Me.groupBox40.TabStop = false
        Me.groupBox40.Text = "Destination rect"
        '
        'edPanDestHeight
        '
        Me.edPanDestHeight.Location = New System.Drawing.Point(123, 51)
        Me.edPanDestHeight.Name = "edPanDestHeight"
        Me.edPanDestHeight.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestHeight.TabIndex = 17
        Me.edPanDestHeight.Text = "240"
        '
        'label302
        '
        Me.label302.AutoSize = true
        Me.label302.Location = New System.Drawing.Point(81, 54)
        Me.label302.Name = "label302"
        Me.label302.Size = New System.Drawing.Size(38, 13)
        Me.label302.TabIndex = 16
        Me.label302.Text = "Height"
        '
        'edPanDestWidth
        '
        Me.edPanDestWidth.Location = New System.Drawing.Point(123, 25)
        Me.edPanDestWidth.Name = "edPanDestWidth"
        Me.edPanDestWidth.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestWidth.TabIndex = 15
        Me.edPanDestWidth.Text = "320"
        '
        'label303
        '
        Me.label303.AutoSize = true
        Me.label303.Location = New System.Drawing.Point(81, 28)
        Me.label303.Name = "label303"
        Me.label303.Size = New System.Drawing.Size(35, 13)
        Me.label303.TabIndex = 14
        Me.label303.Text = "Width"
        '
        'edPanDestTop
        '
        Me.edPanDestTop.Location = New System.Drawing.Point(43, 52)
        Me.edPanDestTop.Name = "edPanDestTop"
        Me.edPanDestTop.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestTop.TabIndex = 12
        Me.edPanDestTop.Text = "0"
        '
        'label304
        '
        Me.label304.AutoSize = true
        Me.label304.Location = New System.Drawing.Point(13, 54)
        Me.label304.Name = "label304"
        Me.label304.Size = New System.Drawing.Size(26, 13)
        Me.label304.TabIndex = 11
        Me.label304.Text = "Top"
        '
        'edPanDestLeft
        '
        Me.edPanDestLeft.Location = New System.Drawing.Point(43, 26)
        Me.edPanDestLeft.Name = "edPanDestLeft"
        Me.edPanDestLeft.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestLeft.TabIndex = 10
        Me.edPanDestLeft.Text = "0"
        '
        'label305
        '
        Me.label305.AutoSize = true
        Me.label305.Location = New System.Drawing.Point(13, 28)
        Me.label305.Name = "label305"
        Me.label305.Size = New System.Drawing.Size(25, 13)
        Me.label305.TabIndex = 9
        Me.label305.Text = "Left"
        '
        'groupBox39
        '
        Me.groupBox39.Controls.Add(Me.edPanSourceHeight)
        Me.groupBox39.Controls.Add(Me.label298)
        Me.groupBox39.Controls.Add(Me.edPanSourceWidth)
        Me.groupBox39.Controls.Add(Me.label299)
        Me.groupBox39.Controls.Add(Me.edPanSourceTop)
        Me.groupBox39.Controls.Add(Me.label300)
        Me.groupBox39.Controls.Add(Me.edPanSourceLeft)
        Me.groupBox39.Controls.Add(Me.label301)
        Me.groupBox39.Location = New System.Drawing.Point(12, 85)
        Me.groupBox39.Margin = New System.Windows.Forms.Padding(2)
        Me.groupBox39.Name = "groupBox39"
        Me.groupBox39.Padding = New System.Windows.Forms.Padding(2)
        Me.groupBox39.Size = New System.Drawing.Size(168, 77)
        Me.groupBox39.TabIndex = 57
        Me.groupBox39.TabStop = false
        Me.groupBox39.Text = "Source rect"
        '
        'edPanSourceHeight
        '
        Me.edPanSourceHeight.Location = New System.Drawing.Point(123, 51)
        Me.edPanSourceHeight.Name = "edPanSourceHeight"
        Me.edPanSourceHeight.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceHeight.TabIndex = 17
        Me.edPanSourceHeight.Text = "480"
        '
        'label298
        '
        Me.label298.AutoSize = true
        Me.label298.Location = New System.Drawing.Point(81, 54)
        Me.label298.Name = "label298"
        Me.label298.Size = New System.Drawing.Size(38, 13)
        Me.label298.TabIndex = 16
        Me.label298.Text = "Height"
        '
        'edPanSourceWidth
        '
        Me.edPanSourceWidth.Location = New System.Drawing.Point(123, 25)
        Me.edPanSourceWidth.Name = "edPanSourceWidth"
        Me.edPanSourceWidth.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceWidth.TabIndex = 15
        Me.edPanSourceWidth.Text = "640"
        '
        'label299
        '
        Me.label299.AutoSize = true
        Me.label299.Location = New System.Drawing.Point(81, 28)
        Me.label299.Name = "label299"
        Me.label299.Size = New System.Drawing.Size(35, 13)
        Me.label299.TabIndex = 14
        Me.label299.Text = "Width"
        '
        'edPanSourceTop
        '
        Me.edPanSourceTop.Location = New System.Drawing.Point(43, 52)
        Me.edPanSourceTop.Name = "edPanSourceTop"
        Me.edPanSourceTop.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceTop.TabIndex = 12
        Me.edPanSourceTop.Text = "0"
        '
        'label300
        '
        Me.label300.AutoSize = true
        Me.label300.Location = New System.Drawing.Point(13, 54)
        Me.label300.Name = "label300"
        Me.label300.Size = New System.Drawing.Size(26, 13)
        Me.label300.TabIndex = 11
        Me.label300.Text = "Top"
        '
        'edPanSourceLeft
        '
        Me.edPanSourceLeft.Location = New System.Drawing.Point(43, 26)
        Me.edPanSourceLeft.Name = "edPanSourceLeft"
        Me.edPanSourceLeft.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceLeft.TabIndex = 10
        Me.edPanSourceLeft.Text = "0"
        '
        'label301
        '
        Me.label301.AutoSize = true
        Me.label301.Location = New System.Drawing.Point(13, 28)
        Me.label301.Name = "label301"
        Me.label301.Size = New System.Drawing.Size(25, 13)
        Me.label301.TabIndex = 9
        Me.label301.Text = "Left"
        '
        'groupBox38
        '
        Me.groupBox38.Controls.Add(Me.edPanStopTime)
        Me.groupBox38.Controls.Add(Me.label296)
        Me.groupBox38.Controls.Add(Me.edPanStartTime)
        Me.groupBox38.Controls.Add(Me.label297)
        Me.groupBox38.Location = New System.Drawing.Point(12, 34)
        Me.groupBox38.Name = "groupBox38"
        Me.groupBox38.Size = New System.Drawing.Size(168, 46)
        Me.groupBox38.TabIndex = 56
        Me.groupBox38.TabStop = false
        Me.groupBox38.Text = "Duration"
        '
        'edPanStopTime
        '
        Me.edPanStopTime.Location = New System.Drawing.Point(117, 19)
        Me.edPanStopTime.Name = "edPanStopTime"
        Me.edPanStopTime.Size = New System.Drawing.Size(39, 20)
        Me.edPanStopTime.TabIndex = 34
        Me.edPanStopTime.Text = "15000"
        Me.edPanStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label296
        '
        Me.label296.AutoSize = true
        Me.label296.Location = New System.Drawing.Point(88, 22)
        Me.label296.Name = "label296"
        Me.label296.Size = New System.Drawing.Size(29, 13)
        Me.label296.TabIndex = 33
        Me.label296.Text = "Stop"
        '
        'edPanStartTime
        '
        Me.edPanStartTime.Location = New System.Drawing.Point(43, 19)
        Me.edPanStartTime.Name = "edPanStartTime"
        Me.edPanStartTime.Size = New System.Drawing.Size(39, 20)
        Me.edPanStartTime.TabIndex = 32
        Me.edPanStartTime.Text = "5000"
        Me.edPanStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label297
        '
        Me.label297.AutoSize = true
        Me.label297.Location = New System.Drawing.Point(10, 22)
        Me.label297.Name = "label297"
        Me.label297.Size = New System.Drawing.Size(29, 13)
        Me.label297.TabIndex = 31
        Me.label297.Text = "Start"
        '
        'cbPan
        '
        Me.cbPan.AutoSize = true
        Me.cbPan.Location = New System.Drawing.Point(12, 11)
        Me.cbPan.Name = "cbPan"
        Me.cbPan.Size = New System.Drawing.Size(65, 17)
        Me.cbPan.TabIndex = 55
        Me.cbPan.Text = "Enabled"
        Me.cbPan.UseVisualStyleBackColor = true
        '
        'TabPage101
        '
        Me.TabPage101.Controls.Add(Me.rbFadeOut)
        Me.TabPage101.Controls.Add(Me.rbFadeIn)
        Me.TabPage101.Controls.Add(Me.groupBox45)
        Me.TabPage101.Controls.Add(Me.cbFadeInOut)
        Me.TabPage101.Location = New System.Drawing.Point(4, 22)
        Me.TabPage101.Name = "TabPage101"
        Me.TabPage101.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage101.Size = New System.Drawing.Size(275, 248)
        Me.TabPage101.TabIndex = 4
        Me.TabPage101.Text = "Fade-in/out"
        Me.TabPage101.UseVisualStyleBackColor = true
        '
        'rbFadeOut
        '
        Me.rbFadeOut.AutoSize = true
        Me.rbFadeOut.Location = New System.Drawing.Point(103, 87)
        Me.rbFadeOut.Name = "rbFadeOut"
        Me.rbFadeOut.Size = New System.Drawing.Size(67, 17)
        Me.rbFadeOut.TabIndex = 60
        Me.rbFadeOut.TabStop = true
        Me.rbFadeOut.Text = "Fade-out"
        Me.rbFadeOut.UseVisualStyleBackColor = true
        '
        'rbFadeIn
        '
        Me.rbFadeIn.AutoSize = true
        Me.rbFadeIn.Checked = true
        Me.rbFadeIn.Location = New System.Drawing.Point(12, 87)
        Me.rbFadeIn.Name = "rbFadeIn"
        Me.rbFadeIn.Size = New System.Drawing.Size(60, 17)
        Me.rbFadeIn.TabIndex = 59
        Me.rbFadeIn.TabStop = true
        Me.rbFadeIn.Text = "Fade-in"
        Me.rbFadeIn.UseVisualStyleBackColor = true
        '
        'groupBox45
        '
        Me.groupBox45.Controls.Add(Me.edFadeInOutStopTime)
        Me.groupBox45.Controls.Add(Me.label329)
        Me.groupBox45.Controls.Add(Me.edFadeInOutStartTime)
        Me.groupBox45.Controls.Add(Me.label330)
        Me.groupBox45.Location = New System.Drawing.Point(12, 35)
        Me.groupBox45.Name = "groupBox45"
        Me.groupBox45.Size = New System.Drawing.Size(168, 46)
        Me.groupBox45.TabIndex = 58
        Me.groupBox45.TabStop = false
        Me.groupBox45.Text = "Duration"
        '
        'edFadeInOutStopTime
        '
        Me.edFadeInOutStopTime.Location = New System.Drawing.Point(117, 19)
        Me.edFadeInOutStopTime.Name = "edFadeInOutStopTime"
        Me.edFadeInOutStopTime.Size = New System.Drawing.Size(39, 20)
        Me.edFadeInOutStopTime.TabIndex = 34
        Me.edFadeInOutStopTime.Text = "15000"
        Me.edFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label329
        '
        Me.label329.AutoSize = true
        Me.label329.Location = New System.Drawing.Point(88, 22)
        Me.label329.Name = "label329"
        Me.label329.Size = New System.Drawing.Size(29, 13)
        Me.label329.TabIndex = 33
        Me.label329.Text = "Stop"
        '
        'edFadeInOutStartTime
        '
        Me.edFadeInOutStartTime.Location = New System.Drawing.Point(43, 19)
        Me.edFadeInOutStartTime.Name = "edFadeInOutStartTime"
        Me.edFadeInOutStartTime.Size = New System.Drawing.Size(39, 20)
        Me.edFadeInOutStartTime.TabIndex = 32
        Me.edFadeInOutStartTime.Text = "5000"
        Me.edFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label330
        '
        Me.label330.AutoSize = true
        Me.label330.Location = New System.Drawing.Point(10, 22)
        Me.label330.Name = "label330"
        Me.label330.Size = New System.Drawing.Size(29, 13)
        Me.label330.TabIndex = 31
        Me.label330.Text = "Start"
        '
        'cbFadeInOut
        '
        Me.cbFadeInOut.AutoSize = true
        Me.cbFadeInOut.Location = New System.Drawing.Point(12, 12)
        Me.cbFadeInOut.Name = "cbFadeInOut"
        Me.cbFadeInOut.Size = New System.Drawing.Size(65, 17)
        Me.cbFadeInOut.TabIndex = 57
        Me.cbFadeInOut.Text = "Enabled"
        Me.cbFadeInOut.UseVisualStyleBackColor = true
        '
        'TabPage112
        '
        Me.TabPage112.Controls.Add(Me.label391)
        Me.TabPage112.Controls.Add(Me.cbLiveRotationStretch)
        Me.TabPage112.Controls.Add(Me.label392)
        Me.TabPage112.Controls.Add(Me.tbLiveRotationAngle)
        Me.TabPage112.Controls.Add(Me.label390)
        Me.TabPage112.Controls.Add(Me.cbLiveRotation)
        Me.TabPage112.Location = New System.Drawing.Point(4, 22)
        Me.TabPage112.Name = "TabPage112"
        Me.TabPage112.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage112.Size = New System.Drawing.Size(275, 248)
        Me.TabPage112.TabIndex = 5
        Me.TabPage112.Text = "Live rotation"
        Me.TabPage112.UseVisualStyleBackColor = true
        '
        'label391
        '
        Me.label391.AutoSize = true
        Me.label391.Location = New System.Drawing.Point(16, 115)
        Me.label391.Name = "label391"
        Me.label391.Size = New System.Drawing.Size(13, 13)
        Me.label391.TabIndex = 65
        Me.label391.Text = "0"
        '
        'cbLiveRotationStretch
        '
        Me.cbLiveRotationStretch.AutoSize = true
        Me.cbLiveRotationStretch.Location = New System.Drawing.Point(12, 137)
        Me.cbLiveRotationStretch.Name = "cbLiveRotationStretch"
        Me.cbLiveRotationStretch.Size = New System.Drawing.Size(158, 17)
        Me.cbLiveRotationStretch.TabIndex = 64
        Me.cbLiveRotationStretch.Text = "Stretch  if angle is 90 or 270"
        Me.cbLiveRotationStretch.UseVisualStyleBackColor = true
        '
        'label392
        '
        Me.label392.AutoSize = true
        Me.label392.Location = New System.Drawing.Point(130, 111)
        Me.label392.Name = "label392"
        Me.label392.Size = New System.Drawing.Size(25, 13)
        Me.label392.TabIndex = 63
        Me.label392.Text = "360"
        '
        'tbLiveRotationAngle
        '
        Me.tbLiveRotationAngle.Location = New System.Drawing.Point(12, 63)
        Me.tbLiveRotationAngle.Maximum = 360
        Me.tbLiveRotationAngle.Name = "tbLiveRotationAngle"
        Me.tbLiveRotationAngle.Size = New System.Drawing.Size(143, 45)
        Me.tbLiveRotationAngle.TabIndex = 62
        Me.tbLiveRotationAngle.TickFrequency = 5
        Me.tbLiveRotationAngle.Value = 90
        '
        'label390
        '
        Me.label390.AutoSize = true
        Me.label390.Location = New System.Drawing.Point(9, 44)
        Me.label390.Name = "label390"
        Me.label390.Size = New System.Drawing.Size(34, 13)
        Me.label390.TabIndex = 61
        Me.label390.Text = "Angle"
        '
        'cbLiveRotation
        '
        Me.cbLiveRotation.AutoSize = true
        Me.cbLiveRotation.Location = New System.Drawing.Point(12, 12)
        Me.cbLiveRotation.Name = "cbLiveRotation"
        Me.cbLiveRotation.Size = New System.Drawing.Size(65, 17)
        Me.cbLiveRotation.TabIndex = 60
        Me.cbLiveRotation.Text = "Enabled"
        Me.cbLiveRotation.UseVisualStyleBackColor = true
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(3, 107)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbContrast.TabIndex = 49
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(142, 107)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbDarkness.TabIndex = 46
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(3, 51)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(130, 45)
        Me.tbLightness.TabIndex = 45
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(142, 51)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbSaturation.TabIndex = 43
        Me.tbSaturation.Value = 255
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = true
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(90, 158)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbInvert.TabIndex = 41
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = true
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = true
        Me.cbGreyscale.Location = New System.Drawing.Point(9, 158)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGreyscale.TabIndex = 39
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = true
        '
        'cbEffects
        '
        Me.cbEffects.AutoSize = true
        Me.cbEffects.Checked = true
        Me.cbEffects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEffects.Location = New System.Drawing.Point(9, 7)
        Me.cbEffects.Name = "cbEffects"
        Me.cbEffects.Size = New System.Drawing.Size(65, 17)
        Me.cbEffects.TabIndex = 37
        Me.cbEffects.Text = "Enabled"
        Me.cbEffects.UseVisualStyleBackColor = true
        '
        'tabPage69
        '
        Me.tabPage69.Controls.Add(Me.label211)
        Me.tabPage69.Controls.Add(Me.edDeintTriangleWeight)
        Me.tabPage69.Controls.Add(Me.label212)
        Me.tabPage69.Controls.Add(Me.label210)
        Me.tabPage69.Controls.Add(Me.label209)
        Me.tabPage69.Controls.Add(Me.label206)
        Me.tabPage69.Controls.Add(Me.edDeintBlendConstants2)
        Me.tabPage69.Controls.Add(Me.label207)
        Me.tabPage69.Controls.Add(Me.edDeintBlendConstants1)
        Me.tabPage69.Controls.Add(Me.label208)
        Me.tabPage69.Controls.Add(Me.label204)
        Me.tabPage69.Controls.Add(Me.edDeintBlendThreshold2)
        Me.tabPage69.Controls.Add(Me.label205)
        Me.tabPage69.Controls.Add(Me.edDeintBlendThreshold1)
        Me.tabPage69.Controls.Add(Me.label203)
        Me.tabPage69.Controls.Add(Me.label202)
        Me.tabPage69.Controls.Add(Me.edDeintCAVTThreshold)
        Me.tabPage69.Controls.Add(Me.label104)
        Me.tabPage69.Controls.Add(Me.rbDeintTriangleEnabled)
        Me.tabPage69.Controls.Add(Me.rbDeintBlendEnabled)
        Me.tabPage69.Controls.Add(Me.rbDeintCAVTEnabled)
        Me.tabPage69.Controls.Add(Me.cbDeinterlace)
        Me.tabPage69.Location = New System.Drawing.Point(4, 22)
        Me.tabPage69.Name = "tabPage69"
        Me.tabPage69.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage69.Size = New System.Drawing.Size(290, 459)
        Me.tabPage69.TabIndex = 1
        Me.tabPage69.Text = "Deinterlace"
        Me.tabPage69.UseVisualStyleBackColor = true
        '
        'label211
        '
        Me.label211.AutoSize = true
        Me.label211.Location = New System.Drawing.Point(99, 294)
        Me.label211.Name = "label211"
        Me.label211.Size = New System.Drawing.Size(40, 13)
        Me.label211.TabIndex = 50
        Me.label211.Text = "[0-255]"
        '
        'edDeintTriangleWeight
        '
        Me.edDeintTriangleWeight.Location = New System.Drawing.Point(102, 270)
        Me.edDeintTriangleWeight.Name = "edDeintTriangleWeight"
        Me.edDeintTriangleWeight.Size = New System.Drawing.Size(32, 20)
        Me.edDeintTriangleWeight.TabIndex = 49
        Me.edDeintTriangleWeight.Text = "180"
        '
        'label212
        '
        Me.label212.AutoSize = true
        Me.label212.Location = New System.Drawing.Point(33, 273)
        Me.label212.Name = "label212"
        Me.label212.Size = New System.Drawing.Size(41, 13)
        Me.label212.TabIndex = 48
        Me.label212.Text = "Weight"
        '
        'label210
        '
        Me.label210.AutoSize = true
        Me.label210.Location = New System.Drawing.Point(256, 192)
        Me.label210.Name = "label210"
        Me.label210.Size = New System.Drawing.Size(27, 13)
        Me.label210.TabIndex = 47
        Me.label210.Text = "/ 10"
        '
        'label209
        '
        Me.label209.AutoSize = true
        Me.label209.Location = New System.Drawing.Point(256, 159)
        Me.label209.Name = "label209"
        Me.label209.Size = New System.Drawing.Size(27, 13)
        Me.label209.TabIndex = 46
        Me.label209.Text = "/ 10"
        '
        'label206
        '
        Me.label206.AutoSize = true
        Me.label206.Location = New System.Drawing.Point(217, 213)
        Me.label206.Name = "label206"
        Me.label206.Size = New System.Drawing.Size(46, 13)
        Me.label206.TabIndex = 45
        Me.label206.Text = "[0.0-1.0]"
        '
        'edDeintBlendConstants2
        '
        Me.edDeintBlendConstants2.Location = New System.Drawing.Point(220, 189)
        Me.edDeintBlendConstants2.Name = "edDeintBlendConstants2"
        Me.edDeintBlendConstants2.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendConstants2.TabIndex = 44
        Me.edDeintBlendConstants2.Text = "9"
        '
        'label207
        '
        Me.label207.AutoSize = true
        Me.label207.Location = New System.Drawing.Point(151, 192)
        Me.label207.Name = "label207"
        Me.label207.Size = New System.Drawing.Size(63, 13)
        Me.label207.TabIndex = 43
        Me.label207.Text = "Constants 2"
        '
        'edDeintBlendConstants1
        '
        Me.edDeintBlendConstants1.Location = New System.Drawing.Point(220, 156)
        Me.edDeintBlendConstants1.Name = "edDeintBlendConstants1"
        Me.edDeintBlendConstants1.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendConstants1.TabIndex = 42
        Me.edDeintBlendConstants1.Text = "3"
        '
        'label208
        '
        Me.label208.AutoSize = true
        Me.label208.Location = New System.Drawing.Point(151, 159)
        Me.label208.Name = "label208"
        Me.label208.Size = New System.Drawing.Size(63, 13)
        Me.label208.TabIndex = 41
        Me.label208.Text = "Constants 1"
        '
        'label204
        '
        Me.label204.AutoSize = true
        Me.label204.Location = New System.Drawing.Point(99, 213)
        Me.label204.Name = "label204"
        Me.label204.Size = New System.Drawing.Size(40, 13)
        Me.label204.TabIndex = 40
        Me.label204.Text = "[0-255]"
        '
        'edDeintBlendThreshold2
        '
        Me.edDeintBlendThreshold2.Location = New System.Drawing.Point(102, 189)
        Me.edDeintBlendThreshold2.Name = "edDeintBlendThreshold2"
        Me.edDeintBlendThreshold2.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendThreshold2.TabIndex = 39
        Me.edDeintBlendThreshold2.Text = "9"
        '
        'label205
        '
        Me.label205.AutoSize = true
        Me.label205.Location = New System.Drawing.Point(33, 192)
        Me.label205.Name = "label205"
        Me.label205.Size = New System.Drawing.Size(63, 13)
        Me.label205.TabIndex = 38
        Me.label205.Text = "Threshold 2"
        '
        'edDeintBlendThreshold1
        '
        Me.edDeintBlendThreshold1.Location = New System.Drawing.Point(102, 156)
        Me.edDeintBlendThreshold1.Name = "edDeintBlendThreshold1"
        Me.edDeintBlendThreshold1.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendThreshold1.TabIndex = 37
        Me.edDeintBlendThreshold1.Text = "5"
        '
        'label203
        '
        Me.label203.AutoSize = true
        Me.label203.Location = New System.Drawing.Point(33, 159)
        Me.label203.Name = "label203"
        Me.label203.Size = New System.Drawing.Size(63, 13)
        Me.label203.TabIndex = 36
        Me.label203.Text = "Threshold 1"
        '
        'label202
        '
        Me.label202.AutoSize = true
        Me.label202.Location = New System.Drawing.Point(99, 103)
        Me.label202.Name = "label202"
        Me.label202.Size = New System.Drawing.Size(40, 13)
        Me.label202.TabIndex = 35
        Me.label202.Text = "[0-255]"
        '
        'edDeintCAVTThreshold
        '
        Me.edDeintCAVTThreshold.Location = New System.Drawing.Point(102, 79)
        Me.edDeintCAVTThreshold.Name = "edDeintCAVTThreshold"
        Me.edDeintCAVTThreshold.Size = New System.Drawing.Size(32, 20)
        Me.edDeintCAVTThreshold.TabIndex = 34
        Me.edDeintCAVTThreshold.Text = "20"
        '
        'label104
        '
        Me.label104.AutoSize = true
        Me.label104.Location = New System.Drawing.Point(33, 82)
        Me.label104.Name = "label104"
        Me.label104.Size = New System.Drawing.Size(54, 13)
        Me.label104.TabIndex = 33
        Me.label104.Text = "Threshold"
        '
        'rbDeintTriangleEnabled
        '
        Me.rbDeintTriangleEnabled.AutoSize = true
        Me.rbDeintTriangleEnabled.Location = New System.Drawing.Point(17, 243)
        Me.rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled"
        Me.rbDeintTriangleEnabled.Size = New System.Drawing.Size(63, 17)
        Me.rbDeintTriangleEnabled.TabIndex = 32
        Me.rbDeintTriangleEnabled.Text = "Triangle"
        Me.rbDeintTriangleEnabled.UseVisualStyleBackColor = true
        '
        'rbDeintBlendEnabled
        '
        Me.rbDeintBlendEnabled.AutoSize = true
        Me.rbDeintBlendEnabled.Location = New System.Drawing.Point(17, 127)
        Me.rbDeintBlendEnabled.Name = "rbDeintBlendEnabled"
        Me.rbDeintBlendEnabled.Size = New System.Drawing.Size(52, 17)
        Me.rbDeintBlendEnabled.TabIndex = 31
        Me.rbDeintBlendEnabled.Text = "Blend"
        Me.rbDeintBlendEnabled.UseVisualStyleBackColor = true
        '
        'rbDeintCAVTEnabled
        '
        Me.rbDeintCAVTEnabled.AutoSize = true
        Me.rbDeintCAVTEnabled.Checked = true
        Me.rbDeintCAVTEnabled.Location = New System.Drawing.Point(17, 52)
        Me.rbDeintCAVTEnabled.Name = "rbDeintCAVTEnabled"
        Me.rbDeintCAVTEnabled.Size = New System.Drawing.Size(229, 17)
        Me.rbDeintCAVTEnabled.TabIndex = 30
        Me.rbDeintCAVTEnabled.TabStop = true
        Me.rbDeintCAVTEnabled.Text = "Content Adaptive Vertical Temporal (CAVT)"
        Me.rbDeintCAVTEnabled.UseVisualStyleBackColor = true
        '
        'cbDeinterlace
        '
        Me.cbDeinterlace.AutoSize = true
        Me.cbDeinterlace.Location = New System.Drawing.Point(17, 16)
        Me.cbDeinterlace.Name = "cbDeinterlace"
        Me.cbDeinterlace.Size = New System.Drawing.Size(65, 17)
        Me.cbDeinterlace.TabIndex = 29
        Me.cbDeinterlace.Text = "Enabled"
        Me.cbDeinterlace.UseVisualStyleBackColor = true
        '
        'TabPage59
        '
        Me.TabPage59.Controls.Add(Me.rbDenoiseCAST)
        Me.TabPage59.Controls.Add(Me.rbDenoiseMosquito)
        Me.TabPage59.Controls.Add(Me.cbDenoise)
        Me.TabPage59.Location = New System.Drawing.Point(4, 22)
        Me.TabPage59.Name = "TabPage59"
        Me.TabPage59.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage59.Size = New System.Drawing.Size(290, 459)
        Me.TabPage59.TabIndex = 4
        Me.TabPage59.Text = "Denoise"
        Me.TabPage59.UseVisualStyleBackColor = true
        '
        'rbDenoiseCAST
        '
        Me.rbDenoiseCAST.AutoSize = true
        Me.rbDenoiseCAST.Location = New System.Drawing.Point(17, 79)
        Me.rbDenoiseCAST.Name = "rbDenoiseCAST"
        Me.rbDenoiseCAST.Size = New System.Drawing.Size(224, 17)
        Me.rbDenoiseCAST.TabIndex = 13
        Me.rbDenoiseCAST.Text = "Content Adaptive Spatio-Temporal (CAST)"
        Me.rbDenoiseCAST.UseVisualStyleBackColor = true
        '
        'rbDenoiseMosquito
        '
        Me.rbDenoiseMosquito.AutoSize = true
        Me.rbDenoiseMosquito.Checked = true
        Me.rbDenoiseMosquito.Location = New System.Drawing.Point(17, 52)
        Me.rbDenoiseMosquito.Name = "rbDenoiseMosquito"
        Me.rbDenoiseMosquito.Size = New System.Drawing.Size(68, 17)
        Me.rbDenoiseMosquito.TabIndex = 12
        Me.rbDenoiseMosquito.TabStop = true
        Me.rbDenoiseMosquito.Text = "Mosquito"
        Me.rbDenoiseMosquito.UseVisualStyleBackColor = true
        '
        'cbDenoise
        '
        Me.cbDenoise.AutoSize = true
        Me.cbDenoise.Location = New System.Drawing.Point(17, 16)
        Me.cbDenoise.Name = "cbDenoise"
        Me.cbDenoise.Size = New System.Drawing.Size(65, 17)
        Me.cbDenoise.TabIndex = 11
        Me.cbDenoise.Text = "Enabled"
        Me.cbDenoise.UseVisualStyleBackColor = true
        '
        'TabPage63
        '
        Me.TabPage63.Controls.Add(Me.label5)
        Me.TabPage63.Controls.Add(Me.tbGPUBlur)
        Me.TabPage63.Controls.Add(Me.cbVideoEffectsGPUEnabled)
        Me.TabPage63.Controls.Add(Me.cbGPUOldMovie)
        Me.TabPage63.Controls.Add(Me.cbGPUDeinterlace)
        Me.TabPage63.Controls.Add(Me.cbGPUDenoise)
        Me.TabPage63.Controls.Add(Me.cbGPUPixelate)
        Me.TabPage63.Controls.Add(Me.cbGPUNightVision)
        Me.TabPage63.Controls.Add(Me.label383)
        Me.TabPage63.Controls.Add(Me.label384)
        Me.TabPage63.Controls.Add(Me.label385)
        Me.TabPage63.Controls.Add(Me.label386)
        Me.TabPage63.Controls.Add(Me.tbGPUContrast)
        Me.TabPage63.Controls.Add(Me.tbGPUDarkness)
        Me.TabPage63.Controls.Add(Me.tbGPULightness)
        Me.TabPage63.Controls.Add(Me.tbGPUSaturation)
        Me.TabPage63.Controls.Add(Me.cbGPUInvert)
        Me.TabPage63.Controls.Add(Me.cbGPUGreyscale)
        Me.TabPage63.Location = New System.Drawing.Point(4, 22)
        Me.TabPage63.Name = "TabPage63"
        Me.TabPage63.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage63.Size = New System.Drawing.Size(290, 459)
        Me.TabPage63.TabIndex = 9
        Me.TabPage63.Text = "GPU effects"
        Me.TabPage63.UseVisualStyleBackColor = true
        '
        'label5
        '
        Me.label5.AutoSize = true
        Me.label5.Location = New System.Drawing.Point(11, 269)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(25, 13)
        Me.label5.TabIndex = 100
        Me.label5.Text = "Blur"
        '
        'tbGPUBlur
        '
        Me.tbGPUBlur.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUBlur.Location = New System.Drawing.Point(8, 285)
        Me.tbGPUBlur.Maximum = 30
        Me.tbGPUBlur.Name = "tbGPUBlur"
        Me.tbGPUBlur.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUBlur.TabIndex = 99
        '
        'cbVideoEffectsGPUEnabled
        '
        Me.cbVideoEffectsGPUEnabled.AutoSize = true
        Me.cbVideoEffectsGPUEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled"
        Me.cbVideoEffectsGPUEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbVideoEffectsGPUEnabled.TabIndex = 97
        Me.cbVideoEffectsGPUEnabled.Text = "Enabled"
        Me.cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = true
        '
        'cbGPUOldMovie
        '
        Me.cbGPUOldMovie.AutoSize = true
        Me.cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUOldMovie.Location = New System.Drawing.Point(142, 236)
        Me.cbGPUOldMovie.Name = "cbGPUOldMovie"
        Me.cbGPUOldMovie.Size = New System.Drawing.Size(73, 17)
        Me.cbGPUOldMovie.TabIndex = 96
        Me.cbGPUOldMovie.Text = "Old movie"
        Me.cbGPUOldMovie.UseVisualStyleBackColor = true
        '
        'cbGPUDeinterlace
        '
        Me.cbGPUDeinterlace.AutoSize = true
        Me.cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUDeinterlace.Location = New System.Drawing.Point(142, 212)
        Me.cbGPUDeinterlace.Name = "cbGPUDeinterlace"
        Me.cbGPUDeinterlace.Size = New System.Drawing.Size(80, 17)
        Me.cbGPUDeinterlace.TabIndex = 94
        Me.cbGPUDeinterlace.Text = "Deinterlace"
        Me.cbGPUDeinterlace.UseVisualStyleBackColor = true
        '
        'cbGPUDenoise
        '
        Me.cbGPUDenoise.AutoSize = true
        Me.cbGPUDenoise.Location = New System.Drawing.Point(14, 212)
        Me.cbGPUDenoise.Name = "cbGPUDenoise"
        Me.cbGPUDenoise.Size = New System.Drawing.Size(65, 17)
        Me.cbGPUDenoise.TabIndex = 93
        Me.cbGPUDenoise.Text = "Denoise"
        Me.cbGPUDenoise.UseVisualStyleBackColor = true
        '
        'cbGPUPixelate
        '
        Me.cbGPUPixelate.AutoSize = true
        Me.cbGPUPixelate.Location = New System.Drawing.Point(142, 189)
        Me.cbGPUPixelate.Name = "cbGPUPixelate"
        Me.cbGPUPixelate.Size = New System.Drawing.Size(63, 17)
        Me.cbGPUPixelate.TabIndex = 92
        Me.cbGPUPixelate.Text = "Pixelate"
        Me.cbGPUPixelate.UseVisualStyleBackColor = true
        '
        'cbGPUNightVision
        '
        Me.cbGPUNightVision.AutoSize = true
        Me.cbGPUNightVision.Location = New System.Drawing.Point(14, 189)
        Me.cbGPUNightVision.Name = "cbGPUNightVision"
        Me.cbGPUNightVision.Size = New System.Drawing.Size(81, 17)
        Me.cbGPUNightVision.TabIndex = 91
        Me.cbGPUNightVision.Text = "Night vision"
        Me.cbGPUNightVision.UseVisualStyleBackColor = true
        '
        'label383
        '
        Me.label383.AutoSize = true
        Me.label383.Location = New System.Drawing.Point(147, 96)
        Me.label383.Name = "label383"
        Me.label383.Size = New System.Drawing.Size(52, 13)
        Me.label383.TabIndex = 90
        Me.label383.Text = "Darkness"
        '
        'label384
        '
        Me.label384.AutoSize = true
        Me.label384.Location = New System.Drawing.Point(11, 96)
        Me.label384.Name = "label384"
        Me.label384.Size = New System.Drawing.Size(46, 13)
        Me.label384.TabIndex = 89
        Me.label384.Text = "Contrast"
        '
        'label385
        '
        Me.label385.AutoSize = true
        Me.label385.Location = New System.Drawing.Point(147, 44)
        Me.label385.Name = "label385"
        Me.label385.Size = New System.Drawing.Size(55, 13)
        Me.label385.TabIndex = 88
        Me.label385.Text = "Saturation"
        '
        'label386
        '
        Me.label386.AutoSize = true
        Me.label386.Location = New System.Drawing.Point(11, 44)
        Me.label386.Name = "label386"
        Me.label386.Size = New System.Drawing.Size(52, 13)
        Me.label386.TabIndex = 87
        Me.label386.Text = "Lightness"
        '
        'tbGPUContrast
        '
        Me.tbGPUContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUContrast.Location = New System.Drawing.Point(8, 115)
        Me.tbGPUContrast.Maximum = 255
        Me.tbGPUContrast.Name = "tbGPUContrast"
        Me.tbGPUContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUContrast.TabIndex = 86
        Me.tbGPUContrast.Value = 255
        '
        'tbGPUDarkness
        '
        Me.tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUDarkness.Location = New System.Drawing.Point(147, 115)
        Me.tbGPUDarkness.Maximum = 255
        Me.tbGPUDarkness.Name = "tbGPUDarkness"
        Me.tbGPUDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUDarkness.TabIndex = 85
        '
        'tbGPULightness
        '
        Me.tbGPULightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPULightness.Location = New System.Drawing.Point(8, 59)
        Me.tbGPULightness.Maximum = 255
        Me.tbGPULightness.Name = "tbGPULightness"
        Me.tbGPULightness.Size = New System.Drawing.Size(130, 45)
        Me.tbGPULightness.TabIndex = 84
        '
        'tbGPUSaturation
        '
        Me.tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUSaturation.Location = New System.Drawing.Point(147, 59)
        Me.tbGPUSaturation.Maximum = 255
        Me.tbGPUSaturation.Name = "tbGPUSaturation"
        Me.tbGPUSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUSaturation.TabIndex = 83
        Me.tbGPUSaturation.Value = 255
        '
        'cbGPUInvert
        '
        Me.cbGPUInvert.AutoSize = true
        Me.cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUInvert.Location = New System.Drawing.Point(142, 166)
        Me.cbGPUInvert.Name = "cbGPUInvert"
        Me.cbGPUInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbGPUInvert.TabIndex = 82
        Me.cbGPUInvert.Text = "Invert"
        Me.cbGPUInvert.UseVisualStyleBackColor = true
        '
        'cbGPUGreyscale
        '
        Me.cbGPUGreyscale.AutoSize = true
        Me.cbGPUGreyscale.Location = New System.Drawing.Point(14, 166)
        Me.cbGPUGreyscale.Name = "cbGPUGreyscale"
        Me.cbGPUGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGPUGreyscale.TabIndex = 81
        Me.cbGPUGreyscale.Text = "Greyscale"
        Me.cbGPUGreyscale.UseVisualStyleBackColor = true
        '
        'TabPage92
        '
        Me.TabPage92.Controls.Add(Me.label92)
        Me.TabPage92.Controls.Add(Me.cbRotate)
        Me.TabPage92.Controls.Add(Me.edCropRight)
        Me.TabPage92.Controls.Add(Me.label52)
        Me.TabPage92.Controls.Add(Me.edCropBottom)
        Me.TabPage92.Controls.Add(Me.label53)
        Me.TabPage92.Controls.Add(Me.edCropLeft)
        Me.TabPage92.Controls.Add(Me.label50)
        Me.TabPage92.Controls.Add(Me.edCropTop)
        Me.TabPage92.Controls.Add(Me.label51)
        Me.TabPage92.Controls.Add(Me.cbCrop)
        Me.TabPage92.Controls.Add(Me.cbResizeMode)
        Me.TabPage92.Controls.Add(Me.label49)
        Me.TabPage92.Controls.Add(Me.cbResizeLetterbox)
        Me.TabPage92.Controls.Add(Me.edResizeHeight)
        Me.TabPage92.Controls.Add(Me.label35)
        Me.TabPage92.Controls.Add(Me.edResizeWidth)
        Me.TabPage92.Controls.Add(Me.label29)
        Me.TabPage92.Controls.Add(Me.cbResize)
        Me.TabPage92.Location = New System.Drawing.Point(4, 22)
        Me.TabPage92.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage92.Name = "TabPage92"
        Me.TabPage92.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage92.Size = New System.Drawing.Size(290, 459)
        Me.TabPage92.TabIndex = 8
        Me.TabPage92.Text = "Resize / Crop"
        Me.TabPage92.UseVisualStyleBackColor = true
        '
        'label92
        '
        Me.label92.AutoSize = true
        Me.label92.Location = New System.Drawing.Point(10, 210)
        Me.label92.Name = "label92"
        Me.label92.Size = New System.Drawing.Size(39, 13)
        Me.label92.TabIndex = 169
        Me.label92.Text = "Rotate"
        '
        'cbRotate
        '
        Me.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRotate.FormattingEnabled = true
        Me.cbRotate.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.cbRotate.Location = New System.Drawing.Point(74, 207)
        Me.cbRotate.Name = "cbRotate"
        Me.cbRotate.Size = New System.Drawing.Size(121, 21)
        Me.cbRotate.TabIndex = 168
        '
        'edCropRight
        '
        Me.edCropRight.Location = New System.Drawing.Point(170, 178)
        Me.edCropRight.Name = "edCropRight"
        Me.edCropRight.Size = New System.Drawing.Size(36, 20)
        Me.edCropRight.TabIndex = 167
        Me.edCropRight.Text = "0"
        '
        'label52
        '
        Me.label52.AutoSize = true
        Me.label52.Location = New System.Drawing.Point(128, 181)
        Me.label52.Name = "label52"
        Me.label52.Size = New System.Drawing.Size(32, 13)
        Me.label52.TabIndex = 166
        Me.label52.Text = "Right"
        '
        'edCropBottom
        '
        Me.edCropBottom.Location = New System.Drawing.Point(74, 178)
        Me.edCropBottom.Name = "edCropBottom"
        Me.edCropBottom.Size = New System.Drawing.Size(36, 20)
        Me.edCropBottom.TabIndex = 165
        Me.edCropBottom.Text = "0"
        '
        'label53
        '
        Me.label53.AutoSize = true
        Me.label53.Location = New System.Drawing.Point(28, 181)
        Me.label53.Name = "label53"
        Me.label53.Size = New System.Drawing.Size(40, 13)
        Me.label53.TabIndex = 164
        Me.label53.Text = "Bottom"
        '
        'edCropLeft
        '
        Me.edCropLeft.Location = New System.Drawing.Point(170, 152)
        Me.edCropLeft.Name = "edCropLeft"
        Me.edCropLeft.Size = New System.Drawing.Size(36, 20)
        Me.edCropLeft.TabIndex = 163
        Me.edCropLeft.Text = "0"
        '
        'label50
        '
        Me.label50.AutoSize = true
        Me.label50.Location = New System.Drawing.Point(128, 155)
        Me.label50.Name = "label50"
        Me.label50.Size = New System.Drawing.Size(25, 13)
        Me.label50.TabIndex = 162
        Me.label50.Text = "Left"
        '
        'edCropTop
        '
        Me.edCropTop.Location = New System.Drawing.Point(74, 152)
        Me.edCropTop.Name = "edCropTop"
        Me.edCropTop.Size = New System.Drawing.Size(36, 20)
        Me.edCropTop.TabIndex = 161
        Me.edCropTop.Text = "0"
        '
        'label51
        '
        Me.label51.AutoSize = true
        Me.label51.Location = New System.Drawing.Point(28, 155)
        Me.label51.Name = "label51"
        Me.label51.Size = New System.Drawing.Size(26, 13)
        Me.label51.TabIndex = 160
        Me.label51.Text = "Top"
        '
        'cbCrop
        '
        Me.cbCrop.AutoSize = true
        Me.cbCrop.Location = New System.Drawing.Point(14, 129)
        Me.cbCrop.Name = "cbCrop"
        Me.cbCrop.Size = New System.Drawing.Size(48, 17)
        Me.cbCrop.TabIndex = 159
        Me.cbCrop.Text = "Crop"
        Me.cbCrop.UseVisualStyleBackColor = true
        '
        'cbResizeMode
        '
        Me.cbResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResizeMode.FormattingEnabled = true
        Me.cbResizeMode.Items.AddRange(New Object() {"Nearest Neighbor", "Bilinear", "Bicubic", "Lancroz"})
        Me.cbResizeMode.Location = New System.Drawing.Point(63, 93)
        Me.cbResizeMode.Name = "cbResizeMode"
        Me.cbResizeMode.Size = New System.Drawing.Size(125, 21)
        Me.cbResizeMode.TabIndex = 158
        '
        'label49
        '
        Me.label49.AutoSize = true
        Me.label49.Location = New System.Drawing.Point(21, 96)
        Me.label49.Name = "label49"
        Me.label49.Size = New System.Drawing.Size(34, 13)
        Me.label49.TabIndex = 157
        Me.label49.Text = "Mode"
        '
        'cbResizeLetterbox
        '
        Me.cbResizeLetterbox.AutoSize = true
        Me.cbResizeLetterbox.Location = New System.Drawing.Point(24, 67)
        Me.cbResizeLetterbox.Name = "cbResizeLetterbox"
        Me.cbResizeLetterbox.Size = New System.Drawing.Size(164, 17)
        Me.cbResizeLetterbox.TabIndex = 156
        Me.cbResizeLetterbox.Text = "Letterbox (add black borders)"
        Me.cbResizeLetterbox.UseVisualStyleBackColor = true
        '
        'edResizeHeight
        '
        Me.edResizeHeight.Location = New System.Drawing.Point(152, 37)
        Me.edResizeHeight.Name = "edResizeHeight"
        Me.edResizeHeight.Size = New System.Drawing.Size(36, 20)
        Me.edResizeHeight.TabIndex = 155
        Me.edResizeHeight.Text = "576"
        '
        'label35
        '
        Me.label35.AutoSize = true
        Me.label35.Location = New System.Drawing.Point(105, 41)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(38, 13)
        Me.label35.TabIndex = 154
        Me.label35.Text = "Height"
        '
        'edResizeWidth
        '
        Me.edResizeWidth.Location = New System.Drawing.Point(63, 37)
        Me.edResizeWidth.Name = "edResizeWidth"
        Me.edResizeWidth.Size = New System.Drawing.Size(36, 20)
        Me.edResizeWidth.TabIndex = 153
        Me.edResizeWidth.Text = "768"
        '
        'label29
        '
        Me.label29.AutoSize = true
        Me.label29.Location = New System.Drawing.Point(21, 41)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(35, 13)
        Me.label29.TabIndex = 152
        Me.label29.Text = "Width"
        '
        'cbResize
        '
        Me.cbResize.AutoSize = true
        Me.cbResize.Location = New System.Drawing.Point(14, 15)
        Me.cbResize.Name = "cbResize"
        Me.cbResize.Size = New System.Drawing.Size(58, 17)
        Me.cbResize.TabIndex = 151
        Me.cbResize.Text = "Resize"
        Me.cbResize.UseVisualStyleBackColor = true
        '
        'TabPage60
        '
        Me.TabPage60.Controls.Add(Me.pnChromaKeyColor)
        Me.TabPage60.Controls.Add(Me.btChromaKeySelectBGImage)
        Me.TabPage60.Controls.Add(Me.edChromaKeyImage)
        Me.TabPage60.Controls.Add(Me.label216)
        Me.TabPage60.Controls.Add(Me.label215)
        Me.TabPage60.Controls.Add(Me.tbChromaKeySmoothing)
        Me.TabPage60.Controls.Add(Me.label214)
        Me.TabPage60.Controls.Add(Me.tbChromaKeyThresholdSensitivity)
        Me.TabPage60.Controls.Add(Me.label213)
        Me.TabPage60.Controls.Add(Me.cbChromaKeyEnabled)
        Me.TabPage60.Location = New System.Drawing.Point(4, 22)
        Me.TabPage60.Name = "TabPage60"
        Me.TabPage60.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage60.Size = New System.Drawing.Size(290, 459)
        Me.TabPage60.TabIndex = 5
        Me.TabPage60.Text = "Chroma Key"
        Me.TabPage60.UseVisualStyleBackColor = true
        '
        'pnChromaKeyColor
        '
        Me.pnChromaKeyColor.BackColor = System.Drawing.Color.Lime
        Me.pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control
        Me.pnChromaKeyColor.Location = New System.Drawing.Point(53, 200)
        Me.pnChromaKeyColor.Name = "pnChromaKeyColor"
        Me.pnChromaKeyColor.Size = New System.Drawing.Size(26, 24)
        Me.pnChromaKeyColor.TabIndex = 43
        '
        'btChromaKeySelectBGImage
        '
        Me.btChromaKeySelectBGImage.Location = New System.Drawing.Point(253, 262)
        Me.btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage"
        Me.btChromaKeySelectBGImage.Size = New System.Drawing.Size(24, 23)
        Me.btChromaKeySelectBGImage.TabIndex = 42
        Me.btChromaKeySelectBGImage.Text = "..."
        Me.btChromaKeySelectBGImage.UseVisualStyleBackColor = true
        '
        'edChromaKeyImage
        '
        Me.edChromaKeyImage.Location = New System.Drawing.Point(11, 264)
        Me.edChromaKeyImage.Name = "edChromaKeyImage"
        Me.edChromaKeyImage.Size = New System.Drawing.Size(235, 20)
        Me.edChromaKeyImage.TabIndex = 41
        Me.edChromaKeyImage.Text = "c:\Samples\pics\1.jpg"
        '
        'label216
        '
        Me.label216.AutoSize = true
        Me.label216.Location = New System.Drawing.Point(8, 248)
        Me.label216.Name = "label216"
        Me.label216.Size = New System.Drawing.Size(112, 13)
        Me.label216.TabIndex = 40
        Me.label216.Text = "Image background file"
        '
        'label215
        '
        Me.label215.AutoSize = true
        Me.label215.Location = New System.Drawing.Point(8, 204)
        Me.label215.Name = "label215"
        Me.label215.Size = New System.Drawing.Size(31, 13)
        Me.label215.TabIndex = 39
        Me.label215.Text = "Color"
        '
        'tbChromaKeySmoothing
        '
        Me.tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window
        Me.tbChromaKeySmoothing.Location = New System.Drawing.Point(11, 145)
        Me.tbChromaKeySmoothing.Maximum = 1000
        Me.tbChromaKeySmoothing.Name = "tbChromaKeySmoothing"
        Me.tbChromaKeySmoothing.Size = New System.Drawing.Size(154, 45)
        Me.tbChromaKeySmoothing.TabIndex = 38
        Me.tbChromaKeySmoothing.Value = 80
        '
        'label214
        '
        Me.label214.AutoSize = true
        Me.label214.Location = New System.Drawing.Point(8, 127)
        Me.label214.Name = "label214"
        Me.label214.Size = New System.Drawing.Size(57, 13)
        Me.label214.TabIndex = 37
        Me.label214.Text = "Smoothing"
        '
        'tbChromaKeyThresholdSensitivity
        '
        Me.tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window
        Me.tbChromaKeyThresholdSensitivity.Location = New System.Drawing.Point(11, 72)
        Me.tbChromaKeyThresholdSensitivity.Maximum = 200
        Me.tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity"
        Me.tbChromaKeyThresholdSensitivity.Size = New System.Drawing.Size(154, 45)
        Me.tbChromaKeyThresholdSensitivity.TabIndex = 36
        Me.tbChromaKeyThresholdSensitivity.Value = 180
        '
        'label213
        '
        Me.label213.AutoSize = true
        Me.label213.Location = New System.Drawing.Point(8, 54)
        Me.label213.Name = "label213"
        Me.label213.Size = New System.Drawing.Size(102, 13)
        Me.label213.TabIndex = 35
        Me.label213.Text = "Threshold sensitivity"
        '
        'cbChromaKeyEnabled
        '
        Me.cbChromaKeyEnabled.AutoSize = true
        Me.cbChromaKeyEnabled.Location = New System.Drawing.Point(11, 15)
        Me.cbChromaKeyEnabled.Name = "cbChromaKeyEnabled"
        Me.cbChromaKeyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbChromaKeyEnabled.TabIndex = 34
        Me.cbChromaKeyEnabled.Text = "Enabled"
        Me.cbChromaKeyEnabled.UseVisualStyleBackColor = true
        '
        'tabPage70
        '
        Me.tabPage70.Controls.Add(Me.btFilterDeleteAll)
        Me.tabPage70.Controls.Add(Me.btFilterSettings2)
        Me.tabPage70.Controls.Add(Me.lbFilters)
        Me.tabPage70.Controls.Add(Me.label106)
        Me.tabPage70.Controls.Add(Me.btFilterSettings)
        Me.tabPage70.Controls.Add(Me.btFilterAdd)
        Me.tabPage70.Controls.Add(Me.cbFilters)
        Me.tabPage70.Controls.Add(Me.label105)
        Me.tabPage70.Location = New System.Drawing.Point(4, 22)
        Me.tabPage70.Name = "tabPage70"
        Me.tabPage70.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage70.Size = New System.Drawing.Size(290, 459)
        Me.tabPage70.TabIndex = 3
        Me.tabPage70.Text = "3rd-party filters"
        Me.tabPage70.UseVisualStyleBackColor = true
        '
        'btFilterDeleteAll
        '
        Me.btFilterDeleteAll.Location = New System.Drawing.Point(210, 287)
        Me.btFilterDeleteAll.Name = "btFilterDeleteAll"
        Me.btFilterDeleteAll.Size = New System.Drawing.Size(68, 23)
        Me.btFilterDeleteAll.TabIndex = 16
        Me.btFilterDeleteAll.Text = "Delete all"
        Me.btFilterDeleteAll.UseVisualStyleBackColor = true
        '
        'btFilterSettings2
        '
        Me.btFilterSettings2.Location = New System.Drawing.Point(18, 287)
        Me.btFilterSettings2.Name = "btFilterSettings2"
        Me.btFilterSettings2.Size = New System.Drawing.Size(65, 23)
        Me.btFilterSettings2.TabIndex = 15
        Me.btFilterSettings2.Text = "Settings"
        Me.btFilterSettings2.UseVisualStyleBackColor = true
        '
        'lbFilters
        '
        Me.lbFilters.FormattingEnabled = true
        Me.lbFilters.Location = New System.Drawing.Point(18, 121)
        Me.lbFilters.Name = "lbFilters"
        Me.lbFilters.Size = New System.Drawing.Size(260, 160)
        Me.lbFilters.TabIndex = 14
        '
        'label106
        '
        Me.label106.AutoSize = true
        Me.label106.Location = New System.Drawing.Point(15, 105)
        Me.label106.Name = "label106"
        Me.label106.Size = New System.Drawing.Size(68, 13)
        Me.label106.TabIndex = 13
        Me.label106.Text = "Current filters"
        '
        'btFilterSettings
        '
        Me.btFilterSettings.Location = New System.Drawing.Point(210, 57)
        Me.btFilterSettings.Name = "btFilterSettings"
        Me.btFilterSettings.Size = New System.Drawing.Size(68, 23)
        Me.btFilterSettings.TabIndex = 12
        Me.btFilterSettings.Text = "Settings"
        Me.btFilterSettings.UseVisualStyleBackColor = true
        '
        'btFilterAdd
        '
        Me.btFilterAdd.Location = New System.Drawing.Point(18, 57)
        Me.btFilterAdd.Name = "btFilterAdd"
        Me.btFilterAdd.Size = New System.Drawing.Size(39, 23)
        Me.btFilterAdd.TabIndex = 11
        Me.btFilterAdd.Text = "Add"
        Me.btFilterAdd.UseVisualStyleBackColor = true
        '
        'cbFilters
        '
        Me.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilters.FormattingEnabled = true
        Me.cbFilters.Location = New System.Drawing.Point(18, 30)
        Me.cbFilters.Name = "cbFilters"
        Me.cbFilters.Size = New System.Drawing.Size(260, 21)
        Me.cbFilters.TabIndex = 10
        '
        'label105
        '
        Me.label105.AutoSize = true
        Me.label105.Location = New System.Drawing.Point(15, 14)
        Me.label105.Name = "label105"
        Me.label105.Size = New System.Drawing.Size(34, 13)
        Me.label105.TabIndex = 9
        Me.label105.Text = "Filters"
        '
        'tabControl14
        '
        Me.tabControl14.Controls.Add(Me.tabPage5)
        Me.tabControl14.Controls.Add(Me.tabPage58)
        Me.tabControl14.Location = New System.Drawing.Point(284, 7)
        Me.tabControl14.Name = "tabControl14"
        Me.tabControl14.SelectedIndex = 0
        Me.tabControl14.Size = New System.Drawing.Size(17, 46)
        Me.tabControl14.TabIndex = 36
        '
        'tabPage5
        '
        Me.tabPage5.Location = New System.Drawing.Point(4, 22)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage5.Size = New System.Drawing.Size(9, 20)
        Me.tabPage5.TabIndex = 0
        Me.tabPage5.Text = "tabPage5"
        Me.tabPage5.UseVisualStyleBackColor = true
        '
        'tabPage58
        '
        Me.tabPage58.Location = New System.Drawing.Point(4, 22)
        Me.tabPage58.Name = "tabPage58"
        Me.tabPage58.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage58.Size = New System.Drawing.Size(9, 20)
        Me.tabPage58.TabIndex = 1
        Me.tabPage58.Text = "tabPage58"
        Me.tabPage58.UseVisualStyleBackColor = true
        '
        'tabPage27
        '
        Me.tabPage27.Controls.Add(Me.Label250)
        Me.tabPage27.Controls.Add(Me.tabControl18)
        Me.tabPage27.Controls.Add(Me.cbAudioEffectsEnabled)
        Me.tabPage27.Location = New System.Drawing.Point(4, 22)
        Me.tabPage27.Name = "tabPage27"
        Me.tabPage27.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage27.Size = New System.Drawing.Size(307, 484)
        Me.tabPage27.TabIndex = 12
        Me.tabPage27.Text = "Audio effects"
        Me.tabPage27.UseVisualStyleBackColor = true
        '
        'Label250
        '
        Me.Label250.AutoSize = true
        Me.Label250.Location = New System.Drawing.Point(105, 17)
        Me.Label250.Name = "Label250"
        Me.Label250.Size = New System.Drawing.Size(188, 13)
        Me.Label250.TabIndex = 5
        Me.Label250.Text = "Much more effects available using API"
        '
        'tabControl18
        '
        Me.tabControl18.Controls.Add(Me.tabPage71)
        Me.tabControl18.Controls.Add(Me.tabPage72)
        Me.tabControl18.Controls.Add(Me.tabPage73)
        Me.tabControl18.Controls.Add(Me.tabPage75)
        Me.tabControl18.Controls.Add(Me.tabPage76)
        Me.tabControl18.Location = New System.Drawing.Point(14, 36)
        Me.tabControl18.Name = "tabControl18"
        Me.tabControl18.SelectedIndex = 0
        Me.tabControl18.Size = New System.Drawing.Size(283, 442)
        Me.tabControl18.TabIndex = 1
        '
        'tabPage71
        '
        Me.tabPage71.Controls.Add(Me.label231)
        Me.tabPage71.Controls.Add(Me.label230)
        Me.tabPage71.Controls.Add(Me.tbAudAmplifyAmp)
        Me.tabPage71.Controls.Add(Me.label95)
        Me.tabPage71.Controls.Add(Me.cbAudAmplifyEnabled)
        Me.tabPage71.Location = New System.Drawing.Point(4, 22)
        Me.tabPage71.Name = "tabPage71"
        Me.tabPage71.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage71.Size = New System.Drawing.Size(275, 416)
        Me.tabPage71.TabIndex = 0
        Me.tabPage71.Text = "Amplify"
        Me.tabPage71.UseVisualStyleBackColor = true
        '
        'label231
        '
        Me.label231.AutoSize = true
        Me.label231.Location = New System.Drawing.Point(213, 53)
        Me.label231.Name = "label231"
        Me.label231.Size = New System.Drawing.Size(33, 13)
        Me.label231.TabIndex = 5
        Me.label231.Text = "400%"
        '
        'label230
        '
        Me.label230.AutoSize = true
        Me.label230.Location = New System.Drawing.Point(68, 53)
        Me.label230.Name = "label230"
        Me.label230.Size = New System.Drawing.Size(33, 13)
        Me.label230.TabIndex = 4
        Me.label230.Text = "100%"
        '
        'tbAudAmplifyAmp
        '
        Me.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudAmplifyAmp.Location = New System.Drawing.Point(16, 69)
        Me.tbAudAmplifyAmp.Maximum = 4000
        Me.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp"
        Me.tbAudAmplifyAmp.Size = New System.Drawing.Size(230, 45)
        Me.tbAudAmplifyAmp.TabIndex = 3
        Me.tbAudAmplifyAmp.TickFrequency = 50
        Me.tbAudAmplifyAmp.Value = 1000
        '
        'label95
        '
        Me.label95.AutoSize = true
        Me.label95.Location = New System.Drawing.Point(13, 53)
        Me.label95.Name = "label95"
        Me.label95.Size = New System.Drawing.Size(42, 13)
        Me.label95.TabIndex = 2
        Me.label95.Text = "Volume"
        '
        'cbAudAmplifyEnabled
        '
        Me.cbAudAmplifyEnabled.AutoSize = true
        Me.cbAudAmplifyEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled"
        Me.cbAudAmplifyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudAmplifyEnabled.TabIndex = 1
        Me.cbAudAmplifyEnabled.Text = "Enabled"
        Me.cbAudAmplifyEnabled.UseVisualStyleBackColor = true
        '
        'tabPage72
        '
        Me.tabPage72.Controls.Add(Me.btAudEqRefresh)
        Me.tabPage72.Controls.Add(Me.cbAudEqualizerPreset)
        Me.tabPage72.Controls.Add(Me.label243)
        Me.tabPage72.Controls.Add(Me.label242)
        Me.tabPage72.Controls.Add(Me.label241)
        Me.tabPage72.Controls.Add(Me.label240)
        Me.tabPage72.Controls.Add(Me.label239)
        Me.tabPage72.Controls.Add(Me.label238)
        Me.tabPage72.Controls.Add(Me.label237)
        Me.tabPage72.Controls.Add(Me.label236)
        Me.tabPage72.Controls.Add(Me.label235)
        Me.tabPage72.Controls.Add(Me.label234)
        Me.tabPage72.Controls.Add(Me.label233)
        Me.tabPage72.Controls.Add(Me.label232)
        Me.tabPage72.Controls.Add(Me.tbAudEq9)
        Me.tabPage72.Controls.Add(Me.tbAudEq8)
        Me.tabPage72.Controls.Add(Me.tbAudEq7)
        Me.tabPage72.Controls.Add(Me.tbAudEq6)
        Me.tabPage72.Controls.Add(Me.tbAudEq5)
        Me.tabPage72.Controls.Add(Me.tbAudEq4)
        Me.tabPage72.Controls.Add(Me.tbAudEq3)
        Me.tabPage72.Controls.Add(Me.tbAudEq2)
        Me.tabPage72.Controls.Add(Me.tbAudEq1)
        Me.tabPage72.Controls.Add(Me.tbAudEq0)
        Me.tabPage72.Controls.Add(Me.cbAudEqualizerEnabled)
        Me.tabPage72.Location = New System.Drawing.Point(4, 22)
        Me.tabPage72.Name = "tabPage72"
        Me.tabPage72.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage72.Size = New System.Drawing.Size(275, 416)
        Me.tabPage72.TabIndex = 1
        Me.tabPage72.Text = "Equlizer"
        Me.tabPage72.UseVisualStyleBackColor = true
        '
        'btAudEqRefresh
        '
        Me.btAudEqRefresh.Location = New System.Drawing.Point(175, 219)
        Me.btAudEqRefresh.Name = "btAudEqRefresh"
        Me.btAudEqRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btAudEqRefresh.TabIndex = 26
        Me.btAudEqRefresh.Text = "Refresh"
        Me.btAudEqRefresh.UseVisualStyleBackColor = true
        '
        'cbAudEqualizerPreset
        '
        Me.cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudEqualizerPreset.FormattingEnabled = true
        Me.cbAudEqualizerPreset.Location = New System.Drawing.Point(61, 180)
        Me.cbAudEqualizerPreset.Name = "cbAudEqualizerPreset"
        Me.cbAudEqualizerPreset.Size = New System.Drawing.Size(189, 21)
        Me.cbAudEqualizerPreset.TabIndex = 25
        '
        'label243
        '
        Me.label243.AutoSize = true
        Me.label243.Location = New System.Drawing.Point(14, 183)
        Me.label243.Name = "label243"
        Me.label243.Size = New System.Drawing.Size(37, 13)
        Me.label243.TabIndex = 24
        Me.label243.Text = "Preset"
        '
        'label242
        '
        Me.label242.AutoSize = true
        Me.label242.Location = New System.Drawing.Point(206, 156)
        Me.label242.Name = "label242"
        Me.label242.Size = New System.Drawing.Size(26, 13)
        Me.label242.TabIndex = 23
        Me.label242.Text = "16K"
        '
        'label241
        '
        Me.label241.AutoSize = true
        Me.label241.Location = New System.Drawing.Point(184, 156)
        Me.label241.Name = "label241"
        Me.label241.Size = New System.Drawing.Size(26, 13)
        Me.label241.TabIndex = 22
        Me.label241.Text = "14K"
        '
        'label240
        '
        Me.label240.AutoSize = true
        Me.label240.Location = New System.Drawing.Point(162, 156)
        Me.label240.Name = "label240"
        Me.label240.Size = New System.Drawing.Size(26, 13)
        Me.label240.TabIndex = 21
        Me.label240.Text = "12K"
        '
        'label239
        '
        Me.label239.AutoSize = true
        Me.label239.Location = New System.Drawing.Point(143, 156)
        Me.label239.Name = "label239"
        Me.label239.Size = New System.Drawing.Size(20, 13)
        Me.label239.TabIndex = 20
        Me.label239.Text = "6K"
        '
        'label238
        '
        Me.label238.AutoSize = true
        Me.label238.Location = New System.Drawing.Point(121, 156)
        Me.label238.Name = "label238"
        Me.label238.Size = New System.Drawing.Size(20, 13)
        Me.label238.TabIndex = 19
        Me.label238.Text = "3K"
        '
        'label237
        '
        Me.label237.AutoSize = true
        Me.label237.Location = New System.Drawing.Point(102, 156)
        Me.label237.Name = "label237"
        Me.label237.Size = New System.Drawing.Size(20, 13)
        Me.label237.TabIndex = 18
        Me.label237.Text = "1K"
        '
        'label236
        '
        Me.label236.AutoSize = true
        Me.label236.Location = New System.Drawing.Point(80, 156)
        Me.label236.Name = "label236"
        Me.label236.Size = New System.Drawing.Size(25, 13)
        Me.label236.TabIndex = 17
        Me.label236.Text = "600"
        '
        'label235
        '
        Me.label235.AutoSize = true
        Me.label235.Location = New System.Drawing.Point(58, 156)
        Me.label235.Name = "label235"
        Me.label235.Size = New System.Drawing.Size(25, 13)
        Me.label235.TabIndex = 16
        Me.label235.Text = "310"
        '
        'label234
        '
        Me.label234.AutoSize = true
        Me.label234.Location = New System.Drawing.Point(36, 156)
        Me.label234.Name = "label234"
        Me.label234.Size = New System.Drawing.Size(25, 13)
        Me.label234.TabIndex = 15
        Me.label234.Text = "170"
        '
        'label233
        '
        Me.label233.AutoSize = true
        Me.label233.Location = New System.Drawing.Point(18, 156)
        Me.label233.Name = "label233"
        Me.label233.Size = New System.Drawing.Size(19, 13)
        Me.label233.TabIndex = 14
        Me.label233.Text = "60"
        '
        'label232
        '
        Me.label232.AutoSize = true
        Me.label232.Location = New System.Drawing.Point(118, 33)
        Me.label232.Name = "label232"
        Me.label232.Size = New System.Drawing.Size(13, 13)
        Me.label232.TabIndex = 13
        Me.label232.Text = "0"
        '
        'tbAudEq9
        '
        Me.tbAudEq9.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq9.Location = New System.Drawing.Point(205, 49)
        Me.tbAudEq9.Maximum = 100
        Me.tbAudEq9.Minimum = -100
        Me.tbAudEq9.Name = "tbAudEq9"
        Me.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq9.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq9.TabIndex = 12
        Me.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq8
        '
        Me.tbAudEq8.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq8.Location = New System.Drawing.Point(184, 49)
        Me.tbAudEq8.Maximum = 100
        Me.tbAudEq8.Minimum = -100
        Me.tbAudEq8.Name = "tbAudEq8"
        Me.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq8.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq8.TabIndex = 11
        Me.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq7
        '
        Me.tbAudEq7.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq7.Location = New System.Drawing.Point(162, 49)
        Me.tbAudEq7.Maximum = 100
        Me.tbAudEq7.Minimum = -100
        Me.tbAudEq7.Name = "tbAudEq7"
        Me.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq7.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq7.TabIndex = 10
        Me.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq6
        '
        Me.tbAudEq6.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq6.Location = New System.Drawing.Point(141, 49)
        Me.tbAudEq6.Maximum = 100
        Me.tbAudEq6.Minimum = -100
        Me.tbAudEq6.Name = "tbAudEq6"
        Me.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq6.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq6.TabIndex = 9
        Me.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq5
        '
        Me.tbAudEq5.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq5.Location = New System.Drawing.Point(120, 49)
        Me.tbAudEq5.Maximum = 100
        Me.tbAudEq5.Minimum = -100
        Me.tbAudEq5.Name = "tbAudEq5"
        Me.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq5.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq5.TabIndex = 8
        Me.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq4
        '
        Me.tbAudEq4.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq4.Location = New System.Drawing.Point(100, 49)
        Me.tbAudEq4.Maximum = 100
        Me.tbAudEq4.Minimum = -100
        Me.tbAudEq4.Name = "tbAudEq4"
        Me.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq4.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq4.TabIndex = 7
        Me.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq3
        '
        Me.tbAudEq3.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq3.Location = New System.Drawing.Point(79, 49)
        Me.tbAudEq3.Maximum = 100
        Me.tbAudEq3.Minimum = -100
        Me.tbAudEq3.Name = "tbAudEq3"
        Me.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq3.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq3.TabIndex = 6
        Me.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq2
        '
        Me.tbAudEq2.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq2.Location = New System.Drawing.Point(58, 49)
        Me.tbAudEq2.Maximum = 100
        Me.tbAudEq2.Minimum = -100
        Me.tbAudEq2.Name = "tbAudEq2"
        Me.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq2.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq2.TabIndex = 5
        Me.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq1
        '
        Me.tbAudEq1.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq1.Location = New System.Drawing.Point(37, 49)
        Me.tbAudEq1.Maximum = 100
        Me.tbAudEq1.Minimum = -100
        Me.tbAudEq1.Name = "tbAudEq1"
        Me.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq1.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq1.TabIndex = 4
        Me.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq0
        '
        Me.tbAudEq0.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq0.Location = New System.Drawing.Point(17, 49)
        Me.tbAudEq0.Maximum = 100
        Me.tbAudEq0.Minimum = -100
        Me.tbAudEq0.Name = "tbAudEq0"
        Me.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq0.Size = New System.Drawing.Size(45, 104)
        Me.tbAudEq0.TabIndex = 3
        Me.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'cbAudEqualizerEnabled
        '
        Me.cbAudEqualizerEnabled.AutoSize = true
        Me.cbAudEqualizerEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled"
        Me.cbAudEqualizerEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudEqualizerEnabled.TabIndex = 2
        Me.cbAudEqualizerEnabled.Text = "Enabled"
        Me.cbAudEqualizerEnabled.UseVisualStyleBackColor = true
        '
        'tabPage73
        '
        Me.tabPage73.Controls.Add(Me.tbAudRelease)
        Me.tabPage73.Controls.Add(Me.label248)
        Me.tabPage73.Controls.Add(Me.label249)
        Me.tabPage73.Controls.Add(Me.label246)
        Me.tabPage73.Controls.Add(Me.tbAudAttack)
        Me.tabPage73.Controls.Add(Me.label247)
        Me.tabPage73.Controls.Add(Me.label244)
        Me.tabPage73.Controls.Add(Me.tbAudDynAmp)
        Me.tabPage73.Controls.Add(Me.label245)
        Me.tabPage73.Controls.Add(Me.cbAudDynamicAmplifyEnabled)
        Me.tabPage73.Location = New System.Drawing.Point(4, 22)
        Me.tabPage73.Name = "tabPage73"
        Me.tabPage73.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage73.Size = New System.Drawing.Size(275, 416)
        Me.tabPage73.TabIndex = 2
        Me.tabPage73.Text = "Dynamic amplify"
        Me.tabPage73.UseVisualStyleBackColor = true
        '
        'tbAudRelease
        '
        Me.tbAudRelease.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudRelease.Location = New System.Drawing.Point(16, 209)
        Me.tbAudRelease.Maximum = 10000
        Me.tbAudRelease.Minimum = 10
        Me.tbAudRelease.Name = "tbAudRelease"
        Me.tbAudRelease.Size = New System.Drawing.Size(230, 45)
        Me.tbAudRelease.TabIndex = 15
        Me.tbAudRelease.TickFrequency = 250
        Me.tbAudRelease.Value = 10
        '
        'label248
        '
        Me.label248.AutoSize = true
        Me.label248.Location = New System.Drawing.Point(233, 193)
        Me.label248.Name = "label248"
        Me.label248.Size = New System.Drawing.Size(13, 13)
        Me.label248.TabIndex = 14
        Me.label248.Text = "0"
        '
        'label249
        '
        Me.label249.AutoSize = true
        Me.label249.Location = New System.Drawing.Point(13, 193)
        Me.label249.Name = "label249"
        Me.label249.Size = New System.Drawing.Size(68, 13)
        Me.label249.TabIndex = 12
        Me.label249.Text = "Release time"
        '
        'label246
        '
        Me.label246.AutoSize = true
        Me.label246.Location = New System.Drawing.Point(233, 121)
        Me.label246.Name = "label246"
        Me.label246.Size = New System.Drawing.Size(13, 13)
        Me.label246.TabIndex = 11
        Me.label246.Text = "0"
        '
        'tbAudAttack
        '
        Me.tbAudAttack.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudAttack.Location = New System.Drawing.Point(16, 137)
        Me.tbAudAttack.Maximum = 10000
        Me.tbAudAttack.Minimum = 10
        Me.tbAudAttack.Name = "tbAudAttack"
        Me.tbAudAttack.Size = New System.Drawing.Size(230, 45)
        Me.tbAudAttack.TabIndex = 10
        Me.tbAudAttack.TickFrequency = 250
        Me.tbAudAttack.Value = 10
        '
        'label247
        '
        Me.label247.AutoSize = true
        Me.label247.Location = New System.Drawing.Point(13, 121)
        Me.label247.Name = "label247"
        Me.label247.Size = New System.Drawing.Size(38, 13)
        Me.label247.TabIndex = 9
        Me.label247.Text = "Attack"
        '
        'label244
        '
        Me.label244.AutoSize = true
        Me.label244.Location = New System.Drawing.Point(233, 53)
        Me.label244.Name = "label244"
        Me.label244.Size = New System.Drawing.Size(13, 13)
        Me.label244.TabIndex = 8
        Me.label244.Text = "0"
        '
        'tbAudDynAmp
        '
        Me.tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudDynAmp.Location = New System.Drawing.Point(16, 69)
        Me.tbAudDynAmp.Maximum = 2000
        Me.tbAudDynAmp.Minimum = 100
        Me.tbAudDynAmp.Name = "tbAudDynAmp"
        Me.tbAudDynAmp.Size = New System.Drawing.Size(230, 45)
        Me.tbAudDynAmp.TabIndex = 7
        Me.tbAudDynAmp.TickFrequency = 50
        Me.tbAudDynAmp.Value = 1000
        '
        'label245
        '
        Me.label245.AutoSize = true
        Me.label245.Location = New System.Drawing.Point(13, 53)
        Me.label245.Name = "label245"
        Me.label245.Size = New System.Drawing.Size(112, 13)
        Me.label245.TabIndex = 6
        Me.label245.Text = "Maximum amplification"
        '
        'cbAudDynamicAmplifyEnabled
        '
        Me.cbAudDynamicAmplifyEnabled.AutoSize = true
        Me.cbAudDynamicAmplifyEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled"
        Me.cbAudDynamicAmplifyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudDynamicAmplifyEnabled.TabIndex = 2
        Me.cbAudDynamicAmplifyEnabled.Text = "Enabled"
        Me.cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = true
        '
        'tabPage75
        '
        Me.tabPage75.Controls.Add(Me.tbAud3DSound)
        Me.tabPage75.Controls.Add(Me.label253)
        Me.tabPage75.Controls.Add(Me.cbAudSound3DEnabled)
        Me.tabPage75.Location = New System.Drawing.Point(4, 22)
        Me.tabPage75.Name = "tabPage75"
        Me.tabPage75.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage75.Size = New System.Drawing.Size(275, 416)
        Me.tabPage75.TabIndex = 4
        Me.tabPage75.Text = "Sound 3D"
        Me.tabPage75.UseVisualStyleBackColor = true
        '
        'tbAud3DSound
        '
        Me.tbAud3DSound.BackColor = System.Drawing.SystemColors.Window
        Me.tbAud3DSound.Location = New System.Drawing.Point(16, 69)
        Me.tbAud3DSound.Maximum = 10000
        Me.tbAud3DSound.Name = "tbAud3DSound"
        Me.tbAud3DSound.Size = New System.Drawing.Size(230, 45)
        Me.tbAud3DSound.TabIndex = 19
        Me.tbAud3DSound.TickFrequency = 250
        Me.tbAud3DSound.Value = 500
        '
        'label253
        '
        Me.label253.AutoSize = true
        Me.label253.Location = New System.Drawing.Point(13, 53)
        Me.label253.Name = "label253"
        Me.label253.Size = New System.Drawing.Size(82, 13)
        Me.label253.TabIndex = 18
        Me.label253.Text = "3D amplification"
        '
        'cbAudSound3DEnabled
        '
        Me.cbAudSound3DEnabled.AutoSize = true
        Me.cbAudSound3DEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudSound3DEnabled.Name = "cbAudSound3DEnabled"
        Me.cbAudSound3DEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudSound3DEnabled.TabIndex = 2
        Me.cbAudSound3DEnabled.Text = "Enabled"
        Me.cbAudSound3DEnabled.UseVisualStyleBackColor = true
        '
        'tabPage76
        '
        Me.tabPage76.Controls.Add(Me.tbAudTrueBass)
        Me.tabPage76.Controls.Add(Me.label254)
        Me.tabPage76.Controls.Add(Me.cbAudTrueBassEnabled)
        Me.tabPage76.Location = New System.Drawing.Point(4, 22)
        Me.tabPage76.Name = "tabPage76"
        Me.tabPage76.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage76.Size = New System.Drawing.Size(275, 416)
        Me.tabPage76.TabIndex = 5
        Me.tabPage76.Text = "True Bass"
        Me.tabPage76.UseVisualStyleBackColor = true
        '
        'tbAudTrueBass
        '
        Me.tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudTrueBass.Location = New System.Drawing.Point(16, 69)
        Me.tbAudTrueBass.Maximum = 10000
        Me.tbAudTrueBass.Name = "tbAudTrueBass"
        Me.tbAudTrueBass.Size = New System.Drawing.Size(230, 45)
        Me.tbAudTrueBass.TabIndex = 21
        Me.tbAudTrueBass.TickFrequency = 250
        '
        'label254
        '
        Me.label254.AutoSize = true
        Me.label254.Location = New System.Drawing.Point(13, 53)
        Me.label254.Name = "label254"
        Me.label254.Size = New System.Drawing.Size(42, 13)
        Me.label254.TabIndex = 20
        Me.label254.Text = "Volume"
        '
        'cbAudTrueBassEnabled
        '
        Me.cbAudTrueBassEnabled.AutoSize = true
        Me.cbAudTrueBassEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled"
        Me.cbAudTrueBassEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudTrueBassEnabled.TabIndex = 2
        Me.cbAudTrueBassEnabled.Text = "Enabled"
        Me.cbAudTrueBassEnabled.UseVisualStyleBackColor = true
        '
        'cbAudioEffectsEnabled
        '
        Me.cbAudioEffectsEnabled.AutoSize = true
        Me.cbAudioEffectsEnabled.Location = New System.Drawing.Point(14, 16)
        Me.cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled"
        Me.cbAudioEffectsEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioEffectsEnabled.TabIndex = 0
        Me.cbAudioEffectsEnabled.Text = "Enabled"
        Me.cbAudioEffectsEnabled.UseVisualStyleBackColor = true
        '
        'TabPage124
        '
        Me.TabPage124.Controls.Add(Me.lbAudioTimeshift)
        Me.TabPage124.Controls.Add(Me.tbAudioTimeshift)
        Me.TabPage124.Controls.Add(Me.Label430)
        Me.TabPage124.Controls.Add(Me.GroupBox3)
        Me.TabPage124.Controls.Add(Me.GroupBox7)
        Me.TabPage124.Controls.Add(Me.cbAudioAutoGain)
        Me.TabPage124.Controls.Add(Me.cbAudioNormalize)
        Me.TabPage124.Controls.Add(Me.cbAudioEnhancementEnabled)
        Me.TabPage124.Location = New System.Drawing.Point(4, 22)
        Me.TabPage124.Name = "TabPage124"
        Me.TabPage124.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage124.Size = New System.Drawing.Size(307, 484)
        Me.TabPage124.TabIndex = 18
        Me.TabPage124.Text = "Audio enhancement"
        Me.TabPage124.UseVisualStyleBackColor = true
        '
        'lbAudioTimeshift
        '
        Me.lbAudioTimeshift.AutoSize = true
        Me.lbAudioTimeshift.Location = New System.Drawing.Point(178, 443)
        Me.lbAudioTimeshift.Name = "lbAudioTimeshift"
        Me.lbAudioTimeshift.Size = New System.Drawing.Size(29, 13)
        Me.lbAudioTimeshift.TabIndex = 28
        Me.lbAudioTimeshift.Text = "0 ms"
        '
        'tbAudioTimeshift
        '
        Me.tbAudioTimeshift.Location = New System.Drawing.Point(68, 432)
        Me.tbAudioTimeshift.Maximum = 3000
        Me.tbAudioTimeshift.Name = "tbAudioTimeshift"
        Me.tbAudioTimeshift.Size = New System.Drawing.Size(104, 45)
        Me.tbAudioTimeshift.SmallChange = 10
        Me.tbAudioTimeshift.TabIndex = 27
        Me.tbAudioTimeshift.TickFrequency = 100
        Me.tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label430
        '
        Me.Label430.AutoSize = true
        Me.Label430.Location = New System.Drawing.Point(7, 443)
        Me.Label430.Name = "Label430"
        Me.Label430.Size = New System.Drawing.Size(52, 13)
        Me.Label430.TabIndex = 26
        Me.Label430.Text = "Time shift"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainLFE)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainLFE)
        Me.GroupBox3.Controls.Add(Me.Label431)
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainSR)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainSR)
        Me.GroupBox3.Controls.Add(Me.Label439)
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainSL)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainSL)
        Me.GroupBox3.Controls.Add(Me.Label440)
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainR)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainR)
        Me.GroupBox3.Controls.Add(Me.Label441)
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainC)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainC)
        Me.GroupBox3.Controls.Add(Me.Label442)
        Me.GroupBox3.Controls.Add(Me.lbAudioOutputGainL)
        Me.GroupBox3.Controls.Add(Me.tbAudioOutputGainL)
        Me.GroupBox3.Controls.Add(Me.Label443)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 172)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Output gains (dB)"
        '
        'lbAudioOutputGainLFE
        '
        Me.lbAudioOutputGainLFE.AutoSize = true
        Me.lbAudioOutputGainLFE.Location = New System.Drawing.Point(249, 148)
        Me.lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE"
        Me.lbAudioOutputGainLFE.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainLFE.TabIndex = 17
        Me.lbAudioOutputGainLFE.Text = "0.0"
        '
        'tbAudioOutputGainLFE
        '
        Me.tbAudioOutputGainLFE.Location = New System.Drawing.Point(242, 41)
        Me.tbAudioOutputGainLFE.Maximum = 200
        Me.tbAudioOutputGainLFE.Minimum = -200
        Me.tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE"
        Me.tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainLFE.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainLFE.TabIndex = 16
        Me.tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label431
        '
        Me.Label431.AutoSize = true
        Me.Label431.Location = New System.Drawing.Point(250, 25)
        Me.Label431.Name = "Label431"
        Me.Label431.Size = New System.Drawing.Size(26, 13)
        Me.Label431.TabIndex = 15
        Me.Label431.Text = "LFE"
        '
        'lbAudioOutputGainSR
        '
        Me.lbAudioOutputGainSR.AutoSize = true
        Me.lbAudioOutputGainSR.Location = New System.Drawing.Point(201, 148)
        Me.lbAudioOutputGainSR.Name = "lbAudioOutputGainSR"
        Me.lbAudioOutputGainSR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainSR.TabIndex = 14
        Me.lbAudioOutputGainSR.Text = "0.0"
        '
        'tbAudioOutputGainSR
        '
        Me.tbAudioOutputGainSR.Location = New System.Drawing.Point(194, 41)
        Me.tbAudioOutputGainSR.Maximum = 200
        Me.tbAudioOutputGainSR.Minimum = -200
        Me.tbAudioOutputGainSR.Name = "tbAudioOutputGainSR"
        Me.tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainSR.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainSR.TabIndex = 13
        Me.tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label439
        '
        Me.Label439.AutoSize = true
        Me.Label439.Location = New System.Drawing.Point(205, 25)
        Me.Label439.Name = "Label439"
        Me.Label439.Size = New System.Drawing.Size(22, 13)
        Me.Label439.TabIndex = 12
        Me.Label439.Text = "SR"
        '
        'lbAudioOutputGainSL
        '
        Me.lbAudioOutputGainSL.AutoSize = true
        Me.lbAudioOutputGainSL.Location = New System.Drawing.Point(153, 148)
        Me.lbAudioOutputGainSL.Name = "lbAudioOutputGainSL"
        Me.lbAudioOutputGainSL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainSL.TabIndex = 11
        Me.lbAudioOutputGainSL.Text = "0.0"
        '
        'tbAudioOutputGainSL
        '
        Me.tbAudioOutputGainSL.Location = New System.Drawing.Point(146, 41)
        Me.tbAudioOutputGainSL.Maximum = 200
        Me.tbAudioOutputGainSL.Minimum = -200
        Me.tbAudioOutputGainSL.Name = "tbAudioOutputGainSL"
        Me.tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainSL.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainSL.TabIndex = 10
        Me.tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label440
        '
        Me.Label440.AutoSize = true
        Me.Label440.Location = New System.Drawing.Point(158, 25)
        Me.Label440.Name = "Label440"
        Me.Label440.Size = New System.Drawing.Size(20, 13)
        Me.Label440.TabIndex = 9
        Me.Label440.Text = "SL"
        '
        'lbAudioOutputGainR
        '
        Me.lbAudioOutputGainR.AutoSize = true
        Me.lbAudioOutputGainR.Location = New System.Drawing.Point(105, 148)
        Me.lbAudioOutputGainR.Name = "lbAudioOutputGainR"
        Me.lbAudioOutputGainR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainR.TabIndex = 8
        Me.lbAudioOutputGainR.Text = "0.0"
        '
        'tbAudioOutputGainR
        '
        Me.tbAudioOutputGainR.Location = New System.Drawing.Point(98, 41)
        Me.tbAudioOutputGainR.Maximum = 200
        Me.tbAudioOutputGainR.Minimum = -200
        Me.tbAudioOutputGainR.Name = "tbAudioOutputGainR"
        Me.tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainR.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainR.TabIndex = 7
        Me.tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label441
        '
        Me.Label441.AutoSize = true
        Me.Label441.Location = New System.Drawing.Point(114, 25)
        Me.Label441.Name = "Label441"
        Me.Label441.Size = New System.Drawing.Size(15, 13)
        Me.Label441.TabIndex = 6
        Me.Label441.Text = "R"
        '
        'lbAudioOutputGainC
        '
        Me.lbAudioOutputGainC.AutoSize = true
        Me.lbAudioOutputGainC.Location = New System.Drawing.Point(57, 148)
        Me.lbAudioOutputGainC.Name = "lbAudioOutputGainC"
        Me.lbAudioOutputGainC.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainC.TabIndex = 5
        Me.lbAudioOutputGainC.Text = "0.0"
        '
        'tbAudioOutputGainC
        '
        Me.tbAudioOutputGainC.Location = New System.Drawing.Point(50, 41)
        Me.tbAudioOutputGainC.Maximum = 200
        Me.tbAudioOutputGainC.Minimum = -200
        Me.tbAudioOutputGainC.Name = "tbAudioOutputGainC"
        Me.tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainC.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainC.TabIndex = 4
        Me.tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label442
        '
        Me.Label442.AutoSize = true
        Me.Label442.Location = New System.Drawing.Point(66, 25)
        Me.Label442.Name = "Label442"
        Me.Label442.Size = New System.Drawing.Size(14, 13)
        Me.Label442.TabIndex = 3
        Me.Label442.Text = "C"
        '
        'lbAudioOutputGainL
        '
        Me.lbAudioOutputGainL.AutoSize = true
        Me.lbAudioOutputGainL.Location = New System.Drawing.Point(9, 148)
        Me.lbAudioOutputGainL.Name = "lbAudioOutputGainL"
        Me.lbAudioOutputGainL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainL.TabIndex = 2
        Me.lbAudioOutputGainL.Text = "0.0"
        '
        'tbAudioOutputGainL
        '
        Me.tbAudioOutputGainL.Location = New System.Drawing.Point(2, 41)
        Me.tbAudioOutputGainL.Maximum = 200
        Me.tbAudioOutputGainL.Minimum = -200
        Me.tbAudioOutputGainL.Name = "tbAudioOutputGainL"
        Me.tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainL.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioOutputGainL.TabIndex = 1
        Me.tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label443
        '
        Me.Label443.AutoSize = true
        Me.Label443.Location = New System.Drawing.Point(18, 25)
        Me.Label443.Name = "Label443"
        Me.Label443.Size = New System.Drawing.Size(13, 13)
        Me.Label443.TabIndex = 0
        Me.Label443.Text = "L"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainLFE)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainLFE)
        Me.GroupBox7.Controls.Add(Me.Label444)
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainSR)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainSR)
        Me.GroupBox7.Controls.Add(Me.Label445)
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainSL)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainSL)
        Me.GroupBox7.Controls.Add(Me.Label446)
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainR)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainR)
        Me.GroupBox7.Controls.Add(Me.Label447)
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainC)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainC)
        Me.GroupBox7.Controls.Add(Me.Label448)
        Me.GroupBox7.Controls.Add(Me.lbAudioInputGainL)
        Me.GroupBox7.Controls.Add(Me.tbAudioInputGainL)
        Me.GroupBox7.Controls.Add(Me.Label449)
        Me.GroupBox7.Location = New System.Drawing.Point(10, 74)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(289, 172)
        Me.GroupBox7.TabIndex = 24
        Me.GroupBox7.TabStop = false
        Me.GroupBox7.Text = "Input gains (dB)"
        '
        'lbAudioInputGainLFE
        '
        Me.lbAudioInputGainLFE.AutoSize = true
        Me.lbAudioInputGainLFE.Location = New System.Drawing.Point(249, 148)
        Me.lbAudioInputGainLFE.Name = "lbAudioInputGainLFE"
        Me.lbAudioInputGainLFE.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainLFE.TabIndex = 17
        Me.lbAudioInputGainLFE.Text = "0.0"
        '
        'tbAudioInputGainLFE
        '
        Me.tbAudioInputGainLFE.Location = New System.Drawing.Point(242, 41)
        Me.tbAudioInputGainLFE.Maximum = 200
        Me.tbAudioInputGainLFE.Minimum = -200
        Me.tbAudioInputGainLFE.Name = "tbAudioInputGainLFE"
        Me.tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainLFE.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainLFE.TabIndex = 16
        Me.tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label444
        '
        Me.Label444.AutoSize = true
        Me.Label444.Location = New System.Drawing.Point(250, 25)
        Me.Label444.Name = "Label444"
        Me.Label444.Size = New System.Drawing.Size(26, 13)
        Me.Label444.TabIndex = 15
        Me.Label444.Text = "LFE"
        '
        'lbAudioInputGainSR
        '
        Me.lbAudioInputGainSR.AutoSize = true
        Me.lbAudioInputGainSR.Location = New System.Drawing.Point(201, 148)
        Me.lbAudioInputGainSR.Name = "lbAudioInputGainSR"
        Me.lbAudioInputGainSR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainSR.TabIndex = 14
        Me.lbAudioInputGainSR.Text = "0.0"
        '
        'tbAudioInputGainSR
        '
        Me.tbAudioInputGainSR.Location = New System.Drawing.Point(194, 41)
        Me.tbAudioInputGainSR.Maximum = 200
        Me.tbAudioInputGainSR.Minimum = -200
        Me.tbAudioInputGainSR.Name = "tbAudioInputGainSR"
        Me.tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainSR.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainSR.TabIndex = 13
        Me.tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label445
        '
        Me.Label445.AutoSize = true
        Me.Label445.Location = New System.Drawing.Point(205, 25)
        Me.Label445.Name = "Label445"
        Me.Label445.Size = New System.Drawing.Size(22, 13)
        Me.Label445.TabIndex = 12
        Me.Label445.Text = "SR"
        '
        'lbAudioInputGainSL
        '
        Me.lbAudioInputGainSL.AutoSize = true
        Me.lbAudioInputGainSL.Location = New System.Drawing.Point(153, 148)
        Me.lbAudioInputGainSL.Name = "lbAudioInputGainSL"
        Me.lbAudioInputGainSL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainSL.TabIndex = 11
        Me.lbAudioInputGainSL.Text = "0.0"
        '
        'tbAudioInputGainSL
        '
        Me.tbAudioInputGainSL.Location = New System.Drawing.Point(146, 41)
        Me.tbAudioInputGainSL.Maximum = 200
        Me.tbAudioInputGainSL.Minimum = -200
        Me.tbAudioInputGainSL.Name = "tbAudioInputGainSL"
        Me.tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainSL.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainSL.TabIndex = 10
        Me.tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label446
        '
        Me.Label446.AutoSize = true
        Me.Label446.Location = New System.Drawing.Point(158, 25)
        Me.Label446.Name = "Label446"
        Me.Label446.Size = New System.Drawing.Size(20, 13)
        Me.Label446.TabIndex = 9
        Me.Label446.Text = "SL"
        '
        'lbAudioInputGainR
        '
        Me.lbAudioInputGainR.AutoSize = true
        Me.lbAudioInputGainR.Location = New System.Drawing.Point(105, 148)
        Me.lbAudioInputGainR.Name = "lbAudioInputGainR"
        Me.lbAudioInputGainR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainR.TabIndex = 8
        Me.lbAudioInputGainR.Text = "0.0"
        '
        'tbAudioInputGainR
        '
        Me.tbAudioInputGainR.Location = New System.Drawing.Point(98, 41)
        Me.tbAudioInputGainR.Maximum = 200
        Me.tbAudioInputGainR.Minimum = -200
        Me.tbAudioInputGainR.Name = "tbAudioInputGainR"
        Me.tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainR.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainR.TabIndex = 7
        Me.tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label447
        '
        Me.Label447.AutoSize = true
        Me.Label447.Location = New System.Drawing.Point(114, 25)
        Me.Label447.Name = "Label447"
        Me.Label447.Size = New System.Drawing.Size(15, 13)
        Me.Label447.TabIndex = 6
        Me.Label447.Text = "R"
        '
        'lbAudioInputGainC
        '
        Me.lbAudioInputGainC.AutoSize = true
        Me.lbAudioInputGainC.Location = New System.Drawing.Point(57, 148)
        Me.lbAudioInputGainC.Name = "lbAudioInputGainC"
        Me.lbAudioInputGainC.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainC.TabIndex = 5
        Me.lbAudioInputGainC.Text = "0.0"
        '
        'tbAudioInputGainC
        '
        Me.tbAudioInputGainC.Location = New System.Drawing.Point(50, 41)
        Me.tbAudioInputGainC.Maximum = 200
        Me.tbAudioInputGainC.Minimum = -200
        Me.tbAudioInputGainC.Name = "tbAudioInputGainC"
        Me.tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainC.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainC.TabIndex = 4
        Me.tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label448
        '
        Me.Label448.AutoSize = true
        Me.Label448.Location = New System.Drawing.Point(66, 25)
        Me.Label448.Name = "Label448"
        Me.Label448.Size = New System.Drawing.Size(14, 13)
        Me.Label448.TabIndex = 3
        Me.Label448.Text = "C"
        '
        'lbAudioInputGainL
        '
        Me.lbAudioInputGainL.AutoSize = true
        Me.lbAudioInputGainL.Location = New System.Drawing.Point(9, 148)
        Me.lbAudioInputGainL.Name = "lbAudioInputGainL"
        Me.lbAudioInputGainL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainL.TabIndex = 2
        Me.lbAudioInputGainL.Text = "0.0"
        '
        'tbAudioInputGainL
        '
        Me.tbAudioInputGainL.Location = New System.Drawing.Point(2, 41)
        Me.tbAudioInputGainL.Maximum = 200
        Me.tbAudioInputGainL.Minimum = -200
        Me.tbAudioInputGainL.Name = "tbAudioInputGainL"
        Me.tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainL.Size = New System.Drawing.Size(45, 104)
        Me.tbAudioInputGainL.TabIndex = 1
        Me.tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label449
        '
        Me.Label449.AutoSize = true
        Me.Label449.Location = New System.Drawing.Point(18, 25)
        Me.Label449.Name = "Label449"
        Me.Label449.Size = New System.Drawing.Size(13, 13)
        Me.Label449.TabIndex = 0
        Me.Label449.Text = "L"
        '
        'cbAudioAutoGain
        '
        Me.cbAudioAutoGain.AutoSize = true
        Me.cbAudioAutoGain.Location = New System.Drawing.Point(137, 40)
        Me.cbAudioAutoGain.Name = "cbAudioAutoGain"
        Me.cbAudioAutoGain.Size = New System.Drawing.Size(71, 17)
        Me.cbAudioAutoGain.TabIndex = 23
        Me.cbAudioAutoGain.Text = "Auto gain"
        Me.cbAudioAutoGain.UseVisualStyleBackColor = true
        '
        'cbAudioNormalize
        '
        Me.cbAudioNormalize.AutoSize = true
        Me.cbAudioNormalize.Location = New System.Drawing.Point(43, 40)
        Me.cbAudioNormalize.Name = "cbAudioNormalize"
        Me.cbAudioNormalize.Size = New System.Drawing.Size(72, 17)
        Me.cbAudioNormalize.TabIndex = 22
        Me.cbAudioNormalize.Text = "Normalize"
        Me.cbAudioNormalize.UseVisualStyleBackColor = true
        '
        'cbAudioEnhancementEnabled
        '
        Me.cbAudioEnhancementEnabled.AutoSize = true
        Me.cbAudioEnhancementEnabled.Location = New System.Drawing.Point(20, 8)
        Me.cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled"
        Me.cbAudioEnhancementEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioEnhancementEnabled.TabIndex = 21
        Me.cbAudioEnhancementEnabled.Text = "Enabled"
        Me.cbAudioEnhancementEnabled.UseVisualStyleBackColor = true
        '
        'TabPage22
        '
        Me.TabPage22.Controls.Add(Me.btAudioChannelMapperClear)
        Me.TabPage22.Controls.Add(Me.groupBox41)
        Me.TabPage22.Controls.Add(Me.label307)
        Me.TabPage22.Controls.Add(Me.edAudioChannelMapperOutputChannels)
        Me.TabPage22.Controls.Add(Me.label306)
        Me.TabPage22.Controls.Add(Me.lbAudioChannelMapperRoutes)
        Me.TabPage22.Controls.Add(Me.cbAudioChannelMapperEnabled)
        Me.TabPage22.Location = New System.Drawing.Point(4, 22)
        Me.TabPage22.Name = "TabPage22"
        Me.TabPage22.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage22.Size = New System.Drawing.Size(307, 484)
        Me.TabPage22.TabIndex = 21
        Me.TabPage22.Text = "Audio channel mapper"
        Me.TabPage22.UseVisualStyleBackColor = true
        '
        'btAudioChannelMapperClear
        '
        Me.btAudioChannelMapperClear.Location = New System.Drawing.Point(204, 222)
        Me.btAudioChannelMapperClear.Name = "btAudioChannelMapperClear"
        Me.btAudioChannelMapperClear.Size = New System.Drawing.Size(75, 23)
        Me.btAudioChannelMapperClear.TabIndex = 21
        Me.btAudioChannelMapperClear.Text = "Clear"
        Me.btAudioChannelMapperClear.UseVisualStyleBackColor = true
        '
        'groupBox41
        '
        Me.groupBox41.Controls.Add(Me.btAudioChannelMapperAddNewRoute)
        Me.groupBox41.Controls.Add(Me.label311)
        Me.groupBox41.Controls.Add(Me.tbAudioChannelMapperVolume)
        Me.groupBox41.Controls.Add(Me.label310)
        Me.groupBox41.Controls.Add(Me.edAudioChannelMapperTargetChannel)
        Me.groupBox41.Controls.Add(Me.label309)
        Me.groupBox41.Controls.Add(Me.edAudioChannelMapperSourceChannel)
        Me.groupBox41.Controls.Add(Me.label308)
        Me.groupBox41.Location = New System.Drawing.Point(6, 251)
        Me.groupBox41.Name = "groupBox41"
        Me.groupBox41.Size = New System.Drawing.Size(292, 171)
        Me.groupBox41.TabIndex = 20
        Me.groupBox41.TabStop = false
        Me.groupBox41.Text = "Add new route"
        '
        'btAudioChannelMapperAddNewRoute
        '
        Me.btAudioChannelMapperAddNewRoute.Location = New System.Drawing.Point(108, 131)
        Me.btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute"
        Me.btAudioChannelMapperAddNewRoute.Size = New System.Drawing.Size(75, 23)
        Me.btAudioChannelMapperAddNewRoute.TabIndex = 20
        Me.btAudioChannelMapperAddNewRoute.Text = "Add"
        Me.btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = true
        '
        'label311
        '
        Me.label311.AutoSize = true
        Me.label311.Location = New System.Drawing.Point(205, 89)
        Me.label311.Name = "label311"
        Me.label311.Size = New System.Drawing.Size(62, 13)
        Me.label311.TabIndex = 19
        Me.label311.Text = "10% - 200%"
        '
        'tbAudioChannelMapperVolume
        '
        Me.tbAudioChannelMapperVolume.Location = New System.Drawing.Point(208, 41)
        Me.tbAudioChannelMapperVolume.Maximum = 2000
        Me.tbAudioChannelMapperVolume.Minimum = 100
        Me.tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume"
        Me.tbAudioChannelMapperVolume.Size = New System.Drawing.Size(74, 45)
        Me.tbAudioChannelMapperVolume.TabIndex = 18
        Me.tbAudioChannelMapperVolume.Value = 1000
        '
        'label310
        '
        Me.label310.AutoSize = true
        Me.label310.Location = New System.Drawing.Point(205, 25)
        Me.label310.Name = "label310"
        Me.label310.Size = New System.Drawing.Size(42, 13)
        Me.label310.TabIndex = 17
        Me.label310.Text = "Volume"
        '
        'edAudioChannelMapperTargetChannel
        '
        Me.edAudioChannelMapperTargetChannel.Location = New System.Drawing.Point(108, 41)
        Me.edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel"
        Me.edAudioChannelMapperTargetChannel.Size = New System.Drawing.Size(51, 20)
        Me.edAudioChannelMapperTargetChannel.TabIndex = 16
        Me.edAudioChannelMapperTargetChannel.Text = "0"
        '
        'label309
        '
        Me.label309.AutoSize = true
        Me.label309.Location = New System.Drawing.Point(105, 25)
        Me.label309.Name = "label309"
        Me.label309.Size = New System.Drawing.Size(79, 13)
        Me.label309.TabIndex = 15
        Me.label309.Text = "Target channel"
        '
        'edAudioChannelMapperSourceChannel
        '
        Me.edAudioChannelMapperSourceChannel.Location = New System.Drawing.Point(15, 41)
        Me.edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel"
        Me.edAudioChannelMapperSourceChannel.Size = New System.Drawing.Size(51, 20)
        Me.edAudioChannelMapperSourceChannel.TabIndex = 14
        Me.edAudioChannelMapperSourceChannel.Text = "0"
        '
        'label308
        '
        Me.label308.AutoSize = true
        Me.label308.Location = New System.Drawing.Point(12, 25)
        Me.label308.Name = "label308"
        Me.label308.Size = New System.Drawing.Size(82, 13)
        Me.label308.TabIndex = 13
        Me.label308.Text = "Source channel"
        '
        'label307
        '
        Me.label307.AutoSize = true
        Me.label307.Location = New System.Drawing.Point(9, 103)
        Me.label307.Name = "label307"
        Me.label307.Size = New System.Drawing.Size(41, 13)
        Me.label307.TabIndex = 19
        Me.label307.Text = "Routes"
        '
        'edAudioChannelMapperOutputChannels
        '
        Me.edAudioChannelMapperOutputChannels.Location = New System.Drawing.Point(12, 64)
        Me.edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels"
        Me.edAudioChannelMapperOutputChannels.Size = New System.Drawing.Size(42, 20)
        Me.edAudioChannelMapperOutputChannels.TabIndex = 18
        Me.edAudioChannelMapperOutputChannels.Text = "0"
        '
        'label306
        '
        Me.label306.AutoSize = true
        Me.label306.Location = New System.Drawing.Point(9, 48)
        Me.label306.Name = "label306"
        Me.label306.Size = New System.Drawing.Size(274, 13)
        Me.label306.TabIndex = 17
        Me.label306.Text = "Output channels count (0 to use original channels count)"
        '
        'lbAudioChannelMapperRoutes
        '
        Me.lbAudioChannelMapperRoutes.FormattingEnabled = true
        Me.lbAudioChannelMapperRoutes.Location = New System.Drawing.Point(12, 121)
        Me.lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes"
        Me.lbAudioChannelMapperRoutes.Size = New System.Drawing.Size(267, 95)
        Me.lbAudioChannelMapperRoutes.TabIndex = 16
        '
        'cbAudioChannelMapperEnabled
        '
        Me.cbAudioChannelMapperEnabled.AutoSize = true
        Me.cbAudioChannelMapperEnabled.Location = New System.Drawing.Point(12, 14)
        Me.cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled"
        Me.cbAudioChannelMapperEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioChannelMapperEnabled.TabIndex = 15
        Me.cbAudioChannelMapperEnabled.Text = "Enabled"
        Me.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true
        '
        'tabPage7
        '
        Me.tabPage7.Controls.Add(Me.cbNetworkStreamingMode)
        Me.tabPage7.Controls.Add(Me.tabControl5)
        Me.tabPage7.Controls.Add(Me.cbNetworkStreamingAudioEnabled)
        Me.tabPage7.Controls.Add(Me.cbNetworkStreaming)
        Me.tabPage7.Location = New System.Drawing.Point(4, 22)
        Me.tabPage7.Name = "tabPage7"
        Me.tabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage7.Size = New System.Drawing.Size(307, 484)
        Me.tabPage7.TabIndex = 6
        Me.tabPage7.Text = "Network streaming"
        Me.tabPage7.UseVisualStyleBackColor = true
        '
        'cbNetworkStreamingMode
        '
        Me.cbNetworkStreamingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNetworkStreamingMode.FormattingEnabled = true
        Me.cbNetworkStreamingMode.Items.AddRange(New Object() {"Windows Media Video", "RTSP", "RTMP to Adobe Media Server / Wowza", "NDI", "UDP", "Smooth Streaming to Microsoft IIS", "HTTP Live Streaming (HLS)", "Output to external virtual devices"})
        Me.cbNetworkStreamingMode.Location = New System.Drawing.Point(19, 38)
        Me.cbNetworkStreamingMode.Name = "cbNetworkStreamingMode"
        Me.cbNetworkStreamingMode.Size = New System.Drawing.Size(276, 21)
        Me.cbNetworkStreamingMode.TabIndex = 26
        '
        'tabControl5
        '
        Me.tabControl5.Controls.Add(Me.tpWMV)
        Me.tabControl5.Controls.Add(Me.tpRTSP)
        Me.tabControl5.Controls.Add(Me.tpRTMP)
        Me.tabControl5.Controls.Add(Me.tpNDI)
        Me.tabControl5.Controls.Add(Me.tpUDP)
        Me.tabControl5.Controls.Add(Me.tpSSF)
        Me.tabControl5.Controls.Add(Me.tpHLS)
        Me.tabControl5.Controls.Add(Me.tpExternal)
        Me.tabControl5.Location = New System.Drawing.Point(7, 73)
        Me.tabControl5.Name = "tabControl5"
        Me.tabControl5.SelectedIndex = 0
        Me.tabControl5.Size = New System.Drawing.Size(292, 382)
        Me.tabControl5.TabIndex = 25
        '
        'tpWMV
        '
        Me.tpWMV.Controls.Add(Me.label48)
        Me.tpWMV.Controls.Add(Me.edNetworkURL)
        Me.tpWMV.Controls.Add(Me.edWMVNetworkPort)
        Me.tpWMV.Controls.Add(Me.label47)
        Me.tpWMV.Controls.Add(Me.btRefreshClients)
        Me.tpWMV.Controls.Add(Me.lbNetworkClients)
        Me.tpWMV.Controls.Add(Me.rbNetworkStreamingUseExternalProfile)
        Me.tpWMV.Controls.Add(Me.rbNetworkStreamingUseMainWMVSettings)
        Me.tpWMV.Controls.Add(Me.label81)
        Me.tpWMV.Controls.Add(Me.label80)
        Me.tpWMV.Controls.Add(Me.edMaximumClients)
        Me.tpWMV.Controls.Add(Me.label46)
        Me.tpWMV.Controls.Add(Me.btSelectWMVProfileNetwork)
        Me.tpWMV.Controls.Add(Me.edNetworkStreamingWMVProfile)
        Me.tpWMV.Controls.Add(Me.label44)
        Me.tpWMV.Location = New System.Drawing.Point(4, 22)
        Me.tpWMV.Name = "tpWMV"
        Me.tpWMV.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWMV.Size = New System.Drawing.Size(284, 356)
        Me.tpWMV.TabIndex = 0
        Me.tpWMV.Text = "WMV"
        Me.tpWMV.UseVisualStyleBackColor = true
        '
        'label48
        '
        Me.label48.AutoSize = true
        Me.label48.Location = New System.Drawing.Point(12, 314)
        Me.label48.Name = "label48"
        Me.label48.Size = New System.Drawing.Size(86, 13)
        Me.label48.TabIndex = 32
        Me.label48.Text = "Connection URL"
        '
        'edNetworkURL
        '
        Me.edNetworkURL.Location = New System.Drawing.Point(15, 330)
        Me.edNetworkURL.Name = "edNetworkURL"
        Me.edNetworkURL.ReadOnly = true
        Me.edNetworkURL.Size = New System.Drawing.Size(255, 20)
        Me.edNetworkURL.TabIndex = 31
        '
        'edWMVNetworkPort
        '
        Me.edWMVNetworkPort.Location = New System.Drawing.Point(236, 120)
        Me.edWMVNetworkPort.Name = "edWMVNetworkPort"
        Me.edWMVNetworkPort.Size = New System.Drawing.Size(34, 20)
        Me.edWMVNetworkPort.TabIndex = 30
        Me.edWMVNetworkPort.Text = "100"
        '
        'label47
        '
        Me.label47.AutoSize = true
        Me.label47.Location = New System.Drawing.Point(162, 123)
        Me.label47.Name = "label47"
        Me.label47.Size = New System.Drawing.Size(68, 13)
        Me.label47.TabIndex = 29
        Me.label47.Text = "Network port"
        '
        'btRefreshClients
        '
        Me.btRefreshClients.Location = New System.Drawing.Point(206, 237)
        Me.btRefreshClients.Name = "btRefreshClients"
        Me.btRefreshClients.Size = New System.Drawing.Size(64, 23)
        Me.btRefreshClients.TabIndex = 28
        Me.btRefreshClients.Text = "Refresh"
        Me.btRefreshClients.UseVisualStyleBackColor = true
        '
        'lbNetworkClients
        '
        Me.lbNetworkClients.FormattingEnabled = true
        Me.lbNetworkClients.Location = New System.Drawing.Point(15, 175)
        Me.lbNetworkClients.Name = "lbNetworkClients"
        Me.lbNetworkClients.Size = New System.Drawing.Size(255, 56)
        Me.lbNetworkClients.TabIndex = 27
        '
        'rbNetworkStreamingUseExternalProfile
        '
        Me.rbNetworkStreamingUseExternalProfile.AutoSize = true
        Me.rbNetworkStreamingUseExternalProfile.Location = New System.Drawing.Point(15, 38)
        Me.rbNetworkStreamingUseExternalProfile.Name = "rbNetworkStreamingUseExternalProfile"
        Me.rbNetworkStreamingUseExternalProfile.Size = New System.Drawing.Size(115, 17)
        Me.rbNetworkStreamingUseExternalProfile.TabIndex = 26
        Me.rbNetworkStreamingUseExternalProfile.Text = "Use external profile"
        Me.rbNetworkStreamingUseExternalProfile.UseVisualStyleBackColor = true
        '
        'rbNetworkStreamingUseMainWMVSettings
        '
        Me.rbNetworkStreamingUseMainWMVSettings.AutoSize = true
        Me.rbNetworkStreamingUseMainWMVSettings.Checked = true
        Me.rbNetworkStreamingUseMainWMVSettings.Location = New System.Drawing.Point(15, 15)
        Me.rbNetworkStreamingUseMainWMVSettings.Name = "rbNetworkStreamingUseMainWMVSettings"
        Me.rbNetworkStreamingUseMainWMVSettings.Size = New System.Drawing.Size(193, 17)
        Me.rbNetworkStreamingUseMainWMVSettings.TabIndex = 25
        Me.rbNetworkStreamingUseMainWMVSettings.TabStop = true
        Me.rbNetworkStreamingUseMainWMVSettings.Text = "Use WMV settings from capture tab"
        Me.rbNetworkStreamingUseMainWMVSettings.UseVisualStyleBackColor = true
        '
        'label81
        '
        Me.label81.AutoSize = true
        Me.label81.Location = New System.Drawing.Point(34, 272)
        Me.label81.Name = "label81"
        Me.label81.Size = New System.Drawing.Size(230, 13)
        Me.label81.TabIndex = 24
        Me.label81.Text = "You can use Windows Media Player for testing."
        '
        'label80
        '
        Me.label80.AutoSize = true
        Me.label80.Location = New System.Drawing.Point(13, 159)
        Me.label80.Name = "label80"
        Me.label80.Size = New System.Drawing.Size(38, 13)
        Me.label80.TabIndex = 23
        Me.label80.Text = "Clients"
        '
        'edMaximumClients
        '
        Me.edMaximumClients.Location = New System.Drawing.Point(109, 120)
        Me.edMaximumClients.Name = "edMaximumClients"
        Me.edMaximumClients.Size = New System.Drawing.Size(34, 20)
        Me.edMaximumClients.TabIndex = 22
        Me.edMaximumClients.Text = "10"
        '
        'label46
        '
        Me.label46.AutoSize = true
        Me.label46.Location = New System.Drawing.Point(13, 123)
        Me.label46.Name = "label46"
        Me.label46.Size = New System.Drawing.Size(84, 13)
        Me.label46.TabIndex = 21
        Me.label46.Text = "Maximum clients"
        '
        'btSelectWMVProfileNetwork
        '
        Me.btSelectWMVProfileNetwork.Location = New System.Drawing.Point(246, 82)
        Me.btSelectWMVProfileNetwork.Name = "btSelectWMVProfileNetwork"
        Me.btSelectWMVProfileNetwork.Size = New System.Drawing.Size(24, 23)
        Me.btSelectWMVProfileNetwork.TabIndex = 20
        Me.btSelectWMVProfileNetwork.Text = "..."
        Me.btSelectWMVProfileNetwork.UseVisualStyleBackColor = true
        '
        'edNetworkStreamingWMVProfile
        '
        Me.edNetworkStreamingWMVProfile.Location = New System.Drawing.Point(37, 84)
        Me.edNetworkStreamingWMVProfile.Name = "edNetworkStreamingWMVProfile"
        Me.edNetworkStreamingWMVProfile.Size = New System.Drawing.Size(206, 20)
        Me.edNetworkStreamingWMVProfile.TabIndex = 19
        Me.edNetworkStreamingWMVProfile.Text = "c:\WM.prx"
        '
        'label44
        '
        Me.label44.AutoSize = true
        Me.label44.Location = New System.Drawing.Point(34, 68)
        Me.label44.Name = "label44"
        Me.label44.Size = New System.Drawing.Size(52, 13)
        Me.label44.TabIndex = 18
        Me.label44.Text = "File name"
        '
        'tpRTSP
        '
        Me.tpRTSP.Controls.Add(Me.edNetworkRTSPURL)
        Me.tpRTSP.Controls.Add(Me.label367)
        Me.tpRTSP.Controls.Add(Me.label366)
        Me.tpRTSP.Location = New System.Drawing.Point(4, 22)
        Me.tpRTSP.Name = "tpRTSP"
        Me.tpRTSP.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRTSP.Size = New System.Drawing.Size(284, 356)
        Me.tpRTSP.TabIndex = 2
        Me.tpRTSP.Text = "RTSP"
        Me.tpRTSP.UseVisualStyleBackColor = true
        '
        'edNetworkRTSPURL
        '
        Me.edNetworkRTSPURL.Location = New System.Drawing.Point(20, 32)
        Me.edNetworkRTSPURL.Name = "edNetworkRTSPURL"
        Me.edNetworkRTSPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkRTSPURL.TabIndex = 9
        Me.edNetworkRTSPURL.Text = "rtsp://localhost:5554/vfstream"
        '
        'label367
        '
        Me.label367.AutoSize = true
        Me.label367.Location = New System.Drawing.Point(17, 16)
        Me.label367.Name = "label367"
        Me.label367.Size = New System.Drawing.Size(29, 13)
        Me.label367.TabIndex = 8
        Me.label367.Text = "URL"
        '
        'label366
        '
        Me.label366.AutoSize = true
        Me.label366.Location = New System.Drawing.Point(17, 326)
        Me.label366.Name = "label366"
        Me.label366.Size = New System.Drawing.Size(159, 13)
        Me.label366.TabIndex = 7
        Me.label366.Text = "MP4 output settings will be used"
        '
        'tpRTMP
        '
        Me.tpRTMP.Controls.Add(Me.cbNetworkRTMPFFMPEGUsePipes)
        Me.tpRTMP.Controls.Add(Me.linkLabel11)
        Me.tpRTMP.Controls.Add(Me.LinkLabel8)
        Me.tpRTMP.Controls.Add(Me.rbNetworkRTMPFFMPEGCustom)
        Me.tpRTMP.Controls.Add(Me.rbNetworkRTMPFFMPEG)
        Me.tpRTMP.Controls.Add(Me.edNetworkRTMPURL)
        Me.tpRTMP.Controls.Add(Me.label368)
        Me.tpRTMP.Controls.Add(Me.label369)
        Me.tpRTMP.Location = New System.Drawing.Point(4, 22)
        Me.tpRTMP.Name = "tpRTMP"
        Me.tpRTMP.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRTMP.Size = New System.Drawing.Size(284, 356)
        Me.tpRTMP.TabIndex = 3
        Me.tpRTMP.Text = "RTMP"
        Me.tpRTMP.UseVisualStyleBackColor = true
        '
        'cbNetworkRTMPFFMPEGUsePipes
        '
        Me.cbNetworkRTMPFFMPEGUsePipes.AutoSize = true
        Me.cbNetworkRTMPFFMPEGUsePipes.Checked = true
        Me.cbNetworkRTMPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNetworkRTMPFFMPEGUsePipes.Location = New System.Drawing.Point(20, 77)
        Me.cbNetworkRTMPFFMPEGUsePipes.Name = "cbNetworkRTMPFFMPEGUsePipes"
        Me.cbNetworkRTMPFFMPEGUsePipes.Size = New System.Drawing.Size(73, 17)
        Me.cbNetworkRTMPFFMPEGUsePipes.TabIndex = 19
        Me.cbNetworkRTMPFFMPEGUsePipes.Text = "Use pipes"
        Me.cbNetworkRTMPFFMPEGUsePipes.UseVisualStyleBackColor = true
        '
        'linkLabel11
        '
        Me.linkLabel11.AutoSize = true
        Me.linkLabel11.Location = New System.Drawing.Point(17, 150)
        Me.linkLabel11.Name = "linkLabel11"
        Me.linkLabel11.Size = New System.Drawing.Size(154, 13)
        Me.linkLabel11.TabIndex = 18
        Me.linkLabel11.TabStop = true
        Me.linkLabel11.Text = "Network streaming to YouTube"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = true
        Me.LinkLabel8.Location = New System.Drawing.Point(17, 127)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(207, 13)
        Me.LinkLabel8.TabIndex = 17
        Me.LinkLabel8.TabStop = true
        Me.LinkLabel8.Text = "FFMPEG.exe redist required to be installed"
        '
        'rbNetworkRTMPFFMPEGCustom
        '
        Me.rbNetworkRTMPFFMPEGCustom.AutoSize = true
        Me.rbNetworkRTMPFFMPEGCustom.Location = New System.Drawing.Point(20, 41)
        Me.rbNetworkRTMPFFMPEGCustom.Name = "rbNetworkRTMPFFMPEGCustom"
        Me.rbNetworkRTMPFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkRTMPFFMPEGCustom.TabIndex = 16
        Me.rbNetworkRTMPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = true
        '
        'rbNetworkRTMPFFMPEG
        '
        Me.rbNetworkRTMPFFMPEG.AutoSize = true
        Me.rbNetworkRTMPFFMPEG.Checked = true
        Me.rbNetworkRTMPFFMPEG.Location = New System.Drawing.Point(20, 18)
        Me.rbNetworkRTMPFFMPEG.Name = "rbNetworkRTMPFFMPEG"
        Me.rbNetworkRTMPFFMPEG.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkRTMPFFMPEG.TabIndex = 15
        Me.rbNetworkRTMPFFMPEG.TabStop = true
        Me.rbNetworkRTMPFFMPEG.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = true
        '
        'edNetworkRTMPURL
        '
        Me.edNetworkRTMPURL.Location = New System.Drawing.Point(20, 292)
        Me.edNetworkRTMPURL.Name = "edNetworkRTMPURL"
        Me.edNetworkRTMPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkRTMPURL.TabIndex = 14
        Me.edNetworkRTMPURL.Text = "rtmp://localhost:5554/live/Stream"
        '
        'label368
        '
        Me.label368.AutoSize = true
        Me.label368.Location = New System.Drawing.Point(17, 276)
        Me.label368.Name = "label368"
        Me.label368.Size = New System.Drawing.Size(29, 13)
        Me.label368.TabIndex = 13
        Me.label368.Text = "URL"
        '
        'label369
        '
        Me.label369.AutoSize = true
        Me.label369.Location = New System.Drawing.Point(30, 326)
        Me.label369.Name = "label369"
        Me.label369.Size = New System.Drawing.Size(214, 13)
        Me.label369.TabIndex = 12
        Me.label369.Text = "Format settings located on output format tab"
        '
        'tpNDI
        '
        Me.tpNDI.Controls.Add(Me.linkLabel6)
        Me.tpNDI.Controls.Add(Me.label38)
        Me.tpNDI.Controls.Add(Me.label31)
        Me.tpNDI.Controls.Add(Me.edNDIURL)
        Me.tpNDI.Controls.Add(Me.edNDIName)
        Me.tpNDI.Controls.Add(Me.label30)
        Me.tpNDI.Location = New System.Drawing.Point(4, 22)
        Me.tpNDI.Name = "tpNDI"
        Me.tpNDI.Size = New System.Drawing.Size(284, 356)
        Me.tpNDI.TabIndex = 7
        Me.tpNDI.Text = "NDI"
        Me.tpNDI.UseVisualStyleBackColor = true
        '
        'linkLabel6
        '
        Me.linkLabel6.AutoSize = true
        Me.linkLabel6.Location = New System.Drawing.Point(14, 131)
        Me.linkLabel6.Name = "linkLabel6"
        Me.linkLabel6.Size = New System.Drawing.Size(86, 13)
        Me.linkLabel6.TabIndex = 91
        Me.linkLabel6.TabStop = true
        Me.linkLabel6.Text = "vendor's website"
        '
        'label38
        '
        Me.label38.AutoSize = true
        Me.label38.Location = New System.Drawing.Point(14, 118)
        Me.label38.Name = "label38"
        Me.label38.Size = New System.Drawing.Size(257, 13)
        Me.label38.TabIndex = 90
        Me.label38.Text = "To use NDI please install NDI SDK for Windows from"
        '
        'label31
        '
        Me.label31.AutoSize = true
        Me.label31.Location = New System.Drawing.Point(14, 68)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(86, 13)
        Me.label31.TabIndex = 38
        Me.label31.Text = "Connection URL"
        '
        'edNDIURL
        '
        Me.edNDIURL.Location = New System.Drawing.Point(17, 84)
        Me.edNDIURL.Name = "edNDIURL"
        Me.edNDIURL.ReadOnly = true
        Me.edNDIURL.Size = New System.Drawing.Size(243, 20)
        Me.edNDIURL.TabIndex = 37
        '
        'edNDIName
        '
        Me.edNDIName.Location = New System.Drawing.Point(17, 32)
        Me.edNDIName.Name = "edNDIName"
        Me.edNDIName.Size = New System.Drawing.Size(243, 20)
        Me.edNDIName.TabIndex = 36
        Me.edNDIName.Text = "Main"
        '
        'label30
        '
        Me.label30.AutoSize = true
        Me.label30.Location = New System.Drawing.Point(14, 16)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(35, 13)
        Me.label30.TabIndex = 35
        Me.label30.Text = "Name"
        '
        'tpUDP
        '
        Me.tpUDP.Controls.Add(Me.cbNetworkUDPFFMPEGUsePipes)
        Me.tpUDP.Controls.Add(Me.label314)
        Me.tpUDP.Controls.Add(Me.label313)
        Me.tpUDP.Controls.Add(Me.LinkLabel9)
        Me.tpUDP.Controls.Add(Me.label484)
        Me.tpUDP.Controls.Add(Me.edNetworkUDPURL)
        Me.tpUDP.Controls.Add(Me.label372)
        Me.tpUDP.Controls.Add(Me.rbNetworkUDPFFMPEGCustom)
        Me.tpUDP.Controls.Add(Me.rbNetworkUDPFFMPEG)
        Me.tpUDP.Location = New System.Drawing.Point(4, 22)
        Me.tpUDP.Name = "tpUDP"
        Me.tpUDP.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUDP.Size = New System.Drawing.Size(284, 356)
        Me.tpUDP.TabIndex = 5
        Me.tpUDP.Text = "UDP"
        Me.tpUDP.UseVisualStyleBackColor = true
        '
        'cbNetworkUDPFFMPEGUsePipes
        '
        Me.cbNetworkUDPFFMPEGUsePipes.AutoSize = true
        Me.cbNetworkUDPFFMPEGUsePipes.Checked = true
        Me.cbNetworkUDPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNetworkUDPFFMPEGUsePipes.Location = New System.Drawing.Point(20, 83)
        Me.cbNetworkUDPFFMPEGUsePipes.Name = "cbNetworkUDPFFMPEGUsePipes"
        Me.cbNetworkUDPFFMPEGUsePipes.Size = New System.Drawing.Size(73, 17)
        Me.cbNetworkUDPFFMPEGUsePipes.TabIndex = 20
        Me.cbNetworkUDPFFMPEGUsePipes.Text = "Use pipes"
        Me.cbNetworkUDPFFMPEGUsePipes.UseVisualStyleBackColor = true
        '
        'label314
        '
        Me.label314.AutoSize = true
        Me.label314.Location = New System.Drawing.Point(18, 270)
        Me.label314.Name = "label314"
        Me.label314.Size = New System.Drawing.Size(204, 13)
        Me.label314.TabIndex = 19
        Me.label314.Text = "For multicast UDP streaming use URL like"
        '
        'label313
        '
        Me.label313.AutoSize = true
        Me.label313.Location = New System.Drawing.Point(18, 283)
        Me.label313.Name = "label313"
        Me.label313.Size = New System.Drawing.Size(229, 13)
        Me.label313.TabIndex = 18
        Me.label313.Text = "udp://239.101.101.1:1234?ttl=1&pkt_size=1316"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = true
        Me.LinkLabel9.Location = New System.Drawing.Point(18, 130)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(207, 13)
        Me.LinkLabel9.TabIndex = 17
        Me.LinkLabel9.TabStop = true
        Me.LinkLabel9.Text = "FFMPEG.exe redist required to be installed"
        '
        'label484
        '
        Me.label484.AutoSize = true
        Me.label484.Location = New System.Drawing.Point(30, 327)
        Me.label484.Name = "label484"
        Me.label484.Size = New System.Drawing.Size(217, 13)
        Me.label484.TabIndex = 16
        Me.label484.Text = "Specify settings located on output format tab"
        '
        'edNetworkUDPURL
        '
        Me.edNetworkUDPURL.Location = New System.Drawing.Point(20, 246)
        Me.edNetworkUDPURL.Name = "edNetworkUDPURL"
        Me.edNetworkUDPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkUDPURL.TabIndex = 15
        Me.edNetworkUDPURL.Text = "udp://127.0.0.1:10000"
        '
        'label372
        '
        Me.label372.AutoSize = true
        Me.label372.Location = New System.Drawing.Point(17, 230)
        Me.label372.Name = "label372"
        Me.label372.Size = New System.Drawing.Size(29, 13)
        Me.label372.TabIndex = 14
        Me.label372.Text = "URL"
        '
        'rbNetworkUDPFFMPEGCustom
        '
        Me.rbNetworkUDPFFMPEGCustom.AutoSize = true
        Me.rbNetworkUDPFFMPEGCustom.Location = New System.Drawing.Point(20, 39)
        Me.rbNetworkUDPFFMPEGCustom.Name = "rbNetworkUDPFFMPEGCustom"
        Me.rbNetworkUDPFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkUDPFFMPEGCustom.TabIndex = 13
        Me.rbNetworkUDPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = true
        '
        'rbNetworkUDPFFMPEG
        '
        Me.rbNetworkUDPFFMPEG.AutoSize = true
        Me.rbNetworkUDPFFMPEG.Checked = true
        Me.rbNetworkUDPFFMPEG.Location = New System.Drawing.Point(20, 16)
        Me.rbNetworkUDPFFMPEG.Name = "rbNetworkUDPFFMPEG"
        Me.rbNetworkUDPFFMPEG.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkUDPFFMPEG.TabIndex = 12
        Me.rbNetworkUDPFFMPEG.TabStop = true
        Me.rbNetworkUDPFFMPEG.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkUDPFFMPEG.UseVisualStyleBackColor = true
        '
        'tpSSF
        '
        Me.tpSSF.Controls.Add(Me.cbNetworkSSUsePipes)
        Me.tpSSF.Controls.Add(Me.linkLabel10)
        Me.tpSSF.Controls.Add(Me.rbNetworkSSFFMPEGCustom)
        Me.tpSSF.Controls.Add(Me.rbNetworkSSFFMPEGDefault)
        Me.tpSSF.Controls.Add(Me.linkLabel5)
        Me.tpSSF.Controls.Add(Me.edNetworkSSURL)
        Me.tpSSF.Controls.Add(Me.label370)
        Me.tpSSF.Controls.Add(Me.label371)
        Me.tpSSF.Controls.Add(Me.rbNetworkSSSoftware)
        Me.tpSSF.Location = New System.Drawing.Point(4, 22)
        Me.tpSSF.Name = "tpSSF"
        Me.tpSSF.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSSF.Size = New System.Drawing.Size(284, 356)
        Me.tpSSF.TabIndex = 4
        Me.tpSSF.Text = "IIS Smooth Streaming"
        Me.tpSSF.UseVisualStyleBackColor = true
        '
        'cbNetworkSSUsePipes
        '
        Me.cbNetworkSSUsePipes.AutoSize = true
        Me.cbNetworkSSUsePipes.Checked = true
        Me.cbNetworkSSUsePipes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNetworkSSUsePipes.Location = New System.Drawing.Point(42, 86)
        Me.cbNetworkSSUsePipes.Name = "cbNetworkSSUsePipes"
        Me.cbNetworkSSUsePipes.Size = New System.Drawing.Size(182, 17)
        Me.cbNetworkSSUsePipes.TabIndex = 24
        Me.cbNetworkSSUsePipes.Text = "Use pipes for FFMPEG streaming"
        Me.cbNetworkSSUsePipes.UseVisualStyleBackColor = true
        '
        'linkLabel10
        '
        Me.linkLabel10.AutoSize = true
        Me.linkLabel10.Location = New System.Drawing.Point(17, 225)
        Me.linkLabel10.Name = "linkLabel10"
        Me.linkLabel10.Size = New System.Drawing.Size(207, 13)
        Me.linkLabel10.TabIndex = 23
        Me.linkLabel10.TabStop = true
        Me.linkLabel10.Text = "FFMPEG.exe redist required to be installed"
        '
        'rbNetworkSSFFMPEGCustom
        '
        Me.rbNetworkSSFFMPEGCustom.AutoSize = true
        Me.rbNetworkSSFFMPEGCustom.Location = New System.Drawing.Point(20, 63)
        Me.rbNetworkSSFFMPEGCustom.Name = "rbNetworkSSFFMPEGCustom"
        Me.rbNetworkSSFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkSSFFMPEGCustom.TabIndex = 22
        Me.rbNetworkSSFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = true
        '
        'rbNetworkSSFFMPEGDefault
        '
        Me.rbNetworkSSFFMPEGDefault.AutoSize = true
        Me.rbNetworkSSFFMPEGDefault.Location = New System.Drawing.Point(20, 40)
        Me.rbNetworkSSFFMPEGDefault.Name = "rbNetworkSSFFMPEGDefault"
        Me.rbNetworkSSFFMPEGDefault.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkSSFFMPEGDefault.TabIndex = 21
        Me.rbNetworkSSFFMPEGDefault.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = true
        '
        'linkLabel5
        '
        Me.linkLabel5.AutoSize = true
        Me.linkLabel5.Location = New System.Drawing.Point(17, 202)
        Me.linkLabel5.Name = "linkLabel5"
        Me.linkLabel5.Size = New System.Drawing.Size(178, 13)
        Me.linkLabel5.TabIndex = 20
        Me.linkLabel5.TabStop = true
        Me.linkLabel5.Text = "IIS Smooth Streaming usage manual"
        '
        'edNetworkSSURL
        '
        Me.edNetworkSSURL.Location = New System.Drawing.Point(20, 154)
        Me.edNetworkSSURL.Name = "edNetworkSSURL"
        Me.edNetworkSSURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkSSURL.TabIndex = 19
        Me.edNetworkSSURL.Text = "http://localhost/LiveSmoothStream.isml"
        '
        'label370
        '
        Me.label370.AutoSize = true
        Me.label370.Location = New System.Drawing.Point(17, 138)
        Me.label370.Name = "label370"
        Me.label370.Size = New System.Drawing.Size(106, 13)
        Me.label370.TabIndex = 18
        Me.label370.Text = "Publishing point URL"
        '
        'label371
        '
        Me.label371.AutoSize = true
        Me.label371.Location = New System.Drawing.Point(17, 326)
        Me.label371.Name = "label371"
        Me.label371.Size = New System.Drawing.Size(214, 13)
        Me.label371.TabIndex = 17
        Me.label371.Text = "Format settings located on output format tab"
        '
        'rbNetworkSSSoftware
        '
        Me.rbNetworkSSSoftware.AutoSize = true
        Me.rbNetworkSSSoftware.Checked = true
        Me.rbNetworkSSSoftware.Location = New System.Drawing.Point(20, 17)
        Me.rbNetworkSSSoftware.Name = "rbNetworkSSSoftware"
        Me.rbNetworkSSSoftware.Size = New System.Drawing.Size(244, 17)
        Me.rbNetworkSSSoftware.TabIndex = 15
        Me.rbNetworkSSSoftware.TabStop = true
        Me.rbNetworkSSSoftware.Text = "H264 / AAC using software encoder / NVENC"
        Me.rbNetworkSSSoftware.UseVisualStyleBackColor = true
        '
        'tpHLS
        '
        Me.tpHLS.Controls.Add(Me.edHLSURL)
        Me.tpHLS.Controls.Add(Me.label19)
        Me.tpHLS.Controls.Add(Me.edHLSEmbeddedHTTPServerPort)
        Me.tpHLS.Controls.Add(Me.cbHLSEmbeddedHTTPServerEnabled)
        Me.tpHLS.Controls.Add(Me.cbHLSMode)
        Me.tpHLS.Controls.Add(Me.label6)
        Me.tpHLS.Controls.Add(Me.lbHLSConfigure)
        Me.tpHLS.Controls.Add(Me.label532)
        Me.tpHLS.Controls.Add(Me.label531)
        Me.tpHLS.Controls.Add(Me.label530)
        Me.tpHLS.Controls.Add(Me.label529)
        Me.tpHLS.Controls.Add(Me.edHLSSegmentCount)
        Me.tpHLS.Controls.Add(Me.label519)
        Me.tpHLS.Controls.Add(Me.edHLSSegmentDuration)
        Me.tpHLS.Controls.Add(Me.btSelectHLSOutputFolder)
        Me.tpHLS.Controls.Add(Me.edHLSOutputFolder)
        Me.tpHLS.Controls.Add(Me.Label500)
        Me.tpHLS.Location = New System.Drawing.Point(4, 22)
        Me.tpHLS.Name = "tpHLS"
        Me.tpHLS.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHLS.Size = New System.Drawing.Size(284, 356)
        Me.tpHLS.TabIndex = 6
        Me.tpHLS.Text = "HLS"
        Me.tpHLS.UseVisualStyleBackColor = true
        '
        'edHLSURL
        '
        Me.edHLSURL.Location = New System.Drawing.Point(12, 293)
        Me.edHLSURL.Name = "edHLSURL"
        Me.edHLSURL.Size = New System.Drawing.Size(252, 20)
        Me.edHLSURL.TabIndex = 27
        Me.edHLSURL.Text = "http://localhost:81/playlist.m3u8"
        '
        'label19
        '
        Me.label19.AutoSize = true
        Me.label19.Location = New System.Drawing.Point(9, 316)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(16, 13)
        Me.label19.TabIndex = 26
        Me.label19.Text = "or"
        '
        'edHLSEmbeddedHTTPServerPort
        '
        Me.edHLSEmbeddedHTTPServerPort.Location = New System.Drawing.Point(223, 270)
        Me.edHLSEmbeddedHTTPServerPort.Name = "edHLSEmbeddedHTTPServerPort"
        Me.edHLSEmbeddedHTTPServerPort.Size = New System.Drawing.Size(41, 20)
        Me.edHLSEmbeddedHTTPServerPort.TabIndex = 25
        Me.edHLSEmbeddedHTTPServerPort.Text = "81"
        '
        'cbHLSEmbeddedHTTPServerEnabled
        '
        Me.cbHLSEmbeddedHTTPServerEnabled.AutoSize = true
        Me.cbHLSEmbeddedHTTPServerEnabled.Location = New System.Drawing.Point(12, 272)
        Me.cbHLSEmbeddedHTTPServerEnabled.Name = "cbHLSEmbeddedHTTPServerEnabled"
        Me.cbHLSEmbeddedHTTPServerEnabled.Size = New System.Drawing.Size(205, 17)
        Me.cbHLSEmbeddedHTTPServerEnabled.TabIndex = 24
        Me.cbHLSEmbeddedHTTPServerEnabled.Text = "Use embedded HTTP server with port"
        Me.cbHLSEmbeddedHTTPServerEnabled.UseVisualStyleBackColor = true
        '
        'cbHLSMode
        '
        Me.cbHLSMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHLSMode.FormattingEnabled = true
        Me.cbHLSMode.Items.AddRange(New Object() {"Live", "VOD", "Event"})
        Me.cbHLSMode.Location = New System.Drawing.Point(12, 236)
        Me.cbHLSMode.Name = "cbHLSMode"
        Me.cbHLSMode.Size = New System.Drawing.Size(121, 21)
        Me.cbHLSMode.TabIndex = 23
        '
        'label6
        '
        Me.label6.AutoSize = true
        Me.label6.Location = New System.Drawing.Point(9, 220)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(97, 13)
        Me.label6.TabIndex = 22
        Me.label6.Text = "Mode (playlist type)"
        '
        'lbHLSConfigure
        '
        Me.lbHLSConfigure.AutoSize = true
        Me.lbHLSConfigure.Location = New System.Drawing.Point(9, 329)
        Me.lbHLSConfigure.Name = "lbHLSConfigure"
        Me.lbHLSConfigure.Size = New System.Drawing.Size(191, 13)
        Me.lbHLSConfigure.TabIndex = 21
        Me.lbHLSConfigure.TabStop = true
        Me.lbHLSConfigure.Text = "How to configure HTTP server for HLS"
        '
        'label532
        '
        Me.label532.AutoSize = true
        Me.label532.Location = New System.Drawing.Point(9, 179)
        Me.label532.Name = "label532"
        Me.label532.Size = New System.Drawing.Size(42, 13)
        Me.label532.TabIndex = 20
        Me.label532.Text = "in code"
        '
        'label531
        '
        Me.label531.AutoSize = true
        Me.label531.Location = New System.Drawing.Point(9, 166)
        Me.label531.Name = "label531"
        Me.label531.Size = New System.Drawing.Size(247, 13)
        Me.label531.TabIndex = 19
        Me.label531.Text = "You can set video (H264) and audio (AAC) settings"
        '
        'label530
        '
        Me.label530.AutoSize = true
        Me.label530.Location = New System.Drawing.Point(60, 131)
        Me.label530.Name = "label530"
        Me.label530.Size = New System.Drawing.Size(134, 13)
        Me.label530.TabIndex = 18
        Me.label530.Text = "Use 0 to save all segments"
        '
        'label529
        '
        Me.label529.AutoSize = true
        Me.label529.Location = New System.Drawing.Point(9, 112)
        Me.label529.Name = "label529"
        Me.label529.Size = New System.Drawing.Size(244, 13)
        Me.label529.TabIndex = 17
        Me.label529.Text = "Segment count that will be saved during streaming"
        '
        'edHLSSegmentCount
        '
        Me.edHLSSegmentCount.Location = New System.Drawing.Point(12, 128)
        Me.edHLSSegmentCount.Name = "edHLSSegmentCount"
        Me.edHLSSegmentCount.Size = New System.Drawing.Size(42, 20)
        Me.edHLSSegmentCount.TabIndex = 16
        Me.edHLSSegmentCount.Text = "20"
        '
        'label519
        '
        Me.label519.AutoSize = true
        Me.label519.Location = New System.Drawing.Point(9, 63)
        Me.label519.Name = "label519"
        Me.label519.Size = New System.Drawing.Size(116, 13)
        Me.label519.TabIndex = 15
        Me.label519.Text = "Segment duration (sec)"
        '
        'edHLSSegmentDuration
        '
        Me.edHLSSegmentDuration.Location = New System.Drawing.Point(12, 79)
        Me.edHLSSegmentDuration.Name = "edHLSSegmentDuration"
        Me.edHLSSegmentDuration.Size = New System.Drawing.Size(42, 20)
        Me.edHLSSegmentDuration.TabIndex = 14
        Me.edHLSSegmentDuration.Text = "10"
        '
        'btSelectHLSOutputFolder
        '
        Me.btSelectHLSOutputFolder.Location = New System.Drawing.Point(248, 29)
        Me.btSelectHLSOutputFolder.Name = "btSelectHLSOutputFolder"
        Me.btSelectHLSOutputFolder.Size = New System.Drawing.Size(23, 23)
        Me.btSelectHLSOutputFolder.TabIndex = 13
        Me.btSelectHLSOutputFolder.Text = "..."
        Me.btSelectHLSOutputFolder.UseVisualStyleBackColor = true
        '
        'edHLSOutputFolder
        '
        Me.edHLSOutputFolder.Location = New System.Drawing.Point(12, 31)
        Me.edHLSOutputFolder.Name = "edHLSOutputFolder"
        Me.edHLSOutputFolder.Size = New System.Drawing.Size(230, 20)
        Me.edHLSOutputFolder.TabIndex = 12
        Me.edHLSOutputFolder.Text = "c:\inetpub\wwwroot\hls\"
        '
        'Label500
        '
        Me.Label500.AutoSize = true
        Me.Label500.Location = New System.Drawing.Point(9, 12)
        Me.Label500.Name = "Label500"
        Me.Label500.Size = New System.Drawing.Size(188, 13)
        Me.Label500.TabIndex = 11
        Me.Label500.Text = "Output folder for video files and playlist"
        '
        'tpExternal
        '
        Me.tpExternal.Controls.Add(Me.linkLabel4)
        Me.tpExternal.Controls.Add(Me.linkLabel2)
        Me.tpExternal.Location = New System.Drawing.Point(4, 22)
        Me.tpExternal.Name = "tpExternal"
        Me.tpExternal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpExternal.Size = New System.Drawing.Size(284, 356)
        Me.tpExternal.TabIndex = 1
        Me.tpExternal.Text = "External"
        Me.tpExternal.UseVisualStyleBackColor = true
        '
        'linkLabel4
        '
        Me.linkLabel4.AutoSize = true
        Me.linkLabel4.Location = New System.Drawing.Point(16, 35)
        Me.linkLabel4.Name = "linkLabel4"
        Me.linkLabel4.Size = New System.Drawing.Size(225, 13)
        Me.linkLabel4.TabIndex = 2
        Me.linkLabel4.TabStop = true
        Me.linkLabel4.Text = "Streaming using Microsoft Expression Encoder"
        '
        'linkLabel2
        '
        Me.linkLabel2.AutoSize = true
        Me.linkLabel2.Location = New System.Drawing.Point(16, 12)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(194, 13)
        Me.linkLabel2.TabIndex = 1
        Me.linkLabel2.TabStop = true
        Me.linkLabel2.Text = "Streaming to Adobe Flash Media Server"
        '
        'cbNetworkStreamingAudioEnabled
        '
        Me.cbNetworkStreamingAudioEnabled.AutoSize = true
        Me.cbNetworkStreamingAudioEnabled.Location = New System.Drawing.Point(11, 461)
        Me.cbNetworkStreamingAudioEnabled.Name = "cbNetworkStreamingAudioEnabled"
        Me.cbNetworkStreamingAudioEnabled.Size = New System.Drawing.Size(88, 17)
        Me.cbNetworkStreamingAudioEnabled.TabIndex = 24
        Me.cbNetworkStreamingAudioEnabled.Text = "Stream audio"
        Me.cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = true
        '
        'cbNetworkStreaming
        '
        Me.cbNetworkStreaming.AutoSize = true
        Me.cbNetworkStreaming.Location = New System.Drawing.Point(19, 16)
        Me.cbNetworkStreaming.Name = "cbNetworkStreaming"
        Me.cbNetworkStreaming.Size = New System.Drawing.Size(155, 17)
        Me.cbNetworkStreaming.TabIndex = 21
        Me.cbNetworkStreaming.Text = "Network streaming enabled"
        Me.cbNetworkStreaming.UseVisualStyleBackColor = true
        '
        'tabPage28
        '
        Me.tabPage28.Controls.Add(Me.btOSDRenderLayers)
        Me.tabPage28.Controls.Add(Me.lbOSDLayers)
        Me.tabPage28.Controls.Add(Me.cbOSDEnabled)
        Me.tabPage28.Controls.Add(Me.groupBox19)
        Me.tabPage28.Controls.Add(Me.btOSDClearLayers)
        Me.tabPage28.Controls.Add(Me.groupBox15)
        Me.tabPage28.Controls.Add(Me.label108)
        Me.tabPage28.Location = New System.Drawing.Point(4, 22)
        Me.tabPage28.Name = "tabPage28"
        Me.tabPage28.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage28.Size = New System.Drawing.Size(307, 484)
        Me.tabPage28.TabIndex = 10
        Me.tabPage28.Text = "OSD"
        Me.tabPage28.UseVisualStyleBackColor = true
        '
        'btOSDRenderLayers
        '
        Me.btOSDRenderLayers.Location = New System.Drawing.Point(161, 184)
        Me.btOSDRenderLayers.Name = "btOSDRenderLayers"
        Me.btOSDRenderLayers.Size = New System.Drawing.Size(117, 23)
        Me.btOSDRenderLayers.TabIndex = 18
        Me.btOSDRenderLayers.Text = "Render layers"
        Me.btOSDRenderLayers.UseVisualStyleBackColor = true
        '
        'lbOSDLayers
        '
        Me.lbOSDLayers.CheckOnClick = true
        Me.lbOSDLayers.FormattingEnabled = true
        Me.lbOSDLayers.Location = New System.Drawing.Point(16, 56)
        Me.lbOSDLayers.Name = "lbOSDLayers"
        Me.lbOSDLayers.Size = New System.Drawing.Size(139, 124)
        Me.lbOSDLayers.TabIndex = 17
        '
        'cbOSDEnabled
        '
        Me.cbOSDEnabled.AutoSize = true
        Me.cbOSDEnabled.Location = New System.Drawing.Point(16, 15)
        Me.cbOSDEnabled.Name = "cbOSDEnabled"
        Me.cbOSDEnabled.Size = New System.Drawing.Size(251, 17)
        Me.cbOSDEnabled.TabIndex = 16
        Me.cbOSDEnabled.Text = "Enabled (should be set before playback started)"
        Me.cbOSDEnabled.UseVisualStyleBackColor = true
        '
        'groupBox19
        '
        Me.groupBox19.Controls.Add(Me.btOSDClearLayer)
        Me.groupBox19.Controls.Add(Me.tabControl6)
        Me.groupBox19.Location = New System.Drawing.Point(15, 213)
        Me.groupBox19.Name = "groupBox19"
        Me.groupBox19.Size = New System.Drawing.Size(262, 250)
        Me.groupBox19.TabIndex = 6
        Me.groupBox19.TabStop = false
        Me.groupBox19.Text = "Selected layer"
        '
        'btOSDClearLayer
        '
        Me.btOSDClearLayer.Location = New System.Drawing.Point(6, 221)
        Me.btOSDClearLayer.Name = "btOSDClearLayer"
        Me.btOSDClearLayer.Size = New System.Drawing.Size(91, 23)
        Me.btOSDClearLayer.TabIndex = 4
        Me.btOSDClearLayer.Text = "Clear layer"
        Me.btOSDClearLayer.UseVisualStyleBackColor = true
        '
        'tabControl6
        '
        Me.tabControl6.Controls.Add(Me.tabPage30)
        Me.tabControl6.Controls.Add(Me.tabPage31)
        Me.tabControl6.Controls.Add(Me.tabPage32)
        Me.tabControl6.Location = New System.Drawing.Point(6, 19)
        Me.tabControl6.Name = "tabControl6"
        Me.tabControl6.SelectedIndex = 0
        Me.tabControl6.Size = New System.Drawing.Size(250, 196)
        Me.tabControl6.TabIndex = 0
        '
        'tabPage30
        '
        Me.tabPage30.Controls.Add(Me.btOSDImageDraw)
        Me.tabPage30.Controls.Add(Me.pnOSDColorKey)
        Me.tabPage30.Controls.Add(Me.cbOSDImageTranspColor)
        Me.tabPage30.Controls.Add(Me.edOSDImageTop)
        Me.tabPage30.Controls.Add(Me.label115)
        Me.tabPage30.Controls.Add(Me.edOSDImageLeft)
        Me.tabPage30.Controls.Add(Me.label114)
        Me.tabPage30.Controls.Add(Me.btOSDSelectImage)
        Me.tabPage30.Controls.Add(Me.edOSDImageFilename)
        Me.tabPage30.Controls.Add(Me.label113)
        Me.tabPage30.Location = New System.Drawing.Point(4, 22)
        Me.tabPage30.Name = "tabPage30"
        Me.tabPage30.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage30.Size = New System.Drawing.Size(242, 170)
        Me.tabPage30.TabIndex = 1
        Me.tabPage30.Text = "Image"
        Me.tabPage30.UseVisualStyleBackColor = true
        '
        'btOSDImageDraw
        '
        Me.btOSDImageDraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btOSDImageDraw.Location = New System.Drawing.Point(178, 141)
        Me.btOSDImageDraw.Name = "btOSDImageDraw"
        Me.btOSDImageDraw.Size = New System.Drawing.Size(57, 23)
        Me.btOSDImageDraw.TabIndex = 47
        Me.btOSDImageDraw.Text = "Draw"
        Me.btOSDImageDraw.UseVisualStyleBackColor = true
        '
        'pnOSDColorKey
        '
        Me.pnOSDColorKey.BackColor = System.Drawing.Color.Fuchsia
        Me.pnOSDColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOSDColorKey.Location = New System.Drawing.Point(162, 97)
        Me.pnOSDColorKey.Name = "pnOSDColorKey"
        Me.pnOSDColorKey.Size = New System.Drawing.Size(24, 24)
        Me.pnOSDColorKey.TabIndex = 45
        '
        'cbOSDImageTranspColor
        '
        Me.cbOSDImageTranspColor.AutoSize = true
        Me.cbOSDImageTranspColor.Location = New System.Drawing.Point(15, 102)
        Me.cbOSDImageTranspColor.Name = "cbOSDImageTranspColor"
        Me.cbOSDImageTranspColor.Size = New System.Drawing.Size(135, 17)
        Me.cbOSDImageTranspColor.TabIndex = 7
        Me.cbOSDImageTranspColor.Text = "Use transparency color"
        Me.cbOSDImageTranspColor.UseVisualStyleBackColor = true
        '
        'edOSDImageTop
        '
        Me.edOSDImageTop.Location = New System.Drawing.Point(132, 67)
        Me.edOSDImageTop.Name = "edOSDImageTop"
        Me.edOSDImageTop.Size = New System.Drawing.Size(38, 20)
        Me.edOSDImageTop.TabIndex = 6
        Me.edOSDImageTop.Text = "0"
        '
        'label115
        '
        Me.label115.AutoSize = true
        Me.label115.Location = New System.Drawing.Point(101, 70)
        Me.label115.Name = "label115"
        Me.label115.Size = New System.Drawing.Size(26, 13)
        Me.label115.TabIndex = 5
        Me.label115.Text = "Top"
        '
        'edOSDImageLeft
        '
        Me.edOSDImageLeft.Location = New System.Drawing.Point(49, 67)
        Me.edOSDImageLeft.Name = "edOSDImageLeft"
        Me.edOSDImageLeft.Size = New System.Drawing.Size(38, 20)
        Me.edOSDImageLeft.TabIndex = 4
        Me.edOSDImageLeft.Text = "0"
        '
        'label114
        '
        Me.label114.AutoSize = true
        Me.label114.Location = New System.Drawing.Point(12, 70)
        Me.label114.Name = "label114"
        Me.label114.Size = New System.Drawing.Size(25, 13)
        Me.label114.TabIndex = 3
        Me.label114.Text = "Left"
        '
        'btOSDSelectImage
        '
        Me.btOSDSelectImage.Location = New System.Drawing.Point(213, 30)
        Me.btOSDSelectImage.Name = "btOSDSelectImage"
        Me.btOSDSelectImage.Size = New System.Drawing.Size(22, 23)
        Me.btOSDSelectImage.TabIndex = 2
        Me.btOSDSelectImage.Text = "..."
        Me.btOSDSelectImage.UseVisualStyleBackColor = true
        '
        'edOSDImageFilename
        '
        Me.edOSDImageFilename.Location = New System.Drawing.Point(15, 32)
        Me.edOSDImageFilename.Name = "edOSDImageFilename"
        Me.edOSDImageFilename.Size = New System.Drawing.Size(192, 20)
        Me.edOSDImageFilename.TabIndex = 1
        Me.edOSDImageFilename.Text = "c:\logo.png"
        '
        'label113
        '
        Me.label113.AutoSize = true
        Me.label113.Location = New System.Drawing.Point(12, 16)
        Me.label113.Name = "label113"
        Me.label113.Size = New System.Drawing.Size(52, 13)
        Me.label113.TabIndex = 0
        Me.label113.Text = "File name"
        '
        'tabPage31
        '
        Me.tabPage31.Controls.Add(Me.edOSDTextTop)
        Me.tabPage31.Controls.Add(Me.label117)
        Me.tabPage31.Controls.Add(Me.edOSDTextLeft)
        Me.tabPage31.Controls.Add(Me.label118)
        Me.tabPage31.Controls.Add(Me.label116)
        Me.tabPage31.Controls.Add(Me.btOSDSelectFont)
        Me.tabPage31.Controls.Add(Me.edOSDText)
        Me.tabPage31.Controls.Add(Me.btOSDTextDraw)
        Me.tabPage31.Location = New System.Drawing.Point(4, 22)
        Me.tabPage31.Name = "tabPage31"
        Me.tabPage31.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage31.Size = New System.Drawing.Size(242, 170)
        Me.tabPage31.TabIndex = 2
        Me.tabPage31.Text = "Text"
        Me.tabPage31.UseVisualStyleBackColor = true
        '
        'edOSDTextTop
        '
        Me.edOSDTextTop.Location = New System.Drawing.Point(132, 67)
        Me.edOSDTextTop.Name = "edOSDTextTop"
        Me.edOSDTextTop.Size = New System.Drawing.Size(38, 20)
        Me.edOSDTextTop.TabIndex = 55
        Me.edOSDTextTop.Text = "0"
        '
        'label117
        '
        Me.label117.AutoSize = true
        Me.label117.Location = New System.Drawing.Point(101, 70)
        Me.label117.Name = "label117"
        Me.label117.Size = New System.Drawing.Size(26, 13)
        Me.label117.TabIndex = 54
        Me.label117.Text = "Top"
        '
        'edOSDTextLeft
        '
        Me.edOSDTextLeft.Location = New System.Drawing.Point(49, 67)
        Me.edOSDTextLeft.Name = "edOSDTextLeft"
        Me.edOSDTextLeft.Size = New System.Drawing.Size(38, 20)
        Me.edOSDTextLeft.TabIndex = 53
        Me.edOSDTextLeft.Text = "0"
        '
        'label118
        '
        Me.label118.AutoSize = true
        Me.label118.Location = New System.Drawing.Point(12, 70)
        Me.label118.Name = "label118"
        Me.label118.Size = New System.Drawing.Size(25, 13)
        Me.label118.TabIndex = 52
        Me.label118.Text = "Left"
        '
        'label116
        '
        Me.label116.AutoSize = true
        Me.label116.Location = New System.Drawing.Point(12, 16)
        Me.label116.Name = "label116"
        Me.label116.Size = New System.Drawing.Size(28, 13)
        Me.label116.TabIndex = 51
        Me.label116.Text = "Text"
        '
        'btOSDSelectFont
        '
        Me.btOSDSelectFont.Location = New System.Drawing.Point(198, 30)
        Me.btOSDSelectFont.Name = "btOSDSelectFont"
        Me.btOSDSelectFont.Size = New System.Drawing.Size(37, 23)
        Me.btOSDSelectFont.TabIndex = 50
        Me.btOSDSelectFont.Text = "Font"
        Me.btOSDSelectFont.UseVisualStyleBackColor = true
        '
        'edOSDText
        '
        Me.edOSDText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edOSDText.Location = New System.Drawing.Point(15, 32)
        Me.edOSDText.Name = "edOSDText"
        Me.edOSDText.Size = New System.Drawing.Size(180, 20)
        Me.edOSDText.TabIndex = 49
        Me.edOSDText.Text = "Hello!!!"
        '
        'btOSDTextDraw
        '
        Me.btOSDTextDraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btOSDTextDraw.Location = New System.Drawing.Point(178, 141)
        Me.btOSDTextDraw.Name = "btOSDTextDraw"
        Me.btOSDTextDraw.Size = New System.Drawing.Size(57, 23)
        Me.btOSDTextDraw.TabIndex = 48
        Me.btOSDTextDraw.Text = "Draw"
        Me.btOSDTextDraw.UseVisualStyleBackColor = true
        '
        'tabPage32
        '
        Me.tabPage32.Controls.Add(Me.tbOSDTranspLevel)
        Me.tabPage32.Controls.Add(Me.btOSDSetTransp)
        Me.tabPage32.Controls.Add(Me.label119)
        Me.tabPage32.Location = New System.Drawing.Point(4, 22)
        Me.tabPage32.Name = "tabPage32"
        Me.tabPage32.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage32.Size = New System.Drawing.Size(242, 170)
        Me.tabPage32.TabIndex = 3
        Me.tabPage32.Text = "Other"
        Me.tabPage32.UseVisualStyleBackColor = true
        '
        'tbOSDTranspLevel
        '
        Me.tbOSDTranspLevel.BackColor = System.Drawing.SystemColors.Window
        Me.tbOSDTranspLevel.Location = New System.Drawing.Point(15, 32)
        Me.tbOSDTranspLevel.Maximum = 255
        Me.tbOSDTranspLevel.Name = "tbOSDTranspLevel"
        Me.tbOSDTranspLevel.Size = New System.Drawing.Size(143, 45)
        Me.tbOSDTranspLevel.TabIndex = 3
        Me.tbOSDTranspLevel.TickFrequency = 10
        '
        'btOSDSetTransp
        '
        Me.btOSDSetTransp.Location = New System.Drawing.Point(178, 41)
        Me.btOSDSetTransp.Name = "btOSDSetTransp"
        Me.btOSDSetTransp.Size = New System.Drawing.Size(48, 23)
        Me.btOSDSetTransp.TabIndex = 2
        Me.btOSDSetTransp.Text = "Set"
        Me.btOSDSetTransp.UseVisualStyleBackColor = true
        '
        'label119
        '
        Me.label119.AutoSize = true
        Me.label119.Location = New System.Drawing.Point(12, 16)
        Me.label119.Name = "label119"
        Me.label119.Size = New System.Drawing.Size(97, 13)
        Me.label119.TabIndex = 0
        Me.label119.Text = "Transparency level"
        '
        'btOSDClearLayers
        '
        Me.btOSDClearLayers.Location = New System.Drawing.Point(15, 184)
        Me.btOSDClearLayers.Name = "btOSDClearLayers"
        Me.btOSDClearLayers.Size = New System.Drawing.Size(140, 23)
        Me.btOSDClearLayers.TabIndex = 5
        Me.btOSDClearLayers.Text = "Remove all layers"
        Me.btOSDClearLayers.UseVisualStyleBackColor = true
        '
        'groupBox15
        '
        Me.groupBox15.Controls.Add(Me.btOSDLayerAdd)
        Me.groupBox15.Controls.Add(Me.edOSDLayerHeight)
        Me.groupBox15.Controls.Add(Me.label111)
        Me.groupBox15.Controls.Add(Me.edOSDLayerWidth)
        Me.groupBox15.Controls.Add(Me.label112)
        Me.groupBox15.Controls.Add(Me.edOSDLayerTop)
        Me.groupBox15.Controls.Add(Me.label110)
        Me.groupBox15.Controls.Add(Me.edOSDLayerLeft)
        Me.groupBox15.Controls.Add(Me.label109)
        Me.groupBox15.Location = New System.Drawing.Point(161, 46)
        Me.groupBox15.Name = "groupBox15"
        Me.groupBox15.Size = New System.Drawing.Size(117, 134)
        Me.groupBox15.TabIndex = 4
        Me.groupBox15.TabStop = false
        Me.groupBox15.Text = "New layer"
        '
        'btOSDLayerAdd
        '
        Me.btOSDLayerAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btOSDLayerAdd.Location = New System.Drawing.Point(31, 107)
        Me.btOSDLayerAdd.Name = "btOSDLayerAdd"
        Me.btOSDLayerAdd.Size = New System.Drawing.Size(56, 23)
        Me.btOSDLayerAdd.TabIndex = 8
        Me.btOSDLayerAdd.Text = "Create"
        Me.btOSDLayerAdd.UseVisualStyleBackColor = true
        '
        'edOSDLayerHeight
        '
        Me.edOSDLayerHeight.Location = New System.Drawing.Point(65, 81)
        Me.edOSDLayerHeight.Name = "edOSDLayerHeight"
        Me.edOSDLayerHeight.Size = New System.Drawing.Size(38, 20)
        Me.edOSDLayerHeight.TabIndex = 7
        Me.edOSDLayerHeight.Text = "200"
        '
        'label111
        '
        Me.label111.AutoSize = true
        Me.label111.Location = New System.Drawing.Point(62, 65)
        Me.label111.Name = "label111"
        Me.label111.Size = New System.Drawing.Size(38, 13)
        Me.label111.TabIndex = 6
        Me.label111.Text = "Height"
        '
        'edOSDLayerWidth
        '
        Me.edOSDLayerWidth.Location = New System.Drawing.Point(13, 81)
        Me.edOSDLayerWidth.Name = "edOSDLayerWidth"
        Me.edOSDLayerWidth.Size = New System.Drawing.Size(38, 20)
        Me.edOSDLayerWidth.TabIndex = 5
        Me.edOSDLayerWidth.Text = "200"
        '
        'label112
        '
        Me.label112.AutoSize = true
        Me.label112.Location = New System.Drawing.Point(10, 65)
        Me.label112.Name = "label112"
        Me.label112.Size = New System.Drawing.Size(35, 13)
        Me.label112.TabIndex = 4
        Me.label112.Text = "Width"
        '
        'edOSDLayerTop
        '
        Me.edOSDLayerTop.Location = New System.Drawing.Point(65, 42)
        Me.edOSDLayerTop.Name = "edOSDLayerTop"
        Me.edOSDLayerTop.Size = New System.Drawing.Size(38, 20)
        Me.edOSDLayerTop.TabIndex = 3
        Me.edOSDLayerTop.Text = "0"
        '
        'label110
        '
        Me.label110.AutoSize = true
        Me.label110.Location = New System.Drawing.Point(62, 26)
        Me.label110.Name = "label110"
        Me.label110.Size = New System.Drawing.Size(26, 13)
        Me.label110.TabIndex = 2
        Me.label110.Text = "Top"
        '
        'edOSDLayerLeft
        '
        Me.edOSDLayerLeft.Location = New System.Drawing.Point(13, 42)
        Me.edOSDLayerLeft.Name = "edOSDLayerLeft"
        Me.edOSDLayerLeft.Size = New System.Drawing.Size(38, 20)
        Me.edOSDLayerLeft.TabIndex = 1
        Me.edOSDLayerLeft.Text = "0"
        '
        'label109
        '
        Me.label109.AutoSize = true
        Me.label109.Location = New System.Drawing.Point(10, 26)
        Me.label109.Name = "label109"
        Me.label109.Size = New System.Drawing.Size(25, 13)
        Me.label109.TabIndex = 0
        Me.label109.Text = "Left"
        '
        'label108
        '
        Me.label108.AutoSize = true
        Me.label108.Location = New System.Drawing.Point(13, 40)
        Me.label108.Name = "label108"
        Me.label108.Size = New System.Drawing.Size(38, 13)
        Me.label108.TabIndex = 2
        Me.label108.Text = "Layers"
        '
        'tabPage43
        '
        Me.tabPage43.Controls.Add(Me.tabControl9)
        Me.tabPage43.Controls.Add(Me.cbMotDetEnabled)
        Me.tabPage43.Location = New System.Drawing.Point(4, 22)
        Me.tabPage43.Name = "tabPage43"
        Me.tabPage43.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage43.Size = New System.Drawing.Size(307, 484)
        Me.tabPage43.TabIndex = 11
        Me.tabPage43.Text = "Motion detection"
        Me.tabPage43.UseVisualStyleBackColor = true
        '
        'tabControl9
        '
        Me.tabControl9.Controls.Add(Me.tabPage44)
        Me.tabControl9.Controls.Add(Me.tabPage45)
        Me.tabControl9.Location = New System.Drawing.Point(16, 45)
        Me.tabControl9.Name = "tabControl9"
        Me.tabControl9.SelectedIndex = 0
        Me.tabControl9.Size = New System.Drawing.Size(268, 413)
        Me.tabControl9.TabIndex = 1
        '
        'tabPage44
        '
        Me.tabPage44.Controls.Add(Me.pbMotionLevel)
        Me.tabPage44.Controls.Add(Me.label158)
        Me.tabPage44.Controls.Add(Me.mmMotDetMatrix)
        Me.tabPage44.Location = New System.Drawing.Point(4, 22)
        Me.tabPage44.Name = "tabPage44"
        Me.tabPage44.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage44.Size = New System.Drawing.Size(260, 387)
        Me.tabPage44.TabIndex = 0
        Me.tabPage44.Text = "Output matrix"
        Me.tabPage44.UseVisualStyleBackColor = true
        '
        'pbMotionLevel
        '
        Me.pbMotionLevel.Location = New System.Drawing.Point(17, 333)
        Me.pbMotionLevel.Name = "pbMotionLevel"
        Me.pbMotionLevel.Size = New System.Drawing.Size(225, 19)
        Me.pbMotionLevel.TabIndex = 2
        '
        'label158
        '
        Me.label158.AutoSize = true
        Me.label158.Location = New System.Drawing.Point(14, 313)
        Me.label158.Name = "label158"
        Me.label158.Size = New System.Drawing.Size(64, 13)
        Me.label158.TabIndex = 1
        Me.label158.Text = "Motion level"
        '
        'mmMotDetMatrix
        '
        Me.mmMotDetMatrix.Location = New System.Drawing.Point(6, 6)
        Me.mmMotDetMatrix.Multiline = true
        Me.mmMotDetMatrix.Name = "mmMotDetMatrix"
        Me.mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.mmMotDetMatrix.Size = New System.Drawing.Size(248, 252)
        Me.mmMotDetMatrix.TabIndex = 0
        '
        'tabPage45
        '
        Me.tabPage45.Controls.Add(Me.groupBox25)
        Me.tabPage45.Controls.Add(Me.btMotDetUpdateSettings)
        Me.tabPage45.Controls.Add(Me.groupBox27)
        Me.tabPage45.Controls.Add(Me.groupBox26)
        Me.tabPage45.Controls.Add(Me.groupBox24)
        Me.tabPage45.Location = New System.Drawing.Point(4, 22)
        Me.tabPage45.Name = "tabPage45"
        Me.tabPage45.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage45.Size = New System.Drawing.Size(260, 387)
        Me.tabPage45.TabIndex = 1
        Me.tabPage45.Text = "Settings"
        Me.tabPage45.UseVisualStyleBackColor = true
        '
        'groupBox25
        '
        Me.groupBox25.Controls.Add(Me.cbMotDetHLColor)
        Me.groupBox25.Controls.Add(Me.label161)
        Me.groupBox25.Controls.Add(Me.label160)
        Me.groupBox25.Controls.Add(Me.cbMotDetHLEnabled)
        Me.groupBox25.Controls.Add(Me.tbMotDetHLThreshold)
        Me.groupBox25.Location = New System.Drawing.Point(12, 103)
        Me.groupBox25.Name = "groupBox25"
        Me.groupBox25.Size = New System.Drawing.Size(233, 86)
        Me.groupBox25.TabIndex = 1
        Me.groupBox25.TabStop = false
        Me.groupBox25.Text = "Color highlight"
        '
        'cbMotDetHLColor
        '
        Me.cbMotDetHLColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMotDetHLColor.FormattingEnabled = true
        Me.cbMotDetHLColor.Items.AddRange(New Object() {"Red", "Green", "Blue"})
        Me.cbMotDetHLColor.Location = New System.Drawing.Point(153, 59)
        Me.cbMotDetHLColor.Name = "cbMotDetHLColor"
        Me.cbMotDetHLColor.Size = New System.Drawing.Size(70, 21)
        Me.cbMotDetHLColor.TabIndex = 5
        '
        'label161
        '
        Me.label161.AutoSize = true
        Me.label161.Location = New System.Drawing.Point(148, 42)
        Me.label161.Name = "label161"
        Me.label161.Size = New System.Drawing.Size(31, 13)
        Me.label161.TabIndex = 4
        Me.label161.Text = "Color"
        '
        'label160
        '
        Me.label160.AutoSize = true
        Me.label160.Location = New System.Drawing.Point(30, 42)
        Me.label160.Name = "label160"
        Me.label160.Size = New System.Drawing.Size(54, 13)
        Me.label160.TabIndex = 2
        Me.label160.Text = "Threshold"
        '
        'cbMotDetHLEnabled
        '
        Me.cbMotDetHLEnabled.AutoSize = true
        Me.cbMotDetHLEnabled.Checked = true
        Me.cbMotDetHLEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMotDetHLEnabled.Location = New System.Drawing.Point(14, 22)
        Me.cbMotDetHLEnabled.Name = "cbMotDetHLEnabled"
        Me.cbMotDetHLEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetHLEnabled.TabIndex = 1
        Me.cbMotDetHLEnabled.Text = "Enabled"
        Me.cbMotDetHLEnabled.UseVisualStyleBackColor = true
        '
        'tbMotDetHLThreshold
        '
        Me.tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window
        Me.tbMotDetHLThreshold.Location = New System.Drawing.Point(31, 58)
        Me.tbMotDetHLThreshold.Maximum = 255
        Me.tbMotDetHLThreshold.Name = "tbMotDetHLThreshold"
        Me.tbMotDetHLThreshold.Size = New System.Drawing.Size(104, 45)
        Me.tbMotDetHLThreshold.TabIndex = 3
        Me.tbMotDetHLThreshold.TickFrequency = 5
        Me.tbMotDetHLThreshold.Value = 25
        '
        'btMotDetUpdateSettings
        '
        Me.btMotDetUpdateSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btMotDetUpdateSettings.Location = New System.Drawing.Point(138, 358)
        Me.btMotDetUpdateSettings.Name = "btMotDetUpdateSettings"
        Me.btMotDetUpdateSettings.Size = New System.Drawing.Size(107, 23)
        Me.btMotDetUpdateSettings.TabIndex = 4
        Me.btMotDetUpdateSettings.Text = "Update settings"
        Me.btMotDetUpdateSettings.UseVisualStyleBackColor = true
        '
        'groupBox27
        '
        Me.groupBox27.Controls.Add(Me.edMotDetMatrixHeight)
        Me.groupBox27.Controls.Add(Me.label163)
        Me.groupBox27.Controls.Add(Me.edMotDetMatrixWidth)
        Me.groupBox27.Controls.Add(Me.label164)
        Me.groupBox27.Location = New System.Drawing.Point(12, 266)
        Me.groupBox27.Name = "groupBox27"
        Me.groupBox27.Size = New System.Drawing.Size(233, 59)
        Me.groupBox27.TabIndex = 3
        Me.groupBox27.TabStop = false
        Me.groupBox27.Text = "Matrix"
        '
        'edMotDetMatrixHeight
        '
        Me.edMotDetMatrixHeight.Location = New System.Drawing.Point(145, 23)
        Me.edMotDetMatrixHeight.Name = "edMotDetMatrixHeight"
        Me.edMotDetMatrixHeight.Size = New System.Drawing.Size(36, 20)
        Me.edMotDetMatrixHeight.TabIndex = 75
        Me.edMotDetMatrixHeight.Text = "10"
        '
        'label163
        '
        Me.label163.AutoSize = true
        Me.label163.Location = New System.Drawing.Point(98, 26)
        Me.label163.Name = "label163"
        Me.label163.Size = New System.Drawing.Size(38, 13)
        Me.label163.TabIndex = 74
        Me.label163.Text = "Height"
        '
        'edMotDetMatrixWidth
        '
        Me.edMotDetMatrixWidth.Location = New System.Drawing.Point(56, 23)
        Me.edMotDetMatrixWidth.Name = "edMotDetMatrixWidth"
        Me.edMotDetMatrixWidth.Size = New System.Drawing.Size(36, 20)
        Me.edMotDetMatrixWidth.TabIndex = 73
        Me.edMotDetMatrixWidth.Text = "10"
        '
        'label164
        '
        Me.label164.AutoSize = true
        Me.label164.Location = New System.Drawing.Point(14, 26)
        Me.label164.Name = "label164"
        Me.label164.Size = New System.Drawing.Size(35, 13)
        Me.label164.TabIndex = 72
        Me.label164.Text = "Width"
        '
        'groupBox26
        '
        Me.groupBox26.Controls.Add(Me.label162)
        Me.groupBox26.Controls.Add(Me.tbMotDetDropFramesThreshold)
        Me.groupBox26.Controls.Add(Me.cbMotDetDropFramesEnabled)
        Me.groupBox26.Location = New System.Drawing.Point(12, 191)
        Me.groupBox26.Name = "groupBox26"
        Me.groupBox26.Size = New System.Drawing.Size(233, 69)
        Me.groupBox26.TabIndex = 2
        Me.groupBox26.TabStop = false
        Me.groupBox26.Text = "Drop frames"
        '
        'label162
        '
        Me.label162.AutoSize = true
        Me.label162.Location = New System.Drawing.Point(94, 21)
        Me.label162.Name = "label162"
        Me.label162.Size = New System.Drawing.Size(54, 13)
        Me.label162.TabIndex = 4
        Me.label162.Text = "Threshold"
        '
        'tbMotDetDropFramesThreshold
        '
        Me.tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window
        Me.tbMotDetDropFramesThreshold.Location = New System.Drawing.Point(95, 37)
        Me.tbMotDetDropFramesThreshold.Maximum = 255
        Me.tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold"
        Me.tbMotDetDropFramesThreshold.Size = New System.Drawing.Size(104, 45)
        Me.tbMotDetDropFramesThreshold.TabIndex = 5
        Me.tbMotDetDropFramesThreshold.TickFrequency = 5
        Me.tbMotDetDropFramesThreshold.Value = 5
        '
        'cbMotDetDropFramesEnabled
        '
        Me.cbMotDetDropFramesEnabled.AutoSize = true
        Me.cbMotDetDropFramesEnabled.Location = New System.Drawing.Point(14, 19)
        Me.cbMotDetDropFramesEnabled.Name = "cbMotDetDropFramesEnabled"
        Me.cbMotDetDropFramesEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetDropFramesEnabled.TabIndex = 1
        Me.cbMotDetDropFramesEnabled.Text = "Enabled"
        Me.cbMotDetDropFramesEnabled.UseVisualStyleBackColor = true
        '
        'groupBox24
        '
        Me.groupBox24.Controls.Add(Me.edMotDetFrameInterval)
        Me.groupBox24.Controls.Add(Me.label159)
        Me.groupBox24.Controls.Add(Me.cbCompareGreyscale)
        Me.groupBox24.Controls.Add(Me.cbCompareBlue)
        Me.groupBox24.Controls.Add(Me.cbCompareGreen)
        Me.groupBox24.Controls.Add(Me.cbCompareRed)
        Me.groupBox24.Location = New System.Drawing.Point(12, 12)
        Me.groupBox24.Name = "groupBox24"
        Me.groupBox24.Size = New System.Drawing.Size(233, 82)
        Me.groupBox24.TabIndex = 0
        Me.groupBox24.TabStop = false
        Me.groupBox24.Text = "Compare settings"
        '
        'edMotDetFrameInterval
        '
        Me.edMotDetFrameInterval.Location = New System.Drawing.Point(95, 51)
        Me.edMotDetFrameInterval.Name = "edMotDetFrameInterval"
        Me.edMotDetFrameInterval.Size = New System.Drawing.Size(32, 20)
        Me.edMotDetFrameInterval.TabIndex = 5
        Me.edMotDetFrameInterval.Text = "2"
        '
        'label159
        '
        Me.label159.AutoSize = true
        Me.label159.Location = New System.Drawing.Point(11, 54)
        Me.label159.Name = "label159"
        Me.label159.Size = New System.Drawing.Size(73, 13)
        Me.label159.TabIndex = 4
        Me.label159.Text = "Frame interval"
        '
        'cbCompareGreyscale
        '
        Me.cbCompareGreyscale.AutoSize = true
        Me.cbCompareGreyscale.Checked = true
        Me.cbCompareGreyscale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCompareGreyscale.Location = New System.Drawing.Point(163, 21)
        Me.cbCompareGreyscale.Name = "cbCompareGreyscale"
        Me.cbCompareGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbCompareGreyscale.TabIndex = 3
        Me.cbCompareGreyscale.Text = "Greyscale"
        Me.cbCompareGreyscale.UseVisualStyleBackColor = true
        '
        'cbCompareBlue
        '
        Me.cbCompareBlue.AutoSize = true
        Me.cbCompareBlue.Location = New System.Drawing.Point(118, 21)
        Me.cbCompareBlue.Name = "cbCompareBlue"
        Me.cbCompareBlue.Size = New System.Drawing.Size(47, 17)
        Me.cbCompareBlue.TabIndex = 2
        Me.cbCompareBlue.Text = "Blue"
        Me.cbCompareBlue.UseVisualStyleBackColor = true
        '
        'cbCompareGreen
        '
        Me.cbCompareGreen.AutoSize = true
        Me.cbCompareGreen.Location = New System.Drawing.Point(60, 21)
        Me.cbCompareGreen.Name = "cbCompareGreen"
        Me.cbCompareGreen.Size = New System.Drawing.Size(55, 17)
        Me.cbCompareGreen.TabIndex = 1
        Me.cbCompareGreen.Text = "Green"
        Me.cbCompareGreen.UseVisualStyleBackColor = true
        '
        'cbCompareRed
        '
        Me.cbCompareRed.AutoSize = true
        Me.cbCompareRed.Location = New System.Drawing.Point(14, 21)
        Me.cbCompareRed.Name = "cbCompareRed"
        Me.cbCompareRed.Size = New System.Drawing.Size(46, 17)
        Me.cbCompareRed.TabIndex = 0
        Me.cbCompareRed.Text = "Red"
        Me.cbCompareRed.UseVisualStyleBackColor = true
        '
        'cbMotDetEnabled
        '
        Me.cbMotDetEnabled.AutoSize = true
        Me.cbMotDetEnabled.Location = New System.Drawing.Point(16, 18)
        Me.cbMotDetEnabled.Name = "cbMotDetEnabled"
        Me.cbMotDetEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetEnabled.TabIndex = 0
        Me.cbMotDetEnabled.Text = "Enabled"
        Me.cbMotDetEnabled.UseVisualStyleBackColor = true
        '
        'TabPage26
        '
        Me.TabPage26.Controls.Add(Me.label505)
        Me.TabPage26.Controls.Add(Me.rbMotionDetectionExProcessor)
        Me.TabPage26.Controls.Add(Me.label389)
        Me.TabPage26.Controls.Add(Me.rbMotionDetectionExDetector)
        Me.TabPage26.Controls.Add(Me.label64)
        Me.TabPage26.Controls.Add(Me.cbMotionDetectionEx)
        Me.TabPage26.Controls.Add(Me.label65)
        Me.TabPage26.Controls.Add(Me.pbAFMotionLevel)
        Me.TabPage26.Location = New System.Drawing.Point(4, 22)
        Me.TabPage26.Name = "TabPage26"
        Me.TabPage26.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage26.Size = New System.Drawing.Size(307, 484)
        Me.TabPage26.TabIndex = 20
        Me.TabPage26.Text = "Motion detection (Extended)"
        Me.TabPage26.UseVisualStyleBackColor = true
        '
        'label505
        '
        Me.label505.AutoSize = true
        Me.label505.Location = New System.Drawing.Point(19, 107)
        Me.label505.Name = "label505"
        Me.label505.Size = New System.Drawing.Size(54, 13)
        Me.label505.TabIndex = 29
        Me.label505.Text = "Processor"
        '
        'rbMotionDetectionExProcessor
        '
        Me.rbMotionDetectionExProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.rbMotionDetectionExProcessor.FormattingEnabled = true
        Me.rbMotionDetectionExProcessor.Items.AddRange(New Object() {"None", "Blob counting objects", "GridMotionAreaProcessing", "Motion area highlighting", "Motion border highlighting"})
        Me.rbMotionDetectionExProcessor.Location = New System.Drawing.Point(19, 123)
        Me.rbMotionDetectionExProcessor.Name = "rbMotionDetectionExProcessor"
        Me.rbMotionDetectionExProcessor.Size = New System.Drawing.Size(258, 21)
        Me.rbMotionDetectionExProcessor.TabIndex = 28
        '
        'label389
        '
        Me.label389.AutoSize = true
        Me.label389.Location = New System.Drawing.Point(19, 57)
        Me.label389.Name = "label389"
        Me.label389.Size = New System.Drawing.Size(48, 13)
        Me.label389.TabIndex = 27
        Me.label389.Text = "Detector"
        '
        'rbMotionDetectionExDetector
        '
        Me.rbMotionDetectionExDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.rbMotionDetectionExDetector.FormattingEnabled = true
        Me.rbMotionDetectionExDetector.Items.AddRange(New Object() {"Custom frame difference", "Simple background modeling", "Two frames difference"})
        Me.rbMotionDetectionExDetector.Location = New System.Drawing.Point(19, 73)
        Me.rbMotionDetectionExDetector.Name = "rbMotionDetectionExDetector"
        Me.rbMotionDetectionExDetector.Size = New System.Drawing.Size(258, 21)
        Me.rbMotionDetectionExDetector.TabIndex = 26
        '
        'label64
        '
        Me.label64.AutoSize = true
        Me.label64.Location = New System.Drawing.Point(45, 451)
        Me.label64.Name = "label64"
        Me.label64.Size = New System.Drawing.Size(173, 13)
        Me.label64.TabIndex = 25
        Me.label64.Text = "Much more options available in API"
        '
        'cbMotionDetectionEx
        '
        Me.cbMotionDetectionEx.AutoSize = true
        Me.cbMotionDetectionEx.Location = New System.Drawing.Point(19, 19)
        Me.cbMotionDetectionEx.Name = "cbMotionDetectionEx"
        Me.cbMotionDetectionEx.Size = New System.Drawing.Size(65, 17)
        Me.cbMotionDetectionEx.TabIndex = 24
        Me.cbMotionDetectionEx.Text = "Enabled"
        Me.cbMotionDetectionEx.UseVisualStyleBackColor = true
        '
        'label65
        '
        Me.label65.AutoSize = true
        Me.label65.Location = New System.Drawing.Point(19, 165)
        Me.label65.Name = "label65"
        Me.label65.Size = New System.Drawing.Size(64, 13)
        Me.label65.TabIndex = 13
        Me.label65.Text = "Motion level"
        '
        'pbAFMotionLevel
        '
        Me.pbAFMotionLevel.Location = New System.Drawing.Point(19, 181)
        Me.pbAFMotionLevel.Name = "pbAFMotionLevel"
        Me.pbAFMotionLevel.Size = New System.Drawing.Size(258, 23)
        Me.pbAFMotionLevel.TabIndex = 12
        '
        'TabPage25
        '
        Me.TabPage25.Controls.Add(Me.edBarcodeMetadata)
        Me.TabPage25.Controls.Add(Me.label91)
        Me.TabPage25.Controls.Add(Me.cbBarcodeType)
        Me.TabPage25.Controls.Add(Me.label90)
        Me.TabPage25.Controls.Add(Me.btBarcodeReset)
        Me.TabPage25.Controls.Add(Me.edBarcode)
        Me.TabPage25.Controls.Add(Me.label89)
        Me.TabPage25.Controls.Add(Me.cbBarcodeDetectionEnabled)
        Me.TabPage25.Location = New System.Drawing.Point(4, 22)
        Me.TabPage25.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage25.Name = "TabPage25"
        Me.TabPage25.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage25.Size = New System.Drawing.Size(307, 484)
        Me.TabPage25.TabIndex = 13
        Me.TabPage25.Text = "Barcode reader"
        Me.TabPage25.UseVisualStyleBackColor = true
        '
        'edBarcodeMetadata
        '
        Me.edBarcodeMetadata.Location = New System.Drawing.Point(9, 159)
        Me.edBarcodeMetadata.Margin = New System.Windows.Forms.Padding(2)
        Me.edBarcodeMetadata.Multiline = true
        Me.edBarcodeMetadata.Name = "edBarcodeMetadata"
        Me.edBarcodeMetadata.Size = New System.Drawing.Size(282, 96)
        Me.edBarcodeMetadata.TabIndex = 16
        '
        'label91
        '
        Me.label91.AutoSize = true
        Me.label91.Location = New System.Drawing.Point(7, 141)
        Me.label91.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label91.Name = "label91"
        Me.label91.Size = New System.Drawing.Size(52, 13)
        Me.label91.TabIndex = 15
        Me.label91.Text = "Metadata"
        '
        'cbBarcodeType
        '
        Me.cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBarcodeType.FormattingEnabled = true
        Me.cbBarcodeType.Items.AddRange(New Object() {"Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417"})
        Me.cbBarcodeType.Location = New System.Drawing.Point(9, 63)
        Me.cbBarcodeType.Margin = New System.Windows.Forms.Padding(2)
        Me.cbBarcodeType.Name = "cbBarcodeType"
        Me.cbBarcodeType.Size = New System.Drawing.Size(160, 21)
        Me.cbBarcodeType.TabIndex = 14
        '
        'label90
        '
        Me.label90.AutoSize = true
        Me.label90.Location = New System.Drawing.Point(7, 47)
        Me.label90.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label90.Name = "label90"
        Me.label90.Size = New System.Drawing.Size(70, 13)
        Me.label90.TabIndex = 13
        Me.label90.Text = "Barcode type"
        '
        'btBarcodeReset
        '
        Me.btBarcodeReset.Location = New System.Drawing.Point(9, 267)
        Me.btBarcodeReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btBarcodeReset.Name = "btBarcodeReset"
        Me.btBarcodeReset.Size = New System.Drawing.Size(62, 23)
        Me.btBarcodeReset.TabIndex = 12
        Me.btBarcodeReset.Text = "Restart"
        Me.btBarcodeReset.UseVisualStyleBackColor = true
        '
        'edBarcode
        '
        Me.edBarcode.Location = New System.Drawing.Point(9, 111)
        Me.edBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.edBarcode.Name = "edBarcode"
        Me.edBarcode.Size = New System.Drawing.Size(282, 20)
        Me.edBarcode.TabIndex = 11
        '
        'label89
        '
        Me.label89.AutoSize = true
        Me.label89.Location = New System.Drawing.Point(7, 95)
        Me.label89.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label89.Name = "label89"
        Me.label89.Size = New System.Drawing.Size(93, 13)
        Me.label89.TabIndex = 10
        Me.label89.Text = "Detected barcode"
        '
        'cbBarcodeDetectionEnabled
        '
        Me.cbBarcodeDetectionEnabled.AutoSize = true
        Me.cbBarcodeDetectionEnabled.Location = New System.Drawing.Point(9, 17)
        Me.cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled"
        Me.cbBarcodeDetectionEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbBarcodeDetectionEnabled.TabIndex = 9
        Me.cbBarcodeDetectionEnabled.Text = "Enabled"
        Me.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true
        '
        'TabPage100
        '
        Me.TabPage100.Controls.Add(Me.label328)
        Me.TabPage100.Controls.Add(Me.label327)
        Me.TabPage100.Controls.Add(Me.label326)
        Me.TabPage100.Controls.Add(Me.label325)
        Me.TabPage100.Controls.Add(Me.cbVirtualCamera)
        Me.TabPage100.Location = New System.Drawing.Point(4, 22)
        Me.TabPage100.Name = "TabPage100"
        Me.TabPage100.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage100.Size = New System.Drawing.Size(307, 484)
        Me.TabPage100.TabIndex = 14
        Me.TabPage100.Text = "Virtual camera"
        Me.TabPage100.UseVisualStyleBackColor = true
        '
        'label328
        '
        Me.label328.AutoSize = true
        Me.label328.Location = New System.Drawing.Point(15, 125)
        Me.label328.Name = "label328"
        Me.label328.Size = New System.Drawing.Size(197, 13)
        Me.label328.TabIndex = 7
        Me.label328.Text = "TRIAL limitation - 5000 frames to stream."
        '
        'label327
        '
        Me.label327.AutoSize = true
        Me.label327.Location = New System.Drawing.Point(15, 103)
        Me.label327.Name = "label327"
        Me.label327.Size = New System.Drawing.Size(180, 13)
        Me.label327.TabIndex = 6
        Me.label327.Text = "Virtual Camera SDK license required."
        '
        'label326
        '
        Me.label326.AutoSize = true
        Me.label326.Location = New System.Drawing.Point(15, 72)
        Me.label326.Name = "label326"
        Me.label326.Size = New System.Drawing.Size(111, 13)
        Me.label326.TabIndex = 5
        Me.label326.Text = "to see streamed video"
        '
        'label325
        '
        Me.label325.AutoSize = true
        Me.label325.Location = New System.Drawing.Point(15, 52)
        Me.label325.Name = "label325"
        Me.label325.Size = New System.Drawing.Size(243, 13)
        Me.label325.TabIndex = 4
        Me.label325.Text = "You are can use VisioForge Virtual Camera device"
        '
        'cbVirtualCamera
        '
        Me.cbVirtualCamera.AutoSize = true
        Me.cbVirtualCamera.Location = New System.Drawing.Point(18, 18)
        Me.cbVirtualCamera.Name = "cbVirtualCamera"
        Me.cbVirtualCamera.Size = New System.Drawing.Size(107, 17)
        Me.cbVirtualCamera.TabIndex = 3
        Me.cbVirtualCamera.Text = "Enable streaming"
        Me.cbVirtualCamera.UseVisualStyleBackColor = true
        '
        'TabPage102
        '
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputDownConversionAnalogOutput)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputDownConversion)
        Me.TabPage102.Controls.Add(Me.label337)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputHDTVPulldown)
        Me.TabPage102.Controls.Add(Me.label336)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputBlackToDeck)
        Me.TabPage102.Controls.Add(Me.label335)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputSingleField)
        Me.TabPage102.Controls.Add(Me.label334)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputComponentLevels)
        Me.TabPage102.Controls.Add(Me.label333)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputNTSC)
        Me.TabPage102.Controls.Add(Me.label332)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputDualLink)
        Me.TabPage102.Controls.Add(Me.label331)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutputAnalog)
        Me.TabPage102.Controls.Add(Me.label87)
        Me.TabPage102.Controls.Add(Me.cbDecklinkDV)
        Me.TabPage102.Controls.Add(Me.cbDecklinkOutput)
        Me.TabPage102.Location = New System.Drawing.Point(4, 22)
        Me.TabPage102.Name = "TabPage102"
        Me.TabPage102.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage102.Size = New System.Drawing.Size(307, 484)
        Me.TabPage102.TabIndex = 15
        Me.TabPage102.Text = "Decklink output"
        Me.TabPage102.UseVisualStyleBackColor = true
        '
        'cbDecklinkOutputDownConversionAnalogOutput
        '
        Me.cbDecklinkOutputDownConversionAnalogOutput.AutoSize = true
        Me.cbDecklinkOutputDownConversionAnalogOutput.Location = New System.Drawing.Point(18, 246)
        Me.cbDecklinkOutputDownConversionAnalogOutput.Name = "cbDecklinkOutputDownConversionAnalogOutput"
        Me.cbDecklinkOutputDownConversionAnalogOutput.Size = New System.Drawing.Size(118, 17)
        Me.cbDecklinkOutputDownConversionAnalogOutput.TabIndex = 35
        Me.cbDecklinkOutputDownConversionAnalogOutput.Text = "Analog output used"
        Me.cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = true
        '
        'cbDecklinkOutputDownConversion
        '
        Me.cbDecklinkOutputDownConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputDownConversion.FormattingEnabled = true
        Me.cbDecklinkOutputDownConversion.Items.AddRange(New Object() {"Default", "Disabled", "Letterbox 16:9", "Anamorphic", "Anamorphic center"})
        Me.cbDecklinkOutputDownConversion.Location = New System.Drawing.Point(18, 222)
        Me.cbDecklinkOutputDownConversion.Name = "cbDecklinkOutputDownConversion"
        Me.cbDecklinkOutputDownConversion.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputDownConversion.TabIndex = 34
        '
        'label337
        '
        Me.label337.AutoSize = true
        Me.label337.Location = New System.Drawing.Point(15, 206)
        Me.label337.Name = "label337"
        Me.label337.Size = New System.Drawing.Size(119, 13)
        Me.label337.TabIndex = 33
        Me.label337.Text = "Down conversion mode"
        '
        'cbDecklinkOutputHDTVPulldown
        '
        Me.cbDecklinkOutputHDTVPulldown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputHDTVPulldown.FormattingEnabled = true
        Me.cbDecklinkOutputHDTVPulldown.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputHDTVPulldown.Location = New System.Drawing.Point(18, 293)
        Me.cbDecklinkOutputHDTVPulldown.Name = "cbDecklinkOutputHDTVPulldown"
        Me.cbDecklinkOutputHDTVPulldown.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputHDTVPulldown.TabIndex = 32
        '
        'label336
        '
        Me.label336.AutoSize = true
        Me.label336.Location = New System.Drawing.Point(15, 277)
        Me.label336.Name = "label336"
        Me.label336.Size = New System.Drawing.Size(82, 13)
        Me.label336.TabIndex = 31
        Me.label336.Text = "HDTV pulldown"
        '
        'cbDecklinkOutputBlackToDeck
        '
        Me.cbDecklinkOutputBlackToDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputBlackToDeck.FormattingEnabled = true
        Me.cbDecklinkOutputBlackToDeck.Items.AddRange(New Object() {"Default", "None", "Digital", "Analogue"})
        Me.cbDecklinkOutputBlackToDeck.Location = New System.Drawing.Point(18, 175)
        Me.cbDecklinkOutputBlackToDeck.Name = "cbDecklinkOutputBlackToDeck"
        Me.cbDecklinkOutputBlackToDeck.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputBlackToDeck.TabIndex = 30
        '
        'label335
        '
        Me.label335.AutoSize = true
        Me.label335.Location = New System.Drawing.Point(15, 159)
        Me.label335.Name = "label335"
        Me.label335.Size = New System.Drawing.Size(73, 13)
        Me.label335.TabIndex = 29
        Me.label335.Text = "Black to deck"
        '
        'cbDecklinkOutputSingleField
        '
        Me.cbDecklinkOutputSingleField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputSingleField.FormattingEnabled = true
        Me.cbDecklinkOutputSingleField.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputSingleField.Location = New System.Drawing.Point(18, 130)
        Me.cbDecklinkOutputSingleField.Name = "cbDecklinkOutputSingleField"
        Me.cbDecklinkOutputSingleField.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputSingleField.TabIndex = 28
        '
        'label334
        '
        Me.label334.AutoSize = true
        Me.label334.Location = New System.Drawing.Point(15, 114)
        Me.label334.Name = "label334"
        Me.label334.Size = New System.Drawing.Size(91, 13)
        Me.label334.TabIndex = 27
        Me.label334.Text = "Single field output"
        '
        'cbDecklinkOutputComponentLevels
        '
        Me.cbDecklinkOutputComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputComponentLevels.FormattingEnabled = true
        Me.cbDecklinkOutputComponentLevels.Items.AddRange(New Object() {"SMPTE", "Betacam"})
        Me.cbDecklinkOutputComponentLevels.Location = New System.Drawing.Point(154, 175)
        Me.cbDecklinkOutputComponentLevels.Name = "cbDecklinkOutputComponentLevels"
        Me.cbDecklinkOutputComponentLevels.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputComponentLevels.TabIndex = 26
        '
        'label333
        '
        Me.label333.AutoSize = true
        Me.label333.Location = New System.Drawing.Point(151, 159)
        Me.label333.Name = "label333"
        Me.label333.Size = New System.Drawing.Size(91, 13)
        Me.label333.TabIndex = 25
        Me.label333.Text = "Component levels"
        '
        'cbDecklinkOutputNTSC
        '
        Me.cbDecklinkOutputNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputNTSC.FormattingEnabled = true
        Me.cbDecklinkOutputNTSC.Items.AddRange(New Object() {"USA", "Japan"})
        Me.cbDecklinkOutputNTSC.Location = New System.Drawing.Point(154, 130)
        Me.cbDecklinkOutputNTSC.Name = "cbDecklinkOutputNTSC"
        Me.cbDecklinkOutputNTSC.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputNTSC.TabIndex = 24
        '
        'label332
        '
        Me.label332.AutoSize = true
        Me.label332.Location = New System.Drawing.Point(151, 114)
        Me.label332.Name = "label332"
        Me.label332.Size = New System.Drawing.Size(80, 13)
        Me.label332.TabIndex = 23
        Me.label332.Text = "NTSC standard"
        '
        'cbDecklinkOutputDualLink
        '
        Me.cbDecklinkOutputDualLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputDualLink.FormattingEnabled = true
        Me.cbDecklinkOutputDualLink.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputDualLink.Location = New System.Drawing.Point(18, 85)
        Me.cbDecklinkOutputDualLink.Name = "cbDecklinkOutputDualLink"
        Me.cbDecklinkOutputDualLink.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputDualLink.TabIndex = 22
        '
        'label331
        '
        Me.label331.AutoSize = true
        Me.label331.Location = New System.Drawing.Point(15, 69)
        Me.label331.Name = "label331"
        Me.label331.Size = New System.Drawing.Size(77, 13)
        Me.label331.TabIndex = 21
        Me.label331.Text = "Dual link mode"
        '
        'cbDecklinkOutputAnalog
        '
        Me.cbDecklinkOutputAnalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputAnalog.FormattingEnabled = true
        Me.cbDecklinkOutputAnalog.Items.AddRange(New Object() {"Auto", "Component", "Composite", "S-Video"})
        Me.cbDecklinkOutputAnalog.Location = New System.Drawing.Point(154, 85)
        Me.cbDecklinkOutputAnalog.Name = "cbDecklinkOutputAnalog"
        Me.cbDecklinkOutputAnalog.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputAnalog.TabIndex = 20
        '
        'label87
        '
        Me.label87.AutoSize = true
        Me.label87.Location = New System.Drawing.Point(151, 69)
        Me.label87.Name = "label87"
        Me.label87.Size = New System.Drawing.Size(73, 13)
        Me.label87.TabIndex = 19
        Me.label87.Text = "Analog output"
        '
        'cbDecklinkDV
        '
        Me.cbDecklinkDV.AutoSize = true
        Me.cbDecklinkDV.Location = New System.Drawing.Point(27, 39)
        Me.cbDecklinkDV.Name = "cbDecklinkDV"
        Me.cbDecklinkDV.Size = New System.Drawing.Size(74, 17)
        Me.cbDecklinkDV.TabIndex = 3
        Me.cbDecklinkDV.Text = "DV output"
        Me.cbDecklinkDV.UseVisualStyleBackColor = true
        '
        'cbDecklinkOutput
        '
        Me.cbDecklinkOutput.AutoSize = true
        Me.cbDecklinkOutput.Location = New System.Drawing.Point(9, 16)
        Me.cbDecklinkOutput.Name = "cbDecklinkOutput"
        Me.cbDecklinkOutput.Size = New System.Drawing.Size(173, 17)
        Me.cbDecklinkOutput.TabIndex = 2
        Me.cbDecklinkOutput.Text = "Enable output to Decklink card"
        Me.cbDecklinkOutput.UseVisualStyleBackColor = true
        '
        'TabPage105
        '
        Me.TabPage105.Controls.Add(Me.groupBox48)
        Me.TabPage105.Controls.Add(Me.groupBox47)
        Me.TabPage105.Controls.Add(Me.groupBox43)
        Me.TabPage105.Location = New System.Drawing.Point(4, 22)
        Me.TabPage105.Name = "TabPage105"
        Me.TabPage105.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage105.Size = New System.Drawing.Size(307, 484)
        Me.TabPage105.TabIndex = 16
        Me.TabPage105.Text = "Encryption"
        Me.TabPage105.UseVisualStyleBackColor = true
        '
        'groupBox48
        '
        Me.groupBox48.Controls.Add(Me.label343)
        Me.groupBox48.Controls.Add(Me.edEncryptionKeyHEX)
        Me.groupBox48.Controls.Add(Me.rbEncryptionKeyBinary)
        Me.groupBox48.Controls.Add(Me.btEncryptionOpenFile)
        Me.groupBox48.Controls.Add(Me.edEncryptionKeyFile)
        Me.groupBox48.Controls.Add(Me.rbEncryptionKeyFile)
        Me.groupBox48.Controls.Add(Me.edEncryptionKeyString)
        Me.groupBox48.Controls.Add(Me.rbEncryptionKeyString)
        Me.groupBox48.Location = New System.Drawing.Point(18, 195)
        Me.groupBox48.Name = "groupBox48"
        Me.groupBox48.Size = New System.Drawing.Size(269, 224)
        Me.groupBox48.TabIndex = 11
        Me.groupBox48.TabStop = false
        Me.groupBox48.Text = "Encryption key type"
        '
        'label343
        '
        Me.label343.AutoSize = true
        Me.label343.Location = New System.Drawing.Point(33, 199)
        Me.label343.Name = "label343"
        Me.label343.Size = New System.Drawing.Size(157, 13)
        Me.label343.TabIndex = 10
        Me.label343.Text = "You can assign byte[] using API"
        '
        'edEncryptionKeyHEX
        '
        Me.edEncryptionKeyHEX.Location = New System.Drawing.Point(36, 176)
        Me.edEncryptionKeyHEX.Name = "edEncryptionKeyHEX"
        Me.edEncryptionKeyHEX.Size = New System.Drawing.Size(214, 20)
        Me.edEncryptionKeyHEX.TabIndex = 9
        Me.edEncryptionKeyHEX.Text = "enter hex data"
        '
        'rbEncryptionKeyBinary
        '
        Me.rbEncryptionKeyBinary.AutoSize = true
        Me.rbEncryptionKeyBinary.Location = New System.Drawing.Point(14, 153)
        Me.rbEncryptionKeyBinary.Name = "rbEncryptionKeyBinary"
        Me.rbEncryptionKeyBinary.Size = New System.Drawing.Size(124, 17)
        Me.rbEncryptionKeyBinary.TabIndex = 8
        Me.rbEncryptionKeyBinary.Text = "Binary data (v9 SDK)"
        Me.rbEncryptionKeyBinary.UseVisualStyleBackColor = true
        '
        'btEncryptionOpenFile
        '
        Me.btEncryptionOpenFile.Location = New System.Drawing.Point(227, 114)
        Me.btEncryptionOpenFile.Name = "btEncryptionOpenFile"
        Me.btEncryptionOpenFile.Size = New System.Drawing.Size(23, 23)
        Me.btEncryptionOpenFile.TabIndex = 7
        Me.btEncryptionOpenFile.Text = "..."
        Me.btEncryptionOpenFile.UseVisualStyleBackColor = true
        '
        'edEncryptionKeyFile
        '
        Me.edEncryptionKeyFile.Location = New System.Drawing.Point(36, 116)
        Me.edEncryptionKeyFile.Name = "edEncryptionKeyFile"
        Me.edEncryptionKeyFile.Size = New System.Drawing.Size(185, 20)
        Me.edEncryptionKeyFile.TabIndex = 6
        Me.edEncryptionKeyFile.Text = "c:\keyfile.txt"
        '
        'rbEncryptionKeyFile
        '
        Me.rbEncryptionKeyFile.AutoSize = true
        Me.rbEncryptionKeyFile.Location = New System.Drawing.Point(14, 93)
        Me.rbEncryptionKeyFile.Name = "rbEncryptionKeyFile"
        Me.rbEncryptionKeyFile.Size = New System.Drawing.Size(87, 17)
        Me.rbEncryptionKeyFile.TabIndex = 5
        Me.rbEncryptionKeyFile.Text = "File (v9 SDK)"
        Me.rbEncryptionKeyFile.UseVisualStyleBackColor = true
        '
        'edEncryptionKeyString
        '
        Me.edEncryptionKeyString.Location = New System.Drawing.Point(36, 56)
        Me.edEncryptionKeyString.Name = "edEncryptionKeyString"
        Me.edEncryptionKeyString.Size = New System.Drawing.Size(214, 20)
        Me.edEncryptionKeyString.TabIndex = 4
        Me.edEncryptionKeyString.Text = "100"
        '
        'rbEncryptionKeyString
        '
        Me.rbEncryptionKeyString.AutoSize = true
        Me.rbEncryptionKeyString.Checked = true
        Me.rbEncryptionKeyString.Location = New System.Drawing.Point(14, 28)
        Me.rbEncryptionKeyString.Name = "rbEncryptionKeyString"
        Me.rbEncryptionKeyString.Size = New System.Drawing.Size(52, 17)
        Me.rbEncryptionKeyString.TabIndex = 0
        Me.rbEncryptionKeyString.TabStop = true
        Me.rbEncryptionKeyString.Text = "String"
        Me.rbEncryptionKeyString.UseVisualStyleBackColor = true
        '
        'groupBox47
        '
        Me.groupBox47.Controls.Add(Me.rbEncryptionModeAES256)
        Me.groupBox47.Controls.Add(Me.rbEncryptionModeAES128)
        Me.groupBox47.Location = New System.Drawing.Point(18, 17)
        Me.groupBox47.Name = "groupBox47"
        Me.groupBox47.Size = New System.Drawing.Size(269, 83)
        Me.groupBox47.TabIndex = 10
        Me.groupBox47.TabStop = false
        Me.groupBox47.Text = "Method"
        '
        'rbEncryptionModeAES256
        '
        Me.rbEncryptionModeAES256.AutoSize = true
        Me.rbEncryptionModeAES256.Checked = true
        Me.rbEncryptionModeAES256.Location = New System.Drawing.Point(14, 51)
        Me.rbEncryptionModeAES256.Name = "rbEncryptionModeAES256"
        Me.rbEncryptionModeAES256.Size = New System.Drawing.Size(198, 17)
        Me.rbEncryptionModeAES256.TabIndex = 1
        Me.rbEncryptionModeAES256.TabStop = true
        Me.rbEncryptionModeAES256.Text = "AES-256 (v9 encryption SDK output)"
        Me.rbEncryptionModeAES256.UseVisualStyleBackColor = true
        '
        'rbEncryptionModeAES128
        '
        Me.rbEncryptionModeAES128.AutoSize = true
        Me.rbEncryptionModeAES128.Location = New System.Drawing.Point(14, 28)
        Me.rbEncryptionModeAES128.Name = "rbEncryptionModeAES128"
        Me.rbEncryptionModeAES128.Size = New System.Drawing.Size(198, 17)
        Me.rbEncryptionModeAES128.TabIndex = 0
        Me.rbEncryptionModeAES128.Text = "AES-128 (v8 encryption SDK output)"
        Me.rbEncryptionModeAES128.UseVisualStyleBackColor = true
        '
        'groupBox43
        '
        Me.groupBox43.Controls.Add(Me.rbEncryptedH264CUDA)
        Me.groupBox43.Controls.Add(Me.rbEncryptedH264SW)
        Me.groupBox43.Location = New System.Drawing.Point(18, 106)
        Me.groupBox43.Name = "groupBox43"
        Me.groupBox43.Size = New System.Drawing.Size(269, 83)
        Me.groupBox43.TabIndex = 9
        Me.groupBox43.TabStop = false
        Me.groupBox43.Text = "Video / audio format"
        '
        'rbEncryptedH264CUDA
        '
        Me.rbEncryptedH264CUDA.AutoSize = true
        Me.rbEncryptedH264CUDA.Location = New System.Drawing.Point(14, 51)
        Me.rbEncryptedH264CUDA.Name = "rbEncryptedH264CUDA"
        Me.rbEncryptedH264CUDA.Size = New System.Drawing.Size(228, 17)
        Me.rbEncryptedH264CUDA.TabIndex = 7
        Me.rbEncryptedH264CUDA.Text = "Use MP4 H264 CUDA / AAC output format"
        Me.rbEncryptedH264CUDA.UseVisualStyleBackColor = true
        '
        'rbEncryptedH264SW
        '
        Me.rbEncryptedH264SW.AutoSize = true
        Me.rbEncryptedH264SW.Checked = true
        Me.rbEncryptedH264SW.Location = New System.Drawing.Point(14, 28)
        Me.rbEncryptedH264SW.Name = "rbEncryptedH264SW"
        Me.rbEncryptedH264SW.Size = New System.Drawing.Size(195, 17)
        Me.rbEncryptedH264SW.TabIndex = 6
        Me.rbEncryptedH264SW.TabStop = true
        Me.rbEncryptedH264SW.Text = "Use MP4 H264 / ACC output format"
        Me.rbEncryptedH264SW.UseVisualStyleBackColor = true
        '
        'TabPage106
        '
        Me.TabPage106.Controls.Add(Me.label365)
        Me.TabPage106.Controls.Add(Me.edFaceTrackingFaces)
        Me.TabPage106.Controls.Add(Me.label364)
        Me.TabPage106.Controls.Add(Me.label363)
        Me.TabPage106.Controls.Add(Me.cbFaceTrackingScalingMode)
        Me.TabPage106.Controls.Add(Me.label362)
        Me.TabPage106.Controls.Add(Me.edFaceTrackingScaleFactor)
        Me.TabPage106.Controls.Add(Me.label361)
        Me.TabPage106.Controls.Add(Me.cbFaceTrackingSearchMode)
        Me.TabPage106.Controls.Add(Me.cbFaceTrackingColorMode)
        Me.TabPage106.Controls.Add(Me.label346)
        Me.TabPage106.Controls.Add(Me.edFaceTrackingMinimumWindowSize)
        Me.TabPage106.Controls.Add(Me.label345)
        Me.TabPage106.Controls.Add(Me.cbFaceTrackingCHL)
        Me.TabPage106.Controls.Add(Me.cbFaceTrackingEnabled)
        Me.TabPage106.Location = New System.Drawing.Point(4, 22)
        Me.TabPage106.Name = "TabPage106"
        Me.TabPage106.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage106.Size = New System.Drawing.Size(307, 484)
        Me.TabPage106.TabIndex = 17
        Me.TabPage106.Text = "Face tracking"
        Me.TabPage106.UseVisualStyleBackColor = true
        '
        'label365
        '
        Me.label365.AutoSize = true
        Me.label365.Location = New System.Drawing.Point(164, 21)
        Me.label365.Name = "label365"
        Me.label365.Size = New System.Drawing.Size(117, 13)
        Me.label365.TabIndex = 28
        Me.label365.Text = "(available for .Net 4.0+)"
        '
        'edFaceTrackingFaces
        '
        Me.edFaceTrackingFaces.Location = New System.Drawing.Point(34, 296)
        Me.edFaceTrackingFaces.Multiline = true
        Me.edFaceTrackingFaces.Name = "edFaceTrackingFaces"
        Me.edFaceTrackingFaces.Size = New System.Drawing.Size(254, 169)
        Me.edFaceTrackingFaces.TabIndex = 27
        '
        'label364
        '
        Me.label364.AutoSize = true
        Me.label364.Location = New System.Drawing.Point(31, 277)
        Me.label364.Name = "label364"
        Me.label364.Size = New System.Drawing.Size(80, 13)
        Me.label364.TabIndex = 26
        Me.label364.Text = "Detected faces"
        '
        'label363
        '
        Me.label363.AutoSize = true
        Me.label363.Location = New System.Drawing.Point(31, 229)
        Me.label363.Name = "label363"
        Me.label363.Size = New System.Drawing.Size(71, 13)
        Me.label363.TabIndex = 25
        Me.label363.Text = "Scaling mode"
        '
        'cbFaceTrackingScalingMode
        '
        Me.cbFaceTrackingScalingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFaceTrackingScalingMode.FormattingEnabled = true
        Me.cbFaceTrackingScalingMode.Items.AddRange(New Object() {"Greater to smaller", "Smaller to greater"})
        Me.cbFaceTrackingScalingMode.Location = New System.Drawing.Point(167, 226)
        Me.cbFaceTrackingScalingMode.Name = "cbFaceTrackingScalingMode"
        Me.cbFaceTrackingScalingMode.Size = New System.Drawing.Size(121, 21)
        Me.cbFaceTrackingScalingMode.TabIndex = 24
        '
        'label362
        '
        Me.label362.AutoSize = true
        Me.label362.Location = New System.Drawing.Point(31, 192)
        Me.label362.Name = "label362"
        Me.label362.Size = New System.Drawing.Size(64, 13)
        Me.label362.TabIndex = 23
        Me.label362.Text = "Scale factor"
        '
        'edFaceTrackingScaleFactor
        '
        Me.edFaceTrackingScaleFactor.Location = New System.Drawing.Point(167, 189)
        Me.edFaceTrackingScaleFactor.Name = "edFaceTrackingScaleFactor"
        Me.edFaceTrackingScaleFactor.Size = New System.Drawing.Size(45, 20)
        Me.edFaceTrackingScaleFactor.TabIndex = 22
        Me.edFaceTrackingScaleFactor.Text = "1.2"
        '
        'label361
        '
        Me.label361.AutoSize = true
        Me.label361.Location = New System.Drawing.Point(31, 154)
        Me.label361.Name = "label361"
        Me.label361.Size = New System.Drawing.Size(70, 13)
        Me.label361.TabIndex = 21
        Me.label361.Text = "Search mode"
        '
        'cbFaceTrackingSearchMode
        '
        Me.cbFaceTrackingSearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFaceTrackingSearchMode.FormattingEnabled = true
        Me.cbFaceTrackingSearchMode.Items.AddRange(New Object() {"Default", "Single", "No overlap", "Average"})
        Me.cbFaceTrackingSearchMode.Location = New System.Drawing.Point(167, 151)
        Me.cbFaceTrackingSearchMode.Name = "cbFaceTrackingSearchMode"
        Me.cbFaceTrackingSearchMode.Size = New System.Drawing.Size(121, 21)
        Me.cbFaceTrackingSearchMode.TabIndex = 20
        '
        'cbFaceTrackingColorMode
        '
        Me.cbFaceTrackingColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFaceTrackingColorMode.FormattingEnabled = true
        Me.cbFaceTrackingColorMode.Items.AddRange(New Object() {"RGB", "HSL", "Mixed"})
        Me.cbFaceTrackingColorMode.Location = New System.Drawing.Point(167, 114)
        Me.cbFaceTrackingColorMode.Name = "cbFaceTrackingColorMode"
        Me.cbFaceTrackingColorMode.Size = New System.Drawing.Size(121, 21)
        Me.cbFaceTrackingColorMode.TabIndex = 19
        '
        'label346
        '
        Me.label346.AutoSize = true
        Me.label346.Location = New System.Drawing.Point(31, 117)
        Me.label346.Name = "label346"
        Me.label346.Size = New System.Drawing.Size(60, 13)
        Me.label346.TabIndex = 18
        Me.label346.Text = "Color mode"
        '
        'edFaceTrackingMinimumWindowSize
        '
        Me.edFaceTrackingMinimumWindowSize.Location = New System.Drawing.Point(167, 80)
        Me.edFaceTrackingMinimumWindowSize.Name = "edFaceTrackingMinimumWindowSize"
        Me.edFaceTrackingMinimumWindowSize.Size = New System.Drawing.Size(45, 20)
        Me.edFaceTrackingMinimumWindowSize.TabIndex = 17
        Me.edFaceTrackingMinimumWindowSize.Text = "25"
        '
        'label345
        '
        Me.label345.AutoSize = true
        Me.label345.Location = New System.Drawing.Point(31, 83)
        Me.label345.Name = "label345"
        Me.label345.Size = New System.Drawing.Size(108, 13)
        Me.label345.TabIndex = 16
        Me.label345.Text = "Minimum window size"
        '
        'cbFaceTrackingCHL
        '
        Me.cbFaceTrackingCHL.AutoSize = true
        Me.cbFaceTrackingCHL.Checked = true
        Me.cbFaceTrackingCHL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFaceTrackingCHL.Location = New System.Drawing.Point(34, 53)
        Me.cbFaceTrackingCHL.Name = "cbFaceTrackingCHL"
        Me.cbFaceTrackingCHL.Size = New System.Drawing.Size(92, 17)
        Me.cbFaceTrackingCHL.TabIndex = 15
        Me.cbFaceTrackingCHL.Text = "Color highlight"
        Me.cbFaceTrackingCHL.UseVisualStyleBackColor = true
        '
        'cbFaceTrackingEnabled
        '
        Me.cbFaceTrackingEnabled.AutoSize = true
        Me.cbFaceTrackingEnabled.Location = New System.Drawing.Point(19, 20)
        Me.cbFaceTrackingEnabled.Name = "cbFaceTrackingEnabled"
        Me.cbFaceTrackingEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbFaceTrackingEnabled.TabIndex = 14
        Me.cbFaceTrackingEnabled.Text = "Enabled"
        Me.cbFaceTrackingEnabled.UseVisualStyleBackColor = true
        '
        'TabPage141
        '
        Me.TabPage141.Controls.Add(Me.TabControl32)
        Me.TabPage141.Controls.Add(Me.cbTagEnabled)
        Me.TabPage141.Location = New System.Drawing.Point(4, 22)
        Me.TabPage141.Name = "TabPage141"
        Me.TabPage141.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage141.Size = New System.Drawing.Size(307, 484)
        Me.TabPage141.TabIndex = 19
        Me.TabPage141.Text = "Tags"
        Me.TabPage141.UseVisualStyleBackColor = true
        '
        'TabControl32
        '
        Me.TabControl32.Controls.Add(Me.TabPage142)
        Me.TabControl32.Controls.Add(Me.TabPage143)
        Me.TabControl32.Location = New System.Drawing.Point(9, 46)
        Me.TabControl32.Name = "TabControl32"
        Me.TabControl32.SelectedIndex = 0
        Me.TabControl32.Size = New System.Drawing.Size(292, 432)
        Me.TabControl32.TabIndex = 1
        '
        'TabPage142
        '
        Me.TabPage142.Controls.Add(Me.edTagTrackID)
        Me.TabPage142.Controls.Add(Me.Label496)
        Me.TabPage142.Controls.Add(Me.edTagYear)
        Me.TabPage142.Controls.Add(Me.Label495)
        Me.TabPage142.Controls.Add(Me.edTagComment)
        Me.TabPage142.Controls.Add(Me.Label493)
        Me.TabPage142.Controls.Add(Me.edTagAlbum)
        Me.TabPage142.Controls.Add(Me.Label491)
        Me.TabPage142.Controls.Add(Me.edTagArtists)
        Me.TabPage142.Controls.Add(Me.Label490)
        Me.TabPage142.Controls.Add(Me.edTagCopyright)
        Me.TabPage142.Controls.Add(Me.Label489)
        Me.TabPage142.Controls.Add(Me.edTagTitle)
        Me.TabPage142.Controls.Add(Me.Label488)
        Me.TabPage142.Location = New System.Drawing.Point(4, 22)
        Me.TabPage142.Name = "TabPage142"
        Me.TabPage142.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage142.Size = New System.Drawing.Size(284, 406)
        Me.TabPage142.TabIndex = 0
        Me.TabPage142.Text = "Common"
        Me.TabPage142.UseVisualStyleBackColor = true
        '
        'edTagTrackID
        '
        Me.edTagTrackID.Location = New System.Drawing.Point(16, 207)
        Me.edTagTrackID.Name = "edTagTrackID"
        Me.edTagTrackID.Size = New System.Drawing.Size(63, 20)
        Me.edTagTrackID.TabIndex = 13
        Me.edTagTrackID.Text = "1"
        '
        'Label496
        '
        Me.Label496.AutoSize = true
        Me.Label496.Location = New System.Drawing.Point(13, 192)
        Me.Label496.Name = "Label496"
        Me.Label496.Size = New System.Drawing.Size(49, 13)
        Me.Label496.TabIndex = 12
        Me.Label496.Text = "Track ID"
        '
        'edTagYear
        '
        Me.edTagYear.Location = New System.Drawing.Point(16, 301)
        Me.edTagYear.Name = "edTagYear"
        Me.edTagYear.Size = New System.Drawing.Size(63, 20)
        Me.edTagYear.TabIndex = 11
        Me.edTagYear.Text = "2015"
        '
        'Label495
        '
        Me.Label495.AutoSize = true
        Me.Label495.Location = New System.Drawing.Point(13, 286)
        Me.Label495.Name = "Label495"
        Me.Label495.Size = New System.Drawing.Size(29, 13)
        Me.Label495.TabIndex = 10
        Me.Label495.Text = "Year"
        '
        'edTagComment
        '
        Me.edTagComment.Location = New System.Drawing.Point(16, 160)
        Me.edTagComment.Name = "edTagComment"
        Me.edTagComment.Size = New System.Drawing.Size(242, 20)
        Me.edTagComment.TabIndex = 9
        Me.edTagComment.Text = "No comments"
        '
        'Label493
        '
        Me.Label493.AutoSize = true
        Me.Label493.Location = New System.Drawing.Point(13, 145)
        Me.Label493.Name = "Label493"
        Me.Label493.Size = New System.Drawing.Size(51, 13)
        Me.Label493.TabIndex = 8
        Me.Label493.Text = "Comment"
        '
        'edTagAlbum
        '
        Me.edTagAlbum.Location = New System.Drawing.Point(16, 116)
        Me.edTagAlbum.Name = "edTagAlbum"
        Me.edTagAlbum.Size = New System.Drawing.Size(242, 20)
        Me.edTagAlbum.TabIndex = 7
        Me.edTagAlbum.Text = "Sample album"
        '
        'Label491
        '
        Me.Label491.AutoSize = true
        Me.Label491.Location = New System.Drawing.Point(13, 101)
        Me.Label491.Name = "Label491"
        Me.Label491.Size = New System.Drawing.Size(36, 13)
        Me.Label491.TabIndex = 6
        Me.Label491.Text = "Album"
        '
        'edTagArtists
        '
        Me.edTagArtists.Location = New System.Drawing.Point(16, 72)
        Me.edTagArtists.Name = "edTagArtists"
        Me.edTagArtists.Size = New System.Drawing.Size(242, 20)
        Me.edTagArtists.TabIndex = 5
        Me.edTagArtists.Text = "Sample artist"
        '
        'Label490
        '
        Me.Label490.AutoSize = true
        Me.Label490.Location = New System.Drawing.Point(13, 57)
        Me.Label490.Name = "Label490"
        Me.Label490.Size = New System.Drawing.Size(35, 13)
        Me.Label490.TabIndex = 4
        Me.Label490.Text = "Artists"
        '
        'edTagCopyright
        '
        Me.edTagCopyright.Location = New System.Drawing.Point(16, 255)
        Me.edTagCopyright.Name = "edTagCopyright"
        Me.edTagCopyright.Size = New System.Drawing.Size(242, 20)
        Me.edTagCopyright.TabIndex = 3
        Me.edTagCopyright.Text = "VisioForge"
        '
        'Label489
        '
        Me.Label489.AutoSize = true
        Me.Label489.Location = New System.Drawing.Point(13, 240)
        Me.Label489.Name = "Label489"
        Me.Label489.Size = New System.Drawing.Size(51, 13)
        Me.Label489.TabIndex = 2
        Me.Label489.Text = "Copyright"
        '
        'edTagTitle
        '
        Me.edTagTitle.Location = New System.Drawing.Point(16, 29)
        Me.edTagTitle.Name = "edTagTitle"
        Me.edTagTitle.Size = New System.Drawing.Size(242, 20)
        Me.edTagTitle.TabIndex = 1
        Me.edTagTitle.Text = "Sample output file"
        '
        'Label488
        '
        Me.Label488.AutoSize = true
        Me.Label488.Location = New System.Drawing.Point(13, 14)
        Me.Label488.Name = "Label488"
        Me.Label488.Size = New System.Drawing.Size(27, 13)
        Me.Label488.TabIndex = 0
        Me.Label488.Text = "Title"
        '
        'TabPage143
        '
        Me.TabPage143.Controls.Add(Me.imgTagCover)
        Me.TabPage143.Controls.Add(Me.Label499)
        Me.TabPage143.Controls.Add(Me.Label498)
        Me.TabPage143.Controls.Add(Me.edTagLyrics)
        Me.TabPage143.Controls.Add(Me.Label497)
        Me.TabPage143.Controls.Add(Me.cbTagGenre)
        Me.TabPage143.Controls.Add(Me.Label494)
        Me.TabPage143.Controls.Add(Me.edTagComposers)
        Me.TabPage143.Controls.Add(Me.Label492)
        Me.TabPage143.Location = New System.Drawing.Point(4, 22)
        Me.TabPage143.Name = "TabPage143"
        Me.TabPage143.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage143.Size = New System.Drawing.Size(284, 406)
        Me.TabPage143.TabIndex = 1
        Me.TabPage143.Text = "Special"
        Me.TabPage143.UseVisualStyleBackColor = true
        '
        'imgTagCover
        '
        Me.imgTagCover.BackColor = System.Drawing.Color.DimGray
        Me.imgTagCover.Location = New System.Drawing.Point(15, 178)
        Me.imgTagCover.Name = "imgTagCover"
        Me.imgTagCover.Size = New System.Drawing.Size(104, 104)
        Me.imgTagCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTagCover.TabIndex = 16
        Me.imgTagCover.TabStop = false
        '
        'Label499
        '
        Me.Label499.AutoSize = true
        Me.Label499.Location = New System.Drawing.Point(12, 162)
        Me.Label499.Name = "Label499"
        Me.Label499.Size = New System.Drawing.Size(35, 13)
        Me.Label499.TabIndex = 15
        Me.Label499.Text = "Cover"
        '
        'Label498
        '
        Me.Label498.AutoSize = true
        Me.Label498.Location = New System.Drawing.Point(43, 334)
        Me.Label498.Name = "Label498"
        Me.Label498.Size = New System.Drawing.Size(194, 13)
        Me.Label498.TabIndex = 14
        Me.Label498.Text = "Many other tags are available using API"
        '
        'edTagLyrics
        '
        Me.edTagLyrics.Location = New System.Drawing.Point(15, 127)
        Me.edTagLyrics.Name = "edTagLyrics"
        Me.edTagLyrics.Size = New System.Drawing.Size(242, 20)
        Me.edTagLyrics.TabIndex = 13
        Me.edTagLyrics.Text = "Yo-ho-ho and the buttle of rum"
        '
        'Label497
        '
        Me.Label497.AutoSize = true
        Me.Label497.Location = New System.Drawing.Point(12, 112)
        Me.Label497.Name = "Label497"
        Me.Label497.Size = New System.Drawing.Size(34, 13)
        Me.Label497.TabIndex = 12
        Me.Label497.Text = "Lyrics"
        '
        'cbTagGenre
        '
        Me.cbTagGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTagGenre.FormattingEnabled = true
        Me.cbTagGenre.Location = New System.Drawing.Point(15, 76)
        Me.cbTagGenre.Name = "cbTagGenre"
        Me.cbTagGenre.Size = New System.Drawing.Size(242, 21)
        Me.cbTagGenre.TabIndex = 11
        '
        'Label494
        '
        Me.Label494.AutoSize = true
        Me.Label494.Location = New System.Drawing.Point(12, 60)
        Me.Label494.Name = "Label494"
        Me.Label494.Size = New System.Drawing.Size(36, 13)
        Me.Label494.TabIndex = 10
        Me.Label494.Text = "Genre"
        '
        'edTagComposers
        '
        Me.edTagComposers.Location = New System.Drawing.Point(15, 29)
        Me.edTagComposers.Name = "edTagComposers"
        Me.edTagComposers.Size = New System.Drawing.Size(242, 20)
        Me.edTagComposers.TabIndex = 9
        Me.edTagComposers.Text = "Sample composer"
        '
        'Label492
        '
        Me.Label492.AutoSize = true
        Me.Label492.Location = New System.Drawing.Point(12, 14)
        Me.Label492.Name = "Label492"
        Me.Label492.Size = New System.Drawing.Size(59, 13)
        Me.Label492.TabIndex = 8
        Me.Label492.Text = "Composers"
        '
        'cbTagEnabled
        '
        Me.cbTagEnabled.AutoSize = true
        Me.cbTagEnabled.Location = New System.Drawing.Point(18, 16)
        Me.cbTagEnabled.Name = "cbTagEnabled"
        Me.cbTagEnabled.Size = New System.Drawing.Size(135, 17)
        Me.cbTagEnabled.TabIndex = 0
        Me.cbTagEnabled.Text = "Write tags to output file"
        Me.cbTagEnabled.UseVisualStyleBackColor = true
        '
        'openFileDialog3
        '
        Me.openFileDialog3.FileName = "openFileDialog3"
        Me.openFileDialog3.Filter = "VirtualDub filters|*.vdf"
        '
        'VideoCapture1
        '
        Me.VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = false
        Me.VideoCapture1.Audio_CaptureDevice = ""
        Me.VideoCapture1.Audio_CaptureDevice_CustomLatency = 0
        Me.VideoCapture1.Audio_CaptureDevice_Format = ""
        Me.VideoCapture1.Audio_CaptureDevice_Format_UseBest = true
        Me.VideoCapture1.Audio_CaptureDevice_Line = ""
        Me.VideoCapture1.Audio_CaptureDevice_MasterDevice = Nothing
        Me.VideoCapture1.Audio_CaptureDevice_MasterDevice_Format = Nothing
        Me.VideoCapture1.Audio_CaptureDevice_Path = Nothing
        Me.VideoCapture1.Audio_CaptureSourceFilter = Nothing
        Me.VideoCapture1.Audio_Channel_Mapper = Nothing
        Me.VideoCapture1.Audio_Decoder = Nothing
        Me.VideoCapture1.Audio_Effects_Enabled = false
        Me.VideoCapture1.Audio_Effects_UseLegacyEffects = false
        Me.VideoCapture1.Audio_Enhancer_Enabled = false
        Me.VideoCapture1.Audio_OutputDevice = "Default DirectSound Device"
        Me.VideoCapture1.Audio_PCM_Converter = Nothing
        Me.VideoCapture1.Audio_PlayAudio = true
        Me.VideoCapture1.Audio_RecordAudio = true
        Me.VideoCapture1.Audio_Sample_Grabber_Enabled = false
        Me.VideoCapture1.Audio_VUMeter_Enabled = false
        Me.VideoCapture1.Audio_VUMeter_Pro_Enabled = false
        Me.VideoCapture1.Audio_VUMeter_Pro_Volume = 100
        Me.VideoCapture1.BackColor = System.Drawing.Color.Black
        Me.VideoCapture1.Barcode_Reader_Enabled = false
        Me.VideoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.[Auto]
        Me.VideoCapture1.BDA_Source = Nothing
        Me.VideoCapture1.ChromaKey = Nothing
        Me.VideoCapture1.Custom_Source = Nothing
        Me.VideoCapture1.CustomRedist_Auto = true
        Me.VideoCapture1.CustomRedist_Enabled = false
        Me.VideoCapture1.CustomRedist_Path = Nothing
        Me.VideoCapture1.Debug_Dir = ""
        Me.VideoCapture1.Debug_DisableMessageDialogs = false
        Me.VideoCapture1.Debug_Mode = false
        Me.VideoCapture1.Debug_Telemetry = false
        Me.VideoCapture1.Decklink_Input = VisioForge.Types.DecklinkInput.[Auto]
        Me.VideoCapture1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.[Auto]
        Me.VideoCapture1.Decklink_Input_IREUSA = false
        Me.VideoCapture1.Decklink_Input_SMPTE = false
        Me.VideoCapture1.Decklink_Output = Nothing
        Me.VideoCapture1.Decklink_Source = Nothing
        Me.VideoCapture1.DirectCapture_Muxer = Nothing
        Me.VideoCapture1.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full
        Me.VideoCapture1.Face_Tracking = Nothing
        Me.VideoCapture1.IP_Camera_Source = Nothing
        Me.VideoCapture1.Location = New System.Drawing.Point(334, 324)
        Me.VideoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture
        Me.VideoCapture1.Motion_Detection = Nothing
        Me.VideoCapture1.Motion_DetectionEx = Nothing
        Me.VideoCapture1.MPEG_Audio_Decoder = ""
        Me.VideoCapture1.MPEG_Demuxer = Nothing
        Me.VideoCapture1.MPEG_Video_Decoder = ""
        Me.VideoCapture1.MultiScreen_Enabled = false
        Me.VideoCapture1.Name = "VideoCapture1"
        Me.VideoCapture1.Network_Streaming_Audio_Enabled = false
        Me.VideoCapture1.Network_Streaming_Enabled = false
        Me.VideoCapture1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV
        Me.VideoCapture1.Network_Streaming_Network_Port = 100
        Me.VideoCapture1.Network_Streaming_Output = Nothing
        Me.VideoCapture1.Network_Streaming_URL = ""
        Me.VideoCapture1.Network_Streaming_WMV_Maximum_Clients = 10
        Me.VideoCapture1.OSD_Enabled = false
        Me.VideoCapture1.Output_Filename = ""
        Me.VideoCapture1.Output_Format = Nothing
        Me.VideoCapture1.PIP_AddSampleGrabbers = false
        Me.VideoCapture1.PIP_ChromaKeySettings = Nothing
        Me.VideoCapture1.PIP_Mode = VisioForge.Types.VFPIPMode.Custom
        Me.VideoCapture1.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN
        Me.VideoCapture1.Push_Source = Nothing
        Me.VideoCapture1.Screen_Capture_Source = Nothing
        Me.VideoCapture1.SeparateCapture_AutostartCapture = false
        Me.VideoCapture1.SeparateCapture_Enabled = false
        Me.VideoCapture1.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext"
        Me.VideoCapture1.SeparateCapture_FileSizeThreshold = CType(0,Long)
        Me.VideoCapture1.SeparateCapture_GMFMode = true
        Me.VideoCapture1.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal
        Me.VideoCapture1.SeparateCapture_TimeThreshold = System.TimeSpan.Parse("00:00:00")
        Me.VideoCapture1.Size = New System.Drawing.Size(465, 323)
        Me.VideoCapture1.Start_DelayEnabled = false
        Me.VideoCapture1.TabIndex = 94
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
        Me.VideoCapture1.Video_CaptureDevice_Format_UseBest = true
        Me.VideoCapture1.Video_CaptureDevice_FrameRate = 0R
        Me.VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = ""
        Me.VideoCapture1.Video_CaptureDevice_IsAudioSource = false
        Me.VideoCapture1.Video_CaptureDevice_Path = Nothing
        Me.VideoCapture1.Video_CaptureDevice_UseClosedCaptions = false
        Me.VideoCapture1.Video_CaptureDevice_UseRAWSampleGrabber = false
        Me.VideoCapture1.Video_Crop = Nothing
        Me.VideoCapture1.Video_Decoder = Nothing
        Me.VideoCapture1.Video_Effects_AllowMultipleStreams = false
        Me.VideoCapture1.Video_Effects_Enabled = false
        Me.VideoCapture1.Video_Effects_GPU_Enabled = false
        Me.VideoCapture1.Video_Effects_MergeImageLogos = false
        Me.VideoCapture1.Video_Effects_MergeTextLogos = false
        Me.VideoCapture1.Video_Resize = Nothing
        Me.VideoCapture1.Video_ResizeOrCrop_Enabled = false
        Me.VideoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone
        Me.VideoCapture1.Video_Sample_Grabber_Enabled = false
        Me.VideoCapture1.Video_Sample_Grabber_UseForVideoEffects = false
        Me.VideoCapture1.Video_Still_Frames_Grabber_Enabled = false
        Me.VideoCapture1.Virtual_Camera_Output_Enabled = false
        Me.VideoCapture1.Virtual_Camera_Output_LicenseKey = Nothing
        Me.VideoCapture1.VLC_Path = Nothing
        '
        'btSaveScreenshot
        '
        Me.btSaveScreenshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btSaveScreenshot.Location = New System.Drawing.Point(533, 653)
        Me.btSaveScreenshot.Name = "btSaveScreenshot"
        Me.btSaveScreenshot.Size = New System.Drawing.Size(116, 23)
        Me.btSaveScreenshot.TabIndex = 95
        Me.btSaveScreenshot.Text = "Save snapshot"
        Me.btSaveScreenshot.UseVisualStyleBackColor = true
        '
        'lbTimestamp
        '
        Me.lbTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lbTimestamp.AutoSize = true
        Me.lbTimestamp.Location = New System.Drawing.Point(335, 658)
        Me.lbTimestamp.Name = "lbTimestamp"
        Me.lbTimestamp.Size = New System.Drawing.Size(126, 13)
        Me.lbTimestamp.TabIndex = 96
        Me.lbTimestamp.Text = "Recording time: 00:00:00"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 713)
        Me.Controls.Add(Me.VideoCapture1)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.tabControl12)
        Me.Controls.Add(Me.tabControl10)
        Me.Controls.Add(Me.btResume)
        Me.Controls.Add(Me.btPause)
        Me.Controls.Add(Me.cbMode)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.lbTimestamp)
        Me.Controls.Add(Me.btSaveScreenshot)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Tag = "0"
        Me.Text = "VisioForge Video Capture SDK .Net - Main Demo"
        Me.tabControl12.ResumeLayout(false)
        Me.tabPage53.ResumeLayout(false)
        Me.tabPage53.PerformLayout
        Me.tabControl10.ResumeLayout(false)
        Me.tabPage46.ResumeLayout(false)
        Me.tabControl2.ResumeLayout(false)
        Me.tabPage8.ResumeLayout(false)
        Me.tabPage8.PerformLayout
        Me.tabPage52.ResumeLayout(false)
        Me.tabPage52.PerformLayout
        Me.tabPage10.ResumeLayout(false)
        Me.tabControl3.ResumeLayout(false)
        Me.tabPage14.ResumeLayout(false)
        Me.tabPage14.PerformLayout
        Me.tabPage15.ResumeLayout(false)
        Me.tabPage15.PerformLayout
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.tabPage21.ResumeLayout(false)
        Me.tabPage21.PerformLayout
        Me.tabPage33.ResumeLayout(false)
        Me.tabPage33.PerformLayout
        Me.tabPage11.ResumeLayout(false)
        Me.groupBox21.ResumeLayout(false)
        Me.groupBox21.PerformLayout
        Me.groupBox2.ResumeLayout(false)
        Me.tabPage57.ResumeLayout(false)
        Me.tabPage57.PerformLayout
        CType(Me.tbAdjSaturation,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAdjHue,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAdjContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAdjBrightness,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        CType(Me.tbCCFocus,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbCCZoom,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbCCTilt,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbCCPan,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage9.ResumeLayout(false)
        Me.tabControl19.ResumeLayout(false)
        Me.tabPage96.ResumeLayout(false)
        Me.tabPage96.PerformLayout
        Me.tabPage97.ResumeLayout(false)
        Me.tabPage97.PerformLayout
        CType(Me.tbAudioBalance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage98.ResumeLayout(false)
        Me.tabPage98.PerformLayout
        Me.TabPage111.ResumeLayout(false)
        Me.TabPage111.PerformLayout
        CType(Me.tbVUMeterBoost,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbVUMeterAmplification,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage99.ResumeLayout(false)
        Me.tabPage99.PerformLayout
        Me.tabPage47.ResumeLayout(false)
        Me.tabPage47.PerformLayout
        Me.tabPage48.ResumeLayout(false)
        Me.tabControl15.ResumeLayout(false)
        Me.tabPage144.ResumeLayout(false)
        Me.tabPage144.PerformLayout
        Me.tabPage146.ResumeLayout(false)
        Me.tabPage146.PerformLayout
        Me.tabPage145.ResumeLayout(false)
        Me.tabPage145.PerformLayout
        Me.groupBox42.ResumeLayout(false)
        Me.TabPage61.ResumeLayout(false)
        Me.TabPage61.PerformLayout
        Me.TabPage66.ResumeLayout(false)
        Me.tabControl22.ResumeLayout(false)
        Me.tabPage82.ResumeLayout(false)
        Me.tabPage82.PerformLayout
        Me.tabPage83.ResumeLayout(false)
        Me.tabControl23.ResumeLayout(false)
        Me.tabPage84.ResumeLayout(false)
        Me.tabPage84.PerformLayout
        Me.tabPage85.ResumeLayout(false)
        Me.tabPage85.PerformLayout
        Me.tabPage86.ResumeLayout(false)
        Me.groupBox35.ResumeLayout(false)
        Me.groupBox35.PerformLayout
        Me.groupBox36.ResumeLayout(false)
        Me.groupBox36.PerformLayout
        Me.tabPage87.ResumeLayout(false)
        Me.tabPage87.PerformLayout
        Me.TabPage104.ResumeLayout(false)
        Me.TabPage104.PerformLayout
        Me.tabPage49.ResumeLayout(false)
        Me.tabControl20.ResumeLayout(false)
        Me.tabPage67.ResumeLayout(false)
        Me.tabControl21.ResumeLayout(false)
        Me.tabPage78.ResumeLayout(false)
        Me.tabPage78.PerformLayout
        Me.groupBox30.ResumeLayout(false)
        Me.groupBox30.PerformLayout
        Me.tabPage79.ResumeLayout(false)
        Me.groupBox31.ResumeLayout(false)
        Me.groupBox31.PerformLayout
        Me.tabPage80.ResumeLayout(false)
        Me.groupBox32.ResumeLayout(false)
        Me.groupBox32.PerformLayout
        Me.TabPage93.ResumeLayout(false)
        Me.TabPage93.PerformLayout
        Me.groupBox44.ResumeLayout(false)
        Me.groupBox44.PerformLayout
        Me.tabPage77.ResumeLayout(false)
        Me.tabPage77.PerformLayout
        Me.groupBox34.ResumeLayout(false)
        Me.groupBox34.PerformLayout
        CType(Me.tbPIPTransparency,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox33.ResumeLayout(false)
        Me.groupBox33.PerformLayout
        Me.groupBox20.ResumeLayout(false)
        Me.groupBox20.PerformLayout
        Me.TabPage113.ResumeLayout(false)
        Me.TabPage113.PerformLayout
        CType(Me.tbPIPChromaKeyTolerance2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbPIPChromaKeyTolerance1,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage50.ResumeLayout(false)
        Me.tabPage50.PerformLayout
        Me.tabPage51.ResumeLayout(false)
        Me.tabControl26.ResumeLayout(false)
        Me.tabPage115.ResumeLayout(false)
        Me.tabPage115.PerformLayout
        Me.groupBox28.ResumeLayout(false)
        Me.groupBox13.ResumeLayout(false)
        Me.groupBox13.PerformLayout
        Me.tabPage116.ResumeLayout(false)
        Me.tabPage116.PerformLayout
        Me.TabPage23.ResumeLayout(false)
        Me.TabPage23.PerformLayout
        Me.groupBox8.ResumeLayout(false)
        Me.groupBox8.PerformLayout
        Me.TabPage123.ResumeLayout(false)
        Me.tabControl28.ResumeLayout(false)
        Me.tabPage125.ResumeLayout(false)
        Me.tabPage125.PerformLayout
        Me.tabPage126.ResumeLayout(false)
        Me.tabPage126.PerformLayout
        Me.tabControl1.ResumeLayout(false)
        Me.tabPage1.ResumeLayout(false)
        Me.tabPage1.PerformLayout
        Me.tabPage2.ResumeLayout(false)
        Me.tabControl17.ResumeLayout(false)
        Me.tabPage68.ResumeLayout(false)
        Me.tabPage68.PerformLayout
        Me.tabControl7.ResumeLayout(false)
        Me.tabPage29.ResumeLayout(false)
        Me.tabPage29.PerformLayout
        Me.tabPage42.ResumeLayout(false)
        Me.tabPage42.PerformLayout
        Me.TabPage88.ResumeLayout(false)
        Me.TabPage88.PerformLayout
        Me.groupBox37.ResumeLayout(false)
        Me.TabPage91.ResumeLayout(false)
        Me.TabPage91.PerformLayout
        Me.groupBox40.ResumeLayout(false)
        Me.groupBox40.PerformLayout
        Me.groupBox39.ResumeLayout(false)
        Me.groupBox39.PerformLayout
        Me.groupBox38.ResumeLayout(false)
        Me.groupBox38.PerformLayout
        Me.TabPage101.ResumeLayout(false)
        Me.TabPage101.PerformLayout
        Me.groupBox45.ResumeLayout(false)
        Me.groupBox45.PerformLayout
        Me.TabPage112.ResumeLayout(false)
        Me.TabPage112.PerformLayout
        CType(Me.tbLiveRotationAngle,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage69.ResumeLayout(false)
        Me.tabPage69.PerformLayout
        Me.TabPage59.ResumeLayout(false)
        Me.TabPage59.PerformLayout
        Me.TabPage63.ResumeLayout(false)
        Me.TabPage63.PerformLayout
        CType(Me.tbGPUBlur,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbGPUContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbGPUDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbGPULightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbGPUSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage92.ResumeLayout(false)
        Me.TabPage92.PerformLayout
        Me.TabPage60.ResumeLayout(false)
        Me.TabPage60.PerformLayout
        CType(Me.tbChromaKeySmoothing,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbChromaKeyThresholdSensitivity,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage70.ResumeLayout(false)
        Me.tabPage70.PerformLayout
        Me.tabControl14.ResumeLayout(false)
        Me.tabPage27.ResumeLayout(false)
        Me.tabPage27.PerformLayout
        Me.tabControl18.ResumeLayout(false)
        Me.tabPage71.ResumeLayout(false)
        Me.tabPage71.PerformLayout
        CType(Me.tbAudAmplifyAmp,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage72.ResumeLayout(false)
        Me.tabPage72.PerformLayout
        CType(Me.tbAudEq9,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq0,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage73.ResumeLayout(false)
        Me.tabPage73.PerformLayout
        CType(Me.tbAudRelease,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudAttack,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudDynAmp,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage75.ResumeLayout(false)
        Me.tabPage75.PerformLayout
        CType(Me.tbAud3DSound,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage76.ResumeLayout(false)
        Me.tabPage76.PerformLayout
        CType(Me.tbAudTrueBass,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage124.ResumeLayout(false)
        Me.TabPage124.PerformLayout
        CType(Me.tbAudioTimeshift,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        CType(Me.tbAudioOutputGainLFE,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioOutputGainSR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioOutputGainSL,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioOutputGainR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioOutputGainC,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioOutputGainL,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox7.ResumeLayout(false)
        Me.GroupBox7.PerformLayout
        CType(Me.tbAudioInputGainLFE,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioInputGainSR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioInputGainSL,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioInputGainR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioInputGainC,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioInputGainL,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage22.ResumeLayout(false)
        Me.TabPage22.PerformLayout
        Me.groupBox41.ResumeLayout(false)
        Me.groupBox41.PerformLayout
        CType(Me.tbAudioChannelMapperVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage7.ResumeLayout(false)
        Me.tabPage7.PerformLayout
        Me.tabControl5.ResumeLayout(false)
        Me.tpWMV.ResumeLayout(false)
        Me.tpWMV.PerformLayout
        Me.tpRTSP.ResumeLayout(false)
        Me.tpRTSP.PerformLayout
        Me.tpRTMP.ResumeLayout(false)
        Me.tpRTMP.PerformLayout
        Me.tpNDI.ResumeLayout(false)
        Me.tpNDI.PerformLayout
        Me.tpUDP.ResumeLayout(false)
        Me.tpUDP.PerformLayout
        Me.tpSSF.ResumeLayout(false)
        Me.tpSSF.PerformLayout
        Me.tpHLS.ResumeLayout(false)
        Me.tpHLS.PerformLayout
        Me.tpExternal.ResumeLayout(false)
        Me.tpExternal.PerformLayout
        Me.tabPage28.ResumeLayout(false)
        Me.tabPage28.PerformLayout
        Me.groupBox19.ResumeLayout(false)
        Me.tabControl6.ResumeLayout(false)
        Me.tabPage30.ResumeLayout(false)
        Me.tabPage30.PerformLayout
        Me.tabPage31.ResumeLayout(false)
        Me.tabPage31.PerformLayout
        Me.tabPage32.ResumeLayout(false)
        Me.tabPage32.PerformLayout
        CType(Me.tbOSDTranspLevel,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox15.ResumeLayout(false)
        Me.groupBox15.PerformLayout
        Me.tabPage43.ResumeLayout(false)
        Me.tabPage43.PerformLayout
        Me.tabControl9.ResumeLayout(false)
        Me.tabPage44.ResumeLayout(false)
        Me.tabPage44.PerformLayout
        Me.tabPage45.ResumeLayout(false)
        Me.groupBox25.ResumeLayout(false)
        Me.groupBox25.PerformLayout
        CType(Me.tbMotDetHLThreshold,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox27.ResumeLayout(false)
        Me.groupBox27.PerformLayout
        Me.groupBox26.ResumeLayout(false)
        Me.groupBox26.PerformLayout
        CType(Me.tbMotDetDropFramesThreshold,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox24.ResumeLayout(false)
        Me.groupBox24.PerformLayout
        Me.TabPage26.ResumeLayout(false)
        Me.TabPage26.PerformLayout
        Me.TabPage25.ResumeLayout(false)
        Me.TabPage25.PerformLayout
        Me.TabPage100.ResumeLayout(false)
        Me.TabPage100.PerformLayout
        Me.TabPage102.ResumeLayout(false)
        Me.TabPage102.PerformLayout
        Me.TabPage105.ResumeLayout(false)
        Me.groupBox48.ResumeLayout(false)
        Me.groupBox48.PerformLayout
        Me.groupBox47.ResumeLayout(false)
        Me.groupBox47.PerformLayout
        Me.groupBox43.ResumeLayout(false)
        Me.groupBox43.PerformLayout
        Me.TabPage106.ResumeLayout(false)
        Me.TabPage106.PerformLayout
        Me.TabPage141.ResumeLayout(false)
        Me.TabPage141.PerformLayout
        Me.TabControl32.ResumeLayout(false)
        Me.TabPage142.ResumeLayout(false)
        Me.TabPage142.PerformLayout
        Me.TabPage143.ResumeLayout(false)
        Me.TabPage143.PerformLayout
        CType(Me.imgTagCover,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents openFileDialog2 As System.Windows.Forms.OpenFileDialog
    Private WithEvents folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents colorDialog1 As System.Windows.Forms.ColorDialog
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents tabControl12 As System.Windows.Forms.TabControl
    Private WithEvents tabPage53 As System.Windows.Forms.TabPage
    Private WithEvents cbDebugMode As System.Windows.Forms.CheckBox
    Private WithEvents mmLog As System.Windows.Forms.TextBox
    Private WithEvents tabControl10 As System.Windows.Forms.TabControl
    Private WithEvents tabPage46 As System.Windows.Forms.TabPage
    Private WithEvents tabControl2 As System.Windows.Forms.TabControl
    Private WithEvents tabPage8 As System.Windows.Forms.TabPage
    Private WithEvents btSignal As System.Windows.Forms.Button
    Private WithEvents label28 As System.Windows.Forms.Label
    Private WithEvents cbUseBestVideoInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents btVideoCaptureDeviceSettings As System.Windows.Forms.Button
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbFramerate As System.Windows.Forms.ComboBox
    Private WithEvents cbVideoInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents cbVideoInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents tabPage52 As System.Windows.Forms.TabPage
    Private WithEvents cbCrossBarAvailable As System.Windows.Forms.CheckBox
    Private WithEvents lbRotes As System.Windows.Forms.ListBox
    Private WithEvents label61 As System.Windows.Forms.Label
    Private WithEvents label60 As System.Windows.Forms.Label
    Private WithEvents cbConnectRelated As System.Windows.Forms.CheckBox
    Private WithEvents btConnect As System.Windows.Forms.Button
    Private WithEvents cbCrossbarVideoInput As System.Windows.Forms.ComboBox
    Private WithEvents label59 As System.Windows.Forms.Label
    Private WithEvents rbCrossbarAdvanced As System.Windows.Forms.RadioButton
    Private WithEvents rbCrossbarSimple As System.Windows.Forms.RadioButton
    Private WithEvents cbCrossbarOutput As System.Windows.Forms.ComboBox
    Private WithEvents cbCrossbarInput As System.Windows.Forms.ComboBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents tabPage10 As System.Windows.Forms.TabPage
    Private WithEvents tabControl3 As System.Windows.Forms.TabControl
    Private WithEvents tabPage14 As System.Windows.Forms.TabPage
    Private WithEvents edTVDefaultFormat As System.Windows.Forms.TextBox
    Private WithEvents label57 As System.Windows.Forms.Label
    Private WithEvents cbTVCountry As System.Windows.Forms.ComboBox
    Private WithEvents label56 As System.Windows.Forms.Label
    Private WithEvents cbTVMode As System.Windows.Forms.ComboBox
    Private WithEvents cbTVInput As System.Windows.Forms.ComboBox
    Private WithEvents cbTVTuner As System.Windows.Forms.ComboBox
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents label27 As System.Windows.Forms.Label
    Private WithEvents tabPage15 As System.Windows.Forms.TabPage
    Private WithEvents edChannel As System.Windows.Forms.TextBox
    Private WithEvents btUseThisChannel As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cbTVChannel As System.Windows.Forms.ComboBox
    Private WithEvents label58 As System.Windows.Forms.Label
    Private WithEvents pbChannels As System.Windows.Forms.ProgressBar
    Private WithEvents btStopTune As System.Windows.Forms.Button
    Private WithEvents btStartTune As System.Windows.Forms.Button
    Private WithEvents cbTVSystem As System.Windows.Forms.ComboBox
    Private WithEvents edAudioFreq As System.Windows.Forms.TextBox
    Private WithEvents label36 As System.Windows.Forms.Label
    Private WithEvents edVideoFreq As System.Windows.Forms.TextBox
    Private WithEvents label37 As System.Windows.Forms.Label
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents tabPage21 As System.Windows.Forms.TabPage
    Private WithEvents btMPEGEncoderShowDialog As System.Windows.Forms.Button
    Private WithEvents cbMPEGEncoder As System.Windows.Forms.ComboBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents tabPage33 As System.Windows.Forms.TabPage
    Private WithEvents btMPEGAudDecSettings As System.Windows.Forms.Button
    Private WithEvents cbMPEGAudioDecoder As System.Windows.Forms.ComboBox
    Private WithEvents label121 As System.Windows.Forms.Label
    Private WithEvents btMPEGVidDecSetting As System.Windows.Forms.Button
    Private WithEvents cbMPEGVideoDecoder As System.Windows.Forms.ComboBox
    Private WithEvents label120 As System.Windows.Forms.Label
    Private WithEvents tabPage11 As System.Windows.Forms.TabPage
    Private WithEvents groupBox21 As System.Windows.Forms.GroupBox
    Private WithEvents rbDVResDC As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResQuarter As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResHalf As System.Windows.Forms.RadioButton
    Private WithEvents rbDVResFull As System.Windows.Forms.RadioButton
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents btDVStepFWD As System.Windows.Forms.Button
    Private WithEvents btDVStepRev As System.Windows.Forms.Button
    Private WithEvents btDVFF As System.Windows.Forms.Button
    Private WithEvents btDVStop As System.Windows.Forms.Button
    Private WithEvents btDVPause As System.Windows.Forms.Button
    Private WithEvents btDVPlay As System.Windows.Forms.Button
    Private WithEvents btDVRewind As System.Windows.Forms.Button
    Private WithEvents tabPage57 As System.Windows.Forms.TabPage
    Private WithEvents lbAdjSaturationCurrent As System.Windows.Forms.Label
    Private WithEvents lbAdjSaturationMax As System.Windows.Forms.Label
    Private WithEvents cbAdjSaturationAuto As System.Windows.Forms.CheckBox
    Private WithEvents lbAdjSaturationMin As System.Windows.Forms.Label
    Private WithEvents tbAdjSaturation As System.Windows.Forms.TrackBar
    Private WithEvents label45 As System.Windows.Forms.Label
    Private WithEvents lbAdjHueCurrent As System.Windows.Forms.Label
    Private WithEvents lbAdjHueMax As System.Windows.Forms.Label
    Private WithEvents cbAdjHueAuto As System.Windows.Forms.CheckBox
    Private WithEvents lbAdjHueMin As System.Windows.Forms.Label
    Private WithEvents tbAdjHue As System.Windows.Forms.TrackBar
    Private WithEvents label41 As System.Windows.Forms.Label
    Private WithEvents lbAdjContrastCurrent As System.Windows.Forms.Label
    Private WithEvents lbAdjContrastMax As System.Windows.Forms.Label
    Private WithEvents cbAdjContrastAuto As System.Windows.Forms.CheckBox
    Private WithEvents lbAdjContrastMin As System.Windows.Forms.Label
    Private WithEvents tbAdjContrast As System.Windows.Forms.TrackBar
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents lbAdjBrightnessCurrent As System.Windows.Forms.Label
    Private WithEvents lbAdjBrightnessMax As System.Windows.Forms.Label
    Private WithEvents cbAdjBrightnessAuto As System.Windows.Forms.CheckBox
    Private WithEvents lbAdjBrightnessMin As System.Windows.Forms.Label
    Private WithEvents tbAdjBrightness As System.Windows.Forms.TrackBar
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents tabPage47 As System.Windows.Forms.TabPage
    Private WithEvents btScreenCaptureUpdate As System.Windows.Forms.Button
    Private WithEvents cbScreenCapture_GrabMouseCursor As System.Windows.Forms.CheckBox
    Private WithEvents label79 As System.Windows.Forms.Label
    Private WithEvents edScreenFrameRate As System.Windows.Forms.TextBox
    Private WithEvents label43 As System.Windows.Forms.Label
    Private WithEvents edScreenBottom As System.Windows.Forms.TextBox
    Private WithEvents label42 As System.Windows.Forms.Label
    Private WithEvents edScreenRight As System.Windows.Forms.TextBox
    Private WithEvents label40 As System.Windows.Forms.Label
    Private WithEvents edScreenTop As System.Windows.Forms.TextBox
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents edScreenLeft As System.Windows.Forms.TextBox
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents rbScreenCustomArea As System.Windows.Forms.RadioButton
    Private WithEvents rbScreenFullScreen As System.Windows.Forms.RadioButton
    Private WithEvents tabPage48 As System.Windows.Forms.TabPage
    Private WithEvents tabPage49 As System.Windows.Forms.TabPage
    Private WithEvents tabPage50 As System.Windows.Forms.TabPage
    Private WithEvents cbFlipHorizontal3 As System.Windows.Forms.CheckBox
    Private WithEvents cbFlipVertical3 As System.Windows.Forms.CheckBox
    Private WithEvents cbStretch3 As System.Windows.Forms.CheckBox
    Private WithEvents cbFlipHorizontal2 As System.Windows.Forms.CheckBox
    Private WithEvents cbFlipVertical2 As System.Windows.Forms.CheckBox
    Private WithEvents cbStretch2 As System.Windows.Forms.CheckBox
    Private WithEvents cbFlipHorizontal1 As System.Windows.Forms.CheckBox
    Private WithEvents cbFlipVertical1 As System.Windows.Forms.CheckBox
    Private WithEvents cbStretch1 As System.Windows.Forms.CheckBox
    Private WithEvents pnScreen3 As System.Windows.Forms.Panel
    Private WithEvents panel3 As System.Windows.Forms.Panel
    Private WithEvents pnScreen2 As System.Windows.Forms.Panel
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents pnScreen1 As System.Windows.Forms.Panel
    Private WithEvents tabPage51 As System.Windows.Forms.TabPage
    Private WithEvents btResume As System.Windows.Forms.Button
    Private WithEvents btPause As System.Windows.Forms.Button
    Private WithEvents cbMode As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents btSelectOutput As System.Windows.Forms.Button
    Private WithEvents edOutput As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents cbRecordAudio As System.Windows.Forms.CheckBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents tabControl17 As System.Windows.Forms.TabControl
    Private WithEvents tabPage68 As System.Windows.Forms.TabPage
    Private WithEvents label201 As System.Windows.Forms.Label
    Private WithEvents label200 As System.Windows.Forms.Label
    Private WithEvents label199 As System.Windows.Forms.Label
    Private WithEvents label198 As System.Windows.Forms.Label
    Private WithEvents tabControl7 As System.Windows.Forms.TabControl
    Private WithEvents tabPage29 As System.Windows.Forms.TabPage
    Private WithEvents tabPage42 As System.Windows.Forms.TabPage
    Private WithEvents tbContrast As System.Windows.Forms.TrackBar
    Private WithEvents tbDarkness As System.Windows.Forms.TrackBar
    Private WithEvents tbLightness As System.Windows.Forms.TrackBar
    Private WithEvents tbSaturation As System.Windows.Forms.TrackBar
    Private WithEvents cbInvert As System.Windows.Forms.CheckBox
    Private WithEvents cbGreyscale As System.Windows.Forms.CheckBox
    Private WithEvents cbEffects As System.Windows.Forms.CheckBox
    Private WithEvents tabPage69 As System.Windows.Forms.TabPage
    Private WithEvents tabPage70 As System.Windows.Forms.TabPage
    Private WithEvents btFilterDeleteAll As System.Windows.Forms.Button
    Private WithEvents btFilterSettings2 As System.Windows.Forms.Button
    Private WithEvents lbFilters As System.Windows.Forms.ListBox
    Private WithEvents label106 As System.Windows.Forms.Label
    Private WithEvents btFilterSettings As System.Windows.Forms.Button
    Private WithEvents btFilterAdd As System.Windows.Forms.Button
    Private WithEvents cbFilters As System.Windows.Forms.ComboBox
    Private WithEvents label105 As System.Windows.Forms.Label
    Private WithEvents tabControl14 As System.Windows.Forms.TabControl
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents tabPage58 As System.Windows.Forms.TabPage
    Private WithEvents tabPage27 As System.Windows.Forms.TabPage
    Private WithEvents tabControl18 As System.Windows.Forms.TabControl
    Private WithEvents tabPage71 As System.Windows.Forms.TabPage
    Private WithEvents label231 As System.Windows.Forms.Label
    Private WithEvents label230 As System.Windows.Forms.Label
    Private WithEvents tbAudAmplifyAmp As System.Windows.Forms.TrackBar
    Private WithEvents label95 As System.Windows.Forms.Label
    Private WithEvents cbAudAmplifyEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage72 As System.Windows.Forms.TabPage
    Private WithEvents btAudEqRefresh As System.Windows.Forms.Button
    Private WithEvents cbAudEqualizerPreset As System.Windows.Forms.ComboBox
    Private WithEvents label243 As System.Windows.Forms.Label
    Private WithEvents label242 As System.Windows.Forms.Label
    Private WithEvents label241 As System.Windows.Forms.Label
    Private WithEvents label240 As System.Windows.Forms.Label
    Private WithEvents label239 As System.Windows.Forms.Label
    Private WithEvents label238 As System.Windows.Forms.Label
    Private WithEvents label237 As System.Windows.Forms.Label
    Private WithEvents label236 As System.Windows.Forms.Label
    Private WithEvents label235 As System.Windows.Forms.Label
    Private WithEvents label234 As System.Windows.Forms.Label
    Private WithEvents label233 As System.Windows.Forms.Label
    Private WithEvents label232 As System.Windows.Forms.Label
    Private WithEvents tbAudEq9 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq8 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq7 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq6 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq5 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq4 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq3 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq2 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq1 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq0 As System.Windows.Forms.TrackBar
    Private WithEvents cbAudEqualizerEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage73 As System.Windows.Forms.TabPage
    Private WithEvents tbAudRelease As System.Windows.Forms.TrackBar
    Private WithEvents label248 As System.Windows.Forms.Label
    Private WithEvents label249 As System.Windows.Forms.Label
    Private WithEvents label246 As System.Windows.Forms.Label
    Private WithEvents tbAudAttack As System.Windows.Forms.TrackBar
    Private WithEvents label247 As System.Windows.Forms.Label
    Private WithEvents label244 As System.Windows.Forms.Label
    Private WithEvents tbAudDynAmp As System.Windows.Forms.TrackBar
    Private WithEvents label245 As System.Windows.Forms.Label
    Private WithEvents cbAudDynamicAmplifyEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage75 As System.Windows.Forms.TabPage
    Private WithEvents tbAud3DSound As System.Windows.Forms.TrackBar
    Private WithEvents label253 As System.Windows.Forms.Label
    Private WithEvents cbAudSound3DEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage76 As System.Windows.Forms.TabPage
    Private WithEvents tbAudTrueBass As System.Windows.Forms.TrackBar
    Private WithEvents label254 As System.Windows.Forms.Label
    Private WithEvents cbAudTrueBassEnabled As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioEffectsEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage7 As System.Windows.Forms.TabPage
    Private WithEvents tabPage28 As System.Windows.Forms.TabPage
    Private WithEvents groupBox19 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl6 As System.Windows.Forms.TabControl
    Private WithEvents tabPage30 As System.Windows.Forms.TabPage
    Private WithEvents btOSDImageDraw As System.Windows.Forms.Button
    Private WithEvents pnOSDColorKey As System.Windows.Forms.Panel
    Private WithEvents cbOSDImageTranspColor As System.Windows.Forms.CheckBox
    Private WithEvents edOSDImageTop As System.Windows.Forms.TextBox
    Private WithEvents label115 As System.Windows.Forms.Label
    Private WithEvents edOSDImageLeft As System.Windows.Forms.TextBox
    Private WithEvents label114 As System.Windows.Forms.Label
    Private WithEvents btOSDSelectImage As System.Windows.Forms.Button
    Private WithEvents edOSDImageFilename As System.Windows.Forms.TextBox
    Private WithEvents label113 As System.Windows.Forms.Label
    Private WithEvents tabPage31 As System.Windows.Forms.TabPage
    Private WithEvents edOSDTextTop As System.Windows.Forms.TextBox
    Private WithEvents label117 As System.Windows.Forms.Label
    Private WithEvents edOSDTextLeft As System.Windows.Forms.TextBox
    Private WithEvents label118 As System.Windows.Forms.Label
    Private WithEvents label116 As System.Windows.Forms.Label
    Private WithEvents btOSDSelectFont As System.Windows.Forms.Button
    Private WithEvents edOSDText As System.Windows.Forms.TextBox
    Private WithEvents btOSDTextDraw As System.Windows.Forms.Button
    Private WithEvents tabPage32 As System.Windows.Forms.TabPage
    Private WithEvents tbOSDTranspLevel As System.Windows.Forms.TrackBar
    Private WithEvents btOSDSetTransp As System.Windows.Forms.Button
    Private WithEvents label119 As System.Windows.Forms.Label
    Private WithEvents btOSDClearLayers As System.Windows.Forms.Button
    Private WithEvents groupBox15 As System.Windows.Forms.GroupBox
    Private WithEvents btOSDLayerAdd As System.Windows.Forms.Button
    Private WithEvents edOSDLayerHeight As System.Windows.Forms.TextBox
    Private WithEvents label111 As System.Windows.Forms.Label
    Private WithEvents edOSDLayerWidth As System.Windows.Forms.TextBox
    Private WithEvents label112 As System.Windows.Forms.Label
    Private WithEvents edOSDLayerTop As System.Windows.Forms.TextBox
    Private WithEvents label110 As System.Windows.Forms.Label
    Private WithEvents edOSDLayerLeft As System.Windows.Forms.TextBox
    Private WithEvents label109 As System.Windows.Forms.Label
    Private WithEvents label108 As System.Windows.Forms.Label
    Private WithEvents tabPage43 As System.Windows.Forms.TabPage
    Private WithEvents tabControl9 As System.Windows.Forms.TabControl
    Private WithEvents tabPage44 As System.Windows.Forms.TabPage
    Private WithEvents pbMotionLevel As System.Windows.Forms.ProgressBar
    Private WithEvents label158 As System.Windows.Forms.Label
    Private WithEvents mmMotDetMatrix As System.Windows.Forms.TextBox
    Private WithEvents tabPage45 As System.Windows.Forms.TabPage
    Private WithEvents groupBox25 As System.Windows.Forms.GroupBox
    Private WithEvents cbMotDetHLColor As System.Windows.Forms.ComboBox
    Private WithEvents label161 As System.Windows.Forms.Label
    Private WithEvents label160 As System.Windows.Forms.Label
    Private WithEvents cbMotDetHLEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tbMotDetHLThreshold As System.Windows.Forms.TrackBar
    Private WithEvents btMotDetUpdateSettings As System.Windows.Forms.Button
    Private WithEvents groupBox27 As System.Windows.Forms.GroupBox
    Private WithEvents edMotDetMatrixHeight As System.Windows.Forms.TextBox
    Private WithEvents label163 As System.Windows.Forms.Label
    Private WithEvents edMotDetMatrixWidth As System.Windows.Forms.TextBox
    Private WithEvents label164 As System.Windows.Forms.Label
    Private WithEvents groupBox26 As System.Windows.Forms.GroupBox
    Private WithEvents label162 As System.Windows.Forms.Label
    Private WithEvents tbMotDetDropFramesThreshold As System.Windows.Forms.TrackBar
    Private WithEvents cbMotDetDropFramesEnabled As System.Windows.Forms.CheckBox
    Private WithEvents groupBox24 As System.Windows.Forms.GroupBox
    Private WithEvents edMotDetFrameInterval As System.Windows.Forms.TextBox
    Private WithEvents label159 As System.Windows.Forms.Label
    Private WithEvents cbCompareGreyscale As System.Windows.Forms.CheckBox
    Private WithEvents cbCompareBlue As System.Windows.Forms.CheckBox
    Private WithEvents cbCompareGreen As System.Windows.Forms.CheckBox
    Private WithEvents cbCompareRed As System.Windows.Forms.CheckBox
    Private WithEvents cbMotDetEnabled As System.Windows.Forms.CheckBox
    Private WithEvents openFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage59 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage60 As System.Windows.Forms.TabPage
    Private WithEvents label211 As System.Windows.Forms.Label
    Private WithEvents edDeintTriangleWeight As System.Windows.Forms.TextBox
    Private WithEvents label212 As System.Windows.Forms.Label
    Private WithEvents label210 As System.Windows.Forms.Label
    Private WithEvents label209 As System.Windows.Forms.Label
    Private WithEvents label206 As System.Windows.Forms.Label
    Private WithEvents edDeintBlendConstants2 As System.Windows.Forms.TextBox
    Private WithEvents label207 As System.Windows.Forms.Label
    Private WithEvents edDeintBlendConstants1 As System.Windows.Forms.TextBox
    Private WithEvents label208 As System.Windows.Forms.Label
    Private WithEvents label204 As System.Windows.Forms.Label
    Private WithEvents edDeintBlendThreshold2 As System.Windows.Forms.TextBox
    Private WithEvents label205 As System.Windows.Forms.Label
    Private WithEvents edDeintBlendThreshold1 As System.Windows.Forms.TextBox
    Private WithEvents label203 As System.Windows.Forms.Label
    Private WithEvents label202 As System.Windows.Forms.Label
    Private WithEvents edDeintCAVTThreshold As System.Windows.Forms.TextBox
    Private WithEvents label104 As System.Windows.Forms.Label
    Private WithEvents rbDeintTriangleEnabled As System.Windows.Forms.RadioButton
    Private WithEvents rbDeintBlendEnabled As System.Windows.Forms.RadioButton
    Private WithEvents rbDeintCAVTEnabled As System.Windows.Forms.RadioButton
    Private WithEvents cbDeinterlace As System.Windows.Forms.CheckBox
    Private WithEvents rbDenoiseCAST As System.Windows.Forms.RadioButton
    Private WithEvents rbDenoiseMosquito As System.Windows.Forms.RadioButton
    Private WithEvents cbDenoise As System.Windows.Forms.CheckBox
    Friend WithEvents VideoCapture1 As VisioForge.Controls.UI.WinForms.VideoCapture
    Friend WithEvents TabPage23 As System.Windows.Forms.TabPage
    Private WithEvents cbScreenCaptureDisplayIndex As System.Windows.Forms.ComboBox
    Private WithEvents label93 As System.Windows.Forms.Label
    Private WithEvents tabControl20 As System.Windows.Forms.TabControl
    Private WithEvents tabPage67 As System.Windows.Forms.TabPage
    Private WithEvents tabControl21 As System.Windows.Forms.TabControl
    Private WithEvents tabPage78 As System.Windows.Forms.TabPage
    Private WithEvents btPIPAddDevice As System.Windows.Forms.Button
    Private WithEvents groupBox30 As System.Windows.Forms.GroupBox
    Private WithEvents edPIPVidCapHeight As System.Windows.Forms.TextBox
    Private WithEvents label94 As System.Windows.Forms.Label
    Private WithEvents edPIPVidCapWidth As System.Windows.Forms.TextBox
    Private WithEvents label98 As System.Windows.Forms.Label
    Private WithEvents edPIPVidCapTop As System.Windows.Forms.TextBox
    Private WithEvents label99 As System.Windows.Forms.Label
    Private WithEvents edPIPVidCapLeft As System.Windows.Forms.TextBox
    Private WithEvents label100 As System.Windows.Forms.Label
    Private WithEvents cbPIPInput As System.Windows.Forms.ComboBox
    Private WithEvents label170 As System.Windows.Forms.Label
    Private WithEvents cbPIPFrameRate As System.Windows.Forms.ComboBox
    Private WithEvents label128 As System.Windows.Forms.Label
    Private WithEvents cbPIPFormatUseBest As System.Windows.Forms.CheckBox
    Private WithEvents cbPIPFormat As System.Windows.Forms.ComboBox
    Private WithEvents label127 As System.Windows.Forms.Label
    Private WithEvents label126 As System.Windows.Forms.Label
    Private WithEvents cbPIPDevice As System.Windows.Forms.ComboBox
    Private WithEvents label125 As System.Windows.Forms.Label
    Private WithEvents tabPage79 As System.Windows.Forms.TabPage
    Private WithEvents groupBox31 As System.Windows.Forms.GroupBox
    Private WithEvents edPIPIPCapHeight As System.Windows.Forms.TextBox
    Private WithEvents label101 As System.Windows.Forms.Label
    Private WithEvents edPIPIPCapWidth As System.Windows.Forms.TextBox
    Private WithEvents label102 As System.Windows.Forms.Label
    Private WithEvents edPIPIPCapTop As System.Windows.Forms.TextBox
    Private WithEvents label103 As System.Windows.Forms.Label
    Private WithEvents edPIPIPCapLeft As System.Windows.Forms.TextBox
    Private WithEvents label229 As System.Windows.Forms.Label
    Private WithEvents btPIPAddIPCamera As System.Windows.Forms.Button
    Private WithEvents tabPage80 As System.Windows.Forms.TabPage
    Private WithEvents groupBox32 As System.Windows.Forms.GroupBox
    Private WithEvents edPIPScreenCapHeight As System.Windows.Forms.TextBox
    Private WithEvents label256 As System.Windows.Forms.Label
    Private WithEvents edPIPScreenCapWidth As System.Windows.Forms.TextBox
    Private WithEvents label260 As System.Windows.Forms.Label
    Private WithEvents edPIPScreenCapTop As System.Windows.Forms.TextBox
    Private WithEvents label266 As System.Windows.Forms.Label
    Private WithEvents edPIPScreenCapLeft As System.Windows.Forms.TextBox
    Private WithEvents label268 As System.Windows.Forms.Label
    Private WithEvents btPIPAddScreenCapture As System.Windows.Forms.Button
    Private WithEvents tabPage77 As System.Windows.Forms.TabPage
    Private WithEvents groupBox34 As System.Windows.Forms.GroupBox
    Private WithEvents btPIPSet As System.Windows.Forms.Button
    Private WithEvents tbPIPTransparency As System.Windows.Forms.TrackBar
    Private WithEvents groupBox33 As System.Windows.Forms.GroupBox
    Private WithEvents btPIPSetOutputSize As System.Windows.Forms.Button
    Private WithEvents edPIPOutputHeight As System.Windows.Forms.TextBox
    Private WithEvents label269 As System.Windows.Forms.Label
    Private WithEvents edPIPOutputWidth As System.Windows.Forms.TextBox
    Private WithEvents label271 As System.Windows.Forms.Label
    Private WithEvents cbPIPDevices As System.Windows.Forms.ComboBox
    Private WithEvents cbPIPMode As System.Windows.Forms.ComboBox
    Private WithEvents label169 As System.Windows.Forms.Label
    Private WithEvents btPIPDevicesClear As System.Windows.Forms.Button
    Private WithEvents label134 As System.Windows.Forms.Label
    Private WithEvents groupBox20 As System.Windows.Forms.GroupBox
    Private WithEvents btPIPUpdate As System.Windows.Forms.Button
    Private WithEvents edPIPHeight As System.Windows.Forms.TextBox
    Private WithEvents label132 As System.Windows.Forms.Label
    Private WithEvents edPIPWidth As System.Windows.Forms.TextBox
    Private WithEvents label133 As System.Windows.Forms.Label
    Private WithEvents edPIPTop As System.Windows.Forms.TextBox
    Private WithEvents label130 As System.Windows.Forms.Label
    Private WithEvents edPIPLeft As System.Windows.Forms.TextBox
    Private WithEvents label131 As System.Windows.Forms.Label
    Private WithEvents tabControl5 As System.Windows.Forms.TabControl
    Private WithEvents tpWMV As System.Windows.Forms.TabPage
    Private WithEvents edWMVNetworkPort As System.Windows.Forms.TextBox
    Private WithEvents label47 As System.Windows.Forms.Label
    Private WithEvents btRefreshClients As System.Windows.Forms.Button
    Private WithEvents lbNetworkClients As System.Windows.Forms.ListBox
    Private WithEvents rbNetworkStreamingUseExternalProfile As System.Windows.Forms.RadioButton
    Private WithEvents rbNetworkStreamingUseMainWMVSettings As System.Windows.Forms.RadioButton
    Private WithEvents label81 As System.Windows.Forms.Label
    Private WithEvents label80 As System.Windows.Forms.Label
    Private WithEvents edMaximumClients As System.Windows.Forms.TextBox
    Private WithEvents label46 As System.Windows.Forms.Label
    Private WithEvents btSelectWMVProfileNetwork As System.Windows.Forms.Button
    Private WithEvents edNetworkStreamingWMVProfile As System.Windows.Forms.TextBox
    Private WithEvents label44 As System.Windows.Forms.Label
    Private WithEvents tpExternal As System.Windows.Forms.TabPage
    Private WithEvents cbNetworkStreamingAudioEnabled As System.Windows.Forms.CheckBox
    Private WithEvents cbNetworkStreaming As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage66 As System.Windows.Forms.TabPage
    Private WithEvents tabControl22 As System.Windows.Forms.TabControl
    Private WithEvents tabPage82 As System.Windows.Forms.TabPage
    Private WithEvents cbBDADeviceStandard As System.Windows.Forms.ComboBox
    Private WithEvents label129 As System.Windows.Forms.Label
    Private WithEvents cbBDAReceiver As System.Windows.Forms.ComboBox
    Private WithEvents label270 As System.Windows.Forms.Label
    Private WithEvents cbBDASourceDevice As System.Windows.Forms.ComboBox
    Private WithEvents label272 As System.Windows.Forms.Label
    Private WithEvents tabPage83 As System.Windows.Forms.TabPage
    Private WithEvents tabControl23 As System.Windows.Forms.TabControl
    Private WithEvents tabPage84 As System.Windows.Forms.TabPage
    Private WithEvents btDVBTTune As System.Windows.Forms.Button
    Private WithEvents edDVBTSID As System.Windows.Forms.TextBox
    Private WithEvents edDVBTTSID As System.Windows.Forms.TextBox
    Private WithEvents edDVBTONID As System.Windows.Forms.TextBox
    Private WithEvents label273 As System.Windows.Forms.Label
    Private WithEvents edDVBTFrequency As System.Windows.Forms.TextBox
    Private WithEvents label274 As System.Windows.Forms.Label
    Private WithEvents label275 As System.Windows.Forms.Label
    Private WithEvents label276 As System.Windows.Forms.Label
    Private WithEvents label277 As System.Windows.Forms.Label
    Private WithEvents tabPage85 As System.Windows.Forms.TabPage
    Private WithEvents cbDVBSPolarisation As System.Windows.Forms.ComboBox
    Private WithEvents label278 As System.Windows.Forms.Label
    Private WithEvents edDVBSSymbolRate As System.Windows.Forms.TextBox
    Private WithEvents label279 As System.Windows.Forms.Label
    Private WithEvents btDVBSTune As System.Windows.Forms.Button
    Private WithEvents edDVBSSID As System.Windows.Forms.TextBox
    Private WithEvents edDVBSTSID As System.Windows.Forms.TextBox
    Private WithEvents edDVBSONIT As System.Windows.Forms.TextBox
    Private WithEvents label280 As System.Windows.Forms.Label
    Private WithEvents edDVBSFrequency As System.Windows.Forms.TextBox
    Private WithEvents label281 As System.Windows.Forms.Label
    Private WithEvents label282 As System.Windows.Forms.Label
    Private WithEvents label283 As System.Windows.Forms.Label
    Private WithEvents label284 As System.Windows.Forms.Label
    Private WithEvents tabPage86 As System.Windows.Forms.TabPage
    Private WithEvents groupBox35 As System.Windows.Forms.GroupBox
    Private WithEvents edDVBCMinorChannel As System.Windows.Forms.TextBox
    Private WithEvents label285 As System.Windows.Forms.Label
    Private WithEvents edDVBCPhysicalChannel As System.Windows.Forms.TextBox
    Private WithEvents label286 As System.Windows.Forms.Label
    Private WithEvents edDVBCVirtualChannel As System.Windows.Forms.TextBox
    Private WithEvents label287 As System.Windows.Forms.Label
    Private WithEvents groupBox36 As System.Windows.Forms.GroupBox
    Private WithEvents edDVBCSymbolRate As System.Windows.Forms.TextBox
    Private WithEvents label288 As System.Windows.Forms.Label
    Private WithEvents edDVBCProgramNumber As System.Windows.Forms.TextBox
    Private WithEvents label289 As System.Windows.Forms.Label
    Private WithEvents cbDVBCModulation As System.Windows.Forms.ComboBox
    Private WithEvents label290 As System.Windows.Forms.Label
    Private WithEvents label291 As System.Windows.Forms.Label
    Private WithEvents edDVBCCarrierFrequency As System.Windows.Forms.TextBox
    Private WithEvents label292 As System.Windows.Forms.Label
    Private WithEvents btBDADVBCTune As System.Windows.Forms.Button
    Private WithEvents tabPage87 As System.Windows.Forms.TabPage
    Private WithEvents label293 As System.Windows.Forms.Label
    Friend WithEvents TabPage88 As System.Windows.Forms.TabPage
    Private WithEvents cbZoom As System.Windows.Forms.CheckBox
    Private WithEvents groupBox37 As System.Windows.Forms.GroupBox
    Private WithEvents btEffZoomRight As System.Windows.Forms.Button
    Private WithEvents btEffZoomLeft As System.Windows.Forms.Button
    Private WithEvents btEffZoomOut As System.Windows.Forms.Button
    Private WithEvents btEffZoomIn As System.Windows.Forms.Button
    Private WithEvents btEffZoomDown As System.Windows.Forms.Button
    Private WithEvents btEffZoomUp As System.Windows.Forms.Button
    Friend WithEvents TabPage91 As System.Windows.Forms.TabPage
    Private WithEvents groupBox40 As System.Windows.Forms.GroupBox
    Private WithEvents edPanDestHeight As System.Windows.Forms.TextBox
    Private WithEvents label302 As System.Windows.Forms.Label
    Private WithEvents edPanDestWidth As System.Windows.Forms.TextBox
    Private WithEvents label303 As System.Windows.Forms.Label
    Private WithEvents edPanDestTop As System.Windows.Forms.TextBox
    Private WithEvents label304 As System.Windows.Forms.Label
    Private WithEvents edPanDestLeft As System.Windows.Forms.TextBox
    Private WithEvents label305 As System.Windows.Forms.Label
    Private WithEvents groupBox39 As System.Windows.Forms.GroupBox
    Private WithEvents edPanSourceHeight As System.Windows.Forms.TextBox
    Private WithEvents label298 As System.Windows.Forms.Label
    Private WithEvents edPanSourceWidth As System.Windows.Forms.TextBox
    Private WithEvents label299 As System.Windows.Forms.Label
    Private WithEvents edPanSourceTop As System.Windows.Forms.TextBox
    Private WithEvents label300 As System.Windows.Forms.Label
    Private WithEvents edPanSourceLeft As System.Windows.Forms.TextBox
    Private WithEvents label301 As System.Windows.Forms.Label
    Private WithEvents groupBox38 As System.Windows.Forms.GroupBox
    Private WithEvents edPanStopTime As System.Windows.Forms.TextBox
    Private WithEvents label296 As System.Windows.Forms.Label
    Private WithEvents edPanStartTime As System.Windows.Forms.TextBox
    Private WithEvents label297 As System.Windows.Forms.Label
    Private WithEvents cbPan As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage25 As System.Windows.Forms.TabPage
    Private WithEvents edBarcodeMetadata As System.Windows.Forms.TextBox
    Private WithEvents label91 As System.Windows.Forms.Label
    Private WithEvents cbBarcodeType As System.Windows.Forms.ComboBox
    Private WithEvents label90 As System.Windows.Forms.Label
    Private WithEvents btBarcodeReset As System.Windows.Forms.Button
    Private WithEvents edBarcode As System.Windows.Forms.TextBox
    Private WithEvents label89 As System.Windows.Forms.Label
    Private WithEvents cbBarcodeDetectionEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Private WithEvents tabControl19 As System.Windows.Forms.TabControl
    Private WithEvents tabPage96 As System.Windows.Forms.TabPage
    Private WithEvents cbUseBestAudioInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents cbUseAudioInputFromVideoCaptureDevice As System.Windows.Forms.CheckBox
    Private WithEvents btAudioInputDeviceSettings As System.Windows.Forms.Button
    Private WithEvents cbAudioInputLine As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents tabPage97 As System.Windows.Forms.TabPage
    Private WithEvents label55 As System.Windows.Forms.Label
    Private WithEvents tbAudioBalance As System.Windows.Forms.TrackBar
    Private WithEvents label54 As System.Windows.Forms.Label
    Private WithEvents tbAudioVolume As System.Windows.Forms.TrackBar
    Private WithEvents cbPlayAudio As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioOutputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents tabPage98 As System.Windows.Forms.TabPage
    Private WithEvents peakMeterCtrl1 As VisioForge.Controls.UI.WinForms.PeakMeterCtrl
    Private WithEvents cbVUMeter As System.Windows.Forms.CheckBox
    Private WithEvents tabPage99 As System.Windows.Forms.TabPage
    Private WithEvents label319 As System.Windows.Forms.Label
    Private WithEvents label318 As System.Windows.Forms.Label
    Private WithEvents btAddAdditionalAudioSource As System.Windows.Forms.Button
    Private WithEvents cbAdditionalAudioSource As System.Windows.Forms.ComboBox
    Private WithEvents label180 As System.Windows.Forms.Label
    Friend WithEvents TabPage92 As System.Windows.Forms.TabPage
    Private WithEvents label92 As System.Windows.Forms.Label
    Private WithEvents cbRotate As System.Windows.Forms.ComboBox
    Private WithEvents edCropRight As System.Windows.Forms.TextBox
    Private WithEvents label52 As System.Windows.Forms.Label
    Private WithEvents edCropBottom As System.Windows.Forms.TextBox
    Private WithEvents label53 As System.Windows.Forms.Label
    Private WithEvents edCropLeft As System.Windows.Forms.TextBox
    Private WithEvents label50 As System.Windows.Forms.Label
    Private WithEvents edCropTop As System.Windows.Forms.TextBox
    Private WithEvents label51 As System.Windows.Forms.Label
    Private WithEvents cbCrop As System.Windows.Forms.CheckBox
    Private WithEvents cbResizeMode As System.Windows.Forms.ComboBox
    Private WithEvents label49 As System.Windows.Forms.Label
    Private WithEvents cbResizeLetterbox As System.Windows.Forms.CheckBox
    Private WithEvents edResizeHeight As System.Windows.Forms.TextBox
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents edResizeWidth As System.Windows.Forms.TextBox
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents cbResize As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage93 As System.Windows.Forms.TabPage
    Private WithEvents groupBox44 As System.Windows.Forms.GroupBox
    Private WithEvents edPIPFileHeight As System.Windows.Forms.TextBox
    Private WithEvents label321 As System.Windows.Forms.Label
    Private WithEvents edPIPFileWidth As System.Windows.Forms.TextBox
    Private WithEvents label322 As System.Windows.Forms.Label
    Private WithEvents edPIPFileTop As System.Windows.Forms.TextBox
    Private WithEvents label323 As System.Windows.Forms.Label
    Private WithEvents edPIPFileLeft As System.Windows.Forms.TextBox
    Private WithEvents label324 As System.Windows.Forms.Label
    Private WithEvents btPIPFileSourceAdd As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents edPIPFileSoureFilename As System.Windows.Forms.TextBox
    Private WithEvents label320 As System.Windows.Forms.Label
    Friend WithEvents TabPage100 As System.Windows.Forms.TabPage
    Private WithEvents label326 As System.Windows.Forms.Label
    Private WithEvents label325 As System.Windows.Forms.Label
    Private WithEvents cbVirtualCamera As System.Windows.Forms.CheckBox
    Private WithEvents label328 As System.Windows.Forms.Label
    Private WithEvents label327 As System.Windows.Forms.Label
    Friend WithEvents TabPage101 As System.Windows.Forms.TabPage
    Private WithEvents rbFadeOut As System.Windows.Forms.RadioButton
    Private WithEvents rbFadeIn As System.Windows.Forms.RadioButton
    Private WithEvents groupBox45 As System.Windows.Forms.GroupBox
    Private WithEvents edFadeInOutStopTime As System.Windows.Forms.TextBox
    Private WithEvents label329 As System.Windows.Forms.Label
    Private WithEvents edFadeInOutStartTime As System.Windows.Forms.TextBox
    Private WithEvents label330 As System.Windows.Forms.Label
    Private WithEvents cbFadeInOut As System.Windows.Forms.CheckBox
    Private WithEvents linkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage102 As System.Windows.Forms.TabPage
    Private WithEvents cbDecklinkDV As System.Windows.Forms.CheckBox
    Private WithEvents cbDecklinkOutput As System.Windows.Forms.CheckBox
    Private WithEvents cbDecklinkOutputDownConversionAnalogOutput As System.Windows.Forms.CheckBox
    Private WithEvents cbDecklinkOutputDownConversion As System.Windows.Forms.ComboBox
    Private WithEvents label337 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputHDTVPulldown As System.Windows.Forms.ComboBox
    Private WithEvents label336 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputBlackToDeck As System.Windows.Forms.ComboBox
    Private WithEvents label335 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputSingleField As System.Windows.Forms.ComboBox
    Private WithEvents label334 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputComponentLevels As System.Windows.Forms.ComboBox
    Private WithEvents label333 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputNTSC As System.Windows.Forms.ComboBox
    Private WithEvents label332 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputDualLink As System.Windows.Forms.ComboBox
    Private WithEvents label331 As System.Windows.Forms.Label
    Private WithEvents cbDecklinkOutputAnalog As System.Windows.Forms.ComboBox
    Private WithEvents label87 As System.Windows.Forms.Label
    Friend WithEvents TabPage104 As System.Windows.Forms.TabPage
    Private WithEvents btBDAChannelScanningStart As System.Windows.Forms.Button
    Private WithEvents lvBDAChannels As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents label342 As System.Windows.Forms.Label
    Private WithEvents linkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage105 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage106 As System.Windows.Forms.TabPage
    Private WithEvents edFaceTrackingFaces As System.Windows.Forms.TextBox
    Private WithEvents label364 As System.Windows.Forms.Label
    Private WithEvents label363 As System.Windows.Forms.Label
    Private WithEvents cbFaceTrackingScalingMode As System.Windows.Forms.ComboBox
    Private WithEvents label362 As System.Windows.Forms.Label
    Private WithEvents edFaceTrackingScaleFactor As System.Windows.Forms.TextBox
    Private WithEvents label361 As System.Windows.Forms.Label
    Private WithEvents cbFaceTrackingSearchMode As System.Windows.Forms.ComboBox
    Private WithEvents cbFaceTrackingColorMode As System.Windows.Forms.ComboBox
    Private WithEvents label346 As System.Windows.Forms.Label
    Private WithEvents edFaceTrackingMinimumWindowSize As System.Windows.Forms.TextBox
    Private WithEvents label345 As System.Windows.Forms.Label
    Private WithEvents cbFaceTrackingCHL As System.Windows.Forms.CheckBox
    Private WithEvents cbFaceTrackingEnabled As System.Windows.Forms.CheckBox
    Private WithEvents label365 As System.Windows.Forms.Label
    Private WithEvents label48 As System.Windows.Forms.Label
    Private WithEvents edNetworkURL As System.Windows.Forms.TextBox
    Friend WithEvents tpRTSP As System.Windows.Forms.TabPage
    Private WithEvents edNetworkRTSPURL As System.Windows.Forms.TextBox
    Private WithEvents label367 As System.Windows.Forms.Label
    Private WithEvents label366 As System.Windows.Forms.Label
    Friend WithEvents tpRTMP As System.Windows.Forms.TabPage
    Friend WithEvents tpSSF As System.Windows.Forms.TabPage
    Private WithEvents edNetworkSSURL As System.Windows.Forms.TextBox
    Private WithEvents label370 As System.Windows.Forms.Label
    Private WithEvents label371 As System.Windows.Forms.Label
    Private WithEvents rbNetworkSSSoftware As System.Windows.Forms.RadioButton
    Private WithEvents cbNetworkStreamingMode As System.Windows.Forms.ComboBox
    Private WithEvents linkLabel5 As System.Windows.Forms.LinkLabel
    Private WithEvents label376 As System.Windows.Forms.Label
    Private WithEvents edSeparateCaptureFileSize As System.Windows.Forms.TextBox
    Private WithEvents label375 As System.Windows.Forms.Label
    Private WithEvents label374 As System.Windows.Forms.Label
    Private WithEvents edSeparateCaptureDuration As System.Windows.Forms.TextBox
    Private WithEvents label373 As System.Windows.Forms.Label
    Private WithEvents rbSeparateCaptureSplitBySize As System.Windows.Forms.RadioButton
    Private WithEvents rbSeparateCaptureSplitByDuration As System.Windows.Forms.RadioButton
    Private WithEvents rbSeparateCaptureStartManually As System.Windows.Forms.RadioButton
    Private WithEvents btSeparateCaptureResume As System.Windows.Forms.Button
    Private WithEvents btSeparateCapturePause As System.Windows.Forms.Button
    Private WithEvents groupBox8 As System.Windows.Forms.GroupBox
    Private WithEvents btSeparateCaptureChangeFilename As System.Windows.Forms.Button
    Private WithEvents edNewFilename As System.Windows.Forms.TextBox
    Private WithEvents label84 As System.Windows.Forms.Label
    Private WithEvents btSeparateCaptureStop As System.Windows.Forms.Button
    Private WithEvents btSeparateCaptureStart As System.Windows.Forms.Button
    Private WithEvents cbSeparateCaptureEnabled As System.Windows.Forms.CheckBox
    Private WithEvents label83 As System.Windows.Forms.Label
    Private WithEvents label82 As System.Windows.Forms.Label
    Friend WithEvents TabPage111 As System.Windows.Forms.TabPage
    Private WithEvents tbVUMeterBoost As System.Windows.Forms.TrackBar
    Private WithEvents label382 As System.Windows.Forms.Label
    Private WithEvents waveformPainter2 As VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter
    Private WithEvents waveformPainter1 As VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter
    Private WithEvents volumeMeter2 As VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter
    Private WithEvents label381 As System.Windows.Forms.Label
    Private WithEvents tbVUMeterAmplification As System.Windows.Forms.TrackBar
    Private WithEvents cbVUMeterPro As System.Windows.Forms.CheckBox
    Private WithEvents volumeMeter1 As VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter
    Friend WithEvents TabPage112 As System.Windows.Forms.TabPage
    Private WithEvents cbLiveRotationStretch As System.Windows.Forms.CheckBox
    Private WithEvents label392 As System.Windows.Forms.Label
    Private WithEvents tbLiveRotationAngle As System.Windows.Forms.TrackBar
    Private WithEvents label390 As System.Windows.Forms.Label
    Private WithEvents cbLiveRotation As System.Windows.Forms.CheckBox
    Private WithEvents label391 As System.Windows.Forms.Label
    Private WithEvents tabControl26 As System.Windows.Forms.TabControl
    Private WithEvents tabPage115 As System.Windows.Forms.TabPage
    Private WithEvents pnVideoRendererBGColor As System.Windows.Forms.Panel
    Private WithEvents label394 As System.Windows.Forms.Label
    Private WithEvents btFullScreen As System.Windows.Forms.Button
    Private WithEvents groupBox28 As System.Windows.Forms.GroupBox
    Private WithEvents btZoomShiftRight As System.Windows.Forms.Button
    Private WithEvents btZoomShiftLeft As System.Windows.Forms.Button
    Private WithEvents btZoomOut As System.Windows.Forms.Button
    Private WithEvents btZoomIn As System.Windows.Forms.Button
    Private WithEvents btZoomShiftDown As System.Windows.Forms.Button
    Private WithEvents btZoomShiftUp As System.Windows.Forms.Button
    Private WithEvents cbScreenFlipVertical As System.Windows.Forms.CheckBox
    Private WithEvents cbScreenFlipHorizontal As System.Windows.Forms.CheckBox
    Private WithEvents cbStretch As System.Windows.Forms.CheckBox
    Private WithEvents groupBox13 As System.Windows.Forms.GroupBox
    Private WithEvents rbDirect2D As System.Windows.Forms.RadioButton
    Private WithEvents rbNone As System.Windows.Forms.RadioButton
    Private WithEvents rbEVR As System.Windows.Forms.RadioButton
    Private WithEvents rbVMR9 As System.Windows.Forms.RadioButton
    Private WithEvents rbVR As System.Windows.Forms.RadioButton
    Private WithEvents tabPage116 As System.Windows.Forms.TabPage
    Private WithEvents label393 As System.Windows.Forms.Label
    Private WithEvents cbDirect2DRotate As System.Windows.Forms.ComboBox
    Private WithEvents rbAddAudioStreamsIndependent As System.Windows.Forms.RadioButton
    Private WithEvents rbAddAudioStreamsMix As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage123 As System.Windows.Forms.TabPage
    Private WithEvents tabControl28 As System.Windows.Forms.TabControl
    Private WithEvents tabPage125 As System.Windows.Forms.TabPage
    Private WithEvents cbCustomVideoSourceFrameRate As System.Windows.Forms.ComboBox
    Private WithEvents label438 As System.Windows.Forms.Label
    Private WithEvents label435 As System.Windows.Forms.Label
    Private WithEvents cbCustomVideoSourceFormat As System.Windows.Forms.ComboBox
    Private WithEvents label434 As System.Windows.Forms.Label
    Private WithEvents cbCustomVideoSourceFilter As System.Windows.Forms.ComboBox
    Private WithEvents cbCustomVideoSourceCategory As System.Windows.Forms.ComboBox
    Private WithEvents label432 As System.Windows.Forms.Label
    Private WithEvents tabPage126 As System.Windows.Forms.TabPage
    Private WithEvents label437 As System.Windows.Forms.Label
    Private WithEvents cbCustomAudioSourceFormat As System.Windows.Forms.ComboBox
    Private WithEvents label436 As System.Windows.Forms.Label
    Private WithEvents cbCustomAudioSourceFilter As System.Windows.Forms.ComboBox
    Private WithEvents label433 As System.Windows.Forms.Label
    Private WithEvents cbCustomAudioSourceCategory As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage124 As System.Windows.Forms.TabPage
    Private WithEvents lbAudioTimeshift As System.Windows.Forms.Label
    Private WithEvents tbAudioTimeshift As System.Windows.Forms.TrackBar
    Private WithEvents Label430 As System.Windows.Forms.Label
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lbAudioOutputGainLFE As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainLFE As System.Windows.Forms.TrackBar
    Private WithEvents Label431 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainSR As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainSR As System.Windows.Forms.TrackBar
    Private WithEvents Label439 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainSL As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainSL As System.Windows.Forms.TrackBar
    Private WithEvents Label440 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainR As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainR As System.Windows.Forms.TrackBar
    Private WithEvents Label441 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainC As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainC As System.Windows.Forms.TrackBar
    Private WithEvents Label442 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainL As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainL As System.Windows.Forms.TrackBar
    Private WithEvents Label443 As System.Windows.Forms.Label
    Private WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents lbAudioInputGainLFE As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainLFE As System.Windows.Forms.TrackBar
    Private WithEvents Label444 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainSR As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainSR As System.Windows.Forms.TrackBar
    Private WithEvents Label445 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainSL As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainSL As System.Windows.Forms.TrackBar
    Private WithEvents Label446 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainR As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainR As System.Windows.Forms.TrackBar
    Private WithEvents Label447 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainC As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainC As System.Windows.Forms.TrackBar
    Private WithEvents Label448 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainL As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainL As System.Windows.Forms.TrackBar
    Private WithEvents Label449 As System.Windows.Forms.Label
    Private WithEvents cbAudioAutoGain As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioNormalize As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioEnhancementEnabled As System.Windows.Forms.CheckBox
    Private WithEvents cbScreenCapture_DesktopDuplication As System.Windows.Forms.CheckBox
    Private WithEvents rbNetworkRTMPFFMPEGCustom As System.Windows.Forms.RadioButton
    Private WithEvents rbNetworkRTMPFFMPEG As System.Windows.Forms.RadioButton
    Private WithEvents edNetworkRTMPURL As System.Windows.Forms.TextBox
    Private WithEvents label368 As System.Windows.Forms.Label
    Private WithEvents label369 As System.Windows.Forms.Label
    Friend WithEvents tpUDP As System.Windows.Forms.TabPage
    Private WithEvents label484 As System.Windows.Forms.Label
    Private WithEvents edNetworkUDPURL As System.Windows.Forms.TextBox
    Private WithEvents label372 As System.Windows.Forms.Label
    Private WithEvents rbNetworkUDPFFMPEGCustom As System.Windows.Forms.RadioButton
    Private WithEvents rbNetworkUDPFFMPEG As System.Windows.Forms.RadioButton
    Private WithEvents groupBox48 As System.Windows.Forms.GroupBox
    Private WithEvents label343 As System.Windows.Forms.Label
    Private WithEvents edEncryptionKeyHEX As System.Windows.Forms.TextBox
    Private WithEvents rbEncryptionKeyBinary As System.Windows.Forms.RadioButton
    Private WithEvents btEncryptionOpenFile As System.Windows.Forms.Button
    Private WithEvents edEncryptionKeyFile As System.Windows.Forms.TextBox
    Private WithEvents rbEncryptionKeyFile As System.Windows.Forms.RadioButton
    Private WithEvents edEncryptionKeyString As System.Windows.Forms.TextBox
    Private WithEvents rbEncryptionKeyString As System.Windows.Forms.RadioButton
    Private WithEvents groupBox47 As System.Windows.Forms.GroupBox
    Private WithEvents rbEncryptionModeAES256 As System.Windows.Forms.RadioButton
    Private WithEvents rbEncryptionModeAES128 As System.Windows.Forms.RadioButton
    Private WithEvents groupBox43 As System.Windows.Forms.GroupBox
    Private WithEvents rbEncryptedH264CUDA As System.Windows.Forms.RadioButton
    Private WithEvents rbEncryptedH264SW As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage141 As TabPage
    Friend WithEvents TabControl32 As TabControl
    Friend WithEvents TabPage142 As TabPage
    Friend WithEvents TabPage143 As TabPage
    Friend WithEvents cbTagEnabled As CheckBox
    Friend WithEvents edTagTitle As TextBox
    Friend WithEvents Label488 As Label
    Friend WithEvents edTagCopyright As TextBox
    Friend WithEvents Label489 As Label
    Friend WithEvents edTagAlbum As TextBox
    Friend WithEvents Label491 As Label
    Friend WithEvents edTagArtists As TextBox
    Friend WithEvents Label490 As Label
    Friend WithEvents edTagComment As TextBox
    Friend WithEvents Label493 As Label
    Friend WithEvents edTagComposers As TextBox
    Friend WithEvents Label492 As Label
    Friend WithEvents cbTagGenre As ComboBox
    Friend WithEvents Label494 As Label
    Friend WithEvents edTagYear As TextBox
    Friend WithEvents Label495 As Label
    Friend WithEvents edTagTrackID As TextBox
    Friend WithEvents Label496 As Label
    Friend WithEvents edTagLyrics As TextBox
    Friend WithEvents Label497 As Label
    Friend WithEvents Label498 As Label
    Friend WithEvents imgTagCover As PictureBox
    Friend WithEvents Label499 As Label
    Private WithEvents cbUseClosedCaptions As CheckBox
    Private WithEvents Label250 As Label
    Friend WithEvents TabPage26 As TabPage
    Private WithEvents pbAFMotionLevel As ProgressBar
    Private WithEvents label65 As Label
    Private WithEvents LinkLabel8 As LinkLabel
    Private WithEvents LinkLabel9 As LinkLabel
    Private WithEvents rbNetworkSSFFMPEGCustom As RadioButton
    Private WithEvents rbNetworkSSFFMPEGDefault As RadioButton
    Private WithEvents linkLabel10 As LinkLabel
    Friend WithEvents TabPage61 As TabPage
    Private WithEvents cbDecklinkSourceTimecode As ComboBox
    Private WithEvents label341 As Label
    Private WithEvents cbDecklinkSourceComponentLevels As ComboBox
    Private WithEvents label339 As Label
    Private WithEvents cbDecklinkSourceNTSC As ComboBox
    Private WithEvents label340 As Label
    Private WithEvents cbDecklinkSourceInput As ComboBox
    Private WithEvents label338 As Label
    Private WithEvents cbDecklinkCaptureVideoFormat As ComboBox
    Private WithEvents label66 As Label
    Private WithEvents cbDecklinkCaptureDevice As ComboBox
    Private WithEvents label39 As Label
    Friend WithEvents TabPage22 As TabPage
    Private WithEvents btAudioChannelMapperClear As Button
    Private WithEvents groupBox41 As GroupBox
    Private WithEvents btAudioChannelMapperAddNewRoute As Button
    Private WithEvents label311 As Label
    Private WithEvents tbAudioChannelMapperVolume As TrackBar
    Private WithEvents label310 As Label
    Private WithEvents edAudioChannelMapperTargetChannel As TextBox
    Private WithEvents label309 As Label
    Private WithEvents edAudioChannelMapperSourceChannel As TextBox
    Private WithEvents label308 As Label
    Private WithEvents label307 As Label
    Private WithEvents edAudioChannelMapperOutputChannels As TextBox
    Private WithEvents label306 As Label
    Private WithEvents lbAudioChannelMapperRoutes As ListBox
    Private WithEvents cbAudioChannelMapperEnabled As CheckBox
    Private WithEvents linkLabel11 As LinkLabel
    Private WithEvents label314 As Label
    Private WithEvents label313 As Label
    Friend WithEvents TabPage63 As TabPage
    Private WithEvents cbGPUOldMovie As CheckBox
    Private WithEvents cbGPUDeinterlace As CheckBox
    Private WithEvents cbGPUDenoise As CheckBox
    Private WithEvents cbGPUPixelate As CheckBox
    Private WithEvents cbGPUNightVision As CheckBox
    Private WithEvents label383 As Label
    Private WithEvents label384 As Label
    Private WithEvents label385 As Label
    Private WithEvents label386 As Label
    Private WithEvents tbGPUContrast As TrackBar
    Private WithEvents tbGPUDarkness As TrackBar
    Private WithEvents tbGPULightness As TrackBar
    Private WithEvents tbGPUSaturation As TrackBar
    Private WithEvents cbGPUInvert As CheckBox
    Private WithEvents cbGPUGreyscale As CheckBox
    Private WithEvents label505 As Label
    Private WithEvents rbMotionDetectionExProcessor As ComboBox
    Private WithEvents label389 As Label
    Private WithEvents rbMotionDetectionExDetector As ComboBox
    Private WithEvents label64 As Label
    Private WithEvents cbMotionDetectionEx As CheckBox
    Private WithEvents tabControl15 As TabControl
    Private WithEvents tabPage144 As TabPage
    Private WithEvents cbIPCameraONVIF As CheckBox
    Private WithEvents btShowIPCamDatabase As Button
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
    Private WithEvents lbONVIFCameraInfo As Label
    Private WithEvents btONVIFConnect As Button
    Friend WithEvents TabPage113 As TabPage
    Private WithEvents lbPIPChromaKeyTolerance2 As Label
    Private WithEvents label518 As Label
    Private WithEvents tbPIPChromaKeyTolerance2 As TrackBar
    Private WithEvents lbPIPChromaKeyTolerance1 As Label
    Private WithEvents label515 As Label
    Private WithEvents tbPIPChromaKeyTolerance1 As TrackBar
    Private WithEvents pnPIPChromaKeyColor As Panel
    Private WithEvents label514 As Label
    Private WithEvents cbPIPResizeMode As ComboBox
    Private WithEvents label317 As Label
    Private WithEvents edCustomAudioSourceURL As TextBox
    Private WithEvents label517 As Label
    Private WithEvents edCustomVideoSourceURL As TextBox
    Private WithEvents label516 As Label
    Private WithEvents label165 As Label
    Private WithEvents edONVIFPassword As TextBox
    Private WithEvents Label379 As Label
    Private WithEvents edONVIFLogin As TextBox
    Private WithEvents Label380 As Label
    Private WithEvents edONVIFURL As TextBox
    Private WithEvents cbMultiscreenDrawOnExternalDisplays As CheckBox
    Private WithEvents cbMultiscreenDrawOnPanels As CheckBox
    Friend WithEvents tpHLS As TabPage
    Private WithEvents lbHLSConfigure As LinkLabel
    Private WithEvents label532 As Label
    Private WithEvents label531 As Label
    Private WithEvents label530 As Label
    Private WithEvents label529 As Label
    Private WithEvents edHLSSegmentCount As TextBox
    Private WithEvents label519 As Label
    Private WithEvents edHLSSegmentDuration As TextBox
    Private WithEvents btSelectHLSOutputFolder As Button
    Private WithEvents edHLSOutputFolder As TextBox
    Private WithEvents Label500 As Label
    Private WithEvents btOutputConfigure As Button
    Private WithEvents cbOutputFormat As ComboBox
    Private WithEvents lbInfo As Label
    Private WithEvents btSaveScreenshot As Button
    Private WithEvents lbTimestamp As Label
    Private WithEvents btTextLogoRemove As Button
    Private WithEvents btTextLogoEdit As Button
    Private WithEvents lbTextLogos As ListBox
    Private WithEvents btTextLogoAdd As Button
    Private WithEvents btImageLogoRemove As Button
    Private WithEvents btImageLogoEdit As Button
    Private WithEvents lbImageLogos As ListBox
    Private WithEvents btImageLogoAdd As Button
    Private WithEvents cbFlipY As CheckBox
    Private WithEvents cbFlipX As CheckBox
    Private WithEvents cbTelemetry As CheckBox
    Friend WithEvents TabPage3 As TabPage
    Private WithEvents label1 As Label
    Private WithEvents btCCFocusApply As Button
    Private WithEvents btCCZoomApply As Button
    Private WithEvents cbCCFocusRelative As CheckBox
    Private WithEvents cbCCFocusManual As CheckBox
    Private WithEvents cbCCFocusAuto As CheckBox
    Private WithEvents lbCCFocusCurrent As Label
    Private WithEvents lbCCFocusMax As Label
    Private WithEvents lbCCFocusMin As Label
    Private WithEvents tbCCFocus As TrackBar
    Private WithEvents label4 As Label
    Private WithEvents cbCCZoomRelative As CheckBox
    Private WithEvents cbCCZoomManual As CheckBox
    Private WithEvents cbCCZoomAuto As CheckBox
    Private WithEvents lbCCZoomCurrent As Label
    Private WithEvents lbCCZoomMax As Label
    Private WithEvents lbCCZoomMin As Label
    Private WithEvents tbCCZoom As TrackBar
    Private WithEvents label20 As Label
    Private WithEvents btCCTiltApply As Button
    Private WithEvents btCCPanApply As Button
    Private WithEvents cbCCTiltRelative As CheckBox
    Private WithEvents cbCCTiltManual As CheckBox
    Private WithEvents cbCCTiltAuto As CheckBox
    Private WithEvents lbCCTiltCurrent As Label
    Private WithEvents lbCCTiltMax As Label
    Private WithEvents lbCCTiltMin As Label
    Private WithEvents tbCCTilt As TrackBar
    Private WithEvents label97 As Label
    Private WithEvents cbCCPanRelative As CheckBox
    Private WithEvents cbCCPanManual As CheckBox
    Private WithEvents cbCCPanAuto As CheckBox
    Private WithEvents btCCReadValues As Button
    Private WithEvents lbCCPanCurrent As Label
    Private WithEvents lbCCPanMax As Label
    Private WithEvents lbCCPanMin As Label
    Private WithEvents tbCCPan As TrackBar
    Private WithEvents label96 As Label
    Private WithEvents cbOSDEnabled As CheckBox
    Private WithEvents btOSDClearLayer As Button
    Friend WithEvents cbVideoEffectsGPUEnabled As CheckBox
    Private WithEvents lbOSDLayers As CheckedListBox
    Private WithEvents btOSDRenderLayers As Button
    Friend WithEvents btZoomReset As Button
    Private WithEvents textBox1 As TextBox
    Private WithEvents label3 As Label
    Private WithEvents lbScreenSourceWindowText As Label
    Private WithEvents btScreenSourceWindowSelect As Button
    Private WithEvents rbScreenCaptureWindow As RadioButton
    Private WithEvents cbNetworkRTMPFFMPEGUsePipes As CheckBox
    Private WithEvents cbNetworkUDPFFMPEGUsePipes As CheckBox
    Private WithEvents cbNetworkSSUsePipes As CheckBox
    Private WithEvents label5 As Label
    Private WithEvents tbGPUBlur As TrackBar
    Private WithEvents cbMergeTextLogos As CheckBox
    Private WithEvents cbMergeImageLogos As CheckBox
    Private WithEvents cbHLSMode As ComboBox
    Private WithEvents label6 As Label
    Private WithEvents label19 As Label
    Private WithEvents edHLSEmbeddedHTTPServerPort As TextBox
    Private WithEvents cbHLSEmbeddedHTTPServerEnabled As CheckBox
    Private WithEvents pnChromaKeyColor As Panel
    Private WithEvents btChromaKeySelectBGImage As Button
    Private WithEvents edChromaKeyImage As TextBox
    Private WithEvents label216 As Label
    Private WithEvents label215 As Label
    Private WithEvents tbChromaKeySmoothing As TrackBar
    Private WithEvents label214 As Label
    Private WithEvents tbChromaKeyThresholdSensitivity As TrackBar
    Private WithEvents label213 As Label
    Private WithEvents cbChromaKeyEnabled As CheckBox
    Private WithEvents LinkLabel3 As LinkLabel
    Private WithEvents Label2 As Label
    Private WithEvents linkLabel7 As LinkLabel
    Private WithEvents lbNDI As LinkLabel
    Private WithEvents label25 As Label
    Friend WithEvents tpNDI As TabPage
    Private WithEvents label31 As Label
    Private WithEvents edNDIURL As TextBox
    Private WithEvents edNDIName As TextBox
    Private WithEvents label30 As Label
    Private WithEvents cbIPURL As ComboBox
    Private WithEvents btListNDISources As Button
    Private WithEvents linkLabel6 As LinkLabel
    Private WithEvents label38 As Label
    Private WithEvents edHLSURL As TextBox
End Class
