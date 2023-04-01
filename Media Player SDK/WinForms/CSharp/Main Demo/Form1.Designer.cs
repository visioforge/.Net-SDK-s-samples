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
            this.components = (new global::System.ComponentModel.Container());
            global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Media_Player_Demo.Form1));
            this.tabControl1 = (new global::System.Windows.Forms.TabControl());
            this.tabPage20 = (new global::System.Windows.Forms.TabPage());
            this.groupBox6 = (new global::System.Windows.Forms.GroupBox());
            this.rbGPUDirect3D = (new global::System.Windows.Forms.RadioButton());
            this.rbGPUDXVANative = (new global::System.Windows.Forms.RadioButton());
            this.rbGPUDXVACopyBack = (new global::System.Windows.Forms.RadioButton());
            this.rbGPUIntel = (new global::System.Windows.Forms.RadioButton());
            this.rbGPUNVidia = (new global::System.Windows.Forms.RadioButton());
            this.tabPage1 = (new global::System.Windows.Forms.TabPage());
            this.cbUseLibMediaInfo = (new global::System.Windows.Forms.CheckBox());
            this.btReadInfo = (new global::System.Windows.Forms.Button());
            this.tabControl2 = (new global::System.Windows.Forms.TabControl());
            this.tabPage6 = (new global::System.Windows.Forms.TabPage());
            this.mmInfo = (new global::System.Windows.Forms.TextBox());
            this.tabPage49 = (new global::System.Windows.Forms.TabPage());
            this.imgTags = (new global::System.Windows.Forms.PictureBox());
            this.edTags = (new global::System.Windows.Forms.TextBox());
            this.btReadTags = (new global::System.Windows.Forms.Button());
            this.tabPage2 = (new global::System.Windows.Forms.TabPage());
            this.label10 = (new global::System.Windows.Forms.Label());
            this.tbBalance4 = (new global::System.Windows.Forms.TrackBar());
            this.label11 = (new global::System.Windows.Forms.Label());
            this.tbVolume4 = (new global::System.Windows.Forms.TrackBar());
            this.cbAudioStream4 = (new global::System.Windows.Forms.CheckBox());
            this.label12 = (new global::System.Windows.Forms.Label());
            this.tbBalance3 = (new global::System.Windows.Forms.TrackBar());
            this.label13 = (new global::System.Windows.Forms.Label());
            this.tbVolume3 = (new global::System.Windows.Forms.TrackBar());
            this.cbAudioStream3 = (new global::System.Windows.Forms.CheckBox());
            this.label8 = (new global::System.Windows.Forms.Label());
            this.tbBalance2 = (new global::System.Windows.Forms.TrackBar());
            this.label9 = (new global::System.Windows.Forms.Label());
            this.tbVolume2 = (new global::System.Windows.Forms.TrackBar());
            this.cbAudioStream2 = (new global::System.Windows.Forms.CheckBox());
            this.label7 = (new global::System.Windows.Forms.Label());
            this.tbBalance1 = (new global::System.Windows.Forms.TrackBar());
            this.label6 = (new global::System.Windows.Forms.Label());
            this.tbVolume1 = (new global::System.Windows.Forms.TrackBar());
            this.cbAudioStream1 = (new global::System.Windows.Forms.CheckBox());
            this.cbPlayAudio = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioOutputDevice = (new global::System.Windows.Forms.ComboBox());
            this.label5 = (new global::System.Windows.Forms.Label());
            this.tabPage3 = (new global::System.Windows.Forms.TabPage());
            this.tabControl4 = (new global::System.Windows.Forms.TabControl());
            this.tabPage16 = (new global::System.Windows.Forms.TabPage());
            this.label393 = (new global::System.Windows.Forms.Label());
            this.cbDirect2DRotate = (new global::System.Windows.Forms.ComboBox());
            this.pnVideoRendererBGColor = (new global::System.Windows.Forms.Panel());
            this.label394 = (new global::System.Windows.Forms.Label());
            this.btFullScreen = (new global::System.Windows.Forms.Button());
            this.groupBox28 = (new global::System.Windows.Forms.GroupBox());
            this.btZoomReset = (new global::System.Windows.Forms.Button());
            this.btZoomShiftRight = (new global::System.Windows.Forms.Button());
            this.btZoomShiftLeft = (new global::System.Windows.Forms.Button());
            this.btZoomOut = (new global::System.Windows.Forms.Button());
            this.btZoomIn = (new global::System.Windows.Forms.Button());
            this.btZoomShiftDown = (new global::System.Windows.Forms.Button());
            this.btZoomShiftUp = (new global::System.Windows.Forms.Button());
            this.cbScreenFlipVertical = (new global::System.Windows.Forms.CheckBox());
            this.cbScreenFlipHorizontal = (new global::System.Windows.Forms.CheckBox());
            this.cbStretch = (new global::System.Windows.Forms.CheckBox());
            this.groupBox13 = (new global::System.Windows.Forms.GroupBox());
            this.rbNDIStreaming = (new global::System.Windows.Forms.RadioButton());
            this.rbVirtualCameraOutput = (new global::System.Windows.Forms.RadioButton());
            this.rbMadVR = (new global::System.Windows.Forms.RadioButton());
            this.rbDirect2D = (new global::System.Windows.Forms.RadioButton());
            this.rbNone = (new global::System.Windows.Forms.RadioButton());
            this.rbEVR = (new global::System.Windows.Forms.RadioButton());
            this.rbVMR9 = (new global::System.Windows.Forms.RadioButton());
            this.label15 = (new global::System.Windows.Forms.Label());
            this.edAspectRatioY = (new global::System.Windows.Forms.TextBox());
            this.edAspectRatioX = (new global::System.Windows.Forms.TextBox());
            this.cbAspectRatioUseCustom = (new global::System.Windows.Forms.CheckBox());
            this.tabPage17 = (new global::System.Windows.Forms.TabPage());
            this.cbMultiscreenDrawOnExternalDisplays = (new global::System.Windows.Forms.CheckBox());
            this.cbMultiscreenDrawOnPanels = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipHorizontal2 = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipVertical2 = (new global::System.Windows.Forms.CheckBox());
            this.cbStretch2 = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipHorizontal1 = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipVertical1 = (new global::System.Windows.Forms.CheckBox());
            this.cbStretch1 = (new global::System.Windows.Forms.CheckBox());
            this.pnScreen2 = (new global::System.Windows.Forms.Panel());
            this.pnScreen1 = (new global::System.Windows.Forms.Panel());
            this.tabPage4 = (new global::System.Windows.Forms.TabPage());
            this.tabControl17 = (new global::System.Windows.Forms.TabControl());
            this.tabPage68 = (new global::System.Windows.Forms.TabPage());
            this.cbScrollingText = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipY = (new global::System.Windows.Forms.CheckBox());
            this.cbFlipX = (new global::System.Windows.Forms.CheckBox());
            this.label201 = (new global::System.Windows.Forms.Label());
            this.label200 = (new global::System.Windows.Forms.Label());
            this.label199 = (new global::System.Windows.Forms.Label());
            this.label198 = (new global::System.Windows.Forms.Label());
            this.tabControl7 = (new global::System.Windows.Forms.TabControl());
            this.tabPage29 = (new global::System.Windows.Forms.TabPage());
            this.btTextLogoRemove = (new global::System.Windows.Forms.Button());
            this.btTextLogoEdit = (new global::System.Windows.Forms.Button());
            this.lbTextLogos = (new global::System.Windows.Forms.ListBox());
            this.btTextLogoAdd = (new global::System.Windows.Forms.Button());
            this.tabPage42 = (new global::System.Windows.Forms.TabPage());
            this.btImageLogoRemove = (new global::System.Windows.Forms.Button());
            this.btImageLogoEdit = (new global::System.Windows.Forms.Button());
            this.lbImageLogos = (new global::System.Windows.Forms.ListBox());
            this.btImageLogoAdd = (new global::System.Windows.Forms.Button());
            this.tabPage18 = (new global::System.Windows.Forms.TabPage());
            this.groupBox37 = (new global::System.Windows.Forms.GroupBox());
            this.btEffZoomRight = (new global::System.Windows.Forms.Button());
            this.btEffZoomLeft = (new global::System.Windows.Forms.Button());
            this.btEffZoomOut = (new global::System.Windows.Forms.Button());
            this.btEffZoomIn = (new global::System.Windows.Forms.Button());
            this.btEffZoomDown = (new global::System.Windows.Forms.Button());
            this.btEffZoomUp = (new global::System.Windows.Forms.Button());
            this.cbZoom = (new global::System.Windows.Forms.CheckBox());
            this.tabPage19 = (new global::System.Windows.Forms.TabPage());
            this.groupBox40 = (new global::System.Windows.Forms.GroupBox());
            this.edPanDestHeight = (new global::System.Windows.Forms.TextBox());
            this.label302 = (new global::System.Windows.Forms.Label());
            this.edPanDestWidth = (new global::System.Windows.Forms.TextBox());
            this.label303 = (new global::System.Windows.Forms.Label());
            this.edPanDestTop = (new global::System.Windows.Forms.TextBox());
            this.label304 = (new global::System.Windows.Forms.Label());
            this.edPanDestLeft = (new global::System.Windows.Forms.TextBox());
            this.label305 = (new global::System.Windows.Forms.Label());
            this.groupBox39 = (new global::System.Windows.Forms.GroupBox());
            this.edPanSourceHeight = (new global::System.Windows.Forms.TextBox());
            this.label298 = (new global::System.Windows.Forms.Label());
            this.edPanSourceWidth = (new global::System.Windows.Forms.TextBox());
            this.label299 = (new global::System.Windows.Forms.Label());
            this.edPanSourceTop = (new global::System.Windows.Forms.TextBox());
            this.label300 = (new global::System.Windows.Forms.Label());
            this.edPanSourceLeft = (new global::System.Windows.Forms.TextBox());
            this.label301 = (new global::System.Windows.Forms.Label());
            this.groupBox38 = (new global::System.Windows.Forms.GroupBox());
            this.edPanStopTime = (new global::System.Windows.Forms.TextBox());
            this.label296 = (new global::System.Windows.Forms.Label());
            this.edPanStartTime = (new global::System.Windows.Forms.TextBox());
            this.label297 = (new global::System.Windows.Forms.Label());
            this.cbPan = (new global::System.Windows.Forms.CheckBox());
            this.tabPage22 = (new global::System.Windows.Forms.TabPage());
            this.rbFadeOut = (new global::System.Windows.Forms.RadioButton());
            this.rbFadeIn = (new global::System.Windows.Forms.RadioButton());
            this.groupBox45 = (new global::System.Windows.Forms.GroupBox());
            this.edFadeInOutStopTime = (new global::System.Windows.Forms.TextBox());
            this.label329 = (new global::System.Windows.Forms.Label());
            this.edFadeInOutStartTime = (new global::System.Windows.Forms.TextBox());
            this.label330 = (new global::System.Windows.Forms.Label());
            this.cbFadeInOut = (new global::System.Windows.Forms.CheckBox());
            this.tabPage43 = (new global::System.Windows.Forms.TabPage());
            this.cbLiveRotationStretch = (new global::System.Windows.Forms.CheckBox());
            this.label392 = (new global::System.Windows.Forms.Label());
            this.label391 = (new global::System.Windows.Forms.Label());
            this.tbLiveRotationAngle = (new global::System.Windows.Forms.TrackBar());
            this.label390 = (new global::System.Windows.Forms.Label());
            this.cbLiveRotation = (new global::System.Windows.Forms.CheckBox());
            this.tbContrast = (new global::System.Windows.Forms.TrackBar());
            this.tbDarkness = (new global::System.Windows.Forms.TrackBar());
            this.tbLightness = (new global::System.Windows.Forms.TrackBar());
            this.tbSaturation = (new global::System.Windows.Forms.TrackBar());
            this.cbInvert = (new global::System.Windows.Forms.CheckBox());
            this.cbGreyscale = (new global::System.Windows.Forms.CheckBox());
            this.cbVideoEffects = (new global::System.Windows.Forms.CheckBox());
            this.tabPage69 = (new global::System.Windows.Forms.TabPage());
            this.label211 = (new global::System.Windows.Forms.Label());
            this.edDeintTriangleWeight = (new global::System.Windows.Forms.TextBox());
            this.label212 = (new global::System.Windows.Forms.Label());
            this.label210 = (new global::System.Windows.Forms.Label());
            this.label209 = (new global::System.Windows.Forms.Label());
            this.label206 = (new global::System.Windows.Forms.Label());
            this.edDeintBlendConstants2 = (new global::System.Windows.Forms.TextBox());
            this.label207 = (new global::System.Windows.Forms.Label());
            this.edDeintBlendConstants1 = (new global::System.Windows.Forms.TextBox());
            this.label208 = (new global::System.Windows.Forms.Label());
            this.label204 = (new global::System.Windows.Forms.Label());
            this.edDeintBlendThreshold2 = (new global::System.Windows.Forms.TextBox());
            this.label205 = (new global::System.Windows.Forms.Label());
            this.edDeintBlendThreshold1 = (new global::System.Windows.Forms.TextBox());
            this.label203 = (new global::System.Windows.Forms.Label());
            this.label202 = (new global::System.Windows.Forms.Label());
            this.edDeintCAVTThreshold = (new global::System.Windows.Forms.TextBox());
            this.label104 = (new global::System.Windows.Forms.Label());
            this.rbDeintTriangleEnabled = (new global::System.Windows.Forms.RadioButton());
            this.rbDeintBlendEnabled = (new global::System.Windows.Forms.RadioButton());
            this.rbDeintCAVTEnabled = (new global::System.Windows.Forms.RadioButton());
            this.cbDeinterlace = (new global::System.Windows.Forms.CheckBox());
            this.tabPage59 = (new global::System.Windows.Forms.TabPage());
            this.rbDenoiseCAST = (new global::System.Windows.Forms.RadioButton());
            this.rbDenoiseMosquito = (new global::System.Windows.Forms.RadioButton());
            this.cbDenoise = (new global::System.Windows.Forms.CheckBox());
            this.tabPage51 = (new global::System.Windows.Forms.TabPage());
            this.label22 = (new global::System.Windows.Forms.Label());
            this.tbGPUBlur = (new global::System.Windows.Forms.TrackBar());
            this.cbVideoEffectsGPUEnabled = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUOldMovie = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUDeinterlace = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUDenoise = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUPixelate = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUNightVision = (new global::System.Windows.Forms.CheckBox());
            this.label383 = (new global::System.Windows.Forms.Label());
            this.label384 = (new global::System.Windows.Forms.Label());
            this.label385 = (new global::System.Windows.Forms.Label());
            this.label386 = (new global::System.Windows.Forms.Label());
            this.tbGPUContrast = (new global::System.Windows.Forms.TrackBar());
            this.tbGPUDarkness = (new global::System.Windows.Forms.TrackBar());
            this.tbGPULightness = (new global::System.Windows.Forms.TrackBar());
            this.tbGPUSaturation = (new global::System.Windows.Forms.TrackBar());
            this.cbGPUInvert = (new global::System.Windows.Forms.CheckBox());
            this.cbGPUGreyscale = (new global::System.Windows.Forms.CheckBox());
            this.tabPage8 = (new global::System.Windows.Forms.TabPage());
            this.lbAdjSaturationCurrent = (new global::System.Windows.Forms.Label());
            this.lbAdjSaturationMax = (new global::System.Windows.Forms.Label());
            this.lbAdjSaturationMin = (new global::System.Windows.Forms.Label());
            this.tbAdjSaturation = (new global::System.Windows.Forms.TrackBar());
            this.label45 = (new global::System.Windows.Forms.Label());
            this.lbAdjHueCurrent = (new global::System.Windows.Forms.Label());
            this.lbAdjHueMax = (new global::System.Windows.Forms.Label());
            this.lbAdjHueMin = (new global::System.Windows.Forms.Label());
            this.tbAdjHue = (new global::System.Windows.Forms.TrackBar());
            this.label41 = (new global::System.Windows.Forms.Label());
            this.lbAdjContrastCurrent = (new global::System.Windows.Forms.Label());
            this.lbAdjContrastMax = (new global::System.Windows.Forms.Label());
            this.lbAdjContrastMin = (new global::System.Windows.Forms.Label());
            this.tbAdjContrast = (new global::System.Windows.Forms.TrackBar());
            this.label23 = (new global::System.Windows.Forms.Label());
            this.lbAdjBrightnessCurrent = (new global::System.Windows.Forms.Label());
            this.lbAdjBrightnessMax = (new global::System.Windows.Forms.Label());
            this.lbAdjBrightnessMin = (new global::System.Windows.Forms.Label());
            this.tbAdjBrightness = (new global::System.Windows.Forms.TrackBar());
            this.label24 = (new global::System.Windows.Forms.Label());
            this.tabPage15 = (new global::System.Windows.Forms.TabPage());
            this.pnChromaKeyColor = (new global::System.Windows.Forms.Panel());
            this.btChromaKeySelectBGImage = (new global::System.Windows.Forms.Button());
            this.edChromaKeyImage = (new global::System.Windows.Forms.TextBox());
            this.label216 = (new global::System.Windows.Forms.Label());
            this.label215 = (new global::System.Windows.Forms.Label());
            this.tbChromaKeySmoothing = (new global::System.Windows.Forms.TrackBar());
            this.label214 = (new global::System.Windows.Forms.Label());
            this.tbChromaKeyThresholdSensitivity = (new global::System.Windows.Forms.TrackBar());
            this.label213 = (new global::System.Windows.Forms.Label());
            this.cbChromaKeyEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage46 = (new global::System.Windows.Forms.TabPage());
            this.btFilterDelete = (new global::System.Windows.Forms.Button());
            this.btFilterDeleteAll = (new global::System.Windows.Forms.Button());
            this.btFilterSettings2 = (new global::System.Windows.Forms.Button());
            this.lbFilters = (new global::System.Windows.Forms.ListBox());
            this.label106 = (new global::System.Windows.Forms.Label());
            this.btFilterSettings = (new global::System.Windows.Forms.Button());
            this.btFilterAdd = (new global::System.Windows.Forms.Button());
            this.cbFilters = (new global::System.Windows.Forms.ComboBox());
            this.label105 = (new global::System.Windows.Forms.Label());
            this.tabPage48 = (new global::System.Windows.Forms.TabPage());
            this.lbAudioTimeshift = (new global::System.Windows.Forms.Label());
            this.tbAudioTimeshift = (new global::System.Windows.Forms.TrackBar());
            this.label70 = (new global::System.Windows.Forms.Label());
            this.groupBox4 = (new global::System.Windows.Forms.GroupBox());
            this.lbAudioOutputGainLFE = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainLFE = (new global::System.Windows.Forms.TrackBar());
            this.label55 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainSR = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainSR = (new global::System.Windows.Forms.TrackBar());
            this.label57 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainSL = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainSL = (new global::System.Windows.Forms.TrackBar());
            this.label59 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainR = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainR = (new global::System.Windows.Forms.TrackBar());
            this.label61 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainC = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainC = (new global::System.Windows.Forms.TrackBar());
            this.label67 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainL = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainL = (new global::System.Windows.Forms.TrackBar());
            this.label69 = (new global::System.Windows.Forms.Label());
            this.groupBox1 = (new global::System.Windows.Forms.GroupBox());
            this.lbAudioInputGainLFE = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainLFE = (new global::System.Windows.Forms.TrackBar());
            this.label53 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainSR = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainSR = (new global::System.Windows.Forms.TrackBar());
            this.label51 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainSL = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainSL = (new global::System.Windows.Forms.TrackBar());
            this.label49 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainR = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainR = (new global::System.Windows.Forms.TrackBar());
            this.label47 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainC = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainC = (new global::System.Windows.Forms.TrackBar());
            this.label44 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainL = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainL = (new global::System.Windows.Forms.TrackBar());
            this.label40 = (new global::System.Windows.Forms.Label());
            this.cbAudioAutoGain = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioNormalize = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioEnhancementEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage11 = (new global::System.Windows.Forms.TabPage());
            this.label31 = (new global::System.Windows.Forms.Label());
            this.tabControl18 = (new global::System.Windows.Forms.TabControl());
            this.tabPage71 = (new global::System.Windows.Forms.TabPage());
            this.label231 = (new global::System.Windows.Forms.Label());
            this.label230 = (new global::System.Windows.Forms.Label());
            this.tbAudAmplifyAmp = (new global::System.Windows.Forms.TrackBar());
            this.label95 = (new global::System.Windows.Forms.Label());
            this.cbAudAmplifyEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage72 = (new global::System.Windows.Forms.TabPage());
            this.btAudEqRefresh = (new global::System.Windows.Forms.Button());
            this.cbAudEqualizerPreset = (new global::System.Windows.Forms.ComboBox());
            this.label243 = (new global::System.Windows.Forms.Label());
            this.label242 = (new global::System.Windows.Forms.Label());
            this.label241 = (new global::System.Windows.Forms.Label());
            this.label240 = (new global::System.Windows.Forms.Label());
            this.label239 = (new global::System.Windows.Forms.Label());
            this.label238 = (new global::System.Windows.Forms.Label());
            this.label237 = (new global::System.Windows.Forms.Label());
            this.label236 = (new global::System.Windows.Forms.Label());
            this.label235 = (new global::System.Windows.Forms.Label());
            this.label234 = (new global::System.Windows.Forms.Label());
            this.label233 = (new global::System.Windows.Forms.Label());
            this.label232 = (new global::System.Windows.Forms.Label());
            this.tbAudEq9 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq8 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq7 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq6 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq5 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq4 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq3 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq2 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq1 = (new global::System.Windows.Forms.TrackBar());
            this.tbAudEq0 = (new global::System.Windows.Forms.TrackBar());
            this.cbAudEqualizerEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage73 = (new global::System.Windows.Forms.TabPage());
            this.tbAudRelease = (new global::System.Windows.Forms.TrackBar());
            this.label248 = (new global::System.Windows.Forms.Label());
            this.label249 = (new global::System.Windows.Forms.Label());
            this.label246 = (new global::System.Windows.Forms.Label());
            this.tbAudAttack = (new global::System.Windows.Forms.TrackBar());
            this.label247 = (new global::System.Windows.Forms.Label());
            this.label244 = (new global::System.Windows.Forms.Label());
            this.tbAudDynAmp = (new global::System.Windows.Forms.TrackBar());
            this.label245 = (new global::System.Windows.Forms.Label());
            this.cbAudDynamicAmplifyEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage75 = (new global::System.Windows.Forms.TabPage());
            this.tbAud3DSound = (new global::System.Windows.Forms.TrackBar());
            this.label253 = (new global::System.Windows.Forms.Label());
            this.cbAudSound3DEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage76 = (new global::System.Windows.Forms.TabPage());
            this.tbAudTrueBass = (new global::System.Windows.Forms.TrackBar());
            this.label254 = (new global::System.Windows.Forms.Label());
            this.cbAudTrueBassEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage27 = (new global::System.Windows.Forms.TabPage());
            this.tbAudPitchShift = (new global::System.Windows.Forms.TrackBar());
            this.label36 = (new global::System.Windows.Forms.Label());
            this.cbAudPitchShiftEnabled = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioEffectsEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage50 = (new global::System.Windows.Forms.TabPage());
            this.btAudioChannelMapperClear = (new global::System.Windows.Forms.Button());
            this.groupBox41 = (new global::System.Windows.Forms.GroupBox());
            this.btAudioChannelMapperAddNewRoute = (new global::System.Windows.Forms.Button());
            this.label311 = (new global::System.Windows.Forms.Label());
            this.tbAudioChannelMapperVolume = (new global::System.Windows.Forms.TrackBar());
            this.label310 = (new global::System.Windows.Forms.Label());
            this.edAudioChannelMapperTargetChannel = (new global::System.Windows.Forms.TextBox());
            this.label309 = (new global::System.Windows.Forms.Label());
            this.edAudioChannelMapperSourceChannel = (new global::System.Windows.Forms.TextBox());
            this.label308 = (new global::System.Windows.Forms.Label());
            this.label307 = (new global::System.Windows.Forms.Label());
            this.edAudioChannelMapperOutputChannels = (new global::System.Windows.Forms.TextBox());
            this.label306 = (new global::System.Windows.Forms.Label());
            this.lbAudioChannelMapperRoutes = (new global::System.Windows.Forms.ListBox());
            this.cbAudioChannelMapperEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage28 = (new global::System.Windows.Forms.TabPage());
            this.tbVUMeterBoost = (new global::System.Windows.Forms.TrackBar());
            this.label382 = (new global::System.Windows.Forms.Label());
            this.label381 = (new global::System.Windows.Forms.Label());
            this.tbVUMeterAmplification = (new global::System.Windows.Forms.TrackBar());
            this.cbVUMeterPro = (new global::System.Windows.Forms.CheckBox());
            this.waveformPainter2 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter());
            this.waveformPainter1 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter());
            this.volumeMeter2 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.volumeMeter1 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.tabPage5 = (new global::System.Windows.Forms.TabPage());
            this.btOSDRenderLayers = (new global::System.Windows.Forms.Button());
            this.lbOSDLayers = (new global::System.Windows.Forms.CheckedListBox());
            this.cbOSDEnabled = (new global::System.Windows.Forms.CheckBox());
            this.groupBox19 = (new global::System.Windows.Forms.GroupBox());
            this.btOSDClearLayer = (new global::System.Windows.Forms.Button());
            this.tabControl6 = (new global::System.Windows.Forms.TabControl());
            this.tabPage30 = (new global::System.Windows.Forms.TabPage());
            this.btOSDImageDraw = (new global::System.Windows.Forms.Button());
            this.pnOSDColorKey = (new global::System.Windows.Forms.Panel());
            this.cbOSDImageTranspColor = (new global::System.Windows.Forms.CheckBox());
            this.edOSDImageTop = (new global::System.Windows.Forms.TextBox());
            this.label115 = (new global::System.Windows.Forms.Label());
            this.edOSDImageLeft = (new global::System.Windows.Forms.TextBox());
            this.label114 = (new global::System.Windows.Forms.Label());
            this.btOSDSelectImage = (new global::System.Windows.Forms.Button());
            this.edOSDImageFilename = (new global::System.Windows.Forms.TextBox());
            this.label113 = (new global::System.Windows.Forms.Label());
            this.tabPage31 = (new global::System.Windows.Forms.TabPage());
            this.edOSDTextTop = (new global::System.Windows.Forms.TextBox());
            this.label117 = (new global::System.Windows.Forms.Label());
            this.edOSDTextLeft = (new global::System.Windows.Forms.TextBox());
            this.label118 = (new global::System.Windows.Forms.Label());
            this.label116 = (new global::System.Windows.Forms.Label());
            this.btOSDSelectFont = (new global::System.Windows.Forms.Button());
            this.edOSDText = (new global::System.Windows.Forms.TextBox());
            this.btOSDTextDraw = (new global::System.Windows.Forms.Button());
            this.tabPage32 = (new global::System.Windows.Forms.TabPage());
            this.tbOSDTranspLevel = (new global::System.Windows.Forms.TrackBar());
            this.btOSDSetTransp = (new global::System.Windows.Forms.Button());
            this.label119 = (new global::System.Windows.Forms.Label());
            this.btOSDClearLayers = (new global::System.Windows.Forms.Button());
            this.groupBox15 = (new global::System.Windows.Forms.GroupBox());
            this.btOSDLayerAdd = (new global::System.Windows.Forms.Button());
            this.edOSDLayerHeight = (new global::System.Windows.Forms.TextBox());
            this.label111 = (new global::System.Windows.Forms.Label());
            this.edOSDLayerWidth = (new global::System.Windows.Forms.TextBox());
            this.label112 = (new global::System.Windows.Forms.Label());
            this.edOSDLayerTop = (new global::System.Windows.Forms.TextBox());
            this.label110 = (new global::System.Windows.Forms.Label());
            this.edOSDLayerLeft = (new global::System.Windows.Forms.TextBox());
            this.label109 = (new global::System.Windows.Forms.Label());
            this.label108 = (new global::System.Windows.Forms.Label());
            this.tabPage12 = (new global::System.Windows.Forms.TabPage());
            this.tabControl5 = (new global::System.Windows.Forms.TabControl());
            this.tabPage33 = (new global::System.Windows.Forms.TabPage());
            this.cbCustomSplitter = (new global::System.Windows.Forms.ComboBox());
            this.rbSplitterCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbSplitterDefault = (new global::System.Windows.Forms.RadioButton());
            this.tabPage34 = (new global::System.Windows.Forms.TabPage());
            this.rbVideoDecoderVFH264 = (new global::System.Windows.Forms.RadioButton());
            this.cbCustomVideoDecoder = (new global::System.Windows.Forms.ComboBox());
            this.label28 = (new global::System.Windows.Forms.Label());
            this.label27 = (new global::System.Windows.Forms.Label());
            this.label26 = (new global::System.Windows.Forms.Label());
            this.rbVideoDecoderCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbVideoDecoderFFDShow = (new global::System.Windows.Forms.RadioButton());
            this.rbVideoDecoderMS = (new global::System.Windows.Forms.RadioButton());
            this.rbVideoDecoderDefault = (new global::System.Windows.Forms.RadioButton());
            this.tabPage47 = (new global::System.Windows.Forms.TabPage());
            this.cbCustomAudioDecoder = (new global::System.Windows.Forms.ComboBox());
            this.rbAudioDecoderCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbAudioDecoderDefault = (new global::System.Windows.Forms.RadioButton());
            this.tabPage13 = (new global::System.Windows.Forms.TabPage());
            this.tabControl9 = (new global::System.Windows.Forms.TabControl());
            this.tabPage44 = (new global::System.Windows.Forms.TabPage());
            this.pbMotionLevel = (new global::System.Windows.Forms.ProgressBar());
            this.label158 = (new global::System.Windows.Forms.Label());
            this.mmMotDetMatrix = (new global::System.Windows.Forms.TextBox());
            this.tabPage45 = (new global::System.Windows.Forms.TabPage());
            this.groupBox25 = (new global::System.Windows.Forms.GroupBox());
            this.cbMotDetHLColor = (new global::System.Windows.Forms.ComboBox());
            this.label161 = (new global::System.Windows.Forms.Label());
            this.label160 = (new global::System.Windows.Forms.Label());
            this.cbMotDetHLEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tbMotDetHLThreshold = (new global::System.Windows.Forms.TrackBar());
            this.btMotDetUpdateSettings = (new global::System.Windows.Forms.Button());
            this.groupBox27 = (new global::System.Windows.Forms.GroupBox());
            this.edMotDetMatrixHeight = (new global::System.Windows.Forms.TextBox());
            this.label163 = (new global::System.Windows.Forms.Label());
            this.edMotDetMatrixWidth = (new global::System.Windows.Forms.TextBox());
            this.label164 = (new global::System.Windows.Forms.Label());
            this.groupBox26 = (new global::System.Windows.Forms.GroupBox());
            this.label162 = (new global::System.Windows.Forms.Label());
            this.tbMotDetDropFramesThreshold = (new global::System.Windows.Forms.TrackBar());
            this.cbMotDetDropFramesEnabled = (new global::System.Windows.Forms.CheckBox());
            this.groupBox24 = (new global::System.Windows.Forms.GroupBox());
            this.edMotDetFrameInterval = (new global::System.Windows.Forms.TextBox());
            this.label159 = (new global::System.Windows.Forms.Label());
            this.cbCompareGreyscale = (new global::System.Windows.Forms.CheckBox());
            this.cbCompareBlue = (new global::System.Windows.Forms.CheckBox());
            this.cbCompareGreen = (new global::System.Windows.Forms.CheckBox());
            this.cbCompareRed = (new global::System.Windows.Forms.CheckBox());
            this.cbMotDetEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage14 = (new global::System.Windows.Forms.TabPage());
            this.label505 = (new global::System.Windows.Forms.Label());
            this.rbMotionDetectionExProcessor = (new global::System.Windows.Forms.ComboBox());
            this.label389 = (new global::System.Windows.Forms.Label());
            this.rbMotionDetectionExDetector = (new global::System.Windows.Forms.ComboBox());
            this.label64 = (new global::System.Windows.Forms.Label());
            this.label65 = (new global::System.Windows.Forms.Label());
            this.pbAFMotionLevel = (new global::System.Windows.Forms.ProgressBar());
            this.cbMotionDetectionEx = (new global::System.Windows.Forms.CheckBox());
            this.tabPage21 = (new global::System.Windows.Forms.TabPage());
            this.edBarcodeMetadata = (new global::System.Windows.Forms.TextBox());
            this.label91 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeType = (new global::System.Windows.Forms.ComboBox());
            this.label90 = (new global::System.Windows.Forms.Label());
            this.btBarcodeReset = (new global::System.Windows.Forms.Button());
            this.edBarcode = (new global::System.Windows.Forms.TextBox());
            this.label89 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeDetectionEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage23 = (new global::System.Windows.Forms.TabPage());
            this.textBox1 = (new global::System.Windows.Forms.TextBox());
            this.groupBox48 = (new global::System.Windows.Forms.GroupBox());
            this.label343 = (new global::System.Windows.Forms.Label());
            this.edEncryptionKeyHEX = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyBinary = (new global::System.Windows.Forms.RadioButton());
            this.btEncryptionOpenFile = (new global::System.Windows.Forms.Button());
            this.edEncryptionKeyFile = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyFile = (new global::System.Windows.Forms.RadioButton());
            this.edEncryptionKeyString = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyString = (new global::System.Windows.Forms.RadioButton());
            this.tabPage24 = (new global::System.Windows.Forms.TabPage());
            this.btReversePlaybackNextFrame = (new global::System.Windows.Forms.Button());
            this.btReversePlaybackPrevFrame = (new global::System.Windows.Forms.Button());
            this.label34 = (new global::System.Windows.Forms.Label());
            this.label33 = (new global::System.Windows.Forms.Label());
            this.btReversePlayback = (new global::System.Windows.Forms.Button());
            this.edReversePlaybackCacheSize = (new global::System.Windows.Forms.TextBox());
            this.label32 = (new global::System.Windows.Forms.Label());
            this.tbReversePlaybackTrackbar = (new global::System.Windows.Forms.TrackBar());
            this.label14 = (new global::System.Windows.Forms.Label());
            this.edFilenameOrURL = (new global::System.Windows.Forms.TextBox());
            this.btSelectFile = (new global::System.Windows.Forms.Button());
            this.groupBox2 = (new global::System.Windows.Forms.GroupBox());
            this.btPreviousFrame = (new global::System.Windows.Forms.Button());
            this.cbLoop = (new global::System.Windows.Forms.CheckBox());
            this.btNextFrame = (new global::System.Windows.Forms.Button());
            this.btStop = (new global::System.Windows.Forms.Button());
            this.btPause = (new global::System.Windows.Forms.Button());
            this.btResume = (new global::System.Windows.Forms.Button());
            this.btStart = (new global::System.Windows.Forms.Button());
            this.tbSpeed = (new global::System.Windows.Forms.TrackBar());
            this.label16 = (new global::System.Windows.Forms.Label());
            this.lbTime = (new global::System.Windows.Forms.Label());
            this.tbTimeline = (new global::System.Windows.Forms.TrackBar());
            this.tabControl3 = (new global::System.Windows.Forms.TabControl());
            this.tabPage10 = (new global::System.Windows.Forms.TabPage());
            this.cbTelemetry = (new global::System.Windows.Forms.CheckBox());
            this.mmLog = (new global::System.Windows.Forms.TextBox());
            this.cbDebugMode = (new global::System.Windows.Forms.CheckBox());
            this.tabPage9 = (new global::System.Windows.Forms.TabPage());
            this.tabControl13 = (new global::System.Windows.Forms.TabControl());
            this.tabPage54 = (new global::System.Windows.Forms.TabPage());
            this.cbImageType = (new global::System.Windows.Forms.ComboBox());
            this.lbJPEGQuality = (new global::System.Windows.Forms.Label());
            this.label38 = (new global::System.Windows.Forms.Label());
            this.btSaveScreenshot = (new global::System.Windows.Forms.Button());
            this.btSelectScreenshotsFolder = (new global::System.Windows.Forms.Button());
            this.label63 = (new global::System.Windows.Forms.Label());
            this.edScreenshotsFolder = (new global::System.Windows.Forms.TextBox());
            this.tbJPEGQuality = (new global::System.Windows.Forms.TrackBar());
            this.tabPage55 = (new global::System.Windows.Forms.TabPage());
            this.edScreenshotHeight = (new global::System.Windows.Forms.TextBox());
            this.label176 = (new global::System.Windows.Forms.Label());
            this.edScreenshotWidth = (new global::System.Windows.Forms.TextBox());
            this.label177 = (new global::System.Windows.Forms.Label());
            this.cbScreenshotResize = (new global::System.Windows.Forms.CheckBox());
            this.openFileDialog1 = (new global::System.Windows.Forms.OpenFileDialog());
            this.fontDialog1 = (new global::System.Windows.Forms.FontDialog());
            this.openFileDialog2 = (new global::System.Windows.Forms.OpenFileDialog());
            this.folderBrowserDialog1 = (new global::System.Windows.Forms.FolderBrowserDialog());
            this.colorDialog1 = (new global::System.Windows.Forms.ColorDialog());
            this.timer1 = (new global::System.Windows.Forms.Timer(this.components));
            this.label29 = (new global::System.Windows.Forms.Label());
            this.cbSourceMode = (new global::System.Windows.Forms.ComboBox());
            this.lbSourceFiles = (new global::System.Windows.Forms.ListBox());
            this.mnPlaylist = (new global::System.Windows.Forms.ContextMenuStrip(this.components));
            this.mnPlaylistRemove = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.mnPlaylistRemoveAll = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.label30 = (new global::System.Windows.Forms.Label());
            this.btAddFileToPlaylist = (new global::System.Windows.Forms.Button());
            this.linkLabel1 = (new global::System.Windows.Forms.LinkLabel());
            this.label37 = (new global::System.Windows.Forms.Label());
            this.edCustomSourceFilter = (new global::System.Windows.Forms.TextBox());
            this.VideoView1 = (new global::VisioForge.Core.UI.WinForms.VideoView());
            this.tabControl1.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage49.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgTags)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance4)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume4)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance3)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume3)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance2)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume2)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance1)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage69.SuspendLayout();
            this.tabPage59.SuspendLayout();
            this.tabPage51.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).BeginInit();
            this.tabPage46.SuspendLayout();
            this.tabPage48.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.tabControl18.SuspendLayout();
            this.tabPage71.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).BeginInit();
            this.tabPage72.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).BeginInit();
            this.tabPage73.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudRelease)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudAttack)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudDynAmp)).BeginInit();
            this.tabPage75.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAud3DSound)).BeginInit();
            this.tabPage76.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudTrueBass)).BeginInit();
            this.tabPage27.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudPitchShift)).BeginInit();
            this.tabPage50.SuspendLayout();
            this.groupBox41.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).BeginInit();
            this.tabPage28.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabPage32.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbOSDTranspLevel)).BeginInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage23.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.tabPage24.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbReversePlaybackTrackbar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabControl13.SuspendLayout();
            this.tabPage54.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).BeginInit();
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
            this.tabControl1.Location = (new global::System.Drawing.Point(20, 22));
            this.tabControl1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl1.Name = ("tabControl1");
            this.tabControl1.SelectedIndex = (0);
            this.tabControl1.Size = (new global::System.Drawing.Size(516, 995));
            this.tabControl1.TabIndex = (1);
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.groupBox6);
            this.tabPage20.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage20.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage20.Name = ("tabPage20");
            this.tabPage20.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage20.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage20.TabIndex = (15);
            this.tabPage20.Text = ("Source mode");
            this.tabPage20.UseVisualStyleBackColor = (true);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbGPUDirect3D);
            this.groupBox6.Controls.Add(this.rbGPUDXVANative);
            this.groupBox6.Controls.Add(this.rbGPUDXVACopyBack);
            this.groupBox6.Controls.Add(this.rbGPUIntel);
            this.groupBox6.Controls.Add(this.rbGPUNVidia);
            this.groupBox6.Location = (new global::System.Drawing.Point(10, 11));
            this.groupBox6.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox6.Name = ("groupBox6");
            this.groupBox6.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox6.Size = (new global::System.Drawing.Size(468, 208));
            this.groupBox6.TabIndex = (1);
            this.groupBox6.TabStop = (false);
            this.groupBox6.Text = ("GPU decoder");
            // 
            // rbGPUDirect3D
            // 
            this.rbGPUDirect3D.AutoSize = (true);
            this.rbGPUDirect3D.Location = (new global::System.Drawing.Point(22, 141));
            this.rbGPUDirect3D.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbGPUDirect3D.Name = ("rbGPUDirect3D");
            this.rbGPUDirect3D.Size = (new global::System.Drawing.Size(131, 29));
            this.rbGPUDirect3D.TabIndex = (4);
            this.rbGPUDirect3D.Text = ("Direct3D 11");
            this.rbGPUDirect3D.UseVisualStyleBackColor = (true);
            // 
            // rbGPUDXVANative
            // 
            this.rbGPUDXVANative.AutoSize = (true);
            this.rbGPUDXVANative.Location = (new global::System.Drawing.Point(218, 95));
            this.rbGPUDXVANative.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbGPUDXVANative.Name = ("rbGPUDXVANative");
            this.rbGPUDXVANative.Size = (new global::System.Drawing.Size(154, 29));
            this.rbGPUDXVANative.TabIndex = (3);
            this.rbGPUDXVANative.Text = ("DXVA2 (native)");
            this.rbGPUDXVANative.UseVisualStyleBackColor = (true);
            // 
            // rbGPUDXVACopyBack
            // 
            this.rbGPUDXVACopyBack.AutoSize = (true);
            this.rbGPUDXVACopyBack.Checked = (true);
            this.rbGPUDXVACopyBack.Location = (new global::System.Drawing.Point(22, 95));
            this.rbGPUDXVACopyBack.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbGPUDXVACopyBack.Name = ("rbGPUDXVACopyBack");
            this.rbGPUDXVACopyBack.Size = (new global::System.Drawing.Size(190, 29));
            this.rbGPUDXVACopyBack.TabIndex = (2);
            this.rbGPUDXVACopyBack.TabStop = (true);
            this.rbGPUDXVACopyBack.Text = ("DXVA2 (copy-back)");
            this.rbGPUDXVACopyBack.UseVisualStyleBackColor = (true);
            // 
            // rbGPUIntel
            // 
            this.rbGPUIntel.AutoSize = (true);
            this.rbGPUIntel.Location = (new global::System.Drawing.Point(218, 52));
            this.rbGPUIntel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbGPUIntel.Name = ("rbGPUIntel");
            this.rbGPUIntel.Size = (new global::System.Drawing.Size(157, 29));
            this.rbGPUIntel.TabIndex = (1);
            this.rbGPUIntel.Text = ("Intel QuickSync");
            this.rbGPUIntel.UseVisualStyleBackColor = (true);
            // 
            // rbGPUNVidia
            // 
            this.rbGPUNVidia.AutoSize = (true);
            this.rbGPUNVidia.Location = (new global::System.Drawing.Point(22, 52));
            this.rbGPUNVidia.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbGPUNVidia.Name = ("rbGPUNVidia");
            this.rbGPUNVidia.Size = (new global::System.Drawing.Size(143, 29));
            this.rbGPUNVidia.TabIndex = (0);
            this.rbGPUNVidia.Text = ("nVidia CUVID");
            this.rbGPUNVidia.UseVisualStyleBackColor = (true);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbUseLibMediaInfo);
            this.tabPage1.Controls.Add(this.btReadInfo);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage1.Name = ("tabPage1");
            this.tabPage1.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage1.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage1.TabIndex = (0);
            this.tabPage1.Text = ("Info");
            this.tabPage1.UseVisualStyleBackColor = (true);
            // 
            // cbUseLibMediaInfo
            // 
            this.cbUseLibMediaInfo.AutoSize = (true);
            this.cbUseLibMediaInfo.Checked = (true);
            this.cbUseLibMediaInfo.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbUseLibMediaInfo.Location = (new global::System.Drawing.Point(24, 719));
            this.cbUseLibMediaInfo.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbUseLibMediaInfo.Name = ("cbUseLibMediaInfo");
            this.cbUseLibMediaInfo.Size = (new global::System.Drawing.Size(172, 29));
            this.cbUseLibMediaInfo.TabIndex = (2);
            this.cbUseLibMediaInfo.Text = ("Use libMediaInfo");
            this.cbUseLibMediaInfo.UseVisualStyleBackColor = (true);
            // 
            // btReadInfo
            // 
            this.btReadInfo.Location = (new global::System.Drawing.Point(24, 842));
            this.btReadInfo.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btReadInfo.Name = ("btReadInfo");
            this.btReadInfo.Size = (new global::System.Drawing.Size(124, 44));
            this.btReadInfo.TabIndex = (1);
            this.btReadInfo.Text = ("Read info");
            this.btReadInfo.UseVisualStyleBackColor = (true);
            this.btReadInfo.Click += (this.btReadInfo_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage49);
            this.tabControl2.Location = (new global::System.Drawing.Point(28, 31));
            this.tabControl2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl2.Name = ("tabControl2");
            this.tabControl2.SelectedIndex = (0);
            this.tabControl2.Size = (new global::System.Drawing.Size(452, 658));
            this.tabControl2.TabIndex = (0);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.mmInfo);
            this.tabPage6.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage6.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage6.Name = ("tabPage6");
            this.tabPage6.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage6.Size = (new global::System.Drawing.Size(444, 620));
            this.tabPage6.TabIndex = (0);
            this.tabPage6.Text = ("File");
            this.tabPage6.UseVisualStyleBackColor = (true);
            // 
            // mmInfo
            // 
            this.mmInfo.Location = (new global::System.Drawing.Point(28, 39));
            this.mmInfo.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.mmInfo.Multiline = (true);
            this.mmInfo.Name = ("mmInfo");
            this.mmInfo.ScrollBars = (global::System.Windows.Forms.ScrollBars.Both);
            this.mmInfo.Size = (new global::System.Drawing.Size(384, 446));
            this.mmInfo.TabIndex = (0);
            // 
            // tabPage49
            // 
            this.tabPage49.Controls.Add(this.imgTags);
            this.tabPage49.Controls.Add(this.edTags);
            this.tabPage49.Controls.Add(this.btReadTags);
            this.tabPage49.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage49.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage49.Name = ("tabPage49");
            this.tabPage49.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage49.Size = (new global::System.Drawing.Size(444, 620));
            this.tabPage49.TabIndex = (2);
            this.tabPage49.Text = ("Tags");
            this.tabPage49.UseVisualStyleBackColor = (true);
            // 
            // imgTags
            // 
            this.imgTags.Location = (new global::System.Drawing.Point(262, 406));
            this.imgTags.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.imgTags.Name = ("imgTags");
            this.imgTags.Size = (new global::System.Drawing.Size(150, 172));
            this.imgTags.SizeMode = (global::System.Windows.Forms.PictureBoxSizeMode.StretchImage);
            this.imgTags.TabIndex = (2);
            this.imgTags.TabStop = (false);
            // 
            // edTags
            // 
            this.edTags.Location = (new global::System.Drawing.Point(28, 31));
            this.edTags.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTags.Multiline = (true);
            this.edTags.Name = ("edTags");
            this.edTags.Size = (new global::System.Drawing.Size(384, 359));
            this.edTags.TabIndex = (1);
            // 
            // btReadTags
            // 
            this.btReadTags.Location = (new global::System.Drawing.Point(28, 534));
            this.btReadTags.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btReadTags.Name = ("btReadTags");
            this.btReadTags.Size = (new global::System.Drawing.Size(124, 44));
            this.btReadTags.TabIndex = (0);
            this.btReadTags.Text = ("Read tags");
            this.btReadTags.UseVisualStyleBackColor = (true);
            this.btReadTags.Click += (this.btReadTags_Click);
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
            this.tabPage2.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage2.Name = ("tabPage2");
            this.tabPage2.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage2.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage2.TabIndex = (1);
            this.tabPage2.Text = ("Audio output");
            this.tabPage2.UseVisualStyleBackColor = (true);
            // 
            // label10
            // 
            this.label10.AutoSize = (true);
            this.label10.Location = (new global::System.Drawing.Point(322, 600));
            this.label10.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label10.Name = ("label10");
            this.label10.Size = (new global::System.Drawing.Size(71, 25));
            this.label10.TabIndex = (22);
            this.label10.Text = ("Balance");
            // 
            // tbBalance4
            // 
            this.tbBalance4.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbBalance4.Location = (new global::System.Drawing.Point(328, 631));
            this.tbBalance4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbBalance4.Maximum = (100);
            this.tbBalance4.Minimum = (-100);
            this.tbBalance4.Name = ("tbBalance4");
            this.tbBalance4.Size = (new global::System.Drawing.Size(142, 69));
            this.tbBalance4.TabIndex = (21);
            this.tbBalance4.Scroll += (this.tbBalance4_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = (true);
            this.label11.Location = (new global::System.Drawing.Point(168, 600));
            this.label11.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label11.Name = ("label11");
            this.label11.Size = (new global::System.Drawing.Size(72, 25));
            this.label11.TabIndex = (20);
            this.label11.Text = ("Volume");
            // 
            // tbVolume4
            // 
            this.tbVolume4.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVolume4.Location = (new global::System.Drawing.Point(171, 631));
            this.tbVolume4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVolume4.Maximum = (100);
            this.tbVolume4.Name = ("tbVolume4");
            this.tbVolume4.Size = (new global::System.Drawing.Size(142, 69));
            this.tbVolume4.TabIndex = (19);
            this.tbVolume4.Value = (85);
            this.tbVolume4.Scroll += (this.tbVolume4_Scroll);
            // 
            // cbAudioStream4
            // 
            this.cbAudioStream4.AutoSize = (true);
            this.cbAudioStream4.Location = (new global::System.Drawing.Point(31, 570));
            this.cbAudioStream4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioStream4.Name = ("cbAudioStream4");
            this.cbAudioStream4.Size = (new global::System.Drawing.Size(108, 29));
            this.cbAudioStream4.TabIndex = (18);
            this.cbAudioStream4.Text = ("Stream 4");
            this.cbAudioStream4.UseVisualStyleBackColor = (true);
            this.cbAudioStream4.CheckedChanged += (this.cbAudioStream4_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = (true);
            this.label12.Location = (new global::System.Drawing.Point(322, 472));
            this.label12.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label12.Name = ("label12");
            this.label12.Size = (new global::System.Drawing.Size(71, 25));
            this.label12.TabIndex = (17);
            this.label12.Text = ("Balance");
            // 
            // tbBalance3
            // 
            this.tbBalance3.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbBalance3.Location = (new global::System.Drawing.Point(328, 505));
            this.tbBalance3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbBalance3.Maximum = (100);
            this.tbBalance3.Minimum = (-100);
            this.tbBalance3.Name = ("tbBalance3");
            this.tbBalance3.Size = (new global::System.Drawing.Size(142, 69));
            this.tbBalance3.TabIndex = (16);
            this.tbBalance3.Scroll += (this.tbBalance3_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = (true);
            this.label13.Location = (new global::System.Drawing.Point(168, 472));
            this.label13.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label13.Name = ("label13");
            this.label13.Size = (new global::System.Drawing.Size(72, 25));
            this.label13.TabIndex = (15);
            this.label13.Text = ("Volume");
            // 
            // tbVolume3
            // 
            this.tbVolume3.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVolume3.Location = (new global::System.Drawing.Point(171, 505));
            this.tbVolume3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVolume3.Maximum = (100);
            this.tbVolume3.Name = ("tbVolume3");
            this.tbVolume3.Size = (new global::System.Drawing.Size(142, 69));
            this.tbVolume3.TabIndex = (14);
            this.tbVolume3.Value = (85);
            this.tbVolume3.Scroll += (this.tbVolume3_Scroll);
            // 
            // cbAudioStream3
            // 
            this.cbAudioStream3.AutoSize = (true);
            this.cbAudioStream3.Location = (new global::System.Drawing.Point(31, 444));
            this.cbAudioStream3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioStream3.Name = ("cbAudioStream3");
            this.cbAudioStream3.Size = (new global::System.Drawing.Size(108, 29));
            this.cbAudioStream3.TabIndex = (13);
            this.cbAudioStream3.Text = ("Stream 3");
            this.cbAudioStream3.UseVisualStyleBackColor = (true);
            this.cbAudioStream3.CheckedChanged += (this.cbAudioStream3_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = (true);
            this.label8.Location = (new global::System.Drawing.Point(322, 355));
            this.label8.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label8.Name = ("label8");
            this.label8.Size = (new global::System.Drawing.Size(71, 25));
            this.label8.TabIndex = (12);
            this.label8.Text = ("Balance");
            // 
            // tbBalance2
            // 
            this.tbBalance2.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbBalance2.Location = (new global::System.Drawing.Point(328, 384));
            this.tbBalance2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbBalance2.Maximum = (100);
            this.tbBalance2.Minimum = (-100);
            this.tbBalance2.Name = ("tbBalance2");
            this.tbBalance2.Size = (new global::System.Drawing.Size(142, 69));
            this.tbBalance2.TabIndex = (11);
            this.tbBalance2.Scroll += (this.tbBalance2_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = (true);
            this.label9.Location = (new global::System.Drawing.Point(168, 355));
            this.label9.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label9.Name = ("label9");
            this.label9.Size = (new global::System.Drawing.Size(72, 25));
            this.label9.TabIndex = (10);
            this.label9.Text = ("Volume");
            // 
            // tbVolume2
            // 
            this.tbVolume2.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVolume2.Location = (new global::System.Drawing.Point(171, 384));
            this.tbVolume2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVolume2.Maximum = (100);
            this.tbVolume2.Name = ("tbVolume2");
            this.tbVolume2.Size = (new global::System.Drawing.Size(142, 69));
            this.tbVolume2.TabIndex = (9);
            this.tbVolume2.Value = (85);
            this.tbVolume2.Scroll += (this.tbVolume2_Scroll);
            // 
            // cbAudioStream2
            // 
            this.cbAudioStream2.AutoSize = (true);
            this.cbAudioStream2.Location = (new global::System.Drawing.Point(31, 325));
            this.cbAudioStream2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioStream2.Name = ("cbAudioStream2");
            this.cbAudioStream2.Size = (new global::System.Drawing.Size(108, 29));
            this.cbAudioStream2.TabIndex = (8);
            this.cbAudioStream2.Text = ("Stream 2");
            this.cbAudioStream2.UseVisualStyleBackColor = (true);
            this.cbAudioStream2.CheckedChanged += (this.cbAudioStream2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = (true);
            this.label7.Location = (new global::System.Drawing.Point(322, 234));
            this.label7.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label7.Name = ("label7");
            this.label7.Size = (new global::System.Drawing.Size(71, 25));
            this.label7.TabIndex = (7);
            this.label7.Text = ("Balance");
            // 
            // tbBalance1
            // 
            this.tbBalance1.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbBalance1.Location = (new global::System.Drawing.Point(328, 266));
            this.tbBalance1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbBalance1.Maximum = (100);
            this.tbBalance1.Minimum = (-100);
            this.tbBalance1.Name = ("tbBalance1");
            this.tbBalance1.Size = (new global::System.Drawing.Size(142, 69));
            this.tbBalance1.TabIndex = (6);
            this.tbBalance1.Scroll += (this.tbBalance1_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = (true);
            this.label6.Location = (new global::System.Drawing.Point(168, 234));
            this.label6.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label6.Name = ("label6");
            this.label6.Size = (new global::System.Drawing.Size(72, 25));
            this.label6.TabIndex = (5);
            this.label6.Text = ("Volume");
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVolume1.Location = (new global::System.Drawing.Point(171, 266));
            this.tbVolume1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVolume1.Maximum = (100);
            this.tbVolume1.Name = ("tbVolume1");
            this.tbVolume1.Size = (new global::System.Drawing.Size(142, 69));
            this.tbVolume1.TabIndex = (4);
            this.tbVolume1.Value = (85);
            this.tbVolume1.Scroll += (this.tbVolume1_Scroll);
            // 
            // cbAudioStream1
            // 
            this.cbAudioStream1.AutoSize = (true);
            this.cbAudioStream1.Location = (new global::System.Drawing.Point(31, 206));
            this.cbAudioStream1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioStream1.Name = ("cbAudioStream1");
            this.cbAudioStream1.Size = (new global::System.Drawing.Size(108, 29));
            this.cbAudioStream1.TabIndex = (3);
            this.cbAudioStream1.Text = ("Stream 1");
            this.cbAudioStream1.UseVisualStyleBackColor = (true);
            this.cbAudioStream1.CheckedChanged += (this.cbAudioStream1_CheckedChanged);
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = (true);
            this.cbPlayAudio.Checked = (true);
            this.cbPlayAudio.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbPlayAudio.Location = (new global::System.Drawing.Point(31, 119));
            this.cbPlayAudio.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbPlayAudio.Name = ("cbPlayAudio");
            this.cbPlayAudio.Size = (new global::System.Drawing.Size(120, 29));
            this.cbPlayAudio.TabIndex = (2);
            this.cbPlayAudio.Text = ("Play audio");
            this.cbPlayAudio.UseVisualStyleBackColor = (true);
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbAudioOutputDevice.FormattingEnabled = (true);
            this.cbAudioOutputDevice.Location = (new global::System.Drawing.Point(31, 69));
            this.cbAudioOutputDevice.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioOutputDevice.Name = ("cbAudioOutputDevice");
            this.cbAudioOutputDevice.Size = (new global::System.Drawing.Size(434, 33));
            this.cbAudioOutputDevice.TabIndex = (1);
            // 
            // label5
            // 
            this.label5.AutoSize = (true);
            this.label5.Location = (new global::System.Drawing.Point(28, 31));
            this.label5.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label5.Name = ("label5");
            this.label5.Size = (new global::System.Drawing.Size(119, 25));
            this.label5.TabIndex = (0);
            this.label5.Text = ("Audio output");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl4);
            this.tabPage3.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage3.Name = ("tabPage3");
            this.tabPage3.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage3.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage3.TabIndex = (2);
            this.tabPage3.Text = ("Display");
            this.tabPage3.UseVisualStyleBackColor = (true);
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage16);
            this.tabControl4.Controls.Add(this.tabPage17);
            this.tabControl4.Location = (new global::System.Drawing.Point(4, 11));
            this.tabControl4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl4.Name = ("tabControl4");
            this.tabControl4.SelectedIndex = (0);
            this.tabControl4.Size = (new global::System.Drawing.Size(488, 922));
            this.tabControl4.TabIndex = (17);
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
            this.tabPage16.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage16.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage16.Name = ("tabPage16");
            this.tabPage16.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage16.Size = (new global::System.Drawing.Size(480, 884));
            this.tabPage16.TabIndex = (0);
            this.tabPage16.Text = ("Main");
            this.tabPage16.UseVisualStyleBackColor = (true);
            // 
            // label393
            // 
            this.label393.AutoSize = (true);
            this.label393.Location = (new global::System.Drawing.Point(236, 611));
            this.label393.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label393.Name = ("label393");
            this.label393.Size = (new global::System.Drawing.Size(133, 25));
            this.label393.TabIndex = (35);
            this.label393.Text = ("Direct2D rotate");
            // 
            // cbDirect2DRotate
            // 
            this.cbDirect2DRotate.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDirect2DRotate.FormattingEnabled = (true);
            this.cbDirect2DRotate.Items.AddRange(new global::System.Object[] { "0", "90", "180", "270" });
            this.cbDirect2DRotate.Location = (new global::System.Drawing.Point(240, 642));
            this.cbDirect2DRotate.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDirect2DRotate.Name = ("cbDirect2DRotate");
            this.cbDirect2DRotate.Size = (new global::System.Drawing.Size(202, 33));
            this.cbDirect2DRotate.TabIndex = (34);
            this.cbDirect2DRotate.SelectedIndexChanged += (this.cbDirect2DRotate_SelectedIndexChanged);
            // 
            // pnVideoRendererBGColor
            // 
            this.pnVideoRendererBGColor.BackColor = (global::System.Drawing.Color.Black);
            this.pnVideoRendererBGColor.BorderStyle = (global::System.Windows.Forms.BorderStyle.FixedSingle);
            this.pnVideoRendererBGColor.Location = (new global::System.Drawing.Point(200, 420));
            this.pnVideoRendererBGColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnVideoRendererBGColor.Name = ("pnVideoRendererBGColor");
            this.pnVideoRendererBGColor.Size = (new global::System.Drawing.Size(40, 44));
            this.pnVideoRendererBGColor.TabIndex = (33);
            this.pnVideoRendererBGColor.Click += (this.pnVideoRendererBGColor_Click);
            // 
            // label394
            // 
            this.label394.AutoSize = (true);
            this.label394.Location = (new global::System.Drawing.Point(22, 431));
            this.label394.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label394.Name = ("label394");
            this.label394.Size = (new global::System.Drawing.Size(152, 25));
            this.label394.TabIndex = (32);
            this.label394.Text = ("Background color");
            // 
            // btFullScreen
            // 
            this.btFullScreen.Location = (new global::System.Drawing.Point(240, 694));
            this.btFullScreen.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFullScreen.Name = ("btFullScreen");
            this.btFullScreen.Size = (new global::System.Drawing.Size(202, 44));
            this.btFullScreen.TabIndex = (31);
            this.btFullScreen.Text = ("Full screen");
            this.btFullScreen.UseVisualStyleBackColor = (true);
            this.btFullScreen.Click += (this.btFullScreen_Click);
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
            this.groupBox28.Location = (new global::System.Drawing.Point(28, 611));
            this.groupBox28.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox28.Name = ("groupBox28");
            this.groupBox28.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox28.Size = (new global::System.Drawing.Size(198, 250));
            this.groupBox28.TabIndex = (30);
            this.groupBox28.TabStop = (false);
            this.groupBox28.Text = ("Zoom");
            // 
            // btZoomReset
            // 
            this.btZoomReset.Location = (new global::System.Drawing.Point(58, 194));
            this.btZoomReset.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomReset.Name = ("btZoomReset");
            this.btZoomReset.Size = (new global::System.Drawing.Size(82, 44));
            this.btZoomReset.TabIndex = (6);
            this.btZoomReset.Text = ("Reset");
            this.btZoomReset.UseVisualStyleBackColor = (true);
            this.btZoomReset.Click += (this.btZoomReset_Click);
            // 
            // btZoomShiftRight
            // 
            this.btZoomShiftRight.Location = (new global::System.Drawing.Point(142, 64));
            this.btZoomShiftRight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomShiftRight.Name = ("btZoomShiftRight");
            this.btZoomShiftRight.Size = (new global::System.Drawing.Size(36, 92));
            this.btZoomShiftRight.TabIndex = (5);
            this.btZoomShiftRight.Text = ("R");
            this.btZoomShiftRight.UseVisualStyleBackColor = (true);
            this.btZoomShiftRight.Click += (this.btZoomShiftRight_Click);
            // 
            // btZoomShiftLeft
            // 
            this.btZoomShiftLeft.Location = (new global::System.Drawing.Point(22, 61));
            this.btZoomShiftLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomShiftLeft.Name = ("btZoomShiftLeft");
            this.btZoomShiftLeft.Size = (new global::System.Drawing.Size(36, 92));
            this.btZoomShiftLeft.TabIndex = (4);
            this.btZoomShiftLeft.Text = ("L");
            this.btZoomShiftLeft.UseVisualStyleBackColor = (true);
            this.btZoomShiftLeft.Click += (this.btZoomShiftLeft_Click);
            // 
            // btZoomOut
            // 
            this.btZoomOut.Location = (new global::System.Drawing.Point(102, 86));
            this.btZoomOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomOut.Name = ("btZoomOut");
            this.btZoomOut.Size = (new global::System.Drawing.Size(38, 44));
            this.btZoomOut.TabIndex = (3);
            this.btZoomOut.Text = ("-");
            this.btZoomOut.UseVisualStyleBackColor = (true);
            this.btZoomOut.Click += (this.btZoomOut_Click);
            // 
            // btZoomIn
            // 
            this.btZoomIn.Location = (new global::System.Drawing.Point(58, 86));
            this.btZoomIn.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomIn.Name = ("btZoomIn");
            this.btZoomIn.Size = (new global::System.Drawing.Size(38, 44));
            this.btZoomIn.TabIndex = (2);
            this.btZoomIn.Text = ("+");
            this.btZoomIn.UseVisualStyleBackColor = (true);
            this.btZoomIn.Click += (this.btZoomIn_Click);
            // 
            // btZoomShiftDown
            // 
            this.btZoomShiftDown.Location = (new global::System.Drawing.Point(58, 134));
            this.btZoomShiftDown.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomShiftDown.Name = ("btZoomShiftDown");
            this.btZoomShiftDown.Size = (new global::System.Drawing.Size(84, 44));
            this.btZoomShiftDown.TabIndex = (1);
            this.btZoomShiftDown.Text = ("Down");
            this.btZoomShiftDown.UseVisualStyleBackColor = (true);
            this.btZoomShiftDown.Click += (this.btZoomShiftDown_Click);
            // 
            // btZoomShiftUp
            // 
            this.btZoomShiftUp.Location = (new global::System.Drawing.Point(58, 39));
            this.btZoomShiftUp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btZoomShiftUp.Name = ("btZoomShiftUp");
            this.btZoomShiftUp.Size = (new global::System.Drawing.Size(84, 44));
            this.btZoomShiftUp.TabIndex = (0);
            this.btZoomShiftUp.Text = ("Up");
            this.btZoomShiftUp.UseVisualStyleBackColor = (true);
            this.btZoomShiftUp.Click += (this.btZoomShiftUp_Click);
            // 
            // cbScreenFlipVertical
            // 
            this.cbScreenFlipVertical.AutoSize = (true);
            this.cbScreenFlipVertical.Location = (new global::System.Drawing.Point(292, 469));
            this.cbScreenFlipVertical.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbScreenFlipVertical.Name = ("cbScreenFlipVertical");
            this.cbScreenFlipVertical.Size = (new global::System.Drawing.Size(126, 29));
            this.cbScreenFlipVertical.TabIndex = (29);
            this.cbScreenFlipVertical.Text = ("Flip vertical");
            this.cbScreenFlipVertical.UseVisualStyleBackColor = (true);
            this.cbScreenFlipVertical.CheckedChanged += (this.cbScreenFlipVertical_CheckedChanged);
            // 
            // cbScreenFlipHorizontal
            // 
            this.cbScreenFlipHorizontal.AutoSize = (true);
            this.cbScreenFlipHorizontal.Location = (new global::System.Drawing.Point(292, 422));
            this.cbScreenFlipHorizontal.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbScreenFlipHorizontal.Name = ("cbScreenFlipHorizontal");
            this.cbScreenFlipHorizontal.Size = (new global::System.Drawing.Size(150, 29));
            this.cbScreenFlipHorizontal.TabIndex = (28);
            this.cbScreenFlipHorizontal.Text = ("Flip horizontal");
            this.cbScreenFlipHorizontal.UseVisualStyleBackColor = (true);
            this.cbScreenFlipHorizontal.CheckedChanged += (this.cbScreenFlipHorizontal_CheckedChanged);
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = (true);
            this.cbStretch.Location = (new global::System.Drawing.Point(292, 516));
            this.cbStretch.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbStretch.Name = ("cbStretch");
            this.cbStretch.Size = (new global::System.Drawing.Size(141, 29));
            this.cbStretch.TabIndex = (27);
            this.cbStretch.Text = ("Stretch video");
            this.cbStretch.UseVisualStyleBackColor = (true);
            this.cbStretch.CheckedChanged += (this.cbStretch_CheckedChanged);
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
            this.groupBox13.Location = (new global::System.Drawing.Point(28, 11));
            this.groupBox13.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox13.Name = ("groupBox13");
            this.groupBox13.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox13.Size = (new global::System.Drawing.Size(418, 369));
            this.groupBox13.TabIndex = (26);
            this.groupBox13.TabStop = (false);
            this.groupBox13.Text = ("Video Renderer");
            // 
            // rbNDIStreaming
            // 
            this.rbNDIStreaming.AutoSize = (true);
            this.rbNDIStreaming.Location = (new global::System.Drawing.Point(22, 314));
            this.rbNDIStreaming.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNDIStreaming.Name = ("rbNDIStreaming");
            this.rbNDIStreaming.Size = (new global::System.Drawing.Size(152, 29));
            this.rbNDIStreaming.TabIndex = (7);
            this.rbNDIStreaming.Text = ("NDI streaming");
            this.rbNDIStreaming.UseVisualStyleBackColor = (true);
            // 
            // rbVirtualCameraOutput
            // 
            this.rbVirtualCameraOutput.AutoSize = (true);
            this.rbVirtualCameraOutput.Location = (new global::System.Drawing.Point(22, 270));
            this.rbVirtualCameraOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVirtualCameraOutput.Name = ("rbVirtualCameraOutput");
            this.rbVirtualCameraOutput.Size = (new global::System.Drawing.Size(274, 29));
            this.rbVirtualCameraOutput.TabIndex = (6);
            this.rbVirtualCameraOutput.Text = ("Output to Virtual Camera SDK");
            this.rbVirtualCameraOutput.UseVisualStyleBackColor = (true);
            // 
            // rbMadVR
            // 
            this.rbMadVR.AutoSize = (true);
            this.rbMadVR.Location = (new global::System.Drawing.Point(22, 181));
            this.rbMadVR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbMadVR.Name = ("rbMadVR");
            this.rbMadVR.Size = (new global::System.Drawing.Size(176, 29));
            this.rbMadVR.TabIndex = (5);
            this.rbMadVR.Text = ("madVR (optional)");
            this.rbMadVR.UseVisualStyleBackColor = (true);
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = (true);
            this.rbDirect2D.Location = (new global::System.Drawing.Point(22, 136));
            this.rbDirect2D.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDirect2D.Name = ("rbDirect2D");
            this.rbDirect2D.Size = (new global::System.Drawing.Size(106, 29));
            this.rbDirect2D.TabIndex = (4);
            this.rbDirect2D.Text = ("Direct2D");
            this.rbDirect2D.UseVisualStyleBackColor = (true);
            this.rbDirect2D.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = (true);
            this.rbNone.Location = (new global::System.Drawing.Point(22, 225));
            this.rbNone.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNone.Name = ("rbNone");
            this.rbNone.Size = (new global::System.Drawing.Size(80, 29));
            this.rbNone.TabIndex = (3);
            this.rbNone.Text = ("None");
            this.rbNone.UseVisualStyleBackColor = (true);
            this.rbNone.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbEVR
            // 
            this.rbEVR.AutoSize = (true);
            this.rbEVR.Checked = (true);
            this.rbEVR.Location = (new global::System.Drawing.Point(22, 92));
            this.rbEVR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEVR.Name = ("rbEVR");
            this.rbEVR.Size = (new global::System.Drawing.Size(309, 29));
            this.rbEVR.TabIndex = (2);
            this.rbEVR.TabStop = (true);
            this.rbEVR.Text = ("Enhanced Video Renderer (default)");
            this.rbEVR.UseVisualStyleBackColor = (true);
            this.rbEVR.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbVMR9
            // 
            this.rbVMR9.AutoSize = (true);
            this.rbVMR9.Location = (new global::System.Drawing.Point(22, 48));
            this.rbVMR9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVMR9.Name = ("rbVMR9");
            this.rbVMR9.Size = (new global::System.Drawing.Size(231, 29));
            this.rbVMR9.TabIndex = (1);
            this.rbVMR9.Text = ("Video Mixing Renderer 9");
            this.rbVMR9.UseVisualStyleBackColor = (true);
            this.rbVMR9.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = (true);
            this.label15.Location = (new global::System.Drawing.Point(112, 566));
            this.label15.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label15.Name = ("label15");
            this.label15.Size = (new global::System.Drawing.Size(20, 25));
            this.label15.TabIndex = (25);
            this.label15.Text = ("x");
            // 
            // edAspectRatioY
            // 
            this.edAspectRatioY.Location = (new global::System.Drawing.Point(138, 559));
            this.edAspectRatioY.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAspectRatioY.Name = ("edAspectRatioY");
            this.edAspectRatioY.Size = (new global::System.Drawing.Size(46, 31));
            this.edAspectRatioY.TabIndex = (24);
            this.edAspectRatioY.Text = ("9");
            // 
            // edAspectRatioX
            // 
            this.edAspectRatioX.Location = (new global::System.Drawing.Point(56, 559));
            this.edAspectRatioX.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAspectRatioX.Name = ("edAspectRatioX");
            this.edAspectRatioX.Size = (new global::System.Drawing.Size(46, 31));
            this.edAspectRatioX.TabIndex = (23);
            this.edAspectRatioX.Text = ("16");
            // 
            // cbAspectRatioUseCustom
            // 
            this.cbAspectRatioUseCustom.AutoSize = (true);
            this.cbAspectRatioUseCustom.Location = (new global::System.Drawing.Point(28, 516));
            this.cbAspectRatioUseCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAspectRatioUseCustom.Name = ("cbAspectRatioUseCustom");
            this.cbAspectRatioUseCustom.Size = (new global::System.Drawing.Size(228, 29));
            this.cbAspectRatioUseCustom.TabIndex = (22);
            this.cbAspectRatioUseCustom.Text = ("Use custom aspect ratio");
            this.cbAspectRatioUseCustom.UseVisualStyleBackColor = (true);
            this.cbAspectRatioUseCustom.CheckedChanged += (this.cbAspectRatioUseCustom_CheckedChanged);
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
            this.tabPage17.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage17.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage17.Name = ("tabPage17");
            this.tabPage17.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage17.Size = (new global::System.Drawing.Size(480, 884));
            this.tabPage17.TabIndex = (1);
            this.tabPage17.Text = ("Multiscreen");
            this.tabPage17.UseVisualStyleBackColor = (true);
            // 
            // cbMultiscreenDrawOnExternalDisplays
            // 
            this.cbMultiscreenDrawOnExternalDisplays.AutoSize = (true);
            this.cbMultiscreenDrawOnExternalDisplays.Location = (new global::System.Drawing.Point(18, 66));
            this.cbMultiscreenDrawOnExternalDisplays.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMultiscreenDrawOnExternalDisplays.Name = ("cbMultiscreenDrawOnExternalDisplays");
            this.cbMultiscreenDrawOnExternalDisplays.Size = (new global::System.Drawing.Size(289, 29));
            this.cbMultiscreenDrawOnExternalDisplays.TabIndex = (23);
            this.cbMultiscreenDrawOnExternalDisplays.Text = ("Draw video on external displays");
            this.cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = (true);
            // 
            // cbMultiscreenDrawOnPanels
            // 
            this.cbMultiscreenDrawOnPanels.AutoSize = (true);
            this.cbMultiscreenDrawOnPanels.Location = (new global::System.Drawing.Point(18, 20));
            this.cbMultiscreenDrawOnPanels.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMultiscreenDrawOnPanels.Name = ("cbMultiscreenDrawOnPanels");
            this.cbMultiscreenDrawOnPanels.Size = (new global::System.Drawing.Size(210, 29));
            this.cbMultiscreenDrawOnPanels.TabIndex = (22);
            this.cbMultiscreenDrawOnPanels.Text = ("Draw video on panels");
            this.cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = (true);
            // 
            // cbFlipHorizontal2
            // 
            this.cbFlipHorizontal2.AutoSize = (true);
            this.cbFlipHorizontal2.Location = (new global::System.Drawing.Point(270, 830));
            this.cbFlipHorizontal2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipHorizontal2.Name = ("cbFlipHorizontal2");
            this.cbFlipHorizontal2.Size = (new global::System.Drawing.Size(150, 29));
            this.cbFlipHorizontal2.TabIndex = (21);
            this.cbFlipHorizontal2.Text = ("Flip horizontal");
            this.cbFlipHorizontal2.UseVisualStyleBackColor = (true);
            this.cbFlipHorizontal2.CheckedChanged += (this.cbFlipStretch2_CheckedChanged);
            // 
            // cbFlipVertical2
            // 
            this.cbFlipVertical2.AutoSize = (true);
            this.cbFlipVertical2.Location = (new global::System.Drawing.Point(128, 830));
            this.cbFlipVertical2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipVertical2.Name = ("cbFlipVertical2");
            this.cbFlipVertical2.Size = (new global::System.Drawing.Size(126, 29));
            this.cbFlipVertical2.TabIndex = (20);
            this.cbFlipVertical2.Text = ("Flip vertical");
            this.cbFlipVertical2.UseVisualStyleBackColor = (true);
            this.cbFlipVertical2.CheckedChanged += (this.cbFlipStretch2_CheckedChanged);
            // 
            // cbStretch2
            // 
            this.cbStretch2.AutoSize = (true);
            this.cbStretch2.Location = (new global::System.Drawing.Point(18, 830));
            this.cbStretch2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbStretch2.Name = ("cbStretch2");
            this.cbStretch2.Size = (new global::System.Drawing.Size(92, 29));
            this.cbStretch2.TabIndex = (19);
            this.cbStretch2.Text = ("Stretch");
            this.cbStretch2.UseVisualStyleBackColor = (true);
            this.cbStretch2.CheckedChanged += (this.cbFlipStretch2_CheckedChanged);
            // 
            // cbFlipHorizontal1
            // 
            this.cbFlipHorizontal1.AutoSize = (true);
            this.cbFlipHorizontal1.Location = (new global::System.Drawing.Point(270, 375));
            this.cbFlipHorizontal1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipHorizontal1.Name = ("cbFlipHorizontal1");
            this.cbFlipHorizontal1.Size = (new global::System.Drawing.Size(150, 29));
            this.cbFlipHorizontal1.TabIndex = (18);
            this.cbFlipHorizontal1.Text = ("Flip horizontal");
            this.cbFlipHorizontal1.UseVisualStyleBackColor = (true);
            this.cbFlipHorizontal1.CheckedChanged += (this.cbFlipStretch1_CheckedChanged);
            // 
            // cbFlipVertical1
            // 
            this.cbFlipVertical1.AutoSize = (true);
            this.cbFlipVertical1.Location = (new global::System.Drawing.Point(128, 375));
            this.cbFlipVertical1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipVertical1.Name = ("cbFlipVertical1");
            this.cbFlipVertical1.Size = (new global::System.Drawing.Size(126, 29));
            this.cbFlipVertical1.TabIndex = (17);
            this.cbFlipVertical1.Text = ("Flip vertical");
            this.cbFlipVertical1.UseVisualStyleBackColor = (true);
            this.cbFlipVertical1.CheckedChanged += (this.cbFlipStretch1_CheckedChanged);
            // 
            // cbStretch1
            // 
            this.cbStretch1.AutoSize = (true);
            this.cbStretch1.Location = (new global::System.Drawing.Point(18, 375));
            this.cbStretch1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbStretch1.Name = ("cbStretch1");
            this.cbStretch1.Size = (new global::System.Drawing.Size(92, 29));
            this.cbStretch1.TabIndex = (16);
            this.cbStretch1.Text = ("Stretch");
            this.cbStretch1.UseVisualStyleBackColor = (true);
            this.cbStretch1.CheckedChanged += (this.cbFlipStretch1_CheckedChanged);
            // 
            // pnScreen2
            // 
            this.pnScreen2.BackColor = (global::System.Drawing.Color.Black);
            this.pnScreen2.Location = (new global::System.Drawing.Point(18, 419));
            this.pnScreen2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnScreen2.Name = ("pnScreen2");
            this.pnScreen2.Size = (new global::System.Drawing.Size(409, 392));
            this.pnScreen2.TabIndex = (15);
            // 
            // pnScreen1
            // 
            this.pnScreen1.BackColor = (global::System.Drawing.Color.Black);
            this.pnScreen1.Location = (new global::System.Drawing.Point(78, 120));
            this.pnScreen1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnScreen1.Name = ("pnScreen1");
            this.pnScreen1.Size = (new global::System.Drawing.Size(290, 242));
            this.pnScreen1.TabIndex = (13);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl17);
            this.tabPage4.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage4.Name = ("tabPage4");
            this.tabPage4.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage4.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage4.TabIndex = (3);
            this.tabPage4.Text = ("Video processing");
            this.tabPage4.UseVisualStyleBackColor = (true);
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
            this.tabControl17.Location = (new global::System.Drawing.Point(0, 11));
            this.tabControl17.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl17.Name = ("tabControl17");
            this.tabControl17.SelectedIndex = (0);
            this.tabControl17.Size = (new global::System.Drawing.Size(498, 931));
            this.tabControl17.TabIndex = (37);
            // 
            // tabPage68
            // 
            this.tabPage68.Controls.Add(this.cbScrollingText);
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
            this.tabPage68.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage68.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage68.Name = ("tabPage68");
            this.tabPage68.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage68.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage68.TabIndex = (0);
            this.tabPage68.Text = ("Effects");
            this.tabPage68.UseVisualStyleBackColor = (true);
            // 
            // cbScrollingText
            // 
            this.cbScrollingText.AutoSize = (true);
            this.cbScrollingText.Location = (new global::System.Drawing.Point(21, 319));
            this.cbScrollingText.Margin = (new global::System.Windows.Forms.Padding(2, 3, 2, 3));
            this.cbScrollingText.Name = ("cbScrollingText");
            this.cbScrollingText.Size = (new global::System.Drawing.Size(202, 29));
            this.cbScrollingText.TabIndex = (89);
            this.cbScrollingText.Text = ("Sample scrolling text");
            this.cbScrollingText.UseVisualStyleBackColor = (true);
            this.cbScrollingText.CheckedChanged += (this.cbScrollingText_CheckedChanged);
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = (true);
            this.cbFlipY.Location = (new global::System.Drawing.Point(355, 288));
            this.cbFlipY.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipY.Name = ("cbFlipY");
            this.cbFlipY.Size = (new global::System.Drawing.Size(81, 29));
            this.cbFlipY.TabIndex = (69);
            this.cbFlipY.Text = ("Flip Y");
            this.cbFlipY.UseVisualStyleBackColor = (true);
            this.cbFlipY.CheckedChanged += (this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = (true);
            this.cbFlipX.Location = (new global::System.Drawing.Point(255, 288));
            this.cbFlipX.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFlipX.Name = ("cbFlipX");
            this.cbFlipX.Size = (new global::System.Drawing.Size(82, 29));
            this.cbFlipX.TabIndex = (68);
            this.cbFlipX.Text = ("Flip X");
            this.cbFlipX.UseVisualStyleBackColor = (true);
            this.cbFlipX.CheckedChanged += (this.cbFlipX_CheckedChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = (true);
            this.label201.Location = (new global::System.Drawing.Point(238, 169));
            this.label201.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label201.Name = ("label201");
            this.label201.Size = (new global::System.Drawing.Size(84, 25));
            this.label201.TabIndex = (63);
            this.label201.Text = ("Darkness");
            // 
            // label200
            // 
            this.label200.AutoSize = (true);
            this.label200.Location = (new global::System.Drawing.Point(10, 169));
            this.label200.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label200.Name = ("label200");
            this.label200.Size = (new global::System.Drawing.Size(79, 25));
            this.label200.TabIndex = (62);
            this.label200.Text = ("Contrast");
            // 
            // label199
            // 
            this.label199.AutoSize = (true);
            this.label199.Location = (new global::System.Drawing.Point(238, 69));
            this.label199.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label199.Name = ("label199");
            this.label199.Size = (new global::System.Drawing.Size(93, 25));
            this.label199.TabIndex = (61);
            this.label199.Text = ("Saturation");
            // 
            // label198
            // 
            this.label198.AutoSize = (true);
            this.label198.Location = (new global::System.Drawing.Point(10, 69));
            this.label198.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label198.Name = ("label198");
            this.label198.Size = (new global::System.Drawing.Size(86, 25));
            this.label198.TabIndex = (60);
            this.label198.Text = ("Lightness");
            // 
            // tabControl7
            // 
            this.tabControl7.Controls.Add(this.tabPage29);
            this.tabControl7.Controls.Add(this.tabPage42);
            this.tabControl7.Controls.Add(this.tabPage18);
            this.tabControl7.Controls.Add(this.tabPage19);
            this.tabControl7.Controls.Add(this.tabPage22);
            this.tabControl7.Controls.Add(this.tabPage43);
            this.tabControl7.Location = (new global::System.Drawing.Point(4, 356));
            this.tabControl7.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl7.Name = ("tabControl7");
            this.tabControl7.SelectedIndex = (0);
            this.tabControl7.Size = (new global::System.Drawing.Size(471, 528));
            this.tabControl7.TabIndex = (59);
            // 
            // tabPage29
            // 
            this.tabPage29.Controls.Add(this.btTextLogoRemove);
            this.tabPage29.Controls.Add(this.btTextLogoEdit);
            this.tabPage29.Controls.Add(this.lbTextLogos);
            this.tabPage29.Controls.Add(this.btTextLogoAdd);
            this.tabPage29.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage29.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage29.Name = ("tabPage29");
            this.tabPage29.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage29.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage29.TabIndex = (0);
            this.tabPage29.Text = ("Text logo");
            this.tabPage29.UseVisualStyleBackColor = (true);
            // 
            // btTextLogoRemove
            // 
            this.btTextLogoRemove.Location = (new global::System.Drawing.Point(342, 414));
            this.btTextLogoRemove.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btTextLogoRemove.Name = ("btTextLogoRemove");
            this.btTextLogoRemove.Size = (new global::System.Drawing.Size(98, 44));
            this.btTextLogoRemove.TabIndex = (7);
            this.btTextLogoRemove.Text = ("Remove");
            this.btTextLogoRemove.UseVisualStyleBackColor = (true);
            this.btTextLogoRemove.Click += (this.btTextLogoRemove_Click);
            // 
            // btTextLogoEdit
            // 
            this.btTextLogoEdit.Location = (new global::System.Drawing.Point(122, 414));
            this.btTextLogoEdit.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btTextLogoEdit.Name = ("btTextLogoEdit");
            this.btTextLogoEdit.Size = (new global::System.Drawing.Size(98, 44));
            this.btTextLogoEdit.TabIndex = (6);
            this.btTextLogoEdit.Text = ("Edit");
            this.btTextLogoEdit.UseVisualStyleBackColor = (true);
            this.btTextLogoEdit.Click += (this.btTextLogoEdit_Click);
            // 
            // lbTextLogos
            // 
            this.lbTextLogos.FormattingEnabled = (true);
            this.lbTextLogos.ItemHeight = (25);
            this.lbTextLogos.Location = (new global::System.Drawing.Point(18, 22));
            this.lbTextLogos.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbTextLogos.Name = ("lbTextLogos");
            this.lbTextLogos.Size = (new global::System.Drawing.Size(426, 379));
            this.lbTextLogos.TabIndex = (5);
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = (new global::System.Drawing.Point(12, 414));
            this.btTextLogoAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btTextLogoAdd.Name = ("btTextLogoAdd");
            this.btTextLogoAdd.Size = (new global::System.Drawing.Size(98, 44));
            this.btTextLogoAdd.TabIndex = (4);
            this.btTextLogoAdd.Text = ("Add");
            this.btTextLogoAdd.UseVisualStyleBackColor = (true);
            this.btTextLogoAdd.Click += (this.btTextLogoAdd_Click);
            // 
            // tabPage42
            // 
            this.tabPage42.Controls.Add(this.btImageLogoRemove);
            this.tabPage42.Controls.Add(this.btImageLogoEdit);
            this.tabPage42.Controls.Add(this.lbImageLogos);
            this.tabPage42.Controls.Add(this.btImageLogoAdd);
            this.tabPage42.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage42.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage42.Name = ("tabPage42");
            this.tabPage42.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage42.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage42.TabIndex = (1);
            this.tabPage42.Text = ("Image logo");
            this.tabPage42.UseVisualStyleBackColor = (true);
            // 
            // btImageLogoRemove
            // 
            this.btImageLogoRemove.Location = (new global::System.Drawing.Point(342, 414));
            this.btImageLogoRemove.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btImageLogoRemove.Name = ("btImageLogoRemove");
            this.btImageLogoRemove.Size = (new global::System.Drawing.Size(98, 44));
            this.btImageLogoRemove.TabIndex = (11);
            this.btImageLogoRemove.Text = ("Remove");
            this.btImageLogoRemove.UseVisualStyleBackColor = (true);
            this.btImageLogoRemove.Click += (this.btImageLogoRemove_Click);
            // 
            // btImageLogoEdit
            // 
            this.btImageLogoEdit.Location = (new global::System.Drawing.Point(122, 414));
            this.btImageLogoEdit.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btImageLogoEdit.Name = ("btImageLogoEdit");
            this.btImageLogoEdit.Size = (new global::System.Drawing.Size(98, 44));
            this.btImageLogoEdit.TabIndex = (10);
            this.btImageLogoEdit.Text = ("Edit");
            this.btImageLogoEdit.UseVisualStyleBackColor = (true);
            this.btImageLogoEdit.Click += (this.btImageLogoEdit_Click);
            // 
            // lbImageLogos
            // 
            this.lbImageLogos.FormattingEnabled = (true);
            this.lbImageLogos.ItemHeight = (25);
            this.lbImageLogos.Location = (new global::System.Drawing.Point(18, 22));
            this.lbImageLogos.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbImageLogos.Name = ("lbImageLogos");
            this.lbImageLogos.Size = (new global::System.Drawing.Size(426, 379));
            this.lbImageLogos.TabIndex = (9);
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = (new global::System.Drawing.Point(12, 414));
            this.btImageLogoAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btImageLogoAdd.Name = ("btImageLogoAdd");
            this.btImageLogoAdd.Size = (new global::System.Drawing.Size(98, 44));
            this.btImageLogoAdd.TabIndex = (8);
            this.btImageLogoAdd.Text = ("Add");
            this.btImageLogoAdd.UseVisualStyleBackColor = (true);
            this.btImageLogoAdd.Click += (this.btImageLogoAdd_Click);
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.groupBox37);
            this.tabPage18.Controls.Add(this.cbZoom);
            this.tabPage18.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage18.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage18.Name = ("tabPage18");
            this.tabPage18.Padding = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage18.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage18.TabIndex = (2);
            this.tabPage18.Text = ("Zoom");
            this.tabPage18.UseVisualStyleBackColor = (true);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.btEffZoomRight);
            this.groupBox37.Controls.Add(this.btEffZoomLeft);
            this.groupBox37.Controls.Add(this.btEffZoomOut);
            this.groupBox37.Controls.Add(this.btEffZoomIn);
            this.groupBox37.Controls.Add(this.btEffZoomDown);
            this.groupBox37.Controls.Add(this.btEffZoomUp);
            this.groupBox37.Location = (new global::System.Drawing.Point(142, 98));
            this.groupBox37.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox37.Name = ("groupBox37");
            this.groupBox37.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox37.Size = (new global::System.Drawing.Size(198, 200));
            this.groupBox37.TabIndex = (18);
            this.groupBox37.TabStop = (false);
            this.groupBox37.Text = ("Zoom");
            // 
            // btEffZoomRight
            // 
            this.btEffZoomRight.Location = (new global::System.Drawing.Point(142, 64));
            this.btEffZoomRight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomRight.Name = ("btEffZoomRight");
            this.btEffZoomRight.Size = (new global::System.Drawing.Size(36, 92));
            this.btEffZoomRight.TabIndex = (5);
            this.btEffZoomRight.Text = ("R");
            this.btEffZoomRight.UseVisualStyleBackColor = (true);
            this.btEffZoomRight.Click += (this.btEffZoomRight_Click);
            // 
            // btEffZoomLeft
            // 
            this.btEffZoomLeft.Location = (new global::System.Drawing.Point(22, 61));
            this.btEffZoomLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomLeft.Name = ("btEffZoomLeft");
            this.btEffZoomLeft.Size = (new global::System.Drawing.Size(36, 92));
            this.btEffZoomLeft.TabIndex = (4);
            this.btEffZoomLeft.Text = ("L");
            this.btEffZoomLeft.UseVisualStyleBackColor = (true);
            this.btEffZoomLeft.Click += (this.btEffZoomLeft_Click);
            // 
            // btEffZoomOut
            // 
            this.btEffZoomOut.Location = (new global::System.Drawing.Point(102, 86));
            this.btEffZoomOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomOut.Name = ("btEffZoomOut");
            this.btEffZoomOut.Size = (new global::System.Drawing.Size(38, 44));
            this.btEffZoomOut.TabIndex = (3);
            this.btEffZoomOut.Text = ("-");
            this.btEffZoomOut.UseVisualStyleBackColor = (true);
            this.btEffZoomOut.Click += (this.btEffZoomOut_Click);
            // 
            // btEffZoomIn
            // 
            this.btEffZoomIn.Location = (new global::System.Drawing.Point(58, 86));
            this.btEffZoomIn.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomIn.Name = ("btEffZoomIn");
            this.btEffZoomIn.Size = (new global::System.Drawing.Size(38, 44));
            this.btEffZoomIn.TabIndex = (2);
            this.btEffZoomIn.Text = ("+");
            this.btEffZoomIn.UseVisualStyleBackColor = (true);
            this.btEffZoomIn.Click += (this.btEffZoomIn_Click);
            // 
            // btEffZoomDown
            // 
            this.btEffZoomDown.Location = (new global::System.Drawing.Point(58, 131));
            this.btEffZoomDown.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomDown.Name = ("btEffZoomDown");
            this.btEffZoomDown.Size = (new global::System.Drawing.Size(84, 44));
            this.btEffZoomDown.TabIndex = (1);
            this.btEffZoomDown.Text = ("Down");
            this.btEffZoomDown.UseVisualStyleBackColor = (true);
            this.btEffZoomDown.Click += (this.btEffZoomDown_Click);
            // 
            // btEffZoomUp
            // 
            this.btEffZoomUp.Location = (new global::System.Drawing.Point(58, 39));
            this.btEffZoomUp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEffZoomUp.Name = ("btEffZoomUp");
            this.btEffZoomUp.Size = (new global::System.Drawing.Size(84, 44));
            this.btEffZoomUp.TabIndex = (0);
            this.btEffZoomUp.Text = ("Up");
            this.btEffZoomUp.UseVisualStyleBackColor = (true);
            this.btEffZoomUp.Click += (this.btEffZoomUp_Click);
            // 
            // cbZoom
            // 
            this.cbZoom.AutoSize = (true);
            this.cbZoom.Location = (new global::System.Drawing.Point(20, 30));
            this.cbZoom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbZoom.Name = ("cbZoom");
            this.cbZoom.Size = (new global::System.Drawing.Size(101, 29));
            this.cbZoom.TabIndex = (17);
            this.cbZoom.Text = ("Enabled");
            this.cbZoom.UseVisualStyleBackColor = (true);
            this.cbZoom.CheckedChanged += (this.cbZoom_CheckedChanged);
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.groupBox40);
            this.tabPage19.Controls.Add(this.groupBox39);
            this.tabPage19.Controls.Add(this.groupBox38);
            this.tabPage19.Controls.Add(this.cbPan);
            this.tabPage19.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage19.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage19.Name = ("tabPage19");
            this.tabPage19.Padding = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage19.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage19.TabIndex = (3);
            this.tabPage19.Text = ("Pan");
            this.tabPage19.UseVisualStyleBackColor = (true);
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
            this.groupBox40.Location = (new global::System.Drawing.Point(20, 311));
            this.groupBox40.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.groupBox40.Name = ("groupBox40");
            this.groupBox40.Padding = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.groupBox40.Size = (new global::System.Drawing.Size(280, 148));
            this.groupBox40.TabIndex = (58);
            this.groupBox40.TabStop = (false);
            this.groupBox40.Text = ("Destination rect");
            // 
            // edPanDestHeight
            // 
            this.edPanDestHeight.Location = (new global::System.Drawing.Point(204, 98));
            this.edPanDestHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanDestHeight.Name = ("edPanDestHeight");
            this.edPanDestHeight.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanDestHeight.TabIndex = (17);
            this.edPanDestHeight.Text = ("240");
            // 
            // label302
            // 
            this.label302.AutoSize = (true);
            this.label302.Location = (new global::System.Drawing.Point(136, 105));
            this.label302.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label302.Name = ("label302");
            this.label302.Size = (new global::System.Drawing.Size(65, 25));
            this.label302.TabIndex = (16);
            this.label302.Text = ("Height");
            // 
            // edPanDestWidth
            // 
            this.edPanDestWidth.Location = (new global::System.Drawing.Point(204, 48));
            this.edPanDestWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanDestWidth.Name = ("edPanDestWidth");
            this.edPanDestWidth.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanDestWidth.TabIndex = (15);
            this.edPanDestWidth.Text = ("320");
            // 
            // label303
            // 
            this.label303.AutoSize = (true);
            this.label303.Location = (new global::System.Drawing.Point(136, 55));
            this.label303.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label303.Name = ("label303");
            this.label303.Size = (new global::System.Drawing.Size(60, 25));
            this.label303.TabIndex = (14);
            this.label303.Text = ("Width");
            // 
            // edPanDestTop
            // 
            this.edPanDestTop.Location = (new global::System.Drawing.Point(71, 100));
            this.edPanDestTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanDestTop.Name = ("edPanDestTop");
            this.edPanDestTop.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanDestTop.TabIndex = (12);
            this.edPanDestTop.Text = ("0");
            // 
            // label304
            // 
            this.label304.AutoSize = (true);
            this.label304.Location = (new global::System.Drawing.Point(22, 105));
            this.label304.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label304.Name = ("label304");
            this.label304.Size = (new global::System.Drawing.Size(41, 25));
            this.label304.TabIndex = (11);
            this.label304.Text = ("Top");
            // 
            // edPanDestLeft
            // 
            this.edPanDestLeft.Location = (new global::System.Drawing.Point(71, 50));
            this.edPanDestLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanDestLeft.Name = ("edPanDestLeft");
            this.edPanDestLeft.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanDestLeft.TabIndex = (10);
            this.edPanDestLeft.Text = ("0");
            // 
            // label305
            // 
            this.label305.AutoSize = (true);
            this.label305.Location = (new global::System.Drawing.Point(22, 55));
            this.label305.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label305.Name = ("label305");
            this.label305.Size = (new global::System.Drawing.Size(41, 25));
            this.label305.TabIndex = (9);
            this.label305.Text = ("Left");
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
            this.groupBox39.Location = (new global::System.Drawing.Point(20, 155));
            this.groupBox39.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.groupBox39.Name = ("groupBox39");
            this.groupBox39.Padding = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.groupBox39.Size = (new global::System.Drawing.Size(280, 148));
            this.groupBox39.TabIndex = (57);
            this.groupBox39.TabStop = (false);
            this.groupBox39.Text = ("Source rect");
            // 
            // edPanSourceHeight
            // 
            this.edPanSourceHeight.Location = (new global::System.Drawing.Point(204, 98));
            this.edPanSourceHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanSourceHeight.Name = ("edPanSourceHeight");
            this.edPanSourceHeight.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanSourceHeight.TabIndex = (17);
            this.edPanSourceHeight.Text = ("480");
            // 
            // label298
            // 
            this.label298.AutoSize = (true);
            this.label298.Location = (new global::System.Drawing.Point(136, 105));
            this.label298.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label298.Name = ("label298");
            this.label298.Size = (new global::System.Drawing.Size(65, 25));
            this.label298.TabIndex = (16);
            this.label298.Text = ("Height");
            // 
            // edPanSourceWidth
            // 
            this.edPanSourceWidth.Location = (new global::System.Drawing.Point(204, 48));
            this.edPanSourceWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanSourceWidth.Name = ("edPanSourceWidth");
            this.edPanSourceWidth.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanSourceWidth.TabIndex = (15);
            this.edPanSourceWidth.Text = ("640");
            // 
            // label299
            // 
            this.label299.AutoSize = (true);
            this.label299.Location = (new global::System.Drawing.Point(136, 55));
            this.label299.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label299.Name = ("label299");
            this.label299.Size = (new global::System.Drawing.Size(60, 25));
            this.label299.TabIndex = (14);
            this.label299.Text = ("Width");
            // 
            // edPanSourceTop
            // 
            this.edPanSourceTop.Location = (new global::System.Drawing.Point(71, 100));
            this.edPanSourceTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanSourceTop.Name = ("edPanSourceTop");
            this.edPanSourceTop.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanSourceTop.TabIndex = (12);
            this.edPanSourceTop.Text = ("0");
            // 
            // label300
            // 
            this.label300.AutoSize = (true);
            this.label300.Location = (new global::System.Drawing.Point(22, 105));
            this.label300.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label300.Name = ("label300");
            this.label300.Size = (new global::System.Drawing.Size(41, 25));
            this.label300.TabIndex = (11);
            this.label300.Text = ("Top");
            // 
            // edPanSourceLeft
            // 
            this.edPanSourceLeft.Location = (new global::System.Drawing.Point(71, 50));
            this.edPanSourceLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanSourceLeft.Name = ("edPanSourceLeft");
            this.edPanSourceLeft.Size = (new global::System.Drawing.Size(53, 31));
            this.edPanSourceLeft.TabIndex = (10);
            this.edPanSourceLeft.Text = ("0");
            // 
            // label301
            // 
            this.label301.AutoSize = (true);
            this.label301.Location = (new global::System.Drawing.Point(22, 55));
            this.label301.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label301.Name = ("label301");
            this.label301.Size = (new global::System.Drawing.Size(41, 25));
            this.label301.TabIndex = (9);
            this.label301.Text = ("Left");
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.edPanStopTime);
            this.groupBox38.Controls.Add(this.label296);
            this.groupBox38.Controls.Add(this.edPanStartTime);
            this.groupBox38.Controls.Add(this.label297);
            this.groupBox38.Location = (new global::System.Drawing.Point(20, 56));
            this.groupBox38.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox38.Name = ("groupBox38");
            this.groupBox38.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox38.Size = (new global::System.Drawing.Size(280, 89));
            this.groupBox38.TabIndex = (56);
            this.groupBox38.TabStop = (false);
            this.groupBox38.Text = ("Duration");
            // 
            // edPanStopTime
            // 
            this.edPanStopTime.Location = (new global::System.Drawing.Point(196, 36));
            this.edPanStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanStopTime.Name = ("edPanStopTime");
            this.edPanStopTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edPanStopTime.TabIndex = (34);
            this.edPanStopTime.Text = ("15000");
            this.edPanStopTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label296
            // 
            this.label296.AutoSize = (true);
            this.label296.Location = (new global::System.Drawing.Point(148, 42));
            this.label296.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label296.Name = ("label296");
            this.label296.Size = (new global::System.Drawing.Size(49, 25));
            this.label296.TabIndex = (33);
            this.label296.Text = ("Stop");
            // 
            // edPanStartTime
            // 
            this.edPanStartTime.Location = (new global::System.Drawing.Point(71, 36));
            this.edPanStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edPanStartTime.Name = ("edPanStartTime");
            this.edPanStartTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edPanStartTime.TabIndex = (32);
            this.edPanStartTime.Text = ("5000");
            this.edPanStartTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label297
            // 
            this.label297.AutoSize = (true);
            this.label297.Location = (new global::System.Drawing.Point(18, 42));
            this.label297.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label297.Name = ("label297");
            this.label297.Size = (new global::System.Drawing.Size(48, 25));
            this.label297.TabIndex = (31);
            this.label297.Text = ("Start");
            // 
            // cbPan
            // 
            this.cbPan.AutoSize = (true);
            this.cbPan.Location = (new global::System.Drawing.Point(20, 11));
            this.cbPan.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbPan.Name = ("cbPan");
            this.cbPan.Size = (new global::System.Drawing.Size(101, 29));
            this.cbPan.TabIndex = (55);
            this.cbPan.Text = ("Enabled");
            this.cbPan.UseVisualStyleBackColor = (true);
            this.cbPan.CheckedChanged += (this.cbPan_CheckedChanged);
            // 
            // tabPage22
            // 
            this.tabPage22.Controls.Add(this.rbFadeOut);
            this.tabPage22.Controls.Add(this.rbFadeIn);
            this.tabPage22.Controls.Add(this.groupBox45);
            this.tabPage22.Controls.Add(this.cbFadeInOut);
            this.tabPage22.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage22.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage22.Name = ("tabPage22");
            this.tabPage22.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage22.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage22.TabIndex = (4);
            this.tabPage22.Text = ("Fade-in/out");
            this.tabPage22.UseVisualStyleBackColor = (true);
            // 
            // rbFadeOut
            // 
            this.rbFadeOut.AutoSize = (true);
            this.rbFadeOut.Location = (new global::System.Drawing.Point(169, 198));
            this.rbFadeOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbFadeOut.Name = ("rbFadeOut");
            this.rbFadeOut.Size = (new global::System.Drawing.Size(108, 29));
            this.rbFadeOut.TabIndex = (60);
            this.rbFadeOut.TabStop = (true);
            this.rbFadeOut.Text = ("Fade-out");
            this.rbFadeOut.UseVisualStyleBackColor = (true);
            // 
            // rbFadeIn
            // 
            this.rbFadeIn.AutoSize = (true);
            this.rbFadeIn.Checked = (true);
            this.rbFadeIn.Location = (new global::System.Drawing.Point(18, 198));
            this.rbFadeIn.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbFadeIn.Name = ("rbFadeIn");
            this.rbFadeIn.Size = (new global::System.Drawing.Size(95, 29));
            this.rbFadeIn.TabIndex = (59);
            this.rbFadeIn.TabStop = (true);
            this.rbFadeIn.Text = ("Fade-in");
            this.rbFadeIn.UseVisualStyleBackColor = (true);
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.edFadeInOutStopTime);
            this.groupBox45.Controls.Add(this.label329);
            this.groupBox45.Controls.Add(this.edFadeInOutStartTime);
            this.groupBox45.Controls.Add(this.label330);
            this.groupBox45.Location = (new global::System.Drawing.Point(18, 98));
            this.groupBox45.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox45.Name = ("groupBox45");
            this.groupBox45.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox45.Size = (new global::System.Drawing.Size(280, 89));
            this.groupBox45.TabIndex = (58);
            this.groupBox45.TabStop = (false);
            this.groupBox45.Text = ("Duration");
            // 
            // edFadeInOutStopTime
            // 
            this.edFadeInOutStopTime.Location = (new global::System.Drawing.Point(196, 36));
            this.edFadeInOutStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeInOutStopTime.Name = ("edFadeInOutStopTime");
            this.edFadeInOutStopTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edFadeInOutStopTime.TabIndex = (34);
            this.edFadeInOutStopTime.Text = ("15000");
            this.edFadeInOutStopTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label329
            // 
            this.label329.AutoSize = (true);
            this.label329.Location = (new global::System.Drawing.Point(148, 42));
            this.label329.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label329.Name = ("label329");
            this.label329.Size = (new global::System.Drawing.Size(49, 25));
            this.label329.TabIndex = (33);
            this.label329.Text = ("Stop");
            // 
            // edFadeInOutStartTime
            // 
            this.edFadeInOutStartTime.Location = (new global::System.Drawing.Point(71, 36));
            this.edFadeInOutStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeInOutStartTime.Name = ("edFadeInOutStartTime");
            this.edFadeInOutStartTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edFadeInOutStartTime.TabIndex = (32);
            this.edFadeInOutStartTime.Text = ("5000");
            this.edFadeInOutStartTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label330
            // 
            this.label330.AutoSize = (true);
            this.label330.Location = (new global::System.Drawing.Point(18, 42));
            this.label330.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label330.Name = ("label330");
            this.label330.Size = (new global::System.Drawing.Size(48, 25));
            this.label330.TabIndex = (31);
            this.label330.Text = ("Start");
            // 
            // cbFadeInOut
            // 
            this.cbFadeInOut.AutoSize = (true);
            this.cbFadeInOut.Location = (new global::System.Drawing.Point(18, 31));
            this.cbFadeInOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFadeInOut.Name = ("cbFadeInOut");
            this.cbFadeInOut.Size = (new global::System.Drawing.Size(101, 29));
            this.cbFadeInOut.TabIndex = (57);
            this.cbFadeInOut.Text = ("Enabled");
            this.cbFadeInOut.UseVisualStyleBackColor = (true);
            this.cbFadeInOut.CheckedChanged += (this.cbFadeInOut_CheckedChanged);
            // 
            // tabPage43
            // 
            this.tabPage43.Controls.Add(this.cbLiveRotationStretch);
            this.tabPage43.Controls.Add(this.label392);
            this.tabPage43.Controls.Add(this.label391);
            this.tabPage43.Controls.Add(this.tbLiveRotationAngle);
            this.tabPage43.Controls.Add(this.label390);
            this.tabPage43.Controls.Add(this.cbLiveRotation);
            this.tabPage43.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage43.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage43.Name = ("tabPage43");
            this.tabPage43.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage43.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage43.TabIndex = (5);
            this.tabPage43.Text = ("Live rotation");
            this.tabPage43.UseVisualStyleBackColor = (true);
            // 
            // cbLiveRotationStretch
            // 
            this.cbLiveRotationStretch.AutoSize = (true);
            this.cbLiveRotationStretch.Location = (new global::System.Drawing.Point(20, 264));
            this.cbLiveRotationStretch.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbLiveRotationStretch.Name = ("cbLiveRotationStretch");
            this.cbLiveRotationStretch.Size = (new global::System.Drawing.Size(259, 29));
            this.cbLiveRotationStretch.TabIndex = (65);
            this.cbLiveRotationStretch.Text = ("Stretch  if angle is 90 or 270");
            this.cbLiveRotationStretch.UseVisualStyleBackColor = (true);
            this.cbLiveRotationStretch.CheckedChanged += (this.cbLiveRotationStretch_CheckedChanged);
            // 
            // label392
            // 
            this.label392.AutoSize = (true);
            this.label392.Location = (new global::System.Drawing.Point(218, 214));
            this.label392.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label392.Name = ("label392");
            this.label392.Size = (new global::System.Drawing.Size(42, 25));
            this.label392.TabIndex = (64);
            this.label392.Text = ("360");
            // 
            // label391
            // 
            this.label391.AutoSize = (true);
            this.label391.Location = (new global::System.Drawing.Point(16, 214));
            this.label391.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label391.Name = ("label391");
            this.label391.Size = (new global::System.Drawing.Size(22, 25));
            this.label391.TabIndex = (63);
            this.label391.Text = ("0");
            // 
            // tbLiveRotationAngle
            // 
            this.tbLiveRotationAngle.Location = (new global::System.Drawing.Point(20, 120));
            this.tbLiveRotationAngle.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbLiveRotationAngle.Maximum = (360);
            this.tbLiveRotationAngle.Name = ("tbLiveRotationAngle");
            this.tbLiveRotationAngle.Size = (new global::System.Drawing.Size(238, 69));
            this.tbLiveRotationAngle.TabIndex = (62);
            this.tbLiveRotationAngle.TickFrequency = (5);
            this.tbLiveRotationAngle.Value = (90);
            this.tbLiveRotationAngle.Scroll += (this.tbLiveRotationAngle_Scroll);
            // 
            // label390
            // 
            this.label390.AutoSize = (true);
            this.label390.Location = (new global::System.Drawing.Point(16, 84));
            this.label390.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label390.Name = ("label390");
            this.label390.Size = (new global::System.Drawing.Size(58, 25));
            this.label390.TabIndex = (61);
            this.label390.Text = ("Angle");
            // 
            // cbLiveRotation
            // 
            this.cbLiveRotation.AutoSize = (true);
            this.cbLiveRotation.Location = (new global::System.Drawing.Point(20, 22));
            this.cbLiveRotation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbLiveRotation.Name = ("cbLiveRotation");
            this.cbLiveRotation.Size = (new global::System.Drawing.Size(101, 29));
            this.cbLiveRotation.TabIndex = (60);
            this.cbLiveRotation.Text = ("Enabled");
            this.cbLiveRotation.UseVisualStyleBackColor = (true);
            this.cbLiveRotation.CheckedChanged += (this.cbLiveRotation_CheckedChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbContrast.Location = (new global::System.Drawing.Point(4, 206));
            this.tbContrast.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbContrast.Maximum = (255);
            this.tbContrast.Name = ("tbContrast");
            this.tbContrast.Size = (new global::System.Drawing.Size(218, 69));
            this.tbContrast.TabIndex = (49);
            this.tbContrast.Scroll += (this.tbContrast_Scroll);
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbDarkness.Location = (new global::System.Drawing.Point(238, 206));
            this.tbDarkness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbDarkness.Maximum = (255);
            this.tbDarkness.Name = ("tbDarkness");
            this.tbDarkness.Size = (new global::System.Drawing.Size(218, 69));
            this.tbDarkness.TabIndex = (46);
            this.tbDarkness.Scroll += (this.tbDarkness_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbLightness.Location = (new global::System.Drawing.Point(4, 98));
            this.tbLightness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbLightness.Maximum = (255);
            this.tbLightness.Name = ("tbLightness");
            this.tbLightness.Size = (new global::System.Drawing.Size(218, 69));
            this.tbLightness.TabIndex = (45);
            this.tbLightness.Scroll += (this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbSaturation.Location = (new global::System.Drawing.Point(238, 98));
            this.tbSaturation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbSaturation.Maximum = (255);
            this.tbSaturation.Name = ("tbSaturation");
            this.tbSaturation.Size = (new global::System.Drawing.Size(218, 69));
            this.tbSaturation.TabIndex = (43);
            this.tbSaturation.Value = (255);
            this.tbSaturation.Scroll += (this.tbSaturation_Scroll);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = (true);
            this.cbInvert.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbInvert.Location = (new global::System.Drawing.Point(155, 288));
            this.cbInvert.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbInvert.Name = ("cbInvert");
            this.cbInvert.Size = (new global::System.Drawing.Size(83, 29));
            this.cbInvert.TabIndex = (41);
            this.cbInvert.Text = ("Invert");
            this.cbInvert.UseVisualStyleBackColor = (true);
            this.cbInvert.CheckedChanged += (this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = (true);
            this.cbGreyscale.Location = (new global::System.Drawing.Point(21, 288));
            this.cbGreyscale.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGreyscale.Name = ("cbGreyscale");
            this.cbGreyscale.Size = (new global::System.Drawing.Size(112, 29));
            this.cbGreyscale.TabIndex = (39);
            this.cbGreyscale.Text = ("Greyscale");
            this.cbGreyscale.UseVisualStyleBackColor = (true);
            this.cbGreyscale.CheckedChanged += (this.cbGreyscale_CheckedChanged);
            // 
            // cbVideoEffects
            // 
            this.cbVideoEffects.AutoSize = (true);
            this.cbVideoEffects.Location = (new global::System.Drawing.Point(12, 16));
            this.cbVideoEffects.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVideoEffects.Name = ("cbVideoEffects");
            this.cbVideoEffects.Size = (new global::System.Drawing.Size(101, 29));
            this.cbVideoEffects.TabIndex = (37);
            this.cbVideoEffects.Text = ("Enabled");
            this.cbVideoEffects.UseVisualStyleBackColor = (true);
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
            this.tabPage69.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage69.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage69.Name = ("tabPage69");
            this.tabPage69.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage69.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage69.TabIndex = (1);
            this.tabPage69.Text = ("Deinterlace");
            this.tabPage69.UseVisualStyleBackColor = (true);
            // 
            // label211
            // 
            this.label211.AutoSize = (true);
            this.label211.Location = (new global::System.Drawing.Point(168, 566));
            this.label211.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label211.Name = ("label211");
            this.label211.Size = (new global::System.Drawing.Size(69, 25));
            this.label211.TabIndex = (28);
            this.label211.Text = ("[0-255]");
            // 
            // edDeintTriangleWeight
            // 
            this.edDeintTriangleWeight.Location = (new global::System.Drawing.Point(171, 519));
            this.edDeintTriangleWeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintTriangleWeight.Name = ("edDeintTriangleWeight");
            this.edDeintTriangleWeight.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintTriangleWeight.TabIndex = (27);
            this.edDeintTriangleWeight.Text = ("180");
            // 
            // label212
            // 
            this.label212.AutoSize = (true);
            this.label212.Location = (new global::System.Drawing.Point(58, 525));
            this.label212.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label212.Name = ("label212");
            this.label212.Size = (new global::System.Drawing.Size(68, 25));
            this.label212.TabIndex = (26);
            this.label212.Text = ("Weight");
            // 
            // label210
            // 
            this.label210.AutoSize = (true);
            this.label210.Location = (new global::System.Drawing.Point(429, 369));
            this.label210.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label210.Name = ("label210");
            this.label210.Size = (new global::System.Drawing.Size(44, 25));
            this.label210.TabIndex = (25);
            this.label210.Text = ("/ 10");
            // 
            // label209
            // 
            this.label209.AutoSize = (true);
            this.label209.Location = (new global::System.Drawing.Point(429, 306));
            this.label209.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label209.Name = ("label209");
            this.label209.Size = (new global::System.Drawing.Size(44, 25));
            this.label209.TabIndex = (24);
            this.label209.Text = ("/ 10");
            // 
            // label206
            // 
            this.label206.AutoSize = (true);
            this.label206.Location = (new global::System.Drawing.Point(362, 409));
            this.label206.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label206.Name = ("label206");
            this.label206.Size = (new global::System.Drawing.Size(77, 25));
            this.label206.TabIndex = (23);
            this.label206.Text = ("[0.0-1.0]");
            // 
            // edDeintBlendConstants2
            // 
            this.edDeintBlendConstants2.Location = (new global::System.Drawing.Point(369, 364));
            this.edDeintBlendConstants2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintBlendConstants2.Name = ("edDeintBlendConstants2");
            this.edDeintBlendConstants2.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintBlendConstants2.TabIndex = (22);
            this.edDeintBlendConstants2.Text = ("9");
            // 
            // label207
            // 
            this.label207.AutoSize = (true);
            this.label207.Location = (new global::System.Drawing.Point(252, 369));
            this.label207.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label207.Name = ("label207");
            this.label207.Size = (new global::System.Drawing.Size(106, 25));
            this.label207.TabIndex = (21);
            this.label207.Text = ("Constants 2");
            // 
            // edDeintBlendConstants1
            // 
            this.edDeintBlendConstants1.Location = (new global::System.Drawing.Point(369, 300));
            this.edDeintBlendConstants1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintBlendConstants1.Name = ("edDeintBlendConstants1");
            this.edDeintBlendConstants1.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintBlendConstants1.TabIndex = (20);
            this.edDeintBlendConstants1.Text = ("3");
            // 
            // label208
            // 
            this.label208.AutoSize = (true);
            this.label208.Location = (new global::System.Drawing.Point(252, 306));
            this.label208.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label208.Name = ("label208");
            this.label208.Size = (new global::System.Drawing.Size(106, 25));
            this.label208.TabIndex = (19);
            this.label208.Text = ("Constants 1");
            // 
            // label204
            // 
            this.label204.AutoSize = (true);
            this.label204.Location = (new global::System.Drawing.Point(168, 409));
            this.label204.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label204.Name = ("label204");
            this.label204.Size = (new global::System.Drawing.Size(69, 25));
            this.label204.TabIndex = (18);
            this.label204.Text = ("[0-255]");
            // 
            // edDeintBlendThreshold2
            // 
            this.edDeintBlendThreshold2.Location = (new global::System.Drawing.Point(171, 364));
            this.edDeintBlendThreshold2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintBlendThreshold2.Name = ("edDeintBlendThreshold2");
            this.edDeintBlendThreshold2.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintBlendThreshold2.TabIndex = (17);
            this.edDeintBlendThreshold2.Text = ("9");
            // 
            // label205
            // 
            this.label205.AutoSize = (true);
            this.label205.Location = (new global::System.Drawing.Point(58, 369));
            this.label205.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label205.Name = ("label205");
            this.label205.Size = (new global::System.Drawing.Size(105, 25));
            this.label205.TabIndex = (16);
            this.label205.Text = ("Threshold 2");
            // 
            // edDeintBlendThreshold1
            // 
            this.edDeintBlendThreshold1.Location = (new global::System.Drawing.Point(171, 300));
            this.edDeintBlendThreshold1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintBlendThreshold1.Name = ("edDeintBlendThreshold1");
            this.edDeintBlendThreshold1.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintBlendThreshold1.TabIndex = (15);
            this.edDeintBlendThreshold1.Text = ("5");
            // 
            // label203
            // 
            this.label203.AutoSize = (true);
            this.label203.Location = (new global::System.Drawing.Point(58, 306));
            this.label203.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label203.Name = ("label203");
            this.label203.Size = (new global::System.Drawing.Size(105, 25));
            this.label203.TabIndex = (14);
            this.label203.Text = ("Threshold 1");
            // 
            // label202
            // 
            this.label202.AutoSize = (true);
            this.label202.Location = (new global::System.Drawing.Point(168, 198));
            this.label202.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label202.Name = ("label202");
            this.label202.Size = (new global::System.Drawing.Size(69, 25));
            this.label202.TabIndex = (13);
            this.label202.Text = ("[0-255]");
            // 
            // edDeintCAVTThreshold
            // 
            this.edDeintCAVTThreshold.Location = (new global::System.Drawing.Point(171, 152));
            this.edDeintCAVTThreshold.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edDeintCAVTThreshold.Name = ("edDeintCAVTThreshold");
            this.edDeintCAVTThreshold.Size = (new global::System.Drawing.Size(52, 31));
            this.edDeintCAVTThreshold.TabIndex = (12);
            this.edDeintCAVTThreshold.Text = ("20");
            // 
            // label104
            // 
            this.label104.AutoSize = (true);
            this.label104.Location = (new global::System.Drawing.Point(58, 158));
            this.label104.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label104.Name = ("label104");
            this.label104.Size = (new global::System.Drawing.Size(90, 25));
            this.label104.TabIndex = (11);
            this.label104.Text = ("Threshold");
            // 
            // rbDeintTriangleEnabled
            // 
            this.rbDeintTriangleEnabled.AutoSize = (true);
            this.rbDeintTriangleEnabled.Location = (new global::System.Drawing.Point(30, 469));
            this.rbDeintTriangleEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDeintTriangleEnabled.Name = ("rbDeintTriangleEnabled");
            this.rbDeintTriangleEnabled.Size = (new global::System.Drawing.Size(97, 29));
            this.rbDeintTriangleEnabled.TabIndex = (10);
            this.rbDeintTriangleEnabled.Text = ("Triangle");
            this.rbDeintTriangleEnabled.UseVisualStyleBackColor = (true);
            // 
            // rbDeintBlendEnabled
            // 
            this.rbDeintBlendEnabled.AutoSize = (true);
            this.rbDeintBlendEnabled.Location = (new global::System.Drawing.Point(30, 244));
            this.rbDeintBlendEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDeintBlendEnabled.Name = ("rbDeintBlendEnabled");
            this.rbDeintBlendEnabled.Size = (new global::System.Drawing.Size(81, 29));
            this.rbDeintBlendEnabled.TabIndex = (9);
            this.rbDeintBlendEnabled.Text = ("Blend");
            this.rbDeintBlendEnabled.UseVisualStyleBackColor = (true);
            // 
            // rbDeintCAVTEnabled
            // 
            this.rbDeintCAVTEnabled.AutoSize = (true);
            this.rbDeintCAVTEnabled.Checked = (true);
            this.rbDeintCAVTEnabled.Location = (new global::System.Drawing.Point(30, 100));
            this.rbDeintCAVTEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDeintCAVTEnabled.Name = ("rbDeintCAVTEnabled");
            this.rbDeintCAVTEnabled.Size = (new global::System.Drawing.Size(372, 29));
            this.rbDeintCAVTEnabled.TabIndex = (8);
            this.rbDeintCAVTEnabled.TabStop = (true);
            this.rbDeintCAVTEnabled.Text = ("Content Adaptive Vertical Temporal (CAVT)");
            this.rbDeintCAVTEnabled.UseVisualStyleBackColor = (true);
            // 
            // cbDeinterlace
            // 
            this.cbDeinterlace.AutoSize = (true);
            this.cbDeinterlace.Location = (new global::System.Drawing.Point(30, 31));
            this.cbDeinterlace.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDeinterlace.Name = ("cbDeinterlace");
            this.cbDeinterlace.Size = (new global::System.Drawing.Size(101, 29));
            this.cbDeinterlace.TabIndex = (7);
            this.cbDeinterlace.Text = ("Enabled");
            this.cbDeinterlace.UseVisualStyleBackColor = (true);
            // 
            // tabPage59
            // 
            this.tabPage59.Controls.Add(this.rbDenoiseCAST);
            this.tabPage59.Controls.Add(this.rbDenoiseMosquito);
            this.tabPage59.Controls.Add(this.cbDenoise);
            this.tabPage59.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage59.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage59.Name = ("tabPage59");
            this.tabPage59.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage59.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage59.TabIndex = (4);
            this.tabPage59.Text = ("Denoise");
            this.tabPage59.UseVisualStyleBackColor = (true);
            // 
            // rbDenoiseCAST
            // 
            this.rbDenoiseCAST.AutoSize = (true);
            this.rbDenoiseCAST.Location = (new global::System.Drawing.Point(30, 152));
            this.rbDenoiseCAST.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDenoiseCAST.Name = ("rbDenoiseCAST");
            this.rbDenoiseCAST.Size = (new global::System.Drawing.Size(369, 29));
            this.rbDenoiseCAST.TabIndex = (10);
            this.rbDenoiseCAST.Text = ("Content Adaptive Spatio-Temporal (CAST)");
            this.rbDenoiseCAST.UseVisualStyleBackColor = (true);
            // 
            // rbDenoiseMosquito
            // 
            this.rbDenoiseMosquito.AutoSize = (true);
            this.rbDenoiseMosquito.Checked = (true);
            this.rbDenoiseMosquito.Location = (new global::System.Drawing.Point(30, 100));
            this.rbDenoiseMosquito.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbDenoiseMosquito.Name = ("rbDenoiseMosquito");
            this.rbDenoiseMosquito.Size = (new global::System.Drawing.Size(114, 29));
            this.rbDenoiseMosquito.TabIndex = (9);
            this.rbDenoiseMosquito.TabStop = (true);
            this.rbDenoiseMosquito.Text = ("Mosquito");
            this.rbDenoiseMosquito.UseVisualStyleBackColor = (true);
            // 
            // cbDenoise
            // 
            this.cbDenoise.AutoSize = (true);
            this.cbDenoise.Location = (new global::System.Drawing.Point(30, 31));
            this.cbDenoise.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDenoise.Name = ("cbDenoise");
            this.cbDenoise.Size = (new global::System.Drawing.Size(101, 29));
            this.cbDenoise.TabIndex = (8);
            this.cbDenoise.Text = ("Enabled");
            this.cbDenoise.UseVisualStyleBackColor = (true);
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
            this.tabPage51.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage51.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage51.Name = ("tabPage51");
            this.tabPage51.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage51.TabIndex = (9);
            this.tabPage51.Text = ("Effects (GPU)");
            this.tabPage51.UseVisualStyleBackColor = (true);
            // 
            // label22
            // 
            this.label22.AutoSize = (true);
            this.label22.Location = (new global::System.Drawing.Point(18, 519));
            this.label22.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label22.Name = ("label22");
            this.label22.Size = (new global::System.Drawing.Size(42, 25));
            this.label22.TabIndex = (100);
            this.label22.Text = ("Blur");
            // 
            // tbGPUBlur
            // 
            this.tbGPUBlur.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUBlur.Location = (new global::System.Drawing.Point(11, 548));
            this.tbGPUBlur.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUBlur.Maximum = (30);
            this.tbGPUBlur.Name = ("tbGPUBlur");
            this.tbGPUBlur.Size = (new global::System.Drawing.Size(218, 69));
            this.tbGPUBlur.TabIndex = (99);
            this.tbGPUBlur.Scroll += (this.tbGPUBlur_Scroll);
            // 
            // cbVideoEffectsGPUEnabled
            // 
            this.cbVideoEffectsGPUEnabled.AutoSize = (true);
            this.cbVideoEffectsGPUEnabled.Location = (new global::System.Drawing.Point(30, 31));
            this.cbVideoEffectsGPUEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVideoEffectsGPUEnabled.Name = ("cbVideoEffectsGPUEnabled");
            this.cbVideoEffectsGPUEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbVideoEffectsGPUEnabled.TabIndex = (97);
            this.cbVideoEffectsGPUEnabled.Text = ("Enabled");
            this.cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = (true);
            // 
            // cbGPUOldMovie
            // 
            this.cbGPUOldMovie.AutoSize = (true);
            this.cbGPUOldMovie.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbGPUOldMovie.Location = (new global::System.Drawing.Point(236, 461));
            this.cbGPUOldMovie.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUOldMovie.Name = ("cbGPUOldMovie");
            this.cbGPUOldMovie.Size = (new global::System.Drawing.Size(121, 29));
            this.cbGPUOldMovie.TabIndex = (96);
            this.cbGPUOldMovie.Text = ("Old movie");
            this.cbGPUOldMovie.UseVisualStyleBackColor = (true);
            this.cbGPUOldMovie.CheckedChanged += (this.cbGPUOldMovie_CheckedChanged);
            // 
            // cbGPUDeinterlace
            // 
            this.cbGPUDeinterlace.AutoSize = (true);
            this.cbGPUDeinterlace.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbGPUDeinterlace.Location = (new global::System.Drawing.Point(236, 416));
            this.cbGPUDeinterlace.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUDeinterlace.Name = ("cbGPUDeinterlace");
            this.cbGPUDeinterlace.Size = (new global::System.Drawing.Size(125, 29));
            this.cbGPUDeinterlace.TabIndex = (94);
            this.cbGPUDeinterlace.Text = ("Deinterlace");
            this.cbGPUDeinterlace.UseVisualStyleBackColor = (true);
            this.cbGPUDeinterlace.CheckedChanged += (this.cbGPUDeinterlace_CheckedChanged);
            // 
            // cbGPUDenoise
            // 
            this.cbGPUDenoise.AutoSize = (true);
            this.cbGPUDenoise.Location = (new global::System.Drawing.Point(22, 416));
            this.cbGPUDenoise.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUDenoise.Name = ("cbGPUDenoise");
            this.cbGPUDenoise.Size = (new global::System.Drawing.Size(102, 29));
            this.cbGPUDenoise.TabIndex = (93);
            this.cbGPUDenoise.Text = ("Denoise");
            this.cbGPUDenoise.UseVisualStyleBackColor = (true);
            this.cbGPUDenoise.CheckedChanged += (this.cbGPUDenoise_CheckedChanged);
            // 
            // cbGPUPixelate
            // 
            this.cbGPUPixelate.AutoSize = (true);
            this.cbGPUPixelate.Location = (new global::System.Drawing.Point(236, 370));
            this.cbGPUPixelate.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUPixelate.Name = ("cbGPUPixelate");
            this.cbGPUPixelate.Size = (new global::System.Drawing.Size(97, 29));
            this.cbGPUPixelate.TabIndex = (92);
            this.cbGPUPixelate.Text = ("Pixelate");
            this.cbGPUPixelate.UseVisualStyleBackColor = (true);
            this.cbGPUPixelate.CheckedChanged += (this.cbGPUPixelate_CheckedChanged);
            // 
            // cbGPUNightVision
            // 
            this.cbGPUNightVision.AutoSize = (true);
            this.cbGPUNightVision.Location = (new global::System.Drawing.Point(22, 370));
            this.cbGPUNightVision.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUNightVision.Name = ("cbGPUNightVision");
            this.cbGPUNightVision.Size = (new global::System.Drawing.Size(133, 29));
            this.cbGPUNightVision.TabIndex = (91);
            this.cbGPUNightVision.Text = ("Night vision");
            this.cbGPUNightVision.UseVisualStyleBackColor = (true);
            this.cbGPUNightVision.CheckedChanged += (this.cbGPUNightVision_CheckedChanged);
            // 
            // label383
            // 
            this.label383.AutoSize = (true);
            this.label383.Location = (new global::System.Drawing.Point(242, 192));
            this.label383.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label383.Name = ("label383");
            this.label383.Size = (new global::System.Drawing.Size(84, 25));
            this.label383.TabIndex = (90);
            this.label383.Text = ("Darkness");
            // 
            // label384
            // 
            this.label384.AutoSize = (true);
            this.label384.Location = (new global::System.Drawing.Point(18, 192));
            this.label384.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label384.Name = ("label384");
            this.label384.Size = (new global::System.Drawing.Size(79, 25));
            this.label384.TabIndex = (89);
            this.label384.Text = ("Contrast");
            // 
            // label385
            // 
            this.label385.AutoSize = (true);
            this.label385.Location = (new global::System.Drawing.Point(242, 92));
            this.label385.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label385.Name = ("label385");
            this.label385.Size = (new global::System.Drawing.Size(93, 25));
            this.label385.TabIndex = (88);
            this.label385.Text = ("Saturation");
            // 
            // label386
            // 
            this.label386.AutoSize = (true);
            this.label386.Location = (new global::System.Drawing.Point(18, 92));
            this.label386.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label386.Name = ("label386");
            this.label386.Size = (new global::System.Drawing.Size(86, 25));
            this.label386.TabIndex = (87);
            this.label386.Text = ("Lightness");
            // 
            // tbGPUContrast
            // 
            this.tbGPUContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUContrast.Location = (new global::System.Drawing.Point(11, 230));
            this.tbGPUContrast.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUContrast.Maximum = (255);
            this.tbGPUContrast.Name = ("tbGPUContrast");
            this.tbGPUContrast.Size = (new global::System.Drawing.Size(218, 69));
            this.tbGPUContrast.TabIndex = (86);
            this.tbGPUContrast.Value = (255);
            this.tbGPUContrast.Scroll += (this.tbGPUContrast_Scroll);
            // 
            // tbGPUDarkness
            // 
            this.tbGPUDarkness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUDarkness.Location = (new global::System.Drawing.Point(242, 230));
            this.tbGPUDarkness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUDarkness.Maximum = (255);
            this.tbGPUDarkness.Name = ("tbGPUDarkness");
            this.tbGPUDarkness.Size = (new global::System.Drawing.Size(218, 69));
            this.tbGPUDarkness.TabIndex = (85);
            this.tbGPUDarkness.Scroll += (this.tbGPUDarkness_Scroll);
            // 
            // tbGPULightness
            // 
            this.tbGPULightness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPULightness.Location = (new global::System.Drawing.Point(11, 120));
            this.tbGPULightness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPULightness.Maximum = (255);
            this.tbGPULightness.Name = ("tbGPULightness");
            this.tbGPULightness.Size = (new global::System.Drawing.Size(218, 69));
            this.tbGPULightness.TabIndex = (84);
            this.tbGPULightness.Scroll += (this.tbGPULightness_Scroll);
            // 
            // tbGPUSaturation
            // 
            this.tbGPUSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUSaturation.Location = (new global::System.Drawing.Point(242, 120));
            this.tbGPUSaturation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUSaturation.Maximum = (255);
            this.tbGPUSaturation.Name = ("tbGPUSaturation");
            this.tbGPUSaturation.Size = (new global::System.Drawing.Size(218, 69));
            this.tbGPUSaturation.TabIndex = (83);
            this.tbGPUSaturation.Value = (255);
            this.tbGPUSaturation.Scroll += (this.tbGPUSaturation_Scroll);
            // 
            // cbGPUInvert
            // 
            this.cbGPUInvert.AutoSize = (true);
            this.cbGPUInvert.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbGPUInvert.Location = (new global::System.Drawing.Point(236, 328));
            this.cbGPUInvert.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUInvert.Name = ("cbGPUInvert");
            this.cbGPUInvert.Size = (new global::System.Drawing.Size(83, 29));
            this.cbGPUInvert.TabIndex = (82);
            this.cbGPUInvert.Text = ("Invert");
            this.cbGPUInvert.UseVisualStyleBackColor = (true);
            this.cbGPUInvert.CheckedChanged += (this.cbGPUInvert_CheckedChanged);
            // 
            // cbGPUGreyscale
            // 
            this.cbGPUGreyscale.AutoSize = (true);
            this.cbGPUGreyscale.Location = (new global::System.Drawing.Point(22, 328));
            this.cbGPUGreyscale.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUGreyscale.Name = ("cbGPUGreyscale");
            this.cbGPUGreyscale.Size = (new global::System.Drawing.Size(112, 29));
            this.cbGPUGreyscale.TabIndex = (81);
            this.cbGPUGreyscale.Text = ("Greyscale");
            this.cbGPUGreyscale.UseVisualStyleBackColor = (true);
            this.cbGPUGreyscale.CheckedChanged += (this.cbGPUGreyscale_CheckedChanged);
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
            this.tabPage8.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage8.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage8.Name = ("tabPage8");
            this.tabPage8.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage8.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage8.TabIndex = (5);
            this.tabPage8.Text = ("Effects (Video renderer)");
            this.tabPage8.UseVisualStyleBackColor = (true);
            // 
            // lbAdjSaturationCurrent
            // 
            this.lbAdjSaturationCurrent.AutoSize = (true);
            this.lbAdjSaturationCurrent.Location = (new global::System.Drawing.Point(218, 511));
            this.lbAdjSaturationCurrent.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjSaturationCurrent.Name = ("lbAdjSaturationCurrent");
            this.lbAdjSaturationCurrent.Size = (new global::System.Drawing.Size(112, 25));
            this.lbAdjSaturationCurrent.TabIndex = (48);
            this.lbAdjSaturationCurrent.Text = ("Current = 40");
            // 
            // lbAdjSaturationMax
            // 
            this.lbAdjSaturationMax.AutoSize = (true);
            this.lbAdjSaturationMax.Location = (new global::System.Drawing.Point(111, 511));
            this.lbAdjSaturationMax.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjSaturationMax.Name = ("lbAdjSaturationMax");
            this.lbAdjSaturationMax.Size = (new global::System.Drawing.Size(97, 25));
            this.lbAdjSaturationMax.TabIndex = (47);
            this.lbAdjSaturationMax.Text = ("Max = 100");
            // 
            // lbAdjSaturationMin
            // 
            this.lbAdjSaturationMin.AutoSize = (true);
            this.lbAdjSaturationMin.Location = (new global::System.Drawing.Point(31, 511));
            this.lbAdjSaturationMin.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjSaturationMin.Name = ("lbAdjSaturationMin");
            this.lbAdjSaturationMin.Size = (new global::System.Drawing.Size(74, 25));
            this.lbAdjSaturationMin.TabIndex = (45);
            this.lbAdjSaturationMin.Text = ("Min = 1");
            // 
            // tbAdjSaturation
            // 
            this.tbAdjSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAdjSaturation.Location = (new global::System.Drawing.Point(22, 456));
            this.tbAdjSaturation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAdjSaturation.Maximum = (100);
            this.tbAdjSaturation.Name = ("tbAdjSaturation");
            this.tbAdjSaturation.Size = (new global::System.Drawing.Size(318, 69));
            this.tbAdjSaturation.TabIndex = (44);
            this.tbAdjSaturation.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAdjSaturation.Value = (50);
            this.tbAdjSaturation.Scroll += (this.tbAdjSaturation_Scroll);
            // 
            // label45
            // 
            this.label45.AutoSize = (true);
            this.label45.Location = (new global::System.Drawing.Point(18, 425));
            this.label45.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label45.Name = ("label45");
            this.label45.Size = (new global::System.Drawing.Size(93, 25));
            this.label45.TabIndex = (43);
            this.label45.Text = ("Saturation");
            // 
            // lbAdjHueCurrent
            // 
            this.lbAdjHueCurrent.AutoSize = (true);
            this.lbAdjHueCurrent.Location = (new global::System.Drawing.Point(218, 381));
            this.lbAdjHueCurrent.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjHueCurrent.Name = ("lbAdjHueCurrent");
            this.lbAdjHueCurrent.Size = (new global::System.Drawing.Size(112, 25));
            this.lbAdjHueCurrent.TabIndex = (42);
            this.lbAdjHueCurrent.Text = ("Current = 40");
            // 
            // lbAdjHueMax
            // 
            this.lbAdjHueMax.AutoSize = (true);
            this.lbAdjHueMax.Location = (new global::System.Drawing.Point(111, 381));
            this.lbAdjHueMax.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjHueMax.Name = ("lbAdjHueMax");
            this.lbAdjHueMax.Size = (new global::System.Drawing.Size(97, 25));
            this.lbAdjHueMax.TabIndex = (41);
            this.lbAdjHueMax.Text = ("Max = 100");
            // 
            // lbAdjHueMin
            // 
            this.lbAdjHueMin.AutoSize = (true);
            this.lbAdjHueMin.Location = (new global::System.Drawing.Point(31, 381));
            this.lbAdjHueMin.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjHueMin.Name = ("lbAdjHueMin");
            this.lbAdjHueMin.Size = (new global::System.Drawing.Size(74, 25));
            this.lbAdjHueMin.TabIndex = (39);
            this.lbAdjHueMin.Text = ("Min = 1");
            // 
            // tbAdjHue
            // 
            this.tbAdjHue.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAdjHue.Location = (new global::System.Drawing.Point(22, 325));
            this.tbAdjHue.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAdjHue.Maximum = (100);
            this.tbAdjHue.Name = ("tbAdjHue");
            this.tbAdjHue.Size = (new global::System.Drawing.Size(318, 69));
            this.tbAdjHue.TabIndex = (38);
            this.tbAdjHue.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAdjHue.Value = (50);
            this.tbAdjHue.Scroll += (this.tbAdjHue_Scroll);
            // 
            // label41
            // 
            this.label41.AutoSize = (true);
            this.label41.Location = (new global::System.Drawing.Point(18, 294));
            this.label41.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label41.Name = ("label41");
            this.label41.Size = (new global::System.Drawing.Size(44, 25));
            this.label41.TabIndex = (37);
            this.label41.Text = ("Hue");
            // 
            // lbAdjContrastCurrent
            // 
            this.lbAdjContrastCurrent.AutoSize = (true);
            this.lbAdjContrastCurrent.Location = (new global::System.Drawing.Point(218, 245));
            this.lbAdjContrastCurrent.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjContrastCurrent.Name = ("lbAdjContrastCurrent");
            this.lbAdjContrastCurrent.Size = (new global::System.Drawing.Size(112, 25));
            this.lbAdjContrastCurrent.TabIndex = (36);
            this.lbAdjContrastCurrent.Text = ("Current = 40");
            // 
            // lbAdjContrastMax
            // 
            this.lbAdjContrastMax.AutoSize = (true);
            this.lbAdjContrastMax.Location = (new global::System.Drawing.Point(111, 245));
            this.lbAdjContrastMax.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjContrastMax.Name = ("lbAdjContrastMax");
            this.lbAdjContrastMax.Size = (new global::System.Drawing.Size(97, 25));
            this.lbAdjContrastMax.TabIndex = (35);
            this.lbAdjContrastMax.Text = ("Max = 100");
            // 
            // lbAdjContrastMin
            // 
            this.lbAdjContrastMin.AutoSize = (true);
            this.lbAdjContrastMin.Location = (new global::System.Drawing.Point(31, 245));
            this.lbAdjContrastMin.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjContrastMin.Name = ("lbAdjContrastMin");
            this.lbAdjContrastMin.Size = (new global::System.Drawing.Size(74, 25));
            this.lbAdjContrastMin.TabIndex = (33);
            this.lbAdjContrastMin.Text = ("Min = 1");
            // 
            // tbAdjContrast
            // 
            this.tbAdjContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAdjContrast.Location = (new global::System.Drawing.Point(22, 191));
            this.tbAdjContrast.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAdjContrast.Maximum = (100);
            this.tbAdjContrast.Name = ("tbAdjContrast");
            this.tbAdjContrast.Size = (new global::System.Drawing.Size(318, 69));
            this.tbAdjContrast.TabIndex = (32);
            this.tbAdjContrast.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAdjContrast.Value = (50);
            this.tbAdjContrast.Scroll += (this.tbAdjContrast_Scroll);
            // 
            // label23
            // 
            this.label23.AutoSize = (true);
            this.label23.Location = (new global::System.Drawing.Point(18, 159));
            this.label23.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label23.Name = ("label23");
            this.label23.Size = (new global::System.Drawing.Size(79, 25));
            this.label23.TabIndex = (31);
            this.label23.Text = ("Contrast");
            // 
            // lbAdjBrightnessCurrent
            // 
            this.lbAdjBrightnessCurrent.AutoSize = (true);
            this.lbAdjBrightnessCurrent.Location = (new global::System.Drawing.Point(218, 116));
            this.lbAdjBrightnessCurrent.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjBrightnessCurrent.Name = ("lbAdjBrightnessCurrent");
            this.lbAdjBrightnessCurrent.Size = (new global::System.Drawing.Size(112, 25));
            this.lbAdjBrightnessCurrent.TabIndex = (30);
            this.lbAdjBrightnessCurrent.Text = ("Current = 40");
            // 
            // lbAdjBrightnessMax
            // 
            this.lbAdjBrightnessMax.AutoSize = (true);
            this.lbAdjBrightnessMax.Location = (new global::System.Drawing.Point(111, 116));
            this.lbAdjBrightnessMax.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjBrightnessMax.Name = ("lbAdjBrightnessMax");
            this.lbAdjBrightnessMax.Size = (new global::System.Drawing.Size(97, 25));
            this.lbAdjBrightnessMax.TabIndex = (29);
            this.lbAdjBrightnessMax.Text = ("Max = 100");
            // 
            // lbAdjBrightnessMin
            // 
            this.lbAdjBrightnessMin.AutoSize = (true);
            this.lbAdjBrightnessMin.Location = (new global::System.Drawing.Point(31, 116));
            this.lbAdjBrightnessMin.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAdjBrightnessMin.Name = ("lbAdjBrightnessMin");
            this.lbAdjBrightnessMin.Size = (new global::System.Drawing.Size(74, 25));
            this.lbAdjBrightnessMin.TabIndex = (27);
            this.lbAdjBrightnessMin.Text = ("Min = 1");
            // 
            // tbAdjBrightness
            // 
            this.tbAdjBrightness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAdjBrightness.Location = (new global::System.Drawing.Point(22, 59));
            this.tbAdjBrightness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAdjBrightness.Maximum = (100);
            this.tbAdjBrightness.Name = ("tbAdjBrightness");
            this.tbAdjBrightness.Size = (new global::System.Drawing.Size(318, 69));
            this.tbAdjBrightness.TabIndex = (26);
            this.tbAdjBrightness.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAdjBrightness.Value = (50);
            this.tbAdjBrightness.Scroll += (this.tbAdjBrightness_Scroll);
            // 
            // label24
            // 
            this.label24.AutoSize = (true);
            this.label24.Location = (new global::System.Drawing.Point(18, 30));
            this.label24.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label24.Name = ("label24");
            this.label24.Size = (new global::System.Drawing.Size(94, 25));
            this.label24.TabIndex = (25);
            this.label24.Text = ("Brightness");
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
            this.tabPage15.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage15.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage15.Name = ("tabPage15");
            this.tabPage15.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage15.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage15.TabIndex = (7);
            this.tabPage15.Text = ("Chroma key");
            this.tabPage15.UseVisualStyleBackColor = (true);
            // 
            // pnChromaKeyColor
            // 
            this.pnChromaKeyColor.BackColor = (global::System.Drawing.Color.Lime);
            this.pnChromaKeyColor.ForeColor = (global::System.Drawing.SystemColors.Control);
            this.pnChromaKeyColor.Location = (new global::System.Drawing.Point(91, 384));
            this.pnChromaKeyColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnChromaKeyColor.Name = ("pnChromaKeyColor");
            this.pnChromaKeyColor.Size = (new global::System.Drawing.Size(42, 45));
            this.pnChromaKeyColor.TabIndex = (33);
            this.pnChromaKeyColor.Click += (this.pnChromaKeyColor_Click);
            // 
            // btChromaKeySelectBGImage
            // 
            this.btChromaKeySelectBGImage.Location = (new global::System.Drawing.Point(424, 505));
            this.btChromaKeySelectBGImage.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btChromaKeySelectBGImage.Name = ("btChromaKeySelectBGImage");
            this.btChromaKeySelectBGImage.Size = (new global::System.Drawing.Size(40, 44));
            this.btChromaKeySelectBGImage.TabIndex = (32);
            this.btChromaKeySelectBGImage.Text = ("...");
            this.btChromaKeySelectBGImage.UseVisualStyleBackColor = (true);
            this.btChromaKeySelectBGImage.Click += (this.btChromaKeySelectBGImage_Click);
            // 
            // edChromaKeyImage
            // 
            this.edChromaKeyImage.Location = (new global::System.Drawing.Point(22, 508));
            this.edChromaKeyImage.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edChromaKeyImage.Name = ("edChromaKeyImage");
            this.edChromaKeyImage.Size = (new global::System.Drawing.Size(388, 31));
            this.edChromaKeyImage.TabIndex = (31);
            this.edChromaKeyImage.Text = ("c:\\Samples\\pics\\1.jpg");
            // 
            // label216
            // 
            this.label216.AutoSize = (true);
            this.label216.Location = (new global::System.Drawing.Point(18, 478));
            this.label216.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label216.Name = ("label216");
            this.label216.Size = (new global::System.Drawing.Size(191, 25));
            this.label216.TabIndex = (30);
            this.label216.Text = ("Image background file");
            // 
            // label215
            // 
            this.label215.AutoSize = (true);
            this.label215.Location = (new global::System.Drawing.Point(18, 392));
            this.label215.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label215.Name = ("label215");
            this.label215.Size = (new global::System.Drawing.Size(55, 25));
            this.label215.TabIndex = (26);
            this.label215.Text = ("Color");
            // 
            // tbChromaKeySmoothing
            // 
            this.tbChromaKeySmoothing.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbChromaKeySmoothing.Location = (new global::System.Drawing.Point(22, 280));
            this.tbChromaKeySmoothing.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbChromaKeySmoothing.Maximum = (1000);
            this.tbChromaKeySmoothing.Name = ("tbChromaKeySmoothing");
            this.tbChromaKeySmoothing.Size = (new global::System.Drawing.Size(258, 69));
            this.tbChromaKeySmoothing.TabIndex = (25);
            this.tbChromaKeySmoothing.Value = (80);
            this.tbChromaKeySmoothing.Scroll += (this.tbChromaKeyContrastHigh_Scroll);
            // 
            // label214
            // 
            this.label214.AutoSize = (true);
            this.label214.Location = (new global::System.Drawing.Point(18, 244));
            this.label214.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label214.Name = ("label214");
            this.label214.Size = (new global::System.Drawing.Size(101, 25));
            this.label214.TabIndex = (24);
            this.label214.Text = ("Smoothing");
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            this.tbChromaKeyThresholdSensitivity.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbChromaKeyThresholdSensitivity.Location = (new global::System.Drawing.Point(22, 139));
            this.tbChromaKeyThresholdSensitivity.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbChromaKeyThresholdSensitivity.Maximum = (200);
            this.tbChromaKeyThresholdSensitivity.Name = ("tbChromaKeyThresholdSensitivity");
            this.tbChromaKeyThresholdSensitivity.Size = (new global::System.Drawing.Size(258, 69));
            this.tbChromaKeyThresholdSensitivity.TabIndex = (23);
            this.tbChromaKeyThresholdSensitivity.Value = (180);
            this.tbChromaKeyThresholdSensitivity.Scroll += (this.tbChromaKeyContrastLow_Scroll);
            // 
            // label213
            // 
            this.label213.AutoSize = (true);
            this.label213.Location = (new global::System.Drawing.Point(18, 105));
            this.label213.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label213.Name = ("label213");
            this.label213.Size = (new global::System.Drawing.Size(172, 25));
            this.label213.TabIndex = (22);
            this.label213.Text = ("Threshold sensitivity");
            // 
            // cbChromaKeyEnabled
            // 
            this.cbChromaKeyEnabled.AutoSize = (true);
            this.cbChromaKeyEnabled.Location = (new global::System.Drawing.Point(22, 30));
            this.cbChromaKeyEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbChromaKeyEnabled.Name = ("cbChromaKeyEnabled");
            this.cbChromaKeyEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbChromaKeyEnabled.TabIndex = (21);
            this.cbChromaKeyEnabled.Text = ("Enabled");
            this.cbChromaKeyEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage46.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage46.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage46.Name = ("tabPage46");
            this.tabPage46.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage46.Size = (new global::System.Drawing.Size(490, 893));
            this.tabPage46.TabIndex = (8);
            this.tabPage46.Text = ("3rd-party filters");
            this.tabPage46.UseVisualStyleBackColor = (true);
            // 
            // btFilterDelete
            // 
            this.btFilterDelete.Location = (new global::System.Drawing.Point(250, 545));
            this.btFilterDelete.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterDelete.Name = ("btFilterDelete");
            this.btFilterDelete.Size = (new global::System.Drawing.Size(80, 44));
            this.btFilterDelete.TabIndex = (26);
            this.btFilterDelete.Text = ("Delete");
            this.btFilterDelete.UseVisualStyleBackColor = (true);
            this.btFilterDelete.Click += (this.btFilterDelete_Click);
            // 
            // btFilterDeleteAll
            // 
            this.btFilterDeleteAll.Location = (new global::System.Drawing.Point(340, 545));
            this.btFilterDeleteAll.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterDeleteAll.Name = ("btFilterDeleteAll");
            this.btFilterDeleteAll.Size = (new global::System.Drawing.Size(112, 44));
            this.btFilterDeleteAll.TabIndex = (25);
            this.btFilterDeleteAll.Text = ("Delete all");
            this.btFilterDeleteAll.UseVisualStyleBackColor = (true);
            this.btFilterDeleteAll.Click += (this.btFilterDeleteAll_Click);
            // 
            // btFilterSettings2
            // 
            this.btFilterSettings2.Location = (new global::System.Drawing.Point(20, 545));
            this.btFilterSettings2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterSettings2.Name = ("btFilterSettings2");
            this.btFilterSettings2.Size = (new global::System.Drawing.Size(109, 44));
            this.btFilterSettings2.TabIndex = (24);
            this.btFilterSettings2.Text = ("Settings");
            this.btFilterSettings2.UseVisualStyleBackColor = (true);
            this.btFilterSettings2.Click += (this.btFilterSettings2_Click);
            // 
            // lbFilters
            // 
            this.lbFilters.FormattingEnabled = (true);
            this.lbFilters.ItemHeight = (25);
            this.lbFilters.Location = (new global::System.Drawing.Point(20, 228));
            this.lbFilters.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbFilters.Name = ("lbFilters");
            this.lbFilters.Size = (new global::System.Drawing.Size(432, 304));
            this.lbFilters.TabIndex = (23);
            this.lbFilters.SelectedIndexChanged += (this.lbFilters_SelectedIndexChanged);
            // 
            // label106
            // 
            this.label106.AutoSize = (true);
            this.label106.Location = (new global::System.Drawing.Point(16, 195));
            this.label106.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label106.Name = ("label106");
            this.label106.Size = (new global::System.Drawing.Size(118, 25));
            this.label106.TabIndex = (22);
            this.label106.Text = ("Current filters");
            // 
            // btFilterSettings
            // 
            this.btFilterSettings.Location = (new global::System.Drawing.Point(340, 105));
            this.btFilterSettings.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterSettings.Name = ("btFilterSettings");
            this.btFilterSettings.Size = (new global::System.Drawing.Size(112, 44));
            this.btFilterSettings.TabIndex = (21);
            this.btFilterSettings.Text = ("Settings");
            this.btFilterSettings.UseVisualStyleBackColor = (true);
            this.btFilterSettings.Click += (this.btFilterSettings_Click);
            // 
            // btFilterAdd
            // 
            this.btFilterAdd.Location = (new global::System.Drawing.Point(20, 105));
            this.btFilterAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterAdd.Name = ("btFilterAdd");
            this.btFilterAdd.Size = (new global::System.Drawing.Size(64, 44));
            this.btFilterAdd.TabIndex = (20);
            this.btFilterAdd.Text = ("Add");
            this.btFilterAdd.UseVisualStyleBackColor = (true);
            this.btFilterAdd.Click += (this.btFilterAdd_Click);
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbFilters.FormattingEnabled = (true);
            this.cbFilters.Location = (new global::System.Drawing.Point(20, 52));
            this.cbFilters.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFilters.Name = ("cbFilters");
            this.cbFilters.Size = (new global::System.Drawing.Size(432, 33));
            this.cbFilters.TabIndex = (19);
            this.cbFilters.SelectedIndexChanged += (this.cbFilters_SelectedIndexChanged);
            // 
            // label105
            // 
            this.label105.AutoSize = (true);
            this.label105.Location = (new global::System.Drawing.Point(16, 20));
            this.label105.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label105.Name = ("label105");
            this.label105.Size = (new global::System.Drawing.Size(58, 25));
            this.label105.TabIndex = (18);
            this.label105.Text = ("Filters");
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
            this.tabPage48.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage48.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage48.Name = ("tabPage48");
            this.tabPage48.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage48.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage48.TabIndex = (12);
            this.tabPage48.Text = ("Audio enhancement");
            this.tabPage48.UseVisualStyleBackColor = (true);
            // 
            // lbAudioTimeshift
            // 
            this.lbAudioTimeshift.AutoSize = (true);
            this.lbAudioTimeshift.Location = (new global::System.Drawing.Point(290, 861));
            this.lbAudioTimeshift.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioTimeshift.Name = ("lbAudioTimeshift");
            this.lbAudioTimeshift.Size = (new global::System.Drawing.Size(51, 25));
            this.lbAudioTimeshift.TabIndex = (7);
            this.lbAudioTimeshift.Text = ("0 ms");
            // 
            // tbAudioTimeshift
            // 
            this.tbAudioTimeshift.Location = (new global::System.Drawing.Point(108, 841));
            this.tbAudioTimeshift.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioTimeshift.Maximum = (3000);
            this.tbAudioTimeshift.Name = ("tbAudioTimeshift");
            this.tbAudioTimeshift.Size = (new global::System.Drawing.Size(172, 69));
            this.tbAudioTimeshift.SmallChange = (10);
            this.tbAudioTimeshift.TabIndex = (6);
            this.tbAudioTimeshift.TickFrequency = (100);
            this.tbAudioTimeshift.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioTimeshift.Scroll += (this.tbAudioTimeshift_Scroll);
            // 
            // label70
            // 
            this.label70.AutoSize = (true);
            this.label70.Location = (new global::System.Drawing.Point(4, 861));
            this.label70.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label70.Name = ("label70");
            this.label70.Size = (new global::System.Drawing.Size(89, 25));
            this.label70.TabIndex = (5);
            this.label70.Text = ("Time shift");
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
            this.groupBox4.Location = (new global::System.Drawing.Point(10, 494));
            this.groupBox4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox4.Name = ("groupBox4");
            this.groupBox4.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox4.Size = (new global::System.Drawing.Size(482, 331));
            this.groupBox4.TabIndex = (4);
            this.groupBox4.TabStop = (false);
            this.groupBox4.Text = ("Output gains (dB)");
            // 
            // lbAudioOutputGainLFE
            // 
            this.lbAudioOutputGainLFE.AutoSize = (true);
            this.lbAudioOutputGainLFE.Location = (new global::System.Drawing.Point(416, 284));
            this.lbAudioOutputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainLFE.Name = ("lbAudioOutputGainLFE");
            this.lbAudioOutputGainLFE.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainLFE.TabIndex = (17);
            this.lbAudioOutputGainLFE.Text = ("0.0");
            // 
            // tbAudioOutputGainLFE
            // 
            this.tbAudioOutputGainLFE.Location = (new global::System.Drawing.Point(402, 80));
            this.tbAudioOutputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainLFE.Maximum = (200);
            this.tbAudioOutputGainLFE.Minimum = (-200);
            this.tbAudioOutputGainLFE.Name = ("tbAudioOutputGainLFE");
            this.tbAudioOutputGainLFE.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainLFE.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainLFE.TabIndex = (16);
            this.tbAudioOutputGainLFE.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainLFE.Scroll += (this.tbAudioOutputGainLFE_Scroll);
            // 
            // label55
            // 
            this.label55.AutoSize = (true);
            this.label55.Location = (new global::System.Drawing.Point(418, 48));
            this.label55.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label55.Name = ("label55");
            this.label55.Size = (new global::System.Drawing.Size(38, 25));
            this.label55.TabIndex = (15);
            this.label55.Text = ("LFE");
            // 
            // lbAudioOutputGainSR
            // 
            this.lbAudioOutputGainSR.AutoSize = (true);
            this.lbAudioOutputGainSR.Location = (new global::System.Drawing.Point(336, 284));
            this.lbAudioOutputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainSR.Name = ("lbAudioOutputGainSR");
            this.lbAudioOutputGainSR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainSR.TabIndex = (14);
            this.lbAudioOutputGainSR.Text = ("0.0");
            // 
            // tbAudioOutputGainSR
            // 
            this.tbAudioOutputGainSR.Location = (new global::System.Drawing.Point(322, 80));
            this.tbAudioOutputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainSR.Maximum = (200);
            this.tbAudioOutputGainSR.Minimum = (-200);
            this.tbAudioOutputGainSR.Name = ("tbAudioOutputGainSR");
            this.tbAudioOutputGainSR.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainSR.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainSR.TabIndex = (13);
            this.tbAudioOutputGainSR.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainSR.Scroll += (this.tbAudioOutputGainSR_Scroll);
            // 
            // label57
            // 
            this.label57.AutoSize = (true);
            this.label57.Location = (new global::System.Drawing.Point(342, 48));
            this.label57.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label57.Name = ("label57");
            this.label57.Size = (new global::System.Drawing.Size(33, 25));
            this.label57.TabIndex = (12);
            this.label57.Text = ("SR");
            // 
            // lbAudioOutputGainSL
            // 
            this.lbAudioOutputGainSL.AutoSize = (true);
            this.lbAudioOutputGainSL.Location = (new global::System.Drawing.Point(256, 284));
            this.lbAudioOutputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainSL.Name = ("lbAudioOutputGainSL");
            this.lbAudioOutputGainSL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainSL.TabIndex = (11);
            this.lbAudioOutputGainSL.Text = ("0.0");
            // 
            // tbAudioOutputGainSL
            // 
            this.tbAudioOutputGainSL.Location = (new global::System.Drawing.Point(242, 80));
            this.tbAudioOutputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainSL.Maximum = (200);
            this.tbAudioOutputGainSL.Minimum = (-200);
            this.tbAudioOutputGainSL.Name = ("tbAudioOutputGainSL");
            this.tbAudioOutputGainSL.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainSL.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainSL.TabIndex = (10);
            this.tbAudioOutputGainSL.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainSL.Scroll += (this.tbAudioOutputGainSL_Scroll);
            // 
            // label59
            // 
            this.label59.AutoSize = (true);
            this.label59.Location = (new global::System.Drawing.Point(262, 48));
            this.label59.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label59.Name = ("label59");
            this.label59.Size = (new global::System.Drawing.Size(30, 25));
            this.label59.TabIndex = (9);
            this.label59.Text = ("SL");
            // 
            // lbAudioOutputGainR
            // 
            this.lbAudioOutputGainR.AutoSize = (true);
            this.lbAudioOutputGainR.Location = (new global::System.Drawing.Point(176, 284));
            this.lbAudioOutputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainR.Name = ("lbAudioOutputGainR");
            this.lbAudioOutputGainR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainR.TabIndex = (8);
            this.lbAudioOutputGainR.Text = ("0.0");
            // 
            // tbAudioOutputGainR
            // 
            this.tbAudioOutputGainR.Location = (new global::System.Drawing.Point(162, 80));
            this.tbAudioOutputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainR.Maximum = (200);
            this.tbAudioOutputGainR.Minimum = (-200);
            this.tbAudioOutputGainR.Name = ("tbAudioOutputGainR");
            this.tbAudioOutputGainR.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainR.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainR.TabIndex = (7);
            this.tbAudioOutputGainR.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainR.Scroll += (this.tbAudioOutputGainR_Scroll);
            // 
            // label61
            // 
            this.label61.AutoSize = (true);
            this.label61.Location = (new global::System.Drawing.Point(190, 48));
            this.label61.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label61.Name = ("label61");
            this.label61.Size = (new global::System.Drawing.Size(23, 25));
            this.label61.TabIndex = (6);
            this.label61.Text = ("R");
            // 
            // lbAudioOutputGainC
            // 
            this.lbAudioOutputGainC.AutoSize = (true);
            this.lbAudioOutputGainC.Location = (new global::System.Drawing.Point(96, 284));
            this.lbAudioOutputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainC.Name = ("lbAudioOutputGainC");
            this.lbAudioOutputGainC.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainC.TabIndex = (5);
            this.lbAudioOutputGainC.Text = ("0.0");
            // 
            // tbAudioOutputGainC
            // 
            this.tbAudioOutputGainC.Location = (new global::System.Drawing.Point(82, 80));
            this.tbAudioOutputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainC.Maximum = (200);
            this.tbAudioOutputGainC.Minimum = (-200);
            this.tbAudioOutputGainC.Name = ("tbAudioOutputGainC");
            this.tbAudioOutputGainC.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainC.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainC.TabIndex = (4);
            this.tbAudioOutputGainC.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainC.Scroll += (this.tbAudioOutputGainC_Scroll);
            // 
            // label67
            // 
            this.label67.AutoSize = (true);
            this.label67.Location = (new global::System.Drawing.Point(110, 48));
            this.label67.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label67.Name = ("label67");
            this.label67.Size = (new global::System.Drawing.Size(23, 25));
            this.label67.TabIndex = (3);
            this.label67.Text = ("C");
            // 
            // lbAudioOutputGainL
            // 
            this.lbAudioOutputGainL.AutoSize = (true);
            this.lbAudioOutputGainL.Location = (new global::System.Drawing.Point(16, 284));
            this.lbAudioOutputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainL.Name = ("lbAudioOutputGainL");
            this.lbAudioOutputGainL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainL.TabIndex = (2);
            this.lbAudioOutputGainL.Text = ("0.0");
            // 
            // tbAudioOutputGainL
            // 
            this.tbAudioOutputGainL.Location = (new global::System.Drawing.Point(2, 80));
            this.tbAudioOutputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainL.Maximum = (200);
            this.tbAudioOutputGainL.Minimum = (-200);
            this.tbAudioOutputGainL.Name = ("tbAudioOutputGainL");
            this.tbAudioOutputGainL.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainL.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainL.TabIndex = (1);
            this.tbAudioOutputGainL.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioOutputGainL.Scroll += (this.tbAudioOutputGainL_Scroll);
            // 
            // label69
            // 
            this.label69.AutoSize = (true);
            this.label69.Location = (new global::System.Drawing.Point(30, 48));
            this.label69.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label69.Name = ("label69");
            this.label69.Size = (new global::System.Drawing.Size(20, 25));
            this.label69.TabIndex = (0);
            this.label69.Text = ("L");
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
            this.groupBox1.Location = (new global::System.Drawing.Point(10, 152));
            this.groupBox1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox1.Name = ("groupBox1");
            this.groupBox1.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox1.Size = (new global::System.Drawing.Size(482, 331));
            this.groupBox1.TabIndex = (3);
            this.groupBox1.TabStop = (false);
            this.groupBox1.Text = ("Input gains (dB)");
            // 
            // lbAudioInputGainLFE
            // 
            this.lbAudioInputGainLFE.AutoSize = (true);
            this.lbAudioInputGainLFE.Location = (new global::System.Drawing.Point(416, 284));
            this.lbAudioInputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainLFE.Name = ("lbAudioInputGainLFE");
            this.lbAudioInputGainLFE.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainLFE.TabIndex = (17);
            this.lbAudioInputGainLFE.Text = ("0.0");
            // 
            // tbAudioInputGainLFE
            // 
            this.tbAudioInputGainLFE.Location = (new global::System.Drawing.Point(402, 80));
            this.tbAudioInputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainLFE.Maximum = (200);
            this.tbAudioInputGainLFE.Minimum = (-200);
            this.tbAudioInputGainLFE.Name = ("tbAudioInputGainLFE");
            this.tbAudioInputGainLFE.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainLFE.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainLFE.TabIndex = (16);
            this.tbAudioInputGainLFE.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainLFE.Scroll += (this.tbAudioInputGainLFE_Scroll);
            // 
            // label53
            // 
            this.label53.AutoSize = (true);
            this.label53.Location = (new global::System.Drawing.Point(418, 48));
            this.label53.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label53.Name = ("label53");
            this.label53.Size = (new global::System.Drawing.Size(38, 25));
            this.label53.TabIndex = (15);
            this.label53.Text = ("LFE");
            // 
            // lbAudioInputGainSR
            // 
            this.lbAudioInputGainSR.AutoSize = (true);
            this.lbAudioInputGainSR.Location = (new global::System.Drawing.Point(336, 284));
            this.lbAudioInputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainSR.Name = ("lbAudioInputGainSR");
            this.lbAudioInputGainSR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainSR.TabIndex = (14);
            this.lbAudioInputGainSR.Text = ("0.0");
            // 
            // tbAudioInputGainSR
            // 
            this.tbAudioInputGainSR.Location = (new global::System.Drawing.Point(322, 80));
            this.tbAudioInputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainSR.Maximum = (200);
            this.tbAudioInputGainSR.Minimum = (-200);
            this.tbAudioInputGainSR.Name = ("tbAudioInputGainSR");
            this.tbAudioInputGainSR.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainSR.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainSR.TabIndex = (13);
            this.tbAudioInputGainSR.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainSR.Scroll += (this.tbAudioInputGainSR_Scroll);
            // 
            // label51
            // 
            this.label51.AutoSize = (true);
            this.label51.Location = (new global::System.Drawing.Point(342, 48));
            this.label51.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label51.Name = ("label51");
            this.label51.Size = (new global::System.Drawing.Size(33, 25));
            this.label51.TabIndex = (12);
            this.label51.Text = ("SR");
            // 
            // lbAudioInputGainSL
            // 
            this.lbAudioInputGainSL.AutoSize = (true);
            this.lbAudioInputGainSL.Location = (new global::System.Drawing.Point(256, 284));
            this.lbAudioInputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainSL.Name = ("lbAudioInputGainSL");
            this.lbAudioInputGainSL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainSL.TabIndex = (11);
            this.lbAudioInputGainSL.Text = ("0.0");
            // 
            // tbAudioInputGainSL
            // 
            this.tbAudioInputGainSL.Location = (new global::System.Drawing.Point(242, 80));
            this.tbAudioInputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainSL.Maximum = (200);
            this.tbAudioInputGainSL.Minimum = (-200);
            this.tbAudioInputGainSL.Name = ("tbAudioInputGainSL");
            this.tbAudioInputGainSL.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainSL.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainSL.TabIndex = (10);
            this.tbAudioInputGainSL.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainSL.Scroll += (this.tbAudioInputGainSL_Scroll);
            // 
            // label49
            // 
            this.label49.AutoSize = (true);
            this.label49.Location = (new global::System.Drawing.Point(262, 48));
            this.label49.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label49.Name = ("label49");
            this.label49.Size = (new global::System.Drawing.Size(30, 25));
            this.label49.TabIndex = (9);
            this.label49.Text = ("SL");
            // 
            // lbAudioInputGainR
            // 
            this.lbAudioInputGainR.AutoSize = (true);
            this.lbAudioInputGainR.Location = (new global::System.Drawing.Point(176, 284));
            this.lbAudioInputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainR.Name = ("lbAudioInputGainR");
            this.lbAudioInputGainR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainR.TabIndex = (8);
            this.lbAudioInputGainR.Text = ("0.0");
            // 
            // tbAudioInputGainR
            // 
            this.tbAudioInputGainR.Location = (new global::System.Drawing.Point(162, 80));
            this.tbAudioInputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainR.Maximum = (200);
            this.tbAudioInputGainR.Minimum = (-200);
            this.tbAudioInputGainR.Name = ("tbAudioInputGainR");
            this.tbAudioInputGainR.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainR.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainR.TabIndex = (7);
            this.tbAudioInputGainR.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainR.Scroll += (this.tbAudioInputGainR_Scroll);
            // 
            // label47
            // 
            this.label47.AutoSize = (true);
            this.label47.Location = (new global::System.Drawing.Point(190, 48));
            this.label47.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label47.Name = ("label47");
            this.label47.Size = (new global::System.Drawing.Size(23, 25));
            this.label47.TabIndex = (6);
            this.label47.Text = ("R");
            // 
            // lbAudioInputGainC
            // 
            this.lbAudioInputGainC.AutoSize = (true);
            this.lbAudioInputGainC.Location = (new global::System.Drawing.Point(96, 284));
            this.lbAudioInputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainC.Name = ("lbAudioInputGainC");
            this.lbAudioInputGainC.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainC.TabIndex = (5);
            this.lbAudioInputGainC.Text = ("0.0");
            // 
            // tbAudioInputGainC
            // 
            this.tbAudioInputGainC.Location = (new global::System.Drawing.Point(82, 80));
            this.tbAudioInputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainC.Maximum = (200);
            this.tbAudioInputGainC.Minimum = (-200);
            this.tbAudioInputGainC.Name = ("tbAudioInputGainC");
            this.tbAudioInputGainC.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainC.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainC.TabIndex = (4);
            this.tbAudioInputGainC.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainC.Scroll += (this.tbAudioInputGainC_Scroll);
            // 
            // label44
            // 
            this.label44.AutoSize = (true);
            this.label44.Location = (new global::System.Drawing.Point(110, 48));
            this.label44.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label44.Name = ("label44");
            this.label44.Size = (new global::System.Drawing.Size(23, 25));
            this.label44.TabIndex = (3);
            this.label44.Text = ("C");
            // 
            // lbAudioInputGainL
            // 
            this.lbAudioInputGainL.AutoSize = (true);
            this.lbAudioInputGainL.Location = (new global::System.Drawing.Point(16, 284));
            this.lbAudioInputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainL.Name = ("lbAudioInputGainL");
            this.lbAudioInputGainL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainL.TabIndex = (2);
            this.lbAudioInputGainL.Text = ("0.0");
            // 
            // tbAudioInputGainL
            // 
            this.tbAudioInputGainL.Location = (new global::System.Drawing.Point(2, 80));
            this.tbAudioInputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioInputGainL.Maximum = (200);
            this.tbAudioInputGainL.Minimum = (-200);
            this.tbAudioInputGainL.Name = ("tbAudioInputGainL");
            this.tbAudioInputGainL.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioInputGainL.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioInputGainL.TabIndex = (1);
            this.tbAudioInputGainL.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioInputGainL.Scroll += (this.tbAudioInputGainL_Scroll);
            // 
            // label40
            // 
            this.label40.AutoSize = (true);
            this.label40.Location = (new global::System.Drawing.Point(30, 48));
            this.label40.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label40.Name = ("label40");
            this.label40.Size = (new global::System.Drawing.Size(20, 25));
            this.label40.TabIndex = (0);
            this.label40.Text = ("L");
            // 
            // cbAudioAutoGain
            // 
            this.cbAudioAutoGain.AutoSize = (true);
            this.cbAudioAutoGain.Location = (new global::System.Drawing.Point(222, 91));
            this.cbAudioAutoGain.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioAutoGain.Name = ("cbAudioAutoGain");
            this.cbAudioAutoGain.Size = (new global::System.Drawing.Size(116, 29));
            this.cbAudioAutoGain.TabIndex = (2);
            this.cbAudioAutoGain.Text = ("Auto gain");
            this.cbAudioAutoGain.UseVisualStyleBackColor = (true);
            this.cbAudioAutoGain.CheckedChanged += (this.cbAudioAutoGain_CheckedChanged);
            // 
            // cbAudioNormalize
            // 
            this.cbAudioNormalize.AutoSize = (true);
            this.cbAudioNormalize.Location = (new global::System.Drawing.Point(64, 91));
            this.cbAudioNormalize.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioNormalize.Name = ("cbAudioNormalize");
            this.cbAudioNormalize.Size = (new global::System.Drawing.Size(118, 29));
            this.cbAudioNormalize.TabIndex = (1);
            this.cbAudioNormalize.Text = ("Normalize");
            this.cbAudioNormalize.UseVisualStyleBackColor = (true);
            this.cbAudioNormalize.CheckedChanged += (this.cbAudioNormalize_CheckedChanged);
            // 
            // cbAudioEnhancementEnabled
            // 
            this.cbAudioEnhancementEnabled.AutoSize = (true);
            this.cbAudioEnhancementEnabled.Location = (new global::System.Drawing.Point(28, 30));
            this.cbAudioEnhancementEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioEnhancementEnabled.Name = ("cbAudioEnhancementEnabled");
            this.cbAudioEnhancementEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioEnhancementEnabled.TabIndex = (0);
            this.cbAudioEnhancementEnabled.Text = ("Enabled");
            this.cbAudioEnhancementEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label31);
            this.tabPage11.Controls.Add(this.tabControl18);
            this.tabPage11.Controls.Add(this.cbAudioEffectsEnabled);
            this.tabPage11.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage11.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage11.Name = ("tabPage11");
            this.tabPage11.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage11.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage11.TabIndex = (5);
            this.tabPage11.Text = ("Audio effects");
            this.tabPage11.UseVisualStyleBackColor = (true);
            // 
            // label31
            // 
            this.label31.AutoSize = (true);
            this.label31.Location = (new global::System.Drawing.Point(156, 19));
            this.label31.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label31.Name = ("label31");
            this.label31.Size = (new global::System.Drawing.Size(313, 25));
            this.label31.TabIndex = (4);
            this.label31.Text = ("Much more effects available using API");
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage73);
            this.tabControl18.Controls.Add(this.tabPage75);
            this.tabControl18.Controls.Add(this.tabPage76);
            this.tabControl18.Controls.Add(this.tabPage27);
            this.tabControl18.Location = (new global::System.Drawing.Point(12, 59));
            this.tabControl18.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl18.Name = ("tabControl18");
            this.tabControl18.SelectedIndex = (0);
            this.tabControl18.Size = (new global::System.Drawing.Size(471, 850));
            this.tabControl18.TabIndex = (3);
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.label231);
            this.tabPage71.Controls.Add(this.label230);
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage71.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage71.Name = ("tabPage71");
            this.tabPage71.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage71.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage71.TabIndex = (0);
            this.tabPage71.Text = ("Amplify");
            this.tabPage71.UseVisualStyleBackColor = (true);
            // 
            // label231
            // 
            this.label231.AutoSize = (true);
            this.label231.Location = (new global::System.Drawing.Point(356, 102));
            this.label231.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label231.Name = ("label231");
            this.label231.Size = (new global::System.Drawing.Size(57, 25));
            this.label231.TabIndex = (5);
            this.label231.Text = ("400%");
            // 
            // label230
            // 
            this.label230.AutoSize = (true);
            this.label230.Location = (new global::System.Drawing.Point(112, 102));
            this.label230.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label230.Name = ("label230");
            this.label230.Size = (new global::System.Drawing.Size(57, 25));
            this.label230.TabIndex = (4);
            this.label230.Text = ("100%");
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudAmplifyAmp.Location = (new global::System.Drawing.Point(28, 131));
            this.tbAudAmplifyAmp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudAmplifyAmp.Maximum = (4000);
            this.tbAudAmplifyAmp.Name = ("tbAudAmplifyAmp");
            this.tbAudAmplifyAmp.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudAmplifyAmp.TabIndex = (3);
            this.tbAudAmplifyAmp.TickFrequency = (50);
            this.tbAudAmplifyAmp.Value = (1000);
            this.tbAudAmplifyAmp.Scroll += (this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            this.label95.AutoSize = (true);
            this.label95.Location = (new global::System.Drawing.Point(22, 102));
            this.label95.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label95.Name = ("label95");
            this.label95.Size = (new global::System.Drawing.Size(72, 25));
            this.label95.TabIndex = (2);
            this.label95.Text = ("Volume");
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = (true);
            this.cbAudAmplifyEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudAmplifyEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudAmplifyEnabled.Name = ("cbAudAmplifyEnabled");
            this.cbAudAmplifyEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudAmplifyEnabled.TabIndex = (1);
            this.cbAudAmplifyEnabled.Text = ("Enabled");
            this.cbAudAmplifyEnabled.UseVisualStyleBackColor = (true);
            this.cbAudAmplifyEnabled.CheckedChanged += (this.cbAudAmplifyEnabled_CheckedChanged);
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
            this.tabPage72.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage72.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage72.Name = ("tabPage72");
            this.tabPage72.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage72.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage72.TabIndex = (1);
            this.tabPage72.Text = ("Equalizer");
            this.tabPage72.UseVisualStyleBackColor = (true);
            // 
            // btAudEqRefresh
            // 
            this.btAudEqRefresh.Location = (new global::System.Drawing.Point(291, 420));
            this.btAudEqRefresh.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAudEqRefresh.Name = ("btAudEqRefresh");
            this.btAudEqRefresh.Size = (new global::System.Drawing.Size(124, 44));
            this.btAudEqRefresh.TabIndex = (26);
            this.btAudEqRefresh.Text = ("Refresh");
            this.btAudEqRefresh.UseVisualStyleBackColor = (true);
            this.btAudEqRefresh.Click += (this.btAudEqRefresh_Click);
            // 
            // cbAudEqualizerPreset
            // 
            this.cbAudEqualizerPreset.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbAudEqualizerPreset.FormattingEnabled = (true);
            this.cbAudEqualizerPreset.Location = (new global::System.Drawing.Point(102, 345));
            this.cbAudEqualizerPreset.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudEqualizerPreset.Name = ("cbAudEqualizerPreset");
            this.cbAudEqualizerPreset.Size = (new global::System.Drawing.Size(313, 33));
            this.cbAudEqualizerPreset.TabIndex = (25);
            this.cbAudEqualizerPreset.SelectedIndexChanged += (this.cbAudEqualizerPreset_SelectedIndexChanged);
            // 
            // label243
            // 
            this.label243.AutoSize = (true);
            this.label243.Location = (new global::System.Drawing.Point(22, 352));
            this.label243.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label243.Name = ("label243");
            this.label243.Size = (new global::System.Drawing.Size(60, 25));
            this.label243.TabIndex = (24);
            this.label243.Text = ("Preset");
            // 
            // label242
            // 
            this.label242.AutoSize = (true);
            this.label242.Location = (new global::System.Drawing.Point(342, 300));
            this.label242.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label242.Name = ("label242");
            this.label242.Size = (new global::System.Drawing.Size(42, 25));
            this.label242.TabIndex = (23);
            this.label242.Text = ("16K");
            // 
            // label241
            // 
            this.label241.AutoSize = (true);
            this.label241.Location = (new global::System.Drawing.Point(308, 300));
            this.label241.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label241.Name = ("label241");
            this.label241.Size = (new global::System.Drawing.Size(42, 25));
            this.label241.TabIndex = (22);
            this.label241.Text = ("14K");
            // 
            // label240
            // 
            this.label240.AutoSize = (true);
            this.label240.Location = (new global::System.Drawing.Point(270, 300));
            this.label240.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label240.Name = ("label240");
            this.label240.Size = (new global::System.Drawing.Size(42, 25));
            this.label240.TabIndex = (21);
            this.label240.Text = ("12K");
            // 
            // label239
            // 
            this.label239.AutoSize = (true);
            this.label239.Location = (new global::System.Drawing.Point(238, 300));
            this.label239.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label239.Name = ("label239");
            this.label239.Size = (new global::System.Drawing.Size(32, 25));
            this.label239.TabIndex = (20);
            this.label239.Text = ("6K");
            // 
            // label238
            // 
            this.label238.AutoSize = (true);
            this.label238.Location = (new global::System.Drawing.Point(202, 300));
            this.label238.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label238.Name = ("label238");
            this.label238.Size = (new global::System.Drawing.Size(32, 25));
            this.label238.TabIndex = (19);
            this.label238.Text = ("3K");
            // 
            // label237
            // 
            this.label237.AutoSize = (true);
            this.label237.Location = (new global::System.Drawing.Point(170, 300));
            this.label237.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label237.Name = ("label237");
            this.label237.Size = (new global::System.Drawing.Size(32, 25));
            this.label237.TabIndex = (18);
            this.label237.Text = ("1K");
            // 
            // label236
            // 
            this.label236.AutoSize = (true);
            this.label236.Location = (new global::System.Drawing.Point(132, 300));
            this.label236.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label236.Name = ("label236");
            this.label236.Size = (new global::System.Drawing.Size(42, 25));
            this.label236.TabIndex = (17);
            this.label236.Text = ("600");
            // 
            // label235
            // 
            this.label235.AutoSize = (true);
            this.label235.Location = (new global::System.Drawing.Point(98, 300));
            this.label235.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label235.Name = ("label235");
            this.label235.Size = (new global::System.Drawing.Size(42, 25));
            this.label235.TabIndex = (16);
            this.label235.Text = ("310");
            // 
            // label234
            // 
            this.label234.AutoSize = (true);
            this.label234.Location = (new global::System.Drawing.Point(60, 300));
            this.label234.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label234.Name = ("label234");
            this.label234.Size = (new global::System.Drawing.Size(42, 25));
            this.label234.TabIndex = (15);
            this.label234.Text = ("170");
            // 
            // label233
            // 
            this.label233.AutoSize = (true);
            this.label233.Location = (new global::System.Drawing.Point(30, 300));
            this.label233.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label233.Name = ("label233");
            this.label233.Size = (new global::System.Drawing.Size(32, 25));
            this.label233.TabIndex = (14);
            this.label233.Text = ("60");
            // 
            // label232
            // 
            this.label232.AutoSize = (true);
            this.label232.Location = (new global::System.Drawing.Point(198, 64));
            this.label232.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label232.Name = ("label232");
            this.label232.Size = (new global::System.Drawing.Size(22, 25));
            this.label232.TabIndex = (13);
            this.label232.Text = ("0");
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq9.Location = (new global::System.Drawing.Point(342, 94));
            this.tbAudEq9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq9.Maximum = (100);
            this.tbAudEq9.Minimum = (-100);
            this.tbAudEq9.Name = ("tbAudEq9");
            this.tbAudEq9.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq9.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq9.TabIndex = (12);
            this.tbAudEq9.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq9.Scroll += (this.tbAudEq9_Scroll);
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq8.Location = (new global::System.Drawing.Point(308, 94));
            this.tbAudEq8.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq8.Maximum = (100);
            this.tbAudEq8.Minimum = (-100);
            this.tbAudEq8.Name = ("tbAudEq8");
            this.tbAudEq8.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq8.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq8.TabIndex = (11);
            this.tbAudEq8.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq8.Scroll += (this.tbAudEq8_Scroll);
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq7.Location = (new global::System.Drawing.Point(270, 94));
            this.tbAudEq7.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq7.Maximum = (100);
            this.tbAudEq7.Minimum = (-100);
            this.tbAudEq7.Name = ("tbAudEq7");
            this.tbAudEq7.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq7.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq7.TabIndex = (10);
            this.tbAudEq7.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq7.Scroll += (this.tbAudEq7_Scroll);
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq6.Location = (new global::System.Drawing.Point(236, 94));
            this.tbAudEq6.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq6.Maximum = (100);
            this.tbAudEq6.Minimum = (-100);
            this.tbAudEq6.Name = ("tbAudEq6");
            this.tbAudEq6.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq6.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq6.TabIndex = (9);
            this.tbAudEq6.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq6.Scroll += (this.tbAudEq6_Scroll);
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq5.Location = (new global::System.Drawing.Point(200, 94));
            this.tbAudEq5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq5.Maximum = (100);
            this.tbAudEq5.Minimum = (-100);
            this.tbAudEq5.Name = ("tbAudEq5");
            this.tbAudEq5.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq5.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq5.TabIndex = (8);
            this.tbAudEq5.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq5.Scroll += (this.tbAudEq5_Scroll);
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq4.Location = (new global::System.Drawing.Point(168, 94));
            this.tbAudEq4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq4.Maximum = (100);
            this.tbAudEq4.Minimum = (-100);
            this.tbAudEq4.Name = ("tbAudEq4");
            this.tbAudEq4.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq4.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq4.TabIndex = (7);
            this.tbAudEq4.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq4.Scroll += (this.tbAudEq4_Scroll);
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq3.Location = (new global::System.Drawing.Point(131, 94));
            this.tbAudEq3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq3.Maximum = (100);
            this.tbAudEq3.Minimum = (-100);
            this.tbAudEq3.Name = ("tbAudEq3");
            this.tbAudEq3.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq3.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq3.TabIndex = (6);
            this.tbAudEq3.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq3.Scroll += (this.tbAudEq3_Scroll);
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq2.Location = (new global::System.Drawing.Point(98, 94));
            this.tbAudEq2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq2.Maximum = (100);
            this.tbAudEq2.Minimum = (-100);
            this.tbAudEq2.Name = ("tbAudEq2");
            this.tbAudEq2.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq2.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq2.TabIndex = (5);
            this.tbAudEq2.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq2.Scroll += (this.tbAudEq2_Scroll);
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq1.Location = (new global::System.Drawing.Point(62, 94));
            this.tbAudEq1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq1.Maximum = (100);
            this.tbAudEq1.Minimum = (-100);
            this.tbAudEq1.Name = ("tbAudEq1");
            this.tbAudEq1.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq1.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq1.TabIndex = (4);
            this.tbAudEq1.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq1.Scroll += (this.tbAudEq1_Scroll);
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq0.Location = (new global::System.Drawing.Point(29, 94));
            this.tbAudEq0.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudEq0.Maximum = (100);
            this.tbAudEq0.Minimum = (-100);
            this.tbAudEq0.Name = ("tbAudEq0");
            this.tbAudEq0.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq0.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq0.TabIndex = (3);
            this.tbAudEq0.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            this.tbAudEq0.Scroll += (this.tbAudEq0_Scroll);
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = (true);
            this.cbAudEqualizerEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudEqualizerEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudEqualizerEnabled.Name = ("cbAudEqualizerEnabled");
            this.cbAudEqualizerEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudEqualizerEnabled.TabIndex = (2);
            this.cbAudEqualizerEnabled.Text = ("Enabled");
            this.cbAudEqualizerEnabled.UseVisualStyleBackColor = (true);
            this.cbAudEqualizerEnabled.CheckedChanged += (this.cbAudEqualizerEnabled_CheckedChanged);
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
            this.tabPage73.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage73.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage73.Name = ("tabPage73");
            this.tabPage73.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage73.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage73.TabIndex = (2);
            this.tabPage73.Text = ("Dynamic amplify");
            this.tabPage73.UseVisualStyleBackColor = (true);
            // 
            // tbAudRelease
            // 
            this.tbAudRelease.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudRelease.Location = (new global::System.Drawing.Point(28, 402));
            this.tbAudRelease.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudRelease.Maximum = (10000);
            this.tbAudRelease.Minimum = (10);
            this.tbAudRelease.Name = ("tbAudRelease");
            this.tbAudRelease.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudRelease.TabIndex = (15);
            this.tbAudRelease.TickFrequency = (250);
            this.tbAudRelease.Value = (10);
            this.tbAudRelease.Scroll += (this.tbAudRelease_Scroll);
            // 
            // label248
            // 
            this.label248.AutoSize = (true);
            this.label248.Location = (new global::System.Drawing.Point(389, 370));
            this.label248.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label248.Name = ("label248");
            this.label248.Size = (new global::System.Drawing.Size(32, 25));
            this.label248.TabIndex = (14);
            this.label248.Text = ("10");
            // 
            // label249
            // 
            this.label249.AutoSize = (true);
            this.label249.Location = (new global::System.Drawing.Point(22, 370));
            this.label249.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label249.Name = ("label249");
            this.label249.Size = (new global::System.Drawing.Size(110, 25));
            this.label249.TabIndex = (12);
            this.label249.Text = ("Release time");
            // 
            // label246
            // 
            this.label246.AutoSize = (true);
            this.label246.Location = (new global::System.Drawing.Point(389, 231));
            this.label246.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label246.Name = ("label246");
            this.label246.Size = (new global::System.Drawing.Size(32, 25));
            this.label246.TabIndex = (11);
            this.label246.Text = ("10");
            // 
            // tbAudAttack
            // 
            this.tbAudAttack.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudAttack.Location = (new global::System.Drawing.Point(28, 264));
            this.tbAudAttack.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudAttack.Maximum = (10000);
            this.tbAudAttack.Minimum = (10);
            this.tbAudAttack.Name = ("tbAudAttack");
            this.tbAudAttack.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudAttack.TabIndex = (10);
            this.tbAudAttack.TickFrequency = (250);
            this.tbAudAttack.Value = (10);
            this.tbAudAttack.Scroll += (this.tbAudAttack_Scroll);
            // 
            // label247
            // 
            this.label247.AutoSize = (true);
            this.label247.Location = (new global::System.Drawing.Point(22, 231));
            this.label247.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label247.Name = ("label247");
            this.label247.Size = (new global::System.Drawing.Size(62, 25));
            this.label247.TabIndex = (9);
            this.label247.Text = ("Attack");
            // 
            // label244
            // 
            this.label244.AutoSize = (true);
            this.label244.Location = (new global::System.Drawing.Point(389, 102));
            this.label244.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label244.Name = ("label244");
            this.label244.Size = (new global::System.Drawing.Size(52, 25));
            this.label244.TabIndex = (8);
            this.label244.Text = ("1000");
            // 
            // tbAudDynAmp
            // 
            this.tbAudDynAmp.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudDynAmp.Location = (new global::System.Drawing.Point(28, 131));
            this.tbAudDynAmp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudDynAmp.Maximum = (2000);
            this.tbAudDynAmp.Minimum = (100);
            this.tbAudDynAmp.Name = ("tbAudDynAmp");
            this.tbAudDynAmp.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudDynAmp.TabIndex = (7);
            this.tbAudDynAmp.TickFrequency = (50);
            this.tbAudDynAmp.Value = (1000);
            this.tbAudDynAmp.Scroll += (this.tbAudDynAmp_Scroll);
            // 
            // label245
            // 
            this.label245.AutoSize = (true);
            this.label245.Location = (new global::System.Drawing.Point(22, 102));
            this.label245.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label245.Name = ("label245");
            this.label245.Size = (new global::System.Drawing.Size(198, 25));
            this.label245.TabIndex = (6);
            this.label245.Text = ("Maximum amplification");
            // 
            // cbAudDynamicAmplifyEnabled
            // 
            this.cbAudDynamicAmplifyEnabled.AutoSize = (true);
            this.cbAudDynamicAmplifyEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudDynamicAmplifyEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudDynamicAmplifyEnabled.Name = ("cbAudDynamicAmplifyEnabled");
            this.cbAudDynamicAmplifyEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudDynamicAmplifyEnabled.TabIndex = (2);
            this.cbAudDynamicAmplifyEnabled.Text = ("Enabled");
            this.cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = (true);
            this.cbAudDynamicAmplifyEnabled.CheckedChanged += (this.cbAudDynamicAmplifyEnabled_CheckedChanged);
            // 
            // tabPage75
            // 
            this.tabPage75.Controls.Add(this.tbAud3DSound);
            this.tabPage75.Controls.Add(this.label253);
            this.tabPage75.Controls.Add(this.cbAudSound3DEnabled);
            this.tabPage75.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage75.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage75.Name = ("tabPage75");
            this.tabPage75.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage75.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage75.TabIndex = (4);
            this.tabPage75.Text = ("Sound 3D");
            this.tabPage75.UseVisualStyleBackColor = (true);
            // 
            // tbAud3DSound
            // 
            this.tbAud3DSound.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAud3DSound.Location = (new global::System.Drawing.Point(28, 131));
            this.tbAud3DSound.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAud3DSound.Maximum = (10000);
            this.tbAud3DSound.Name = ("tbAud3DSound");
            this.tbAud3DSound.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAud3DSound.TabIndex = (19);
            this.tbAud3DSound.TickFrequency = (250);
            this.tbAud3DSound.Value = (500);
            this.tbAud3DSound.Scroll += (this.tbAud3DSound_Scroll);
            // 
            // label253
            // 
            this.label253.AutoSize = (true);
            this.label253.Location = (new global::System.Drawing.Point(22, 102));
            this.label253.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label253.Name = ("label253");
            this.label253.Size = (new global::System.Drawing.Size(142, 25));
            this.label253.TabIndex = (18);
            this.label253.Text = ("3D amplification");
            // 
            // cbAudSound3DEnabled
            // 
            this.cbAudSound3DEnabled.AutoSize = (true);
            this.cbAudSound3DEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudSound3DEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudSound3DEnabled.Name = ("cbAudSound3DEnabled");
            this.cbAudSound3DEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudSound3DEnabled.TabIndex = (2);
            this.cbAudSound3DEnabled.Text = ("Enabled");
            this.cbAudSound3DEnabled.UseVisualStyleBackColor = (true);
            this.cbAudSound3DEnabled.CheckedChanged += (this.cbAudSound3DEnabled_CheckedChanged);
            // 
            // tabPage76
            // 
            this.tabPage76.Controls.Add(this.tbAudTrueBass);
            this.tabPage76.Controls.Add(this.label254);
            this.tabPage76.Controls.Add(this.cbAudTrueBassEnabled);
            this.tabPage76.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage76.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage76.Name = ("tabPage76");
            this.tabPage76.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage76.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage76.TabIndex = (5);
            this.tabPage76.Text = ("True Bass");
            this.tabPage76.UseVisualStyleBackColor = (true);
            // 
            // tbAudTrueBass
            // 
            this.tbAudTrueBass.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudTrueBass.Location = (new global::System.Drawing.Point(28, 131));
            this.tbAudTrueBass.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudTrueBass.Maximum = (10000);
            this.tbAudTrueBass.Name = ("tbAudTrueBass");
            this.tbAudTrueBass.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudTrueBass.TabIndex = (21);
            this.tbAudTrueBass.TickFrequency = (250);
            this.tbAudTrueBass.Scroll += (this.tbAudTrueBass_Scroll);
            // 
            // label254
            // 
            this.label254.AutoSize = (true);
            this.label254.Location = (new global::System.Drawing.Point(22, 102));
            this.label254.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label254.Name = ("label254");
            this.label254.Size = (new global::System.Drawing.Size(72, 25));
            this.label254.TabIndex = (20);
            this.label254.Text = ("Volume");
            // 
            // cbAudTrueBassEnabled
            // 
            this.cbAudTrueBassEnabled.AutoSize = (true);
            this.cbAudTrueBassEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudTrueBassEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudTrueBassEnabled.Name = ("cbAudTrueBassEnabled");
            this.cbAudTrueBassEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudTrueBassEnabled.TabIndex = (2);
            this.cbAudTrueBassEnabled.Text = ("Enabled");
            this.cbAudTrueBassEnabled.UseVisualStyleBackColor = (true);
            this.cbAudTrueBassEnabled.CheckedChanged += (this.cbAudTrueBassEnabled_CheckedChanged);
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.tbAudPitchShift);
            this.tabPage27.Controls.Add(this.label36);
            this.tabPage27.Controls.Add(this.cbAudPitchShiftEnabled);
            this.tabPage27.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage27.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage27.Name = ("tabPage27");
            this.tabPage27.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage27.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage27.TabIndex = (7);
            this.tabPage27.Text = ("Pitch shift");
            this.tabPage27.UseVisualStyleBackColor = (true);
            // 
            // tbAudPitchShift
            // 
            this.tbAudPitchShift.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudPitchShift.Location = (new global::System.Drawing.Point(28, 131));
            this.tbAudPitchShift.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudPitchShift.Maximum = (3000);
            this.tbAudPitchShift.Minimum = (100);
            this.tbAudPitchShift.Name = ("tbAudPitchShift");
            this.tbAudPitchShift.Size = (new global::System.Drawing.Size(382, 69));
            this.tbAudPitchShift.TabIndex = (26);
            this.tbAudPitchShift.TickFrequency = (20);
            this.tbAudPitchShift.Value = (1000);
            this.tbAudPitchShift.Scroll += (this.tbAudPitchShift_Scroll);
            // 
            // label36
            // 
            this.label36.AutoSize = (true);
            this.label36.Location = (new global::System.Drawing.Point(22, 102));
            this.label36.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label36.Name = ("label36");
            this.label36.Size = (new global::System.Drawing.Size(50, 25));
            this.label36.TabIndex = (25);
            this.label36.Text = ("Pitch");
            // 
            // cbAudPitchShiftEnabled
            // 
            this.cbAudPitchShiftEnabled.AutoSize = (true);
            this.cbAudPitchShiftEnabled.Location = (new global::System.Drawing.Point(28, 31));
            this.cbAudPitchShiftEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudPitchShiftEnabled.Name = ("cbAudPitchShiftEnabled");
            this.cbAudPitchShiftEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudPitchShiftEnabled.TabIndex = (24);
            this.cbAudPitchShiftEnabled.Text = ("Enabled");
            this.cbAudPitchShiftEnabled.UseVisualStyleBackColor = (true);
            this.cbAudPitchShiftEnabled.CheckedChanged += (this.cbAudPitchShiftEnabled_CheckedChanged);
            // 
            // cbAudioEffectsEnabled
            // 
            this.cbAudioEffectsEnabled.AutoSize = (true);
            this.cbAudioEffectsEnabled.Location = (new global::System.Drawing.Point(12, 16));
            this.cbAudioEffectsEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioEffectsEnabled.Name = ("cbAudioEffectsEnabled");
            this.cbAudioEffectsEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioEffectsEnabled.TabIndex = (2);
            this.cbAudioEffectsEnabled.Text = ("Enabled");
            this.cbAudioEffectsEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage50.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage50.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage50.Name = ("tabPage50");
            this.tabPage50.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage50.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage50.TabIndex = (13);
            this.tabPage50.Text = ("Audio channel mapper");
            this.tabPage50.UseVisualStyleBackColor = (true);
            // 
            // btAudioChannelMapperClear
            // 
            this.btAudioChannelMapperClear.Location = (new global::System.Drawing.Point(340, 422));
            this.btAudioChannelMapperClear.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAudioChannelMapperClear.Name = ("btAudioChannelMapperClear");
            this.btAudioChannelMapperClear.Size = (new global::System.Drawing.Size(124, 44));
            this.btAudioChannelMapperClear.TabIndex = (21);
            this.btAudioChannelMapperClear.Text = ("Clear");
            this.btAudioChannelMapperClear.UseVisualStyleBackColor = (true);
            this.btAudioChannelMapperClear.Click += (this.btAudioChannelMapperClear_Click);
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
            this.groupBox41.Location = (new global::System.Drawing.Point(10, 480));
            this.groupBox41.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox41.Name = ("groupBox41");
            this.groupBox41.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox41.Size = (new global::System.Drawing.Size(478, 330));
            this.groupBox41.TabIndex = (20);
            this.groupBox41.TabStop = (false);
            this.groupBox41.Text = ("Add new route");
            // 
            // btAudioChannelMapperAddNewRoute
            // 
            this.btAudioChannelMapperAddNewRoute.Location = (new global::System.Drawing.Point(180, 252));
            this.btAudioChannelMapperAddNewRoute.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAudioChannelMapperAddNewRoute.Name = ("btAudioChannelMapperAddNewRoute");
            this.btAudioChannelMapperAddNewRoute.Size = (new global::System.Drawing.Size(124, 44));
            this.btAudioChannelMapperAddNewRoute.TabIndex = (20);
            this.btAudioChannelMapperAddNewRoute.Text = ("Add");
            this.btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = (true);
            this.btAudioChannelMapperAddNewRoute.Click += (this.btAudioChannelMapperAddNewRoute_Click);
            // 
            // label311
            // 
            this.label311.AutoSize = (true);
            this.label311.Location = (new global::System.Drawing.Point(342, 170));
            this.label311.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label311.Name = ("label311");
            this.label311.Size = (new global::System.Drawing.Size(109, 25));
            this.label311.TabIndex = (19);
            this.label311.Text = ("10% - 200%");
            // 
            // tbAudioChannelMapperVolume
            // 
            this.tbAudioChannelMapperVolume.Location = (new global::System.Drawing.Point(348, 80));
            this.tbAudioChannelMapperVolume.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioChannelMapperVolume.Maximum = (2000);
            this.tbAudioChannelMapperVolume.Minimum = (100);
            this.tbAudioChannelMapperVolume.Name = ("tbAudioChannelMapperVolume");
            this.tbAudioChannelMapperVolume.Size = (new global::System.Drawing.Size(122, 69));
            this.tbAudioChannelMapperVolume.TabIndex = (18);
            this.tbAudioChannelMapperVolume.Value = (1000);
            // 
            // label310
            // 
            this.label310.AutoSize = (true);
            this.label310.Location = (new global::System.Drawing.Point(342, 48));
            this.label310.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label310.Name = ("label310");
            this.label310.Size = (new global::System.Drawing.Size(72, 25));
            this.label310.TabIndex = (17);
            this.label310.Text = ("Volume");
            // 
            // edAudioChannelMapperTargetChannel
            // 
            this.edAudioChannelMapperTargetChannel.Location = (new global::System.Drawing.Point(180, 80));
            this.edAudioChannelMapperTargetChannel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAudioChannelMapperTargetChannel.Name = ("edAudioChannelMapperTargetChannel");
            this.edAudioChannelMapperTargetChannel.Size = (new global::System.Drawing.Size(82, 31));
            this.edAudioChannelMapperTargetChannel.TabIndex = (16);
            this.edAudioChannelMapperTargetChannel.Text = ("0");
            // 
            // label309
            // 
            this.label309.AutoSize = (true);
            this.label309.Location = (new global::System.Drawing.Point(176, 48));
            this.label309.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label309.Name = ("label309");
            this.label309.Size = (new global::System.Drawing.Size(125, 25));
            this.label309.TabIndex = (15);
            this.label309.Text = ("Target channel");
            // 
            // edAudioChannelMapperSourceChannel
            // 
            this.edAudioChannelMapperSourceChannel.Location = (new global::System.Drawing.Point(24, 80));
            this.edAudioChannelMapperSourceChannel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAudioChannelMapperSourceChannel.Name = ("edAudioChannelMapperSourceChannel");
            this.edAudioChannelMapperSourceChannel.Size = (new global::System.Drawing.Size(82, 31));
            this.edAudioChannelMapperSourceChannel.TabIndex = (14);
            this.edAudioChannelMapperSourceChannel.Text = ("0");
            // 
            // label308
            // 
            this.label308.AutoSize = (true);
            this.label308.Location = (new global::System.Drawing.Point(20, 48));
            this.label308.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label308.Name = ("label308");
            this.label308.Size = (new global::System.Drawing.Size(131, 25));
            this.label308.TabIndex = (13);
            this.label308.Text = ("Source channel");
            // 
            // label307
            // 
            this.label307.AutoSize = (true);
            this.label307.Location = (new global::System.Drawing.Point(16, 194));
            this.label307.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label307.Name = ("label307");
            this.label307.Size = (new global::System.Drawing.Size(66, 25));
            this.label307.TabIndex = (19);
            this.label307.Text = ("Routes");
            // 
            // edAudioChannelMapperOutputChannels
            // 
            this.edAudioChannelMapperOutputChannels.Location = (new global::System.Drawing.Point(20, 119));
            this.edAudioChannelMapperOutputChannels.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAudioChannelMapperOutputChannels.Name = ("edAudioChannelMapperOutputChannels");
            this.edAudioChannelMapperOutputChannels.Size = (new global::System.Drawing.Size(66, 31));
            this.edAudioChannelMapperOutputChannels.TabIndex = (18);
            this.edAudioChannelMapperOutputChannels.Text = ("0");
            // 
            // label306
            // 
            this.label306.AutoSize = (true);
            this.label306.Location = (new global::System.Drawing.Point(16, 89));
            this.label306.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label306.Name = ("label306");
            this.label306.Size = (new global::System.Drawing.Size(458, 25));
            this.label306.TabIndex = (17);
            this.label306.Text = ("Output channels count (0 to use original channels count)");
            // 
            // lbAudioChannelMapperRoutes
            // 
            this.lbAudioChannelMapperRoutes.FormattingEnabled = (true);
            this.lbAudioChannelMapperRoutes.ItemHeight = (25);
            this.lbAudioChannelMapperRoutes.Location = (new global::System.Drawing.Point(20, 230));
            this.lbAudioChannelMapperRoutes.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbAudioChannelMapperRoutes.Name = ("lbAudioChannelMapperRoutes");
            this.lbAudioChannelMapperRoutes.Size = (new global::System.Drawing.Size(442, 179));
            this.lbAudioChannelMapperRoutes.TabIndex = (16);
            // 
            // cbAudioChannelMapperEnabled
            // 
            this.cbAudioChannelMapperEnabled.AutoSize = (true);
            this.cbAudioChannelMapperEnabled.Location = (new global::System.Drawing.Point(20, 22));
            this.cbAudioChannelMapperEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioChannelMapperEnabled.Name = ("cbAudioChannelMapperEnabled");
            this.cbAudioChannelMapperEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioChannelMapperEnabled.TabIndex = (15);
            this.cbAudioChannelMapperEnabled.Text = ("Enabled");
            this.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage28.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage28.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage28.Name = ("tabPage28");
            this.tabPage28.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage28.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage28.TabIndex = (11);
            this.tabPage28.Text = ("VU meter");
            this.tabPage28.UseVisualStyleBackColor = (true);
            // 
            // tbVUMeterBoost
            // 
            this.tbVUMeterBoost.Location = (new global::System.Drawing.Point(208, 269));
            this.tbVUMeterBoost.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVUMeterBoost.Maximum = (30);
            this.tbVUMeterBoost.Minimum = (1);
            this.tbVUMeterBoost.Name = ("tbVUMeterBoost");
            this.tbVUMeterBoost.Size = (new global::System.Drawing.Size(172, 69));
            this.tbVUMeterBoost.TabIndex = (122);
            this.tbVUMeterBoost.Value = (10);
            this.tbVUMeterBoost.Scroll += (this.tbVUMeterBoost_Scroll);
            // 
            // label382
            // 
            this.label382.AutoSize = (true);
            this.label382.Location = (new global::System.Drawing.Point(202, 236));
            this.label382.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label382.Name = ("label382");
            this.label382.Size = (new global::System.Drawing.Size(118, 25));
            this.label382.TabIndex = (121);
            this.label382.Text = ("Meters boost");
            // 
            // label381
            // 
            this.label381.AutoSize = (true);
            this.label381.Location = (new global::System.Drawing.Point(202, 111));
            this.label381.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label381.Name = ("label381");
            this.label381.Size = (new global::System.Drawing.Size(209, 25));
            this.label381.TabIndex = (120);
            this.label381.Text = ("Volume amplification (%)");
            // 
            // tbVUMeterAmplification
            // 
            this.tbVUMeterAmplification.Location = (new global::System.Drawing.Point(208, 142));
            this.tbVUMeterAmplification.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVUMeterAmplification.Maximum = (100);
            this.tbVUMeterAmplification.Name = ("tbVUMeterAmplification");
            this.tbVUMeterAmplification.Size = (new global::System.Drawing.Size(176, 69));
            this.tbVUMeterAmplification.TabIndex = (119);
            this.tbVUMeterAmplification.Value = (100);
            this.tbVUMeterAmplification.Scroll += (this.tbVUMeterAmplification_Scroll);
            // 
            // cbVUMeterPro
            // 
            this.cbVUMeterPro.AutoSize = (true);
            this.cbVUMeterPro.Location = (new global::System.Drawing.Point(38, 45));
            this.cbVUMeterPro.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVUMeterPro.Name = ("cbVUMeterPro");
            this.cbVUMeterPro.Size = (new global::System.Drawing.Size(201, 29));
            this.cbVUMeterPro.TabIndex = (115);
            this.cbVUMeterPro.Text = ("Enable VU meter Pro");
            this.cbVUMeterPro.UseVisualStyleBackColor = (true);
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Boost = (1F);
            this.waveformPainter2.Location = (new global::System.Drawing.Point(24, 492));
            this.waveformPainter2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.waveformPainter2.Name = ("waveformPainter2");
            this.waveformPainter2.Size = (new global::System.Drawing.Size(450, 116));
            this.waveformPainter2.TabIndex = (118);
            this.waveformPainter2.Text = ("waveformPainter2");
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Boost = (1F);
            this.waveformPainter1.Location = (new global::System.Drawing.Point(24, 366));
            this.waveformPainter1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.waveformPainter1.Name = ("waveformPainter1");
            this.waveformPainter1.Size = (new global::System.Drawing.Size(450, 116));
            this.waveformPainter1.TabIndex = (117);
            this.waveformPainter1.Text = ("waveformPainter1");
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = (0F);
            this.volumeMeter2.BackColor = (global::System.Drawing.Color.LightGray);
            this.volumeMeter2.Boost = (1F);
            this.volumeMeter2.Location = (new global::System.Drawing.Point(100, 111));
            this.volumeMeter2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.volumeMeter2.MaxDb = (18F);
            this.volumeMeter2.MinDb = (-60F);
            this.volumeMeter2.Name = ("volumeMeter2");
            this.volumeMeter2.Size = (new global::System.Drawing.Size(38, 242));
            this.volumeMeter2.TabIndex = (116);
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = (0F);
            this.volumeMeter1.BackColor = (global::System.Drawing.Color.LightGray);
            this.volumeMeter1.Boost = (1F);
            this.volumeMeter1.Location = (new global::System.Drawing.Point(52, 111));
            this.volumeMeter1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.volumeMeter1.MaxDb = (18F);
            this.volumeMeter1.MinDb = (-60F);
            this.volumeMeter1.Name = ("volumeMeter1");
            this.volumeMeter1.Size = (new global::System.Drawing.Size(38, 242));
            this.volumeMeter1.TabIndex = (114);
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
            this.tabPage5.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage5.Name = ("tabPage5");
            this.tabPage5.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage5.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage5.TabIndex = (4);
            this.tabPage5.Text = ("OSD");
            this.tabPage5.UseVisualStyleBackColor = (true);
            // 
            // btOSDRenderLayers
            // 
            this.btOSDRenderLayers.Location = (new global::System.Drawing.Point(269, 398));
            this.btOSDRenderLayers.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDRenderLayers.Name = ("btOSDRenderLayers");
            this.btOSDRenderLayers.Size = (new global::System.Drawing.Size(209, 44));
            this.btOSDRenderLayers.TabIndex = (16);
            this.btOSDRenderLayers.Text = ("Render layers");
            this.btOSDRenderLayers.UseVisualStyleBackColor = (true);
            this.btOSDRenderLayers.Click += (this.btOSDRenderLayers_Click);
            // 
            // lbOSDLayers
            // 
            this.lbOSDLayers.CheckOnClick = (true);
            this.lbOSDLayers.FormattingEnabled = (true);
            this.lbOSDLayers.Location = (new global::System.Drawing.Point(28, 131));
            this.lbOSDLayers.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbOSDLayers.Name = ("lbOSDLayers");
            this.lbOSDLayers.Size = (new global::System.Drawing.Size(228, 172));
            this.lbOSDLayers.TabIndex = (15);
            this.lbOSDLayers.ItemCheck += (this.lbOSDLayers_ItemCheck);
            // 
            // cbOSDEnabled
            // 
            this.cbOSDEnabled.AutoSize = (true);
            this.cbOSDEnabled.Location = (new global::System.Drawing.Point(28, 30));
            this.cbOSDEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbOSDEnabled.Name = ("cbOSDEnabled");
            this.cbOSDEnabled.Size = (new global::System.Drawing.Size(415, 29));
            this.cbOSDEnabled.TabIndex = (14);
            this.cbOSDEnabled.Text = ("Enabled (should be set before playback started)");
            this.cbOSDEnabled.UseVisualStyleBackColor = (true);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btOSDClearLayer);
            this.groupBox19.Controls.Add(this.tabControl6);
            this.groupBox19.Location = (new global::System.Drawing.Point(24, 455));
            this.groupBox19.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox19.Name = ("groupBox19");
            this.groupBox19.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox19.Size = (new global::System.Drawing.Size(450, 481));
            this.groupBox19.TabIndex = (13);
            this.groupBox19.TabStop = (false);
            this.groupBox19.Text = ("Selected layer");
            // 
            // btOSDClearLayer
            // 
            this.btOSDClearLayer.Location = (new global::System.Drawing.Point(18, 425));
            this.btOSDClearLayer.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDClearLayer.Name = ("btOSDClearLayer");
            this.btOSDClearLayer.Size = (new global::System.Drawing.Size(151, 44));
            this.btOSDClearLayer.TabIndex = (2);
            this.btOSDClearLayer.Text = ("Clear layer");
            this.btOSDClearLayer.UseVisualStyleBackColor = (true);
            this.btOSDClearLayer.Click += (this.btOSDClearLayer_Click);
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage30);
            this.tabControl6.Controls.Add(this.tabPage31);
            this.tabControl6.Controls.Add(this.tabPage32);
            this.tabControl6.Location = (new global::System.Drawing.Point(18, 36));
            this.tabControl6.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl6.Name = ("tabControl6");
            this.tabControl6.SelectedIndex = (0);
            this.tabControl6.Size = (new global::System.Drawing.Size(418, 378));
            this.tabControl6.TabIndex = (0);
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
            this.tabPage30.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage30.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage30.Name = ("tabPage30");
            this.tabPage30.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage30.Size = (new global::System.Drawing.Size(410, 340));
            this.tabPage30.TabIndex = (1);
            this.tabPage30.Text = ("Image");
            this.tabPage30.UseVisualStyleBackColor = (true);
            // 
            // btOSDImageDraw
            // 
            this.btOSDImageDraw.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btOSDImageDraw.Location = (new global::System.Drawing.Point(298, 270));
            this.btOSDImageDraw.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDImageDraw.Name = ("btOSDImageDraw");
            this.btOSDImageDraw.Size = (new global::System.Drawing.Size(96, 44));
            this.btOSDImageDraw.TabIndex = (47);
            this.btOSDImageDraw.Text = ("Draw");
            this.btOSDImageDraw.UseVisualStyleBackColor = (true);
            this.btOSDImageDraw.Click += (this.btOSDImageDraw_Click);
            // 
            // pnOSDColorKey
            // 
            this.pnOSDColorKey.BackColor = (global::System.Drawing.Color.Fuchsia);
            this.pnOSDColorKey.BorderStyle = (global::System.Windows.Forms.BorderStyle.FixedSingle);
            this.pnOSDColorKey.Location = (new global::System.Drawing.Point(269, 195));
            this.pnOSDColorKey.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnOSDColorKey.Name = ("pnOSDColorKey");
            this.pnOSDColorKey.Size = (new global::System.Drawing.Size(40, 44));
            this.pnOSDColorKey.TabIndex = (45);
            this.pnOSDColorKey.Click += (this.pnOSDColorKey_Click);
            // 
            // cbOSDImageTranspColor
            // 
            this.cbOSDImageTranspColor.AutoSize = (true);
            this.cbOSDImageTranspColor.Location = (new global::System.Drawing.Point(24, 195));
            this.cbOSDImageTranspColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbOSDImageTranspColor.Name = ("cbOSDImageTranspColor");
            this.cbOSDImageTranspColor.Size = (new global::System.Drawing.Size(218, 29));
            this.cbOSDImageTranspColor.TabIndex = (7);
            this.cbOSDImageTranspColor.Text = ("Use transparency color");
            this.cbOSDImageTranspColor.UseVisualStyleBackColor = (true);
            // 
            // edOSDImageTop
            // 
            this.edOSDImageTop.Location = (new global::System.Drawing.Point(220, 130));
            this.edOSDImageTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDImageTop.Name = ("edOSDImageTop");
            this.edOSDImageTop.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDImageTop.TabIndex = (6);
            this.edOSDImageTop.Text = ("0");
            // 
            // label115
            // 
            this.label115.AutoSize = (true);
            this.label115.Location = (new global::System.Drawing.Point(169, 134));
            this.label115.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label115.Name = ("label115");
            this.label115.Size = (new global::System.Drawing.Size(41, 25));
            this.label115.TabIndex = (5);
            this.label115.Text = ("Top");
            // 
            // edOSDImageLeft
            // 
            this.edOSDImageLeft.Location = (new global::System.Drawing.Point(82, 130));
            this.edOSDImageLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDImageLeft.Name = ("edOSDImageLeft");
            this.edOSDImageLeft.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDImageLeft.TabIndex = (4);
            this.edOSDImageLeft.Text = ("0");
            // 
            // label114
            // 
            this.label114.AutoSize = (true);
            this.label114.Location = (new global::System.Drawing.Point(20, 134));
            this.label114.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label114.Name = ("label114");
            this.label114.Size = (new global::System.Drawing.Size(41, 25));
            this.label114.TabIndex = (3);
            this.label114.Text = ("Left");
            // 
            // btOSDSelectImage
            // 
            this.btOSDSelectImage.Location = (new global::System.Drawing.Point(356, 58));
            this.btOSDSelectImage.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDSelectImage.Name = ("btOSDSelectImage");
            this.btOSDSelectImage.Size = (new global::System.Drawing.Size(38, 44));
            this.btOSDSelectImage.TabIndex = (2);
            this.btOSDSelectImage.Text = ("...");
            this.btOSDSelectImage.UseVisualStyleBackColor = (true);
            this.btOSDSelectImage.Click += (this.btOSDSelectImage_Click);
            // 
            // edOSDImageFilename
            // 
            this.edOSDImageFilename.Location = (new global::System.Drawing.Point(24, 61));
            this.edOSDImageFilename.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDImageFilename.Name = ("edOSDImageFilename");
            this.edOSDImageFilename.Size = (new global::System.Drawing.Size(316, 31));
            this.edOSDImageFilename.TabIndex = (1);
            this.edOSDImageFilename.Text = ("c:\\logo.png");
            // 
            // label113
            // 
            this.label113.AutoSize = (true);
            this.label113.Location = (new global::System.Drawing.Point(20, 31));
            this.label113.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label113.Name = ("label113");
            this.label113.Size = (new global::System.Drawing.Size(87, 25));
            this.label113.TabIndex = (0);
            this.label113.Text = ("File name");
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
            this.tabPage31.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage31.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage31.Name = ("tabPage31");
            this.tabPage31.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage31.Size = (new global::System.Drawing.Size(410, 340));
            this.tabPage31.TabIndex = (2);
            this.tabPage31.Text = ("Text");
            this.tabPage31.UseVisualStyleBackColor = (true);
            // 
            // edOSDTextTop
            // 
            this.edOSDTextTop.Location = (new global::System.Drawing.Point(220, 130));
            this.edOSDTextTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDTextTop.Name = ("edOSDTextTop");
            this.edOSDTextTop.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDTextTop.TabIndex = (55);
            this.edOSDTextTop.Text = ("0");
            // 
            // label117
            // 
            this.label117.AutoSize = (true);
            this.label117.Location = (new global::System.Drawing.Point(169, 134));
            this.label117.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label117.Name = ("label117");
            this.label117.Size = (new global::System.Drawing.Size(41, 25));
            this.label117.TabIndex = (54);
            this.label117.Text = ("Top");
            // 
            // edOSDTextLeft
            // 
            this.edOSDTextLeft.Location = (new global::System.Drawing.Point(82, 130));
            this.edOSDTextLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDTextLeft.Name = ("edOSDTextLeft");
            this.edOSDTextLeft.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDTextLeft.TabIndex = (53);
            this.edOSDTextLeft.Text = ("0");
            // 
            // label118
            // 
            this.label118.AutoSize = (true);
            this.label118.Location = (new global::System.Drawing.Point(20, 134));
            this.label118.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label118.Name = ("label118");
            this.label118.Size = (new global::System.Drawing.Size(41, 25));
            this.label118.TabIndex = (52);
            this.label118.Text = ("Left");
            // 
            // label116
            // 
            this.label116.AutoSize = (true);
            this.label116.Location = (new global::System.Drawing.Point(20, 31));
            this.label116.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label116.Name = ("label116");
            this.label116.Size = (new global::System.Drawing.Size(42, 25));
            this.label116.TabIndex = (51);
            this.label116.Text = ("Text");
            // 
            // btOSDSelectFont
            // 
            this.btOSDSelectFont.Location = (new global::System.Drawing.Point(330, 58));
            this.btOSDSelectFont.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDSelectFont.Name = ("btOSDSelectFont");
            this.btOSDSelectFont.Size = (new global::System.Drawing.Size(62, 44));
            this.btOSDSelectFont.TabIndex = (50);
            this.btOSDSelectFont.Text = ("Font");
            this.btOSDSelectFont.UseVisualStyleBackColor = (true);
            this.btOSDSelectFont.Click += (this.btOSDSelectFont_Click);
            // 
            // edOSDText
            // 
            this.edOSDText.ForeColor = (global::System.Drawing.SystemColors.WindowText);
            this.edOSDText.Location = (new global::System.Drawing.Point(24, 61));
            this.edOSDText.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDText.Name = ("edOSDText");
            this.edOSDText.Size = (new global::System.Drawing.Size(296, 31));
            this.edOSDText.TabIndex = (49);
            this.edOSDText.Text = ("Hello!!!");
            // 
            // btOSDTextDraw
            // 
            this.btOSDTextDraw.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btOSDTextDraw.Location = (new global::System.Drawing.Point(298, 270));
            this.btOSDTextDraw.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDTextDraw.Name = ("btOSDTextDraw");
            this.btOSDTextDraw.Size = (new global::System.Drawing.Size(96, 44));
            this.btOSDTextDraw.TabIndex = (48);
            this.btOSDTextDraw.Text = ("Draw");
            this.btOSDTextDraw.UseVisualStyleBackColor = (true);
            this.btOSDTextDraw.Click += (this.btOSDTextDraw_Click);
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.tbOSDTranspLevel);
            this.tabPage32.Controls.Add(this.btOSDSetTransp);
            this.tabPage32.Controls.Add(this.label119);
            this.tabPage32.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage32.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage32.Name = ("tabPage32");
            this.tabPage32.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage32.Size = (new global::System.Drawing.Size(410, 340));
            this.tabPage32.TabIndex = (3);
            this.tabPage32.Text = ("Other");
            this.tabPage32.UseVisualStyleBackColor = (true);
            // 
            // tbOSDTranspLevel
            // 
            this.tbOSDTranspLevel.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbOSDTranspLevel.Location = (new global::System.Drawing.Point(24, 61));
            this.tbOSDTranspLevel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbOSDTranspLevel.Maximum = (255);
            this.tbOSDTranspLevel.Name = ("tbOSDTranspLevel");
            this.tbOSDTranspLevel.Size = (new global::System.Drawing.Size(238, 69));
            this.tbOSDTranspLevel.TabIndex = (3);
            this.tbOSDTranspLevel.TickFrequency = (10);
            // 
            // btOSDSetTransp
            // 
            this.btOSDSetTransp.Location = (new global::System.Drawing.Point(298, 80));
            this.btOSDSetTransp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDSetTransp.Name = ("btOSDSetTransp");
            this.btOSDSetTransp.Size = (new global::System.Drawing.Size(80, 44));
            this.btOSDSetTransp.TabIndex = (2);
            this.btOSDSetTransp.Text = ("Set");
            this.btOSDSetTransp.UseVisualStyleBackColor = (true);
            this.btOSDSetTransp.Click += (this.btOSDSetTransp_Click);
            // 
            // label119
            // 
            this.label119.AutoSize = (true);
            this.label119.Location = (new global::System.Drawing.Point(20, 31));
            this.label119.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label119.Name = ("label119");
            this.label119.Size = (new global::System.Drawing.Size(154, 25));
            this.label119.TabIndex = (0);
            this.label119.Text = ("Transparency level");
            // 
            // btOSDClearLayers
            // 
            this.btOSDClearLayers.Location = (new global::System.Drawing.Point(28, 398));
            this.btOSDClearLayers.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDClearLayers.Name = ("btOSDClearLayers");
            this.btOSDClearLayers.Size = (new global::System.Drawing.Size(232, 44));
            this.btOSDClearLayers.TabIndex = (12);
            this.btOSDClearLayers.Text = ("Remove all layers");
            this.btOSDClearLayers.UseVisualStyleBackColor = (true);
            this.btOSDClearLayers.Click += (this.btOSDClearLayers_Click);
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
            this.groupBox15.Location = (new global::System.Drawing.Point(269, 119));
            this.groupBox15.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox15.Name = ("groupBox15");
            this.groupBox15.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox15.Size = (new global::System.Drawing.Size(209, 258));
            this.groupBox15.TabIndex = (11);
            this.groupBox15.TabStop = (false);
            this.groupBox15.Text = ("New layer");
            // 
            // btOSDLayerAdd
            // 
            this.btOSDLayerAdd.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btOSDLayerAdd.Location = (new global::System.Drawing.Point(51, 206));
            this.btOSDLayerAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btOSDLayerAdd.Name = ("btOSDLayerAdd");
            this.btOSDLayerAdd.Size = (new global::System.Drawing.Size(92, 44));
            this.btOSDLayerAdd.TabIndex = (8);
            this.btOSDLayerAdd.Text = ("Create");
            this.btOSDLayerAdd.UseVisualStyleBackColor = (true);
            this.btOSDLayerAdd.Click += (this.btOSDLayerAdd_Click);
            // 
            // edOSDLayerHeight
            // 
            this.edOSDLayerHeight.Location = (new global::System.Drawing.Point(122, 156));
            this.edOSDLayerHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDLayerHeight.Name = ("edOSDLayerHeight");
            this.edOSDLayerHeight.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDLayerHeight.TabIndex = (7);
            this.edOSDLayerHeight.Text = ("200");
            // 
            // label111
            // 
            this.label111.AutoSize = (true);
            this.label111.Location = (new global::System.Drawing.Point(118, 125));
            this.label111.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label111.Name = ("label111");
            this.label111.Size = (new global::System.Drawing.Size(65, 25));
            this.label111.TabIndex = (6);
            this.label111.Text = ("Height");
            // 
            // edOSDLayerWidth
            // 
            this.edOSDLayerWidth.Location = (new global::System.Drawing.Point(22, 156));
            this.edOSDLayerWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDLayerWidth.Name = ("edOSDLayerWidth");
            this.edOSDLayerWidth.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDLayerWidth.TabIndex = (5);
            this.edOSDLayerWidth.Text = ("200");
            // 
            // label112
            // 
            this.label112.AutoSize = (true);
            this.label112.Location = (new global::System.Drawing.Point(18, 125));
            this.label112.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label112.Name = ("label112");
            this.label112.Size = (new global::System.Drawing.Size(60, 25));
            this.label112.TabIndex = (4);
            this.label112.Text = ("Width");
            // 
            // edOSDLayerTop
            // 
            this.edOSDLayerTop.Location = (new global::System.Drawing.Point(122, 81));
            this.edOSDLayerTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDLayerTop.Name = ("edOSDLayerTop");
            this.edOSDLayerTop.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDLayerTop.TabIndex = (3);
            this.edOSDLayerTop.Text = ("0");
            // 
            // label110
            // 
            this.label110.AutoSize = (true);
            this.label110.Location = (new global::System.Drawing.Point(118, 50));
            this.label110.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label110.Name = ("label110");
            this.label110.Size = (new global::System.Drawing.Size(41, 25));
            this.label110.TabIndex = (2);
            this.label110.Text = ("Top");
            // 
            // edOSDLayerLeft
            // 
            this.edOSDLayerLeft.Location = (new global::System.Drawing.Point(22, 81));
            this.edOSDLayerLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOSDLayerLeft.Name = ("edOSDLayerLeft");
            this.edOSDLayerLeft.Size = (new global::System.Drawing.Size(62, 31));
            this.edOSDLayerLeft.TabIndex = (1);
            this.edOSDLayerLeft.Text = ("0");
            // 
            // label109
            // 
            this.label109.AutoSize = (true);
            this.label109.Location = (new global::System.Drawing.Point(18, 50));
            this.label109.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label109.Name = ("label109");
            this.label109.Size = (new global::System.Drawing.Size(41, 25));
            this.label109.TabIndex = (0);
            this.label109.Text = ("Left");
            // 
            // label108
            // 
            this.label108.AutoSize = (true);
            this.label108.Location = (new global::System.Drawing.Point(20, 98));
            this.label108.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label108.Name = ("label108");
            this.label108.Size = (new global::System.Drawing.Size(61, 25));
            this.label108.TabIndex = (9);
            this.label108.Text = ("Layers");
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.tabControl5);
            this.tabPage12.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage12.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage12.Name = ("tabPage12");
            this.tabPage12.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage12.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage12.TabIndex = (6);
            this.tabPage12.Text = ("Decoders / Splitter");
            this.tabPage12.UseVisualStyleBackColor = (true);
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage33);
            this.tabControl5.Controls.Add(this.tabPage34);
            this.tabControl5.Controls.Add(this.tabPage47);
            this.tabControl5.Location = (new global::System.Drawing.Point(10, 11));
            this.tabControl5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl5.Name = ("tabControl5");
            this.tabControl5.SelectedIndex = (0);
            this.tabControl5.Size = (new global::System.Drawing.Size(488, 922));
            this.tabControl5.TabIndex = (0);
            // 
            // tabPage33
            // 
            this.tabPage33.Controls.Add(this.cbCustomSplitter);
            this.tabPage33.Controls.Add(this.rbSplitterCustom);
            this.tabPage33.Controls.Add(this.rbSplitterDefault);
            this.tabPage33.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage33.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage33.Name = ("tabPage33");
            this.tabPage33.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage33.Size = (new global::System.Drawing.Size(480, 884));
            this.tabPage33.TabIndex = (0);
            this.tabPage33.Text = ("Splitter");
            this.tabPage33.UseVisualStyleBackColor = (true);
            // 
            // cbCustomSplitter
            // 
            this.cbCustomSplitter.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbCustomSplitter.FormattingEnabled = (true);
            this.cbCustomSplitter.Location = (new global::System.Drawing.Point(60, 128));
            this.cbCustomSplitter.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCustomSplitter.Name = ("cbCustomSplitter");
            this.cbCustomSplitter.Size = (new global::System.Drawing.Size(386, 33));
            this.cbCustomSplitter.Sorted = (true);
            this.cbCustomSplitter.TabIndex = (27);
            // 
            // rbSplitterCustom
            // 
            this.rbSplitterCustom.AutoSize = (true);
            this.rbSplitterCustom.Location = (new global::System.Drawing.Point(28, 81));
            this.rbSplitterCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbSplitterCustom.Name = ("rbSplitterCustom");
            this.rbSplitterCustom.Size = (new global::System.Drawing.Size(99, 29));
            this.rbSplitterCustom.TabIndex = (1);
            this.rbSplitterCustom.Text = ("Custom");
            this.rbSplitterCustom.UseVisualStyleBackColor = (true);
            // 
            // rbSplitterDefault
            // 
            this.rbSplitterDefault.AutoSize = (true);
            this.rbSplitterDefault.Checked = (true);
            this.rbSplitterDefault.Location = (new global::System.Drawing.Point(28, 30));
            this.rbSplitterDefault.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbSplitterDefault.Name = ("rbSplitterDefault");
            this.rbSplitterDefault.Size = (new global::System.Drawing.Size(94, 29));
            this.rbSplitterDefault.TabIndex = (0);
            this.rbSplitterDefault.TabStop = (true);
            this.rbSplitterDefault.Text = ("Default");
            this.rbSplitterDefault.UseVisualStyleBackColor = (true);
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
            this.tabPage34.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage34.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage34.Name = ("tabPage34");
            this.tabPage34.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage34.Size = (new global::System.Drawing.Size(480, 884));
            this.tabPage34.TabIndex = (1);
            this.tabPage34.Text = ("Video decoder");
            this.tabPage34.UseVisualStyleBackColor = (true);
            // 
            // rbVideoDecoderVFH264
            // 
            this.rbVideoDecoderVFH264.AutoSize = (true);
            this.rbVideoDecoderVFH264.Location = (new global::System.Drawing.Point(28, 384));
            this.rbVideoDecoderVFH264.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoDecoderVFH264.Name = ("rbVideoDecoderVFH264");
            this.rbVideoDecoderVFH264.Size = (new global::System.Drawing.Size(241, 29));
            this.rbVideoDecoderVFH264.TabIndex = (26);
            this.rbVideoDecoderVFH264.TabStop = (true);
            this.rbVideoDecoderVFH264.Text = ("VisioForge H264 Decoder");
            this.rbVideoDecoderVFH264.UseVisualStyleBackColor = (true);
            // 
            // cbCustomVideoDecoder
            // 
            this.cbCustomVideoDecoder.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbCustomVideoDecoder.FormattingEnabled = (true);
            this.cbCustomVideoDecoder.Location = (new global::System.Drawing.Point(62, 495));
            this.cbCustomVideoDecoder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCustomVideoDecoder.Name = ("cbCustomVideoDecoder");
            this.cbCustomVideoDecoder.Size = (new global::System.Drawing.Size(386, 33));
            this.cbCustomVideoDecoder.Sorted = (true);
            this.cbCustomVideoDecoder.TabIndex = (25);
            // 
            // label28
            // 
            this.label28.AutoSize = (true);
            this.label28.Location = (new global::System.Drawing.Point(58, 325));
            this.label28.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label28.Name = ("label28");
            this.label28.Size = (new global::System.Drawing.Size(159, 25));
            this.label28.TabIndex = (24);
            this.label28.Text = ("and DVD playback");
            // 
            // label27
            // 
            this.label27.AutoSize = (true);
            this.label27.Location = (new global::System.Drawing.Point(58, 281));
            this.label27.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label27.Name = ("label27");
            this.label27.Size = (new global::System.Drawing.Size(404, 25));
            this.label27.TabIndex = (23);
            this.label27.Text = ("To play DVD you must activate MPEG-2 decoding");
            // 
            // label26
            // 
            this.label26.AutoSize = (true);
            this.label26.Location = (new global::System.Drawing.Point(58, 155));
            this.label26.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label26.Name = ("label26");
            this.label26.Size = (new global::System.Drawing.Size(329, 25));
            this.label26.TabIndex = (22);
            this.label26.Text = ("Available on Vista / 7 Premium and later");
            // 
            // rbVideoDecoderCustom
            // 
            this.rbVideoDecoderCustom.AutoSize = (true);
            this.rbVideoDecoderCustom.Location = (new global::System.Drawing.Point(28, 452));
            this.rbVideoDecoderCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoDecoderCustom.Name = ("rbVideoDecoderCustom");
            this.rbVideoDecoderCustom.Size = (new global::System.Drawing.Size(99, 29));
            this.rbVideoDecoderCustom.TabIndex = (21);
            this.rbVideoDecoderCustom.Text = ("Custom");
            this.rbVideoDecoderCustom.UseVisualStyleBackColor = (true);
            // 
            // rbVideoDecoderFFDShow
            // 
            this.rbVideoDecoderFFDShow.AutoSize = (true);
            this.rbVideoDecoderFFDShow.Location = (new global::System.Drawing.Point(28, 222));
            this.rbVideoDecoderFFDShow.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoDecoderFFDShow.Name = ("rbVideoDecoderFFDShow");
            this.rbVideoDecoderFFDShow.Size = (new global::System.Drawing.Size(112, 29));
            this.rbVideoDecoderFFDShow.TabIndex = (20);
            this.rbVideoDecoderFFDShow.Text = ("FFDShow");
            this.rbVideoDecoderFFDShow.UseVisualStyleBackColor = (true);
            // 
            // rbVideoDecoderMS
            // 
            this.rbVideoDecoderMS.AutoSize = (true);
            this.rbVideoDecoderMS.Location = (new global::System.Drawing.Point(28, 98));
            this.rbVideoDecoderMS.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoDecoderMS.Name = ("rbVideoDecoderMS");
            this.rbVideoDecoderMS.Size = (new global::System.Drawing.Size(317, 29));
            this.rbVideoDecoderMS.TabIndex = (19);
            this.rbVideoDecoderMS.Text = ("Microsoft DTV/DVD Video Decoder");
            this.rbVideoDecoderMS.UseVisualStyleBackColor = (true);
            // 
            // rbVideoDecoderDefault
            // 
            this.rbVideoDecoderDefault.AutoSize = (true);
            this.rbVideoDecoderDefault.Checked = (true);
            this.rbVideoDecoderDefault.Location = (new global::System.Drawing.Point(28, 30));
            this.rbVideoDecoderDefault.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoDecoderDefault.Name = ("rbVideoDecoderDefault");
            this.rbVideoDecoderDefault.Size = (new global::System.Drawing.Size(94, 29));
            this.rbVideoDecoderDefault.TabIndex = (18);
            this.rbVideoDecoderDefault.TabStop = (true);
            this.rbVideoDecoderDefault.Text = ("Default");
            this.rbVideoDecoderDefault.UseVisualStyleBackColor = (true);
            // 
            // tabPage47
            // 
            this.tabPage47.Controls.Add(this.cbCustomAudioDecoder);
            this.tabPage47.Controls.Add(this.rbAudioDecoderCustom);
            this.tabPage47.Controls.Add(this.rbAudioDecoderDefault);
            this.tabPage47.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage47.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage47.Name = ("tabPage47");
            this.tabPage47.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage47.Size = (new global::System.Drawing.Size(480, 884));
            this.tabPage47.TabIndex = (2);
            this.tabPage47.Text = ("Audio decoder");
            this.tabPage47.UseVisualStyleBackColor = (true);
            // 
            // cbCustomAudioDecoder
            // 
            this.cbCustomAudioDecoder.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbCustomAudioDecoder.FormattingEnabled = (true);
            this.cbCustomAudioDecoder.Location = (new global::System.Drawing.Point(62, 128));
            this.cbCustomAudioDecoder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCustomAudioDecoder.Name = ("cbCustomAudioDecoder");
            this.cbCustomAudioDecoder.Size = (new global::System.Drawing.Size(386, 33));
            this.cbCustomAudioDecoder.Sorted = (true);
            this.cbCustomAudioDecoder.TabIndex = (30);
            // 
            // rbAudioDecoderCustom
            // 
            this.rbAudioDecoderCustom.AutoSize = (true);
            this.rbAudioDecoderCustom.Location = (new global::System.Drawing.Point(28, 81));
            this.rbAudioDecoderCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbAudioDecoderCustom.Name = ("rbAudioDecoderCustom");
            this.rbAudioDecoderCustom.Size = (new global::System.Drawing.Size(99, 29));
            this.rbAudioDecoderCustom.TabIndex = (29);
            this.rbAudioDecoderCustom.Text = ("Custom");
            this.rbAudioDecoderCustom.UseVisualStyleBackColor = (true);
            // 
            // rbAudioDecoderDefault
            // 
            this.rbAudioDecoderDefault.AutoSize = (true);
            this.rbAudioDecoderDefault.Checked = (true);
            this.rbAudioDecoderDefault.Location = (new global::System.Drawing.Point(28, 30));
            this.rbAudioDecoderDefault.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbAudioDecoderDefault.Name = ("rbAudioDecoderDefault");
            this.rbAudioDecoderDefault.Size = (new global::System.Drawing.Size(94, 29));
            this.rbAudioDecoderDefault.TabIndex = (28);
            this.rbAudioDecoderDefault.TabStop = (true);
            this.rbAudioDecoderDefault.Text = ("Default");
            this.rbAudioDecoderDefault.UseVisualStyleBackColor = (true);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.tabControl9);
            this.tabPage13.Controls.Add(this.cbMotDetEnabled);
            this.tabPage13.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage13.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage13.Name = ("tabPage13");
            this.tabPage13.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage13.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage13.TabIndex = (7);
            this.tabPage13.Text = ("Motion detection");
            this.tabPage13.UseVisualStyleBackColor = (true);
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.tabPage44);
            this.tabControl9.Controls.Add(this.tabPage45);
            this.tabControl9.Location = (new global::System.Drawing.Point(24, 81));
            this.tabControl9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl9.Name = ("tabControl9");
            this.tabControl9.SelectedIndex = (0);
            this.tabControl9.Size = (new global::System.Drawing.Size(448, 794));
            this.tabControl9.TabIndex = (3);
            // 
            // tabPage44
            // 
            this.tabPage44.Controls.Add(this.pbMotionLevel);
            this.tabPage44.Controls.Add(this.label158);
            this.tabPage44.Controls.Add(this.mmMotDetMatrix);
            this.tabPage44.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage44.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage44.Name = ("tabPage44");
            this.tabPage44.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage44.Size = (new global::System.Drawing.Size(440, 756));
            this.tabPage44.TabIndex = (0);
            this.tabPage44.Text = ("Output matrix");
            this.tabPage44.UseVisualStyleBackColor = (true);
            // 
            // pbMotionLevel
            // 
            this.pbMotionLevel.Location = (new global::System.Drawing.Point(10, 630));
            this.pbMotionLevel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pbMotionLevel.Name = ("pbMotionLevel");
            this.pbMotionLevel.Size = (new global::System.Drawing.Size(378, 36));
            this.pbMotionLevel.TabIndex = (2);
            // 
            // label158
            // 
            this.label158.AutoSize = (true);
            this.label158.Location = (new global::System.Drawing.Point(9, 591));
            this.label158.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label158.Name = ("label158");
            this.label158.Size = (new global::System.Drawing.Size(110, 25));
            this.label158.TabIndex = (1);
            this.label158.Text = ("Motion level");
            // 
            // mmMotDetMatrix
            // 
            this.mmMotDetMatrix.Location = (new global::System.Drawing.Point(10, 11));
            this.mmMotDetMatrix.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.mmMotDetMatrix.Multiline = (true);
            this.mmMotDetMatrix.Name = ("mmMotDetMatrix");
            this.mmMotDetMatrix.ScrollBars = (global::System.Windows.Forms.ScrollBars.Both);
            this.mmMotDetMatrix.Size = (new global::System.Drawing.Size(412, 498));
            this.mmMotDetMatrix.TabIndex = (0);
            // 
            // tabPage45
            // 
            this.tabPage45.Controls.Add(this.groupBox25);
            this.tabPage45.Controls.Add(this.btMotDetUpdateSettings);
            this.tabPage45.Controls.Add(this.groupBox27);
            this.tabPage45.Controls.Add(this.groupBox26);
            this.tabPage45.Controls.Add(this.groupBox24);
            this.tabPage45.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage45.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage45.Name = ("tabPage45");
            this.tabPage45.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage45.Size = (new global::System.Drawing.Size(440, 756));
            this.tabPage45.TabIndex = (1);
            this.tabPage45.Text = ("Settings");
            this.tabPage45.UseVisualStyleBackColor = (true);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.cbMotDetHLColor);
            this.groupBox25.Controls.Add(this.label161);
            this.groupBox25.Controls.Add(this.label160);
            this.groupBox25.Controls.Add(this.cbMotDetHLEnabled);
            this.groupBox25.Controls.Add(this.tbMotDetHLThreshold);
            this.groupBox25.Location = (new global::System.Drawing.Point(20, 198));
            this.groupBox25.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox25.Name = ("groupBox25");
            this.groupBox25.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox25.Size = (new global::System.Drawing.Size(389, 166));
            this.groupBox25.TabIndex = (1);
            this.groupBox25.TabStop = (false);
            this.groupBox25.Text = ("Color highlight");
            // 
            // cbMotDetHLColor
            // 
            this.cbMotDetHLColor.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbMotDetHLColor.FormattingEnabled = (true);
            this.cbMotDetHLColor.Items.AddRange(new global::System.Object[] { "Red", "Green", "Blue" });
            this.cbMotDetHLColor.Location = (new global::System.Drawing.Point(256, 114));
            this.cbMotDetHLColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotDetHLColor.Name = ("cbMotDetHLColor");
            this.cbMotDetHLColor.Size = (new global::System.Drawing.Size(114, 33));
            this.cbMotDetHLColor.TabIndex = (5);
            // 
            // label161
            // 
            this.label161.AutoSize = (true);
            this.label161.Location = (new global::System.Drawing.Point(248, 81));
            this.label161.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label161.Name = ("label161");
            this.label161.Size = (new global::System.Drawing.Size(55, 25));
            this.label161.TabIndex = (4);
            this.label161.Text = ("Color");
            // 
            // label160
            // 
            this.label160.AutoSize = (true);
            this.label160.Location = (new global::System.Drawing.Point(50, 81));
            this.label160.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label160.Name = ("label160");
            this.label160.Size = (new global::System.Drawing.Size(90, 25));
            this.label160.TabIndex = (2);
            this.label160.Text = ("Threshold");
            // 
            // cbMotDetHLEnabled
            // 
            this.cbMotDetHLEnabled.AutoSize = (true);
            this.cbMotDetHLEnabled.Checked = (true);
            this.cbMotDetHLEnabled.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbMotDetHLEnabled.Location = (new global::System.Drawing.Point(22, 42));
            this.cbMotDetHLEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotDetHLEnabled.Name = ("cbMotDetHLEnabled");
            this.cbMotDetHLEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotDetHLEnabled.TabIndex = (1);
            this.cbMotDetHLEnabled.Text = ("Enabled");
            this.cbMotDetHLEnabled.UseVisualStyleBackColor = (true);
            // 
            // tbMotDetHLThreshold
            // 
            this.tbMotDetHLThreshold.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbMotDetHLThreshold.Location = (new global::System.Drawing.Point(51, 111));
            this.tbMotDetHLThreshold.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbMotDetHLThreshold.Maximum = (255);
            this.tbMotDetHLThreshold.Name = ("tbMotDetHLThreshold");
            this.tbMotDetHLThreshold.Size = (new global::System.Drawing.Size(172, 69));
            this.tbMotDetHLThreshold.TabIndex = (3);
            this.tbMotDetHLThreshold.TickFrequency = (5);
            this.tbMotDetHLThreshold.Value = (25);
            // 
            // btMotDetUpdateSettings
            // 
            this.btMotDetUpdateSettings.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btMotDetUpdateSettings.Location = (new global::System.Drawing.Point(230, 689));
            this.btMotDetUpdateSettings.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btMotDetUpdateSettings.Name = ("btMotDetUpdateSettings");
            this.btMotDetUpdateSettings.Size = (new global::System.Drawing.Size(178, 44));
            this.btMotDetUpdateSettings.TabIndex = (4);
            this.btMotDetUpdateSettings.Text = ("Update settings");
            this.btMotDetUpdateSettings.UseVisualStyleBackColor = (true);
            this.btMotDetUpdateSettings.Click += (this.btMotDetUpdateSettings_Click);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.edMotDetMatrixHeight);
            this.groupBox27.Controls.Add(this.label163);
            this.groupBox27.Controls.Add(this.edMotDetMatrixWidth);
            this.groupBox27.Controls.Add(this.label164);
            this.groupBox27.Location = (new global::System.Drawing.Point(20, 511));
            this.groupBox27.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox27.Name = ("groupBox27");
            this.groupBox27.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox27.Size = (new global::System.Drawing.Size(389, 114));
            this.groupBox27.TabIndex = (3);
            this.groupBox27.TabStop = (false);
            this.groupBox27.Text = ("Matrix");
            // 
            // edMotDetMatrixHeight
            // 
            this.edMotDetMatrixHeight.Location = (new global::System.Drawing.Point(242, 44));
            this.edMotDetMatrixHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMotDetMatrixHeight.Name = ("edMotDetMatrixHeight");
            this.edMotDetMatrixHeight.Size = (new global::System.Drawing.Size(56, 31));
            this.edMotDetMatrixHeight.TabIndex = (75);
            this.edMotDetMatrixHeight.Text = ("10");
            // 
            // label163
            // 
            this.label163.AutoSize = (true);
            this.label163.Location = (new global::System.Drawing.Point(162, 50));
            this.label163.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label163.Name = ("label163");
            this.label163.Size = (new global::System.Drawing.Size(65, 25));
            this.label163.TabIndex = (74);
            this.label163.Text = ("Height");
            // 
            // edMotDetMatrixWidth
            // 
            this.edMotDetMatrixWidth.Location = (new global::System.Drawing.Point(92, 44));
            this.edMotDetMatrixWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMotDetMatrixWidth.Name = ("edMotDetMatrixWidth");
            this.edMotDetMatrixWidth.Size = (new global::System.Drawing.Size(56, 31));
            this.edMotDetMatrixWidth.TabIndex = (73);
            this.edMotDetMatrixWidth.Text = ("10");
            // 
            // label164
            // 
            this.label164.AutoSize = (true);
            this.label164.Location = (new global::System.Drawing.Point(22, 50));
            this.label164.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label164.Name = ("label164");
            this.label164.Size = (new global::System.Drawing.Size(60, 25));
            this.label164.TabIndex = (72);
            this.label164.Text = ("Width");
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label162);
            this.groupBox26.Controls.Add(this.tbMotDetDropFramesThreshold);
            this.groupBox26.Controls.Add(this.cbMotDetDropFramesEnabled);
            this.groupBox26.Location = (new global::System.Drawing.Point(20, 369));
            this.groupBox26.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox26.Name = ("groupBox26");
            this.groupBox26.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox26.Size = (new global::System.Drawing.Size(389, 131));
            this.groupBox26.TabIndex = (2);
            this.groupBox26.TabStop = (false);
            this.groupBox26.Text = ("Drop frames");
            // 
            // label162
            // 
            this.label162.AutoSize = (true);
            this.label162.Location = (new global::System.Drawing.Point(158, 41));
            this.label162.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label162.Name = ("label162");
            this.label162.Size = (new global::System.Drawing.Size(90, 25));
            this.label162.TabIndex = (4);
            this.label162.Text = ("Threshold");
            // 
            // tbMotDetDropFramesThreshold
            // 
            this.tbMotDetDropFramesThreshold.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbMotDetDropFramesThreshold.Location = (new global::System.Drawing.Point(158, 70));
            this.tbMotDetDropFramesThreshold.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbMotDetDropFramesThreshold.Maximum = (255);
            this.tbMotDetDropFramesThreshold.Name = ("tbMotDetDropFramesThreshold");
            this.tbMotDetDropFramesThreshold.Size = (new global::System.Drawing.Size(172, 69));
            this.tbMotDetDropFramesThreshold.TabIndex = (5);
            this.tbMotDetDropFramesThreshold.TickFrequency = (5);
            this.tbMotDetDropFramesThreshold.Value = (5);
            // 
            // cbMotDetDropFramesEnabled
            // 
            this.cbMotDetDropFramesEnabled.AutoSize = (true);
            this.cbMotDetDropFramesEnabled.Location = (new global::System.Drawing.Point(22, 36));
            this.cbMotDetDropFramesEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotDetDropFramesEnabled.Name = ("cbMotDetDropFramesEnabled");
            this.cbMotDetDropFramesEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotDetDropFramesEnabled.TabIndex = (1);
            this.cbMotDetDropFramesEnabled.Text = ("Enabled");
            this.cbMotDetDropFramesEnabled.UseVisualStyleBackColor = (true);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.edMotDetFrameInterval);
            this.groupBox24.Controls.Add(this.label159);
            this.groupBox24.Controls.Add(this.cbCompareGreyscale);
            this.groupBox24.Controls.Add(this.cbCompareBlue);
            this.groupBox24.Controls.Add(this.cbCompareGreen);
            this.groupBox24.Controls.Add(this.cbCompareRed);
            this.groupBox24.Location = (new global::System.Drawing.Point(20, 22));
            this.groupBox24.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox24.Name = ("groupBox24");
            this.groupBox24.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox24.Size = (new global::System.Drawing.Size(389, 158));
            this.groupBox24.TabIndex = (0);
            this.groupBox24.TabStop = (false);
            this.groupBox24.Text = ("Compare settings");
            // 
            // edMotDetFrameInterval
            // 
            this.edMotDetFrameInterval.Location = (new global::System.Drawing.Point(158, 98));
            this.edMotDetFrameInterval.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMotDetFrameInterval.Name = ("edMotDetFrameInterval");
            this.edMotDetFrameInterval.Size = (new global::System.Drawing.Size(52, 31));
            this.edMotDetFrameInterval.TabIndex = (5);
            this.edMotDetFrameInterval.Text = ("2");
            // 
            // label159
            // 
            this.label159.AutoSize = (true);
            this.label159.Location = (new global::System.Drawing.Point(18, 105));
            this.label159.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label159.Name = ("label159");
            this.label159.Size = (new global::System.Drawing.Size(123, 25));
            this.label159.TabIndex = (4);
            this.label159.Text = ("Frame interval");
            // 
            // cbCompareGreyscale
            // 
            this.cbCompareGreyscale.AutoSize = (true);
            this.cbCompareGreyscale.Checked = (true);
            this.cbCompareGreyscale.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbCompareGreyscale.Location = (new global::System.Drawing.Point(271, 41));
            this.cbCompareGreyscale.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCompareGreyscale.Name = ("cbCompareGreyscale");
            this.cbCompareGreyscale.Size = (new global::System.Drawing.Size(112, 29));
            this.cbCompareGreyscale.TabIndex = (3);
            this.cbCompareGreyscale.Text = ("Greyscale");
            this.cbCompareGreyscale.UseVisualStyleBackColor = (true);
            // 
            // cbCompareBlue
            // 
            this.cbCompareBlue.AutoSize = (true);
            this.cbCompareBlue.Location = (new global::System.Drawing.Point(198, 41));
            this.cbCompareBlue.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCompareBlue.Name = ("cbCompareBlue");
            this.cbCompareBlue.Size = (new global::System.Drawing.Size(71, 29));
            this.cbCompareBlue.TabIndex = (2);
            this.cbCompareBlue.Text = ("Blue");
            this.cbCompareBlue.UseVisualStyleBackColor = (true);
            // 
            // cbCompareGreen
            // 
            this.cbCompareGreen.AutoSize = (true);
            this.cbCompareGreen.Location = (new global::System.Drawing.Point(100, 41));
            this.cbCompareGreen.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCompareGreen.Name = ("cbCompareGreen");
            this.cbCompareGreen.Size = (new global::System.Drawing.Size(84, 29));
            this.cbCompareGreen.TabIndex = (1);
            this.cbCompareGreen.Text = ("Green");
            this.cbCompareGreen.UseVisualStyleBackColor = (true);
            // 
            // cbCompareRed
            // 
            this.cbCompareRed.AutoSize = (true);
            this.cbCompareRed.Location = (new global::System.Drawing.Point(22, 41));
            this.cbCompareRed.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCompareRed.Name = ("cbCompareRed");
            this.cbCompareRed.Size = (new global::System.Drawing.Size(68, 29));
            this.cbCompareRed.TabIndex = (0);
            this.cbCompareRed.Text = ("Red");
            this.cbCompareRed.UseVisualStyleBackColor = (true);
            // 
            // cbMotDetEnabled
            // 
            this.cbMotDetEnabled.AutoSize = (true);
            this.cbMotDetEnabled.Location = (new global::System.Drawing.Point(24, 31));
            this.cbMotDetEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotDetEnabled.Name = ("cbMotDetEnabled");
            this.cbMotDetEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotDetEnabled.TabIndex = (2);
            this.cbMotDetEnabled.Text = ("Enabled");
            this.cbMotDetEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage14.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage14.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage14.Name = ("tabPage14");
            this.tabPage14.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage14.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage14.TabIndex = (14);
            this.tabPage14.Text = ("Motion detection (Extended)");
            this.tabPage14.UseVisualStyleBackColor = (true);
            // 
            // label505
            // 
            this.label505.AutoSize = (true);
            this.label505.Location = (new global::System.Drawing.Point(28, 192));
            this.label505.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label505.Name = ("label505");
            this.label505.Size = (new global::System.Drawing.Size(89, 25));
            this.label505.TabIndex = (31);
            this.label505.Text = ("Processor");
            // 
            // rbMotionDetectionExProcessor
            // 
            this.rbMotionDetectionExProcessor.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.rbMotionDetectionExProcessor.FormattingEnabled = (true);
            this.rbMotionDetectionExProcessor.Items.AddRange(new global::System.Object[] { "None", "Blob counting objects", "GridMotionAreaProcessing", "Motion area highlighting", "Motion border highlighting" });
            this.rbMotionDetectionExProcessor.Location = (new global::System.Drawing.Point(28, 222));
            this.rbMotionDetectionExProcessor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbMotionDetectionExProcessor.Name = ("rbMotionDetectionExProcessor");
            this.rbMotionDetectionExProcessor.Size = (new global::System.Drawing.Size(426, 33));
            this.rbMotionDetectionExProcessor.TabIndex = (30);
            // 
            // label389
            // 
            this.label389.AutoSize = (true);
            this.label389.Location = (new global::System.Drawing.Point(28, 95));
            this.label389.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label389.Name = ("label389");
            this.label389.Size = (new global::System.Drawing.Size(80, 25));
            this.label389.TabIndex = (29);
            this.label389.Text = ("Detector");
            // 
            // rbMotionDetectionExDetector
            // 
            this.rbMotionDetectionExDetector.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.rbMotionDetectionExDetector.FormattingEnabled = (true);
            this.rbMotionDetectionExDetector.Items.AddRange(new global::System.Object[] { "Custom frame difference", "Simple background modeling", "Two frames difference" });
            this.rbMotionDetectionExDetector.Location = (new global::System.Drawing.Point(28, 128));
            this.rbMotionDetectionExDetector.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbMotionDetectionExDetector.Name = ("rbMotionDetectionExDetector");
            this.rbMotionDetectionExDetector.Size = (new global::System.Drawing.Size(426, 33));
            this.rbMotionDetectionExDetector.TabIndex = (28);
            // 
            // label64
            // 
            this.label64.AutoSize = (true);
            this.label64.Location = (new global::System.Drawing.Point(89, 842));
            this.label64.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label64.Name = ("label64");
            this.label64.Size = (new global::System.Drawing.Size(293, 25));
            this.label64.TabIndex = (27);
            this.label64.Text = ("Much more options available in API");
            // 
            // label65
            // 
            this.label65.AutoSize = (true);
            this.label65.Location = (new global::System.Drawing.Point(28, 305));
            this.label65.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label65.Name = ("label65");
            this.label65.Size = (new global::System.Drawing.Size(110, 25));
            this.label65.TabIndex = (26);
            this.label65.Text = ("Motion level");
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = (new global::System.Drawing.Point(28, 334));
            this.pbAFMotionLevel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pbAFMotionLevel.Name = ("pbAFMotionLevel");
            this.pbAFMotionLevel.Size = (new global::System.Drawing.Size(430, 44));
            this.pbAFMotionLevel.TabIndex = (25);
            // 
            // cbMotionDetectionEx
            // 
            this.cbMotionDetectionEx.AutoSize = (true);
            this.cbMotionDetectionEx.Location = (new global::System.Drawing.Point(28, 22));
            this.cbMotionDetectionEx.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotionDetectionEx.Name = ("cbMotionDetectionEx");
            this.cbMotionDetectionEx.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotionDetectionEx.TabIndex = (24);
            this.cbMotionDetectionEx.Text = ("Enabled");
            this.cbMotionDetectionEx.UseVisualStyleBackColor = (true);
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
            this.tabPage21.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage21.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage21.Name = ("tabPage21");
            this.tabPage21.Padding = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.tabPage21.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage21.TabIndex = (8);
            this.tabPage21.Text = ("Barcode reader");
            this.tabPage21.UseVisualStyleBackColor = (true);
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = (new global::System.Drawing.Point(28, 308));
            this.edBarcodeMetadata.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.edBarcodeMetadata.Multiline = (true);
            this.edBarcodeMetadata.Name = ("edBarcodeMetadata");
            this.edBarcodeMetadata.Size = (new global::System.Drawing.Size(452, 182));
            this.edBarcodeMetadata.TabIndex = (16);
            // 
            // label91
            // 
            this.label91.AutoSize = (true);
            this.label91.Location = (new global::System.Drawing.Point(22, 270));
            this.label91.Margin = (new global::System.Windows.Forms.Padding(2, 0, 2, 0));
            this.label91.Name = ("label91");
            this.label91.Size = (new global::System.Drawing.Size(87, 25));
            this.label91.TabIndex = (15);
            this.label91.Text = ("Metadata");
            // 
            // cbBarcodeType
            // 
            this.cbBarcodeType.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbBarcodeType.FormattingEnabled = (true);
            this.cbBarcodeType.Items.AddRange(new global::System.Object[] { "Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417" });
            this.cbBarcodeType.Location = (new global::System.Drawing.Point(28, 122));
            this.cbBarcodeType.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.cbBarcodeType.Name = ("cbBarcodeType");
            this.cbBarcodeType.Size = (new global::System.Drawing.Size(264, 33));
            this.cbBarcodeType.TabIndex = (14);
            // 
            // label90
            // 
            this.label90.AutoSize = (true);
            this.label90.Location = (new global::System.Drawing.Point(22, 92));
            this.label90.Margin = (new global::System.Windows.Forms.Padding(2, 0, 2, 0));
            this.label90.Name = ("label90");
            this.label90.Size = (new global::System.Drawing.Size(116, 25));
            this.label90.TabIndex = (13);
            this.label90.Text = ("Barcode type");
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = (new global::System.Drawing.Point(28, 516));
            this.btBarcodeReset.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.btBarcodeReset.Name = ("btBarcodeReset");
            this.btBarcodeReset.Size = (new global::System.Drawing.Size(102, 44));
            this.btBarcodeReset.TabIndex = (12);
            this.btBarcodeReset.Text = ("Restart");
            this.btBarcodeReset.UseVisualStyleBackColor = (true);
            this.btBarcodeReset.Click += (this.btBarcodeReset_Click);
            // 
            // edBarcode
            // 
            this.edBarcode.Location = (new global::System.Drawing.Point(28, 216));
            this.edBarcode.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.edBarcode.Name = ("edBarcode");
            this.edBarcode.Size = (new global::System.Drawing.Size(452, 31));
            this.edBarcode.TabIndex = (11);
            // 
            // label89
            // 
            this.label89.AutoSize = (true);
            this.label89.Location = (new global::System.Drawing.Point(22, 184));
            this.label89.Margin = (new global::System.Windows.Forms.Padding(2, 0, 2, 0));
            this.label89.Name = ("label89");
            this.label89.Size = (new global::System.Drawing.Size(153, 25));
            this.label89.TabIndex = (10);
            this.label89.Text = ("Detected barcode");
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = (true);
            this.cbBarcodeDetectionEnabled.Location = (new global::System.Drawing.Point(28, 34));
            this.cbBarcodeDetectionEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbBarcodeDetectionEnabled.Name = ("cbBarcodeDetectionEnabled");
            this.cbBarcodeDetectionEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbBarcodeDetectionEnabled.TabIndex = (9);
            this.cbBarcodeDetectionEnabled.Text = ("Enabled");
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage23
            // 
            this.tabPage23.Controls.Add(this.textBox1);
            this.tabPage23.Controls.Add(this.groupBox48);
            this.tabPage23.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage23.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage23.Name = ("tabPage23");
            this.tabPage23.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage23.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage23.TabIndex = (9);
            this.tabPage23.Text = ("Encryption");
            this.tabPage23.UseVisualStyleBackColor = (true);
            // 
            // textBox1
            // 
            this.textBox1.Location = (new global::System.Drawing.Point(28, 470));
            this.textBox1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.textBox1.Multiline = (true);
            this.textBox1.Name = ("textBox1");
            this.textBox1.ReadOnly = (true);
            this.textBox1.Size = (new global::System.Drawing.Size(446, 149));
            this.textBox1.TabIndex = (11);
            this.textBox1.Text = ("Media Player SDK .Net can play encrypted files created by Video Encryption SDK (DirectShow or included in Video Capture SDK .Net / Video Edit SDK .Net).");
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
            this.groupBox48.Location = (new global::System.Drawing.Point(28, 30));
            this.groupBox48.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox48.Name = ("groupBox48");
            this.groupBox48.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox48.Size = (new global::System.Drawing.Size(449, 431));
            this.groupBox48.TabIndex = (9);
            this.groupBox48.TabStop = (false);
            this.groupBox48.Text = ("Encryption key type");
            // 
            // label343
            // 
            this.label343.AutoSize = (true);
            this.label343.Location = (new global::System.Drawing.Point(56, 381));
            this.label343.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label343.Name = ("label343");
            this.label343.Size = (new global::System.Drawing.Size(258, 25));
            this.label343.TabIndex = (10);
            this.label343.Text = ("You can assign byte[] using API");
            // 
            // edEncryptionKeyHEX
            // 
            this.edEncryptionKeyHEX.Location = (new global::System.Drawing.Point(60, 339));
            this.edEncryptionKeyHEX.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edEncryptionKeyHEX.Name = ("edEncryptionKeyHEX");
            this.edEncryptionKeyHEX.Size = (new global::System.Drawing.Size(354, 31));
            this.edEncryptionKeyHEX.TabIndex = (9);
            this.edEncryptionKeyHEX.Text = ("enter hex data");
            // 
            // rbEncryptionKeyBinary
            // 
            this.rbEncryptionKeyBinary.AutoSize = (true);
            this.rbEncryptionKeyBinary.Location = (new global::System.Drawing.Point(22, 294));
            this.rbEncryptionKeyBinary.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionKeyBinary.Name = ("rbEncryptionKeyBinary");
            this.rbEncryptionKeyBinary.Size = (new global::System.Drawing.Size(197, 29));
            this.rbEncryptionKeyBinary.TabIndex = (8);
            this.rbEncryptionKeyBinary.Text = ("Binary data (v9 SDK)");
            this.rbEncryptionKeyBinary.UseVisualStyleBackColor = (true);
            // 
            // btEncryptionOpenFile
            // 
            this.btEncryptionOpenFile.Location = (new global::System.Drawing.Point(378, 219));
            this.btEncryptionOpenFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btEncryptionOpenFile.Name = ("btEncryptionOpenFile");
            this.btEncryptionOpenFile.Size = (new global::System.Drawing.Size(38, 44));
            this.btEncryptionOpenFile.TabIndex = (7);
            this.btEncryptionOpenFile.Text = ("...");
            this.btEncryptionOpenFile.UseVisualStyleBackColor = (true);
            this.btEncryptionOpenFile.Click += (this.btEncryptionOpenFile_Click);
            // 
            // edEncryptionKeyFile
            // 
            this.edEncryptionKeyFile.Location = (new global::System.Drawing.Point(60, 222));
            this.edEncryptionKeyFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edEncryptionKeyFile.Name = ("edEncryptionKeyFile");
            this.edEncryptionKeyFile.Size = (new global::System.Drawing.Size(306, 31));
            this.edEncryptionKeyFile.TabIndex = (6);
            this.edEncryptionKeyFile.Text = ("c:\\keyfile.txt");
            // 
            // rbEncryptionKeyFile
            // 
            this.rbEncryptionKeyFile.AutoSize = (true);
            this.rbEncryptionKeyFile.Location = (new global::System.Drawing.Point(22, 180));
            this.rbEncryptionKeyFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionKeyFile.Name = ("rbEncryptionKeyFile");
            this.rbEncryptionKeyFile.Size = (new global::System.Drawing.Size(135, 29));
            this.rbEncryptionKeyFile.TabIndex = (5);
            this.rbEncryptionKeyFile.Text = ("File (v9 SDK)");
            this.rbEncryptionKeyFile.UseVisualStyleBackColor = (true);
            // 
            // edEncryptionKeyString
            // 
            this.edEncryptionKeyString.Location = (new global::System.Drawing.Point(60, 108));
            this.edEncryptionKeyString.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edEncryptionKeyString.Name = ("edEncryptionKeyString");
            this.edEncryptionKeyString.Size = (new global::System.Drawing.Size(354, 31));
            this.edEncryptionKeyString.TabIndex = (4);
            this.edEncryptionKeyString.Text = ("100");
            // 
            // rbEncryptionKeyString
            // 
            this.rbEncryptionKeyString.AutoSize = (true);
            this.rbEncryptionKeyString.Checked = (true);
            this.rbEncryptionKeyString.Location = (new global::System.Drawing.Point(22, 55));
            this.rbEncryptionKeyString.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionKeyString.Name = ("rbEncryptionKeyString");
            this.rbEncryptionKeyString.Size = (new global::System.Drawing.Size(83, 29));
            this.rbEncryptionKeyString.TabIndex = (0);
            this.rbEncryptionKeyString.TabStop = (true);
            this.rbEncryptionKeyString.Text = ("String");
            this.rbEncryptionKeyString.UseVisualStyleBackColor = (true);
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
            this.tabPage24.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage24.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage24.Name = ("tabPage24");
            this.tabPage24.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage24.Size = (new global::System.Drawing.Size(508, 957));
            this.tabPage24.TabIndex = (10);
            this.tabPage24.Text = ("Reverse playback");
            this.tabPage24.UseVisualStyleBackColor = (true);
            // 
            // btReversePlaybackNextFrame
            // 
            this.btReversePlaybackNextFrame.Location = (new global::System.Drawing.Point(218, 389));
            this.btReversePlaybackNextFrame.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btReversePlaybackNextFrame.Name = ("btReversePlaybackNextFrame");
            this.btReversePlaybackNextFrame.Size = (new global::System.Drawing.Size(176, 44));
            this.btReversePlaybackNextFrame.TabIndex = (12);
            this.btReversePlaybackNextFrame.Text = ("Next frame");
            this.btReversePlaybackNextFrame.UseVisualStyleBackColor = (true);
            this.btReversePlaybackNextFrame.Click += (this.btReversePlaybackNextFrame_Click);
            // 
            // btReversePlaybackPrevFrame
            // 
            this.btReversePlaybackPrevFrame.Location = (new global::System.Drawing.Point(31, 389));
            this.btReversePlaybackPrevFrame.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btReversePlaybackPrevFrame.Name = ("btReversePlaybackPrevFrame");
            this.btReversePlaybackPrevFrame.Size = (new global::System.Drawing.Size(176, 44));
            this.btReversePlaybackPrevFrame.TabIndex = (11);
            this.btReversePlaybackPrevFrame.Text = ("Previous frame");
            this.btReversePlaybackPrevFrame.UseVisualStyleBackColor = (true);
            this.btReversePlaybackPrevFrame.Click += (this.btReversePlaybackPrevFrame_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = (true);
            this.label34.Location = (new global::System.Drawing.Point(28, 222));
            this.label34.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label34.Name = ("label34");
            this.label34.Size = (new global::System.Drawing.Size(182, 25));
            this.label34.TabIndex = (10);
            this.label34.Text = ("count before tracking");
            // 
            // label33
            // 
            this.label33.AutoSize = (true);
            this.label33.Location = (new global::System.Drawing.Point(28, 191));
            this.label33.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label33.Name = ("label33");
            this.label33.Size = (new global::System.Drawing.Size(377, 25));
            this.label33.TabIndex = (9);
            this.label33.Text = ("Wait several seconds to cache required frames");
            // 
            // btReversePlayback
            // 
            this.btReversePlayback.Location = (new global::System.Drawing.Point(31, 122));
            this.btReversePlayback.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btReversePlayback.Name = ("btReversePlayback");
            this.btReversePlayback.Size = (new global::System.Drawing.Size(318, 44));
            this.btReversePlayback.TabIndex = (8);
            this.btReversePlayback.Text = ("Go to reverse playback mode");
            this.btReversePlayback.UseVisualStyleBackColor = (true);
            this.btReversePlayback.Click += (this.btReversePlayback_Click);
            // 
            // edReversePlaybackCacheSize
            // 
            this.edReversePlaybackCacheSize.Location = (new global::System.Drawing.Point(238, 30));
            this.edReversePlaybackCacheSize.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edReversePlaybackCacheSize.Name = ("edReversePlaybackCacheSize");
            this.edReversePlaybackCacheSize.Size = (new global::System.Drawing.Size(108, 31));
            this.edReversePlaybackCacheSize.TabIndex = (7);
            this.edReversePlaybackCacheSize.Text = ("100");
            // 
            // label32
            // 
            this.label32.AutoSize = (true);
            this.label32.Location = (new global::System.Drawing.Point(28, 34));
            this.label32.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label32.Name = ("label32");
            this.label32.Size = (new global::System.Drawing.Size(144, 25));
            this.label32.TabIndex = (6);
            this.label32.Text = ("Frame cache size");
            // 
            // tbReversePlaybackTrackbar
            // 
            this.tbReversePlaybackTrackbar.Location = (new global::System.Drawing.Point(31, 272));
            this.tbReversePlaybackTrackbar.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbReversePlaybackTrackbar.Maximum = (100);
            this.tbReversePlaybackTrackbar.Name = ("tbReversePlaybackTrackbar");
            this.tbReversePlaybackTrackbar.Size = (new global::System.Drawing.Size(318, 69));
            this.tbReversePlaybackTrackbar.TabIndex = (4);
            this.tbReversePlaybackTrackbar.Value = (100);
            this.tbReversePlaybackTrackbar.Scroll += (this.tbReversePlaybackTrackbar_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = (true);
            this.label14.Location = (new global::System.Drawing.Point(544, 22));
            this.label14.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label14.Name = ("label14");
            this.label14.Size = (new global::System.Drawing.Size(145, 25));
            this.label14.TabIndex = (2);
            this.label14.Text = ("File name or URL");
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Left)) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.edFilenameOrURL.Location = (new global::System.Drawing.Point(550, 55));
            this.edFilenameOrURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFilenameOrURL.Name = ("edFilenameOrURL");
            this.edFilenameOrURL.Size = (new global::System.Drawing.Size(576, 31));
            this.edFilenameOrURL.TabIndex = (3);
            this.edFilenameOrURL.Text = ("c:\\samples\\!video.mp4");
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = (new global::System.Drawing.Point(1204, 50));
            this.btSelectFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectFile.Name = ("btSelectFile");
            this.btSelectFile.Size = (new global::System.Drawing.Size(38, 44));
            this.btSelectFile.TabIndex = (4);
            this.btSelectFile.Text = ("...");
            this.btSelectFile.UseVisualStyleBackColor = (true);
            this.btSelectFile.Click += (this.btSelectFile_Click);
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
            this.groupBox2.Location = (new global::System.Drawing.Point(550, 969));
            this.groupBox2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox2.Name = ("groupBox2");
            this.groupBox2.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox2.Size = (new global::System.Drawing.Size(690, 172));
            this.groupBox2.TabIndex = (7);
            this.groupBox2.TabStop = (false);
            this.groupBox2.Text = ("Controls");
            // 
            // btPreviousFrame
            // 
            this.btPreviousFrame.Location = (new global::System.Drawing.Point(420, 111));
            this.btPreviousFrame.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btPreviousFrame.Name = ("btPreviousFrame");
            this.btPreviousFrame.Size = (new global::System.Drawing.Size(124, 44));
            this.btPreviousFrame.TabIndex = (10);
            this.btPreviousFrame.Text = ("Prev frame");
            this.btPreviousFrame.UseVisualStyleBackColor = (true);
            this.btPreviousFrame.Click += (this.btPreviousFrame_Click);
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = (true);
            this.cbLoop.Location = (new global::System.Drawing.Point(368, 22));
            this.cbLoop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbLoop.Name = ("cbLoop");
            this.cbLoop.Size = (new global::System.Drawing.Size(79, 29));
            this.cbLoop.TabIndex = (9);
            this.cbLoop.Text = ("Loop");
            this.cbLoop.UseVisualStyleBackColor = (true);
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = (new global::System.Drawing.Point(556, 111));
            this.btNextFrame.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btNextFrame.Name = ("btNextFrame");
            this.btNextFrame.Size = (new global::System.Drawing.Size(124, 44));
            this.btNextFrame.TabIndex = (8);
            this.btNextFrame.Text = ("Next frame");
            this.btNextFrame.UseVisualStyleBackColor = (true);
            this.btNextFrame.Click += (this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btStop.Location = (new global::System.Drawing.Point(300, 111));
            this.btStop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStop.Name = ("btStop");
            this.btStop.Size = (new global::System.Drawing.Size(78, 44));
            this.btStop.TabIndex = (7);
            this.btStop.Text = ("Stop");
            this.btStop.UseVisualStyleBackColor = (true);
            this.btStop.Click += (this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = (new global::System.Drawing.Point(202, 111));
            this.btPause.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btPause.Name = ("btPause");
            this.btPause.Size = (new global::System.Drawing.Size(88, 44));
            this.btPause.TabIndex = (6);
            this.btPause.Text = ("Pause");
            this.btPause.UseVisualStyleBackColor = (true);
            this.btPause.Click += (this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = (new global::System.Drawing.Point(91, 111));
            this.btResume.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btResume.Name = ("btResume");
            this.btResume.Size = (new global::System.Drawing.Size(102, 44));
            this.btResume.TabIndex = (5);
            this.btResume.Text = ("Resume");
            this.btResume.UseVisualStyleBackColor = (true);
            this.btResume.Click += (this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btStart.Location = (new global::System.Drawing.Point(10, 111));
            this.btStart.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStart.Name = ("btStart");
            this.btStart.Size = (new global::System.Drawing.Size(71, 44));
            this.btStart.TabIndex = (4);
            this.btStart.Text = ("Start");
            this.btStart.UseVisualStyleBackColor = (true);
            this.btStart.Click += (this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = (new global::System.Drawing.Point(536, 52));
            this.tbSpeed.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbSpeed.Maximum = (25);
            this.tbSpeed.Name = ("tbSpeed");
            this.tbSpeed.Size = (new global::System.Drawing.Size(149, 69));
            this.tbSpeed.TabIndex = (3);
            this.tbSpeed.Value = (10);
            this.tbSpeed.Scroll += (this.tbSpeed_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = (true);
            this.label16.Location = (new global::System.Drawing.Point(538, 20));
            this.label16.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label16.Name = ("label16");
            this.label16.Size = (new global::System.Drawing.Size(62, 25));
            this.label16.TabIndex = (2);
            this.label16.Text = ("Speed");
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = (true);
            this.lbTime.Location = (new global::System.Drawing.Point(362, 61));
            this.lbTime.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbTime.Name = ("lbTime");
            this.lbTime.Size = (new global::System.Drawing.Size(155, 25));
            this.lbTime.TabIndex = (1);
            this.lbTime.Text = ("00:00:00/00:00:00");
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = (new global::System.Drawing.Point(10, 36));
            this.tbTimeline.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbTimeline.Maximum = (100);
            this.tbTimeline.Name = ("tbTimeline");
            this.tbTimeline.Size = (new global::System.Drawing.Size(344, 69));
            this.tbTimeline.TabIndex = (0);
            this.tbTimeline.Scroll += (this.tbTimeline_Scroll);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Location = (new global::System.Drawing.Point(20, 1022));
            this.tabControl3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl3.Name = ("tabControl3");
            this.tabControl3.SelectedIndex = (0);
            this.tabControl3.Size = (new global::System.Drawing.Size(516, 281));
            this.tabControl3.TabIndex = (9);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.cbTelemetry);
            this.tabPage10.Controls.Add(this.mmLog);
            this.tabPage10.Controls.Add(this.cbDebugMode);
            this.tabPage10.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage10.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage10.Name = ("tabPage10");
            this.tabPage10.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage10.Size = (new global::System.Drawing.Size(508, 243));
            this.tabPage10.TabIndex = (2);
            this.tabPage10.Text = ("Debug");
            this.tabPage10.UseVisualStyleBackColor = (true);
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = (true);
            this.cbTelemetry.Checked = (true);
            this.cbTelemetry.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbTelemetry.Location = (new global::System.Drawing.Point(132, 25));
            this.cbTelemetry.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbTelemetry.Name = ("cbTelemetry");
            this.cbTelemetry.Size = (new global::System.Drawing.Size(113, 29));
            this.cbTelemetry.TabIndex = (4);
            this.cbTelemetry.Text = ("Telemetry");
            this.cbTelemetry.UseVisualStyleBackColor = (true);
            // 
            // mmLog
            // 
            this.mmLog.Location = (new global::System.Drawing.Point(28, 69));
            this.mmLog.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.mmLog.Multiline = (true);
            this.mmLog.Name = ("mmLog");
            this.mmLog.ScrollBars = (global::System.Windows.Forms.ScrollBars.Both);
            this.mmLog.Size = (new global::System.Drawing.Size(436, 146));
            this.mmLog.TabIndex = (1);
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = (true);
            this.cbDebugMode.Location = (new global::System.Drawing.Point(28, 25));
            this.cbDebugMode.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDebugMode.Name = ("cbDebugMode");
            this.cbDebugMode.Size = (new global::System.Drawing.Size(92, 29));
            this.cbDebugMode.TabIndex = (0);
            this.cbDebugMode.Text = ("Debug");
            this.cbDebugMode.UseVisualStyleBackColor = (true);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.tabControl13);
            this.tabPage9.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage9.Name = ("tabPage9");
            this.tabPage9.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage9.Size = (new global::System.Drawing.Size(508, 243));
            this.tabPage9.TabIndex = (1);
            this.tabPage9.Text = ("Snapshot");
            this.tabPage9.UseVisualStyleBackColor = (true);
            // 
            // tabControl13
            // 
            this.tabControl13.Controls.Add(this.tabPage54);
            this.tabControl13.Controls.Add(this.tabPage55);
            this.tabControl13.Location = (new global::System.Drawing.Point(2, 5));
            this.tabControl13.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl13.Name = ("tabControl13");
            this.tabControl13.SelectedIndex = (0);
            this.tabControl13.Size = (new global::System.Drawing.Size(489, 214));
            this.tabControl13.TabIndex = (27);
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
            this.tabPage54.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage54.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage54.Name = ("tabPage54");
            this.tabPage54.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage54.Size = (new global::System.Drawing.Size(481, 176));
            this.tabPage54.TabIndex = (0);
            this.tabPage54.Text = ("Main");
            this.tabPage54.UseVisualStyleBackColor = (true);
            // 
            // cbImageType
            // 
            this.cbImageType.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbImageType.FormattingEnabled = (true);
            this.cbImageType.Items.AddRange(new global::System.Object[] { "BMP", "JPEG", "GIF", "PNG", "TIFF" });
            this.cbImageType.Location = (new global::System.Drawing.Point(18, 114));
            this.cbImageType.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbImageType.Name = ("cbImageType");
            this.cbImageType.Size = (new global::System.Drawing.Size(120, 33));
            this.cbImageType.TabIndex = (33);
            // 
            // lbJPEGQuality
            // 
            this.lbJPEGQuality.AutoSize = (true);
            this.lbJPEGQuality.Location = (new global::System.Drawing.Point(436, 119));
            this.lbJPEGQuality.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbJPEGQuality.Name = ("lbJPEGQuality");
            this.lbJPEGQuality.Size = (new global::System.Drawing.Size(32, 25));
            this.lbJPEGQuality.TabIndex = (32);
            this.lbJPEGQuality.Text = ("85");
            // 
            // label38
            // 
            this.label38.AutoSize = (true);
            this.label38.Location = (new global::System.Drawing.Point(198, 119));
            this.label38.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label38.Name = ("label38");
            this.label38.Size = (new global::System.Drawing.Size(107, 25));
            this.label38.TabIndex = (31);
            this.label38.Text = ("JPEG quality");
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Location = (new global::System.Drawing.Point(378, 28));
            this.btSaveScreenshot.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSaveScreenshot.Name = ("btSaveScreenshot");
            this.btSaveScreenshot.Size = (new global::System.Drawing.Size(92, 44));
            this.btSaveScreenshot.TabIndex = (29);
            this.btSaveScreenshot.Text = ("Save");
            this.btSaveScreenshot.UseVisualStyleBackColor = (true);
            this.btSaveScreenshot.Click += (this.btSaveScreenshot_Click);
            // 
            // btSelectScreenshotsFolder
            // 
            this.btSelectScreenshotsFolder.Location = (new global::System.Drawing.Point(330, 28));
            this.btSelectScreenshotsFolder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectScreenshotsFolder.Name = ("btSelectScreenshotsFolder");
            this.btSelectScreenshotsFolder.Size = (new global::System.Drawing.Size(38, 44));
            this.btSelectScreenshotsFolder.TabIndex = (28);
            this.btSelectScreenshotsFolder.Text = ("...");
            this.btSelectScreenshotsFolder.UseVisualStyleBackColor = (true);
            this.btSelectScreenshotsFolder.Click += (this.btSelectScreenshotsFolder_Click);
            // 
            // label63
            // 
            this.label63.AutoSize = (true);
            this.label63.Location = (new global::System.Drawing.Point(12, 36));
            this.label63.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label63.Name = ("label63");
            this.label63.Size = (new global::System.Drawing.Size(62, 25));
            this.label63.TabIndex = (27);
            this.label63.Text = ("Folder");
            // 
            // edScreenshotsFolder
            // 
            this.edScreenshotsFolder.Location = (new global::System.Drawing.Point(89, 31));
            this.edScreenshotsFolder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edScreenshotsFolder.Name = ("edScreenshotsFolder");
            this.edScreenshotsFolder.Size = (new global::System.Drawing.Size(228, 31));
            this.edScreenshotsFolder.TabIndex = (26);
            this.edScreenshotsFolder.Text = ("c:\\");
            // 
            // tbJPEGQuality
            // 
            this.tbJPEGQuality.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbJPEGQuality.Location = (new global::System.Drawing.Point(320, 92));
            this.tbJPEGQuality.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbJPEGQuality.Maximum = (100);
            this.tbJPEGQuality.Name = ("tbJPEGQuality");
            this.tbJPEGQuality.Size = (new global::System.Drawing.Size(108, 69));
            this.tbJPEGQuality.TabIndex = (30);
            this.tbJPEGQuality.TickFrequency = (5);
            this.tbJPEGQuality.Value = (85);
            this.tbJPEGQuality.Scroll += (this.tbJPEGQuality_Scroll);
            // 
            // tabPage55
            // 
            this.tabPage55.Controls.Add(this.edScreenshotHeight);
            this.tabPage55.Controls.Add(this.label176);
            this.tabPage55.Controls.Add(this.edScreenshotWidth);
            this.tabPage55.Controls.Add(this.label177);
            this.tabPage55.Controls.Add(this.cbScreenshotResize);
            this.tabPage55.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage55.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage55.Name = ("tabPage55");
            this.tabPage55.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage55.Size = (new global::System.Drawing.Size(481, 176));
            this.tabPage55.TabIndex = (1);
            this.tabPage55.Text = ("Resize");
            this.tabPage55.UseVisualStyleBackColor = (true);
            // 
            // edScreenshotHeight
            // 
            this.edScreenshotHeight.Location = (new global::System.Drawing.Point(271, 84));
            this.edScreenshotHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edScreenshotHeight.Name = ("edScreenshotHeight");
            this.edScreenshotHeight.Size = (new global::System.Drawing.Size(56, 31));
            this.edScreenshotHeight.TabIndex = (128);
            this.edScreenshotHeight.Text = ("576");
            // 
            // label176
            // 
            this.label176.AutoSize = (true);
            this.label176.Location = (new global::System.Drawing.Point(192, 91));
            this.label176.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label176.Name = ("label176");
            this.label176.Size = (new global::System.Drawing.Size(65, 25));
            this.label176.TabIndex = (127);
            this.label176.Text = ("Height");
            // 
            // edScreenshotWidth
            // 
            this.edScreenshotWidth.Location = (new global::System.Drawing.Point(122, 84));
            this.edScreenshotWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edScreenshotWidth.Name = ("edScreenshotWidth");
            this.edScreenshotWidth.Size = (new global::System.Drawing.Size(56, 31));
            this.edScreenshotWidth.TabIndex = (126);
            this.edScreenshotWidth.Text = ("768");
            // 
            // label177
            // 
            this.label177.AutoSize = (true);
            this.label177.Location = (new global::System.Drawing.Point(52, 91));
            this.label177.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label177.Name = ("label177");
            this.label177.Size = (new global::System.Drawing.Size(60, 25));
            this.label177.TabIndex = (125);
            this.label177.Text = ("Width");
            // 
            // cbScreenshotResize
            // 
            this.cbScreenshotResize.AutoSize = (true);
            this.cbScreenshotResize.Location = (new global::System.Drawing.Point(28, 34));
            this.cbScreenshotResize.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbScreenshotResize.Name = ("cbScreenshotResize");
            this.cbScreenshotResize.Size = (new global::System.Drawing.Size(101, 29));
            this.cbScreenshotResize.TabIndex = (0);
            this.cbScreenshotResize.Text = ("Enabled");
            this.cbScreenshotResize.UseVisualStyleBackColor = (true);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = (global::System.Drawing.Color.White);
            this.fontDialog1.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 32F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.fontDialog1.FontMustExist = (true);
            this.fontDialog1.ShowColor = (true);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = ("Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*");
            // 
            // timer1
            // 
            this.timer1.Interval = (1000);
            this.timer1.Tick += (this.timer1_Tick);
            // 
            // label29
            // 
            this.label29.AutoSize = (true);
            this.label29.Location = (new global::System.Drawing.Point(544, 245));
            this.label29.Margin = (new global::System.Windows.Forms.Padding(2, 0, 2, 0));
            this.label29.Name = ("label29");
            this.label29.Size = (new global::System.Drawing.Size(118, 25));
            this.label29.TabIndex = (14);
            this.label29.Text = ("Source mode");
            // 
            // cbSourceMode
            // 
            this.cbSourceMode.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Left)) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.cbSourceMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbSourceMode.FormattingEnabled = (true);
            this.cbSourceMode.Items.AddRange(new global::System.Object[] { "File / Network stream (decode using LAV) ", "File / Network stream (decode using GPU) ", "File / Network stream (decode using FFMPEG)", "File (decode using DirectShow)", "File (decode using VLC)", "Blu-Ray", "File from memory (decode using DirectShow)", "MMS / WMV (network stream)", "HTTP / RTSP / RTMP (decoding using VLC)", "Encrypted file (decode using DirectShow)", "Custom source filter (specified by CLSID)", "MIDI / KAR" });
            this.cbSourceMode.Location = (new global::System.Drawing.Point(720, 241));
            this.cbSourceMode.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.cbSourceMode.Name = ("cbSourceMode");
            this.cbSourceMode.Size = (new global::System.Drawing.Size(516, 33));
            this.cbSourceMode.TabIndex = (15);
            // 
            // lbSourceFiles
            // 
            this.lbSourceFiles.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Left)) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceFiles.ContextMenuStrip = (this.mnPlaylist);
            this.lbSourceFiles.FormattingEnabled = (true);
            this.lbSourceFiles.ItemHeight = (25);
            this.lbSourceFiles.Location = (new global::System.Drawing.Point(550, 125));
            this.lbSourceFiles.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.lbSourceFiles.Name = ("lbSourceFiles");
            this.lbSourceFiles.Size = (new global::System.Drawing.Size(686, 104));
            this.lbSourceFiles.TabIndex = (16);
            // 
            // mnPlaylist
            // 
            this.mnPlaylist.ImageScalingSize = (new global::System.Drawing.Size(24, 24));
            this.mnPlaylist.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.mnPlaylistRemove, this.mnPlaylistRemoveAll });
            this.mnPlaylist.Name = ("mnPlaylist");
            this.mnPlaylist.Size = (new global::System.Drawing.Size(171, 68));
            this.mnPlaylist.ItemClicked += (this.mnPlaylist_ItemClicked);
            // 
            // mnPlaylistRemove
            // 
            this.mnPlaylistRemove.Name = ("mnPlaylistRemove");
            this.mnPlaylistRemove.Size = (new global::System.Drawing.Size(170, 32));
            this.mnPlaylistRemove.Text = ("Remove");
            // 
            // mnPlaylistRemoveAll
            // 
            this.mnPlaylistRemoveAll.Name = ("mnPlaylistRemoveAll");
            this.mnPlaylistRemoveAll.Size = (new global::System.Drawing.Size(170, 32));
            this.mnPlaylistRemoveAll.Text = ("Remove all");
            // 
            // label30
            // 
            this.label30.AutoSize = (true);
            this.label30.Location = (new global::System.Drawing.Point(548, 94));
            this.label30.Margin = (new global::System.Windows.Forms.Padding(2, 0, 2, 0));
            this.label30.Name = ("label30");
            this.label30.Size = (new global::System.Drawing.Size(66, 25));
            this.label30.TabIndex = (17);
            this.label30.Text = ("Playlist");
            // 
            // btAddFileToPlaylist
            // 
            this.btAddFileToPlaylist.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.btAddFileToPlaylist.Location = (new global::System.Drawing.Point(1138, 52));
            this.btAddFileToPlaylist.Margin = (new global::System.Windows.Forms.Padding(2, 5, 2, 5));
            this.btAddFileToPlaylist.Name = ("btAddFileToPlaylist");
            this.btAddFileToPlaylist.Size = (new global::System.Drawing.Size(62, 42));
            this.btAddFileToPlaylist.TabIndex = (18);
            this.btAddFileToPlaylist.Text = ("Add");
            this.btAddFileToPlaylist.UseVisualStyleBackColor = (true);
            this.btAddFileToPlaylist.Click += (this.btAddFileToPlaylist_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = (true);
            this.linkLabel1.Location = (new global::System.Drawing.Point(1060, 19));
            this.linkLabel1.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel1.Name = ("linkLabel1");
            this.linkLabel1.Size = (new global::System.Drawing.Size(184, 25));
            this.linkLabel1.TabIndex = (20);
            this.linkLabel1.TabStop = (true);
            this.linkLabel1.Text = ("Watch video tutorials!");
            this.linkLabel1.LinkClicked += (this.linkLabel1_LinkClicked);
            // 
            // label37
            // 
            this.label37.AutoSize = (true);
            this.label37.Location = (new global::System.Drawing.Point(548, 305));
            this.label37.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label37.Name = ("label37");
            this.label37.Size = (new global::System.Drawing.Size(166, 25));
            this.label37.TabIndex = (21);
            this.label37.Text = ("Custom filter CLSID");
            // 
            // edCustomSourceFilter
            // 
            this.edCustomSourceFilter.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top) | (global::System.Windows.Forms.AnchorStyles.Left)) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.edCustomSourceFilter.Location = (new global::System.Drawing.Point(720, 298));
            this.edCustomSourceFilter.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edCustomSourceFilter.Name = ("edCustomSourceFilter");
            this.edCustomSourceFilter.Size = (new global::System.Drawing.Size(516, 31));
            this.edCustomSourceFilter.TabIndex = (22);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = (global::System.Drawing.Color.Black);
            this.VideoView1.Location = (new global::System.Drawing.Point(550, 352));
            this.VideoView1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.VideoView1.Name = ("VideoView1");
            this.VideoView1.Size = (new global::System.Drawing.Size(691, 591));
            this.VideoView1.StatusOverlay = (null);
            this.VideoView1.TabIndex = (23);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = (new global::System.Drawing.SizeF(10F, 25F));
            this.AutoScaleMode = (global::System.Windows.Forms.AutoScaleMode.Font);
            this.ClientSize = (new global::System.Drawing.Size(1262, 1330));
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
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((global::System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.Name = ("Form1");
            this.Text = ("Media Player SDK .Net - Main Demo");
            this.FormClosed += (this.Form1_FormClosed);
            this.Load += (this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage49.ResumeLayout(false);
            this.tabPage49.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgTags)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance4)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume4)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance3)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume3)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance2)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume2)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbBalance1)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage69.ResumeLayout(false);
            this.tabPage69.PerformLayout();
            this.tabPage59.ResumeLayout(false);
            this.tabPage59.PerformLayout();
            this.tabPage51.ResumeLayout(false);
            this.tabPage51.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).EndInit();
            this.tabPage46.ResumeLayout(false);
            this.tabPage46.PerformLayout();
            this.tabPage48.ResumeLayout(false);
            this.tabPage48.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.tabControl18.ResumeLayout(false);
            this.tabPage71.ResumeLayout(false);
            this.tabPage71.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).EndInit();
            this.tabPage72.ResumeLayout(false);
            this.tabPage72.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).EndInit();
            this.tabPage73.ResumeLayout(false);
            this.tabPage73.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudRelease)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudAttack)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudDynAmp)).EndInit();
            this.tabPage75.ResumeLayout(false);
            this.tabPage75.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAud3DSound)).EndInit();
            this.tabPage76.ResumeLayout(false);
            this.tabPage76.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudTrueBass)).EndInit();
            this.tabPage27.ResumeLayout(false);
            this.tabPage27.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudPitchShift)).EndInit();
            this.tabPage50.ResumeLayout(false);
            this.tabPage50.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).EndInit();
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).EndInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbOSDTranspLevel)).EndInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).EndInit();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).EndInit();
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
            ((global::System.ComponentModel.ISupportInitialize)(this.tbReversePlaybackTrackbar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabControl13.ResumeLayout(false);
            this.tabPage54.ResumeLayout(false);
            this.tabPage54.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).EndInit();
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
        private System.Windows.Forms.RadioButton rbNDIStreaming;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.CheckBox cbScrollingText;
    }
}