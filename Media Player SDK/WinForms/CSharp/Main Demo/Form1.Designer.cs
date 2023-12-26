namespace Media_Player_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "memoryFileStream")]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            MediaPlayer1?.Dispose();
            MediaPlayer1 = null;

            memoryFileStream?.Dispose();
            memoryFileStream = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage20 = new System.Windows.Forms.TabPage();
            groupBox6 = new System.Windows.Forms.GroupBox();
            rbGPUDirect3D = new System.Windows.Forms.RadioButton();
            rbGPUDXVANative = new System.Windows.Forms.RadioButton();
            rbGPUDXVACopyBack = new System.Windows.Forms.RadioButton();
            rbGPUIntel = new System.Windows.Forms.RadioButton();
            rbGPUNVidia = new System.Windows.Forms.RadioButton();
            tabPage1 = new System.Windows.Forms.TabPage();
            cbUseLibMediaInfo = new System.Windows.Forms.CheckBox();
            btReadInfo = new System.Windows.Forms.Button();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabPage6 = new System.Windows.Forms.TabPage();
            mmInfo = new System.Windows.Forms.TextBox();
            tabPage49 = new System.Windows.Forms.TabPage();
            imgTags = new System.Windows.Forms.PictureBox();
            edTags = new System.Windows.Forms.TextBox();
            btReadTags = new System.Windows.Forms.Button();
            tabPage2 = new System.Windows.Forms.TabPage();
            label10 = new System.Windows.Forms.Label();
            tbBalance4 = new System.Windows.Forms.TrackBar();
            label11 = new System.Windows.Forms.Label();
            tbVolume4 = new System.Windows.Forms.TrackBar();
            cbAudioStream4 = new System.Windows.Forms.CheckBox();
            label12 = new System.Windows.Forms.Label();
            tbBalance3 = new System.Windows.Forms.TrackBar();
            label13 = new System.Windows.Forms.Label();
            tbVolume3 = new System.Windows.Forms.TrackBar();
            cbAudioStream3 = new System.Windows.Forms.CheckBox();
            label8 = new System.Windows.Forms.Label();
            tbBalance2 = new System.Windows.Forms.TrackBar();
            label9 = new System.Windows.Forms.Label();
            tbVolume2 = new System.Windows.Forms.TrackBar();
            cbAudioStream2 = new System.Windows.Forms.CheckBox();
            label7 = new System.Windows.Forms.Label();
            tbBalance1 = new System.Windows.Forms.TrackBar();
            label6 = new System.Windows.Forms.Label();
            tbVolume1 = new System.Windows.Forms.TrackBar();
            cbAudioStream1 = new System.Windows.Forms.CheckBox();
            cbPlayAudio = new System.Windows.Forms.CheckBox();
            cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            tabControl4 = new System.Windows.Forms.TabControl();
            tabPage16 = new System.Windows.Forms.TabPage();
            label393 = new System.Windows.Forms.Label();
            cbDirect2DRotate = new System.Windows.Forms.ComboBox();
            pnVideoRendererBGColor = new System.Windows.Forms.Panel();
            label394 = new System.Windows.Forms.Label();
            btFullScreen = new System.Windows.Forms.Button();
            groupBox28 = new System.Windows.Forms.GroupBox();
            btZoomReset = new System.Windows.Forms.Button();
            btZoomShiftRight = new System.Windows.Forms.Button();
            btZoomShiftLeft = new System.Windows.Forms.Button();
            btZoomOut = new System.Windows.Forms.Button();
            btZoomIn = new System.Windows.Forms.Button();
            btZoomShiftDown = new System.Windows.Forms.Button();
            btZoomShiftUp = new System.Windows.Forms.Button();
            cbScreenFlipVertical = new System.Windows.Forms.CheckBox();
            cbScreenFlipHorizontal = new System.Windows.Forms.CheckBox();
            cbStretch = new System.Windows.Forms.CheckBox();
            groupBox13 = new System.Windows.Forms.GroupBox();
            rbMadVR = new System.Windows.Forms.RadioButton();
            rbDirect2D = new System.Windows.Forms.RadioButton();
            rbNone = new System.Windows.Forms.RadioButton();
            rbEVR = new System.Windows.Forms.RadioButton();
            rbVMR9 = new System.Windows.Forms.RadioButton();
            label15 = new System.Windows.Forms.Label();
            edAspectRatioY = new System.Windows.Forms.TextBox();
            edAspectRatioX = new System.Windows.Forms.TextBox();
            cbAspectRatioUseCustom = new System.Windows.Forms.CheckBox();
            tabPage17 = new System.Windows.Forms.TabPage();
            cbMultiscreenDrawOnExternalDisplays = new System.Windows.Forms.CheckBox();
            cbMultiscreenDrawOnPanels = new System.Windows.Forms.CheckBox();
            cbFlipHorizontal2 = new System.Windows.Forms.CheckBox();
            cbFlipVertical2 = new System.Windows.Forms.CheckBox();
            cbStretch2 = new System.Windows.Forms.CheckBox();
            cbFlipHorizontal1 = new System.Windows.Forms.CheckBox();
            cbFlipVertical1 = new System.Windows.Forms.CheckBox();
            cbStretch1 = new System.Windows.Forms.CheckBox();
            pnScreen2 = new System.Windows.Forms.Panel();
            pnScreen1 = new System.Windows.Forms.Panel();
            tabPage4 = new System.Windows.Forms.TabPage();
            tabControl17 = new System.Windows.Forms.TabControl();
            tabPage68 = new System.Windows.Forms.TabPage();
            cbScrollingText = new System.Windows.Forms.CheckBox();
            cbFlipY = new System.Windows.Forms.CheckBox();
            cbFlipX = new System.Windows.Forms.CheckBox();
            label201 = new System.Windows.Forms.Label();
            label200 = new System.Windows.Forms.Label();
            label199 = new System.Windows.Forms.Label();
            label198 = new System.Windows.Forms.Label();
            tabControl7 = new System.Windows.Forms.TabControl();
            tabPage29 = new System.Windows.Forms.TabPage();
            btTextLogoRemove = new System.Windows.Forms.Button();
            btTextLogoEdit = new System.Windows.Forms.Button();
            lbTextLogos = new System.Windows.Forms.ListBox();
            btTextLogoAdd = new System.Windows.Forms.Button();
            tabPage42 = new System.Windows.Forms.TabPage();
            btImageLogoRemove = new System.Windows.Forms.Button();
            btImageLogoEdit = new System.Windows.Forms.Button();
            lbImageLogos = new System.Windows.Forms.ListBox();
            btImageLogoAdd = new System.Windows.Forms.Button();
            tabPage18 = new System.Windows.Forms.TabPage();
            groupBox37 = new System.Windows.Forms.GroupBox();
            btEffZoomRight = new System.Windows.Forms.Button();
            btEffZoomLeft = new System.Windows.Forms.Button();
            btEffZoomOut = new System.Windows.Forms.Button();
            btEffZoomIn = new System.Windows.Forms.Button();
            btEffZoomDown = new System.Windows.Forms.Button();
            btEffZoomUp = new System.Windows.Forms.Button();
            cbZoom = new System.Windows.Forms.CheckBox();
            tabPage19 = new System.Windows.Forms.TabPage();
            groupBox40 = new System.Windows.Forms.GroupBox();
            edPanDestHeight = new System.Windows.Forms.TextBox();
            label302 = new System.Windows.Forms.Label();
            edPanDestWidth = new System.Windows.Forms.TextBox();
            label303 = new System.Windows.Forms.Label();
            edPanDestTop = new System.Windows.Forms.TextBox();
            label304 = new System.Windows.Forms.Label();
            edPanDestLeft = new System.Windows.Forms.TextBox();
            label305 = new System.Windows.Forms.Label();
            groupBox39 = new System.Windows.Forms.GroupBox();
            edPanSourceHeight = new System.Windows.Forms.TextBox();
            label298 = new System.Windows.Forms.Label();
            edPanSourceWidth = new System.Windows.Forms.TextBox();
            label299 = new System.Windows.Forms.Label();
            edPanSourceTop = new System.Windows.Forms.TextBox();
            label300 = new System.Windows.Forms.Label();
            edPanSourceLeft = new System.Windows.Forms.TextBox();
            label301 = new System.Windows.Forms.Label();
            groupBox38 = new System.Windows.Forms.GroupBox();
            edPanStopTime = new System.Windows.Forms.TextBox();
            label296 = new System.Windows.Forms.Label();
            edPanStartTime = new System.Windows.Forms.TextBox();
            label297 = new System.Windows.Forms.Label();
            cbPan = new System.Windows.Forms.CheckBox();
            tabPage22 = new System.Windows.Forms.TabPage();
            rbFadeOut = new System.Windows.Forms.RadioButton();
            rbFadeIn = new System.Windows.Forms.RadioButton();
            groupBox45 = new System.Windows.Forms.GroupBox();
            edFadeInOutStopTime = new System.Windows.Forms.TextBox();
            label329 = new System.Windows.Forms.Label();
            edFadeInOutStartTime = new System.Windows.Forms.TextBox();
            label330 = new System.Windows.Forms.Label();
            cbFadeInOut = new System.Windows.Forms.CheckBox();
            tabPage43 = new System.Windows.Forms.TabPage();
            cbLiveRotationStretch = new System.Windows.Forms.CheckBox();
            label392 = new System.Windows.Forms.Label();
            label391 = new System.Windows.Forms.Label();
            tbLiveRotationAngle = new System.Windows.Forms.TrackBar();
            label390 = new System.Windows.Forms.Label();
            cbLiveRotation = new System.Windows.Forms.CheckBox();
            tbContrast = new System.Windows.Forms.TrackBar();
            tbDarkness = new System.Windows.Forms.TrackBar();
            tbLightness = new System.Windows.Forms.TrackBar();
            tbSaturation = new System.Windows.Forms.TrackBar();
            cbInvert = new System.Windows.Forms.CheckBox();
            cbGreyscale = new System.Windows.Forms.CheckBox();
            cbVideoEffects = new System.Windows.Forms.CheckBox();
            tabPage69 = new System.Windows.Forms.TabPage();
            label211 = new System.Windows.Forms.Label();
            edDeintTriangleWeight = new System.Windows.Forms.TextBox();
            label212 = new System.Windows.Forms.Label();
            label210 = new System.Windows.Forms.Label();
            label209 = new System.Windows.Forms.Label();
            label206 = new System.Windows.Forms.Label();
            edDeintBlendConstants2 = new System.Windows.Forms.TextBox();
            label207 = new System.Windows.Forms.Label();
            edDeintBlendConstants1 = new System.Windows.Forms.TextBox();
            label208 = new System.Windows.Forms.Label();
            label204 = new System.Windows.Forms.Label();
            edDeintBlendThreshold2 = new System.Windows.Forms.TextBox();
            label205 = new System.Windows.Forms.Label();
            edDeintBlendThreshold1 = new System.Windows.Forms.TextBox();
            label203 = new System.Windows.Forms.Label();
            label202 = new System.Windows.Forms.Label();
            edDeintCAVTThreshold = new System.Windows.Forms.TextBox();
            label104 = new System.Windows.Forms.Label();
            rbDeintTriangleEnabled = new System.Windows.Forms.RadioButton();
            rbDeintBlendEnabled = new System.Windows.Forms.RadioButton();
            rbDeintCAVTEnabled = new System.Windows.Forms.RadioButton();
            cbDeinterlace = new System.Windows.Forms.CheckBox();
            tabPage59 = new System.Windows.Forms.TabPage();
            rbDenoiseCAST = new System.Windows.Forms.RadioButton();
            rbDenoiseMosquito = new System.Windows.Forms.RadioButton();
            cbDenoise = new System.Windows.Forms.CheckBox();
            tabPage51 = new System.Windows.Forms.TabPage();
            label22 = new System.Windows.Forms.Label();
            tbGPUBlur = new System.Windows.Forms.TrackBar();
            cbVideoEffectsGPUEnabled = new System.Windows.Forms.CheckBox();
            cbGPUOldMovie = new System.Windows.Forms.CheckBox();
            cbGPUDeinterlace = new System.Windows.Forms.CheckBox();
            cbGPUDenoise = new System.Windows.Forms.CheckBox();
            cbGPUPixelate = new System.Windows.Forms.CheckBox();
            cbGPUNightVision = new System.Windows.Forms.CheckBox();
            label383 = new System.Windows.Forms.Label();
            label384 = new System.Windows.Forms.Label();
            label385 = new System.Windows.Forms.Label();
            label386 = new System.Windows.Forms.Label();
            tbGPUContrast = new System.Windows.Forms.TrackBar();
            tbGPUDarkness = new System.Windows.Forms.TrackBar();
            tbGPULightness = new System.Windows.Forms.TrackBar();
            tbGPUSaturation = new System.Windows.Forms.TrackBar();
            cbGPUInvert = new System.Windows.Forms.CheckBox();
            cbGPUGreyscale = new System.Windows.Forms.CheckBox();
            tabPage8 = new System.Windows.Forms.TabPage();
            lbAdjSaturationCurrent = new System.Windows.Forms.Label();
            lbAdjSaturationMax = new System.Windows.Forms.Label();
            lbAdjSaturationMin = new System.Windows.Forms.Label();
            tbAdjSaturation = new System.Windows.Forms.TrackBar();
            label45 = new System.Windows.Forms.Label();
            lbAdjHueCurrent = new System.Windows.Forms.Label();
            lbAdjHueMax = new System.Windows.Forms.Label();
            lbAdjHueMin = new System.Windows.Forms.Label();
            tbAdjHue = new System.Windows.Forms.TrackBar();
            label41 = new System.Windows.Forms.Label();
            lbAdjContrastCurrent = new System.Windows.Forms.Label();
            lbAdjContrastMax = new System.Windows.Forms.Label();
            lbAdjContrastMin = new System.Windows.Forms.Label();
            tbAdjContrast = new System.Windows.Forms.TrackBar();
            label23 = new System.Windows.Forms.Label();
            lbAdjBrightnessCurrent = new System.Windows.Forms.Label();
            lbAdjBrightnessMax = new System.Windows.Forms.Label();
            lbAdjBrightnessMin = new System.Windows.Forms.Label();
            tbAdjBrightness = new System.Windows.Forms.TrackBar();
            label24 = new System.Windows.Forms.Label();
            tabPage15 = new System.Windows.Forms.TabPage();
            pnChromaKeyColor = new System.Windows.Forms.Panel();
            btChromaKeySelectBGImage = new System.Windows.Forms.Button();
            edChromaKeyImage = new System.Windows.Forms.TextBox();
            label216 = new System.Windows.Forms.Label();
            label215 = new System.Windows.Forms.Label();
            tbChromaKeySmoothing = new System.Windows.Forms.TrackBar();
            label214 = new System.Windows.Forms.Label();
            tbChromaKeyThresholdSensitivity = new System.Windows.Forms.TrackBar();
            label213 = new System.Windows.Forms.Label();
            cbChromaKeyEnabled = new System.Windows.Forms.CheckBox();
            tabPage46 = new System.Windows.Forms.TabPage();
            btFilterDelete = new System.Windows.Forms.Button();
            btFilterDeleteAll = new System.Windows.Forms.Button();
            btFilterSettings2 = new System.Windows.Forms.Button();
            lbFilters = new System.Windows.Forms.ListBox();
            label106 = new System.Windows.Forms.Label();
            btFilterSettings = new System.Windows.Forms.Button();
            btFilterAdd = new System.Windows.Forms.Button();
            cbFilters = new System.Windows.Forms.ComboBox();
            label105 = new System.Windows.Forms.Label();
            tabPage48 = new System.Windows.Forms.TabPage();
            lbAudioTimeshift = new System.Windows.Forms.Label();
            tbAudioTimeshift = new System.Windows.Forms.TrackBar();
            label70 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            lbAudioOutputGainLFE = new System.Windows.Forms.Label();
            tbAudioOutputGainLFE = new System.Windows.Forms.TrackBar();
            label55 = new System.Windows.Forms.Label();
            lbAudioOutputGainSR = new System.Windows.Forms.Label();
            tbAudioOutputGainSR = new System.Windows.Forms.TrackBar();
            label57 = new System.Windows.Forms.Label();
            lbAudioOutputGainSL = new System.Windows.Forms.Label();
            tbAudioOutputGainSL = new System.Windows.Forms.TrackBar();
            label59 = new System.Windows.Forms.Label();
            lbAudioOutputGainR = new System.Windows.Forms.Label();
            tbAudioOutputGainR = new System.Windows.Forms.TrackBar();
            label61 = new System.Windows.Forms.Label();
            lbAudioOutputGainC = new System.Windows.Forms.Label();
            tbAudioOutputGainC = new System.Windows.Forms.TrackBar();
            label67 = new System.Windows.Forms.Label();
            lbAudioOutputGainL = new System.Windows.Forms.Label();
            tbAudioOutputGainL = new System.Windows.Forms.TrackBar();
            label69 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lbAudioInputGainLFE = new System.Windows.Forms.Label();
            tbAudioInputGainLFE = new System.Windows.Forms.TrackBar();
            label53 = new System.Windows.Forms.Label();
            lbAudioInputGainSR = new System.Windows.Forms.Label();
            tbAudioInputGainSR = new System.Windows.Forms.TrackBar();
            label51 = new System.Windows.Forms.Label();
            lbAudioInputGainSL = new System.Windows.Forms.Label();
            tbAudioInputGainSL = new System.Windows.Forms.TrackBar();
            label49 = new System.Windows.Forms.Label();
            lbAudioInputGainR = new System.Windows.Forms.Label();
            tbAudioInputGainR = new System.Windows.Forms.TrackBar();
            label47 = new System.Windows.Forms.Label();
            lbAudioInputGainC = new System.Windows.Forms.Label();
            tbAudioInputGainC = new System.Windows.Forms.TrackBar();
            label44 = new System.Windows.Forms.Label();
            lbAudioInputGainL = new System.Windows.Forms.Label();
            tbAudioInputGainL = new System.Windows.Forms.TrackBar();
            label40 = new System.Windows.Forms.Label();
            cbAudioAutoGain = new System.Windows.Forms.CheckBox();
            cbAudioNormalize = new System.Windows.Forms.CheckBox();
            cbAudioEnhancementEnabled = new System.Windows.Forms.CheckBox();
            tabPage11 = new System.Windows.Forms.TabPage();
            label31 = new System.Windows.Forms.Label();
            tabControl18 = new System.Windows.Forms.TabControl();
            tabPage71 = new System.Windows.Forms.TabPage();
            label231 = new System.Windows.Forms.Label();
            label230 = new System.Windows.Forms.Label();
            tbAudAmplifyAmp = new System.Windows.Forms.TrackBar();
            label95 = new System.Windows.Forms.Label();
            cbAudAmplifyEnabled = new System.Windows.Forms.CheckBox();
            tabPage72 = new System.Windows.Forms.TabPage();
            btAudEqRefresh = new System.Windows.Forms.Button();
            cbAudEqualizerPreset = new System.Windows.Forms.ComboBox();
            label243 = new System.Windows.Forms.Label();
            label242 = new System.Windows.Forms.Label();
            label241 = new System.Windows.Forms.Label();
            label240 = new System.Windows.Forms.Label();
            label239 = new System.Windows.Forms.Label();
            label238 = new System.Windows.Forms.Label();
            label237 = new System.Windows.Forms.Label();
            label236 = new System.Windows.Forms.Label();
            label235 = new System.Windows.Forms.Label();
            label234 = new System.Windows.Forms.Label();
            label233 = new System.Windows.Forms.Label();
            label232 = new System.Windows.Forms.Label();
            tbAudEq9 = new System.Windows.Forms.TrackBar();
            tbAudEq8 = new System.Windows.Forms.TrackBar();
            tbAudEq7 = new System.Windows.Forms.TrackBar();
            tbAudEq6 = new System.Windows.Forms.TrackBar();
            tbAudEq5 = new System.Windows.Forms.TrackBar();
            tbAudEq4 = new System.Windows.Forms.TrackBar();
            tbAudEq3 = new System.Windows.Forms.TrackBar();
            tbAudEq2 = new System.Windows.Forms.TrackBar();
            tbAudEq1 = new System.Windows.Forms.TrackBar();
            tbAudEq0 = new System.Windows.Forms.TrackBar();
            cbAudEqualizerEnabled = new System.Windows.Forms.CheckBox();
            tabPage73 = new System.Windows.Forms.TabPage();
            tbAudRelease = new System.Windows.Forms.TrackBar();
            label248 = new System.Windows.Forms.Label();
            label249 = new System.Windows.Forms.Label();
            label246 = new System.Windows.Forms.Label();
            tbAudAttack = new System.Windows.Forms.TrackBar();
            label247 = new System.Windows.Forms.Label();
            label244 = new System.Windows.Forms.Label();
            tbAudDynAmp = new System.Windows.Forms.TrackBar();
            label245 = new System.Windows.Forms.Label();
            cbAudDynamicAmplifyEnabled = new System.Windows.Forms.CheckBox();
            tabPage75 = new System.Windows.Forms.TabPage();
            tbAud3DSound = new System.Windows.Forms.TrackBar();
            label253 = new System.Windows.Forms.Label();
            cbAudSound3DEnabled = new System.Windows.Forms.CheckBox();
            tabPage76 = new System.Windows.Forms.TabPage();
            tbAudTrueBass = new System.Windows.Forms.TrackBar();
            label254 = new System.Windows.Forms.Label();
            cbAudTrueBassEnabled = new System.Windows.Forms.CheckBox();
            tabPage27 = new System.Windows.Forms.TabPage();
            tbAudPitchShift = new System.Windows.Forms.TrackBar();
            label36 = new System.Windows.Forms.Label();
            cbAudPitchShiftEnabled = new System.Windows.Forms.CheckBox();
            cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            tabPage50 = new System.Windows.Forms.TabPage();
            btAudioChannelMapperClear = new System.Windows.Forms.Button();
            groupBox41 = new System.Windows.Forms.GroupBox();
            btAudioChannelMapperAddNewRoute = new System.Windows.Forms.Button();
            label311 = new System.Windows.Forms.Label();
            tbAudioChannelMapperVolume = new System.Windows.Forms.TrackBar();
            label310 = new System.Windows.Forms.Label();
            edAudioChannelMapperTargetChannel = new System.Windows.Forms.TextBox();
            label309 = new System.Windows.Forms.Label();
            edAudioChannelMapperSourceChannel = new System.Windows.Forms.TextBox();
            label308 = new System.Windows.Forms.Label();
            label307 = new System.Windows.Forms.Label();
            edAudioChannelMapperOutputChannels = new System.Windows.Forms.TextBox();
            label306 = new System.Windows.Forms.Label();
            lbAudioChannelMapperRoutes = new System.Windows.Forms.ListBox();
            cbAudioChannelMapperEnabled = new System.Windows.Forms.CheckBox();
            tabPage28 = new System.Windows.Forms.TabPage();
            tbVUMeterBoost = new System.Windows.Forms.TrackBar();
            label382 = new System.Windows.Forms.Label();
            label381 = new System.Windows.Forms.Label();
            tbVUMeterAmplification = new System.Windows.Forms.TrackBar();
            cbVUMeterPro = new System.Windows.Forms.CheckBox();
            waveformPainter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            waveformPainter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            volumeMeter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            volumeMeter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            tabPage5 = new System.Windows.Forms.TabPage();
            btOSDRenderLayers = new System.Windows.Forms.Button();
            lbOSDLayers = new System.Windows.Forms.CheckedListBox();
            cbOSDEnabled = new System.Windows.Forms.CheckBox();
            groupBox19 = new System.Windows.Forms.GroupBox();
            btOSDClearLayer = new System.Windows.Forms.Button();
            tabControl6 = new System.Windows.Forms.TabControl();
            tabPage30 = new System.Windows.Forms.TabPage();
            btOSDImageDraw = new System.Windows.Forms.Button();
            pnOSDColorKey = new System.Windows.Forms.Panel();
            cbOSDImageTranspColor = new System.Windows.Forms.CheckBox();
            edOSDImageTop = new System.Windows.Forms.TextBox();
            label115 = new System.Windows.Forms.Label();
            edOSDImageLeft = new System.Windows.Forms.TextBox();
            label114 = new System.Windows.Forms.Label();
            btOSDSelectImage = new System.Windows.Forms.Button();
            edOSDImageFilename = new System.Windows.Forms.TextBox();
            label113 = new System.Windows.Forms.Label();
            tabPage31 = new System.Windows.Forms.TabPage();
            edOSDTextTop = new System.Windows.Forms.TextBox();
            label117 = new System.Windows.Forms.Label();
            edOSDTextLeft = new System.Windows.Forms.TextBox();
            label118 = new System.Windows.Forms.Label();
            label116 = new System.Windows.Forms.Label();
            btOSDSelectFont = new System.Windows.Forms.Button();
            edOSDText = new System.Windows.Forms.TextBox();
            btOSDTextDraw = new System.Windows.Forms.Button();
            tabPage32 = new System.Windows.Forms.TabPage();
            tbOSDTranspLevel = new System.Windows.Forms.TrackBar();
            btOSDSetTransp = new System.Windows.Forms.Button();
            label119 = new System.Windows.Forms.Label();
            btOSDClearLayers = new System.Windows.Forms.Button();
            groupBox15 = new System.Windows.Forms.GroupBox();
            btOSDLayerAdd = new System.Windows.Forms.Button();
            edOSDLayerHeight = new System.Windows.Forms.TextBox();
            label111 = new System.Windows.Forms.Label();
            edOSDLayerWidth = new System.Windows.Forms.TextBox();
            label112 = new System.Windows.Forms.Label();
            edOSDLayerTop = new System.Windows.Forms.TextBox();
            label110 = new System.Windows.Forms.Label();
            edOSDLayerLeft = new System.Windows.Forms.TextBox();
            label109 = new System.Windows.Forms.Label();
            label108 = new System.Windows.Forms.Label();
            tabPage12 = new System.Windows.Forms.TabPage();
            tabControl5 = new System.Windows.Forms.TabControl();
            tabPage33 = new System.Windows.Forms.TabPage();
            cbCustomSplitter = new System.Windows.Forms.ComboBox();
            rbSplitterCustom = new System.Windows.Forms.RadioButton();
            rbSplitterDefault = new System.Windows.Forms.RadioButton();
            tabPage34 = new System.Windows.Forms.TabPage();
            rbVideoDecoderVFH264 = new System.Windows.Forms.RadioButton();
            cbCustomVideoDecoder = new System.Windows.Forms.ComboBox();
            label28 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            rbVideoDecoderCustom = new System.Windows.Forms.RadioButton();
            rbVideoDecoderFFDShow = new System.Windows.Forms.RadioButton();
            rbVideoDecoderMS = new System.Windows.Forms.RadioButton();
            rbVideoDecoderDefault = new System.Windows.Forms.RadioButton();
            tabPage47 = new System.Windows.Forms.TabPage();
            cbCustomAudioDecoder = new System.Windows.Forms.ComboBox();
            rbAudioDecoderCustom = new System.Windows.Forms.RadioButton();
            rbAudioDecoderDefault = new System.Windows.Forms.RadioButton();
            tabPage13 = new System.Windows.Forms.TabPage();
            tabControl9 = new System.Windows.Forms.TabControl();
            tabPage44 = new System.Windows.Forms.TabPage();
            pbMotionLevel = new System.Windows.Forms.ProgressBar();
            label158 = new System.Windows.Forms.Label();
            mmMotDetMatrix = new System.Windows.Forms.TextBox();
            tabPage45 = new System.Windows.Forms.TabPage();
            groupBox25 = new System.Windows.Forms.GroupBox();
            cbMotDetHLColor = new System.Windows.Forms.ComboBox();
            label161 = new System.Windows.Forms.Label();
            label160 = new System.Windows.Forms.Label();
            cbMotDetHLEnabled = new System.Windows.Forms.CheckBox();
            tbMotDetHLThreshold = new System.Windows.Forms.TrackBar();
            btMotDetUpdateSettings = new System.Windows.Forms.Button();
            groupBox27 = new System.Windows.Forms.GroupBox();
            edMotDetMatrixHeight = new System.Windows.Forms.TextBox();
            label163 = new System.Windows.Forms.Label();
            edMotDetMatrixWidth = new System.Windows.Forms.TextBox();
            label164 = new System.Windows.Forms.Label();
            groupBox26 = new System.Windows.Forms.GroupBox();
            label162 = new System.Windows.Forms.Label();
            tbMotDetDropFramesThreshold = new System.Windows.Forms.TrackBar();
            cbMotDetDropFramesEnabled = new System.Windows.Forms.CheckBox();
            groupBox24 = new System.Windows.Forms.GroupBox();
            edMotDetFrameInterval = new System.Windows.Forms.TextBox();
            label159 = new System.Windows.Forms.Label();
            cbCompareGreyscale = new System.Windows.Forms.CheckBox();
            cbCompareBlue = new System.Windows.Forms.CheckBox();
            cbCompareGreen = new System.Windows.Forms.CheckBox();
            cbCompareRed = new System.Windows.Forms.CheckBox();
            cbMotDetEnabled = new System.Windows.Forms.CheckBox();
            tabPage14 = new System.Windows.Forms.TabPage();
            label505 = new System.Windows.Forms.Label();
            rbMotionDetectionExProcessor = new System.Windows.Forms.ComboBox();
            label389 = new System.Windows.Forms.Label();
            rbMotionDetectionExDetector = new System.Windows.Forms.ComboBox();
            label64 = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            cbMotionDetectionEx = new System.Windows.Forms.CheckBox();
            tabPage21 = new System.Windows.Forms.TabPage();
            edBarcodeMetadata = new System.Windows.Forms.TextBox();
            label91 = new System.Windows.Forms.Label();
            cbBarcodeType = new System.Windows.Forms.ComboBox();
            label90 = new System.Windows.Forms.Label();
            btBarcodeReset = new System.Windows.Forms.Button();
            edBarcode = new System.Windows.Forms.TextBox();
            label89 = new System.Windows.Forms.Label();
            cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            tabPage23 = new System.Windows.Forms.TabPage();
            textBox1 = new System.Windows.Forms.TextBox();
            groupBox48 = new System.Windows.Forms.GroupBox();
            label343 = new System.Windows.Forms.Label();
            edEncryptionKeyHEX = new System.Windows.Forms.TextBox();
            rbEncryptionKeyBinary = new System.Windows.Forms.RadioButton();
            btEncryptionOpenFile = new System.Windows.Forms.Button();
            edEncryptionKeyFile = new System.Windows.Forms.TextBox();
            rbEncryptionKeyFile = new System.Windows.Forms.RadioButton();
            edEncryptionKeyString = new System.Windows.Forms.TextBox();
            rbEncryptionKeyString = new System.Windows.Forms.RadioButton();
            tabPage24 = new System.Windows.Forms.TabPage();
            btReversePlaybackNextFrame = new System.Windows.Forms.Button();
            btReversePlaybackPrevFrame = new System.Windows.Forms.Button();
            label34 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            btReversePlayback = new System.Windows.Forms.Button();
            edReversePlaybackCacheSize = new System.Windows.Forms.TextBox();
            label32 = new System.Windows.Forms.Label();
            tbReversePlaybackTrackbar = new System.Windows.Forms.TrackBar();
            label14 = new System.Windows.Forms.Label();
            edFilenameOrURL = new System.Windows.Forms.TextBox();
            btSelectFile = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btPreviousFrame = new System.Windows.Forms.Button();
            cbLoop = new System.Windows.Forms.CheckBox();
            btNextFrame = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tbSpeed = new System.Windows.Forms.TrackBar();
            label16 = new System.Windows.Forms.Label();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            fontDialog1 = new System.Windows.Forms.FontDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            label29 = new System.Windows.Forms.Label();
            cbSourceMode = new System.Windows.Forms.ComboBox();
            lbSourceFiles = new System.Windows.Forms.ListBox();
            mnPlaylist = new System.Windows.Forms.ContextMenuStrip(components);
            mnPlaylistRemove = new System.Windows.Forms.ToolStripMenuItem();
            mnPlaylistRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            label30 = new System.Windows.Forms.Label();
            btAddFileToPlaylist = new System.Windows.Forms.Button();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            btSaveSnapshot = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            tabPage20.SuspendLayout();
            groupBox6.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage49.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgTags).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).BeginInit();
            tabPage3.SuspendLayout();
            tabControl4.SuspendLayout();
            tabPage16.SuspendLayout();
            groupBox28.SuspendLayout();
            groupBox13.SuspendLayout();
            tabPage17.SuspendLayout();
            tabPage4.SuspendLayout();
            tabControl17.SuspendLayout();
            tabPage68.SuspendLayout();
            tabControl7.SuspendLayout();
            tabPage29.SuspendLayout();
            tabPage42.SuspendLayout();
            tabPage18.SuspendLayout();
            groupBox37.SuspendLayout();
            tabPage19.SuspendLayout();
            groupBox40.SuspendLayout();
            groupBox39.SuspendLayout();
            groupBox38.SuspendLayout();
            tabPage22.SuspendLayout();
            groupBox45.SuspendLayout();
            tabPage43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbLiveRotationAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage69.SuspendLayout();
            tabPage59.SuspendLayout();
            tabPage51.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).BeginInit();
            tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAdjSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjBrightness).BeginInit();
            tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).BeginInit();
            tabPage46.SuspendLayout();
            tabPage48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).BeginInit();
            tabPage11.SuspendLayout();
            tabControl18.SuspendLayout();
            tabPage71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudAmplifyAmp).BeginInit();
            tabPage72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudEq9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq0).BeginInit();
            tabPage73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudRelease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudAttack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudDynAmp).BeginInit();
            tabPage75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAud3DSound).BeginInit();
            tabPage76.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudTrueBass).BeginInit();
            tabPage27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudPitchShift).BeginInit();
            tabPage50.SuspendLayout();
            groupBox41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).BeginInit();
            tabPage28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).BeginInit();
            tabPage5.SuspendLayout();
            groupBox19.SuspendLayout();
            tabControl6.SuspendLayout();
            tabPage30.SuspendLayout();
            tabPage31.SuspendLayout();
            tabPage32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbOSDTranspLevel).BeginInit();
            groupBox15.SuspendLayout();
            tabPage12.SuspendLayout();
            tabControl5.SuspendLayout();
            tabPage33.SuspendLayout();
            tabPage34.SuspendLayout();
            tabPage47.SuspendLayout();
            tabPage13.SuspendLayout();
            tabControl9.SuspendLayout();
            tabPage44.SuspendLayout();
            tabPage45.SuspendLayout();
            groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetHLThreshold).BeginInit();
            groupBox27.SuspendLayout();
            groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetDropFramesThreshold).BeginInit();
            groupBox24.SuspendLayout();
            tabPage14.SuspendLayout();
            tabPage21.SuspendLayout();
            tabPage23.SuspendLayout();
            groupBox48.SuspendLayout();
            tabPage24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbReversePlaybackTrackbar).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            mnPlaylist.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage20);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage48);
            tabControl1.Controls.Add(tabPage11);
            tabControl1.Controls.Add(tabPage50);
            tabControl1.Controls.Add(tabPage28);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage12);
            tabControl1.Controls.Add(tabPage13);
            tabControl1.Controls.Add(tabPage14);
            tabControl1.Controls.Add(tabPage21);
            tabControl1.Controls.Add(tabPage23);
            tabControl1.Controls.Add(tabPage24);
            tabControl1.Location = new System.Drawing.Point(20, 22);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(516, 995);
            tabControl1.TabIndex = 1;
            // 
            // tabPage20
            // 
            tabPage20.Controls.Add(groupBox6);
            tabPage20.Location = new System.Drawing.Point(4, 34);
            tabPage20.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage20.Name = "tabPage20";
            tabPage20.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage20.Size = new System.Drawing.Size(508, 957);
            tabPage20.TabIndex = 15;
            tabPage20.Text = "Source mode";
            tabPage20.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(rbGPUDirect3D);
            groupBox6.Controls.Add(rbGPUDXVANative);
            groupBox6.Controls.Add(rbGPUDXVACopyBack);
            groupBox6.Controls.Add(rbGPUIntel);
            groupBox6.Controls.Add(rbGPUNVidia);
            groupBox6.Location = new System.Drawing.Point(10, 11);
            groupBox6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox6.Size = new System.Drawing.Size(468, 208);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "GPU decoder";
            // 
            // rbGPUDirect3D
            // 
            rbGPUDirect3D.AutoSize = true;
            rbGPUDirect3D.Location = new System.Drawing.Point(22, 141);
            rbGPUDirect3D.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbGPUDirect3D.Name = "rbGPUDirect3D";
            rbGPUDirect3D.Size = new System.Drawing.Size(131, 29);
            rbGPUDirect3D.TabIndex = 4;
            rbGPUDirect3D.Text = "Direct3D 11";
            rbGPUDirect3D.UseVisualStyleBackColor = true;
            // 
            // rbGPUDXVANative
            // 
            rbGPUDXVANative.AutoSize = true;
            rbGPUDXVANative.Location = new System.Drawing.Point(218, 95);
            rbGPUDXVANative.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbGPUDXVANative.Name = "rbGPUDXVANative";
            rbGPUDXVANative.Size = new System.Drawing.Size(154, 29);
            rbGPUDXVANative.TabIndex = 3;
            rbGPUDXVANative.Text = "DXVA2 (native)";
            rbGPUDXVANative.UseVisualStyleBackColor = true;
            // 
            // rbGPUDXVACopyBack
            // 
            rbGPUDXVACopyBack.AutoSize = true;
            rbGPUDXVACopyBack.Checked = true;
            rbGPUDXVACopyBack.Location = new System.Drawing.Point(22, 95);
            rbGPUDXVACopyBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbGPUDXVACopyBack.Name = "rbGPUDXVACopyBack";
            rbGPUDXVACopyBack.Size = new System.Drawing.Size(190, 29);
            rbGPUDXVACopyBack.TabIndex = 2;
            rbGPUDXVACopyBack.TabStop = true;
            rbGPUDXVACopyBack.Text = "DXVA2 (copy-back)";
            rbGPUDXVACopyBack.UseVisualStyleBackColor = true;
            // 
            // rbGPUIntel
            // 
            rbGPUIntel.AutoSize = true;
            rbGPUIntel.Location = new System.Drawing.Point(218, 52);
            rbGPUIntel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbGPUIntel.Name = "rbGPUIntel";
            rbGPUIntel.Size = new System.Drawing.Size(157, 29);
            rbGPUIntel.TabIndex = 1;
            rbGPUIntel.Text = "Intel QuickSync";
            rbGPUIntel.UseVisualStyleBackColor = true;
            // 
            // rbGPUNVidia
            // 
            rbGPUNVidia.AutoSize = true;
            rbGPUNVidia.Location = new System.Drawing.Point(22, 52);
            rbGPUNVidia.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbGPUNVidia.Name = "rbGPUNVidia";
            rbGPUNVidia.Size = new System.Drawing.Size(143, 29);
            rbGPUNVidia.TabIndex = 0;
            rbGPUNVidia.Text = "nVidia CUVID";
            rbGPUNVidia.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbUseLibMediaInfo);
            tabPage1.Controls.Add(btReadInfo);
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Size = new System.Drawing.Size(508, 957);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbUseLibMediaInfo
            // 
            cbUseLibMediaInfo.AutoSize = true;
            cbUseLibMediaInfo.Checked = true;
            cbUseLibMediaInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            cbUseLibMediaInfo.Location = new System.Drawing.Point(24, 719);
            cbUseLibMediaInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbUseLibMediaInfo.Name = "cbUseLibMediaInfo";
            cbUseLibMediaInfo.Size = new System.Drawing.Size(172, 29);
            cbUseLibMediaInfo.TabIndex = 2;
            cbUseLibMediaInfo.Text = "Use libMediaInfo";
            cbUseLibMediaInfo.UseVisualStyleBackColor = true;
            // 
            // btReadInfo
            // 
            btReadInfo.Location = new System.Drawing.Point(24, 842);
            btReadInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btReadInfo.Name = "btReadInfo";
            btReadInfo.Size = new System.Drawing.Size(124, 44);
            btReadInfo.TabIndex = 1;
            btReadInfo.Text = "Read info";
            btReadInfo.UseVisualStyleBackColor = true;
            btReadInfo.Click += btReadInfo_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage6);
            tabControl2.Controls.Add(tabPage49);
            tabControl2.Location = new System.Drawing.Point(28, 31);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(452, 658);
            tabControl2.TabIndex = 0;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(mmInfo);
            tabPage6.Location = new System.Drawing.Point(4, 34);
            tabPage6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage6.Size = new System.Drawing.Size(444, 620);
            tabPage6.TabIndex = 0;
            tabPage6.Text = "File";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // mmInfo
            // 
            mmInfo.Location = new System.Drawing.Point(28, 39);
            mmInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmInfo.Multiline = true;
            mmInfo.Name = "mmInfo";
            mmInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmInfo.Size = new System.Drawing.Size(384, 446);
            mmInfo.TabIndex = 0;
            // 
            // tabPage49
            // 
            tabPage49.Controls.Add(imgTags);
            tabPage49.Controls.Add(edTags);
            tabPage49.Controls.Add(btReadTags);
            tabPage49.Location = new System.Drawing.Point(4, 34);
            tabPage49.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage49.Name = "tabPage49";
            tabPage49.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage49.Size = new System.Drawing.Size(444, 620);
            tabPage49.TabIndex = 2;
            tabPage49.Text = "Tags";
            tabPage49.UseVisualStyleBackColor = true;
            // 
            // imgTags
            // 
            imgTags.Location = new System.Drawing.Point(262, 406);
            imgTags.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            imgTags.Name = "imgTags";
            imgTags.Size = new System.Drawing.Size(150, 172);
            imgTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgTags.TabIndex = 2;
            imgTags.TabStop = false;
            // 
            // edTags
            // 
            edTags.Location = new System.Drawing.Point(28, 31);
            edTags.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTags.Multiline = true;
            edTags.Name = "edTags";
            edTags.Size = new System.Drawing.Size(384, 359);
            edTags.TabIndex = 1;
            // 
            // btReadTags
            // 
            btReadTags.Location = new System.Drawing.Point(28, 534);
            btReadTags.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btReadTags.Name = "btReadTags";
            btReadTags.Size = new System.Drawing.Size(124, 44);
            btReadTags.TabIndex = 0;
            btReadTags.Text = "Read tags";
            btReadTags.UseVisualStyleBackColor = true;
            btReadTags.Click += btReadTags_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(tbBalance4);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(tbVolume4);
            tabPage2.Controls.Add(cbAudioStream4);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(tbBalance3);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(tbVolume3);
            tabPage2.Controls.Add(cbAudioStream3);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(tbBalance2);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(tbVolume2);
            tabPage2.Controls.Add(cbAudioStream2);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(tbBalance1);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(tbVolume1);
            tabPage2.Controls.Add(cbAudioStream1);
            tabPage2.Controls.Add(cbPlayAudio);
            tabPage2.Controls.Add(cbAudioOutputDevice);
            tabPage2.Controls.Add(label5);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Size = new System.Drawing.Size(508, 957);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Audio output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(322, 600);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(71, 25);
            label10.TabIndex = 22;
            label10.Text = "Balance";
            // 
            // tbBalance4
            // 
            tbBalance4.BackColor = System.Drawing.SystemColors.Window;
            tbBalance4.Location = new System.Drawing.Point(328, 631);
            tbBalance4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbBalance4.Maximum = 100;
            tbBalance4.Minimum = -100;
            tbBalance4.Name = "tbBalance4";
            tbBalance4.Size = new System.Drawing.Size(142, 69);
            tbBalance4.TabIndex = 21;
            tbBalance4.Scroll += tbBalance4_Scroll;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(168, 600);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(72, 25);
            label11.TabIndex = 20;
            label11.Text = "Volume";
            // 
            // tbVolume4
            // 
            tbVolume4.BackColor = System.Drawing.SystemColors.Window;
            tbVolume4.Location = new System.Drawing.Point(171, 631);
            tbVolume4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVolume4.Maximum = 100;
            tbVolume4.Name = "tbVolume4";
            tbVolume4.Size = new System.Drawing.Size(142, 69);
            tbVolume4.TabIndex = 19;
            tbVolume4.Value = 85;
            tbVolume4.Scroll += tbVolume4_Scroll;
            // 
            // cbAudioStream4
            // 
            cbAudioStream4.AutoSize = true;
            cbAudioStream4.Location = new System.Drawing.Point(31, 570);
            cbAudioStream4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioStream4.Name = "cbAudioStream4";
            cbAudioStream4.Size = new System.Drawing.Size(108, 29);
            cbAudioStream4.TabIndex = 18;
            cbAudioStream4.Text = "Stream 4";
            cbAudioStream4.UseVisualStyleBackColor = true;
            cbAudioStream4.CheckedChanged += cbAudioStream4_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(322, 472);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(71, 25);
            label12.TabIndex = 17;
            label12.Text = "Balance";
            // 
            // tbBalance3
            // 
            tbBalance3.BackColor = System.Drawing.SystemColors.Window;
            tbBalance3.Location = new System.Drawing.Point(328, 505);
            tbBalance3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbBalance3.Maximum = 100;
            tbBalance3.Minimum = -100;
            tbBalance3.Name = "tbBalance3";
            tbBalance3.Size = new System.Drawing.Size(142, 69);
            tbBalance3.TabIndex = 16;
            tbBalance3.Scroll += tbBalance3_Scroll;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(168, 472);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(72, 25);
            label13.TabIndex = 15;
            label13.Text = "Volume";
            // 
            // tbVolume3
            // 
            tbVolume3.BackColor = System.Drawing.SystemColors.Window;
            tbVolume3.Location = new System.Drawing.Point(171, 505);
            tbVolume3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVolume3.Maximum = 100;
            tbVolume3.Name = "tbVolume3";
            tbVolume3.Size = new System.Drawing.Size(142, 69);
            tbVolume3.TabIndex = 14;
            tbVolume3.Value = 85;
            tbVolume3.Scroll += tbVolume3_Scroll;
            // 
            // cbAudioStream3
            // 
            cbAudioStream3.AutoSize = true;
            cbAudioStream3.Location = new System.Drawing.Point(31, 444);
            cbAudioStream3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioStream3.Name = "cbAudioStream3";
            cbAudioStream3.Size = new System.Drawing.Size(108, 29);
            cbAudioStream3.TabIndex = 13;
            cbAudioStream3.Text = "Stream 3";
            cbAudioStream3.UseVisualStyleBackColor = true;
            cbAudioStream3.CheckedChanged += cbAudioStream3_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(322, 355);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(71, 25);
            label8.TabIndex = 12;
            label8.Text = "Balance";
            // 
            // tbBalance2
            // 
            tbBalance2.BackColor = System.Drawing.SystemColors.Window;
            tbBalance2.Location = new System.Drawing.Point(328, 384);
            tbBalance2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbBalance2.Maximum = 100;
            tbBalance2.Minimum = -100;
            tbBalance2.Name = "tbBalance2";
            tbBalance2.Size = new System.Drawing.Size(142, 69);
            tbBalance2.TabIndex = 11;
            tbBalance2.Scroll += tbBalance2_Scroll;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(168, 355);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(72, 25);
            label9.TabIndex = 10;
            label9.Text = "Volume";
            // 
            // tbVolume2
            // 
            tbVolume2.BackColor = System.Drawing.SystemColors.Window;
            tbVolume2.Location = new System.Drawing.Point(171, 384);
            tbVolume2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVolume2.Maximum = 100;
            tbVolume2.Name = "tbVolume2";
            tbVolume2.Size = new System.Drawing.Size(142, 69);
            tbVolume2.TabIndex = 9;
            tbVolume2.Value = 85;
            tbVolume2.Scroll += tbVolume2_Scroll;
            // 
            // cbAudioStream2
            // 
            cbAudioStream2.AutoSize = true;
            cbAudioStream2.Location = new System.Drawing.Point(31, 325);
            cbAudioStream2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioStream2.Name = "cbAudioStream2";
            cbAudioStream2.Size = new System.Drawing.Size(108, 29);
            cbAudioStream2.TabIndex = 8;
            cbAudioStream2.Text = "Stream 2";
            cbAudioStream2.UseVisualStyleBackColor = true;
            cbAudioStream2.CheckedChanged += cbAudioStream2_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(322, 234);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(71, 25);
            label7.TabIndex = 7;
            label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            tbBalance1.Location = new System.Drawing.Point(328, 266);
            tbBalance1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbBalance1.Maximum = 100;
            tbBalance1.Minimum = -100;
            tbBalance1.Name = "tbBalance1";
            tbBalance1.Size = new System.Drawing.Size(142, 69);
            tbBalance1.TabIndex = 6;
            tbBalance1.Scroll += tbBalance1_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(168, 234);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 25);
            label6.TabIndex = 5;
            label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            tbVolume1.Location = new System.Drawing.Point(171, 266);
            tbVolume1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVolume1.Maximum = 100;
            tbVolume1.Name = "tbVolume1";
            tbVolume1.Size = new System.Drawing.Size(142, 69);
            tbVolume1.TabIndex = 4;
            tbVolume1.Value = 85;
            tbVolume1.Scroll += tbVolume1_Scroll;
            // 
            // cbAudioStream1
            // 
            cbAudioStream1.AutoSize = true;
            cbAudioStream1.Location = new System.Drawing.Point(31, 206);
            cbAudioStream1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioStream1.Name = "cbAudioStream1";
            cbAudioStream1.Size = new System.Drawing.Size(108, 29);
            cbAudioStream1.TabIndex = 3;
            cbAudioStream1.Text = "Stream 1";
            cbAudioStream1.UseVisualStyleBackColor = true;
            cbAudioStream1.CheckedChanged += cbAudioStream1_CheckedChanged;
            // 
            // cbPlayAudio
            // 
            cbPlayAudio.AutoSize = true;
            cbPlayAudio.Checked = true;
            cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            cbPlayAudio.Location = new System.Drawing.Point(31, 119);
            cbPlayAudio.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbPlayAudio.Name = "cbPlayAudio";
            cbPlayAudio.Size = new System.Drawing.Size(120, 29);
            cbPlayAudio.TabIndex = 2;
            cbPlayAudio.Text = "Play audio";
            cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutputDevice.FormattingEnabled = true;
            cbAudioOutputDevice.Location = new System.Drawing.Point(31, 69);
            cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            cbAudioOutputDevice.Size = new System.Drawing.Size(434, 33);
            cbAudioOutputDevice.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(28, 31);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(119, 25);
            label5.TabIndex = 0;
            label5.Text = "Audio output";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabControl4);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Size = new System.Drawing.Size(508, 957);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Display";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            tabControl4.Controls.Add(tabPage16);
            tabControl4.Controls.Add(tabPage17);
            tabControl4.Location = new System.Drawing.Point(4, 11);
            tabControl4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl4.Name = "tabControl4";
            tabControl4.SelectedIndex = 0;
            tabControl4.Size = new System.Drawing.Size(488, 922);
            tabControl4.TabIndex = 17;
            // 
            // tabPage16
            // 
            tabPage16.Controls.Add(label393);
            tabPage16.Controls.Add(cbDirect2DRotate);
            tabPage16.Controls.Add(pnVideoRendererBGColor);
            tabPage16.Controls.Add(label394);
            tabPage16.Controls.Add(btFullScreen);
            tabPage16.Controls.Add(groupBox28);
            tabPage16.Controls.Add(cbScreenFlipVertical);
            tabPage16.Controls.Add(cbScreenFlipHorizontal);
            tabPage16.Controls.Add(cbStretch);
            tabPage16.Controls.Add(groupBox13);
            tabPage16.Controls.Add(label15);
            tabPage16.Controls.Add(edAspectRatioY);
            tabPage16.Controls.Add(edAspectRatioX);
            tabPage16.Controls.Add(cbAspectRatioUseCustom);
            tabPage16.Location = new System.Drawing.Point(4, 34);
            tabPage16.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage16.Name = "tabPage16";
            tabPage16.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage16.Size = new System.Drawing.Size(480, 884);
            tabPage16.TabIndex = 0;
            tabPage16.Text = "Main";
            tabPage16.UseVisualStyleBackColor = true;
            // 
            // label393
            // 
            label393.AutoSize = true;
            label393.Location = new System.Drawing.Point(236, 611);
            label393.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label393.Name = "label393";
            label393.Size = new System.Drawing.Size(133, 25);
            label393.TabIndex = 35;
            label393.Text = "Direct2D rotate";
            // 
            // cbDirect2DRotate
            // 
            cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDirect2DRotate.FormattingEnabled = true;
            cbDirect2DRotate.Items.AddRange(new object[] { "0", "90", "180", "270" });
            cbDirect2DRotate.Location = new System.Drawing.Point(240, 642);
            cbDirect2DRotate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDirect2DRotate.Name = "cbDirect2DRotate";
            cbDirect2DRotate.Size = new System.Drawing.Size(202, 33);
            cbDirect2DRotate.TabIndex = 34;
            cbDirect2DRotate.SelectedIndexChanged += cbDirect2DRotate_SelectedIndexChanged;
            // 
            // pnVideoRendererBGColor
            // 
            pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black;
            pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnVideoRendererBGColor.Location = new System.Drawing.Point(200, 420);
            pnVideoRendererBGColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnVideoRendererBGColor.Name = "pnVideoRendererBGColor";
            pnVideoRendererBGColor.Size = new System.Drawing.Size(40, 44);
            pnVideoRendererBGColor.TabIndex = 33;
            pnVideoRendererBGColor.Click += pnVideoRendererBGColor_Click;
            // 
            // label394
            // 
            label394.AutoSize = true;
            label394.Location = new System.Drawing.Point(22, 431);
            label394.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label394.Name = "label394";
            label394.Size = new System.Drawing.Size(152, 25);
            label394.TabIndex = 32;
            label394.Text = "Background color";
            // 
            // btFullScreen
            // 
            btFullScreen.Location = new System.Drawing.Point(240, 694);
            btFullScreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFullScreen.Name = "btFullScreen";
            btFullScreen.Size = new System.Drawing.Size(202, 44);
            btFullScreen.TabIndex = 31;
            btFullScreen.Text = "Full screen";
            btFullScreen.UseVisualStyleBackColor = true;
            btFullScreen.Click += btFullScreen_Click;
            // 
            // groupBox28
            // 
            groupBox28.Controls.Add(btZoomReset);
            groupBox28.Controls.Add(btZoomShiftRight);
            groupBox28.Controls.Add(btZoomShiftLeft);
            groupBox28.Controls.Add(btZoomOut);
            groupBox28.Controls.Add(btZoomIn);
            groupBox28.Controls.Add(btZoomShiftDown);
            groupBox28.Controls.Add(btZoomShiftUp);
            groupBox28.Location = new System.Drawing.Point(28, 611);
            groupBox28.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox28.Name = "groupBox28";
            groupBox28.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox28.Size = new System.Drawing.Size(198, 250);
            groupBox28.TabIndex = 30;
            groupBox28.TabStop = false;
            groupBox28.Text = "Zoom";
            // 
            // btZoomReset
            // 
            btZoomReset.Location = new System.Drawing.Point(58, 194);
            btZoomReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomReset.Name = "btZoomReset";
            btZoomReset.Size = new System.Drawing.Size(82, 44);
            btZoomReset.TabIndex = 6;
            btZoomReset.Text = "Reset";
            btZoomReset.UseVisualStyleBackColor = true;
            btZoomReset.Click += btZoomReset_Click;
            // 
            // btZoomShiftRight
            // 
            btZoomShiftRight.Location = new System.Drawing.Point(142, 64);
            btZoomShiftRight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomShiftRight.Name = "btZoomShiftRight";
            btZoomShiftRight.Size = new System.Drawing.Size(36, 92);
            btZoomShiftRight.TabIndex = 5;
            btZoomShiftRight.Text = "R";
            btZoomShiftRight.UseVisualStyleBackColor = true;
            btZoomShiftRight.Click += btZoomShiftRight_Click;
            // 
            // btZoomShiftLeft
            // 
            btZoomShiftLeft.Location = new System.Drawing.Point(22, 61);
            btZoomShiftLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomShiftLeft.Name = "btZoomShiftLeft";
            btZoomShiftLeft.Size = new System.Drawing.Size(36, 92);
            btZoomShiftLeft.TabIndex = 4;
            btZoomShiftLeft.Text = "L";
            btZoomShiftLeft.UseVisualStyleBackColor = true;
            btZoomShiftLeft.Click += btZoomShiftLeft_Click;
            // 
            // btZoomOut
            // 
            btZoomOut.Location = new System.Drawing.Point(102, 86);
            btZoomOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomOut.Name = "btZoomOut";
            btZoomOut.Size = new System.Drawing.Size(38, 44);
            btZoomOut.TabIndex = 3;
            btZoomOut.Text = "-";
            btZoomOut.UseVisualStyleBackColor = true;
            btZoomOut.Click += btZoomOut_Click;
            // 
            // btZoomIn
            // 
            btZoomIn.Location = new System.Drawing.Point(58, 86);
            btZoomIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomIn.Name = "btZoomIn";
            btZoomIn.Size = new System.Drawing.Size(38, 44);
            btZoomIn.TabIndex = 2;
            btZoomIn.Text = "+";
            btZoomIn.UseVisualStyleBackColor = true;
            btZoomIn.Click += btZoomIn_Click;
            // 
            // btZoomShiftDown
            // 
            btZoomShiftDown.Location = new System.Drawing.Point(58, 134);
            btZoomShiftDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomShiftDown.Name = "btZoomShiftDown";
            btZoomShiftDown.Size = new System.Drawing.Size(84, 44);
            btZoomShiftDown.TabIndex = 1;
            btZoomShiftDown.Text = "Down";
            btZoomShiftDown.UseVisualStyleBackColor = true;
            btZoomShiftDown.Click += btZoomShiftDown_Click;
            // 
            // btZoomShiftUp
            // 
            btZoomShiftUp.Location = new System.Drawing.Point(58, 39);
            btZoomShiftUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btZoomShiftUp.Name = "btZoomShiftUp";
            btZoomShiftUp.Size = new System.Drawing.Size(84, 44);
            btZoomShiftUp.TabIndex = 0;
            btZoomShiftUp.Text = "Up";
            btZoomShiftUp.UseVisualStyleBackColor = true;
            btZoomShiftUp.Click += btZoomShiftUp_Click;
            // 
            // cbScreenFlipVertical
            // 
            cbScreenFlipVertical.AutoSize = true;
            cbScreenFlipVertical.Location = new System.Drawing.Point(292, 469);
            cbScreenFlipVertical.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbScreenFlipVertical.Name = "cbScreenFlipVertical";
            cbScreenFlipVertical.Size = new System.Drawing.Size(126, 29);
            cbScreenFlipVertical.TabIndex = 29;
            cbScreenFlipVertical.Text = "Flip vertical";
            cbScreenFlipVertical.UseVisualStyleBackColor = true;
            cbScreenFlipVertical.CheckedChanged += cbScreenFlipVertical_CheckedChanged;
            // 
            // cbScreenFlipHorizontal
            // 
            cbScreenFlipHorizontal.AutoSize = true;
            cbScreenFlipHorizontal.Location = new System.Drawing.Point(292, 422);
            cbScreenFlipHorizontal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal";
            cbScreenFlipHorizontal.Size = new System.Drawing.Size(150, 29);
            cbScreenFlipHorizontal.TabIndex = 28;
            cbScreenFlipHorizontal.Text = "Flip horizontal";
            cbScreenFlipHorizontal.UseVisualStyleBackColor = true;
            cbScreenFlipHorizontal.CheckedChanged += cbScreenFlipHorizontal_CheckedChanged;
            // 
            // cbStretch
            // 
            cbStretch.AutoSize = true;
            cbStretch.Location = new System.Drawing.Point(292, 516);
            cbStretch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbStretch.Name = "cbStretch";
            cbStretch.Size = new System.Drawing.Size(141, 29);
            cbStretch.TabIndex = 27;
            cbStretch.Text = "Stretch video";
            cbStretch.UseVisualStyleBackColor = true;
            cbStretch.CheckedChanged += cbStretch_CheckedChanged;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(rbMadVR);
            groupBox13.Controls.Add(rbDirect2D);
            groupBox13.Controls.Add(rbNone);
            groupBox13.Controls.Add(rbEVR);
            groupBox13.Controls.Add(rbVMR9);
            groupBox13.Location = new System.Drawing.Point(28, 11);
            groupBox13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox13.Size = new System.Drawing.Size(418, 369);
            groupBox13.TabIndex = 26;
            groupBox13.TabStop = false;
            groupBox13.Text = "Video Renderer";
            // 
            // rbMadVR
            // 
            rbMadVR.AutoSize = true;
            rbMadVR.Location = new System.Drawing.Point(22, 181);
            rbMadVR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbMadVR.Name = "rbMadVR";
            rbMadVR.Size = new System.Drawing.Size(176, 29);
            rbMadVR.TabIndex = 5;
            rbMadVR.Text = "madVR (optional)";
            rbMadVR.UseVisualStyleBackColor = true;
            // 
            // rbDirect2D
            // 
            rbDirect2D.AutoSize = true;
            rbDirect2D.Location = new System.Drawing.Point(22, 136);
            rbDirect2D.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDirect2D.Name = "rbDirect2D";
            rbDirect2D.Size = new System.Drawing.Size(106, 29);
            rbDirect2D.TabIndex = 4;
            rbDirect2D.Text = "Direct2D";
            rbDirect2D.UseVisualStyleBackColor = true;
            rbDirect2D.CheckedChanged += rbVR_CheckedChanged;
            // 
            // rbNone
            // 
            rbNone.AutoSize = true;
            rbNone.Location = new System.Drawing.Point(22, 225);
            rbNone.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNone.Name = "rbNone";
            rbNone.Size = new System.Drawing.Size(80, 29);
            rbNone.TabIndex = 3;
            rbNone.Text = "None";
            rbNone.UseVisualStyleBackColor = true;
            rbNone.CheckedChanged += rbVR_CheckedChanged;
            // 
            // rbEVR
            // 
            rbEVR.AutoSize = true;
            rbEVR.Checked = true;
            rbEVR.Location = new System.Drawing.Point(22, 92);
            rbEVR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEVR.Name = "rbEVR";
            rbEVR.Size = new System.Drawing.Size(309, 29);
            rbEVR.TabIndex = 2;
            rbEVR.TabStop = true;
            rbEVR.Text = "Enhanced Video Renderer (default)";
            rbEVR.UseVisualStyleBackColor = true;
            rbEVR.CheckedChanged += rbVR_CheckedChanged;
            // 
            // rbVMR9
            // 
            rbVMR9.AutoSize = true;
            rbVMR9.Location = new System.Drawing.Point(22, 48);
            rbVMR9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVMR9.Name = "rbVMR9";
            rbVMR9.Size = new System.Drawing.Size(231, 29);
            rbVMR9.TabIndex = 1;
            rbVMR9.Text = "Video Mixing Renderer 9";
            rbVMR9.UseVisualStyleBackColor = true;
            rbVMR9.CheckedChanged += rbVR_CheckedChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(112, 566);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(20, 25);
            label15.TabIndex = 25;
            label15.Text = "x";
            // 
            // edAspectRatioY
            // 
            edAspectRatioY.Location = new System.Drawing.Point(138, 559);
            edAspectRatioY.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAspectRatioY.Name = "edAspectRatioY";
            edAspectRatioY.Size = new System.Drawing.Size(46, 31);
            edAspectRatioY.TabIndex = 24;
            edAspectRatioY.Text = "9";
            // 
            // edAspectRatioX
            // 
            edAspectRatioX.Location = new System.Drawing.Point(56, 559);
            edAspectRatioX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAspectRatioX.Name = "edAspectRatioX";
            edAspectRatioX.Size = new System.Drawing.Size(46, 31);
            edAspectRatioX.TabIndex = 23;
            edAspectRatioX.Text = "16";
            // 
            // cbAspectRatioUseCustom
            // 
            cbAspectRatioUseCustom.AutoSize = true;
            cbAspectRatioUseCustom.Location = new System.Drawing.Point(28, 516);
            cbAspectRatioUseCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAspectRatioUseCustom.Name = "cbAspectRatioUseCustom";
            cbAspectRatioUseCustom.Size = new System.Drawing.Size(228, 29);
            cbAspectRatioUseCustom.TabIndex = 22;
            cbAspectRatioUseCustom.Text = "Use custom aspect ratio";
            cbAspectRatioUseCustom.UseVisualStyleBackColor = true;
            cbAspectRatioUseCustom.CheckedChanged += cbAspectRatioUseCustom_CheckedChanged;
            // 
            // tabPage17
            // 
            tabPage17.Controls.Add(cbMultiscreenDrawOnExternalDisplays);
            tabPage17.Controls.Add(cbMultiscreenDrawOnPanels);
            tabPage17.Controls.Add(cbFlipHorizontal2);
            tabPage17.Controls.Add(cbFlipVertical2);
            tabPage17.Controls.Add(cbStretch2);
            tabPage17.Controls.Add(cbFlipHorizontal1);
            tabPage17.Controls.Add(cbFlipVertical1);
            tabPage17.Controls.Add(cbStretch1);
            tabPage17.Controls.Add(pnScreen2);
            tabPage17.Controls.Add(pnScreen1);
            tabPage17.Location = new System.Drawing.Point(4, 34);
            tabPage17.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage17.Name = "tabPage17";
            tabPage17.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage17.Size = new System.Drawing.Size(480, 884);
            tabPage17.TabIndex = 1;
            tabPage17.Text = "Multiscreen";
            tabPage17.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnExternalDisplays
            // 
            cbMultiscreenDrawOnExternalDisplays.AutoSize = true;
            cbMultiscreenDrawOnExternalDisplays.Location = new System.Drawing.Point(18, 66);
            cbMultiscreenDrawOnExternalDisplays.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMultiscreenDrawOnExternalDisplays.Name = "cbMultiscreenDrawOnExternalDisplays";
            cbMultiscreenDrawOnExternalDisplays.Size = new System.Drawing.Size(289, 29);
            cbMultiscreenDrawOnExternalDisplays.TabIndex = 23;
            cbMultiscreenDrawOnExternalDisplays.Text = "Draw video on external displays";
            cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnPanels
            // 
            cbMultiscreenDrawOnPanels.AutoSize = true;
            cbMultiscreenDrawOnPanels.Location = new System.Drawing.Point(18, 20);
            cbMultiscreenDrawOnPanels.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMultiscreenDrawOnPanels.Name = "cbMultiscreenDrawOnPanels";
            cbMultiscreenDrawOnPanels.Size = new System.Drawing.Size(210, 29);
            cbMultiscreenDrawOnPanels.TabIndex = 22;
            cbMultiscreenDrawOnPanels.Text = "Draw video on panels";
            cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = true;
            // 
            // cbFlipHorizontal2
            // 
            cbFlipHorizontal2.AutoSize = true;
            cbFlipHorizontal2.Location = new System.Drawing.Point(270, 830);
            cbFlipHorizontal2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipHorizontal2.Name = "cbFlipHorizontal2";
            cbFlipHorizontal2.Size = new System.Drawing.Size(150, 29);
            cbFlipHorizontal2.TabIndex = 21;
            cbFlipHorizontal2.Text = "Flip horizontal";
            cbFlipHorizontal2.UseVisualStyleBackColor = true;
            cbFlipHorizontal2.CheckedChanged += cbFlipStretch2_CheckedChanged;
            // 
            // cbFlipVertical2
            // 
            cbFlipVertical2.AutoSize = true;
            cbFlipVertical2.Location = new System.Drawing.Point(128, 830);
            cbFlipVertical2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipVertical2.Name = "cbFlipVertical2";
            cbFlipVertical2.Size = new System.Drawing.Size(126, 29);
            cbFlipVertical2.TabIndex = 20;
            cbFlipVertical2.Text = "Flip vertical";
            cbFlipVertical2.UseVisualStyleBackColor = true;
            cbFlipVertical2.CheckedChanged += cbFlipStretch2_CheckedChanged;
            // 
            // cbStretch2
            // 
            cbStretch2.AutoSize = true;
            cbStretch2.Location = new System.Drawing.Point(18, 830);
            cbStretch2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbStretch2.Name = "cbStretch2";
            cbStretch2.Size = new System.Drawing.Size(92, 29);
            cbStretch2.TabIndex = 19;
            cbStretch2.Text = "Stretch";
            cbStretch2.UseVisualStyleBackColor = true;
            cbStretch2.CheckedChanged += cbFlipStretch2_CheckedChanged;
            // 
            // cbFlipHorizontal1
            // 
            cbFlipHorizontal1.AutoSize = true;
            cbFlipHorizontal1.Location = new System.Drawing.Point(270, 375);
            cbFlipHorizontal1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipHorizontal1.Name = "cbFlipHorizontal1";
            cbFlipHorizontal1.Size = new System.Drawing.Size(150, 29);
            cbFlipHorizontal1.TabIndex = 18;
            cbFlipHorizontal1.Text = "Flip horizontal";
            cbFlipHorizontal1.UseVisualStyleBackColor = true;
            cbFlipHorizontal1.CheckedChanged += cbFlipStretch1_CheckedChanged;
            // 
            // cbFlipVertical1
            // 
            cbFlipVertical1.AutoSize = true;
            cbFlipVertical1.Location = new System.Drawing.Point(128, 375);
            cbFlipVertical1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipVertical1.Name = "cbFlipVertical1";
            cbFlipVertical1.Size = new System.Drawing.Size(126, 29);
            cbFlipVertical1.TabIndex = 17;
            cbFlipVertical1.Text = "Flip vertical";
            cbFlipVertical1.UseVisualStyleBackColor = true;
            cbFlipVertical1.CheckedChanged += cbFlipStretch1_CheckedChanged;
            // 
            // cbStretch1
            // 
            cbStretch1.AutoSize = true;
            cbStretch1.Location = new System.Drawing.Point(18, 375);
            cbStretch1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbStretch1.Name = "cbStretch1";
            cbStretch1.Size = new System.Drawing.Size(92, 29);
            cbStretch1.TabIndex = 16;
            cbStretch1.Text = "Stretch";
            cbStretch1.UseVisualStyleBackColor = true;
            cbStretch1.CheckedChanged += cbFlipStretch1_CheckedChanged;
            // 
            // pnScreen2
            // 
            pnScreen2.BackColor = System.Drawing.Color.Black;
            pnScreen2.Location = new System.Drawing.Point(18, 419);
            pnScreen2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnScreen2.Name = "pnScreen2";
            pnScreen2.Size = new System.Drawing.Size(409, 392);
            pnScreen2.TabIndex = 15;
            // 
            // pnScreen1
            // 
            pnScreen1.BackColor = System.Drawing.Color.Black;
            pnScreen1.Location = new System.Drawing.Point(78, 120);
            pnScreen1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnScreen1.Name = "pnScreen1";
            pnScreen1.Size = new System.Drawing.Size(290, 242);
            pnScreen1.TabIndex = 13;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tabControl17);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Size = new System.Drawing.Size(508, 957);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Video processing";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            tabControl17.Controls.Add(tabPage68);
            tabControl17.Controls.Add(tabPage69);
            tabControl17.Controls.Add(tabPage59);
            tabControl17.Controls.Add(tabPage51);
            tabControl17.Controls.Add(tabPage8);
            tabControl17.Controls.Add(tabPage15);
            tabControl17.Controls.Add(tabPage46);
            tabControl17.Location = new System.Drawing.Point(0, 11);
            tabControl17.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl17.Name = "tabControl17";
            tabControl17.SelectedIndex = 0;
            tabControl17.Size = new System.Drawing.Size(498, 931);
            tabControl17.TabIndex = 37;
            // 
            // tabPage68
            // 
            tabPage68.Controls.Add(cbScrollingText);
            tabPage68.Controls.Add(cbFlipY);
            tabPage68.Controls.Add(cbFlipX);
            tabPage68.Controls.Add(label201);
            tabPage68.Controls.Add(label200);
            tabPage68.Controls.Add(label199);
            tabPage68.Controls.Add(label198);
            tabPage68.Controls.Add(tabControl7);
            tabPage68.Controls.Add(tbContrast);
            tabPage68.Controls.Add(tbDarkness);
            tabPage68.Controls.Add(tbLightness);
            tabPage68.Controls.Add(tbSaturation);
            tabPage68.Controls.Add(cbInvert);
            tabPage68.Controls.Add(cbGreyscale);
            tabPage68.Controls.Add(cbVideoEffects);
            tabPage68.Location = new System.Drawing.Point(4, 34);
            tabPage68.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage68.Name = "tabPage68";
            tabPage68.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage68.Size = new System.Drawing.Size(490, 893);
            tabPage68.TabIndex = 0;
            tabPage68.Text = "Effects";
            tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbScrollingText
            // 
            cbScrollingText.AutoSize = true;
            cbScrollingText.Location = new System.Drawing.Point(21, 319);
            cbScrollingText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbScrollingText.Name = "cbScrollingText";
            cbScrollingText.Size = new System.Drawing.Size(202, 29);
            cbScrollingText.TabIndex = 89;
            cbScrollingText.Text = "Sample scrolling text";
            cbScrollingText.UseVisualStyleBackColor = true;
            cbScrollingText.CheckedChanged += cbScrollingText_CheckedChanged;
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(355, 288);
            cbFlipY.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipY.Name = "cbFlipY";
            cbFlipY.Size = new System.Drawing.Size(81, 29);
            cbFlipY.TabIndex = 69;
            cbFlipY.Text = "Flip Y";
            cbFlipY.UseVisualStyleBackColor = true;
            cbFlipY.CheckedChanged += cbFlipY_CheckedChanged;
            // 
            // cbFlipX
            // 
            cbFlipX.AutoSize = true;
            cbFlipX.Location = new System.Drawing.Point(255, 288);
            cbFlipX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipX.Name = "cbFlipX";
            cbFlipX.Size = new System.Drawing.Size(82, 29);
            cbFlipX.TabIndex = 68;
            cbFlipX.Text = "Flip X";
            cbFlipX.UseVisualStyleBackColor = true;
            cbFlipX.CheckedChanged += cbFlipX_CheckedChanged;
            // 
            // label201
            // 
            label201.AutoSize = true;
            label201.Location = new System.Drawing.Point(238, 169);
            label201.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label201.Name = "label201";
            label201.Size = new System.Drawing.Size(84, 25);
            label201.TabIndex = 63;
            label201.Text = "Darkness";
            // 
            // label200
            // 
            label200.AutoSize = true;
            label200.Location = new System.Drawing.Point(10, 169);
            label200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label200.Name = "label200";
            label200.Size = new System.Drawing.Size(79, 25);
            label200.TabIndex = 62;
            label200.Text = "Contrast";
            // 
            // label199
            // 
            label199.AutoSize = true;
            label199.Location = new System.Drawing.Point(238, 69);
            label199.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label199.Name = "label199";
            label199.Size = new System.Drawing.Size(93, 25);
            label199.TabIndex = 61;
            label199.Text = "Saturation";
            // 
            // label198
            // 
            label198.AutoSize = true;
            label198.Location = new System.Drawing.Point(10, 69);
            label198.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label198.Name = "label198";
            label198.Size = new System.Drawing.Size(86, 25);
            label198.TabIndex = 60;
            label198.Text = "Lightness";
            // 
            // tabControl7
            // 
            tabControl7.Controls.Add(tabPage29);
            tabControl7.Controls.Add(tabPage42);
            tabControl7.Controls.Add(tabPage18);
            tabControl7.Controls.Add(tabPage19);
            tabControl7.Controls.Add(tabPage22);
            tabControl7.Controls.Add(tabPage43);
            tabControl7.Location = new System.Drawing.Point(4, 356);
            tabControl7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl7.Name = "tabControl7";
            tabControl7.SelectedIndex = 0;
            tabControl7.Size = new System.Drawing.Size(471, 528);
            tabControl7.TabIndex = 59;
            // 
            // tabPage29
            // 
            tabPage29.Controls.Add(btTextLogoRemove);
            tabPage29.Controls.Add(btTextLogoEdit);
            tabPage29.Controls.Add(lbTextLogos);
            tabPage29.Controls.Add(btTextLogoAdd);
            tabPage29.Location = new System.Drawing.Point(4, 34);
            tabPage29.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage29.Name = "tabPage29";
            tabPage29.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage29.Size = new System.Drawing.Size(463, 490);
            tabPage29.TabIndex = 0;
            tabPage29.Text = "Text logo";
            tabPage29.UseVisualStyleBackColor = true;
            // 
            // btTextLogoRemove
            // 
            btTextLogoRemove.Location = new System.Drawing.Point(342, 414);
            btTextLogoRemove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btTextLogoRemove.Name = "btTextLogoRemove";
            btTextLogoRemove.Size = new System.Drawing.Size(98, 44);
            btTextLogoRemove.TabIndex = 7;
            btTextLogoRemove.Text = "Remove";
            btTextLogoRemove.UseVisualStyleBackColor = true;
            btTextLogoRemove.Click += btTextLogoRemove_Click;
            // 
            // btTextLogoEdit
            // 
            btTextLogoEdit.Location = new System.Drawing.Point(122, 414);
            btTextLogoEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btTextLogoEdit.Name = "btTextLogoEdit";
            btTextLogoEdit.Size = new System.Drawing.Size(98, 44);
            btTextLogoEdit.TabIndex = 6;
            btTextLogoEdit.Text = "Edit";
            btTextLogoEdit.UseVisualStyleBackColor = true;
            btTextLogoEdit.Click += btTextLogoEdit_Click;
            // 
            // lbTextLogos
            // 
            lbTextLogos.FormattingEnabled = true;
            lbTextLogos.ItemHeight = 25;
            lbTextLogos.Location = new System.Drawing.Point(18, 22);
            lbTextLogos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbTextLogos.Name = "lbTextLogos";
            lbTextLogos.Size = new System.Drawing.Size(426, 379);
            lbTextLogos.TabIndex = 5;
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(12, 414);
            btTextLogoAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btTextLogoAdd.Name = "btTextLogoAdd";
            btTextLogoAdd.Size = new System.Drawing.Size(98, 44);
            btTextLogoAdd.TabIndex = 4;
            btTextLogoAdd.Text = "Add";
            btTextLogoAdd.UseVisualStyleBackColor = true;
            btTextLogoAdd.Click += btTextLogoAdd_Click;
            // 
            // tabPage42
            // 
            tabPage42.Controls.Add(btImageLogoRemove);
            tabPage42.Controls.Add(btImageLogoEdit);
            tabPage42.Controls.Add(lbImageLogos);
            tabPage42.Controls.Add(btImageLogoAdd);
            tabPage42.Location = new System.Drawing.Point(4, 34);
            tabPage42.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage42.Name = "tabPage42";
            tabPage42.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage42.Size = new System.Drawing.Size(463, 490);
            tabPage42.TabIndex = 1;
            tabPage42.Text = "Image logo";
            tabPage42.UseVisualStyleBackColor = true;
            // 
            // btImageLogoRemove
            // 
            btImageLogoRemove.Location = new System.Drawing.Point(342, 414);
            btImageLogoRemove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btImageLogoRemove.Name = "btImageLogoRemove";
            btImageLogoRemove.Size = new System.Drawing.Size(98, 44);
            btImageLogoRemove.TabIndex = 11;
            btImageLogoRemove.Text = "Remove";
            btImageLogoRemove.UseVisualStyleBackColor = true;
            btImageLogoRemove.Click += btImageLogoRemove_Click;
            // 
            // btImageLogoEdit
            // 
            btImageLogoEdit.Location = new System.Drawing.Point(122, 414);
            btImageLogoEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btImageLogoEdit.Name = "btImageLogoEdit";
            btImageLogoEdit.Size = new System.Drawing.Size(98, 44);
            btImageLogoEdit.TabIndex = 10;
            btImageLogoEdit.Text = "Edit";
            btImageLogoEdit.UseVisualStyleBackColor = true;
            btImageLogoEdit.Click += btImageLogoEdit_Click;
            // 
            // lbImageLogos
            // 
            lbImageLogos.FormattingEnabled = true;
            lbImageLogos.ItemHeight = 25;
            lbImageLogos.Location = new System.Drawing.Point(18, 22);
            lbImageLogos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbImageLogos.Name = "lbImageLogos";
            lbImageLogos.Size = new System.Drawing.Size(426, 379);
            lbImageLogos.TabIndex = 9;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(12, 414);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(98, 44);
            btImageLogoAdd.TabIndex = 8;
            btImageLogoAdd.Text = "Add";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += btImageLogoAdd_Click;
            // 
            // tabPage18
            // 
            tabPage18.Controls.Add(groupBox37);
            tabPage18.Controls.Add(cbZoom);
            tabPage18.Location = new System.Drawing.Point(4, 34);
            tabPage18.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage18.Name = "tabPage18";
            tabPage18.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage18.Size = new System.Drawing.Size(463, 490);
            tabPage18.TabIndex = 2;
            tabPage18.Text = "Zoom";
            tabPage18.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            groupBox37.Controls.Add(btEffZoomRight);
            groupBox37.Controls.Add(btEffZoomLeft);
            groupBox37.Controls.Add(btEffZoomOut);
            groupBox37.Controls.Add(btEffZoomIn);
            groupBox37.Controls.Add(btEffZoomDown);
            groupBox37.Controls.Add(btEffZoomUp);
            groupBox37.Location = new System.Drawing.Point(142, 98);
            groupBox37.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox37.Name = "groupBox37";
            groupBox37.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox37.Size = new System.Drawing.Size(198, 200);
            groupBox37.TabIndex = 18;
            groupBox37.TabStop = false;
            groupBox37.Text = "Zoom";
            // 
            // btEffZoomRight
            // 
            btEffZoomRight.Location = new System.Drawing.Point(142, 64);
            btEffZoomRight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomRight.Name = "btEffZoomRight";
            btEffZoomRight.Size = new System.Drawing.Size(36, 92);
            btEffZoomRight.TabIndex = 5;
            btEffZoomRight.Text = "R";
            btEffZoomRight.UseVisualStyleBackColor = true;
            btEffZoomRight.Click += btEffZoomRight_Click;
            // 
            // btEffZoomLeft
            // 
            btEffZoomLeft.Location = new System.Drawing.Point(22, 61);
            btEffZoomLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomLeft.Name = "btEffZoomLeft";
            btEffZoomLeft.Size = new System.Drawing.Size(36, 92);
            btEffZoomLeft.TabIndex = 4;
            btEffZoomLeft.Text = "L";
            btEffZoomLeft.UseVisualStyleBackColor = true;
            btEffZoomLeft.Click += btEffZoomLeft_Click;
            // 
            // btEffZoomOut
            // 
            btEffZoomOut.Location = new System.Drawing.Point(102, 86);
            btEffZoomOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomOut.Name = "btEffZoomOut";
            btEffZoomOut.Size = new System.Drawing.Size(38, 44);
            btEffZoomOut.TabIndex = 3;
            btEffZoomOut.Text = "-";
            btEffZoomOut.UseVisualStyleBackColor = true;
            btEffZoomOut.Click += btEffZoomOut_Click;
            // 
            // btEffZoomIn
            // 
            btEffZoomIn.Location = new System.Drawing.Point(58, 86);
            btEffZoomIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomIn.Name = "btEffZoomIn";
            btEffZoomIn.Size = new System.Drawing.Size(38, 44);
            btEffZoomIn.TabIndex = 2;
            btEffZoomIn.Text = "+";
            btEffZoomIn.UseVisualStyleBackColor = true;
            btEffZoomIn.Click += btEffZoomIn_Click;
            // 
            // btEffZoomDown
            // 
            btEffZoomDown.Location = new System.Drawing.Point(58, 131);
            btEffZoomDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomDown.Name = "btEffZoomDown";
            btEffZoomDown.Size = new System.Drawing.Size(84, 44);
            btEffZoomDown.TabIndex = 1;
            btEffZoomDown.Text = "Down";
            btEffZoomDown.UseVisualStyleBackColor = true;
            btEffZoomDown.Click += btEffZoomDown_Click;
            // 
            // btEffZoomUp
            // 
            btEffZoomUp.Location = new System.Drawing.Point(58, 39);
            btEffZoomUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEffZoomUp.Name = "btEffZoomUp";
            btEffZoomUp.Size = new System.Drawing.Size(84, 44);
            btEffZoomUp.TabIndex = 0;
            btEffZoomUp.Text = "Up";
            btEffZoomUp.UseVisualStyleBackColor = true;
            btEffZoomUp.Click += btEffZoomUp_Click;
            // 
            // cbZoom
            // 
            cbZoom.AutoSize = true;
            cbZoom.Location = new System.Drawing.Point(20, 30);
            cbZoom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbZoom.Name = "cbZoom";
            cbZoom.Size = new System.Drawing.Size(101, 29);
            cbZoom.TabIndex = 17;
            cbZoom.Text = "Enabled";
            cbZoom.UseVisualStyleBackColor = true;
            cbZoom.CheckedChanged += cbZoom_CheckedChanged;
            // 
            // tabPage19
            // 
            tabPage19.Controls.Add(groupBox40);
            tabPage19.Controls.Add(groupBox39);
            tabPage19.Controls.Add(groupBox38);
            tabPage19.Controls.Add(cbPan);
            tabPage19.Location = new System.Drawing.Point(4, 34);
            tabPage19.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage19.Name = "tabPage19";
            tabPage19.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage19.Size = new System.Drawing.Size(463, 490);
            tabPage19.TabIndex = 3;
            tabPage19.Text = "Pan";
            tabPage19.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            groupBox40.Controls.Add(edPanDestHeight);
            groupBox40.Controls.Add(label302);
            groupBox40.Controls.Add(edPanDestWidth);
            groupBox40.Controls.Add(label303);
            groupBox40.Controls.Add(edPanDestTop);
            groupBox40.Controls.Add(label304);
            groupBox40.Controls.Add(edPanDestLeft);
            groupBox40.Controls.Add(label305);
            groupBox40.Location = new System.Drawing.Point(20, 311);
            groupBox40.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            groupBox40.Name = "groupBox40";
            groupBox40.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            groupBox40.Size = new System.Drawing.Size(280, 148);
            groupBox40.TabIndex = 58;
            groupBox40.TabStop = false;
            groupBox40.Text = "Destination rect";
            // 
            // edPanDestHeight
            // 
            edPanDestHeight.Location = new System.Drawing.Point(204, 98);
            edPanDestHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanDestHeight.Name = "edPanDestHeight";
            edPanDestHeight.Size = new System.Drawing.Size(53, 31);
            edPanDestHeight.TabIndex = 17;
            edPanDestHeight.Text = "240";
            // 
            // label302
            // 
            label302.AutoSize = true;
            label302.Location = new System.Drawing.Point(136, 105);
            label302.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label302.Name = "label302";
            label302.Size = new System.Drawing.Size(65, 25);
            label302.TabIndex = 16;
            label302.Text = "Height";
            // 
            // edPanDestWidth
            // 
            edPanDestWidth.Location = new System.Drawing.Point(204, 48);
            edPanDestWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanDestWidth.Name = "edPanDestWidth";
            edPanDestWidth.Size = new System.Drawing.Size(53, 31);
            edPanDestWidth.TabIndex = 15;
            edPanDestWidth.Text = "320";
            // 
            // label303
            // 
            label303.AutoSize = true;
            label303.Location = new System.Drawing.Point(136, 55);
            label303.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label303.Name = "label303";
            label303.Size = new System.Drawing.Size(60, 25);
            label303.TabIndex = 14;
            label303.Text = "Width";
            // 
            // edPanDestTop
            // 
            edPanDestTop.Location = new System.Drawing.Point(71, 100);
            edPanDestTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanDestTop.Name = "edPanDestTop";
            edPanDestTop.Size = new System.Drawing.Size(53, 31);
            edPanDestTop.TabIndex = 12;
            edPanDestTop.Text = "0";
            // 
            // label304
            // 
            label304.AutoSize = true;
            label304.Location = new System.Drawing.Point(22, 105);
            label304.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label304.Name = "label304";
            label304.Size = new System.Drawing.Size(41, 25);
            label304.TabIndex = 11;
            label304.Text = "Top";
            // 
            // edPanDestLeft
            // 
            edPanDestLeft.Location = new System.Drawing.Point(71, 50);
            edPanDestLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanDestLeft.Name = "edPanDestLeft";
            edPanDestLeft.Size = new System.Drawing.Size(53, 31);
            edPanDestLeft.TabIndex = 10;
            edPanDestLeft.Text = "0";
            // 
            // label305
            // 
            label305.AutoSize = true;
            label305.Location = new System.Drawing.Point(22, 55);
            label305.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label305.Name = "label305";
            label305.Size = new System.Drawing.Size(41, 25);
            label305.TabIndex = 9;
            label305.Text = "Left";
            // 
            // groupBox39
            // 
            groupBox39.Controls.Add(edPanSourceHeight);
            groupBox39.Controls.Add(label298);
            groupBox39.Controls.Add(edPanSourceWidth);
            groupBox39.Controls.Add(label299);
            groupBox39.Controls.Add(edPanSourceTop);
            groupBox39.Controls.Add(label300);
            groupBox39.Controls.Add(edPanSourceLeft);
            groupBox39.Controls.Add(label301);
            groupBox39.Location = new System.Drawing.Point(20, 155);
            groupBox39.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            groupBox39.Name = "groupBox39";
            groupBox39.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            groupBox39.Size = new System.Drawing.Size(280, 148);
            groupBox39.TabIndex = 57;
            groupBox39.TabStop = false;
            groupBox39.Text = "Source rect";
            // 
            // edPanSourceHeight
            // 
            edPanSourceHeight.Location = new System.Drawing.Point(204, 98);
            edPanSourceHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanSourceHeight.Name = "edPanSourceHeight";
            edPanSourceHeight.Size = new System.Drawing.Size(53, 31);
            edPanSourceHeight.TabIndex = 17;
            edPanSourceHeight.Text = "480";
            // 
            // label298
            // 
            label298.AutoSize = true;
            label298.Location = new System.Drawing.Point(136, 105);
            label298.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label298.Name = "label298";
            label298.Size = new System.Drawing.Size(65, 25);
            label298.TabIndex = 16;
            label298.Text = "Height";
            // 
            // edPanSourceWidth
            // 
            edPanSourceWidth.Location = new System.Drawing.Point(204, 48);
            edPanSourceWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanSourceWidth.Name = "edPanSourceWidth";
            edPanSourceWidth.Size = new System.Drawing.Size(53, 31);
            edPanSourceWidth.TabIndex = 15;
            edPanSourceWidth.Text = "640";
            // 
            // label299
            // 
            label299.AutoSize = true;
            label299.Location = new System.Drawing.Point(136, 55);
            label299.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label299.Name = "label299";
            label299.Size = new System.Drawing.Size(60, 25);
            label299.TabIndex = 14;
            label299.Text = "Width";
            // 
            // edPanSourceTop
            // 
            edPanSourceTop.Location = new System.Drawing.Point(71, 100);
            edPanSourceTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanSourceTop.Name = "edPanSourceTop";
            edPanSourceTop.Size = new System.Drawing.Size(53, 31);
            edPanSourceTop.TabIndex = 12;
            edPanSourceTop.Text = "0";
            // 
            // label300
            // 
            label300.AutoSize = true;
            label300.Location = new System.Drawing.Point(22, 105);
            label300.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label300.Name = "label300";
            label300.Size = new System.Drawing.Size(41, 25);
            label300.TabIndex = 11;
            label300.Text = "Top";
            // 
            // edPanSourceLeft
            // 
            edPanSourceLeft.Location = new System.Drawing.Point(71, 50);
            edPanSourceLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanSourceLeft.Name = "edPanSourceLeft";
            edPanSourceLeft.Size = new System.Drawing.Size(53, 31);
            edPanSourceLeft.TabIndex = 10;
            edPanSourceLeft.Text = "0";
            // 
            // label301
            // 
            label301.AutoSize = true;
            label301.Location = new System.Drawing.Point(22, 55);
            label301.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label301.Name = "label301";
            label301.Size = new System.Drawing.Size(41, 25);
            label301.TabIndex = 9;
            label301.Text = "Left";
            // 
            // groupBox38
            // 
            groupBox38.Controls.Add(edPanStopTime);
            groupBox38.Controls.Add(label296);
            groupBox38.Controls.Add(edPanStartTime);
            groupBox38.Controls.Add(label297);
            groupBox38.Location = new System.Drawing.Point(20, 56);
            groupBox38.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox38.Name = "groupBox38";
            groupBox38.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox38.Size = new System.Drawing.Size(280, 89);
            groupBox38.TabIndex = 56;
            groupBox38.TabStop = false;
            groupBox38.Text = "Duration";
            // 
            // edPanStopTime
            // 
            edPanStopTime.Location = new System.Drawing.Point(196, 36);
            edPanStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanStopTime.Name = "edPanStopTime";
            edPanStopTime.Size = new System.Drawing.Size(62, 31);
            edPanStopTime.TabIndex = 34;
            edPanStopTime.Text = "15000";
            edPanStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label296
            // 
            label296.AutoSize = true;
            label296.Location = new System.Drawing.Point(148, 42);
            label296.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label296.Name = "label296";
            label296.Size = new System.Drawing.Size(49, 25);
            label296.TabIndex = 33;
            label296.Text = "Stop";
            // 
            // edPanStartTime
            // 
            edPanStartTime.Location = new System.Drawing.Point(71, 36);
            edPanStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPanStartTime.Name = "edPanStartTime";
            edPanStartTime.Size = new System.Drawing.Size(62, 31);
            edPanStartTime.TabIndex = 32;
            edPanStartTime.Text = "5000";
            edPanStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label297
            // 
            label297.AutoSize = true;
            label297.Location = new System.Drawing.Point(18, 42);
            label297.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label297.Name = "label297";
            label297.Size = new System.Drawing.Size(48, 25);
            label297.TabIndex = 31;
            label297.Text = "Start";
            // 
            // cbPan
            // 
            cbPan.AutoSize = true;
            cbPan.Location = new System.Drawing.Point(20, 11);
            cbPan.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbPan.Name = "cbPan";
            cbPan.Size = new System.Drawing.Size(101, 29);
            cbPan.TabIndex = 55;
            cbPan.Text = "Enabled";
            cbPan.UseVisualStyleBackColor = true;
            cbPan.CheckedChanged += cbPan_CheckedChanged;
            // 
            // tabPage22
            // 
            tabPage22.Controls.Add(rbFadeOut);
            tabPage22.Controls.Add(rbFadeIn);
            tabPage22.Controls.Add(groupBox45);
            tabPage22.Controls.Add(cbFadeInOut);
            tabPage22.Location = new System.Drawing.Point(4, 34);
            tabPage22.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage22.Name = "tabPage22";
            tabPage22.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage22.Size = new System.Drawing.Size(463, 490);
            tabPage22.TabIndex = 4;
            tabPage22.Text = "Fade-in/out";
            tabPage22.UseVisualStyleBackColor = true;
            // 
            // rbFadeOut
            // 
            rbFadeOut.AutoSize = true;
            rbFadeOut.Location = new System.Drawing.Point(169, 198);
            rbFadeOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbFadeOut.Name = "rbFadeOut";
            rbFadeOut.Size = new System.Drawing.Size(108, 29);
            rbFadeOut.TabIndex = 60;
            rbFadeOut.TabStop = true;
            rbFadeOut.Text = "Fade-out";
            rbFadeOut.UseVisualStyleBackColor = true;
            // 
            // rbFadeIn
            // 
            rbFadeIn.AutoSize = true;
            rbFadeIn.Checked = true;
            rbFadeIn.Location = new System.Drawing.Point(18, 198);
            rbFadeIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbFadeIn.Name = "rbFadeIn";
            rbFadeIn.Size = new System.Drawing.Size(95, 29);
            rbFadeIn.TabIndex = 59;
            rbFadeIn.TabStop = true;
            rbFadeIn.Text = "Fade-in";
            rbFadeIn.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            groupBox45.Controls.Add(edFadeInOutStopTime);
            groupBox45.Controls.Add(label329);
            groupBox45.Controls.Add(edFadeInOutStartTime);
            groupBox45.Controls.Add(label330);
            groupBox45.Location = new System.Drawing.Point(18, 98);
            groupBox45.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox45.Name = "groupBox45";
            groupBox45.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox45.Size = new System.Drawing.Size(280, 89);
            groupBox45.TabIndex = 58;
            groupBox45.TabStop = false;
            groupBox45.Text = "Duration";
            // 
            // edFadeInOutStopTime
            // 
            edFadeInOutStopTime.Location = new System.Drawing.Point(196, 36);
            edFadeInOutStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeInOutStopTime.Name = "edFadeInOutStopTime";
            edFadeInOutStopTime.Size = new System.Drawing.Size(62, 31);
            edFadeInOutStopTime.TabIndex = 34;
            edFadeInOutStopTime.Text = "15000";
            edFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label329
            // 
            label329.AutoSize = true;
            label329.Location = new System.Drawing.Point(148, 42);
            label329.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label329.Name = "label329";
            label329.Size = new System.Drawing.Size(49, 25);
            label329.TabIndex = 33;
            label329.Text = "Stop";
            // 
            // edFadeInOutStartTime
            // 
            edFadeInOutStartTime.Location = new System.Drawing.Point(71, 36);
            edFadeInOutStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeInOutStartTime.Name = "edFadeInOutStartTime";
            edFadeInOutStartTime.Size = new System.Drawing.Size(62, 31);
            edFadeInOutStartTime.TabIndex = 32;
            edFadeInOutStartTime.Text = "5000";
            edFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label330
            // 
            label330.AutoSize = true;
            label330.Location = new System.Drawing.Point(18, 42);
            label330.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label330.Name = "label330";
            label330.Size = new System.Drawing.Size(48, 25);
            label330.TabIndex = 31;
            label330.Text = "Start";
            // 
            // cbFadeInOut
            // 
            cbFadeInOut.AutoSize = true;
            cbFadeInOut.Location = new System.Drawing.Point(18, 31);
            cbFadeInOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFadeInOut.Name = "cbFadeInOut";
            cbFadeInOut.Size = new System.Drawing.Size(101, 29);
            cbFadeInOut.TabIndex = 57;
            cbFadeInOut.Text = "Enabled";
            cbFadeInOut.UseVisualStyleBackColor = true;
            cbFadeInOut.CheckedChanged += cbFadeInOut_CheckedChanged;
            // 
            // tabPage43
            // 
            tabPage43.Controls.Add(cbLiveRotationStretch);
            tabPage43.Controls.Add(label392);
            tabPage43.Controls.Add(label391);
            tabPage43.Controls.Add(tbLiveRotationAngle);
            tabPage43.Controls.Add(label390);
            tabPage43.Controls.Add(cbLiveRotation);
            tabPage43.Location = new System.Drawing.Point(4, 34);
            tabPage43.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage43.Name = "tabPage43";
            tabPage43.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage43.Size = new System.Drawing.Size(463, 490);
            tabPage43.TabIndex = 5;
            tabPage43.Text = "Live rotation";
            tabPage43.UseVisualStyleBackColor = true;
            // 
            // cbLiveRotationStretch
            // 
            cbLiveRotationStretch.AutoSize = true;
            cbLiveRotationStretch.Location = new System.Drawing.Point(20, 264);
            cbLiveRotationStretch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbLiveRotationStretch.Name = "cbLiveRotationStretch";
            cbLiveRotationStretch.Size = new System.Drawing.Size(259, 29);
            cbLiveRotationStretch.TabIndex = 65;
            cbLiveRotationStretch.Text = "Stretch  if angle is 90 or 270";
            cbLiveRotationStretch.UseVisualStyleBackColor = true;
            cbLiveRotationStretch.CheckedChanged += cbLiveRotationStretch_CheckedChanged;
            // 
            // label392
            // 
            label392.AutoSize = true;
            label392.Location = new System.Drawing.Point(218, 214);
            label392.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label392.Name = "label392";
            label392.Size = new System.Drawing.Size(42, 25);
            label392.TabIndex = 64;
            label392.Text = "360";
            // 
            // label391
            // 
            label391.AutoSize = true;
            label391.Location = new System.Drawing.Point(16, 214);
            label391.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label391.Name = "label391";
            label391.Size = new System.Drawing.Size(22, 25);
            label391.TabIndex = 63;
            label391.Text = "0";
            // 
            // tbLiveRotationAngle
            // 
            tbLiveRotationAngle.Location = new System.Drawing.Point(20, 120);
            tbLiveRotationAngle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbLiveRotationAngle.Maximum = 360;
            tbLiveRotationAngle.Name = "tbLiveRotationAngle";
            tbLiveRotationAngle.Size = new System.Drawing.Size(238, 69);
            tbLiveRotationAngle.TabIndex = 62;
            tbLiveRotationAngle.TickFrequency = 5;
            tbLiveRotationAngle.Value = 90;
            tbLiveRotationAngle.Scroll += tbLiveRotationAngle_Scroll;
            // 
            // label390
            // 
            label390.AutoSize = true;
            label390.Location = new System.Drawing.Point(16, 84);
            label390.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label390.Name = "label390";
            label390.Size = new System.Drawing.Size(58, 25);
            label390.TabIndex = 61;
            label390.Text = "Angle";
            // 
            // cbLiveRotation
            // 
            cbLiveRotation.AutoSize = true;
            cbLiveRotation.Location = new System.Drawing.Point(20, 22);
            cbLiveRotation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbLiveRotation.Name = "cbLiveRotation";
            cbLiveRotation.Size = new System.Drawing.Size(101, 29);
            cbLiveRotation.TabIndex = 60;
            cbLiveRotation.Text = "Enabled";
            cbLiveRotation.UseVisualStyleBackColor = true;
            cbLiveRotation.CheckedChanged += cbLiveRotation_CheckedChanged;
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(4, 206);
            tbContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(218, 69);
            tbContrast.TabIndex = 49;
            tbContrast.Scroll += tbContrast_Scroll;
            // 
            // tbDarkness
            // 
            tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbDarkness.Location = new System.Drawing.Point(238, 206);
            tbDarkness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbDarkness.Maximum = 255;
            tbDarkness.Name = "tbDarkness";
            tbDarkness.Size = new System.Drawing.Size(218, 69);
            tbDarkness.TabIndex = 46;
            tbDarkness.Scroll += tbDarkness_Scroll;
            // 
            // tbLightness
            // 
            tbLightness.BackColor = System.Drawing.SystemColors.Window;
            tbLightness.Location = new System.Drawing.Point(4, 98);
            tbLightness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbLightness.Maximum = 255;
            tbLightness.Name = "tbLightness";
            tbLightness.Size = new System.Drawing.Size(218, 69);
            tbLightness.TabIndex = 45;
            tbLightness.Scroll += tbLightness_Scroll;
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(238, 98);
            tbSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(218, 69);
            tbSaturation.TabIndex = 43;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += tbSaturation_Scroll;
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(155, 288);
            cbInvert.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbInvert.Name = "cbInvert";
            cbInvert.Size = new System.Drawing.Size(83, 29);
            cbInvert.TabIndex = 41;
            cbInvert.Text = "Invert";
            cbInvert.UseVisualStyleBackColor = true;
            cbInvert.CheckedChanged += cbInvert_CheckedChanged;
            // 
            // cbGreyscale
            // 
            cbGreyscale.AutoSize = true;
            cbGreyscale.Location = new System.Drawing.Point(21, 288);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 39;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += cbGreyscale_CheckedChanged;
            // 
            // cbVideoEffects
            // 
            cbVideoEffects.AutoSize = true;
            cbVideoEffects.Location = new System.Drawing.Point(12, 16);
            cbVideoEffects.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoEffects.Name = "cbVideoEffects";
            cbVideoEffects.Size = new System.Drawing.Size(101, 29);
            cbVideoEffects.TabIndex = 37;
            cbVideoEffects.Text = "Enabled";
            cbVideoEffects.UseVisualStyleBackColor = true;
            // 
            // tabPage69
            // 
            tabPage69.Controls.Add(label211);
            tabPage69.Controls.Add(edDeintTriangleWeight);
            tabPage69.Controls.Add(label212);
            tabPage69.Controls.Add(label210);
            tabPage69.Controls.Add(label209);
            tabPage69.Controls.Add(label206);
            tabPage69.Controls.Add(edDeintBlendConstants2);
            tabPage69.Controls.Add(label207);
            tabPage69.Controls.Add(edDeintBlendConstants1);
            tabPage69.Controls.Add(label208);
            tabPage69.Controls.Add(label204);
            tabPage69.Controls.Add(edDeintBlendThreshold2);
            tabPage69.Controls.Add(label205);
            tabPage69.Controls.Add(edDeintBlendThreshold1);
            tabPage69.Controls.Add(label203);
            tabPage69.Controls.Add(label202);
            tabPage69.Controls.Add(edDeintCAVTThreshold);
            tabPage69.Controls.Add(label104);
            tabPage69.Controls.Add(rbDeintTriangleEnabled);
            tabPage69.Controls.Add(rbDeintBlendEnabled);
            tabPage69.Controls.Add(rbDeintCAVTEnabled);
            tabPage69.Controls.Add(cbDeinterlace);
            tabPage69.Location = new System.Drawing.Point(4, 34);
            tabPage69.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage69.Name = "tabPage69";
            tabPage69.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage69.Size = new System.Drawing.Size(490, 893);
            tabPage69.TabIndex = 1;
            tabPage69.Text = "Deinterlace";
            tabPage69.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            label211.AutoSize = true;
            label211.Location = new System.Drawing.Point(168, 566);
            label211.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label211.Name = "label211";
            label211.Size = new System.Drawing.Size(69, 25);
            label211.TabIndex = 28;
            label211.Text = "[0-255]";
            // 
            // edDeintTriangleWeight
            // 
            edDeintTriangleWeight.Location = new System.Drawing.Point(171, 519);
            edDeintTriangleWeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintTriangleWeight.Name = "edDeintTriangleWeight";
            edDeintTriangleWeight.Size = new System.Drawing.Size(52, 31);
            edDeintTriangleWeight.TabIndex = 27;
            edDeintTriangleWeight.Text = "180";
            // 
            // label212
            // 
            label212.AutoSize = true;
            label212.Location = new System.Drawing.Point(58, 525);
            label212.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label212.Name = "label212";
            label212.Size = new System.Drawing.Size(68, 25);
            label212.TabIndex = 26;
            label212.Text = "Weight";
            // 
            // label210
            // 
            label210.AutoSize = true;
            label210.Location = new System.Drawing.Point(429, 369);
            label210.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label210.Name = "label210";
            label210.Size = new System.Drawing.Size(44, 25);
            label210.TabIndex = 25;
            label210.Text = "/ 10";
            // 
            // label209
            // 
            label209.AutoSize = true;
            label209.Location = new System.Drawing.Point(429, 306);
            label209.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label209.Name = "label209";
            label209.Size = new System.Drawing.Size(44, 25);
            label209.TabIndex = 24;
            label209.Text = "/ 10";
            // 
            // label206
            // 
            label206.AutoSize = true;
            label206.Location = new System.Drawing.Point(362, 409);
            label206.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label206.Name = "label206";
            label206.Size = new System.Drawing.Size(77, 25);
            label206.TabIndex = 23;
            label206.Text = "[0.0-1.0]";
            // 
            // edDeintBlendConstants2
            // 
            edDeintBlendConstants2.Location = new System.Drawing.Point(369, 364);
            edDeintBlendConstants2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintBlendConstants2.Name = "edDeintBlendConstants2";
            edDeintBlendConstants2.Size = new System.Drawing.Size(52, 31);
            edDeintBlendConstants2.TabIndex = 22;
            edDeintBlendConstants2.Text = "9";
            // 
            // label207
            // 
            label207.AutoSize = true;
            label207.Location = new System.Drawing.Point(252, 369);
            label207.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label207.Name = "label207";
            label207.Size = new System.Drawing.Size(106, 25);
            label207.TabIndex = 21;
            label207.Text = "Constants 2";
            // 
            // edDeintBlendConstants1
            // 
            edDeintBlendConstants1.Location = new System.Drawing.Point(369, 300);
            edDeintBlendConstants1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintBlendConstants1.Name = "edDeintBlendConstants1";
            edDeintBlendConstants1.Size = new System.Drawing.Size(52, 31);
            edDeintBlendConstants1.TabIndex = 20;
            edDeintBlendConstants1.Text = "3";
            // 
            // label208
            // 
            label208.AutoSize = true;
            label208.Location = new System.Drawing.Point(252, 306);
            label208.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label208.Name = "label208";
            label208.Size = new System.Drawing.Size(106, 25);
            label208.TabIndex = 19;
            label208.Text = "Constants 1";
            // 
            // label204
            // 
            label204.AutoSize = true;
            label204.Location = new System.Drawing.Point(168, 409);
            label204.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label204.Name = "label204";
            label204.Size = new System.Drawing.Size(69, 25);
            label204.TabIndex = 18;
            label204.Text = "[0-255]";
            // 
            // edDeintBlendThreshold2
            // 
            edDeintBlendThreshold2.Location = new System.Drawing.Point(171, 364);
            edDeintBlendThreshold2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintBlendThreshold2.Name = "edDeintBlendThreshold2";
            edDeintBlendThreshold2.Size = new System.Drawing.Size(52, 31);
            edDeintBlendThreshold2.TabIndex = 17;
            edDeintBlendThreshold2.Text = "9";
            // 
            // label205
            // 
            label205.AutoSize = true;
            label205.Location = new System.Drawing.Point(58, 369);
            label205.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label205.Name = "label205";
            label205.Size = new System.Drawing.Size(105, 25);
            label205.TabIndex = 16;
            label205.Text = "Threshold 2";
            // 
            // edDeintBlendThreshold1
            // 
            edDeintBlendThreshold1.Location = new System.Drawing.Point(171, 300);
            edDeintBlendThreshold1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintBlendThreshold1.Name = "edDeintBlendThreshold1";
            edDeintBlendThreshold1.Size = new System.Drawing.Size(52, 31);
            edDeintBlendThreshold1.TabIndex = 15;
            edDeintBlendThreshold1.Text = "5";
            // 
            // label203
            // 
            label203.AutoSize = true;
            label203.Location = new System.Drawing.Point(58, 306);
            label203.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label203.Name = "label203";
            label203.Size = new System.Drawing.Size(105, 25);
            label203.TabIndex = 14;
            label203.Text = "Threshold 1";
            // 
            // label202
            // 
            label202.AutoSize = true;
            label202.Location = new System.Drawing.Point(168, 198);
            label202.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label202.Name = "label202";
            label202.Size = new System.Drawing.Size(69, 25);
            label202.TabIndex = 13;
            label202.Text = "[0-255]";
            // 
            // edDeintCAVTThreshold
            // 
            edDeintCAVTThreshold.Location = new System.Drawing.Point(171, 152);
            edDeintCAVTThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edDeintCAVTThreshold.Name = "edDeintCAVTThreshold";
            edDeintCAVTThreshold.Size = new System.Drawing.Size(52, 31);
            edDeintCAVTThreshold.TabIndex = 12;
            edDeintCAVTThreshold.Text = "20";
            // 
            // label104
            // 
            label104.AutoSize = true;
            label104.Location = new System.Drawing.Point(58, 158);
            label104.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label104.Name = "label104";
            label104.Size = new System.Drawing.Size(90, 25);
            label104.TabIndex = 11;
            label104.Text = "Threshold";
            // 
            // rbDeintTriangleEnabled
            // 
            rbDeintTriangleEnabled.AutoSize = true;
            rbDeintTriangleEnabled.Location = new System.Drawing.Point(30, 469);
            rbDeintTriangleEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled";
            rbDeintTriangleEnabled.Size = new System.Drawing.Size(97, 29);
            rbDeintTriangleEnabled.TabIndex = 10;
            rbDeintTriangleEnabled.Text = "Triangle";
            rbDeintTriangleEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintBlendEnabled
            // 
            rbDeintBlendEnabled.AutoSize = true;
            rbDeintBlendEnabled.Location = new System.Drawing.Point(30, 244);
            rbDeintBlendEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDeintBlendEnabled.Name = "rbDeintBlendEnabled";
            rbDeintBlendEnabled.Size = new System.Drawing.Size(81, 29);
            rbDeintBlendEnabled.TabIndex = 9;
            rbDeintBlendEnabled.Text = "Blend";
            rbDeintBlendEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintCAVTEnabled
            // 
            rbDeintCAVTEnabled.AutoSize = true;
            rbDeintCAVTEnabled.Checked = true;
            rbDeintCAVTEnabled.Location = new System.Drawing.Point(30, 100);
            rbDeintCAVTEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDeintCAVTEnabled.Name = "rbDeintCAVTEnabled";
            rbDeintCAVTEnabled.Size = new System.Drawing.Size(372, 29);
            rbDeintCAVTEnabled.TabIndex = 8;
            rbDeintCAVTEnabled.TabStop = true;
            rbDeintCAVTEnabled.Text = "Content Adaptive Vertical Temporal (CAVT)";
            rbDeintCAVTEnabled.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlace
            // 
            cbDeinterlace.AutoSize = true;
            cbDeinterlace.Location = new System.Drawing.Point(30, 31);
            cbDeinterlace.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDeinterlace.Name = "cbDeinterlace";
            cbDeinterlace.Size = new System.Drawing.Size(101, 29);
            cbDeinterlace.TabIndex = 7;
            cbDeinterlace.Text = "Enabled";
            cbDeinterlace.UseVisualStyleBackColor = true;
            // 
            // tabPage59
            // 
            tabPage59.Controls.Add(rbDenoiseCAST);
            tabPage59.Controls.Add(rbDenoiseMosquito);
            tabPage59.Controls.Add(cbDenoise);
            tabPage59.Location = new System.Drawing.Point(4, 34);
            tabPage59.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage59.Name = "tabPage59";
            tabPage59.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage59.Size = new System.Drawing.Size(490, 893);
            tabPage59.TabIndex = 4;
            tabPage59.Text = "Denoise";
            tabPage59.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseCAST
            // 
            rbDenoiseCAST.AutoSize = true;
            rbDenoiseCAST.Location = new System.Drawing.Point(30, 152);
            rbDenoiseCAST.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDenoiseCAST.Name = "rbDenoiseCAST";
            rbDenoiseCAST.Size = new System.Drawing.Size(369, 29);
            rbDenoiseCAST.TabIndex = 10;
            rbDenoiseCAST.Text = "Content Adaptive Spatio-Temporal (CAST)";
            rbDenoiseCAST.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseMosquito
            // 
            rbDenoiseMosquito.AutoSize = true;
            rbDenoiseMosquito.Checked = true;
            rbDenoiseMosquito.Location = new System.Drawing.Point(30, 100);
            rbDenoiseMosquito.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbDenoiseMosquito.Name = "rbDenoiseMosquito";
            rbDenoiseMosquito.Size = new System.Drawing.Size(114, 29);
            rbDenoiseMosquito.TabIndex = 9;
            rbDenoiseMosquito.TabStop = true;
            rbDenoiseMosquito.Text = "Mosquito";
            rbDenoiseMosquito.UseVisualStyleBackColor = true;
            // 
            // cbDenoise
            // 
            cbDenoise.AutoSize = true;
            cbDenoise.Location = new System.Drawing.Point(30, 31);
            cbDenoise.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDenoise.Name = "cbDenoise";
            cbDenoise.Size = new System.Drawing.Size(101, 29);
            cbDenoise.TabIndex = 8;
            cbDenoise.Text = "Enabled";
            cbDenoise.UseVisualStyleBackColor = true;
            // 
            // tabPage51
            // 
            tabPage51.Controls.Add(label22);
            tabPage51.Controls.Add(tbGPUBlur);
            tabPage51.Controls.Add(cbVideoEffectsGPUEnabled);
            tabPage51.Controls.Add(cbGPUOldMovie);
            tabPage51.Controls.Add(cbGPUDeinterlace);
            tabPage51.Controls.Add(cbGPUDenoise);
            tabPage51.Controls.Add(cbGPUPixelate);
            tabPage51.Controls.Add(cbGPUNightVision);
            tabPage51.Controls.Add(label383);
            tabPage51.Controls.Add(label384);
            tabPage51.Controls.Add(label385);
            tabPage51.Controls.Add(label386);
            tabPage51.Controls.Add(tbGPUContrast);
            tabPage51.Controls.Add(tbGPUDarkness);
            tabPage51.Controls.Add(tbGPULightness);
            tabPage51.Controls.Add(tbGPUSaturation);
            tabPage51.Controls.Add(cbGPUInvert);
            tabPage51.Controls.Add(cbGPUGreyscale);
            tabPage51.Location = new System.Drawing.Point(4, 34);
            tabPage51.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage51.Name = "tabPage51";
            tabPage51.Size = new System.Drawing.Size(490, 893);
            tabPage51.TabIndex = 9;
            tabPage51.Text = "Effects (GPU)";
            tabPage51.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(18, 519);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(42, 25);
            label22.TabIndex = 100;
            label22.Text = "Blur";
            // 
            // tbGPUBlur
            // 
            tbGPUBlur.BackColor = System.Drawing.SystemColors.Window;
            tbGPUBlur.Location = new System.Drawing.Point(11, 548);
            tbGPUBlur.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUBlur.Maximum = 30;
            tbGPUBlur.Name = "tbGPUBlur";
            tbGPUBlur.Size = new System.Drawing.Size(218, 69);
            tbGPUBlur.TabIndex = 99;
            tbGPUBlur.Scroll += tbGPUBlur_Scroll;
            // 
            // cbVideoEffectsGPUEnabled
            // 
            cbVideoEffectsGPUEnabled.AutoSize = true;
            cbVideoEffectsGPUEnabled.Location = new System.Drawing.Point(30, 31);
            cbVideoEffectsGPUEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled";
            cbVideoEffectsGPUEnabled.Size = new System.Drawing.Size(101, 29);
            cbVideoEffectsGPUEnabled.TabIndex = 97;
            cbVideoEffectsGPUEnabled.Text = "Enabled";
            cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = true;
            // 
            // cbGPUOldMovie
            // 
            cbGPUOldMovie.AutoSize = true;
            cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUOldMovie.Location = new System.Drawing.Point(236, 461);
            cbGPUOldMovie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUOldMovie.Name = "cbGPUOldMovie";
            cbGPUOldMovie.Size = new System.Drawing.Size(121, 29);
            cbGPUOldMovie.TabIndex = 96;
            cbGPUOldMovie.Text = "Old movie";
            cbGPUOldMovie.UseVisualStyleBackColor = true;
            cbGPUOldMovie.CheckedChanged += cbGPUOldMovie_CheckedChanged;
            // 
            // cbGPUDeinterlace
            // 
            cbGPUDeinterlace.AutoSize = true;
            cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUDeinterlace.Location = new System.Drawing.Point(236, 416);
            cbGPUDeinterlace.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUDeinterlace.Name = "cbGPUDeinterlace";
            cbGPUDeinterlace.Size = new System.Drawing.Size(125, 29);
            cbGPUDeinterlace.TabIndex = 94;
            cbGPUDeinterlace.Text = "Deinterlace";
            cbGPUDeinterlace.UseVisualStyleBackColor = true;
            cbGPUDeinterlace.CheckedChanged += cbGPUDeinterlace_CheckedChanged;
            // 
            // cbGPUDenoise
            // 
            cbGPUDenoise.AutoSize = true;
            cbGPUDenoise.Location = new System.Drawing.Point(22, 416);
            cbGPUDenoise.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUDenoise.Name = "cbGPUDenoise";
            cbGPUDenoise.Size = new System.Drawing.Size(102, 29);
            cbGPUDenoise.TabIndex = 93;
            cbGPUDenoise.Text = "Denoise";
            cbGPUDenoise.UseVisualStyleBackColor = true;
            cbGPUDenoise.CheckedChanged += cbGPUDenoise_CheckedChanged;
            // 
            // cbGPUPixelate
            // 
            cbGPUPixelate.AutoSize = true;
            cbGPUPixelate.Location = new System.Drawing.Point(236, 370);
            cbGPUPixelate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUPixelate.Name = "cbGPUPixelate";
            cbGPUPixelate.Size = new System.Drawing.Size(97, 29);
            cbGPUPixelate.TabIndex = 92;
            cbGPUPixelate.Text = "Pixelate";
            cbGPUPixelate.UseVisualStyleBackColor = true;
            cbGPUPixelate.CheckedChanged += cbGPUPixelate_CheckedChanged;
            // 
            // cbGPUNightVision
            // 
            cbGPUNightVision.AutoSize = true;
            cbGPUNightVision.Location = new System.Drawing.Point(22, 370);
            cbGPUNightVision.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUNightVision.Name = "cbGPUNightVision";
            cbGPUNightVision.Size = new System.Drawing.Size(133, 29);
            cbGPUNightVision.TabIndex = 91;
            cbGPUNightVision.Text = "Night vision";
            cbGPUNightVision.UseVisualStyleBackColor = true;
            cbGPUNightVision.CheckedChanged += cbGPUNightVision_CheckedChanged;
            // 
            // label383
            // 
            label383.AutoSize = true;
            label383.Location = new System.Drawing.Point(242, 192);
            label383.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label383.Name = "label383";
            label383.Size = new System.Drawing.Size(84, 25);
            label383.TabIndex = 90;
            label383.Text = "Darkness";
            // 
            // label384
            // 
            label384.AutoSize = true;
            label384.Location = new System.Drawing.Point(18, 192);
            label384.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label384.Name = "label384";
            label384.Size = new System.Drawing.Size(79, 25);
            label384.TabIndex = 89;
            label384.Text = "Contrast";
            // 
            // label385
            // 
            label385.AutoSize = true;
            label385.Location = new System.Drawing.Point(242, 92);
            label385.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label385.Name = "label385";
            label385.Size = new System.Drawing.Size(93, 25);
            label385.TabIndex = 88;
            label385.Text = "Saturation";
            // 
            // label386
            // 
            label386.AutoSize = true;
            label386.Location = new System.Drawing.Point(18, 92);
            label386.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label386.Name = "label386";
            label386.Size = new System.Drawing.Size(86, 25);
            label386.TabIndex = 87;
            label386.Text = "Lightness";
            // 
            // tbGPUContrast
            // 
            tbGPUContrast.BackColor = System.Drawing.SystemColors.Window;
            tbGPUContrast.Location = new System.Drawing.Point(11, 230);
            tbGPUContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUContrast.Maximum = 255;
            tbGPUContrast.Name = "tbGPUContrast";
            tbGPUContrast.Size = new System.Drawing.Size(218, 69);
            tbGPUContrast.TabIndex = 86;
            tbGPUContrast.Value = 255;
            tbGPUContrast.Scroll += tbGPUContrast_Scroll;
            // 
            // tbGPUDarkness
            // 
            tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbGPUDarkness.Location = new System.Drawing.Point(242, 230);
            tbGPUDarkness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUDarkness.Maximum = 255;
            tbGPUDarkness.Name = "tbGPUDarkness";
            tbGPUDarkness.Size = new System.Drawing.Size(218, 69);
            tbGPUDarkness.TabIndex = 85;
            tbGPUDarkness.Scroll += tbGPUDarkness_Scroll;
            // 
            // tbGPULightness
            // 
            tbGPULightness.BackColor = System.Drawing.SystemColors.Window;
            tbGPULightness.Location = new System.Drawing.Point(11, 120);
            tbGPULightness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPULightness.Maximum = 255;
            tbGPULightness.Name = "tbGPULightness";
            tbGPULightness.Size = new System.Drawing.Size(218, 69);
            tbGPULightness.TabIndex = 84;
            tbGPULightness.Scroll += tbGPULightness_Scroll;
            // 
            // tbGPUSaturation
            // 
            tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbGPUSaturation.Location = new System.Drawing.Point(242, 120);
            tbGPUSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUSaturation.Maximum = 255;
            tbGPUSaturation.Name = "tbGPUSaturation";
            tbGPUSaturation.Size = new System.Drawing.Size(218, 69);
            tbGPUSaturation.TabIndex = 83;
            tbGPUSaturation.Value = 255;
            tbGPUSaturation.Scroll += tbGPUSaturation_Scroll;
            // 
            // cbGPUInvert
            // 
            cbGPUInvert.AutoSize = true;
            cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUInvert.Location = new System.Drawing.Point(236, 328);
            cbGPUInvert.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUInvert.Name = "cbGPUInvert";
            cbGPUInvert.Size = new System.Drawing.Size(83, 29);
            cbGPUInvert.TabIndex = 82;
            cbGPUInvert.Text = "Invert";
            cbGPUInvert.UseVisualStyleBackColor = true;
            cbGPUInvert.CheckedChanged += cbGPUInvert_CheckedChanged;
            // 
            // cbGPUGreyscale
            // 
            cbGPUGreyscale.AutoSize = true;
            cbGPUGreyscale.Location = new System.Drawing.Point(22, 328);
            cbGPUGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUGreyscale.Name = "cbGPUGreyscale";
            cbGPUGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGPUGreyscale.TabIndex = 81;
            cbGPUGreyscale.Text = "Greyscale";
            cbGPUGreyscale.UseVisualStyleBackColor = true;
            cbGPUGreyscale.CheckedChanged += cbGPUGreyscale_CheckedChanged;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(lbAdjSaturationCurrent);
            tabPage8.Controls.Add(lbAdjSaturationMax);
            tabPage8.Controls.Add(lbAdjSaturationMin);
            tabPage8.Controls.Add(tbAdjSaturation);
            tabPage8.Controls.Add(label45);
            tabPage8.Controls.Add(lbAdjHueCurrent);
            tabPage8.Controls.Add(lbAdjHueMax);
            tabPage8.Controls.Add(lbAdjHueMin);
            tabPage8.Controls.Add(tbAdjHue);
            tabPage8.Controls.Add(label41);
            tabPage8.Controls.Add(lbAdjContrastCurrent);
            tabPage8.Controls.Add(lbAdjContrastMax);
            tabPage8.Controls.Add(lbAdjContrastMin);
            tabPage8.Controls.Add(tbAdjContrast);
            tabPage8.Controls.Add(label23);
            tabPage8.Controls.Add(lbAdjBrightnessCurrent);
            tabPage8.Controls.Add(lbAdjBrightnessMax);
            tabPage8.Controls.Add(lbAdjBrightnessMin);
            tabPage8.Controls.Add(tbAdjBrightness);
            tabPage8.Controls.Add(label24);
            tabPage8.Location = new System.Drawing.Point(4, 34);
            tabPage8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage8.Size = new System.Drawing.Size(490, 893);
            tabPage8.TabIndex = 5;
            tabPage8.Text = "Effects (Video renderer)";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // lbAdjSaturationCurrent
            // 
            lbAdjSaturationCurrent.AutoSize = true;
            lbAdjSaturationCurrent.Location = new System.Drawing.Point(218, 511);
            lbAdjSaturationCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationCurrent.Name = "lbAdjSaturationCurrent";
            lbAdjSaturationCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjSaturationCurrent.TabIndex = 48;
            lbAdjSaturationCurrent.Text = "Current = 40";
            // 
            // lbAdjSaturationMax
            // 
            lbAdjSaturationMax.AutoSize = true;
            lbAdjSaturationMax.Location = new System.Drawing.Point(111, 511);
            lbAdjSaturationMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationMax.Name = "lbAdjSaturationMax";
            lbAdjSaturationMax.Size = new System.Drawing.Size(97, 25);
            lbAdjSaturationMax.TabIndex = 47;
            lbAdjSaturationMax.Text = "Max = 100";
            // 
            // lbAdjSaturationMin
            // 
            lbAdjSaturationMin.AutoSize = true;
            lbAdjSaturationMin.Location = new System.Drawing.Point(31, 511);
            lbAdjSaturationMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationMin.Name = "lbAdjSaturationMin";
            lbAdjSaturationMin.Size = new System.Drawing.Size(74, 25);
            lbAdjSaturationMin.TabIndex = 45;
            lbAdjSaturationMin.Text = "Min = 1";
            // 
            // tbAdjSaturation
            // 
            tbAdjSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbAdjSaturation.Location = new System.Drawing.Point(22, 456);
            tbAdjSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAdjSaturation.Maximum = 100;
            tbAdjSaturation.Name = "tbAdjSaturation";
            tbAdjSaturation.Size = new System.Drawing.Size(318, 69);
            tbAdjSaturation.TabIndex = 44;
            tbAdjSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjSaturation.Value = 50;
            tbAdjSaturation.Scroll += tbAdjSaturation_Scroll;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(18, 425);
            label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(93, 25);
            label45.TabIndex = 43;
            label45.Text = "Saturation";
            // 
            // lbAdjHueCurrent
            // 
            lbAdjHueCurrent.AutoSize = true;
            lbAdjHueCurrent.Location = new System.Drawing.Point(218, 381);
            lbAdjHueCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueCurrent.Name = "lbAdjHueCurrent";
            lbAdjHueCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjHueCurrent.TabIndex = 42;
            lbAdjHueCurrent.Text = "Current = 40";
            // 
            // lbAdjHueMax
            // 
            lbAdjHueMax.AutoSize = true;
            lbAdjHueMax.Location = new System.Drawing.Point(111, 381);
            lbAdjHueMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueMax.Name = "lbAdjHueMax";
            lbAdjHueMax.Size = new System.Drawing.Size(97, 25);
            lbAdjHueMax.TabIndex = 41;
            lbAdjHueMax.Text = "Max = 100";
            // 
            // lbAdjHueMin
            // 
            lbAdjHueMin.AutoSize = true;
            lbAdjHueMin.Location = new System.Drawing.Point(31, 381);
            lbAdjHueMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueMin.Name = "lbAdjHueMin";
            lbAdjHueMin.Size = new System.Drawing.Size(74, 25);
            lbAdjHueMin.TabIndex = 39;
            lbAdjHueMin.Text = "Min = 1";
            // 
            // tbAdjHue
            // 
            tbAdjHue.BackColor = System.Drawing.SystemColors.Window;
            tbAdjHue.Location = new System.Drawing.Point(22, 325);
            tbAdjHue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAdjHue.Maximum = 100;
            tbAdjHue.Name = "tbAdjHue";
            tbAdjHue.Size = new System.Drawing.Size(318, 69);
            tbAdjHue.TabIndex = 38;
            tbAdjHue.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjHue.Value = 50;
            tbAdjHue.Scroll += tbAdjHue_Scroll;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new System.Drawing.Point(18, 294);
            label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(44, 25);
            label41.TabIndex = 37;
            label41.Text = "Hue";
            // 
            // lbAdjContrastCurrent
            // 
            lbAdjContrastCurrent.AutoSize = true;
            lbAdjContrastCurrent.Location = new System.Drawing.Point(218, 245);
            lbAdjContrastCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastCurrent.Name = "lbAdjContrastCurrent";
            lbAdjContrastCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjContrastCurrent.TabIndex = 36;
            lbAdjContrastCurrent.Text = "Current = 40";
            // 
            // lbAdjContrastMax
            // 
            lbAdjContrastMax.AutoSize = true;
            lbAdjContrastMax.Location = new System.Drawing.Point(111, 245);
            lbAdjContrastMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastMax.Name = "lbAdjContrastMax";
            lbAdjContrastMax.Size = new System.Drawing.Size(97, 25);
            lbAdjContrastMax.TabIndex = 35;
            lbAdjContrastMax.Text = "Max = 100";
            // 
            // lbAdjContrastMin
            // 
            lbAdjContrastMin.AutoSize = true;
            lbAdjContrastMin.Location = new System.Drawing.Point(31, 245);
            lbAdjContrastMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastMin.Name = "lbAdjContrastMin";
            lbAdjContrastMin.Size = new System.Drawing.Size(74, 25);
            lbAdjContrastMin.TabIndex = 33;
            lbAdjContrastMin.Text = "Min = 1";
            // 
            // tbAdjContrast
            // 
            tbAdjContrast.BackColor = System.Drawing.SystemColors.Window;
            tbAdjContrast.Location = new System.Drawing.Point(22, 191);
            tbAdjContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAdjContrast.Maximum = 100;
            tbAdjContrast.Name = "tbAdjContrast";
            tbAdjContrast.Size = new System.Drawing.Size(318, 69);
            tbAdjContrast.TabIndex = 32;
            tbAdjContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjContrast.Value = 50;
            tbAdjContrast.Scroll += tbAdjContrast_Scroll;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(18, 159);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(79, 25);
            label23.TabIndex = 31;
            label23.Text = "Contrast";
            // 
            // lbAdjBrightnessCurrent
            // 
            lbAdjBrightnessCurrent.AutoSize = true;
            lbAdjBrightnessCurrent.Location = new System.Drawing.Point(218, 116);
            lbAdjBrightnessCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessCurrent.Name = "lbAdjBrightnessCurrent";
            lbAdjBrightnessCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjBrightnessCurrent.TabIndex = 30;
            lbAdjBrightnessCurrent.Text = "Current = 40";
            // 
            // lbAdjBrightnessMax
            // 
            lbAdjBrightnessMax.AutoSize = true;
            lbAdjBrightnessMax.Location = new System.Drawing.Point(111, 116);
            lbAdjBrightnessMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessMax.Name = "lbAdjBrightnessMax";
            lbAdjBrightnessMax.Size = new System.Drawing.Size(97, 25);
            lbAdjBrightnessMax.TabIndex = 29;
            lbAdjBrightnessMax.Text = "Max = 100";
            // 
            // lbAdjBrightnessMin
            // 
            lbAdjBrightnessMin.AutoSize = true;
            lbAdjBrightnessMin.Location = new System.Drawing.Point(31, 116);
            lbAdjBrightnessMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessMin.Name = "lbAdjBrightnessMin";
            lbAdjBrightnessMin.Size = new System.Drawing.Size(74, 25);
            lbAdjBrightnessMin.TabIndex = 27;
            lbAdjBrightnessMin.Text = "Min = 1";
            // 
            // tbAdjBrightness
            // 
            tbAdjBrightness.BackColor = System.Drawing.SystemColors.Window;
            tbAdjBrightness.Location = new System.Drawing.Point(22, 59);
            tbAdjBrightness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAdjBrightness.Maximum = 100;
            tbAdjBrightness.Name = "tbAdjBrightness";
            tbAdjBrightness.Size = new System.Drawing.Size(318, 69);
            tbAdjBrightness.TabIndex = 26;
            tbAdjBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjBrightness.Value = 50;
            tbAdjBrightness.Scroll += tbAdjBrightness_Scroll;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(18, 30);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(94, 25);
            label24.TabIndex = 25;
            label24.Text = "Brightness";
            // 
            // tabPage15
            // 
            tabPage15.Controls.Add(pnChromaKeyColor);
            tabPage15.Controls.Add(btChromaKeySelectBGImage);
            tabPage15.Controls.Add(edChromaKeyImage);
            tabPage15.Controls.Add(label216);
            tabPage15.Controls.Add(label215);
            tabPage15.Controls.Add(tbChromaKeySmoothing);
            tabPage15.Controls.Add(label214);
            tabPage15.Controls.Add(tbChromaKeyThresholdSensitivity);
            tabPage15.Controls.Add(label213);
            tabPage15.Controls.Add(cbChromaKeyEnabled);
            tabPage15.Location = new System.Drawing.Point(4, 34);
            tabPage15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage15.Name = "tabPage15";
            tabPage15.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage15.Size = new System.Drawing.Size(490, 893);
            tabPage15.TabIndex = 7;
            tabPage15.Text = "Chroma key";
            tabPage15.UseVisualStyleBackColor = true;
            // 
            // pnChromaKeyColor
            // 
            pnChromaKeyColor.BackColor = System.Drawing.Color.Lime;
            pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control;
            pnChromaKeyColor.Location = new System.Drawing.Point(91, 384);
            pnChromaKeyColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnChromaKeyColor.Name = "pnChromaKeyColor";
            pnChromaKeyColor.Size = new System.Drawing.Size(42, 45);
            pnChromaKeyColor.TabIndex = 33;
            pnChromaKeyColor.Click += pnChromaKeyColor_Click;
            // 
            // btChromaKeySelectBGImage
            // 
            btChromaKeySelectBGImage.Location = new System.Drawing.Point(424, 505);
            btChromaKeySelectBGImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage";
            btChromaKeySelectBGImage.Size = new System.Drawing.Size(40, 44);
            btChromaKeySelectBGImage.TabIndex = 32;
            btChromaKeySelectBGImage.Text = "...";
            btChromaKeySelectBGImage.UseVisualStyleBackColor = true;
            btChromaKeySelectBGImage.Click += btChromaKeySelectBGImage_Click;
            // 
            // edChromaKeyImage
            // 
            edChromaKeyImage.Location = new System.Drawing.Point(22, 508);
            edChromaKeyImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edChromaKeyImage.Name = "edChromaKeyImage";
            edChromaKeyImage.Size = new System.Drawing.Size(388, 31);
            edChromaKeyImage.TabIndex = 31;
            edChromaKeyImage.Text = "c:\\Samples\\pics\\1.jpg";
            // 
            // label216
            // 
            label216.AutoSize = true;
            label216.Location = new System.Drawing.Point(18, 478);
            label216.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label216.Name = "label216";
            label216.Size = new System.Drawing.Size(191, 25);
            label216.TabIndex = 30;
            label216.Text = "Image background file";
            // 
            // label215
            // 
            label215.AutoSize = true;
            label215.Location = new System.Drawing.Point(18, 392);
            label215.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label215.Name = "label215";
            label215.Size = new System.Drawing.Size(55, 25);
            label215.TabIndex = 26;
            label215.Text = "Color";
            // 
            // tbChromaKeySmoothing
            // 
            tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeySmoothing.Location = new System.Drawing.Point(22, 280);
            tbChromaKeySmoothing.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbChromaKeySmoothing.Maximum = 1000;
            tbChromaKeySmoothing.Name = "tbChromaKeySmoothing";
            tbChromaKeySmoothing.Size = new System.Drawing.Size(258, 69);
            tbChromaKeySmoothing.TabIndex = 25;
            tbChromaKeySmoothing.Value = 80;
            tbChromaKeySmoothing.Scroll += tbChromaKeyContrastHigh_Scroll;
            // 
            // label214
            // 
            label214.AutoSize = true;
            label214.Location = new System.Drawing.Point(18, 244);
            label214.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label214.Name = "label214";
            label214.Size = new System.Drawing.Size(101, 25);
            label214.TabIndex = 24;
            label214.Text = "Smoothing";
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeyThresholdSensitivity.Location = new System.Drawing.Point(22, 139);
            tbChromaKeyThresholdSensitivity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbChromaKeyThresholdSensitivity.Maximum = 200;
            tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity";
            tbChromaKeyThresholdSensitivity.Size = new System.Drawing.Size(258, 69);
            tbChromaKeyThresholdSensitivity.TabIndex = 23;
            tbChromaKeyThresholdSensitivity.Value = 180;
            tbChromaKeyThresholdSensitivity.Scroll += tbChromaKeyContrastLow_Scroll;
            // 
            // label213
            // 
            label213.AutoSize = true;
            label213.Location = new System.Drawing.Point(18, 105);
            label213.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label213.Name = "label213";
            label213.Size = new System.Drawing.Size(172, 25);
            label213.TabIndex = 22;
            label213.Text = "Threshold sensitivity";
            // 
            // cbChromaKeyEnabled
            // 
            cbChromaKeyEnabled.AutoSize = true;
            cbChromaKeyEnabled.Location = new System.Drawing.Point(22, 30);
            cbChromaKeyEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbChromaKeyEnabled.Name = "cbChromaKeyEnabled";
            cbChromaKeyEnabled.Size = new System.Drawing.Size(101, 29);
            cbChromaKeyEnabled.TabIndex = 21;
            cbChromaKeyEnabled.Text = "Enabled";
            cbChromaKeyEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage46
            // 
            tabPage46.Controls.Add(btFilterDelete);
            tabPage46.Controls.Add(btFilterDeleteAll);
            tabPage46.Controls.Add(btFilterSettings2);
            tabPage46.Controls.Add(lbFilters);
            tabPage46.Controls.Add(label106);
            tabPage46.Controls.Add(btFilterSettings);
            tabPage46.Controls.Add(btFilterAdd);
            tabPage46.Controls.Add(cbFilters);
            tabPage46.Controls.Add(label105);
            tabPage46.Location = new System.Drawing.Point(4, 34);
            tabPage46.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage46.Name = "tabPage46";
            tabPage46.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage46.Size = new System.Drawing.Size(490, 893);
            tabPage46.TabIndex = 8;
            tabPage46.Text = "3rd-party filters";
            tabPage46.UseVisualStyleBackColor = true;
            // 
            // btFilterDelete
            // 
            btFilterDelete.Location = new System.Drawing.Point(250, 545);
            btFilterDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterDelete.Name = "btFilterDelete";
            btFilterDelete.Size = new System.Drawing.Size(80, 44);
            btFilterDelete.TabIndex = 26;
            btFilterDelete.Text = "Delete";
            btFilterDelete.UseVisualStyleBackColor = true;
            btFilterDelete.Click += btFilterDelete_Click;
            // 
            // btFilterDeleteAll
            // 
            btFilterDeleteAll.Location = new System.Drawing.Point(340, 545);
            btFilterDeleteAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterDeleteAll.Name = "btFilterDeleteAll";
            btFilterDeleteAll.Size = new System.Drawing.Size(112, 44);
            btFilterDeleteAll.TabIndex = 25;
            btFilterDeleteAll.Text = "Delete all";
            btFilterDeleteAll.UseVisualStyleBackColor = true;
            btFilterDeleteAll.Click += btFilterDeleteAll_Click;
            // 
            // btFilterSettings2
            // 
            btFilterSettings2.Location = new System.Drawing.Point(20, 545);
            btFilterSettings2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterSettings2.Name = "btFilterSettings2";
            btFilterSettings2.Size = new System.Drawing.Size(109, 44);
            btFilterSettings2.TabIndex = 24;
            btFilterSettings2.Text = "Settings";
            btFilterSettings2.UseVisualStyleBackColor = true;
            btFilterSettings2.Click += btFilterSettings2_Click;
            // 
            // lbFilters
            // 
            lbFilters.FormattingEnabled = true;
            lbFilters.ItemHeight = 25;
            lbFilters.Location = new System.Drawing.Point(20, 228);
            lbFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbFilters.Name = "lbFilters";
            lbFilters.Size = new System.Drawing.Size(432, 304);
            lbFilters.TabIndex = 23;
            lbFilters.SelectedIndexChanged += lbFilters_SelectedIndexChanged;
            // 
            // label106
            // 
            label106.AutoSize = true;
            label106.Location = new System.Drawing.Point(16, 195);
            label106.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label106.Name = "label106";
            label106.Size = new System.Drawing.Size(118, 25);
            label106.TabIndex = 22;
            label106.Text = "Current filters";
            // 
            // btFilterSettings
            // 
            btFilterSettings.Location = new System.Drawing.Point(340, 105);
            btFilterSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterSettings.Name = "btFilterSettings";
            btFilterSettings.Size = new System.Drawing.Size(112, 44);
            btFilterSettings.TabIndex = 21;
            btFilterSettings.Text = "Settings";
            btFilterSettings.UseVisualStyleBackColor = true;
            btFilterSettings.Click += btFilterSettings_Click;
            // 
            // btFilterAdd
            // 
            btFilterAdd.Location = new System.Drawing.Point(20, 105);
            btFilterAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterAdd.Name = "btFilterAdd";
            btFilterAdd.Size = new System.Drawing.Size(64, 44);
            btFilterAdd.TabIndex = 20;
            btFilterAdd.Text = "Add";
            btFilterAdd.UseVisualStyleBackColor = true;
            btFilterAdd.Click += btFilterAdd_Click;
            // 
            // cbFilters
            // 
            cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilters.FormattingEnabled = true;
            cbFilters.Location = new System.Drawing.Point(20, 52);
            cbFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new System.Drawing.Size(432, 33);
            cbFilters.TabIndex = 19;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // label105
            // 
            label105.AutoSize = true;
            label105.Location = new System.Drawing.Point(16, 20);
            label105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label105.Name = "label105";
            label105.Size = new System.Drawing.Size(58, 25);
            label105.TabIndex = 18;
            label105.Text = "Filters";
            // 
            // tabPage48
            // 
            tabPage48.Controls.Add(lbAudioTimeshift);
            tabPage48.Controls.Add(tbAudioTimeshift);
            tabPage48.Controls.Add(label70);
            tabPage48.Controls.Add(groupBox4);
            tabPage48.Controls.Add(groupBox1);
            tabPage48.Controls.Add(cbAudioAutoGain);
            tabPage48.Controls.Add(cbAudioNormalize);
            tabPage48.Controls.Add(cbAudioEnhancementEnabled);
            tabPage48.Location = new System.Drawing.Point(4, 34);
            tabPage48.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage48.Name = "tabPage48";
            tabPage48.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage48.Size = new System.Drawing.Size(508, 957);
            tabPage48.TabIndex = 12;
            tabPage48.Text = "Audio enhancement";
            tabPage48.UseVisualStyleBackColor = true;
            // 
            // lbAudioTimeshift
            // 
            lbAudioTimeshift.AutoSize = true;
            lbAudioTimeshift.Location = new System.Drawing.Point(290, 861);
            lbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioTimeshift.Name = "lbAudioTimeshift";
            lbAudioTimeshift.Size = new System.Drawing.Size(51, 25);
            lbAudioTimeshift.TabIndex = 7;
            lbAudioTimeshift.Text = "0 ms";
            // 
            // tbAudioTimeshift
            // 
            tbAudioTimeshift.Location = new System.Drawing.Point(108, 841);
            tbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioTimeshift.Maximum = 3000;
            tbAudioTimeshift.Name = "tbAudioTimeshift";
            tbAudioTimeshift.Size = new System.Drawing.Size(172, 69);
            tbAudioTimeshift.SmallChange = 10;
            tbAudioTimeshift.TabIndex = 6;
            tbAudioTimeshift.TickFrequency = 100;
            tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioTimeshift.Scroll += tbAudioTimeshift_Scroll;
            // 
            // label70
            // 
            label70.AutoSize = true;
            label70.Location = new System.Drawing.Point(4, 861);
            label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label70.Name = "label70";
            label70.Size = new System.Drawing.Size(89, 25);
            label70.TabIndex = 5;
            label70.Text = "Time shift";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbAudioOutputGainLFE);
            groupBox4.Controls.Add(tbAudioOutputGainLFE);
            groupBox4.Controls.Add(label55);
            groupBox4.Controls.Add(lbAudioOutputGainSR);
            groupBox4.Controls.Add(tbAudioOutputGainSR);
            groupBox4.Controls.Add(label57);
            groupBox4.Controls.Add(lbAudioOutputGainSL);
            groupBox4.Controls.Add(tbAudioOutputGainSL);
            groupBox4.Controls.Add(label59);
            groupBox4.Controls.Add(lbAudioOutputGainR);
            groupBox4.Controls.Add(tbAudioOutputGainR);
            groupBox4.Controls.Add(label61);
            groupBox4.Controls.Add(lbAudioOutputGainC);
            groupBox4.Controls.Add(tbAudioOutputGainC);
            groupBox4.Controls.Add(label67);
            groupBox4.Controls.Add(lbAudioOutputGainL);
            groupBox4.Controls.Add(tbAudioOutputGainL);
            groupBox4.Controls.Add(label69);
            groupBox4.Location = new System.Drawing.Point(10, 494);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox4.Size = new System.Drawing.Size(482, 331);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Output gains (dB)";
            // 
            // lbAudioOutputGainLFE
            // 
            lbAudioOutputGainLFE.AutoSize = true;
            lbAudioOutputGainLFE.Location = new System.Drawing.Point(416, 284);
            lbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE";
            lbAudioOutputGainLFE.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainLFE.TabIndex = 17;
            lbAudioOutputGainLFE.Text = "0.0";
            // 
            // tbAudioOutputGainLFE
            // 
            tbAudioOutputGainLFE.Location = new System.Drawing.Point(402, 80);
            tbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainLFE.Maximum = 200;
            tbAudioOutputGainLFE.Minimum = -200;
            tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE";
            tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainLFE.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainLFE.TabIndex = 16;
            tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainLFE.Scroll += tbAudioOutputGainLFE_Scroll;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new System.Drawing.Point(418, 48);
            label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(38, 25);
            label55.TabIndex = 15;
            label55.Text = "LFE";
            // 
            // lbAudioOutputGainSR
            // 
            lbAudioOutputGainSR.AutoSize = true;
            lbAudioOutputGainSR.Location = new System.Drawing.Point(336, 284);
            lbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainSR.Name = "lbAudioOutputGainSR";
            lbAudioOutputGainSR.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainSR.TabIndex = 14;
            lbAudioOutputGainSR.Text = "0.0";
            // 
            // tbAudioOutputGainSR
            // 
            tbAudioOutputGainSR.Location = new System.Drawing.Point(322, 80);
            tbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainSR.Maximum = 200;
            tbAudioOutputGainSR.Minimum = -200;
            tbAudioOutputGainSR.Name = "tbAudioOutputGainSR";
            tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainSR.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainSR.TabIndex = 13;
            tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainSR.Scroll += tbAudioOutputGainSR_Scroll;
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new System.Drawing.Point(342, 48);
            label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label57.Name = "label57";
            label57.Size = new System.Drawing.Size(33, 25);
            label57.TabIndex = 12;
            label57.Text = "SR";
            // 
            // lbAudioOutputGainSL
            // 
            lbAudioOutputGainSL.AutoSize = true;
            lbAudioOutputGainSL.Location = new System.Drawing.Point(256, 284);
            lbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainSL.Name = "lbAudioOutputGainSL";
            lbAudioOutputGainSL.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainSL.TabIndex = 11;
            lbAudioOutputGainSL.Text = "0.0";
            // 
            // tbAudioOutputGainSL
            // 
            tbAudioOutputGainSL.Location = new System.Drawing.Point(242, 80);
            tbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainSL.Maximum = 200;
            tbAudioOutputGainSL.Minimum = -200;
            tbAudioOutputGainSL.Name = "tbAudioOutputGainSL";
            tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainSL.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainSL.TabIndex = 10;
            tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainSL.Scroll += tbAudioOutputGainSL_Scroll;
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new System.Drawing.Point(262, 48);
            label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label59.Name = "label59";
            label59.Size = new System.Drawing.Size(30, 25);
            label59.TabIndex = 9;
            label59.Text = "SL";
            // 
            // lbAudioOutputGainR
            // 
            lbAudioOutputGainR.AutoSize = true;
            lbAudioOutputGainR.Location = new System.Drawing.Point(176, 284);
            lbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainR.Name = "lbAudioOutputGainR";
            lbAudioOutputGainR.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainR.TabIndex = 8;
            lbAudioOutputGainR.Text = "0.0";
            // 
            // tbAudioOutputGainR
            // 
            tbAudioOutputGainR.Location = new System.Drawing.Point(162, 80);
            tbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainR.Maximum = 200;
            tbAudioOutputGainR.Minimum = -200;
            tbAudioOutputGainR.Name = "tbAudioOutputGainR";
            tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainR.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainR.TabIndex = 7;
            tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainR.Scroll += tbAudioOutputGainR_Scroll;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new System.Drawing.Point(190, 48);
            label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label61.Name = "label61";
            label61.Size = new System.Drawing.Size(23, 25);
            label61.TabIndex = 6;
            label61.Text = "R";
            // 
            // lbAudioOutputGainC
            // 
            lbAudioOutputGainC.AutoSize = true;
            lbAudioOutputGainC.Location = new System.Drawing.Point(96, 284);
            lbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainC.Name = "lbAudioOutputGainC";
            lbAudioOutputGainC.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainC.TabIndex = 5;
            lbAudioOutputGainC.Text = "0.0";
            // 
            // tbAudioOutputGainC
            // 
            tbAudioOutputGainC.Location = new System.Drawing.Point(82, 80);
            tbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainC.Maximum = 200;
            tbAudioOutputGainC.Minimum = -200;
            tbAudioOutputGainC.Name = "tbAudioOutputGainC";
            tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainC.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainC.TabIndex = 4;
            tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainC.Scroll += tbAudioOutputGainC_Scroll;
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new System.Drawing.Point(110, 48);
            label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(23, 25);
            label67.TabIndex = 3;
            label67.Text = "C";
            // 
            // lbAudioOutputGainL
            // 
            lbAudioOutputGainL.AutoSize = true;
            lbAudioOutputGainL.Location = new System.Drawing.Point(16, 284);
            lbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainL.Name = "lbAudioOutputGainL";
            lbAudioOutputGainL.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainL.TabIndex = 2;
            lbAudioOutputGainL.Text = "0.0";
            // 
            // tbAudioOutputGainL
            // 
            tbAudioOutputGainL.Location = new System.Drawing.Point(2, 80);
            tbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainL.Maximum = 200;
            tbAudioOutputGainL.Minimum = -200;
            tbAudioOutputGainL.Name = "tbAudioOutputGainL";
            tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainL.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainL.TabIndex = 1;
            tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainL.Scroll += tbAudioOutputGainL_Scroll;
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Location = new System.Drawing.Point(30, 48);
            label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(20, 25);
            label69.TabIndex = 0;
            label69.Text = "L";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbAudioInputGainLFE);
            groupBox1.Controls.Add(tbAudioInputGainLFE);
            groupBox1.Controls.Add(label53);
            groupBox1.Controls.Add(lbAudioInputGainSR);
            groupBox1.Controls.Add(tbAudioInputGainSR);
            groupBox1.Controls.Add(label51);
            groupBox1.Controls.Add(lbAudioInputGainSL);
            groupBox1.Controls.Add(tbAudioInputGainSL);
            groupBox1.Controls.Add(label49);
            groupBox1.Controls.Add(lbAudioInputGainR);
            groupBox1.Controls.Add(tbAudioInputGainR);
            groupBox1.Controls.Add(label47);
            groupBox1.Controls.Add(lbAudioInputGainC);
            groupBox1.Controls.Add(tbAudioInputGainC);
            groupBox1.Controls.Add(label44);
            groupBox1.Controls.Add(lbAudioInputGainL);
            groupBox1.Controls.Add(tbAudioInputGainL);
            groupBox1.Controls.Add(label40);
            groupBox1.Location = new System.Drawing.Point(10, 152);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Size = new System.Drawing.Size(482, 331);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input gains (dB)";
            // 
            // lbAudioInputGainLFE
            // 
            lbAudioInputGainLFE.AutoSize = true;
            lbAudioInputGainLFE.Location = new System.Drawing.Point(416, 284);
            lbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainLFE.Name = "lbAudioInputGainLFE";
            lbAudioInputGainLFE.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainLFE.TabIndex = 17;
            lbAudioInputGainLFE.Text = "0.0";
            // 
            // tbAudioInputGainLFE
            // 
            tbAudioInputGainLFE.Location = new System.Drawing.Point(402, 80);
            tbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainLFE.Maximum = 200;
            tbAudioInputGainLFE.Minimum = -200;
            tbAudioInputGainLFE.Name = "tbAudioInputGainLFE";
            tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainLFE.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainLFE.TabIndex = 16;
            tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainLFE.Scroll += tbAudioInputGainLFE_Scroll;
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(418, 48);
            label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(38, 25);
            label53.TabIndex = 15;
            label53.Text = "LFE";
            // 
            // lbAudioInputGainSR
            // 
            lbAudioInputGainSR.AutoSize = true;
            lbAudioInputGainSR.Location = new System.Drawing.Point(336, 284);
            lbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainSR.Name = "lbAudioInputGainSR";
            lbAudioInputGainSR.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainSR.TabIndex = 14;
            lbAudioInputGainSR.Text = "0.0";
            // 
            // tbAudioInputGainSR
            // 
            tbAudioInputGainSR.Location = new System.Drawing.Point(322, 80);
            tbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainSR.Maximum = 200;
            tbAudioInputGainSR.Minimum = -200;
            tbAudioInputGainSR.Name = "tbAudioInputGainSR";
            tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainSR.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainSR.TabIndex = 13;
            tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainSR.Scroll += tbAudioInputGainSR_Scroll;
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new System.Drawing.Point(342, 48);
            label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(33, 25);
            label51.TabIndex = 12;
            label51.Text = "SR";
            // 
            // lbAudioInputGainSL
            // 
            lbAudioInputGainSL.AutoSize = true;
            lbAudioInputGainSL.Location = new System.Drawing.Point(256, 284);
            lbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainSL.Name = "lbAudioInputGainSL";
            lbAudioInputGainSL.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainSL.TabIndex = 11;
            lbAudioInputGainSL.Text = "0.0";
            // 
            // tbAudioInputGainSL
            // 
            tbAudioInputGainSL.Location = new System.Drawing.Point(242, 80);
            tbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainSL.Maximum = 200;
            tbAudioInputGainSL.Minimum = -200;
            tbAudioInputGainSL.Name = "tbAudioInputGainSL";
            tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainSL.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainSL.TabIndex = 10;
            tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainSL.Scroll += tbAudioInputGainSL_Scroll;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new System.Drawing.Point(262, 48);
            label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(30, 25);
            label49.TabIndex = 9;
            label49.Text = "SL";
            // 
            // lbAudioInputGainR
            // 
            lbAudioInputGainR.AutoSize = true;
            lbAudioInputGainR.Location = new System.Drawing.Point(176, 284);
            lbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainR.Name = "lbAudioInputGainR";
            lbAudioInputGainR.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainR.TabIndex = 8;
            lbAudioInputGainR.Text = "0.0";
            // 
            // tbAudioInputGainR
            // 
            tbAudioInputGainR.Location = new System.Drawing.Point(162, 80);
            tbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainR.Maximum = 200;
            tbAudioInputGainR.Minimum = -200;
            tbAudioInputGainR.Name = "tbAudioInputGainR";
            tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainR.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainR.TabIndex = 7;
            tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainR.Scroll += tbAudioInputGainR_Scroll;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new System.Drawing.Point(190, 48);
            label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(23, 25);
            label47.TabIndex = 6;
            label47.Text = "R";
            // 
            // lbAudioInputGainC
            // 
            lbAudioInputGainC.AutoSize = true;
            lbAudioInputGainC.Location = new System.Drawing.Point(96, 284);
            lbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainC.Name = "lbAudioInputGainC";
            lbAudioInputGainC.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainC.TabIndex = 5;
            lbAudioInputGainC.Text = "0.0";
            // 
            // tbAudioInputGainC
            // 
            tbAudioInputGainC.Location = new System.Drawing.Point(82, 80);
            tbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainC.Maximum = 200;
            tbAudioInputGainC.Minimum = -200;
            tbAudioInputGainC.Name = "tbAudioInputGainC";
            tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainC.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainC.TabIndex = 4;
            tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainC.Scroll += tbAudioInputGainC_Scroll;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(110, 48);
            label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(23, 25);
            label44.TabIndex = 3;
            label44.Text = "C";
            // 
            // lbAudioInputGainL
            // 
            lbAudioInputGainL.AutoSize = true;
            lbAudioInputGainL.Location = new System.Drawing.Point(16, 284);
            lbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainL.Name = "lbAudioInputGainL";
            lbAudioInputGainL.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainL.TabIndex = 2;
            lbAudioInputGainL.Text = "0.0";
            // 
            // tbAudioInputGainL
            // 
            tbAudioInputGainL.Location = new System.Drawing.Point(2, 80);
            tbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioInputGainL.Maximum = 200;
            tbAudioInputGainL.Minimum = -200;
            tbAudioInputGainL.Name = "tbAudioInputGainL";
            tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainL.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainL.TabIndex = 1;
            tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainL.Scroll += tbAudioInputGainL_Scroll;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(30, 48);
            label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(20, 25);
            label40.TabIndex = 0;
            label40.Text = "L";
            // 
            // cbAudioAutoGain
            // 
            cbAudioAutoGain.AutoSize = true;
            cbAudioAutoGain.Location = new System.Drawing.Point(222, 91);
            cbAudioAutoGain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioAutoGain.Name = "cbAudioAutoGain";
            cbAudioAutoGain.Size = new System.Drawing.Size(116, 29);
            cbAudioAutoGain.TabIndex = 2;
            cbAudioAutoGain.Text = "Auto gain";
            cbAudioAutoGain.UseVisualStyleBackColor = true;
            cbAudioAutoGain.CheckedChanged += cbAudioAutoGain_CheckedChanged;
            // 
            // cbAudioNormalize
            // 
            cbAudioNormalize.AutoSize = true;
            cbAudioNormalize.Location = new System.Drawing.Point(64, 91);
            cbAudioNormalize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioNormalize.Name = "cbAudioNormalize";
            cbAudioNormalize.Size = new System.Drawing.Size(118, 29);
            cbAudioNormalize.TabIndex = 1;
            cbAudioNormalize.Text = "Normalize";
            cbAudioNormalize.UseVisualStyleBackColor = true;
            cbAudioNormalize.CheckedChanged += cbAudioNormalize_CheckedChanged;
            // 
            // cbAudioEnhancementEnabled
            // 
            cbAudioEnhancementEnabled.AutoSize = true;
            cbAudioEnhancementEnabled.Location = new System.Drawing.Point(28, 30);
            cbAudioEnhancementEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled";
            cbAudioEnhancementEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEnhancementEnabled.TabIndex = 0;
            cbAudioEnhancementEnabled.Text = "Enabled";
            cbAudioEnhancementEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Controls.Add(label31);
            tabPage11.Controls.Add(tabControl18);
            tabPage11.Controls.Add(cbAudioEffectsEnabled);
            tabPage11.Location = new System.Drawing.Point(4, 34);
            tabPage11.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage11.Size = new System.Drawing.Size(508, 957);
            tabPage11.TabIndex = 5;
            tabPage11.Text = "Audio effects";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(156, 19);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(313, 25);
            label31.TabIndex = 4;
            label31.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            tabControl18.Controls.Add(tabPage71);
            tabControl18.Controls.Add(tabPage72);
            tabControl18.Controls.Add(tabPage73);
            tabControl18.Controls.Add(tabPage75);
            tabControl18.Controls.Add(tabPage76);
            tabControl18.Controls.Add(tabPage27);
            tabControl18.Location = new System.Drawing.Point(12, 59);
            tabControl18.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl18.Name = "tabControl18";
            tabControl18.SelectedIndex = 0;
            tabControl18.Size = new System.Drawing.Size(471, 850);
            tabControl18.TabIndex = 3;
            // 
            // tabPage71
            // 
            tabPage71.Controls.Add(label231);
            tabPage71.Controls.Add(label230);
            tabPage71.Controls.Add(tbAudAmplifyAmp);
            tabPage71.Controls.Add(label95);
            tabPage71.Controls.Add(cbAudAmplifyEnabled);
            tabPage71.Location = new System.Drawing.Point(4, 34);
            tabPage71.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage71.Name = "tabPage71";
            tabPage71.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage71.Size = new System.Drawing.Size(463, 812);
            tabPage71.TabIndex = 0;
            tabPage71.Text = "Amplify";
            tabPage71.UseVisualStyleBackColor = true;
            // 
            // label231
            // 
            label231.AutoSize = true;
            label231.Location = new System.Drawing.Point(356, 102);
            label231.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label231.Name = "label231";
            label231.Size = new System.Drawing.Size(57, 25);
            label231.TabIndex = 5;
            label231.Text = "400%";
            // 
            // label230
            // 
            label230.AutoSize = true;
            label230.Location = new System.Drawing.Point(112, 102);
            label230.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label230.Name = "label230";
            label230.Size = new System.Drawing.Size(57, 25);
            label230.TabIndex = 4;
            label230.Text = "100%";
            // 
            // tbAudAmplifyAmp
            // 
            tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            tbAudAmplifyAmp.Location = new System.Drawing.Point(28, 131);
            tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudAmplifyAmp.Maximum = 4000;
            tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            tbAudAmplifyAmp.Size = new System.Drawing.Size(382, 69);
            tbAudAmplifyAmp.TabIndex = 3;
            tbAudAmplifyAmp.TickFrequency = 50;
            tbAudAmplifyAmp.Value = 1000;
            tbAudAmplifyAmp.Scroll += tbAudAmplifyAmp_Scroll;
            // 
            // label95
            // 
            label95.AutoSize = true;
            label95.Location = new System.Drawing.Point(22, 102);
            label95.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label95.Name = "label95";
            label95.Size = new System.Drawing.Size(72, 25);
            label95.TabIndex = 2;
            label95.Text = "Volume";
            // 
            // cbAudAmplifyEnabled
            // 
            cbAudAmplifyEnabled.AutoSize = true;
            cbAudAmplifyEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            cbAudAmplifyEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudAmplifyEnabled.TabIndex = 1;
            cbAudAmplifyEnabled.Text = "Enabled";
            cbAudAmplifyEnabled.UseVisualStyleBackColor = true;
            cbAudAmplifyEnabled.CheckedChanged += cbAudAmplifyEnabled_CheckedChanged;
            // 
            // tabPage72
            // 
            tabPage72.Controls.Add(btAudEqRefresh);
            tabPage72.Controls.Add(cbAudEqualizerPreset);
            tabPage72.Controls.Add(label243);
            tabPage72.Controls.Add(label242);
            tabPage72.Controls.Add(label241);
            tabPage72.Controls.Add(label240);
            tabPage72.Controls.Add(label239);
            tabPage72.Controls.Add(label238);
            tabPage72.Controls.Add(label237);
            tabPage72.Controls.Add(label236);
            tabPage72.Controls.Add(label235);
            tabPage72.Controls.Add(label234);
            tabPage72.Controls.Add(label233);
            tabPage72.Controls.Add(label232);
            tabPage72.Controls.Add(tbAudEq9);
            tabPage72.Controls.Add(tbAudEq8);
            tabPage72.Controls.Add(tbAudEq7);
            tabPage72.Controls.Add(tbAudEq6);
            tabPage72.Controls.Add(tbAudEq5);
            tabPage72.Controls.Add(tbAudEq4);
            tabPage72.Controls.Add(tbAudEq3);
            tabPage72.Controls.Add(tbAudEq2);
            tabPage72.Controls.Add(tbAudEq1);
            tabPage72.Controls.Add(tbAudEq0);
            tabPage72.Controls.Add(cbAudEqualizerEnabled);
            tabPage72.Location = new System.Drawing.Point(4, 34);
            tabPage72.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage72.Name = "tabPage72";
            tabPage72.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage72.Size = new System.Drawing.Size(463, 812);
            tabPage72.TabIndex = 1;
            tabPage72.Text = "Equalizer";
            tabPage72.UseVisualStyleBackColor = true;
            // 
            // btAudEqRefresh
            // 
            btAudEqRefresh.Location = new System.Drawing.Point(291, 420);
            btAudEqRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAudEqRefresh.Name = "btAudEqRefresh";
            btAudEqRefresh.Size = new System.Drawing.Size(124, 44);
            btAudEqRefresh.TabIndex = 26;
            btAudEqRefresh.Text = "Refresh";
            btAudEqRefresh.UseVisualStyleBackColor = true;
            btAudEqRefresh.Click += btAudEqRefresh_Click;
            // 
            // cbAudEqualizerPreset
            // 
            cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudEqualizerPreset.FormattingEnabled = true;
            cbAudEqualizerPreset.Location = new System.Drawing.Point(102, 345);
            cbAudEqualizerPreset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudEqualizerPreset.Name = "cbAudEqualizerPreset";
            cbAudEqualizerPreset.Size = new System.Drawing.Size(313, 33);
            cbAudEqualizerPreset.TabIndex = 25;
            cbAudEqualizerPreset.SelectedIndexChanged += cbAudEqualizerPreset_SelectedIndexChanged;
            // 
            // label243
            // 
            label243.AutoSize = true;
            label243.Location = new System.Drawing.Point(22, 352);
            label243.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label243.Name = "label243";
            label243.Size = new System.Drawing.Size(60, 25);
            label243.TabIndex = 24;
            label243.Text = "Preset";
            // 
            // label242
            // 
            label242.AutoSize = true;
            label242.Location = new System.Drawing.Point(342, 300);
            label242.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label242.Name = "label242";
            label242.Size = new System.Drawing.Size(42, 25);
            label242.TabIndex = 23;
            label242.Text = "16K";
            // 
            // label241
            // 
            label241.AutoSize = true;
            label241.Location = new System.Drawing.Point(308, 300);
            label241.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label241.Name = "label241";
            label241.Size = new System.Drawing.Size(42, 25);
            label241.TabIndex = 22;
            label241.Text = "14K";
            // 
            // label240
            // 
            label240.AutoSize = true;
            label240.Location = new System.Drawing.Point(270, 300);
            label240.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label240.Name = "label240";
            label240.Size = new System.Drawing.Size(42, 25);
            label240.TabIndex = 21;
            label240.Text = "12K";
            // 
            // label239
            // 
            label239.AutoSize = true;
            label239.Location = new System.Drawing.Point(238, 300);
            label239.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label239.Name = "label239";
            label239.Size = new System.Drawing.Size(32, 25);
            label239.TabIndex = 20;
            label239.Text = "6K";
            // 
            // label238
            // 
            label238.AutoSize = true;
            label238.Location = new System.Drawing.Point(202, 300);
            label238.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label238.Name = "label238";
            label238.Size = new System.Drawing.Size(32, 25);
            label238.TabIndex = 19;
            label238.Text = "3K";
            // 
            // label237
            // 
            label237.AutoSize = true;
            label237.Location = new System.Drawing.Point(170, 300);
            label237.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label237.Name = "label237";
            label237.Size = new System.Drawing.Size(32, 25);
            label237.TabIndex = 18;
            label237.Text = "1K";
            // 
            // label236
            // 
            label236.AutoSize = true;
            label236.Location = new System.Drawing.Point(132, 300);
            label236.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label236.Name = "label236";
            label236.Size = new System.Drawing.Size(42, 25);
            label236.TabIndex = 17;
            label236.Text = "600";
            // 
            // label235
            // 
            label235.AutoSize = true;
            label235.Location = new System.Drawing.Point(98, 300);
            label235.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label235.Name = "label235";
            label235.Size = new System.Drawing.Size(42, 25);
            label235.TabIndex = 16;
            label235.Text = "310";
            // 
            // label234
            // 
            label234.AutoSize = true;
            label234.Location = new System.Drawing.Point(60, 300);
            label234.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label234.Name = "label234";
            label234.Size = new System.Drawing.Size(42, 25);
            label234.TabIndex = 15;
            label234.Text = "170";
            // 
            // label233
            // 
            label233.AutoSize = true;
            label233.Location = new System.Drawing.Point(30, 300);
            label233.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label233.Name = "label233";
            label233.Size = new System.Drawing.Size(32, 25);
            label233.TabIndex = 14;
            label233.Text = "60";
            // 
            // label232
            // 
            label232.AutoSize = true;
            label232.Location = new System.Drawing.Point(198, 64);
            label232.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label232.Name = "label232";
            label232.Size = new System.Drawing.Size(22, 25);
            label232.TabIndex = 13;
            label232.Text = "0";
            // 
            // tbAudEq9
            // 
            tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq9.Location = new System.Drawing.Point(342, 94);
            tbAudEq9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq9.Maximum = 100;
            tbAudEq9.Minimum = -100;
            tbAudEq9.Name = "tbAudEq9";
            tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq9.Size = new System.Drawing.Size(69, 200);
            tbAudEq9.TabIndex = 12;
            tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq9.Scroll += tbAudEq9_Scroll;
            // 
            // tbAudEq8
            // 
            tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq8.Location = new System.Drawing.Point(308, 94);
            tbAudEq8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq8.Maximum = 100;
            tbAudEq8.Minimum = -100;
            tbAudEq8.Name = "tbAudEq8";
            tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq8.Size = new System.Drawing.Size(69, 200);
            tbAudEq8.TabIndex = 11;
            tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq8.Scroll += tbAudEq8_Scroll;
            // 
            // tbAudEq7
            // 
            tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq7.Location = new System.Drawing.Point(270, 94);
            tbAudEq7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq7.Maximum = 100;
            tbAudEq7.Minimum = -100;
            tbAudEq7.Name = "tbAudEq7";
            tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq7.Size = new System.Drawing.Size(69, 200);
            tbAudEq7.TabIndex = 10;
            tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq7.Scroll += tbAudEq7_Scroll;
            // 
            // tbAudEq6
            // 
            tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq6.Location = new System.Drawing.Point(236, 94);
            tbAudEq6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq6.Maximum = 100;
            tbAudEq6.Minimum = -100;
            tbAudEq6.Name = "tbAudEq6";
            tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq6.Size = new System.Drawing.Size(69, 200);
            tbAudEq6.TabIndex = 9;
            tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq6.Scroll += tbAudEq6_Scroll;
            // 
            // tbAudEq5
            // 
            tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq5.Location = new System.Drawing.Point(200, 94);
            tbAudEq5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq5.Maximum = 100;
            tbAudEq5.Minimum = -100;
            tbAudEq5.Name = "tbAudEq5";
            tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq5.Size = new System.Drawing.Size(69, 200);
            tbAudEq5.TabIndex = 8;
            tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq5.Scroll += tbAudEq5_Scroll;
            // 
            // tbAudEq4
            // 
            tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq4.Location = new System.Drawing.Point(168, 94);
            tbAudEq4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq4.Maximum = 100;
            tbAudEq4.Minimum = -100;
            tbAudEq4.Name = "tbAudEq4";
            tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq4.Size = new System.Drawing.Size(69, 200);
            tbAudEq4.TabIndex = 7;
            tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq4.Scroll += tbAudEq4_Scroll;
            // 
            // tbAudEq3
            // 
            tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq3.Location = new System.Drawing.Point(131, 94);
            tbAudEq3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq3.Maximum = 100;
            tbAudEq3.Minimum = -100;
            tbAudEq3.Name = "tbAudEq3";
            tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq3.Size = new System.Drawing.Size(69, 200);
            tbAudEq3.TabIndex = 6;
            tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq3.Scroll += tbAudEq3_Scroll;
            // 
            // tbAudEq2
            // 
            tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq2.Location = new System.Drawing.Point(98, 94);
            tbAudEq2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq2.Maximum = 100;
            tbAudEq2.Minimum = -100;
            tbAudEq2.Name = "tbAudEq2";
            tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq2.Size = new System.Drawing.Size(69, 200);
            tbAudEq2.TabIndex = 5;
            tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq2.Scroll += tbAudEq2_Scroll;
            // 
            // tbAudEq1
            // 
            tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq1.Location = new System.Drawing.Point(62, 94);
            tbAudEq1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq1.Maximum = 100;
            tbAudEq1.Minimum = -100;
            tbAudEq1.Name = "tbAudEq1";
            tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq1.Size = new System.Drawing.Size(69, 200);
            tbAudEq1.TabIndex = 4;
            tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq1.Scroll += tbAudEq1_Scroll;
            // 
            // tbAudEq0
            // 
            tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq0.Location = new System.Drawing.Point(29, 94);
            tbAudEq0.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudEq0.Maximum = 100;
            tbAudEq0.Minimum = -100;
            tbAudEq0.Name = "tbAudEq0";
            tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq0.Size = new System.Drawing.Size(69, 200);
            tbAudEq0.TabIndex = 3;
            tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq0.Scroll += tbAudEq0_Scroll;
            // 
            // cbAudEqualizerEnabled
            // 
            cbAudEqualizerEnabled.AutoSize = true;
            cbAudEqualizerEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudEqualizerEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            cbAudEqualizerEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudEqualizerEnabled.TabIndex = 2;
            cbAudEqualizerEnabled.Text = "Enabled";
            cbAudEqualizerEnabled.UseVisualStyleBackColor = true;
            cbAudEqualizerEnabled.CheckedChanged += cbAudEqualizerEnabled_CheckedChanged;
            // 
            // tabPage73
            // 
            tabPage73.Controls.Add(tbAudRelease);
            tabPage73.Controls.Add(label248);
            tabPage73.Controls.Add(label249);
            tabPage73.Controls.Add(label246);
            tabPage73.Controls.Add(tbAudAttack);
            tabPage73.Controls.Add(label247);
            tabPage73.Controls.Add(label244);
            tabPage73.Controls.Add(tbAudDynAmp);
            tabPage73.Controls.Add(label245);
            tabPage73.Controls.Add(cbAudDynamicAmplifyEnabled);
            tabPage73.Location = new System.Drawing.Point(4, 34);
            tabPage73.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage73.Name = "tabPage73";
            tabPage73.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage73.Size = new System.Drawing.Size(463, 812);
            tabPage73.TabIndex = 2;
            tabPage73.Text = "Dynamic amplify";
            tabPage73.UseVisualStyleBackColor = true;
            // 
            // tbAudRelease
            // 
            tbAudRelease.BackColor = System.Drawing.SystemColors.Window;
            tbAudRelease.Location = new System.Drawing.Point(28, 402);
            tbAudRelease.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudRelease.Maximum = 10000;
            tbAudRelease.Minimum = 10;
            tbAudRelease.Name = "tbAudRelease";
            tbAudRelease.Size = new System.Drawing.Size(382, 69);
            tbAudRelease.TabIndex = 15;
            tbAudRelease.TickFrequency = 250;
            tbAudRelease.Value = 10;
            tbAudRelease.Scroll += tbAudRelease_Scroll;
            // 
            // label248
            // 
            label248.AutoSize = true;
            label248.Location = new System.Drawing.Point(389, 370);
            label248.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label248.Name = "label248";
            label248.Size = new System.Drawing.Size(32, 25);
            label248.TabIndex = 14;
            label248.Text = "10";
            // 
            // label249
            // 
            label249.AutoSize = true;
            label249.Location = new System.Drawing.Point(22, 370);
            label249.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label249.Name = "label249";
            label249.Size = new System.Drawing.Size(110, 25);
            label249.TabIndex = 12;
            label249.Text = "Release time";
            // 
            // label246
            // 
            label246.AutoSize = true;
            label246.Location = new System.Drawing.Point(389, 231);
            label246.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label246.Name = "label246";
            label246.Size = new System.Drawing.Size(32, 25);
            label246.TabIndex = 11;
            label246.Text = "10";
            // 
            // tbAudAttack
            // 
            tbAudAttack.BackColor = System.Drawing.SystemColors.Window;
            tbAudAttack.Location = new System.Drawing.Point(28, 264);
            tbAudAttack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudAttack.Maximum = 10000;
            tbAudAttack.Minimum = 10;
            tbAudAttack.Name = "tbAudAttack";
            tbAudAttack.Size = new System.Drawing.Size(382, 69);
            tbAudAttack.TabIndex = 10;
            tbAudAttack.TickFrequency = 250;
            tbAudAttack.Value = 10;
            tbAudAttack.Scroll += tbAudAttack_Scroll;
            // 
            // label247
            // 
            label247.AutoSize = true;
            label247.Location = new System.Drawing.Point(22, 231);
            label247.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label247.Name = "label247";
            label247.Size = new System.Drawing.Size(62, 25);
            label247.TabIndex = 9;
            label247.Text = "Attack";
            // 
            // label244
            // 
            label244.AutoSize = true;
            label244.Location = new System.Drawing.Point(389, 102);
            label244.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label244.Name = "label244";
            label244.Size = new System.Drawing.Size(52, 25);
            label244.TabIndex = 8;
            label244.Text = "1000";
            // 
            // tbAudDynAmp
            // 
            tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window;
            tbAudDynAmp.Location = new System.Drawing.Point(28, 131);
            tbAudDynAmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudDynAmp.Maximum = 2000;
            tbAudDynAmp.Minimum = 100;
            tbAudDynAmp.Name = "tbAudDynAmp";
            tbAudDynAmp.Size = new System.Drawing.Size(382, 69);
            tbAudDynAmp.TabIndex = 7;
            tbAudDynAmp.TickFrequency = 50;
            tbAudDynAmp.Value = 1000;
            tbAudDynAmp.Scroll += tbAudDynAmp_Scroll;
            // 
            // label245
            // 
            label245.AutoSize = true;
            label245.Location = new System.Drawing.Point(22, 102);
            label245.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label245.Name = "label245";
            label245.Size = new System.Drawing.Size(198, 25);
            label245.TabIndex = 6;
            label245.Text = "Maximum amplification";
            // 
            // cbAudDynamicAmplifyEnabled
            // 
            cbAudDynamicAmplifyEnabled.AutoSize = true;
            cbAudDynamicAmplifyEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudDynamicAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled";
            cbAudDynamicAmplifyEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudDynamicAmplifyEnabled.TabIndex = 2;
            cbAudDynamicAmplifyEnabled.Text = "Enabled";
            cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = true;
            cbAudDynamicAmplifyEnabled.CheckedChanged += cbAudDynamicAmplifyEnabled_CheckedChanged;
            // 
            // tabPage75
            // 
            tabPage75.Controls.Add(tbAud3DSound);
            tabPage75.Controls.Add(label253);
            tabPage75.Controls.Add(cbAudSound3DEnabled);
            tabPage75.Location = new System.Drawing.Point(4, 34);
            tabPage75.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage75.Name = "tabPage75";
            tabPage75.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage75.Size = new System.Drawing.Size(463, 812);
            tabPage75.TabIndex = 4;
            tabPage75.Text = "Sound 3D";
            tabPage75.UseVisualStyleBackColor = true;
            // 
            // tbAud3DSound
            // 
            tbAud3DSound.BackColor = System.Drawing.SystemColors.Window;
            tbAud3DSound.Location = new System.Drawing.Point(28, 131);
            tbAud3DSound.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAud3DSound.Maximum = 10000;
            tbAud3DSound.Name = "tbAud3DSound";
            tbAud3DSound.Size = new System.Drawing.Size(382, 69);
            tbAud3DSound.TabIndex = 19;
            tbAud3DSound.TickFrequency = 250;
            tbAud3DSound.Value = 500;
            tbAud3DSound.Scroll += tbAud3DSound_Scroll;
            // 
            // label253
            // 
            label253.AutoSize = true;
            label253.Location = new System.Drawing.Point(22, 102);
            label253.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label253.Name = "label253";
            label253.Size = new System.Drawing.Size(142, 25);
            label253.TabIndex = 18;
            label253.Text = "3D amplification";
            // 
            // cbAudSound3DEnabled
            // 
            cbAudSound3DEnabled.AutoSize = true;
            cbAudSound3DEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudSound3DEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudSound3DEnabled.Name = "cbAudSound3DEnabled";
            cbAudSound3DEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudSound3DEnabled.TabIndex = 2;
            cbAudSound3DEnabled.Text = "Enabled";
            cbAudSound3DEnabled.UseVisualStyleBackColor = true;
            cbAudSound3DEnabled.CheckedChanged += cbAudSound3DEnabled_CheckedChanged;
            // 
            // tabPage76
            // 
            tabPage76.Controls.Add(tbAudTrueBass);
            tabPage76.Controls.Add(label254);
            tabPage76.Controls.Add(cbAudTrueBassEnabled);
            tabPage76.Location = new System.Drawing.Point(4, 34);
            tabPage76.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage76.Name = "tabPage76";
            tabPage76.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage76.Size = new System.Drawing.Size(463, 812);
            tabPage76.TabIndex = 5;
            tabPage76.Text = "True Bass";
            tabPage76.UseVisualStyleBackColor = true;
            // 
            // tbAudTrueBass
            // 
            tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window;
            tbAudTrueBass.Location = new System.Drawing.Point(28, 131);
            tbAudTrueBass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudTrueBass.Maximum = 10000;
            tbAudTrueBass.Name = "tbAudTrueBass";
            tbAudTrueBass.Size = new System.Drawing.Size(382, 69);
            tbAudTrueBass.TabIndex = 21;
            tbAudTrueBass.TickFrequency = 250;
            tbAudTrueBass.Scroll += tbAudTrueBass_Scroll;
            // 
            // label254
            // 
            label254.AutoSize = true;
            label254.Location = new System.Drawing.Point(22, 102);
            label254.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label254.Name = "label254";
            label254.Size = new System.Drawing.Size(72, 25);
            label254.TabIndex = 20;
            label254.Text = "Volume";
            // 
            // cbAudTrueBassEnabled
            // 
            cbAudTrueBassEnabled.AutoSize = true;
            cbAudTrueBassEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudTrueBassEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled";
            cbAudTrueBassEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudTrueBassEnabled.TabIndex = 2;
            cbAudTrueBassEnabled.Text = "Enabled";
            cbAudTrueBassEnabled.UseVisualStyleBackColor = true;
            cbAudTrueBassEnabled.CheckedChanged += cbAudTrueBassEnabled_CheckedChanged;
            // 
            // tabPage27
            // 
            tabPage27.Controls.Add(tbAudPitchShift);
            tabPage27.Controls.Add(label36);
            tabPage27.Controls.Add(cbAudPitchShiftEnabled);
            tabPage27.Location = new System.Drawing.Point(4, 34);
            tabPage27.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage27.Name = "tabPage27";
            tabPage27.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage27.Size = new System.Drawing.Size(463, 812);
            tabPage27.TabIndex = 7;
            tabPage27.Text = "Pitch shift";
            tabPage27.UseVisualStyleBackColor = true;
            // 
            // tbAudPitchShift
            // 
            tbAudPitchShift.BackColor = System.Drawing.SystemColors.Window;
            tbAudPitchShift.Location = new System.Drawing.Point(28, 131);
            tbAudPitchShift.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudPitchShift.Maximum = 3000;
            tbAudPitchShift.Minimum = 100;
            tbAudPitchShift.Name = "tbAudPitchShift";
            tbAudPitchShift.Size = new System.Drawing.Size(382, 69);
            tbAudPitchShift.TabIndex = 26;
            tbAudPitchShift.TickFrequency = 20;
            tbAudPitchShift.Value = 1000;
            tbAudPitchShift.Scroll += tbAudPitchShift_Scroll;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(22, 102);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(50, 25);
            label36.TabIndex = 25;
            label36.Text = "Pitch";
            // 
            // cbAudPitchShiftEnabled
            // 
            cbAudPitchShiftEnabled.AutoSize = true;
            cbAudPitchShiftEnabled.Location = new System.Drawing.Point(28, 31);
            cbAudPitchShiftEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudPitchShiftEnabled.Name = "cbAudPitchShiftEnabled";
            cbAudPitchShiftEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudPitchShiftEnabled.TabIndex = 24;
            cbAudPitchShiftEnabled.Text = "Enabled";
            cbAudPitchShiftEnabled.UseVisualStyleBackColor = true;
            cbAudPitchShiftEnabled.CheckedChanged += cbAudPitchShiftEnabled_CheckedChanged;
            // 
            // cbAudioEffectsEnabled
            // 
            cbAudioEffectsEnabled.AutoSize = true;
            cbAudioEffectsEnabled.Location = new System.Drawing.Point(12, 16);
            cbAudioEffectsEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            cbAudioEffectsEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEffectsEnabled.TabIndex = 2;
            cbAudioEffectsEnabled.Text = "Enabled";
            cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage50
            // 
            tabPage50.Controls.Add(btAudioChannelMapperClear);
            tabPage50.Controls.Add(groupBox41);
            tabPage50.Controls.Add(label307);
            tabPage50.Controls.Add(edAudioChannelMapperOutputChannels);
            tabPage50.Controls.Add(label306);
            tabPage50.Controls.Add(lbAudioChannelMapperRoutes);
            tabPage50.Controls.Add(cbAudioChannelMapperEnabled);
            tabPage50.Location = new System.Drawing.Point(4, 34);
            tabPage50.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage50.Name = "tabPage50";
            tabPage50.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage50.Size = new System.Drawing.Size(508, 957);
            tabPage50.TabIndex = 13;
            tabPage50.Text = "Audio channel mapper";
            tabPage50.UseVisualStyleBackColor = true;
            // 
            // btAudioChannelMapperClear
            // 
            btAudioChannelMapperClear.Location = new System.Drawing.Point(340, 422);
            btAudioChannelMapperClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAudioChannelMapperClear.Name = "btAudioChannelMapperClear";
            btAudioChannelMapperClear.Size = new System.Drawing.Size(124, 44);
            btAudioChannelMapperClear.TabIndex = 21;
            btAudioChannelMapperClear.Text = "Clear";
            btAudioChannelMapperClear.UseVisualStyleBackColor = true;
            btAudioChannelMapperClear.Click += btAudioChannelMapperClear_Click;
            // 
            // groupBox41
            // 
            groupBox41.Controls.Add(btAudioChannelMapperAddNewRoute);
            groupBox41.Controls.Add(label311);
            groupBox41.Controls.Add(tbAudioChannelMapperVolume);
            groupBox41.Controls.Add(label310);
            groupBox41.Controls.Add(edAudioChannelMapperTargetChannel);
            groupBox41.Controls.Add(label309);
            groupBox41.Controls.Add(edAudioChannelMapperSourceChannel);
            groupBox41.Controls.Add(label308);
            groupBox41.Location = new System.Drawing.Point(10, 480);
            groupBox41.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox41.Name = "groupBox41";
            groupBox41.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox41.Size = new System.Drawing.Size(478, 330);
            groupBox41.TabIndex = 20;
            groupBox41.TabStop = false;
            groupBox41.Text = "Add new route";
            // 
            // btAudioChannelMapperAddNewRoute
            // 
            btAudioChannelMapperAddNewRoute.Location = new System.Drawing.Point(180, 252);
            btAudioChannelMapperAddNewRoute.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute";
            btAudioChannelMapperAddNewRoute.Size = new System.Drawing.Size(124, 44);
            btAudioChannelMapperAddNewRoute.TabIndex = 20;
            btAudioChannelMapperAddNewRoute.Text = "Add";
            btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = true;
            btAudioChannelMapperAddNewRoute.Click += btAudioChannelMapperAddNewRoute_Click;
            // 
            // label311
            // 
            label311.AutoSize = true;
            label311.Location = new System.Drawing.Point(342, 170);
            label311.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label311.Name = "label311";
            label311.Size = new System.Drawing.Size(109, 25);
            label311.TabIndex = 19;
            label311.Text = "10% - 200%";
            // 
            // tbAudioChannelMapperVolume
            // 
            tbAudioChannelMapperVolume.Location = new System.Drawing.Point(348, 80);
            tbAudioChannelMapperVolume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioChannelMapperVolume.Maximum = 2000;
            tbAudioChannelMapperVolume.Minimum = 100;
            tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume";
            tbAudioChannelMapperVolume.Size = new System.Drawing.Size(122, 69);
            tbAudioChannelMapperVolume.TabIndex = 18;
            tbAudioChannelMapperVolume.Value = 1000;
            // 
            // label310
            // 
            label310.AutoSize = true;
            label310.Location = new System.Drawing.Point(342, 48);
            label310.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label310.Name = "label310";
            label310.Size = new System.Drawing.Size(72, 25);
            label310.TabIndex = 17;
            label310.Text = "Volume";
            // 
            // edAudioChannelMapperTargetChannel
            // 
            edAudioChannelMapperTargetChannel.Location = new System.Drawing.Point(180, 80);
            edAudioChannelMapperTargetChannel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel";
            edAudioChannelMapperTargetChannel.Size = new System.Drawing.Size(82, 31);
            edAudioChannelMapperTargetChannel.TabIndex = 16;
            edAudioChannelMapperTargetChannel.Text = "0";
            // 
            // label309
            // 
            label309.AutoSize = true;
            label309.Location = new System.Drawing.Point(176, 48);
            label309.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label309.Name = "label309";
            label309.Size = new System.Drawing.Size(125, 25);
            label309.TabIndex = 15;
            label309.Text = "Target channel";
            // 
            // edAudioChannelMapperSourceChannel
            // 
            edAudioChannelMapperSourceChannel.Location = new System.Drawing.Point(24, 80);
            edAudioChannelMapperSourceChannel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel";
            edAudioChannelMapperSourceChannel.Size = new System.Drawing.Size(82, 31);
            edAudioChannelMapperSourceChannel.TabIndex = 14;
            edAudioChannelMapperSourceChannel.Text = "0";
            // 
            // label308
            // 
            label308.AutoSize = true;
            label308.Location = new System.Drawing.Point(20, 48);
            label308.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label308.Name = "label308";
            label308.Size = new System.Drawing.Size(131, 25);
            label308.TabIndex = 13;
            label308.Text = "Source channel";
            // 
            // label307
            // 
            label307.AutoSize = true;
            label307.Location = new System.Drawing.Point(16, 194);
            label307.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label307.Name = "label307";
            label307.Size = new System.Drawing.Size(66, 25);
            label307.TabIndex = 19;
            label307.Text = "Routes";
            // 
            // edAudioChannelMapperOutputChannels
            // 
            edAudioChannelMapperOutputChannels.Location = new System.Drawing.Point(20, 119);
            edAudioChannelMapperOutputChannels.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels";
            edAudioChannelMapperOutputChannels.Size = new System.Drawing.Size(66, 31);
            edAudioChannelMapperOutputChannels.TabIndex = 18;
            edAudioChannelMapperOutputChannels.Text = "0";
            // 
            // label306
            // 
            label306.AutoSize = true;
            label306.Location = new System.Drawing.Point(16, 89);
            label306.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label306.Name = "label306";
            label306.Size = new System.Drawing.Size(458, 25);
            label306.TabIndex = 17;
            label306.Text = "Output channels count (0 to use original channels count)";
            // 
            // lbAudioChannelMapperRoutes
            // 
            lbAudioChannelMapperRoutes.FormattingEnabled = true;
            lbAudioChannelMapperRoutes.ItemHeight = 25;
            lbAudioChannelMapperRoutes.Location = new System.Drawing.Point(20, 230);
            lbAudioChannelMapperRoutes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes";
            lbAudioChannelMapperRoutes.Size = new System.Drawing.Size(442, 179);
            lbAudioChannelMapperRoutes.TabIndex = 16;
            // 
            // cbAudioChannelMapperEnabled
            // 
            cbAudioChannelMapperEnabled.AutoSize = true;
            cbAudioChannelMapperEnabled.Location = new System.Drawing.Point(20, 22);
            cbAudioChannelMapperEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled";
            cbAudioChannelMapperEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioChannelMapperEnabled.TabIndex = 15;
            cbAudioChannelMapperEnabled.Text = "Enabled";
            cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage28
            // 
            tabPage28.Controls.Add(tbVUMeterBoost);
            tabPage28.Controls.Add(label382);
            tabPage28.Controls.Add(label381);
            tabPage28.Controls.Add(tbVUMeterAmplification);
            tabPage28.Controls.Add(cbVUMeterPro);
            tabPage28.Controls.Add(waveformPainter2);
            tabPage28.Controls.Add(waveformPainter1);
            tabPage28.Controls.Add(volumeMeter2);
            tabPage28.Controls.Add(volumeMeter1);
            tabPage28.Location = new System.Drawing.Point(4, 34);
            tabPage28.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage28.Name = "tabPage28";
            tabPage28.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage28.Size = new System.Drawing.Size(508, 957);
            tabPage28.TabIndex = 11;
            tabPage28.Text = "VU meter";
            tabPage28.UseVisualStyleBackColor = true;
            // 
            // tbVUMeterBoost
            // 
            tbVUMeterBoost.Location = new System.Drawing.Point(208, 269);
            tbVUMeterBoost.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVUMeterBoost.Maximum = 30;
            tbVUMeterBoost.Minimum = 1;
            tbVUMeterBoost.Name = "tbVUMeterBoost";
            tbVUMeterBoost.Size = new System.Drawing.Size(172, 69);
            tbVUMeterBoost.TabIndex = 122;
            tbVUMeterBoost.Value = 10;
            tbVUMeterBoost.Scroll += tbVUMeterBoost_Scroll;
            // 
            // label382
            // 
            label382.AutoSize = true;
            label382.Location = new System.Drawing.Point(202, 236);
            label382.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label382.Name = "label382";
            label382.Size = new System.Drawing.Size(118, 25);
            label382.TabIndex = 121;
            label382.Text = "Meters boost";
            // 
            // label381
            // 
            label381.AutoSize = true;
            label381.Location = new System.Drawing.Point(202, 111);
            label381.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label381.Name = "label381";
            label381.Size = new System.Drawing.Size(209, 25);
            label381.TabIndex = 120;
            label381.Text = "Volume amplification (%)";
            // 
            // tbVUMeterAmplification
            // 
            tbVUMeterAmplification.Location = new System.Drawing.Point(208, 142);
            tbVUMeterAmplification.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVUMeterAmplification.Maximum = 100;
            tbVUMeterAmplification.Name = "tbVUMeterAmplification";
            tbVUMeterAmplification.Size = new System.Drawing.Size(176, 69);
            tbVUMeterAmplification.TabIndex = 119;
            tbVUMeterAmplification.Value = 100;
            tbVUMeterAmplification.Scroll += tbVUMeterAmplification_Scroll;
            // 
            // cbVUMeterPro
            // 
            cbVUMeterPro.AutoSize = true;
            cbVUMeterPro.Location = new System.Drawing.Point(38, 45);
            cbVUMeterPro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVUMeterPro.Name = "cbVUMeterPro";
            cbVUMeterPro.Size = new System.Drawing.Size(201, 29);
            cbVUMeterPro.TabIndex = 115;
            cbVUMeterPro.Text = "Enable VU meter Pro";
            cbVUMeterPro.UseVisualStyleBackColor = true;
            // 
            // waveformPainter2
            // 
            waveformPainter2.Boost = 1F;
            waveformPainter2.Location = new System.Drawing.Point(24, 492);
            waveformPainter2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            waveformPainter2.Name = "waveformPainter2";
            waveformPainter2.Size = new System.Drawing.Size(450, 116);
            waveformPainter2.TabIndex = 118;
            waveformPainter2.Text = "waveformPainter2";
            // 
            // waveformPainter1
            // 
            waveformPainter1.Boost = 1F;
            waveformPainter1.Location = new System.Drawing.Point(24, 366);
            waveformPainter1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            waveformPainter1.Name = "waveformPainter1";
            waveformPainter1.Size = new System.Drawing.Size(450, 116);
            waveformPainter1.TabIndex = 117;
            waveformPainter1.Text = "waveformPainter1";
            // 
            // volumeMeter2
            // 
            volumeMeter2.Amplitude = 0F;
            volumeMeter2.BackColor = System.Drawing.Color.LightGray;
            volumeMeter2.Boost = 1F;
            volumeMeter2.Location = new System.Drawing.Point(100, 111);
            volumeMeter2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            volumeMeter2.MaxDb = 18F;
            volumeMeter2.MinDb = -60F;
            volumeMeter2.Name = "volumeMeter2";
            volumeMeter2.Size = new System.Drawing.Size(38, 242);
            volumeMeter2.TabIndex = 116;
            // 
            // volumeMeter1
            // 
            volumeMeter1.Amplitude = 0F;
            volumeMeter1.BackColor = System.Drawing.Color.LightGray;
            volumeMeter1.Boost = 1F;
            volumeMeter1.Location = new System.Drawing.Point(52, 111);
            volumeMeter1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            volumeMeter1.MaxDb = 18F;
            volumeMeter1.MinDb = -60F;
            volumeMeter1.Name = "volumeMeter1";
            volumeMeter1.Size = new System.Drawing.Size(38, 242);
            volumeMeter1.TabIndex = 114;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btOSDRenderLayers);
            tabPage5.Controls.Add(lbOSDLayers);
            tabPage5.Controls.Add(cbOSDEnabled);
            tabPage5.Controls.Add(groupBox19);
            tabPage5.Controls.Add(btOSDClearLayers);
            tabPage5.Controls.Add(groupBox15);
            tabPage5.Controls.Add(label108);
            tabPage5.Location = new System.Drawing.Point(4, 34);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Size = new System.Drawing.Size(508, 957);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "OSD";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btOSDRenderLayers
            // 
            btOSDRenderLayers.Location = new System.Drawing.Point(269, 398);
            btOSDRenderLayers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDRenderLayers.Name = "btOSDRenderLayers";
            btOSDRenderLayers.Size = new System.Drawing.Size(209, 44);
            btOSDRenderLayers.TabIndex = 16;
            btOSDRenderLayers.Text = "Render layers";
            btOSDRenderLayers.UseVisualStyleBackColor = true;
            btOSDRenderLayers.Click += btOSDRenderLayers_Click;
            // 
            // lbOSDLayers
            // 
            lbOSDLayers.CheckOnClick = true;
            lbOSDLayers.FormattingEnabled = true;
            lbOSDLayers.Location = new System.Drawing.Point(28, 131);
            lbOSDLayers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbOSDLayers.Name = "lbOSDLayers";
            lbOSDLayers.Size = new System.Drawing.Size(228, 172);
            lbOSDLayers.TabIndex = 15;
            lbOSDLayers.ItemCheck += lbOSDLayers_ItemCheck;
            // 
            // cbOSDEnabled
            // 
            cbOSDEnabled.AutoSize = true;
            cbOSDEnabled.Location = new System.Drawing.Point(28, 30);
            cbOSDEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbOSDEnabled.Name = "cbOSDEnabled";
            cbOSDEnabled.Size = new System.Drawing.Size(415, 29);
            cbOSDEnabled.TabIndex = 14;
            cbOSDEnabled.Text = "Enabled (should be set before playback started)";
            cbOSDEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(btOSDClearLayer);
            groupBox19.Controls.Add(tabControl6);
            groupBox19.Location = new System.Drawing.Point(24, 455);
            groupBox19.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox19.Name = "groupBox19";
            groupBox19.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox19.Size = new System.Drawing.Size(450, 481);
            groupBox19.TabIndex = 13;
            groupBox19.TabStop = false;
            groupBox19.Text = "Selected layer";
            // 
            // btOSDClearLayer
            // 
            btOSDClearLayer.Location = new System.Drawing.Point(18, 425);
            btOSDClearLayer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDClearLayer.Name = "btOSDClearLayer";
            btOSDClearLayer.Size = new System.Drawing.Size(151, 44);
            btOSDClearLayer.TabIndex = 2;
            btOSDClearLayer.Text = "Clear layer";
            btOSDClearLayer.UseVisualStyleBackColor = true;
            btOSDClearLayer.Click += btOSDClearLayer_Click;
            // 
            // tabControl6
            // 
            tabControl6.Controls.Add(tabPage30);
            tabControl6.Controls.Add(tabPage31);
            tabControl6.Controls.Add(tabPage32);
            tabControl6.Location = new System.Drawing.Point(18, 36);
            tabControl6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl6.Name = "tabControl6";
            tabControl6.SelectedIndex = 0;
            tabControl6.Size = new System.Drawing.Size(418, 378);
            tabControl6.TabIndex = 0;
            // 
            // tabPage30
            // 
            tabPage30.Controls.Add(btOSDImageDraw);
            tabPage30.Controls.Add(pnOSDColorKey);
            tabPage30.Controls.Add(cbOSDImageTranspColor);
            tabPage30.Controls.Add(edOSDImageTop);
            tabPage30.Controls.Add(label115);
            tabPage30.Controls.Add(edOSDImageLeft);
            tabPage30.Controls.Add(label114);
            tabPage30.Controls.Add(btOSDSelectImage);
            tabPage30.Controls.Add(edOSDImageFilename);
            tabPage30.Controls.Add(label113);
            tabPage30.Location = new System.Drawing.Point(4, 34);
            tabPage30.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage30.Name = "tabPage30";
            tabPage30.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage30.Size = new System.Drawing.Size(410, 340);
            tabPage30.TabIndex = 1;
            tabPage30.Text = "Image";
            tabPage30.UseVisualStyleBackColor = true;
            // 
            // btOSDImageDraw
            // 
            btOSDImageDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDImageDraw.Location = new System.Drawing.Point(298, 270);
            btOSDImageDraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDImageDraw.Name = "btOSDImageDraw";
            btOSDImageDraw.Size = new System.Drawing.Size(96, 44);
            btOSDImageDraw.TabIndex = 47;
            btOSDImageDraw.Text = "Draw";
            btOSDImageDraw.UseVisualStyleBackColor = true;
            btOSDImageDraw.Click += btOSDImageDraw_Click;
            // 
            // pnOSDColorKey
            // 
            pnOSDColorKey.BackColor = System.Drawing.Color.Fuchsia;
            pnOSDColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnOSDColorKey.Location = new System.Drawing.Point(269, 195);
            pnOSDColorKey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnOSDColorKey.Name = "pnOSDColorKey";
            pnOSDColorKey.Size = new System.Drawing.Size(40, 44);
            pnOSDColorKey.TabIndex = 45;
            pnOSDColorKey.Click += pnOSDColorKey_Click;
            // 
            // cbOSDImageTranspColor
            // 
            cbOSDImageTranspColor.AutoSize = true;
            cbOSDImageTranspColor.Location = new System.Drawing.Point(24, 195);
            cbOSDImageTranspColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbOSDImageTranspColor.Name = "cbOSDImageTranspColor";
            cbOSDImageTranspColor.Size = new System.Drawing.Size(218, 29);
            cbOSDImageTranspColor.TabIndex = 7;
            cbOSDImageTranspColor.Text = "Use transparency color";
            cbOSDImageTranspColor.UseVisualStyleBackColor = true;
            // 
            // edOSDImageTop
            // 
            edOSDImageTop.Location = new System.Drawing.Point(220, 130);
            edOSDImageTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDImageTop.Name = "edOSDImageTop";
            edOSDImageTop.Size = new System.Drawing.Size(62, 31);
            edOSDImageTop.TabIndex = 6;
            edOSDImageTop.Text = "0";
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Location = new System.Drawing.Point(169, 134);
            label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label115.Name = "label115";
            label115.Size = new System.Drawing.Size(41, 25);
            label115.TabIndex = 5;
            label115.Text = "Top";
            // 
            // edOSDImageLeft
            // 
            edOSDImageLeft.Location = new System.Drawing.Point(82, 130);
            edOSDImageLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDImageLeft.Name = "edOSDImageLeft";
            edOSDImageLeft.Size = new System.Drawing.Size(62, 31);
            edOSDImageLeft.TabIndex = 4;
            edOSDImageLeft.Text = "0";
            // 
            // label114
            // 
            label114.AutoSize = true;
            label114.Location = new System.Drawing.Point(20, 134);
            label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label114.Name = "label114";
            label114.Size = new System.Drawing.Size(41, 25);
            label114.TabIndex = 3;
            label114.Text = "Left";
            // 
            // btOSDSelectImage
            // 
            btOSDSelectImage.Location = new System.Drawing.Point(356, 58);
            btOSDSelectImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDSelectImage.Name = "btOSDSelectImage";
            btOSDSelectImage.Size = new System.Drawing.Size(38, 44);
            btOSDSelectImage.TabIndex = 2;
            btOSDSelectImage.Text = "...";
            btOSDSelectImage.UseVisualStyleBackColor = true;
            btOSDSelectImage.Click += btOSDSelectImage_Click;
            // 
            // edOSDImageFilename
            // 
            edOSDImageFilename.Location = new System.Drawing.Point(24, 61);
            edOSDImageFilename.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDImageFilename.Name = "edOSDImageFilename";
            edOSDImageFilename.Size = new System.Drawing.Size(316, 31);
            edOSDImageFilename.TabIndex = 1;
            edOSDImageFilename.Text = "c:\\logo.png";
            // 
            // label113
            // 
            label113.AutoSize = true;
            label113.Location = new System.Drawing.Point(20, 31);
            label113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label113.Name = "label113";
            label113.Size = new System.Drawing.Size(87, 25);
            label113.TabIndex = 0;
            label113.Text = "File name";
            // 
            // tabPage31
            // 
            tabPage31.Controls.Add(edOSDTextTop);
            tabPage31.Controls.Add(label117);
            tabPage31.Controls.Add(edOSDTextLeft);
            tabPage31.Controls.Add(label118);
            tabPage31.Controls.Add(label116);
            tabPage31.Controls.Add(btOSDSelectFont);
            tabPage31.Controls.Add(edOSDText);
            tabPage31.Controls.Add(btOSDTextDraw);
            tabPage31.Location = new System.Drawing.Point(4, 34);
            tabPage31.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage31.Name = "tabPage31";
            tabPage31.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage31.Size = new System.Drawing.Size(410, 340);
            tabPage31.TabIndex = 2;
            tabPage31.Text = "Text";
            tabPage31.UseVisualStyleBackColor = true;
            // 
            // edOSDTextTop
            // 
            edOSDTextTop.Location = new System.Drawing.Point(220, 130);
            edOSDTextTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDTextTop.Name = "edOSDTextTop";
            edOSDTextTop.Size = new System.Drawing.Size(62, 31);
            edOSDTextTop.TabIndex = 55;
            edOSDTextTop.Text = "0";
            // 
            // label117
            // 
            label117.AutoSize = true;
            label117.Location = new System.Drawing.Point(169, 134);
            label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label117.Name = "label117";
            label117.Size = new System.Drawing.Size(41, 25);
            label117.TabIndex = 54;
            label117.Text = "Top";
            // 
            // edOSDTextLeft
            // 
            edOSDTextLeft.Location = new System.Drawing.Point(82, 130);
            edOSDTextLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDTextLeft.Name = "edOSDTextLeft";
            edOSDTextLeft.Size = new System.Drawing.Size(62, 31);
            edOSDTextLeft.TabIndex = 53;
            edOSDTextLeft.Text = "0";
            // 
            // label118
            // 
            label118.AutoSize = true;
            label118.Location = new System.Drawing.Point(20, 134);
            label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label118.Name = "label118";
            label118.Size = new System.Drawing.Size(41, 25);
            label118.TabIndex = 52;
            label118.Text = "Left";
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Location = new System.Drawing.Point(20, 31);
            label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label116.Name = "label116";
            label116.Size = new System.Drawing.Size(42, 25);
            label116.TabIndex = 51;
            label116.Text = "Text";
            // 
            // btOSDSelectFont
            // 
            btOSDSelectFont.Location = new System.Drawing.Point(330, 58);
            btOSDSelectFont.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDSelectFont.Name = "btOSDSelectFont";
            btOSDSelectFont.Size = new System.Drawing.Size(62, 44);
            btOSDSelectFont.TabIndex = 50;
            btOSDSelectFont.Text = "Font";
            btOSDSelectFont.UseVisualStyleBackColor = true;
            btOSDSelectFont.Click += btOSDSelectFont_Click;
            // 
            // edOSDText
            // 
            edOSDText.ForeColor = System.Drawing.SystemColors.WindowText;
            edOSDText.Location = new System.Drawing.Point(24, 61);
            edOSDText.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDText.Name = "edOSDText";
            edOSDText.Size = new System.Drawing.Size(296, 31);
            edOSDText.TabIndex = 49;
            edOSDText.Text = "Hello!!!";
            // 
            // btOSDTextDraw
            // 
            btOSDTextDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDTextDraw.Location = new System.Drawing.Point(298, 270);
            btOSDTextDraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDTextDraw.Name = "btOSDTextDraw";
            btOSDTextDraw.Size = new System.Drawing.Size(96, 44);
            btOSDTextDraw.TabIndex = 48;
            btOSDTextDraw.Text = "Draw";
            btOSDTextDraw.UseVisualStyleBackColor = true;
            btOSDTextDraw.Click += btOSDTextDraw_Click;
            // 
            // tabPage32
            // 
            tabPage32.Controls.Add(tbOSDTranspLevel);
            tabPage32.Controls.Add(btOSDSetTransp);
            tabPage32.Controls.Add(label119);
            tabPage32.Location = new System.Drawing.Point(4, 34);
            tabPage32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage32.Name = "tabPage32";
            tabPage32.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage32.Size = new System.Drawing.Size(410, 340);
            tabPage32.TabIndex = 3;
            tabPage32.Text = "Other";
            tabPage32.UseVisualStyleBackColor = true;
            // 
            // tbOSDTranspLevel
            // 
            tbOSDTranspLevel.BackColor = System.Drawing.SystemColors.Window;
            tbOSDTranspLevel.Location = new System.Drawing.Point(24, 61);
            tbOSDTranspLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbOSDTranspLevel.Maximum = 255;
            tbOSDTranspLevel.Name = "tbOSDTranspLevel";
            tbOSDTranspLevel.Size = new System.Drawing.Size(238, 69);
            tbOSDTranspLevel.TabIndex = 3;
            tbOSDTranspLevel.TickFrequency = 10;
            // 
            // btOSDSetTransp
            // 
            btOSDSetTransp.Location = new System.Drawing.Point(298, 80);
            btOSDSetTransp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDSetTransp.Name = "btOSDSetTransp";
            btOSDSetTransp.Size = new System.Drawing.Size(80, 44);
            btOSDSetTransp.TabIndex = 2;
            btOSDSetTransp.Text = "Set";
            btOSDSetTransp.UseVisualStyleBackColor = true;
            btOSDSetTransp.Click += btOSDSetTransp_Click;
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Location = new System.Drawing.Point(20, 31);
            label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label119.Name = "label119";
            label119.Size = new System.Drawing.Size(154, 25);
            label119.TabIndex = 0;
            label119.Text = "Transparency level";
            // 
            // btOSDClearLayers
            // 
            btOSDClearLayers.Location = new System.Drawing.Point(28, 398);
            btOSDClearLayers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDClearLayers.Name = "btOSDClearLayers";
            btOSDClearLayers.Size = new System.Drawing.Size(232, 44);
            btOSDClearLayers.TabIndex = 12;
            btOSDClearLayers.Text = "Remove all layers";
            btOSDClearLayers.UseVisualStyleBackColor = true;
            btOSDClearLayers.Click += btOSDClearLayers_Click;
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(btOSDLayerAdd);
            groupBox15.Controls.Add(edOSDLayerHeight);
            groupBox15.Controls.Add(label111);
            groupBox15.Controls.Add(edOSDLayerWidth);
            groupBox15.Controls.Add(label112);
            groupBox15.Controls.Add(edOSDLayerTop);
            groupBox15.Controls.Add(label110);
            groupBox15.Controls.Add(edOSDLayerLeft);
            groupBox15.Controls.Add(label109);
            groupBox15.Location = new System.Drawing.Point(269, 119);
            groupBox15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox15.Name = "groupBox15";
            groupBox15.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox15.Size = new System.Drawing.Size(209, 258);
            groupBox15.TabIndex = 11;
            groupBox15.TabStop = false;
            groupBox15.Text = "New layer";
            // 
            // btOSDLayerAdd
            // 
            btOSDLayerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDLayerAdd.Location = new System.Drawing.Point(51, 206);
            btOSDLayerAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOSDLayerAdd.Name = "btOSDLayerAdd";
            btOSDLayerAdd.Size = new System.Drawing.Size(92, 44);
            btOSDLayerAdd.TabIndex = 8;
            btOSDLayerAdd.Text = "Create";
            btOSDLayerAdd.UseVisualStyleBackColor = true;
            btOSDLayerAdd.Click += btOSDLayerAdd_Click;
            // 
            // edOSDLayerHeight
            // 
            edOSDLayerHeight.Location = new System.Drawing.Point(122, 156);
            edOSDLayerHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDLayerHeight.Name = "edOSDLayerHeight";
            edOSDLayerHeight.Size = new System.Drawing.Size(62, 31);
            edOSDLayerHeight.TabIndex = 7;
            edOSDLayerHeight.Text = "200";
            // 
            // label111
            // 
            label111.AutoSize = true;
            label111.Location = new System.Drawing.Point(118, 125);
            label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label111.Name = "label111";
            label111.Size = new System.Drawing.Size(65, 25);
            label111.TabIndex = 6;
            label111.Text = "Height";
            // 
            // edOSDLayerWidth
            // 
            edOSDLayerWidth.Location = new System.Drawing.Point(22, 156);
            edOSDLayerWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDLayerWidth.Name = "edOSDLayerWidth";
            edOSDLayerWidth.Size = new System.Drawing.Size(62, 31);
            edOSDLayerWidth.TabIndex = 5;
            edOSDLayerWidth.Text = "200";
            // 
            // label112
            // 
            label112.AutoSize = true;
            label112.Location = new System.Drawing.Point(18, 125);
            label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label112.Name = "label112";
            label112.Size = new System.Drawing.Size(60, 25);
            label112.TabIndex = 4;
            label112.Text = "Width";
            // 
            // edOSDLayerTop
            // 
            edOSDLayerTop.Location = new System.Drawing.Point(122, 81);
            edOSDLayerTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDLayerTop.Name = "edOSDLayerTop";
            edOSDLayerTop.Size = new System.Drawing.Size(62, 31);
            edOSDLayerTop.TabIndex = 3;
            edOSDLayerTop.Text = "0";
            // 
            // label110
            // 
            label110.AutoSize = true;
            label110.Location = new System.Drawing.Point(118, 50);
            label110.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label110.Name = "label110";
            label110.Size = new System.Drawing.Size(41, 25);
            label110.TabIndex = 2;
            label110.Text = "Top";
            // 
            // edOSDLayerLeft
            // 
            edOSDLayerLeft.Location = new System.Drawing.Point(22, 81);
            edOSDLayerLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOSDLayerLeft.Name = "edOSDLayerLeft";
            edOSDLayerLeft.Size = new System.Drawing.Size(62, 31);
            edOSDLayerLeft.TabIndex = 1;
            edOSDLayerLeft.Text = "0";
            // 
            // label109
            // 
            label109.AutoSize = true;
            label109.Location = new System.Drawing.Point(18, 50);
            label109.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label109.Name = "label109";
            label109.Size = new System.Drawing.Size(41, 25);
            label109.TabIndex = 0;
            label109.Text = "Left";
            // 
            // label108
            // 
            label108.AutoSize = true;
            label108.Location = new System.Drawing.Point(20, 98);
            label108.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label108.Name = "label108";
            label108.Size = new System.Drawing.Size(61, 25);
            label108.TabIndex = 9;
            label108.Text = "Layers";
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(tabControl5);
            tabPage12.Location = new System.Drawing.Point(4, 34);
            tabPage12.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage12.Name = "tabPage12";
            tabPage12.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage12.Size = new System.Drawing.Size(508, 957);
            tabPage12.TabIndex = 6;
            tabPage12.Text = "Decoders / Splitter";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            tabControl5.Controls.Add(tabPage33);
            tabControl5.Controls.Add(tabPage34);
            tabControl5.Controls.Add(tabPage47);
            tabControl5.Location = new System.Drawing.Point(10, 11);
            tabControl5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl5.Name = "tabControl5";
            tabControl5.SelectedIndex = 0;
            tabControl5.Size = new System.Drawing.Size(488, 922);
            tabControl5.TabIndex = 0;
            // 
            // tabPage33
            // 
            tabPage33.Controls.Add(cbCustomSplitter);
            tabPage33.Controls.Add(rbSplitterCustom);
            tabPage33.Controls.Add(rbSplitterDefault);
            tabPage33.Location = new System.Drawing.Point(4, 34);
            tabPage33.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage33.Name = "tabPage33";
            tabPage33.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage33.Size = new System.Drawing.Size(480, 884);
            tabPage33.TabIndex = 0;
            tabPage33.Text = "Splitter";
            tabPage33.UseVisualStyleBackColor = true;
            // 
            // cbCustomSplitter
            // 
            cbCustomSplitter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomSplitter.FormattingEnabled = true;
            cbCustomSplitter.Location = new System.Drawing.Point(60, 128);
            cbCustomSplitter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCustomSplitter.Name = "cbCustomSplitter";
            cbCustomSplitter.Size = new System.Drawing.Size(386, 33);
            cbCustomSplitter.Sorted = true;
            cbCustomSplitter.TabIndex = 27;
            // 
            // rbSplitterCustom
            // 
            rbSplitterCustom.AutoSize = true;
            rbSplitterCustom.Location = new System.Drawing.Point(28, 81);
            rbSplitterCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbSplitterCustom.Name = "rbSplitterCustom";
            rbSplitterCustom.Size = new System.Drawing.Size(99, 29);
            rbSplitterCustom.TabIndex = 1;
            rbSplitterCustom.Text = "Custom";
            rbSplitterCustom.UseVisualStyleBackColor = true;
            // 
            // rbSplitterDefault
            // 
            rbSplitterDefault.AutoSize = true;
            rbSplitterDefault.Checked = true;
            rbSplitterDefault.Location = new System.Drawing.Point(28, 30);
            rbSplitterDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbSplitterDefault.Name = "rbSplitterDefault";
            rbSplitterDefault.Size = new System.Drawing.Size(94, 29);
            rbSplitterDefault.TabIndex = 0;
            rbSplitterDefault.TabStop = true;
            rbSplitterDefault.Text = "Default";
            rbSplitterDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage34
            // 
            tabPage34.Controls.Add(rbVideoDecoderVFH264);
            tabPage34.Controls.Add(cbCustomVideoDecoder);
            tabPage34.Controls.Add(label28);
            tabPage34.Controls.Add(label27);
            tabPage34.Controls.Add(label26);
            tabPage34.Controls.Add(rbVideoDecoderCustom);
            tabPage34.Controls.Add(rbVideoDecoderFFDShow);
            tabPage34.Controls.Add(rbVideoDecoderMS);
            tabPage34.Controls.Add(rbVideoDecoderDefault);
            tabPage34.Location = new System.Drawing.Point(4, 34);
            tabPage34.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage34.Name = "tabPage34";
            tabPage34.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage34.Size = new System.Drawing.Size(480, 884);
            tabPage34.TabIndex = 1;
            tabPage34.Text = "Video decoder";
            tabPage34.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderVFH264
            // 
            rbVideoDecoderVFH264.AutoSize = true;
            rbVideoDecoderVFH264.Location = new System.Drawing.Point(28, 384);
            rbVideoDecoderVFH264.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoDecoderVFH264.Name = "rbVideoDecoderVFH264";
            rbVideoDecoderVFH264.Size = new System.Drawing.Size(241, 29);
            rbVideoDecoderVFH264.TabIndex = 26;
            rbVideoDecoderVFH264.TabStop = true;
            rbVideoDecoderVFH264.Text = "VisioForge H264 Decoder";
            rbVideoDecoderVFH264.UseVisualStyleBackColor = true;
            // 
            // cbCustomVideoDecoder
            // 
            cbCustomVideoDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomVideoDecoder.FormattingEnabled = true;
            cbCustomVideoDecoder.Location = new System.Drawing.Point(62, 495);
            cbCustomVideoDecoder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCustomVideoDecoder.Name = "cbCustomVideoDecoder";
            cbCustomVideoDecoder.Size = new System.Drawing.Size(386, 33);
            cbCustomVideoDecoder.Sorted = true;
            cbCustomVideoDecoder.TabIndex = 25;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(58, 325);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(159, 25);
            label28.TabIndex = 24;
            label28.Text = "and DVD playback";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(58, 281);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(404, 25);
            label27.TabIndex = 23;
            label27.Text = "To play DVD you must activate MPEG-2 decoding";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(58, 155);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(329, 25);
            label26.TabIndex = 22;
            label26.Text = "Available on Vista / 7 Premium and later";
            // 
            // rbVideoDecoderCustom
            // 
            rbVideoDecoderCustom.AutoSize = true;
            rbVideoDecoderCustom.Location = new System.Drawing.Point(28, 452);
            rbVideoDecoderCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoDecoderCustom.Name = "rbVideoDecoderCustom";
            rbVideoDecoderCustom.Size = new System.Drawing.Size(99, 29);
            rbVideoDecoderCustom.TabIndex = 21;
            rbVideoDecoderCustom.Text = "Custom";
            rbVideoDecoderCustom.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderFFDShow
            // 
            rbVideoDecoderFFDShow.AutoSize = true;
            rbVideoDecoderFFDShow.Location = new System.Drawing.Point(28, 222);
            rbVideoDecoderFFDShow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoDecoderFFDShow.Name = "rbVideoDecoderFFDShow";
            rbVideoDecoderFFDShow.Size = new System.Drawing.Size(112, 29);
            rbVideoDecoderFFDShow.TabIndex = 20;
            rbVideoDecoderFFDShow.Text = "FFDShow";
            rbVideoDecoderFFDShow.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderMS
            // 
            rbVideoDecoderMS.AutoSize = true;
            rbVideoDecoderMS.Location = new System.Drawing.Point(28, 98);
            rbVideoDecoderMS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoDecoderMS.Name = "rbVideoDecoderMS";
            rbVideoDecoderMS.Size = new System.Drawing.Size(317, 29);
            rbVideoDecoderMS.TabIndex = 19;
            rbVideoDecoderMS.Text = "Microsoft DTV/DVD Video Decoder";
            rbVideoDecoderMS.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderDefault
            // 
            rbVideoDecoderDefault.AutoSize = true;
            rbVideoDecoderDefault.Checked = true;
            rbVideoDecoderDefault.Location = new System.Drawing.Point(28, 30);
            rbVideoDecoderDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoDecoderDefault.Name = "rbVideoDecoderDefault";
            rbVideoDecoderDefault.Size = new System.Drawing.Size(94, 29);
            rbVideoDecoderDefault.TabIndex = 18;
            rbVideoDecoderDefault.TabStop = true;
            rbVideoDecoderDefault.Text = "Default";
            rbVideoDecoderDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage47
            // 
            tabPage47.Controls.Add(cbCustomAudioDecoder);
            tabPage47.Controls.Add(rbAudioDecoderCustom);
            tabPage47.Controls.Add(rbAudioDecoderDefault);
            tabPage47.Location = new System.Drawing.Point(4, 34);
            tabPage47.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage47.Name = "tabPage47";
            tabPage47.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage47.Size = new System.Drawing.Size(480, 884);
            tabPage47.TabIndex = 2;
            tabPage47.Text = "Audio decoder";
            tabPage47.UseVisualStyleBackColor = true;
            // 
            // cbCustomAudioDecoder
            // 
            cbCustomAudioDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomAudioDecoder.FormattingEnabled = true;
            cbCustomAudioDecoder.Location = new System.Drawing.Point(62, 128);
            cbCustomAudioDecoder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCustomAudioDecoder.Name = "cbCustomAudioDecoder";
            cbCustomAudioDecoder.Size = new System.Drawing.Size(386, 33);
            cbCustomAudioDecoder.Sorted = true;
            cbCustomAudioDecoder.TabIndex = 30;
            // 
            // rbAudioDecoderCustom
            // 
            rbAudioDecoderCustom.AutoSize = true;
            rbAudioDecoderCustom.Location = new System.Drawing.Point(28, 81);
            rbAudioDecoderCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbAudioDecoderCustom.Name = "rbAudioDecoderCustom";
            rbAudioDecoderCustom.Size = new System.Drawing.Size(99, 29);
            rbAudioDecoderCustom.TabIndex = 29;
            rbAudioDecoderCustom.Text = "Custom";
            rbAudioDecoderCustom.UseVisualStyleBackColor = true;
            // 
            // rbAudioDecoderDefault
            // 
            rbAudioDecoderDefault.AutoSize = true;
            rbAudioDecoderDefault.Checked = true;
            rbAudioDecoderDefault.Location = new System.Drawing.Point(28, 30);
            rbAudioDecoderDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbAudioDecoderDefault.Name = "rbAudioDecoderDefault";
            rbAudioDecoderDefault.Size = new System.Drawing.Size(94, 29);
            rbAudioDecoderDefault.TabIndex = 28;
            rbAudioDecoderDefault.TabStop = true;
            rbAudioDecoderDefault.Text = "Default";
            rbAudioDecoderDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            tabPage13.Controls.Add(tabControl9);
            tabPage13.Controls.Add(cbMotDetEnabled);
            tabPage13.Location = new System.Drawing.Point(4, 34);
            tabPage13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage13.Name = "tabPage13";
            tabPage13.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage13.Size = new System.Drawing.Size(508, 957);
            tabPage13.TabIndex = 7;
            tabPage13.Text = "Motion detection";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabControl9
            // 
            tabControl9.Controls.Add(tabPage44);
            tabControl9.Controls.Add(tabPage45);
            tabControl9.Location = new System.Drawing.Point(24, 81);
            tabControl9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl9.Name = "tabControl9";
            tabControl9.SelectedIndex = 0;
            tabControl9.Size = new System.Drawing.Size(448, 794);
            tabControl9.TabIndex = 3;
            // 
            // tabPage44
            // 
            tabPage44.Controls.Add(pbMotionLevel);
            tabPage44.Controls.Add(label158);
            tabPage44.Controls.Add(mmMotDetMatrix);
            tabPage44.Location = new System.Drawing.Point(4, 34);
            tabPage44.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage44.Name = "tabPage44";
            tabPage44.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage44.Size = new System.Drawing.Size(440, 756);
            tabPage44.TabIndex = 0;
            tabPage44.Text = "Output matrix";
            tabPage44.UseVisualStyleBackColor = true;
            // 
            // pbMotionLevel
            // 
            pbMotionLevel.Location = new System.Drawing.Point(10, 630);
            pbMotionLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbMotionLevel.Name = "pbMotionLevel";
            pbMotionLevel.Size = new System.Drawing.Size(378, 36);
            pbMotionLevel.TabIndex = 2;
            // 
            // label158
            // 
            label158.AutoSize = true;
            label158.Location = new System.Drawing.Point(9, 591);
            label158.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label158.Name = "label158";
            label158.Size = new System.Drawing.Size(110, 25);
            label158.TabIndex = 1;
            label158.Text = "Motion level";
            // 
            // mmMotDetMatrix
            // 
            mmMotDetMatrix.Location = new System.Drawing.Point(10, 11);
            mmMotDetMatrix.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmMotDetMatrix.Multiline = true;
            mmMotDetMatrix.Name = "mmMotDetMatrix";
            mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmMotDetMatrix.Size = new System.Drawing.Size(412, 498);
            mmMotDetMatrix.TabIndex = 0;
            // 
            // tabPage45
            // 
            tabPage45.Controls.Add(groupBox25);
            tabPage45.Controls.Add(btMotDetUpdateSettings);
            tabPage45.Controls.Add(groupBox27);
            tabPage45.Controls.Add(groupBox26);
            tabPage45.Controls.Add(groupBox24);
            tabPage45.Location = new System.Drawing.Point(4, 34);
            tabPage45.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage45.Name = "tabPage45";
            tabPage45.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage45.Size = new System.Drawing.Size(440, 756);
            tabPage45.TabIndex = 1;
            tabPage45.Text = "Settings";
            tabPage45.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            groupBox25.Controls.Add(cbMotDetHLColor);
            groupBox25.Controls.Add(label161);
            groupBox25.Controls.Add(label160);
            groupBox25.Controls.Add(cbMotDetHLEnabled);
            groupBox25.Controls.Add(tbMotDetHLThreshold);
            groupBox25.Location = new System.Drawing.Point(20, 198);
            groupBox25.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox25.Name = "groupBox25";
            groupBox25.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox25.Size = new System.Drawing.Size(389, 166);
            groupBox25.TabIndex = 1;
            groupBox25.TabStop = false;
            groupBox25.Text = "Color highlight";
            // 
            // cbMotDetHLColor
            // 
            cbMotDetHLColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMotDetHLColor.FormattingEnabled = true;
            cbMotDetHLColor.Items.AddRange(new object[] { "Red", "Green", "Blue" });
            cbMotDetHLColor.Location = new System.Drawing.Point(256, 114);
            cbMotDetHLColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotDetHLColor.Name = "cbMotDetHLColor";
            cbMotDetHLColor.Size = new System.Drawing.Size(114, 33);
            cbMotDetHLColor.TabIndex = 5;
            // 
            // label161
            // 
            label161.AutoSize = true;
            label161.Location = new System.Drawing.Point(248, 81);
            label161.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label161.Name = "label161";
            label161.Size = new System.Drawing.Size(55, 25);
            label161.TabIndex = 4;
            label161.Text = "Color";
            // 
            // label160
            // 
            label160.AutoSize = true;
            label160.Location = new System.Drawing.Point(50, 81);
            label160.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label160.Name = "label160";
            label160.Size = new System.Drawing.Size(90, 25);
            label160.TabIndex = 2;
            label160.Text = "Threshold";
            // 
            // cbMotDetHLEnabled
            // 
            cbMotDetHLEnabled.AutoSize = true;
            cbMotDetHLEnabled.Checked = true;
            cbMotDetHLEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            cbMotDetHLEnabled.Location = new System.Drawing.Point(22, 42);
            cbMotDetHLEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotDetHLEnabled.Name = "cbMotDetHLEnabled";
            cbMotDetHLEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetHLEnabled.TabIndex = 1;
            cbMotDetHLEnabled.Text = "Enabled";
            cbMotDetHLEnabled.UseVisualStyleBackColor = true;
            // 
            // tbMotDetHLThreshold
            // 
            tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window;
            tbMotDetHLThreshold.Location = new System.Drawing.Point(51, 111);
            tbMotDetHLThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbMotDetHLThreshold.Maximum = 255;
            tbMotDetHLThreshold.Name = "tbMotDetHLThreshold";
            tbMotDetHLThreshold.Size = new System.Drawing.Size(172, 69);
            tbMotDetHLThreshold.TabIndex = 3;
            tbMotDetHLThreshold.TickFrequency = 5;
            tbMotDetHLThreshold.Value = 25;
            // 
            // btMotDetUpdateSettings
            // 
            btMotDetUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btMotDetUpdateSettings.Location = new System.Drawing.Point(230, 689);
            btMotDetUpdateSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btMotDetUpdateSettings.Name = "btMotDetUpdateSettings";
            btMotDetUpdateSettings.Size = new System.Drawing.Size(178, 44);
            btMotDetUpdateSettings.TabIndex = 4;
            btMotDetUpdateSettings.Text = "Update settings";
            btMotDetUpdateSettings.UseVisualStyleBackColor = true;
            btMotDetUpdateSettings.Click += btMotDetUpdateSettings_Click;
            // 
            // groupBox27
            // 
            groupBox27.Controls.Add(edMotDetMatrixHeight);
            groupBox27.Controls.Add(label163);
            groupBox27.Controls.Add(edMotDetMatrixWidth);
            groupBox27.Controls.Add(label164);
            groupBox27.Location = new System.Drawing.Point(20, 511);
            groupBox27.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox27.Name = "groupBox27";
            groupBox27.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox27.Size = new System.Drawing.Size(389, 114);
            groupBox27.TabIndex = 3;
            groupBox27.TabStop = false;
            groupBox27.Text = "Matrix";
            // 
            // edMotDetMatrixHeight
            // 
            edMotDetMatrixHeight.Location = new System.Drawing.Point(242, 44);
            edMotDetMatrixHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMotDetMatrixHeight.Name = "edMotDetMatrixHeight";
            edMotDetMatrixHeight.Size = new System.Drawing.Size(56, 31);
            edMotDetMatrixHeight.TabIndex = 75;
            edMotDetMatrixHeight.Text = "10";
            // 
            // label163
            // 
            label163.AutoSize = true;
            label163.Location = new System.Drawing.Point(162, 50);
            label163.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label163.Name = "label163";
            label163.Size = new System.Drawing.Size(65, 25);
            label163.TabIndex = 74;
            label163.Text = "Height";
            // 
            // edMotDetMatrixWidth
            // 
            edMotDetMatrixWidth.Location = new System.Drawing.Point(92, 44);
            edMotDetMatrixWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMotDetMatrixWidth.Name = "edMotDetMatrixWidth";
            edMotDetMatrixWidth.Size = new System.Drawing.Size(56, 31);
            edMotDetMatrixWidth.TabIndex = 73;
            edMotDetMatrixWidth.Text = "10";
            // 
            // label164
            // 
            label164.AutoSize = true;
            label164.Location = new System.Drawing.Point(22, 50);
            label164.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label164.Name = "label164";
            label164.Size = new System.Drawing.Size(60, 25);
            label164.TabIndex = 72;
            label164.Text = "Width";
            // 
            // groupBox26
            // 
            groupBox26.Controls.Add(label162);
            groupBox26.Controls.Add(tbMotDetDropFramesThreshold);
            groupBox26.Controls.Add(cbMotDetDropFramesEnabled);
            groupBox26.Location = new System.Drawing.Point(20, 369);
            groupBox26.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox26.Name = "groupBox26";
            groupBox26.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox26.Size = new System.Drawing.Size(389, 131);
            groupBox26.TabIndex = 2;
            groupBox26.TabStop = false;
            groupBox26.Text = "Drop frames";
            // 
            // label162
            // 
            label162.AutoSize = true;
            label162.Location = new System.Drawing.Point(158, 41);
            label162.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label162.Name = "label162";
            label162.Size = new System.Drawing.Size(90, 25);
            label162.TabIndex = 4;
            label162.Text = "Threshold";
            // 
            // tbMotDetDropFramesThreshold
            // 
            tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window;
            tbMotDetDropFramesThreshold.Location = new System.Drawing.Point(158, 70);
            tbMotDetDropFramesThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbMotDetDropFramesThreshold.Maximum = 255;
            tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold";
            tbMotDetDropFramesThreshold.Size = new System.Drawing.Size(172, 69);
            tbMotDetDropFramesThreshold.TabIndex = 5;
            tbMotDetDropFramesThreshold.TickFrequency = 5;
            tbMotDetDropFramesThreshold.Value = 5;
            // 
            // cbMotDetDropFramesEnabled
            // 
            cbMotDetDropFramesEnabled.AutoSize = true;
            cbMotDetDropFramesEnabled.Location = new System.Drawing.Point(22, 36);
            cbMotDetDropFramesEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotDetDropFramesEnabled.Name = "cbMotDetDropFramesEnabled";
            cbMotDetDropFramesEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetDropFramesEnabled.TabIndex = 1;
            cbMotDetDropFramesEnabled.Text = "Enabled";
            cbMotDetDropFramesEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            groupBox24.Controls.Add(edMotDetFrameInterval);
            groupBox24.Controls.Add(label159);
            groupBox24.Controls.Add(cbCompareGreyscale);
            groupBox24.Controls.Add(cbCompareBlue);
            groupBox24.Controls.Add(cbCompareGreen);
            groupBox24.Controls.Add(cbCompareRed);
            groupBox24.Location = new System.Drawing.Point(20, 22);
            groupBox24.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox24.Name = "groupBox24";
            groupBox24.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox24.Size = new System.Drawing.Size(389, 158);
            groupBox24.TabIndex = 0;
            groupBox24.TabStop = false;
            groupBox24.Text = "Compare settings";
            // 
            // edMotDetFrameInterval
            // 
            edMotDetFrameInterval.Location = new System.Drawing.Point(158, 98);
            edMotDetFrameInterval.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMotDetFrameInterval.Name = "edMotDetFrameInterval";
            edMotDetFrameInterval.Size = new System.Drawing.Size(52, 31);
            edMotDetFrameInterval.TabIndex = 5;
            edMotDetFrameInterval.Text = "2";
            // 
            // label159
            // 
            label159.AutoSize = true;
            label159.Location = new System.Drawing.Point(18, 105);
            label159.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label159.Name = "label159";
            label159.Size = new System.Drawing.Size(123, 25);
            label159.TabIndex = 4;
            label159.Text = "Frame interval";
            // 
            // cbCompareGreyscale
            // 
            cbCompareGreyscale.AutoSize = true;
            cbCompareGreyscale.Checked = true;
            cbCompareGreyscale.CheckState = System.Windows.Forms.CheckState.Checked;
            cbCompareGreyscale.Location = new System.Drawing.Point(271, 41);
            cbCompareGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCompareGreyscale.Name = "cbCompareGreyscale";
            cbCompareGreyscale.Size = new System.Drawing.Size(112, 29);
            cbCompareGreyscale.TabIndex = 3;
            cbCompareGreyscale.Text = "Greyscale";
            cbCompareGreyscale.UseVisualStyleBackColor = true;
            // 
            // cbCompareBlue
            // 
            cbCompareBlue.AutoSize = true;
            cbCompareBlue.Location = new System.Drawing.Point(198, 41);
            cbCompareBlue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCompareBlue.Name = "cbCompareBlue";
            cbCompareBlue.Size = new System.Drawing.Size(71, 29);
            cbCompareBlue.TabIndex = 2;
            cbCompareBlue.Text = "Blue";
            cbCompareBlue.UseVisualStyleBackColor = true;
            // 
            // cbCompareGreen
            // 
            cbCompareGreen.AutoSize = true;
            cbCompareGreen.Location = new System.Drawing.Point(100, 41);
            cbCompareGreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCompareGreen.Name = "cbCompareGreen";
            cbCompareGreen.Size = new System.Drawing.Size(84, 29);
            cbCompareGreen.TabIndex = 1;
            cbCompareGreen.Text = "Green";
            cbCompareGreen.UseVisualStyleBackColor = true;
            // 
            // cbCompareRed
            // 
            cbCompareRed.AutoSize = true;
            cbCompareRed.Location = new System.Drawing.Point(22, 41);
            cbCompareRed.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCompareRed.Name = "cbCompareRed";
            cbCompareRed.Size = new System.Drawing.Size(68, 29);
            cbCompareRed.TabIndex = 0;
            cbCompareRed.Text = "Red";
            cbCompareRed.UseVisualStyleBackColor = true;
            // 
            // cbMotDetEnabled
            // 
            cbMotDetEnabled.AutoSize = true;
            cbMotDetEnabled.Location = new System.Drawing.Point(24, 31);
            cbMotDetEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotDetEnabled.Name = "cbMotDetEnabled";
            cbMotDetEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetEnabled.TabIndex = 2;
            cbMotDetEnabled.Text = "Enabled";
            cbMotDetEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            tabPage14.Controls.Add(label505);
            tabPage14.Controls.Add(rbMotionDetectionExProcessor);
            tabPage14.Controls.Add(label389);
            tabPage14.Controls.Add(rbMotionDetectionExDetector);
            tabPage14.Controls.Add(label64);
            tabPage14.Controls.Add(label65);
            tabPage14.Controls.Add(pbAFMotionLevel);
            tabPage14.Controls.Add(cbMotionDetectionEx);
            tabPage14.Location = new System.Drawing.Point(4, 34);
            tabPage14.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage14.Name = "tabPage14";
            tabPage14.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage14.Size = new System.Drawing.Size(508, 957);
            tabPage14.TabIndex = 14;
            tabPage14.Text = "Motion detection (Extended)";
            tabPage14.UseVisualStyleBackColor = true;
            // 
            // label505
            // 
            label505.AutoSize = true;
            label505.Location = new System.Drawing.Point(28, 192);
            label505.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label505.Name = "label505";
            label505.Size = new System.Drawing.Size(89, 25);
            label505.TabIndex = 31;
            label505.Text = "Processor";
            // 
            // rbMotionDetectionExProcessor
            // 
            rbMotionDetectionExProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rbMotionDetectionExProcessor.FormattingEnabled = true;
            rbMotionDetectionExProcessor.Items.AddRange(new object[] { "None", "Blob counting objects", "GridMotionAreaProcessing", "Motion area highlighting", "Motion border highlighting" });
            rbMotionDetectionExProcessor.Location = new System.Drawing.Point(28, 222);
            rbMotionDetectionExProcessor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbMotionDetectionExProcessor.Name = "rbMotionDetectionExProcessor";
            rbMotionDetectionExProcessor.Size = new System.Drawing.Size(426, 33);
            rbMotionDetectionExProcessor.TabIndex = 30;
            // 
            // label389
            // 
            label389.AutoSize = true;
            label389.Location = new System.Drawing.Point(28, 95);
            label389.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label389.Name = "label389";
            label389.Size = new System.Drawing.Size(80, 25);
            label389.TabIndex = 29;
            label389.Text = "Detector";
            // 
            // rbMotionDetectionExDetector
            // 
            rbMotionDetectionExDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rbMotionDetectionExDetector.FormattingEnabled = true;
            rbMotionDetectionExDetector.Items.AddRange(new object[] { "Custom frame difference", "Simple background modeling", "Two frames difference" });
            rbMotionDetectionExDetector.Location = new System.Drawing.Point(28, 128);
            rbMotionDetectionExDetector.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbMotionDetectionExDetector.Name = "rbMotionDetectionExDetector";
            rbMotionDetectionExDetector.Size = new System.Drawing.Size(426, 33);
            rbMotionDetectionExDetector.TabIndex = 28;
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new System.Drawing.Point(89, 842);
            label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(293, 25);
            label64.TabIndex = 27;
            label64.Text = "Much more options available in API";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new System.Drawing.Point(28, 305);
            label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(110, 25);
            label65.TabIndex = 26;
            label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            pbAFMotionLevel.Location = new System.Drawing.Point(28, 334);
            pbAFMotionLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbAFMotionLevel.Name = "pbAFMotionLevel";
            pbAFMotionLevel.Size = new System.Drawing.Size(430, 44);
            pbAFMotionLevel.TabIndex = 25;
            // 
            // cbMotionDetectionEx
            // 
            cbMotionDetectionEx.AutoSize = true;
            cbMotionDetectionEx.Location = new System.Drawing.Point(28, 22);
            cbMotionDetectionEx.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotionDetectionEx.Name = "cbMotionDetectionEx";
            cbMotionDetectionEx.Size = new System.Drawing.Size(101, 29);
            cbMotionDetectionEx.TabIndex = 24;
            cbMotionDetectionEx.Text = "Enabled";
            cbMotionDetectionEx.UseVisualStyleBackColor = true;
            // 
            // tabPage21
            // 
            tabPage21.Controls.Add(edBarcodeMetadata);
            tabPage21.Controls.Add(label91);
            tabPage21.Controls.Add(cbBarcodeType);
            tabPage21.Controls.Add(label90);
            tabPage21.Controls.Add(btBarcodeReset);
            tabPage21.Controls.Add(edBarcode);
            tabPage21.Controls.Add(label89);
            tabPage21.Controls.Add(cbBarcodeDetectionEnabled);
            tabPage21.Location = new System.Drawing.Point(4, 34);
            tabPage21.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage21.Name = "tabPage21";
            tabPage21.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            tabPage21.Size = new System.Drawing.Size(508, 957);
            tabPage21.TabIndex = 8;
            tabPage21.Text = "Barcode reader";
            tabPage21.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            edBarcodeMetadata.Location = new System.Drawing.Point(28, 308);
            edBarcodeMetadata.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            edBarcodeMetadata.Multiline = true;
            edBarcodeMetadata.Name = "edBarcodeMetadata";
            edBarcodeMetadata.Size = new System.Drawing.Size(452, 182);
            edBarcodeMetadata.TabIndex = 16;
            // 
            // label91
            // 
            label91.AutoSize = true;
            label91.Location = new System.Drawing.Point(22, 270);
            label91.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label91.Name = "label91";
            label91.Size = new System.Drawing.Size(87, 25);
            label91.TabIndex = 15;
            label91.Text = "Metadata";
            // 
            // cbBarcodeType
            // 
            cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBarcodeType.FormattingEnabled = true;
            cbBarcodeType.Items.AddRange(new object[] { "Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417" });
            cbBarcodeType.Location = new System.Drawing.Point(28, 122);
            cbBarcodeType.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            cbBarcodeType.Name = "cbBarcodeType";
            cbBarcodeType.Size = new System.Drawing.Size(264, 33);
            cbBarcodeType.TabIndex = 14;
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Location = new System.Drawing.Point(22, 92);
            label90.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label90.Name = "label90";
            label90.Size = new System.Drawing.Size(116, 25);
            label90.TabIndex = 13;
            label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            btBarcodeReset.Location = new System.Drawing.Point(28, 516);
            btBarcodeReset.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            btBarcodeReset.Name = "btBarcodeReset";
            btBarcodeReset.Size = new System.Drawing.Size(102, 44);
            btBarcodeReset.TabIndex = 12;
            btBarcodeReset.Text = "Restart";
            btBarcodeReset.UseVisualStyleBackColor = true;
            btBarcodeReset.Click += btBarcodeReset_Click;
            // 
            // edBarcode
            // 
            edBarcode.Location = new System.Drawing.Point(28, 216);
            edBarcode.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            edBarcode.Name = "edBarcode";
            edBarcode.Size = new System.Drawing.Size(452, 31);
            edBarcode.TabIndex = 11;
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Location = new System.Drawing.Point(22, 184);
            label89.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label89.Name = "label89";
            label89.Size = new System.Drawing.Size(153, 25);
            label89.TabIndex = 10;
            label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            cbBarcodeDetectionEnabled.AutoSize = true;
            cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(28, 34);
            cbBarcodeDetectionEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(101, 29);
            cbBarcodeDetectionEnabled.TabIndex = 9;
            cbBarcodeDetectionEnabled.Text = "Enabled";
            cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage23
            // 
            tabPage23.Controls.Add(textBox1);
            tabPage23.Controls.Add(groupBox48);
            tabPage23.Location = new System.Drawing.Point(4, 34);
            tabPage23.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage23.Name = "tabPage23";
            tabPage23.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage23.Size = new System.Drawing.Size(508, 957);
            tabPage23.TabIndex = 9;
            tabPage23.Text = "Encryption";
            tabPage23.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(28, 470);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(446, 149);
            textBox1.TabIndex = 11;
            textBox1.Text = "Media Player SDK .Net can play encrypted files created by Video Encryption SDK (DirectShow or included in Video Capture SDK .Net / Video Edit SDK .Net).";
            // 
            // groupBox48
            // 
            groupBox48.Controls.Add(label343);
            groupBox48.Controls.Add(edEncryptionKeyHEX);
            groupBox48.Controls.Add(rbEncryptionKeyBinary);
            groupBox48.Controls.Add(btEncryptionOpenFile);
            groupBox48.Controls.Add(edEncryptionKeyFile);
            groupBox48.Controls.Add(rbEncryptionKeyFile);
            groupBox48.Controls.Add(edEncryptionKeyString);
            groupBox48.Controls.Add(rbEncryptionKeyString);
            groupBox48.Location = new System.Drawing.Point(28, 30);
            groupBox48.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox48.Name = "groupBox48";
            groupBox48.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox48.Size = new System.Drawing.Size(449, 431);
            groupBox48.TabIndex = 9;
            groupBox48.TabStop = false;
            groupBox48.Text = "Encryption key type";
            // 
            // label343
            // 
            label343.AutoSize = true;
            label343.Location = new System.Drawing.Point(56, 381);
            label343.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label343.Name = "label343";
            label343.Size = new System.Drawing.Size(258, 25);
            label343.TabIndex = 10;
            label343.Text = "You can assign byte[] using API";
            // 
            // edEncryptionKeyHEX
            // 
            edEncryptionKeyHEX.Location = new System.Drawing.Point(60, 339);
            edEncryptionKeyHEX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edEncryptionKeyHEX.Name = "edEncryptionKeyHEX";
            edEncryptionKeyHEX.Size = new System.Drawing.Size(354, 31);
            edEncryptionKeyHEX.TabIndex = 9;
            edEncryptionKeyHEX.Text = "enter hex data";
            // 
            // rbEncryptionKeyBinary
            // 
            rbEncryptionKeyBinary.AutoSize = true;
            rbEncryptionKeyBinary.Location = new System.Drawing.Point(22, 294);
            rbEncryptionKeyBinary.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionKeyBinary.Name = "rbEncryptionKeyBinary";
            rbEncryptionKeyBinary.Size = new System.Drawing.Size(197, 29);
            rbEncryptionKeyBinary.TabIndex = 8;
            rbEncryptionKeyBinary.Text = "Binary data (v9 SDK)";
            rbEncryptionKeyBinary.UseVisualStyleBackColor = true;
            // 
            // btEncryptionOpenFile
            // 
            btEncryptionOpenFile.Location = new System.Drawing.Point(378, 219);
            btEncryptionOpenFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btEncryptionOpenFile.Name = "btEncryptionOpenFile";
            btEncryptionOpenFile.Size = new System.Drawing.Size(38, 44);
            btEncryptionOpenFile.TabIndex = 7;
            btEncryptionOpenFile.Text = "...";
            btEncryptionOpenFile.UseVisualStyleBackColor = true;
            btEncryptionOpenFile.Click += btEncryptionOpenFile_Click;
            // 
            // edEncryptionKeyFile
            // 
            edEncryptionKeyFile.Location = new System.Drawing.Point(60, 222);
            edEncryptionKeyFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edEncryptionKeyFile.Name = "edEncryptionKeyFile";
            edEncryptionKeyFile.Size = new System.Drawing.Size(306, 31);
            edEncryptionKeyFile.TabIndex = 6;
            edEncryptionKeyFile.Text = "c:\\keyfile.txt";
            // 
            // rbEncryptionKeyFile
            // 
            rbEncryptionKeyFile.AutoSize = true;
            rbEncryptionKeyFile.Location = new System.Drawing.Point(22, 180);
            rbEncryptionKeyFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionKeyFile.Name = "rbEncryptionKeyFile";
            rbEncryptionKeyFile.Size = new System.Drawing.Size(135, 29);
            rbEncryptionKeyFile.TabIndex = 5;
            rbEncryptionKeyFile.Text = "File (v9 SDK)";
            rbEncryptionKeyFile.UseVisualStyleBackColor = true;
            // 
            // edEncryptionKeyString
            // 
            edEncryptionKeyString.Location = new System.Drawing.Point(60, 108);
            edEncryptionKeyString.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edEncryptionKeyString.Name = "edEncryptionKeyString";
            edEncryptionKeyString.Size = new System.Drawing.Size(354, 31);
            edEncryptionKeyString.TabIndex = 4;
            edEncryptionKeyString.Text = "100";
            // 
            // rbEncryptionKeyString
            // 
            rbEncryptionKeyString.AutoSize = true;
            rbEncryptionKeyString.Checked = true;
            rbEncryptionKeyString.Location = new System.Drawing.Point(22, 55);
            rbEncryptionKeyString.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionKeyString.Name = "rbEncryptionKeyString";
            rbEncryptionKeyString.Size = new System.Drawing.Size(83, 29);
            rbEncryptionKeyString.TabIndex = 0;
            rbEncryptionKeyString.TabStop = true;
            rbEncryptionKeyString.Text = "String";
            rbEncryptionKeyString.UseVisualStyleBackColor = true;
            // 
            // tabPage24
            // 
            tabPage24.Controls.Add(btReversePlaybackNextFrame);
            tabPage24.Controls.Add(btReversePlaybackPrevFrame);
            tabPage24.Controls.Add(label34);
            tabPage24.Controls.Add(label33);
            tabPage24.Controls.Add(btReversePlayback);
            tabPage24.Controls.Add(edReversePlaybackCacheSize);
            tabPage24.Controls.Add(label32);
            tabPage24.Controls.Add(tbReversePlaybackTrackbar);
            tabPage24.Location = new System.Drawing.Point(4, 34);
            tabPage24.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage24.Name = "tabPage24";
            tabPage24.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage24.Size = new System.Drawing.Size(508, 957);
            tabPage24.TabIndex = 10;
            tabPage24.Text = "Reverse playback";
            tabPage24.UseVisualStyleBackColor = true;
            // 
            // btReversePlaybackNextFrame
            // 
            btReversePlaybackNextFrame.Location = new System.Drawing.Point(218, 389);
            btReversePlaybackNextFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btReversePlaybackNextFrame.Name = "btReversePlaybackNextFrame";
            btReversePlaybackNextFrame.Size = new System.Drawing.Size(176, 44);
            btReversePlaybackNextFrame.TabIndex = 12;
            btReversePlaybackNextFrame.Text = "Next frame";
            btReversePlaybackNextFrame.UseVisualStyleBackColor = true;
            btReversePlaybackNextFrame.Click += btReversePlaybackNextFrame_Click;
            // 
            // btReversePlaybackPrevFrame
            // 
            btReversePlaybackPrevFrame.Location = new System.Drawing.Point(31, 389);
            btReversePlaybackPrevFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btReversePlaybackPrevFrame.Name = "btReversePlaybackPrevFrame";
            btReversePlaybackPrevFrame.Size = new System.Drawing.Size(176, 44);
            btReversePlaybackPrevFrame.TabIndex = 11;
            btReversePlaybackPrevFrame.Text = "Previous frame";
            btReversePlaybackPrevFrame.UseVisualStyleBackColor = true;
            btReversePlaybackPrevFrame.Click += btReversePlaybackPrevFrame_Click;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(28, 222);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(182, 25);
            label34.TabIndex = 10;
            label34.Text = "count before tracking";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new System.Drawing.Point(28, 191);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(377, 25);
            label33.TabIndex = 9;
            label33.Text = "Wait several seconds to cache required frames";
            // 
            // btReversePlayback
            // 
            btReversePlayback.Location = new System.Drawing.Point(31, 122);
            btReversePlayback.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btReversePlayback.Name = "btReversePlayback";
            btReversePlayback.Size = new System.Drawing.Size(318, 44);
            btReversePlayback.TabIndex = 8;
            btReversePlayback.Text = "Go to reverse playback mode";
            btReversePlayback.UseVisualStyleBackColor = true;
            btReversePlayback.Click += btReversePlayback_Click;
            // 
            // edReversePlaybackCacheSize
            // 
            edReversePlaybackCacheSize.Location = new System.Drawing.Point(238, 30);
            edReversePlaybackCacheSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edReversePlaybackCacheSize.Name = "edReversePlaybackCacheSize";
            edReversePlaybackCacheSize.Size = new System.Drawing.Size(108, 31);
            edReversePlaybackCacheSize.TabIndex = 7;
            edReversePlaybackCacheSize.Text = "100";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(28, 34);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(144, 25);
            label32.TabIndex = 6;
            label32.Text = "Frame cache size";
            // 
            // tbReversePlaybackTrackbar
            // 
            tbReversePlaybackTrackbar.Location = new System.Drawing.Point(31, 272);
            tbReversePlaybackTrackbar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbReversePlaybackTrackbar.Maximum = 100;
            tbReversePlaybackTrackbar.Name = "tbReversePlaybackTrackbar";
            tbReversePlaybackTrackbar.Size = new System.Drawing.Size(318, 69);
            tbReversePlaybackTrackbar.TabIndex = 4;
            tbReversePlaybackTrackbar.Value = 100;
            tbReversePlaybackTrackbar.Scroll += tbReversePlaybackTrackbar_Scroll;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(544, 22);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(145, 25);
            label14.TabIndex = 2;
            label14.Text = "File name or URL";
            // 
            // edFilenameOrURL
            // 
            edFilenameOrURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            edFilenameOrURL.Location = new System.Drawing.Point(550, 55);
            edFilenameOrURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFilenameOrURL.Name = "edFilenameOrURL";
            edFilenameOrURL.Size = new System.Drawing.Size(576, 31);
            edFilenameOrURL.TabIndex = 3;
            edFilenameOrURL.Text = "c:\\samples\\!video.mp4";
            // 
            // btSelectFile
            // 
            btSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btSelectFile.Location = new System.Drawing.Point(1204, 50);
            btSelectFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(38, 44);
            btSelectFile.TabIndex = 4;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btPreviousFrame);
            groupBox2.Controls.Add(cbLoop);
            groupBox2.Controls.Add(btNextFrame);
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(tbSpeed);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(lbTime);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(550, 757);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Size = new System.Drawing.Size(690, 172);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btPreviousFrame
            // 
            btPreviousFrame.Location = new System.Drawing.Point(420, 111);
            btPreviousFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btPreviousFrame.Name = "btPreviousFrame";
            btPreviousFrame.Size = new System.Drawing.Size(124, 44);
            btPreviousFrame.TabIndex = 10;
            btPreviousFrame.Text = "Prev frame";
            btPreviousFrame.UseVisualStyleBackColor = true;
            btPreviousFrame.Click += btPreviousFrame_Click;
            // 
            // cbLoop
            // 
            cbLoop.AutoSize = true;
            cbLoop.Location = new System.Drawing.Point(368, 22);
            cbLoop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbLoop.Name = "cbLoop";
            cbLoop.Size = new System.Drawing.Size(79, 29);
            cbLoop.TabIndex = 9;
            cbLoop.Text = "Loop";
            cbLoop.UseVisualStyleBackColor = true;
            // 
            // btNextFrame
            // 
            btNextFrame.Location = new System.Drawing.Point(556, 111);
            btNextFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btNextFrame.Name = "btNextFrame";
            btNextFrame.Size = new System.Drawing.Size(124, 44);
            btNextFrame.TabIndex = 8;
            btNextFrame.Text = "Next frame";
            btNextFrame.UseVisualStyleBackColor = true;
            btNextFrame.Click += btNextFrame_Click;
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStop.Location = new System.Drawing.Point(300, 111);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(78, 44);
            btStop.TabIndex = 7;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(202, 111);
            btPause.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(88, 44);
            btPause.TabIndex = 6;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(91, 111);
            btResume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(102, 44);
            btResume.TabIndex = 5;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(10, 111);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(71, 44);
            btStart.TabIndex = 4;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new System.Drawing.Point(536, 52);
            tbSpeed.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSpeed.Maximum = 25;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new System.Drawing.Size(149, 69);
            tbSpeed.TabIndex = 3;
            tbSpeed.Value = 10;
            tbSpeed.Scroll += tbSpeed_Scroll;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(538, 20);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(62, 25);
            label16.TabIndex = 2;
            label16.Text = "Speed";
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(362, 61);
            lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(155, 25);
            lbTime.TabIndex = 1;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Location = new System.Drawing.Point(10, 36);
            tbTimeline.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(344, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // fontDialog1
            // 
            fontDialog1.Color = System.Drawing.Color.White;
            fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            fontDialog1.FontMustExist = true;
            fontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(548, 217);
            label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(118, 25);
            label29.TabIndex = 14;
            label29.Text = "Source mode";
            // 
            // cbSourceMode
            // 
            cbSourceMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSourceMode.FormattingEnabled = true;
            cbSourceMode.Items.AddRange(new object[] { "File / Network stream (decode using LAV) ", "File / Network stream (decode using GPU) ", "File / Network stream (decode using FFMPEG)", "File (decode using DirectShow)", "File (decode using VLC)", "Blu-Ray", "File from memory (decode using DirectShow)", "MMS / WMV (network stream)", "HTTP / RTSP / RTMP (decoding using VLC)", "Encrypted file (decode using DirectShow)", "MIDI / KAR" });
            cbSourceMode.Location = new System.Drawing.Point(720, 214);
            cbSourceMode.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            cbSourceMode.Name = "cbSourceMode";
            cbSourceMode.Size = new System.Drawing.Size(524, 33);
            cbSourceMode.TabIndex = 15;
            // 
            // lbSourceFiles
            // 
            lbSourceFiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbSourceFiles.ContextMenuStrip = mnPlaylist;
            lbSourceFiles.FormattingEnabled = true;
            lbSourceFiles.ItemHeight = 25;
            lbSourceFiles.Location = new System.Drawing.Point(550, 125);
            lbSourceFiles.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            lbSourceFiles.Name = "lbSourceFiles";
            lbSourceFiles.Size = new System.Drawing.Size(692, 79);
            lbSourceFiles.TabIndex = 16;
            // 
            // mnPlaylist
            // 
            mnPlaylist.ImageScalingSize = new System.Drawing.Size(24, 24);
            mnPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnPlaylistRemove, mnPlaylistRemoveAll });
            mnPlaylist.Name = "mnPlaylist";
            mnPlaylist.Size = new System.Drawing.Size(171, 68);
            mnPlaylist.ItemClicked += mnPlaylist_ItemClicked;
            // 
            // mnPlaylistRemove
            // 
            mnPlaylistRemove.Name = "mnPlaylistRemove";
            mnPlaylistRemove.Size = new System.Drawing.Size(170, 32);
            mnPlaylistRemove.Text = "Remove";
            // 
            // mnPlaylistRemoveAll
            // 
            mnPlaylistRemoveAll.Name = "mnPlaylistRemoveAll";
            mnPlaylistRemoveAll.Size = new System.Drawing.Size(170, 32);
            mnPlaylistRemoveAll.Text = "Remove all";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(548, 94);
            label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(66, 25);
            label30.TabIndex = 17;
            label30.Text = "Playlist";
            // 
            // btAddFileToPlaylist
            // 
            btAddFileToPlaylist.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btAddFileToPlaylist.Location = new System.Drawing.Point(1138, 52);
            btAddFileToPlaylist.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            btAddFileToPlaylist.Name = "btAddFileToPlaylist";
            btAddFileToPlaylist.Size = new System.Drawing.Size(62, 42);
            btAddFileToPlaylist.TabIndex = 18;
            btAddFileToPlaylist.Text = "Add";
            btAddFileToPlaylist.UseVisualStyleBackColor = true;
            btAddFileToPlaylist.Click += btAddFileToPlaylist_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(1060, 19);
            linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(184, 25);
            linkLabel1.TabIndex = 20;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(550, 269);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(692, 476);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 23;
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Checked = true;
            cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            cbTelemetry.Location = new System.Drawing.Point(1129, 941);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(113, 29);
            cbTelemetry.TabIndex = 26;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(550, 989);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmLog.Size = new System.Drawing.Size(690, 139);
            mmLog.TabIndex = 25;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(1029, 941);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 24;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // btSaveSnapshot
            // 
            btSaveSnapshot.Location = new System.Drawing.Point(548, 938);
            btSaveSnapshot.Name = "btSaveSnapshot";
            btSaveSnapshot.Size = new System.Drawing.Size(193, 42);
            btSaveSnapshot.TabIndex = 27;
            btSaveSnapshot.Text = "Save snapshot";
            btSaveSnapshot.UseVisualStyleBackColor = true;
            btSaveSnapshot.Click += btSaveSnapshot_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1262, 1148);
            Controls.Add(btSaveSnapshot);
            Controls.Add(cbTelemetry);
            Controls.Add(mmLog);
            Controls.Add(cbDebugMode);
            Controls.Add(VideoView1);
            Controls.Add(linkLabel1);
            Controls.Add(btAddFileToPlaylist);
            Controls.Add(label30);
            Controls.Add(lbSourceFiles);
            Controls.Add(cbSourceMode);
            Controls.Add(label29);
            Controls.Add(groupBox2);
            Controls.Add(btSelectFile);
            Controls.Add(edFilenameOrURL);
            Controls.Add(label14);
            Controls.Add(tabControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "Form1";
            Text = "Media Player SDK .Net - Main Demo";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage20.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage49.ResumeLayout(false);
            tabPage49.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgTags).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance4).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume4).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance3).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume3).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).EndInit();
            tabPage3.ResumeLayout(false);
            tabControl4.ResumeLayout(false);
            tabPage16.ResumeLayout(false);
            tabPage16.PerformLayout();
            groupBox28.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            tabPage17.ResumeLayout(false);
            tabPage17.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabControl17.ResumeLayout(false);
            tabPage68.ResumeLayout(false);
            tabPage68.PerformLayout();
            tabControl7.ResumeLayout(false);
            tabPage29.ResumeLayout(false);
            tabPage42.ResumeLayout(false);
            tabPage18.ResumeLayout(false);
            tabPage18.PerformLayout();
            groupBox37.ResumeLayout(false);
            tabPage19.ResumeLayout(false);
            tabPage19.PerformLayout();
            groupBox40.ResumeLayout(false);
            groupBox40.PerformLayout();
            groupBox39.ResumeLayout(false);
            groupBox39.PerformLayout();
            groupBox38.ResumeLayout(false);
            groupBox38.PerformLayout();
            tabPage22.ResumeLayout(false);
            tabPage22.PerformLayout();
            groupBox45.ResumeLayout(false);
            groupBox45.PerformLayout();
            tabPage43.ResumeLayout(false);
            tabPage43.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbLiveRotationAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage69.ResumeLayout(false);
            tabPage69.PerformLayout();
            tabPage59.ResumeLayout(false);
            tabPage59.PerformLayout();
            tabPage51.ResumeLayout(false);
            tabPage51.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).EndInit();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAdjSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjBrightness).EndInit();
            tabPage15.ResumeLayout(false);
            tabPage15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).EndInit();
            tabPage46.ResumeLayout(false);
            tabPage46.PerformLayout();
            tabPage48.ResumeLayout(false);
            tabPage48.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).EndInit();
            tabPage11.ResumeLayout(false);
            tabPage11.PerformLayout();
            tabControl18.ResumeLayout(false);
            tabPage71.ResumeLayout(false);
            tabPage71.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudAmplifyAmp).EndInit();
            tabPage72.ResumeLayout(false);
            tabPage72.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudEq9).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq8).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq7).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq6).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq5).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq4).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq3).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudEq0).EndInit();
            tabPage73.ResumeLayout(false);
            tabPage73.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudRelease).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudAttack).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudDynAmp).EndInit();
            tabPage75.ResumeLayout(false);
            tabPage75.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAud3DSound).EndInit();
            tabPage76.ResumeLayout(false);
            tabPage76.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudTrueBass).EndInit();
            tabPage27.ResumeLayout(false);
            tabPage27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudPitchShift).EndInit();
            tabPage50.ResumeLayout(false);
            tabPage50.PerformLayout();
            groupBox41.ResumeLayout(false);
            groupBox41.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).EndInit();
            tabPage28.ResumeLayout(false);
            tabPage28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            groupBox19.ResumeLayout(false);
            tabControl6.ResumeLayout(false);
            tabPage30.ResumeLayout(false);
            tabPage30.PerformLayout();
            tabPage31.ResumeLayout(false);
            tabPage31.PerformLayout();
            tabPage32.ResumeLayout(false);
            tabPage32.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbOSDTranspLevel).EndInit();
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            tabPage12.ResumeLayout(false);
            tabControl5.ResumeLayout(false);
            tabPage33.ResumeLayout(false);
            tabPage33.PerformLayout();
            tabPage34.ResumeLayout(false);
            tabPage34.PerformLayout();
            tabPage47.ResumeLayout(false);
            tabPage47.PerformLayout();
            tabPage13.ResumeLayout(false);
            tabPage13.PerformLayout();
            tabControl9.ResumeLayout(false);
            tabPage44.ResumeLayout(false);
            tabPage44.PerformLayout();
            tabPage45.ResumeLayout(false);
            groupBox25.ResumeLayout(false);
            groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetHLThreshold).EndInit();
            groupBox27.ResumeLayout(false);
            groupBox27.PerformLayout();
            groupBox26.ResumeLayout(false);
            groupBox26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetDropFramesThreshold).EndInit();
            groupBox24.ResumeLayout(false);
            groupBox24.PerformLayout();
            tabPage14.ResumeLayout(false);
            tabPage14.PerformLayout();
            tabPage21.ResumeLayout(false);
            tabPage21.PerformLayout();
            tabPage23.ResumeLayout(false);
            tabPage23.PerformLayout();
            groupBox48.ResumeLayout(false);
            groupBox48.PerformLayout();
            tabPage24.ResumeLayout(false);
            tabPage24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbReversePlaybackTrackbar).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            mnPlaylist.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox mmInfo;
        private System.Windows.Forms.Button btReadInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbPlayAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.CheckBox cbAudioStream1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbBalance1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tbBalance4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar tbVolume4;
        private System.Windows.Forms.CheckBox cbAudioStream4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar tbBalance3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar tbVolume3;
        private System.Windows.Forms.CheckBox cbAudioStream3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbBalance2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tbVolume2;
        private System.Windows.Forms.CheckBox cbAudioStream2;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.Button btOSDImageDraw;
        private System.Windows.Forms.Panel pnOSDColorKey;
        private System.Windows.Forms.CheckBox cbOSDImageTranspColor;
        private System.Windows.Forms.TextBox edOSDImageTop;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.TextBox edOSDImageLeft;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Button btOSDSelectImage;
        private System.Windows.Forms.TextBox edOSDImageFilename;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.TextBox edOSDTextTop;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.TextBox edOSDTextLeft;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Button btOSDSelectFont;
        private System.Windows.Forms.TextBox edOSDText;
        private System.Windows.Forms.Button btOSDTextDraw;
        private System.Windows.Forms.TabPage tabPage32;
        private System.Windows.Forms.TrackBar tbOSDTranspLevel;
        private System.Windows.Forms.Button btOSDSetTransp;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Button btOSDClearLayers;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btOSDLayerAdd;
        private System.Windows.Forms.TextBox edOSDLayerHeight;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.TextBox edOSDLayerWidth;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.TextBox edOSDLayerTop;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.TextBox edOSDLayerLeft;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox edFilenameOrURL;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabControl tabControl18;
        private System.Windows.Forms.TabPage tabPage71;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.TrackBar tbAudAmplifyAmp;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.CheckBox cbAudAmplifyEnabled;
        private System.Windows.Forms.TabPage tabPage72;
        private System.Windows.Forms.Button btAudEqRefresh;
        private System.Windows.Forms.ComboBox cbAudEqualizerPreset;
        private System.Windows.Forms.Label label243;
        private System.Windows.Forms.Label label242;
        private System.Windows.Forms.Label label241;
        private System.Windows.Forms.Label label240;
        private System.Windows.Forms.Label label239;
        private System.Windows.Forms.Label label238;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.Label label235;
        private System.Windows.Forms.Label label234;
        private System.Windows.Forms.Label label233;
        private System.Windows.Forms.Label label232;
        private System.Windows.Forms.TrackBar tbAudEq9;
        private System.Windows.Forms.TrackBar tbAudEq8;
        private System.Windows.Forms.TrackBar tbAudEq7;
        private System.Windows.Forms.TrackBar tbAudEq6;
        private System.Windows.Forms.TrackBar tbAudEq5;
        private System.Windows.Forms.TrackBar tbAudEq4;
        private System.Windows.Forms.TrackBar tbAudEq3;
        private System.Windows.Forms.TrackBar tbAudEq2;
        private System.Windows.Forms.TrackBar tbAudEq1;
        private System.Windows.Forms.TrackBar tbAudEq0;
        private System.Windows.Forms.CheckBox cbAudEqualizerEnabled;
        private System.Windows.Forms.TabPage tabPage73;
        private System.Windows.Forms.TrackBar tbAudRelease;
        private System.Windows.Forms.Label label248;
        private System.Windows.Forms.Label label249;
        private System.Windows.Forms.Label label246;
        private System.Windows.Forms.TrackBar tbAudAttack;
        private System.Windows.Forms.Label label247;
        private System.Windows.Forms.Label label244;
        private System.Windows.Forms.TrackBar tbAudDynAmp;
        private System.Windows.Forms.Label label245;
        private System.Windows.Forms.CheckBox cbAudDynamicAmplifyEnabled;
        private System.Windows.Forms.TabPage tabPage75;
        private System.Windows.Forms.TrackBar tbAud3DSound;
        private System.Windows.Forms.Label label253;
        private System.Windows.Forms.CheckBox cbAudSound3DEnabled;
        private System.Windows.Forms.TabPage tabPage76;
        private System.Windows.Forms.TrackBar tbAudTrueBass;
        private System.Windows.Forms.Label label254;
        private System.Windows.Forms.CheckBox cbAudTrueBassEnabled;
        private System.Windows.Forms.CheckBox cbAudioEffectsEnabled;
        private System.Windows.Forms.TabControl tabControl17;
        private System.Windows.Forms.TabPage tabPage68;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TabControl tabControl7;
        private System.Windows.Forms.TabPage tabPage29;
        private System.Windows.Forms.TabPage tabPage42;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.TrackBar tbDarkness;
        private System.Windows.Forms.TrackBar tbLightness;
        private System.Windows.Forms.TrackBar tbSaturation;
        private System.Windows.Forms.CheckBox cbInvert;
        private System.Windows.Forms.CheckBox cbGreyscale;
        private System.Windows.Forms.CheckBox cbVideoEffects;
        private System.Windows.Forms.TabPage tabPage69;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.TextBox edDeintTriangleWeight;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.TextBox edDeintBlendConstants2;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.TextBox edDeintBlendConstants1;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.TextBox edDeintBlendThreshold2;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.TextBox edDeintBlendThreshold1;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.TextBox edDeintCAVTThreshold;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.RadioButton rbDeintTriangleEnabled;
        private System.Windows.Forms.RadioButton rbDeintBlendEnabled;
        private System.Windows.Forms.RadioButton rbDeintCAVTEnabled;
        private System.Windows.Forms.CheckBox cbDeinterlace;
        private System.Windows.Forms.TabPage tabPage59;
        private System.Windows.Forms.RadioButton rbDenoiseCAST;
        private System.Windows.Forms.RadioButton rbDenoiseMosquito;
        private System.Windows.Forms.CheckBox cbDenoise;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label lbAdjContrastCurrent;
        private System.Windows.Forms.Label lbAdjContrastMax;
        private System.Windows.Forms.Label lbAdjContrastMin;
        private System.Windows.Forms.TrackBar tbAdjContrast;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbAdjBrightnessCurrent;
        private System.Windows.Forms.Label lbAdjBrightnessMax;
        private System.Windows.Forms.Label lbAdjBrightnessMin;
        private System.Windows.Forms.TrackBar tbAdjBrightness;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbAdjSaturationCurrent;
        private System.Windows.Forms.Label lbAdjSaturationMax;
        private System.Windows.Forms.Label lbAdjSaturationMin;
        private System.Windows.Forms.TrackBar tbAdjSaturation;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lbAdjHueCurrent;
        private System.Windows.Forms.Label lbAdjHueMax;
        private System.Windows.Forms.Label lbAdjHueMin;
        private System.Windows.Forms.TrackBar tbAdjHue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabControl tabControl9;
        private System.Windows.Forms.TabPage tabPage44;
        private System.Windows.Forms.ProgressBar pbMotionLevel;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.TextBox mmMotDetMatrix;
        private System.Windows.Forms.TabPage tabPage45;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.ComboBox cbMotDetHLColor;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.CheckBox cbMotDetHLEnabled;
        private System.Windows.Forms.TrackBar tbMotDetHLThreshold;
        private System.Windows.Forms.Button btMotDetUpdateSettings;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.TextBox edMotDetMatrixHeight;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.TextBox edMotDetMatrixWidth;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.TrackBar tbMotDetDropFramesThreshold;
        private System.Windows.Forms.CheckBox cbMotDetDropFramesEnabled;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.TextBox edMotDetFrameInterval;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.CheckBox cbCompareGreyscale;
        private System.Windows.Forms.CheckBox cbCompareBlue;
        private System.Windows.Forms.CheckBox cbCompareGreen;
        private System.Windows.Forms.CheckBox cbCompareRed;
        private System.Windows.Forms.CheckBox cbMotDetEnabled;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.Button btChromaKeySelectBGImage;
        private System.Windows.Forms.TextBox edChromaKeyImage;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.TrackBar tbChromaKeySmoothing;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.TrackBar tbChromaKeyThresholdSensitivity;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.CheckBox cbChromaKeyEnabled;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox edAspectRatioY;
        private System.Windows.Forms.TextBox edAspectRatioX;
        private System.Windows.Forms.CheckBox cbAspectRatioUseCustom;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.CheckBox cbFlipHorizontal2;
        private System.Windows.Forms.CheckBox cbFlipVertical2;
        private System.Windows.Forms.CheckBox cbStretch2;
        private System.Windows.Forms.CheckBox cbFlipHorizontal1;
        private System.Windows.Forms.CheckBox cbFlipVertical1;
        private System.Windows.Forms.CheckBox cbStretch1;
        private System.Windows.Forms.Panel pnScreen2;
        private System.Windows.Forms.Panel pnScreen1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbSourceMode;
        private System.Windows.Forms.TabPage tabPage18;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Button btEffZoomRight;
        private System.Windows.Forms.Button btEffZoomLeft;
        private System.Windows.Forms.Button btEffZoomOut;
        private System.Windows.Forms.Button btEffZoomIn;
        private System.Windows.Forms.Button btEffZoomDown;
        private System.Windows.Forms.Button btEffZoomUp;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.TabPage tabPage19;
        private System.Windows.Forms.GroupBox groupBox40;
        private System.Windows.Forms.TextBox edPanDestHeight;
        private System.Windows.Forms.Label label302;
        private System.Windows.Forms.TextBox edPanDestWidth;
        private System.Windows.Forms.Label label303;
        private System.Windows.Forms.TextBox edPanDestTop;
        private System.Windows.Forms.Label label304;
        private System.Windows.Forms.TextBox edPanDestLeft;
        private System.Windows.Forms.Label label305;
        private System.Windows.Forms.GroupBox groupBox39;
        private System.Windows.Forms.TextBox edPanSourceHeight;
        private System.Windows.Forms.Label label298;
        private System.Windows.Forms.TextBox edPanSourceWidth;
        private System.Windows.Forms.Label label299;
        private System.Windows.Forms.TextBox edPanSourceTop;
        private System.Windows.Forms.Label label300;
        private System.Windows.Forms.TextBox edPanSourceLeft;
        private System.Windows.Forms.Label label301;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.TextBox edPanStopTime;
        private System.Windows.Forms.Label label296;
        private System.Windows.Forms.TextBox edPanStartTime;
        private System.Windows.Forms.Label label297;
        private System.Windows.Forms.CheckBox cbPan;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.TextBox edBarcodeMetadata;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.ComboBox cbBarcodeType;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Button btBarcodeReset;
        private System.Windows.Forms.TextBox edBarcode;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.CheckBox cbBarcodeDetectionEnabled;
        private System.Windows.Forms.ListBox lbSourceFiles;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btAddFileToPlaylist;
        private System.Windows.Forms.TabPage tabPage22;
        private System.Windows.Forms.RadioButton rbFadeOut;
        private System.Windows.Forms.RadioButton rbFadeIn;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.TextBox edFadeInOutStopTime;
        private System.Windows.Forms.Label label329;
        private System.Windows.Forms.TextBox edFadeInOutStartTime;
        private System.Windows.Forms.Label label330;
        private System.Windows.Forms.CheckBox cbFadeInOut;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabPage tabPage23;
        private System.Windows.Forms.TabPage tabPage24;
        private System.Windows.Forms.TextBox edReversePlaybackCacheSize;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TrackBar tbReversePlaybackTrackbar;
        private System.Windows.Forms.Button btReversePlayback;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage tabPage27;
        private System.Windows.Forms.TrackBar tbAudPitchShift;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox cbAudPitchShiftEnabled;
        private System.Windows.Forms.TabPage tabPage28;
        private System.Windows.Forms.CheckBox cbVUMeterPro;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter waveformPainter2;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter waveformPainter1;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter2;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter1;
        private System.Windows.Forms.TrackBar tbVUMeterBoost;
        private System.Windows.Forms.Label label382;
        private System.Windows.Forms.Label label381;
        private System.Windows.Forms.TrackBar tbVUMeterAmplification;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage33;
        private System.Windows.Forms.TabPage tabPage34;
        private System.Windows.Forms.ComboBox cbCustomVideoDecoder;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.RadioButton rbVideoDecoderCustom;
        private System.Windows.Forms.RadioButton rbVideoDecoderFFDShow;
        private System.Windows.Forms.RadioButton rbVideoDecoderMS;
        private System.Windows.Forms.RadioButton rbVideoDecoderDefault;
        private System.Windows.Forms.RadioButton rbSplitterDefault;
        private System.Windows.Forms.RadioButton rbSplitterCustom;
        private System.Windows.Forms.ComboBox cbCustomSplitter;
        private System.Windows.Forms.TabPage tabPage43;
        private System.Windows.Forms.CheckBox cbLiveRotationStretch;
        private System.Windows.Forms.Label label392;
        private System.Windows.Forms.Label label391;
        private System.Windows.Forms.TrackBar tbLiveRotationAngle;
        private System.Windows.Forms.Label label390;
        private System.Windows.Forms.CheckBox cbLiveRotation;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbDirect2D;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbEVR;
        private System.Windows.Forms.RadioButton rbVMR9;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.Button btZoomShiftRight;
        private System.Windows.Forms.Button btZoomShiftLeft;
        private System.Windows.Forms.Button btZoomOut;
        private System.Windows.Forms.Button btZoomIn;
        private System.Windows.Forms.Button btZoomShiftDown;
        private System.Windows.Forms.Button btZoomShiftUp;
        private System.Windows.Forms.CheckBox cbScreenFlipVertical;
        private System.Windows.Forms.CheckBox cbScreenFlipHorizontal;
        private System.Windows.Forms.CheckBox cbStretch;
        private System.Windows.Forms.Button btFullScreen;
        private System.Windows.Forms.Panel pnVideoRendererBGColor;
        private System.Windows.Forms.Label label394;
        private System.Windows.Forms.Label label393;
        private System.Windows.Forms.ComboBox cbDirect2DRotate;
        private System.Windows.Forms.CheckBox cbUseLibMediaInfo;
        private System.Windows.Forms.RadioButton rbVideoDecoderVFH264;
        private System.Windows.Forms.TabPage tabPage46;
        private System.Windows.Forms.Button btFilterDelete;
        private System.Windows.Forms.Button btFilterDeleteAll;
        private System.Windows.Forms.Button btFilterSettings2;
        private System.Windows.Forms.ListBox lbFilters;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Button btFilterSettings;
        private System.Windows.Forms.Button btFilterAdd;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.TabPage tabPage47;
        private System.Windows.Forms.ComboBox cbCustomAudioDecoder;
        private System.Windows.Forms.RadioButton rbAudioDecoderCustom;
        private System.Windows.Forms.RadioButton rbAudioDecoderDefault;
        private System.Windows.Forms.TabPage tabPage48;
        private System.Windows.Forms.CheckBox cbAudioAutoGain;
        private System.Windows.Forms.CheckBox cbAudioNormalize;
        private System.Windows.Forms.CheckBox cbAudioEnhancementEnabled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbAudioInputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioInputGainLFE;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lbAudioInputGainSR;
        private System.Windows.Forms.TrackBar tbAudioInputGainSR;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lbAudioInputGainSL;
        private System.Windows.Forms.TrackBar tbAudioInputGainSL;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lbAudioInputGainR;
        private System.Windows.Forms.TrackBar tbAudioInputGainR;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lbAudioInputGainC;
        private System.Windows.Forms.TrackBar tbAudioInputGainC;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lbAudioInputGainL;
        private System.Windows.Forms.TrackBar tbAudioInputGainL;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbAudioOutputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioOutputGainLFE;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label lbAudioOutputGainSR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSR;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label lbAudioOutputGainSL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSL;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label lbAudioOutputGainR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainR;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label lbAudioOutputGainC;
        private System.Windows.Forms.TrackBar tbAudioOutputGainC;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lbAudioOutputGainL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainL;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label lbAudioTimeshift;
        private System.Windows.Forms.TrackBar tbAudioTimeshift;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.Label label343;
        private System.Windows.Forms.TextBox edEncryptionKeyHEX;
        private System.Windows.Forms.RadioButton rbEncryptionKeyBinary;
        private System.Windows.Forms.Button btEncryptionOpenFile;
        private System.Windows.Forms.TextBox edEncryptionKeyFile;
        private System.Windows.Forms.RadioButton rbEncryptionKeyFile;
        private System.Windows.Forms.TextBox edEncryptionKeyString;
        private System.Windows.Forms.RadioButton rbEncryptionKeyString;
        private System.Windows.Forms.TabPage tabPage49;
        private System.Windows.Forms.Button btReadTags;
        private System.Windows.Forms.TextBox edTags;
        private System.Windows.Forms.PictureBox imgTags;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btReversePlaybackPrevFrame;
        private System.Windows.Forms.TabPage tabPage50;
        private System.Windows.Forms.Button btAudioChannelMapperClear;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button btAudioChannelMapperAddNewRoute;
        private System.Windows.Forms.Label label311;
        private System.Windows.Forms.TrackBar tbAudioChannelMapperVolume;
        private System.Windows.Forms.Label label310;
        private System.Windows.Forms.TextBox edAudioChannelMapperTargetChannel;
        private System.Windows.Forms.Label label309;
        private System.Windows.Forms.TextBox edAudioChannelMapperSourceChannel;
        private System.Windows.Forms.Label label308;
        private System.Windows.Forms.Label label307;
        private System.Windows.Forms.TextBox edAudioChannelMapperOutputChannels;
        private System.Windows.Forms.Label label306;
        private System.Windows.Forms.ListBox lbAudioChannelMapperRoutes;
        private System.Windows.Forms.CheckBox cbAudioChannelMapperEnabled;
        private System.Windows.Forms.TabPage tabPage51;
        private System.Windows.Forms.CheckBox cbGPUOldMovie;
        private System.Windows.Forms.CheckBox cbGPUDeinterlace;
        private System.Windows.Forms.CheckBox cbGPUDenoise;
        private System.Windows.Forms.CheckBox cbGPUPixelate;
        private System.Windows.Forms.CheckBox cbGPUNightVision;
        private System.Windows.Forms.Label label383;
        private System.Windows.Forms.Label label384;
        private System.Windows.Forms.Label label385;
        private System.Windows.Forms.Label label386;
        private System.Windows.Forms.TrackBar tbGPUContrast;
        private System.Windows.Forms.TrackBar tbGPUDarkness;
        private System.Windows.Forms.TrackBar tbGPULightness;
        private System.Windows.Forms.TrackBar tbGPUSaturation;
        private System.Windows.Forms.CheckBox cbGPUInvert;
        private System.Windows.Forms.CheckBox cbGPUGreyscale;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.Label label505;
        private System.Windows.Forms.ComboBox rbMotionDetectionExProcessor;
        private System.Windows.Forms.Label label389;
        private System.Windows.Forms.ComboBox rbMotionDetectionExDetector;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ProgressBar pbAFMotionLevel;
        private System.Windows.Forms.CheckBox cbMotionDetectionEx;
        private System.Windows.Forms.RadioButton rbMadVR;
        private System.Windows.Forms.Button btReversePlaybackNextFrame;
        private System.Windows.Forms.Button btPreviousFrame;
        private System.Windows.Forms.CheckBox cbMultiscreenDrawOnExternalDisplays;
        private System.Windows.Forms.CheckBox cbMultiscreenDrawOnPanels;
        private System.Windows.Forms.Button btTextLogoRemove;
        private System.Windows.Forms.Button btTextLogoEdit;
        private System.Windows.Forms.ListBox lbTextLogos;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.Button btImageLogoRemove;
        private System.Windows.Forms.Button btImageLogoEdit;
        private System.Windows.Forms.ListBox lbImageLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.CheckBox cbFlipX;
        private System.Windows.Forms.TabPage tabPage20;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbGPUDirect3D;
        private System.Windows.Forms.RadioButton rbGPUDXVANative;
        private System.Windows.Forms.RadioButton rbGPUDXVACopyBack;
        private System.Windows.Forms.RadioButton rbGPUIntel;
        private System.Windows.Forms.RadioButton rbGPUNVidia;
        private System.Windows.Forms.CheckBox cbOSDEnabled;
        private System.Windows.Forms.Button btOSDClearLayer;
        private System.Windows.Forms.CheckBox cbVideoEffectsGPUEnabled;
        private System.Windows.Forms.CheckedListBox lbOSDLayers;
        private System.Windows.Forms.Button btOSDRenderLayers;
        private System.Windows.Forms.Button btZoomReset;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip mnPlaylist;
        private System.Windows.Forms.ToolStripMenuItem mnPlaylistRemove;
        private System.Windows.Forms.ToolStripMenuItem mnPlaylistRemoveAll;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TrackBar tbGPUBlur;
        private System.Windows.Forms.Panel pnChromaKeyColor;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.CheckBox cbScrollingText;
        private global::System.Windows.Forms.CheckBox cbTelemetry;
        private global::System.Windows.Forms.TextBox mmLog;
        private global::System.Windows.Forms.CheckBox cbDebugMode;
        private global::System.Windows.Forms.Button btSaveSnapshot;
    }
}