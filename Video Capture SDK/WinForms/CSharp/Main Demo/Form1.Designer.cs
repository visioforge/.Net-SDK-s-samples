using System;

namespace VideoCapture_CSharp_Demo
{
    using VisioForge.Controls.UI.WinForms.VolumeMeterPro;
    using VisioForge.Types;

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

            if (onvifControl != null)
            {
                onvifControl.Dispose();
                onvifControl = null;
            }

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
            this.label8 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btOutputConfigure = new System.Windows.Forms.Button();
            this.cbAutoFilename = new System.Windows.Forms.CheckBox();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbRecordAudio = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl17 = new System.Windows.Forms.TabControl();
            this.tabPage68 = new System.Windows.Forms.TabPage();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.cbDisableAllVideoProcessing = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tabControl7 = new System.Windows.Forms.TabControl();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.cbMergeTextLogos = new System.Windows.Forms.CheckBox();
            this.btTextLogoRemove = new System.Windows.Forms.Button();
            this.btTextLogoEdit = new System.Windows.Forms.Button();
            this.lbTextLogos = new System.Windows.Forms.ListBox();
            this.btTextLogoAdd = new System.Windows.Forms.Button();
            this.tabPage42 = new System.Windows.Forms.TabPage();
            this.cbMergeImageLogos = new System.Windows.Forms.CheckBox();
            this.btImageLogoRemove = new System.Windows.Forms.Button();
            this.btImageLogoEdit = new System.Windows.Forms.Button();
            this.lbImageLogos = new System.Windows.Forms.ListBox();
            this.btImageLogoAdd = new System.Windows.Forms.Button();
            this.tabPage91 = new System.Windows.Forms.TabPage();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.btEffZoomRight = new System.Windows.Forms.Button();
            this.btEffZoomLeft = new System.Windows.Forms.Button();
            this.btEffZoomOut = new System.Windows.Forms.Button();
            this.btEffZoomIn = new System.Windows.Forms.Button();
            this.btEffZoomDown = new System.Windows.Forms.Button();
            this.btEffZoomUp = new System.Windows.Forms.Button();
            this.cbZoom = new System.Windows.Forms.CheckBox();
            this.tabPage92 = new System.Windows.Forms.TabPage();
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
            this.tabPage102 = new System.Windows.Forms.TabPage();
            this.rbFadeOut = new System.Windows.Forms.RadioButton();
            this.rbFadeIn = new System.Windows.Forms.RadioButton();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.edFadeInOutStopTime = new System.Windows.Forms.TextBox();
            this.label329 = new System.Windows.Forms.Label();
            this.edFadeInOutStartTime = new System.Windows.Forms.TextBox();
            this.label330 = new System.Windows.Forms.Label();
            this.cbFadeInOut = new System.Windows.Forms.CheckBox();
            this.tabPage114 = new System.Windows.Forms.TabPage();
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
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label92 = new System.Windows.Forms.Label();
            this.cbRotate = new System.Windows.Forms.ComboBox();
            this.edCropRight = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.edCropBottom = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.edCropLeft = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.edCropTop = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.cbCrop = new System.Windows.Forms.CheckBox();
            this.cbResizeMode = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.cbResizeLetterbox = new System.Windows.Forms.CheckBox();
            this.edResizeHeight = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.edResizeWidth = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.tabPage60 = new System.Windows.Forms.TabPage();
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
            this.tabPage70 = new System.Windows.Forms.TabPage();
            this.btFilterDeleteAll = new System.Windows.Forms.Button();
            this.btFilterSettings2 = new System.Windows.Forms.Button();
            this.lbFilters = new System.Windows.Forms.ListBox();
            this.label106 = new System.Windows.Forms.Label();
            this.btFilterSettings = new System.Windows.Forms.Button();
            this.btFilterAdd = new System.Windows.Forms.Button();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.tabControl14 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage58 = new System.Windows.Forms.TabPage();
            this.tabPage127 = new System.Windows.Forms.TabPage();
            this.lbAudioTimeshift = new System.Windows.Forms.Label();
            this.tbAudioTimeshift = new System.Windows.Forms.TrackBar();
            this.label439 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbAudioOutputGainLFE = new System.Windows.Forms.Label();
            this.tbAudioOutputGainLFE = new System.Windows.Forms.TrackBar();
            this.label440 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainSR = new System.Windows.Forms.Label();
            this.tbAudioOutputGainSR = new System.Windows.Forms.TrackBar();
            this.label441 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainSL = new System.Windows.Forms.Label();
            this.tbAudioOutputGainSL = new System.Windows.Forms.TrackBar();
            this.label442 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainR = new System.Windows.Forms.Label();
            this.tbAudioOutputGainR = new System.Windows.Forms.TrackBar();
            this.label443 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainC = new System.Windows.Forms.Label();
            this.tbAudioOutputGainC = new System.Windows.Forms.TrackBar();
            this.label444 = new System.Windows.Forms.Label();
            this.lbAudioOutputGainL = new System.Windows.Forms.Label();
            this.tbAudioOutputGainL = new System.Windows.Forms.TrackBar();
            this.label445 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbAudioInputGainLFE = new System.Windows.Forms.Label();
            this.tbAudioInputGainLFE = new System.Windows.Forms.TrackBar();
            this.label446 = new System.Windows.Forms.Label();
            this.lbAudioInputGainSR = new System.Windows.Forms.Label();
            this.tbAudioInputGainSR = new System.Windows.Forms.TrackBar();
            this.label447 = new System.Windows.Forms.Label();
            this.lbAudioInputGainSL = new System.Windows.Forms.Label();
            this.tbAudioInputGainSL = new System.Windows.Forms.TrackBar();
            this.label448 = new System.Windows.Forms.Label();
            this.lbAudioInputGainR = new System.Windows.Forms.Label();
            this.tbAudioInputGainR = new System.Windows.Forms.TrackBar();
            this.label449 = new System.Windows.Forms.Label();
            this.lbAudioInputGainC = new System.Windows.Forms.Label();
            this.tbAudioInputGainC = new System.Windows.Forms.TrackBar();
            this.label450 = new System.Windows.Forms.Label();
            this.lbAudioInputGainL = new System.Windows.Forms.Label();
            this.tbAudioInputGainL = new System.Windows.Forms.TrackBar();
            this.label451 = new System.Windows.Forms.Label();
            this.cbAudioAutoGain = new System.Windows.Forms.CheckBox();
            this.cbAudioNormalize = new System.Windows.Forms.CheckBox();
            this.cbAudioEnhancementEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.label250 = new System.Windows.Forms.Label();
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
            this.cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage93 = new System.Windows.Forms.TabPage();
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
            this.tabPage107 = new System.Windows.Forms.TabPage();
            this.edFaceTrackingFaces = new System.Windows.Forms.TextBox();
            this.label364 = new System.Windows.Forms.Label();
            this.label363 = new System.Windows.Forms.Label();
            this.cbFaceTrackingScalingMode = new System.Windows.Forms.ComboBox();
            this.label362 = new System.Windows.Forms.Label();
            this.edFaceTrackingScaleFactor = new System.Windows.Forms.TextBox();
            this.label361 = new System.Windows.Forms.Label();
            this.cbFaceTrackingSearchMode = new System.Windows.Forms.ComboBox();
            this.cbFaceTrackingColorMode = new System.Windows.Forms.ComboBox();
            this.label346 = new System.Windows.Forms.Label();
            this.edFaceTrackingMinimumWindowSize = new System.Windows.Forms.TextBox();
            this.label345 = new System.Windows.Forms.Label();
            this.cbFaceTrackingCHL = new System.Windows.Forms.CheckBox();
            this.cbFaceTrackingEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cbNetworkStreamingMode = new System.Windows.Forms.ComboBox();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tpWMV = new System.Windows.Forms.TabPage();
            this.label48 = new System.Windows.Forms.Label();
            this.edNetworkURL = new System.Windows.Forms.TextBox();
            this.edWMVNetworkPort = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btRefreshClients = new System.Windows.Forms.Button();
            this.lbNetworkClients = new System.Windows.Forms.ListBox();
            this.rbNetworkStreamingUseExternalProfile = new System.Windows.Forms.RadioButton();
            this.rbNetworkStreamingUseMainWMVSettings = new System.Windows.Forms.RadioButton();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.edMaximumClients = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.btSelectWMVProfileNetwork = new System.Windows.Forms.Button();
            this.edNetworkStreamingWMVProfile = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tpRTSP = new System.Windows.Forms.TabPage();
            this.edNetworkRTSPURL = new System.Windows.Forms.TextBox();
            this.label367 = new System.Windows.Forms.Label();
            this.label366 = new System.Windows.Forms.Label();
            this.tpRTMP = new System.Windows.Forms.TabPage();
            this.cbNetworkRTMPFFMPEGUsePipes = new System.Windows.Forms.CheckBox();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.rbNetworkRTMPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            this.rbNetworkRTMPFFMPEG = new System.Windows.Forms.RadioButton();
            this.edNetworkRTMPURL = new System.Windows.Forms.TextBox();
            this.label368 = new System.Windows.Forms.Label();
            this.label369 = new System.Windows.Forms.Label();
            this.tpNDI = new System.Windows.Forms.TabPage();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.label38 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.edNDIURL = new System.Windows.Forms.TextBox();
            this.edNDIName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tpUDP = new System.Windows.Forms.TabPage();
            this.cbNetworkUDPFFMPEGUsePipes = new System.Windows.Forms.CheckBox();
            this.label314 = new System.Windows.Forms.Label();
            this.label313 = new System.Windows.Forms.Label();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.label484 = new System.Windows.Forms.Label();
            this.edNetworkUDPURL = new System.Windows.Forms.TextBox();
            this.label372 = new System.Windows.Forms.Label();
            this.rbNetworkUDPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            this.rbNetworkUDPFFMPEG = new System.Windows.Forms.RadioButton();
            this.tpSSF = new System.Windows.Forms.TabPage();
            this.cbNetworkSSUsePipes = new System.Windows.Forms.CheckBox();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.rbNetworkSSFFMPEGCustom = new System.Windows.Forms.RadioButton();
            this.rbNetworkSSFFMPEGDefault = new System.Windows.Forms.RadioButton();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.edNetworkSSURL = new System.Windows.Forms.TextBox();
            this.label370 = new System.Windows.Forms.Label();
            this.label371 = new System.Windows.Forms.Label();
            this.rbNetworkSSSoftware = new System.Windows.Forms.RadioButton();
            this.tpHLS = new System.Windows.Forms.TabPage();
            this.edHLSURL = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.edHLSEmbeddedHTTPServerPort = new System.Windows.Forms.TextBox();
            this.cbHLSEmbeddedHTTPServerEnabled = new System.Windows.Forms.CheckBox();
            this.cbHLSMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbHLSConfigure = new System.Windows.Forms.LinkLabel();
            this.label532 = new System.Windows.Forms.Label();
            this.label531 = new System.Windows.Forms.Label();
            this.label530 = new System.Windows.Forms.Label();
            this.label529 = new System.Windows.Forms.Label();
            this.edHLSSegmentCount = new System.Windows.Forms.TextBox();
            this.label519 = new System.Windows.Forms.Label();
            this.edHLSSegmentDuration = new System.Windows.Forms.TextBox();
            this.btSelectHLSOutputFolder = new System.Windows.Forms.Button();
            this.edHLSOutputFolder = new System.Windows.Forms.TextBox();
            this.label380 = new System.Windows.Forms.Label();
            this.tpNSExternal = new System.Windows.Forms.TabPage();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.cbNetworkStreamingAudioEnabled = new System.Windows.Forms.CheckBox();
            this.cbNetworkStreaming = new System.Windows.Forms.CheckBox();
            this.tabPage28 = new System.Windows.Forms.TabPage();
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
            this.tabPage43 = new System.Windows.Forms.TabPage();
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
            this.tabPage26 = new System.Windows.Forms.TabPage();
            this.label505 = new System.Windows.Forms.Label();
            this.rbMotionDetectionExProcessor = new System.Windows.Forms.ComboBox();
            this.label389 = new System.Windows.Forms.Label();
            this.rbMotionDetectionExDetector = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            this.cbMotionDetectionEx = new System.Windows.Forms.CheckBox();
            this.tabPage25 = new System.Windows.Forms.TabPage();
            this.edBarcodeMetadata = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.cbBarcodeType = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.btBarcodeReset = new System.Windows.Forms.Button();
            this.edBarcode = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage101 = new System.Windows.Forms.TabPage();
            this.label328 = new System.Windows.Forms.Label();
            this.label327 = new System.Windows.Forms.Label();
            this.label326 = new System.Windows.Forms.Label();
            this.label325 = new System.Windows.Forms.Label();
            this.cbVirtualCamera = new System.Windows.Forms.CheckBox();
            this.tabPage103 = new System.Windows.Forms.TabPage();
            this.cbDecklinkOutputDownConversionAnalogOutput = new System.Windows.Forms.CheckBox();
            this.cbDecklinkOutputDownConversion = new System.Windows.Forms.ComboBox();
            this.label337 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputHDTVPulldown = new System.Windows.Forms.ComboBox();
            this.label336 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputBlackToDeck = new System.Windows.Forms.ComboBox();
            this.label335 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputSingleField = new System.Windows.Forms.ComboBox();
            this.label334 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputComponentLevels = new System.Windows.Forms.ComboBox();
            this.label333 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputNTSC = new System.Windows.Forms.ComboBox();
            this.label332 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputDualLink = new System.Windows.Forms.ComboBox();
            this.label331 = new System.Windows.Forms.Label();
            this.cbDecklinkOutputAnalog = new System.Windows.Forms.ComboBox();
            this.label87 = new System.Windows.Forms.Label();
            this.cbDecklinkDV = new System.Windows.Forms.CheckBox();
            this.cbDecklinkOutput = new System.Windows.Forms.CheckBox();
            this.tabPage141 = new System.Windows.Forms.TabPage();
            this.TabControl32 = new System.Windows.Forms.TabControl();
            this.TabPage142 = new System.Windows.Forms.TabPage();
            this.edTagTrackID = new System.Windows.Forms.TextBox();
            this.Label496 = new System.Windows.Forms.Label();
            this.edTagYear = new System.Windows.Forms.TextBox();
            this.Label495 = new System.Windows.Forms.Label();
            this.edTagComment = new System.Windows.Forms.TextBox();
            this.Label493 = new System.Windows.Forms.Label();
            this.edTagAlbum = new System.Windows.Forms.TextBox();
            this.Label491 = new System.Windows.Forms.Label();
            this.edTagArtists = new System.Windows.Forms.TextBox();
            this.label494 = new System.Windows.Forms.Label();
            this.edTagCopyright = new System.Windows.Forms.TextBox();
            this.label497 = new System.Windows.Forms.Label();
            this.edTagTitle = new System.Windows.Forms.TextBox();
            this.label498 = new System.Windows.Forms.Label();
            this.TabPage143 = new System.Windows.Forms.TabPage();
            this.imgTagCover = new System.Windows.Forms.PictureBox();
            this.Label499 = new System.Windows.Forms.Label();
            this.label500 = new System.Windows.Forms.Label();
            this.edTagLyrics = new System.Windows.Forms.TextBox();
            this.label501 = new System.Windows.Forms.Label();
            this.cbTagGenre = new System.Windows.Forms.ComboBox();
            this.label502 = new System.Windows.Forms.Label();
            this.edTagComposers = new System.Windows.Forms.TextBox();
            this.label503 = new System.Windows.Forms.Label();
            this.cbTagEnabled = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl10 = new System.Windows.Forms.TabControl();
            this.tabPage46 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btSignal = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.btVideoCaptureDeviceSettings = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage52 = new System.Windows.Forms.TabPage();
            this.cbCrossBarAvailable = new System.Windows.Forms.CheckBox();
            this.lbRotes = new System.Windows.Forms.ListBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.cbConnectRelated = new System.Windows.Forms.CheckBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.cbCrossbarVideoInput = new System.Windows.Forms.ComboBox();
            this.label59 = new System.Windows.Forms.Label();
            this.rbCrossbarAdvanced = new System.Windows.Forms.RadioButton();
            this.rbCrossbarSimple = new System.Windows.Forms.RadioButton();
            this.cbCrossbarOutput = new System.Windows.Forms.ComboBox();
            this.cbCrossbarInput = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.cbUseClosedCaptions = new System.Windows.Forms.CheckBox();
            this.edTVDefaultFormat = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cbTVCountry = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cbTVMode = new System.Windows.Forms.ComboBox();
            this.cbTVInput = new System.Windows.Forms.ComboBox();
            this.cbTVTuner = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.edChannel = new System.Windows.Forms.TextBox();
            this.btUseThisChannel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTVChannel = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.pbChannels = new System.Windows.Forms.ProgressBar();
            this.btStopTune = new System.Windows.Forms.Button();
            this.btStartTune = new System.Windows.Forms.Button();
            this.cbTVSystem = new System.Windows.Forms.ComboBox();
            this.edAudioFreq = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.edVideoFreq = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.btMPEGEncoderShowDialog = new System.Windows.Forms.Button();
            this.cbMPEGEncoder = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.rbDVResDC = new System.Windows.Forms.RadioButton();
            this.rbDVResQuarter = new System.Windows.Forms.RadioButton();
            this.rbDVResHalf = new System.Windows.Forms.RadioButton();
            this.rbDVResFull = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btDVStepFWD = new System.Windows.Forms.Button();
            this.btDVStepRev = new System.Windows.Forms.Button();
            this.btDVFF = new System.Windows.Forms.Button();
            this.btDVStop = new System.Windows.Forms.Button();
            this.btDVPause = new System.Windows.Forms.Button();
            this.btDVPlay = new System.Windows.Forms.Button();
            this.btDVRewind = new System.Windows.Forms.Button();
            this.tabPage57 = new System.Windows.Forms.TabPage();
            this.lbAdjSaturationCurrent = new System.Windows.Forms.Label();
            this.lbAdjSaturationMax = new System.Windows.Forms.Label();
            this.cbAdjSaturationAuto = new System.Windows.Forms.CheckBox();
            this.lbAdjSaturationMin = new System.Windows.Forms.Label();
            this.tbAdjSaturation = new System.Windows.Forms.TrackBar();
            this.label45 = new System.Windows.Forms.Label();
            this.lbAdjHueCurrent = new System.Windows.Forms.Label();
            this.lbAdjHueMax = new System.Windows.Forms.Label();
            this.cbAdjHueAuto = new System.Windows.Forms.CheckBox();
            this.lbAdjHueMin = new System.Windows.Forms.Label();
            this.tbAdjHue = new System.Windows.Forms.TrackBar();
            this.label41 = new System.Windows.Forms.Label();
            this.lbAdjContrastCurrent = new System.Windows.Forms.Label();
            this.lbAdjContrastMax = new System.Windows.Forms.Label();
            this.cbAdjContrastAuto = new System.Windows.Forms.CheckBox();
            this.lbAdjContrastMin = new System.Windows.Forms.Label();
            this.tbAdjContrast = new System.Windows.Forms.TrackBar();
            this.label23 = new System.Windows.Forms.Label();
            this.lbAdjBrightnessCurrent = new System.Windows.Forms.Label();
            this.lbAdjBrightnessMax = new System.Windows.Forms.Label();
            this.cbAdjBrightnessAuto = new System.Windows.Forms.CheckBox();
            this.lbAdjBrightnessMin = new System.Windows.Forms.Label();
            this.tbAdjBrightness = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage66 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btCCFocusApply = new System.Windows.Forms.Button();
            this.btCCZoomApply = new System.Windows.Forms.Button();
            this.cbCCFocusRelative = new System.Windows.Forms.CheckBox();
            this.cbCCFocusManual = new System.Windows.Forms.CheckBox();
            this.cbCCFocusAuto = new System.Windows.Forms.CheckBox();
            this.lbCCFocusCurrent = new System.Windows.Forms.Label();
            this.lbCCFocusMax = new System.Windows.Forms.Label();
            this.lbCCFocusMin = new System.Windows.Forms.Label();
            this.tbCCFocus = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCCZoomRelative = new System.Windows.Forms.CheckBox();
            this.cbCCZoomManual = new System.Windows.Forms.CheckBox();
            this.cbCCZoomAuto = new System.Windows.Forms.CheckBox();
            this.lbCCZoomCurrent = new System.Windows.Forms.Label();
            this.lbCCZoomMax = new System.Windows.Forms.Label();
            this.lbCCZoomMin = new System.Windows.Forms.Label();
            this.tbCCZoom = new System.Windows.Forms.TrackBar();
            this.label20 = new System.Windows.Forms.Label();
            this.btCCTiltApply = new System.Windows.Forms.Button();
            this.btCCPanApply = new System.Windows.Forms.Button();
            this.cbCCTiltRelative = new System.Windows.Forms.CheckBox();
            this.cbCCTiltManual = new System.Windows.Forms.CheckBox();
            this.cbCCTiltAuto = new System.Windows.Forms.CheckBox();
            this.lbCCTiltCurrent = new System.Windows.Forms.Label();
            this.lbCCTiltMax = new System.Windows.Forms.Label();
            this.lbCCTiltMin = new System.Windows.Forms.Label();
            this.tbCCTilt = new System.Windows.Forms.TrackBar();
            this.label97 = new System.Windows.Forms.Label();
            this.cbCCPanRelative = new System.Windows.Forms.CheckBox();
            this.cbCCPanManual = new System.Windows.Forms.CheckBox();
            this.cbCCPanAuto = new System.Windows.Forms.CheckBox();
            this.btCCReadValues = new System.Windows.Forms.Button();
            this.lbCCPanCurrent = new System.Windows.Forms.Label();
            this.lbCCPanMax = new System.Windows.Forms.Label();
            this.lbCCPanMin = new System.Windows.Forms.Label();
            this.tbCCPan = new System.Windows.Forms.TrackBar();
            this.label96 = new System.Windows.Forms.Label();
            this.tabPage63 = new System.Windows.Forms.TabPage();
            this.tabControl19 = new System.Windows.Forms.TabControl();
            this.tabPage96 = new System.Windows.Forms.TabPage();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.cbUseAudioInputFromVideoCaptureDevice = new System.Windows.Forms.CheckBox();
            this.btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage97 = new System.Windows.Forms.TabPage();
            this.label55 = new System.Windows.Forms.Label();
            this.tbAudioBalance = new System.Windows.Forms.TrackBar();
            this.label54 = new System.Windows.Forms.Label();
            this.tbAudioVolume = new System.Windows.Forms.TrackBar();
            this.cbPlayAudio = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage98 = new System.Windows.Forms.TabPage();
            this.cbVUMeter = new System.Windows.Forms.CheckBox();
            this.peakMeterCtrl1 = new VisioForge.Controls.UI.WinForms.PeakMeterCtrl();
            this.tabPage112 = new System.Windows.Forms.TabPage();
            this.tbVUMeterBoost = new System.Windows.Forms.TrackBar();
            this.label382 = new System.Windows.Forms.Label();
            this.label381 = new System.Windows.Forms.Label();
            this.tbVUMeterAmplification = new System.Windows.Forms.TrackBar();
            this.cbVUMeterPro = new System.Windows.Forms.CheckBox();
            this.waveformPainter2 = new VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter();
            this.waveformPainter1 = new VisioForge.Controls.UI.WinForms.VolumeMeterPro.WaveformPainter();
            this.volumeMeter2 = new VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.volumeMeter1 = new VisioForge.Controls.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.tabPage99 = new System.Windows.Forms.TabPage();
            this.rbAddAudioStreamsIndependent = new System.Windows.Forms.RadioButton();
            this.rbAddAudioStreamsMix = new System.Windows.Forms.RadioButton();
            this.label319 = new System.Windows.Forms.Label();
            this.label318 = new System.Windows.Forms.Label();
            this.btAddAdditionalAudioSource = new System.Windows.Forms.Button();
            this.cbAdditionalAudioSource = new System.Windows.Forms.ComboBox();
            this.label180 = new System.Windows.Forms.Label();
            this.tabPage47 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbScreenSourceWindowText = new System.Windows.Forms.Label();
            this.btScreenSourceWindowSelect = new System.Windows.Forms.Button();
            this.cbScreenCapture_DesktopDuplication = new System.Windows.Forms.CheckBox();
            this.rbScreenCaptureColorSource = new System.Windows.Forms.RadioButton();
            this.rbScreenCaptureWindow = new System.Windows.Forms.RadioButton();
            this.cbScreenCaptureDisplayIndex = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.btScreenCaptureUpdate = new System.Windows.Forms.Button();
            this.cbScreenCapture_GrabMouseCursor = new System.Windows.Forms.CheckBox();
            this.label79 = new System.Windows.Forms.Label();
            this.edScreenFrameRate = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.edScreenBottom = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.edScreenRight = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.edScreenTop = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.edScreenLeft = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.rbScreenCustomArea = new System.Windows.Forms.RadioButton();
            this.rbScreenFullScreen = new System.Windows.Forms.RadioButton();
            this.tabPage48 = new System.Windows.Forms.TabPage();
            this.tabControl15 = new System.Windows.Forms.TabControl();
            this.tabPage144 = new System.Windows.Forms.TabPage();
            this.btListONVIFSources = new System.Windows.Forms.Button();
            this.cbIPURL = new System.Windows.Forms.ComboBox();
            this.btListNDISources = new System.Windows.Forms.Button();
            this.lbNDI = new System.Windows.Forms.LinkLabel();
            this.label25 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label22 = new System.Windows.Forms.Label();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.label165 = new System.Windows.Forms.Label();
            this.cbIPCameraONVIF = new System.Windows.Forms.CheckBox();
            this.btShowIPCamDatabase = new System.Windows.Forms.Button();
            this.cbIPDisconnect = new System.Windows.Forms.CheckBox();
            this.edIPForcedFramerateID = new System.Windows.Forms.TextBox();
            this.label344 = new System.Windows.Forms.Label();
            this.edIPForcedFramerate = new System.Windows.Forms.TextBox();
            this.label295 = new System.Windows.Forms.Label();
            this.cbIPCameraType = new System.Windows.Forms.ComboBox();
            this.edIPPassword = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.edIPLogin = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.cbIPAudioCapture = new System.Windows.Forms.CheckBox();
            this.label168 = new System.Windows.Forms.Label();
            this.tabPage146 = new System.Windows.Forms.TabPage();
            this.btVLCAddParameter = new System.Windows.Forms.Button();
            this.btVLCClearParameters = new System.Windows.Forms.Button();
            this.edVLCParameter = new System.Windows.Forms.TextBox();
            this.lbVLCParameters = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVLCZeroClockJitter = new System.Windows.Forms.CheckBox();
            this.edVLCCacheSize = new System.Windows.Forms.TextBox();
            this.label312 = new System.Windows.Forms.Label();
            this.tabPage145 = new System.Windows.Forms.TabPage();
            this.edONVIFPassword = new System.Windows.Forms.TextBox();
            this.label378 = new System.Windows.Forms.Label();
            this.edONVIFLogin = new System.Windows.Forms.TextBox();
            this.label379 = new System.Windows.Forms.Label();
            this.edONVIFURL = new System.Windows.Forms.TextBox();
            this.edONVIFLiveVideoURL = new System.Windows.Forms.TextBox();
            this.label513 = new System.Windows.Forms.Label();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.btONVIFPTZSetDefault = new System.Windows.Forms.Button();
            this.btONVIFRight = new System.Windows.Forms.Button();
            this.btONVIFLeft = new System.Windows.Forms.Button();
            this.btONVIFZoomOut = new System.Windows.Forms.Button();
            this.btONVIFZoomIn = new System.Windows.Forms.Button();
            this.btONVIFDown = new System.Windows.Forms.Button();
            this.btONVIFUp = new System.Windows.Forms.Button();
            this.cbONVIFProfile = new System.Windows.Forms.ComboBox();
            this.label510 = new System.Windows.Forms.Label();
            this.lbONVIFCameraInfo = new System.Windows.Forms.Label();
            this.btONVIFConnect = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDecklinkCaptureVideoFormat = new System.Windows.Forms.ComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.cbDecklinkCaptureDevice = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cbDecklinkSourceTimecode = new System.Windows.Forms.ComboBox();
            this.label341 = new System.Windows.Forms.Label();
            this.cbDecklinkSourceComponentLevels = new System.Windows.Forms.ComboBox();
            this.label339 = new System.Windows.Forms.Label();
            this.cbDecklinkSourceNTSC = new System.Windows.Forms.ComboBox();
            this.label340 = new System.Windows.Forms.Label();
            this.cbDecklinkSourceInput = new System.Windows.Forms.ComboBox();
            this.label338 = new System.Windows.Forms.Label();
            this.tabPage81 = new System.Windows.Forms.TabPage();
            this.tabControl22 = new System.Windows.Forms.TabControl();
            this.tabPage82 = new System.Windows.Forms.TabPage();
            this.cbBDADeviceStandard = new System.Windows.Forms.ComboBox();
            this.label129 = new System.Windows.Forms.Label();
            this.cbBDAReceiver = new System.Windows.Forms.ComboBox();
            this.label270 = new System.Windows.Forms.Label();
            this.cbBDASourceDevice = new System.Windows.Forms.ComboBox();
            this.label272 = new System.Windows.Forms.Label();
            this.tabPage83 = new System.Windows.Forms.TabPage();
            this.tabControl23 = new System.Windows.Forms.TabControl();
            this.tabPage84 = new System.Windows.Forms.TabPage();
            this.btDVBTTune = new System.Windows.Forms.Button();
            this.edDVBTSID = new System.Windows.Forms.TextBox();
            this.edDVBTTSID = new System.Windows.Forms.TextBox();
            this.edDVBTONID = new System.Windows.Forms.TextBox();
            this.label273 = new System.Windows.Forms.Label();
            this.edDVBTFrequency = new System.Windows.Forms.TextBox();
            this.label274 = new System.Windows.Forms.Label();
            this.label275 = new System.Windows.Forms.Label();
            this.label276 = new System.Windows.Forms.Label();
            this.label277 = new System.Windows.Forms.Label();
            this.tabPage85 = new System.Windows.Forms.TabPage();
            this.cbDVBSPolarisation = new System.Windows.Forms.ComboBox();
            this.label278 = new System.Windows.Forms.Label();
            this.edDVBSSymbolRate = new System.Windows.Forms.TextBox();
            this.label279 = new System.Windows.Forms.Label();
            this.btDVBSTune = new System.Windows.Forms.Button();
            this.edDVBSSID = new System.Windows.Forms.TextBox();
            this.edDVBSTSID = new System.Windows.Forms.TextBox();
            this.edDVBSONIT = new System.Windows.Forms.TextBox();
            this.label280 = new System.Windows.Forms.Label();
            this.edDVBSFrequency = new System.Windows.Forms.TextBox();
            this.label281 = new System.Windows.Forms.Label();
            this.label282 = new System.Windows.Forms.Label();
            this.label283 = new System.Windows.Forms.Label();
            this.label284 = new System.Windows.Forms.Label();
            this.tabPage86 = new System.Windows.Forms.TabPage();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.edDVBCMinorChannel = new System.Windows.Forms.TextBox();
            this.label285 = new System.Windows.Forms.Label();
            this.edDVBCPhysicalChannel = new System.Windows.Forms.TextBox();
            this.label286 = new System.Windows.Forms.Label();
            this.edDVBCVirtualChannel = new System.Windows.Forms.TextBox();
            this.label287 = new System.Windows.Forms.Label();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.edDVBCSymbolRate = new System.Windows.Forms.TextBox();
            this.label288 = new System.Windows.Forms.Label();
            this.edDVBCProgramNumber = new System.Windows.Forms.TextBox();
            this.label289 = new System.Windows.Forms.Label();
            this.cbDVBCModulation = new System.Windows.Forms.ComboBox();
            this.label290 = new System.Windows.Forms.Label();
            this.label291 = new System.Windows.Forms.Label();
            this.edDVBCCarrierFrequency = new System.Windows.Forms.TextBox();
            this.label292 = new System.Windows.Forms.Label();
            this.btBDADVBCTune = new System.Windows.Forms.Button();
            this.tabPage87 = new System.Windows.Forms.TabPage();
            this.label293 = new System.Windows.Forms.Label();
            this.tabPage105 = new System.Windows.Forms.TabPage();
            this.btBDAChannelScanningStart = new System.Windows.Forms.Button();
            this.lvBDAChannels = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label342 = new System.Windows.Forms.Label();
            this.tabPage49 = new System.Windows.Forms.TabPage();
            this.tabControl20 = new System.Windows.Forms.TabControl();
            this.tabPage67 = new System.Windows.Forms.TabPage();
            this.tabControl21 = new System.Windows.Forms.TabControl();
            this.tabPage78 = new System.Windows.Forms.TabPage();
            this.btPIPAddDevice = new System.Windows.Forms.Button();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.edPIPVidCapHeight = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.edPIPVidCapWidth = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.edPIPVidCapTop = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.edPIPVidCapLeft = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.cbPIPInput = new System.Windows.Forms.ComboBox();
            this.label170 = new System.Windows.Forms.Label();
            this.cbPIPFrameRate = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.cbPIPFormatUseBest = new System.Windows.Forms.CheckBox();
            this.cbPIPFormat = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.cbPIPDevice = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.tabPage79 = new System.Windows.Forms.TabPage();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.edPIPIPCapHeight = new System.Windows.Forms.TextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.edPIPIPCapWidth = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.edPIPIPCapTop = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.edPIPIPCapLeft = new System.Windows.Forms.TextBox();
            this.label229 = new System.Windows.Forms.Label();
            this.btPIPAddIPCamera = new System.Windows.Forms.Button();
            this.tabPage80 = new System.Windows.Forms.TabPage();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.edPIPScreenCapHeight = new System.Windows.Forms.TextBox();
            this.label256 = new System.Windows.Forms.Label();
            this.edPIPScreenCapWidth = new System.Windows.Forms.TextBox();
            this.label260 = new System.Windows.Forms.Label();
            this.edPIPScreenCapTop = new System.Windows.Forms.TextBox();
            this.label266 = new System.Windows.Forms.Label();
            this.edPIPScreenCapLeft = new System.Windows.Forms.TextBox();
            this.label268 = new System.Windows.Forms.Label();
            this.btPIPAddScreenCapture = new System.Windows.Forms.Button();
            this.tabPage100 = new System.Windows.Forms.TabPage();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.edPIPFileHeight = new System.Windows.Forms.TextBox();
            this.label321 = new System.Windows.Forms.Label();
            this.edPIPFileWidth = new System.Windows.Forms.TextBox();
            this.label322 = new System.Windows.Forms.Label();
            this.edPIPFileTop = new System.Windows.Forms.TextBox();
            this.label323 = new System.Windows.Forms.Label();
            this.edPIPFileLeft = new System.Windows.Forms.TextBox();
            this.label324 = new System.Windows.Forms.Label();
            this.btPIPFileSourceAdd = new System.Windows.Forms.Button();
            this.btSelectPIPFile = new System.Windows.Forms.Button();
            this.edPIPFileSoureFilename = new System.Windows.Forms.TextBox();
            this.label320 = new System.Windows.Forms.Label();
            this.tabPage77 = new System.Windows.Forms.TabPage();
            this.cbPIPResizeMode = new System.Windows.Forms.ComboBox();
            this.label317 = new System.Windows.Forms.Label();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.btPIPSet = new System.Windows.Forms.Button();
            this.tbPIPTransparency = new System.Windows.Forms.TrackBar();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.btPIPSetOutputSize = new System.Windows.Forms.Button();
            this.edPIPOutputHeight = new System.Windows.Forms.TextBox();
            this.label269 = new System.Windows.Forms.Label();
            this.edPIPOutputWidth = new System.Windows.Forms.TextBox();
            this.label271 = new System.Windows.Forms.Label();
            this.cbPIPDevices = new System.Windows.Forms.ComboBox();
            this.cbPIPMode = new System.Windows.Forms.ComboBox();
            this.label169 = new System.Windows.Forms.Label();
            this.btPIPDevicesClear = new System.Windows.Forms.Button();
            this.label134 = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.btPIPUpdate = new System.Windows.Forms.Button();
            this.edPIPHeight = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.edPIPWidth = new System.Windows.Forms.TextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.edPIPTop = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.edPIPLeft = new System.Windows.Forms.TextBox();
            this.label131 = new System.Windows.Forms.Label();
            this.tabPage147 = new System.Windows.Forms.TabPage();
            this.lbPIPChromaKeyTolerance2 = new System.Windows.Forms.Label();
            this.label518 = new System.Windows.Forms.Label();
            this.tbPIPChromaKeyTolerance2 = new System.Windows.Forms.TrackBar();
            this.lbPIPChromaKeyTolerance1 = new System.Windows.Forms.Label();
            this.label515 = new System.Windows.Forms.Label();
            this.tbPIPChromaKeyTolerance1 = new System.Windows.Forms.TrackBar();
            this.pnPIPChromaKeyColor = new System.Windows.Forms.Panel();
            this.label514 = new System.Windows.Forms.Label();
            this.tabPage50 = new System.Windows.Forms.TabPage();
            this.cbMultiscreenDrawOnExternalDisplays = new System.Windows.Forms.CheckBox();
            this.cbFlipHorizontal3 = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical3 = new System.Windows.Forms.CheckBox();
            this.cbStretch3 = new System.Windows.Forms.CheckBox();
            this.cbFlipHorizontal2 = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical2 = new System.Windows.Forms.CheckBox();
            this.cbStretch2 = new System.Windows.Forms.CheckBox();
            this.cbFlipHorizontal1 = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical1 = new System.Windows.Forms.CheckBox();
            this.cbStretch1 = new System.Windows.Forms.CheckBox();
            this.pnScreen3 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnScreen2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnScreen1 = new System.Windows.Forms.Panel();
            this.cbMultiscreenDrawOnPanels = new System.Windows.Forms.CheckBox();
            this.tabPage51 = new System.Windows.Forms.TabPage();
            this.tabControl26 = new System.Windows.Forms.TabControl();
            this.tabPage115 = new System.Windows.Forms.TabPage();
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
            this.rbDirect2D = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbEVR = new System.Windows.Forms.RadioButton();
            this.rbVMR9 = new System.Windows.Forms.RadioButton();
            this.rbVR = new System.Windows.Forms.RadioButton();
            this.tabPage116 = new System.Windows.Forms.TabPage();
            this.label393 = new System.Windows.Forms.Label();
            this.cbDirect2DRotate = new System.Windows.Forms.ComboBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.cbSeparateCaptureBridgeEngine = new System.Windows.Forms.CheckBox();
            this.label376 = new System.Windows.Forms.Label();
            this.edSeparateCaptureFileSize = new System.Windows.Forms.TextBox();
            this.label375 = new System.Windows.Forms.Label();
            this.label374 = new System.Windows.Forms.Label();
            this.edSeparateCaptureDuration = new System.Windows.Forms.TextBox();
            this.label373 = new System.Windows.Forms.Label();
            this.rbSeparateCaptureSplitBySize = new System.Windows.Forms.RadioButton();
            this.rbSeparateCaptureSplitByDuration = new System.Windows.Forms.RadioButton();
            this.rbSeparateCaptureStartManually = new System.Windows.Forms.RadioButton();
            this.btSeparateCaptureResume = new System.Windows.Forms.Button();
            this.btSeparateCapturePause = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btSeparateCaptureChangeFilename = new System.Windows.Forms.Button();
            this.edNewFilename = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.btSeparateCaptureStop = new System.Windows.Forms.Button();
            this.btSeparateCaptureStart = new System.Windows.Forms.Button();
            this.cbSeparateCaptureEnabled = new System.Windows.Forms.CheckBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.tabPage88 = new System.Windows.Forms.TabPage();
            this.btMPEGDemuxSettings = new System.Windows.Forms.Button();
            this.cbMPEGDemuxer = new System.Windows.Forms.ComboBox();
            this.label315 = new System.Windows.Forms.Label();
            this.btMPEGAudDecSettings = new System.Windows.Forms.Button();
            this.cbMPEGAudioDecoder = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.btMPEGVidDecSetting = new System.Windows.Forms.Button();
            this.cbMPEGVideoDecoder = new System.Windows.Forms.ComboBox();
            this.label120 = new System.Windows.Forms.Label();
            this.tabPage124 = new System.Windows.Forms.TabPage();
            this.tabControl28 = new System.Windows.Forms.TabControl();
            this.tabPage125 = new System.Windows.Forms.TabPage();
            this.edCustomVideoSourceURL = new System.Windows.Forms.TextBox();
            this.label516 = new System.Windows.Forms.Label();
            this.cbCustomVideoSourceFrameRate = new System.Windows.Forms.ComboBox();
            this.label438 = new System.Windows.Forms.Label();
            this.label435 = new System.Windows.Forms.Label();
            this.cbCustomVideoSourceFormat = new System.Windows.Forms.ComboBox();
            this.label434 = new System.Windows.Forms.Label();
            this.cbCustomVideoSourceFilter = new System.Windows.Forms.ComboBox();
            this.cbCustomVideoSourceCategory = new System.Windows.Forms.ComboBox();
            this.label432 = new System.Windows.Forms.Label();
            this.tabPage126 = new System.Windows.Forms.TabPage();
            this.edCustomAudioSourceURL = new System.Windows.Forms.TextBox();
            this.label517 = new System.Windows.Forms.Label();
            this.label437 = new System.Windows.Forms.Label();
            this.cbCustomAudioSourceFormat = new System.Windows.Forms.ComboBox();
            this.label436 = new System.Windows.Forms.Label();
            this.cbCustomAudioSourceFilter = new System.Windows.Forms.ComboBox();
            this.label433 = new System.Windows.Forms.Label();
            this.cbCustomAudioSourceCategory = new System.Windows.Forms.ComboBox();
            this.tabControl12 = new System.Windows.Forms.TabControl();
            this.tabPage53 = new System.Windows.Forms.TabPage();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl17.SuspendLayout();
            this.tabPage68.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.tabPage29.SuspendLayout();
            this.tabPage42.SuspendLayout();
            this.tabPage91.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.tabPage92.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.tabPage102.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.tabPage114.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage69.SuspendLayout();
            this.tabPage59.SuspendLayout();
            this.tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.tabPage60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).BeginInit();
            this.tabPage70.SuspendLayout();
            this.tabControl14.SuspendLayout();
            this.tabPage127.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).BeginInit();
            this.tabPage27.SuspendLayout();
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
            this.tabPage93.SuspendLayout();
            this.groupBox41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).BeginInit();
            this.tabPage107.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tpWMV.SuspendLayout();
            this.tpRTSP.SuspendLayout();
            this.tpRTMP.SuspendLayout();
            this.tpNDI.SuspendLayout();
            this.tpUDP.SuspendLayout();
            this.tpSSF.SuspendLayout();
            this.tpHLS.SuspendLayout();
            this.tpNSExternal.SuspendLayout();
            this.tabPage28.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabPage32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOSDTranspLevel)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.tabPage43.SuspendLayout();
            this.tabControl9.SuspendLayout();
            this.tabPage44.SuspendLayout();
            this.tabPage45.SuspendLayout();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetHLThreshold)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMotDetDropFramesThreshold)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.tabPage26.SuspendLayout();
            this.tabPage25.SuspendLayout();
            this.tabPage101.SuspendLayout();
            this.tabPage103.SuspendLayout();
            this.tabPage141.SuspendLayout();
            this.TabControl32.SuspendLayout();
            this.TabPage142.SuspendLayout();
            this.TabPage143.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTagCover)).BeginInit();
            this.tabControl10.SuspendLayout();
            this.tabPage46.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage52.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).BeginInit();
            this.tabPage66.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCPan)).BeginInit();
            this.tabPage63.SuspendLayout();
            this.tabControl19.SuspendLayout();
            this.tabPage96.SuspendLayout();
            this.tabPage97.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).BeginInit();
            this.tabPage98.SuspendLayout();
            this.tabPage112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).BeginInit();
            this.tabPage99.SuspendLayout();
            this.tabPage47.SuspendLayout();
            this.tabPage48.SuspendLayout();
            this.tabControl15.SuspendLayout();
            this.tabPage144.SuspendLayout();
            this.tabPage146.SuspendLayout();
            this.tabPage145.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage81.SuspendLayout();
            this.tabControl22.SuspendLayout();
            this.tabPage82.SuspendLayout();
            this.tabPage83.SuspendLayout();
            this.tabControl23.SuspendLayout();
            this.tabPage84.SuspendLayout();
            this.tabPage85.SuspendLayout();
            this.tabPage86.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.tabPage87.SuspendLayout();
            this.tabPage105.SuspendLayout();
            this.tabPage49.SuspendLayout();
            this.tabControl20.SuspendLayout();
            this.tabPage67.SuspendLayout();
            this.tabControl21.SuspendLayout();
            this.tabPage78.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.tabPage79.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.tabPage80.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.tabPage100.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.tabPage77.SuspendLayout();
            this.groupBox34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPTransparency)).BeginInit();
            this.groupBox33.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tabPage147.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPChromaKeyTolerance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPChromaKeyTolerance1)).BeginInit();
            this.tabPage50.SuspendLayout();
            this.tabPage51.SuspendLayout();
            this.tabControl26.SuspendLayout();
            this.tabPage115.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage116.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage88.SuspendLayout();
            this.tabPage124.SuspendLayout();
            this.tabControl28.SuspendLayout();
            this.tabPage125.SuspendLayout();
            this.tabPage126.SuspendLayout();
            this.tabControl12.SuspendLayout();
            this.tabPage53.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 685);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Mode";
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btStop.Location = new System.Drawing.Point(734, 680);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 34;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btStart.Location = new System.Drawing.Point(669, 680);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 33;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage127);
            this.tabControl1.Controls.Add(this.tabPage27);
            this.tabControl1.Controls.Add(this.tabPage93);
            this.tabControl1.Controls.Add(this.tabPage107);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage28);
            this.tabControl1.Controls.Add(this.tabPage43);
            this.tabControl1.Controls.Add(this.tabPage26);
            this.tabControl1.Controls.Add(this.tabPage25);
            this.tabControl1.Controls.Add(this.tabPage101);
            this.tabControl1.Controls.Add(this.tabPage103);
            this.tabControl1.Controls.Add(this.tabPage141);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(315, 510);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbInfo);
            this.tabPage1.Controls.Add(this.btOutputConfigure);
            this.tabPage1.Controls.Add(this.cbAutoFilename);
            this.tabPage1.Controls.Add(this.cbOutputFormat);
            this.tabPage1.Controls.Add(this.btSelectOutput);
            this.tabPage1.Controls.Add(this.edOutput);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cbRecordAudio);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Capture";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(16, 61);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 51;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            this.btOutputConfigure.Location = new System.Drawing.Point(19, 77);
            this.btOutputConfigure.Name = "btOutputConfigure";
            this.btOutputConfigure.Size = new System.Drawing.Size(75, 23);
            this.btOutputConfigure.TabIndex = 44;
            this.btOutputConfigure.Text = "Configure";
            this.btOutputConfigure.UseVisualStyleBackColor = true;
            this.btOutputConfigure.Click += new System.EventHandler(this.btOutputConfigure_Click);
            // 
            // cbAutoFilename
            // 
            this.cbAutoFilename.AutoSize = true;
            this.cbAutoFilename.Location = new System.Drawing.Point(250, 141);
            this.cbAutoFilename.Name = "cbAutoFilename";
            this.cbAutoFilename.Size = new System.Drawing.Size(48, 17);
            this.cbAutoFilename.TabIndex = 43;
            this.cbAutoFilename.Text = "Auto";
            this.cbAutoFilename.UseVisualStyleBackColor = true;
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "AVI",
            "MKV (Legacy)",
            "WMV (Windows Media Video)",
            "DV",
            "PCM/ACM",
            "MP3",
            "M4A (AAC)",
            "WMA (Windows Media Audio)",
            "FLAC",
            "Ogg Vorbis",
            "Speex",
            "Custom",
            "DirectCapture DV (DV devices only)",
            "DirectCapture AVI (some specific devices)",
            "DirectCapture MPEG (MPEG 1/2/4 devices only)",
            "DirectCapture MKV (IP cameras / H264 devices)",
            "DirectCapture MP4 GDCL Mux (IP cameras / H264 devices)",
            "DirectCapture MP4 Monogram Mux (IP cameras / H264 devices)",
            "DirectCapture Custom (IP Cameras / H264 devices)",
            "WebM",
            "FFMPEG (DLL)",
            "FFMPEG (external exe)",
            "MP4 (v10 engine)",
            "MP4 (v11 engine, CPU/GPU)",
            "Animated GIF",
            "Encrypted video",
            "MPEG-TS",
            "MOV"});
            this.cbOutputFormat.Location = new System.Drawing.Point(19, 33);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(279, 21);
            this.cbOutputFormat.TabIndex = 42;
            this.cbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputFormat_SelectedIndexChanged);
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(274, 159);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 41;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(19, 161);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(249, 20);
            this.edOutput.TabIndex = 40;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "File name";
            // 
            // cbRecordAudio
            // 
            this.cbRecordAudio.AutoSize = true;
            this.cbRecordAudio.Location = new System.Drawing.Point(19, 114);
            this.cbRecordAudio.Name = "cbRecordAudio";
            this.cbRecordAudio.Size = new System.Drawing.Size(90, 17);
            this.cbRecordAudio.TabIndex = 7;
            this.cbRecordAudio.Text = "Record audio";
            this.cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Format";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl17);
            this.tabPage2.Controls.Add(this.tabControl14);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(307, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video processing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            this.tabControl17.Controls.Add(this.tabPage68);
            this.tabControl17.Controls.Add(this.tabPage69);
            this.tabControl17.Controls.Add(this.tabPage59);
            this.tabControl17.Controls.Add(this.tabPage20);
            this.tabControl17.Controls.Add(this.tabPage9);
            this.tabControl17.Controls.Add(this.tabPage60);
            this.tabControl17.Controls.Add(this.tabPage70);
            this.tabControl17.Location = new System.Drawing.Point(6, 3);
            this.tabControl17.Name = "tabControl17";
            this.tabControl17.SelectedIndex = 0;
            this.tabControl17.Size = new System.Drawing.Size(298, 485);
            this.tabControl17.TabIndex = 36;
            // 
            // tabPage68
            // 
            this.tabPage68.Controls.Add(this.cbFlipY);
            this.tabPage68.Controls.Add(this.cbFlipX);
            this.tabPage68.Controls.Add(this.cbDisableAllVideoProcessing);
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
            this.tabPage68.Location = new System.Drawing.Point(4, 22);
            this.tabPage68.Name = "tabPage68";
            this.tabPage68.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage68.Size = new System.Drawing.Size(290, 459);
            this.tabPage68.TabIndex = 0;
            this.tabPage68.Text = "Effects";
            this.tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(210, 158);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(52, 17);
            this.cbFlipY.TabIndex = 67;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(150, 158);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(52, 17);
            this.cbFlipX.TabIndex = 66;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            this.cbFlipX.CheckedChanged += new System.EventHandler(this.cbFlipX_CheckedChanged);
            // 
            // cbDisableAllVideoProcessing
            // 
            this.cbDisableAllVideoProcessing.AutoSize = true;
            this.cbDisableAllVideoProcessing.Location = new System.Drawing.Point(106, 8);
            this.cbDisableAllVideoProcessing.Name = "cbDisableAllVideoProcessing";
            this.cbDisableAllVideoProcessing.Size = new System.Drawing.Size(175, 17);
            this.cbDisableAllVideoProcessing.TabIndex = 65;
            this.cbDisableAllVideoProcessing.Text = "(DEBUG) Disable all processing";
            this.cbDisableAllVideoProcessing.UseVisualStyleBackColor = true;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(142, 88);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(52, 13);
            this.label201.TabIndex = 63;
            this.label201.Text = "Darkness";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(6, 88);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(46, 13);
            this.label200.TabIndex = 62;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(142, 36);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(55, 13);
            this.label199.TabIndex = 61;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(6, 36);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(52, 13);
            this.label198.TabIndex = 60;
            this.label198.Text = "Lightness";
            // 
            // tabControl7
            // 
            this.tabControl7.Controls.Add(this.tabPage29);
            this.tabControl7.Controls.Add(this.tabPage42);
            this.tabControl7.Controls.Add(this.tabPage91);
            this.tabControl7.Controls.Add(this.tabPage92);
            this.tabControl7.Controls.Add(this.tabPage102);
            this.tabControl7.Controls.Add(this.tabPage114);
            this.tabControl7.Location = new System.Drawing.Point(3, 185);
            this.tabControl7.Name = "tabControl7";
            this.tabControl7.SelectedIndex = 0;
            this.tabControl7.Size = new System.Drawing.Size(283, 274);
            this.tabControl7.TabIndex = 59;
            // 
            // tabPage29
            // 
            this.tabPage29.Controls.Add(this.cbMergeTextLogos);
            this.tabPage29.Controls.Add(this.btTextLogoRemove);
            this.tabPage29.Controls.Add(this.btTextLogoEdit);
            this.tabPage29.Controls.Add(this.lbTextLogos);
            this.tabPage29.Controls.Add(this.btTextLogoAdd);
            this.tabPage29.Location = new System.Drawing.Point(4, 22);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage29.Size = new System.Drawing.Size(275, 248);
            this.tabPage29.TabIndex = 0;
            this.tabPage29.Text = "Text logo";
            this.tabPage29.UseVisualStyleBackColor = true;
            // 
            // cbMergeTextLogos
            // 
            this.cbMergeTextLogos.AutoSize = true;
            this.cbMergeTextLogos.Location = new System.Drawing.Point(8, 11);
            this.cbMergeTextLogos.Name = "cbMergeTextLogos";
            this.cbMergeTextLogos.Size = new System.Drawing.Size(145, 17);
            this.cbMergeTextLogos.TabIndex = 88;
            this.cbMergeTextLogos.Text = "Merge text logos into one";
            this.cbMergeTextLogos.UseVisualStyleBackColor = true;
            // 
            // btTextLogoRemove
            // 
            this.btTextLogoRemove.Location = new System.Drawing.Point(204, 211);
            this.btTextLogoRemove.Name = "btTextLogoRemove";
            this.btTextLogoRemove.Size = new System.Drawing.Size(59, 23);
            this.btTextLogoRemove.TabIndex = 3;
            this.btTextLogoRemove.Text = "Remove";
            this.btTextLogoRemove.UseVisualStyleBackColor = true;
            this.btTextLogoRemove.Click += new System.EventHandler(this.btTextLogoRemove_Click);
            // 
            // btTextLogoEdit
            // 
            this.btTextLogoEdit.Location = new System.Drawing.Point(72, 211);
            this.btTextLogoEdit.Name = "btTextLogoEdit";
            this.btTextLogoEdit.Size = new System.Drawing.Size(59, 23);
            this.btTextLogoEdit.TabIndex = 2;
            this.btTextLogoEdit.Text = "Edit";
            this.btTextLogoEdit.UseVisualStyleBackColor = true;
            this.btTextLogoEdit.Click += new System.EventHandler(this.btTextLogoEdit_Click);
            // 
            // lbTextLogos
            // 
            this.lbTextLogos.FormattingEnabled = true;
            this.lbTextLogos.Location = new System.Drawing.Point(8, 34);
            this.lbTextLogos.Name = "lbTextLogos";
            this.lbTextLogos.Size = new System.Drawing.Size(257, 173);
            this.lbTextLogos.TabIndex = 1;
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = new System.Drawing.Point(7, 211);
            this.btTextLogoAdd.Name = "btTextLogoAdd";
            this.btTextLogoAdd.Size = new System.Drawing.Size(59, 23);
            this.btTextLogoAdd.TabIndex = 0;
            this.btTextLogoAdd.Text = "Add";
            this.btTextLogoAdd.UseVisualStyleBackColor = true;
            this.btTextLogoAdd.Click += new System.EventHandler(this.btTextLogoAdd_Click);
            // 
            // tabPage42
            // 
            this.tabPage42.Controls.Add(this.cbMergeImageLogos);
            this.tabPage42.Controls.Add(this.btImageLogoRemove);
            this.tabPage42.Controls.Add(this.btImageLogoEdit);
            this.tabPage42.Controls.Add(this.lbImageLogos);
            this.tabPage42.Controls.Add(this.btImageLogoAdd);
            this.tabPage42.Location = new System.Drawing.Point(4, 22);
            this.tabPage42.Name = "tabPage42";
            this.tabPage42.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage42.Size = new System.Drawing.Size(275, 248);
            this.tabPage42.TabIndex = 1;
            this.tabPage42.Text = "Image logo";
            this.tabPage42.UseVisualStyleBackColor = true;
            // 
            // cbMergeImageLogos
            // 
            this.cbMergeImageLogos.AutoSize = true;
            this.cbMergeImageLogos.Location = new System.Drawing.Point(8, 11);
            this.cbMergeImageLogos.Name = "cbMergeImageLogos";
            this.cbMergeImageLogos.Size = new System.Drawing.Size(156, 17);
            this.cbMergeImageLogos.TabIndex = 87;
            this.cbMergeImageLogos.Text = "Merge image logos into one";
            this.cbMergeImageLogos.UseVisualStyleBackColor = true;
            // 
            // btImageLogoRemove
            // 
            this.btImageLogoRemove.Location = new System.Drawing.Point(206, 211);
            this.btImageLogoRemove.Name = "btImageLogoRemove";
            this.btImageLogoRemove.Size = new System.Drawing.Size(59, 23);
            this.btImageLogoRemove.TabIndex = 7;
            this.btImageLogoRemove.Text = "Remove";
            this.btImageLogoRemove.UseVisualStyleBackColor = true;
            this.btImageLogoRemove.Click += new System.EventHandler(this.btImageLogoRemove_Click);
            // 
            // btImageLogoEdit
            // 
            this.btImageLogoEdit.Location = new System.Drawing.Point(72, 211);
            this.btImageLogoEdit.Name = "btImageLogoEdit";
            this.btImageLogoEdit.Size = new System.Drawing.Size(59, 23);
            this.btImageLogoEdit.TabIndex = 6;
            this.btImageLogoEdit.Text = "Edit";
            this.btImageLogoEdit.UseVisualStyleBackColor = true;
            this.btImageLogoEdit.Click += new System.EventHandler(this.btImageLogoEdit_Click);
            // 
            // lbImageLogos
            // 
            this.lbImageLogos.FormattingEnabled = true;
            this.lbImageLogos.Location = new System.Drawing.Point(8, 34);
            this.lbImageLogos.Name = "lbImageLogos";
            this.lbImageLogos.Size = new System.Drawing.Size(257, 173);
            this.lbImageLogos.TabIndex = 5;
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = new System.Drawing.Point(7, 211);
            this.btImageLogoAdd.Name = "btImageLogoAdd";
            this.btImageLogoAdd.Size = new System.Drawing.Size(59, 23);
            this.btImageLogoAdd.TabIndex = 4;
            this.btImageLogoAdd.Text = "Add";
            this.btImageLogoAdd.UseVisualStyleBackColor = true;
            this.btImageLogoAdd.Click += new System.EventHandler(this.btImageLogoAdd_Click);
            // 
            // tabPage91
            // 
            this.tabPage91.Controls.Add(this.groupBox37);
            this.tabPage91.Controls.Add(this.cbZoom);
            this.tabPage91.Location = new System.Drawing.Point(4, 22);
            this.tabPage91.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage91.Name = "tabPage91";
            this.tabPage91.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage91.Size = new System.Drawing.Size(275, 248);
            this.tabPage91.TabIndex = 2;
            this.tabPage91.Text = "Zoom";
            this.tabPage91.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.btEffZoomRight);
            this.groupBox37.Controls.Add(this.btEffZoomLeft);
            this.groupBox37.Controls.Add(this.btEffZoomOut);
            this.groupBox37.Controls.Add(this.btEffZoomIn);
            this.groupBox37.Controls.Add(this.btEffZoomDown);
            this.groupBox37.Controls.Add(this.btEffZoomUp);
            this.groupBox37.Location = new System.Drawing.Point(82, 53);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(119, 104);
            this.groupBox37.TabIndex = 16;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Zoom";
            // 
            // btEffZoomRight
            // 
            this.btEffZoomRight.Location = new System.Drawing.Point(85, 33);
            this.btEffZoomRight.Name = "btEffZoomRight";
            this.btEffZoomRight.Size = new System.Drawing.Size(21, 48);
            this.btEffZoomRight.TabIndex = 5;
            this.btEffZoomRight.Text = "R";
            this.btEffZoomRight.UseVisualStyleBackColor = true;
            this.btEffZoomRight.Click += new System.EventHandler(this.btEffZoomRight_Click);
            // 
            // btEffZoomLeft
            // 
            this.btEffZoomLeft.Location = new System.Drawing.Point(13, 32);
            this.btEffZoomLeft.Name = "btEffZoomLeft";
            this.btEffZoomLeft.Size = new System.Drawing.Size(21, 48);
            this.btEffZoomLeft.TabIndex = 4;
            this.btEffZoomLeft.Text = "L";
            this.btEffZoomLeft.UseVisualStyleBackColor = true;
            this.btEffZoomLeft.Click += new System.EventHandler(this.btEffZoomLeft_Click);
            // 
            // btEffZoomOut
            // 
            this.btEffZoomOut.Location = new System.Drawing.Point(61, 45);
            this.btEffZoomOut.Name = "btEffZoomOut";
            this.btEffZoomOut.Size = new System.Drawing.Size(23, 23);
            this.btEffZoomOut.TabIndex = 3;
            this.btEffZoomOut.Text = "-";
            this.btEffZoomOut.UseVisualStyleBackColor = true;
            this.btEffZoomOut.Click += new System.EventHandler(this.btEffZoomOut_Click);
            // 
            // btEffZoomIn
            // 
            this.btEffZoomIn.Location = new System.Drawing.Point(35, 45);
            this.btEffZoomIn.Name = "btEffZoomIn";
            this.btEffZoomIn.Size = new System.Drawing.Size(22, 23);
            this.btEffZoomIn.TabIndex = 2;
            this.btEffZoomIn.Text = "+";
            this.btEffZoomIn.UseVisualStyleBackColor = true;
            this.btEffZoomIn.Click += new System.EventHandler(this.btEffZoomIn_Click);
            // 
            // btEffZoomDown
            // 
            this.btEffZoomDown.Location = new System.Drawing.Point(34, 69);
            this.btEffZoomDown.Name = "btEffZoomDown";
            this.btEffZoomDown.Size = new System.Drawing.Size(51, 23);
            this.btEffZoomDown.TabIndex = 1;
            this.btEffZoomDown.Text = "Down";
            this.btEffZoomDown.UseVisualStyleBackColor = true;
            this.btEffZoomDown.Click += new System.EventHandler(this.btEffZoomDown_Click);
            // 
            // btEffZoomUp
            // 
            this.btEffZoomUp.Location = new System.Drawing.Point(34, 20);
            this.btEffZoomUp.Name = "btEffZoomUp";
            this.btEffZoomUp.Size = new System.Drawing.Size(51, 23);
            this.btEffZoomUp.TabIndex = 0;
            this.btEffZoomUp.Text = "Up";
            this.btEffZoomUp.UseVisualStyleBackColor = true;
            this.btEffZoomUp.Click += new System.EventHandler(this.btEffZoomUp_Click);
            // 
            // cbZoom
            // 
            this.cbZoom.AutoSize = true;
            this.cbZoom.Location = new System.Drawing.Point(8, 16);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(65, 17);
            this.cbZoom.TabIndex = 15;
            this.cbZoom.Text = "Enabled";
            this.cbZoom.UseVisualStyleBackColor = true;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.cbZoom_CheckedChanged);
            // 
            // tabPage92
            // 
            this.tabPage92.Controls.Add(this.groupBox40);
            this.tabPage92.Controls.Add(this.groupBox39);
            this.tabPage92.Controls.Add(this.groupBox38);
            this.tabPage92.Controls.Add(this.cbPan);
            this.tabPage92.Location = new System.Drawing.Point(4, 22);
            this.tabPage92.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage92.Name = "tabPage92";
            this.tabPage92.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage92.Size = new System.Drawing.Size(275, 248);
            this.tabPage92.TabIndex = 3;
            this.tabPage92.Text = "Pan";
            this.tabPage92.UseVisualStyleBackColor = true;
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
            this.groupBox40.Location = new System.Drawing.Point(12, 168);
            this.groupBox40.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox40.Size = new System.Drawing.Size(168, 77);
            this.groupBox40.TabIndex = 54;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "Destination rect";
            // 
            // edPanDestHeight
            // 
            this.edPanDestHeight.Location = new System.Drawing.Point(123, 51);
            this.edPanDestHeight.Name = "edPanDestHeight";
            this.edPanDestHeight.Size = new System.Drawing.Size(33, 20);
            this.edPanDestHeight.TabIndex = 17;
            this.edPanDestHeight.Text = "240";
            // 
            // label302
            // 
            this.label302.AutoSize = true;
            this.label302.Location = new System.Drawing.Point(81, 54);
            this.label302.Name = "label302";
            this.label302.Size = new System.Drawing.Size(38, 13);
            this.label302.TabIndex = 16;
            this.label302.Text = "Height";
            // 
            // edPanDestWidth
            // 
            this.edPanDestWidth.Location = new System.Drawing.Point(123, 25);
            this.edPanDestWidth.Name = "edPanDestWidth";
            this.edPanDestWidth.Size = new System.Drawing.Size(33, 20);
            this.edPanDestWidth.TabIndex = 15;
            this.edPanDestWidth.Text = "320";
            // 
            // label303
            // 
            this.label303.AutoSize = true;
            this.label303.Location = new System.Drawing.Point(81, 28);
            this.label303.Name = "label303";
            this.label303.Size = new System.Drawing.Size(35, 13);
            this.label303.TabIndex = 14;
            this.label303.Text = "Width";
            // 
            // edPanDestTop
            // 
            this.edPanDestTop.Location = new System.Drawing.Point(43, 52);
            this.edPanDestTop.Name = "edPanDestTop";
            this.edPanDestTop.Size = new System.Drawing.Size(33, 20);
            this.edPanDestTop.TabIndex = 12;
            this.edPanDestTop.Text = "0";
            // 
            // label304
            // 
            this.label304.AutoSize = true;
            this.label304.Location = new System.Drawing.Point(13, 54);
            this.label304.Name = "label304";
            this.label304.Size = new System.Drawing.Size(26, 13);
            this.label304.TabIndex = 11;
            this.label304.Text = "Top";
            // 
            // edPanDestLeft
            // 
            this.edPanDestLeft.Location = new System.Drawing.Point(43, 26);
            this.edPanDestLeft.Name = "edPanDestLeft";
            this.edPanDestLeft.Size = new System.Drawing.Size(33, 20);
            this.edPanDestLeft.TabIndex = 10;
            this.edPanDestLeft.Text = "0";
            // 
            // label305
            // 
            this.label305.AutoSize = true;
            this.label305.Location = new System.Drawing.Point(13, 28);
            this.label305.Name = "label305";
            this.label305.Size = new System.Drawing.Size(25, 13);
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
            this.groupBox39.Location = new System.Drawing.Point(12, 87);
            this.groupBox39.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox39.Size = new System.Drawing.Size(168, 77);
            this.groupBox39.TabIndex = 53;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Source rect";
            // 
            // edPanSourceHeight
            // 
            this.edPanSourceHeight.Location = new System.Drawing.Point(123, 51);
            this.edPanSourceHeight.Name = "edPanSourceHeight";
            this.edPanSourceHeight.Size = new System.Drawing.Size(33, 20);
            this.edPanSourceHeight.TabIndex = 17;
            this.edPanSourceHeight.Text = "480";
            // 
            // label298
            // 
            this.label298.AutoSize = true;
            this.label298.Location = new System.Drawing.Point(81, 54);
            this.label298.Name = "label298";
            this.label298.Size = new System.Drawing.Size(38, 13);
            this.label298.TabIndex = 16;
            this.label298.Text = "Height";
            // 
            // edPanSourceWidth
            // 
            this.edPanSourceWidth.Location = new System.Drawing.Point(123, 25);
            this.edPanSourceWidth.Name = "edPanSourceWidth";
            this.edPanSourceWidth.Size = new System.Drawing.Size(33, 20);
            this.edPanSourceWidth.TabIndex = 15;
            this.edPanSourceWidth.Text = "640";
            // 
            // label299
            // 
            this.label299.AutoSize = true;
            this.label299.Location = new System.Drawing.Point(81, 28);
            this.label299.Name = "label299";
            this.label299.Size = new System.Drawing.Size(35, 13);
            this.label299.TabIndex = 14;
            this.label299.Text = "Width";
            // 
            // edPanSourceTop
            // 
            this.edPanSourceTop.Location = new System.Drawing.Point(43, 52);
            this.edPanSourceTop.Name = "edPanSourceTop";
            this.edPanSourceTop.Size = new System.Drawing.Size(33, 20);
            this.edPanSourceTop.TabIndex = 12;
            this.edPanSourceTop.Text = "0";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.Location = new System.Drawing.Point(13, 54);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(26, 13);
            this.label300.TabIndex = 11;
            this.label300.Text = "Top";
            // 
            // edPanSourceLeft
            // 
            this.edPanSourceLeft.Location = new System.Drawing.Point(43, 26);
            this.edPanSourceLeft.Name = "edPanSourceLeft";
            this.edPanSourceLeft.Size = new System.Drawing.Size(33, 20);
            this.edPanSourceLeft.TabIndex = 10;
            this.edPanSourceLeft.Text = "0";
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Location = new System.Drawing.Point(13, 28);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(25, 13);
            this.label301.TabIndex = 9;
            this.label301.Text = "Left";
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.edPanStopTime);
            this.groupBox38.Controls.Add(this.label296);
            this.groupBox38.Controls.Add(this.edPanStartTime);
            this.groupBox38.Controls.Add(this.label297);
            this.groupBox38.Location = new System.Drawing.Point(12, 36);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(168, 46);
            this.groupBox38.TabIndex = 52;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Duration";
            // 
            // edPanStopTime
            // 
            this.edPanStopTime.Location = new System.Drawing.Point(117, 19);
            this.edPanStopTime.Name = "edPanStopTime";
            this.edPanStopTime.Size = new System.Drawing.Size(39, 20);
            this.edPanStopTime.TabIndex = 34;
            this.edPanStopTime.Text = "15000";
            this.edPanStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label296
            // 
            this.label296.AutoSize = true;
            this.label296.Location = new System.Drawing.Point(88, 22);
            this.label296.Name = "label296";
            this.label296.Size = new System.Drawing.Size(29, 13);
            this.label296.TabIndex = 33;
            this.label296.Text = "Stop";
            // 
            // edPanStartTime
            // 
            this.edPanStartTime.Location = new System.Drawing.Point(43, 19);
            this.edPanStartTime.Name = "edPanStartTime";
            this.edPanStartTime.Size = new System.Drawing.Size(39, 20);
            this.edPanStartTime.TabIndex = 32;
            this.edPanStartTime.Text = "5000";
            this.edPanStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label297
            // 
            this.label297.AutoSize = true;
            this.label297.Location = new System.Drawing.Point(10, 22);
            this.label297.Name = "label297";
            this.label297.Size = new System.Drawing.Size(29, 13);
            this.label297.TabIndex = 31;
            this.label297.Text = "Start";
            // 
            // cbPan
            // 
            this.cbPan.AutoSize = true;
            this.cbPan.Location = new System.Drawing.Point(12, 12);
            this.cbPan.Name = "cbPan";
            this.cbPan.Size = new System.Drawing.Size(65, 17);
            this.cbPan.TabIndex = 51;
            this.cbPan.Text = "Enabled";
            this.cbPan.UseVisualStyleBackColor = true;
            this.cbPan.CheckedChanged += new System.EventHandler(this.cbPan_CheckedChanged);
            // 
            // tabPage102
            // 
            this.tabPage102.Controls.Add(this.rbFadeOut);
            this.tabPage102.Controls.Add(this.rbFadeIn);
            this.tabPage102.Controls.Add(this.groupBox45);
            this.tabPage102.Controls.Add(this.cbFadeInOut);
            this.tabPage102.Location = new System.Drawing.Point(4, 22);
            this.tabPage102.Name = "tabPage102";
            this.tabPage102.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage102.Size = new System.Drawing.Size(275, 248);
            this.tabPage102.TabIndex = 4;
            this.tabPage102.Text = "Fade-in/out";
            this.tabPage102.UseVisualStyleBackColor = true;
            // 
            // rbFadeOut
            // 
            this.rbFadeOut.AutoSize = true;
            this.rbFadeOut.Location = new System.Drawing.Point(103, 98);
            this.rbFadeOut.Name = "rbFadeOut";
            this.rbFadeOut.Size = new System.Drawing.Size(67, 17);
            this.rbFadeOut.TabIndex = 56;
            this.rbFadeOut.TabStop = true;
            this.rbFadeOut.Text = "Fade-out";
            this.rbFadeOut.UseVisualStyleBackColor = true;
            // 
            // rbFadeIn
            // 
            this.rbFadeIn.AutoSize = true;
            this.rbFadeIn.Checked = true;
            this.rbFadeIn.Location = new System.Drawing.Point(12, 98);
            this.rbFadeIn.Name = "rbFadeIn";
            this.rbFadeIn.Size = new System.Drawing.Size(60, 17);
            this.rbFadeIn.TabIndex = 55;
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
            this.groupBox45.Location = new System.Drawing.Point(12, 46);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(168, 46);
            this.groupBox45.TabIndex = 54;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Duration";
            // 
            // edFadeInOutStopTime
            // 
            this.edFadeInOutStopTime.Location = new System.Drawing.Point(117, 19);
            this.edFadeInOutStopTime.Name = "edFadeInOutStopTime";
            this.edFadeInOutStopTime.Size = new System.Drawing.Size(39, 20);
            this.edFadeInOutStopTime.TabIndex = 34;
            this.edFadeInOutStopTime.Text = "15000";
            this.edFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label329
            // 
            this.label329.AutoSize = true;
            this.label329.Location = new System.Drawing.Point(88, 22);
            this.label329.Name = "label329";
            this.label329.Size = new System.Drawing.Size(29, 13);
            this.label329.TabIndex = 33;
            this.label329.Text = "Stop";
            // 
            // edFadeInOutStartTime
            // 
            this.edFadeInOutStartTime.Location = new System.Drawing.Point(43, 19);
            this.edFadeInOutStartTime.Name = "edFadeInOutStartTime";
            this.edFadeInOutStartTime.Size = new System.Drawing.Size(39, 20);
            this.edFadeInOutStartTime.TabIndex = 32;
            this.edFadeInOutStartTime.Text = "5000";
            this.edFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label330
            // 
            this.label330.AutoSize = true;
            this.label330.Location = new System.Drawing.Point(10, 22);
            this.label330.Name = "label330";
            this.label330.Size = new System.Drawing.Size(29, 13);
            this.label330.TabIndex = 31;
            this.label330.Text = "Start";
            // 
            // cbFadeInOut
            // 
            this.cbFadeInOut.AutoSize = true;
            this.cbFadeInOut.Location = new System.Drawing.Point(12, 12);
            this.cbFadeInOut.Name = "cbFadeInOut";
            this.cbFadeInOut.Size = new System.Drawing.Size(65, 17);
            this.cbFadeInOut.TabIndex = 53;
            this.cbFadeInOut.Text = "Enabled";
            this.cbFadeInOut.UseVisualStyleBackColor = true;
            this.cbFadeInOut.CheckedChanged += new System.EventHandler(this.cbFadeInOut_CheckedChanged);
            // 
            // tabPage114
            // 
            this.tabPage114.Controls.Add(this.cbLiveRotationStretch);
            this.tabPage114.Controls.Add(this.label392);
            this.tabPage114.Controls.Add(this.label391);
            this.tabPage114.Controls.Add(this.tbLiveRotationAngle);
            this.tabPage114.Controls.Add(this.label390);
            this.tabPage114.Controls.Add(this.cbLiveRotation);
            this.tabPage114.Location = new System.Drawing.Point(4, 22);
            this.tabPage114.Name = "tabPage114";
            this.tabPage114.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage114.Size = new System.Drawing.Size(275, 248);
            this.tabPage114.TabIndex = 5;
            this.tabPage114.Text = "Live rotation";
            this.tabPage114.UseVisualStyleBackColor = true;
            // 
            // cbLiveRotationStretch
            // 
            this.cbLiveRotationStretch.AutoSize = true;
            this.cbLiveRotationStretch.Location = new System.Drawing.Point(12, 137);
            this.cbLiveRotationStretch.Name = "cbLiveRotationStretch";
            this.cbLiveRotationStretch.Size = new System.Drawing.Size(158, 17);
            this.cbLiveRotationStretch.TabIndex = 59;
            this.cbLiveRotationStretch.Text = "Stretch  if angle is 90 or 270";
            this.cbLiveRotationStretch.UseVisualStyleBackColor = true;
            this.cbLiveRotationStretch.CheckedChanged += new System.EventHandler(this.cbLiveRotationStretch_CheckedChanged);
            // 
            // label392
            // 
            this.label392.AutoSize = true;
            this.label392.Location = new System.Drawing.Point(130, 111);
            this.label392.Name = "label392";
            this.label392.Size = new System.Drawing.Size(25, 13);
            this.label392.TabIndex = 58;
            this.label392.Text = "360";
            // 
            // label391
            // 
            this.label391.AutoSize = true;
            this.label391.Location = new System.Drawing.Point(9, 111);
            this.label391.Name = "label391";
            this.label391.Size = new System.Drawing.Size(13, 13);
            this.label391.TabIndex = 57;
            this.label391.Text = "0";
            // 
            // tbLiveRotationAngle
            // 
            this.tbLiveRotationAngle.Location = new System.Drawing.Point(12, 63);
            this.tbLiveRotationAngle.Maximum = 360;
            this.tbLiveRotationAngle.Name = "tbLiveRotationAngle";
            this.tbLiveRotationAngle.Size = new System.Drawing.Size(143, 45);
            this.tbLiveRotationAngle.TabIndex = 56;
            this.tbLiveRotationAngle.TickFrequency = 5;
            this.tbLiveRotationAngle.Value = 90;
            this.tbLiveRotationAngle.Scroll += new System.EventHandler(this.tbLiveRotationDegree_Scroll);
            // 
            // label390
            // 
            this.label390.AutoSize = true;
            this.label390.Location = new System.Drawing.Point(9, 44);
            this.label390.Name = "label390";
            this.label390.Size = new System.Drawing.Size(34, 13);
            this.label390.TabIndex = 55;
            this.label390.Text = "Angle";
            // 
            // cbLiveRotation
            // 
            this.cbLiveRotation.AutoSize = true;
            this.cbLiveRotation.Location = new System.Drawing.Point(12, 12);
            this.cbLiveRotation.Name = "cbLiveRotation";
            this.cbLiveRotation.Size = new System.Drawing.Size(65, 17);
            this.cbLiveRotation.TabIndex = 54;
            this.cbLiveRotation.Text = "Enabled";
            this.cbLiveRotation.UseVisualStyleBackColor = true;
            this.cbLiveRotation.CheckedChanged += new System.EventHandler(this.cbLiveRotation_CheckedChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(3, 107);
            this.tbContrast.Maximum = 255;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(130, 45);
            this.tbContrast.TabIndex = 49;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbDarkness.Location = new System.Drawing.Point(142, 107);
            this.tbDarkness.Maximum = 255;
            this.tbDarkness.Name = "tbDarkness";
            this.tbDarkness.Size = new System.Drawing.Size(130, 45);
            this.tbDarkness.TabIndex = 46;
            this.tbDarkness.Scroll += new System.EventHandler(this.tbDarkness_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbLightness.Location = new System.Drawing.Point(3, 51);
            this.tbLightness.Maximum = 255;
            this.tbLightness.Name = "tbLightness";
            this.tbLightness.Size = new System.Drawing.Size(130, 45);
            this.tbLightness.TabIndex = 45;
            this.tbLightness.Scroll += new System.EventHandler(this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(142, 51);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(130, 45);
            this.tbSaturation.TabIndex = 43;
            this.tbSaturation.Value = 255;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = true;
            this.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbInvert.Location = new System.Drawing.Point(90, 158);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.Size = new System.Drawing.Size(53, 17);
            this.cbInvert.TabIndex = 41;
            this.cbInvert.Text = "Invert";
            this.cbInvert.UseVisualStyleBackColor = true;
            this.cbInvert.CheckedChanged += new System.EventHandler(this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(10, 158);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbGreyscale.TabIndex = 39;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            this.cbGreyscale.CheckedChanged += new System.EventHandler(this.cbGreyscale_CheckedChanged);
            // 
            // cbVideoEffects
            // 
            this.cbVideoEffects.AutoSize = true;
            this.cbVideoEffects.Checked = true;
            this.cbVideoEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVideoEffects.Location = new System.Drawing.Point(8, 8);
            this.cbVideoEffects.Name = "cbVideoEffects";
            this.cbVideoEffects.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage69.Location = new System.Drawing.Point(4, 22);
            this.tabPage69.Name = "tabPage69";
            this.tabPage69.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage69.Size = new System.Drawing.Size(290, 459);
            this.tabPage69.TabIndex = 1;
            this.tabPage69.Text = "Deinterlace";
            this.tabPage69.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(100, 294);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(40, 13);
            this.label211.TabIndex = 28;
            this.label211.Text = "[0-255]";
            // 
            // edDeintTriangleWeight
            // 
            this.edDeintTriangleWeight.Location = new System.Drawing.Point(103, 270);
            this.edDeintTriangleWeight.Name = "edDeintTriangleWeight";
            this.edDeintTriangleWeight.Size = new System.Drawing.Size(32, 20);
            this.edDeintTriangleWeight.TabIndex = 27;
            this.edDeintTriangleWeight.Text = "180";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(34, 273);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(41, 13);
            this.label212.TabIndex = 26;
            this.label212.Text = "Weight";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(257, 192);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(27, 13);
            this.label210.TabIndex = 25;
            this.label210.Text = "/ 10";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(257, 159);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(27, 13);
            this.label209.TabIndex = 24;
            this.label209.Text = "/ 10";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(218, 213);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(46, 13);
            this.label206.TabIndex = 23;
            this.label206.Text = "[0.0-1.0]";
            // 
            // edDeintBlendConstants2
            // 
            this.edDeintBlendConstants2.Location = new System.Drawing.Point(221, 189);
            this.edDeintBlendConstants2.Name = "edDeintBlendConstants2";
            this.edDeintBlendConstants2.Size = new System.Drawing.Size(32, 20);
            this.edDeintBlendConstants2.TabIndex = 22;
            this.edDeintBlendConstants2.Text = "9";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(152, 192);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(63, 13);
            this.label207.TabIndex = 21;
            this.label207.Text = "Constants 2";
            // 
            // edDeintBlendConstants1
            // 
            this.edDeintBlendConstants1.Location = new System.Drawing.Point(221, 156);
            this.edDeintBlendConstants1.Name = "edDeintBlendConstants1";
            this.edDeintBlendConstants1.Size = new System.Drawing.Size(32, 20);
            this.edDeintBlendConstants1.TabIndex = 20;
            this.edDeintBlendConstants1.Text = "3";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(152, 159);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(63, 13);
            this.label208.TabIndex = 19;
            this.label208.Text = "Constants 1";
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(100, 213);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(40, 13);
            this.label204.TabIndex = 18;
            this.label204.Text = "[0-255]";
            // 
            // edDeintBlendThreshold2
            // 
            this.edDeintBlendThreshold2.Location = new System.Drawing.Point(103, 189);
            this.edDeintBlendThreshold2.Name = "edDeintBlendThreshold2";
            this.edDeintBlendThreshold2.Size = new System.Drawing.Size(32, 20);
            this.edDeintBlendThreshold2.TabIndex = 17;
            this.edDeintBlendThreshold2.Text = "9";
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(34, 192);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(63, 13);
            this.label205.TabIndex = 16;
            this.label205.Text = "Threshold 2";
            // 
            // edDeintBlendThreshold1
            // 
            this.edDeintBlendThreshold1.Location = new System.Drawing.Point(103, 156);
            this.edDeintBlendThreshold1.Name = "edDeintBlendThreshold1";
            this.edDeintBlendThreshold1.Size = new System.Drawing.Size(32, 20);
            this.edDeintBlendThreshold1.TabIndex = 15;
            this.edDeintBlendThreshold1.Text = "5";
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(34, 159);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(63, 13);
            this.label203.TabIndex = 14;
            this.label203.Text = "Threshold 1";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(100, 103);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(40, 13);
            this.label202.TabIndex = 13;
            this.label202.Text = "[0-255]";
            // 
            // edDeintCAVTThreshold
            // 
            this.edDeintCAVTThreshold.Location = new System.Drawing.Point(103, 79);
            this.edDeintCAVTThreshold.Name = "edDeintCAVTThreshold";
            this.edDeintCAVTThreshold.Size = new System.Drawing.Size(32, 20);
            this.edDeintCAVTThreshold.TabIndex = 12;
            this.edDeintCAVTThreshold.Text = "20";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(34, 82);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(54, 13);
            this.label104.TabIndex = 11;
            this.label104.Text = "Threshold";
            // 
            // rbDeintTriangleEnabled
            // 
            this.rbDeintTriangleEnabled.AutoSize = true;
            this.rbDeintTriangleEnabled.Location = new System.Drawing.Point(18, 243);
            this.rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled";
            this.rbDeintTriangleEnabled.Size = new System.Drawing.Size(63, 17);
            this.rbDeintTriangleEnabled.TabIndex = 10;
            this.rbDeintTriangleEnabled.Text = "Triangle";
            this.rbDeintTriangleEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintBlendEnabled
            // 
            this.rbDeintBlendEnabled.AutoSize = true;
            this.rbDeintBlendEnabled.Location = new System.Drawing.Point(18, 127);
            this.rbDeintBlendEnabled.Name = "rbDeintBlendEnabled";
            this.rbDeintBlendEnabled.Size = new System.Drawing.Size(52, 17);
            this.rbDeintBlendEnabled.TabIndex = 9;
            this.rbDeintBlendEnabled.Text = "Blend";
            this.rbDeintBlendEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintCAVTEnabled
            // 
            this.rbDeintCAVTEnabled.AutoSize = true;
            this.rbDeintCAVTEnabled.Checked = true;
            this.rbDeintCAVTEnabled.Location = new System.Drawing.Point(18, 52);
            this.rbDeintCAVTEnabled.Name = "rbDeintCAVTEnabled";
            this.rbDeintCAVTEnabled.Size = new System.Drawing.Size(229, 17);
            this.rbDeintCAVTEnabled.TabIndex = 8;
            this.rbDeintCAVTEnabled.TabStop = true;
            this.rbDeintCAVTEnabled.Text = "Content Adaptive Vertical Temporal (CAVT)";
            this.rbDeintCAVTEnabled.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlace
            // 
            this.cbDeinterlace.AutoSize = true;
            this.cbDeinterlace.Location = new System.Drawing.Point(18, 16);
            this.cbDeinterlace.Name = "cbDeinterlace";
            this.cbDeinterlace.Size = new System.Drawing.Size(65, 17);
            this.cbDeinterlace.TabIndex = 7;
            this.cbDeinterlace.Text = "Enabled";
            this.cbDeinterlace.UseVisualStyleBackColor = true;
            // 
            // tabPage59
            // 
            this.tabPage59.Controls.Add(this.rbDenoiseCAST);
            this.tabPage59.Controls.Add(this.rbDenoiseMosquito);
            this.tabPage59.Controls.Add(this.cbDenoise);
            this.tabPage59.Location = new System.Drawing.Point(4, 22);
            this.tabPage59.Name = "tabPage59";
            this.tabPage59.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage59.Size = new System.Drawing.Size(290, 459);
            this.tabPage59.TabIndex = 4;
            this.tabPage59.Text = "Denoise";
            this.tabPage59.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseCAST
            // 
            this.rbDenoiseCAST.AutoSize = true;
            this.rbDenoiseCAST.Location = new System.Drawing.Point(18, 79);
            this.rbDenoiseCAST.Name = "rbDenoiseCAST";
            this.rbDenoiseCAST.Size = new System.Drawing.Size(224, 17);
            this.rbDenoiseCAST.TabIndex = 10;
            this.rbDenoiseCAST.Text = "Content Adaptive Spatio-Temporal (CAST)";
            this.rbDenoiseCAST.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseMosquito
            // 
            this.rbDenoiseMosquito.AutoSize = true;
            this.rbDenoiseMosquito.Checked = true;
            this.rbDenoiseMosquito.Location = new System.Drawing.Point(18, 52);
            this.rbDenoiseMosquito.Name = "rbDenoiseMosquito";
            this.rbDenoiseMosquito.Size = new System.Drawing.Size(68, 17);
            this.rbDenoiseMosquito.TabIndex = 9;
            this.rbDenoiseMosquito.TabStop = true;
            this.rbDenoiseMosquito.Text = "Mosquito";
            this.rbDenoiseMosquito.UseVisualStyleBackColor = true;
            // 
            // cbDenoise
            // 
            this.cbDenoise.AutoSize = true;
            this.cbDenoise.Location = new System.Drawing.Point(18, 16);
            this.cbDenoise.Name = "cbDenoise";
            this.cbDenoise.Size = new System.Drawing.Size(65, 17);
            this.cbDenoise.TabIndex = 8;
            this.cbDenoise.Text = "Enabled";
            this.cbDenoise.UseVisualStyleBackColor = true;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.label5);
            this.tabPage20.Controls.Add(this.tbGPUBlur);
            this.tabPage20.Controls.Add(this.cbVideoEffectsGPUEnabled);
            this.tabPage20.Controls.Add(this.cbGPUOldMovie);
            this.tabPage20.Controls.Add(this.cbGPUDeinterlace);
            this.tabPage20.Controls.Add(this.cbGPUDenoise);
            this.tabPage20.Controls.Add(this.cbGPUPixelate);
            this.tabPage20.Controls.Add(this.cbGPUNightVision);
            this.tabPage20.Controls.Add(this.label383);
            this.tabPage20.Controls.Add(this.label384);
            this.tabPage20.Controls.Add(this.label385);
            this.tabPage20.Controls.Add(this.label386);
            this.tabPage20.Controls.Add(this.tbGPUContrast);
            this.tabPage20.Controls.Add(this.tbGPUDarkness);
            this.tabPage20.Controls.Add(this.tbGPULightness);
            this.tabPage20.Controls.Add(this.tbGPUSaturation);
            this.tabPage20.Controls.Add(this.cbGPUInvert);
            this.tabPage20.Controls.Add(this.cbGPUGreyscale);
            this.tabPage20.Location = new System.Drawing.Point(4, 22);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage20.Size = new System.Drawing.Size(290, 459);
            this.tabPage20.TabIndex = 9;
            this.tabPage20.Text = "GPU effects";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Blur";
            // 
            // tbGPUBlur
            // 
            this.tbGPUBlur.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUBlur.Location = new System.Drawing.Point(8, 311);
            this.tbGPUBlur.Maximum = 30;
            this.tbGPUBlur.Name = "tbGPUBlur";
            this.tbGPUBlur.Size = new System.Drawing.Size(130, 45);
            this.tbGPUBlur.TabIndex = 84;
            this.tbGPUBlur.Scroll += new System.EventHandler(this.tbGPUBlur_Scroll);
            // 
            // cbVideoEffectsGPUEnabled
            // 
            this.cbVideoEffectsGPUEnabled.AutoSize = true;
            this.cbVideoEffectsGPUEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled";
            this.cbVideoEffectsGPUEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbVideoEffectsGPUEnabled.TabIndex = 81;
            this.cbVideoEffectsGPUEnabled.Text = "Enabled";
            this.cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = true;
            // 
            // cbGPUOldMovie
            // 
            this.cbGPUOldMovie.AutoSize = true;
            this.cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUOldMovie.Location = new System.Drawing.Point(142, 237);
            this.cbGPUOldMovie.Name = "cbGPUOldMovie";
            this.cbGPUOldMovie.Size = new System.Drawing.Size(73, 17);
            this.cbGPUOldMovie.TabIndex = 80;
            this.cbGPUOldMovie.Text = "Old movie";
            this.cbGPUOldMovie.UseVisualStyleBackColor = true;
            this.cbGPUOldMovie.CheckedChanged += new System.EventHandler(this.cbGPUOldMovie_CheckedChanged);
            // 
            // cbGPUDeinterlace
            // 
            this.cbGPUDeinterlace.AutoSize = true;
            this.cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUDeinterlace.Location = new System.Drawing.Point(142, 213);
            this.cbGPUDeinterlace.Name = "cbGPUDeinterlace";
            this.cbGPUDeinterlace.Size = new System.Drawing.Size(80, 17);
            this.cbGPUDeinterlace.TabIndex = 78;
            this.cbGPUDeinterlace.Text = "Deinterlace";
            this.cbGPUDeinterlace.UseVisualStyleBackColor = true;
            this.cbGPUDeinterlace.CheckedChanged += new System.EventHandler(this.cbGPUDeinterlace_CheckedChanged);
            // 
            // cbGPUDenoise
            // 
            this.cbGPUDenoise.AutoSize = true;
            this.cbGPUDenoise.Location = new System.Drawing.Point(14, 213);
            this.cbGPUDenoise.Name = "cbGPUDenoise";
            this.cbGPUDenoise.Size = new System.Drawing.Size(65, 17);
            this.cbGPUDenoise.TabIndex = 77;
            this.cbGPUDenoise.Text = "Denoise";
            this.cbGPUDenoise.UseVisualStyleBackColor = true;
            this.cbGPUDenoise.CheckedChanged += new System.EventHandler(this.cbGPUDenoise_CheckedChanged);
            // 
            // cbGPUPixelate
            // 
            this.cbGPUPixelate.AutoSize = true;
            this.cbGPUPixelate.Location = new System.Drawing.Point(142, 190);
            this.cbGPUPixelate.Name = "cbGPUPixelate";
            this.cbGPUPixelate.Size = new System.Drawing.Size(63, 17);
            this.cbGPUPixelate.TabIndex = 76;
            this.cbGPUPixelate.Text = "Pixelate";
            this.cbGPUPixelate.UseVisualStyleBackColor = true;
            this.cbGPUPixelate.CheckedChanged += new System.EventHandler(this.cbGPUPixelate_CheckedChanged);
            // 
            // cbGPUNightVision
            // 
            this.cbGPUNightVision.AutoSize = true;
            this.cbGPUNightVision.Location = new System.Drawing.Point(14, 190);
            this.cbGPUNightVision.Name = "cbGPUNightVision";
            this.cbGPUNightVision.Size = new System.Drawing.Size(81, 17);
            this.cbGPUNightVision.TabIndex = 75;
            this.cbGPUNightVision.Text = "Night vision";
            this.cbGPUNightVision.UseVisualStyleBackColor = true;
            this.cbGPUNightVision.CheckedChanged += new System.EventHandler(this.cbGPUNightVision_CheckedChanged);
            // 
            // label383
            // 
            this.label383.AutoSize = true;
            this.label383.Location = new System.Drawing.Point(147, 97);
            this.label383.Name = "label383";
            this.label383.Size = new System.Drawing.Size(52, 13);
            this.label383.TabIndex = 74;
            this.label383.Text = "Darkness";
            // 
            // label384
            // 
            this.label384.AutoSize = true;
            this.label384.Location = new System.Drawing.Point(11, 97);
            this.label384.Name = "label384";
            this.label384.Size = new System.Drawing.Size(46, 13);
            this.label384.TabIndex = 73;
            this.label384.Text = "Contrast";
            // 
            // label385
            // 
            this.label385.AutoSize = true;
            this.label385.Location = new System.Drawing.Point(147, 45);
            this.label385.Name = "label385";
            this.label385.Size = new System.Drawing.Size(55, 13);
            this.label385.TabIndex = 72;
            this.label385.Text = "Saturation";
            // 
            // label386
            // 
            this.label386.AutoSize = true;
            this.label386.Location = new System.Drawing.Point(11, 45);
            this.label386.Name = "label386";
            this.label386.Size = new System.Drawing.Size(52, 13);
            this.label386.TabIndex = 71;
            this.label386.Text = "Lightness";
            // 
            // tbGPUContrast
            // 
            this.tbGPUContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUContrast.Location = new System.Drawing.Point(8, 116);
            this.tbGPUContrast.Maximum = 255;
            this.tbGPUContrast.Name = "tbGPUContrast";
            this.tbGPUContrast.Size = new System.Drawing.Size(130, 45);
            this.tbGPUContrast.TabIndex = 70;
            this.tbGPUContrast.Value = 255;
            this.tbGPUContrast.Scroll += new System.EventHandler(this.tbGPUContrast_Scroll);
            // 
            // tbGPUDarkness
            // 
            this.tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUDarkness.Location = new System.Drawing.Point(147, 116);
            this.tbGPUDarkness.Maximum = 255;
            this.tbGPUDarkness.Name = "tbGPUDarkness";
            this.tbGPUDarkness.Size = new System.Drawing.Size(130, 45);
            this.tbGPUDarkness.TabIndex = 69;
            this.tbGPUDarkness.Scroll += new System.EventHandler(this.tbGPUDarkness_Scroll);
            // 
            // tbGPULightness
            // 
            this.tbGPULightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPULightness.Location = new System.Drawing.Point(8, 60);
            this.tbGPULightness.Maximum = 255;
            this.tbGPULightness.Name = "tbGPULightness";
            this.tbGPULightness.Size = new System.Drawing.Size(130, 45);
            this.tbGPULightness.TabIndex = 68;
            this.tbGPULightness.Scroll += new System.EventHandler(this.tbGPULightness_Scroll);
            // 
            // tbGPUSaturation
            // 
            this.tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbGPUSaturation.Location = new System.Drawing.Point(147, 60);
            this.tbGPUSaturation.Maximum = 255;
            this.tbGPUSaturation.Name = "tbGPUSaturation";
            this.tbGPUSaturation.Size = new System.Drawing.Size(130, 45);
            this.tbGPUSaturation.TabIndex = 67;
            this.tbGPUSaturation.Value = 255;
            this.tbGPUSaturation.Scroll += new System.EventHandler(this.tbGPUSaturation_Scroll);
            // 
            // cbGPUInvert
            // 
            this.cbGPUInvert.AutoSize = true;
            this.cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbGPUInvert.Location = new System.Drawing.Point(142, 167);
            this.cbGPUInvert.Name = "cbGPUInvert";
            this.cbGPUInvert.Size = new System.Drawing.Size(53, 17);
            this.cbGPUInvert.TabIndex = 66;
            this.cbGPUInvert.Text = "Invert";
            this.cbGPUInvert.UseVisualStyleBackColor = true;
            this.cbGPUInvert.CheckedChanged += new System.EventHandler(this.cbGPUInvert_CheckedChanged);
            // 
            // cbGPUGreyscale
            // 
            this.cbGPUGreyscale.AutoSize = true;
            this.cbGPUGreyscale.Location = new System.Drawing.Point(14, 167);
            this.cbGPUGreyscale.Name = "cbGPUGreyscale";
            this.cbGPUGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbGPUGreyscale.TabIndex = 65;
            this.cbGPUGreyscale.Text = "Greyscale";
            this.cbGPUGreyscale.UseVisualStyleBackColor = true;
            this.cbGPUGreyscale.CheckedChanged += new System.EventHandler(this.cbGPUGreyscale_CheckedChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label92);
            this.tabPage9.Controls.Add(this.cbRotate);
            this.tabPage9.Controls.Add(this.edCropRight);
            this.tabPage9.Controls.Add(this.label52);
            this.tabPage9.Controls.Add(this.edCropBottom);
            this.tabPage9.Controls.Add(this.label53);
            this.tabPage9.Controls.Add(this.edCropLeft);
            this.tabPage9.Controls.Add(this.label50);
            this.tabPage9.Controls.Add(this.edCropTop);
            this.tabPage9.Controls.Add(this.label51);
            this.tabPage9.Controls.Add(this.cbCrop);
            this.tabPage9.Controls.Add(this.cbResizeMode);
            this.tabPage9.Controls.Add(this.label49);
            this.tabPage9.Controls.Add(this.cbResizeLetterbox);
            this.tabPage9.Controls.Add(this.edResizeHeight);
            this.tabPage9.Controls.Add(this.label35);
            this.tabPage9.Controls.Add(this.edResizeWidth);
            this.tabPage9.Controls.Add(this.label29);
            this.tabPage9.Controls.Add(this.cbResize);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage9.Size = new System.Drawing.Size(290, 459);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Resize / crop / rotate";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(9, 209);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(39, 13);
            this.label92.TabIndex = 150;
            this.label92.Text = "Rotate";
            // 
            // cbRotate
            // 
            this.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotate.FormattingEnabled = true;
            this.cbRotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbRotate.Location = new System.Drawing.Point(73, 206);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(121, 21);
            this.cbRotate.TabIndex = 149;
            // 
            // edCropRight
            // 
            this.edCropRight.Location = new System.Drawing.Point(168, 176);
            this.edCropRight.Name = "edCropRight";
            this.edCropRight.Size = new System.Drawing.Size(36, 20);
            this.edCropRight.TabIndex = 148;
            this.edCropRight.Text = "0";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(127, 180);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(32, 13);
            this.label52.TabIndex = 147;
            this.label52.Text = "Right";
            // 
            // edCropBottom
            // 
            this.edCropBottom.Location = new System.Drawing.Point(73, 176);
            this.edCropBottom.Name = "edCropBottom";
            this.edCropBottom.Size = new System.Drawing.Size(36, 20);
            this.edCropBottom.TabIndex = 146;
            this.edCropBottom.Text = "0";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(27, 180);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 13);
            this.label53.TabIndex = 145;
            this.label53.Text = "Bottom";
            // 
            // edCropLeft
            // 
            this.edCropLeft.Location = new System.Drawing.Point(168, 150);
            this.edCropLeft.Name = "edCropLeft";
            this.edCropLeft.Size = new System.Drawing.Size(36, 20);
            this.edCropLeft.TabIndex = 144;
            this.edCropLeft.Text = "0";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(127, 154);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(25, 13);
            this.label50.TabIndex = 143;
            this.label50.Text = "Left";
            // 
            // edCropTop
            // 
            this.edCropTop.Location = new System.Drawing.Point(73, 150);
            this.edCropTop.Name = "edCropTop";
            this.edCropTop.Size = new System.Drawing.Size(36, 20);
            this.edCropTop.TabIndex = 142;
            this.edCropTop.Text = "0";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(27, 154);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(26, 13);
            this.label51.TabIndex = 141;
            this.label51.Text = "Top";
            // 
            // cbCrop
            // 
            this.cbCrop.AutoSize = true;
            this.cbCrop.Location = new System.Drawing.Point(12, 128);
            this.cbCrop.Name = "cbCrop";
            this.cbCrop.Size = new System.Drawing.Size(48, 17);
            this.cbCrop.TabIndex = 140;
            this.cbCrop.Text = "Crop";
            this.cbCrop.UseVisualStyleBackColor = true;
            // 
            // cbResizeMode
            // 
            this.cbResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResizeMode.FormattingEnabled = true;
            this.cbResizeMode.Items.AddRange(new object[] {
            "Nearest Neighbor",
            "Bilinear",
            "Bicubic",
            "Lancroz"});
            this.cbResizeMode.Location = new System.Drawing.Point(62, 91);
            this.cbResizeMode.Name = "cbResizeMode";
            this.cbResizeMode.Size = new System.Drawing.Size(125, 21);
            this.cbResizeMode.TabIndex = 135;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(20, 94);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(34, 13);
            this.label49.TabIndex = 134;
            this.label49.Text = "Mode";
            // 
            // cbResizeLetterbox
            // 
            this.cbResizeLetterbox.AutoSize = true;
            this.cbResizeLetterbox.Location = new System.Drawing.Point(22, 65);
            this.cbResizeLetterbox.Name = "cbResizeLetterbox";
            this.cbResizeLetterbox.Size = new System.Drawing.Size(164, 17);
            this.cbResizeLetterbox.TabIndex = 133;
            this.cbResizeLetterbox.Text = "Letterbox (add black borders)";
            this.cbResizeLetterbox.UseVisualStyleBackColor = true;
            // 
            // edResizeHeight
            // 
            this.edResizeHeight.Location = new System.Drawing.Point(151, 36);
            this.edResizeHeight.Name = "edResizeHeight";
            this.edResizeHeight.Size = new System.Drawing.Size(36, 20);
            this.edResizeHeight.TabIndex = 132;
            this.edResizeHeight.Text = "576";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(104, 39);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(38, 13);
            this.label35.TabIndex = 131;
            this.label35.Text = "Height";
            // 
            // edResizeWidth
            // 
            this.edResizeWidth.Location = new System.Drawing.Point(62, 36);
            this.edResizeWidth.Name = "edResizeWidth";
            this.edResizeWidth.Size = new System.Drawing.Size(36, 20);
            this.edResizeWidth.TabIndex = 130;
            this.edResizeWidth.Text = "768";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(20, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 13);
            this.label29.TabIndex = 129;
            this.label29.Text = "Width";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Location = new System.Drawing.Point(12, 13);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(58, 17);
            this.cbResize.TabIndex = 128;
            this.cbResize.Text = "Resize";
            this.cbResize.UseVisualStyleBackColor = true;
            // 
            // tabPage60
            // 
            this.tabPage60.Controls.Add(this.pnChromaKeyColor);
            this.tabPage60.Controls.Add(this.btChromaKeySelectBGImage);
            this.tabPage60.Controls.Add(this.edChromaKeyImage);
            this.tabPage60.Controls.Add(this.label216);
            this.tabPage60.Controls.Add(this.label215);
            this.tabPage60.Controls.Add(this.tbChromaKeySmoothing);
            this.tabPage60.Controls.Add(this.label214);
            this.tabPage60.Controls.Add(this.tbChromaKeyThresholdSensitivity);
            this.tabPage60.Controls.Add(this.label213);
            this.tabPage60.Controls.Add(this.cbChromaKeyEnabled);
            this.tabPage60.Location = new System.Drawing.Point(4, 22);
            this.tabPage60.Name = "tabPage60";
            this.tabPage60.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage60.Size = new System.Drawing.Size(290, 459);
            this.tabPage60.TabIndex = 5;
            this.tabPage60.Text = "Chroma key";
            this.tabPage60.UseVisualStyleBackColor = true;
            // 
            // pnChromaKeyColor
            // 
            this.pnChromaKeyColor.BackColor = System.Drawing.Color.Lime;
            this.pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control;
            this.pnChromaKeyColor.Location = new System.Drawing.Point(57, 200);
            this.pnChromaKeyColor.Name = "pnChromaKeyColor";
            this.pnChromaKeyColor.Size = new System.Drawing.Size(26, 24);
            this.pnChromaKeyColor.TabIndex = 43;
            this.pnChromaKeyColor.Click += new System.EventHandler(this.pnChromaKeyColor_Click);
            // 
            // btChromaKeySelectBGImage
            // 
            this.btChromaKeySelectBGImage.Location = new System.Drawing.Point(257, 262);
            this.btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage";
            this.btChromaKeySelectBGImage.Size = new System.Drawing.Size(24, 23);
            this.btChromaKeySelectBGImage.TabIndex = 42;
            this.btChromaKeySelectBGImage.Text = "...";
            this.btChromaKeySelectBGImage.UseVisualStyleBackColor = true;
            this.btChromaKeySelectBGImage.Click += new System.EventHandler(this.btChromaKeySelectBGImage_Click);
            // 
            // edChromaKeyImage
            // 
            this.edChromaKeyImage.Location = new System.Drawing.Point(15, 264);
            this.edChromaKeyImage.Name = "edChromaKeyImage";
            this.edChromaKeyImage.Size = new System.Drawing.Size(235, 20);
            this.edChromaKeyImage.TabIndex = 41;
            this.edChromaKeyImage.Text = "c:\\Samples\\pics\\1.jpg";
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(12, 248);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(112, 13);
            this.label216.TabIndex = 40;
            this.label216.Text = "Image background file";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(12, 204);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(31, 13);
            this.label215.TabIndex = 39;
            this.label215.Text = "Color";
            // 
            // tbChromaKeySmoothing
            // 
            this.tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window;
            this.tbChromaKeySmoothing.Location = new System.Drawing.Point(15, 145);
            this.tbChromaKeySmoothing.Maximum = 1000;
            this.tbChromaKeySmoothing.Name = "tbChromaKeySmoothing";
            this.tbChromaKeySmoothing.Size = new System.Drawing.Size(154, 45);
            this.tbChromaKeySmoothing.TabIndex = 38;
            this.tbChromaKeySmoothing.Value = 80;
            this.tbChromaKeySmoothing.Scroll += new System.EventHandler(this.tbChromaKeySmoothing_Scroll);
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(12, 127);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(57, 13);
            this.label214.TabIndex = 37;
            this.label214.Text = "Smoothing";
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            this.tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window;
            this.tbChromaKeyThresholdSensitivity.Location = new System.Drawing.Point(15, 72);
            this.tbChromaKeyThresholdSensitivity.Maximum = 200;
            this.tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity";
            this.tbChromaKeyThresholdSensitivity.Size = new System.Drawing.Size(154, 45);
            this.tbChromaKeyThresholdSensitivity.TabIndex = 36;
            this.tbChromaKeyThresholdSensitivity.Value = 180;
            this.tbChromaKeyThresholdSensitivity.Scroll += new System.EventHandler(this.tbChromaKeyThresholdSensitivity_Scroll);
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(12, 54);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(102, 13);
            this.label213.TabIndex = 35;
            this.label213.Text = "Threshold sensitivity";
            // 
            // cbChromaKeyEnabled
            // 
            this.cbChromaKeyEnabled.AutoSize = true;
            this.cbChromaKeyEnabled.Location = new System.Drawing.Point(15, 15);
            this.cbChromaKeyEnabled.Name = "cbChromaKeyEnabled";
            this.cbChromaKeyEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbChromaKeyEnabled.TabIndex = 34;
            this.cbChromaKeyEnabled.Text = "Enabled";
            this.cbChromaKeyEnabled.UseVisualStyleBackColor = true;
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
            this.tabPage70.Location = new System.Drawing.Point(4, 22);
            this.tabPage70.Name = "tabPage70";
            this.tabPage70.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage70.Size = new System.Drawing.Size(290, 459);
            this.tabPage70.TabIndex = 3;
            this.tabPage70.Text = "3rd-party filters";
            this.tabPage70.UseVisualStyleBackColor = true;
            // 
            // btFilterDeleteAll
            // 
            this.btFilterDeleteAll.Location = new System.Drawing.Point(210, 287);
            this.btFilterDeleteAll.Name = "btFilterDeleteAll";
            this.btFilterDeleteAll.Size = new System.Drawing.Size(68, 23);
            this.btFilterDeleteAll.TabIndex = 16;
            this.btFilterDeleteAll.Text = "Delete all";
            this.btFilterDeleteAll.UseVisualStyleBackColor = true;
            this.btFilterDeleteAll.Click += new System.EventHandler(this.btFilterDeleteAll_Click);
            // 
            // btFilterSettings2
            // 
            this.btFilterSettings2.Location = new System.Drawing.Point(18, 287);
            this.btFilterSettings2.Name = "btFilterSettings2";
            this.btFilterSettings2.Size = new System.Drawing.Size(65, 23);
            this.btFilterSettings2.TabIndex = 15;
            this.btFilterSettings2.Text = "Settings";
            this.btFilterSettings2.UseVisualStyleBackColor = true;
            this.btFilterSettings2.Click += new System.EventHandler(this.btFilterSettings2_Click);
            // 
            // lbFilters
            // 
            this.lbFilters.FormattingEnabled = true;
            this.lbFilters.Location = new System.Drawing.Point(18, 121);
            this.lbFilters.Name = "lbFilters";
            this.lbFilters.Size = new System.Drawing.Size(260, 160);
            this.lbFilters.TabIndex = 14;
            this.lbFilters.SelectedIndexChanged += new System.EventHandler(this.lbFilters_SelectedIndexChanged);
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(15, 105);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(68, 13);
            this.label106.TabIndex = 13;
            this.label106.Text = "Current filters";
            // 
            // btFilterSettings
            // 
            this.btFilterSettings.Location = new System.Drawing.Point(210, 57);
            this.btFilterSettings.Name = "btFilterSettings";
            this.btFilterSettings.Size = new System.Drawing.Size(68, 23);
            this.btFilterSettings.TabIndex = 12;
            this.btFilterSettings.Text = "Settings";
            this.btFilterSettings.UseVisualStyleBackColor = true;
            this.btFilterSettings.Click += new System.EventHandler(this.btFilterSettings_Click);
            // 
            // btFilterAdd
            // 
            this.btFilterAdd.Location = new System.Drawing.Point(18, 57);
            this.btFilterAdd.Name = "btFilterAdd";
            this.btFilterAdd.Size = new System.Drawing.Size(39, 23);
            this.btFilterAdd.TabIndex = 11;
            this.btFilterAdd.Text = "Add";
            this.btFilterAdd.UseVisualStyleBackColor = true;
            this.btFilterAdd.Click += new System.EventHandler(this.btFilterAdd_Click);
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(18, 30);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(260, 21);
            this.cbFilters.TabIndex = 10;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(15, 14);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(34, 13);
            this.label105.TabIndex = 9;
            this.label105.Text = "Filters";
            // 
            // tabControl14
            // 
            this.tabControl14.Controls.Add(this.tabPage5);
            this.tabControl14.Controls.Add(this.tabPage58);
            this.tabControl14.Location = new System.Drawing.Point(284, 7);
            this.tabControl14.Name = "tabControl14";
            this.tabControl14.SelectedIndex = 0;
            this.tabControl14.Size = new System.Drawing.Size(17, 46);
            this.tabControl14.TabIndex = 36;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(9, 20);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage58
            // 
            this.tabPage58.Location = new System.Drawing.Point(4, 22);
            this.tabPage58.Name = "tabPage58";
            this.tabPage58.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage58.Size = new System.Drawing.Size(9, 20);
            this.tabPage58.TabIndex = 1;
            this.tabPage58.Text = "tabPage58";
            this.tabPage58.UseVisualStyleBackColor = true;
            // 
            // tabPage127
            // 
            this.tabPage127.Controls.Add(this.lbAudioTimeshift);
            this.tabPage127.Controls.Add(this.tbAudioTimeshift);
            this.tabPage127.Controls.Add(this.label439);
            this.tabPage127.Controls.Add(this.groupBox3);
            this.tabPage127.Controls.Add(this.groupBox7);
            this.tabPage127.Controls.Add(this.cbAudioAutoGain);
            this.tabPage127.Controls.Add(this.cbAudioNormalize);
            this.tabPage127.Controls.Add(this.cbAudioEnhancementEnabled);
            this.tabPage127.Location = new System.Drawing.Point(4, 22);
            this.tabPage127.Name = "tabPage127";
            this.tabPage127.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage127.Size = new System.Drawing.Size(307, 484);
            this.tabPage127.TabIndex = 18;
            this.tabPage127.Text = "Audio enhancement";
            this.tabPage127.UseVisualStyleBackColor = true;
            // 
            // lbAudioTimeshift
            // 
            this.lbAudioTimeshift.AutoSize = true;
            this.lbAudioTimeshift.Location = new System.Drawing.Point(177, 443);
            this.lbAudioTimeshift.Name = "lbAudioTimeshift";
            this.lbAudioTimeshift.Size = new System.Drawing.Size(29, 13);
            this.lbAudioTimeshift.TabIndex = 13;
            this.lbAudioTimeshift.Text = "0 ms";
            // 
            // tbAudioTimeshift
            // 
            this.tbAudioTimeshift.Location = new System.Drawing.Point(67, 432);
            this.tbAudioTimeshift.Maximum = 3000;
            this.tbAudioTimeshift.Name = "tbAudioTimeshift";
            this.tbAudioTimeshift.Size = new System.Drawing.Size(104, 45);
            this.tbAudioTimeshift.SmallChange = 10;
            this.tbAudioTimeshift.TabIndex = 12;
            this.tbAudioTimeshift.TickFrequency = 100;
            this.tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioTimeshift.Scroll += new System.EventHandler(this.tbAudioTimeshift_Scroll);
            // 
            // label439
            // 
            this.label439.AutoSize = true;
            this.label439.Location = new System.Drawing.Point(6, 443);
            this.label439.Name = "label439";
            this.label439.Size = new System.Drawing.Size(52, 13);
            this.label439.TabIndex = 11;
            this.label439.Text = "Time shift";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbAudioOutputGainLFE);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainLFE);
            this.groupBox3.Controls.Add(this.label440);
            this.groupBox3.Controls.Add(this.lbAudioOutputGainSR);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainSR);
            this.groupBox3.Controls.Add(this.label441);
            this.groupBox3.Controls.Add(this.lbAudioOutputGainSL);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainSL);
            this.groupBox3.Controls.Add(this.label442);
            this.groupBox3.Controls.Add(this.lbAudioOutputGainR);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainR);
            this.groupBox3.Controls.Add(this.label443);
            this.groupBox3.Controls.Add(this.lbAudioOutputGainC);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainC);
            this.groupBox3.Controls.Add(this.label444);
            this.groupBox3.Controls.Add(this.lbAudioOutputGainL);
            this.groupBox3.Controls.Add(this.tbAudioOutputGainL);
            this.groupBox3.Controls.Add(this.label445);
            this.groupBox3.Location = new System.Drawing.Point(9, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 172);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output gains (dB)";
            // 
            // lbAudioOutputGainLFE
            // 
            this.lbAudioOutputGainLFE.AutoSize = true;
            this.lbAudioOutputGainLFE.Location = new System.Drawing.Point(249, 148);
            this.lbAudioOutputGainLFE.Name = "lbAudioOutputGainLFE";
            this.lbAudioOutputGainLFE.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainLFE.TabIndex = 17;
            this.lbAudioOutputGainLFE.Text = "0.0";
            // 
            // tbAudioOutputGainLFE
            // 
            this.tbAudioOutputGainLFE.Location = new System.Drawing.Point(242, 41);
            this.tbAudioOutputGainLFE.Maximum = 200;
            this.tbAudioOutputGainLFE.Minimum = -200;
            this.tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE";
            this.tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainLFE.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainLFE.TabIndex = 16;
            this.tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainLFE.Scroll += new System.EventHandler(this.tbAudioOutputGainLFE_Scroll);
            // 
            // label440
            // 
            this.label440.AutoSize = true;
            this.label440.Location = new System.Drawing.Point(250, 25);
            this.label440.Name = "label440";
            this.label440.Size = new System.Drawing.Size(26, 13);
            this.label440.TabIndex = 15;
            this.label440.Text = "LFE";
            // 
            // lbAudioOutputGainSR
            // 
            this.lbAudioOutputGainSR.AutoSize = true;
            this.lbAudioOutputGainSR.Location = new System.Drawing.Point(201, 148);
            this.lbAudioOutputGainSR.Name = "lbAudioOutputGainSR";
            this.lbAudioOutputGainSR.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainSR.TabIndex = 14;
            this.lbAudioOutputGainSR.Text = "0.0";
            // 
            // tbAudioOutputGainSR
            // 
            this.tbAudioOutputGainSR.Location = new System.Drawing.Point(194, 41);
            this.tbAudioOutputGainSR.Maximum = 200;
            this.tbAudioOutputGainSR.Minimum = -200;
            this.tbAudioOutputGainSR.Name = "tbAudioOutputGainSR";
            this.tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainSR.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainSR.TabIndex = 13;
            this.tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainSR.Scroll += new System.EventHandler(this.tbAudioOutputGainSR_Scroll);
            // 
            // label441
            // 
            this.label441.AutoSize = true;
            this.label441.Location = new System.Drawing.Point(205, 25);
            this.label441.Name = "label441";
            this.label441.Size = new System.Drawing.Size(22, 13);
            this.label441.TabIndex = 12;
            this.label441.Text = "SR";
            // 
            // lbAudioOutputGainSL
            // 
            this.lbAudioOutputGainSL.AutoSize = true;
            this.lbAudioOutputGainSL.Location = new System.Drawing.Point(153, 148);
            this.lbAudioOutputGainSL.Name = "lbAudioOutputGainSL";
            this.lbAudioOutputGainSL.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainSL.TabIndex = 11;
            this.lbAudioOutputGainSL.Text = "0.0";
            // 
            // tbAudioOutputGainSL
            // 
            this.tbAudioOutputGainSL.Location = new System.Drawing.Point(146, 41);
            this.tbAudioOutputGainSL.Maximum = 200;
            this.tbAudioOutputGainSL.Minimum = -200;
            this.tbAudioOutputGainSL.Name = "tbAudioOutputGainSL";
            this.tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainSL.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainSL.TabIndex = 10;
            this.tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainSL.Scroll += new System.EventHandler(this.tbAudioOutputGainSL_Scroll);
            // 
            // label442
            // 
            this.label442.AutoSize = true;
            this.label442.Location = new System.Drawing.Point(158, 25);
            this.label442.Name = "label442";
            this.label442.Size = new System.Drawing.Size(20, 13);
            this.label442.TabIndex = 9;
            this.label442.Text = "SL";
            // 
            // lbAudioOutputGainR
            // 
            this.lbAudioOutputGainR.AutoSize = true;
            this.lbAudioOutputGainR.Location = new System.Drawing.Point(105, 148);
            this.lbAudioOutputGainR.Name = "lbAudioOutputGainR";
            this.lbAudioOutputGainR.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainR.TabIndex = 8;
            this.lbAudioOutputGainR.Text = "0.0";
            // 
            // tbAudioOutputGainR
            // 
            this.tbAudioOutputGainR.Location = new System.Drawing.Point(98, 41);
            this.tbAudioOutputGainR.Maximum = 200;
            this.tbAudioOutputGainR.Minimum = -200;
            this.tbAudioOutputGainR.Name = "tbAudioOutputGainR";
            this.tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainR.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainR.TabIndex = 7;
            this.tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainR.Scroll += new System.EventHandler(this.tbAudioOutputGainR_Scroll);
            // 
            // label443
            // 
            this.label443.AutoSize = true;
            this.label443.Location = new System.Drawing.Point(114, 25);
            this.label443.Name = "label443";
            this.label443.Size = new System.Drawing.Size(15, 13);
            this.label443.TabIndex = 6;
            this.label443.Text = "R";
            // 
            // lbAudioOutputGainC
            // 
            this.lbAudioOutputGainC.AutoSize = true;
            this.lbAudioOutputGainC.Location = new System.Drawing.Point(57, 148);
            this.lbAudioOutputGainC.Name = "lbAudioOutputGainC";
            this.lbAudioOutputGainC.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainC.TabIndex = 5;
            this.lbAudioOutputGainC.Text = "0.0";
            // 
            // tbAudioOutputGainC
            // 
            this.tbAudioOutputGainC.Location = new System.Drawing.Point(50, 41);
            this.tbAudioOutputGainC.Maximum = 200;
            this.tbAudioOutputGainC.Minimum = -200;
            this.tbAudioOutputGainC.Name = "tbAudioOutputGainC";
            this.tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainC.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainC.TabIndex = 4;
            this.tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainC.Scroll += new System.EventHandler(this.tbAudioOutputGainC_Scroll);
            // 
            // label444
            // 
            this.label444.AutoSize = true;
            this.label444.Location = new System.Drawing.Point(66, 25);
            this.label444.Name = "label444";
            this.label444.Size = new System.Drawing.Size(14, 13);
            this.label444.TabIndex = 3;
            this.label444.Text = "C";
            // 
            // lbAudioOutputGainL
            // 
            this.lbAudioOutputGainL.AutoSize = true;
            this.lbAudioOutputGainL.Location = new System.Drawing.Point(9, 148);
            this.lbAudioOutputGainL.Name = "lbAudioOutputGainL";
            this.lbAudioOutputGainL.Size = new System.Drawing.Size(22, 13);
            this.lbAudioOutputGainL.TabIndex = 2;
            this.lbAudioOutputGainL.Text = "0.0";
            // 
            // tbAudioOutputGainL
            // 
            this.tbAudioOutputGainL.Location = new System.Drawing.Point(2, 41);
            this.tbAudioOutputGainL.Maximum = 200;
            this.tbAudioOutputGainL.Minimum = -200;
            this.tbAudioOutputGainL.Name = "tbAudioOutputGainL";
            this.tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioOutputGainL.Size = new System.Drawing.Size(45, 104);
            this.tbAudioOutputGainL.TabIndex = 1;
            this.tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioOutputGainL.Scroll += new System.EventHandler(this.tbAudioOutputGainL_Scroll);
            // 
            // label445
            // 
            this.label445.AutoSize = true;
            this.label445.Location = new System.Drawing.Point(18, 25);
            this.label445.Name = "label445";
            this.label445.Size = new System.Drawing.Size(13, 13);
            this.label445.TabIndex = 0;
            this.label445.Text = "L";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbAudioInputGainLFE);
            this.groupBox7.Controls.Add(this.tbAudioInputGainLFE);
            this.groupBox7.Controls.Add(this.label446);
            this.groupBox7.Controls.Add(this.lbAudioInputGainSR);
            this.groupBox7.Controls.Add(this.tbAudioInputGainSR);
            this.groupBox7.Controls.Add(this.label447);
            this.groupBox7.Controls.Add(this.lbAudioInputGainSL);
            this.groupBox7.Controls.Add(this.tbAudioInputGainSL);
            this.groupBox7.Controls.Add(this.label448);
            this.groupBox7.Controls.Add(this.lbAudioInputGainR);
            this.groupBox7.Controls.Add(this.tbAudioInputGainR);
            this.groupBox7.Controls.Add(this.label449);
            this.groupBox7.Controls.Add(this.lbAudioInputGainC);
            this.groupBox7.Controls.Add(this.tbAudioInputGainC);
            this.groupBox7.Controls.Add(this.label450);
            this.groupBox7.Controls.Add(this.lbAudioInputGainL);
            this.groupBox7.Controls.Add(this.tbAudioInputGainL);
            this.groupBox7.Controls.Add(this.label451);
            this.groupBox7.Location = new System.Drawing.Point(9, 74);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(289, 172);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Input gains (dB)";
            // 
            // lbAudioInputGainLFE
            // 
            this.lbAudioInputGainLFE.AutoSize = true;
            this.lbAudioInputGainLFE.Location = new System.Drawing.Point(249, 148);
            this.lbAudioInputGainLFE.Name = "lbAudioInputGainLFE";
            this.lbAudioInputGainLFE.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainLFE.TabIndex = 17;
            this.lbAudioInputGainLFE.Text = "0.0";
            // 
            // tbAudioInputGainLFE
            // 
            this.tbAudioInputGainLFE.Location = new System.Drawing.Point(242, 41);
            this.tbAudioInputGainLFE.Maximum = 200;
            this.tbAudioInputGainLFE.Minimum = -200;
            this.tbAudioInputGainLFE.Name = "tbAudioInputGainLFE";
            this.tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainLFE.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainLFE.TabIndex = 16;
            this.tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainLFE.Scroll += new System.EventHandler(this.tbAudioInputGainLFE_Scroll);
            // 
            // label446
            // 
            this.label446.AutoSize = true;
            this.label446.Location = new System.Drawing.Point(250, 25);
            this.label446.Name = "label446";
            this.label446.Size = new System.Drawing.Size(26, 13);
            this.label446.TabIndex = 15;
            this.label446.Text = "LFE";
            // 
            // lbAudioInputGainSR
            // 
            this.lbAudioInputGainSR.AutoSize = true;
            this.lbAudioInputGainSR.Location = new System.Drawing.Point(201, 148);
            this.lbAudioInputGainSR.Name = "lbAudioInputGainSR";
            this.lbAudioInputGainSR.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainSR.TabIndex = 14;
            this.lbAudioInputGainSR.Text = "0.0";
            // 
            // tbAudioInputGainSR
            // 
            this.tbAudioInputGainSR.Location = new System.Drawing.Point(194, 41);
            this.tbAudioInputGainSR.Maximum = 200;
            this.tbAudioInputGainSR.Minimum = -200;
            this.tbAudioInputGainSR.Name = "tbAudioInputGainSR";
            this.tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainSR.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainSR.TabIndex = 13;
            this.tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainSR.Scroll += new System.EventHandler(this.tbAudioInputGainSR_Scroll);
            // 
            // label447
            // 
            this.label447.AutoSize = true;
            this.label447.Location = new System.Drawing.Point(205, 25);
            this.label447.Name = "label447";
            this.label447.Size = new System.Drawing.Size(22, 13);
            this.label447.TabIndex = 12;
            this.label447.Text = "SR";
            // 
            // lbAudioInputGainSL
            // 
            this.lbAudioInputGainSL.AutoSize = true;
            this.lbAudioInputGainSL.Location = new System.Drawing.Point(153, 148);
            this.lbAudioInputGainSL.Name = "lbAudioInputGainSL";
            this.lbAudioInputGainSL.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainSL.TabIndex = 11;
            this.lbAudioInputGainSL.Text = "0.0";
            // 
            // tbAudioInputGainSL
            // 
            this.tbAudioInputGainSL.Location = new System.Drawing.Point(146, 41);
            this.tbAudioInputGainSL.Maximum = 200;
            this.tbAudioInputGainSL.Minimum = -200;
            this.tbAudioInputGainSL.Name = "tbAudioInputGainSL";
            this.tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainSL.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainSL.TabIndex = 10;
            this.tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainSL.Scroll += new System.EventHandler(this.tbAudioInputGainSL_Scroll);
            // 
            // label448
            // 
            this.label448.AutoSize = true;
            this.label448.Location = new System.Drawing.Point(158, 25);
            this.label448.Name = "label448";
            this.label448.Size = new System.Drawing.Size(20, 13);
            this.label448.TabIndex = 9;
            this.label448.Text = "SL";
            // 
            // lbAudioInputGainR
            // 
            this.lbAudioInputGainR.AutoSize = true;
            this.lbAudioInputGainR.Location = new System.Drawing.Point(105, 148);
            this.lbAudioInputGainR.Name = "lbAudioInputGainR";
            this.lbAudioInputGainR.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainR.TabIndex = 8;
            this.lbAudioInputGainR.Text = "0.0";
            // 
            // tbAudioInputGainR
            // 
            this.tbAudioInputGainR.Location = new System.Drawing.Point(98, 41);
            this.tbAudioInputGainR.Maximum = 200;
            this.tbAudioInputGainR.Minimum = -200;
            this.tbAudioInputGainR.Name = "tbAudioInputGainR";
            this.tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainR.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainR.TabIndex = 7;
            this.tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainR.Scroll += new System.EventHandler(this.tbAudioInputGainR_Scroll);
            // 
            // label449
            // 
            this.label449.AutoSize = true;
            this.label449.Location = new System.Drawing.Point(114, 25);
            this.label449.Name = "label449";
            this.label449.Size = new System.Drawing.Size(15, 13);
            this.label449.TabIndex = 6;
            this.label449.Text = "R";
            // 
            // lbAudioInputGainC
            // 
            this.lbAudioInputGainC.AutoSize = true;
            this.lbAudioInputGainC.Location = new System.Drawing.Point(57, 148);
            this.lbAudioInputGainC.Name = "lbAudioInputGainC";
            this.lbAudioInputGainC.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainC.TabIndex = 5;
            this.lbAudioInputGainC.Text = "0.0";
            // 
            // tbAudioInputGainC
            // 
            this.tbAudioInputGainC.Location = new System.Drawing.Point(50, 41);
            this.tbAudioInputGainC.Maximum = 200;
            this.tbAudioInputGainC.Minimum = -200;
            this.tbAudioInputGainC.Name = "tbAudioInputGainC";
            this.tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainC.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainC.TabIndex = 4;
            this.tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainC.Scroll += new System.EventHandler(this.tbAudioInputGainC_Scroll);
            // 
            // label450
            // 
            this.label450.AutoSize = true;
            this.label450.Location = new System.Drawing.Point(66, 25);
            this.label450.Name = "label450";
            this.label450.Size = new System.Drawing.Size(14, 13);
            this.label450.TabIndex = 3;
            this.label450.Text = "C";
            // 
            // lbAudioInputGainL
            // 
            this.lbAudioInputGainL.AutoSize = true;
            this.lbAudioInputGainL.Location = new System.Drawing.Point(9, 148);
            this.lbAudioInputGainL.Name = "lbAudioInputGainL";
            this.lbAudioInputGainL.Size = new System.Drawing.Size(22, 13);
            this.lbAudioInputGainL.TabIndex = 2;
            this.lbAudioInputGainL.Text = "0.0";
            // 
            // tbAudioInputGainL
            // 
            this.tbAudioInputGainL.Location = new System.Drawing.Point(2, 41);
            this.tbAudioInputGainL.Maximum = 200;
            this.tbAudioInputGainL.Minimum = -200;
            this.tbAudioInputGainL.Name = "tbAudioInputGainL";
            this.tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudioInputGainL.Size = new System.Drawing.Size(45, 104);
            this.tbAudioInputGainL.TabIndex = 1;
            this.tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAudioInputGainL.Scroll += new System.EventHandler(this.tbAudioInputGainL_Scroll);
            // 
            // label451
            // 
            this.label451.AutoSize = true;
            this.label451.Location = new System.Drawing.Point(18, 25);
            this.label451.Name = "label451";
            this.label451.Size = new System.Drawing.Size(13, 13);
            this.label451.TabIndex = 0;
            this.label451.Text = "L";
            // 
            // cbAudioAutoGain
            // 
            this.cbAudioAutoGain.AutoSize = true;
            this.cbAudioAutoGain.Location = new System.Drawing.Point(136, 51);
            this.cbAudioAutoGain.Name = "cbAudioAutoGain";
            this.cbAudioAutoGain.Size = new System.Drawing.Size(71, 17);
            this.cbAudioAutoGain.TabIndex = 8;
            this.cbAudioAutoGain.Text = "Auto gain";
            this.cbAudioAutoGain.UseVisualStyleBackColor = true;
            this.cbAudioAutoGain.CheckedChanged += new System.EventHandler(this.cbAudioAutoGain_CheckedChanged);
            // 
            // cbAudioNormalize
            // 
            this.cbAudioNormalize.AutoSize = true;
            this.cbAudioNormalize.Location = new System.Drawing.Point(42, 51);
            this.cbAudioNormalize.Name = "cbAudioNormalize";
            this.cbAudioNormalize.Size = new System.Drawing.Size(72, 17);
            this.cbAudioNormalize.TabIndex = 7;
            this.cbAudioNormalize.Text = "Normalize";
            this.cbAudioNormalize.UseVisualStyleBackColor = true;
            this.cbAudioNormalize.CheckedChanged += new System.EventHandler(this.cbAudioNormalize_CheckedChanged);
            // 
            // cbAudioEnhancementEnabled
            // 
            this.cbAudioEnhancementEnabled.AutoSize = true;
            this.cbAudioEnhancementEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled";
            this.cbAudioEnhancementEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbAudioEnhancementEnabled.TabIndex = 6;
            this.cbAudioEnhancementEnabled.Text = "Enabled";
            this.cbAudioEnhancementEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.label250);
            this.tabPage27.Controls.Add(this.tabControl18);
            this.tabPage27.Controls.Add(this.cbAudioEffectsEnabled);
            this.tabPage27.Location = new System.Drawing.Point(4, 22);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage27.Size = new System.Drawing.Size(307, 484);
            this.tabPage27.TabIndex = 12;
            this.tabPage27.Text = "Audio effects";
            this.tabPage27.UseVisualStyleBackColor = true;
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Location = new System.Drawing.Point(100, 17);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(188, 13);
            this.label250.TabIndex = 5;
            this.label250.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage73);
            this.tabControl18.Controls.Add(this.tabPage75);
            this.tabControl18.Controls.Add(this.tabPage76);
            this.tabControl18.Location = new System.Drawing.Point(14, 39);
            this.tabControl18.Name = "tabControl18";
            this.tabControl18.SelectedIndex = 0;
            this.tabControl18.Size = new System.Drawing.Size(283, 442);
            this.tabControl18.TabIndex = 1;
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.label231);
            this.tabPage71.Controls.Add(this.label230);
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = new System.Drawing.Point(4, 22);
            this.tabPage71.Name = "tabPage71";
            this.tabPage71.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage71.Size = new System.Drawing.Size(275, 416);
            this.tabPage71.TabIndex = 0;
            this.tabPage71.Text = "Amplify";
            this.tabPage71.UseVisualStyleBackColor = true;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Location = new System.Drawing.Point(213, 53);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(33, 13);
            this.label231.TabIndex = 5;
            this.label231.Text = "400%";
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(68, 53);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(33, 13);
            this.label230.TabIndex = 4;
            this.label230.Text = "100%";
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAmplifyAmp.Location = new System.Drawing.Point(16, 69);
            this.tbAudAmplifyAmp.Maximum = 4000;
            this.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            this.tbAudAmplifyAmp.Size = new System.Drawing.Size(230, 45);
            this.tbAudAmplifyAmp.TabIndex = 3;
            this.tbAudAmplifyAmp.TickFrequency = 50;
            this.tbAudAmplifyAmp.Value = 1000;
            this.tbAudAmplifyAmp.Scroll += new System.EventHandler(this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(13, 53);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(42, 13);
            this.label95.TabIndex = 2;
            this.label95.Text = "Volume";
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = true;
            this.cbAudAmplifyEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            this.cbAudAmplifyEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage72.Location = new System.Drawing.Point(4, 22);
            this.tabPage72.Name = "tabPage72";
            this.tabPage72.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage72.Size = new System.Drawing.Size(275, 416);
            this.tabPage72.TabIndex = 1;
            this.tabPage72.Text = "Equlizer";
            this.tabPage72.UseVisualStyleBackColor = true;
            // 
            // btAudEqRefresh
            // 
            this.btAudEqRefresh.Location = new System.Drawing.Point(175, 219);
            this.btAudEqRefresh.Name = "btAudEqRefresh";
            this.btAudEqRefresh.Size = new System.Drawing.Size(75, 23);
            this.btAudEqRefresh.TabIndex = 26;
            this.btAudEqRefresh.Text = "Refresh";
            this.btAudEqRefresh.UseVisualStyleBackColor = true;
            this.btAudEqRefresh.Click += new System.EventHandler(this.btAudEqRefresh_Click);
            // 
            // cbAudEqualizerPreset
            // 
            this.cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudEqualizerPreset.FormattingEnabled = true;
            this.cbAudEqualizerPreset.Location = new System.Drawing.Point(61, 180);
            this.cbAudEqualizerPreset.Name = "cbAudEqualizerPreset";
            this.cbAudEqualizerPreset.Size = new System.Drawing.Size(189, 21);
            this.cbAudEqualizerPreset.TabIndex = 25;
            this.cbAudEqualizerPreset.SelectedIndexChanged += new System.EventHandler(this.cbAudEqualizerPreset_SelectedIndexChanged);
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Location = new System.Drawing.Point(14, 183);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(37, 13);
            this.label243.TabIndex = 24;
            this.label243.Text = "Preset";
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(206, 156);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(26, 13);
            this.label242.TabIndex = 23;
            this.label242.Text = "16K";
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(184, 156);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(26, 13);
            this.label241.TabIndex = 22;
            this.label241.Text = "14K";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(162, 156);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(26, 13);
            this.label240.TabIndex = 21;
            this.label240.Text = "12K";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(143, 156);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(20, 13);
            this.label239.TabIndex = 20;
            this.label239.Text = "6K";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(121, 156);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(20, 13);
            this.label238.TabIndex = 19;
            this.label238.Text = "3K";
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(102, 156);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(20, 13);
            this.label237.TabIndex = 18;
            this.label237.Text = "1K";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(80, 156);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(25, 13);
            this.label236.TabIndex = 17;
            this.label236.Text = "600";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(58, 156);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(25, 13);
            this.label235.TabIndex = 16;
            this.label235.Text = "310";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(36, 156);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(25, 13);
            this.label234.TabIndex = 15;
            this.label234.Text = "170";
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(18, 156);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(19, 13);
            this.label233.TabIndex = 14;
            this.label233.Text = "60";
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Location = new System.Drawing.Point(118, 33);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(13, 13);
            this.label232.TabIndex = 13;
            this.label232.Text = "0";
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq9.Location = new System.Drawing.Point(205, 49);
            this.tbAudEq9.Maximum = 100;
            this.tbAudEq9.Minimum = -100;
            this.tbAudEq9.Name = "tbAudEq9";
            this.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq9.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq9.TabIndex = 12;
            this.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq9.Scroll += new System.EventHandler(this.tbAudEq9_Scroll);
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq8.Location = new System.Drawing.Point(184, 49);
            this.tbAudEq8.Maximum = 100;
            this.tbAudEq8.Minimum = -100;
            this.tbAudEq8.Name = "tbAudEq8";
            this.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq8.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq8.TabIndex = 11;
            this.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq8.Scroll += new System.EventHandler(this.tbAudEq8_Scroll);
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq7.Location = new System.Drawing.Point(162, 49);
            this.tbAudEq7.Maximum = 100;
            this.tbAudEq7.Minimum = -100;
            this.tbAudEq7.Name = "tbAudEq7";
            this.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq7.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq7.TabIndex = 10;
            this.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq7.Scroll += new System.EventHandler(this.tbAudEq7_Scroll);
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq6.Location = new System.Drawing.Point(141, 49);
            this.tbAudEq6.Maximum = 100;
            this.tbAudEq6.Minimum = -100;
            this.tbAudEq6.Name = "tbAudEq6";
            this.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq6.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq6.TabIndex = 9;
            this.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq6.Scroll += new System.EventHandler(this.tbAudEq6_Scroll);
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq5.Location = new System.Drawing.Point(120, 49);
            this.tbAudEq5.Maximum = 100;
            this.tbAudEq5.Minimum = -100;
            this.tbAudEq5.Name = "tbAudEq5";
            this.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq5.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq5.TabIndex = 8;
            this.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq5.Scroll += new System.EventHandler(this.tbAudEq5_Scroll);
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq4.Location = new System.Drawing.Point(100, 49);
            this.tbAudEq4.Maximum = 100;
            this.tbAudEq4.Minimum = -100;
            this.tbAudEq4.Name = "tbAudEq4";
            this.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq4.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq4.TabIndex = 7;
            this.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq4.Scroll += new System.EventHandler(this.tbAudEq4_Scroll);
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq3.Location = new System.Drawing.Point(79, 49);
            this.tbAudEq3.Maximum = 100;
            this.tbAudEq3.Minimum = -100;
            this.tbAudEq3.Name = "tbAudEq3";
            this.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq3.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq3.TabIndex = 6;
            this.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq3.Scroll += new System.EventHandler(this.tbAudEq3_Scroll);
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq2.Location = new System.Drawing.Point(58, 49);
            this.tbAudEq2.Maximum = 100;
            this.tbAudEq2.Minimum = -100;
            this.tbAudEq2.Name = "tbAudEq2";
            this.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq2.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq2.TabIndex = 5;
            this.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq2.Scroll += new System.EventHandler(this.tbAudEq2_Scroll);
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq1.Location = new System.Drawing.Point(37, 49);
            this.tbAudEq1.Maximum = 100;
            this.tbAudEq1.Minimum = -100;
            this.tbAudEq1.Name = "tbAudEq1";
            this.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq1.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq1.TabIndex = 4;
            this.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq1.Scroll += new System.EventHandler(this.tbAudEq1_Scroll);
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq0.Location = new System.Drawing.Point(17, 49);
            this.tbAudEq0.Maximum = 100;
            this.tbAudEq0.Minimum = -100;
            this.tbAudEq0.Name = "tbAudEq0";
            this.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq0.Size = new System.Drawing.Size(45, 104);
            this.tbAudEq0.TabIndex = 3;
            this.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudEq0.Scroll += new System.EventHandler(this.tbAudEq0_Scroll);
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = true;
            this.cbAudEqualizerEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            this.cbAudEqualizerEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage73.Location = new System.Drawing.Point(4, 22);
            this.tabPage73.Name = "tabPage73";
            this.tabPage73.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage73.Size = new System.Drawing.Size(275, 416);
            this.tabPage73.TabIndex = 2;
            this.tabPage73.Text = "Dynamic amplify";
            this.tabPage73.UseVisualStyleBackColor = true;
            // 
            // tbAudRelease
            // 
            this.tbAudRelease.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudRelease.Location = new System.Drawing.Point(16, 209);
            this.tbAudRelease.Maximum = 10000;
            this.tbAudRelease.Minimum = 10;
            this.tbAudRelease.Name = "tbAudRelease";
            this.tbAudRelease.Size = new System.Drawing.Size(230, 45);
            this.tbAudRelease.TabIndex = 15;
            this.tbAudRelease.TickFrequency = 250;
            this.tbAudRelease.Value = 10;
            this.tbAudRelease.Scroll += new System.EventHandler(this.tbAudRelease_Scroll);
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Location = new System.Drawing.Point(233, 193);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(13, 13);
            this.label248.TabIndex = 14;
            this.label248.Text = "0";
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Location = new System.Drawing.Point(13, 193);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(68, 13);
            this.label249.TabIndex = 12;
            this.label249.Text = "Release time";
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Location = new System.Drawing.Point(233, 121);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(13, 13);
            this.label246.TabIndex = 11;
            this.label246.Text = "0";
            // 
            // tbAudAttack
            // 
            this.tbAudAttack.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAttack.Location = new System.Drawing.Point(16, 137);
            this.tbAudAttack.Maximum = 10000;
            this.tbAudAttack.Minimum = 10;
            this.tbAudAttack.Name = "tbAudAttack";
            this.tbAudAttack.Size = new System.Drawing.Size(230, 45);
            this.tbAudAttack.TabIndex = 10;
            this.tbAudAttack.TickFrequency = 250;
            this.tbAudAttack.Value = 10;
            this.tbAudAttack.Scroll += new System.EventHandler(this.tbAudAttack_Scroll);
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Location = new System.Drawing.Point(13, 121);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(38, 13);
            this.label247.TabIndex = 9;
            this.label247.Text = "Attack";
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Location = new System.Drawing.Point(233, 53);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(13, 13);
            this.label244.TabIndex = 8;
            this.label244.Text = "0";
            // 
            // tbAudDynAmp
            // 
            this.tbAudDynAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudDynAmp.Location = new System.Drawing.Point(16, 69);
            this.tbAudDynAmp.Maximum = 2000;
            this.tbAudDynAmp.Minimum = 100;
            this.tbAudDynAmp.Name = "tbAudDynAmp";
            this.tbAudDynAmp.Size = new System.Drawing.Size(230, 45);
            this.tbAudDynAmp.TabIndex = 7;
            this.tbAudDynAmp.TickFrequency = 50;
            this.tbAudDynAmp.Value = 1000;
            this.tbAudDynAmp.Scroll += new System.EventHandler(this.tbAudDynAmp_Scroll);
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Location = new System.Drawing.Point(13, 53);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(112, 13);
            this.label245.TabIndex = 6;
            this.label245.Text = "Maximum amplification";
            // 
            // cbAudDynamicAmplifyEnabled
            // 
            this.cbAudDynamicAmplifyEnabled.AutoSize = true;
            this.cbAudDynamicAmplifyEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled";
            this.cbAudDynamicAmplifyEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage75.Location = new System.Drawing.Point(4, 22);
            this.tabPage75.Name = "tabPage75";
            this.tabPage75.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage75.Size = new System.Drawing.Size(275, 416);
            this.tabPage75.TabIndex = 4;
            this.tabPage75.Text = "Sound 3D";
            this.tabPage75.UseVisualStyleBackColor = true;
            // 
            // tbAud3DSound
            // 
            this.tbAud3DSound.BackColor = System.Drawing.SystemColors.Window;
            this.tbAud3DSound.Location = new System.Drawing.Point(16, 69);
            this.tbAud3DSound.Maximum = 10000;
            this.tbAud3DSound.Name = "tbAud3DSound";
            this.tbAud3DSound.Size = new System.Drawing.Size(230, 45);
            this.tbAud3DSound.TabIndex = 19;
            this.tbAud3DSound.TickFrequency = 250;
            this.tbAud3DSound.Value = 500;
            this.tbAud3DSound.Scroll += new System.EventHandler(this.tbAud3DSound_Scroll);
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Location = new System.Drawing.Point(13, 53);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(82, 13);
            this.label253.TabIndex = 18;
            this.label253.Text = "3D amplification";
            // 
            // cbAudSound3DEnabled
            // 
            this.cbAudSound3DEnabled.AutoSize = true;
            this.cbAudSound3DEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudSound3DEnabled.Name = "cbAudSound3DEnabled";
            this.cbAudSound3DEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage76.Location = new System.Drawing.Point(4, 22);
            this.tabPage76.Name = "tabPage76";
            this.tabPage76.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage76.Size = new System.Drawing.Size(275, 416);
            this.tabPage76.TabIndex = 5;
            this.tabPage76.Text = "True bass";
            this.tabPage76.UseVisualStyleBackColor = true;
            // 
            // tbAudTrueBass
            // 
            this.tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudTrueBass.Location = new System.Drawing.Point(16, 69);
            this.tbAudTrueBass.Maximum = 10000;
            this.tbAudTrueBass.Name = "tbAudTrueBass";
            this.tbAudTrueBass.Size = new System.Drawing.Size(230, 45);
            this.tbAudTrueBass.TabIndex = 21;
            this.tbAudTrueBass.TickFrequency = 250;
            this.tbAudTrueBass.Scroll += new System.EventHandler(this.tbAudTrueBass_Scroll);
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Location = new System.Drawing.Point(13, 53);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(42, 13);
            this.label254.TabIndex = 20;
            this.label254.Text = "Volume";
            // 
            // cbAudTrueBassEnabled
            // 
            this.cbAudTrueBassEnabled.AutoSize = true;
            this.cbAudTrueBassEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled";
            this.cbAudTrueBassEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbAudTrueBassEnabled.TabIndex = 2;
            this.cbAudTrueBassEnabled.Text = "Enabled";
            this.cbAudTrueBassEnabled.UseVisualStyleBackColor = true;
            this.cbAudTrueBassEnabled.CheckedChanged += new System.EventHandler(this.cbAudTrueBassEnabled_CheckedChanged);
            // 
            // cbAudioEffectsEnabled
            // 
            this.cbAudioEffectsEnabled.AutoSize = true;
            this.cbAudioEffectsEnabled.Location = new System.Drawing.Point(14, 16);
            this.cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            this.cbAudioEffectsEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbAudioEffectsEnabled.TabIndex = 0;
            this.cbAudioEffectsEnabled.Text = "Enabled";
            this.cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage93
            // 
            this.tabPage93.Controls.Add(this.btAudioChannelMapperClear);
            this.tabPage93.Controls.Add(this.groupBox41);
            this.tabPage93.Controls.Add(this.label307);
            this.tabPage93.Controls.Add(this.edAudioChannelMapperOutputChannels);
            this.tabPage93.Controls.Add(this.label306);
            this.tabPage93.Controls.Add(this.lbAudioChannelMapperRoutes);
            this.tabPage93.Controls.Add(this.cbAudioChannelMapperEnabled);
            this.tabPage93.Location = new System.Drawing.Point(4, 22);
            this.tabPage93.Name = "tabPage93";
            this.tabPage93.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage93.Size = new System.Drawing.Size(307, 484);
            this.tabPage93.TabIndex = 21;
            this.tabPage93.Text = "Audio channel mapper";
            this.tabPage93.UseVisualStyleBackColor = true;
            // 
            // btAudioChannelMapperClear
            // 
            this.btAudioChannelMapperClear.Location = new System.Drawing.Point(212, 226);
            this.btAudioChannelMapperClear.Name = "btAudioChannelMapperClear";
            this.btAudioChannelMapperClear.Size = new System.Drawing.Size(75, 23);
            this.btAudioChannelMapperClear.TabIndex = 14;
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
            this.groupBox41.Location = new System.Drawing.Point(9, 255);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(292, 171);
            this.groupBox41.TabIndex = 13;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Add new route";
            // 
            // btAudioChannelMapperAddNewRoute
            // 
            this.btAudioChannelMapperAddNewRoute.Location = new System.Drawing.Point(108, 131);
            this.btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute";
            this.btAudioChannelMapperAddNewRoute.Size = new System.Drawing.Size(75, 23);
            this.btAudioChannelMapperAddNewRoute.TabIndex = 20;
            this.btAudioChannelMapperAddNewRoute.Text = "Add";
            this.btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = true;
            this.btAudioChannelMapperAddNewRoute.Click += new System.EventHandler(this.btAudioChannelMapperAddNewRoute_Click);
            // 
            // label311
            // 
            this.label311.AutoSize = true;
            this.label311.Location = new System.Drawing.Point(205, 89);
            this.label311.Name = "label311";
            this.label311.Size = new System.Drawing.Size(62, 13);
            this.label311.TabIndex = 19;
            this.label311.Text = "10% - 200%";
            // 
            // tbAudioChannelMapperVolume
            // 
            this.tbAudioChannelMapperVolume.Location = new System.Drawing.Point(208, 41);
            this.tbAudioChannelMapperVolume.Maximum = 2000;
            this.tbAudioChannelMapperVolume.Minimum = 100;
            this.tbAudioChannelMapperVolume.Name = "tbAudioChannelMapperVolume";
            this.tbAudioChannelMapperVolume.Size = new System.Drawing.Size(74, 45);
            this.tbAudioChannelMapperVolume.TabIndex = 18;
            this.tbAudioChannelMapperVolume.Value = 1000;
            // 
            // label310
            // 
            this.label310.AutoSize = true;
            this.label310.Location = new System.Drawing.Point(205, 25);
            this.label310.Name = "label310";
            this.label310.Size = new System.Drawing.Size(42, 13);
            this.label310.TabIndex = 17;
            this.label310.Text = "Volume";
            // 
            // edAudioChannelMapperTargetChannel
            // 
            this.edAudioChannelMapperTargetChannel.Location = new System.Drawing.Point(108, 41);
            this.edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel";
            this.edAudioChannelMapperTargetChannel.Size = new System.Drawing.Size(51, 20);
            this.edAudioChannelMapperTargetChannel.TabIndex = 16;
            this.edAudioChannelMapperTargetChannel.Text = "0";
            // 
            // label309
            // 
            this.label309.AutoSize = true;
            this.label309.Location = new System.Drawing.Point(105, 25);
            this.label309.Name = "label309";
            this.label309.Size = new System.Drawing.Size(79, 13);
            this.label309.TabIndex = 15;
            this.label309.Text = "Target channel";
            // 
            // edAudioChannelMapperSourceChannel
            // 
            this.edAudioChannelMapperSourceChannel.Location = new System.Drawing.Point(15, 41);
            this.edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel";
            this.edAudioChannelMapperSourceChannel.Size = new System.Drawing.Size(51, 20);
            this.edAudioChannelMapperSourceChannel.TabIndex = 14;
            this.edAudioChannelMapperSourceChannel.Text = "0";
            // 
            // label308
            // 
            this.label308.AutoSize = true;
            this.label308.Location = new System.Drawing.Point(12, 25);
            this.label308.Name = "label308";
            this.label308.Size = new System.Drawing.Size(82, 13);
            this.label308.TabIndex = 13;
            this.label308.Text = "Source channel";
            // 
            // label307
            // 
            this.label307.AutoSize = true;
            this.label307.Location = new System.Drawing.Point(17, 107);
            this.label307.Name = "label307";
            this.label307.Size = new System.Drawing.Size(41, 13);
            this.label307.TabIndex = 4;
            this.label307.Text = "Routes";
            // 
            // edAudioChannelMapperOutputChannels
            // 
            this.edAudioChannelMapperOutputChannels.Location = new System.Drawing.Point(20, 68);
            this.edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels";
            this.edAudioChannelMapperOutputChannels.Size = new System.Drawing.Size(42, 20);
            this.edAudioChannelMapperOutputChannels.TabIndex = 3;
            this.edAudioChannelMapperOutputChannels.Text = "0";
            // 
            // label306
            // 
            this.label306.AutoSize = true;
            this.label306.Location = new System.Drawing.Point(17, 52);
            this.label306.Name = "label306";
            this.label306.Size = new System.Drawing.Size(274, 13);
            this.label306.TabIndex = 2;
            this.label306.Text = "Output channels count (0 to use original channels count)";
            // 
            // lbAudioChannelMapperRoutes
            // 
            this.lbAudioChannelMapperRoutes.FormattingEnabled = true;
            this.lbAudioChannelMapperRoutes.Location = new System.Drawing.Point(20, 125);
            this.lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes";
            this.lbAudioChannelMapperRoutes.Size = new System.Drawing.Size(267, 95);
            this.lbAudioChannelMapperRoutes.TabIndex = 1;
            // 
            // cbAudioChannelMapperEnabled
            // 
            this.cbAudioChannelMapperEnabled.AutoSize = true;
            this.cbAudioChannelMapperEnabled.Location = new System.Drawing.Point(20, 18);
            this.cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled";
            this.cbAudioChannelMapperEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbAudioChannelMapperEnabled.TabIndex = 0;
            this.cbAudioChannelMapperEnabled.Text = "Enabled";
            this.cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage107
            // 
            this.tabPage107.Controls.Add(this.edFaceTrackingFaces);
            this.tabPage107.Controls.Add(this.label364);
            this.tabPage107.Controls.Add(this.label363);
            this.tabPage107.Controls.Add(this.cbFaceTrackingScalingMode);
            this.tabPage107.Controls.Add(this.label362);
            this.tabPage107.Controls.Add(this.edFaceTrackingScaleFactor);
            this.tabPage107.Controls.Add(this.label361);
            this.tabPage107.Controls.Add(this.cbFaceTrackingSearchMode);
            this.tabPage107.Controls.Add(this.cbFaceTrackingColorMode);
            this.tabPage107.Controls.Add(this.label346);
            this.tabPage107.Controls.Add(this.edFaceTrackingMinimumWindowSize);
            this.tabPage107.Controls.Add(this.label345);
            this.tabPage107.Controls.Add(this.cbFaceTrackingCHL);
            this.tabPage107.Controls.Add(this.cbFaceTrackingEnabled);
            this.tabPage107.Location = new System.Drawing.Point(4, 22);
            this.tabPage107.Name = "tabPage107";
            this.tabPage107.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage107.Size = new System.Drawing.Size(307, 484);
            this.tabPage107.TabIndex = 17;
            this.tabPage107.Text = "Face tracking";
            this.tabPage107.UseVisualStyleBackColor = true;
            // 
            // edFaceTrackingFaces
            // 
            this.edFaceTrackingFaces.Location = new System.Drawing.Point(33, 295);
            this.edFaceTrackingFaces.Multiline = true;
            this.edFaceTrackingFaces.Name = "edFaceTrackingFaces";
            this.edFaceTrackingFaces.Size = new System.Drawing.Size(254, 169);
            this.edFaceTrackingFaces.TabIndex = 13;
            // 
            // label364
            // 
            this.label364.AutoSize = true;
            this.label364.Location = new System.Drawing.Point(30, 276);
            this.label364.Name = "label364";
            this.label364.Size = new System.Drawing.Size(80, 13);
            this.label364.TabIndex = 12;
            this.label364.Text = "Detected faces";
            // 
            // label363
            // 
            this.label363.AutoSize = true;
            this.label363.Location = new System.Drawing.Point(30, 228);
            this.label363.Name = "label363";
            this.label363.Size = new System.Drawing.Size(71, 13);
            this.label363.TabIndex = 11;
            this.label363.Text = "Scaling mode";
            // 
            // cbFaceTrackingScalingMode
            // 
            this.cbFaceTrackingScalingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaceTrackingScalingMode.FormattingEnabled = true;
            this.cbFaceTrackingScalingMode.Items.AddRange(new object[] {
            "Greater to smaller",
            "Smaller to greater"});
            this.cbFaceTrackingScalingMode.Location = new System.Drawing.Point(166, 225);
            this.cbFaceTrackingScalingMode.Name = "cbFaceTrackingScalingMode";
            this.cbFaceTrackingScalingMode.Size = new System.Drawing.Size(121, 21);
            this.cbFaceTrackingScalingMode.TabIndex = 10;
            // 
            // label362
            // 
            this.label362.AutoSize = true;
            this.label362.Location = new System.Drawing.Point(30, 191);
            this.label362.Name = "label362";
            this.label362.Size = new System.Drawing.Size(64, 13);
            this.label362.TabIndex = 9;
            this.label362.Text = "Scale factor";
            // 
            // edFaceTrackingScaleFactor
            // 
            this.edFaceTrackingScaleFactor.Location = new System.Drawing.Point(166, 188);
            this.edFaceTrackingScaleFactor.Name = "edFaceTrackingScaleFactor";
            this.edFaceTrackingScaleFactor.Size = new System.Drawing.Size(45, 20);
            this.edFaceTrackingScaleFactor.TabIndex = 8;
            this.edFaceTrackingScaleFactor.Text = "1.2";
            // 
            // label361
            // 
            this.label361.AutoSize = true;
            this.label361.Location = new System.Drawing.Point(30, 153);
            this.label361.Name = "label361";
            this.label361.Size = new System.Drawing.Size(70, 13);
            this.label361.TabIndex = 7;
            this.label361.Text = "Search mode";
            // 
            // cbFaceTrackingSearchMode
            // 
            this.cbFaceTrackingSearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaceTrackingSearchMode.FormattingEnabled = true;
            this.cbFaceTrackingSearchMode.Items.AddRange(new object[] {
            "Default",
            "Single",
            "No overlap",
            "Average"});
            this.cbFaceTrackingSearchMode.Location = new System.Drawing.Point(166, 150);
            this.cbFaceTrackingSearchMode.Name = "cbFaceTrackingSearchMode";
            this.cbFaceTrackingSearchMode.Size = new System.Drawing.Size(121, 21);
            this.cbFaceTrackingSearchMode.TabIndex = 6;
            // 
            // cbFaceTrackingColorMode
            // 
            this.cbFaceTrackingColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaceTrackingColorMode.FormattingEnabled = true;
            this.cbFaceTrackingColorMode.Items.AddRange(new object[] {
            "RGB",
            "HSL",
            "Mixed"});
            this.cbFaceTrackingColorMode.Location = new System.Drawing.Point(166, 113);
            this.cbFaceTrackingColorMode.Name = "cbFaceTrackingColorMode";
            this.cbFaceTrackingColorMode.Size = new System.Drawing.Size(121, 21);
            this.cbFaceTrackingColorMode.TabIndex = 5;
            // 
            // label346
            // 
            this.label346.AutoSize = true;
            this.label346.Location = new System.Drawing.Point(30, 116);
            this.label346.Name = "label346";
            this.label346.Size = new System.Drawing.Size(60, 13);
            this.label346.TabIndex = 4;
            this.label346.Text = "Color mode";
            // 
            // edFaceTrackingMinimumWindowSize
            // 
            this.edFaceTrackingMinimumWindowSize.Location = new System.Drawing.Point(166, 79);
            this.edFaceTrackingMinimumWindowSize.Name = "edFaceTrackingMinimumWindowSize";
            this.edFaceTrackingMinimumWindowSize.Size = new System.Drawing.Size(45, 20);
            this.edFaceTrackingMinimumWindowSize.TabIndex = 3;
            this.edFaceTrackingMinimumWindowSize.Text = "25";
            // 
            // label345
            // 
            this.label345.AutoSize = true;
            this.label345.Location = new System.Drawing.Point(30, 82);
            this.label345.Name = "label345";
            this.label345.Size = new System.Drawing.Size(108, 13);
            this.label345.TabIndex = 2;
            this.label345.Text = "Minimum window size";
            // 
            // cbFaceTrackingCHL
            // 
            this.cbFaceTrackingCHL.AutoSize = true;
            this.cbFaceTrackingCHL.Checked = true;
            this.cbFaceTrackingCHL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFaceTrackingCHL.Location = new System.Drawing.Point(33, 52);
            this.cbFaceTrackingCHL.Name = "cbFaceTrackingCHL";
            this.cbFaceTrackingCHL.Size = new System.Drawing.Size(92, 17);
            this.cbFaceTrackingCHL.TabIndex = 1;
            this.cbFaceTrackingCHL.Text = "Color highlight";
            this.cbFaceTrackingCHL.UseVisualStyleBackColor = true;
            // 
            // cbFaceTrackingEnabled
            // 
            this.cbFaceTrackingEnabled.AutoSize = true;
            this.cbFaceTrackingEnabled.Location = new System.Drawing.Point(18, 19);
            this.cbFaceTrackingEnabled.Name = "cbFaceTrackingEnabled";
            this.cbFaceTrackingEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbFaceTrackingEnabled.TabIndex = 0;
            this.cbFaceTrackingEnabled.Text = "Enabled";
            this.cbFaceTrackingEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbNetworkStreamingMode);
            this.tabPage7.Controls.Add(this.tabControl5);
            this.tabPage7.Controls.Add(this.cbNetworkStreamingAudioEnabled);
            this.tabPage7.Controls.Add(this.cbNetworkStreaming);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(307, 484);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Network streaming";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreamingMode
            // 
            this.cbNetworkStreamingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNetworkStreamingMode.FormattingEnabled = true;
            this.cbNetworkStreamingMode.Items.AddRange(new object[] {
            "Windows Media Video",
            "RTSP",
            "RTMP to Adobe Media Server / Wowza",
            "NDI",
            "UDP",
            "Smooth Streaming to Microsoft IIS",
            "HTTP Live Streaming (HLS)",
            "Output to external virtual devices"});
            this.cbNetworkStreamingMode.Location = new System.Drawing.Point(18, 41);
            this.cbNetworkStreamingMode.Name = "cbNetworkStreamingMode";
            this.cbNetworkStreamingMode.Size = new System.Drawing.Size(276, 21);
            this.cbNetworkStreamingMode.TabIndex = 19;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tpWMV);
            this.tabControl5.Controls.Add(this.tpRTSP);
            this.tabControl5.Controls.Add(this.tpRTMP);
            this.tabControl5.Controls.Add(this.tpNDI);
            this.tabControl5.Controls.Add(this.tpUDP);
            this.tabControl5.Controls.Add(this.tpSSF);
            this.tabControl5.Controls.Add(this.tpHLS);
            this.tabControl5.Controls.Add(this.tpNSExternal);
            this.tabControl5.Location = new System.Drawing.Point(6, 73);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(292, 382);
            this.tabControl5.TabIndex = 18;
            // 
            // tpWMV
            // 
            this.tpWMV.Controls.Add(this.label48);
            this.tpWMV.Controls.Add(this.edNetworkURL);
            this.tpWMV.Controls.Add(this.edWMVNetworkPort);
            this.tpWMV.Controls.Add(this.label47);
            this.tpWMV.Controls.Add(this.btRefreshClients);
            this.tpWMV.Controls.Add(this.lbNetworkClients);
            this.tpWMV.Controls.Add(this.rbNetworkStreamingUseExternalProfile);
            this.tpWMV.Controls.Add(this.rbNetworkStreamingUseMainWMVSettings);
            this.tpWMV.Controls.Add(this.label81);
            this.tpWMV.Controls.Add(this.label80);
            this.tpWMV.Controls.Add(this.edMaximumClients);
            this.tpWMV.Controls.Add(this.label46);
            this.tpWMV.Controls.Add(this.btSelectWMVProfileNetwork);
            this.tpWMV.Controls.Add(this.edNetworkStreamingWMVProfile);
            this.tpWMV.Controls.Add(this.label44);
            this.tpWMV.Location = new System.Drawing.Point(4, 22);
            this.tpWMV.Name = "tpWMV";
            this.tpWMV.Padding = new System.Windows.Forms.Padding(3);
            this.tpWMV.Size = new System.Drawing.Size(284, 356);
            this.tpWMV.TabIndex = 0;
            this.tpWMV.Text = "WMV";
            this.tpWMV.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(12, 304);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(86, 13);
            this.label48.TabIndex = 32;
            this.label48.Text = "Connection URL";
            // 
            // edNetworkURL
            // 
            this.edNetworkURL.Location = new System.Drawing.Point(15, 320);
            this.edNetworkURL.Name = "edNetworkURL";
            this.edNetworkURL.ReadOnly = true;
            this.edNetworkURL.Size = new System.Drawing.Size(255, 20);
            this.edNetworkURL.TabIndex = 31;
            // 
            // edWMVNetworkPort
            // 
            this.edWMVNetworkPort.Location = new System.Drawing.Point(236, 120);
            this.edWMVNetworkPort.Name = "edWMVNetworkPort";
            this.edWMVNetworkPort.Size = new System.Drawing.Size(34, 20);
            this.edWMVNetworkPort.TabIndex = 30;
            this.edWMVNetworkPort.Text = "100";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(162, 123);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(68, 13);
            this.label47.TabIndex = 29;
            this.label47.Text = "Network port";
            // 
            // btRefreshClients
            // 
            this.btRefreshClients.Location = new System.Drawing.Point(206, 237);
            this.btRefreshClients.Name = "btRefreshClients";
            this.btRefreshClients.Size = new System.Drawing.Size(64, 23);
            this.btRefreshClients.TabIndex = 28;
            this.btRefreshClients.Text = "Refresh";
            this.btRefreshClients.UseVisualStyleBackColor = true;
            this.btRefreshClients.Click += new System.EventHandler(this.btRefreshClients_Click);
            // 
            // lbNetworkClients
            // 
            this.lbNetworkClients.FormattingEnabled = true;
            this.lbNetworkClients.Location = new System.Drawing.Point(15, 175);
            this.lbNetworkClients.Name = "lbNetworkClients";
            this.lbNetworkClients.Size = new System.Drawing.Size(255, 56);
            this.lbNetworkClients.TabIndex = 27;
            // 
            // rbNetworkStreamingUseExternalProfile
            // 
            this.rbNetworkStreamingUseExternalProfile.AutoSize = true;
            this.rbNetworkStreamingUseExternalProfile.Location = new System.Drawing.Point(15, 38);
            this.rbNetworkStreamingUseExternalProfile.Name = "rbNetworkStreamingUseExternalProfile";
            this.rbNetworkStreamingUseExternalProfile.Size = new System.Drawing.Size(115, 17);
            this.rbNetworkStreamingUseExternalProfile.TabIndex = 26;
            this.rbNetworkStreamingUseExternalProfile.Text = "Use external profile";
            this.rbNetworkStreamingUseExternalProfile.UseVisualStyleBackColor = true;
            // 
            // rbNetworkStreamingUseMainWMVSettings
            // 
            this.rbNetworkStreamingUseMainWMVSettings.AutoSize = true;
            this.rbNetworkStreamingUseMainWMVSettings.Checked = true;
            this.rbNetworkStreamingUseMainWMVSettings.Location = new System.Drawing.Point(15, 15);
            this.rbNetworkStreamingUseMainWMVSettings.Name = "rbNetworkStreamingUseMainWMVSettings";
            this.rbNetworkStreamingUseMainWMVSettings.Size = new System.Drawing.Size(193, 17);
            this.rbNetworkStreamingUseMainWMVSettings.TabIndex = 25;
            this.rbNetworkStreamingUseMainWMVSettings.TabStop = true;
            this.rbNetworkStreamingUseMainWMVSettings.Text = "Use WMV settings from capture tab";
            this.rbNetworkStreamingUseMainWMVSettings.UseVisualStyleBackColor = true;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(34, 272);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(230, 13);
            this.label81.TabIndex = 24;
            this.label81.Text = "You can use Windows Media Player for testing.";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(13, 159);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(38, 13);
            this.label80.TabIndex = 23;
            this.label80.Text = "Clients";
            // 
            // edMaximumClients
            // 
            this.edMaximumClients.Location = new System.Drawing.Point(109, 120);
            this.edMaximumClients.Name = "edMaximumClients";
            this.edMaximumClients.Size = new System.Drawing.Size(34, 20);
            this.edMaximumClients.TabIndex = 22;
            this.edMaximumClients.Text = "10";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(13, 123);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(84, 13);
            this.label46.TabIndex = 21;
            this.label46.Text = "Maximum clients";
            // 
            // btSelectWMVProfileNetwork
            // 
            this.btSelectWMVProfileNetwork.Location = new System.Drawing.Point(246, 82);
            this.btSelectWMVProfileNetwork.Name = "btSelectWMVProfileNetwork";
            this.btSelectWMVProfileNetwork.Size = new System.Drawing.Size(24, 23);
            this.btSelectWMVProfileNetwork.TabIndex = 20;
            this.btSelectWMVProfileNetwork.Text = "...";
            this.btSelectWMVProfileNetwork.UseVisualStyleBackColor = true;
            this.btSelectWMVProfileNetwork.Click += new System.EventHandler(this.btSelectWMVProfileNetwork_Click);
            // 
            // edNetworkStreamingWMVProfile
            // 
            this.edNetworkStreamingWMVProfile.Location = new System.Drawing.Point(37, 84);
            this.edNetworkStreamingWMVProfile.Name = "edNetworkStreamingWMVProfile";
            this.edNetworkStreamingWMVProfile.Size = new System.Drawing.Size(206, 20);
            this.edNetworkStreamingWMVProfile.TabIndex = 19;
            this.edNetworkStreamingWMVProfile.Text = "c:\\WM.prx";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(34, 68);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 13);
            this.label44.TabIndex = 18;
            this.label44.Text = "File name";
            // 
            // tpRTSP
            // 
            this.tpRTSP.Controls.Add(this.edNetworkRTSPURL);
            this.tpRTSP.Controls.Add(this.label367);
            this.tpRTSP.Controls.Add(this.label366);
            this.tpRTSP.Location = new System.Drawing.Point(4, 22);
            this.tpRTSP.Name = "tpRTSP";
            this.tpRTSP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRTSP.Size = new System.Drawing.Size(284, 356);
            this.tpRTSP.TabIndex = 2;
            this.tpRTSP.Text = "RTSP";
            this.tpRTSP.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTSPURL
            // 
            this.edNetworkRTSPURL.Location = new System.Drawing.Point(20, 30);
            this.edNetworkRTSPURL.Name = "edNetworkRTSPURL";
            this.edNetworkRTSPURL.Size = new System.Drawing.Size(247, 20);
            this.edNetworkRTSPURL.TabIndex = 4;
            this.edNetworkRTSPURL.Text = "rtsp://localhost:5554/vfstream";
            // 
            // label367
            // 
            this.label367.AutoSize = true;
            this.label367.Location = new System.Drawing.Point(17, 14);
            this.label367.Name = "label367";
            this.label367.Size = new System.Drawing.Size(29, 13);
            this.label367.TabIndex = 3;
            this.label367.Text = "URL";
            // 
            // label366
            // 
            this.label366.AutoSize = true;
            this.label366.Location = new System.Drawing.Point(17, 327);
            this.label366.Name = "label366";
            this.label366.Size = new System.Drawing.Size(159, 13);
            this.label366.TabIndex = 2;
            this.label366.Text = "MP4 output settings will be used";
            // 
            // tpRTMP
            // 
            this.tpRTMP.Controls.Add(this.cbNetworkRTMPFFMPEGUsePipes);
            this.tpRTMP.Controls.Add(this.linkLabel11);
            this.tpRTMP.Controls.Add(this.linkLabel8);
            this.tpRTMP.Controls.Add(this.rbNetworkRTMPFFMPEGCustom);
            this.tpRTMP.Controls.Add(this.rbNetworkRTMPFFMPEG);
            this.tpRTMP.Controls.Add(this.edNetworkRTMPURL);
            this.tpRTMP.Controls.Add(this.label368);
            this.tpRTMP.Controls.Add(this.label369);
            this.tpRTMP.Location = new System.Drawing.Point(4, 22);
            this.tpRTMP.Name = "tpRTMP";
            this.tpRTMP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRTMP.Size = new System.Drawing.Size(284, 356);
            this.tpRTMP.TabIndex = 3;
            this.tpRTMP.Text = "RTMP";
            this.tpRTMP.UseVisualStyleBackColor = true;
            // 
            // cbNetworkRTMPFFMPEGUsePipes
            // 
            this.cbNetworkRTMPFFMPEGUsePipes.AutoSize = true;
            this.cbNetworkRTMPFFMPEGUsePipes.Checked = true;
            this.cbNetworkRTMPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNetworkRTMPFFMPEGUsePipes.Location = new System.Drawing.Point(20, 76);
            this.cbNetworkRTMPFFMPEGUsePipes.Name = "cbNetworkRTMPFFMPEGUsePipes";
            this.cbNetworkRTMPFFMPEGUsePipes.Size = new System.Drawing.Size(73, 17);
            this.cbNetworkRTMPFFMPEGUsePipes.TabIndex = 14;
            this.cbNetworkRTMPFFMPEGUsePipes.Text = "Use pipes";
            this.cbNetworkRTMPFFMPEGUsePipes.UseVisualStyleBackColor = true;
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.Location = new System.Drawing.Point(17, 145);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(154, 13);
            this.linkLabel11.TabIndex = 13;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "Network streaming to YouTube";
            this.linkLabel11.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel11_LinkClicked);
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(17, 121);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(207, 13);
            this.linkLabel8.TabIndex = 12;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "FFMPEG.exe redist required to be installed";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FFMPEGDownloadLinkClicked);
            // 
            // rbNetworkRTMPFFMPEGCustom
            // 
            this.rbNetworkRTMPFFMPEGCustom.AutoSize = true;
            this.rbNetworkRTMPFFMPEGCustom.Location = new System.Drawing.Point(20, 41);
            this.rbNetworkRTMPFFMPEGCustom.Name = "rbNetworkRTMPFFMPEGCustom";
            this.rbNetworkRTMPFFMPEGCustom.Size = new System.Drawing.Size(197, 17);
            this.rbNetworkRTMPFFMPEGCustom.TabIndex = 11;
            this.rbNetworkRTMPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            this.rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkRTMPFFMPEG
            // 
            this.rbNetworkRTMPFFMPEG.AutoSize = true;
            this.rbNetworkRTMPFFMPEG.Checked = true;
            this.rbNetworkRTMPFFMPEG.Location = new System.Drawing.Point(20, 18);
            this.rbNetworkRTMPFFMPEG.Name = "rbNetworkRTMPFFMPEG";
            this.rbNetworkRTMPFFMPEG.Size = new System.Drawing.Size(181, 17);
            this.rbNetworkRTMPFFMPEG.TabIndex = 10;
            this.rbNetworkRTMPFFMPEG.TabStop = true;
            this.rbNetworkRTMPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            this.rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTMPURL
            // 
            this.edNetworkRTMPURL.Location = new System.Drawing.Point(20, 292);
            this.edNetworkRTMPURL.Name = "edNetworkRTMPURL";
            this.edNetworkRTMPURL.Size = new System.Drawing.Size(247, 20);
            this.edNetworkRTMPURL.TabIndex = 9;
            this.edNetworkRTMPURL.Text = "rtmp://localhost:5554/live/Stream";
            // 
            // label368
            // 
            this.label368.AutoSize = true;
            this.label368.Location = new System.Drawing.Point(17, 276);
            this.label368.Name = "label368";
            this.label368.Size = new System.Drawing.Size(29, 13);
            this.label368.TabIndex = 8;
            this.label368.Text = "URL";
            // 
            // label369
            // 
            this.label369.AutoSize = true;
            this.label369.Location = new System.Drawing.Point(30, 326);
            this.label369.Name = "label369";
            this.label369.Size = new System.Drawing.Size(214, 13);
            this.label369.TabIndex = 7;
            this.label369.Text = "Format settings located on output format tab";
            // 
            // tpNDI
            // 
            this.tpNDI.Controls.Add(this.linkLabel6);
            this.tpNDI.Controls.Add(this.label38);
            this.tpNDI.Controls.Add(this.label31);
            this.tpNDI.Controls.Add(this.edNDIURL);
            this.tpNDI.Controls.Add(this.edNDIName);
            this.tpNDI.Controls.Add(this.label30);
            this.tpNDI.Location = new System.Drawing.Point(4, 22);
            this.tpNDI.Name = "tpNDI";
            this.tpNDI.Padding = new System.Windows.Forms.Padding(3);
            this.tpNDI.Size = new System.Drawing.Size(284, 356);
            this.tpNDI.TabIndex = 7;
            this.tpNDI.Text = "NDI";
            this.tpNDI.UseVisualStyleBackColor = true;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(16, 128);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(86, 13);
            this.linkLabel6.TabIndex = 89;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "vendor\'s website";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbNDI_LinkClicked);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 115);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(257, 13);
            this.label38.TabIndex = 88;
            this.label38.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(86, 13);
            this.label31.TabIndex = 34;
            this.label31.Text = "Connection URL";
            // 
            // edNDIURL
            // 
            this.edNDIURL.Location = new System.Drawing.Point(19, 80);
            this.edNDIURL.Name = "edNDIURL";
            this.edNDIURL.ReadOnly = true;
            this.edNDIURL.Size = new System.Drawing.Size(243, 20);
            this.edNDIURL.TabIndex = 33;
            // 
            // edNDIName
            // 
            this.edNDIName.Location = new System.Drawing.Point(19, 28);
            this.edNDIName.Name = "edNDIName";
            this.edNDIName.Size = new System.Drawing.Size(243, 20);
            this.edNDIName.TabIndex = 1;
            this.edNDIName.Text = "Main";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 12);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Name";
            // 
            // tpUDP
            // 
            this.tpUDP.Controls.Add(this.cbNetworkUDPFFMPEGUsePipes);
            this.tpUDP.Controls.Add(this.label314);
            this.tpUDP.Controls.Add(this.label313);
            this.tpUDP.Controls.Add(this.linkLabel9);
            this.tpUDP.Controls.Add(this.label484);
            this.tpUDP.Controls.Add(this.edNetworkUDPURL);
            this.tpUDP.Controls.Add(this.label372);
            this.tpUDP.Controls.Add(this.rbNetworkUDPFFMPEGCustom);
            this.tpUDP.Controls.Add(this.rbNetworkUDPFFMPEG);
            this.tpUDP.Location = new System.Drawing.Point(4, 22);
            this.tpUDP.Name = "tpUDP";
            this.tpUDP.Padding = new System.Windows.Forms.Padding(3);
            this.tpUDP.Size = new System.Drawing.Size(284, 356);
            this.tpUDP.TabIndex = 5;
            this.tpUDP.Text = "UDP";
            this.tpUDP.UseVisualStyleBackColor = true;
            // 
            // cbNetworkUDPFFMPEGUsePipes
            // 
            this.cbNetworkUDPFFMPEGUsePipes.AutoSize = true;
            this.cbNetworkUDPFFMPEGUsePipes.Checked = true;
            this.cbNetworkUDPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNetworkUDPFFMPEGUsePipes.Location = new System.Drawing.Point(20, 76);
            this.cbNetworkUDPFFMPEGUsePipes.Name = "cbNetworkUDPFFMPEGUsePipes";
            this.cbNetworkUDPFFMPEGUsePipes.Size = new System.Drawing.Size(73, 17);
            this.cbNetworkUDPFFMPEGUsePipes.TabIndex = 15;
            this.cbNetworkUDPFFMPEGUsePipes.Text = "Use pipes";
            this.cbNetworkUDPFFMPEGUsePipes.UseVisualStyleBackColor = true;
            // 
            // label314
            // 
            this.label314.AutoSize = true;
            this.label314.Location = new System.Drawing.Point(17, 281);
            this.label314.Name = "label314";
            this.label314.Size = new System.Drawing.Size(204, 13);
            this.label314.TabIndex = 14;
            this.label314.Text = "For multicast UDP streaming use URL like";
            // 
            // label313
            // 
            this.label313.AutoSize = true;
            this.label313.Location = new System.Drawing.Point(17, 294);
            this.label313.Name = "label313";
            this.label313.Size = new System.Drawing.Size(229, 13);
            this.label313.TabIndex = 13;
            this.label313.Text = "udp://239.101.101.1:1234?ttl=1&pkt_size=1316";
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.Location = new System.Drawing.Point(17, 129);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(207, 13);
            this.linkLabel9.TabIndex = 12;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "FFMPEG.exe redist required to be installed";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FFMPEGDownloadLinkClicked);
            // 
            // label484
            // 
            this.label484.AutoSize = true;
            this.label484.Location = new System.Drawing.Point(30, 329);
            this.label484.Name = "label484";
            this.label484.Size = new System.Drawing.Size(217, 13);
            this.label484.TabIndex = 11;
            this.label484.Text = "Specify settings located on output format tab";
            // 
            // edNetworkUDPURL
            // 
            this.edNetworkUDPURL.Location = new System.Drawing.Point(20, 258);
            this.edNetworkUDPURL.Name = "edNetworkUDPURL";
            this.edNetworkUDPURL.Size = new System.Drawing.Size(247, 20);
            this.edNetworkUDPURL.TabIndex = 10;
            this.edNetworkUDPURL.Text = "udp://127.0.0.1:10000";
            // 
            // label372
            // 
            this.label372.AutoSize = true;
            this.label372.Location = new System.Drawing.Point(17, 242);
            this.label372.Name = "label372";
            this.label372.Size = new System.Drawing.Size(29, 13);
            this.label372.TabIndex = 9;
            this.label372.Text = "URL";
            // 
            // rbNetworkUDPFFMPEGCustom
            // 
            this.rbNetworkUDPFFMPEGCustom.AutoSize = true;
            this.rbNetworkUDPFFMPEGCustom.Location = new System.Drawing.Point(20, 41);
            this.rbNetworkUDPFFMPEGCustom.Name = "rbNetworkUDPFFMPEGCustom";
            this.rbNetworkUDPFFMPEGCustom.Size = new System.Drawing.Size(197, 17);
            this.rbNetworkUDPFFMPEGCustom.TabIndex = 8;
            this.rbNetworkUDPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            this.rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkUDPFFMPEG
            // 
            this.rbNetworkUDPFFMPEG.AutoSize = true;
            this.rbNetworkUDPFFMPEG.Checked = true;
            this.rbNetworkUDPFFMPEG.Location = new System.Drawing.Point(20, 18);
            this.rbNetworkUDPFFMPEG.Name = "rbNetworkUDPFFMPEG";
            this.rbNetworkUDPFFMPEG.Size = new System.Drawing.Size(181, 17);
            this.rbNetworkUDPFFMPEG.TabIndex = 7;
            this.rbNetworkUDPFFMPEG.TabStop = true;
            this.rbNetworkUDPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            this.rbNetworkUDPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // tpSSF
            // 
            this.tpSSF.Controls.Add(this.cbNetworkSSUsePipes);
            this.tpSSF.Controls.Add(this.linkLabel10);
            this.tpSSF.Controls.Add(this.rbNetworkSSFFMPEGCustom);
            this.tpSSF.Controls.Add(this.rbNetworkSSFFMPEGDefault);
            this.tpSSF.Controls.Add(this.linkLabel5);
            this.tpSSF.Controls.Add(this.edNetworkSSURL);
            this.tpSSF.Controls.Add(this.label370);
            this.tpSSF.Controls.Add(this.label371);
            this.tpSSF.Controls.Add(this.rbNetworkSSSoftware);
            this.tpSSF.Location = new System.Drawing.Point(4, 22);
            this.tpSSF.Name = "tpSSF";
            this.tpSSF.Padding = new System.Windows.Forms.Padding(3);
            this.tpSSF.Size = new System.Drawing.Size(284, 356);
            this.tpSSF.TabIndex = 4;
            this.tpSSF.Text = "IIS Smooth Streaming";
            this.tpSSF.UseVisualStyleBackColor = true;
            // 
            // cbNetworkSSUsePipes
            // 
            this.cbNetworkSSUsePipes.AutoSize = true;
            this.cbNetworkSSUsePipes.Checked = true;
            this.cbNetworkSSUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNetworkSSUsePipes.Location = new System.Drawing.Point(36, 86);
            this.cbNetworkSSUsePipes.Name = "cbNetworkSSUsePipes";
            this.cbNetworkSSUsePipes.Size = new System.Drawing.Size(182, 17);
            this.cbNetworkSSUsePipes.TabIndex = 19;
            this.cbNetworkSSUsePipes.Text = "Use pipes for FFMPEG streaming";
            this.cbNetworkSSUsePipes.UseVisualStyleBackColor = true;
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.Location = new System.Drawing.Point(17, 211);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(207, 13);
            this.linkLabel10.TabIndex = 18;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "FFMPEG.exe redist required to be installed";
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FFMPEGDownloadLinkClicked);
            // 
            // rbNetworkSSFFMPEGCustom
            // 
            this.rbNetworkSSFFMPEGCustom.AutoSize = true;
            this.rbNetworkSSFFMPEGCustom.Location = new System.Drawing.Point(20, 63);
            this.rbNetworkSSFFMPEGCustom.Name = "rbNetworkSSFFMPEGCustom";
            this.rbNetworkSSFFMPEGCustom.Size = new System.Drawing.Size(197, 17);
            this.rbNetworkSSFFMPEGCustom.TabIndex = 17;
            this.rbNetworkSSFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            this.rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkSSFFMPEGDefault
            // 
            this.rbNetworkSSFFMPEGDefault.AutoSize = true;
            this.rbNetworkSSFFMPEGDefault.Location = new System.Drawing.Point(20, 40);
            this.rbNetworkSSFFMPEGDefault.Name = "rbNetworkSSFFMPEGDefault";
            this.rbNetworkSSFFMPEGDefault.Size = new System.Drawing.Size(181, 17);
            this.rbNetworkSSFFMPEGDefault.TabIndex = 16;
            this.rbNetworkSSFFMPEGDefault.Text = "H264 / AAC using FFMPEG EXE";
            this.rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = true;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(17, 184);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(178, 13);
            this.linkLabel5.TabIndex = 15;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "IIS Smooth Streaming usage manual";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // edNetworkSSURL
            // 
            this.edNetworkSSURL.Location = new System.Drawing.Point(20, 140);
            this.edNetworkSSURL.Name = "edNetworkSSURL";
            this.edNetworkSSURL.Size = new System.Drawing.Size(247, 20);
            this.edNetworkSSURL.TabIndex = 14;
            this.edNetworkSSURL.Text = "http://localhost/LiveSmoothStream.isml";
            // 
            // label370
            // 
            this.label370.AutoSize = true;
            this.label370.Location = new System.Drawing.Point(17, 124);
            this.label370.Name = "label370";
            this.label370.Size = new System.Drawing.Size(106, 13);
            this.label370.TabIndex = 13;
            this.label370.Text = "Publishing point URL";
            // 
            // label371
            // 
            this.label371.AutoSize = true;
            this.label371.Location = new System.Drawing.Point(17, 326);
            this.label371.Name = "label371";
            this.label371.Size = new System.Drawing.Size(214, 13);
            this.label371.TabIndex = 12;
            this.label371.Text = "Format settings located on output format tab";
            // 
            // rbNetworkSSSoftware
            // 
            this.rbNetworkSSSoftware.AutoSize = true;
            this.rbNetworkSSSoftware.Checked = true;
            this.rbNetworkSSSoftware.Location = new System.Drawing.Point(20, 17);
            this.rbNetworkSSSoftware.Name = "rbNetworkSSSoftware";
            this.rbNetworkSSSoftware.Size = new System.Drawing.Size(244, 17);
            this.rbNetworkSSSoftware.TabIndex = 10;
            this.rbNetworkSSSoftware.TabStop = true;
            this.rbNetworkSSSoftware.Text = "H264 / AAC using software encoder / NVENC";
            this.rbNetworkSSSoftware.UseVisualStyleBackColor = true;
            // 
            // tpHLS
            // 
            this.tpHLS.Controls.Add(this.edHLSURL);
            this.tpHLS.Controls.Add(this.label19);
            this.tpHLS.Controls.Add(this.edHLSEmbeddedHTTPServerPort);
            this.tpHLS.Controls.Add(this.cbHLSEmbeddedHTTPServerEnabled);
            this.tpHLS.Controls.Add(this.cbHLSMode);
            this.tpHLS.Controls.Add(this.label6);
            this.tpHLS.Controls.Add(this.lbHLSConfigure);
            this.tpHLS.Controls.Add(this.label532);
            this.tpHLS.Controls.Add(this.label531);
            this.tpHLS.Controls.Add(this.label530);
            this.tpHLS.Controls.Add(this.label529);
            this.tpHLS.Controls.Add(this.edHLSSegmentCount);
            this.tpHLS.Controls.Add(this.label519);
            this.tpHLS.Controls.Add(this.edHLSSegmentDuration);
            this.tpHLS.Controls.Add(this.btSelectHLSOutputFolder);
            this.tpHLS.Controls.Add(this.edHLSOutputFolder);
            this.tpHLS.Controls.Add(this.label380);
            this.tpHLS.Location = new System.Drawing.Point(4, 22);
            this.tpHLS.Name = "tpHLS";
            this.tpHLS.Padding = new System.Windows.Forms.Padding(3);
            this.tpHLS.Size = new System.Drawing.Size(284, 356);
            this.tpHLS.TabIndex = 6;
            this.tpHLS.Text = "HLS";
            this.tpHLS.UseVisualStyleBackColor = true;
            // 
            // edHLSURL
            // 
            this.edHLSURL.Location = new System.Drawing.Point(19, 290);
            this.edHLSURL.Name = "edHLSURL";
            this.edHLSURL.Size = new System.Drawing.Size(252, 20);
            this.edHLSURL.TabIndex = 16;
            this.edHLSURL.Text = "http://localhost:81/playlist.m3u8";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 315);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "or";
            // 
            // edHLSEmbeddedHTTPServerPort
            // 
            this.edHLSEmbeddedHTTPServerPort.Location = new System.Drawing.Point(230, 265);
            this.edHLSEmbeddedHTTPServerPort.Name = "edHLSEmbeddedHTTPServerPort";
            this.edHLSEmbeddedHTTPServerPort.Size = new System.Drawing.Size(41, 20);
            this.edHLSEmbeddedHTTPServerPort.TabIndex = 14;
            this.edHLSEmbeddedHTTPServerPort.Text = "81";
            // 
            // cbHLSEmbeddedHTTPServerEnabled
            // 
            this.cbHLSEmbeddedHTTPServerEnabled.AutoSize = true;
            this.cbHLSEmbeddedHTTPServerEnabled.Location = new System.Drawing.Point(19, 267);
            this.cbHLSEmbeddedHTTPServerEnabled.Name = "cbHLSEmbeddedHTTPServerEnabled";
            this.cbHLSEmbeddedHTTPServerEnabled.Size = new System.Drawing.Size(205, 17);
            this.cbHLSEmbeddedHTTPServerEnabled.TabIndex = 13;
            this.cbHLSEmbeddedHTTPServerEnabled.Text = "Use embedded HTTP server with port";
            this.cbHLSEmbeddedHTTPServerEnabled.UseVisualStyleBackColor = true;
            // 
            // cbHLSMode
            // 
            this.cbHLSMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHLSMode.FormattingEnabled = true;
            this.cbHLSMode.Items.AddRange(new object[] {
            "Live",
            "VOD",
            "Event"});
            this.cbHLSMode.Location = new System.Drawing.Point(19, 229);
            this.cbHLSMode.Name = "cbHLSMode";
            this.cbHLSMode.Size = new System.Drawing.Size(121, 21);
            this.cbHLSMode.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mode (playlist type)";
            // 
            // lbHLSConfigure
            // 
            this.lbHLSConfigure.AutoSize = true;
            this.lbHLSConfigure.Location = new System.Drawing.Point(16, 328);
            this.lbHLSConfigure.Name = "lbHLSConfigure";
            this.lbHLSConfigure.Size = new System.Drawing.Size(191, 13);
            this.lbHLSConfigure.TabIndex = 10;
            this.lbHLSConfigure.TabStop = true;
            this.lbHLSConfigure.Text = "How to configure HTTP server for HLS";
            this.lbHLSConfigure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbHLSConfigure_LinkClicked);
            // 
            // label532
            // 
            this.label532.AutoSize = true;
            this.label532.Location = new System.Drawing.Point(16, 183);
            this.label532.Name = "label532";
            this.label532.Size = new System.Drawing.Size(42, 13);
            this.label532.TabIndex = 9;
            this.label532.Text = "in code";
            // 
            // label531
            // 
            this.label531.AutoSize = true;
            this.label531.Location = new System.Drawing.Point(16, 170);
            this.label531.Name = "label531";
            this.label531.Size = new System.Drawing.Size(247, 13);
            this.label531.TabIndex = 8;
            this.label531.Text = "You can set video (H264) and audio (AAC) settings";
            // 
            // label530
            // 
            this.label530.AutoSize = true;
            this.label530.Location = new System.Drawing.Point(67, 135);
            this.label530.Name = "label530";
            this.label530.Size = new System.Drawing.Size(134, 13);
            this.label530.TabIndex = 7;
            this.label530.Text = "Use 0 to save all segments";
            // 
            // label529
            // 
            this.label529.AutoSize = true;
            this.label529.Location = new System.Drawing.Point(16, 116);
            this.label529.Name = "label529";
            this.label529.Size = new System.Drawing.Size(244, 13);
            this.label529.TabIndex = 6;
            this.label529.Text = "Segment count that will be saved during streaming";
            // 
            // edHLSSegmentCount
            // 
            this.edHLSSegmentCount.Location = new System.Drawing.Point(19, 132);
            this.edHLSSegmentCount.Name = "edHLSSegmentCount";
            this.edHLSSegmentCount.Size = new System.Drawing.Size(42, 20);
            this.edHLSSegmentCount.TabIndex = 5;
            this.edHLSSegmentCount.Text = "20";
            // 
            // label519
            // 
            this.label519.AutoSize = true;
            this.label519.Location = new System.Drawing.Point(16, 67);
            this.label519.Name = "label519";
            this.label519.Size = new System.Drawing.Size(116, 13);
            this.label519.TabIndex = 4;
            this.label519.Text = "Segment duration (sec)";
            // 
            // edHLSSegmentDuration
            // 
            this.edHLSSegmentDuration.Location = new System.Drawing.Point(19, 83);
            this.edHLSSegmentDuration.Name = "edHLSSegmentDuration";
            this.edHLSSegmentDuration.Size = new System.Drawing.Size(42, 20);
            this.edHLSSegmentDuration.TabIndex = 3;
            this.edHLSSegmentDuration.Text = "10";
            // 
            // btSelectHLSOutputFolder
            // 
            this.btSelectHLSOutputFolder.Location = new System.Drawing.Point(255, 33);
            this.btSelectHLSOutputFolder.Name = "btSelectHLSOutputFolder";
            this.btSelectHLSOutputFolder.Size = new System.Drawing.Size(23, 23);
            this.btSelectHLSOutputFolder.TabIndex = 2;
            this.btSelectHLSOutputFolder.Text = "...";
            this.btSelectHLSOutputFolder.UseVisualStyleBackColor = true;
            this.btSelectHLSOutputFolder.Click += new System.EventHandler(this.btSelectHLSOutputFolder_Click);
            // 
            // edHLSOutputFolder
            // 
            this.edHLSOutputFolder.Location = new System.Drawing.Point(19, 35);
            this.edHLSOutputFolder.Name = "edHLSOutputFolder";
            this.edHLSOutputFolder.Size = new System.Drawing.Size(230, 20);
            this.edHLSOutputFolder.TabIndex = 1;
            this.edHLSOutputFolder.Text = "c:\\inetpub\\wwwroot\\hls\\";
            // 
            // label380
            // 
            this.label380.AutoSize = true;
            this.label380.Location = new System.Drawing.Point(16, 16);
            this.label380.Name = "label380";
            this.label380.Size = new System.Drawing.Size(188, 13);
            this.label380.TabIndex = 0;
            this.label380.Text = "Output folder for video files and playlist";
            // 
            // tpNSExternal
            // 
            this.tpNSExternal.Controls.Add(this.linkLabel4);
            this.tpNSExternal.Controls.Add(this.linkLabel2);
            this.tpNSExternal.Location = new System.Drawing.Point(4, 22);
            this.tpNSExternal.Name = "tpNSExternal";
            this.tpNSExternal.Padding = new System.Windows.Forms.Padding(3);
            this.tpNSExternal.Size = new System.Drawing.Size(284, 356);
            this.tpNSExternal.TabIndex = 1;
            this.tpNSExternal.Text = "External virtual devices";
            this.tpNSExternal.UseVisualStyleBackColor = true;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(17, 38);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(225, 13);
            this.linkLabel4.TabIndex = 1;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Streaming using Microsoft Expression Encoder";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(17, 12);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(194, 13);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Streaming to Adobe Flash Media Server";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // cbNetworkStreamingAudioEnabled
            // 
            this.cbNetworkStreamingAudioEnabled.AutoSize = true;
            this.cbNetworkStreamingAudioEnabled.Location = new System.Drawing.Point(10, 461);
            this.cbNetworkStreamingAudioEnabled.Name = "cbNetworkStreamingAudioEnabled";
            this.cbNetworkStreamingAudioEnabled.Size = new System.Drawing.Size(88, 17);
            this.cbNetworkStreamingAudioEnabled.TabIndex = 16;
            this.cbNetworkStreamingAudioEnabled.Text = "Stream audio";
            this.cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreaming
            // 
            this.cbNetworkStreaming.AutoSize = true;
            this.cbNetworkStreaming.Location = new System.Drawing.Point(18, 16);
            this.cbNetworkStreaming.Name = "cbNetworkStreaming";
            this.cbNetworkStreaming.Size = new System.Drawing.Size(155, 17);
            this.cbNetworkStreaming.TabIndex = 7;
            this.cbNetworkStreaming.Text = "Network streaming enabled";
            this.cbNetworkStreaming.UseVisualStyleBackColor = true;
            // 
            // tabPage28
            // 
            this.tabPage28.Controls.Add(this.btOSDRenderLayers);
            this.tabPage28.Controls.Add(this.lbOSDLayers);
            this.tabPage28.Controls.Add(this.cbOSDEnabled);
            this.tabPage28.Controls.Add(this.groupBox19);
            this.tabPage28.Controls.Add(this.btOSDClearLayers);
            this.tabPage28.Controls.Add(this.groupBox15);
            this.tabPage28.Controls.Add(this.label108);
            this.tabPage28.Location = new System.Drawing.Point(4, 22);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage28.Size = new System.Drawing.Size(307, 484);
            this.tabPage28.TabIndex = 10;
            this.tabPage28.Text = "OSD";
            this.tabPage28.UseVisualStyleBackColor = true;
            // 
            // btOSDRenderLayers
            // 
            this.btOSDRenderLayers.Location = new System.Drawing.Point(161, 199);
            this.btOSDRenderLayers.Name = "btOSDRenderLayers";
            this.btOSDRenderLayers.Size = new System.Drawing.Size(117, 23);
            this.btOSDRenderLayers.TabIndex = 17;
            this.btOSDRenderLayers.Text = "Render layers";
            this.btOSDRenderLayers.UseVisualStyleBackColor = true;
            this.btOSDRenderLayers.Click += new System.EventHandler(this.btOSDRenderLayers_Click);
            // 
            // lbOSDLayers
            // 
            this.lbOSDLayers.CheckOnClick = true;
            this.lbOSDLayers.FormattingEnabled = true;
            this.lbOSDLayers.Location = new System.Drawing.Point(15, 61);
            this.lbOSDLayers.Name = "lbOSDLayers";
            this.lbOSDLayers.Size = new System.Drawing.Size(139, 109);
            this.lbOSDLayers.TabIndex = 16;
            this.lbOSDLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbOSDLayers_ItemCheck);
            // 
            // cbOSDEnabled
            // 
            this.cbOSDEnabled.AutoSize = true;
            this.cbOSDEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbOSDEnabled.Name = "cbOSDEnabled";
            this.cbOSDEnabled.Size = new System.Drawing.Size(251, 17);
            this.cbOSDEnabled.TabIndex = 15;
            this.cbOSDEnabled.Text = "Enabled (should be set before playback started)";
            this.cbOSDEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btOSDClearLayer);
            this.groupBox19.Controls.Add(this.tabControl6);
            this.groupBox19.Location = new System.Drawing.Point(15, 228);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(262, 250);
            this.groupBox19.TabIndex = 6;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Selected layer";
            // 
            // btOSDClearLayer
            // 
            this.btOSDClearLayer.Location = new System.Drawing.Point(6, 221);
            this.btOSDClearLayer.Name = "btOSDClearLayer";
            this.btOSDClearLayer.Size = new System.Drawing.Size(91, 23);
            this.btOSDClearLayer.TabIndex = 3;
            this.btOSDClearLayer.Text = "Clear layer";
            this.btOSDClearLayer.UseVisualStyleBackColor = true;
            this.btOSDClearLayer.Click += new System.EventHandler(this.btOSDClearLayer_Click);
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage30);
            this.tabControl6.Controls.Add(this.tabPage31);
            this.tabControl6.Controls.Add(this.tabPage32);
            this.tabControl6.Location = new System.Drawing.Point(6, 19);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(250, 196);
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
            this.tabPage30.Location = new System.Drawing.Point(4, 22);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage30.Size = new System.Drawing.Size(242, 170);
            this.tabPage30.TabIndex = 1;
            this.tabPage30.Text = "Image";
            this.tabPage30.UseVisualStyleBackColor = true;
            // 
            // btOSDImageDraw
            // 
            this.btOSDImageDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDImageDraw.Location = new System.Drawing.Point(178, 141);
            this.btOSDImageDraw.Name = "btOSDImageDraw";
            this.btOSDImageDraw.Size = new System.Drawing.Size(57, 23);
            this.btOSDImageDraw.TabIndex = 47;
            this.btOSDImageDraw.Text = "Draw";
            this.btOSDImageDraw.UseVisualStyleBackColor = true;
            this.btOSDImageDraw.Click += new System.EventHandler(this.btOSDImageDraw_Click);
            // 
            // pnOSDColorKey
            // 
            this.pnOSDColorKey.BackColor = System.Drawing.Color.Fuchsia;
            this.pnOSDColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnOSDColorKey.Location = new System.Drawing.Point(162, 97);
            this.pnOSDColorKey.Name = "pnOSDColorKey";
            this.pnOSDColorKey.Size = new System.Drawing.Size(24, 24);
            this.pnOSDColorKey.TabIndex = 45;
            this.pnOSDColorKey.Click += new System.EventHandler(this.pnOSDColorKey_Click);
            // 
            // cbOSDImageTranspColor
            // 
            this.cbOSDImageTranspColor.AutoSize = true;
            this.cbOSDImageTranspColor.Location = new System.Drawing.Point(15, 102);
            this.cbOSDImageTranspColor.Name = "cbOSDImageTranspColor";
            this.cbOSDImageTranspColor.Size = new System.Drawing.Size(135, 17);
            this.cbOSDImageTranspColor.TabIndex = 7;
            this.cbOSDImageTranspColor.Text = "Use transparency color";
            this.cbOSDImageTranspColor.UseVisualStyleBackColor = true;
            // 
            // edOSDImageTop
            // 
            this.edOSDImageTop.Location = new System.Drawing.Point(132, 67);
            this.edOSDImageTop.Name = "edOSDImageTop";
            this.edOSDImageTop.Size = new System.Drawing.Size(38, 20);
            this.edOSDImageTop.TabIndex = 6;
            this.edOSDImageTop.Text = "0";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(101, 70);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(26, 13);
            this.label115.TabIndex = 5;
            this.label115.Text = "Top";
            // 
            // edOSDImageLeft
            // 
            this.edOSDImageLeft.Location = new System.Drawing.Point(49, 67);
            this.edOSDImageLeft.Name = "edOSDImageLeft";
            this.edOSDImageLeft.Size = new System.Drawing.Size(38, 20);
            this.edOSDImageLeft.TabIndex = 4;
            this.edOSDImageLeft.Text = "0";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(12, 70);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(25, 13);
            this.label114.TabIndex = 3;
            this.label114.Text = "Left";
            // 
            // btOSDSelectImage
            // 
            this.btOSDSelectImage.Location = new System.Drawing.Point(213, 30);
            this.btOSDSelectImage.Name = "btOSDSelectImage";
            this.btOSDSelectImage.Size = new System.Drawing.Size(22, 23);
            this.btOSDSelectImage.TabIndex = 2;
            this.btOSDSelectImage.Text = "...";
            this.btOSDSelectImage.UseVisualStyleBackColor = true;
            this.btOSDSelectImage.Click += new System.EventHandler(this.btOSDSelectImage_Click);
            // 
            // edOSDImageFilename
            // 
            this.edOSDImageFilename.Location = new System.Drawing.Point(15, 32);
            this.edOSDImageFilename.Name = "edOSDImageFilename";
            this.edOSDImageFilename.Size = new System.Drawing.Size(192, 20);
            this.edOSDImageFilename.TabIndex = 1;
            this.edOSDImageFilename.Text = "c:\\logo.png";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(12, 16);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(52, 13);
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
            this.tabPage31.Location = new System.Drawing.Point(4, 22);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage31.Size = new System.Drawing.Size(242, 170);
            this.tabPage31.TabIndex = 2;
            this.tabPage31.Text = "Text";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // edOSDTextTop
            // 
            this.edOSDTextTop.Location = new System.Drawing.Point(132, 67);
            this.edOSDTextTop.Name = "edOSDTextTop";
            this.edOSDTextTop.Size = new System.Drawing.Size(38, 20);
            this.edOSDTextTop.TabIndex = 55;
            this.edOSDTextTop.Text = "0";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(101, 70);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(26, 13);
            this.label117.TabIndex = 54;
            this.label117.Text = "Top";
            // 
            // edOSDTextLeft
            // 
            this.edOSDTextLeft.Location = new System.Drawing.Point(49, 67);
            this.edOSDTextLeft.Name = "edOSDTextLeft";
            this.edOSDTextLeft.Size = new System.Drawing.Size(38, 20);
            this.edOSDTextLeft.TabIndex = 53;
            this.edOSDTextLeft.Text = "0";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(12, 70);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(25, 13);
            this.label118.TabIndex = 52;
            this.label118.Text = "Left";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(12, 16);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(28, 13);
            this.label116.TabIndex = 51;
            this.label116.Text = "Text";
            // 
            // btOSDSelectFont
            // 
            this.btOSDSelectFont.Location = new System.Drawing.Point(198, 30);
            this.btOSDSelectFont.Name = "btOSDSelectFont";
            this.btOSDSelectFont.Size = new System.Drawing.Size(37, 23);
            this.btOSDSelectFont.TabIndex = 50;
            this.btOSDSelectFont.Text = "Font";
            this.btOSDSelectFont.UseVisualStyleBackColor = true;
            this.btOSDSelectFont.Click += new System.EventHandler(this.btOSDSelectFont_Click);
            // 
            // edOSDText
            // 
            this.edOSDText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.edOSDText.Location = new System.Drawing.Point(15, 32);
            this.edOSDText.Name = "edOSDText";
            this.edOSDText.Size = new System.Drawing.Size(180, 20);
            this.edOSDText.TabIndex = 49;
            this.edOSDText.Text = "Hello!!!";
            // 
            // btOSDTextDraw
            // 
            this.btOSDTextDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDTextDraw.Location = new System.Drawing.Point(178, 141);
            this.btOSDTextDraw.Name = "btOSDTextDraw";
            this.btOSDTextDraw.Size = new System.Drawing.Size(57, 23);
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
            this.tabPage32.Location = new System.Drawing.Point(4, 22);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage32.Size = new System.Drawing.Size(242, 170);
            this.tabPage32.TabIndex = 3;
            this.tabPage32.Text = "Other";
            this.tabPage32.UseVisualStyleBackColor = true;
            // 
            // tbOSDTranspLevel
            // 
            this.tbOSDTranspLevel.BackColor = System.Drawing.SystemColors.Window;
            this.tbOSDTranspLevel.Location = new System.Drawing.Point(15, 32);
            this.tbOSDTranspLevel.Maximum = 255;
            this.tbOSDTranspLevel.Name = "tbOSDTranspLevel";
            this.tbOSDTranspLevel.Size = new System.Drawing.Size(143, 45);
            this.tbOSDTranspLevel.TabIndex = 3;
            this.tbOSDTranspLevel.TickFrequency = 10;
            // 
            // btOSDSetTransp
            // 
            this.btOSDSetTransp.Location = new System.Drawing.Point(178, 41);
            this.btOSDSetTransp.Name = "btOSDSetTransp";
            this.btOSDSetTransp.Size = new System.Drawing.Size(48, 23);
            this.btOSDSetTransp.TabIndex = 2;
            this.btOSDSetTransp.Text = "Set";
            this.btOSDSetTransp.UseVisualStyleBackColor = true;
            this.btOSDSetTransp.Click += new System.EventHandler(this.btOSDSetTransp_Click);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(12, 16);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(97, 13);
            this.label119.TabIndex = 0;
            this.label119.Text = "Transparency level";
            // 
            // btOSDClearLayers
            // 
            this.btOSDClearLayers.Location = new System.Drawing.Point(15, 199);
            this.btOSDClearLayers.Name = "btOSDClearLayers";
            this.btOSDClearLayers.Size = new System.Drawing.Size(140, 23);
            this.btOSDClearLayers.TabIndex = 5;
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
            this.groupBox15.Location = new System.Drawing.Point(161, 53);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(117, 134);
            this.groupBox15.TabIndex = 4;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "New layer";
            // 
            // btOSDLayerAdd
            // 
            this.btOSDLayerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btOSDLayerAdd.Location = new System.Drawing.Point(31, 107);
            this.btOSDLayerAdd.Name = "btOSDLayerAdd";
            this.btOSDLayerAdd.Size = new System.Drawing.Size(56, 23);
            this.btOSDLayerAdd.TabIndex = 8;
            this.btOSDLayerAdd.Text = "Create";
            this.btOSDLayerAdd.UseVisualStyleBackColor = true;
            this.btOSDLayerAdd.Click += new System.EventHandler(this.btOSDLayerAdd_Click);
            // 
            // edOSDLayerHeight
            // 
            this.edOSDLayerHeight.Location = new System.Drawing.Point(65, 81);
            this.edOSDLayerHeight.Name = "edOSDLayerHeight";
            this.edOSDLayerHeight.Size = new System.Drawing.Size(38, 20);
            this.edOSDLayerHeight.TabIndex = 7;
            this.edOSDLayerHeight.Text = "200";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(62, 65);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(38, 13);
            this.label111.TabIndex = 6;
            this.label111.Text = "Height";
            // 
            // edOSDLayerWidth
            // 
            this.edOSDLayerWidth.Location = new System.Drawing.Point(13, 81);
            this.edOSDLayerWidth.Name = "edOSDLayerWidth";
            this.edOSDLayerWidth.Size = new System.Drawing.Size(38, 20);
            this.edOSDLayerWidth.TabIndex = 5;
            this.edOSDLayerWidth.Text = "200";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(10, 65);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(35, 13);
            this.label112.TabIndex = 4;
            this.label112.Text = "Width";
            // 
            // edOSDLayerTop
            // 
            this.edOSDLayerTop.Location = new System.Drawing.Point(65, 42);
            this.edOSDLayerTop.Name = "edOSDLayerTop";
            this.edOSDLayerTop.Size = new System.Drawing.Size(38, 20);
            this.edOSDLayerTop.TabIndex = 3;
            this.edOSDLayerTop.Text = "0";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(62, 26);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(26, 13);
            this.label110.TabIndex = 2;
            this.label110.Text = "Top";
            // 
            // edOSDLayerLeft
            // 
            this.edOSDLayerLeft.Location = new System.Drawing.Point(13, 42);
            this.edOSDLayerLeft.Name = "edOSDLayerLeft";
            this.edOSDLayerLeft.Size = new System.Drawing.Size(38, 20);
            this.edOSDLayerLeft.TabIndex = 1;
            this.edOSDLayerLeft.Text = "0";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(10, 26);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(25, 13);
            this.label109.TabIndex = 0;
            this.label109.Text = "Left";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(12, 45);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(38, 13);
            this.label108.TabIndex = 2;
            this.label108.Text = "Layers";
            // 
            // tabPage43
            // 
            this.tabPage43.Controls.Add(this.tabControl9);
            this.tabPage43.Controls.Add(this.cbMotDetEnabled);
            this.tabPage43.Location = new System.Drawing.Point(4, 22);
            this.tabPage43.Name = "tabPage43";
            this.tabPage43.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage43.Size = new System.Drawing.Size(307, 484);
            this.tabPage43.TabIndex = 11;
            this.tabPage43.Text = "Motion detection";
            this.tabPage43.UseVisualStyleBackColor = true;
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.tabPage44);
            this.tabControl9.Controls.Add(this.tabPage45);
            this.tabControl9.Location = new System.Drawing.Point(16, 45);
            this.tabControl9.Name = "tabControl9";
            this.tabControl9.SelectedIndex = 0;
            this.tabControl9.Size = new System.Drawing.Size(268, 413);
            this.tabControl9.TabIndex = 1;
            // 
            // tabPage44
            // 
            this.tabPage44.Controls.Add(this.pbMotionLevel);
            this.tabPage44.Controls.Add(this.label158);
            this.tabPage44.Controls.Add(this.mmMotDetMatrix);
            this.tabPage44.Location = new System.Drawing.Point(4, 22);
            this.tabPage44.Name = "tabPage44";
            this.tabPage44.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage44.Size = new System.Drawing.Size(260, 387);
            this.tabPage44.TabIndex = 0;
            this.tabPage44.Text = "Output matrix";
            this.tabPage44.UseVisualStyleBackColor = true;
            // 
            // pbMotionLevel
            // 
            this.pbMotionLevel.Location = new System.Drawing.Point(10, 336);
            this.pbMotionLevel.Name = "pbMotionLevel";
            this.pbMotionLevel.Size = new System.Drawing.Size(224, 19);
            this.pbMotionLevel.TabIndex = 2;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(7, 320);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(64, 13);
            this.label158.TabIndex = 1;
            this.label158.Text = "Motion level";
            // 
            // mmMotDetMatrix
            // 
            this.mmMotDetMatrix.Location = new System.Drawing.Point(6, 6);
            this.mmMotDetMatrix.Multiline = true;
            this.mmMotDetMatrix.Name = "mmMotDetMatrix";
            this.mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmMotDetMatrix.Size = new System.Drawing.Size(248, 253);
            this.mmMotDetMatrix.TabIndex = 0;
            // 
            // tabPage45
            // 
            this.tabPage45.Controls.Add(this.groupBox25);
            this.tabPage45.Controls.Add(this.btMotDetUpdateSettings);
            this.tabPage45.Controls.Add(this.groupBox27);
            this.tabPage45.Controls.Add(this.groupBox26);
            this.tabPage45.Controls.Add(this.groupBox24);
            this.tabPage45.Location = new System.Drawing.Point(4, 22);
            this.tabPage45.Name = "tabPage45";
            this.tabPage45.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage45.Size = new System.Drawing.Size(260, 387);
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
            this.groupBox25.Location = new System.Drawing.Point(12, 103);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(233, 86);
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
            this.cbMotDetHLColor.Location = new System.Drawing.Point(153, 59);
            this.cbMotDetHLColor.Name = "cbMotDetHLColor";
            this.cbMotDetHLColor.Size = new System.Drawing.Size(70, 21);
            this.cbMotDetHLColor.TabIndex = 5;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(148, 42);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(31, 13);
            this.label161.TabIndex = 4;
            this.label161.Text = "Color";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(30, 42);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(54, 13);
            this.label160.TabIndex = 2;
            this.label160.Text = "Threshold";
            // 
            // cbMotDetHLEnabled
            // 
            this.cbMotDetHLEnabled.AutoSize = true;
            this.cbMotDetHLEnabled.Checked = true;
            this.cbMotDetHLEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMotDetHLEnabled.Location = new System.Drawing.Point(14, 22);
            this.cbMotDetHLEnabled.Name = "cbMotDetHLEnabled";
            this.cbMotDetHLEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbMotDetHLEnabled.TabIndex = 1;
            this.cbMotDetHLEnabled.Text = "Enabled";
            this.cbMotDetHLEnabled.UseVisualStyleBackColor = true;
            // 
            // tbMotDetHLThreshold
            // 
            this.tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.tbMotDetHLThreshold.Location = new System.Drawing.Point(31, 58);
            this.tbMotDetHLThreshold.Maximum = 255;
            this.tbMotDetHLThreshold.Name = "tbMotDetHLThreshold";
            this.tbMotDetHLThreshold.Size = new System.Drawing.Size(104, 45);
            this.tbMotDetHLThreshold.TabIndex = 3;
            this.tbMotDetHLThreshold.TickFrequency = 5;
            this.tbMotDetHLThreshold.Value = 25;
            // 
            // btMotDetUpdateSettings
            // 
            this.btMotDetUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btMotDetUpdateSettings.Location = new System.Drawing.Point(138, 358);
            this.btMotDetUpdateSettings.Name = "btMotDetUpdateSettings";
            this.btMotDetUpdateSettings.Size = new System.Drawing.Size(107, 23);
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
            this.groupBox27.Location = new System.Drawing.Point(12, 266);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(233, 59);
            this.groupBox27.TabIndex = 3;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Matrix";
            // 
            // edMotDetMatrixHeight
            // 
            this.edMotDetMatrixHeight.Location = new System.Drawing.Point(145, 23);
            this.edMotDetMatrixHeight.Name = "edMotDetMatrixHeight";
            this.edMotDetMatrixHeight.Size = new System.Drawing.Size(36, 20);
            this.edMotDetMatrixHeight.TabIndex = 75;
            this.edMotDetMatrixHeight.Text = "10";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(98, 26);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(38, 13);
            this.label163.TabIndex = 74;
            this.label163.Text = "Height";
            // 
            // edMotDetMatrixWidth
            // 
            this.edMotDetMatrixWidth.Location = new System.Drawing.Point(56, 23);
            this.edMotDetMatrixWidth.Name = "edMotDetMatrixWidth";
            this.edMotDetMatrixWidth.Size = new System.Drawing.Size(36, 20);
            this.edMotDetMatrixWidth.TabIndex = 73;
            this.edMotDetMatrixWidth.Text = "10";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(14, 26);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(35, 13);
            this.label164.TabIndex = 72;
            this.label164.Text = "Width";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label162);
            this.groupBox26.Controls.Add(this.tbMotDetDropFramesThreshold);
            this.groupBox26.Controls.Add(this.cbMotDetDropFramesEnabled);
            this.groupBox26.Location = new System.Drawing.Point(12, 191);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(233, 69);
            this.groupBox26.TabIndex = 2;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Drop frames";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(94, 21);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(54, 13);
            this.label162.TabIndex = 4;
            this.label162.Text = "Threshold";
            // 
            // tbMotDetDropFramesThreshold
            // 
            this.tbMotDetDropFramesThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.tbMotDetDropFramesThreshold.Location = new System.Drawing.Point(95, 37);
            this.tbMotDetDropFramesThreshold.Maximum = 255;
            this.tbMotDetDropFramesThreshold.Name = "tbMotDetDropFramesThreshold";
            this.tbMotDetDropFramesThreshold.Size = new System.Drawing.Size(104, 45);
            this.tbMotDetDropFramesThreshold.TabIndex = 5;
            this.tbMotDetDropFramesThreshold.TickFrequency = 5;
            this.tbMotDetDropFramesThreshold.Value = 5;
            // 
            // cbMotDetDropFramesEnabled
            // 
            this.cbMotDetDropFramesEnabled.AutoSize = true;
            this.cbMotDetDropFramesEnabled.Location = new System.Drawing.Point(14, 19);
            this.cbMotDetDropFramesEnabled.Name = "cbMotDetDropFramesEnabled";
            this.cbMotDetDropFramesEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.groupBox24.Location = new System.Drawing.Point(12, 12);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(233, 82);
            this.groupBox24.TabIndex = 0;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Compare settings";
            // 
            // edMotDetFrameInterval
            // 
            this.edMotDetFrameInterval.Location = new System.Drawing.Point(95, 51);
            this.edMotDetFrameInterval.Name = "edMotDetFrameInterval";
            this.edMotDetFrameInterval.Size = new System.Drawing.Size(32, 20);
            this.edMotDetFrameInterval.TabIndex = 5;
            this.edMotDetFrameInterval.Text = "2";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(11, 54);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(73, 13);
            this.label159.TabIndex = 4;
            this.label159.Text = "Frame interval";
            // 
            // cbCompareGreyscale
            // 
            this.cbCompareGreyscale.AutoSize = true;
            this.cbCompareGreyscale.Checked = true;
            this.cbCompareGreyscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCompareGreyscale.Location = new System.Drawing.Point(163, 21);
            this.cbCompareGreyscale.Name = "cbCompareGreyscale";
            this.cbCompareGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbCompareGreyscale.TabIndex = 3;
            this.cbCompareGreyscale.Text = "Greyscale";
            this.cbCompareGreyscale.UseVisualStyleBackColor = true;
            // 
            // cbCompareBlue
            // 
            this.cbCompareBlue.AutoSize = true;
            this.cbCompareBlue.Location = new System.Drawing.Point(118, 21);
            this.cbCompareBlue.Name = "cbCompareBlue";
            this.cbCompareBlue.Size = new System.Drawing.Size(47, 17);
            this.cbCompareBlue.TabIndex = 2;
            this.cbCompareBlue.Text = "Blue";
            this.cbCompareBlue.UseVisualStyleBackColor = true;
            // 
            // cbCompareGreen
            // 
            this.cbCompareGreen.AutoSize = true;
            this.cbCompareGreen.Location = new System.Drawing.Point(60, 21);
            this.cbCompareGreen.Name = "cbCompareGreen";
            this.cbCompareGreen.Size = new System.Drawing.Size(55, 17);
            this.cbCompareGreen.TabIndex = 1;
            this.cbCompareGreen.Text = "Green";
            this.cbCompareGreen.UseVisualStyleBackColor = true;
            // 
            // cbCompareRed
            // 
            this.cbCompareRed.AutoSize = true;
            this.cbCompareRed.Location = new System.Drawing.Point(14, 21);
            this.cbCompareRed.Name = "cbCompareRed";
            this.cbCompareRed.Size = new System.Drawing.Size(46, 17);
            this.cbCompareRed.TabIndex = 0;
            this.cbCompareRed.Text = "Red";
            this.cbCompareRed.UseVisualStyleBackColor = true;
            // 
            // cbMotDetEnabled
            // 
            this.cbMotDetEnabled.AutoSize = true;
            this.cbMotDetEnabled.Location = new System.Drawing.Point(16, 18);
            this.cbMotDetEnabled.Name = "cbMotDetEnabled";
            this.cbMotDetEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbMotDetEnabled.TabIndex = 0;
            this.cbMotDetEnabled.Text = "Enabled";
            this.cbMotDetEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage26
            // 
            this.tabPage26.Controls.Add(this.label505);
            this.tabPage26.Controls.Add(this.rbMotionDetectionExProcessor);
            this.tabPage26.Controls.Add(this.label389);
            this.tabPage26.Controls.Add(this.rbMotionDetectionExDetector);
            this.tabPage26.Controls.Add(this.label64);
            this.tabPage26.Controls.Add(this.label65);
            this.tabPage26.Controls.Add(this.pbAFMotionLevel);
            this.tabPage26.Controls.Add(this.cbMotionDetectionEx);
            this.tabPage26.Location = new System.Drawing.Point(4, 22);
            this.tabPage26.Name = "tabPage26";
            this.tabPage26.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage26.Size = new System.Drawing.Size(307, 484);
            this.tabPage26.TabIndex = 20;
            this.tabPage26.Text = "Motion detection (Extended)";
            this.tabPage26.UseVisualStyleBackColor = true;
            // 
            // label505
            // 
            this.label505.AutoSize = true;
            this.label505.Location = new System.Drawing.Point(19, 106);
            this.label505.Name = "label505";
            this.label505.Size = new System.Drawing.Size(54, 13);
            this.label505.TabIndex = 23;
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
            this.rbMotionDetectionExProcessor.Location = new System.Drawing.Point(19, 122);
            this.rbMotionDetectionExProcessor.Name = "rbMotionDetectionExProcessor";
            this.rbMotionDetectionExProcessor.Size = new System.Drawing.Size(258, 21);
            this.rbMotionDetectionExProcessor.TabIndex = 22;
            // 
            // label389
            // 
            this.label389.AutoSize = true;
            this.label389.Location = new System.Drawing.Point(19, 56);
            this.label389.Name = "label389";
            this.label389.Size = new System.Drawing.Size(48, 13);
            this.label389.TabIndex = 21;
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
            this.rbMotionDetectionExDetector.Location = new System.Drawing.Point(19, 72);
            this.rbMotionDetectionExDetector.Name = "rbMotionDetectionExDetector";
            this.rbMotionDetectionExDetector.Size = new System.Drawing.Size(258, 21);
            this.rbMotionDetectionExDetector.TabIndex = 20;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(56, 444);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(173, 13);
            this.label64.TabIndex = 19;
            this.label64.Text = "Much more options available in API";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(19, 164);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(64, 13);
            this.label65.TabIndex = 18;
            this.label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = new System.Drawing.Point(19, 180);
            this.pbAFMotionLevel.Name = "pbAFMotionLevel";
            this.pbAFMotionLevel.Size = new System.Drawing.Size(258, 23);
            this.pbAFMotionLevel.TabIndex = 17;
            // 
            // cbMotionDetectionEx
            // 
            this.cbMotionDetectionEx.AutoSize = true;
            this.cbMotionDetectionEx.Location = new System.Drawing.Point(19, 18);
            this.cbMotionDetectionEx.Name = "cbMotionDetectionEx";
            this.cbMotionDetectionEx.Size = new System.Drawing.Size(65, 17);
            this.cbMotionDetectionEx.TabIndex = 15;
            this.cbMotionDetectionEx.Text = "Enabled";
            this.cbMotionDetectionEx.UseVisualStyleBackColor = true;
            this.cbMotionDetectionEx.CheckedChanged += new System.EventHandler(this.cbAFMotionDetection_CheckedChanged);
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
            this.tabPage25.Location = new System.Drawing.Point(4, 22);
            this.tabPage25.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage25.Name = "tabPage25";
            this.tabPage25.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage25.Size = new System.Drawing.Size(307, 484);
            this.tabPage25.TabIndex = 13;
            this.tabPage25.Text = "Barcode reader";
            this.tabPage25.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = new System.Drawing.Point(16, 160);
            this.edBarcodeMetadata.Margin = new System.Windows.Forms.Padding(2);
            this.edBarcodeMetadata.Multiline = true;
            this.edBarcodeMetadata.Name = "edBarcodeMetadata";
            this.edBarcodeMetadata.Size = new System.Drawing.Size(282, 96);
            this.edBarcodeMetadata.TabIndex = 8;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(14, 141);
            this.label91.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(52, 13);
            this.label91.TabIndex = 7;
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
            this.cbBarcodeType.Location = new System.Drawing.Point(16, 64);
            this.cbBarcodeType.Margin = new System.Windows.Forms.Padding(2);
            this.cbBarcodeType.Name = "cbBarcodeType";
            this.cbBarcodeType.Size = new System.Drawing.Size(160, 21);
            this.cbBarcodeType.TabIndex = 6;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(14, 48);
            this.label90.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(70, 13);
            this.label90.TabIndex = 5;
            this.label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = new System.Drawing.Point(16, 268);
            this.btBarcodeReset.Margin = new System.Windows.Forms.Padding(2);
            this.btBarcodeReset.Name = "btBarcodeReset";
            this.btBarcodeReset.Size = new System.Drawing.Size(62, 23);
            this.btBarcodeReset.TabIndex = 4;
            this.btBarcodeReset.Text = "Restart";
            this.btBarcodeReset.UseVisualStyleBackColor = true;
            this.btBarcodeReset.Click += new System.EventHandler(this.btBarcodeReset_Click);
            // 
            // edBarcode
            // 
            this.edBarcode.Location = new System.Drawing.Point(16, 112);
            this.edBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.edBarcode.Name = "edBarcode";
            this.edBarcode.Size = new System.Drawing.Size(282, 20);
            this.edBarcode.TabIndex = 3;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(14, 96);
            this.label89.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(93, 13);
            this.label89.TabIndex = 2;
            this.label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = true;
            this.cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(16, 18);
            this.cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            this.cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbBarcodeDetectionEnabled.TabIndex = 1;
            this.cbBarcodeDetectionEnabled.Text = "Enabled";
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage101
            // 
            this.tabPage101.Controls.Add(this.label328);
            this.tabPage101.Controls.Add(this.label327);
            this.tabPage101.Controls.Add(this.label326);
            this.tabPage101.Controls.Add(this.label325);
            this.tabPage101.Controls.Add(this.cbVirtualCamera);
            this.tabPage101.Location = new System.Drawing.Point(4, 22);
            this.tabPage101.Name = "tabPage101";
            this.tabPage101.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage101.Size = new System.Drawing.Size(307, 484);
            this.tabPage101.TabIndex = 14;
            this.tabPage101.Text = "Virtual camera";
            this.tabPage101.UseVisualStyleBackColor = true;
            // 
            // label328
            // 
            this.label328.AutoSize = true;
            this.label328.Location = new System.Drawing.Point(17, 125);
            this.label328.Name = "label328";
            this.label328.Size = new System.Drawing.Size(197, 13);
            this.label328.TabIndex = 4;
            this.label328.Text = "TRIAL limitation - 5000 frames to stream.";
            // 
            // label327
            // 
            this.label327.AutoSize = true;
            this.label327.Location = new System.Drawing.Point(17, 103);
            this.label327.Name = "label327";
            this.label327.Size = new System.Drawing.Size(180, 13);
            this.label327.TabIndex = 3;
            this.label327.Text = "Virtual Camera SDK license required.";
            // 
            // label326
            // 
            this.label326.AutoSize = true;
            this.label326.Location = new System.Drawing.Point(17, 72);
            this.label326.Name = "label326";
            this.label326.Size = new System.Drawing.Size(111, 13);
            this.label326.TabIndex = 2;
            this.label326.Text = "to see streamed video";
            // 
            // label325
            // 
            this.label325.AutoSize = true;
            this.label325.Location = new System.Drawing.Point(17, 52);
            this.label325.Name = "label325";
            this.label325.Size = new System.Drawing.Size(243, 13);
            this.label325.TabIndex = 1;
            this.label325.Text = "You are can use VisioForge Virtual Camera device";
            // 
            // cbVirtualCamera
            // 
            this.cbVirtualCamera.AutoSize = true;
            this.cbVirtualCamera.Location = new System.Drawing.Point(20, 18);
            this.cbVirtualCamera.Name = "cbVirtualCamera";
            this.cbVirtualCamera.Size = new System.Drawing.Size(107, 17);
            this.cbVirtualCamera.TabIndex = 0;
            this.cbVirtualCamera.Text = "Enable streaming";
            this.cbVirtualCamera.UseVisualStyleBackColor = true;
            // 
            // tabPage103
            // 
            this.tabPage103.Controls.Add(this.cbDecklinkOutputDownConversionAnalogOutput);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputDownConversion);
            this.tabPage103.Controls.Add(this.label337);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputHDTVPulldown);
            this.tabPage103.Controls.Add(this.label336);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputBlackToDeck);
            this.tabPage103.Controls.Add(this.label335);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputSingleField);
            this.tabPage103.Controls.Add(this.label334);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputComponentLevels);
            this.tabPage103.Controls.Add(this.label333);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputNTSC);
            this.tabPage103.Controls.Add(this.label332);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputDualLink);
            this.tabPage103.Controls.Add(this.label331);
            this.tabPage103.Controls.Add(this.cbDecklinkOutputAnalog);
            this.tabPage103.Controls.Add(this.label87);
            this.tabPage103.Controls.Add(this.cbDecklinkDV);
            this.tabPage103.Controls.Add(this.cbDecklinkOutput);
            this.tabPage103.Location = new System.Drawing.Point(4, 22);
            this.tabPage103.Name = "tabPage103";
            this.tabPage103.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage103.Size = new System.Drawing.Size(307, 484);
            this.tabPage103.TabIndex = 15;
            this.tabPage103.Text = "Decklink output";
            this.tabPage103.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutputDownConversionAnalogOutput
            // 
            this.cbDecklinkOutputDownConversionAnalogOutput.AutoSize = true;
            this.cbDecklinkOutputDownConversionAnalogOutput.Location = new System.Drawing.Point(18, 248);
            this.cbDecklinkOutputDownConversionAnalogOutput.Name = "cbDecklinkOutputDownConversionAnalogOutput";
            this.cbDecklinkOutputDownConversionAnalogOutput.Size = new System.Drawing.Size(118, 17);
            this.cbDecklinkOutputDownConversionAnalogOutput.TabIndex = 18;
            this.cbDecklinkOutputDownConversionAnalogOutput.Text = "Analog output used";
            this.cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutputDownConversion
            // 
            this.cbDecklinkOutputDownConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputDownConversion.FormattingEnabled = true;
            this.cbDecklinkOutputDownConversion.Items.AddRange(new object[] {
            "Default",
            "Disabled",
            "Letterbox 16:9",
            "Anamorphic",
            "Anamorphic center"});
            this.cbDecklinkOutputDownConversion.Location = new System.Drawing.Point(18, 224);
            this.cbDecklinkOutputDownConversion.Name = "cbDecklinkOutputDownConversion";
            this.cbDecklinkOutputDownConversion.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputDownConversion.TabIndex = 17;
            // 
            // label337
            // 
            this.label337.AutoSize = true;
            this.label337.Location = new System.Drawing.Point(15, 208);
            this.label337.Name = "label337";
            this.label337.Size = new System.Drawing.Size(119, 13);
            this.label337.TabIndex = 16;
            this.label337.Text = "Down conversion mode";
            // 
            // cbDecklinkOutputHDTVPulldown
            // 
            this.cbDecklinkOutputHDTVPulldown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputHDTVPulldown.FormattingEnabled = true;
            this.cbDecklinkOutputHDTVPulldown.Items.AddRange(new object[] {
            "Default",
            "Enabled",
            "Disabled"});
            this.cbDecklinkOutputHDTVPulldown.Location = new System.Drawing.Point(18, 295);
            this.cbDecklinkOutputHDTVPulldown.Name = "cbDecklinkOutputHDTVPulldown";
            this.cbDecklinkOutputHDTVPulldown.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputHDTVPulldown.TabIndex = 15;
            // 
            // label336
            // 
            this.label336.AutoSize = true;
            this.label336.Location = new System.Drawing.Point(15, 279);
            this.label336.Name = "label336";
            this.label336.Size = new System.Drawing.Size(82, 13);
            this.label336.TabIndex = 14;
            this.label336.Text = "HDTV pulldown";
            // 
            // cbDecklinkOutputBlackToDeck
            // 
            this.cbDecklinkOutputBlackToDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputBlackToDeck.FormattingEnabled = true;
            this.cbDecklinkOutputBlackToDeck.Items.AddRange(new object[] {
            "Default",
            "None",
            "Digital",
            "Analogue"});
            this.cbDecklinkOutputBlackToDeck.Location = new System.Drawing.Point(18, 177);
            this.cbDecklinkOutputBlackToDeck.Name = "cbDecklinkOutputBlackToDeck";
            this.cbDecklinkOutputBlackToDeck.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputBlackToDeck.TabIndex = 13;
            // 
            // label335
            // 
            this.label335.AutoSize = true;
            this.label335.Location = new System.Drawing.Point(15, 161);
            this.label335.Name = "label335";
            this.label335.Size = new System.Drawing.Size(73, 13);
            this.label335.TabIndex = 12;
            this.label335.Text = "Black to deck";
            // 
            // cbDecklinkOutputSingleField
            // 
            this.cbDecklinkOutputSingleField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputSingleField.FormattingEnabled = true;
            this.cbDecklinkOutputSingleField.Items.AddRange(new object[] {
            "Default",
            "Enabled",
            "Disabled"});
            this.cbDecklinkOutputSingleField.Location = new System.Drawing.Point(18, 132);
            this.cbDecklinkOutputSingleField.Name = "cbDecklinkOutputSingleField";
            this.cbDecklinkOutputSingleField.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputSingleField.TabIndex = 11;
            // 
            // label334
            // 
            this.label334.AutoSize = true;
            this.label334.Location = new System.Drawing.Point(15, 116);
            this.label334.Name = "label334";
            this.label334.Size = new System.Drawing.Size(91, 13);
            this.label334.TabIndex = 10;
            this.label334.Text = "Single field output";
            // 
            // cbDecklinkOutputComponentLevels
            // 
            this.cbDecklinkOutputComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputComponentLevels.FormattingEnabled = true;
            this.cbDecklinkOutputComponentLevels.Items.AddRange(new object[] {
            "SMPTE",
            "Betacam"});
            this.cbDecklinkOutputComponentLevels.Location = new System.Drawing.Point(154, 177);
            this.cbDecklinkOutputComponentLevels.Name = "cbDecklinkOutputComponentLevels";
            this.cbDecklinkOutputComponentLevels.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputComponentLevels.TabIndex = 9;
            // 
            // label333
            // 
            this.label333.AutoSize = true;
            this.label333.Location = new System.Drawing.Point(151, 161);
            this.label333.Name = "label333";
            this.label333.Size = new System.Drawing.Size(91, 13);
            this.label333.TabIndex = 8;
            this.label333.Text = "Component levels";
            // 
            // cbDecklinkOutputNTSC
            // 
            this.cbDecklinkOutputNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputNTSC.FormattingEnabled = true;
            this.cbDecklinkOutputNTSC.Items.AddRange(new object[] {
            "USA",
            "Japan"});
            this.cbDecklinkOutputNTSC.Location = new System.Drawing.Point(154, 132);
            this.cbDecklinkOutputNTSC.Name = "cbDecklinkOutputNTSC";
            this.cbDecklinkOutputNTSC.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputNTSC.TabIndex = 7;
            // 
            // label332
            // 
            this.label332.AutoSize = true;
            this.label332.Location = new System.Drawing.Point(151, 116);
            this.label332.Name = "label332";
            this.label332.Size = new System.Drawing.Size(80, 13);
            this.label332.TabIndex = 6;
            this.label332.Text = "NTSC standard";
            // 
            // cbDecklinkOutputDualLink
            // 
            this.cbDecklinkOutputDualLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputDualLink.FormattingEnabled = true;
            this.cbDecklinkOutputDualLink.Items.AddRange(new object[] {
            "Default",
            "Enabled",
            "Disabled"});
            this.cbDecklinkOutputDualLink.Location = new System.Drawing.Point(18, 87);
            this.cbDecklinkOutputDualLink.Name = "cbDecklinkOutputDualLink";
            this.cbDecklinkOutputDualLink.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputDualLink.TabIndex = 5;
            // 
            // label331
            // 
            this.label331.AutoSize = true;
            this.label331.Location = new System.Drawing.Point(15, 71);
            this.label331.Name = "label331";
            this.label331.Size = new System.Drawing.Size(77, 13);
            this.label331.TabIndex = 4;
            this.label331.Text = "Dual link mode";
            // 
            // cbDecklinkOutputAnalog
            // 
            this.cbDecklinkOutputAnalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkOutputAnalog.FormattingEnabled = true;
            this.cbDecklinkOutputAnalog.Items.AddRange(new object[] {
            "Auto",
            "Component",
            "Composite",
            "S-Video"});
            this.cbDecklinkOutputAnalog.Location = new System.Drawing.Point(154, 87);
            this.cbDecklinkOutputAnalog.Name = "cbDecklinkOutputAnalog";
            this.cbDecklinkOutputAnalog.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkOutputAnalog.TabIndex = 3;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(151, 71);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(73, 13);
            this.label87.TabIndex = 2;
            this.label87.Text = "Analog output";
            // 
            // cbDecklinkDV
            // 
            this.cbDecklinkDV.AutoSize = true;
            this.cbDecklinkDV.Location = new System.Drawing.Point(27, 39);
            this.cbDecklinkDV.Name = "cbDecklinkDV";
            this.cbDecklinkDV.Size = new System.Drawing.Size(74, 17);
            this.cbDecklinkDV.TabIndex = 1;
            this.cbDecklinkDV.Text = "DV output";
            this.cbDecklinkDV.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutput
            // 
            this.cbDecklinkOutput.AutoSize = true;
            this.cbDecklinkOutput.Location = new System.Drawing.Point(9, 16);
            this.cbDecklinkOutput.Name = "cbDecklinkOutput";
            this.cbDecklinkOutput.Size = new System.Drawing.Size(173, 17);
            this.cbDecklinkOutput.TabIndex = 0;
            this.cbDecklinkOutput.Text = "Enable output to Decklink card";
            this.cbDecklinkOutput.UseVisualStyleBackColor = true;
            // 
            // tabPage141
            // 
            this.tabPage141.Controls.Add(this.TabControl32);
            this.tabPage141.Controls.Add(this.cbTagEnabled);
            this.tabPage141.Location = new System.Drawing.Point(4, 22);
            this.tabPage141.Name = "tabPage141";
            this.tabPage141.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage141.Size = new System.Drawing.Size(307, 484);
            this.tabPage141.TabIndex = 19;
            this.tabPage141.Text = "Tags";
            this.tabPage141.UseVisualStyleBackColor = true;
            // 
            // TabControl32
            // 
            this.TabControl32.Controls.Add(this.TabPage142);
            this.TabControl32.Controls.Add(this.TabPage143);
            this.TabControl32.Location = new System.Drawing.Point(7, 41);
            this.TabControl32.Name = "TabControl32";
            this.TabControl32.SelectedIndex = 0;
            this.TabControl32.Size = new System.Drawing.Size(292, 432);
            this.TabControl32.TabIndex = 3;
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
            this.TabPage142.Location = new System.Drawing.Point(4, 22);
            this.TabPage142.Name = "TabPage142";
            this.TabPage142.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage142.Size = new System.Drawing.Size(284, 406);
            this.TabPage142.TabIndex = 0;
            this.TabPage142.Text = "Common";
            this.TabPage142.UseVisualStyleBackColor = true;
            // 
            // edTagTrackID
            // 
            this.edTagTrackID.Location = new System.Drawing.Point(16, 207);
            this.edTagTrackID.Name = "edTagTrackID";
            this.edTagTrackID.Size = new System.Drawing.Size(63, 20);
            this.edTagTrackID.TabIndex = 13;
            this.edTagTrackID.Text = "1";
            // 
            // Label496
            // 
            this.Label496.AutoSize = true;
            this.Label496.Location = new System.Drawing.Point(13, 192);
            this.Label496.Name = "Label496";
            this.Label496.Size = new System.Drawing.Size(49, 13);
            this.Label496.TabIndex = 12;
            this.Label496.Text = "Track ID";
            // 
            // edTagYear
            // 
            this.edTagYear.Location = new System.Drawing.Point(16, 301);
            this.edTagYear.Name = "edTagYear";
            this.edTagYear.Size = new System.Drawing.Size(63, 20);
            this.edTagYear.TabIndex = 11;
            this.edTagYear.Text = "2015";
            // 
            // Label495
            // 
            this.Label495.AutoSize = true;
            this.Label495.Location = new System.Drawing.Point(13, 286);
            this.Label495.Name = "Label495";
            this.Label495.Size = new System.Drawing.Size(29, 13);
            this.Label495.TabIndex = 10;
            this.Label495.Text = "Year";
            // 
            // edTagComment
            // 
            this.edTagComment.Location = new System.Drawing.Point(16, 160);
            this.edTagComment.Name = "edTagComment";
            this.edTagComment.Size = new System.Drawing.Size(242, 20);
            this.edTagComment.TabIndex = 9;
            this.edTagComment.Text = "No comments";
            // 
            // Label493
            // 
            this.Label493.AutoSize = true;
            this.Label493.Location = new System.Drawing.Point(13, 145);
            this.Label493.Name = "Label493";
            this.Label493.Size = new System.Drawing.Size(51, 13);
            this.Label493.TabIndex = 8;
            this.Label493.Text = "Comment";
            // 
            // edTagAlbum
            // 
            this.edTagAlbum.Location = new System.Drawing.Point(16, 116);
            this.edTagAlbum.Name = "edTagAlbum";
            this.edTagAlbum.Size = new System.Drawing.Size(242, 20);
            this.edTagAlbum.TabIndex = 7;
            this.edTagAlbum.Text = "Sample album";
            // 
            // Label491
            // 
            this.Label491.AutoSize = true;
            this.Label491.Location = new System.Drawing.Point(13, 101);
            this.Label491.Name = "Label491";
            this.Label491.Size = new System.Drawing.Size(36, 13);
            this.Label491.TabIndex = 6;
            this.Label491.Text = "Album";
            // 
            // edTagArtists
            // 
            this.edTagArtists.Location = new System.Drawing.Point(16, 72);
            this.edTagArtists.Name = "edTagArtists";
            this.edTagArtists.Size = new System.Drawing.Size(242, 20);
            this.edTagArtists.TabIndex = 5;
            this.edTagArtists.Text = "Sample artist";
            // 
            // label494
            // 
            this.label494.AutoSize = true;
            this.label494.Location = new System.Drawing.Point(13, 57);
            this.label494.Name = "label494";
            this.label494.Size = new System.Drawing.Size(35, 13);
            this.label494.TabIndex = 4;
            this.label494.Text = "Artists";
            // 
            // edTagCopyright
            // 
            this.edTagCopyright.Location = new System.Drawing.Point(16, 255);
            this.edTagCopyright.Name = "edTagCopyright";
            this.edTagCopyright.Size = new System.Drawing.Size(242, 20);
            this.edTagCopyright.TabIndex = 3;
            this.edTagCopyright.Text = "VisioForge";
            // 
            // label497
            // 
            this.label497.AutoSize = true;
            this.label497.Location = new System.Drawing.Point(13, 240);
            this.label497.Name = "label497";
            this.label497.Size = new System.Drawing.Size(51, 13);
            this.label497.TabIndex = 2;
            this.label497.Text = "Copyright";
            // 
            // edTagTitle
            // 
            this.edTagTitle.Location = new System.Drawing.Point(16, 29);
            this.edTagTitle.Name = "edTagTitle";
            this.edTagTitle.Size = new System.Drawing.Size(242, 20);
            this.edTagTitle.TabIndex = 1;
            this.edTagTitle.Text = "Sample output file";
            // 
            // label498
            // 
            this.label498.AutoSize = true;
            this.label498.Location = new System.Drawing.Point(13, 14);
            this.label498.Name = "label498";
            this.label498.Size = new System.Drawing.Size(27, 13);
            this.label498.TabIndex = 0;
            this.label498.Text = "Title";
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
            this.TabPage143.Location = new System.Drawing.Point(4, 22);
            this.TabPage143.Name = "TabPage143";
            this.TabPage143.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage143.Size = new System.Drawing.Size(284, 406);
            this.TabPage143.TabIndex = 1;
            this.TabPage143.Text = "Special";
            this.TabPage143.UseVisualStyleBackColor = true;
            // 
            // imgTagCover
            // 
            this.imgTagCover.BackColor = System.Drawing.Color.DimGray;
            this.imgTagCover.Location = new System.Drawing.Point(15, 178);
            this.imgTagCover.Name = "imgTagCover";
            this.imgTagCover.Size = new System.Drawing.Size(168, 137);
            this.imgTagCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTagCover.TabIndex = 16;
            this.imgTagCover.TabStop = false;
            this.imgTagCover.Click += new System.EventHandler(this.imgTagCover_Click);
            // 
            // Label499
            // 
            this.Label499.AutoSize = true;
            this.Label499.Location = new System.Drawing.Point(12, 162);
            this.Label499.Name = "Label499";
            this.Label499.Size = new System.Drawing.Size(109, 13);
            this.Label499.TabIndex = 15;
            this.Label499.Text = "Cover (click to select)";
            // 
            // label500
            // 
            this.label500.AutoSize = true;
            this.label500.Location = new System.Drawing.Point(43, 334);
            this.label500.Name = "label500";
            this.label500.Size = new System.Drawing.Size(194, 13);
            this.label500.TabIndex = 14;
            this.label500.Text = "Many other tags are available using API";
            // 
            // edTagLyrics
            // 
            this.edTagLyrics.Location = new System.Drawing.Point(15, 127);
            this.edTagLyrics.Name = "edTagLyrics";
            this.edTagLyrics.Size = new System.Drawing.Size(242, 20);
            this.edTagLyrics.TabIndex = 13;
            this.edTagLyrics.Text = "Yo-ho-ho and the buttle of rum";
            // 
            // label501
            // 
            this.label501.AutoSize = true;
            this.label501.Location = new System.Drawing.Point(12, 112);
            this.label501.Name = "label501";
            this.label501.Size = new System.Drawing.Size(34, 13);
            this.label501.TabIndex = 12;
            this.label501.Text = "Lyrics";
            // 
            // cbTagGenre
            // 
            this.cbTagGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTagGenre.FormattingEnabled = true;
            this.cbTagGenre.Location = new System.Drawing.Point(15, 76);
            this.cbTagGenre.Name = "cbTagGenre";
            this.cbTagGenre.Size = new System.Drawing.Size(242, 21);
            this.cbTagGenre.TabIndex = 11;
            // 
            // label502
            // 
            this.label502.AutoSize = true;
            this.label502.Location = new System.Drawing.Point(12, 60);
            this.label502.Name = "label502";
            this.label502.Size = new System.Drawing.Size(36, 13);
            this.label502.TabIndex = 10;
            this.label502.Text = "Genre";
            // 
            // edTagComposers
            // 
            this.edTagComposers.Location = new System.Drawing.Point(15, 29);
            this.edTagComposers.Name = "edTagComposers";
            this.edTagComposers.Size = new System.Drawing.Size(242, 20);
            this.edTagComposers.TabIndex = 9;
            this.edTagComposers.Text = "Sample composer";
            // 
            // label503
            // 
            this.label503.AutoSize = true;
            this.label503.Location = new System.Drawing.Point(12, 14);
            this.label503.Name = "label503";
            this.label503.Size = new System.Drawing.Size(59, 13);
            this.label503.TabIndex = 8;
            this.label503.Text = "Composers";
            // 
            // cbTagEnabled
            // 
            this.cbTagEnabled.AutoSize = true;
            this.cbTagEnabled.Location = new System.Drawing.Point(16, 11);
            this.cbTagEnabled.Name = "cbTagEnabled";
            this.cbTagEnabled.Size = new System.Drawing.Size(135, 17);
            this.cbTagEnabled.TabIndex = 2;
            this.cbTagEnabled.Text = "Write tags to output file";
            this.cbTagEnabled.UseVisualStyleBackColor = true;
            // 
            // cbMode
            // 
            this.cbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Video Preview",
            "Video Capture",
            "Audio Preview",
            "Audio Capture",
            "Screen Preview",
            "Screen Capture",
            "IP Preview",
            "IP Capture",
            "DVB-x Preview",
            "DVB-x Capture",
            "Custom Source Preview",
            "Custom Source Capture",
            "DeckLink Source Preview",
            "DeckLink Source Capture"});
            this.cbMode.Location = new System.Drawing.Point(366, 682);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(154, 21);
            this.cbMode.TabIndex = 61;
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(538, 680);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 71;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(599, 680);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 72;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // tabControl10
            // 
            this.tabControl10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl10.Controls.Add(this.tabPage46);
            this.tabControl10.Controls.Add(this.tabPage63);
            this.tabControl10.Controls.Add(this.tabPage47);
            this.tabControl10.Controls.Add(this.tabPage48);
            this.tabControl10.Controls.Add(this.tabPage4);
            this.tabControl10.Controls.Add(this.tabPage81);
            this.tabControl10.Controls.Add(this.tabPage49);
            this.tabControl10.Controls.Add(this.tabPage50);
            this.tabControl10.Controls.Add(this.tabPage51);
            this.tabControl10.Controls.Add(this.tabPage12);
            this.tabControl10.Controls.Add(this.tabPage88);
            this.tabControl10.Controls.Add(this.tabPage124);
            this.tabControl10.Location = new System.Drawing.Point(329, 8);
            this.tabControl10.Name = "tabControl10";
            this.tabControl10.SelectedIndex = 0;
            this.tabControl10.Size = new System.Drawing.Size(467, 311);
            this.tabControl10.TabIndex = 74;
            // 
            // tabPage46
            // 
            this.tabPage46.Controls.Add(this.tabControl2);
            this.tabPage46.Location = new System.Drawing.Point(4, 22);
            this.tabPage46.Name = "tabPage46";
            this.tabPage46.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage46.Size = new System.Drawing.Size(459, 285);
            this.tabPage46.TabIndex = 0;
            this.tabPage46.Text = "Video capture device";
            this.tabPage46.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage52);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Controls.Add(this.tabPage57);
            this.tabControl2.Controls.Add(this.tabPage66);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(456, 272);
            this.tabControl2.TabIndex = 66;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.btSignal);
            this.tabPage8.Controls.Add(this.label28);
            this.tabPage8.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage8.Controls.Add(this.btVideoCaptureDeviceSettings);
            this.tabPage8.Controls.Add(this.label18);
            this.tabPage8.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage8.Controls.Add(this.cbVideoInputFormat);
            this.tabPage8.Controls.Add(this.cbVideoInputDevice);
            this.tabPage8.Controls.Add(this.label13);
            this.tabPage8.Controls.Add(this.label11);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(448, 246);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Video input";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // btSignal
            // 
            this.btSignal.Location = new System.Drawing.Point(308, 33);
            this.btSignal.Name = "btSignal";
            this.btSignal.Size = new System.Drawing.Size(65, 23);
            this.btSignal.TabIndex = 137;
            this.btSignal.Text = "Signal";
            this.btSignal.UseVisualStyleBackColor = true;
            this.btSignal.Click += new System.EventHandler(this.btSignal_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(308, 102);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 119;
            this.label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(160, 75);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 118;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestVideoInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestVideoInputFormat_CheckedChanged);
            // 
            // btVideoCaptureDeviceSettings
            // 
            this.btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(237, 33);
            this.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            this.btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(65, 23);
            this.btVideoCaptureDeviceSettings.TabIndex = 117;
            this.btVideoCaptureDeviceSettings.Text = "Settings";
            this.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            this.btVideoCaptureDeviceSettings.Click += new System.EventHandler(this.btVideoCaptureDeviceSettings_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(234, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 116;
            this.label18.Text = "Frame rate";
            // 
            // cbFramerate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(237, 97);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(65, 21);
            this.cbVideoInputFrameRate.TabIndex = 115;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(23, 97);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(208, 21);
            this.cbVideoInputFormat.TabIndex = 114;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(23, 35);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(208, 21);
            this.cbVideoInputDevice.TabIndex = 113;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 112;
            this.label13.Text = "Input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 111;
            this.label11.Text = "Input device";
            // 
            // tabPage52
            // 
            this.tabPage52.Controls.Add(this.cbCrossBarAvailable);
            this.tabPage52.Controls.Add(this.lbRotes);
            this.tabPage52.Controls.Add(this.label61);
            this.tabPage52.Controls.Add(this.label60);
            this.tabPage52.Controls.Add(this.cbConnectRelated);
            this.tabPage52.Controls.Add(this.btConnect);
            this.tabPage52.Controls.Add(this.cbCrossbarVideoInput);
            this.tabPage52.Controls.Add(this.label59);
            this.tabPage52.Controls.Add(this.rbCrossbarAdvanced);
            this.tabPage52.Controls.Add(this.rbCrossbarSimple);
            this.tabPage52.Controls.Add(this.cbCrossbarOutput);
            this.tabPage52.Controls.Add(this.cbCrossbarInput);
            this.tabPage52.Controls.Add(this.label16);
            this.tabPage52.Location = new System.Drawing.Point(4, 22);
            this.tabPage52.Name = "tabPage52";
            this.tabPage52.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage52.Size = new System.Drawing.Size(448, 246);
            this.tabPage52.TabIndex = 7;
            this.tabPage52.Text = "Crossbar (Source)";
            this.tabPage52.UseVisualStyleBackColor = true;
            // 
            // cbCrossBarAvailable
            // 
            this.cbCrossBarAvailable.AutoSize = true;
            this.cbCrossBarAvailable.Enabled = false;
            this.cbCrossBarAvailable.Location = new System.Drawing.Point(279, 21);
            this.cbCrossBarAvailable.Name = "cbCrossBarAvailable";
            this.cbCrossBarAvailable.Size = new System.Drawing.Size(112, 17);
            this.cbCrossBarAvailable.TabIndex = 94;
            this.cbCrossBarAvailable.Text = "Crossbar available";
            this.cbCrossBarAvailable.UseVisualStyleBackColor = true;
            // 
            // lbRotes
            // 
            this.lbRotes.FormattingEnabled = true;
            this.lbRotes.Location = new System.Drawing.Point(99, 164);
            this.lbRotes.Name = "lbRotes";
            this.lbRotes.Size = new System.Drawing.Size(246, 43);
            this.lbRotes.TabIndex = 93;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(52, 186);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(36, 13);
            this.label61.TabIndex = 92;
            this.label61.Text = "routes";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(52, 164);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(41, 13);
            this.label60.TabIndex = 91;
            this.label60.Text = "Current";
            // 
            // cbConnectRelated
            // 
            this.cbConnectRelated.AutoSize = true;
            this.cbConnectRelated.Checked = true;
            this.cbConnectRelated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConnectRelated.Location = new System.Drawing.Point(244, 112);
            this.cbConnectRelated.Name = "cbConnectRelated";
            this.cbConnectRelated.Size = new System.Drawing.Size(101, 17);
            this.cbConnectRelated.TabIndex = 90;
            this.cbConnectRelated.Text = "Connect related";
            this.cbConnectRelated.UseVisualStyleBackColor = true;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(279, 135);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(66, 23);
            this.btConnect.TabIndex = 89;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // cbCrossbarVideoInput
            // 
            this.cbCrossbarVideoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCrossbarVideoInput.FormattingEnabled = true;
            this.cbCrossbarVideoInput.Location = new System.Drawing.Point(127, 44);
            this.cbCrossbarVideoInput.Name = "cbCrossbarVideoInput";
            this.cbCrossbarVideoInput.Size = new System.Drawing.Size(93, 21);
            this.cbCrossbarVideoInput.TabIndex = 88;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(52, 47);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(60, 13);
            this.label59.TabIndex = 87;
            this.label59.Text = "Video input";
            // 
            // rbCrossbarAdvanced
            // 
            this.rbCrossbarAdvanced.AutoSize = true;
            this.rbCrossbarAdvanced.Location = new System.Drawing.Point(19, 87);
            this.rbCrossbarAdvanced.Name = "rbCrossbarAdvanced";
            this.rbCrossbarAdvanced.Size = new System.Drawing.Size(74, 17);
            this.rbCrossbarAdvanced.TabIndex = 86;
            this.rbCrossbarAdvanced.Text = "Advanced";
            this.rbCrossbarAdvanced.UseVisualStyleBackColor = true;
            // 
            // rbCrossbarSimple
            // 
            this.rbCrossbarSimple.AutoSize = true;
            this.rbCrossbarSimple.Checked = true;
            this.rbCrossbarSimple.Location = new System.Drawing.Point(19, 20);
            this.rbCrossbarSimple.Name = "rbCrossbarSimple";
            this.rbCrossbarSimple.Size = new System.Drawing.Size(56, 17);
            this.rbCrossbarSimple.TabIndex = 85;
            this.rbCrossbarSimple.TabStop = true;
            this.rbCrossbarSimple.Text = "Simple";
            this.rbCrossbarSimple.UseVisualStyleBackColor = true;
            // 
            // cbCrossbarOutput
            // 
            this.cbCrossbarOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCrossbarOutput.FormattingEnabled = true;
            this.cbCrossbarOutput.Location = new System.Drawing.Point(163, 137);
            this.cbCrossbarOutput.Name = "cbCrossbarOutput";
            this.cbCrossbarOutput.Size = new System.Drawing.Size(100, 21);
            this.cbCrossbarOutput.TabIndex = 84;
            this.cbCrossbarOutput.SelectedIndexChanged += new System.EventHandler(this.cbCrossbarOutput_SelectedIndexChanged);
            // 
            // cbCrossbarInput
            // 
            this.cbCrossbarInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCrossbarInput.FormattingEnabled = true;
            this.cbCrossbarInput.Location = new System.Drawing.Point(55, 137);
            this.cbCrossbarInput.Name = "cbCrossbarInput";
            this.cbCrossbarInput.Size = new System.Drawing.Size(100, 21);
            this.cbCrossbarInput.TabIndex = 83;
            this.cbCrossbarInput.SelectedIndexChanged += new System.EventHandler(this.cbCrossbarInput_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(52, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 13);
            this.label16.TabIndex = 82;
            this.label16.Text = "Crossbar (INPUT - OUTPUT)";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.tabControl3);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(448, 246);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "TV tuner";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage14);
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Controls.Add(this.tabPage21);
            this.tabControl3.Location = new System.Drawing.Point(3, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(439, 234);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.cbUseClosedCaptions);
            this.tabPage14.Controls.Add(this.edTVDefaultFormat);
            this.tabPage14.Controls.Add(this.label57);
            this.tabPage14.Controls.Add(this.cbTVCountry);
            this.tabPage14.Controls.Add(this.label56);
            this.tabPage14.Controls.Add(this.cbTVMode);
            this.tabPage14.Controls.Add(this.cbTVInput);
            this.tabPage14.Controls.Add(this.cbTVTuner);
            this.tabPage14.Controls.Add(this.label33);
            this.tabPage14.Controls.Add(this.label32);
            this.tabPage14.Controls.Add(this.label27);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(431, 208);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "Main settings";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // cbUseClosedCaptions
            // 
            this.cbUseClosedCaptions.AutoSize = true;
            this.cbUseClosedCaptions.Location = new System.Drawing.Point(26, 150);
            this.cbUseClosedCaptions.Name = "cbUseClosedCaptions";
            this.cbUseClosedCaptions.Size = new System.Drawing.Size(160, 17);
            this.cbUseClosedCaptions.TabIndex = 60;
            this.cbUseClosedCaptions.Text = "Allow closed captions usage";
            this.cbUseClosedCaptions.UseVisualStyleBackColor = true;
            // 
            // edTVDefaultFormat
            // 
            this.edTVDefaultFormat.Location = new System.Drawing.Point(232, 102);
            this.edTVDefaultFormat.Name = "edTVDefaultFormat";
            this.edTVDefaultFormat.ReadOnly = true;
            this.edTVDefaultFormat.Size = new System.Drawing.Size(83, 20);
            this.edTVDefaultFormat.TabIndex = 59;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(229, 83);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(73, 13);
            this.label57.TabIndex = 58;
            this.label57.Text = "Default format";
            // 
            // cbTVCountry
            // 
            this.cbTVCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVCountry.FormattingEnabled = true;
            this.cbTVCountry.Location = new System.Drawing.Point(73, 102);
            this.cbTVCountry.Name = "cbTVCountry";
            this.cbTVCountry.Size = new System.Drawing.Size(150, 21);
            this.cbTVCountry.TabIndex = 57;
            this.cbTVCountry.SelectedIndexChanged += new System.EventHandler(this.cbTVCountry_SelectedIndexChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(23, 105);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(43, 13);
            this.label56.TabIndex = 56;
            this.label56.Text = "Country";
            // 
            // cbTVMode
            // 
            this.cbTVMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVMode.FormattingEnabled = true;
            this.cbTVMode.Items.AddRange(new object[] {
            "Default",
            "TV",
            "FM Radio",
            "AM Radio",
            "DSS"});
            this.cbTVMode.Location = new System.Drawing.Point(72, 51);
            this.cbTVMode.Name = "cbTVMode";
            this.cbTVMode.Size = new System.Drawing.Size(86, 21);
            this.cbTVMode.TabIndex = 55;
            this.cbTVMode.SelectedIndexChanged += new System.EventHandler(this.cbTVMode_SelectedIndexChanged);
            // 
            // cbTVInput
            // 
            this.cbTVInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVInput.FormattingEnabled = true;
            this.cbTVInput.Items.AddRange(new object[] {
            "Cable",
            "Antenna"});
            this.cbTVInput.Location = new System.Drawing.Point(229, 51);
            this.cbTVInput.Name = "cbTVInput";
            this.cbTVInput.Size = new System.Drawing.Size(86, 21);
            this.cbTVInput.TabIndex = 54;
            this.cbTVInput.SelectedIndexChanged += new System.EventHandler(this.cbTVInput_SelectedIndexChanged);
            // 
            // cbTVTuner
            // 
            this.cbTVTuner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVTuner.FormattingEnabled = true;
            this.cbTVTuner.Location = new System.Drawing.Point(72, 16);
            this.cbTVTuner.Name = "cbTVTuner";
            this.cbTVTuner.Size = new System.Drawing.Size(243, 21);
            this.cbTVTuner.TabIndex = 53;
            this.cbTVTuner.SelectedIndexChanged += new System.EventHandler(this.cbTVTuner_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(23, 54);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 13);
            this.label33.TabIndex = 52;
            this.label33.Text = "Mode";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(192, 54);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(31, 13);
            this.label32.TabIndex = 51;
            this.label32.Text = "Input";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(23, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 13);
            this.label27.TabIndex = 50;
            this.label27.Text = "Device";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.edChannel);
            this.tabPage15.Controls.Add(this.btUseThisChannel);
            this.tabPage15.Controls.Add(this.groupBox1);
            this.tabPage15.Controls.Add(this.cbTVSystem);
            this.tabPage15.Controls.Add(this.edAudioFreq);
            this.tabPage15.Controls.Add(this.label36);
            this.tabPage15.Controls.Add(this.edVideoFreq);
            this.tabPage15.Controls.Add(this.label37);
            this.tabPage15.Controls.Add(this.label34);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(431, 208);
            this.tabPage15.TabIndex = 1;
            this.tabPage15.Text = "Tuning";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // edChannel
            // 
            this.edChannel.Location = new System.Drawing.Point(334, 136);
            this.edChannel.Name = "edChannel";
            this.edChannel.Size = new System.Drawing.Size(79, 20);
            this.edChannel.TabIndex = 59;
            this.edChannel.Text = "22";
            // 
            // btUseThisChannel
            // 
            this.btUseThisChannel.Location = new System.Drawing.Point(224, 133);
            this.btUseThisChannel.Name = "btUseThisChannel";
            this.btUseThisChannel.Size = new System.Drawing.Size(104, 23);
            this.btUseThisChannel.TabIndex = 58;
            this.btUseThisChannel.Text = "Set channel/freq.";
            this.btUseThisChannel.UseVisualStyleBackColor = true;
            this.btUseThisChannel.Click += new System.EventHandler(this.btUseThisChannel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTVChannel);
            this.groupBox1.Controls.Add(this.label58);
            this.groupBox1.Controls.Add(this.pbChannels);
            this.groupBox1.Controls.Add(this.btStopTune);
            this.groupBox1.Controls.Add(this.btStartTune);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 97);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AutoTune";
            // 
            // cbTVChannel
            // 
            this.cbTVChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVChannel.FormattingEnabled = true;
            this.cbTVChannel.Location = new System.Drawing.Point(165, 56);
            this.cbTVChannel.Name = "cbTVChannel";
            this.cbTVChannel.Size = new System.Drawing.Size(82, 21);
            this.cbTVChannel.TabIndex = 4;
            this.cbTVChannel.SelectedIndexChanged += new System.EventHandler(this.cbTVChannel_SelectedIndexChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(17, 59);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(142, 13);
            this.label58.TabIndex = 3;
            this.label58.Text = "TV Channel / FM Frequency";
            // 
            // pbChannels
            // 
            this.pbChannels.Location = new System.Drawing.Point(147, 23);
            this.pbChannels.Name = "pbChannels";
            this.pbChannels.Size = new System.Drawing.Size(100, 15);
            this.pbChannels.TabIndex = 2;
            // 
            // btStopTune
            // 
            this.btStopTune.Location = new System.Drawing.Point(76, 19);
            this.btStopTune.Name = "btStopTune";
            this.btStopTune.Size = new System.Drawing.Size(50, 23);
            this.btStopTune.TabIndex = 1;
            this.btStopTune.Text = "Stop";
            this.btStopTune.UseVisualStyleBackColor = true;
            this.btStopTune.Click += new System.EventHandler(this.btStopTune_Click);
            // 
            // btStartTune
            // 
            this.btStartTune.Location = new System.Drawing.Point(20, 19);
            this.btStartTune.Name = "btStartTune";
            this.btStartTune.Size = new System.Drawing.Size(50, 23);
            this.btStartTune.TabIndex = 0;
            this.btStartTune.Text = "Start";
            this.btStartTune.UseVisualStyleBackColor = true;
            this.btStartTune.Click += new System.EventHandler(this.btStartTune_Click);
            // 
            // cbTVSystem
            // 
            this.cbTVSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTVSystem.FormattingEnabled = true;
            this.cbTVSystem.Location = new System.Drawing.Point(101, 136);
            this.cbTVSystem.Name = "cbTVSystem";
            this.cbTVSystem.Size = new System.Drawing.Size(86, 21);
            this.cbTVSystem.TabIndex = 56;
            this.cbTVSystem.SelectedIndexChanged += new System.EventHandler(this.cbTVSystem_SelectedIndexChanged);
            // 
            // edAudioFreq
            // 
            this.edAudioFreq.Location = new System.Drawing.Point(384, 76);
            this.edAudioFreq.Name = "edAudioFreq";
            this.edAudioFreq.Size = new System.Drawing.Size(29, 20);
            this.edAudioFreq.TabIndex = 55;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(289, 78);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(84, 13);
            this.label36.TabIndex = 54;
            this.label36.Text = "Audio frequency";
            // 
            // edVideoFreq
            // 
            this.edVideoFreq.Location = new System.Drawing.Point(384, 35);
            this.edVideoFreq.Name = "edVideoFreq";
            this.edVideoFreq.Size = new System.Drawing.Size(29, 20);
            this.edVideoFreq.TabIndex = 53;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(289, 38);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 13);
            this.label37.TabIndex = 52;
            this.label37.Text = "Video frequency";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(13, 139);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(82, 13);
            this.label34.TabIndex = 51;
            this.label34.Text = "TV video format";
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.btMPEGEncoderShowDialog);
            this.tabPage21.Controls.Add(this.cbMPEGEncoder);
            this.tabPage21.Controls.Add(this.label21);
            this.tabPage21.Location = new System.Drawing.Point(4, 22);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage21.Size = new System.Drawing.Size(431, 208);
            this.tabPage21.TabIndex = 3;
            this.tabPage21.Text = "MPEG Encoder";
            this.tabPage21.UseVisualStyleBackColor = true;
            // 
            // btMPEGEncoderShowDialog
            // 
            this.btMPEGEncoderShowDialog.Location = new System.Drawing.Point(241, 30);
            this.btMPEGEncoderShowDialog.Name = "btMPEGEncoderShowDialog";
            this.btMPEGEncoderShowDialog.Size = new System.Drawing.Size(75, 23);
            this.btMPEGEncoderShowDialog.TabIndex = 2;
            this.btMPEGEncoderShowDialog.Text = "Settings";
            this.btMPEGEncoderShowDialog.UseVisualStyleBackColor = true;
            this.btMPEGEncoderShowDialog.Click += new System.EventHandler(this.btMPEGEncoderShowDialog_Click);
            // 
            // cbMPEGEncoder
            // 
            this.cbMPEGEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMPEGEncoder.FormattingEnabled = true;
            this.cbMPEGEncoder.Location = new System.Drawing.Point(19, 32);
            this.cbMPEGEncoder.Name = "cbMPEGEncoder";
            this.cbMPEGEncoder.Size = new System.Drawing.Size(216, 21);
            this.cbMPEGEncoder.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "MPEG Encoder";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.groupBox21);
            this.tabPage11.Controls.Add(this.groupBox2);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(448, 246);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "DV";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.rbDVResDC);
            this.groupBox21.Controls.Add(this.rbDVResQuarter);
            this.groupBox21.Controls.Add(this.rbDVResHalf);
            this.groupBox21.Controls.Add(this.rbDVResFull);
            this.groupBox21.Location = new System.Drawing.Point(19, 140);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(361, 45);
            this.groupBox21.TabIndex = 1;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Resolution";
            // 
            // rbDVResDC
            // 
            this.rbDVResDC.AutoSize = true;
            this.rbDVResDC.Location = new System.Drawing.Point(279, 19);
            this.rbDVResDC.Name = "rbDVResDC";
            this.rbDVResDC.Size = new System.Drawing.Size(40, 17);
            this.rbDVResDC.TabIndex = 3;
            this.rbDVResDC.Text = "DC";
            this.rbDVResDC.UseVisualStyleBackColor = true;
            // 
            // rbDVResQuarter
            // 
            this.rbDVResQuarter.AutoSize = true;
            this.rbDVResQuarter.Location = new System.Drawing.Point(183, 19);
            this.rbDVResQuarter.Name = "rbDVResQuarter";
            this.rbDVResQuarter.Size = new System.Drawing.Size(60, 17);
            this.rbDVResQuarter.TabIndex = 2;
            this.rbDVResQuarter.Text = "Quarter";
            this.rbDVResQuarter.UseVisualStyleBackColor = true;
            // 
            // rbDVResHalf
            // 
            this.rbDVResHalf.AutoSize = true;
            this.rbDVResHalf.Location = new System.Drawing.Point(104, 19);
            this.rbDVResHalf.Name = "rbDVResHalf";
            this.rbDVResHalf.Size = new System.Drawing.Size(44, 17);
            this.rbDVResHalf.TabIndex = 1;
            this.rbDVResHalf.Text = "Half";
            this.rbDVResHalf.UseVisualStyleBackColor = true;
            // 
            // rbDVResFull
            // 
            this.rbDVResFull.AutoSize = true;
            this.rbDVResFull.Checked = true;
            this.rbDVResFull.Location = new System.Drawing.Point(22, 19);
            this.rbDVResFull.Name = "rbDVResFull";
            this.rbDVResFull.Size = new System.Drawing.Size(41, 17);
            this.rbDVResFull.TabIndex = 0;
            this.rbDVResFull.TabStop = true;
            this.rbDVResFull.Text = "Full";
            this.rbDVResFull.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btDVStepFWD);
            this.groupBox2.Controls.Add(this.btDVStepRev);
            this.groupBox2.Controls.Add(this.btDVFF);
            this.groupBox2.Controls.Add(this.btDVStop);
            this.groupBox2.Controls.Add(this.btDVPause);
            this.groupBox2.Controls.Add(this.btDVPlay);
            this.groupBox2.Controls.Add(this.btDVRewind);
            this.groupBox2.Location = new System.Drawing.Point(19, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btDVStepFWD
            // 
            this.btDVStepFWD.Location = new System.Drawing.Point(251, 58);
            this.btDVStepFWD.Name = "btDVStepFWD";
            this.btDVStepFWD.Size = new System.Drawing.Size(68, 23);
            this.btDVStepFWD.TabIndex = 6;
            this.btDVStepFWD.Text = "Step FWD";
            this.btDVStepFWD.UseVisualStyleBackColor = true;
            this.btDVStepFWD.Click += new System.EventHandler(this.btDVStepFWD_Click);
            // 
            // btDVStepRev
            // 
            this.btDVStepRev.Location = new System.Drawing.Point(52, 58);
            this.btDVStepRev.Name = "btDVStepRev";
            this.btDVStepRev.Size = new System.Drawing.Size(68, 23);
            this.btDVStepRev.TabIndex = 5;
            this.btDVStepRev.Text = "Step REV";
            this.btDVStepRev.UseVisualStyleBackColor = true;
            this.btDVStepRev.Click += new System.EventHandler(this.btDVStepRev_Click);
            // 
            // btDVFF
            // 
            this.btDVFF.Location = new System.Drawing.Point(286, 23);
            this.btDVFF.Name = "btDVFF";
            this.btDVFF.Size = new System.Drawing.Size(60, 23);
            this.btDVFF.TabIndex = 4;
            this.btDVFF.Text = "F.F.";
            this.btDVFF.UseVisualStyleBackColor = true;
            this.btDVFF.Click += new System.EventHandler(this.btDVFF_Click);
            // 
            // btDVStop
            // 
            this.btDVStop.Location = new System.Drawing.Point(220, 23);
            this.btDVStop.Name = "btDVStop";
            this.btDVStop.Size = new System.Drawing.Size(60, 23);
            this.btDVStop.TabIndex = 3;
            this.btDVStop.Text = "Stop";
            this.btDVStop.UseVisualStyleBackColor = true;
            this.btDVStop.Click += new System.EventHandler(this.btDVStop_Click);
            // 
            // btDVPause
            // 
            this.btDVPause.Location = new System.Drawing.Point(154, 23);
            this.btDVPause.Name = "btDVPause";
            this.btDVPause.Size = new System.Drawing.Size(60, 23);
            this.btDVPause.TabIndex = 2;
            this.btDVPause.Text = "Pause";
            this.btDVPause.UseVisualStyleBackColor = true;
            this.btDVPause.Click += new System.EventHandler(this.btDVPause_Click);
            // 
            // btDVPlay
            // 
            this.btDVPlay.Location = new System.Drawing.Point(88, 23);
            this.btDVPlay.Name = "btDVPlay";
            this.btDVPlay.Size = new System.Drawing.Size(60, 23);
            this.btDVPlay.TabIndex = 1;
            this.btDVPlay.Text = "Play";
            this.btDVPlay.UseVisualStyleBackColor = true;
            this.btDVPlay.Click += new System.EventHandler(this.btDVPlay_Click);
            // 
            // btDVRewind
            // 
            this.btDVRewind.Location = new System.Drawing.Point(22, 23);
            this.btDVRewind.Name = "btDVRewind";
            this.btDVRewind.Size = new System.Drawing.Size(60, 23);
            this.btDVRewind.TabIndex = 0;
            this.btDVRewind.Text = "Rewind";
            this.btDVRewind.UseVisualStyleBackColor = true;
            this.btDVRewind.Click += new System.EventHandler(this.btDVRewind_Click);
            // 
            // tabPage57
            // 
            this.tabPage57.Controls.Add(this.lbAdjSaturationCurrent);
            this.tabPage57.Controls.Add(this.lbAdjSaturationMax);
            this.tabPage57.Controls.Add(this.cbAdjSaturationAuto);
            this.tabPage57.Controls.Add(this.lbAdjSaturationMin);
            this.tabPage57.Controls.Add(this.tbAdjSaturation);
            this.tabPage57.Controls.Add(this.label45);
            this.tabPage57.Controls.Add(this.lbAdjHueCurrent);
            this.tabPage57.Controls.Add(this.lbAdjHueMax);
            this.tabPage57.Controls.Add(this.cbAdjHueAuto);
            this.tabPage57.Controls.Add(this.lbAdjHueMin);
            this.tabPage57.Controls.Add(this.tbAdjHue);
            this.tabPage57.Controls.Add(this.label41);
            this.tabPage57.Controls.Add(this.lbAdjContrastCurrent);
            this.tabPage57.Controls.Add(this.lbAdjContrastMax);
            this.tabPage57.Controls.Add(this.cbAdjContrastAuto);
            this.tabPage57.Controls.Add(this.lbAdjContrastMin);
            this.tabPage57.Controls.Add(this.tbAdjContrast);
            this.tabPage57.Controls.Add(this.label23);
            this.tabPage57.Controls.Add(this.lbAdjBrightnessCurrent);
            this.tabPage57.Controls.Add(this.lbAdjBrightnessMax);
            this.tabPage57.Controls.Add(this.cbAdjBrightnessAuto);
            this.tabPage57.Controls.Add(this.lbAdjBrightnessMin);
            this.tabPage57.Controls.Add(this.tbAdjBrightness);
            this.tabPage57.Controls.Add(this.label17);
            this.tabPage57.Location = new System.Drawing.Point(4, 22);
            this.tabPage57.Name = "tabPage57";
            this.tabPage57.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage57.Size = new System.Drawing.Size(448, 246);
            this.tabPage57.TabIndex = 8;
            this.tabPage57.Text = "Video adjustments";
            this.tabPage57.UseVisualStyleBackColor = true;
            // 
            // lbAdjSaturationCurrent
            // 
            this.lbAdjSaturationCurrent.AutoSize = true;
            this.lbAdjSaturationCurrent.Location = new System.Drawing.Point(341, 125);
            this.lbAdjSaturationCurrent.Name = "lbAdjSaturationCurrent";
            this.lbAdjSaturationCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbAdjSaturationCurrent.TabIndex = 36;
            this.lbAdjSaturationCurrent.Text = "Current = 40";
            // 
            // lbAdjSaturationMax
            // 
            this.lbAdjSaturationMax.AutoSize = true;
            this.lbAdjSaturationMax.Location = new System.Drawing.Point(278, 125);
            this.lbAdjSaturationMax.Name = "lbAdjSaturationMax";
            this.lbAdjSaturationMax.Size = new System.Drawing.Size(57, 13);
            this.lbAdjSaturationMax.TabIndex = 35;
            this.lbAdjSaturationMax.Text = "Max = 100";
            // 
            // cbAdjSaturationAuto
            // 
            this.cbAdjSaturationAuto.AutoSize = true;
            this.cbAdjSaturationAuto.Location = new System.Drawing.Point(367, 79);
            this.cbAdjSaturationAuto.Name = "cbAdjSaturationAuto";
            this.cbAdjSaturationAuto.Size = new System.Drawing.Size(48, 17);
            this.cbAdjSaturationAuto.TabIndex = 34;
            this.cbAdjSaturationAuto.Text = "Auto";
            this.cbAdjSaturationAuto.UseVisualStyleBackColor = true;
            this.cbAdjSaturationAuto.CheckedChanged += new System.EventHandler(this.tbAdjSaturation_Scroll);
            // 
            // lbAdjSaturationMin
            // 
            this.lbAdjSaturationMin.AutoSize = true;
            this.lbAdjSaturationMin.Location = new System.Drawing.Point(230, 125);
            this.lbAdjSaturationMin.Name = "lbAdjSaturationMin";
            this.lbAdjSaturationMin.Size = new System.Drawing.Size(42, 13);
            this.lbAdjSaturationMin.TabIndex = 33;
            this.lbAdjSaturationMin.Text = "Min = 1";
            // 
            // tbAdjSaturation
            // 
            this.tbAdjSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjSaturation.Location = new System.Drawing.Point(224, 96);
            this.tbAdjSaturation.Maximum = 100;
            this.tbAdjSaturation.Name = "tbAdjSaturation";
            this.tbAdjSaturation.Size = new System.Drawing.Size(191, 45);
            this.tbAdjSaturation.TabIndex = 32;
            this.tbAdjSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjSaturation.Value = 50;
            this.tbAdjSaturation.Scroll += new System.EventHandler(this.tbAdjSaturation_Scroll);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(221, 80);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(55, 13);
            this.label45.TabIndex = 31;
            this.label45.Text = "Saturation";
            // 
            // lbAdjHueCurrent
            // 
            this.lbAdjHueCurrent.AutoSize = true;
            this.lbAdjHueCurrent.Location = new System.Drawing.Point(341, 57);
            this.lbAdjHueCurrent.Name = "lbAdjHueCurrent";
            this.lbAdjHueCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbAdjHueCurrent.TabIndex = 30;
            this.lbAdjHueCurrent.Text = "Current = 40";
            // 
            // lbAdjHueMax
            // 
            this.lbAdjHueMax.AutoSize = true;
            this.lbAdjHueMax.Location = new System.Drawing.Point(278, 57);
            this.lbAdjHueMax.Name = "lbAdjHueMax";
            this.lbAdjHueMax.Size = new System.Drawing.Size(57, 13);
            this.lbAdjHueMax.TabIndex = 29;
            this.lbAdjHueMax.Text = "Max = 100";
            // 
            // cbAdjHueAuto
            // 
            this.cbAdjHueAuto.AutoSize = true;
            this.cbAdjHueAuto.Location = new System.Drawing.Point(367, 11);
            this.cbAdjHueAuto.Name = "cbAdjHueAuto";
            this.cbAdjHueAuto.Size = new System.Drawing.Size(48, 17);
            this.cbAdjHueAuto.TabIndex = 28;
            this.cbAdjHueAuto.Text = "Auto";
            this.cbAdjHueAuto.UseVisualStyleBackColor = true;
            this.cbAdjHueAuto.CheckedChanged += new System.EventHandler(this.tbAdjHue_Scroll);
            // 
            // lbAdjHueMin
            // 
            this.lbAdjHueMin.AutoSize = true;
            this.lbAdjHueMin.Location = new System.Drawing.Point(230, 57);
            this.lbAdjHueMin.Name = "lbAdjHueMin";
            this.lbAdjHueMin.Size = new System.Drawing.Size(42, 13);
            this.lbAdjHueMin.TabIndex = 27;
            this.lbAdjHueMin.Text = "Min = 1";
            // 
            // tbAdjHue
            // 
            this.tbAdjHue.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjHue.Location = new System.Drawing.Point(224, 28);
            this.tbAdjHue.Maximum = 100;
            this.tbAdjHue.Name = "tbAdjHue";
            this.tbAdjHue.Size = new System.Drawing.Size(191, 45);
            this.tbAdjHue.TabIndex = 26;
            this.tbAdjHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjHue.Value = 50;
            this.tbAdjHue.Scroll += new System.EventHandler(this.tbAdjHue_Scroll);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(221, 12);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(27, 13);
            this.label41.TabIndex = 25;
            this.label41.Text = "Hue";
            // 
            // lbAdjContrastCurrent
            // 
            this.lbAdjContrastCurrent.AutoSize = true;
            this.lbAdjContrastCurrent.Location = new System.Drawing.Point(132, 125);
            this.lbAdjContrastCurrent.Name = "lbAdjContrastCurrent";
            this.lbAdjContrastCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbAdjContrastCurrent.TabIndex = 24;
            this.lbAdjContrastCurrent.Text = "Current = 40";
            // 
            // lbAdjContrastMax
            // 
            this.lbAdjContrastMax.AutoSize = true;
            this.lbAdjContrastMax.Location = new System.Drawing.Point(69, 125);
            this.lbAdjContrastMax.Name = "lbAdjContrastMax";
            this.lbAdjContrastMax.Size = new System.Drawing.Size(57, 13);
            this.lbAdjContrastMax.TabIndex = 23;
            this.lbAdjContrastMax.Text = "Max = 100";
            // 
            // cbAdjContrastAuto
            // 
            this.cbAdjContrastAuto.AutoSize = true;
            this.cbAdjContrastAuto.Location = new System.Drawing.Point(158, 79);
            this.cbAdjContrastAuto.Name = "cbAdjContrastAuto";
            this.cbAdjContrastAuto.Size = new System.Drawing.Size(48, 17);
            this.cbAdjContrastAuto.TabIndex = 22;
            this.cbAdjContrastAuto.Text = "Auto";
            this.cbAdjContrastAuto.UseVisualStyleBackColor = true;
            this.cbAdjContrastAuto.CheckedChanged += new System.EventHandler(this.tbAdjContrast_Scroll);
            // 
            // lbAdjContrastMin
            // 
            this.lbAdjContrastMin.AutoSize = true;
            this.lbAdjContrastMin.Location = new System.Drawing.Point(21, 125);
            this.lbAdjContrastMin.Name = "lbAdjContrastMin";
            this.lbAdjContrastMin.Size = new System.Drawing.Size(42, 13);
            this.lbAdjContrastMin.TabIndex = 21;
            this.lbAdjContrastMin.Text = "Min = 1";
            // 
            // tbAdjContrast
            // 
            this.tbAdjContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjContrast.Location = new System.Drawing.Point(15, 96);
            this.tbAdjContrast.Maximum = 100;
            this.tbAdjContrast.Name = "tbAdjContrast";
            this.tbAdjContrast.Size = new System.Drawing.Size(191, 45);
            this.tbAdjContrast.TabIndex = 20;
            this.tbAdjContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjContrast.Value = 50;
            this.tbAdjContrast.Scroll += new System.EventHandler(this.tbAdjContrast_Scroll);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Contrast";
            // 
            // lbAdjBrightnessCurrent
            // 
            this.lbAdjBrightnessCurrent.AutoSize = true;
            this.lbAdjBrightnessCurrent.Location = new System.Drawing.Point(132, 57);
            this.lbAdjBrightnessCurrent.Name = "lbAdjBrightnessCurrent";
            this.lbAdjBrightnessCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbAdjBrightnessCurrent.TabIndex = 18;
            this.lbAdjBrightnessCurrent.Text = "Current = 40";
            // 
            // lbAdjBrightnessMax
            // 
            this.lbAdjBrightnessMax.AutoSize = true;
            this.lbAdjBrightnessMax.Location = new System.Drawing.Point(69, 57);
            this.lbAdjBrightnessMax.Name = "lbAdjBrightnessMax";
            this.lbAdjBrightnessMax.Size = new System.Drawing.Size(57, 13);
            this.lbAdjBrightnessMax.TabIndex = 17;
            this.lbAdjBrightnessMax.Text = "Max = 100";
            // 
            // cbAdjBrightnessAuto
            // 
            this.cbAdjBrightnessAuto.AutoSize = true;
            this.cbAdjBrightnessAuto.Location = new System.Drawing.Point(158, 11);
            this.cbAdjBrightnessAuto.Name = "cbAdjBrightnessAuto";
            this.cbAdjBrightnessAuto.Size = new System.Drawing.Size(48, 17);
            this.cbAdjBrightnessAuto.TabIndex = 16;
            this.cbAdjBrightnessAuto.Text = "Auto";
            this.cbAdjBrightnessAuto.UseVisualStyleBackColor = true;
            this.cbAdjBrightnessAuto.CheckedChanged += new System.EventHandler(this.tbAdjBrightness_Scroll);
            // 
            // lbAdjBrightnessMin
            // 
            this.lbAdjBrightnessMin.AutoSize = true;
            this.lbAdjBrightnessMin.Location = new System.Drawing.Point(21, 57);
            this.lbAdjBrightnessMin.Name = "lbAdjBrightnessMin";
            this.lbAdjBrightnessMin.Size = new System.Drawing.Size(42, 13);
            this.lbAdjBrightnessMin.TabIndex = 15;
            this.lbAdjBrightnessMin.Text = "Min = 1";
            // 
            // tbAdjBrightness
            // 
            this.tbAdjBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbAdjBrightness.Location = new System.Drawing.Point(15, 28);
            this.tbAdjBrightness.Maximum = 100;
            this.tbAdjBrightness.Name = "tbAdjBrightness";
            this.tbAdjBrightness.Size = new System.Drawing.Size(191, 45);
            this.tbAdjBrightness.TabIndex = 14;
            this.tbAdjBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjBrightness.Value = 50;
            this.tbAdjBrightness.Scroll += new System.EventHandler(this.tbAdjBrightness_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Brightness";
            // 
            // tabPage66
            // 
            this.tabPage66.Controls.Add(this.label1);
            this.tabPage66.Controls.Add(this.btCCFocusApply);
            this.tabPage66.Controls.Add(this.btCCZoomApply);
            this.tabPage66.Controls.Add(this.cbCCFocusRelative);
            this.tabPage66.Controls.Add(this.cbCCFocusManual);
            this.tabPage66.Controls.Add(this.cbCCFocusAuto);
            this.tabPage66.Controls.Add(this.lbCCFocusCurrent);
            this.tabPage66.Controls.Add(this.lbCCFocusMax);
            this.tabPage66.Controls.Add(this.lbCCFocusMin);
            this.tabPage66.Controls.Add(this.tbCCFocus);
            this.tabPage66.Controls.Add(this.label4);
            this.tabPage66.Controls.Add(this.cbCCZoomRelative);
            this.tabPage66.Controls.Add(this.cbCCZoomManual);
            this.tabPage66.Controls.Add(this.cbCCZoomAuto);
            this.tabPage66.Controls.Add(this.lbCCZoomCurrent);
            this.tabPage66.Controls.Add(this.lbCCZoomMax);
            this.tabPage66.Controls.Add(this.lbCCZoomMin);
            this.tabPage66.Controls.Add(this.tbCCZoom);
            this.tabPage66.Controls.Add(this.label20);
            this.tabPage66.Controls.Add(this.btCCTiltApply);
            this.tabPage66.Controls.Add(this.btCCPanApply);
            this.tabPage66.Controls.Add(this.cbCCTiltRelative);
            this.tabPage66.Controls.Add(this.cbCCTiltManual);
            this.tabPage66.Controls.Add(this.cbCCTiltAuto);
            this.tabPage66.Controls.Add(this.lbCCTiltCurrent);
            this.tabPage66.Controls.Add(this.lbCCTiltMax);
            this.tabPage66.Controls.Add(this.lbCCTiltMin);
            this.tabPage66.Controls.Add(this.tbCCTilt);
            this.tabPage66.Controls.Add(this.label97);
            this.tabPage66.Controls.Add(this.cbCCPanRelative);
            this.tabPage66.Controls.Add(this.cbCCPanManual);
            this.tabPage66.Controls.Add(this.cbCCPanAuto);
            this.tabPage66.Controls.Add(this.btCCReadValues);
            this.tabPage66.Controls.Add(this.lbCCPanCurrent);
            this.tabPage66.Controls.Add(this.lbCCPanMax);
            this.tabPage66.Controls.Add(this.lbCCPanMin);
            this.tabPage66.Controls.Add(this.tbCCPan);
            this.tabPage66.Controls.Add(this.label96);
            this.tabPage66.Location = new System.Drawing.Point(4, 22);
            this.tabPage66.Name = "tabPage66";
            this.tabPage66.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage66.Size = new System.Drawing.Size(448, 246);
            this.tabPage66.TabIndex = 9;
            this.tabPage66.Text = "Camera control";
            this.tabPage66.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Many other parameters available using API";
            // 
            // btCCFocusApply
            // 
            this.btCCFocusApply.Location = new System.Drawing.Point(240, 220);
            this.btCCFocusApply.Name = "btCCFocusApply";
            this.btCCFocusApply.Size = new System.Drawing.Size(75, 23);
            this.btCCFocusApply.TabIndex = 57;
            this.btCCFocusApply.Text = "Apply";
            this.btCCFocusApply.UseVisualStyleBackColor = true;
            this.btCCFocusApply.Click += new System.EventHandler(this.btCCFocusApply_Click);
            // 
            // btCCZoomApply
            // 
            this.btCCZoomApply.Location = new System.Drawing.Point(28, 220);
            this.btCCZoomApply.Name = "btCCZoomApply";
            this.btCCZoomApply.Size = new System.Drawing.Size(75, 23);
            this.btCCZoomApply.TabIndex = 56;
            this.btCCZoomApply.Text = "Apply";
            this.btCCZoomApply.UseVisualStyleBackColor = true;
            this.btCCZoomApply.Click += new System.EventHandler(this.btCCZoomApply_Click);
            // 
            // cbCCFocusRelative
            // 
            this.cbCCFocusRelative.AutoSize = true;
            this.cbCCFocusRelative.Location = new System.Drawing.Point(351, 197);
            this.cbCCFocusRelative.Name = "cbCCFocusRelative";
            this.cbCCFocusRelative.Size = new System.Drawing.Size(65, 17);
            this.cbCCFocusRelative.TabIndex = 55;
            this.cbCCFocusRelative.Text = "Relative";
            this.cbCCFocusRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCFocusManual
            // 
            this.cbCCFocusManual.AutoSize = true;
            this.cbCCFocusManual.Location = new System.Drawing.Point(288, 197);
            this.cbCCFocusManual.Name = "cbCCFocusManual";
            this.cbCCFocusManual.Size = new System.Drawing.Size(61, 17);
            this.cbCCFocusManual.TabIndex = 54;
            this.cbCCFocusManual.Text = "Manual";
            this.cbCCFocusManual.UseVisualStyleBackColor = true;
            // 
            // cbCCFocusAuto
            // 
            this.cbCCFocusAuto.AutoSize = true;
            this.cbCCFocusAuto.Location = new System.Drawing.Point(240, 197);
            this.cbCCFocusAuto.Name = "cbCCFocusAuto";
            this.cbCCFocusAuto.Size = new System.Drawing.Size(48, 17);
            this.cbCCFocusAuto.TabIndex = 53;
            this.cbCCFocusAuto.Text = "Auto";
            this.cbCCFocusAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCFocusCurrent
            // 
            this.lbCCFocusCurrent.AutoSize = true;
            this.lbCCFocusCurrent.Location = new System.Drawing.Point(348, 173);
            this.lbCCFocusCurrent.Name = "lbCCFocusCurrent";
            this.lbCCFocusCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbCCFocusCurrent.TabIndex = 52;
            this.lbCCFocusCurrent.Text = "Current = 40";
            // 
            // lbCCFocusMax
            // 
            this.lbCCFocusMax.AutoSize = true;
            this.lbCCFocusMax.Location = new System.Drawing.Point(285, 173);
            this.lbCCFocusMax.Name = "lbCCFocusMax";
            this.lbCCFocusMax.Size = new System.Drawing.Size(57, 13);
            this.lbCCFocusMax.TabIndex = 51;
            this.lbCCFocusMax.Text = "Max = 100";
            // 
            // lbCCFocusMin
            // 
            this.lbCCFocusMin.AutoSize = true;
            this.lbCCFocusMin.Location = new System.Drawing.Point(237, 173);
            this.lbCCFocusMin.Name = "lbCCFocusMin";
            this.lbCCFocusMin.Size = new System.Drawing.Size(42, 13);
            this.lbCCFocusMin.TabIndex = 50;
            this.lbCCFocusMin.Text = "Min = 1";
            // 
            // tbCCFocus
            // 
            this.tbCCFocus.BackColor = System.Drawing.SystemColors.Window;
            this.tbCCFocus.Location = new System.Drawing.Point(263, 146);
            this.tbCCFocus.Maximum = 100;
            this.tbCCFocus.Name = "tbCCFocus";
            this.tbCCFocus.Size = new System.Drawing.Size(159, 45);
            this.tbCCFocus.TabIndex = 49;
            this.tbCCFocus.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCCFocus.Value = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Focus";
            // 
            // cbCCZoomRelative
            // 
            this.cbCCZoomRelative.AutoSize = true;
            this.cbCCZoomRelative.Location = new System.Drawing.Point(139, 197);
            this.cbCCZoomRelative.Name = "cbCCZoomRelative";
            this.cbCCZoomRelative.Size = new System.Drawing.Size(65, 17);
            this.cbCCZoomRelative.TabIndex = 47;
            this.cbCCZoomRelative.Text = "Relative";
            this.cbCCZoomRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCZoomManual
            // 
            this.cbCCZoomManual.AutoSize = true;
            this.cbCCZoomManual.Location = new System.Drawing.Point(76, 197);
            this.cbCCZoomManual.Name = "cbCCZoomManual";
            this.cbCCZoomManual.Size = new System.Drawing.Size(61, 17);
            this.cbCCZoomManual.TabIndex = 46;
            this.cbCCZoomManual.Text = "Manual";
            this.cbCCZoomManual.UseVisualStyleBackColor = true;
            // 
            // cbCCZoomAuto
            // 
            this.cbCCZoomAuto.AutoSize = true;
            this.cbCCZoomAuto.Location = new System.Drawing.Point(28, 197);
            this.cbCCZoomAuto.Name = "cbCCZoomAuto";
            this.cbCCZoomAuto.Size = new System.Drawing.Size(48, 17);
            this.cbCCZoomAuto.TabIndex = 45;
            this.cbCCZoomAuto.Text = "Auto";
            this.cbCCZoomAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCZoomCurrent
            // 
            this.lbCCZoomCurrent.AutoSize = true;
            this.lbCCZoomCurrent.Location = new System.Drawing.Point(136, 173);
            this.lbCCZoomCurrent.Name = "lbCCZoomCurrent";
            this.lbCCZoomCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbCCZoomCurrent.TabIndex = 44;
            this.lbCCZoomCurrent.Text = "Current = 40";
            // 
            // lbCCZoomMax
            // 
            this.lbCCZoomMax.AutoSize = true;
            this.lbCCZoomMax.Location = new System.Drawing.Point(73, 173);
            this.lbCCZoomMax.Name = "lbCCZoomMax";
            this.lbCCZoomMax.Size = new System.Drawing.Size(57, 13);
            this.lbCCZoomMax.TabIndex = 43;
            this.lbCCZoomMax.Text = "Max = 100";
            // 
            // lbCCZoomMin
            // 
            this.lbCCZoomMin.AutoSize = true;
            this.lbCCZoomMin.Location = new System.Drawing.Point(25, 173);
            this.lbCCZoomMin.Name = "lbCCZoomMin";
            this.lbCCZoomMin.Size = new System.Drawing.Size(42, 13);
            this.lbCCZoomMin.TabIndex = 42;
            this.lbCCZoomMin.Text = "Min = 1";
            // 
            // tbCCZoom
            // 
            this.tbCCZoom.BackColor = System.Drawing.SystemColors.Window;
            this.tbCCZoom.Location = new System.Drawing.Point(51, 146);
            this.tbCCZoom.Maximum = 100;
            this.tbCCZoom.Name = "tbCCZoom";
            this.tbCCZoom.Size = new System.Drawing.Size(159, 45);
            this.tbCCZoom.TabIndex = 41;
            this.tbCCZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCCZoom.Value = 50;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "Zoom";
            // 
            // btCCTiltApply
            // 
            this.btCCTiltApply.Location = new System.Drawing.Point(240, 104);
            this.btCCTiltApply.Name = "btCCTiltApply";
            this.btCCTiltApply.Size = new System.Drawing.Size(75, 23);
            this.btCCTiltApply.TabIndex = 39;
            this.btCCTiltApply.Text = "Apply";
            this.btCCTiltApply.UseVisualStyleBackColor = true;
            this.btCCTiltApply.Click += new System.EventHandler(this.btCCTiltApply_Click);
            // 
            // btCCPanApply
            // 
            this.btCCPanApply.Location = new System.Drawing.Point(28, 104);
            this.btCCPanApply.Name = "btCCPanApply";
            this.btCCPanApply.Size = new System.Drawing.Size(75, 23);
            this.btCCPanApply.TabIndex = 38;
            this.btCCPanApply.Text = "Apply";
            this.btCCPanApply.UseVisualStyleBackColor = true;
            this.btCCPanApply.Click += new System.EventHandler(this.btCCPanApply_Click);
            // 
            // cbCCTiltRelative
            // 
            this.cbCCTiltRelative.AutoSize = true;
            this.cbCCTiltRelative.Location = new System.Drawing.Point(351, 81);
            this.cbCCTiltRelative.Name = "cbCCTiltRelative";
            this.cbCCTiltRelative.Size = new System.Drawing.Size(65, 17);
            this.cbCCTiltRelative.TabIndex = 37;
            this.cbCCTiltRelative.Text = "Relative";
            this.cbCCTiltRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCTiltManual
            // 
            this.cbCCTiltManual.AutoSize = true;
            this.cbCCTiltManual.Location = new System.Drawing.Point(288, 81);
            this.cbCCTiltManual.Name = "cbCCTiltManual";
            this.cbCCTiltManual.Size = new System.Drawing.Size(61, 17);
            this.cbCCTiltManual.TabIndex = 36;
            this.cbCCTiltManual.Text = "Manual";
            this.cbCCTiltManual.UseVisualStyleBackColor = true;
            // 
            // cbCCTiltAuto
            // 
            this.cbCCTiltAuto.AutoSize = true;
            this.cbCCTiltAuto.Location = new System.Drawing.Point(240, 81);
            this.cbCCTiltAuto.Name = "cbCCTiltAuto";
            this.cbCCTiltAuto.Size = new System.Drawing.Size(48, 17);
            this.cbCCTiltAuto.TabIndex = 35;
            this.cbCCTiltAuto.Text = "Auto";
            this.cbCCTiltAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCTiltCurrent
            // 
            this.lbCCTiltCurrent.AutoSize = true;
            this.lbCCTiltCurrent.Location = new System.Drawing.Point(348, 57);
            this.lbCCTiltCurrent.Name = "lbCCTiltCurrent";
            this.lbCCTiltCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbCCTiltCurrent.TabIndex = 34;
            this.lbCCTiltCurrent.Text = "Current = 40";
            // 
            // lbCCTiltMax
            // 
            this.lbCCTiltMax.AutoSize = true;
            this.lbCCTiltMax.Location = new System.Drawing.Point(285, 57);
            this.lbCCTiltMax.Name = "lbCCTiltMax";
            this.lbCCTiltMax.Size = new System.Drawing.Size(57, 13);
            this.lbCCTiltMax.TabIndex = 33;
            this.lbCCTiltMax.Text = "Max = 100";
            // 
            // lbCCTiltMin
            // 
            this.lbCCTiltMin.AutoSize = true;
            this.lbCCTiltMin.Location = new System.Drawing.Point(237, 57);
            this.lbCCTiltMin.Name = "lbCCTiltMin";
            this.lbCCTiltMin.Size = new System.Drawing.Size(42, 13);
            this.lbCCTiltMin.TabIndex = 32;
            this.lbCCTiltMin.Text = "Min = 1";
            // 
            // tbCCTilt
            // 
            this.tbCCTilt.BackColor = System.Drawing.SystemColors.Window;
            this.tbCCTilt.Location = new System.Drawing.Point(259, 30);
            this.tbCCTilt.Maximum = 100;
            this.tbCCTilt.Name = "tbCCTilt";
            this.tbCCTilt.Size = new System.Drawing.Size(163, 45);
            this.tbCCTilt.TabIndex = 31;
            this.tbCCTilt.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCCTilt.Value = 50;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(228, 33);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(21, 13);
            this.label97.TabIndex = 30;
            this.label97.Text = "Tilt";
            // 
            // cbCCPanRelative
            // 
            this.cbCCPanRelative.AutoSize = true;
            this.cbCCPanRelative.Location = new System.Drawing.Point(139, 81);
            this.cbCCPanRelative.Name = "cbCCPanRelative";
            this.cbCCPanRelative.Size = new System.Drawing.Size(65, 17);
            this.cbCCPanRelative.TabIndex = 29;
            this.cbCCPanRelative.Text = "Relative";
            this.cbCCPanRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCPanManual
            // 
            this.cbCCPanManual.AutoSize = true;
            this.cbCCPanManual.Location = new System.Drawing.Point(76, 81);
            this.cbCCPanManual.Name = "cbCCPanManual";
            this.cbCCPanManual.Size = new System.Drawing.Size(61, 17);
            this.cbCCPanManual.TabIndex = 28;
            this.cbCCPanManual.Text = "Manual";
            this.cbCCPanManual.UseVisualStyleBackColor = true;
            // 
            // cbCCPanAuto
            // 
            this.cbCCPanAuto.AutoSize = true;
            this.cbCCPanAuto.Location = new System.Drawing.Point(28, 81);
            this.cbCCPanAuto.Name = "cbCCPanAuto";
            this.cbCCPanAuto.Size = new System.Drawing.Size(48, 17);
            this.cbCCPanAuto.TabIndex = 27;
            this.cbCCPanAuto.Text = "Auto";
            this.cbCCPanAuto.UseVisualStyleBackColor = true;
            // 
            // btCCReadValues
            // 
            this.btCCReadValues.AccessibleDescription = "";
            this.btCCReadValues.Location = new System.Drawing.Point(351, 6);
            this.btCCReadValues.Name = "btCCReadValues";
            this.btCCReadValues.Size = new System.Drawing.Size(91, 23);
            this.btCCReadValues.TabIndex = 26;
            this.btCCReadValues.Text = "Read values";
            this.btCCReadValues.UseVisualStyleBackColor = true;
            this.btCCReadValues.Click += new System.EventHandler(this.btCCReadValues_Click);
            // 
            // lbCCPanCurrent
            // 
            this.lbCCPanCurrent.AutoSize = true;
            this.lbCCPanCurrent.Location = new System.Drawing.Point(136, 57);
            this.lbCCPanCurrent.Name = "lbCCPanCurrent";
            this.lbCCPanCurrent.Size = new System.Drawing.Size(65, 13);
            this.lbCCPanCurrent.TabIndex = 23;
            this.lbCCPanCurrent.Text = "Current = 40";
            // 
            // lbCCPanMax
            // 
            this.lbCCPanMax.AutoSize = true;
            this.lbCCPanMax.Location = new System.Drawing.Point(73, 57);
            this.lbCCPanMax.Name = "lbCCPanMax";
            this.lbCCPanMax.Size = new System.Drawing.Size(57, 13);
            this.lbCCPanMax.TabIndex = 22;
            this.lbCCPanMax.Text = "Max = 100";
            // 
            // lbCCPanMin
            // 
            this.lbCCPanMin.AutoSize = true;
            this.lbCCPanMin.Location = new System.Drawing.Point(25, 57);
            this.lbCCPanMin.Name = "lbCCPanMin";
            this.lbCCPanMin.Size = new System.Drawing.Size(42, 13);
            this.lbCCPanMin.TabIndex = 21;
            this.lbCCPanMin.Text = "Min = 1";
            // 
            // tbCCPan
            // 
            this.tbCCPan.BackColor = System.Drawing.SystemColors.Window;
            this.tbCCPan.Location = new System.Drawing.Point(51, 30);
            this.tbCCPan.Maximum = 100;
            this.tbCCPan.Name = "tbCCPan";
            this.tbCCPan.Size = new System.Drawing.Size(159, 45);
            this.tbCCPan.TabIndex = 20;
            this.tbCCPan.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCCPan.Value = 50;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(16, 33);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(26, 13);
            this.label96.TabIndex = 19;
            this.label96.Text = "Pan";
            // 
            // tabPage63
            // 
            this.tabPage63.Controls.Add(this.tabControl19);
            this.tabPage63.Location = new System.Drawing.Point(4, 22);
            this.tabPage63.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage63.Name = "tabPage63";
            this.tabPage63.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage63.Size = new System.Drawing.Size(459, 285);
            this.tabPage63.TabIndex = 9;
            this.tabPage63.Text = "Audio input / output";
            this.tabPage63.UseVisualStyleBackColor = true;
            // 
            // tabControl19
            // 
            this.tabControl19.Controls.Add(this.tabPage96);
            this.tabControl19.Controls.Add(this.tabPage97);
            this.tabControl19.Controls.Add(this.tabPage98);
            this.tabControl19.Controls.Add(this.tabPage112);
            this.tabControl19.Controls.Add(this.tabPage99);
            this.tabControl19.Location = new System.Drawing.Point(4, 6);
            this.tabControl19.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl19.Name = "tabControl19";
            this.tabControl19.SelectedIndex = 0;
            this.tabControl19.Size = new System.Drawing.Size(455, 277);
            this.tabControl19.TabIndex = 0;
            // 
            // tabPage96
            // 
            this.tabPage96.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage96.Controls.Add(this.cbUseAudioInputFromVideoCaptureDevice);
            this.tabPage96.Controls.Add(this.btAudioInputDeviceSettings);
            this.tabPage96.Controls.Add(this.cbAudioInputLine);
            this.tabPage96.Controls.Add(this.cbAudioInputFormat);
            this.tabPage96.Controls.Add(this.cbAudioInputDevice);
            this.tabPage96.Controls.Add(this.label14);
            this.tabPage96.Controls.Add(this.label12);
            this.tabPage96.Controls.Add(this.label10);
            this.tabPage96.Location = new System.Drawing.Point(4, 22);
            this.tabPage96.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage96.Name = "tabPage96";
            this.tabPage96.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage96.Size = new System.Drawing.Size(447, 251);
            this.tabPage96.TabIndex = 0;
            this.tabPage96.Text = "Main audio input";
            this.tabPage96.UseVisualStyleBackColor = true;
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(358, 63);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestAudioInputFormat.TabIndex = 93;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestAudioInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestAudioInputFormat_CheckedChanged);
            // 
            // cbUseAudioInputFromVideoCaptureDevice
            // 
            this.cbUseAudioInputFromVideoCaptureDevice.AutoSize = true;
            this.cbUseAudioInputFromVideoCaptureDevice.Location = new System.Drawing.Point(246, 15);
            this.cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice";
            this.cbUseAudioInputFromVideoCaptureDevice.Size = new System.Drawing.Size(187, 17);
            this.cbUseAudioInputFromVideoCaptureDevice.TabIndex = 92;
            this.cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source";
            this.cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true;
            this.cbUseAudioInputFromVideoCaptureDevice.CheckedChanged += new System.EventHandler(this.cbUseAudioInputFromVideoCaptureDevice_CheckedChanged);
            // 
            // btAudioInputDeviceSettings
            // 
            this.btAudioInputDeviceSettings.Location = new System.Drawing.Point(373, 32);
            this.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            this.btAudioInputDeviceSettings.Size = new System.Drawing.Size(54, 23);
            this.btAudioInputDeviceSettings.TabIndex = 91;
            this.btAudioInputDeviceSettings.Text = "Settings";
            this.btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            this.btAudioInputDeviceSettings.Click += new System.EventHandler(this.btAudioInputDeviceSettings_Click);
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(21, 81);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(190, 21);
            this.cbAudioInputLine.TabIndex = 88;
            this.cbAudioInputLine.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputLine_SelectedIndexChanged);
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(237, 81);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(190, 21);
            this.cbAudioInputFormat.TabIndex = 87;
            this.cbAudioInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputFormat_SelectedIndexChanged);
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(21, 33);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(346, 21);
            this.cbAudioInputDevice.TabIndex = 86;
            this.cbAudioInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 85;
            this.label14.Text = "Input line";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 84;
            this.label12.Text = "Input device";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 83;
            this.label10.Text = "Input format";
            // 
            // tabPage97
            // 
            this.tabPage97.Controls.Add(this.label55);
            this.tabPage97.Controls.Add(this.tbAudioBalance);
            this.tabPage97.Controls.Add(this.label54);
            this.tabPage97.Controls.Add(this.tbAudioVolume);
            this.tabPage97.Controls.Add(this.cbPlayAudio);
            this.tabPage97.Controls.Add(this.cbAudioOutputDevice);
            this.tabPage97.Controls.Add(this.label15);
            this.tabPage97.Location = new System.Drawing.Point(4, 22);
            this.tabPage97.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage97.Name = "tabPage97";
            this.tabPage97.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage97.Size = new System.Drawing.Size(447, 251);
            this.tabPage97.TabIndex = 1;
            this.tabPage97.Text = "Audio output";
            this.tabPage97.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(338, 20);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 13);
            this.label55.TabIndex = 105;
            this.label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            this.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioBalance.Location = new System.Drawing.Point(340, 35);
            this.tbAudioBalance.Maximum = 100;
            this.tbAudioBalance.Minimum = -100;
            this.tbAudioBalance.Name = "tbAudioBalance";
            this.tbAudioBalance.Size = new System.Drawing.Size(82, 45);
            this.tbAudioBalance.TabIndex = 104;
            this.tbAudioBalance.TickFrequency = 5;
            this.tbAudioBalance.Scroll += new System.EventHandler(this.tbAudioBalance_Scroll);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(230, 20);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 103;
            this.label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            this.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioVolume.Location = new System.Drawing.Point(231, 35);
            this.tbAudioVolume.Maximum = 100;
            this.tbAudioVolume.Name = "tbAudioVolume";
            this.tbAudioVolume.Size = new System.Drawing.Size(82, 45);
            this.tbAudioVolume.TabIndex = 102;
            this.tbAudioVolume.TickFrequency = 10;
            this.tbAudioVolume.Value = 80;
            this.tbAudioVolume.Scroll += new System.EventHandler(this.tbAudioVolume_Scroll);
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = true;
            this.cbPlayAudio.Checked = true;
            this.cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlayAudio.Location = new System.Drawing.Point(131, 20);
            this.cbPlayAudio.Name = "cbPlayAudio";
            this.cbPlayAudio.Size = new System.Drawing.Size(75, 17);
            this.cbPlayAudio.TabIndex = 101;
            this.cbPlayAudio.Text = "Play audio";
            this.cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(16, 37);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(190, 21);
            this.cbAudioOutputDevice.TabIndex = 100;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 99;
            this.label15.Text = "Output device";
            // 
            // tabPage98
            // 
            this.tabPage98.Controls.Add(this.cbVUMeter);
            this.tabPage98.Controls.Add(this.peakMeterCtrl1);
            this.tabPage98.Location = new System.Drawing.Point(4, 22);
            this.tabPage98.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage98.Name = "tabPage98";
            this.tabPage98.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage98.Size = new System.Drawing.Size(447, 251);
            this.tabPage98.TabIndex = 2;
            this.tabPage98.Text = "VU meter";
            this.tabPage98.UseVisualStyleBackColor = true;
            // 
            // cbVUMeter
            // 
            this.cbVUMeter.AutoSize = true;
            this.cbVUMeter.Location = new System.Drawing.Point(13, 17);
            this.cbVUMeter.Name = "cbVUMeter";
            this.cbVUMeter.Size = new System.Drawing.Size(107, 17);
            this.cbVUMeter.TabIndex = 101;
            this.cbVUMeter.Text = "Enable VU Meter";
            this.cbVUMeter.UseVisualStyleBackColor = true;
            // 
            // peakMeterCtrl1
            // 
            this.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            this.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow;
            this.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green;
            this.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro;
            this.peakMeterCtrl1.Location = new System.Drawing.Point(128, 11);
            this.peakMeterCtrl1.Name = "peakMeterCtrl1";
            this.peakMeterCtrl1.Size = new System.Drawing.Size(105, 61);
            this.peakMeterCtrl1.TabIndex = 102;
            this.peakMeterCtrl1.Text = "peakMeterCtrl1";
            // 
            // tabPage112
            // 
            this.tabPage112.Controls.Add(this.tbVUMeterBoost);
            this.tabPage112.Controls.Add(this.label382);
            this.tabPage112.Controls.Add(this.label381);
            this.tabPage112.Controls.Add(this.tbVUMeterAmplification);
            this.tabPage112.Controls.Add(this.cbVUMeterPro);
            this.tabPage112.Controls.Add(this.waveformPainter2);
            this.tabPage112.Controls.Add(this.waveformPainter1);
            this.tabPage112.Controls.Add(this.volumeMeter2);
            this.tabPage112.Controls.Add(this.volumeMeter1);
            this.tabPage112.Location = new System.Drawing.Point(4, 22);
            this.tabPage112.Name = "tabPage112";
            this.tabPage112.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage112.Size = new System.Drawing.Size(447, 251);
            this.tabPage112.TabIndex = 4;
            this.tabPage112.Text = "VU meter Pro";
            this.tabPage112.UseVisualStyleBackColor = true;
            // 
            // tbVUMeterBoost
            // 
            this.tbVUMeterBoost.Location = new System.Drawing.Point(172, 188);
            this.tbVUMeterBoost.Maximum = 30;
            this.tbVUMeterBoost.Minimum = 1;
            this.tbVUMeterBoost.Name = "tbVUMeterBoost";
            this.tbVUMeterBoost.Size = new System.Drawing.Size(104, 45);
            this.tbVUMeterBoost.TabIndex = 115;
            this.tbVUMeterBoost.Value = 10;
            this.tbVUMeterBoost.Scroll += new System.EventHandler(this.tbVUMeterBoost_Scroll);
            // 
            // label382
            // 
            this.label382.AutoSize = true;
            this.label382.Location = new System.Drawing.Point(169, 172);
            this.label382.Name = "label382";
            this.label382.Size = new System.Drawing.Size(68, 13);
            this.label382.TabIndex = 114;
            this.label382.Text = "Meters boost";
            // 
            // label381
            // 
            this.label381.AutoSize = true;
            this.label381.Location = new System.Drawing.Point(21, 172);
            this.label381.Name = "label381";
            this.label381.Size = new System.Drawing.Size(120, 13);
            this.label381.TabIndex = 110;
            this.label381.Text = "Volume amplification (%)";
            // 
            // tbVUMeterAmplification
            // 
            this.tbVUMeterAmplification.Location = new System.Drawing.Point(24, 188);
            this.tbVUMeterAmplification.Maximum = 100;
            this.tbVUMeterAmplification.Name = "tbVUMeterAmplification";
            this.tbVUMeterAmplification.Size = new System.Drawing.Size(105, 45);
            this.tbVUMeterAmplification.TabIndex = 109;
            this.tbVUMeterAmplification.Value = 100;
            this.tbVUMeterAmplification.Scroll += new System.EventHandler(this.tbVUMeterAmplification_Scroll);
            // 
            // cbVUMeterPro
            // 
            this.cbVUMeterPro.AutoSize = true;
            this.cbVUMeterPro.Location = new System.Drawing.Point(13, 17);
            this.cbVUMeterPro.Name = "cbVUMeterPro";
            this.cbVUMeterPro.Size = new System.Drawing.Size(125, 17);
            this.cbVUMeterPro.TabIndex = 108;
            this.cbVUMeterPro.Text = "Enable VU meter Pro";
            this.cbVUMeterPro.UseVisualStyleBackColor = true;
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Boost = 1F;
            this.waveformPainter2.Location = new System.Drawing.Point(102, 106);
            this.waveformPainter2.Name = "waveformPainter2";
            this.waveformPainter2.Size = new System.Drawing.Size(270, 60);
            this.waveformPainter2.TabIndex = 113;
            this.waveformPainter2.Text = "waveformPainter2";
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Boost = 1F;
            this.waveformPainter1.Location = new System.Drawing.Point(102, 40);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(270, 60);
            this.waveformPainter1.TabIndex = 112;
            this.waveformPainter1.Text = "waveformPainter1";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.BackColor = System.Drawing.Color.LightGray;
            this.volumeMeter2.Boost = 1F;
            this.volumeMeter2.Location = new System.Drawing.Point(52, 40);
            this.volumeMeter2.MaxDb = 18F;
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Size = new System.Drawing.Size(22, 126);
            this.volumeMeter2.TabIndex = 111;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.BackColor = System.Drawing.Color.LightGray;
            this.volumeMeter1.Boost = 1F;
            this.volumeMeter1.Location = new System.Drawing.Point(24, 40);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Size = new System.Drawing.Size(22, 126);
            this.volumeMeter1.TabIndex = 107;
            // 
            // tabPage99
            // 
            this.tabPage99.Controls.Add(this.rbAddAudioStreamsIndependent);
            this.tabPage99.Controls.Add(this.rbAddAudioStreamsMix);
            this.tabPage99.Controls.Add(this.label319);
            this.tabPage99.Controls.Add(this.label318);
            this.tabPage99.Controls.Add(this.btAddAdditionalAudioSource);
            this.tabPage99.Controls.Add(this.cbAdditionalAudioSource);
            this.tabPage99.Controls.Add(this.label180);
            this.tabPage99.Location = new System.Drawing.Point(4, 22);
            this.tabPage99.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage99.Name = "tabPage99";
            this.tabPage99.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage99.Size = new System.Drawing.Size(447, 251);
            this.tabPage99.TabIndex = 3;
            this.tabPage99.Text = "Additional audio inputs";
            this.tabPage99.UseVisualStyleBackColor = true;
            // 
            // rbAddAudioStreamsIndependent
            // 
            this.rbAddAudioStreamsIndependent.AutoSize = true;
            this.rbAddAudioStreamsIndependent.Location = new System.Drawing.Point(15, 85);
            this.rbAddAudioStreamsIndependent.Name = "rbAddAudioStreamsIndependent";
            this.rbAddAudioStreamsIndependent.Size = new System.Drawing.Size(124, 17);
            this.rbAddAudioStreamsIndependent.TabIndex = 93;
            this.rbAddAudioStreamsIndependent.Text = "Independent streams";
            this.rbAddAudioStreamsIndependent.UseVisualStyleBackColor = true;
            // 
            // rbAddAudioStreamsMix
            // 
            this.rbAddAudioStreamsMix.AutoSize = true;
            this.rbAddAudioStreamsMix.Checked = true;
            this.rbAddAudioStreamsMix.Location = new System.Drawing.Point(15, 62);
            this.rbAddAudioStreamsMix.Name = "rbAddAudioStreamsMix";
            this.rbAddAudioStreamsMix.Size = new System.Drawing.Size(297, 17);
            this.rbAddAudioStreamsMix.TabIndex = 92;
            this.rbAddAudioStreamsMix.TabStop = true;
            this.rbAddAudioStreamsMix.Text = "Mix into one stream (one additional stream only supported)";
            this.rbAddAudioStreamsMix.UseVisualStyleBackColor = true;
            // 
            // label319
            // 
            this.label319.AutoSize = true;
            this.label319.Location = new System.Drawing.Point(42, 134);
            this.label319.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label319.Name = "label319";
            this.label319.Size = new System.Drawing.Size(291, 13);
            this.label319.TabIndex = 91;
            this.label319.Text = "Please contact support if additional formats support required.";
            // 
            // label318
            // 
            this.label318.AutoSize = true;
            this.label318.Location = new System.Drawing.Point(42, 116);
            this.label318.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label318.Name = "label318";
            this.label318.Size = new System.Drawing.Size(270, 13);
            this.label318.TabIndex = 90;
            this.label318.Text = "Currently AVI and WMV with a special profile supported.";
            // 
            // btAddAdditionalAudioSource
            // 
            this.btAddAdditionalAudioSource.Location = new System.Drawing.Point(366, 33);
            this.btAddAdditionalAudioSource.Margin = new System.Windows.Forms.Padding(2);
            this.btAddAdditionalAudioSource.Name = "btAddAdditionalAudioSource";
            this.btAddAdditionalAudioSource.Size = new System.Drawing.Size(56, 23);
            this.btAddAdditionalAudioSource.TabIndex = 89;
            this.btAddAdditionalAudioSource.Text = "Add";
            this.btAddAdditionalAudioSource.UseVisualStyleBackColor = true;
            this.btAddAdditionalAudioSource.Click += new System.EventHandler(this.btAddAdditionalAudioSource_Click);
            // 
            // cbAdditionalAudioSource
            // 
            this.cbAdditionalAudioSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdditionalAudioSource.FormattingEnabled = true;
            this.cbAdditionalAudioSource.Location = new System.Drawing.Point(15, 33);
            this.cbAdditionalAudioSource.Name = "cbAdditionalAudioSource";
            this.cbAdditionalAudioSource.Size = new System.Drawing.Size(346, 21);
            this.cbAdditionalAudioSource.TabIndex = 88;
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(12, 15);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(66, 13);
            this.label180.TabIndex = 87;
            this.label180.Text = "Input device";
            // 
            // tabPage47
            // 
            this.tabPage47.Controls.Add(this.label3);
            this.tabPage47.Controls.Add(this.textBox1);
            this.tabPage47.Controls.Add(this.lbScreenSourceWindowText);
            this.tabPage47.Controls.Add(this.btScreenSourceWindowSelect);
            this.tabPage47.Controls.Add(this.cbScreenCapture_DesktopDuplication);
            this.tabPage47.Controls.Add(this.rbScreenCaptureColorSource);
            this.tabPage47.Controls.Add(this.rbScreenCaptureWindow);
            this.tabPage47.Controls.Add(this.cbScreenCaptureDisplayIndex);
            this.tabPage47.Controls.Add(this.label93);
            this.tabPage47.Controls.Add(this.btScreenCaptureUpdate);
            this.tabPage47.Controls.Add(this.cbScreenCapture_GrabMouseCursor);
            this.tabPage47.Controls.Add(this.label79);
            this.tabPage47.Controls.Add(this.edScreenFrameRate);
            this.tabPage47.Controls.Add(this.label43);
            this.tabPage47.Controls.Add(this.edScreenBottom);
            this.tabPage47.Controls.Add(this.label42);
            this.tabPage47.Controls.Add(this.edScreenRight);
            this.tabPage47.Controls.Add(this.label40);
            this.tabPage47.Controls.Add(this.edScreenTop);
            this.tabPage47.Controls.Add(this.label26);
            this.tabPage47.Controls.Add(this.edScreenLeft);
            this.tabPage47.Controls.Add(this.label24);
            this.tabPage47.Controls.Add(this.rbScreenCustomArea);
            this.tabPage47.Controls.Add(this.rbScreenFullScreen);
            this.tabPage47.Location = new System.Drawing.Point(4, 22);
            this.tabPage47.Name = "tabPage47";
            this.tabPage47.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage47.Size = new System.Drawing.Size(459, 285);
            this.tabPage47.TabIndex = 1;
            this.tabPage47.Text = "Screen source";
            this.tabPage47.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "(You can capture background window)";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(271, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(167, 59);
            this.textBox1.TabIndex = 57;
            this.textBox1.Text = "You can update left/top position and mouse cursor capturing on-the-fly";
            // 
            // lbScreenSourceWindowText
            // 
            this.lbScreenSourceWindowText.AutoSize = true;
            this.lbScreenSourceWindowText.Location = new System.Drawing.Point(286, 188);
            this.lbScreenSourceWindowText.Name = "lbScreenSourceWindowText";
            this.lbScreenSourceWindowText.Size = new System.Drawing.Size(107, 13);
            this.lbScreenSourceWindowText.TabIndex = 56;
            this.lbScreenSourceWindowText.Text = "(no window selected)";
            // 
            // btScreenSourceWindowSelect
            // 
            this.btScreenSourceWindowSelect.Location = new System.Drawing.Point(389, 155);
            this.btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect";
            this.btScreenSourceWindowSelect.Size = new System.Drawing.Size(49, 23);
            this.btScreenSourceWindowSelect.TabIndex = 55;
            this.btScreenSourceWindowSelect.Text = "Select";
            this.btScreenSourceWindowSelect.UseVisualStyleBackColor = true;
            this.btScreenSourceWindowSelect.Click += new System.EventHandler(this.btScreenSourceWindowSelect_Click);
            // 
            // cbScreenCapture_DesktopDuplication
            // 
            this.cbScreenCapture_DesktopDuplication.AutoSize = true;
            this.cbScreenCapture_DesktopDuplication.Location = new System.Drawing.Point(19, 241);
            this.cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication";
            this.cbScreenCapture_DesktopDuplication.Size = new System.Drawing.Size(182, 17);
            this.cbScreenCapture_DesktopDuplication.TabIndex = 54;
            this.cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage";
            this.cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true;
            // 
            // rbScreenCaptureColorSource
            // 
            this.rbScreenCaptureColorSource.AutoSize = true;
            this.rbScreenCaptureColorSource.Location = new System.Drawing.Point(271, 247);
            this.rbScreenCaptureColorSource.Name = "rbScreenCaptureColorSource";
            this.rbScreenCaptureColorSource.Size = new System.Drawing.Size(78, 17);
            this.rbScreenCaptureColorSource.TabIndex = 53;
            this.rbScreenCaptureColorSource.TabStop = true;
            this.rbScreenCaptureColorSource.Text = "Black color";
            this.rbScreenCaptureColorSource.UseVisualStyleBackColor = true;
            // 
            // rbScreenCaptureWindow
            // 
            this.rbScreenCaptureWindow.AutoSize = true;
            this.rbScreenCaptureWindow.Location = new System.Drawing.Point(271, 158);
            this.rbScreenCaptureWindow.Name = "rbScreenCaptureWindow";
            this.rbScreenCaptureWindow.Size = new System.Drawing.Size(101, 17);
            this.rbScreenCaptureWindow.TabIndex = 50;
            this.rbScreenCaptureWindow.TabStop = true;
            this.rbScreenCaptureWindow.Text = "Capture window";
            this.rbScreenCaptureWindow.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptureDisplayIndex
            // 
            this.cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScreenCaptureDisplayIndex.FormattingEnabled = true;
            this.cbScreenCaptureDisplayIndex.Location = new System.Drawing.Point(88, 185);
            this.cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex";
            this.cbScreenCaptureDisplayIndex.Size = new System.Drawing.Size(44, 21);
            this.cbScreenCaptureDisplayIndex.TabIndex = 49;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label93.Location = new System.Drawing.Point(16, 188);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(65, 13);
            this.label93.TabIndex = 48;
            this.label93.Text = "Display ID";
            // 
            // btScreenCaptureUpdate
            // 
            this.btScreenCaptureUpdate.Location = new System.Drawing.Point(318, 94);
            this.btScreenCaptureUpdate.Name = "btScreenCaptureUpdate";
            this.btScreenCaptureUpdate.Size = new System.Drawing.Size(75, 23);
            this.btScreenCaptureUpdate.TabIndex = 47;
            this.btScreenCaptureUpdate.Text = "Update";
            this.btScreenCaptureUpdate.UseVisualStyleBackColor = true;
            this.btScreenCaptureUpdate.Click += new System.EventHandler(this.btScreenCaptureUpdate_Click);
            // 
            // cbScreenCapture_GrabMouseCursor
            // 
            this.cbScreenCapture_GrabMouseCursor.AutoSize = true;
            this.cbScreenCapture_GrabMouseCursor.Location = new System.Drawing.Point(19, 218);
            this.cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor";
            this.cbScreenCapture_GrabMouseCursor.Size = new System.Drawing.Size(129, 17);
            this.cbScreenCapture_GrabMouseCursor.TabIndex = 43;
            this.cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor";
            this.cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(137, 160);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(21, 13);
            this.label79.TabIndex = 42;
            this.label79.Text = "fps";
            // 
            // edScreenFrameRate
            // 
            this.edScreenFrameRate.Location = new System.Drawing.Point(88, 157);
            this.edScreenFrameRate.Name = "edScreenFrameRate";
            this.edScreenFrameRate.Size = new System.Drawing.Size(44, 20);
            this.edScreenFrameRate.TabIndex = 41;
            this.edScreenFrameRate.Text = "5";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(16, 160);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 40;
            this.label43.Text = "Frame rate";
            // 
            // edScreenBottom
            // 
            this.edScreenBottom.Location = new System.Drawing.Point(204, 119);
            this.edScreenBottom.Name = "edScreenBottom";
            this.edScreenBottom.Size = new System.Drawing.Size(44, 20);
            this.edScreenBottom.TabIndex = 39;
            this.edScreenBottom.Text = "480";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(161, 122);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 13);
            this.label42.TabIndex = 38;
            this.label42.Text = "Bottom";
            // 
            // edScreenRight
            // 
            this.edScreenRight.Location = new System.Drawing.Point(88, 119);
            this.edScreenRight.Name = "edScreenRight";
            this.edScreenRight.Size = new System.Drawing.Size(44, 20);
            this.edScreenRight.TabIndex = 37;
            this.edScreenRight.Text = "640";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(47, 122);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(32, 13);
            this.label40.TabIndex = 36;
            this.label40.Text = "Right";
            // 
            // edScreenTop
            // 
            this.edScreenTop.Location = new System.Drawing.Point(204, 79);
            this.edScreenTop.Name = "edScreenTop";
            this.edScreenTop.Size = new System.Drawing.Size(44, 20);
            this.edScreenTop.TabIndex = 35;
            this.edScreenTop.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(161, 82);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 34;
            this.label26.Text = "Top";
            // 
            // edScreenLeft
            // 
            this.edScreenLeft.Location = new System.Drawing.Point(88, 79);
            this.edScreenLeft.Name = "edScreenLeft";
            this.edScreenLeft.Size = new System.Drawing.Size(44, 20);
            this.edScreenLeft.TabIndex = 33;
            this.edScreenLeft.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(47, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "Left";
            // 
            // rbScreenCustomArea
            // 
            this.rbScreenCustomArea.AutoSize = true;
            this.rbScreenCustomArea.Location = new System.Drawing.Point(19, 41);
            this.rbScreenCustomArea.Name = "rbScreenCustomArea";
            this.rbScreenCustomArea.Size = new System.Drawing.Size(84, 17);
            this.rbScreenCustomArea.TabIndex = 31;
            this.rbScreenCustomArea.Text = "Custom area";
            this.rbScreenCustomArea.UseVisualStyleBackColor = true;
            // 
            // rbScreenFullScreen
            // 
            this.rbScreenFullScreen.AutoSize = true;
            this.rbScreenFullScreen.Checked = true;
            this.rbScreenFullScreen.Location = new System.Drawing.Point(19, 17);
            this.rbScreenFullScreen.Name = "rbScreenFullScreen";
            this.rbScreenFullScreen.Size = new System.Drawing.Size(76, 17);
            this.rbScreenFullScreen.TabIndex = 30;
            this.rbScreenFullScreen.TabStop = true;
            this.rbScreenFullScreen.Text = "Full screen";
            this.rbScreenFullScreen.UseVisualStyleBackColor = true;
            // 
            // tabPage48
            // 
            this.tabPage48.Controls.Add(this.tabControl15);
            this.tabPage48.Location = new System.Drawing.Point(4, 22);
            this.tabPage48.Name = "tabPage48";
            this.tabPage48.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage48.Size = new System.Drawing.Size(459, 285);
            this.tabPage48.TabIndex = 2;
            this.tabPage48.Text = "IP camera / Network stream";
            this.tabPage48.UseVisualStyleBackColor = true;
            // 
            // tabControl15
            // 
            this.tabControl15.Controls.Add(this.tabPage144);
            this.tabControl15.Controls.Add(this.tabPage146);
            this.tabControl15.Controls.Add(this.tabPage145);
            this.tabControl15.Location = new System.Drawing.Point(6, 6);
            this.tabControl15.Name = "tabControl15";
            this.tabControl15.SelectedIndex = 0;
            this.tabControl15.Size = new System.Drawing.Size(447, 273);
            this.tabControl15.TabIndex = 62;
            // 
            // tabPage144
            // 
            this.tabPage144.Controls.Add(this.btListONVIFSources);
            this.tabPage144.Controls.Add(this.cbIPURL);
            this.tabPage144.Controls.Add(this.btListNDISources);
            this.tabPage144.Controls.Add(this.lbNDI);
            this.tabPage144.Controls.Add(this.label25);
            this.tabPage144.Controls.Add(this.linkLabel3);
            this.tabPage144.Controls.Add(this.label22);
            this.tabPage144.Controls.Add(this.linkLabel7);
            this.tabPage144.Controls.Add(this.label165);
            this.tabPage144.Controls.Add(this.cbIPCameraONVIF);
            this.tabPage144.Controls.Add(this.btShowIPCamDatabase);
            this.tabPage144.Controls.Add(this.cbIPDisconnect);
            this.tabPage144.Controls.Add(this.edIPForcedFramerateID);
            this.tabPage144.Controls.Add(this.label344);
            this.tabPage144.Controls.Add(this.edIPForcedFramerate);
            this.tabPage144.Controls.Add(this.label295);
            this.tabPage144.Controls.Add(this.cbIPCameraType);
            this.tabPage144.Controls.Add(this.edIPPassword);
            this.tabPage144.Controls.Add(this.label167);
            this.tabPage144.Controls.Add(this.edIPLogin);
            this.tabPage144.Controls.Add(this.label166);
            this.tabPage144.Controls.Add(this.cbIPAudioCapture);
            this.tabPage144.Controls.Add(this.label168);
            this.tabPage144.Location = new System.Drawing.Point(4, 22);
            this.tabPage144.Name = "tabPage144";
            this.tabPage144.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage144.Size = new System.Drawing.Size(439, 247);
            this.tabPage144.TabIndex = 0;
            this.tabPage144.Text = "Main";
            this.tabPage144.UseVisualStyleBackColor = true;
            // 
            // btListONVIFSources
            // 
            this.btListONVIFSources.Location = new System.Drawing.Point(144, 218);
            this.btListONVIFSources.Name = "btListONVIFSources";
            this.btListONVIFSources.Size = new System.Drawing.Size(123, 23);
            this.btListONVIFSources.TabIndex = 90;
            this.btListONVIFSources.Text = "List ONVIF sources";
            this.btListONVIFSources.UseVisualStyleBackColor = true;
            this.btListONVIFSources.Click += new System.EventHandler(this.btListONVIFSources_Click);
            // 
            // cbIPURL
            // 
            this.cbIPURL.FormattingEnabled = true;
            this.cbIPURL.Location = new System.Drawing.Point(55, 14);
            this.cbIPURL.Name = "cbIPURL";
            this.cbIPURL.Size = new System.Drawing.Size(373, 21);
            this.cbIPURL.TabIndex = 89;
            this.cbIPURL.Text = "rtsp://192.168.1.101:554/stream1";
            // 
            // btListNDISources
            // 
            this.btListNDISources.Location = new System.Drawing.Point(13, 218);
            this.btListNDISources.Name = "btListNDISources";
            this.btListNDISources.Size = new System.Drawing.Size(123, 23);
            this.btListNDISources.TabIndex = 88;
            this.btListNDISources.Text = "List NDI sources";
            this.btListNDISources.UseVisualStyleBackColor = true;
            this.btListNDISources.Click += new System.EventHandler(this.btListNDISources_Click);
            // 
            // lbNDI
            // 
            this.lbNDI.AutoSize = true;
            this.lbNDI.Location = new System.Drawing.Point(259, 194);
            this.lbNDI.Name = "lbNDI";
            this.lbNDI.Size = new System.Drawing.Size(86, 13);
            this.lbNDI.TabIndex = 87;
            this.lbNDI.TabStop = true;
            this.lbNDI.Text = "vendor\'s website";
            this.lbNDI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbNDI_LinkClicked);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 194);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(257, 13);
            this.label25.TabIndex = 86;
            this.label25.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(373, 166);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(24, 13);
            this.linkLabel3.TabIndex = 85;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "x64";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 166);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(327, 13);
            this.label22.TabIndex = 84;
            this.label22.Text = "Please install VLC redist EXE or NuGet package to use VLC engine ";
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(343, 166);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(24, 13);
            this.linkLabel7.TabIndex = 83;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "x86";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(10, 17);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(29, 13);
            this.label165.TabIndex = 79;
            this.label165.Text = "URL";
            // 
            // cbIPCameraONVIF
            // 
            this.cbIPCameraONVIF.AutoSize = true;
            this.cbIPCameraONVIF.Location = new System.Drawing.Point(292, 52);
            this.cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            this.cbIPCameraONVIF.Size = new System.Drawing.Size(96, 17);
            this.cbIPCameraONVIF.TabIndex = 78;
            this.cbIPCameraONVIF.Text = "ONVIF camera";
            this.cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // btShowIPCamDatabase
            // 
            this.btShowIPCamDatabase.Location = new System.Drawing.Point(293, 218);
            this.btShowIPCamDatabase.Name = "btShowIPCamDatabase";
            this.btShowIPCamDatabase.Size = new System.Drawing.Size(135, 23);
            this.btShowIPCamDatabase.TabIndex = 77;
            this.btShowIPCamDatabase.Text = "Show IP cam database";
            this.btShowIPCamDatabase.UseVisualStyleBackColor = true;
            this.btShowIPCamDatabase.Click += new System.EventHandler(this.btShowIPCamDatabase_Click);
            // 
            // cbIPDisconnect
            // 
            this.cbIPDisconnect.AutoSize = true;
            this.cbIPDisconnect.Location = new System.Drawing.Point(292, 98);
            this.cbIPDisconnect.Name = "cbIPDisconnect";
            this.cbIPDisconnect.Size = new System.Drawing.Size(136, 17);
            this.cbIPDisconnect.TabIndex = 75;
            this.cbIPDisconnect.Text = "Notify if connection lost";
            this.cbIPDisconnect.UseVisualStyleBackColor = true;
            // 
            // edIPForcedFramerateID
            // 
            this.edIPForcedFramerateID.Location = new System.Drawing.Point(265, 134);
            this.edIPForcedFramerateID.Margin = new System.Windows.Forms.Padding(2);
            this.edIPForcedFramerateID.Name = "edIPForcedFramerateID";
            this.edIPForcedFramerateID.Size = new System.Drawing.Size(32, 20);
            this.edIPForcedFramerateID.TabIndex = 71;
            this.edIPForcedFramerateID.Text = "0";
            // 
            // label344
            // 
            this.label344.AutoSize = true;
            this.label344.Location = new System.Drawing.Point(163, 136);
            this.label344.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label344.Name = "label344";
            this.label344.Size = new System.Drawing.Size(98, 13);
            this.label344.TabIndex = 70;
            this.label344.Text = "Force frame rate ID";
            // 
            // edIPForcedFramerate
            // 
            this.edIPForcedFramerate.Location = new System.Drawing.Point(112, 134);
            this.edIPForcedFramerate.Margin = new System.Windows.Forms.Padding(2);
            this.edIPForcedFramerate.Name = "edIPForcedFramerate";
            this.edIPForcedFramerate.Size = new System.Drawing.Size(32, 20);
            this.edIPForcedFramerate.TabIndex = 69;
            this.edIPForcedFramerate.Text = "0";
            // 
            // label295
            // 
            this.label295.AutoSize = true;
            this.label295.Location = new System.Drawing.Point(10, 136);
            this.label295.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label295.Name = "label295";
            this.label295.Size = new System.Drawing.Size(84, 13);
            this.label295.TabIndex = 68;
            this.label295.Text = "Force frame rate";
            // 
            // cbIPCameraType
            // 
            this.cbIPCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPCameraType.FormattingEnabled = true;
            this.cbIPCameraType.Items.AddRange(new object[] {
            "Auto (VLC engine)",
            "Auto (FFMPEG engine)",
            "Auto (LAV engine)",
            "RTSP (Live555 engine)",
            "MMS - WMV",
            "HTTP MJPEG Low Latency",
            "RTSP Low Latency TCP",
            "RTSP Low Latency UDP",
            "NDI",
            "NDI (Legacy)"});
            this.cbIPCameraType.Location = new System.Drawing.Point(55, 50);
            this.cbIPCameraType.Name = "cbIPCameraType";
            this.cbIPCameraType.Size = new System.Drawing.Size(227, 21);
            this.cbIPCameraType.TabIndex = 67;
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(166, 98);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(100, 20);
            this.edIPPassword.TabIndex = 66;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(163, 81);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(53, 13);
            this.label167.TabIndex = 65;
            this.label167.Text = "Password";
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(13, 98);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(100, 20);
            this.edIPLogin.TabIndex = 64;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(9, 81);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(33, 13);
            this.label166.TabIndex = 63;
            this.label166.Text = "Login";
            // 
            // cbIPAudioCapture
            // 
            this.cbIPAudioCapture.AutoSize = true;
            this.cbIPAudioCapture.Checked = true;
            this.cbIPAudioCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIPAudioCapture.Location = new System.Drawing.Point(292, 75);
            this.cbIPAudioCapture.Name = "cbIPAudioCapture";
            this.cbIPAudioCapture.Size = new System.Drawing.Size(92, 17);
            this.cbIPAudioCapture.TabIndex = 62;
            this.cbIPAudioCapture.Text = "Capture audio";
            this.cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(9, 54);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(40, 13);
            this.label168.TabIndex = 61;
            this.label168.Text = "Engine";
            // 
            // tabPage146
            // 
            this.tabPage146.Controls.Add(this.btVLCAddParameter);
            this.tabPage146.Controls.Add(this.btVLCClearParameters);
            this.tabPage146.Controls.Add(this.edVLCParameter);
            this.tabPage146.Controls.Add(this.lbVLCParameters);
            this.tabPage146.Controls.Add(this.label2);
            this.tabPage146.Controls.Add(this.cbVLCZeroClockJitter);
            this.tabPage146.Controls.Add(this.edVLCCacheSize);
            this.tabPage146.Controls.Add(this.label312);
            this.tabPage146.Location = new System.Drawing.Point(4, 22);
            this.tabPage146.Name = "tabPage146";
            this.tabPage146.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage146.Size = new System.Drawing.Size(439, 247);
            this.tabPage146.TabIndex = 2;
            this.tabPage146.Text = "VLC";
            this.tabPage146.UseVisualStyleBackColor = true;
            // 
            // btVLCAddParameter
            // 
            this.btVLCAddParameter.Location = new System.Drawing.Point(245, 203);
            this.btVLCAddParameter.Name = "btVLCAddParameter";
            this.btVLCAddParameter.Size = new System.Drawing.Size(55, 23);
            this.btVLCAddParameter.TabIndex = 83;
            this.btVLCAddParameter.Text = "Add";
            this.btVLCAddParameter.UseVisualStyleBackColor = true;
            this.btVLCAddParameter.Click += new System.EventHandler(this.btVLCAddParameter_Click);
            // 
            // btVLCClearParameters
            // 
            this.btVLCClearParameters.Location = new System.Drawing.Point(368, 203);
            this.btVLCClearParameters.Name = "btVLCClearParameters";
            this.btVLCClearParameters.Size = new System.Drawing.Size(55, 23);
            this.btVLCClearParameters.TabIndex = 82;
            this.btVLCClearParameters.Text = "Clear";
            this.btVLCClearParameters.UseVisualStyleBackColor = true;
            this.btVLCClearParameters.Click += new System.EventHandler(this.btVLCClearParameters_Click);
            // 
            // edVLCParameter
            // 
            this.edVLCParameter.Location = new System.Drawing.Point(20, 205);
            this.edVLCParameter.Name = "edVLCParameter";
            this.edVLCParameter.Size = new System.Drawing.Size(219, 20);
            this.edVLCParameter.TabIndex = 81;
            // 
            // lbVLCParameters
            // 
            this.lbVLCParameters.FormattingEnabled = true;
            this.lbVLCParameters.Location = new System.Drawing.Point(20, 65);
            this.lbVLCParameters.Name = "lbVLCParameters";
            this.lbVLCParameters.Size = new System.Drawing.Size(403, 134);
            this.lbVLCParameters.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Custom parameters (same as in command line)";
            // 
            // cbVLCZeroClockJitter
            // 
            this.cbVLCZeroClockJitter.AutoSize = true;
            this.cbVLCZeroClockJitter.Location = new System.Drawing.Point(173, 16);
            this.cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter";
            this.cbVLCZeroClockJitter.Size = new System.Drawing.Size(131, 17);
            this.cbVLCZeroClockJitter.TabIndex = 78;
            this.cbVLCZeroClockJitter.Text = "VLC low latency mode";
            this.cbVLCZeroClockJitter.UseVisualStyleBackColor = true;
            // 
            // edVLCCacheSize
            // 
            this.edVLCCacheSize.Location = new System.Drawing.Point(119, 14);
            this.edVLCCacheSize.Name = "edVLCCacheSize";
            this.edVLCCacheSize.Size = new System.Drawing.Size(32, 20);
            this.edVLCCacheSize.TabIndex = 77;
            this.edVLCCacheSize.Text = "250";
            // 
            // label312
            // 
            this.label312.AutoSize = true;
            this.label312.Location = new System.Drawing.Point(17, 17);
            this.label312.Name = "label312";
            this.label312.Size = new System.Drawing.Size(103, 13);
            this.label312.TabIndex = 76;
            this.label312.Text = "VLC cache size (ms)";
            // 
            // tabPage145
            // 
            this.tabPage145.Controls.Add(this.edONVIFPassword);
            this.tabPage145.Controls.Add(this.label378);
            this.tabPage145.Controls.Add(this.edONVIFLogin);
            this.tabPage145.Controls.Add(this.label379);
            this.tabPage145.Controls.Add(this.edONVIFURL);
            this.tabPage145.Controls.Add(this.edONVIFLiveVideoURL);
            this.tabPage145.Controls.Add(this.label513);
            this.tabPage145.Controls.Add(this.groupBox42);
            this.tabPage145.Controls.Add(this.cbONVIFProfile);
            this.tabPage145.Controls.Add(this.label510);
            this.tabPage145.Controls.Add(this.lbONVIFCameraInfo);
            this.tabPage145.Controls.Add(this.btONVIFConnect);
            this.tabPage145.Location = new System.Drawing.Point(4, 22);
            this.tabPage145.Name = "tabPage145";
            this.tabPage145.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage145.Size = new System.Drawing.Size(439, 247);
            this.tabPage145.TabIndex = 1;
            this.tabPage145.Text = "ONVIF";
            this.tabPage145.UseVisualStyleBackColor = true;
            // 
            // edONVIFPassword
            // 
            this.edONVIFPassword.Location = new System.Drawing.Point(240, 38);
            this.edONVIFPassword.Name = "edONVIFPassword";
            this.edONVIFPassword.Size = new System.Drawing.Size(100, 20);
            this.edONVIFPassword.TabIndex = 70;
            // 
            // label378
            // 
            this.label378.AutoSize = true;
            this.label378.Location = new System.Drawing.Point(182, 41);
            this.label378.Name = "label378";
            this.label378.Size = new System.Drawing.Size(53, 13);
            this.label378.TabIndex = 69;
            this.label378.Text = "Password";
            // 
            // edONVIFLogin
            // 
            this.edONVIFLogin.Location = new System.Drawing.Point(75, 38);
            this.edONVIFLogin.Name = "edONVIFLogin";
            this.edONVIFLogin.Size = new System.Drawing.Size(100, 20);
            this.edONVIFLogin.TabIndex = 68;
            // 
            // label379
            // 
            this.label379.AutoSize = true;
            this.label379.Location = new System.Drawing.Point(11, 41);
            this.label379.Name = "label379";
            this.label379.Size = new System.Drawing.Size(33, 13);
            this.label379.TabIndex = 67;
            this.label379.Text = "Login";
            // 
            // edONVIFURL
            // 
            this.edONVIFURL.Location = new System.Drawing.Point(14, 8);
            this.edONVIFURL.Name = "edONVIFURL";
            this.edONVIFURL.Size = new System.Drawing.Size(326, 20);
            this.edONVIFURL.TabIndex = 29;
            this.edONVIFURL.Text = "http://192.168.1.219:8899/onvif/device_service";
            // 
            // edONVIFLiveVideoURL
            // 
            this.edONVIFLiveVideoURL.Location = new System.Drawing.Point(75, 111);
            this.edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL";
            this.edONVIFLiveVideoURL.ReadOnly = true;
            this.edONVIFLiveVideoURL.Size = new System.Drawing.Size(346, 20);
            this.edONVIFLiveVideoURL.TabIndex = 28;
            // 
            // label513
            // 
            this.label513.AutoSize = true;
            this.label513.Location = new System.Drawing.Point(11, 114);
            this.label513.Name = "label513";
            this.label513.Size = new System.Drawing.Size(59, 13);
            this.label513.TabIndex = 27;
            this.label513.Text = "Video URL";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.btONVIFPTZSetDefault);
            this.groupBox42.Controls.Add(this.btONVIFRight);
            this.groupBox42.Controls.Add(this.btONVIFLeft);
            this.groupBox42.Controls.Add(this.btONVIFZoomOut);
            this.groupBox42.Controls.Add(this.btONVIFZoomIn);
            this.groupBox42.Controls.Add(this.btONVIFDown);
            this.groupBox42.Controls.Add(this.btONVIFUp);
            this.groupBox42.Location = new System.Drawing.Point(150, 137);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(271, 104);
            this.groupBox42.TabIndex = 26;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "PTZ";
            // 
            // btONVIFPTZSetDefault
            // 
            this.btONVIFPTZSetDefault.Location = new System.Drawing.Point(130, 44);
            this.btONVIFPTZSetDefault.Name = "btONVIFPTZSetDefault";
            this.btONVIFPTZSetDefault.Size = new System.Drawing.Size(116, 23);
            this.btONVIFPTZSetDefault.TabIndex = 6;
            this.btONVIFPTZSetDefault.Text = "Set default position";
            this.btONVIFPTZSetDefault.UseVisualStyleBackColor = true;
            this.btONVIFPTZSetDefault.Click += new System.EventHandler(this.btONVIFPTZSetDefault_Click);
            // 
            // btONVIFRight
            // 
            this.btONVIFRight.Location = new System.Drawing.Point(85, 33);
            this.btONVIFRight.Name = "btONVIFRight";
            this.btONVIFRight.Size = new System.Drawing.Size(21, 48);
            this.btONVIFRight.TabIndex = 5;
            this.btONVIFRight.Text = "R";
            this.btONVIFRight.UseVisualStyleBackColor = true;
            this.btONVIFRight.Click += new System.EventHandler(this.btONVIFRight_Click);
            // 
            // btONVIFLeft
            // 
            this.btONVIFLeft.Location = new System.Drawing.Point(13, 32);
            this.btONVIFLeft.Name = "btONVIFLeft";
            this.btONVIFLeft.Size = new System.Drawing.Size(21, 48);
            this.btONVIFLeft.TabIndex = 4;
            this.btONVIFLeft.Text = "L";
            this.btONVIFLeft.UseVisualStyleBackColor = true;
            this.btONVIFLeft.Click += new System.EventHandler(this.btONVIFLeft_Click);
            // 
            // btONVIFZoomOut
            // 
            this.btONVIFZoomOut.Location = new System.Drawing.Point(61, 45);
            this.btONVIFZoomOut.Name = "btONVIFZoomOut";
            this.btONVIFZoomOut.Size = new System.Drawing.Size(23, 23);
            this.btONVIFZoomOut.TabIndex = 3;
            this.btONVIFZoomOut.Text = "-";
            this.btONVIFZoomOut.UseVisualStyleBackColor = true;
            this.btONVIFZoomOut.Click += new System.EventHandler(this.btONVIFZoomOut_Click);
            // 
            // btONVIFZoomIn
            // 
            this.btONVIFZoomIn.Location = new System.Drawing.Point(35, 45);
            this.btONVIFZoomIn.Name = "btONVIFZoomIn";
            this.btONVIFZoomIn.Size = new System.Drawing.Size(22, 23);
            this.btONVIFZoomIn.TabIndex = 2;
            this.btONVIFZoomIn.Text = "+";
            this.btONVIFZoomIn.UseVisualStyleBackColor = true;
            this.btONVIFZoomIn.Click += new System.EventHandler(this.btONVIFZoomIn_Click);
            // 
            // btONVIFDown
            // 
            this.btONVIFDown.Location = new System.Drawing.Point(34, 69);
            this.btONVIFDown.Name = "btONVIFDown";
            this.btONVIFDown.Size = new System.Drawing.Size(51, 23);
            this.btONVIFDown.TabIndex = 1;
            this.btONVIFDown.Text = "Down";
            this.btONVIFDown.UseVisualStyleBackColor = true;
            this.btONVIFDown.Click += new System.EventHandler(this.btONVIFDown_Click);
            // 
            // btONVIFUp
            // 
            this.btONVIFUp.Location = new System.Drawing.Point(34, 20);
            this.btONVIFUp.Name = "btONVIFUp";
            this.btONVIFUp.Size = new System.Drawing.Size(51, 23);
            this.btONVIFUp.TabIndex = 0;
            this.btONVIFUp.Text = "Up";
            this.btONVIFUp.UseVisualStyleBackColor = true;
            this.btONVIFUp.Click += new System.EventHandler(this.btONVIFUp_Click);
            // 
            // cbONVIFProfile
            // 
            this.cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbONVIFProfile.FormattingEnabled = true;
            this.cbONVIFProfile.Location = new System.Drawing.Point(75, 85);
            this.cbONVIFProfile.Name = "cbONVIFProfile";
            this.cbONVIFProfile.Size = new System.Drawing.Size(346, 21);
            this.cbONVIFProfile.TabIndex = 4;
            // 
            // label510
            // 
            this.label510.AutoSize = true;
            this.label510.Location = new System.Drawing.Point(11, 88);
            this.label510.Name = "label510";
            this.label510.Size = new System.Drawing.Size(36, 13);
            this.label510.TabIndex = 3;
            this.label510.Text = "Profile";
            // 
            // lbONVIFCameraInfo
            // 
            this.lbONVIFCameraInfo.AutoSize = true;
            this.lbONVIFCameraInfo.Location = new System.Drawing.Point(11, 67);
            this.lbONVIFCameraInfo.Name = "lbONVIFCameraInfo";
            this.lbONVIFCameraInfo.Size = new System.Drawing.Size(69, 13);
            this.lbONVIFCameraInfo.TabIndex = 1;
            this.lbONVIFCameraInfo.Text = "Status: None";
            // 
            // btONVIFConnect
            // 
            this.btONVIFConnect.Location = new System.Drawing.Point(346, 6);
            this.btONVIFConnect.Name = "btONVIFConnect";
            this.btONVIFConnect.Size = new System.Drawing.Size(75, 23);
            this.btONVIFConnect.TabIndex = 0;
            this.btONVIFConnect.Text = "Connect";
            this.btONVIFConnect.UseVisualStyleBackColor = true;
            this.btONVIFConnect.Click += new System.EventHandler(this.btONVIFConnect_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDecklinkCaptureVideoFormat);
            this.tabPage4.Controls.Add(this.label66);
            this.tabPage4.Controls.Add(this.cbDecklinkCaptureDevice);
            this.tabPage4.Controls.Add(this.label39);
            this.tabPage4.Controls.Add(this.cbDecklinkSourceTimecode);
            this.tabPage4.Controls.Add(this.label341);
            this.tabPage4.Controls.Add(this.cbDecklinkSourceComponentLevels);
            this.tabPage4.Controls.Add(this.label339);
            this.tabPage4.Controls.Add(this.cbDecklinkSourceNTSC);
            this.tabPage4.Controls.Add(this.label340);
            this.tabPage4.Controls.Add(this.cbDecklinkSourceInput);
            this.tabPage4.Controls.Add(this.label338);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(459, 285);
            this.tabPage4.TabIndex = 11;
            this.tabPage4.Text = "Decklink";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkCaptureVideoFormat
            // 
            this.cbDecklinkCaptureVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkCaptureVideoFormat.FormattingEnabled = true;
            this.cbDecklinkCaptureVideoFormat.Location = new System.Drawing.Point(20, 77);
            this.cbDecklinkCaptureVideoFormat.Name = "cbDecklinkCaptureVideoFormat";
            this.cbDecklinkCaptureVideoFormat.Size = new System.Drawing.Size(182, 21);
            this.cbDecklinkCaptureVideoFormat.TabIndex = 27;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(17, 61);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(159, 13);
            this.label66.TabIndex = 26;
            this.label66.Text = "Video format (original format first)";
            // 
            // cbDecklinkCaptureDevice
            // 
            this.cbDecklinkCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkCaptureDevice.FormattingEnabled = true;
            this.cbDecklinkCaptureDevice.Location = new System.Drawing.Point(20, 33);
            this.cbDecklinkCaptureDevice.Name = "cbDecklinkCaptureDevice";
            this.cbDecklinkCaptureDevice.Size = new System.Drawing.Size(182, 21);
            this.cbDecklinkCaptureDevice.TabIndex = 25;
            this.cbDecklinkCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.cbDecklinkCaptureDevice_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(17, 17);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(41, 13);
            this.label39.TabIndex = 24;
            this.label39.Text = "Device";
            // 
            // cbDecklinkSourceTimecode
            // 
            this.cbDecklinkSourceTimecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkSourceTimecode.FormattingEnabled = true;
            this.cbDecklinkSourceTimecode.Items.AddRange(new object[] {
            "Auto",
            "VITC",
            "HANC"});
            this.cbDecklinkSourceTimecode.Location = new System.Drawing.Point(174, 256);
            this.cbDecklinkSourceTimecode.Name = "cbDecklinkSourceTimecode";
            this.cbDecklinkSourceTimecode.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkSourceTimecode.TabIndex = 23;
            // 
            // label341
            // 
            this.label341.AutoSize = true;
            this.label341.Location = new System.Drawing.Point(171, 240);
            this.label341.Name = "label341";
            this.label341.Size = new System.Drawing.Size(89, 13);
            this.label341.TabIndex = 22;
            this.label341.Text = "Timecode source";
            // 
            // cbDecklinkSourceComponentLevels
            // 
            this.cbDecklinkSourceComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkSourceComponentLevels.FormattingEnabled = true;
            this.cbDecklinkSourceComponentLevels.Items.AddRange(new object[] {
            "SMPTE",
            "Betacam"});
            this.cbDecklinkSourceComponentLevels.Location = new System.Drawing.Point(326, 256);
            this.cbDecklinkSourceComponentLevels.Name = "cbDecklinkSourceComponentLevels";
            this.cbDecklinkSourceComponentLevels.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkSourceComponentLevels.TabIndex = 21;
            // 
            // label339
            // 
            this.label339.AutoSize = true;
            this.label339.Location = new System.Drawing.Point(323, 240);
            this.label339.Name = "label339";
            this.label339.Size = new System.Drawing.Size(91, 13);
            this.label339.TabIndex = 20;
            this.label339.Text = "Component levels";
            // 
            // cbDecklinkSourceNTSC
            // 
            this.cbDecklinkSourceNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkSourceNTSC.FormattingEnabled = true;
            this.cbDecklinkSourceNTSC.Items.AddRange(new object[] {
            "USA",
            "Japan"});
            this.cbDecklinkSourceNTSC.Location = new System.Drawing.Point(326, 211);
            this.cbDecklinkSourceNTSC.Name = "cbDecklinkSourceNTSC";
            this.cbDecklinkSourceNTSC.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkSourceNTSC.TabIndex = 19;
            // 
            // label340
            // 
            this.label340.AutoSize = true;
            this.label340.Location = new System.Drawing.Point(323, 195);
            this.label340.Name = "label340";
            this.label340.Size = new System.Drawing.Size(80, 13);
            this.label340.TabIndex = 18;
            this.label340.Text = "NTSC standard";
            // 
            // cbDecklinkSourceInput
            // 
            this.cbDecklinkSourceInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecklinkSourceInput.FormattingEnabled = true;
            this.cbDecklinkSourceInput.Items.AddRange(new object[] {
            "Auto",
            "SDI",
            "Composite",
            "Component",
            "S-Video",
            "HDMI",
            "Optical SDI"});
            this.cbDecklinkSourceInput.Location = new System.Drawing.Point(174, 211);
            this.cbDecklinkSourceInput.Name = "cbDecklinkSourceInput";
            this.cbDecklinkSourceInput.Size = new System.Drawing.Size(121, 21);
            this.cbDecklinkSourceInput.TabIndex = 17;
            // 
            // label338
            // 
            this.label338.AutoSize = true;
            this.label338.Location = new System.Drawing.Point(171, 195);
            this.label338.Name = "label338";
            this.label338.Size = new System.Drawing.Size(31, 13);
            this.label338.TabIndex = 16;
            this.label338.Text = "Input";
            // 
            // tabPage81
            // 
            this.tabPage81.Controls.Add(this.tabControl22);
            this.tabPage81.Location = new System.Drawing.Point(4, 22);
            this.tabPage81.Name = "tabPage81";
            this.tabPage81.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage81.Size = new System.Drawing.Size(459, 285);
            this.tabPage81.TabIndex = 7;
            this.tabPage81.Text = "DVB-x / ATSC";
            this.tabPage81.UseVisualStyleBackColor = true;
            // 
            // tabControl22
            // 
            this.tabControl22.Controls.Add(this.tabPage82);
            this.tabControl22.Controls.Add(this.tabPage83);
            this.tabControl22.Controls.Add(this.tabPage105);
            this.tabControl22.Location = new System.Drawing.Point(6, 6);
            this.tabControl22.Name = "tabControl22";
            this.tabControl22.SelectedIndex = 0;
            this.tabControl22.Size = new System.Drawing.Size(447, 273);
            this.tabControl22.TabIndex = 12;
            // 
            // tabPage82
            // 
            this.tabPage82.Controls.Add(this.cbBDADeviceStandard);
            this.tabPage82.Controls.Add(this.label129);
            this.tabPage82.Controls.Add(this.cbBDAReceiver);
            this.tabPage82.Controls.Add(this.label270);
            this.tabPage82.Controls.Add(this.cbBDASourceDevice);
            this.tabPage82.Controls.Add(this.label272);
            this.tabPage82.Location = new System.Drawing.Point(4, 22);
            this.tabPage82.Name = "tabPage82";
            this.tabPage82.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage82.Size = new System.Drawing.Size(439, 247);
            this.tabPage82.TabIndex = 0;
            this.tabPage82.Text = "Input device";
            this.tabPage82.UseVisualStyleBackColor = true;
            // 
            // cbBDADeviceStandard
            // 
            this.cbBDADeviceStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBDADeviceStandard.FormattingEnabled = true;
            this.cbBDADeviceStandard.Items.AddRange(new object[] {
            "DVB-T",
            "DVB-S",
            "DVB-C",
            "ATSC (not supported now)"});
            this.cbBDADeviceStandard.Location = new System.Drawing.Point(14, 130);
            this.cbBDADeviceStandard.Name = "cbBDADeviceStandard";
            this.cbBDADeviceStandard.Size = new System.Drawing.Size(269, 21);
            this.cbBDADeviceStandard.TabIndex = 17;
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(11, 114);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(85, 13);
            this.label129.TabIndex = 16;
            this.label129.Text = "Device standard";
            // 
            // cbBDAReceiver
            // 
            this.cbBDAReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBDAReceiver.FormattingEnabled = true;
            this.cbBDAReceiver.Items.AddRange(new object[] {
            ""});
            this.cbBDAReceiver.Location = new System.Drawing.Point(14, 81);
            this.cbBDAReceiver.Name = "cbBDAReceiver";
            this.cbBDAReceiver.Size = new System.Drawing.Size(269, 21);
            this.cbBDAReceiver.TabIndex = 15;
            // 
            // label270
            // 
            this.label270.AutoSize = true;
            this.label270.Location = new System.Drawing.Point(11, 65);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(158, 13);
            this.label270.TabIndex = 14;
            this.label270.Text = "Receiver device (can be empty)";
            // 
            // cbBDASourceDevice
            // 
            this.cbBDASourceDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBDASourceDevice.FormattingEnabled = true;
            this.cbBDASourceDevice.Location = new System.Drawing.Point(14, 32);
            this.cbBDASourceDevice.Name = "cbBDASourceDevice";
            this.cbBDASourceDevice.Size = new System.Drawing.Size(269, 21);
            this.cbBDASourceDevice.TabIndex = 13;
            // 
            // label272
            // 
            this.label272.AutoSize = true;
            this.label272.Location = new System.Drawing.Point(11, 16);
            this.label272.Name = "label272";
            this.label272.Size = new System.Drawing.Size(76, 13);
            this.label272.TabIndex = 12;
            this.label272.Text = "Source device";
            // 
            // tabPage83
            // 
            this.tabPage83.Controls.Add(this.tabControl23);
            this.tabPage83.Location = new System.Drawing.Point(4, 22);
            this.tabPage83.Name = "tabPage83";
            this.tabPage83.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage83.Size = new System.Drawing.Size(439, 247);
            this.tabPage83.TabIndex = 1;
            this.tabPage83.Text = "Tuning";
            this.tabPage83.UseVisualStyleBackColor = true;
            // 
            // tabControl23
            // 
            this.tabControl23.Controls.Add(this.tabPage84);
            this.tabControl23.Controls.Add(this.tabPage85);
            this.tabControl23.Controls.Add(this.tabPage86);
            this.tabControl23.Controls.Add(this.tabPage87);
            this.tabControl23.Location = new System.Drawing.Point(6, 4);
            this.tabControl23.Name = "tabControl23";
            this.tabControl23.SelectedIndex = 0;
            this.tabControl23.Size = new System.Drawing.Size(427, 240);
            this.tabControl23.TabIndex = 8;
            // 
            // tabPage84
            // 
            this.tabPage84.Controls.Add(this.btDVBTTune);
            this.tabPage84.Controls.Add(this.edDVBTSID);
            this.tabPage84.Controls.Add(this.edDVBTTSID);
            this.tabPage84.Controls.Add(this.edDVBTONID);
            this.tabPage84.Controls.Add(this.label273);
            this.tabPage84.Controls.Add(this.edDVBTFrequency);
            this.tabPage84.Controls.Add(this.label274);
            this.tabPage84.Controls.Add(this.label275);
            this.tabPage84.Controls.Add(this.label276);
            this.tabPage84.Controls.Add(this.label277);
            this.tabPage84.Location = new System.Drawing.Point(4, 22);
            this.tabPage84.Name = "tabPage84";
            this.tabPage84.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage84.Size = new System.Drawing.Size(419, 214);
            this.tabPage84.TabIndex = 0;
            this.tabPage84.Text = "DVB-T";
            this.tabPage84.UseVisualStyleBackColor = true;
            // 
            // btDVBTTune
            // 
            this.btDVBTTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btDVBTTune.Location = new System.Drawing.Point(6, 185);
            this.btDVBTTune.Name = "btDVBTTune";
            this.btDVBTTune.Size = new System.Drawing.Size(46, 23);
            this.btDVBTTune.TabIndex = 21;
            this.btDVBTTune.Text = "Tune";
            this.btDVBTTune.UseVisualStyleBackColor = true;
            this.btDVBTTune.Click += new System.EventHandler(this.btDVBTTune_Click);
            // 
            // edDVBTSID
            // 
            this.edDVBTSID.Location = new System.Drawing.Point(102, 94);
            this.edDVBTSID.Name = "edDVBTSID";
            this.edDVBTSID.Size = new System.Drawing.Size(94, 20);
            this.edDVBTSID.TabIndex = 20;
            this.edDVBTSID.Text = "1010";
            // 
            // edDVBTTSID
            // 
            this.edDVBTTSID.Location = new System.Drawing.Point(102, 66);
            this.edDVBTTSID.Name = "edDVBTTSID";
            this.edDVBTTSID.Size = new System.Drawing.Size(94, 20);
            this.edDVBTTSID.TabIndex = 19;
            this.edDVBTTSID.Text = "-1";
            // 
            // edDVBTONID
            // 
            this.edDVBTONID.Location = new System.Drawing.Point(102, 37);
            this.edDVBTONID.Name = "edDVBTONID";
            this.edDVBTONID.Size = new System.Drawing.Size(94, 20);
            this.edDVBTONID.TabIndex = 18;
            this.edDVBTONID.Text = "-1";
            // 
            // label273
            // 
            this.label273.AutoSize = true;
            this.label273.Location = new System.Drawing.Point(202, 11);
            this.label273.Name = "label273";
            this.label273.Size = new System.Drawing.Size(27, 13);
            this.label273.TabIndex = 17;
            this.label273.Text = "KHz";
            // 
            // edDVBTFrequency
            // 
            this.edDVBTFrequency.Location = new System.Drawing.Point(102, 8);
            this.edDVBTFrequency.Name = "edDVBTFrequency";
            this.edDVBTFrequency.Size = new System.Drawing.Size(94, 20);
            this.edDVBTFrequency.TabIndex = 16;
            this.edDVBTFrequency.Text = "586000";
            // 
            // label274
            // 
            this.label274.AutoSize = true;
            this.label274.Location = new System.Drawing.Point(6, 97);
            this.label274.Name = "label274";
            this.label274.Size = new System.Drawing.Size(25, 13);
            this.label274.TabIndex = 15;
            this.label274.Text = "SID";
            // 
            // label275
            // 
            this.label275.AutoSize = true;
            this.label275.Location = new System.Drawing.Point(6, 69);
            this.label275.Name = "label275";
            this.label275.Size = new System.Drawing.Size(32, 13);
            this.label275.TabIndex = 14;
            this.label275.Text = "TSID";
            // 
            // label276
            // 
            this.label276.AutoSize = true;
            this.label276.Location = new System.Drawing.Point(6, 40);
            this.label276.Name = "label276";
            this.label276.Size = new System.Drawing.Size(34, 13);
            this.label276.TabIndex = 13;
            this.label276.Text = "ONID";
            // 
            // label277
            // 
            this.label277.AutoSize = true;
            this.label277.Location = new System.Drawing.Point(6, 11);
            this.label277.Name = "label277";
            this.label277.Size = new System.Drawing.Size(90, 13);
            this.label277.TabIndex = 12;
            this.label277.Text = "Carrier Frequency";
            // 
            // tabPage85
            // 
            this.tabPage85.Controls.Add(this.cbDVBSPolarisation);
            this.tabPage85.Controls.Add(this.label278);
            this.tabPage85.Controls.Add(this.edDVBSSymbolRate);
            this.tabPage85.Controls.Add(this.label279);
            this.tabPage85.Controls.Add(this.btDVBSTune);
            this.tabPage85.Controls.Add(this.edDVBSSID);
            this.tabPage85.Controls.Add(this.edDVBSTSID);
            this.tabPage85.Controls.Add(this.edDVBSONIT);
            this.tabPage85.Controls.Add(this.label280);
            this.tabPage85.Controls.Add(this.edDVBSFrequency);
            this.tabPage85.Controls.Add(this.label281);
            this.tabPage85.Controls.Add(this.label282);
            this.tabPage85.Controls.Add(this.label283);
            this.tabPage85.Controls.Add(this.label284);
            this.tabPage85.Location = new System.Drawing.Point(4, 22);
            this.tabPage85.Name = "tabPage85";
            this.tabPage85.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage85.Size = new System.Drawing.Size(419, 214);
            this.tabPage85.TabIndex = 1;
            this.tabPage85.Text = "DVB-S";
            this.tabPage85.UseVisualStyleBackColor = true;
            // 
            // cbDVBSPolarisation
            // 
            this.cbDVBSPolarisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVBSPolarisation.Items.AddRange(new object[] {
            "Not Set",
            "Not Defined",
            "Linear Horizontal",
            "Linear Vertical",
            "Circular Left",
            "Circular Right",
            "Max"});
            this.cbDVBSPolarisation.Location = new System.Drawing.Point(102, 60);
            this.cbDVBSPolarisation.Name = "cbDVBSPolarisation";
            this.cbDVBSPolarisation.Size = new System.Drawing.Size(94, 21);
            this.cbDVBSPolarisation.TabIndex = 34;
            // 
            // label278
            // 
            this.label278.AutoSize = true;
            this.label278.Location = new System.Drawing.Point(6, 63);
            this.label278.Name = "label278";
            this.label278.Size = new System.Drawing.Size(93, 13);
            this.label278.TabIndex = 33;
            this.label278.Text = "Signal Polarisation";
            // 
            // edDVBSSymbolRate
            // 
            this.edDVBSSymbolRate.Location = new System.Drawing.Point(102, 34);
            this.edDVBSSymbolRate.Name = "edDVBSSymbolRate";
            this.edDVBSSymbolRate.Size = new System.Drawing.Size(94, 20);
            this.edDVBSSymbolRate.TabIndex = 32;
            this.edDVBSSymbolRate.Text = "-1";
            // 
            // label279
            // 
            this.label279.AutoSize = true;
            this.label279.Location = new System.Drawing.Point(6, 37);
            this.label279.Name = "label279";
            this.label279.Size = new System.Drawing.Size(67, 13);
            this.label279.TabIndex = 31;
            this.label279.Text = "Symbol Rate";
            // 
            // btDVBSTune
            // 
            this.btDVBSTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btDVBSTune.Location = new System.Drawing.Point(6, 185);
            this.btDVBSTune.Name = "btDVBSTune";
            this.btDVBSTune.Size = new System.Drawing.Size(46, 23);
            this.btDVBSTune.TabIndex = 30;
            this.btDVBSTune.Text = "Tune";
            this.btDVBSTune.UseVisualStyleBackColor = true;
            // 
            // edDVBSSID
            // 
            this.edDVBSSID.Location = new System.Drawing.Point(102, 144);
            this.edDVBSSID.Name = "edDVBSSID";
            this.edDVBSSID.Size = new System.Drawing.Size(94, 20);
            this.edDVBSSID.TabIndex = 29;
            this.edDVBSSID.Text = "-1";
            // 
            // edDVBSTSID
            // 
            this.edDVBSTSID.Location = new System.Drawing.Point(102, 116);
            this.edDVBSTSID.Name = "edDVBSTSID";
            this.edDVBSTSID.Size = new System.Drawing.Size(94, 20);
            this.edDVBSTSID.TabIndex = 28;
            this.edDVBSTSID.Text = "-1";
            // 
            // edDVBSONIT
            // 
            this.edDVBSONIT.Location = new System.Drawing.Point(102, 87);
            this.edDVBSONIT.Name = "edDVBSONIT";
            this.edDVBSONIT.Size = new System.Drawing.Size(94, 20);
            this.edDVBSONIT.TabIndex = 27;
            this.edDVBSONIT.Text = "-1";
            // 
            // label280
            // 
            this.label280.AutoSize = true;
            this.label280.Location = new System.Drawing.Point(202, 11);
            this.label280.Name = "label280";
            this.label280.Size = new System.Drawing.Size(27, 13);
            this.label280.TabIndex = 26;
            this.label280.Text = "KHz";
            // 
            // edDVBSFrequency
            // 
            this.edDVBSFrequency.Location = new System.Drawing.Point(102, 8);
            this.edDVBSFrequency.Name = "edDVBSFrequency";
            this.edDVBSFrequency.Size = new System.Drawing.Size(94, 20);
            this.edDVBSFrequency.TabIndex = 25;
            this.edDVBSFrequency.Text = "-1";
            // 
            // label281
            // 
            this.label281.AutoSize = true;
            this.label281.Location = new System.Drawing.Point(6, 147);
            this.label281.Name = "label281";
            this.label281.Size = new System.Drawing.Size(25, 13);
            this.label281.TabIndex = 24;
            this.label281.Text = "SID";
            // 
            // label282
            // 
            this.label282.AutoSize = true;
            this.label282.Location = new System.Drawing.Point(6, 119);
            this.label282.Name = "label282";
            this.label282.Size = new System.Drawing.Size(32, 13);
            this.label282.TabIndex = 23;
            this.label282.Text = "TSID";
            // 
            // label283
            // 
            this.label283.AutoSize = true;
            this.label283.Location = new System.Drawing.Point(6, 90);
            this.label283.Name = "label283";
            this.label283.Size = new System.Drawing.Size(33, 13);
            this.label283.TabIndex = 22;
            this.label283.Text = "ONIT";
            // 
            // label284
            // 
            this.label284.AutoSize = true;
            this.label284.Location = new System.Drawing.Point(6, 11);
            this.label284.Name = "label284";
            this.label284.Size = new System.Drawing.Size(90, 13);
            this.label284.TabIndex = 21;
            this.label284.Text = "Carrier Frequency";
            // 
            // tabPage86
            // 
            this.tabPage86.Controls.Add(this.groupBox35);
            this.tabPage86.Controls.Add(this.groupBox36);
            this.tabPage86.Controls.Add(this.btBDADVBCTune);
            this.tabPage86.Location = new System.Drawing.Point(4, 22);
            this.tabPage86.Name = "tabPage86";
            this.tabPage86.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage86.Size = new System.Drawing.Size(419, 214);
            this.tabPage86.TabIndex = 2;
            this.tabPage86.Text = "DVB-C";
            this.tabPage86.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.edDVBCMinorChannel);
            this.groupBox35.Controls.Add(this.label285);
            this.groupBox35.Controls.Add(this.edDVBCPhysicalChannel);
            this.groupBox35.Controls.Add(this.label286);
            this.groupBox35.Controls.Add(this.edDVBCVirtualChannel);
            this.groupBox35.Controls.Add(this.label287);
            this.groupBox35.Location = new System.Drawing.Point(232, 9);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(181, 107);
            this.groupBox35.TabIndex = 46;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Tune request";
            // 
            // edDVBCMinorChannel
            // 
            this.edDVBCMinorChannel.Location = new System.Drawing.Point(98, 76);
            this.edDVBCMinorChannel.Name = "edDVBCMinorChannel";
            this.edDVBCMinorChannel.Size = new System.Drawing.Size(77, 20);
            this.edDVBCMinorChannel.TabIndex = 57;
            this.edDVBCMinorChannel.Text = "-1";
            // 
            // label285
            // 
            this.label285.AutoSize = true;
            this.label285.Location = new System.Drawing.Point(6, 79);
            this.label285.Name = "label285";
            this.label285.Size = new System.Drawing.Size(74, 13);
            this.label285.TabIndex = 56;
            this.label285.Text = "Minor channel";
            // 
            // edDVBCPhysicalChannel
            // 
            this.edDVBCPhysicalChannel.Location = new System.Drawing.Point(98, 51);
            this.edDVBCPhysicalChannel.Name = "edDVBCPhysicalChannel";
            this.edDVBCPhysicalChannel.Size = new System.Drawing.Size(77, 20);
            this.edDVBCPhysicalChannel.TabIndex = 55;
            this.edDVBCPhysicalChannel.Text = "103";
            // 
            // label286
            // 
            this.label286.AutoSize = true;
            this.label286.Location = new System.Drawing.Point(6, 54);
            this.label286.Name = "label286";
            this.label286.Size = new System.Drawing.Size(87, 13);
            this.label286.TabIndex = 54;
            this.label286.Text = "Physical channel";
            // 
            // edDVBCVirtualChannel
            // 
            this.edDVBCVirtualChannel.Location = new System.Drawing.Point(98, 24);
            this.edDVBCVirtualChannel.Name = "edDVBCVirtualChannel";
            this.edDVBCVirtualChannel.Size = new System.Drawing.Size(77, 20);
            this.edDVBCVirtualChannel.TabIndex = 53;
            this.edDVBCVirtualChannel.Text = "-1";
            // 
            // label287
            // 
            this.label287.AutoSize = true;
            this.label287.Location = new System.Drawing.Point(6, 27);
            this.label287.Name = "label287";
            this.label287.Size = new System.Drawing.Size(77, 13);
            this.label287.TabIndex = 52;
            this.label287.Text = "Virtual channel";
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.edDVBCSymbolRate);
            this.groupBox36.Controls.Add(this.label288);
            this.groupBox36.Controls.Add(this.edDVBCProgramNumber);
            this.groupBox36.Controls.Add(this.label289);
            this.groupBox36.Controls.Add(this.cbDVBCModulation);
            this.groupBox36.Controls.Add(this.label290);
            this.groupBox36.Controls.Add(this.label291);
            this.groupBox36.Controls.Add(this.edDVBCCarrierFrequency);
            this.groupBox36.Controls.Add(this.label292);
            this.groupBox36.Location = new System.Drawing.Point(6, 9);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(220, 139);
            this.groupBox36.TabIndex = 45;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Current locator properties";
            // 
            // edDVBCSymbolRate
            // 
            this.edDVBCSymbolRate.Location = new System.Drawing.Point(106, 104);
            this.edDVBCSymbolRate.Name = "edDVBCSymbolRate";
            this.edDVBCSymbolRate.Size = new System.Drawing.Size(77, 20);
            this.edDVBCSymbolRate.TabIndex = 53;
            this.edDVBCSymbolRate.Text = "6875";
            // 
            // label288
            // 
            this.label288.AutoSize = true;
            this.label288.Location = new System.Drawing.Point(10, 107);
            this.label288.Name = "label288";
            this.label288.Size = new System.Drawing.Size(62, 13);
            this.label288.TabIndex = 52;
            this.label288.Text = "Symbol rate";
            // 
            // edDVBCProgramNumber
            // 
            this.edDVBCProgramNumber.Location = new System.Drawing.Point(106, 78);
            this.edDVBCProgramNumber.Name = "edDVBCProgramNumber";
            this.edDVBCProgramNumber.Size = new System.Drawing.Size(77, 20);
            this.edDVBCProgramNumber.TabIndex = 51;
            this.edDVBCProgramNumber.Text = "8";
            // 
            // label289
            // 
            this.label289.AutoSize = true;
            this.label289.Location = new System.Drawing.Point(10, 81);
            this.label289.Name = "label289";
            this.label289.Size = new System.Drawing.Size(84, 13);
            this.label289.TabIndex = 50;
            this.label289.Text = "Program number";
            // 
            // cbDVBCModulation
            // 
            this.cbDVBCModulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVBCModulation.Items.AddRange(new object[] {
            "ModNotSet",
            "ModNotDefined",
            "Mod16Qam",
            "Mod32Qam",
            "Mod64Qam",
            "Mod80Qam",
            "Mod96Qam",
            "Mod112Qam",
            "Mod128Qam",
            "Mod160Qam",
            "Mod192Qam",
            "Mod224Qam",
            "Mod256Qam",
            "Mod320Qam",
            "Mod384Qam",
            "Mod448Qam",
            "Mod512Qam",
            "Mod640Qam",
            "Mod768Qam",
            "Mod896Qam",
            "Mod1024Qam",
            "ModQpsk",
            "ModBpsk",
            "ModOqpsk",
            "Mod8Vsb",
            "Mod16Vsb",
            "ModAnalogAmplitude ",
            "ModAnalogFrequency ",
            "Mod8Psk",
            "ModRF",
            "Mod16Apsk",
            "Mod32Apsk",
            "ModNbcQpsk",
            "ModNbc8Psk",
            "ModDirectTv",
            "ModMax"});
            this.cbDVBCModulation.Location = new System.Drawing.Point(106, 51);
            this.cbDVBCModulation.Name = "cbDVBCModulation";
            this.cbDVBCModulation.Size = new System.Drawing.Size(77, 21);
            this.cbDVBCModulation.TabIndex = 49;
            // 
            // label290
            // 
            this.label290.AutoSize = true;
            this.label290.Location = new System.Drawing.Point(10, 54);
            this.label290.Name = "label290";
            this.label290.Size = new System.Drawing.Size(59, 13);
            this.label290.TabIndex = 48;
            this.label290.Text = "Modulation";
            // 
            // label291
            // 
            this.label291.AutoSize = true;
            this.label291.Location = new System.Drawing.Point(189, 28);
            this.label291.Name = "label291";
            this.label291.Size = new System.Drawing.Size(27, 13);
            this.label291.TabIndex = 47;
            this.label291.Text = "KHz";
            // 
            // edDVBCCarrierFrequency
            // 
            this.edDVBCCarrierFrequency.Location = new System.Drawing.Point(106, 24);
            this.edDVBCCarrierFrequency.Name = "edDVBCCarrierFrequency";
            this.edDVBCCarrierFrequency.Size = new System.Drawing.Size(77, 20);
            this.edDVBCCarrierFrequency.TabIndex = 46;
            this.edDVBCCarrierFrequency.Text = "303250";
            // 
            // label292
            // 
            this.label292.AutoSize = true;
            this.label292.Location = new System.Drawing.Point(10, 27);
            this.label292.Name = "label292";
            this.label292.Size = new System.Drawing.Size(87, 13);
            this.label292.TabIndex = 45;
            this.label292.Text = "Carrier frequency";
            // 
            // btBDADVBCTune
            // 
            this.btBDADVBCTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btBDADVBCTune.Location = new System.Drawing.Point(6, 185);
            this.btBDADVBCTune.Name = "btBDADVBCTune";
            this.btBDADVBCTune.Size = new System.Drawing.Size(46, 23);
            this.btBDADVBCTune.TabIndex = 36;
            this.btBDADVBCTune.Text = "Tune";
            this.btBDADVBCTune.UseVisualStyleBackColor = true;
            // 
            // tabPage87
            // 
            this.tabPage87.Controls.Add(this.label293);
            this.tabPage87.Location = new System.Drawing.Point(4, 22);
            this.tabPage87.Name = "tabPage87";
            this.tabPage87.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage87.Size = new System.Drawing.Size(419, 214);
            this.tabPage87.TabIndex = 3;
            this.tabPage87.Text = "ATSC";
            this.tabPage87.UseVisualStyleBackColor = true;
            // 
            // label293
            // 
            this.label293.AutoSize = true;
            this.label293.Location = new System.Drawing.Point(10, 11);
            this.label293.Name = "label293";
            this.label293.Size = new System.Drawing.Size(101, 13);
            this.label293.TabIndex = 0;
            this.label293.Text = "not implemented yet";
            // 
            // tabPage105
            // 
            this.tabPage105.Controls.Add(this.btBDAChannelScanningStart);
            this.tabPage105.Controls.Add(this.lvBDAChannels);
            this.tabPage105.Controls.Add(this.label342);
            this.tabPage105.Location = new System.Drawing.Point(4, 22);
            this.tabPage105.Name = "tabPage105";
            this.tabPage105.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage105.Size = new System.Drawing.Size(439, 247);
            this.tabPage105.TabIndex = 2;
            this.tabPage105.Text = "Channel scanning";
            this.tabPage105.UseVisualStyleBackColor = true;
            // 
            // btBDAChannelScanningStart
            // 
            this.btBDAChannelScanningStart.Location = new System.Drawing.Point(364, 210);
            this.btBDAChannelScanningStart.Name = "btBDAChannelScanningStart";
            this.btBDAChannelScanningStart.Size = new System.Drawing.Size(56, 23);
            this.btBDAChannelScanningStart.TabIndex = 2;
            this.btBDAChannelScanningStart.Text = "Start";
            this.btBDAChannelScanningStart.UseVisualStyleBackColor = true;
            this.btBDAChannelScanningStart.Click += new System.EventHandler(this.btBDAChannelScanningStart_Click);
            // 
            // lvBDAChannels
            // 
            this.lvBDAChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvBDAChannels.HideSelection = false;
            this.lvBDAChannels.Location = new System.Drawing.Point(19, 36);
            this.lvBDAChannels.Name = "lvBDAChannels";
            this.lvBDAChannels.Size = new System.Drawing.Size(401, 168);
            this.lvBDAChannels.TabIndex = 1;
            this.lvBDAChannels.UseCompatibleStateImageBehavior = false;
            this.lvBDAChannels.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Frequency";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Audio PID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Video PID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SID";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Symbol rate";
            // 
            // label342
            // 
            this.label342.AutoSize = true;
            this.label342.Location = new System.Drawing.Point(16, 20);
            this.label342.Name = "label342";
            this.label342.Size = new System.Drawing.Size(288, 13);
            this.label342.TabIndex = 0;
            this.label342.Text = "Please tune to a required frequency or other parameters first";
            // 
            // tabPage49
            // 
            this.tabPage49.Controls.Add(this.tabControl20);
            this.tabPage49.Location = new System.Drawing.Point(4, 22);
            this.tabPage49.Name = "tabPage49";
            this.tabPage49.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage49.Size = new System.Drawing.Size(459, 285);
            this.tabPage49.TabIndex = 3;
            this.tabPage49.Text = "Picture-In-Picture";
            this.tabPage49.UseVisualStyleBackColor = true;
            // 
            // tabControl20
            // 
            this.tabControl20.Controls.Add(this.tabPage67);
            this.tabControl20.Controls.Add(this.tabPage77);
            this.tabControl20.Controls.Add(this.tabPage147);
            this.tabControl20.Location = new System.Drawing.Point(6, 4);
            this.tabControl20.Name = "tabControl20";
            this.tabControl20.SelectedIndex = 0;
            this.tabControl20.Size = new System.Drawing.Size(450, 275);
            this.tabControl20.TabIndex = 0;
            // 
            // tabPage67
            // 
            this.tabPage67.Controls.Add(this.tabControl21);
            this.tabPage67.Location = new System.Drawing.Point(4, 22);
            this.tabPage67.Name = "tabPage67";
            this.tabPage67.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage67.Size = new System.Drawing.Size(442, 249);
            this.tabPage67.TabIndex = 0;
            this.tabPage67.Text = "Sources";
            this.tabPage67.UseVisualStyleBackColor = true;
            // 
            // tabControl21
            // 
            this.tabControl21.Controls.Add(this.tabPage78);
            this.tabControl21.Controls.Add(this.tabPage79);
            this.tabControl21.Controls.Add(this.tabPage80);
            this.tabControl21.Controls.Add(this.tabPage100);
            this.tabControl21.Location = new System.Drawing.Point(6, 6);
            this.tabControl21.Name = "tabControl21";
            this.tabControl21.SelectedIndex = 0;
            this.tabControl21.Size = new System.Drawing.Size(433, 240);
            this.tabControl21.TabIndex = 0;
            // 
            // tabPage78
            // 
            this.tabPage78.Controls.Add(this.btPIPAddDevice);
            this.tabPage78.Controls.Add(this.groupBox30);
            this.tabPage78.Controls.Add(this.cbPIPInput);
            this.tabPage78.Controls.Add(this.label170);
            this.tabPage78.Controls.Add(this.cbPIPFrameRate);
            this.tabPage78.Controls.Add(this.label128);
            this.tabPage78.Controls.Add(this.cbPIPFormatUseBest);
            this.tabPage78.Controls.Add(this.cbPIPFormat);
            this.tabPage78.Controls.Add(this.label127);
            this.tabPage78.Controls.Add(this.label126);
            this.tabPage78.Controls.Add(this.cbPIPDevice);
            this.tabPage78.Controls.Add(this.label125);
            this.tabPage78.Location = new System.Drawing.Point(4, 22);
            this.tabPage78.Name = "tabPage78";
            this.tabPage78.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage78.Size = new System.Drawing.Size(425, 214);
            this.tabPage78.TabIndex = 0;
            this.tabPage78.Text = "Video capture device";
            this.tabPage78.UseVisualStyleBackColor = true;
            // 
            // btPIPAddDevice
            // 
            this.btPIPAddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btPIPAddDevice.Location = new System.Drawing.Point(11, 180);
            this.btPIPAddDevice.Name = "btPIPAddDevice";
            this.btPIPAddDevice.Size = new System.Drawing.Size(54, 23);
            this.btPIPAddDevice.TabIndex = 63;
            this.btPIPAddDevice.Text = "Add";
            this.btPIPAddDevice.UseVisualStyleBackColor = true;
            this.btPIPAddDevice.Click += new System.EventHandler(this.btPIPAddDevice_Click);
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.edPIPVidCapHeight);
            this.groupBox30.Controls.Add(this.label94);
            this.groupBox30.Controls.Add(this.edPIPVidCapWidth);
            this.groupBox30.Controls.Add(this.label98);
            this.groupBox30.Controls.Add(this.edPIPVidCapTop);
            this.groupBox30.Controls.Add(this.label99);
            this.groupBox30.Controls.Add(this.edPIPVidCapLeft);
            this.groupBox30.Controls.Add(this.label100);
            this.groupBox30.Location = new System.Drawing.Point(215, 137);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(204, 71);
            this.groupBox30.TabIndex = 62;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Position";
            // 
            // edPIPVidCapHeight
            // 
            this.edPIPVidCapHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPVidCapHeight.Name = "edPIPVidCapHeight";
            this.edPIPVidCapHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPVidCapHeight.TabIndex = 40;
            this.edPIPVidCapHeight.Text = "200";
            this.edPIPVidCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(112, 48);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(38, 13);
            this.label94.TabIndex = 39;
            this.label94.Text = "Height";
            // 
            // edPIPVidCapWidth
            // 
            this.edPIPVidCapWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPVidCapWidth.Name = "edPIPVidCapWidth";
            this.edPIPVidCapWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPVidCapWidth.TabIndex = 38;
            this.edPIPVidCapWidth.Text = "300";
            this.edPIPVidCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(112, 22);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(35, 13);
            this.label98.TabIndex = 37;
            this.label98.Text = "Width";
            // 
            // edPIPVidCapTop
            // 
            this.edPIPVidCapTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPVidCapTop.Name = "edPIPVidCapTop";
            this.edPIPVidCapTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPVidCapTop.TabIndex = 36;
            this.edPIPVidCapTop.Text = "0";
            this.edPIPVidCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(15, 48);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(26, 13);
            this.label99.TabIndex = 35;
            this.label99.Text = "Top";
            // 
            // edPIPVidCapLeft
            // 
            this.edPIPVidCapLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPVidCapLeft.Name = "edPIPVidCapLeft";
            this.edPIPVidCapLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPVidCapLeft.TabIndex = 34;
            this.edPIPVidCapLeft.Text = "0";
            this.edPIPVidCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(15, 22);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(25, 13);
            this.label100.TabIndex = 33;
            this.label100.Text = "Left";
            // 
            // cbPIPInput
            // 
            this.cbPIPInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPInput.FormattingEnabled = true;
            this.cbPIPInput.Location = new System.Drawing.Point(85, 94);
            this.cbPIPInput.Name = "cbPIPInput";
            this.cbPIPInput.Size = new System.Drawing.Size(205, 21);
            this.cbPIPInput.TabIndex = 61;
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(8, 97);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(31, 13);
            this.label170.TabIndex = 60;
            this.label170.Text = "Input";
            // 
            // cbPIPFrameRate
            // 
            this.cbPIPFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPFrameRate.FormattingEnabled = true;
            this.cbPIPFrameRate.Location = new System.Drawing.Point(85, 121);
            this.cbPIPFrameRate.Name = "cbPIPFrameRate";
            this.cbPIPFrameRate.Size = new System.Drawing.Size(74, 21);
            this.cbPIPFrameRate.TabIndex = 59;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(8, 124);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(57, 13);
            this.label128.TabIndex = 58;
            this.label128.Text = "Frame rate";
            // 
            // cbPIPFormatUseBest
            // 
            this.cbPIPFormatUseBest.AutoSize = true;
            this.cbPIPFormatUseBest.Location = new System.Drawing.Point(296, 69);
            this.cbPIPFormatUseBest.Name = "cbPIPFormatUseBest";
            this.cbPIPFormatUseBest.Size = new System.Drawing.Size(68, 17);
            this.cbPIPFormatUseBest.TabIndex = 57;
            this.cbPIPFormatUseBest.Text = "Use best";
            this.cbPIPFormatUseBest.UseVisualStyleBackColor = true;
            this.cbPIPFormatUseBest.CheckedChanged += new System.EventHandler(this.cbPIPFormatUseBest_CheckedChanged);
            // 
            // cbPIPFormat
            // 
            this.cbPIPFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPFormat.FormattingEnabled = true;
            this.cbPIPFormat.Location = new System.Drawing.Point(85, 67);
            this.cbPIPFormat.Name = "cbPIPFormat";
            this.cbPIPFormat.Size = new System.Drawing.Size(205, 21);
            this.cbPIPFormat.TabIndex = 56;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(8, 70);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(66, 13);
            this.label127.TabIndex = 55;
            this.label127.Text = "Video format";
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(8, 12);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(184, 13);
            this.label126.TabIndex = 54;
            this.label126.Text = "Don\'t add main video capture device!";
            // 
            // cbPIPDevice
            // 
            this.cbPIPDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPDevice.FormattingEnabled = true;
            this.cbPIPDevice.Location = new System.Drawing.Point(85, 40);
            this.cbPIPDevice.Name = "cbPIPDevice";
            this.cbPIPDevice.Size = new System.Drawing.Size(205, 21);
            this.cbPIPDevice.TabIndex = 53;
            this.cbPIPDevice.SelectedIndexChanged += new System.EventHandler(this.cbPIPDevice_SelectedIndexChanged);
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(8, 43);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(70, 13);
            this.label125.TabIndex = 52;
            this.label125.Text = "Device name";
            // 
            // tabPage79
            // 
            this.tabPage79.Controls.Add(this.groupBox31);
            this.tabPage79.Controls.Add(this.btPIPAddIPCamera);
            this.tabPage79.Location = new System.Drawing.Point(4, 22);
            this.tabPage79.Name = "tabPage79";
            this.tabPage79.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage79.Size = new System.Drawing.Size(425, 214);
            this.tabPage79.TabIndex = 1;
            this.tabPage79.Text = "IP camera";
            this.tabPage79.UseVisualStyleBackColor = true;
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.edPIPIPCapHeight);
            this.groupBox31.Controls.Add(this.label101);
            this.groupBox31.Controls.Add(this.edPIPIPCapWidth);
            this.groupBox31.Controls.Add(this.label102);
            this.groupBox31.Controls.Add(this.edPIPIPCapTop);
            this.groupBox31.Controls.Add(this.label103);
            this.groupBox31.Controls.Add(this.edPIPIPCapLeft);
            this.groupBox31.Controls.Add(this.label229);
            this.groupBox31.Location = new System.Drawing.Point(215, 137);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(204, 71);
            this.groupBox31.TabIndex = 63;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Position";
            // 
            // edPIPIPCapHeight
            // 
            this.edPIPIPCapHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPIPCapHeight.Name = "edPIPIPCapHeight";
            this.edPIPIPCapHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPIPCapHeight.TabIndex = 40;
            this.edPIPIPCapHeight.Text = "200";
            this.edPIPIPCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(112, 48);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(38, 13);
            this.label101.TabIndex = 39;
            this.label101.Text = "Height";
            // 
            // edPIPIPCapWidth
            // 
            this.edPIPIPCapWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPIPCapWidth.Name = "edPIPIPCapWidth";
            this.edPIPIPCapWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPIPCapWidth.TabIndex = 38;
            this.edPIPIPCapWidth.Text = "300";
            this.edPIPIPCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(112, 22);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(35, 13);
            this.label102.TabIndex = 37;
            this.label102.Text = "Width";
            // 
            // edPIPIPCapTop
            // 
            this.edPIPIPCapTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPIPCapTop.Name = "edPIPIPCapTop";
            this.edPIPIPCapTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPIPCapTop.TabIndex = 36;
            this.edPIPIPCapTop.Text = "0";
            this.edPIPIPCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(15, 48);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(26, 13);
            this.label103.TabIndex = 35;
            this.label103.Text = "Top";
            // 
            // edPIPIPCapLeft
            // 
            this.edPIPIPCapLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPIPCapLeft.Name = "edPIPIPCapLeft";
            this.edPIPIPCapLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPIPCapLeft.TabIndex = 34;
            this.edPIPIPCapLeft.Text = "0";
            this.edPIPIPCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.Location = new System.Drawing.Point(15, 22);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(25, 13);
            this.label229.TabIndex = 33;
            this.label229.Text = "Left";
            // 
            // btPIPAddIPCamera
            // 
            this.btPIPAddIPCamera.Location = new System.Drawing.Point(101, 56);
            this.btPIPAddIPCamera.Name = "btPIPAddIPCamera";
            this.btPIPAddIPCamera.Size = new System.Drawing.Size(218, 23);
            this.btPIPAddIPCamera.TabIndex = 0;
            this.btPIPAddIPCamera.Text = "Add using settings from IP camera tab";
            this.btPIPAddIPCamera.UseVisualStyleBackColor = true;
            this.btPIPAddIPCamera.Click += new System.EventHandler(this.btPIPAddIPCamera_Click);
            // 
            // tabPage80
            // 
            this.tabPage80.Controls.Add(this.groupBox32);
            this.tabPage80.Controls.Add(this.btPIPAddScreenCapture);
            this.tabPage80.Location = new System.Drawing.Point(4, 22);
            this.tabPage80.Name = "tabPage80";
            this.tabPage80.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage80.Size = new System.Drawing.Size(425, 214);
            this.tabPage80.TabIndex = 2;
            this.tabPage80.Text = "Screen source";
            this.tabPage80.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.edPIPScreenCapHeight);
            this.groupBox32.Controls.Add(this.label256);
            this.groupBox32.Controls.Add(this.edPIPScreenCapWidth);
            this.groupBox32.Controls.Add(this.label260);
            this.groupBox32.Controls.Add(this.edPIPScreenCapTop);
            this.groupBox32.Controls.Add(this.label266);
            this.groupBox32.Controls.Add(this.edPIPScreenCapLeft);
            this.groupBox32.Controls.Add(this.label268);
            this.groupBox32.Location = new System.Drawing.Point(215, 137);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(204, 71);
            this.groupBox32.TabIndex = 63;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Position";
            // 
            // edPIPScreenCapHeight
            // 
            this.edPIPScreenCapHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPScreenCapHeight.Name = "edPIPScreenCapHeight";
            this.edPIPScreenCapHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPScreenCapHeight.TabIndex = 40;
            this.edPIPScreenCapHeight.Text = "200";
            this.edPIPScreenCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label256
            // 
            this.label256.AutoSize = true;
            this.label256.Location = new System.Drawing.Point(112, 48);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(38, 13);
            this.label256.TabIndex = 39;
            this.label256.Text = "Height";
            // 
            // edPIPScreenCapWidth
            // 
            this.edPIPScreenCapWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPScreenCapWidth.Name = "edPIPScreenCapWidth";
            this.edPIPScreenCapWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPScreenCapWidth.TabIndex = 38;
            this.edPIPScreenCapWidth.Text = "300";
            this.edPIPScreenCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label260
            // 
            this.label260.AutoSize = true;
            this.label260.Location = new System.Drawing.Point(112, 22);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(35, 13);
            this.label260.TabIndex = 37;
            this.label260.Text = "Width";
            // 
            // edPIPScreenCapTop
            // 
            this.edPIPScreenCapTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPScreenCapTop.Name = "edPIPScreenCapTop";
            this.edPIPScreenCapTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPScreenCapTop.TabIndex = 36;
            this.edPIPScreenCapTop.Text = "0";
            this.edPIPScreenCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Location = new System.Drawing.Point(15, 48);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(26, 13);
            this.label266.TabIndex = 35;
            this.label266.Text = "Top";
            // 
            // edPIPScreenCapLeft
            // 
            this.edPIPScreenCapLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPScreenCapLeft.Name = "edPIPScreenCapLeft";
            this.edPIPScreenCapLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPScreenCapLeft.TabIndex = 34;
            this.edPIPScreenCapLeft.Text = "0";
            this.edPIPScreenCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label268
            // 
            this.label268.AutoSize = true;
            this.label268.Location = new System.Drawing.Point(15, 22);
            this.label268.Name = "label268";
            this.label268.Size = new System.Drawing.Size(25, 13);
            this.label268.TabIndex = 33;
            this.label268.Text = "Left";
            // 
            // btPIPAddScreenCapture
            // 
            this.btPIPAddScreenCapture.Location = new System.Drawing.Point(101, 56);
            this.btPIPAddScreenCapture.Name = "btPIPAddScreenCapture";
            this.btPIPAddScreenCapture.Size = new System.Drawing.Size(218, 23);
            this.btPIPAddScreenCapture.TabIndex = 1;
            this.btPIPAddScreenCapture.Text = "Add using settings from Screen source tab";
            this.btPIPAddScreenCapture.UseVisualStyleBackColor = true;
            this.btPIPAddScreenCapture.Click += new System.EventHandler(this.btPIPAddScreenCapture_Click);
            // 
            // tabPage100
            // 
            this.tabPage100.Controls.Add(this.groupBox44);
            this.tabPage100.Controls.Add(this.btPIPFileSourceAdd);
            this.tabPage100.Controls.Add(this.btSelectPIPFile);
            this.tabPage100.Controls.Add(this.edPIPFileSoureFilename);
            this.tabPage100.Controls.Add(this.label320);
            this.tabPage100.Location = new System.Drawing.Point(4, 22);
            this.tabPage100.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage100.Name = "tabPage100";
            this.tabPage100.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage100.Size = new System.Drawing.Size(425, 214);
            this.tabPage100.TabIndex = 3;
            this.tabPage100.Text = "Video file";
            this.tabPage100.UseVisualStyleBackColor = true;
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.edPIPFileHeight);
            this.groupBox44.Controls.Add(this.label321);
            this.groupBox44.Controls.Add(this.edPIPFileWidth);
            this.groupBox44.Controls.Add(this.label322);
            this.groupBox44.Controls.Add(this.edPIPFileTop);
            this.groupBox44.Controls.Add(this.label323);
            this.groupBox44.Controls.Add(this.edPIPFileLeft);
            this.groupBox44.Controls.Add(this.label324);
            this.groupBox44.Location = new System.Drawing.Point(218, 140);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(204, 71);
            this.groupBox44.TabIndex = 64;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Position";
            // 
            // edPIPFileHeight
            // 
            this.edPIPFileHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPFileHeight.Name = "edPIPFileHeight";
            this.edPIPFileHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileHeight.TabIndex = 40;
            this.edPIPFileHeight.Text = "200";
            this.edPIPFileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label321
            // 
            this.label321.AutoSize = true;
            this.label321.Location = new System.Drawing.Point(112, 48);
            this.label321.Name = "label321";
            this.label321.Size = new System.Drawing.Size(38, 13);
            this.label321.TabIndex = 39;
            this.label321.Text = "Height";
            // 
            // edPIPFileWidth
            // 
            this.edPIPFileWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPFileWidth.Name = "edPIPFileWidth";
            this.edPIPFileWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileWidth.TabIndex = 38;
            this.edPIPFileWidth.Text = "300";
            this.edPIPFileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label322
            // 
            this.label322.AutoSize = true;
            this.label322.Location = new System.Drawing.Point(112, 22);
            this.label322.Name = "label322";
            this.label322.Size = new System.Drawing.Size(35, 13);
            this.label322.TabIndex = 37;
            this.label322.Text = "Width";
            // 
            // edPIPFileTop
            // 
            this.edPIPFileTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPFileTop.Name = "edPIPFileTop";
            this.edPIPFileTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileTop.TabIndex = 36;
            this.edPIPFileTop.Text = "0";
            this.edPIPFileTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label323
            // 
            this.label323.AutoSize = true;
            this.label323.Location = new System.Drawing.Point(15, 48);
            this.label323.Name = "label323";
            this.label323.Size = new System.Drawing.Size(26, 13);
            this.label323.TabIndex = 35;
            this.label323.Text = "Top";
            // 
            // edPIPFileLeft
            // 
            this.edPIPFileLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPFileLeft.Name = "edPIPFileLeft";
            this.edPIPFileLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileLeft.TabIndex = 34;
            this.edPIPFileLeft.Text = "0";
            this.edPIPFileLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label324
            // 
            this.label324.AutoSize = true;
            this.label324.Location = new System.Drawing.Point(15, 22);
            this.label324.Name = "label324";
            this.label324.Size = new System.Drawing.Size(25, 13);
            this.label324.TabIndex = 33;
            this.label324.Text = "Left";
            // 
            // btPIPFileSourceAdd
            // 
            this.btPIPFileSourceAdd.Location = new System.Drawing.Point(307, 32);
            this.btPIPFileSourceAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btPIPFileSourceAdd.Name = "btPIPFileSourceAdd";
            this.btPIPFileSourceAdd.Size = new System.Drawing.Size(56, 22);
            this.btPIPFileSourceAdd.TabIndex = 3;
            this.btPIPFileSourceAdd.Text = "Add";
            this.btPIPFileSourceAdd.UseVisualStyleBackColor = true;
            this.btPIPFileSourceAdd.Click += new System.EventHandler(this.btPIPFileSourceAdd_Click);
            // 
            // btSelectPIPFile
            // 
            this.btSelectPIPFile.Location = new System.Drawing.Point(280, 32);
            this.btSelectPIPFile.Margin = new System.Windows.Forms.Padding(2);
            this.btSelectPIPFile.Name = "btSelectPIPFile";
            this.btSelectPIPFile.Size = new System.Drawing.Size(22, 22);
            this.btSelectPIPFile.TabIndex = 2;
            this.btSelectPIPFile.Text = "...";
            this.btSelectPIPFile.UseVisualStyleBackColor = true;
            this.btSelectPIPFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // edPIPFileSoureFilename
            // 
            this.edPIPFileSoureFilename.Location = new System.Drawing.Point(15, 34);
            this.edPIPFileSoureFilename.Margin = new System.Windows.Forms.Padding(2);
            this.edPIPFileSoureFilename.Name = "edPIPFileSoureFilename";
            this.edPIPFileSoureFilename.Size = new System.Drawing.Size(261, 20);
            this.edPIPFileSoureFilename.TabIndex = 1;
            // 
            // label320
            // 
            this.label320.AutoSize = true;
            this.label320.Location = new System.Drawing.Point(13, 18);
            this.label320.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label320.Name = "label320";
            this.label320.Size = new System.Drawing.Size(52, 13);
            this.label320.TabIndex = 0;
            this.label320.Text = "File name";
            // 
            // tabPage77
            // 
            this.tabPage77.Controls.Add(this.cbPIPResizeMode);
            this.tabPage77.Controls.Add(this.label317);
            this.tabPage77.Controls.Add(this.groupBox34);
            this.tabPage77.Controls.Add(this.groupBox33);
            this.tabPage77.Controls.Add(this.cbPIPDevices);
            this.tabPage77.Controls.Add(this.cbPIPMode);
            this.tabPage77.Controls.Add(this.label169);
            this.tabPage77.Controls.Add(this.btPIPDevicesClear);
            this.tabPage77.Controls.Add(this.label134);
            this.tabPage77.Controls.Add(this.groupBox20);
            this.tabPage77.Location = new System.Drawing.Point(4, 22);
            this.tabPage77.Name = "tabPage77";
            this.tabPage77.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage77.Size = new System.Drawing.Size(442, 249);
            this.tabPage77.TabIndex = 1;
            this.tabPage77.Text = "Configuration";
            this.tabPage77.UseVisualStyleBackColor = true;
            // 
            // cbPIPResizeMode
            // 
            this.cbPIPResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPResizeMode.FormattingEnabled = true;
            this.cbPIPResizeMode.Items.AddRange(new object[] {
            "Nearest neighbor",
            "Linear",
            "Cubic",
            "Lanczos"});
            this.cbPIPResizeMode.Location = new System.Drawing.Point(232, 193);
            this.cbPIPResizeMode.Name = "cbPIPResizeMode";
            this.cbPIPResizeMode.Size = new System.Drawing.Size(189, 21);
            this.cbPIPResizeMode.TabIndex = 54;
            // 
            // label317
            // 
            this.label317.AutoSize = true;
            this.label317.Location = new System.Drawing.Point(229, 173);
            this.label317.Name = "label317";
            this.label317.Size = new System.Drawing.Size(62, 13);
            this.label317.TabIndex = 53;
            this.label317.Text = "Resize type";
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.btPIPSet);
            this.groupBox34.Controls.Add(this.tbPIPTransparency);
            this.groupBox34.Location = new System.Drawing.Point(18, 170);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(204, 73);
            this.groupBox34.TabIndex = 52;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Source transparency";
            // 
            // btPIPSet
            // 
            this.btPIPSet.Location = new System.Drawing.Point(150, 28);
            this.btPIPSet.Name = "btPIPSet";
            this.btPIPSet.Size = new System.Drawing.Size(48, 23);
            this.btPIPSet.TabIndex = 1;
            this.btPIPSet.Text = "Set";
            this.btPIPSet.UseVisualStyleBackColor = true;
            this.btPIPSet.Click += new System.EventHandler(this.btPIPSet_Click);
            // 
            // tbPIPTransparency
            // 
            this.tbPIPTransparency.Location = new System.Drawing.Point(11, 19);
            this.tbPIPTransparency.Maximum = 255;
            this.tbPIPTransparency.Name = "tbPIPTransparency";
            this.tbPIPTransparency.Size = new System.Drawing.Size(123, 45);
            this.tbPIPTransparency.TabIndex = 0;
            this.tbPIPTransparency.Value = 255;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.btPIPSetOutputSize);
            this.groupBox33.Controls.Add(this.edPIPOutputHeight);
            this.groupBox33.Controls.Add(this.label269);
            this.groupBox33.Controls.Add(this.edPIPOutputWidth);
            this.groupBox33.Controls.Add(this.label271);
            this.groupBox33.Location = new System.Drawing.Point(232, 70);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(204, 100);
            this.groupBox33.TabIndex = 51;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Set custom output size";
            // 
            // btPIPSetOutputSize
            // 
            this.btPIPSetOutputSize.Location = new System.Drawing.Point(60, 71);
            this.btPIPSetOutputSize.Name = "btPIPSetOutputSize";
            this.btPIPSetOutputSize.Size = new System.Drawing.Size(74, 23);
            this.btPIPSetOutputSize.TabIndex = 41;
            this.btPIPSetOutputSize.Text = "Set";
            this.btPIPSetOutputSize.UseVisualStyleBackColor = true;
            this.btPIPSetOutputSize.Click += new System.EventHandler(this.btPIPSetOutputSize_Click);
            // 
            // edPIPOutputHeight
            // 
            this.edPIPOutputHeight.Location = new System.Drawing.Point(150, 19);
            this.edPIPOutputHeight.Name = "edPIPOutputHeight";
            this.edPIPOutputHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPOutputHeight.TabIndex = 38;
            this.edPIPOutputHeight.Text = "600";
            this.edPIPOutputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label269
            // 
            this.label269.AutoSize = true;
            this.label269.Location = new System.Drawing.Point(112, 22);
            this.label269.Name = "label269";
            this.label269.Size = new System.Drawing.Size(38, 13);
            this.label269.TabIndex = 37;
            this.label269.Text = "Height";
            // 
            // edPIPOutputWidth
            // 
            this.edPIPOutputWidth.Location = new System.Drawing.Point(48, 19);
            this.edPIPOutputWidth.Name = "edPIPOutputWidth";
            this.edPIPOutputWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPOutputWidth.TabIndex = 34;
            this.edPIPOutputWidth.Text = "800";
            this.edPIPOutputWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label271
            // 
            this.label271.AutoSize = true;
            this.label271.Location = new System.Drawing.Point(15, 22);
            this.label271.Name = "label271";
            this.label271.Size = new System.Drawing.Size(35, 13);
            this.label271.TabIndex = 33;
            this.label271.Text = "Width";
            // 
            // cbPIPDevices
            // 
            this.cbPIPDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPDevices.FormattingEnabled = true;
            this.cbPIPDevices.Location = new System.Drawing.Point(66, 37);
            this.cbPIPDevices.Name = "cbPIPDevices";
            this.cbPIPDevices.Size = new System.Drawing.Size(245, 21);
            this.cbPIPDevices.TabIndex = 50;
            // 
            // cbPIPMode
            // 
            this.cbPIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPIPMode.FormattingEnabled = true;
            this.cbPIPMode.Items.AddRange(new object[] {
            "Custom (Specify coordinates for each device)",
            "Horizontal",
            "Vertical",
            "2x2",
            "Multiple video streams (Use WMV, external profile for multiple video streams)",
            "Chroma-key"});
            this.cbPIPMode.Location = new System.Drawing.Point(66, 7);
            this.cbPIPMode.Name = "cbPIPMode";
            this.cbPIPMode.Size = new System.Drawing.Size(370, 21);
            this.cbPIPMode.TabIndex = 49;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(8, 10);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(34, 13);
            this.label169.TabIndex = 48;
            this.label169.Text = "Mode";
            // 
            // btPIPDevicesClear
            // 
            this.btPIPDevicesClear.Location = new System.Drawing.Point(317, 37);
            this.btPIPDevicesClear.Name = "btPIPDevicesClear";
            this.btPIPDevicesClear.Size = new System.Drawing.Size(59, 23);
            this.btPIPDevicesClear.TabIndex = 46;
            this.btPIPDevicesClear.Text = "Clear";
            this.btPIPDevicesClear.UseVisualStyleBackColor = true;
            this.btPIPDevicesClear.Click += new System.EventHandler(this.btPIPDevicesClear_Click);
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(8, 40);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(46, 13);
            this.label134.TabIndex = 43;
            this.label134.Text = "Devices";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.btPIPUpdate);
            this.groupBox20.Controls.Add(this.edPIPHeight);
            this.groupBox20.Controls.Add(this.label132);
            this.groupBox20.Controls.Add(this.edPIPWidth);
            this.groupBox20.Controls.Add(this.label133);
            this.groupBox20.Controls.Add(this.edPIPTop);
            this.groupBox20.Controls.Add(this.label130);
            this.groupBox20.Controls.Add(this.edPIPLeft);
            this.groupBox20.Controls.Add(this.label131);
            this.groupBox20.Location = new System.Drawing.Point(18, 70);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(204, 100);
            this.groupBox20.TabIndex = 42;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Position";
            // 
            // btPIPUpdate
            // 
            this.btPIPUpdate.Location = new System.Drawing.Point(60, 71);
            this.btPIPUpdate.Name = "btPIPUpdate";
            this.btPIPUpdate.Size = new System.Drawing.Size(74, 23);
            this.btPIPUpdate.TabIndex = 41;
            this.btPIPUpdate.Text = "Update";
            this.btPIPUpdate.UseVisualStyleBackColor = true;
            this.btPIPUpdate.Click += new System.EventHandler(this.btPIPUpdate_Click);
            // 
            // edPIPHeight
            // 
            this.edPIPHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPHeight.Name = "edPIPHeight";
            this.edPIPHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPHeight.TabIndex = 40;
            this.edPIPHeight.Text = "200";
            this.edPIPHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(112, 48);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(38, 13);
            this.label132.TabIndex = 39;
            this.label132.Text = "Height";
            // 
            // edPIPWidth
            // 
            this.edPIPWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPWidth.Name = "edPIPWidth";
            this.edPIPWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPWidth.TabIndex = 38;
            this.edPIPWidth.Text = "300";
            this.edPIPWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(112, 22);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(35, 13);
            this.label133.TabIndex = 37;
            this.label133.Text = "Width";
            // 
            // edPIPTop
            // 
            this.edPIPTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPTop.Name = "edPIPTop";
            this.edPIPTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPTop.TabIndex = 36;
            this.edPIPTop.Text = "0";
            this.edPIPTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(15, 48);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(26, 13);
            this.label130.TabIndex = 35;
            this.label130.Text = "Top";
            // 
            // edPIPLeft
            // 
            this.edPIPLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPLeft.Name = "edPIPLeft";
            this.edPIPLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPLeft.TabIndex = 34;
            this.edPIPLeft.Text = "0";
            this.edPIPLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(15, 22);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(25, 13);
            this.label131.TabIndex = 33;
            this.label131.Text = "Left";
            // 
            // tabPage147
            // 
            this.tabPage147.Controls.Add(this.lbPIPChromaKeyTolerance2);
            this.tabPage147.Controls.Add(this.label518);
            this.tabPage147.Controls.Add(this.tbPIPChromaKeyTolerance2);
            this.tabPage147.Controls.Add(this.lbPIPChromaKeyTolerance1);
            this.tabPage147.Controls.Add(this.label515);
            this.tabPage147.Controls.Add(this.tbPIPChromaKeyTolerance1);
            this.tabPage147.Controls.Add(this.pnPIPChromaKeyColor);
            this.tabPage147.Controls.Add(this.label514);
            this.tabPage147.Location = new System.Drawing.Point(4, 22);
            this.tabPage147.Name = "tabPage147";
            this.tabPage147.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage147.Size = new System.Drawing.Size(442, 249);
            this.tabPage147.TabIndex = 2;
            this.tabPage147.Text = "Chroma-key";
            this.tabPage147.UseVisualStyleBackColor = true;
            // 
            // lbPIPChromaKeyTolerance2
            // 
            this.lbPIPChromaKeyTolerance2.AutoSize = true;
            this.lbPIPChromaKeyTolerance2.Location = new System.Drawing.Point(383, 87);
            this.lbPIPChromaKeyTolerance2.Name = "lbPIPChromaKeyTolerance2";
            this.lbPIPChromaKeyTolerance2.Size = new System.Drawing.Size(19, 13);
            this.lbPIPChromaKeyTolerance2.TabIndex = 35;
            this.lbPIPChromaKeyTolerance2.Text = "30";
            // 
            // label518
            // 
            this.label518.AutoSize = true;
            this.label518.Location = new System.Drawing.Point(253, 56);
            this.label518.Name = "label518";
            this.label518.Size = new System.Drawing.Size(64, 13);
            this.label518.TabIndex = 34;
            this.label518.Text = "Tolerance 2";
            // 
            // tbPIPChromaKeyTolerance2
            // 
            this.tbPIPChromaKeyTolerance2.Location = new System.Drawing.Point(256, 72);
            this.tbPIPChromaKeyTolerance2.Maximum = 100;
            this.tbPIPChromaKeyTolerance2.Minimum = 5;
            this.tbPIPChromaKeyTolerance2.Name = "tbPIPChromaKeyTolerance2";
            this.tbPIPChromaKeyTolerance2.Size = new System.Drawing.Size(110, 45);
            this.tbPIPChromaKeyTolerance2.TabIndex = 33;
            this.tbPIPChromaKeyTolerance2.TickFrequency = 3;
            this.tbPIPChromaKeyTolerance2.Value = 30;
            this.tbPIPChromaKeyTolerance2.Scroll += new System.EventHandler(this.tbPIPChromaKeyTolerance2_Scroll);
            // 
            // lbPIPChromaKeyTolerance1
            // 
            this.lbPIPChromaKeyTolerance1.AutoSize = true;
            this.lbPIPChromaKeyTolerance1.Location = new System.Drawing.Point(150, 87);
            this.lbPIPChromaKeyTolerance1.Name = "lbPIPChromaKeyTolerance1";
            this.lbPIPChromaKeyTolerance1.Size = new System.Drawing.Size(19, 13);
            this.lbPIPChromaKeyTolerance1.TabIndex = 32;
            this.lbPIPChromaKeyTolerance1.Text = "10";
            // 
            // label515
            // 
            this.label515.AutoSize = true;
            this.label515.Location = new System.Drawing.Point(20, 56);
            this.label515.Name = "label515";
            this.label515.Size = new System.Drawing.Size(64, 13);
            this.label515.TabIndex = 31;
            this.label515.Text = "Tolerance 1";
            // 
            // tbPIPChromaKeyTolerance1
            // 
            this.tbPIPChromaKeyTolerance1.Location = new System.Drawing.Point(23, 72);
            this.tbPIPChromaKeyTolerance1.Maximum = 100;
            this.tbPIPChromaKeyTolerance1.Minimum = 5;
            this.tbPIPChromaKeyTolerance1.Name = "tbPIPChromaKeyTolerance1";
            this.tbPIPChromaKeyTolerance1.Size = new System.Drawing.Size(110, 45);
            this.tbPIPChromaKeyTolerance1.TabIndex = 30;
            this.tbPIPChromaKeyTolerance1.TickFrequency = 3;
            this.tbPIPChromaKeyTolerance1.Value = 10;
            this.tbPIPChromaKeyTolerance1.Scroll += new System.EventHandler(this.tbPIPChromaKeyTolerance1_Scroll);
            // 
            // pnPIPChromaKeyColor
            // 
            this.pnPIPChromaKeyColor.BackColor = System.Drawing.Color.ForestGreen;
            this.pnPIPChromaKeyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPIPChromaKeyColor.Location = new System.Drawing.Point(153, 20);
            this.pnPIPChromaKeyColor.Name = "pnPIPChromaKeyColor";
            this.pnPIPChromaKeyColor.Size = new System.Drawing.Size(24, 24);
            this.pnPIPChromaKeyColor.TabIndex = 29;
            this.pnPIPChromaKeyColor.Click += new System.EventHandler(this.pnPIPChromaKeyColor_Click);
            // 
            // label514
            // 
            this.label514.AutoSize = true;
            this.label514.Location = new System.Drawing.Point(19, 23);
            this.label514.Name = "label514";
            this.label514.Size = new System.Drawing.Size(105, 13);
            this.label514.TabIndex = 28;
            this.label514.Text = "Color (click to select)";
            // 
            // tabPage50
            // 
            this.tabPage50.Controls.Add(this.cbMultiscreenDrawOnExternalDisplays);
            this.tabPage50.Controls.Add(this.cbFlipHorizontal3);
            this.tabPage50.Controls.Add(this.cbFlipVertical3);
            this.tabPage50.Controls.Add(this.cbStretch3);
            this.tabPage50.Controls.Add(this.cbFlipHorizontal2);
            this.tabPage50.Controls.Add(this.cbFlipVertical2);
            this.tabPage50.Controls.Add(this.cbStretch2);
            this.tabPage50.Controls.Add(this.cbFlipHorizontal1);
            this.tabPage50.Controls.Add(this.cbFlipVertical1);
            this.tabPage50.Controls.Add(this.cbStretch1);
            this.tabPage50.Controls.Add(this.pnScreen3);
            this.tabPage50.Controls.Add(this.panel3);
            this.tabPage50.Controls.Add(this.pnScreen2);
            this.tabPage50.Controls.Add(this.panel2);
            this.tabPage50.Controls.Add(this.pnScreen1);
            this.tabPage50.Controls.Add(this.cbMultiscreenDrawOnPanels);
            this.tabPage50.Location = new System.Drawing.Point(4, 22);
            this.tabPage50.Name = "tabPage50";
            this.tabPage50.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage50.Size = new System.Drawing.Size(459, 285);
            this.tabPage50.TabIndex = 4;
            this.tabPage50.Text = "Multiscreen";
            this.tabPage50.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnExternalDisplays
            // 
            this.cbMultiscreenDrawOnExternalDisplays.AutoSize = true;
            this.cbMultiscreenDrawOnExternalDisplays.Location = new System.Drawing.Point(180, 17);
            this.cbMultiscreenDrawOnExternalDisplays.Name = "cbMultiscreenDrawOnExternalDisplays";
            this.cbMultiscreenDrawOnExternalDisplays.Size = new System.Drawing.Size(175, 17);
            this.cbMultiscreenDrawOnExternalDisplays.TabIndex = 15;
            this.cbMultiscreenDrawOnExternalDisplays.Text = "Draw video on external displays";
            this.cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = true;
            // 
            // cbFlipHorizontal3
            // 
            this.cbFlipHorizontal3.AutoSize = true;
            this.cbFlipHorizontal3.Location = new System.Drawing.Point(341, 107);
            this.cbFlipHorizontal3.Name = "cbFlipHorizontal3";
            this.cbFlipHorizontal3.Size = new System.Drawing.Size(90, 17);
            this.cbFlipHorizontal3.TabIndex = 14;
            this.cbFlipHorizontal3.Text = "Flip horizontal";
            this.cbFlipHorizontal3.UseVisualStyleBackColor = true;
            this.cbFlipHorizontal3.CheckedChanged += new System.EventHandler(this.cbFlipHorizontal3_CheckedChanged);
            // 
            // cbFlipVertical3
            // 
            this.cbFlipVertical3.AutoSize = true;
            this.cbFlipVertical3.Location = new System.Drawing.Point(341, 84);
            this.cbFlipVertical3.Name = "cbFlipVertical3";
            this.cbFlipVertical3.Size = new System.Drawing.Size(79, 17);
            this.cbFlipVertical3.TabIndex = 13;
            this.cbFlipVertical3.Text = "Flip vertical";
            this.cbFlipVertical3.UseVisualStyleBackColor = true;
            this.cbFlipVertical3.CheckedChanged += new System.EventHandler(this.cbFlipVertical3_CheckedChanged);
            // 
            // cbStretch3
            // 
            this.cbStretch3.AutoSize = true;
            this.cbStretch3.Location = new System.Drawing.Point(341, 61);
            this.cbStretch3.Name = "cbStretch3";
            this.cbStretch3.Size = new System.Drawing.Size(60, 17);
            this.cbStretch3.TabIndex = 12;
            this.cbStretch3.Text = "Stretch";
            this.cbStretch3.UseVisualStyleBackColor = true;
            this.cbStretch3.CheckedChanged += new System.EventHandler(this.cbStretch3_CheckedChanged);
            // 
            // cbFlipHorizontal2
            // 
            this.cbFlipHorizontal2.AutoSize = true;
            this.cbFlipHorizontal2.Location = new System.Drawing.Point(224, 215);
            this.cbFlipHorizontal2.Name = "cbFlipHorizontal2";
            this.cbFlipHorizontal2.Size = new System.Drawing.Size(90, 17);
            this.cbFlipHorizontal2.TabIndex = 11;
            this.cbFlipHorizontal2.Text = "Flip horizontal";
            this.cbFlipHorizontal2.UseVisualStyleBackColor = true;
            this.cbFlipHorizontal2.CheckedChanged += new System.EventHandler(this.cbFlipHorizontal2_CheckedChanged);
            // 
            // cbFlipVertical2
            // 
            this.cbFlipVertical2.AutoSize = true;
            this.cbFlipVertical2.Location = new System.Drawing.Point(224, 195);
            this.cbFlipVertical2.Name = "cbFlipVertical2";
            this.cbFlipVertical2.Size = new System.Drawing.Size(79, 17);
            this.cbFlipVertical2.TabIndex = 10;
            this.cbFlipVertical2.Text = "Flip vertical";
            this.cbFlipVertical2.UseVisualStyleBackColor = true;
            this.cbFlipVertical2.CheckedChanged += new System.EventHandler(this.cbFlipVertical2_CheckedChanged);
            // 
            // cbStretch2
            // 
            this.cbStretch2.AutoSize = true;
            this.cbStretch2.Location = new System.Drawing.Point(147, 195);
            this.cbStretch2.Name = "cbStretch2";
            this.cbStretch2.Size = new System.Drawing.Size(60, 17);
            this.cbStretch2.TabIndex = 9;
            this.cbStretch2.Text = "Stretch";
            this.cbStretch2.UseVisualStyleBackColor = true;
            this.cbStretch2.CheckedChanged += new System.EventHandler(this.cbStretch2_CheckedChanged);
            // 
            // cbFlipHorizontal1
            // 
            this.cbFlipHorizontal1.AutoSize = true;
            this.cbFlipHorizontal1.Location = new System.Drawing.Point(18, 192);
            this.cbFlipHorizontal1.Name = "cbFlipHorizontal1";
            this.cbFlipHorizontal1.Size = new System.Drawing.Size(90, 17);
            this.cbFlipHorizontal1.TabIndex = 8;
            this.cbFlipHorizontal1.Text = "Flip horizontal";
            this.cbFlipHorizontal1.UseVisualStyleBackColor = true;
            this.cbFlipHorizontal1.CheckedChanged += new System.EventHandler(this.cbFlipHorizontal1_CheckedChanged);
            // 
            // cbFlipVertical1
            // 
            this.cbFlipVertical1.AutoSize = true;
            this.cbFlipVertical1.Location = new System.Drawing.Point(18, 169);
            this.cbFlipVertical1.Name = "cbFlipVertical1";
            this.cbFlipVertical1.Size = new System.Drawing.Size(79, 17);
            this.cbFlipVertical1.TabIndex = 7;
            this.cbFlipVertical1.Text = "Flip vertical";
            this.cbFlipVertical1.UseVisualStyleBackColor = true;
            this.cbFlipVertical1.CheckedChanged += new System.EventHandler(this.cbFlipVertical1_CheckedChanged);
            // 
            // cbStretch1
            // 
            this.cbStretch1.AutoSize = true;
            this.cbStretch1.Location = new System.Drawing.Point(18, 146);
            this.cbStretch1.Name = "cbStretch1";
            this.cbStretch1.Size = new System.Drawing.Size(60, 17);
            this.cbStretch1.TabIndex = 6;
            this.cbStretch1.Text = "Stretch";
            this.cbStretch1.UseVisualStyleBackColor = true;
            this.cbStretch1.CheckedChanged += new System.EventHandler(this.cbStretch1_CheckedChanged);
            // 
            // pnScreen3
            // 
            this.pnScreen3.BackColor = System.Drawing.Color.Black;
            this.pnScreen3.Location = new System.Drawing.Point(332, 132);
            this.pnScreen3.Name = "pnScreen3";
            this.pnScreen3.Size = new System.Drawing.Size(120, 100);
            this.pnScreen3.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(326, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 196);
            this.panel3.TabIndex = 4;
            // 
            // pnScreen2
            // 
            this.pnScreen2.BackColor = System.Drawing.Color.Black;
            this.pnScreen2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnScreen2.Location = new System.Drawing.Point(147, 40);
            this.pnScreen2.Name = "pnScreen2";
            this.pnScreen2.Size = new System.Drawing.Size(176, 149);
            this.pnScreen2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(141, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 197);
            this.panel2.TabIndex = 2;
            // 
            // pnScreen1
            // 
            this.pnScreen1.BackColor = System.Drawing.Color.Black;
            this.pnScreen1.Location = new System.Drawing.Point(18, 40);
            this.pnScreen1.Name = "pnScreen1";
            this.pnScreen1.Size = new System.Drawing.Size(120, 100);
            this.pnScreen1.TabIndex = 1;
            // 
            // cbMultiscreenDrawOnPanels
            // 
            this.cbMultiscreenDrawOnPanels.AutoSize = true;
            this.cbMultiscreenDrawOnPanels.Location = new System.Drawing.Point(18, 17);
            this.cbMultiscreenDrawOnPanels.Name = "cbMultiscreenDrawOnPanels";
            this.cbMultiscreenDrawOnPanels.Size = new System.Drawing.Size(129, 17);
            this.cbMultiscreenDrawOnPanels.TabIndex = 0;
            this.cbMultiscreenDrawOnPanels.Text = "Draw video on panels";
            this.cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = true;
            // 
            // tabPage51
            // 
            this.tabPage51.Controls.Add(this.tabControl26);
            this.tabPage51.Location = new System.Drawing.Point(4, 22);
            this.tabPage51.Name = "tabPage51";
            this.tabPage51.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage51.Size = new System.Drawing.Size(459, 285);
            this.tabPage51.TabIndex = 5;
            this.tabPage51.Text = "Display";
            this.tabPage51.UseVisualStyleBackColor = true;
            // 
            // tabControl26
            // 
            this.tabControl26.Controls.Add(this.tabPage115);
            this.tabControl26.Controls.Add(this.tabPage116);
            this.tabControl26.Location = new System.Drawing.Point(4, 7);
            this.tabControl26.Name = "tabControl26";
            this.tabControl26.SelectedIndex = 0;
            this.tabControl26.Size = new System.Drawing.Size(452, 275);
            this.tabControl26.TabIndex = 0;
            // 
            // tabPage115
            // 
            this.tabPage115.Controls.Add(this.pnVideoRendererBGColor);
            this.tabPage115.Controls.Add(this.label394);
            this.tabPage115.Controls.Add(this.btFullScreen);
            this.tabPage115.Controls.Add(this.groupBox28);
            this.tabPage115.Controls.Add(this.cbScreenFlipVertical);
            this.tabPage115.Controls.Add(this.cbScreenFlipHorizontal);
            this.tabPage115.Controls.Add(this.cbStretch);
            this.tabPage115.Controls.Add(this.groupBox13);
            this.tabPage115.Location = new System.Drawing.Point(4, 22);
            this.tabPage115.Name = "tabPage115";
            this.tabPage115.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage115.Size = new System.Drawing.Size(444, 249);
            this.tabPage115.TabIndex = 0;
            this.tabPage115.Text = "Main";
            this.tabPage115.UseVisualStyleBackColor = true;
            // 
            // pnVideoRendererBGColor
            // 
            this.pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black;
            this.pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnVideoRendererBGColor.Location = new System.Drawing.Point(120, 168);
            this.pnVideoRendererBGColor.Name = "pnVideoRendererBGColor";
            this.pnVideoRendererBGColor.Size = new System.Drawing.Size(24, 24);
            this.pnVideoRendererBGColor.TabIndex = 28;
            this.pnVideoRendererBGColor.Click += new System.EventHandler(this.pnVideoRendererBGColor_Click);
            // 
            // label394
            // 
            this.label394.AutoSize = true;
            this.label394.Location = new System.Drawing.Point(13, 173);
            this.label394.Name = "label394";
            this.label394.Size = new System.Drawing.Size(91, 13);
            this.label394.TabIndex = 27;
            this.label394.Text = "Background color";
            // 
            // btFullScreen
            // 
            this.btFullScreen.Location = new System.Drawing.Point(164, 168);
            this.btFullScreen.Name = "btFullScreen";
            this.btFullScreen.Size = new System.Drawing.Size(119, 23);
            this.btFullScreen.TabIndex = 26;
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
            this.groupBox28.Location = new System.Drawing.Point(299, 99);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(119, 129);
            this.groupBox28.TabIndex = 25;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Zoom";
            // 
            // btZoomReset
            // 
            this.btZoomReset.Location = new System.Drawing.Point(34, 98);
            this.btZoomReset.Name = "btZoomReset";
            this.btZoomReset.Size = new System.Drawing.Size(51, 23);
            this.btZoomReset.TabIndex = 7;
            this.btZoomReset.Text = "Reset";
            this.btZoomReset.UseVisualStyleBackColor = true;
            this.btZoomReset.Click += new System.EventHandler(this.btZoomReset_Click);
            // 
            // btZoomShiftRight
            // 
            this.btZoomShiftRight.Location = new System.Drawing.Point(85, 33);
            this.btZoomShiftRight.Name = "btZoomShiftRight";
            this.btZoomShiftRight.Size = new System.Drawing.Size(21, 48);
            this.btZoomShiftRight.TabIndex = 5;
            this.btZoomShiftRight.Text = "R";
            this.btZoomShiftRight.UseVisualStyleBackColor = true;
            this.btZoomShiftRight.Click += new System.EventHandler(this.btZoomShiftRight_Click);
            // 
            // btZoomShiftLeft
            // 
            this.btZoomShiftLeft.Location = new System.Drawing.Point(13, 32);
            this.btZoomShiftLeft.Name = "btZoomShiftLeft";
            this.btZoomShiftLeft.Size = new System.Drawing.Size(21, 48);
            this.btZoomShiftLeft.TabIndex = 4;
            this.btZoomShiftLeft.Text = "L";
            this.btZoomShiftLeft.UseVisualStyleBackColor = true;
            this.btZoomShiftLeft.Click += new System.EventHandler(this.btZoomShiftLeft_Click);
            // 
            // btZoomOut
            // 
            this.btZoomOut.Location = new System.Drawing.Point(61, 45);
            this.btZoomOut.Name = "btZoomOut";
            this.btZoomOut.Size = new System.Drawing.Size(23, 23);
            this.btZoomOut.TabIndex = 3;
            this.btZoomOut.Text = "-";
            this.btZoomOut.UseVisualStyleBackColor = true;
            this.btZoomOut.Click += new System.EventHandler(this.btZoomOut_Click);
            // 
            // btZoomIn
            // 
            this.btZoomIn.Location = new System.Drawing.Point(35, 45);
            this.btZoomIn.Name = "btZoomIn";
            this.btZoomIn.Size = new System.Drawing.Size(22, 23);
            this.btZoomIn.TabIndex = 2;
            this.btZoomIn.Text = "+";
            this.btZoomIn.UseVisualStyleBackColor = true;
            this.btZoomIn.Click += new System.EventHandler(this.btZoomIn_Click);
            // 
            // btZoomShiftDown
            // 
            this.btZoomShiftDown.Location = new System.Drawing.Point(34, 69);
            this.btZoomShiftDown.Name = "btZoomShiftDown";
            this.btZoomShiftDown.Size = new System.Drawing.Size(51, 23);
            this.btZoomShiftDown.TabIndex = 1;
            this.btZoomShiftDown.Text = "Down";
            this.btZoomShiftDown.UseVisualStyleBackColor = true;
            this.btZoomShiftDown.Click += new System.EventHandler(this.btZoomShiftDown_Click);
            // 
            // btZoomShiftUp
            // 
            this.btZoomShiftUp.Location = new System.Drawing.Point(34, 20);
            this.btZoomShiftUp.Name = "btZoomShiftUp";
            this.btZoomShiftUp.Size = new System.Drawing.Size(51, 23);
            this.btZoomShiftUp.TabIndex = 0;
            this.btZoomShiftUp.Text = "Up";
            this.btZoomShiftUp.UseVisualStyleBackColor = true;
            this.btZoomShiftUp.Click += new System.EventHandler(this.btZoomShiftUp_Click);
            // 
            // cbScreenFlipVertical
            // 
            this.cbScreenFlipVertical.AutoSize = true;
            this.cbScreenFlipVertical.Location = new System.Drawing.Point(299, 47);
            this.cbScreenFlipVertical.Name = "cbScreenFlipVertical";
            this.cbScreenFlipVertical.Size = new System.Drawing.Size(79, 17);
            this.cbScreenFlipVertical.TabIndex = 18;
            this.cbScreenFlipVertical.Text = "Flip vertical";
            this.cbScreenFlipVertical.UseVisualStyleBackColor = true;
            this.cbScreenFlipVertical.CheckedChanged += new System.EventHandler(this.cbScreenFlipVertical_CheckedChanged);
            // 
            // cbScreenFlipHorizontal
            // 
            this.cbScreenFlipHorizontal.AutoSize = true;
            this.cbScreenFlipHorizontal.Location = new System.Drawing.Point(299, 70);
            this.cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal";
            this.cbScreenFlipHorizontal.Size = new System.Drawing.Size(90, 17);
            this.cbScreenFlipHorizontal.TabIndex = 17;
            this.cbScreenFlipHorizontal.Text = "Flip horizontal";
            this.cbScreenFlipHorizontal.UseVisualStyleBackColor = true;
            this.cbScreenFlipHorizontal.CheckedChanged += new System.EventHandler(this.cbScreenFlipHorizontal_CheckedChanged);
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = true;
            this.cbStretch.Location = new System.Drawing.Point(299, 22);
            this.cbStretch.Name = "cbStretch";
            this.cbStretch.Size = new System.Drawing.Size(89, 17);
            this.cbStretch.TabIndex = 16;
            this.cbStretch.Text = "Stretch video";
            this.cbStretch.UseVisualStyleBackColor = true;
            this.cbStretch.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbDirect2D);
            this.groupBox13.Controls.Add(this.rbNone);
            this.groupBox13.Controls.Add(this.rbEVR);
            this.groupBox13.Controls.Add(this.rbVMR9);
            this.groupBox13.Controls.Add(this.rbVR);
            this.groupBox13.Location = new System.Drawing.Point(16, 16);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(267, 138);
            this.groupBox13.TabIndex = 15;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Video Renderer";
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = true;
            this.rbDirect2D.Location = new System.Drawing.Point(12, 90);
            this.rbDirect2D.Name = "rbDirect2D";
            this.rbDirect2D.Size = new System.Drawing.Size(67, 17);
            this.rbDirect2D.TabIndex = 4;
            this.rbDirect2D.TabStop = true;
            this.rbDirect2D.Text = "Direct2D";
            this.rbDirect2D.UseVisualStyleBackColor = true;
            this.rbDirect2D.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(12, 113);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 3;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbEVR
            // 
            this.rbEVR.AutoSize = true;
            this.rbEVR.Location = new System.Drawing.Point(12, 67);
            this.rbEVR.Name = "rbEVR";
            this.rbEVR.Size = new System.Drawing.Size(227, 17);
            this.rbEVR.TabIndex = 2;
            this.rbEVR.Text = "Enhanced Video Renderer (Vista and later)";
            this.rbEVR.UseVisualStyleBackColor = true;
            this.rbEVR.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbVMR9
            // 
            this.rbVMR9.AutoSize = true;
            this.rbVMR9.Checked = true;
            this.rbVMR9.Location = new System.Drawing.Point(12, 44);
            this.rbVMR9.Name = "rbVMR9";
            this.rbVMR9.Size = new System.Drawing.Size(182, 17);
            this.rbVMR9.TabIndex = 1;
            this.rbVMR9.TabStop = true;
            this.rbVMR9.Text = "Video Mixing Renderer 9 (default)";
            this.rbVMR9.UseVisualStyleBackColor = true;
            this.rbVMR9.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // rbVR
            // 
            this.rbVR.AutoSize = true;
            this.rbVR.Location = new System.Drawing.Point(12, 21);
            this.rbVR.Name = "rbVR";
            this.rbVR.Size = new System.Drawing.Size(147, 17);
            this.rbVR.TabIndex = 0;
            this.rbVR.Text = "Video Renderer Filter (old)";
            this.rbVR.UseVisualStyleBackColor = true;
            this.rbVR.CheckedChanged += new System.EventHandler(this.rbVR_CheckedChanged);
            // 
            // tabPage116
            // 
            this.tabPage116.Controls.Add(this.label393);
            this.tabPage116.Controls.Add(this.cbDirect2DRotate);
            this.tabPage116.Location = new System.Drawing.Point(4, 22);
            this.tabPage116.Name = "tabPage116";
            this.tabPage116.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage116.Size = new System.Drawing.Size(444, 249);
            this.tabPage116.TabIndex = 1;
            this.tabPage116.Text = "Advanced";
            this.tabPage116.UseVisualStyleBackColor = true;
            // 
            // label393
            // 
            this.label393.AutoSize = true;
            this.label393.Location = new System.Drawing.Point(16, 16);
            this.label393.Name = "label393";
            this.label393.Size = new System.Drawing.Size(79, 13);
            this.label393.TabIndex = 26;
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
            this.cbDirect2DRotate.Location = new System.Drawing.Point(19, 32);
            this.cbDirect2DRotate.Name = "cbDirect2DRotate";
            this.cbDirect2DRotate.Size = new System.Drawing.Size(130, 21);
            this.cbDirect2DRotate.TabIndex = 25;
            this.cbDirect2DRotate.SelectedIndexChanged += new System.EventHandler(this.cbDirect2DRotate_SelectedIndexChanged);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.cbSeparateCaptureBridgeEngine);
            this.tabPage12.Controls.Add(this.label376);
            this.tabPage12.Controls.Add(this.edSeparateCaptureFileSize);
            this.tabPage12.Controls.Add(this.label375);
            this.tabPage12.Controls.Add(this.label374);
            this.tabPage12.Controls.Add(this.edSeparateCaptureDuration);
            this.tabPage12.Controls.Add(this.label373);
            this.tabPage12.Controls.Add(this.rbSeparateCaptureSplitBySize);
            this.tabPage12.Controls.Add(this.rbSeparateCaptureSplitByDuration);
            this.tabPage12.Controls.Add(this.rbSeparateCaptureStartManually);
            this.tabPage12.Controls.Add(this.btSeparateCaptureResume);
            this.tabPage12.Controls.Add(this.btSeparateCapturePause);
            this.tabPage12.Controls.Add(this.groupBox8);
            this.tabPage12.Controls.Add(this.btSeparateCaptureStop);
            this.tabPage12.Controls.Add(this.btSeparateCaptureStart);
            this.tabPage12.Controls.Add(this.cbSeparateCaptureEnabled);
            this.tabPage12.Controls.Add(this.label83);
            this.tabPage12.Controls.Add(this.label82);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(459, 285);
            this.tabPage12.TabIndex = 6;
            this.tabPage12.Text = "Separate capture";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // cbSeparateCaptureBridgeEngine
            // 
            this.cbSeparateCaptureBridgeEngine.AutoSize = true;
            this.cbSeparateCaptureBridgeEngine.Location = new System.Drawing.Point(339, 55);
            this.cbSeparateCaptureBridgeEngine.Name = "cbSeparateCaptureBridgeEngine";
            this.cbSeparateCaptureBridgeEngine.Size = new System.Drawing.Size(112, 17);
            this.cbSeparateCaptureBridgeEngine.TabIndex = 19;
            this.cbSeparateCaptureBridgeEngine.Text = "Use bridge engine";
            this.cbSeparateCaptureBridgeEngine.UseVisualStyleBackColor = true;
            // 
            // label376
            // 
            this.label376.AutoSize = true;
            this.label376.Location = new System.Drawing.Point(371, 245);
            this.label376.Name = "label376";
            this.label376.Size = new System.Drawing.Size(23, 13);
            this.label376.TabIndex = 18;
            this.label376.Text = "MB";
            // 
            // edSeparateCaptureFileSize
            // 
            this.edSeparateCaptureFileSize.Location = new System.Drawing.Point(312, 241);
            this.edSeparateCaptureFileSize.Name = "edSeparateCaptureFileSize";
            this.edSeparateCaptureFileSize.Size = new System.Drawing.Size(53, 20);
            this.edSeparateCaptureFileSize.TabIndex = 17;
            this.edSeparateCaptureFileSize.Text = "50";
            // 
            // label375
            // 
            this.label375.AutoSize = true;
            this.label375.Location = new System.Drawing.Point(239, 244);
            this.label375.Name = "label375";
            this.label375.Size = new System.Drawing.Size(44, 13);
            this.label375.TabIndex = 16;
            this.label375.Text = "File size";
            // 
            // label374
            // 
            this.label374.AutoSize = true;
            this.label374.Location = new System.Drawing.Point(168, 245);
            this.label374.Name = "label374";
            this.label374.Size = new System.Drawing.Size(20, 13);
            this.label374.TabIndex = 15;
            this.label374.Text = "ms";
            // 
            // edSeparateCaptureDuration
            // 
            this.edSeparateCaptureDuration.Location = new System.Drawing.Point(109, 242);
            this.edSeparateCaptureDuration.Name = "edSeparateCaptureDuration";
            this.edSeparateCaptureDuration.Size = new System.Drawing.Size(53, 20);
            this.edSeparateCaptureDuration.TabIndex = 14;
            this.edSeparateCaptureDuration.Text = "20000";
            // 
            // label373
            // 
            this.label373.AutoSize = true;
            this.label373.Location = new System.Drawing.Point(36, 245);
            this.label373.Name = "label373";
            this.label373.Size = new System.Drawing.Size(47, 13);
            this.label373.TabIndex = 13;
            this.label373.Text = "Duration";
            // 
            // rbSeparateCaptureSplitBySize
            // 
            this.rbSeparateCaptureSplitBySize.AutoSize = true;
            this.rbSeparateCaptureSplitBySize.Location = new System.Drawing.Point(222, 220);
            this.rbSeparateCaptureSplitBySize.Name = "rbSeparateCaptureSplitBySize";
            this.rbSeparateCaptureSplitBySize.Size = new System.Drawing.Size(96, 17);
            this.rbSeparateCaptureSplitBySize.TabIndex = 12;
            this.rbSeparateCaptureSplitBySize.Text = "Split by file size";
            this.rbSeparateCaptureSplitBySize.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureSplitByDuration
            // 
            this.rbSeparateCaptureSplitByDuration.AutoSize = true;
            this.rbSeparateCaptureSplitByDuration.Location = new System.Drawing.Point(19, 220);
            this.rbSeparateCaptureSplitByDuration.Name = "rbSeparateCaptureSplitByDuration";
            this.rbSeparateCaptureSplitByDuration.Size = new System.Drawing.Size(100, 17);
            this.rbSeparateCaptureSplitByDuration.TabIndex = 11;
            this.rbSeparateCaptureSplitByDuration.Text = "Split by duration";
            this.rbSeparateCaptureSplitByDuration.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureStartManually
            // 
            this.rbSeparateCaptureStartManually.AutoSize = true;
            this.rbSeparateCaptureStartManually.Checked = true;
            this.rbSeparateCaptureStartManually.Location = new System.Drawing.Point(19, 89);
            this.rbSeparateCaptureStartManually.Name = "rbSeparateCaptureStartManually";
            this.rbSeparateCaptureStartManually.Size = new System.Drawing.Size(91, 17);
            this.rbSeparateCaptureStartManually.TabIndex = 10;
            this.rbSeparateCaptureStartManually.TabStop = true;
            this.rbSeparateCaptureStartManually.Text = "Start manually";
            this.rbSeparateCaptureStartManually.UseVisualStyleBackColor = true;
            // 
            // btSeparateCaptureResume
            // 
            this.btSeparateCaptureResume.Location = new System.Drawing.Point(238, 113);
            this.btSeparateCaptureResume.Name = "btSeparateCaptureResume";
            this.btSeparateCaptureResume.Size = new System.Drawing.Size(95, 23);
            this.btSeparateCaptureResume.TabIndex = 9;
            this.btSeparateCaptureResume.Text = "Resume capture";
            this.btSeparateCaptureResume.UseVisualStyleBackColor = true;
            this.btSeparateCaptureResume.Click += new System.EventHandler(this.btSeparateCaptureResume_Click);
            // 
            // btSeparateCapturePause
            // 
            this.btSeparateCapturePause.Location = new System.Drawing.Point(137, 113);
            this.btSeparateCapturePause.Name = "btSeparateCapturePause";
            this.btSeparateCapturePause.Size = new System.Drawing.Size(95, 23);
            this.btSeparateCapturePause.TabIndex = 8;
            this.btSeparateCapturePause.Text = "Pause capture";
            this.btSeparateCapturePause.UseVisualStyleBackColor = true;
            this.btSeparateCapturePause.Click += new System.EventHandler(this.btSeparateCapturePause_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btSeparateCaptureChangeFilename);
            this.groupBox8.Controls.Add(this.edNewFilename);
            this.groupBox8.Controls.Add(this.label84);
            this.groupBox8.Location = new System.Drawing.Point(39, 142);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(392, 55);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Change file name on the fly";
            // 
            // btSeparateCaptureChangeFilename
            // 
            this.btSeparateCaptureChangeFilename.Location = new System.Drawing.Point(326, 20);
            this.btSeparateCaptureChangeFilename.Name = "btSeparateCaptureChangeFilename";
            this.btSeparateCaptureChangeFilename.Size = new System.Drawing.Size(60, 23);
            this.btSeparateCaptureChangeFilename.TabIndex = 9;
            this.btSeparateCaptureChangeFilename.Text = "Change";
            this.btSeparateCaptureChangeFilename.UseVisualStyleBackColor = true;
            this.btSeparateCaptureChangeFilename.Click += new System.EventHandler(this.btSeparateCaptureChangeFilename_Click);
            // 
            // edNewFilename
            // 
            this.edNewFilename.Location = new System.Drawing.Point(98, 22);
            this.edNewFilename.Name = "edNewFilename";
            this.edNewFilename.Size = new System.Drawing.Size(224, 20);
            this.edNewFilename.TabIndex = 8;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(18, 24);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(74, 13);
            this.label84.TabIndex = 7;
            this.label84.Text = "New file name";
            // 
            // btSeparateCaptureStop
            // 
            this.btSeparateCaptureStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btSeparateCaptureStop.Location = new System.Drawing.Point(339, 113);
            this.btSeparateCaptureStop.Name = "btSeparateCaptureStop";
            this.btSeparateCaptureStop.Size = new System.Drawing.Size(92, 23);
            this.btSeparateCaptureStop.TabIndex = 4;
            this.btSeparateCaptureStop.Text = "Stop capture";
            this.btSeparateCaptureStop.UseVisualStyleBackColor = true;
            this.btSeparateCaptureStop.Click += new System.EventHandler(this.btSeparateCaptureStop_Click);
            // 
            // btSeparateCaptureStart
            // 
            this.btSeparateCaptureStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btSeparateCaptureStart.Location = new System.Drawing.Point(39, 113);
            this.btSeparateCaptureStart.Name = "btSeparateCaptureStart";
            this.btSeparateCaptureStart.Size = new System.Drawing.Size(92, 23);
            this.btSeparateCaptureStart.TabIndex = 3;
            this.btSeparateCaptureStart.Text = "Start capture";
            this.btSeparateCaptureStart.UseVisualStyleBackColor = true;
            this.btSeparateCaptureStart.Click += new System.EventHandler(this.btSeparateCaptureStart_Click);
            // 
            // cbSeparateCaptureEnabled
            // 
            this.cbSeparateCaptureEnabled.AutoSize = true;
            this.cbSeparateCaptureEnabled.Location = new System.Drawing.Point(19, 55);
            this.cbSeparateCaptureEnabled.Name = "cbSeparateCaptureEnabled";
            this.cbSeparateCaptureEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbSeparateCaptureEnabled.TabIndex = 2;
            this.cbSeparateCaptureEnabled.Text = "Enabled";
            this.cbSeparateCaptureEnabled.UseVisualStyleBackColor = true;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(16, 34);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(302, 13);
            this.label83.TabIndex = 1;
            this.label83.Text = "from preview. You must enable it before you press Start button.";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(16, 16);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(430, 13);
            this.label82.TabIndex = 0;
            this.label82.Text = "\"Separate capture\" option allows you to start and stop video/audio capture indepe" +
    "ndently";
            // 
            // tabPage88
            // 
            this.tabPage88.Controls.Add(this.btMPEGDemuxSettings);
            this.tabPage88.Controls.Add(this.cbMPEGDemuxer);
            this.tabPage88.Controls.Add(this.label315);
            this.tabPage88.Controls.Add(this.btMPEGAudDecSettings);
            this.tabPage88.Controls.Add(this.cbMPEGAudioDecoder);
            this.tabPage88.Controls.Add(this.label121);
            this.tabPage88.Controls.Add(this.btMPEGVidDecSetting);
            this.tabPage88.Controls.Add(this.cbMPEGVideoDecoder);
            this.tabPage88.Controls.Add(this.label120);
            this.tabPage88.Location = new System.Drawing.Point(4, 22);
            this.tabPage88.Name = "tabPage88";
            this.tabPage88.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage88.Size = new System.Drawing.Size(459, 285);
            this.tabPage88.TabIndex = 8;
            this.tabPage88.Text = "MPEG decoding";
            this.tabPage88.UseVisualStyleBackColor = true;
            // 
            // btMPEGDemuxSettings
            // 
            this.btMPEGDemuxSettings.Location = new System.Drawing.Point(286, 126);
            this.btMPEGDemuxSettings.Name = "btMPEGDemuxSettings";
            this.btMPEGDemuxSettings.Size = new System.Drawing.Size(75, 23);
            this.btMPEGDemuxSettings.TabIndex = 14;
            this.btMPEGDemuxSettings.Text = "Settings";
            this.btMPEGDemuxSettings.UseVisualStyleBackColor = true;
            // 
            // cbMPEGDemuxer
            // 
            this.cbMPEGDemuxer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMPEGDemuxer.FormattingEnabled = true;
            this.cbMPEGDemuxer.Location = new System.Drawing.Point(18, 128);
            this.cbMPEGDemuxer.Name = "cbMPEGDemuxer";
            this.cbMPEGDemuxer.Size = new System.Drawing.Size(262, 21);
            this.cbMPEGDemuxer.TabIndex = 13;
            // 
            // label315
            // 
            this.label315.AutoSize = true;
            this.label315.Location = new System.Drawing.Point(15, 112);
            this.label315.Name = "label315";
            this.label315.Size = new System.Drawing.Size(83, 13);
            this.label315.TabIndex = 12;
            this.label315.Text = "MPEG Demuxer";
            // 
            // btMPEGAudDecSettings
            // 
            this.btMPEGAudDecSettings.Location = new System.Drawing.Point(286, 77);
            this.btMPEGAudDecSettings.Name = "btMPEGAudDecSettings";
            this.btMPEGAudDecSettings.Size = new System.Drawing.Size(75, 23);
            this.btMPEGAudDecSettings.TabIndex = 11;
            this.btMPEGAudDecSettings.Text = "Settings";
            this.btMPEGAudDecSettings.UseVisualStyleBackColor = true;
            this.btMPEGAudDecSettings.Click += new System.EventHandler(this.btMPEGAudDecSettings_Click);
            // 
            // cbMPEGAudioDecoder
            // 
            this.cbMPEGAudioDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMPEGAudioDecoder.FormattingEnabled = true;
            this.cbMPEGAudioDecoder.Location = new System.Drawing.Point(18, 79);
            this.cbMPEGAudioDecoder.Name = "cbMPEGAudioDecoder";
            this.cbMPEGAudioDecoder.Size = new System.Drawing.Size(262, 21);
            this.cbMPEGAudioDecoder.TabIndex = 10;
            this.cbMPEGAudioDecoder.SelectedIndexChanged += new System.EventHandler(this.cbMPEGAudioDecoder_SelectedIndexChanged);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(15, 63);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(78, 13);
            this.label121.TabIndex = 9;
            this.label121.Text = "Audio Decoder";
            // 
            // btMPEGVidDecSetting
            // 
            this.btMPEGVidDecSetting.Location = new System.Drawing.Point(286, 32);
            this.btMPEGVidDecSetting.Name = "btMPEGVidDecSetting";
            this.btMPEGVidDecSetting.Size = new System.Drawing.Size(75, 23);
            this.btMPEGVidDecSetting.TabIndex = 8;
            this.btMPEGVidDecSetting.Text = "Settings";
            this.btMPEGVidDecSetting.UseVisualStyleBackColor = true;
            this.btMPEGVidDecSetting.Click += new System.EventHandler(this.btMPEGVidDecSetting_Click);
            // 
            // cbMPEGVideoDecoder
            // 
            this.cbMPEGVideoDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMPEGVideoDecoder.FormattingEnabled = true;
            this.cbMPEGVideoDecoder.Location = new System.Drawing.Point(18, 34);
            this.cbMPEGVideoDecoder.Name = "cbMPEGVideoDecoder";
            this.cbMPEGVideoDecoder.Size = new System.Drawing.Size(262, 21);
            this.cbMPEGVideoDecoder.TabIndex = 7;
            this.cbMPEGVideoDecoder.SelectedIndexChanged += new System.EventHandler(this.cbMPEGVideoDecoder_SelectedIndexChanged);
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(15, 18);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(78, 13);
            this.label120.TabIndex = 6;
            this.label120.Text = "Video Decoder";
            // 
            // tabPage124
            // 
            this.tabPage124.Controls.Add(this.tabControl28);
            this.tabPage124.Location = new System.Drawing.Point(4, 22);
            this.tabPage124.Name = "tabPage124";
            this.tabPage124.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage124.Size = new System.Drawing.Size(459, 285);
            this.tabPage124.TabIndex = 10;
            this.tabPage124.Text = "Custom source";
            this.tabPage124.UseVisualStyleBackColor = true;
            // 
            // tabControl28
            // 
            this.tabControl28.Controls.Add(this.tabPage125);
            this.tabControl28.Controls.Add(this.tabPage126);
            this.tabControl28.Location = new System.Drawing.Point(6, 6);
            this.tabControl28.Name = "tabControl28";
            this.tabControl28.SelectedIndex = 0;
            this.tabControl28.Size = new System.Drawing.Size(450, 273);
            this.tabControl28.TabIndex = 6;
            // 
            // tabPage125
            // 
            this.tabPage125.Controls.Add(this.edCustomVideoSourceURL);
            this.tabPage125.Controls.Add(this.label516);
            this.tabPage125.Controls.Add(this.cbCustomVideoSourceFrameRate);
            this.tabPage125.Controls.Add(this.label438);
            this.tabPage125.Controls.Add(this.label435);
            this.tabPage125.Controls.Add(this.cbCustomVideoSourceFormat);
            this.tabPage125.Controls.Add(this.label434);
            this.tabPage125.Controls.Add(this.cbCustomVideoSourceFilter);
            this.tabPage125.Controls.Add(this.cbCustomVideoSourceCategory);
            this.tabPage125.Controls.Add(this.label432);
            this.tabPage125.Location = new System.Drawing.Point(4, 22);
            this.tabPage125.Name = "tabPage125";
            this.tabPage125.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage125.Size = new System.Drawing.Size(442, 247);
            this.tabPage125.TabIndex = 0;
            this.tabPage125.Text = "Video source";
            this.tabPage125.UseVisualStyleBackColor = true;
            // 
            // edCustomVideoSourceURL
            // 
            this.edCustomVideoSourceURL.Location = new System.Drawing.Point(14, 131);
            this.edCustomVideoSourceURL.Name = "edCustomVideoSourceURL";
            this.edCustomVideoSourceURL.Size = new System.Drawing.Size(414, 20);
            this.edCustomVideoSourceURL.TabIndex = 14;
            // 
            // label516
            // 
            this.label516.AutoSize = true;
            this.label516.Location = new System.Drawing.Point(11, 114);
            this.label516.Name = "label516";
            this.label516.Size = new System.Drawing.Size(189, 13);
            this.label516.TabIndex = 13;
            this.label516.Text = "File name or URL (if supported by filter)";
            // 
            // cbCustomVideoSourceFrameRate
            // 
            this.cbCustomVideoSourceFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoSourceFrameRate.FormattingEnabled = true;
            this.cbCustomVideoSourceFrameRate.Location = new System.Drawing.Point(343, 81);
            this.cbCustomVideoSourceFrameRate.Name = "cbCustomVideoSourceFrameRate";
            this.cbCustomVideoSourceFrameRate.Size = new System.Drawing.Size(85, 21);
            this.cbCustomVideoSourceFrameRate.TabIndex = 12;
            // 
            // label438
            // 
            this.label438.AutoSize = true;
            this.label438.Location = new System.Drawing.Point(340, 64);
            this.label438.Name = "label438";
            this.label438.Size = new System.Drawing.Size(57, 13);
            this.label438.TabIndex = 11;
            this.label438.Text = "Frame rate";
            // 
            // label435
            // 
            this.label435.AutoSize = true;
            this.label435.Location = new System.Drawing.Point(11, 14);
            this.label435.Name = "label435";
            this.label435.Size = new System.Drawing.Size(49, 13);
            this.label435.TabIndex = 10;
            this.label435.Text = "Category";
            // 
            // cbCustomVideoSourceFormat
            // 
            this.cbCustomVideoSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoSourceFormat.FormattingEnabled = true;
            this.cbCustomVideoSourceFormat.Location = new System.Drawing.Point(14, 81);
            this.cbCustomVideoSourceFormat.Name = "cbCustomVideoSourceFormat";
            this.cbCustomVideoSourceFormat.Size = new System.Drawing.Size(323, 21);
            this.cbCustomVideoSourceFormat.TabIndex = 9;
            // 
            // label434
            // 
            this.label434.AutoSize = true;
            this.label434.Location = new System.Drawing.Point(11, 64);
            this.label434.Name = "label434";
            this.label434.Size = new System.Drawing.Size(39, 13);
            this.label434.TabIndex = 8;
            this.label434.Text = "Format";
            // 
            // cbCustomVideoSourceFilter
            // 
            this.cbCustomVideoSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoSourceFilter.FormattingEnabled = true;
            this.cbCustomVideoSourceFilter.Location = new System.Drawing.Point(165, 30);
            this.cbCustomVideoSourceFilter.Name = "cbCustomVideoSourceFilter";
            this.cbCustomVideoSourceFilter.Size = new System.Drawing.Size(263, 21);
            this.cbCustomVideoSourceFilter.TabIndex = 7;
            this.cbCustomVideoSourceFilter.SelectedIndexChanged += new System.EventHandler(this.cbCustomVideoSourceFilter_SelectedIndexChanged);
            // 
            // cbCustomVideoSourceCategory
            // 
            this.cbCustomVideoSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoSourceCategory.FormattingEnabled = true;
            this.cbCustomVideoSourceCategory.Items.AddRange(new object[] {
            "Video capture source",
            "DirectShow filter"});
            this.cbCustomVideoSourceCategory.Location = new System.Drawing.Point(14, 30);
            this.cbCustomVideoSourceCategory.Name = "cbCustomVideoSourceCategory";
            this.cbCustomVideoSourceCategory.Size = new System.Drawing.Size(133, 21);
            this.cbCustomVideoSourceCategory.TabIndex = 6;
            this.cbCustomVideoSourceCategory.SelectedIndexChanged += new System.EventHandler(this.cbCustomVideoSourceCategory_SelectedIndexChanged);
            // 
            // label432
            // 
            this.label432.AutoSize = true;
            this.label432.Location = new System.Drawing.Point(162, 14);
            this.label432.Name = "label432";
            this.label432.Size = new System.Drawing.Size(35, 13);
            this.label432.TabIndex = 5;
            this.label432.Text = "Name";
            // 
            // tabPage126
            // 
            this.tabPage126.Controls.Add(this.edCustomAudioSourceURL);
            this.tabPage126.Controls.Add(this.label517);
            this.tabPage126.Controls.Add(this.label437);
            this.tabPage126.Controls.Add(this.cbCustomAudioSourceFormat);
            this.tabPage126.Controls.Add(this.label436);
            this.tabPage126.Controls.Add(this.cbCustomAudioSourceFilter);
            this.tabPage126.Controls.Add(this.label433);
            this.tabPage126.Controls.Add(this.cbCustomAudioSourceCategory);
            this.tabPage126.Location = new System.Drawing.Point(4, 22);
            this.tabPage126.Name = "tabPage126";
            this.tabPage126.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage126.Size = new System.Drawing.Size(442, 247);
            this.tabPage126.TabIndex = 1;
            this.tabPage126.Text = "Audio source";
            this.tabPage126.UseVisualStyleBackColor = true;
            // 
            // edCustomAudioSourceURL
            // 
            this.edCustomAudioSourceURL.Location = new System.Drawing.Point(14, 131);
            this.edCustomAudioSourceURL.Name = "edCustomAudioSourceURL";
            this.edCustomAudioSourceURL.Size = new System.Drawing.Size(414, 20);
            this.edCustomAudioSourceURL.TabIndex = 16;
            // 
            // label517
            // 
            this.label517.AutoSize = true;
            this.label517.Location = new System.Drawing.Point(11, 114);
            this.label517.Name = "label517";
            this.label517.Size = new System.Drawing.Size(189, 13);
            this.label517.TabIndex = 15;
            this.label517.Text = "File name or URL (if supported by filter)";
            // 
            // label437
            // 
            this.label437.AutoSize = true;
            this.label437.Location = new System.Drawing.Point(11, 14);
            this.label437.Name = "label437";
            this.label437.Size = new System.Drawing.Size(49, 13);
            this.label437.TabIndex = 12;
            this.label437.Text = "Category";
            // 
            // cbCustomAudioSourceFormat
            // 
            this.cbCustomAudioSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomAudioSourceFormat.FormattingEnabled = true;
            this.cbCustomAudioSourceFormat.Location = new System.Drawing.Point(14, 81);
            this.cbCustomAudioSourceFormat.Name = "cbCustomAudioSourceFormat";
            this.cbCustomAudioSourceFormat.Size = new System.Drawing.Size(414, 21);
            this.cbCustomAudioSourceFormat.TabIndex = 11;
            // 
            // label436
            // 
            this.label436.AutoSize = true;
            this.label436.Location = new System.Drawing.Point(11, 64);
            this.label436.Name = "label436";
            this.label436.Size = new System.Drawing.Size(39, 13);
            this.label436.TabIndex = 10;
            this.label436.Text = "Format";
            // 
            // cbCustomAudioSourceFilter
            // 
            this.cbCustomAudioSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomAudioSourceFilter.FormattingEnabled = true;
            this.cbCustomAudioSourceFilter.Location = new System.Drawing.Point(165, 30);
            this.cbCustomAudioSourceFilter.Name = "cbCustomAudioSourceFilter";
            this.cbCustomAudioSourceFilter.Size = new System.Drawing.Size(263, 21);
            this.cbCustomAudioSourceFilter.TabIndex = 8;
            this.cbCustomAudioSourceFilter.SelectedIndexChanged += new System.EventHandler(this.cbCustomAudioSourceFilter_SelectedIndexChanged);
            // 
            // label433
            // 
            this.label433.AutoSize = true;
            this.label433.Location = new System.Drawing.Point(162, 14);
            this.label433.Name = "label433";
            this.label433.Size = new System.Drawing.Size(35, 13);
            this.label433.TabIndex = 7;
            this.label433.Text = "Name";
            // 
            // cbCustomAudioSourceCategory
            // 
            this.cbCustomAudioSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomAudioSourceCategory.FormattingEnabled = true;
            this.cbCustomAudioSourceCategory.Items.AddRange(new object[] {
            "Audio capture source",
            "DirectShow filter"});
            this.cbCustomAudioSourceCategory.Location = new System.Drawing.Point(14, 30);
            this.cbCustomAudioSourceCategory.Name = "cbCustomAudioSourceCategory";
            this.cbCustomAudioSourceCategory.Size = new System.Drawing.Size(133, 21);
            this.cbCustomAudioSourceCategory.TabIndex = 6;
            this.cbCustomAudioSourceCategory.SelectedIndexChanged += new System.EventHandler(this.cbCustomAudioSourceCategory_SelectedIndexChanged);
            // 
            // tabControl12
            // 
            this.tabControl12.Controls.Add(this.tabPage53);
            this.tabControl12.Location = new System.Drawing.Point(8, 524);
            this.tabControl12.Name = "tabControl12";
            this.tabControl12.SelectedIndex = 0;
            this.tabControl12.Size = new System.Drawing.Size(315, 153);
            this.tabControl12.TabIndex = 75;
            // 
            // tabPage53
            // 
            this.tabPage53.Controls.Add(this.cbTelemetry);
            this.tabPage53.Controls.Add(this.cbDebugMode);
            this.tabPage53.Controls.Add(this.mmLog);
            this.tabPage53.Location = new System.Drawing.Point(4, 22);
            this.tabPage53.Name = "tabPage53";
            this.tabPage53.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage53.Size = new System.Drawing.Size(307, 127);
            this.tabPage53.TabIndex = 2;
            this.tabPage53.Text = "Debug";
            this.tabPage53.UseVisualStyleBackColor = true;
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(73, 6);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(72, 17);
            this.cbTelemetry.TabIndex = 77;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(9, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(58, 17);
            this.cbDebugMode.TabIndex = 73;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(9, 29);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(289, 92);
            this.mmLog.TabIndex = 72;
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            this.openFileDialog3.Filter = "VirtualDub filters|*.vdf";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 114);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 104;
            this.checkBox1.Text = "Enable VU meter Pro";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 685);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(78, 13);
            this.linkLabel1.TabIndex = 76;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch tutorials";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScreenshot.Location = new System.Drawing.Point(538, 650);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(116, 23);
            this.btSaveScreenshot.TabIndex = 78;
            this.btSaveScreenshot.Text = "Save snapshot";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(326, 655);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 95;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
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
            // VideoCapture1
            // 
            this.VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = false;
            this.VideoCapture1.Audio_CaptureDevice = "";
            this.VideoCapture1.Audio_CaptureDevice_CustomLatency = 0;
            this.VideoCapture1.Audio_CaptureDevice_Format = "";
            this.VideoCapture1.Audio_CaptureDevice_Format_UseBest = true;
            this.VideoCapture1.Audio_CaptureDevice_Line = "";
            this.VideoCapture1.Audio_CaptureDevice_MasterDevice = null;
            this.VideoCapture1.Audio_CaptureDevice_MasterDevice_Format = null;
            this.VideoCapture1.Audio_CaptureDevice_Path = null;
            this.VideoCapture1.Audio_CaptureSourceFilter = null;
            this.VideoCapture1.Audio_Channel_Mapper = null;
            this.VideoCapture1.Audio_Decoder = null;
            this.VideoCapture1.Audio_Effects_Enabled = false;
            this.VideoCapture1.Audio_Effects_UseLegacyEffects = false;
            this.VideoCapture1.Audio_Enhancer_Enabled = false;
            this.VideoCapture1.Audio_OutputDevice = "Default DirectSound Device";
            this.VideoCapture1.Audio_PCM_Converter = null;
            this.VideoCapture1.Audio_PlayAudio = true;
            this.VideoCapture1.Audio_RecordAudio = true;
            this.VideoCapture1.Audio_Sample_Grabber_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Pro_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Pro_Volume = 100;
            this.VideoCapture1.BackColor = System.Drawing.Color.Black;
            this.VideoCapture1.Barcode_Reader_Enabled = false;
            this.VideoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.QR;
            this.VideoCapture1.BDA_Source = null;
            this.VideoCapture1.ChromaKey = null;
            this.VideoCapture1.Custom_Source = null;
            this.VideoCapture1.CustomRedist_Auto = true;
            this.VideoCapture1.CustomRedist_Enabled = false;
            this.VideoCapture1.CustomRedist_Path = null;
            this.VideoCapture1.Debug_Dir = "";
            this.VideoCapture1.Debug_DisableMessageDialogs = false;
            this.VideoCapture1.Debug_Mode = false;
            this.VideoCapture1.Debug_Telemetry = false;
            this.VideoCapture1.Decklink_Input = VisioForge.Types.DecklinkInput.Auto;
            this.VideoCapture1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.Auto;
            this.VideoCapture1.Decklink_Input_IREUSA = false;
            this.VideoCapture1.Decklink_Input_SMPTE = false;
            this.VideoCapture1.Decklink_Output = null;
            this.VideoCapture1.Decklink_Source = null;
            this.VideoCapture1.DirectCapture_Muxer = null;
            this.VideoCapture1.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full;
            this.VideoCapture1.Face_Tracking = null;
            this.VideoCapture1.IP_Camera_Source = null;
            this.VideoCapture1.Location = new System.Drawing.Point(330, 325);
            this.VideoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture;
            this.VideoCapture1.Motion_Detection = null;
            this.VideoCapture1.Motion_DetectionEx = null;
            this.VideoCapture1.MPEG_Audio_Decoder = "";
            this.VideoCapture1.MPEG_Demuxer = null;
            this.VideoCapture1.MPEG_Video_Decoder = "";
            this.VideoCapture1.MultiScreen_Enabled = false;
            this.VideoCapture1.Name = "VideoCapture1";
            this.VideoCapture1.Network_Streaming_Audio_Enabled = false;
            this.VideoCapture1.Network_Streaming_Enabled = false;
            this.VideoCapture1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV;
            this.VideoCapture1.Network_Streaming_Network_Port = 10;
            this.VideoCapture1.Network_Streaming_Output = null;
            this.VideoCapture1.Network_Streaming_URL = "";
            this.VideoCapture1.Network_Streaming_WMV_Maximum_Clients = 10;
            this.VideoCapture1.OSD_Enabled = false;
            this.VideoCapture1.Output_Filename = "";
            this.VideoCapture1.Output_Format = null;
            this.VideoCapture1.PIP_AddSampleGrabbers = false;
            this.VideoCapture1.PIP_ChromaKeySettings = null;
            this.VideoCapture1.PIP_Mode = VisioForge.Types.VFPIPMode.Custom;
            this.VideoCapture1.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN;
            this.VideoCapture1.Push_Source = null;
            this.VideoCapture1.Screen_Capture_Source = null;
            this.VideoCapture1.SeparateCapture_AutostartCapture = false;
            this.VideoCapture1.SeparateCapture_Enabled = false;
            this.VideoCapture1.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext";
            this.VideoCapture1.SeparateCapture_FileSizeThreshold = ((long)(0));
            this.VideoCapture1.SeparateCapture_GMFMode = true;
            this.VideoCapture1.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal;
            this.VideoCapture1.SeparateCapture_TimeThreshold = System.TimeSpan.Parse("00:00:00");
            this.VideoCapture1.Size = new System.Drawing.Size(467, 321);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 77;
            this.VideoCapture1.Tags = null;
            this.VideoCapture1.Timeshift_Settings = null;
            this.VideoCapture1.TVTuner_Channel = 0;
            this.VideoCapture1.TVTuner_Country = "";
            this.VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 80000000;
            this.VideoCapture1.TVTuner_FM_Tuning_Step = 160000000;
            this.VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 0;
            this.VideoCapture1.TVTuner_Frequency = 0;
            this.VideoCapture1.TVTuner_InputType = "";
            this.VideoCapture1.TVTuner_Mode = VisioForge.Types.VFTVTunerMode.Default;
            this.VideoCapture1.TVTuner_Name = "";
            this.VideoCapture1.TVTuner_TVFormat = VisioForge.Types.VFTVTunerVideoFormat.PAL_D;
            this.VideoCapture1.Video_CaptureDevice = "";
            this.VideoCapture1.Video_CaptureDevice_Format = "";
            this.VideoCapture1.Video_CaptureDevice_Format_UseBest = true;
            this.VideoCapture1.Video_CaptureDevice_FrameRate = 0D;
            this.VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = "";
            this.VideoCapture1.Video_CaptureDevice_IsAudioSource = false;
            this.VideoCapture1.Video_CaptureDevice_Path = null;
            this.VideoCapture1.Video_CaptureDevice_UseClosedCaptions = false;
            this.VideoCapture1.Video_CaptureDevice_UseRAWSampleGrabber = false;
            this.VideoCapture1.Video_Crop = null;
            this.VideoCapture1.Video_Decoder = null;
            this.VideoCapture1.Video_Effects_AllowMultipleStreams = false;
            this.VideoCapture1.Video_Effects_Enabled = false;
            this.VideoCapture1.Video_Effects_GPU_Enabled = false;
            this.VideoCapture1.Video_Effects_MergeImageLogos = false;
            this.VideoCapture1.Video_Effects_MergeTextLogos = false;
            this.VideoCapture1.Video_Resize = null;
            this.VideoCapture1.Video_ResizeOrCrop_Enabled = false;
            this.VideoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.VideoCapture1.Video_Sample_Grabber_Enabled = false;
            this.VideoCapture1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.VideoCapture1.Video_Still_Frames_Grabber_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_LicenseKey = null;
            this.VideoCapture1.VLC_Path = null;
            this.VideoCapture1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoCapture1_OnError);
            this.VideoCapture1.OnFFMPEGInfo += new System.EventHandler<VisioForge.Types.FFMPEGInfoEventArgs>(this.VideoCapture1_OnFFMPEGInfo);
            this.VideoCapture1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.VideoCapture1_OnLicenseRequired);
            this.VideoCapture1.OnFaceDetected += new System.EventHandler<VisioForge.Types.AFFaceDetectionEventArgs>(this.VideoCapture1_OnFaceDetected);
            this.VideoCapture1.OnMotion += new System.EventHandler<VisioForge.Types.MotionDetectionEventArgs>(this.VideoCapture1_OnMotion);
            this.VideoCapture1.OnTVTunerTuneChannels += new System.EventHandler<VisioForge.Types.TVTunerTuneChannelsEventArgs>(this.VideoCapture1_OnTVTunerTuneChannels);
            this.VideoCapture1.OnAudioVUMeter += new System.EventHandler<VisioForge.Types.VUMeterEventArgs>(this.VideoCapture1_OnAudioVUMeter);
            this.VideoCapture1.OnAudioVUMeterProVolume += new System.EventHandler<VisioForge.Types.AudioLevelEventArgs>(this.VideoCapture1_OnAudioVUMeterProVolume);
            this.VideoCapture1.OnNetworkSourceDisconnect += new System.EventHandler<System.EventArgs>(this.VideoCapture1_OnNetworkSourceStop);
            this.VideoCapture1.OnMotionDetectionEx += new System.EventHandler<VisioForge.Types.MotionDetectionExEventArgs>(this.VideoCapture1_OnMotionDetectionEx);
            this.VideoCapture1.OnBarcodeDetected += new System.EventHandler<VisioForge.Types.BarcodeEventArgs>(this.VideoCapture1_OnBarcodeDetected);
            this.VideoCapture1.OnBDAChannelFound += new System.EventHandler<VisioForge.Types.BDAChannelEventArgs>(this.VideoCapture1_OnBDAChannelFound);
            this.VideoCapture1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoCapture1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 712);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.tabControl12);
            this.Controls.Add(this.tabControl10);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btSaveScreenshot);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.linkLabel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Main Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl17.ResumeLayout(false);
            this.tabPage68.ResumeLayout(false);
            this.tabPage68.PerformLayout();
            this.tabControl7.ResumeLayout(false);
            this.tabPage29.ResumeLayout(false);
            this.tabPage29.PerformLayout();
            this.tabPage42.ResumeLayout(false);
            this.tabPage42.PerformLayout();
            this.tabPage91.ResumeLayout(false);
            this.tabPage91.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.tabPage92.ResumeLayout(false);
            this.tabPage92.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.tabPage102.ResumeLayout(false);
            this.tabPage102.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.tabPage114.ResumeLayout(false);
            this.tabPage114.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLiveRotationAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage69.ResumeLayout(false);
            this.tabPage69.PerformLayout();
            this.tabPage59.ResumeLayout(false);
            this.tabPage59.PerformLayout();
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPULightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGPUSaturation)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage60.ResumeLayout(false);
            this.tabPage60.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeySmoothing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChromaKeyThresholdSensitivity)).EndInit();
            this.tabPage70.ResumeLayout(false);
            this.tabPage70.PerformLayout();
            this.tabControl14.ResumeLayout(false);
            this.tabPage127.ResumeLayout(false);
            this.tabPage127.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioTimeshift)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainLFE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioOutputGainL)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainLFE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioInputGainL)).EndInit();
            this.tabPage27.ResumeLayout(false);
            this.tabPage27.PerformLayout();
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
            this.tabPage93.ResumeLayout(false);
            this.tabPage93.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioChannelMapperVolume)).EndInit();
            this.tabPage107.ResumeLayout(false);
            this.tabPage107.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tpWMV.ResumeLayout(false);
            this.tpWMV.PerformLayout();
            this.tpRTSP.ResumeLayout(false);
            this.tpRTSP.PerformLayout();
            this.tpRTMP.ResumeLayout(false);
            this.tpRTMP.PerformLayout();
            this.tpNDI.ResumeLayout(false);
            this.tpNDI.PerformLayout();
            this.tpUDP.ResumeLayout(false);
            this.tpUDP.PerformLayout();
            this.tpSSF.ResumeLayout(false);
            this.tpSSF.PerformLayout();
            this.tpHLS.ResumeLayout(false);
            this.tpHLS.PerformLayout();
            this.tpNSExternal.ResumeLayout(false);
            this.tpNSExternal.PerformLayout();
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
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
            this.tabPage43.ResumeLayout(false);
            this.tabPage43.PerformLayout();
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
            this.tabPage26.ResumeLayout(false);
            this.tabPage26.PerformLayout();
            this.tabPage25.ResumeLayout(false);
            this.tabPage25.PerformLayout();
            this.tabPage101.ResumeLayout(false);
            this.tabPage101.PerformLayout();
            this.tabPage103.ResumeLayout(false);
            this.tabPage103.PerformLayout();
            this.tabPage141.ResumeLayout(false);
            this.tabPage141.PerformLayout();
            this.TabControl32.ResumeLayout(false);
            this.TabPage142.ResumeLayout(false);
            this.TabPage142.PerformLayout();
            this.TabPage143.ResumeLayout(false);
            this.TabPage143.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTagCover)).EndInit();
            this.tabControl10.ResumeLayout(false);
            this.tabPage46.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage52.ResumeLayout(false);
            this.tabPage52.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage21.ResumeLayout(false);
            this.tabPage21.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage57.ResumeLayout(false);
            this.tabPage57.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjBrightness)).EndInit();
            this.tabPage66.ResumeLayout(false);
            this.tabPage66.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCCPan)).EndInit();
            this.tabPage63.ResumeLayout(false);
            this.tabControl19.ResumeLayout(false);
            this.tabPage96.ResumeLayout(false);
            this.tabPage96.PerformLayout();
            this.tabPage97.ResumeLayout(false);
            this.tabPage97.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).EndInit();
            this.tabPage98.ResumeLayout(false);
            this.tabPage98.PerformLayout();
            this.tabPage112.ResumeLayout(false);
            this.tabPage112.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterBoost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVUMeterAmplification)).EndInit();
            this.tabPage99.ResumeLayout(false);
            this.tabPage99.PerformLayout();
            this.tabPage47.ResumeLayout(false);
            this.tabPage47.PerformLayout();
            this.tabPage48.ResumeLayout(false);
            this.tabControl15.ResumeLayout(false);
            this.tabPage144.ResumeLayout(false);
            this.tabPage144.PerformLayout();
            this.tabPage146.ResumeLayout(false);
            this.tabPage146.PerformLayout();
            this.tabPage145.ResumeLayout(false);
            this.tabPage145.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage81.ResumeLayout(false);
            this.tabControl22.ResumeLayout(false);
            this.tabPage82.ResumeLayout(false);
            this.tabPage82.PerformLayout();
            this.tabPage83.ResumeLayout(false);
            this.tabControl23.ResumeLayout(false);
            this.tabPage84.ResumeLayout(false);
            this.tabPage84.PerformLayout();
            this.tabPage85.ResumeLayout(false);
            this.tabPage85.PerformLayout();
            this.tabPage86.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.tabPage87.ResumeLayout(false);
            this.tabPage87.PerformLayout();
            this.tabPage105.ResumeLayout(false);
            this.tabPage105.PerformLayout();
            this.tabPage49.ResumeLayout(false);
            this.tabControl20.ResumeLayout(false);
            this.tabPage67.ResumeLayout(false);
            this.tabControl21.ResumeLayout(false);
            this.tabPage78.ResumeLayout(false);
            this.tabPage78.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.tabPage79.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.tabPage80.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.tabPage100.ResumeLayout(false);
            this.tabPage100.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.tabPage77.ResumeLayout(false);
            this.tabPage77.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPTransparency)).EndInit();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.tabPage147.ResumeLayout(false);
            this.tabPage147.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPChromaKeyTolerance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPIPChromaKeyTolerance1)).EndInit();
            this.tabPage50.ResumeLayout(false);
            this.tabPage50.PerformLayout();
            this.tabPage51.ResumeLayout(false);
            this.tabControl26.ResumeLayout(false);
            this.tabPage115.ResumeLayout(false);
            this.tabPage115.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage116.ResumeLayout(false);
            this.tabPage116.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage88.ResumeLayout(false);
            this.tabPage88.PerformLayout();
            this.tabPage124.ResumeLayout(false);
            this.tabControl28.ResumeLayout(false);
            this.tabPage125.ResumeLayout(false);
            this.tabPage125.PerformLayout();
            this.tabPage126.ResumeLayout(false);
            this.tabPage126.PerformLayout();
            this.tabControl12.ResumeLayout(false);
            this.tabPage53.ResumeLayout(false);
            this.tabPage53.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbRecordAudio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.CheckBox cbNetworkStreaming;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.TabPage tabPage28;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.TextBox edOSDLayerLeft;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Button btOSDClearLayers;
        private System.Windows.Forms.Button btOSDLayerAdd;
        private System.Windows.Forms.TextBox edOSDLayerHeight;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.TextBox edOSDLayerWidth;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.TextBox edOSDLayerTop;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.TabPage tabPage32;
        private System.Windows.Forms.TextBox edOSDImageTop;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.TextBox edOSDImageLeft;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Button btOSDSelectImage;
        private System.Windows.Forms.TextBox edOSDImageFilename;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.CheckBox cbOSDImageTranspColor;
        private System.Windows.Forms.Panel pnOSDColorKey;
        private System.Windows.Forms.Button btOSDImageDraw;
        private System.Windows.Forms.Button btOSDSelectFont;
        private System.Windows.Forms.TextBox edOSDText;
        private System.Windows.Forms.Button btOSDTextDraw;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.TextBox edOSDTextTop;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.TextBox edOSDTextLeft;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Button btOSDSetTransp;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.TrackBar tbOSDTranspLevel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage tabPage43;
        private System.Windows.Forms.CheckBox cbMotDetEnabled;
        private System.Windows.Forms.TabControl tabControl9;
        private System.Windows.Forms.TabPage tabPage44;
        private System.Windows.Forms.TabPage tabPage45;
        private System.Windows.Forms.ProgressBar pbMotionLevel;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.TextBox mmMotDetMatrix;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Button btMotDetUpdateSettings;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.CheckBox cbCompareGreyscale;
        private System.Windows.Forms.CheckBox cbCompareBlue;
        private System.Windows.Forms.CheckBox cbCompareGreen;
        private System.Windows.Forms.CheckBox cbCompareRed;
        private System.Windows.Forms.TextBox edMotDetFrameInterval;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.CheckBox cbMotDetDropFramesEnabled;
        private System.Windows.Forms.CheckBox cbMotDetHLEnabled;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.TrackBar tbMotDetHLThreshold;
        private System.Windows.Forms.ComboBox cbMotDetHLColor;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.TextBox edMotDetMatrixHeight;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.TextBox edMotDetMatrixWidth;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.TrackBar tbMotDetDropFramesThreshold;
        private System.Windows.Forms.TabControl tabControl10;
        private System.Windows.Forms.TabPage tabPage46;
        private System.Windows.Forms.TabPage tabPage47;
        private System.Windows.Forms.TabPage tabPage48;
        private System.Windows.Forms.TabPage tabPage49;
        private System.Windows.Forms.TabPage tabPage50;
        private System.Windows.Forms.TabPage tabPage51;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btSignal;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Button btVideoCaptureDeviceSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TextBox edTVDefaultFormat;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ComboBox cbTVCountry;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cbTVMode;
        private System.Windows.Forms.ComboBox cbTVInput;
        private System.Windows.Forms.ComboBox cbTVTuner;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TextBox edChannel;
        private System.Windows.Forms.Button btUseThisChannel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTVChannel;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ProgressBar pbChannels;
        private System.Windows.Forms.Button btStopTune;
        private System.Windows.Forms.Button btStartTune;
        private System.Windows.Forms.ComboBox cbTVSystem;
        private System.Windows.Forms.TextBox edAudioFreq;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox edVideoFreq;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.Button btMPEGEncoderShowDialog;
        private System.Windows.Forms.ComboBox cbMPEGEncoder;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.RadioButton rbDVResDC;
        private System.Windows.Forms.RadioButton rbDVResQuarter;
        private System.Windows.Forms.RadioButton rbDVResHalf;
        private System.Windows.Forms.RadioButton rbDVResFull;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btDVStepFWD;
        private System.Windows.Forms.Button btDVStepRev;
        private System.Windows.Forms.Button btDVFF;
        private System.Windows.Forms.Button btDVStop;
        private System.Windows.Forms.Button btDVPause;
        private System.Windows.Forms.Button btDVPlay;
        private System.Windows.Forms.Button btDVRewind;
        private System.Windows.Forms.TabPage tabPage52;
        private System.Windows.Forms.CheckBox cbCrossBarAvailable;
        private System.Windows.Forms.ListBox lbRotes;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.CheckBox cbConnectRelated;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ComboBox cbCrossbarVideoInput;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.RadioButton rbCrossbarAdvanced;
        private System.Windows.Forms.RadioButton rbCrossbarSimple;
        private System.Windows.Forms.ComboBox cbCrossbarOutput;
        private System.Windows.Forms.ComboBox cbCrossbarInput;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btScreenCaptureUpdate;
        private System.Windows.Forms.CheckBox cbScreenCapture_GrabMouseCursor;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox edScreenFrameRate;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox edScreenBottom;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox edScreenRight;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox edScreenTop;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox edScreenLeft;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton rbScreenCustomArea;
        private System.Windows.Forms.RadioButton rbScreenFullScreen;
        private System.Windows.Forms.CheckBox cbMultiscreenDrawOnPanels;
        private System.Windows.Forms.Panel pnScreen3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnScreen2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnScreen1;
        private System.Windows.Forms.CheckBox cbFlipHorizontal3;
        private System.Windows.Forms.CheckBox cbFlipVertical3;
        private System.Windows.Forms.CheckBox cbStretch3;
        private System.Windows.Forms.CheckBox cbFlipHorizontal2;
        private System.Windows.Forms.CheckBox cbFlipVertical2;
        private System.Windows.Forms.CheckBox cbStretch2;
        private System.Windows.Forms.CheckBox cbFlipHorizontal1;
        private System.Windows.Forms.CheckBox cbFlipVertical1;
        private System.Windows.Forms.CheckBox cbStretch1;
        private System.Windows.Forms.TabControl tabControl12;
        private System.Windows.Forms.TabPage tabPage53;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.TabPage tabPage57;
        private System.Windows.Forms.Label lbAdjContrastCurrent;
        private System.Windows.Forms.Label lbAdjContrastMax;
        private System.Windows.Forms.CheckBox cbAdjContrastAuto;
        private System.Windows.Forms.Label lbAdjContrastMin;
        private System.Windows.Forms.TrackBar tbAdjContrast;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbAdjBrightnessCurrent;
        private System.Windows.Forms.Label lbAdjBrightnessMax;
        private System.Windows.Forms.CheckBox cbAdjBrightnessAuto;
        private System.Windows.Forms.Label lbAdjBrightnessMin;
        private System.Windows.Forms.TrackBar tbAdjBrightness;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbAdjSaturationCurrent;
        private System.Windows.Forms.Label lbAdjSaturationMax;
        private System.Windows.Forms.CheckBox cbAdjSaturationAuto;
        private System.Windows.Forms.Label lbAdjSaturationMin;
        private System.Windows.Forms.TrackBar tbAdjSaturation;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lbAdjHueCurrent;
        private System.Windows.Forms.Label lbAdjHueMax;
        private System.Windows.Forms.CheckBox cbAdjHueAuto;
        private System.Windows.Forms.Label lbAdjHueMin;
        private System.Windows.Forms.TrackBar tbAdjHue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TabControl tabControl17;
        private System.Windows.Forms.TabPage tabPage68;
        private System.Windows.Forms.TabPage tabPage69;
        private System.Windows.Forms.TabControl tabControl14;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage58;
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
        private System.Windows.Forms.CheckBox cbDeinterlace;
        private System.Windows.Forms.TabPage tabPage70;
        private System.Windows.Forms.Button btFilterDeleteAll;
        private System.Windows.Forms.Button btFilterSettings2;
        private System.Windows.Forms.ListBox lbFilters;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Button btFilterSettings;
        private System.Windows.Forms.Button btFilterAdd;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.TabPage tabPage27;
        private System.Windows.Forms.CheckBox cbNetworkStreamingAudioEnabled;
        private System.Windows.Forms.TabControl tabControl18;
        private System.Windows.Forms.TabPage tabPage71;
        private System.Windows.Forms.TabPage tabPage72;
        private System.Windows.Forms.CheckBox cbAudioEffectsEnabled;
        private System.Windows.Forms.TabPage tabPage73;
        private System.Windows.Forms.TabPage tabPage75;
        private System.Windows.Forms.CheckBox cbAudAmplifyEnabled;
        private System.Windows.Forms.CheckBox cbAudEqualizerEnabled;
        private System.Windows.Forms.CheckBox cbAudDynamicAmplifyEnabled;
        private System.Windows.Forms.CheckBox cbAudSound3DEnabled;
        private System.Windows.Forms.TabPage tabPage76;
        private System.Windows.Forms.CheckBox cbAudTrueBassEnabled;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.TrackBar tbAudAmplifyAmp;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TrackBar tbAudEq0;
        private System.Windows.Forms.TrackBar tbAudEq1;
        private System.Windows.Forms.Label label232;
        private System.Windows.Forms.TrackBar tbAudEq9;
        private System.Windows.Forms.TrackBar tbAudEq8;
        private System.Windows.Forms.TrackBar tbAudEq7;
        private System.Windows.Forms.TrackBar tbAudEq6;
        private System.Windows.Forms.TrackBar tbAudEq5;
        private System.Windows.Forms.TrackBar tbAudEq4;
        private System.Windows.Forms.TrackBar tbAudEq3;
        private System.Windows.Forms.TrackBar tbAudEq2;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.Label label235;
        private System.Windows.Forms.Label label234;
        private System.Windows.Forms.Label label233;
        private System.Windows.Forms.Label label242;
        private System.Windows.Forms.Label label241;
        private System.Windows.Forms.Label label240;
        private System.Windows.Forms.Label label239;
        private System.Windows.Forms.Label label238;
        private System.Windows.Forms.Button btAudEqRefresh;
        private System.Windows.Forms.ComboBox cbAudEqualizerPreset;
        private System.Windows.Forms.Label label243;
        private System.Windows.Forms.Label label244;
        private System.Windows.Forms.TrackBar tbAudDynAmp;
        private System.Windows.Forms.Label label245;
        private System.Windows.Forms.TrackBar tbAudRelease;
        private System.Windows.Forms.Label label248;
        private System.Windows.Forms.Label label249;
        private System.Windows.Forms.Label label246;
        private System.Windows.Forms.TrackBar tbAudAttack;
        private System.Windows.Forms.Label label247;
        private System.Windows.Forms.TrackBar tbAud3DSound;
        private System.Windows.Forms.Label label253;
        private System.Windows.Forms.TrackBar tbAudTrueBass;
        private System.Windows.Forms.Label label254;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TabPage tabPage59;
        private System.Windows.Forms.TabPage tabPage60;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.TextBox edDeintCAVTThreshold;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.RadioButton rbDeintTriangleEnabled;
        private System.Windows.Forms.RadioButton rbDeintBlendEnabled;
        private System.Windows.Forms.RadioButton rbDeintCAVTEnabled;
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
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.TextBox edDeintTriangleWeight;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.CheckBox cbDenoise;
        private System.Windows.Forms.RadioButton rbDenoiseMosquito;
        private System.Windows.Forms.RadioButton rbDenoiseCAST;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Button btSeparateCaptureStop;
        private System.Windows.Forms.Button btSeparateCaptureStart;
        private System.Windows.Forms.CheckBox cbSeparateCaptureEnabled;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btSeparateCaptureChangeFilename;
        private System.Windows.Forms.TextBox edNewFilename;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tpWMV;
        private System.Windows.Forms.Button btRefreshClients;
        private System.Windows.Forms.ListBox lbNetworkClients;
        private System.Windows.Forms.RadioButton rbNetworkStreamingUseExternalProfile;
        private System.Windows.Forms.RadioButton rbNetworkStreamingUseMainWMVSettings;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox edMaximumClients;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button btSelectWMVProfileNetwork;
        private System.Windows.Forms.TextBox edNetworkStreamingWMVProfile;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TabPage tpNSExternal;
        private System.Windows.Forms.TextBox edWMVNetworkPort;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TabPage tabPage66;
        private System.Windows.Forms.Label lbCCPanCurrent;
        private System.Windows.Forms.Label lbCCPanMax;
        private System.Windows.Forms.Label lbCCPanMin;
        private System.Windows.Forms.TrackBar tbCCPan;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Button btCCReadValues;
        private System.Windows.Forms.CheckBox cbCCPanManual;
        private System.Windows.Forms.CheckBox cbCCPanAuto;
        private System.Windows.Forms.CheckBox cbCCTiltManual;
        private System.Windows.Forms.CheckBox cbCCTiltAuto;
        private System.Windows.Forms.Label lbCCTiltCurrent;
        private System.Windows.Forms.Label lbCCTiltMax;
        private System.Windows.Forms.Label lbCCTiltMin;
        private System.Windows.Forms.TrackBar tbCCTilt;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Button btCCTiltApply;
        private System.Windows.Forms.Button btCCPanApply;
        private System.Windows.Forms.ComboBox cbScreenCaptureDisplayIndex;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.TabControl tabControl20;
        private System.Windows.Forms.TabPage tabPage67;
        private System.Windows.Forms.TabPage tabPage77;
        private System.Windows.Forms.ComboBox cbPIPMode;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Button btPIPDevicesClear;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btPIPUpdate;
        private System.Windows.Forms.TextBox edPIPHeight;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.TextBox edPIPWidth;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.TextBox edPIPTop;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.TextBox edPIPLeft;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.TabControl tabControl21;
        private System.Windows.Forms.TabPage tabPage78;
        private System.Windows.Forms.TabPage tabPage79;
        private System.Windows.Forms.TabPage tabPage80;
        private System.Windows.Forms.ComboBox cbPIPInput;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.ComboBox cbPIPFrameRate;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.CheckBox cbPIPFormatUseBest;
        private System.Windows.Forms.ComboBox cbPIPFormat;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.ComboBox cbPIPDevice;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Button btPIPAddDevice;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.TextBox edPIPVidCapHeight;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox edPIPVidCapWidth;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox edPIPVidCapTop;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox edPIPVidCapLeft;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button btPIPAddIPCamera;
        private System.Windows.Forms.Button btPIPAddScreenCapture;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.TextBox edPIPIPCapHeight;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.TextBox edPIPIPCapWidth;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.TextBox edPIPIPCapTop;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.TextBox edPIPIPCapLeft;
        private System.Windows.Forms.Label label229;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.TextBox edPIPScreenCapHeight;
        private System.Windows.Forms.Label label256;
        private System.Windows.Forms.TextBox edPIPScreenCapWidth;
        private System.Windows.Forms.Label label260;
        private System.Windows.Forms.TextBox edPIPScreenCapTop;
        private System.Windows.Forms.Label label266;
        private System.Windows.Forms.TextBox edPIPScreenCapLeft;
        private System.Windows.Forms.Label label268;
        private System.Windows.Forms.ComboBox cbPIPDevices;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.Button btPIPSetOutputSize;
        private System.Windows.Forms.TextBox edPIPOutputHeight;
        private System.Windows.Forms.Label label269;
        private System.Windows.Forms.TextBox edPIPOutputWidth;
        private System.Windows.Forms.Label label271;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.Button btPIPSet;
        private System.Windows.Forms.TrackBar tbPIPTransparency;
        private System.Windows.Forms.TabPage tabPage81;
        private System.Windows.Forms.TabControl tabControl22;
        private System.Windows.Forms.TabPage tabPage82;
        private System.Windows.Forms.ComboBox cbBDADeviceStandard;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.ComboBox cbBDAReceiver;
        private System.Windows.Forms.Label label270;
        private System.Windows.Forms.ComboBox cbBDASourceDevice;
        private System.Windows.Forms.Label label272;
        private System.Windows.Forms.TabPage tabPage83;
        private System.Windows.Forms.TabControl tabControl23;
        private System.Windows.Forms.TabPage tabPage84;
        private System.Windows.Forms.Button btDVBTTune;
        private System.Windows.Forms.TextBox edDVBTSID;
        private System.Windows.Forms.TextBox edDVBTTSID;
        private System.Windows.Forms.TextBox edDVBTONID;
        private System.Windows.Forms.Label label273;
        private System.Windows.Forms.TextBox edDVBTFrequency;
        private System.Windows.Forms.Label label274;
        private System.Windows.Forms.Label label275;
        private System.Windows.Forms.Label label276;
        private System.Windows.Forms.Label label277;
        private System.Windows.Forms.TabPage tabPage85;
        private System.Windows.Forms.ComboBox cbDVBSPolarisation;
        private System.Windows.Forms.Label label278;
        private System.Windows.Forms.TextBox edDVBSSymbolRate;
        private System.Windows.Forms.Label label279;
        private System.Windows.Forms.Button btDVBSTune;
        private System.Windows.Forms.TextBox edDVBSSID;
        private System.Windows.Forms.TextBox edDVBSTSID;
        private System.Windows.Forms.TextBox edDVBSONIT;
        private System.Windows.Forms.Label label280;
        private System.Windows.Forms.TextBox edDVBSFrequency;
        private System.Windows.Forms.Label label281;
        private System.Windows.Forms.Label label282;
        private System.Windows.Forms.Label label283;
        private System.Windows.Forms.Label label284;
        private System.Windows.Forms.TabPage tabPage86;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.TextBox edDVBCMinorChannel;
        private System.Windows.Forms.Label label285;
        private System.Windows.Forms.TextBox edDVBCPhysicalChannel;
        private System.Windows.Forms.Label label286;
        private System.Windows.Forms.TextBox edDVBCVirtualChannel;
        private System.Windows.Forms.Label label287;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.TextBox edDVBCSymbolRate;
        private System.Windows.Forms.Label label288;
        private System.Windows.Forms.TextBox edDVBCProgramNumber;
        private System.Windows.Forms.Label label289;
        private System.Windows.Forms.ComboBox cbDVBCModulation;
        private System.Windows.Forms.Label label290;
        private System.Windows.Forms.Label label291;
        private System.Windows.Forms.TextBox edDVBCCarrierFrequency;
        private System.Windows.Forms.Label label292;
        private System.Windows.Forms.Button btBDADVBCTune;
        private System.Windows.Forms.TabPage tabPage87;
        private System.Windows.Forms.Label label293;
        private System.Windows.Forms.Button btSeparateCaptureResume;
        private System.Windows.Forms.Button btSeparateCapturePause;
        private System.Windows.Forms.TabPage tabPage88;
        private System.Windows.Forms.Button btMPEGAudDecSettings;
        private System.Windows.Forms.ComboBox cbMPEGAudioDecoder;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Button btMPEGVidDecSetting;
        private System.Windows.Forms.ComboBox cbMPEGVideoDecoder;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.RadioButton rbScreenCaptureWindow;
        private System.Windows.Forms.TabPage tabPage91;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Button btEffZoomRight;
        private System.Windows.Forms.Button btEffZoomLeft;
        private System.Windows.Forms.Button btEffZoomOut;
        private System.Windows.Forms.Button btEffZoomIn;
        private System.Windows.Forms.Button btEffZoomDown;
        private System.Windows.Forms.Button btEffZoomUp;
        private System.Windows.Forms.TabPage tabPage92;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.TextBox edPanStopTime;
        private System.Windows.Forms.Label label296;
        private System.Windows.Forms.TextBox edPanStartTime;
        private System.Windows.Forms.Label label297;
        private System.Windows.Forms.CheckBox cbPan;
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
        private System.Windows.Forms.TabPage tabPage25;
        private System.Windows.Forms.CheckBox cbBarcodeDetectionEnabled;
        private System.Windows.Forms.Button btBarcodeReset;
        private System.Windows.Forms.TextBox edBarcode;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.ComboBox cbBarcodeType;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox edBarcodeMetadata;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TabPage tabPage63;
        private System.Windows.Forms.TabControl tabControl19;
        private System.Windows.Forms.TabPage tabPage96;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.CheckBox cbUseAudioInputFromVideoCaptureDevice;
        private System.Windows.Forms.Button btAudioInputDeviceSettings;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage97;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TrackBar tbAudioBalance;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TrackBar tbAudioVolume;
        private System.Windows.Forms.CheckBox cbPlayAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage98;
        private System.Windows.Forms.TabPage tabPage99;
        private VisioForge.Controls.UI.WinForms.PeakMeterCtrl peakMeterCtrl1;
        private System.Windows.Forms.CheckBox cbVUMeter;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox cbRotate;
        private System.Windows.Forms.TextBox edCropRight;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox edCropBottom;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox edCropLeft;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox edCropTop;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox cbCrop;
        private System.Windows.Forms.ComboBox cbResizeMode;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.CheckBox cbResizeLetterbox;
        private System.Windows.Forms.TextBox edResizeHeight;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox edResizeWidth;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Label label318;
        private System.Windows.Forms.Button btAddAdditionalAudioSource;
        private System.Windows.Forms.ComboBox cbAdditionalAudioSource;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label319;
        private System.Windows.Forms.TabPage tabPage100;
        private System.Windows.Forms.TabPage tabPage101;
        private System.Windows.Forms.Label label326;
        private System.Windows.Forms.Label label325;
        private System.Windows.Forms.CheckBox cbVirtualCamera;
        private System.Windows.Forms.Label label328;
        private System.Windows.Forms.Label label327;
        private System.Windows.Forms.TabPage tabPage102;
        private System.Windows.Forms.RadioButton rbFadeOut;
        private System.Windows.Forms.RadioButton rbFadeIn;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.TextBox edFadeInOutStopTime;
        private System.Windows.Forms.Label label329;
        private System.Windows.Forms.TextBox edFadeInOutStartTime;
        private System.Windows.Forms.Label label330;
        private System.Windows.Forms.CheckBox cbFadeInOut;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TabPage tabPage103;
        private System.Windows.Forms.CheckBox cbDecklinkDV;
        private System.Windows.Forms.CheckBox cbDecklinkOutput;
        private System.Windows.Forms.ComboBox cbDecklinkOutputAnalog;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.ComboBox cbDecklinkOutputDualLink;
        private System.Windows.Forms.Label label331;
        private System.Windows.Forms.ComboBox cbDecklinkOutputNTSC;
        private System.Windows.Forms.Label label332;
        private System.Windows.Forms.ComboBox cbDecklinkOutputComponentLevels;
        private System.Windows.Forms.Label label333;
        private System.Windows.Forms.ComboBox cbDecklinkOutputHDTVPulldown;
        private System.Windows.Forms.Label label336;
        private System.Windows.Forms.ComboBox cbDecklinkOutputBlackToDeck;
        private System.Windows.Forms.Label label335;
        private System.Windows.Forms.ComboBox cbDecklinkOutputSingleField;
        private System.Windows.Forms.Label label334;
        private System.Windows.Forms.ComboBox cbDecklinkOutputDownConversion;
        private System.Windows.Forms.Label label337;
        private System.Windows.Forms.CheckBox cbDecklinkOutputDownConversionAnalogOutput;
        private System.Windows.Forms.TabPage tabPage105;
        private System.Windows.Forms.Button btBDAChannelScanningStart;
        private System.Windows.Forms.ListView lvBDAChannels;
        private System.Windows.Forms.Label label342;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.RadioButton rbScreenCaptureColorSource;
        private System.Windows.Forms.TabPage tabPage107;
        private System.Windows.Forms.CheckBox cbFaceTrackingEnabled;
        private System.Windows.Forms.CheckBox cbFaceTrackingCHL;
        private System.Windows.Forms.TextBox edFaceTrackingMinimumWindowSize;
        private System.Windows.Forms.Label label345;
        private System.Windows.Forms.ComboBox cbFaceTrackingColorMode;
        private System.Windows.Forms.Label label346;
        private System.Windows.Forms.ComboBox cbFaceTrackingSearchMode;
        private System.Windows.Forms.Label label361;
        private System.Windows.Forms.Label label362;
        private System.Windows.Forms.TextBox edFaceTrackingScaleFactor;
        private System.Windows.Forms.ComboBox cbFaceTrackingScalingMode;
        private System.Windows.Forms.Label label363;
        private System.Windows.Forms.TextBox edFaceTrackingFaces;
        private System.Windows.Forms.Label label364;
        private System.Windows.Forms.TabPage tpRTSP;
        private System.Windows.Forms.Label label366;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox edNetworkURL;
        private System.Windows.Forms.TextBox edNetworkRTSPURL;
        private System.Windows.Forms.Label label367;
        private System.Windows.Forms.ComboBox cbNetworkStreamingMode;
        private System.Windows.Forms.TabPage tpRTMP;
        private System.Windows.Forms.TextBox edNetworkRTMPURL;
        private System.Windows.Forms.Label label368;
        private System.Windows.Forms.Label label369;
        private System.Windows.Forms.TabPage tpSSF;
        private System.Windows.Forms.TextBox edNetworkSSURL;
        private System.Windows.Forms.Label label370;
        private System.Windows.Forms.Label label371;
        private System.Windows.Forms.RadioButton rbNetworkSSSoftware;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Label label376;
        private System.Windows.Forms.TextBox edSeparateCaptureFileSize;
        private System.Windows.Forms.Label label375;
        private System.Windows.Forms.Label label374;
        private System.Windows.Forms.TextBox edSeparateCaptureDuration;
        private System.Windows.Forms.Label label373;
        private System.Windows.Forms.RadioButton rbSeparateCaptureSplitBySize;
        private System.Windows.Forms.RadioButton rbSeparateCaptureSplitByDuration;
        private System.Windows.Forms.RadioButton rbSeparateCaptureStartManually;
        private System.Windows.Forms.CheckBox cbAutoFilename;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage112;
        private System.Windows.Forms.Label label381;
        private System.Windows.Forms.TrackBar tbVUMeterAmplification;
        private System.Windows.Forms.CheckBox cbVUMeterPro;
        private VolumeMeter volumeMeter1;
        private VolumeMeter volumeMeter2;
        private WaveformPainter waveformPainter2;
        private WaveformPainter waveformPainter1;
        private System.Windows.Forms.TrackBar tbVUMeterBoost;
        private System.Windows.Forms.Label label382;
        private System.Windows.Forms.TabPage tabPage114;
        private System.Windows.Forms.Label label392;
        private System.Windows.Forms.Label label391;
        private System.Windows.Forms.TrackBar tbLiveRotationAngle;
        private System.Windows.Forms.Label label390;
        private System.Windows.Forms.CheckBox cbLiveRotation;
        private System.Windows.Forms.CheckBox cbLiveRotationStretch;
        private System.Windows.Forms.TabControl tabControl26;
        private System.Windows.Forms.TabPage tabPage115;
        private System.Windows.Forms.CheckBox cbScreenFlipVertical;
        private System.Windows.Forms.CheckBox cbScreenFlipHorizontal;
        private System.Windows.Forms.CheckBox cbStretch;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbDirect2D;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbEVR;
        private System.Windows.Forms.RadioButton rbVMR9;
        private System.Windows.Forms.RadioButton rbVR;
        private System.Windows.Forms.TabPage tabPage116;
        private System.Windows.Forms.Label label393;
        private System.Windows.Forms.ComboBox cbDirect2DRotate;
        private System.Windows.Forms.Button btFullScreen;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.Button btZoomShiftRight;
        private System.Windows.Forms.Button btZoomShiftLeft;
        private System.Windows.Forms.Button btZoomOut;
        private System.Windows.Forms.Button btZoomIn;
        private System.Windows.Forms.Button btZoomShiftDown;
        private System.Windows.Forms.Button btZoomShiftUp;
        private System.Windows.Forms.Panel pnVideoRendererBGColor;
        private System.Windows.Forms.Label label394;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton rbAddAudioStreamsIndependent;
        private System.Windows.Forms.RadioButton rbAddAudioStreamsMix;
        private System.Windows.Forms.TabPage tabPage124;
        private System.Windows.Forms.TabControl tabControl28;
        private System.Windows.Forms.TabPage tabPage125;
        private System.Windows.Forms.ComboBox cbCustomVideoSourceFilter;
        private System.Windows.Forms.ComboBox cbCustomVideoSourceCategory;
        private System.Windows.Forms.Label label432;
        private System.Windows.Forms.TabPage tabPage126;
        private System.Windows.Forms.ComboBox cbCustomAudioSourceFilter;
        private System.Windows.Forms.Label label433;
        private System.Windows.Forms.ComboBox cbCustomAudioSourceCategory;
        private System.Windows.Forms.ComboBox cbCustomVideoSourceFormat;
        private System.Windows.Forms.Label label434;
        private System.Windows.Forms.Label label435;
        private System.Windows.Forms.Label label437;
        private System.Windows.Forms.ComboBox cbCustomAudioSourceFormat;
        private System.Windows.Forms.Label label436;
        private System.Windows.Forms.ComboBox cbCustomVideoSourceFrameRate;
        private System.Windows.Forms.Label label438;
        private System.Windows.Forms.TabPage tabPage127;
        private System.Windows.Forms.CheckBox cbAudioAutoGain;
        private System.Windows.Forms.CheckBox cbAudioNormalize;
        private System.Windows.Forms.CheckBox cbAudioEnhancementEnabled;
        private System.Windows.Forms.Label lbAudioTimeshift;
        private System.Windows.Forms.TrackBar tbAudioTimeshift;
        private System.Windows.Forms.Label label439;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbAudioOutputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioOutputGainLFE;
        private System.Windows.Forms.Label label440;
        private System.Windows.Forms.Label lbAudioOutputGainSR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSR;
        private System.Windows.Forms.Label label441;
        private System.Windows.Forms.Label lbAudioOutputGainSL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainSL;
        private System.Windows.Forms.Label label442;
        private System.Windows.Forms.Label lbAudioOutputGainR;
        private System.Windows.Forms.TrackBar tbAudioOutputGainR;
        private System.Windows.Forms.Label label443;
        private System.Windows.Forms.Label lbAudioOutputGainC;
        private System.Windows.Forms.TrackBar tbAudioOutputGainC;
        private System.Windows.Forms.Label label444;
        private System.Windows.Forms.Label lbAudioOutputGainL;
        private System.Windows.Forms.TrackBar tbAudioOutputGainL;
        private System.Windows.Forms.Label label445;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lbAudioInputGainLFE;
        private System.Windows.Forms.TrackBar tbAudioInputGainLFE;
        private System.Windows.Forms.Label label446;
        private System.Windows.Forms.Label lbAudioInputGainSR;
        private System.Windows.Forms.TrackBar tbAudioInputGainSR;
        private System.Windows.Forms.Label label447;
        private System.Windows.Forms.Label lbAudioInputGainSL;
        private System.Windows.Forms.TrackBar tbAudioInputGainSL;
        private System.Windows.Forms.Label label448;
        private System.Windows.Forms.Label lbAudioInputGainR;
        private System.Windows.Forms.TrackBar tbAudioInputGainR;
        private System.Windows.Forms.Label label449;
        private System.Windows.Forms.Label lbAudioInputGainC;
        private System.Windows.Forms.TrackBar tbAudioInputGainC;
        private System.Windows.Forms.Label label450;
        private System.Windows.Forms.Label lbAudioInputGainL;
        private System.Windows.Forms.TrackBar tbAudioInputGainL;
        private System.Windows.Forms.Label label451;
        private System.Windows.Forms.CheckBox cbScreenCapture_DesktopDuplication;
        private System.Windows.Forms.TabPage tpUDP;
        private System.Windows.Forms.RadioButton rbNetworkUDPFFMPEGCustom;
        private System.Windows.Forms.RadioButton rbNetworkUDPFFMPEG;
        private System.Windows.Forms.TextBox edNetworkUDPURL;
        private System.Windows.Forms.Label label372;
        private System.Windows.Forms.Label label484;
        private System.Windows.Forms.RadioButton rbNetworkRTMPFFMPEGCustom;
        private System.Windows.Forms.RadioButton rbNetworkRTMPFFMPEG;
        private System.Windows.Forms.CheckBox cbUseClosedCaptions;
        private System.Windows.Forms.TabPage tabPage141;
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
        private System.Windows.Forms.Label label250;
        private System.Windows.Forms.GroupBox groupBox44;
        private System.Windows.Forms.TextBox edPIPFileHeight;
        private System.Windows.Forms.Label label321;
        private System.Windows.Forms.TextBox edPIPFileWidth;
        private System.Windows.Forms.Label label322;
        private System.Windows.Forms.TextBox edPIPFileTop;
        private System.Windows.Forms.Label label323;
        private System.Windows.Forms.TextBox edPIPFileLeft;
        private System.Windows.Forms.Label label324;
        private System.Windows.Forms.Button btPIPFileSourceAdd;
        private System.Windows.Forms.Button btSelectPIPFile;
        private System.Windows.Forms.TextBox edPIPFileSoureFilename;
        private System.Windows.Forms.Label label320;
        private System.Windows.Forms.TabPage tabPage26;
        private System.Windows.Forms.CheckBox cbMotionDetectionEx;
        private System.Windows.Forms.ProgressBar pbAFMotionLevel;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cbDecklinkSourceTimecode;
        private System.Windows.Forms.Label label341;
        private System.Windows.Forms.ComboBox cbDecklinkSourceComponentLevels;
        private System.Windows.Forms.Label label339;
        private System.Windows.Forms.ComboBox cbDecklinkSourceNTSC;
        private System.Windows.Forms.Label label340;
        private System.Windows.Forms.ComboBox cbDecklinkSourceInput;
        private System.Windows.Forms.Label label338;
        private System.Windows.Forms.ComboBox cbDecklinkCaptureVideoFormat;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cbDecklinkCaptureDevice;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel9;
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGDefault;
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGCustom;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.Windows.Forms.TabPage tabPage93;
        private System.Windows.Forms.CheckBox cbAudioChannelMapperEnabled;
        private System.Windows.Forms.ListBox lbAudioChannelMapperRoutes;
        private System.Windows.Forms.Label label307;
        private System.Windows.Forms.TextBox edAudioChannelMapperOutputChannels;
        private System.Windows.Forms.Label label306;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button btAudioChannelMapperAddNewRoute;
        private System.Windows.Forms.Label label311;
        private System.Windows.Forms.TrackBar tbAudioChannelMapperVolume;
        private System.Windows.Forms.Label label310;
        private System.Windows.Forms.TextBox edAudioChannelMapperTargetChannel;
        private System.Windows.Forms.Label label309;
        private System.Windows.Forms.TextBox edAudioChannelMapperSourceChannel;
        private System.Windows.Forms.Label label308;
        private System.Windows.Forms.Button btAudioChannelMapperClear;
        private System.Windows.Forms.CheckBox cbDisableAllVideoProcessing;
        private System.Windows.Forms.CheckBox cbSeparateCaptureBridgeEngine;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.Label label314;
        private System.Windows.Forms.Label label313;
        private System.Windows.Forms.TabPage tpHLS;
        private System.Windows.Forms.Button btMPEGDemuxSettings;
        private System.Windows.Forms.ComboBox cbMPEGDemuxer;
        private System.Windows.Forms.Label label315;
        private System.Windows.Forms.ComboBox cbPIPResizeMode;
        private System.Windows.Forms.Label label317;
        private System.Windows.Forms.TabPage tabPage20;
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
        private System.Windows.Forms.Label label505;
        private System.Windows.Forms.ComboBox rbMotionDetectionExProcessor;
        private System.Windows.Forms.Label label389;
        private System.Windows.Forms.ComboBox rbMotionDetectionExDetector;
        private System.Windows.Forms.TabControl tabControl15;
        private System.Windows.Forms.TabPage tabPage144;
        private System.Windows.Forms.Button btShowIPCamDatabase;
        private System.Windows.Forms.CheckBox cbIPDisconnect;
        private System.Windows.Forms.TextBox edIPForcedFramerateID;
        private System.Windows.Forms.Label label344;
        private System.Windows.Forms.TextBox edIPForcedFramerate;
        private System.Windows.Forms.Label label295;
        private System.Windows.Forms.ComboBox cbIPCameraType;
        private System.Windows.Forms.TextBox edIPPassword;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.TextBox edIPLogin;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.CheckBox cbIPAudioCapture;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.TabPage tabPage146;
        private System.Windows.Forms.CheckBox cbVLCZeroClockJitter;
        private System.Windows.Forms.TextBox edVLCCacheSize;
        private System.Windows.Forms.Label label312;
        private System.Windows.Forms.TabPage tabPage145;
        private System.Windows.Forms.Button btONVIFConnect;
        private System.Windows.Forms.Label lbONVIFCameraInfo;
        private System.Windows.Forms.ComboBox cbONVIFProfile;
        private System.Windows.Forms.Label label510;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.Button btONVIFRight;
        private System.Windows.Forms.Button btONVIFLeft;
        private System.Windows.Forms.Button btONVIFZoomOut;
        private System.Windows.Forms.Button btONVIFZoomIn;
        private System.Windows.Forms.Button btONVIFDown;
        private System.Windows.Forms.Button btONVIFUp;
        private System.Windows.Forms.TextBox edONVIFLiveVideoURL;
        private System.Windows.Forms.Label label513;
        private System.Windows.Forms.Button btONVIFPTZSetDefault;
        private System.Windows.Forms.CheckBox cbIPCameraONVIF;
        private System.Windows.Forms.TabPage tabPage147;
        private System.Windows.Forms.Panel pnPIPChromaKeyColor;
        private System.Windows.Forms.Label label514;
        private System.Windows.Forms.Label lbPIPChromaKeyTolerance2;
        private System.Windows.Forms.Label label518;
        private System.Windows.Forms.TrackBar tbPIPChromaKeyTolerance2;
        private System.Windows.Forms.Label lbPIPChromaKeyTolerance1;
        private System.Windows.Forms.Label label515;
        private System.Windows.Forms.TrackBar tbPIPChromaKeyTolerance1;
        private System.Windows.Forms.TextBox edCustomVideoSourceURL;
        private System.Windows.Forms.Label label516;
        private System.Windows.Forms.TextBox edCustomAudioSourceURL;
        private System.Windows.Forms.Label label517;
        private System.Windows.Forms.TextBox edONVIFURL;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.TextBox edONVIFPassword;
        private System.Windows.Forms.Label label378;
        private System.Windows.Forms.TextBox edONVIFLogin;
        private System.Windows.Forms.Label label379;
        private System.Windows.Forms.CheckBox cbMultiscreenDrawOnExternalDisplays;
        private System.Windows.Forms.Button btSelectHLSOutputFolder;
        private System.Windows.Forms.TextBox edHLSOutputFolder;
        private System.Windows.Forms.Label label380;
        private System.Windows.Forms.Label label530;
        private System.Windows.Forms.Label label529;
        private System.Windows.Forms.TextBox edHLSSegmentCount;
        private System.Windows.Forms.Label label519;
        private System.Windows.Forms.TextBox edHLSSegmentDuration;
        private System.Windows.Forms.Label label532;
        private System.Windows.Forms.Label label531;
        private System.Windows.Forms.LinkLabel lbHLSConfigure;
        private System.Windows.Forms.Button btOutputConfigure;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btTextLogoRemove;
        private System.Windows.Forms.Button btTextLogoEdit;
        private System.Windows.Forms.ListBox lbTextLogos;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btImageLogoRemove;
        private System.Windows.Forms.Button btImageLogoEdit;
        private System.Windows.Forms.ListBox lbImageLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.CheckBox cbFlipX;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbCCTiltRelative;
        private System.Windows.Forms.CheckBox cbCCPanRelative;
        private System.Windows.Forms.Button btCCFocusApply;
        private System.Windows.Forms.Button btCCZoomApply;
        private System.Windows.Forms.CheckBox cbCCFocusRelative;
        private System.Windows.Forms.CheckBox cbCCFocusManual;
        private System.Windows.Forms.CheckBox cbCCFocusAuto;
        private System.Windows.Forms.Label lbCCFocusCurrent;
        private System.Windows.Forms.Label lbCCFocusMax;
        private System.Windows.Forms.Label lbCCFocusMin;
        private System.Windows.Forms.TrackBar tbCCFocus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCCZoomRelative;
        private System.Windows.Forms.CheckBox cbCCZoomManual;
        private System.Windows.Forms.CheckBox cbCCZoomAuto;
        private System.Windows.Forms.Label lbCCZoomCurrent;
        private System.Windows.Forms.Label lbCCZoomMax;
        private System.Windows.Forms.Label lbCCZoomMin;
        private System.Windows.Forms.TrackBar tbCCZoom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btVLCAddParameter;
        private System.Windows.Forms.Button btVLCClearParameters;
        private System.Windows.Forms.TextBox edVLCParameter;
        private System.Windows.Forms.ListBox lbVLCParameters;
        private System.Windows.Forms.CheckBox cbOSDEnabled;
        private System.Windows.Forms.CheckBox cbVideoEffectsGPUEnabled;
        private System.Windows.Forms.CheckedListBox lbOSDLayers;
        private System.Windows.Forms.Button btOSDRenderLayers;
        private System.Windows.Forms.Button btOSDClearLayer;
        internal System.Windows.Forms.Button btZoomReset;
        private System.Windows.Forms.Label lbScreenSourceWindowText;
        private System.Windows.Forms.Button btScreenSourceWindowSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbNetworkRTMPFFMPEGUsePipes;
        private System.Windows.Forms.CheckBox cbNetworkUDPFFMPEGUsePipes;
        private System.Windows.Forms.CheckBox cbNetworkSSUsePipes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbGPUBlur;
        private System.Windows.Forms.CheckBox cbMergeImageLogos;
        private System.Windows.Forms.CheckBox cbMergeTextLogos;
        private System.Windows.Forms.ComboBox cbHLSMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edHLSEmbeddedHTTPServerPort;
        private System.Windows.Forms.CheckBox cbHLSEmbeddedHTTPServerEnabled;
        private System.Windows.Forms.Label label19;
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
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.LinkLabel lbNDI;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tpNDI;
        private System.Windows.Forms.TextBox edNDIName;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox edNDIURL;
        private System.Windows.Forms.ComboBox cbIPURL;
        private System.Windows.Forms.Button btListNDISources;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox edHLSURL;
        private System.Windows.Forms.Button btListONVIFSources;
    }
}

