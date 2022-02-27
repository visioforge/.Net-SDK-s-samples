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

            mp4HWSettingsDialog?.Dispose()
            mp4HWSettingsDialog = Nothing

            mp4SettingsDialog?.Dispose()
            mp4SettingsDialog = Nothing

            mp3SettingsDialog?.Dispose()
            mp3SettingsDialog = Nothing

            m4aSettingsDialog?.Dispose()
            m4aSettingsDialog = Nothing

            gifSettingsDialog?.Dispose()
            gifSettingsDialog = Nothing

            flacSettingsDialog?.Dispose()
            flacSettingsDialog = Nothing

            ffmpegSettingsDialog?.Dispose()
            ffmpegSettingsDialog = Nothing

            ffmpegEXESettingsDialog?.Dispose()
            ffmpegEXESettingsDialog = Nothing

            dvSettingsDialog?.Dispose()
            dvSettingsDialog = Nothing

            aviSettingsDialog?.Dispose()
            aviSettingsDialog = Nothing

            customFormatSettingsDialog?.Dispose()
            customFormatSettingsDialog = Nothing

            wmvSettingsDialog?.Dispose()
            wmvSettingsDialog = Nothing

            webmSettingsDialog?.Dispose()
            webmSettingsDialog = Nothing

            speexSettingsDialog?.Dispose()
            speexSettingsDialog = Nothing

            pcmSettingsDialog?.Dispose()
            pcmSettingsDialog = Nothing

            oggVorbisSettingsDialog?.Dispose()
            oggVorbisSettingsDialog = Nothing

            VideoEdit1?.Dispose()
            VideoEdit1 = Nothing
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
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.OpenDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.label120 = New System.Windows.Forms.Label()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.rbPreview = New System.Windows.Forms.RadioButton()
        Me.rbConvert = New System.Windows.Forms.RadioButton()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.tabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.llXiphX64 = New System.Windows.Forms.LinkLabel()
        Me.llXiphX86 = New System.Windows.Forms.LinkLabel()
        Me.label68 = New System.Windows.Forms.Label()
        Me.label67 = New System.Windows.Forms.Label()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btConfigure = New System.Windows.Forms.Button()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.cbOutputVideoFormat = New System.Windows.Forms.ComboBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.tabPage30 = New System.Windows.Forms.TabPage()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.edCropRight = New System.Windows.Forms.TextBox()
        Me.label176 = New System.Windows.Forms.Label()
        Me.edCropBottom = New System.Windows.Forms.TextBox()
        Me.label252 = New System.Windows.Forms.Label()
        Me.edCropLeft = New System.Windows.Forms.TextBox()
        Me.label270 = New System.Windows.Forms.Label()
        Me.edCropTop = New System.Windows.Forms.TextBox()
        Me.label272 = New System.Windows.Forms.Label()
        Me.cbCrop = New System.Windows.Forms.CheckBox()
        Me.label92 = New System.Windows.Forms.Label()
        Me.cbRotate = New System.Windows.Forms.ComboBox()
        Me.cbFrameRate = New System.Windows.Forms.ComboBox()
        Me.edHeight = New System.Windows.Forms.TextBox()
        Me.edWidth = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cbResize = New System.Windows.Forms.CheckBox()
        Me.tabPage31 = New System.Windows.Forms.TabPage()
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
        Me.btTextLogoRemove = New System.Windows.Forms.Button()
        Me.btTextLogoEdit = New System.Windows.Forms.Button()
        Me.lbTextLogos = New System.Windows.Forms.ListBox()
        Me.btTextLogoAdd = New System.Windows.Forms.Button()
        Me.tabPage42 = New System.Windows.Forms.TabPage()
        Me.btImageLogoRemove = New System.Windows.Forms.Button()
        Me.btImageLogoEdit = New System.Windows.Forms.Button()
        Me.lbImageLogos = New System.Windows.Forms.ListBox()
        Me.btImageLogoAdd = New System.Windows.Forms.Button()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.groupBox37 = New System.Windows.Forms.GroupBox()
        Me.btEffZoomRight = New System.Windows.Forms.Button()
        Me.btEffZoomLeft = New System.Windows.Forms.Button()
        Me.btEffZoomOut = New System.Windows.Forms.Button()
        Me.btEffZoomIn = New System.Windows.Forms.Button()
        Me.btEffZoomDown = New System.Windows.Forms.Button()
        Me.btEffZoomUp = New System.Windows.Forms.Button()
        Me.cbZoom = New System.Windows.Forms.CheckBox()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
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
        Me.TabPage33 = New System.Windows.Forms.TabPage()
        Me.rbVideoFadeOut = New System.Windows.Forms.RadioButton()
        Me.rbVideoFadeIn = New System.Windows.Forms.RadioButton()
        Me.groupBox45 = New System.Windows.Forms.GroupBox()
        Me.edVideoFadeInOutStopTime = New System.Windows.Forms.TextBox()
        Me.label329 = New System.Windows.Forms.Label()
        Me.edVideoFadeInOutStartTime = New System.Windows.Forms.TextBox()
        Me.label330 = New System.Windows.Forms.Label()
        Me.cbVideoFadeInOut = New System.Windows.Forms.CheckBox()
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
        Me.tabPage59 = New System.Windows.Forms.TabPage()
        Me.rbDenoiseCAST = New System.Windows.Forms.RadioButton()
        Me.rbDenoiseMosquito = New System.Windows.Forms.RadioButton()
        Me.cbDenoise = New System.Windows.Forms.CheckBox()
        Me.TabPage82 = New System.Windows.Forms.TabPage()
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
        Me.TabPage20 = New System.Windows.Forms.TabPage()
        Me.tabControl15 = New System.Windows.Forms.TabControl()
        Me.TabPage26 = New System.Windows.Forms.TabPage()
        Me.label64 = New System.Windows.Forms.Label()
        Me.label65 = New System.Windows.Forms.Label()
        Me.pbAFMotionLevel = New System.Windows.Forms.ProgressBar()
        Me.cbAFMotionHighlight = New System.Windows.Forms.CheckBox()
        Me.cbAFMotionDetection = New System.Windows.Forms.CheckBox()
        Me.TabPage27 = New System.Windows.Forms.TabPage()
        Me.label171 = New System.Windows.Forms.Label()
        Me.label66 = New System.Windows.Forms.Label()
        Me.label16 = New System.Windows.Forms.Label()
        Me.TabPage21 = New System.Windows.Forms.TabPage()
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
        Me.TabPage81 = New System.Windows.Forms.TabPage()
        Me.label177 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btSubtitlesSelectFile = New System.Windows.Forms.Button()
        Me.edSubtitlesFilename = New System.Windows.Forms.TextBox()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.cbSubtitlesEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage9 = New System.Windows.Forms.TabPage()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.label47 = New System.Windows.Forms.Label()
        Me.edTransStopTime = New System.Windows.Forms.TextBox()
        Me.label48 = New System.Windows.Forms.Label()
        Me.label46 = New System.Windows.Forms.Label()
        Me.edTransStartTime = New System.Windows.Forms.TextBox()
        Me.label45 = New System.Windows.Forms.Label()
        Me.btAddTransition = New System.Windows.Forms.Button()
        Me.cbTransitionName = New System.Windows.Forms.ComboBox()
        Me.label44 = New System.Windows.Forms.Label()
        Me.lbTransitions = New System.Windows.Forms.ListBox()
        Me.label43 = New System.Windows.Forms.Label()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
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
        Me.TabPage57 = New System.Windows.Forms.TabPage()
        Me.lbAudioTimeshift = New System.Windows.Forms.Label()
        Me.tbAudioTimeshift = New System.Windows.Forms.TrackBar()
        Me.label115 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbAudioOutputGainLFE = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainLFE = New System.Windows.Forms.TrackBar()
        Me.label116 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainSR = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainSR = New System.Windows.Forms.TrackBar()
        Me.label117 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainSL = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainSL = New System.Windows.Forms.TrackBar()
        Me.label118 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainR = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainR = New System.Windows.Forms.TrackBar()
        Me.label119 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainC = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainC = New System.Windows.Forms.TrackBar()
        Me.label121 = New System.Windows.Forms.Label()
        Me.lbAudioOutputGainL = New System.Windows.Forms.Label()
        Me.tbAudioOutputGainL = New System.Windows.Forms.TrackBar()
        Me.label122 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbAudioInputGainLFE = New System.Windows.Forms.Label()
        Me.tbAudioInputGainLFE = New System.Windows.Forms.TrackBar()
        Me.label123 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainSR = New System.Windows.Forms.Label()
        Me.tbAudioInputGainSR = New System.Windows.Forms.TrackBar()
        Me.label124 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainSL = New System.Windows.Forms.Label()
        Me.tbAudioInputGainSL = New System.Windows.Forms.TrackBar()
        Me.label125 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainR = New System.Windows.Forms.Label()
        Me.tbAudioInputGainR = New System.Windows.Forms.TrackBar()
        Me.label126 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainC = New System.Windows.Forms.Label()
        Me.tbAudioInputGainC = New System.Windows.Forms.TrackBar()
        Me.label127 = New System.Windows.Forms.Label()
        Me.lbAudioInputGainL = New System.Windows.Forms.Label()
        Me.tbAudioInputGainL = New System.Windows.Forms.TrackBar()
        Me.label128 = New System.Windows.Forms.Label()
        Me.cbAudioAutoGain = New System.Windows.Forms.CheckBox()
        Me.cbAudioNormalize = New System.Windows.Forms.CheckBox()
        Me.cbAudioEnhancementEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage80 = New System.Windows.Forms.TabPage()
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
        Me.TabPage28 = New System.Windows.Forms.TabPage()
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
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.label393 = New System.Windows.Forms.Label()
        Me.cbDirect2DRotate = New System.Windows.Forms.ComboBox()
        Me.pnVideoRendererBGColor = New System.Windows.Forms.Panel()
        Me.label394 = New System.Windows.Forms.Label()
        Me.btFullScreen = New System.Windows.Forms.Button()
        Me.cbScreenFlipVertical = New System.Windows.Forms.CheckBox()
        Me.cbScreenFlipHorizontal = New System.Windows.Forms.CheckBox()
        Me.cbStretch = New System.Windows.Forms.CheckBox()
        Me.groupBox13 = New System.Windows.Forms.GroupBox()
        Me.rbDirect2D = New System.Windows.Forms.RadioButton()
        Me.rbNone = New System.Windows.Forms.RadioButton()
        Me.rbEVR = New System.Windows.Forms.RadioButton()
        Me.rbVMR9 = New System.Windows.Forms.RadioButton()
        Me.rbVR = New System.Windows.Forms.RadioButton()
        Me.TabPage23 = New System.Windows.Forms.TabPage()
        Me.edBarcodeMetadata = New System.Windows.Forms.TextBox()
        Me.label91 = New System.Windows.Forms.Label()
        Me.cbBarcodeType = New System.Windows.Forms.ComboBox()
        Me.label90 = New System.Windows.Forms.Label()
        Me.btBarcodeReset = New System.Windows.Forms.Button()
        Me.edBarcode = New System.Windows.Forms.TextBox()
        Me.label89 = New System.Windows.Forms.Label()
        Me.cbBarcodeDetectionEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage24 = New System.Windows.Forms.TabPage()
        Me.cbNetworkStreamingMode = New System.Windows.Forms.ComboBox()
        Me.tabControl5 = New System.Windows.Forms.TabControl()
        Me.TabPage25 = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.edNetworkURL = New System.Windows.Forms.TextBox()
        Me.edWMVNetworkPort = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btRefreshClients = New System.Windows.Forms.Button()
        Me.lbNetworkClients = New System.Windows.Forms.ListBox()
        Me.rbNetworkStreamingUseExternalProfile = New System.Windows.Forms.RadioButton()
        Me.rbNetworkStreamingUseMainWMVSettings = New System.Windows.Forms.RadioButton()
        Me.label81 = New System.Windows.Forms.Label()
        Me.label80 = New System.Windows.Forms.Label()
        Me.edMaximumClients = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btSelectWMVProfileNetwork = New System.Windows.Forms.Button()
        Me.edNetworkStreamingWMVProfile = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage47 = New System.Windows.Forms.TabPage()
        Me.edNetworkRTSPURL = New System.Windows.Forms.TextBox()
        Me.label367 = New System.Windows.Forms.Label()
        Me.label366 = New System.Windows.Forms.Label()
        Me.TabPage48 = New System.Windows.Forms.TabPage()
        Me.linkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.rbNetworkRTMPFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkRTMPFFMPEG = New System.Windows.Forms.RadioButton()
        Me.edNetworkRTMPURL = New System.Windows.Forms.TextBox()
        Me.label368 = New System.Windows.Forms.Label()
        Me.label369 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.edNDIURL = New System.Windows.Forms.TextBox()
        Me.edNDIName = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.TabPage67 = New System.Windows.Forms.TabPage()
        Me.label63 = New System.Windows.Forms.Label()
        Me.label62 = New System.Windows.Forms.Label()
        Me.label314 = New System.Windows.Forms.Label()
        Me.label313 = New System.Windows.Forms.Label()
        Me.edNetworkUDPURL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.label484 = New System.Windows.Forms.Label()
        Me.rbNetworkUDPFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkUDPFFMPEG = New System.Windows.Forms.RadioButton()
        Me.TabPage49 = New System.Windows.Forms.TabPage()
        Me.rbNetworkSSFFMPEGCustom = New System.Windows.Forms.RadioButton()
        Me.rbNetworkSSFFMPEGDefault = New System.Windows.Forms.RadioButton()
        Me.linkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.edNetworkSSURL = New System.Windows.Forms.TextBox()
        Me.label370 = New System.Windows.Forms.Label()
        Me.label371 = New System.Windows.Forms.Label()
        Me.rbNetworkSSSoftware = New System.Windows.Forms.RadioButton()
        Me.TabPage56 = New System.Windows.Forms.TabPage()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.cbNetworkStreamingAudioEnabled = New System.Windows.Forms.CheckBox()
        Me.cbNetworkStreaming = New System.Windows.Forms.CheckBox()
        Me.TabPage32 = New System.Windows.Forms.TabPage()
        Me.label328 = New System.Windows.Forms.Label()
        Me.label327 = New System.Windows.Forms.Label()
        Me.label326 = New System.Windows.Forms.Label()
        Me.label325 = New System.Windows.Forms.Label()
        Me.cbVirtualCamera = New System.Windows.Forms.CheckBox()
        Me.TabPage34 = New System.Windows.Forms.TabPage()
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
        Me.TabPage43 = New System.Windows.Forms.TabPage()
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
        Me.TabPage78 = New System.Windows.Forms.TabPage()
        Me.TabControl32 = New System.Windows.Forms.TabControl()
        Me.cbTagEnabled = New System.Windows.Forms.CheckBox()
        Me.TabPage22 = New System.Windows.Forms.TabPage()
        Me.tbVUMeterBoost = New System.Windows.Forms.TrackBar()
        Me.label382 = New System.Windows.Forms.Label()
        Me.label381 = New System.Windows.Forms.Label()
        Me.tbVUMeterAmplification = New System.Windows.Forms.TrackBar()
        Me.cbVUMeterPro = New System.Windows.Forms.CheckBox()
        Me.waveformPainter2 = New VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter()
        Me.waveformPainter1 = New VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter()
        Me.volumeMeter2 = New VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter()
        Me.volumeMeter1 = New VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter()
        Me.peakMeterCtrl1 = New VisioForge.Core.UI.WinForms.PeakMeterCtrl()
        Me.cbVUMeter = New System.Windows.Forms.CheckBox()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.tbSeeking = New System.Windows.Forms.TrackBar()
        Me.openFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabControl3 = New System.Windows.Forms.TabControl()
        Me.tabPage52 = New System.Windows.Forms.TabPage()
        Me.groupBox7 = New System.Windows.Forms.GroupBox()
        Me.label72 = New System.Windows.Forms.Label()
        Me.edInsertTime = New System.Windows.Forms.TextBox()
        Me.label73 = New System.Windows.Forms.Label()
        Me.cbInsertAfterPreviousFile = New System.Windows.Forms.CheckBox()
        Me.label50 = New System.Windows.Forms.Label()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.lbSpeed = New System.Windows.Forms.Label()
        Me.label42 = New System.Windows.Forms.Label()
        Me.label37 = New System.Windows.Forms.Label()
        Me.edStopTime = New System.Windows.Forms.TextBox()
        Me.label38 = New System.Windows.Forms.Label()
        Me.label36 = New System.Windows.Forms.Label()
        Me.edStartTime = New System.Windows.Forms.TextBox()
        Me.label35 = New System.Windows.Forms.Label()
        Me.cbAddFullFile = New System.Windows.Forms.CheckBox()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.btClearList = New System.Windows.Forms.Button()
        Me.btAddInputFile = New System.Windows.Forms.Button()
        Me.lbFiles = New System.Windows.Forms.ListBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.tabPage53 = New System.Windows.Forms.TabPage()
        Me.label134 = New System.Windows.Forms.Label()
        Me.btSelectOutputCut = New System.Windows.Forms.Button()
        Me.edOutputFileCut = New System.Windows.Forms.TextBox()
        Me.label131 = New System.Windows.Forms.Label()
        Me.btStopCut = New System.Windows.Forms.Button()
        Me.btStartCut = New System.Windows.Forms.Button()
        Me.label31 = New System.Windows.Forms.Label()
        Me.btAddInputFile2 = New System.Windows.Forms.Button()
        Me.edSourceFileToCut = New System.Windows.Forms.TextBox()
        Me.label30 = New System.Windows.Forms.Label()
        Me.label26 = New System.Windows.Forms.Label()
        Me.edStopTimeCut = New System.Windows.Forms.TextBox()
        Me.label27 = New System.Windows.Forms.Label()
        Me.label28 = New System.Windows.Forms.Label()
        Me.edStartTimeCut = New System.Windows.Forms.TextBox()
        Me.label29 = New System.Windows.Forms.Label()
        Me.tabPage54 = New System.Windows.Forms.TabPage()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btSelectOutputJoin = New System.Windows.Forms.Button()
        Me.edOutputFileJoin = New System.Windows.Forms.TextBox()
        Me.label132 = New System.Windows.Forms.Label()
        Me.btStopJoin = New System.Windows.Forms.Button()
        Me.btStartJoin = New System.Windows.Forms.Button()
        Me.btClearList3 = New System.Windows.Forms.Button()
        Me.btAddInputFile3 = New System.Windows.Forms.Button()
        Me.lbFiles2 = New System.Windows.Forms.ListBox()
        Me.label32 = New System.Windows.Forms.Label()
        Me.TabPage74 = New System.Windows.Forms.TabPage()
        Me.label168 = New System.Windows.Forms.Label()
        Me.cbMuxStreamsShortest = New System.Windows.Forms.CheckBox()
        Me.cbMuxStreamsType = New System.Windows.Forms.ComboBox()
        Me.btMuxStreamsSelectFile = New System.Windows.Forms.Button()
        Me.edMuxStreamsSourceFile = New System.Windows.Forms.TextBox()
        Me.label167 = New System.Windows.Forms.Label()
        Me.btMuxStreamsSelectOutput = New System.Windows.Forms.Button()
        Me.edMuxStreamsOutputFile = New System.Windows.Forms.TextBox()
        Me.label165 = New System.Windows.Forms.Label()
        Me.btStopMux = New System.Windows.Forms.Button()
        Me.btStartMux = New System.Windows.Forms.Button()
        Me.btMuxStreamsClear = New System.Windows.Forms.Button()
        Me.btMuxStreamsAdd = New System.Windows.Forms.Button()
        Me.lbMuxStreamsList = New System.Windows.Forms.ListBox()
        Me.label166 = New System.Windows.Forms.Label()
        Me.cbLicensing = New System.Windows.Forms.CheckBox()
        Me.openFileDialogSubtitles = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage143 = New System.Windows.Forms.TabPage()
        Me.Label492 = New System.Windows.Forms.Label()
        Me.edTagComposers = New System.Windows.Forms.TextBox()
        Me.Label494 = New System.Windows.Forms.Label()
        Me.cbTagGenre = New System.Windows.Forms.ComboBox()
        Me.Label497 = New System.Windows.Forms.Label()
        Me.edTagLyrics = New System.Windows.Forms.TextBox()
        Me.Label498 = New System.Windows.Forms.Label()
        Me.Label499 = New System.Windows.Forms.Label()
        Me.imgTagCover = New System.Windows.Forms.PictureBox()
        Me.TabPage142 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.edTagTitle = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.edTagCopyright = New System.Windows.Forms.TextBox()
        Me.Label490 = New System.Windows.Forms.Label()
        Me.edTagArtists = New System.Windows.Forms.TextBox()
        Me.Label491 = New System.Windows.Forms.Label()
        Me.edTagAlbum = New System.Windows.Forms.TextBox()
        Me.Label493 = New System.Windows.Forms.Label()
        Me.edTagComment = New System.Windows.Forms.TextBox()
        Me.Label495 = New System.Windows.Forms.Label()
        Me.edTagYear = New System.Windows.Forms.TextBox()
        Me.Label496 = New System.Windows.Forms.Label()
        Me.edTagTrackID = New System.Windows.Forms.TextBox()
        Me.cbTelemetry = New System.Windows.Forms.CheckBox()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.tabPage30.SuspendLayout()
        Me.tabPage31.SuspendLayout()
        Me.tabControl17.SuspendLayout()
        Me.tabPage68.SuspendLayout()
        Me.tabControl7.SuspendLayout()
        Me.tabPage29.SuspendLayout()
        Me.tabPage42.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.groupBox37.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        Me.groupBox40.SuspendLayout()
        Me.groupBox39.SuspendLayout()
        Me.groupBox38.SuspendLayout()
        Me.TabPage33.SuspendLayout()
        Me.groupBox45.SuspendLayout()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDarkness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage69.SuspendLayout()
        Me.tabPage59.SuspendLayout()
        Me.TabPage82.SuspendLayout()
        CType(Me.tbGPUBlur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGPUContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGPUDarkness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGPULightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGPUSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage20.SuspendLayout()
        Me.tabControl15.SuspendLayout()
        Me.TabPage26.SuspendLayout()
        Me.TabPage27.SuspendLayout()
        Me.TabPage21.SuspendLayout()
        CType(Me.tbChromaKeySmoothing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbChromaKeyThresholdSensitivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage70.SuspendLayout()
        Me.TabPage81.SuspendLayout()
        Me.tabPage9.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tabControl18.SuspendLayout()
        Me.tabPage71.SuspendLayout()
        CType(Me.tbAudAmplifyAmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage72.SuspendLayout()
        CType(Me.tbAudEq9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage73.SuspendLayout()
        CType(Me.tbAudRelease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudAttack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudDynAmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage75.SuspendLayout()
        CType(Me.tbAud3DSound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage76.SuspendLayout()
        CType(Me.tbAudTrueBass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage57.SuspendLayout()
        CType(Me.tbAudioTimeshift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.tbAudioOutputGainLFE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioOutputGainSR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioOutputGainSL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioOutputGainR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioOutputGainC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioOutputGainL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        CType(Me.tbAudioInputGainLFE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioInputGainSR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioInputGainSL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioInputGainR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioInputGainC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioInputGainL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage80.SuspendLayout()
        Me.groupBox41.SuspendLayout()
        CType(Me.tbAudioChannelMapperVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage28.SuspendLayout()
        Me.tabControl9.SuspendLayout()
        Me.tabPage44.SuspendLayout()
        Me.tabPage45.SuspendLayout()
        Me.groupBox25.SuspendLayout()
        CType(Me.tbMotDetHLThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox27.SuspendLayout()
        Me.groupBox26.SuspendLayout()
        CType(Me.tbMotDetDropFramesThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox24.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox13.SuspendLayout()
        Me.TabPage23.SuspendLayout()
        Me.TabPage24.SuspendLayout()
        Me.tabControl5.SuspendLayout()
        Me.TabPage25.SuspendLayout()
        Me.TabPage47.SuspendLayout()
        Me.TabPage48.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage67.SuspendLayout()
        Me.TabPage49.SuspendLayout()
        Me.TabPage56.SuspendLayout()
        Me.TabPage32.SuspendLayout()
        Me.TabPage34.SuspendLayout()
        Me.TabPage43.SuspendLayout()
        Me.groupBox48.SuspendLayout()
        Me.groupBox47.SuspendLayout()
        Me.groupBox43.SuspendLayout()
        Me.TabPage78.SuspendLayout()
        Me.TabPage22.SuspendLayout()
        CType(Me.tbVUMeterBoost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVUMeterAmplification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSeeking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl3.SuspendLayout()
        Me.tabPage52.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage53.SuspendLayout()
        Me.tabPage54.SuspendLayout()
        Me.TabPage74.SuspendLayout()
        CType(Me.imgTagCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.Color.White
        Me.FontDialog1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FontDialog1.ShowColor = True
        '
        'OpenDialog1
        '
        Me.OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter")
        '
        'SaveDialog1
        '
        Me.SaveDialog1.Filter = "AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|" &
    "All files  (*.*)| *.*"
        '
        'openFileDialog2
        '
        Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
        '
        'mmLog
        '
        Me.mmLog.Location = New System.Drawing.Point(11, 568)
        Me.mmLog.Multiline = True
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(310, 57)
        Me.mmLog.TabIndex = 76
        '
        'label120
        '
        Me.label120.AutoSize = True
        Me.label120.Location = New System.Drawing.Point(8, 552)
        Me.label120.Name = "label120"
        Me.label120.Size = New System.Drawing.Size(100, 13)
        Me.label120.TabIndex = 75
        Me.label120.Text = "Errors and warnings"
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(149, 524)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 74
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(80, 523)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(63, 17)
        Me.rbPreview.TabIndex = 73
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'rbConvert
        '
        Me.rbConvert.AutoSize = True
        Me.rbConvert.Location = New System.Drawing.Point(11, 523)
        Me.rbConvert.Name = "rbConvert"
        Me.rbConvert.Size = New System.Drawing.Size(62, 17)
        Me.rbConvert.TabIndex = 72
        Me.rbConvert.Text = "Convert"
        Me.rbConvert.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage31)
        Me.tabControl1.Controls.Add(Me.tabPage9)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.TabPage57)
        Me.tabControl1.Controls.Add(Me.TabPage80)
        Me.tabControl1.Controls.Add(Me.TabPage28)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.TabPage23)
        Me.tabControl1.Controls.Add(Me.TabPage24)
        Me.tabControl1.Controls.Add(Me.TabPage32)
        Me.tabControl1.Controls.Add(Me.TabPage34)
        Me.tabControl1.Controls.Add(Me.TabPage43)
        Me.tabControl1.Controls.Add(Me.TabPage78)
        Me.tabControl1.Controls.Add(Me.TabPage22)
        Me.tabControl1.Location = New System.Drawing.Point(11, 12)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(310, 500)
        Me.tabControl1.TabIndex = 71
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.tabControl2)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(302, 474)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Output"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'tabControl2
        '
        Me.tabControl2.Controls.Add(Me.TabPage4)
        Me.tabControl2.Controls.Add(Me.tabPage30)
        Me.tabControl2.Location = New System.Drawing.Point(4, 6)
        Me.tabControl2.Name = "tabControl2"
        Me.tabControl2.SelectedIndex = 0
        Me.tabControl2.Size = New System.Drawing.Size(292, 464)
        Me.tabControl2.TabIndex = 10
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.llXiphX64)
        Me.TabPage4.Controls.Add(Me.llXiphX86)
        Me.TabPage4.Controls.Add(Me.label68)
        Me.TabPage4.Controls.Add(Me.label67)
        Me.TabPage4.Controls.Add(Me.lbInfo)
        Me.TabPage4.Controls.Add(Me.btConfigure)
        Me.TabPage4.Controls.Add(Me.btSelectOutput)
        Me.TabPage4.Controls.Add(Me.edOutput)
        Me.TabPage4.Controls.Add(Me.label15)
        Me.TabPage4.Controls.Add(Me.cbOutputVideoFormat)
        Me.TabPage4.Controls.Add(Me.label9)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Size = New System.Drawing.Size(284, 438)
        Me.TabPage4.TabIndex = 7
        Me.TabPage4.Text = "Main"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'llXiphX64
        '
        Me.llXiphX64.AutoSize = True
        Me.llXiphX64.Location = New System.Drawing.Point(155, 224)
        Me.llXiphX64.Name = "llXiphX64"
        Me.llXiphX64.Size = New System.Drawing.Size(24, 13)
        Me.llXiphX64.TabIndex = 63
        Me.llXiphX64.TabStop = True
        Me.llXiphX64.Text = "x64"
        '
        'llXiphX86
        '
        Me.llXiphX86.AutoSize = True
        Me.llXiphX86.Location = New System.Drawing.Point(125, 224)
        Me.llXiphX86.Name = "llXiphX86"
        Me.llXiphX86.Size = New System.Drawing.Size(24, 13)
        Me.llXiphX86.TabIndex = 62
        Me.llXiphX86.TabStop = True
        Me.llXiphX86.Text = "x86"
        '
        'label68
        '
        Me.label68.AutoSize = True
        Me.label68.Location = New System.Drawing.Point(6, 224)
        Me.label68.Name = "label68"
        Me.label68.Size = New System.Drawing.Size(113, 13)
        Me.label68.TabIndex = 61
        Me.label68.Text = "and Ogg Vorbis output"
        '
        'label67
        '
        Me.label67.AutoSize = True
        Me.label67.Location = New System.Drawing.Point(6, 202)
        Me.label67.Name = "label67"
        Me.label67.Size = New System.Drawing.Size(273, 13)
        Me.label67.TabIndex = 60
        Me.label67.Text = "Additional redist required to be installed for FLAC, Speex,"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Location = New System.Drawing.Point(10, 61)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(267, 13)
        Me.lbInfo.TabIndex = 59
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btConfigure
        '
        Me.btConfigure.Location = New System.Drawing.Point(13, 82)
        Me.btConfigure.Name = "btConfigure"
        Me.btConfigure.Size = New System.Drawing.Size(61, 22)
        Me.btConfigure.TabIndex = 58
        Me.btConfigure.Text = "Configure"
        Me.btConfigure.UseVisualStyleBackColor = True
        '
        'btSelectOutput
        '
        Me.btSelectOutput.Location = New System.Drawing.Point(246, 144)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(26, 22)
        Me.btSelectOutput.TabIndex = 57
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = True
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(13, 146)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(227, 20)
        Me.edOutput.TabIndex = 56
        Me.edOutput.Text = "c:\vf\video_edit_output.avi"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(10, 130)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(52, 13)
        Me.label15.TabIndex = 55
        Me.label15.Text = "File name"
        '
        'cbOutputVideoFormat
        '
        Me.cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputVideoFormat.FormattingEnabled = True
        Me.cbOutputVideoFormat.Items.AddRange(New Object() {"AVI", "MKV (Matroska)", "WMV", "DV", "PCM/ACM", "MP3", "M4A (AAC)", "WMA (Windows Media Audio)", "Ogg Vorbis", "FLAC", "Speex", "Custom format", "WebM", "FFMPEG", "FFMPEG (external exe)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video"})
        Me.cbOutputVideoFormat.Location = New System.Drawing.Point(13, 32)
        Me.cbOutputVideoFormat.Name = "cbOutputVideoFormat"
        Me.cbOutputVideoFormat.Size = New System.Drawing.Size(259, 21)
        Me.cbOutputVideoFormat.TabIndex = 54
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(10, 15)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(39, 13)
        Me.label9.TabIndex = 53
        Me.label9.Text = "Format"
        '
        'tabPage30
        '
        Me.tabPage30.Controls.Add(Me.Label114)
        Me.tabPage30.Controls.Add(Me.edCropRight)
        Me.tabPage30.Controls.Add(Me.label176)
        Me.tabPage30.Controls.Add(Me.edCropBottom)
        Me.tabPage30.Controls.Add(Me.label252)
        Me.tabPage30.Controls.Add(Me.edCropLeft)
        Me.tabPage30.Controls.Add(Me.label270)
        Me.tabPage30.Controls.Add(Me.edCropTop)
        Me.tabPage30.Controls.Add(Me.label272)
        Me.tabPage30.Controls.Add(Me.cbCrop)
        Me.tabPage30.Controls.Add(Me.label92)
        Me.tabPage30.Controls.Add(Me.cbRotate)
        Me.tabPage30.Controls.Add(Me.cbFrameRate)
        Me.tabPage30.Controls.Add(Me.edHeight)
        Me.tabPage30.Controls.Add(Me.edWidth)
        Me.tabPage30.Controls.Add(Me.label2)
        Me.tabPage30.Controls.Add(Me.cbResize)
        Me.tabPage30.Location = New System.Drawing.Point(4, 22)
        Me.tabPage30.Name = "tabPage30"
        Me.tabPage30.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage30.Size = New System.Drawing.Size(284, 438)
        Me.tabPage30.TabIndex = 6
        Me.tabPage30.Text = "Resolution / frame rate"
        Me.tabPage30.UseVisualStyleBackColor = True
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Location = New System.Drawing.Point(8, 50)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(278, 13)
        Me.Label114.TabIndex = 167
        Me.Label114.Text = "Frame rate (Use 0 to have original, set before adding files)"
        '
        'edCropRight
        '
        Me.edCropRight.Location = New System.Drawing.Point(179, 219)
        Me.edCropRight.Name = "edCropRight"
        Me.edCropRight.Size = New System.Drawing.Size(36, 20)
        Me.edCropRight.TabIndex = 166
        Me.edCropRight.Text = "0"
        '
        'label176
        '
        Me.label176.AutoSize = True
        Me.label176.Location = New System.Drawing.Point(138, 223)
        Me.label176.Name = "label176"
        Me.label176.Size = New System.Drawing.Size(32, 13)
        Me.label176.TabIndex = 165
        Me.label176.Text = "Right"
        '
        'edCropBottom
        '
        Me.edCropBottom.Location = New System.Drawing.Point(84, 219)
        Me.edCropBottom.Name = "edCropBottom"
        Me.edCropBottom.Size = New System.Drawing.Size(36, 20)
        Me.edCropBottom.TabIndex = 164
        Me.edCropBottom.Text = "0"
        '
        'label252
        '
        Me.label252.AutoSize = True
        Me.label252.Location = New System.Drawing.Point(38, 223)
        Me.label252.Name = "label252"
        Me.label252.Size = New System.Drawing.Size(40, 13)
        Me.label252.TabIndex = 163
        Me.label252.Text = "Bottom"
        '
        'edCropLeft
        '
        Me.edCropLeft.Location = New System.Drawing.Point(179, 194)
        Me.edCropLeft.Name = "edCropLeft"
        Me.edCropLeft.Size = New System.Drawing.Size(36, 20)
        Me.edCropLeft.TabIndex = 162
        Me.edCropLeft.Text = "0"
        '
        'label270
        '
        Me.label270.AutoSize = True
        Me.label270.Location = New System.Drawing.Point(138, 198)
        Me.label270.Name = "label270"
        Me.label270.Size = New System.Drawing.Size(25, 13)
        Me.label270.TabIndex = 161
        Me.label270.Text = "Left"
        '
        'edCropTop
        '
        Me.edCropTop.Location = New System.Drawing.Point(84, 194)
        Me.edCropTop.Name = "edCropTop"
        Me.edCropTop.Size = New System.Drawing.Size(36, 20)
        Me.edCropTop.TabIndex = 160
        Me.edCropTop.Text = "0"
        '
        'label272
        '
        Me.label272.AutoSize = True
        Me.label272.Location = New System.Drawing.Point(38, 198)
        Me.label272.Name = "label272"
        Me.label272.Size = New System.Drawing.Size(26, 13)
        Me.label272.TabIndex = 159
        Me.label272.Text = "Top"
        '
        'cbCrop
        '
        Me.cbCrop.AutoSize = True
        Me.cbCrop.Location = New System.Drawing.Point(11, 173)
        Me.cbCrop.Name = "cbCrop"
        Me.cbCrop.Size = New System.Drawing.Size(48, 17)
        Me.cbCrop.TabIndex = 158
        Me.cbCrop.Text = "Crop"
        Me.cbCrop.UseVisualStyleBackColor = True
        '
        'label92
        '
        Me.label92.AutoSize = True
        Me.label92.Location = New System.Drawing.Point(8, 149)
        Me.label92.Name = "label92"
        Me.label92.Size = New System.Drawing.Size(39, 13)
        Me.label92.TabIndex = 143
        Me.label92.Text = "Rotate"
        '
        'cbRotate
        '
        Me.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRotate.FormattingEnabled = True
        Me.cbRotate.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.cbRotate.Location = New System.Drawing.Point(84, 146)
        Me.cbRotate.Name = "cbRotate"
        Me.cbRotate.Size = New System.Drawing.Size(120, 21)
        Me.cbRotate.TabIndex = 142
        '
        'cbFrameRate
        '
        Me.cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFrameRate.FormattingEnabled = True
        Me.cbFrameRate.Items.AddRange(New Object() {"0", "1", "2", "5", "10", "12", "15", "20", "25", "30"})
        Me.cbFrameRate.Location = New System.Drawing.Point(11, 66)
        Me.cbFrameRate.Name = "cbFrameRate"
        Me.cbFrameRate.Size = New System.Drawing.Size(48, 21)
        Me.cbFrameRate.TabIndex = 45
        '
        'edHeight
        '
        Me.edHeight.Location = New System.Drawing.Point(156, 18)
        Me.edHeight.Name = "edHeight"
        Me.edHeight.Size = New System.Drawing.Size(48, 20)
        Me.edHeight.TabIndex = 43
        Me.edHeight.Text = "576"
        '
        'edWidth
        '
        Me.edWidth.Location = New System.Drawing.Point(84, 18)
        Me.edWidth.Name = "edWidth"
        Me.edWidth.Size = New System.Drawing.Size(48, 20)
        Me.edWidth.TabIndex = 42
        Me.edWidth.Text = "768"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(138, 20)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(12, 13)
        Me.label2.TabIndex = 41
        Me.label2.Text = "x"
        '
        'cbResize
        '
        Me.cbResize.AutoSize = True
        Me.cbResize.Location = New System.Drawing.Point(11, 20)
        Me.cbResize.Name = "cbResize"
        Me.cbResize.Size = New System.Drawing.Size(58, 17)
        Me.cbResize.TabIndex = 40
        Me.cbResize.Text = "Resize"
        Me.cbResize.UseVisualStyleBackColor = True
        '
        'tabPage31
        '
        Me.tabPage31.Controls.Add(Me.tabControl17)
        Me.tabPage31.Location = New System.Drawing.Point(4, 22)
        Me.tabPage31.Name = "tabPage31"
        Me.tabPage31.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage31.Size = New System.Drawing.Size(302, 474)
        Me.tabPage31.TabIndex = 4
        Me.tabPage31.Text = "Video processing"
        Me.tabPage31.UseVisualStyleBackColor = True
        '
        'tabControl17
        '
        Me.tabControl17.Controls.Add(Me.tabPage68)
        Me.tabControl17.Controls.Add(Me.tabPage69)
        Me.tabControl17.Controls.Add(Me.tabPage59)
        Me.tabControl17.Controls.Add(Me.TabPage82)
        Me.tabControl17.Controls.Add(Me.TabPage20)
        Me.tabControl17.Controls.Add(Me.TabPage21)
        Me.tabControl17.Controls.Add(Me.tabPage70)
        Me.tabControl17.Controls.Add(Me.TabPage81)
        Me.tabControl17.Location = New System.Drawing.Point(1, 6)
        Me.tabControl17.Name = "tabControl17"
        Me.tabControl17.SelectedIndex = 0
        Me.tabControl17.Size = New System.Drawing.Size(298, 466)
        Me.tabControl17.TabIndex = 37
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
        Me.tabPage68.Size = New System.Drawing.Size(290, 440)
        Me.tabPage68.TabIndex = 0
        Me.tabPage68.Text = "Effects"
        Me.tabPage68.UseVisualStyleBackColor = True
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = True
        Me.cbFlipY.Location = New System.Drawing.Point(210, 150)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipY.TabIndex = 71
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = True
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = True
        Me.cbFlipX.Location = New System.Drawing.Point(150, 150)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(52, 17)
        Me.cbFlipX.TabIndex = 70
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = True
        '
        'label201
        '
        Me.label201.AutoSize = True
        Me.label201.Location = New System.Drawing.Point(142, 84)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(52, 13)
        Me.label201.TabIndex = 63
        Me.label201.Text = "Darkness"
        '
        'label200
        '
        Me.label200.AutoSize = True
        Me.label200.Location = New System.Drawing.Point(6, 84)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(46, 13)
        Me.label200.TabIndex = 62
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = True
        Me.label199.Location = New System.Drawing.Point(142, 34)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(55, 13)
        Me.label199.TabIndex = 61
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = True
        Me.label198.Location = New System.Drawing.Point(6, 34)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(52, 13)
        Me.label198.TabIndex = 60
        Me.label198.Text = "Lightness"
        '
        'tabControl7
        '
        Me.tabControl7.Controls.Add(Me.tabPage29)
        Me.tabControl7.Controls.Add(Me.tabPage42)
        Me.tabControl7.Controls.Add(Me.TabPage7)
        Me.tabControl7.Controls.Add(Me.TabPage16)
        Me.tabControl7.Controls.Add(Me.TabPage33)
        Me.tabControl7.Location = New System.Drawing.Point(3, 178)
        Me.tabControl7.Name = "tabControl7"
        Me.tabControl7.SelectedIndex = 0
        Me.tabControl7.Size = New System.Drawing.Size(283, 264)
        Me.tabControl7.TabIndex = 59
        '
        'tabPage29
        '
        Me.tabPage29.Controls.Add(Me.btTextLogoRemove)
        Me.tabPage29.Controls.Add(Me.btTextLogoEdit)
        Me.tabPage29.Controls.Add(Me.lbTextLogos)
        Me.tabPage29.Controls.Add(Me.btTextLogoAdd)
        Me.tabPage29.Location = New System.Drawing.Point(4, 22)
        Me.tabPage29.Name = "tabPage29"
        Me.tabPage29.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage29.Size = New System.Drawing.Size(275, 238)
        Me.tabPage29.TabIndex = 0
        Me.tabPage29.Text = "Text logo"
        Me.tabPage29.UseVisualStyleBackColor = True
        '
        'btTextLogoRemove
        '
        Me.btTextLogoRemove.Location = New System.Drawing.Point(208, 207)
        Me.btTextLogoRemove.Name = "btTextLogoRemove"
        Me.btTextLogoRemove.Size = New System.Drawing.Size(59, 22)
        Me.btTextLogoRemove.TabIndex = 11
        Me.btTextLogoRemove.Text = "Remove"
        Me.btTextLogoRemove.UseVisualStyleBackColor = True
        '
        'btTextLogoEdit
        '
        Me.btTextLogoEdit.Location = New System.Drawing.Point(74, 207)
        Me.btTextLogoEdit.Name = "btTextLogoEdit"
        Me.btTextLogoEdit.Size = New System.Drawing.Size(59, 22)
        Me.btTextLogoEdit.TabIndex = 10
        Me.btTextLogoEdit.Text = "Edit"
        Me.btTextLogoEdit.UseVisualStyleBackColor = True
        '
        'lbTextLogos
        '
        Me.lbTextLogos.FormattingEnabled = True
        Me.lbTextLogos.Location = New System.Drawing.Point(10, 12)
        Me.lbTextLogos.Name = "lbTextLogos"
        Me.lbTextLogos.Size = New System.Drawing.Size(257, 186)
        Me.lbTextLogos.TabIndex = 9
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(8, 207)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(59, 22)
        Me.btTextLogoAdd.TabIndex = 8
        Me.btTextLogoAdd.Text = "Add"
        Me.btTextLogoAdd.UseVisualStyleBackColor = True
        '
        'tabPage42
        '
        Me.tabPage42.Controls.Add(Me.btImageLogoRemove)
        Me.tabPage42.Controls.Add(Me.btImageLogoEdit)
        Me.tabPage42.Controls.Add(Me.lbImageLogos)
        Me.tabPage42.Controls.Add(Me.btImageLogoAdd)
        Me.tabPage42.Location = New System.Drawing.Point(4, 22)
        Me.tabPage42.Name = "tabPage42"
        Me.tabPage42.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage42.Size = New System.Drawing.Size(275, 238)
        Me.tabPage42.TabIndex = 1
        Me.tabPage42.Text = "Image logo"
        Me.tabPage42.UseVisualStyleBackColor = True
        '
        'btImageLogoRemove
        '
        Me.btImageLogoRemove.Location = New System.Drawing.Point(208, 207)
        Me.btImageLogoRemove.Name = "btImageLogoRemove"
        Me.btImageLogoRemove.Size = New System.Drawing.Size(59, 22)
        Me.btImageLogoRemove.TabIndex = 15
        Me.btImageLogoRemove.Text = "Remove"
        Me.btImageLogoRemove.UseVisualStyleBackColor = True
        '
        'btImageLogoEdit
        '
        Me.btImageLogoEdit.Location = New System.Drawing.Point(74, 207)
        Me.btImageLogoEdit.Name = "btImageLogoEdit"
        Me.btImageLogoEdit.Size = New System.Drawing.Size(59, 22)
        Me.btImageLogoEdit.TabIndex = 14
        Me.btImageLogoEdit.Text = "Edit"
        Me.btImageLogoEdit.UseVisualStyleBackColor = True
        '
        'lbImageLogos
        '
        Me.lbImageLogos.FormattingEnabled = True
        Me.lbImageLogos.Location = New System.Drawing.Point(10, 12)
        Me.lbImageLogos.Name = "lbImageLogos"
        Me.lbImageLogos.Size = New System.Drawing.Size(257, 186)
        Me.lbImageLogos.TabIndex = 13
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(8, 207)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(59, 22)
        Me.btImageLogoAdd.TabIndex = 12
        Me.btImageLogoAdd.Text = "Add"
        Me.btImageLogoAdd.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.groupBox37)
        Me.TabPage7.Controls.Add(Me.cbZoom)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage7.Size = New System.Drawing.Size(275, 238)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "Zoom"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'groupBox37
        '
        Me.groupBox37.Controls.Add(Me.btEffZoomRight)
        Me.groupBox37.Controls.Add(Me.btEffZoomLeft)
        Me.groupBox37.Controls.Add(Me.btEffZoomOut)
        Me.groupBox37.Controls.Add(Me.btEffZoomIn)
        Me.groupBox37.Controls.Add(Me.btEffZoomDown)
        Me.groupBox37.Controls.Add(Me.btEffZoomUp)
        Me.groupBox37.Location = New System.Drawing.Point(86, 48)
        Me.groupBox37.Name = "groupBox37"
        Me.groupBox37.Size = New System.Drawing.Size(119, 100)
        Me.groupBox37.TabIndex = 20
        Me.groupBox37.TabStop = False
        Me.groupBox37.Text = "Zoom"
        '
        'btEffZoomRight
        '
        Me.btEffZoomRight.Location = New System.Drawing.Point(85, 32)
        Me.btEffZoomRight.Name = "btEffZoomRight"
        Me.btEffZoomRight.Size = New System.Drawing.Size(21, 46)
        Me.btEffZoomRight.TabIndex = 5
        Me.btEffZoomRight.Text = "R"
        Me.btEffZoomRight.UseVisualStyleBackColor = True
        '
        'btEffZoomLeft
        '
        Me.btEffZoomLeft.Location = New System.Drawing.Point(13, 31)
        Me.btEffZoomLeft.Name = "btEffZoomLeft"
        Me.btEffZoomLeft.Size = New System.Drawing.Size(21, 46)
        Me.btEffZoomLeft.TabIndex = 4
        Me.btEffZoomLeft.Text = "L"
        Me.btEffZoomLeft.UseVisualStyleBackColor = True
        '
        'btEffZoomOut
        '
        Me.btEffZoomOut.Location = New System.Drawing.Point(61, 44)
        Me.btEffZoomOut.Name = "btEffZoomOut"
        Me.btEffZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.btEffZoomOut.TabIndex = 3
        Me.btEffZoomOut.Text = "-"
        Me.btEffZoomOut.UseVisualStyleBackColor = True
        '
        'btEffZoomIn
        '
        Me.btEffZoomIn.Location = New System.Drawing.Point(35, 44)
        Me.btEffZoomIn.Name = "btEffZoomIn"
        Me.btEffZoomIn.Size = New System.Drawing.Size(22, 22)
        Me.btEffZoomIn.TabIndex = 2
        Me.btEffZoomIn.Text = "+"
        Me.btEffZoomIn.UseVisualStyleBackColor = True
        '
        'btEffZoomDown
        '
        Me.btEffZoomDown.Location = New System.Drawing.Point(34, 66)
        Me.btEffZoomDown.Name = "btEffZoomDown"
        Me.btEffZoomDown.Size = New System.Drawing.Size(51, 22)
        Me.btEffZoomDown.TabIndex = 1
        Me.btEffZoomDown.Text = "Down"
        Me.btEffZoomDown.UseVisualStyleBackColor = True
        '
        'btEffZoomUp
        '
        Me.btEffZoomUp.Location = New System.Drawing.Point(34, 19)
        Me.btEffZoomUp.Name = "btEffZoomUp"
        Me.btEffZoomUp.Size = New System.Drawing.Size(51, 22)
        Me.btEffZoomUp.TabIndex = 0
        Me.btEffZoomUp.Text = "Up"
        Me.btEffZoomUp.UseVisualStyleBackColor = True
        '
        'cbZoom
        '
        Me.cbZoom.AutoSize = True
        Me.cbZoom.Location = New System.Drawing.Point(12, 14)
        Me.cbZoom.Name = "cbZoom"
        Me.cbZoom.Size = New System.Drawing.Size(65, 17)
        Me.cbZoom.TabIndex = 19
        Me.cbZoom.Text = "Enabled"
        Me.cbZoom.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.Controls.Add(Me.groupBox40)
        Me.TabPage16.Controls.Add(Me.groupBox39)
        Me.TabPage16.Controls.Add(Me.groupBox38)
        Me.TabPage16.Controls.Add(Me.cbPan)
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage16.Size = New System.Drawing.Size(275, 238)
        Me.TabPage16.TabIndex = 3
        Me.TabPage16.Text = "Pan"
        Me.TabPage16.UseVisualStyleBackColor = True
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
        Me.groupBox40.Location = New System.Drawing.Point(12, 156)
        Me.groupBox40.Margin = New System.Windows.Forms.Padding(2)
        Me.groupBox40.Name = "groupBox40"
        Me.groupBox40.Padding = New System.Windows.Forms.Padding(2)
        Me.groupBox40.Size = New System.Drawing.Size(168, 74)
        Me.groupBox40.TabIndex = 58
        Me.groupBox40.TabStop = False
        Me.groupBox40.Text = "Destination rect"
        '
        'edPanDestHeight
        '
        Me.edPanDestHeight.Location = New System.Drawing.Point(123, 49)
        Me.edPanDestHeight.Name = "edPanDestHeight"
        Me.edPanDestHeight.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestHeight.TabIndex = 17
        Me.edPanDestHeight.Text = "240"
        '
        'label302
        '
        Me.label302.AutoSize = True
        Me.label302.Location = New System.Drawing.Point(81, 52)
        Me.label302.Name = "label302"
        Me.label302.Size = New System.Drawing.Size(38, 13)
        Me.label302.TabIndex = 16
        Me.label302.Text = "Height"
        '
        'edPanDestWidth
        '
        Me.edPanDestWidth.Location = New System.Drawing.Point(123, 24)
        Me.edPanDestWidth.Name = "edPanDestWidth"
        Me.edPanDestWidth.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestWidth.TabIndex = 15
        Me.edPanDestWidth.Text = "320"
        '
        'label303
        '
        Me.label303.AutoSize = True
        Me.label303.Location = New System.Drawing.Point(81, 27)
        Me.label303.Name = "label303"
        Me.label303.Size = New System.Drawing.Size(35, 13)
        Me.label303.TabIndex = 14
        Me.label303.Text = "Width"
        '
        'edPanDestTop
        '
        Me.edPanDestTop.Location = New System.Drawing.Point(43, 50)
        Me.edPanDestTop.Name = "edPanDestTop"
        Me.edPanDestTop.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestTop.TabIndex = 12
        Me.edPanDestTop.Text = "0"
        '
        'label304
        '
        Me.label304.AutoSize = True
        Me.label304.Location = New System.Drawing.Point(13, 52)
        Me.label304.Name = "label304"
        Me.label304.Size = New System.Drawing.Size(26, 13)
        Me.label304.TabIndex = 11
        Me.label304.Text = "Top"
        '
        'edPanDestLeft
        '
        Me.edPanDestLeft.Location = New System.Drawing.Point(43, 25)
        Me.edPanDestLeft.Name = "edPanDestLeft"
        Me.edPanDestLeft.Size = New System.Drawing.Size(33, 20)
        Me.edPanDestLeft.TabIndex = 10
        Me.edPanDestLeft.Text = "0"
        '
        'label305
        '
        Me.label305.AutoSize = True
        Me.label305.Location = New System.Drawing.Point(13, 27)
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
        Me.groupBox39.Location = New System.Drawing.Point(12, 77)
        Me.groupBox39.Margin = New System.Windows.Forms.Padding(2)
        Me.groupBox39.Name = "groupBox39"
        Me.groupBox39.Padding = New System.Windows.Forms.Padding(2)
        Me.groupBox39.Size = New System.Drawing.Size(168, 74)
        Me.groupBox39.TabIndex = 57
        Me.groupBox39.TabStop = False
        Me.groupBox39.Text = "Source rect"
        '
        'edPanSourceHeight
        '
        Me.edPanSourceHeight.Location = New System.Drawing.Point(123, 49)
        Me.edPanSourceHeight.Name = "edPanSourceHeight"
        Me.edPanSourceHeight.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceHeight.TabIndex = 17
        Me.edPanSourceHeight.Text = "480"
        '
        'label298
        '
        Me.label298.AutoSize = True
        Me.label298.Location = New System.Drawing.Point(81, 52)
        Me.label298.Name = "label298"
        Me.label298.Size = New System.Drawing.Size(38, 13)
        Me.label298.TabIndex = 16
        Me.label298.Text = "Height"
        '
        'edPanSourceWidth
        '
        Me.edPanSourceWidth.Location = New System.Drawing.Point(123, 24)
        Me.edPanSourceWidth.Name = "edPanSourceWidth"
        Me.edPanSourceWidth.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceWidth.TabIndex = 15
        Me.edPanSourceWidth.Text = "640"
        '
        'label299
        '
        Me.label299.AutoSize = True
        Me.label299.Location = New System.Drawing.Point(81, 27)
        Me.label299.Name = "label299"
        Me.label299.Size = New System.Drawing.Size(35, 13)
        Me.label299.TabIndex = 14
        Me.label299.Text = "Width"
        '
        'edPanSourceTop
        '
        Me.edPanSourceTop.Location = New System.Drawing.Point(43, 50)
        Me.edPanSourceTop.Name = "edPanSourceTop"
        Me.edPanSourceTop.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceTop.TabIndex = 12
        Me.edPanSourceTop.Text = "0"
        '
        'label300
        '
        Me.label300.AutoSize = True
        Me.label300.Location = New System.Drawing.Point(13, 52)
        Me.label300.Name = "label300"
        Me.label300.Size = New System.Drawing.Size(26, 13)
        Me.label300.TabIndex = 11
        Me.label300.Text = "Top"
        '
        'edPanSourceLeft
        '
        Me.edPanSourceLeft.Location = New System.Drawing.Point(43, 25)
        Me.edPanSourceLeft.Name = "edPanSourceLeft"
        Me.edPanSourceLeft.Size = New System.Drawing.Size(33, 20)
        Me.edPanSourceLeft.TabIndex = 10
        Me.edPanSourceLeft.Text = "0"
        '
        'label301
        '
        Me.label301.AutoSize = True
        Me.label301.Location = New System.Drawing.Point(13, 27)
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
        Me.groupBox38.Location = New System.Drawing.Point(12, 28)
        Me.groupBox38.Name = "groupBox38"
        Me.groupBox38.Size = New System.Drawing.Size(168, 44)
        Me.groupBox38.TabIndex = 56
        Me.groupBox38.TabStop = False
        Me.groupBox38.Text = "Duration"
        '
        'edPanStopTime
        '
        Me.edPanStopTime.Location = New System.Drawing.Point(117, 18)
        Me.edPanStopTime.Name = "edPanStopTime"
        Me.edPanStopTime.Size = New System.Drawing.Size(39, 20)
        Me.edPanStopTime.TabIndex = 34
        Me.edPanStopTime.Text = "15000"
        Me.edPanStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label296
        '
        Me.label296.AutoSize = True
        Me.label296.Location = New System.Drawing.Point(88, 21)
        Me.label296.Name = "label296"
        Me.label296.Size = New System.Drawing.Size(29, 13)
        Me.label296.TabIndex = 33
        Me.label296.Text = "Stop"
        '
        'edPanStartTime
        '
        Me.edPanStartTime.Location = New System.Drawing.Point(43, 18)
        Me.edPanStartTime.Name = "edPanStartTime"
        Me.edPanStartTime.Size = New System.Drawing.Size(39, 20)
        Me.edPanStartTime.TabIndex = 32
        Me.edPanStartTime.Text = "5000"
        Me.edPanStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label297
        '
        Me.label297.AutoSize = True
        Me.label297.Location = New System.Drawing.Point(10, 21)
        Me.label297.Name = "label297"
        Me.label297.Size = New System.Drawing.Size(29, 13)
        Me.label297.TabIndex = 31
        Me.label297.Text = "Start"
        '
        'cbPan
        '
        Me.cbPan.AutoSize = True
        Me.cbPan.Location = New System.Drawing.Point(12, 6)
        Me.cbPan.Name = "cbPan"
        Me.cbPan.Size = New System.Drawing.Size(65, 17)
        Me.cbPan.TabIndex = 55
        Me.cbPan.Text = "Enabled"
        Me.cbPan.UseVisualStyleBackColor = True
        '
        'TabPage33
        '
        Me.TabPage33.Controls.Add(Me.rbVideoFadeOut)
        Me.TabPage33.Controls.Add(Me.rbVideoFadeIn)
        Me.TabPage33.Controls.Add(Me.groupBox45)
        Me.TabPage33.Controls.Add(Me.cbVideoFadeInOut)
        Me.TabPage33.Location = New System.Drawing.Point(4, 22)
        Me.TabPage33.Name = "TabPage33"
        Me.TabPage33.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage33.Size = New System.Drawing.Size(275, 238)
        Me.TabPage33.TabIndex = 4
        Me.TabPage33.Text = "Fade-in/out"
        Me.TabPage33.UseVisualStyleBackColor = True
        '
        'rbVideoFadeOut
        '
        Me.rbVideoFadeOut.AutoSize = True
        Me.rbVideoFadeOut.Location = New System.Drawing.Point(107, 86)
        Me.rbVideoFadeOut.Name = "rbVideoFadeOut"
        Me.rbVideoFadeOut.Size = New System.Drawing.Size(67, 17)
        Me.rbVideoFadeOut.TabIndex = 64
        Me.rbVideoFadeOut.TabStop = True
        Me.rbVideoFadeOut.Text = "Fade-out"
        Me.rbVideoFadeOut.UseVisualStyleBackColor = True
        '
        'rbVideoFadeIn
        '
        Me.rbVideoFadeIn.AutoSize = True
        Me.rbVideoFadeIn.Checked = True
        Me.rbVideoFadeIn.Location = New System.Drawing.Point(16, 86)
        Me.rbVideoFadeIn.Name = "rbVideoFadeIn"
        Me.rbVideoFadeIn.Size = New System.Drawing.Size(60, 17)
        Me.rbVideoFadeIn.TabIndex = 63
        Me.rbVideoFadeIn.TabStop = True
        Me.rbVideoFadeIn.Text = "Fade-in"
        Me.rbVideoFadeIn.UseVisualStyleBackColor = True
        '
        'groupBox45
        '
        Me.groupBox45.Controls.Add(Me.edVideoFadeInOutStopTime)
        Me.groupBox45.Controls.Add(Me.label329)
        Me.groupBox45.Controls.Add(Me.edVideoFadeInOutStartTime)
        Me.groupBox45.Controls.Add(Me.label330)
        Me.groupBox45.Location = New System.Drawing.Point(16, 36)
        Me.groupBox45.Name = "groupBox45"
        Me.groupBox45.Size = New System.Drawing.Size(168, 44)
        Me.groupBox45.TabIndex = 62
        Me.groupBox45.TabStop = False
        Me.groupBox45.Text = "Duration"
        '
        'edVideoFadeInOutStopTime
        '
        Me.edVideoFadeInOutStopTime.Location = New System.Drawing.Point(117, 18)
        Me.edVideoFadeInOutStopTime.Name = "edVideoFadeInOutStopTime"
        Me.edVideoFadeInOutStopTime.Size = New System.Drawing.Size(39, 20)
        Me.edVideoFadeInOutStopTime.TabIndex = 34
        Me.edVideoFadeInOutStopTime.Text = "15000"
        Me.edVideoFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label329
        '
        Me.label329.AutoSize = True
        Me.label329.Location = New System.Drawing.Point(88, 21)
        Me.label329.Name = "label329"
        Me.label329.Size = New System.Drawing.Size(29, 13)
        Me.label329.TabIndex = 33
        Me.label329.Text = "Stop"
        '
        'edVideoFadeInOutStartTime
        '
        Me.edVideoFadeInOutStartTime.Location = New System.Drawing.Point(43, 18)
        Me.edVideoFadeInOutStartTime.Name = "edVideoFadeInOutStartTime"
        Me.edVideoFadeInOutStartTime.Size = New System.Drawing.Size(39, 20)
        Me.edVideoFadeInOutStartTime.TabIndex = 32
        Me.edVideoFadeInOutStartTime.Text = "5000"
        Me.edVideoFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label330
        '
        Me.label330.AutoSize = True
        Me.label330.Location = New System.Drawing.Point(10, 21)
        Me.label330.Name = "label330"
        Me.label330.Size = New System.Drawing.Size(29, 13)
        Me.label330.TabIndex = 31
        Me.label330.Text = "Start"
        '
        'cbVideoFadeInOut
        '
        Me.cbVideoFadeInOut.AutoSize = True
        Me.cbVideoFadeInOut.Location = New System.Drawing.Point(16, 14)
        Me.cbVideoFadeInOut.Name = "cbVideoFadeInOut"
        Me.cbVideoFadeInOut.Size = New System.Drawing.Size(65, 17)
        Me.cbVideoFadeInOut.TabIndex = 61
        Me.cbVideoFadeInOut.Text = "Enabled"
        Me.cbVideoFadeInOut.UseVisualStyleBackColor = True
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(3, 103)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbContrast.TabIndex = 49
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(142, 103)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbDarkness.TabIndex = 46
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(3, 49)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(130, 45)
        Me.tbLightness.TabIndex = 45
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(142, 49)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbSaturation.TabIndex = 43
        Me.tbSaturation.Value = 255
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = True
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(86, 152)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbInvert.TabIndex = 41
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = True
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = True
        Me.cbGreyscale.Location = New System.Drawing.Point(9, 152)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGreyscale.TabIndex = 39
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = True
        '
        'cbEffects
        '
        Me.cbEffects.AutoSize = True
        Me.cbEffects.Checked = True
        Me.cbEffects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEffects.Location = New System.Drawing.Point(8, 8)
        Me.cbEffects.Name = "cbEffects"
        Me.cbEffects.Size = New System.Drawing.Size(65, 17)
        Me.cbEffects.TabIndex = 37
        Me.cbEffects.Text = "Enabled"
        Me.cbEffects.UseVisualStyleBackColor = True
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
        Me.tabPage69.Size = New System.Drawing.Size(290, 440)
        Me.tabPage69.TabIndex = 1
        Me.tabPage69.Text = "Deinterlace"
        Me.tabPage69.UseVisualStyleBackColor = True
        '
        'label211
        '
        Me.label211.AutoSize = True
        Me.label211.Location = New System.Drawing.Point(100, 282)
        Me.label211.Name = "label211"
        Me.label211.Size = New System.Drawing.Size(40, 13)
        Me.label211.TabIndex = 28
        Me.label211.Text = "[0-255]"
        '
        'edDeintTriangleWeight
        '
        Me.edDeintTriangleWeight.Location = New System.Drawing.Point(103, 260)
        Me.edDeintTriangleWeight.Name = "edDeintTriangleWeight"
        Me.edDeintTriangleWeight.Size = New System.Drawing.Size(32, 20)
        Me.edDeintTriangleWeight.TabIndex = 27
        Me.edDeintTriangleWeight.Text = "180"
        '
        'label212
        '
        Me.label212.AutoSize = True
        Me.label212.Location = New System.Drawing.Point(34, 262)
        Me.label212.Name = "label212"
        Me.label212.Size = New System.Drawing.Size(41, 13)
        Me.label212.TabIndex = 26
        Me.label212.Text = "Weight"
        '
        'label210
        '
        Me.label210.AutoSize = True
        Me.label210.Location = New System.Drawing.Point(257, 184)
        Me.label210.Name = "label210"
        Me.label210.Size = New System.Drawing.Size(27, 13)
        Me.label210.TabIndex = 25
        Me.label210.Text = "/ 10"
        '
        'label209
        '
        Me.label209.AutoSize = True
        Me.label209.Location = New System.Drawing.Point(257, 153)
        Me.label209.Name = "label209"
        Me.label209.Size = New System.Drawing.Size(27, 13)
        Me.label209.TabIndex = 24
        Me.label209.Text = "/ 10"
        '
        'label206
        '
        Me.label206.AutoSize = True
        Me.label206.Location = New System.Drawing.Point(218, 205)
        Me.label206.Name = "label206"
        Me.label206.Size = New System.Drawing.Size(46, 13)
        Me.label206.TabIndex = 23
        Me.label206.Text = "[0.0-1.0]"
        '
        'edDeintBlendConstants2
        '
        Me.edDeintBlendConstants2.Location = New System.Drawing.Point(221, 182)
        Me.edDeintBlendConstants2.Name = "edDeintBlendConstants2"
        Me.edDeintBlendConstants2.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendConstants2.TabIndex = 22
        Me.edDeintBlendConstants2.Text = "9"
        '
        'label207
        '
        Me.label207.AutoSize = True
        Me.label207.Location = New System.Drawing.Point(152, 184)
        Me.label207.Name = "label207"
        Me.label207.Size = New System.Drawing.Size(63, 13)
        Me.label207.TabIndex = 21
        Me.label207.Text = "Constants 2"
        '
        'edDeintBlendConstants1
        '
        Me.edDeintBlendConstants1.Location = New System.Drawing.Point(221, 150)
        Me.edDeintBlendConstants1.Name = "edDeintBlendConstants1"
        Me.edDeintBlendConstants1.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendConstants1.TabIndex = 20
        Me.edDeintBlendConstants1.Text = "3"
        '
        'label208
        '
        Me.label208.AutoSize = True
        Me.label208.Location = New System.Drawing.Point(152, 153)
        Me.label208.Name = "label208"
        Me.label208.Size = New System.Drawing.Size(63, 13)
        Me.label208.TabIndex = 19
        Me.label208.Text = "Constants 1"
        '
        'label204
        '
        Me.label204.AutoSize = True
        Me.label204.Location = New System.Drawing.Point(100, 205)
        Me.label204.Name = "label204"
        Me.label204.Size = New System.Drawing.Size(40, 13)
        Me.label204.TabIndex = 18
        Me.label204.Text = "[0-255]"
        '
        'edDeintBlendThreshold2
        '
        Me.edDeintBlendThreshold2.Location = New System.Drawing.Point(103, 182)
        Me.edDeintBlendThreshold2.Name = "edDeintBlendThreshold2"
        Me.edDeintBlendThreshold2.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendThreshold2.TabIndex = 17
        Me.edDeintBlendThreshold2.Text = "9"
        '
        'label205
        '
        Me.label205.AutoSize = True
        Me.label205.Location = New System.Drawing.Point(34, 184)
        Me.label205.Name = "label205"
        Me.label205.Size = New System.Drawing.Size(63, 13)
        Me.label205.TabIndex = 16
        Me.label205.Text = "Threshold 2"
        '
        'edDeintBlendThreshold1
        '
        Me.edDeintBlendThreshold1.Location = New System.Drawing.Point(103, 150)
        Me.edDeintBlendThreshold1.Name = "edDeintBlendThreshold1"
        Me.edDeintBlendThreshold1.Size = New System.Drawing.Size(32, 20)
        Me.edDeintBlendThreshold1.TabIndex = 15
        Me.edDeintBlendThreshold1.Text = "5"
        '
        'label203
        '
        Me.label203.AutoSize = True
        Me.label203.Location = New System.Drawing.Point(34, 153)
        Me.label203.Name = "label203"
        Me.label203.Size = New System.Drawing.Size(63, 13)
        Me.label203.TabIndex = 14
        Me.label203.Text = "Threshold 1"
        '
        'label202
        '
        Me.label202.AutoSize = True
        Me.label202.Location = New System.Drawing.Point(100, 99)
        Me.label202.Name = "label202"
        Me.label202.Size = New System.Drawing.Size(40, 13)
        Me.label202.TabIndex = 13
        Me.label202.Text = "[0-255]"
        '
        'edDeintCAVTThreshold
        '
        Me.edDeintCAVTThreshold.Location = New System.Drawing.Point(103, 76)
        Me.edDeintCAVTThreshold.Name = "edDeintCAVTThreshold"
        Me.edDeintCAVTThreshold.Size = New System.Drawing.Size(32, 20)
        Me.edDeintCAVTThreshold.TabIndex = 12
        Me.edDeintCAVTThreshold.Text = "20"
        '
        'label104
        '
        Me.label104.AutoSize = True
        Me.label104.Location = New System.Drawing.Point(34, 79)
        Me.label104.Name = "label104"
        Me.label104.Size = New System.Drawing.Size(54, 13)
        Me.label104.TabIndex = 11
        Me.label104.Text = "Threshold"
        '
        'rbDeintTriangleEnabled
        '
        Me.rbDeintTriangleEnabled.AutoSize = True
        Me.rbDeintTriangleEnabled.Location = New System.Drawing.Point(18, 234)
        Me.rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled"
        Me.rbDeintTriangleEnabled.Size = New System.Drawing.Size(63, 17)
        Me.rbDeintTriangleEnabled.TabIndex = 10
        Me.rbDeintTriangleEnabled.Text = "Triangle"
        Me.rbDeintTriangleEnabled.UseVisualStyleBackColor = True
        '
        'rbDeintBlendEnabled
        '
        Me.rbDeintBlendEnabled.AutoSize = True
        Me.rbDeintBlendEnabled.Location = New System.Drawing.Point(18, 122)
        Me.rbDeintBlendEnabled.Name = "rbDeintBlendEnabled"
        Me.rbDeintBlendEnabled.Size = New System.Drawing.Size(52, 17)
        Me.rbDeintBlendEnabled.TabIndex = 9
        Me.rbDeintBlendEnabled.Text = "Blend"
        Me.rbDeintBlendEnabled.UseVisualStyleBackColor = True
        '
        'rbDeintCAVTEnabled
        '
        Me.rbDeintCAVTEnabled.AutoSize = True
        Me.rbDeintCAVTEnabled.Checked = True
        Me.rbDeintCAVTEnabled.Location = New System.Drawing.Point(18, 50)
        Me.rbDeintCAVTEnabled.Name = "rbDeintCAVTEnabled"
        Me.rbDeintCAVTEnabled.Size = New System.Drawing.Size(229, 17)
        Me.rbDeintCAVTEnabled.TabIndex = 8
        Me.rbDeintCAVTEnabled.TabStop = True
        Me.rbDeintCAVTEnabled.Text = "Content Adaptive Vertical Temporal (CAVT)"
        Me.rbDeintCAVTEnabled.UseVisualStyleBackColor = True
        '
        'cbDeinterlace
        '
        Me.cbDeinterlace.AutoSize = True
        Me.cbDeinterlace.Location = New System.Drawing.Point(18, 16)
        Me.cbDeinterlace.Name = "cbDeinterlace"
        Me.cbDeinterlace.Size = New System.Drawing.Size(65, 17)
        Me.cbDeinterlace.TabIndex = 7
        Me.cbDeinterlace.Text = "Enabled"
        Me.cbDeinterlace.UseVisualStyleBackColor = True
        '
        'tabPage59
        '
        Me.tabPage59.Controls.Add(Me.rbDenoiseCAST)
        Me.tabPage59.Controls.Add(Me.rbDenoiseMosquito)
        Me.tabPage59.Controls.Add(Me.cbDenoise)
        Me.tabPage59.Location = New System.Drawing.Point(4, 22)
        Me.tabPage59.Name = "tabPage59"
        Me.tabPage59.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage59.Size = New System.Drawing.Size(290, 440)
        Me.tabPage59.TabIndex = 4
        Me.tabPage59.Text = "Denoise"
        Me.tabPage59.UseVisualStyleBackColor = True
        '
        'rbDenoiseCAST
        '
        Me.rbDenoiseCAST.AutoSize = True
        Me.rbDenoiseCAST.Location = New System.Drawing.Point(18, 76)
        Me.rbDenoiseCAST.Name = "rbDenoiseCAST"
        Me.rbDenoiseCAST.Size = New System.Drawing.Size(224, 17)
        Me.rbDenoiseCAST.TabIndex = 10
        Me.rbDenoiseCAST.Text = "Content Adaptive Spatio-Temporal (CAST)"
        Me.rbDenoiseCAST.UseVisualStyleBackColor = True
        '
        'rbDenoiseMosquito
        '
        Me.rbDenoiseMosquito.AutoSize = True
        Me.rbDenoiseMosquito.Checked = True
        Me.rbDenoiseMosquito.Location = New System.Drawing.Point(18, 50)
        Me.rbDenoiseMosquito.Name = "rbDenoiseMosquito"
        Me.rbDenoiseMosquito.Size = New System.Drawing.Size(68, 17)
        Me.rbDenoiseMosquito.TabIndex = 9
        Me.rbDenoiseMosquito.TabStop = True
        Me.rbDenoiseMosquito.Text = "Mosquito"
        Me.rbDenoiseMosquito.UseVisualStyleBackColor = True
        '
        'cbDenoise
        '
        Me.cbDenoise.AutoSize = True
        Me.cbDenoise.Location = New System.Drawing.Point(18, 16)
        Me.cbDenoise.Name = "cbDenoise"
        Me.cbDenoise.Size = New System.Drawing.Size(65, 17)
        Me.cbDenoise.TabIndex = 8
        Me.cbDenoise.Text = "Enabled"
        Me.cbDenoise.UseVisualStyleBackColor = True
        '
        'TabPage82
        '
        Me.TabPage82.Controls.Add(Me.label5)
        Me.TabPage82.Controls.Add(Me.tbGPUBlur)
        Me.TabPage82.Controls.Add(Me.cbVideoEffectsGPUEnabled)
        Me.TabPage82.Controls.Add(Me.cbGPUOldMovie)
        Me.TabPage82.Controls.Add(Me.cbGPUDeinterlace)
        Me.TabPage82.Controls.Add(Me.cbGPUDenoise)
        Me.TabPage82.Controls.Add(Me.cbGPUPixelate)
        Me.TabPage82.Controls.Add(Me.cbGPUNightVision)
        Me.TabPage82.Controls.Add(Me.label383)
        Me.TabPage82.Controls.Add(Me.label384)
        Me.TabPage82.Controls.Add(Me.label385)
        Me.TabPage82.Controls.Add(Me.label386)
        Me.TabPage82.Controls.Add(Me.tbGPUContrast)
        Me.TabPage82.Controls.Add(Me.tbGPUDarkness)
        Me.TabPage82.Controls.Add(Me.tbGPULightness)
        Me.TabPage82.Controls.Add(Me.tbGPUSaturation)
        Me.TabPage82.Controls.Add(Me.cbGPUInvert)
        Me.TabPage82.Controls.Add(Me.cbGPUGreyscale)
        Me.TabPage82.Location = New System.Drawing.Point(4, 22)
        Me.TabPage82.Name = "TabPage82"
        Me.TabPage82.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage82.Size = New System.Drawing.Size(290, 440)
        Me.TabPage82.TabIndex = 8
        Me.TabPage82.Text = "GPU effects"
        Me.TabPage82.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(14, 269)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(25, 13)
        Me.label5.TabIndex = 103
        Me.label5.Text = "Blur"
        '
        'tbGPUBlur
        '
        Me.tbGPUBlur.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUBlur.Location = New System.Drawing.Point(11, 285)
        Me.tbGPUBlur.Maximum = 30
        Me.tbGPUBlur.Name = "tbGPUBlur"
        Me.tbGPUBlur.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUBlur.TabIndex = 102
        '
        'cbVideoEffectsGPUEnabled
        '
        Me.cbVideoEffectsGPUEnabled.AutoSize = True
        Me.cbVideoEffectsGPUEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled"
        Me.cbVideoEffectsGPUEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbVideoEffectsGPUEnabled.TabIndex = 97
        Me.cbVideoEffectsGPUEnabled.Text = "Enabled"
        Me.cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = True
        '
        'cbGPUOldMovie
        '
        Me.cbGPUOldMovie.AutoSize = True
        Me.cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUOldMovie.Location = New System.Drawing.Point(145, 228)
        Me.cbGPUOldMovie.Name = "cbGPUOldMovie"
        Me.cbGPUOldMovie.Size = New System.Drawing.Size(73, 17)
        Me.cbGPUOldMovie.TabIndex = 96
        Me.cbGPUOldMovie.Text = "Old movie"
        Me.cbGPUOldMovie.UseVisualStyleBackColor = True
        '
        'cbGPUDeinterlace
        '
        Me.cbGPUDeinterlace.AutoSize = True
        Me.cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUDeinterlace.Location = New System.Drawing.Point(145, 205)
        Me.cbGPUDeinterlace.Name = "cbGPUDeinterlace"
        Me.cbGPUDeinterlace.Size = New System.Drawing.Size(80, 17)
        Me.cbGPUDeinterlace.TabIndex = 94
        Me.cbGPUDeinterlace.Text = "Deinterlace"
        Me.cbGPUDeinterlace.UseVisualStyleBackColor = True
        '
        'cbGPUDenoise
        '
        Me.cbGPUDenoise.AutoSize = True
        Me.cbGPUDenoise.Location = New System.Drawing.Point(17, 205)
        Me.cbGPUDenoise.Name = "cbGPUDenoise"
        Me.cbGPUDenoise.Size = New System.Drawing.Size(65, 17)
        Me.cbGPUDenoise.TabIndex = 93
        Me.cbGPUDenoise.Text = "Denoise"
        Me.cbGPUDenoise.UseVisualStyleBackColor = True
        '
        'cbGPUPixelate
        '
        Me.cbGPUPixelate.AutoSize = True
        Me.cbGPUPixelate.Location = New System.Drawing.Point(145, 183)
        Me.cbGPUPixelate.Name = "cbGPUPixelate"
        Me.cbGPUPixelate.Size = New System.Drawing.Size(63, 17)
        Me.cbGPUPixelate.TabIndex = 92
        Me.cbGPUPixelate.Text = "Pixelate"
        Me.cbGPUPixelate.UseVisualStyleBackColor = True
        '
        'cbGPUNightVision
        '
        Me.cbGPUNightVision.AutoSize = True
        Me.cbGPUNightVision.Location = New System.Drawing.Point(17, 183)
        Me.cbGPUNightVision.Name = "cbGPUNightVision"
        Me.cbGPUNightVision.Size = New System.Drawing.Size(81, 17)
        Me.cbGPUNightVision.TabIndex = 91
        Me.cbGPUNightVision.Text = "Night vision"
        Me.cbGPUNightVision.UseVisualStyleBackColor = True
        '
        'label383
        '
        Me.label383.AutoSize = True
        Me.label383.Location = New System.Drawing.Point(150, 94)
        Me.label383.Name = "label383"
        Me.label383.Size = New System.Drawing.Size(52, 13)
        Me.label383.TabIndex = 90
        Me.label383.Text = "Darkness"
        '
        'label384
        '
        Me.label384.AutoSize = True
        Me.label384.Location = New System.Drawing.Point(14, 94)
        Me.label384.Name = "label384"
        Me.label384.Size = New System.Drawing.Size(46, 13)
        Me.label384.TabIndex = 89
        Me.label384.Text = "Contrast"
        '
        'label385
        '
        Me.label385.AutoSize = True
        Me.label385.Location = New System.Drawing.Point(150, 44)
        Me.label385.Name = "label385"
        Me.label385.Size = New System.Drawing.Size(55, 13)
        Me.label385.TabIndex = 88
        Me.label385.Text = "Saturation"
        '
        'label386
        '
        Me.label386.AutoSize = True
        Me.label386.Location = New System.Drawing.Point(14, 44)
        Me.label386.Name = "label386"
        Me.label386.Size = New System.Drawing.Size(52, 13)
        Me.label386.TabIndex = 87
        Me.label386.Text = "Lightness"
        '
        'tbGPUContrast
        '
        Me.tbGPUContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUContrast.Location = New System.Drawing.Point(11, 112)
        Me.tbGPUContrast.Maximum = 255
        Me.tbGPUContrast.Name = "tbGPUContrast"
        Me.tbGPUContrast.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUContrast.TabIndex = 86
        Me.tbGPUContrast.Value = 255
        '
        'tbGPUDarkness
        '
        Me.tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUDarkness.Location = New System.Drawing.Point(150, 112)
        Me.tbGPUDarkness.Maximum = 255
        Me.tbGPUDarkness.Name = "tbGPUDarkness"
        Me.tbGPUDarkness.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUDarkness.TabIndex = 85
        '
        'tbGPULightness
        '
        Me.tbGPULightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPULightness.Location = New System.Drawing.Point(11, 58)
        Me.tbGPULightness.Maximum = 255
        Me.tbGPULightness.Name = "tbGPULightness"
        Me.tbGPULightness.Size = New System.Drawing.Size(130, 45)
        Me.tbGPULightness.TabIndex = 84
        '
        'tbGPUSaturation
        '
        Me.tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbGPUSaturation.Location = New System.Drawing.Point(150, 58)
        Me.tbGPUSaturation.Maximum = 255
        Me.tbGPUSaturation.Name = "tbGPUSaturation"
        Me.tbGPUSaturation.Size = New System.Drawing.Size(130, 45)
        Me.tbGPUSaturation.TabIndex = 83
        Me.tbGPUSaturation.Value = 255
        '
        'cbGPUInvert
        '
        Me.cbGPUInvert.AutoSize = True
        Me.cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbGPUInvert.Location = New System.Drawing.Point(145, 161)
        Me.cbGPUInvert.Name = "cbGPUInvert"
        Me.cbGPUInvert.Size = New System.Drawing.Size(53, 17)
        Me.cbGPUInvert.TabIndex = 82
        Me.cbGPUInvert.Text = "Invert"
        Me.cbGPUInvert.UseVisualStyleBackColor = True
        '
        'cbGPUGreyscale
        '
        Me.cbGPUGreyscale.AutoSize = True
        Me.cbGPUGreyscale.Location = New System.Drawing.Point(17, 161)
        Me.cbGPUGreyscale.Name = "cbGPUGreyscale"
        Me.cbGPUGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbGPUGreyscale.TabIndex = 81
        Me.cbGPUGreyscale.Text = "Greyscale"
        Me.cbGPUGreyscale.UseVisualStyleBackColor = True
        '
        'TabPage20
        '
        Me.TabPage20.Controls.Add(Me.tabControl15)
        Me.TabPage20.Controls.Add(Me.label16)
        Me.TabPage20.Location = New System.Drawing.Point(4, 22)
        Me.TabPage20.Name = "TabPage20"
        Me.TabPage20.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage20.Size = New System.Drawing.Size(290, 440)
        Me.TabPage20.TabIndex = 5
        Me.TabPage20.Text = "Object detection"
        Me.TabPage20.UseVisualStyleBackColor = True
        '
        'tabControl15
        '
        Me.tabControl15.Controls.Add(Me.TabPage26)
        Me.tabControl15.Controls.Add(Me.TabPage27)
        Me.tabControl15.Location = New System.Drawing.Point(6, 6)
        Me.tabControl15.Name = "tabControl15"
        Me.tabControl15.SelectedIndex = 0
        Me.tabControl15.Size = New System.Drawing.Size(278, 371)
        Me.tabControl15.TabIndex = 5
        '
        'TabPage26
        '
        Me.TabPage26.Controls.Add(Me.label64)
        Me.TabPage26.Controls.Add(Me.label65)
        Me.TabPage26.Controls.Add(Me.pbAFMotionLevel)
        Me.TabPage26.Controls.Add(Me.cbAFMotionHighlight)
        Me.TabPage26.Controls.Add(Me.cbAFMotionDetection)
        Me.TabPage26.Location = New System.Drawing.Point(4, 22)
        Me.TabPage26.Name = "TabPage26"
        Me.TabPage26.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage26.Size = New System.Drawing.Size(270, 345)
        Me.TabPage26.TabIndex = 0
        Me.TabPage26.Text = "Motion detection"
        Me.TabPage26.UseVisualStyleBackColor = True
        '
        'label64
        '
        Me.label64.AutoSize = True
        Me.label64.Location = New System.Drawing.Point(6, 88)
        Me.label64.Name = "label64"
        Me.label64.Size = New System.Drawing.Size(254, 13)
        Me.label64.TabIndex = 4
        Me.label64.Text = "Much more motion detection options available in API"
        '
        'label65
        '
        Me.label65.AutoSize = True
        Me.label65.Location = New System.Drawing.Point(6, 303)
        Me.label65.Name = "label65"
        Me.label65.Size = New System.Drawing.Size(64, 13)
        Me.label65.TabIndex = 3
        Me.label65.Text = "Motion level"
        '
        'pbAFMotionLevel
        '
        Me.pbAFMotionLevel.Location = New System.Drawing.Point(6, 318)
        Me.pbAFMotionLevel.Name = "pbAFMotionLevel"
        Me.pbAFMotionLevel.Size = New System.Drawing.Size(258, 22)
        Me.pbAFMotionLevel.TabIndex = 2
        '
        'cbAFMotionHighlight
        '
        Me.cbAFMotionHighlight.AutoSize = True
        Me.cbAFMotionHighlight.Location = New System.Drawing.Point(15, 44)
        Me.cbAFMotionHighlight.Name = "cbAFMotionHighlight"
        Me.cbAFMotionHighlight.Size = New System.Drawing.Size(67, 17)
        Me.cbAFMotionHighlight.TabIndex = 1
        Me.cbAFMotionHighlight.Text = "Highlight"
        Me.cbAFMotionHighlight.UseVisualStyleBackColor = True
        '
        'cbAFMotionDetection
        '
        Me.cbAFMotionDetection.AutoSize = True
        Me.cbAFMotionDetection.Location = New System.Drawing.Point(15, 18)
        Me.cbAFMotionDetection.Name = "cbAFMotionDetection"
        Me.cbAFMotionDetection.Size = New System.Drawing.Size(138, 17)
        Me.cbAFMotionDetection.TabIndex = 0
        Me.cbAFMotionDetection.Text = "Enabled, detect objects"
        Me.cbAFMotionDetection.UseVisualStyleBackColor = True
        '
        'TabPage27
        '
        Me.TabPage27.Controls.Add(Me.label171)
        Me.TabPage27.Controls.Add(Me.label66)
        Me.TabPage27.Location = New System.Drawing.Point(4, 22)
        Me.TabPage27.Name = "TabPage27"
        Me.TabPage27.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage27.Size = New System.Drawing.Size(270, 345)
        Me.TabPage27.TabIndex = 1
        Me.TabPage27.Text = "Effects"
        Me.TabPage27.UseVisualStyleBackColor = True
        '
        'label171
        '
        Me.label171.AutoSize = True
        Me.label171.Location = New System.Drawing.Point(10, 38)
        Me.label171.Name = "label171"
        Me.label171.Size = New System.Drawing.Size(141, 13)
        Me.label171.TabIndex = 1
        Me.label171.Text = "OnVideoFrameBuffer event. "
        '
        'label66
        '
        Me.label66.AutoSize = True
        Me.label66.Location = New System.Drawing.Point(10, 18)
        Me.label66.Name = "label66"
        Me.label66.Size = New System.Drawing.Size(171, 13)
        Me.label66.TabIndex = 0
        Me.label66.Text = "You can add various effects using "
        '
        'label16
        '
        Me.label16.Location = New System.Drawing.Point(0, 0)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(100, 22)
        Me.label16.TabIndex = 6
        '
        'TabPage21
        '
        Me.TabPage21.Controls.Add(Me.pnChromaKeyColor)
        Me.TabPage21.Controls.Add(Me.btChromaKeySelectBGImage)
        Me.TabPage21.Controls.Add(Me.edChromaKeyImage)
        Me.TabPage21.Controls.Add(Me.label216)
        Me.TabPage21.Controls.Add(Me.label215)
        Me.TabPage21.Controls.Add(Me.tbChromaKeySmoothing)
        Me.TabPage21.Controls.Add(Me.label214)
        Me.TabPage21.Controls.Add(Me.tbChromaKeyThresholdSensitivity)
        Me.TabPage21.Controls.Add(Me.label213)
        Me.TabPage21.Controls.Add(Me.cbChromaKeyEnabled)
        Me.TabPage21.Location = New System.Drawing.Point(4, 22)
        Me.TabPage21.Name = "TabPage21"
        Me.TabPage21.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage21.Size = New System.Drawing.Size(290, 440)
        Me.TabPage21.TabIndex = 6
        Me.TabPage21.Text = "Chroma key"
        Me.TabPage21.UseVisualStyleBackColor = True
        '
        'pnChromaKeyColor
        '
        Me.pnChromaKeyColor.BackColor = System.Drawing.Color.Lime
        Me.pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control
        Me.pnChromaKeyColor.Location = New System.Drawing.Point(54, 199)
        Me.pnChromaKeyColor.Name = "pnChromaKeyColor"
        Me.pnChromaKeyColor.Size = New System.Drawing.Size(26, 24)
        Me.pnChromaKeyColor.TabIndex = 43
        '
        'btChromaKeySelectBGImage
        '
        Me.btChromaKeySelectBGImage.Location = New System.Drawing.Point(254, 261)
        Me.btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage"
        Me.btChromaKeySelectBGImage.Size = New System.Drawing.Size(24, 23)
        Me.btChromaKeySelectBGImage.TabIndex = 42
        Me.btChromaKeySelectBGImage.Text = "..."
        Me.btChromaKeySelectBGImage.UseVisualStyleBackColor = True
        '
        'edChromaKeyImage
        '
        Me.edChromaKeyImage.Location = New System.Drawing.Point(12, 263)
        Me.edChromaKeyImage.Name = "edChromaKeyImage"
        Me.edChromaKeyImage.Size = New System.Drawing.Size(235, 20)
        Me.edChromaKeyImage.TabIndex = 41
        Me.edChromaKeyImage.Text = "c:\Samples\pics\1.jpg"
        '
        'label216
        '
        Me.label216.AutoSize = True
        Me.label216.Location = New System.Drawing.Point(9, 247)
        Me.label216.Name = "label216"
        Me.label216.Size = New System.Drawing.Size(112, 13)
        Me.label216.TabIndex = 40
        Me.label216.Text = "Image background file"
        '
        'label215
        '
        Me.label215.AutoSize = True
        Me.label215.Location = New System.Drawing.Point(9, 203)
        Me.label215.Name = "label215"
        Me.label215.Size = New System.Drawing.Size(31, 13)
        Me.label215.TabIndex = 39
        Me.label215.Text = "Color"
        '
        'tbChromaKeySmoothing
        '
        Me.tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window
        Me.tbChromaKeySmoothing.Location = New System.Drawing.Point(12, 144)
        Me.tbChromaKeySmoothing.Maximum = 1000
        Me.tbChromaKeySmoothing.Name = "tbChromaKeySmoothing"
        Me.tbChromaKeySmoothing.Size = New System.Drawing.Size(154, 45)
        Me.tbChromaKeySmoothing.TabIndex = 38
        Me.tbChromaKeySmoothing.Value = 80
        '
        'label214
        '
        Me.label214.AutoSize = True
        Me.label214.Location = New System.Drawing.Point(9, 126)
        Me.label214.Name = "label214"
        Me.label214.Size = New System.Drawing.Size(57, 13)
        Me.label214.TabIndex = 37
        Me.label214.Text = "Smoothing"
        '
        'tbChromaKeyThresholdSensitivity
        '
        Me.tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window
        Me.tbChromaKeyThresholdSensitivity.Location = New System.Drawing.Point(12, 71)
        Me.tbChromaKeyThresholdSensitivity.Maximum = 200
        Me.tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity"
        Me.tbChromaKeyThresholdSensitivity.Size = New System.Drawing.Size(154, 45)
        Me.tbChromaKeyThresholdSensitivity.TabIndex = 36
        Me.tbChromaKeyThresholdSensitivity.Value = 180
        '
        'label213
        '
        Me.label213.AutoSize = True
        Me.label213.Location = New System.Drawing.Point(9, 53)
        Me.label213.Name = "label213"
        Me.label213.Size = New System.Drawing.Size(102, 13)
        Me.label213.TabIndex = 35
        Me.label213.Text = "Threshold sensitivity"
        '
        'cbChromaKeyEnabled
        '
        Me.cbChromaKeyEnabled.AutoSize = True
        Me.cbChromaKeyEnabled.Location = New System.Drawing.Point(12, 14)
        Me.cbChromaKeyEnabled.Name = "cbChromaKeyEnabled"
        Me.cbChromaKeyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbChromaKeyEnabled.TabIndex = 34
        Me.cbChromaKeyEnabled.Text = "Enabled"
        Me.cbChromaKeyEnabled.UseVisualStyleBackColor = True
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
        Me.tabPage70.Size = New System.Drawing.Size(290, 440)
        Me.tabPage70.TabIndex = 3
        Me.tabPage70.Text = "3rd-party filters"
        Me.tabPage70.UseVisualStyleBackColor = True
        '
        'btFilterDeleteAll
        '
        Me.btFilterDeleteAll.Location = New System.Drawing.Point(210, 276)
        Me.btFilterDeleteAll.Name = "btFilterDeleteAll"
        Me.btFilterDeleteAll.Size = New System.Drawing.Size(68, 22)
        Me.btFilterDeleteAll.TabIndex = 16
        Me.btFilterDeleteAll.Text = "Delete all"
        Me.btFilterDeleteAll.UseVisualStyleBackColor = True
        '
        'btFilterSettings2
        '
        Me.btFilterSettings2.Location = New System.Drawing.Point(18, 276)
        Me.btFilterSettings2.Name = "btFilterSettings2"
        Me.btFilterSettings2.Size = New System.Drawing.Size(65, 22)
        Me.btFilterSettings2.TabIndex = 15
        Me.btFilterSettings2.Text = "Settings"
        Me.btFilterSettings2.UseVisualStyleBackColor = True
        '
        'lbFilters
        '
        Me.lbFilters.FormattingEnabled = True
        Me.lbFilters.Location = New System.Drawing.Point(18, 116)
        Me.lbFilters.Name = "lbFilters"
        Me.lbFilters.Size = New System.Drawing.Size(260, 134)
        Me.lbFilters.TabIndex = 14
        '
        'label106
        '
        Me.label106.AutoSize = True
        Me.label106.Location = New System.Drawing.Point(15, 101)
        Me.label106.Name = "label106"
        Me.label106.Size = New System.Drawing.Size(68, 13)
        Me.label106.TabIndex = 13
        Me.label106.Text = "Current filters"
        '
        'btFilterSettings
        '
        Me.btFilterSettings.Location = New System.Drawing.Point(210, 55)
        Me.btFilterSettings.Name = "btFilterSettings"
        Me.btFilterSettings.Size = New System.Drawing.Size(68, 22)
        Me.btFilterSettings.TabIndex = 12
        Me.btFilterSettings.Text = "Settings"
        Me.btFilterSettings.UseVisualStyleBackColor = True
        '
        'btFilterAdd
        '
        Me.btFilterAdd.Location = New System.Drawing.Point(18, 55)
        Me.btFilterAdd.Name = "btFilterAdd"
        Me.btFilterAdd.Size = New System.Drawing.Size(39, 22)
        Me.btFilterAdd.TabIndex = 11
        Me.btFilterAdd.Text = "Add"
        Me.btFilterAdd.UseVisualStyleBackColor = True
        '
        'cbFilters
        '
        Me.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilters.FormattingEnabled = True
        Me.cbFilters.Location = New System.Drawing.Point(18, 29)
        Me.cbFilters.Name = "cbFilters"
        Me.cbFilters.Size = New System.Drawing.Size(260, 21)
        Me.cbFilters.TabIndex = 10
        '
        'label105
        '
        Me.label105.AutoSize = True
        Me.label105.Location = New System.Drawing.Point(15, 14)
        Me.label105.Name = "label105"
        Me.label105.Size = New System.Drawing.Size(34, 13)
        Me.label105.TabIndex = 9
        Me.label105.Text = "Filters"
        '
        'TabPage81
        '
        Me.TabPage81.Controls.Add(Me.label177)
        Me.TabPage81.Controls.Add(Me.Label3)
        Me.TabPage81.Controls.Add(Me.btSubtitlesSelectFile)
        Me.TabPage81.Controls.Add(Me.edSubtitlesFilename)
        Me.TabPage81.Controls.Add(Me.Label130)
        Me.TabPage81.Controls.Add(Me.cbSubtitlesEnabled)
        Me.TabPage81.Location = New System.Drawing.Point(4, 22)
        Me.TabPage81.Name = "TabPage81"
        Me.TabPage81.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage81.Size = New System.Drawing.Size(290, 440)
        Me.TabPage81.TabIndex = 7
        Me.TabPage81.Text = "Subtitles"
        Me.TabPage81.UseVisualStyleBackColor = True
        '
        'label177
        '
        Me.label177.AutoSize = True
        Me.label177.Location = New System.Drawing.Point(10, 100)
        Me.label177.Name = "label177"
        Me.label177.Size = New System.Drawing.Size(82, 13)
        Me.label177.TabIndex = 11
        Me.label177.Text = " using interface."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Use OnSubtitleSettings event to set other settings"
        '
        'btSubtitlesSelectFile
        '
        Me.btSubtitlesSelectFile.Location = New System.Drawing.Point(250, 53)
        Me.btSubtitlesSelectFile.Name = "btSubtitlesSelectFile"
        Me.btSubtitlesSelectFile.Size = New System.Drawing.Size(23, 22)
        Me.btSubtitlesSelectFile.TabIndex = 9
        Me.btSubtitlesSelectFile.Text = "..."
        Me.btSubtitlesSelectFile.UseVisualStyleBackColor = True
        '
        'edSubtitlesFilename
        '
        Me.edSubtitlesFilename.Location = New System.Drawing.Point(13, 55)
        Me.edSubtitlesFilename.Name = "edSubtitlesFilename"
        Me.edSubtitlesFilename.Size = New System.Drawing.Size(232, 20)
        Me.edSubtitlesFilename.TabIndex = 8
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.Location = New System.Drawing.Point(10, 40)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(52, 13)
        Me.Label130.TabIndex = 7
        Me.Label130.Text = "File name"
        '
        'cbSubtitlesEnabled
        '
        Me.cbSubtitlesEnabled.AutoSize = True
        Me.cbSubtitlesEnabled.Location = New System.Drawing.Point(13, 16)
        Me.cbSubtitlesEnabled.Name = "cbSubtitlesEnabled"
        Me.cbSubtitlesEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbSubtitlesEnabled.TabIndex = 6
        Me.cbSubtitlesEnabled.Text = "Enabled"
        Me.cbSubtitlesEnabled.UseVisualStyleBackColor = True
        '
        'tabPage9
        '
        Me.tabPage9.Controls.Add(Me.groupBox5)
        Me.tabPage9.Controls.Add(Me.lbTransitions)
        Me.tabPage9.Controls.Add(Me.label43)
        Me.tabPage9.Location = New System.Drawing.Point(4, 22)
        Me.tabPage9.Name = "tabPage9"
        Me.tabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage9.Size = New System.Drawing.Size(302, 474)
        Me.tabPage9.TabIndex = 3
        Me.tabPage9.Text = "Transitions"
        Me.tabPage9.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.label47)
        Me.groupBox5.Controls.Add(Me.edTransStopTime)
        Me.groupBox5.Controls.Add(Me.label48)
        Me.groupBox5.Controls.Add(Me.label46)
        Me.groupBox5.Controls.Add(Me.edTransStartTime)
        Me.groupBox5.Controls.Add(Me.label45)
        Me.groupBox5.Controls.Add(Me.btAddTransition)
        Me.groupBox5.Controls.Add(Me.cbTransitionName)
        Me.groupBox5.Controls.Add(Me.label44)
        Me.groupBox5.Location = New System.Drawing.Point(20, 118)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(251, 138)
        Me.groupBox5.TabIndex = 2
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Add transition"
        '
        'label47
        '
        Me.label47.AutoSize = True
        Me.label47.Location = New System.Drawing.Point(133, 106)
        Me.label47.Name = "label47"
        Me.label47.Size = New System.Drawing.Size(20, 13)
        Me.label47.TabIndex = 8
        Me.label47.Text = "ms"
        '
        'edTransStopTime
        '
        Me.edTransStopTime.Location = New System.Drawing.Point(84, 103)
        Me.edTransStopTime.Name = "edTransStopTime"
        Me.edTransStopTime.Size = New System.Drawing.Size(43, 20)
        Me.edTransStopTime.TabIndex = 7
        Me.edTransStopTime.Text = "5000"
        '
        'label48
        '
        Me.label48.AutoSize = True
        Me.label48.Location = New System.Drawing.Point(12, 106)
        Me.label48.Name = "label48"
        Me.label48.Size = New System.Drawing.Size(51, 13)
        Me.label48.TabIndex = 6
        Me.label48.Text = "Stop time"
        '
        'label46
        '
        Me.label46.AutoSize = True
        Me.label46.Location = New System.Drawing.Point(133, 81)
        Me.label46.Name = "label46"
        Me.label46.Size = New System.Drawing.Size(20, 13)
        Me.label46.TabIndex = 5
        Me.label46.Text = "ms"
        '
        'edTransStartTime
        '
        Me.edTransStartTime.Location = New System.Drawing.Point(84, 78)
        Me.edTransStartTime.Name = "edTransStartTime"
        Me.edTransStartTime.Size = New System.Drawing.Size(43, 20)
        Me.edTransStartTime.TabIndex = 4
        Me.edTransStartTime.Text = "4000"
        '
        'label45
        '
        Me.label45.AutoSize = True
        Me.label45.Location = New System.Drawing.Point(12, 81)
        Me.label45.Name = "label45"
        Me.label45.Size = New System.Drawing.Size(51, 13)
        Me.label45.TabIndex = 3
        Me.label45.Text = "Start time"
        '
        'btAddTransition
        '
        Me.btAddTransition.Location = New System.Drawing.Point(203, 40)
        Me.btAddTransition.Name = "btAddTransition"
        Me.btAddTransition.Size = New System.Drawing.Size(42, 22)
        Me.btAddTransition.TabIndex = 2
        Me.btAddTransition.Text = "Add"
        Me.btAddTransition.UseVisualStyleBackColor = True
        '
        'cbTransitionName
        '
        Me.cbTransitionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTransitionName.FormattingEnabled = True
        Me.cbTransitionName.Location = New System.Drawing.Point(15, 42)
        Me.cbTransitionName.Name = "cbTransitionName"
        Me.cbTransitionName.Size = New System.Drawing.Size(182, 21)
        Me.cbTransitionName.TabIndex = 1
        '
        'label44
        '
        Me.label44.AutoSize = True
        Me.label44.Location = New System.Drawing.Point(12, 27)
        Me.label44.Name = "label44"
        Me.label44.Size = New System.Drawing.Size(35, 13)
        Me.label44.TabIndex = 0
        Me.label44.Text = "Name"
        '
        'lbTransitions
        '
        Me.lbTransitions.FormattingEnabled = True
        Me.lbTransitions.Location = New System.Drawing.Point(20, 34)
        Me.lbTransitions.Name = "lbTransitions"
        Me.lbTransitions.Size = New System.Drawing.Size(251, 56)
        Me.lbTransitions.TabIndex = 1
        '
        'label43
        '
        Me.label43.AutoSize = True
        Me.label43.Location = New System.Drawing.Point(17, 18)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(49, 13)
        Me.label43.TabIndex = 0
        Me.label43.Text = "Selected"
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.Label24)
        Me.tabPage3.Controls.Add(Me.tabControl18)
        Me.tabPage3.Controls.Add(Me.cbAudioEffectsEnabled)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(302, 474)
        Me.tabPage3.TabIndex = 5
        Me.tabPage3.Text = "Audio effects"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(96, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(188, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Much more effects available using API"
        '
        'tabControl18
        '
        Me.tabControl18.Controls.Add(Me.tabPage71)
        Me.tabControl18.Controls.Add(Me.tabPage72)
        Me.tabControl18.Controls.Add(Me.tabPage73)
        Me.tabControl18.Controls.Add(Me.tabPage75)
        Me.tabControl18.Controls.Add(Me.tabPage76)
        Me.tabControl18.Location = New System.Drawing.Point(10, 36)
        Me.tabControl18.Name = "tabControl18"
        Me.tabControl18.SelectedIndex = 0
        Me.tabControl18.Size = New System.Drawing.Size(283, 425)
        Me.tabControl18.TabIndex = 3
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
        Me.tabPage71.Size = New System.Drawing.Size(275, 399)
        Me.tabPage71.TabIndex = 0
        Me.tabPage71.Text = "Amplify"
        Me.tabPage71.UseVisualStyleBackColor = True
        '
        'label231
        '
        Me.label231.AutoSize = True
        Me.label231.Location = New System.Drawing.Point(213, 51)
        Me.label231.Name = "label231"
        Me.label231.Size = New System.Drawing.Size(33, 13)
        Me.label231.TabIndex = 5
        Me.label231.Text = "400%"
        '
        'label230
        '
        Me.label230.AutoSize = True
        Me.label230.Location = New System.Drawing.Point(68, 51)
        Me.label230.Name = "label230"
        Me.label230.Size = New System.Drawing.Size(33, 13)
        Me.label230.TabIndex = 4
        Me.label230.Text = "100%"
        '
        'tbAudAmplifyAmp
        '
        Me.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudAmplifyAmp.Location = New System.Drawing.Point(16, 66)
        Me.tbAudAmplifyAmp.Maximum = 4000
        Me.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp"
        Me.tbAudAmplifyAmp.Size = New System.Drawing.Size(230, 45)
        Me.tbAudAmplifyAmp.TabIndex = 3
        Me.tbAudAmplifyAmp.TickFrequency = 50
        Me.tbAudAmplifyAmp.Value = 1000
        '
        'label95
        '
        Me.label95.AutoSize = True
        Me.label95.Location = New System.Drawing.Point(13, 51)
        Me.label95.Name = "label95"
        Me.label95.Size = New System.Drawing.Size(42, 13)
        Me.label95.TabIndex = 2
        Me.label95.Text = "Volume"
        '
        'cbAudAmplifyEnabled
        '
        Me.cbAudAmplifyEnabled.AutoSize = True
        Me.cbAudAmplifyEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled"
        Me.cbAudAmplifyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudAmplifyEnabled.TabIndex = 1
        Me.cbAudAmplifyEnabled.Text = "Enabled"
        Me.cbAudAmplifyEnabled.UseVisualStyleBackColor = True
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
        Me.tabPage72.Size = New System.Drawing.Size(275, 399)
        Me.tabPage72.TabIndex = 1
        Me.tabPage72.Text = "Equlizer"
        Me.tabPage72.UseVisualStyleBackColor = True
        '
        'btAudEqRefresh
        '
        Me.btAudEqRefresh.Location = New System.Drawing.Point(175, 210)
        Me.btAudEqRefresh.Name = "btAudEqRefresh"
        Me.btAudEqRefresh.Size = New System.Drawing.Size(75, 22)
        Me.btAudEqRefresh.TabIndex = 26
        Me.btAudEqRefresh.Text = "Refresh"
        Me.btAudEqRefresh.UseVisualStyleBackColor = True
        '
        'cbAudEqualizerPreset
        '
        Me.cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudEqualizerPreset.FormattingEnabled = True
        Me.cbAudEqualizerPreset.Location = New System.Drawing.Point(61, 173)
        Me.cbAudEqualizerPreset.Name = "cbAudEqualizerPreset"
        Me.cbAudEqualizerPreset.Size = New System.Drawing.Size(189, 21)
        Me.cbAudEqualizerPreset.TabIndex = 25
        '
        'label243
        '
        Me.label243.AutoSize = True
        Me.label243.Location = New System.Drawing.Point(14, 176)
        Me.label243.Name = "label243"
        Me.label243.Size = New System.Drawing.Size(37, 13)
        Me.label243.TabIndex = 24
        Me.label243.Text = "Preset"
        '
        'label242
        '
        Me.label242.AutoSize = True
        Me.label242.Location = New System.Drawing.Point(206, 150)
        Me.label242.Name = "label242"
        Me.label242.Size = New System.Drawing.Size(26, 13)
        Me.label242.TabIndex = 23
        Me.label242.Text = "16K"
        '
        'label241
        '
        Me.label241.AutoSize = True
        Me.label241.Location = New System.Drawing.Point(184, 150)
        Me.label241.Name = "label241"
        Me.label241.Size = New System.Drawing.Size(26, 13)
        Me.label241.TabIndex = 22
        Me.label241.Text = "14K"
        '
        'label240
        '
        Me.label240.AutoSize = True
        Me.label240.Location = New System.Drawing.Point(162, 150)
        Me.label240.Name = "label240"
        Me.label240.Size = New System.Drawing.Size(26, 13)
        Me.label240.TabIndex = 21
        Me.label240.Text = "12K"
        '
        'label239
        '
        Me.label239.AutoSize = True
        Me.label239.Location = New System.Drawing.Point(143, 150)
        Me.label239.Name = "label239"
        Me.label239.Size = New System.Drawing.Size(20, 13)
        Me.label239.TabIndex = 20
        Me.label239.Text = "6K"
        '
        'label238
        '
        Me.label238.AutoSize = True
        Me.label238.Location = New System.Drawing.Point(121, 150)
        Me.label238.Name = "label238"
        Me.label238.Size = New System.Drawing.Size(20, 13)
        Me.label238.TabIndex = 19
        Me.label238.Text = "3K"
        '
        'label237
        '
        Me.label237.AutoSize = True
        Me.label237.Location = New System.Drawing.Point(102, 150)
        Me.label237.Name = "label237"
        Me.label237.Size = New System.Drawing.Size(20, 13)
        Me.label237.TabIndex = 18
        Me.label237.Text = "1K"
        '
        'label236
        '
        Me.label236.AutoSize = True
        Me.label236.Location = New System.Drawing.Point(80, 150)
        Me.label236.Name = "label236"
        Me.label236.Size = New System.Drawing.Size(25, 13)
        Me.label236.TabIndex = 17
        Me.label236.Text = "600"
        '
        'label235
        '
        Me.label235.AutoSize = True
        Me.label235.Location = New System.Drawing.Point(58, 150)
        Me.label235.Name = "label235"
        Me.label235.Size = New System.Drawing.Size(25, 13)
        Me.label235.TabIndex = 16
        Me.label235.Text = "310"
        '
        'label234
        '
        Me.label234.AutoSize = True
        Me.label234.Location = New System.Drawing.Point(36, 150)
        Me.label234.Name = "label234"
        Me.label234.Size = New System.Drawing.Size(25, 13)
        Me.label234.TabIndex = 15
        Me.label234.Text = "170"
        '
        'label233
        '
        Me.label233.AutoSize = True
        Me.label233.Location = New System.Drawing.Point(18, 150)
        Me.label233.Name = "label233"
        Me.label233.Size = New System.Drawing.Size(19, 13)
        Me.label233.TabIndex = 14
        Me.label233.Text = "60"
        '
        'label232
        '
        Me.label232.AutoSize = True
        Me.label232.Location = New System.Drawing.Point(118, 32)
        Me.label232.Name = "label232"
        Me.label232.Size = New System.Drawing.Size(13, 13)
        Me.label232.TabIndex = 13
        Me.label232.Text = "0"
        '
        'tbAudEq9
        '
        Me.tbAudEq9.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq9.Location = New System.Drawing.Point(205, 47)
        Me.tbAudEq9.Maximum = 100
        Me.tbAudEq9.Minimum = -100
        Me.tbAudEq9.Name = "tbAudEq9"
        Me.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq9.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq9.TabIndex = 12
        Me.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq8
        '
        Me.tbAudEq8.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq8.Location = New System.Drawing.Point(184, 47)
        Me.tbAudEq8.Maximum = 100
        Me.tbAudEq8.Minimum = -100
        Me.tbAudEq8.Name = "tbAudEq8"
        Me.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq8.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq8.TabIndex = 11
        Me.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq7
        '
        Me.tbAudEq7.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq7.Location = New System.Drawing.Point(162, 47)
        Me.tbAudEq7.Maximum = 100
        Me.tbAudEq7.Minimum = -100
        Me.tbAudEq7.Name = "tbAudEq7"
        Me.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq7.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq7.TabIndex = 10
        Me.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq6
        '
        Me.tbAudEq6.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq6.Location = New System.Drawing.Point(141, 47)
        Me.tbAudEq6.Maximum = 100
        Me.tbAudEq6.Minimum = -100
        Me.tbAudEq6.Name = "tbAudEq6"
        Me.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq6.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq6.TabIndex = 9
        Me.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq5
        '
        Me.tbAudEq5.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq5.Location = New System.Drawing.Point(120, 47)
        Me.tbAudEq5.Maximum = 100
        Me.tbAudEq5.Minimum = -100
        Me.tbAudEq5.Name = "tbAudEq5"
        Me.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq5.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq5.TabIndex = 8
        Me.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq4
        '
        Me.tbAudEq4.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq4.Location = New System.Drawing.Point(100, 47)
        Me.tbAudEq4.Maximum = 100
        Me.tbAudEq4.Minimum = -100
        Me.tbAudEq4.Name = "tbAudEq4"
        Me.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq4.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq4.TabIndex = 7
        Me.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq3
        '
        Me.tbAudEq3.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq3.Location = New System.Drawing.Point(79, 47)
        Me.tbAudEq3.Maximum = 100
        Me.tbAudEq3.Minimum = -100
        Me.tbAudEq3.Name = "tbAudEq3"
        Me.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq3.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq3.TabIndex = 6
        Me.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq2
        '
        Me.tbAudEq2.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq2.Location = New System.Drawing.Point(58, 47)
        Me.tbAudEq2.Maximum = 100
        Me.tbAudEq2.Minimum = -100
        Me.tbAudEq2.Name = "tbAudEq2"
        Me.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq2.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq2.TabIndex = 5
        Me.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq1
        '
        Me.tbAudEq1.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq1.Location = New System.Drawing.Point(37, 47)
        Me.tbAudEq1.Maximum = 100
        Me.tbAudEq1.Minimum = -100
        Me.tbAudEq1.Name = "tbAudEq1"
        Me.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq1.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq1.TabIndex = 4
        Me.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq0
        '
        Me.tbAudEq0.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq0.Location = New System.Drawing.Point(17, 47)
        Me.tbAudEq0.Maximum = 100
        Me.tbAudEq0.Minimum = -100
        Me.tbAudEq0.Name = "tbAudEq0"
        Me.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq0.Size = New System.Drawing.Size(45, 100)
        Me.tbAudEq0.TabIndex = 3
        Me.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'cbAudEqualizerEnabled
        '
        Me.cbAudEqualizerEnabled.AutoSize = True
        Me.cbAudEqualizerEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled"
        Me.cbAudEqualizerEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudEqualizerEnabled.TabIndex = 2
        Me.cbAudEqualizerEnabled.Text = "Enabled"
        Me.cbAudEqualizerEnabled.UseVisualStyleBackColor = True
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
        Me.tabPage73.Size = New System.Drawing.Size(275, 399)
        Me.tabPage73.TabIndex = 2
        Me.tabPage73.Text = "Dynamic amplify"
        Me.tabPage73.UseVisualStyleBackColor = True
        '
        'tbAudRelease
        '
        Me.tbAudRelease.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudRelease.Location = New System.Drawing.Point(16, 201)
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
        Me.label248.AutoSize = True
        Me.label248.Location = New System.Drawing.Point(233, 186)
        Me.label248.Name = "label248"
        Me.label248.Size = New System.Drawing.Size(13, 13)
        Me.label248.TabIndex = 14
        Me.label248.Text = "0"
        '
        'label249
        '
        Me.label249.AutoSize = True
        Me.label249.Location = New System.Drawing.Point(13, 186)
        Me.label249.Name = "label249"
        Me.label249.Size = New System.Drawing.Size(68, 13)
        Me.label249.TabIndex = 12
        Me.label249.Text = "Release time"
        '
        'label246
        '
        Me.label246.AutoSize = True
        Me.label246.Location = New System.Drawing.Point(233, 116)
        Me.label246.Name = "label246"
        Me.label246.Size = New System.Drawing.Size(13, 13)
        Me.label246.TabIndex = 11
        Me.label246.Text = "0"
        '
        'tbAudAttack
        '
        Me.tbAudAttack.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudAttack.Location = New System.Drawing.Point(16, 132)
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
        Me.label247.AutoSize = True
        Me.label247.Location = New System.Drawing.Point(13, 116)
        Me.label247.Name = "label247"
        Me.label247.Size = New System.Drawing.Size(38, 13)
        Me.label247.TabIndex = 9
        Me.label247.Text = "Attack"
        '
        'label244
        '
        Me.label244.AutoSize = True
        Me.label244.Location = New System.Drawing.Point(233, 51)
        Me.label244.Name = "label244"
        Me.label244.Size = New System.Drawing.Size(13, 13)
        Me.label244.TabIndex = 8
        Me.label244.Text = "0"
        '
        'tbAudDynAmp
        '
        Me.tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudDynAmp.Location = New System.Drawing.Point(16, 66)
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
        Me.label245.AutoSize = True
        Me.label245.Location = New System.Drawing.Point(13, 51)
        Me.label245.Name = "label245"
        Me.label245.Size = New System.Drawing.Size(112, 13)
        Me.label245.TabIndex = 6
        Me.label245.Text = "Maximum amplification"
        '
        'cbAudDynamicAmplifyEnabled
        '
        Me.cbAudDynamicAmplifyEnabled.AutoSize = True
        Me.cbAudDynamicAmplifyEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled"
        Me.cbAudDynamicAmplifyEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudDynamicAmplifyEnabled.TabIndex = 2
        Me.cbAudDynamicAmplifyEnabled.Text = "Enabled"
        Me.cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = True
        '
        'tabPage75
        '
        Me.tabPage75.Controls.Add(Me.tbAud3DSound)
        Me.tabPage75.Controls.Add(Me.label253)
        Me.tabPage75.Controls.Add(Me.cbAudSound3DEnabled)
        Me.tabPage75.Location = New System.Drawing.Point(4, 22)
        Me.tabPage75.Name = "tabPage75"
        Me.tabPage75.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage75.Size = New System.Drawing.Size(275, 399)
        Me.tabPage75.TabIndex = 4
        Me.tabPage75.Text = "Sound 3D"
        Me.tabPage75.UseVisualStyleBackColor = True
        '
        'tbAud3DSound
        '
        Me.tbAud3DSound.BackColor = System.Drawing.SystemColors.Window
        Me.tbAud3DSound.Location = New System.Drawing.Point(16, 66)
        Me.tbAud3DSound.Maximum = 10000
        Me.tbAud3DSound.Name = "tbAud3DSound"
        Me.tbAud3DSound.Size = New System.Drawing.Size(230, 45)
        Me.tbAud3DSound.TabIndex = 19
        Me.tbAud3DSound.TickFrequency = 250
        Me.tbAud3DSound.Value = 500
        '
        'label253
        '
        Me.label253.AutoSize = True
        Me.label253.Location = New System.Drawing.Point(13, 51)
        Me.label253.Name = "label253"
        Me.label253.Size = New System.Drawing.Size(82, 13)
        Me.label253.TabIndex = 18
        Me.label253.Text = "3D amplification"
        '
        'cbAudSound3DEnabled
        '
        Me.cbAudSound3DEnabled.AutoSize = True
        Me.cbAudSound3DEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudSound3DEnabled.Name = "cbAudSound3DEnabled"
        Me.cbAudSound3DEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudSound3DEnabled.TabIndex = 2
        Me.cbAudSound3DEnabled.Text = "Enabled"
        Me.cbAudSound3DEnabled.UseVisualStyleBackColor = True
        '
        'tabPage76
        '
        Me.tabPage76.Controls.Add(Me.tbAudTrueBass)
        Me.tabPage76.Controls.Add(Me.label254)
        Me.tabPage76.Controls.Add(Me.cbAudTrueBassEnabled)
        Me.tabPage76.Location = New System.Drawing.Point(4, 22)
        Me.tabPage76.Name = "tabPage76"
        Me.tabPage76.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage76.Size = New System.Drawing.Size(275, 399)
        Me.tabPage76.TabIndex = 5
        Me.tabPage76.Text = "True Bass"
        Me.tabPage76.UseVisualStyleBackColor = True
        '
        'tbAudTrueBass
        '
        Me.tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudTrueBass.Location = New System.Drawing.Point(16, 66)
        Me.tbAudTrueBass.Maximum = 10000
        Me.tbAudTrueBass.Name = "tbAudTrueBass"
        Me.tbAudTrueBass.Size = New System.Drawing.Size(230, 45)
        Me.tbAudTrueBass.TabIndex = 21
        Me.tbAudTrueBass.TickFrequency = 250
        '
        'label254
        '
        Me.label254.AutoSize = True
        Me.label254.Location = New System.Drawing.Point(13, 51)
        Me.label254.Name = "label254"
        Me.label254.Size = New System.Drawing.Size(42, 13)
        Me.label254.TabIndex = 20
        Me.label254.Text = "Volume"
        '
        'cbAudTrueBassEnabled
        '
        Me.cbAudTrueBassEnabled.AutoSize = True
        Me.cbAudTrueBassEnabled.Location = New System.Drawing.Point(16, 16)
        Me.cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled"
        Me.cbAudTrueBassEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudTrueBassEnabled.TabIndex = 2
        Me.cbAudTrueBassEnabled.Text = "Enabled"
        Me.cbAudTrueBassEnabled.UseVisualStyleBackColor = True
        '
        'cbAudioEffectsEnabled
        '
        Me.cbAudioEffectsEnabled.AutoSize = True
        Me.cbAudioEffectsEnabled.Location = New System.Drawing.Point(10, 14)
        Me.cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled"
        Me.cbAudioEffectsEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioEffectsEnabled.TabIndex = 2
        Me.cbAudioEffectsEnabled.Text = "Enabled"
        Me.cbAudioEffectsEnabled.UseVisualStyleBackColor = True
        '
        'TabPage57
        '
        Me.TabPage57.Controls.Add(Me.lbAudioTimeshift)
        Me.TabPage57.Controls.Add(Me.tbAudioTimeshift)
        Me.TabPage57.Controls.Add(Me.label115)
        Me.TabPage57.Controls.Add(Me.groupBox1)
        Me.TabPage57.Controls.Add(Me.groupBox2)
        Me.TabPage57.Controls.Add(Me.cbAudioAutoGain)
        Me.TabPage57.Controls.Add(Me.cbAudioNormalize)
        Me.TabPage57.Controls.Add(Me.cbAudioEnhancementEnabled)
        Me.TabPage57.Location = New System.Drawing.Point(4, 22)
        Me.TabPage57.Name = "TabPage57"
        Me.TabPage57.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage57.Size = New System.Drawing.Size(302, 474)
        Me.TabPage57.TabIndex = 13
        Me.TabPage57.Text = "Audio enhancement"
        Me.TabPage57.UseVisualStyleBackColor = True
        '
        'lbAudioTimeshift
        '
        Me.lbAudioTimeshift.AutoSize = True
        Me.lbAudioTimeshift.Location = New System.Drawing.Point(176, 431)
        Me.lbAudioTimeshift.Name = "lbAudioTimeshift"
        Me.lbAudioTimeshift.Size = New System.Drawing.Size(29, 13)
        Me.lbAudioTimeshift.TabIndex = 20
        Me.lbAudioTimeshift.Text = "0 ms"
        '
        'tbAudioTimeshift
        '
        Me.tbAudioTimeshift.Location = New System.Drawing.Point(66, 420)
        Me.tbAudioTimeshift.Maximum = 3000
        Me.tbAudioTimeshift.Name = "tbAudioTimeshift"
        Me.tbAudioTimeshift.Size = New System.Drawing.Size(104, 45)
        Me.tbAudioTimeshift.SmallChange = 10
        Me.tbAudioTimeshift.TabIndex = 19
        Me.tbAudioTimeshift.TickFrequency = 100
        Me.tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label115
        '
        Me.label115.AutoSize = True
        Me.label115.Location = New System.Drawing.Point(5, 431)
        Me.label115.Name = "label115"
        Me.label115.Size = New System.Drawing.Size(52, 13)
        Me.label115.TabIndex = 18
        Me.label115.Text = "Time shift"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainLFE)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainLFE)
        Me.groupBox1.Controls.Add(Me.label116)
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainSR)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainSR)
        Me.groupBox1.Controls.Add(Me.label117)
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainSL)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainSL)
        Me.groupBox1.Controls.Add(Me.label118)
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainR)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainR)
        Me.groupBox1.Controls.Add(Me.label119)
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainC)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainC)
        Me.groupBox1.Controls.Add(Me.label121)
        Me.groupBox1.Controls.Add(Me.lbAudioOutputGainL)
        Me.groupBox1.Controls.Add(Me.tbAudioOutputGainL)
        Me.groupBox1.Controls.Add(Me.label122)
        Me.groupBox1.Location = New System.Drawing.Point(8, 247)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(289, 166)
        Me.groupBox1.TabIndex = 17
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Output gains (dB)"
        '
        'lbAudioOutputGainLFE
        '
        Me.lbAudioOutputGainLFE.AutoSize = True
        Me.lbAudioOutputGainLFE.Location = New System.Drawing.Point(249, 142)
        Me.lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE"
        Me.lbAudioOutputGainLFE.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainLFE.TabIndex = 17
        Me.lbAudioOutputGainLFE.Text = "0.0"
        '
        'tbAudioOutputGainLFE
        '
        Me.tbAudioOutputGainLFE.Location = New System.Drawing.Point(242, 40)
        Me.tbAudioOutputGainLFE.Maximum = 200
        Me.tbAudioOutputGainLFE.Minimum = -200
        Me.tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE"
        Me.tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainLFE.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainLFE.TabIndex = 16
        Me.tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label116
        '
        Me.label116.AutoSize = True
        Me.label116.Location = New System.Drawing.Point(250, 24)
        Me.label116.Name = "label116"
        Me.label116.Size = New System.Drawing.Size(26, 13)
        Me.label116.TabIndex = 15
        Me.label116.Text = "LFE"
        '
        'lbAudioOutputGainSR
        '
        Me.lbAudioOutputGainSR.AutoSize = True
        Me.lbAudioOutputGainSR.Location = New System.Drawing.Point(201, 142)
        Me.lbAudioOutputGainSR.Name = "lbAudioOutputGainSR"
        Me.lbAudioOutputGainSR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainSR.TabIndex = 14
        Me.lbAudioOutputGainSR.Text = "0.0"
        '
        'tbAudioOutputGainSR
        '
        Me.tbAudioOutputGainSR.Location = New System.Drawing.Point(194, 40)
        Me.tbAudioOutputGainSR.Maximum = 200
        Me.tbAudioOutputGainSR.Minimum = -200
        Me.tbAudioOutputGainSR.Name = "tbAudioOutputGainSR"
        Me.tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainSR.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainSR.TabIndex = 13
        Me.tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label117
        '
        Me.label117.AutoSize = True
        Me.label117.Location = New System.Drawing.Point(205, 24)
        Me.label117.Name = "label117"
        Me.label117.Size = New System.Drawing.Size(22, 13)
        Me.label117.TabIndex = 12
        Me.label117.Text = "SR"
        '
        'lbAudioOutputGainSL
        '
        Me.lbAudioOutputGainSL.AutoSize = True
        Me.lbAudioOutputGainSL.Location = New System.Drawing.Point(153, 142)
        Me.lbAudioOutputGainSL.Name = "lbAudioOutputGainSL"
        Me.lbAudioOutputGainSL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainSL.TabIndex = 11
        Me.lbAudioOutputGainSL.Text = "0.0"
        '
        'tbAudioOutputGainSL
        '
        Me.tbAudioOutputGainSL.Location = New System.Drawing.Point(146, 40)
        Me.tbAudioOutputGainSL.Maximum = 200
        Me.tbAudioOutputGainSL.Minimum = -200
        Me.tbAudioOutputGainSL.Name = "tbAudioOutputGainSL"
        Me.tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainSL.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainSL.TabIndex = 10
        Me.tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label118
        '
        Me.label118.AutoSize = True
        Me.label118.Location = New System.Drawing.Point(158, 24)
        Me.label118.Name = "label118"
        Me.label118.Size = New System.Drawing.Size(20, 13)
        Me.label118.TabIndex = 9
        Me.label118.Text = "SL"
        '
        'lbAudioOutputGainR
        '
        Me.lbAudioOutputGainR.AutoSize = True
        Me.lbAudioOutputGainR.Location = New System.Drawing.Point(105, 142)
        Me.lbAudioOutputGainR.Name = "lbAudioOutputGainR"
        Me.lbAudioOutputGainR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainR.TabIndex = 8
        Me.lbAudioOutputGainR.Text = "0.0"
        '
        'tbAudioOutputGainR
        '
        Me.tbAudioOutputGainR.Location = New System.Drawing.Point(98, 40)
        Me.tbAudioOutputGainR.Maximum = 200
        Me.tbAudioOutputGainR.Minimum = -200
        Me.tbAudioOutputGainR.Name = "tbAudioOutputGainR"
        Me.tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainR.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainR.TabIndex = 7
        Me.tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label119
        '
        Me.label119.AutoSize = True
        Me.label119.Location = New System.Drawing.Point(114, 24)
        Me.label119.Name = "label119"
        Me.label119.Size = New System.Drawing.Size(15, 13)
        Me.label119.TabIndex = 6
        Me.label119.Text = "R"
        '
        'lbAudioOutputGainC
        '
        Me.lbAudioOutputGainC.AutoSize = True
        Me.lbAudioOutputGainC.Location = New System.Drawing.Point(57, 142)
        Me.lbAudioOutputGainC.Name = "lbAudioOutputGainC"
        Me.lbAudioOutputGainC.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainC.TabIndex = 5
        Me.lbAudioOutputGainC.Text = "0.0"
        '
        'tbAudioOutputGainC
        '
        Me.tbAudioOutputGainC.Location = New System.Drawing.Point(50, 40)
        Me.tbAudioOutputGainC.Maximum = 200
        Me.tbAudioOutputGainC.Minimum = -200
        Me.tbAudioOutputGainC.Name = "tbAudioOutputGainC"
        Me.tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainC.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainC.TabIndex = 4
        Me.tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label121
        '
        Me.label121.AutoSize = True
        Me.label121.Location = New System.Drawing.Point(66, 24)
        Me.label121.Name = "label121"
        Me.label121.Size = New System.Drawing.Size(14, 13)
        Me.label121.TabIndex = 3
        Me.label121.Text = "C"
        '
        'lbAudioOutputGainL
        '
        Me.lbAudioOutputGainL.AutoSize = True
        Me.lbAudioOutputGainL.Location = New System.Drawing.Point(9, 142)
        Me.lbAudioOutputGainL.Name = "lbAudioOutputGainL"
        Me.lbAudioOutputGainL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioOutputGainL.TabIndex = 2
        Me.lbAudioOutputGainL.Text = "0.0"
        '
        'tbAudioOutputGainL
        '
        Me.tbAudioOutputGainL.Location = New System.Drawing.Point(2, 40)
        Me.tbAudioOutputGainL.Maximum = 200
        Me.tbAudioOutputGainL.Minimum = -200
        Me.tbAudioOutputGainL.Name = "tbAudioOutputGainL"
        Me.tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioOutputGainL.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioOutputGainL.TabIndex = 1
        Me.tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label122
        '
        Me.label122.AutoSize = True
        Me.label122.Location = New System.Drawing.Point(18, 24)
        Me.label122.Name = "label122"
        Me.label122.Size = New System.Drawing.Size(13, 13)
        Me.label122.TabIndex = 0
        Me.label122.Text = "L"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainLFE)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainLFE)
        Me.groupBox2.Controls.Add(Me.label123)
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainSR)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainSR)
        Me.groupBox2.Controls.Add(Me.label124)
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainSL)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainSL)
        Me.groupBox2.Controls.Add(Me.label125)
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainR)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainR)
        Me.groupBox2.Controls.Add(Me.label126)
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainC)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainC)
        Me.groupBox2.Controls.Add(Me.label127)
        Me.groupBox2.Controls.Add(Me.lbAudioInputGainL)
        Me.groupBox2.Controls.Add(Me.tbAudioInputGainL)
        Me.groupBox2.Controls.Add(Me.label128)
        Me.groupBox2.Location = New System.Drawing.Point(8, 76)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(289, 166)
        Me.groupBox2.TabIndex = 16
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Input gains (dB)"
        '
        'lbAudioInputGainLFE
        '
        Me.lbAudioInputGainLFE.AutoSize = True
        Me.lbAudioInputGainLFE.Location = New System.Drawing.Point(249, 142)
        Me.lbAudioInputGainLFE.Name = "lbAudioInputGainLFE"
        Me.lbAudioInputGainLFE.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainLFE.TabIndex = 17
        Me.lbAudioInputGainLFE.Text = "0.0"
        '
        'tbAudioInputGainLFE
        '
        Me.tbAudioInputGainLFE.Location = New System.Drawing.Point(242, 40)
        Me.tbAudioInputGainLFE.Maximum = 200
        Me.tbAudioInputGainLFE.Minimum = -200
        Me.tbAudioInputGainLFE.Name = "tbAudioInputGainLFE"
        Me.tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainLFE.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainLFE.TabIndex = 16
        Me.tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label123
        '
        Me.label123.AutoSize = True
        Me.label123.Location = New System.Drawing.Point(250, 24)
        Me.label123.Name = "label123"
        Me.label123.Size = New System.Drawing.Size(26, 13)
        Me.label123.TabIndex = 15
        Me.label123.Text = "LFE"
        '
        'lbAudioInputGainSR
        '
        Me.lbAudioInputGainSR.AutoSize = True
        Me.lbAudioInputGainSR.Location = New System.Drawing.Point(201, 142)
        Me.lbAudioInputGainSR.Name = "lbAudioInputGainSR"
        Me.lbAudioInputGainSR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainSR.TabIndex = 14
        Me.lbAudioInputGainSR.Text = "0.0"
        '
        'tbAudioInputGainSR
        '
        Me.tbAudioInputGainSR.Location = New System.Drawing.Point(194, 40)
        Me.tbAudioInputGainSR.Maximum = 200
        Me.tbAudioInputGainSR.Minimum = -200
        Me.tbAudioInputGainSR.Name = "tbAudioInputGainSR"
        Me.tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainSR.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainSR.TabIndex = 13
        Me.tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label124
        '
        Me.label124.AutoSize = True
        Me.label124.Location = New System.Drawing.Point(205, 24)
        Me.label124.Name = "label124"
        Me.label124.Size = New System.Drawing.Size(22, 13)
        Me.label124.TabIndex = 12
        Me.label124.Text = "SR"
        '
        'lbAudioInputGainSL
        '
        Me.lbAudioInputGainSL.AutoSize = True
        Me.lbAudioInputGainSL.Location = New System.Drawing.Point(153, 142)
        Me.lbAudioInputGainSL.Name = "lbAudioInputGainSL"
        Me.lbAudioInputGainSL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainSL.TabIndex = 11
        Me.lbAudioInputGainSL.Text = "0.0"
        '
        'tbAudioInputGainSL
        '
        Me.tbAudioInputGainSL.Location = New System.Drawing.Point(146, 40)
        Me.tbAudioInputGainSL.Maximum = 200
        Me.tbAudioInputGainSL.Minimum = -200
        Me.tbAudioInputGainSL.Name = "tbAudioInputGainSL"
        Me.tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainSL.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainSL.TabIndex = 10
        Me.tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label125
        '
        Me.label125.AutoSize = True
        Me.label125.Location = New System.Drawing.Point(158, 24)
        Me.label125.Name = "label125"
        Me.label125.Size = New System.Drawing.Size(20, 13)
        Me.label125.TabIndex = 9
        Me.label125.Text = "SL"
        '
        'lbAudioInputGainR
        '
        Me.lbAudioInputGainR.AutoSize = True
        Me.lbAudioInputGainR.Location = New System.Drawing.Point(105, 142)
        Me.lbAudioInputGainR.Name = "lbAudioInputGainR"
        Me.lbAudioInputGainR.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainR.TabIndex = 8
        Me.lbAudioInputGainR.Text = "0.0"
        '
        'tbAudioInputGainR
        '
        Me.tbAudioInputGainR.Location = New System.Drawing.Point(98, 40)
        Me.tbAudioInputGainR.Maximum = 200
        Me.tbAudioInputGainR.Minimum = -200
        Me.tbAudioInputGainR.Name = "tbAudioInputGainR"
        Me.tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainR.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainR.TabIndex = 7
        Me.tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label126
        '
        Me.label126.AutoSize = True
        Me.label126.Location = New System.Drawing.Point(114, 24)
        Me.label126.Name = "label126"
        Me.label126.Size = New System.Drawing.Size(15, 13)
        Me.label126.TabIndex = 6
        Me.label126.Text = "R"
        '
        'lbAudioInputGainC
        '
        Me.lbAudioInputGainC.AutoSize = True
        Me.lbAudioInputGainC.Location = New System.Drawing.Point(57, 142)
        Me.lbAudioInputGainC.Name = "lbAudioInputGainC"
        Me.lbAudioInputGainC.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainC.TabIndex = 5
        Me.lbAudioInputGainC.Text = "0.0"
        '
        'tbAudioInputGainC
        '
        Me.tbAudioInputGainC.Location = New System.Drawing.Point(50, 40)
        Me.tbAudioInputGainC.Maximum = 200
        Me.tbAudioInputGainC.Minimum = -200
        Me.tbAudioInputGainC.Name = "tbAudioInputGainC"
        Me.tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainC.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainC.TabIndex = 4
        Me.tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label127
        '
        Me.label127.AutoSize = True
        Me.label127.Location = New System.Drawing.Point(66, 24)
        Me.label127.Name = "label127"
        Me.label127.Size = New System.Drawing.Size(14, 13)
        Me.label127.TabIndex = 3
        Me.label127.Text = "C"
        '
        'lbAudioInputGainL
        '
        Me.lbAudioInputGainL.AutoSize = True
        Me.lbAudioInputGainL.Location = New System.Drawing.Point(9, 142)
        Me.lbAudioInputGainL.Name = "lbAudioInputGainL"
        Me.lbAudioInputGainL.Size = New System.Drawing.Size(22, 13)
        Me.lbAudioInputGainL.TabIndex = 2
        Me.lbAudioInputGainL.Text = "0.0"
        '
        'tbAudioInputGainL
        '
        Me.tbAudioInputGainL.Location = New System.Drawing.Point(2, 40)
        Me.tbAudioInputGainL.Maximum = 200
        Me.tbAudioInputGainL.Minimum = -200
        Me.tbAudioInputGainL.Name = "tbAudioInputGainL"
        Me.tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioInputGainL.Size = New System.Drawing.Size(45, 100)
        Me.tbAudioInputGainL.TabIndex = 1
        Me.tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'label128
        '
        Me.label128.AutoSize = True
        Me.label128.Location = New System.Drawing.Point(18, 24)
        Me.label128.Name = "label128"
        Me.label128.Size = New System.Drawing.Size(13, 13)
        Me.label128.TabIndex = 0
        Me.label128.Text = "L"
        '
        'cbAudioAutoGain
        '
        Me.cbAudioAutoGain.AutoSize = True
        Me.cbAudioAutoGain.Location = New System.Drawing.Point(135, 44)
        Me.cbAudioAutoGain.Name = "cbAudioAutoGain"
        Me.cbAudioAutoGain.Size = New System.Drawing.Size(71, 17)
        Me.cbAudioAutoGain.TabIndex = 15
        Me.cbAudioAutoGain.Text = "Auto gain"
        Me.cbAudioAutoGain.UseVisualStyleBackColor = True
        '
        'cbAudioNormalize
        '
        Me.cbAudioNormalize.AutoSize = True
        Me.cbAudioNormalize.Location = New System.Drawing.Point(41, 44)
        Me.cbAudioNormalize.Name = "cbAudioNormalize"
        Me.cbAudioNormalize.Size = New System.Drawing.Size(72, 17)
        Me.cbAudioNormalize.TabIndex = 14
        Me.cbAudioNormalize.Text = "Normalize"
        Me.cbAudioNormalize.UseVisualStyleBackColor = True
        '
        'cbAudioEnhancementEnabled
        '
        Me.cbAudioEnhancementEnabled.AutoSize = True
        Me.cbAudioEnhancementEnabled.Location = New System.Drawing.Point(18, 12)
        Me.cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled"
        Me.cbAudioEnhancementEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioEnhancementEnabled.TabIndex = 13
        Me.cbAudioEnhancementEnabled.Text = "Enabled"
        Me.cbAudioEnhancementEnabled.UseVisualStyleBackColor = True
        '
        'TabPage80
        '
        Me.TabPage80.Controls.Add(Me.btAudioChannelMapperClear)
        Me.TabPage80.Controls.Add(Me.groupBox41)
        Me.TabPage80.Controls.Add(Me.label307)
        Me.TabPage80.Controls.Add(Me.edAudioChannelMapperOutputChannels)
        Me.TabPage80.Controls.Add(Me.label306)
        Me.TabPage80.Controls.Add(Me.lbAudioChannelMapperRoutes)
        Me.TabPage80.Controls.Add(Me.cbAudioChannelMapperEnabled)
        Me.TabPage80.Location = New System.Drawing.Point(4, 22)
        Me.TabPage80.Name = "TabPage80"
        Me.TabPage80.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage80.Size = New System.Drawing.Size(302, 474)
        Me.TabPage80.TabIndex = 15
        Me.TabPage80.Text = "Audio channel mapper"
        Me.TabPage80.UseVisualStyleBackColor = True
        '
        'btAudioChannelMapperClear
        '
        Me.btAudioChannelMapperClear.Location = New System.Drawing.Point(202, 210)
        Me.btAudioChannelMapperClear.Name = "btAudioChannelMapperClear"
        Me.btAudioChannelMapperClear.Size = New System.Drawing.Size(75, 22)
        Me.btAudioChannelMapperClear.TabIndex = 28
        Me.btAudioChannelMapperClear.Text = "Clear"
        Me.btAudioChannelMapperClear.UseVisualStyleBackColor = True
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
        Me.groupBox41.Location = New System.Drawing.Point(4, 238)
        Me.groupBox41.Name = "groupBox41"
        Me.groupBox41.Size = New System.Drawing.Size(292, 164)
        Me.groupBox41.TabIndex = 27
        Me.groupBox41.TabStop = False
        Me.groupBox41.Text = "Add new route"
        '
        'btAudioChannelMapperAddNewRoute
        '
        Me.btAudioChannelMapperAddNewRoute.Location = New System.Drawing.Point(108, 126)
        Me.btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute"
        Me.btAudioChannelMapperAddNewRoute.Size = New System.Drawing.Size(75, 22)
        Me.btAudioChannelMapperAddNewRoute.TabIndex = 20
        Me.btAudioChannelMapperAddNewRoute.Text = "Add"
        Me.btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = True
        '
        'label311
        '
        Me.label311.AutoSize = True
        Me.label311.Location = New System.Drawing.Point(205, 86)
        Me.label311.Name = "label311"
        Me.label311.Size = New System.Drawing.Size(62, 13)
        Me.label311.TabIndex = 19
        Me.label311.Text = "10% - 200%"
        '
        'tbAudioChannelMapperVolume
        '
        Me.tbAudioChannelMapperVolume.Location = New System.Drawing.Point(208, 40)
        Me.tbAudioChannelMapperVolume.Maximum = 2000
        Me.tbAudioChannelMapperVolume.Minimum = 100
        Me.tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume"
        Me.tbAudioChannelMapperVolume.Size = New System.Drawing.Size(74, 45)
        Me.tbAudioChannelMapperVolume.TabIndex = 18
        Me.tbAudioChannelMapperVolume.Value = 1000
        '
        'label310
        '
        Me.label310.AutoSize = True
        Me.label310.Location = New System.Drawing.Point(205, 24)
        Me.label310.Name = "label310"
        Me.label310.Size = New System.Drawing.Size(42, 13)
        Me.label310.TabIndex = 17
        Me.label310.Text = "Volume"
        '
        'edAudioChannelMapperTargetChannel
        '
        Me.edAudioChannelMapperTargetChannel.Location = New System.Drawing.Point(108, 40)
        Me.edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel"
        Me.edAudioChannelMapperTargetChannel.Size = New System.Drawing.Size(51, 20)
        Me.edAudioChannelMapperTargetChannel.TabIndex = 16
        Me.edAudioChannelMapperTargetChannel.Text = "0"
        '
        'label309
        '
        Me.label309.AutoSize = True
        Me.label309.Location = New System.Drawing.Point(105, 24)
        Me.label309.Name = "label309"
        Me.label309.Size = New System.Drawing.Size(79, 13)
        Me.label309.TabIndex = 15
        Me.label309.Text = "Target channel"
        '
        'edAudioChannelMapperSourceChannel
        '
        Me.edAudioChannelMapperSourceChannel.Location = New System.Drawing.Point(15, 40)
        Me.edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel"
        Me.edAudioChannelMapperSourceChannel.Size = New System.Drawing.Size(51, 20)
        Me.edAudioChannelMapperSourceChannel.TabIndex = 14
        Me.edAudioChannelMapperSourceChannel.Text = "0"
        '
        'label308
        '
        Me.label308.AutoSize = True
        Me.label308.Location = New System.Drawing.Point(12, 24)
        Me.label308.Name = "label308"
        Me.label308.Size = New System.Drawing.Size(82, 13)
        Me.label308.TabIndex = 13
        Me.label308.Text = "Source channel"
        '
        'label307
        '
        Me.label307.AutoSize = True
        Me.label307.Location = New System.Drawing.Point(7, 96)
        Me.label307.Name = "label307"
        Me.label307.Size = New System.Drawing.Size(41, 13)
        Me.label307.TabIndex = 26
        Me.label307.Text = "Routes"
        '
        'edAudioChannelMapperOutputChannels
        '
        Me.edAudioChannelMapperOutputChannels.Location = New System.Drawing.Point(10, 58)
        Me.edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels"
        Me.edAudioChannelMapperOutputChannels.Size = New System.Drawing.Size(42, 20)
        Me.edAudioChannelMapperOutputChannels.TabIndex = 25
        Me.edAudioChannelMapperOutputChannels.Text = "0"
        '
        'label306
        '
        Me.label306.AutoSize = True
        Me.label306.Location = New System.Drawing.Point(7, 44)
        Me.label306.Name = "label306"
        Me.label306.Size = New System.Drawing.Size(274, 13)
        Me.label306.TabIndex = 24
        Me.label306.Text = "Output channels count (0 to use original channels count)"
        '
        'lbAudioChannelMapperRoutes
        '
        Me.lbAudioChannelMapperRoutes.FormattingEnabled = True
        Me.lbAudioChannelMapperRoutes.Location = New System.Drawing.Point(10, 114)
        Me.lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes"
        Me.lbAudioChannelMapperRoutes.Size = New System.Drawing.Size(267, 69)
        Me.lbAudioChannelMapperRoutes.TabIndex = 23
        '
        'cbAudioChannelMapperEnabled
        '
        Me.cbAudioChannelMapperEnabled.AutoSize = True
        Me.cbAudioChannelMapperEnabled.Location = New System.Drawing.Point(10, 10)
        Me.cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled"
        Me.cbAudioChannelMapperEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbAudioChannelMapperEnabled.TabIndex = 22
        Me.cbAudioChannelMapperEnabled.Text = "Enabled"
        Me.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = True
        '
        'TabPage28
        '
        Me.TabPage28.Controls.Add(Me.tabControl9)
        Me.TabPage28.Controls.Add(Me.cbMotDetEnabled)
        Me.TabPage28.Location = New System.Drawing.Point(4, 22)
        Me.TabPage28.Name = "TabPage28"
        Me.TabPage28.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage28.Size = New System.Drawing.Size(302, 474)
        Me.TabPage28.TabIndex = 7
        Me.TabPage28.Text = "Motion detection"
        Me.TabPage28.UseVisualStyleBackColor = True
        '
        'tabControl9
        '
        Me.tabControl9.Controls.Add(Me.tabPage44)
        Me.tabControl9.Controls.Add(Me.tabPage45)
        Me.tabControl9.Location = New System.Drawing.Point(15, 44)
        Me.tabControl9.Name = "tabControl9"
        Me.tabControl9.SelectedIndex = 0
        Me.tabControl9.Size = New System.Drawing.Size(268, 397)
        Me.tabControl9.TabIndex = 5
        '
        'tabPage44
        '
        Me.tabPage44.Controls.Add(Me.pbMotionLevel)
        Me.tabPage44.Controls.Add(Me.label158)
        Me.tabPage44.Controls.Add(Me.mmMotDetMatrix)
        Me.tabPage44.Location = New System.Drawing.Point(4, 22)
        Me.tabPage44.Name = "tabPage44"
        Me.tabPage44.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage44.Size = New System.Drawing.Size(260, 371)
        Me.tabPage44.TabIndex = 0
        Me.tabPage44.Text = "Output matrix"
        Me.tabPage44.UseVisualStyleBackColor = True
        '
        'pbMotionLevel
        '
        Me.pbMotionLevel.Location = New System.Drawing.Point(17, 324)
        Me.pbMotionLevel.Name = "pbMotionLevel"
        Me.pbMotionLevel.Size = New System.Drawing.Size(225, 18)
        Me.pbMotionLevel.TabIndex = 2
        '
        'label158
        '
        Me.label158.AutoSize = True
        Me.label158.Location = New System.Drawing.Point(14, 305)
        Me.label158.Name = "label158"
        Me.label158.Size = New System.Drawing.Size(64, 13)
        Me.label158.TabIndex = 1
        Me.label158.Text = "Motion level"
        '
        'mmMotDetMatrix
        '
        Me.mmMotDetMatrix.Location = New System.Drawing.Point(6, 6)
        Me.mmMotDetMatrix.Multiline = True
        Me.mmMotDetMatrix.Name = "mmMotDetMatrix"
        Me.mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.mmMotDetMatrix.Size = New System.Drawing.Size(248, 248)
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
        Me.tabPage45.Size = New System.Drawing.Size(260, 371)
        Me.tabPage45.TabIndex = 1
        Me.tabPage45.Text = "Settings"
        Me.tabPage45.UseVisualStyleBackColor = True
        '
        'groupBox25
        '
        Me.groupBox25.Controls.Add(Me.cbMotDetHLColor)
        Me.groupBox25.Controls.Add(Me.label161)
        Me.groupBox25.Controls.Add(Me.label160)
        Me.groupBox25.Controls.Add(Me.cbMotDetHLEnabled)
        Me.groupBox25.Controls.Add(Me.tbMotDetHLThreshold)
        Me.groupBox25.Location = New System.Drawing.Point(12, 99)
        Me.groupBox25.Name = "groupBox25"
        Me.groupBox25.Size = New System.Drawing.Size(233, 82)
        Me.groupBox25.TabIndex = 1
        Me.groupBox25.TabStop = False
        Me.groupBox25.Text = "Color highlight"
        '
        'cbMotDetHLColor
        '
        Me.cbMotDetHLColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMotDetHLColor.FormattingEnabled = True
        Me.cbMotDetHLColor.Items.AddRange(New Object() {"Red", "Green", "Blue"})
        Me.cbMotDetHLColor.Location = New System.Drawing.Point(153, 56)
        Me.cbMotDetHLColor.Name = "cbMotDetHLColor"
        Me.cbMotDetHLColor.Size = New System.Drawing.Size(70, 21)
        Me.cbMotDetHLColor.TabIndex = 5
        '
        'label161
        '
        Me.label161.AutoSize = True
        Me.label161.Location = New System.Drawing.Point(148, 40)
        Me.label161.Name = "label161"
        Me.label161.Size = New System.Drawing.Size(31, 13)
        Me.label161.TabIndex = 4
        Me.label161.Text = "Color"
        '
        'label160
        '
        Me.label160.AutoSize = True
        Me.label160.Location = New System.Drawing.Point(30, 40)
        Me.label160.Name = "label160"
        Me.label160.Size = New System.Drawing.Size(54, 13)
        Me.label160.TabIndex = 2
        Me.label160.Text = "Threshold"
        '
        'cbMotDetHLEnabled
        '
        Me.cbMotDetHLEnabled.AutoSize = True
        Me.cbMotDetHLEnabled.Checked = True
        Me.cbMotDetHLEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMotDetHLEnabled.Location = New System.Drawing.Point(14, 21)
        Me.cbMotDetHLEnabled.Name = "cbMotDetHLEnabled"
        Me.cbMotDetHLEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetHLEnabled.TabIndex = 1
        Me.cbMotDetHLEnabled.Text = "Enabled"
        Me.cbMotDetHLEnabled.UseVisualStyleBackColor = True
        '
        'tbMotDetHLThreshold
        '
        Me.tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window
        Me.tbMotDetHLThreshold.Location = New System.Drawing.Point(31, 56)
        Me.tbMotDetHLThreshold.Maximum = 255
        Me.tbMotDetHLThreshold.Name = "tbMotDetHLThreshold"
        Me.tbMotDetHLThreshold.Size = New System.Drawing.Size(104, 45)
        Me.tbMotDetHLThreshold.TabIndex = 3
        Me.tbMotDetHLThreshold.TickFrequency = 5
        Me.tbMotDetHLThreshold.Value = 25
        '
        'btMotDetUpdateSettings
        '
        Me.btMotDetUpdateSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btMotDetUpdateSettings.Location = New System.Drawing.Point(138, 344)
        Me.btMotDetUpdateSettings.Name = "btMotDetUpdateSettings"
        Me.btMotDetUpdateSettings.Size = New System.Drawing.Size(107, 22)
        Me.btMotDetUpdateSettings.TabIndex = 4
        Me.btMotDetUpdateSettings.Text = "Update settings"
        Me.btMotDetUpdateSettings.UseVisualStyleBackColor = True
        '
        'groupBox27
        '
        Me.groupBox27.Controls.Add(Me.edMotDetMatrixHeight)
        Me.groupBox27.Controls.Add(Me.label163)
        Me.groupBox27.Controls.Add(Me.edMotDetMatrixWidth)
        Me.groupBox27.Controls.Add(Me.label164)
        Me.groupBox27.Location = New System.Drawing.Point(12, 256)
        Me.groupBox27.Name = "groupBox27"
        Me.groupBox27.Size = New System.Drawing.Size(233, 56)
        Me.groupBox27.TabIndex = 3
        Me.groupBox27.TabStop = False
        Me.groupBox27.Text = "Matrix"
        '
        'edMotDetMatrixHeight
        '
        Me.edMotDetMatrixHeight.Location = New System.Drawing.Point(145, 22)
        Me.edMotDetMatrixHeight.Name = "edMotDetMatrixHeight"
        Me.edMotDetMatrixHeight.Size = New System.Drawing.Size(36, 20)
        Me.edMotDetMatrixHeight.TabIndex = 75
        Me.edMotDetMatrixHeight.Text = "10"
        '
        'label163
        '
        Me.label163.AutoSize = True
        Me.label163.Location = New System.Drawing.Point(98, 25)
        Me.label163.Name = "label163"
        Me.label163.Size = New System.Drawing.Size(38, 13)
        Me.label163.TabIndex = 74
        Me.label163.Text = "Height"
        '
        'edMotDetMatrixWidth
        '
        Me.edMotDetMatrixWidth.Location = New System.Drawing.Point(56, 22)
        Me.edMotDetMatrixWidth.Name = "edMotDetMatrixWidth"
        Me.edMotDetMatrixWidth.Size = New System.Drawing.Size(36, 20)
        Me.edMotDetMatrixWidth.TabIndex = 73
        Me.edMotDetMatrixWidth.Text = "10"
        '
        'label164
        '
        Me.label164.AutoSize = True
        Me.label164.Location = New System.Drawing.Point(14, 25)
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
        Me.groupBox26.Location = New System.Drawing.Point(12, 184)
        Me.groupBox26.Name = "groupBox26"
        Me.groupBox26.Size = New System.Drawing.Size(233, 66)
        Me.groupBox26.TabIndex = 2
        Me.groupBox26.TabStop = False
        Me.groupBox26.Text = "Drop frames"
        '
        'label162
        '
        Me.label162.AutoSize = True
        Me.label162.Location = New System.Drawing.Point(94, 20)
        Me.label162.Name = "label162"
        Me.label162.Size = New System.Drawing.Size(54, 13)
        Me.label162.TabIndex = 4
        Me.label162.Text = "Threshold"
        '
        'tbMotDetDropFramesThreshold
        '
        Me.tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window
        Me.tbMotDetDropFramesThreshold.Location = New System.Drawing.Point(95, 36)
        Me.tbMotDetDropFramesThreshold.Maximum = 255
        Me.tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold"
        Me.tbMotDetDropFramesThreshold.Size = New System.Drawing.Size(104, 45)
        Me.tbMotDetDropFramesThreshold.TabIndex = 5
        Me.tbMotDetDropFramesThreshold.TickFrequency = 5
        Me.tbMotDetDropFramesThreshold.Value = 5
        '
        'cbMotDetDropFramesEnabled
        '
        Me.cbMotDetDropFramesEnabled.AutoSize = True
        Me.cbMotDetDropFramesEnabled.Location = New System.Drawing.Point(14, 18)
        Me.cbMotDetDropFramesEnabled.Name = "cbMotDetDropFramesEnabled"
        Me.cbMotDetDropFramesEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetDropFramesEnabled.TabIndex = 1
        Me.cbMotDetDropFramesEnabled.Text = "Enabled"
        Me.cbMotDetDropFramesEnabled.UseVisualStyleBackColor = True
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
        Me.groupBox24.Size = New System.Drawing.Size(233, 79)
        Me.groupBox24.TabIndex = 0
        Me.groupBox24.TabStop = False
        Me.groupBox24.Text = "Compare settings"
        '
        'edMotDetFrameInterval
        '
        Me.edMotDetFrameInterval.Location = New System.Drawing.Point(95, 49)
        Me.edMotDetFrameInterval.Name = "edMotDetFrameInterval"
        Me.edMotDetFrameInterval.Size = New System.Drawing.Size(32, 20)
        Me.edMotDetFrameInterval.TabIndex = 5
        Me.edMotDetFrameInterval.Text = "2"
        '
        'label159
        '
        Me.label159.AutoSize = True
        Me.label159.Location = New System.Drawing.Point(11, 52)
        Me.label159.Name = "label159"
        Me.label159.Size = New System.Drawing.Size(73, 13)
        Me.label159.TabIndex = 4
        Me.label159.Text = "Frame interval"
        '
        'cbCompareGreyscale
        '
        Me.cbCompareGreyscale.AutoSize = True
        Me.cbCompareGreyscale.Checked = True
        Me.cbCompareGreyscale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCompareGreyscale.Location = New System.Drawing.Point(163, 20)
        Me.cbCompareGreyscale.Name = "cbCompareGreyscale"
        Me.cbCompareGreyscale.Size = New System.Drawing.Size(73, 17)
        Me.cbCompareGreyscale.TabIndex = 3
        Me.cbCompareGreyscale.Text = "Greyscale"
        Me.cbCompareGreyscale.UseVisualStyleBackColor = True
        '
        'cbCompareBlue
        '
        Me.cbCompareBlue.AutoSize = True
        Me.cbCompareBlue.Location = New System.Drawing.Point(118, 20)
        Me.cbCompareBlue.Name = "cbCompareBlue"
        Me.cbCompareBlue.Size = New System.Drawing.Size(47, 17)
        Me.cbCompareBlue.TabIndex = 2
        Me.cbCompareBlue.Text = "Blue"
        Me.cbCompareBlue.UseVisualStyleBackColor = True
        '
        'cbCompareGreen
        '
        Me.cbCompareGreen.AutoSize = True
        Me.cbCompareGreen.Location = New System.Drawing.Point(60, 20)
        Me.cbCompareGreen.Name = "cbCompareGreen"
        Me.cbCompareGreen.Size = New System.Drawing.Size(55, 17)
        Me.cbCompareGreen.TabIndex = 1
        Me.cbCompareGreen.Text = "Green"
        Me.cbCompareGreen.UseVisualStyleBackColor = True
        '
        'cbCompareRed
        '
        Me.cbCompareRed.AutoSize = True
        Me.cbCompareRed.Location = New System.Drawing.Point(14, 20)
        Me.cbCompareRed.Name = "cbCompareRed"
        Me.cbCompareRed.Size = New System.Drawing.Size(46, 17)
        Me.cbCompareRed.TabIndex = 0
        Me.cbCompareRed.Text = "Red"
        Me.cbCompareRed.UseVisualStyleBackColor = True
        '
        'cbMotDetEnabled
        '
        Me.cbMotDetEnabled.AutoSize = True
        Me.cbMotDetEnabled.Location = New System.Drawing.Point(15, 18)
        Me.cbMotDetEnabled.Name = "cbMotDetEnabled"
        Me.cbMotDetEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbMotDetEnabled.TabIndex = 4
        Me.cbMotDetEnabled.Text = "Enabled"
        Me.cbMotDetEnabled.UseVisualStyleBackColor = True
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.label393)
        Me.tabPage2.Controls.Add(Me.cbDirect2DRotate)
        Me.tabPage2.Controls.Add(Me.pnVideoRendererBGColor)
        Me.tabPage2.Controls.Add(Me.label394)
        Me.tabPage2.Controls.Add(Me.btFullScreen)
        Me.tabPage2.Controls.Add(Me.cbScreenFlipVertical)
        Me.tabPage2.Controls.Add(Me.cbScreenFlipHorizontal)
        Me.tabPage2.Controls.Add(Me.cbStretch)
        Me.tabPage2.Controls.Add(Me.groupBox13)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(302, 474)
        Me.tabPage2.TabIndex = 6
        Me.tabPage2.Text = "Display"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'label393
        '
        Me.label393.AutoSize = True
        Me.label393.Location = New System.Drawing.Point(21, 255)
        Me.label393.Name = "label393"
        Me.label393.Size = New System.Drawing.Size(79, 13)
        Me.label393.TabIndex = 75
        Me.label393.Text = "Direct2D rotate"
        '
        'cbDirect2DRotate
        '
        Me.cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDirect2DRotate.FormattingEnabled = True
        Me.cbDirect2DRotate.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.cbDirect2DRotate.Location = New System.Drawing.Point(24, 270)
        Me.cbDirect2DRotate.Name = "cbDirect2DRotate"
        Me.cbDirect2DRotate.Size = New System.Drawing.Size(122, 21)
        Me.cbDirect2DRotate.TabIndex = 74
        '
        'pnVideoRendererBGColor
        '
        Me.pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black
        Me.pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnVideoRendererBGColor.Location = New System.Drawing.Point(128, 172)
        Me.pnVideoRendererBGColor.Name = "pnVideoRendererBGColor"
        Me.pnVideoRendererBGColor.Size = New System.Drawing.Size(24, 23)
        Me.pnVideoRendererBGColor.TabIndex = 73
        '
        'label394
        '
        Me.label394.AutoSize = True
        Me.label394.Location = New System.Drawing.Point(21, 177)
        Me.label394.Name = "label394"
        Me.label394.Size = New System.Drawing.Size(91, 13)
        Me.label394.TabIndex = 72
        Me.label394.Text = "Background color"
        '
        'btFullScreen
        '
        Me.btFullScreen.Location = New System.Drawing.Point(184, 270)
        Me.btFullScreen.Name = "btFullScreen"
        Me.btFullScreen.Size = New System.Drawing.Size(90, 22)
        Me.btFullScreen.TabIndex = 71
        Me.btFullScreen.Text = "Full screen"
        Me.btFullScreen.UseVisualStyleBackColor = True
        '
        'cbScreenFlipVertical
        '
        Me.cbScreenFlipVertical.AutoSize = True
        Me.cbScreenFlipVertical.Location = New System.Drawing.Point(184, 195)
        Me.cbScreenFlipVertical.Name = "cbScreenFlipVertical"
        Me.cbScreenFlipVertical.Size = New System.Drawing.Size(79, 17)
        Me.cbScreenFlipVertical.TabIndex = 70
        Me.cbScreenFlipVertical.Text = "Flip vertical"
        Me.cbScreenFlipVertical.UseVisualStyleBackColor = True
        '
        'cbScreenFlipHorizontal
        '
        Me.cbScreenFlipHorizontal.AutoSize = True
        Me.cbScreenFlipHorizontal.Location = New System.Drawing.Point(184, 173)
        Me.cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal"
        Me.cbScreenFlipHorizontal.Size = New System.Drawing.Size(90, 17)
        Me.cbScreenFlipHorizontal.TabIndex = 69
        Me.cbScreenFlipHorizontal.Text = "Flip horizontal"
        Me.cbScreenFlipHorizontal.UseVisualStyleBackColor = True
        '
        'cbStretch
        '
        Me.cbStretch.AutoSize = True
        Me.cbStretch.Location = New System.Drawing.Point(184, 219)
        Me.cbStretch.Name = "cbStretch"
        Me.cbStretch.Size = New System.Drawing.Size(89, 17)
        Me.cbStretch.TabIndex = 68
        Me.cbStretch.Text = "Stretch video"
        Me.cbStretch.UseVisualStyleBackColor = True
        '
        'groupBox13
        '
        Me.groupBox13.Controls.Add(Me.rbDirect2D)
        Me.groupBox13.Controls.Add(Me.rbNone)
        Me.groupBox13.Controls.Add(Me.rbEVR)
        Me.groupBox13.Controls.Add(Me.rbVMR9)
        Me.groupBox13.Controls.Add(Me.rbVR)
        Me.groupBox13.Location = New System.Drawing.Point(24, 26)
        Me.groupBox13.Name = "groupBox13"
        Me.groupBox13.Size = New System.Drawing.Size(250, 132)
        Me.groupBox13.TabIndex = 67
        Me.groupBox13.TabStop = False
        Me.groupBox13.Text = "Video Renderer"
        '
        'rbDirect2D
        '
        Me.rbDirect2D.AutoSize = True
        Me.rbDirect2D.Location = New System.Drawing.Point(12, 86)
        Me.rbDirect2D.Name = "rbDirect2D"
        Me.rbDirect2D.Size = New System.Drawing.Size(67, 17)
        Me.rbDirect2D.TabIndex = 4
        Me.rbDirect2D.TabStop = True
        Me.rbDirect2D.Text = "Direct2D"
        Me.rbDirect2D.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.AutoSize = True
        Me.rbNone.Location = New System.Drawing.Point(12, 108)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(51, 17)
        Me.rbNone.TabIndex = 3
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "None"
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'rbEVR
        '
        Me.rbEVR.AutoSize = True
        Me.rbEVR.Location = New System.Drawing.Point(12, 64)
        Me.rbEVR.Name = "rbEVR"
        Me.rbEVR.Size = New System.Drawing.Size(227, 17)
        Me.rbEVR.TabIndex = 2
        Me.rbEVR.Text = "Enhanced Video Renderer (Vista and later)"
        Me.rbEVR.UseVisualStyleBackColor = True
        '
        'rbVMR9
        '
        Me.rbVMR9.AutoSize = True
        Me.rbVMR9.Checked = True
        Me.rbVMR9.Location = New System.Drawing.Point(12, 42)
        Me.rbVMR9.Name = "rbVMR9"
        Me.rbVMR9.Size = New System.Drawing.Size(182, 17)
        Me.rbVMR9.TabIndex = 1
        Me.rbVMR9.TabStop = True
        Me.rbVMR9.Text = "Video Mixing Renderer 9 (default)"
        Me.rbVMR9.UseVisualStyleBackColor = True
        '
        'rbVR
        '
        Me.rbVR.AutoSize = True
        Me.rbVR.Location = New System.Drawing.Point(12, 20)
        Me.rbVR.Name = "rbVR"
        Me.rbVR.Size = New System.Drawing.Size(147, 17)
        Me.rbVR.TabIndex = 0
        Me.rbVR.Text = "Video Renderer Filter (old)"
        Me.rbVR.UseVisualStyleBackColor = True
        '
        'TabPage23
        '
        Me.TabPage23.Controls.Add(Me.edBarcodeMetadata)
        Me.TabPage23.Controls.Add(Me.label91)
        Me.TabPage23.Controls.Add(Me.cbBarcodeType)
        Me.TabPage23.Controls.Add(Me.label90)
        Me.TabPage23.Controls.Add(Me.btBarcodeReset)
        Me.TabPage23.Controls.Add(Me.edBarcode)
        Me.TabPage23.Controls.Add(Me.label89)
        Me.TabPage23.Controls.Add(Me.cbBarcodeDetectionEnabled)
        Me.TabPage23.Location = New System.Drawing.Point(4, 22)
        Me.TabPage23.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage23.Name = "TabPage23"
        Me.TabPage23.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage23.Size = New System.Drawing.Size(302, 474)
        Me.TabPage23.TabIndex = 8
        Me.TabPage23.Text = "Barcode reader"
        Me.TabPage23.UseVisualStyleBackColor = True
        '
        'edBarcodeMetadata
        '
        Me.edBarcodeMetadata.Location = New System.Drawing.Point(12, 151)
        Me.edBarcodeMetadata.Margin = New System.Windows.Forms.Padding(2)
        Me.edBarcodeMetadata.Multiline = True
        Me.edBarcodeMetadata.Name = "edBarcodeMetadata"
        Me.edBarcodeMetadata.Size = New System.Drawing.Size(282, 92)
        Me.edBarcodeMetadata.TabIndex = 24
        '
        'label91
        '
        Me.label91.AutoSize = True
        Me.label91.Location = New System.Drawing.Point(10, 132)
        Me.label91.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label91.Name = "label91"
        Me.label91.Size = New System.Drawing.Size(52, 13)
        Me.label91.TabIndex = 23
        Me.label91.Text = "Metadata"
        '
        'cbBarcodeType
        '
        Me.cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBarcodeType.FormattingEnabled = True
        Me.cbBarcodeType.Items.AddRange(New Object() {"Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417"})
        Me.cbBarcodeType.Location = New System.Drawing.Point(12, 58)
        Me.cbBarcodeType.Margin = New System.Windows.Forms.Padding(2)
        Me.cbBarcodeType.Name = "cbBarcodeType"
        Me.cbBarcodeType.Size = New System.Drawing.Size(160, 21)
        Me.cbBarcodeType.TabIndex = 22
        '
        'label90
        '
        Me.label90.AutoSize = True
        Me.label90.Location = New System.Drawing.Point(10, 44)
        Me.label90.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label90.Name = "label90"
        Me.label90.Size = New System.Drawing.Size(70, 13)
        Me.label90.TabIndex = 21
        Me.label90.Text = "Barcode type"
        '
        'btBarcodeReset
        '
        Me.btBarcodeReset.Location = New System.Drawing.Point(12, 255)
        Me.btBarcodeReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btBarcodeReset.Name = "btBarcodeReset"
        Me.btBarcodeReset.Size = New System.Drawing.Size(62, 22)
        Me.btBarcodeReset.TabIndex = 20
        Me.btBarcodeReset.Text = "Restart"
        Me.btBarcodeReset.UseVisualStyleBackColor = True
        '
        'edBarcode
        '
        Me.edBarcode.Location = New System.Drawing.Point(12, 105)
        Me.edBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.edBarcode.Name = "edBarcode"
        Me.edBarcode.Size = New System.Drawing.Size(282, 20)
        Me.edBarcode.TabIndex = 19
        '
        'label89
        '
        Me.label89.AutoSize = True
        Me.label89.Location = New System.Drawing.Point(10, 90)
        Me.label89.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label89.Name = "label89"
        Me.label89.Size = New System.Drawing.Size(93, 13)
        Me.label89.TabIndex = 18
        Me.label89.Text = "Detected barcode"
        '
        'cbBarcodeDetectionEnabled
        '
        Me.cbBarcodeDetectionEnabled.AutoSize = True
        Me.cbBarcodeDetectionEnabled.Location = New System.Drawing.Point(12, 14)
        Me.cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled"
        Me.cbBarcodeDetectionEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbBarcodeDetectionEnabled.TabIndex = 17
        Me.cbBarcodeDetectionEnabled.Text = "Enabled"
        Me.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = True
        '
        'TabPage24
        '
        Me.TabPage24.Controls.Add(Me.cbNetworkStreamingMode)
        Me.TabPage24.Controls.Add(Me.tabControl5)
        Me.TabPage24.Controls.Add(Me.cbNetworkStreamingAudioEnabled)
        Me.TabPage24.Controls.Add(Me.cbNetworkStreaming)
        Me.TabPage24.Location = New System.Drawing.Point(4, 22)
        Me.TabPage24.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage24.Name = "TabPage24"
        Me.TabPage24.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage24.Size = New System.Drawing.Size(302, 474)
        Me.TabPage24.TabIndex = 9
        Me.TabPage24.Text = "Network streaming"
        Me.TabPage24.UseVisualStyleBackColor = True
        '
        'cbNetworkStreamingMode
        '
        Me.cbNetworkStreamingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNetworkStreamingMode.FormattingEnabled = True
        Me.cbNetworkStreamingMode.Items.AddRange(New Object() {"Windows Media Video", "RTSP", "RTMP (including YouTube and Facebook)", "NDI", "UDP", "Smooth Streaming to Microsoft IIS", "Output to external virtual devices"})
        Me.cbNetworkStreamingMode.Location = New System.Drawing.Point(14, 36)
        Me.cbNetworkStreamingMode.Name = "cbNetworkStreamingMode"
        Me.cbNetworkStreamingMode.Size = New System.Drawing.Size(276, 21)
        Me.cbNetworkStreamingMode.TabIndex = 33
        '
        'tabControl5
        '
        Me.tabControl5.Controls.Add(Me.TabPage25)
        Me.tabControl5.Controls.Add(Me.TabPage47)
        Me.tabControl5.Controls.Add(Me.TabPage48)
        Me.tabControl5.Controls.Add(Me.TabPage5)
        Me.tabControl5.Controls.Add(Me.TabPage67)
        Me.tabControl5.Controls.Add(Me.TabPage49)
        Me.tabControl5.Controls.Add(Me.TabPage56)
        Me.tabControl5.Location = New System.Drawing.Point(2, 68)
        Me.tabControl5.Name = "tabControl5"
        Me.tabControl5.SelectedIndex = 0
        Me.tabControl5.Size = New System.Drawing.Size(292, 370)
        Me.tabControl5.TabIndex = 32
        '
        'TabPage25
        '
        Me.TabPage25.Controls.Add(Me.Label20)
        Me.TabPage25.Controls.Add(Me.edNetworkURL)
        Me.TabPage25.Controls.Add(Me.edWMVNetworkPort)
        Me.TabPage25.Controls.Add(Me.Label17)
        Me.TabPage25.Controls.Add(Me.btRefreshClients)
        Me.TabPage25.Controls.Add(Me.lbNetworkClients)
        Me.TabPage25.Controls.Add(Me.rbNetworkStreamingUseExternalProfile)
        Me.TabPage25.Controls.Add(Me.rbNetworkStreamingUseMainWMVSettings)
        Me.TabPage25.Controls.Add(Me.label81)
        Me.TabPage25.Controls.Add(Me.label80)
        Me.TabPage25.Controls.Add(Me.edMaximumClients)
        Me.TabPage25.Controls.Add(Me.Label18)
        Me.TabPage25.Controls.Add(Me.btSelectWMVProfileNetwork)
        Me.TabPage25.Controls.Add(Me.edNetworkStreamingWMVProfile)
        Me.TabPage25.Controls.Add(Me.Label19)
        Me.TabPage25.Location = New System.Drawing.Point(4, 22)
        Me.TabPage25.Name = "TabPage25"
        Me.TabPage25.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage25.Size = New System.Drawing.Size(284, 344)
        Me.TabPage25.TabIndex = 0
        Me.TabPage25.Text = "WMV"
        Me.TabPage25.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 295)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 13)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "Connection URL"
        '
        'edNetworkURL
        '
        Me.edNetworkURL.Location = New System.Drawing.Point(15, 310)
        Me.edNetworkURL.Name = "edNetworkURL"
        Me.edNetworkURL.ReadOnly = True
        Me.edNetworkURL.Size = New System.Drawing.Size(255, 20)
        Me.edNetworkURL.TabIndex = 31
        '
        'edWMVNetworkPort
        '
        Me.edWMVNetworkPort.Location = New System.Drawing.Point(236, 116)
        Me.edWMVNetworkPort.Name = "edWMVNetworkPort"
        Me.edWMVNetworkPort.Size = New System.Drawing.Size(34, 20)
        Me.edWMVNetworkPort.TabIndex = 30
        Me.edWMVNetworkPort.Text = "100"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(162, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Network port"
        '
        'btRefreshClients
        '
        Me.btRefreshClients.Location = New System.Drawing.Point(206, 228)
        Me.btRefreshClients.Name = "btRefreshClients"
        Me.btRefreshClients.Size = New System.Drawing.Size(64, 22)
        Me.btRefreshClients.TabIndex = 28
        Me.btRefreshClients.Text = "Refresh"
        Me.btRefreshClients.UseVisualStyleBackColor = True
        '
        'lbNetworkClients
        '
        Me.lbNetworkClients.FormattingEnabled = True
        Me.lbNetworkClients.Location = New System.Drawing.Point(15, 168)
        Me.lbNetworkClients.Name = "lbNetworkClients"
        Me.lbNetworkClients.Size = New System.Drawing.Size(255, 30)
        Me.lbNetworkClients.TabIndex = 27
        '
        'rbNetworkStreamingUseExternalProfile
        '
        Me.rbNetworkStreamingUseExternalProfile.AutoSize = True
        Me.rbNetworkStreamingUseExternalProfile.Location = New System.Drawing.Point(15, 36)
        Me.rbNetworkStreamingUseExternalProfile.Name = "rbNetworkStreamingUseExternalProfile"
        Me.rbNetworkStreamingUseExternalProfile.Size = New System.Drawing.Size(115, 17)
        Me.rbNetworkStreamingUseExternalProfile.TabIndex = 26
        Me.rbNetworkStreamingUseExternalProfile.Text = "Use external profile"
        Me.rbNetworkStreamingUseExternalProfile.UseVisualStyleBackColor = True
        '
        'rbNetworkStreamingUseMainWMVSettings
        '
        Me.rbNetworkStreamingUseMainWMVSettings.AutoSize = True
        Me.rbNetworkStreamingUseMainWMVSettings.Checked = True
        Me.rbNetworkStreamingUseMainWMVSettings.Location = New System.Drawing.Point(15, 14)
        Me.rbNetworkStreamingUseMainWMVSettings.Name = "rbNetworkStreamingUseMainWMVSettings"
        Me.rbNetworkStreamingUseMainWMVSettings.Size = New System.Drawing.Size(193, 17)
        Me.rbNetworkStreamingUseMainWMVSettings.TabIndex = 25
        Me.rbNetworkStreamingUseMainWMVSettings.TabStop = True
        Me.rbNetworkStreamingUseMainWMVSettings.Text = "Use WMV settings from capture tab"
        Me.rbNetworkStreamingUseMainWMVSettings.UseVisualStyleBackColor = True
        '
        'label81
        '
        Me.label81.AutoSize = True
        Me.label81.Location = New System.Drawing.Point(13, 266)
        Me.label81.Name = "label81"
        Me.label81.Size = New System.Drawing.Size(230, 13)
        Me.label81.TabIndex = 24
        Me.label81.Text = "You can use Windows Media Player for testing."
        '
        'label80
        '
        Me.label80.AutoSize = True
        Me.label80.Location = New System.Drawing.Point(13, 153)
        Me.label80.Name = "label80"
        Me.label80.Size = New System.Drawing.Size(38, 13)
        Me.label80.TabIndex = 23
        Me.label80.Text = "Clients"
        '
        'edMaximumClients
        '
        Me.edMaximumClients.Location = New System.Drawing.Point(109, 116)
        Me.edMaximumClients.Name = "edMaximumClients"
        Me.edMaximumClients.Size = New System.Drawing.Size(34, 20)
        Me.edMaximumClients.TabIndex = 22
        Me.edMaximumClients.Text = "10"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Maximum clients"
        '
        'btSelectWMVProfileNetwork
        '
        Me.btSelectWMVProfileNetwork.Location = New System.Drawing.Point(246, 79)
        Me.btSelectWMVProfileNetwork.Name = "btSelectWMVProfileNetwork"
        Me.btSelectWMVProfileNetwork.Size = New System.Drawing.Size(24, 22)
        Me.btSelectWMVProfileNetwork.TabIndex = 20
        Me.btSelectWMVProfileNetwork.Text = "..."
        Me.btSelectWMVProfileNetwork.UseVisualStyleBackColor = True
        '
        'edNetworkStreamingWMVProfile
        '
        Me.edNetworkStreamingWMVProfile.Location = New System.Drawing.Point(37, 81)
        Me.edNetworkStreamingWMVProfile.Name = "edNetworkStreamingWMVProfile"
        Me.edNetworkStreamingWMVProfile.Size = New System.Drawing.Size(206, 20)
        Me.edNetworkStreamingWMVProfile.TabIndex = 19
        Me.edNetworkStreamingWMVProfile.Text = "c:\WM.prx"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(34, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "File name"
        '
        'TabPage47
        '
        Me.TabPage47.Controls.Add(Me.edNetworkRTSPURL)
        Me.TabPage47.Controls.Add(Me.label367)
        Me.TabPage47.Controls.Add(Me.label366)
        Me.TabPage47.Location = New System.Drawing.Point(4, 22)
        Me.TabPage47.Name = "TabPage47"
        Me.TabPage47.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage47.Size = New System.Drawing.Size(284, 344)
        Me.TabPage47.TabIndex = 2
        Me.TabPage47.Text = "RTSP"
        Me.TabPage47.UseVisualStyleBackColor = True
        '
        'edNetworkRTSPURL
        '
        Me.edNetworkRTSPURL.Location = New System.Drawing.Point(20, 36)
        Me.edNetworkRTSPURL.Name = "edNetworkRTSPURL"
        Me.edNetworkRTSPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkRTSPURL.TabIndex = 14
        Me.edNetworkRTSPURL.Text = "rtsp://localhost:5554/vfstream"
        '
        'label367
        '
        Me.label367.AutoSize = True
        Me.label367.Location = New System.Drawing.Point(17, 20)
        Me.label367.Name = "label367"
        Me.label367.Size = New System.Drawing.Size(29, 13)
        Me.label367.TabIndex = 13
        Me.label367.Text = "URL"
        '
        'label366
        '
        Me.label366.AutoSize = True
        Me.label366.Location = New System.Drawing.Point(17, 314)
        Me.label366.Name = "label366"
        Me.label366.Size = New System.Drawing.Size(159, 13)
        Me.label366.TabIndex = 12
        Me.label366.Text = "MP4 output settings will be used"
        '
        'TabPage48
        '
        Me.TabPage48.Controls.Add(Me.linkLabel11)
        Me.TabPage48.Controls.Add(Me.rbNetworkRTMPFFMPEGCustom)
        Me.TabPage48.Controls.Add(Me.rbNetworkRTMPFFMPEG)
        Me.TabPage48.Controls.Add(Me.edNetworkRTMPURL)
        Me.TabPage48.Controls.Add(Me.label368)
        Me.TabPage48.Controls.Add(Me.label369)
        Me.TabPage48.Location = New System.Drawing.Point(4, 22)
        Me.TabPage48.Name = "TabPage48"
        Me.TabPage48.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage48.Size = New System.Drawing.Size(284, 344)
        Me.TabPage48.TabIndex = 3
        Me.TabPage48.Text = "RTMP"
        Me.TabPage48.UseVisualStyleBackColor = True
        '
        'linkLabel11
        '
        Me.linkLabel11.AutoSize = True
        Me.linkLabel11.Location = New System.Drawing.Point(17, 106)
        Me.linkLabel11.Name = "linkLabel11"
        Me.linkLabel11.Size = New System.Drawing.Size(154, 13)
        Me.linkLabel11.TabIndex = 23
        Me.linkLabel11.TabStop = True
        Me.linkLabel11.Text = "Network streaming to YouTube"
        '
        'rbNetworkRTMPFFMPEGCustom
        '
        Me.rbNetworkRTMPFFMPEGCustom.AutoSize = True
        Me.rbNetworkRTMPFFMPEGCustom.Location = New System.Drawing.Point(20, 40)
        Me.rbNetworkRTMPFFMPEGCustom.Name = "rbNetworkRTMPFFMPEGCustom"
        Me.rbNetworkRTMPFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkRTMPFFMPEGCustom.TabIndex = 21
        Me.rbNetworkRTMPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = True
        '
        'rbNetworkRTMPFFMPEG
        '
        Me.rbNetworkRTMPFFMPEG.AutoSize = True
        Me.rbNetworkRTMPFFMPEG.Checked = True
        Me.rbNetworkRTMPFFMPEG.Location = New System.Drawing.Point(20, 18)
        Me.rbNetworkRTMPFFMPEG.Name = "rbNetworkRTMPFFMPEG"
        Me.rbNetworkRTMPFFMPEG.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkRTMPFFMPEG.TabIndex = 20
        Me.rbNetworkRTMPFFMPEG.TabStop = True
        Me.rbNetworkRTMPFFMPEG.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = True
        '
        'edNetworkRTMPURL
        '
        Me.edNetworkRTMPURL.Location = New System.Drawing.Point(20, 282)
        Me.edNetworkRTMPURL.Name = "edNetworkRTMPURL"
        Me.edNetworkRTMPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkRTMPURL.TabIndex = 19
        Me.edNetworkRTMPURL.Text = "rtmp://localhost:5554/live/Stream"
        '
        'label368
        '
        Me.label368.AutoSize = True
        Me.label368.Location = New System.Drawing.Point(17, 266)
        Me.label368.Name = "label368"
        Me.label368.Size = New System.Drawing.Size(29, 13)
        Me.label368.TabIndex = 18
        Me.label368.Text = "URL"
        '
        'label369
        '
        Me.label369.AutoSize = True
        Me.label369.Location = New System.Drawing.Point(30, 314)
        Me.label369.Name = "label369"
        Me.label369.Size = New System.Drawing.Size(214, 13)
        Me.label369.TabIndex = 17
        Me.label369.Text = "Format settings located on output format tab"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.LinkLabel6)
        Me.TabPage5.Controls.Add(Me.label11)
        Me.TabPage5.Controls.Add(Me.label12)
        Me.TabPage5.Controls.Add(Me.edNDIURL)
        Me.TabPage5.Controls.Add(Me.edNDIName)
        Me.TabPage5.Controls.Add(Me.label13)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(284, 344)
        Me.TabPage5.TabIndex = 6
        Me.TabPage5.Text = "NDI"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(15, 135)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(86, 13)
        Me.LinkLabel6.TabIndex = 101
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "vendor's website"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(15, 122)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(257, 13)
        Me.label11.TabIndex = 100
        Me.label11.Text = "To use NDI please install NDI SDK for Windows from"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(15, 71)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(86, 13)
        Me.label12.TabIndex = 99
        Me.label12.Text = "Connection URL"
        '
        'edNDIURL
        '
        Me.edNDIURL.Location = New System.Drawing.Point(18, 87)
        Me.edNDIURL.Name = "edNDIURL"
        Me.edNDIURL.ReadOnly = True
        Me.edNDIURL.Size = New System.Drawing.Size(243, 20)
        Me.edNDIURL.TabIndex = 98
        '
        'edNDIName
        '
        Me.edNDIName.Location = New System.Drawing.Point(18, 35)
        Me.edNDIName.Name = "edNDIName"
        Me.edNDIName.Size = New System.Drawing.Size(243, 20)
        Me.edNDIName.TabIndex = 97
        Me.edNDIName.Text = "Main"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(15, 19)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(35, 13)
        Me.label13.TabIndex = 96
        Me.label13.Text = "Name"
        '
        'TabPage67
        '
        Me.TabPage67.Controls.Add(Me.label63)
        Me.TabPage67.Controls.Add(Me.label62)
        Me.TabPage67.Controls.Add(Me.label314)
        Me.TabPage67.Controls.Add(Me.label313)
        Me.TabPage67.Controls.Add(Me.edNetworkUDPURL)
        Me.TabPage67.Controls.Add(Me.Label4)
        Me.TabPage67.Controls.Add(Me.label484)
        Me.TabPage67.Controls.Add(Me.rbNetworkUDPFFMPEGCustom)
        Me.TabPage67.Controls.Add(Me.rbNetworkUDPFFMPEG)
        Me.TabPage67.Location = New System.Drawing.Point(4, 22)
        Me.TabPage67.Name = "TabPage67"
        Me.TabPage67.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage67.Size = New System.Drawing.Size(284, 344)
        Me.TabPage67.TabIndex = 5
        Me.TabPage67.Text = "UDP"
        Me.TabPage67.UseVisualStyleBackColor = True
        '
        'label63
        '
        Me.label63.AutoSize = True
        Me.label63.Location = New System.Drawing.Point(17, 178)
        Me.label63.Name = "label63"
        Me.label63.Size = New System.Drawing.Size(109, 13)
        Me.label63.TabIndex = 27
        Me.label63.Text = "instead of IP address."
        '
        'label62
        '
        Me.label62.AutoSize = True
        Me.label62.Location = New System.Drawing.Point(17, 165)
        Me.label62.Name = "label62"
        Me.label62.Size = New System.Drawing.Size(239, 13)
        Me.label62.TabIndex = 26
        Me.label62.Text = "To open the stream in VLC on a local PC, use @ "
        '
        'label314
        '
        Me.label314.AutoSize = True
        Me.label314.Location = New System.Drawing.Point(17, 114)
        Me.label314.Name = "label314"
        Me.label314.Size = New System.Drawing.Size(222, 13)
        Me.label314.TabIndex = 25
        Me.label314.Text = "For multicast UDP streaming, use an URL like"
        '
        'label313
        '
        Me.label313.AutoSize = True
        Me.label313.Location = New System.Drawing.Point(17, 127)
        Me.label313.Name = "label313"
        Me.label313.Size = New System.Drawing.Size(229, 13)
        Me.label313.TabIndex = 24
        Me.label313.Text = "udp://239.101.101.1:1234?ttl=1&pkt_size=1316"
        '
        'edNetworkUDPURL
        '
        Me.edNetworkUDPURL.Location = New System.Drawing.Point(20, 91)
        Me.edNetworkUDPURL.Name = "edNetworkUDPURL"
        Me.edNetworkUDPURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkUDPURL.TabIndex = 23
        Me.edNetworkUDPURL.Text = "udp://127.0.0.1:10000?pkt_size=1316"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "URL"
        '
        'label484
        '
        Me.label484.AutoSize = True
        Me.label484.Location = New System.Drawing.Point(30, 316)
        Me.label484.Name = "label484"
        Me.label484.Size = New System.Drawing.Size(217, 13)
        Me.label484.TabIndex = 21
        Me.label484.Text = "Specify settings located on output format tab"
        '
        'rbNetworkUDPFFMPEGCustom
        '
        Me.rbNetworkUDPFFMPEGCustom.AutoSize = True
        Me.rbNetworkUDPFFMPEGCustom.Location = New System.Drawing.Point(20, 38)
        Me.rbNetworkUDPFFMPEGCustom.Name = "rbNetworkUDPFFMPEGCustom"
        Me.rbNetworkUDPFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkUDPFFMPEGCustom.TabIndex = 18
        Me.rbNetworkUDPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = True
        '
        'rbNetworkUDPFFMPEG
        '
        Me.rbNetworkUDPFFMPEG.AutoSize = True
        Me.rbNetworkUDPFFMPEG.Checked = True
        Me.rbNetworkUDPFFMPEG.Location = New System.Drawing.Point(20, 16)
        Me.rbNetworkUDPFFMPEG.Name = "rbNetworkUDPFFMPEG"
        Me.rbNetworkUDPFFMPEG.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkUDPFFMPEG.TabIndex = 17
        Me.rbNetworkUDPFFMPEG.TabStop = True
        Me.rbNetworkUDPFFMPEG.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkUDPFFMPEG.UseVisualStyleBackColor = True
        '
        'TabPage49
        '
        Me.TabPage49.Controls.Add(Me.rbNetworkSSFFMPEGCustom)
        Me.TabPage49.Controls.Add(Me.rbNetworkSSFFMPEGDefault)
        Me.TabPage49.Controls.Add(Me.linkLabel5)
        Me.TabPage49.Controls.Add(Me.edNetworkSSURL)
        Me.TabPage49.Controls.Add(Me.label370)
        Me.TabPage49.Controls.Add(Me.label371)
        Me.TabPage49.Controls.Add(Me.rbNetworkSSSoftware)
        Me.TabPage49.Location = New System.Drawing.Point(4, 22)
        Me.TabPage49.Name = "TabPage49"
        Me.TabPage49.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage49.Size = New System.Drawing.Size(284, 344)
        Me.TabPage49.TabIndex = 4
        Me.TabPage49.Text = "IIS Smooth Streaming"
        Me.TabPage49.UseVisualStyleBackColor = True
        '
        'rbNetworkSSFFMPEGCustom
        '
        Me.rbNetworkSSFFMPEGCustom.AutoSize = True
        Me.rbNetworkSSFFMPEGCustom.Location = New System.Drawing.Point(20, 62)
        Me.rbNetworkSSFFMPEGCustom.Name = "rbNetworkSSFFMPEGCustom"
        Me.rbNetworkSSFFMPEGCustom.Size = New System.Drawing.Size(197, 17)
        Me.rbNetworkSSFFMPEGCustom.TabIndex = 27
        Me.rbNetworkSSFFMPEGCustom.Text = "Custom settings using FFMPEG EXE"
        Me.rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = True
        '
        'rbNetworkSSFFMPEGDefault
        '
        Me.rbNetworkSSFFMPEGDefault.AutoSize = True
        Me.rbNetworkSSFFMPEGDefault.Location = New System.Drawing.Point(20, 40)
        Me.rbNetworkSSFFMPEGDefault.Name = "rbNetworkSSFFMPEGDefault"
        Me.rbNetworkSSFFMPEGDefault.Size = New System.Drawing.Size(181, 17)
        Me.rbNetworkSSFFMPEGDefault.TabIndex = 26
        Me.rbNetworkSSFFMPEGDefault.Text = "H264 / AAC using FFMPEG EXE"
        Me.rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = True
        '
        'linkLabel5
        '
        Me.linkLabel5.AutoSize = True
        Me.linkLabel5.Location = New System.Drawing.Point(17, 190)
        Me.linkLabel5.Name = "linkLabel5"
        Me.linkLabel5.Size = New System.Drawing.Size(178, 13)
        Me.linkLabel5.TabIndex = 25
        Me.linkLabel5.TabStop = True
        Me.linkLabel5.Text = "IIS Smooth Streaming usage manual"
        '
        'edNetworkSSURL
        '
        Me.edNetworkSSURL.Location = New System.Drawing.Point(20, 147)
        Me.edNetworkSSURL.Name = "edNetworkSSURL"
        Me.edNetworkSSURL.Size = New System.Drawing.Size(247, 20)
        Me.edNetworkSSURL.TabIndex = 24
        Me.edNetworkSSURL.Text = "http://localhost/LiveStream.isml"
        '
        'label370
        '
        Me.label370.AutoSize = True
        Me.label370.Location = New System.Drawing.Point(17, 132)
        Me.label370.Name = "label370"
        Me.label370.Size = New System.Drawing.Size(106, 13)
        Me.label370.TabIndex = 23
        Me.label370.Text = "Publishing point URL"
        '
        'label371
        '
        Me.label371.AutoSize = True
        Me.label371.Location = New System.Drawing.Point(17, 314)
        Me.label371.Name = "label371"
        Me.label371.Size = New System.Drawing.Size(214, 13)
        Me.label371.TabIndex = 22
        Me.label371.Text = "Format settings located on output format tab"
        '
        'rbNetworkSSSoftware
        '
        Me.rbNetworkSSSoftware.AutoSize = True
        Me.rbNetworkSSSoftware.Checked = True
        Me.rbNetworkSSSoftware.Location = New System.Drawing.Point(20, 18)
        Me.rbNetworkSSSoftware.Name = "rbNetworkSSSoftware"
        Me.rbNetworkSSSoftware.Size = New System.Drawing.Size(244, 17)
        Me.rbNetworkSSSoftware.TabIndex = 20
        Me.rbNetworkSSSoftware.TabStop = True
        Me.rbNetworkSSSoftware.Text = "H264 / AAC using software encoder / NVENC"
        Me.rbNetworkSSSoftware.UseVisualStyleBackColor = True
        '
        'TabPage56
        '
        Me.TabPage56.Controls.Add(Me.LinkLabel4)
        Me.TabPage56.Location = New System.Drawing.Point(4, 22)
        Me.TabPage56.Name = "TabPage56"
        Me.TabPage56.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage56.Size = New System.Drawing.Size(284, 344)
        Me.TabPage56.TabIndex = 1
        Me.TabPage56.Text = "External"
        Me.TabPage56.UseVisualStyleBackColor = True
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(27, 24)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(194, 13)
        Me.LinkLabel4.TabIndex = 1
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Streaming to Adobe Flash Media Server"
        '
        'cbNetworkStreamingAudioEnabled
        '
        Me.cbNetworkStreamingAudioEnabled.AutoSize = True
        Me.cbNetworkStreamingAudioEnabled.Location = New System.Drawing.Point(14, 444)
        Me.cbNetworkStreamingAudioEnabled.Name = "cbNetworkStreamingAudioEnabled"
        Me.cbNetworkStreamingAudioEnabled.Size = New System.Drawing.Size(88, 17)
        Me.cbNetworkStreamingAudioEnabled.TabIndex = 31
        Me.cbNetworkStreamingAudioEnabled.Text = "Stream audio"
        Me.cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = True
        '
        'cbNetworkStreaming
        '
        Me.cbNetworkStreaming.AutoSize = True
        Me.cbNetworkStreaming.Location = New System.Drawing.Point(14, 14)
        Me.cbNetworkStreaming.Name = "cbNetworkStreaming"
        Me.cbNetworkStreaming.Size = New System.Drawing.Size(155, 17)
        Me.cbNetworkStreaming.TabIndex = 28
        Me.cbNetworkStreaming.Text = "Network streaming enabled"
        Me.cbNetworkStreaming.UseVisualStyleBackColor = True
        '
        'TabPage32
        '
        Me.TabPage32.Controls.Add(Me.label328)
        Me.TabPage32.Controls.Add(Me.label327)
        Me.TabPage32.Controls.Add(Me.label326)
        Me.TabPage32.Controls.Add(Me.label325)
        Me.TabPage32.Controls.Add(Me.cbVirtualCamera)
        Me.TabPage32.Location = New System.Drawing.Point(4, 22)
        Me.TabPage32.Name = "TabPage32"
        Me.TabPage32.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage32.Size = New System.Drawing.Size(302, 474)
        Me.TabPage32.TabIndex = 10
        Me.TabPage32.Text = "Virtual camera"
        Me.TabPage32.UseVisualStyleBackColor = True
        '
        'label328
        '
        Me.label328.AutoSize = True
        Me.label328.Location = New System.Drawing.Point(17, 126)
        Me.label328.Name = "label328"
        Me.label328.Size = New System.Drawing.Size(197, 13)
        Me.label328.TabIndex = 7
        Me.label328.Text = "TRIAL limitation - 5000 frames to stream."
        '
        'label327
        '
        Me.label327.AutoSize = True
        Me.label327.Location = New System.Drawing.Point(17, 105)
        Me.label327.Name = "label327"
        Me.label327.Size = New System.Drawing.Size(180, 13)
        Me.label327.TabIndex = 6
        Me.label327.Text = "Virtual Camera SDK license required."
        '
        'label326
        '
        Me.label326.AutoSize = True
        Me.label326.Location = New System.Drawing.Point(17, 70)
        Me.label326.Name = "label326"
        Me.label326.Size = New System.Drawing.Size(111, 13)
        Me.label326.TabIndex = 5
        Me.label326.Text = "to see streamed video"
        '
        'label325
        '
        Me.label325.AutoSize = True
        Me.label325.Location = New System.Drawing.Point(17, 51)
        Me.label325.Name = "label325"
        Me.label325.Size = New System.Drawing.Size(243, 13)
        Me.label325.TabIndex = 4
        Me.label325.Text = "You are can use VisioForge Virtual Camera device"
        '
        'cbVirtualCamera
        '
        Me.cbVirtualCamera.AutoSize = True
        Me.cbVirtualCamera.Location = New System.Drawing.Point(20, 18)
        Me.cbVirtualCamera.Name = "cbVirtualCamera"
        Me.cbVirtualCamera.Size = New System.Drawing.Size(107, 17)
        Me.cbVirtualCamera.TabIndex = 3
        Me.cbVirtualCamera.Text = "Enable streaming"
        Me.cbVirtualCamera.UseVisualStyleBackColor = True
        '
        'TabPage34
        '
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputDownConversionAnalogOutput)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputDownConversion)
        Me.TabPage34.Controls.Add(Me.label337)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputHDTVPulldown)
        Me.TabPage34.Controls.Add(Me.label336)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputBlackToDeck)
        Me.TabPage34.Controls.Add(Me.label335)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputSingleField)
        Me.TabPage34.Controls.Add(Me.label334)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputComponentLevels)
        Me.TabPage34.Controls.Add(Me.label333)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputNTSC)
        Me.TabPage34.Controls.Add(Me.label332)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputDualLink)
        Me.TabPage34.Controls.Add(Me.label331)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutputAnalog)
        Me.TabPage34.Controls.Add(Me.label87)
        Me.TabPage34.Controls.Add(Me.cbDecklinkDV)
        Me.TabPage34.Controls.Add(Me.cbDecklinkOutput)
        Me.TabPage34.Location = New System.Drawing.Point(4, 22)
        Me.TabPage34.Name = "TabPage34"
        Me.TabPage34.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage34.Size = New System.Drawing.Size(302, 474)
        Me.TabPage34.TabIndex = 11
        Me.TabPage34.Text = "Decklink output"
        Me.TabPage34.UseVisualStyleBackColor = True
        '
        'cbDecklinkOutputDownConversionAnalogOutput
        '
        Me.cbDecklinkOutputDownConversionAnalogOutput.AutoSize = True
        Me.cbDecklinkOutputDownConversionAnalogOutput.Location = New System.Drawing.Point(26, 238)
        Me.cbDecklinkOutputDownConversionAnalogOutput.Name = "cbDecklinkOutputDownConversionAnalogOutput"
        Me.cbDecklinkOutputDownConversionAnalogOutput.Size = New System.Drawing.Size(118, 17)
        Me.cbDecklinkOutputDownConversionAnalogOutput.TabIndex = 52
        Me.cbDecklinkOutputDownConversionAnalogOutput.Text = "Analog output used"
        Me.cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = True
        '
        'cbDecklinkOutputDownConversion
        '
        Me.cbDecklinkOutputDownConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputDownConversion.FormattingEnabled = True
        Me.cbDecklinkOutputDownConversion.Items.AddRange(New Object() {"Default", "Disabled", "Letterbox 16:9", "Anamorphic", "Anamorphic center"})
        Me.cbDecklinkOutputDownConversion.Location = New System.Drawing.Point(26, 214)
        Me.cbDecklinkOutputDownConversion.Name = "cbDecklinkOutputDownConversion"
        Me.cbDecklinkOutputDownConversion.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputDownConversion.TabIndex = 51
        '
        'label337
        '
        Me.label337.AutoSize = True
        Me.label337.Location = New System.Drawing.Point(23, 199)
        Me.label337.Name = "label337"
        Me.label337.Size = New System.Drawing.Size(119, 13)
        Me.label337.TabIndex = 50
        Me.label337.Text = "Down conversion mode"
        '
        'cbDecklinkOutputHDTVPulldown
        '
        Me.cbDecklinkOutputHDTVPulldown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputHDTVPulldown.FormattingEnabled = True
        Me.cbDecklinkOutputHDTVPulldown.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputHDTVPulldown.Location = New System.Drawing.Point(26, 282)
        Me.cbDecklinkOutputHDTVPulldown.Name = "cbDecklinkOutputHDTVPulldown"
        Me.cbDecklinkOutputHDTVPulldown.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputHDTVPulldown.TabIndex = 49
        '
        'label336
        '
        Me.label336.AutoSize = True
        Me.label336.Location = New System.Drawing.Point(23, 268)
        Me.label336.Name = "label336"
        Me.label336.Size = New System.Drawing.Size(82, 13)
        Me.label336.TabIndex = 48
        Me.label336.Text = "HDTV pulldown"
        '
        'cbDecklinkOutputBlackToDeck
        '
        Me.cbDecklinkOutputBlackToDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputBlackToDeck.FormattingEnabled = True
        Me.cbDecklinkOutputBlackToDeck.Items.AddRange(New Object() {"Default", "None", "Digital", "Analogue"})
        Me.cbDecklinkOutputBlackToDeck.Location = New System.Drawing.Point(26, 169)
        Me.cbDecklinkOutputBlackToDeck.Name = "cbDecklinkOutputBlackToDeck"
        Me.cbDecklinkOutputBlackToDeck.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputBlackToDeck.TabIndex = 47
        '
        'label335
        '
        Me.label335.AutoSize = True
        Me.label335.Location = New System.Drawing.Point(23, 154)
        Me.label335.Name = "label335"
        Me.label335.Size = New System.Drawing.Size(73, 13)
        Me.label335.TabIndex = 46
        Me.label335.Text = "Black to deck"
        '
        'cbDecklinkOutputSingleField
        '
        Me.cbDecklinkOutputSingleField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputSingleField.FormattingEnabled = True
        Me.cbDecklinkOutputSingleField.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputSingleField.Location = New System.Drawing.Point(26, 126)
        Me.cbDecklinkOutputSingleField.Name = "cbDecklinkOutputSingleField"
        Me.cbDecklinkOutputSingleField.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputSingleField.TabIndex = 45
        '
        'label334
        '
        Me.label334.AutoSize = True
        Me.label334.Location = New System.Drawing.Point(23, 110)
        Me.label334.Name = "label334"
        Me.label334.Size = New System.Drawing.Size(91, 13)
        Me.label334.TabIndex = 44
        Me.label334.Text = "Single field output"
        '
        'cbDecklinkOutputComponentLevels
        '
        Me.cbDecklinkOutputComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputComponentLevels.FormattingEnabled = True
        Me.cbDecklinkOutputComponentLevels.Items.AddRange(New Object() {"SMPTE", "Betacam"})
        Me.cbDecklinkOutputComponentLevels.Location = New System.Drawing.Point(162, 169)
        Me.cbDecklinkOutputComponentLevels.Name = "cbDecklinkOutputComponentLevels"
        Me.cbDecklinkOutputComponentLevels.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputComponentLevels.TabIndex = 43
        '
        'label333
        '
        Me.label333.AutoSize = True
        Me.label333.Location = New System.Drawing.Point(159, 154)
        Me.label333.Name = "label333"
        Me.label333.Size = New System.Drawing.Size(91, 13)
        Me.label333.TabIndex = 42
        Me.label333.Text = "Component levels"
        '
        'cbDecklinkOutputNTSC
        '
        Me.cbDecklinkOutputNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputNTSC.FormattingEnabled = True
        Me.cbDecklinkOutputNTSC.Items.AddRange(New Object() {"USA", "Japan"})
        Me.cbDecklinkOutputNTSC.Location = New System.Drawing.Point(162, 126)
        Me.cbDecklinkOutputNTSC.Name = "cbDecklinkOutputNTSC"
        Me.cbDecklinkOutputNTSC.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputNTSC.TabIndex = 41
        '
        'label332
        '
        Me.label332.AutoSize = True
        Me.label332.Location = New System.Drawing.Point(159, 110)
        Me.label332.Name = "label332"
        Me.label332.Size = New System.Drawing.Size(80, 13)
        Me.label332.TabIndex = 40
        Me.label332.Text = "NTSC standard"
        '
        'cbDecklinkOutputDualLink
        '
        Me.cbDecklinkOutputDualLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputDualLink.FormattingEnabled = True
        Me.cbDecklinkOutputDualLink.Items.AddRange(New Object() {"Default", "Enabled", "Disabled"})
        Me.cbDecklinkOutputDualLink.Location = New System.Drawing.Point(26, 82)
        Me.cbDecklinkOutputDualLink.Name = "cbDecklinkOutputDualLink"
        Me.cbDecklinkOutputDualLink.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputDualLink.TabIndex = 39
        '
        'label331
        '
        Me.label331.AutoSize = True
        Me.label331.Location = New System.Drawing.Point(23, 68)
        Me.label331.Name = "label331"
        Me.label331.Size = New System.Drawing.Size(77, 13)
        Me.label331.TabIndex = 38
        Me.label331.Text = "Dual link mode"
        '
        'cbDecklinkOutputAnalog
        '
        Me.cbDecklinkOutputAnalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecklinkOutputAnalog.FormattingEnabled = True
        Me.cbDecklinkOutputAnalog.Items.AddRange(New Object() {"Auto", "Component", "Composite", "S-Video"})
        Me.cbDecklinkOutputAnalog.Location = New System.Drawing.Point(162, 82)
        Me.cbDecklinkOutputAnalog.Name = "cbDecklinkOutputAnalog"
        Me.cbDecklinkOutputAnalog.Size = New System.Drawing.Size(121, 21)
        Me.cbDecklinkOutputAnalog.TabIndex = 37
        '
        'label87
        '
        Me.label87.AutoSize = True
        Me.label87.Location = New System.Drawing.Point(159, 68)
        Me.label87.Name = "label87"
        Me.label87.Size = New System.Drawing.Size(73, 13)
        Me.label87.TabIndex = 36
        Me.label87.Text = "Analog output"
        '
        'cbDecklinkDV
        '
        Me.cbDecklinkDV.AutoSize = True
        Me.cbDecklinkDV.Location = New System.Drawing.Point(35, 38)
        Me.cbDecklinkDV.Name = "cbDecklinkDV"
        Me.cbDecklinkDV.Size = New System.Drawing.Size(74, 17)
        Me.cbDecklinkDV.TabIndex = 3
        Me.cbDecklinkDV.Text = "DV output"
        Me.cbDecklinkDV.UseVisualStyleBackColor = True
        '
        'cbDecklinkOutput
        '
        Me.cbDecklinkOutput.AutoSize = True
        Me.cbDecklinkOutput.Location = New System.Drawing.Point(17, 16)
        Me.cbDecklinkOutput.Name = "cbDecklinkOutput"
        Me.cbDecklinkOutput.Size = New System.Drawing.Size(173, 17)
        Me.cbDecklinkOutput.TabIndex = 2
        Me.cbDecklinkOutput.Text = "Enable output to Decklink card"
        Me.cbDecklinkOutput.UseVisualStyleBackColor = True
        '
        'TabPage43
        '
        Me.TabPage43.Controls.Add(Me.groupBox48)
        Me.TabPage43.Controls.Add(Me.groupBox47)
        Me.TabPage43.Controls.Add(Me.groupBox43)
        Me.TabPage43.Location = New System.Drawing.Point(4, 22)
        Me.TabPage43.Name = "TabPage43"
        Me.TabPage43.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage43.Size = New System.Drawing.Size(302, 474)
        Me.TabPage43.TabIndex = 12
        Me.TabPage43.Text = "Encryption"
        Me.TabPage43.UseVisualStyleBackColor = True
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
        Me.groupBox48.Location = New System.Drawing.Point(16, 186)
        Me.groupBox48.Name = "groupBox48"
        Me.groupBox48.Size = New System.Drawing.Size(269, 216)
        Me.groupBox48.TabIndex = 14
        Me.groupBox48.TabStop = False
        Me.groupBox48.Text = "Encryption key type"
        '
        'label343
        '
        Me.label343.AutoSize = True
        Me.label343.Location = New System.Drawing.Point(33, 192)
        Me.label343.Name = "label343"
        Me.label343.Size = New System.Drawing.Size(157, 13)
        Me.label343.TabIndex = 10
        Me.label343.Text = "You can assign byte[] using API"
        '
        'edEncryptionKeyHEX
        '
        Me.edEncryptionKeyHEX.Location = New System.Drawing.Point(36, 169)
        Me.edEncryptionKeyHEX.Name = "edEncryptionKeyHEX"
        Me.edEncryptionKeyHEX.Size = New System.Drawing.Size(214, 20)
        Me.edEncryptionKeyHEX.TabIndex = 9
        Me.edEncryptionKeyHEX.Text = "enter hex data"
        '
        'rbEncryptionKeyBinary
        '
        Me.rbEncryptionKeyBinary.AutoSize = True
        Me.rbEncryptionKeyBinary.Location = New System.Drawing.Point(14, 147)
        Me.rbEncryptionKeyBinary.Name = "rbEncryptionKeyBinary"
        Me.rbEncryptionKeyBinary.Size = New System.Drawing.Size(124, 17)
        Me.rbEncryptionKeyBinary.TabIndex = 8
        Me.rbEncryptionKeyBinary.Text = "Binary data (v9 SDK)"
        Me.rbEncryptionKeyBinary.UseVisualStyleBackColor = True
        '
        'btEncryptionOpenFile
        '
        Me.btEncryptionOpenFile.Location = New System.Drawing.Point(227, 110)
        Me.btEncryptionOpenFile.Name = "btEncryptionOpenFile"
        Me.btEncryptionOpenFile.Size = New System.Drawing.Size(23, 22)
        Me.btEncryptionOpenFile.TabIndex = 7
        Me.btEncryptionOpenFile.Text = "..."
        Me.btEncryptionOpenFile.UseVisualStyleBackColor = True
        '
        'edEncryptionKeyFile
        '
        Me.edEncryptionKeyFile.Location = New System.Drawing.Point(36, 112)
        Me.edEncryptionKeyFile.Name = "edEncryptionKeyFile"
        Me.edEncryptionKeyFile.Size = New System.Drawing.Size(185, 20)
        Me.edEncryptionKeyFile.TabIndex = 6
        Me.edEncryptionKeyFile.Text = "c:\keyfile.txt"
        '
        'rbEncryptionKeyFile
        '
        Me.rbEncryptionKeyFile.AutoSize = True
        Me.rbEncryptionKeyFile.Location = New System.Drawing.Point(14, 90)
        Me.rbEncryptionKeyFile.Name = "rbEncryptionKeyFile"
        Me.rbEncryptionKeyFile.Size = New System.Drawing.Size(87, 17)
        Me.rbEncryptionKeyFile.TabIndex = 5
        Me.rbEncryptionKeyFile.Text = "File (v9 SDK)"
        Me.rbEncryptionKeyFile.UseVisualStyleBackColor = True
        '
        'edEncryptionKeyString
        '
        Me.edEncryptionKeyString.Location = New System.Drawing.Point(36, 54)
        Me.edEncryptionKeyString.Name = "edEncryptionKeyString"
        Me.edEncryptionKeyString.Size = New System.Drawing.Size(214, 20)
        Me.edEncryptionKeyString.TabIndex = 4
        Me.edEncryptionKeyString.Text = "100"
        '
        'rbEncryptionKeyString
        '
        Me.rbEncryptionKeyString.AutoSize = True
        Me.rbEncryptionKeyString.Checked = True
        Me.rbEncryptionKeyString.Location = New System.Drawing.Point(14, 27)
        Me.rbEncryptionKeyString.Name = "rbEncryptionKeyString"
        Me.rbEncryptionKeyString.Size = New System.Drawing.Size(52, 17)
        Me.rbEncryptionKeyString.TabIndex = 0
        Me.rbEncryptionKeyString.TabStop = True
        Me.rbEncryptionKeyString.Text = "String"
        Me.rbEncryptionKeyString.UseVisualStyleBackColor = True
        '
        'groupBox47
        '
        Me.groupBox47.Controls.Add(Me.rbEncryptionModeAES256)
        Me.groupBox47.Controls.Add(Me.rbEncryptionModeAES128)
        Me.groupBox47.Location = New System.Drawing.Point(16, 14)
        Me.groupBox47.Name = "groupBox47"
        Me.groupBox47.Size = New System.Drawing.Size(269, 80)
        Me.groupBox47.TabIndex = 13
        Me.groupBox47.TabStop = False
        Me.groupBox47.Text = "Method"
        '
        'rbEncryptionModeAES256
        '
        Me.rbEncryptionModeAES256.AutoSize = True
        Me.rbEncryptionModeAES256.Checked = True
        Me.rbEncryptionModeAES256.Location = New System.Drawing.Point(14, 49)
        Me.rbEncryptionModeAES256.Name = "rbEncryptionModeAES256"
        Me.rbEncryptionModeAES256.Size = New System.Drawing.Size(198, 17)
        Me.rbEncryptionModeAES256.TabIndex = 1
        Me.rbEncryptionModeAES256.TabStop = True
        Me.rbEncryptionModeAES256.Text = "AES-256 (v9 encryption SDK output)"
        Me.rbEncryptionModeAES256.UseVisualStyleBackColor = True
        '
        'rbEncryptionModeAES128
        '
        Me.rbEncryptionModeAES128.AutoSize = True
        Me.rbEncryptionModeAES128.Location = New System.Drawing.Point(14, 27)
        Me.rbEncryptionModeAES128.Name = "rbEncryptionModeAES128"
        Me.rbEncryptionModeAES128.Size = New System.Drawing.Size(198, 17)
        Me.rbEncryptionModeAES128.TabIndex = 0
        Me.rbEncryptionModeAES128.Text = "AES-128 (v8 encryption SDK output)"
        Me.rbEncryptionModeAES128.UseVisualStyleBackColor = True
        '
        'groupBox43
        '
        Me.groupBox43.Controls.Add(Me.rbEncryptedH264CUDA)
        Me.groupBox43.Controls.Add(Me.rbEncryptedH264SW)
        Me.groupBox43.Location = New System.Drawing.Point(16, 100)
        Me.groupBox43.Name = "groupBox43"
        Me.groupBox43.Size = New System.Drawing.Size(269, 80)
        Me.groupBox43.TabIndex = 12
        Me.groupBox43.TabStop = False
        Me.groupBox43.Text = "Video / audio format"
        '
        'rbEncryptedH264CUDA
        '
        Me.rbEncryptedH264CUDA.AutoSize = True
        Me.rbEncryptedH264CUDA.Enabled = False
        Me.rbEncryptedH264CUDA.Location = New System.Drawing.Point(14, 49)
        Me.rbEncryptedH264CUDA.Name = "rbEncryptedH264CUDA"
        Me.rbEncryptedH264CUDA.Size = New System.Drawing.Size(260, 17)
        Me.rbEncryptedH264CUDA.TabIndex = 7
        Me.rbEncryptedH264CUDA.Text = "[Deprecated] Use MP4 H264 CUDA / AAC format"
        Me.rbEncryptedH264CUDA.UseVisualStyleBackColor = True
        '
        'rbEncryptedH264SW
        '
        Me.rbEncryptedH264SW.AutoSize = True
        Me.rbEncryptedH264SW.Checked = True
        Me.rbEncryptedH264SW.Location = New System.Drawing.Point(14, 27)
        Me.rbEncryptedH264SW.Name = "rbEncryptedH264SW"
        Me.rbEncryptedH264SW.Size = New System.Drawing.Size(195, 17)
        Me.rbEncryptedH264SW.TabIndex = 6
        Me.rbEncryptedH264SW.TabStop = True
        Me.rbEncryptedH264SW.Text = "Use MP4 H264 / ACC output format"
        Me.rbEncryptedH264SW.UseVisualStyleBackColor = True
        '
        'TabPage78
        '
        Me.TabPage78.Controls.Add(Me.TabControl32)
        Me.TabPage78.Controls.Add(Me.cbTagEnabled)
        Me.TabPage78.Location = New System.Drawing.Point(4, 22)
        Me.TabPage78.Name = "TabPage78"
        Me.TabPage78.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage78.Size = New System.Drawing.Size(302, 474)
        Me.TabPage78.TabIndex = 14
        Me.TabPage78.Text = "Tags"
        Me.TabPage78.UseVisualStyleBackColor = True
        '
        'TabControl32
        '
        Me.TabControl32.Location = New System.Drawing.Point(5, 44)
        Me.TabControl32.Name = "TabControl32"
        Me.TabControl32.SelectedIndex = 0
        Me.TabControl32.Size = New System.Drawing.Size(292, 416)
        Me.TabControl32.TabIndex = 3
        '
        'cbTagEnabled
        '
        Me.cbTagEnabled.AutoSize = True
        Me.cbTagEnabled.Location = New System.Drawing.Point(14, 16)
        Me.cbTagEnabled.Name = "cbTagEnabled"
        Me.cbTagEnabled.Size = New System.Drawing.Size(135, 17)
        Me.cbTagEnabled.TabIndex = 2
        Me.cbTagEnabled.Text = "Write tags to output file"
        Me.cbTagEnabled.UseVisualStyleBackColor = True
        '
        'TabPage22
        '
        Me.TabPage22.Controls.Add(Me.tbVUMeterBoost)
        Me.TabPage22.Controls.Add(Me.label382)
        Me.TabPage22.Controls.Add(Me.label381)
        Me.TabPage22.Controls.Add(Me.tbVUMeterAmplification)
        Me.TabPage22.Controls.Add(Me.cbVUMeterPro)
        Me.TabPage22.Controls.Add(Me.waveformPainter2)
        Me.TabPage22.Controls.Add(Me.waveformPainter1)
        Me.TabPage22.Controls.Add(Me.volumeMeter2)
        Me.TabPage22.Controls.Add(Me.volumeMeter1)
        Me.TabPage22.Controls.Add(Me.peakMeterCtrl1)
        Me.TabPage22.Controls.Add(Me.cbVUMeter)
        Me.TabPage22.Location = New System.Drawing.Point(4, 22)
        Me.TabPage22.Name = "TabPage22"
        Me.TabPage22.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage22.Size = New System.Drawing.Size(302, 474)
        Me.TabPage22.TabIndex = 16
        Me.TabPage22.Text = "Audio output"
        Me.TabPage22.UseVisualStyleBackColor = True
        '
        'tbVUMeterBoost
        '
        Me.tbVUMeterBoost.Location = New System.Drawing.Point(171, 246)
        Me.tbVUMeterBoost.Maximum = 30
        Me.tbVUMeterBoost.Name = "tbVUMeterBoost"
        Me.tbVUMeterBoost.Size = New System.Drawing.Size(104, 45)
        Me.tbVUMeterBoost.TabIndex = 133
        Me.tbVUMeterBoost.Value = 10
        '
        'label382
        '
        Me.label382.AutoSize = True
        Me.label382.Location = New System.Drawing.Point(168, 231)
        Me.label382.Name = "label382"
        Me.label382.Size = New System.Drawing.Size(68, 13)
        Me.label382.TabIndex = 132
        Me.label382.Text = "Meters boost"
        '
        'label381
        '
        Me.label381.AutoSize = True
        Me.label381.Location = New System.Drawing.Point(20, 231)
        Me.label381.Name = "label381"
        Me.label381.Size = New System.Drawing.Size(120, 13)
        Me.label381.TabIndex = 128
        Me.label381.Text = "Volume amplification (%)"
        '
        'tbVUMeterAmplification
        '
        Me.tbVUMeterAmplification.Location = New System.Drawing.Point(23, 246)
        Me.tbVUMeterAmplification.Maximum = 100
        Me.tbVUMeterAmplification.Name = "tbVUMeterAmplification"
        Me.tbVUMeterAmplification.Size = New System.Drawing.Size(105, 45)
        Me.tbVUMeterAmplification.TabIndex = 127
        Me.tbVUMeterAmplification.Value = 100
        '
        'cbVUMeterPro
        '
        Me.cbVUMeterPro.AutoSize = True
        Me.cbVUMeterPro.Location = New System.Drawing.Point(12, 84)
        Me.cbVUMeterPro.Name = "cbVUMeterPro"
        Me.cbVUMeterPro.Size = New System.Drawing.Size(125, 17)
        Me.cbVUMeterPro.TabIndex = 126
        Me.cbVUMeterPro.Text = "Enable VU meter Pro"
        Me.cbVUMeterPro.UseVisualStyleBackColor = True
        '
        'waveformPainter2
        '
        Me.waveformPainter2.Boost = 1.0!
        Me.waveformPainter2.Location = New System.Drawing.Point(101, 168)
        Me.waveformPainter2.Name = "waveformPainter2"
        Me.waveformPainter2.Size = New System.Drawing.Size(174, 58)
        Me.waveformPainter2.TabIndex = 131
        Me.waveformPainter2.Text = "waveformPainter2"
        '
        'waveformPainter1
        '
        Me.waveformPainter1.Boost = 1.0!
        Me.waveformPainter1.Location = New System.Drawing.Point(101, 104)
        Me.waveformPainter1.Name = "waveformPainter1"
        Me.waveformPainter1.Size = New System.Drawing.Size(174, 58)
        Me.waveformPainter1.TabIndex = 130
        Me.waveformPainter1.Text = "waveformPainter1"
        '
        'volumeMeter2
        '
        Me.volumeMeter2.Amplitude = 0!
        Me.volumeMeter2.BackColor = System.Drawing.Color.LightGray
        Me.volumeMeter2.Boost = 1.0!
        Me.volumeMeter2.Location = New System.Drawing.Point(51, 104)
        Me.volumeMeter2.MaxDb = 18.0!
        Me.volumeMeter2.MinDb = -60.0!
        Me.volumeMeter2.Name = "volumeMeter2"
        Me.volumeMeter2.Size = New System.Drawing.Size(22, 121)
        Me.volumeMeter2.TabIndex = 129
        '
        'volumeMeter1
        '
        Me.volumeMeter1.Amplitude = 0!
        Me.volumeMeter1.BackColor = System.Drawing.Color.LightGray
        Me.volumeMeter1.Boost = 1.0!
        Me.volumeMeter1.Location = New System.Drawing.Point(23, 104)
        Me.volumeMeter1.MaxDb = 18.0!
        Me.volumeMeter1.MinDb = -60.0!
        Me.volumeMeter1.Name = "volumeMeter1"
        Me.volumeMeter1.Size = New System.Drawing.Size(22, 121)
        Me.volumeMeter1.TabIndex = 125
        '
        'peakMeterCtrl1
        '
        Me.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red
        Me.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow
        Me.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green
        Me.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro
        Me.peakMeterCtrl1.Location = New System.Drawing.Point(125, 12)
        Me.peakMeterCtrl1.Name = "peakMeterCtrl1"
        Me.peakMeterCtrl1.Size = New System.Drawing.Size(105, 58)
        Me.peakMeterCtrl1.TabIndex = 104
        Me.peakMeterCtrl1.Text = "peakMeterCtrl1"
        '
        'cbVUMeter
        '
        Me.cbVUMeter.AutoSize = True
        Me.cbVUMeter.Location = New System.Drawing.Point(12, 12)
        Me.cbVUMeter.Name = "cbVUMeter"
        Me.cbVUMeter.Size = New System.Drawing.Size(107, 17)
        Me.cbVUMeter.TabIndex = 103
        Me.cbVUMeter.Text = "Enable VU Meter"
        Me.cbVUMeter.UseVisualStyleBackColor = True
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(243, 551)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(78, 13)
        Me.linkLabel1.TabIndex = 85
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Watch tutorials"
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(698, 600)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(58, 22)
        Me.btStop.TabIndex = 88
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(631, 600)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(58, 22)
        Me.btStart.TabIndex = 87
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(441, 600)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(184, 22)
        Me.ProgressBar1.TabIndex = 86
        '
        'tbSeeking
        '
        Me.tbSeeking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbSeeking.Location = New System.Drawing.Point(327, 600)
        Me.tbSeeking.Name = "tbSeeking"
        Me.tbSeeking.Size = New System.Drawing.Size(108, 45)
        Me.tbSeeking.TabIndex = 89
        '
        'openFileDialog3
        '
        Me.openFileDialog3.FileName = "openFileDialog3"
        Me.openFileDialog3.Filter = "Windows Media profile|*.prx"
        '
        'tabControl3
        '
        Me.tabControl3.Controls.Add(Me.tabPage52)
        Me.tabControl3.Controls.Add(Me.tabPage53)
        Me.tabControl3.Controls.Add(Me.tabPage54)
        Me.tabControl3.Controls.Add(Me.TabPage74)
        Me.tabControl3.Location = New System.Drawing.Point(331, 12)
        Me.tabControl3.Name = "tabControl3"
        Me.tabControl3.SelectedIndex = 0
        Me.tabControl3.Size = New System.Drawing.Size(425, 292)
        Me.tabControl3.TabIndex = 91
        '
        'tabPage52
        '
        Me.tabPage52.Controls.Add(Me.groupBox7)
        Me.tabPage52.Controls.Add(Me.label50)
        Me.tabPage52.Controls.Add(Me.groupBox6)
        Me.tabPage52.Controls.Add(Me.btClearList)
        Me.tabPage52.Controls.Add(Me.btAddInputFile)
        Me.tabPage52.Controls.Add(Me.lbFiles)
        Me.tabPage52.Controls.Add(Me.label10)
        Me.tabPage52.Location = New System.Drawing.Point(4, 22)
        Me.tabPage52.Name = "tabPage52"
        Me.tabPage52.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage52.Size = New System.Drawing.Size(417, 266)
        Me.tabPage52.TabIndex = 0
        Me.tabPage52.Text = "Edit"
        Me.tabPage52.UseVisualStyleBackColor = True
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.label72)
        Me.groupBox7.Controls.Add(Me.edInsertTime)
        Me.groupBox7.Controls.Add(Me.label73)
        Me.groupBox7.Controls.Add(Me.cbInsertAfterPreviousFile)
        Me.groupBox7.Location = New System.Drawing.Point(253, 110)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(147, 126)
        Me.groupBox7.TabIndex = 56
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Timeline"
        '
        'label72
        '
        Me.label72.AutoSize = True
        Me.label72.Location = New System.Drawing.Point(116, 44)
        Me.label72.Name = "label72"
        Me.label72.Size = New System.Drawing.Size(20, 13)
        Me.label72.TabIndex = 42
        Me.label72.Text = "ms"
        '
        'edInsertTime
        '
        Me.edInsertTime.Location = New System.Drawing.Point(76, 40)
        Me.edInsertTime.Name = "edInsertTime"
        Me.edInsertTime.Size = New System.Drawing.Size(34, 20)
        Me.edInsertTime.TabIndex = 41
        Me.edInsertTime.Text = "4000"
        '
        'label73
        '
        Me.label73.AutoSize = True
        Me.label73.Location = New System.Drawing.Point(12, 44)
        Me.label73.Name = "label73"
        Me.label73.Size = New System.Drawing.Size(55, 13)
        Me.label73.TabIndex = 40
        Me.label73.Text = "Insert time"
        '
        'cbInsertAfterPreviousFile
        '
        Me.cbInsertAfterPreviousFile.AutoSize = True
        Me.cbInsertAfterPreviousFile.Checked = True
        Me.cbInsertAfterPreviousFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbInsertAfterPreviousFile.Location = New System.Drawing.Point(12, 18)
        Me.cbInsertAfterPreviousFile.Name = "cbInsertAfterPreviousFile"
        Me.cbInsertAfterPreviousFile.Size = New System.Drawing.Size(135, 17)
        Me.cbInsertAfterPreviousFile.TabIndex = 39
        Me.cbInsertAfterPreviousFile.Text = "Insert after previous file"
        Me.cbInsertAfterPreviousFile.UseVisualStyleBackColor = True
        '
        'label50
        '
        Me.label50.AutoSize = True
        Me.label50.Location = New System.Drawing.Point(6, 88)
        Me.label50.Name = "label50"
        Me.label50.Size = New System.Drawing.Size(250, 13)
        Me.label50.TabIndex = 55
        Me.label50.Text = "You must set this parameters before you add the file"
        '
        'groupBox6
        '
        Me.groupBox6.Controls.Add(Me.lbSpeed)
        Me.groupBox6.Controls.Add(Me.label42)
        Me.groupBox6.Controls.Add(Me.label37)
        Me.groupBox6.Controls.Add(Me.edStopTime)
        Me.groupBox6.Controls.Add(Me.label38)
        Me.groupBox6.Controls.Add(Me.label36)
        Me.groupBox6.Controls.Add(Me.edStartTime)
        Me.groupBox6.Controls.Add(Me.label35)
        Me.groupBox6.Controls.Add(Me.cbAddFullFile)
        Me.groupBox6.Controls.Add(Me.tbSpeed)
        Me.groupBox6.Location = New System.Drawing.Point(9, 110)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(238, 126)
        Me.groupBox6.TabIndex = 54
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Input file"
        '
        'lbSpeed
        '
        Me.lbSpeed.AutoSize = True
        Me.lbSpeed.Location = New System.Drawing.Point(200, 71)
        Me.lbSpeed.Name = "lbSpeed"
        Me.lbSpeed.Size = New System.Drawing.Size(33, 13)
        Me.lbSpeed.TabIndex = 44
        Me.lbSpeed.Text = "100%"
        '
        'label42
        '
        Me.label42.AutoSize = True
        Me.label42.Location = New System.Drawing.Point(12, 71)
        Me.label42.Name = "label42"
        Me.label42.Size = New System.Drawing.Size(83, 13)
        Me.label42.TabIndex = 42
        Me.label42.Text = "Playback speed"
        '
        'label37
        '
        Me.label37.AutoSize = True
        Me.label37.Location = New System.Drawing.Point(213, 44)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(20, 13)
        Me.label37.TabIndex = 41
        Me.label37.Text = "ms"
        '
        'edStopTime
        '
        Me.edStopTime.Location = New System.Drawing.Point(178, 40)
        Me.edStopTime.Name = "edStopTime"
        Me.edStopTime.Size = New System.Drawing.Size(32, 20)
        Me.edStopTime.TabIndex = 40
        Me.edStopTime.Text = "5000"
        '
        'label38
        '
        Me.label38.AutoSize = True
        Me.label38.Location = New System.Drawing.Point(127, 44)
        Me.label38.Name = "label38"
        Me.label38.Size = New System.Drawing.Size(51, 13)
        Me.label38.TabIndex = 39
        Me.label38.Text = "Stop time"
        '
        'label36
        '
        Me.label36.AutoSize = True
        Me.label36.Location = New System.Drawing.Point(92, 44)
        Me.label36.Name = "label36"
        Me.label36.Size = New System.Drawing.Size(20, 13)
        Me.label36.TabIndex = 38
        Me.label36.Text = "ms"
        '
        'edStartTime
        '
        Me.edStartTime.Location = New System.Drawing.Point(67, 40)
        Me.edStartTime.Name = "edStartTime"
        Me.edStartTime.Size = New System.Drawing.Size(22, 20)
        Me.edStartTime.TabIndex = 37
        Me.edStartTime.Text = "0"
        '
        'label35
        '
        Me.label35.AutoSize = True
        Me.label35.Location = New System.Drawing.Point(12, 44)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(51, 13)
        Me.label35.TabIndex = 36
        Me.label35.Text = "Start time"
        '
        'cbAddFullFile
        '
        Me.cbAddFullFile.AutoSize = True
        Me.cbAddFullFile.Checked = True
        Me.cbAddFullFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAddFullFile.Location = New System.Drawing.Point(12, 18)
        Me.cbAddFullFile.Name = "cbAddFullFile"
        Me.cbAddFullFile.Size = New System.Drawing.Size(77, 17)
        Me.cbAddFullFile.TabIndex = 35
        Me.cbAddFullFile.Text = "Add full file"
        Me.cbAddFullFile.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(101, 66)
        Me.tbSpeed.Maximum = 400
        Me.tbSpeed.Minimum = 10
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(99, 45)
        Me.tbSpeed.TabIndex = 43
        Me.tbSpeed.Value = 100
        '
        'btClearList
        '
        Me.btClearList.Location = New System.Drawing.Point(336, 54)
        Me.btClearList.Name = "btClearList"
        Me.btClearList.Size = New System.Drawing.Size(64, 22)
        Me.btClearList.TabIndex = 53
        Me.btClearList.Text = "Clear"
        Me.btClearList.UseVisualStyleBackColor = True
        '
        'btAddInputFile
        '
        Me.btAddInputFile.Location = New System.Drawing.Point(336, 26)
        Me.btAddInputFile.Name = "btAddInputFile"
        Me.btAddInputFile.Size = New System.Drawing.Size(64, 22)
        Me.btAddInputFile.TabIndex = 52
        Me.btAddInputFile.Text = "Add"
        Me.btAddInputFile.UseVisualStyleBackColor = True
        '
        'lbFiles
        '
        Me.lbFiles.FormattingEnabled = True
        Me.lbFiles.Location = New System.Drawing.Point(9, 26)
        Me.lbFiles.Name = "lbFiles"
        Me.lbFiles.Size = New System.Drawing.Size(321, 56)
        Me.lbFiles.TabIndex = 51
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 6)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(52, 13)
        Me.label10.TabIndex = 50
        Me.label10.Text = "Input files"
        '
        'tabPage53
        '
        Me.tabPage53.Controls.Add(Me.label134)
        Me.tabPage53.Controls.Add(Me.btSelectOutputCut)
        Me.tabPage53.Controls.Add(Me.edOutputFileCut)
        Me.tabPage53.Controls.Add(Me.label131)
        Me.tabPage53.Controls.Add(Me.btStopCut)
        Me.tabPage53.Controls.Add(Me.btStartCut)
        Me.tabPage53.Controls.Add(Me.label31)
        Me.tabPage53.Controls.Add(Me.btAddInputFile2)
        Me.tabPage53.Controls.Add(Me.edSourceFileToCut)
        Me.tabPage53.Controls.Add(Me.label30)
        Me.tabPage53.Controls.Add(Me.label26)
        Me.tabPage53.Controls.Add(Me.edStopTimeCut)
        Me.tabPage53.Controls.Add(Me.label27)
        Me.tabPage53.Controls.Add(Me.label28)
        Me.tabPage53.Controls.Add(Me.edStartTimeCut)
        Me.tabPage53.Controls.Add(Me.label29)
        Me.tabPage53.Location = New System.Drawing.Point(4, 22)
        Me.tabPage53.Name = "tabPage53"
        Me.tabPage53.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage53.Size = New System.Drawing.Size(417, 266)
        Me.tabPage53.TabIndex = 1
        Me.tabPage53.Text = "Cut file (w/o reencoding)"
        Me.tabPage53.UseVisualStyleBackColor = True
        '
        'label134
        '
        Me.label134.AutoSize = True
        Me.label134.Location = New System.Drawing.Point(17, 181)
        Me.label134.Name = "label134"
        Me.label134.Size = New System.Drawing.Size(221, 13)
        Me.label134.TabIndex = 72
        Me.label134.Text = "Better to specify start time based on keyframe"
        '
        'btSelectOutputCut
        '
        Me.btSelectOutputCut.Location = New System.Drawing.Point(368, 104)
        Me.btSelectOutputCut.Name = "btSelectOutputCut"
        Me.btSelectOutputCut.Size = New System.Drawing.Size(24, 22)
        Me.btSelectOutputCut.TabIndex = 71
        Me.btSelectOutputCut.Text = "..."
        Me.btSelectOutputCut.UseVisualStyleBackColor = True
        '
        'edOutputFileCut
        '
        Me.edOutputFileCut.Location = New System.Drawing.Point(83, 106)
        Me.edOutputFileCut.Name = "edOutputFileCut"
        Me.edOutputFileCut.Size = New System.Drawing.Size(279, 20)
        Me.edOutputFileCut.TabIndex = 70
        Me.edOutputFileCut.Text = "c:\vf\video_edit_output.avi"
        '
        'label131
        '
        Me.label131.AutoSize = True
        Me.label131.Location = New System.Drawing.Point(17, 108)
        Me.label131.Name = "label131"
        Me.label131.Size = New System.Drawing.Size(55, 13)
        Me.label131.TabIndex = 69
        Me.label131.Text = "Output file"
        '
        'btStopCut
        '
        Me.btStopCut.Location = New System.Drawing.Point(100, 147)
        Me.btStopCut.Name = "btStopCut"
        Me.btStopCut.Size = New System.Drawing.Size(75, 22)
        Me.btStopCut.TabIndex = 68
        Me.btStopCut.Text = "Stop"
        Me.btStopCut.UseVisualStyleBackColor = True
        '
        'btStartCut
        '
        Me.btStartCut.Location = New System.Drawing.Point(19, 147)
        Me.btStartCut.Name = "btStartCut"
        Me.btStartCut.Size = New System.Drawing.Size(75, 22)
        Me.btStartCut.TabIndex = 67
        Me.btStartCut.Text = "Start"
        Me.btStartCut.UseVisualStyleBackColor = True
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Location = New System.Drawing.Point(80, 74)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(183, 13)
        Me.label31.TabIndex = 66
        Me.label31.Text = "Specify time before adding source file"
        '
        'btAddInputFile2
        '
        Me.btAddInputFile2.Location = New System.Drawing.Point(368, 12)
        Me.btAddInputFile2.Name = "btAddInputFile2"
        Me.btAddInputFile2.Size = New System.Drawing.Size(24, 22)
        Me.btAddInputFile2.TabIndex = 65
        Me.btAddInputFile2.Text = "..."
        Me.btAddInputFile2.UseVisualStyleBackColor = True
        '
        'edSourceFileToCut
        '
        Me.edSourceFileToCut.Location = New System.Drawing.Point(83, 14)
        Me.edSourceFileToCut.Name = "edSourceFileToCut"
        Me.edSourceFileToCut.Size = New System.Drawing.Size(279, 20)
        Me.edSourceFileToCut.TabIndex = 64
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(15, 16)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(57, 13)
        Me.label30.TabIndex = 63
        Me.label30.Text = "Source file"
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Location = New System.Drawing.Point(291, 48)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(20, 13)
        Me.label26.TabIndex = 62
        Me.label26.Text = "ms"
        '
        'edStopTimeCut
        '
        Me.edStopTimeCut.Location = New System.Drawing.Point(239, 46)
        Me.edStopTimeCut.Name = "edStopTimeCut"
        Me.edStopTimeCut.Size = New System.Drawing.Size(46, 20)
        Me.edStopTimeCut.TabIndex = 61
        Me.edStopTimeCut.Text = "5000"
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Location = New System.Drawing.Point(182, 49)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(51, 13)
        Me.label27.TabIndex = 60
        Me.label27.Text = "Stop time"
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.Location = New System.Drawing.Point(135, 49)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(20, 13)
        Me.label28.TabIndex = 59
        Me.label28.Text = "ms"
        '
        'edStartTimeCut
        '
        Me.edStartTimeCut.Location = New System.Drawing.Point(83, 46)
        Me.edStartTimeCut.Name = "edStartTimeCut"
        Me.edStartTimeCut.Size = New System.Drawing.Size(46, 20)
        Me.edStartTimeCut.TabIndex = 58
        Me.edStartTimeCut.Text = "0"
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(17, 49)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(51, 13)
        Me.label29.TabIndex = 57
        Me.label29.Text = "Start time"
        '
        'tabPage54
        '
        Me.tabPage54.Controls.Add(Me.label1)
        Me.tabPage54.Controls.Add(Me.btSelectOutputJoin)
        Me.tabPage54.Controls.Add(Me.edOutputFileJoin)
        Me.tabPage54.Controls.Add(Me.label132)
        Me.tabPage54.Controls.Add(Me.btStopJoin)
        Me.tabPage54.Controls.Add(Me.btStartJoin)
        Me.tabPage54.Controls.Add(Me.btClearList3)
        Me.tabPage54.Controls.Add(Me.btAddInputFile3)
        Me.tabPage54.Controls.Add(Me.lbFiles2)
        Me.tabPage54.Controls.Add(Me.label32)
        Me.tabPage54.Location = New System.Drawing.Point(4, 22)
        Me.tabPage54.Name = "tabPage54"
        Me.tabPage54.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage54.Size = New System.Drawing.Size(417, 266)
        Me.tabPage54.TabIndex = 2
        Me.tabPage54.Text = "Join files (w/o reencoding)"
        Me.tabPage54.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 209)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(333, 13)
        Me.label1.TabIndex = 72
        Me.label1.Text = "Source files should have identical video and audio stream parameters"
        '
        'btSelectOutputJoin
        '
        Me.btSelectOutputJoin.Location = New System.Drawing.Point(365, 102)
        Me.btSelectOutputJoin.Name = "btSelectOutputJoin"
        Me.btSelectOutputJoin.Size = New System.Drawing.Size(24, 22)
        Me.btSelectOutputJoin.TabIndex = 71
        Me.btSelectOutputJoin.Text = "..."
        Me.btSelectOutputJoin.UseVisualStyleBackColor = True
        '
        'edOutputFileJoin
        '
        Me.edOutputFileJoin.Location = New System.Drawing.Point(87, 104)
        Me.edOutputFileJoin.Name = "edOutputFileJoin"
        Me.edOutputFileJoin.Size = New System.Drawing.Size(272, 20)
        Me.edOutputFileJoin.TabIndex = 70
        Me.edOutputFileJoin.Text = "c:\vf\video_edit_output.avi"
        '
        'label132
        '
        Me.label132.AutoSize = True
        Me.label132.Location = New System.Drawing.Point(15, 106)
        Me.label132.Name = "label132"
        Me.label132.Size = New System.Drawing.Size(55, 13)
        Me.label132.TabIndex = 69
        Me.label132.Text = "Output file"
        '
        'btStopJoin
        '
        Me.btStopJoin.Location = New System.Drawing.Point(99, 148)
        Me.btStopJoin.Name = "btStopJoin"
        Me.btStopJoin.Size = New System.Drawing.Size(75, 22)
        Me.btStopJoin.TabIndex = 68
        Me.btStopJoin.Text = "Stop"
        Me.btStopJoin.UseVisualStyleBackColor = True
        '
        'btStartJoin
        '
        Me.btStartJoin.Location = New System.Drawing.Point(18, 148)
        Me.btStartJoin.Name = "btStartJoin"
        Me.btStartJoin.Size = New System.Drawing.Size(75, 22)
        Me.btStartJoin.TabIndex = 67
        Me.btStartJoin.Text = "Start"
        Me.btStartJoin.UseVisualStyleBackColor = True
        '
        'btClearList3
        '
        Me.btClearList3.Location = New System.Drawing.Point(325, 60)
        Me.btClearList3.Name = "btClearList3"
        Me.btClearList3.Size = New System.Drawing.Size(64, 22)
        Me.btClearList3.TabIndex = 66
        Me.btClearList3.Text = "Clear"
        Me.btClearList3.UseVisualStyleBackColor = True
        '
        'btAddInputFile3
        '
        Me.btAddInputFile3.Location = New System.Drawing.Point(325, 32)
        Me.btAddInputFile3.Name = "btAddInputFile3"
        Me.btAddInputFile3.Size = New System.Drawing.Size(64, 22)
        Me.btAddInputFile3.TabIndex = 65
        Me.btAddInputFile3.Text = "Add"
        Me.btAddInputFile3.UseVisualStyleBackColor = True
        '
        'lbFiles2
        '
        Me.lbFiles2.FormattingEnabled = True
        Me.lbFiles2.Location = New System.Drawing.Point(18, 32)
        Me.lbFiles2.Name = "lbFiles2"
        Me.lbFiles2.Size = New System.Drawing.Size(301, 30)
        Me.lbFiles2.TabIndex = 64
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.Location = New System.Drawing.Point(15, 16)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(52, 13)
        Me.label32.TabIndex = 63
        Me.label32.Text = "Input files"
        '
        'TabPage74
        '
        Me.TabPage74.Controls.Add(Me.label168)
        Me.TabPage74.Controls.Add(Me.cbMuxStreamsShortest)
        Me.TabPage74.Controls.Add(Me.cbMuxStreamsType)
        Me.TabPage74.Controls.Add(Me.btMuxStreamsSelectFile)
        Me.TabPage74.Controls.Add(Me.edMuxStreamsSourceFile)
        Me.TabPage74.Controls.Add(Me.label167)
        Me.TabPage74.Controls.Add(Me.btMuxStreamsSelectOutput)
        Me.TabPage74.Controls.Add(Me.edMuxStreamsOutputFile)
        Me.TabPage74.Controls.Add(Me.label165)
        Me.TabPage74.Controls.Add(Me.btStopMux)
        Me.TabPage74.Controls.Add(Me.btStartMux)
        Me.TabPage74.Controls.Add(Me.btMuxStreamsClear)
        Me.TabPage74.Controls.Add(Me.btMuxStreamsAdd)
        Me.TabPage74.Controls.Add(Me.lbMuxStreamsList)
        Me.TabPage74.Controls.Add(Me.label166)
        Me.TabPage74.Location = New System.Drawing.Point(4, 22)
        Me.TabPage74.Name = "TabPage74"
        Me.TabPage74.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage74.Size = New System.Drawing.Size(417, 266)
        Me.TabPage74.TabIndex = 3
        Me.TabPage74.Text = "Mux streams (w/o reencoding)"
        Me.TabPage74.UseVisualStyleBackColor = True
        '
        'label168
        '
        Me.label168.AutoSize = True
        Me.label168.Location = New System.Drawing.Point(267, 12)
        Me.label168.Name = "label168"
        Me.label168.Size = New System.Drawing.Size(71, 13)
        Me.label168.TabIndex = 91
        Me.label168.Text = "Type or index"
        '
        'cbMuxStreamsShortest
        '
        Me.cbMuxStreamsShortest.AutoSize = True
        Me.cbMuxStreamsShortest.Location = New System.Drawing.Point(14, 134)
        Me.cbMuxStreamsShortest.Name = "cbMuxStreamsShortest"
        Me.cbMuxStreamsShortest.Size = New System.Drawing.Size(185, 17)
        Me.cbMuxStreamsShortest.TabIndex = 90
        Me.cbMuxStreamsShortest.Text = "Set file duration to shortest stream"
        Me.cbMuxStreamsShortest.UseVisualStyleBackColor = True
        '
        'cbMuxStreamsType
        '
        Me.cbMuxStreamsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMuxStreamsType.FormattingEnabled = True
        Me.cbMuxStreamsType.Items.AddRange(New Object() {"Video", "Audio", "0", "1", "2", "3", "4", "5", "6", "7"})
        Me.cbMuxStreamsType.Location = New System.Drawing.Point(270, 26)
        Me.cbMuxStreamsType.Name = "cbMuxStreamsType"
        Me.cbMuxStreamsType.Size = New System.Drawing.Size(76, 21)
        Me.cbMuxStreamsType.TabIndex = 89
        '
        'btMuxStreamsSelectFile
        '
        Me.btMuxStreamsSelectFile.Location = New System.Drawing.Point(241, 25)
        Me.btMuxStreamsSelectFile.Name = "btMuxStreamsSelectFile"
        Me.btMuxStreamsSelectFile.Size = New System.Drawing.Size(23, 22)
        Me.btMuxStreamsSelectFile.TabIndex = 88
        Me.btMuxStreamsSelectFile.Text = "..."
        Me.btMuxStreamsSelectFile.UseVisualStyleBackColor = True
        '
        'edMuxStreamsSourceFile
        '
        Me.edMuxStreamsSourceFile.Location = New System.Drawing.Point(14, 27)
        Me.edMuxStreamsSourceFile.Name = "edMuxStreamsSourceFile"
        Me.edMuxStreamsSourceFile.Size = New System.Drawing.Size(221, 20)
        Me.edMuxStreamsSourceFile.TabIndex = 87
        '
        'label167
        '
        Me.label167.AutoSize = True
        Me.label167.Location = New System.Drawing.Point(11, 12)
        Me.label167.Name = "label167"
        Me.label167.Size = New System.Drawing.Size(57, 13)
        Me.label167.TabIndex = 86
        Me.label167.Text = "Source file"
        '
        'btMuxStreamsSelectOutput
        '
        Me.btMuxStreamsSelectOutput.Location = New System.Drawing.Point(380, 173)
        Me.btMuxStreamsSelectOutput.Name = "btMuxStreamsSelectOutput"
        Me.btMuxStreamsSelectOutput.Size = New System.Drawing.Size(24, 22)
        Me.btMuxStreamsSelectOutput.TabIndex = 85
        Me.btMuxStreamsSelectOutput.Text = "..."
        Me.btMuxStreamsSelectOutput.UseVisualStyleBackColor = True
        '
        'edMuxStreamsOutputFile
        '
        Me.edMuxStreamsOutputFile.Location = New System.Drawing.Point(83, 175)
        Me.edMuxStreamsOutputFile.Name = "edMuxStreamsOutputFile"
        Me.edMuxStreamsOutputFile.Size = New System.Drawing.Size(291, 20)
        Me.edMuxStreamsOutputFile.TabIndex = 84
        Me.edMuxStreamsOutputFile.Text = "c:\vf\video_edit_output.avi"
        '
        'label165
        '
        Me.label165.AutoSize = True
        Me.label165.Location = New System.Drawing.Point(11, 178)
        Me.label165.Name = "label165"
        Me.label165.Size = New System.Drawing.Size(55, 13)
        Me.label165.TabIndex = 83
        Me.label165.Text = "Output file"
        '
        'btStopMux
        '
        Me.btStopMux.Location = New System.Drawing.Point(95, 219)
        Me.btStopMux.Name = "btStopMux"
        Me.btStopMux.Size = New System.Drawing.Size(75, 22)
        Me.btStopMux.TabIndex = 82
        Me.btStopMux.Text = "Stop"
        Me.btStopMux.UseVisualStyleBackColor = True
        '
        'btStartMux
        '
        Me.btStartMux.Location = New System.Drawing.Point(14, 219)
        Me.btStartMux.Name = "btStartMux"
        Me.btStartMux.Size = New System.Drawing.Size(75, 22)
        Me.btStartMux.TabIndex = 81
        Me.btStartMux.Text = "Start"
        Me.btStartMux.UseVisualStyleBackColor = True
        '
        'btMuxStreamsClear
        '
        Me.btMuxStreamsClear.Location = New System.Drawing.Point(340, 134)
        Me.btMuxStreamsClear.Name = "btMuxStreamsClear"
        Me.btMuxStreamsClear.Size = New System.Drawing.Size(64, 22)
        Me.btMuxStreamsClear.TabIndex = 80
        Me.btMuxStreamsClear.Text = "Clear"
        Me.btMuxStreamsClear.UseVisualStyleBackColor = True
        '
        'btMuxStreamsAdd
        '
        Me.btMuxStreamsAdd.Location = New System.Drawing.Point(352, 25)
        Me.btMuxStreamsAdd.Name = "btMuxStreamsAdd"
        Me.btMuxStreamsAdd.Size = New System.Drawing.Size(52, 22)
        Me.btMuxStreamsAdd.TabIndex = 79
        Me.btMuxStreamsAdd.Text = "Add"
        Me.btMuxStreamsAdd.UseVisualStyleBackColor = True
        '
        'lbMuxStreamsList
        '
        Me.lbMuxStreamsList.FormattingEnabled = True
        Me.lbMuxStreamsList.Location = New System.Drawing.Point(14, 73)
        Me.lbMuxStreamsList.Name = "lbMuxStreamsList"
        Me.lbMuxStreamsList.Size = New System.Drawing.Size(390, 30)
        Me.lbMuxStreamsList.TabIndex = 78
        '
        'label166
        '
        Me.label166.AutoSize = True
        Me.label166.Location = New System.Drawing.Point(11, 58)
        Me.label166.Name = "label166"
        Me.label166.Size = New System.Drawing.Size(70, 13)
        Me.label166.TabIndex = 77
        Me.label166.Text = "Input streams"
        '
        'cbLicensing
        '
        Me.cbLicensing.AutoSize = True
        Me.cbLicensing.Location = New System.Drawing.Point(149, 551)
        Me.cbLicensing.Name = "cbLicensing"
        Me.cbLicensing.Size = New System.Drawing.Size(91, 17)
        Me.cbLicensing.TabIndex = 93
        Me.cbLicensing.Text = "Licensing info"
        Me.cbLicensing.UseVisualStyleBackColor = True
        '
        'openFileDialogSubtitles
        '
        Me.openFileDialogSubtitles.FileName = "openFileDialog4"
        Me.openFileDialogSubtitles.Filter = "Subtitle files|*.srt;*.ssa;*.ass;*.sub|All files|*.*"
        '
        'TabPage143
        '
        Me.TabPage143.Location = New System.Drawing.Point(4, 22)
        Me.TabPage143.Name = "TabPage143"
        Me.TabPage143.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage143.Size = New System.Drawing.Size(284, 406)
        Me.TabPage143.TabIndex = 1
        Me.TabPage143.Text = "Special"
        Me.TabPage143.UseVisualStyleBackColor = True
        '
        'Label492
        '
        Me.Label492.AutoSize = True
        Me.Label492.Location = New System.Drawing.Point(12, 14)
        Me.Label492.Name = "Label492"
        Me.Label492.Size = New System.Drawing.Size(59, 13)
        Me.Label492.TabIndex = 8
        '
        'edTagComposers
        '
        Me.edTagComposers.Location = New System.Drawing.Point(15, 29)
        Me.edTagComposers.Name = "edTagComposers"
        Me.edTagComposers.Size = New System.Drawing.Size(242, 20)
        Me.edTagComposers.TabIndex = 9
        '
        'Label494
        '
        Me.Label494.AutoSize = True
        Me.Label494.Location = New System.Drawing.Point(12, 60)
        Me.Label494.Name = "Label494"
        Me.Label494.Size = New System.Drawing.Size(36, 13)
        Me.Label494.TabIndex = 10
        '
        'cbTagGenre
        '
        Me.cbTagGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTagGenre.FormattingEnabled = True
        Me.cbTagGenre.Location = New System.Drawing.Point(15, 76)
        Me.cbTagGenre.Name = "cbTagGenre"
        Me.cbTagGenre.Size = New System.Drawing.Size(242, 21)
        Me.cbTagGenre.TabIndex = 11
        '
        'Label497
        '
        Me.Label497.AutoSize = True
        Me.Label497.Location = New System.Drawing.Point(12, 112)
        Me.Label497.Name = "Label497"
        Me.Label497.Size = New System.Drawing.Size(34, 13)
        Me.Label497.TabIndex = 12
        '
        'edTagLyrics
        '
        Me.edTagLyrics.Location = New System.Drawing.Point(15, 127)
        Me.edTagLyrics.Name = "edTagLyrics"
        Me.edTagLyrics.Size = New System.Drawing.Size(242, 20)
        Me.edTagLyrics.TabIndex = 13
        '
        'Label498
        '
        Me.Label498.AutoSize = True
        Me.Label498.Location = New System.Drawing.Point(43, 334)
        Me.Label498.Name = "Label498"
        Me.Label498.Size = New System.Drawing.Size(194, 13)
        Me.Label498.TabIndex = 14
        '
        'Label499
        '
        Me.Label499.AutoSize = True
        Me.Label499.Location = New System.Drawing.Point(12, 162)
        Me.Label499.Name = "Label499"
        Me.Label499.Size = New System.Drawing.Size(35, 13)
        Me.Label499.TabIndex = 15
        '
        'imgTagCover
        '
        Me.imgTagCover.BackColor = System.Drawing.Color.DimGray
        Me.imgTagCover.Location = New System.Drawing.Point(15, 178)
        Me.imgTagCover.Name = "imgTagCover"
        Me.imgTagCover.Size = New System.Drawing.Size(104, 104)
        Me.imgTagCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTagCover.TabIndex = 16
        Me.imgTagCover.TabStop = False
        '
        'TabPage142
        '
        Me.TabPage142.Location = New System.Drawing.Point(4, 22)
        Me.TabPage142.Name = "TabPage142"
        Me.TabPage142.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage142.Size = New System.Drawing.Size(284, 406)
        Me.TabPage142.TabIndex = 0
        Me.TabPage142.Text = "Common"
        Me.TabPage142.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 0
        '
        'edTagTitle
        '
        Me.edTagTitle.Location = New System.Drawing.Point(16, 29)
        Me.edTagTitle.Name = "edTagTitle"
        Me.edTagTitle.Size = New System.Drawing.Size(242, 20)
        Me.edTagTitle.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 240)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 13)
        Me.Label22.TabIndex = 2
        '
        'edTagCopyright
        '
        Me.edTagCopyright.Location = New System.Drawing.Point(16, 255)
        Me.edTagCopyright.Name = "edTagCopyright"
        Me.edTagCopyright.Size = New System.Drawing.Size(242, 20)
        Me.edTagCopyright.TabIndex = 3
        '
        'Label490
        '
        Me.Label490.AutoSize = True
        Me.Label490.Location = New System.Drawing.Point(13, 57)
        Me.Label490.Name = "Label490"
        Me.Label490.Size = New System.Drawing.Size(35, 13)
        Me.Label490.TabIndex = 4
        '
        'edTagArtists
        '
        Me.edTagArtists.Location = New System.Drawing.Point(16, 72)
        Me.edTagArtists.Name = "edTagArtists"
        Me.edTagArtists.Size = New System.Drawing.Size(242, 20)
        Me.edTagArtists.TabIndex = 5
        '
        'Label491
        '
        Me.Label491.AutoSize = True
        Me.Label491.Location = New System.Drawing.Point(13, 101)
        Me.Label491.Name = "Label491"
        Me.Label491.Size = New System.Drawing.Size(36, 13)
        Me.Label491.TabIndex = 6
        '
        'edTagAlbum
        '
        Me.edTagAlbum.Location = New System.Drawing.Point(16, 116)
        Me.edTagAlbum.Name = "edTagAlbum"
        Me.edTagAlbum.Size = New System.Drawing.Size(242, 20)
        Me.edTagAlbum.TabIndex = 7
        '
        'Label493
        '
        Me.Label493.AutoSize = True
        Me.Label493.Location = New System.Drawing.Point(13, 145)
        Me.Label493.Name = "Label493"
        Me.Label493.Size = New System.Drawing.Size(51, 13)
        Me.Label493.TabIndex = 8
        '
        'edTagComment
        '
        Me.edTagComment.Location = New System.Drawing.Point(16, 160)
        Me.edTagComment.Name = "edTagComment"
        Me.edTagComment.Size = New System.Drawing.Size(242, 20)
        Me.edTagComment.TabIndex = 9
        '
        'Label495
        '
        Me.Label495.AutoSize = True
        Me.Label495.Location = New System.Drawing.Point(13, 286)
        Me.Label495.Name = "Label495"
        Me.Label495.Size = New System.Drawing.Size(29, 13)
        Me.Label495.TabIndex = 10
        '
        'edTagYear
        '
        Me.edTagYear.Location = New System.Drawing.Point(16, 301)
        Me.edTagYear.Name = "edTagYear"
        Me.edTagYear.Size = New System.Drawing.Size(63, 20)
        Me.edTagYear.TabIndex = 11
        '
        'Label496
        '
        Me.Label496.AutoSize = True
        Me.Label496.Location = New System.Drawing.Point(13, 192)
        Me.Label496.Name = "Label496"
        Me.Label496.Size = New System.Drawing.Size(49, 13)
        Me.Label496.TabIndex = 12
        '
        'edTagTrackID
        '
        Me.edTagTrackID.Location = New System.Drawing.Point(16, 207)
        Me.edTagTrackID.Name = "edTagTrackID"
        Me.edTagTrackID.Size = New System.Drawing.Size(63, 20)
        Me.edTagTrackID.TabIndex = 13
        '
        'cbTelemetry
        '
        Me.cbTelemetry.AutoSize = True
        Me.cbTelemetry.Checked = True
        Me.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbTelemetry.Location = New System.Drawing.Point(249, 524)
        Me.cbTelemetry.Name = "cbTelemetry"
        Me.cbTelemetry.Size = New System.Drawing.Size(72, 17)
        Me.cbTelemetry.TabIndex = 94
        Me.cbTelemetry.Text = "Telemetry"
        Me.cbTelemetry.UseVisualStyleBackColor = True
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(335, 310)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(417, 284)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 95
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(768, 634)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.tbSeeking)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.mmLog)
        Me.Controls.Add(Me.label120)
        Me.Controls.Add(Me.cbDebugMode)
        Me.Controls.Add(Me.rbPreview)
        Me.Controls.Add(Me.rbConvert)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.tabControl3)
        Me.Controls.Add(Me.cbTelemetry)
        Me.Controls.Add(Me.cbLicensing)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "VisioForge Video Edit SDK .Net - Main Demo"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.tabPage30.ResumeLayout(False)
        Me.tabPage30.PerformLayout()
        Me.tabPage31.ResumeLayout(False)
        Me.tabControl17.ResumeLayout(False)
        Me.tabPage68.ResumeLayout(False)
        Me.tabPage68.PerformLayout()
        Me.tabControl7.ResumeLayout(False)
        Me.tabPage29.ResumeLayout(False)
        Me.tabPage42.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.groupBox37.ResumeLayout(False)
        Me.TabPage16.ResumeLayout(False)
        Me.TabPage16.PerformLayout()
        Me.groupBox40.ResumeLayout(False)
        Me.groupBox40.PerformLayout()
        Me.groupBox39.ResumeLayout(False)
        Me.groupBox39.PerformLayout()
        Me.groupBox38.ResumeLayout(False)
        Me.groupBox38.PerformLayout()
        Me.TabPage33.ResumeLayout(False)
        Me.TabPage33.PerformLayout()
        Me.groupBox45.ResumeLayout(False)
        Me.groupBox45.PerformLayout()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDarkness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSaturation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage69.ResumeLayout(False)
        Me.tabPage69.PerformLayout()
        Me.tabPage59.ResumeLayout(False)
        Me.tabPage59.PerformLayout()
        Me.TabPage82.ResumeLayout(False)
        Me.TabPage82.PerformLayout()
        CType(Me.tbGPUBlur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGPUContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGPUDarkness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGPULightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGPUSaturation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage20.ResumeLayout(False)
        Me.tabControl15.ResumeLayout(False)
        Me.TabPage26.ResumeLayout(False)
        Me.TabPage26.PerformLayout()
        Me.TabPage27.ResumeLayout(False)
        Me.TabPage27.PerformLayout()
        Me.TabPage21.ResumeLayout(False)
        Me.TabPage21.PerformLayout()
        CType(Me.tbChromaKeySmoothing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbChromaKeyThresholdSensitivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage70.ResumeLayout(False)
        Me.tabPage70.PerformLayout()
        Me.TabPage81.ResumeLayout(False)
        Me.TabPage81.PerformLayout()
        Me.tabPage9.ResumeLayout(False)
        Me.tabPage9.PerformLayout()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        Me.tabControl18.ResumeLayout(False)
        Me.tabPage71.ResumeLayout(False)
        Me.tabPage71.PerformLayout()
        CType(Me.tbAudAmplifyAmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage72.ResumeLayout(False)
        Me.tabPage72.PerformLayout()
        CType(Me.tbAudEq9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudEq0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage73.ResumeLayout(False)
        Me.tabPage73.PerformLayout()
        CType(Me.tbAudRelease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudAttack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudDynAmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage75.ResumeLayout(False)
        Me.tabPage75.PerformLayout()
        CType(Me.tbAud3DSound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage76.ResumeLayout(False)
        Me.tabPage76.PerformLayout()
        CType(Me.tbAudTrueBass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage57.ResumeLayout(False)
        Me.TabPage57.PerformLayout()
        CType(Me.tbAudioTimeshift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.tbAudioOutputGainLFE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioOutputGainSR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioOutputGainSL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioOutputGainR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioOutputGainC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioOutputGainL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.tbAudioInputGainLFE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioInputGainSR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioInputGainSL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioInputGainR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioInputGainC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioInputGainL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage80.ResumeLayout(False)
        Me.TabPage80.PerformLayout()
        Me.groupBox41.ResumeLayout(False)
        Me.groupBox41.PerformLayout()
        CType(Me.tbAudioChannelMapperVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage28.ResumeLayout(False)
        Me.TabPage28.PerformLayout()
        Me.tabControl9.ResumeLayout(False)
        Me.tabPage44.ResumeLayout(False)
        Me.tabPage44.PerformLayout()
        Me.tabPage45.ResumeLayout(False)
        Me.groupBox25.ResumeLayout(False)
        Me.groupBox25.PerformLayout()
        CType(Me.tbMotDetHLThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox27.ResumeLayout(False)
        Me.groupBox27.PerformLayout()
        Me.groupBox26.ResumeLayout(False)
        Me.groupBox26.PerformLayout()
        CType(Me.tbMotDetDropFramesThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox24.ResumeLayout(False)
        Me.groupBox24.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        Me.groupBox13.ResumeLayout(False)
        Me.groupBox13.PerformLayout()
        Me.TabPage23.ResumeLayout(False)
        Me.TabPage23.PerformLayout()
        Me.TabPage24.ResumeLayout(False)
        Me.TabPage24.PerformLayout()
        Me.tabControl5.ResumeLayout(False)
        Me.TabPage25.ResumeLayout(False)
        Me.TabPage25.PerformLayout()
        Me.TabPage47.ResumeLayout(False)
        Me.TabPage47.PerformLayout()
        Me.TabPage48.ResumeLayout(False)
        Me.TabPage48.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage67.ResumeLayout(False)
        Me.TabPage67.PerformLayout()
        Me.TabPage49.ResumeLayout(False)
        Me.TabPage49.PerformLayout()
        Me.TabPage56.ResumeLayout(False)
        Me.TabPage56.PerformLayout()
        Me.TabPage32.ResumeLayout(False)
        Me.TabPage32.PerformLayout()
        Me.TabPage34.ResumeLayout(False)
        Me.TabPage34.PerformLayout()
        Me.TabPage43.ResumeLayout(False)
        Me.groupBox48.ResumeLayout(False)
        Me.groupBox48.PerformLayout()
        Me.groupBox47.ResumeLayout(False)
        Me.groupBox47.PerformLayout()
        Me.groupBox43.ResumeLayout(False)
        Me.groupBox43.PerformLayout()
        Me.TabPage78.ResumeLayout(False)
        Me.TabPage78.PerformLayout()
        Me.TabPage22.ResumeLayout(False)
        Me.TabPage22.PerformLayout()
        CType(Me.tbVUMeterBoost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbVUMeterAmplification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSeeking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl3.ResumeLayout(False)
        Me.tabPage52.ResumeLayout(False)
        Me.tabPage52.PerformLayout()
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage53.ResumeLayout(False)
        Me.tabPage53.PerformLayout()
        Me.tabPage54.ResumeLayout(False)
        Me.tabPage54.PerformLayout()
        Me.TabPage74.ResumeLayout(False)
        Me.TabPage74.PerformLayout()
        CType(Me.imgTagCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Private WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents OpenDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents SaveDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents openFileDialog2 As System.Windows.Forms.OpenFileDialog
    Private WithEvents colorDialog1 As System.Windows.Forms.ColorDialog
    Private WithEvents mmLog As System.Windows.Forms.TextBox
    Private WithEvents label120 As System.Windows.Forms.Label
    Private WithEvents cbDebugMode As System.Windows.Forms.CheckBox
    Private WithEvents rbPreview As System.Windows.Forms.RadioButton
    Private WithEvents rbConvert As System.Windows.Forms.RadioButton
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents tabControl2 As System.Windows.Forms.TabControl
    Private WithEvents tabPage30 As System.Windows.Forms.TabPage
    Private WithEvents cbFrameRate As System.Windows.Forms.ComboBox
    Private WithEvents edHeight As System.Windows.Forms.TextBox
    Private WithEvents edWidth As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cbResize As System.Windows.Forms.CheckBox
    Private WithEvents tabPage31 As System.Windows.Forms.TabPage
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
    Private WithEvents tabPage59 As System.Windows.Forms.TabPage
    Private WithEvents rbDenoiseCAST As System.Windows.Forms.RadioButton
    Private WithEvents rbDenoiseMosquito As System.Windows.Forms.RadioButton
    Private WithEvents cbDenoise As System.Windows.Forms.CheckBox
    Private WithEvents tabPage70 As System.Windows.Forms.TabPage
    Private WithEvents btFilterDeleteAll As System.Windows.Forms.Button
    Private WithEvents btFilterSettings2 As System.Windows.Forms.Button
    Private WithEvents lbFilters As System.Windows.Forms.ListBox
    Private WithEvents label106 As System.Windows.Forms.Label
    Private WithEvents btFilterSettings As System.Windows.Forms.Button
    Private WithEvents btFilterAdd As System.Windows.Forms.Button
    Private WithEvents cbFilters As System.Windows.Forms.ComboBox
    Private WithEvents label105 As System.Windows.Forms.Label
    Private WithEvents tabPage9 As System.Windows.Forms.TabPage
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents label47 As System.Windows.Forms.Label
    Private WithEvents edTransStopTime As System.Windows.Forms.TextBox
    Private WithEvents label48 As System.Windows.Forms.Label
    Private WithEvents label46 As System.Windows.Forms.Label
    Private WithEvents edTransStartTime As System.Windows.Forms.TextBox
    Private WithEvents label45 As System.Windows.Forms.Label
    Private WithEvents btAddTransition As System.Windows.Forms.Button
    Private WithEvents cbTransitionName As System.Windows.Forms.ComboBox
    Private WithEvents label44 As System.Windows.Forms.Label
    Private WithEvents lbTransitions As System.Windows.Forms.ListBox
    Private WithEvents label43 As System.Windows.Forms.Label
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
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
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents tbSeeking As System.Windows.Forms.TrackBar
    Private WithEvents openFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage20 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage21 As System.Windows.Forms.TabPage
    Private WithEvents tabControl15 As System.Windows.Forms.TabControl
    Private WithEvents TabPage26 As System.Windows.Forms.TabPage
    Private WithEvents label64 As System.Windows.Forms.Label
    Private WithEvents label65 As System.Windows.Forms.Label
    Private WithEvents pbAFMotionLevel As System.Windows.Forms.ProgressBar
    Private WithEvents cbAFMotionHighlight As System.Windows.Forms.CheckBox
    Private WithEvents cbAFMotionDetection As System.Windows.Forms.CheckBox
    Private WithEvents TabPage27 As System.Windows.Forms.TabPage
    Private WithEvents label171 As System.Windows.Forms.Label
    Private WithEvents label66 As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents TabPage28 As System.Windows.Forms.TabPage
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
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
    Private WithEvents label92 As System.Windows.Forms.Label
    Private WithEvents cbRotate As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Private WithEvents groupBox37 As System.Windows.Forms.GroupBox
    Private WithEvents btEffZoomRight As System.Windows.Forms.Button
    Private WithEvents btEffZoomLeft As System.Windows.Forms.Button
    Private WithEvents btEffZoomOut As System.Windows.Forms.Button
    Private WithEvents btEffZoomIn As System.Windows.Forms.Button
    Private WithEvents btEffZoomDown As System.Windows.Forms.Button
    Private WithEvents btEffZoomUp As System.Windows.Forms.Button
    Private WithEvents cbZoom As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
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
    Friend WithEvents TabPage23 As System.Windows.Forms.TabPage
    Private WithEvents edBarcodeMetadata As System.Windows.Forms.TextBox
    Private WithEvents label91 As System.Windows.Forms.Label
    Private WithEvents cbBarcodeType As System.Windows.Forms.ComboBox
    Private WithEvents label90 As System.Windows.Forms.Label
    Private WithEvents btBarcodeReset As System.Windows.Forms.Button
    Private WithEvents edBarcode As System.Windows.Forms.TextBox
    Private WithEvents label89 As System.Windows.Forms.Label
    Private WithEvents cbBarcodeDetectionEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage24 As System.Windows.Forms.TabPage
    Private WithEvents tabControl5 As System.Windows.Forms.TabControl
    Private WithEvents TabPage25 As System.Windows.Forms.TabPage
    Private WithEvents edWMVNetworkPort As System.Windows.Forms.TextBox
    Private WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents btRefreshClients As System.Windows.Forms.Button
    Private WithEvents lbNetworkClients As System.Windows.Forms.ListBox
    Private WithEvents rbNetworkStreamingUseExternalProfile As System.Windows.Forms.RadioButton
    Private WithEvents rbNetworkStreamingUseMainWMVSettings As System.Windows.Forms.RadioButton
    Private WithEvents label81 As System.Windows.Forms.Label
    Private WithEvents label80 As System.Windows.Forms.Label
    Private WithEvents edMaximumClients As System.Windows.Forms.TextBox
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents btSelectWMVProfileNetwork As System.Windows.Forms.Button
    Private WithEvents edNetworkStreamingWMVProfile As System.Windows.Forms.TextBox
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents TabPage56 As System.Windows.Forms.TabPage
    Private WithEvents cbNetworkStreamingAudioEnabled As System.Windows.Forms.CheckBox
    Private WithEvents cbNetworkStreaming As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage32 As System.Windows.Forms.TabPage
    Private WithEvents label326 As System.Windows.Forms.Label
    Private WithEvents label325 As System.Windows.Forms.Label
    Private WithEvents cbVirtualCamera As System.Windows.Forms.CheckBox
    Private WithEvents label328 As System.Windows.Forms.Label
    Private WithEvents label327 As System.Windows.Forms.Label
    Friend WithEvents TabPage33 As System.Windows.Forms.TabPage
    Private WithEvents rbVideoFadeOut As System.Windows.Forms.RadioButton
    Private WithEvents rbVideoFadeIn As System.Windows.Forms.RadioButton
    Private WithEvents groupBox45 As System.Windows.Forms.GroupBox
    Private WithEvents edVideoFadeInOutStopTime As System.Windows.Forms.TextBox
    Private WithEvents label329 As System.Windows.Forms.Label
    Private WithEvents edVideoFadeInOutStartTime As System.Windows.Forms.TextBox
    Private WithEvents label330 As System.Windows.Forms.Label
    Private WithEvents cbVideoFadeInOut As System.Windows.Forms.CheckBox
    Private WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage34 As System.Windows.Forms.TabPage
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
    Friend WithEvents TabPage43 As System.Windows.Forms.TabPage
    Private WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents edNetworkURL As System.Windows.Forms.TextBox
    Friend WithEvents TabPage47 As System.Windows.Forms.TabPage
    Private WithEvents edNetworkRTSPURL As System.Windows.Forms.TextBox
    Private WithEvents label367 As System.Windows.Forms.Label
    Private WithEvents label366 As System.Windows.Forms.Label
    Private WithEvents cbNetworkStreamingMode As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage48 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage49 As System.Windows.Forms.TabPage
    Private WithEvents edNetworkSSURL As System.Windows.Forms.TextBox
    Private WithEvents label370 As System.Windows.Forms.Label
    Private WithEvents label371 As System.Windows.Forms.Label
    Private WithEvents rbNetworkSSSoftware As System.Windows.Forms.RadioButton
    Private WithEvents linkLabel5 As System.Windows.Forms.LinkLabel
    Private WithEvents tabControl3 As System.Windows.Forms.TabControl
    Private WithEvents tabPage52 As System.Windows.Forms.TabPage
    Private WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents label72 As System.Windows.Forms.Label
    Private WithEvents edInsertTime As System.Windows.Forms.TextBox
    Private WithEvents label73 As System.Windows.Forms.Label
    Private WithEvents cbInsertAfterPreviousFile As System.Windows.Forms.CheckBox
    Private WithEvents label50 As System.Windows.Forms.Label
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents lbSpeed As System.Windows.Forms.Label
    Private WithEvents label42 As System.Windows.Forms.Label
    Private WithEvents label37 As System.Windows.Forms.Label
    Private WithEvents edStopTime As System.Windows.Forms.TextBox
    Private WithEvents label38 As System.Windows.Forms.Label
    Private WithEvents label36 As System.Windows.Forms.Label
    Private WithEvents edStartTime As System.Windows.Forms.TextBox
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents cbAddFullFile As System.Windows.Forms.CheckBox
    Private WithEvents tbSpeed As System.Windows.Forms.TrackBar
    Private WithEvents btClearList As System.Windows.Forms.Button
    Private WithEvents btAddInputFile As System.Windows.Forms.Button
    Private WithEvents lbFiles As System.Windows.Forms.ListBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents tabPage53 As System.Windows.Forms.TabPage
    Private WithEvents tabPage54 As System.Windows.Forms.TabPage
    Private WithEvents label393 As System.Windows.Forms.Label
    Private WithEvents cbDirect2DRotate As System.Windows.Forms.ComboBox
    Private WithEvents pnVideoRendererBGColor As System.Windows.Forms.Panel
    Private WithEvents label394 As System.Windows.Forms.Label
    Private WithEvents btFullScreen As System.Windows.Forms.Button
    Private WithEvents cbScreenFlipVertical As System.Windows.Forms.CheckBox
    Private WithEvents cbScreenFlipHorizontal As System.Windows.Forms.CheckBox
    Private WithEvents cbStretch As System.Windows.Forms.CheckBox
    Private WithEvents groupBox13 As System.Windows.Forms.GroupBox
    Private WithEvents rbDirect2D As System.Windows.Forms.RadioButton
    Private WithEvents rbNone As System.Windows.Forms.RadioButton
    Private WithEvents rbEVR As System.Windows.Forms.RadioButton
    Private WithEvents rbVMR9 As System.Windows.Forms.RadioButton
    Private WithEvents rbVR As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage57 As System.Windows.Forms.TabPage
    Private WithEvents lbAudioTimeshift As System.Windows.Forms.Label
    Private WithEvents tbAudioTimeshift As System.Windows.Forms.TrackBar
    Private WithEvents label115 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lbAudioOutputGainLFE As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainLFE As System.Windows.Forms.TrackBar
    Private WithEvents label116 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainSR As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainSR As System.Windows.Forms.TrackBar
    Private WithEvents label117 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainSL As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainSL As System.Windows.Forms.TrackBar
    Private WithEvents label118 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainR As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainR As System.Windows.Forms.TrackBar
    Private WithEvents label119 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainC As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainC As System.Windows.Forms.TrackBar
    Private WithEvents label121 As System.Windows.Forms.Label
    Private WithEvents lbAudioOutputGainL As System.Windows.Forms.Label
    Private WithEvents tbAudioOutputGainL As System.Windows.Forms.TrackBar
    Private WithEvents label122 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lbAudioInputGainLFE As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainLFE As System.Windows.Forms.TrackBar
    Private WithEvents label123 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainSR As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainSR As System.Windows.Forms.TrackBar
    Private WithEvents label124 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainSL As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainSL As System.Windows.Forms.TrackBar
    Private WithEvents label125 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainR As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainR As System.Windows.Forms.TrackBar
    Private WithEvents label126 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainC As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainC As System.Windows.Forms.TrackBar
    Private WithEvents label127 As System.Windows.Forms.Label
    Private WithEvents lbAudioInputGainL As System.Windows.Forms.Label
    Private WithEvents tbAudioInputGainL As System.Windows.Forms.TrackBar
    Private WithEvents label128 As System.Windows.Forms.Label
    Private WithEvents cbAudioAutoGain As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioNormalize As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioEnhancementEnabled As System.Windows.Forms.CheckBox
    Private WithEvents rbNetworkRTMPFFMPEGCustom As System.Windows.Forms.RadioButton
    Private WithEvents rbNetworkRTMPFFMPEG As System.Windows.Forms.RadioButton
    Private WithEvents edNetworkRTMPURL As System.Windows.Forms.TextBox
    Private WithEvents label368 As System.Windows.Forms.Label
    Private WithEvents label369 As System.Windows.Forms.Label
    Friend WithEvents TabPage67 As System.Windows.Forms.TabPage
    Private WithEvents label484 As System.Windows.Forms.Label
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
    Private WithEvents btSelectOutputCut As Button
    Private WithEvents edOutputFileCut As TextBox
    Private WithEvents label131 As Label
    Private WithEvents btStopCut As Button
    Private WithEvents btStartCut As Button
    Private WithEvents label31 As Label
    Private WithEvents btAddInputFile2 As Button
    Private WithEvents edSourceFileToCut As TextBox
    Private WithEvents label30 As Label
    Private WithEvents label26 As Label
    Private WithEvents edStopTimeCut As TextBox
    Private WithEvents label27 As Label
    Private WithEvents label28 As Label
    Private WithEvents edStartTimeCut As TextBox
    Private WithEvents label29 As Label
    Private WithEvents btSelectOutputJoin As Button
    Private WithEvents edOutputFileJoin As TextBox
    Private WithEvents label132 As Label
    Private WithEvents btStopJoin As Button
    Private WithEvents btStartJoin As Button
    Private WithEvents btClearList3 As Button
    Private WithEvents btAddInputFile3 As Button
    Private WithEvents lbFiles2 As ListBox
    Private WithEvents label32 As Label
    Private WithEvents cbLicensing As CheckBox
    Friend WithEvents Label24 As Label
    Private WithEvents edCropRight As TextBox
    Private WithEvents label176 As Label
    Private WithEvents edCropBottom As TextBox
    Private WithEvents label252 As Label
    Private WithEvents edCropLeft As TextBox
    Private WithEvents label270 As Label
    Private WithEvents edCropTop As TextBox
    Private WithEvents label272 As Label
    Private WithEvents cbCrop As CheckBox
    Private WithEvents label134 As Label
    Friend WithEvents TabPage74 As TabPage
    Private WithEvents cbMuxStreamsShortest As CheckBox
    Private WithEvents cbMuxStreamsType As ComboBox
    Private WithEvents btMuxStreamsSelectFile As Button
    Private WithEvents edMuxStreamsSourceFile As TextBox
    Private WithEvents label167 As Label
    Private WithEvents btMuxStreamsSelectOutput As Button
    Private WithEvents edMuxStreamsOutputFile As TextBox
    Private WithEvents label165 As Label
    Private WithEvents btStopMux As Button
    Private WithEvents btStartMux As Button
    Private WithEvents btMuxStreamsClear As Button
    Private WithEvents btMuxStreamsAdd As Button
    Private WithEvents lbMuxStreamsList As ListBox
    Private WithEvents label166 As Label
    Private WithEvents label168 As Label
    Private WithEvents rbNetworkSSFFMPEGCustom As RadioButton
    Private WithEvents rbNetworkSSFFMPEGDefault As RadioButton
    Friend WithEvents TabPage80 As TabPage
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
    Private WithEvents Label114 As Label
    Private WithEvents linkLabel11 As LinkLabel
    Friend WithEvents TabPage81 As TabPage
    Private WithEvents label177 As Label
    Private WithEvents Label3 As Label
    Private WithEvents btSubtitlesSelectFile As Button
    Private WithEvents edSubtitlesFilename As TextBox
    Private WithEvents Label130 As Label
    Private WithEvents cbSubtitlesEnabled As CheckBox
    Private WithEvents openFileDialogSubtitles As OpenFileDialog
    Friend WithEvents TabPage82 As TabPage
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
    Friend WithEvents TabPage78 As TabPage
    Friend WithEvents TabControl32 As TabControl
    Friend WithEvents cbTagEnabled As CheckBox
    Friend WithEvents TabPage22 As TabPage
    Friend WithEvents TabPage143 As TabPage
    Friend WithEvents Label492 As Label
    Friend WithEvents edTagComposers As TextBox
    Friend WithEvents Label494 As Label
    Friend WithEvents cbTagGenre As ComboBox
    Friend WithEvents Label497 As Label
    Friend WithEvents edTagLyrics As TextBox
    Friend WithEvents Label498 As Label
    Friend WithEvents Label499 As Label
    Friend WithEvents imgTagCover As PictureBox
    Friend WithEvents TabPage142 As TabPage
    Friend WithEvents Label23 As Label
    Friend WithEvents edTagTitle As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents edTagCopyright As TextBox
    Friend WithEvents Label490 As Label
    Friend WithEvents edTagArtists As TextBox
    Friend WithEvents Label491 As Label
    Friend WithEvents edTagAlbum As TextBox
    Friend WithEvents Label493 As Label
    Friend WithEvents edTagComment As TextBox
    Friend WithEvents Label495 As Label
    Friend WithEvents edTagYear As TextBox
    Friend WithEvents Label496 As Label
    Friend WithEvents edTagTrackID As TextBox
    Private WithEvents peakMeterCtrl1 As VisioForge.Core.UI.WinForms.PeakMeterCtrl
    Private WithEvents cbVUMeter As CheckBox
    Private WithEvents tbVUMeterBoost As TrackBar
    Private WithEvents label382 As Label
    Private WithEvents label381 As Label
    Private WithEvents tbVUMeterAmplification As TrackBar
    Private WithEvents cbVUMeterPro As CheckBox
    Private WithEvents waveformPainter2 As VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter
    Private WithEvents waveformPainter1 As VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter
    Private WithEvents volumeMeter2 As VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter
    Private WithEvents volumeMeter1 As VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter
    Friend WithEvents TabPage4 As TabPage
    Private WithEvents lbInfo As Label
    Private WithEvents btConfigure As Button
    Private WithEvents btSelectOutput As Button
    Private WithEvents edOutput As TextBox
    Private WithEvents label15 As Label
    Private WithEvents cbOutputVideoFormat As ComboBox
    Private WithEvents label9 As Label
    Private WithEvents cbFlipY As CheckBox
    Private WithEvents cbFlipX As CheckBox
    Private WithEvents btTextLogoRemove As Button
    Private WithEvents btTextLogoEdit As Button
    Private WithEvents lbTextLogos As ListBox
    Private WithEvents btTextLogoAdd As Button
    Private WithEvents btImageLogoRemove As Button
    Private WithEvents btImageLogoEdit As Button
    Private WithEvents lbImageLogos As ListBox
    Private WithEvents btImageLogoAdd As Button
    Private WithEvents cbTelemetry As CheckBox
    Private WithEvents label1 As Label
    Friend WithEvents cbVideoEffectsGPUEnabled As CheckBox
    Private WithEvents label5 As Label
    Private WithEvents tbGPUBlur As TrackBar
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
    Friend WithEvents TabPage5 As TabPage
    Private WithEvents LinkLabel6 As LinkLabel
    Private WithEvents label11 As Label
    Private WithEvents label12 As Label
    Private WithEvents edNDIURL As TextBox
    Private WithEvents edNDIName As TextBox
    Private WithEvents label13 As Label
    Private WithEvents label63 As Label
    Private WithEvents label62 As Label
    Private WithEvents label314 As Label
    Private WithEvents label313 As Label
    Private WithEvents edNetworkUDPURL As TextBox
    Private WithEvents Label4 As Label
    Private WithEvents llXiphX64 As LinkLabel
    Private WithEvents llXiphX86 As LinkLabel
    Private WithEvents label68 As Label
    Private WithEvents label67 As Label
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
