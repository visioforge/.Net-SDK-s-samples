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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbGPUDirect3D = new System.Windows.Forms.RadioButton();
            this.rbGPUDXVANative = new System.Windows.Forms.RadioButton();
            this.rbGPUDXVACopyBack = new System.Windows.Forms.RadioButton();
            this.rbGPUIntel = new System.Windows.Forms.RadioButton();
            this.rbGPUNVidia = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbUseLibMediaInfo = new System.Windows.Forms.CheckBox();
            this.btReadInfo = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.mmInfo = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.lbDVDTitles = new System.Windows.Forms.ListBox();
            this.cbDVDSubtitles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDVDAudio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edDVDVideo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage49 = new System.Windows.Forms.TabPage();
            this.imgTags = new System.Windows.Forms.PictureBox();
            this.edTags = new System.Windows.Forms.TextBox();
            this.btReadTags = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBalance4 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.tbVolume4 = new System.Windows.Forms.TrackBar();
            this.cbAudioStream4 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBalance3 = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.tbVolume3 = new System.Windows.Forms.TrackBar();
            this.cbAudioStream3 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBalance2 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.tbVolume2 = new System.Windows.Forms.TrackBar();
            this.cbAudioStream2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBalance1 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.cbAudioStream1 = new System.Windows.Forms.CheckBox();
            this.cbPlayAudio = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.label393 = new System.Windows.Forms.Label();
            this.cbDirect2DRotate = new System.Windows.Forms.ComboBox();
            this.pnVideoRendererBGColor = new System.Windows.Forms.Panel();
            this.label394 = new System.Windows.Forms.Label();
            this.btFullScreen = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.btZoomReset = new System.Windows.Forms.Button();
            this.btZoomShiftRight = new System.Windows.Forms.Button();
            this.btZoomShiftLeft = new System.Windows.Forms.Button();
            this.btZoomOut = new System.Windows.Forms.Button();
            this.btZoomIn = new System.Windows.Forms.Button();
            this.btZoomShiftDown = new System.Windows.Forms.Button();
            this.btZoomShiftUp = new System.Windows.Forms.Button();
            this.cbScreenFlipVertical = new System.Windows.Forms.CheckBox();
            this.cbScreenFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.cbStretch = new System.Windows.Forms.CheckBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rbNDIStreaming = new System.Windows.Forms.RadioButton();
            this.rbVirtualCameraOutput = new System.Windows.Forms.RadioButton();
            this.rbMadVR = new System.Windows.Forms.RadioButton();
            this.rbDirect2D = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbEVR = new System.Windows.Forms.RadioButton();
            this.rbVMR9 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.edAspectRatioY = new System.Windows.Forms.TextBox();
            this.edAspectRatioX = new System.Windows.Forms.TextBox();
            this.cbAspectRatioUseCustom = new System.Windows.Forms.CheckBox();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.cbMultiscreenDrawOnExternalDisplays = new System.Windows.Forms.CheckBox();
            this.cbMultiscreenDrawOnPanels = new System.Windows.Forms.CheckBox();
            this.cbFlipHorizontal2 = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical2 = new System.Windows.Forms.CheckBox();
            this.cbStretch2 = new System.Windows.Forms.CheckBox();
            this.cbFlipHorizontal1 = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical1 = new System.Windows.Forms.CheckBox();
            this.cbStretch1 = new System.Windows.Forms.CheckBox();
            this.pnScreen2 = new System.Windows.Forms.Panel();
            this.pnScreen1 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl17 = new System.Windows.Forms.TabControl();
            this.tabPage68 = new System.Windows.Forms.TabPage();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tabControl7 = new System.Windows.Forms.TabControl();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.btTextLogoRemove = new System.Windows.Forms.Button();
            this.btTextLogoEdit = new System.Windows.Forms.Button();
            this.lbTextLogos = new System.Windows.Forms.ListBox();
            this.btTextLogoAdd = new System.Windows.Forms.Button();
            this.tabPage42 = new System.Windows.Forms.TabPage();
            this.btImageLogoRemove = new System.Windows.Forms.Button();
            this.btImageLogoEdit = new System.Windows.Forms.Button();
            this.lbImageLogos = new System.Windows.Forms.ListBox();
            this.btImageLogoAdd = new System.Windows.Forms.Button();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.btEffZoomRight = new System.Windows.Forms.Button();
            this.btEffZoomLeft = new System.Windows.Forms.Button();
            this.btEffZoomOut = new System.Windows.Forms.Button();
            this.btEffZoomIn = new System.Windows.Forms.Button();
            this.btEffZoomDown = new System.Windows.Forms.Button();
            this.btEffZoomUp = new System.Windows.Forms.Button();
            this.cbZoom = new System.Windows.Forms.CheckBox();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.edPanDestHeight = new System.Windows.Forms.TextBox();
            this.label302 = new System.Windows.Forms.Label();
            this.edPanDestWidth = new System.Windows.Forms.TextBox();
            this.label303 = new System.Windows.Forms.Label();
            this.edPanDestTop = new System.Windows.Forms.TextBox();
            this.label304 = new System.Windows.Forms.Label();
            this.edPanDestLeft = new System.Windows.Forms.TextBox();
            this.label305 = new System.Windows.Forms.Label();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.edPanSourceHeight = new System.Windows.Forms.TextBox();
            this.label298 = new System.Windows.Forms.Label();
            this.edPanSourceWidth = new System.Windows.Forms.TextBox();
            this.label299 = new System.Windows.Forms.Label();
            this.edPanSourceTop = new System.Windows.Forms.TextBox();
            this.label300 = new System.Windows.Forms.Label();
            this.edPanSourceLeft = new System.Windows.Forms.TextBox();
            this.label301 = new System.Windows.Forms.Label();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.edPanStopTime = new System.Windows.Forms.TextBox();
            this.label296 = new System.Windows.Forms.Label();
            this.edPanStartTime = new System.Windows.Forms.TextBox();
            this.label297 = new System.Windows.Forms.Label();
            this.cbPan = new System.Windows.Forms.CheckBox();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.rbFadeOut = new System.Windows.Forms.RadioButton();
            this.rbFadeIn = new System.Windows.Forms.RadioButton();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.edFadeInOutStopTime = new System.Windows.Forms.TextBox();
            this.label329 = new System.Windows.Forms.Label();
            this.edFadeInOutStartTime = new System.Windows.Forms.TextBox();
            this.label330 = new System.Windows.Forms.Label();
            this.cbFadeInOut = new System.Windows.Forms.CheckBox();
            this.tabPage43 = new System.Windows.Forms.TabPage();
            this.cbLiveRotationStretch = new System.Windows.Forms.CheckBox();
            this.label392 = new System.Windows.Forms.Label();
            this.label391 = new System.Windows.Forms.Label();
            this.tbLiveRotationAngle = new System.Windows.Forms.TrackBar();
            this.label390 = new System.Windows.Forms.Label();
            this.cbLiveRotation = new System.Windows.Forms.CheckBox();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbDarkness = new System.Windows.Forms.TrackBar();
            this.tbLightness = new System.Windows.Forms.TrackBar();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.cbInvert = new System.Windows.Forms.CheckBox();
            this.cbGreyscale = new System.Windows.Forms.CheckBox();
            this.cbVideoEffects = new System.Windows.Forms.CheckBox();
            this.tabPage69 = new System.Windows.Forms.TabPage();
            this.label211 = new System.Windows.Forms.Label();
            this.edDeintTriangleWeight = new System.Windows.Forms.TextBox();
            this.label212 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label206 = new System.Windows.Forms.Label();
            this.edDeintBlendConstants2 = new System.Windows.Forms.TextBox();
            this.label207 = new System.Windows.Forms.Label();
            this.edDeintBlendConstants1 = new System.Windows.Forms.TextBox();
            this.label208 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.edDeintBlendThreshold2 = new System.Windows.Forms.TextBox();
            this.label205 = new System.Windows.Forms.Label();
            this.edDeintBlendThreshold1 = new System.Windows.Forms.TextBox();
            this.label203 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.edDeintCAVTThreshold = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.rbDeintTriangleEnabled = new System.Windows.Forms.RadioButton();
            this.rbDeintBlendEnabled = new System.Windows.Forms.RadioButton();
            this.rbDeintCAVTEnabled = new System.Windows.Forms.RadioButton();
            this.cbDeinterlace = new System.Windows.Forms.CheckBox();
            this.tabPage59 = new System.Windows.Forms.TabPage();
            this.rbDenoiseCAST = new System.Windows.Forms.RadioButton();
            this.rbDenoiseMosquito = new System.Windows.Forms.RadioButton();
            this.cbDenoise = new System.Windows.Forms.CheckBox();
            this.tabPage51 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.tbGPUBlur = new System.Windows.Forms.TrackBar();
            this.cbVideoEffectsGPUEnabled = new System.Windows.Forms.CheckBox();
            this.cbGPUOldMovie = new System.Windows.Forms.CheckBox();
            this.cbGPUDeinterlace = new System.Windows.Forms.CheckBox();
            this.cbGPUDenoise = new System.Windows.Forms.CheckBox();
            this.cbGPUPixelate = new System.Windows.Forms.CheckBox();
            this.cbGPUNightVision = new System.Windows.Forms.CheckBox();
            this.label383 = new System.Windows.Forms.Label();
            this.label384 = new System.Windows.Forms.Label();
            this.label385 = new System.Windows.Forms.Label();
            this.label386 = new System.Windows.Forms.Label();
            this.tbGPUContrast = new System.Windows.Forms.TrackBar();
            this.tbGPUDarkness = new System.Windows.Forms.TrackBar();
            this.tbGPULightness = new System.Windows.Forms.TrackBar();
            this.tbGPUSaturation = new System.Windows.Forms.TrackBar();
            this.cbGPUInvert = new System.Windows.Forms.CheckBox();
            this.cbGPUGreyscale = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.lbAdjSaturationCurrent = new System.Windows.Forms.Label();
            this.lbAdjSaturationMax = new System.Windows.Forms.Label();
            this.lbAdjSaturationMin = new System.Windows.Forms.Label();
            this.tbAdjSaturation = new System.Windows.Forms.TrackBar();
            this.label45 = new System.Windows.Forms.Label();
            this.lbAdjHueCurrent = new System.Windows.Forms.Label();
            this.lbAdjHueMax = new System.Windows.Forms.Label();
            this.lbAdjHueMin = new System.Windows.Forms.Label();
            this.tbAdjHue = new System.Windows.Forms.TrackBar();
            this.label41 = new System.Windows.Forms.Label();
            this.lbAdjContrastCurrent = new System.Windows.Forms.Label();
            this.lbAdjContrastMax = new System.Windows.Forms.Label();
            this.lbAdjContrastMin = new System.Windows.Forms.Label();
            this.tbAdjContrast = new System.Windows.Forms.TrackBar();
            this.label23 = new System.Windows.Forms.Label();
            this.lbAdjBrightnessCurrent = new System.Windows.Forms.Label();
            this.lbAdjBrightnessMax = new System.Windows.Forms.Label();
            this.lbAdjBrightnessMin = new System.Windows.Forms.Label();
            this.tbAdjBrightness = new System.Windows.Forms.TrackBar();
            this.label24 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.pnChromaKeyColor = new System.Windows.Forms.Panel();
            this.btChromaKeySelectBGImage = new System.Windows.Forms.Button();
            this.edChromaKeyImage = new System.Windows.Forms.TextBox();
            this.label216 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.tbChromaKeySmoothing = new System.Windows.Forms.TrackBar();
            this.label214 = new System.Windows.Forms.Label();
            this.tbChromaKeyThresholdSensitivity = new System.Windows.Forms.TrackBar();
            this.label213 = new System.Windows.Forms.Label();
            this.cbChromaKeyEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage46 = new System.Windows.Forms.TabPage();
            this.btFilterDelete = new System.Windows.Forms.Button();
            this.btFilterDeleteAll = new System.Windows.Forms.Button();
            this.btFilterSettings2 = new System.Windows.Forms.Button();
            this.lbFilters = new System.Windows.Forms.ListBox();
            this.label106 = new System.Windows.Forms.Label();
            this.btFilterSettings = new System.Windows.Forms.Button();
            this.btFilterAdd = new System.Windows.Forms.Button();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.tabPage48 = new System.Windows.Forms.TabPage();
            this.lbAudioTimeshift = new System.Windows.Forms.Label();
            this.tbAudioTimeshift = new System.Windows.Forms.TrackBar();
            this.label70 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbAudioOutputGainLFE = new System.Windows.Forms.Label();
            this.tbAudioOutputGainLFE = new System.Windows.Forms.TrackBar();
            this.label55 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainSR = new System.Windows.Forms.Label();
            this.tbAudioOutputGainSR = new System.Windows.Forms.TrackBar();
            this.label57 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainSL = new System.Windows.Forms.Label();
            this.tbAudioOutputGainSL = new System.Windows.Forms.TrackBar();
            this.label59 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainR = new System.Windows.Forms.Label();
            this.tbAudioOutputGainR = new System.Windows.Forms.TrackBar();
            this.label61 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainC = new System.Windows.Forms.Label();
            this.tbAudioOutputGainC = new System.Windows.Forms.TrackBar();
            this.label67 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainL = new System.Windows.Forms.Label();
            this.tbAudioOutputGainL = new System.Windows.Forms.TrackBar();
            this.label69 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAudioInputGainLFE = new System.Windows.Forms.Label();
            this.tbAudioInputGainLFE = new System.Windows.Forms.TrackBar();
            this.label53 = new System.Windows.Forms.Label();
            this.lbAudioInputGainSR = new System.Windows.Forms.Label();
            this.tbAudioInputGainSR = new System.Windows.Forms.TrackBar();
            this.label51 = new System.Windows.Forms.Label();
            this.lbAudioInputGainSL = new System.Windows.Forms.Label();
            this.tbAudioInputGainSL = new System.Windows.Forms.TrackBar();
            this.label49 = new System.Windows.Forms.Label();
            this.lbAudioInputGainR = new System.Windows.Forms.Label();
            this.tbAudioInputGainR = new System.Windows.Forms.TrackBar();
            this.label47 = new System.Windows.Forms.Label();
            this.lbAudioInputGainC = new System.Windows.Forms.Label();
            this.tbAudioInputGainC = new System.Windows.Forms.TrackBar();
            this.label44 = new System.Windows.Forms.Label();
            this.lbAudioInputGainL = new System.Windows.Forms.Label();
            this.tbAudioInputGainL = new System.Windows.Forms.TrackBar();
            this.label40 = new System.Windows.Forms.Label();
            this.cbAudioAutoGain = new System.Windows.Forms.CheckBox();
            this.cbAudioNormalize = new System.Windows.Forms.CheckBox();
            this.cbAudioEnhancementEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.tabControl18 = new System.Windows.Forms.TabControl();
            this.tabPage71 = new System.Windows.Forms.TabPage();
            this.label231 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.tbAudAmplifyAmp = new System.Windows.Forms.TrackBar();
            this.label95 = new System.Windows.Forms.Label();
            this.cbAudAmplifyEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage72 = new System.Windows.Forms.TabPage();
            this.btAudEqRefresh = new System.Windows.Forms.Button();
            this.cbAudEqualizerPreset = new System.Windows.Forms.ComboBox();
            this.label243 = new System.Windows.Forms.Label();
            this.label242 = new System.Windows.Forms.Label();
            this.label241 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.label239 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.label237 = new System.Windows.Forms.Label();
            this.label236 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.label234 = new System.Windows.Forms.Label();
            this.label233 = new System.Windows.Forms.Label();
            this.label232 = new System.Windows.Forms.Label();
            this.tbAudEq9 = new System.Windows.Forms.TrackBar();
            this.tbAudEq8 = new System.Windows.Forms.TrackBar();
            this.tbAudEq7 = new System.Windows.Forms.TrackBar();
            this.tbAudEq6 = new System.Windows.Forms.TrackBar();
            this.tbAudEq5 = new System.Windows.Forms.TrackBar();
            this.tbAudEq4 = new System.Windows.Forms.TrackBar();
            this.tbAudEq3 = new System.Windows.Forms.TrackBar();
            this.tbAudEq2 = new System.Windows.Forms.TrackBar();
            this.tbAudEq1 = new System.Windows.Forms.TrackBar();
            this.tbAudEq0 = new System.Windows.Forms.TrackBar();
            this.cbAudEqualizerEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage73 = new System.Windows.Forms.TabPage();
            this.tbAudRelease = new System.Windows.Forms.TrackBar();
            this.label248 = new System.Windows.Forms.Label();
            this.label249 = new System.Windows.Forms.Label();
            this.label246 = new System.Windows.Forms.Label();
            this.tbAudAttack = new System.Windows.Forms.TrackBar();
            this.label247 = new System.Windows.Forms.Label();
            this.label244 = new System.Windows.Forms.Label();
            this.tbAudDynAmp = new System.Windows.Forms.TrackBar();
            this.label245 = new System.Windows.Forms.Label();
            this.cbAudDynamicAmplifyEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage75 = new System.Windows.Forms.TabPage();
            this.tbAud3DSound = new System.Windows.Forms.TrackBar();
            this.label253 = new System.Windows.Forms.Label();
            this.cbAudSound3DEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage76 = new System.Windows.Forms.TabPage();
            this.tbAudTrueBass = new System.Windows.Forms.TrackBar();
            this.label254 = new System.Windows.Forms.Label();
            this.cbAudTrueBassEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.tbAudPitchShift = new System.Windows.Forms.TrackBar();
            this.label36 = new System.Windows.Forms.Label();
            this.cbAudPitchShiftEnabled = new System.Windows.Forms.CheckBox();
            this.cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage50 = new System.Windows.Forms.TabPage();
            this.btAudioChannelMapperClear = new System.Windows.Forms.Button();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.btAudioChannelMapperAddNewRoute = new System.Windows.Forms.Button();
            this.label311 = new System.Windows.Forms.Label();
            this.tbAudioChannelMapperVolume = new System.Windows.Forms.TrackBar();
            this.label310 = new System.Windows.Forms.Label();
            this.edAudioChannelMapperTargetChannel = new System.Windows.Forms.TextBox();
            this.label309 = new System.Windows.Forms.Label();
            this.edAudioChannelMapperSourceChannel = new System.Windows.Forms.TextBox();
            this.label308 = new System.Windows.Forms.Label();
            this.label307 = new System.Windows.Forms.Label();
            this.edAudioChannelMapperOutputChannels = new System.Windows.Forms.TextBox();
            this.label306 = new System.Windows.Forms.Label();
            this.lbAudioChannelMapperRoutes = new System.Windows.Forms.ListBox();
            this.cbAudioChannelMapperEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage28 = new System.Windows.Forms.TabPage();
            this.tbVUMeterBoost = new System.Windows.Forms.TrackBar();
            this.label382 = new System.Windows.Forms.Label();
            this.label381 = new System.Windows.Forms.Label();
            this.tbVUMeterAmplification = new System.Windows.Forms.TrackBar();
            this.cbVUMeterPro = new System.Windows.Forms.CheckBox();
            this.waveformPainter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            this.waveformPainter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            this.volumeMeter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.volumeMeter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btOSDRenderLayers = new System.Windows.Forms.Button();
            this.lbOSDLayers = new System.Windows.Forms.CheckedListBox();
            this.cbOSDEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btOSDClearLayer = new System.Windows.Forms.Button();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.btOSDImageDraw = new System.Windows.Forms.Button();
            this.pnOSDColorKey = new System.Windows.Forms.Panel();
            this.cbOSDImageTranspColor = new System.Windows.Forms.CheckBox();
            this.edOSDImageTop = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.edOSDImageLeft = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.btOSDSelectImage = new System.Windows.Forms.Button();
            this.edOSDImageFilename = new System.Windows.Forms.TextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.edOSDTextTop = new System.Windows.Forms.TextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.edOSDTextLeft = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.btOSDSelectFont = new System.Windows.Forms.Button();
            this.edOSDText = new System.Windows.Forms.TextBox();
            this.btOSDTextDraw = new System.Windows.Forms.Button();
            this.tabPage32 = new System.Windows.Forms.TabPage();
            this.tbOSDTranspLevel = new System.Windows.Forms.TrackBar();
            this.btOSDSetTransp = new System.Windows.Forms.Button();
            this.label119 = new System.Windows.Forms.Label();
            this.btOSDClearLayers = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btOSDLayerAdd = new System.Windows.Forms.Button();
            this.edOSDLayerHeight = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.edOSDLayerWidth = new System.Windows.Forms.TextBox();
            this.label112 = new System.Windows.Forms.Label();
            this.edOSDLayerTop = new System.Windows.Forms.TextBox();
            this.label110 = new System.Windows.Forms.Label();
            this.edOSDLayerLeft = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage33 = new System.Windows.Forms.TabPage();
            this.cbCustomSplitter = new System.Windows.Forms.ComboBox();
            this.rbSplitterCustom = new System.Windows.Forms.RadioButton();
            this.rbSplitterDefault = new System.Windows.Forms.RadioButton();
            this.tabPage34 = new System.Windows.Forms.TabPage();
            this.rbVideoDecoderVFH264 = new System.Windows.Forms.RadioButton();
            this.cbCustomVideoDecoder = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.rbVideoDecoderCustom = new System.Windows.Forms.RadioButton();
            this.rbVideoDecoderFFDShow = new System.Windows.Forms.RadioButton();
            this.rbVideoDecoderMS = new System.Windows.Forms.RadioButton();
            this.rbVideoDecoderDefault = new System.Windows.Forms.RadioButton();
            this.tabPage47 = new System.Windows.Forms.TabPage();
            this.cbCustomAudioDecoder = new System.Windows.Forms.ComboBox();
            this.rbAudioDecoderCustom = new System.Windows.Forms.RadioButton();
            this.rbAudioDecoderDefault = new System.Windows.Forms.RadioButton();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.tabControl9 = new System.Windows.Forms.TabControl();
            this.tabPage44 = new System.Windows.Forms.TabPage();
            this.pbMotionLevel = new System.Windows.Forms.ProgressBar();
            this.label158 = new System.Windows.Forms.Label();
            this.mmMotDetMatrix = new System.Windows.Forms.TextBox();
            this.tabPage45 = new System.Windows.Forms.TabPage();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.cbMotDetHLColor = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.cbMotDetHLEnabled = new System.Windows.Forms.CheckBox();
            this.tbMotDetHLThreshold = new System.Windows.Forms.TrackBar();
            this.btMotDetUpdateSettings = new System.Windows.Forms.Button();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.edMotDetMatrixHeight = new System.Windows.Forms.TextBox();
            this.label163 = new System.Windows.Forms.Label();
            this.edMotDetMatrixWidth = new System.Windows.Forms.TextBox();
            this.label164 = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label162 = new System.Windows.Forms.Label();
            this.tbMotDetDropFramesThreshold = new System.Windows.Forms.TrackBar();
            this.cbMotDetDropFramesEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.edMotDetFrameInterval = new System.Windows.Forms.TextBox();
            this.label159 = new System.Windows.Forms.Label();
            this.cbCompareGreyscale = new System.Windows.Forms.CheckBox();
            this.cbCompareBlue = new System.Windows.Forms.CheckBox();
            this.cbCompareGreen = new System.Windows.Forms.CheckBox();
            this.cbCompareRed = new System.Windows.Forms.CheckBox();
            this.cbMotDetEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.label505 = new System.Windows.Forms.Label();
            this.rbMotionDetectionExProcessor = new System.Windows.Forms.ComboBox();
            this.label389 = new System.Windows.Forms.Label();
            this.rbMotionDetectionExDetector = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            this.cbMotionDetectionEx = new System.Windows.Forms.CheckBox();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.edBarcodeMetadata = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.cbBarcodeType = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.btBarcodeReset = new System.Windows.Forms.Button();
            this.edBarcode = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.label343 = new System.Windows.Forms.Label();
            this.edEncryptionKeyHEX = new System.Windows.Forms.TextBox();
            this.rbEncryptionKeyBinary = new System.Windows.Forms.RadioButton();
            this.btEncryptionOpenFile = new System.Windows.Forms.Button();
            this.edEncryptionKeyFile = new System.Windows.Forms.TextBox();
            this.rbEncryptionKeyFile = new System.Windows.Forms.RadioButton();
            this.edEncryptionKeyString = new System.Windows.Forms.TextBox();
            this.rbEncryptionKeyString = new System.Windows.Forms.RadioButton();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.btReversePlaybackNextFrame = new System.Windows.Forms.Button();
            this.btReversePlaybackPrevFrame = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btReversePlayback = new System.Windows.Forms.Button();
            this.edReversePlaybackCacheSize = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbReversePlaybackTrackbar = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.edFilenameOrURL = new System.Windows.Forms.TextBox();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btPreviousFrame = new System.Windows.Forms.Button();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btDVDControlRootMenu = new System.Windows.Forms.Button();
            this.btDVDControlTitleMenu = new System.Windows.Forms.Button();
            this.cbDVDControlSubtitles = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbDVDControlAudio = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbDVDControlChapter = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbDVDControlTitle = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabControl13 = new System.Windows.Forms.TabControl();
            this.tabPage54 = new System.Windows.Forms.TabPage();
            this.cbImageType = new System.Windows.Forms.ComboBox();
            this.lbJPEGQuality = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.btSelectScreenshotsFolder = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.edScreenshotsFolder = new System.Windows.Forms.TextBox();
            this.tbJPEGQuality = new System.Windows.Forms.TrackBar();
            this.tabPage55 = new System.Windows.Forms.TabPage();
            this.edScreenshotHeight = new System.Windows.Forms.TextBox();
            this.label176 = new System.Windows.Forms.Label();
            this.edScreenshotWidth = new System.Windows.Forms.TextBox();
            this.label177 = new System.Windows.Forms.Label();
            this.cbScreenshotResize = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label29 = new System.Windows.Forms.Label();
            this.cbSourceMode = new System.Windows.Forms.ComboBox();
            this.lbSourceFiles = new System.Windows.Forms.ListBox();
            this.mnPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnPlaylistRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPlaylistRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label30 = new System.Windows.Forms.Label();
            this.btAddFileToPlaylist = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label37 = new System.Windows.Forms.Label();
            this.edCustomSourceFilter = new System.Windows.Forms.TextBox();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.tabControl1.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage49.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTags)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl17.SuspendLayout();
            this.tabPage68.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.tabPage29.SuspendLayout();
            this.tabPage42.SuspendLayout();
            this.tabPage18.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.tabPage19.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.tabPage22.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.tabPage43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage69.SuspendLayout();
            this.tabPage59.SuspendLayout();
            this.tabPage51.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).BeginInit();
            this.tabPage46.SuspendLayout();
            this.tabPage48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.tabControl18.SuspendLayout();
            this.tabPage71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).BeginInit();
            this.tabPage72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).BeginInit();
            this.tabPage73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudDynAmp)).BeginInit();
            this.tabPage75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAud3DSound)).BeginInit();
            this.tabPage76.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudTrueBass)).BeginInit();
            this.tabPage27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudPitchShift)).BeginInit();
            this.tabPage50.SuspendLayout();
            this.groupBox41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).BeginInit();
            this.tabPage28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabPage32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOSDTranspLevel)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.tabPage34.SuspendLayout();
            this.tabPage47.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabControl9.SuspendLayout();
            this.tabPage44.SuspendLayout();
            this.tabPage45.SuspendLayout();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage23.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.tabPage24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbReversePlaybackTrackbar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabControl13.SuspendLayout();
            this.tabPage54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).BeginInit();
            this.tabPage55.SuspendLayout();
            this.mnPlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage20);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage48);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage50);
            this.tabControl1.Controls.Add(this.tabPage28);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage21);
            this.tabControl1.Controls.Add(this.tabPage23);
            this.tabControl1.Controls.Add(this.tabPage24);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 797);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.linkLabel2);
            this.tabPage20.Controls.Add(this.linkLabel7);
            this.tabPage20.Controls.Add(this.label25);
            this.tabPage20.Controls.Add(this.label20);
            this.tabPage20.Controls.Add(this.groupBox6);
            this.tabPage20.Location = new System.Drawing.Point(4, 29);
            this.tabPage20.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage20.Size = new System.Drawing.Size(456, 764);
            this.tabPage20.TabIndex = 15;
            this.tabPage20.Text = "Source mode";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(171, 229);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(34, 20);
            this.linkLabel2.TabIndex = 85;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "x64";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(126, 229);
            this.linkLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(34, 20);
            this.linkLabel7.TabIndex = 84;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "x86";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 229);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 20);
            this.label25.TabIndex = 83;
            this.label25.Text = "VLC engine ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 197);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(398, 20);
            this.label20.TabIndex = 82;
            this.label20.Text = "Please install VLC redist EXE or NuGet package to use";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbGPUDirect3D);
            this.groupBox6.Controls.Add(this.rbGPUDXVANative);
            this.groupBox6.Controls.Add(this.rbGPUDXVACopyBack);
            this.groupBox6.Controls.Add(this.rbGPUIntel);
            this.groupBox6.Controls.Add(this.rbGPUNVidia);
            this.groupBox6.Location = new System.Drawing.Point(9, 9);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(420, 166);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "GPU decoder";
            // 
            // rbGPUDirect3D
            // 
            this.rbGPUDirect3D.AutoSize = true;
            this.rbGPUDirect3D.Location = new System.Drawing.Point(20, 112);
            this.rbGPUDirect3D.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGPUDirect3D.Name = "rbGPUDirect3D";
            this.rbGPUDirect3D.Size = new System.Drawing.Size(119, 24);
            this.rbGPUDirect3D.TabIndex = 4;
            this.rbGPUDirect3D.Text = "Direct3D 11";
            this.rbGPUDirect3D.UseVisualStyleBackColor = true;
            // 
            // rbGPUDXVANative
            // 
            this.rbGPUDXVANative.AutoSize = true;
            this.rbGPUDXVANative.Location = new System.Drawing.Point(196, 77);
            this.rbGPUDXVANative.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGPUDXVANative.Name = "rbGPUDXVANative";
            this.rbGPUDXVANative.Size = new System.Drawing.Size(144, 24);
            this.rbGPUDXVANative.TabIndex = 3;
            this.rbGPUDXVANative.Text = "DXVA2 (native)";
            this.rbGPUDXVANative.UseVisualStyleBackColor = true;
            // 
            // rbGPUDXVACopyBack
            // 
            this.rbGPUDXVACopyBack.AutoSize = true;
            this.rbGPUDXVACopyBack.Checked = true;
            this.rbGPUDXVACopyBack.Location = new System.Drawing.Point(20, 77);
            this.rbGPUDXVACopyBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGPUDXVACopyBack.Name = "rbGPUDXVACopyBack";
            this.rbGPUDXVACopyBack.Size = new System.Drawing.Size(174, 24);
            this.rbGPUDXVACopyBack.TabIndex = 2;
            this.rbGPUDXVACopyBack.TabStop = true;
            this.rbGPUDXVACopyBack.Text = "DXVA2 (copy-back)";
            this.rbGPUDXVACopyBack.UseVisualStyleBackColor = true;
            // 
            // rbGPUIntel
            // 
            this.rbGPUIntel.AutoSize = true;
            this.rbGPUIntel.Location = new System.Drawing.Point(196, 42);
            this.rbGPUIntel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGPUIntel.Name = "rbGPUIntel";
            this.rbGPUIntel.Size = new System.Drawing.Size(144, 24);
            this.rbGPUIntel.TabIndex = 1;
            this.rbGPUIntel.Text = "Intel QuickSync";
            this.rbGPUIntel.UseVisualStyleBackColor = true;
            // 
            // rbGPUNVidia
            // 
            this.rbGPUNVidia.AutoSize = true;
            this.rbGPUNVidia.Location = new System.Drawing.Point(20, 42);
            this.rbGPUNVidia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGPUNVidia.Name = "rbGPUNVidia";
            this.rbGPUNVidia.Size = new System.Drawing.Size(133, 24);
            this.rbGPUNVidia.TabIndex = 0;
            this.rbGPUNVidia.Text = "nVidia CUVID";
            this.rbGPUNVidia.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbUseLibMediaInfo);
            this.tabPage1.Controls.Add(this.btReadInfo);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(456, 764);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbUseLibMediaInfo
            // 
            this.cbUseLibMediaInfo.AutoSize = true;
            this.cbUseLibMediaInfo.Checked = true;
            this.cbUseLibMediaInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseLibMediaInfo.Location = new System.Drawing.Point(22, 574);
            this.cbUseLibMediaInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUseLibMediaInfo.Name = "cbUseLibMediaInfo";
            this.cbUseLibMediaInfo.Size = new System.Drawing.Size(154, 24);
            this.cbUseLibMediaInfo.TabIndex = 2;
            this.cbUseLibMediaInfo.Text = "Use libMediaInfo";
            this.cbUseLibMediaInfo.UseVisualStyleBackColor = true;
            // 
            // btReadInfo
            // 
            this.btReadInfo.Location = new System.Drawing.Point(22, 674);
            this.btReadInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btReadInfo.Name = "btReadInfo";
            this.btReadInfo.Size = new System.Drawing.Size(112, 35);
            this.btReadInfo.TabIndex = 1;
            this.btReadInfo.Text = "Read info";
            this.btReadInfo.UseVisualStyleBackColor = true;
            this.btReadInfo.Click += new System.EventHandler(this.btReadInfo_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage49);
            this.tabControl2.Location = new System.Drawing.Point(24, 25);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(408, 526);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.mmInfo);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage6.Size = new System.Drawing.Size(400, 493);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "File";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // mmInfo
            // 
            this.mmInfo.Location = new System.Drawing.Point(24, 31);
            this.mmInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmInfo.Multiline = true;
            this.mmInfo.Name = "mmInfo";
            this.mmInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmInfo.Size = new System.Drawing.Size(346, 358);
            this.mmInfo.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.lbDVDTitles);
            this.tabPage7.Controls.Add(this.cbDVDSubtitles);
            this.tabPage7.Controls.Add(this.label4);
            this.tabPage7.Controls.Add(this.cbDVDAudio);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.edDVDVideo);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage7.Size = new System.Drawing.Size(400, 493);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "DVD";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // lbDVDTitles
            // 
            this.lbDVDTitles.FormattingEnabled = true;
            this.lbDVDTitles.ItemHeight = 20;
            this.lbDVDTitles.Location = new System.Drawing.Point(27, 54);
            this.lbDVDTitles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbDVDTitles.Name = "lbDVDTitles";
            this.lbDVDTitles.Size = new System.Drawing.Size(342, 184);
            this.lbDVDTitles.TabIndex = 8;
            this.lbDVDTitles.Click += new System.EventHandler(this.lbDVDTitles_Click);
            // 
            // cbDVDSubtitles
            // 
            this.cbDVDSubtitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDSubtitles.FormattingEnabled = true;
            this.cbDVDSubtitles.Location = new System.Drawing.Point(27, 423);
            this.cbDVDSubtitles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDSubtitles.Name = "cbDVDSubtitles";
            this.cbDVDSubtitles.Size = new System.Drawing.Size(342, 28);
            this.cbDVDSubtitles.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 398);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subtitles";
            // 
            // cbDVDAudio
            // 
            this.cbDVDAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDAudio.FormattingEnabled = true;
            this.cbDVDAudio.Location = new System.Drawing.Point(27, 345);
            this.cbDVDAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDAudio.Name = "cbDVDAudio";
            this.cbDVDAudio.Size = new System.Drawing.Size(342, 28);
            this.cbDVDAudio.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 320);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Audio streams";
            // 
            // edDVDVideo
            // 
            this.edDVDVideo.Location = new System.Drawing.Point(27, 271);
            this.edDVDVideo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDVDVideo.Name = "edDVDVideo";
            this.edDVDVideo.Size = new System.Drawing.Size(342, 26);
            this.edDVDVideo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titles";
            // 
            // tabPage49
            // 
            this.tabPage49.Controls.Add(this.imgTags);
            this.tabPage49.Controls.Add(this.edTags);
            this.tabPage49.Controls.Add(this.btReadTags);
            this.tabPage49.Location = new System.Drawing.Point(4, 29);
            this.tabPage49.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage49.Name = "tabPage49";
            this.tabPage49.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage49.Size = new System.Drawing.Size(400, 493);
            this.tabPage49.TabIndex = 2;
            this.tabPage49.Text = "Tags";
            this.tabPage49.UseVisualStyleBackColor = true;
            // 
            // imgTags
            // 
            this.imgTags.Location = new System.Drawing.Point(237, 325);
            this.imgTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgTags.Name = "imgTags";
            this.imgTags.Size = new System.Drawing.Size(135, 138);
            this.imgTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTags.TabIndex = 2;
            this.imgTags.TabStop = false;
            // 
            // edTags
            // 
            this.edTags.Location = new System.Drawing.Point(24, 26);
            this.edTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edTags.Multiline = true;
            this.edTags.Name = "edTags";
            this.edTags.Size = new System.Drawing.Size(346, 287);
            this.edTags.TabIndex = 1;
            // 
            // btReadTags
            // 
            this.btReadTags.Location = new System.Drawing.Point(24, 428);
            this.btReadTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btReadTags.Name = "btReadTags";
            this.btReadTags.Size = new System.Drawing.Size(112, 35);
            this.btReadTags.TabIndex = 0;
            this.btReadTags.Text = "Read tags";
            this.btReadTags.UseVisualStyleBackColor = true;
            this.btReadTags.Click += new System.EventHandler(this.btReadTags_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbBalance4);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbVolume4);
            this.tabPage2.Controls.Add(this.cbAudioStream4);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbBalance3);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tbVolume3);
            this.tabPage2.Controls.Add(this.cbAudioStream3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbBalance2);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbVolume2);
            this.tabPage2.Controls.Add(this.cbAudioStream2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbBalance1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbVolume1);
            this.tabPage2.Controls.Add(this.cbAudioStream1);
            this.tabPage2.Controls.Add(this.cbPlayAudio);
            this.tabPage2.Controls.Add(this.cbAudioOutputDevice);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(456, 764);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Audio output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 480);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Balance";
            // 
            // tbBalance4
            // 
            this.tbBalance4.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance4.Location = new System.Drawing.Point(294, 505);
            this.tbBalance4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBalance4.Maximum = 100;
            this.tbBalance4.Minimum = -100;
            this.tbBalance4.Name = "tbBalance4";
            this.tbBalance4.Size = new System.Drawing.Size(128, 69);
            this.tbBalance4.TabIndex = 21;
            this.tbBalance4.Scroll += new System.EventHandler(this.tbBalance4_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(150, 480);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Volume";
            // 
            // tbVolume4
            // 
            this.tbVolume4.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume4.Location = new System.Drawing.Point(154, 505);
            this.tbVolume4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume4.Maximum = 100;
            this.tbVolume4.Name = "tbVolume4";
            this.tbVolume4.Size = new System.Drawing.Size(128, 69);
            this.tbVolume4.TabIndex = 19;
            this.tbVolume4.Value = 85;
            this.tbVolume4.Scroll += new System.EventHandler(this.tbVolume4_Scroll);
            // 
            // cbAudioStream4
            // 
            this.cbAudioStream4.AutoSize = true;
            this.cbAudioStream4.Location = new System.Drawing.Point(28, 457);
            this.cbAudioStream4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioStream4.Name = "cbAudioStream4";
            this.cbAudioStream4.Size = new System.Drawing.Size(100, 24);
            this.cbAudioStream4.TabIndex = 18;
            this.cbAudioStream4.Text = "Stream 4";
            this.cbAudioStream4.UseVisualStyleBackColor = true;
            this.cbAudioStream4.CheckedChanged += new System.EventHandler(this.cbAudioStream4_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 378);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Balance";
            // 
            // tbBalance3
            // 
            this.tbBalance3.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance3.Location = new System.Drawing.Point(294, 403);
            this.tbBalance3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBalance3.Maximum = 100;
            this.tbBalance3.Minimum = -100;
            this.tbBalance3.Name = "tbBalance3";
            this.tbBalance3.Size = new System.Drawing.Size(128, 69);
            this.tbBalance3.TabIndex = 16;
            this.tbBalance3.Scroll += new System.EventHandler(this.tbBalance3_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(150, 378);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Volume";
            // 
            // tbVolume3
            // 
            this.tbVolume3.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume3.Location = new System.Drawing.Point(154, 403);
            this.tbVolume3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume3.Maximum = 100;
            this.tbVolume3.Name = "tbVolume3";
            this.tbVolume3.Size = new System.Drawing.Size(128, 69);
            this.tbVolume3.TabIndex = 14;
            this.tbVolume3.Value = 85;
            this.tbVolume3.Scroll += new System.EventHandler(this.tbVolume3_Scroll);
            // 
            // cbAudioStream3
            // 
            this.cbAudioStream3.AutoSize = true;
            this.cbAudioStream3.Location = new System.Drawing.Point(28, 355);
            this.cbAudioStream3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioStream3.Name = "cbAudioStream3";
            this.cbAudioStream3.Size = new System.Drawing.Size(100, 24);
            this.cbAudioStream3.TabIndex = 13;
            this.cbAudioStream3.Text = "Stream 3";
            this.cbAudioStream3.UseVisualStyleBackColor = true;
            this.cbAudioStream3.CheckedChanged += new System.EventHandler(this.cbAudioStream3_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Balance";
            // 
            // tbBalance2
            // 
            this.tbBalance2.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance2.Location = new System.Drawing.Point(294, 308);
            this.tbBalance2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBalance2.Maximum = 100;
            this.tbBalance2.Minimum = -100;
            this.tbBalance2.Name = "tbBalance2";
            this.tbBalance2.Size = new System.Drawing.Size(128, 69);
            this.tbBalance2.TabIndex = 11;
            this.tbBalance2.Scroll += new System.EventHandler(this.tbBalance2_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 283);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Volume";
            // 
            // tbVolume2
            // 
            this.tbVolume2.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume2.Location = new System.Drawing.Point(154, 308);
            this.tbVolume2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume2.Maximum = 100;
            this.tbVolume2.Name = "tbVolume2";
            this.tbVolume2.Size = new System.Drawing.Size(128, 69);
            this.tbVolume2.TabIndex = 9;
            this.tbVolume2.Value = 85;
            this.tbVolume2.Scroll += new System.EventHandler(this.tbVolume2_Scroll);
            // 
            // cbAudioStream2
            // 
            this.cbAudioStream2.AutoSize = true;
            this.cbAudioStream2.Location = new System.Drawing.Point(28, 260);
            this.cbAudioStream2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioStream2.Name = "cbAudioStream2";
            this.cbAudioStream2.Size = new System.Drawing.Size(100, 24);
            this.cbAudioStream2.TabIndex = 8;
            this.cbAudioStream2.Text = "Stream 2";
            this.cbAudioStream2.UseVisualStyleBackColor = true;
            this.cbAudioStream2.CheckedChanged += new System.EventHandler(this.cbAudioStream2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            this.tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance1.Location = new System.Drawing.Point(294, 212);
            this.tbBalance1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBalance1.Maximum = 100;
            this.tbBalance1.Minimum = -100;
            this.tbBalance1.Name = "tbBalance1";
            this.tbBalance1.Size = new System.Drawing.Size(128, 69);
            this.tbBalance1.TabIndex = 6;
            this.tbBalance1.Scroll += new System.EventHandler(this.tbBalance1_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 188);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume1.Location = new System.Drawing.Point(154, 212);
            this.tbVolume1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume1.Maximum = 100;
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(128, 69);
            this.tbVolume1.TabIndex = 4;
            this.tbVolume1.Value = 85;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // cbAudioStream1
            // 
            this.cbAudioStream1.AutoSize = true;
            this.cbAudioStream1.Location = new System.Drawing.Point(28, 165);
            this.cbAudioStream1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioStream1.Name = "cbAudioStream1";
            this.cbAudioStream1.Size = new System.Drawing.Size(100, 24);
            this.cbAudioStream1.TabIndex = 3;
            this.cbAudioStream1.Text = "Stream 1";
            this.cbAudioStream1.UseVisualStyleBackColor = true;
            this.cbAudioStream1.CheckedChanged += new System.EventHandler(this.cbAudioStream1_CheckedChanged);
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = true;
            this.cbPlayAudio.Checked = true;
            this.cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlayAudio.Location = new System.Drawing.Point(28, 95);
            this.cbPlayAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPlayAudio.Name = "cbPlayAudio";
            this.cbPlayAudio.Size = new System.Drawing.Size(107, 24);
            this.cbPlayAudio.TabIndex = 2;
            this.cbPlayAudio.Text = "Play audio";
            this.cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(28, 54);
            this.cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(391, 28);
            this.cbAudioOutputDevice.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Audio output";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl4);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(456, 764);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Display";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage16);
            this.tabControl4.Controls.Add(this.tabPage17);
            this.tabControl4.Location = new System.Drawing.Point(4, 9);
            this.tabControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(438, 738);
            this.tabControl4.TabIndex = 17;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.label393);
            this.tabPage16.Controls.Add(this.cbDirect2DRotate);
            this.tabPage16.Controls.Add(this.pnVideoRendererBGColor);
            this.tabPage16.Controls.Add(this.label394);
            this.tabPage16.Controls.Add(this.btFullScreen);
            this.tabPage16.Controls.Add(this.groupBox28);
            this.tabPage16.Controls.Add(this.cbScreenFlipVertical);
            this.tabPage16.Controls.Add(this.cbScreenFlipHorizontal);
            this.tabPage16.Controls.Add(this.cbStretch);
            this.tabPage16.Controls.Add(this.groupBox13);
            this.tabPage16.Controls.Add(this.label15);
            this.tabPage16.Controls.Add(this.edAspectRatioY);
            this.tabPage16.Controls.Add(this.edAspectRatioX);
            this.tabPage16.Controls.Add(this.cbAspectRatioUseCustom);
            this.tabPage16.Location = new System.Drawing.Point(4, 29);
            this.tabPage16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage16.Size = new System.Drawing.Size(430, 705);
            this.tabPage16.TabIndex = 0;
            this.tabPage16.Text = "Main";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // label393
            // 
            this.label393.AutoSize = true;
            this.label393.Location = new System.Drawing.Point(212, 489);
            this.label393.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label393.Name = "label393";
            this.label393.Size = new System.Drawing.Size(118, 20);
            this.label393.TabIndex = 35;
            this.label393.Text = "Direct2D rotate";
            // 
            // cbDirect2DRotate
            // 
            this.cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirect2DRotate.FormattingEnabled = true;
            this.cbDirect2DRotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbDirect2DRotate.Location = new System.Drawing.Point(216, 514);
            this.cbDirect2DRotate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDirect2DRotate.Name = "cbDirect2DRotate";
            this.cbDirect2DRotate.Size = new System.Drawing.Size(181, 28);
            this.cbDirect2DRotate.TabIndex = 34;
            this.cbDirect2DRotate.SelectedIndexChanged += new System.EventHandler(this.cbDirect2DRotate_SelectedIndexChanged);
            // 
            // pnVideoRendererBGColor
            // 
            this.pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black;
            this.pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnVideoRendererBGColor.Location = new System.Drawing.Point(180, 337);
            this.pnVideoRendererBGColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnVideoRendererBGColor.Name = "pnVideoRendererBGColor";
            this.pnVideoRendererBGColor.Size = new System.Drawing.Size(35, 36);
            this.pnVideoRendererBGColor.TabIndex = 33;
            this.pnVideoRendererBGColor.Click += new System.EventHandler(this.pnVideoRendererBGColor_Click);
            // 
            // label394
            // 
            this.label394.AutoSize = true;
            this.label394.Location = new System.Drawing.Point(20, 345);
            this.label394.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label394.Name = "label394";
            this.label394.Size = new System.Drawing.Size(133, 20);
            this.label394.TabIndex = 32;
            this.label394.Text = "Background color";
            // 
            // btFullScreen
            // 
            this.btFullScreen.Location = new System.Drawing.Point(216, 555);
            this.btFullScreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFullScreen.Name = "btFullScreen";
            this.btFullScreen.Size = new System.Drawing.Size(183, 35);
            this.btFullScreen.TabIndex = 31;
            this.btFullScreen.Text = "Full screen";
            this.btFullScreen.UseVisualStyleBackColor = true;
            this.btFullScreen.Click += new System.EventHandler(this.btFullScreen_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.btZoomReset);
            this.groupBox28.Controls.Add(this.btZoomShiftRight);
            this.groupBox28.Controls.Add(this.btZoomShiftLeft);
            this.groupBox28.Controls.Add(this.btZoomOut);
            this.groupBox28.Controls.Add(this.btZoomIn);
            this.groupBox28.Controls.Add(this.btZoomShiftDown);
            this.groupBox28.Controls.Add(this.btZoomShiftUp);
            this.groupBox28.Location = new System.Drawing.Point(24, 489);
            this.groupBox28.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox28.Size = new System.Drawing.Size(178, 200);
            this.groupBox28.TabIndex = 30;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Zoom";
            // 
            // btZoomReset
            // 
            this.btZoomReset.Location = new System.Drawing.Point(52, 155);
            this.btZoomReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomReset.Name = "btZoomReset";
            this.btZoomReset.Size = new System.Drawing.Size(75, 35);
            this.btZoomReset.TabIndex = 6;
            this.btZoomReset.Text = "Reset";
            this.btZoomReset.UseVisualStyleBackColor = true;
            this.btZoomReset.Click += new System.EventHandler(this.btZoomReset_Click);
            // 
            // btZoomShiftRight
            // 
            this.btZoomShiftRight.Location = new System.Drawing.Point(128, 51);
            this.btZoomShiftRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomShiftRight.Name = "btZoomShiftRight";
            this.btZoomShiftRight.Size = new System.Drawing.Size(32, 74);
            this.btZoomShiftRight.TabIndex = 5;
            this.btZoomShiftRight.Text = "R";
            this.btZoomShiftRight.UseVisualStyleBackColor = true;
            this.btZoomShiftRight.Click += new System.EventHandler(this.btZoomShiftRight_Click);
            // 
            // btZoomShiftLeft
            // 
            this.btZoomShiftLeft.Location = new System.Drawing.Point(20, 49);
            this.btZoomShiftLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomShiftLeft.Name = "btZoomShiftLeft";
            this.btZoomShiftLeft.Size = new System.Drawing.Size(32, 74);
            this.btZoomShiftLeft.TabIndex = 4;
            this.btZoomShiftLeft.Text = "L";
            this.btZoomShiftLeft.UseVisualStyleBackColor = true;
            this.btZoomShiftLeft.Click += new System.EventHandler(this.btZoomShiftLeft_Click);
            // 
            // btZoomOut
            // 
            this.btZoomOut.Location = new System.Drawing.Point(92, 69);
            this.btZoomOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomOut.Name = "btZoomOut";
            this.btZoomOut.Size = new System.Drawing.Size(34, 35);
            this.btZoomOut.TabIndex = 3;
            this.btZoomOut.Text = "-";
            this.btZoomOut.UseVisualStyleBackColor = true;
            this.btZoomOut.Click += new System.EventHandler(this.btZoomOut_Click);
            // 
            // btZoomIn
            // 
            this.btZoomIn.Location = new System.Drawing.Point(52, 69);
            this.btZoomIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomIn.Name = "btZoomIn";
            this.btZoomIn.Size = new System.Drawing.Size(33, 35);
            this.btZoomIn.TabIndex = 2;
            this.btZoomIn.Text = "+";
            this.btZoomIn.UseVisualStyleBackColor = true;
            this.btZoomIn.Click += new System.EventHandler(this.btZoomIn_Click);
            // 
            // btZoomShiftDown
            // 
            this.btZoomShiftDown.Location = new System.Drawing.Point(51, 108);
            this.btZoomShiftDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomShiftDown.Name = "btZoomShiftDown";
            this.btZoomShiftDown.Size = new System.Drawing.Size(76, 35);
            this.btZoomShiftDown.TabIndex = 1;
            this.btZoomShiftDown.Text = "Down";
            this.btZoomShiftDown.UseVisualStyleBackColor = true;
            this.btZoomShiftDown.Click += new System.EventHandler(this.btZoomShiftDown_Click);
            // 
            // btZoomShiftUp
            // 
            this.btZoomShiftUp.Location = new System.Drawing.Point(51, 31);
            this.btZoomShiftUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZoomShiftUp.Name = "btZoomShiftUp";
            this.btZoomShiftUp.Size = new System.Drawing.Size(76, 35);
            this.btZoomShiftUp.TabIndex = 0;
            this.btZoomShiftUp.Text = "Up";
            this.btZoomShiftUp.UseVisualStyleBackColor = true;
            this.btZoomShiftUp.Click += new System.EventHandler(this.btZoomShiftUp_Click);
            // 
            // cbScreenFlipVertical
            // 
            this.cbScreenFlipVertical.AutoSize = true;
            this.cbScreenFlipVertical.Location = new System.Drawing.Point(264, 374);
            this.cbScreenFlipVertical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbScreenFlipVertical.Name = "cbScreenFlipVertical";
            this.cbScreenFlipVertical.Size = new System.Drawing.Size(113, 24);
            this.cbScreenFlipVertical.TabIndex = 29;
            this.cbScreenFlipVertical.Text = "Flip vertical";
            this.cbScreenFlipVertical.UseVisualStyleBackColor = true;
            this.cbScreenFlipVertical.CheckedChanged += new System.EventHandler(this.cbScreenFlipVertical_CheckedChanged);
            // 
            // cbScreenFlipHorizontal
            // 
            this.cbScreenFlipHorizontal.AutoSize = true;
            this.cbScreenFlipHorizontal.Location = new System.Drawing.Point(264, 338);
            this.cbScreenFlipHorizontal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal";
            this.cbScreenFlipHorizontal.Size = new System.Drawing.Size(133, 24);
            this.cbScreenFlipHorizontal.TabIndex = 28;
            this.cbScreenFlipHorizontal.Text = "Flip horizontal";
            this.cbScreenFlipHorizontal.UseVisualStyleBackColor = true;
            this.cbScreenFlipHorizontal.CheckedChanged += new System.EventHandler(this.cbScreenFlipHorizontal_CheckedChanged);
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = true;
            this.cbStretch.Location = new System.Drawing.Point(264, 412);
            this.cbStretch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStretch.Name = "cbStretch";
            this.cbStretch.Size = new System.Drawing.Size(128, 24);
            this.cbStretch.TabIndex = 27;
            this.cbStretch.Text = "Stretch video";
            this.cbStretch.UseVisualStyleBackColor = true;
            this.cbStretch.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbNDIStreaming);
            this.groupBox13.Controls.Add(this.rbVirtualCameraOutput);
            this.groupBox13.Controls.Add(this.rbMadVR);
            this.groupBox13.Controls.Add(this.rbDirect2D);
            this.groupBox13.Controls.Add(this.rbNone);
            this.groupBox13.Controls.Add(this.rbEVR);
            this.groupBox13.Controls.Add(this.rbVMR9);
            this.groupBox13.Location = new System.Drawing.Point(24, 9);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox13.Size = new System.Drawing.Size(375, 294);
            this.groupBox13.TabIndex = 26;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Video Renderer";
            // 
            // rbNDIStreaming
            // 
            this.rbNDIStreaming.AutoSize = true;
            this.rbNDIStreaming.Location = new System.Drawing.Point(20, 251);
            this.rbNDIStreaming.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNDIStreaming.Name = "rbNDIStreaming";
            this.rbNDIStreaming.Size = new System.Drawing.Size(136, 24);
            this.rbNDIStreaming.TabIndex = 7;
            this.rbNDIStreaming.Text = "NDI streaming";
            this.rbNDIStreaming.UseVisualStyleBackColor = true;
            // 
            // rbVirtualCameraOutput
            // 
            this.rbVirtualCameraOutput.AutoSize = true;
            this.rbVirtualCameraOutput.Location = new System.Drawing.Point(20, 216);
            this.rbVirtualCameraOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVirtualCameraOutput.Name = "rbVirtualCameraOutput";
            this.rbVirtualCameraOutput.Size = new System.Drawing.Size(247, 24);
            this.rbVirtualCameraOutput.TabIndex = 6;
            this.rbVirtualCameraOutput.Text = "Output to Virtual Camera SDK";
            this.rbVirtualCameraOutput.UseVisualStyleBackColor = true;
            // 
            // rbMadVR
            // 
            this.rbMadVR.AutoSize = true;
            this.rbMadVR.Location = new System.Drawing.Point(20, 145);
            this.rbMadVR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMadVR.Name = "rbMadVR";
            this.rbMadVR.Size = new System.Drawing.Size(158, 24);
            this.rbMadVR.TabIndex = 5;
            this.rbMadVR.Text = "madVR (optional)";
            this.rbMadVR.UseVisualStyleBackColor = true;
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = true;
            this.rbDirect2D.Location = new System.Drawing.Point(20, 109);
            this.rbDirect2D.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDirect2D.Name = "rbDirect2D";
            this.rbDirect2D.Size = new System.Drawing.Size(97, 24);
            this.rbDirect2D.TabIndex = 4;
            this.rbDirect2D.Text = "Direct2D";
            this.rbDirect2D.UseVisualStyleBackColor = true;
            this.rbDirect2D.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(20, 180);
            this.rbNone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(72, 24);
            this.rbNone.TabIndex = 3;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbEVR
            // 
            this.rbEVR.AutoSize = true;
            this.rbEVR.Checked = true;
            this.rbEVR.Location = new System.Drawing.Point(20, 74);
            this.rbEVR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEVR.Name = "rbEVR";
            this.rbEVR.Size = new System.Drawing.Size(286, 24);
            this.rbEVR.TabIndex = 2;
            this.rbEVR.TabStop = true;
            this.rbEVR.Text = "Enhanced Video Renderer (default)";
            this.rbEVR.UseVisualStyleBackColor = true;
            this.rbEVR.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbVMR9
            // 
            this.rbVMR9.AutoSize = true;
            this.rbVMR9.Location = new System.Drawing.Point(20, 39);
            this.rbVMR9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVMR9.Name = "rbVMR9";
            this.rbVMR9.Size = new System.Drawing.Size(207, 24);
            this.rbVMR9.TabIndex = 1;
            this.rbVMR9.Text = "Video Mixing Renderer 9";
            this.rbVMR9.UseVisualStyleBackColor = true;
            this.rbVMR9.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(102, 452);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "x";
            // 
            // edAspectRatioY
            // 
            this.edAspectRatioY.Location = new System.Drawing.Point(123, 448);
            this.edAspectRatioY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edAspectRatioY.Name = "edAspectRatioY";
            this.edAspectRatioY.Size = new System.Drawing.Size(43, 26);
            this.edAspectRatioY.TabIndex = 24;
            this.edAspectRatioY.Text = "9";
            // 
            // edAspectRatioX
            // 
            this.edAspectRatioX.Location = new System.Drawing.Point(50, 448);
            this.edAspectRatioX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edAspectRatioX.Name = "edAspectRatioX";
            this.edAspectRatioX.Size = new System.Drawing.Size(43, 26);
            this.edAspectRatioX.TabIndex = 23;
            this.edAspectRatioX.Text = "16";
            // 
            // cbAspectRatioUseCustom
            // 
            this.cbAspectRatioUseCustom.AutoSize = true;
            this.cbAspectRatioUseCustom.Location = new System.Drawing.Point(24, 412);
            this.cbAspectRatioUseCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAspectRatioUseCustom.Name = "cbAspectRatioUseCustom";
            this.cbAspectRatioUseCustom.Size = new System.Drawing.Size(207, 24);
            this.cbAspectRatioUseCustom.TabIndex = 22;
            this.cbAspectRatioUseCustom.Text = "Use custom aspect ratio";
            this.cbAspectRatioUseCustom.UseVisualStyleBackColor = true;
            this.cbAspectRatioUseCustom.CheckedChanged += new System.EventHandler(this.cbAspectRatioUseCustom_CheckedChanged);
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.cbMultiscreenDrawOnExternalDisplays);
            this.tabPage17.Controls.Add(this.cbMultiscreenDrawOnPanels);
            this.tabPage17.Controls.Add(this.cbFlipHorizontal2);
            this.tabPage17.Controls.Add(this.cbFlipVertical2);
            this.tabPage17.Controls.Add(this.cbStretch2);
            this.tabPage17.Controls.Add(this.cbFlipHorizontal1);
            this.tabPage17.Controls.Add(this.cbFlipVertical1);
            this.tabPage17.Controls.Add(this.cbStretch1);
            this.tabPage17.Controls.Add(this.pnScreen2);
            this.tabPage17.Controls.Add(this.pnScreen1);
            this.tabPage17.Location = new System.Drawing.Point(4, 29);
            this.tabPage17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage17.Size = new System.Drawing.Size(430, 705);
            this.tabPage17.TabIndex = 1;
            this.tabPage17.Text = "Multiscreen";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnExternalDisplays
            // 
            this.cbMultiscreenDrawOnExternalDisplays.AutoSize = true;
            this.cbMultiscreenDrawOnExternalDisplays.Location = new System.Drawing.Point(15, 52);
            this.cbMultiscreenDrawOnExternalDisplays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMultiscreenDrawOnExternalDisplays.Name = "cbMultiscreenDrawOnExternalDisplays";
            this.cbMultiscreenDrawOnExternalDisplays.Size = new System.Drawing.Size(255, 24);
            this.cbMultiscreenDrawOnExternalDisplays.TabIndex = 23;
            this.cbMultiscreenDrawOnExternalDisplays.Text = "Draw video on external displays";
            this.cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnPanels
            // 
            this.cbMultiscreenDrawOnPanels.AutoSize = true;
            this.cbMultiscreenDrawOnPanels.Location = new System.Drawing.Point(15, 17);
            this.cbMultiscreenDrawOnPanels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMultiscreenDrawOnPanels.Name = "cbMultiscreenDrawOnPanels";
            this.cbMultiscreenDrawOnPanels.Size = new System.Drawing.Size(186, 24);
            this.cbMultiscreenDrawOnPanels.TabIndex = 22;
            this.cbMultiscreenDrawOnPanels.Text = "Draw video on panels";
            this.cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = true;
            // 
            // cbFlipHorizontal2
            // 
            this.cbFlipHorizontal2.AutoSize = true;
            this.cbFlipHorizontal2.Location = new System.Drawing.Point(243, 663);
            this.cbFlipHorizontal2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipHorizontal2.Name = "cbFlipHorizontal2";
            this.cbFlipHorizontal2.Size = new System.Drawing.Size(133, 24);
            this.cbFlipHorizontal2.TabIndex = 21;
            this.cbFlipHorizontal2.Text = "Flip horizontal";
            this.cbFlipHorizontal2.UseVisualStyleBackColor = true;
            this.cbFlipHorizontal2.CheckedChanged += new System.EventHandler(this.cbFlipStretch2_CheckedChanged);
            // 
            // cbFlipVertical2
            // 
            this.cbFlipVertical2.AutoSize = true;
            this.cbFlipVertical2.Location = new System.Drawing.Point(114, 663);
            this.cbFlipVertical2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipVertical2.Name = "cbFlipVertical2";
            this.cbFlipVertical2.Size = new System.Drawing.Size(113, 24);
            this.cbFlipVertical2.TabIndex = 20;
            this.cbFlipVertical2.Text = "Flip vertical";
            this.cbFlipVertical2.UseVisualStyleBackColor = true;
            this.cbFlipVertical2.CheckedChanged += new System.EventHandler(this.cbFlipStretch2_CheckedChanged);
            // 
            // cbStretch2
            // 
            this.cbStretch2.AutoSize = true;
            this.cbStretch2.Location = new System.Drawing.Point(15, 663);
            this.cbStretch2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStretch2.Name = "cbStretch2";
            this.cbStretch2.Size = new System.Drawing.Size(87, 24);
            this.cbStretch2.TabIndex = 19;
            this.cbStretch2.Text = "Stretch";
            this.cbStretch2.UseVisualStyleBackColor = true;
            this.cbStretch2.CheckedChanged += new System.EventHandler(this.cbFlipStretch2_CheckedChanged);
            // 
            // cbFlipHorizontal1
            // 
            this.cbFlipHorizontal1.AutoSize = true;
            this.cbFlipHorizontal1.Location = new System.Drawing.Point(243, 300);
            this.cbFlipHorizontal1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipHorizontal1.Name = "cbFlipHorizontal1";
            this.cbFlipHorizontal1.Size = new System.Drawing.Size(133, 24);
            this.cbFlipHorizontal1.TabIndex = 18;
            this.cbFlipHorizontal1.Text = "Flip horizontal";
            this.cbFlipHorizontal1.UseVisualStyleBackColor = true;
            this.cbFlipHorizontal1.CheckedChanged += new System.EventHandler(this.cbFlipStretch1_CheckedChanged);
            // 
            // cbFlipVertical1
            // 
            this.cbFlipVertical1.AutoSize = true;
            this.cbFlipVertical1.Location = new System.Drawing.Point(114, 300);
            this.cbFlipVertical1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipVertical1.Name = "cbFlipVertical1";
            this.cbFlipVertical1.Size = new System.Drawing.Size(113, 24);
            this.cbFlipVertical1.TabIndex = 17;
            this.cbFlipVertical1.Text = "Flip vertical";
            this.cbFlipVertical1.UseVisualStyleBackColor = true;
            this.cbFlipVertical1.CheckedChanged += new System.EventHandler(this.cbFlipStretch1_CheckedChanged);
            // 
            // cbStretch1
            // 
            this.cbStretch1.AutoSize = true;
            this.cbStretch1.Location = new System.Drawing.Point(15, 300);
            this.cbStretch1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStretch1.Name = "cbStretch1";
            this.cbStretch1.Size = new System.Drawing.Size(87, 24);
            this.cbStretch1.TabIndex = 16;
            this.cbStretch1.Text = "Stretch";
            this.cbStretch1.UseVisualStyleBackColor = true;
            this.cbStretch1.CheckedChanged += new System.EventHandler(this.cbFlipStretch1_CheckedChanged);
            // 
            // pnScreen2
            // 
            this.pnScreen2.BackColor = System.Drawing.Color.Black;
            this.pnScreen2.Location = new System.Drawing.Point(15, 335);
            this.pnScreen2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnScreen2.Name = "pnScreen2";
            this.pnScreen2.Size = new System.Drawing.Size(368, 314);
            this.pnScreen2.TabIndex = 15;
            // 
            // pnScreen1
            // 
            this.pnScreen1.BackColor = System.Drawing.Color.Black;
            this.pnScreen1.Location = new System.Drawing.Point(69, 97);
            this.pnScreen1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnScreen1.Name = "pnScreen1";
            this.pnScreen1.Size = new System.Drawing.Size(261, 194);
            this.pnScreen1.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl17);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(456, 764);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Video processing";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            this.tabControl17.Controls.Add(this.tabPage68);
            this.tabControl17.Controls.Add(this.tabPage69);
            this.tabControl17.Controls.Add(this.tabPage59);
            this.tabControl17.Controls.Add(this.tabPage51);
            this.tabControl17.Controls.Add(this.tabPage8);
            this.tabControl17.Controls.Add(this.tabPage15);
            this.tabControl17.Controls.Add(this.tabPage46);
            this.tabControl17.Location = new System.Drawing.Point(0, 9);
            this.tabControl17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl17.Name = "tabControl17";
            this.tabControl17.SelectedIndex = 0;
            this.tabControl17.Size = new System.Drawing.Size(447, 746);
            this.tabControl17.TabIndex = 37;
            // 
            // tabPage68
            // 
            this.tabPage68.Controls.Add(this.cbFlipY);
            this.tabPage68.Controls.Add(this.cbFlipX);
            this.tabPage68.Controls.Add(this.label201);
            this.tabPage68.Controls.Add(this.label200);
            this.tabPage68.Controls.Add(this.label199);
            this.tabPage68.Controls.Add(this.label198);
            this.tabPage68.Controls.Add(this.tabControl7);
            this.tabPage68.Controls.Add(this.tbContrast);
            this.tabPage68.Controls.Add(this.tbDarkness);
            this.tabPage68.Controls.Add(this.tbLightness);
            this.tabPage68.Controls.Add(this.tbSaturation);
            this.tabPage68.Controls.Add(this.cbInvert);
            this.tabPage68.Controls.Add(this.cbGreyscale);
            this.tabPage68.Controls.Add(this.cbVideoEffects);
            this.tabPage68.Location = new System.Drawing.Point(4, 29);
            this.tabPage68.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage68.Name = "tabPage68";
            this.tabPage68.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage68.Size = new System.Drawing.Size(439, 713);
            this.tabPage68.TabIndex = 0;
            this.tabPage68.Text = "Effects";
            this.tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(315, 243);
            this.cbFlipY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(75, 24);
            this.cbFlipY.TabIndex = 69;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(225, 243);
            this.cbFlipX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(75, 24);
            this.cbFlipX.TabIndex = 68;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            this.cbFlipX.CheckedChanged += new System.EventHandler(this.cbFlipX_CheckedChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(213, 135);
            this.label201.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(77, 20);
            this.label201.TabIndex = 63;
            this.label201.Text = "Darkness";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(9, 135);
            this.label200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(70, 20);
            this.label200.TabIndex = 62;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(213, 55);
            this.label199.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(83, 20);
            this.label199.TabIndex = 61;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(9, 55);
            this.label198.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(78, 20);
            this.label198.TabIndex = 60;
            this.label198.Text = "Lightness";
            // 
            // tabControl7
            // 
            this.tabControl7.Controls.Add(this.tabPage29);
            this.tabControl7.Controls.Add(this.tabPage42);
            this.tabControl7.Controls.Add(this.tabPage18);
            this.tabControl7.Controls.Add(this.tabPage19);
            this.tabControl7.Controls.Add(this.tabPage22);
            this.tabControl7.Controls.Add(this.tabPage43);
            this.tabControl7.Location = new System.Drawing.Point(4, 285);
            this.tabControl7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl7.Name = "tabControl7";
            this.tabControl7.SelectedIndex = 0;
            this.tabControl7.Size = new System.Drawing.Size(424, 422);
            this.tabControl7.TabIndex = 59;
            // 
            // tabPage29
            // 
            this.tabPage29.Controls.Add(this.btTextLogoRemove);
            this.tabPage29.Controls.Add(this.btTextLogoEdit);
            this.tabPage29.Controls.Add(this.lbTextLogos);
            this.tabPage29.Controls.Add(this.btTextLogoAdd);
            this.tabPage29.Location = new System.Drawing.Point(4, 29);
            this.tabPage29.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage29.Size = new System.Drawing.Size(416, 389);
            this.tabPage29.TabIndex = 0;
            this.tabPage29.Text = "Text logo";
            this.tabPage29.UseVisualStyleBackColor = true;
            // 
            // btTextLogoRemove
            // 
            this.btTextLogoRemove.Location = new System.Drawing.Point(309, 331);
            this.btTextLogoRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btTextLogoRemove.Name = "btTextLogoRemove";
            this.btTextLogoRemove.Size = new System.Drawing.Size(88, 35);
            this.btTextLogoRemove.TabIndex = 7;
            this.btTextLogoRemove.Text = "Remove";
            this.btTextLogoRemove.UseVisualStyleBackColor = true;
            this.btTextLogoRemove.Click += new System.EventHandler(this.btTextLogoRemove_Click);
            // 
            // btTextLogoEdit
            // 
            this.btTextLogoEdit.Location = new System.Drawing.Point(111, 331);
            this.btTextLogoEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btTextLogoEdit.Name = "btTextLogoEdit";
            this.btTextLogoEdit.Size = new System.Drawing.Size(88, 35);
            this.btTextLogoEdit.TabIndex = 6;
            this.btTextLogoEdit.Text = "Edit";
            this.btTextLogoEdit.UseVisualStyleBackColor = true;
            this.btTextLogoEdit.Click += new System.EventHandler(this.btTextLogoEdit_Click);
            // 
            // lbTextLogos
            // 
            this.lbTextLogos.FormattingEnabled = true;
            this.lbTextLogos.ItemHeight = 20;
            this.lbTextLogos.Location = new System.Drawing.Point(15, 18);
            this.lbTextLogos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbTextLogos.Name = "lbTextLogos";
            this.lbTextLogos.Size = new System.Drawing.Size(384, 304);
            this.lbTextLogos.TabIndex = 5;
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = new System.Drawing.Point(12, 331);
            this.btTextLogoAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btTextLogoAdd.Name = "btTextLogoAdd";
            this.btTextLogoAdd.Size = new System.Drawing.Size(88, 35);
            this.btTextLogoAdd.TabIndex = 4;
            this.btTextLogoAdd.Text = "Add";
            this.btTextLogoAdd.UseVisualStyleBackColor = true;
            this.btTextLogoAdd.Click += new System.EventHandler(this.btTextLogoAdd_Click);
            // 
            // tabPage42
            // 
            this.tabPage42.Controls.Add(this.btImageLogoRemove);
            this.tabPage42.Controls.Add(this.btImageLogoEdit);
            this.tabPage42.Controls.Add(this.lbImageLogos);
            this.tabPage42.Controls.Add(this.btImageLogoAdd);
            this.tabPage42.Location = new System.Drawing.Point(4, 29);
            this.tabPage42.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage42.Name = "tabPage42";
            this.tabPage42.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage42.Size = new System.Drawing.Size(416, 389);
            this.tabPage42.TabIndex = 1;
            this.tabPage42.Text = "Image logo";
            this.tabPage42.UseVisualStyleBackColor = true;
            // 
            // btImageLogoRemove
            // 
            this.btImageLogoRemove.Location = new System.Drawing.Point(309, 331);
            this.btImageLogoRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btImageLogoRemove.Name = "btImageLogoRemove";
            this.btImageLogoRemove.Size = new System.Drawing.Size(88, 35);
            this.btImageLogoRemove.TabIndex = 11;
            this.btImageLogoRemove.Text = "Remove";
            this.btImageLogoRemove.UseVisualStyleBackColor = true;
            this.btImageLogoRemove.Click += new System.EventHandler(this.btImageLogoRemove_Click);
            // 
            // btImageLogoEdit
            // 
            this.btImageLogoEdit.Location = new System.Drawing.Point(111, 331);
            this.btImageLogoEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btImageLogoEdit.Name = "btImageLogoEdit";
            this.btImageLogoEdit.Size = new System.Drawing.Size(88, 35);
            this.btImageLogoEdit.TabIndex = 10;
            this.btImageLogoEdit.Text = "Edit";
            this.btImageLogoEdit.UseVisualStyleBackColor = true;
            this.btImageLogoEdit.Click += new System.EventHandler(this.btImageLogoEdit_Click);
            // 
            // lbImageLogos
            // 
            this.lbImageLogos.FormattingEnabled = true;
            this.lbImageLogos.ItemHeight = 20;
            this.lbImageLogos.Location = new System.Drawing.Point(15, 18);
            this.lbImageLogos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbImageLogos.Name = "lbImageLogos";
            this.lbImageLogos.Size = new System.Drawing.Size(384, 304);
            this.lbImageLogos.TabIndex = 9;
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = new System.Drawing.Point(12, 331);
            this.btImageLogoAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btImageLogoAdd.Name = "btImageLogoAdd";
            this.btImageLogoAdd.Size = new System.Drawing.Size(88, 35);
            this.btImageLogoAdd.TabIndex = 8;
            this.btImageLogoAdd.Text = "Add";
            this.btImageLogoAdd.UseVisualStyleBackColor = true;
            this.btImageLogoAdd.Click += new System.EventHandler(this.btImageLogoAdd_Click);
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.groupBox37);
            this.tabPage18.Controls.Add(this.cbZoom);
            this.tabPage18.Location = new System.Drawing.Point(4, 29);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage18.Size = new System.Drawing.Size(416, 389);
            this.tabPage18.TabIndex = 2;
            this.tabPage18.Text = "Zoom";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.btEffZoomRight);
            this.groupBox37.Controls.Add(this.btEffZoomLeft);
            this.groupBox37.Controls.Add(this.btEffZoomOut);
            this.groupBox37.Controls.Add(this.btEffZoomIn);
            this.groupBox37.Controls.Add(this.btEffZoomDown);
            this.groupBox37.Controls.Add(this.btEffZoomUp);
            this.groupBox37.Location = new System.Drawing.Point(129, 78);
            this.groupBox37.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox37.Size = new System.Drawing.Size(178, 160);
            this.groupBox37.TabIndex = 18;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Zoom";
            // 
            // btEffZoomRight
            // 
            this.btEffZoomRight.Location = new System.Drawing.Point(128, 51);
            this.btEffZoomRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomRight.Name = "btEffZoomRight";
            this.btEffZoomRight.Size = new System.Drawing.Size(32, 74);
            this.btEffZoomRight.TabIndex = 5;
            this.btEffZoomRight.Text = "R";
            this.btEffZoomRight.UseVisualStyleBackColor = true;
            this.btEffZoomRight.Click += new System.EventHandler(this.btEffZoomRight_Click);
            // 
            // btEffZoomLeft
            // 
            this.btEffZoomLeft.Location = new System.Drawing.Point(20, 49);
            this.btEffZoomLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomLeft.Name = "btEffZoomLeft";
            this.btEffZoomLeft.Size = new System.Drawing.Size(32, 74);
            this.btEffZoomLeft.TabIndex = 4;
            this.btEffZoomLeft.Text = "L";
            this.btEffZoomLeft.UseVisualStyleBackColor = true;
            this.btEffZoomLeft.Click += new System.EventHandler(this.btEffZoomLeft_Click);
            // 
            // btEffZoomOut
            // 
            this.btEffZoomOut.Location = new System.Drawing.Point(92, 69);
            this.btEffZoomOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomOut.Name = "btEffZoomOut";
            this.btEffZoomOut.Size = new System.Drawing.Size(34, 35);
            this.btEffZoomOut.TabIndex = 3;
            this.btEffZoomOut.Text = "-";
            this.btEffZoomOut.UseVisualStyleBackColor = true;
            this.btEffZoomOut.Click += new System.EventHandler(this.btEffZoomOut_Click);
            // 
            // btEffZoomIn
            // 
            this.btEffZoomIn.Location = new System.Drawing.Point(52, 69);
            this.btEffZoomIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomIn.Name = "btEffZoomIn";
            this.btEffZoomIn.Size = new System.Drawing.Size(33, 35);
            this.btEffZoomIn.TabIndex = 2;
            this.btEffZoomIn.Text = "+";
            this.btEffZoomIn.UseVisualStyleBackColor = true;
            this.btEffZoomIn.Click += new System.EventHandler(this.btEffZoomIn_Click);
            // 
            // btEffZoomDown
            // 
            this.btEffZoomDown.Location = new System.Drawing.Point(51, 106);
            this.btEffZoomDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomDown.Name = "btEffZoomDown";
            this.btEffZoomDown.Size = new System.Drawing.Size(76, 35);
            this.btEffZoomDown.TabIndex = 1;
            this.btEffZoomDown.Text = "Down";
            this.btEffZoomDown.UseVisualStyleBackColor = true;
            this.btEffZoomDown.Click += new System.EventHandler(this.btEffZoomDown_Click);
            // 
            // btEffZoomUp
            // 
            this.btEffZoomUp.Location = new System.Drawing.Point(51, 31);
            this.btEffZoomUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEffZoomUp.Name = "btEffZoomUp";
            this.btEffZoomUp.Size = new System.Drawing.Size(76, 35);
            this.btEffZoomUp.TabIndex = 0;
            this.btEffZoomUp.Text = "Up";
            this.btEffZoomUp.UseVisualStyleBackColor = true;
            this.btEffZoomUp.Click += new System.EventHandler(this.btEffZoomUp_Click);
            // 
            // cbZoom
            // 
            this.cbZoom.AutoSize = true;
            this.cbZoom.Location = new System.Drawing.Point(18, 23);
            this.cbZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(94, 24);
            this.cbZoom.TabIndex = 17;
            this.cbZoom.Text = "Enabled";
            this.cbZoom.UseVisualStyleBackColor = true;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.cbZoom_CheckedChanged);
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.groupBox40);
            this.tabPage19.Controls.Add(this.groupBox39);
            this.tabPage19.Controls.Add(this.groupBox38);
            this.tabPage19.Controls.Add(this.cbPan);
            this.tabPage19.Location = new System.Drawing.Point(4, 29);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage19.Size = new System.Drawing.Size(416, 389);
            this.tabPage19.TabIndex = 3;
            this.tabPage19.Text = "Pan";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.edPanDestHeight);
            this.groupBox40.Controls.Add(this.label302);
            this.groupBox40.Controls.Add(this.edPanDestWidth);
            this.groupBox40.Controls.Add(this.label303);
            this.groupBox40.Controls.Add(this.edPanDestTop);
            this.groupBox40.Controls.Add(this.label304);
            this.groupBox40.Controls.Add(this.edPanDestLeft);
            this.groupBox40.Controls.Add(this.label305);
            this.groupBox40.Location = new System.Drawing.Point(18, 249);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(252, 118);
            this.groupBox40.TabIndex = 58;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "Destination rect";
            // 
            // edPanDestHeight
            // 
            this.edPanDestHeight.Location = new System.Drawing.Point(184, 78);
            this.edPanDestHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanDestHeight.Name = "edPanDestHeight";
            this.edPanDestHeight.Size = new System.Drawing.Size(48, 26);
            this.edPanDestHeight.TabIndex = 17;
            this.edPanDestHeight.Text = "240";
            // 
            // label302
            // 
            this.label302.AutoSize = true;
            this.label302.Location = new System.Drawing.Point(122, 83);
            this.label302.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label302.Name = "label302";
            this.label302.Size = new System.Drawing.Size(56, 20);
            this.label302.TabIndex = 16;
            this.label302.Text = "Height";
            // 
            // edPanDestWidth
            // 
            this.edPanDestWidth.Location = new System.Drawing.Point(184, 38);
            this.edPanDestWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanDestWidth.Name = "edPanDestWidth";
            this.edPanDestWidth.Size = new System.Drawing.Size(48, 26);
            this.edPanDestWidth.TabIndex = 15;
            this.edPanDestWidth.Text = "320";
            // 
            // label303
            // 
            this.label303.AutoSize = true;
            this.label303.Location = new System.Drawing.Point(122, 43);
            this.label303.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label303.Name = "label303";
            this.label303.Size = new System.Drawing.Size(50, 20);
            this.label303.TabIndex = 14;
            this.label303.Text = "Width";
            // 
            // edPanDestTop
            // 
            this.edPanDestTop.Location = new System.Drawing.Point(64, 80);
            this.edPanDestTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanDestTop.Name = "edPanDestTop";
            this.edPanDestTop.Size = new System.Drawing.Size(48, 26);
            this.edPanDestTop.TabIndex = 12;
            this.edPanDestTop.Text = "0";
            // 
            // label304
            // 
            this.label304.AutoSize = true;
            this.label304.Location = new System.Drawing.Point(20, 83);
            this.label304.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label304.Name = "label304";
            this.label304.Size = new System.Drawing.Size(36, 20);
            this.label304.TabIndex = 11;
            this.label304.Text = "Top";
            // 
            // edPanDestLeft
            // 
            this.edPanDestLeft.Location = new System.Drawing.Point(64, 40);
            this.edPanDestLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanDestLeft.Name = "edPanDestLeft";
            this.edPanDestLeft.Size = new System.Drawing.Size(48, 26);
            this.edPanDestLeft.TabIndex = 10;
            this.edPanDestLeft.Text = "0";
            // 
            // label305
            // 
            this.label305.AutoSize = true;
            this.label305.Location = new System.Drawing.Point(20, 43);
            this.label305.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label305.Name = "label305";
            this.label305.Size = new System.Drawing.Size(37, 20);
            this.label305.TabIndex = 9;
            this.label305.Text = "Left";
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.edPanSourceHeight);
            this.groupBox39.Controls.Add(this.label298);
            this.groupBox39.Controls.Add(this.edPanSourceWidth);
            this.groupBox39.Controls.Add(this.label299);
            this.groupBox39.Controls.Add(this.edPanSourceTop);
            this.groupBox39.Controls.Add(this.label300);
            this.groupBox39.Controls.Add(this.edPanSourceLeft);
            this.groupBox39.Controls.Add(this.label301);
            this.groupBox39.Location = new System.Drawing.Point(18, 123);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(252, 118);
            this.groupBox39.TabIndex = 57;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Source rect";
            // 
            // edPanSourceHeight
            // 
            this.edPanSourceHeight.Location = new System.Drawing.Point(184, 78);
            this.edPanSourceHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanSourceHeight.Name = "edPanSourceHeight";
            this.edPanSourceHeight.Size = new System.Drawing.Size(48, 26);
            this.edPanSourceHeight.TabIndex = 17;
            this.edPanSourceHeight.Text = "480";
            // 
            // label298
            // 
            this.label298.AutoSize = true;
            this.label298.Location = new System.Drawing.Point(122, 83);
            this.label298.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label298.Name = "label298";
            this.label298.Size = new System.Drawing.Size(56, 20);
            this.label298.TabIndex = 16;
            this.label298.Text = "Height";
            // 
            // edPanSourceWidth
            // 
            this.edPanSourceWidth.Location = new System.Drawing.Point(184, 38);
            this.edPanSourceWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanSourceWidth.Name = "edPanSourceWidth";
            this.edPanSourceWidth.Size = new System.Drawing.Size(48, 26);
            this.edPanSourceWidth.TabIndex = 15;
            this.edPanSourceWidth.Text = "640";
            // 
            // label299
            // 
            this.label299.AutoSize = true;
            this.label299.Location = new System.Drawing.Point(122, 43);
            this.label299.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label299.Name = "label299";
            this.label299.Size = new System.Drawing.Size(50, 20);
            this.label299.TabIndex = 14;
            this.label299.Text = "Width";
            // 
            // edPanSourceTop
            // 
            this.edPanSourceTop.Location = new System.Drawing.Point(64, 80);
            this.edPanSourceTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanSourceTop.Name = "edPanSourceTop";
            this.edPanSourceTop.Size = new System.Drawing.Size(48, 26);
            this.edPanSourceTop.TabIndex = 12;
            this.edPanSourceTop.Text = "0";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.Location = new System.Drawing.Point(20, 83);
            this.label300.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(36, 20);
            this.label300.TabIndex = 11;
            this.label300.Text = "Top";
            // 
            // edPanSourceLeft
            // 
            this.edPanSourceLeft.Location = new System.Drawing.Point(64, 40);
            this.edPanSourceLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanSourceLeft.Name = "edPanSourceLeft";
            this.edPanSourceLeft.Size = new System.Drawing.Size(48, 26);
            this.edPanSourceLeft.TabIndex = 10;
            this.edPanSourceLeft.Text = "0";
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Location = new System.Drawing.Point(20, 43);
            this.label301.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(37, 20);
            this.label301.TabIndex = 9;
            this.label301.Text = "Left";
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.edPanStopTime);
            this.groupBox38.Controls.Add(this.label296);
            this.groupBox38.Controls.Add(this.edPanStartTime);
            this.groupBox38.Controls.Add(this.label297);
            this.groupBox38.Location = new System.Drawing.Point(18, 45);
            this.groupBox38.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox38.Size = new System.Drawing.Size(252, 71);
            this.groupBox38.TabIndex = 56;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Duration";
            // 
            // edPanStopTime
            // 
            this.edPanStopTime.Location = new System.Drawing.Point(176, 29);
            this.edPanStopTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanStopTime.Name = "edPanStopTime";
            this.edPanStopTime.Size = new System.Drawing.Size(56, 26);
            this.edPanStopTime.TabIndex = 34;
            this.edPanStopTime.Text = "15000";
            this.edPanStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label296
            // 
            this.label296.AutoSize = true;
            this.label296.Location = new System.Drawing.Point(132, 34);
            this.label296.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label296.Name = "label296";
            this.label296.Size = new System.Drawing.Size(43, 20);
            this.label296.TabIndex = 33;
            this.label296.Text = "Stop";
            // 
            // edPanStartTime
            // 
            this.edPanStartTime.Location = new System.Drawing.Point(64, 29);
            this.edPanStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPanStartTime.Name = "edPanStartTime";
            this.edPanStartTime.Size = new System.Drawing.Size(56, 26);
            this.edPanStartTime.TabIndex = 32;
            this.edPanStartTime.Text = "5000";
            this.edPanStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label297
            // 
            this.label297.AutoSize = true;
            this.label297.Location = new System.Drawing.Point(15, 34);
            this.label297.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label297.Name = "label297";
            this.label297.Size = new System.Drawing.Size(44, 20);
            this.label297.TabIndex = 31;
            this.label297.Text = "Start";
            // 
            // cbPan
            // 
            this.cbPan.AutoSize = true;
            this.cbPan.Location = new System.Drawing.Point(18, 9);
            this.cbPan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPan.Name = "cbPan";
            this.cbPan.Size = new System.Drawing.Size(94, 24);
            this.cbPan.TabIndex = 55;
            this.cbPan.Text = "Enabled";
            this.cbPan.UseVisualStyleBackColor = true;
            this.cbPan.CheckedChanged += new System.EventHandler(this.cbPan_CheckedChanged);
            // 
            // tabPage22
            // 
            this.tabPage22.Controls.Add(this.rbFadeOut);
            this.tabPage22.Controls.Add(this.rbFadeIn);
            this.tabPage22.Controls.Add(this.groupBox45);
            this.tabPage22.Controls.Add(this.cbFadeInOut);
            this.tabPage22.Location = new System.Drawing.Point(4, 29);
            this.tabPage22.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage22.Size = new System.Drawing.Size(416, 389);
            this.tabPage22.TabIndex = 4;
            this.tabPage22.Text = "Fade-in/out";
            this.tabPage22.UseVisualStyleBackColor = true;
            // 
            // rbFadeOut
            // 
            this.rbFadeOut.AutoSize = true;
            this.rbFadeOut.Location = new System.Drawing.Point(152, 158);
            this.rbFadeOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFadeOut.Name = "rbFadeOut";
            this.rbFadeOut.Size = new System.Drawing.Size(99, 24);
            this.rbFadeOut.TabIndex = 60;
            this.rbFadeOut.TabStop = true;
            this.rbFadeOut.Text = "Fade-out";
            this.rbFadeOut.UseVisualStyleBackColor = true;
            // 
            // rbFadeIn
            // 
            this.rbFadeIn.AutoSize = true;
            this.rbFadeIn.Checked = true;
            this.rbFadeIn.Location = new System.Drawing.Point(15, 158);
            this.rbFadeIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFadeIn.Name = "rbFadeIn";
            this.rbFadeIn.Size = new System.Drawing.Size(88, 24);
            this.rbFadeIn.TabIndex = 59;
            this.rbFadeIn.TabStop = true;
            this.rbFadeIn.Text = "Fade-in";
            this.rbFadeIn.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.edFadeInOutStopTime);
            this.groupBox45.Controls.Add(this.label329);
            this.groupBox45.Controls.Add(this.edFadeInOutStartTime);
            this.groupBox45.Controls.Add(this.label330);
            this.groupBox45.Location = new System.Drawing.Point(15, 78);
            this.groupBox45.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox45.Size = new System.Drawing.Size(252, 71);
            this.groupBox45.TabIndex = 58;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Duration";
            // 
            // edFadeInOutStopTime
            // 
            this.edFadeInOutStopTime.Location = new System.Drawing.Point(176, 29);
            this.edFadeInOutStopTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFadeInOutStopTime.Name = "edFadeInOutStopTime";
            this.edFadeInOutStopTime.Size = new System.Drawing.Size(56, 26);
            this.edFadeInOutStopTime.TabIndex = 34;
            this.edFadeInOutStopTime.Text = "15000";
            this.edFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label329
            // 
            this.label329.AutoSize = true;
            this.label329.Location = new System.Drawing.Point(132, 34);
            this.label329.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label329.Name = "label329";
            this.label329.Size = new System.Drawing.Size(43, 20);
            this.label329.TabIndex = 33;
            this.label329.Text = "Stop";
            // 
            // edFadeInOutStartTime
            // 
            this.edFadeInOutStartTime.Location = new System.Drawing.Point(64, 29);
            this.edFadeInOutStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFadeInOutStartTime.Name = "edFadeInOutStartTime";
            this.edFadeInOutStartTime.Size = new System.Drawing.Size(56, 26);
            this.edFadeInOutStartTime.TabIndex = 32;
            this.edFadeInOutStartTime.Text = "5000";
            this.edFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label330
            // 
            this.label330.AutoSize = true;
            this.label330.Location = new System.Drawing.Point(15, 34);
            this.label330.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label330.Name = "label330";
            this.label330.Size = new System.Drawing.Size(44, 20);
            this.label330.TabIndex = 31;
            this.label330.Text = "Start";
            // 
            // cbFadeInOut
            // 
            this.cbFadeInOut.AutoSize = true;
            this.cbFadeInOut.Location = new System.Drawing.Point(15, 26);
            this.cbFadeInOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFadeInOut.Name = "cbFadeInOut";
            this.cbFadeInOut.Size = new System.Drawing.Size(94, 24);
            this.cbFadeInOut.TabIndex = 57;
            this.cbFadeInOut.Text = "Enabled";
            this.cbFadeInOut.UseVisualStyleBackColor = true;
            this.cbFadeInOut.CheckedChanged += new System.EventHandler(this.cbFadeInOut_CheckedChanged);
            // 
            // tabPage43
            // 
            this.tabPage43.Controls.Add(this.cbLiveRotationStretch);
            this.tabPage43.Controls.Add(this.label392);
            this.tabPage43.Controls.Add(this.label391);
            this.tabPage43.Controls.Add(this.tbLiveRotationAngle);
            this.tabPage43.Controls.Add(this.label390);
            this.tabPage43.Controls.Add(this.cbLiveRotation);
            this.tabPage43.Location = new System.Drawing.Point(4, 29);
            this.tabPage43.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage43.Name = "tabPage43";
            this.tabPage43.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage43.Size = new System.Drawing.Size(416, 389);
            this.tabPage43.TabIndex = 5;
            this.tabPage43.Text = "Live rotation";
            this.tabPage43.UseVisualStyleBackColor = true;
            // 
            // cbLiveRotationStretch
            // 
            this.cbLiveRotationStretch.AutoSize = true;
            this.cbLiveRotationStretch.Location = new System.Drawing.Point(18, 211);
            this.cbLiveRotationStretch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLiveRotationStretch.Name = "cbLiveRotationStretch";
            this.cbLiveRotationStretch.Size = new System.Drawing.Size(232, 24);
            this.cbLiveRotationStretch.TabIndex = 65;
            this.cbLiveRotationStretch.Text = "Stretch  if angle is 90 or 270";
            this.cbLiveRotationStretch.UseVisualStyleBackColor = true;
            this.cbLiveRotationStretch.CheckedChanged += new System.EventHandler(this.cbLiveRotationStretch_CheckedChanged);
            // 
            // label392
            // 
            this.label392.AutoSize = true;
            this.label392.Location = new System.Drawing.Point(195, 171);
            this.label392.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label392.Name = "label392";
            this.label392.Size = new System.Drawing.Size(36, 20);
            this.label392.TabIndex = 64;
            this.label392.Text = "360";
            // 
            // label391
            // 
            this.label391.AutoSize = true;
            this.label391.Location = new System.Drawing.Point(14, 171);
            this.label391.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label391.Name = "label391";
            this.label391.Size = new System.Drawing.Size(18, 20);
            this.label391.TabIndex = 63;
            this.label391.Text = "0";
            // 
            // tbLiveRotationAngle
            // 
            this.tbLiveRotationAngle.Location = new System.Drawing.Point(18, 97);
            this.tbLiveRotationAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLiveRotationAngle.Maximum = 360;
            this.tbLiveRotationAngle.Name = "tbLiveRotationAngle";
            this.tbLiveRotationAngle.Size = new System.Drawing.Size(214, 69);
            this.tbLiveRotationAngle.TabIndex = 62;
            this.tbLiveRotationAngle.TickFrequency = 5;
            this.tbLiveRotationAngle.Value = 90;
            this.tbLiveRotationAngle.Scroll += new System.EventHandler(this.tbLiveRotationAngle_Scroll);
            // 
            // label390
            // 
            this.label390.AutoSize = true;
            this.label390.Location = new System.Drawing.Point(14, 68);
            this.label390.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label390.Name = "label390";
            this.label390.Size = new System.Drawing.Size(50, 20);
            this.label390.TabIndex = 61;
            this.label390.Text = "Angle";
            // 
            // cbLiveRotation
            // 
            this.cbLiveRotation.AutoSize = true;
            this.cbLiveRotation.Location = new System.Drawing.Point(18, 18);
            this.cbLiveRotation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLiveRotation.Name = "cbLiveRotation";
            this.cbLiveRotation.Size = new System.Drawing.Size(94, 24);
            this.cbLiveRotation.TabIndex = 60;
            this.cbLiveRotation.Text = "Enabled";
            this.cbLiveRotation.UseVisualStyleBackColor = true;
            this.cbLiveRotation.CheckedChanged += new System.EventHandler(this.cbLiveRotation_CheckedChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(4, 165);
            this.tbContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContrast.Maximum = 255;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(195, 69);
            this.tbContrast.TabIndex = 49;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbDarkness.Location = new System.Drawing.Point(213, 165);
            this.tbDarkness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDarkness.Maximum = 255;
            this.tbDarkness.Name = "tbDarkness";
            this.tbDarkness.Size = new System.Drawing.Size(195, 69);
            this.tbDarkness.TabIndex = 46;
            this.tbDarkness.Scroll += new System.EventHandler(this.tbDarkness_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbLightness.Location = new System.Drawing.Point(4, 78);
            this.tbLightness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLightness.Maximum = 255;
            this.tbLightness.Name = "tbLightness";
            this.tbLightness.Size = new System.Drawing.Size(195, 69);
            this.tbLightness.TabIndex = 45;
            this.tbLightness.Scroll += new System.EventHandler(this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(213, 78);
            this.tbSaturation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(195, 69);
            this.tbSaturation.TabIndex = 43;
            this.tbSaturation.Value = 255;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = true;
            this.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbInvert.Location = new System.Drawing.Point(135, 243);
            this.cbInvert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.Size = new System.Drawing.Size(75, 24);
            this.cbInvert.TabIndex = 41;
            this.cbInvert.Text = "Invert";
            this.cbInvert.UseVisualStyleBackColor = true;
            this.cbInvert.CheckedChanged += new System.EventHandler(this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(14, 243);
            this.cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(106, 24);
            this.cbGreyscale.TabIndex = 39;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            this.cbGreyscale.CheckedChanged += new System.EventHandler(this.cbGreyscale_CheckedChanged);
            // 
            // cbVideoEffects
            // 
            this.cbVideoEffects.AutoSize = true;
            this.cbVideoEffects.Location = new System.Drawing.Point(12, 12);
            this.cbVideoEffects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVideoEffects.Name = "cbVideoEffects";
            this.cbVideoEffects.Size = new System.Drawing.Size(94, 24);
            this.cbVideoEffects.TabIndex = 37;
            this.cbVideoEffects.Text = "Enabled";
            this.cbVideoEffects.UseVisualStyleBackColor = true;
            // 
            // tabPage69
            // 
            this.tabPage69.Controls.Add(this.label211);
            this.tabPage69.Controls.Add(this.edDeintTriangleWeight);
            this.tabPage69.Controls.Add(this.label212);
            this.tabPage69.Controls.Add(this.label210);
            this.tabPage69.Controls.Add(this.label209);
            this.tabPage69.Controls.Add(this.label206);
            this.tabPage69.Controls.Add(this.edDeintBlendConstants2);
            this.tabPage69.Controls.Add(this.label207);
            this.tabPage69.Controls.Add(this.edDeintBlendConstants1);
            this.tabPage69.Controls.Add(this.label208);
            this.tabPage69.Controls.Add(this.label204);
            this.tabPage69.Controls.Add(this.edDeintBlendThreshold2);
            this.tabPage69.Controls.Add(this.label205);
            this.tabPage69.Controls.Add(this.edDeintBlendThreshold1);
            this.tabPage69.Controls.Add(this.label203);
            this.tabPage69.Controls.Add(this.label202);
            this.tabPage69.Controls.Add(this.edDeintCAVTThreshold);
            this.tabPage69.Controls.Add(this.label104);
            this.tabPage69.Controls.Add(this.rbDeintTriangleEnabled);
            this.tabPage69.Controls.Add(this.rbDeintBlendEnabled);
            this.tabPage69.Controls.Add(this.rbDeintCAVTEnabled);
            this.tabPage69.Controls.Add(this.cbDeinterlace);
            this.tabPage69.Location = new System.Drawing.Point(4, 29);
            this.tabPage69.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage69.Name = "tabPage69";
            this.tabPage69.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage69.Size = new System.Drawing.Size(439, 713);
            this.tabPage69.TabIndex = 1;
            this.tabPage69.Text = "Deinterlace";
            this.tabPage69.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(150, 452);
            this.label211.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(58, 20);
            this.label211.TabIndex = 28;
            this.label211.Text = "[0-255]";
            // 
            // edDeintTriangleWeight
            // 
            this.edDeintTriangleWeight.Location = new System.Drawing.Point(154, 415);
            this.edDeintTriangleWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintTriangleWeight.Name = "edDeintTriangleWeight";
            this.edDeintTriangleWeight.Size = new System.Drawing.Size(46, 26);
            this.edDeintTriangleWeight.TabIndex = 27;
            this.edDeintTriangleWeight.Text = "180";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(51, 420);
            this.label212.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(59, 20);
            this.label212.TabIndex = 26;
            this.label212.Text = "Weight";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(386, 295);
            this.label210.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(35, 20);
            this.label210.TabIndex = 25;
            this.label210.Text = "/ 10";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(386, 245);
            this.label209.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(35, 20);
            this.label209.TabIndex = 24;
            this.label209.Text = "/ 10";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(327, 328);
            this.label206.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(66, 20);
            this.label206.TabIndex = 23;
            this.label206.Text = "[0.0-1.0]";
            // 
            // edDeintBlendConstants2
            // 
            this.edDeintBlendConstants2.Location = new System.Drawing.Point(332, 291);
            this.edDeintBlendConstants2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintBlendConstants2.Name = "edDeintBlendConstants2";
            this.edDeintBlendConstants2.Size = new System.Drawing.Size(46, 26);
            this.edDeintBlendConstants2.TabIndex = 22;
            this.edDeintBlendConstants2.Text = "9";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(228, 295);
            this.label207.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(95, 20);
            this.label207.TabIndex = 21;
            this.label207.Text = "Constants 2";
            // 
            // edDeintBlendConstants1
            // 
            this.edDeintBlendConstants1.Location = new System.Drawing.Point(332, 240);
            this.edDeintBlendConstants1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintBlendConstants1.Name = "edDeintBlendConstants1";
            this.edDeintBlendConstants1.Size = new System.Drawing.Size(46, 26);
            this.edDeintBlendConstants1.TabIndex = 20;
            this.edDeintBlendConstants1.Text = "3";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(228, 245);
            this.label208.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(95, 20);
            this.label208.TabIndex = 19;
            this.label208.Text = "Constants 1";
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(150, 328);
            this.label204.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(58, 20);
            this.label204.TabIndex = 18;
            this.label204.Text = "[0-255]";
            // 
            // edDeintBlendThreshold2
            // 
            this.edDeintBlendThreshold2.Location = new System.Drawing.Point(154, 291);
            this.edDeintBlendThreshold2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintBlendThreshold2.Name = "edDeintBlendThreshold2";
            this.edDeintBlendThreshold2.Size = new System.Drawing.Size(46, 26);
            this.edDeintBlendThreshold2.TabIndex = 17;
            this.edDeintBlendThreshold2.Text = "9";
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(51, 295);
            this.label205.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(92, 20);
            this.label205.TabIndex = 16;
            this.label205.Text = "Threshold 2";
            // 
            // edDeintBlendThreshold1
            // 
            this.edDeintBlendThreshold1.Location = new System.Drawing.Point(154, 240);
            this.edDeintBlendThreshold1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintBlendThreshold1.Name = "edDeintBlendThreshold1";
            this.edDeintBlendThreshold1.Size = new System.Drawing.Size(46, 26);
            this.edDeintBlendThreshold1.TabIndex = 15;
            this.edDeintBlendThreshold1.Text = "5";
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(51, 245);
            this.label203.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(92, 20);
            this.label203.TabIndex = 14;
            this.label203.Text = "Threshold 1";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(150, 158);
            this.label202.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(58, 20);
            this.label202.TabIndex = 13;
            this.label202.Text = "[0-255]";
            // 
            // edDeintCAVTThreshold
            // 
            this.edDeintCAVTThreshold.Location = new System.Drawing.Point(154, 122);
            this.edDeintCAVTThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDeintCAVTThreshold.Name = "edDeintCAVTThreshold";
            this.edDeintCAVTThreshold.Size = new System.Drawing.Size(46, 26);
            this.edDeintCAVTThreshold.TabIndex = 12;
            this.edDeintCAVTThreshold.Text = "20";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(51, 126);
            this.label104.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(79, 20);
            this.label104.TabIndex = 11;
            this.label104.Text = "Threshold";
            // 
            // rbDeintTriangleEnabled
            // 
            this.rbDeintTriangleEnabled.AutoSize = true;
            this.rbDeintTriangleEnabled.Location = new System.Drawing.Point(27, 374);
            this.rbDeintTriangleEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled";
            this.rbDeintTriangleEnabled.Size = new System.Drawing.Size(90, 24);
            this.rbDeintTriangleEnabled.TabIndex = 10;
            this.rbDeintTriangleEnabled.Text = "Triangle";
            this.rbDeintTriangleEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintBlendEnabled
            // 
            this.rbDeintBlendEnabled.AutoSize = true;
            this.rbDeintBlendEnabled.Location = new System.Drawing.Point(27, 195);
            this.rbDeintBlendEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDeintBlendEnabled.Name = "rbDeintBlendEnabled";
            this.rbDeintBlendEnabled.Size = new System.Drawing.Size(75, 24);
            this.rbDeintBlendEnabled.TabIndex = 9;
            this.rbDeintBlendEnabled.Text = "Blend";
            this.rbDeintBlendEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintCAVTEnabled
            // 
            this.rbDeintCAVTEnabled.AutoSize = true;
            this.rbDeintCAVTEnabled.Checked = true;
            this.rbDeintCAVTEnabled.Location = new System.Drawing.Point(27, 80);
            this.rbDeintCAVTEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDeintCAVTEnabled.Name = "rbDeintCAVTEnabled";
            this.rbDeintCAVTEnabled.Size = new System.Drawing.Size(340, 24);
            this.rbDeintCAVTEnabled.TabIndex = 8;
            this.rbDeintCAVTEnabled.TabStop = true;
            this.rbDeintCAVTEnabled.Text = "Content Adaptive Vertical Temporal (CAVT)";
            this.rbDeintCAVTEnabled.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlace
            // 
            this.cbDeinterlace.AutoSize = true;
            this.cbDeinterlace.Location = new System.Drawing.Point(27, 25);
            this.cbDeinterlace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDeinterlace.Name = "cbDeinterlace";
            this.cbDeinterlace.Size = new System.Drawing.Size(94, 24);
            this.cbDeinterlace.TabIndex = 7;
            this.cbDeinterlace.Text = "Enabled";
            this.cbDeinterlace.UseVisualStyleBackColor = true;
            // 
            // tabPage59
            // 
            this.tabPage59.Controls.Add(this.rbDenoiseCAST);
            this.tabPage59.Controls.Add(this.rbDenoiseMosquito);
            this.tabPage59.Controls.Add(this.cbDenoise);
            this.tabPage59.Location = new System.Drawing.Point(4, 29);
            this.tabPage59.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage59.Name = "tabPage59";
            this.tabPage59.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage59.Size = new System.Drawing.Size(439, 713);
            this.tabPage59.TabIndex = 4;
            this.tabPage59.Text = "Denoise";
            this.tabPage59.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseCAST
            // 
            this.rbDenoiseCAST.AutoSize = true;
            this.rbDenoiseCAST.Location = new System.Drawing.Point(27, 122);
            this.rbDenoiseCAST.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDenoiseCAST.Name = "rbDenoiseCAST";
            this.rbDenoiseCAST.Size = new System.Drawing.Size(334, 24);
            this.rbDenoiseCAST.TabIndex = 10;
            this.rbDenoiseCAST.Text = "Content Adaptive Spatio-Temporal (CAST)";
            this.rbDenoiseCAST.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseMosquito
            // 
            this.rbDenoiseMosquito.AutoSize = true;
            this.rbDenoiseMosquito.Checked = true;
            this.rbDenoiseMosquito.Location = new System.Drawing.Point(27, 80);
            this.rbDenoiseMosquito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDenoiseMosquito.Name = "rbDenoiseMosquito";
            this.rbDenoiseMosquito.Size = new System.Drawing.Size(99, 24);
            this.rbDenoiseMosquito.TabIndex = 9;
            this.rbDenoiseMosquito.TabStop = true;
            this.rbDenoiseMosquito.Text = "Mosquito";
            this.rbDenoiseMosquito.UseVisualStyleBackColor = true;
            // 
            // cbDenoise
            // 
            this.cbDenoise.AutoSize = true;
            this.cbDenoise.Location = new System.Drawing.Point(27, 25);
            this.cbDenoise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDenoise.Name = "cbDenoise";
            this.cbDenoise.Size = new System.Drawing.Size(94, 24);
            this.cbDenoise.TabIndex = 8;
            this.cbDenoise.Text = "Enabled";
            this.cbDenoise.UseVisualStyleBackColor = true;
            // 
            // tabPage51
            // 
            this.tabPage51.Controls.Add(this.label22);
            this.tabPage51.Controls.Add(this.tbGPUBlur);
            this.tabPage51.Controls.Add(this.cbVideoEffectsGPUEnabled);
            this.tabPage51.Controls.Add(this.cbGPUOldMovie);
            this.tabPage51.Controls.Add(this.cbGPUDeinterlace);
            this.tabPage51.Controls.Add(this.cbGPUDenoise);
            this.tabPage51.Controls.Add(this.cbGPUPixelate);
            this.tabPage51.Controls.Add(this.cbGPUNightVision);
            this.tabPage51.Controls.Add(this.label383);
            this.tabPage51.Controls.Add(this.label384);
            this.tabPage51.Controls.Add(this.label385);
            this.tabPage51.Controls.Add(this.label386);
            this.tabPage51.Controls.Add(this.tbGPUContrast);
            this.tabPage51.Controls.Add(this.tbGPUDarkness);
            this.tabPage51.Controls.Add(this.tbGPULightness);
            this.tabPage51.Controls.Add(this.tbGPUSaturation);
            this.tabPage51.Controls.Add(this.cbGPUInvert);
            this.tabPage51.Controls.Add(this.cbGPUGreyscale);
            this.tabPage51.Location = new System.Drawing.Point(4, 29);
            this.tabPage51.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage51.Name = "tabPage51";
            this.tabPage51.Size = new System.Drawing.Size(439, 713);
            this.tabPage51.TabIndex = 9;
            this.tabPage51.Text = "Effects (GPU)";
            this.tabPage51.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 414);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 20);
            this.label22.TabIndex = 100;
            this.label22.Text = "Blur";
            // 
            // tbGPUBlur
            // 
            this.tbGPUBlur.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUBlur.Location = new System.Drawing.Point(10, 438);
            this.tbGPUBlur.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGPUBlur.Maximum = 30;
            this.tbGPUBlur.Name = "tbGPUBlur";
            this.tbGPUBlur.Size = new System.Drawing.Size(195, 69);
            this.tbGPUBlur.TabIndex = 99;
            this.tbGPUBlur.Scroll += new System.EventHandler(this.tbGPUBlur_Scroll);
            // 
            // cbVideoEffectsGPUEnabled
            // 
            this.cbVideoEffectsGPUEnabled.AutoSize = true;
            this.cbVideoEffectsGPUEnabled.Location = new System.Drawing.Point(27, 25);
            this.cbVideoEffectsGPUEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled";
            this.cbVideoEffectsGPUEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbVideoEffectsGPUEnabled.TabIndex = 97;
            this.cbVideoEffectsGPUEnabled.Text = "Enabled";
            this.cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = true;
            // 
            // cbGPUOldMovie
            // 
            this.cbGPUOldMovie.AutoSize = true;
            this.cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUOldMovie.Location = new System.Drawing.Point(212, 369);
            this.cbGPUOldMovie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUOldMovie.Name = "cbGPUOldMovie";
            this.cbGPUOldMovie.Size = new System.Drawing.Size(104, 24);
            this.cbGPUOldMovie.TabIndex = 96;
            this.cbGPUOldMovie.Text = "Old movie";
            this.cbGPUOldMovie.UseVisualStyleBackColor = true;
            this.cbGPUOldMovie.CheckedChanged += new System.EventHandler(this.cbGPUOldMovie_CheckedChanged);
            // 
            // cbGPUDeinterlace
            // 
            this.cbGPUDeinterlace.AutoSize = true;
            this.cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUDeinterlace.Location = new System.Drawing.Point(212, 332);
            this.cbGPUDeinterlace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUDeinterlace.Name = "cbGPUDeinterlace";
            this.cbGPUDeinterlace.Size = new System.Drawing.Size(116, 24);
            this.cbGPUDeinterlace.TabIndex = 94;
            this.cbGPUDeinterlace.Text = "Deinterlace";
            this.cbGPUDeinterlace.UseVisualStyleBackColor = true;
            this.cbGPUDeinterlace.CheckedChanged += new System.EventHandler(this.cbGPUDeinterlace_CheckedChanged);
            // 
            // cbGPUDenoise
            // 
            this.cbGPUDenoise.AutoSize = true;
            this.cbGPUDenoise.Location = new System.Drawing.Point(20, 332);
            this.cbGPUDenoise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUDenoise.Name = "cbGPUDenoise";
            this.cbGPUDenoise.Size = new System.Drawing.Size(94, 24);
            this.cbGPUDenoise.TabIndex = 93;
            this.cbGPUDenoise.Text = "Denoise";
            this.cbGPUDenoise.UseVisualStyleBackColor = true;
            this.cbGPUDenoise.CheckedChanged += new System.EventHandler(this.cbGPUDenoise_CheckedChanged);
            // 
            // cbGPUPixelate
            // 
            this.cbGPUPixelate.AutoSize = true;
            this.cbGPUPixelate.Location = new System.Drawing.Point(212, 297);
            this.cbGPUPixelate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUPixelate.Name = "cbGPUPixelate";
            this.cbGPUPixelate.Size = new System.Drawing.Size(90, 24);
            this.cbGPUPixelate.TabIndex = 92;
            this.cbGPUPixelate.Text = "Pixelate";
            this.cbGPUPixelate.UseVisualStyleBackColor = true;
            this.cbGPUPixelate.CheckedChanged += new System.EventHandler(this.cbGPUPixelate_CheckedChanged);
            // 
            // cbGPUNightVision
            // 
            this.cbGPUNightVision.AutoSize = true;
            this.cbGPUNightVision.Location = new System.Drawing.Point(20, 297);
            this.cbGPUNightVision.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUNightVision.Name = "cbGPUNightVision";
            this.cbGPUNightVision.Size = new System.Drawing.Size(115, 24);
            this.cbGPUNightVision.TabIndex = 91;
            this.cbGPUNightVision.Text = "Night vision";
            this.cbGPUNightVision.UseVisualStyleBackColor = true;
            this.cbGPUNightVision.CheckedChanged += new System.EventHandler(this.cbGPUNightVision_CheckedChanged);
            // 
            // label383
            // 
            this.label383.AutoSize = true;
            this.label383.Location = new System.Drawing.Point(219, 154);
            this.label383.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label383.Name = "label383";
            this.label383.Size = new System.Drawing.Size(77, 20);
            this.label383.TabIndex = 90;
            this.label383.Text = "Darkness";
            // 
            // label384
            // 
            this.label384.AutoSize = true;
            this.label384.Location = new System.Drawing.Point(15, 154);
            this.label384.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label384.Name = "label384";
            this.label384.Size = new System.Drawing.Size(70, 20);
            this.label384.TabIndex = 89;
            this.label384.Text = "Contrast";
            // 
            // label385
            // 
            this.label385.AutoSize = true;
            this.label385.Location = new System.Drawing.Point(219, 74);
            this.label385.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label385.Name = "label385";
            this.label385.Size = new System.Drawing.Size(83, 20);
            this.label385.TabIndex = 88;
            this.label385.Text = "Saturation";
            // 
            // label386
            // 
            this.label386.AutoSize = true;
            this.label386.Location = new System.Drawing.Point(15, 74);
            this.label386.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label386.Name = "label386";
            this.label386.Size = new System.Drawing.Size(78, 20);
            this.label386.TabIndex = 87;
            this.label386.Text = "Lightness";
            // 
            // tbGPUContrast
            // 
            this.tbGPUContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUContrast.Location = new System.Drawing.Point(10, 183);
            this.tbGPUContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGPUContrast.Maximum = 255;
            this.tbGPUContrast.Name = "tbGPUContrast";
            this.tbGPUContrast.Size = new System.Drawing.Size(195, 69);
            this.tbGPUContrast.TabIndex = 86;
            this.tbGPUContrast.Value = 255;
            this.tbGPUContrast.Scroll += new System.EventHandler(this.tbGPUContrast_Scroll);
            // 
            // tbGPUDarkness
            // 
            this.tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUDarkness.Location = new System.Drawing.Point(219, 183);
            this.tbGPUDarkness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGPUDarkness.Maximum = 255;
            this.tbGPUDarkness.Name = "tbGPUDarkness";
            this.tbGPUDarkness.Size = new System.Drawing.Size(195, 69);
            this.tbGPUDarkness.TabIndex = 85;
            this.tbGPUDarkness.Scroll += new System.EventHandler(this.tbGPUDarkness_Scroll);
            // 
            // tbGPULightness
            // 
            this.tbGPULightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPULightness.Location = new System.Drawing.Point(10, 97);
            this.tbGPULightness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGPULightness.Maximum = 255;
            this.tbGPULightness.Name = "tbGPULightness";
            this.tbGPULightness.Size = new System.Drawing.Size(195, 69);
            this.tbGPULightness.TabIndex = 84;
            this.tbGPULightness.Scroll += new System.EventHandler(this.tbGPULightness_Scroll);
            // 
            // tbGPUSaturation
            // 
            this.tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUSaturation.Location = new System.Drawing.Point(219, 97);
            this.tbGPUSaturation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGPUSaturation.Maximum = 255;
            this.tbGPUSaturation.Name = "tbGPUSaturation";
            this.tbGPUSaturation.Size = new System.Drawing.Size(195, 69);
            this.tbGPUSaturation.TabIndex = 83;
            this.tbGPUSaturation.Value = 255;
            this.tbGPUSaturation.Scroll += new System.EventHandler(this.tbGPUSaturation_Scroll);
            // 
            // cbGPUInvert
            // 
            this.cbGPUInvert.AutoSize = true;
            this.cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUInvert.Location = new System.Drawing.Point(212, 262);
            this.cbGPUInvert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUInvert.Name = "cbGPUInvert";
            this.cbGPUInvert.Size = new System.Drawing.Size(75, 24);
            this.cbGPUInvert.TabIndex = 82;
            this.cbGPUInvert.Text = "Invert";
            this.cbGPUInvert.UseVisualStyleBackColor = true;
            this.cbGPUInvert.CheckedChanged += new System.EventHandler(this.cbGPUInvert_CheckedChanged);
            // 
            // cbGPUGreyscale
            // 
            this.cbGPUGreyscale.AutoSize = true;
            this.cbGPUGreyscale.Location = new System.Drawing.Point(20, 262);
            this.cbGPUGreyscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGPUGreyscale.Name = "cbGPUGreyscale";
            this.cbGPUGreyscale.Size = new System.Drawing.Size(106, 24);
            this.cbGPUGreyscale.TabIndex = 81;
            this.cbGPUGreyscale.Text = "Greyscale";
            this.cbGPUGreyscale.UseVisualStyleBackColor = true;
            this.cbGPUGreyscale.CheckedChanged += new System.EventHandler(this.cbGPUGreyscale_CheckedChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.lbAdjSaturationCurrent);
            this.tabPage8.Controls.Add(this.lbAdjSaturationMax);
            this.tabPage8.Controls.Add(this.lbAdjSaturationMin);
            this.tabPage8.Controls.Add(this.tbAdjSaturation);
            this.tabPage8.Controls.Add(this.label45);
            this.tabPage8.Controls.Add(this.lbAdjHueCurrent);
            this.tabPage8.Controls.Add(this.lbAdjHueMax);
            this.tabPage8.Controls.Add(this.lbAdjHueMin);
            this.tabPage8.Controls.Add(this.tbAdjHue);
            this.tabPage8.Controls.Add(this.label41);
            this.tabPage8.Controls.Add(this.lbAdjContrastCurrent);
            this.tabPage8.Controls.Add(this.lbAdjContrastMax);
            this.tabPage8.Controls.Add(this.lbAdjContrastMin);
            this.tabPage8.Controls.Add(this.tbAdjContrast);
            this.tabPage8.Controls.Add(this.label23);
            this.tabPage8.Controls.Add(this.lbAdjBrightnessCurrent);
            this.tabPage8.Controls.Add(this.lbAdjBrightnessMax);
            this.tabPage8.Controls.Add(this.lbAdjBrightnessMin);
            this.tabPage8.Controls.Add(this.tbAdjBrightness);
            this.tabPage8.Controls.Add(this.label24);
            this.tabPage8.Location = new System.Drawing.Point(4, 29);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage8.Size = new System.Drawing.Size(439, 713);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Effects (Video renderer)";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // lbAdjSaturationCurrent
            // 
            this.lbAdjSaturationCurrent.AutoSize = true;
            this.lbAdjSaturationCurrent.Location = new System.Drawing.Point(195, 409);
            this.lbAdjSaturationCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjSaturationCurrent.Name = "lbAdjSaturationCurrent";
            this.lbAdjSaturationCurrent.Size = new System.Drawing.Size(97, 20);
            this.lbAdjSaturationCurrent.TabIndex = 48;
            this.lbAdjSaturationCurrent.Text = "Current = 40";
            // 
            // lbAdjSaturationMax
            // 
            this.lbAdjSaturationMax.AutoSize = true;
            this.lbAdjSaturationMax.Location = new System.Drawing.Point(100, 409);
            this.lbAdjSaturationMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjSaturationMax.Name = "lbAdjSaturationMax";
            this.lbAdjSaturationMax.Size = new System.Drawing.Size(82, 20);
            this.lbAdjSaturationMax.TabIndex = 47;
            this.lbAdjSaturationMax.Text = "Max = 100";
            // 
            // lbAdjSaturationMin
            // 
            this.lbAdjSaturationMin.AutoSize = true;
            this.lbAdjSaturationMin.Location = new System.Drawing.Point(28, 409);
            this.lbAdjSaturationMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjSaturationMin.Name = "lbAdjSaturationMin";
            this.lbAdjSaturationMin.Size = new System.Drawing.Size(60, 20);
            this.lbAdjSaturationMin.TabIndex = 45;
            this.lbAdjSaturationMin.Text = "Min = 1";
            // 
            // tbAdjSaturation
            // 
            this.tbAdjSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjSaturation.Location = new System.Drawing.Point(20, 365);
            this.tbAdjSaturation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAdjSaturation.Maximum = 100;
            this.tbAdjSaturation.Name = "tbAdjSaturation";
            this.tbAdjSaturation.Size = new System.Drawing.Size(286, 69);
            this.tbAdjSaturation.TabIndex = 44;
            this.tbAdjSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjSaturation.Value = 50;
            this.tbAdjSaturation.Scroll += new System.EventHandler(this.tbAdjSaturation_Scroll);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(15, 340);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(83, 20);
            this.label45.TabIndex = 43;
            this.label45.Text = "Saturation";
            // 
            // lbAdjHueCurrent
            // 
            this.lbAdjHueCurrent.AutoSize = true;
            this.lbAdjHueCurrent.Location = new System.Drawing.Point(195, 305);
            this.lbAdjHueCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjHueCurrent.Name = "lbAdjHueCurrent";
            this.lbAdjHueCurrent.Size = new System.Drawing.Size(97, 20);
            this.lbAdjHueCurrent.TabIndex = 42;
            this.lbAdjHueCurrent.Text = "Current = 40";
            // 
            // lbAdjHueMax
            // 
            this.lbAdjHueMax.AutoSize = true;
            this.lbAdjHueMax.Location = new System.Drawing.Point(100, 305);
            this.lbAdjHueMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjHueMax.Name = "lbAdjHueMax";
            this.lbAdjHueMax.Size = new System.Drawing.Size(82, 20);
            this.lbAdjHueMax.TabIndex = 41;
            this.lbAdjHueMax.Text = "Max = 100";
            // 
            // lbAdjHueMin
            // 
            this.lbAdjHueMin.AutoSize = true;
            this.lbAdjHueMin.Location = new System.Drawing.Point(28, 305);
            this.lbAdjHueMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjHueMin.Name = "lbAdjHueMin";
            this.lbAdjHueMin.Size = new System.Drawing.Size(60, 20);
            this.lbAdjHueMin.TabIndex = 39;
            this.lbAdjHueMin.Text = "Min = 1";
            // 
            // tbAdjHue
            // 
            this.tbAdjHue.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjHue.Location = new System.Drawing.Point(20, 260);
            this.tbAdjHue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAdjHue.Maximum = 100;
            this.tbAdjHue.Name = "tbAdjHue";
            this.tbAdjHue.Size = new System.Drawing.Size(286, 69);
            this.tbAdjHue.TabIndex = 38;
            this.tbAdjHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjHue.Value = 50;
            this.tbAdjHue.Scroll += new System.EventHandler(this.tbAdjHue_Scroll);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(15, 235);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(39, 20);
            this.label41.TabIndex = 37;
            this.label41.Text = "Hue";
            // 
            // lbAdjContrastCurrent
            // 
            this.lbAdjContrastCurrent.AutoSize = true;
            this.lbAdjContrastCurrent.Location = new System.Drawing.Point(195, 197);
            this.lbAdjContrastCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjContrastCurrent.Name = "lbAdjContrastCurrent";
            this.lbAdjContrastCurrent.Size = new System.Drawing.Size(97, 20);
            this.lbAdjContrastCurrent.TabIndex = 36;
            this.lbAdjContrastCurrent.Text = "Current = 40";
            // 
            // lbAdjContrastMax
            // 
            this.lbAdjContrastMax.AutoSize = true;
            this.lbAdjContrastMax.Location = new System.Drawing.Point(100, 197);
            this.lbAdjContrastMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjContrastMax.Name = "lbAdjContrastMax";
            this.lbAdjContrastMax.Size = new System.Drawing.Size(82, 20);
            this.lbAdjContrastMax.TabIndex = 35;
            this.lbAdjContrastMax.Text = "Max = 100";
            // 
            // lbAdjContrastMin
            // 
            this.lbAdjContrastMin.AutoSize = true;
            this.lbAdjContrastMin.Location = new System.Drawing.Point(28, 197);
            this.lbAdjContrastMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjContrastMin.Name = "lbAdjContrastMin";
            this.lbAdjContrastMin.Size = new System.Drawing.Size(60, 20);
            this.lbAdjContrastMin.TabIndex = 33;
            this.lbAdjContrastMin.Text = "Min = 1";
            // 
            // tbAdjContrast
            // 
            this.tbAdjContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjContrast.Location = new System.Drawing.Point(20, 152);
            this.tbAdjContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAdjContrast.Maximum = 100;
            this.tbAdjContrast.Name = "tbAdjContrast";
            this.tbAdjContrast.Size = new System.Drawing.Size(286, 69);
            this.tbAdjContrast.TabIndex = 32;
            this.tbAdjContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjContrast.Value = 50;
            this.tbAdjContrast.Scroll += new System.EventHandler(this.tbAdjContrast_Scroll);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(15, 128);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 20);
            this.label23.TabIndex = 31;
            this.label23.Text = "Contrast";
            // 
            // lbAdjBrightnessCurrent
            // 
            this.lbAdjBrightnessCurrent.AutoSize = true;
            this.lbAdjBrightnessCurrent.Location = new System.Drawing.Point(195, 92);
            this.lbAdjBrightnessCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjBrightnessCurrent.Name = "lbAdjBrightnessCurrent";
            this.lbAdjBrightnessCurrent.Size = new System.Drawing.Size(97, 20);
            this.lbAdjBrightnessCurrent.TabIndex = 30;
            this.lbAdjBrightnessCurrent.Text = "Current = 40";
            // 
            // lbAdjBrightnessMax
            // 
            this.lbAdjBrightnessMax.AutoSize = true;
            this.lbAdjBrightnessMax.Location = new System.Drawing.Point(100, 92);
            this.lbAdjBrightnessMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjBrightnessMax.Name = "lbAdjBrightnessMax";
            this.lbAdjBrightnessMax.Size = new System.Drawing.Size(82, 20);
            this.lbAdjBrightnessMax.TabIndex = 29;
            this.lbAdjBrightnessMax.Text = "Max = 100";
            // 
            // lbAdjBrightnessMin
            // 
            this.lbAdjBrightnessMin.AutoSize = true;
            this.lbAdjBrightnessMin.Location = new System.Drawing.Point(28, 92);
            this.lbAdjBrightnessMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdjBrightnessMin.Name = "lbAdjBrightnessMin";
            this.lbAdjBrightnessMin.Size = new System.Drawing.Size(60, 20);
            this.lbAdjBrightnessMin.TabIndex = 27;
            this.lbAdjBrightnessMin.Text = "Min = 1";
            // 
            // tbAdjBrightness
            // 
            this.tbAdjBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjBrightness.Location = new System.Drawing.Point(20, 48);
            this.tbAdjBrightness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAdjBrightness.Maximum = 100;
            this.tbAdjBrightness.Name = "tbAdjBrightness";
            this.tbAdjBrightness.Size = new System.Drawing.Size(286, 69);
            this.tbAdjBrightness.TabIndex = 26;
            this.tbAdjBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjBrightness.Value = 50;
            this.tbAdjBrightness.Scroll += new System.EventHandler(this.tbAdjBrightness_Scroll);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 23);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 20);
            this.label24.TabIndex = 25;
            this.label24.Text = "Brightness";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.pnChromaKeyColor);
            this.tabPage15.Controls.Add(this.btChromaKeySelectBGImage);
            this.tabPage15.Controls.Add(this.edChromaKeyImage);
            this.tabPage15.Controls.Add(this.label216);
            this.tabPage15.Controls.Add(this.label215);
            this.tabPage15.Controls.Add(this.tbChromaKeySmoothing);
            this.tabPage15.Controls.Add(this.label214);
            this.tabPage15.Controls.Add(this.tbChromaKeyThresholdSensitivity);
            this.tabPage15.Controls.Add(this.label213);
            this.tabPage15.Controls.Add(this.cbChromaKeyEnabled);
            this.tabPage15.Location = new System.Drawing.Point(4, 29);
            this.tabPage15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage15.Size = new System.Drawing.Size(439, 713);
            this.tabPage15.TabIndex = 7;
            this.tabPage15.Text = "Chroma key";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // pnChromaKeyColor
            // 
            this.pnChromaKeyColor.BackColor = System.Drawing.Color.Lime;
            this.pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control;
            this.pnChromaKeyColor.Location = new System.Drawing.Point(82, 308);
            this.pnChromaKeyColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnChromaKeyColor.Name = "pnChromaKeyColor";
            this.pnChromaKeyColor.Size = new System.Drawing.Size(39, 37);
            this.pnChromaKeyColor.TabIndex = 33;
            this.pnChromaKeyColor.Click += new System.EventHandler(this.pnChromaKeyColor_Click);
            // 
            // btChromaKeySelectBGImage
            // 
            this.btChromaKeySelectBGImage.Location = new System.Drawing.Point(382, 403);
            this.btChromaKeySelectBGImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage";
            this.btChromaKeySelectBGImage.Size = new System.Drawing.Size(36, 35);
            this.btChromaKeySelectBGImage.TabIndex = 32;
            this.btChromaKeySelectBGImage.Text = "...";
            this.btChromaKeySelectBGImage.UseVisualStyleBackColor = true;
            this.btChromaKeySelectBGImage.Click += new System.EventHandler(this.btChromaKeySelectBGImage_Click);
            // 
            // edChromaKeyImage
            // 
            this.edChromaKeyImage.Location = new System.Drawing.Point(20, 406);
            this.edChromaKeyImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edChromaKeyImage.Name = "edChromaKeyImage";
            this.edChromaKeyImage.Size = new System.Drawing.Size(350, 26);
            this.edChromaKeyImage.TabIndex = 31;
            this.edChromaKeyImage.Text = "c:\\Samples\\pics\\1.jpg";
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(15, 382);
            this.label216.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(166, 20);
            this.label216.TabIndex = 30;
            this.label216.Text = "Image background file";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(15, 314);
            this.label215.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(46, 20);
            this.label215.TabIndex = 26;
            this.label215.Text = "Color";
            // 
            // tbChromaKeySmoothing
            // 
            this.tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window;
            this.tbChromaKeySmoothing.Location = new System.Drawing.Point(20, 223);
            this.tbChromaKeySmoothing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbChromaKeySmoothing.Maximum = 1000;
            this.tbChromaKeySmoothing.Name = "tbChromaKeySmoothing";
            this.tbChromaKeySmoothing.Size = new System.Drawing.Size(231, 69);
            this.tbChromaKeySmoothing.TabIndex = 25;
            this.tbChromaKeySmoothing.Value = 80;
            this.tbChromaKeySmoothing.Scroll += new System.EventHandler(this.tbChromaKeyContrastHigh_Scroll);
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(15, 195);
            this.label214.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(86, 20);
            this.label214.TabIndex = 24;
            this.label214.Text = "Smoothing";
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            this.tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window;
            this.tbChromaKeyThresholdSensitivity.Location = new System.Drawing.Point(20, 111);
            this.tbChromaKeyThresholdSensitivity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbChromaKeyThresholdSensitivity.Maximum = 200;
            this.tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity";
            this.tbChromaKeyThresholdSensitivity.Size = new System.Drawing.Size(231, 69);
            this.tbChromaKeyThresholdSensitivity.TabIndex = 23;
            this.tbChromaKeyThresholdSensitivity.Value = 180;
            this.tbChromaKeyThresholdSensitivity.Scroll += new System.EventHandler(this.tbChromaKeyContrastLow_Scroll);
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(15, 83);
            this.label213.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(150, 20);
            this.label213.TabIndex = 22;
            this.label213.Text = "Threshold sensitivity";
            // 
            // cbChromaKeyEnabled
            // 
            this.cbChromaKeyEnabled.AutoSize = true;
            this.cbChromaKeyEnabled.Location = new System.Drawing.Point(20, 23);
            this.cbChromaKeyEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbChromaKeyEnabled.Name = "cbChromaKeyEnabled";
            this.cbChromaKeyEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbChromaKeyEnabled.TabIndex = 21;
            this.cbChromaKeyEnabled.Text = "Enabled";
            this.cbChromaKeyEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage46
            // 
            this.tabPage46.Controls.Add(this.btFilterDelete);
            this.tabPage46.Controls.Add(this.btFilterDeleteAll);
            this.tabPage46.Controls.Add(this.btFilterSettings2);
            this.tabPage46.Controls.Add(this.lbFilters);
            this.tabPage46.Controls.Add(this.label106);
            this.tabPage46.Controls.Add(this.btFilterSettings);
            this.tabPage46.Controls.Add(this.btFilterAdd);
            this.tabPage46.Controls.Add(this.cbFilters);
            this.tabPage46.Controls.Add(this.label105);
            this.tabPage46.Location = new System.Drawing.Point(4, 29);
            this.tabPage46.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage46.Name = "tabPage46";
            this.tabPage46.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage46.Size = new System.Drawing.Size(439, 713);
            this.tabPage46.TabIndex = 8;
            this.tabPage46.Text = "3rd-party filters";
            this.tabPage46.UseVisualStyleBackColor = true;
            // 
            // btFilterDelete
            // 
            this.btFilterDelete.Location = new System.Drawing.Point(225, 437);
            this.btFilterDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFilterDelete.Name = "btFilterDelete";
            this.btFilterDelete.Size = new System.Drawing.Size(72, 35);
            this.btFilterDelete.TabIndex = 26;
            this.btFilterDelete.Text = "Delete";
            this.btFilterDelete.UseVisualStyleBackColor = true;
            this.btFilterDelete.Click += new System.EventHandler(this.btFilterDelete_Click);
            // 
            // btFilterDeleteAll
            // 
            this.btFilterDeleteAll.Location = new System.Drawing.Point(306, 437);
            this.btFilterDeleteAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFilterDeleteAll.Name = "btFilterDeleteAll";
            this.btFilterDeleteAll.Size = new System.Drawing.Size(102, 35);
            this.btFilterDeleteAll.TabIndex = 25;
            this.btFilterDeleteAll.Text = "Delete all";
            this.btFilterDeleteAll.UseVisualStyleBackColor = true;
            this.btFilterDeleteAll.Click += new System.EventHandler(this.btFilterDeleteAll_Click);
            // 
            // btFilterSettings2
            // 
            this.btFilterSettings2.Location = new System.Drawing.Point(18, 437);
            this.btFilterSettings2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFilterSettings2.Name = "btFilterSettings2";
            this.btFilterSettings2.Size = new System.Drawing.Size(98, 35);
            this.btFilterSettings2.TabIndex = 24;
            this.btFilterSettings2.Text = "Settings";
            this.btFilterSettings2.UseVisualStyleBackColor = true;
            this.btFilterSettings2.Click += new System.EventHandler(this.btFilterSettings2_Click);
            // 
            // lbFilters
            // 
            this.lbFilters.FormattingEnabled = true;
            this.lbFilters.ItemHeight = 20;
            this.lbFilters.Location = new System.Drawing.Point(18, 182);
            this.lbFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbFilters.Name = "lbFilters";
            this.lbFilters.Size = new System.Drawing.Size(388, 244);
            this.lbFilters.TabIndex = 23;
            this.lbFilters.SelectedIndexChanged += new System.EventHandler(this.lbFilters_SelectedIndexChanged);
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(14, 157);
            this.label106.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(104, 20);
            this.label106.TabIndex = 22;
            this.label106.Text = "Current filters";
            // 
            // btFilterSettings
            // 
            this.btFilterSettings.Location = new System.Drawing.Point(306, 83);
            this.btFilterSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFilterSettings.Name = "btFilterSettings";
            this.btFilterSettings.Size = new System.Drawing.Size(102, 35);
            this.btFilterSettings.TabIndex = 21;
            this.btFilterSettings.Text = "Settings";
            this.btFilterSettings.UseVisualStyleBackColor = true;
            this.btFilterSettings.Click += new System.EventHandler(this.btFilterSettings_Click);
            // 
            // btFilterAdd
            // 
            this.btFilterAdd.Location = new System.Drawing.Point(18, 83);
            this.btFilterAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFilterAdd.Name = "btFilterAdd";
            this.btFilterAdd.Size = new System.Drawing.Size(58, 35);
            this.btFilterAdd.TabIndex = 20;
            this.btFilterAdd.Text = "Add";
            this.btFilterAdd.UseVisualStyleBackColor = true;
            this.btFilterAdd.Click += new System.EventHandler(this.btFilterAdd_Click);
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(18, 42);
            this.cbFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(388, 28);
            this.cbFilters.TabIndex = 19;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(14, 17);
            this.label105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(52, 20);
            this.label105.TabIndex = 18;
            this.label105.Text = "Filters";
            // 
            // tabPage48
            // 
            this.tabPage48.Controls.Add(this.lbAudioTimeshift);
            this.tabPage48.Controls.Add(this.tbAudioTimeshift);
            this.tabPage48.Controls.Add(this.label70);
            this.tabPage48.Controls.Add(this.groupBox4);
            this.tabPage48.Controls.Add(this.groupBox1);
            this.tabPage48.Controls.Add(this.cbAudioAutoGain);
            this.tabPage48.Controls.Add(this.cbAudioNormalize);
            this.tabPage48.Controls.Add(this.cbAudioEnhancementEnabled);
            this.tabPage48.Location = new System.Drawing.Point(4, 29);
            this.tabPage48.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage48.Name = "tabPage48";
            this.tabPage48.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage48.Size = new System.Drawing.Size(456, 764);
            this.tabPage48.TabIndex = 12;
            this.tabPage48.Text = "Audio enhancement";
            this.tabPage48.UseVisualStyleBackColor = true;
            // 
            // lbAudioTimeshift
            // 
            this.lbAudioTimeshift.AutoSize = true;
            this.lbAudioTimeshift.Location = new System.Drawing.Point(261, 689);
            this.lbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioTimeshift.Name = "lbAudioTimeshift";
            this.lbAudioTimeshift.Size = new System.Drawing.Size(43, 20);
            this.lbAudioTimeshift.TabIndex = 7;
            this.lbAudioTimeshift.Text = "0 ms";
            // 
            // tbAudioTimeshift
            // 
            this.tbAudioTimeshift.Location = new System.Drawing.Point(96, 672);
            this.tbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioTimeshift.Maximum = 3000;
            this.tbAudioTimeshift.Name = "tbAudioTimeshift";
            this.tbAudioTimeshift.Size = new System.Drawing.Size(156, 69);
            this.tbAudioTimeshift.SmallChange = 10;
            this.tbAudioTimeshift.TabIndex = 6;
            this.tbAudioTimeshift.TickFrequency = 100;
            this.tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioTimeshift.Scroll += new System.EventHandler(this.tbAudioTimeshift_Scroll);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(4, 689);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(77, 20);
            this.label70.TabIndex = 5;
            this.label70.Text = "Time shift";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbAudioOutputGainLFE);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainLFE);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.lbAudioOutputGainSR);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainSR);
            this.groupBox4.Controls.Add(this.label57);
            this.groupBox4.Controls.Add(this.lbAudioOutputGainSL);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainSL);
            this.groupBox4.Controls.Add(this.label59);
            this.groupBox4.Controls.Add(this.lbAudioOutputGainR);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainR);
            this.groupBox4.Controls.Add(this.label61);
            this.groupBox4.Controls.Add(this.lbAudioOutputGainC);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainC);
            this.groupBox4.Controls.Add(this.label67);
            this.groupBox4.Controls.Add(this.lbAudioOutputGainL);
            this.groupBox4.Controls.Add(this.tbAudioOutputGainL);
            this.groupBox4.Controls.Add(this.label69);
            this.groupBox4.Location = new System.Drawing.Point(9, 395);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(434, 265);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output gains (dB)";
            // 
            // lbAudioOutputGainLFE
            // 
            this.lbAudioOutputGainLFE.AutoSize = true;
            this.lbAudioOutputGainLFE.Location = new System.Drawing.Point(374, 228);
            this.lbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE";
            this.lbAudioOutputGainLFE.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainLFE.TabIndex = 17;
            this.lbAudioOutputGainLFE.Text = "0.0";
            // 
            // tbAudioOutputGainLFE
            // 
            this.tbAudioOutputGainLFE.Location = new System.Drawing.Point(363, 63);
            this.tbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainLFE.Maximum = 200;
            this.tbAudioOutputGainLFE.Minimum = -200;
            this.tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE";
            this.tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainLFE.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainLFE.TabIndex = 16;
            this.tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainLFE.Scroll += new System.EventHandler(this.tbAudioOutputGainLFE_Scroll);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(375, 38);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(39, 20);
            this.label55.TabIndex = 15;
            this.label55.Text = "LFE";
            // 
            // lbAudioOutputGainSR
            // 
            this.lbAudioOutputGainSR.AutoSize = true;
            this.lbAudioOutputGainSR.Location = new System.Drawing.Point(302, 228);
            this.lbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainSR.Name = "lbAudioOutputGainSR";
            this.lbAudioOutputGainSR.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainSR.TabIndex = 14;
            this.lbAudioOutputGainSR.Text = "0.0";
            // 
            // tbAudioOutputGainSR
            // 
            this.tbAudioOutputGainSR.Location = new System.Drawing.Point(291, 63);
            this.tbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainSR.Maximum = 200;
            this.tbAudioOutputGainSR.Minimum = -200;
            this.tbAudioOutputGainSR.Name = "tbAudioOutputGainSR";
            this.tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainSR.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainSR.TabIndex = 13;
            this.tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainSR.Scroll += new System.EventHandler(this.tbAudioOutputGainSR_Scroll);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(308, 38);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(32, 20);
            this.label57.TabIndex = 12;
            this.label57.Text = "SR";
            // 
            // lbAudioOutputGainSL
            // 
            this.lbAudioOutputGainSL.AutoSize = true;
            this.lbAudioOutputGainSL.Location = new System.Drawing.Point(230, 228);
            this.lbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainSL.Name = "lbAudioOutputGainSL";
            this.lbAudioOutputGainSL.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainSL.TabIndex = 11;
            this.lbAudioOutputGainSL.Text = "0.0";
            // 
            // tbAudioOutputGainSL
            // 
            this.tbAudioOutputGainSL.Location = new System.Drawing.Point(219, 63);
            this.tbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainSL.Maximum = 200;
            this.tbAudioOutputGainSL.Minimum = -200;
            this.tbAudioOutputGainSL.Name = "tbAudioOutputGainSL";
            this.tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainSL.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainSL.TabIndex = 10;
            this.tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainSL.Scroll += new System.EventHandler(this.tbAudioOutputGainSL_Scroll);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(237, 38);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(29, 20);
            this.label59.TabIndex = 9;
            this.label59.Text = "SL";
            // 
            // lbAudioOutputGainR
            // 
            this.lbAudioOutputGainR.AutoSize = true;
            this.lbAudioOutputGainR.Location = new System.Drawing.Point(158, 228);
            this.lbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainR.Name = "lbAudioOutputGainR";
            this.lbAudioOutputGainR.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainR.TabIndex = 8;
            this.lbAudioOutputGainR.Text = "0.0";
            // 
            // tbAudioOutputGainR
            // 
            this.tbAudioOutputGainR.Location = new System.Drawing.Point(147, 63);
            this.tbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainR.Maximum = 200;
            this.tbAudioOutputGainR.Minimum = -200;
            this.tbAudioOutputGainR.Name = "tbAudioOutputGainR";
            this.tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainR.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainR.TabIndex = 7;
            this.tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainR.Scroll += new System.EventHandler(this.tbAudioOutputGainR_Scroll);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(171, 38);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(21, 20);
            this.label61.TabIndex = 6;
            this.label61.Text = "R";
            // 
            // lbAudioOutputGainC
            // 
            this.lbAudioOutputGainC.AutoSize = true;
            this.lbAudioOutputGainC.Location = new System.Drawing.Point(86, 228);
            this.lbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainC.Name = "lbAudioOutputGainC";
            this.lbAudioOutputGainC.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainC.TabIndex = 5;
            this.lbAudioOutputGainC.Text = "0.0";
            // 
            // tbAudioOutputGainC
            // 
            this.tbAudioOutputGainC.Location = new System.Drawing.Point(75, 63);
            this.tbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainC.Maximum = 200;
            this.tbAudioOutputGainC.Minimum = -200;
            this.tbAudioOutputGainC.Name = "tbAudioOutputGainC";
            this.tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainC.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainC.TabIndex = 4;
            this.tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainC.Scroll += new System.EventHandler(this.tbAudioOutputGainC_Scroll);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(99, 38);
            this.label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(20, 20);
            this.label67.TabIndex = 3;
            this.label67.Text = "C";
            // 
            // lbAudioOutputGainL
            // 
            this.lbAudioOutputGainL.AutoSize = true;
            this.lbAudioOutputGainL.Location = new System.Drawing.Point(14, 228);
            this.lbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioOutputGainL.Name = "lbAudioOutputGainL";
            this.lbAudioOutputGainL.Size = new System.Drawing.Size(31, 20);
            this.lbAudioOutputGainL.TabIndex = 2;
            this.lbAudioOutputGainL.Text = "0.0";
            // 
            // tbAudioOutputGainL
            // 
            this.tbAudioOutputGainL.Location = new System.Drawing.Point(3, 63);
            this.tbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioOutputGainL.Maximum = 200;
            this.tbAudioOutputGainL.Minimum = -200;
            this.tbAudioOutputGainL.Name = "tbAudioOutputGainL";
            this.tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainL.Size = new System.Drawing.Size(69, 160);
            this.tbAudioOutputGainL.TabIndex = 1;
            this.tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainL.Scroll += new System.EventHandler(this.tbAudioOutputGainL_Scroll);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(27, 38);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(18, 20);
            this.label69.TabIndex = 0;
            this.label69.Text = "L";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAudioInputGainLFE);
            this.groupBox1.Controls.Add(this.tbAudioInputGainLFE);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.lbAudioInputGainSR);
            this.groupBox1.Controls.Add(this.tbAudioInputGainSR);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.lbAudioInputGainSL);
            this.groupBox1.Controls.Add(this.tbAudioInputGainSL);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.lbAudioInputGainR);
            this.groupBox1.Controls.Add(this.tbAudioInputGainR);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.lbAudioInputGainC);
            this.groupBox1.Controls.Add(this.tbAudioInputGainC);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.lbAudioInputGainL);
            this.groupBox1.Controls.Add(this.tbAudioInputGainL);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Location = new System.Drawing.Point(9, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(434, 265);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input gains (dB)";
            // 
            // lbAudioInputGainLFE
            // 
            this.lbAudioInputGainLFE.AutoSize = true;
            this.lbAudioInputGainLFE.Location = new System.Drawing.Point(374, 228);
            this.lbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainLFE.Name = "lbAudioInputGainLFE";
            this.lbAudioInputGainLFE.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainLFE.TabIndex = 17;
            this.lbAudioInputGainLFE.Text = "0.0";
            // 
            // tbAudioInputGainLFE
            // 
            this.tbAudioInputGainLFE.Location = new System.Drawing.Point(363, 63);
            this.tbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainLFE.Maximum = 200;
            this.tbAudioInputGainLFE.Minimum = -200;
            this.tbAudioInputGainLFE.Name = "tbAudioInputGainLFE";
            this.tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainLFE.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainLFE.TabIndex = 16;
            this.tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainLFE.Scroll += new System.EventHandler(this.tbAudioInputGainLFE_Scroll);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(375, 38);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(39, 20);
            this.label53.TabIndex = 15;
            this.label53.Text = "LFE";
            // 
            // lbAudioInputGainSR
            // 
            this.lbAudioInputGainSR.AutoSize = true;
            this.lbAudioInputGainSR.Location = new System.Drawing.Point(302, 228);
            this.lbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainSR.Name = "lbAudioInputGainSR";
            this.lbAudioInputGainSR.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainSR.TabIndex = 14;
            this.lbAudioInputGainSR.Text = "0.0";
            // 
            // tbAudioInputGainSR
            // 
            this.tbAudioInputGainSR.Location = new System.Drawing.Point(291, 63);
            this.tbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainSR.Maximum = 200;
            this.tbAudioInputGainSR.Minimum = -200;
            this.tbAudioInputGainSR.Name = "tbAudioInputGainSR";
            this.tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainSR.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainSR.TabIndex = 13;
            this.tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainSR.Scroll += new System.EventHandler(this.tbAudioInputGainSR_Scroll);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(308, 38);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(32, 20);
            this.label51.TabIndex = 12;
            this.label51.Text = "SR";
            // 
            // lbAudioInputGainSL
            // 
            this.lbAudioInputGainSL.AutoSize = true;
            this.lbAudioInputGainSL.Location = new System.Drawing.Point(230, 228);
            this.lbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainSL.Name = "lbAudioInputGainSL";
            this.lbAudioInputGainSL.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainSL.TabIndex = 11;
            this.lbAudioInputGainSL.Text = "0.0";
            // 
            // tbAudioInputGainSL
            // 
            this.tbAudioInputGainSL.Location = new System.Drawing.Point(219, 63);
            this.tbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainSL.Maximum = 200;
            this.tbAudioInputGainSL.Minimum = -200;
            this.tbAudioInputGainSL.Name = "tbAudioInputGainSL";
            this.tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainSL.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainSL.TabIndex = 10;
            this.tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainSL.Scroll += new System.EventHandler(this.tbAudioInputGainSL_Scroll);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(237, 38);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(29, 20);
            this.label49.TabIndex = 9;
            this.label49.Text = "SL";
            // 
            // lbAudioInputGainR
            // 
            this.lbAudioInputGainR.AutoSize = true;
            this.lbAudioInputGainR.Location = new System.Drawing.Point(158, 228);
            this.lbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainR.Name = "lbAudioInputGainR";
            this.lbAudioInputGainR.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainR.TabIndex = 8;
            this.lbAudioInputGainR.Text = "0.0";
            // 
            // tbAudioInputGainR
            // 
            this.tbAudioInputGainR.Location = new System.Drawing.Point(147, 63);
            this.tbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainR.Maximum = 200;
            this.tbAudioInputGainR.Minimum = -200;
            this.tbAudioInputGainR.Name = "tbAudioInputGainR";
            this.tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainR.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainR.TabIndex = 7;
            this.tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainR.Scroll += new System.EventHandler(this.tbAudioInputGainR_Scroll);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(171, 38);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(21, 20);
            this.label47.TabIndex = 6;
            this.label47.Text = "R";
            // 
            // lbAudioInputGainC
            // 
            this.lbAudioInputGainC.AutoSize = true;
            this.lbAudioInputGainC.Location = new System.Drawing.Point(86, 228);
            this.lbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainC.Name = "lbAudioInputGainC";
            this.lbAudioInputGainC.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainC.TabIndex = 5;
            this.lbAudioInputGainC.Text = "0.0";
            // 
            // tbAudioInputGainC
            // 
            this.tbAudioInputGainC.Location = new System.Drawing.Point(75, 63);
            this.tbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainC.Maximum = 200;
            this.tbAudioInputGainC.Minimum = -200;
            this.tbAudioInputGainC.Name = "tbAudioInputGainC";
            this.tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainC.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainC.TabIndex = 4;
            this.tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainC.Scroll += new System.EventHandler(this.tbAudioInputGainC_Scroll);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(99, 38);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(20, 20);
            this.label44.TabIndex = 3;
            this.label44.Text = "C";
            // 
            // lbAudioInputGainL
            // 
            this.lbAudioInputGainL.AutoSize = true;
            this.lbAudioInputGainL.Location = new System.Drawing.Point(14, 228);
            this.lbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudioInputGainL.Name = "lbAudioInputGainL";
            this.lbAudioInputGainL.Size = new System.Drawing.Size(31, 20);
            this.lbAudioInputGainL.TabIndex = 2;
            this.lbAudioInputGainL.Text = "0.0";
            // 
            // tbAudioInputGainL
            // 
            this.tbAudioInputGainL.Location = new System.Drawing.Point(3, 63);
            this.tbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioInputGainL.Maximum = 200;
            this.tbAudioInputGainL.Minimum = -200;
            this.tbAudioInputGainL.Name = "tbAudioInputGainL";
            this.tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainL.Size = new System.Drawing.Size(69, 160);
            this.tbAudioInputGainL.TabIndex = 1;
            this.tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainL.Scroll += new System.EventHandler(this.tbAudioInputGainL_Scroll);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(27, 38);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(18, 20);
            this.label40.TabIndex = 0;
            this.label40.Text = "L";
            // 
            // cbAudioAutoGain
            // 
            this.cbAudioAutoGain.AutoSize = true;
            this.cbAudioAutoGain.Location = new System.Drawing.Point(200, 72);
            this.cbAudioAutoGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioAutoGain.Name = "cbAudioAutoGain";
            this.cbAudioAutoGain.Size = new System.Drawing.Size(103, 24);
            this.cbAudioAutoGain.TabIndex = 2;
            this.cbAudioAutoGain.Text = "Auto gain";
            this.cbAudioAutoGain.UseVisualStyleBackColor = true;
            this.cbAudioAutoGain.CheckedChanged += new System.EventHandler(this.cbAudioAutoGain_CheckedChanged);
            // 
            // cbAudioNormalize
            // 
            this.cbAudioNormalize.AutoSize = true;
            this.cbAudioNormalize.Location = new System.Drawing.Point(58, 72);
            this.cbAudioNormalize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioNormalize.Name = "cbAudioNormalize";
            this.cbAudioNormalize.Size = new System.Drawing.Size(105, 24);
            this.cbAudioNormalize.TabIndex = 1;
            this.cbAudioNormalize.Text = "Normalize";
            this.cbAudioNormalize.UseVisualStyleBackColor = true;
            this.cbAudioNormalize.CheckedChanged += new System.EventHandler(this.cbAudioNormalize_CheckedChanged);
            // 
            // cbAudioEnhancementEnabled
            // 
            this.cbAudioEnhancementEnabled.AutoSize = true;
            this.cbAudioEnhancementEnabled.Location = new System.Drawing.Point(24, 23);
            this.cbAudioEnhancementEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled";
            this.cbAudioEnhancementEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudioEnhancementEnabled.TabIndex = 0;
            this.cbAudioEnhancementEnabled.Text = "Enabled";
            this.cbAudioEnhancementEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label31);
            this.tabPage11.Controls.Add(this.tabControl18);
            this.tabPage11.Controls.Add(this.cbAudioEffectsEnabled);
            this.tabPage11.Location = new System.Drawing.Point(4, 29);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage11.Size = new System.Drawing.Size(456, 764);
            this.tabPage11.TabIndex = 5;
            this.tabPage11.Text = "Audio effects";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(140, 14);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(278, 20);
            this.label31.TabIndex = 4;
            this.label31.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage73);
            this.tabControl18.Controls.Add(this.tabPage75);
            this.tabControl18.Controls.Add(this.tabPage76);
            this.tabControl18.Controls.Add(this.tabPage27);
            this.tabControl18.Location = new System.Drawing.Point(12, 48);
            this.tabControl18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl18.Name = "tabControl18";
            this.tabControl18.SelectedIndex = 0;
            this.tabControl18.Size = new System.Drawing.Size(424, 680);
            this.tabControl18.TabIndex = 3;
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.label231);
            this.tabPage71.Controls.Add(this.label230);
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = new System.Drawing.Point(4, 29);
            this.tabPage71.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage71.Name = "tabPage71";
            this.tabPage71.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage71.Size = new System.Drawing.Size(416, 647);
            this.tabPage71.TabIndex = 0;
            this.tabPage71.Text = "Amplify";
            this.tabPage71.UseVisualStyleBackColor = true;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Location = new System.Drawing.Point(320, 82);
            this.label231.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(50, 20);
            this.label231.TabIndex = 5;
            this.label231.Text = "400%";
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(102, 82);
            this.label230.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(50, 20);
            this.label230.TabIndex = 4;
            this.label230.Text = "100%";
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAmplifyAmp.Location = new System.Drawing.Point(24, 106);
            this.tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudAmplifyAmp.Maximum = 4000;
            this.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            this.tbAudAmplifyAmp.Size = new System.Drawing.Size(345, 69);
            this.tbAudAmplifyAmp.TabIndex = 3;
            this.tbAudAmplifyAmp.TickFrequency = 50;
            this.tbAudAmplifyAmp.Value = 1000;
            this.tbAudAmplifyAmp.Scroll += new System.EventHandler(this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(20, 82);
            this.label95.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(63, 20);
            this.label95.TabIndex = 2;
            this.label95.Text = "Volume";
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = true;
            this.cbAudAmplifyEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            this.cbAudAmplifyEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudAmplifyEnabled.TabIndex = 1;
            this.cbAudAmplifyEnabled.Text = "Enabled";
            this.cbAudAmplifyEnabled.UseVisualStyleBackColor = true;
            this.cbAudAmplifyEnabled.CheckedChanged += new System.EventHandler(this.cbAudAmplifyEnabled_CheckedChanged);
            // 
            // tabPage72
            // 
            this.tabPage72.Controls.Add(this.btAudEqRefresh);
            this.tabPage72.Controls.Add(this.cbAudEqualizerPreset);
            this.tabPage72.Controls.Add(this.label243);
            this.tabPage72.Controls.Add(this.label242);
            this.tabPage72.Controls.Add(this.label241);
            this.tabPage72.Controls.Add(this.label240);
            this.tabPage72.Controls.Add(this.label239);
            this.tabPage72.Controls.Add(this.label238);
            this.tabPage72.Controls.Add(this.label237);
            this.tabPage72.Controls.Add(this.label236);
            this.tabPage72.Controls.Add(this.label235);
            this.tabPage72.Controls.Add(this.label234);
            this.tabPage72.Controls.Add(this.label233);
            this.tabPage72.Controls.Add(this.label232);
            this.tabPage72.Controls.Add(this.tbAudEq9);
            this.tabPage72.Controls.Add(this.tbAudEq8);
            this.tabPage72.Controls.Add(this.tbAudEq7);
            this.tabPage72.Controls.Add(this.tbAudEq6);
            this.tabPage72.Controls.Add(this.tbAudEq5);
            this.tabPage72.Controls.Add(this.tbAudEq4);
            this.tabPage72.Controls.Add(this.tbAudEq3);
            this.tabPage72.Controls.Add(this.tbAudEq2);
            this.tabPage72.Controls.Add(this.tbAudEq1);
            this.tabPage72.Controls.Add(this.tbAudEq0);
            this.tabPage72.Controls.Add(this.cbAudEqualizerEnabled);
            this.tabPage72.Location = new System.Drawing.Point(4, 29);
            this.tabPage72.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage72.Name = "tabPage72";
            this.tabPage72.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage72.Size = new System.Drawing.Size(416, 647);
            this.tabPage72.TabIndex = 1;
            this.tabPage72.Text = "Equalizer";
            this.tabPage72.UseVisualStyleBackColor = true;
            // 
            // btAudEqRefresh
            // 
            this.btAudEqRefresh.Location = new System.Drawing.Point(262, 337);
            this.btAudEqRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAudEqRefresh.Name = "btAudEqRefresh";
            this.btAudEqRefresh.Size = new System.Drawing.Size(112, 35);
            this.btAudEqRefresh.TabIndex = 26;
            this.btAudEqRefresh.Text = "Refresh";
            this.btAudEqRefresh.UseVisualStyleBackColor = true;
            this.btAudEqRefresh.Click += new System.EventHandler(this.btAudEqRefresh_Click);
            // 
            // cbAudEqualizerPreset
            // 
            this.cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudEqualizerPreset.FormattingEnabled = true;
            this.cbAudEqualizerPreset.Location = new System.Drawing.Point(92, 277);
            this.cbAudEqualizerPreset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudEqualizerPreset.Name = "cbAudEqualizerPreset";
            this.cbAudEqualizerPreset.Size = new System.Drawing.Size(282, 28);
            this.cbAudEqualizerPreset.TabIndex = 25;
            this.cbAudEqualizerPreset.SelectedIndexChanged += new System.EventHandler(this.cbAudEqualizerPreset_SelectedIndexChanged);
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Location = new System.Drawing.Point(21, 282);
            this.label243.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(55, 20);
            this.label243.TabIndex = 24;
            this.label243.Text = "Preset";
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(309, 240);
            this.label242.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(37, 20);
            this.label242.TabIndex = 23;
            this.label242.Text = "16K";
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(276, 240);
            this.label241.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(37, 20);
            this.label241.TabIndex = 22;
            this.label241.Text = "14K";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(243, 240);
            this.label240.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(37, 20);
            this.label240.TabIndex = 21;
            this.label240.Text = "12K";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(214, 240);
            this.label239.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(28, 20);
            this.label239.TabIndex = 20;
            this.label239.Text = "6K";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(182, 240);
            this.label238.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(28, 20);
            this.label238.TabIndex = 19;
            this.label238.Text = "3K";
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(153, 240);
            this.label237.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(28, 20);
            this.label237.TabIndex = 18;
            this.label237.Text = "1K";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(120, 240);
            this.label236.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(36, 20);
            this.label236.TabIndex = 17;
            this.label236.Text = "600";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(87, 240);
            this.label235.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(36, 20);
            this.label235.TabIndex = 16;
            this.label235.Text = "310";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(54, 240);
            this.label234.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(36, 20);
            this.label234.TabIndex = 15;
            this.label234.Text = "170";
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(27, 240);
            this.label233.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(27, 20);
            this.label233.TabIndex = 14;
            this.label233.Text = "60";
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Location = new System.Drawing.Point(177, 51);
            this.label232.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(18, 20);
            this.label232.TabIndex = 13;
            this.label232.Text = "0";
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq9.Location = new System.Drawing.Point(308, 75);
            this.tbAudEq9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq9.Maximum = 100;
            this.tbAudEq9.Minimum = -100;
            this.tbAudEq9.Name = "tbAudEq9";
            this.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq9.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq9.TabIndex = 12;
            this.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq9.Scroll += new System.EventHandler(this.tbAudEq9_Scroll);
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq8.Location = new System.Drawing.Point(276, 75);
            this.tbAudEq8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq8.Maximum = 100;
            this.tbAudEq8.Minimum = -100;
            this.tbAudEq8.Name = "tbAudEq8";
            this.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq8.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq8.TabIndex = 11;
            this.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq8.Scroll += new System.EventHandler(this.tbAudEq8_Scroll);
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq7.Location = new System.Drawing.Point(243, 75);
            this.tbAudEq7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq7.Maximum = 100;
            this.tbAudEq7.Minimum = -100;
            this.tbAudEq7.Name = "tbAudEq7";
            this.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq7.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq7.TabIndex = 10;
            this.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq7.Scroll += new System.EventHandler(this.tbAudEq7_Scroll);
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq6.Location = new System.Drawing.Point(212, 75);
            this.tbAudEq6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq6.Maximum = 100;
            this.tbAudEq6.Minimum = -100;
            this.tbAudEq6.Name = "tbAudEq6";
            this.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq6.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq6.TabIndex = 9;
            this.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq6.Scroll += new System.EventHandler(this.tbAudEq6_Scroll);
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq5.Location = new System.Drawing.Point(180, 75);
            this.tbAudEq5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq5.Maximum = 100;
            this.tbAudEq5.Minimum = -100;
            this.tbAudEq5.Name = "tbAudEq5";
            this.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq5.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq5.TabIndex = 8;
            this.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq5.Scroll += new System.EventHandler(this.tbAudEq5_Scroll);
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq4.Location = new System.Drawing.Point(150, 75);
            this.tbAudEq4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq4.Maximum = 100;
            this.tbAudEq4.Minimum = -100;
            this.tbAudEq4.Name = "tbAudEq4";
            this.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq4.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq4.TabIndex = 7;
            this.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq4.Scroll += new System.EventHandler(this.tbAudEq4_Scroll);
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq3.Location = new System.Drawing.Point(118, 75);
            this.tbAudEq3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq3.Maximum = 100;
            this.tbAudEq3.Minimum = -100;
            this.tbAudEq3.Name = "tbAudEq3";
            this.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq3.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq3.TabIndex = 6;
            this.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq3.Scroll += new System.EventHandler(this.tbAudEq3_Scroll);
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq2.Location = new System.Drawing.Point(87, 75);
            this.tbAudEq2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq2.Maximum = 100;
            this.tbAudEq2.Minimum = -100;
            this.tbAudEq2.Name = "tbAudEq2";
            this.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq2.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq2.TabIndex = 5;
            this.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq2.Scroll += new System.EventHandler(this.tbAudEq2_Scroll);
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq1.Location = new System.Drawing.Point(56, 75);
            this.tbAudEq1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq1.Maximum = 100;
            this.tbAudEq1.Minimum = -100;
            this.tbAudEq1.Name = "tbAudEq1";
            this.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq1.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq1.TabIndex = 4;
            this.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq1.Scroll += new System.EventHandler(this.tbAudEq1_Scroll);
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq0.Location = new System.Drawing.Point(26, 75);
            this.tbAudEq0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq0.Maximum = 100;
            this.tbAudEq0.Minimum = -100;
            this.tbAudEq0.Name = "tbAudEq0";
            this.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq0.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq0.TabIndex = 3;
            this.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq0.Scroll += new System.EventHandler(this.tbAudEq0_Scroll);
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = true;
            this.cbAudEqualizerEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudEqualizerEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            this.cbAudEqualizerEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudEqualizerEnabled.TabIndex = 2;
            this.cbAudEqualizerEnabled.Text = "Enabled";
            this.cbAudEqualizerEnabled.UseVisualStyleBackColor = true;
            this.cbAudEqualizerEnabled.CheckedChanged += new System.EventHandler(this.cbAudEqualizerEnabled_CheckedChanged);
            // 
            // tabPage73
            // 
            this.tabPage73.Controls.Add(this.tbAudRelease);
            this.tabPage73.Controls.Add(this.label248);
            this.tabPage73.Controls.Add(this.label249);
            this.tabPage73.Controls.Add(this.label246);
            this.tabPage73.Controls.Add(this.tbAudAttack);
            this.tabPage73.Controls.Add(this.label247);
            this.tabPage73.Controls.Add(this.label244);
            this.tabPage73.Controls.Add(this.tbAudDynAmp);
            this.tabPage73.Controls.Add(this.label245);
            this.tabPage73.Controls.Add(this.cbAudDynamicAmplifyEnabled);
            this.tabPage73.Location = new System.Drawing.Point(4, 29);
            this.tabPage73.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage73.Name = "tabPage73";
            this.tabPage73.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage73.Size = new System.Drawing.Size(416, 647);
            this.tabPage73.TabIndex = 2;
            this.tabPage73.Text = "Dynamic amplify";
            this.tabPage73.UseVisualStyleBackColor = true;
            // 
            // tbAudRelease
            // 
            this.tbAudRelease.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudRelease.Location = new System.Drawing.Point(24, 322);
            this.tbAudRelease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudRelease.Maximum = 10000;
            this.tbAudRelease.Minimum = 10;
            this.tbAudRelease.Name = "tbAudRelease";
            this.tbAudRelease.Size = new System.Drawing.Size(345, 69);
            this.tbAudRelease.TabIndex = 15;
            this.tbAudRelease.TickFrequency = 250;
            this.tbAudRelease.Value = 10;
            this.tbAudRelease.Scroll += new System.EventHandler(this.tbAudRelease_Scroll);
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Location = new System.Drawing.Point(350, 297);
            this.label248.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(27, 20);
            this.label248.TabIndex = 14;
            this.label248.Text = "10";
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Location = new System.Drawing.Point(20, 297);
            this.label249.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(102, 20);
            this.label249.TabIndex = 12;
            this.label249.Text = "Release time";
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Location = new System.Drawing.Point(350, 186);
            this.label246.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(27, 20);
            this.label246.TabIndex = 11;
            this.label246.Text = "10";
            // 
            // tbAudAttack
            // 
            this.tbAudAttack.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAttack.Location = new System.Drawing.Point(24, 211);
            this.tbAudAttack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudAttack.Maximum = 10000;
            this.tbAudAttack.Minimum = 10;
            this.tbAudAttack.Name = "tbAudAttack";
            this.tbAudAttack.Size = new System.Drawing.Size(345, 69);
            this.tbAudAttack.TabIndex = 10;
            this.tbAudAttack.TickFrequency = 250;
            this.tbAudAttack.Value = 10;
            this.tbAudAttack.Scroll += new System.EventHandler(this.tbAudAttack_Scroll);
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Location = new System.Drawing.Point(20, 186);
            this.label247.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(55, 20);
            this.label247.TabIndex = 9;
            this.label247.Text = "Attack";
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Location = new System.Drawing.Point(350, 82);
            this.label244.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(45, 20);
            this.label244.TabIndex = 8;
            this.label244.Text = "1000";
            // 
            // tbAudDynAmp
            // 
            this.tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudDynAmp.Location = new System.Drawing.Point(24, 106);
            this.tbAudDynAmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudDynAmp.Maximum = 2000;
            this.tbAudDynAmp.Minimum = 100;
            this.tbAudDynAmp.Name = "tbAudDynAmp";
            this.tbAudDynAmp.Size = new System.Drawing.Size(345, 69);
            this.tbAudDynAmp.TabIndex = 7;
            this.tbAudDynAmp.TickFrequency = 50;
            this.tbAudDynAmp.Value = 1000;
            this.tbAudDynAmp.Scroll += new System.EventHandler(this.tbAudDynAmp_Scroll);
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Location = new System.Drawing.Point(20, 82);
            this.label245.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(168, 20);
            this.label245.TabIndex = 6;
            this.label245.Text = "Maximum amplification";
            // 
            // cbAudDynamicAmplifyEnabled
            // 
            this.cbAudDynamicAmplifyEnabled.AutoSize = true;
            this.cbAudDynamicAmplifyEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudDynamicAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled";
            this.cbAudDynamicAmplifyEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudDynamicAmplifyEnabled.TabIndex = 2;
            this.cbAudDynamicAmplifyEnabled.Text = "Enabled";
            this.cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = true;
            this.cbAudDynamicAmplifyEnabled.CheckedChanged += new System.EventHandler(this.cbAudDynamicAmplifyEnabled_CheckedChanged);
            // 
            // tabPage75
            // 
            this.tabPage75.Controls.Add(this.tbAud3DSound);
            this.tabPage75.Controls.Add(this.label253);
            this.tabPage75.Controls.Add(this.cbAudSound3DEnabled);
            this.tabPage75.Location = new System.Drawing.Point(4, 29);
            this.tabPage75.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage75.Name = "tabPage75";
            this.tabPage75.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage75.Size = new System.Drawing.Size(416, 647);
            this.tabPage75.TabIndex = 4;
            this.tabPage75.Text = "Sound 3D";
            this.tabPage75.UseVisualStyleBackColor = true;
            // 
            // tbAud3DSound
            // 
            this.tbAud3DSound.BackColor = System.Drawing.SystemColors.Window;
            this.tbAud3DSound.Location = new System.Drawing.Point(24, 106);
            this.tbAud3DSound.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAud3DSound.Maximum = 10000;
            this.tbAud3DSound.Name = "tbAud3DSound";
            this.tbAud3DSound.Size = new System.Drawing.Size(345, 69);
            this.tbAud3DSound.TabIndex = 19;
            this.tbAud3DSound.TickFrequency = 250;
            this.tbAud3DSound.Value = 500;
            this.tbAud3DSound.Scroll += new System.EventHandler(this.tbAud3DSound_Scroll);
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Location = new System.Drawing.Point(20, 82);
            this.label253.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(122, 20);
            this.label253.TabIndex = 18;
            this.label253.Text = "3D amplification";
            // 
            // cbAudSound3DEnabled
            // 
            this.cbAudSound3DEnabled.AutoSize = true;
            this.cbAudSound3DEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudSound3DEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudSound3DEnabled.Name = "cbAudSound3DEnabled";
            this.cbAudSound3DEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudSound3DEnabled.TabIndex = 2;
            this.cbAudSound3DEnabled.Text = "Enabled";
            this.cbAudSound3DEnabled.UseVisualStyleBackColor = true;
            this.cbAudSound3DEnabled.CheckedChanged += new System.EventHandler(this.cbAudSound3DEnabled_CheckedChanged);
            // 
            // tabPage76
            // 
            this.tabPage76.Controls.Add(this.tbAudTrueBass);
            this.tabPage76.Controls.Add(this.label254);
            this.tabPage76.Controls.Add(this.cbAudTrueBassEnabled);
            this.tabPage76.Location = new System.Drawing.Point(4, 29);
            this.tabPage76.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage76.Name = "tabPage76";
            this.tabPage76.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage76.Size = new System.Drawing.Size(416, 647);
            this.tabPage76.TabIndex = 5;
            this.tabPage76.Text = "True Bass";
            this.tabPage76.UseVisualStyleBackColor = true;
            // 
            // tbAudTrueBass
            // 
            this.tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudTrueBass.Location = new System.Drawing.Point(24, 106);
            this.tbAudTrueBass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudTrueBass.Maximum = 10000;
            this.tbAudTrueBass.Name = "tbAudTrueBass";
            this.tbAudTrueBass.Size = new System.Drawing.Size(345, 69);
            this.tbAudTrueBass.TabIndex = 21;
            this.tbAudTrueBass.TickFrequency = 250;
            this.tbAudTrueBass.Scroll += new System.EventHandler(this.tbAudTrueBass_Scroll);
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Location = new System.Drawing.Point(20, 82);
            this.label254.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(63, 20);
            this.label254.TabIndex = 20;
            this.label254.Text = "Volume";
            // 
            // cbAudTrueBassEnabled
            // 
            this.cbAudTrueBassEnabled.AutoSize = true;
            this.cbAudTrueBassEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudTrueBassEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled";
            this.cbAudTrueBassEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudTrueBassEnabled.TabIndex = 2;
            this.cbAudTrueBassEnabled.Text = "Enabled";
            this.cbAudTrueBassEnabled.UseVisualStyleBackColor = true;
            this.cbAudTrueBassEnabled.CheckedChanged += new System.EventHandler(this.cbAudTrueBassEnabled_CheckedChanged);
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.tbAudPitchShift);
            this.tabPage27.Controls.Add(this.label36);
            this.tabPage27.Controls.Add(this.cbAudPitchShiftEnabled);
            this.tabPage27.Location = new System.Drawing.Point(4, 29);
            this.tabPage27.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage27.Size = new System.Drawing.Size(416, 647);
            this.tabPage27.TabIndex = 7;
            this.tabPage27.Text = "Pitch shift";
            this.tabPage27.UseVisualStyleBackColor = true;
            // 
            // tbAudPitchShift
            // 
            this.tbAudPitchShift.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudPitchShift.Location = new System.Drawing.Point(24, 106);
            this.tbAudPitchShift.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudPitchShift.Maximum = 3000;
            this.tbAudPitchShift.Minimum = 100;
            this.tbAudPitchShift.Name = "tbAudPitchShift";
            this.tbAudPitchShift.Size = new System.Drawing.Size(345, 69);
            this.tbAudPitchShift.TabIndex = 26;
            this.tbAudPitchShift.TickFrequency = 20;
            this.tbAudPitchShift.Value = 1000;
            this.tbAudPitchShift.Scroll += new System.EventHandler(this.tbAudPitchShift_Scroll);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(20, 82);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 20);
            this.label36.TabIndex = 25;
            this.label36.Text = "Pitch";
            // 
            // cbAudPitchShiftEnabled
            // 
            this.cbAudPitchShiftEnabled.AutoSize = true;
            this.cbAudPitchShiftEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudPitchShiftEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudPitchShiftEnabled.Name = "cbAudPitchShiftEnabled";
            this.cbAudPitchShiftEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudPitchShiftEnabled.TabIndex = 24;
            this.cbAudPitchShiftEnabled.Text = "Enabled";
            this.cbAudPitchShiftEnabled.UseVisualStyleBackColor = true;
            this.cbAudPitchShiftEnabled.CheckedChanged += new System.EventHandler(this.cbAudPitchShiftEnabled_CheckedChanged);
            // 
            // cbAudioEffectsEnabled
            // 
            this.cbAudioEffectsEnabled.AutoSize = true;
            this.cbAudioEffectsEnabled.Location = new System.Drawing.Point(12, 12);
            this.cbAudioEffectsEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            this.cbAudioEffectsEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudioEffectsEnabled.TabIndex = 2;
            this.cbAudioEffectsEnabled.Text = "Enabled";
            this.cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage50
            // 
            this.tabPage50.Controls.Add(this.btAudioChannelMapperClear);
            this.tabPage50.Controls.Add(this.groupBox41);
            this.tabPage50.Controls.Add(this.label307);
            this.tabPage50.Controls.Add(this.edAudioChannelMapperOutputChannels);
            this.tabPage50.Controls.Add(this.label306);
            this.tabPage50.Controls.Add(this.lbAudioChannelMapperRoutes);
            this.tabPage50.Controls.Add(this.cbAudioChannelMapperEnabled);
            this.tabPage50.Location = new System.Drawing.Point(4, 29);
            this.tabPage50.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage50.Name = "tabPage50";
            this.tabPage50.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage50.Size = new System.Drawing.Size(456, 764);
            this.tabPage50.TabIndex = 13;
            this.tabPage50.Text = "Audio channel mapper";
            this.tabPage50.UseVisualStyleBackColor = true;
            // 
            // btAudioChannelMapperClear
            // 
            this.btAudioChannelMapperClear.Location = new System.Drawing.Point(306, 338);
            this.btAudioChannelMapperClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAudioChannelMapperClear.Name = "btAudioChannelMapperClear";
            this.btAudioChannelMapperClear.Size = new System.Drawing.Size(112, 35);
            this.btAudioChannelMapperClear.TabIndex = 21;
            this.btAudioChannelMapperClear.Text = "Clear";
            this.btAudioChannelMapperClear.UseVisualStyleBackColor = true;
            this.btAudioChannelMapperClear.Click += new System.EventHandler(this.btAudioChannelMapperClear_Click);
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.btAudioChannelMapperAddNewRoute);
            this.groupBox41.Controls.Add(this.label311);
            this.groupBox41.Controls.Add(this.tbAudioChannelMapperVolume);
            this.groupBox41.Controls.Add(this.label310);
            this.groupBox41.Controls.Add(this.edAudioChannelMapperTargetChannel);
            this.groupBox41.Controls.Add(this.label309);
            this.groupBox41.Controls.Add(this.edAudioChannelMapperSourceChannel);
            this.groupBox41.Controls.Add(this.label308);
            this.groupBox41.Location = new System.Drawing.Point(9, 383);
            this.groupBox41.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox41.Size = new System.Drawing.Size(430, 263);
            this.groupBox41.TabIndex = 20;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Add new route";
            // 
            // btAudioChannelMapperAddNewRoute
            // 
            this.btAudioChannelMapperAddNewRoute.Location = new System.Drawing.Point(162, 202);
            this.btAudioChannelMapperAddNewRoute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute";
            this.btAudioChannelMapperAddNewRoute.Size = new System.Drawing.Size(112, 35);
            this.btAudioChannelMapperAddNewRoute.TabIndex = 20;
            this.btAudioChannelMapperAddNewRoute.Text = "Add";
            this.btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = true;
            this.btAudioChannelMapperAddNewRoute.Click += new System.EventHandler(this.btAudioChannelMapperAddNewRoute_Click);
            // 
            // label311
            // 
            this.label311.AutoSize = true;
            this.label311.Location = new System.Drawing.Point(308, 137);
            this.label311.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label311.Name = "label311";
            this.label311.Size = new System.Drawing.Size(95, 20);
            this.label311.TabIndex = 19;
            this.label311.Text = "10% - 200%";
            // 
            // tbAudioChannelMapperVolume
            // 
            this.tbAudioChannelMapperVolume.Location = new System.Drawing.Point(312, 63);
            this.tbAudioChannelMapperVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudioChannelMapperVolume.Maximum = 2000;
            this.tbAudioChannelMapperVolume.Minimum = 100;
            this.tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume";
            this.tbAudioChannelMapperVolume.Size = new System.Drawing.Size(111, 69);
            this.tbAudioChannelMapperVolume.TabIndex = 18;
            this.tbAudioChannelMapperVolume.Value = 1000;
            // 
            // label310
            // 
            this.label310.AutoSize = true;
            this.label310.Location = new System.Drawing.Point(308, 38);
            this.label310.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label310.Name = "label310";
            this.label310.Size = new System.Drawing.Size(63, 20);
            this.label310.TabIndex = 17;
            this.label310.Text = "Volume";
            // 
            // edAudioChannelMapperTargetChannel
            // 
            this.edAudioChannelMapperTargetChannel.Location = new System.Drawing.Point(162, 63);
            this.edAudioChannelMapperTargetChannel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel";
            this.edAudioChannelMapperTargetChannel.Size = new System.Drawing.Size(74, 26);
            this.edAudioChannelMapperTargetChannel.TabIndex = 16;
            this.edAudioChannelMapperTargetChannel.Text = "0";
            // 
            // label309
            // 
            this.label309.AutoSize = true;
            this.label309.Location = new System.Drawing.Point(158, 38);
            this.label309.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label309.Name = "label309";
            this.label309.Size = new System.Drawing.Size(115, 20);
            this.label309.TabIndex = 15;
            this.label309.Text = "Target channel";
            // 
            // edAudioChannelMapperSourceChannel
            // 
            this.edAudioChannelMapperSourceChannel.Location = new System.Drawing.Point(22, 63);
            this.edAudioChannelMapperSourceChannel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel";
            this.edAudioChannelMapperSourceChannel.Size = new System.Drawing.Size(74, 26);
            this.edAudioChannelMapperSourceChannel.TabIndex = 14;
            this.edAudioChannelMapperSourceChannel.Text = "0";
            // 
            // label308
            // 
            this.label308.AutoSize = true;
            this.label308.Location = new System.Drawing.Point(18, 38);
            this.label308.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label308.Name = "label308";
            this.label308.Size = new System.Drawing.Size(120, 20);
            this.label308.TabIndex = 13;
            this.label308.Text = "Source channel";
            // 
            // label307
            // 
            this.label307.AutoSize = true;
            this.label307.Location = new System.Drawing.Point(14, 155);
            this.label307.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label307.Name = "label307";
            this.label307.Size = new System.Drawing.Size(61, 20);
            this.label307.TabIndex = 19;
            this.label307.Text = "Routes";
            // 
            // edAudioChannelMapperOutputChannels
            // 
            this.edAudioChannelMapperOutputChannels.Location = new System.Drawing.Point(18, 95);
            this.edAudioChannelMapperOutputChannels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels";
            this.edAudioChannelMapperOutputChannels.Size = new System.Drawing.Size(61, 26);
            this.edAudioChannelMapperOutputChannels.TabIndex = 18;
            this.edAudioChannelMapperOutputChannels.Text = "0";
            // 
            // label306
            // 
            this.label306.AutoSize = true;
            this.label306.Location = new System.Drawing.Point(14, 71);
            this.label306.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label306.Name = "label306";
            this.label306.Size = new System.Drawing.Size(407, 20);
            this.label306.TabIndex = 17;
            this.label306.Text = "Output channels count (0 to use original channels count)";
            // 
            // lbAudioChannelMapperRoutes
            // 
            this.lbAudioChannelMapperRoutes.FormattingEnabled = true;
            this.lbAudioChannelMapperRoutes.ItemHeight = 20;
            this.lbAudioChannelMapperRoutes.Location = new System.Drawing.Point(18, 183);
            this.lbAudioChannelMapperRoutes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes";
            this.lbAudioChannelMapperRoutes.Size = new System.Drawing.Size(398, 144);
            this.lbAudioChannelMapperRoutes.TabIndex = 16;
            // 
            // cbAudioChannelMapperEnabled
            // 
            this.cbAudioChannelMapperEnabled.AutoSize = true;
            this.cbAudioChannelMapperEnabled.Location = new System.Drawing.Point(18, 18);
            this.cbAudioChannelMapperEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled";
            this.cbAudioChannelMapperEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudioChannelMapperEnabled.TabIndex = 15;
            this.cbAudioChannelMapperEnabled.Text = "Enabled";
            this.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage28
            // 
            this.tabPage28.Controls.Add(this.tbVUMeterBoost);
            this.tabPage28.Controls.Add(this.label382);
            this.tabPage28.Controls.Add(this.label381);
            this.tabPage28.Controls.Add(this.tbVUMeterAmplification);
            this.tabPage28.Controls.Add(this.cbVUMeterPro);
            this.tabPage28.Controls.Add(this.waveformPainter2);
            this.tabPage28.Controls.Add(this.waveformPainter1);
            this.tabPage28.Controls.Add(this.volumeMeter2);
            this.tabPage28.Controls.Add(this.volumeMeter1);
            this.tabPage28.Location = new System.Drawing.Point(4, 29);
            this.tabPage28.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage28.Size = new System.Drawing.Size(456, 764);
            this.tabPage28.TabIndex = 11;
            this.tabPage28.Text = "VU meter";
            this.tabPage28.UseVisualStyleBackColor = true;
            // 
            // tbVUMeterBoost
            // 
            this.tbVUMeterBoost.Location = new System.Drawing.Point(186, 214);
            this.tbVUMeterBoost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVUMeterBoost.Maximum = 30;
            this.tbVUMeterBoost.Minimum = 1;
            this.tbVUMeterBoost.Name = "tbVUMeterBoost";
            this.tbVUMeterBoost.Size = new System.Drawing.Size(156, 69);
            this.tbVUMeterBoost.TabIndex = 122;
            this.tbVUMeterBoost.Value = 10;
            this.tbVUMeterBoost.Scroll += new System.EventHandler(this.tbVUMeterBoost_Scroll);
            // 
            // label382
            // 
            this.label382.AutoSize = true;
            this.label382.Location = new System.Drawing.Point(182, 189);
            this.label382.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label382.Name = "label382";
            this.label382.Size = new System.Drawing.Size(102, 20);
            this.label382.TabIndex = 121;
            this.label382.Text = "Meters boost";
            // 
            // label381
            // 
            this.label381.AutoSize = true;
            this.label381.Location = new System.Drawing.Point(182, 89);
            this.label381.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label381.Name = "label381";
            this.label381.Size = new System.Drawing.Size(183, 20);
            this.label381.TabIndex = 120;
            this.label381.Text = "Volume amplification (%)";
            // 
            // tbVUMeterAmplification
            // 
            this.tbVUMeterAmplification.Location = new System.Drawing.Point(186, 114);
            this.tbVUMeterAmplification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVUMeterAmplification.Maximum = 100;
            this.tbVUMeterAmplification.Name = "tbVUMeterAmplification";
            this.tbVUMeterAmplification.Size = new System.Drawing.Size(158, 69);
            this.tbVUMeterAmplification.TabIndex = 119;
            this.tbVUMeterAmplification.Value = 100;
            this.tbVUMeterAmplification.Scroll += new System.EventHandler(this.tbVUMeterAmplification_Scroll);
            // 
            // cbVUMeterPro
            // 
            this.cbVUMeterPro.AutoSize = true;
            this.cbVUMeterPro.Location = new System.Drawing.Point(33, 37);
            this.cbVUMeterPro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVUMeterPro.Name = "cbVUMeterPro";
            this.cbVUMeterPro.Size = new System.Drawing.Size(185, 24);
            this.cbVUMeterPro.TabIndex = 115;
            this.cbVUMeterPro.Text = "Enable VU meter Pro";
            this.cbVUMeterPro.UseVisualStyleBackColor = true;
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Boost = 1F;
            this.waveformPainter2.Location = new System.Drawing.Point(22, 394);
            this.waveformPainter2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waveformPainter2.Name = "waveformPainter2";
            this.waveformPainter2.Size = new System.Drawing.Size(405, 92);
            this.waveformPainter2.TabIndex = 118;
            this.waveformPainter2.Text = "waveformPainter2";
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Boost = 1F;
            this.waveformPainter1.Location = new System.Drawing.Point(22, 292);
            this.waveformPainter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(405, 92);
            this.waveformPainter1.TabIndex = 117;
            this.waveformPainter1.Text = "waveformPainter1";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.BackColor = System.Drawing.Color.LightGray;
            this.volumeMeter2.Boost = 1F;
            this.volumeMeter2.Location = new System.Drawing.Point(90, 89);
            this.volumeMeter2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.volumeMeter2.MaxDb = 18F;
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Size = new System.Drawing.Size(33, 194);
            this.volumeMeter2.TabIndex = 116;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.BackColor = System.Drawing.Color.LightGray;
            this.volumeMeter1.Boost = 1F;
            this.volumeMeter1.Location = new System.Drawing.Point(48, 89);
            this.volumeMeter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Size = new System.Drawing.Size(33, 194);
            this.volumeMeter1.TabIndex = 114;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btOSDRenderLayers);
            this.tabPage5.Controls.Add(this.lbOSDLayers);
            this.tabPage5.Controls.Add(this.cbOSDEnabled);
            this.tabPage5.Controls.Add(this.groupBox19);
            this.tabPage5.Controls.Add(this.btOSDClearLayers);
            this.tabPage5.Controls.Add(this.groupBox15);
            this.tabPage5.Controls.Add(this.label108);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Size = new System.Drawing.Size(456, 764);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "OSD";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btOSDRenderLayers
            // 
            this.btOSDRenderLayers.Location = new System.Drawing.Point(242, 318);
            this.btOSDRenderLayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDRenderLayers.Name = "btOSDRenderLayers";
            this.btOSDRenderLayers.Size = new System.Drawing.Size(188, 35);
            this.btOSDRenderLayers.TabIndex = 16;
            this.btOSDRenderLayers.Text = "Render layers";
            this.btOSDRenderLayers.UseVisualStyleBackColor = true;
            this.btOSDRenderLayers.Click += new System.EventHandler(this.btOSDRenderLayers_Click);
            // 
            // lbOSDLayers
            // 
            this.lbOSDLayers.CheckOnClick = true;
            this.lbOSDLayers.FormattingEnabled = true;
            this.lbOSDLayers.Location = new System.Drawing.Point(24, 105);
            this.lbOSDLayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbOSDLayers.Name = "lbOSDLayers";
            this.lbOSDLayers.Size = new System.Drawing.Size(206, 165);
            this.lbOSDLayers.TabIndex = 15;
            this.lbOSDLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbOSDLayers_ItemCheck);
            // 
            // cbOSDEnabled
            // 
            this.cbOSDEnabled.AutoSize = true;
            this.cbOSDEnabled.Location = new System.Drawing.Point(24, 23);
            this.cbOSDEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOSDEnabled.Name = "cbOSDEnabled";
            this.cbOSDEnabled.Size = new System.Drawing.Size(373, 24);
            this.cbOSDEnabled.TabIndex = 14;
            this.cbOSDEnabled.Text = "Enabled (should be set before playback started)";
            this.cbOSDEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btOSDClearLayer);
            this.groupBox19.Controls.Add(this.tabControl6);
            this.groupBox19.Location = new System.Drawing.Point(22, 363);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox19.Size = new System.Drawing.Size(405, 385);
            this.groupBox19.TabIndex = 13;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Selected layer";
            // 
            // btOSDClearLayer
            // 
            this.btOSDClearLayer.Location = new System.Drawing.Point(16, 340);
            this.btOSDClearLayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDClearLayer.Name = "btOSDClearLayer";
            this.btOSDClearLayer.Size = new System.Drawing.Size(136, 35);
            this.btOSDClearLayer.TabIndex = 2;
            this.btOSDClearLayer.Text = "Clear layer";
            this.btOSDClearLayer.UseVisualStyleBackColor = true;
            this.btOSDClearLayer.Click += new System.EventHandler(this.btOSDClearLayer_Click);
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage30);
            this.tabControl6.Controls.Add(this.tabPage31);
            this.tabControl6.Controls.Add(this.tabPage32);
            this.tabControl6.Location = new System.Drawing.Point(16, 29);
            this.tabControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(375, 302);
            this.tabControl6.TabIndex = 0;
            // 
            // tabPage30
            // 
            this.tabPage30.Controls.Add(this.btOSDImageDraw);
            this.tabPage30.Controls.Add(this.pnOSDColorKey);
            this.tabPage30.Controls.Add(this.cbOSDImageTranspColor);
            this.tabPage30.Controls.Add(this.edOSDImageTop);
            this.tabPage30.Controls.Add(this.label115);
            this.tabPage30.Controls.Add(this.edOSDImageLeft);
            this.tabPage30.Controls.Add(this.label114);
            this.tabPage30.Controls.Add(this.btOSDSelectImage);
            this.tabPage30.Controls.Add(this.edOSDImageFilename);
            this.tabPage30.Controls.Add(this.label113);
            this.tabPage30.Location = new System.Drawing.Point(4, 29);
            this.tabPage30.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage30.Size = new System.Drawing.Size(367, 269);
            this.tabPage30.TabIndex = 1;
            this.tabPage30.Text = "Image";
            this.tabPage30.UseVisualStyleBackColor = true;
            // 
            // btOSDImageDraw
            // 
            this.btOSDImageDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDImageDraw.Location = new System.Drawing.Point(267, 217);
            this.btOSDImageDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDImageDraw.Name = "btOSDImageDraw";
            this.btOSDImageDraw.Size = new System.Drawing.Size(86, 35);
            this.btOSDImageDraw.TabIndex = 47;
            this.btOSDImageDraw.Text = "Draw";
            this.btOSDImageDraw.UseVisualStyleBackColor = true;
            this.btOSDImageDraw.Click += new System.EventHandler(this.btOSDImageDraw_Click);
            // 
            // pnOSDColorKey
            // 
            this.pnOSDColorKey.BackColor = System.Drawing.Color.Fuchsia;
            this.pnOSDColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnOSDColorKey.Location = new System.Drawing.Point(242, 157);
            this.pnOSDColorKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnOSDColorKey.Name = "pnOSDColorKey";
            this.pnOSDColorKey.Size = new System.Drawing.Size(35, 36);
            this.pnOSDColorKey.TabIndex = 45;
            this.pnOSDColorKey.Click += new System.EventHandler(this.pnOSDColorKey_Click);
            // 
            // cbOSDImageTranspColor
            // 
            this.cbOSDImageTranspColor.AutoSize = true;
            this.cbOSDImageTranspColor.Location = new System.Drawing.Point(22, 157);
            this.cbOSDImageTranspColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOSDImageTranspColor.Name = "cbOSDImageTranspColor";
            this.cbOSDImageTranspColor.Size = new System.Drawing.Size(198, 24);
            this.cbOSDImageTranspColor.TabIndex = 7;
            this.cbOSDImageTranspColor.Text = "Use transparency color";
            this.cbOSDImageTranspColor.UseVisualStyleBackColor = true;
            // 
            // edOSDImageTop
            // 
            this.edOSDImageTop.Location = new System.Drawing.Point(198, 103);
            this.edOSDImageTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDImageTop.Name = "edOSDImageTop";
            this.edOSDImageTop.Size = new System.Drawing.Size(55, 26);
            this.edOSDImageTop.TabIndex = 6;
            this.edOSDImageTop.Text = "0";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(152, 108);
            this.label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(36, 20);
            this.label115.TabIndex = 5;
            this.label115.Text = "Top";
            // 
            // edOSDImageLeft
            // 
            this.edOSDImageLeft.Location = new System.Drawing.Point(74, 103);
            this.edOSDImageLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDImageLeft.Name = "edOSDImageLeft";
            this.edOSDImageLeft.Size = new System.Drawing.Size(55, 26);
            this.edOSDImageLeft.TabIndex = 4;
            this.edOSDImageLeft.Text = "0";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(18, 108);
            this.label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(37, 20);
            this.label114.TabIndex = 3;
            this.label114.Text = "Left";
            // 
            // btOSDSelectImage
            // 
            this.btOSDSelectImage.Location = new System.Drawing.Point(320, 46);
            this.btOSDSelectImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDSelectImage.Name = "btOSDSelectImage";
            this.btOSDSelectImage.Size = new System.Drawing.Size(33, 35);
            this.btOSDSelectImage.TabIndex = 2;
            this.btOSDSelectImage.Text = "...";
            this.btOSDSelectImage.UseVisualStyleBackColor = true;
            this.btOSDSelectImage.Click += new System.EventHandler(this.btOSDSelectImage_Click);
            // 
            // edOSDImageFilename
            // 
            this.edOSDImageFilename.Location = new System.Drawing.Point(22, 49);
            this.edOSDImageFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDImageFilename.Name = "edOSDImageFilename";
            this.edOSDImageFilename.Size = new System.Drawing.Size(286, 26);
            this.edOSDImageFilename.TabIndex = 1;
            this.edOSDImageFilename.Text = "c:\\logo.png";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(18, 25);
            this.label113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(78, 20);
            this.label113.TabIndex = 0;
            this.label113.Text = "File name";
            // 
            // tabPage31
            // 
            this.tabPage31.Controls.Add(this.edOSDTextTop);
            this.tabPage31.Controls.Add(this.label117);
            this.tabPage31.Controls.Add(this.edOSDTextLeft);
            this.tabPage31.Controls.Add(this.label118);
            this.tabPage31.Controls.Add(this.label116);
            this.tabPage31.Controls.Add(this.btOSDSelectFont);
            this.tabPage31.Controls.Add(this.edOSDText);
            this.tabPage31.Controls.Add(this.btOSDTextDraw);
            this.tabPage31.Location = new System.Drawing.Point(4, 29);
            this.tabPage31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage31.Size = new System.Drawing.Size(367, 269);
            this.tabPage31.TabIndex = 2;
            this.tabPage31.Text = "Text";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // edOSDTextTop
            // 
            this.edOSDTextTop.Location = new System.Drawing.Point(198, 103);
            this.edOSDTextTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDTextTop.Name = "edOSDTextTop";
            this.edOSDTextTop.Size = new System.Drawing.Size(55, 26);
            this.edOSDTextTop.TabIndex = 55;
            this.edOSDTextTop.Text = "0";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(152, 108);
            this.label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(36, 20);
            this.label117.TabIndex = 54;
            this.label117.Text = "Top";
            // 
            // edOSDTextLeft
            // 
            this.edOSDTextLeft.Location = new System.Drawing.Point(74, 103);
            this.edOSDTextLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDTextLeft.Name = "edOSDTextLeft";
            this.edOSDTextLeft.Size = new System.Drawing.Size(55, 26);
            this.edOSDTextLeft.TabIndex = 53;
            this.edOSDTextLeft.Text = "0";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(18, 108);
            this.label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(37, 20);
            this.label118.TabIndex = 52;
            this.label118.Text = "Left";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(18, 25);
            this.label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(39, 20);
            this.label116.TabIndex = 51;
            this.label116.Text = "Text";
            // 
            // btOSDSelectFont
            // 
            this.btOSDSelectFont.Location = new System.Drawing.Point(297, 46);
            this.btOSDSelectFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDSelectFont.Name = "btOSDSelectFont";
            this.btOSDSelectFont.Size = new System.Drawing.Size(56, 35);
            this.btOSDSelectFont.TabIndex = 50;
            this.btOSDSelectFont.Text = "Font";
            this.btOSDSelectFont.UseVisualStyleBackColor = true;
            this.btOSDSelectFont.Click += new System.EventHandler(this.btOSDSelectFont_Click);
            // 
            // edOSDText
            // 
            this.edOSDText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.edOSDText.Location = new System.Drawing.Point(22, 49);
            this.edOSDText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDText.Name = "edOSDText";
            this.edOSDText.Size = new System.Drawing.Size(268, 26);
            this.edOSDText.TabIndex = 49;
            this.edOSDText.Text = "Hello!!!";
            // 
            // btOSDTextDraw
            // 
            this.btOSDTextDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDTextDraw.Location = new System.Drawing.Point(267, 217);
            this.btOSDTextDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDTextDraw.Name = "btOSDTextDraw";
            this.btOSDTextDraw.Size = new System.Drawing.Size(86, 35);
            this.btOSDTextDraw.TabIndex = 48;
            this.btOSDTextDraw.Text = "Draw";
            this.btOSDTextDraw.UseVisualStyleBackColor = true;
            this.btOSDTextDraw.Click += new System.EventHandler(this.btOSDTextDraw_Click);
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.tbOSDTranspLevel);
            this.tabPage32.Controls.Add(this.btOSDSetTransp);
            this.tabPage32.Controls.Add(this.label119);
            this.tabPage32.Location = new System.Drawing.Point(4, 29);
            this.tabPage32.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage32.Size = new System.Drawing.Size(367, 269);
            this.tabPage32.TabIndex = 3;
            this.tabPage32.Text = "Other";
            this.tabPage32.UseVisualStyleBackColor = true;
            // 
            // tbOSDTranspLevel
            // 
            this.tbOSDTranspLevel.BackColor = System.Drawing.SystemColors.Window;
            this.tbOSDTranspLevel.Location = new System.Drawing.Point(22, 49);
            this.tbOSDTranspLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOSDTranspLevel.Maximum = 255;
            this.tbOSDTranspLevel.Name = "tbOSDTranspLevel";
            this.tbOSDTranspLevel.Size = new System.Drawing.Size(214, 69);
            this.tbOSDTranspLevel.TabIndex = 3;
            this.tbOSDTranspLevel.TickFrequency = 10;
            // 
            // btOSDSetTransp
            // 
            this.btOSDSetTransp.Location = new System.Drawing.Point(267, 63);
            this.btOSDSetTransp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDSetTransp.Name = "btOSDSetTransp";
            this.btOSDSetTransp.Size = new System.Drawing.Size(72, 35);
            this.btOSDSetTransp.TabIndex = 2;
            this.btOSDSetTransp.Text = "Set";
            this.btOSDSetTransp.UseVisualStyleBackColor = true;
            this.btOSDSetTransp.Click += new System.EventHandler(this.btOSDSetTransp_Click);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(18, 25);
            this.label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(140, 20);
            this.label119.TabIndex = 0;
            this.label119.Text = "Transparency level";
            // 
            // btOSDClearLayers
            // 
            this.btOSDClearLayers.Location = new System.Drawing.Point(24, 318);
            this.btOSDClearLayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDClearLayers.Name = "btOSDClearLayers";
            this.btOSDClearLayers.Size = new System.Drawing.Size(210, 35);
            this.btOSDClearLayers.TabIndex = 12;
            this.btOSDClearLayers.Text = "Remove all layers";
            this.btOSDClearLayers.UseVisualStyleBackColor = true;
            this.btOSDClearLayers.Click += new System.EventHandler(this.btOSDClearLayers_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btOSDLayerAdd);
            this.groupBox15.Controls.Add(this.edOSDLayerHeight);
            this.groupBox15.Controls.Add(this.label111);
            this.groupBox15.Controls.Add(this.edOSDLayerWidth);
            this.groupBox15.Controls.Add(this.label112);
            this.groupBox15.Controls.Add(this.edOSDLayerTop);
            this.groupBox15.Controls.Add(this.label110);
            this.groupBox15.Controls.Add(this.edOSDLayerLeft);
            this.groupBox15.Controls.Add(this.label109);
            this.groupBox15.Location = new System.Drawing.Point(242, 94);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox15.Size = new System.Drawing.Size(188, 206);
            this.groupBox15.TabIndex = 11;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "New layer";
            // 
            // btOSDLayerAdd
            // 
            this.btOSDLayerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDLayerAdd.Location = new System.Drawing.Point(46, 165);
            this.btOSDLayerAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOSDLayerAdd.Name = "btOSDLayerAdd";
            this.btOSDLayerAdd.Size = new System.Drawing.Size(84, 35);
            this.btOSDLayerAdd.TabIndex = 8;
            this.btOSDLayerAdd.Text = "Create";
            this.btOSDLayerAdd.UseVisualStyleBackColor = true;
            this.btOSDLayerAdd.Click += new System.EventHandler(this.btOSDLayerAdd_Click);
            // 
            // edOSDLayerHeight
            // 
            this.edOSDLayerHeight.Location = new System.Drawing.Point(110, 125);
            this.edOSDLayerHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDLayerHeight.Name = "edOSDLayerHeight";
            this.edOSDLayerHeight.Size = new System.Drawing.Size(55, 26);
            this.edOSDLayerHeight.TabIndex = 7;
            this.edOSDLayerHeight.Text = "200";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(105, 100);
            this.label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(56, 20);
            this.label111.TabIndex = 6;
            this.label111.Text = "Height";
            // 
            // edOSDLayerWidth
            // 
            this.edOSDLayerWidth.Location = new System.Drawing.Point(20, 125);
            this.edOSDLayerWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDLayerWidth.Name = "edOSDLayerWidth";
            this.edOSDLayerWidth.Size = new System.Drawing.Size(55, 26);
            this.edOSDLayerWidth.TabIndex = 5;
            this.edOSDLayerWidth.Text = "200";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(15, 100);
            this.label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(50, 20);
            this.label112.TabIndex = 4;
            this.label112.Text = "Width";
            // 
            // edOSDLayerTop
            // 
            this.edOSDLayerTop.Location = new System.Drawing.Point(110, 65);
            this.edOSDLayerTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDLayerTop.Name = "edOSDLayerTop";
            this.edOSDLayerTop.Size = new System.Drawing.Size(55, 26);
            this.edOSDLayerTop.TabIndex = 3;
            this.edOSDLayerTop.Text = "0";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(105, 40);
            this.label110.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(36, 20);
            this.label110.TabIndex = 2;
            this.label110.Text = "Top";
            // 
            // edOSDLayerLeft
            // 
            this.edOSDLayerLeft.Location = new System.Drawing.Point(20, 65);
            this.edOSDLayerLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOSDLayerLeft.Name = "edOSDLayerLeft";
            this.edOSDLayerLeft.Size = new System.Drawing.Size(55, 26);
            this.edOSDLayerLeft.TabIndex = 1;
            this.edOSDLayerLeft.Text = "0";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(15, 40);
            this.label109.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(37, 20);
            this.label109.TabIndex = 0;
            this.label109.Text = "Left";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(18, 78);
            this.label108.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(56, 20);
            this.label108.TabIndex = 9;
            this.label108.Text = "Layers";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.tabControl5);
            this.tabPage12.Location = new System.Drawing.Point(4, 29);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage12.Size = new System.Drawing.Size(456, 764);
            this.tabPage12.TabIndex = 6;
            this.tabPage12.Text = "Decoders / Splitter";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage33);
            this.tabControl5.Controls.Add(this.tabPage34);
            this.tabControl5.Controls.Add(this.tabPage47);
            this.tabControl5.Location = new System.Drawing.Point(9, 9);
            this.tabControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(438, 738);
            this.tabControl5.TabIndex = 0;
            // 
            // tabPage33
            // 
            this.tabPage33.Controls.Add(this.cbCustomSplitter);
            this.tabPage33.Controls.Add(this.rbSplitterCustom);
            this.tabPage33.Controls.Add(this.rbSplitterDefault);
            this.tabPage33.Location = new System.Drawing.Point(4, 29);
            this.tabPage33.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage33.Name = "tabPage33";
            this.tabPage33.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage33.Size = new System.Drawing.Size(430, 705);
            this.tabPage33.TabIndex = 0;
            this.tabPage33.Text = "Splitter";
            this.tabPage33.UseVisualStyleBackColor = true;
            // 
            // cbCustomSplitter
            // 
            this.cbCustomSplitter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomSplitter.FormattingEnabled = true;
            this.cbCustomSplitter.Location = new System.Drawing.Point(54, 102);
            this.cbCustomSplitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCustomSplitter.Name = "cbCustomSplitter";
            this.cbCustomSplitter.Size = new System.Drawing.Size(349, 28);
            this.cbCustomSplitter.Sorted = true;
            this.cbCustomSplitter.TabIndex = 27;
            // 
            // rbSplitterCustom
            // 
            this.rbSplitterCustom.AutoSize = true;
            this.rbSplitterCustom.Location = new System.Drawing.Point(24, 65);
            this.rbSplitterCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSplitterCustom.Name = "rbSplitterCustom";
            this.rbSplitterCustom.Size = new System.Drawing.Size(89, 24);
            this.rbSplitterCustom.TabIndex = 1;
            this.rbSplitterCustom.Text = "Custom";
            this.rbSplitterCustom.UseVisualStyleBackColor = true;
            // 
            // rbSplitterDefault
            // 
            this.rbSplitterDefault.AutoSize = true;
            this.rbSplitterDefault.Checked = true;
            this.rbSplitterDefault.Location = new System.Drawing.Point(24, 23);
            this.rbSplitterDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSplitterDefault.Name = "rbSplitterDefault";
            this.rbSplitterDefault.Size = new System.Drawing.Size(86, 24);
            this.rbSplitterDefault.TabIndex = 0;
            this.rbSplitterDefault.TabStop = true;
            this.rbSplitterDefault.Text = "Default";
            this.rbSplitterDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage34
            // 
            this.tabPage34.Controls.Add(this.rbVideoDecoderVFH264);
            this.tabPage34.Controls.Add(this.cbCustomVideoDecoder);
            this.tabPage34.Controls.Add(this.label28);
            this.tabPage34.Controls.Add(this.label27);
            this.tabPage34.Controls.Add(this.label26);
            this.tabPage34.Controls.Add(this.rbVideoDecoderCustom);
            this.tabPage34.Controls.Add(this.rbVideoDecoderFFDShow);
            this.tabPage34.Controls.Add(this.rbVideoDecoderMS);
            this.tabPage34.Controls.Add(this.rbVideoDecoderDefault);
            this.tabPage34.Location = new System.Drawing.Point(4, 29);
            this.tabPage34.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage34.Name = "tabPage34";
            this.tabPage34.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage34.Size = new System.Drawing.Size(430, 705);
            this.tabPage34.TabIndex = 1;
            this.tabPage34.Text = "Video decoder";
            this.tabPage34.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderVFH264
            // 
            this.rbVideoDecoderVFH264.AutoSize = true;
            this.rbVideoDecoderVFH264.Location = new System.Drawing.Point(24, 308);
            this.rbVideoDecoderVFH264.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoDecoderVFH264.Name = "rbVideoDecoderVFH264";
            this.rbVideoDecoderVFH264.Size = new System.Drawing.Size(218, 24);
            this.rbVideoDecoderVFH264.TabIndex = 26;
            this.rbVideoDecoderVFH264.TabStop = true;
            this.rbVideoDecoderVFH264.Text = "VisioForge H264 Decoder";
            this.rbVideoDecoderVFH264.UseVisualStyleBackColor = true;
            // 
            // cbCustomVideoDecoder
            // 
            this.cbCustomVideoDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoDecoder.FormattingEnabled = true;
            this.cbCustomVideoDecoder.Location = new System.Drawing.Point(56, 397);
            this.cbCustomVideoDecoder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCustomVideoDecoder.Name = "cbCustomVideoDecoder";
            this.cbCustomVideoDecoder.Size = new System.Drawing.Size(348, 28);
            this.cbCustomVideoDecoder.Sorted = true;
            this.cbCustomVideoDecoder.TabIndex = 25;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(51, 260);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(141, 20);
            this.label28.TabIndex = 24;
            this.label28.Text = "and DVD playback";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(51, 225);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(359, 20);
            this.label27.TabIndex = 23;
            this.label27.Text = "To play DVD you must activate MPEG-2 decoding";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(51, 123);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(287, 20);
            this.label26.TabIndex = 22;
            this.label26.Text = "Available on Vista / 7 Premium and later";
            // 
            // rbVideoDecoderCustom
            // 
            this.rbVideoDecoderCustom.AutoSize = true;
            this.rbVideoDecoderCustom.Location = new System.Drawing.Point(24, 362);
            this.rbVideoDecoderCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoDecoderCustom.Name = "rbVideoDecoderCustom";
            this.rbVideoDecoderCustom.Size = new System.Drawing.Size(89, 24);
            this.rbVideoDecoderCustom.TabIndex = 21;
            this.rbVideoDecoderCustom.Text = "Custom";
            this.rbVideoDecoderCustom.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderFFDShow
            // 
            this.rbVideoDecoderFFDShow.AutoSize = true;
            this.rbVideoDecoderFFDShow.Location = new System.Drawing.Point(24, 178);
            this.rbVideoDecoderFFDShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoDecoderFFDShow.Name = "rbVideoDecoderFFDShow";
            this.rbVideoDecoderFFDShow.Size = new System.Drawing.Size(106, 24);
            this.rbVideoDecoderFFDShow.TabIndex = 20;
            this.rbVideoDecoderFFDShow.Text = "FFDShow";
            this.rbVideoDecoderFFDShow.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderMS
            // 
            this.rbVideoDecoderMS.AutoSize = true;
            this.rbVideoDecoderMS.Location = new System.Drawing.Point(24, 78);
            this.rbVideoDecoderMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoDecoderMS.Name = "rbVideoDecoderMS";
            this.rbVideoDecoderMS.Size = new System.Drawing.Size(284, 24);
            this.rbVideoDecoderMS.TabIndex = 19;
            this.rbVideoDecoderMS.Text = "Microsoft DTV/DVD Video Decoder";
            this.rbVideoDecoderMS.UseVisualStyleBackColor = true;
            // 
            // rbVideoDecoderDefault
            // 
            this.rbVideoDecoderDefault.AutoSize = true;
            this.rbVideoDecoderDefault.Checked = true;
            this.rbVideoDecoderDefault.Location = new System.Drawing.Point(24, 23);
            this.rbVideoDecoderDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoDecoderDefault.Name = "rbVideoDecoderDefault";
            this.rbVideoDecoderDefault.Size = new System.Drawing.Size(86, 24);
            this.rbVideoDecoderDefault.TabIndex = 18;
            this.rbVideoDecoderDefault.TabStop = true;
            this.rbVideoDecoderDefault.Text = "Default";
            this.rbVideoDecoderDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage47
            // 
            this.tabPage47.Controls.Add(this.cbCustomAudioDecoder);
            this.tabPage47.Controls.Add(this.rbAudioDecoderCustom);
            this.tabPage47.Controls.Add(this.rbAudioDecoderDefault);
            this.tabPage47.Location = new System.Drawing.Point(4, 29);
            this.tabPage47.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage47.Name = "tabPage47";
            this.tabPage47.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage47.Size = new System.Drawing.Size(430, 705);
            this.tabPage47.TabIndex = 2;
            this.tabPage47.Text = "Audio decoder";
            this.tabPage47.UseVisualStyleBackColor = true;
            // 
            // cbCustomAudioDecoder
            // 
            this.cbCustomAudioDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomAudioDecoder.FormattingEnabled = true;
            this.cbCustomAudioDecoder.Location = new System.Drawing.Point(56, 102);
            this.cbCustomAudioDecoder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCustomAudioDecoder.Name = "cbCustomAudioDecoder";
            this.cbCustomAudioDecoder.Size = new System.Drawing.Size(348, 28);
            this.cbCustomAudioDecoder.Sorted = true;
            this.cbCustomAudioDecoder.TabIndex = 30;
            // 
            // rbAudioDecoderCustom
            // 
            this.rbAudioDecoderCustom.AutoSize = true;
            this.rbAudioDecoderCustom.Location = new System.Drawing.Point(24, 65);
            this.rbAudioDecoderCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAudioDecoderCustom.Name = "rbAudioDecoderCustom";
            this.rbAudioDecoderCustom.Size = new System.Drawing.Size(89, 24);
            this.rbAudioDecoderCustom.TabIndex = 29;
            this.rbAudioDecoderCustom.Text = "Custom";
            this.rbAudioDecoderCustom.UseVisualStyleBackColor = true;
            // 
            // rbAudioDecoderDefault
            // 
            this.rbAudioDecoderDefault.AutoSize = true;
            this.rbAudioDecoderDefault.Checked = true;
            this.rbAudioDecoderDefault.Location = new System.Drawing.Point(24, 23);
            this.rbAudioDecoderDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAudioDecoderDefault.Name = "rbAudioDecoderDefault";
            this.rbAudioDecoderDefault.Size = new System.Drawing.Size(86, 24);
            this.rbAudioDecoderDefault.TabIndex = 28;
            this.rbAudioDecoderDefault.TabStop = true;
            this.rbAudioDecoderDefault.Text = "Default";
            this.rbAudioDecoderDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.tabControl9);
            this.tabPage13.Controls.Add(this.cbMotDetEnabled);
            this.tabPage13.Location = new System.Drawing.Point(4, 29);
            this.tabPage13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage13.Size = new System.Drawing.Size(456, 764);
            this.tabPage13.TabIndex = 7;
            this.tabPage13.Text = "Motion detection";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.tabPage44);
            this.tabControl9.Controls.Add(this.tabPage45);
            this.tabControl9.Location = new System.Drawing.Point(22, 66);
            this.tabControl9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl9.Name = "tabControl9";
            this.tabControl9.SelectedIndex = 0;
            this.tabControl9.Size = new System.Drawing.Size(402, 635);
            this.tabControl9.TabIndex = 3;
            // 
            // tabPage44
            // 
            this.tabPage44.Controls.Add(this.pbMotionLevel);
            this.tabPage44.Controls.Add(this.label158);
            this.tabPage44.Controls.Add(this.mmMotDetMatrix);
            this.tabPage44.Location = new System.Drawing.Point(4, 29);
            this.tabPage44.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage44.Name = "tabPage44";
            this.tabPage44.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage44.Size = new System.Drawing.Size(394, 602);
            this.tabPage44.TabIndex = 0;
            this.tabPage44.Text = "Output matrix";
            this.tabPage44.UseVisualStyleBackColor = true;
            // 
            // pbMotionLevel
            // 
            this.pbMotionLevel.Location = new System.Drawing.Point(9, 503);
            this.pbMotionLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbMotionLevel.Name = "pbMotionLevel";
            this.pbMotionLevel.Size = new System.Drawing.Size(340, 29);
            this.pbMotionLevel.TabIndex = 2;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(8, 472);
            this.label158.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(92, 20);
            this.label158.TabIndex = 1;
            this.label158.Text = "Motion level";
            // 
            // mmMotDetMatrix
            // 
            this.mmMotDetMatrix.Location = new System.Drawing.Point(9, 9);
            this.mmMotDetMatrix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmMotDetMatrix.Multiline = true;
            this.mmMotDetMatrix.Name = "mmMotDetMatrix";
            this.mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmMotDetMatrix.Size = new System.Drawing.Size(370, 399);
            this.mmMotDetMatrix.TabIndex = 0;
            // 
            // tabPage45
            // 
            this.tabPage45.Controls.Add(this.groupBox25);
            this.tabPage45.Controls.Add(this.btMotDetUpdateSettings);
            this.tabPage45.Controls.Add(this.groupBox27);
            this.tabPage45.Controls.Add(this.groupBox26);
            this.tabPage45.Controls.Add(this.groupBox24);
            this.tabPage45.Location = new System.Drawing.Point(4, 29);
            this.tabPage45.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage45.Name = "tabPage45";
            this.tabPage45.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage45.Size = new System.Drawing.Size(394, 602);
            this.tabPage45.TabIndex = 1;
            this.tabPage45.Text = "Settings";
            this.tabPage45.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.cbMotDetHLColor);
            this.groupBox25.Controls.Add(this.label161);
            this.groupBox25.Controls.Add(this.label160);
            this.groupBox25.Controls.Add(this.cbMotDetHLEnabled);
            this.groupBox25.Controls.Add(this.tbMotDetHLThreshold);
            this.groupBox25.Location = new System.Drawing.Point(18, 158);
            this.groupBox25.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox25.Size = new System.Drawing.Size(350, 132);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Color highlight";
            // 
            // cbMotDetHLColor
            // 
            this.cbMotDetHLColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotDetHLColor.FormattingEnabled = true;
            this.cbMotDetHLColor.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.cbMotDetHLColor.Location = new System.Drawing.Point(230, 91);
            this.cbMotDetHLColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMotDetHLColor.Name = "cbMotDetHLColor";
            this.cbMotDetHLColor.Size = new System.Drawing.Size(103, 28);
            this.cbMotDetHLColor.TabIndex = 5;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(222, 65);
            this.label161.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(46, 20);
            this.label161.TabIndex = 4;
            this.label161.Text = "Color";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(45, 65);
            this.label160.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(79, 20);
            this.label160.TabIndex = 2;
            this.label160.Text = "Threshold";
            // 
            // cbMotDetHLEnabled
            // 
            this.cbMotDetHLEnabled.AutoSize = true;
            this.cbMotDetHLEnabled.Checked = true;
            this.cbMotDetHLEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMotDetHLEnabled.Location = new System.Drawing.Point(21, 34);
            this.cbMotDetHLEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMotDetHLEnabled.Name = "cbMotDetHLEnabled";
            this.cbMotDetHLEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbMotDetHLEnabled.TabIndex = 1;
            this.cbMotDetHLEnabled.Text = "Enabled";
            this.cbMotDetHLEnabled.UseVisualStyleBackColor = true;
            // 
            // tbMotDetHLThreshold
            // 
            this.tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.tbMotDetHLThreshold.Location = new System.Drawing.Point(46, 89);
            this.tbMotDetHLThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMotDetHLThreshold.Maximum = 255;
            this.tbMotDetHLThreshold.Name = "tbMotDetHLThreshold";
            this.tbMotDetHLThreshold.Size = new System.Drawing.Size(156, 69);
            this.tbMotDetHLThreshold.TabIndex = 3;
            this.tbMotDetHLThreshold.TickFrequency = 5;
            this.tbMotDetHLThreshold.Value = 25;
            // 
            // btMotDetUpdateSettings
            // 
            this.btMotDetUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btMotDetUpdateSettings.Location = new System.Drawing.Point(207, 551);
            this.btMotDetUpdateSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btMotDetUpdateSettings.Name = "btMotDetUpdateSettings";
            this.btMotDetUpdateSettings.Size = new System.Drawing.Size(160, 35);
            this.btMotDetUpdateSettings.TabIndex = 4;
            this.btMotDetUpdateSettings.Text = "Update settings";
            this.btMotDetUpdateSettings.UseVisualStyleBackColor = true;
            this.btMotDetUpdateSettings.Click += new System.EventHandler(this.btMotDetUpdateSettings_Click);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.edMotDetMatrixHeight);
            this.groupBox27.Controls.Add(this.label163);
            this.groupBox27.Controls.Add(this.edMotDetMatrixWidth);
            this.groupBox27.Controls.Add(this.label164);
            this.groupBox27.Location = new System.Drawing.Point(18, 409);
            this.groupBox27.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox27.Size = new System.Drawing.Size(350, 91);
            this.groupBox27.TabIndex = 3;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Matrix";
            // 
            // edMotDetMatrixHeight
            // 
            this.edMotDetMatrixHeight.Location = new System.Drawing.Point(218, 35);
            this.edMotDetMatrixHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edMotDetMatrixHeight.Name = "edMotDetMatrixHeight";
            this.edMotDetMatrixHeight.Size = new System.Drawing.Size(52, 26);
            this.edMotDetMatrixHeight.TabIndex = 75;
            this.edMotDetMatrixHeight.Text = "10";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(147, 40);
            this.label163.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(56, 20);
            this.label163.TabIndex = 74;
            this.label163.Text = "Height";
            // 
            // edMotDetMatrixWidth
            // 
            this.edMotDetMatrixWidth.Location = new System.Drawing.Point(84, 35);
            this.edMotDetMatrixWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edMotDetMatrixWidth.Name = "edMotDetMatrixWidth";
            this.edMotDetMatrixWidth.Size = new System.Drawing.Size(52, 26);
            this.edMotDetMatrixWidth.TabIndex = 73;
            this.edMotDetMatrixWidth.Text = "10";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(21, 40);
            this.label164.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(50, 20);
            this.label164.TabIndex = 72;
            this.label164.Text = "Width";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label162);
            this.groupBox26.Controls.Add(this.tbMotDetDropFramesThreshold);
            this.groupBox26.Controls.Add(this.cbMotDetDropFramesEnabled);
            this.groupBox26.Location = new System.Drawing.Point(18, 294);
            this.groupBox26.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox26.Size = new System.Drawing.Size(350, 106);
            this.groupBox26.TabIndex = 2;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Drop frames";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(141, 32);
            this.label162.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(79, 20);
            this.label162.TabIndex = 4;
            this.label162.Text = "Threshold";
            // 
            // tbMotDetDropFramesThreshold
            // 
            this.tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.tbMotDetDropFramesThreshold.Location = new System.Drawing.Point(142, 57);
            this.tbMotDetDropFramesThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMotDetDropFramesThreshold.Maximum = 255;
            this.tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold";
            this.tbMotDetDropFramesThreshold.Size = new System.Drawing.Size(156, 69);
            this.tbMotDetDropFramesThreshold.TabIndex = 5;
            this.tbMotDetDropFramesThreshold.TickFrequency = 5;
            this.tbMotDetDropFramesThreshold.Value = 5;
            // 
            // cbMotDetDropFramesEnabled
            // 
            this.cbMotDetDropFramesEnabled.AutoSize = true;
            this.cbMotDetDropFramesEnabled.Location = new System.Drawing.Point(21, 29);
            this.cbMotDetDropFramesEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMotDetDropFramesEnabled.Name = "cbMotDetDropFramesEnabled";
            this.cbMotDetDropFramesEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbMotDetDropFramesEnabled.TabIndex = 1;
            this.cbMotDetDropFramesEnabled.Text = "Enabled";
            this.cbMotDetDropFramesEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.edMotDetFrameInterval);
            this.groupBox24.Controls.Add(this.label159);
            this.groupBox24.Controls.Add(this.cbCompareGreyscale);
            this.groupBox24.Controls.Add(this.cbCompareBlue);
            this.groupBox24.Controls.Add(this.cbCompareGreen);
            this.groupBox24.Controls.Add(this.cbCompareRed);
            this.groupBox24.Location = new System.Drawing.Point(18, 18);
            this.groupBox24.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox24.Size = new System.Drawing.Size(350, 126);
            this.groupBox24.TabIndex = 0;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Compare settings";
            // 
            // edMotDetFrameInterval
            // 
            this.edMotDetFrameInterval.Location = new System.Drawing.Point(142, 78);
            this.edMotDetFrameInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edMotDetFrameInterval.Name = "edMotDetFrameInterval";
            this.edMotDetFrameInterval.Size = new System.Drawing.Size(46, 26);
            this.edMotDetFrameInterval.TabIndex = 5;
            this.edMotDetFrameInterval.Text = "2";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(16, 83);
            this.label159.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(109, 20);
            this.label159.TabIndex = 4;
            this.label159.Text = "Frame interval";
            // 
            // cbCompareGreyscale
            // 
            this.cbCompareGreyscale.AutoSize = true;
            this.cbCompareGreyscale.Checked = true;
            this.cbCompareGreyscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCompareGreyscale.Location = new System.Drawing.Point(244, 32);
            this.cbCompareGreyscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCompareGreyscale.Name = "cbCompareGreyscale";
            this.cbCompareGreyscale.Size = new System.Drawing.Size(106, 24);
            this.cbCompareGreyscale.TabIndex = 3;
            this.cbCompareGreyscale.Text = "Greyscale";
            this.cbCompareGreyscale.UseVisualStyleBackColor = true;
            // 
            // cbCompareBlue
            // 
            this.cbCompareBlue.AutoSize = true;
            this.cbCompareBlue.Location = new System.Drawing.Point(177, 32);
            this.cbCompareBlue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCompareBlue.Name = "cbCompareBlue";
            this.cbCompareBlue.Size = new System.Drawing.Size(67, 24);
            this.cbCompareBlue.TabIndex = 2;
            this.cbCompareBlue.Text = "Blue";
            this.cbCompareBlue.UseVisualStyleBackColor = true;
            // 
            // cbCompareGreen
            // 
            this.cbCompareGreen.AutoSize = true;
            this.cbCompareGreen.Location = new System.Drawing.Point(90, 32);
            this.cbCompareGreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCompareGreen.Name = "cbCompareGreen";
            this.cbCompareGreen.Size = new System.Drawing.Size(80, 24);
            this.cbCompareGreen.TabIndex = 1;
            this.cbCompareGreen.Text = "Green";
            this.cbCompareGreen.UseVisualStyleBackColor = true;
            // 
            // cbCompareRed
            // 
            this.cbCompareRed.AutoSize = true;
            this.cbCompareRed.Location = new System.Drawing.Point(21, 32);
            this.cbCompareRed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCompareRed.Name = "cbCompareRed";
            this.cbCompareRed.Size = new System.Drawing.Size(65, 24);
            this.cbCompareRed.TabIndex = 0;
            this.cbCompareRed.Text = "Red";
            this.cbCompareRed.UseVisualStyleBackColor = true;
            // 
            // cbMotDetEnabled
            // 
            this.cbMotDetEnabled.AutoSize = true;
            this.cbMotDetEnabled.Location = new System.Drawing.Point(22, 25);
            this.cbMotDetEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMotDetEnabled.Name = "cbMotDetEnabled";
            this.cbMotDetEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbMotDetEnabled.TabIndex = 2;
            this.cbMotDetEnabled.Text = "Enabled";
            this.cbMotDetEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.label505);
            this.tabPage14.Controls.Add(this.rbMotionDetectionExProcessor);
            this.tabPage14.Controls.Add(this.label389);
            this.tabPage14.Controls.Add(this.rbMotionDetectionExDetector);
            this.tabPage14.Controls.Add(this.label64);
            this.tabPage14.Controls.Add(this.label65);
            this.tabPage14.Controls.Add(this.pbAFMotionLevel);
            this.tabPage14.Controls.Add(this.cbMotionDetectionEx);
            this.tabPage14.Location = new System.Drawing.Point(4, 29);
            this.tabPage14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage14.Size = new System.Drawing.Size(456, 764);
            this.tabPage14.TabIndex = 14;
            this.tabPage14.Text = "Motion detection (Extended)";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // label505
            // 
            this.label505.AutoSize = true;
            this.label505.Location = new System.Drawing.Point(24, 154);
            this.label505.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label505.Name = "label505";
            this.label505.Size = new System.Drawing.Size(80, 20);
            this.label505.TabIndex = 31;
            this.label505.Text = "Processor";
            // 
            // rbMotionDetectionExProcessor
            // 
            this.rbMotionDetectionExProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rbMotionDetectionExProcessor.FormattingEnabled = true;
            this.rbMotionDetectionExProcessor.Items.AddRange(new object[] {
            "None",
            "Blob counting objects",
            "GridMotionAreaProcessing",
            "Motion area highlighting",
            "Motion border highlighting"});
            this.rbMotionDetectionExProcessor.Location = new System.Drawing.Point(24, 178);
            this.rbMotionDetectionExProcessor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMotionDetectionExProcessor.Name = "rbMotionDetectionExProcessor";
            this.rbMotionDetectionExProcessor.Size = new System.Drawing.Size(385, 28);
            this.rbMotionDetectionExProcessor.TabIndex = 30;
            // 
            // label389
            // 
            this.label389.AutoSize = true;
            this.label389.Location = new System.Drawing.Point(24, 77);
            this.label389.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label389.Name = "label389";
            this.label389.Size = new System.Drawing.Size(71, 20);
            this.label389.TabIndex = 29;
            this.label389.Text = "Detector";
            // 
            // rbMotionDetectionExDetector
            // 
            this.rbMotionDetectionExDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rbMotionDetectionExDetector.FormattingEnabled = true;
            this.rbMotionDetectionExDetector.Items.AddRange(new object[] {
            "Custom frame difference",
            "Simple background modeling",
            "Two frames difference"});
            this.rbMotionDetectionExDetector.Location = new System.Drawing.Point(24, 102);
            this.rbMotionDetectionExDetector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMotionDetectionExDetector.Name = "rbMotionDetectionExDetector";
            this.rbMotionDetectionExDetector.Size = new System.Drawing.Size(385, 28);
            this.rbMotionDetectionExDetector.TabIndex = 28;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(80, 674);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(255, 20);
            this.label64.TabIndex = 27;
            this.label64.Text = "Much more options available in API";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(24, 243);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(92, 20);
            this.label65.TabIndex = 26;
            this.label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = new System.Drawing.Point(24, 268);
            this.pbAFMotionLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbAFMotionLevel.Name = "pbAFMotionLevel";
            this.pbAFMotionLevel.Size = new System.Drawing.Size(387, 35);
            this.pbAFMotionLevel.TabIndex = 25;
            // 
            // cbMotionDetectionEx
            // 
            this.cbMotionDetectionEx.AutoSize = true;
            this.cbMotionDetectionEx.Location = new System.Drawing.Point(24, 18);
            this.cbMotionDetectionEx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMotionDetectionEx.Name = "cbMotionDetectionEx";
            this.cbMotionDetectionEx.Size = new System.Drawing.Size(94, 24);
            this.cbMotionDetectionEx.TabIndex = 24;
            this.cbMotionDetectionEx.Text = "Enabled";
            this.cbMotionDetectionEx.UseVisualStyleBackColor = true;
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.edBarcodeMetadata);
            this.tabPage21.Controls.Add(this.label91);
            this.tabPage21.Controls.Add(this.cbBarcodeType);
            this.tabPage21.Controls.Add(this.label90);
            this.tabPage21.Controls.Add(this.btBarcodeReset);
            this.tabPage21.Controls.Add(this.edBarcode);
            this.tabPage21.Controls.Add(this.label89);
            this.tabPage21.Controls.Add(this.cbBarcodeDetectionEnabled);
            this.tabPage21.Location = new System.Drawing.Point(4, 29);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage21.Size = new System.Drawing.Size(456, 764);
            this.tabPage21.TabIndex = 8;
            this.tabPage21.Text = "Barcode reader";
            this.tabPage21.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = new System.Drawing.Point(24, 246);
            this.edBarcodeMetadata.Multiline = true;
            this.edBarcodeMetadata.Name = "edBarcodeMetadata";
            this.edBarcodeMetadata.Size = new System.Drawing.Size(406, 146);
            this.edBarcodeMetadata.TabIndex = 16;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(21, 217);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(77, 20);
            this.label91.TabIndex = 15;
            this.label91.Text = "Metadata";
            // 
            // cbBarcodeType
            // 
            this.cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBarcodeType.FormattingEnabled = true;
            this.cbBarcodeType.Items.AddRange(new object[] {
            "Autodetect",
            "UPC-A",
            "UPC-E",
            "EAN-8",
            "EAN-13",
            "Code 39",
            "Code 93",
            "Code 128",
            "ITF",
            "CodaBar",
            "RSS-14",
            "Data matrix",
            "Aztec",
            "QR",
            "PDF-417"});
            this.cbBarcodeType.Location = new System.Drawing.Point(24, 98);
            this.cbBarcodeType.Name = "cbBarcodeType";
            this.cbBarcodeType.Size = new System.Drawing.Size(238, 28);
            this.cbBarcodeType.TabIndex = 14;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(21, 74);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(103, 20);
            this.label90.TabIndex = 13;
            this.label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = new System.Drawing.Point(24, 412);
            this.btBarcodeReset.Name = "btBarcodeReset";
            this.btBarcodeReset.Size = new System.Drawing.Size(93, 35);
            this.btBarcodeReset.TabIndex = 12;
            this.btBarcodeReset.Text = "Restart";
            this.btBarcodeReset.UseVisualStyleBackColor = true;
            this.btBarcodeReset.Click += new System.EventHandler(this.btBarcodeReset_Click);
            // 
            // edBarcode
            // 
            this.edBarcode.Location = new System.Drawing.Point(24, 172);
            this.edBarcode.Name = "edBarcode";
            this.edBarcode.Size = new System.Drawing.Size(406, 26);
            this.edBarcode.TabIndex = 11;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(21, 148);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(137, 20);
            this.label89.TabIndex = 10;
            this.label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = true;
            this.cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(24, 28);
            this.cbBarcodeDetectionEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            this.cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbBarcodeDetectionEnabled.TabIndex = 9;
            this.cbBarcodeDetectionEnabled.Text = "Enabled";
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage23
            // 
            this.tabPage23.Controls.Add(this.textBox1);
            this.tabPage23.Controls.Add(this.groupBox48);
            this.tabPage23.Location = new System.Drawing.Point(4, 29);
            this.tabPage23.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage23.Name = "tabPage23";
            this.tabPage23.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage23.Size = new System.Drawing.Size(456, 764);
            this.tabPage23.TabIndex = 9;
            this.tabPage23.Text = "Encryption";
            this.tabPage23.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 377);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(402, 121);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Media Player SDK .Net can play encrypted files created by Video Encryption SDK (D" +
    "irectShow or included in Video Capture SDK .Net / Video Edit SDK .Net).";
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.label343);
            this.groupBox48.Controls.Add(this.edEncryptionKeyHEX);
            this.groupBox48.Controls.Add(this.rbEncryptionKeyBinary);
            this.groupBox48.Controls.Add(this.btEncryptionOpenFile);
            this.groupBox48.Controls.Add(this.edEncryptionKeyFile);
            this.groupBox48.Controls.Add(this.rbEncryptionKeyFile);
            this.groupBox48.Controls.Add(this.edEncryptionKeyString);
            this.groupBox48.Controls.Add(this.rbEncryptionKeyString);
            this.groupBox48.Location = new System.Drawing.Point(24, 23);
            this.groupBox48.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox48.Size = new System.Drawing.Size(404, 345);
            this.groupBox48.TabIndex = 9;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "Encryption key type";
            // 
            // label343
            // 
            this.label343.AutoSize = true;
            this.label343.Location = new System.Drawing.Point(50, 306);
            this.label343.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label343.Name = "label343";
            this.label343.Size = new System.Drawing.Size(232, 20);
            this.label343.TabIndex = 10;
            this.label343.Text = "You can assign byte[] using API";
            // 
            // edEncryptionKeyHEX
            // 
            this.edEncryptionKeyHEX.Location = new System.Drawing.Point(54, 271);
            this.edEncryptionKeyHEX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edEncryptionKeyHEX.Name = "edEncryptionKeyHEX";
            this.edEncryptionKeyHEX.Size = new System.Drawing.Size(319, 26);
            this.edEncryptionKeyHEX.TabIndex = 9;
            this.edEncryptionKeyHEX.Text = "enter hex data";
            // 
            // rbEncryptionKeyBinary
            // 
            this.rbEncryptionKeyBinary.AutoSize = true;
            this.rbEncryptionKeyBinary.Location = new System.Drawing.Point(21, 235);
            this.rbEncryptionKeyBinary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEncryptionKeyBinary.Name = "rbEncryptionKeyBinary";
            this.rbEncryptionKeyBinary.Size = new System.Drawing.Size(181, 24);
            this.rbEncryptionKeyBinary.TabIndex = 8;
            this.rbEncryptionKeyBinary.Text = "Binary data (v9 SDK)";
            this.rbEncryptionKeyBinary.UseVisualStyleBackColor = true;
            // 
            // btEncryptionOpenFile
            // 
            this.btEncryptionOpenFile.Location = new System.Drawing.Point(340, 175);
            this.btEncryptionOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEncryptionOpenFile.Name = "btEncryptionOpenFile";
            this.btEncryptionOpenFile.Size = new System.Drawing.Size(34, 35);
            this.btEncryptionOpenFile.TabIndex = 7;
            this.btEncryptionOpenFile.Text = "...";
            this.btEncryptionOpenFile.UseVisualStyleBackColor = true;
            this.btEncryptionOpenFile.Click += new System.EventHandler(this.btEncryptionOpenFile_Click);
            // 
            // edEncryptionKeyFile
            // 
            this.edEncryptionKeyFile.Location = new System.Drawing.Point(54, 178);
            this.edEncryptionKeyFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edEncryptionKeyFile.Name = "edEncryptionKeyFile";
            this.edEncryptionKeyFile.Size = new System.Drawing.Size(276, 26);
            this.edEncryptionKeyFile.TabIndex = 6;
            this.edEncryptionKeyFile.Text = "c:\\keyfile.txt";
            // 
            // rbEncryptionKeyFile
            // 
            this.rbEncryptionKeyFile.AutoSize = true;
            this.rbEncryptionKeyFile.Location = new System.Drawing.Point(21, 143);
            this.rbEncryptionKeyFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEncryptionKeyFile.Name = "rbEncryptionKeyFile";
            this.rbEncryptionKeyFile.Size = new System.Drawing.Size(126, 24);
            this.rbEncryptionKeyFile.TabIndex = 5;
            this.rbEncryptionKeyFile.Text = "File (v9 SDK)";
            this.rbEncryptionKeyFile.UseVisualStyleBackColor = true;
            // 
            // edEncryptionKeyString
            // 
            this.edEncryptionKeyString.Location = new System.Drawing.Point(54, 86);
            this.edEncryptionKeyString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edEncryptionKeyString.Name = "edEncryptionKeyString";
            this.edEncryptionKeyString.Size = new System.Drawing.Size(319, 26);
            this.edEncryptionKeyString.TabIndex = 4;
            this.edEncryptionKeyString.Text = "100";
            // 
            // rbEncryptionKeyString
            // 
            this.rbEncryptionKeyString.AutoSize = true;
            this.rbEncryptionKeyString.Checked = true;
            this.rbEncryptionKeyString.Location = new System.Drawing.Point(21, 43);
            this.rbEncryptionKeyString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEncryptionKeyString.Name = "rbEncryptionKeyString";
            this.rbEncryptionKeyString.Size = new System.Drawing.Size(76, 24);
            this.rbEncryptionKeyString.TabIndex = 0;
            this.rbEncryptionKeyString.TabStop = true;
            this.rbEncryptionKeyString.Text = "String";
            this.rbEncryptionKeyString.UseVisualStyleBackColor = true;
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.btReversePlaybackNextFrame);
            this.tabPage24.Controls.Add(this.btReversePlaybackPrevFrame);
            this.tabPage24.Controls.Add(this.label34);
            this.tabPage24.Controls.Add(this.label33);
            this.tabPage24.Controls.Add(this.btReversePlayback);
            this.tabPage24.Controls.Add(this.edReversePlaybackCacheSize);
            this.tabPage24.Controls.Add(this.label32);
            this.tabPage24.Controls.Add(this.tbReversePlaybackTrackbar);
            this.tabPage24.Location = new System.Drawing.Point(4, 29);
            this.tabPage24.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage24.Size = new System.Drawing.Size(456, 764);
            this.tabPage24.TabIndex = 10;
            this.tabPage24.Text = "Reverse playback";
            this.tabPage24.UseVisualStyleBackColor = true;
            // 
            // btReversePlaybackNextFrame
            // 
            this.btReversePlaybackNextFrame.Location = new System.Drawing.Point(195, 311);
            this.btReversePlaybackNextFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btReversePlaybackNextFrame.Name = "btReversePlaybackNextFrame";
            this.btReversePlaybackNextFrame.Size = new System.Drawing.Size(158, 35);
            this.btReversePlaybackNextFrame.TabIndex = 12;
            this.btReversePlaybackNextFrame.Text = "Next frame";
            this.btReversePlaybackNextFrame.UseVisualStyleBackColor = true;
            this.btReversePlaybackNextFrame.Click += new System.EventHandler(this.btReversePlaybackNextFrame_Click);
            // 
            // btReversePlaybackPrevFrame
            // 
            this.btReversePlaybackPrevFrame.Location = new System.Drawing.Point(28, 311);
            this.btReversePlaybackPrevFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btReversePlaybackPrevFrame.Name = "btReversePlaybackPrevFrame";
            this.btReversePlaybackPrevFrame.Size = new System.Drawing.Size(158, 35);
            this.btReversePlaybackPrevFrame.TabIndex = 11;
            this.btReversePlaybackPrevFrame.Text = "Previous frame";
            this.btReversePlaybackPrevFrame.UseVisualStyleBackColor = true;
            this.btReversePlaybackPrevFrame.Click += new System.EventHandler(this.btReversePlaybackPrevFrame_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(24, 178);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(159, 20);
            this.label34.TabIndex = 10;
            this.label34.Text = "count before tracking";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 152);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(339, 20);
            this.label33.TabIndex = 9;
            this.label33.Text = "Wait several seconds to cache required frames";
            // 
            // btReversePlayback
            // 
            this.btReversePlayback.Location = new System.Drawing.Point(28, 98);
            this.btReversePlayback.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btReversePlayback.Name = "btReversePlayback";
            this.btReversePlayback.Size = new System.Drawing.Size(285, 35);
            this.btReversePlayback.TabIndex = 8;
            this.btReversePlayback.Text = "Go to reverse playback mode";
            this.btReversePlayback.UseVisualStyleBackColor = true;
            this.btReversePlayback.Click += new System.EventHandler(this.btReversePlayback_Click);
            // 
            // edReversePlaybackCacheSize
            // 
            this.edReversePlaybackCacheSize.Location = new System.Drawing.Point(213, 23);
            this.edReversePlaybackCacheSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edReversePlaybackCacheSize.Name = "edReversePlaybackCacheSize";
            this.edReversePlaybackCacheSize.Size = new System.Drawing.Size(98, 26);
            this.edReversePlaybackCacheSize.TabIndex = 7;
            this.edReversePlaybackCacheSize.Text = "100";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(24, 28);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(134, 20);
            this.label32.TabIndex = 6;
            this.label32.Text = "Frame cache size";
            // 
            // tbReversePlaybackTrackbar
            // 
            this.tbReversePlaybackTrackbar.Location = new System.Drawing.Point(28, 218);
            this.tbReversePlaybackTrackbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbReversePlaybackTrackbar.Maximum = 100;
            this.tbReversePlaybackTrackbar.Name = "tbReversePlaybackTrackbar";
            this.tbReversePlaybackTrackbar.Size = new System.Drawing.Size(285, 69);
            this.tbReversePlaybackTrackbar.TabIndex = 4;
            this.tbReversePlaybackTrackbar.Value = 100;
            this.tbReversePlaybackTrackbar.Scroll += new System.EventHandler(this.tbReversePlaybackTrackbar_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(490, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "File name or URL";
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFilenameOrURL.Location = new System.Drawing.Point(495, 43);
            this.edFilenameOrURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFilenameOrURL.Name = "edFilenameOrURL";
            this.edFilenameOrURL.Size = new System.Drawing.Size(520, 26);
            this.edFilenameOrURL.TabIndex = 3;
            this.edFilenameOrURL.Text = "c:\\samples\\!video.mp4";
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(1084, 40);
            this.btSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(34, 35);
            this.btSelectFile.TabIndex = 4;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btPreviousFrame);
            this.groupBox2.Controls.Add(this.cbLoop);
            this.groupBox2.Controls.Add(this.btNextFrame);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbTime);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(495, 774);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(621, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btPreviousFrame
            // 
            this.btPreviousFrame.Location = new System.Drawing.Point(378, 89);
            this.btPreviousFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPreviousFrame.Name = "btPreviousFrame";
            this.btPreviousFrame.Size = new System.Drawing.Size(112, 35);
            this.btPreviousFrame.TabIndex = 10;
            this.btPreviousFrame.Text = "Prev frame";
            this.btPreviousFrame.UseVisualStyleBackColor = true;
            this.btPreviousFrame.Click += new System.EventHandler(this.btPreviousFrame_Click);
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(330, 18);
            this.cbLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(71, 24);
            this.cbLoop.TabIndex = 9;
            this.cbLoop.Text = "Loop";
            this.cbLoop.UseVisualStyleBackColor = true;
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = new System.Drawing.Point(500, 89);
            this.btNextFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btNextFrame.Name = "btNextFrame";
            this.btNextFrame.Size = new System.Drawing.Size(112, 35);
            this.btNextFrame.TabIndex = 8;
            this.btNextFrame.Text = "Next frame";
            this.btNextFrame.UseVisualStyleBackColor = true;
            this.btNextFrame.Click += new System.EventHandler(this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btStop.Location = new System.Drawing.Point(270, 89);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(69, 35);
            this.btStop.TabIndex = 7;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(183, 89);
            this.btPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(78, 35);
            this.btPause.TabIndex = 6;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(82, 89);
            this.btResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(92, 35);
            this.btResume.TabIndex = 5;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btStart.Location = new System.Drawing.Point(9, 89);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(64, 35);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(482, 42);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSpeed.Maximum = 25;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(134, 69);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(483, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Speed";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(326, 49);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(137, 20);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(9, 29);
            this.tbTimeline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(310, 69);
            this.tbTimeline.TabIndex = 0;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btDVDControlRootMenu);
            this.groupBox3.Controls.Add(this.btDVDControlTitleMenu);
            this.groupBox3.Controls.Add(this.cbDVDControlSubtitles);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cbDVDControlAudio);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbDVDControlChapter);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cbDVDControlTitle);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(495, 923);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(621, 120);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DVD";
            // 
            // btDVDControlRootMenu
            // 
            this.btDVDControlRootMenu.Location = new System.Drawing.Point(502, 74);
            this.btDVDControlRootMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDVDControlRootMenu.Name = "btDVDControlRootMenu";
            this.btDVDControlRootMenu.Size = new System.Drawing.Size(112, 35);
            this.btDVDControlRootMenu.TabIndex = 9;
            this.btDVDControlRootMenu.Text = "Root menu";
            this.btDVDControlRootMenu.UseVisualStyleBackColor = true;
            this.btDVDControlRootMenu.Click += new System.EventHandler(this.btDVDControlRootMenu_Click);
            // 
            // btDVDControlTitleMenu
            // 
            this.btDVDControlTitleMenu.Location = new System.Drawing.Point(502, 32);
            this.btDVDControlTitleMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDVDControlTitleMenu.Name = "btDVDControlTitleMenu";
            this.btDVDControlTitleMenu.Size = new System.Drawing.Size(112, 35);
            this.btDVDControlTitleMenu.TabIndex = 8;
            this.btDVDControlTitleMenu.Text = "Title menu";
            this.btDVDControlTitleMenu.UseVisualStyleBackColor = true;
            this.btDVDControlTitleMenu.Click += new System.EventHandler(this.btDVDControlTitleMenu_Click);
            // 
            // cbDVDControlSubtitles
            // 
            this.cbDVDControlSubtitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlSubtitles.FormattingEnabled = true;
            this.cbDVDControlSubtitles.Location = new System.Drawing.Point(326, 77);
            this.cbDVDControlSubtitles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDControlSubtitles.Name = "cbDVDControlSubtitles";
            this.cbDVDControlSubtitles.Size = new System.Drawing.Size(166, 28);
            this.cbDVDControlSubtitles.TabIndex = 7;
            this.cbDVDControlSubtitles.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlSubtitles_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(252, 82);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 20);
            this.label19.TabIndex = 6;
            this.label19.Text = "Subtitles";
            // 
            // cbDVDControlAudio
            // 
            this.cbDVDControlAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlAudio.FormattingEnabled = true;
            this.cbDVDControlAudio.Location = new System.Drawing.Point(326, 35);
            this.cbDVDControlAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDControlAudio.Name = "cbDVDControlAudio";
            this.cbDVDControlAudio.Size = new System.Drawing.Size(166, 28);
            this.cbDVDControlAudio.TabIndex = 5;
            this.cbDVDControlAudio.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlAudio_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(252, 40);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "Audio";
            // 
            // cbDVDControlChapter
            // 
            this.cbDVDControlChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlChapter.FormattingEnabled = true;
            this.cbDVDControlChapter.Location = new System.Drawing.Point(82, 77);
            this.cbDVDControlChapter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDControlChapter.Name = "cbDVDControlChapter";
            this.cbDVDControlChapter.Size = new System.Drawing.Size(145, 28);
            this.cbDVDControlChapter.TabIndex = 3;
            this.cbDVDControlChapter.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlChapter_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 82);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "Chapter";
            // 
            // cbDVDControlTitle
            // 
            this.cbDVDControlTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlTitle.FormattingEnabled = true;
            this.cbDVDControlTitle.Location = new System.Drawing.Point(82, 35);
            this.cbDVDControlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDVDControlTitle.Name = "cbDVDControlTitle";
            this.cbDVDControlTitle.Size = new System.Drawing.Size(145, 28);
            this.cbDVDControlTitle.TabIndex = 1;
            this.cbDVDControlTitle.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlTitle_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 40);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Title";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Location = new System.Drawing.Point(18, 818);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(464, 225);
            this.tabControl3.TabIndex = 9;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.cbTelemetry);
            this.tabPage10.Controls.Add(this.mmLog);
            this.tabPage10.Controls.Add(this.cbDebugMode);
            this.tabPage10.Location = new System.Drawing.Point(4, 29);
            this.tabPage10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage10.Size = new System.Drawing.Size(456, 192);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Debug";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(120, 20);
            this.cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(104, 24);
            this.cbTelemetry.TabIndex = 4;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(24, 55);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(394, 118);
            this.mmLog.TabIndex = 1;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(24, 20);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(83, 24);
            this.cbDebugMode.TabIndex = 0;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.tabControl13);
            this.tabPage9.Location = new System.Drawing.Point(4, 29);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage9.Size = new System.Drawing.Size(456, 192);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Snapshot";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabControl13
            // 
            this.tabControl13.Controls.Add(this.tabPage54);
            this.tabControl13.Controls.Add(this.tabPage55);
            this.tabControl13.Location = new System.Drawing.Point(3, 3);
            this.tabControl13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl13.Name = "tabControl13";
            this.tabControl13.SelectedIndex = 0;
            this.tabControl13.Size = new System.Drawing.Size(440, 171);
            this.tabControl13.TabIndex = 27;
            // 
            // tabPage54
            // 
            this.tabPage54.Controls.Add(this.cbImageType);
            this.tabPage54.Controls.Add(this.lbJPEGQuality);
            this.tabPage54.Controls.Add(this.label38);
            this.tabPage54.Controls.Add(this.btSaveScreenshot);
            this.tabPage54.Controls.Add(this.btSelectScreenshotsFolder);
            this.tabPage54.Controls.Add(this.label63);
            this.tabPage54.Controls.Add(this.edScreenshotsFolder);
            this.tabPage54.Controls.Add(this.tbJPEGQuality);
            this.tabPage54.Location = new System.Drawing.Point(4, 29);
            this.tabPage54.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage54.Name = "tabPage54";
            this.tabPage54.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage54.Size = new System.Drawing.Size(432, 138);
            this.tabPage54.TabIndex = 0;
            this.tabPage54.Text = "Main";
            this.tabPage54.UseVisualStyleBackColor = true;
            // 
            // cbImageType
            // 
            this.cbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageType.FormattingEnabled = true;
            this.cbImageType.Items.AddRange(new object[] {
            "BMP",
            "JPEG",
            "GIF",
            "PNG",
            "TIFF"});
            this.cbImageType.Location = new System.Drawing.Point(16, 91);
            this.cbImageType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbImageType.Name = "cbImageType";
            this.cbImageType.Size = new System.Drawing.Size(108, 28);
            this.cbImageType.TabIndex = 33;
            // 
            // lbJPEGQuality
            // 
            this.lbJPEGQuality.AutoSize = true;
            this.lbJPEGQuality.Location = new System.Drawing.Point(392, 95);
            this.lbJPEGQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbJPEGQuality.Name = "lbJPEGQuality";
            this.lbJPEGQuality.Size = new System.Drawing.Size(27, 20);
            this.lbJPEGQuality.TabIndex = 32;
            this.lbJPEGQuality.Text = "85";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(178, 95);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 20);
            this.label38.TabIndex = 31;
            this.label38.Text = "JPEG quality";
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Location = new System.Drawing.Point(340, 22);
            this.btSaveScreenshot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(84, 35);
            this.btSaveScreenshot.TabIndex = 29;
            this.btSaveScreenshot.Text = "Save";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // btSelectScreenshotsFolder
            // 
            this.btSelectScreenshotsFolder.Location = new System.Drawing.Point(297, 22);
            this.btSelectScreenshotsFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectScreenshotsFolder.Name = "btSelectScreenshotsFolder";
            this.btSelectScreenshotsFolder.Size = new System.Drawing.Size(34, 35);
            this.btSelectScreenshotsFolder.TabIndex = 28;
            this.btSelectScreenshotsFolder.Text = "...";
            this.btSelectScreenshotsFolder.UseVisualStyleBackColor = true;
            this.btSelectScreenshotsFolder.Click += new System.EventHandler(this.btSelectScreenshotsFolder_Click);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(12, 29);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(54, 20);
            this.label63.TabIndex = 27;
            this.label63.Text = "Folder";
            // 
            // edScreenshotsFolder
            // 
            this.edScreenshotsFolder.Location = new System.Drawing.Point(80, 25);
            this.edScreenshotsFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edScreenshotsFolder.Name = "edScreenshotsFolder";
            this.edScreenshotsFolder.Size = new System.Drawing.Size(206, 26);
            this.edScreenshotsFolder.TabIndex = 26;
            this.edScreenshotsFolder.Text = "c:\\";
            // 
            // tbJPEGQuality
            // 
            this.tbJPEGQuality.BackColor = System.Drawing.SystemColors.Window;
            this.tbJPEGQuality.Location = new System.Drawing.Point(288, 74);
            this.tbJPEGQuality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbJPEGQuality.Maximum = 100;
            this.tbJPEGQuality.Name = "tbJPEGQuality";
            this.tbJPEGQuality.Size = new System.Drawing.Size(96, 69);
            this.tbJPEGQuality.TabIndex = 30;
            this.tbJPEGQuality.TickFrequency = 5;
            this.tbJPEGQuality.Value = 85;
            this.tbJPEGQuality.Scroll += new System.EventHandler(this.tbJPEGQuality_Scroll);
            // 
            // tabPage55
            // 
            this.tabPage55.Controls.Add(this.edScreenshotHeight);
            this.tabPage55.Controls.Add(this.label176);
            this.tabPage55.Controls.Add(this.edScreenshotWidth);
            this.tabPage55.Controls.Add(this.label177);
            this.tabPage55.Controls.Add(this.cbScreenshotResize);
            this.tabPage55.Location = new System.Drawing.Point(4, 29);
            this.tabPage55.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage55.Name = "tabPage55";
            this.tabPage55.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage55.Size = new System.Drawing.Size(432, 138);
            this.tabPage55.TabIndex = 1;
            this.tabPage55.Text = "Resize";
            this.tabPage55.UseVisualStyleBackColor = true;
            // 
            // edScreenshotHeight
            // 
            this.edScreenshotHeight.Location = new System.Drawing.Point(244, 68);
            this.edScreenshotHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edScreenshotHeight.Name = "edScreenshotHeight";
            this.edScreenshotHeight.Size = new System.Drawing.Size(52, 26);
            this.edScreenshotHeight.TabIndex = 128;
            this.edScreenshotHeight.Text = "576";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(174, 72);
            this.label176.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(56, 20);
            this.label176.TabIndex = 127;
            this.label176.Text = "Height";
            // 
            // edScreenshotWidth
            // 
            this.edScreenshotWidth.Location = new System.Drawing.Point(111, 68);
            this.edScreenshotWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edScreenshotWidth.Name = "edScreenshotWidth";
            this.edScreenshotWidth.Size = new System.Drawing.Size(52, 26);
            this.edScreenshotWidth.TabIndex = 126;
            this.edScreenshotWidth.Text = "768";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(48, 72);
            this.label177.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(50, 20);
            this.label177.TabIndex = 125;
            this.label177.Text = "Width";
            // 
            // cbScreenshotResize
            // 
            this.cbScreenshotResize.AutoSize = true;
            this.cbScreenshotResize.Location = new System.Drawing.Point(24, 28);
            this.cbScreenshotResize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbScreenshotResize.Name = "cbScreenshotResize";
            this.cbScreenshotResize.Size = new System.Drawing.Size(94, 24);
            this.cbScreenshotResize.TabIndex = 0;
            this.cbScreenshotResize.Text = "Enabled";
            this.cbScreenshotResize.UseVisualStyleBackColor = true;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.White;
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(490, 197);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 20);
            this.label29.TabIndex = 14;
            this.label29.Text = "Source mode";
            // 
            // cbSourceMode
            // 
            this.cbSourceMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceMode.FormattingEnabled = true;
            this.cbSourceMode.Items.AddRange(new object[] {
            "File / Network stream (decode using LAV) ",
            "File / Network stream (decode using GPU) ",
            "File / Network stream (decode using FFMPEG)",
            "File (decode using DirectShow)",
            "File (decode using VLC)",
            "DVD",
            "Blu-Ray",
            "File from memory (decode using DirectShow)",
            "MMS / WMV (network stream)",
            "HTTP / RTSP / RTMP (decoding using VLC)",
            "Encrypted file (decode using DirectShow)",
            "Custom source filter (specified by CLSID)",
            "MIDI / KAR"});
            this.cbSourceMode.Location = new System.Drawing.Point(648, 192);
            this.cbSourceMode.Name = "cbSourceMode";
            this.cbSourceMode.Size = new System.Drawing.Size(466, 28);
            this.cbSourceMode.TabIndex = 15;
            // 
            // lbSourceFiles
            // 
            this.lbSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceFiles.ContextMenuStrip = this.mnPlaylist;
            this.lbSourceFiles.FormattingEnabled = true;
            this.lbSourceFiles.ItemHeight = 20;
            this.lbSourceFiles.Location = new System.Drawing.Point(495, 100);
            this.lbSourceFiles.Name = "lbSourceFiles";
            this.lbSourceFiles.Size = new System.Drawing.Size(619, 84);
            this.lbSourceFiles.TabIndex = 16;
            // 
            // mnPlaylist
            // 
            this.mnPlaylist.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPlaylistRemove,
            this.mnPlaylistRemoveAll});
            this.mnPlaylist.Name = "mnPlaylist";
            this.mnPlaylist.Size = new System.Drawing.Size(171, 68);
            this.mnPlaylist.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnPlaylist_ItemClicked);
            // 
            // mnPlaylistRemove
            // 
            this.mnPlaylistRemove.Name = "mnPlaylistRemove";
            this.mnPlaylistRemove.Size = new System.Drawing.Size(170, 32);
            this.mnPlaylistRemove.Text = "Remove";
            // 
            // mnPlaylistRemoveAll
            // 
            this.mnPlaylistRemoveAll.Name = "mnPlaylistRemoveAll";
            this.mnPlaylistRemoveAll.Size = new System.Drawing.Size(170, 32);
            this.mnPlaylistRemoveAll.Text = "Remove all";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(492, 75);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 20);
            this.label30.TabIndex = 17;
            this.label30.Text = "Playlist";
            // 
            // btAddFileToPlaylist
            // 
            this.btAddFileToPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddFileToPlaylist.Location = new System.Drawing.Point(1023, 42);
            this.btAddFileToPlaylist.Name = "btAddFileToPlaylist";
            this.btAddFileToPlaylist.Size = new System.Drawing.Size(57, 34);
            this.btAddFileToPlaylist.TabIndex = 18;
            this.btAddFileToPlaylist.Text = "Add";
            this.btAddFileToPlaylist.UseVisualStyleBackColor = true;
            this.btAddFileToPlaylist.Click += new System.EventHandler(this.btAddFileToPlaylist_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(954, 14);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(160, 20);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(492, 243);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(150, 20);
            this.label37.TabIndex = 21;
            this.label37.Text = "Custom filter CLSID";
            // 
            // edCustomSourceFilter
            // 
            this.edCustomSourceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edCustomSourceFilter.Location = new System.Drawing.Point(648, 238);
            this.edCustomSourceFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCustomSourceFilter.Name = "edCustomSourceFilter";
            this.edCustomSourceFilter.Size = new System.Drawing.Size(466, 26);
            this.edCustomSourceFilter.TabIndex = 22;
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(495, 282);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(622, 472);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 1057);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.edCustomSourceFilter);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btAddFileToPlaylist);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lbSourceFiles);
            this.Controls.Add(this.cbSourceMode);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net - Main Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage49.ResumeLayout(false);
            this.tabPage49.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTags)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabControl17.ResumeLayout(false);
            this.tabPage68.ResumeLayout(false);
            this.tabPage68.PerformLayout();
            this.tabControl7.ResumeLayout(false);
            this.tabPage29.ResumeLayout(false);
            this.tabPage42.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabPage19.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.tabPage22.ResumeLayout(false);
            this.tabPage22.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.tabPage43.ResumeLayout(false);
            this.tabPage43.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage69.ResumeLayout(false);
            this.tabPage69.PerformLayout();
            this.tabPage59.ResumeLayout(false);
            this.tabPage59.PerformLayout();
            this.tabPage51.ResumeLayout(false);
            this.tabPage51.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).EndInit();
            this.tabPage46.ResumeLayout(false);
            this.tabPage46.PerformLayout();
            this.tabPage48.ResumeLayout(false);
            this.tabPage48.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.tabControl18.ResumeLayout(false);
            this.tabPage71.ResumeLayout(false);
            this.tabPage71.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).EndInit();
            this.tabPage72.ResumeLayout(false);
            this.tabPage72.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).EndInit();
            this.tabPage73.ResumeLayout(false);
            this.tabPage73.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudDynAmp)).EndInit();
            this.tabPage75.ResumeLayout(false);
            this.tabPage75.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAud3DSound)).EndInit();
            this.tabPage76.ResumeLayout(false);
            this.tabPage76.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudTrueBass)).EndInit();
            this.tabPage27.ResumeLayout(false);
            this.tabPage27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudPitchShift)).EndInit();
            this.tabPage50.ResumeLayout(false);
            this.tabPage50.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).EndInit();
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.tabPage30.PerformLayout();
            this.tabPage31.ResumeLayout(false);
            this.tabPage31.PerformLayout();
            this.tabPage32.ResumeLayout(false);
            this.tabPage32.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOSDTranspLevel)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage33.ResumeLayout(false);
            this.tabPage33.PerformLayout();
            this.tabPage34.ResumeLayout(false);
            this.tabPage34.PerformLayout();
            this.tabPage47.ResumeLayout(false);
            this.tabPage47.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabControl9.ResumeLayout(false);
            this.tabPage44.ResumeLayout(false);
            this.tabPage44.PerformLayout();
            this.tabPage45.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).EndInit();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).EndInit();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage21.ResumeLayout(false);
            this.tabPage21.PerformLayout();
            this.tabPage23.ResumeLayout(false);
            this.tabPage23.PerformLayout();
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.tabPage24.ResumeLayout(false);
            this.tabPage24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbReversePlaybackTrackbar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabControl13.ResumeLayout(false);
            this.tabPage54.ResumeLayout(false);
            this.tabPage54.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).EndInit();
            this.tabPage55.ResumeLayout(false);
            this.tabPage55.PerformLayout();
            this.mnPlaylist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox mmInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDVDSubtitles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDVDAudio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edDVDVideo;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btDVDControlRootMenu;
        private System.Windows.Forms.Button btDVDControlTitleMenu;
        private System.Windows.Forms.ComboBox cbDVDControlSubtitles;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbDVDControlAudio;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbDVDControlChapter;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbDVDControlTitle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lbDVDTitles;
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
        private System.Windows.Forms.TabControl tabControl13;
        private System.Windows.Forms.TabPage tabPage54;
        private System.Windows.Forms.ComboBox cbImageType;
        private System.Windows.Forms.Label lbJPEGQuality;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Button btSelectScreenshotsFolder;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox edScreenshotsFolder;
        private System.Windows.Forms.TrackBar tbJPEGQuality;
        private System.Windows.Forms.TabPage tabPage55;
        private System.Windows.Forms.TextBox edScreenshotHeight;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.TextBox edScreenshotWidth;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.CheckBox cbScreenshotResize;
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
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox edCustomSourceFilter;
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
        private System.Windows.Forms.CheckBox cbTelemetry;
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
        private System.Windows.Forms.RadioButton rbVirtualCameraOutput;
        private System.Windows.Forms.Panel pnChromaKeyColor;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.RadioButton rbNDIStreaming;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}