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
            global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::VideoEdit_CS_Demo.Form1));
            this.tabControl1 = (new global::System.Windows.Forms.TabControl());
            this.tabPage1 = (new global::System.Windows.Forms.TabPage());
            this.tabControl2 = (new global::System.Windows.Forms.TabControl());
            this.tabPage30 = (new global::System.Windows.Forms.TabPage());
            this.llXiphX64 = (new global::System.Windows.Forms.LinkLabel());
            this.llXiphX86 = (new global::System.Windows.Forms.LinkLabel());
            this.label68 = (new global::System.Windows.Forms.Label());
            this.label67 = (new global::System.Windows.Forms.Label());
            this.lbInfo = (new global::System.Windows.Forms.Label());
            this.btConfigure = (new global::System.Windows.Forms.Button());
            this.btSelectOutput = (new global::System.Windows.Forms.Button());
            this.edOutput = (new global::System.Windows.Forms.TextBox());
            this.label15 = (new global::System.Windows.Forms.Label());
            this.cbOutputVideoFormat = (new global::System.Windows.Forms.ComboBox());
            this.label9 = (new global::System.Windows.Forms.Label());
            this.tabPage48 = (new global::System.Windows.Forms.TabPage());
            this.edCropRight = (new global::System.Windows.Forms.TextBox());
            this.label176 = (new global::System.Windows.Forms.Label());
            this.edCropBottom = (new global::System.Windows.Forms.TextBox());
            this.label252 = (new global::System.Windows.Forms.Label());
            this.edCropLeft = (new global::System.Windows.Forms.TextBox());
            this.label270 = (new global::System.Windows.Forms.Label());
            this.edCropTop = (new global::System.Windows.Forms.TextBox());
            this.label272 = (new global::System.Windows.Forms.Label());
            this.cbCrop = (new global::System.Windows.Forms.CheckBox());
            this.label92 = (new global::System.Windows.Forms.Label());
            this.cbRotate = (new global::System.Windows.Forms.ComboBox());
            this.cbFrameRate = (new global::System.Windows.Forms.ComboBox());
            this.label3 = (new global::System.Windows.Forms.Label());
            this.edHeight = (new global::System.Windows.Forms.TextBox());
            this.edWidth = (new global::System.Windows.Forms.TextBox());
            this.label2 = (new global::System.Windows.Forms.Label());
            this.cbResize = (new global::System.Windows.Forms.CheckBox());
            this.tabPage31 = (new global::System.Windows.Forms.TabPage());
            this.tabControl17 = (new global::System.Windows.Forms.TabControl());
            this.tabPage68 = (new global::System.Windows.Forms.TabPage());
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
            this.tabPage22 = (new global::System.Windows.Forms.TabPage());
            this.groupBox37 = (new global::System.Windows.Forms.GroupBox());
            this.btEffZoomRight = (new global::System.Windows.Forms.Button());
            this.btEffZoomLeft = (new global::System.Windows.Forms.Button());
            this.btEffZoomOut = (new global::System.Windows.Forms.Button());
            this.btEffZoomIn = (new global::System.Windows.Forms.Button());
            this.btEffZoomDown = (new global::System.Windows.Forms.Button());
            this.btEffZoomUp = (new global::System.Windows.Forms.Button());
            this.cbZoom = (new global::System.Windows.Forms.CheckBox());
            this.tabPage23 = (new global::System.Windows.Forms.TabPage());
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
            this.tabPage43 = (new global::System.Windows.Forms.TabPage());
            this.rbVideoFadeOut = (new global::System.Windows.Forms.RadioButton());
            this.rbVideoFadeIn = (new global::System.Windows.Forms.RadioButton());
            this.groupBox45 = (new global::System.Windows.Forms.GroupBox());
            this.edVideoFadeInOutStopTime = (new global::System.Windows.Forms.TextBox());
            this.label329 = (new global::System.Windows.Forms.Label());
            this.edVideoFadeInOutStartTime = (new global::System.Windows.Forms.TextBox());
            this.label330 = (new global::System.Windows.Forms.Label());
            this.cbVideoFadeInOut = (new global::System.Windows.Forms.CheckBox());
            this.tbContrast = (new global::System.Windows.Forms.TrackBar());
            this.tbDarkness = (new global::System.Windows.Forms.TrackBar());
            this.tbLightness = (new global::System.Windows.Forms.TrackBar());
            this.tbSaturation = (new global::System.Windows.Forms.TrackBar());
            this.cbInvert = (new global::System.Windows.Forms.CheckBox());
            this.cbGreyscale = (new global::System.Windows.Forms.CheckBox());
            this.cbEffects = (new global::System.Windows.Forms.CheckBox());
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
            this.tabPage15 = (new global::System.Windows.Forms.TabPage());
            this.tabControl15 = (new global::System.Windows.Forms.TabControl());
            this.tabPage21 = (new global::System.Windows.Forms.TabPage());
            this.label64 = (new global::System.Windows.Forms.Label());
            this.label65 = (new global::System.Windows.Forms.Label());
            this.pbAFMotionLevel = (new global::System.Windows.Forms.ProgressBar());
            this.cbAFMotionHighlight = (new global::System.Windows.Forms.CheckBox());
            this.cbAFMotionDetection = (new global::System.Windows.Forms.CheckBox());
            this.tabPage26 = (new global::System.Windows.Forms.TabPage());
            this.label171 = (new global::System.Windows.Forms.Label());
            this.label66 = (new global::System.Windows.Forms.Label());
            this.label16 = (new global::System.Windows.Forms.Label());
            this.tabPage20 = (new global::System.Windows.Forms.TabPage());
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
            this.tabPage70 = (new global::System.Windows.Forms.TabPage());
            this.btFilterDeleteAll = (new global::System.Windows.Forms.Button());
            this.btFilterSettings2 = (new global::System.Windows.Forms.Button());
            this.lbFilters = (new global::System.Windows.Forms.ListBox());
            this.label106 = (new global::System.Windows.Forms.Label());
            this.btFilterSettings = (new global::System.Windows.Forms.Button());
            this.btFilterAdd = (new global::System.Windows.Forms.Button());
            this.cbFilters = (new global::System.Windows.Forms.ComboBox());
            this.label105 = (new global::System.Windows.Forms.Label());
            this.tabPage82 = (new global::System.Windows.Forms.TabPage());
            this.label177 = (new global::System.Windows.Forms.Label());
            this.label129 = (new global::System.Windows.Forms.Label());
            this.btSubtitlesSelectFile = (new global::System.Windows.Forms.Button());
            this.edSubtitlesFilename = (new global::System.Windows.Forms.TextBox());
            this.label114 = (new global::System.Windows.Forms.Label());
            this.cbSubtitlesEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage83 = (new global::System.Windows.Forms.TabPage());
            this.label8 = (new global::System.Windows.Forms.Label());
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
            this.tabPage9 = (new global::System.Windows.Forms.TabPage());
            this.groupBox5 = (new global::System.Windows.Forms.GroupBox());
            this.label47 = (new global::System.Windows.Forms.Label());
            this.edTransStopTime = (new global::System.Windows.Forms.TextBox());
            this.label48 = (new global::System.Windows.Forms.Label());
            this.label46 = (new global::System.Windows.Forms.Label());
            this.edTransStartTime = (new global::System.Windows.Forms.TextBox());
            this.label45 = (new global::System.Windows.Forms.Label());
            this.btAddTransition = (new global::System.Windows.Forms.Button());
            this.cbTransitionName = (new global::System.Windows.Forms.ComboBox());
            this.label44 = (new global::System.Windows.Forms.Label());
            this.lbTransitions = (new global::System.Windows.Forms.ListBox());
            this.label43 = (new global::System.Windows.Forms.Label());
            this.tabPage66 = (new global::System.Windows.Forms.TabPage());
            this.lbAudioTimeshift = (new global::System.Windows.Forms.Label());
            this.tbAudioTimeshift = (new global::System.Windows.Forms.TrackBar());
            this.label115 = (new global::System.Windows.Forms.Label());
            this.groupBox1 = (new global::System.Windows.Forms.GroupBox());
            this.lbAudioOutputGainLFE = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainLFE = (new global::System.Windows.Forms.TrackBar());
            this.label116 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainSR = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainSR = (new global::System.Windows.Forms.TrackBar());
            this.label117 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainSL = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainSL = (new global::System.Windows.Forms.TrackBar());
            this.label118 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainR = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainR = (new global::System.Windows.Forms.TrackBar());
            this.label119 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainC = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainC = (new global::System.Windows.Forms.TrackBar());
            this.label121 = (new global::System.Windows.Forms.Label());
            this.lbAudioOutputGainL = (new global::System.Windows.Forms.Label());
            this.tbAudioOutputGainL = (new global::System.Windows.Forms.TrackBar());
            this.label122 = (new global::System.Windows.Forms.Label());
            this.groupBox2 = (new global::System.Windows.Forms.GroupBox());
            this.lbAudioInputGainLFE = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainLFE = (new global::System.Windows.Forms.TrackBar());
            this.label123 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainSR = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainSR = (new global::System.Windows.Forms.TrackBar());
            this.label124 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainSL = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainSL = (new global::System.Windows.Forms.TrackBar());
            this.label125 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainR = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainR = (new global::System.Windows.Forms.TrackBar());
            this.label126 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainC = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainC = (new global::System.Windows.Forms.TrackBar());
            this.label127 = (new global::System.Windows.Forms.Label());
            this.lbAudioInputGainL = (new global::System.Windows.Forms.Label());
            this.tbAudioInputGainL = (new global::System.Windows.Forms.TrackBar());
            this.label128 = (new global::System.Windows.Forms.Label());
            this.cbAudioAutoGain = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioNormalize = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioEnhancementEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage3 = (new global::System.Windows.Forms.TabPage());
            this.label133 = (new global::System.Windows.Forms.Label());
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
            this.tabPage16 = (new global::System.Windows.Forms.TabPage());
            this.cbFadeOutEnabled = (new global::System.Windows.Forms.CheckBox());
            this.label4 = (new global::System.Windows.Forms.Label());
            this.edFadeOutStopTime = (new global::System.Windows.Forms.TextBox());
            this.label5 = (new global::System.Windows.Forms.Label());
            this.label6 = (new global::System.Windows.Forms.Label());
            this.edFadeOutStartTime = (new global::System.Windows.Forms.TextBox());
            this.label7 = (new global::System.Windows.Forms.Label());
            this.cbFadeInEnabled = (new global::System.Windows.Forms.CheckBox());
            this.label19 = (new global::System.Windows.Forms.Label());
            this.edFadeInStopTime = (new global::System.Windows.Forms.TextBox());
            this.label20 = (new global::System.Windows.Forms.Label());
            this.label18 = (new global::System.Windows.Forms.Label());
            this.edFadeInStartTime = (new global::System.Windows.Forms.TextBox());
            this.label17 = (new global::System.Windows.Forms.Label());
            this.cbAudioEffectsEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage81 = (new global::System.Windows.Forms.TabPage());
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
            this.tabPage27 = (new global::System.Windows.Forms.TabPage());
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
            this.tabPage2 = (new global::System.Windows.Forms.TabPage());
            this.label393 = (new global::System.Windows.Forms.Label());
            this.cbDirect2DRotate = (new global::System.Windows.Forms.ComboBox());
            this.pnVideoRendererBGColor = (new global::System.Windows.Forms.Panel());
            this.label394 = (new global::System.Windows.Forms.Label());
            this.btFullScreen = (new global::System.Windows.Forms.Button());
            this.cbScreenFlipVertical = (new global::System.Windows.Forms.CheckBox());
            this.cbScreenFlipHorizontal = (new global::System.Windows.Forms.CheckBox());
            this.cbStretch = (new global::System.Windows.Forms.CheckBox());
            this.groupBox13 = (new global::System.Windows.Forms.GroupBox());
            this.rbDirect2D = (new global::System.Windows.Forms.RadioButton());
            this.rbNone = (new global::System.Windows.Forms.RadioButton());
            this.rbEVR = (new global::System.Windows.Forms.RadioButton());
            this.rbVMR9 = (new global::System.Windows.Forms.RadioButton());
            this.tabPage25 = (new global::System.Windows.Forms.TabPage());
            this.edBarcodeMetadata = (new global::System.Windows.Forms.TextBox());
            this.label91 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeType = (new global::System.Windows.Forms.ComboBox());
            this.label90 = (new global::System.Windows.Forms.Label());
            this.btBarcodeReset = (new global::System.Windows.Forms.Button());
            this.edBarcode = (new global::System.Windows.Forms.TextBox());
            this.label89 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeDetectionEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage28 = (new global::System.Windows.Forms.TabPage());
            this.cbNetworkStreamingMode = (new global::System.Windows.Forms.ComboBox());
            this.tabControl5 = (new global::System.Windows.Forms.TabControl());
            this.tabPage32 = (new global::System.Windows.Forms.TabPage());
            this.label24 = (new global::System.Windows.Forms.Label());
            this.edNetworkURL = (new global::System.Windows.Forms.TextBox());
            this.edWMVNetworkPort = (new global::System.Windows.Forms.TextBox());
            this.label21 = (new global::System.Windows.Forms.Label());
            this.btRefreshClients = (new global::System.Windows.Forms.Button());
            this.lbNetworkClients = (new global::System.Windows.Forms.ListBox());
            this.rbNetworkStreamingUseExternalProfile = (new global::System.Windows.Forms.RadioButton());
            this.rbNetworkStreamingUseMainWMVSettings = (new global::System.Windows.Forms.RadioButton());
            this.label81 = (new global::System.Windows.Forms.Label());
            this.label80 = (new global::System.Windows.Forms.Label());
            this.edMaximumClients = (new global::System.Windows.Forms.TextBox());
            this.label22 = (new global::System.Windows.Forms.Label());
            this.btSelectWMVProfileNetwork = (new global::System.Windows.Forms.Button());
            this.edNetworkStreamingWMVProfile = (new global::System.Windows.Forms.TextBox());
            this.label23 = (new global::System.Windows.Forms.Label());
            this.tabPage49 = (new global::System.Windows.Forms.TabPage());
            this.edNetworkRTSPURL = (new global::System.Windows.Forms.TextBox());
            this.label367 = (new global::System.Windows.Forms.Label());
            this.label366 = (new global::System.Windows.Forms.Label());
            this.tabPage50 = (new global::System.Windows.Forms.TabPage());
            this.linkLabel11 = (new global::System.Windows.Forms.LinkLabel());
            this.rbNetworkRTMPFFMPEGCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbNetworkRTMPFFMPEG = (new global::System.Windows.Forms.RadioButton());
            this.edNetworkRTMPURL = (new global::System.Windows.Forms.TextBox());
            this.label368 = (new global::System.Windows.Forms.Label());
            this.label369 = (new global::System.Windows.Forms.Label());
            this.tabPage4 = (new global::System.Windows.Forms.TabPage());
            this.lbNDI = (new global::System.Windows.Forms.LinkLabel());
            this.label11 = (new global::System.Windows.Forms.Label());
            this.label12 = (new global::System.Windows.Forms.Label());
            this.edNDIURL = (new global::System.Windows.Forms.TextBox());
            this.edNDIName = (new global::System.Windows.Forms.TextBox());
            this.label13 = (new global::System.Windows.Forms.Label());
            this.tabPage77 = (new global::System.Windows.Forms.TabPage());
            this.label484 = (new global::System.Windows.Forms.Label());
            this.label63 = (new global::System.Windows.Forms.Label());
            this.label62 = (new global::System.Windows.Forms.Label());
            this.label314 = (new global::System.Windows.Forms.Label());
            this.label313 = (new global::System.Windows.Forms.Label());
            this.edNetworkUDPURL = (new global::System.Windows.Forms.TextBox());
            this.label372 = (new global::System.Windows.Forms.Label());
            this.rbNetworkUDPFFMPEGCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbNetworkUDPFFMPEG = (new global::System.Windows.Forms.RadioButton());
            this.tabPage51 = (new global::System.Windows.Forms.TabPage());
            this.rbNetworkSSFFMPEGCustom = (new global::System.Windows.Forms.RadioButton());
            this.rbNetworkSSFFMPEGDefault = (new global::System.Windows.Forms.RadioButton());
            this.linkLabel6 = (new global::System.Windows.Forms.LinkLabel());
            this.edNetworkSSURL = (new global::System.Windows.Forms.TextBox());
            this.label370 = (new global::System.Windows.Forms.Label());
            this.label371 = (new global::System.Windows.Forms.Label());
            this.rbNetworkSSSoftware = (new global::System.Windows.Forms.RadioButton());
            this.tabPage33 = (new global::System.Windows.Forms.TabPage());
            this.linkLabel4 = (new global::System.Windows.Forms.LinkLabel());
            this.linkLabel5 = (new global::System.Windows.Forms.LinkLabel());
            this.tabPage5 = (new global::System.Windows.Forms.TabPage());
            this.edHLSURL = (new global::System.Windows.Forms.TextBox());
            this.label14 = (new global::System.Windows.Forms.Label());
            this.edHLSEmbeddedHTTPServerPort = (new global::System.Windows.Forms.TextBox());
            this.cbHLSEmbeddedHTTPServerEnabled = (new global::System.Windows.Forms.CheckBox());
            this.cbHLSMode = (new global::System.Windows.Forms.ComboBox());
            this.label25 = (new global::System.Windows.Forms.Label());
            this.lbHLSConfigure = (new global::System.Windows.Forms.LinkLabel());
            this.label532 = (new global::System.Windows.Forms.Label());
            this.label531 = (new global::System.Windows.Forms.Label());
            this.label530 = (new global::System.Windows.Forms.Label());
            this.label529 = (new global::System.Windows.Forms.Label());
            this.edHLSSegmentCount = (new global::System.Windows.Forms.TextBox());
            this.label519 = (new global::System.Windows.Forms.Label());
            this.edHLSSegmentDuration = (new global::System.Windows.Forms.TextBox());
            this.btSelectHLSOutputFolder = (new global::System.Windows.Forms.Button());
            this.edHLSOutputFolder = (new global::System.Windows.Forms.TextBox());
            this.label380 = (new global::System.Windows.Forms.Label());
            this.cbNetworkStreamingAudioEnabled = (new global::System.Windows.Forms.CheckBox());
            this.cbNetworkStreaming = (new global::System.Windows.Forms.CheckBox());
            this.tabPage34 = (new global::System.Windows.Forms.TabPage());
            this.label328 = (new global::System.Windows.Forms.Label());
            this.label327 = (new global::System.Windows.Forms.Label());
            this.label326 = (new global::System.Windows.Forms.Label());
            this.label325 = (new global::System.Windows.Forms.Label());
            this.cbVirtualCamera = (new global::System.Windows.Forms.CheckBox());
            this.tabPage46 = (new global::System.Windows.Forms.TabPage());
            this.cbDecklinkOutputDownConversionAnalogOutput = (new global::System.Windows.Forms.CheckBox());
            this.cbDecklinkOutputDownConversion = (new global::System.Windows.Forms.ComboBox());
            this.label337 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputHDTVPulldown = (new global::System.Windows.Forms.ComboBox());
            this.label336 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputBlackToDeck = (new global::System.Windows.Forms.ComboBox());
            this.label335 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputSingleField = (new global::System.Windows.Forms.ComboBox());
            this.label334 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputComponentLevels = (new global::System.Windows.Forms.ComboBox());
            this.label333 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputNTSC = (new global::System.Windows.Forms.ComboBox());
            this.label332 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputDualLink = (new global::System.Windows.Forms.ComboBox());
            this.label331 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkOutputAnalog = (new global::System.Windows.Forms.ComboBox());
            this.label87 = (new global::System.Windows.Forms.Label());
            this.cbDecklinkDV = (new global::System.Windows.Forms.CheckBox());
            this.cbDecklinkOutput = (new global::System.Windows.Forms.CheckBox());
            this.tabPage47 = (new global::System.Windows.Forms.TabPage());
            this.groupBox48 = (new global::System.Windows.Forms.GroupBox());
            this.label343 = (new global::System.Windows.Forms.Label());
            this.edEncryptionKeyHEX = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyBinary = (new global::System.Windows.Forms.RadioButton());
            this.btEncryptionOpenFile = (new global::System.Windows.Forms.Button());
            this.edEncryptionKeyFile = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyFile = (new global::System.Windows.Forms.RadioButton());
            this.edEncryptionKeyString = (new global::System.Windows.Forms.TextBox());
            this.rbEncryptionKeyString = (new global::System.Windows.Forms.RadioButton());
            this.groupBox47 = (new global::System.Windows.Forms.GroupBox());
            this.rbEncryptionModeAES256 = (new global::System.Windows.Forms.RadioButton());
            this.rbEncryptionModeAES128 = (new global::System.Windows.Forms.RadioButton());
            this.groupBox43 = (new global::System.Windows.Forms.GroupBox());
            this.rbEncryptedH264CUDA = (new global::System.Windows.Forms.RadioButton());
            this.rbEncryptedH264SW = (new global::System.Windows.Forms.RadioButton());
            this.tabPage79 = (new global::System.Windows.Forms.TabPage());
            this.TabControl32 = (new global::System.Windows.Forms.TabControl());
            this.TabPage142 = (new global::System.Windows.Forms.TabPage());
            this.edTagTrackID = (new global::System.Windows.Forms.TextBox());
            this.Label496 = (new global::System.Windows.Forms.Label());
            this.edTagYear = (new global::System.Windows.Forms.TextBox());
            this.Label495 = (new global::System.Windows.Forms.Label());
            this.edTagComment = (new global::System.Windows.Forms.TextBox());
            this.Label493 = (new global::System.Windows.Forms.Label());
            this.edTagAlbum = (new global::System.Windows.Forms.TextBox());
            this.Label491 = (new global::System.Windows.Forms.Label());
            this.edTagArtists = (new global::System.Windows.Forms.TextBox());
            this.label494 = (new global::System.Windows.Forms.Label());
            this.edTagCopyright = (new global::System.Windows.Forms.TextBox());
            this.label497 = (new global::System.Windows.Forms.Label());
            this.edTagTitle = (new global::System.Windows.Forms.TextBox());
            this.label498 = (new global::System.Windows.Forms.Label());
            this.TabPage143 = (new global::System.Windows.Forms.TabPage());
            this.imgTagCover = (new global::System.Windows.Forms.PictureBox());
            this.Label499 = (new global::System.Windows.Forms.Label());
            this.label500 = (new global::System.Windows.Forms.Label());
            this.edTagLyrics = (new global::System.Windows.Forms.TextBox());
            this.label501 = (new global::System.Windows.Forms.Label());
            this.cbTagGenre = (new global::System.Windows.Forms.ComboBox());
            this.label502 = (new global::System.Windows.Forms.Label());
            this.edTagComposers = (new global::System.Windows.Forms.TextBox());
            this.label503 = (new global::System.Windows.Forms.Label());
            this.cbTagEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage24 = (new global::System.Windows.Forms.TabPage());
            this.cbVUMeter = (new global::System.Windows.Forms.CheckBox());
            this.tbVUMeterBoost = (new global::System.Windows.Forms.TrackBar());
            this.label382 = (new global::System.Windows.Forms.Label());
            this.label381 = (new global::System.Windows.Forms.Label());
            this.tbVUMeterAmplification = (new global::System.Windows.Forms.TrackBar());
            this.cbVUMeterPro = (new global::System.Windows.Forms.CheckBox());
            this.peakMeterCtrl1 = (new global::VisioForge.Core.UI.WinForms.PeakMeterCtrl());
            this.waveformPainter2 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter());
            this.waveformPainter1 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.WaveformPainter());
            this.volumeMeter2 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.volumeMeter1 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.btStart = (new global::System.Windows.Forms.Button());
            this.btStop = (new global::System.Windows.Forms.Button());
            this.OpenDialog1 = (new global::System.Windows.Forms.OpenFileDialog());
            this.SaveDialog1 = (new global::System.Windows.Forms.SaveFileDialog());
            this.FontDialog1 = (new global::System.Windows.Forms.FontDialog());
            this.openFileDialog2 = (new global::System.Windows.Forms.OpenFileDialog());
            this.colorDialog1 = (new global::System.Windows.Forms.ColorDialog());
            this.tbSeeking = (new global::System.Windows.Forms.TrackBar());
            this.linkLabel1 = (new global::System.Windows.Forms.LinkLabel());
            this.openFileDialog3 = (new global::System.Windows.Forms.OpenFileDialog());
            this.openFileDialog1 = (new global::System.Windows.Forms.OpenFileDialog());
            this.ProgressBar1 = (new global::System.Windows.Forms.ProgressBar());
            this.tabControl3 = (new global::System.Windows.Forms.TabControl());
            this.tabPage52 = (new global::System.Windows.Forms.TabPage());
            this.linkLabelDecoders = (new global::System.Windows.Forms.LinkLabel());
            this.groupBox7 = (new global::System.Windows.Forms.GroupBox());
            this.label72 = (new global::System.Windows.Forms.Label());
            this.edInsertTime = (new global::System.Windows.Forms.TextBox());
            this.label73 = (new global::System.Windows.Forms.Label());
            this.cbInsertAfterPreviousFile = (new global::System.Windows.Forms.CheckBox());
            this.label50 = (new global::System.Windows.Forms.Label());
            this.groupBox6 = (new global::System.Windows.Forms.GroupBox());
            this.lbSpeed = (new global::System.Windows.Forms.Label());
            this.label42 = (new global::System.Windows.Forms.Label());
            this.label37 = (new global::System.Windows.Forms.Label());
            this.edStopTime = (new global::System.Windows.Forms.TextBox());
            this.label38 = (new global::System.Windows.Forms.Label());
            this.label36 = (new global::System.Windows.Forms.Label());
            this.edStartTime = (new global::System.Windows.Forms.TextBox());
            this.label35 = (new global::System.Windows.Forms.Label());
            this.cbAddFullFile = (new global::System.Windows.Forms.CheckBox());
            this.tbSpeed = (new global::System.Windows.Forms.TrackBar());
            this.btClearList = (new global::System.Windows.Forms.Button());
            this.btAddInputFile = (new global::System.Windows.Forms.Button());
            this.lbFiles = (new global::System.Windows.Forms.ListBox());
            this.label10 = (new global::System.Windows.Forms.Label());
            this.tabPage53 = (new global::System.Windows.Forms.TabPage());
            this.label134 = (new global::System.Windows.Forms.Label());
            this.btSelectOutputCut = (new global::System.Windows.Forms.Button());
            this.edOutputFileCut = (new global::System.Windows.Forms.TextBox());
            this.label131 = (new global::System.Windows.Forms.Label());
            this.btStopCut = (new global::System.Windows.Forms.Button());
            this.btStartCut = (new global::System.Windows.Forms.Button());
            this.label31 = (new global::System.Windows.Forms.Label());
            this.btAddInputFile2 = (new global::System.Windows.Forms.Button());
            this.edSourceFileToCut = (new global::System.Windows.Forms.TextBox());
            this.label30 = (new global::System.Windows.Forms.Label());
            this.label26 = (new global::System.Windows.Forms.Label());
            this.edStopTimeCut = (new global::System.Windows.Forms.TextBox());
            this.label27 = (new global::System.Windows.Forms.Label());
            this.label28 = (new global::System.Windows.Forms.Label());
            this.edStartTimeCut = (new global::System.Windows.Forms.TextBox());
            this.label29 = (new global::System.Windows.Forms.Label());
            this.tabPage54 = (new global::System.Windows.Forms.TabPage());
            this.label1 = (new global::System.Windows.Forms.Label());
            this.btSelectOutputJoin = (new global::System.Windows.Forms.Button());
            this.edOutputFileJoin = (new global::System.Windows.Forms.TextBox());
            this.label132 = (new global::System.Windows.Forms.Label());
            this.btStopJoin = (new global::System.Windows.Forms.Button());
            this.btStartJoin = (new global::System.Windows.Forms.Button());
            this.btClearList3 = (new global::System.Windows.Forms.Button());
            this.btAddInputFile3 = (new global::System.Windows.Forms.Button());
            this.lbFiles2 = (new global::System.Windows.Forms.ListBox());
            this.label32 = (new global::System.Windows.Forms.Label());
            this.tabPage74 = (new global::System.Windows.Forms.TabPage());
            this.label168 = (new global::System.Windows.Forms.Label());
            this.cbMuxStreamsShortest = (new global::System.Windows.Forms.CheckBox());
            this.cbMuxStreamsType = (new global::System.Windows.Forms.ComboBox());
            this.btMuxStreamsSelectFile = (new global::System.Windows.Forms.Button());
            this.edMuxStreamsSourceFile = (new global::System.Windows.Forms.TextBox());
            this.label167 = (new global::System.Windows.Forms.Label());
            this.btMuxStreamsSelectOutput = (new global::System.Windows.Forms.Button());
            this.edMuxStreamsOutputFile = (new global::System.Windows.Forms.TextBox());
            this.label165 = (new global::System.Windows.Forms.Label());
            this.btStopMux = (new global::System.Windows.Forms.Button());
            this.btStartMux = (new global::System.Windows.Forms.Button());
            this.btMuxStreamsClear = (new global::System.Windows.Forms.Button());
            this.btMuxStreamsAdd = (new global::System.Windows.Forms.Button());
            this.lbMuxStreamsList = (new global::System.Windows.Forms.ListBox());
            this.label166 = (new global::System.Windows.Forms.Label());
            this.cbMode = (new global::System.Windows.Forms.ComboBox());
            this.label130 = (new global::System.Windows.Forms.Label());
            this.openFileDialogSubtitles = (new global::System.Windows.Forms.OpenFileDialog());
            this.cbTelemetry = (new global::System.Windows.Forms.CheckBox());
            this.cbLicensing = (new global::System.Windows.Forms.CheckBox());
            this.cbDebugMode = (new global::System.Windows.Forms.CheckBox());
            this.mmLog = (new global::System.Windows.Forms.TextBox());
            this.VideoView1 = (new global::VisioForge.Core.UI.WinForms.VideoView());
            this.folderBrowserDialog1 = (new global::System.Windows.Forms.FolderBrowserDialog());
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage48.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabControl17.SuspendLayout();
            this.tabPage68.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.tabPage29.SuspendLayout();
            this.tabPage42.SuspendLayout();
            this.tabPage22.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.tabPage23.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.tabPage43.SuspendLayout();
            this.groupBox45.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage69.SuspendLayout();
            this.tabPage59.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabControl15.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage26.SuspendLayout();
            this.tabPage20.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).BeginInit();
            this.tabPage70.SuspendLayout();
            this.tabPage82.SuspendLayout();
            this.tabPage83.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage66.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            this.tabPage16.SuspendLayout();
            this.tabPage81.SuspendLayout();
            this.groupBox41.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).BeginInit();
            this.tabPage27.SuspendLayout();
            this.tabControl9.SuspendLayout();
            this.tabPage44.SuspendLayout();
            this.tabPage45.SuspendLayout();
            this.groupBox25.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage25.SuspendLayout();
            this.tabPage28.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage32.SuspendLayout();
            this.tabPage49.SuspendLayout();
            this.tabPage50.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage77.SuspendLayout();
            this.tabPage51.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage34.SuspendLayout();
            this.tabPage46.SuspendLayout();
            this.tabPage47.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox43.SuspendLayout();
            this.tabPage79.SuspendLayout();
            this.TabControl32.SuspendLayout();
            this.TabPage142.SuspendLayout();
            this.TabPage143.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgTagCover)).BeginInit();
            this.tabPage24.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSeeking)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage52.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.tabPage53.SuspendLayout();
            this.tabPage54.SuspendLayout();
            this.tabPage74.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage31);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage66);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage81);
            this.tabControl1.Controls.Add(this.tabPage27);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage25);
            this.tabControl1.Controls.Add(this.tabPage28);
            this.tabControl1.Controls.Add(this.tabPage34);
            this.tabControl1.Controls.Add(this.tabPage46);
            this.tabControl1.Controls.Add(this.tabPage47);
            this.tabControl1.Controls.Add(this.tabPage79);
            this.tabControl1.Controls.Add(this.tabPage24);
            this.tabControl1.Location = (new global::System.Drawing.Point(20, 22));
            this.tabControl1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl1.Name = ("tabControl1");
            this.tabControl1.SelectedIndex = (0);
            this.tabControl1.Size = (new global::System.Drawing.Size(517, 1000));
            this.tabControl1.TabIndex = (0);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage1.Name = ("tabPage1");
            this.tabPage1.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage1.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage1.TabIndex = (0);
            this.tabPage1.Text = ("Output");
            this.tabPage1.UseVisualStyleBackColor = (true);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage30);
            this.tabControl2.Controls.Add(this.tabPage48);
            this.tabControl2.Location = (new global::System.Drawing.Point(7, 11));
            this.tabControl2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl2.Name = ("tabControl2");
            this.tabControl2.SelectedIndex = (0);
            this.tabControl2.Size = (new global::System.Drawing.Size(487, 928));
            this.tabControl2.TabIndex = (10);
            // 
            // tabPage30
            // 
            this.tabPage30.Controls.Add(this.llXiphX64);
            this.tabPage30.Controls.Add(this.llXiphX86);
            this.tabPage30.Controls.Add(this.label68);
            this.tabPage30.Controls.Add(this.label67);
            this.tabPage30.Controls.Add(this.lbInfo);
            this.tabPage30.Controls.Add(this.btConfigure);
            this.tabPage30.Controls.Add(this.btSelectOutput);
            this.tabPage30.Controls.Add(this.edOutput);
            this.tabPage30.Controls.Add(this.label15);
            this.tabPage30.Controls.Add(this.cbOutputVideoFormat);
            this.tabPage30.Controls.Add(this.label9);
            this.tabPage30.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage30.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage30.Name = ("tabPage30");
            this.tabPage30.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage30.Size = (new global::System.Drawing.Size(479, 890));
            this.tabPage30.TabIndex = (6);
            this.tabPage30.Text = ("Main");
            this.tabPage30.UseVisualStyleBackColor = (true);
            // 
            // llXiphX64
            // 
            this.llXiphX64.AutoSize = (true);
            this.llXiphX64.Location = (new global::System.Drawing.Point(249, 431));
            this.llXiphX64.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.llXiphX64.Name = ("llXiphX64");
            this.llXiphX64.Size = (new global::System.Drawing.Size(40, 25));
            this.llXiphX64.TabIndex = (59);
            this.llXiphX64.TabStop = (true);
            this.llXiphX64.Text = ("x64");
            this.llXiphX64.LinkClicked += (this.llXiphX64_LinkClicked);
            // 
            // llXiphX86
            // 
            this.llXiphX86.AutoSize = (true);
            this.llXiphX86.Location = (new global::System.Drawing.Point(198, 431));
            this.llXiphX86.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.llXiphX86.Name = ("llXiphX86");
            this.llXiphX86.Size = (new global::System.Drawing.Size(40, 25));
            this.llXiphX86.TabIndex = (58);
            this.llXiphX86.TabStop = (true);
            this.llXiphX86.Text = ("x86");
            this.llXiphX86.LinkClicked += (this.llXiphX86_LinkClicked);
            // 
            // label68
            // 
            this.label68.AutoSize = (true);
            this.label68.Location = (new global::System.Drawing.Point(0, 431));
            this.label68.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label68.Name = ("label68");
            this.label68.Size = (new global::System.Drawing.Size(197, 25));
            this.label68.TabIndex = (57);
            this.label68.Text = ("and Ogg Vorbis output");
            // 
            // label67
            // 
            this.label67.AutoSize = (true);
            this.label67.Location = (new global::System.Drawing.Point(0, 389));
            this.label67.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label67.Name = ("label67");
            this.label67.Size = (new global::System.Drawing.Size(465, 25));
            this.label67.TabIndex = (56);
            this.label67.Text = ("Additional redist required to be installed for FLAC, Speex,");
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = (true);
            this.lbInfo.Location = (new global::System.Drawing.Point(13, 122));
            this.lbInfo.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbInfo.Name = ("lbInfo");
            this.lbInfo.Size = (new global::System.Drawing.Size(454, 25));
            this.lbInfo.TabIndex = (52);
            this.lbInfo.Text = ("You can use dialog or code to configure format settings");
            // 
            // btConfigure
            // 
            this.btConfigure.Location = (new global::System.Drawing.Point(18, 165));
            this.btConfigure.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btConfigure.Name = ("btConfigure");
            this.btConfigure.Size = (new global::System.Drawing.Size(102, 44));
            this.btConfigure.TabIndex = (32);
            this.btConfigure.Text = ("Configure");
            this.btConfigure.UseVisualStyleBackColor = (true);
            this.btConfigure.Click += (this.btConfigure_Click);
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = (new global::System.Drawing.Point(407, 290));
            this.btSelectOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectOutput.Name = ("btSelectOutput");
            this.btSelectOutput.Size = (new global::System.Drawing.Size(43, 44));
            this.btSelectOutput.TabIndex = (31);
            this.btSelectOutput.Text = ("...");
            this.btSelectOutput.UseVisualStyleBackColor = (true);
            this.btSelectOutput.Click += (this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = (new global::System.Drawing.Point(18, 294));
            this.edOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOutput.Name = ("edOutput");
            this.edOutput.Size = (new global::System.Drawing.Size(375, 31));
            this.edOutput.TabIndex = (30);
            this.edOutput.Text = ("c:\\vf\\video_edit_output.avi");
            // 
            // label15
            // 
            this.label15.AutoSize = (true);
            this.label15.Location = (new global::System.Drawing.Point(13, 260));
            this.label15.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label15.Name = ("label15");
            this.label15.Size = (new global::System.Drawing.Size(87, 25));
            this.label15.TabIndex = (29);
            this.label15.Text = ("File name");
            // 
            // cbOutputVideoFormat
            // 
            this.cbOutputVideoFormat.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbOutputVideoFormat.FormattingEnabled = (true);
            this.cbOutputVideoFormat.Items.AddRange(new global::System.Object[] { "AVI", "MKV (Matroska)", "WMV (Windows Media Video)", "DV", "PCM/ACM", "MP3", "M4A (AAC)", "WMA (Windows Media Audio)", "Ogg Vorbis", "FLAC", "Speex", "Custom format", "WebM", "FFMPEG", "FFMPEG (external exe)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video" });
            this.cbOutputVideoFormat.Location = (new global::System.Drawing.Point(18, 65));
            this.cbOutputVideoFormat.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbOutputVideoFormat.Name = ("cbOutputVideoFormat");
            this.cbOutputVideoFormat.Size = (new global::System.Drawing.Size(428, 33));
            this.cbOutputVideoFormat.TabIndex = (28);
            this.cbOutputVideoFormat.SelectedIndexChanged += (this.cbOutputVideoFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = (true);
            this.label9.Location = (new global::System.Drawing.Point(13, 31));
            this.label9.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label9.Name = ("label9");
            this.label9.Size = (new global::System.Drawing.Size(69, 25));
            this.label9.TabIndex = (27);
            this.label9.Text = ("Format");
            // 
            // tabPage48
            // 
            this.tabPage48.Controls.Add(this.edCropRight);
            this.tabPage48.Controls.Add(this.label176);
            this.tabPage48.Controls.Add(this.edCropBottom);
            this.tabPage48.Controls.Add(this.label252);
            this.tabPage48.Controls.Add(this.edCropLeft);
            this.tabPage48.Controls.Add(this.label270);
            this.tabPage48.Controls.Add(this.edCropTop);
            this.tabPage48.Controls.Add(this.label272);
            this.tabPage48.Controls.Add(this.cbCrop);
            this.tabPage48.Controls.Add(this.label92);
            this.tabPage48.Controls.Add(this.cbRotate);
            this.tabPage48.Controls.Add(this.cbFrameRate);
            this.tabPage48.Controls.Add(this.label3);
            this.tabPage48.Controls.Add(this.edHeight);
            this.tabPage48.Controls.Add(this.edWidth);
            this.tabPage48.Controls.Add(this.label2);
            this.tabPage48.Controls.Add(this.cbResize);
            this.tabPage48.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage48.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage48.Name = ("tabPage48");
            this.tabPage48.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage48.Size = (new global::System.Drawing.Size(479, 890));
            this.tabPage48.TabIndex = (14);
            this.tabPage48.Text = ("Resolution / frame rate");
            this.tabPage48.UseVisualStyleBackColor = (true);
            // 
            // edCropRight
            // 
            this.edCropRight.Location = (new global::System.Drawing.Point(303, 421));
            this.edCropRight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edCropRight.Name = ("edCropRight");
            this.edCropRight.Size = (new global::System.Drawing.Size(57, 31));
            this.edCropRight.TabIndex = (174);
            this.edCropRight.Text = ("0");
            // 
            // label176
            // 
            this.label176.AutoSize = (true);
            this.label176.Location = (new global::System.Drawing.Point(236, 429));
            this.label176.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label176.Name = ("label176");
            this.label176.Size = (new global::System.Drawing.Size(54, 25));
            this.label176.TabIndex = (173);
            this.label176.Text = ("Right");
            // 
            // edCropBottom
            // 
            this.edCropBottom.Location = (new global::System.Drawing.Point(144, 421));
            this.edCropBottom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edCropBottom.Name = ("edCropBottom");
            this.edCropBottom.Size = (new global::System.Drawing.Size(57, 31));
            this.edCropBottom.TabIndex = (172);
            this.edCropBottom.Text = ("0");
            // 
            // label252
            // 
            this.label252.AutoSize = (true);
            this.label252.Location = (new global::System.Drawing.Point(69, 429));
            this.label252.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label252.Name = ("label252");
            this.label252.Size = (new global::System.Drawing.Size(72, 25));
            this.label252.TabIndex = (171);
            this.label252.Text = ("Bottom");
            // 
            // edCropLeft
            // 
            this.edCropLeft.Location = (new global::System.Drawing.Point(303, 371));
            this.edCropLeft.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edCropLeft.Name = ("edCropLeft");
            this.edCropLeft.Size = (new global::System.Drawing.Size(57, 31));
            this.edCropLeft.TabIndex = (170);
            this.edCropLeft.Text = ("0");
            // 
            // label270
            // 
            this.label270.AutoSize = (true);
            this.label270.Location = (new global::System.Drawing.Point(236, 379));
            this.label270.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label270.Name = ("label270");
            this.label270.Size = (new global::System.Drawing.Size(41, 25));
            this.label270.TabIndex = (169);
            this.label270.Text = ("Left");
            // 
            // edCropTop
            // 
            this.edCropTop.Location = (new global::System.Drawing.Point(144, 371));
            this.edCropTop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edCropTop.Name = ("edCropTop");
            this.edCropTop.Size = (new global::System.Drawing.Size(57, 31));
            this.edCropTop.TabIndex = (168);
            this.edCropTop.Text = ("0");
            // 
            // label272
            // 
            this.label272.AutoSize = (true);
            this.label272.Location = (new global::System.Drawing.Point(69, 379));
            this.label272.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label272.Name = ("label272");
            this.label272.Size = (new global::System.Drawing.Size(41, 25));
            this.label272.TabIndex = (167);
            this.label272.Text = ("Top");
            // 
            // cbCrop
            // 
            this.cbCrop.AutoSize = (true);
            this.cbCrop.Location = (new global::System.Drawing.Point(23, 329));
            this.cbCrop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbCrop.Name = ("cbCrop");
            this.cbCrop.Size = (new global::System.Drawing.Size(77, 29));
            this.cbCrop.TabIndex = (166);
            this.cbCrop.Text = ("Crop");
            this.cbCrop.UseVisualStyleBackColor = (true);
            // 
            // label92
            // 
            this.label92.AutoSize = (true);
            this.label92.Location = (new global::System.Drawing.Point(18, 269));
            this.label92.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label92.Name = ("label92");
            this.label92.Size = (new global::System.Drawing.Size(63, 25));
            this.label92.TabIndex = (165);
            this.label92.Text = ("Rotate");
            // 
            // cbRotate
            // 
            this.cbRotate.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbRotate.FormattingEnabled = (true);
            this.cbRotate.Items.AddRange(new global::System.Object[] { "0", "90", "180", "270" });
            this.cbRotate.Location = (new global::System.Drawing.Point(144, 264));
            this.cbRotate.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbRotate.Name = ("cbRotate");
            this.cbRotate.Size = (new global::System.Drawing.Size(197, 33));
            this.cbRotate.TabIndex = (164);
            // 
            // cbFrameRate
            // 
            this.cbFrameRate.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbFrameRate.FormattingEnabled = (true);
            this.cbFrameRate.Items.AddRange(new global::System.Object[] { "0", "1", "2", "5", "10", "12", "15", "20", "25", "30" });
            this.cbFrameRate.Location = (new global::System.Drawing.Point(23, 121));
            this.cbFrameRate.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFrameRate.Name = ("cbFrameRate");
            this.cbFrameRate.Size = (new global::System.Drawing.Size(94, 33));
            this.cbFrameRate.TabIndex = (163);
            // 
            // label3
            // 
            this.label3.AutoSize = (true);
            this.label3.Location = (new global::System.Drawing.Point(18, 90));
            this.label3.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label3.Name = ("label3");
            this.label3.Size = (new global::System.Drawing.Size(469, 25));
            this.label3.TabIndex = (162);
            this.label3.Text = ("Frame rate (Use 0 to have original, set before adding files)");
            // 
            // edHeight
            // 
            this.edHeight.Location = (new global::System.Drawing.Point(264, 25));
            this.edHeight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHeight.Name = ("edHeight");
            this.edHeight.Size = (new global::System.Drawing.Size(77, 31));
            this.edHeight.TabIndex = (161);
            this.edHeight.Text = ("576");
            // 
            // edWidth
            // 
            this.edWidth.Location = (new global::System.Drawing.Point(144, 25));
            this.edWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edWidth.Name = ("edWidth");
            this.edWidth.Size = (new global::System.Drawing.Size(77, 31));
            this.edWidth.TabIndex = (160);
            this.edWidth.Text = ("768");
            // 
            // label2
            // 
            this.label2.AutoSize = (true);
            this.label2.Location = (new global::System.Drawing.Point(236, 31));
            this.label2.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label2.Name = ("label2");
            this.label2.Size = (new global::System.Drawing.Size(20, 25));
            this.label2.TabIndex = (159);
            this.label2.Text = ("x");
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = (true);
            this.cbResize.Location = (new global::System.Drawing.Point(23, 31));
            this.cbResize.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbResize.Name = ("cbResize");
            this.cbResize.Size = (new global::System.Drawing.Size(86, 29));
            this.cbResize.TabIndex = (158);
            this.cbResize.Text = ("Resize");
            this.cbResize.UseVisualStyleBackColor = (true);
            // 
            // tabPage31
            // 
            this.tabPage31.Controls.Add(this.tabControl17);
            this.tabPage31.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage31.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage31.Name = ("tabPage31");
            this.tabPage31.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage31.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage31.TabIndex = (4);
            this.tabPage31.Text = ("Video processing");
            this.tabPage31.UseVisualStyleBackColor = (true);
            // 
            // tabControl17
            // 
            this.tabControl17.Controls.Add(this.tabPage68);
            this.tabControl17.Controls.Add(this.tabPage69);
            this.tabControl17.Controls.Add(this.tabPage59);
            this.tabControl17.Controls.Add(this.tabPage15);
            this.tabControl17.Controls.Add(this.tabPage20);
            this.tabControl17.Controls.Add(this.tabPage70);
            this.tabControl17.Controls.Add(this.tabPage82);
            this.tabControl17.Controls.Add(this.tabPage83);
            this.tabControl17.Location = (new global::System.Drawing.Point(2, 11));
            this.tabControl17.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl17.Name = ("tabControl17");
            this.tabControl17.SelectedIndex = (0);
            this.tabControl17.Size = (new global::System.Drawing.Size(497, 932));
            this.tabControl17.TabIndex = (37);
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
            this.tabPage68.Controls.Add(this.cbEffects);
            this.tabPage68.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage68.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage68.Name = ("tabPage68");
            this.tabPage68.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage68.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage68.TabIndex = (0);
            this.tabPage68.Text = ("Effects");
            this.tabPage68.UseVisualStyleBackColor = (true);
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = (true);
            this.cbFlipY.Location = (new global::System.Drawing.Point(350, 304));
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
            this.cbFlipX.Location = (new global::System.Drawing.Point(250, 304));
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
            this.label201.Location = (new global::System.Drawing.Point(237, 169));
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
            this.label199.Location = (new global::System.Drawing.Point(237, 69));
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
            this.tabControl7.Controls.Add(this.tabPage22);
            this.tabControl7.Controls.Add(this.tabPage23);
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
            this.btTextLogoRemove.Location = (new global::System.Drawing.Point(343, 414));
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
            this.btTextLogoEdit.Location = (new global::System.Drawing.Point(123, 414));
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
            this.lbTextLogos.Location = (new global::System.Drawing.Point(17, 22));
            this.lbTextLogos.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbTextLogos.Name = ("lbTextLogos");
            this.lbTextLogos.Size = (new global::System.Drawing.Size(426, 379));
            this.lbTextLogos.TabIndex = (5);
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = (new global::System.Drawing.Point(13, 414));
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
            this.btImageLogoRemove.Location = (new global::System.Drawing.Point(343, 414));
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
            this.btImageLogoEdit.Location = (new global::System.Drawing.Point(123, 414));
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
            this.lbImageLogos.Location = (new global::System.Drawing.Point(17, 22));
            this.lbImageLogos.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbImageLogos.Name = ("lbImageLogos");
            this.lbImageLogos.Size = (new global::System.Drawing.Size(426, 379));
            this.lbImageLogos.TabIndex = (9);
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = (new global::System.Drawing.Point(13, 414));
            this.btImageLogoAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btImageLogoAdd.Name = ("btImageLogoAdd");
            this.btImageLogoAdd.Size = (new global::System.Drawing.Size(98, 44));
            this.btImageLogoAdd.TabIndex = (8);
            this.btImageLogoAdd.Text = ("Add");
            this.btImageLogoAdd.UseVisualStyleBackColor = (true);
            this.btImageLogoAdd.Click += (this.btImageLogoAdd_Click);
            // 
            // tabPage22
            // 
            this.tabPage22.Controls.Add(this.groupBox37);
            this.tabPage22.Controls.Add(this.cbZoom);
            this.tabPage22.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage22.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage22.Name = ("tabPage22");
            this.tabPage22.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage22.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage22.TabIndex = (2);
            this.tabPage22.Text = ("Zoom");
            this.tabPage22.UseVisualStyleBackColor = (true);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.btEffZoomRight);
            this.groupBox37.Controls.Add(this.btEffZoomLeft);
            this.groupBox37.Controls.Add(this.btEffZoomOut);
            this.groupBox37.Controls.Add(this.btEffZoomIn);
            this.groupBox37.Controls.Add(this.btEffZoomDown);
            this.groupBox37.Controls.Add(this.btEffZoomUp);
            this.groupBox37.Location = (new global::System.Drawing.Point(143, 98));
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
            this.btEffZoomIn.Size = (new global::System.Drawing.Size(37, 44));
            this.btEffZoomIn.TabIndex = (2);
            this.btEffZoomIn.Text = ("+");
            this.btEffZoomIn.UseVisualStyleBackColor = (true);
            this.btEffZoomIn.Click += (this.btEffZoomIn_Click);
            // 
            // btEffZoomDown
            // 
            this.btEffZoomDown.Location = (new global::System.Drawing.Point(57, 132));
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
            this.btEffZoomUp.Location = (new global::System.Drawing.Point(57, 39));
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
            this.cbZoom.Location = (new global::System.Drawing.Point(20, 29));
            this.cbZoom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbZoom.Name = ("cbZoom");
            this.cbZoom.Size = (new global::System.Drawing.Size(101, 29));
            this.cbZoom.TabIndex = (17);
            this.cbZoom.Text = ("Enabled");
            this.cbZoom.UseVisualStyleBackColor = (true);
            this.cbZoom.CheckedChanged += (this.cbZoom_CheckedChanged);
            // 
            // tabPage23
            // 
            this.tabPage23.Controls.Add(this.groupBox40);
            this.tabPage23.Controls.Add(this.groupBox39);
            this.tabPage23.Controls.Add(this.groupBox38);
            this.tabPage23.Controls.Add(this.cbPan);
            this.tabPage23.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage23.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage23.Name = ("tabPage23");
            this.tabPage23.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage23.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage23.TabIndex = (3);
            this.tabPage23.Text = ("Pan");
            this.tabPage23.UseVisualStyleBackColor = (true);
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
            this.groupBox40.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.groupBox40.Name = ("groupBox40");
            this.groupBox40.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
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
            this.label302.Location = (new global::System.Drawing.Point(136, 104));
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
            this.label303.Location = (new global::System.Drawing.Point(136, 54));
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
            this.label304.Location = (new global::System.Drawing.Point(22, 104));
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
            this.label305.Location = (new global::System.Drawing.Point(22, 54));
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
            this.groupBox39.Location = (new global::System.Drawing.Point(20, 154));
            this.groupBox39.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.groupBox39.Name = ("groupBox39");
            this.groupBox39.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
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
            this.label298.Location = (new global::System.Drawing.Point(136, 104));
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
            this.label299.Location = (new global::System.Drawing.Point(136, 54));
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
            this.label300.Location = (new global::System.Drawing.Point(22, 104));
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
            this.label301.Location = (new global::System.Drawing.Point(22, 54));
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
            this.label296.Location = (new global::System.Drawing.Point(147, 42));
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
            this.label297.Location = (new global::System.Drawing.Point(17, 42));
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
            // tabPage43
            // 
            this.tabPage43.Controls.Add(this.rbVideoFadeOut);
            this.tabPage43.Controls.Add(this.rbVideoFadeIn);
            this.tabPage43.Controls.Add(this.groupBox45);
            this.tabPage43.Controls.Add(this.cbVideoFadeInOut);
            this.tabPage43.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage43.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage43.Name = ("tabPage43");
            this.tabPage43.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage43.Size = (new global::System.Drawing.Size(463, 490));
            this.tabPage43.TabIndex = (4);
            this.tabPage43.Text = ("Fade-in/out");
            this.tabPage43.UseVisualStyleBackColor = (true);
            // 
            // rbVideoFadeOut
            // 
            this.rbVideoFadeOut.AutoSize = (true);
            this.rbVideoFadeOut.Location = (new global::System.Drawing.Point(178, 200));
            this.rbVideoFadeOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoFadeOut.Name = ("rbVideoFadeOut");
            this.rbVideoFadeOut.Size = (new global::System.Drawing.Size(108, 29));
            this.rbVideoFadeOut.TabIndex = (60);
            this.rbVideoFadeOut.TabStop = (true);
            this.rbVideoFadeOut.Text = ("Fade-out");
            this.rbVideoFadeOut.UseVisualStyleBackColor = (true);
            // 
            // rbVideoFadeIn
            // 
            this.rbVideoFadeIn.AutoSize = (true);
            this.rbVideoFadeIn.Checked = (true);
            this.rbVideoFadeIn.Location = (new global::System.Drawing.Point(27, 200));
            this.rbVideoFadeIn.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVideoFadeIn.Name = ("rbVideoFadeIn");
            this.rbVideoFadeIn.Size = (new global::System.Drawing.Size(95, 29));
            this.rbVideoFadeIn.TabIndex = (59);
            this.rbVideoFadeIn.TabStop = (true);
            this.rbVideoFadeIn.Text = ("Fade-in");
            this.rbVideoFadeIn.UseVisualStyleBackColor = (true);
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.edVideoFadeInOutStopTime);
            this.groupBox45.Controls.Add(this.label329);
            this.groupBox45.Controls.Add(this.edVideoFadeInOutStartTime);
            this.groupBox45.Controls.Add(this.label330);
            this.groupBox45.Location = (new global::System.Drawing.Point(27, 100));
            this.groupBox45.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox45.Name = ("groupBox45");
            this.groupBox45.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox45.Size = (new global::System.Drawing.Size(280, 89));
            this.groupBox45.TabIndex = (58);
            this.groupBox45.TabStop = (false);
            this.groupBox45.Text = ("Duration");
            // 
            // edVideoFadeInOutStopTime
            // 
            this.edVideoFadeInOutStopTime.Location = (new global::System.Drawing.Point(196, 36));
            this.edVideoFadeInOutStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edVideoFadeInOutStopTime.Name = ("edVideoFadeInOutStopTime");
            this.edVideoFadeInOutStopTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edVideoFadeInOutStopTime.TabIndex = (34);
            this.edVideoFadeInOutStopTime.Text = ("15000");
            this.edVideoFadeInOutStopTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label329
            // 
            this.label329.AutoSize = (true);
            this.label329.Location = (new global::System.Drawing.Point(147, 42));
            this.label329.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label329.Name = ("label329");
            this.label329.Size = (new global::System.Drawing.Size(49, 25));
            this.label329.TabIndex = (33);
            this.label329.Text = ("Stop");
            // 
            // edVideoFadeInOutStartTime
            // 
            this.edVideoFadeInOutStartTime.Location = (new global::System.Drawing.Point(71, 36));
            this.edVideoFadeInOutStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edVideoFadeInOutStartTime.Name = ("edVideoFadeInOutStartTime");
            this.edVideoFadeInOutStartTime.Size = (new global::System.Drawing.Size(62, 31));
            this.edVideoFadeInOutStartTime.TabIndex = (32);
            this.edVideoFadeInOutStartTime.Text = ("5000");
            this.edVideoFadeInOutStartTime.TextAlign = (global::System.Windows.Forms.HorizontalAlignment.Center);
            // 
            // label330
            // 
            this.label330.AutoSize = (true);
            this.label330.Location = (new global::System.Drawing.Point(17, 42));
            this.label330.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label330.Name = ("label330");
            this.label330.Size = (new global::System.Drawing.Size(48, 25));
            this.label330.TabIndex = (31);
            this.label330.Text = ("Start");
            // 
            // cbVideoFadeInOut
            // 
            this.cbVideoFadeInOut.AutoSize = (true);
            this.cbVideoFadeInOut.Location = (new global::System.Drawing.Point(27, 35));
            this.cbVideoFadeInOut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVideoFadeInOut.Name = ("cbVideoFadeInOut");
            this.cbVideoFadeInOut.Size = (new global::System.Drawing.Size(101, 29));
            this.cbVideoFadeInOut.TabIndex = (57);
            this.cbVideoFadeInOut.Text = ("Enabled");
            this.cbVideoFadeInOut.UseVisualStyleBackColor = (true);
            this.cbVideoFadeInOut.CheckedChanged += (this.cbFadeInOut_CheckedChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbContrast.Location = (new global::System.Drawing.Point(4, 206));
            this.tbContrast.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbContrast.Maximum = (255);
            this.tbContrast.Name = ("tbContrast");
            this.tbContrast.Size = (new global::System.Drawing.Size(217, 69));
            this.tbContrast.TabIndex = (49);
            this.tbContrast.Scroll += (this.tbContrast_Scroll);
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbDarkness.Location = (new global::System.Drawing.Point(237, 206));
            this.tbDarkness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbDarkness.Maximum = (255);
            this.tbDarkness.Name = ("tbDarkness");
            this.tbDarkness.Size = (new global::System.Drawing.Size(217, 69));
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
            this.tbLightness.Size = (new global::System.Drawing.Size(217, 69));
            this.tbLightness.TabIndex = (45);
            this.tbLightness.Scroll += (this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbSaturation.Location = (new global::System.Drawing.Point(237, 98));
            this.tbSaturation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbSaturation.Maximum = (255);
            this.tbSaturation.Name = ("tbSaturation");
            this.tbSaturation.Size = (new global::System.Drawing.Size(217, 69));
            this.tbSaturation.TabIndex = (43);
            this.tbSaturation.Value = (255);
            this.tbSaturation.Scroll += (this.tbSaturation_Scroll);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = (true);
            this.cbInvert.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbInvert.Location = (new global::System.Drawing.Point(150, 304));
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
            this.cbGreyscale.Location = (new global::System.Drawing.Point(16, 304));
            this.cbGreyscale.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGreyscale.Name = ("cbGreyscale");
            this.cbGreyscale.Size = (new global::System.Drawing.Size(112, 29));
            this.cbGreyscale.TabIndex = (39);
            this.cbGreyscale.Text = ("Greyscale");
            this.cbGreyscale.UseVisualStyleBackColor = (true);
            this.cbGreyscale.CheckedChanged += (this.cbGreyscale_CheckedChanged);
            // 
            // cbEffects
            // 
            this.cbEffects.AutoSize = (true);
            this.cbEffects.Checked = (true);
            this.cbEffects.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbEffects.Location = (new global::System.Drawing.Point(13, 15));
            this.cbEffects.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbEffects.Name = ("cbEffects");
            this.cbEffects.Size = (new global::System.Drawing.Size(101, 29));
            this.cbEffects.TabIndex = (37);
            this.cbEffects.Text = ("Enabled");
            this.cbEffects.UseVisualStyleBackColor = (true);
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
            this.tabPage69.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage69.TabIndex = (1);
            this.tabPage69.Text = ("Deinterlace");
            this.tabPage69.UseVisualStyleBackColor = (true);
            // 
            // label211
            // 
            this.label211.AutoSize = (true);
            this.label211.Location = (new global::System.Drawing.Point(167, 565));
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
            this.edDeintTriangleWeight.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintTriangleWeight.TabIndex = (27);
            this.edDeintTriangleWeight.Text = ("180");
            // 
            // label212
            // 
            this.label212.AutoSize = (true);
            this.label212.Location = (new global::System.Drawing.Point(57, 525));
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
            this.label206.Location = (new global::System.Drawing.Point(363, 410));
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
            this.edDeintBlendConstants2.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintBlendConstants2.TabIndex = (22);
            this.edDeintBlendConstants2.Text = ("9");
            // 
            // label207
            // 
            this.label207.AutoSize = (true);
            this.label207.Location = (new global::System.Drawing.Point(253, 369));
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
            this.edDeintBlendConstants1.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintBlendConstants1.TabIndex = (20);
            this.edDeintBlendConstants1.Text = ("3");
            // 
            // label208
            // 
            this.label208.AutoSize = (true);
            this.label208.Location = (new global::System.Drawing.Point(253, 306));
            this.label208.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label208.Name = ("label208");
            this.label208.Size = (new global::System.Drawing.Size(106, 25));
            this.label208.TabIndex = (19);
            this.label208.Text = ("Constants 1");
            // 
            // label204
            // 
            this.label204.AutoSize = (true);
            this.label204.Location = (new global::System.Drawing.Point(167, 410));
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
            this.edDeintBlendThreshold2.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintBlendThreshold2.TabIndex = (17);
            this.edDeintBlendThreshold2.Text = ("9");
            // 
            // label205
            // 
            this.label205.AutoSize = (true);
            this.label205.Location = (new global::System.Drawing.Point(57, 369));
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
            this.edDeintBlendThreshold1.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintBlendThreshold1.TabIndex = (15);
            this.edDeintBlendThreshold1.Text = ("5");
            // 
            // label203
            // 
            this.label203.AutoSize = (true);
            this.label203.Location = (new global::System.Drawing.Point(57, 306));
            this.label203.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label203.Name = ("label203");
            this.label203.Size = (new global::System.Drawing.Size(105, 25));
            this.label203.TabIndex = (14);
            this.label203.Text = ("Threshold 1");
            // 
            // label202
            // 
            this.label202.AutoSize = (true);
            this.label202.Location = (new global::System.Drawing.Point(167, 198));
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
            this.edDeintCAVTThreshold.Size = (new global::System.Drawing.Size(51, 31));
            this.edDeintCAVTThreshold.TabIndex = (12);
            this.edDeintCAVTThreshold.Text = ("20");
            // 
            // label104
            // 
            this.label104.AutoSize = (true);
            this.label104.Location = (new global::System.Drawing.Point(57, 158));
            this.label104.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label104.Name = ("label104");
            this.label104.Size = (new global::System.Drawing.Size(90, 25));
            this.label104.TabIndex = (11);
            this.label104.Text = ("Threshold");
            // 
            // rbDeintTriangleEnabled
            // 
            this.rbDeintTriangleEnabled.AutoSize = (true);
            this.rbDeintTriangleEnabled.Location = (new global::System.Drawing.Point(30, 468));
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
            this.tabPage59.Size = (new global::System.Drawing.Size(489, 894));
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
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.tabControl15);
            this.tabPage15.Controls.Add(this.label16);
            this.tabPage15.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage15.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage15.Name = ("tabPage15");
            this.tabPage15.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage15.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage15.TabIndex = (5);
            this.tabPage15.Text = ("Object detection");
            this.tabPage15.UseVisualStyleBackColor = (true);
            // 
            // tabControl15
            // 
            this.tabControl15.Controls.Add(this.tabPage21);
            this.tabControl15.Controls.Add(this.tabPage26);
            this.tabControl15.Location = (new global::System.Drawing.Point(16, 11));
            this.tabControl15.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl15.Name = ("tabControl15");
            this.tabControl15.SelectedIndex = (0);
            this.tabControl15.Size = (new global::System.Drawing.Size(463, 742));
            this.tabControl15.TabIndex = (3);
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.label64);
            this.tabPage21.Controls.Add(this.label65);
            this.tabPage21.Controls.Add(this.pbAFMotionLevel);
            this.tabPage21.Controls.Add(this.cbAFMotionHighlight);
            this.tabPage21.Controls.Add(this.cbAFMotionDetection);
            this.tabPage21.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage21.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage21.Name = ("tabPage21");
            this.tabPage21.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage21.Size = (new global::System.Drawing.Size(455, 704));
            this.tabPage21.TabIndex = (0);
            this.tabPage21.Text = ("Motion detection");
            this.tabPage21.UseVisualStyleBackColor = (true);
            // 
            // label64
            // 
            this.label64.AutoSize = (true);
            this.label64.Location = (new global::System.Drawing.Point(10, 175));
            this.label64.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label64.Name = ("label64");
            this.label64.Size = (new global::System.Drawing.Size(435, 25));
            this.label64.TabIndex = (4);
            this.label64.Text = ("Much more motion detection options available in API");
            // 
            // label65
            // 
            this.label65.AutoSize = (true);
            this.label65.Location = (new global::System.Drawing.Point(10, 606));
            this.label65.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label65.Name = ("label65");
            this.label65.Size = (new global::System.Drawing.Size(110, 25));
            this.label65.TabIndex = (3);
            this.label65.Text = ("Motion level");
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = (new global::System.Drawing.Point(10, 636));
            this.pbAFMotionLevel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pbAFMotionLevel.Name = ("pbAFMotionLevel");
            this.pbAFMotionLevel.Size = (new global::System.Drawing.Size(430, 44));
            this.pbAFMotionLevel.TabIndex = (2);
            // 
            // cbAFMotionHighlight
            // 
            this.cbAFMotionHighlight.AutoSize = (true);
            this.cbAFMotionHighlight.Location = (new global::System.Drawing.Point(24, 86));
            this.cbAFMotionHighlight.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAFMotionHighlight.Name = ("cbAFMotionHighlight");
            this.cbAFMotionHighlight.Size = (new global::System.Drawing.Size(111, 29));
            this.cbAFMotionHighlight.TabIndex = (1);
            this.cbAFMotionHighlight.Text = ("Highlight");
            this.cbAFMotionHighlight.UseVisualStyleBackColor = (true);
            this.cbAFMotionHighlight.CheckedChanged += (this.cbAFMotionHighlight_CheckedChanged);
            // 
            // cbAFMotionDetection
            // 
            this.cbAFMotionDetection.AutoSize = (true);
            this.cbAFMotionDetection.Location = (new global::System.Drawing.Point(24, 36));
            this.cbAFMotionDetection.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAFMotionDetection.Name = ("cbAFMotionDetection");
            this.cbAFMotionDetection.Size = (new global::System.Drawing.Size(221, 29));
            this.cbAFMotionDetection.TabIndex = (0);
            this.cbAFMotionDetection.Text = ("Enabled, detect objects");
            this.cbAFMotionDetection.UseVisualStyleBackColor = (true);
            this.cbAFMotionDetection.CheckedChanged += (this.cbAFMotionDetection_CheckedChanged);
            // 
            // tabPage26
            // 
            this.tabPage26.Controls.Add(this.label171);
            this.tabPage26.Controls.Add(this.label66);
            this.tabPage26.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage26.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage26.Name = ("tabPage26");
            this.tabPage26.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage26.Size = (new global::System.Drawing.Size(455, 704));
            this.tabPage26.TabIndex = (1);
            this.tabPage26.Text = ("Effects");
            this.tabPage26.UseVisualStyleBackColor = (true);
            // 
            // label171
            // 
            this.label171.AutoSize = (true);
            this.label171.Location = (new global::System.Drawing.Point(17, 78));
            this.label171.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label171.Name = ("label171");
            this.label171.Size = (new global::System.Drawing.Size(235, 25));
            this.label171.TabIndex = (1);
            this.label171.Text = ("OnVideoFrameBuffer event. ");
            // 
            // label66
            // 
            this.label66.AutoSize = (true);
            this.label66.Location = (new global::System.Drawing.Point(17, 35));
            this.label66.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label66.Name = ("label66");
            this.label66.Size = (new global::System.Drawing.Size(281, 25));
            this.label66.TabIndex = (0);
            this.label66.Text = ("You can add various effects using ");
            // 
            // label16
            // 
            this.label16.Location = (new global::System.Drawing.Point(0, 0));
            this.label16.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label16.Name = ("label16");
            this.label16.Size = (new global::System.Drawing.Size(167, 44));
            this.label16.TabIndex = (4);
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.pnChromaKeyColor);
            this.tabPage20.Controls.Add(this.btChromaKeySelectBGImage);
            this.tabPage20.Controls.Add(this.edChromaKeyImage);
            this.tabPage20.Controls.Add(this.label216);
            this.tabPage20.Controls.Add(this.label215);
            this.tabPage20.Controls.Add(this.tbChromaKeySmoothing);
            this.tabPage20.Controls.Add(this.label214);
            this.tabPage20.Controls.Add(this.tbChromaKeyThresholdSensitivity);
            this.tabPage20.Controls.Add(this.label213);
            this.tabPage20.Controls.Add(this.cbChromaKeyEnabled);
            this.tabPage20.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage20.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage20.Name = ("tabPage20");
            this.tabPage20.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage20.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage20.TabIndex = (6);
            this.tabPage20.Text = ("Chroma key");
            this.tabPage20.UseVisualStyleBackColor = (true);
            // 
            // pnChromaKeyColor
            // 
            this.pnChromaKeyColor.BackColor = (global::System.Drawing.Color.Lime);
            this.pnChromaKeyColor.ForeColor = (global::System.Drawing.SystemColors.Control);
            this.pnChromaKeyColor.Location = (new global::System.Drawing.Point(91, 385));
            this.pnChromaKeyColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnChromaKeyColor.Name = ("pnChromaKeyColor");
            this.pnChromaKeyColor.Size = (new global::System.Drawing.Size(43, 46));
            this.pnChromaKeyColor.TabIndex = (43);
            this.pnChromaKeyColor.MouseDown += (this.pnChromaKeyColor_MouseDown);
            // 
            // btChromaKeySelectBGImage
            // 
            this.btChromaKeySelectBGImage.Location = (new global::System.Drawing.Point(424, 504));
            this.btChromaKeySelectBGImage.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btChromaKeySelectBGImage.Name = ("btChromaKeySelectBGImage");
            this.btChromaKeySelectBGImage.Size = (new global::System.Drawing.Size(40, 44));
            this.btChromaKeySelectBGImage.TabIndex = (42);
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
            this.edChromaKeyImage.TabIndex = (41);
            this.edChromaKeyImage.Text = ("c:\\Samples\\pics\\1.jpg");
            // 
            // label216
            // 
            this.label216.AutoSize = (true);
            this.label216.Location = (new global::System.Drawing.Point(17, 478));
            this.label216.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label216.Name = ("label216");
            this.label216.Size = (new global::System.Drawing.Size(191, 25));
            this.label216.TabIndex = (40);
            this.label216.Text = ("Image background file");
            // 
            // label215
            // 
            this.label215.AutoSize = (true);
            this.label215.Location = (new global::System.Drawing.Point(17, 392));
            this.label215.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label215.Name = ("label215");
            this.label215.Size = (new global::System.Drawing.Size(55, 25));
            this.label215.TabIndex = (39);
            this.label215.Text = ("Color");
            // 
            // tbChromaKeySmoothing
            // 
            this.tbChromaKeySmoothing.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbChromaKeySmoothing.Location = (new global::System.Drawing.Point(22, 279));
            this.tbChromaKeySmoothing.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbChromaKeySmoothing.Maximum = (1000);
            this.tbChromaKeySmoothing.Name = ("tbChromaKeySmoothing");
            this.tbChromaKeySmoothing.Size = (new global::System.Drawing.Size(257, 69));
            this.tbChromaKeySmoothing.TabIndex = (38);
            this.tbChromaKeySmoothing.Value = (80);
            this.tbChromaKeySmoothing.Scroll += (this.tbChromaKeySmoothing_Scroll);
            // 
            // label214
            // 
            this.label214.AutoSize = (true);
            this.label214.Location = (new global::System.Drawing.Point(17, 244));
            this.label214.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label214.Name = ("label214");
            this.label214.Size = (new global::System.Drawing.Size(101, 25));
            this.label214.TabIndex = (37);
            this.label214.Text = ("Smoothing");
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            this.tbChromaKeyThresholdSensitivity.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbChromaKeyThresholdSensitivity.Location = (new global::System.Drawing.Point(22, 139));
            this.tbChromaKeyThresholdSensitivity.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbChromaKeyThresholdSensitivity.Maximum = (200);
            this.tbChromaKeyThresholdSensitivity.Name = ("tbChromaKeyThresholdSensitivity");
            this.tbChromaKeyThresholdSensitivity.Size = (new global::System.Drawing.Size(257, 69));
            this.tbChromaKeyThresholdSensitivity.TabIndex = (36);
            this.tbChromaKeyThresholdSensitivity.Value = (180);
            this.tbChromaKeyThresholdSensitivity.Scroll += (this.tbChromaKeyThresholdSensitivity_Scroll);
            // 
            // label213
            // 
            this.label213.AutoSize = (true);
            this.label213.Location = (new global::System.Drawing.Point(17, 104));
            this.label213.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label213.Name = ("label213");
            this.label213.Size = (new global::System.Drawing.Size(172, 25));
            this.label213.TabIndex = (35);
            this.label213.Text = ("Threshold sensitivity");
            // 
            // cbChromaKeyEnabled
            // 
            this.cbChromaKeyEnabled.AutoSize = (true);
            this.cbChromaKeyEnabled.Location = (new global::System.Drawing.Point(22, 29));
            this.cbChromaKeyEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbChromaKeyEnabled.Name = ("cbChromaKeyEnabled");
            this.cbChromaKeyEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbChromaKeyEnabled.TabIndex = (34);
            this.cbChromaKeyEnabled.Text = ("Enabled");
            this.cbChromaKeyEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage70
            // 
            this.tabPage70.Controls.Add(this.btFilterDeleteAll);
            this.tabPage70.Controls.Add(this.btFilterSettings2);
            this.tabPage70.Controls.Add(this.lbFilters);
            this.tabPage70.Controls.Add(this.label106);
            this.tabPage70.Controls.Add(this.btFilterSettings);
            this.tabPage70.Controls.Add(this.btFilterAdd);
            this.tabPage70.Controls.Add(this.cbFilters);
            this.tabPage70.Controls.Add(this.label105);
            this.tabPage70.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage70.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage70.Name = ("tabPage70");
            this.tabPage70.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage70.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage70.TabIndex = (3);
            this.tabPage70.Text = ("3rd-party filters");
            this.tabPage70.UseVisualStyleBackColor = (true);
            // 
            // btFilterDeleteAll
            // 
            this.btFilterDeleteAll.Location = (new global::System.Drawing.Point(350, 552));
            this.btFilterDeleteAll.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterDeleteAll.Name = ("btFilterDeleteAll");
            this.btFilterDeleteAll.Size = (new global::System.Drawing.Size(113, 44));
            this.btFilterDeleteAll.TabIndex = (16);
            this.btFilterDeleteAll.Text = ("Delete all");
            this.btFilterDeleteAll.UseVisualStyleBackColor = (true);
            this.btFilterDeleteAll.Click += (this.btFilterDeleteAll_Click);
            // 
            // btFilterSettings2
            // 
            this.btFilterSettings2.Location = (new global::System.Drawing.Point(30, 552));
            this.btFilterSettings2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterSettings2.Name = ("btFilterSettings2");
            this.btFilterSettings2.Size = (new global::System.Drawing.Size(109, 44));
            this.btFilterSettings2.TabIndex = (15);
            this.btFilterSettings2.Text = ("Settings");
            this.btFilterSettings2.UseVisualStyleBackColor = (true);
            this.btFilterSettings2.Click += (this.btFilterSettings2_Click);
            // 
            // lbFilters
            // 
            this.lbFilters.FormattingEnabled = (true);
            this.lbFilters.ItemHeight = (25);
            this.lbFilters.Location = (new global::System.Drawing.Point(30, 232));
            this.lbFilters.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbFilters.Name = ("lbFilters");
            this.lbFilters.Size = (new global::System.Drawing.Size(431, 304));
            this.lbFilters.TabIndex = (14);
            this.lbFilters.SelectedIndexChanged += (this.lbFilters_SelectedIndexChanged);
            // 
            // label106
            // 
            this.label106.AutoSize = (true);
            this.label106.Location = (new global::System.Drawing.Point(24, 202));
            this.label106.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label106.Name = ("label106");
            this.label106.Size = (new global::System.Drawing.Size(118, 25));
            this.label106.TabIndex = (13);
            this.label106.Text = ("Current filters");
            // 
            // btFilterSettings
            // 
            this.btFilterSettings.Location = (new global::System.Drawing.Point(350, 110));
            this.btFilterSettings.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterSettings.Name = ("btFilterSettings");
            this.btFilterSettings.Size = (new global::System.Drawing.Size(113, 44));
            this.btFilterSettings.TabIndex = (12);
            this.btFilterSettings.Text = ("Settings");
            this.btFilterSettings.UseVisualStyleBackColor = (true);
            this.btFilterSettings.Click += (this.btFilterSettings_Click);
            // 
            // btFilterAdd
            // 
            this.btFilterAdd.Location = (new global::System.Drawing.Point(30, 110));
            this.btFilterAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFilterAdd.Name = ("btFilterAdd");
            this.btFilterAdd.Size = (new global::System.Drawing.Size(64, 44));
            this.btFilterAdd.TabIndex = (11);
            this.btFilterAdd.Text = ("Add");
            this.btFilterAdd.UseVisualStyleBackColor = (true);
            this.btFilterAdd.Click += (this.btFilterAdd_Click);
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbFilters.FormattingEnabled = (true);
            this.cbFilters.Location = (new global::System.Drawing.Point(30, 58));
            this.cbFilters.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFilters.Name = ("cbFilters");
            this.cbFilters.Size = (new global::System.Drawing.Size(431, 33));
            this.cbFilters.TabIndex = (10);
            this.cbFilters.SelectedIndexChanged += (this.cbFilters_SelectedIndexChanged);
            // 
            // label105
            // 
            this.label105.AutoSize = (true);
            this.label105.Location = (new global::System.Drawing.Point(24, 28));
            this.label105.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label105.Name = ("label105");
            this.label105.Size = (new global::System.Drawing.Size(58, 25));
            this.label105.TabIndex = (9);
            this.label105.Text = ("Filters");
            // 
            // tabPage82
            // 
            this.tabPage82.Controls.Add(this.label177);
            this.tabPage82.Controls.Add(this.label129);
            this.tabPage82.Controls.Add(this.btSubtitlesSelectFile);
            this.tabPage82.Controls.Add(this.edSubtitlesFilename);
            this.tabPage82.Controls.Add(this.label114);
            this.tabPage82.Controls.Add(this.cbSubtitlesEnabled);
            this.tabPage82.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage82.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage82.Name = ("tabPage82");
            this.tabPage82.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage82.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage82.TabIndex = (7);
            this.tabPage82.Text = ("Subtitles");
            this.tabPage82.UseVisualStyleBackColor = (true);
            // 
            // label177
            // 
            this.label177.AutoSize = (true);
            this.label177.Location = (new global::System.Drawing.Point(18, 202));
            this.label177.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label177.Name = ("label177");
            this.label177.Size = (new global::System.Drawing.Size(136, 25));
            this.label177.TabIndex = (5);
            this.label177.Text = (" using interface.");
            // 
            // label129
            // 
            this.label129.AutoSize = (true);
            this.label129.Location = (new global::System.Drawing.Point(18, 165));
            this.label129.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label129.Name = ("label129");
            this.label129.Size = (new global::System.Drawing.Size(406, 25));
            this.label129.TabIndex = (4);
            this.label129.Text = ("Use OnSubtitleSettings event to set other settings");
            // 
            // btSubtitlesSelectFile
            // 
            this.btSubtitlesSelectFile.Location = (new global::System.Drawing.Point(418, 108));
            this.btSubtitlesSelectFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSubtitlesSelectFile.Name = ("btSubtitlesSelectFile");
            this.btSubtitlesSelectFile.Size = (new global::System.Drawing.Size(38, 44));
            this.btSubtitlesSelectFile.TabIndex = (3);
            this.btSubtitlesSelectFile.Text = ("...");
            this.btSubtitlesSelectFile.UseVisualStyleBackColor = (true);
            this.btSubtitlesSelectFile.Click += (this.btSubtitlesSelectFile_Click);
            // 
            // edSubtitlesFilename
            // 
            this.edSubtitlesFilename.Location = (new global::System.Drawing.Point(23, 111));
            this.edSubtitlesFilename.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edSubtitlesFilename.Name = ("edSubtitlesFilename");
            this.edSubtitlesFilename.Size = (new global::System.Drawing.Size(384, 31));
            this.edSubtitlesFilename.TabIndex = (2);
            // 
            // label114
            // 
            this.label114.AutoSize = (true);
            this.label114.Location = (new global::System.Drawing.Point(18, 81));
            this.label114.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label114.Name = ("label114");
            this.label114.Size = (new global::System.Drawing.Size(87, 25));
            this.label114.TabIndex = (1);
            this.label114.Text = ("File name");
            // 
            // cbSubtitlesEnabled
            // 
            this.cbSubtitlesEnabled.AutoSize = (true);
            this.cbSubtitlesEnabled.Location = (new global::System.Drawing.Point(23, 32));
            this.cbSubtitlesEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbSubtitlesEnabled.Name = ("cbSubtitlesEnabled");
            this.cbSubtitlesEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbSubtitlesEnabled.TabIndex = (0);
            this.cbSubtitlesEnabled.Text = ("Enabled");
            this.cbSubtitlesEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage83
            // 
            this.tabPage83.Controls.Add(this.label8);
            this.tabPage83.Controls.Add(this.tbGPUBlur);
            this.tabPage83.Controls.Add(this.cbVideoEffectsGPUEnabled);
            this.tabPage83.Controls.Add(this.cbGPUOldMovie);
            this.tabPage83.Controls.Add(this.cbGPUDeinterlace);
            this.tabPage83.Controls.Add(this.cbGPUDenoise);
            this.tabPage83.Controls.Add(this.cbGPUPixelate);
            this.tabPage83.Controls.Add(this.cbGPUNightVision);
            this.tabPage83.Controls.Add(this.label383);
            this.tabPage83.Controls.Add(this.label384);
            this.tabPage83.Controls.Add(this.label385);
            this.tabPage83.Controls.Add(this.label386);
            this.tabPage83.Controls.Add(this.tbGPUContrast);
            this.tabPage83.Controls.Add(this.tbGPUDarkness);
            this.tabPage83.Controls.Add(this.tbGPULightness);
            this.tabPage83.Controls.Add(this.tbGPUSaturation);
            this.tabPage83.Controls.Add(this.cbGPUInvert);
            this.tabPage83.Controls.Add(this.cbGPUGreyscale);
            this.tabPage83.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage83.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage83.Name = ("tabPage83");
            this.tabPage83.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage83.Size = (new global::System.Drawing.Size(489, 894));
            this.tabPage83.TabIndex = (8);
            this.tabPage83.Text = ("GPU effects");
            this.tabPage83.UseVisualStyleBackColor = (true);
            // 
            // label8
            // 
            this.label8.AutoSize = (true);
            this.label8.Location = (new global::System.Drawing.Point(20, 519));
            this.label8.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label8.Name = ("label8");
            this.label8.Size = (new global::System.Drawing.Size(42, 25));
            this.label8.TabIndex = (100);
            this.label8.Text = ("Blur");
            // 
            // tbGPUBlur
            // 
            this.tbGPUBlur.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUBlur.Location = (new global::System.Drawing.Point(16, 550));
            this.tbGPUBlur.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUBlur.Maximum = (30);
            this.tbGPUBlur.Name = ("tbGPUBlur");
            this.tbGPUBlur.Size = (new global::System.Drawing.Size(217, 69));
            this.tbGPUBlur.TabIndex = (99);
            this.tbGPUBlur.Scroll += (this.tbGPUBlur_Scroll);
            // 
            // cbVideoEffectsGPUEnabled
            // 
            this.cbVideoEffectsGPUEnabled.AutoSize = (true);
            this.cbVideoEffectsGPUEnabled.Location = (new global::System.Drawing.Point(27, 31));
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
            this.cbGPUOldMovie.Location = (new global::System.Drawing.Point(238, 452));
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
            this.cbGPUDeinterlace.Location = (new global::System.Drawing.Point(238, 406));
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
            this.cbGPUDenoise.Location = (new global::System.Drawing.Point(24, 406));
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
            this.cbGPUPixelate.Location = (new global::System.Drawing.Point(238, 361));
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
            this.cbGPUNightVision.Location = (new global::System.Drawing.Point(24, 361));
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
            this.label383.Location = (new global::System.Drawing.Point(247, 182));
            this.label383.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label383.Name = ("label383");
            this.label383.Size = (new global::System.Drawing.Size(84, 25));
            this.label383.TabIndex = (90);
            this.label383.Text = ("Darkness");
            // 
            // label384
            // 
            this.label384.AutoSize = (true);
            this.label384.Location = (new global::System.Drawing.Point(20, 182));
            this.label384.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label384.Name = ("label384");
            this.label384.Size = (new global::System.Drawing.Size(79, 25));
            this.label384.TabIndex = (89);
            this.label384.Text = ("Contrast");
            // 
            // label385
            // 
            this.label385.AutoSize = (true);
            this.label385.Location = (new global::System.Drawing.Point(247, 82));
            this.label385.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label385.Name = ("label385");
            this.label385.Size = (new global::System.Drawing.Size(93, 25));
            this.label385.TabIndex = (88);
            this.label385.Text = ("Saturation");
            // 
            // label386
            // 
            this.label386.AutoSize = (true);
            this.label386.Location = (new global::System.Drawing.Point(20, 82));
            this.label386.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label386.Name = ("label386");
            this.label386.Size = (new global::System.Drawing.Size(86, 25));
            this.label386.TabIndex = (87);
            this.label386.Text = ("Lightness");
            // 
            // tbGPUContrast
            // 
            this.tbGPUContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUContrast.Location = (new global::System.Drawing.Point(16, 219));
            this.tbGPUContrast.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUContrast.Maximum = (255);
            this.tbGPUContrast.Name = ("tbGPUContrast");
            this.tbGPUContrast.Size = (new global::System.Drawing.Size(217, 69));
            this.tbGPUContrast.TabIndex = (86);
            this.tbGPUContrast.Value = (255);
            this.tbGPUContrast.Scroll += (this.tbGPUContrast_Scroll);
            // 
            // tbGPUDarkness
            // 
            this.tbGPUDarkness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUDarkness.Location = (new global::System.Drawing.Point(247, 219));
            this.tbGPUDarkness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUDarkness.Maximum = (255);
            this.tbGPUDarkness.Name = ("tbGPUDarkness");
            this.tbGPUDarkness.Size = (new global::System.Drawing.Size(217, 69));
            this.tbGPUDarkness.TabIndex = (85);
            this.tbGPUDarkness.Scroll += (this.tbGPUDarkness_Scroll);
            // 
            // tbGPULightness
            // 
            this.tbGPULightness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPULightness.Location = (new global::System.Drawing.Point(16, 111));
            this.tbGPULightness.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPULightness.Maximum = (255);
            this.tbGPULightness.Name = ("tbGPULightness");
            this.tbGPULightness.Size = (new global::System.Drawing.Size(217, 69));
            this.tbGPULightness.TabIndex = (84);
            this.tbGPULightness.Scroll += (this.tbGPULightness_Scroll);
            // 
            // tbGPUSaturation
            // 
            this.tbGPUSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbGPUSaturation.Location = (new global::System.Drawing.Point(247, 111));
            this.tbGPUSaturation.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbGPUSaturation.Maximum = (255);
            this.tbGPUSaturation.Name = ("tbGPUSaturation");
            this.tbGPUSaturation.Size = (new global::System.Drawing.Size(217, 69));
            this.tbGPUSaturation.TabIndex = (83);
            this.tbGPUSaturation.Value = (255);
            this.tbGPUSaturation.Scroll += (this.tbGPUSaturation_Scroll);
            // 
            // cbGPUInvert
            // 
            this.cbGPUInvert.AutoSize = (true);
            this.cbGPUInvert.BackgroundImageLayout = (global::System.Windows.Forms.ImageLayout.Center);
            this.cbGPUInvert.Location = (new global::System.Drawing.Point(238, 318));
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
            this.cbGPUGreyscale.Location = (new global::System.Drawing.Point(24, 318));
            this.cbGPUGreyscale.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbGPUGreyscale.Name = ("cbGPUGreyscale");
            this.cbGPUGreyscale.Size = (new global::System.Drawing.Size(112, 29));
            this.cbGPUGreyscale.TabIndex = (81);
            this.cbGPUGreyscale.Text = ("Greyscale");
            this.cbGPUGreyscale.UseVisualStyleBackColor = (true);
            this.cbGPUGreyscale.CheckedChanged += (this.cbGPUGreyscale_CheckedChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox5);
            this.tabPage9.Controls.Add(this.lbTransitions);
            this.tabPage9.Controls.Add(this.label43);
            this.tabPage9.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage9.Name = ("tabPage9");
            this.tabPage9.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage9.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage9.TabIndex = (3);
            this.tabPage9.Text = ("Transitions");
            this.tabPage9.UseVisualStyleBackColor = (true);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Controls.Add(this.edTransStopTime);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.edTransStartTime);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Controls.Add(this.btAddTransition);
            this.groupBox5.Controls.Add(this.cbTransitionName);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Location = (new global::System.Drawing.Point(33, 236));
            this.groupBox5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox5.Name = ("groupBox5");
            this.groupBox5.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox5.Size = (new global::System.Drawing.Size(418, 278));
            this.groupBox5.TabIndex = (2);
            this.groupBox5.TabStop = (false);
            this.groupBox5.Text = ("Add transition");
            // 
            // label47
            // 
            this.label47.AutoSize = (true);
            this.label47.Location = (new global::System.Drawing.Point(222, 211));
            this.label47.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label47.Name = ("label47");
            this.label47.Size = (new global::System.Drawing.Size(36, 25));
            this.label47.TabIndex = (8);
            this.label47.Text = ("ms");
            // 
            // edTransStopTime
            // 
            this.edTransStopTime.Location = (new global::System.Drawing.Point(140, 206));
            this.edTransStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTransStopTime.Name = ("edTransStopTime");
            this.edTransStopTime.Size = (new global::System.Drawing.Size(68, 31));
            this.edTransStopTime.TabIndex = (7);
            this.edTransStopTime.Text = ("5000");
            // 
            // label48
            // 
            this.label48.AutoSize = (true);
            this.label48.Location = (new global::System.Drawing.Point(20, 211));
            this.label48.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label48.Name = ("label48");
            this.label48.Size = (new global::System.Drawing.Size(89, 25));
            this.label48.TabIndex = (6);
            this.label48.Text = ("Stop time");
            // 
            // label46
            // 
            this.label46.AutoSize = (true);
            this.label46.Location = (new global::System.Drawing.Point(222, 161));
            this.label46.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label46.Name = ("label46");
            this.label46.Size = (new global::System.Drawing.Size(36, 25));
            this.label46.TabIndex = (5);
            this.label46.Text = ("ms");
            // 
            // edTransStartTime
            // 
            this.edTransStartTime.Location = (new global::System.Drawing.Point(140, 156));
            this.edTransStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTransStartTime.Name = ("edTransStartTime");
            this.edTransStartTime.Size = (new global::System.Drawing.Size(68, 31));
            this.edTransStartTime.TabIndex = (4);
            this.edTransStartTime.Text = ("4000");
            // 
            // label45
            // 
            this.label45.AutoSize = (true);
            this.label45.Location = (new global::System.Drawing.Point(20, 161));
            this.label45.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label45.Name = ("label45");
            this.label45.Size = (new global::System.Drawing.Size(88, 25));
            this.label45.TabIndex = (3);
            this.label45.Text = ("Start time");
            // 
            // btAddTransition
            // 
            this.btAddTransition.Location = (new global::System.Drawing.Point(338, 81));
            this.btAddTransition.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAddTransition.Name = ("btAddTransition");
            this.btAddTransition.Size = (new global::System.Drawing.Size(70, 44));
            this.btAddTransition.TabIndex = (2);
            this.btAddTransition.Text = ("Add");
            this.btAddTransition.UseVisualStyleBackColor = (true);
            this.btAddTransition.Click += (this.btAddTransition_Click);
            // 
            // cbTransitionName
            // 
            this.cbTransitionName.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTransitionName.FormattingEnabled = (true);
            this.cbTransitionName.Location = (new global::System.Drawing.Point(24, 85));
            this.cbTransitionName.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbTransitionName.Name = ("cbTransitionName");
            this.cbTransitionName.Size = (new global::System.Drawing.Size(301, 33));
            this.cbTransitionName.TabIndex = (1);
            // 
            // label44
            // 
            this.label44.AutoSize = (true);
            this.label44.Location = (new global::System.Drawing.Point(20, 54));
            this.label44.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label44.Name = ("label44");
            this.label44.Size = (new global::System.Drawing.Size(59, 25));
            this.label44.TabIndex = (0);
            this.label44.Text = ("Name");
            // 
            // lbTransitions
            // 
            this.lbTransitions.FormattingEnabled = (true);
            this.lbTransitions.ItemHeight = (25);
            this.lbTransitions.Location = (new global::System.Drawing.Point(33, 68));
            this.lbTransitions.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbTransitions.Name = ("lbTransitions");
            this.lbTransitions.Size = (new global::System.Drawing.Size(415, 154));
            this.lbTransitions.TabIndex = (1);
            // 
            // label43
            // 
            this.label43.AutoSize = (true);
            this.label43.Location = (new global::System.Drawing.Point(29, 36));
            this.label43.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label43.Name = ("label43");
            this.label43.Size = (new global::System.Drawing.Size(78, 25));
            this.label43.TabIndex = (0);
            this.label43.Text = ("Selected");
            // 
            // tabPage66
            // 
            this.tabPage66.Controls.Add(this.lbAudioTimeshift);
            this.tabPage66.Controls.Add(this.tbAudioTimeshift);
            this.tabPage66.Controls.Add(this.label115);
            this.tabPage66.Controls.Add(this.groupBox1);
            this.tabPage66.Controls.Add(this.groupBox2);
            this.tabPage66.Controls.Add(this.cbAudioAutoGain);
            this.tabPage66.Controls.Add(this.cbAudioNormalize);
            this.tabPage66.Controls.Add(this.cbAudioEnhancementEnabled);
            this.tabPage66.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage66.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage66.Name = ("tabPage66");
            this.tabPage66.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage66.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage66.TabIndex = (13);
            this.tabPage66.Text = ("Audio enhancement");
            this.tabPage66.UseVisualStyleBackColor = (true);
            // 
            // lbAudioTimeshift
            // 
            this.lbAudioTimeshift.AutoSize = (true);
            this.lbAudioTimeshift.Location = (new global::System.Drawing.Point(290, 868));
            this.lbAudioTimeshift.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioTimeshift.Name = ("lbAudioTimeshift");
            this.lbAudioTimeshift.Size = (new global::System.Drawing.Size(51, 25));
            this.lbAudioTimeshift.TabIndex = (12);
            this.lbAudioTimeshift.Text = ("0 ms");
            // 
            // tbAudioTimeshift
            // 
            this.tbAudioTimeshift.Location = (new global::System.Drawing.Point(107, 846));
            this.tbAudioTimeshift.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioTimeshift.Maximum = (3000);
            this.tbAudioTimeshift.Name = ("tbAudioTimeshift");
            this.tbAudioTimeshift.Size = (new global::System.Drawing.Size(173, 69));
            this.tbAudioTimeshift.SmallChange = (10);
            this.tbAudioTimeshift.TabIndex = (11);
            this.tbAudioTimeshift.TickFrequency = (100);
            this.tbAudioTimeshift.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            this.tbAudioTimeshift.Scroll += (this.tbAudioTimeshift_Scroll);
            // 
            // label115
            // 
            this.label115.AutoSize = (true);
            this.label115.Location = (new global::System.Drawing.Point(4, 868));
            this.label115.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label115.Name = ("label115");
            this.label115.Size = (new global::System.Drawing.Size(89, 25));
            this.label115.TabIndex = (10);
            this.label115.Text = ("Time shift");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAudioOutputGainLFE);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainLFE);
            this.groupBox1.Controls.Add(this.label116);
            this.groupBox1.Controls.Add(this.lbAudioOutputGainSR);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainSR);
            this.groupBox1.Controls.Add(this.label117);
            this.groupBox1.Controls.Add(this.lbAudioOutputGainSL);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainSL);
            this.groupBox1.Controls.Add(this.label118);
            this.groupBox1.Controls.Add(this.lbAudioOutputGainR);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainR);
            this.groupBox1.Controls.Add(this.label119);
            this.groupBox1.Controls.Add(this.lbAudioOutputGainC);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainC);
            this.groupBox1.Controls.Add(this.label121);
            this.groupBox1.Controls.Add(this.lbAudioOutputGainL);
            this.groupBox1.Controls.Add(this.tbAudioOutputGainL);
            this.groupBox1.Controls.Add(this.label122);
            this.groupBox1.Location = (new global::System.Drawing.Point(10, 500));
            this.groupBox1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox1.Name = ("groupBox1");
            this.groupBox1.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox1.Size = (new global::System.Drawing.Size(482, 331));
            this.groupBox1.TabIndex = (9);
            this.groupBox1.TabStop = (false);
            this.groupBox1.Text = ("Output gains (dB)");
            // 
            // lbAudioOutputGainLFE
            // 
            this.lbAudioOutputGainLFE.AutoSize = (true);
            this.lbAudioOutputGainLFE.Location = (new global::System.Drawing.Point(416, 285));
            this.lbAudioOutputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainLFE.Name = ("lbAudioOutputGainLFE");
            this.lbAudioOutputGainLFE.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainLFE.TabIndex = (17);
            this.lbAudioOutputGainLFE.Text = ("0.0");
            // 
            // tbAudioOutputGainLFE
            // 
            this.tbAudioOutputGainLFE.Location = (new global::System.Drawing.Point(403, 79));
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
            // label116
            // 
            this.label116.AutoSize = (true);
            this.label116.Location = (new global::System.Drawing.Point(417, 48));
            this.label116.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label116.Name = ("label116");
            this.label116.Size = (new global::System.Drawing.Size(38, 25));
            this.label116.TabIndex = (15);
            this.label116.Text = ("LFE");
            // 
            // lbAudioOutputGainSR
            // 
            this.lbAudioOutputGainSR.AutoSize = (true);
            this.lbAudioOutputGainSR.Location = (new global::System.Drawing.Point(336, 285));
            this.lbAudioOutputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainSR.Name = ("lbAudioOutputGainSR");
            this.lbAudioOutputGainSR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainSR.TabIndex = (14);
            this.lbAudioOutputGainSR.Text = ("0.0");
            // 
            // tbAudioOutputGainSR
            // 
            this.tbAudioOutputGainSR.Location = (new global::System.Drawing.Point(323, 79));
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
            // label117
            // 
            this.label117.AutoSize = (true);
            this.label117.Location = (new global::System.Drawing.Point(342, 48));
            this.label117.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label117.Name = ("label117");
            this.label117.Size = (new global::System.Drawing.Size(33, 25));
            this.label117.TabIndex = (12);
            this.label117.Text = ("SR");
            // 
            // lbAudioOutputGainSL
            // 
            this.lbAudioOutputGainSL.AutoSize = (true);
            this.lbAudioOutputGainSL.Location = (new global::System.Drawing.Point(256, 285));
            this.lbAudioOutputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainSL.Name = ("lbAudioOutputGainSL");
            this.lbAudioOutputGainSL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainSL.TabIndex = (11);
            this.lbAudioOutputGainSL.Text = ("0.0");
            // 
            // tbAudioOutputGainSL
            // 
            this.tbAudioOutputGainSL.Location = (new global::System.Drawing.Point(243, 79));
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
            // label118
            // 
            this.label118.AutoSize = (true);
            this.label118.Location = (new global::System.Drawing.Point(263, 48));
            this.label118.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label118.Name = ("label118");
            this.label118.Size = (new global::System.Drawing.Size(30, 25));
            this.label118.TabIndex = (9);
            this.label118.Text = ("SL");
            // 
            // lbAudioOutputGainR
            // 
            this.lbAudioOutputGainR.AutoSize = (true);
            this.lbAudioOutputGainR.Location = (new global::System.Drawing.Point(176, 285));
            this.lbAudioOutputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainR.Name = ("lbAudioOutputGainR");
            this.lbAudioOutputGainR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainR.TabIndex = (8);
            this.lbAudioOutputGainR.Text = ("0.0");
            // 
            // tbAudioOutputGainR
            // 
            this.tbAudioOutputGainR.Location = (new global::System.Drawing.Point(163, 79));
            this.tbAudioOutputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioOutputGainR.Maximum = (200);
            this.tbAudioOutputGainR.Minimum = (-200);
            this.tbAudioOutputGainR.Name = ("tbAudioOutputGainR");
            this.tbAudioOutputGainR.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudioOutputGainR.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudioOutputGainR.TabIndex = (7);
            this.tbAudioOutputGainR.TickStyle = (global::System.Windows.Forms.TickStyle.Both);
            // 
            // label119
            // 
            this.label119.AutoSize = (true);
            this.label119.Location = (new global::System.Drawing.Point(190, 48));
            this.label119.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label119.Name = ("label119");
            this.label119.Size = (new global::System.Drawing.Size(23, 25));
            this.label119.TabIndex = (6);
            this.label119.Text = ("R");
            // 
            // lbAudioOutputGainC
            // 
            this.lbAudioOutputGainC.AutoSize = (true);
            this.lbAudioOutputGainC.Location = (new global::System.Drawing.Point(96, 285));
            this.lbAudioOutputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainC.Name = ("lbAudioOutputGainC");
            this.lbAudioOutputGainC.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainC.TabIndex = (5);
            this.lbAudioOutputGainC.Text = ("0.0");
            // 
            // tbAudioOutputGainC
            // 
            this.tbAudioOutputGainC.Location = (new global::System.Drawing.Point(83, 79));
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
            // label121
            // 
            this.label121.AutoSize = (true);
            this.label121.Location = (new global::System.Drawing.Point(110, 48));
            this.label121.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label121.Name = ("label121");
            this.label121.Size = (new global::System.Drawing.Size(23, 25));
            this.label121.TabIndex = (3);
            this.label121.Text = ("C");
            // 
            // lbAudioOutputGainL
            // 
            this.lbAudioOutputGainL.AutoSize = (true);
            this.lbAudioOutputGainL.Location = (new global::System.Drawing.Point(16, 285));
            this.lbAudioOutputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioOutputGainL.Name = ("lbAudioOutputGainL");
            this.lbAudioOutputGainL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioOutputGainL.TabIndex = (2);
            this.lbAudioOutputGainL.Text = ("0.0");
            // 
            // tbAudioOutputGainL
            // 
            this.tbAudioOutputGainL.Location = (new global::System.Drawing.Point(3, 79));
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
            // label122
            // 
            this.label122.AutoSize = (true);
            this.label122.Location = (new global::System.Drawing.Point(30, 48));
            this.label122.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label122.Name = ("label122");
            this.label122.Size = (new global::System.Drawing.Size(20, 25));
            this.label122.TabIndex = (0);
            this.label122.Text = ("L");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbAudioInputGainLFE);
            this.groupBox2.Controls.Add(this.tbAudioInputGainLFE);
            this.groupBox2.Controls.Add(this.label123);
            this.groupBox2.Controls.Add(this.lbAudioInputGainSR);
            this.groupBox2.Controls.Add(this.tbAudioInputGainSR);
            this.groupBox2.Controls.Add(this.label124);
            this.groupBox2.Controls.Add(this.lbAudioInputGainSL);
            this.groupBox2.Controls.Add(this.tbAudioInputGainSL);
            this.groupBox2.Controls.Add(this.label125);
            this.groupBox2.Controls.Add(this.lbAudioInputGainR);
            this.groupBox2.Controls.Add(this.tbAudioInputGainR);
            this.groupBox2.Controls.Add(this.label126);
            this.groupBox2.Controls.Add(this.lbAudioInputGainC);
            this.groupBox2.Controls.Add(this.tbAudioInputGainC);
            this.groupBox2.Controls.Add(this.label127);
            this.groupBox2.Controls.Add(this.lbAudioInputGainL);
            this.groupBox2.Controls.Add(this.tbAudioInputGainL);
            this.groupBox2.Controls.Add(this.label128);
            this.groupBox2.Location = (new global::System.Drawing.Point(10, 158));
            this.groupBox2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox2.Name = ("groupBox2");
            this.groupBox2.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox2.Size = (new global::System.Drawing.Size(482, 331));
            this.groupBox2.TabIndex = (8);
            this.groupBox2.TabStop = (false);
            this.groupBox2.Text = ("Input gains (dB)");
            // 
            // lbAudioInputGainLFE
            // 
            this.lbAudioInputGainLFE.AutoSize = (true);
            this.lbAudioInputGainLFE.Location = (new global::System.Drawing.Point(416, 285));
            this.lbAudioInputGainLFE.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainLFE.Name = ("lbAudioInputGainLFE");
            this.lbAudioInputGainLFE.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainLFE.TabIndex = (17);
            this.lbAudioInputGainLFE.Text = ("0.0");
            // 
            // tbAudioInputGainLFE
            // 
            this.tbAudioInputGainLFE.Location = (new global::System.Drawing.Point(403, 79));
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
            // label123
            // 
            this.label123.AutoSize = (true);
            this.label123.Location = (new global::System.Drawing.Point(417, 48));
            this.label123.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label123.Name = ("label123");
            this.label123.Size = (new global::System.Drawing.Size(38, 25));
            this.label123.TabIndex = (15);
            this.label123.Text = ("LFE");
            // 
            // lbAudioInputGainSR
            // 
            this.lbAudioInputGainSR.AutoSize = (true);
            this.lbAudioInputGainSR.Location = (new global::System.Drawing.Point(336, 285));
            this.lbAudioInputGainSR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainSR.Name = ("lbAudioInputGainSR");
            this.lbAudioInputGainSR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainSR.TabIndex = (14);
            this.lbAudioInputGainSR.Text = ("0.0");
            // 
            // tbAudioInputGainSR
            // 
            this.tbAudioInputGainSR.Location = (new global::System.Drawing.Point(323, 79));
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
            // label124
            // 
            this.label124.AutoSize = (true);
            this.label124.Location = (new global::System.Drawing.Point(342, 48));
            this.label124.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label124.Name = ("label124");
            this.label124.Size = (new global::System.Drawing.Size(33, 25));
            this.label124.TabIndex = (12);
            this.label124.Text = ("SR");
            // 
            // lbAudioInputGainSL
            // 
            this.lbAudioInputGainSL.AutoSize = (true);
            this.lbAudioInputGainSL.Location = (new global::System.Drawing.Point(256, 285));
            this.lbAudioInputGainSL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainSL.Name = ("lbAudioInputGainSL");
            this.lbAudioInputGainSL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainSL.TabIndex = (11);
            this.lbAudioInputGainSL.Text = ("0.0");
            // 
            // tbAudioInputGainSL
            // 
            this.tbAudioInputGainSL.Location = (new global::System.Drawing.Point(243, 79));
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
            // label125
            // 
            this.label125.AutoSize = (true);
            this.label125.Location = (new global::System.Drawing.Point(263, 48));
            this.label125.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label125.Name = ("label125");
            this.label125.Size = (new global::System.Drawing.Size(30, 25));
            this.label125.TabIndex = (9);
            this.label125.Text = ("SL");
            // 
            // lbAudioInputGainR
            // 
            this.lbAudioInputGainR.AutoSize = (true);
            this.lbAudioInputGainR.Location = (new global::System.Drawing.Point(176, 285));
            this.lbAudioInputGainR.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainR.Name = ("lbAudioInputGainR");
            this.lbAudioInputGainR.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainR.TabIndex = (8);
            this.lbAudioInputGainR.Text = ("0.0");
            // 
            // tbAudioInputGainR
            // 
            this.tbAudioInputGainR.Location = (new global::System.Drawing.Point(163, 79));
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
            // label126
            // 
            this.label126.AutoSize = (true);
            this.label126.Location = (new global::System.Drawing.Point(190, 48));
            this.label126.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label126.Name = ("label126");
            this.label126.Size = (new global::System.Drawing.Size(23, 25));
            this.label126.TabIndex = (6);
            this.label126.Text = ("R");
            // 
            // lbAudioInputGainC
            // 
            this.lbAudioInputGainC.AutoSize = (true);
            this.lbAudioInputGainC.Location = (new global::System.Drawing.Point(96, 285));
            this.lbAudioInputGainC.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainC.Name = ("lbAudioInputGainC");
            this.lbAudioInputGainC.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainC.TabIndex = (5);
            this.lbAudioInputGainC.Text = ("0.0");
            // 
            // tbAudioInputGainC
            // 
            this.tbAudioInputGainC.Location = (new global::System.Drawing.Point(83, 79));
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
            // label127
            // 
            this.label127.AutoSize = (true);
            this.label127.Location = (new global::System.Drawing.Point(110, 48));
            this.label127.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label127.Name = ("label127");
            this.label127.Size = (new global::System.Drawing.Size(23, 25));
            this.label127.TabIndex = (3);
            this.label127.Text = ("C");
            // 
            // lbAudioInputGainL
            // 
            this.lbAudioInputGainL.AutoSize = (true);
            this.lbAudioInputGainL.Location = (new global::System.Drawing.Point(16, 285));
            this.lbAudioInputGainL.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbAudioInputGainL.Name = ("lbAudioInputGainL");
            this.lbAudioInputGainL.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudioInputGainL.TabIndex = (2);
            this.lbAudioInputGainL.Text = ("0.0");
            // 
            // tbAudioInputGainL
            // 
            this.tbAudioInputGainL.Location = (new global::System.Drawing.Point(3, 79));
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
            // label128
            // 
            this.label128.AutoSize = (true);
            this.label128.Location = (new global::System.Drawing.Point(30, 48));
            this.label128.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label128.Name = ("label128");
            this.label128.Size = (new global::System.Drawing.Size(20, 25));
            this.label128.TabIndex = (0);
            this.label128.Text = ("L");
            // 
            // cbAudioAutoGain
            // 
            this.cbAudioAutoGain.AutoSize = (true);
            this.cbAudioAutoGain.Location = (new global::System.Drawing.Point(222, 92));
            this.cbAudioAutoGain.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioAutoGain.Name = ("cbAudioAutoGain");
            this.cbAudioAutoGain.Size = (new global::System.Drawing.Size(116, 29));
            this.cbAudioAutoGain.TabIndex = (5);
            this.cbAudioAutoGain.Text = ("Auto gain");
            this.cbAudioAutoGain.UseVisualStyleBackColor = (true);
            this.cbAudioAutoGain.CheckedChanged += (this.cbAudioAutoGain_CheckedChanged);
            // 
            // cbAudioNormalize
            // 
            this.cbAudioNormalize.AutoSize = (true);
            this.cbAudioNormalize.Location = (new global::System.Drawing.Point(64, 92));
            this.cbAudioNormalize.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioNormalize.Name = ("cbAudioNormalize");
            this.cbAudioNormalize.Size = (new global::System.Drawing.Size(118, 29));
            this.cbAudioNormalize.TabIndex = (4);
            this.cbAudioNormalize.Text = ("Normalize");
            this.cbAudioNormalize.UseVisualStyleBackColor = (true);
            this.cbAudioNormalize.CheckedChanged += (this.cbAudioNormalize_CheckedChanged);
            // 
            // cbAudioEnhancementEnabled
            // 
            this.cbAudioEnhancementEnabled.AutoSize = (true);
            this.cbAudioEnhancementEnabled.Location = (new global::System.Drawing.Point(27, 31));
            this.cbAudioEnhancementEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioEnhancementEnabled.Name = ("cbAudioEnhancementEnabled");
            this.cbAudioEnhancementEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioEnhancementEnabled.TabIndex = (3);
            this.cbAudioEnhancementEnabled.Text = ("Enabled");
            this.cbAudioEnhancementEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label133);
            this.tabPage3.Controls.Add(this.tabControl18);
            this.tabPage3.Controls.Add(this.cbAudioEffectsEnabled);
            this.tabPage3.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage3.Name = ("tabPage3");
            this.tabPage3.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage3.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage3.TabIndex = (5);
            this.tabPage3.Text = ("Audio effects");
            this.tabPage3.UseVisualStyleBackColor = (true);
            // 
            // label133
            // 
            this.label133.AutoSize = (true);
            this.label133.Location = (new global::System.Drawing.Point(169, 31));
            this.label133.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label133.Name = ("label133");
            this.label133.Size = (new global::System.Drawing.Size(313, 25));
            this.label133.TabIndex = (4);
            this.label133.Text = ("Much more effects available using API");
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage73);
            this.tabControl18.Controls.Add(this.tabPage75);
            this.tabControl18.Controls.Add(this.tabPage76);
            this.tabControl18.Controls.Add(this.tabPage16);
            this.tabControl18.Location = (new global::System.Drawing.Point(17, 72));
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
            this.label230.Location = (new global::System.Drawing.Point(113, 102));
            this.label230.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label230.Name = ("label230");
            this.label230.Size = (new global::System.Drawing.Size(57, 25));
            this.label230.TabIndex = (4);
            this.label230.Text = ("100%");
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudAmplifyAmp.Location = (new global::System.Drawing.Point(27, 132));
            this.tbAudAmplifyAmp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudAmplifyAmp.Maximum = (4000);
            this.tbAudAmplifyAmp.Name = ("tbAudAmplifyAmp");
            this.tbAudAmplifyAmp.Size = (new global::System.Drawing.Size(383, 69));
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
            this.cbAudAmplifyEnabled.Location = (new global::System.Drawing.Point(27, 31));
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
            this.btAudEqRefresh.Location = (new global::System.Drawing.Point(291, 421));
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
            this.cbAudEqualizerPreset.Location = (new global::System.Drawing.Point(102, 346));
            this.cbAudEqualizerPreset.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudEqualizerPreset.Name = ("cbAudEqualizerPreset");
            this.cbAudEqualizerPreset.Size = (new global::System.Drawing.Size(313, 33));
            this.cbAudEqualizerPreset.TabIndex = (25);
            this.cbAudEqualizerPreset.SelectedIndexChanged += (this.cbAudEqualizerPreset_SelectedIndexChanged);
            // 
            // label243
            // 
            this.label243.AutoSize = (true);
            this.label243.Location = (new global::System.Drawing.Point(23, 352));
            this.label243.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label243.Name = ("label243");
            this.label243.Size = (new global::System.Drawing.Size(60, 25));
            this.label243.TabIndex = (24);
            this.label243.Text = ("Preset");
            // 
            // label242
            // 
            this.label242.AutoSize = (true);
            this.label242.Location = (new global::System.Drawing.Point(343, 300));
            this.label242.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label242.Name = ("label242");
            this.label242.Size = (new global::System.Drawing.Size(42, 25));
            this.label242.TabIndex = (23);
            this.label242.Text = ("16K");
            // 
            // label241
            // 
            this.label241.AutoSize = (true);
            this.label241.Location = (new global::System.Drawing.Point(307, 300));
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
            this.label236.Location = (new global::System.Drawing.Point(133, 300));
            this.label236.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label236.Name = ("label236");
            this.label236.Size = (new global::System.Drawing.Size(42, 25));
            this.label236.TabIndex = (17);
            this.label236.Text = ("600");
            // 
            // label235
            // 
            this.label235.AutoSize = (true);
            this.label235.Location = (new global::System.Drawing.Point(97, 300));
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
            this.label232.Location = (new global::System.Drawing.Point(197, 64));
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
            this.tbAudEq8.Location = (new global::System.Drawing.Point(307, 94));
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
            this.tbAudEq4.Location = (new global::System.Drawing.Point(167, 94));
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
            this.tbAudEq2.Location = (new global::System.Drawing.Point(97, 94));
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
            this.cbAudEqualizerEnabled.Location = (new global::System.Drawing.Point(27, 31));
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
            this.tbAudRelease.Location = (new global::System.Drawing.Point(27, 402));
            this.tbAudRelease.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudRelease.Maximum = (10000);
            this.tbAudRelease.Minimum = (10);
            this.tbAudRelease.Name = ("tbAudRelease");
            this.tbAudRelease.Size = (new global::System.Drawing.Size(383, 69));
            this.tbAudRelease.TabIndex = (15);
            this.tbAudRelease.TickFrequency = (250);
            this.tbAudRelease.Value = (10);
            this.tbAudRelease.Scroll += (this.tbAudRelease_Scroll);
            // 
            // label248
            // 
            this.label248.AutoSize = (true);
            this.label248.Location = (new global::System.Drawing.Point(389, 371));
            this.label248.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label248.Name = ("label248");
            this.label248.Size = (new global::System.Drawing.Size(22, 25));
            this.label248.TabIndex = (14);
            this.label248.Text = ("0");
            // 
            // label249
            // 
            this.label249.AutoSize = (true);
            this.label249.Location = (new global::System.Drawing.Point(22, 371));
            this.label249.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label249.Name = ("label249");
            this.label249.Size = (new global::System.Drawing.Size(110, 25));
            this.label249.TabIndex = (12);
            this.label249.Text = ("Release time");
            // 
            // label246
            // 
            this.label246.AutoSize = (true);
            this.label246.Location = (new global::System.Drawing.Point(389, 232));
            this.label246.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label246.Name = ("label246");
            this.label246.Size = (new global::System.Drawing.Size(22, 25));
            this.label246.TabIndex = (11);
            this.label246.Text = ("0");
            // 
            // tbAudAttack
            // 
            this.tbAudAttack.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudAttack.Location = (new global::System.Drawing.Point(27, 264));
            this.tbAudAttack.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudAttack.Maximum = (10000);
            this.tbAudAttack.Minimum = (10);
            this.tbAudAttack.Name = ("tbAudAttack");
            this.tbAudAttack.Size = (new global::System.Drawing.Size(383, 69));
            this.tbAudAttack.TabIndex = (10);
            this.tbAudAttack.TickFrequency = (250);
            this.tbAudAttack.Value = (10);
            this.tbAudAttack.Scroll += (this.tbAudAttack_Scroll);
            // 
            // label247
            // 
            this.label247.AutoSize = (true);
            this.label247.Location = (new global::System.Drawing.Point(22, 232));
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
            this.label244.Size = (new global::System.Drawing.Size(22, 25));
            this.label244.TabIndex = (8);
            this.label244.Text = ("0");
            // 
            // tbAudDynAmp
            // 
            this.tbAudDynAmp.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudDynAmp.Location = (new global::System.Drawing.Point(27, 132));
            this.tbAudDynAmp.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudDynAmp.Maximum = (2000);
            this.tbAudDynAmp.Minimum = (100);
            this.tbAudDynAmp.Name = ("tbAudDynAmp");
            this.tbAudDynAmp.Size = (new global::System.Drawing.Size(383, 69));
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
            this.cbAudDynamicAmplifyEnabled.Location = (new global::System.Drawing.Point(27, 31));
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
            this.tbAud3DSound.Location = (new global::System.Drawing.Point(27, 132));
            this.tbAud3DSound.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAud3DSound.Maximum = (10000);
            this.tbAud3DSound.Name = ("tbAud3DSound");
            this.tbAud3DSound.Size = (new global::System.Drawing.Size(383, 69));
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
            this.cbAudSound3DEnabled.Location = (new global::System.Drawing.Point(27, 31));
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
            this.tbAudTrueBass.Location = (new global::System.Drawing.Point(27, 132));
            this.tbAudTrueBass.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudTrueBass.Maximum = (10000);
            this.tbAudTrueBass.Name = ("tbAudTrueBass");
            this.tbAudTrueBass.Size = (new global::System.Drawing.Size(383, 69));
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
            this.cbAudTrueBassEnabled.Location = (new global::System.Drawing.Point(27, 31));
            this.cbAudTrueBassEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudTrueBassEnabled.Name = ("cbAudTrueBassEnabled");
            this.cbAudTrueBassEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudTrueBassEnabled.TabIndex = (2);
            this.cbAudTrueBassEnabled.Text = ("Enabled");
            this.cbAudTrueBassEnabled.UseVisualStyleBackColor = (true);
            this.cbAudTrueBassEnabled.CheckedChanged += (this.cbAudTrueBassEnabled_CheckedChanged);
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.cbFadeOutEnabled);
            this.tabPage16.Controls.Add(this.label4);
            this.tabPage16.Controls.Add(this.edFadeOutStopTime);
            this.tabPage16.Controls.Add(this.label5);
            this.tabPage16.Controls.Add(this.label6);
            this.tabPage16.Controls.Add(this.edFadeOutStartTime);
            this.tabPage16.Controls.Add(this.label7);
            this.tabPage16.Controls.Add(this.cbFadeInEnabled);
            this.tabPage16.Controls.Add(this.label19);
            this.tabPage16.Controls.Add(this.edFadeInStopTime);
            this.tabPage16.Controls.Add(this.label20);
            this.tabPage16.Controls.Add(this.label18);
            this.tabPage16.Controls.Add(this.edFadeInStartTime);
            this.tabPage16.Controls.Add(this.label17);
            this.tabPage16.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage16.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage16.Name = ("tabPage16");
            this.tabPage16.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage16.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage16.TabIndex = (6);
            this.tabPage16.Text = ("Fade-In/Fade-Out");
            this.tabPage16.UseVisualStyleBackColor = (true);
            // 
            // cbFadeOutEnabled
            // 
            this.cbFadeOutEnabled.AutoSize = (true);
            this.cbFadeOutEnabled.Location = (new global::System.Drawing.Point(27, 215));
            this.cbFadeOutEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFadeOutEnabled.Name = ("cbFadeOutEnabled");
            this.cbFadeOutEnabled.Size = (new global::System.Drawing.Size(109, 29));
            this.cbFadeOutEnabled.TabIndex = (13);
            this.cbFadeOutEnabled.Text = ("Fade-out");
            this.cbFadeOutEnabled.UseVisualStyleBackColor = (true);
            this.cbFadeOutEnabled.CheckedChanged += (this.cbFadeOutEnabled_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = (true);
            this.label4.Location = (new global::System.Drawing.Point(240, 321));
            this.label4.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label4.Name = ("label4");
            this.label4.Size = (new global::System.Drawing.Size(36, 25));
            this.label4.TabIndex = (12);
            this.label4.Text = ("ms");
            // 
            // edFadeOutStopTime
            // 
            this.edFadeOutStopTime.Location = (new global::System.Drawing.Point(150, 315));
            this.edFadeOutStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeOutStopTime.Name = ("edFadeOutStopTime");
            this.edFadeOutStopTime.Size = (new global::System.Drawing.Size(77, 31));
            this.edFadeOutStopTime.TabIndex = (11);
            this.edFadeOutStopTime.Text = ("5000");
            // 
            // label5
            // 
            this.label5.AutoSize = (true);
            this.label5.Location = (new global::System.Drawing.Point(42, 321));
            this.label5.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label5.Name = ("label5");
            this.label5.Size = (new global::System.Drawing.Size(89, 25));
            this.label5.TabIndex = (10);
            this.label5.Text = ("Stop time");
            // 
            // label6
            // 
            this.label6.AutoSize = (true);
            this.label6.Location = (new global::System.Drawing.Point(240, 271));
            this.label6.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label6.Name = ("label6");
            this.label6.Size = (new global::System.Drawing.Size(36, 25));
            this.label6.TabIndex = (9);
            this.label6.Text = ("ms");
            // 
            // edFadeOutStartTime
            // 
            this.edFadeOutStartTime.Location = (new global::System.Drawing.Point(150, 265));
            this.edFadeOutStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeOutStartTime.Name = ("edFadeOutStartTime");
            this.edFadeOutStartTime.Size = (new global::System.Drawing.Size(77, 31));
            this.edFadeOutStartTime.TabIndex = (8);
            this.edFadeOutStartTime.Text = ("0");
            // 
            // label7
            // 
            this.label7.AutoSize = (true);
            this.label7.Location = (new global::System.Drawing.Point(42, 271));
            this.label7.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label7.Name = ("label7");
            this.label7.Size = (new global::System.Drawing.Size(88, 25));
            this.label7.TabIndex = (7);
            this.label7.Text = ("Start time");
            // 
            // cbFadeInEnabled
            // 
            this.cbFadeInEnabled.AutoSize = (true);
            this.cbFadeInEnabled.Location = (new global::System.Drawing.Point(27, 31));
            this.cbFadeInEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbFadeInEnabled.Name = ("cbFadeInEnabled");
            this.cbFadeInEnabled.Size = (new global::System.Drawing.Size(96, 29));
            this.cbFadeInEnabled.TabIndex = (6);
            this.cbFadeInEnabled.Text = ("Fade-in");
            this.cbFadeInEnabled.UseVisualStyleBackColor = (true);
            this.cbFadeInEnabled.CheckedChanged += (this.cbFadeInEnabled_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = (true);
            this.label19.Location = (new global::System.Drawing.Point(240, 136));
            this.label19.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label19.Name = ("label19");
            this.label19.Size = (new global::System.Drawing.Size(36, 25));
            this.label19.TabIndex = (5);
            this.label19.Text = ("ms");
            // 
            // edFadeInStopTime
            // 
            this.edFadeInStopTime.Location = (new global::System.Drawing.Point(150, 131));
            this.edFadeInStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeInStopTime.Name = ("edFadeInStopTime");
            this.edFadeInStopTime.Size = (new global::System.Drawing.Size(77, 31));
            this.edFadeInStopTime.TabIndex = (4);
            this.edFadeInStopTime.Text = ("5000");
            // 
            // label20
            // 
            this.label20.AutoSize = (true);
            this.label20.Location = (new global::System.Drawing.Point(42, 136));
            this.label20.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label20.Name = ("label20");
            this.label20.Size = (new global::System.Drawing.Size(89, 25));
            this.label20.TabIndex = (3);
            this.label20.Text = ("Stop time");
            // 
            // label18
            // 
            this.label18.AutoSize = (true);
            this.label18.Location = (new global::System.Drawing.Point(240, 86));
            this.label18.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label18.Name = ("label18");
            this.label18.Size = (new global::System.Drawing.Size(36, 25));
            this.label18.TabIndex = (2);
            this.label18.Text = ("ms");
            // 
            // edFadeInStartTime
            // 
            this.edFadeInStartTime.Location = (new global::System.Drawing.Point(150, 81));
            this.edFadeInStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edFadeInStartTime.Name = ("edFadeInStartTime");
            this.edFadeInStartTime.Size = (new global::System.Drawing.Size(77, 31));
            this.edFadeInStartTime.TabIndex = (1);
            this.edFadeInStartTime.Text = ("0");
            // 
            // label17
            // 
            this.label17.AutoSize = (true);
            this.label17.Location = (new global::System.Drawing.Point(42, 86));
            this.label17.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label17.Name = ("label17");
            this.label17.Size = (new global::System.Drawing.Size(88, 25));
            this.label17.TabIndex = (0);
            this.label17.Text = ("Start time");
            // 
            // cbAudioEffectsEnabled
            // 
            this.cbAudioEffectsEnabled.AutoSize = (true);
            this.cbAudioEffectsEnabled.Location = (new global::System.Drawing.Point(17, 29));
            this.cbAudioEffectsEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioEffectsEnabled.Name = ("cbAudioEffectsEnabled");
            this.cbAudioEffectsEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioEffectsEnabled.TabIndex = (2);
            this.cbAudioEffectsEnabled.Text = ("Enabled");
            this.cbAudioEffectsEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage81
            // 
            this.tabPage81.Controls.Add(this.btAudioChannelMapperClear);
            this.tabPage81.Controls.Add(this.groupBox41);
            this.tabPage81.Controls.Add(this.label307);
            this.tabPage81.Controls.Add(this.edAudioChannelMapperOutputChannels);
            this.tabPage81.Controls.Add(this.label306);
            this.tabPage81.Controls.Add(this.lbAudioChannelMapperRoutes);
            this.tabPage81.Controls.Add(this.cbAudioChannelMapperEnabled);
            this.tabPage81.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage81.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage81.Name = ("tabPage81");
            this.tabPage81.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage81.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage81.TabIndex = (15);
            this.tabPage81.Text = ("Audio channel mapper");
            this.tabPage81.UseVisualStyleBackColor = (true);
            // 
            // btAudioChannelMapperClear
            // 
            this.btAudioChannelMapperClear.Location = (new global::System.Drawing.Point(344, 432));
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
            this.groupBox41.Location = (new global::System.Drawing.Point(7, 489));
            this.groupBox41.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox41.Name = ("groupBox41");
            this.groupBox41.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox41.Size = (new global::System.Drawing.Size(487, 329));
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
            this.label311.Location = (new global::System.Drawing.Point(342, 171));
            this.label311.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label311.Name = ("label311");
            this.label311.Size = (new global::System.Drawing.Size(109, 25));
            this.label311.TabIndex = (19);
            this.label311.Text = ("10% - 200%");
            // 
            // tbAudioChannelMapperVolume
            // 
            this.tbAudioChannelMapperVolume.Location = (new global::System.Drawing.Point(347, 79));
            this.tbAudioChannelMapperVolume.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbAudioChannelMapperVolume.Maximum = (2000);
            this.tbAudioChannelMapperVolume.Minimum = (100);
            this.tbAudioChannelMapperVolume.Name = ("tbAudioChannelMapperVolume");
            this.tbAudioChannelMapperVolume.Size = (new global::System.Drawing.Size(123, 69));
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
            this.edAudioChannelMapperTargetChannel.Location = (new global::System.Drawing.Point(180, 79));
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
            this.edAudioChannelMapperSourceChannel.Location = (new global::System.Drawing.Point(24, 79));
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
            this.label307.Location = (new global::System.Drawing.Point(20, 204));
            this.label307.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label307.Name = ("label307");
            this.label307.Size = (new global::System.Drawing.Size(66, 25));
            this.label307.TabIndex = (19);
            this.label307.Text = ("Routes");
            // 
            // edAudioChannelMapperOutputChannels
            // 
            this.edAudioChannelMapperOutputChannels.Location = (new global::System.Drawing.Point(24, 129));
            this.edAudioChannelMapperOutputChannels.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edAudioChannelMapperOutputChannels.Name = ("edAudioChannelMapperOutputChannels");
            this.edAudioChannelMapperOutputChannels.Size = (new global::System.Drawing.Size(67, 31));
            this.edAudioChannelMapperOutputChannels.TabIndex = (18);
            this.edAudioChannelMapperOutputChannels.Text = ("0");
            // 
            // label306
            // 
            this.label306.AutoSize = (true);
            this.label306.Location = (new global::System.Drawing.Point(20, 98));
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
            this.lbAudioChannelMapperRoutes.Location = (new global::System.Drawing.Point(24, 239));
            this.lbAudioChannelMapperRoutes.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbAudioChannelMapperRoutes.Name = ("lbAudioChannelMapperRoutes");
            this.lbAudioChannelMapperRoutes.Size = (new global::System.Drawing.Size(442, 179));
            this.lbAudioChannelMapperRoutes.TabIndex = (16);
            // 
            // cbAudioChannelMapperEnabled
            // 
            this.cbAudioChannelMapperEnabled.AutoSize = (true);
            this.cbAudioChannelMapperEnabled.Location = (new global::System.Drawing.Point(24, 32));
            this.cbAudioChannelMapperEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAudioChannelMapperEnabled.Name = ("cbAudioChannelMapperEnabled");
            this.cbAudioChannelMapperEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudioChannelMapperEnabled.TabIndex = (15);
            this.cbAudioChannelMapperEnabled.Text = ("Enabled");
            this.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.tabControl9);
            this.tabPage27.Controls.Add(this.cbMotDetEnabled);
            this.tabPage27.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage27.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage27.Name = ("tabPage27");
            this.tabPage27.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage27.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage27.TabIndex = (7);
            this.tabPage27.Text = ("Motion detection");
            this.tabPage27.UseVisualStyleBackColor = (true);
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.tabPage44);
            this.tabControl9.Controls.Add(this.tabPage45);
            this.tabControl9.Location = (new global::System.Drawing.Point(23, 82));
            this.tabControl9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl9.Name = ("tabControl9");
            this.tabControl9.SelectedIndex = (0);
            this.tabControl9.Size = (new global::System.Drawing.Size(447, 794));
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
            this.tabPage44.Size = (new global::System.Drawing.Size(439, 756));
            this.tabPage44.TabIndex = (0);
            this.tabPage44.Text = ("Output matrix");
            this.tabPage44.UseVisualStyleBackColor = (true);
            // 
            // pbMotionLevel
            // 
            this.pbMotionLevel.Location = (new global::System.Drawing.Point(31, 611));
            this.pbMotionLevel.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pbMotionLevel.Name = ("pbMotionLevel");
            this.pbMotionLevel.Size = (new global::System.Drawing.Size(376, 36));
            this.pbMotionLevel.TabIndex = (2);
            // 
            // label158
            // 
            this.label158.AutoSize = (true);
            this.label158.Location = (new global::System.Drawing.Point(27, 572));
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
            this.mmMotDetMatrix.Size = (new global::System.Drawing.Size(411, 475));
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
            this.tabPage45.Size = (new global::System.Drawing.Size(439, 756));
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
            this.groupBox25.Size = (new global::System.Drawing.Size(389, 165));
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
            this.label161.Location = (new global::System.Drawing.Point(247, 81));
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
            this.cbMotDetHLEnabled.Location = (new global::System.Drawing.Point(23, 42));
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
            this.tbMotDetHLThreshold.Size = (new global::System.Drawing.Size(173, 69));
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
            this.edMotDetMatrixHeight.Size = (new global::System.Drawing.Size(57, 31));
            this.edMotDetMatrixHeight.TabIndex = (75);
            this.edMotDetMatrixHeight.Text = ("10");
            // 
            // label163
            // 
            this.label163.AutoSize = (true);
            this.label163.Location = (new global::System.Drawing.Point(163, 50));
            this.label163.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label163.Name = ("label163");
            this.label163.Size = (new global::System.Drawing.Size(65, 25));
            this.label163.TabIndex = (74);
            this.label163.Text = ("Height");
            // 
            // edMotDetMatrixWidth
            // 
            this.edMotDetMatrixWidth.Location = (new global::System.Drawing.Point(93, 44));
            this.edMotDetMatrixWidth.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMotDetMatrixWidth.Name = ("edMotDetMatrixWidth");
            this.edMotDetMatrixWidth.Size = (new global::System.Drawing.Size(57, 31));
            this.edMotDetMatrixWidth.TabIndex = (73);
            this.edMotDetMatrixWidth.Text = ("10");
            // 
            // label164
            // 
            this.label164.AutoSize = (true);
            this.label164.Location = (new global::System.Drawing.Point(23, 50));
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
            this.groupBox26.Location = (new global::System.Drawing.Point(20, 368));
            this.groupBox26.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox26.Name = ("groupBox26");
            this.groupBox26.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox26.Size = (new global::System.Drawing.Size(389, 132));
            this.groupBox26.TabIndex = (2);
            this.groupBox26.TabStop = (false);
            this.groupBox26.Text = ("Drop frames");
            // 
            // label162
            // 
            this.label162.AutoSize = (true);
            this.label162.Location = (new global::System.Drawing.Point(157, 40));
            this.label162.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label162.Name = ("label162");
            this.label162.Size = (new global::System.Drawing.Size(90, 25));
            this.label162.TabIndex = (4);
            this.label162.Text = ("Threshold");
            // 
            // tbMotDetDropFramesThreshold
            // 
            this.tbMotDetDropFramesThreshold.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbMotDetDropFramesThreshold.Location = (new global::System.Drawing.Point(158, 71));
            this.tbMotDetDropFramesThreshold.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbMotDetDropFramesThreshold.Maximum = (255);
            this.tbMotDetDropFramesThreshold.Name = ("tbMotDetDropFramesThreshold");
            this.tbMotDetDropFramesThreshold.Size = (new global::System.Drawing.Size(173, 69));
            this.tbMotDetDropFramesThreshold.TabIndex = (5);
            this.tbMotDetDropFramesThreshold.TickFrequency = (5);
            this.tbMotDetDropFramesThreshold.Value = (5);
            // 
            // cbMotDetDropFramesEnabled
            // 
            this.cbMotDetDropFramesEnabled.AutoSize = (true);
            this.cbMotDetDropFramesEnabled.Location = (new global::System.Drawing.Point(23, 36));
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
            this.edMotDetFrameInterval.Size = (new global::System.Drawing.Size(51, 31));
            this.edMotDetFrameInterval.TabIndex = (5);
            this.edMotDetFrameInterval.Text = ("2");
            // 
            // label159
            // 
            this.label159.AutoSize = (true);
            this.label159.Location = (new global::System.Drawing.Point(18, 104));
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
            this.cbCompareGreyscale.Location = (new global::System.Drawing.Point(271, 40));
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
            this.cbCompareBlue.Location = (new global::System.Drawing.Point(197, 40));
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
            this.cbCompareGreen.Location = (new global::System.Drawing.Point(100, 40));
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
            this.cbCompareRed.Location = (new global::System.Drawing.Point(23, 40));
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
            this.cbMotDetEnabled.Location = (new global::System.Drawing.Point(23, 31));
            this.cbMotDetEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMotDetEnabled.Name = ("cbMotDetEnabled");
            this.cbMotDetEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotDetEnabled.TabIndex = (2);
            this.cbMotDetEnabled.Text = ("Enabled");
            this.cbMotDetEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label393);
            this.tabPage2.Controls.Add(this.cbDirect2DRotate);
            this.tabPage2.Controls.Add(this.pnVideoRendererBGColor);
            this.tabPage2.Controls.Add(this.label394);
            this.tabPage2.Controls.Add(this.btFullScreen);
            this.tabPage2.Controls.Add(this.cbScreenFlipVertical);
            this.tabPage2.Controls.Add(this.cbScreenFlipHorizontal);
            this.tabPage2.Controls.Add(this.cbStretch);
            this.tabPage2.Controls.Add(this.groupBox13);
            this.tabPage2.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage2.Name = ("tabPage2");
            this.tabPage2.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage2.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage2.TabIndex = (6);
            this.tabPage2.Text = ("Display");
            this.tabPage2.UseVisualStyleBackColor = (true);
            // 
            // label393
            // 
            this.label393.AutoSize = (true);
            this.label393.Location = (new global::System.Drawing.Point(39, 444));
            this.label393.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label393.Name = ("label393");
            this.label393.Size = (new global::System.Drawing.Size(133, 25));
            this.label393.TabIndex = (65);
            this.label393.Text = ("Direct2D rotate");
            // 
            // cbDirect2DRotate
            // 
            this.cbDirect2DRotate.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDirect2DRotate.FormattingEnabled = (true);
            this.cbDirect2DRotate.Items.AddRange(new global::System.Object[] { "0", "90", "180", "270" });
            this.cbDirect2DRotate.Location = (new global::System.Drawing.Point(43, 474));
            this.cbDirect2DRotate.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDirect2DRotate.Name = ("cbDirect2DRotate");
            this.cbDirect2DRotate.Size = (new global::System.Drawing.Size(201, 33));
            this.cbDirect2DRotate.TabIndex = (64);
            this.cbDirect2DRotate.SelectedIndexChanged += (this.cbDirect2DRotate_SelectedIndexChanged);
            // 
            // pnVideoRendererBGColor
            // 
            this.pnVideoRendererBGColor.BackColor = (global::System.Drawing.Color.Black);
            this.pnVideoRendererBGColor.BorderStyle = (global::System.Windows.Forms.BorderStyle.FixedSingle);
            this.pnVideoRendererBGColor.Location = (new global::System.Drawing.Point(217, 279));
            this.pnVideoRendererBGColor.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.pnVideoRendererBGColor.Name = ("pnVideoRendererBGColor");
            this.pnVideoRendererBGColor.Size = (new global::System.Drawing.Size(39, 44));
            this.pnVideoRendererBGColor.TabIndex = (63);
            this.pnVideoRendererBGColor.Click += (this.pnVideoRendererBGColor_Click);
            // 
            // label394
            // 
            this.label394.AutoSize = (true);
            this.label394.Location = (new global::System.Drawing.Point(39, 288));
            this.label394.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label394.Name = ("label394");
            this.label394.Size = (new global::System.Drawing.Size(152, 25));
            this.label394.TabIndex = (62);
            this.label394.Text = ("Background color");
            // 
            // btFullScreen
            // 
            this.btFullScreen.Location = (new global::System.Drawing.Point(310, 474));
            this.btFullScreen.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btFullScreen.Name = ("btFullScreen");
            this.btFullScreen.Size = (new global::System.Drawing.Size(150, 44));
            this.btFullScreen.TabIndex = (61);
            this.btFullScreen.Text = ("Full screen");
            this.btFullScreen.UseVisualStyleBackColor = (true);
            this.btFullScreen.Click += (this.btFullScreen_Click);
            // 
            // cbScreenFlipVertical
            // 
            this.cbScreenFlipVertical.AutoSize = (true);
            this.cbScreenFlipVertical.Location = (new global::System.Drawing.Point(310, 324));
            this.cbScreenFlipVertical.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbScreenFlipVertical.Name = ("cbScreenFlipVertical");
            this.cbScreenFlipVertical.Size = (new global::System.Drawing.Size(126, 29));
            this.cbScreenFlipVertical.TabIndex = (59);
            this.cbScreenFlipVertical.Text = ("Flip vertical");
            this.cbScreenFlipVertical.UseVisualStyleBackColor = (true);
            this.cbScreenFlipVertical.CheckedChanged += (this.cbScreenFlipVertical_CheckedChanged);
            // 
            // cbScreenFlipHorizontal
            // 
            this.cbScreenFlipHorizontal.AutoSize = (true);
            this.cbScreenFlipHorizontal.Location = (new global::System.Drawing.Point(310, 280));
            this.cbScreenFlipHorizontal.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbScreenFlipHorizontal.Name = ("cbScreenFlipHorizontal");
            this.cbScreenFlipHorizontal.Size = (new global::System.Drawing.Size(150, 29));
            this.cbScreenFlipHorizontal.TabIndex = (58);
            this.cbScreenFlipHorizontal.Text = ("Flip horizontal");
            this.cbScreenFlipHorizontal.UseVisualStyleBackColor = (true);
            this.cbScreenFlipHorizontal.CheckedChanged += (this.cbScreenFlipHorizontal_CheckedChanged);
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = (true);
            this.cbStretch.Location = (new global::System.Drawing.Point(310, 366));
            this.cbStretch.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbStretch.Name = ("cbStretch");
            this.cbStretch.Size = (new global::System.Drawing.Size(141, 29));
            this.cbStretch.TabIndex = (57);
            this.cbStretch.Text = ("Stretch video");
            this.cbStretch.UseVisualStyleBackColor = (true);
            this.cbStretch.CheckedChanged += (this.cbStretch_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbDirect2D);
            this.groupBox13.Controls.Add(this.rbNone);
            this.groupBox13.Controls.Add(this.rbEVR);
            this.groupBox13.Controls.Add(this.rbVMR9);
            this.groupBox13.Location = (new global::System.Drawing.Point(22, 20));
            this.groupBox13.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox13.Name = ("groupBox13");
            this.groupBox13.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox13.Size = (new global::System.Drawing.Size(459, 236));
            this.groupBox13.TabIndex = (56);
            this.groupBox13.TabStop = (false);
            this.groupBox13.Text = ("Video Renderer");
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = (true);
            this.rbDirect2D.Location = (new global::System.Drawing.Point(24, 135));
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
            this.rbNone.Location = (new global::System.Drawing.Point(24, 180));
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
            this.rbEVR.Location = (new global::System.Drawing.Point(24, 91));
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
            this.rbVMR9.Location = (new global::System.Drawing.Point(24, 48));
            this.rbVMR9.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbVMR9.Name = ("rbVMR9");
            this.rbVMR9.Size = (new global::System.Drawing.Size(231, 29));
            this.rbVMR9.TabIndex = (1);
            this.rbVMR9.Text = ("Video Mixing Renderer 9");
            this.rbVMR9.UseVisualStyleBackColor = (true);
            this.rbVMR9.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // tabPage25
            // 
            this.tabPage25.Controls.Add(this.edBarcodeMetadata);
            this.tabPage25.Controls.Add(this.label91);
            this.tabPage25.Controls.Add(this.cbBarcodeType);
            this.tabPage25.Controls.Add(this.label90);
            this.tabPage25.Controls.Add(this.btBarcodeReset);
            this.tabPage25.Controls.Add(this.edBarcode);
            this.tabPage25.Controls.Add(this.label89);
            this.tabPage25.Controls.Add(this.cbBarcodeDetectionEnabled);
            this.tabPage25.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage25.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage25.Name = ("tabPage25");
            this.tabPage25.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage25.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage25.TabIndex = (8);
            this.tabPage25.Text = ("Barcode reader");
            this.tabPage25.UseVisualStyleBackColor = (true);
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = (new global::System.Drawing.Point(23, 310));
            this.edBarcodeMetadata.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.edBarcodeMetadata.Multiline = (true);
            this.edBarcodeMetadata.Name = ("edBarcodeMetadata");
            this.edBarcodeMetadata.Size = (new global::System.Drawing.Size(467, 182));
            this.edBarcodeMetadata.TabIndex = (24);
            // 
            // label91
            // 
            this.label91.AutoSize = (true);
            this.label91.Location = (new global::System.Drawing.Point(18, 272));
            this.label91.Name = ("label91");
            this.label91.Size = (new global::System.Drawing.Size(87, 25));
            this.label91.TabIndex = (23);
            this.label91.Text = ("Metadata");
            // 
            // cbBarcodeType
            // 
            this.cbBarcodeType.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbBarcodeType.FormattingEnabled = (true);
            this.cbBarcodeType.Items.AddRange(new global::System.Object[] { "Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417" });
            this.cbBarcodeType.Location = (new global::System.Drawing.Point(23, 125));
            this.cbBarcodeType.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.cbBarcodeType.Name = ("cbBarcodeType");
            this.cbBarcodeType.Size = (new global::System.Drawing.Size(264, 33));
            this.cbBarcodeType.TabIndex = (22);
            // 
            // label90
            // 
            this.label90.AutoSize = (true);
            this.label90.Location = (new global::System.Drawing.Point(18, 94));
            this.label90.Name = ("label90");
            this.label90.Size = (new global::System.Drawing.Size(116, 25));
            this.label90.TabIndex = (21);
            this.label90.Text = ("Barcode type");
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = (new global::System.Drawing.Point(23, 518));
            this.btBarcodeReset.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.btBarcodeReset.Name = ("btBarcodeReset");
            this.btBarcodeReset.Size = (new global::System.Drawing.Size(103, 44));
            this.btBarcodeReset.TabIndex = (20);
            this.btBarcodeReset.Text = ("Restart");
            this.btBarcodeReset.UseVisualStyleBackColor = (true);
            this.btBarcodeReset.Click += (this.btBarcodeReset_Click);
            // 
            // edBarcode
            // 
            this.edBarcode.Location = (new global::System.Drawing.Point(23, 218));
            this.edBarcode.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.edBarcode.Name = ("edBarcode");
            this.edBarcode.Size = (new global::System.Drawing.Size(467, 31));
            this.edBarcode.TabIndex = (19);
            // 
            // label89
            // 
            this.label89.AutoSize = (true);
            this.label89.Location = (new global::System.Drawing.Point(18, 186));
            this.label89.Name = ("label89");
            this.label89.Size = (new global::System.Drawing.Size(153, 25));
            this.label89.TabIndex = (18);
            this.label89.Text = ("Detected barcode");
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = (true);
            this.cbBarcodeDetectionEnabled.Location = (new global::System.Drawing.Point(23, 36));
            this.cbBarcodeDetectionEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbBarcodeDetectionEnabled.Name = ("cbBarcodeDetectionEnabled");
            this.cbBarcodeDetectionEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbBarcodeDetectionEnabled.TabIndex = (17);
            this.cbBarcodeDetectionEnabled.Text = ("Enabled");
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage28
            // 
            this.tabPage28.Controls.Add(this.cbNetworkStreamingMode);
            this.tabPage28.Controls.Add(this.tabControl5);
            this.tabPage28.Controls.Add(this.cbNetworkStreamingAudioEnabled);
            this.tabPage28.Controls.Add(this.cbNetworkStreaming);
            this.tabPage28.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage28.Margin = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage28.Name = ("tabPage28");
            this.tabPage28.Padding = (new global::System.Windows.Forms.Padding(3, 4, 3, 4));
            this.tabPage28.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage28.TabIndex = (9);
            this.tabPage28.Text = ("Network streaming");
            this.tabPage28.UseVisualStyleBackColor = (true);
            // 
            // cbNetworkStreamingMode
            // 
            this.cbNetworkStreamingMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbNetworkStreamingMode.FormattingEnabled = (true);
            this.cbNetworkStreamingMode.Items.AddRange(new global::System.Object[] { "Windows Media Video", "RTSP", "RTMP (including YouTube and Facebook)", "NDI", "UDP", "Smooth Streaming to Microsoft IIS", "Output to external virtual devices", "HTTP Live Streaming (HLS)" });
            this.cbNetworkStreamingMode.Location = (new global::System.Drawing.Point(27, 75));
            this.cbNetworkStreamingMode.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbNetworkStreamingMode.Name = ("cbNetworkStreamingMode");
            this.cbNetworkStreamingMode.Size = (new global::System.Drawing.Size(457, 33));
            this.cbNetworkStreamingMode.TabIndex = (26);
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage32);
            this.tabControl5.Controls.Add(this.tabPage49);
            this.tabControl5.Controls.Add(this.tabPage50);
            this.tabControl5.Controls.Add(this.tabPage4);
            this.tabControl5.Controls.Add(this.tabPage77);
            this.tabControl5.Controls.Add(this.tabPage51);
            this.tabControl5.Controls.Add(this.tabPage33);
            this.tabControl5.Controls.Add(this.tabPage5);
            this.tabControl5.Location = (new global::System.Drawing.Point(7, 140));
            this.tabControl5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl5.Name = ("tabControl5");
            this.tabControl5.SelectedIndex = (0);
            this.tabControl5.Size = (new global::System.Drawing.Size(487, 728));
            this.tabControl5.TabIndex = (25);
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.label24);
            this.tabPage32.Controls.Add(this.edNetworkURL);
            this.tabPage32.Controls.Add(this.edWMVNetworkPort);
            this.tabPage32.Controls.Add(this.label21);
            this.tabPage32.Controls.Add(this.btRefreshClients);
            this.tabPage32.Controls.Add(this.lbNetworkClients);
            this.tabPage32.Controls.Add(this.rbNetworkStreamingUseExternalProfile);
            this.tabPage32.Controls.Add(this.rbNetworkStreamingUseMainWMVSettings);
            this.tabPage32.Controls.Add(this.label81);
            this.tabPage32.Controls.Add(this.label80);
            this.tabPage32.Controls.Add(this.edMaximumClients);
            this.tabPage32.Controls.Add(this.label22);
            this.tabPage32.Controls.Add(this.btSelectWMVProfileNetwork);
            this.tabPage32.Controls.Add(this.edNetworkStreamingWMVProfile);
            this.tabPage32.Controls.Add(this.label23);
            this.tabPage32.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage32.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage32.Name = ("tabPage32");
            this.tabPage32.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage32.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage32.TabIndex = (0);
            this.tabPage32.Text = ("WMV");
            this.tabPage32.UseVisualStyleBackColor = (true);
            // 
            // label24
            // 
            this.label24.AutoSize = (true);
            this.label24.Location = (new global::System.Drawing.Point(22, 575));
            this.label24.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label24.Name = ("label24");
            this.label24.Size = (new global::System.Drawing.Size(138, 25));
            this.label24.TabIndex = (32);
            this.label24.Text = ("Connection URL");
            // 
            // edNetworkURL
            // 
            this.edNetworkURL.Location = (new global::System.Drawing.Point(24, 606));
            this.edNetworkURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkURL.Name = ("edNetworkURL");
            this.edNetworkURL.ReadOnly = (true);
            this.edNetworkURL.Size = (new global::System.Drawing.Size(433, 31));
            this.edNetworkURL.TabIndex = (31);
            // 
            // edWMVNetworkPort
            // 
            this.edWMVNetworkPort.Location = (new global::System.Drawing.Point(393, 231));
            this.edWMVNetworkPort.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edWMVNetworkPort.Name = ("edWMVNetworkPort");
            this.edWMVNetworkPort.Size = (new global::System.Drawing.Size(54, 31));
            this.edWMVNetworkPort.TabIndex = (30);
            this.edWMVNetworkPort.Text = ("100");
            // 
            // label21
            // 
            this.label21.AutoSize = (true);
            this.label21.Location = (new global::System.Drawing.Point(270, 236));
            this.label21.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label21.Name = ("label21");
            this.label21.Size = (new global::System.Drawing.Size(118, 25));
            this.label21.TabIndex = (29);
            this.label21.Text = ("Network port");
            // 
            // btRefreshClients
            // 
            this.btRefreshClients.Location = (new global::System.Drawing.Point(343, 456));
            this.btRefreshClients.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btRefreshClients.Name = ("btRefreshClients");
            this.btRefreshClients.Size = (new global::System.Drawing.Size(107, 44));
            this.btRefreshClients.TabIndex = (28);
            this.btRefreshClients.Text = ("Refresh");
            this.btRefreshClients.UseVisualStyleBackColor = (true);
            this.btRefreshClients.Click += (this.btRefreshClients_Click);
            // 
            // lbNetworkClients
            // 
            this.lbNetworkClients.FormattingEnabled = (true);
            this.lbNetworkClients.ItemHeight = (25);
            this.lbNetworkClients.Location = (new global::System.Drawing.Point(24, 336));
            this.lbNetworkClients.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbNetworkClients.Name = ("lbNetworkClients");
            this.lbNetworkClients.Size = (new global::System.Drawing.Size(422, 104));
            this.lbNetworkClients.TabIndex = (27);
            // 
            // rbNetworkStreamingUseExternalProfile
            // 
            this.rbNetworkStreamingUseExternalProfile.AutoSize = (true);
            this.rbNetworkStreamingUseExternalProfile.Location = (new global::System.Drawing.Point(24, 72));
            this.rbNetworkStreamingUseExternalProfile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkStreamingUseExternalProfile.Name = ("rbNetworkStreamingUseExternalProfile");
            this.rbNetworkStreamingUseExternalProfile.Size = (new global::System.Drawing.Size(188, 29));
            this.rbNetworkStreamingUseExternalProfile.TabIndex = (26);
            this.rbNetworkStreamingUseExternalProfile.Text = ("Use external profile");
            this.rbNetworkStreamingUseExternalProfile.UseVisualStyleBackColor = (true);
            // 
            // rbNetworkStreamingUseMainWMVSettings
            // 
            this.rbNetworkStreamingUseMainWMVSettings.AutoSize = (true);
            this.rbNetworkStreamingUseMainWMVSettings.Checked = (true);
            this.rbNetworkStreamingUseMainWMVSettings.Location = (new global::System.Drawing.Point(24, 29));
            this.rbNetworkStreamingUseMainWMVSettings.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkStreamingUseMainWMVSettings.Name = ("rbNetworkStreamingUseMainWMVSettings");
            this.rbNetworkStreamingUseMainWMVSettings.Size = (new global::System.Drawing.Size(321, 29));
            this.rbNetworkStreamingUseMainWMVSettings.TabIndex = (25);
            this.rbNetworkStreamingUseMainWMVSettings.TabStop = (true);
            this.rbNetworkStreamingUseMainWMVSettings.Text = ("Use WMV settings from capture tab");
            this.rbNetworkStreamingUseMainWMVSettings.UseVisualStyleBackColor = (true);
            // 
            // label81
            // 
            this.label81.AutoSize = (true);
            this.label81.Location = (new global::System.Drawing.Point(57, 522));
            this.label81.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label81.Name = ("label81");
            this.label81.Size = (new global::System.Drawing.Size(381, 25));
            this.label81.TabIndex = (24);
            this.label81.Text = ("You can use Windows Media Player for testing.");
            // 
            // label80
            // 
            this.label80.AutoSize = (true);
            this.label80.Location = (new global::System.Drawing.Point(22, 306));
            this.label80.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label80.Name = ("label80");
            this.label80.Size = (new global::System.Drawing.Size(64, 25));
            this.label80.TabIndex = (23);
            this.label80.Text = ("Clients");
            // 
            // edMaximumClients
            // 
            this.edMaximumClients.Location = (new global::System.Drawing.Point(182, 231));
            this.edMaximumClients.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMaximumClients.Name = ("edMaximumClients");
            this.edMaximumClients.Size = (new global::System.Drawing.Size(54, 31));
            this.edMaximumClients.TabIndex = (22);
            this.edMaximumClients.Text = ("10");
            // 
            // label22
            // 
            this.label22.AutoSize = (true);
            this.label22.Location = (new global::System.Drawing.Point(22, 236));
            this.label22.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label22.Name = ("label22");
            this.label22.Size = (new global::System.Drawing.Size(145, 25));
            this.label22.TabIndex = (21);
            this.label22.Text = ("Maximum clients");
            // 
            // btSelectWMVProfileNetwork
            // 
            this.btSelectWMVProfileNetwork.Location = (new global::System.Drawing.Point(410, 158));
            this.btSelectWMVProfileNetwork.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectWMVProfileNetwork.Name = ("btSelectWMVProfileNetwork");
            this.btSelectWMVProfileNetwork.Size = (new global::System.Drawing.Size(40, 44));
            this.btSelectWMVProfileNetwork.TabIndex = (20);
            this.btSelectWMVProfileNetwork.Text = ("...");
            this.btSelectWMVProfileNetwork.UseVisualStyleBackColor = (true);
            this.btSelectWMVProfileNetwork.Click += (this.btSelectWMVProfileNetwork_Click);
            // 
            // edNetworkStreamingWMVProfile
            // 
            this.edNetworkStreamingWMVProfile.Location = (new global::System.Drawing.Point(62, 161));
            this.edNetworkStreamingWMVProfile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkStreamingWMVProfile.Name = ("edNetworkStreamingWMVProfile");
            this.edNetworkStreamingWMVProfile.Size = (new global::System.Drawing.Size(341, 31));
            this.edNetworkStreamingWMVProfile.TabIndex = (19);
            this.edNetworkStreamingWMVProfile.Text = ("c:\\WM.prx");
            // 
            // label23
            // 
            this.label23.AutoSize = (true);
            this.label23.Location = (new global::System.Drawing.Point(57, 131));
            this.label23.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label23.Name = ("label23");
            this.label23.Size = (new global::System.Drawing.Size(87, 25));
            this.label23.TabIndex = (18);
            this.label23.Text = ("File name");
            // 
            // tabPage49
            // 
            this.tabPage49.Controls.Add(this.edNetworkRTSPURL);
            this.tabPage49.Controls.Add(this.label367);
            this.tabPage49.Controls.Add(this.label366);
            this.tabPage49.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage49.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage49.Name = ("tabPage49");
            this.tabPage49.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage49.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage49.TabIndex = (2);
            this.tabPage49.Text = ("RTSP");
            this.tabPage49.UseVisualStyleBackColor = (true);
            // 
            // edNetworkRTSPURL
            // 
            this.edNetworkRTSPURL.Location = (new global::System.Drawing.Point(33, 68));
            this.edNetworkRTSPURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkRTSPURL.Name = ("edNetworkRTSPURL");
            this.edNetworkRTSPURL.Size = (new global::System.Drawing.Size(408, 31));
            this.edNetworkRTSPURL.TabIndex = (9);
            this.edNetworkRTSPURL.Text = ("rtsp://localhost:5554/vfstream");
            // 
            // label367
            // 
            this.label367.AutoSize = (true);
            this.label367.Location = (new global::System.Drawing.Point(29, 36));
            this.label367.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label367.Name = ("label367");
            this.label367.Size = (new global::System.Drawing.Size(43, 25));
            this.label367.TabIndex = (8);
            this.label367.Text = ("URL");
            // 
            // label366
            // 
            this.label366.AutoSize = (true);
            this.label366.Location = (new global::System.Drawing.Point(29, 622));
            this.label366.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label366.Name = ("label366");
            this.label366.Size = (new global::System.Drawing.Size(272, 25));
            this.label366.TabIndex = (7);
            this.label366.Text = ("MP4 output settings will be used");
            // 
            // tabPage50
            // 
            this.tabPage50.Controls.Add(this.linkLabel11);
            this.tabPage50.Controls.Add(this.rbNetworkRTMPFFMPEGCustom);
            this.tabPage50.Controls.Add(this.rbNetworkRTMPFFMPEG);
            this.tabPage50.Controls.Add(this.edNetworkRTMPURL);
            this.tabPage50.Controls.Add(this.label368);
            this.tabPage50.Controls.Add(this.label369);
            this.tabPage50.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage50.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage50.Name = ("tabPage50");
            this.tabPage50.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage50.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage50.TabIndex = (3);
            this.tabPage50.Text = ("RTMP");
            this.tabPage50.UseVisualStyleBackColor = (true);
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = (true);
            this.linkLabel11.Location = (new global::System.Drawing.Point(29, 211));
            this.linkLabel11.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel11.Name = ("linkLabel11");
            this.linkLabel11.Size = (new global::System.Drawing.Size(258, 25));
            this.linkLabel11.TabIndex = (19);
            this.linkLabel11.TabStop = (true);
            this.linkLabel11.Text = ("Network streaming to YouTube");
            this.linkLabel11.LinkClicked += (this.linkLabel11_LinkClicked);
            // 
            // rbNetworkRTMPFFMPEGCustom
            // 
            this.rbNetworkRTMPFFMPEGCustom.AutoSize = (true);
            this.rbNetworkRTMPFFMPEGCustom.Location = (new global::System.Drawing.Point(33, 81));
            this.rbNetworkRTMPFFMPEGCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkRTMPFFMPEGCustom.Name = ("rbNetworkRTMPFFMPEGCustom");
            this.rbNetworkRTMPFFMPEGCustom.Size = (new global::System.Drawing.Size(318, 29));
            this.rbNetworkRTMPFFMPEGCustom.TabIndex = (17);
            this.rbNetworkRTMPFFMPEGCustom.Text = ("Custom settings using FFMPEG EXE");
            this.rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = (true);
            // 
            // rbNetworkRTMPFFMPEG
            // 
            this.rbNetworkRTMPFFMPEG.AutoSize = (true);
            this.rbNetworkRTMPFFMPEG.Checked = (true);
            this.rbNetworkRTMPFFMPEG.Location = (new global::System.Drawing.Point(33, 36));
            this.rbNetworkRTMPFFMPEG.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkRTMPFFMPEG.Name = ("rbNetworkRTMPFFMPEG");
            this.rbNetworkRTMPFFMPEG.Size = (new global::System.Drawing.Size(284, 29));
            this.rbNetworkRTMPFFMPEG.TabIndex = (16);
            this.rbNetworkRTMPFFMPEG.TabStop = (true);
            this.rbNetworkRTMPFFMPEG.Text = ("H264 / AAC using FFMPEG EXE");
            this.rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = (true);
            // 
            // edNetworkRTMPURL
            // 
            this.edNetworkRTMPURL.Location = (new global::System.Drawing.Point(33, 564));
            this.edNetworkRTMPURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkRTMPURL.Name = ("edNetworkRTMPURL");
            this.edNetworkRTMPURL.Size = (new global::System.Drawing.Size(408, 31));
            this.edNetworkRTMPURL.TabIndex = (15);
            this.edNetworkRTMPURL.Text = ("rtmp://localhost:5554/live/Stream");
            // 
            // label368
            // 
            this.label368.AutoSize = (true);
            this.label368.Location = (new global::System.Drawing.Point(29, 532));
            this.label368.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label368.Name = ("label368");
            this.label368.Size = (new global::System.Drawing.Size(43, 25));
            this.label368.TabIndex = (14);
            this.label368.Text = ("URL");
            // 
            // label369
            // 
            this.label369.AutoSize = (true);
            this.label369.Location = (new global::System.Drawing.Point(29, 622));
            this.label369.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label369.Name = ("label369");
            this.label369.Size = (new global::System.Drawing.Size(374, 25));
            this.label369.TabIndex = (13);
            this.label369.Text = ("Format settings located on output format tab");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbNDI);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.edNDIURL);
            this.tabPage4.Controls.Add(this.edNDIName);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage4.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage4.Name = ("tabPage4");
            this.tabPage4.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage4.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage4.TabIndex = (6);
            this.tabPage4.Text = ("NDI");
            this.tabPage4.UseVisualStyleBackColor = (true);
            // 
            // lbNDI
            // 
            this.lbNDI.AutoSize = (true);
            this.lbNDI.Location = (new global::System.Drawing.Point(24, 260));
            this.lbNDI.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbNDI.Name = ("lbNDI");
            this.lbNDI.Size = (new global::System.Drawing.Size(145, 25));
            this.lbNDI.TabIndex = (95);
            this.lbNDI.TabStop = (true);
            this.lbNDI.Text = ("vendor's website");
            this.lbNDI.LinkClicked += (this.lbNDI_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = (true);
            this.label11.Location = (new global::System.Drawing.Point(24, 235));
            this.label11.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label11.Name = ("label11");
            this.label11.Size = (new global::System.Drawing.Size(428, 25));
            this.label11.TabIndex = (94);
            this.label11.Text = ("To use NDI please install NDI SDK for Windows from");
            // 
            // label12
            // 
            this.label12.AutoSize = (true);
            this.label12.Location = (new global::System.Drawing.Point(24, 136));
            this.label12.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label12.Name = ("label12");
            this.label12.Size = (new global::System.Drawing.Size(138, 25));
            this.label12.TabIndex = (93);
            this.label12.Text = ("Connection URL");
            // 
            // edNDIURL
            // 
            this.edNDIURL.Location = (new global::System.Drawing.Point(30, 168));
            this.edNDIURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNDIURL.Name = ("edNDIURL");
            this.edNDIURL.ReadOnly = (true);
            this.edNDIURL.Size = (new global::System.Drawing.Size(402, 31));
            this.edNDIURL.TabIndex = (92);
            // 
            // edNDIName
            // 
            this.edNDIName.Location = (new global::System.Drawing.Point(30, 68));
            this.edNDIName.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNDIName.Name = ("edNDIName");
            this.edNDIName.Size = (new global::System.Drawing.Size(402, 31));
            this.edNDIName.TabIndex = (91);
            this.edNDIName.Text = ("Main");
            // 
            // label13
            // 
            this.label13.AutoSize = (true);
            this.label13.Location = (new global::System.Drawing.Point(24, 36));
            this.label13.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label13.Name = ("label13");
            this.label13.Size = (new global::System.Drawing.Size(59, 25));
            this.label13.TabIndex = (90);
            this.label13.Text = ("Name");
            // 
            // tabPage77
            // 
            this.tabPage77.Controls.Add(this.label484);
            this.tabPage77.Controls.Add(this.label63);
            this.tabPage77.Controls.Add(this.label62);
            this.tabPage77.Controls.Add(this.label314);
            this.tabPage77.Controls.Add(this.label313);
            this.tabPage77.Controls.Add(this.edNetworkUDPURL);
            this.tabPage77.Controls.Add(this.label372);
            this.tabPage77.Controls.Add(this.rbNetworkUDPFFMPEGCustom);
            this.tabPage77.Controls.Add(this.rbNetworkUDPFFMPEG);
            this.tabPage77.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage77.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage77.Name = ("tabPage77");
            this.tabPage77.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage77.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage77.TabIndex = (5);
            this.tabPage77.Text = ("UDP");
            this.tabPage77.UseVisualStyleBackColor = (true);
            // 
            // label484
            // 
            this.label484.AutoSize = (true);
            this.label484.Location = (new global::System.Drawing.Point(44, 629));
            this.label484.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label484.Name = ("label484");
            this.label484.Size = (new global::System.Drawing.Size(374, 25));
            this.label484.TabIndex = (24);
            this.label484.Text = ("Specify settings located on output format tab");
            // 
            // label63
            // 
            this.label63.AutoSize = (true);
            this.label63.Location = (new global::System.Drawing.Point(24, 489));
            this.label63.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label63.Name = ("label63");
            this.label63.Size = (new global::System.Drawing.Size(182, 25));
            this.label63.TabIndex = (23);
            this.label63.Text = ("instead of IP address.");
            // 
            // label62
            // 
            this.label62.AutoSize = (true);
            this.label62.Location = (new global::System.Drawing.Point(24, 464));
            this.label62.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label62.Name = ("label62");
            this.label62.Size = (new global::System.Drawing.Size(388, 25));
            this.label62.TabIndex = (22);
            this.label62.Text = ("To open the stream in VLC on a local PC, use @ ");
            // 
            // label314
            // 
            this.label314.AutoSize = (true);
            this.label314.Location = (new global::System.Drawing.Point(24, 365));
            this.label314.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label314.Name = ("label314");
            this.label314.Size = (new global::System.Drawing.Size(365, 25));
            this.label314.TabIndex = (21);
            this.label314.Text = ("For multicast UDP streaming, use an URL like");
            // 
            // label313
            // 
            this.label313.AutoSize = (true);
            this.label313.Location = (new global::System.Drawing.Point(24, 390));
            this.label313.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label313.Name = ("label313");
            this.label313.Size = (new global::System.Drawing.Size(378, 25));
            this.label313.TabIndex = (20);
            this.label313.Text = ("udp://239.101.101.1:1234?ttl=1&pkt_size=1316");
            // 
            // edNetworkUDPURL
            // 
            this.edNetworkUDPURL.Location = (new global::System.Drawing.Point(30, 321));
            this.edNetworkUDPURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkUDPURL.Name = ("edNetworkUDPURL");
            this.edNetworkUDPURL.Size = (new global::System.Drawing.Size(408, 31));
            this.edNetworkUDPURL.TabIndex = (19);
            this.edNetworkUDPURL.Text = ("udp://127.0.0.1:10000?pkt_size=1316");
            // 
            // label372
            // 
            this.label372.AutoSize = (true);
            this.label372.Location = (new global::System.Drawing.Point(24, 290));
            this.label372.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label372.Name = ("label372");
            this.label372.Size = (new global::System.Drawing.Size(43, 25));
            this.label372.TabIndex = (18);
            this.label372.Text = ("URL");
            // 
            // rbNetworkUDPFFMPEGCustom
            // 
            this.rbNetworkUDPFFMPEGCustom.AutoSize = (true);
            this.rbNetworkUDPFFMPEGCustom.Location = (new global::System.Drawing.Point(30, 81));
            this.rbNetworkUDPFFMPEGCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkUDPFFMPEGCustom.Name = ("rbNetworkUDPFFMPEGCustom");
            this.rbNetworkUDPFFMPEGCustom.Size = (new global::System.Drawing.Size(318, 29));
            this.rbNetworkUDPFFMPEGCustom.TabIndex = (12);
            this.rbNetworkUDPFFMPEGCustom.Text = ("Custom settings using FFMPEG EXE");
            this.rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = (true);
            // 
            // rbNetworkUDPFFMPEG
            // 
            this.rbNetworkUDPFFMPEG.AutoSize = (true);
            this.rbNetworkUDPFFMPEG.Checked = (true);
            this.rbNetworkUDPFFMPEG.Location = (new global::System.Drawing.Point(30, 36));
            this.rbNetworkUDPFFMPEG.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkUDPFFMPEG.Name = ("rbNetworkUDPFFMPEG");
            this.rbNetworkUDPFFMPEG.Size = (new global::System.Drawing.Size(284, 29));
            this.rbNetworkUDPFFMPEG.TabIndex = (11);
            this.rbNetworkUDPFFMPEG.TabStop = (true);
            this.rbNetworkUDPFFMPEG.Text = ("H264 / AAC using FFMPEG EXE");
            this.rbNetworkUDPFFMPEG.UseVisualStyleBackColor = (true);
            // 
            // tabPage51
            // 
            this.tabPage51.Controls.Add(this.rbNetworkSSFFMPEGCustom);
            this.tabPage51.Controls.Add(this.rbNetworkSSFFMPEGDefault);
            this.tabPage51.Controls.Add(this.linkLabel6);
            this.tabPage51.Controls.Add(this.edNetworkSSURL);
            this.tabPage51.Controls.Add(this.label370);
            this.tabPage51.Controls.Add(this.label371);
            this.tabPage51.Controls.Add(this.rbNetworkSSSoftware);
            this.tabPage51.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage51.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage51.Name = ("tabPage51");
            this.tabPage51.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage51.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage51.TabIndex = (4);
            this.tabPage51.Text = ("IIS Smooth Streaming");
            this.tabPage51.UseVisualStyleBackColor = (true);
            // 
            // rbNetworkSSFFMPEGCustom
            // 
            this.rbNetworkSSFFMPEGCustom.AutoSize = (true);
            this.rbNetworkSSFFMPEGCustom.Location = (new global::System.Drawing.Point(33, 118));
            this.rbNetworkSSFFMPEGCustom.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkSSFFMPEGCustom.Name = ("rbNetworkSSFFMPEGCustom");
            this.rbNetworkSSFFMPEGCustom.Size = (new global::System.Drawing.Size(318, 29));
            this.rbNetworkSSFFMPEGCustom.TabIndex = (22);
            this.rbNetworkSSFFMPEGCustom.Text = ("Custom settings using FFMPEG EXE");
            this.rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = (true);
            // 
            // rbNetworkSSFFMPEGDefault
            // 
            this.rbNetworkSSFFMPEGDefault.AutoSize = (true);
            this.rbNetworkSSFFMPEGDefault.Location = (new global::System.Drawing.Point(33, 72));
            this.rbNetworkSSFFMPEGDefault.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkSSFFMPEGDefault.Name = ("rbNetworkSSFFMPEGDefault");
            this.rbNetworkSSFFMPEGDefault.Size = (new global::System.Drawing.Size(284, 29));
            this.rbNetworkSSFFMPEGDefault.TabIndex = (21);
            this.rbNetworkSSFFMPEGDefault.Text = ("H264 / AAC using FFMPEG EXE");
            this.rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = (true);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = (true);
            this.linkLabel6.Location = (new global::System.Drawing.Point(29, 456));
            this.linkLabel6.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel6.Name = ("linkLabel6");
            this.linkLabel6.Size = (new global::System.Drawing.Size(301, 25));
            this.linkLabel6.TabIndex = (20);
            this.linkLabel6.TabStop = (true);
            this.linkLabel6.Text = ("IIS Smooth Streaming usage manual");
            this.linkLabel6.LinkClicked += (this.linkLabel6_LinkClicked);
            // 
            // edNetworkSSURL
            // 
            this.edNetworkSSURL.Location = (new global::System.Drawing.Point(33, 365));
            this.edNetworkSSURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edNetworkSSURL.Name = ("edNetworkSSURL");
            this.edNetworkSSURL.Size = (new global::System.Drawing.Size(408, 31));
            this.edNetworkSSURL.TabIndex = (19);
            this.edNetworkSSURL.Text = ("http://localhost/LiveStream.isml");
            // 
            // label370
            // 
            this.label370.AutoSize = (true);
            this.label370.Location = (new global::System.Drawing.Point(29, 335));
            this.label370.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label370.Name = ("label370");
            this.label370.Size = (new global::System.Drawing.Size(177, 25));
            this.label370.TabIndex = (18);
            this.label370.Text = ("Publishing point URL");
            // 
            // label371
            // 
            this.label371.AutoSize = (true);
            this.label371.Location = (new global::System.Drawing.Point(29, 622));
            this.label371.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label371.Name = ("label371");
            this.label371.Size = (new global::System.Drawing.Size(374, 25));
            this.label371.TabIndex = (17);
            this.label371.Text = ("Format settings located on output format tab");
            // 
            // rbNetworkSSSoftware
            // 
            this.rbNetworkSSSoftware.AutoSize = (true);
            this.rbNetworkSSSoftware.Checked = (true);
            this.rbNetworkSSSoftware.Location = (new global::System.Drawing.Point(33, 29));
            this.rbNetworkSSSoftware.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbNetworkSSSoftware.Name = ("rbNetworkSSSoftware");
            this.rbNetworkSSSoftware.Size = (new global::System.Drawing.Size(322, 29));
            this.rbNetworkSSSoftware.TabIndex = (15);
            this.rbNetworkSSSoftware.TabStop = (true);
            this.rbNetworkSSSoftware.Text = ("H264 / AAC using software encoder");
            this.rbNetworkSSSoftware.UseVisualStyleBackColor = (true);
            // 
            // tabPage33
            // 
            this.tabPage33.Controls.Add(this.linkLabel4);
            this.tabPage33.Controls.Add(this.linkLabel5);
            this.tabPage33.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage33.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage33.Name = ("tabPage33");
            this.tabPage33.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage33.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage33.TabIndex = (1);
            this.tabPage33.Text = ("External");
            this.tabPage33.UseVisualStyleBackColor = (true);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = (true);
            this.linkLabel4.Location = (new global::System.Drawing.Point(43, 94));
            this.linkLabel4.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel4.Name = ("linkLabel4");
            this.linkLabel4.Size = (new global::System.Drawing.Size(379, 25));
            this.linkLabel4.TabIndex = (3);
            this.linkLabel4.TabStop = (true);
            this.linkLabel4.Text = ("Streaming using Microsoft Expression Encoder");
            this.linkLabel4.LinkClicked += (this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = (true);
            this.linkLabel5.Location = (new global::System.Drawing.Point(43, 44));
            this.linkLabel5.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel5.Name = ("linkLabel5");
            this.linkLabel5.Size = (new global::System.Drawing.Size(326, 25));
            this.linkLabel5.TabIndex = (2);
            this.linkLabel5.TabStop = (true);
            this.linkLabel5.Text = ("Streaming to Adobe Flash Media Server");
            this.linkLabel5.LinkClicked += (this.linkLabel5_LinkClicked);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.edHLSURL);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.edHLSEmbeddedHTTPServerPort);
            this.tabPage5.Controls.Add(this.cbHLSEmbeddedHTTPServerEnabled);
            this.tabPage5.Controls.Add(this.cbHLSMode);
            this.tabPage5.Controls.Add(this.label25);
            this.tabPage5.Controls.Add(this.lbHLSConfigure);
            this.tabPage5.Controls.Add(this.label532);
            this.tabPage5.Controls.Add(this.label531);
            this.tabPage5.Controls.Add(this.label530);
            this.tabPage5.Controls.Add(this.label529);
            this.tabPage5.Controls.Add(this.edHLSSegmentCount);
            this.tabPage5.Controls.Add(this.label519);
            this.tabPage5.Controls.Add(this.edHLSSegmentDuration);
            this.tabPage5.Controls.Add(this.btSelectHLSOutputFolder);
            this.tabPage5.Controls.Add(this.edHLSOutputFolder);
            this.tabPage5.Controls.Add(this.label380);
            this.tabPage5.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage5.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage5.Name = ("tabPage5");
            this.tabPage5.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage5.Size = (new global::System.Drawing.Size(479, 690));
            this.tabPage5.TabIndex = (7);
            this.tabPage5.Text = ("HLS");
            this.tabPage5.UseVisualStyleBackColor = (true);
            // 
            // edHLSURL
            // 
            this.edHLSURL.Location = (new global::System.Drawing.Point(23, 554));
            this.edHLSURL.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHLSURL.Name = ("edHLSURL");
            this.edHLSURL.Size = (new global::System.Drawing.Size(417, 31));
            this.edHLSURL.TabIndex = (33);
            this.edHLSURL.Text = ("http://localhost:81/playlist.m3u8");
            // 
            // label14
            // 
            this.label14.AutoSize = (true);
            this.label14.Location = (new global::System.Drawing.Point(18, 602));
            this.label14.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label14.Name = ("label14");
            this.label14.Size = (new global::System.Drawing.Size(29, 25));
            this.label14.TabIndex = (32);
            this.label14.Text = ("or");
            // 
            // edHLSEmbeddedHTTPServerPort
            // 
            this.edHLSEmbeddedHTTPServerPort.Location = (new global::System.Drawing.Point(376, 506));
            this.edHLSEmbeddedHTTPServerPort.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHLSEmbeddedHTTPServerPort.Name = ("edHLSEmbeddedHTTPServerPort");
            this.edHLSEmbeddedHTTPServerPort.Size = (new global::System.Drawing.Size(66, 31));
            this.edHLSEmbeddedHTTPServerPort.TabIndex = (31);
            this.edHLSEmbeddedHTTPServerPort.Text = ("81");
            // 
            // cbHLSEmbeddedHTTPServerEnabled
            // 
            this.cbHLSEmbeddedHTTPServerEnabled.AutoSize = (true);
            this.cbHLSEmbeddedHTTPServerEnabled.Location = (new global::System.Drawing.Point(23, 510));
            this.cbHLSEmbeddedHTTPServerEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbHLSEmbeddedHTTPServerEnabled.Name = ("cbHLSEmbeddedHTTPServerEnabled");
            this.cbHLSEmbeddedHTTPServerEnabled.Size = (new global::System.Drawing.Size(334, 29));
            this.cbHLSEmbeddedHTTPServerEnabled.TabIndex = (30);
            this.cbHLSEmbeddedHTTPServerEnabled.Text = ("Use embedded HTTP server with port");
            this.cbHLSEmbeddedHTTPServerEnabled.UseVisualStyleBackColor = (true);
            // 
            // cbHLSMode
            // 
            this.cbHLSMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbHLSMode.FormattingEnabled = (true);
            this.cbHLSMode.Items.AddRange(new global::System.Object[] { "Live", "VOD", "Event" });
            this.cbHLSMode.Location = (new global::System.Drawing.Point(23, 436));
            this.cbHLSMode.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbHLSMode.Name = ("cbHLSMode");
            this.cbHLSMode.Size = (new global::System.Drawing.Size(200, 33));
            this.cbHLSMode.TabIndex = (29);
            // 
            // label25
            // 
            this.label25.AutoSize = (true);
            this.label25.Location = (new global::System.Drawing.Point(18, 406));
            this.label25.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label25.Name = ("label25");
            this.label25.Size = (new global::System.Drawing.Size(169, 25));
            this.label25.TabIndex = (28);
            this.label25.Text = ("Mode (playlist type)");
            // 
            // lbHLSConfigure
            // 
            this.lbHLSConfigure.AutoSize = (true);
            this.lbHLSConfigure.Location = (new global::System.Drawing.Point(18, 628));
            this.lbHLSConfigure.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbHLSConfigure.Name = ("lbHLSConfigure");
            this.lbHLSConfigure.Size = (new global::System.Drawing.Size(313, 25));
            this.lbHLSConfigure.TabIndex = (27);
            this.lbHLSConfigure.TabStop = (true);
            this.lbHLSConfigure.Text = ("How to configure HTTP server for HLS");
            this.lbHLSConfigure.LinkClicked += (this.lbHLSConfigure_LinkClicked);
            // 
            // label532
            // 
            this.label532.AutoSize = (true);
            this.label532.Location = (new global::System.Drawing.Point(18, 348));
            this.label532.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label532.Name = ("label532");
            this.label532.Size = (new global::System.Drawing.Size(70, 25));
            this.label532.TabIndex = (26);
            this.label532.Text = ("in code");
            // 
            // label531
            // 
            this.label531.AutoSize = (true);
            this.label531.Location = (new global::System.Drawing.Point(18, 322));
            this.label531.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label531.Name = ("label531");
            this.label531.Size = (new global::System.Drawing.Size(410, 25));
            this.label531.TabIndex = (25);
            this.label531.Text = ("You can set video (H264) and audio (AAC) settings");
            // 
            // label530
            // 
            this.label530.AutoSize = (true);
            this.label530.Location = (new global::System.Drawing.Point(103, 256));
            this.label530.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label530.Name = ("label530");
            this.label530.Size = (new global::System.Drawing.Size(222, 25));
            this.label530.TabIndex = (24);
            this.label530.Text = ("Use 0 to save all segments");
            // 
            // label529
            // 
            this.label529.AutoSize = (true);
            this.label529.Location = (new global::System.Drawing.Point(18, 219));
            this.label529.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label529.Name = ("label529");
            this.label529.Size = (new global::System.Drawing.Size(416, 25));
            this.label529.TabIndex = (23);
            this.label529.Text = ("Segment count that will be saved during streaming");
            // 
            // edHLSSegmentCount
            // 
            this.edHLSSegmentCount.Location = (new global::System.Drawing.Point(23, 250));
            this.edHLSSegmentCount.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHLSSegmentCount.Name = ("edHLSSegmentCount");
            this.edHLSSegmentCount.Size = (new global::System.Drawing.Size(67, 31));
            this.edHLSSegmentCount.TabIndex = (22);
            this.edHLSSegmentCount.Text = ("20");
            // 
            // label519
            // 
            this.label519.AutoSize = (true);
            this.label519.Location = (new global::System.Drawing.Point(18, 125));
            this.label519.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label519.Name = ("label519");
            this.label519.Size = (new global::System.Drawing.Size(195, 25));
            this.label519.TabIndex = (21);
            this.label519.Text = ("Segment duration (sec)");
            // 
            // edHLSSegmentDuration
            // 
            this.edHLSSegmentDuration.Location = (new global::System.Drawing.Point(23, 156));
            this.edHLSSegmentDuration.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHLSSegmentDuration.Name = ("edHLSSegmentDuration");
            this.edHLSSegmentDuration.Size = (new global::System.Drawing.Size(67, 31));
            this.edHLSSegmentDuration.TabIndex = (20);
            this.edHLSSegmentDuration.Text = ("10");
            // 
            // btSelectHLSOutputFolder
            // 
            this.btSelectHLSOutputFolder.Location = (new global::System.Drawing.Point(417, 60));
            this.btSelectHLSOutputFolder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectHLSOutputFolder.Name = ("btSelectHLSOutputFolder");
            this.btSelectHLSOutputFolder.Size = (new global::System.Drawing.Size(38, 44));
            this.btSelectHLSOutputFolder.TabIndex = (19);
            this.btSelectHLSOutputFolder.Text = ("...");
            this.btSelectHLSOutputFolder.UseVisualStyleBackColor = (true);
            this.btSelectHLSOutputFolder.Click += (this.btSelectHLSOutputFolder_Click);
            // 
            // edHLSOutputFolder
            // 
            this.edHLSOutputFolder.Location = (new global::System.Drawing.Point(23, 64));
            this.edHLSOutputFolder.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edHLSOutputFolder.Name = ("edHLSOutputFolder");
            this.edHLSOutputFolder.Size = (new global::System.Drawing.Size(381, 31));
            this.edHLSOutputFolder.TabIndex = (18);
            this.edHLSOutputFolder.Text = ("c:\\inetpub\\wwwroot\\hls\\");
            // 
            // label380
            // 
            this.label380.AutoSize = (true);
            this.label380.Location = (new global::System.Drawing.Point(18, 28));
            this.label380.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label380.Name = ("label380");
            this.label380.Size = (new global::System.Drawing.Size(329, 25));
            this.label380.TabIndex = (17);
            this.label380.Text = ("Output folder for video files and playlist");
            // 
            // cbNetworkStreamingAudioEnabled
            // 
            this.cbNetworkStreamingAudioEnabled.AutoSize = (true);
            this.cbNetworkStreamingAudioEnabled.Location = (new global::System.Drawing.Point(27, 879));
            this.cbNetworkStreamingAudioEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbNetworkStreamingAudioEnabled.Name = ("cbNetworkStreamingAudioEnabled");
            this.cbNetworkStreamingAudioEnabled.Size = (new global::System.Drawing.Size(143, 29));
            this.cbNetworkStreamingAudioEnabled.TabIndex = (24);
            this.cbNetworkStreamingAudioEnabled.Text = ("Stream audio");
            this.cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = (true);
            // 
            // cbNetworkStreaming
            // 
            this.cbNetworkStreaming.AutoSize = (true);
            this.cbNetworkStreaming.Location = (new global::System.Drawing.Point(27, 31));
            this.cbNetworkStreaming.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbNetworkStreaming.Name = ("cbNetworkStreaming");
            this.cbNetworkStreaming.Size = (new global::System.Drawing.Size(257, 29));
            this.cbNetworkStreaming.TabIndex = (21);
            this.cbNetworkStreaming.Text = ("Network streaming enabled");
            this.cbNetworkStreaming.UseVisualStyleBackColor = (true);
            // 
            // tabPage34
            // 
            this.tabPage34.Controls.Add(this.label328);
            this.tabPage34.Controls.Add(this.label327);
            this.tabPage34.Controls.Add(this.label326);
            this.tabPage34.Controls.Add(this.label325);
            this.tabPage34.Controls.Add(this.cbVirtualCamera);
            this.tabPage34.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage34.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage34.Name = ("tabPage34");
            this.tabPage34.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage34.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage34.TabIndex = (10);
            this.tabPage34.Text = ("Virtual camera");
            this.tabPage34.UseVisualStyleBackColor = (true);
            // 
            // label328
            // 
            this.label328.AutoSize = (true);
            this.label328.Location = (new global::System.Drawing.Point(22, 244));
            this.label328.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label328.Name = ("label328");
            this.label328.Size = (new global::System.Drawing.Size(337, 25));
            this.label328.TabIndex = (7);
            this.label328.Text = ("TRIAL limitation - 5000 frames to stream.");
            // 
            // label327
            // 
            this.label327.AutoSize = (true);
            this.label327.Location = (new global::System.Drawing.Point(22, 202));
            this.label327.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label327.Name = ("label327");
            this.label327.Size = (new global::System.Drawing.Size(297, 25));
            this.label327.TabIndex = (6);
            this.label327.Text = ("Virtual Camera SDK license required.");
            // 
            // label326
            // 
            this.label326.AutoSize = (true);
            this.label326.Location = (new global::System.Drawing.Point(22, 136));
            this.label326.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label326.Name = ("label326");
            this.label326.Size = (new global::System.Drawing.Size(188, 25));
            this.label326.TabIndex = (5);
            this.label326.Text = ("to see streamed video");
            // 
            // label325
            // 
            this.label325.AutoSize = (true);
            this.label325.Location = (new global::System.Drawing.Point(22, 98));
            this.label325.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label325.Name = ("label325");
            this.label325.Size = (new global::System.Drawing.Size(398, 25));
            this.label325.TabIndex = (4);
            this.label325.Text = ("You are can use VisioForge Virtual Camera device");
            // 
            // cbVirtualCamera
            // 
            this.cbVirtualCamera.AutoSize = (true);
            this.cbVirtualCamera.Location = (new global::System.Drawing.Point(27, 32));
            this.cbVirtualCamera.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVirtualCamera.Name = ("cbVirtualCamera");
            this.cbVirtualCamera.Size = (new global::System.Drawing.Size(174, 29));
            this.cbVirtualCamera.TabIndex = (3);
            this.cbVirtualCamera.Text = ("Enable streaming");
            this.cbVirtualCamera.UseVisualStyleBackColor = (true);
            // 
            // tabPage46
            // 
            this.tabPage46.Controls.Add(this.cbDecklinkOutputDownConversionAnalogOutput);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputDownConversion);
            this.tabPage46.Controls.Add(this.label337);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputHDTVPulldown);
            this.tabPage46.Controls.Add(this.label336);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputBlackToDeck);
            this.tabPage46.Controls.Add(this.label335);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputSingleField);
            this.tabPage46.Controls.Add(this.label334);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputComponentLevels);
            this.tabPage46.Controls.Add(this.label333);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputNTSC);
            this.tabPage46.Controls.Add(this.label332);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputDualLink);
            this.tabPage46.Controls.Add(this.label331);
            this.tabPage46.Controls.Add(this.cbDecklinkOutputAnalog);
            this.tabPage46.Controls.Add(this.label87);
            this.tabPage46.Controls.Add(this.cbDecklinkDV);
            this.tabPage46.Controls.Add(this.cbDecklinkOutput);
            this.tabPage46.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage46.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage46.Name = ("tabPage46");
            this.tabPage46.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage46.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage46.TabIndex = (11);
            this.tabPage46.Text = ("Decklink output");
            this.tabPage46.UseVisualStyleBackColor = (true);
            // 
            // cbDecklinkOutputDownConversionAnalogOutput
            // 
            this.cbDecklinkOutputDownConversionAnalogOutput.AutoSize = (true);
            this.cbDecklinkOutputDownConversionAnalogOutput.Location = (new global::System.Drawing.Point(40, 475));
            this.cbDecklinkOutputDownConversionAnalogOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputDownConversionAnalogOutput.Name = ("cbDecklinkOutputDownConversionAnalogOutput");
            this.cbDecklinkOutputDownConversionAnalogOutput.Size = (new global::System.Drawing.Size(197, 29));
            this.cbDecklinkOutputDownConversionAnalogOutput.TabIndex = (35);
            this.cbDecklinkOutputDownConversionAnalogOutput.Text = ("Analog output used");
            this.cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = (true);
            // 
            // cbDecklinkOutputDownConversion
            // 
            this.cbDecklinkOutputDownConversion.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputDownConversion.FormattingEnabled = (true);
            this.cbDecklinkOutputDownConversion.Items.AddRange(new global::System.Object[] { "Default", "Disabled", "Letterbox 16:9", "Anamorphic", "Anamorphic center" });
            this.cbDecklinkOutputDownConversion.Location = (new global::System.Drawing.Point(40, 429));
            this.cbDecklinkOutputDownConversion.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputDownConversion.Name = ("cbDecklinkOutputDownConversion");
            this.cbDecklinkOutputDownConversion.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputDownConversion.TabIndex = (34);
            // 
            // label337
            // 
            this.label337.AutoSize = (true);
            this.label337.Location = (new global::System.Drawing.Point(36, 398));
            this.label337.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label337.Name = ("label337");
            this.label337.Size = (new global::System.Drawing.Size(202, 25));
            this.label337.TabIndex = (33);
            this.label337.Text = ("Down conversion mode");
            // 
            // cbDecklinkOutputHDTVPulldown
            // 
            this.cbDecklinkOutputHDTVPulldown.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputHDTVPulldown.FormattingEnabled = (true);
            this.cbDecklinkOutputHDTVPulldown.Items.AddRange(new global::System.Object[] { "Default", "Enabled", "Disabled" });
            this.cbDecklinkOutputHDTVPulldown.Location = (new global::System.Drawing.Point(40, 565));
            this.cbDecklinkOutputHDTVPulldown.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputHDTVPulldown.Name = ("cbDecklinkOutputHDTVPulldown");
            this.cbDecklinkOutputHDTVPulldown.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputHDTVPulldown.TabIndex = (32);
            // 
            // label336
            // 
            this.label336.AutoSize = (true);
            this.label336.Location = (new global::System.Drawing.Point(36, 535));
            this.label336.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label336.Name = ("label336");
            this.label336.Size = (new global::System.Drawing.Size(136, 25));
            this.label336.TabIndex = (31);
            this.label336.Text = ("HDTV pulldown");
            // 
            // cbDecklinkOutputBlackToDeck
            // 
            this.cbDecklinkOutputBlackToDeck.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputBlackToDeck.FormattingEnabled = (true);
            this.cbDecklinkOutputBlackToDeck.Items.AddRange(new global::System.Object[] { "Default", "None", "Digital", "Analogue" });
            this.cbDecklinkOutputBlackToDeck.Location = (new global::System.Drawing.Point(40, 339));
            this.cbDecklinkOutputBlackToDeck.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputBlackToDeck.Name = ("cbDecklinkOutputBlackToDeck");
            this.cbDecklinkOutputBlackToDeck.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputBlackToDeck.TabIndex = (30);
            // 
            // label335
            // 
            this.label335.AutoSize = (true);
            this.label335.Location = (new global::System.Drawing.Point(36, 308));
            this.label335.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label335.Name = ("label335");
            this.label335.Size = (new global::System.Drawing.Size(116, 25));
            this.label335.TabIndex = (29);
            this.label335.Text = ("Black to deck");
            // 
            // cbDecklinkOutputSingleField
            // 
            this.cbDecklinkOutputSingleField.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputSingleField.FormattingEnabled = (true);
            this.cbDecklinkOutputSingleField.Items.AddRange(new global::System.Object[] { "Default", "Enabled", "Disabled" });
            this.cbDecklinkOutputSingleField.Location = (new global::System.Drawing.Point(40, 252));
            this.cbDecklinkOutputSingleField.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputSingleField.Name = ("cbDecklinkOutputSingleField");
            this.cbDecklinkOutputSingleField.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputSingleField.TabIndex = (28);
            // 
            // label334
            // 
            this.label334.AutoSize = (true);
            this.label334.Location = (new global::System.Drawing.Point(36, 221));
            this.label334.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label334.Name = ("label334");
            this.label334.Size = (new global::System.Drawing.Size(158, 25));
            this.label334.TabIndex = (27);
            this.label334.Text = ("Single field output");
            // 
            // cbDecklinkOutputComponentLevels
            // 
            this.cbDecklinkOutputComponentLevels.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputComponentLevels.FormattingEnabled = (true);
            this.cbDecklinkOutputComponentLevels.Items.AddRange(new global::System.Object[] { "SMPTE", "Betacam" });
            this.cbDecklinkOutputComponentLevels.Location = (new global::System.Drawing.Point(267, 339));
            this.cbDecklinkOutputComponentLevels.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputComponentLevels.Name = ("cbDecklinkOutputComponentLevels");
            this.cbDecklinkOutputComponentLevels.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputComponentLevels.TabIndex = (26);
            // 
            // label333
            // 
            this.label333.AutoSize = (true);
            this.label333.Location = (new global::System.Drawing.Point(262, 308));
            this.label333.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label333.Name = ("label333");
            this.label333.Size = (new global::System.Drawing.Size(155, 25));
            this.label333.TabIndex = (25);
            this.label333.Text = ("Component levels");
            // 
            // cbDecklinkOutputNTSC
            // 
            this.cbDecklinkOutputNTSC.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputNTSC.FormattingEnabled = (true);
            this.cbDecklinkOutputNTSC.Items.AddRange(new global::System.Object[] { "USA", "Japan" });
            this.cbDecklinkOutputNTSC.Location = (new global::System.Drawing.Point(267, 252));
            this.cbDecklinkOutputNTSC.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputNTSC.Name = ("cbDecklinkOutputNTSC");
            this.cbDecklinkOutputNTSC.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputNTSC.TabIndex = (24);
            // 
            // label332
            // 
            this.label332.AutoSize = (true);
            this.label332.Location = (new global::System.Drawing.Point(262, 221));
            this.label332.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label332.Name = ("label332");
            this.label332.Size = (new global::System.Drawing.Size(130, 25));
            this.label332.TabIndex = (23);
            this.label332.Text = ("NTSC standard");
            // 
            // cbDecklinkOutputDualLink
            // 
            this.cbDecklinkOutputDualLink.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputDualLink.FormattingEnabled = (true);
            this.cbDecklinkOutputDualLink.Items.AddRange(new global::System.Object[] { "Default", "Enabled", "Disabled" });
            this.cbDecklinkOutputDualLink.Location = (new global::System.Drawing.Point(40, 165));
            this.cbDecklinkOutputDualLink.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputDualLink.Name = ("cbDecklinkOutputDualLink");
            this.cbDecklinkOutputDualLink.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputDualLink.TabIndex = (22);
            // 
            // label331
            // 
            this.label331.AutoSize = (true);
            this.label331.Location = (new global::System.Drawing.Point(36, 135));
            this.label331.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label331.Name = ("label331");
            this.label331.Size = (new global::System.Drawing.Size(132, 25));
            this.label331.TabIndex = (21);
            this.label331.Text = ("Dual link mode");
            // 
            // cbDecklinkOutputAnalog
            // 
            this.cbDecklinkOutputAnalog.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDecklinkOutputAnalog.FormattingEnabled = (true);
            this.cbDecklinkOutputAnalog.Items.AddRange(new global::System.Object[] { "Auto", "Component", "Composite", "S-Video" });
            this.cbDecklinkOutputAnalog.Location = (new global::System.Drawing.Point(267, 165));
            this.cbDecklinkOutputAnalog.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutputAnalog.Name = ("cbDecklinkOutputAnalog");
            this.cbDecklinkOutputAnalog.Size = (new global::System.Drawing.Size(200, 33));
            this.cbDecklinkOutputAnalog.TabIndex = (20);
            // 
            // label87
            // 
            this.label87.AutoSize = (true);
            this.label87.Location = (new global::System.Drawing.Point(262, 135));
            this.label87.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label87.Name = ("label87");
            this.label87.Size = (new global::System.Drawing.Size(128, 25));
            this.label87.TabIndex = (19);
            this.label87.Text = ("Analog output");
            // 
            // cbDecklinkDV
            // 
            this.cbDecklinkDV.AutoSize = (true);
            this.cbDecklinkDV.Location = (new global::System.Drawing.Point(56, 72));
            this.cbDecklinkDV.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkDV.Name = ("cbDecklinkDV");
            this.cbDecklinkDV.Size = (new global::System.Drawing.Size(121, 29));
            this.cbDecklinkDV.TabIndex = (3);
            this.cbDecklinkDV.Text = ("DV output");
            this.cbDecklinkDV.UseVisualStyleBackColor = (true);
            // 
            // cbDecklinkOutput
            // 
            this.cbDecklinkOutput.AutoSize = (true);
            this.cbDecklinkOutput.Location = (new global::System.Drawing.Point(24, 29));
            this.cbDecklinkOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDecklinkOutput.Name = ("cbDecklinkOutput");
            this.cbDecklinkOutput.Size = (new global::System.Drawing.Size(281, 29));
            this.cbDecklinkOutput.TabIndex = (2);
            this.cbDecklinkOutput.Text = ("Enable output to Decklink card");
            this.cbDecklinkOutput.UseVisualStyleBackColor = (true);
            // 
            // tabPage47
            // 
            this.tabPage47.Controls.Add(this.groupBox48);
            this.tabPage47.Controls.Add(this.groupBox47);
            this.tabPage47.Controls.Add(this.groupBox43);
            this.tabPage47.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage47.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage47.Name = ("tabPage47");
            this.tabPage47.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage47.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage47.TabIndex = (12);
            this.tabPage47.Text = ("Encryption");
            this.tabPage47.UseVisualStyleBackColor = (true);
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
            this.groupBox48.Location = (new global::System.Drawing.Point(27, 372));
            this.groupBox48.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox48.Name = ("groupBox48");
            this.groupBox48.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox48.Size = (new global::System.Drawing.Size(449, 431));
            this.groupBox48.TabIndex = (11);
            this.groupBox48.TabStop = (false);
            this.groupBox48.Text = ("Encryption key type");
            // 
            // label343
            // 
            this.label343.AutoSize = (true);
            this.label343.Location = (new global::System.Drawing.Point(56, 382));
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
            this.rbEncryptionKeyBinary.Location = (new global::System.Drawing.Point(23, 294));
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
            this.rbEncryptionKeyFile.Location = (new global::System.Drawing.Point(23, 179));
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
            this.rbEncryptionKeyString.Location = (new global::System.Drawing.Point(23, 54));
            this.rbEncryptionKeyString.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionKeyString.Name = ("rbEncryptionKeyString");
            this.rbEncryptionKeyString.Size = (new global::System.Drawing.Size(83, 29));
            this.rbEncryptionKeyString.TabIndex = (0);
            this.rbEncryptionKeyString.TabStop = (true);
            this.rbEncryptionKeyString.Text = ("String");
            this.rbEncryptionKeyString.UseVisualStyleBackColor = (true);
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.rbEncryptionModeAES256);
            this.groupBox47.Controls.Add(this.rbEncryptionModeAES128);
            this.groupBox47.Location = (new global::System.Drawing.Point(27, 31));
            this.groupBox47.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox47.Name = ("groupBox47");
            this.groupBox47.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox47.Size = (new global::System.Drawing.Size(449, 160));
            this.groupBox47.TabIndex = (10);
            this.groupBox47.TabStop = (false);
            this.groupBox47.Text = ("Method");
            // 
            // rbEncryptionModeAES256
            // 
            this.rbEncryptionModeAES256.AutoSize = (true);
            this.rbEncryptionModeAES256.Checked = (true);
            this.rbEncryptionModeAES256.Location = (new global::System.Drawing.Point(23, 98));
            this.rbEncryptionModeAES256.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionModeAES256.Name = ("rbEncryptionModeAES256");
            this.rbEncryptionModeAES256.Size = (new global::System.Drawing.Size(325, 29));
            this.rbEncryptionModeAES256.TabIndex = (1);
            this.rbEncryptionModeAES256.TabStop = (true);
            this.rbEncryptionModeAES256.Text = ("AES-256 (v9 encryption SDK output)");
            this.rbEncryptionModeAES256.UseVisualStyleBackColor = (true);
            // 
            // rbEncryptionModeAES128
            // 
            this.rbEncryptionModeAES128.AutoSize = (true);
            this.rbEncryptionModeAES128.Location = (new global::System.Drawing.Point(23, 54));
            this.rbEncryptionModeAES128.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptionModeAES128.Name = ("rbEncryptionModeAES128");
            this.rbEncryptionModeAES128.Size = (new global::System.Drawing.Size(325, 29));
            this.rbEncryptionModeAES128.TabIndex = (0);
            this.rbEncryptionModeAES128.Text = ("AES-128 (v8 encryption SDK output)");
            this.rbEncryptionModeAES128.UseVisualStyleBackColor = (true);
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.rbEncryptedH264CUDA);
            this.groupBox43.Controls.Add(this.rbEncryptedH264SW);
            this.groupBox43.Location = (new global::System.Drawing.Point(27, 202));
            this.groupBox43.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox43.Name = ("groupBox43");
            this.groupBox43.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox43.Size = (new global::System.Drawing.Size(449, 160));
            this.groupBox43.TabIndex = (9);
            this.groupBox43.TabStop = (false);
            this.groupBox43.Text = ("Video / audio format");
            // 
            // rbEncryptedH264CUDA
            // 
            this.rbEncryptedH264CUDA.AutoSize = (true);
            this.rbEncryptedH264CUDA.Enabled = (false);
            this.rbEncryptedH264CUDA.Location = (new global::System.Drawing.Point(23, 98));
            this.rbEncryptedH264CUDA.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptedH264CUDA.Name = ("rbEncryptedH264CUDA");
            this.rbEncryptedH264CUDA.Size = (new global::System.Drawing.Size(425, 29));
            this.rbEncryptedH264CUDA.TabIndex = (7);
            this.rbEncryptedH264CUDA.Text = ("[Deprecated] Use MP4 H264 CUDA / AAC format");
            this.rbEncryptedH264CUDA.UseVisualStyleBackColor = (true);
            // 
            // rbEncryptedH264SW
            // 
            this.rbEncryptedH264SW.AutoSize = (true);
            this.rbEncryptedH264SW.Checked = (true);
            this.rbEncryptedH264SW.Location = (new global::System.Drawing.Point(23, 54));
            this.rbEncryptedH264SW.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.rbEncryptedH264SW.Name = ("rbEncryptedH264SW");
            this.rbEncryptedH264SW.Size = (new global::System.Drawing.Size(324, 29));
            this.rbEncryptedH264SW.TabIndex = (6);
            this.rbEncryptedH264SW.TabStop = (true);
            this.rbEncryptedH264SW.Text = ("Use MP4 H264 / ACC output format");
            this.rbEncryptedH264SW.UseVisualStyleBackColor = (true);
            // 
            // tabPage79
            // 
            this.tabPage79.Controls.Add(this.TabControl32);
            this.tabPage79.Controls.Add(this.cbTagEnabled);
            this.tabPage79.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage79.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage79.Name = ("tabPage79");
            this.tabPage79.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage79.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage79.TabIndex = (14);
            this.tabPage79.Text = ("Tags");
            this.tabPage79.UseVisualStyleBackColor = (true);
            // 
            // TabControl32
            // 
            this.TabControl32.Controls.Add(this.TabPage142);
            this.TabControl32.Controls.Add(this.TabPage143);
            this.TabControl32.Location = (new global::System.Drawing.Point(9, 89));
            this.TabControl32.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.TabControl32.Name = ("TabControl32");
            this.TabControl32.SelectedIndex = (0);
            this.TabControl32.Size = (new global::System.Drawing.Size(487, 831));
            this.TabControl32.TabIndex = (5);
            // 
            // TabPage142
            // 
            this.TabPage142.Controls.Add(this.edTagTrackID);
            this.TabPage142.Controls.Add(this.Label496);
            this.TabPage142.Controls.Add(this.edTagYear);
            this.TabPage142.Controls.Add(this.Label495);
            this.TabPage142.Controls.Add(this.edTagComment);
            this.TabPage142.Controls.Add(this.Label493);
            this.TabPage142.Controls.Add(this.edTagAlbum);
            this.TabPage142.Controls.Add(this.Label491);
            this.TabPage142.Controls.Add(this.edTagArtists);
            this.TabPage142.Controls.Add(this.label494);
            this.TabPage142.Controls.Add(this.edTagCopyright);
            this.TabPage142.Controls.Add(this.label497);
            this.TabPage142.Controls.Add(this.edTagTitle);
            this.TabPage142.Controls.Add(this.label498);
            this.TabPage142.Location = (new global::System.Drawing.Point(4, 34));
            this.TabPage142.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.TabPage142.Name = ("TabPage142");
            this.TabPage142.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.TabPage142.Size = (new global::System.Drawing.Size(479, 793));
            this.TabPage142.TabIndex = (0);
            this.TabPage142.Text = ("Common");
            this.TabPage142.UseVisualStyleBackColor = (true);
            // 
            // edTagTrackID
            // 
            this.edTagTrackID.Location = (new global::System.Drawing.Point(27, 398));
            this.edTagTrackID.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagTrackID.Name = ("edTagTrackID");
            this.edTagTrackID.Size = (new global::System.Drawing.Size(102, 31));
            this.edTagTrackID.TabIndex = (13);
            this.edTagTrackID.Text = ("1");
            // 
            // Label496
            // 
            this.Label496.AutoSize = (true);
            this.Label496.Location = (new global::System.Drawing.Point(22, 369));
            this.Label496.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.Label496.Name = ("Label496");
            this.Label496.Size = (new global::System.Drawing.Size(74, 25));
            this.Label496.TabIndex = (12);
            this.Label496.Text = ("Track ID");
            // 
            // edTagYear
            // 
            this.edTagYear.Location = (new global::System.Drawing.Point(27, 579));
            this.edTagYear.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagYear.Name = ("edTagYear");
            this.edTagYear.Size = (new global::System.Drawing.Size(102, 31));
            this.edTagYear.TabIndex = (11);
            this.edTagYear.Text = ("2015");
            // 
            // Label495
            // 
            this.Label495.AutoSize = (true);
            this.Label495.Location = (new global::System.Drawing.Point(22, 550));
            this.Label495.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.Label495.Name = ("Label495");
            this.Label495.Size = (new global::System.Drawing.Size(44, 25));
            this.Label495.TabIndex = (10);
            this.Label495.Text = ("Year");
            // 
            // edTagComment
            // 
            this.edTagComment.Location = (new global::System.Drawing.Point(27, 308));
            this.edTagComment.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagComment.Name = ("edTagComment");
            this.edTagComment.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagComment.TabIndex = (9);
            this.edTagComment.Text = ("No comments");
            // 
            // Label493
            // 
            this.Label493.AutoSize = (true);
            this.Label493.Location = (new global::System.Drawing.Point(22, 279));
            this.Label493.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.Label493.Name = ("Label493");
            this.Label493.Size = (new global::System.Drawing.Size(91, 25));
            this.Label493.TabIndex = (8);
            this.Label493.Text = ("Comment");
            // 
            // edTagAlbum
            // 
            this.edTagAlbum.Location = (new global::System.Drawing.Point(27, 222));
            this.edTagAlbum.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagAlbum.Name = ("edTagAlbum");
            this.edTagAlbum.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagAlbum.TabIndex = (7);
            this.edTagAlbum.Text = ("Sample album");
            // 
            // Label491
            // 
            this.Label491.AutoSize = (true);
            this.Label491.Location = (new global::System.Drawing.Point(22, 194));
            this.Label491.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.Label491.Name = ("Label491");
            this.Label491.Size = (new global::System.Drawing.Size(65, 25));
            this.Label491.TabIndex = (6);
            this.Label491.Text = ("Album");
            // 
            // edTagArtists
            // 
            this.edTagArtists.Location = (new global::System.Drawing.Point(27, 139));
            this.edTagArtists.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagArtists.Name = ("edTagArtists");
            this.edTagArtists.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagArtists.TabIndex = (5);
            this.edTagArtists.Text = ("Sample artist");
            // 
            // label494
            // 
            this.label494.AutoSize = (true);
            this.label494.Location = (new global::System.Drawing.Point(22, 110));
            this.label494.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label494.Name = ("label494");
            this.label494.Size = (new global::System.Drawing.Size(62, 25));
            this.label494.TabIndex = (4);
            this.label494.Text = ("Artists");
            // 
            // edTagCopyright
            // 
            this.edTagCopyright.Location = (new global::System.Drawing.Point(27, 490));
            this.edTagCopyright.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagCopyright.Name = ("edTagCopyright");
            this.edTagCopyright.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagCopyright.TabIndex = (3);
            this.edTagCopyright.Text = ("VisioForge");
            // 
            // label497
            // 
            this.label497.AutoSize = (true);
            this.label497.Location = (new global::System.Drawing.Point(22, 461));
            this.label497.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label497.Name = ("label497");
            this.label497.Size = (new global::System.Drawing.Size(91, 25));
            this.label497.TabIndex = (2);
            this.label497.Text = ("Copyright");
            // 
            // edTagTitle
            // 
            this.edTagTitle.Location = (new global::System.Drawing.Point(27, 56));
            this.edTagTitle.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagTitle.Name = ("edTagTitle");
            this.edTagTitle.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagTitle.TabIndex = (1);
            this.edTagTitle.Text = ("Sample output file");
            // 
            // label498
            // 
            this.label498.AutoSize = (true);
            this.label498.Location = (new global::System.Drawing.Point(22, 28));
            this.label498.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label498.Name = ("label498");
            this.label498.Size = (new global::System.Drawing.Size(44, 25));
            this.label498.TabIndex = (0);
            this.label498.Text = ("Title");
            // 
            // TabPage143
            // 
            this.TabPage143.Controls.Add(this.imgTagCover);
            this.TabPage143.Controls.Add(this.Label499);
            this.TabPage143.Controls.Add(this.label500);
            this.TabPage143.Controls.Add(this.edTagLyrics);
            this.TabPage143.Controls.Add(this.label501);
            this.TabPage143.Controls.Add(this.cbTagGenre);
            this.TabPage143.Controls.Add(this.label502);
            this.TabPage143.Controls.Add(this.edTagComposers);
            this.TabPage143.Controls.Add(this.label503);
            this.TabPage143.Location = (new global::System.Drawing.Point(4, 34));
            this.TabPage143.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.TabPage143.Name = ("TabPage143");
            this.TabPage143.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.TabPage143.Size = (new global::System.Drawing.Size(479, 793));
            this.TabPage143.TabIndex = (1);
            this.TabPage143.Text = ("Special");
            this.TabPage143.UseVisualStyleBackColor = (true);
            // 
            // imgTagCover
            // 
            this.imgTagCover.BackColor = (global::System.Drawing.Color.DimGray);
            this.imgTagCover.Location = (new global::System.Drawing.Point(24, 342));
            this.imgTagCover.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.imgTagCover.Name = ("imgTagCover");
            this.imgTagCover.Size = (new global::System.Drawing.Size(280, 264));
            this.imgTagCover.SizeMode = (global::System.Windows.Forms.PictureBoxSizeMode.StretchImage);
            this.imgTagCover.TabIndex = (16);
            this.imgTagCover.TabStop = (false);
            this.imgTagCover.Click += (this.imgTagCover_Click);
            // 
            // Label499
            // 
            this.Label499.AutoSize = (true);
            this.Label499.Location = (new global::System.Drawing.Point(20, 311));
            this.Label499.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.Label499.Name = ("Label499");
            this.Label499.Size = (new global::System.Drawing.Size(177, 25));
            this.Label499.TabIndex = (15);
            this.Label499.Text = ("Cover (click to select)");
            // 
            // label500
            // 
            this.label500.AutoSize = (true);
            this.label500.Location = (new global::System.Drawing.Point(71, 642));
            this.label500.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label500.Name = ("label500");
            this.label500.Size = (new global::System.Drawing.Size(324, 25));
            this.label500.TabIndex = (14);
            this.label500.Text = ("Many other tags are available using API");
            // 
            // edTagLyrics
            // 
            this.edTagLyrics.Location = (new global::System.Drawing.Point(24, 244));
            this.edTagLyrics.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagLyrics.Name = ("edTagLyrics");
            this.edTagLyrics.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagLyrics.TabIndex = (13);
            this.edTagLyrics.Text = ("Yo-ho-ho and the buttle of rum");
            // 
            // label501
            // 
            this.label501.AutoSize = (true);
            this.label501.Location = (new global::System.Drawing.Point(20, 215));
            this.label501.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label501.Name = ("label501");
            this.label501.Size = (new global::System.Drawing.Size(54, 25));
            this.label501.TabIndex = (12);
            this.label501.Text = ("Lyrics");
            // 
            // cbTagGenre
            // 
            this.cbTagGenre.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTagGenre.FormattingEnabled = (true);
            this.cbTagGenre.Location = (new global::System.Drawing.Point(24, 146));
            this.cbTagGenre.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbTagGenre.Name = ("cbTagGenre");
            this.cbTagGenre.Size = (new global::System.Drawing.Size(401, 33));
            this.cbTagGenre.TabIndex = (11);
            // 
            // label502
            // 
            this.label502.AutoSize = (true);
            this.label502.Location = (new global::System.Drawing.Point(20, 115));
            this.label502.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label502.Name = ("label502");
            this.label502.Size = (new global::System.Drawing.Size(58, 25));
            this.label502.TabIndex = (10);
            this.label502.Text = ("Genre");
            // 
            // edTagComposers
            // 
            this.edTagComposers.Location = (new global::System.Drawing.Point(24, 56));
            this.edTagComposers.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edTagComposers.Name = ("edTagComposers");
            this.edTagComposers.Size = (new global::System.Drawing.Size(401, 31));
            this.edTagComposers.TabIndex = (9);
            this.edTagComposers.Text = ("Sample composer");
            // 
            // label503
            // 
            this.label503.AutoSize = (true);
            this.label503.Location = (new global::System.Drawing.Point(20, 28));
            this.label503.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label503.Name = ("label503");
            this.label503.Size = (new global::System.Drawing.Size(103, 25));
            this.label503.TabIndex = (8);
            this.label503.Text = ("Composers");
            // 
            // cbTagEnabled
            // 
            this.cbTagEnabled.AutoSize = (true);
            this.cbTagEnabled.Location = (new global::System.Drawing.Point(23, 31));
            this.cbTagEnabled.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbTagEnabled.Name = ("cbTagEnabled");
            this.cbTagEnabled.Size = (new global::System.Drawing.Size(228, 29));
            this.cbTagEnabled.TabIndex = (4);
            this.cbTagEnabled.Text = ("Write tags to output file");
            this.cbTagEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.cbVUMeter);
            this.tabPage24.Controls.Add(this.tbVUMeterBoost);
            this.tabPage24.Controls.Add(this.label382);
            this.tabPage24.Controls.Add(this.label381);
            this.tabPage24.Controls.Add(this.tbVUMeterAmplification);
            this.tabPage24.Controls.Add(this.cbVUMeterPro);
            this.tabPage24.Controls.Add(this.peakMeterCtrl1);
            this.tabPage24.Controls.Add(this.waveformPainter2);
            this.tabPage24.Controls.Add(this.waveformPainter1);
            this.tabPage24.Controls.Add(this.volumeMeter2);
            this.tabPage24.Controls.Add(this.volumeMeter1);
            this.tabPage24.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage24.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage24.Name = ("tabPage24");
            this.tabPage24.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage24.Size = (new global::System.Drawing.Size(509, 962));
            this.tabPage24.TabIndex = (16);
            this.tabPage24.Text = ("Audio output");
            this.tabPage24.UseVisualStyleBackColor = (true);
            // 
            // cbVUMeter
            // 
            this.cbVUMeter.AutoSize = (true);
            this.cbVUMeter.Location = (new global::System.Drawing.Point(30, 29));
            this.cbVUMeter.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVUMeter.Name = ("cbVUMeter");
            this.cbVUMeter.Size = (new global::System.Drawing.Size(169, 29));
            this.cbVUMeter.TabIndex = (125);
            this.cbVUMeter.Text = ("Enable VU Meter");
            this.cbVUMeter.UseVisualStyleBackColor = (true);
            // 
            // tbVUMeterBoost
            // 
            this.tbVUMeterBoost.Location = (new global::System.Drawing.Point(296, 585));
            this.tbVUMeterBoost.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVUMeterBoost.Maximum = (30);
            this.tbVUMeterBoost.Minimum = (1);
            this.tbVUMeterBoost.Name = ("tbVUMeterBoost");
            this.tbVUMeterBoost.Size = (new global::System.Drawing.Size(173, 69));
            this.tbVUMeterBoost.TabIndex = (124);
            this.tbVUMeterBoost.Value = (10);
            // 
            // label382
            // 
            this.label382.AutoSize = (true);
            this.label382.Location = (new global::System.Drawing.Point(290, 554));
            this.label382.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label382.Name = ("label382");
            this.label382.Size = (new global::System.Drawing.Size(118, 25));
            this.label382.TabIndex = (123);
            this.label382.Text = ("Meters boost");
            // 
            // label381
            // 
            this.label381.AutoSize = (true);
            this.label381.Location = (new global::System.Drawing.Point(43, 554));
            this.label381.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label381.Name = ("label381");
            this.label381.Size = (new global::System.Drawing.Size(209, 25));
            this.label381.TabIndex = (119);
            this.label381.Text = ("Volume amplification (%)");
            // 
            // tbVUMeterAmplification
            // 
            this.tbVUMeterAmplification.Location = (new global::System.Drawing.Point(49, 585));
            this.tbVUMeterAmplification.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbVUMeterAmplification.Maximum = (100);
            this.tbVUMeterAmplification.Name = ("tbVUMeterAmplification");
            this.tbVUMeterAmplification.Size = (new global::System.Drawing.Size(176, 69));
            this.tbVUMeterAmplification.TabIndex = (118);
            this.tbVUMeterAmplification.Value = (100);
            // 
            // cbVUMeterPro
            // 
            this.cbVUMeterPro.AutoSize = (true);
            this.cbVUMeterPro.Location = (new global::System.Drawing.Point(30, 256));
            this.cbVUMeterPro.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbVUMeterPro.Name = ("cbVUMeterPro");
            this.cbVUMeterPro.Size = (new global::System.Drawing.Size(201, 29));
            this.cbVUMeterPro.TabIndex = (117);
            this.cbVUMeterPro.Text = ("Enable VU meter Pro");
            this.cbVUMeterPro.UseVisualStyleBackColor = (true);
            // 
            // peakMeterCtrl1
            // 
            this.peakMeterCtrl1.ColorHigh = (global::System.Drawing.Color.Red);
            this.peakMeterCtrl1.ColorHighBack = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(150)), (global::System.Int32)((global::System.Byte)(150))));
            this.peakMeterCtrl1.ColorMedium = (global::System.Drawing.Color.Yellow);
            this.peakMeterCtrl1.ColorMediumBack = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(150))));
            this.peakMeterCtrl1.ColorNormal = (global::System.Drawing.Color.Green);
            this.peakMeterCtrl1.ColorNormalBack = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(150)), (global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(150))));
            this.peakMeterCtrl1.FalloffColor = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(180)), (global::System.Int32)((global::System.Byte)(180)), (global::System.Int32)((global::System.Byte)(180))));
            this.peakMeterCtrl1.GridColor = (global::System.Drawing.Color.Gainsboro);
            this.peakMeterCtrl1.Location = (new global::System.Drawing.Point(229, 29));
            this.peakMeterCtrl1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.peakMeterCtrl1.Name = ("peakMeterCtrl1");
            this.peakMeterCtrl1.Size = (new global::System.Drawing.Size(176, 118));
            this.peakMeterCtrl1.TabIndex = (126);
            this.peakMeterCtrl1.Text = ("peakMeterCtrl1");
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Boost = (1F);
            this.waveformPainter2.Location = (new global::System.Drawing.Point(178, 428));
            this.waveformPainter2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.waveformPainter2.Name = ("waveformPainter2");
            this.waveformPainter2.Size = (new global::System.Drawing.Size(290, 115));
            this.waveformPainter2.TabIndex = (122);
            this.waveformPainter2.Text = ("waveformPainter2");
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Boost = (1F);
            this.waveformPainter1.Location = (new global::System.Drawing.Point(178, 300));
            this.waveformPainter1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.waveformPainter1.Name = ("waveformPainter1");
            this.waveformPainter1.Size = (new global::System.Drawing.Size(290, 115));
            this.waveformPainter1.TabIndex = (121);
            this.waveformPainter1.Text = ("waveformPainter1");
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = (0F);
            this.volumeMeter2.BackColor = (global::System.Drawing.Color.LightGray);
            this.volumeMeter2.Boost = (1F);
            this.volumeMeter2.Location = (new global::System.Drawing.Point(96, 300));
            this.volumeMeter2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.volumeMeter2.MaxDb = (18F);
            this.volumeMeter2.MinDb = (-60F);
            this.volumeMeter2.Name = ("volumeMeter2");
            this.volumeMeter2.Size = (new global::System.Drawing.Size(37, 242));
            this.volumeMeter2.TabIndex = (120);
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = (0F);
            this.volumeMeter1.BackColor = (global::System.Drawing.Color.LightGray);
            this.volumeMeter1.Boost = (1F);
            this.volumeMeter1.Location = (new global::System.Drawing.Point(49, 300));
            this.volumeMeter1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.volumeMeter1.MaxDb = (18F);
            this.volumeMeter1.MinDb = (-60F);
            this.volumeMeter1.Name = ("volumeMeter1");
            this.volumeMeter1.Size = (new global::System.Drawing.Size(37, 242));
            this.volumeMeter1.TabIndex = (116);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btStart.Location = (new global::System.Drawing.Point(1064, 1196));
            this.btStart.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStart.Name = ("btStart");
            this.btStart.Size = (new global::System.Drawing.Size(97, 44));
            this.btStart.TabIndex = (25);
            this.btStart.Text = ("Start");
            this.btStart.UseVisualStyleBackColor = (true);
            this.btStart.Click += (this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btStop.Location = (new global::System.Drawing.Point(1177, 1196));
            this.btStop.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStop.Name = ("btStop");
            this.btStop.Size = (new global::System.Drawing.Size(97, 44));
            this.btStop.TabIndex = (26);
            this.btStop.Text = ("Stop");
            this.btStop.UseVisualStyleBackColor = (true);
            this.btStop.Click += (this.btStop_Click);
            // 
            // OpenDialog1
            // 
            this.OpenDialog1.Filter = (resources.GetString("OpenDialog1.Filter"));
            // 
            // SaveDialog1
            // 
            this.SaveDialog1.Filter = ("AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|All files  (*.*)| *.*");
            // 
            // FontDialog1
            // 
            this.FontDialog1.Color = (global::System.Drawing.Color.White);
            this.FontDialog1.Font = (new global::System.Drawing.Font("Arial", 32F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.FontDialog1.ShowColor = (true);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = ("Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*");
            // 
            // tbSeeking
            // 
            this.tbSeeking.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.tbSeeking.Location = (new global::System.Drawing.Point(557, 1196));
            this.tbSeeking.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbSeeking.Name = ("tbSeeking");
            this.tbSeeking.Size = (new global::System.Drawing.Size(224, 69));
            this.tbSeeking.TabIndex = (46);
            this.tbSeeking.Scroll += (this.tbSeeking_Scroll);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = (true);
            this.linkLabel1.Location = (new global::System.Drawing.Point(407, 1044));
            this.linkLabel1.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.linkLabel1.Name = ("linkLabel1");
            this.linkLabel1.Size = (new global::System.Drawing.Size(130, 25));
            this.linkLabel1.TabIndex = (77);
            this.linkLabel1.TabStop = (true);
            this.linkLabel1.Text = ("Watch tutorials");
            this.linkLabel1.LinkClicked += (this.linkLabel1_LinkClicked);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = ("openFileDialog3");
            this.openFileDialog3.Filter = ("Windows Media profile|*.prx");
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom) | (global::System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.Location = (new global::System.Drawing.Point(791, 1196));
            this.ProgressBar1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.ProgressBar1.Name = ("ProgressBar1");
            this.ProgressBar1.Size = (new global::System.Drawing.Size(263, 42));
            this.ProgressBar1.TabIndex = (9);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage52);
            this.tabControl3.Controls.Add(this.tabPage53);
            this.tabControl3.Controls.Add(this.tabPage54);
            this.tabControl3.Controls.Add(this.tabPage74);
            this.tabControl3.Location = (new global::System.Drawing.Point(551, 22));
            this.tabControl3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabControl3.Name = ("tabControl3");
            this.tabControl3.SelectedIndex = (0);
            this.tabControl3.Size = (new global::System.Drawing.Size(729, 585));
            this.tabControl3.TabIndex = (80);
            // 
            // tabPage52
            // 
            this.tabPage52.Controls.Add(this.linkLabelDecoders);
            this.tabPage52.Controls.Add(this.groupBox7);
            this.tabPage52.Controls.Add(this.label50);
            this.tabPage52.Controls.Add(this.groupBox6);
            this.tabPage52.Controls.Add(this.btClearList);
            this.tabPage52.Controls.Add(this.btAddInputFile);
            this.tabPage52.Controls.Add(this.lbFiles);
            this.tabPage52.Controls.Add(this.label10);
            this.tabPage52.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage52.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage52.Name = ("tabPage52");
            this.tabPage52.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage52.Size = (new global::System.Drawing.Size(721, 547));
            this.tabPage52.TabIndex = (0);
            this.tabPage52.Text = ("Edit");
            this.tabPage52.UseVisualStyleBackColor = (true);
            // 
            // linkLabelDecoders
            // 
            this.linkLabelDecoders.AutoSize = (true);
            this.linkLabelDecoders.Location = (new global::System.Drawing.Point(96, 503));
            this.linkLabelDecoders.Name = ("linkLabelDecoders");
            this.linkLabelDecoders.Size = (new global::System.Drawing.Size(546, 25));
            this.linkLabelDecoders.TabIndex = (57);
            this.linkLabelDecoders.TabStop = (true);
            this.linkLabelDecoders.Text = ("[NuGet only] Install decoders if you can see errors while adding files");
            this.linkLabelDecoders.LinkClicked += (this.linkLabelDecoders_LinkClicked);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label72);
            this.groupBox7.Controls.Add(this.edInsertTime);
            this.groupBox7.Controls.Add(this.label73);
            this.groupBox7.Controls.Add(this.cbInsertAfterPreviousFile);
            this.groupBox7.Location = (new global::System.Drawing.Point(422, 219));
            this.groupBox7.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox7.Name = ("groupBox7");
            this.groupBox7.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox7.Size = (new global::System.Drawing.Size(256, 265));
            this.groupBox7.TabIndex = (56);
            this.groupBox7.TabStop = (false);
            this.groupBox7.Text = ("Timeline");
            // 
            // label72
            // 
            this.label72.AutoSize = (true);
            this.label72.Location = (new global::System.Drawing.Point(193, 86));
            this.label72.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label72.Name = ("label72");
            this.label72.Size = (new global::System.Drawing.Size(36, 25));
            this.label72.TabIndex = (42);
            this.label72.Text = ("ms");
            // 
            // edInsertTime
            // 
            this.edInsertTime.Location = (new global::System.Drawing.Point(127, 81));
            this.edInsertTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edInsertTime.Name = ("edInsertTime");
            this.edInsertTime.Size = (new global::System.Drawing.Size(54, 31));
            this.edInsertTime.TabIndex = (41);
            this.edInsertTime.Text = ("4000");
            // 
            // label73
            // 
            this.label73.AutoSize = (true);
            this.label73.Location = (new global::System.Drawing.Point(20, 86));
            this.label73.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label73.Name = ("label73");
            this.label73.Size = (new global::System.Drawing.Size(96, 25));
            this.label73.TabIndex = (40);
            this.label73.Text = ("Insert time");
            // 
            // cbInsertAfterPreviousFile
            // 
            this.cbInsertAfterPreviousFile.AutoSize = (true);
            this.cbInsertAfterPreviousFile.Checked = (true);
            this.cbInsertAfterPreviousFile.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbInsertAfterPreviousFile.Location = (new global::System.Drawing.Point(20, 36));
            this.cbInsertAfterPreviousFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbInsertAfterPreviousFile.Name = ("cbInsertAfterPreviousFile");
            this.cbInsertAfterPreviousFile.Size = (new global::System.Drawing.Size(224, 29));
            this.cbInsertAfterPreviousFile.TabIndex = (39);
            this.cbInsertAfterPreviousFile.Text = ("Insert after previous file");
            this.cbInsertAfterPreviousFile.UseVisualStyleBackColor = (true);
            // 
            // label50
            // 
            this.label50.AutoSize = (true);
            this.label50.Location = (new global::System.Drawing.Point(10, 178));
            this.label50.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label50.Name = ("label50");
            this.label50.Size = (new global::System.Drawing.Size(427, 25));
            this.label50.TabIndex = (55);
            this.label50.Text = ("You must set this parameters before you add the file");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbSpeed);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.edStopTime);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.edStartTime);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.cbAddFullFile);
            this.groupBox6.Controls.Add(this.tbSpeed);
            this.groupBox6.Location = (new global::System.Drawing.Point(16, 219));
            this.groupBox6.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox6.Name = ("groupBox6");
            this.groupBox6.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.groupBox6.Size = (new global::System.Drawing.Size(397, 265));
            this.groupBox6.TabIndex = (54);
            this.groupBox6.TabStop = (false);
            this.groupBox6.Text = ("Input file");
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = (true);
            this.lbSpeed.Location = (new global::System.Drawing.Point(333, 142));
            this.lbSpeed.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.lbSpeed.Name = ("lbSpeed");
            this.lbSpeed.Size = (new global::System.Drawing.Size(57, 25));
            this.lbSpeed.TabIndex = (44);
            this.lbSpeed.Text = ("100%");
            // 
            // label42
            // 
            this.label42.AutoSize = (true);
            this.label42.Location = (new global::System.Drawing.Point(10, 142));
            this.label42.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label42.Name = ("label42");
            this.label42.Size = (new global::System.Drawing.Size(134, 25));
            this.label42.TabIndex = (42);
            this.label42.Text = ("Playback speed");
            // 
            // label37
            // 
            this.label37.AutoSize = (true);
            this.label37.Location = (new global::System.Drawing.Point(363, 86));
            this.label37.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label37.Name = ("label37");
            this.label37.Size = (new global::System.Drawing.Size(36, 25));
            this.label37.TabIndex = (41);
            this.label37.Text = ("ms");
            // 
            // edStopTime
            // 
            this.edStopTime.Location = (new global::System.Drawing.Point(291, 81));
            this.edStopTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edStopTime.Name = ("edStopTime");
            this.edStopTime.Size = (new global::System.Drawing.Size(64, 31));
            this.edStopTime.TabIndex = (40);
            this.edStopTime.Text = ("5000");
            // 
            // label38
            // 
            this.label38.AutoSize = (true);
            this.label38.Location = (new global::System.Drawing.Point(207, 86));
            this.label38.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label38.Name = ("label38");
            this.label38.Size = (new global::System.Drawing.Size(89, 25));
            this.label38.TabIndex = (39);
            this.label38.Text = ("Stop time");
            // 
            // label36
            // 
            this.label36.AutoSize = (true);
            this.label36.Location = (new global::System.Drawing.Point(176, 86));
            this.label36.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label36.Name = ("label36");
            this.label36.Size = (new global::System.Drawing.Size(36, 25));
            this.label36.TabIndex = (38);
            this.label36.Text = ("ms");
            // 
            // edStartTime
            // 
            this.edStartTime.Location = (new global::System.Drawing.Point(104, 81));
            this.edStartTime.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edStartTime.Name = ("edStartTime");
            this.edStartTime.Size = (new global::System.Drawing.Size(64, 31));
            this.edStartTime.TabIndex = (37);
            this.edStartTime.Text = ("0");
            // 
            // label35
            // 
            this.label35.AutoSize = (true);
            this.label35.Location = (new global::System.Drawing.Point(10, 86));
            this.label35.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label35.Name = ("label35");
            this.label35.Size = (new global::System.Drawing.Size(88, 25));
            this.label35.TabIndex = (36);
            this.label35.Text = ("Start time");
            // 
            // cbAddFullFile
            // 
            this.cbAddFullFile.AutoSize = (true);
            this.cbAddFullFile.Checked = (true);
            this.cbAddFullFile.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbAddFullFile.Location = (new global::System.Drawing.Point(20, 36));
            this.cbAddFullFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbAddFullFile.Name = ("cbAddFullFile");
            this.cbAddFullFile.Size = (new global::System.Drawing.Size(129, 29));
            this.cbAddFullFile.TabIndex = (35);
            this.cbAddFullFile.Text = ("Add full file");
            this.cbAddFullFile.UseVisualStyleBackColor = (true);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = (new global::System.Drawing.Point(169, 131));
            this.tbSpeed.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tbSpeed.Maximum = (400);
            this.tbSpeed.Minimum = (10);
            this.tbSpeed.Name = ("tbSpeed");
            this.tbSpeed.Size = (new global::System.Drawing.Size(164, 69));
            this.tbSpeed.TabIndex = (43);
            this.tbSpeed.Value = (100);
            this.tbSpeed.Scroll += (this.tbSpeed_Scroll);
            // 
            // btClearList
            // 
            this.btClearList.Location = (new global::System.Drawing.Point(560, 108));
            this.btClearList.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btClearList.Name = ("btClearList");
            this.btClearList.Size = (new global::System.Drawing.Size(107, 44));
            this.btClearList.TabIndex = (53);
            this.btClearList.Text = ("Clear");
            this.btClearList.UseVisualStyleBackColor = (true);
            this.btClearList.Click += (this.btClearList_Click);
            // 
            // btAddInputFile
            // 
            this.btAddInputFile.Location = (new global::System.Drawing.Point(560, 52));
            this.btAddInputFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAddInputFile.Name = ("btAddInputFile");
            this.btAddInputFile.Size = (new global::System.Drawing.Size(107, 44));
            this.btAddInputFile.TabIndex = (52);
            this.btAddInputFile.Text = ("Add");
            this.btAddInputFile.UseVisualStyleBackColor = (true);
            this.btAddInputFile.Click += (this.btAddInputFile_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = (true);
            this.lbFiles.ItemHeight = (25);
            this.lbFiles.Location = (new global::System.Drawing.Point(16, 52));
            this.lbFiles.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbFiles.Name = ("lbFiles");
            this.lbFiles.Size = (new global::System.Drawing.Size(533, 104));
            this.lbFiles.TabIndex = (51);
            // 
            // label10
            // 
            this.label10.AutoSize = (true);
            this.label10.Location = (new global::System.Drawing.Point(10, 11));
            this.label10.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label10.Name = ("label10");
            this.label10.Size = (new global::System.Drawing.Size(90, 25));
            this.label10.TabIndex = (50);
            this.label10.Text = ("Input files");
            // 
            // tabPage53
            // 
            this.tabPage53.Controls.Add(this.label134);
            this.tabPage53.Controls.Add(this.btSelectOutputCut);
            this.tabPage53.Controls.Add(this.edOutputFileCut);
            this.tabPage53.Controls.Add(this.label131);
            this.tabPage53.Controls.Add(this.btStopCut);
            this.tabPage53.Controls.Add(this.btStartCut);
            this.tabPage53.Controls.Add(this.label31);
            this.tabPage53.Controls.Add(this.btAddInputFile2);
            this.tabPage53.Controls.Add(this.edSourceFileToCut);
            this.tabPage53.Controls.Add(this.label30);
            this.tabPage53.Controls.Add(this.label26);
            this.tabPage53.Controls.Add(this.edStopTimeCut);
            this.tabPage53.Controls.Add(this.label27);
            this.tabPage53.Controls.Add(this.label28);
            this.tabPage53.Controls.Add(this.edStartTimeCut);
            this.tabPage53.Controls.Add(this.label29);
            this.tabPage53.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage53.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage53.Name = ("tabPage53");
            this.tabPage53.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage53.Size = (new global::System.Drawing.Size(721, 547));
            this.tabPage53.TabIndex = (1);
            this.tabPage53.Text = ("Cut file (w/o reencoding)");
            this.tabPage53.UseVisualStyleBackColor = (true);
            // 
            // label134
            // 
            this.label134.AutoSize = (true);
            this.label134.Location = (new global::System.Drawing.Point(30, 404));
            this.label134.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label134.Name = ("label134");
            this.label134.Size = (new global::System.Drawing.Size(377, 25));
            this.label134.TabIndex = (57);
            this.label134.Text = ("Better to specify start time based on keyframe");
            // 
            // btSelectOutputCut
            // 
            this.btSelectOutputCut.Location = (new global::System.Drawing.Point(616, 206));
            this.btSelectOutputCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectOutputCut.Name = ("btSelectOutputCut");
            this.btSelectOutputCut.Size = (new global::System.Drawing.Size(40, 44));
            this.btSelectOutputCut.TabIndex = (56);
            this.btSelectOutputCut.Text = ("...");
            this.btSelectOutputCut.UseVisualStyleBackColor = (true);
            this.btSelectOutputCut.Click += (this.btSelectOutputCut_Click);
            // 
            // edOutputFileCut
            // 
            this.edOutputFileCut.Location = (new global::System.Drawing.Point(140, 210));
            this.edOutputFileCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOutputFileCut.Name = ("edOutputFileCut");
            this.edOutputFileCut.Size = (new global::System.Drawing.Size(462, 31));
            this.edOutputFileCut.TabIndex = (55);
            this.edOutputFileCut.Text = ("c:\\vf\\video_edit_output.avi");
            // 
            // label131
            // 
            this.label131.AutoSize = (true);
            this.label131.Location = (new global::System.Drawing.Point(30, 215));
            this.label131.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label131.Name = ("label131");
            this.label131.Size = (new global::System.Drawing.Size(97, 25));
            this.label131.TabIndex = (54);
            this.label131.Text = ("Output file");
            // 
            // btStopCut
            // 
            this.btStopCut.Location = (new global::System.Drawing.Point(167, 321));
            this.btStopCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStopCut.Name = ("btStopCut");
            this.btStopCut.Size = (new global::System.Drawing.Size(124, 44));
            this.btStopCut.TabIndex = (53);
            this.btStopCut.Text = ("Stop");
            this.btStopCut.UseVisualStyleBackColor = (true);
            this.btStopCut.Click += (this.btStopCut_Click);
            // 
            // btStartCut
            // 
            this.btStartCut.Location = (new global::System.Drawing.Point(31, 321));
            this.btStartCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStartCut.Name = ("btStartCut");
            this.btStartCut.Size = (new global::System.Drawing.Size(124, 44));
            this.btStartCut.TabIndex = (52);
            this.btStartCut.Text = ("Start");
            this.btStartCut.UseVisualStyleBackColor = (true);
            this.btStartCut.Click += (this.btStartCut_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = (true);
            this.label31.Location = (new global::System.Drawing.Point(136, 146));
            this.label31.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label31.Name = ("label31");
            this.label31.Size = (new global::System.Drawing.Size(312, 25));
            this.label31.TabIndex = (51);
            this.label31.Text = ("Specify time before adding source file");
            // 
            // btAddInputFile2
            // 
            this.btAddInputFile2.Location = (new global::System.Drawing.Point(616, 21));
            this.btAddInputFile2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAddInputFile2.Name = ("btAddInputFile2");
            this.btAddInputFile2.Size = (new global::System.Drawing.Size(40, 44));
            this.btAddInputFile2.TabIndex = (50);
            this.btAddInputFile2.Text = ("...");
            this.btAddInputFile2.UseVisualStyleBackColor = (true);
            this.btAddInputFile2.Click += (this.btAddInputFile2_Click);
            // 
            // edSourceFileToCut
            // 
            this.edSourceFileToCut.Location = (new global::System.Drawing.Point(140, 25));
            this.edSourceFileToCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edSourceFileToCut.Name = ("edSourceFileToCut");
            this.edSourceFileToCut.Size = (new global::System.Drawing.Size(462, 31));
            this.edSourceFileToCut.TabIndex = (49);
            // 
            // label30
            // 
            this.label30.AutoSize = (true);
            this.label30.Location = (new global::System.Drawing.Point(30, 31));
            this.label30.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label30.Name = ("label30");
            this.label30.Size = (new global::System.Drawing.Size(94, 25));
            this.label30.TabIndex = (48);
            this.label30.Text = ("Source file");
            // 
            // label26
            // 
            this.label26.AutoSize = (true);
            this.label26.Location = (new global::System.Drawing.Point(487, 94));
            this.label26.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label26.Name = ("label26");
            this.label26.Size = (new global::System.Drawing.Size(36, 25));
            this.label26.TabIndex = (47);
            this.label26.Text = ("ms");
            // 
            // edStopTimeCut
            // 
            this.edStopTimeCut.Location = (new global::System.Drawing.Point(400, 90));
            this.edStopTimeCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edStopTimeCut.Name = ("edStopTimeCut");
            this.edStopTimeCut.Size = (new global::System.Drawing.Size(74, 31));
            this.edStopTimeCut.TabIndex = (46);
            this.edStopTimeCut.Text = ("5000");
            // 
            // label27
            // 
            this.label27.AutoSize = (true);
            this.label27.Location = (new global::System.Drawing.Point(304, 96));
            this.label27.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label27.Name = ("label27");
            this.label27.Size = (new global::System.Drawing.Size(89, 25));
            this.label27.TabIndex = (45);
            this.label27.Text = ("Stop time");
            // 
            // label28
            // 
            this.label28.AutoSize = (true);
            this.label28.Location = (new global::System.Drawing.Point(227, 96));
            this.label28.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label28.Name = ("label28");
            this.label28.Size = (new global::System.Drawing.Size(36, 25));
            this.label28.TabIndex = (44);
            this.label28.Text = ("ms");
            // 
            // edStartTimeCut
            // 
            this.edStartTimeCut.Location = (new global::System.Drawing.Point(140, 90));
            this.edStartTimeCut.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edStartTimeCut.Name = ("edStartTimeCut");
            this.edStartTimeCut.Size = (new global::System.Drawing.Size(74, 31));
            this.edStartTimeCut.TabIndex = (43);
            this.edStartTimeCut.Text = ("0");
            // 
            // label29
            // 
            this.label29.AutoSize = (true);
            this.label29.Location = (new global::System.Drawing.Point(30, 96));
            this.label29.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label29.Name = ("label29");
            this.label29.Size = (new global::System.Drawing.Size(88, 25));
            this.label29.TabIndex = (42);
            this.label29.Text = ("Start time");
            // 
            // tabPage54
            // 
            this.tabPage54.Controls.Add(this.label1);
            this.tabPage54.Controls.Add(this.btSelectOutputJoin);
            this.tabPage54.Controls.Add(this.edOutputFileJoin);
            this.tabPage54.Controls.Add(this.label132);
            this.tabPage54.Controls.Add(this.btStopJoin);
            this.tabPage54.Controls.Add(this.btStartJoin);
            this.tabPage54.Controls.Add(this.btClearList3);
            this.tabPage54.Controls.Add(this.btAddInputFile3);
            this.tabPage54.Controls.Add(this.lbFiles2);
            this.tabPage54.Controls.Add(this.label32);
            this.tabPage54.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage54.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage54.Name = ("tabPage54");
            this.tabPage54.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage54.Size = (new global::System.Drawing.Size(721, 547));
            this.tabPage54.TabIndex = (2);
            this.tabPage54.Text = ("Join files (w/o reencoding)");
            this.tabPage54.UseVisualStyleBackColor = (true);
            // 
            // label1
            // 
            this.label1.AutoSize = (true);
            this.label1.Location = (new global::System.Drawing.Point(30, 386));
            this.label1.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label1.Name = ("label1");
            this.label1.Size = (new global::System.Drawing.Size(560, 25));
            this.label1.TabIndex = (63);
            this.label1.Text = ("Source files should have identical video and audio stream parameters");
            // 
            // btSelectOutputJoin
            // 
            this.btSelectOutputJoin.Location = (new global::System.Drawing.Point(613, 202));
            this.btSelectOutputJoin.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btSelectOutputJoin.Name = ("btSelectOutputJoin");
            this.btSelectOutputJoin.Size = (new global::System.Drawing.Size(40, 44));
            this.btSelectOutputJoin.TabIndex = (62);
            this.btSelectOutputJoin.Text = ("...");
            this.btSelectOutputJoin.UseVisualStyleBackColor = (true);
            this.btSelectOutputJoin.Click += (this.btSelectOutputJoin_Click);
            // 
            // edOutputFileJoin
            // 
            this.edOutputFileJoin.Location = (new global::System.Drawing.Point(150, 206));
            this.edOutputFileJoin.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edOutputFileJoin.Name = ("edOutputFileJoin");
            this.edOutputFileJoin.Size = (new global::System.Drawing.Size(451, 31));
            this.edOutputFileJoin.TabIndex = (61);
            this.edOutputFileJoin.Text = ("c:\\vf\\video_edit_output.avi");
            // 
            // label132
            // 
            this.label132.AutoSize = (true);
            this.label132.Location = (new global::System.Drawing.Point(30, 211));
            this.label132.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label132.Name = ("label132");
            this.label132.Size = (new global::System.Drawing.Size(97, 25));
            this.label132.TabIndex = (60);
            this.label132.Text = ("Output file");
            // 
            // btStopJoin
            // 
            this.btStopJoin.Location = (new global::System.Drawing.Point(170, 294));
            this.btStopJoin.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStopJoin.Name = ("btStopJoin");
            this.btStopJoin.Size = (new global::System.Drawing.Size(124, 44));
            this.btStopJoin.TabIndex = (59);
            this.btStopJoin.Text = ("Stop");
            this.btStopJoin.UseVisualStyleBackColor = (true);
            this.btStopJoin.Click += (this.btStopJoin_Click);
            // 
            // btStartJoin
            // 
            this.btStartJoin.Location = (new global::System.Drawing.Point(36, 294));
            this.btStartJoin.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStartJoin.Name = ("btStartJoin");
            this.btStartJoin.Size = (new global::System.Drawing.Size(124, 44));
            this.btStartJoin.TabIndex = (58);
            this.btStartJoin.Text = ("Start");
            this.btStartJoin.UseVisualStyleBackColor = (true);
            this.btStartJoin.Click += (this.btStartJoin_Click);
            // 
            // btClearList3
            // 
            this.btClearList3.Location = (new global::System.Drawing.Point(547, 118));
            this.btClearList3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btClearList3.Name = ("btClearList3");
            this.btClearList3.Size = (new global::System.Drawing.Size(107, 44));
            this.btClearList3.TabIndex = (57);
            this.btClearList3.Text = ("Clear");
            this.btClearList3.UseVisualStyleBackColor = (true);
            this.btClearList3.Click += (this.btClearList3_Click);
            // 
            // btAddInputFile3
            // 
            this.btAddInputFile3.Location = (new global::System.Drawing.Point(547, 61));
            this.btAddInputFile3.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btAddInputFile3.Name = ("btAddInputFile3");
            this.btAddInputFile3.Size = (new global::System.Drawing.Size(107, 44));
            this.btAddInputFile3.TabIndex = (56);
            this.btAddInputFile3.Text = ("Add");
            this.btAddInputFile3.UseVisualStyleBackColor = (true);
            this.btAddInputFile3.Click += (this.btAddInputFile3_Click);
            // 
            // lbFiles2
            // 
            this.lbFiles2.FormattingEnabled = (true);
            this.lbFiles2.ItemHeight = (25);
            this.lbFiles2.Location = (new global::System.Drawing.Point(36, 61));
            this.lbFiles2.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbFiles2.Name = ("lbFiles2");
            this.lbFiles2.Size = (new global::System.Drawing.Size(500, 104));
            this.lbFiles2.TabIndex = (55);
            // 
            // label32
            // 
            this.label32.AutoSize = (true);
            this.label32.Location = (new global::System.Drawing.Point(30, 31));
            this.label32.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label32.Name = ("label32");
            this.label32.Size = (new global::System.Drawing.Size(90, 25));
            this.label32.TabIndex = (54);
            this.label32.Text = ("Input files");
            // 
            // tabPage74
            // 
            this.tabPage74.Controls.Add(this.label168);
            this.tabPage74.Controls.Add(this.cbMuxStreamsShortest);
            this.tabPage74.Controls.Add(this.cbMuxStreamsType);
            this.tabPage74.Controls.Add(this.btMuxStreamsSelectFile);
            this.tabPage74.Controls.Add(this.edMuxStreamsSourceFile);
            this.tabPage74.Controls.Add(this.label167);
            this.tabPage74.Controls.Add(this.btMuxStreamsSelectOutput);
            this.tabPage74.Controls.Add(this.edMuxStreamsOutputFile);
            this.tabPage74.Controls.Add(this.label165);
            this.tabPage74.Controls.Add(this.btStopMux);
            this.tabPage74.Controls.Add(this.btStartMux);
            this.tabPage74.Controls.Add(this.btMuxStreamsClear);
            this.tabPage74.Controls.Add(this.btMuxStreamsAdd);
            this.tabPage74.Controls.Add(this.lbMuxStreamsList);
            this.tabPage74.Controls.Add(this.label166);
            this.tabPage74.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage74.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage74.Name = ("tabPage74");
            this.tabPage74.Padding = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.tabPage74.Size = (new global::System.Drawing.Size(721, 547));
            this.tabPage74.TabIndex = (3);
            this.tabPage74.Text = ("Mux streams (w/o reencoding)");
            this.tabPage74.UseVisualStyleBackColor = (true);
            // 
            // label168
            // 
            this.label168.AutoSize = (true);
            this.label168.Location = (new global::System.Drawing.Point(457, 22));
            this.label168.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label168.Name = ("label168");
            this.label168.Size = (new global::System.Drawing.Size(118, 25));
            this.label168.TabIndex = (77);
            this.label168.Text = ("Type or index");
            // 
            // cbMuxStreamsShortest
            // 
            this.cbMuxStreamsShortest.AutoSize = (true);
            this.cbMuxStreamsShortest.Location = (new global::System.Drawing.Point(36, 269));
            this.cbMuxStreamsShortest.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMuxStreamsShortest.Name = ("cbMuxStreamsShortest");
            this.cbMuxStreamsShortest.Size = (new global::System.Drawing.Size(313, 29));
            this.cbMuxStreamsShortest.TabIndex = (76);
            this.cbMuxStreamsShortest.Text = ("Set file duration to shortest stream");
            this.cbMuxStreamsShortest.UseVisualStyleBackColor = (true);
            // 
            // cbMuxStreamsType
            // 
            this.cbMuxStreamsType.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbMuxStreamsType.FormattingEnabled = (true);
            this.cbMuxStreamsType.Items.AddRange(new global::System.Object[] { "Video", "Audio", "Subtitle", "0", "1", "2", "3", "4", "5", "6", "7" });
            this.cbMuxStreamsType.Location = (new global::System.Drawing.Point(462, 52));
            this.cbMuxStreamsType.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMuxStreamsType.Name = ("cbMuxStreamsType");
            this.cbMuxStreamsType.Size = (new global::System.Drawing.Size(124, 33));
            this.cbMuxStreamsType.TabIndex = (75);
            // 
            // btMuxStreamsSelectFile
            // 
            this.btMuxStreamsSelectFile.Location = (new global::System.Drawing.Point(413, 50));
            this.btMuxStreamsSelectFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btMuxStreamsSelectFile.Name = ("btMuxStreamsSelectFile");
            this.btMuxStreamsSelectFile.Size = (new global::System.Drawing.Size(38, 44));
            this.btMuxStreamsSelectFile.TabIndex = (74);
            this.btMuxStreamsSelectFile.Text = ("...");
            this.btMuxStreamsSelectFile.UseVisualStyleBackColor = (true);
            this.btMuxStreamsSelectFile.Click += (this.btMuxStreamsSelectFile_Click);
            // 
            // edMuxStreamsSourceFile
            // 
            this.edMuxStreamsSourceFile.Location = (new global::System.Drawing.Point(36, 54));
            this.edMuxStreamsSourceFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMuxStreamsSourceFile.Name = ("edMuxStreamsSourceFile");
            this.edMuxStreamsSourceFile.Size = (new global::System.Drawing.Size(366, 31));
            this.edMuxStreamsSourceFile.TabIndex = (73);
            // 
            // label167
            // 
            this.label167.AutoSize = (true);
            this.label167.Location = (new global::System.Drawing.Point(30, 22));
            this.label167.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label167.Name = ("label167");
            this.label167.Size = (new global::System.Drawing.Size(94, 25));
            this.label167.TabIndex = (72);
            this.label167.Text = ("Source file");
            // 
            // btMuxStreamsSelectOutput
            // 
            this.btMuxStreamsSelectOutput.Location = (new global::System.Drawing.Point(644, 346));
            this.btMuxStreamsSelectOutput.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btMuxStreamsSelectOutput.Name = ("btMuxStreamsSelectOutput");
            this.btMuxStreamsSelectOutput.Size = (new global::System.Drawing.Size(40, 44));
            this.btMuxStreamsSelectOutput.TabIndex = (71);
            this.btMuxStreamsSelectOutput.Text = ("...");
            this.btMuxStreamsSelectOutput.UseVisualStyleBackColor = (true);
            this.btMuxStreamsSelectOutput.Click += (this.btMuxStreamsSelectOutput_Click);
            // 
            // edMuxStreamsOutputFile
            // 
            this.edMuxStreamsOutputFile.Location = (new global::System.Drawing.Point(150, 350));
            this.edMuxStreamsOutputFile.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.edMuxStreamsOutputFile.Name = ("edMuxStreamsOutputFile");
            this.edMuxStreamsOutputFile.Size = (new global::System.Drawing.Size(482, 31));
            this.edMuxStreamsOutputFile.TabIndex = (70);
            this.edMuxStreamsOutputFile.Text = ("c:\\vf\\video_edit_output.avi");
            // 
            // label165
            // 
            this.label165.AutoSize = (true);
            this.label165.Location = (new global::System.Drawing.Point(30, 356));
            this.label165.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label165.Name = ("label165");
            this.label165.Size = (new global::System.Drawing.Size(97, 25));
            this.label165.TabIndex = (69);
            this.label165.Text = ("Output file");
            // 
            // btStopMux
            // 
            this.btStopMux.Location = (new global::System.Drawing.Point(170, 439));
            this.btStopMux.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStopMux.Name = ("btStopMux");
            this.btStopMux.Size = (new global::System.Drawing.Size(124, 44));
            this.btStopMux.TabIndex = (68);
            this.btStopMux.Text = ("Stop");
            this.btStopMux.UseVisualStyleBackColor = (true);
            this.btStopMux.Click += (this.btStopMux_Click);
            // 
            // btStartMux
            // 
            this.btStartMux.Location = (new global::System.Drawing.Point(36, 439));
            this.btStartMux.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btStartMux.Name = ("btStartMux");
            this.btStartMux.Size = (new global::System.Drawing.Size(124, 44));
            this.btStartMux.TabIndex = (67);
            this.btStartMux.Text = ("Start");
            this.btStartMux.UseVisualStyleBackColor = (true);
            this.btStartMux.Click += (this.btStartMux_Click);
            // 
            // btMuxStreamsClear
            // 
            this.btMuxStreamsClear.Location = (new global::System.Drawing.Point(578, 269));
            this.btMuxStreamsClear.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btMuxStreamsClear.Name = ("btMuxStreamsClear");
            this.btMuxStreamsClear.Size = (new global::System.Drawing.Size(107, 44));
            this.btMuxStreamsClear.TabIndex = (66);
            this.btMuxStreamsClear.Text = ("Clear");
            this.btMuxStreamsClear.UseVisualStyleBackColor = (true);
            this.btMuxStreamsClear.Click += (this.btMuxStreamsClear_Click);
            // 
            // btMuxStreamsAdd
            // 
            this.btMuxStreamsAdd.Location = (new global::System.Drawing.Point(598, 50));
            this.btMuxStreamsAdd.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.btMuxStreamsAdd.Name = ("btMuxStreamsAdd");
            this.btMuxStreamsAdd.Size = (new global::System.Drawing.Size(87, 44));
            this.btMuxStreamsAdd.TabIndex = (65);
            this.btMuxStreamsAdd.Text = ("Add");
            this.btMuxStreamsAdd.UseVisualStyleBackColor = (true);
            this.btMuxStreamsAdd.Click += (this.btMuxStreamsAdd_Click);
            // 
            // lbMuxStreamsList
            // 
            this.lbMuxStreamsList.FormattingEnabled = (true);
            this.lbMuxStreamsList.ItemHeight = (25);
            this.lbMuxStreamsList.Location = (new global::System.Drawing.Point(36, 146));
            this.lbMuxStreamsList.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.lbMuxStreamsList.Name = ("lbMuxStreamsList");
            this.lbMuxStreamsList.Size = (new global::System.Drawing.Size(647, 104));
            this.lbMuxStreamsList.TabIndex = (64);
            // 
            // label166
            // 
            this.label166.AutoSize = (true);
            this.label166.Location = (new global::System.Drawing.Point(30, 115));
            this.label166.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label166.Name = ("label166");
            this.label166.Size = (new global::System.Drawing.Size(121, 25));
            this.label166.TabIndex = (63);
            this.label166.Text = ("Input streams");
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbMode.FormattingEnabled = (true);
            this.cbMode.Items.AddRange(new global::System.Object[] { "Convert", "Preview" });
            this.cbMode.Location = (new global::System.Drawing.Point(89, 1039));
            this.cbMode.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbMode.Name = ("cbMode");
            this.cbMode.Size = (new global::System.Drawing.Size(306, 33));
            this.cbMode.TabIndex = (81);
            // 
            // label130
            // 
            this.label130.AutoSize = (true);
            this.label130.Location = (new global::System.Drawing.Point(16, 1044));
            this.label130.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label130.Name = ("label130");
            this.label130.Size = (new global::System.Drawing.Size(59, 25));
            this.label130.TabIndex = (82);
            this.label130.Text = ("Mode");
            // 
            // openFileDialogSubtitles
            // 
            this.openFileDialogSubtitles.FileName = ("openFileDialog4");
            this.openFileDialogSubtitles.Filter = ("Subtitle files|*.srt;*.ssa;*.ass;*.sub|All files|*.*");
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = (true);
            this.cbTelemetry.Checked = (true);
            this.cbTelemetry.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbTelemetry.Location = (new global::System.Drawing.Point(256, 1102));
            this.cbTelemetry.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbTelemetry.Name = ("cbTelemetry");
            this.cbTelemetry.Size = (new global::System.Drawing.Size(113, 29));
            this.cbTelemetry.TabIndex = (86);
            this.cbTelemetry.Text = ("Telemetry");
            this.cbTelemetry.UseVisualStyleBackColor = (true);
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = (true);
            this.cbLicensing.Location = (new global::System.Drawing.Point(127, 1102));
            this.cbLicensing.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbLicensing.Name = ("cbLicensing");
            this.cbLicensing.Size = (new global::System.Drawing.Size(110, 29));
            this.cbLicensing.TabIndex = (85);
            this.cbLicensing.Text = ("Licensing");
            this.cbLicensing.UseVisualStyleBackColor = (true);
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = (true);
            this.cbDebugMode.Location = (new global::System.Drawing.Point(20, 1102));
            this.cbDebugMode.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.cbDebugMode.Name = ("cbDebugMode");
            this.cbDebugMode.Size = (new global::System.Drawing.Size(92, 29));
            this.cbDebugMode.TabIndex = (84);
            this.cbDebugMode.Text = ("Debug");
            this.cbDebugMode.UseVisualStyleBackColor = (true);
            // 
            // mmLog
            // 
            this.mmLog.Location = (new global::System.Drawing.Point(20, 1146));
            this.mmLog.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.mmLog.Multiline = (true);
            this.mmLog.Name = ("mmLog");
            this.mmLog.ScrollBars = (global::System.Windows.Forms.ScrollBars.Vertical);
            this.mmLog.Size = (new global::System.Drawing.Size(507, 83));
            this.mmLog.TabIndex = (83);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = (global::System.Drawing.Color.Black);
            this.VideoView1.Location = (new global::System.Drawing.Point(551, 619));
            this.VideoView1.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.VideoView1.Name = ("VideoView1");
            this.VideoView1.Size = (new global::System.Drawing.Size(720, 556));
            this.VideoView1.StatusOverlay = (null);
            this.VideoView1.TabIndex = (87);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = (new global::System.Drawing.SizeF(10F, 25F));
            this.AutoScaleMode = (global::System.Windows.Forms.AutoScaleMode.Font);
            this.ClientSize = (new global::System.Drawing.Size(1289, 1256));
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbSeeking);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.cbTelemetry);
            this.Controls.Add(this.cbLicensing);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.label130);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((global::System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = (new global::System.Windows.Forms.Padding(4, 6, 4, 6));
            this.Name = ("Form1");
            this.Text = ("VisioForge Video Edit SDK .Net - Main Demo");
            this.FormClosing += (this.Form1_FormClosing);
            this.Load += (this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.tabPage30.PerformLayout();
            this.tabPage48.ResumeLayout(false);
            this.tabPage48.PerformLayout();
            this.tabPage31.ResumeLayout(false);
            this.tabControl17.ResumeLayout(false);
            this.tabPage68.ResumeLayout(false);
            this.tabPage68.PerformLayout();
            this.tabControl7.ResumeLayout(false);
            this.tabPage29.ResumeLayout(false);
            this.tabPage42.ResumeLayout(false);
            this.tabPage22.ResumeLayout(false);
            this.tabPage22.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.tabPage23.ResumeLayout(false);
            this.tabPage23.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.tabPage43.ResumeLayout(false);
            this.tabPage43.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage69.ResumeLayout(false);
            this.tabPage69.PerformLayout();
            this.tabPage59.ResumeLayout(false);
            this.tabPage59.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabControl15.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.tabPage21.PerformLayout();
            this.tabPage26.ResumeLayout(false);
            this.tabPage26.PerformLayout();
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).EndInit();
            this.tabPage70.ResumeLayout(false);
            this.tabPage70.PerformLayout();
            this.tabPage82.ResumeLayout(false);
            this.tabPage82.PerformLayout();
            this.tabPage83.ResumeLayout(false);
            this.tabPage83.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage66.ResumeLayout(false);
            this.tabPage66.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.tabPage81.ResumeLayout(false);
            this.tabPage81.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).EndInit();
            this.tabPage27.ResumeLayout(false);
            this.tabPage27.PerformLayout();
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage25.ResumeLayout(false);
            this.tabPage25.PerformLayout();
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tabPage32.ResumeLayout(false);
            this.tabPage32.PerformLayout();
            this.tabPage49.ResumeLayout(false);
            this.tabPage49.PerformLayout();
            this.tabPage50.ResumeLayout(false);
            this.tabPage50.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage77.ResumeLayout(false);
            this.tabPage77.PerformLayout();
            this.tabPage51.ResumeLayout(false);
            this.tabPage51.PerformLayout();
            this.tabPage33.ResumeLayout(false);
            this.tabPage33.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage34.ResumeLayout(false);
            this.tabPage34.PerformLayout();
            this.tabPage46.ResumeLayout(false);
            this.tabPage46.PerformLayout();
            this.tabPage47.ResumeLayout(false);
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox43.ResumeLayout(false);
            this.groupBox43.PerformLayout();
            this.tabPage79.ResumeLayout(false);
            this.tabPage79.PerformLayout();
            this.TabControl32.ResumeLayout(false);
            this.TabPage142.ResumeLayout(false);
            this.TabPage142.PerformLayout();
            this.TabPage143.ResumeLayout(false);
            this.TabPage143.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgTagCover)).EndInit();
            this.tabPage24.ResumeLayout(false);
            this.tabPage24.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSeeking)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage52.ResumeLayout(false);
            this.tabPage52.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.tabPage53.ResumeLayout(false);
            this.tabPage53.PerformLayout();
            this.tabPage54.ResumeLayout(false);
            this.tabPage54.PerformLayout();
            this.tabPage74.ResumeLayout(false);
            this.tabPage74.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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

