using VisioForge.Core.Types;

namespace VideoEdit_CS_Demo
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            mp4SettingsDialog?.Dispose();
            mp4SettingsDialog = null;

            mp4HWSettingsDialog?.Dispose();
            mp4HWSettingsDialog = null;

            mp3SettingsDialog?.Dispose();
            mp3SettingsDialog = null;

            m4aSettingsDialog?.Dispose();
            m4aSettingsDialog = null;

            gifSettingsDialog?.Dispose();
            gifSettingsDialog = null;

            flacSettingsDialog?.Dispose();
            flacSettingsDialog = null;

            ffmpegSettingsDialog?.Dispose();
            ffmpegSettingsDialog = null;

            ffmpegEXESettingsDialog?.Dispose();
            ffmpegEXESettingsDialog = null;

            dvSettingsDialog?.Dispose();
            dvSettingsDialog = null;

            aviSettingsDialog?.Dispose();
            aviSettingsDialog = null;

            customFormatSettingsDialog?.Dispose();
            customFormatSettingsDialog = null;

            wmvSettingsDialog?.Dispose();
            wmvSettingsDialog = null;

            webmSettingsDialog?.Dispose();
            webmSettingsDialog = null;

            speexSettingsDialog?.Dispose();
            speexSettingsDialog = null;

            pcmSettingsDialog?.Dispose();
            pcmSettingsDialog = null;

            oggVorbisSettingsDialog?.Dispose();
            oggVorbisSettingsDialog = null;

            VideoEdit1?.Dispose();
            VideoEdit1 = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabPage30 = new System.Windows.Forms.TabPage();
            llXiphX64 = new System.Windows.Forms.LinkLabel();
            llXiphX86 = new System.Windows.Forms.LinkLabel();
            label68 = new System.Windows.Forms.Label();
            label67 = new System.Windows.Forms.Label();
            lbInfo = new System.Windows.Forms.Label();
            btConfigure = new System.Windows.Forms.Button();
            btSelectOutput = new System.Windows.Forms.Button();
            edOutput = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            cbOutputVideoFormat = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            tabPage48 = new System.Windows.Forms.TabPage();
            edCropRight = new System.Windows.Forms.TextBox();
            label176 = new System.Windows.Forms.Label();
            edCropBottom = new System.Windows.Forms.TextBox();
            label252 = new System.Windows.Forms.Label();
            edCropLeft = new System.Windows.Forms.TextBox();
            label270 = new System.Windows.Forms.Label();
            edCropTop = new System.Windows.Forms.TextBox();
            label272 = new System.Windows.Forms.Label();
            cbCrop = new System.Windows.Forms.CheckBox();
            label92 = new System.Windows.Forms.Label();
            cbRotate = new System.Windows.Forms.ComboBox();
            cbFrameRate = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            edHeight = new System.Windows.Forms.TextBox();
            edWidth = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            cbResize = new System.Windows.Forms.CheckBox();
            tabPage31 = new System.Windows.Forms.TabPage();
            tabControl17 = new System.Windows.Forms.TabControl();
            tabPage68 = new System.Windows.Forms.TabPage();
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
            tabPage22 = new System.Windows.Forms.TabPage();
            groupBox37 = new System.Windows.Forms.GroupBox();
            btEffZoomRight = new System.Windows.Forms.Button();
            btEffZoomLeft = new System.Windows.Forms.Button();
            btEffZoomOut = new System.Windows.Forms.Button();
            btEffZoomIn = new System.Windows.Forms.Button();
            btEffZoomDown = new System.Windows.Forms.Button();
            btEffZoomUp = new System.Windows.Forms.Button();
            cbZoom = new System.Windows.Forms.CheckBox();
            tabPage23 = new System.Windows.Forms.TabPage();
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
            tabPage43 = new System.Windows.Forms.TabPage();
            rbVideoFadeOut = new System.Windows.Forms.RadioButton();
            rbVideoFadeIn = new System.Windows.Forms.RadioButton();
            groupBox45 = new System.Windows.Forms.GroupBox();
            edVideoFadeInOutStopTime = new System.Windows.Forms.TextBox();
            label329 = new System.Windows.Forms.Label();
            edVideoFadeInOutStartTime = new System.Windows.Forms.TextBox();
            label330 = new System.Windows.Forms.Label();
            cbVideoFadeInOut = new System.Windows.Forms.CheckBox();
            tbContrast = new System.Windows.Forms.TrackBar();
            tbDarkness = new System.Windows.Forms.TrackBar();
            tbLightness = new System.Windows.Forms.TrackBar();
            tbSaturation = new System.Windows.Forms.TrackBar();
            cbInvert = new System.Windows.Forms.CheckBox();
            cbGreyscale = new System.Windows.Forms.CheckBox();
            cbEffects = new System.Windows.Forms.CheckBox();
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
            tabPage15 = new System.Windows.Forms.TabPage();
            tabControl15 = new System.Windows.Forms.TabControl();
            tabPage21 = new System.Windows.Forms.TabPage();
            label64 = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            cbAFMotionHighlight = new System.Windows.Forms.CheckBox();
            cbAFMotionDetection = new System.Windows.Forms.CheckBox();
            tabPage26 = new System.Windows.Forms.TabPage();
            label171 = new System.Windows.Forms.Label();
            label66 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            tabPage20 = new System.Windows.Forms.TabPage();
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
            tabPage70 = new System.Windows.Forms.TabPage();
            btFilterDeleteAll = new System.Windows.Forms.Button();
            btFilterSettings2 = new System.Windows.Forms.Button();
            lbFilters = new System.Windows.Forms.ListBox();
            label106 = new System.Windows.Forms.Label();
            btFilterSettings = new System.Windows.Forms.Button();
            btFilterAdd = new System.Windows.Forms.Button();
            cbFilters = new System.Windows.Forms.ComboBox();
            label105 = new System.Windows.Forms.Label();
            tabPage82 = new System.Windows.Forms.TabPage();
            label177 = new System.Windows.Forms.Label();
            label129 = new System.Windows.Forms.Label();
            btSubtitlesSelectFile = new System.Windows.Forms.Button();
            edSubtitlesFilename = new System.Windows.Forms.TextBox();
            label114 = new System.Windows.Forms.Label();
            cbSubtitlesEnabled = new System.Windows.Forms.CheckBox();
            tabPage83 = new System.Windows.Forms.TabPage();
            label8 = new System.Windows.Forms.Label();
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
            tabPage9 = new System.Windows.Forms.TabPage();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label47 = new System.Windows.Forms.Label();
            edTransStopTime = new System.Windows.Forms.TextBox();
            label48 = new System.Windows.Forms.Label();
            label46 = new System.Windows.Forms.Label();
            edTransStartTime = new System.Windows.Forms.TextBox();
            label45 = new System.Windows.Forms.Label();
            btAddTransition = new System.Windows.Forms.Button();
            cbTransitionName = new System.Windows.Forms.ComboBox();
            label44 = new System.Windows.Forms.Label();
            lbTransitions = new System.Windows.Forms.ListBox();
            label43 = new System.Windows.Forms.Label();
            tabPage66 = new System.Windows.Forms.TabPage();
            lbAudioTimeshift = new System.Windows.Forms.Label();
            tbAudioTimeshift = new System.Windows.Forms.TrackBar();
            label115 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lbAudioOutputGainLFE = new System.Windows.Forms.Label();
            tbAudioOutputGainLFE = new System.Windows.Forms.TrackBar();
            label116 = new System.Windows.Forms.Label();
            lbAudioOutputGainSR = new System.Windows.Forms.Label();
            tbAudioOutputGainSR = new System.Windows.Forms.TrackBar();
            label117 = new System.Windows.Forms.Label();
            lbAudioOutputGainSL = new System.Windows.Forms.Label();
            tbAudioOutputGainSL = new System.Windows.Forms.TrackBar();
            label118 = new System.Windows.Forms.Label();
            lbAudioOutputGainR = new System.Windows.Forms.Label();
            tbAudioOutputGainR = new System.Windows.Forms.TrackBar();
            label119 = new System.Windows.Forms.Label();
            lbAudioOutputGainC = new System.Windows.Forms.Label();
            tbAudioOutputGainC = new System.Windows.Forms.TrackBar();
            label121 = new System.Windows.Forms.Label();
            lbAudioOutputGainL = new System.Windows.Forms.Label();
            tbAudioOutputGainL = new System.Windows.Forms.TrackBar();
            label122 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            lbAudioInputGainLFE = new System.Windows.Forms.Label();
            tbAudioInputGainLFE = new System.Windows.Forms.TrackBar();
            label123 = new System.Windows.Forms.Label();
            lbAudioInputGainSR = new System.Windows.Forms.Label();
            tbAudioInputGainSR = new System.Windows.Forms.TrackBar();
            label124 = new System.Windows.Forms.Label();
            lbAudioInputGainSL = new System.Windows.Forms.Label();
            tbAudioInputGainSL = new System.Windows.Forms.TrackBar();
            label125 = new System.Windows.Forms.Label();
            lbAudioInputGainR = new System.Windows.Forms.Label();
            tbAudioInputGainR = new System.Windows.Forms.TrackBar();
            label126 = new System.Windows.Forms.Label();
            lbAudioInputGainC = new System.Windows.Forms.Label();
            tbAudioInputGainC = new System.Windows.Forms.TrackBar();
            label127 = new System.Windows.Forms.Label();
            lbAudioInputGainL = new System.Windows.Forms.Label();
            tbAudioInputGainL = new System.Windows.Forms.TrackBar();
            label128 = new System.Windows.Forms.Label();
            cbAudioAutoGain = new System.Windows.Forms.CheckBox();
            cbAudioNormalize = new System.Windows.Forms.CheckBox();
            cbAudioEnhancementEnabled = new System.Windows.Forms.CheckBox();
            tabPage3 = new System.Windows.Forms.TabPage();
            label133 = new System.Windows.Forms.Label();
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
            tabPage16 = new System.Windows.Forms.TabPage();
            cbFadeOutEnabled = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            edFadeOutStopTime = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            edFadeOutStartTime = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            cbFadeInEnabled = new System.Windows.Forms.CheckBox();
            label19 = new System.Windows.Forms.Label();
            edFadeInStopTime = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            edFadeInStartTime = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            tabPage81 = new System.Windows.Forms.TabPage();
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
            tabPage27 = new System.Windows.Forms.TabPage();
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
            tabPage2 = new System.Windows.Forms.TabPage();
            label393 = new System.Windows.Forms.Label();
            cbDirect2DRotate = new System.Windows.Forms.ComboBox();
            pnVideoRendererBGColor = new System.Windows.Forms.Panel();
            label394 = new System.Windows.Forms.Label();
            btFullScreen = new System.Windows.Forms.Button();
            cbScreenFlipVertical = new System.Windows.Forms.CheckBox();
            cbScreenFlipHorizontal = new System.Windows.Forms.CheckBox();
            cbStretch = new System.Windows.Forms.CheckBox();
            groupBox13 = new System.Windows.Forms.GroupBox();
            rbDirect2D = new System.Windows.Forms.RadioButton();
            rbNone = new System.Windows.Forms.RadioButton();
            rbEVR = new System.Windows.Forms.RadioButton();
            rbVMR9 = new System.Windows.Forms.RadioButton();
            tabPage25 = new System.Windows.Forms.TabPage();
            edBarcodeMetadata = new System.Windows.Forms.TextBox();
            label91 = new System.Windows.Forms.Label();
            cbBarcodeType = new System.Windows.Forms.ComboBox();
            label90 = new System.Windows.Forms.Label();
            btBarcodeReset = new System.Windows.Forms.Button();
            edBarcode = new System.Windows.Forms.TextBox();
            label89 = new System.Windows.Forms.Label();
            cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            tabPage28 = new System.Windows.Forms.TabPage();
            cbNetworkStreamingMode = new System.Windows.Forms.ComboBox();
            tabControl5 = new System.Windows.Forms.TabControl();
            tabPage32 = new System.Windows.Forms.TabPage();
            label24 = new System.Windows.Forms.Label();
            edNetworkURL = new System.Windows.Forms.TextBox();
            edWMVNetworkPort = new System.Windows.Forms.TextBox();
            label21 = new System.Windows.Forms.Label();
            btRefreshClients = new System.Windows.Forms.Button();
            lbNetworkClients = new System.Windows.Forms.ListBox();
            rbNetworkStreamingUseExternalProfile = new System.Windows.Forms.RadioButton();
            rbNetworkStreamingUseMainWMVSettings = new System.Windows.Forms.RadioButton();
            label81 = new System.Windows.Forms.Label();
            label80 = new System.Windows.Forms.Label();
            edMaximumClients = new System.Windows.Forms.TextBox();
            label22 = new System.Windows.Forms.Label();
            btSelectWMVProfileNetwork = new System.Windows.Forms.Button();
            edNetworkStreamingWMVProfile = new System.Windows.Forms.TextBox();
            label23 = new System.Windows.Forms.Label();
            tabPage49 = new System.Windows.Forms.TabPage();
            edNetworkRTSPURL = new System.Windows.Forms.TextBox();
            label367 = new System.Windows.Forms.Label();
            label366 = new System.Windows.Forms.Label();
            tabPage50 = new System.Windows.Forms.TabPage();
            linkLabel11 = new System.Windows.Forms.LinkLabel();
            rbNetworkRTMPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkRTMPFFMPEG = new System.Windows.Forms.RadioButton();
            edNetworkRTMPURL = new System.Windows.Forms.TextBox();
            label368 = new System.Windows.Forms.Label();
            label369 = new System.Windows.Forms.Label();
            tabPage4 = new System.Windows.Forms.TabPage();
            lbNDI = new System.Windows.Forms.LinkLabel();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            edNDIURL = new System.Windows.Forms.TextBox();
            edNDIName = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            tabPage77 = new System.Windows.Forms.TabPage();
            label484 = new System.Windows.Forms.Label();
            label63 = new System.Windows.Forms.Label();
            label62 = new System.Windows.Forms.Label();
            label314 = new System.Windows.Forms.Label();
            label313 = new System.Windows.Forms.Label();
            edNetworkUDPURL = new System.Windows.Forms.TextBox();
            label372 = new System.Windows.Forms.Label();
            rbNetworkUDPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkUDPFFMPEG = new System.Windows.Forms.RadioButton();
            tabPage51 = new System.Windows.Forms.TabPage();
            rbNetworkSSFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkSSFFMPEGDefault = new System.Windows.Forms.RadioButton();
            linkLabel6 = new System.Windows.Forms.LinkLabel();
            edNetworkSSURL = new System.Windows.Forms.TextBox();
            label370 = new System.Windows.Forms.Label();
            label371 = new System.Windows.Forms.Label();
            rbNetworkSSSoftware = new System.Windows.Forms.RadioButton();
            tabPage33 = new System.Windows.Forms.TabPage();
            linkLabel4 = new System.Windows.Forms.LinkLabel();
            linkLabel5 = new System.Windows.Forms.LinkLabel();
            tabPage5 = new System.Windows.Forms.TabPage();
            edHLSURL = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            edHLSEmbeddedHTTPServerPort = new System.Windows.Forms.TextBox();
            cbHLSEmbeddedHTTPServerEnabled = new System.Windows.Forms.CheckBox();
            cbHLSMode = new System.Windows.Forms.ComboBox();
            label25 = new System.Windows.Forms.Label();
            lbHLSConfigure = new System.Windows.Forms.LinkLabel();
            label532 = new System.Windows.Forms.Label();
            label531 = new System.Windows.Forms.Label();
            label530 = new System.Windows.Forms.Label();
            label529 = new System.Windows.Forms.Label();
            edHLSSegmentCount = new System.Windows.Forms.TextBox();
            label519 = new System.Windows.Forms.Label();
            edHLSSegmentDuration = new System.Windows.Forms.TextBox();
            btSelectHLSOutputFolder = new System.Windows.Forms.Button();
            edHLSOutputFolder = new System.Windows.Forms.TextBox();
            label380 = new System.Windows.Forms.Label();
            cbNetworkStreamingAudioEnabled = new System.Windows.Forms.CheckBox();
            cbNetworkStreaming = new System.Windows.Forms.CheckBox();
            tabPage34 = new System.Windows.Forms.TabPage();
            label328 = new System.Windows.Forms.Label();
            label327 = new System.Windows.Forms.Label();
            label326 = new System.Windows.Forms.Label();
            label325 = new System.Windows.Forms.Label();
            cbVirtualCamera = new System.Windows.Forms.CheckBox();
            tabPage46 = new System.Windows.Forms.TabPage();
            cbDecklinkOutputDownConversionAnalogOutput = new System.Windows.Forms.CheckBox();
            cbDecklinkOutputDownConversion = new System.Windows.Forms.ComboBox();
            label337 = new System.Windows.Forms.Label();
            cbDecklinkOutputHDTVPulldown = new System.Windows.Forms.ComboBox();
            label336 = new System.Windows.Forms.Label();
            cbDecklinkOutputBlackToDeck = new System.Windows.Forms.ComboBox();
            label335 = new System.Windows.Forms.Label();
            cbDecklinkOutputSingleField = new System.Windows.Forms.ComboBox();
            label334 = new System.Windows.Forms.Label();
            cbDecklinkOutputComponentLevels = new System.Windows.Forms.ComboBox();
            label333 = new System.Windows.Forms.Label();
            cbDecklinkOutputNTSC = new System.Windows.Forms.ComboBox();
            label332 = new System.Windows.Forms.Label();
            cbDecklinkOutputDualLink = new System.Windows.Forms.ComboBox();
            label331 = new System.Windows.Forms.Label();
            cbDecklinkOutputAnalog = new System.Windows.Forms.ComboBox();
            label87 = new System.Windows.Forms.Label();
            cbDecklinkDV = new System.Windows.Forms.CheckBox();
            cbDecklinkOutput = new System.Windows.Forms.CheckBox();
            tabPage47 = new System.Windows.Forms.TabPage();
            groupBox48 = new System.Windows.Forms.GroupBox();
            label343 = new System.Windows.Forms.Label();
            edEncryptionKeyHEX = new System.Windows.Forms.TextBox();
            rbEncryptionKeyBinary = new System.Windows.Forms.RadioButton();
            btEncryptionOpenFile = new System.Windows.Forms.Button();
            edEncryptionKeyFile = new System.Windows.Forms.TextBox();
            rbEncryptionKeyFile = new System.Windows.Forms.RadioButton();
            edEncryptionKeyString = new System.Windows.Forms.TextBox();
            rbEncryptionKeyString = new System.Windows.Forms.RadioButton();
            groupBox47 = new System.Windows.Forms.GroupBox();
            rbEncryptionModeAES256 = new System.Windows.Forms.RadioButton();
            rbEncryptionModeAES128 = new System.Windows.Forms.RadioButton();
            groupBox43 = new System.Windows.Forms.GroupBox();
            rbEncryptedH264CUDA = new System.Windows.Forms.RadioButton();
            rbEncryptedH264SW = new System.Windows.Forms.RadioButton();
            tabPage79 = new System.Windows.Forms.TabPage();
            TabControl32 = new System.Windows.Forms.TabControl();
            TabPage142 = new System.Windows.Forms.TabPage();
            edTagTrackID = new System.Windows.Forms.TextBox();
            Label496 = new System.Windows.Forms.Label();
            edTagYear = new System.Windows.Forms.TextBox();
            Label495 = new System.Windows.Forms.Label();
            edTagComment = new System.Windows.Forms.TextBox();
            Label493 = new System.Windows.Forms.Label();
            edTagAlbum = new System.Windows.Forms.TextBox();
            Label491 = new System.Windows.Forms.Label();
            edTagArtists = new System.Windows.Forms.TextBox();
            label494 = new System.Windows.Forms.Label();
            edTagCopyright = new System.Windows.Forms.TextBox();
            label497 = new System.Windows.Forms.Label();
            edTagTitle = new System.Windows.Forms.TextBox();
            label498 = new System.Windows.Forms.Label();
            TabPage143 = new System.Windows.Forms.TabPage();
            imgTagCover = new System.Windows.Forms.PictureBox();
            Label499 = new System.Windows.Forms.Label();
            label500 = new System.Windows.Forms.Label();
            edTagLyrics = new System.Windows.Forms.TextBox();
            label501 = new System.Windows.Forms.Label();
            cbTagGenre = new System.Windows.Forms.ComboBox();
            label502 = new System.Windows.Forms.Label();
            edTagComposers = new System.Windows.Forms.TextBox();
            label503 = new System.Windows.Forms.Label();
            cbTagEnabled = new System.Windows.Forms.CheckBox();
            tabPage24 = new System.Windows.Forms.TabPage();
            cbVUMeter = new System.Windows.Forms.CheckBox();
            tbVUMeterBoost = new System.Windows.Forms.TrackBar();
            label382 = new System.Windows.Forms.Label();
            label381 = new System.Windows.Forms.Label();
            tbVUMeterAmplification = new System.Windows.Forms.TrackBar();
            cbVUMeterPro = new System.Windows.Forms.CheckBox();
            peakMeterCtrl1 = new VisioForge.Core.UI.WinForms.PeakMeterCtrl();
            waveformPainter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            waveformPainter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter();
            volumeMeter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            volumeMeter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            FontDialog1 = new System.Windows.Forms.FontDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            tbSeeking = new System.Windows.Forms.TrackBar();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ProgressBar1 = new System.Windows.Forms.ProgressBar();
            tabControl3 = new System.Windows.Forms.TabControl();
            tabPage52 = new System.Windows.Forms.TabPage();
            linkLabelDecoders = new System.Windows.Forms.LinkLabel();
            groupBox7 = new System.Windows.Forms.GroupBox();
            label72 = new System.Windows.Forms.Label();
            edInsertTime = new System.Windows.Forms.TextBox();
            label73 = new System.Windows.Forms.Label();
            cbInsertAfterPreviousFile = new System.Windows.Forms.CheckBox();
            label50 = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            lbSpeed = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            edStopTime = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            edStartTime = new System.Windows.Forms.TextBox();
            label35 = new System.Windows.Forms.Label();
            cbAddFullFile = new System.Windows.Forms.CheckBox();
            tbSpeed = new System.Windows.Forms.TrackBar();
            btClearList = new System.Windows.Forms.Button();
            btAddInputFile = new System.Windows.Forms.Button();
            lbFiles = new System.Windows.Forms.ListBox();
            label10 = new System.Windows.Forms.Label();
            tabPage53 = new System.Windows.Forms.TabPage();
            label134 = new System.Windows.Forms.Label();
            btSelectOutputCut = new System.Windows.Forms.Button();
            edOutputFileCut = new System.Windows.Forms.TextBox();
            label131 = new System.Windows.Forms.Label();
            btStopCut = new System.Windows.Forms.Button();
            btStartCut = new System.Windows.Forms.Button();
            label31 = new System.Windows.Forms.Label();
            btAddInputFile2 = new System.Windows.Forms.Button();
            edSourceFileToCut = new System.Windows.Forms.TextBox();
            label30 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            edStopTimeCut = new System.Windows.Forms.TextBox();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            edStartTimeCut = new System.Windows.Forms.TextBox();
            label29 = new System.Windows.Forms.Label();
            tabPage54 = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            btSelectOutputJoin = new System.Windows.Forms.Button();
            edOutputFileJoin = new System.Windows.Forms.TextBox();
            label132 = new System.Windows.Forms.Label();
            btStopJoin = new System.Windows.Forms.Button();
            btStartJoin = new System.Windows.Forms.Button();
            btClearList3 = new System.Windows.Forms.Button();
            btAddInputFile3 = new System.Windows.Forms.Button();
            lbFiles2 = new System.Windows.Forms.ListBox();
            label32 = new System.Windows.Forms.Label();
            tabPage74 = new System.Windows.Forms.TabPage();
            label168 = new System.Windows.Forms.Label();
            cbMuxStreamsShortest = new System.Windows.Forms.CheckBox();
            cbMuxStreamsType = new System.Windows.Forms.ComboBox();
            btMuxStreamsSelectFile = new System.Windows.Forms.Button();
            edMuxStreamsSourceFile = new System.Windows.Forms.TextBox();
            label167 = new System.Windows.Forms.Label();
            btMuxStreamsSelectOutput = new System.Windows.Forms.Button();
            edMuxStreamsOutputFile = new System.Windows.Forms.TextBox();
            label165 = new System.Windows.Forms.Label();
            btStopMux = new System.Windows.Forms.Button();
            btStartMux = new System.Windows.Forms.Button();
            btMuxStreamsClear = new System.Windows.Forms.Button();
            btMuxStreamsAdd = new System.Windows.Forms.Button();
            lbMuxStreamsList = new System.Windows.Forms.ListBox();
            label166 = new System.Windows.Forms.Label();
            cbMode = new System.Windows.Forms.ComboBox();
            label130 = new System.Windows.Forms.Label();
            openFileDialogSubtitles = new System.Windows.Forms.OpenFileDialog();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            cbLicensing = new System.Windows.Forms.CheckBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage30.SuspendLayout();
            tabPage48.SuspendLayout();
            tabPage31.SuspendLayout();
            tabControl17.SuspendLayout();
            tabPage68.SuspendLayout();
            tabControl7.SuspendLayout();
            tabPage29.SuspendLayout();
            tabPage42.SuspendLayout();
            tabPage22.SuspendLayout();
            groupBox37.SuspendLayout();
            tabPage23.SuspendLayout();
            groupBox40.SuspendLayout();
            groupBox39.SuspendLayout();
            groupBox38.SuspendLayout();
            tabPage43.SuspendLayout();
            groupBox45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage69.SuspendLayout();
            tabPage59.SuspendLayout();
            tabPage15.SuspendLayout();
            tabControl15.SuspendLayout();
            tabPage21.SuspendLayout();
            tabPage26.SuspendLayout();
            tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).BeginInit();
            tabPage70.SuspendLayout();
            tabPage82.SuspendLayout();
            tabPage83.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).BeginInit();
            tabPage9.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPage66.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).BeginInit();
            tabPage3.SuspendLayout();
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
            tabPage16.SuspendLayout();
            tabPage81.SuspendLayout();
            groupBox41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).BeginInit();
            tabPage27.SuspendLayout();
            tabControl9.SuspendLayout();
            tabPage44.SuspendLayout();
            tabPage45.SuspendLayout();
            groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetHLThreshold).BeginInit();
            groupBox27.SuspendLayout();
            groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetDropFramesThreshold).BeginInit();
            groupBox24.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox13.SuspendLayout();
            tabPage25.SuspendLayout();
            tabPage28.SuspendLayout();
            tabControl5.SuspendLayout();
            tabPage32.SuspendLayout();
            tabPage49.SuspendLayout();
            tabPage50.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage77.SuspendLayout();
            tabPage51.SuspendLayout();
            tabPage33.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage34.SuspendLayout();
            tabPage46.SuspendLayout();
            tabPage47.SuspendLayout();
            groupBox48.SuspendLayout();
            groupBox47.SuspendLayout();
            groupBox43.SuspendLayout();
            tabPage79.SuspendLayout();
            TabControl32.SuspendLayout();
            TabPage142.SuspendLayout();
            TabPage143.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgTagCover).BeginInit();
            tabPage24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSeeking).BeginInit();
            tabControl3.SuspendLayout();
            tabPage52.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            tabPage53.SuspendLayout();
            tabPage54.SuspendLayout();
            tabPage74.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage31);
            tabControl1.Controls.Add(tabPage9);
            tabControl1.Controls.Add(tabPage66);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage81);
            tabControl1.Controls.Add(tabPage27);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage25);
            tabControl1.Controls.Add(tabPage28);
            tabControl1.Controls.Add(tabPage34);
            tabControl1.Controls.Add(tabPage46);
            tabControl1.Controls.Add(tabPage47);
            tabControl1.Controls.Add(tabPage79);
            tabControl1.Controls.Add(tabPage24);
            tabControl1.Location = new System.Drawing.Point(20, 22);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(517, 1000);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Size = new System.Drawing.Size(509, 962);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Output";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage30);
            tabControl2.Controls.Add(tabPage48);
            tabControl2.Location = new System.Drawing.Point(7, 11);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(487, 928);
            tabControl2.TabIndex = 10;
            // 
            // tabPage30
            // 
            tabPage30.Controls.Add(llXiphX64);
            tabPage30.Controls.Add(llXiphX86);
            tabPage30.Controls.Add(label68);
            tabPage30.Controls.Add(label67);
            tabPage30.Controls.Add(lbInfo);
            tabPage30.Controls.Add(btConfigure);
            tabPage30.Controls.Add(btSelectOutput);
            tabPage30.Controls.Add(edOutput);
            tabPage30.Controls.Add(label15);
            tabPage30.Controls.Add(cbOutputVideoFormat);
            tabPage30.Controls.Add(label9);
            tabPage30.Location = new System.Drawing.Point(4, 34);
            tabPage30.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage30.Name = "tabPage30";
            tabPage30.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage30.Size = new System.Drawing.Size(479, 890);
            tabPage30.TabIndex = 6;
            tabPage30.Text = "Main";
            tabPage30.UseVisualStyleBackColor = true;
            // 
            // llXiphX64
            // 
            llXiphX64.AutoSize = true;
            llXiphX64.Location = new System.Drawing.Point(249, 431);
            llXiphX64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llXiphX64.Name = "llXiphX64";
            llXiphX64.Size = new System.Drawing.Size(40, 25);
            llXiphX64.TabIndex = 59;
            llXiphX64.TabStop = true;
            llXiphX64.Text = "x64";
            llXiphX64.LinkClicked += llXiphX64_LinkClicked;
            // 
            // llXiphX86
            // 
            llXiphX86.AutoSize = true;
            llXiphX86.Location = new System.Drawing.Point(198, 431);
            llXiphX86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llXiphX86.Name = "llXiphX86";
            llXiphX86.Size = new System.Drawing.Size(40, 25);
            llXiphX86.TabIndex = 58;
            llXiphX86.TabStop = true;
            llXiphX86.Text = "x86";
            llXiphX86.LinkClicked += llXiphX86_LinkClicked;
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Location = new System.Drawing.Point(0, 431);
            label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label68.Name = "label68";
            label68.Size = new System.Drawing.Size(197, 25);
            label68.TabIndex = 57;
            label68.Text = "and Ogg Vorbis output";
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new System.Drawing.Point(0, 389);
            label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(465, 25);
            label67.TabIndex = 56;
            label67.Text = "Additional redist required to be installed for FLAC, Speex,";
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(13, 122);
            lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 52;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btConfigure
            // 
            btConfigure.Location = new System.Drawing.Point(18, 165);
            btConfigure.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btConfigure.Name = "btConfigure";
            btConfigure.Size = new System.Drawing.Size(102, 44);
            btConfigure.TabIndex = 32;
            btConfigure.Text = "Configure";
            btConfigure.UseVisualStyleBackColor = true;
            btConfigure.Click += btConfigure_Click;
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(407, 290);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(43, 44);
            btSelectOutput.TabIndex = 31;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(18, 294);
            edOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(375, 31);
            edOutput.TabIndex = 30;
            edOutput.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(13, 260);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(87, 25);
            label15.TabIndex = 29;
            label15.Text = "File name";
            // 
            // cbOutputVideoFormat
            // 
            cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputVideoFormat.FormattingEnabled = true;
            cbOutputVideoFormat.Items.AddRange(new object[] { "AVI", "MKV (Matroska)", "WMV (Windows Media Video)", "DV", "PCM/ACM", "MP3", "M4A (AAC)", "WMA (Windows Media Audio)", "Ogg Vorbis", "FLAC", "Speex", "Custom format", "WebM", "FFMPEG", "FFMPEG (external exe)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video" });
            cbOutputVideoFormat.Location = new System.Drawing.Point(18, 65);
            cbOutputVideoFormat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbOutputVideoFormat.Name = "cbOutputVideoFormat";
            cbOutputVideoFormat.Size = new System.Drawing.Size(428, 33);
            cbOutputVideoFormat.TabIndex = 28;
            cbOutputVideoFormat.SelectedIndexChanged += cbOutputVideoFormat_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(13, 31);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(69, 25);
            label9.TabIndex = 27;
            label9.Text = "Format";
            // 
            // tabPage48
            // 
            tabPage48.Controls.Add(edCropRight);
            tabPage48.Controls.Add(label176);
            tabPage48.Controls.Add(edCropBottom);
            tabPage48.Controls.Add(label252);
            tabPage48.Controls.Add(edCropLeft);
            tabPage48.Controls.Add(label270);
            tabPage48.Controls.Add(edCropTop);
            tabPage48.Controls.Add(label272);
            tabPage48.Controls.Add(cbCrop);
            tabPage48.Controls.Add(label92);
            tabPage48.Controls.Add(cbRotate);
            tabPage48.Controls.Add(cbFrameRate);
            tabPage48.Controls.Add(label3);
            tabPage48.Controls.Add(edHeight);
            tabPage48.Controls.Add(edWidth);
            tabPage48.Controls.Add(label2);
            tabPage48.Controls.Add(cbResize);
            tabPage48.Location = new System.Drawing.Point(4, 34);
            tabPage48.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage48.Name = "tabPage48";
            tabPage48.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage48.Size = new System.Drawing.Size(479, 890);
            tabPage48.TabIndex = 14;
            tabPage48.Text = "Resolution / frame rate";
            tabPage48.UseVisualStyleBackColor = true;
            // 
            // edCropRight
            // 
            edCropRight.Location = new System.Drawing.Point(303, 421);
            edCropRight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edCropRight.Name = "edCropRight";
            edCropRight.Size = new System.Drawing.Size(57, 31);
            edCropRight.TabIndex = 174;
            edCropRight.Text = "0";
            // 
            // label176
            // 
            label176.AutoSize = true;
            label176.Location = new System.Drawing.Point(236, 429);
            label176.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label176.Name = "label176";
            label176.Size = new System.Drawing.Size(54, 25);
            label176.TabIndex = 173;
            label176.Text = "Right";
            // 
            // edCropBottom
            // 
            edCropBottom.Location = new System.Drawing.Point(144, 421);
            edCropBottom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edCropBottom.Name = "edCropBottom";
            edCropBottom.Size = new System.Drawing.Size(57, 31);
            edCropBottom.TabIndex = 172;
            edCropBottom.Text = "0";
            // 
            // label252
            // 
            label252.AutoSize = true;
            label252.Location = new System.Drawing.Point(69, 429);
            label252.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label252.Name = "label252";
            label252.Size = new System.Drawing.Size(72, 25);
            label252.TabIndex = 171;
            label252.Text = "Bottom";
            // 
            // edCropLeft
            // 
            edCropLeft.Location = new System.Drawing.Point(303, 371);
            edCropLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edCropLeft.Name = "edCropLeft";
            edCropLeft.Size = new System.Drawing.Size(57, 31);
            edCropLeft.TabIndex = 170;
            edCropLeft.Text = "0";
            // 
            // label270
            // 
            label270.AutoSize = true;
            label270.Location = new System.Drawing.Point(236, 379);
            label270.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label270.Name = "label270";
            label270.Size = new System.Drawing.Size(41, 25);
            label270.TabIndex = 169;
            label270.Text = "Left";
            // 
            // edCropTop
            // 
            edCropTop.Location = new System.Drawing.Point(144, 371);
            edCropTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edCropTop.Name = "edCropTop";
            edCropTop.Size = new System.Drawing.Size(57, 31);
            edCropTop.TabIndex = 168;
            edCropTop.Text = "0";
            // 
            // label272
            // 
            label272.AutoSize = true;
            label272.Location = new System.Drawing.Point(69, 379);
            label272.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label272.Name = "label272";
            label272.Size = new System.Drawing.Size(41, 25);
            label272.TabIndex = 167;
            label272.Text = "Top";
            // 
            // cbCrop
            // 
            cbCrop.AutoSize = true;
            cbCrop.Location = new System.Drawing.Point(23, 329);
            cbCrop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCrop.Name = "cbCrop";
            cbCrop.Size = new System.Drawing.Size(77, 29);
            cbCrop.TabIndex = 166;
            cbCrop.Text = "Crop";
            cbCrop.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            label92.AutoSize = true;
            label92.Location = new System.Drawing.Point(18, 269);
            label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label92.Name = "label92";
            label92.Size = new System.Drawing.Size(63, 25);
            label92.TabIndex = 165;
            label92.Text = "Rotate";
            // 
            // cbRotate
            // 
            cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbRotate.FormattingEnabled = true;
            cbRotate.Items.AddRange(new object[] { "0", "90", "180", "270" });
            cbRotate.Location = new System.Drawing.Point(144, 264);
            cbRotate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbRotate.Name = "cbRotate";
            cbRotate.Size = new System.Drawing.Size(197, 33);
            cbRotate.TabIndex = 164;
            // 
            // cbFrameRate
            // 
            cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFrameRate.FormattingEnabled = true;
            cbFrameRate.Items.AddRange(new object[] { "0", "1", "2", "5", "10", "12", "15", "20", "25", "30" });
            cbFrameRate.Location = new System.Drawing.Point(23, 121);
            cbFrameRate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFrameRate.Name = "cbFrameRate";
            cbFrameRate.Size = new System.Drawing.Size(94, 33);
            cbFrameRate.TabIndex = 163;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 90);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(469, 25);
            label3.TabIndex = 162;
            label3.Text = "Frame rate (Use 0 to have original, set before adding files)";
            // 
            // edHeight
            // 
            edHeight.Location = new System.Drawing.Point(264, 25);
            edHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHeight.Name = "edHeight";
            edHeight.Size = new System.Drawing.Size(77, 31);
            edHeight.TabIndex = 161;
            edHeight.Text = "576";
            // 
            // edWidth
            // 
            edWidth.Location = new System.Drawing.Point(144, 25);
            edWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edWidth.Name = "edWidth";
            edWidth.Size = new System.Drawing.Size(77, 31);
            edWidth.TabIndex = 160;
            edWidth.Text = "768";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(236, 31);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 25);
            label2.TabIndex = 159;
            label2.Text = "x";
            // 
            // cbResize
            // 
            cbResize.AutoSize = true;
            cbResize.Location = new System.Drawing.Point(23, 31);
            cbResize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbResize.Name = "cbResize";
            cbResize.Size = new System.Drawing.Size(86, 29);
            cbResize.TabIndex = 158;
            cbResize.Text = "Resize";
            cbResize.UseVisualStyleBackColor = true;
            // 
            // tabPage31
            // 
            tabPage31.Controls.Add(tabControl17);
            tabPage31.Location = new System.Drawing.Point(4, 34);
            tabPage31.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage31.Name = "tabPage31";
            tabPage31.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage31.Size = new System.Drawing.Size(509, 962);
            tabPage31.TabIndex = 4;
            tabPage31.Text = "Video processing";
            tabPage31.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            tabControl17.Controls.Add(tabPage68);
            tabControl17.Controls.Add(tabPage69);
            tabControl17.Controls.Add(tabPage59);
            tabControl17.Controls.Add(tabPage15);
            tabControl17.Controls.Add(tabPage20);
            tabControl17.Controls.Add(tabPage70);
            tabControl17.Controls.Add(tabPage82);
            tabControl17.Controls.Add(tabPage83);
            tabControl17.Location = new System.Drawing.Point(2, 11);
            tabControl17.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl17.Name = "tabControl17";
            tabControl17.SelectedIndex = 0;
            tabControl17.Size = new System.Drawing.Size(497, 932);
            tabControl17.TabIndex = 37;
            // 
            // tabPage68
            // 
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
            tabPage68.Controls.Add(cbEffects);
            tabPage68.Location = new System.Drawing.Point(4, 34);
            tabPage68.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage68.Name = "tabPage68";
            tabPage68.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage68.Size = new System.Drawing.Size(489, 894);
            tabPage68.TabIndex = 0;
            tabPage68.Text = "Effects";
            tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(350, 304);
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
            cbFlipX.Location = new System.Drawing.Point(250, 304);
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
            label201.Location = new System.Drawing.Point(237, 169);
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
            label199.Location = new System.Drawing.Point(237, 69);
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
            tabControl7.Controls.Add(tabPage22);
            tabControl7.Controls.Add(tabPage23);
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
            btTextLogoRemove.Location = new System.Drawing.Point(343, 414);
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
            btTextLogoEdit.Location = new System.Drawing.Point(123, 414);
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
            lbTextLogos.Location = new System.Drawing.Point(17, 22);
            lbTextLogos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbTextLogos.Name = "lbTextLogos";
            lbTextLogos.Size = new System.Drawing.Size(426, 379);
            lbTextLogos.TabIndex = 5;
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(13, 414);
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
            btImageLogoRemove.Location = new System.Drawing.Point(343, 414);
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
            btImageLogoEdit.Location = new System.Drawing.Point(123, 414);
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
            lbImageLogos.Location = new System.Drawing.Point(17, 22);
            lbImageLogos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbImageLogos.Name = "lbImageLogos";
            lbImageLogos.Size = new System.Drawing.Size(426, 379);
            lbImageLogos.TabIndex = 9;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(13, 414);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(98, 44);
            btImageLogoAdd.TabIndex = 8;
            btImageLogoAdd.Text = "Add";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += btImageLogoAdd_Click;
            // 
            // tabPage22
            // 
            tabPage22.Controls.Add(groupBox37);
            tabPage22.Controls.Add(cbZoom);
            tabPage22.Location = new System.Drawing.Point(4, 34);
            tabPage22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage22.Name = "tabPage22";
            tabPage22.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage22.Size = new System.Drawing.Size(463, 490);
            tabPage22.TabIndex = 2;
            tabPage22.Text = "Zoom";
            tabPage22.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            groupBox37.Controls.Add(btEffZoomRight);
            groupBox37.Controls.Add(btEffZoomLeft);
            groupBox37.Controls.Add(btEffZoomOut);
            groupBox37.Controls.Add(btEffZoomIn);
            groupBox37.Controls.Add(btEffZoomDown);
            groupBox37.Controls.Add(btEffZoomUp);
            groupBox37.Location = new System.Drawing.Point(143, 98);
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
            btEffZoomIn.Size = new System.Drawing.Size(37, 44);
            btEffZoomIn.TabIndex = 2;
            btEffZoomIn.Text = "+";
            btEffZoomIn.UseVisualStyleBackColor = true;
            btEffZoomIn.Click += btEffZoomIn_Click;
            // 
            // btEffZoomDown
            // 
            btEffZoomDown.Location = new System.Drawing.Point(57, 132);
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
            btEffZoomUp.Location = new System.Drawing.Point(57, 39);
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
            cbZoom.Location = new System.Drawing.Point(20, 29);
            cbZoom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbZoom.Name = "cbZoom";
            cbZoom.Size = new System.Drawing.Size(101, 29);
            cbZoom.TabIndex = 17;
            cbZoom.Text = "Enabled";
            cbZoom.UseVisualStyleBackColor = true;
            cbZoom.CheckedChanged += cbZoom_CheckedChanged;
            // 
            // tabPage23
            // 
            tabPage23.Controls.Add(groupBox40);
            tabPage23.Controls.Add(groupBox39);
            tabPage23.Controls.Add(groupBox38);
            tabPage23.Controls.Add(cbPan);
            tabPage23.Location = new System.Drawing.Point(4, 34);
            tabPage23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage23.Name = "tabPage23";
            tabPage23.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage23.Size = new System.Drawing.Size(463, 490);
            tabPage23.TabIndex = 3;
            tabPage23.Text = "Pan";
            tabPage23.UseVisualStyleBackColor = true;
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
            groupBox40.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox40.Name = "groupBox40";
            groupBox40.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            label302.Location = new System.Drawing.Point(136, 104);
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
            label303.Location = new System.Drawing.Point(136, 54);
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
            label304.Location = new System.Drawing.Point(22, 104);
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
            label305.Location = new System.Drawing.Point(22, 54);
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
            groupBox39.Location = new System.Drawing.Point(20, 154);
            groupBox39.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox39.Name = "groupBox39";
            groupBox39.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            label298.Location = new System.Drawing.Point(136, 104);
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
            label299.Location = new System.Drawing.Point(136, 54);
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
            label300.Location = new System.Drawing.Point(22, 104);
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
            label301.Location = new System.Drawing.Point(22, 54);
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
            label296.Location = new System.Drawing.Point(147, 42);
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
            label297.Location = new System.Drawing.Point(17, 42);
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
            // tabPage43
            // 
            tabPage43.Controls.Add(rbVideoFadeOut);
            tabPage43.Controls.Add(rbVideoFadeIn);
            tabPage43.Controls.Add(groupBox45);
            tabPage43.Controls.Add(cbVideoFadeInOut);
            tabPage43.Location = new System.Drawing.Point(4, 34);
            tabPage43.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage43.Name = "tabPage43";
            tabPage43.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage43.Size = new System.Drawing.Size(463, 490);
            tabPage43.TabIndex = 4;
            tabPage43.Text = "Fade-in/out";
            tabPage43.UseVisualStyleBackColor = true;
            // 
            // rbVideoFadeOut
            // 
            rbVideoFadeOut.AutoSize = true;
            rbVideoFadeOut.Location = new System.Drawing.Point(178, 200);
            rbVideoFadeOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoFadeOut.Name = "rbVideoFadeOut";
            rbVideoFadeOut.Size = new System.Drawing.Size(108, 29);
            rbVideoFadeOut.TabIndex = 60;
            rbVideoFadeOut.TabStop = true;
            rbVideoFadeOut.Text = "Fade-out";
            rbVideoFadeOut.UseVisualStyleBackColor = true;
            // 
            // rbVideoFadeIn
            // 
            rbVideoFadeIn.AutoSize = true;
            rbVideoFadeIn.Checked = true;
            rbVideoFadeIn.Location = new System.Drawing.Point(27, 200);
            rbVideoFadeIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoFadeIn.Name = "rbVideoFadeIn";
            rbVideoFadeIn.Size = new System.Drawing.Size(95, 29);
            rbVideoFadeIn.TabIndex = 59;
            rbVideoFadeIn.TabStop = true;
            rbVideoFadeIn.Text = "Fade-in";
            rbVideoFadeIn.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            groupBox45.Controls.Add(edVideoFadeInOutStopTime);
            groupBox45.Controls.Add(label329);
            groupBox45.Controls.Add(edVideoFadeInOutStartTime);
            groupBox45.Controls.Add(label330);
            groupBox45.Location = new System.Drawing.Point(27, 100);
            groupBox45.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox45.Name = "groupBox45";
            groupBox45.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox45.Size = new System.Drawing.Size(280, 89);
            groupBox45.TabIndex = 58;
            groupBox45.TabStop = false;
            groupBox45.Text = "Duration";
            // 
            // edVideoFadeInOutStopTime
            // 
            edVideoFadeInOutStopTime.Location = new System.Drawing.Point(196, 36);
            edVideoFadeInOutStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edVideoFadeInOutStopTime.Name = "edVideoFadeInOutStopTime";
            edVideoFadeInOutStopTime.Size = new System.Drawing.Size(62, 31);
            edVideoFadeInOutStopTime.TabIndex = 34;
            edVideoFadeInOutStopTime.Text = "15000";
            edVideoFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label329
            // 
            label329.AutoSize = true;
            label329.Location = new System.Drawing.Point(147, 42);
            label329.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label329.Name = "label329";
            label329.Size = new System.Drawing.Size(49, 25);
            label329.TabIndex = 33;
            label329.Text = "Stop";
            // 
            // edVideoFadeInOutStartTime
            // 
            edVideoFadeInOutStartTime.Location = new System.Drawing.Point(71, 36);
            edVideoFadeInOutStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edVideoFadeInOutStartTime.Name = "edVideoFadeInOutStartTime";
            edVideoFadeInOutStartTime.Size = new System.Drawing.Size(62, 31);
            edVideoFadeInOutStartTime.TabIndex = 32;
            edVideoFadeInOutStartTime.Text = "5000";
            edVideoFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label330
            // 
            label330.AutoSize = true;
            label330.Location = new System.Drawing.Point(17, 42);
            label330.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label330.Name = "label330";
            label330.Size = new System.Drawing.Size(48, 25);
            label330.TabIndex = 31;
            label330.Text = "Start";
            // 
            // cbVideoFadeInOut
            // 
            cbVideoFadeInOut.AutoSize = true;
            cbVideoFadeInOut.Location = new System.Drawing.Point(27, 35);
            cbVideoFadeInOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoFadeInOut.Name = "cbVideoFadeInOut";
            cbVideoFadeInOut.Size = new System.Drawing.Size(101, 29);
            cbVideoFadeInOut.TabIndex = 57;
            cbVideoFadeInOut.Text = "Enabled";
            cbVideoFadeInOut.UseVisualStyleBackColor = true;
            cbVideoFadeInOut.CheckedChanged += cbFadeInOut_CheckedChanged;
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(4, 206);
            tbContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(217, 69);
            tbContrast.TabIndex = 49;
            tbContrast.Scroll += tbContrast_Scroll;
            // 
            // tbDarkness
            // 
            tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbDarkness.Location = new System.Drawing.Point(237, 206);
            tbDarkness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbDarkness.Maximum = 255;
            tbDarkness.Name = "tbDarkness";
            tbDarkness.Size = new System.Drawing.Size(217, 69);
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
            tbLightness.Size = new System.Drawing.Size(217, 69);
            tbLightness.TabIndex = 45;
            tbLightness.Scroll += tbLightness_Scroll;
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(237, 98);
            tbSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(217, 69);
            tbSaturation.TabIndex = 43;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += tbSaturation_Scroll;
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(150, 304);
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
            cbGreyscale.Location = new System.Drawing.Point(16, 304);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 39;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += cbGreyscale_CheckedChanged;
            // 
            // cbEffects
            // 
            cbEffects.AutoSize = true;
            cbEffects.Checked = true;
            cbEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            cbEffects.Location = new System.Drawing.Point(13, 15);
            cbEffects.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbEffects.Name = "cbEffects";
            cbEffects.Size = new System.Drawing.Size(101, 29);
            cbEffects.TabIndex = 37;
            cbEffects.Text = "Enabled";
            cbEffects.UseVisualStyleBackColor = true;
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
            tabPage69.Size = new System.Drawing.Size(489, 894);
            tabPage69.TabIndex = 1;
            tabPage69.Text = "Deinterlace";
            tabPage69.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            label211.AutoSize = true;
            label211.Location = new System.Drawing.Point(167, 565);
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
            edDeintTriangleWeight.Size = new System.Drawing.Size(51, 31);
            edDeintTriangleWeight.TabIndex = 27;
            edDeintTriangleWeight.Text = "180";
            // 
            // label212
            // 
            label212.AutoSize = true;
            label212.Location = new System.Drawing.Point(57, 525);
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
            label206.Location = new System.Drawing.Point(363, 410);
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
            edDeintBlendConstants2.Size = new System.Drawing.Size(51, 31);
            edDeintBlendConstants2.TabIndex = 22;
            edDeintBlendConstants2.Text = "9";
            // 
            // label207
            // 
            label207.AutoSize = true;
            label207.Location = new System.Drawing.Point(253, 369);
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
            edDeintBlendConstants1.Size = new System.Drawing.Size(51, 31);
            edDeintBlendConstants1.TabIndex = 20;
            edDeintBlendConstants1.Text = "3";
            // 
            // label208
            // 
            label208.AutoSize = true;
            label208.Location = new System.Drawing.Point(253, 306);
            label208.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label208.Name = "label208";
            label208.Size = new System.Drawing.Size(106, 25);
            label208.TabIndex = 19;
            label208.Text = "Constants 1";
            // 
            // label204
            // 
            label204.AutoSize = true;
            label204.Location = new System.Drawing.Point(167, 410);
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
            edDeintBlendThreshold2.Size = new System.Drawing.Size(51, 31);
            edDeintBlendThreshold2.TabIndex = 17;
            edDeintBlendThreshold2.Text = "9";
            // 
            // label205
            // 
            label205.AutoSize = true;
            label205.Location = new System.Drawing.Point(57, 369);
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
            edDeintBlendThreshold1.Size = new System.Drawing.Size(51, 31);
            edDeintBlendThreshold1.TabIndex = 15;
            edDeintBlendThreshold1.Text = "5";
            // 
            // label203
            // 
            label203.AutoSize = true;
            label203.Location = new System.Drawing.Point(57, 306);
            label203.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label203.Name = "label203";
            label203.Size = new System.Drawing.Size(105, 25);
            label203.TabIndex = 14;
            label203.Text = "Threshold 1";
            // 
            // label202
            // 
            label202.AutoSize = true;
            label202.Location = new System.Drawing.Point(167, 198);
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
            edDeintCAVTThreshold.Size = new System.Drawing.Size(51, 31);
            edDeintCAVTThreshold.TabIndex = 12;
            edDeintCAVTThreshold.Text = "20";
            // 
            // label104
            // 
            label104.AutoSize = true;
            label104.Location = new System.Drawing.Point(57, 158);
            label104.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label104.Name = "label104";
            label104.Size = new System.Drawing.Size(90, 25);
            label104.TabIndex = 11;
            label104.Text = "Threshold";
            // 
            // rbDeintTriangleEnabled
            // 
            rbDeintTriangleEnabled.AutoSize = true;
            rbDeintTriangleEnabled.Location = new System.Drawing.Point(30, 468);
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
            tabPage59.Size = new System.Drawing.Size(489, 894);
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
            // tabPage15
            // 
            tabPage15.Controls.Add(tabControl15);
            tabPage15.Controls.Add(label16);
            tabPage15.Location = new System.Drawing.Point(4, 34);
            tabPage15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage15.Name = "tabPage15";
            tabPage15.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage15.Size = new System.Drawing.Size(489, 894);
            tabPage15.TabIndex = 5;
            tabPage15.Text = "Object detection";
            tabPage15.UseVisualStyleBackColor = true;
            // 
            // tabControl15
            // 
            tabControl15.Controls.Add(tabPage21);
            tabControl15.Controls.Add(tabPage26);
            tabControl15.Location = new System.Drawing.Point(16, 11);
            tabControl15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl15.Name = "tabControl15";
            tabControl15.SelectedIndex = 0;
            tabControl15.Size = new System.Drawing.Size(463, 742);
            tabControl15.TabIndex = 3;
            // 
            // tabPage21
            // 
            tabPage21.Controls.Add(label64);
            tabPage21.Controls.Add(label65);
            tabPage21.Controls.Add(pbAFMotionLevel);
            tabPage21.Controls.Add(cbAFMotionHighlight);
            tabPage21.Controls.Add(cbAFMotionDetection);
            tabPage21.Location = new System.Drawing.Point(4, 34);
            tabPage21.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage21.Name = "tabPage21";
            tabPage21.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage21.Size = new System.Drawing.Size(455, 704);
            tabPage21.TabIndex = 0;
            tabPage21.Text = "Motion detection";
            tabPage21.UseVisualStyleBackColor = true;
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new System.Drawing.Point(10, 175);
            label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(435, 25);
            label64.TabIndex = 4;
            label64.Text = "Much more motion detection options available in API";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new System.Drawing.Point(10, 606);
            label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(110, 25);
            label65.TabIndex = 3;
            label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            pbAFMotionLevel.Location = new System.Drawing.Point(10, 636);
            pbAFMotionLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbAFMotionLevel.Name = "pbAFMotionLevel";
            pbAFMotionLevel.Size = new System.Drawing.Size(430, 44);
            pbAFMotionLevel.TabIndex = 2;
            // 
            // cbAFMotionHighlight
            // 
            cbAFMotionHighlight.AutoSize = true;
            cbAFMotionHighlight.Location = new System.Drawing.Point(24, 86);
            cbAFMotionHighlight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAFMotionHighlight.Name = "cbAFMotionHighlight";
            cbAFMotionHighlight.Size = new System.Drawing.Size(111, 29);
            cbAFMotionHighlight.TabIndex = 1;
            cbAFMotionHighlight.Text = "Highlight";
            cbAFMotionHighlight.UseVisualStyleBackColor = true;
            cbAFMotionHighlight.CheckedChanged += cbAFMotionHighlight_CheckedChanged;
            // 
            // cbAFMotionDetection
            // 
            cbAFMotionDetection.AutoSize = true;
            cbAFMotionDetection.Location = new System.Drawing.Point(24, 36);
            cbAFMotionDetection.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAFMotionDetection.Name = "cbAFMotionDetection";
            cbAFMotionDetection.Size = new System.Drawing.Size(221, 29);
            cbAFMotionDetection.TabIndex = 0;
            cbAFMotionDetection.Text = "Enabled, detect objects";
            cbAFMotionDetection.UseVisualStyleBackColor = true;
            cbAFMotionDetection.CheckedChanged += cbAFMotionDetection_CheckedChanged;
            // 
            // tabPage26
            // 
            tabPage26.Controls.Add(label171);
            tabPage26.Controls.Add(label66);
            tabPage26.Location = new System.Drawing.Point(4, 34);
            tabPage26.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage26.Name = "tabPage26";
            tabPage26.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage26.Size = new System.Drawing.Size(455, 704);
            tabPage26.TabIndex = 1;
            tabPage26.Text = "Effects";
            tabPage26.UseVisualStyleBackColor = true;
            // 
            // label171
            // 
            label171.AutoSize = true;
            label171.Location = new System.Drawing.Point(17, 78);
            label171.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label171.Name = "label171";
            label171.Size = new System.Drawing.Size(235, 25);
            label171.TabIndex = 1;
            label171.Text = "OnVideoFrameBuffer event. ";
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Location = new System.Drawing.Point(17, 35);
            label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label66.Name = "label66";
            label66.Size = new System.Drawing.Size(281, 25);
            label66.TabIndex = 0;
            label66.Text = "You can add various effects using ";
            // 
            // label16
            // 
            label16.Location = new System.Drawing.Point(0, 0);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(167, 44);
            label16.TabIndex = 4;
            // 
            // tabPage20
            // 
            tabPage20.Controls.Add(pnChromaKeyColor);
            tabPage20.Controls.Add(btChromaKeySelectBGImage);
            tabPage20.Controls.Add(edChromaKeyImage);
            tabPage20.Controls.Add(label216);
            tabPage20.Controls.Add(label215);
            tabPage20.Controls.Add(tbChromaKeySmoothing);
            tabPage20.Controls.Add(label214);
            tabPage20.Controls.Add(tbChromaKeyThresholdSensitivity);
            tabPage20.Controls.Add(label213);
            tabPage20.Controls.Add(cbChromaKeyEnabled);
            tabPage20.Location = new System.Drawing.Point(4, 34);
            tabPage20.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage20.Name = "tabPage20";
            tabPage20.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage20.Size = new System.Drawing.Size(489, 894);
            tabPage20.TabIndex = 6;
            tabPage20.Text = "Chroma key";
            tabPage20.UseVisualStyleBackColor = true;
            // 
            // pnChromaKeyColor
            // 
            pnChromaKeyColor.BackColor = System.Drawing.Color.Lime;
            pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control;
            pnChromaKeyColor.Location = new System.Drawing.Point(91, 385);
            pnChromaKeyColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnChromaKeyColor.Name = "pnChromaKeyColor";
            pnChromaKeyColor.Size = new System.Drawing.Size(43, 46);
            pnChromaKeyColor.TabIndex = 43;
            pnChromaKeyColor.MouseDown += pnChromaKeyColor_MouseDown;
            // 
            // btChromaKeySelectBGImage
            // 
            btChromaKeySelectBGImage.Location = new System.Drawing.Point(424, 504);
            btChromaKeySelectBGImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage";
            btChromaKeySelectBGImage.Size = new System.Drawing.Size(40, 44);
            btChromaKeySelectBGImage.TabIndex = 42;
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
            edChromaKeyImage.TabIndex = 41;
            edChromaKeyImage.Text = "c:\\Samples\\pics\\1.jpg";
            // 
            // label216
            // 
            label216.AutoSize = true;
            label216.Location = new System.Drawing.Point(17, 478);
            label216.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label216.Name = "label216";
            label216.Size = new System.Drawing.Size(191, 25);
            label216.TabIndex = 40;
            label216.Text = "Image background file";
            // 
            // label215
            // 
            label215.AutoSize = true;
            label215.Location = new System.Drawing.Point(17, 392);
            label215.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label215.Name = "label215";
            label215.Size = new System.Drawing.Size(55, 25);
            label215.TabIndex = 39;
            label215.Text = "Color";
            // 
            // tbChromaKeySmoothing
            // 
            tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeySmoothing.Location = new System.Drawing.Point(22, 279);
            tbChromaKeySmoothing.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbChromaKeySmoothing.Maximum = 1000;
            tbChromaKeySmoothing.Name = "tbChromaKeySmoothing";
            tbChromaKeySmoothing.Size = new System.Drawing.Size(257, 69);
            tbChromaKeySmoothing.TabIndex = 38;
            tbChromaKeySmoothing.Value = 80;
            tbChromaKeySmoothing.Scroll += tbChromaKeySmoothing_Scroll;
            // 
            // label214
            // 
            label214.AutoSize = true;
            label214.Location = new System.Drawing.Point(17, 244);
            label214.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label214.Name = "label214";
            label214.Size = new System.Drawing.Size(101, 25);
            label214.TabIndex = 37;
            label214.Text = "Smoothing";
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeyThresholdSensitivity.Location = new System.Drawing.Point(22, 139);
            tbChromaKeyThresholdSensitivity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbChromaKeyThresholdSensitivity.Maximum = 200;
            tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity";
            tbChromaKeyThresholdSensitivity.Size = new System.Drawing.Size(257, 69);
            tbChromaKeyThresholdSensitivity.TabIndex = 36;
            tbChromaKeyThresholdSensitivity.Value = 180;
            tbChromaKeyThresholdSensitivity.Scroll += tbChromaKeyThresholdSensitivity_Scroll;
            // 
            // label213
            // 
            label213.AutoSize = true;
            label213.Location = new System.Drawing.Point(17, 104);
            label213.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label213.Name = "label213";
            label213.Size = new System.Drawing.Size(172, 25);
            label213.TabIndex = 35;
            label213.Text = "Threshold sensitivity";
            // 
            // cbChromaKeyEnabled
            // 
            cbChromaKeyEnabled.AutoSize = true;
            cbChromaKeyEnabled.Location = new System.Drawing.Point(22, 29);
            cbChromaKeyEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbChromaKeyEnabled.Name = "cbChromaKeyEnabled";
            cbChromaKeyEnabled.Size = new System.Drawing.Size(101, 29);
            cbChromaKeyEnabled.TabIndex = 34;
            cbChromaKeyEnabled.Text = "Enabled";
            cbChromaKeyEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage70
            // 
            tabPage70.Controls.Add(btFilterDeleteAll);
            tabPage70.Controls.Add(btFilterSettings2);
            tabPage70.Controls.Add(lbFilters);
            tabPage70.Controls.Add(label106);
            tabPage70.Controls.Add(btFilterSettings);
            tabPage70.Controls.Add(btFilterAdd);
            tabPage70.Controls.Add(cbFilters);
            tabPage70.Controls.Add(label105);
            tabPage70.Location = new System.Drawing.Point(4, 34);
            tabPage70.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage70.Name = "tabPage70";
            tabPage70.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage70.Size = new System.Drawing.Size(489, 894);
            tabPage70.TabIndex = 3;
            tabPage70.Text = "3rd-party filters";
            tabPage70.UseVisualStyleBackColor = true;
            // 
            // btFilterDeleteAll
            // 
            btFilterDeleteAll.Location = new System.Drawing.Point(350, 552);
            btFilterDeleteAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterDeleteAll.Name = "btFilterDeleteAll";
            btFilterDeleteAll.Size = new System.Drawing.Size(113, 44);
            btFilterDeleteAll.TabIndex = 16;
            btFilterDeleteAll.Text = "Delete all";
            btFilterDeleteAll.UseVisualStyleBackColor = true;
            btFilterDeleteAll.Click += btFilterDeleteAll_Click;
            // 
            // btFilterSettings2
            // 
            btFilterSettings2.Location = new System.Drawing.Point(30, 552);
            btFilterSettings2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterSettings2.Name = "btFilterSettings2";
            btFilterSettings2.Size = new System.Drawing.Size(109, 44);
            btFilterSettings2.TabIndex = 15;
            btFilterSettings2.Text = "Settings";
            btFilterSettings2.UseVisualStyleBackColor = true;
            btFilterSettings2.Click += btFilterSettings2_Click;
            // 
            // lbFilters
            // 
            lbFilters.FormattingEnabled = true;
            lbFilters.ItemHeight = 25;
            lbFilters.Location = new System.Drawing.Point(30, 232);
            lbFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbFilters.Name = "lbFilters";
            lbFilters.Size = new System.Drawing.Size(431, 304);
            lbFilters.TabIndex = 14;
            lbFilters.SelectedIndexChanged += lbFilters_SelectedIndexChanged;
            // 
            // label106
            // 
            label106.AutoSize = true;
            label106.Location = new System.Drawing.Point(24, 202);
            label106.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label106.Name = "label106";
            label106.Size = new System.Drawing.Size(118, 25);
            label106.TabIndex = 13;
            label106.Text = "Current filters";
            // 
            // btFilterSettings
            // 
            btFilterSettings.Location = new System.Drawing.Point(350, 110);
            btFilterSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterSettings.Name = "btFilterSettings";
            btFilterSettings.Size = new System.Drawing.Size(113, 44);
            btFilterSettings.TabIndex = 12;
            btFilterSettings.Text = "Settings";
            btFilterSettings.UseVisualStyleBackColor = true;
            btFilterSettings.Click += btFilterSettings_Click;
            // 
            // btFilterAdd
            // 
            btFilterAdd.Location = new System.Drawing.Point(30, 110);
            btFilterAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFilterAdd.Name = "btFilterAdd";
            btFilterAdd.Size = new System.Drawing.Size(64, 44);
            btFilterAdd.TabIndex = 11;
            btFilterAdd.Text = "Add";
            btFilterAdd.UseVisualStyleBackColor = true;
            btFilterAdd.Click += btFilterAdd_Click;
            // 
            // cbFilters
            // 
            cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilters.FormattingEnabled = true;
            cbFilters.Location = new System.Drawing.Point(30, 58);
            cbFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new System.Drawing.Size(431, 33);
            cbFilters.TabIndex = 10;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // label105
            // 
            label105.AutoSize = true;
            label105.Location = new System.Drawing.Point(24, 28);
            label105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label105.Name = "label105";
            label105.Size = new System.Drawing.Size(58, 25);
            label105.TabIndex = 9;
            label105.Text = "Filters";
            // 
            // tabPage82
            // 
            tabPage82.Controls.Add(label177);
            tabPage82.Controls.Add(label129);
            tabPage82.Controls.Add(btSubtitlesSelectFile);
            tabPage82.Controls.Add(edSubtitlesFilename);
            tabPage82.Controls.Add(label114);
            tabPage82.Controls.Add(cbSubtitlesEnabled);
            tabPage82.Location = new System.Drawing.Point(4, 34);
            tabPage82.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage82.Name = "tabPage82";
            tabPage82.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage82.Size = new System.Drawing.Size(489, 894);
            tabPage82.TabIndex = 7;
            tabPage82.Text = "Subtitles";
            tabPage82.UseVisualStyleBackColor = true;
            // 
            // label177
            // 
            label177.AutoSize = true;
            label177.Location = new System.Drawing.Point(18, 202);
            label177.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label177.Name = "label177";
            label177.Size = new System.Drawing.Size(136, 25);
            label177.TabIndex = 5;
            label177.Text = " using interface.";
            // 
            // label129
            // 
            label129.AutoSize = true;
            label129.Location = new System.Drawing.Point(18, 165);
            label129.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label129.Name = "label129";
            label129.Size = new System.Drawing.Size(406, 25);
            label129.TabIndex = 4;
            label129.Text = "Use OnSubtitleSettings event to set other settings";
            // 
            // btSubtitlesSelectFile
            // 
            btSubtitlesSelectFile.Location = new System.Drawing.Point(418, 108);
            btSubtitlesSelectFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSubtitlesSelectFile.Name = "btSubtitlesSelectFile";
            btSubtitlesSelectFile.Size = new System.Drawing.Size(38, 44);
            btSubtitlesSelectFile.TabIndex = 3;
            btSubtitlesSelectFile.Text = "...";
            btSubtitlesSelectFile.UseVisualStyleBackColor = true;
            btSubtitlesSelectFile.Click += btSubtitlesSelectFile_Click;
            // 
            // edSubtitlesFilename
            // 
            edSubtitlesFilename.Location = new System.Drawing.Point(23, 111);
            edSubtitlesFilename.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edSubtitlesFilename.Name = "edSubtitlesFilename";
            edSubtitlesFilename.Size = new System.Drawing.Size(384, 31);
            edSubtitlesFilename.TabIndex = 2;
            // 
            // label114
            // 
            label114.AutoSize = true;
            label114.Location = new System.Drawing.Point(18, 81);
            label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label114.Name = "label114";
            label114.Size = new System.Drawing.Size(87, 25);
            label114.TabIndex = 1;
            label114.Text = "File name";
            // 
            // cbSubtitlesEnabled
            // 
            cbSubtitlesEnabled.AutoSize = true;
            cbSubtitlesEnabled.Location = new System.Drawing.Point(23, 32);
            cbSubtitlesEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbSubtitlesEnabled.Name = "cbSubtitlesEnabled";
            cbSubtitlesEnabled.Size = new System.Drawing.Size(101, 29);
            cbSubtitlesEnabled.TabIndex = 0;
            cbSubtitlesEnabled.Text = "Enabled";
            cbSubtitlesEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage83
            // 
            tabPage83.Controls.Add(label8);
            tabPage83.Controls.Add(tbGPUBlur);
            tabPage83.Controls.Add(cbVideoEffectsGPUEnabled);
            tabPage83.Controls.Add(cbGPUOldMovie);
            tabPage83.Controls.Add(cbGPUDeinterlace);
            tabPage83.Controls.Add(cbGPUDenoise);
            tabPage83.Controls.Add(cbGPUPixelate);
            tabPage83.Controls.Add(cbGPUNightVision);
            tabPage83.Controls.Add(label383);
            tabPage83.Controls.Add(label384);
            tabPage83.Controls.Add(label385);
            tabPage83.Controls.Add(label386);
            tabPage83.Controls.Add(tbGPUContrast);
            tabPage83.Controls.Add(tbGPUDarkness);
            tabPage83.Controls.Add(tbGPULightness);
            tabPage83.Controls.Add(tbGPUSaturation);
            tabPage83.Controls.Add(cbGPUInvert);
            tabPage83.Controls.Add(cbGPUGreyscale);
            tabPage83.Location = new System.Drawing.Point(4, 34);
            tabPage83.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage83.Name = "tabPage83";
            tabPage83.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage83.Size = new System.Drawing.Size(489, 894);
            tabPage83.TabIndex = 8;
            tabPage83.Text = "GPU effects";
            tabPage83.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(20, 519);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(42, 25);
            label8.TabIndex = 100;
            label8.Text = "Blur";
            // 
            // tbGPUBlur
            // 
            tbGPUBlur.BackColor = System.Drawing.SystemColors.Window;
            tbGPUBlur.Location = new System.Drawing.Point(16, 550);
            tbGPUBlur.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUBlur.Maximum = 30;
            tbGPUBlur.Name = "tbGPUBlur";
            tbGPUBlur.Size = new System.Drawing.Size(217, 69);
            tbGPUBlur.TabIndex = 99;
            tbGPUBlur.Scroll += tbGPUBlur_Scroll;
            // 
            // cbVideoEffectsGPUEnabled
            // 
            cbVideoEffectsGPUEnabled.AutoSize = true;
            cbVideoEffectsGPUEnabled.Location = new System.Drawing.Point(27, 31);
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
            cbGPUOldMovie.Location = new System.Drawing.Point(238, 452);
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
            cbGPUDeinterlace.Location = new System.Drawing.Point(238, 406);
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
            cbGPUDenoise.Location = new System.Drawing.Point(24, 406);
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
            cbGPUPixelate.Location = new System.Drawing.Point(238, 361);
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
            cbGPUNightVision.Location = new System.Drawing.Point(24, 361);
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
            label383.Location = new System.Drawing.Point(247, 182);
            label383.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label383.Name = "label383";
            label383.Size = new System.Drawing.Size(84, 25);
            label383.TabIndex = 90;
            label383.Text = "Darkness";
            // 
            // label384
            // 
            label384.AutoSize = true;
            label384.Location = new System.Drawing.Point(20, 182);
            label384.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label384.Name = "label384";
            label384.Size = new System.Drawing.Size(79, 25);
            label384.TabIndex = 89;
            label384.Text = "Contrast";
            // 
            // label385
            // 
            label385.AutoSize = true;
            label385.Location = new System.Drawing.Point(247, 82);
            label385.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label385.Name = "label385";
            label385.Size = new System.Drawing.Size(93, 25);
            label385.TabIndex = 88;
            label385.Text = "Saturation";
            // 
            // label386
            // 
            label386.AutoSize = true;
            label386.Location = new System.Drawing.Point(20, 82);
            label386.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label386.Name = "label386";
            label386.Size = new System.Drawing.Size(86, 25);
            label386.TabIndex = 87;
            label386.Text = "Lightness";
            // 
            // tbGPUContrast
            // 
            tbGPUContrast.BackColor = System.Drawing.SystemColors.Window;
            tbGPUContrast.Location = new System.Drawing.Point(16, 219);
            tbGPUContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUContrast.Maximum = 255;
            tbGPUContrast.Name = "tbGPUContrast";
            tbGPUContrast.Size = new System.Drawing.Size(217, 69);
            tbGPUContrast.TabIndex = 86;
            tbGPUContrast.Value = 255;
            tbGPUContrast.Scroll += tbGPUContrast_Scroll;
            // 
            // tbGPUDarkness
            // 
            tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbGPUDarkness.Location = new System.Drawing.Point(247, 219);
            tbGPUDarkness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUDarkness.Maximum = 255;
            tbGPUDarkness.Name = "tbGPUDarkness";
            tbGPUDarkness.Size = new System.Drawing.Size(217, 69);
            tbGPUDarkness.TabIndex = 85;
            tbGPUDarkness.Scroll += tbGPUDarkness_Scroll;
            // 
            // tbGPULightness
            // 
            tbGPULightness.BackColor = System.Drawing.SystemColors.Window;
            tbGPULightness.Location = new System.Drawing.Point(16, 111);
            tbGPULightness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPULightness.Maximum = 255;
            tbGPULightness.Name = "tbGPULightness";
            tbGPULightness.Size = new System.Drawing.Size(217, 69);
            tbGPULightness.TabIndex = 84;
            tbGPULightness.Scroll += tbGPULightness_Scroll;
            // 
            // tbGPUSaturation
            // 
            tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbGPUSaturation.Location = new System.Drawing.Point(247, 111);
            tbGPUSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbGPUSaturation.Maximum = 255;
            tbGPUSaturation.Name = "tbGPUSaturation";
            tbGPUSaturation.Size = new System.Drawing.Size(217, 69);
            tbGPUSaturation.TabIndex = 83;
            tbGPUSaturation.Value = 255;
            tbGPUSaturation.Scroll += tbGPUSaturation_Scroll;
            // 
            // cbGPUInvert
            // 
            cbGPUInvert.AutoSize = true;
            cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUInvert.Location = new System.Drawing.Point(238, 318);
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
            cbGPUGreyscale.Location = new System.Drawing.Point(24, 318);
            cbGPUGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGPUGreyscale.Name = "cbGPUGreyscale";
            cbGPUGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGPUGreyscale.TabIndex = 81;
            cbGPUGreyscale.Text = "Greyscale";
            cbGPUGreyscale.UseVisualStyleBackColor = true;
            cbGPUGreyscale.CheckedChanged += cbGPUGreyscale_CheckedChanged;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(groupBox5);
            tabPage9.Controls.Add(lbTransitions);
            tabPage9.Controls.Add(label43);
            tabPage9.Location = new System.Drawing.Point(4, 34);
            tabPage9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage9.Size = new System.Drawing.Size(509, 962);
            tabPage9.TabIndex = 3;
            tabPage9.Text = "Transitions";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label47);
            groupBox5.Controls.Add(edTransStopTime);
            groupBox5.Controls.Add(label48);
            groupBox5.Controls.Add(label46);
            groupBox5.Controls.Add(edTransStartTime);
            groupBox5.Controls.Add(label45);
            groupBox5.Controls.Add(btAddTransition);
            groupBox5.Controls.Add(cbTransitionName);
            groupBox5.Controls.Add(label44);
            groupBox5.Location = new System.Drawing.Point(33, 236);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox5.Size = new System.Drawing.Size(418, 278);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Add transition";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new System.Drawing.Point(222, 211);
            label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(36, 25);
            label47.TabIndex = 8;
            label47.Text = "ms";
            // 
            // edTransStopTime
            // 
            edTransStopTime.Location = new System.Drawing.Point(140, 206);
            edTransStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTransStopTime.Name = "edTransStopTime";
            edTransStopTime.Size = new System.Drawing.Size(68, 31);
            edTransStopTime.TabIndex = 7;
            edTransStopTime.Text = "5000";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new System.Drawing.Point(20, 211);
            label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(89, 25);
            label48.TabIndex = 6;
            label48.Text = "Stop time";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new System.Drawing.Point(222, 161);
            label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(36, 25);
            label46.TabIndex = 5;
            label46.Text = "ms";
            // 
            // edTransStartTime
            // 
            edTransStartTime.Location = new System.Drawing.Point(140, 156);
            edTransStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTransStartTime.Name = "edTransStartTime";
            edTransStartTime.Size = new System.Drawing.Size(68, 31);
            edTransStartTime.TabIndex = 4;
            edTransStartTime.Text = "4000";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(20, 161);
            label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(88, 25);
            label45.TabIndex = 3;
            label45.Text = "Start time";
            // 
            // btAddTransition
            // 
            btAddTransition.Location = new System.Drawing.Point(338, 81);
            btAddTransition.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAddTransition.Name = "btAddTransition";
            btAddTransition.Size = new System.Drawing.Size(70, 44);
            btAddTransition.TabIndex = 2;
            btAddTransition.Text = "Add";
            btAddTransition.UseVisualStyleBackColor = true;
            btAddTransition.Click += btAddTransition_Click;
            // 
            // cbTransitionName
            // 
            cbTransitionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTransitionName.FormattingEnabled = true;
            cbTransitionName.Location = new System.Drawing.Point(24, 85);
            cbTransitionName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbTransitionName.Name = "cbTransitionName";
            cbTransitionName.Size = new System.Drawing.Size(301, 33);
            cbTransitionName.TabIndex = 1;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(20, 54);
            label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(59, 25);
            label44.TabIndex = 0;
            label44.Text = "Name";
            // 
            // lbTransitions
            // 
            lbTransitions.FormattingEnabled = true;
            lbTransitions.ItemHeight = 25;
            lbTransitions.Location = new System.Drawing.Point(33, 68);
            lbTransitions.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbTransitions.Name = "lbTransitions";
            lbTransitions.Size = new System.Drawing.Size(415, 154);
            lbTransitions.TabIndex = 1;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new System.Drawing.Point(29, 36);
            label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(78, 25);
            label43.TabIndex = 0;
            label43.Text = "Selected";
            // 
            // tabPage66
            // 
            tabPage66.Controls.Add(lbAudioTimeshift);
            tabPage66.Controls.Add(tbAudioTimeshift);
            tabPage66.Controls.Add(label115);
            tabPage66.Controls.Add(groupBox1);
            tabPage66.Controls.Add(groupBox2);
            tabPage66.Controls.Add(cbAudioAutoGain);
            tabPage66.Controls.Add(cbAudioNormalize);
            tabPage66.Controls.Add(cbAudioEnhancementEnabled);
            tabPage66.Location = new System.Drawing.Point(4, 34);
            tabPage66.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage66.Name = "tabPage66";
            tabPage66.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage66.Size = new System.Drawing.Size(509, 962);
            tabPage66.TabIndex = 13;
            tabPage66.Text = "Audio enhancement";
            tabPage66.UseVisualStyleBackColor = true;
            // 
            // lbAudioTimeshift
            // 
            lbAudioTimeshift.AutoSize = true;
            lbAudioTimeshift.Location = new System.Drawing.Point(290, 868);
            lbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioTimeshift.Name = "lbAudioTimeshift";
            lbAudioTimeshift.Size = new System.Drawing.Size(51, 25);
            lbAudioTimeshift.TabIndex = 12;
            lbAudioTimeshift.Text = "0 ms";
            // 
            // tbAudioTimeshift
            // 
            tbAudioTimeshift.Location = new System.Drawing.Point(107, 846);
            tbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioTimeshift.Maximum = 3000;
            tbAudioTimeshift.Name = "tbAudioTimeshift";
            tbAudioTimeshift.Size = new System.Drawing.Size(173, 69);
            tbAudioTimeshift.SmallChange = 10;
            tbAudioTimeshift.TabIndex = 11;
            tbAudioTimeshift.TickFrequency = 100;
            tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioTimeshift.Scroll += tbAudioTimeshift_Scroll;
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Location = new System.Drawing.Point(4, 868);
            label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label115.Name = "label115";
            label115.Size = new System.Drawing.Size(89, 25);
            label115.TabIndex = 10;
            label115.Text = "Time shift";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbAudioOutputGainLFE);
            groupBox1.Controls.Add(tbAudioOutputGainLFE);
            groupBox1.Controls.Add(label116);
            groupBox1.Controls.Add(lbAudioOutputGainSR);
            groupBox1.Controls.Add(tbAudioOutputGainSR);
            groupBox1.Controls.Add(label117);
            groupBox1.Controls.Add(lbAudioOutputGainSL);
            groupBox1.Controls.Add(tbAudioOutputGainSL);
            groupBox1.Controls.Add(label118);
            groupBox1.Controls.Add(lbAudioOutputGainR);
            groupBox1.Controls.Add(tbAudioOutputGainR);
            groupBox1.Controls.Add(label119);
            groupBox1.Controls.Add(lbAudioOutputGainC);
            groupBox1.Controls.Add(tbAudioOutputGainC);
            groupBox1.Controls.Add(label121);
            groupBox1.Controls.Add(lbAudioOutputGainL);
            groupBox1.Controls.Add(tbAudioOutputGainL);
            groupBox1.Controls.Add(label122);
            groupBox1.Location = new System.Drawing.Point(10, 500);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Size = new System.Drawing.Size(482, 331);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Output gains (dB)";
            // 
            // lbAudioOutputGainLFE
            // 
            lbAudioOutputGainLFE.AutoSize = true;
            lbAudioOutputGainLFE.Location = new System.Drawing.Point(416, 285);
            lbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE";
            lbAudioOutputGainLFE.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainLFE.TabIndex = 17;
            lbAudioOutputGainLFE.Text = "0.0";
            // 
            // tbAudioOutputGainLFE
            // 
            tbAudioOutputGainLFE.Location = new System.Drawing.Point(403, 79);
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
            // label116
            // 
            label116.AutoSize = true;
            label116.Location = new System.Drawing.Point(417, 48);
            label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label116.Name = "label116";
            label116.Size = new System.Drawing.Size(38, 25);
            label116.TabIndex = 15;
            label116.Text = "LFE";
            // 
            // lbAudioOutputGainSR
            // 
            lbAudioOutputGainSR.AutoSize = true;
            lbAudioOutputGainSR.Location = new System.Drawing.Point(336, 285);
            lbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainSR.Name = "lbAudioOutputGainSR";
            lbAudioOutputGainSR.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainSR.TabIndex = 14;
            lbAudioOutputGainSR.Text = "0.0";
            // 
            // tbAudioOutputGainSR
            // 
            tbAudioOutputGainSR.Location = new System.Drawing.Point(323, 79);
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
            // label117
            // 
            label117.AutoSize = true;
            label117.Location = new System.Drawing.Point(342, 48);
            label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label117.Name = "label117";
            label117.Size = new System.Drawing.Size(33, 25);
            label117.TabIndex = 12;
            label117.Text = "SR";
            // 
            // lbAudioOutputGainSL
            // 
            lbAudioOutputGainSL.AutoSize = true;
            lbAudioOutputGainSL.Location = new System.Drawing.Point(256, 285);
            lbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainSL.Name = "lbAudioOutputGainSL";
            lbAudioOutputGainSL.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainSL.TabIndex = 11;
            lbAudioOutputGainSL.Text = "0.0";
            // 
            // tbAudioOutputGainSL
            // 
            tbAudioOutputGainSL.Location = new System.Drawing.Point(243, 79);
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
            // label118
            // 
            label118.AutoSize = true;
            label118.Location = new System.Drawing.Point(263, 48);
            label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label118.Name = "label118";
            label118.Size = new System.Drawing.Size(30, 25);
            label118.TabIndex = 9;
            label118.Text = "SL";
            // 
            // lbAudioOutputGainR
            // 
            lbAudioOutputGainR.AutoSize = true;
            lbAudioOutputGainR.Location = new System.Drawing.Point(176, 285);
            lbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainR.Name = "lbAudioOutputGainR";
            lbAudioOutputGainR.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainR.TabIndex = 8;
            lbAudioOutputGainR.Text = "0.0";
            // 
            // tbAudioOutputGainR
            // 
            tbAudioOutputGainR.Location = new System.Drawing.Point(163, 79);
            tbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioOutputGainR.Maximum = 200;
            tbAudioOutputGainR.Minimum = -200;
            tbAudioOutputGainR.Name = "tbAudioOutputGainR";
            tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainR.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainR.TabIndex = 7;
            tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Location = new System.Drawing.Point(190, 48);
            label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label119.Name = "label119";
            label119.Size = new System.Drawing.Size(23, 25);
            label119.TabIndex = 6;
            label119.Text = "R";
            // 
            // lbAudioOutputGainC
            // 
            lbAudioOutputGainC.AutoSize = true;
            lbAudioOutputGainC.Location = new System.Drawing.Point(96, 285);
            lbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainC.Name = "lbAudioOutputGainC";
            lbAudioOutputGainC.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainC.TabIndex = 5;
            lbAudioOutputGainC.Text = "0.0";
            // 
            // tbAudioOutputGainC
            // 
            tbAudioOutputGainC.Location = new System.Drawing.Point(83, 79);
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
            // label121
            // 
            label121.AutoSize = true;
            label121.Location = new System.Drawing.Point(110, 48);
            label121.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label121.Name = "label121";
            label121.Size = new System.Drawing.Size(23, 25);
            label121.TabIndex = 3;
            label121.Text = "C";
            // 
            // lbAudioOutputGainL
            // 
            lbAudioOutputGainL.AutoSize = true;
            lbAudioOutputGainL.Location = new System.Drawing.Point(16, 285);
            lbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioOutputGainL.Name = "lbAudioOutputGainL";
            lbAudioOutputGainL.Size = new System.Drawing.Size(36, 25);
            lbAudioOutputGainL.TabIndex = 2;
            lbAudioOutputGainL.Text = "0.0";
            // 
            // tbAudioOutputGainL
            // 
            tbAudioOutputGainL.Location = new System.Drawing.Point(3, 79);
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
            // label122
            // 
            label122.AutoSize = true;
            label122.Location = new System.Drawing.Point(30, 48);
            label122.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label122.Name = "label122";
            label122.Size = new System.Drawing.Size(20, 25);
            label122.TabIndex = 0;
            label122.Text = "L";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbAudioInputGainLFE);
            groupBox2.Controls.Add(tbAudioInputGainLFE);
            groupBox2.Controls.Add(label123);
            groupBox2.Controls.Add(lbAudioInputGainSR);
            groupBox2.Controls.Add(tbAudioInputGainSR);
            groupBox2.Controls.Add(label124);
            groupBox2.Controls.Add(lbAudioInputGainSL);
            groupBox2.Controls.Add(tbAudioInputGainSL);
            groupBox2.Controls.Add(label125);
            groupBox2.Controls.Add(lbAudioInputGainR);
            groupBox2.Controls.Add(tbAudioInputGainR);
            groupBox2.Controls.Add(label126);
            groupBox2.Controls.Add(lbAudioInputGainC);
            groupBox2.Controls.Add(tbAudioInputGainC);
            groupBox2.Controls.Add(label127);
            groupBox2.Controls.Add(lbAudioInputGainL);
            groupBox2.Controls.Add(tbAudioInputGainL);
            groupBox2.Controls.Add(label128);
            groupBox2.Location = new System.Drawing.Point(10, 158);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Size = new System.Drawing.Size(482, 331);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Input gains (dB)";
            // 
            // lbAudioInputGainLFE
            // 
            lbAudioInputGainLFE.AutoSize = true;
            lbAudioInputGainLFE.Location = new System.Drawing.Point(416, 285);
            lbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainLFE.Name = "lbAudioInputGainLFE";
            lbAudioInputGainLFE.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainLFE.TabIndex = 17;
            lbAudioInputGainLFE.Text = "0.0";
            // 
            // tbAudioInputGainLFE
            // 
            tbAudioInputGainLFE.Location = new System.Drawing.Point(403, 79);
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
            // label123
            // 
            label123.AutoSize = true;
            label123.Location = new System.Drawing.Point(417, 48);
            label123.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label123.Name = "label123";
            label123.Size = new System.Drawing.Size(38, 25);
            label123.TabIndex = 15;
            label123.Text = "LFE";
            // 
            // lbAudioInputGainSR
            // 
            lbAudioInputGainSR.AutoSize = true;
            lbAudioInputGainSR.Location = new System.Drawing.Point(336, 285);
            lbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainSR.Name = "lbAudioInputGainSR";
            lbAudioInputGainSR.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainSR.TabIndex = 14;
            lbAudioInputGainSR.Text = "0.0";
            // 
            // tbAudioInputGainSR
            // 
            tbAudioInputGainSR.Location = new System.Drawing.Point(323, 79);
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
            // label124
            // 
            label124.AutoSize = true;
            label124.Location = new System.Drawing.Point(342, 48);
            label124.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label124.Name = "label124";
            label124.Size = new System.Drawing.Size(33, 25);
            label124.TabIndex = 12;
            label124.Text = "SR";
            // 
            // lbAudioInputGainSL
            // 
            lbAudioInputGainSL.AutoSize = true;
            lbAudioInputGainSL.Location = new System.Drawing.Point(256, 285);
            lbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainSL.Name = "lbAudioInputGainSL";
            lbAudioInputGainSL.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainSL.TabIndex = 11;
            lbAudioInputGainSL.Text = "0.0";
            // 
            // tbAudioInputGainSL
            // 
            tbAudioInputGainSL.Location = new System.Drawing.Point(243, 79);
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
            // label125
            // 
            label125.AutoSize = true;
            label125.Location = new System.Drawing.Point(263, 48);
            label125.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label125.Name = "label125";
            label125.Size = new System.Drawing.Size(30, 25);
            label125.TabIndex = 9;
            label125.Text = "SL";
            // 
            // lbAudioInputGainR
            // 
            lbAudioInputGainR.AutoSize = true;
            lbAudioInputGainR.Location = new System.Drawing.Point(176, 285);
            lbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainR.Name = "lbAudioInputGainR";
            lbAudioInputGainR.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainR.TabIndex = 8;
            lbAudioInputGainR.Text = "0.0";
            // 
            // tbAudioInputGainR
            // 
            tbAudioInputGainR.Location = new System.Drawing.Point(163, 79);
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
            // label126
            // 
            label126.AutoSize = true;
            label126.Location = new System.Drawing.Point(190, 48);
            label126.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label126.Name = "label126";
            label126.Size = new System.Drawing.Size(23, 25);
            label126.TabIndex = 6;
            label126.Text = "R";
            // 
            // lbAudioInputGainC
            // 
            lbAudioInputGainC.AutoSize = true;
            lbAudioInputGainC.Location = new System.Drawing.Point(96, 285);
            lbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainC.Name = "lbAudioInputGainC";
            lbAudioInputGainC.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainC.TabIndex = 5;
            lbAudioInputGainC.Text = "0.0";
            // 
            // tbAudioInputGainC
            // 
            tbAudioInputGainC.Location = new System.Drawing.Point(83, 79);
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
            // label127
            // 
            label127.AutoSize = true;
            label127.Location = new System.Drawing.Point(110, 48);
            label127.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label127.Name = "label127";
            label127.Size = new System.Drawing.Size(23, 25);
            label127.TabIndex = 3;
            label127.Text = "C";
            // 
            // lbAudioInputGainL
            // 
            lbAudioInputGainL.AutoSize = true;
            lbAudioInputGainL.Location = new System.Drawing.Point(16, 285);
            lbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioInputGainL.Name = "lbAudioInputGainL";
            lbAudioInputGainL.Size = new System.Drawing.Size(36, 25);
            lbAudioInputGainL.TabIndex = 2;
            lbAudioInputGainL.Text = "0.0";
            // 
            // tbAudioInputGainL
            // 
            tbAudioInputGainL.Location = new System.Drawing.Point(3, 79);
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
            // label128
            // 
            label128.AutoSize = true;
            label128.Location = new System.Drawing.Point(30, 48);
            label128.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label128.Name = "label128";
            label128.Size = new System.Drawing.Size(20, 25);
            label128.TabIndex = 0;
            label128.Text = "L";
            // 
            // cbAudioAutoGain
            // 
            cbAudioAutoGain.AutoSize = true;
            cbAudioAutoGain.Location = new System.Drawing.Point(222, 92);
            cbAudioAutoGain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioAutoGain.Name = "cbAudioAutoGain";
            cbAudioAutoGain.Size = new System.Drawing.Size(116, 29);
            cbAudioAutoGain.TabIndex = 5;
            cbAudioAutoGain.Text = "Auto gain";
            cbAudioAutoGain.UseVisualStyleBackColor = true;
            cbAudioAutoGain.CheckedChanged += cbAudioAutoGain_CheckedChanged;
            // 
            // cbAudioNormalize
            // 
            cbAudioNormalize.AutoSize = true;
            cbAudioNormalize.Location = new System.Drawing.Point(64, 92);
            cbAudioNormalize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioNormalize.Name = "cbAudioNormalize";
            cbAudioNormalize.Size = new System.Drawing.Size(118, 29);
            cbAudioNormalize.TabIndex = 4;
            cbAudioNormalize.Text = "Normalize";
            cbAudioNormalize.UseVisualStyleBackColor = true;
            cbAudioNormalize.CheckedChanged += cbAudioNormalize_CheckedChanged;
            // 
            // cbAudioEnhancementEnabled
            // 
            cbAudioEnhancementEnabled.AutoSize = true;
            cbAudioEnhancementEnabled.Location = new System.Drawing.Point(27, 31);
            cbAudioEnhancementEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled";
            cbAudioEnhancementEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEnhancementEnabled.TabIndex = 3;
            cbAudioEnhancementEnabled.Text = "Enabled";
            cbAudioEnhancementEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label133);
            tabPage3.Controls.Add(tabControl18);
            tabPage3.Controls.Add(cbAudioEffectsEnabled);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Size = new System.Drawing.Size(509, 962);
            tabPage3.TabIndex = 5;
            tabPage3.Text = "Audio effects";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label133
            // 
            label133.AutoSize = true;
            label133.Location = new System.Drawing.Point(169, 31);
            label133.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label133.Name = "label133";
            label133.Size = new System.Drawing.Size(313, 25);
            label133.TabIndex = 4;
            label133.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            tabControl18.Controls.Add(tabPage71);
            tabControl18.Controls.Add(tabPage72);
            tabControl18.Controls.Add(tabPage73);
            tabControl18.Controls.Add(tabPage75);
            tabControl18.Controls.Add(tabPage76);
            tabControl18.Controls.Add(tabPage16);
            tabControl18.Location = new System.Drawing.Point(17, 72);
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
            label230.Location = new System.Drawing.Point(113, 102);
            label230.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label230.Name = "label230";
            label230.Size = new System.Drawing.Size(57, 25);
            label230.TabIndex = 4;
            label230.Text = "100%";
            // 
            // tbAudAmplifyAmp
            // 
            tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            tbAudAmplifyAmp.Location = new System.Drawing.Point(27, 132);
            tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudAmplifyAmp.Maximum = 4000;
            tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            tbAudAmplifyAmp.Size = new System.Drawing.Size(383, 69);
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
            cbAudAmplifyEnabled.Location = new System.Drawing.Point(27, 31);
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
            btAudEqRefresh.Location = new System.Drawing.Point(291, 421);
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
            cbAudEqualizerPreset.Location = new System.Drawing.Point(102, 346);
            cbAudEqualizerPreset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudEqualizerPreset.Name = "cbAudEqualizerPreset";
            cbAudEqualizerPreset.Size = new System.Drawing.Size(313, 33);
            cbAudEqualizerPreset.TabIndex = 25;
            cbAudEqualizerPreset.SelectedIndexChanged += cbAudEqualizerPreset_SelectedIndexChanged;
            // 
            // label243
            // 
            label243.AutoSize = true;
            label243.Location = new System.Drawing.Point(23, 352);
            label243.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label243.Name = "label243";
            label243.Size = new System.Drawing.Size(60, 25);
            label243.TabIndex = 24;
            label243.Text = "Preset";
            // 
            // label242
            // 
            label242.AutoSize = true;
            label242.Location = new System.Drawing.Point(343, 300);
            label242.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label242.Name = "label242";
            label242.Size = new System.Drawing.Size(42, 25);
            label242.TabIndex = 23;
            label242.Text = "16K";
            // 
            // label241
            // 
            label241.AutoSize = true;
            label241.Location = new System.Drawing.Point(307, 300);
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
            label236.Location = new System.Drawing.Point(133, 300);
            label236.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label236.Name = "label236";
            label236.Size = new System.Drawing.Size(42, 25);
            label236.TabIndex = 17;
            label236.Text = "600";
            // 
            // label235
            // 
            label235.AutoSize = true;
            label235.Location = new System.Drawing.Point(97, 300);
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
            label232.Location = new System.Drawing.Point(197, 64);
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
            tbAudEq8.Location = new System.Drawing.Point(307, 94);
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
            tbAudEq4.Location = new System.Drawing.Point(167, 94);
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
            tbAudEq2.Location = new System.Drawing.Point(97, 94);
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
            cbAudEqualizerEnabled.Location = new System.Drawing.Point(27, 31);
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
            tbAudRelease.Location = new System.Drawing.Point(27, 402);
            tbAudRelease.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudRelease.Maximum = 10000;
            tbAudRelease.Minimum = 10;
            tbAudRelease.Name = "tbAudRelease";
            tbAudRelease.Size = new System.Drawing.Size(383, 69);
            tbAudRelease.TabIndex = 15;
            tbAudRelease.TickFrequency = 250;
            tbAudRelease.Value = 10;
            tbAudRelease.Scroll += tbAudRelease_Scroll;
            // 
            // label248
            // 
            label248.AutoSize = true;
            label248.Location = new System.Drawing.Point(389, 371);
            label248.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label248.Name = "label248";
            label248.Size = new System.Drawing.Size(22, 25);
            label248.TabIndex = 14;
            label248.Text = "0";
            // 
            // label249
            // 
            label249.AutoSize = true;
            label249.Location = new System.Drawing.Point(22, 371);
            label249.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label249.Name = "label249";
            label249.Size = new System.Drawing.Size(110, 25);
            label249.TabIndex = 12;
            label249.Text = "Release time";
            // 
            // label246
            // 
            label246.AutoSize = true;
            label246.Location = new System.Drawing.Point(389, 232);
            label246.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label246.Name = "label246";
            label246.Size = new System.Drawing.Size(22, 25);
            label246.TabIndex = 11;
            label246.Text = "0";
            // 
            // tbAudAttack
            // 
            tbAudAttack.BackColor = System.Drawing.SystemColors.Window;
            tbAudAttack.Location = new System.Drawing.Point(27, 264);
            tbAudAttack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudAttack.Maximum = 10000;
            tbAudAttack.Minimum = 10;
            tbAudAttack.Name = "tbAudAttack";
            tbAudAttack.Size = new System.Drawing.Size(383, 69);
            tbAudAttack.TabIndex = 10;
            tbAudAttack.TickFrequency = 250;
            tbAudAttack.Value = 10;
            tbAudAttack.Scroll += tbAudAttack_Scroll;
            // 
            // label247
            // 
            label247.AutoSize = true;
            label247.Location = new System.Drawing.Point(22, 232);
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
            label244.Size = new System.Drawing.Size(22, 25);
            label244.TabIndex = 8;
            label244.Text = "0";
            // 
            // tbAudDynAmp
            // 
            tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window;
            tbAudDynAmp.Location = new System.Drawing.Point(27, 132);
            tbAudDynAmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudDynAmp.Maximum = 2000;
            tbAudDynAmp.Minimum = 100;
            tbAudDynAmp.Name = "tbAudDynAmp";
            tbAudDynAmp.Size = new System.Drawing.Size(383, 69);
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
            cbAudDynamicAmplifyEnabled.Location = new System.Drawing.Point(27, 31);
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
            tbAud3DSound.Location = new System.Drawing.Point(27, 132);
            tbAud3DSound.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAud3DSound.Maximum = 10000;
            tbAud3DSound.Name = "tbAud3DSound";
            tbAud3DSound.Size = new System.Drawing.Size(383, 69);
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
            cbAudSound3DEnabled.Location = new System.Drawing.Point(27, 31);
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
            tbAudTrueBass.Location = new System.Drawing.Point(27, 132);
            tbAudTrueBass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudTrueBass.Maximum = 10000;
            tbAudTrueBass.Name = "tbAudTrueBass";
            tbAudTrueBass.Size = new System.Drawing.Size(383, 69);
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
            cbAudTrueBassEnabled.Location = new System.Drawing.Point(27, 31);
            cbAudTrueBassEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled";
            cbAudTrueBassEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudTrueBassEnabled.TabIndex = 2;
            cbAudTrueBassEnabled.Text = "Enabled";
            cbAudTrueBassEnabled.UseVisualStyleBackColor = true;
            cbAudTrueBassEnabled.CheckedChanged += cbAudTrueBassEnabled_CheckedChanged;
            // 
            // tabPage16
            // 
            tabPage16.Controls.Add(cbFadeOutEnabled);
            tabPage16.Controls.Add(label4);
            tabPage16.Controls.Add(edFadeOutStopTime);
            tabPage16.Controls.Add(label5);
            tabPage16.Controls.Add(label6);
            tabPage16.Controls.Add(edFadeOutStartTime);
            tabPage16.Controls.Add(label7);
            tabPage16.Controls.Add(cbFadeInEnabled);
            tabPage16.Controls.Add(label19);
            tabPage16.Controls.Add(edFadeInStopTime);
            tabPage16.Controls.Add(label20);
            tabPage16.Controls.Add(label18);
            tabPage16.Controls.Add(edFadeInStartTime);
            tabPage16.Controls.Add(label17);
            tabPage16.Location = new System.Drawing.Point(4, 34);
            tabPage16.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage16.Name = "tabPage16";
            tabPage16.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage16.Size = new System.Drawing.Size(463, 812);
            tabPage16.TabIndex = 6;
            tabPage16.Text = "Fade-In/Fade-Out";
            tabPage16.UseVisualStyleBackColor = true;
            // 
            // cbFadeOutEnabled
            // 
            cbFadeOutEnabled.AutoSize = true;
            cbFadeOutEnabled.Location = new System.Drawing.Point(27, 215);
            cbFadeOutEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFadeOutEnabled.Name = "cbFadeOutEnabled";
            cbFadeOutEnabled.Size = new System.Drawing.Size(109, 29);
            cbFadeOutEnabled.TabIndex = 13;
            cbFadeOutEnabled.Text = "Fade-out";
            cbFadeOutEnabled.UseVisualStyleBackColor = true;
            cbFadeOutEnabled.CheckedChanged += cbFadeOutEnabled_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(240, 321);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(36, 25);
            label4.TabIndex = 12;
            label4.Text = "ms";
            // 
            // edFadeOutStopTime
            // 
            edFadeOutStopTime.Location = new System.Drawing.Point(150, 315);
            edFadeOutStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeOutStopTime.Name = "edFadeOutStopTime";
            edFadeOutStopTime.Size = new System.Drawing.Size(77, 31);
            edFadeOutStopTime.TabIndex = 11;
            edFadeOutStopTime.Text = "5000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(42, 321);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 25);
            label5.TabIndex = 10;
            label5.Text = "Stop time";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(240, 271);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 25);
            label6.TabIndex = 9;
            label6.Text = "ms";
            // 
            // edFadeOutStartTime
            // 
            edFadeOutStartTime.Location = new System.Drawing.Point(150, 265);
            edFadeOutStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeOutStartTime.Name = "edFadeOutStartTime";
            edFadeOutStartTime.Size = new System.Drawing.Size(77, 31);
            edFadeOutStartTime.TabIndex = 8;
            edFadeOutStartTime.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(42, 271);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(88, 25);
            label7.TabIndex = 7;
            label7.Text = "Start time";
            // 
            // cbFadeInEnabled
            // 
            cbFadeInEnabled.AutoSize = true;
            cbFadeInEnabled.Location = new System.Drawing.Point(27, 31);
            cbFadeInEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFadeInEnabled.Name = "cbFadeInEnabled";
            cbFadeInEnabled.Size = new System.Drawing.Size(96, 29);
            cbFadeInEnabled.TabIndex = 6;
            cbFadeInEnabled.Text = "Fade-in";
            cbFadeInEnabled.UseVisualStyleBackColor = true;
            cbFadeInEnabled.CheckedChanged += cbFadeInEnabled_CheckedChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(240, 136);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(36, 25);
            label19.TabIndex = 5;
            label19.Text = "ms";
            // 
            // edFadeInStopTime
            // 
            edFadeInStopTime.Location = new System.Drawing.Point(150, 131);
            edFadeInStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeInStopTime.Name = "edFadeInStopTime";
            edFadeInStopTime.Size = new System.Drawing.Size(77, 31);
            edFadeInStopTime.TabIndex = 4;
            edFadeInStopTime.Text = "5000";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(42, 136);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(89, 25);
            label20.TabIndex = 3;
            label20.Text = "Stop time";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(240, 86);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(36, 25);
            label18.TabIndex = 2;
            label18.Text = "ms";
            // 
            // edFadeInStartTime
            // 
            edFadeInStartTime.Location = new System.Drawing.Point(150, 81);
            edFadeInStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFadeInStartTime.Name = "edFadeInStartTime";
            edFadeInStartTime.Size = new System.Drawing.Size(77, 31);
            edFadeInStartTime.TabIndex = 1;
            edFadeInStartTime.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(42, 86);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(88, 25);
            label17.TabIndex = 0;
            label17.Text = "Start time";
            // 
            // cbAudioEffectsEnabled
            // 
            cbAudioEffectsEnabled.AutoSize = true;
            cbAudioEffectsEnabled.Location = new System.Drawing.Point(17, 29);
            cbAudioEffectsEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            cbAudioEffectsEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEffectsEnabled.TabIndex = 2;
            cbAudioEffectsEnabled.Text = "Enabled";
            cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage81
            // 
            tabPage81.Controls.Add(btAudioChannelMapperClear);
            tabPage81.Controls.Add(groupBox41);
            tabPage81.Controls.Add(label307);
            tabPage81.Controls.Add(edAudioChannelMapperOutputChannels);
            tabPage81.Controls.Add(label306);
            tabPage81.Controls.Add(lbAudioChannelMapperRoutes);
            tabPage81.Controls.Add(cbAudioChannelMapperEnabled);
            tabPage81.Location = new System.Drawing.Point(4, 34);
            tabPage81.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage81.Name = "tabPage81";
            tabPage81.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage81.Size = new System.Drawing.Size(509, 962);
            tabPage81.TabIndex = 15;
            tabPage81.Text = "Audio channel mapper";
            tabPage81.UseVisualStyleBackColor = true;
            // 
            // btAudioChannelMapperClear
            // 
            btAudioChannelMapperClear.Location = new System.Drawing.Point(344, 432);
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
            groupBox41.Location = new System.Drawing.Point(7, 489);
            groupBox41.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox41.Name = "groupBox41";
            groupBox41.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox41.Size = new System.Drawing.Size(487, 329);
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
            label311.Location = new System.Drawing.Point(342, 171);
            label311.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label311.Name = "label311";
            label311.Size = new System.Drawing.Size(109, 25);
            label311.TabIndex = 19;
            label311.Text = "10% - 200%";
            // 
            // tbAudioChannelMapperVolume
            // 
            tbAudioChannelMapperVolume.Location = new System.Drawing.Point(347, 79);
            tbAudioChannelMapperVolume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbAudioChannelMapperVolume.Maximum = 2000;
            tbAudioChannelMapperVolume.Minimum = 100;
            tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume";
            tbAudioChannelMapperVolume.Size = new System.Drawing.Size(123, 69);
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
            edAudioChannelMapperTargetChannel.Location = new System.Drawing.Point(180, 79);
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
            edAudioChannelMapperSourceChannel.Location = new System.Drawing.Point(24, 79);
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
            label307.Location = new System.Drawing.Point(20, 204);
            label307.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label307.Name = "label307";
            label307.Size = new System.Drawing.Size(66, 25);
            label307.TabIndex = 19;
            label307.Text = "Routes";
            // 
            // edAudioChannelMapperOutputChannels
            // 
            edAudioChannelMapperOutputChannels.Location = new System.Drawing.Point(24, 129);
            edAudioChannelMapperOutputChannels.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels";
            edAudioChannelMapperOutputChannels.Size = new System.Drawing.Size(67, 31);
            edAudioChannelMapperOutputChannels.TabIndex = 18;
            edAudioChannelMapperOutputChannels.Text = "0";
            // 
            // label306
            // 
            label306.AutoSize = true;
            label306.Location = new System.Drawing.Point(20, 98);
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
            lbAudioChannelMapperRoutes.Location = new System.Drawing.Point(24, 239);
            lbAudioChannelMapperRoutes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes";
            lbAudioChannelMapperRoutes.Size = new System.Drawing.Size(442, 179);
            lbAudioChannelMapperRoutes.TabIndex = 16;
            // 
            // cbAudioChannelMapperEnabled
            // 
            cbAudioChannelMapperEnabled.AutoSize = true;
            cbAudioChannelMapperEnabled.Location = new System.Drawing.Point(24, 32);
            cbAudioChannelMapperEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled";
            cbAudioChannelMapperEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioChannelMapperEnabled.TabIndex = 15;
            cbAudioChannelMapperEnabled.Text = "Enabled";
            cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage27
            // 
            tabPage27.Controls.Add(tabControl9);
            tabPage27.Controls.Add(cbMotDetEnabled);
            tabPage27.Location = new System.Drawing.Point(4, 34);
            tabPage27.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage27.Name = "tabPage27";
            tabPage27.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage27.Size = new System.Drawing.Size(509, 962);
            tabPage27.TabIndex = 7;
            tabPage27.Text = "Motion detection";
            tabPage27.UseVisualStyleBackColor = true;
            // 
            // tabControl9
            // 
            tabControl9.Controls.Add(tabPage44);
            tabControl9.Controls.Add(tabPage45);
            tabControl9.Location = new System.Drawing.Point(23, 82);
            tabControl9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl9.Name = "tabControl9";
            tabControl9.SelectedIndex = 0;
            tabControl9.Size = new System.Drawing.Size(447, 794);
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
            tabPage44.Size = new System.Drawing.Size(439, 756);
            tabPage44.TabIndex = 0;
            tabPage44.Text = "Output matrix";
            tabPage44.UseVisualStyleBackColor = true;
            // 
            // pbMotionLevel
            // 
            pbMotionLevel.Location = new System.Drawing.Point(31, 611);
            pbMotionLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbMotionLevel.Name = "pbMotionLevel";
            pbMotionLevel.Size = new System.Drawing.Size(376, 36);
            pbMotionLevel.TabIndex = 2;
            // 
            // label158
            // 
            label158.AutoSize = true;
            label158.Location = new System.Drawing.Point(27, 572);
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
            mmMotDetMatrix.Size = new System.Drawing.Size(411, 475);
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
            tabPage45.Size = new System.Drawing.Size(439, 756);
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
            groupBox25.Size = new System.Drawing.Size(389, 165);
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
            label161.Location = new System.Drawing.Point(247, 81);
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
            cbMotDetHLEnabled.Location = new System.Drawing.Point(23, 42);
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
            tbMotDetHLThreshold.Size = new System.Drawing.Size(173, 69);
            tbMotDetHLThreshold.TabIndex = 3;
            tbMotDetHLThreshold.TickFrequency = 5;
            tbMotDetHLThreshold.Value = 25;
            // 
            // btMotDetUpdateSettings
            // 
            btMotDetUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            edMotDetMatrixHeight.Size = new System.Drawing.Size(57, 31);
            edMotDetMatrixHeight.TabIndex = 75;
            edMotDetMatrixHeight.Text = "10";
            // 
            // label163
            // 
            label163.AutoSize = true;
            label163.Location = new System.Drawing.Point(163, 50);
            label163.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label163.Name = "label163";
            label163.Size = new System.Drawing.Size(65, 25);
            label163.TabIndex = 74;
            label163.Text = "Height";
            // 
            // edMotDetMatrixWidth
            // 
            edMotDetMatrixWidth.Location = new System.Drawing.Point(93, 44);
            edMotDetMatrixWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMotDetMatrixWidth.Name = "edMotDetMatrixWidth";
            edMotDetMatrixWidth.Size = new System.Drawing.Size(57, 31);
            edMotDetMatrixWidth.TabIndex = 73;
            edMotDetMatrixWidth.Text = "10";
            // 
            // label164
            // 
            label164.AutoSize = true;
            label164.Location = new System.Drawing.Point(23, 50);
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
            groupBox26.Location = new System.Drawing.Point(20, 368);
            groupBox26.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox26.Name = "groupBox26";
            groupBox26.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox26.Size = new System.Drawing.Size(389, 132);
            groupBox26.TabIndex = 2;
            groupBox26.TabStop = false;
            groupBox26.Text = "Drop frames";
            // 
            // label162
            // 
            label162.AutoSize = true;
            label162.Location = new System.Drawing.Point(157, 40);
            label162.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label162.Name = "label162";
            label162.Size = new System.Drawing.Size(90, 25);
            label162.TabIndex = 4;
            label162.Text = "Threshold";
            // 
            // tbMotDetDropFramesThreshold
            // 
            tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window;
            tbMotDetDropFramesThreshold.Location = new System.Drawing.Point(158, 71);
            tbMotDetDropFramesThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbMotDetDropFramesThreshold.Maximum = 255;
            tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold";
            tbMotDetDropFramesThreshold.Size = new System.Drawing.Size(173, 69);
            tbMotDetDropFramesThreshold.TabIndex = 5;
            tbMotDetDropFramesThreshold.TickFrequency = 5;
            tbMotDetDropFramesThreshold.Value = 5;
            // 
            // cbMotDetDropFramesEnabled
            // 
            cbMotDetDropFramesEnabled.AutoSize = true;
            cbMotDetDropFramesEnabled.Location = new System.Drawing.Point(23, 36);
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
            edMotDetFrameInterval.Size = new System.Drawing.Size(51, 31);
            edMotDetFrameInterval.TabIndex = 5;
            edMotDetFrameInterval.Text = "2";
            // 
            // label159
            // 
            label159.AutoSize = true;
            label159.Location = new System.Drawing.Point(18, 104);
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
            cbCompareGreyscale.Location = new System.Drawing.Point(271, 40);
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
            cbCompareBlue.Location = new System.Drawing.Point(197, 40);
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
            cbCompareGreen.Location = new System.Drawing.Point(100, 40);
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
            cbCompareRed.Location = new System.Drawing.Point(23, 40);
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
            cbMotDetEnabled.Location = new System.Drawing.Point(23, 31);
            cbMotDetEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMotDetEnabled.Name = "cbMotDetEnabled";
            cbMotDetEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetEnabled.TabIndex = 2;
            cbMotDetEnabled.Text = "Enabled";
            cbMotDetEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label393);
            tabPage2.Controls.Add(cbDirect2DRotate);
            tabPage2.Controls.Add(pnVideoRendererBGColor);
            tabPage2.Controls.Add(label394);
            tabPage2.Controls.Add(btFullScreen);
            tabPage2.Controls.Add(cbScreenFlipVertical);
            tabPage2.Controls.Add(cbScreenFlipHorizontal);
            tabPage2.Controls.Add(cbStretch);
            tabPage2.Controls.Add(groupBox13);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Size = new System.Drawing.Size(509, 962);
            tabPage2.TabIndex = 6;
            tabPage2.Text = "Display";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label393
            // 
            label393.AutoSize = true;
            label393.Location = new System.Drawing.Point(39, 444);
            label393.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label393.Name = "label393";
            label393.Size = new System.Drawing.Size(133, 25);
            label393.TabIndex = 65;
            label393.Text = "Direct2D rotate";
            // 
            // cbDirect2DRotate
            // 
            cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDirect2DRotate.FormattingEnabled = true;
            cbDirect2DRotate.Items.AddRange(new object[] { "0", "90", "180", "270" });
            cbDirect2DRotate.Location = new System.Drawing.Point(43, 474);
            cbDirect2DRotate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDirect2DRotate.Name = "cbDirect2DRotate";
            cbDirect2DRotate.Size = new System.Drawing.Size(201, 33);
            cbDirect2DRotate.TabIndex = 64;
            cbDirect2DRotate.SelectedIndexChanged += cbDirect2DRotate_SelectedIndexChanged;
            // 
            // pnVideoRendererBGColor
            // 
            pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black;
            pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnVideoRendererBGColor.Location = new System.Drawing.Point(217, 279);
            pnVideoRendererBGColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pnVideoRendererBGColor.Name = "pnVideoRendererBGColor";
            pnVideoRendererBGColor.Size = new System.Drawing.Size(39, 44);
            pnVideoRendererBGColor.TabIndex = 63;
            pnVideoRendererBGColor.Click += pnVideoRendererBGColor_Click;
            // 
            // label394
            // 
            label394.AutoSize = true;
            label394.Location = new System.Drawing.Point(39, 288);
            label394.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label394.Name = "label394";
            label394.Size = new System.Drawing.Size(152, 25);
            label394.TabIndex = 62;
            label394.Text = "Background color";
            // 
            // btFullScreen
            // 
            btFullScreen.Location = new System.Drawing.Point(310, 474);
            btFullScreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFullScreen.Name = "btFullScreen";
            btFullScreen.Size = new System.Drawing.Size(150, 44);
            btFullScreen.TabIndex = 61;
            btFullScreen.Text = "Full screen";
            btFullScreen.UseVisualStyleBackColor = true;
            btFullScreen.Click += btFullScreen_Click;
            // 
            // cbScreenFlipVertical
            // 
            cbScreenFlipVertical.AutoSize = true;
            cbScreenFlipVertical.Location = new System.Drawing.Point(310, 324);
            cbScreenFlipVertical.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbScreenFlipVertical.Name = "cbScreenFlipVertical";
            cbScreenFlipVertical.Size = new System.Drawing.Size(126, 29);
            cbScreenFlipVertical.TabIndex = 59;
            cbScreenFlipVertical.Text = "Flip vertical";
            cbScreenFlipVertical.UseVisualStyleBackColor = true;
            cbScreenFlipVertical.CheckedChanged += cbScreenFlipVertical_CheckedChanged;
            // 
            // cbScreenFlipHorizontal
            // 
            cbScreenFlipHorizontal.AutoSize = true;
            cbScreenFlipHorizontal.Location = new System.Drawing.Point(310, 280);
            cbScreenFlipHorizontal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal";
            cbScreenFlipHorizontal.Size = new System.Drawing.Size(150, 29);
            cbScreenFlipHorizontal.TabIndex = 58;
            cbScreenFlipHorizontal.Text = "Flip horizontal";
            cbScreenFlipHorizontal.UseVisualStyleBackColor = true;
            cbScreenFlipHorizontal.CheckedChanged += cbScreenFlipHorizontal_CheckedChanged;
            // 
            // cbStretch
            // 
            cbStretch.AutoSize = true;
            cbStretch.Location = new System.Drawing.Point(310, 366);
            cbStretch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbStretch.Name = "cbStretch";
            cbStretch.Size = new System.Drawing.Size(141, 29);
            cbStretch.TabIndex = 57;
            cbStretch.Text = "Stretch video";
            cbStretch.UseVisualStyleBackColor = true;
            cbStretch.CheckedChanged += cbStretch_CheckedChanged;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(rbDirect2D);
            groupBox13.Controls.Add(rbNone);
            groupBox13.Controls.Add(rbEVR);
            groupBox13.Controls.Add(rbVMR9);
            groupBox13.Location = new System.Drawing.Point(22, 20);
            groupBox13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox13.Size = new System.Drawing.Size(459, 236);
            groupBox13.TabIndex = 56;
            groupBox13.TabStop = false;
            groupBox13.Text = "Video Renderer";
            // 
            // rbDirect2D
            // 
            rbDirect2D.AutoSize = true;
            rbDirect2D.Location = new System.Drawing.Point(24, 135);
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
            rbNone.Location = new System.Drawing.Point(24, 180);
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
            rbEVR.Location = new System.Drawing.Point(24, 91);
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
            rbVMR9.Location = new System.Drawing.Point(24, 48);
            rbVMR9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVMR9.Name = "rbVMR9";
            rbVMR9.Size = new System.Drawing.Size(231, 29);
            rbVMR9.TabIndex = 1;
            rbVMR9.Text = "Video Mixing Renderer 9";
            rbVMR9.UseVisualStyleBackColor = true;
            rbVMR9.CheckedChanged += rbVR_CheckedChanged;
            // 
            // tabPage25
            // 
            tabPage25.Controls.Add(edBarcodeMetadata);
            tabPage25.Controls.Add(label91);
            tabPage25.Controls.Add(cbBarcodeType);
            tabPage25.Controls.Add(label90);
            tabPage25.Controls.Add(btBarcodeReset);
            tabPage25.Controls.Add(edBarcode);
            tabPage25.Controls.Add(label89);
            tabPage25.Controls.Add(cbBarcodeDetectionEnabled);
            tabPage25.Location = new System.Drawing.Point(4, 34);
            tabPage25.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage25.Name = "tabPage25";
            tabPage25.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage25.Size = new System.Drawing.Size(509, 962);
            tabPage25.TabIndex = 8;
            tabPage25.Text = "Barcode reader";
            tabPage25.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            edBarcodeMetadata.Location = new System.Drawing.Point(23, 310);
            edBarcodeMetadata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edBarcodeMetadata.Multiline = true;
            edBarcodeMetadata.Name = "edBarcodeMetadata";
            edBarcodeMetadata.Size = new System.Drawing.Size(467, 182);
            edBarcodeMetadata.TabIndex = 24;
            // 
            // label91
            // 
            label91.AutoSize = true;
            label91.Location = new System.Drawing.Point(18, 272);
            label91.Name = "label91";
            label91.Size = new System.Drawing.Size(87, 25);
            label91.TabIndex = 23;
            label91.Text = "Metadata";
            // 
            // cbBarcodeType
            // 
            cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBarcodeType.FormattingEnabled = true;
            cbBarcodeType.Items.AddRange(new object[] { "Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417" });
            cbBarcodeType.Location = new System.Drawing.Point(23, 125);
            cbBarcodeType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbBarcodeType.Name = "cbBarcodeType";
            cbBarcodeType.Size = new System.Drawing.Size(264, 33);
            cbBarcodeType.TabIndex = 22;
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Location = new System.Drawing.Point(18, 94);
            label90.Name = "label90";
            label90.Size = new System.Drawing.Size(116, 25);
            label90.TabIndex = 21;
            label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            btBarcodeReset.Location = new System.Drawing.Point(23, 518);
            btBarcodeReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btBarcodeReset.Name = "btBarcodeReset";
            btBarcodeReset.Size = new System.Drawing.Size(103, 44);
            btBarcodeReset.TabIndex = 20;
            btBarcodeReset.Text = "Restart";
            btBarcodeReset.UseVisualStyleBackColor = true;
            btBarcodeReset.Click += btBarcodeReset_Click;
            // 
            // edBarcode
            // 
            edBarcode.Location = new System.Drawing.Point(23, 218);
            edBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edBarcode.Name = "edBarcode";
            edBarcode.Size = new System.Drawing.Size(467, 31);
            edBarcode.TabIndex = 19;
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Location = new System.Drawing.Point(18, 186);
            label89.Name = "label89";
            label89.Size = new System.Drawing.Size(153, 25);
            label89.TabIndex = 18;
            label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            cbBarcodeDetectionEnabled.AutoSize = true;
            cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(23, 36);
            cbBarcodeDetectionEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(101, 29);
            cbBarcodeDetectionEnabled.TabIndex = 17;
            cbBarcodeDetectionEnabled.Text = "Enabled";
            cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage28
            // 
            tabPage28.Controls.Add(cbNetworkStreamingMode);
            tabPage28.Controls.Add(tabControl5);
            tabPage28.Controls.Add(cbNetworkStreamingAudioEnabled);
            tabPage28.Controls.Add(cbNetworkStreaming);
            tabPage28.Location = new System.Drawing.Point(4, 34);
            tabPage28.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage28.Name = "tabPage28";
            tabPage28.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage28.Size = new System.Drawing.Size(509, 962);
            tabPage28.TabIndex = 9;
            tabPage28.Text = "Network streaming";
            tabPage28.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreamingMode
            // 
            cbNetworkStreamingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbNetworkStreamingMode.FormattingEnabled = true;
            cbNetworkStreamingMode.Items.AddRange(new object[] { "Windows Media Video", "RTSP", "RTMP (including YouTube and Facebook)", "NDI", "UDP", "Smooth Streaming to Microsoft IIS", "Output to external virtual devices", "HTTP Live Streaming (HLS)" });
            cbNetworkStreamingMode.Location = new System.Drawing.Point(27, 75);
            cbNetworkStreamingMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbNetworkStreamingMode.Name = "cbNetworkStreamingMode";
            cbNetworkStreamingMode.Size = new System.Drawing.Size(457, 33);
            cbNetworkStreamingMode.TabIndex = 26;
            // 
            // tabControl5
            // 
            tabControl5.Controls.Add(tabPage32);
            tabControl5.Controls.Add(tabPage49);
            tabControl5.Controls.Add(tabPage50);
            tabControl5.Controls.Add(tabPage4);
            tabControl5.Controls.Add(tabPage77);
            tabControl5.Controls.Add(tabPage51);
            tabControl5.Controls.Add(tabPage33);
            tabControl5.Controls.Add(tabPage5);
            tabControl5.Location = new System.Drawing.Point(7, 140);
            tabControl5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl5.Name = "tabControl5";
            tabControl5.SelectedIndex = 0;
            tabControl5.Size = new System.Drawing.Size(487, 728);
            tabControl5.TabIndex = 25;
            // 
            // tabPage32
            // 
            tabPage32.Controls.Add(label24);
            tabPage32.Controls.Add(edNetworkURL);
            tabPage32.Controls.Add(edWMVNetworkPort);
            tabPage32.Controls.Add(label21);
            tabPage32.Controls.Add(btRefreshClients);
            tabPage32.Controls.Add(lbNetworkClients);
            tabPage32.Controls.Add(rbNetworkStreamingUseExternalProfile);
            tabPage32.Controls.Add(rbNetworkStreamingUseMainWMVSettings);
            tabPage32.Controls.Add(label81);
            tabPage32.Controls.Add(label80);
            tabPage32.Controls.Add(edMaximumClients);
            tabPage32.Controls.Add(label22);
            tabPage32.Controls.Add(btSelectWMVProfileNetwork);
            tabPage32.Controls.Add(edNetworkStreamingWMVProfile);
            tabPage32.Controls.Add(label23);
            tabPage32.Location = new System.Drawing.Point(4, 34);
            tabPage32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage32.Name = "tabPage32";
            tabPage32.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage32.Size = new System.Drawing.Size(479, 690);
            tabPage32.TabIndex = 0;
            tabPage32.Text = "WMV";
            tabPage32.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(22, 575);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(138, 25);
            label24.TabIndex = 32;
            label24.Text = "Connection URL";
            // 
            // edNetworkURL
            // 
            edNetworkURL.Location = new System.Drawing.Point(24, 606);
            edNetworkURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkURL.Name = "edNetworkURL";
            edNetworkURL.ReadOnly = true;
            edNetworkURL.Size = new System.Drawing.Size(433, 31);
            edNetworkURL.TabIndex = 31;
            // 
            // edWMVNetworkPort
            // 
            edWMVNetworkPort.Location = new System.Drawing.Point(393, 231);
            edWMVNetworkPort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edWMVNetworkPort.Name = "edWMVNetworkPort";
            edWMVNetworkPort.Size = new System.Drawing.Size(54, 31);
            edWMVNetworkPort.TabIndex = 30;
            edWMVNetworkPort.Text = "100";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(270, 236);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(118, 25);
            label21.TabIndex = 29;
            label21.Text = "Network port";
            // 
            // btRefreshClients
            // 
            btRefreshClients.Location = new System.Drawing.Point(343, 456);
            btRefreshClients.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btRefreshClients.Name = "btRefreshClients";
            btRefreshClients.Size = new System.Drawing.Size(107, 44);
            btRefreshClients.TabIndex = 28;
            btRefreshClients.Text = "Refresh";
            btRefreshClients.UseVisualStyleBackColor = true;
            btRefreshClients.Click += btRefreshClients_Click;
            // 
            // lbNetworkClients
            // 
            lbNetworkClients.FormattingEnabled = true;
            lbNetworkClients.ItemHeight = 25;
            lbNetworkClients.Location = new System.Drawing.Point(24, 336);
            lbNetworkClients.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbNetworkClients.Name = "lbNetworkClients";
            lbNetworkClients.Size = new System.Drawing.Size(422, 104);
            lbNetworkClients.TabIndex = 27;
            // 
            // rbNetworkStreamingUseExternalProfile
            // 
            rbNetworkStreamingUseExternalProfile.AutoSize = true;
            rbNetworkStreamingUseExternalProfile.Location = new System.Drawing.Point(24, 72);
            rbNetworkStreamingUseExternalProfile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkStreamingUseExternalProfile.Name = "rbNetworkStreamingUseExternalProfile";
            rbNetworkStreamingUseExternalProfile.Size = new System.Drawing.Size(188, 29);
            rbNetworkStreamingUseExternalProfile.TabIndex = 26;
            rbNetworkStreamingUseExternalProfile.Text = "Use external profile";
            rbNetworkStreamingUseExternalProfile.UseVisualStyleBackColor = true;
            // 
            // rbNetworkStreamingUseMainWMVSettings
            // 
            rbNetworkStreamingUseMainWMVSettings.AutoSize = true;
            rbNetworkStreamingUseMainWMVSettings.Checked = true;
            rbNetworkStreamingUseMainWMVSettings.Location = new System.Drawing.Point(24, 29);
            rbNetworkStreamingUseMainWMVSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkStreamingUseMainWMVSettings.Name = "rbNetworkStreamingUseMainWMVSettings";
            rbNetworkStreamingUseMainWMVSettings.Size = new System.Drawing.Size(321, 29);
            rbNetworkStreamingUseMainWMVSettings.TabIndex = 25;
            rbNetworkStreamingUseMainWMVSettings.TabStop = true;
            rbNetworkStreamingUseMainWMVSettings.Text = "Use WMV settings from capture tab";
            rbNetworkStreamingUseMainWMVSettings.UseVisualStyleBackColor = true;
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Location = new System.Drawing.Point(57, 522);
            label81.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label81.Name = "label81";
            label81.Size = new System.Drawing.Size(381, 25);
            label81.TabIndex = 24;
            label81.Text = "You can use Windows Media Player for testing.";
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Location = new System.Drawing.Point(22, 306);
            label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label80.Name = "label80";
            label80.Size = new System.Drawing.Size(64, 25);
            label80.TabIndex = 23;
            label80.Text = "Clients";
            // 
            // edMaximumClients
            // 
            edMaximumClients.Location = new System.Drawing.Point(182, 231);
            edMaximumClients.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMaximumClients.Name = "edMaximumClients";
            edMaximumClients.Size = new System.Drawing.Size(54, 31);
            edMaximumClients.TabIndex = 22;
            edMaximumClients.Text = "10";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(22, 236);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(145, 25);
            label22.TabIndex = 21;
            label22.Text = "Maximum clients";
            // 
            // btSelectWMVProfileNetwork
            // 
            btSelectWMVProfileNetwork.Location = new System.Drawing.Point(410, 158);
            btSelectWMVProfileNetwork.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectWMVProfileNetwork.Name = "btSelectWMVProfileNetwork";
            btSelectWMVProfileNetwork.Size = new System.Drawing.Size(40, 44);
            btSelectWMVProfileNetwork.TabIndex = 20;
            btSelectWMVProfileNetwork.Text = "...";
            btSelectWMVProfileNetwork.UseVisualStyleBackColor = true;
            btSelectWMVProfileNetwork.Click += btSelectWMVProfileNetwork_Click;
            // 
            // edNetworkStreamingWMVProfile
            // 
            edNetworkStreamingWMVProfile.Location = new System.Drawing.Point(62, 161);
            edNetworkStreamingWMVProfile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkStreamingWMVProfile.Name = "edNetworkStreamingWMVProfile";
            edNetworkStreamingWMVProfile.Size = new System.Drawing.Size(341, 31);
            edNetworkStreamingWMVProfile.TabIndex = 19;
            edNetworkStreamingWMVProfile.Text = "c:\\WM.prx";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(57, 131);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(87, 25);
            label23.TabIndex = 18;
            label23.Text = "File name";
            // 
            // tabPage49
            // 
            tabPage49.Controls.Add(edNetworkRTSPURL);
            tabPage49.Controls.Add(label367);
            tabPage49.Controls.Add(label366);
            tabPage49.Location = new System.Drawing.Point(4, 34);
            tabPage49.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage49.Name = "tabPage49";
            tabPage49.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage49.Size = new System.Drawing.Size(479, 690);
            tabPage49.TabIndex = 2;
            tabPage49.Text = "RTSP";
            tabPage49.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTSPURL
            // 
            edNetworkRTSPURL.Location = new System.Drawing.Point(33, 68);
            edNetworkRTSPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkRTSPURL.Name = "edNetworkRTSPURL";
            edNetworkRTSPURL.Size = new System.Drawing.Size(408, 31);
            edNetworkRTSPURL.TabIndex = 9;
            edNetworkRTSPURL.Text = "rtsp://localhost:5554/vfstream";
            // 
            // label367
            // 
            label367.AutoSize = true;
            label367.Location = new System.Drawing.Point(29, 36);
            label367.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label367.Name = "label367";
            label367.Size = new System.Drawing.Size(43, 25);
            label367.TabIndex = 8;
            label367.Text = "URL";
            // 
            // label366
            // 
            label366.AutoSize = true;
            label366.Location = new System.Drawing.Point(29, 622);
            label366.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label366.Name = "label366";
            label366.Size = new System.Drawing.Size(272, 25);
            label366.TabIndex = 7;
            label366.Text = "MP4 output settings will be used";
            // 
            // tabPage50
            // 
            tabPage50.Controls.Add(linkLabel11);
            tabPage50.Controls.Add(rbNetworkRTMPFFMPEGCustom);
            tabPage50.Controls.Add(rbNetworkRTMPFFMPEG);
            tabPage50.Controls.Add(edNetworkRTMPURL);
            tabPage50.Controls.Add(label368);
            tabPage50.Controls.Add(label369);
            tabPage50.Location = new System.Drawing.Point(4, 34);
            tabPage50.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage50.Name = "tabPage50";
            tabPage50.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage50.Size = new System.Drawing.Size(479, 690);
            tabPage50.TabIndex = 3;
            tabPage50.Text = "RTMP";
            tabPage50.UseVisualStyleBackColor = true;
            // 
            // linkLabel11
            // 
            linkLabel11.AutoSize = true;
            linkLabel11.Location = new System.Drawing.Point(29, 211);
            linkLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel11.Name = "linkLabel11";
            linkLabel11.Size = new System.Drawing.Size(258, 25);
            linkLabel11.TabIndex = 19;
            linkLabel11.TabStop = true;
            linkLabel11.Text = "Network streaming to YouTube";
            linkLabel11.LinkClicked += linkLabel11_LinkClicked;
            // 
            // rbNetworkRTMPFFMPEGCustom
            // 
            rbNetworkRTMPFFMPEGCustom.AutoSize = true;
            rbNetworkRTMPFFMPEGCustom.Location = new System.Drawing.Point(33, 81);
            rbNetworkRTMPFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkRTMPFFMPEGCustom.Name = "rbNetworkRTMPFFMPEGCustom";
            rbNetworkRTMPFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkRTMPFFMPEGCustom.TabIndex = 17;
            rbNetworkRTMPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkRTMPFFMPEG
            // 
            rbNetworkRTMPFFMPEG.AutoSize = true;
            rbNetworkRTMPFFMPEG.Checked = true;
            rbNetworkRTMPFFMPEG.Location = new System.Drawing.Point(33, 36);
            rbNetworkRTMPFFMPEG.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkRTMPFFMPEG.Name = "rbNetworkRTMPFFMPEG";
            rbNetworkRTMPFFMPEG.Size = new System.Drawing.Size(284, 29);
            rbNetworkRTMPFFMPEG.TabIndex = 16;
            rbNetworkRTMPFFMPEG.TabStop = true;
            rbNetworkRTMPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTMPURL
            // 
            edNetworkRTMPURL.Location = new System.Drawing.Point(33, 564);
            edNetworkRTMPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkRTMPURL.Name = "edNetworkRTMPURL";
            edNetworkRTMPURL.Size = new System.Drawing.Size(408, 31);
            edNetworkRTMPURL.TabIndex = 15;
            edNetworkRTMPURL.Text = "rtmp://localhost:5554/live/Stream";
            // 
            // label368
            // 
            label368.AutoSize = true;
            label368.Location = new System.Drawing.Point(29, 532);
            label368.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label368.Name = "label368";
            label368.Size = new System.Drawing.Size(43, 25);
            label368.TabIndex = 14;
            label368.Text = "URL";
            // 
            // label369
            // 
            label369.AutoSize = true;
            label369.Location = new System.Drawing.Point(29, 622);
            label369.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label369.Name = "label369";
            label369.Size = new System.Drawing.Size(374, 25);
            label369.TabIndex = 13;
            label369.Text = "Format settings located on output format tab";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lbNDI);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(edNDIURL);
            tabPage4.Controls.Add(edNDIName);
            tabPage4.Controls.Add(label13);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Size = new System.Drawing.Size(479, 690);
            tabPage4.TabIndex = 6;
            tabPage4.Text = "NDI";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbNDI
            // 
            lbNDI.AutoSize = true;
            lbNDI.Location = new System.Drawing.Point(24, 260);
            lbNDI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbNDI.Name = "lbNDI";
            lbNDI.Size = new System.Drawing.Size(145, 25);
            lbNDI.TabIndex = 95;
            lbNDI.TabStop = true;
            lbNDI.Text = "vendor's website";
            lbNDI.LinkClicked += lbNDI_LinkClicked;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(24, 235);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(428, 25);
            label11.TabIndex = 94;
            label11.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(24, 136);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(138, 25);
            label12.TabIndex = 93;
            label12.Text = "Connection URL";
            // 
            // edNDIURL
            // 
            edNDIURL.Location = new System.Drawing.Point(30, 168);
            edNDIURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNDIURL.Name = "edNDIURL";
            edNDIURL.ReadOnly = true;
            edNDIURL.Size = new System.Drawing.Size(402, 31);
            edNDIURL.TabIndex = 92;
            // 
            // edNDIName
            // 
            edNDIName.Location = new System.Drawing.Point(30, 68);
            edNDIName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNDIName.Name = "edNDIName";
            edNDIName.Size = new System.Drawing.Size(402, 31);
            edNDIName.TabIndex = 91;
            edNDIName.Text = "Main";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(24, 36);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(59, 25);
            label13.TabIndex = 90;
            label13.Text = "Name";
            // 
            // tabPage77
            // 
            tabPage77.Controls.Add(label484);
            tabPage77.Controls.Add(label63);
            tabPage77.Controls.Add(label62);
            tabPage77.Controls.Add(label314);
            tabPage77.Controls.Add(label313);
            tabPage77.Controls.Add(edNetworkUDPURL);
            tabPage77.Controls.Add(label372);
            tabPage77.Controls.Add(rbNetworkUDPFFMPEGCustom);
            tabPage77.Controls.Add(rbNetworkUDPFFMPEG);
            tabPage77.Location = new System.Drawing.Point(4, 34);
            tabPage77.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage77.Name = "tabPage77";
            tabPage77.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage77.Size = new System.Drawing.Size(479, 690);
            tabPage77.TabIndex = 5;
            tabPage77.Text = "UDP";
            tabPage77.UseVisualStyleBackColor = true;
            // 
            // label484
            // 
            label484.AutoSize = true;
            label484.Location = new System.Drawing.Point(44, 629);
            label484.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label484.Name = "label484";
            label484.Size = new System.Drawing.Size(374, 25);
            label484.TabIndex = 24;
            label484.Text = "Specify settings located on output format tab";
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Location = new System.Drawing.Point(24, 489);
            label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label63.Name = "label63";
            label63.Size = new System.Drawing.Size(182, 25);
            label63.TabIndex = 23;
            label63.Text = "instead of IP address.";
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Location = new System.Drawing.Point(24, 464);
            label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label62.Name = "label62";
            label62.Size = new System.Drawing.Size(388, 25);
            label62.TabIndex = 22;
            label62.Text = "To open the stream in VLC on a local PC, use @ ";
            // 
            // label314
            // 
            label314.AutoSize = true;
            label314.Location = new System.Drawing.Point(24, 365);
            label314.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label314.Name = "label314";
            label314.Size = new System.Drawing.Size(365, 25);
            label314.TabIndex = 21;
            label314.Text = "For multicast UDP streaming, use an URL like";
            // 
            // label313
            // 
            label313.AutoSize = true;
            label313.Location = new System.Drawing.Point(24, 390);
            label313.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label313.Name = "label313";
            label313.Size = new System.Drawing.Size(378, 25);
            label313.TabIndex = 20;
            label313.Text = "udp://239.101.101.1:1234?ttl=1&pkt_size=1316";
            // 
            // edNetworkUDPURL
            // 
            edNetworkUDPURL.Location = new System.Drawing.Point(30, 321);
            edNetworkUDPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkUDPURL.Name = "edNetworkUDPURL";
            edNetworkUDPURL.Size = new System.Drawing.Size(408, 31);
            edNetworkUDPURL.TabIndex = 19;
            edNetworkUDPURL.Text = "udp://127.0.0.1:10000?pkt_size=1316";
            // 
            // label372
            // 
            label372.AutoSize = true;
            label372.Location = new System.Drawing.Point(24, 290);
            label372.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label372.Name = "label372";
            label372.Size = new System.Drawing.Size(43, 25);
            label372.TabIndex = 18;
            label372.Text = "URL";
            // 
            // rbNetworkUDPFFMPEGCustom
            // 
            rbNetworkUDPFFMPEGCustom.AutoSize = true;
            rbNetworkUDPFFMPEGCustom.Location = new System.Drawing.Point(30, 81);
            rbNetworkUDPFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkUDPFFMPEGCustom.Name = "rbNetworkUDPFFMPEGCustom";
            rbNetworkUDPFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkUDPFFMPEGCustom.TabIndex = 12;
            rbNetworkUDPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkUDPFFMPEG
            // 
            rbNetworkUDPFFMPEG.AutoSize = true;
            rbNetworkUDPFFMPEG.Checked = true;
            rbNetworkUDPFFMPEG.Location = new System.Drawing.Point(30, 36);
            rbNetworkUDPFFMPEG.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkUDPFFMPEG.Name = "rbNetworkUDPFFMPEG";
            rbNetworkUDPFFMPEG.Size = new System.Drawing.Size(284, 29);
            rbNetworkUDPFFMPEG.TabIndex = 11;
            rbNetworkUDPFFMPEG.TabStop = true;
            rbNetworkUDPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkUDPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // tabPage51
            // 
            tabPage51.Controls.Add(rbNetworkSSFFMPEGCustom);
            tabPage51.Controls.Add(rbNetworkSSFFMPEGDefault);
            tabPage51.Controls.Add(linkLabel6);
            tabPage51.Controls.Add(edNetworkSSURL);
            tabPage51.Controls.Add(label370);
            tabPage51.Controls.Add(label371);
            tabPage51.Controls.Add(rbNetworkSSSoftware);
            tabPage51.Location = new System.Drawing.Point(4, 34);
            tabPage51.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage51.Name = "tabPage51";
            tabPage51.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage51.Size = new System.Drawing.Size(479, 690);
            tabPage51.TabIndex = 4;
            tabPage51.Text = "IIS Smooth Streaming";
            tabPage51.UseVisualStyleBackColor = true;
            // 
            // rbNetworkSSFFMPEGCustom
            // 
            rbNetworkSSFFMPEGCustom.AutoSize = true;
            rbNetworkSSFFMPEGCustom.Location = new System.Drawing.Point(33, 118);
            rbNetworkSSFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkSSFFMPEGCustom.Name = "rbNetworkSSFFMPEGCustom";
            rbNetworkSSFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkSSFFMPEGCustom.TabIndex = 22;
            rbNetworkSSFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkSSFFMPEGDefault
            // 
            rbNetworkSSFFMPEGDefault.AutoSize = true;
            rbNetworkSSFFMPEGDefault.Location = new System.Drawing.Point(33, 72);
            rbNetworkSSFFMPEGDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkSSFFMPEGDefault.Name = "rbNetworkSSFFMPEGDefault";
            rbNetworkSSFFMPEGDefault.Size = new System.Drawing.Size(284, 29);
            rbNetworkSSFFMPEGDefault.TabIndex = 21;
            rbNetworkSSFFMPEGDefault.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = true;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Location = new System.Drawing.Point(29, 456);
            linkLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new System.Drawing.Size(301, 25);
            linkLabel6.TabIndex = 20;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "IIS Smooth Streaming usage manual";
            linkLabel6.LinkClicked += linkLabel6_LinkClicked;
            // 
            // edNetworkSSURL
            // 
            edNetworkSSURL.Location = new System.Drawing.Point(33, 365);
            edNetworkSSURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkSSURL.Name = "edNetworkSSURL";
            edNetworkSSURL.Size = new System.Drawing.Size(408, 31);
            edNetworkSSURL.TabIndex = 19;
            edNetworkSSURL.Text = "http://localhost/LiveStream.isml";
            // 
            // label370
            // 
            label370.AutoSize = true;
            label370.Location = new System.Drawing.Point(29, 335);
            label370.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label370.Name = "label370";
            label370.Size = new System.Drawing.Size(177, 25);
            label370.TabIndex = 18;
            label370.Text = "Publishing point URL";
            // 
            // label371
            // 
            label371.AutoSize = true;
            label371.Location = new System.Drawing.Point(29, 622);
            label371.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label371.Name = "label371";
            label371.Size = new System.Drawing.Size(374, 25);
            label371.TabIndex = 17;
            label371.Text = "Format settings located on output format tab";
            // 
            // rbNetworkSSSoftware
            // 
            rbNetworkSSSoftware.AutoSize = true;
            rbNetworkSSSoftware.Checked = true;
            rbNetworkSSSoftware.Location = new System.Drawing.Point(33, 29);
            rbNetworkSSSoftware.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbNetworkSSSoftware.Name = "rbNetworkSSSoftware";
            rbNetworkSSSoftware.Size = new System.Drawing.Size(322, 29);
            rbNetworkSSSoftware.TabIndex = 15;
            rbNetworkSSSoftware.TabStop = true;
            rbNetworkSSSoftware.Text = "H264 / AAC using software encoder";
            rbNetworkSSSoftware.UseVisualStyleBackColor = true;
            // 
            // tabPage33
            // 
            tabPage33.Controls.Add(linkLabel4);
            tabPage33.Controls.Add(linkLabel5);
            tabPage33.Location = new System.Drawing.Point(4, 34);
            tabPage33.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage33.Name = "tabPage33";
            tabPage33.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage33.Size = new System.Drawing.Size(479, 690);
            tabPage33.TabIndex = 1;
            tabPage33.Text = "External";
            tabPage33.UseVisualStyleBackColor = true;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new System.Drawing.Point(43, 94);
            linkLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new System.Drawing.Size(379, 25);
            linkLabel4.TabIndex = 3;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Streaming using Microsoft Expression Encoder";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new System.Drawing.Point(43, 44);
            linkLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new System.Drawing.Size(326, 25);
            linkLabel5.TabIndex = 2;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Streaming to Adobe Flash Media Server";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(edHLSURL);
            tabPage5.Controls.Add(label14);
            tabPage5.Controls.Add(edHLSEmbeddedHTTPServerPort);
            tabPage5.Controls.Add(cbHLSEmbeddedHTTPServerEnabled);
            tabPage5.Controls.Add(cbHLSMode);
            tabPage5.Controls.Add(label25);
            tabPage5.Controls.Add(lbHLSConfigure);
            tabPage5.Controls.Add(label532);
            tabPage5.Controls.Add(label531);
            tabPage5.Controls.Add(label530);
            tabPage5.Controls.Add(label529);
            tabPage5.Controls.Add(edHLSSegmentCount);
            tabPage5.Controls.Add(label519);
            tabPage5.Controls.Add(edHLSSegmentDuration);
            tabPage5.Controls.Add(btSelectHLSOutputFolder);
            tabPage5.Controls.Add(edHLSOutputFolder);
            tabPage5.Controls.Add(label380);
            tabPage5.Location = new System.Drawing.Point(4, 34);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Size = new System.Drawing.Size(479, 690);
            tabPage5.TabIndex = 7;
            tabPage5.Text = "HLS";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // edHLSURL
            // 
            edHLSURL.Location = new System.Drawing.Point(23, 554);
            edHLSURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHLSURL.Name = "edHLSURL";
            edHLSURL.Size = new System.Drawing.Size(417, 31);
            edHLSURL.TabIndex = 33;
            edHLSURL.Text = "http://localhost:81/playlist.m3u8";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(18, 602);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(29, 25);
            label14.TabIndex = 32;
            label14.Text = "or";
            // 
            // edHLSEmbeddedHTTPServerPort
            // 
            edHLSEmbeddedHTTPServerPort.Location = new System.Drawing.Point(376, 506);
            edHLSEmbeddedHTTPServerPort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHLSEmbeddedHTTPServerPort.Name = "edHLSEmbeddedHTTPServerPort";
            edHLSEmbeddedHTTPServerPort.Size = new System.Drawing.Size(66, 31);
            edHLSEmbeddedHTTPServerPort.TabIndex = 31;
            edHLSEmbeddedHTTPServerPort.Text = "81";
            // 
            // cbHLSEmbeddedHTTPServerEnabled
            // 
            cbHLSEmbeddedHTTPServerEnabled.AutoSize = true;
            cbHLSEmbeddedHTTPServerEnabled.Location = new System.Drawing.Point(23, 510);
            cbHLSEmbeddedHTTPServerEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbHLSEmbeddedHTTPServerEnabled.Name = "cbHLSEmbeddedHTTPServerEnabled";
            cbHLSEmbeddedHTTPServerEnabled.Size = new System.Drawing.Size(334, 29);
            cbHLSEmbeddedHTTPServerEnabled.TabIndex = 30;
            cbHLSEmbeddedHTTPServerEnabled.Text = "Use embedded HTTP server with port";
            cbHLSEmbeddedHTTPServerEnabled.UseVisualStyleBackColor = true;
            // 
            // cbHLSMode
            // 
            cbHLSMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHLSMode.FormattingEnabled = true;
            cbHLSMode.Items.AddRange(new object[] { "Live", "VOD", "Event" });
            cbHLSMode.Location = new System.Drawing.Point(23, 436);
            cbHLSMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbHLSMode.Name = "cbHLSMode";
            cbHLSMode.Size = new System.Drawing.Size(200, 33);
            cbHLSMode.TabIndex = 29;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(18, 406);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(169, 25);
            label25.TabIndex = 28;
            label25.Text = "Mode (playlist type)";
            // 
            // lbHLSConfigure
            // 
            lbHLSConfigure.AutoSize = true;
            lbHLSConfigure.Location = new System.Drawing.Point(18, 628);
            lbHLSConfigure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbHLSConfigure.Name = "lbHLSConfigure";
            lbHLSConfigure.Size = new System.Drawing.Size(313, 25);
            lbHLSConfigure.TabIndex = 27;
            lbHLSConfigure.TabStop = true;
            lbHLSConfigure.Text = "How to configure HTTP server for HLS";
            lbHLSConfigure.LinkClicked += lbHLSConfigure_LinkClicked;
            // 
            // label532
            // 
            label532.AutoSize = true;
            label532.Location = new System.Drawing.Point(18, 348);
            label532.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label532.Name = "label532";
            label532.Size = new System.Drawing.Size(70, 25);
            label532.TabIndex = 26;
            label532.Text = "in code";
            // 
            // label531
            // 
            label531.AutoSize = true;
            label531.Location = new System.Drawing.Point(18, 322);
            label531.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label531.Name = "label531";
            label531.Size = new System.Drawing.Size(410, 25);
            label531.TabIndex = 25;
            label531.Text = "You can set video (H264) and audio (AAC) settings";
            // 
            // label530
            // 
            label530.AutoSize = true;
            label530.Location = new System.Drawing.Point(103, 256);
            label530.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label530.Name = "label530";
            label530.Size = new System.Drawing.Size(222, 25);
            label530.TabIndex = 24;
            label530.Text = "Use 0 to save all segments";
            // 
            // label529
            // 
            label529.AutoSize = true;
            label529.Location = new System.Drawing.Point(18, 219);
            label529.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label529.Name = "label529";
            label529.Size = new System.Drawing.Size(416, 25);
            label529.TabIndex = 23;
            label529.Text = "Segment count that will be saved during streaming";
            // 
            // edHLSSegmentCount
            // 
            edHLSSegmentCount.Location = new System.Drawing.Point(23, 250);
            edHLSSegmentCount.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHLSSegmentCount.Name = "edHLSSegmentCount";
            edHLSSegmentCount.Size = new System.Drawing.Size(67, 31);
            edHLSSegmentCount.TabIndex = 22;
            edHLSSegmentCount.Text = "20";
            // 
            // label519
            // 
            label519.AutoSize = true;
            label519.Location = new System.Drawing.Point(18, 125);
            label519.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label519.Name = "label519";
            label519.Size = new System.Drawing.Size(195, 25);
            label519.TabIndex = 21;
            label519.Text = "Segment duration (sec)";
            // 
            // edHLSSegmentDuration
            // 
            edHLSSegmentDuration.Location = new System.Drawing.Point(23, 156);
            edHLSSegmentDuration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHLSSegmentDuration.Name = "edHLSSegmentDuration";
            edHLSSegmentDuration.Size = new System.Drawing.Size(67, 31);
            edHLSSegmentDuration.TabIndex = 20;
            edHLSSegmentDuration.Text = "10";
            // 
            // btSelectHLSOutputFolder
            // 
            btSelectHLSOutputFolder.Location = new System.Drawing.Point(417, 60);
            btSelectHLSOutputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectHLSOutputFolder.Name = "btSelectHLSOutputFolder";
            btSelectHLSOutputFolder.Size = new System.Drawing.Size(38, 44);
            btSelectHLSOutputFolder.TabIndex = 19;
            btSelectHLSOutputFolder.Text = "...";
            btSelectHLSOutputFolder.UseVisualStyleBackColor = true;
            btSelectHLSOutputFolder.Click += btSelectHLSOutputFolder_Click;
            // 
            // edHLSOutputFolder
            // 
            edHLSOutputFolder.Location = new System.Drawing.Point(23, 64);
            edHLSOutputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edHLSOutputFolder.Name = "edHLSOutputFolder";
            edHLSOutputFolder.Size = new System.Drawing.Size(381, 31);
            edHLSOutputFolder.TabIndex = 18;
            edHLSOutputFolder.Text = "c:\\inetpub\\wwwroot\\hls\\";
            // 
            // label380
            // 
            label380.AutoSize = true;
            label380.Location = new System.Drawing.Point(18, 28);
            label380.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label380.Name = "label380";
            label380.Size = new System.Drawing.Size(329, 25);
            label380.TabIndex = 17;
            label380.Text = "Output folder for video files and playlist";
            // 
            // cbNetworkStreamingAudioEnabled
            // 
            cbNetworkStreamingAudioEnabled.AutoSize = true;
            cbNetworkStreamingAudioEnabled.Location = new System.Drawing.Point(27, 879);
            cbNetworkStreamingAudioEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbNetworkStreamingAudioEnabled.Name = "cbNetworkStreamingAudioEnabled";
            cbNetworkStreamingAudioEnabled.Size = new System.Drawing.Size(143, 29);
            cbNetworkStreamingAudioEnabled.TabIndex = 24;
            cbNetworkStreamingAudioEnabled.Text = "Stream audio";
            cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreaming
            // 
            cbNetworkStreaming.AutoSize = true;
            cbNetworkStreaming.Location = new System.Drawing.Point(27, 31);
            cbNetworkStreaming.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbNetworkStreaming.Name = "cbNetworkStreaming";
            cbNetworkStreaming.Size = new System.Drawing.Size(257, 29);
            cbNetworkStreaming.TabIndex = 21;
            cbNetworkStreaming.Text = "Network streaming enabled";
            cbNetworkStreaming.UseVisualStyleBackColor = true;
            // 
            // tabPage34
            // 
            tabPage34.Controls.Add(label328);
            tabPage34.Controls.Add(label327);
            tabPage34.Controls.Add(label326);
            tabPage34.Controls.Add(label325);
            tabPage34.Controls.Add(cbVirtualCamera);
            tabPage34.Location = new System.Drawing.Point(4, 34);
            tabPage34.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage34.Name = "tabPage34";
            tabPage34.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage34.Size = new System.Drawing.Size(509, 962);
            tabPage34.TabIndex = 10;
            tabPage34.Text = "Virtual camera";
            tabPage34.UseVisualStyleBackColor = true;
            // 
            // label328
            // 
            label328.AutoSize = true;
            label328.Location = new System.Drawing.Point(22, 244);
            label328.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label328.Name = "label328";
            label328.Size = new System.Drawing.Size(337, 25);
            label328.TabIndex = 7;
            label328.Text = "TRIAL limitation - 5000 frames to stream.";
            // 
            // label327
            // 
            label327.AutoSize = true;
            label327.Location = new System.Drawing.Point(22, 202);
            label327.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label327.Name = "label327";
            label327.Size = new System.Drawing.Size(297, 25);
            label327.TabIndex = 6;
            label327.Text = "Virtual Camera SDK license required.";
            // 
            // label326
            // 
            label326.AutoSize = true;
            label326.Location = new System.Drawing.Point(22, 136);
            label326.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label326.Name = "label326";
            label326.Size = new System.Drawing.Size(188, 25);
            label326.TabIndex = 5;
            label326.Text = "to see streamed video";
            // 
            // label325
            // 
            label325.AutoSize = true;
            label325.Location = new System.Drawing.Point(22, 98);
            label325.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label325.Name = "label325";
            label325.Size = new System.Drawing.Size(398, 25);
            label325.TabIndex = 4;
            label325.Text = "You are can use VisioForge Virtual Camera device";
            // 
            // cbVirtualCamera
            // 
            cbVirtualCamera.AutoSize = true;
            cbVirtualCamera.Location = new System.Drawing.Point(27, 32);
            cbVirtualCamera.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVirtualCamera.Name = "cbVirtualCamera";
            cbVirtualCamera.Size = new System.Drawing.Size(174, 29);
            cbVirtualCamera.TabIndex = 3;
            cbVirtualCamera.Text = "Enable streaming";
            cbVirtualCamera.UseVisualStyleBackColor = true;
            // 
            // tabPage46
            // 
            tabPage46.Controls.Add(cbDecklinkOutputDownConversionAnalogOutput);
            tabPage46.Controls.Add(cbDecklinkOutputDownConversion);
            tabPage46.Controls.Add(label337);
            tabPage46.Controls.Add(cbDecklinkOutputHDTVPulldown);
            tabPage46.Controls.Add(label336);
            tabPage46.Controls.Add(cbDecklinkOutputBlackToDeck);
            tabPage46.Controls.Add(label335);
            tabPage46.Controls.Add(cbDecklinkOutputSingleField);
            tabPage46.Controls.Add(label334);
            tabPage46.Controls.Add(cbDecklinkOutputComponentLevels);
            tabPage46.Controls.Add(label333);
            tabPage46.Controls.Add(cbDecklinkOutputNTSC);
            tabPage46.Controls.Add(label332);
            tabPage46.Controls.Add(cbDecklinkOutputDualLink);
            tabPage46.Controls.Add(label331);
            tabPage46.Controls.Add(cbDecklinkOutputAnalog);
            tabPage46.Controls.Add(label87);
            tabPage46.Controls.Add(cbDecklinkDV);
            tabPage46.Controls.Add(cbDecklinkOutput);
            tabPage46.Location = new System.Drawing.Point(4, 34);
            tabPage46.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage46.Name = "tabPage46";
            tabPage46.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage46.Size = new System.Drawing.Size(509, 962);
            tabPage46.TabIndex = 11;
            tabPage46.Text = "Decklink output";
            tabPage46.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutputDownConversionAnalogOutput
            // 
            cbDecklinkOutputDownConversionAnalogOutput.AutoSize = true;
            cbDecklinkOutputDownConversionAnalogOutput.Location = new System.Drawing.Point(40, 475);
            cbDecklinkOutputDownConversionAnalogOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputDownConversionAnalogOutput.Name = "cbDecklinkOutputDownConversionAnalogOutput";
            cbDecklinkOutputDownConversionAnalogOutput.Size = new System.Drawing.Size(197, 29);
            cbDecklinkOutputDownConversionAnalogOutput.TabIndex = 35;
            cbDecklinkOutputDownConversionAnalogOutput.Text = "Analog output used";
            cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutputDownConversion
            // 
            cbDecklinkOutputDownConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputDownConversion.FormattingEnabled = true;
            cbDecklinkOutputDownConversion.Items.AddRange(new object[] { "Default", "Disabled", "Letterbox 16:9", "Anamorphic", "Anamorphic center" });
            cbDecklinkOutputDownConversion.Location = new System.Drawing.Point(40, 429);
            cbDecklinkOutputDownConversion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputDownConversion.Name = "cbDecklinkOutputDownConversion";
            cbDecklinkOutputDownConversion.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputDownConversion.TabIndex = 34;
            // 
            // label337
            // 
            label337.AutoSize = true;
            label337.Location = new System.Drawing.Point(36, 398);
            label337.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label337.Name = "label337";
            label337.Size = new System.Drawing.Size(202, 25);
            label337.TabIndex = 33;
            label337.Text = "Down conversion mode";
            // 
            // cbDecklinkOutputHDTVPulldown
            // 
            cbDecklinkOutputHDTVPulldown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputHDTVPulldown.FormattingEnabled = true;
            cbDecklinkOutputHDTVPulldown.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputHDTVPulldown.Location = new System.Drawing.Point(40, 565);
            cbDecklinkOutputHDTVPulldown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputHDTVPulldown.Name = "cbDecklinkOutputHDTVPulldown";
            cbDecklinkOutputHDTVPulldown.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputHDTVPulldown.TabIndex = 32;
            // 
            // label336
            // 
            label336.AutoSize = true;
            label336.Location = new System.Drawing.Point(36, 535);
            label336.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label336.Name = "label336";
            label336.Size = new System.Drawing.Size(136, 25);
            label336.TabIndex = 31;
            label336.Text = "HDTV pulldown";
            // 
            // cbDecklinkOutputBlackToDeck
            // 
            cbDecklinkOutputBlackToDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputBlackToDeck.FormattingEnabled = true;
            cbDecklinkOutputBlackToDeck.Items.AddRange(new object[] { "Default", "None", "Digital", "Analogue" });
            cbDecklinkOutputBlackToDeck.Location = new System.Drawing.Point(40, 339);
            cbDecklinkOutputBlackToDeck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputBlackToDeck.Name = "cbDecklinkOutputBlackToDeck";
            cbDecklinkOutputBlackToDeck.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputBlackToDeck.TabIndex = 30;
            // 
            // label335
            // 
            label335.AutoSize = true;
            label335.Location = new System.Drawing.Point(36, 308);
            label335.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label335.Name = "label335";
            label335.Size = new System.Drawing.Size(116, 25);
            label335.TabIndex = 29;
            label335.Text = "Black to deck";
            // 
            // cbDecklinkOutputSingleField
            // 
            cbDecklinkOutputSingleField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputSingleField.FormattingEnabled = true;
            cbDecklinkOutputSingleField.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputSingleField.Location = new System.Drawing.Point(40, 252);
            cbDecklinkOutputSingleField.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputSingleField.Name = "cbDecklinkOutputSingleField";
            cbDecklinkOutputSingleField.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputSingleField.TabIndex = 28;
            // 
            // label334
            // 
            label334.AutoSize = true;
            label334.Location = new System.Drawing.Point(36, 221);
            label334.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label334.Name = "label334";
            label334.Size = new System.Drawing.Size(158, 25);
            label334.TabIndex = 27;
            label334.Text = "Single field output";
            // 
            // cbDecklinkOutputComponentLevels
            // 
            cbDecklinkOutputComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputComponentLevels.FormattingEnabled = true;
            cbDecklinkOutputComponentLevels.Items.AddRange(new object[] { "SMPTE", "Betacam" });
            cbDecklinkOutputComponentLevels.Location = new System.Drawing.Point(267, 339);
            cbDecklinkOutputComponentLevels.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputComponentLevels.Name = "cbDecklinkOutputComponentLevels";
            cbDecklinkOutputComponentLevels.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputComponentLevels.TabIndex = 26;
            // 
            // label333
            // 
            label333.AutoSize = true;
            label333.Location = new System.Drawing.Point(262, 308);
            label333.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label333.Name = "label333";
            label333.Size = new System.Drawing.Size(155, 25);
            label333.TabIndex = 25;
            label333.Text = "Component levels";
            // 
            // cbDecklinkOutputNTSC
            // 
            cbDecklinkOutputNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputNTSC.FormattingEnabled = true;
            cbDecklinkOutputNTSC.Items.AddRange(new object[] { "USA", "Japan" });
            cbDecklinkOutputNTSC.Location = new System.Drawing.Point(267, 252);
            cbDecklinkOutputNTSC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputNTSC.Name = "cbDecklinkOutputNTSC";
            cbDecklinkOutputNTSC.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputNTSC.TabIndex = 24;
            // 
            // label332
            // 
            label332.AutoSize = true;
            label332.Location = new System.Drawing.Point(262, 221);
            label332.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label332.Name = "label332";
            label332.Size = new System.Drawing.Size(130, 25);
            label332.TabIndex = 23;
            label332.Text = "NTSC standard";
            // 
            // cbDecklinkOutputDualLink
            // 
            cbDecklinkOutputDualLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputDualLink.FormattingEnabled = true;
            cbDecklinkOutputDualLink.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputDualLink.Location = new System.Drawing.Point(40, 165);
            cbDecklinkOutputDualLink.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputDualLink.Name = "cbDecklinkOutputDualLink";
            cbDecklinkOutputDualLink.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputDualLink.TabIndex = 22;
            // 
            // label331
            // 
            label331.AutoSize = true;
            label331.Location = new System.Drawing.Point(36, 135);
            label331.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label331.Name = "label331";
            label331.Size = new System.Drawing.Size(132, 25);
            label331.TabIndex = 21;
            label331.Text = "Dual link mode";
            // 
            // cbDecklinkOutputAnalog
            // 
            cbDecklinkOutputAnalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputAnalog.FormattingEnabled = true;
            cbDecklinkOutputAnalog.Items.AddRange(new object[] { "Auto", "Component", "Composite", "S-Video" });
            cbDecklinkOutputAnalog.Location = new System.Drawing.Point(267, 165);
            cbDecklinkOutputAnalog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutputAnalog.Name = "cbDecklinkOutputAnalog";
            cbDecklinkOutputAnalog.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputAnalog.TabIndex = 20;
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Location = new System.Drawing.Point(262, 135);
            label87.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label87.Name = "label87";
            label87.Size = new System.Drawing.Size(128, 25);
            label87.TabIndex = 19;
            label87.Text = "Analog output";
            // 
            // cbDecklinkDV
            // 
            cbDecklinkDV.AutoSize = true;
            cbDecklinkDV.Location = new System.Drawing.Point(56, 72);
            cbDecklinkDV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkDV.Name = "cbDecklinkDV";
            cbDecklinkDV.Size = new System.Drawing.Size(121, 29);
            cbDecklinkDV.TabIndex = 3;
            cbDecklinkDV.Text = "DV output";
            cbDecklinkDV.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutput
            // 
            cbDecklinkOutput.AutoSize = true;
            cbDecklinkOutput.Location = new System.Drawing.Point(24, 29);
            cbDecklinkOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDecklinkOutput.Name = "cbDecklinkOutput";
            cbDecklinkOutput.Size = new System.Drawing.Size(281, 29);
            cbDecklinkOutput.TabIndex = 2;
            cbDecklinkOutput.Text = "Enable output to Decklink card";
            cbDecklinkOutput.UseVisualStyleBackColor = true;
            // 
            // tabPage47
            // 
            tabPage47.Controls.Add(groupBox48);
            tabPage47.Controls.Add(groupBox47);
            tabPage47.Controls.Add(groupBox43);
            tabPage47.Location = new System.Drawing.Point(4, 34);
            tabPage47.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage47.Name = "tabPage47";
            tabPage47.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage47.Size = new System.Drawing.Size(509, 962);
            tabPage47.TabIndex = 12;
            tabPage47.Text = "Encryption";
            tabPage47.UseVisualStyleBackColor = true;
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
            groupBox48.Location = new System.Drawing.Point(27, 372);
            groupBox48.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox48.Name = "groupBox48";
            groupBox48.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox48.Size = new System.Drawing.Size(449, 431);
            groupBox48.TabIndex = 11;
            groupBox48.TabStop = false;
            groupBox48.Text = "Encryption key type";
            // 
            // label343
            // 
            label343.AutoSize = true;
            label343.Location = new System.Drawing.Point(56, 382);
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
            rbEncryptionKeyBinary.Location = new System.Drawing.Point(23, 294);
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
            rbEncryptionKeyFile.Location = new System.Drawing.Point(23, 179);
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
            rbEncryptionKeyString.Location = new System.Drawing.Point(23, 54);
            rbEncryptionKeyString.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionKeyString.Name = "rbEncryptionKeyString";
            rbEncryptionKeyString.Size = new System.Drawing.Size(83, 29);
            rbEncryptionKeyString.TabIndex = 0;
            rbEncryptionKeyString.TabStop = true;
            rbEncryptionKeyString.Text = "String";
            rbEncryptionKeyString.UseVisualStyleBackColor = true;
            // 
            // groupBox47
            // 
            groupBox47.Controls.Add(rbEncryptionModeAES256);
            groupBox47.Controls.Add(rbEncryptionModeAES128);
            groupBox47.Location = new System.Drawing.Point(27, 31);
            groupBox47.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox47.Name = "groupBox47";
            groupBox47.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox47.Size = new System.Drawing.Size(449, 160);
            groupBox47.TabIndex = 10;
            groupBox47.TabStop = false;
            groupBox47.Text = "Method";
            // 
            // rbEncryptionModeAES256
            // 
            rbEncryptionModeAES256.AutoSize = true;
            rbEncryptionModeAES256.Checked = true;
            rbEncryptionModeAES256.Location = new System.Drawing.Point(23, 98);
            rbEncryptionModeAES256.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionModeAES256.Name = "rbEncryptionModeAES256";
            rbEncryptionModeAES256.Size = new System.Drawing.Size(325, 29);
            rbEncryptionModeAES256.TabIndex = 1;
            rbEncryptionModeAES256.TabStop = true;
            rbEncryptionModeAES256.Text = "AES-256 (v9 encryption SDK output)";
            rbEncryptionModeAES256.UseVisualStyleBackColor = true;
            // 
            // rbEncryptionModeAES128
            // 
            rbEncryptionModeAES128.AutoSize = true;
            rbEncryptionModeAES128.Location = new System.Drawing.Point(23, 54);
            rbEncryptionModeAES128.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptionModeAES128.Name = "rbEncryptionModeAES128";
            rbEncryptionModeAES128.Size = new System.Drawing.Size(325, 29);
            rbEncryptionModeAES128.TabIndex = 0;
            rbEncryptionModeAES128.Text = "AES-128 (v8 encryption SDK output)";
            rbEncryptionModeAES128.UseVisualStyleBackColor = true;
            // 
            // groupBox43
            // 
            groupBox43.Controls.Add(rbEncryptedH264CUDA);
            groupBox43.Controls.Add(rbEncryptedH264SW);
            groupBox43.Location = new System.Drawing.Point(27, 202);
            groupBox43.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox43.Name = "groupBox43";
            groupBox43.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox43.Size = new System.Drawing.Size(449, 160);
            groupBox43.TabIndex = 9;
            groupBox43.TabStop = false;
            groupBox43.Text = "Video / audio format";
            // 
            // rbEncryptedH264CUDA
            // 
            rbEncryptedH264CUDA.AutoSize = true;
            rbEncryptedH264CUDA.Enabled = false;
            rbEncryptedH264CUDA.Location = new System.Drawing.Point(23, 98);
            rbEncryptedH264CUDA.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptedH264CUDA.Name = "rbEncryptedH264CUDA";
            rbEncryptedH264CUDA.Size = new System.Drawing.Size(425, 29);
            rbEncryptedH264CUDA.TabIndex = 7;
            rbEncryptedH264CUDA.Text = "[Deprecated] Use MP4 H264 CUDA / AAC format";
            rbEncryptedH264CUDA.UseVisualStyleBackColor = true;
            // 
            // rbEncryptedH264SW
            // 
            rbEncryptedH264SW.AutoSize = true;
            rbEncryptedH264SW.Checked = true;
            rbEncryptedH264SW.Location = new System.Drawing.Point(23, 54);
            rbEncryptedH264SW.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbEncryptedH264SW.Name = "rbEncryptedH264SW";
            rbEncryptedH264SW.Size = new System.Drawing.Size(324, 29);
            rbEncryptedH264SW.TabIndex = 6;
            rbEncryptedH264SW.TabStop = true;
            rbEncryptedH264SW.Text = "Use MP4 H264 / ACC output format";
            rbEncryptedH264SW.UseVisualStyleBackColor = true;
            // 
            // tabPage79
            // 
            tabPage79.Controls.Add(TabControl32);
            tabPage79.Controls.Add(cbTagEnabled);
            tabPage79.Location = new System.Drawing.Point(4, 34);
            tabPage79.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage79.Name = "tabPage79";
            tabPage79.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage79.Size = new System.Drawing.Size(509, 962);
            tabPage79.TabIndex = 14;
            tabPage79.Text = "Tags";
            tabPage79.UseVisualStyleBackColor = true;
            // 
            // TabControl32
            // 
            TabControl32.Controls.Add(TabPage142);
            TabControl32.Controls.Add(TabPage143);
            TabControl32.Location = new System.Drawing.Point(9, 89);
            TabControl32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabControl32.Name = "TabControl32";
            TabControl32.SelectedIndex = 0;
            TabControl32.Size = new System.Drawing.Size(487, 831);
            TabControl32.TabIndex = 5;
            // 
            // TabPage142
            // 
            TabPage142.Controls.Add(edTagTrackID);
            TabPage142.Controls.Add(Label496);
            TabPage142.Controls.Add(edTagYear);
            TabPage142.Controls.Add(Label495);
            TabPage142.Controls.Add(edTagComment);
            TabPage142.Controls.Add(Label493);
            TabPage142.Controls.Add(edTagAlbum);
            TabPage142.Controls.Add(Label491);
            TabPage142.Controls.Add(edTagArtists);
            TabPage142.Controls.Add(label494);
            TabPage142.Controls.Add(edTagCopyright);
            TabPage142.Controls.Add(label497);
            TabPage142.Controls.Add(edTagTitle);
            TabPage142.Controls.Add(label498);
            TabPage142.Location = new System.Drawing.Point(4, 34);
            TabPage142.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage142.Name = "TabPage142";
            TabPage142.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage142.Size = new System.Drawing.Size(479, 793);
            TabPage142.TabIndex = 0;
            TabPage142.Text = "Common";
            TabPage142.UseVisualStyleBackColor = true;
            // 
            // edTagTrackID
            // 
            edTagTrackID.Location = new System.Drawing.Point(27, 398);
            edTagTrackID.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagTrackID.Name = "edTagTrackID";
            edTagTrackID.Size = new System.Drawing.Size(102, 31);
            edTagTrackID.TabIndex = 13;
            edTagTrackID.Text = "1";
            // 
            // Label496
            // 
            Label496.AutoSize = true;
            Label496.Location = new System.Drawing.Point(22, 369);
            Label496.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label496.Name = "Label496";
            Label496.Size = new System.Drawing.Size(74, 25);
            Label496.TabIndex = 12;
            Label496.Text = "Track ID";
            // 
            // edTagYear
            // 
            edTagYear.Location = new System.Drawing.Point(27, 579);
            edTagYear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagYear.Name = "edTagYear";
            edTagYear.Size = new System.Drawing.Size(102, 31);
            edTagYear.TabIndex = 11;
            edTagYear.Text = "2015";
            // 
            // Label495
            // 
            Label495.AutoSize = true;
            Label495.Location = new System.Drawing.Point(22, 550);
            Label495.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label495.Name = "Label495";
            Label495.Size = new System.Drawing.Size(44, 25);
            Label495.TabIndex = 10;
            Label495.Text = "Year";
            // 
            // edTagComment
            // 
            edTagComment.Location = new System.Drawing.Point(27, 308);
            edTagComment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagComment.Name = "edTagComment";
            edTagComment.Size = new System.Drawing.Size(401, 31);
            edTagComment.TabIndex = 9;
            edTagComment.Text = "No comments";
            // 
            // Label493
            // 
            Label493.AutoSize = true;
            Label493.Location = new System.Drawing.Point(22, 279);
            Label493.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label493.Name = "Label493";
            Label493.Size = new System.Drawing.Size(91, 25);
            Label493.TabIndex = 8;
            Label493.Text = "Comment";
            // 
            // edTagAlbum
            // 
            edTagAlbum.Location = new System.Drawing.Point(27, 222);
            edTagAlbum.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagAlbum.Name = "edTagAlbum";
            edTagAlbum.Size = new System.Drawing.Size(401, 31);
            edTagAlbum.TabIndex = 7;
            edTagAlbum.Text = "Sample album";
            // 
            // Label491
            // 
            Label491.AutoSize = true;
            Label491.Location = new System.Drawing.Point(22, 194);
            Label491.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label491.Name = "Label491";
            Label491.Size = new System.Drawing.Size(65, 25);
            Label491.TabIndex = 6;
            Label491.Text = "Album";
            // 
            // edTagArtists
            // 
            edTagArtists.Location = new System.Drawing.Point(27, 139);
            edTagArtists.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagArtists.Name = "edTagArtists";
            edTagArtists.Size = new System.Drawing.Size(401, 31);
            edTagArtists.TabIndex = 5;
            edTagArtists.Text = "Sample artist";
            // 
            // label494
            // 
            label494.AutoSize = true;
            label494.Location = new System.Drawing.Point(22, 110);
            label494.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label494.Name = "label494";
            label494.Size = new System.Drawing.Size(62, 25);
            label494.TabIndex = 4;
            label494.Text = "Artists";
            // 
            // edTagCopyright
            // 
            edTagCopyright.Location = new System.Drawing.Point(27, 490);
            edTagCopyright.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagCopyright.Name = "edTagCopyright";
            edTagCopyright.Size = new System.Drawing.Size(401, 31);
            edTagCopyright.TabIndex = 3;
            edTagCopyright.Text = "VisioForge";
            // 
            // label497
            // 
            label497.AutoSize = true;
            label497.Location = new System.Drawing.Point(22, 461);
            label497.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label497.Name = "label497";
            label497.Size = new System.Drawing.Size(91, 25);
            label497.TabIndex = 2;
            label497.Text = "Copyright";
            // 
            // edTagTitle
            // 
            edTagTitle.Location = new System.Drawing.Point(27, 56);
            edTagTitle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagTitle.Name = "edTagTitle";
            edTagTitle.Size = new System.Drawing.Size(401, 31);
            edTagTitle.TabIndex = 1;
            edTagTitle.Text = "Sample output file";
            // 
            // label498
            // 
            label498.AutoSize = true;
            label498.Location = new System.Drawing.Point(22, 28);
            label498.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label498.Name = "label498";
            label498.Size = new System.Drawing.Size(44, 25);
            label498.TabIndex = 0;
            label498.Text = "Title";
            // 
            // TabPage143
            // 
            TabPage143.Controls.Add(imgTagCover);
            TabPage143.Controls.Add(Label499);
            TabPage143.Controls.Add(label500);
            TabPage143.Controls.Add(edTagLyrics);
            TabPage143.Controls.Add(label501);
            TabPage143.Controls.Add(cbTagGenre);
            TabPage143.Controls.Add(label502);
            TabPage143.Controls.Add(edTagComposers);
            TabPage143.Controls.Add(label503);
            TabPage143.Location = new System.Drawing.Point(4, 34);
            TabPage143.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage143.Name = "TabPage143";
            TabPage143.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage143.Size = new System.Drawing.Size(479, 793);
            TabPage143.TabIndex = 1;
            TabPage143.Text = "Special";
            TabPage143.UseVisualStyleBackColor = true;
            // 
            // imgTagCover
            // 
            imgTagCover.BackColor = System.Drawing.Color.DimGray;
            imgTagCover.Location = new System.Drawing.Point(24, 342);
            imgTagCover.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            imgTagCover.Name = "imgTagCover";
            imgTagCover.Size = new System.Drawing.Size(280, 264);
            imgTagCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgTagCover.TabIndex = 16;
            imgTagCover.TabStop = false;
            imgTagCover.Click += imgTagCover_Click;
            // 
            // Label499
            // 
            Label499.AutoSize = true;
            Label499.Location = new System.Drawing.Point(20, 311);
            Label499.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label499.Name = "Label499";
            Label499.Size = new System.Drawing.Size(177, 25);
            Label499.TabIndex = 15;
            Label499.Text = "Cover (click to select)";
            // 
            // label500
            // 
            label500.AutoSize = true;
            label500.Location = new System.Drawing.Point(71, 642);
            label500.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label500.Name = "label500";
            label500.Size = new System.Drawing.Size(324, 25);
            label500.TabIndex = 14;
            label500.Text = "Many other tags are available using API";
            // 
            // edTagLyrics
            // 
            edTagLyrics.Location = new System.Drawing.Point(24, 244);
            edTagLyrics.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagLyrics.Name = "edTagLyrics";
            edTagLyrics.Size = new System.Drawing.Size(401, 31);
            edTagLyrics.TabIndex = 13;
            edTagLyrics.Text = "Yo-ho-ho and the buttle of rum";
            // 
            // label501
            // 
            label501.AutoSize = true;
            label501.Location = new System.Drawing.Point(20, 215);
            label501.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label501.Name = "label501";
            label501.Size = new System.Drawing.Size(54, 25);
            label501.TabIndex = 12;
            label501.Text = "Lyrics";
            // 
            // cbTagGenre
            // 
            cbTagGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTagGenre.FormattingEnabled = true;
            cbTagGenre.Location = new System.Drawing.Point(24, 146);
            cbTagGenre.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbTagGenre.Name = "cbTagGenre";
            cbTagGenre.Size = new System.Drawing.Size(401, 33);
            cbTagGenre.TabIndex = 11;
            // 
            // label502
            // 
            label502.AutoSize = true;
            label502.Location = new System.Drawing.Point(20, 115);
            label502.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label502.Name = "label502";
            label502.Size = new System.Drawing.Size(58, 25);
            label502.TabIndex = 10;
            label502.Text = "Genre";
            // 
            // edTagComposers
            // 
            edTagComposers.Location = new System.Drawing.Point(24, 56);
            edTagComposers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edTagComposers.Name = "edTagComposers";
            edTagComposers.Size = new System.Drawing.Size(401, 31);
            edTagComposers.TabIndex = 9;
            edTagComposers.Text = "Sample composer";
            // 
            // label503
            // 
            label503.AutoSize = true;
            label503.Location = new System.Drawing.Point(20, 28);
            label503.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label503.Name = "label503";
            label503.Size = new System.Drawing.Size(103, 25);
            label503.TabIndex = 8;
            label503.Text = "Composers";
            // 
            // cbTagEnabled
            // 
            cbTagEnabled.AutoSize = true;
            cbTagEnabled.Location = new System.Drawing.Point(23, 31);
            cbTagEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbTagEnabled.Name = "cbTagEnabled";
            cbTagEnabled.Size = new System.Drawing.Size(228, 29);
            cbTagEnabled.TabIndex = 4;
            cbTagEnabled.Text = "Write tags to output file";
            cbTagEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage24
            // 
            tabPage24.Controls.Add(cbVUMeter);
            tabPage24.Controls.Add(tbVUMeterBoost);
            tabPage24.Controls.Add(label382);
            tabPage24.Controls.Add(label381);
            tabPage24.Controls.Add(tbVUMeterAmplification);
            tabPage24.Controls.Add(cbVUMeterPro);
            tabPage24.Controls.Add(peakMeterCtrl1);
            tabPage24.Controls.Add(waveformPainter2);
            tabPage24.Controls.Add(waveformPainter1);
            tabPage24.Controls.Add(volumeMeter2);
            tabPage24.Controls.Add(volumeMeter1);
            tabPage24.Location = new System.Drawing.Point(4, 34);
            tabPage24.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage24.Name = "tabPage24";
            tabPage24.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage24.Size = new System.Drawing.Size(509, 962);
            tabPage24.TabIndex = 16;
            tabPage24.Text = "Audio output";
            tabPage24.UseVisualStyleBackColor = true;
            // 
            // cbVUMeter
            // 
            cbVUMeter.AutoSize = true;
            cbVUMeter.Location = new System.Drawing.Point(30, 29);
            cbVUMeter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVUMeter.Name = "cbVUMeter";
            cbVUMeter.Size = new System.Drawing.Size(169, 29);
            cbVUMeter.TabIndex = 125;
            cbVUMeter.Text = "Enable VU Meter";
            cbVUMeter.UseVisualStyleBackColor = true;
            // 
            // tbVUMeterBoost
            // 
            tbVUMeterBoost.Location = new System.Drawing.Point(296, 585);
            tbVUMeterBoost.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVUMeterBoost.Maximum = 30;
            tbVUMeterBoost.Minimum = 1;
            tbVUMeterBoost.Name = "tbVUMeterBoost";
            tbVUMeterBoost.Size = new System.Drawing.Size(173, 69);
            tbVUMeterBoost.TabIndex = 124;
            tbVUMeterBoost.Value = 10;
            // 
            // label382
            // 
            label382.AutoSize = true;
            label382.Location = new System.Drawing.Point(290, 554);
            label382.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label382.Name = "label382";
            label382.Size = new System.Drawing.Size(118, 25);
            label382.TabIndex = 123;
            label382.Text = "Meters boost";
            // 
            // label381
            // 
            label381.AutoSize = true;
            label381.Location = new System.Drawing.Point(43, 554);
            label381.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label381.Name = "label381";
            label381.Size = new System.Drawing.Size(209, 25);
            label381.TabIndex = 119;
            label381.Text = "Volume amplification (%)";
            // 
            // tbVUMeterAmplification
            // 
            tbVUMeterAmplification.Location = new System.Drawing.Point(49, 585);
            tbVUMeterAmplification.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbVUMeterAmplification.Maximum = 100;
            tbVUMeterAmplification.Name = "tbVUMeterAmplification";
            tbVUMeterAmplification.Size = new System.Drawing.Size(176, 69);
            tbVUMeterAmplification.TabIndex = 118;
            tbVUMeterAmplification.Value = 100;
            // 
            // cbVUMeterPro
            // 
            cbVUMeterPro.AutoSize = true;
            cbVUMeterPro.Location = new System.Drawing.Point(30, 256);
            cbVUMeterPro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVUMeterPro.Name = "cbVUMeterPro";
            cbVUMeterPro.Size = new System.Drawing.Size(201, 29);
            cbVUMeterPro.TabIndex = 117;
            cbVUMeterPro.Text = "Enable VU meter Pro";
            cbVUMeterPro.UseVisualStyleBackColor = true;
            // 
            // peakMeterCtrl1
            // 
            peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(255, 150, 150);
            peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow;
            peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(255, 255, 150);
            peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green;
            peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(150, 255, 150);
            peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb(180, 180, 180);
            peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro;
            peakMeterCtrl1.Location = new System.Drawing.Point(229, 29);
            peakMeterCtrl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            peakMeterCtrl1.Name = "peakMeterCtrl1";
            peakMeterCtrl1.Size = new System.Drawing.Size(176, 118);
            peakMeterCtrl1.TabIndex = 126;
            peakMeterCtrl1.Text = "peakMeterCtrl1";
            // 
            // waveformPainter2
            // 
            waveformPainter2.Boost = 1F;
            waveformPainter2.Location = new System.Drawing.Point(178, 428);
            waveformPainter2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            waveformPainter2.Name = "waveformPainter2";
            waveformPainter2.Size = new System.Drawing.Size(290, 115);
            waveformPainter2.TabIndex = 122;
            waveformPainter2.Text = "waveformPainter2";
            // 
            // waveformPainter1
            // 
            waveformPainter1.Boost = 1F;
            waveformPainter1.Location = new System.Drawing.Point(178, 300);
            waveformPainter1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            waveformPainter1.Name = "waveformPainter1";
            waveformPainter1.Size = new System.Drawing.Size(290, 115);
            waveformPainter1.TabIndex = 121;
            waveformPainter1.Text = "waveformPainter1";
            // 
            // volumeMeter2
            // 
            volumeMeter2.Amplitude = 0F;
            volumeMeter2.BackColor = System.Drawing.Color.LightGray;
            volumeMeter2.Boost = 1F;
            volumeMeter2.Location = new System.Drawing.Point(96, 300);
            volumeMeter2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            volumeMeter2.MaxDb = 18F;
            volumeMeter2.MinDb = -60F;
            volumeMeter2.Name = "volumeMeter2";
            volumeMeter2.Size = new System.Drawing.Size(37, 242);
            volumeMeter2.TabIndex = 120;
            // 
            // volumeMeter1
            // 
            volumeMeter1.Amplitude = 0F;
            volumeMeter1.BackColor = System.Drawing.Color.LightGray;
            volumeMeter1.Boost = 1F;
            volumeMeter1.Location = new System.Drawing.Point(49, 300);
            volumeMeter1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            volumeMeter1.MaxDb = 18F;
            volumeMeter1.MinDb = -60F;
            volumeMeter1.Name = "volumeMeter1";
            volumeMeter1.Size = new System.Drawing.Size(37, 242);
            volumeMeter1.TabIndex = 116;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(1064, 1196);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(97, 44);
            btStart.TabIndex = 25;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(1177, 1196);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(97, 44);
            btStop.TabIndex = 26;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // OpenDialog1
            // 
            OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            SaveDialog1.Filter = "AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|All files  (*.*)| *.*";
            // 
            // FontDialog1
            // 
            FontDialog1.Color = System.Drawing.Color.White;
            FontDialog1.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            FontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // tbSeeking
            // 
            tbSeeking.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            tbSeeking.Location = new System.Drawing.Point(557, 1196);
            tbSeeking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSeeking.Name = "tbSeeking";
            tbSeeking.Size = new System.Drawing.Size(224, 69);
            tbSeeking.TabIndex = 46;
            tbSeeking.Scroll += tbSeeking_Scroll;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(407, 1044);
            linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(130, 25);
            linkLabel1.TabIndex = 77;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch tutorials";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            openFileDialog3.Filter = "Windows Media profile|*.prx";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ProgressBar1.Location = new System.Drawing.Point(791, 1196);
            ProgressBar1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new System.Drawing.Size(263, 42);
            ProgressBar1.TabIndex = 9;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage52);
            tabControl3.Controls.Add(tabPage53);
            tabControl3.Controls.Add(tabPage54);
            tabControl3.Controls.Add(tabPage74);
            tabControl3.Location = new System.Drawing.Point(551, 22);
            tabControl3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new System.Drawing.Size(729, 585);
            tabControl3.TabIndex = 80;
            // 
            // tabPage52
            // 
            tabPage52.Controls.Add(linkLabelDecoders);
            tabPage52.Controls.Add(groupBox7);
            tabPage52.Controls.Add(label50);
            tabPage52.Controls.Add(groupBox6);
            tabPage52.Controls.Add(btClearList);
            tabPage52.Controls.Add(btAddInputFile);
            tabPage52.Controls.Add(lbFiles);
            tabPage52.Controls.Add(label10);
            tabPage52.Location = new System.Drawing.Point(4, 34);
            tabPage52.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage52.Name = "tabPage52";
            tabPage52.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage52.Size = new System.Drawing.Size(721, 547);
            tabPage52.TabIndex = 0;
            tabPage52.Text = "Edit";
            tabPage52.UseVisualStyleBackColor = true;
            // 
            // linkLabelDecoders
            // 
            linkLabelDecoders.AutoSize = true;
            linkLabelDecoders.Location = new System.Drawing.Point(3, 500);
            linkLabelDecoders.Name = "linkLabelDecoders";
            linkLabelDecoders.Size = new System.Drawing.Size(706, 25);
            linkLabelDecoders.TabIndex = 57;
            linkLabelDecoders.TabStop = true;
            linkLabelDecoders.Text = "[NuGet only] Install decoders to edit MP4 files, or if you can see errors while adding files";
            linkLabelDecoders.LinkClicked += linkLabelDecoders_LinkClicked;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label72);
            groupBox7.Controls.Add(edInsertTime);
            groupBox7.Controls.Add(label73);
            groupBox7.Controls.Add(cbInsertAfterPreviousFile);
            groupBox7.Location = new System.Drawing.Point(422, 219);
            groupBox7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox7.Size = new System.Drawing.Size(256, 265);
            groupBox7.TabIndex = 56;
            groupBox7.TabStop = false;
            groupBox7.Text = "Timeline";
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Location = new System.Drawing.Point(193, 86);
            label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label72.Name = "label72";
            label72.Size = new System.Drawing.Size(36, 25);
            label72.TabIndex = 42;
            label72.Text = "ms";
            // 
            // edInsertTime
            // 
            edInsertTime.Location = new System.Drawing.Point(127, 81);
            edInsertTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edInsertTime.Name = "edInsertTime";
            edInsertTime.Size = new System.Drawing.Size(54, 31);
            edInsertTime.TabIndex = 41;
            edInsertTime.Text = "4000";
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Location = new System.Drawing.Point(20, 86);
            label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label73.Name = "label73";
            label73.Size = new System.Drawing.Size(96, 25);
            label73.TabIndex = 40;
            label73.Text = "Insert time";
            // 
            // cbInsertAfterPreviousFile
            // 
            cbInsertAfterPreviousFile.AutoSize = true;
            cbInsertAfterPreviousFile.Checked = true;
            cbInsertAfterPreviousFile.CheckState = System.Windows.Forms.CheckState.Checked;
            cbInsertAfterPreviousFile.Location = new System.Drawing.Point(20, 36);
            cbInsertAfterPreviousFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbInsertAfterPreviousFile.Name = "cbInsertAfterPreviousFile";
            cbInsertAfterPreviousFile.Size = new System.Drawing.Size(224, 29);
            cbInsertAfterPreviousFile.TabIndex = 39;
            cbInsertAfterPreviousFile.Text = "Insert after previous file";
            cbInsertAfterPreviousFile.UseVisualStyleBackColor = true;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new System.Drawing.Point(10, 178);
            label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(427, 25);
            label50.TabIndex = 55;
            label50.Text = "You must set this parameters before you add the file";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lbSpeed);
            groupBox6.Controls.Add(label42);
            groupBox6.Controls.Add(label37);
            groupBox6.Controls.Add(edStopTime);
            groupBox6.Controls.Add(label38);
            groupBox6.Controls.Add(label36);
            groupBox6.Controls.Add(edStartTime);
            groupBox6.Controls.Add(label35);
            groupBox6.Controls.Add(cbAddFullFile);
            groupBox6.Controls.Add(tbSpeed);
            groupBox6.Location = new System.Drawing.Point(16, 219);
            groupBox6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox6.Size = new System.Drawing.Size(397, 265);
            groupBox6.TabIndex = 54;
            groupBox6.TabStop = false;
            groupBox6.Text = "Input file";
            // 
            // lbSpeed
            // 
            lbSpeed.AutoSize = true;
            lbSpeed.Location = new System.Drawing.Point(333, 142);
            lbSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbSpeed.Name = "lbSpeed";
            lbSpeed.Size = new System.Drawing.Size(57, 25);
            lbSpeed.TabIndex = 44;
            lbSpeed.Text = "100%";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(10, 142);
            label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(134, 25);
            label42.TabIndex = 42;
            label42.Text = "Playback speed";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(363, 86);
            label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(36, 25);
            label37.TabIndex = 41;
            label37.Text = "ms";
            // 
            // edStopTime
            // 
            edStopTime.Location = new System.Drawing.Point(291, 81);
            edStopTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edStopTime.Name = "edStopTime";
            edStopTime.Size = new System.Drawing.Size(64, 31);
            edStopTime.TabIndex = 40;
            edStopTime.Text = "5000";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new System.Drawing.Point(207, 86);
            label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(89, 25);
            label38.TabIndex = 39;
            label38.Text = "Stop time";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(176, 86);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(36, 25);
            label36.TabIndex = 38;
            label36.Text = "ms";
            // 
            // edStartTime
            // 
            edStartTime.Location = new System.Drawing.Point(104, 81);
            edStartTime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edStartTime.Name = "edStartTime";
            edStartTime.Size = new System.Drawing.Size(64, 31);
            edStartTime.TabIndex = 37;
            edStartTime.Text = "0";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(10, 86);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(88, 25);
            label35.TabIndex = 36;
            label35.Text = "Start time";
            // 
            // cbAddFullFile
            // 
            cbAddFullFile.AutoSize = true;
            cbAddFullFile.Checked = true;
            cbAddFullFile.CheckState = System.Windows.Forms.CheckState.Checked;
            cbAddFullFile.Location = new System.Drawing.Point(20, 36);
            cbAddFullFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAddFullFile.Name = "cbAddFullFile";
            cbAddFullFile.Size = new System.Drawing.Size(129, 29);
            cbAddFullFile.TabIndex = 35;
            cbAddFullFile.Text = "Add full file";
            cbAddFullFile.UseVisualStyleBackColor = true;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new System.Drawing.Point(169, 131);
            tbSpeed.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSpeed.Maximum = 400;
            tbSpeed.Minimum = 10;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new System.Drawing.Size(164, 69);
            tbSpeed.TabIndex = 43;
            tbSpeed.Value = 100;
            tbSpeed.Scroll += tbSpeed_Scroll;
            // 
            // btClearList
            // 
            btClearList.Location = new System.Drawing.Point(560, 108);
            btClearList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btClearList.Name = "btClearList";
            btClearList.Size = new System.Drawing.Size(107, 44);
            btClearList.TabIndex = 53;
            btClearList.Text = "Clear";
            btClearList.UseVisualStyleBackColor = true;
            btClearList.Click += btClearList_Click;
            // 
            // btAddInputFile
            // 
            btAddInputFile.Location = new System.Drawing.Point(560, 52);
            btAddInputFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAddInputFile.Name = "btAddInputFile";
            btAddInputFile.Size = new System.Drawing.Size(107, 44);
            btAddInputFile.TabIndex = 52;
            btAddInputFile.Text = "Add";
            btAddInputFile.UseVisualStyleBackColor = true;
            btAddInputFile.Click += btAddInputFile_Click;
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 25;
            lbFiles.Location = new System.Drawing.Point(16, 52);
            lbFiles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new System.Drawing.Size(533, 104);
            lbFiles.TabIndex = 51;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(10, 11);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(90, 25);
            label10.TabIndex = 50;
            label10.Text = "Input files";
            // 
            // tabPage53
            // 
            tabPage53.Controls.Add(label134);
            tabPage53.Controls.Add(btSelectOutputCut);
            tabPage53.Controls.Add(edOutputFileCut);
            tabPage53.Controls.Add(label131);
            tabPage53.Controls.Add(btStopCut);
            tabPage53.Controls.Add(btStartCut);
            tabPage53.Controls.Add(label31);
            tabPage53.Controls.Add(btAddInputFile2);
            tabPage53.Controls.Add(edSourceFileToCut);
            tabPage53.Controls.Add(label30);
            tabPage53.Controls.Add(label26);
            tabPage53.Controls.Add(edStopTimeCut);
            tabPage53.Controls.Add(label27);
            tabPage53.Controls.Add(label28);
            tabPage53.Controls.Add(edStartTimeCut);
            tabPage53.Controls.Add(label29);
            tabPage53.Location = new System.Drawing.Point(4, 34);
            tabPage53.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage53.Name = "tabPage53";
            tabPage53.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage53.Size = new System.Drawing.Size(721, 547);
            tabPage53.TabIndex = 1;
            tabPage53.Text = "Cut file (w/o reencoding)";
            tabPage53.UseVisualStyleBackColor = true;
            // 
            // label134
            // 
            label134.AutoSize = true;
            label134.Location = new System.Drawing.Point(30, 404);
            label134.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label134.Name = "label134";
            label134.Size = new System.Drawing.Size(377, 25);
            label134.TabIndex = 57;
            label134.Text = "Better to specify start time based on keyframe";
            // 
            // btSelectOutputCut
            // 
            btSelectOutputCut.Location = new System.Drawing.Point(616, 206);
            btSelectOutputCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectOutputCut.Name = "btSelectOutputCut";
            btSelectOutputCut.Size = new System.Drawing.Size(40, 44);
            btSelectOutputCut.TabIndex = 56;
            btSelectOutputCut.Text = "...";
            btSelectOutputCut.UseVisualStyleBackColor = true;
            btSelectOutputCut.Click += btSelectOutputCut_Click;
            // 
            // edOutputFileCut
            // 
            edOutputFileCut.Location = new System.Drawing.Point(140, 210);
            edOutputFileCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOutputFileCut.Name = "edOutputFileCut";
            edOutputFileCut.Size = new System.Drawing.Size(462, 31);
            edOutputFileCut.TabIndex = 55;
            edOutputFileCut.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label131
            // 
            label131.AutoSize = true;
            label131.Location = new System.Drawing.Point(30, 215);
            label131.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label131.Name = "label131";
            label131.Size = new System.Drawing.Size(97, 25);
            label131.TabIndex = 54;
            label131.Text = "Output file";
            // 
            // btStopCut
            // 
            btStopCut.Location = new System.Drawing.Point(167, 321);
            btStopCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStopCut.Name = "btStopCut";
            btStopCut.Size = new System.Drawing.Size(124, 44);
            btStopCut.TabIndex = 53;
            btStopCut.Text = "Stop";
            btStopCut.UseVisualStyleBackColor = true;
            btStopCut.Click += btStopCut_Click;
            // 
            // btStartCut
            // 
            btStartCut.Location = new System.Drawing.Point(31, 321);
            btStartCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStartCut.Name = "btStartCut";
            btStartCut.Size = new System.Drawing.Size(124, 44);
            btStartCut.TabIndex = 52;
            btStartCut.Text = "Start";
            btStartCut.UseVisualStyleBackColor = true;
            btStartCut.Click += btStartCut_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(136, 146);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(312, 25);
            label31.TabIndex = 51;
            label31.Text = "Specify time before adding source file";
            // 
            // btAddInputFile2
            // 
            btAddInputFile2.Location = new System.Drawing.Point(616, 21);
            btAddInputFile2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAddInputFile2.Name = "btAddInputFile2";
            btAddInputFile2.Size = new System.Drawing.Size(40, 44);
            btAddInputFile2.TabIndex = 50;
            btAddInputFile2.Text = "...";
            btAddInputFile2.UseVisualStyleBackColor = true;
            btAddInputFile2.Click += btAddInputFile2_Click;
            // 
            // edSourceFileToCut
            // 
            edSourceFileToCut.Location = new System.Drawing.Point(140, 25);
            edSourceFileToCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edSourceFileToCut.Name = "edSourceFileToCut";
            edSourceFileToCut.Size = new System.Drawing.Size(462, 31);
            edSourceFileToCut.TabIndex = 49;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(30, 31);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(94, 25);
            label30.TabIndex = 48;
            label30.Text = "Source file";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(487, 94);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(36, 25);
            label26.TabIndex = 47;
            label26.Text = "ms";
            // 
            // edStopTimeCut
            // 
            edStopTimeCut.Location = new System.Drawing.Point(400, 90);
            edStopTimeCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edStopTimeCut.Name = "edStopTimeCut";
            edStopTimeCut.Size = new System.Drawing.Size(74, 31);
            edStopTimeCut.TabIndex = 46;
            edStopTimeCut.Text = "5000";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(304, 96);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(89, 25);
            label27.TabIndex = 45;
            label27.Text = "Stop time";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(227, 96);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(36, 25);
            label28.TabIndex = 44;
            label28.Text = "ms";
            // 
            // edStartTimeCut
            // 
            edStartTimeCut.Location = new System.Drawing.Point(140, 90);
            edStartTimeCut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edStartTimeCut.Name = "edStartTimeCut";
            edStartTimeCut.Size = new System.Drawing.Size(74, 31);
            edStartTimeCut.TabIndex = 43;
            edStartTimeCut.Text = "0";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(30, 96);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(88, 25);
            label29.TabIndex = 42;
            label29.Text = "Start time";
            // 
            // tabPage54
            // 
            tabPage54.Controls.Add(label1);
            tabPage54.Controls.Add(btSelectOutputJoin);
            tabPage54.Controls.Add(edOutputFileJoin);
            tabPage54.Controls.Add(label132);
            tabPage54.Controls.Add(btStopJoin);
            tabPage54.Controls.Add(btStartJoin);
            tabPage54.Controls.Add(btClearList3);
            tabPage54.Controls.Add(btAddInputFile3);
            tabPage54.Controls.Add(lbFiles2);
            tabPage54.Controls.Add(label32);
            tabPage54.Location = new System.Drawing.Point(4, 34);
            tabPage54.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage54.Name = "tabPage54";
            tabPage54.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage54.Size = new System.Drawing.Size(721, 547);
            tabPage54.TabIndex = 2;
            tabPage54.Text = "Join files (w/o reencoding)";
            tabPage54.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 386);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(560, 25);
            label1.TabIndex = 63;
            label1.Text = "Source files should have identical video and audio stream parameters";
            // 
            // btSelectOutputJoin
            // 
            btSelectOutputJoin.Location = new System.Drawing.Point(613, 202);
            btSelectOutputJoin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectOutputJoin.Name = "btSelectOutputJoin";
            btSelectOutputJoin.Size = new System.Drawing.Size(40, 44);
            btSelectOutputJoin.TabIndex = 62;
            btSelectOutputJoin.Text = "...";
            btSelectOutputJoin.UseVisualStyleBackColor = true;
            btSelectOutputJoin.Click += btSelectOutputJoin_Click;
            // 
            // edOutputFileJoin
            // 
            edOutputFileJoin.Location = new System.Drawing.Point(150, 206);
            edOutputFileJoin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOutputFileJoin.Name = "edOutputFileJoin";
            edOutputFileJoin.Size = new System.Drawing.Size(451, 31);
            edOutputFileJoin.TabIndex = 61;
            edOutputFileJoin.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label132
            // 
            label132.AutoSize = true;
            label132.Location = new System.Drawing.Point(30, 211);
            label132.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label132.Name = "label132";
            label132.Size = new System.Drawing.Size(97, 25);
            label132.TabIndex = 60;
            label132.Text = "Output file";
            // 
            // btStopJoin
            // 
            btStopJoin.Location = new System.Drawing.Point(170, 294);
            btStopJoin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStopJoin.Name = "btStopJoin";
            btStopJoin.Size = new System.Drawing.Size(124, 44);
            btStopJoin.TabIndex = 59;
            btStopJoin.Text = "Stop";
            btStopJoin.UseVisualStyleBackColor = true;
            btStopJoin.Click += btStopJoin_Click;
            // 
            // btStartJoin
            // 
            btStartJoin.Location = new System.Drawing.Point(36, 294);
            btStartJoin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStartJoin.Name = "btStartJoin";
            btStartJoin.Size = new System.Drawing.Size(124, 44);
            btStartJoin.TabIndex = 58;
            btStartJoin.Text = "Start";
            btStartJoin.UseVisualStyleBackColor = true;
            btStartJoin.Click += btStartJoin_Click;
            // 
            // btClearList3
            // 
            btClearList3.Location = new System.Drawing.Point(547, 118);
            btClearList3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btClearList3.Name = "btClearList3";
            btClearList3.Size = new System.Drawing.Size(107, 44);
            btClearList3.TabIndex = 57;
            btClearList3.Text = "Clear";
            btClearList3.UseVisualStyleBackColor = true;
            btClearList3.Click += btClearList3_Click;
            // 
            // btAddInputFile3
            // 
            btAddInputFile3.Location = new System.Drawing.Point(547, 61);
            btAddInputFile3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAddInputFile3.Name = "btAddInputFile3";
            btAddInputFile3.Size = new System.Drawing.Size(107, 44);
            btAddInputFile3.TabIndex = 56;
            btAddInputFile3.Text = "Add";
            btAddInputFile3.UseVisualStyleBackColor = true;
            btAddInputFile3.Click += btAddInputFile3_Click;
            // 
            // lbFiles2
            // 
            lbFiles2.FormattingEnabled = true;
            lbFiles2.ItemHeight = 25;
            lbFiles2.Location = new System.Drawing.Point(36, 61);
            lbFiles2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbFiles2.Name = "lbFiles2";
            lbFiles2.Size = new System.Drawing.Size(500, 104);
            lbFiles2.TabIndex = 55;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(30, 31);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(90, 25);
            label32.TabIndex = 54;
            label32.Text = "Input files";
            // 
            // tabPage74
            // 
            tabPage74.Controls.Add(label168);
            tabPage74.Controls.Add(cbMuxStreamsShortest);
            tabPage74.Controls.Add(cbMuxStreamsType);
            tabPage74.Controls.Add(btMuxStreamsSelectFile);
            tabPage74.Controls.Add(edMuxStreamsSourceFile);
            tabPage74.Controls.Add(label167);
            tabPage74.Controls.Add(btMuxStreamsSelectOutput);
            tabPage74.Controls.Add(edMuxStreamsOutputFile);
            tabPage74.Controls.Add(label165);
            tabPage74.Controls.Add(btStopMux);
            tabPage74.Controls.Add(btStartMux);
            tabPage74.Controls.Add(btMuxStreamsClear);
            tabPage74.Controls.Add(btMuxStreamsAdd);
            tabPage74.Controls.Add(lbMuxStreamsList);
            tabPage74.Controls.Add(label166);
            tabPage74.Location = new System.Drawing.Point(4, 34);
            tabPage74.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage74.Name = "tabPage74";
            tabPage74.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage74.Size = new System.Drawing.Size(721, 547);
            tabPage74.TabIndex = 3;
            tabPage74.Text = "Mux streams (w/o reencoding)";
            tabPage74.UseVisualStyleBackColor = true;
            // 
            // label168
            // 
            label168.AutoSize = true;
            label168.Location = new System.Drawing.Point(457, 22);
            label168.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label168.Name = "label168";
            label168.Size = new System.Drawing.Size(118, 25);
            label168.TabIndex = 77;
            label168.Text = "Type or index";
            // 
            // cbMuxStreamsShortest
            // 
            cbMuxStreamsShortest.AutoSize = true;
            cbMuxStreamsShortest.Location = new System.Drawing.Point(36, 269);
            cbMuxStreamsShortest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMuxStreamsShortest.Name = "cbMuxStreamsShortest";
            cbMuxStreamsShortest.Size = new System.Drawing.Size(313, 29);
            cbMuxStreamsShortest.TabIndex = 76;
            cbMuxStreamsShortest.Text = "Set file duration to shortest stream";
            cbMuxStreamsShortest.UseVisualStyleBackColor = true;
            // 
            // cbMuxStreamsType
            // 
            cbMuxStreamsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMuxStreamsType.FormattingEnabled = true;
            cbMuxStreamsType.Items.AddRange(new object[] { "Video", "Audio", "Subtitle", "0", "1", "2", "3", "4", "5", "6", "7" });
            cbMuxStreamsType.Location = new System.Drawing.Point(462, 52);
            cbMuxStreamsType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMuxStreamsType.Name = "cbMuxStreamsType";
            cbMuxStreamsType.Size = new System.Drawing.Size(124, 33);
            cbMuxStreamsType.TabIndex = 75;
            // 
            // btMuxStreamsSelectFile
            // 
            btMuxStreamsSelectFile.Location = new System.Drawing.Point(413, 50);
            btMuxStreamsSelectFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btMuxStreamsSelectFile.Name = "btMuxStreamsSelectFile";
            btMuxStreamsSelectFile.Size = new System.Drawing.Size(38, 44);
            btMuxStreamsSelectFile.TabIndex = 74;
            btMuxStreamsSelectFile.Text = "...";
            btMuxStreamsSelectFile.UseVisualStyleBackColor = true;
            btMuxStreamsSelectFile.Click += btMuxStreamsSelectFile_Click;
            // 
            // edMuxStreamsSourceFile
            // 
            edMuxStreamsSourceFile.Location = new System.Drawing.Point(36, 54);
            edMuxStreamsSourceFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMuxStreamsSourceFile.Name = "edMuxStreamsSourceFile";
            edMuxStreamsSourceFile.Size = new System.Drawing.Size(366, 31);
            edMuxStreamsSourceFile.TabIndex = 73;
            // 
            // label167
            // 
            label167.AutoSize = true;
            label167.Location = new System.Drawing.Point(30, 22);
            label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label167.Name = "label167";
            label167.Size = new System.Drawing.Size(94, 25);
            label167.TabIndex = 72;
            label167.Text = "Source file";
            // 
            // btMuxStreamsSelectOutput
            // 
            btMuxStreamsSelectOutput.Location = new System.Drawing.Point(644, 346);
            btMuxStreamsSelectOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btMuxStreamsSelectOutput.Name = "btMuxStreamsSelectOutput";
            btMuxStreamsSelectOutput.Size = new System.Drawing.Size(40, 44);
            btMuxStreamsSelectOutput.TabIndex = 71;
            btMuxStreamsSelectOutput.Text = "...";
            btMuxStreamsSelectOutput.UseVisualStyleBackColor = true;
            btMuxStreamsSelectOutput.Click += btMuxStreamsSelectOutput_Click;
            // 
            // edMuxStreamsOutputFile
            // 
            edMuxStreamsOutputFile.Location = new System.Drawing.Point(150, 350);
            edMuxStreamsOutputFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edMuxStreamsOutputFile.Name = "edMuxStreamsOutputFile";
            edMuxStreamsOutputFile.Size = new System.Drawing.Size(482, 31);
            edMuxStreamsOutputFile.TabIndex = 70;
            edMuxStreamsOutputFile.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label165
            // 
            label165.AutoSize = true;
            label165.Location = new System.Drawing.Point(30, 356);
            label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label165.Name = "label165";
            label165.Size = new System.Drawing.Size(97, 25);
            label165.TabIndex = 69;
            label165.Text = "Output file";
            // 
            // btStopMux
            // 
            btStopMux.Location = new System.Drawing.Point(170, 439);
            btStopMux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStopMux.Name = "btStopMux";
            btStopMux.Size = new System.Drawing.Size(124, 44);
            btStopMux.TabIndex = 68;
            btStopMux.Text = "Stop";
            btStopMux.UseVisualStyleBackColor = true;
            btStopMux.Click += btStopMux_Click;
            // 
            // btStartMux
            // 
            btStartMux.Location = new System.Drawing.Point(36, 439);
            btStartMux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStartMux.Name = "btStartMux";
            btStartMux.Size = new System.Drawing.Size(124, 44);
            btStartMux.TabIndex = 67;
            btStartMux.Text = "Start";
            btStartMux.UseVisualStyleBackColor = true;
            btStartMux.Click += btStartMux_Click;
            // 
            // btMuxStreamsClear
            // 
            btMuxStreamsClear.Location = new System.Drawing.Point(578, 269);
            btMuxStreamsClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btMuxStreamsClear.Name = "btMuxStreamsClear";
            btMuxStreamsClear.Size = new System.Drawing.Size(107, 44);
            btMuxStreamsClear.TabIndex = 66;
            btMuxStreamsClear.Text = "Clear";
            btMuxStreamsClear.UseVisualStyleBackColor = true;
            btMuxStreamsClear.Click += btMuxStreamsClear_Click;
            // 
            // btMuxStreamsAdd
            // 
            btMuxStreamsAdd.Location = new System.Drawing.Point(598, 50);
            btMuxStreamsAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btMuxStreamsAdd.Name = "btMuxStreamsAdd";
            btMuxStreamsAdd.Size = new System.Drawing.Size(87, 44);
            btMuxStreamsAdd.TabIndex = 65;
            btMuxStreamsAdd.Text = "Add";
            btMuxStreamsAdd.UseVisualStyleBackColor = true;
            btMuxStreamsAdd.Click += btMuxStreamsAdd_Click;
            // 
            // lbMuxStreamsList
            // 
            lbMuxStreamsList.FormattingEnabled = true;
            lbMuxStreamsList.ItemHeight = 25;
            lbMuxStreamsList.Location = new System.Drawing.Point(36, 146);
            lbMuxStreamsList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbMuxStreamsList.Name = "lbMuxStreamsList";
            lbMuxStreamsList.Size = new System.Drawing.Size(647, 104);
            lbMuxStreamsList.TabIndex = 64;
            // 
            // label166
            // 
            label166.AutoSize = true;
            label166.Location = new System.Drawing.Point(30, 115);
            label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label166.Name = "label166";
            label166.Size = new System.Drawing.Size(121, 25);
            label166.TabIndex = 63;
            label166.Text = "Input streams";
            // 
            // cbMode
            // 
            cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMode.FormattingEnabled = true;
            cbMode.Items.AddRange(new object[] { "Convert", "Preview" });
            cbMode.Location = new System.Drawing.Point(89, 1039);
            cbMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbMode.Name = "cbMode";
            cbMode.Size = new System.Drawing.Size(306, 33);
            cbMode.TabIndex = 81;
            // 
            // label130
            // 
            label130.AutoSize = true;
            label130.Location = new System.Drawing.Point(16, 1044);
            label130.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label130.Name = "label130";
            label130.Size = new System.Drawing.Size(59, 25);
            label130.TabIndex = 82;
            label130.Text = "Mode";
            // 
            // openFileDialogSubtitles
            // 
            openFileDialogSubtitles.FileName = "openFileDialog4";
            openFileDialogSubtitles.Filter = "Subtitle files|*.srt;*.ssa;*.ass;*.sub|All files|*.*";
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Checked = true;
            cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            cbTelemetry.Location = new System.Drawing.Point(256, 1102);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(113, 29);
            cbTelemetry.TabIndex = 86;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(127, 1102);
            cbLicensing.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(110, 29);
            cbLicensing.TabIndex = 85;
            cbLicensing.Text = "Licensing";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(20, 1102);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 84;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(20, 1146);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmLog.Size = new System.Drawing.Size(507, 83);
            mmLog.TabIndex = 83;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(551, 619);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(720, 556);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 87;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1289, 1256);
            Controls.Add(VideoView1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(ProgressBar1);
            Controls.Add(tabControl1);
            Controls.Add(tbSeeking);
            Controls.Add(tabControl3);
            Controls.Add(cbTelemetry);
            Controls.Add(cbLicensing);
            Controls.Add(cbDebugMode);
            Controls.Add(mmLog);
            Controls.Add(label130);
            Controls.Add(cbMode);
            Controls.Add(linkLabel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "Form1";
            Text = "VisioForge Video Edit SDK .Net - Main Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage30.ResumeLayout(false);
            tabPage30.PerformLayout();
            tabPage48.ResumeLayout(false);
            tabPage48.PerformLayout();
            tabPage31.ResumeLayout(false);
            tabControl17.ResumeLayout(false);
            tabPage68.ResumeLayout(false);
            tabPage68.PerformLayout();
            tabControl7.ResumeLayout(false);
            tabPage29.ResumeLayout(false);
            tabPage42.ResumeLayout(false);
            tabPage22.ResumeLayout(false);
            tabPage22.PerformLayout();
            groupBox37.ResumeLayout(false);
            tabPage23.ResumeLayout(false);
            tabPage23.PerformLayout();
            groupBox40.ResumeLayout(false);
            groupBox40.PerformLayout();
            groupBox39.ResumeLayout(false);
            groupBox39.PerformLayout();
            groupBox38.ResumeLayout(false);
            groupBox38.PerformLayout();
            tabPage43.ResumeLayout(false);
            tabPage43.PerformLayout();
            groupBox45.ResumeLayout(false);
            groupBox45.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage69.ResumeLayout(false);
            tabPage69.PerformLayout();
            tabPage59.ResumeLayout(false);
            tabPage59.PerformLayout();
            tabPage15.ResumeLayout(false);
            tabControl15.ResumeLayout(false);
            tabPage21.ResumeLayout(false);
            tabPage21.PerformLayout();
            tabPage26.ResumeLayout(false);
            tabPage26.PerformLayout();
            tabPage20.ResumeLayout(false);
            tabPage20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).EndInit();
            tabPage70.ResumeLayout(false);
            tabPage70.PerformLayout();
            tabPage82.ResumeLayout(false);
            tabPage82.PerformLayout();
            tabPage83.ResumeLayout(false);
            tabPage83.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).EndInit();
            tabPage9.ResumeLayout(false);
            tabPage9.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabPage66.ResumeLayout(false);
            tabPage66.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
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
            tabPage16.ResumeLayout(false);
            tabPage16.PerformLayout();
            tabPage81.ResumeLayout(false);
            tabPage81.PerformLayout();
            groupBox41.ResumeLayout(false);
            groupBox41.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).EndInit();
            tabPage27.ResumeLayout(false);
            tabPage27.PerformLayout();
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
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            tabPage25.ResumeLayout(false);
            tabPage25.PerformLayout();
            tabPage28.ResumeLayout(false);
            tabPage28.PerformLayout();
            tabControl5.ResumeLayout(false);
            tabPage32.ResumeLayout(false);
            tabPage32.PerformLayout();
            tabPage49.ResumeLayout(false);
            tabPage49.PerformLayout();
            tabPage50.ResumeLayout(false);
            tabPage50.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage77.ResumeLayout(false);
            tabPage77.PerformLayout();
            tabPage51.ResumeLayout(false);
            tabPage51.PerformLayout();
            tabPage33.ResumeLayout(false);
            tabPage33.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage34.ResumeLayout(false);
            tabPage34.PerformLayout();
            tabPage46.ResumeLayout(false);
            tabPage46.PerformLayout();
            tabPage47.ResumeLayout(false);
            groupBox48.ResumeLayout(false);
            groupBox48.PerformLayout();
            groupBox47.ResumeLayout(false);
            groupBox47.PerformLayout();
            groupBox43.ResumeLayout(false);
            groupBox43.PerformLayout();
            tabPage79.ResumeLayout(false);
            tabPage79.PerformLayout();
            TabControl32.ResumeLayout(false);
            TabPage142.ResumeLayout(false);
            TabPage142.PerformLayout();
            TabPage143.ResumeLayout(false);
            TabPage143.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgTagCover).EndInit();
            tabPage24.ResumeLayout(false);
            tabPage24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSeeking).EndInit();
            tabControl3.ResumeLayout(false);
            tabPage52.ResumeLayout(false);
            tabPage52.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            tabPage53.ResumeLayout(false);
            tabPage53.PerformLayout();
            tabPage54.ResumeLayout(false);
            tabPage54.PerformLayout();
            tabPage74.ResumeLayout(false);
            tabPage74.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.OpenFileDialog OpenDialog1;
        private System.Windows.Forms.SaveFileDialog SaveDialog1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lbTransitions;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox edTransStartTime;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btAddTransition;
        private System.Windows.Forms.ComboBox cbTransitionName;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox edTransStopTime;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.FontDialog FontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.CheckBox cbEffects;
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
        private System.Windows.Forms.TabPage tabPage70;
        private System.Windows.Forms.Button btFilterDeleteAll;
        private System.Windows.Forms.Button btFilterSettings2;
        private System.Windows.Forms.ListBox lbFilters;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Button btFilterSettings;
        private System.Windows.Forms.Button btFilterAdd;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label105;
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
        private System.Windows.Forms.TrackBar tbSeeking;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TabPage tabPage20;
        private System.Windows.Forms.TabControl tabControl15;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ProgressBar pbAFMotionLevel;
        private System.Windows.Forms.CheckBox cbAFMotionHighlight;
        private System.Windows.Forms.CheckBox cbAFMotionDetection;
        private System.Windows.Forms.TabPage tabPage26;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage27;
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
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox edFadeInStopTime;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox edFadeInStartTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabPage22;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Button btEffZoomRight;
        private System.Windows.Forms.Button btEffZoomLeft;
        private System.Windows.Forms.Button btEffZoomOut;
        private System.Windows.Forms.Button btEffZoomIn;
        private System.Windows.Forms.Button btEffZoomDown;
        private System.Windows.Forms.Button btEffZoomUp;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.TabPage tabPage23;
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
        private System.Windows.Forms.TabPage tabPage25;
        private System.Windows.Forms.TextBox edBarcodeMetadata;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.ComboBox cbBarcodeType;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Button btBarcodeReset;
        private System.Windows.Forms.TextBox edBarcode;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.CheckBox cbBarcodeDetectionEnabled;
        private System.Windows.Forms.TabPage tabPage28;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage32;
        private System.Windows.Forms.TextBox edWMVNetworkPort;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btRefreshClients;
        private System.Windows.Forms.ListBox lbNetworkClients;
        private System.Windows.Forms.RadioButton rbNetworkStreamingUseExternalProfile;
        private System.Windows.Forms.RadioButton rbNetworkStreamingUseMainWMVSettings;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox edMaximumClients;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btSelectWMVProfileNetwork;
        private System.Windows.Forms.TextBox edNetworkStreamingWMVProfile;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tabPage33;
        private System.Windows.Forms.CheckBox cbNetworkStreamingAudioEnabled;
        private System.Windows.Forms.CheckBox cbNetworkStreaming;
        private System.Windows.Forms.TabPage tabPage34;
        private System.Windows.Forms.Label label326;
        private System.Windows.Forms.Label label325;
        private System.Windows.Forms.CheckBox cbVirtualCamera;
        private System.Windows.Forms.Label label328;
        private System.Windows.Forms.Label label327;
        private System.Windows.Forms.TabPage tabPage43;
        private System.Windows.Forms.RadioButton rbVideoFadeOut;
        private System.Windows.Forms.RadioButton rbVideoFadeIn;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.TextBox edVideoFadeInOutStopTime;
        private System.Windows.Forms.Label label329;
        private System.Windows.Forms.TextBox edVideoFadeInOutStartTime;
        private System.Windows.Forms.Label label330;
        private System.Windows.Forms.CheckBox cbVideoFadeInOut;
        private System.Windows.Forms.TabPage tabPage46;
        private System.Windows.Forms.CheckBox cbDecklinkDV;
        private System.Windows.Forms.CheckBox cbDecklinkOutput;
        private System.Windows.Forms.CheckBox cbDecklinkOutputDownConversionAnalogOutput;
        private System.Windows.Forms.ComboBox cbDecklinkOutputDownConversion;
        private System.Windows.Forms.Label label337;
        private System.Windows.Forms.ComboBox cbDecklinkOutputHDTVPulldown;
        private System.Windows.Forms.Label label336;
        private System.Windows.Forms.ComboBox cbDecklinkOutputBlackToDeck;
        private System.Windows.Forms.Label label335;
        private System.Windows.Forms.ComboBox cbDecklinkOutputSingleField;
        private System.Windows.Forms.Label label334;
        private System.Windows.Forms.ComboBox cbDecklinkOutputComponentLevels;
        private System.Windows.Forms.Label label333;
        private System.Windows.Forms.ComboBox cbDecklinkOutputNTSC;
        private System.Windows.Forms.Label label332;
        private System.Windows.Forms.ComboBox cbDecklinkOutputDualLink;
        private System.Windows.Forms.Label label331;
        private System.Windows.Forms.ComboBox cbDecklinkOutputAnalog;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TabPage tabPage47;
        private System.Windows.Forms.TabPage tabPage48;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox edNetworkURL;
        private System.Windows.Forms.TabPage tabPage49;
        private System.Windows.Forms.TextBox edNetworkRTSPURL;
        private System.Windows.Forms.Label label367;
        private System.Windows.Forms.Label label366;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.ComboBox cbNetworkStreamingMode;
        private System.Windows.Forms.TabPage tabPage50;
        private System.Windows.Forms.Label label369;
        private System.Windows.Forms.TabPage tabPage51;
        private System.Windows.Forms.TextBox edNetworkSSURL;
        private System.Windows.Forms.Label label370;
        private System.Windows.Forms.Label label371;
        private System.Windows.Forms.RadioButton rbNetworkSSSoftware;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage52;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox edInsertTime;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.CheckBox cbInsertAfterPreviousFile;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox edStopTime;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox edStartTime;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox cbAddFullFile;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Button btClearList;
        private System.Windows.Forms.Button btAddInputFile;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage53;
        private System.Windows.Forms.TabPage tabPage54;
        private System.Windows.Forms.Button btAddInputFile2;
        private System.Windows.Forms.TextBox edSourceFileToCut;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox edStopTimeCut;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox edStartTimeCut;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btClearList3;
        private System.Windows.Forms.Button btAddInputFile3;
        private System.Windows.Forms.ListBox lbFiles2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label393;
        private System.Windows.Forms.ComboBox cbDirect2DRotate;
        private System.Windows.Forms.Panel pnVideoRendererBGColor;
        private System.Windows.Forms.Label label394;
        private System.Windows.Forms.Button btFullScreen;
        private System.Windows.Forms.CheckBox cbScreenFlipVertical;
        private System.Windows.Forms.CheckBox cbScreenFlipHorizontal;
        private System.Windows.Forms.CheckBox cbStretch;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbDirect2D;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbEVR;
        private System.Windows.Forms.RadioButton rbVMR9;
        private System.Windows.Forms.TabPage tabPage66;
        private System.Windows.Forms.CheckBox cbAudioAutoGain;
        private System.Windows.Forms.CheckBox cbAudioNormalize;
        private System.Windows.Forms.CheckBox cbAudioEnhancementEnabled;
        private System.Windows.Forms.Label lbAudioTimeshift;
        private System.Windows.Forms.TrackBar tbAudioTimeshift;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbAudioOutputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioOutputGainLFE;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label lbAudioOutputGainSR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSR;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label lbAudioOutputGainSL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSL;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label lbAudioOutputGainR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainR;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label lbAudioOutputGainC;
        private System.Windows.Forms.TrackBar tbAudioOutputGainC;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label lbAudioOutputGainL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainL;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbAudioInputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioInputGainLFE;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label lbAudioInputGainSR;
        private System.Windows.Forms.TrackBar tbAudioInputGainSR;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label lbAudioInputGainSL;
        private System.Windows.Forms.TrackBar tbAudioInputGainSL;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Label lbAudioInputGainR;
        private System.Windows.Forms.TrackBar tbAudioInputGainR;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label lbAudioInputGainC;
        private System.Windows.Forms.TrackBar tbAudioInputGainC;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label lbAudioInputGainL;
        private System.Windows.Forms.TrackBar tbAudioInputGainL;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.RadioButton rbNetworkRTMPFFMPEGCustom;
        private System.Windows.Forms.RadioButton rbNetworkRTMPFFMPEG;
        private System.Windows.Forms.TextBox edNetworkRTMPURL;
        private System.Windows.Forms.Label label368;
        private System.Windows.Forms.TabPage tabPage77;
        private System.Windows.Forms.RadioButton rbNetworkUDPFFMPEGCustom;
        private System.Windows.Forms.RadioButton rbNetworkUDPFFMPEG;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.Label label343;
        private System.Windows.Forms.TextBox edEncryptionKeyHEX;
        private System.Windows.Forms.RadioButton rbEncryptionKeyBinary;
        private System.Windows.Forms.Button btEncryptionOpenFile;
        private System.Windows.Forms.TextBox edEncryptionKeyFile;
        private System.Windows.Forms.RadioButton rbEncryptionKeyFile;
        private System.Windows.Forms.TextBox edEncryptionKeyString;
        private System.Windows.Forms.RadioButton rbEncryptionKeyString;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.RadioButton rbEncryptionModeAES256;
        private System.Windows.Forms.RadioButton rbEncryptionModeAES128;
        private System.Windows.Forms.GroupBox groupBox43;
        private System.Windows.Forms.RadioButton rbEncryptedH264CUDA;
        private System.Windows.Forms.RadioButton rbEncryptedH264SW;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Button btStopCut;
        private System.Windows.Forms.Button btStartCut;
        private System.Windows.Forms.Button btSelectOutputCut;
        private System.Windows.Forms.TextBox edOutputFileCut;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Button btSelectOutputJoin;
        private System.Windows.Forms.TextBox edOutputFileJoin;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Button btStopJoin;
        private System.Windows.Forms.Button btStartJoin;
        private System.Windows.Forms.TabPage tabPage79;
        internal System.Windows.Forms.TabControl TabControl32;
        internal System.Windows.Forms.TabPage TabPage142;
        internal System.Windows.Forms.TextBox edTagTrackID;
        internal System.Windows.Forms.Label Label496;
        internal System.Windows.Forms.TextBox edTagYear;
        internal System.Windows.Forms.Label Label495;
        internal System.Windows.Forms.TextBox edTagComment;
        internal System.Windows.Forms.Label Label493;
        internal System.Windows.Forms.TextBox edTagAlbum;
        internal System.Windows.Forms.Label Label491;
        internal System.Windows.Forms.TextBox edTagArtists;
        internal System.Windows.Forms.Label label494;
        internal System.Windows.Forms.TextBox edTagCopyright;
        internal System.Windows.Forms.Label label497;
        internal System.Windows.Forms.TextBox edTagTitle;
        internal System.Windows.Forms.Label label498;
        internal System.Windows.Forms.TabPage TabPage143;
        internal System.Windows.Forms.PictureBox imgTagCover;
        internal System.Windows.Forms.Label Label499;
        internal System.Windows.Forms.Label label500;
        internal System.Windows.Forms.TextBox edTagLyrics;
        internal System.Windows.Forms.Label label501;
        internal System.Windows.Forms.ComboBox cbTagGenre;
        internal System.Windows.Forms.Label label502;
        internal System.Windows.Forms.TextBox edTagComposers;
        internal System.Windows.Forms.Label label503;
        internal System.Windows.Forms.CheckBox cbTagEnabled;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.TabPage tabPage74;
        private System.Windows.Forms.Button btMuxStreamsSelectOutput;
        private System.Windows.Forms.TextBox edMuxStreamsOutputFile;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Button btStopMux;
        private System.Windows.Forms.Button btStartMux;
        private System.Windows.Forms.Button btMuxStreamsClear;
        private System.Windows.Forms.Button btMuxStreamsAdd;
        private System.Windows.Forms.ListBox lbMuxStreamsList;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.ComboBox cbMuxStreamsType;
        private System.Windows.Forms.Button btMuxStreamsSelectFile;
        private System.Windows.Forms.TextBox edMuxStreamsSourceFile;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.CheckBox cbMuxStreamsShortest;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGCustom;
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGDefault;
        private System.Windows.Forms.TabPage tabPage81;
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
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.TabPage tabPage82;
        private System.Windows.Forms.Button btSubtitlesSelectFile;
        private System.Windows.Forms.TextBox edSubtitlesFilename;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.CheckBox cbSubtitlesEnabled;
        private System.Windows.Forms.OpenFileDialog openFileDialogSubtitles;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TabPage tabPage83;
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
        private System.Windows.Forms.TabPage tabPage24;
        private System.Windows.Forms.TrackBar tbVUMeterBoost;
        private System.Windows.Forms.Label label382;
        private System.Windows.Forms.Label label381;
        private System.Windows.Forms.TrackBar tbVUMeterAmplification;
        private System.Windows.Forms.CheckBox cbVUMeterPro;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter waveformPainter2;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter waveformPainter1;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter2;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter1;
        private System.Windows.Forms.CheckBox cbVUMeter;
        private VisioForge.Core.UI.WinForms.PeakMeterCtrl peakMeterCtrl1;
        private System.Windows.Forms.TextBox edCropRight;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.TextBox edCropBottom;
        private System.Windows.Forms.Label label252;
        private System.Windows.Forms.TextBox edCropLeft;
        private System.Windows.Forms.Label label270;
        private System.Windows.Forms.TextBox edCropTop;
        private System.Windows.Forms.Label label272;
        private System.Windows.Forms.CheckBox cbCrop;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox cbRotate;
        private System.Windows.Forms.ComboBox cbFrameRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Button btConfigure;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbOutputVideoFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbInfo;
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
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbFadeInEnabled;
        private System.Windows.Forms.CheckBox cbFadeOutEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edFadeOutStopTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edFadeOutStartTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbVideoEffectsGPUEnabled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbGPUBlur;
        private System.Windows.Forms.Panel pnChromaKeyColor;
        private System.Windows.Forms.Button btChromaKeySelectBGImage;
        private System.Windows.Forms.TextBox edChromaKeyImage;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.TrackBar tbChromaKeySmoothing;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.TrackBar tbChromaKeyThresholdSensitivity;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.CheckBox cbChromaKeyEnabled;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel lbNDI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox edNDIURL;
        private System.Windows.Forms.TextBox edNDIName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label314;
        private System.Windows.Forms.Label label313;
        private System.Windows.Forms.TextBox edNetworkUDPURL;
        private System.Windows.Forms.Label label372;
        private System.Windows.Forms.Label label484;
        private System.Windows.Forms.LinkLabel llXiphX64;
        private System.Windows.Forms.LinkLabel llXiphX86;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox edHLSURL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox edHLSEmbeddedHTTPServerPort;
        private System.Windows.Forms.CheckBox cbHLSEmbeddedHTTPServerEnabled;
        private System.Windows.Forms.ComboBox cbHLSMode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.LinkLabel lbHLSConfigure;
        private System.Windows.Forms.Label label532;
        private System.Windows.Forms.Label label531;
        private System.Windows.Forms.Label label530;
        private System.Windows.Forms.Label label529;
        private System.Windows.Forms.TextBox edHLSSegmentCount;
        private System.Windows.Forms.Label label519;
        private System.Windows.Forms.TextBox edHLSSegmentDuration;
        private System.Windows.Forms.Button btSelectHLSOutputFolder;
        private System.Windows.Forms.TextBox edHLSOutputFolder;
        private System.Windows.Forms.Label label380;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel linkLabelDecoders;
    }
}

