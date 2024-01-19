using System;

namespace VideoCapture_CSharp_Demo
{
    using VisioForge.Core.UI.WinForms.VolumeMeterPro;
    using VisioForge.Core.Types;

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

            mpegTSSettingsDialog?.Dispose();
            mpegTSSettingsDialog = null;

            mp4SettingsDialog?.Dispose();
            mp4SettingsDialog = null;

            mp4HWSettingsDialog?.Dispose();
            mp4HWSettingsDialog = null;

            mp3SettingsDialog?.Dispose();
            mp3SettingsDialog = null;

            movSettingsDialog?.Dispose();
            movSettingsDialog = null;

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

            windowCaptureForm?.Dispose();
            windowCaptureForm = null;

            screenshotSaveDialog?.Dispose();
            screenshotSaveDialog = null;

            tmRecording?.Dispose();
            tmRecording = null;

            VideoCapture1?.Dispose();
            VideoCapture1 = null;

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
            label8 = new System.Windows.Forms.Label();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            llXiphX64 = new System.Windows.Forms.LinkLabel();
            llXiphX86 = new System.Windows.Forms.LinkLabel();
            label68 = new System.Windows.Forms.Label();
            label67 = new System.Windows.Forms.Label();
            lbInfo = new System.Windows.Forms.Label();
            btOutputConfigure = new System.Windows.Forms.Button();
            cbAutoFilename = new System.Windows.Forms.CheckBox();
            cbOutputFormat = new System.Windows.Forms.ComboBox();
            btSelectOutput = new System.Windows.Forms.Button();
            edOutput = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            cbRecordAudio = new System.Windows.Forms.CheckBox();
            label7 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabControl17 = new System.Windows.Forms.TabControl();
            tabPage68 = new System.Windows.Forms.TabPage();
            cbScrollingText = new System.Windows.Forms.CheckBox();
            cbFlipY = new System.Windows.Forms.CheckBox();
            cbFlipX = new System.Windows.Forms.CheckBox();
            cbDisableAllVideoProcessing = new System.Windows.Forms.CheckBox();
            label201 = new System.Windows.Forms.Label();
            label200 = new System.Windows.Forms.Label();
            label199 = new System.Windows.Forms.Label();
            label198 = new System.Windows.Forms.Label();
            tabControl7 = new System.Windows.Forms.TabControl();
            tabPage29 = new System.Windows.Forms.TabPage();
            cbMergeTextLogos = new System.Windows.Forms.CheckBox();
            btTextLogoRemove = new System.Windows.Forms.Button();
            btTextLogoEdit = new System.Windows.Forms.Button();
            lbTextLogos = new System.Windows.Forms.ListBox();
            btTextLogoAdd = new System.Windows.Forms.Button();
            tabPage42 = new System.Windows.Forms.TabPage();
            cbMergeImageLogos = new System.Windows.Forms.CheckBox();
            btImageLogoRemove = new System.Windows.Forms.Button();
            btImageLogoEdit = new System.Windows.Forms.Button();
            lbImageLogos = new System.Windows.Forms.ListBox();
            btImageLogoAdd = new System.Windows.Forms.Button();
            tabPage91 = new System.Windows.Forms.TabPage();
            groupBox37 = new System.Windows.Forms.GroupBox();
            btEffZoomRight = new System.Windows.Forms.Button();
            btEffZoomLeft = new System.Windows.Forms.Button();
            btEffZoomOut = new System.Windows.Forms.Button();
            btEffZoomIn = new System.Windows.Forms.Button();
            btEffZoomDown = new System.Windows.Forms.Button();
            btEffZoomUp = new System.Windows.Forms.Button();
            cbZoom = new System.Windows.Forms.CheckBox();
            tabPage92 = new System.Windows.Forms.TabPage();
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
            tabPage102 = new System.Windows.Forms.TabPage();
            rbFadeOut = new System.Windows.Forms.RadioButton();
            rbFadeIn = new System.Windows.Forms.RadioButton();
            groupBox45 = new System.Windows.Forms.GroupBox();
            edFadeInOutStopTime = new System.Windows.Forms.TextBox();
            label329 = new System.Windows.Forms.Label();
            edFadeInOutStartTime = new System.Windows.Forms.TextBox();
            label330 = new System.Windows.Forms.Label();
            cbFadeInOut = new System.Windows.Forms.CheckBox();
            tabPage114 = new System.Windows.Forms.TabPage();
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
            tabPage20 = new System.Windows.Forms.TabPage();
            label5 = new System.Windows.Forms.Label();
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
            label92 = new System.Windows.Forms.Label();
            cbRotate = new System.Windows.Forms.ComboBox();
            edCropRight = new System.Windows.Forms.TextBox();
            label52 = new System.Windows.Forms.Label();
            edCropBottom = new System.Windows.Forms.TextBox();
            label53 = new System.Windows.Forms.Label();
            edCropLeft = new System.Windows.Forms.TextBox();
            label50 = new System.Windows.Forms.Label();
            edCropTop = new System.Windows.Forms.TextBox();
            label51 = new System.Windows.Forms.Label();
            cbCrop = new System.Windows.Forms.CheckBox();
            cbResizeMode = new System.Windows.Forms.ComboBox();
            label49 = new System.Windows.Forms.Label();
            cbResizeLetterbox = new System.Windows.Forms.CheckBox();
            edResizeHeight = new System.Windows.Forms.TextBox();
            label35 = new System.Windows.Forms.Label();
            edResizeWidth = new System.Windows.Forms.TextBox();
            label29 = new System.Windows.Forms.Label();
            cbResize = new System.Windows.Forms.CheckBox();
            tabPage60 = new System.Windows.Forms.TabPage();
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
            tabControl14 = new System.Windows.Forms.TabControl();
            tabPage5 = new System.Windows.Forms.TabPage();
            tabPage58 = new System.Windows.Forms.TabPage();
            tabPage127 = new System.Windows.Forms.TabPage();
            lbAudioTimeshift = new System.Windows.Forms.Label();
            tbAudioTimeshift = new System.Windows.Forms.TrackBar();
            label439 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            lbAudioOutputGainLFE = new System.Windows.Forms.Label();
            tbAudioOutputGainLFE = new System.Windows.Forms.TrackBar();
            label440 = new System.Windows.Forms.Label();
            lbAudioOutputGainSR = new System.Windows.Forms.Label();
            tbAudioOutputGainSR = new System.Windows.Forms.TrackBar();
            label441 = new System.Windows.Forms.Label();
            lbAudioOutputGainSL = new System.Windows.Forms.Label();
            tbAudioOutputGainSL = new System.Windows.Forms.TrackBar();
            label442 = new System.Windows.Forms.Label();
            lbAudioOutputGainR = new System.Windows.Forms.Label();
            tbAudioOutputGainR = new System.Windows.Forms.TrackBar();
            label443 = new System.Windows.Forms.Label();
            lbAudioOutputGainC = new System.Windows.Forms.Label();
            tbAudioOutputGainC = new System.Windows.Forms.TrackBar();
            label444 = new System.Windows.Forms.Label();
            lbAudioOutputGainL = new System.Windows.Forms.Label();
            tbAudioOutputGainL = new System.Windows.Forms.TrackBar();
            label445 = new System.Windows.Forms.Label();
            groupBox7 = new System.Windows.Forms.GroupBox();
            lbAudioInputGainLFE = new System.Windows.Forms.Label();
            tbAudioInputGainLFE = new System.Windows.Forms.TrackBar();
            label446 = new System.Windows.Forms.Label();
            lbAudioInputGainSR = new System.Windows.Forms.Label();
            tbAudioInputGainSR = new System.Windows.Forms.TrackBar();
            label447 = new System.Windows.Forms.Label();
            lbAudioInputGainSL = new System.Windows.Forms.Label();
            tbAudioInputGainSL = new System.Windows.Forms.TrackBar();
            label448 = new System.Windows.Forms.Label();
            lbAudioInputGainR = new System.Windows.Forms.Label();
            tbAudioInputGainR = new System.Windows.Forms.TrackBar();
            label449 = new System.Windows.Forms.Label();
            lbAudioInputGainC = new System.Windows.Forms.Label();
            tbAudioInputGainC = new System.Windows.Forms.TrackBar();
            label450 = new System.Windows.Forms.Label();
            lbAudioInputGainL = new System.Windows.Forms.Label();
            tbAudioInputGainL = new System.Windows.Forms.TrackBar();
            label451 = new System.Windows.Forms.Label();
            cbAudioAutoGain = new System.Windows.Forms.CheckBox();
            cbAudioNormalize = new System.Windows.Forms.CheckBox();
            cbAudioEnhancementEnabled = new System.Windows.Forms.CheckBox();
            tabPage27 = new System.Windows.Forms.TabPage();
            label250 = new System.Windows.Forms.Label();
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
            cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            tabPage93 = new System.Windows.Forms.TabPage();
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
            tabPage107 = new System.Windows.Forms.TabPage();
            edFaceTrackingFaces = new System.Windows.Forms.TextBox();
            label364 = new System.Windows.Forms.Label();
            label363 = new System.Windows.Forms.Label();
            cbFaceTrackingScalingMode = new System.Windows.Forms.ComboBox();
            label362 = new System.Windows.Forms.Label();
            edFaceTrackingScaleFactor = new System.Windows.Forms.TextBox();
            label361 = new System.Windows.Forms.Label();
            cbFaceTrackingSearchMode = new System.Windows.Forms.ComboBox();
            cbFaceTrackingColorMode = new System.Windows.Forms.ComboBox();
            label346 = new System.Windows.Forms.Label();
            edFaceTrackingMinimumWindowSize = new System.Windows.Forms.TextBox();
            label345 = new System.Windows.Forms.Label();
            cbFaceTrackingCHL = new System.Windows.Forms.CheckBox();
            cbFaceTrackingEnabled = new System.Windows.Forms.CheckBox();
            tabPage7 = new System.Windows.Forms.TabPage();
            cbNetworkStreamingMode = new System.Windows.Forms.ComboBox();
            tabControl5 = new System.Windows.Forms.TabControl();
            tpWMV = new System.Windows.Forms.TabPage();
            label48 = new System.Windows.Forms.Label();
            edNetworkURL = new System.Windows.Forms.TextBox();
            edWMVNetworkPort = new System.Windows.Forms.TextBox();
            label47 = new System.Windows.Forms.Label();
            btRefreshClients = new System.Windows.Forms.Button();
            lbNetworkClients = new System.Windows.Forms.ListBox();
            rbNetworkStreamingUseExternalProfile = new System.Windows.Forms.RadioButton();
            rbNetworkStreamingUseMainWMVSettings = new System.Windows.Forms.RadioButton();
            label81 = new System.Windows.Forms.Label();
            label80 = new System.Windows.Forms.Label();
            edMaximumClients = new System.Windows.Forms.TextBox();
            label46 = new System.Windows.Forms.Label();
            btSelectWMVProfileNetwork = new System.Windows.Forms.Button();
            edNetworkStreamingWMVProfile = new System.Windows.Forms.TextBox();
            label44 = new System.Windows.Forms.Label();
            tpRTSP = new System.Windows.Forms.TabPage();
            edNetworkRTSPURL = new System.Windows.Forms.TextBox();
            label367 = new System.Windows.Forms.Label();
            label366 = new System.Windows.Forms.Label();
            tpRTMP = new System.Windows.Forms.TabPage();
            groupBox4 = new System.Windows.Forms.GroupBox();
            rbNetworkRTMPGeneric = new System.Windows.Forms.RadioButton();
            edNetworkRTMPFacebook = new System.Windows.Forms.TextBox();
            rbNetworkRTMPFacebook = new System.Windows.Forms.RadioButton();
            edNetworkRTMPYouTube = new System.Windows.Forms.TextBox();
            rbNetworkRTMPYouTube = new System.Windows.Forms.RadioButton();
            edNetworkRTMPURL = new System.Windows.Forms.TextBox();
            label368 = new System.Windows.Forms.Label();
            cbNetworkRTMPFFMPEGUsePipes = new System.Windows.Forms.CheckBox();
            rbNetworkRTMPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkRTMPFFMPEG = new System.Windows.Forms.RadioButton();
            label369 = new System.Windows.Forms.Label();
            tpNDI = new System.Windows.Forms.TabPage();
            linkLabel6 = new System.Windows.Forms.LinkLabel();
            label38 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            edNDIURL = new System.Windows.Forms.TextBox();
            edNDIName = new System.Windows.Forms.TextBox();
            label30 = new System.Windows.Forms.Label();
            tpUDP = new System.Windows.Forms.TabPage();
            label63 = new System.Windows.Forms.Label();
            label62 = new System.Windows.Forms.Label();
            cbNetworkUDPFFMPEGUsePipes = new System.Windows.Forms.CheckBox();
            label314 = new System.Windows.Forms.Label();
            label313 = new System.Windows.Forms.Label();
            label484 = new System.Windows.Forms.Label();
            edNetworkUDPURL = new System.Windows.Forms.TextBox();
            label372 = new System.Windows.Forms.Label();
            rbNetworkUDPFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkUDPFFMPEG = new System.Windows.Forms.RadioButton();
            tpSSF = new System.Windows.Forms.TabPage();
            cbNetworkSSUsePipes = new System.Windows.Forms.CheckBox();
            rbNetworkSSFFMPEGCustom = new System.Windows.Forms.RadioButton();
            rbNetworkSSFFMPEGDefault = new System.Windows.Forms.RadioButton();
            linkLabel5 = new System.Windows.Forms.LinkLabel();
            edNetworkSSURL = new System.Windows.Forms.TextBox();
            label370 = new System.Windows.Forms.Label();
            label371 = new System.Windows.Forms.Label();
            rbNetworkSSSoftware = new System.Windows.Forms.RadioButton();
            tpHLS = new System.Windows.Forms.TabPage();
            label22 = new System.Windows.Forms.Label();
            edHLSURL = new System.Windows.Forms.TextBox();
            label19 = new System.Windows.Forms.Label();
            edHLSEmbeddedHTTPServerPort = new System.Windows.Forms.TextBox();
            cbHLSEmbeddedHTTPServerEnabled = new System.Windows.Forms.CheckBox();
            cbHLSMode = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
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
            tpNSExternal = new System.Windows.Forms.TabPage();
            linkLabel4 = new System.Windows.Forms.LinkLabel();
            linkLabel2 = new System.Windows.Forms.LinkLabel();
            tabPage3 = new System.Windows.Forms.TabPage();
            cbNetworkIcecastFFMPEGUsePipes = new System.Windows.Forms.CheckBox();
            edIcecastURL = new System.Windows.Forms.TextBox();
            label69 = new System.Windows.Forms.Label();
            tabPage6 = new System.Windows.Forms.TabPage();
            edMJPEGPort = new System.Windows.Forms.TextBox();
            label72 = new System.Windows.Forms.Label();
            cbNetworkStreamingAudioEnabled = new System.Windows.Forms.CheckBox();
            cbNetworkStreaming = new System.Windows.Forms.CheckBox();
            tabPage28 = new System.Windows.Forms.TabPage();
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
            tabPage43 = new System.Windows.Forms.TabPage();
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
            tabPage26 = new System.Windows.Forms.TabPage();
            label505 = new System.Windows.Forms.Label();
            rbMotionDetectionExProcessor = new System.Windows.Forms.ComboBox();
            label389 = new System.Windows.Forms.Label();
            rbMotionDetectionExDetector = new System.Windows.Forms.ComboBox();
            label64 = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            cbMotionDetectionEx = new System.Windows.Forms.CheckBox();
            tabPage25 = new System.Windows.Forms.TabPage();
            edBarcodeMetadata = new System.Windows.Forms.TextBox();
            label91 = new System.Windows.Forms.Label();
            cbBarcodeType = new System.Windows.Forms.ComboBox();
            label90 = new System.Windows.Forms.Label();
            btBarcodeReset = new System.Windows.Forms.Button();
            edBarcode = new System.Windows.Forms.TextBox();
            label89 = new System.Windows.Forms.Label();
            cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            tabPage101 = new System.Windows.Forms.TabPage();
            btVirtualCameraRegister = new System.Windows.Forms.Button();
            label328 = new System.Windows.Forms.Label();
            label327 = new System.Windows.Forms.Label();
            label326 = new System.Windows.Forms.Label();
            label325 = new System.Windows.Forms.Label();
            cbVirtualCamera = new System.Windows.Forms.CheckBox();
            tabPage103 = new System.Windows.Forms.TabPage();
            label71 = new System.Windows.Forms.Label();
            label70 = new System.Windows.Forms.Label();
            cbDecklinkOutputAudioRenderer = new System.Windows.Forms.ComboBox();
            cbDecklinkOutputVideoRenderer = new System.Windows.Forms.ComboBox();
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
            tabPage141 = new System.Windows.Forms.TabPage();
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
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            cbMode = new System.Windows.Forms.ComboBox();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            tabControl10 = new System.Windows.Forms.TabControl();
            tabPage46 = new System.Windows.Forms.TabPage();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabPage8 = new System.Windows.Forms.TabPage();
            btSignal = new System.Windows.Forms.Button();
            label28 = new System.Windows.Forms.Label();
            cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            btVideoCaptureDeviceSettings = new System.Windows.Forms.Button();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tabPage52 = new System.Windows.Forms.TabPage();
            cbCrossBarAvailable = new System.Windows.Forms.CheckBox();
            lbRotes = new System.Windows.Forms.ListBox();
            label61 = new System.Windows.Forms.Label();
            label60 = new System.Windows.Forms.Label();
            cbConnectRelated = new System.Windows.Forms.CheckBox();
            btConnect = new System.Windows.Forms.Button();
            cbCrossbarVideoInput = new System.Windows.Forms.ComboBox();
            label59 = new System.Windows.Forms.Label();
            rbCrossbarAdvanced = new System.Windows.Forms.RadioButton();
            rbCrossbarSimple = new System.Windows.Forms.RadioButton();
            cbCrossbarOutput = new System.Windows.Forms.ComboBox();
            cbCrossbarInput = new System.Windows.Forms.ComboBox();
            label16 = new System.Windows.Forms.Label();
            tabPage10 = new System.Windows.Forms.TabPage();
            tabControl3 = new System.Windows.Forms.TabControl();
            tabPage14 = new System.Windows.Forms.TabPage();
            cbUseClosedCaptions = new System.Windows.Forms.CheckBox();
            edTVDefaultFormat = new System.Windows.Forms.TextBox();
            label57 = new System.Windows.Forms.Label();
            cbTVCountry = new System.Windows.Forms.ComboBox();
            label56 = new System.Windows.Forms.Label();
            cbTVMode = new System.Windows.Forms.ComboBox();
            cbTVInput = new System.Windows.Forms.ComboBox();
            cbTVTuner = new System.Windows.Forms.ComboBox();
            label33 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            tabPage15 = new System.Windows.Forms.TabPage();
            edChannel = new System.Windows.Forms.TextBox();
            btUseThisChannel = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            cbTVChannel = new System.Windows.Forms.ComboBox();
            label58 = new System.Windows.Forms.Label();
            pbChannels = new System.Windows.Forms.ProgressBar();
            btStopTune = new System.Windows.Forms.Button();
            btStartTune = new System.Windows.Forms.Button();
            cbTVSystem = new System.Windows.Forms.ComboBox();
            edAudioFreq = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            edVideoFreq = new System.Windows.Forms.TextBox();
            label37 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            tabPage21 = new System.Windows.Forms.TabPage();
            btMPEGEncoderShowDialog = new System.Windows.Forms.Button();
            cbMPEGEncoder = new System.Windows.Forms.ComboBox();
            label21 = new System.Windows.Forms.Label();
            tabPage11 = new System.Windows.Forms.TabPage();
            groupBox21 = new System.Windows.Forms.GroupBox();
            rbDVResDC = new System.Windows.Forms.RadioButton();
            rbDVResQuarter = new System.Windows.Forms.RadioButton();
            rbDVResHalf = new System.Windows.Forms.RadioButton();
            rbDVResFull = new System.Windows.Forms.RadioButton();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btDVStepFWD = new System.Windows.Forms.Button();
            btDVStepRev = new System.Windows.Forms.Button();
            btDVFF = new System.Windows.Forms.Button();
            btDVStop = new System.Windows.Forms.Button();
            btDVPause = new System.Windows.Forms.Button();
            btDVPlay = new System.Windows.Forms.Button();
            btDVRewind = new System.Windows.Forms.Button();
            tabPage57 = new System.Windows.Forms.TabPage();
            lbAdjSaturationCurrent = new System.Windows.Forms.Label();
            lbAdjSaturationMax = new System.Windows.Forms.Label();
            cbAdjSaturationAuto = new System.Windows.Forms.CheckBox();
            lbAdjSaturationMin = new System.Windows.Forms.Label();
            tbAdjSaturation = new System.Windows.Forms.TrackBar();
            label45 = new System.Windows.Forms.Label();
            lbAdjHueCurrent = new System.Windows.Forms.Label();
            lbAdjHueMax = new System.Windows.Forms.Label();
            cbAdjHueAuto = new System.Windows.Forms.CheckBox();
            lbAdjHueMin = new System.Windows.Forms.Label();
            tbAdjHue = new System.Windows.Forms.TrackBar();
            label41 = new System.Windows.Forms.Label();
            lbAdjContrastCurrent = new System.Windows.Forms.Label();
            lbAdjContrastMax = new System.Windows.Forms.Label();
            cbAdjContrastAuto = new System.Windows.Forms.CheckBox();
            lbAdjContrastMin = new System.Windows.Forms.Label();
            tbAdjContrast = new System.Windows.Forms.TrackBar();
            label23 = new System.Windows.Forms.Label();
            lbAdjBrightnessCurrent = new System.Windows.Forms.Label();
            lbAdjBrightnessMax = new System.Windows.Forms.Label();
            cbAdjBrightnessAuto = new System.Windows.Forms.CheckBox();
            lbAdjBrightnessMin = new System.Windows.Forms.Label();
            tbAdjBrightness = new System.Windows.Forms.TrackBar();
            label17 = new System.Windows.Forms.Label();
            tabPage66 = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            btCCFocusApply = new System.Windows.Forms.Button();
            btCCZoomApply = new System.Windows.Forms.Button();
            cbCCFocusRelative = new System.Windows.Forms.CheckBox();
            cbCCFocusManual = new System.Windows.Forms.CheckBox();
            cbCCFocusAuto = new System.Windows.Forms.CheckBox();
            lbCCFocusCurrent = new System.Windows.Forms.Label();
            lbCCFocusMax = new System.Windows.Forms.Label();
            lbCCFocusMin = new System.Windows.Forms.Label();
            tbCCFocus = new System.Windows.Forms.TrackBar();
            label4 = new System.Windows.Forms.Label();
            cbCCZoomRelative = new System.Windows.Forms.CheckBox();
            cbCCZoomManual = new System.Windows.Forms.CheckBox();
            cbCCZoomAuto = new System.Windows.Forms.CheckBox();
            lbCCZoomCurrent = new System.Windows.Forms.Label();
            lbCCZoomMax = new System.Windows.Forms.Label();
            lbCCZoomMin = new System.Windows.Forms.Label();
            tbCCZoom = new System.Windows.Forms.TrackBar();
            label20 = new System.Windows.Forms.Label();
            btCCTiltApply = new System.Windows.Forms.Button();
            btCCPanApply = new System.Windows.Forms.Button();
            cbCCTiltRelative = new System.Windows.Forms.CheckBox();
            cbCCTiltManual = new System.Windows.Forms.CheckBox();
            cbCCTiltAuto = new System.Windows.Forms.CheckBox();
            lbCCTiltCurrent = new System.Windows.Forms.Label();
            lbCCTiltMax = new System.Windows.Forms.Label();
            lbCCTiltMin = new System.Windows.Forms.Label();
            tbCCTilt = new System.Windows.Forms.TrackBar();
            label97 = new System.Windows.Forms.Label();
            cbCCPanRelative = new System.Windows.Forms.CheckBox();
            cbCCPanManual = new System.Windows.Forms.CheckBox();
            cbCCPanAuto = new System.Windows.Forms.CheckBox();
            btCCReadValues = new System.Windows.Forms.Button();
            lbCCPanCurrent = new System.Windows.Forms.Label();
            lbCCPanMax = new System.Windows.Forms.Label();
            lbCCPanMin = new System.Windows.Forms.Label();
            tbCCPan = new System.Windows.Forms.TrackBar();
            label96 = new System.Windows.Forms.Label();
            tabPage63 = new System.Windows.Forms.TabPage();
            tabControl19 = new System.Windows.Forms.TabControl();
            tabPage96 = new System.Windows.Forms.TabPage();
            cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            cbAudioInputLine = new System.Windows.Forms.ComboBox();
            cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            tabPage97 = new System.Windows.Forms.TabPage();
            label55 = new System.Windows.Forms.Label();
            tbAudioBalance = new System.Windows.Forms.TrackBar();
            label54 = new System.Windows.Forms.Label();
            tbAudioVolume = new System.Windows.Forms.TrackBar();
            cbPlayAudio = new System.Windows.Forms.CheckBox();
            cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            label15 = new System.Windows.Forms.Label();
            tabPage98 = new System.Windows.Forms.TabPage();
            cbVUMeter = new System.Windows.Forms.CheckBox();
            peakMeterCtrl1 = new VisioForge.Core.UI.WinForms.PeakMeterCtrl();
            tabPage112 = new System.Windows.Forms.TabPage();
            tbVUMeterBoost = new System.Windows.Forms.TrackBar();
            label382 = new System.Windows.Forms.Label();
            label381 = new System.Windows.Forms.Label();
            tbVUMeterAmplification = new System.Windows.Forms.TrackBar();
            cbVUMeterPro = new System.Windows.Forms.CheckBox();
            waveformPainter2 = new WaveformPainter();
            waveformPainter1 = new WaveformPainter();
            volumeMeter2 = new VolumeMeter();
            volumeMeter1 = new VolumeMeter();
            tabPage99 = new System.Windows.Forms.TabPage();
            rbAddAudioStreamsIndependent = new System.Windows.Forms.RadioButton();
            rbAddAudioStreamsMix = new System.Windows.Forms.RadioButton();
            label319 = new System.Windows.Forms.Label();
            label318 = new System.Windows.Forms.Label();
            btAddAdditionalAudioSource = new System.Windows.Forms.Button();
            cbAdditionalAudioSource = new System.Windows.Forms.ComboBox();
            label180 = new System.Windows.Forms.Label();
            tabPage47 = new System.Windows.Forms.TabPage();
            label3 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            lbScreenSourceWindowText = new System.Windows.Forms.Label();
            btScreenSourceWindowSelect = new System.Windows.Forms.Button();
            cbScreenCapture_DesktopDuplication = new System.Windows.Forms.CheckBox();
            rbScreenCaptureColorSource = new System.Windows.Forms.RadioButton();
            rbScreenCaptureWindow = new System.Windows.Forms.RadioButton();
            cbScreenCaptureDisplayIndex = new System.Windows.Forms.ComboBox();
            label93 = new System.Windows.Forms.Label();
            btScreenCaptureUpdate = new System.Windows.Forms.Button();
            cbScreenCapture_GrabMouseCursor = new System.Windows.Forms.CheckBox();
            label79 = new System.Windows.Forms.Label();
            edScreenFrameRate = new System.Windows.Forms.TextBox();
            label43 = new System.Windows.Forms.Label();
            edScreenBottom = new System.Windows.Forms.TextBox();
            label42 = new System.Windows.Forms.Label();
            edScreenRight = new System.Windows.Forms.TextBox();
            label40 = new System.Windows.Forms.Label();
            edScreenTop = new System.Windows.Forms.TextBox();
            label26 = new System.Windows.Forms.Label();
            edScreenLeft = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            rbScreenCustomArea = new System.Windows.Forms.RadioButton();
            rbScreenFullScreen = new System.Windows.Forms.RadioButton();
            tabPage48 = new System.Windows.Forms.TabPage();
            tabControl15 = new System.Windows.Forms.TabControl();
            tabPage144 = new System.Windows.Forms.TabPage();
            btListONVIFSources = new System.Windows.Forms.Button();
            cbIPURL = new System.Windows.Forms.ComboBox();
            btListNDISources = new System.Windows.Forms.Button();
            lbNDI = new System.Windows.Forms.LinkLabel();
            label25 = new System.Windows.Forms.Label();
            label165 = new System.Windows.Forms.Label();
            cbIPCameraONVIF = new System.Windows.Forms.CheckBox();
            cbIPDisconnect = new System.Windows.Forms.CheckBox();
            edIPForcedFramerateID = new System.Windows.Forms.TextBox();
            label344 = new System.Windows.Forms.Label();
            edIPForcedFramerate = new System.Windows.Forms.TextBox();
            label295 = new System.Windows.Forms.Label();
            cbIPCameraType = new System.Windows.Forms.ComboBox();
            edIPPassword = new System.Windows.Forms.TextBox();
            label167 = new System.Windows.Forms.Label();
            edIPLogin = new System.Windows.Forms.TextBox();
            label166 = new System.Windows.Forms.Label();
            cbIPAudioCapture = new System.Windows.Forms.CheckBox();
            label168 = new System.Windows.Forms.Label();
            tabPage146 = new System.Windows.Forms.TabPage();
            btVLCAddParameter = new System.Windows.Forms.Button();
            btVLCClearParameters = new System.Windows.Forms.Button();
            edVLCParameter = new System.Windows.Forms.TextBox();
            lbVLCParameters = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            cbVLCZeroClockJitter = new System.Windows.Forms.CheckBox();
            edVLCCacheSize = new System.Windows.Forms.TextBox();
            label312 = new System.Windows.Forms.Label();
            tabPage145 = new System.Windows.Forms.TabPage();
            edONVIFPassword = new System.Windows.Forms.TextBox();
            label378 = new System.Windows.Forms.Label();
            edONVIFLogin = new System.Windows.Forms.TextBox();
            label379 = new System.Windows.Forms.Label();
            edONVIFURL = new System.Windows.Forms.TextBox();
            edONVIFLiveVideoURL = new System.Windows.Forms.TextBox();
            label513 = new System.Windows.Forms.Label();
            groupBox42 = new System.Windows.Forms.GroupBox();
            btONVIFPTZSetDefault = new System.Windows.Forms.Button();
            btONVIFRight = new System.Windows.Forms.Button();
            btONVIFLeft = new System.Windows.Forms.Button();
            btONVIFZoomOut = new System.Windows.Forms.Button();
            btONVIFZoomIn = new System.Windows.Forms.Button();
            btONVIFDown = new System.Windows.Forms.Button();
            btONVIFUp = new System.Windows.Forms.Button();
            cbONVIFProfile = new System.Windows.Forms.ComboBox();
            label510 = new System.Windows.Forms.Label();
            lbONVIFCameraInfo = new System.Windows.Forms.Label();
            btONVIFConnect = new System.Windows.Forms.Button();
            tabPage4 = new System.Windows.Forms.TabPage();
            cbDecklinkCaptureVideoFormat = new System.Windows.Forms.ComboBox();
            label66 = new System.Windows.Forms.Label();
            cbDecklinkCaptureDevice = new System.Windows.Forms.ComboBox();
            label39 = new System.Windows.Forms.Label();
            cbDecklinkSourceTimecode = new System.Windows.Forms.ComboBox();
            label341 = new System.Windows.Forms.Label();
            cbDecklinkSourceComponentLevels = new System.Windows.Forms.ComboBox();
            label339 = new System.Windows.Forms.Label();
            cbDecklinkSourceNTSC = new System.Windows.Forms.ComboBox();
            label340 = new System.Windows.Forms.Label();
            cbDecklinkSourceInput = new System.Windows.Forms.ComboBox();
            label338 = new System.Windows.Forms.Label();
            tabPage81 = new System.Windows.Forms.TabPage();
            tabControl22 = new System.Windows.Forms.TabControl();
            tabPage82 = new System.Windows.Forms.TabPage();
            cbBDADeviceStandard = new System.Windows.Forms.ComboBox();
            label129 = new System.Windows.Forms.Label();
            cbBDAReceiver = new System.Windows.Forms.ComboBox();
            label270 = new System.Windows.Forms.Label();
            cbBDASourceDevice = new System.Windows.Forms.ComboBox();
            label272 = new System.Windows.Forms.Label();
            tabPage83 = new System.Windows.Forms.TabPage();
            tabControl23 = new System.Windows.Forms.TabControl();
            tabPage84 = new System.Windows.Forms.TabPage();
            btDVBTTune = new System.Windows.Forms.Button();
            edDVBTSID = new System.Windows.Forms.TextBox();
            edDVBTTSID = new System.Windows.Forms.TextBox();
            edDVBTONID = new System.Windows.Forms.TextBox();
            label273 = new System.Windows.Forms.Label();
            edDVBTFrequency = new System.Windows.Forms.TextBox();
            label274 = new System.Windows.Forms.Label();
            label275 = new System.Windows.Forms.Label();
            label276 = new System.Windows.Forms.Label();
            label277 = new System.Windows.Forms.Label();
            tabPage85 = new System.Windows.Forms.TabPage();
            cbDVBSPolarisation = new System.Windows.Forms.ComboBox();
            label278 = new System.Windows.Forms.Label();
            edDVBSSymbolRate = new System.Windows.Forms.TextBox();
            label279 = new System.Windows.Forms.Label();
            btDVBSTune = new System.Windows.Forms.Button();
            edDVBSSID = new System.Windows.Forms.TextBox();
            edDVBSTSID = new System.Windows.Forms.TextBox();
            edDVBSONIT = new System.Windows.Forms.TextBox();
            label280 = new System.Windows.Forms.Label();
            edDVBSFrequency = new System.Windows.Forms.TextBox();
            label281 = new System.Windows.Forms.Label();
            label282 = new System.Windows.Forms.Label();
            label283 = new System.Windows.Forms.Label();
            label284 = new System.Windows.Forms.Label();
            tabPage86 = new System.Windows.Forms.TabPage();
            groupBox35 = new System.Windows.Forms.GroupBox();
            edDVBCMinorChannel = new System.Windows.Forms.TextBox();
            label285 = new System.Windows.Forms.Label();
            edDVBCPhysicalChannel = new System.Windows.Forms.TextBox();
            label286 = new System.Windows.Forms.Label();
            edDVBCVirtualChannel = new System.Windows.Forms.TextBox();
            label287 = new System.Windows.Forms.Label();
            groupBox36 = new System.Windows.Forms.GroupBox();
            edDVBCSymbolRate = new System.Windows.Forms.TextBox();
            label288 = new System.Windows.Forms.Label();
            edDVBCProgramNumber = new System.Windows.Forms.TextBox();
            label289 = new System.Windows.Forms.Label();
            cbDVBCModulation = new System.Windows.Forms.ComboBox();
            label290 = new System.Windows.Forms.Label();
            label291 = new System.Windows.Forms.Label();
            edDVBCCarrierFrequency = new System.Windows.Forms.TextBox();
            label292 = new System.Windows.Forms.Label();
            btBDADVBCTune = new System.Windows.Forms.Button();
            tabPage87 = new System.Windows.Forms.TabPage();
            label293 = new System.Windows.Forms.Label();
            tabPage105 = new System.Windows.Forms.TabPage();
            btBDAChannelScanningStart = new System.Windows.Forms.Button();
            lvBDAChannels = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            label342 = new System.Windows.Forms.Label();
            tabPage49 = new System.Windows.Forms.TabPage();
            tabControl20 = new System.Windows.Forms.TabControl();
            tabPage67 = new System.Windows.Forms.TabPage();
            tabControl21 = new System.Windows.Forms.TabControl();
            tabPage78 = new System.Windows.Forms.TabPage();
            btPIPAddDevice = new System.Windows.Forms.Button();
            groupBox30 = new System.Windows.Forms.GroupBox();
            edPIPVidCapHeight = new System.Windows.Forms.TextBox();
            label94 = new System.Windows.Forms.Label();
            edPIPVidCapWidth = new System.Windows.Forms.TextBox();
            label98 = new System.Windows.Forms.Label();
            edPIPVidCapTop = new System.Windows.Forms.TextBox();
            label99 = new System.Windows.Forms.Label();
            edPIPVidCapLeft = new System.Windows.Forms.TextBox();
            label100 = new System.Windows.Forms.Label();
            cbPIPInput = new System.Windows.Forms.ComboBox();
            label170 = new System.Windows.Forms.Label();
            cbPIPFrameRate = new System.Windows.Forms.ComboBox();
            label128 = new System.Windows.Forms.Label();
            cbPIPFormatUseBest = new System.Windows.Forms.CheckBox();
            cbPIPFormat = new System.Windows.Forms.ComboBox();
            label127 = new System.Windows.Forms.Label();
            label126 = new System.Windows.Forms.Label();
            cbPIPDevice = new System.Windows.Forms.ComboBox();
            label125 = new System.Windows.Forms.Label();
            tabPage79 = new System.Windows.Forms.TabPage();
            groupBox31 = new System.Windows.Forms.GroupBox();
            edPIPIPCapHeight = new System.Windows.Forms.TextBox();
            label101 = new System.Windows.Forms.Label();
            edPIPIPCapWidth = new System.Windows.Forms.TextBox();
            label102 = new System.Windows.Forms.Label();
            edPIPIPCapTop = new System.Windows.Forms.TextBox();
            label103 = new System.Windows.Forms.Label();
            edPIPIPCapLeft = new System.Windows.Forms.TextBox();
            label229 = new System.Windows.Forms.Label();
            btPIPAddIPCamera = new System.Windows.Forms.Button();
            tabPage80 = new System.Windows.Forms.TabPage();
            groupBox32 = new System.Windows.Forms.GroupBox();
            edPIPScreenCapHeight = new System.Windows.Forms.TextBox();
            label256 = new System.Windows.Forms.Label();
            edPIPScreenCapWidth = new System.Windows.Forms.TextBox();
            label260 = new System.Windows.Forms.Label();
            edPIPScreenCapTop = new System.Windows.Forms.TextBox();
            label266 = new System.Windows.Forms.Label();
            edPIPScreenCapLeft = new System.Windows.Forms.TextBox();
            label268 = new System.Windows.Forms.Label();
            btPIPAddScreenCapture = new System.Windows.Forms.Button();
            tabPage100 = new System.Windows.Forms.TabPage();
            groupBox44 = new System.Windows.Forms.GroupBox();
            edPIPFileHeight = new System.Windows.Forms.TextBox();
            label321 = new System.Windows.Forms.Label();
            edPIPFileWidth = new System.Windows.Forms.TextBox();
            label322 = new System.Windows.Forms.Label();
            edPIPFileTop = new System.Windows.Forms.TextBox();
            label323 = new System.Windows.Forms.Label();
            edPIPFileLeft = new System.Windows.Forms.TextBox();
            label324 = new System.Windows.Forms.Label();
            btPIPFileSourceAdd = new System.Windows.Forms.Button();
            btSelectPIPFile = new System.Windows.Forms.Button();
            edPIPFileSoureFilename = new System.Windows.Forms.TextBox();
            label320 = new System.Windows.Forms.Label();
            tabPage77 = new System.Windows.Forms.TabPage();
            cbPIPResizeMode = new System.Windows.Forms.ComboBox();
            label317 = new System.Windows.Forms.Label();
            groupBox34 = new System.Windows.Forms.GroupBox();
            btPIPSet = new System.Windows.Forms.Button();
            tbPIPTransparency = new System.Windows.Forms.TrackBar();
            groupBox33 = new System.Windows.Forms.GroupBox();
            btPIPSetOutputSize = new System.Windows.Forms.Button();
            edPIPOutputHeight = new System.Windows.Forms.TextBox();
            label269 = new System.Windows.Forms.Label();
            edPIPOutputWidth = new System.Windows.Forms.TextBox();
            label271 = new System.Windows.Forms.Label();
            cbPIPDevices = new System.Windows.Forms.ComboBox();
            cbPIPMode = new System.Windows.Forms.ComboBox();
            label169 = new System.Windows.Forms.Label();
            btPIPDevicesClear = new System.Windows.Forms.Button();
            label134 = new System.Windows.Forms.Label();
            groupBox20 = new System.Windows.Forms.GroupBox();
            btPIPUpdate = new System.Windows.Forms.Button();
            edPIPHeight = new System.Windows.Forms.TextBox();
            label132 = new System.Windows.Forms.Label();
            edPIPWidth = new System.Windows.Forms.TextBox();
            label133 = new System.Windows.Forms.Label();
            edPIPTop = new System.Windows.Forms.TextBox();
            label130 = new System.Windows.Forms.Label();
            edPIPLeft = new System.Windows.Forms.TextBox();
            label131 = new System.Windows.Forms.Label();
            tabPage147 = new System.Windows.Forms.TabPage();
            lbPIPChromaKeyTolerance2 = new System.Windows.Forms.Label();
            label518 = new System.Windows.Forms.Label();
            tbPIPChromaKeyTolerance2 = new System.Windows.Forms.TrackBar();
            lbPIPChromaKeyTolerance1 = new System.Windows.Forms.Label();
            label515 = new System.Windows.Forms.Label();
            tbPIPChromaKeyTolerance1 = new System.Windows.Forms.TrackBar();
            pnPIPChromaKeyColor = new System.Windows.Forms.Panel();
            label514 = new System.Windows.Forms.Label();
            tabPage50 = new System.Windows.Forms.TabPage();
            cbMultiscreenDrawOnExternalDisplays = new System.Windows.Forms.CheckBox();
            cbFlipHorizontal3 = new System.Windows.Forms.CheckBox();
            cbFlipVertical3 = new System.Windows.Forms.CheckBox();
            cbStretch3 = new System.Windows.Forms.CheckBox();
            cbFlipHorizontal2 = new System.Windows.Forms.CheckBox();
            cbFlipVertical2 = new System.Windows.Forms.CheckBox();
            cbStretch2 = new System.Windows.Forms.CheckBox();
            cbFlipHorizontal1 = new System.Windows.Forms.CheckBox();
            cbFlipVertical1 = new System.Windows.Forms.CheckBox();
            cbStretch1 = new System.Windows.Forms.CheckBox();
            pnScreen3 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            pnScreen2 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            pnScreen1 = new System.Windows.Forms.Panel();
            cbMultiscreenDrawOnPanels = new System.Windows.Forms.CheckBox();
            tabPage51 = new System.Windows.Forms.TabPage();
            tabControl26 = new System.Windows.Forms.TabControl();
            tabPage115 = new System.Windows.Forms.TabPage();
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
            rbDirect2D = new System.Windows.Forms.RadioButton();
            rbNone = new System.Windows.Forms.RadioButton();
            rbEVR = new System.Windows.Forms.RadioButton();
            rbVMR9 = new System.Windows.Forms.RadioButton();
            tabPage116 = new System.Windows.Forms.TabPage();
            label393 = new System.Windows.Forms.Label();
            cbDirect2DRotate = new System.Windows.Forms.ComboBox();
            tabPage12 = new System.Windows.Forms.TabPage();
            cbSeparateCaptureBridgeEngine = new System.Windows.Forms.CheckBox();
            label376 = new System.Windows.Forms.Label();
            edSeparateCaptureFileSize = new System.Windows.Forms.TextBox();
            label375 = new System.Windows.Forms.Label();
            label374 = new System.Windows.Forms.Label();
            edSeparateCaptureDuration = new System.Windows.Forms.TextBox();
            label373 = new System.Windows.Forms.Label();
            rbSeparateCaptureSplitBySize = new System.Windows.Forms.RadioButton();
            rbSeparateCaptureSplitByDuration = new System.Windows.Forms.RadioButton();
            rbSeparateCaptureStartManually = new System.Windows.Forms.RadioButton();
            btSeparateCaptureResume = new System.Windows.Forms.Button();
            btSeparateCapturePause = new System.Windows.Forms.Button();
            groupBox8 = new System.Windows.Forms.GroupBox();
            btSeparateCaptureChangeFilename = new System.Windows.Forms.Button();
            edNewFilename = new System.Windows.Forms.TextBox();
            label84 = new System.Windows.Forms.Label();
            btSeparateCaptureStop = new System.Windows.Forms.Button();
            btSeparateCaptureStart = new System.Windows.Forms.Button();
            cbSeparateCaptureEnabled = new System.Windows.Forms.CheckBox();
            label83 = new System.Windows.Forms.Label();
            label82 = new System.Windows.Forms.Label();
            tabPage88 = new System.Windows.Forms.TabPage();
            btMPEGDemuxSettings = new System.Windows.Forms.Button();
            cbMPEGDemuxer = new System.Windows.Forms.ComboBox();
            label315 = new System.Windows.Forms.Label();
            btMPEGAudDecSettings = new System.Windows.Forms.Button();
            cbMPEGAudioDecoder = new System.Windows.Forms.ComboBox();
            label121 = new System.Windows.Forms.Label();
            btMPEGVidDecSetting = new System.Windows.Forms.Button();
            cbMPEGVideoDecoder = new System.Windows.Forms.ComboBox();
            label120 = new System.Windows.Forms.Label();
            tabPage124 = new System.Windows.Forms.TabPage();
            tabControl28 = new System.Windows.Forms.TabControl();
            tabPage125 = new System.Windows.Forms.TabPage();
            edCustomVideoSourceURL = new System.Windows.Forms.TextBox();
            label516 = new System.Windows.Forms.Label();
            cbCustomVideoSourceFrameRate = new System.Windows.Forms.ComboBox();
            label438 = new System.Windows.Forms.Label();
            label435 = new System.Windows.Forms.Label();
            cbCustomVideoSourceFormat = new System.Windows.Forms.ComboBox();
            label434 = new System.Windows.Forms.Label();
            cbCustomVideoSourceFilter = new System.Windows.Forms.ComboBox();
            cbCustomVideoSourceCategory = new System.Windows.Forms.ComboBox();
            label432 = new System.Windows.Forms.Label();
            tabPage126 = new System.Windows.Forms.TabPage();
            edCustomAudioSourceURL = new System.Windows.Forms.TextBox();
            label517 = new System.Windows.Forms.Label();
            label437 = new System.Windows.Forms.Label();
            cbCustomAudioSourceFormat = new System.Windows.Forms.ComboBox();
            label436 = new System.Windows.Forms.Label();
            cbCustomAudioSourceFilter = new System.Windows.Forms.ComboBox();
            label433 = new System.Windows.Forms.Label();
            cbCustomAudioSourceCategory = new System.Windows.Forms.ComboBox();
            openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            checkBox1 = new System.Windows.Forms.CheckBox();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btSaveScreenshot = new System.Windows.Forms.Button();
            lbTimestamp = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            fontDialog1 = new System.Windows.Forms.FontDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            cbScreenCapture_HighlightMouseCursor = new System.Windows.Forms.CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl17.SuspendLayout();
            tabPage68.SuspendLayout();
            tabControl7.SuspendLayout();
            tabPage29.SuspendLayout();
            tabPage42.SuspendLayout();
            tabPage91.SuspendLayout();
            groupBox37.SuspendLayout();
            tabPage92.SuspendLayout();
            groupBox40.SuspendLayout();
            groupBox39.SuspendLayout();
            groupBox38.SuspendLayout();
            tabPage102.SuspendLayout();
            groupBox45.SuspendLayout();
            tabPage114.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbLiveRotationAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage69.SuspendLayout();
            tabPage59.SuspendLayout();
            tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).BeginInit();
            tabPage9.SuspendLayout();
            tabPage60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).BeginInit();
            tabPage70.SuspendLayout();
            tabControl14.SuspendLayout();
            tabPage127.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).BeginInit();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).BeginInit();
            tabPage27.SuspendLayout();
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
            tabPage93.SuspendLayout();
            groupBox41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).BeginInit();
            tabPage107.SuspendLayout();
            tabPage7.SuspendLayout();
            tabControl5.SuspendLayout();
            tpWMV.SuspendLayout();
            tpRTSP.SuspendLayout();
            tpRTMP.SuspendLayout();
            groupBox4.SuspendLayout();
            tpNDI.SuspendLayout();
            tpUDP.SuspendLayout();
            tpSSF.SuspendLayout();
            tpHLS.SuspendLayout();
            tpNSExternal.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage28.SuspendLayout();
            groupBox19.SuspendLayout();
            tabControl6.SuspendLayout();
            tabPage30.SuspendLayout();
            tabPage31.SuspendLayout();
            tabPage32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbOSDTranspLevel).BeginInit();
            groupBox15.SuspendLayout();
            tabPage43.SuspendLayout();
            tabControl9.SuspendLayout();
            tabPage44.SuspendLayout();
            tabPage45.SuspendLayout();
            groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetHLThreshold).BeginInit();
            groupBox27.SuspendLayout();
            groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMotDetDropFramesThreshold).BeginInit();
            groupBox24.SuspendLayout();
            tabPage26.SuspendLayout();
            tabPage25.SuspendLayout();
            tabPage101.SuspendLayout();
            tabPage103.SuspendLayout();
            tabPage141.SuspendLayout();
            TabControl32.SuspendLayout();
            TabPage142.SuspendLayout();
            TabPage143.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgTagCover).BeginInit();
            tabControl10.SuspendLayout();
            tabPage46.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage52.SuspendLayout();
            tabPage10.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPage14.SuspendLayout();
            tabPage15.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage21.SuspendLayout();
            tabPage11.SuspendLayout();
            groupBox21.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAdjSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjBrightness).BeginInit();
            tabPage66.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbCCFocus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbCCZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbCCTilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbCCPan).BeginInit();
            tabPage63.SuspendLayout();
            tabControl19.SuspendLayout();
            tabPage96.SuspendLayout();
            tabPage97.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioVolume).BeginInit();
            tabPage98.SuspendLayout();
            tabPage112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).BeginInit();
            tabPage99.SuspendLayout();
            tabPage47.SuspendLayout();
            tabPage48.SuspendLayout();
            tabControl15.SuspendLayout();
            tabPage144.SuspendLayout();
            tabPage146.SuspendLayout();
            tabPage145.SuspendLayout();
            groupBox42.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage81.SuspendLayout();
            tabControl22.SuspendLayout();
            tabPage82.SuspendLayout();
            tabPage83.SuspendLayout();
            tabControl23.SuspendLayout();
            tabPage84.SuspendLayout();
            tabPage85.SuspendLayout();
            tabPage86.SuspendLayout();
            groupBox35.SuspendLayout();
            groupBox36.SuspendLayout();
            tabPage87.SuspendLayout();
            tabPage105.SuspendLayout();
            tabPage49.SuspendLayout();
            tabControl20.SuspendLayout();
            tabPage67.SuspendLayout();
            tabControl21.SuspendLayout();
            tabPage78.SuspendLayout();
            groupBox30.SuspendLayout();
            tabPage79.SuspendLayout();
            groupBox31.SuspendLayout();
            tabPage80.SuspendLayout();
            groupBox32.SuspendLayout();
            tabPage100.SuspendLayout();
            groupBox44.SuspendLayout();
            tabPage77.SuspendLayout();
            groupBox34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPIPTransparency).BeginInit();
            groupBox33.SuspendLayout();
            groupBox20.SuspendLayout();
            tabPage147.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPIPChromaKeyTolerance2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPIPChromaKeyTolerance1).BeginInit();
            tabPage50.SuspendLayout();
            tabPage51.SuspendLayout();
            tabControl26.SuspendLayout();
            tabPage115.SuspendLayout();
            groupBox28.SuspendLayout();
            groupBox13.SuspendLayout();
            tabPage116.SuspendLayout();
            tabPage12.SuspendLayout();
            groupBox8.SuspendLayout();
            tabPage88.SuspendLayout();
            tabPage124.SuspendLayout();
            tabControl28.SuspendLayout();
            tabPage125.SuspendLayout();
            tabPage126.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(550, 1210);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(59, 25);
            label8.TabIndex = 36;
            label8.Text = "Mode";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStop.Location = new System.Drawing.Point(1216, 1200);
            btStop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 43);
            btStop.TabIndex = 34;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += (this.btStop_Click);
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(1104, 1200);
            btStart.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 43);
            btStart.TabIndex = 33;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += (this.btStart_Click);
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage127);
            tabControl1.Controls.Add(tabPage27);
            tabControl1.Controls.Add(tabPage93);
            tabControl1.Controls.Add(tabPage107);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage28);
            tabControl1.Controls.Add(tabPage43);
            tabControl1.Controls.Add(tabPage26);
            tabControl1.Controls.Add(tabPage25);
            tabControl1.Controls.Add(tabPage101);
            tabControl1.Controls.Add(tabPage103);
            tabControl1.Controls.Add(tabPage141);
            tabControl1.Location = new System.Drawing.Point(13, 15);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(524, 982);
            tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(llXiphX64);
            tabPage1.Controls.Add(llXiphX86);
            tabPage1.Controls.Add(label68);
            tabPage1.Controls.Add(label67);
            tabPage1.Controls.Add(lbInfo);
            tabPage1.Controls.Add(btOutputConfigure);
            tabPage1.Controls.Add(cbAutoFilename);
            tabPage1.Controls.Add(cbOutputFormat);
            tabPage1.Controls.Add(btSelectOutput);
            tabPage1.Controls.Add(edOutput);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(cbRecordAudio);
            tabPage1.Controls.Add(label7);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage1.Size = new System.Drawing.Size(516, 944);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Capture";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // llXiphX64
            // 
            llXiphX64.AutoSize = true;
            llXiphX64.Location = new System.Drawing.Point(276, 450);
            llXiphX64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llXiphX64.Name = "llXiphX64";
            llXiphX64.Size = new System.Drawing.Size(40, 25);
            llXiphX64.TabIndex = 55;
            llXiphX64.TabStop = true;
            llXiphX64.Text = "x64";
            llXiphX64.LinkClicked += (this.llXiphX64_LinkClicked);
            // 
            // llXiphX86
            // 
            llXiphX86.AutoSize = true;
            llXiphX86.Location = new System.Drawing.Point(224, 450);
            llXiphX86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llXiphX86.Name = "llXiphX86";
            llXiphX86.Size = new System.Drawing.Size(40, 25);
            llXiphX86.TabIndex = 54;
            llXiphX86.TabStop = true;
            llXiphX86.Text = "x86";
            llXiphX86.LinkClicked += (this.llXiphX86_LinkClicked);
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Location = new System.Drawing.Point(27, 450);
            label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label68.Name = "label68";
            label68.Size = new System.Drawing.Size(197, 25);
            label68.TabIndex = 53;
            label68.Text = "and Ogg Vorbis output";
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new System.Drawing.Point(27, 408);
            label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(465, 25);
            label67.TabIndex = 52;
            label67.Text = "Additional redist required to be installed for FLAC, Speex,";
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(27, 118);
            lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 51;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            btOutputConfigure.Location = new System.Drawing.Point(31, 148);
            btOutputConfigure.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOutputConfigure.Name = "btOutputConfigure";
            btOutputConfigure.Size = new System.Drawing.Size(124, 43);
            btOutputConfigure.TabIndex = 44;
            btOutputConfigure.Text = "Configure";
            btOutputConfigure.UseVisualStyleBackColor = true;
            btOutputConfigure.Click += (this.btOutputConfigure_Click);
            // 
            // cbAutoFilename
            // 
            cbAutoFilename.AutoSize = true;
            cbAutoFilename.Location = new System.Drawing.Point(417, 272);
            cbAutoFilename.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAutoFilename.Name = "cbAutoFilename";
            cbAutoFilename.Size = new System.Drawing.Size(77, 29);
            cbAutoFilename.TabIndex = 43;
            cbAutoFilename.Text = "Auto";
            cbAutoFilename.UseVisualStyleBackColor = true;
            // 
            // cbOutputFormat
            // 
            cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputFormat.FormattingEnabled = true;
            cbOutputFormat.Items.AddRange(new object[] { "AVI", "MKV (Legacy)", "WMV (Windows Media Video)", "DV", "PCM/ACM", "MP3", "M4A (AAC)", "WMA (Windows Media Audio)", "FLAC", "Ogg Vorbis", "Speex", "Custom", "DirectCapture DV (DV devices only)", "DirectCapture AVI (some specific devices)", "DirectCapture MPEG (MPEG 1/2/4 devices only)", "DirectCapture MKV (IP cameras / H264 devices)", "DirectCapture MP4 GDCL Mux (IP cameras / H264 devices)", "DirectCapture MP4 Monogram Mux (IP cameras / H264 devices)", "DirectCapture Custom (IP Cameras / H264 devices)", "WebM", "FFMPEG", "FFMPEG (external exe)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video", "MPEG-TS", "MOV" });
            cbOutputFormat.Location = new System.Drawing.Point(31, 62);
            cbOutputFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbOutputFormat.Name = "cbOutputFormat";
            cbOutputFormat.Size = new System.Drawing.Size(463, 33);
            cbOutputFormat.TabIndex = 42;
            cbOutputFormat.SelectedIndexChanged += (this.cbOutputFormat_SelectedIndexChanged);
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(457, 307);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(40, 43);
            btSelectOutput.TabIndex = 41;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += (this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(31, 310);
            edOutput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(413, 31);
            edOutput.TabIndex = 40;
            edOutput.Text = "c:\\capture.avi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(27, 278);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 25);
            label9.TabIndex = 39;
            label9.Text = "File name";
            // 
            // cbRecordAudio
            // 
            cbRecordAudio.AutoSize = true;
            cbRecordAudio.Location = new System.Drawing.Point(31, 218);
            cbRecordAudio.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbRecordAudio.Name = "cbRecordAudio";
            cbRecordAudio.Size = new System.Drawing.Size(143, 29);
            cbRecordAudio.TabIndex = 7;
            cbRecordAudio.Text = "Record audio";
            cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(27, 32);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 25);
            label7.TabIndex = 2;
            label7.Text = "Format";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tabControl17);
            tabPage2.Controls.Add(tabControl14);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage2.Size = new System.Drawing.Size(516, 944);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Video processing";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            tabControl17.Controls.Add(tabPage68);
            tabControl17.Controls.Add(tabPage69);
            tabControl17.Controls.Add(tabPage59);
            tabControl17.Controls.Add(tabPage20);
            tabControl17.Controls.Add(tabPage9);
            tabControl17.Controls.Add(tabPage60);
            tabControl17.Controls.Add(tabPage70);
            tabControl17.Location = new System.Drawing.Point(10, 7);
            tabControl17.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl17.Name = "tabControl17";
            tabControl17.SelectedIndex = 0;
            tabControl17.Size = new System.Drawing.Size(497, 932);
            tabControl17.TabIndex = 36;
            // 
            // tabPage68
            // 
            tabPage68.Controls.Add(cbScrollingText);
            tabPage68.Controls.Add(cbFlipY);
            tabPage68.Controls.Add(cbFlipX);
            tabPage68.Controls.Add(cbDisableAllVideoProcessing);
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
            tabPage68.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage68.Name = "tabPage68";
            tabPage68.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage68.Size = new System.Drawing.Size(489, 894);
            tabPage68.TabIndex = 0;
            tabPage68.Text = "Effects";
            tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbScrollingText
            // 
            cbScrollingText.AutoSize = true;
            cbScrollingText.Location = new System.Drawing.Point(14, 318);
            cbScrollingText.Name = "cbScrollingText";
            cbScrollingText.Size = new System.Drawing.Size(202, 29);
            cbScrollingText.TabIndex = 89;
            cbScrollingText.Text = "Sample scrolling text";
            cbScrollingText.UseVisualStyleBackColor = true;
            cbScrollingText.CheckedChanged += (this.cbScrollingText_CheckedChanged);
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(349, 287);
            cbFlipY.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipY.Name = "cbFlipY";
            cbFlipY.Size = new System.Drawing.Size(81, 29);
            cbFlipY.TabIndex = 67;
            cbFlipY.Text = "Flip Y";
            cbFlipY.UseVisualStyleBackColor = true;
            cbFlipY.CheckedChanged += (this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            cbFlipX.AutoSize = true;
            cbFlipX.Location = new System.Drawing.Point(249, 287);
            cbFlipX.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipX.Name = "cbFlipX";
            cbFlipX.Size = new System.Drawing.Size(82, 29);
            cbFlipX.TabIndex = 66;
            cbFlipX.Text = "Flip X";
            cbFlipX.UseVisualStyleBackColor = true;
            cbFlipX.CheckedChanged += (this.cbFlipX_CheckedChanged);
            // 
            // cbDisableAllVideoProcessing
            // 
            cbDisableAllVideoProcessing.AutoSize = true;
            cbDisableAllVideoProcessing.Location = new System.Drawing.Point(177, 15);
            cbDisableAllVideoProcessing.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDisableAllVideoProcessing.Name = "cbDisableAllVideoProcessing";
            cbDisableAllVideoProcessing.Size = new System.Drawing.Size(280, 29);
            cbDisableAllVideoProcessing.TabIndex = 65;
            cbDisableAllVideoProcessing.Text = "(DEBUG) Disable all processing";
            cbDisableAllVideoProcessing.UseVisualStyleBackColor = true;
            // 
            // label201
            // 
            label201.AutoSize = true;
            label201.Location = new System.Drawing.Point(237, 168);
            label201.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label201.Name = "label201";
            label201.Size = new System.Drawing.Size(84, 25);
            label201.TabIndex = 63;
            label201.Text = "Darkness";
            // 
            // label200
            // 
            label200.AutoSize = true;
            label200.Location = new System.Drawing.Point(10, 168);
            label200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label200.Name = "label200";
            label200.Size = new System.Drawing.Size(79, 25);
            label200.TabIndex = 62;
            label200.Text = "Contrast";
            // 
            // label199
            // 
            label199.AutoSize = true;
            label199.Location = new System.Drawing.Point(237, 68);
            label199.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label199.Name = "label199";
            label199.Size = new System.Drawing.Size(93, 25);
            label199.TabIndex = 61;
            label199.Text = "Saturation";
            // 
            // label198
            // 
            label198.AutoSize = true;
            label198.Location = new System.Drawing.Point(10, 68);
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
            tabControl7.Controls.Add(tabPage91);
            tabControl7.Controls.Add(tabPage92);
            tabControl7.Controls.Add(tabPage102);
            tabControl7.Controls.Add(tabPage114);
            tabControl7.Location = new System.Drawing.Point(4, 357);
            tabControl7.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl7.Name = "tabControl7";
            tabControl7.SelectedIndex = 0;
            tabControl7.Size = new System.Drawing.Size(471, 528);
            tabControl7.TabIndex = 59;
            // 
            // tabPage29
            // 
            tabPage29.Controls.Add(cbMergeTextLogos);
            tabPage29.Controls.Add(btTextLogoRemove);
            tabPage29.Controls.Add(btTextLogoEdit);
            tabPage29.Controls.Add(lbTextLogos);
            tabPage29.Controls.Add(btTextLogoAdd);
            tabPage29.Location = new System.Drawing.Point(4, 34);
            tabPage29.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage29.Name = "tabPage29";
            tabPage29.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage29.Size = new System.Drawing.Size(463, 490);
            tabPage29.TabIndex = 0;
            tabPage29.Text = "Text logo";
            tabPage29.UseVisualStyleBackColor = true;
            // 
            // cbMergeTextLogos
            // 
            cbMergeTextLogos.AutoSize = true;
            cbMergeTextLogos.Location = new System.Drawing.Point(13, 22);
            cbMergeTextLogos.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMergeTextLogos.Name = "cbMergeTextLogos";
            cbMergeTextLogos.Size = new System.Drawing.Size(244, 29);
            cbMergeTextLogos.TabIndex = 88;
            cbMergeTextLogos.Text = "Merge text logos into one";
            cbMergeTextLogos.UseVisualStyleBackColor = true;
            // 
            // btTextLogoRemove
            // 
            btTextLogoRemove.Location = new System.Drawing.Point(340, 407);
            btTextLogoRemove.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btTextLogoRemove.Name = "btTextLogoRemove";
            btTextLogoRemove.Size = new System.Drawing.Size(99, 43);
            btTextLogoRemove.TabIndex = 3;
            btTextLogoRemove.Text = "Remove";
            btTextLogoRemove.UseVisualStyleBackColor = true;
            btTextLogoRemove.Click += (this.btTextLogoRemove_Click);
            // 
            // btTextLogoEdit
            // 
            btTextLogoEdit.Location = new System.Drawing.Point(120, 407);
            btTextLogoEdit.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btTextLogoEdit.Name = "btTextLogoEdit";
            btTextLogoEdit.Size = new System.Drawing.Size(99, 43);
            btTextLogoEdit.TabIndex = 2;
            btTextLogoEdit.Text = "Edit";
            btTextLogoEdit.UseVisualStyleBackColor = true;
            btTextLogoEdit.Click += (this.btTextLogoEdit_Click);
            // 
            // lbTextLogos
            // 
            lbTextLogos.FormattingEnabled = true;
            lbTextLogos.ItemHeight = 25;
            lbTextLogos.Location = new System.Drawing.Point(13, 65);
            lbTextLogos.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbTextLogos.Name = "lbTextLogos";
            lbTextLogos.Size = new System.Drawing.Size(425, 329);
            lbTextLogos.TabIndex = 1;
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(11, 407);
            btTextLogoAdd.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btTextLogoAdd.Name = "btTextLogoAdd";
            btTextLogoAdd.Size = new System.Drawing.Size(99, 43);
            btTextLogoAdd.TabIndex = 0;
            btTextLogoAdd.Text = "Add";
            btTextLogoAdd.UseVisualStyleBackColor = true;
            btTextLogoAdd.Click += (this.btTextLogoAdd_Click);
            // 
            // tabPage42
            // 
            tabPage42.Controls.Add(cbMergeImageLogos);
            tabPage42.Controls.Add(btImageLogoRemove);
            tabPage42.Controls.Add(btImageLogoEdit);
            tabPage42.Controls.Add(lbImageLogos);
            tabPage42.Controls.Add(btImageLogoAdd);
            tabPage42.Location = new System.Drawing.Point(4, 34);
            tabPage42.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage42.Name = "tabPage42";
            tabPage42.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage42.Size = new System.Drawing.Size(463, 490);
            tabPage42.TabIndex = 1;
            tabPage42.Text = "Image logo";
            tabPage42.UseVisualStyleBackColor = true;
            // 
            // cbMergeImageLogos
            // 
            cbMergeImageLogos.AutoSize = true;
            cbMergeImageLogos.Location = new System.Drawing.Point(13, 22);
            cbMergeImageLogos.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMergeImageLogos.Name = "cbMergeImageLogos";
            cbMergeImageLogos.Size = new System.Drawing.Size(264, 29);
            cbMergeImageLogos.TabIndex = 87;
            cbMergeImageLogos.Text = "Merge image logos into one";
            cbMergeImageLogos.UseVisualStyleBackColor = true;
            // 
            // btImageLogoRemove
            // 
            btImageLogoRemove.Location = new System.Drawing.Point(343, 407);
            btImageLogoRemove.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btImageLogoRemove.Name = "btImageLogoRemove";
            btImageLogoRemove.Size = new System.Drawing.Size(99, 43);
            btImageLogoRemove.TabIndex = 7;
            btImageLogoRemove.Text = "Remove";
            btImageLogoRemove.UseVisualStyleBackColor = true;
            btImageLogoRemove.Click += (this.btImageLogoRemove_Click);
            // 
            // btImageLogoEdit
            // 
            btImageLogoEdit.Location = new System.Drawing.Point(120, 407);
            btImageLogoEdit.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btImageLogoEdit.Name = "btImageLogoEdit";
            btImageLogoEdit.Size = new System.Drawing.Size(99, 43);
            btImageLogoEdit.TabIndex = 6;
            btImageLogoEdit.Text = "Edit";
            btImageLogoEdit.UseVisualStyleBackColor = true;
            btImageLogoEdit.Click += (this.btImageLogoEdit_Click);
            // 
            // lbImageLogos
            // 
            lbImageLogos.FormattingEnabled = true;
            lbImageLogos.ItemHeight = 25;
            lbImageLogos.Location = new System.Drawing.Point(13, 65);
            lbImageLogos.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbImageLogos.Name = "lbImageLogos";
            lbImageLogos.Size = new System.Drawing.Size(425, 329);
            lbImageLogos.TabIndex = 5;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(11, 407);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(99, 43);
            btImageLogoAdd.TabIndex = 4;
            btImageLogoAdd.Text = "Add";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += (this.btImageLogoAdd_Click);
            // 
            // tabPage91
            // 
            tabPage91.Controls.Add(groupBox37);
            tabPage91.Controls.Add(cbZoom);
            tabPage91.Location = new System.Drawing.Point(4, 34);
            tabPage91.Name = "tabPage91";
            tabPage91.Padding = new System.Windows.Forms.Padding(3);
            tabPage91.Size = new System.Drawing.Size(463, 490);
            tabPage91.TabIndex = 2;
            tabPage91.Text = "Zoom";
            tabPage91.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            groupBox37.Controls.Add(btEffZoomRight);
            groupBox37.Controls.Add(btEffZoomLeft);
            groupBox37.Controls.Add(btEffZoomOut);
            groupBox37.Controls.Add(btEffZoomIn);
            groupBox37.Controls.Add(btEffZoomDown);
            groupBox37.Controls.Add(btEffZoomUp);
            groupBox37.Location = new System.Drawing.Point(137, 102);
            groupBox37.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox37.Name = "groupBox37";
            groupBox37.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox37.Size = new System.Drawing.Size(199, 200);
            groupBox37.TabIndex = 16;
            groupBox37.TabStop = false;
            groupBox37.Text = "Zoom";
            // 
            // btEffZoomRight
            // 
            btEffZoomRight.Location = new System.Drawing.Point(141, 62);
            btEffZoomRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomRight.Name = "btEffZoomRight";
            btEffZoomRight.Size = new System.Drawing.Size(36, 92);
            btEffZoomRight.TabIndex = 5;
            btEffZoomRight.Text = "R";
            btEffZoomRight.UseVisualStyleBackColor = true;
            btEffZoomRight.Click += (this.btEffZoomRight_Click);
            // 
            // btEffZoomLeft
            // 
            btEffZoomLeft.Location = new System.Drawing.Point(21, 62);
            btEffZoomLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomLeft.Name = "btEffZoomLeft";
            btEffZoomLeft.Size = new System.Drawing.Size(36, 92);
            btEffZoomLeft.TabIndex = 4;
            btEffZoomLeft.Text = "L";
            btEffZoomLeft.UseVisualStyleBackColor = true;
            btEffZoomLeft.Click += (this.btEffZoomLeft_Click);
            // 
            // btEffZoomOut
            // 
            btEffZoomOut.Location = new System.Drawing.Point(101, 88);
            btEffZoomOut.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomOut.Name = "btEffZoomOut";
            btEffZoomOut.Size = new System.Drawing.Size(39, 43);
            btEffZoomOut.TabIndex = 3;
            btEffZoomOut.Text = "-";
            btEffZoomOut.UseVisualStyleBackColor = true;
            btEffZoomOut.Click += (this.btEffZoomOut_Click);
            // 
            // btEffZoomIn
            // 
            btEffZoomIn.Location = new System.Drawing.Point(59, 88);
            btEffZoomIn.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomIn.Name = "btEffZoomIn";
            btEffZoomIn.Size = new System.Drawing.Size(37, 43);
            btEffZoomIn.TabIndex = 2;
            btEffZoomIn.Text = "+";
            btEffZoomIn.UseVisualStyleBackColor = true;
            btEffZoomIn.Click += (this.btEffZoomIn_Click);
            // 
            // btEffZoomDown
            // 
            btEffZoomDown.Location = new System.Drawing.Point(57, 132);
            btEffZoomDown.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomDown.Name = "btEffZoomDown";
            btEffZoomDown.Size = new System.Drawing.Size(84, 43);
            btEffZoomDown.TabIndex = 1;
            btEffZoomDown.Text = "Down";
            btEffZoomDown.UseVisualStyleBackColor = true;
            btEffZoomDown.Click += (this.btEffZoomDown_Click);
            // 
            // btEffZoomUp
            // 
            btEffZoomUp.Location = new System.Drawing.Point(57, 38);
            btEffZoomUp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btEffZoomUp.Name = "btEffZoomUp";
            btEffZoomUp.Size = new System.Drawing.Size(84, 43);
            btEffZoomUp.TabIndex = 0;
            btEffZoomUp.Text = "Up";
            btEffZoomUp.UseVisualStyleBackColor = true;
            btEffZoomUp.Click += (this.btEffZoomUp_Click);
            // 
            // cbZoom
            // 
            cbZoom.AutoSize = true;
            cbZoom.Location = new System.Drawing.Point(13, 32);
            cbZoom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbZoom.Name = "cbZoom";
            cbZoom.Size = new System.Drawing.Size(101, 29);
            cbZoom.TabIndex = 15;
            cbZoom.Text = "Enabled";
            cbZoom.UseVisualStyleBackColor = true;
            cbZoom.CheckedChanged += (this.cbZoom_CheckedChanged);
            // 
            // tabPage92
            // 
            tabPage92.Controls.Add(groupBox40);
            tabPage92.Controls.Add(groupBox39);
            tabPage92.Controls.Add(groupBox38);
            tabPage92.Controls.Add(cbPan);
            tabPage92.Location = new System.Drawing.Point(4, 34);
            tabPage92.Name = "tabPage92";
            tabPage92.Padding = new System.Windows.Forms.Padding(3);
            tabPage92.Size = new System.Drawing.Size(463, 490);
            tabPage92.TabIndex = 3;
            tabPage92.Text = "Pan";
            tabPage92.UseVisualStyleBackColor = true;
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
            groupBox40.Location = new System.Drawing.Point(20, 322);
            groupBox40.Name = "groupBox40";
            groupBox40.Size = new System.Drawing.Size(280, 148);
            groupBox40.TabIndex = 54;
            groupBox40.TabStop = false;
            groupBox40.Text = "Destination rect";
            // 
            // edPanDestHeight
            // 
            edPanDestHeight.Location = new System.Drawing.Point(204, 98);
            edPanDestHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanDestHeight.Name = "edPanDestHeight";
            edPanDestHeight.Size = new System.Drawing.Size(53, 31);
            edPanDestHeight.TabIndex = 17;
            edPanDestHeight.Text = "240";
            // 
            // label302
            // 
            label302.AutoSize = true;
            label302.Location = new System.Drawing.Point(136, 103);
            label302.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label302.Name = "label302";
            label302.Size = new System.Drawing.Size(65, 25);
            label302.TabIndex = 16;
            label302.Text = "Height";
            // 
            // edPanDestWidth
            // 
            edPanDestWidth.Location = new System.Drawing.Point(204, 48);
            edPanDestWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanDestWidth.Name = "edPanDestWidth";
            edPanDestWidth.Size = new System.Drawing.Size(53, 31);
            edPanDestWidth.TabIndex = 15;
            edPanDestWidth.Text = "320";
            // 
            // label303
            // 
            label303.AutoSize = true;
            label303.Location = new System.Drawing.Point(136, 53);
            label303.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label303.Name = "label303";
            label303.Size = new System.Drawing.Size(60, 25);
            label303.TabIndex = 14;
            label303.Text = "Width";
            // 
            // edPanDestTop
            // 
            edPanDestTop.Location = new System.Drawing.Point(71, 100);
            edPanDestTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanDestTop.Name = "edPanDestTop";
            edPanDestTop.Size = new System.Drawing.Size(53, 31);
            edPanDestTop.TabIndex = 12;
            edPanDestTop.Text = "0";
            // 
            // label304
            // 
            label304.AutoSize = true;
            label304.Location = new System.Drawing.Point(21, 103);
            label304.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label304.Name = "label304";
            label304.Size = new System.Drawing.Size(41, 25);
            label304.TabIndex = 11;
            label304.Text = "Top";
            // 
            // edPanDestLeft
            // 
            edPanDestLeft.Location = new System.Drawing.Point(71, 50);
            edPanDestLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanDestLeft.Name = "edPanDestLeft";
            edPanDestLeft.Size = new System.Drawing.Size(53, 31);
            edPanDestLeft.TabIndex = 10;
            edPanDestLeft.Text = "0";
            // 
            // label305
            // 
            label305.AutoSize = true;
            label305.Location = new System.Drawing.Point(21, 53);
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
            groupBox39.Location = new System.Drawing.Point(20, 168);
            groupBox39.Name = "groupBox39";
            groupBox39.Size = new System.Drawing.Size(280, 148);
            groupBox39.TabIndex = 53;
            groupBox39.TabStop = false;
            groupBox39.Text = "Source rect";
            // 
            // edPanSourceHeight
            // 
            edPanSourceHeight.Location = new System.Drawing.Point(204, 98);
            edPanSourceHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanSourceHeight.Name = "edPanSourceHeight";
            edPanSourceHeight.Size = new System.Drawing.Size(53, 31);
            edPanSourceHeight.TabIndex = 17;
            edPanSourceHeight.Text = "480";
            // 
            // label298
            // 
            label298.AutoSize = true;
            label298.Location = new System.Drawing.Point(136, 103);
            label298.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label298.Name = "label298";
            label298.Size = new System.Drawing.Size(65, 25);
            label298.TabIndex = 16;
            label298.Text = "Height";
            // 
            // edPanSourceWidth
            // 
            edPanSourceWidth.Location = new System.Drawing.Point(204, 48);
            edPanSourceWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanSourceWidth.Name = "edPanSourceWidth";
            edPanSourceWidth.Size = new System.Drawing.Size(53, 31);
            edPanSourceWidth.TabIndex = 15;
            edPanSourceWidth.Text = "640";
            // 
            // label299
            // 
            label299.AutoSize = true;
            label299.Location = new System.Drawing.Point(136, 53);
            label299.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label299.Name = "label299";
            label299.Size = new System.Drawing.Size(60, 25);
            label299.TabIndex = 14;
            label299.Text = "Width";
            // 
            // edPanSourceTop
            // 
            edPanSourceTop.Location = new System.Drawing.Point(71, 100);
            edPanSourceTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanSourceTop.Name = "edPanSourceTop";
            edPanSourceTop.Size = new System.Drawing.Size(53, 31);
            edPanSourceTop.TabIndex = 12;
            edPanSourceTop.Text = "0";
            // 
            // label300
            // 
            label300.AutoSize = true;
            label300.Location = new System.Drawing.Point(21, 103);
            label300.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label300.Name = "label300";
            label300.Size = new System.Drawing.Size(41, 25);
            label300.TabIndex = 11;
            label300.Text = "Top";
            // 
            // edPanSourceLeft
            // 
            edPanSourceLeft.Location = new System.Drawing.Point(71, 50);
            edPanSourceLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanSourceLeft.Name = "edPanSourceLeft";
            edPanSourceLeft.Size = new System.Drawing.Size(53, 31);
            edPanSourceLeft.TabIndex = 10;
            edPanSourceLeft.Text = "0";
            // 
            // label301
            // 
            label301.AutoSize = true;
            label301.Location = new System.Drawing.Point(21, 53);
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
            groupBox38.Location = new System.Drawing.Point(20, 68);
            groupBox38.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox38.Name = "groupBox38";
            groupBox38.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox38.Size = new System.Drawing.Size(280, 88);
            groupBox38.TabIndex = 52;
            groupBox38.TabStop = false;
            groupBox38.Text = "Duration";
            // 
            // edPanStopTime
            // 
            edPanStopTime.Location = new System.Drawing.Point(196, 38);
            edPanStopTime.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanStopTime.Name = "edPanStopTime";
            edPanStopTime.Size = new System.Drawing.Size(63, 31);
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
            edPanStartTime.Location = new System.Drawing.Point(71, 38);
            edPanStartTime.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPanStartTime.Name = "edPanStartTime";
            edPanStartTime.Size = new System.Drawing.Size(63, 31);
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
            cbPan.Location = new System.Drawing.Point(20, 22);
            cbPan.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPan.Name = "cbPan";
            cbPan.Size = new System.Drawing.Size(101, 29);
            cbPan.TabIndex = 51;
            cbPan.Text = "Enabled";
            cbPan.UseVisualStyleBackColor = true;
            cbPan.CheckedChanged += (this.cbPan_CheckedChanged);
            // 
            // tabPage102
            // 
            tabPage102.Controls.Add(rbFadeOut);
            tabPage102.Controls.Add(rbFadeIn);
            tabPage102.Controls.Add(groupBox45);
            tabPage102.Controls.Add(cbFadeInOut);
            tabPage102.Location = new System.Drawing.Point(4, 34);
            tabPage102.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage102.Name = "tabPage102";
            tabPage102.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage102.Size = new System.Drawing.Size(463, 490);
            tabPage102.TabIndex = 4;
            tabPage102.Text = "Fade-in/out";
            tabPage102.UseVisualStyleBackColor = true;
            // 
            // rbFadeOut
            // 
            rbFadeOut.AutoSize = true;
            rbFadeOut.Location = new System.Drawing.Point(171, 188);
            rbFadeOut.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbFadeOut.Name = "rbFadeOut";
            rbFadeOut.Size = new System.Drawing.Size(108, 29);
            rbFadeOut.TabIndex = 56;
            rbFadeOut.TabStop = true;
            rbFadeOut.Text = "Fade-out";
            rbFadeOut.UseVisualStyleBackColor = true;
            // 
            // rbFadeIn
            // 
            rbFadeIn.AutoSize = true;
            rbFadeIn.Checked = true;
            rbFadeIn.Location = new System.Drawing.Point(20, 188);
            rbFadeIn.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbFadeIn.Name = "rbFadeIn";
            rbFadeIn.Size = new System.Drawing.Size(95, 29);
            rbFadeIn.TabIndex = 55;
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
            groupBox45.Location = new System.Drawing.Point(20, 88);
            groupBox45.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox45.Name = "groupBox45";
            groupBox45.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox45.Size = new System.Drawing.Size(280, 88);
            groupBox45.TabIndex = 54;
            groupBox45.TabStop = false;
            groupBox45.Text = "Duration";
            // 
            // edFadeInOutStopTime
            // 
            edFadeInOutStopTime.Location = new System.Drawing.Point(196, 38);
            edFadeInOutStopTime.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edFadeInOutStopTime.Name = "edFadeInOutStopTime";
            edFadeInOutStopTime.Size = new System.Drawing.Size(63, 31);
            edFadeInOutStopTime.TabIndex = 34;
            edFadeInOutStopTime.Text = "15000";
            edFadeInOutStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // edFadeInOutStartTime
            // 
            edFadeInOutStartTime.Location = new System.Drawing.Point(71, 38);
            edFadeInOutStartTime.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edFadeInOutStartTime.Name = "edFadeInOutStartTime";
            edFadeInOutStartTime.Size = new System.Drawing.Size(63, 31);
            edFadeInOutStartTime.TabIndex = 32;
            edFadeInOutStartTime.Text = "5000";
            edFadeInOutStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // cbFadeInOut
            // 
            cbFadeInOut.AutoSize = true;
            cbFadeInOut.Location = new System.Drawing.Point(20, 22);
            cbFadeInOut.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFadeInOut.Name = "cbFadeInOut";
            cbFadeInOut.Size = new System.Drawing.Size(101, 29);
            cbFadeInOut.TabIndex = 53;
            cbFadeInOut.Text = "Enabled";
            cbFadeInOut.UseVisualStyleBackColor = true;
            cbFadeInOut.CheckedChanged += (this.cbFadeInOut_CheckedChanged);
            // 
            // tabPage114
            // 
            tabPage114.Controls.Add(cbLiveRotationStretch);
            tabPage114.Controls.Add(label392);
            tabPage114.Controls.Add(label391);
            tabPage114.Controls.Add(tbLiveRotationAngle);
            tabPage114.Controls.Add(label390);
            tabPage114.Controls.Add(cbLiveRotation);
            tabPage114.Location = new System.Drawing.Point(4, 34);
            tabPage114.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage114.Name = "tabPage114";
            tabPage114.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage114.Size = new System.Drawing.Size(463, 490);
            tabPage114.TabIndex = 5;
            tabPage114.Text = "Live rotation";
            tabPage114.UseVisualStyleBackColor = true;
            // 
            // cbLiveRotationStretch
            // 
            cbLiveRotationStretch.AutoSize = true;
            cbLiveRotationStretch.Location = new System.Drawing.Point(20, 262);
            cbLiveRotationStretch.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbLiveRotationStretch.Name = "cbLiveRotationStretch";
            cbLiveRotationStretch.Size = new System.Drawing.Size(259, 29);
            cbLiveRotationStretch.TabIndex = 59;
            cbLiveRotationStretch.Text = "Stretch  if angle is 90 or 270";
            cbLiveRotationStretch.UseVisualStyleBackColor = true;
            cbLiveRotationStretch.CheckedChanged += (this.cbLiveRotationStretch_CheckedChanged);
            // 
            // label392
            // 
            label392.AutoSize = true;
            label392.Location = new System.Drawing.Point(217, 212);
            label392.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label392.Name = "label392";
            label392.Size = new System.Drawing.Size(42, 25);
            label392.TabIndex = 58;
            label392.Text = "360";
            // 
            // label391
            // 
            label391.AutoSize = true;
            label391.Location = new System.Drawing.Point(16, 212);
            label391.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label391.Name = "label391";
            label391.Size = new System.Drawing.Size(22, 25);
            label391.TabIndex = 57;
            label391.Text = "0";
            // 
            // tbLiveRotationAngle
            // 
            tbLiveRotationAngle.Location = new System.Drawing.Point(20, 122);
            tbLiveRotationAngle.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbLiveRotationAngle.Maximum = 360;
            tbLiveRotationAngle.Name = "tbLiveRotationAngle";
            tbLiveRotationAngle.Size = new System.Drawing.Size(239, 69);
            tbLiveRotationAngle.TabIndex = 56;
            tbLiveRotationAngle.TickFrequency = 5;
            tbLiveRotationAngle.Value = 90;
            tbLiveRotationAngle.Scroll += (this.tbLiveRotationDegree_Scroll);
            // 
            // label390
            // 
            label390.AutoSize = true;
            label390.Location = new System.Drawing.Point(16, 85);
            label390.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label390.Name = "label390";
            label390.Size = new System.Drawing.Size(58, 25);
            label390.TabIndex = 55;
            label390.Text = "Angle";
            // 
            // cbLiveRotation
            // 
            cbLiveRotation.AutoSize = true;
            cbLiveRotation.Location = new System.Drawing.Point(20, 22);
            cbLiveRotation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbLiveRotation.Name = "cbLiveRotation";
            cbLiveRotation.Size = new System.Drawing.Size(101, 29);
            cbLiveRotation.TabIndex = 54;
            cbLiveRotation.Text = "Enabled";
            cbLiveRotation.UseVisualStyleBackColor = true;
            cbLiveRotation.CheckedChanged += (this.cbLiveRotation_CheckedChanged);
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(4, 207);
            tbContrast.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(217, 69);
            tbContrast.TabIndex = 49;
            tbContrast.Scroll += (this.tbContrast_Scroll);
            // 
            // tbDarkness
            // 
            tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbDarkness.Location = new System.Drawing.Point(237, 207);
            tbDarkness.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbDarkness.Maximum = 255;
            tbDarkness.Name = "tbDarkness";
            tbDarkness.Size = new System.Drawing.Size(217, 69);
            tbDarkness.TabIndex = 46;
            tbDarkness.Scroll += (this.tbDarkness_Scroll);
            // 
            // tbLightness
            // 
            tbLightness.BackColor = System.Drawing.SystemColors.Window;
            tbLightness.Location = new System.Drawing.Point(4, 98);
            tbLightness.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbLightness.Maximum = 255;
            tbLightness.Name = "tbLightness";
            tbLightness.Size = new System.Drawing.Size(217, 69);
            tbLightness.TabIndex = 45;
            tbLightness.Scroll += (this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(237, 98);
            tbSaturation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(217, 69);
            tbSaturation.TabIndex = 43;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += (this.tbSaturation_Scroll);
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(149, 287);
            cbInvert.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbInvert.Name = "cbInvert";
            cbInvert.Size = new System.Drawing.Size(83, 29);
            cbInvert.TabIndex = 41;
            cbInvert.Text = "Invert";
            cbInvert.UseVisualStyleBackColor = true;
            cbInvert.CheckedChanged += (this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            cbGreyscale.AutoSize = true;
            cbGreyscale.Location = new System.Drawing.Point(14, 287);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 39;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += (this.cbGreyscale_CheckedChanged);
            // 
            // cbVideoEffects
            // 
            cbVideoEffects.AutoSize = true;
            cbVideoEffects.Checked = true;
            cbVideoEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            cbVideoEffects.Location = new System.Drawing.Point(13, 15);
            cbVideoEffects.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            tabPage69.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage69.Name = "tabPage69";
            tabPage69.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            edDeintTriangleWeight.Location = new System.Drawing.Point(171, 518);
            edDeintTriangleWeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            label210.Location = new System.Drawing.Point(429, 368);
            label210.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label210.Name = "label210";
            label210.Size = new System.Drawing.Size(44, 25);
            label210.TabIndex = 25;
            label210.Text = "/ 10";
            // 
            // label209
            // 
            label209.AutoSize = true;
            label209.Location = new System.Drawing.Point(429, 307);
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
            edDeintBlendConstants2.Location = new System.Drawing.Point(369, 362);
            edDeintBlendConstants2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDeintBlendConstants2.Name = "edDeintBlendConstants2";
            edDeintBlendConstants2.Size = new System.Drawing.Size(51, 31);
            edDeintBlendConstants2.TabIndex = 22;
            edDeintBlendConstants2.Text = "9";
            // 
            // label207
            // 
            label207.AutoSize = true;
            label207.Location = new System.Drawing.Point(253, 368);
            label207.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label207.Name = "label207";
            label207.Size = new System.Drawing.Size(106, 25);
            label207.TabIndex = 21;
            label207.Text = "Constants 2";
            // 
            // edDeintBlendConstants1
            // 
            edDeintBlendConstants1.Location = new System.Drawing.Point(369, 300);
            edDeintBlendConstants1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDeintBlendConstants1.Name = "edDeintBlendConstants1";
            edDeintBlendConstants1.Size = new System.Drawing.Size(51, 31);
            edDeintBlendConstants1.TabIndex = 20;
            edDeintBlendConstants1.Text = "3";
            // 
            // label208
            // 
            label208.AutoSize = true;
            label208.Location = new System.Drawing.Point(253, 307);
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
            edDeintBlendThreshold2.Location = new System.Drawing.Point(171, 362);
            edDeintBlendThreshold2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDeintBlendThreshold2.Name = "edDeintBlendThreshold2";
            edDeintBlendThreshold2.Size = new System.Drawing.Size(51, 31);
            edDeintBlendThreshold2.TabIndex = 17;
            edDeintBlendThreshold2.Text = "9";
            // 
            // label205
            // 
            label205.AutoSize = true;
            label205.Location = new System.Drawing.Point(57, 368);
            label205.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label205.Name = "label205";
            label205.Size = new System.Drawing.Size(105, 25);
            label205.TabIndex = 16;
            label205.Text = "Threshold 2";
            // 
            // edDeintBlendThreshold1
            // 
            edDeintBlendThreshold1.Location = new System.Drawing.Point(171, 300);
            edDeintBlendThreshold1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDeintBlendThreshold1.Name = "edDeintBlendThreshold1";
            edDeintBlendThreshold1.Size = new System.Drawing.Size(51, 31);
            edDeintBlendThreshold1.TabIndex = 15;
            edDeintBlendThreshold1.Text = "5";
            // 
            // label203
            // 
            label203.AutoSize = true;
            label203.Location = new System.Drawing.Point(57, 307);
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
            edDeintCAVTThreshold.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            rbDeintTriangleEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDeintTriangleEnabled.Name = "rbDeintTriangleEnabled";
            rbDeintTriangleEnabled.Size = new System.Drawing.Size(97, 29);
            rbDeintTriangleEnabled.TabIndex = 10;
            rbDeintTriangleEnabled.Text = "Triangle";
            rbDeintTriangleEnabled.UseVisualStyleBackColor = true;
            // 
            // rbDeintBlendEnabled
            // 
            rbDeintBlendEnabled.AutoSize = true;
            rbDeintBlendEnabled.Location = new System.Drawing.Point(30, 243);
            rbDeintBlendEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            rbDeintCAVTEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbDeinterlace.Location = new System.Drawing.Point(30, 32);
            cbDeinterlace.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            tabPage59.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage59.Name = "tabPage59";
            tabPage59.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage59.Size = new System.Drawing.Size(489, 894);
            tabPage59.TabIndex = 4;
            tabPage59.Text = "Denoise";
            tabPage59.UseVisualStyleBackColor = true;
            // 
            // rbDenoiseCAST
            // 
            rbDenoiseCAST.AutoSize = true;
            rbDenoiseCAST.Location = new System.Drawing.Point(30, 152);
            rbDenoiseCAST.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            rbDenoiseMosquito.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbDenoise.Location = new System.Drawing.Point(30, 32);
            cbDenoise.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDenoise.Name = "cbDenoise";
            cbDenoise.Size = new System.Drawing.Size(101, 29);
            cbDenoise.TabIndex = 8;
            cbDenoise.Text = "Enabled";
            cbDenoise.UseVisualStyleBackColor = true;
            // 
            // tabPage20
            // 
            tabPage20.Controls.Add(label5);
            tabPage20.Controls.Add(tbGPUBlur);
            tabPage20.Controls.Add(cbVideoEffectsGPUEnabled);
            tabPage20.Controls.Add(cbGPUOldMovie);
            tabPage20.Controls.Add(cbGPUDeinterlace);
            tabPage20.Controls.Add(cbGPUDenoise);
            tabPage20.Controls.Add(cbGPUPixelate);
            tabPage20.Controls.Add(cbGPUNightVision);
            tabPage20.Controls.Add(label383);
            tabPage20.Controls.Add(label384);
            tabPage20.Controls.Add(label385);
            tabPage20.Controls.Add(label386);
            tabPage20.Controls.Add(tbGPUContrast);
            tabPage20.Controls.Add(tbGPUDarkness);
            tabPage20.Controls.Add(tbGPULightness);
            tabPage20.Controls.Add(tbGPUSaturation);
            tabPage20.Controls.Add(cbGPUInvert);
            tabPage20.Controls.Add(cbGPUGreyscale);
            tabPage20.Location = new System.Drawing.Point(4, 34);
            tabPage20.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage20.Name = "tabPage20";
            tabPage20.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage20.Size = new System.Drawing.Size(489, 894);
            tabPage20.TabIndex = 9;
            tabPage20.Text = "GPU effects";
            tabPage20.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(19, 568);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 25);
            label5.TabIndex = 85;
            label5.Text = "Blur";
            // 
            // tbGPUBlur
            // 
            tbGPUBlur.BackColor = System.Drawing.SystemColors.Window;
            tbGPUBlur.Location = new System.Drawing.Point(13, 598);
            tbGPUBlur.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbGPUBlur.Maximum = 30;
            tbGPUBlur.Name = "tbGPUBlur";
            tbGPUBlur.Size = new System.Drawing.Size(217, 69);
            tbGPUBlur.TabIndex = 84;
            tbGPUBlur.Scroll += (this.tbGPUBlur_Scroll);
            // 
            // cbVideoEffectsGPUEnabled
            // 
            cbVideoEffectsGPUEnabled.AutoSize = true;
            cbVideoEffectsGPUEnabled.Location = new System.Drawing.Point(27, 32);
            cbVideoEffectsGPUEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVideoEffectsGPUEnabled.Name = "cbVideoEffectsGPUEnabled";
            cbVideoEffectsGPUEnabled.Size = new System.Drawing.Size(101, 29);
            cbVideoEffectsGPUEnabled.TabIndex = 81;
            cbVideoEffectsGPUEnabled.Text = "Enabled";
            cbVideoEffectsGPUEnabled.UseVisualStyleBackColor = true;
            // 
            // cbGPUOldMovie
            // 
            cbGPUOldMovie.AutoSize = true;
            cbGPUOldMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUOldMovie.Location = new System.Drawing.Point(237, 457);
            cbGPUOldMovie.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUOldMovie.Name = "cbGPUOldMovie";
            cbGPUOldMovie.Size = new System.Drawing.Size(121, 29);
            cbGPUOldMovie.TabIndex = 80;
            cbGPUOldMovie.Text = "Old movie";
            cbGPUOldMovie.UseVisualStyleBackColor = true;
            cbGPUOldMovie.CheckedChanged += (this.cbGPUOldMovie_CheckedChanged);
            // 
            // cbGPUDeinterlace
            // 
            cbGPUDeinterlace.AutoSize = true;
            cbGPUDeinterlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUDeinterlace.Location = new System.Drawing.Point(237, 410);
            cbGPUDeinterlace.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUDeinterlace.Name = "cbGPUDeinterlace";
            cbGPUDeinterlace.Size = new System.Drawing.Size(125, 29);
            cbGPUDeinterlace.TabIndex = 78;
            cbGPUDeinterlace.Text = "Deinterlace";
            cbGPUDeinterlace.UseVisualStyleBackColor = true;
            cbGPUDeinterlace.CheckedChanged += (this.cbGPUDeinterlace_CheckedChanged);
            // 
            // cbGPUDenoise
            // 
            cbGPUDenoise.AutoSize = true;
            cbGPUDenoise.Location = new System.Drawing.Point(23, 410);
            cbGPUDenoise.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUDenoise.Name = "cbGPUDenoise";
            cbGPUDenoise.Size = new System.Drawing.Size(102, 29);
            cbGPUDenoise.TabIndex = 77;
            cbGPUDenoise.Text = "Denoise";
            cbGPUDenoise.UseVisualStyleBackColor = true;
            cbGPUDenoise.CheckedChanged += (this.cbGPUDenoise_CheckedChanged);
            // 
            // cbGPUPixelate
            // 
            cbGPUPixelate.AutoSize = true;
            cbGPUPixelate.Location = new System.Drawing.Point(237, 365);
            cbGPUPixelate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUPixelate.Name = "cbGPUPixelate";
            cbGPUPixelate.Size = new System.Drawing.Size(97, 29);
            cbGPUPixelate.TabIndex = 76;
            cbGPUPixelate.Text = "Pixelate";
            cbGPUPixelate.UseVisualStyleBackColor = true;
            cbGPUPixelate.CheckedChanged += (this.cbGPUPixelate_CheckedChanged);
            // 
            // cbGPUNightVision
            // 
            cbGPUNightVision.AutoSize = true;
            cbGPUNightVision.Location = new System.Drawing.Point(23, 365);
            cbGPUNightVision.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUNightVision.Name = "cbGPUNightVision";
            cbGPUNightVision.Size = new System.Drawing.Size(133, 29);
            cbGPUNightVision.TabIndex = 75;
            cbGPUNightVision.Text = "Night vision";
            cbGPUNightVision.UseVisualStyleBackColor = true;
            cbGPUNightVision.CheckedChanged += (this.cbGPUNightVision_CheckedChanged);
            // 
            // label383
            // 
            label383.AutoSize = true;
            label383.Location = new System.Drawing.Point(244, 188);
            label383.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label383.Name = "label383";
            label383.Size = new System.Drawing.Size(84, 25);
            label383.TabIndex = 74;
            label383.Text = "Darkness";
            // 
            // label384
            // 
            label384.AutoSize = true;
            label384.Location = new System.Drawing.Point(19, 188);
            label384.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label384.Name = "label384";
            label384.Size = new System.Drawing.Size(79, 25);
            label384.TabIndex = 73;
            label384.Text = "Contrast";
            // 
            // label385
            // 
            label385.AutoSize = true;
            label385.Location = new System.Drawing.Point(244, 88);
            label385.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label385.Name = "label385";
            label385.Size = new System.Drawing.Size(93, 25);
            label385.TabIndex = 72;
            label385.Text = "Saturation";
            // 
            // label386
            // 
            label386.AutoSize = true;
            label386.Location = new System.Drawing.Point(19, 88);
            label386.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label386.Name = "label386";
            label386.Size = new System.Drawing.Size(86, 25);
            label386.TabIndex = 71;
            label386.Text = "Lightness";
            // 
            // tbGPUContrast
            // 
            tbGPUContrast.BackColor = System.Drawing.SystemColors.Window;
            tbGPUContrast.Location = new System.Drawing.Point(13, 222);
            tbGPUContrast.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbGPUContrast.Maximum = 255;
            tbGPUContrast.Name = "tbGPUContrast";
            tbGPUContrast.Size = new System.Drawing.Size(217, 69);
            tbGPUContrast.TabIndex = 70;
            tbGPUContrast.Value = 255;
            tbGPUContrast.Scroll += (this.tbGPUContrast_Scroll);
            // 
            // tbGPUDarkness
            // 
            tbGPUDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbGPUDarkness.Location = new System.Drawing.Point(244, 222);
            tbGPUDarkness.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbGPUDarkness.Maximum = 255;
            tbGPUDarkness.Name = "tbGPUDarkness";
            tbGPUDarkness.Size = new System.Drawing.Size(217, 69);
            tbGPUDarkness.TabIndex = 69;
            tbGPUDarkness.Scroll += (this.tbGPUDarkness_Scroll);
            // 
            // tbGPULightness
            // 
            tbGPULightness.BackColor = System.Drawing.SystemColors.Window;
            tbGPULightness.Location = new System.Drawing.Point(13, 115);
            tbGPULightness.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbGPULightness.Maximum = 255;
            tbGPULightness.Name = "tbGPULightness";
            tbGPULightness.Size = new System.Drawing.Size(217, 69);
            tbGPULightness.TabIndex = 68;
            tbGPULightness.Scroll += (this.tbGPULightness_Scroll);
            // 
            // tbGPUSaturation
            // 
            tbGPUSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbGPUSaturation.Location = new System.Drawing.Point(244, 115);
            tbGPUSaturation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbGPUSaturation.Maximum = 255;
            tbGPUSaturation.Name = "tbGPUSaturation";
            tbGPUSaturation.Size = new System.Drawing.Size(217, 69);
            tbGPUSaturation.TabIndex = 67;
            tbGPUSaturation.Value = 255;
            tbGPUSaturation.Scroll += (this.tbGPUSaturation_Scroll);
            // 
            // cbGPUInvert
            // 
            cbGPUInvert.AutoSize = true;
            cbGPUInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbGPUInvert.Location = new System.Drawing.Point(237, 322);
            cbGPUInvert.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUInvert.Name = "cbGPUInvert";
            cbGPUInvert.Size = new System.Drawing.Size(83, 29);
            cbGPUInvert.TabIndex = 66;
            cbGPUInvert.Text = "Invert";
            cbGPUInvert.UseVisualStyleBackColor = true;
            cbGPUInvert.CheckedChanged += (this.cbGPUInvert_CheckedChanged);
            // 
            // cbGPUGreyscale
            // 
            cbGPUGreyscale.AutoSize = true;
            cbGPUGreyscale.Location = new System.Drawing.Point(23, 322);
            cbGPUGreyscale.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbGPUGreyscale.Name = "cbGPUGreyscale";
            cbGPUGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGPUGreyscale.TabIndex = 65;
            cbGPUGreyscale.Text = "Greyscale";
            cbGPUGreyscale.UseVisualStyleBackColor = true;
            cbGPUGreyscale.CheckedChanged += (this.cbGPUGreyscale_CheckedChanged);
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(label92);
            tabPage9.Controls.Add(cbRotate);
            tabPage9.Controls.Add(edCropRight);
            tabPage9.Controls.Add(label52);
            tabPage9.Controls.Add(edCropBottom);
            tabPage9.Controls.Add(label53);
            tabPage9.Controls.Add(edCropLeft);
            tabPage9.Controls.Add(label50);
            tabPage9.Controls.Add(edCropTop);
            tabPage9.Controls.Add(label51);
            tabPage9.Controls.Add(cbCrop);
            tabPage9.Controls.Add(cbResizeMode);
            tabPage9.Controls.Add(label49);
            tabPage9.Controls.Add(cbResizeLetterbox);
            tabPage9.Controls.Add(edResizeHeight);
            tabPage9.Controls.Add(label35);
            tabPage9.Controls.Add(edResizeWidth);
            tabPage9.Controls.Add(label29);
            tabPage9.Controls.Add(cbResize);
            tabPage9.Location = new System.Drawing.Point(4, 34);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new System.Windows.Forms.Padding(3);
            tabPage9.Size = new System.Drawing.Size(489, 894);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Resize / crop / rotate";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            label92.AutoSize = true;
            label92.Location = new System.Drawing.Point(16, 402);
            label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label92.Name = "label92";
            label92.Size = new System.Drawing.Size(63, 25);
            label92.TabIndex = 150;
            label92.Text = "Rotate";
            // 
            // cbRotate
            // 
            cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbRotate.FormattingEnabled = true;
            cbRotate.Items.AddRange(new object[] { "0", "90", "180", "270" });
            cbRotate.Location = new System.Drawing.Point(121, 397);
            cbRotate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbRotate.Name = "cbRotate";
            cbRotate.Size = new System.Drawing.Size(200, 33);
            cbRotate.TabIndex = 149;
            // 
            // edCropRight
            // 
            edCropRight.Location = new System.Drawing.Point(280, 338);
            edCropRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCropRight.Name = "edCropRight";
            edCropRight.Size = new System.Drawing.Size(57, 31);
            edCropRight.TabIndex = 148;
            edCropRight.Text = "0";
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new System.Drawing.Point(211, 347);
            label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(54, 25);
            label52.TabIndex = 147;
            label52.Text = "Right";
            // 
            // edCropBottom
            // 
            edCropBottom.Location = new System.Drawing.Point(121, 338);
            edCropBottom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCropBottom.Name = "edCropBottom";
            edCropBottom.Size = new System.Drawing.Size(57, 31);
            edCropBottom.TabIndex = 146;
            edCropBottom.Text = "0";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(44, 347);
            label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(72, 25);
            label53.TabIndex = 145;
            label53.Text = "Bottom";
            // 
            // edCropLeft
            // 
            edCropLeft.Location = new System.Drawing.Point(280, 288);
            edCropLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCropLeft.Name = "edCropLeft";
            edCropLeft.Size = new System.Drawing.Size(57, 31);
            edCropLeft.TabIndex = 144;
            edCropLeft.Text = "0";
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new System.Drawing.Point(211, 297);
            label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(41, 25);
            label50.TabIndex = 143;
            label50.Text = "Left";
            // 
            // edCropTop
            // 
            edCropTop.Location = new System.Drawing.Point(121, 288);
            edCropTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCropTop.Name = "edCropTop";
            edCropTop.Size = new System.Drawing.Size(57, 31);
            edCropTop.TabIndex = 142;
            edCropTop.Text = "0";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new System.Drawing.Point(44, 297);
            label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(41, 25);
            label51.TabIndex = 141;
            label51.Text = "Top";
            // 
            // cbCrop
            // 
            cbCrop.AutoSize = true;
            cbCrop.Location = new System.Drawing.Point(20, 247);
            cbCrop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCrop.Name = "cbCrop";
            cbCrop.Size = new System.Drawing.Size(77, 29);
            cbCrop.TabIndex = 140;
            cbCrop.Text = "Crop";
            cbCrop.UseVisualStyleBackColor = true;
            // 
            // cbResizeMode
            // 
            cbResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbResizeMode.FormattingEnabled = true;
            cbResizeMode.Items.AddRange(new object[] { "Nearest Neighbor", "Bilinear", "Bicubic", "Lancroz" });
            cbResizeMode.Location = new System.Drawing.Point(103, 175);
            cbResizeMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbResizeMode.Name = "cbResizeMode";
            cbResizeMode.Size = new System.Drawing.Size(205, 33);
            cbResizeMode.TabIndex = 135;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new System.Drawing.Point(33, 182);
            label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(59, 25);
            label49.TabIndex = 134;
            label49.Text = "Mode";
            // 
            // cbResizeLetterbox
            // 
            cbResizeLetterbox.AutoSize = true;
            cbResizeLetterbox.Location = new System.Drawing.Point(37, 125);
            cbResizeLetterbox.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbResizeLetterbox.Name = "cbResizeLetterbox";
            cbResizeLetterbox.Size = new System.Drawing.Size(271, 29);
            cbResizeLetterbox.TabIndex = 133;
            cbResizeLetterbox.Text = "Letterbox (add black borders)";
            cbResizeLetterbox.UseVisualStyleBackColor = true;
            // 
            // edResizeHeight
            // 
            edResizeHeight.Location = new System.Drawing.Point(251, 68);
            edResizeHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edResizeHeight.Name = "edResizeHeight";
            edResizeHeight.Size = new System.Drawing.Size(57, 31);
            edResizeHeight.TabIndex = 132;
            edResizeHeight.Text = "576";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(173, 75);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(65, 25);
            label35.TabIndex = 131;
            label35.Text = "Height";
            // 
            // edResizeWidth
            // 
            edResizeWidth.Location = new System.Drawing.Point(103, 68);
            edResizeWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edResizeWidth.Name = "edResizeWidth";
            edResizeWidth.Size = new System.Drawing.Size(57, 31);
            edResizeWidth.TabIndex = 130;
            edResizeWidth.Text = "768";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(33, 75);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(60, 25);
            label29.TabIndex = 129;
            label29.Text = "Width";
            // 
            // cbResize
            // 
            cbResize.AutoSize = true;
            cbResize.Location = new System.Drawing.Point(20, 25);
            cbResize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbResize.Name = "cbResize";
            cbResize.Size = new System.Drawing.Size(86, 29);
            cbResize.TabIndex = 128;
            cbResize.Text = "Resize";
            cbResize.UseVisualStyleBackColor = true;
            // 
            // tabPage60
            // 
            tabPage60.Controls.Add(pnChromaKeyColor);
            tabPage60.Controls.Add(btChromaKeySelectBGImage);
            tabPage60.Controls.Add(edChromaKeyImage);
            tabPage60.Controls.Add(label216);
            tabPage60.Controls.Add(label215);
            tabPage60.Controls.Add(tbChromaKeySmoothing);
            tabPage60.Controls.Add(label214);
            tabPage60.Controls.Add(tbChromaKeyThresholdSensitivity);
            tabPage60.Controls.Add(label213);
            tabPage60.Controls.Add(cbChromaKeyEnabled);
            tabPage60.Location = new System.Drawing.Point(4, 34);
            tabPage60.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage60.Name = "tabPage60";
            tabPage60.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage60.Size = new System.Drawing.Size(489, 894);
            tabPage60.TabIndex = 5;
            tabPage60.Text = "Chroma key";
            tabPage60.UseVisualStyleBackColor = true;
            // 
            // pnChromaKeyColor
            // 
            pnChromaKeyColor.BackColor = System.Drawing.Color.Lime;
            pnChromaKeyColor.ForeColor = System.Drawing.SystemColors.Control;
            pnChromaKeyColor.Location = new System.Drawing.Point(96, 385);
            pnChromaKeyColor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnChromaKeyColor.Name = "pnChromaKeyColor";
            pnChromaKeyColor.Size = new System.Drawing.Size(43, 47);
            pnChromaKeyColor.TabIndex = 43;
            pnChromaKeyColor.Click += (this.pnChromaKeyColor_Click);
            // 
            // btChromaKeySelectBGImage
            // 
            btChromaKeySelectBGImage.Location = new System.Drawing.Point(429, 503);
            btChromaKeySelectBGImage.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btChromaKeySelectBGImage.Name = "btChromaKeySelectBGImage";
            btChromaKeySelectBGImage.Size = new System.Drawing.Size(40, 43);
            btChromaKeySelectBGImage.TabIndex = 42;
            btChromaKeySelectBGImage.Text = "...";
            btChromaKeySelectBGImage.UseVisualStyleBackColor = true;
            btChromaKeySelectBGImage.Click += (this.btChromaKeySelectBGImage_Click);
            // 
            // edChromaKeyImage
            // 
            edChromaKeyImage.Location = new System.Drawing.Point(24, 508);
            edChromaKeyImage.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edChromaKeyImage.Name = "edChromaKeyImage";
            edChromaKeyImage.Size = new System.Drawing.Size(388, 31);
            edChromaKeyImage.TabIndex = 41;
            edChromaKeyImage.Text = "c:\\Samples\\pics\\1.jpg";
            // 
            // label216
            // 
            label216.AutoSize = true;
            label216.Location = new System.Drawing.Point(20, 478);
            label216.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label216.Name = "label216";
            label216.Size = new System.Drawing.Size(191, 25);
            label216.TabIndex = 40;
            label216.Text = "Image background file";
            // 
            // label215
            // 
            label215.AutoSize = true;
            label215.Location = new System.Drawing.Point(20, 392);
            label215.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label215.Name = "label215";
            label215.Size = new System.Drawing.Size(55, 25);
            label215.TabIndex = 39;
            label215.Text = "Color";
            // 
            // tbChromaKeySmoothing
            // 
            tbChromaKeySmoothing.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeySmoothing.Location = new System.Drawing.Point(24, 278);
            tbChromaKeySmoothing.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbChromaKeySmoothing.Maximum = 1000;
            tbChromaKeySmoothing.Name = "tbChromaKeySmoothing";
            tbChromaKeySmoothing.Size = new System.Drawing.Size(257, 69);
            tbChromaKeySmoothing.TabIndex = 38;
            tbChromaKeySmoothing.Value = 80;
            tbChromaKeySmoothing.Scroll += (this.tbChromaKeySmoothing_Scroll);
            // 
            // label214
            // 
            label214.AutoSize = true;
            label214.Location = new System.Drawing.Point(20, 243);
            label214.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label214.Name = "label214";
            label214.Size = new System.Drawing.Size(101, 25);
            label214.TabIndex = 37;
            label214.Text = "Smoothing";
            // 
            // tbChromaKeyThresholdSensitivity
            // 
            tbChromaKeyThresholdSensitivity.BackColor = System.Drawing.SystemColors.Window;
            tbChromaKeyThresholdSensitivity.Location = new System.Drawing.Point(24, 138);
            tbChromaKeyThresholdSensitivity.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbChromaKeyThresholdSensitivity.Maximum = 200;
            tbChromaKeyThresholdSensitivity.Name = "tbChromaKeyThresholdSensitivity";
            tbChromaKeyThresholdSensitivity.Size = new System.Drawing.Size(257, 69);
            tbChromaKeyThresholdSensitivity.TabIndex = 36;
            tbChromaKeyThresholdSensitivity.Value = 180;
            tbChromaKeyThresholdSensitivity.Scroll += (this.tbChromaKeyThresholdSensitivity_Scroll);
            // 
            // label213
            // 
            label213.AutoSize = true;
            label213.Location = new System.Drawing.Point(20, 103);
            label213.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label213.Name = "label213";
            label213.Size = new System.Drawing.Size(172, 25);
            label213.TabIndex = 35;
            label213.Text = "Threshold sensitivity";
            // 
            // cbChromaKeyEnabled
            // 
            cbChromaKeyEnabled.AutoSize = true;
            cbChromaKeyEnabled.Location = new System.Drawing.Point(24, 28);
            cbChromaKeyEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            tabPage70.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage70.Name = "tabPage70";
            tabPage70.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage70.Size = new System.Drawing.Size(489, 894);
            tabPage70.TabIndex = 3;
            tabPage70.Text = "3rd-party filters";
            tabPage70.UseVisualStyleBackColor = true;
            // 
            // btFilterDeleteAll
            // 
            btFilterDeleteAll.Location = new System.Drawing.Point(350, 552);
            btFilterDeleteAll.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btFilterDeleteAll.Name = "btFilterDeleteAll";
            btFilterDeleteAll.Size = new System.Drawing.Size(113, 43);
            btFilterDeleteAll.TabIndex = 16;
            btFilterDeleteAll.Text = "Delete all";
            btFilterDeleteAll.UseVisualStyleBackColor = true;
            btFilterDeleteAll.Click += (this.btFilterDeleteAll_Click);
            // 
            // btFilterSettings2
            // 
            btFilterSettings2.Location = new System.Drawing.Point(30, 552);
            btFilterSettings2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btFilterSettings2.Name = "btFilterSettings2";
            btFilterSettings2.Size = new System.Drawing.Size(109, 43);
            btFilterSettings2.TabIndex = 15;
            btFilterSettings2.Text = "Settings";
            btFilterSettings2.UseVisualStyleBackColor = true;
            btFilterSettings2.Click += (this.btFilterSettings2_Click);
            // 
            // lbFilters
            // 
            lbFilters.FormattingEnabled = true;
            lbFilters.ItemHeight = 25;
            lbFilters.Location = new System.Drawing.Point(30, 232);
            lbFilters.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbFilters.Name = "lbFilters";
            lbFilters.Size = new System.Drawing.Size(431, 304);
            lbFilters.TabIndex = 14;
            lbFilters.SelectedIndexChanged += (this.lbFilters_SelectedIndexChanged);
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
            btFilterSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btFilterSettings.Name = "btFilterSettings";
            btFilterSettings.Size = new System.Drawing.Size(113, 43);
            btFilterSettings.TabIndex = 12;
            btFilterSettings.Text = "Settings";
            btFilterSettings.UseVisualStyleBackColor = true;
            btFilterSettings.Click += (this.btFilterSettings_Click);
            // 
            // btFilterAdd
            // 
            btFilterAdd.Location = new System.Drawing.Point(30, 110);
            btFilterAdd.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btFilterAdd.Name = "btFilterAdd";
            btFilterAdd.Size = new System.Drawing.Size(64, 43);
            btFilterAdd.TabIndex = 11;
            btFilterAdd.Text = "Add";
            btFilterAdd.UseVisualStyleBackColor = true;
            btFilterAdd.Click += (this.btFilterAdd_Click);
            // 
            // cbFilters
            // 
            cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilters.FormattingEnabled = true;
            cbFilters.Location = new System.Drawing.Point(30, 58);
            cbFilters.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new System.Drawing.Size(431, 33);
            cbFilters.TabIndex = 10;
            cbFilters.SelectedIndexChanged += (this.cbFilters_SelectedIndexChanged);
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
            // tabControl14
            // 
            tabControl14.Controls.Add(tabPage5);
            tabControl14.Controls.Add(tabPage58);
            tabControl14.Location = new System.Drawing.Point(473, 12);
            tabControl14.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl14.Name = "tabControl14";
            tabControl14.SelectedIndex = 0;
            tabControl14.Size = new System.Drawing.Size(29, 88);
            tabControl14.TabIndex = 36;
            // 
            // tabPage5
            // 
            tabPage5.Location = new System.Drawing.Point(4, 34);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage5.Size = new System.Drawing.Size(21, 50);
            tabPage5.TabIndex = 0;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage58
            // 
            tabPage58.Location = new System.Drawing.Point(4, 34);
            tabPage58.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage58.Name = "tabPage58";
            tabPage58.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage58.Size = new System.Drawing.Size(21, 50);
            tabPage58.TabIndex = 1;
            tabPage58.Text = "tabPage58";
            tabPage58.UseVisualStyleBackColor = true;
            // 
            // tabPage127
            // 
            tabPage127.Controls.Add(lbAudioTimeshift);
            tabPage127.Controls.Add(tbAudioTimeshift);
            tabPage127.Controls.Add(label439);
            tabPage127.Controls.Add(groupBox3);
            tabPage127.Controls.Add(groupBox7);
            tabPage127.Controls.Add(cbAudioAutoGain);
            tabPage127.Controls.Add(cbAudioNormalize);
            tabPage127.Controls.Add(cbAudioEnhancementEnabled);
            tabPage127.Location = new System.Drawing.Point(4, 34);
            tabPage127.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage127.Name = "tabPage127";
            tabPage127.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage127.Size = new System.Drawing.Size(516, 944);
            tabPage127.TabIndex = 18;
            tabPage127.Text = "Audio enhancement";
            tabPage127.UseVisualStyleBackColor = true;
            // 
            // lbAudioTimeshift
            // 
            lbAudioTimeshift.AutoSize = true;
            lbAudioTimeshift.Location = new System.Drawing.Point(296, 852);
            lbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAudioTimeshift.Name = "lbAudioTimeshift";
            lbAudioTimeshift.Size = new System.Drawing.Size(51, 25);
            lbAudioTimeshift.TabIndex = 13;
            lbAudioTimeshift.Text = "0 ms";
            // 
            // tbAudioTimeshift
            // 
            tbAudioTimeshift.Location = new System.Drawing.Point(111, 832);
            tbAudioTimeshift.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioTimeshift.Maximum = 3000;
            tbAudioTimeshift.Name = "tbAudioTimeshift";
            tbAudioTimeshift.Size = new System.Drawing.Size(173, 69);
            tbAudioTimeshift.SmallChange = 10;
            tbAudioTimeshift.TabIndex = 12;
            tbAudioTimeshift.TickFrequency = 100;
            tbAudioTimeshift.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioTimeshift.Scroll += (this.tbAudioTimeshift_Scroll);
            // 
            // label439
            // 
            label439.AutoSize = true;
            label439.Location = new System.Drawing.Point(10, 852);
            label439.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label439.Name = "label439";
            label439.Size = new System.Drawing.Size(89, 25);
            label439.TabIndex = 11;
            label439.Text = "Time shift";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbAudioOutputGainLFE);
            groupBox3.Controls.Add(tbAudioOutputGainLFE);
            groupBox3.Controls.Add(label440);
            groupBox3.Controls.Add(lbAudioOutputGainSR);
            groupBox3.Controls.Add(tbAudioOutputGainSR);
            groupBox3.Controls.Add(label441);
            groupBox3.Controls.Add(lbAudioOutputGainSL);
            groupBox3.Controls.Add(tbAudioOutputGainSL);
            groupBox3.Controls.Add(label442);
            groupBox3.Controls.Add(lbAudioOutputGainR);
            groupBox3.Controls.Add(tbAudioOutputGainR);
            groupBox3.Controls.Add(label443);
            groupBox3.Controls.Add(lbAudioOutputGainC);
            groupBox3.Controls.Add(tbAudioOutputGainC);
            groupBox3.Controls.Add(label444);
            groupBox3.Controls.Add(lbAudioOutputGainL);
            groupBox3.Controls.Add(tbAudioOutputGainL);
            groupBox3.Controls.Add(label445);
            groupBox3.Location = new System.Drawing.Point(16, 485);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox3.Size = new System.Drawing.Size(481, 332);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Output gains (dB)";
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
            tbAudioOutputGainLFE.Location = new System.Drawing.Point(403, 78);
            tbAudioOutputGainLFE.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainLFE.Maximum = 200;
            tbAudioOutputGainLFE.Minimum = -200;
            tbAudioOutputGainLFE.Name = "tbAudioOutputGainLFE";
            tbAudioOutputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainLFE.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainLFE.TabIndex = 16;
            tbAudioOutputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainLFE.Scroll += (this.tbAudioOutputGainLFE_Scroll);
            // 
            // label440
            // 
            label440.AutoSize = true;
            label440.Location = new System.Drawing.Point(417, 48);
            label440.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label440.Name = "label440";
            label440.Size = new System.Drawing.Size(38, 25);
            label440.TabIndex = 15;
            label440.Text = "LFE";
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
            tbAudioOutputGainSR.Location = new System.Drawing.Point(323, 78);
            tbAudioOutputGainSR.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainSR.Maximum = 200;
            tbAudioOutputGainSR.Minimum = -200;
            tbAudioOutputGainSR.Name = "tbAudioOutputGainSR";
            tbAudioOutputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainSR.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainSR.TabIndex = 13;
            tbAudioOutputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainSR.Scroll += (this.tbAudioOutputGainSR_Scroll);
            // 
            // label441
            // 
            label441.AutoSize = true;
            label441.Location = new System.Drawing.Point(341, 48);
            label441.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label441.Name = "label441";
            label441.Size = new System.Drawing.Size(33, 25);
            label441.TabIndex = 12;
            label441.Text = "SR";
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
            tbAudioOutputGainSL.Location = new System.Drawing.Point(243, 78);
            tbAudioOutputGainSL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainSL.Maximum = 200;
            tbAudioOutputGainSL.Minimum = -200;
            tbAudioOutputGainSL.Name = "tbAudioOutputGainSL";
            tbAudioOutputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainSL.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainSL.TabIndex = 10;
            tbAudioOutputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainSL.Scroll += (this.tbAudioOutputGainSL_Scroll);
            // 
            // label442
            // 
            label442.AutoSize = true;
            label442.Location = new System.Drawing.Point(263, 48);
            label442.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label442.Name = "label442";
            label442.Size = new System.Drawing.Size(30, 25);
            label442.TabIndex = 9;
            label442.Text = "SL";
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
            tbAudioOutputGainR.Location = new System.Drawing.Point(163, 78);
            tbAudioOutputGainR.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainR.Maximum = 200;
            tbAudioOutputGainR.Minimum = -200;
            tbAudioOutputGainR.Name = "tbAudioOutputGainR";
            tbAudioOutputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainR.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainR.TabIndex = 7;
            tbAudioOutputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainR.Scroll += (this.tbAudioOutputGainR_Scroll);
            // 
            // label443
            // 
            label443.AutoSize = true;
            label443.Location = new System.Drawing.Point(190, 48);
            label443.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label443.Name = "label443";
            label443.Size = new System.Drawing.Size(23, 25);
            label443.TabIndex = 6;
            label443.Text = "R";
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
            tbAudioOutputGainC.Location = new System.Drawing.Point(83, 78);
            tbAudioOutputGainC.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainC.Maximum = 200;
            tbAudioOutputGainC.Minimum = -200;
            tbAudioOutputGainC.Name = "tbAudioOutputGainC";
            tbAudioOutputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainC.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainC.TabIndex = 4;
            tbAudioOutputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainC.Scroll += (this.tbAudioOutputGainC_Scroll);
            // 
            // label444
            // 
            label444.AutoSize = true;
            label444.Location = new System.Drawing.Point(110, 48);
            label444.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label444.Name = "label444";
            label444.Size = new System.Drawing.Size(23, 25);
            label444.TabIndex = 3;
            label444.Text = "C";
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
            tbAudioOutputGainL.Location = new System.Drawing.Point(3, 78);
            tbAudioOutputGainL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioOutputGainL.Maximum = 200;
            tbAudioOutputGainL.Minimum = -200;
            tbAudioOutputGainL.Name = "tbAudioOutputGainL";
            tbAudioOutputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioOutputGainL.Size = new System.Drawing.Size(69, 200);
            tbAudioOutputGainL.TabIndex = 1;
            tbAudioOutputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioOutputGainL.Scroll += (this.tbAudioOutputGainL_Scroll);
            // 
            // label445
            // 
            label445.AutoSize = true;
            label445.Location = new System.Drawing.Point(30, 48);
            label445.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label445.Name = "label445";
            label445.Size = new System.Drawing.Size(20, 25);
            label445.TabIndex = 0;
            label445.Text = "L";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(lbAudioInputGainLFE);
            groupBox7.Controls.Add(tbAudioInputGainLFE);
            groupBox7.Controls.Add(label446);
            groupBox7.Controls.Add(lbAudioInputGainSR);
            groupBox7.Controls.Add(tbAudioInputGainSR);
            groupBox7.Controls.Add(label447);
            groupBox7.Controls.Add(lbAudioInputGainSL);
            groupBox7.Controls.Add(tbAudioInputGainSL);
            groupBox7.Controls.Add(label448);
            groupBox7.Controls.Add(lbAudioInputGainR);
            groupBox7.Controls.Add(tbAudioInputGainR);
            groupBox7.Controls.Add(label449);
            groupBox7.Controls.Add(lbAudioInputGainC);
            groupBox7.Controls.Add(tbAudioInputGainC);
            groupBox7.Controls.Add(label450);
            groupBox7.Controls.Add(lbAudioInputGainL);
            groupBox7.Controls.Add(tbAudioInputGainL);
            groupBox7.Controls.Add(label451);
            groupBox7.Location = new System.Drawing.Point(16, 142);
            groupBox7.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox7.Size = new System.Drawing.Size(481, 332);
            groupBox7.TabIndex = 9;
            groupBox7.TabStop = false;
            groupBox7.Text = "Input gains (dB)";
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
            tbAudioInputGainLFE.Location = new System.Drawing.Point(403, 78);
            tbAudioInputGainLFE.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainLFE.Maximum = 200;
            tbAudioInputGainLFE.Minimum = -200;
            tbAudioInputGainLFE.Name = "tbAudioInputGainLFE";
            tbAudioInputGainLFE.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainLFE.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainLFE.TabIndex = 16;
            tbAudioInputGainLFE.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainLFE.Scroll += (this.tbAudioInputGainLFE_Scroll);
            // 
            // label446
            // 
            label446.AutoSize = true;
            label446.Location = new System.Drawing.Point(417, 48);
            label446.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label446.Name = "label446";
            label446.Size = new System.Drawing.Size(38, 25);
            label446.TabIndex = 15;
            label446.Text = "LFE";
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
            tbAudioInputGainSR.Location = new System.Drawing.Point(323, 78);
            tbAudioInputGainSR.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainSR.Maximum = 200;
            tbAudioInputGainSR.Minimum = -200;
            tbAudioInputGainSR.Name = "tbAudioInputGainSR";
            tbAudioInputGainSR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainSR.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainSR.TabIndex = 13;
            tbAudioInputGainSR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainSR.Scroll += (this.tbAudioInputGainSR_Scroll);
            // 
            // label447
            // 
            label447.AutoSize = true;
            label447.Location = new System.Drawing.Point(341, 48);
            label447.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label447.Name = "label447";
            label447.Size = new System.Drawing.Size(33, 25);
            label447.TabIndex = 12;
            label447.Text = "SR";
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
            tbAudioInputGainSL.Location = new System.Drawing.Point(243, 78);
            tbAudioInputGainSL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainSL.Maximum = 200;
            tbAudioInputGainSL.Minimum = -200;
            tbAudioInputGainSL.Name = "tbAudioInputGainSL";
            tbAudioInputGainSL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainSL.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainSL.TabIndex = 10;
            tbAudioInputGainSL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainSL.Scroll += (this.tbAudioInputGainSL_Scroll);
            // 
            // label448
            // 
            label448.AutoSize = true;
            label448.Location = new System.Drawing.Point(263, 48);
            label448.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label448.Name = "label448";
            label448.Size = new System.Drawing.Size(30, 25);
            label448.TabIndex = 9;
            label448.Text = "SL";
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
            tbAudioInputGainR.Location = new System.Drawing.Point(163, 78);
            tbAudioInputGainR.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainR.Maximum = 200;
            tbAudioInputGainR.Minimum = -200;
            tbAudioInputGainR.Name = "tbAudioInputGainR";
            tbAudioInputGainR.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainR.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainR.TabIndex = 7;
            tbAudioInputGainR.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainR.Scroll += (this.tbAudioInputGainR_Scroll);
            // 
            // label449
            // 
            label449.AutoSize = true;
            label449.Location = new System.Drawing.Point(190, 48);
            label449.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label449.Name = "label449";
            label449.Size = new System.Drawing.Size(23, 25);
            label449.TabIndex = 6;
            label449.Text = "R";
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
            tbAudioInputGainC.Location = new System.Drawing.Point(83, 78);
            tbAudioInputGainC.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainC.Maximum = 200;
            tbAudioInputGainC.Minimum = -200;
            tbAudioInputGainC.Name = "tbAudioInputGainC";
            tbAudioInputGainC.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainC.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainC.TabIndex = 4;
            tbAudioInputGainC.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainC.Scroll += (this.tbAudioInputGainC_Scroll);
            // 
            // label450
            // 
            label450.AutoSize = true;
            label450.Location = new System.Drawing.Point(110, 48);
            label450.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label450.Name = "label450";
            label450.Size = new System.Drawing.Size(23, 25);
            label450.TabIndex = 3;
            label450.Text = "C";
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
            tbAudioInputGainL.Location = new System.Drawing.Point(3, 78);
            tbAudioInputGainL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioInputGainL.Maximum = 200;
            tbAudioInputGainL.Minimum = -200;
            tbAudioInputGainL.Name = "tbAudioInputGainL";
            tbAudioInputGainL.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudioInputGainL.Size = new System.Drawing.Size(69, 200);
            tbAudioInputGainL.TabIndex = 1;
            tbAudioInputGainL.TickStyle = System.Windows.Forms.TickStyle.Both;
            tbAudioInputGainL.Scroll += (this.tbAudioInputGainL_Scroll);
            // 
            // label451
            // 
            label451.AutoSize = true;
            label451.Location = new System.Drawing.Point(30, 48);
            label451.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label451.Name = "label451";
            label451.Size = new System.Drawing.Size(20, 25);
            label451.TabIndex = 0;
            label451.Text = "L";
            // 
            // cbAudioAutoGain
            // 
            cbAudioAutoGain.AutoSize = true;
            cbAudioAutoGain.Location = new System.Drawing.Point(227, 98);
            cbAudioAutoGain.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioAutoGain.Name = "cbAudioAutoGain";
            cbAudioAutoGain.Size = new System.Drawing.Size(116, 29);
            cbAudioAutoGain.TabIndex = 8;
            cbAudioAutoGain.Text = "Auto gain";
            cbAudioAutoGain.UseVisualStyleBackColor = true;
            cbAudioAutoGain.CheckedChanged += (this.cbAudioAutoGain_CheckedChanged);
            // 
            // cbAudioNormalize
            // 
            cbAudioNormalize.AutoSize = true;
            cbAudioNormalize.Location = new System.Drawing.Point(70, 98);
            cbAudioNormalize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioNormalize.Name = "cbAudioNormalize";
            cbAudioNormalize.Size = new System.Drawing.Size(118, 29);
            cbAudioNormalize.TabIndex = 7;
            cbAudioNormalize.Text = "Normalize";
            cbAudioNormalize.UseVisualStyleBackColor = true;
            cbAudioNormalize.CheckedChanged += (this.cbAudioNormalize_CheckedChanged);
            // 
            // cbAudioEnhancementEnabled
            // 
            cbAudioEnhancementEnabled.AutoSize = true;
            cbAudioEnhancementEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudioEnhancementEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioEnhancementEnabled.Name = "cbAudioEnhancementEnabled";
            cbAudioEnhancementEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEnhancementEnabled.TabIndex = 6;
            cbAudioEnhancementEnabled.Text = "Enabled";
            cbAudioEnhancementEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage27
            // 
            tabPage27.Controls.Add(label250);
            tabPage27.Controls.Add(tabControl18);
            tabPage27.Controls.Add(cbAudioEffectsEnabled);
            tabPage27.Location = new System.Drawing.Point(4, 34);
            tabPage27.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage27.Name = "tabPage27";
            tabPage27.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage27.Size = new System.Drawing.Size(516, 944);
            tabPage27.TabIndex = 12;
            tabPage27.Text = "Audio effects";
            tabPage27.UseVisualStyleBackColor = true;
            // 
            // label250
            // 
            label250.AutoSize = true;
            label250.Location = new System.Drawing.Point(167, 32);
            label250.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label250.Name = "label250";
            label250.Size = new System.Drawing.Size(313, 25);
            label250.TabIndex = 5;
            label250.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            tabControl18.Controls.Add(tabPage71);
            tabControl18.Controls.Add(tabPage72);
            tabControl18.Controls.Add(tabPage73);
            tabControl18.Controls.Add(tabPage75);
            tabControl18.Controls.Add(tabPage76);
            tabControl18.Location = new System.Drawing.Point(23, 75);
            tabControl18.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl18.Name = "tabControl18";
            tabControl18.SelectedIndex = 0;
            tabControl18.Size = new System.Drawing.Size(471, 850);
            tabControl18.TabIndex = 1;
            // 
            // tabPage71
            // 
            tabPage71.Controls.Add(label231);
            tabPage71.Controls.Add(label230);
            tabPage71.Controls.Add(tbAudAmplifyAmp);
            tabPage71.Controls.Add(label95);
            tabPage71.Controls.Add(cbAudAmplifyEnabled);
            tabPage71.Location = new System.Drawing.Point(4, 34);
            tabPage71.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage71.Name = "tabPage71";
            tabPage71.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudAmplifyAmp.Maximum = 4000;
            tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            tbAudAmplifyAmp.Size = new System.Drawing.Size(383, 69);
            tbAudAmplifyAmp.TabIndex = 3;
            tbAudAmplifyAmp.TickFrequency = 50;
            tbAudAmplifyAmp.Value = 1000;
            tbAudAmplifyAmp.Scroll += (this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            label95.AutoSize = true;
            label95.Location = new System.Drawing.Point(21, 102);
            label95.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label95.Name = "label95";
            label95.Size = new System.Drawing.Size(72, 25);
            label95.TabIndex = 2;
            label95.Text = "Volume";
            // 
            // cbAudAmplifyEnabled
            // 
            cbAudAmplifyEnabled.AutoSize = true;
            cbAudAmplifyEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            cbAudAmplifyEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudAmplifyEnabled.TabIndex = 1;
            cbAudAmplifyEnabled.Text = "Enabled";
            cbAudAmplifyEnabled.UseVisualStyleBackColor = true;
            cbAudAmplifyEnabled.CheckedChanged += (this.cbAudAmplifyEnabled_CheckedChanged);
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
            tabPage72.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage72.Name = "tabPage72";
            tabPage72.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage72.Size = new System.Drawing.Size(463, 812);
            tabPage72.TabIndex = 1;
            tabPage72.Text = "Equlizer";
            tabPage72.UseVisualStyleBackColor = true;
            // 
            // btAudEqRefresh
            // 
            btAudEqRefresh.Location = new System.Drawing.Point(291, 422);
            btAudEqRefresh.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btAudEqRefresh.Name = "btAudEqRefresh";
            btAudEqRefresh.Size = new System.Drawing.Size(124, 43);
            btAudEqRefresh.TabIndex = 26;
            btAudEqRefresh.Text = "Refresh";
            btAudEqRefresh.UseVisualStyleBackColor = true;
            btAudEqRefresh.Click += (this.btAudEqRefresh_Click);
            // 
            // cbAudEqualizerPreset
            // 
            cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudEqualizerPreset.FormattingEnabled = true;
            cbAudEqualizerPreset.Location = new System.Drawing.Point(101, 347);
            cbAudEqualizerPreset.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudEqualizerPreset.Name = "cbAudEqualizerPreset";
            cbAudEqualizerPreset.Size = new System.Drawing.Size(313, 33);
            cbAudEqualizerPreset.TabIndex = 25;
            cbAudEqualizerPreset.SelectedIndexChanged += (this.cbAudEqualizerPreset_SelectedIndexChanged);
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
            label239.Location = new System.Drawing.Point(239, 300);
            label239.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label239.Name = "label239";
            label239.Size = new System.Drawing.Size(32, 25);
            label239.TabIndex = 20;
            label239.Text = "6K";
            // 
            // label238
            // 
            label238.AutoSize = true;
            label238.Location = new System.Drawing.Point(201, 300);
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
            label232.Location = new System.Drawing.Point(197, 62);
            label232.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label232.Name = "label232";
            label232.Size = new System.Drawing.Size(22, 25);
            label232.TabIndex = 13;
            label232.Text = "0";
            // 
            // tbAudEq9
            // 
            tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq9.Location = new System.Drawing.Point(341, 93);
            tbAudEq9.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq9.Maximum = 100;
            tbAudEq9.Minimum = -100;
            tbAudEq9.Name = "tbAudEq9";
            tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq9.Size = new System.Drawing.Size(69, 200);
            tbAudEq9.TabIndex = 12;
            tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq9.Scroll += (this.tbAudEq9_Scroll);
            // 
            // tbAudEq8
            // 
            tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq8.Location = new System.Drawing.Point(307, 93);
            tbAudEq8.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq8.Maximum = 100;
            tbAudEq8.Minimum = -100;
            tbAudEq8.Name = "tbAudEq8";
            tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq8.Size = new System.Drawing.Size(69, 200);
            tbAudEq8.TabIndex = 11;
            tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq8.Scroll += (this.tbAudEq8_Scroll);
            // 
            // tbAudEq7
            // 
            tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq7.Location = new System.Drawing.Point(270, 93);
            tbAudEq7.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq7.Maximum = 100;
            tbAudEq7.Minimum = -100;
            tbAudEq7.Name = "tbAudEq7";
            tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq7.Size = new System.Drawing.Size(69, 200);
            tbAudEq7.TabIndex = 10;
            tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq7.Scroll += (this.tbAudEq7_Scroll);
            // 
            // tbAudEq6
            // 
            tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq6.Location = new System.Drawing.Point(236, 93);
            tbAudEq6.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq6.Maximum = 100;
            tbAudEq6.Minimum = -100;
            tbAudEq6.Name = "tbAudEq6";
            tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq6.Size = new System.Drawing.Size(69, 200);
            tbAudEq6.TabIndex = 9;
            tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq6.Scroll += (this.tbAudEq6_Scroll);
            // 
            // tbAudEq5
            // 
            tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq5.Location = new System.Drawing.Point(200, 93);
            tbAudEq5.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq5.Maximum = 100;
            tbAudEq5.Minimum = -100;
            tbAudEq5.Name = "tbAudEq5";
            tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq5.Size = new System.Drawing.Size(69, 200);
            tbAudEq5.TabIndex = 8;
            tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq5.Scroll += (this.tbAudEq5_Scroll);
            // 
            // tbAudEq4
            // 
            tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq4.Location = new System.Drawing.Point(167, 93);
            tbAudEq4.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq4.Maximum = 100;
            tbAudEq4.Minimum = -100;
            tbAudEq4.Name = "tbAudEq4";
            tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq4.Size = new System.Drawing.Size(69, 200);
            tbAudEq4.TabIndex = 7;
            tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq4.Scroll += (this.tbAudEq4_Scroll);
            // 
            // tbAudEq3
            // 
            tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq3.Location = new System.Drawing.Point(131, 93);
            tbAudEq3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq3.Maximum = 100;
            tbAudEq3.Minimum = -100;
            tbAudEq3.Name = "tbAudEq3";
            tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq3.Size = new System.Drawing.Size(69, 200);
            tbAudEq3.TabIndex = 6;
            tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq3.Scroll += (this.tbAudEq3_Scroll);
            // 
            // tbAudEq2
            // 
            tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq2.Location = new System.Drawing.Point(97, 93);
            tbAudEq2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq2.Maximum = 100;
            tbAudEq2.Minimum = -100;
            tbAudEq2.Name = "tbAudEq2";
            tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq2.Size = new System.Drawing.Size(69, 200);
            tbAudEq2.TabIndex = 5;
            tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq2.Scroll += (this.tbAudEq2_Scroll);
            // 
            // tbAudEq1
            // 
            tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq1.Location = new System.Drawing.Point(61, 93);
            tbAudEq1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq1.Maximum = 100;
            tbAudEq1.Minimum = -100;
            tbAudEq1.Name = "tbAudEq1";
            tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq1.Size = new System.Drawing.Size(69, 200);
            tbAudEq1.TabIndex = 4;
            tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq1.Scroll += (this.tbAudEq1_Scroll);
            // 
            // tbAudEq0
            // 
            tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            tbAudEq0.Location = new System.Drawing.Point(29, 93);
            tbAudEq0.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudEq0.Maximum = 100;
            tbAudEq0.Minimum = -100;
            tbAudEq0.Name = "tbAudEq0";
            tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbAudEq0.Size = new System.Drawing.Size(69, 200);
            tbAudEq0.TabIndex = 3;
            tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAudEq0.Scroll += (this.tbAudEq0_Scroll);
            // 
            // cbAudEqualizerEnabled
            // 
            cbAudEqualizerEnabled.AutoSize = true;
            cbAudEqualizerEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudEqualizerEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            cbAudEqualizerEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudEqualizerEnabled.TabIndex = 2;
            cbAudEqualizerEnabled.Text = "Enabled";
            cbAudEqualizerEnabled.UseVisualStyleBackColor = true;
            cbAudEqualizerEnabled.CheckedChanged += (this.cbAudEqualizerEnabled_CheckedChanged);
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
            tabPage73.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage73.Name = "tabPage73";
            tabPage73.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage73.Size = new System.Drawing.Size(463, 812);
            tabPage73.TabIndex = 2;
            tabPage73.Text = "Dynamic amplify";
            tabPage73.UseVisualStyleBackColor = true;
            // 
            // tbAudRelease
            // 
            tbAudRelease.BackColor = System.Drawing.SystemColors.Window;
            tbAudRelease.Location = new System.Drawing.Point(27, 402);
            tbAudRelease.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudRelease.Maximum = 10000;
            tbAudRelease.Minimum = 10;
            tbAudRelease.Name = "tbAudRelease";
            tbAudRelease.Size = new System.Drawing.Size(383, 69);
            tbAudRelease.TabIndex = 15;
            tbAudRelease.TickFrequency = 250;
            tbAudRelease.Value = 10;
            tbAudRelease.Scroll += (this.tbAudRelease_Scroll);
            // 
            // label248
            // 
            label248.AutoSize = true;
            label248.Location = new System.Drawing.Point(389, 372);
            label248.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label248.Name = "label248";
            label248.Size = new System.Drawing.Size(22, 25);
            label248.TabIndex = 14;
            label248.Text = "0";
            // 
            // label249
            // 
            label249.AutoSize = true;
            label249.Location = new System.Drawing.Point(21, 372);
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
            tbAudAttack.Location = new System.Drawing.Point(27, 262);
            tbAudAttack.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudAttack.Maximum = 10000;
            tbAudAttack.Minimum = 10;
            tbAudAttack.Name = "tbAudAttack";
            tbAudAttack.Size = new System.Drawing.Size(383, 69);
            tbAudAttack.TabIndex = 10;
            tbAudAttack.TickFrequency = 250;
            tbAudAttack.Value = 10;
            tbAudAttack.Scroll += (this.tbAudAttack_Scroll);
            // 
            // label247
            // 
            label247.AutoSize = true;
            label247.Location = new System.Drawing.Point(21, 232);
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
            tbAudDynAmp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudDynAmp.Maximum = 2000;
            tbAudDynAmp.Minimum = 100;
            tbAudDynAmp.Name = "tbAudDynAmp";
            tbAudDynAmp.Size = new System.Drawing.Size(383, 69);
            tbAudDynAmp.TabIndex = 7;
            tbAudDynAmp.TickFrequency = 50;
            tbAudDynAmp.Value = 1000;
            tbAudDynAmp.Scroll += (this.tbAudDynAmp_Scroll);
            // 
            // label245
            // 
            label245.AutoSize = true;
            label245.Location = new System.Drawing.Point(21, 102);
            label245.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label245.Name = "label245";
            label245.Size = new System.Drawing.Size(198, 25);
            label245.TabIndex = 6;
            label245.Text = "Maximum amplification";
            // 
            // cbAudDynamicAmplifyEnabled
            // 
            cbAudDynamicAmplifyEnabled.AutoSize = true;
            cbAudDynamicAmplifyEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudDynamicAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudDynamicAmplifyEnabled.Name = "cbAudDynamicAmplifyEnabled";
            cbAudDynamicAmplifyEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudDynamicAmplifyEnabled.TabIndex = 2;
            cbAudDynamicAmplifyEnabled.Text = "Enabled";
            cbAudDynamicAmplifyEnabled.UseVisualStyleBackColor = true;
            cbAudDynamicAmplifyEnabled.CheckedChanged += (this.cbAudDynamicAmplifyEnabled_CheckedChanged);
            // 
            // tabPage75
            // 
            tabPage75.Controls.Add(tbAud3DSound);
            tabPage75.Controls.Add(label253);
            tabPage75.Controls.Add(cbAudSound3DEnabled);
            tabPage75.Location = new System.Drawing.Point(4, 34);
            tabPage75.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage75.Name = "tabPage75";
            tabPage75.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage75.Size = new System.Drawing.Size(463, 812);
            tabPage75.TabIndex = 4;
            tabPage75.Text = "Sound 3D";
            tabPage75.UseVisualStyleBackColor = true;
            // 
            // tbAud3DSound
            // 
            tbAud3DSound.BackColor = System.Drawing.SystemColors.Window;
            tbAud3DSound.Location = new System.Drawing.Point(27, 132);
            tbAud3DSound.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAud3DSound.Maximum = 10000;
            tbAud3DSound.Name = "tbAud3DSound";
            tbAud3DSound.Size = new System.Drawing.Size(383, 69);
            tbAud3DSound.TabIndex = 19;
            tbAud3DSound.TickFrequency = 250;
            tbAud3DSound.Value = 500;
            tbAud3DSound.Scroll += (this.tbAud3DSound_Scroll);
            // 
            // label253
            // 
            label253.AutoSize = true;
            label253.Location = new System.Drawing.Point(21, 102);
            label253.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label253.Name = "label253";
            label253.Size = new System.Drawing.Size(142, 25);
            label253.TabIndex = 18;
            label253.Text = "3D amplification";
            // 
            // cbAudSound3DEnabled
            // 
            cbAudSound3DEnabled.AutoSize = true;
            cbAudSound3DEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudSound3DEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudSound3DEnabled.Name = "cbAudSound3DEnabled";
            cbAudSound3DEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudSound3DEnabled.TabIndex = 2;
            cbAudSound3DEnabled.Text = "Enabled";
            cbAudSound3DEnabled.UseVisualStyleBackColor = true;
            cbAudSound3DEnabled.CheckedChanged += (this.cbAudSound3DEnabled_CheckedChanged);
            // 
            // tabPage76
            // 
            tabPage76.Controls.Add(tbAudTrueBass);
            tabPage76.Controls.Add(label254);
            tabPage76.Controls.Add(cbAudTrueBassEnabled);
            tabPage76.Location = new System.Drawing.Point(4, 34);
            tabPage76.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage76.Name = "tabPage76";
            tabPage76.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage76.Size = new System.Drawing.Size(463, 812);
            tabPage76.TabIndex = 5;
            tabPage76.Text = "True bass";
            tabPage76.UseVisualStyleBackColor = true;
            // 
            // tbAudTrueBass
            // 
            tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window;
            tbAudTrueBass.Location = new System.Drawing.Point(27, 132);
            tbAudTrueBass.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudTrueBass.Maximum = 10000;
            tbAudTrueBass.Name = "tbAudTrueBass";
            tbAudTrueBass.Size = new System.Drawing.Size(383, 69);
            tbAudTrueBass.TabIndex = 21;
            tbAudTrueBass.TickFrequency = 250;
            tbAudTrueBass.Scroll += (this.tbAudTrueBass_Scroll);
            // 
            // label254
            // 
            label254.AutoSize = true;
            label254.Location = new System.Drawing.Point(21, 102);
            label254.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label254.Name = "label254";
            label254.Size = new System.Drawing.Size(72, 25);
            label254.TabIndex = 20;
            label254.Text = "Volume";
            // 
            // cbAudTrueBassEnabled
            // 
            cbAudTrueBassEnabled.AutoSize = true;
            cbAudTrueBassEnabled.Location = new System.Drawing.Point(27, 32);
            cbAudTrueBassEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled";
            cbAudTrueBassEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudTrueBassEnabled.TabIndex = 2;
            cbAudTrueBassEnabled.Text = "Enabled";
            cbAudTrueBassEnabled.UseVisualStyleBackColor = true;
            cbAudTrueBassEnabled.CheckedChanged += (this.cbAudTrueBassEnabled_CheckedChanged);
            // 
            // cbAudioEffectsEnabled
            // 
            cbAudioEffectsEnabled.AutoSize = true;
            cbAudioEffectsEnabled.Location = new System.Drawing.Point(23, 32);
            cbAudioEffectsEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            cbAudioEffectsEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioEffectsEnabled.TabIndex = 0;
            cbAudioEffectsEnabled.Text = "Enabled";
            cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage93
            // 
            tabPage93.Controls.Add(btAudioChannelMapperClear);
            tabPage93.Controls.Add(groupBox41);
            tabPage93.Controls.Add(label307);
            tabPage93.Controls.Add(edAudioChannelMapperOutputChannels);
            tabPage93.Controls.Add(label306);
            tabPage93.Controls.Add(lbAudioChannelMapperRoutes);
            tabPage93.Controls.Add(cbAudioChannelMapperEnabled);
            tabPage93.Location = new System.Drawing.Point(4, 34);
            tabPage93.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage93.Name = "tabPage93";
            tabPage93.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage93.Size = new System.Drawing.Size(516, 944);
            tabPage93.TabIndex = 21;
            tabPage93.Text = "Audio channel mapper";
            tabPage93.UseVisualStyleBackColor = true;
            // 
            // btAudioChannelMapperClear
            // 
            btAudioChannelMapperClear.Location = new System.Drawing.Point(353, 435);
            btAudioChannelMapperClear.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btAudioChannelMapperClear.Name = "btAudioChannelMapperClear";
            btAudioChannelMapperClear.Size = new System.Drawing.Size(124, 43);
            btAudioChannelMapperClear.TabIndex = 14;
            btAudioChannelMapperClear.Text = "Clear";
            btAudioChannelMapperClear.UseVisualStyleBackColor = true;
            btAudioChannelMapperClear.Click += (this.btAudioChannelMapperClear_Click);
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
            groupBox41.Location = new System.Drawing.Point(16, 490);
            groupBox41.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox41.Name = "groupBox41";
            groupBox41.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox41.Size = new System.Drawing.Size(487, 328);
            groupBox41.TabIndex = 13;
            groupBox41.TabStop = false;
            groupBox41.Text = "Add new route";
            // 
            // btAudioChannelMapperAddNewRoute
            // 
            btAudioChannelMapperAddNewRoute.Location = new System.Drawing.Point(180, 252);
            btAudioChannelMapperAddNewRoute.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btAudioChannelMapperAddNewRoute.Name = "btAudioChannelMapperAddNewRoute";
            btAudioChannelMapperAddNewRoute.Size = new System.Drawing.Size(124, 43);
            btAudioChannelMapperAddNewRoute.TabIndex = 20;
            btAudioChannelMapperAddNewRoute.Text = "Add";
            btAudioChannelMapperAddNewRoute.UseVisualStyleBackColor = true;
            btAudioChannelMapperAddNewRoute.Click += (this.btAudioChannelMapperAddNewRoute_Click);
            // 
            // label311
            // 
            label311.AutoSize = true;
            label311.Location = new System.Drawing.Point(341, 172);
            label311.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label311.Name = "label311";
            label311.Size = new System.Drawing.Size(109, 25);
            label311.TabIndex = 19;
            label311.Text = "10% - 200%";
            // 
            // tbAudioChannelMapperVolume
            // 
            tbAudioChannelMapperVolume.Location = new System.Drawing.Point(347, 78);
            tbAudioChannelMapperVolume.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            label310.Location = new System.Drawing.Point(341, 48);
            label310.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label310.Name = "label310";
            label310.Size = new System.Drawing.Size(72, 25);
            label310.TabIndex = 17;
            label310.Text = "Volume";
            // 
            // edAudioChannelMapperTargetChannel
            // 
            edAudioChannelMapperTargetChannel.Location = new System.Drawing.Point(180, 78);
            edAudioChannelMapperTargetChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edAudioChannelMapperTargetChannel.Name = "edAudioChannelMapperTargetChannel";
            edAudioChannelMapperTargetChannel.Size = new System.Drawing.Size(83, 31);
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
            edAudioChannelMapperSourceChannel.Location = new System.Drawing.Point(24, 78);
            edAudioChannelMapperSourceChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edAudioChannelMapperSourceChannel.Name = "edAudioChannelMapperSourceChannel";
            edAudioChannelMapperSourceChannel.Size = new System.Drawing.Size(83, 31);
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
            label307.Location = new System.Drawing.Point(29, 207);
            label307.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label307.Name = "label307";
            label307.Size = new System.Drawing.Size(66, 25);
            label307.TabIndex = 4;
            label307.Text = "Routes";
            // 
            // edAudioChannelMapperOutputChannels
            // 
            edAudioChannelMapperOutputChannels.Location = new System.Drawing.Point(33, 132);
            edAudioChannelMapperOutputChannels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edAudioChannelMapperOutputChannels.Name = "edAudioChannelMapperOutputChannels";
            edAudioChannelMapperOutputChannels.Size = new System.Drawing.Size(67, 31);
            edAudioChannelMapperOutputChannels.TabIndex = 3;
            edAudioChannelMapperOutputChannels.Text = "0";
            // 
            // label306
            // 
            label306.AutoSize = true;
            label306.Location = new System.Drawing.Point(29, 100);
            label306.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label306.Name = "label306";
            label306.Size = new System.Drawing.Size(458, 25);
            label306.TabIndex = 2;
            label306.Text = "Output channels count (0 to use original channels count)";
            // 
            // lbAudioChannelMapperRoutes
            // 
            lbAudioChannelMapperRoutes.FormattingEnabled = true;
            lbAudioChannelMapperRoutes.ItemHeight = 25;
            lbAudioChannelMapperRoutes.Location = new System.Drawing.Point(33, 240);
            lbAudioChannelMapperRoutes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbAudioChannelMapperRoutes.Name = "lbAudioChannelMapperRoutes";
            lbAudioChannelMapperRoutes.Size = new System.Drawing.Size(443, 179);
            lbAudioChannelMapperRoutes.TabIndex = 1;
            // 
            // cbAudioChannelMapperEnabled
            // 
            cbAudioChannelMapperEnabled.AutoSize = true;
            cbAudioChannelMapperEnabled.Location = new System.Drawing.Point(33, 35);
            cbAudioChannelMapperEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioChannelMapperEnabled.Name = "cbAudioChannelMapperEnabled";
            cbAudioChannelMapperEnabled.Size = new System.Drawing.Size(101, 29);
            cbAudioChannelMapperEnabled.TabIndex = 0;
            cbAudioChannelMapperEnabled.Text = "Enabled";
            cbAudioChannelMapperEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage107
            // 
            tabPage107.Controls.Add(edFaceTrackingFaces);
            tabPage107.Controls.Add(label364);
            tabPage107.Controls.Add(label363);
            tabPage107.Controls.Add(cbFaceTrackingScalingMode);
            tabPage107.Controls.Add(label362);
            tabPage107.Controls.Add(edFaceTrackingScaleFactor);
            tabPage107.Controls.Add(label361);
            tabPage107.Controls.Add(cbFaceTrackingSearchMode);
            tabPage107.Controls.Add(cbFaceTrackingColorMode);
            tabPage107.Controls.Add(label346);
            tabPage107.Controls.Add(edFaceTrackingMinimumWindowSize);
            tabPage107.Controls.Add(label345);
            tabPage107.Controls.Add(cbFaceTrackingCHL);
            tabPage107.Controls.Add(cbFaceTrackingEnabled);
            tabPage107.Location = new System.Drawing.Point(4, 34);
            tabPage107.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage107.Name = "tabPage107";
            tabPage107.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage107.Size = new System.Drawing.Size(516, 944);
            tabPage107.TabIndex = 17;
            tabPage107.Text = "Face tracking";
            tabPage107.UseVisualStyleBackColor = true;
            // 
            // edFaceTrackingFaces
            // 
            edFaceTrackingFaces.Location = new System.Drawing.Point(56, 568);
            edFaceTrackingFaces.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edFaceTrackingFaces.Multiline = true;
            edFaceTrackingFaces.Name = "edFaceTrackingFaces";
            edFaceTrackingFaces.Size = new System.Drawing.Size(421, 322);
            edFaceTrackingFaces.TabIndex = 13;
            // 
            // label364
            // 
            label364.AutoSize = true;
            label364.Location = new System.Drawing.Point(50, 532);
            label364.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label364.Name = "label364";
            label364.Size = new System.Drawing.Size(128, 25);
            label364.TabIndex = 12;
            label364.Text = "Detected faces";
            // 
            // label363
            // 
            label363.AutoSize = true;
            label363.Location = new System.Drawing.Point(50, 437);
            label363.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label363.Name = "label363";
            label363.Size = new System.Drawing.Size(120, 25);
            label363.TabIndex = 11;
            label363.Text = "Scaling mode";
            // 
            // cbFaceTrackingScalingMode
            // 
            cbFaceTrackingScalingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFaceTrackingScalingMode.FormattingEnabled = true;
            cbFaceTrackingScalingMode.Items.AddRange(new object[] { "Greater to smaller", "Smaller to greater" });
            cbFaceTrackingScalingMode.Location = new System.Drawing.Point(277, 432);
            cbFaceTrackingScalingMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFaceTrackingScalingMode.Name = "cbFaceTrackingScalingMode";
            cbFaceTrackingScalingMode.Size = new System.Drawing.Size(200, 33);
            cbFaceTrackingScalingMode.TabIndex = 10;
            // 
            // label362
            // 
            label362.AutoSize = true;
            label362.Location = new System.Drawing.Point(50, 368);
            label362.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label362.Name = "label362";
            label362.Size = new System.Drawing.Size(103, 25);
            label362.TabIndex = 9;
            label362.Text = "Scale factor";
            // 
            // edFaceTrackingScaleFactor
            // 
            edFaceTrackingScaleFactor.Location = new System.Drawing.Point(277, 362);
            edFaceTrackingScaleFactor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edFaceTrackingScaleFactor.Name = "edFaceTrackingScaleFactor";
            edFaceTrackingScaleFactor.Size = new System.Drawing.Size(73, 31);
            edFaceTrackingScaleFactor.TabIndex = 8;
            edFaceTrackingScaleFactor.Text = "1.2";
            // 
            // label361
            // 
            label361.AutoSize = true;
            label361.Location = new System.Drawing.Point(50, 293);
            label361.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label361.Name = "label361";
            label361.Size = new System.Drawing.Size(116, 25);
            label361.TabIndex = 7;
            label361.Text = "Search mode";
            // 
            // cbFaceTrackingSearchMode
            // 
            cbFaceTrackingSearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFaceTrackingSearchMode.FormattingEnabled = true;
            cbFaceTrackingSearchMode.Items.AddRange(new object[] { "Default", "Single", "No overlap", "Average" });
            cbFaceTrackingSearchMode.Location = new System.Drawing.Point(277, 288);
            cbFaceTrackingSearchMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFaceTrackingSearchMode.Name = "cbFaceTrackingSearchMode";
            cbFaceTrackingSearchMode.Size = new System.Drawing.Size(200, 33);
            cbFaceTrackingSearchMode.TabIndex = 6;
            // 
            // cbFaceTrackingColorMode
            // 
            cbFaceTrackingColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFaceTrackingColorMode.FormattingEnabled = true;
            cbFaceTrackingColorMode.Items.AddRange(new object[] { "RGB", "HSL", "Mixed" });
            cbFaceTrackingColorMode.Location = new System.Drawing.Point(277, 218);
            cbFaceTrackingColorMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFaceTrackingColorMode.Name = "cbFaceTrackingColorMode";
            cbFaceTrackingColorMode.Size = new System.Drawing.Size(200, 33);
            cbFaceTrackingColorMode.TabIndex = 5;
            // 
            // label346
            // 
            label346.AutoSize = true;
            label346.Location = new System.Drawing.Point(50, 222);
            label346.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label346.Name = "label346";
            label346.Size = new System.Drawing.Size(107, 25);
            label346.TabIndex = 4;
            label346.Text = "Color mode";
            // 
            // edFaceTrackingMinimumWindowSize
            // 
            edFaceTrackingMinimumWindowSize.Location = new System.Drawing.Point(277, 152);
            edFaceTrackingMinimumWindowSize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edFaceTrackingMinimumWindowSize.Name = "edFaceTrackingMinimumWindowSize";
            edFaceTrackingMinimumWindowSize.Size = new System.Drawing.Size(73, 31);
            edFaceTrackingMinimumWindowSize.TabIndex = 3;
            edFaceTrackingMinimumWindowSize.Text = "25";
            // 
            // label345
            // 
            label345.AutoSize = true;
            label345.Location = new System.Drawing.Point(50, 158);
            label345.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label345.Name = "label345";
            label345.Size = new System.Drawing.Size(189, 25);
            label345.TabIndex = 2;
            label345.Text = "Minimum window size";
            // 
            // cbFaceTrackingCHL
            // 
            cbFaceTrackingCHL.AutoSize = true;
            cbFaceTrackingCHL.Checked = true;
            cbFaceTrackingCHL.CheckState = System.Windows.Forms.CheckState.Checked;
            cbFaceTrackingCHL.Location = new System.Drawing.Point(56, 100);
            cbFaceTrackingCHL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFaceTrackingCHL.Name = "cbFaceTrackingCHL";
            cbFaceTrackingCHL.Size = new System.Drawing.Size(156, 29);
            cbFaceTrackingCHL.TabIndex = 1;
            cbFaceTrackingCHL.Text = "Color highlight";
            cbFaceTrackingCHL.UseVisualStyleBackColor = true;
            // 
            // cbFaceTrackingEnabled
            // 
            cbFaceTrackingEnabled.AutoSize = true;
            cbFaceTrackingEnabled.Location = new System.Drawing.Point(30, 38);
            cbFaceTrackingEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFaceTrackingEnabled.Name = "cbFaceTrackingEnabled";
            cbFaceTrackingEnabled.Size = new System.Drawing.Size(101, 29);
            cbFaceTrackingEnabled.TabIndex = 0;
            cbFaceTrackingEnabled.Text = "Enabled";
            cbFaceTrackingEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(cbNetworkStreamingMode);
            tabPage7.Controls.Add(tabControl5);
            tabPage7.Controls.Add(cbNetworkStreamingAudioEnabled);
            tabPage7.Controls.Add(cbNetworkStreaming);
            tabPage7.Location = new System.Drawing.Point(4, 34);
            tabPage7.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage7.Size = new System.Drawing.Size(516, 944);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Network streaming";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreamingMode
            // 
            cbNetworkStreamingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbNetworkStreamingMode.FormattingEnabled = true;
            cbNetworkStreamingMode.Items.AddRange(new object[] { "Windows Media Video", "HTTP MJPEG", "RTSP", "RTMP (including YouTube and Facebook)", "NDI", "UDP", "Smooth Streaming to Microsoft IIS", "HTTP Live Streaming (HLS)", "Output to external virtual devices", "Icecast" });
            cbNetworkStreamingMode.Location = new System.Drawing.Point(30, 78);
            cbNetworkStreamingMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkStreamingMode.Name = "cbNetworkStreamingMode";
            cbNetworkStreamingMode.Size = new System.Drawing.Size(457, 33);
            cbNetworkStreamingMode.TabIndex = 19;
            // 
            // tabControl5
            // 
            tabControl5.Controls.Add(tpWMV);
            tabControl5.Controls.Add(tpRTSP);
            tabControl5.Controls.Add(tpRTMP);
            tabControl5.Controls.Add(tpNDI);
            tabControl5.Controls.Add(tpUDP);
            tabControl5.Controls.Add(tpSSF);
            tabControl5.Controls.Add(tpHLS);
            tabControl5.Controls.Add(tpNSExternal);
            tabControl5.Controls.Add(tabPage3);
            tabControl5.Controls.Add(tabPage6);
            tabControl5.Location = new System.Drawing.Point(10, 140);
            tabControl5.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl5.Name = "tabControl5";
            tabControl5.SelectedIndex = 0;
            tabControl5.Size = new System.Drawing.Size(487, 735);
            tabControl5.TabIndex = 18;
            // 
            // tpWMV
            // 
            tpWMV.Controls.Add(label48);
            tpWMV.Controls.Add(edNetworkURL);
            tpWMV.Controls.Add(edWMVNetworkPort);
            tpWMV.Controls.Add(label47);
            tpWMV.Controls.Add(btRefreshClients);
            tpWMV.Controls.Add(lbNetworkClients);
            tpWMV.Controls.Add(rbNetworkStreamingUseExternalProfile);
            tpWMV.Controls.Add(rbNetworkStreamingUseMainWMVSettings);
            tpWMV.Controls.Add(label81);
            tpWMV.Controls.Add(label80);
            tpWMV.Controls.Add(edMaximumClients);
            tpWMV.Controls.Add(label46);
            tpWMV.Controls.Add(btSelectWMVProfileNetwork);
            tpWMV.Controls.Add(edNetworkStreamingWMVProfile);
            tpWMV.Controls.Add(label44);
            tpWMV.Location = new System.Drawing.Point(4, 34);
            tpWMV.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpWMV.Name = "tpWMV";
            tpWMV.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpWMV.Size = new System.Drawing.Size(479, 697);
            tpWMV.TabIndex = 0;
            tpWMV.Text = "WMV";
            tpWMV.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new System.Drawing.Point(20, 585);
            label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(138, 25);
            label48.TabIndex = 32;
            label48.Text = "Connection URL";
            // 
            // edNetworkURL
            // 
            edNetworkURL.Location = new System.Drawing.Point(24, 615);
            edNetworkURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkURL.Name = "edNetworkURL";
            edNetworkURL.ReadOnly = true;
            edNetworkURL.Size = new System.Drawing.Size(423, 31);
            edNetworkURL.TabIndex = 31;
            // 
            // edWMVNetworkPort
            // 
            edWMVNetworkPort.Location = new System.Drawing.Point(393, 232);
            edWMVNetworkPort.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edWMVNetworkPort.Name = "edWMVNetworkPort";
            edWMVNetworkPort.Size = new System.Drawing.Size(54, 31);
            edWMVNetworkPort.TabIndex = 30;
            edWMVNetworkPort.Text = "100";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new System.Drawing.Point(270, 237);
            label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(118, 25);
            label47.TabIndex = 29;
            label47.Text = "Network port";
            // 
            // btRefreshClients
            // 
            btRefreshClients.Location = new System.Drawing.Point(343, 457);
            btRefreshClients.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btRefreshClients.Name = "btRefreshClients";
            btRefreshClients.Size = new System.Drawing.Size(107, 43);
            btRefreshClients.TabIndex = 28;
            btRefreshClients.Text = "Refresh";
            btRefreshClients.UseVisualStyleBackColor = true;
            btRefreshClients.Click += (this.btRefreshClients_Click);
            // 
            // lbNetworkClients
            // 
            lbNetworkClients.FormattingEnabled = true;
            lbNetworkClients.ItemHeight = 25;
            lbNetworkClients.Location = new System.Drawing.Point(24, 338);
            lbNetworkClients.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbNetworkClients.Name = "lbNetworkClients";
            lbNetworkClients.Size = new System.Drawing.Size(423, 104);
            lbNetworkClients.TabIndex = 27;
            // 
            // rbNetworkStreamingUseExternalProfile
            // 
            rbNetworkStreamingUseExternalProfile.AutoSize = true;
            rbNetworkStreamingUseExternalProfile.Location = new System.Drawing.Point(24, 72);
            rbNetworkStreamingUseExternalProfile.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            rbNetworkStreamingUseMainWMVSettings.Location = new System.Drawing.Point(24, 28);
            rbNetworkStreamingUseMainWMVSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            label80.Location = new System.Drawing.Point(21, 307);
            label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label80.Name = "label80";
            label80.Size = new System.Drawing.Size(64, 25);
            label80.TabIndex = 23;
            label80.Text = "Clients";
            // 
            // edMaximumClients
            // 
            edMaximumClients.Location = new System.Drawing.Point(181, 232);
            edMaximumClients.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edMaximumClients.Name = "edMaximumClients";
            edMaximumClients.Size = new System.Drawing.Size(54, 31);
            edMaximumClients.TabIndex = 22;
            edMaximumClients.Text = "10";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new System.Drawing.Point(21, 237);
            label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(145, 25);
            label46.TabIndex = 21;
            label46.Text = "Maximum clients";
            // 
            // btSelectWMVProfileNetwork
            // 
            btSelectWMVProfileNetwork.Location = new System.Drawing.Point(410, 158);
            btSelectWMVProfileNetwork.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSelectWMVProfileNetwork.Name = "btSelectWMVProfileNetwork";
            btSelectWMVProfileNetwork.Size = new System.Drawing.Size(40, 43);
            btSelectWMVProfileNetwork.TabIndex = 20;
            btSelectWMVProfileNetwork.Text = "...";
            btSelectWMVProfileNetwork.UseVisualStyleBackColor = true;
            btSelectWMVProfileNetwork.Click += (this.btSelectWMVProfileNetwork_Click);
            // 
            // edNetworkStreamingWMVProfile
            // 
            edNetworkStreamingWMVProfile.Location = new System.Drawing.Point(61, 162);
            edNetworkStreamingWMVProfile.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkStreamingWMVProfile.Name = "edNetworkStreamingWMVProfile";
            edNetworkStreamingWMVProfile.Size = new System.Drawing.Size(341, 31);
            edNetworkStreamingWMVProfile.TabIndex = 19;
            edNetworkStreamingWMVProfile.Text = "c:\\WM.prx";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(57, 132);
            label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(87, 25);
            label44.TabIndex = 18;
            label44.Text = "File name";
            // 
            // tpRTSP
            // 
            tpRTSP.Controls.Add(edNetworkRTSPURL);
            tpRTSP.Controls.Add(label367);
            tpRTSP.Controls.Add(label366);
            tpRTSP.Location = new System.Drawing.Point(4, 34);
            tpRTSP.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpRTSP.Name = "tpRTSP";
            tpRTSP.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpRTSP.Size = new System.Drawing.Size(479, 697);
            tpRTSP.TabIndex = 2;
            tpRTSP.Text = "RTSP";
            tpRTSP.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTSPURL
            // 
            edNetworkRTSPURL.Location = new System.Drawing.Point(33, 58);
            edNetworkRTSPURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkRTSPURL.Name = "edNetworkRTSPURL";
            edNetworkRTSPURL.Size = new System.Drawing.Size(408, 31);
            edNetworkRTSPURL.TabIndex = 4;
            edNetworkRTSPURL.Text = "rtsp://localhost:5554/vfstream";
            // 
            // label367
            // 
            label367.AutoSize = true;
            label367.Location = new System.Drawing.Point(29, 28);
            label367.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label367.Name = "label367";
            label367.Size = new System.Drawing.Size(43, 25);
            label367.TabIndex = 3;
            label367.Text = "URL";
            // 
            // label366
            // 
            label366.AutoSize = true;
            label366.Location = new System.Drawing.Point(29, 628);
            label366.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label366.Name = "label366";
            label366.Size = new System.Drawing.Size(272, 25);
            label366.TabIndex = 2;
            label366.Text = "MP4 output settings will be used";
            // 
            // tpRTMP
            // 
            tpRTMP.Controls.Add(groupBox4);
            tpRTMP.Controls.Add(cbNetworkRTMPFFMPEGUsePipes);
            tpRTMP.Controls.Add(rbNetworkRTMPFFMPEGCustom);
            tpRTMP.Controls.Add(rbNetworkRTMPFFMPEG);
            tpRTMP.Controls.Add(label369);
            tpRTMP.Location = new System.Drawing.Point(4, 34);
            tpRTMP.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpRTMP.Name = "tpRTMP";
            tpRTMP.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpRTMP.Size = new System.Drawing.Size(479, 697);
            tpRTMP.TabIndex = 3;
            tpRTMP.Text = "RTMP";
            tpRTMP.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbNetworkRTMPGeneric);
            groupBox4.Controls.Add(edNetworkRTMPFacebook);
            groupBox4.Controls.Add(rbNetworkRTMPFacebook);
            groupBox4.Controls.Add(edNetworkRTMPYouTube);
            groupBox4.Controls.Add(rbNetworkRTMPYouTube);
            groupBox4.Controls.Add(edNetworkRTMPURL);
            groupBox4.Controls.Add(label368);
            groupBox4.Location = new System.Drawing.Point(33, 207);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(409, 343);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            groupBox4.Text = "Target";
            // 
            // rbNetworkRTMPGeneric
            // 
            rbNetworkRTMPGeneric.AutoSize = true;
            rbNetworkRTMPGeneric.Checked = true;
            rbNetworkRTMPGeneric.Location = new System.Drawing.Point(20, 212);
            rbNetworkRTMPGeneric.Name = "rbNetworkRTMPGeneric";
            rbNetworkRTMPGeneric.Size = new System.Drawing.Size(145, 29);
            rbNetworkRTMPGeneric.TabIndex = 16;
            rbNetworkRTMPGeneric.TabStop = true;
            rbNetworkRTMPGeneric.Text = "Generic RTMP";
            rbNetworkRTMPGeneric.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTMPFacebook
            // 
            edNetworkRTMPFacebook.Location = new System.Drawing.Point(41, 163);
            edNetworkRTMPFacebook.Name = "edNetworkRTMPFacebook";
            edNetworkRTMPFacebook.Size = new System.Drawing.Size(350, 31);
            edNetworkRTMPFacebook.TabIndex = 15;
            edNetworkRTMPFacebook.Text = "KEY";
            // 
            // rbNetworkRTMPFacebook
            // 
            rbNetworkRTMPFacebook.AutoSize = true;
            rbNetworkRTMPFacebook.Location = new System.Drawing.Point(20, 128);
            rbNetworkRTMPFacebook.Name = "rbNetworkRTMPFacebook";
            rbNetworkRTMPFacebook.Size = new System.Drawing.Size(113, 29);
            rbNetworkRTMPFacebook.TabIndex = 14;
            rbNetworkRTMPFacebook.Text = "Facebook";
            rbNetworkRTMPFacebook.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTMPYouTube
            // 
            edNetworkRTMPYouTube.Location = new System.Drawing.Point(41, 82);
            edNetworkRTMPYouTube.Name = "edNetworkRTMPYouTube";
            edNetworkRTMPYouTube.Size = new System.Drawing.Size(350, 31);
            edNetworkRTMPYouTube.TabIndex = 13;
            edNetworkRTMPYouTube.Text = "KEY";
            // 
            // rbNetworkRTMPYouTube
            // 
            rbNetworkRTMPYouTube.AutoSize = true;
            rbNetworkRTMPYouTube.Location = new System.Drawing.Point(20, 47);
            rbNetworkRTMPYouTube.Name = "rbNetworkRTMPYouTube";
            rbNetworkRTMPYouTube.Size = new System.Drawing.Size(105, 29);
            rbNetworkRTMPYouTube.TabIndex = 12;
            rbNetworkRTMPYouTube.Text = "YouTube";
            rbNetworkRTMPYouTube.UseVisualStyleBackColor = true;
            // 
            // edNetworkRTMPURL
            // 
            edNetworkRTMPURL.Location = new System.Drawing.Point(41, 287);
            edNetworkRTMPURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkRTMPURL.Name = "edNetworkRTMPURL";
            edNetworkRTMPURL.Size = new System.Drawing.Size(350, 31);
            edNetworkRTMPURL.TabIndex = 11;
            edNetworkRTMPURL.Text = "rtmp://localhost:5554/live/Stream";
            // 
            // label368
            // 
            label368.AutoSize = true;
            label368.Location = new System.Drawing.Point(41, 255);
            label368.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label368.Name = "label368";
            label368.Size = new System.Drawing.Size(43, 25);
            label368.TabIndex = 10;
            label368.Text = "URL";
            // 
            // cbNetworkRTMPFFMPEGUsePipes
            // 
            cbNetworkRTMPFFMPEGUsePipes.AutoSize = true;
            cbNetworkRTMPFFMPEGUsePipes.Checked = true;
            cbNetworkRTMPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            cbNetworkRTMPFFMPEGUsePipes.Location = new System.Drawing.Point(33, 147);
            cbNetworkRTMPFFMPEGUsePipes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkRTMPFFMPEGUsePipes.Name = "cbNetworkRTMPFFMPEGUsePipes";
            cbNetworkRTMPFFMPEGUsePipes.Size = new System.Drawing.Size(115, 29);
            cbNetworkRTMPFFMPEGUsePipes.TabIndex = 14;
            cbNetworkRTMPFFMPEGUsePipes.Text = "Use pipes";
            cbNetworkRTMPFFMPEGUsePipes.UseVisualStyleBackColor = true;
            // 
            // rbNetworkRTMPFFMPEGCustom
            // 
            rbNetworkRTMPFFMPEGCustom.AutoSize = true;
            rbNetworkRTMPFFMPEGCustom.Location = new System.Drawing.Point(33, 78);
            rbNetworkRTMPFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkRTMPFFMPEGCustom.Name = "rbNetworkRTMPFFMPEGCustom";
            rbNetworkRTMPFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkRTMPFFMPEGCustom.TabIndex = 11;
            rbNetworkRTMPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkRTMPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkRTMPFFMPEG
            // 
            rbNetworkRTMPFFMPEG.AutoSize = true;
            rbNetworkRTMPFFMPEG.Checked = true;
            rbNetworkRTMPFFMPEG.Location = new System.Drawing.Point(33, 35);
            rbNetworkRTMPFFMPEG.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkRTMPFFMPEG.Name = "rbNetworkRTMPFFMPEG";
            rbNetworkRTMPFFMPEG.Size = new System.Drawing.Size(284, 29);
            rbNetworkRTMPFFMPEG.TabIndex = 10;
            rbNetworkRTMPFFMPEG.TabStop = true;
            rbNetworkRTMPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkRTMPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // label369
            // 
            label369.AutoSize = true;
            label369.Location = new System.Drawing.Point(50, 628);
            label369.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label369.Name = "label369";
            label369.Size = new System.Drawing.Size(374, 25);
            label369.TabIndex = 7;
            label369.Text = "Format settings located on output format tab";
            // 
            // tpNDI
            // 
            tpNDI.Controls.Add(linkLabel6);
            tpNDI.Controls.Add(label38);
            tpNDI.Controls.Add(label31);
            tpNDI.Controls.Add(edNDIURL);
            tpNDI.Controls.Add(edNDIName);
            tpNDI.Controls.Add(label30);
            tpNDI.Location = new System.Drawing.Point(4, 34);
            tpNDI.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpNDI.Name = "tpNDI";
            tpNDI.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpNDI.Size = new System.Drawing.Size(479, 697);
            tpNDI.TabIndex = 7;
            tpNDI.Text = "NDI";
            tpNDI.UseVisualStyleBackColor = true;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Location = new System.Drawing.Point(27, 247);
            linkLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new System.Drawing.Size(145, 25);
            linkLabel6.TabIndex = 89;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "vendor's website";
            linkLabel6.LinkClicked += (this.lbNDI_LinkClicked);
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new System.Drawing.Point(27, 222);
            label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(428, 25);
            label38.TabIndex = 88;
            label38.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(27, 122);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(138, 25);
            label31.TabIndex = 34;
            label31.Text = "Connection URL";
            // 
            // edNDIURL
            // 
            edNDIURL.Location = new System.Drawing.Point(31, 153);
            edNDIURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNDIURL.Name = "edNDIURL";
            edNDIURL.ReadOnly = true;
            edNDIURL.Size = new System.Drawing.Size(403, 31);
            edNDIURL.TabIndex = 33;
            // 
            // edNDIName
            // 
            edNDIName.Location = new System.Drawing.Point(31, 53);
            edNDIName.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNDIName.Name = "edNDIName";
            edNDIName.Size = new System.Drawing.Size(403, 31);
            edNDIName.TabIndex = 1;
            edNDIName.Text = "Main";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(27, 22);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(59, 25);
            label30.TabIndex = 0;
            label30.Text = "Name";
            // 
            // tpUDP
            // 
            tpUDP.Controls.Add(label63);
            tpUDP.Controls.Add(label62);
            tpUDP.Controls.Add(cbNetworkUDPFFMPEGUsePipes);
            tpUDP.Controls.Add(label314);
            tpUDP.Controls.Add(label313);
            tpUDP.Controls.Add(label484);
            tpUDP.Controls.Add(edNetworkUDPURL);
            tpUDP.Controls.Add(label372);
            tpUDP.Controls.Add(rbNetworkUDPFFMPEGCustom);
            tpUDP.Controls.Add(rbNetworkUDPFFMPEG);
            tpUDP.Location = new System.Drawing.Point(4, 34);
            tpUDP.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpUDP.Name = "tpUDP";
            tpUDP.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpUDP.Size = new System.Drawing.Size(479, 697);
            tpUDP.TabIndex = 5;
            tpUDP.Text = "UDP";
            tpUDP.UseVisualStyleBackColor = true;
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Location = new System.Drawing.Point(29, 472);
            label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label63.Name = "label63";
            label63.Size = new System.Drawing.Size(182, 25);
            label63.TabIndex = 17;
            label63.Text = "instead of IP address.";
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Location = new System.Drawing.Point(29, 448);
            label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label62.Name = "label62";
            label62.Size = new System.Drawing.Size(388, 25);
            label62.TabIndex = 16;
            label62.Text = "To open the stream in VLC on a local PC, use @ ";
            // 
            // cbNetworkUDPFFMPEGUsePipes
            // 
            cbNetworkUDPFFMPEGUsePipes.AutoSize = true;
            cbNetworkUDPFFMPEGUsePipes.Checked = true;
            cbNetworkUDPFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            cbNetworkUDPFFMPEGUsePipes.Location = new System.Drawing.Point(33, 147);
            cbNetworkUDPFFMPEGUsePipes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkUDPFFMPEGUsePipes.Name = "cbNetworkUDPFFMPEGUsePipes";
            cbNetworkUDPFFMPEGUsePipes.Size = new System.Drawing.Size(115, 29);
            cbNetworkUDPFFMPEGUsePipes.TabIndex = 15;
            cbNetworkUDPFFMPEGUsePipes.Text = "Use pipes";
            cbNetworkUDPFFMPEGUsePipes.UseVisualStyleBackColor = true;
            // 
            // label314
            // 
            label314.AutoSize = true;
            label314.Location = new System.Drawing.Point(29, 350);
            label314.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label314.Name = "label314";
            label314.Size = new System.Drawing.Size(365, 25);
            label314.TabIndex = 14;
            label314.Text = "For multicast UDP streaming, use an URL like";
            // 
            // label313
            // 
            label313.AutoSize = true;
            label313.Location = new System.Drawing.Point(29, 375);
            label313.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label313.Name = "label313";
            label313.Size = new System.Drawing.Size(378, 25);
            label313.TabIndex = 13;
            label313.Text = "udp://239.101.101.1:1234?ttl=1&pkt_size=1316";
            // 
            // label484
            // 
            label484.AutoSize = true;
            label484.Location = new System.Drawing.Point(50, 632);
            label484.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label484.Name = "label484";
            label484.Size = new System.Drawing.Size(374, 25);
            label484.TabIndex = 11;
            label484.Text = "Specify settings located on output format tab";
            // 
            // edNetworkUDPURL
            // 
            edNetworkUDPURL.Location = new System.Drawing.Point(33, 307);
            edNetworkUDPURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkUDPURL.Name = "edNetworkUDPURL";
            edNetworkUDPURL.Size = new System.Drawing.Size(408, 31);
            edNetworkUDPURL.TabIndex = 10;
            edNetworkUDPURL.Text = "udp://127.0.0.1:10000?pkt_size=1316";
            // 
            // label372
            // 
            label372.AutoSize = true;
            label372.Location = new System.Drawing.Point(29, 275);
            label372.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label372.Name = "label372";
            label372.Size = new System.Drawing.Size(43, 25);
            label372.TabIndex = 9;
            label372.Text = "URL";
            // 
            // rbNetworkUDPFFMPEGCustom
            // 
            rbNetworkUDPFFMPEGCustom.AutoSize = true;
            rbNetworkUDPFFMPEGCustom.Location = new System.Drawing.Point(33, 78);
            rbNetworkUDPFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkUDPFFMPEGCustom.Name = "rbNetworkUDPFFMPEGCustom";
            rbNetworkUDPFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkUDPFFMPEGCustom.TabIndex = 8;
            rbNetworkUDPFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkUDPFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkUDPFFMPEG
            // 
            rbNetworkUDPFFMPEG.AutoSize = true;
            rbNetworkUDPFFMPEG.Checked = true;
            rbNetworkUDPFFMPEG.Location = new System.Drawing.Point(33, 35);
            rbNetworkUDPFFMPEG.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkUDPFFMPEG.Name = "rbNetworkUDPFFMPEG";
            rbNetworkUDPFFMPEG.Size = new System.Drawing.Size(284, 29);
            rbNetworkUDPFFMPEG.TabIndex = 7;
            rbNetworkUDPFFMPEG.TabStop = true;
            rbNetworkUDPFFMPEG.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkUDPFFMPEG.UseVisualStyleBackColor = true;
            // 
            // tpSSF
            // 
            tpSSF.Controls.Add(cbNetworkSSUsePipes);
            tpSSF.Controls.Add(rbNetworkSSFFMPEGCustom);
            tpSSF.Controls.Add(rbNetworkSSFFMPEGDefault);
            tpSSF.Controls.Add(linkLabel5);
            tpSSF.Controls.Add(edNetworkSSURL);
            tpSSF.Controls.Add(label370);
            tpSSF.Controls.Add(label371);
            tpSSF.Controls.Add(rbNetworkSSSoftware);
            tpSSF.Location = new System.Drawing.Point(4, 34);
            tpSSF.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpSSF.Name = "tpSSF";
            tpSSF.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpSSF.Size = new System.Drawing.Size(479, 697);
            tpSSF.TabIndex = 4;
            tpSSF.Text = "IIS Smooth Streaming";
            tpSSF.UseVisualStyleBackColor = true;
            // 
            // cbNetworkSSUsePipes
            // 
            cbNetworkSSUsePipes.AutoSize = true;
            cbNetworkSSUsePipes.Checked = true;
            cbNetworkSSUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            cbNetworkSSUsePipes.Location = new System.Drawing.Point(60, 165);
            cbNetworkSSUsePipes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkSSUsePipes.Name = "cbNetworkSSUsePipes";
            cbNetworkSSUsePipes.Size = new System.Drawing.Size(297, 29);
            cbNetworkSSUsePipes.TabIndex = 19;
            cbNetworkSSUsePipes.Text = "Use pipes for FFMPEG streaming";
            cbNetworkSSUsePipes.UseVisualStyleBackColor = true;
            // 
            // rbNetworkSSFFMPEGCustom
            // 
            rbNetworkSSFFMPEGCustom.AutoSize = true;
            rbNetworkSSFFMPEGCustom.Location = new System.Drawing.Point(33, 122);
            rbNetworkSSFFMPEGCustom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkSSFFMPEGCustom.Name = "rbNetworkSSFFMPEGCustom";
            rbNetworkSSFFMPEGCustom.Size = new System.Drawing.Size(318, 29);
            rbNetworkSSFFMPEGCustom.TabIndex = 17;
            rbNetworkSSFFMPEGCustom.Text = "Custom settings using FFMPEG EXE";
            rbNetworkSSFFMPEGCustom.UseVisualStyleBackColor = true;
            // 
            // rbNetworkSSFFMPEGDefault
            // 
            rbNetworkSSFFMPEGDefault.AutoSize = true;
            rbNetworkSSFFMPEGDefault.Location = new System.Drawing.Point(33, 78);
            rbNetworkSSFFMPEGDefault.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkSSFFMPEGDefault.Name = "rbNetworkSSFFMPEGDefault";
            rbNetworkSSFFMPEGDefault.Size = new System.Drawing.Size(284, 29);
            rbNetworkSSFFMPEGDefault.TabIndex = 16;
            rbNetworkSSFFMPEGDefault.Text = "H264 / AAC using FFMPEG EXE";
            rbNetworkSSFFMPEGDefault.UseVisualStyleBackColor = true;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new System.Drawing.Point(29, 353);
            linkLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new System.Drawing.Size(301, 25);
            linkLabel5.TabIndex = 15;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "IIS Smooth Streaming usage manual";
            linkLabel5.LinkClicked += (this.linkLabel5_LinkClicked);
            // 
            // edNetworkSSURL
            // 
            edNetworkSSURL.Location = new System.Drawing.Point(33, 268);
            edNetworkSSURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNetworkSSURL.Name = "edNetworkSSURL";
            edNetworkSSURL.Size = new System.Drawing.Size(408, 31);
            edNetworkSSURL.TabIndex = 14;
            edNetworkSSURL.Text = "http://localhost/LiveSmoothStream.isml";
            // 
            // label370
            // 
            label370.AutoSize = true;
            label370.Location = new System.Drawing.Point(29, 237);
            label370.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label370.Name = "label370";
            label370.Size = new System.Drawing.Size(177, 25);
            label370.TabIndex = 13;
            label370.Text = "Publishing point URL";
            // 
            // label371
            // 
            label371.AutoSize = true;
            label371.Location = new System.Drawing.Point(29, 628);
            label371.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label371.Name = "label371";
            label371.Size = new System.Drawing.Size(374, 25);
            label371.TabIndex = 12;
            label371.Text = "Format settings located on output format tab";
            // 
            // rbNetworkSSSoftware
            // 
            rbNetworkSSSoftware.AutoSize = true;
            rbNetworkSSSoftware.Checked = true;
            rbNetworkSSSoftware.Location = new System.Drawing.Point(33, 32);
            rbNetworkSSSoftware.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNetworkSSSoftware.Name = "rbNetworkSSSoftware";
            rbNetworkSSSoftware.Size = new System.Drawing.Size(396, 29);
            rbNetworkSSSoftware.TabIndex = 10;
            rbNetworkSSSoftware.TabStop = true;
            rbNetworkSSSoftware.Text = "H264 / AAC using software encoder / NVENC";
            rbNetworkSSSoftware.UseVisualStyleBackColor = true;
            // 
            // tpHLS
            // 
            tpHLS.Controls.Add(label22);
            tpHLS.Controls.Add(edHLSURL);
            tpHLS.Controls.Add(label19);
            tpHLS.Controls.Add(edHLSEmbeddedHTTPServerPort);
            tpHLS.Controls.Add(cbHLSEmbeddedHTTPServerEnabled);
            tpHLS.Controls.Add(cbHLSMode);
            tpHLS.Controls.Add(label6);
            tpHLS.Controls.Add(lbHLSConfigure);
            tpHLS.Controls.Add(label532);
            tpHLS.Controls.Add(label531);
            tpHLS.Controls.Add(label530);
            tpHLS.Controls.Add(label529);
            tpHLS.Controls.Add(edHLSSegmentCount);
            tpHLS.Controls.Add(label519);
            tpHLS.Controls.Add(edHLSSegmentDuration);
            tpHLS.Controls.Add(btSelectHLSOutputFolder);
            tpHLS.Controls.Add(edHLSOutputFolder);
            tpHLS.Controls.Add(label380);
            tpHLS.Location = new System.Drawing.Point(4, 34);
            tpHLS.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpHLS.Name = "tpHLS";
            tpHLS.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpHLS.Size = new System.Drawing.Size(479, 697);
            tpHLS.TabIndex = 6;
            tpHLS.Text = "HLS";
            tpHLS.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new System.Drawing.Font("Segoe UI", 8F);
            label22.Location = new System.Drawing.Point(31, 530);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(424, 21);
            label22.TabIndex = 17;
            label22.Text = "(put the index.htm with your player inside the output folder)";
            // 
            // edHLSURL
            // 
            edHLSURL.Location = new System.Drawing.Point(31, 558);
            edHLSURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHLSURL.Name = "edHLSURL";
            edHLSURL.Size = new System.Drawing.Size(417, 31);
            edHLSURL.TabIndex = 16;
            edHLSURL.Text = "http://localhost:81/playlist.m3u8";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(27, 607);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(29, 25);
            label19.TabIndex = 15;
            label19.Text = "or";
            // 
            // edHLSEmbeddedHTTPServerPort
            // 
            edHLSEmbeddedHTTPServerPort.Location = new System.Drawing.Point(383, 496);
            edHLSEmbeddedHTTPServerPort.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHLSEmbeddedHTTPServerPort.Name = "edHLSEmbeddedHTTPServerPort";
            edHLSEmbeddedHTTPServerPort.Size = new System.Drawing.Size(65, 31);
            edHLSEmbeddedHTTPServerPort.TabIndex = 14;
            edHLSEmbeddedHTTPServerPort.Text = "81";
            // 
            // cbHLSEmbeddedHTTPServerEnabled
            // 
            cbHLSEmbeddedHTTPServerEnabled.AutoSize = true;
            cbHLSEmbeddedHTTPServerEnabled.Location = new System.Drawing.Point(31, 498);
            cbHLSEmbeddedHTTPServerEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbHLSEmbeddedHTTPServerEnabled.Name = "cbHLSEmbeddedHTTPServerEnabled";
            cbHLSEmbeddedHTTPServerEnabled.Size = new System.Drawing.Size(334, 29);
            cbHLSEmbeddedHTTPServerEnabled.TabIndex = 13;
            cbHLSEmbeddedHTTPServerEnabled.Text = "Use embedded HTTP server with port";
            cbHLSEmbeddedHTTPServerEnabled.UseVisualStyleBackColor = true;
            // 
            // cbHLSMode
            // 
            cbHLSMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHLSMode.FormattingEnabled = true;
            cbHLSMode.Items.AddRange(new object[] { "Live", "VOD", "Event" });
            cbHLSMode.Location = new System.Drawing.Point(31, 440);
            cbHLSMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbHLSMode.Name = "cbHLSMode";
            cbHLSMode.Size = new System.Drawing.Size(200, 33);
            cbHLSMode.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(27, 410);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(169, 25);
            label6.TabIndex = 11;
            label6.Text = "Mode (playlist type)";
            // 
            // lbHLSConfigure
            // 
            lbHLSConfigure.AutoSize = true;
            lbHLSConfigure.Location = new System.Drawing.Point(27, 632);
            lbHLSConfigure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbHLSConfigure.Name = "lbHLSConfigure";
            lbHLSConfigure.Size = new System.Drawing.Size(313, 25);
            lbHLSConfigure.TabIndex = 10;
            lbHLSConfigure.TabStop = true;
            lbHLSConfigure.Text = "How to configure HTTP server for HLS";
            lbHLSConfigure.LinkClicked += (this.lbHLSConfigure_LinkClicked);
            // 
            // label532
            // 
            label532.AutoSize = true;
            label532.Location = new System.Drawing.Point(27, 352);
            label532.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label532.Name = "label532";
            label532.Size = new System.Drawing.Size(70, 25);
            label532.TabIndex = 9;
            label532.Text = "in code";
            // 
            // label531
            // 
            label531.AutoSize = true;
            label531.Location = new System.Drawing.Point(27, 328);
            label531.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label531.Name = "label531";
            label531.Size = new System.Drawing.Size(410, 25);
            label531.TabIndex = 8;
            label531.Text = "You can set video (H264) and audio (AAC) settings";
            // 
            // label530
            // 
            label530.AutoSize = true;
            label530.Location = new System.Drawing.Point(111, 260);
            label530.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label530.Name = "label530";
            label530.Size = new System.Drawing.Size(222, 25);
            label530.TabIndex = 7;
            label530.Text = "Use 0 to save all segments";
            // 
            // label529
            // 
            label529.AutoSize = true;
            label529.Location = new System.Drawing.Point(27, 222);
            label529.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label529.Name = "label529";
            label529.Size = new System.Drawing.Size(416, 25);
            label529.TabIndex = 6;
            label529.Text = "Segment count that will be saved during streaming";
            // 
            // edHLSSegmentCount
            // 
            edHLSSegmentCount.Location = new System.Drawing.Point(31, 253);
            edHLSSegmentCount.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHLSSegmentCount.Name = "edHLSSegmentCount";
            edHLSSegmentCount.Size = new System.Drawing.Size(67, 31);
            edHLSSegmentCount.TabIndex = 5;
            edHLSSegmentCount.Text = "20";
            // 
            // label519
            // 
            label519.AutoSize = true;
            label519.Location = new System.Drawing.Point(27, 128);
            label519.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label519.Name = "label519";
            label519.Size = new System.Drawing.Size(195, 25);
            label519.TabIndex = 4;
            label519.Text = "Segment duration (sec)";
            // 
            // edHLSSegmentDuration
            // 
            edHLSSegmentDuration.Location = new System.Drawing.Point(31, 160);
            edHLSSegmentDuration.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHLSSegmentDuration.Name = "edHLSSegmentDuration";
            edHLSSegmentDuration.Size = new System.Drawing.Size(67, 31);
            edHLSSegmentDuration.TabIndex = 3;
            edHLSSegmentDuration.Text = "10";
            // 
            // btSelectHLSOutputFolder
            // 
            btSelectHLSOutputFolder.Location = new System.Drawing.Point(424, 62);
            btSelectHLSOutputFolder.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSelectHLSOutputFolder.Name = "btSelectHLSOutputFolder";
            btSelectHLSOutputFolder.Size = new System.Drawing.Size(39, 43);
            btSelectHLSOutputFolder.TabIndex = 2;
            btSelectHLSOutputFolder.Text = "...";
            btSelectHLSOutputFolder.UseVisualStyleBackColor = true;
            btSelectHLSOutputFolder.Click += (this.btSelectHLSOutputFolder_Click);
            // 
            // edHLSOutputFolder
            // 
            edHLSOutputFolder.Location = new System.Drawing.Point(31, 68);
            edHLSOutputFolder.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHLSOutputFolder.Name = "edHLSOutputFolder";
            edHLSOutputFolder.Size = new System.Drawing.Size(381, 31);
            edHLSOutputFolder.TabIndex = 1;
            edHLSOutputFolder.Text = "c:\\inetpub\\wwwroot\\hls\\";
            // 
            // label380
            // 
            label380.AutoSize = true;
            label380.Location = new System.Drawing.Point(27, 32);
            label380.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label380.Name = "label380";
            label380.Size = new System.Drawing.Size(329, 25);
            label380.TabIndex = 0;
            label380.Text = "Output folder for video files and playlist";
            // 
            // tpNSExternal
            // 
            tpNSExternal.Controls.Add(linkLabel4);
            tpNSExternal.Controls.Add(linkLabel2);
            tpNSExternal.Location = new System.Drawing.Point(4, 34);
            tpNSExternal.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpNSExternal.Name = "tpNSExternal";
            tpNSExternal.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tpNSExternal.Size = new System.Drawing.Size(479, 697);
            tpNSExternal.TabIndex = 1;
            tpNSExternal.Text = "External virtual devices";
            tpNSExternal.UseVisualStyleBackColor = true;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new System.Drawing.Point(29, 72);
            linkLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new System.Drawing.Size(379, 25);
            linkLabel4.TabIndex = 1;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Streaming using Microsoft Expression Encoder";
            linkLabel4.LinkClicked += (this.linkLabel4_LinkClicked);
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new System.Drawing.Point(29, 22);
            linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new System.Drawing.Size(326, 25);
            linkLabel2.TabIndex = 0;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Streaming to Adobe Flash Media Server";
            linkLabel2.LinkClicked += (this.linkLabel2_LinkClicked);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(cbNetworkIcecastFFMPEGUsePipes);
            tabPage3.Controls.Add(edIcecastURL);
            tabPage3.Controls.Add(label69);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage3.Size = new System.Drawing.Size(479, 697);
            tabPage3.TabIndex = 8;
            tabPage3.Text = "Icecast";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbNetworkIcecastFFMPEGUsePipes
            // 
            cbNetworkIcecastFFMPEGUsePipes.AutoSize = true;
            cbNetworkIcecastFFMPEGUsePipes.Checked = true;
            cbNetworkIcecastFFMPEGUsePipes.CheckState = System.Windows.Forms.CheckState.Checked;
            cbNetworkIcecastFFMPEGUsePipes.Location = new System.Drawing.Point(27, 110);
            cbNetworkIcecastFFMPEGUsePipes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkIcecastFFMPEGUsePipes.Name = "cbNetworkIcecastFFMPEGUsePipes";
            cbNetworkIcecastFFMPEGUsePipes.Size = new System.Drawing.Size(115, 29);
            cbNetworkIcecastFFMPEGUsePipes.TabIndex = 15;
            cbNetworkIcecastFFMPEGUsePipes.Text = "Use pipes";
            cbNetworkIcecastFFMPEGUsePipes.UseVisualStyleBackColor = true;
            // 
            // edIcecastURL
            // 
            edIcecastURL.Location = new System.Drawing.Point(27, 60);
            edIcecastURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edIcecastURL.Name = "edIcecastURL";
            edIcecastURL.Size = new System.Drawing.Size(417, 31);
            edIcecastURL.TabIndex = 12;
            edIcecastURL.Text = "icecast://source:SRC@127.0.0.1:8000/live";
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Location = new System.Drawing.Point(21, 28);
            label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(43, 25);
            label69.TabIndex = 11;
            label69.Text = "URL";
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(edMJPEGPort);
            tabPage6.Controls.Add(label72);
            tabPage6.Location = new System.Drawing.Point(4, 34);
            tabPage6.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            tabPage6.Size = new System.Drawing.Size(479, 697);
            tabPage6.TabIndex = 9;
            tabPage6.Text = "MJPEG";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // edMJPEGPort
            // 
            edMJPEGPort.Location = new System.Drawing.Point(89, 20);
            edMJPEGPort.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            edMJPEGPort.Name = "edMJPEGPort";
            edMJPEGPort.Size = new System.Drawing.Size(58, 31);
            edMJPEGPort.TabIndex = 1;
            edMJPEGPort.Text = "8090";
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Location = new System.Drawing.Point(19, 20);
            label72.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            label72.Name = "label72";
            label72.Size = new System.Drawing.Size(44, 25);
            label72.TabIndex = 0;
            label72.Text = "Port";
            // 
            // cbNetworkStreamingAudioEnabled
            // 
            cbNetworkStreamingAudioEnabled.AutoSize = true;
            cbNetworkStreamingAudioEnabled.Location = new System.Drawing.Point(17, 887);
            cbNetworkStreamingAudioEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkStreamingAudioEnabled.Name = "cbNetworkStreamingAudioEnabled";
            cbNetworkStreamingAudioEnabled.Size = new System.Drawing.Size(143, 29);
            cbNetworkStreamingAudioEnabled.TabIndex = 16;
            cbNetworkStreamingAudioEnabled.Text = "Stream audio";
            cbNetworkStreamingAudioEnabled.UseVisualStyleBackColor = true;
            // 
            // cbNetworkStreaming
            // 
            cbNetworkStreaming.AutoSize = true;
            cbNetworkStreaming.Location = new System.Drawing.Point(30, 32);
            cbNetworkStreaming.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbNetworkStreaming.Name = "cbNetworkStreaming";
            cbNetworkStreaming.Size = new System.Drawing.Size(257, 29);
            cbNetworkStreaming.TabIndex = 7;
            cbNetworkStreaming.Text = "Network streaming enabled";
            cbNetworkStreaming.UseVisualStyleBackColor = true;
            // 
            // tabPage28
            // 
            tabPage28.Controls.Add(btOSDRenderLayers);
            tabPage28.Controls.Add(lbOSDLayers);
            tabPage28.Controls.Add(cbOSDEnabled);
            tabPage28.Controls.Add(groupBox19);
            tabPage28.Controls.Add(btOSDClearLayers);
            tabPage28.Controls.Add(groupBox15);
            tabPage28.Controls.Add(label108);
            tabPage28.Location = new System.Drawing.Point(4, 34);
            tabPage28.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage28.Name = "tabPage28";
            tabPage28.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage28.Size = new System.Drawing.Size(516, 944);
            tabPage28.TabIndex = 10;
            tabPage28.Text = "OSD";
            tabPage28.UseVisualStyleBackColor = true;
            // 
            // btOSDRenderLayers
            // 
            btOSDRenderLayers.Location = new System.Drawing.Point(269, 382);
            btOSDRenderLayers.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDRenderLayers.Name = "btOSDRenderLayers";
            btOSDRenderLayers.Size = new System.Drawing.Size(196, 43);
            btOSDRenderLayers.TabIndex = 17;
            btOSDRenderLayers.Text = "Render layers";
            btOSDRenderLayers.UseVisualStyleBackColor = true;
            btOSDRenderLayers.Click += (this.btOSDRenderLayers_Click);
            // 
            // lbOSDLayers
            // 
            lbOSDLayers.CheckOnClick = true;
            lbOSDLayers.FormattingEnabled = true;
            lbOSDLayers.Location = new System.Drawing.Point(24, 118);
            lbOSDLayers.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbOSDLayers.Name = "lbOSDLayers";
            lbOSDLayers.Size = new System.Drawing.Size(228, 88);
            lbOSDLayers.TabIndex = 16;
            lbOSDLayers.ItemCheck += (this.lbOSDLayers_ItemCheck);
            // 
            // cbOSDEnabled
            // 
            cbOSDEnabled.AutoSize = true;
            cbOSDEnabled.Location = new System.Drawing.Point(27, 32);
            cbOSDEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbOSDEnabled.Name = "cbOSDEnabled";
            cbOSDEnabled.Size = new System.Drawing.Size(415, 29);
            cbOSDEnabled.TabIndex = 15;
            cbOSDEnabled.Text = "Enabled (should be set before playback started)";
            cbOSDEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(btOSDClearLayer);
            groupBox19.Controls.Add(tabControl6);
            groupBox19.Location = new System.Drawing.Point(24, 437);
            groupBox19.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox19.Name = "groupBox19";
            groupBox19.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox19.Size = new System.Drawing.Size(437, 482);
            groupBox19.TabIndex = 6;
            groupBox19.TabStop = false;
            groupBox19.Text = "Selected layer";
            // 
            // btOSDClearLayer
            // 
            btOSDClearLayer.Location = new System.Drawing.Point(10, 425);
            btOSDClearLayer.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDClearLayer.Name = "btOSDClearLayer";
            btOSDClearLayer.Size = new System.Drawing.Size(151, 43);
            btOSDClearLayer.TabIndex = 3;
            btOSDClearLayer.Text = "Clear layer";
            btOSDClearLayer.UseVisualStyleBackColor = true;
            btOSDClearLayer.Click += (this.btOSDClearLayer_Click);
            // 
            // tabControl6
            // 
            tabControl6.Controls.Add(tabPage30);
            tabControl6.Controls.Add(tabPage31);
            tabControl6.Controls.Add(tabPage32);
            tabControl6.Location = new System.Drawing.Point(10, 38);
            tabControl6.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl6.Name = "tabControl6";
            tabControl6.SelectedIndex = 0;
            tabControl6.Size = new System.Drawing.Size(417, 378);
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
            tabPage30.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage30.Name = "tabPage30";
            tabPage30.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage30.Size = new System.Drawing.Size(409, 340);
            tabPage30.TabIndex = 1;
            tabPage30.Text = "Image";
            tabPage30.UseVisualStyleBackColor = true;
            // 
            // btOSDImageDraw
            // 
            btOSDImageDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDImageDraw.Location = new System.Drawing.Point(297, 272);
            btOSDImageDraw.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDImageDraw.Name = "btOSDImageDraw";
            btOSDImageDraw.Size = new System.Drawing.Size(96, 43);
            btOSDImageDraw.TabIndex = 47;
            btOSDImageDraw.Text = "Draw";
            btOSDImageDraw.UseVisualStyleBackColor = true;
            btOSDImageDraw.Click += (this.btOSDImageDraw_Click);
            // 
            // pnOSDColorKey
            // 
            pnOSDColorKey.BackColor = System.Drawing.Color.Fuchsia;
            pnOSDColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnOSDColorKey.Location = new System.Drawing.Point(270, 188);
            pnOSDColorKey.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnOSDColorKey.Name = "pnOSDColorKey";
            pnOSDColorKey.Size = new System.Drawing.Size(39, 44);
            pnOSDColorKey.TabIndex = 45;
            pnOSDColorKey.Click += (this.pnOSDColorKey_Click);
            // 
            // cbOSDImageTranspColor
            // 
            cbOSDImageTranspColor.AutoSize = true;
            cbOSDImageTranspColor.Location = new System.Drawing.Point(24, 197);
            cbOSDImageTranspColor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbOSDImageTranspColor.Name = "cbOSDImageTranspColor";
            cbOSDImageTranspColor.Size = new System.Drawing.Size(218, 29);
            cbOSDImageTranspColor.TabIndex = 7;
            cbOSDImageTranspColor.Text = "Use transparency color";
            cbOSDImageTranspColor.UseVisualStyleBackColor = true;
            // 
            // edOSDImageTop
            // 
            edOSDImageTop.Location = new System.Drawing.Point(220, 128);
            edOSDImageTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDImageTop.Name = "edOSDImageTop";
            edOSDImageTop.Size = new System.Drawing.Size(61, 31);
            edOSDImageTop.TabIndex = 6;
            edOSDImageTop.Text = "0";
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Location = new System.Drawing.Point(169, 135);
            label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label115.Name = "label115";
            label115.Size = new System.Drawing.Size(41, 25);
            label115.TabIndex = 5;
            label115.Text = "Top";
            // 
            // edOSDImageLeft
            // 
            edOSDImageLeft.Location = new System.Drawing.Point(81, 128);
            edOSDImageLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDImageLeft.Name = "edOSDImageLeft";
            edOSDImageLeft.Size = new System.Drawing.Size(61, 31);
            edOSDImageLeft.TabIndex = 4;
            edOSDImageLeft.Text = "0";
            // 
            // label114
            // 
            label114.AutoSize = true;
            label114.Location = new System.Drawing.Point(20, 135);
            label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label114.Name = "label114";
            label114.Size = new System.Drawing.Size(41, 25);
            label114.TabIndex = 3;
            label114.Text = "Left";
            // 
            // btOSDSelectImage
            // 
            btOSDSelectImage.Location = new System.Drawing.Point(356, 58);
            btOSDSelectImage.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDSelectImage.Name = "btOSDSelectImage";
            btOSDSelectImage.Size = new System.Drawing.Size(37, 43);
            btOSDSelectImage.TabIndex = 2;
            btOSDSelectImage.Text = "...";
            btOSDSelectImage.UseVisualStyleBackColor = true;
            btOSDSelectImage.Click += (this.btOSDSelectImage_Click);
            // 
            // edOSDImageFilename
            // 
            edOSDImageFilename.Location = new System.Drawing.Point(24, 62);
            edOSDImageFilename.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDImageFilename.Name = "edOSDImageFilename";
            edOSDImageFilename.Size = new System.Drawing.Size(317, 31);
            edOSDImageFilename.TabIndex = 1;
            edOSDImageFilename.Text = "c:\\logo.png";
            // 
            // label113
            // 
            label113.AutoSize = true;
            label113.Location = new System.Drawing.Point(20, 32);
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
            tabPage31.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage31.Name = "tabPage31";
            tabPage31.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage31.Size = new System.Drawing.Size(409, 340);
            tabPage31.TabIndex = 2;
            tabPage31.Text = "Text";
            tabPage31.UseVisualStyleBackColor = true;
            // 
            // edOSDTextTop
            // 
            edOSDTextTop.Location = new System.Drawing.Point(220, 128);
            edOSDTextTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDTextTop.Name = "edOSDTextTop";
            edOSDTextTop.Size = new System.Drawing.Size(61, 31);
            edOSDTextTop.TabIndex = 55;
            edOSDTextTop.Text = "0";
            // 
            // label117
            // 
            label117.AutoSize = true;
            label117.Location = new System.Drawing.Point(169, 135);
            label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label117.Name = "label117";
            label117.Size = new System.Drawing.Size(41, 25);
            label117.TabIndex = 54;
            label117.Text = "Top";
            // 
            // edOSDTextLeft
            // 
            edOSDTextLeft.Location = new System.Drawing.Point(81, 128);
            edOSDTextLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDTextLeft.Name = "edOSDTextLeft";
            edOSDTextLeft.Size = new System.Drawing.Size(61, 31);
            edOSDTextLeft.TabIndex = 53;
            edOSDTextLeft.Text = "0";
            // 
            // label118
            // 
            label118.AutoSize = true;
            label118.Location = new System.Drawing.Point(20, 135);
            label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label118.Name = "label118";
            label118.Size = new System.Drawing.Size(41, 25);
            label118.TabIndex = 52;
            label118.Text = "Left";
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Location = new System.Drawing.Point(20, 32);
            label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label116.Name = "label116";
            label116.Size = new System.Drawing.Size(42, 25);
            label116.TabIndex = 51;
            label116.Text = "Text";
            // 
            // btOSDSelectFont
            // 
            btOSDSelectFont.Location = new System.Drawing.Point(330, 58);
            btOSDSelectFont.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDSelectFont.Name = "btOSDSelectFont";
            btOSDSelectFont.Size = new System.Drawing.Size(61, 43);
            btOSDSelectFont.TabIndex = 50;
            btOSDSelectFont.Text = "Font";
            btOSDSelectFont.UseVisualStyleBackColor = true;
            btOSDSelectFont.Click += (this.btOSDSelectFont_Click);
            // 
            // edOSDText
            // 
            edOSDText.ForeColor = System.Drawing.SystemColors.WindowText;
            edOSDText.Location = new System.Drawing.Point(24, 62);
            edOSDText.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDText.Name = "edOSDText";
            edOSDText.Size = new System.Drawing.Size(297, 31);
            edOSDText.TabIndex = 49;
            edOSDText.Text = "Hello!!!";
            // 
            // btOSDTextDraw
            // 
            btOSDTextDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDTextDraw.Location = new System.Drawing.Point(297, 272);
            btOSDTextDraw.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDTextDraw.Name = "btOSDTextDraw";
            btOSDTextDraw.Size = new System.Drawing.Size(96, 43);
            btOSDTextDraw.TabIndex = 48;
            btOSDTextDraw.Text = "Draw";
            btOSDTextDraw.UseVisualStyleBackColor = true;
            btOSDTextDraw.Click += (this.btOSDTextDraw_Click);
            // 
            // tabPage32
            // 
            tabPage32.Controls.Add(tbOSDTranspLevel);
            tabPage32.Controls.Add(btOSDSetTransp);
            tabPage32.Controls.Add(label119);
            tabPage32.Location = new System.Drawing.Point(4, 34);
            tabPage32.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage32.Name = "tabPage32";
            tabPage32.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage32.Size = new System.Drawing.Size(409, 340);
            tabPage32.TabIndex = 3;
            tabPage32.Text = "Other";
            tabPage32.UseVisualStyleBackColor = true;
            // 
            // tbOSDTranspLevel
            // 
            tbOSDTranspLevel.BackColor = System.Drawing.SystemColors.Window;
            tbOSDTranspLevel.Location = new System.Drawing.Point(24, 62);
            tbOSDTranspLevel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbOSDTranspLevel.Maximum = 255;
            tbOSDTranspLevel.Name = "tbOSDTranspLevel";
            tbOSDTranspLevel.Size = new System.Drawing.Size(239, 69);
            tbOSDTranspLevel.TabIndex = 3;
            tbOSDTranspLevel.TickFrequency = 10;
            // 
            // btOSDSetTransp
            // 
            btOSDSetTransp.Location = new System.Drawing.Point(297, 78);
            btOSDSetTransp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDSetTransp.Name = "btOSDSetTransp";
            btOSDSetTransp.Size = new System.Drawing.Size(80, 43);
            btOSDSetTransp.TabIndex = 2;
            btOSDSetTransp.Text = "Set";
            btOSDSetTransp.UseVisualStyleBackColor = true;
            btOSDSetTransp.Click += (this.btOSDSetTransp_Click);
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Location = new System.Drawing.Point(20, 32);
            label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label119.Name = "label119";
            label119.Size = new System.Drawing.Size(154, 25);
            label119.TabIndex = 0;
            label119.Text = "Transparency level";
            // 
            // btOSDClearLayers
            // 
            btOSDClearLayers.Location = new System.Drawing.Point(24, 382);
            btOSDClearLayers.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDClearLayers.Name = "btOSDClearLayers";
            btOSDClearLayers.Size = new System.Drawing.Size(233, 43);
            btOSDClearLayers.TabIndex = 5;
            btOSDClearLayers.Text = "Remove all layers";
            btOSDClearLayers.UseVisualStyleBackColor = true;
            btOSDClearLayers.Click += (this.btOSDClearLayers_Click);
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
            groupBox15.Location = new System.Drawing.Point(269, 102);
            groupBox15.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox15.Name = "groupBox15";
            groupBox15.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox15.Size = new System.Drawing.Size(196, 258);
            groupBox15.TabIndex = 4;
            groupBox15.TabStop = false;
            groupBox15.Text = "New layer";
            // 
            // btOSDLayerAdd
            // 
            btOSDLayerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btOSDLayerAdd.Location = new System.Drawing.Point(51, 207);
            btOSDLayerAdd.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btOSDLayerAdd.Name = "btOSDLayerAdd";
            btOSDLayerAdd.Size = new System.Drawing.Size(93, 43);
            btOSDLayerAdd.TabIndex = 8;
            btOSDLayerAdd.Text = "Create";
            btOSDLayerAdd.UseVisualStyleBackColor = true;
            btOSDLayerAdd.Click += (this.btOSDLayerAdd_Click);
            // 
            // edOSDLayerHeight
            // 
            edOSDLayerHeight.Location = new System.Drawing.Point(109, 157);
            edOSDLayerHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDLayerHeight.Name = "edOSDLayerHeight";
            edOSDLayerHeight.Size = new System.Drawing.Size(61, 31);
            edOSDLayerHeight.TabIndex = 7;
            edOSDLayerHeight.Text = "200";
            // 
            // label111
            // 
            label111.AutoSize = true;
            label111.Location = new System.Drawing.Point(103, 125);
            label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label111.Name = "label111";
            label111.Size = new System.Drawing.Size(65, 25);
            label111.TabIndex = 6;
            label111.Text = "Height";
            // 
            // edOSDLayerWidth
            // 
            edOSDLayerWidth.Location = new System.Drawing.Point(21, 157);
            edOSDLayerWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDLayerWidth.Name = "edOSDLayerWidth";
            edOSDLayerWidth.Size = new System.Drawing.Size(61, 31);
            edOSDLayerWidth.TabIndex = 5;
            edOSDLayerWidth.Text = "200";
            // 
            // label112
            // 
            label112.AutoSize = true;
            label112.Location = new System.Drawing.Point(17, 125);
            label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label112.Name = "label112";
            label112.Size = new System.Drawing.Size(60, 25);
            label112.TabIndex = 4;
            label112.Text = "Width";
            // 
            // edOSDLayerTop
            // 
            edOSDLayerTop.Location = new System.Drawing.Point(109, 82);
            edOSDLayerTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDLayerTop.Name = "edOSDLayerTop";
            edOSDLayerTop.Size = new System.Drawing.Size(61, 31);
            edOSDLayerTop.TabIndex = 3;
            edOSDLayerTop.Text = "0";
            // 
            // label110
            // 
            label110.AutoSize = true;
            label110.Location = new System.Drawing.Point(103, 50);
            label110.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label110.Name = "label110";
            label110.Size = new System.Drawing.Size(41, 25);
            label110.TabIndex = 2;
            label110.Text = "Top";
            // 
            // edOSDLayerLeft
            // 
            edOSDLayerLeft.Location = new System.Drawing.Point(21, 82);
            edOSDLayerLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edOSDLayerLeft.Name = "edOSDLayerLeft";
            edOSDLayerLeft.Size = new System.Drawing.Size(61, 31);
            edOSDLayerLeft.TabIndex = 1;
            edOSDLayerLeft.Text = "0";
            // 
            // label109
            // 
            label109.AutoSize = true;
            label109.Location = new System.Drawing.Point(17, 50);
            label109.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label109.Name = "label109";
            label109.Size = new System.Drawing.Size(41, 25);
            label109.TabIndex = 0;
            label109.Text = "Left";
            // 
            // label108
            // 
            label108.AutoSize = true;
            label108.Location = new System.Drawing.Point(20, 88);
            label108.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label108.Name = "label108";
            label108.Size = new System.Drawing.Size(61, 25);
            label108.TabIndex = 2;
            label108.Text = "Layers";
            // 
            // tabPage43
            // 
            tabPage43.Controls.Add(tabControl9);
            tabPage43.Controls.Add(cbMotDetEnabled);
            tabPage43.Location = new System.Drawing.Point(4, 34);
            tabPage43.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage43.Name = "tabPage43";
            tabPage43.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage43.Size = new System.Drawing.Size(516, 944);
            tabPage43.TabIndex = 11;
            tabPage43.Text = "Motion detection";
            tabPage43.UseVisualStyleBackColor = true;
            // 
            // tabControl9
            // 
            tabControl9.Controls.Add(tabPage44);
            tabControl9.Controls.Add(tabPage45);
            tabControl9.Location = new System.Drawing.Point(27, 88);
            tabControl9.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl9.Name = "tabControl9";
            tabControl9.SelectedIndex = 0;
            tabControl9.Size = new System.Drawing.Size(447, 793);
            tabControl9.TabIndex = 1;
            // 
            // tabPage44
            // 
            tabPage44.Controls.Add(pbMotionLevel);
            tabPage44.Controls.Add(label158);
            tabPage44.Controls.Add(mmMotDetMatrix);
            tabPage44.Location = new System.Drawing.Point(4, 34);
            tabPage44.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage44.Name = "tabPage44";
            tabPage44.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage44.Size = new System.Drawing.Size(439, 755);
            tabPage44.TabIndex = 0;
            tabPage44.Text = "Output matrix";
            tabPage44.UseVisualStyleBackColor = true;
            // 
            // pbMotionLevel
            // 
            pbMotionLevel.Location = new System.Drawing.Point(17, 647);
            pbMotionLevel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pbMotionLevel.Name = "pbMotionLevel";
            pbMotionLevel.Size = new System.Drawing.Size(373, 38);
            pbMotionLevel.TabIndex = 2;
            // 
            // label158
            // 
            label158.AutoSize = true;
            label158.Location = new System.Drawing.Point(11, 615);
            label158.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label158.Name = "label158";
            label158.Size = new System.Drawing.Size(110, 25);
            label158.TabIndex = 1;
            label158.Text = "Motion level";
            // 
            // mmMotDetMatrix
            // 
            mmMotDetMatrix.Location = new System.Drawing.Point(10, 12);
            mmMotDetMatrix.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            mmMotDetMatrix.Multiline = true;
            mmMotDetMatrix.Name = "mmMotDetMatrix";
            mmMotDetMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmMotDetMatrix.Size = new System.Drawing.Size(411, 482);
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
            tabPage45.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage45.Name = "tabPage45";
            tabPage45.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage45.Size = new System.Drawing.Size(439, 755);
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
            groupBox25.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox25.Name = "groupBox25";
            groupBox25.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbMotDetHLColor.Location = new System.Drawing.Point(256, 112);
            cbMotDetHLColor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMotDetHLColor.Name = "cbMotDetHLColor";
            cbMotDetHLColor.Size = new System.Drawing.Size(114, 33);
            cbMotDetHLColor.TabIndex = 5;
            // 
            // label161
            // 
            label161.AutoSize = true;
            label161.Location = new System.Drawing.Point(247, 82);
            label161.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label161.Name = "label161";
            label161.Size = new System.Drawing.Size(55, 25);
            label161.TabIndex = 4;
            label161.Text = "Color";
            // 
            // label160
            // 
            label160.AutoSize = true;
            label160.Location = new System.Drawing.Point(50, 82);
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
            cbMotDetHLEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMotDetHLEnabled.Name = "cbMotDetHLEnabled";
            cbMotDetHLEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetHLEnabled.TabIndex = 1;
            cbMotDetHLEnabled.Text = "Enabled";
            cbMotDetHLEnabled.UseVisualStyleBackColor = true;
            // 
            // tbMotDetHLThreshold
            // 
            tbMotDetHLThreshold.BackColor = System.Drawing.SystemColors.Window;
            tbMotDetHLThreshold.Location = new System.Drawing.Point(51, 112);
            tbMotDetHLThreshold.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbMotDetHLThreshold.Maximum = 255;
            tbMotDetHLThreshold.Name = "tbMotDetHLThreshold";
            tbMotDetHLThreshold.Size = new System.Drawing.Size(173, 69);
            tbMotDetHLThreshold.TabIndex = 3;
            tbMotDetHLThreshold.TickFrequency = 5;
            tbMotDetHLThreshold.Value = 25;
            // 
            // btMotDetUpdateSettings
            // 
            btMotDetUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btMotDetUpdateSettings.Location = new System.Drawing.Point(230, 688);
            btMotDetUpdateSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btMotDetUpdateSettings.Name = "btMotDetUpdateSettings";
            btMotDetUpdateSettings.Size = new System.Drawing.Size(179, 43);
            btMotDetUpdateSettings.TabIndex = 4;
            btMotDetUpdateSettings.Text = "Update settings";
            btMotDetUpdateSettings.UseVisualStyleBackColor = true;
            btMotDetUpdateSettings.Click += (this.btMotDetUpdateSettings_Click);
            // 
            // groupBox27
            // 
            groupBox27.Controls.Add(edMotDetMatrixHeight);
            groupBox27.Controls.Add(label163);
            groupBox27.Controls.Add(edMotDetMatrixWidth);
            groupBox27.Controls.Add(label164);
            groupBox27.Location = new System.Drawing.Point(20, 512);
            groupBox27.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox27.Name = "groupBox27";
            groupBox27.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox27.Size = new System.Drawing.Size(389, 112);
            groupBox27.TabIndex = 3;
            groupBox27.TabStop = false;
            groupBox27.Text = "Matrix";
            // 
            // edMotDetMatrixHeight
            // 
            edMotDetMatrixHeight.Location = new System.Drawing.Point(241, 43);
            edMotDetMatrixHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            edMotDetMatrixWidth.Location = new System.Drawing.Point(93, 43);
            edMotDetMatrixWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            groupBox26.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox26.Name = "groupBox26";
            groupBox26.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            tbMotDetDropFramesThreshold.Location = new System.Drawing.Point(159, 72);
            tbMotDetDropFramesThreshold.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbMotDetDropFramesEnabled.Location = new System.Drawing.Point(23, 38);
            cbMotDetDropFramesEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            groupBox24.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox24.Name = "groupBox24";
            groupBox24.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox24.Size = new System.Drawing.Size(389, 158);
            groupBox24.TabIndex = 0;
            groupBox24.TabStop = false;
            groupBox24.Text = "Compare settings";
            // 
            // edMotDetFrameInterval
            // 
            edMotDetFrameInterval.Location = new System.Drawing.Point(159, 98);
            edMotDetFrameInterval.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edMotDetFrameInterval.Name = "edMotDetFrameInterval";
            edMotDetFrameInterval.Size = new System.Drawing.Size(51, 31);
            edMotDetFrameInterval.TabIndex = 5;
            edMotDetFrameInterval.Text = "2";
            // 
            // label159
            // 
            label159.AutoSize = true;
            label159.Location = new System.Drawing.Point(19, 103);
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
            cbCompareGreyscale.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbCompareBlue.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbCompareGreen.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbCompareRed.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCompareRed.Name = "cbCompareRed";
            cbCompareRed.Size = new System.Drawing.Size(68, 29);
            cbCompareRed.TabIndex = 0;
            cbCompareRed.Text = "Red";
            cbCompareRed.UseVisualStyleBackColor = true;
            // 
            // cbMotDetEnabled
            // 
            cbMotDetEnabled.AutoSize = true;
            cbMotDetEnabled.Location = new System.Drawing.Point(27, 35);
            cbMotDetEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMotDetEnabled.Name = "cbMotDetEnabled";
            cbMotDetEnabled.Size = new System.Drawing.Size(101, 29);
            cbMotDetEnabled.TabIndex = 0;
            cbMotDetEnabled.Text = "Enabled";
            cbMotDetEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage26
            // 
            tabPage26.Controls.Add(label505);
            tabPage26.Controls.Add(rbMotionDetectionExProcessor);
            tabPage26.Controls.Add(label389);
            tabPage26.Controls.Add(rbMotionDetectionExDetector);
            tabPage26.Controls.Add(label64);
            tabPage26.Controls.Add(label65);
            tabPage26.Controls.Add(pbAFMotionLevel);
            tabPage26.Controls.Add(cbMotionDetectionEx);
            tabPage26.Location = new System.Drawing.Point(4, 34);
            tabPage26.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage26.Name = "tabPage26";
            tabPage26.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage26.Size = new System.Drawing.Size(516, 944);
            tabPage26.TabIndex = 20;
            tabPage26.Text = "Motion detection (Extended)";
            tabPage26.UseVisualStyleBackColor = true;
            // 
            // label505
            // 
            label505.AutoSize = true;
            label505.Location = new System.Drawing.Point(31, 203);
            label505.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label505.Name = "label505";
            label505.Size = new System.Drawing.Size(89, 25);
            label505.TabIndex = 23;
            label505.Text = "Processor";
            // 
            // rbMotionDetectionExProcessor
            // 
            rbMotionDetectionExProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rbMotionDetectionExProcessor.FormattingEnabled = true;
            rbMotionDetectionExProcessor.Items.AddRange(new object[] { "None", "Blob counting objects", "GridMotionAreaProcessing", "Motion area highlighting", "Motion border highlighting" });
            rbMotionDetectionExProcessor.Location = new System.Drawing.Point(31, 235);
            rbMotionDetectionExProcessor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbMotionDetectionExProcessor.Name = "rbMotionDetectionExProcessor";
            rbMotionDetectionExProcessor.Size = new System.Drawing.Size(427, 33);
            rbMotionDetectionExProcessor.TabIndex = 22;
            // 
            // label389
            // 
            label389.AutoSize = true;
            label389.Location = new System.Drawing.Point(31, 108);
            label389.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label389.Name = "label389";
            label389.Size = new System.Drawing.Size(80, 25);
            label389.TabIndex = 21;
            label389.Text = "Detector";
            // 
            // rbMotionDetectionExDetector
            // 
            rbMotionDetectionExDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rbMotionDetectionExDetector.FormattingEnabled = true;
            rbMotionDetectionExDetector.Items.AddRange(new object[] { "Custom frame difference", "Simple background modeling", "Two frames difference" });
            rbMotionDetectionExDetector.Location = new System.Drawing.Point(31, 138);
            rbMotionDetectionExDetector.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbMotionDetectionExDetector.Name = "rbMotionDetectionExDetector";
            rbMotionDetectionExDetector.Size = new System.Drawing.Size(427, 33);
            rbMotionDetectionExDetector.TabIndex = 20;
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new System.Drawing.Point(93, 853);
            label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(293, 25);
            label64.TabIndex = 19;
            label64.Text = "Much more options available in API";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new System.Drawing.Point(31, 315);
            label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(110, 25);
            label65.TabIndex = 18;
            label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            pbAFMotionLevel.Location = new System.Drawing.Point(31, 347);
            pbAFMotionLevel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pbAFMotionLevel.Name = "pbAFMotionLevel";
            pbAFMotionLevel.Size = new System.Drawing.Size(430, 43);
            pbAFMotionLevel.TabIndex = 17;
            // 
            // cbMotionDetectionEx
            // 
            cbMotionDetectionEx.AutoSize = true;
            cbMotionDetectionEx.Location = new System.Drawing.Point(31, 35);
            cbMotionDetectionEx.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMotionDetectionEx.Name = "cbMotionDetectionEx";
            cbMotionDetectionEx.Size = new System.Drawing.Size(101, 29);
            cbMotionDetectionEx.TabIndex = 15;
            cbMotionDetectionEx.Text = "Enabled";
            cbMotionDetectionEx.UseVisualStyleBackColor = true;
            cbMotionDetectionEx.CheckedChanged += (this.cbAFMotionDetection_CheckedChanged);
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
            tabPage25.Name = "tabPage25";
            tabPage25.Padding = new System.Windows.Forms.Padding(3);
            tabPage25.Size = new System.Drawing.Size(516, 944);
            tabPage25.TabIndex = 13;
            tabPage25.Text = "Barcode reader";
            tabPage25.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            edBarcodeMetadata.Location = new System.Drawing.Point(27, 308);
            edBarcodeMetadata.Multiline = true;
            edBarcodeMetadata.Name = "edBarcodeMetadata";
            edBarcodeMetadata.Size = new System.Drawing.Size(467, 182);
            edBarcodeMetadata.TabIndex = 8;
            // 
            // label91
            // 
            label91.AutoSize = true;
            label91.Location = new System.Drawing.Point(23, 272);
            label91.Name = "label91";
            label91.Size = new System.Drawing.Size(87, 25);
            label91.TabIndex = 7;
            label91.Text = "Metadata";
            // 
            // cbBarcodeType
            // 
            cbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBarcodeType.FormattingEnabled = true;
            cbBarcodeType.Items.AddRange(new object[] { "Autodetect", "UPC-A", "UPC-E", "EAN-8", "EAN-13", "Code 39", "Code 93", "Code 128", "ITF", "CodaBar", "RSS-14", "Data matrix", "Aztec", "QR", "PDF-417" });
            cbBarcodeType.Location = new System.Drawing.Point(27, 122);
            cbBarcodeType.Name = "cbBarcodeType";
            cbBarcodeType.Size = new System.Drawing.Size(264, 33);
            cbBarcodeType.TabIndex = 6;
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Location = new System.Drawing.Point(23, 92);
            label90.Name = "label90";
            label90.Size = new System.Drawing.Size(116, 25);
            label90.TabIndex = 5;
            label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            btBarcodeReset.Location = new System.Drawing.Point(27, 515);
            btBarcodeReset.Name = "btBarcodeReset";
            btBarcodeReset.Size = new System.Drawing.Size(103, 43);
            btBarcodeReset.TabIndex = 4;
            btBarcodeReset.Text = "Restart";
            btBarcodeReset.UseVisualStyleBackColor = true;
            btBarcodeReset.Click += (this.btBarcodeReset_Click);
            // 
            // edBarcode
            // 
            edBarcode.Location = new System.Drawing.Point(27, 215);
            edBarcode.Name = "edBarcode";
            edBarcode.Size = new System.Drawing.Size(467, 31);
            edBarcode.TabIndex = 3;
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Location = new System.Drawing.Point(23, 185);
            label89.Name = "label89";
            label89.Size = new System.Drawing.Size(153, 25);
            label89.TabIndex = 2;
            label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            cbBarcodeDetectionEnabled.AutoSize = true;
            cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(27, 35);
            cbBarcodeDetectionEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(101, 29);
            cbBarcodeDetectionEnabled.TabIndex = 1;
            cbBarcodeDetectionEnabled.Text = "Enabled";
            cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage101
            // 
            tabPage101.Controls.Add(btVirtualCameraRegister);
            tabPage101.Controls.Add(label328);
            tabPage101.Controls.Add(label327);
            tabPage101.Controls.Add(label326);
            tabPage101.Controls.Add(label325);
            tabPage101.Controls.Add(cbVirtualCamera);
            tabPage101.Location = new System.Drawing.Point(4, 34);
            tabPage101.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage101.Name = "tabPage101";
            tabPage101.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage101.Size = new System.Drawing.Size(516, 944);
            tabPage101.TabIndex = 14;
            tabPage101.Text = "Virtual camera";
            tabPage101.UseVisualStyleBackColor = true;
            // 
            // btVirtualCameraRegister
            // 
            btVirtualCameraRegister.Location = new System.Drawing.Point(33, 300);
            btVirtualCameraRegister.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btVirtualCameraRegister.Name = "btVirtualCameraRegister";
            btVirtualCameraRegister.Size = new System.Drawing.Size(436, 43);
            btVirtualCameraRegister.TabIndex = 5;
            btVirtualCameraRegister.Text = "Click to register filters for NuGet SDK version";
            btVirtualCameraRegister.UseVisualStyleBackColor = true;
            btVirtualCameraRegister.Click += (this.btVirtualCameraRegister_Click);
            // 
            // label328
            // 
            label328.AutoSize = true;
            label328.Location = new System.Drawing.Point(29, 240);
            label328.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label328.Name = "label328";
            label328.Size = new System.Drawing.Size(337, 25);
            label328.TabIndex = 4;
            label328.Text = "TRIAL limitation - 5000 frames to stream.";
            // 
            // label327
            // 
            label327.AutoSize = true;
            label327.Location = new System.Drawing.Point(29, 198);
            label327.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label327.Name = "label327";
            label327.Size = new System.Drawing.Size(297, 25);
            label327.TabIndex = 3;
            label327.Text = "Virtual Camera SDK license required.";
            // 
            // label326
            // 
            label326.AutoSize = true;
            label326.Location = new System.Drawing.Point(29, 138);
            label326.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label326.Name = "label326";
            label326.Size = new System.Drawing.Size(188, 25);
            label326.TabIndex = 2;
            label326.Text = "to see streamed video";
            // 
            // label325
            // 
            label325.AutoSize = true;
            label325.Location = new System.Drawing.Point(29, 100);
            label325.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label325.Name = "label325";
            label325.Size = new System.Drawing.Size(398, 25);
            label325.TabIndex = 1;
            label325.Text = "You are can use VisioForge Virtual Camera device";
            // 
            // cbVirtualCamera
            // 
            cbVirtualCamera.AutoSize = true;
            cbVirtualCamera.Location = new System.Drawing.Point(33, 35);
            cbVirtualCamera.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVirtualCamera.Name = "cbVirtualCamera";
            cbVirtualCamera.Size = new System.Drawing.Size(174, 29);
            cbVirtualCamera.TabIndex = 0;
            cbVirtualCamera.Text = "Enable streaming";
            cbVirtualCamera.UseVisualStyleBackColor = true;
            // 
            // tabPage103
            // 
            tabPage103.Controls.Add(label71);
            tabPage103.Controls.Add(label70);
            tabPage103.Controls.Add(cbDecklinkOutputAudioRenderer);
            tabPage103.Controls.Add(cbDecklinkOutputVideoRenderer);
            tabPage103.Controls.Add(cbDecklinkOutputDownConversionAnalogOutput);
            tabPage103.Controls.Add(cbDecklinkOutputDownConversion);
            tabPage103.Controls.Add(label337);
            tabPage103.Controls.Add(cbDecklinkOutputHDTVPulldown);
            tabPage103.Controls.Add(label336);
            tabPage103.Controls.Add(cbDecklinkOutputBlackToDeck);
            tabPage103.Controls.Add(label335);
            tabPage103.Controls.Add(cbDecklinkOutputSingleField);
            tabPage103.Controls.Add(label334);
            tabPage103.Controls.Add(cbDecklinkOutputComponentLevels);
            tabPage103.Controls.Add(label333);
            tabPage103.Controls.Add(cbDecklinkOutputNTSC);
            tabPage103.Controls.Add(label332);
            tabPage103.Controls.Add(cbDecklinkOutputDualLink);
            tabPage103.Controls.Add(label331);
            tabPage103.Controls.Add(cbDecklinkOutputAnalog);
            tabPage103.Controls.Add(label87);
            tabPage103.Controls.Add(cbDecklinkDV);
            tabPage103.Controls.Add(cbDecklinkOutput);
            tabPage103.Location = new System.Drawing.Point(4, 34);
            tabPage103.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage103.Name = "tabPage103";
            tabPage103.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage103.Size = new System.Drawing.Size(516, 944);
            tabPage103.TabIndex = 15;
            tabPage103.Text = "Decklink output";
            tabPage103.UseVisualStyleBackColor = true;
            // 
            // label71
            // 
            label71.AutoSize = true;
            label71.Location = new System.Drawing.Point(11, 193);
            label71.Name = "label71";
            label71.Size = new System.Drawing.Size(131, 25);
            label71.TabIndex = 22;
            label71.Text = "Audio renderer";
            // 
            // label70
            // 
            label70.AutoSize = true;
            label70.Location = new System.Drawing.Point(11, 103);
            label70.Name = "label70";
            label70.Size = new System.Drawing.Size(129, 25);
            label70.TabIndex = 21;
            label70.Text = "Video renderer";
            // 
            // cbDecklinkOutputAudioRenderer
            // 
            cbDecklinkOutputAudioRenderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputAudioRenderer.FormattingEnabled = true;
            cbDecklinkOutputAudioRenderer.Location = new System.Drawing.Point(16, 222);
            cbDecklinkOutputAudioRenderer.Name = "cbDecklinkOutputAudioRenderer";
            cbDecklinkOutputAudioRenderer.Size = new System.Drawing.Size(428, 33);
            cbDecklinkOutputAudioRenderer.TabIndex = 20;
            // 
            // cbDecklinkOutputVideoRenderer
            // 
            cbDecklinkOutputVideoRenderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputVideoRenderer.FormattingEnabled = true;
            cbDecklinkOutputVideoRenderer.Location = new System.Drawing.Point(16, 132);
            cbDecklinkOutputVideoRenderer.Name = "cbDecklinkOutputVideoRenderer";
            cbDecklinkOutputVideoRenderer.Size = new System.Drawing.Size(428, 33);
            cbDecklinkOutputVideoRenderer.TabIndex = 19;
            // 
            // cbDecklinkOutputDownConversionAnalogOutput
            // 
            cbDecklinkOutputDownConversionAnalogOutput.AutoSize = true;
            cbDecklinkOutputDownConversionAnalogOutput.Location = new System.Drawing.Point(17, 677);
            cbDecklinkOutputDownConversionAnalogOutput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputDownConversionAnalogOutput.Name = "cbDecklinkOutputDownConversionAnalogOutput";
            cbDecklinkOutputDownConversionAnalogOutput.Size = new System.Drawing.Size(197, 29);
            cbDecklinkOutputDownConversionAnalogOutput.TabIndex = 18;
            cbDecklinkOutputDownConversionAnalogOutput.Text = "Analog output used";
            cbDecklinkOutputDownConversionAnalogOutput.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutputDownConversion
            // 
            cbDecklinkOutputDownConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputDownConversion.FormattingEnabled = true;
            cbDecklinkOutputDownConversion.Items.AddRange(new object[] { "Default", "Disabled", "Letterbox 16:9", "Anamorphic", "Anamorphic center" });
            cbDecklinkOutputDownConversion.Location = new System.Drawing.Point(17, 630);
            cbDecklinkOutputDownConversion.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputDownConversion.Name = "cbDecklinkOutputDownConversion";
            cbDecklinkOutputDownConversion.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputDownConversion.TabIndex = 17;
            // 
            // label337
            // 
            label337.AutoSize = true;
            label337.Location = new System.Drawing.Point(11, 598);
            label337.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label337.Name = "label337";
            label337.Size = new System.Drawing.Size(202, 25);
            label337.TabIndex = 16;
            label337.Text = "Down conversion mode";
            // 
            // cbDecklinkOutputHDTVPulldown
            // 
            cbDecklinkOutputHDTVPulldown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputHDTVPulldown.FormattingEnabled = true;
            cbDecklinkOutputHDTVPulldown.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputHDTVPulldown.Location = new System.Drawing.Point(17, 767);
            cbDecklinkOutputHDTVPulldown.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputHDTVPulldown.Name = "cbDecklinkOutputHDTVPulldown";
            cbDecklinkOutputHDTVPulldown.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputHDTVPulldown.TabIndex = 15;
            // 
            // label336
            // 
            label336.AutoSize = true;
            label336.Location = new System.Drawing.Point(11, 738);
            label336.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label336.Name = "label336";
            label336.Size = new System.Drawing.Size(136, 25);
            label336.TabIndex = 14;
            label336.Text = "HDTV pulldown";
            // 
            // cbDecklinkOutputBlackToDeck
            // 
            cbDecklinkOutputBlackToDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputBlackToDeck.FormattingEnabled = true;
            cbDecklinkOutputBlackToDeck.Items.AddRange(new object[] { "Default", "None", "Digital", "Analogue" });
            cbDecklinkOutputBlackToDeck.Location = new System.Drawing.Point(17, 538);
            cbDecklinkOutputBlackToDeck.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputBlackToDeck.Name = "cbDecklinkOutputBlackToDeck";
            cbDecklinkOutputBlackToDeck.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputBlackToDeck.TabIndex = 13;
            // 
            // label335
            // 
            label335.AutoSize = true;
            label335.Location = new System.Drawing.Point(11, 508);
            label335.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label335.Name = "label335";
            label335.Size = new System.Drawing.Size(116, 25);
            label335.TabIndex = 12;
            label335.Text = "Black to deck";
            // 
            // cbDecklinkOutputSingleField
            // 
            cbDecklinkOutputSingleField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputSingleField.FormattingEnabled = true;
            cbDecklinkOutputSingleField.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputSingleField.Location = new System.Drawing.Point(17, 452);
            cbDecklinkOutputSingleField.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputSingleField.Name = "cbDecklinkOutputSingleField";
            cbDecklinkOutputSingleField.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputSingleField.TabIndex = 11;
            // 
            // label334
            // 
            label334.AutoSize = true;
            label334.Location = new System.Drawing.Point(11, 422);
            label334.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label334.Name = "label334";
            label334.Size = new System.Drawing.Size(158, 25);
            label334.TabIndex = 10;
            label334.Text = "Single field output";
            // 
            // cbDecklinkOutputComponentLevels
            // 
            cbDecklinkOutputComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputComponentLevels.FormattingEnabled = true;
            cbDecklinkOutputComponentLevels.Items.AddRange(new object[] { "SMPTE", "Betacam" });
            cbDecklinkOutputComponentLevels.Location = new System.Drawing.Point(243, 538);
            cbDecklinkOutputComponentLevels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputComponentLevels.Name = "cbDecklinkOutputComponentLevels";
            cbDecklinkOutputComponentLevels.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputComponentLevels.TabIndex = 9;
            // 
            // label333
            // 
            label333.AutoSize = true;
            label333.Location = new System.Drawing.Point(239, 508);
            label333.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label333.Name = "label333";
            label333.Size = new System.Drawing.Size(155, 25);
            label333.TabIndex = 8;
            label333.Text = "Component levels";
            // 
            // cbDecklinkOutputNTSC
            // 
            cbDecklinkOutputNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputNTSC.FormattingEnabled = true;
            cbDecklinkOutputNTSC.Items.AddRange(new object[] { "USA", "Japan" });
            cbDecklinkOutputNTSC.Location = new System.Drawing.Point(243, 452);
            cbDecklinkOutputNTSC.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputNTSC.Name = "cbDecklinkOutputNTSC";
            cbDecklinkOutputNTSC.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputNTSC.TabIndex = 7;
            // 
            // label332
            // 
            label332.AutoSize = true;
            label332.Location = new System.Drawing.Point(239, 422);
            label332.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label332.Name = "label332";
            label332.Size = new System.Drawing.Size(130, 25);
            label332.TabIndex = 6;
            label332.Text = "NTSC standard";
            // 
            // cbDecklinkOutputDualLink
            // 
            cbDecklinkOutputDualLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputDualLink.FormattingEnabled = true;
            cbDecklinkOutputDualLink.Items.AddRange(new object[] { "Default", "Enabled", "Disabled" });
            cbDecklinkOutputDualLink.Location = new System.Drawing.Point(17, 367);
            cbDecklinkOutputDualLink.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputDualLink.Name = "cbDecklinkOutputDualLink";
            cbDecklinkOutputDualLink.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputDualLink.TabIndex = 5;
            // 
            // label331
            // 
            label331.AutoSize = true;
            label331.Location = new System.Drawing.Point(11, 338);
            label331.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label331.Name = "label331";
            label331.Size = new System.Drawing.Size(132, 25);
            label331.TabIndex = 4;
            label331.Text = "Dual link mode";
            // 
            // cbDecklinkOutputAnalog
            // 
            cbDecklinkOutputAnalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkOutputAnalog.FormattingEnabled = true;
            cbDecklinkOutputAnalog.Items.AddRange(new object[] { "Auto", "Component", "Composite", "S-Video" });
            cbDecklinkOutputAnalog.Location = new System.Drawing.Point(243, 367);
            cbDecklinkOutputAnalog.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutputAnalog.Name = "cbDecklinkOutputAnalog";
            cbDecklinkOutputAnalog.Size = new System.Drawing.Size(200, 33);
            cbDecklinkOutputAnalog.TabIndex = 3;
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Location = new System.Drawing.Point(239, 338);
            label87.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label87.Name = "label87";
            label87.Size = new System.Drawing.Size(128, 25);
            label87.TabIndex = 2;
            label87.Text = "Analog output";
            // 
            // cbDecklinkDV
            // 
            cbDecklinkDV.AutoSize = true;
            cbDecklinkDV.Location = new System.Drawing.Point(16, 283);
            cbDecklinkDV.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkDV.Name = "cbDecklinkDV";
            cbDecklinkDV.Size = new System.Drawing.Size(121, 29);
            cbDecklinkDV.TabIndex = 1;
            cbDecklinkDV.Text = "DV output";
            cbDecklinkDV.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkOutput
            // 
            cbDecklinkOutput.AutoSize = true;
            cbDecklinkOutput.Location = new System.Drawing.Point(16, 32);
            cbDecklinkOutput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkOutput.Name = "cbDecklinkOutput";
            cbDecklinkOutput.Size = new System.Drawing.Size(281, 29);
            cbDecklinkOutput.TabIndex = 0;
            cbDecklinkOutput.Text = "Enable output to Decklink card";
            cbDecklinkOutput.UseVisualStyleBackColor = true;
            // 
            // tabPage141
            // 
            tabPage141.Controls.Add(TabControl32);
            tabPage141.Controls.Add(cbTagEnabled);
            tabPage141.Location = new System.Drawing.Point(4, 34);
            tabPage141.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage141.Name = "tabPage141";
            tabPage141.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage141.Size = new System.Drawing.Size(516, 944);
            tabPage141.TabIndex = 19;
            tabPage141.Text = "Tags";
            tabPage141.UseVisualStyleBackColor = true;
            // 
            // TabControl32
            // 
            TabControl32.Controls.Add(TabPage142);
            TabControl32.Controls.Add(TabPage143);
            TabControl32.Location = new System.Drawing.Point(11, 78);
            TabControl32.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            TabControl32.Name = "TabControl32";
            TabControl32.SelectedIndex = 0;
            TabControl32.Size = new System.Drawing.Size(487, 832);
            TabControl32.TabIndex = 3;
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
            TabPage142.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            TabPage142.Name = "TabPage142";
            TabPage142.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            TabPage142.Size = new System.Drawing.Size(479, 794);
            TabPage142.TabIndex = 0;
            TabPage142.Text = "Common";
            TabPage142.UseVisualStyleBackColor = true;
            // 
            // edTagTrackID
            // 
            edTagTrackID.Location = new System.Drawing.Point(27, 398);
            edTagTrackID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagTrackID.Name = "edTagTrackID";
            edTagTrackID.Size = new System.Drawing.Size(103, 31);
            edTagTrackID.TabIndex = 13;
            edTagTrackID.Text = "1";
            // 
            // Label496
            // 
            Label496.AutoSize = true;
            Label496.Location = new System.Drawing.Point(21, 368);
            Label496.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label496.Name = "Label496";
            Label496.Size = new System.Drawing.Size(74, 25);
            Label496.TabIndex = 12;
            Label496.Text = "Track ID";
            // 
            // edTagYear
            // 
            edTagYear.Location = new System.Drawing.Point(27, 578);
            edTagYear.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagYear.Name = "edTagYear";
            edTagYear.Size = new System.Drawing.Size(103, 31);
            edTagYear.TabIndex = 11;
            edTagYear.Text = "2015";
            // 
            // Label495
            // 
            Label495.AutoSize = true;
            Label495.Location = new System.Drawing.Point(21, 550);
            Label495.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label495.Name = "Label495";
            Label495.Size = new System.Drawing.Size(44, 25);
            Label495.TabIndex = 10;
            Label495.Text = "Year";
            // 
            // edTagComment
            // 
            edTagComment.Location = new System.Drawing.Point(27, 308);
            edTagComment.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagComment.Name = "edTagComment";
            edTagComment.Size = new System.Drawing.Size(401, 31);
            edTagComment.TabIndex = 9;
            edTagComment.Text = "No comments";
            // 
            // Label493
            // 
            Label493.AutoSize = true;
            Label493.Location = new System.Drawing.Point(21, 278);
            Label493.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label493.Name = "Label493";
            Label493.Size = new System.Drawing.Size(91, 25);
            Label493.TabIndex = 8;
            Label493.Text = "Comment";
            // 
            // edTagAlbum
            // 
            edTagAlbum.Location = new System.Drawing.Point(27, 222);
            edTagAlbum.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagAlbum.Name = "edTagAlbum";
            edTagAlbum.Size = new System.Drawing.Size(401, 31);
            edTagAlbum.TabIndex = 7;
            edTagAlbum.Text = "Sample album";
            // 
            // Label491
            // 
            Label491.AutoSize = true;
            Label491.Location = new System.Drawing.Point(21, 193);
            Label491.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label491.Name = "Label491";
            Label491.Size = new System.Drawing.Size(65, 25);
            Label491.TabIndex = 6;
            Label491.Text = "Album";
            // 
            // edTagArtists
            // 
            edTagArtists.Location = new System.Drawing.Point(27, 138);
            edTagArtists.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagArtists.Name = "edTagArtists";
            edTagArtists.Size = new System.Drawing.Size(401, 31);
            edTagArtists.TabIndex = 5;
            edTagArtists.Text = "Sample artist";
            // 
            // label494
            // 
            label494.AutoSize = true;
            label494.Location = new System.Drawing.Point(21, 110);
            label494.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label494.Name = "label494";
            label494.Size = new System.Drawing.Size(62, 25);
            label494.TabIndex = 4;
            label494.Text = "Artists";
            // 
            // edTagCopyright
            // 
            edTagCopyright.Location = new System.Drawing.Point(27, 490);
            edTagCopyright.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagCopyright.Name = "edTagCopyright";
            edTagCopyright.Size = new System.Drawing.Size(401, 31);
            edTagCopyright.TabIndex = 3;
            edTagCopyright.Text = "VisioForge";
            // 
            // label497
            // 
            label497.AutoSize = true;
            label497.Location = new System.Drawing.Point(21, 462);
            label497.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label497.Name = "label497";
            label497.Size = new System.Drawing.Size(91, 25);
            label497.TabIndex = 2;
            label497.Text = "Copyright";
            // 
            // edTagTitle
            // 
            edTagTitle.Location = new System.Drawing.Point(27, 57);
            edTagTitle.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTagTitle.Name = "edTagTitle";
            edTagTitle.Size = new System.Drawing.Size(401, 31);
            edTagTitle.TabIndex = 1;
            edTagTitle.Text = "Sample output file";
            // 
            // label498
            // 
            label498.AutoSize = true;
            label498.Location = new System.Drawing.Point(21, 28);
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
            TabPage143.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            TabPage143.Name = "TabPage143";
            TabPage143.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            TabPage143.Size = new System.Drawing.Size(479, 794);
            TabPage143.TabIndex = 1;
            TabPage143.Text = "Special";
            TabPage143.UseVisualStyleBackColor = true;
            // 
            // imgTagCover
            // 
            imgTagCover.BackColor = System.Drawing.Color.DimGray;
            imgTagCover.Location = new System.Drawing.Point(24, 342);
            imgTagCover.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            imgTagCover.Name = "imgTagCover";
            imgTagCover.Size = new System.Drawing.Size(280, 262);
            imgTagCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgTagCover.TabIndex = 16;
            imgTagCover.TabStop = false;
            imgTagCover.Click += (this.imgTagCover_Click);
            // 
            // Label499
            // 
            Label499.AutoSize = true;
            Label499.Location = new System.Drawing.Point(20, 312);
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
            edTagLyrics.Location = new System.Drawing.Point(24, 243);
            edTagLyrics.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbTagGenre.Location = new System.Drawing.Point(24, 147);
            cbTagGenre.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            edTagComposers.Location = new System.Drawing.Point(24, 57);
            edTagComposers.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
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
            cbTagEnabled.Location = new System.Drawing.Point(27, 22);
            cbTagEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTagEnabled.Name = "cbTagEnabled";
            cbTagEnabled.Size = new System.Drawing.Size(228, 29);
            cbTagEnabled.TabIndex = 2;
            cbTagEnabled.Text = "Write tags to output file";
            cbTagEnabled.UseVisualStyleBackColor = true;
            // 
            // cbMode
            // 
            cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMode.FormattingEnabled = true;
            cbMode.Items.AddRange(new object[] { "Video Preview", "Video Capture", "Audio Preview", "Audio Capture", "Screen Preview", "Screen Capture", "IP Preview", "IP Capture", "DVB-x Preview", "DVB-x Capture", "Custom Source Preview", "Custom Source Capture", "DeckLink Source Preview", "DeckLink Source Capture" });
            cbMode.Location = new System.Drawing.Point(626, 1205);
            cbMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMode.Name = "cbMode";
            cbMode.Size = new System.Drawing.Size(254, 33);
            cbMode.TabIndex = 61;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(889, 1200);
            btPause.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(91, 43);
            btPause.TabIndex = 71;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += (this.btPause_Click);
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(989, 1200);
            btResume.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(91, 43);
            btResume.TabIndex = 72;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += (this.btResume_Click);
            // 
            // tabControl10
            // 
            tabControl10.Controls.Add(tabPage46);
            tabControl10.Controls.Add(tabPage63);
            tabControl10.Controls.Add(tabPage47);
            tabControl10.Controls.Add(tabPage48);
            tabControl10.Controls.Add(tabPage4);
            tabControl10.Controls.Add(tabPage81);
            tabControl10.Controls.Add(tabPage49);
            tabControl10.Controls.Add(tabPage50);
            tabControl10.Controls.Add(tabPage51);
            tabControl10.Controls.Add(tabPage12);
            tabControl10.Controls.Add(tabPage88);
            tabControl10.Controls.Add(tabPage124);
            tabControl10.Location = new System.Drawing.Point(549, 15);
            tabControl10.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl10.Name = "tabControl10";
            tabControl10.SelectedIndex = 0;
            tabControl10.Size = new System.Drawing.Size(773, 585);
            tabControl10.TabIndex = 74;
            // 
            // tabPage46
            // 
            tabPage46.Controls.Add(tabControl2);
            tabPage46.Location = new System.Drawing.Point(4, 34);
            tabPage46.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage46.Name = "tabPage46";
            tabPage46.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage46.Size = new System.Drawing.Size(765, 547);
            tabPage46.TabIndex = 0;
            tabPage46.Text = "Video capture device";
            tabPage46.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage8);
            tabControl2.Controls.Add(tabPage52);
            tabControl2.Controls.Add(tabPage10);
            tabControl2.Controls.Add(tabPage11);
            tabControl2.Controls.Add(tabPage57);
            tabControl2.Controls.Add(tabPage66);
            tabControl2.Location = new System.Drawing.Point(4, 12);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(760, 522);
            tabControl2.TabIndex = 66;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(btSignal);
            tabPage8.Controls.Add(label28);
            tabPage8.Controls.Add(cbUseBestVideoInputFormat);
            tabPage8.Controls.Add(btVideoCaptureDeviceSettings);
            tabPage8.Controls.Add(label18);
            tabPage8.Controls.Add(cbVideoInputFrameRate);
            tabPage8.Controls.Add(cbVideoInputFormat);
            tabPage8.Controls.Add(cbVideoInputDevice);
            tabPage8.Controls.Add(label13);
            tabPage8.Controls.Add(label11);
            tabPage8.Location = new System.Drawing.Point(4, 34);
            tabPage8.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage8.Size = new System.Drawing.Size(752, 484);
            tabPage8.TabIndex = 0;
            tabPage8.Text = "Video input";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // btSignal
            // 
            btSignal.Location = new System.Drawing.Point(513, 62);
            btSignal.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSignal.Name = "btSignal";
            btSignal.Size = new System.Drawing.Size(109, 43);
            btSignal.TabIndex = 137;
            btSignal.Text = "Signal";
            btSignal.UseVisualStyleBackColor = true;
            btSignal.Click += (this.btSignal_Click);
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(513, 197);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(37, 25);
            label28.TabIndex = 119;
            label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            cbUseBestVideoInputFormat.AutoSize = true;
            cbUseBestVideoInputFormat.Location = new System.Drawing.Point(267, 143);
            cbUseBestVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            cbUseBestVideoInputFormat.Size = new System.Drawing.Size(106, 29);
            cbUseBestVideoInputFormat.TabIndex = 118;
            cbUseBestVideoInputFormat.Text = "Use best";
            cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            cbUseBestVideoInputFormat.CheckedChanged += (this.cbUseBestVideoInputFormat_CheckedChanged);
            // 
            // btVideoCaptureDeviceSettings
            // 
            btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(396, 62);
            btVideoCaptureDeviceSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(109, 43);
            btVideoCaptureDeviceSettings.TabIndex = 117;
            btVideoCaptureDeviceSettings.Text = "Settings";
            btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            btVideoCaptureDeviceSettings.Click += (this.btVideoCaptureDeviceSettings_Click);
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(390, 147);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(96, 25);
            label18.TabIndex = 116;
            label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFrameRate.FormattingEnabled = true;
            cbVideoInputFrameRate.Location = new System.Drawing.Point(396, 188);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(105, 33);
            cbVideoInputFrameRate.TabIndex = 115;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(39, 188);
            cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVideoInputFormat.Name = "cbVideoInputFormat";
            cbVideoInputFormat.Size = new System.Drawing.Size(344, 33);
            cbVideoInputFormat.TabIndex = 114;
            cbVideoInputFormat.SelectedIndexChanged += (this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputDevice.FormattingEnabled = true;
            cbVideoInputDevice.Location = new System.Drawing.Point(39, 68);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(344, 33);
            cbVideoInputDevice.TabIndex = 113;
            cbVideoInputDevice.SelectedIndexChanged += (this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(33, 147);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 25);
            label13.TabIndex = 112;
            label13.Text = "Input format";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(33, 25);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(109, 25);
            label11.TabIndex = 111;
            label11.Text = "Input device";
            // 
            // tabPage52
            // 
            tabPage52.Controls.Add(cbCrossBarAvailable);
            tabPage52.Controls.Add(lbRotes);
            tabPage52.Controls.Add(label61);
            tabPage52.Controls.Add(label60);
            tabPage52.Controls.Add(cbConnectRelated);
            tabPage52.Controls.Add(btConnect);
            tabPage52.Controls.Add(cbCrossbarVideoInput);
            tabPage52.Controls.Add(label59);
            tabPage52.Controls.Add(rbCrossbarAdvanced);
            tabPage52.Controls.Add(rbCrossbarSimple);
            tabPage52.Controls.Add(cbCrossbarOutput);
            tabPage52.Controls.Add(cbCrossbarInput);
            tabPage52.Controls.Add(label16);
            tabPage52.Location = new System.Drawing.Point(4, 34);
            tabPage52.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage52.Name = "tabPage52";
            tabPage52.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage52.Size = new System.Drawing.Size(752, 484);
            tabPage52.TabIndex = 7;
            tabPage52.Text = "Crossbar (Source)";
            tabPage52.UseVisualStyleBackColor = true;
            // 
            // cbCrossBarAvailable
            // 
            cbCrossBarAvailable.AutoSize = true;
            cbCrossBarAvailable.Enabled = false;
            cbCrossBarAvailable.Location = new System.Drawing.Point(464, 40);
            cbCrossBarAvailable.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCrossBarAvailable.Name = "cbCrossBarAvailable";
            cbCrossBarAvailable.Size = new System.Drawing.Size(181, 29);
            cbCrossBarAvailable.TabIndex = 94;
            cbCrossBarAvailable.Text = "Crossbar available";
            cbCrossBarAvailable.UseVisualStyleBackColor = true;
            // 
            // lbRotes
            // 
            lbRotes.FormattingEnabled = true;
            lbRotes.ItemHeight = 25;
            lbRotes.Location = new System.Drawing.Point(164, 315);
            lbRotes.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbRotes.Name = "lbRotes";
            lbRotes.Size = new System.Drawing.Size(407, 79);
            lbRotes.TabIndex = 93;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new System.Drawing.Point(87, 358);
            label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label61.Name = "label61";
            label61.Size = new System.Drawing.Size(62, 25);
            label61.TabIndex = 92;
            label61.Text = "routes";
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Location = new System.Drawing.Point(87, 315);
            label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label60.Name = "label60";
            label60.Size = new System.Drawing.Size(70, 25);
            label60.TabIndex = 91;
            label60.Text = "Current";
            // 
            // cbConnectRelated
            // 
            cbConnectRelated.AutoSize = true;
            cbConnectRelated.Checked = true;
            cbConnectRelated.CheckState = System.Windows.Forms.CheckState.Checked;
            cbConnectRelated.Location = new System.Drawing.Point(407, 215);
            cbConnectRelated.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbConnectRelated.Name = "cbConnectRelated";
            cbConnectRelated.Size = new System.Drawing.Size(162, 29);
            cbConnectRelated.TabIndex = 90;
            cbConnectRelated.Text = "Connect related";
            cbConnectRelated.UseVisualStyleBackColor = true;
            // 
            // btConnect
            // 
            btConnect.Location = new System.Drawing.Point(464, 260);
            btConnect.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btConnect.Name = "btConnect";
            btConnect.Size = new System.Drawing.Size(110, 43);
            btConnect.TabIndex = 89;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += (this.btConnect_Click);
            // 
            // cbCrossbarVideoInput
            // 
            cbCrossbarVideoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCrossbarVideoInput.FormattingEnabled = true;
            cbCrossbarVideoInput.Location = new System.Drawing.Point(211, 85);
            cbCrossbarVideoInput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCrossbarVideoInput.Name = "cbCrossbarVideoInput";
            cbCrossbarVideoInput.Size = new System.Drawing.Size(153, 33);
            cbCrossbarVideoInput.TabIndex = 88;
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new System.Drawing.Point(87, 90);
            label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label59.Name = "label59";
            label59.Size = new System.Drawing.Size(104, 25);
            label59.TabIndex = 87;
            label59.Text = "Video input";
            // 
            // rbCrossbarAdvanced
            // 
            rbCrossbarAdvanced.AutoSize = true;
            rbCrossbarAdvanced.Location = new System.Drawing.Point(31, 168);
            rbCrossbarAdvanced.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbCrossbarAdvanced.Name = "rbCrossbarAdvanced";
            rbCrossbarAdvanced.Size = new System.Drawing.Size(116, 29);
            rbCrossbarAdvanced.TabIndex = 86;
            rbCrossbarAdvanced.Text = "Advanced";
            rbCrossbarAdvanced.UseVisualStyleBackColor = true;
            // 
            // rbCrossbarSimple
            // 
            rbCrossbarSimple.AutoSize = true;
            rbCrossbarSimple.Checked = true;
            rbCrossbarSimple.Location = new System.Drawing.Point(31, 38);
            rbCrossbarSimple.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbCrossbarSimple.Name = "rbCrossbarSimple";
            rbCrossbarSimple.Size = new System.Drawing.Size(91, 29);
            rbCrossbarSimple.TabIndex = 85;
            rbCrossbarSimple.TabStop = true;
            rbCrossbarSimple.Text = "Simple";
            rbCrossbarSimple.UseVisualStyleBackColor = true;
            // 
            // cbCrossbarOutput
            // 
            cbCrossbarOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCrossbarOutput.FormattingEnabled = true;
            cbCrossbarOutput.Location = new System.Drawing.Point(271, 262);
            cbCrossbarOutput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCrossbarOutput.Name = "cbCrossbarOutput";
            cbCrossbarOutput.Size = new System.Drawing.Size(164, 33);
            cbCrossbarOutput.TabIndex = 84;
            cbCrossbarOutput.SelectedIndexChanged += (this.cbCrossbarOutput_SelectedIndexChanged);
            // 
            // cbCrossbarInput
            // 
            cbCrossbarInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCrossbarInput.FormattingEnabled = true;
            cbCrossbarInput.Location = new System.Drawing.Point(91, 262);
            cbCrossbarInput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCrossbarInput.Name = "cbCrossbarInput";
            cbCrossbarInput.Size = new System.Drawing.Size(164, 33);
            cbCrossbarInput.TabIndex = 83;
            cbCrossbarInput.SelectedIndexChanged += (this.cbCrossbarInput_SelectedIndexChanged);
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(87, 218);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(229, 25);
            label16.TabIndex = 82;
            label16.Text = "Crossbar (INPUT - OUTPUT)";
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(tabControl3);
            tabPage10.Location = new System.Drawing.Point(4, 34);
            tabPage10.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage10.Size = new System.Drawing.Size(752, 484);
            tabPage10.TabIndex = 2;
            tabPage10.Text = "TV tuner";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage14);
            tabControl3.Controls.Add(tabPage15);
            tabControl3.Controls.Add(tabPage21);
            tabControl3.Location = new System.Drawing.Point(4, 12);
            tabControl3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new System.Drawing.Size(731, 450);
            tabControl3.TabIndex = 0;
            // 
            // tabPage14
            // 
            tabPage14.Controls.Add(cbUseClosedCaptions);
            tabPage14.Controls.Add(edTVDefaultFormat);
            tabPage14.Controls.Add(label57);
            tabPage14.Controls.Add(cbTVCountry);
            tabPage14.Controls.Add(label56);
            tabPage14.Controls.Add(cbTVMode);
            tabPage14.Controls.Add(cbTVInput);
            tabPage14.Controls.Add(cbTVTuner);
            tabPage14.Controls.Add(label33);
            tabPage14.Controls.Add(label32);
            tabPage14.Controls.Add(label27);
            tabPage14.Location = new System.Drawing.Point(4, 34);
            tabPage14.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage14.Name = "tabPage14";
            tabPage14.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage14.Size = new System.Drawing.Size(723, 412);
            tabPage14.TabIndex = 0;
            tabPage14.Text = "Main settings";
            tabPage14.UseVisualStyleBackColor = true;
            // 
            // cbUseClosedCaptions
            // 
            cbUseClosedCaptions.AutoSize = true;
            cbUseClosedCaptions.Location = new System.Drawing.Point(43, 288);
            cbUseClosedCaptions.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbUseClosedCaptions.Name = "cbUseClosedCaptions";
            cbUseClosedCaptions.Size = new System.Drawing.Size(262, 29);
            cbUseClosedCaptions.TabIndex = 60;
            cbUseClosedCaptions.Text = "Allow closed captions usage";
            cbUseClosedCaptions.UseVisualStyleBackColor = true;
            // 
            // edTVDefaultFormat
            // 
            edTVDefaultFormat.Location = new System.Drawing.Point(387, 197);
            edTVDefaultFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTVDefaultFormat.Name = "edTVDefaultFormat";
            edTVDefaultFormat.ReadOnly = true;
            edTVDefaultFormat.Size = new System.Drawing.Size(135, 31);
            edTVDefaultFormat.TabIndex = 59;
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new System.Drawing.Point(381, 160);
            label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label57.Name = "label57";
            label57.Size = new System.Drawing.Size(128, 25);
            label57.TabIndex = 58;
            label57.Text = "Default format";
            // 
            // cbTVCountry
            // 
            cbTVCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVCountry.FormattingEnabled = true;
            cbTVCountry.Location = new System.Drawing.Point(121, 197);
            cbTVCountry.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVCountry.Name = "cbTVCountry";
            cbTVCountry.Size = new System.Drawing.Size(247, 33);
            cbTVCountry.TabIndex = 57;
            cbTVCountry.SelectedIndexChanged += (this.cbTVCountry_SelectedIndexChanged);
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new System.Drawing.Point(39, 202);
            label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label56.Name = "label56";
            label56.Size = new System.Drawing.Size(75, 25);
            label56.TabIndex = 56;
            label56.Text = "Country";
            // 
            // cbTVMode
            // 
            cbTVMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVMode.FormattingEnabled = true;
            cbTVMode.Items.AddRange(new object[] { "Default", "TV", "FM Radio", "AM Radio", "DSS" });
            cbTVMode.Location = new System.Drawing.Point(120, 98);
            cbTVMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVMode.Name = "cbTVMode";
            cbTVMode.Size = new System.Drawing.Size(141, 33);
            cbTVMode.TabIndex = 55;
            cbTVMode.SelectedIndexChanged += (this.cbTVMode_SelectedIndexChanged);
            // 
            // cbTVInput
            // 
            cbTVInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVInput.FormattingEnabled = true;
            cbTVInput.Items.AddRange(new object[] { "Cable", "Antenna" });
            cbTVInput.Location = new System.Drawing.Point(381, 98);
            cbTVInput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVInput.Name = "cbTVInput";
            cbTVInput.Size = new System.Drawing.Size(141, 33);
            cbTVInput.TabIndex = 54;
            cbTVInput.SelectedIndexChanged += (this.cbTVInput_SelectedIndexChanged);
            // 
            // cbTVTuner
            // 
            cbTVTuner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVTuner.FormattingEnabled = true;
            cbTVTuner.Location = new System.Drawing.Point(120, 32);
            cbTVTuner.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVTuner.Name = "cbTVTuner";
            cbTVTuner.Size = new System.Drawing.Size(403, 33);
            cbTVTuner.TabIndex = 53;
            cbTVTuner.SelectedIndexChanged += (this.cbTVTuner_SelectedIndexChanged);
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new System.Drawing.Point(39, 103);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(59, 25);
            label33.TabIndex = 52;
            label33.Text = "Mode";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(320, 103);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(54, 25);
            label32.TabIndex = 51;
            label32.Text = "Input";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(39, 38);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(64, 25);
            label27.TabIndex = 50;
            label27.Text = "Device";
            // 
            // tabPage15
            // 
            tabPage15.Controls.Add(edChannel);
            tabPage15.Controls.Add(btUseThisChannel);
            tabPage15.Controls.Add(groupBox1);
            tabPage15.Controls.Add(cbTVSystem);
            tabPage15.Controls.Add(edAudioFreq);
            tabPage15.Controls.Add(label36);
            tabPage15.Controls.Add(edVideoFreq);
            tabPage15.Controls.Add(label37);
            tabPage15.Controls.Add(label34);
            tabPage15.Location = new System.Drawing.Point(4, 34);
            tabPage15.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage15.Name = "tabPage15";
            tabPage15.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage15.Size = new System.Drawing.Size(723, 412);
            tabPage15.TabIndex = 1;
            tabPage15.Text = "Tuning";
            tabPage15.UseVisualStyleBackColor = true;
            // 
            // edChannel
            // 
            edChannel.Location = new System.Drawing.Point(557, 262);
            edChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edChannel.Name = "edChannel";
            edChannel.Size = new System.Drawing.Size(128, 31);
            edChannel.TabIndex = 59;
            edChannel.Text = "22";
            // 
            // btUseThisChannel
            // 
            btUseThisChannel.Location = new System.Drawing.Point(373, 257);
            btUseThisChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btUseThisChannel.Name = "btUseThisChannel";
            btUseThisChannel.Size = new System.Drawing.Size(173, 43);
            btUseThisChannel.TabIndex = 58;
            btUseThisChannel.Text = "Set channel/freq.";
            btUseThisChannel.UseVisualStyleBackColor = true;
            btUseThisChannel.Click += (this.btUseThisChannel_Click);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbTVChannel);
            groupBox1.Controls.Add(label58);
            groupBox1.Controls.Add(pbChannels);
            groupBox1.Controls.Add(btStopTune);
            groupBox1.Controls.Add(btStartTune);
            groupBox1.Location = new System.Drawing.Point(27, 38);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox1.Size = new System.Drawing.Size(437, 188);
            groupBox1.TabIndex = 57;
            groupBox1.TabStop = false;
            groupBox1.Text = "AutoTune";
            // 
            // cbTVChannel
            // 
            cbTVChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVChannel.FormattingEnabled = true;
            cbTVChannel.Location = new System.Drawing.Point(276, 108);
            cbTVChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVChannel.Name = "cbTVChannel";
            cbTVChannel.Size = new System.Drawing.Size(134, 33);
            cbTVChannel.TabIndex = 4;
            cbTVChannel.SelectedIndexChanged += (this.cbTVChannel_SelectedIndexChanged);
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Location = new System.Drawing.Point(29, 112);
            label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label58.Name = "label58";
            label58.Size = new System.Drawing.Size(228, 25);
            label58.TabIndex = 3;
            label58.Text = "TV Channel / FM Frequency";
            // 
            // pbChannels
            // 
            pbChannels.Location = new System.Drawing.Point(244, 43);
            pbChannels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pbChannels.Name = "pbChannels";
            pbChannels.Size = new System.Drawing.Size(167, 28);
            pbChannels.TabIndex = 2;
            // 
            // btStopTune
            // 
            btStopTune.Location = new System.Drawing.Point(127, 38);
            btStopTune.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btStopTune.Name = "btStopTune";
            btStopTune.Size = new System.Drawing.Size(83, 43);
            btStopTune.TabIndex = 1;
            btStopTune.Text = "Stop";
            btStopTune.UseVisualStyleBackColor = true;
            btStopTune.Click += (this.btStopTune_Click);
            // 
            // btStartTune
            // 
            btStartTune.Location = new System.Drawing.Point(33, 38);
            btStartTune.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btStartTune.Name = "btStartTune";
            btStartTune.Size = new System.Drawing.Size(83, 43);
            btStartTune.TabIndex = 0;
            btStartTune.Text = "Start";
            btStartTune.UseVisualStyleBackColor = true;
            btStartTune.Click += (this.btStartTune_Click);
            // 
            // cbTVSystem
            // 
            cbTVSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTVSystem.FormattingEnabled = true;
            cbTVSystem.Location = new System.Drawing.Point(169, 262);
            cbTVSystem.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTVSystem.Name = "cbTVSystem";
            cbTVSystem.Size = new System.Drawing.Size(141, 33);
            cbTVSystem.TabIndex = 56;
            cbTVSystem.SelectedIndexChanged += (this.cbTVSystem_SelectedIndexChanged);
            // 
            // edAudioFreq
            // 
            edAudioFreq.Location = new System.Drawing.Point(640, 147);
            edAudioFreq.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edAudioFreq.Name = "edAudioFreq";
            edAudioFreq.Size = new System.Drawing.Size(45, 31);
            edAudioFreq.TabIndex = 55;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(481, 150);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(143, 25);
            label36.TabIndex = 54;
            label36.Text = "Audio frequency";
            // 
            // edVideoFreq
            // 
            edVideoFreq.Location = new System.Drawing.Point(640, 68);
            edVideoFreq.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edVideoFreq.Name = "edVideoFreq";
            edVideoFreq.Size = new System.Drawing.Size(45, 31);
            edVideoFreq.TabIndex = 53;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(481, 72);
            label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(141, 25);
            label37.TabIndex = 52;
            label37.Text = "Video frequency";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(21, 268);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(140, 25);
            label34.TabIndex = 51;
            label34.Text = "TV video format";
            // 
            // tabPage21
            // 
            tabPage21.Controls.Add(btMPEGEncoderShowDialog);
            tabPage21.Controls.Add(cbMPEGEncoder);
            tabPage21.Controls.Add(label21);
            tabPage21.Location = new System.Drawing.Point(4, 34);
            tabPage21.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage21.Name = "tabPage21";
            tabPage21.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage21.Size = new System.Drawing.Size(723, 412);
            tabPage21.TabIndex = 3;
            tabPage21.Text = "MPEG Encoder";
            tabPage21.UseVisualStyleBackColor = true;
            // 
            // btMPEGEncoderShowDialog
            // 
            btMPEGEncoderShowDialog.Location = new System.Drawing.Point(401, 58);
            btMPEGEncoderShowDialog.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btMPEGEncoderShowDialog.Name = "btMPEGEncoderShowDialog";
            btMPEGEncoderShowDialog.Size = new System.Drawing.Size(124, 43);
            btMPEGEncoderShowDialog.TabIndex = 2;
            btMPEGEncoderShowDialog.Text = "Settings";
            btMPEGEncoderShowDialog.UseVisualStyleBackColor = true;
            btMPEGEncoderShowDialog.Click += (this.btMPEGEncoderShowDialog_Click);
            // 
            // cbMPEGEncoder
            // 
            cbMPEGEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMPEGEncoder.FormattingEnabled = true;
            cbMPEGEncoder.Location = new System.Drawing.Point(31, 62);
            cbMPEGEncoder.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMPEGEncoder.Name = "cbMPEGEncoder";
            cbMPEGEncoder.Size = new System.Drawing.Size(357, 33);
            cbMPEGEncoder.TabIndex = 1;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(27, 32);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(128, 25);
            label21.TabIndex = 0;
            label21.Text = "MPEG Encoder";
            // 
            // tabPage11
            // 
            tabPage11.Controls.Add(groupBox21);
            tabPage11.Controls.Add(groupBox2);
            tabPage11.Location = new System.Drawing.Point(4, 34);
            tabPage11.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage11.Size = new System.Drawing.Size(752, 484);
            tabPage11.TabIndex = 3;
            tabPage11.Text = "DV";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(rbDVResDC);
            groupBox21.Controls.Add(rbDVResQuarter);
            groupBox21.Controls.Add(rbDVResHalf);
            groupBox21.Controls.Add(rbDVResFull);
            groupBox21.Location = new System.Drawing.Point(31, 268);
            groupBox21.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox21.Name = "groupBox21";
            groupBox21.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox21.Size = new System.Drawing.Size(601, 88);
            groupBox21.TabIndex = 1;
            groupBox21.TabStop = false;
            groupBox21.Text = "Resolution";
            // 
            // rbDVResDC
            // 
            rbDVResDC.AutoSize = true;
            rbDVResDC.Location = new System.Drawing.Point(464, 38);
            rbDVResDC.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDVResDC.Name = "rbDVResDC";
            rbDVResDC.Size = new System.Drawing.Size(61, 29);
            rbDVResDC.TabIndex = 3;
            rbDVResDC.Text = "DC";
            rbDVResDC.UseVisualStyleBackColor = true;
            // 
            // rbDVResQuarter
            // 
            rbDVResQuarter.AutoSize = true;
            rbDVResQuarter.Location = new System.Drawing.Point(304, 38);
            rbDVResQuarter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDVResQuarter.Name = "rbDVResQuarter";
            rbDVResQuarter.Size = new System.Drawing.Size(97, 29);
            rbDVResQuarter.TabIndex = 2;
            rbDVResQuarter.Text = "Quarter";
            rbDVResQuarter.UseVisualStyleBackColor = true;
            // 
            // rbDVResHalf
            // 
            rbDVResHalf.AutoSize = true;
            rbDVResHalf.Location = new System.Drawing.Point(173, 38);
            rbDVResHalf.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDVResHalf.Name = "rbDVResHalf";
            rbDVResHalf.Size = new System.Drawing.Size(69, 29);
            rbDVResHalf.TabIndex = 1;
            rbDVResHalf.Text = "Half";
            rbDVResHalf.UseVisualStyleBackColor = true;
            // 
            // rbDVResFull
            // 
            rbDVResFull.AutoSize = true;
            rbDVResFull.Checked = true;
            rbDVResFull.Location = new System.Drawing.Point(37, 38);
            rbDVResFull.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDVResFull.Name = "rbDVResFull";
            rbDVResFull.Size = new System.Drawing.Size(64, 29);
            rbDVResFull.TabIndex = 0;
            rbDVResFull.TabStop = true;
            rbDVResFull.Text = "Full";
            rbDVResFull.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btDVStepFWD);
            groupBox2.Controls.Add(btDVStepRev);
            groupBox2.Controls.Add(btDVFF);
            groupBox2.Controls.Add(btDVStop);
            groupBox2.Controls.Add(btDVPause);
            groupBox2.Controls.Add(btDVPlay);
            groupBox2.Controls.Add(btDVRewind);
            groupBox2.Location = new System.Drawing.Point(31, 47);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox2.Size = new System.Drawing.Size(601, 192);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btDVStepFWD
            // 
            btDVStepFWD.Location = new System.Drawing.Point(419, 112);
            btDVStepFWD.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVStepFWD.Name = "btDVStepFWD";
            btDVStepFWD.Size = new System.Drawing.Size(113, 43);
            btDVStepFWD.TabIndex = 6;
            btDVStepFWD.Text = "Step FWD";
            btDVStepFWD.UseVisualStyleBackColor = true;
            btDVStepFWD.Click += (this.btDVStepFWD_Click);
            // 
            // btDVStepRev
            // 
            btDVStepRev.Location = new System.Drawing.Point(87, 112);
            btDVStepRev.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVStepRev.Name = "btDVStepRev";
            btDVStepRev.Size = new System.Drawing.Size(113, 43);
            btDVStepRev.TabIndex = 5;
            btDVStepRev.Text = "Step REV";
            btDVStepRev.UseVisualStyleBackColor = true;
            btDVStepRev.Click += (this.btDVStepRev_Click);
            // 
            // btDVFF
            // 
            btDVFF.Location = new System.Drawing.Point(477, 43);
            btDVFF.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVFF.Name = "btDVFF";
            btDVFF.Size = new System.Drawing.Size(100, 43);
            btDVFF.TabIndex = 4;
            btDVFF.Text = "F.F.";
            btDVFF.UseVisualStyleBackColor = true;
            btDVFF.Click += (this.btDVFF_Click);
            // 
            // btDVStop
            // 
            btDVStop.Location = new System.Drawing.Point(367, 43);
            btDVStop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVStop.Name = "btDVStop";
            btDVStop.Size = new System.Drawing.Size(100, 43);
            btDVStop.TabIndex = 3;
            btDVStop.Text = "Stop";
            btDVStop.UseVisualStyleBackColor = true;
            btDVStop.Click += (this.btDVStop_Click);
            // 
            // btDVPause
            // 
            btDVPause.Location = new System.Drawing.Point(257, 43);
            btDVPause.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVPause.Name = "btDVPause";
            btDVPause.Size = new System.Drawing.Size(100, 43);
            btDVPause.TabIndex = 2;
            btDVPause.Text = "Pause";
            btDVPause.UseVisualStyleBackColor = true;
            btDVPause.Click += (this.btDVPause_Click);
            // 
            // btDVPlay
            // 
            btDVPlay.Location = new System.Drawing.Point(147, 43);
            btDVPlay.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVPlay.Name = "btDVPlay";
            btDVPlay.Size = new System.Drawing.Size(100, 43);
            btDVPlay.TabIndex = 1;
            btDVPlay.Text = "Play";
            btDVPlay.UseVisualStyleBackColor = true;
            btDVPlay.Click += (this.btDVPlay_Click);
            // 
            // btDVRewind
            // 
            btDVRewind.Location = new System.Drawing.Point(37, 43);
            btDVRewind.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVRewind.Name = "btDVRewind";
            btDVRewind.Size = new System.Drawing.Size(100, 43);
            btDVRewind.TabIndex = 0;
            btDVRewind.Text = "Rewind";
            btDVRewind.UseVisualStyleBackColor = true;
            btDVRewind.Click += (this.btDVRewind_Click);
            // 
            // tabPage57
            // 
            tabPage57.Controls.Add(lbAdjSaturationCurrent);
            tabPage57.Controls.Add(lbAdjSaturationMax);
            tabPage57.Controls.Add(cbAdjSaturationAuto);
            tabPage57.Controls.Add(lbAdjSaturationMin);
            tabPage57.Controls.Add(tbAdjSaturation);
            tabPage57.Controls.Add(label45);
            tabPage57.Controls.Add(lbAdjHueCurrent);
            tabPage57.Controls.Add(lbAdjHueMax);
            tabPage57.Controls.Add(cbAdjHueAuto);
            tabPage57.Controls.Add(lbAdjHueMin);
            tabPage57.Controls.Add(tbAdjHue);
            tabPage57.Controls.Add(label41);
            tabPage57.Controls.Add(lbAdjContrastCurrent);
            tabPage57.Controls.Add(lbAdjContrastMax);
            tabPage57.Controls.Add(cbAdjContrastAuto);
            tabPage57.Controls.Add(lbAdjContrastMin);
            tabPage57.Controls.Add(tbAdjContrast);
            tabPage57.Controls.Add(label23);
            tabPage57.Controls.Add(lbAdjBrightnessCurrent);
            tabPage57.Controls.Add(lbAdjBrightnessMax);
            tabPage57.Controls.Add(cbAdjBrightnessAuto);
            tabPage57.Controls.Add(lbAdjBrightnessMin);
            tabPage57.Controls.Add(tbAdjBrightness);
            tabPage57.Controls.Add(label17);
            tabPage57.Location = new System.Drawing.Point(4, 34);
            tabPage57.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage57.Name = "tabPage57";
            tabPage57.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage57.Size = new System.Drawing.Size(752, 484);
            tabPage57.TabIndex = 8;
            tabPage57.Text = "Video adjustments";
            tabPage57.UseVisualStyleBackColor = true;
            // 
            // lbAdjSaturationCurrent
            // 
            lbAdjSaturationCurrent.AutoSize = true;
            lbAdjSaturationCurrent.Location = new System.Drawing.Point(569, 240);
            lbAdjSaturationCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationCurrent.Name = "lbAdjSaturationCurrent";
            lbAdjSaturationCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjSaturationCurrent.TabIndex = 36;
            lbAdjSaturationCurrent.Text = "Current = 40";
            // 
            // lbAdjSaturationMax
            // 
            lbAdjSaturationMax.AutoSize = true;
            lbAdjSaturationMax.Location = new System.Drawing.Point(463, 240);
            lbAdjSaturationMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationMax.Name = "lbAdjSaturationMax";
            lbAdjSaturationMax.Size = new System.Drawing.Size(97, 25);
            lbAdjSaturationMax.TabIndex = 35;
            lbAdjSaturationMax.Text = "Max = 100";
            // 
            // cbAdjSaturationAuto
            // 
            cbAdjSaturationAuto.AutoSize = true;
            cbAdjSaturationAuto.Location = new System.Drawing.Point(611, 152);
            cbAdjSaturationAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAdjSaturationAuto.Name = "cbAdjSaturationAuto";
            cbAdjSaturationAuto.Size = new System.Drawing.Size(77, 29);
            cbAdjSaturationAuto.TabIndex = 34;
            cbAdjSaturationAuto.Text = "Auto";
            cbAdjSaturationAuto.UseVisualStyleBackColor = true;
            cbAdjSaturationAuto.CheckedChanged += (this.tbAdjSaturation_Scroll);
            // 
            // lbAdjSaturationMin
            // 
            lbAdjSaturationMin.AutoSize = true;
            lbAdjSaturationMin.Location = new System.Drawing.Point(383, 240);
            lbAdjSaturationMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjSaturationMin.Name = "lbAdjSaturationMin";
            lbAdjSaturationMin.Size = new System.Drawing.Size(74, 25);
            lbAdjSaturationMin.TabIndex = 33;
            lbAdjSaturationMin.Text = "Min = 1";
            // 
            // tbAdjSaturation
            // 
            tbAdjSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbAdjSaturation.Location = new System.Drawing.Point(373, 185);
            tbAdjSaturation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAdjSaturation.Maximum = 100;
            tbAdjSaturation.Name = "tbAdjSaturation";
            tbAdjSaturation.Size = new System.Drawing.Size(319, 69);
            tbAdjSaturation.TabIndex = 32;
            tbAdjSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjSaturation.Value = 50;
            tbAdjSaturation.Scroll += (this.tbAdjSaturation_Scroll);
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(369, 153);
            label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(93, 25);
            label45.TabIndex = 31;
            label45.Text = "Saturation";
            // 
            // lbAdjHueCurrent
            // 
            lbAdjHueCurrent.AutoSize = true;
            lbAdjHueCurrent.Location = new System.Drawing.Point(569, 110);
            lbAdjHueCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueCurrent.Name = "lbAdjHueCurrent";
            lbAdjHueCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjHueCurrent.TabIndex = 30;
            lbAdjHueCurrent.Text = "Current = 40";
            // 
            // lbAdjHueMax
            // 
            lbAdjHueMax.AutoSize = true;
            lbAdjHueMax.Location = new System.Drawing.Point(463, 110);
            lbAdjHueMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueMax.Name = "lbAdjHueMax";
            lbAdjHueMax.Size = new System.Drawing.Size(97, 25);
            lbAdjHueMax.TabIndex = 29;
            lbAdjHueMax.Text = "Max = 100";
            // 
            // cbAdjHueAuto
            // 
            cbAdjHueAuto.AutoSize = true;
            cbAdjHueAuto.Location = new System.Drawing.Point(611, 22);
            cbAdjHueAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAdjHueAuto.Name = "cbAdjHueAuto";
            cbAdjHueAuto.Size = new System.Drawing.Size(77, 29);
            cbAdjHueAuto.TabIndex = 28;
            cbAdjHueAuto.Text = "Auto";
            cbAdjHueAuto.UseVisualStyleBackColor = true;
            cbAdjHueAuto.CheckedChanged += (this.tbAdjHue_Scroll);
            // 
            // lbAdjHueMin
            // 
            lbAdjHueMin.AutoSize = true;
            lbAdjHueMin.Location = new System.Drawing.Point(383, 110);
            lbAdjHueMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjHueMin.Name = "lbAdjHueMin";
            lbAdjHueMin.Size = new System.Drawing.Size(74, 25);
            lbAdjHueMin.TabIndex = 27;
            lbAdjHueMin.Text = "Min = 1";
            // 
            // tbAdjHue
            // 
            tbAdjHue.BackColor = System.Drawing.SystemColors.Window;
            tbAdjHue.Location = new System.Drawing.Point(373, 53);
            tbAdjHue.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAdjHue.Maximum = 100;
            tbAdjHue.Name = "tbAdjHue";
            tbAdjHue.Size = new System.Drawing.Size(319, 69);
            tbAdjHue.TabIndex = 26;
            tbAdjHue.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjHue.Value = 50;
            tbAdjHue.Scroll += (this.tbAdjHue_Scroll);
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new System.Drawing.Point(369, 22);
            label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(44, 25);
            label41.TabIndex = 25;
            label41.Text = "Hue";
            // 
            // lbAdjContrastCurrent
            // 
            lbAdjContrastCurrent.AutoSize = true;
            lbAdjContrastCurrent.Location = new System.Drawing.Point(220, 240);
            lbAdjContrastCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastCurrent.Name = "lbAdjContrastCurrent";
            lbAdjContrastCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjContrastCurrent.TabIndex = 24;
            lbAdjContrastCurrent.Text = "Current = 40";
            // 
            // lbAdjContrastMax
            // 
            lbAdjContrastMax.AutoSize = true;
            lbAdjContrastMax.Location = new System.Drawing.Point(116, 240);
            lbAdjContrastMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastMax.Name = "lbAdjContrastMax";
            lbAdjContrastMax.Size = new System.Drawing.Size(97, 25);
            lbAdjContrastMax.TabIndex = 23;
            lbAdjContrastMax.Text = "Max = 100";
            // 
            // cbAdjContrastAuto
            // 
            cbAdjContrastAuto.AutoSize = true;
            cbAdjContrastAuto.Location = new System.Drawing.Point(263, 152);
            cbAdjContrastAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAdjContrastAuto.Name = "cbAdjContrastAuto";
            cbAdjContrastAuto.Size = new System.Drawing.Size(77, 29);
            cbAdjContrastAuto.TabIndex = 22;
            cbAdjContrastAuto.Text = "Auto";
            cbAdjContrastAuto.UseVisualStyleBackColor = true;
            cbAdjContrastAuto.CheckedChanged += (this.tbAdjContrast_Scroll);
            // 
            // lbAdjContrastMin
            // 
            lbAdjContrastMin.AutoSize = true;
            lbAdjContrastMin.Location = new System.Drawing.Point(36, 240);
            lbAdjContrastMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjContrastMin.Name = "lbAdjContrastMin";
            lbAdjContrastMin.Size = new System.Drawing.Size(74, 25);
            lbAdjContrastMin.TabIndex = 21;
            lbAdjContrastMin.Text = "Min = 1";
            // 
            // tbAdjContrast
            // 
            tbAdjContrast.BackColor = System.Drawing.SystemColors.Window;
            tbAdjContrast.Location = new System.Drawing.Point(24, 185);
            tbAdjContrast.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAdjContrast.Maximum = 100;
            tbAdjContrast.Name = "tbAdjContrast";
            tbAdjContrast.Size = new System.Drawing.Size(319, 69);
            tbAdjContrast.TabIndex = 20;
            tbAdjContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjContrast.Value = 50;
            tbAdjContrast.Scroll += (this.tbAdjContrast_Scroll);
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(20, 153);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(79, 25);
            label23.TabIndex = 19;
            label23.Text = "Contrast";
            // 
            // lbAdjBrightnessCurrent
            // 
            lbAdjBrightnessCurrent.AutoSize = true;
            lbAdjBrightnessCurrent.Location = new System.Drawing.Point(220, 110);
            lbAdjBrightnessCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessCurrent.Name = "lbAdjBrightnessCurrent";
            lbAdjBrightnessCurrent.Size = new System.Drawing.Size(112, 25);
            lbAdjBrightnessCurrent.TabIndex = 18;
            lbAdjBrightnessCurrent.Text = "Current = 40";
            // 
            // lbAdjBrightnessMax
            // 
            lbAdjBrightnessMax.AutoSize = true;
            lbAdjBrightnessMax.Location = new System.Drawing.Point(116, 110);
            lbAdjBrightnessMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessMax.Name = "lbAdjBrightnessMax";
            lbAdjBrightnessMax.Size = new System.Drawing.Size(97, 25);
            lbAdjBrightnessMax.TabIndex = 17;
            lbAdjBrightnessMax.Text = "Max = 100";
            // 
            // cbAdjBrightnessAuto
            // 
            cbAdjBrightnessAuto.AutoSize = true;
            cbAdjBrightnessAuto.Location = new System.Drawing.Point(263, 22);
            cbAdjBrightnessAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAdjBrightnessAuto.Name = "cbAdjBrightnessAuto";
            cbAdjBrightnessAuto.Size = new System.Drawing.Size(77, 29);
            cbAdjBrightnessAuto.TabIndex = 16;
            cbAdjBrightnessAuto.Text = "Auto";
            cbAdjBrightnessAuto.UseVisualStyleBackColor = true;
            cbAdjBrightnessAuto.CheckedChanged += (this.tbAdjBrightness_Scroll);
            // 
            // lbAdjBrightnessMin
            // 
            lbAdjBrightnessMin.AutoSize = true;
            lbAdjBrightnessMin.Location = new System.Drawing.Point(36, 110);
            lbAdjBrightnessMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbAdjBrightnessMin.Name = "lbAdjBrightnessMin";
            lbAdjBrightnessMin.Size = new System.Drawing.Size(74, 25);
            lbAdjBrightnessMin.TabIndex = 15;
            lbAdjBrightnessMin.Text = "Min = 1";
            // 
            // tbAdjBrightness
            // 
            tbAdjBrightness.BackColor = System.Drawing.SystemColors.Window;
            tbAdjBrightness.Location = new System.Drawing.Point(24, 53);
            tbAdjBrightness.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAdjBrightness.Maximum = 100;
            tbAdjBrightness.Name = "tbAdjBrightness";
            tbAdjBrightness.Size = new System.Drawing.Size(319, 69);
            tbAdjBrightness.TabIndex = 14;
            tbAdjBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            tbAdjBrightness.Value = 50;
            tbAdjBrightness.Scroll += (this.tbAdjBrightness_Scroll);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(20, 22);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(94, 25);
            label17.TabIndex = 13;
            label17.Text = "Brightness";
            // 
            // tabPage66
            // 
            tabPage66.Controls.Add(label1);
            tabPage66.Controls.Add(btCCFocusApply);
            tabPage66.Controls.Add(btCCZoomApply);
            tabPage66.Controls.Add(cbCCFocusRelative);
            tabPage66.Controls.Add(cbCCFocusManual);
            tabPage66.Controls.Add(cbCCFocusAuto);
            tabPage66.Controls.Add(lbCCFocusCurrent);
            tabPage66.Controls.Add(lbCCFocusMax);
            tabPage66.Controls.Add(lbCCFocusMin);
            tabPage66.Controls.Add(tbCCFocus);
            tabPage66.Controls.Add(label4);
            tabPage66.Controls.Add(cbCCZoomRelative);
            tabPage66.Controls.Add(cbCCZoomManual);
            tabPage66.Controls.Add(cbCCZoomAuto);
            tabPage66.Controls.Add(lbCCZoomCurrent);
            tabPage66.Controls.Add(lbCCZoomMax);
            tabPage66.Controls.Add(lbCCZoomMin);
            tabPage66.Controls.Add(tbCCZoom);
            tabPage66.Controls.Add(label20);
            tabPage66.Controls.Add(btCCTiltApply);
            tabPage66.Controls.Add(btCCPanApply);
            tabPage66.Controls.Add(cbCCTiltRelative);
            tabPage66.Controls.Add(cbCCTiltManual);
            tabPage66.Controls.Add(cbCCTiltAuto);
            tabPage66.Controls.Add(lbCCTiltCurrent);
            tabPage66.Controls.Add(lbCCTiltMax);
            tabPage66.Controls.Add(lbCCTiltMin);
            tabPage66.Controls.Add(tbCCTilt);
            tabPage66.Controls.Add(label97);
            tabPage66.Controls.Add(cbCCPanRelative);
            tabPage66.Controls.Add(cbCCPanManual);
            tabPage66.Controls.Add(cbCCPanAuto);
            tabPage66.Controls.Add(btCCReadValues);
            tabPage66.Controls.Add(lbCCPanCurrent);
            tabPage66.Controls.Add(lbCCPanMax);
            tabPage66.Controls.Add(lbCCPanMin);
            tabPage66.Controls.Add(tbCCPan);
            tabPage66.Controls.Add(label96);
            tabPage66.Location = new System.Drawing.Point(4, 34);
            tabPage66.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage66.Name = "tabPage66";
            tabPage66.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage66.Size = new System.Drawing.Size(752, 484);
            tabPage66.TabIndex = 9;
            tabPage66.Text = "Camera control";
            tabPage66.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 22);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(350, 25);
            label1.TabIndex = 58;
            label1.Text = "Many other parameters available using API";
            // 
            // btCCFocusApply
            // 
            btCCFocusApply.Location = new System.Drawing.Point(400, 422);
            btCCFocusApply.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btCCFocusApply.Name = "btCCFocusApply";
            btCCFocusApply.Size = new System.Drawing.Size(124, 43);
            btCCFocusApply.TabIndex = 57;
            btCCFocusApply.Text = "Apply";
            btCCFocusApply.UseVisualStyleBackColor = true;
            btCCFocusApply.Click += (this.btCCFocusApply_Click);
            // 
            // btCCZoomApply
            // 
            btCCZoomApply.Location = new System.Drawing.Point(47, 422);
            btCCZoomApply.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btCCZoomApply.Name = "btCCZoomApply";
            btCCZoomApply.Size = new System.Drawing.Size(124, 43);
            btCCZoomApply.TabIndex = 56;
            btCCZoomApply.Text = "Apply";
            btCCZoomApply.UseVisualStyleBackColor = true;
            btCCZoomApply.Click += (this.btCCZoomApply_Click);
            // 
            // cbCCFocusRelative
            // 
            cbCCFocusRelative.AutoSize = true;
            cbCCFocusRelative.Location = new System.Drawing.Point(584, 378);
            cbCCFocusRelative.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCFocusRelative.Name = "cbCCFocusRelative";
            cbCCFocusRelative.Size = new System.Drawing.Size(98, 29);
            cbCCFocusRelative.TabIndex = 55;
            cbCCFocusRelative.Text = "Relative";
            cbCCFocusRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCFocusManual
            // 
            cbCCFocusManual.AutoSize = true;
            cbCCFocusManual.Location = new System.Drawing.Point(480, 378);
            cbCCFocusManual.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCFocusManual.Name = "cbCCFocusManual";
            cbCCFocusManual.Size = new System.Drawing.Size(96, 29);
            cbCCFocusManual.TabIndex = 54;
            cbCCFocusManual.Text = "Manual";
            cbCCFocusManual.UseVisualStyleBackColor = true;
            // 
            // cbCCFocusAuto
            // 
            cbCCFocusAuto.AutoSize = true;
            cbCCFocusAuto.Location = new System.Drawing.Point(400, 378);
            cbCCFocusAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCFocusAuto.Name = "cbCCFocusAuto";
            cbCCFocusAuto.Size = new System.Drawing.Size(77, 29);
            cbCCFocusAuto.TabIndex = 53;
            cbCCFocusAuto.Text = "Auto";
            cbCCFocusAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCFocusCurrent
            // 
            lbCCFocusCurrent.AutoSize = true;
            lbCCFocusCurrent.Location = new System.Drawing.Point(580, 332);
            lbCCFocusCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCFocusCurrent.Name = "lbCCFocusCurrent";
            lbCCFocusCurrent.Size = new System.Drawing.Size(112, 25);
            lbCCFocusCurrent.TabIndex = 52;
            lbCCFocusCurrent.Text = "Current = 40";
            // 
            // lbCCFocusMax
            // 
            lbCCFocusMax.AutoSize = true;
            lbCCFocusMax.Location = new System.Drawing.Point(476, 332);
            lbCCFocusMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCFocusMax.Name = "lbCCFocusMax";
            lbCCFocusMax.Size = new System.Drawing.Size(97, 25);
            lbCCFocusMax.TabIndex = 51;
            lbCCFocusMax.Text = "Max = 100";
            // 
            // lbCCFocusMin
            // 
            lbCCFocusMin.AutoSize = true;
            lbCCFocusMin.Location = new System.Drawing.Point(396, 332);
            lbCCFocusMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCFocusMin.Name = "lbCCFocusMin";
            lbCCFocusMin.Size = new System.Drawing.Size(74, 25);
            lbCCFocusMin.TabIndex = 50;
            lbCCFocusMin.Text = "Min = 1";
            // 
            // tbCCFocus
            // 
            tbCCFocus.BackColor = System.Drawing.SystemColors.Window;
            tbCCFocus.Location = new System.Drawing.Point(439, 282);
            tbCCFocus.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbCCFocus.Maximum = 100;
            tbCCFocus.Name = "tbCCFocus";
            tbCCFocus.Size = new System.Drawing.Size(264, 69);
            tbCCFocus.TabIndex = 49;
            tbCCFocus.TickStyle = System.Windows.Forms.TickStyle.None;
            tbCCFocus.Value = 50;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(380, 288);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 25);
            label4.TabIndex = 48;
            label4.Text = "Focus";
            // 
            // cbCCZoomRelative
            // 
            cbCCZoomRelative.AutoSize = true;
            cbCCZoomRelative.Location = new System.Drawing.Point(231, 378);
            cbCCZoomRelative.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCZoomRelative.Name = "cbCCZoomRelative";
            cbCCZoomRelative.Size = new System.Drawing.Size(98, 29);
            cbCCZoomRelative.TabIndex = 47;
            cbCCZoomRelative.Text = "Relative";
            cbCCZoomRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCZoomManual
            // 
            cbCCZoomManual.AutoSize = true;
            cbCCZoomManual.Location = new System.Drawing.Point(127, 378);
            cbCCZoomManual.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCZoomManual.Name = "cbCCZoomManual";
            cbCCZoomManual.Size = new System.Drawing.Size(96, 29);
            cbCCZoomManual.TabIndex = 46;
            cbCCZoomManual.Text = "Manual";
            cbCCZoomManual.UseVisualStyleBackColor = true;
            // 
            // cbCCZoomAuto
            // 
            cbCCZoomAuto.AutoSize = true;
            cbCCZoomAuto.Location = new System.Drawing.Point(47, 378);
            cbCCZoomAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCZoomAuto.Name = "cbCCZoomAuto";
            cbCCZoomAuto.Size = new System.Drawing.Size(77, 29);
            cbCCZoomAuto.TabIndex = 45;
            cbCCZoomAuto.Text = "Auto";
            cbCCZoomAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCZoomCurrent
            // 
            lbCCZoomCurrent.AutoSize = true;
            lbCCZoomCurrent.Location = new System.Drawing.Point(227, 332);
            lbCCZoomCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCZoomCurrent.Name = "lbCCZoomCurrent";
            lbCCZoomCurrent.Size = new System.Drawing.Size(112, 25);
            lbCCZoomCurrent.TabIndex = 44;
            lbCCZoomCurrent.Text = "Current = 40";
            // 
            // lbCCZoomMax
            // 
            lbCCZoomMax.AutoSize = true;
            lbCCZoomMax.Location = new System.Drawing.Point(121, 332);
            lbCCZoomMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCZoomMax.Name = "lbCCZoomMax";
            lbCCZoomMax.Size = new System.Drawing.Size(97, 25);
            lbCCZoomMax.TabIndex = 43;
            lbCCZoomMax.Text = "Max = 100";
            // 
            // lbCCZoomMin
            // 
            lbCCZoomMin.AutoSize = true;
            lbCCZoomMin.Location = new System.Drawing.Point(41, 332);
            lbCCZoomMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCZoomMin.Name = "lbCCZoomMin";
            lbCCZoomMin.Size = new System.Drawing.Size(74, 25);
            lbCCZoomMin.TabIndex = 42;
            lbCCZoomMin.Text = "Min = 1";
            // 
            // tbCCZoom
            // 
            tbCCZoom.BackColor = System.Drawing.SystemColors.Window;
            tbCCZoom.Location = new System.Drawing.Point(84, 282);
            tbCCZoom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbCCZoom.Maximum = 100;
            tbCCZoom.Name = "tbCCZoom";
            tbCCZoom.Size = new System.Drawing.Size(264, 69);
            tbCCZoom.TabIndex = 41;
            tbCCZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            tbCCZoom.Value = 50;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(27, 288);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(60, 25);
            label20.TabIndex = 40;
            label20.Text = "Zoom";
            // 
            // btCCTiltApply
            // 
            btCCTiltApply.Location = new System.Drawing.Point(400, 200);
            btCCTiltApply.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btCCTiltApply.Name = "btCCTiltApply";
            btCCTiltApply.Size = new System.Drawing.Size(124, 43);
            btCCTiltApply.TabIndex = 39;
            btCCTiltApply.Text = "Apply";
            btCCTiltApply.UseVisualStyleBackColor = true;
            btCCTiltApply.Click += (this.btCCTiltApply_Click);
            // 
            // btCCPanApply
            // 
            btCCPanApply.Location = new System.Drawing.Point(47, 200);
            btCCPanApply.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btCCPanApply.Name = "btCCPanApply";
            btCCPanApply.Size = new System.Drawing.Size(124, 43);
            btCCPanApply.TabIndex = 38;
            btCCPanApply.Text = "Apply";
            btCCPanApply.UseVisualStyleBackColor = true;
            btCCPanApply.Click += (this.btCCPanApply_Click);
            // 
            // cbCCTiltRelative
            // 
            cbCCTiltRelative.AutoSize = true;
            cbCCTiltRelative.Location = new System.Drawing.Point(584, 157);
            cbCCTiltRelative.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCTiltRelative.Name = "cbCCTiltRelative";
            cbCCTiltRelative.Size = new System.Drawing.Size(98, 29);
            cbCCTiltRelative.TabIndex = 37;
            cbCCTiltRelative.Text = "Relative";
            cbCCTiltRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCTiltManual
            // 
            cbCCTiltManual.AutoSize = true;
            cbCCTiltManual.Location = new System.Drawing.Point(480, 157);
            cbCCTiltManual.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCTiltManual.Name = "cbCCTiltManual";
            cbCCTiltManual.Size = new System.Drawing.Size(96, 29);
            cbCCTiltManual.TabIndex = 36;
            cbCCTiltManual.Text = "Manual";
            cbCCTiltManual.UseVisualStyleBackColor = true;
            // 
            // cbCCTiltAuto
            // 
            cbCCTiltAuto.AutoSize = true;
            cbCCTiltAuto.Location = new System.Drawing.Point(400, 157);
            cbCCTiltAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCTiltAuto.Name = "cbCCTiltAuto";
            cbCCTiltAuto.Size = new System.Drawing.Size(77, 29);
            cbCCTiltAuto.TabIndex = 35;
            cbCCTiltAuto.Text = "Auto";
            cbCCTiltAuto.UseVisualStyleBackColor = true;
            // 
            // lbCCTiltCurrent
            // 
            lbCCTiltCurrent.AutoSize = true;
            lbCCTiltCurrent.Location = new System.Drawing.Point(580, 110);
            lbCCTiltCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCTiltCurrent.Name = "lbCCTiltCurrent";
            lbCCTiltCurrent.Size = new System.Drawing.Size(112, 25);
            lbCCTiltCurrent.TabIndex = 34;
            lbCCTiltCurrent.Text = "Current = 40";
            // 
            // lbCCTiltMax
            // 
            lbCCTiltMax.AutoSize = true;
            lbCCTiltMax.Location = new System.Drawing.Point(476, 110);
            lbCCTiltMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCTiltMax.Name = "lbCCTiltMax";
            lbCCTiltMax.Size = new System.Drawing.Size(97, 25);
            lbCCTiltMax.TabIndex = 33;
            lbCCTiltMax.Text = "Max = 100";
            // 
            // lbCCTiltMin
            // 
            lbCCTiltMin.AutoSize = true;
            lbCCTiltMin.Location = new System.Drawing.Point(396, 110);
            lbCCTiltMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCTiltMin.Name = "lbCCTiltMin";
            lbCCTiltMin.Size = new System.Drawing.Size(74, 25);
            lbCCTiltMin.TabIndex = 32;
            lbCCTiltMin.Text = "Min = 1";
            // 
            // tbCCTilt
            // 
            tbCCTilt.BackColor = System.Drawing.SystemColors.Window;
            tbCCTilt.Location = new System.Drawing.Point(431, 58);
            tbCCTilt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbCCTilt.Maximum = 100;
            tbCCTilt.Name = "tbCCTilt";
            tbCCTilt.Size = new System.Drawing.Size(271, 69);
            tbCCTilt.TabIndex = 31;
            tbCCTilt.TickStyle = System.Windows.Forms.TickStyle.None;
            tbCCTilt.Value = 50;
            // 
            // label97
            // 
            label97.AutoSize = true;
            label97.Location = new System.Drawing.Point(380, 62);
            label97.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label97.Name = "label97";
            label97.Size = new System.Drawing.Size(35, 25);
            label97.TabIndex = 30;
            label97.Text = "Tilt";
            // 
            // cbCCPanRelative
            // 
            cbCCPanRelative.AutoSize = true;
            cbCCPanRelative.Location = new System.Drawing.Point(231, 157);
            cbCCPanRelative.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCPanRelative.Name = "cbCCPanRelative";
            cbCCPanRelative.Size = new System.Drawing.Size(98, 29);
            cbCCPanRelative.TabIndex = 29;
            cbCCPanRelative.Text = "Relative";
            cbCCPanRelative.UseVisualStyleBackColor = true;
            // 
            // cbCCPanManual
            // 
            cbCCPanManual.AutoSize = true;
            cbCCPanManual.Location = new System.Drawing.Point(127, 157);
            cbCCPanManual.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCPanManual.Name = "cbCCPanManual";
            cbCCPanManual.Size = new System.Drawing.Size(96, 29);
            cbCCPanManual.TabIndex = 28;
            cbCCPanManual.Text = "Manual";
            cbCCPanManual.UseVisualStyleBackColor = true;
            // 
            // cbCCPanAuto
            // 
            cbCCPanAuto.AutoSize = true;
            cbCCPanAuto.Location = new System.Drawing.Point(47, 157);
            cbCCPanAuto.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCCPanAuto.Name = "cbCCPanAuto";
            cbCCPanAuto.Size = new System.Drawing.Size(77, 29);
            cbCCPanAuto.TabIndex = 27;
            cbCCPanAuto.Text = "Auto";
            cbCCPanAuto.UseVisualStyleBackColor = true;
            // 
            // btCCReadValues
            // 
            btCCReadValues.AccessibleDescription = "";
            btCCReadValues.Location = new System.Drawing.Point(584, 12);
            btCCReadValues.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btCCReadValues.Name = "btCCReadValues";
            btCCReadValues.Size = new System.Drawing.Size(151, 43);
            btCCReadValues.TabIndex = 26;
            btCCReadValues.Text = "Read values";
            btCCReadValues.UseVisualStyleBackColor = true;
            btCCReadValues.Click += (this.btCCReadValues_Click);
            // 
            // lbCCPanCurrent
            // 
            lbCCPanCurrent.AutoSize = true;
            lbCCPanCurrent.Location = new System.Drawing.Point(227, 110);
            lbCCPanCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCPanCurrent.Name = "lbCCPanCurrent";
            lbCCPanCurrent.Size = new System.Drawing.Size(112, 25);
            lbCCPanCurrent.TabIndex = 23;
            lbCCPanCurrent.Text = "Current = 40";
            // 
            // lbCCPanMax
            // 
            lbCCPanMax.AutoSize = true;
            lbCCPanMax.Location = new System.Drawing.Point(121, 110);
            lbCCPanMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCPanMax.Name = "lbCCPanMax";
            lbCCPanMax.Size = new System.Drawing.Size(97, 25);
            lbCCPanMax.TabIndex = 22;
            lbCCPanMax.Text = "Max = 100";
            // 
            // lbCCPanMin
            // 
            lbCCPanMin.AutoSize = true;
            lbCCPanMin.Location = new System.Drawing.Point(41, 110);
            lbCCPanMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbCCPanMin.Name = "lbCCPanMin";
            lbCCPanMin.Size = new System.Drawing.Size(74, 25);
            lbCCPanMin.TabIndex = 21;
            lbCCPanMin.Text = "Min = 1";
            // 
            // tbCCPan
            // 
            tbCCPan.BackColor = System.Drawing.SystemColors.Window;
            tbCCPan.Location = new System.Drawing.Point(84, 58);
            tbCCPan.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbCCPan.Maximum = 100;
            tbCCPan.Name = "tbCCPan";
            tbCCPan.Size = new System.Drawing.Size(264, 69);
            tbCCPan.TabIndex = 20;
            tbCCPan.TickStyle = System.Windows.Forms.TickStyle.None;
            tbCCPan.Value = 50;
            // 
            // label96
            // 
            label96.AutoSize = true;
            label96.Location = new System.Drawing.Point(27, 62);
            label96.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label96.Name = "label96";
            label96.Size = new System.Drawing.Size(40, 25);
            label96.TabIndex = 19;
            label96.Text = "Pan";
            // 
            // tabPage63
            // 
            tabPage63.Controls.Add(tabControl19);
            tabPage63.Location = new System.Drawing.Point(4, 34);
            tabPage63.Name = "tabPage63";
            tabPage63.Padding = new System.Windows.Forms.Padding(3);
            tabPage63.Size = new System.Drawing.Size(765, 547);
            tabPage63.TabIndex = 9;
            tabPage63.Text = "Audio input / output";
            tabPage63.UseVisualStyleBackColor = true;
            // 
            // tabControl19
            // 
            tabControl19.Controls.Add(tabPage96);
            tabControl19.Controls.Add(tabPage97);
            tabControl19.Controls.Add(tabPage98);
            tabControl19.Controls.Add(tabPage112);
            tabControl19.Controls.Add(tabPage99);
            tabControl19.Location = new System.Drawing.Point(7, 12);
            tabControl19.Name = "tabControl19";
            tabControl19.SelectedIndex = 0;
            tabControl19.Size = new System.Drawing.Size(759, 532);
            tabControl19.TabIndex = 0;
            // 
            // tabPage96
            // 
            tabPage96.Controls.Add(cbUseBestAudioInputFormat);
            tabPage96.Controls.Add(btAudioInputDeviceSettings);
            tabPage96.Controls.Add(cbAudioInputLine);
            tabPage96.Controls.Add(cbAudioInputFormat);
            tabPage96.Controls.Add(cbAudioInputDevice);
            tabPage96.Controls.Add(label14);
            tabPage96.Controls.Add(label12);
            tabPage96.Controls.Add(label10);
            tabPage96.Location = new System.Drawing.Point(4, 34);
            tabPage96.Name = "tabPage96";
            tabPage96.Padding = new System.Windows.Forms.Padding(3);
            tabPage96.Size = new System.Drawing.Size(751, 494);
            tabPage96.TabIndex = 0;
            tabPage96.Text = "Main audio input";
            tabPage96.UseVisualStyleBackColor = true;
            // 
            // cbUseBestAudioInputFormat
            // 
            cbUseBestAudioInputFormat.AutoSize = true;
            cbUseBestAudioInputFormat.Location = new System.Drawing.Point(597, 122);
            cbUseBestAudioInputFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            cbUseBestAudioInputFormat.Size = new System.Drawing.Size(106, 29);
            cbUseBestAudioInputFormat.TabIndex = 93;
            cbUseBestAudioInputFormat.Text = "Use best";
            cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            cbUseBestAudioInputFormat.CheckedChanged += (this.cbUseBestAudioInputFormat_CheckedChanged);
            // 
            // btAudioInputDeviceSettings
            // 
            btAudioInputDeviceSettings.Location = new System.Drawing.Point(621, 62);
            btAudioInputDeviceSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            btAudioInputDeviceSettings.Size = new System.Drawing.Size(90, 43);
            btAudioInputDeviceSettings.TabIndex = 91;
            btAudioInputDeviceSettings.Text = "Settings";
            btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            btAudioInputDeviceSettings.Click += (this.btAudioInputDeviceSettings_Click);
            // 
            // cbAudioInputLine
            // 
            cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputLine.FormattingEnabled = true;
            cbAudioInputLine.Location = new System.Drawing.Point(36, 157);
            cbAudioInputLine.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioInputLine.Name = "cbAudioInputLine";
            cbAudioInputLine.Size = new System.Drawing.Size(314, 33);
            cbAudioInputLine.TabIndex = 88;
            // 
            // cbAudioInputFormat
            // 
            cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputFormat.FormattingEnabled = true;
            cbAudioInputFormat.Location = new System.Drawing.Point(396, 157);
            cbAudioInputFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioInputFormat.Name = "cbAudioInputFormat";
            cbAudioInputFormat.Size = new System.Drawing.Size(314, 33);
            cbAudioInputFormat.TabIndex = 87;
            // 
            // cbAudioInputDevice
            // 
            cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputDevice.FormattingEnabled = true;
            cbAudioInputDevice.Location = new System.Drawing.Point(36, 62);
            cbAudioInputDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioInputDevice.Name = "cbAudioInputDevice";
            cbAudioInputDevice.Size = new System.Drawing.Size(574, 33);
            cbAudioInputDevice.TabIndex = 86;
            cbAudioInputDevice.SelectedIndexChanged += (this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(30, 125);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(86, 25);
            label14.TabIndex = 85;
            label14.Text = "Input line";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(30, 28);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(109, 25);
            label12.TabIndex = 84;
            label12.Text = "Input device";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(390, 125);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(113, 25);
            label10.TabIndex = 83;
            label10.Text = "Input format";
            // 
            // tabPage97
            // 
            tabPage97.Controls.Add(label55);
            tabPage97.Controls.Add(tbAudioBalance);
            tabPage97.Controls.Add(label54);
            tabPage97.Controls.Add(tbAudioVolume);
            tabPage97.Controls.Add(cbPlayAudio);
            tabPage97.Controls.Add(cbAudioOutputDevice);
            tabPage97.Controls.Add(label15);
            tabPage97.Location = new System.Drawing.Point(4, 34);
            tabPage97.Name = "tabPage97";
            tabPage97.Padding = new System.Windows.Forms.Padding(3);
            tabPage97.Size = new System.Drawing.Size(751, 494);
            tabPage97.TabIndex = 1;
            tabPage97.Text = "Audio output";
            tabPage97.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new System.Drawing.Point(563, 38);
            label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(71, 25);
            label55.TabIndex = 105;
            label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            tbAudioBalance.BackColor = System.Drawing.SystemColors.Window;
            tbAudioBalance.Location = new System.Drawing.Point(567, 68);
            tbAudioBalance.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioBalance.Maximum = 100;
            tbAudioBalance.Minimum = -100;
            tbAudioBalance.Name = "tbAudioBalance";
            tbAudioBalance.Size = new System.Drawing.Size(137, 69);
            tbAudioBalance.TabIndex = 104;
            tbAudioBalance.TickFrequency = 5;
            tbAudioBalance.Scroll += (this.tbAudioBalance_Scroll);
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new System.Drawing.Point(383, 38);
            label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label54.Name = "label54";
            label54.Size = new System.Drawing.Size(72, 25);
            label54.TabIndex = 103;
            label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            tbAudioVolume.BackColor = System.Drawing.SystemColors.Window;
            tbAudioVolume.Location = new System.Drawing.Point(384, 68);
            tbAudioVolume.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbAudioVolume.Maximum = 100;
            tbAudioVolume.Name = "tbAudioVolume";
            tbAudioVolume.Size = new System.Drawing.Size(137, 69);
            tbAudioVolume.TabIndex = 102;
            tbAudioVolume.TickFrequency = 10;
            tbAudioVolume.Value = 80;
            tbAudioVolume.Scroll += (this.tbAudioVolume_Scroll);
            // 
            // cbPlayAudio
            // 
            cbPlayAudio.AutoSize = true;
            cbPlayAudio.Checked = true;
            cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            cbPlayAudio.Location = new System.Drawing.Point(219, 38);
            cbPlayAudio.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPlayAudio.Name = "cbPlayAudio";
            cbPlayAudio.Size = new System.Drawing.Size(120, 29);
            cbPlayAudio.TabIndex = 101;
            cbPlayAudio.Text = "Play audio";
            cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutputDevice.FormattingEnabled = true;
            cbAudioOutputDevice.Location = new System.Drawing.Point(27, 72);
            cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            cbAudioOutputDevice.Size = new System.Drawing.Size(314, 33);
            cbAudioOutputDevice.TabIndex = 100;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(23, 38);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(124, 25);
            label15.TabIndex = 99;
            label15.Text = "Output device";
            // 
            // tabPage98
            // 
            tabPage98.Controls.Add(cbVUMeter);
            tabPage98.Controls.Add(peakMeterCtrl1);
            tabPage98.Location = new System.Drawing.Point(4, 34);
            tabPage98.Name = "tabPage98";
            tabPage98.Padding = new System.Windows.Forms.Padding(3);
            tabPage98.Size = new System.Drawing.Size(751, 494);
            tabPage98.TabIndex = 2;
            tabPage98.Text = "VU meter";
            tabPage98.UseVisualStyleBackColor = true;
            // 
            // cbVUMeter
            // 
            cbVUMeter.AutoSize = true;
            cbVUMeter.Location = new System.Drawing.Point(21, 32);
            cbVUMeter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVUMeter.Name = "cbVUMeter";
            cbVUMeter.Size = new System.Drawing.Size(169, 29);
            cbVUMeter.TabIndex = 101;
            cbVUMeter.Text = "Enable VU Meter";
            cbVUMeter.UseVisualStyleBackColor = true;
            // 
            // peakMeterCtrl1
            // 
            peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)150, (int)(byte)150);
            peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow;
            peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)150);
            peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green;
            peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb((int)(byte)150, (int)(byte)255, (int)(byte)150);
            peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb((int)(byte)180, (int)(byte)180, (int)(byte)180);
            peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro;
            peakMeterCtrl1.Location = new System.Drawing.Point(213, 22);
            peakMeterCtrl1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            peakMeterCtrl1.Name = "peakMeterCtrl1";
            peakMeterCtrl1.Size = new System.Drawing.Size(176, 118);
            peakMeterCtrl1.TabIndex = 102;
            peakMeterCtrl1.Text = "peakMeterCtrl1";
            // 
            // tabPage112
            // 
            tabPage112.Controls.Add(tbVUMeterBoost);
            tabPage112.Controls.Add(label382);
            tabPage112.Controls.Add(label381);
            tabPage112.Controls.Add(tbVUMeterAmplification);
            tabPage112.Controls.Add(cbVUMeterPro);
            tabPage112.Controls.Add(waveformPainter2);
            tabPage112.Controls.Add(waveformPainter1);
            tabPage112.Controls.Add(volumeMeter2);
            tabPage112.Controls.Add(volumeMeter1);
            tabPage112.Location = new System.Drawing.Point(4, 34);
            tabPage112.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage112.Name = "tabPage112";
            tabPage112.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage112.Size = new System.Drawing.Size(751, 494);
            tabPage112.TabIndex = 4;
            tabPage112.Text = "VU meter Pro";
            tabPage112.UseVisualStyleBackColor = true;
            // 
            // tbVUMeterBoost
            // 
            tbVUMeterBoost.Location = new System.Drawing.Point(287, 362);
            tbVUMeterBoost.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbVUMeterBoost.Maximum = 30;
            tbVUMeterBoost.Minimum = 1;
            tbVUMeterBoost.Name = "tbVUMeterBoost";
            tbVUMeterBoost.Size = new System.Drawing.Size(173, 69);
            tbVUMeterBoost.TabIndex = 115;
            tbVUMeterBoost.Value = 10;
            tbVUMeterBoost.Scroll += (this.tbVUMeterBoost_Scroll);
            // 
            // label382
            // 
            label382.AutoSize = true;
            label382.Location = new System.Drawing.Point(281, 332);
            label382.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label382.Name = "label382";
            label382.Size = new System.Drawing.Size(118, 25);
            label382.TabIndex = 114;
            label382.Text = "Meters boost";
            // 
            // label381
            // 
            label381.AutoSize = true;
            label381.Location = new System.Drawing.Point(36, 332);
            label381.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label381.Name = "label381";
            label381.Size = new System.Drawing.Size(209, 25);
            label381.TabIndex = 110;
            label381.Text = "Volume amplification (%)";
            // 
            // tbVUMeterAmplification
            // 
            tbVUMeterAmplification.Location = new System.Drawing.Point(40, 362);
            tbVUMeterAmplification.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbVUMeterAmplification.Maximum = 100;
            tbVUMeterAmplification.Name = "tbVUMeterAmplification";
            tbVUMeterAmplification.Size = new System.Drawing.Size(176, 69);
            tbVUMeterAmplification.TabIndex = 109;
            tbVUMeterAmplification.Value = 100;
            tbVUMeterAmplification.Scroll += (this.tbVUMeterAmplification_Scroll);
            // 
            // cbVUMeterPro
            // 
            cbVUMeterPro.AutoSize = true;
            cbVUMeterPro.Location = new System.Drawing.Point(21, 32);
            cbVUMeterPro.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVUMeterPro.Name = "cbVUMeterPro";
            cbVUMeterPro.Size = new System.Drawing.Size(201, 29);
            cbVUMeterPro.TabIndex = 108;
            cbVUMeterPro.Text = "Enable VU meter Pro";
            cbVUMeterPro.UseVisualStyleBackColor = true;
            // 
            // waveformPainter2
            // 
            waveformPainter2.Boost = 1F;
            waveformPainter2.Location = new System.Drawing.Point(170, 203);
            waveformPainter2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            waveformPainter2.Name = "waveformPainter2";
            waveformPainter2.Size = new System.Drawing.Size(450, 115);
            waveformPainter2.TabIndex = 113;
            waveformPainter2.Text = "waveformPainter2";
            // 
            // waveformPainter1
            // 
            waveformPainter1.Boost = 1F;
            waveformPainter1.Location = new System.Drawing.Point(170, 78);
            waveformPainter1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            waveformPainter1.Name = "waveformPainter1";
            waveformPainter1.Size = new System.Drawing.Size(450, 115);
            waveformPainter1.TabIndex = 112;
            waveformPainter1.Text = "waveformPainter1";
            // 
            // volumeMeter2
            // 
            volumeMeter2.Amplitude = 0F;
            volumeMeter2.BackColor = System.Drawing.Color.LightGray;
            volumeMeter2.Boost = 1F;
            volumeMeter2.Location = new System.Drawing.Point(87, 78);
            volumeMeter2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            volumeMeter2.MaxDb = 18F;
            volumeMeter2.MinDb = -60F;
            volumeMeter2.Name = "volumeMeter2";
            volumeMeter2.Size = new System.Drawing.Size(37, 242);
            volumeMeter2.TabIndex = 111;
            // 
            // volumeMeter1
            // 
            volumeMeter1.Amplitude = 0F;
            volumeMeter1.BackColor = System.Drawing.Color.LightGray;
            volumeMeter1.Boost = 1F;
            volumeMeter1.Location = new System.Drawing.Point(40, 78);
            volumeMeter1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            volumeMeter1.MaxDb = 18F;
            volumeMeter1.MinDb = -60F;
            volumeMeter1.Name = "volumeMeter1";
            volumeMeter1.Size = new System.Drawing.Size(37, 242);
            volumeMeter1.TabIndex = 107;
            // 
            // tabPage99
            // 
            tabPage99.Controls.Add(rbAddAudioStreamsIndependent);
            tabPage99.Controls.Add(rbAddAudioStreamsMix);
            tabPage99.Controls.Add(label319);
            tabPage99.Controls.Add(label318);
            tabPage99.Controls.Add(btAddAdditionalAudioSource);
            tabPage99.Controls.Add(cbAdditionalAudioSource);
            tabPage99.Controls.Add(label180);
            tabPage99.Location = new System.Drawing.Point(4, 34);
            tabPage99.Name = "tabPage99";
            tabPage99.Padding = new System.Windows.Forms.Padding(3);
            tabPage99.Size = new System.Drawing.Size(751, 494);
            tabPage99.TabIndex = 3;
            tabPage99.Text = "Additional audio inputs";
            tabPage99.UseVisualStyleBackColor = true;
            // 
            // rbAddAudioStreamsIndependent
            // 
            rbAddAudioStreamsIndependent.AutoSize = true;
            rbAddAudioStreamsIndependent.Location = new System.Drawing.Point(24, 162);
            rbAddAudioStreamsIndependent.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbAddAudioStreamsIndependent.Name = "rbAddAudioStreamsIndependent";
            rbAddAudioStreamsIndependent.Size = new System.Drawing.Size(205, 29);
            rbAddAudioStreamsIndependent.TabIndex = 93;
            rbAddAudioStreamsIndependent.Text = "Independent streams";
            rbAddAudioStreamsIndependent.UseVisualStyleBackColor = true;
            // 
            // rbAddAudioStreamsMix
            // 
            rbAddAudioStreamsMix.AutoSize = true;
            rbAddAudioStreamsMix.Checked = true;
            rbAddAudioStreamsMix.Location = new System.Drawing.Point(24, 118);
            rbAddAudioStreamsMix.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbAddAudioStreamsMix.Name = "rbAddAudioStreamsMix";
            rbAddAudioStreamsMix.Size = new System.Drawing.Size(510, 29);
            rbAddAudioStreamsMix.TabIndex = 92;
            rbAddAudioStreamsMix.TabStop = true;
            rbAddAudioStreamsMix.Text = "Mix into one stream (one additional stream only supported)";
            rbAddAudioStreamsMix.UseVisualStyleBackColor = true;
            // 
            // label319
            // 
            label319.AutoSize = true;
            label319.Location = new System.Drawing.Point(70, 258);
            label319.Name = "label319";
            label319.Size = new System.Drawing.Size(501, 25);
            label319.TabIndex = 91;
            label319.Text = "Please contact support if additional formats support required.";
            // 
            // label318
            // 
            label318.AutoSize = true;
            label318.Location = new System.Drawing.Point(70, 222);
            label318.Name = "label318";
            label318.Size = new System.Drawing.Size(457, 25);
            label318.TabIndex = 90;
            label318.Text = "Currently AVI and WMV with a special profile supported.";
            // 
            // btAddAdditionalAudioSource
            // 
            btAddAdditionalAudioSource.Location = new System.Drawing.Point(610, 62);
            btAddAdditionalAudioSource.Name = "btAddAdditionalAudioSource";
            btAddAdditionalAudioSource.Size = new System.Drawing.Size(93, 43);
            btAddAdditionalAudioSource.TabIndex = 89;
            btAddAdditionalAudioSource.Text = "Add";
            btAddAdditionalAudioSource.UseVisualStyleBackColor = true;
            btAddAdditionalAudioSource.Click += (this.btAddAdditionalAudioSource_Click);
            // 
            // cbAdditionalAudioSource
            // 
            cbAdditionalAudioSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAdditionalAudioSource.FormattingEnabled = true;
            cbAdditionalAudioSource.Location = new System.Drawing.Point(24, 62);
            cbAdditionalAudioSource.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbAdditionalAudioSource.Name = "cbAdditionalAudioSource";
            cbAdditionalAudioSource.Size = new System.Drawing.Size(574, 33);
            cbAdditionalAudioSource.TabIndex = 88;
            // 
            // label180
            // 
            label180.AutoSize = true;
            label180.Location = new System.Drawing.Point(20, 28);
            label180.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label180.Name = "label180";
            label180.Size = new System.Drawing.Size(109, 25);
            label180.TabIndex = 87;
            label180.Text = "Input device";
            // 
            // tabPage47
            // 
            tabPage47.Controls.Add(cbScreenCapture_HighlightMouseCursor);
            tabPage47.Controls.Add(label3);
            tabPage47.Controls.Add(textBox1);
            tabPage47.Controls.Add(lbScreenSourceWindowText);
            tabPage47.Controls.Add(btScreenSourceWindowSelect);
            tabPage47.Controls.Add(cbScreenCapture_DesktopDuplication);
            tabPage47.Controls.Add(rbScreenCaptureColorSource);
            tabPage47.Controls.Add(rbScreenCaptureWindow);
            tabPage47.Controls.Add(cbScreenCaptureDisplayIndex);
            tabPage47.Controls.Add(label93);
            tabPage47.Controls.Add(btScreenCaptureUpdate);
            tabPage47.Controls.Add(cbScreenCapture_GrabMouseCursor);
            tabPage47.Controls.Add(label79);
            tabPage47.Controls.Add(edScreenFrameRate);
            tabPage47.Controls.Add(label43);
            tabPage47.Controls.Add(edScreenBottom);
            tabPage47.Controls.Add(label42);
            tabPage47.Controls.Add(edScreenRight);
            tabPage47.Controls.Add(label40);
            tabPage47.Controls.Add(edScreenTop);
            tabPage47.Controls.Add(label26);
            tabPage47.Controls.Add(edScreenLeft);
            tabPage47.Controls.Add(label24);
            tabPage47.Controls.Add(rbScreenCustomArea);
            tabPage47.Controls.Add(rbScreenFullScreen);
            tabPage47.Location = new System.Drawing.Point(4, 34);
            tabPage47.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage47.Name = "tabPage47";
            tabPage47.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage47.Size = new System.Drawing.Size(765, 547);
            tabPage47.TabIndex = 1;
            tabPage47.Text = "Screen source";
            tabPage47.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(441, 393);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(315, 25);
            label3.TabIndex = 58;
            label3.Text = "(You can capture background window)";
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.White;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Location = new System.Drawing.Point(451, 28);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(279, 112);
            textBox1.TabIndex = 57;
            textBox1.Text = "You can update left/top position and mouse cursor capturing on-the-fly";
            // 
            // lbScreenSourceWindowText
            // 
            lbScreenSourceWindowText.AutoSize = true;
            lbScreenSourceWindowText.Location = new System.Drawing.Point(477, 362);
            lbScreenSourceWindowText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbScreenSourceWindowText.Name = "lbScreenSourceWindowText";
            lbScreenSourceWindowText.Size = new System.Drawing.Size(179, 25);
            lbScreenSourceWindowText.TabIndex = 56;
            lbScreenSourceWindowText.Text = "(no window selected)";
            // 
            // btScreenSourceWindowSelect
            // 
            btScreenSourceWindowSelect.Location = new System.Drawing.Point(649, 298);
            btScreenSourceWindowSelect.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect";
            btScreenSourceWindowSelect.Size = new System.Drawing.Size(81, 43);
            btScreenSourceWindowSelect.TabIndex = 55;
            btScreenSourceWindowSelect.Text = "Select";
            btScreenSourceWindowSelect.UseVisualStyleBackColor = true;
            btScreenSourceWindowSelect.Click += (this.btScreenSourceWindowSelect_Click);
            // 
            // cbScreenCapture_DesktopDuplication
            // 
            cbScreenCapture_DesktopDuplication.AutoSize = true;
            cbScreenCapture_DesktopDuplication.Location = new System.Drawing.Point(31, 504);
            cbScreenCapture_DesktopDuplication.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication";
            cbScreenCapture_DesktopDuplication.Size = new System.Drawing.Size(301, 29);
            cbScreenCapture_DesktopDuplication.TabIndex = 54;
            cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage";
            cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true;
            // 
            // rbScreenCaptureColorSource
            // 
            rbScreenCaptureColorSource.AutoSize = true;
            rbScreenCaptureColorSource.Location = new System.Drawing.Point(451, 475);
            rbScreenCaptureColorSource.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbScreenCaptureColorSource.Name = "rbScreenCaptureColorSource";
            rbScreenCaptureColorSource.Size = new System.Drawing.Size(122, 29);
            rbScreenCaptureColorSource.TabIndex = 53;
            rbScreenCaptureColorSource.TabStop = true;
            rbScreenCaptureColorSource.Text = "Black color";
            rbScreenCaptureColorSource.UseVisualStyleBackColor = true;
            // 
            // rbScreenCaptureWindow
            // 
            rbScreenCaptureWindow.AutoSize = true;
            rbScreenCaptureWindow.Location = new System.Drawing.Point(451, 303);
            rbScreenCaptureWindow.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbScreenCaptureWindow.Name = "rbScreenCaptureWindow";
            rbScreenCaptureWindow.Size = new System.Drawing.Size(166, 29);
            rbScreenCaptureWindow.TabIndex = 50;
            rbScreenCaptureWindow.TabStop = true;
            rbScreenCaptureWindow.Text = "Capture window";
            rbScreenCaptureWindow.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptureDisplayIndex
            // 
            cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbScreenCaptureDisplayIndex.FormattingEnabled = true;
            cbScreenCaptureDisplayIndex.Location = new System.Drawing.Point(147, 357);
            cbScreenCaptureDisplayIndex.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex";
            cbScreenCaptureDisplayIndex.Size = new System.Drawing.Size(71, 33);
            cbScreenCaptureDisplayIndex.TabIndex = 49;
            // 
            // label93
            // 
            label93.AutoSize = true;
            label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label93.Location = new System.Drawing.Point(27, 362);
            label93.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label93.Name = "label93";
            label93.Size = new System.Drawing.Size(97, 20);
            label93.TabIndex = 48;
            label93.Text = "Display ID";
            // 
            // btScreenCaptureUpdate
            // 
            btScreenCaptureUpdate.Location = new System.Drawing.Point(530, 182);
            btScreenCaptureUpdate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btScreenCaptureUpdate.Name = "btScreenCaptureUpdate";
            btScreenCaptureUpdate.Size = new System.Drawing.Size(124, 43);
            btScreenCaptureUpdate.TabIndex = 47;
            btScreenCaptureUpdate.Text = "Update";
            btScreenCaptureUpdate.UseVisualStyleBackColor = true;
            btScreenCaptureUpdate.Click += (this.btScreenCaptureUpdate_Click);
            // 
            // cbScreenCapture_GrabMouseCursor
            // 
            cbScreenCapture_GrabMouseCursor.AutoSize = true;
            cbScreenCapture_GrabMouseCursor.Location = new System.Drawing.Point(31, 418);
            cbScreenCapture_GrabMouseCursor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor";
            cbScreenCapture_GrabMouseCursor.Size = new System.Drawing.Size(213, 29);
            cbScreenCapture_GrabMouseCursor.TabIndex = 43;
            cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor";
            cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true;
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Location = new System.Drawing.Point(229, 308);
            label79.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(37, 25);
            label79.TabIndex = 42;
            label79.Text = "fps";
            // 
            // edScreenFrameRate
            // 
            edScreenFrameRate.Location = new System.Drawing.Point(147, 302);
            edScreenFrameRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edScreenFrameRate.Name = "edScreenFrameRate";
            edScreenFrameRate.Size = new System.Drawing.Size(71, 31);
            edScreenFrameRate.TabIndex = 41;
            edScreenFrameRate.Text = "5";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label43.Location = new System.Drawing.Point(27, 308);
            label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(101, 20);
            label43.TabIndex = 40;
            label43.Text = "Frame rate";
            // 
            // edScreenBottom
            // 
            edScreenBottom.Location = new System.Drawing.Point(340, 228);
            edScreenBottom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edScreenBottom.Name = "edScreenBottom";
            edScreenBottom.Size = new System.Drawing.Size(71, 31);
            edScreenBottom.TabIndex = 39;
            edScreenBottom.Text = "480";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(269, 235);
            label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(72, 25);
            label42.TabIndex = 38;
            label42.Text = "Bottom";
            // 
            // edScreenRight
            // 
            edScreenRight.Location = new System.Drawing.Point(147, 228);
            edScreenRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edScreenRight.Name = "edScreenRight";
            edScreenRight.Size = new System.Drawing.Size(71, 31);
            edScreenRight.TabIndex = 37;
            edScreenRight.Text = "640";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(79, 235);
            label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(54, 25);
            label40.TabIndex = 36;
            label40.Text = "Right";
            // 
            // edScreenTop
            // 
            edScreenTop.Location = new System.Drawing.Point(340, 152);
            edScreenTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edScreenTop.Name = "edScreenTop";
            edScreenTop.Size = new System.Drawing.Size(71, 31);
            edScreenTop.TabIndex = 35;
            edScreenTop.Text = "0";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label26.Location = new System.Drawing.Point(269, 158);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(40, 20);
            label26.TabIndex = 34;
            label26.Text = "Top";
            // 
            // edScreenLeft
            // 
            edScreenLeft.Location = new System.Drawing.Point(147, 152);
            edScreenLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edScreenLeft.Name = "edScreenLeft";
            edScreenLeft.Size = new System.Drawing.Size(71, 31);
            edScreenLeft.TabIndex = 33;
            edScreenLeft.Text = "0";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label24.Location = new System.Drawing.Point(79, 158);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(42, 20);
            label24.TabIndex = 32;
            label24.Text = "Left";
            // 
            // rbScreenCustomArea
            // 
            rbScreenCustomArea.AutoSize = true;
            rbScreenCustomArea.Location = new System.Drawing.Point(31, 78);
            rbScreenCustomArea.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbScreenCustomArea.Name = "rbScreenCustomArea";
            rbScreenCustomArea.Size = new System.Drawing.Size(137, 29);
            rbScreenCustomArea.TabIndex = 31;
            rbScreenCustomArea.Text = "Custom area";
            rbScreenCustomArea.UseVisualStyleBackColor = true;
            // 
            // rbScreenFullScreen
            // 
            rbScreenFullScreen.AutoSize = true;
            rbScreenFullScreen.Checked = true;
            rbScreenFullScreen.Location = new System.Drawing.Point(31, 32);
            rbScreenFullScreen.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbScreenFullScreen.Name = "rbScreenFullScreen";
            rbScreenFullScreen.Size = new System.Drawing.Size(119, 29);
            rbScreenFullScreen.TabIndex = 30;
            rbScreenFullScreen.TabStop = true;
            rbScreenFullScreen.Text = "Full screen";
            rbScreenFullScreen.UseVisualStyleBackColor = true;
            // 
            // tabPage48
            // 
            tabPage48.Controls.Add(tabControl15);
            tabPage48.Location = new System.Drawing.Point(4, 34);
            tabPage48.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage48.Name = "tabPage48";
            tabPage48.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage48.Size = new System.Drawing.Size(765, 547);
            tabPage48.TabIndex = 2;
            tabPage48.Text = "IP camera / Network stream";
            tabPage48.UseVisualStyleBackColor = true;
            // 
            // tabControl15
            // 
            tabControl15.Controls.Add(tabPage144);
            tabControl15.Controls.Add(tabPage146);
            tabControl15.Controls.Add(tabPage145);
            tabControl15.Location = new System.Drawing.Point(10, 12);
            tabControl15.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl15.Name = "tabControl15";
            tabControl15.SelectedIndex = 0;
            tabControl15.Size = new System.Drawing.Size(744, 525);
            tabControl15.TabIndex = 62;
            // 
            // tabPage144
            // 
            tabPage144.Controls.Add(btListONVIFSources);
            tabPage144.Controls.Add(cbIPURL);
            tabPage144.Controls.Add(btListNDISources);
            tabPage144.Controls.Add(lbNDI);
            tabPage144.Controls.Add(label25);
            tabPage144.Controls.Add(label165);
            tabPage144.Controls.Add(cbIPCameraONVIF);
            tabPage144.Controls.Add(cbIPDisconnect);
            tabPage144.Controls.Add(edIPForcedFramerateID);
            tabPage144.Controls.Add(label344);
            tabPage144.Controls.Add(edIPForcedFramerate);
            tabPage144.Controls.Add(label295);
            tabPage144.Controls.Add(cbIPCameraType);
            tabPage144.Controls.Add(edIPPassword);
            tabPage144.Controls.Add(label167);
            tabPage144.Controls.Add(edIPLogin);
            tabPage144.Controls.Add(label166);
            tabPage144.Controls.Add(cbIPAudioCapture);
            tabPage144.Controls.Add(label168);
            tabPage144.Location = new System.Drawing.Point(4, 34);
            tabPage144.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage144.Name = "tabPage144";
            tabPage144.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage144.Size = new System.Drawing.Size(736, 487);
            tabPage144.TabIndex = 0;
            tabPage144.Text = "Main";
            tabPage144.UseVisualStyleBackColor = true;
            // 
            // btListONVIFSources
            // 
            btListONVIFSources.Location = new System.Drawing.Point(240, 418);
            btListONVIFSources.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btListONVIFSources.Name = "btListONVIFSources";
            btListONVIFSources.Size = new System.Drawing.Size(204, 43);
            btListONVIFSources.TabIndex = 90;
            btListONVIFSources.Text = "List ONVIF sources";
            btListONVIFSources.UseVisualStyleBackColor = true;
            btListONVIFSources.Click += (this.btListONVIFSources_Click);
            // 
            // cbIPURL
            // 
            cbIPURL.FormattingEnabled = true;
            cbIPURL.Location = new System.Drawing.Point(91, 28);
            cbIPURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbIPURL.Name = "cbIPURL";
            cbIPURL.Size = new System.Drawing.Size(620, 33);
            cbIPURL.TabIndex = 89;
            cbIPURL.Text = "http://192.168.1.64/onvif/device_service";
            // 
            // btListNDISources
            // 
            btListNDISources.Location = new System.Drawing.Point(21, 418);
            btListNDISources.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btListNDISources.Name = "btListNDISources";
            btListNDISources.Size = new System.Drawing.Size(204, 43);
            btListNDISources.TabIndex = 88;
            btListNDISources.Text = "List NDI sources";
            btListNDISources.UseVisualStyleBackColor = true;
            btListNDISources.Click += (this.btListNDISources_Click);
            // 
            // lbNDI
            // 
            lbNDI.AutoSize = true;
            lbNDI.Location = new System.Drawing.Point(431, 372);
            lbNDI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbNDI.Name = "lbNDI";
            lbNDI.Size = new System.Drawing.Size(145, 25);
            lbNDI.TabIndex = 87;
            lbNDI.TabStop = true;
            lbNDI.Text = "vendor's website";
            lbNDI.LinkClicked += (this.lbNDI_LinkClicked);
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(17, 372);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(428, 25);
            label25.TabIndex = 86;
            label25.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label165
            // 
            label165.AutoSize = true;
            label165.Location = new System.Drawing.Point(17, 32);
            label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label165.Name = "label165";
            label165.Size = new System.Drawing.Size(43, 25);
            label165.TabIndex = 79;
            label165.Text = "URL";
            // 
            // cbIPCameraONVIF
            // 
            cbIPCameraONVIF.AutoSize = true;
            cbIPCameraONVIF.Location = new System.Drawing.Point(487, 100);
            cbIPCameraONVIF.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            cbIPCameraONVIF.Size = new System.Drawing.Size(152, 29);
            cbIPCameraONVIF.TabIndex = 78;
            cbIPCameraONVIF.Text = "ONVIF camera";
            cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // cbIPDisconnect
            // 
            cbIPDisconnect.AutoSize = true;
            cbIPDisconnect.Location = new System.Drawing.Point(487, 188);
            cbIPDisconnect.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbIPDisconnect.Name = "cbIPDisconnect";
            cbIPDisconnect.Size = new System.Drawing.Size(228, 29);
            cbIPDisconnect.TabIndex = 75;
            cbIPDisconnect.Text = "Notify if connection lost";
            cbIPDisconnect.UseVisualStyleBackColor = true;
            // 
            // edIPForcedFramerateID
            // 
            edIPForcedFramerateID.Location = new System.Drawing.Point(441, 258);
            edIPForcedFramerateID.Name = "edIPForcedFramerateID";
            edIPForcedFramerateID.Size = new System.Drawing.Size(51, 31);
            edIPForcedFramerateID.TabIndex = 71;
            edIPForcedFramerateID.Text = "0";
            // 
            // label344
            // 
            label344.AutoSize = true;
            label344.Location = new System.Drawing.Point(271, 262);
            label344.Name = "label344";
            label344.Size = new System.Drawing.Size(164, 25);
            label344.TabIndex = 70;
            label344.Text = "Force frame rate ID";
            // 
            // edIPForcedFramerate
            // 
            edIPForcedFramerate.Location = new System.Drawing.Point(187, 258);
            edIPForcedFramerate.Name = "edIPForcedFramerate";
            edIPForcedFramerate.Size = new System.Drawing.Size(51, 31);
            edIPForcedFramerate.TabIndex = 69;
            edIPForcedFramerate.Text = "0";
            // 
            // label295
            // 
            label295.AutoSize = true;
            label295.Location = new System.Drawing.Point(17, 262);
            label295.Name = "label295";
            label295.Size = new System.Drawing.Size(141, 25);
            label295.TabIndex = 68;
            label295.Text = "Force frame rate";
            // 
            // cbIPCameraType
            // 
            cbIPCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbIPCameraType.FormattingEnabled = true;
            cbIPCameraType.Items.AddRange(new object[] { "Auto (VLC engine)", "Auto (FFMPEG engine)", "Auto (LAV engine)", "Auto (GPU decoding, LAV)", "MMS - WMV", "HTTP MJPEG Low Latency", "RTSP Low Latency TCP", "RTSP Low Latency UDP", "NDI", "NDI (Legacy)" });
            cbIPCameraType.Location = new System.Drawing.Point(91, 97);
            cbIPCameraType.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbIPCameraType.Name = "cbIPCameraType";
            cbIPCameraType.Size = new System.Drawing.Size(375, 33);
            cbIPCameraType.TabIndex = 67;
            // 
            // edIPPassword
            // 
            edIPPassword.Location = new System.Drawing.Point(277, 188);
            edIPPassword.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edIPPassword.Name = "edIPPassword";
            edIPPassword.Size = new System.Drawing.Size(164, 31);
            edIPPassword.TabIndex = 66;
            // 
            // label167
            // 
            label167.AutoSize = true;
            label167.Location = new System.Drawing.Point(271, 157);
            label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label167.Name = "label167";
            label167.Size = new System.Drawing.Size(87, 25);
            label167.TabIndex = 65;
            label167.Text = "Password";
            // 
            // edIPLogin
            // 
            edIPLogin.Location = new System.Drawing.Point(21, 188);
            edIPLogin.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edIPLogin.Name = "edIPLogin";
            edIPLogin.Size = new System.Drawing.Size(164, 31);
            edIPLogin.TabIndex = 64;
            // 
            // label166
            // 
            label166.AutoSize = true;
            label166.Location = new System.Drawing.Point(16, 157);
            label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label166.Name = "label166";
            label166.Size = new System.Drawing.Size(56, 25);
            label166.TabIndex = 63;
            label166.Text = "Login";
            // 
            // cbIPAudioCapture
            // 
            cbIPAudioCapture.AutoSize = true;
            cbIPAudioCapture.Checked = true;
            cbIPAudioCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            cbIPAudioCapture.Location = new System.Drawing.Point(487, 143);
            cbIPAudioCapture.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbIPAudioCapture.Name = "cbIPAudioCapture";
            cbIPAudioCapture.Size = new System.Drawing.Size(150, 29);
            cbIPAudioCapture.TabIndex = 62;
            cbIPAudioCapture.Text = "Capture audio";
            cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // label168
            // 
            label168.AutoSize = true;
            label168.Location = new System.Drawing.Point(16, 103);
            label168.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label168.Name = "label168";
            label168.Size = new System.Drawing.Size(65, 25);
            label168.TabIndex = 61;
            label168.Text = "Engine";
            // 
            // tabPage146
            // 
            tabPage146.Controls.Add(btVLCAddParameter);
            tabPage146.Controls.Add(btVLCClearParameters);
            tabPage146.Controls.Add(edVLCParameter);
            tabPage146.Controls.Add(lbVLCParameters);
            tabPage146.Controls.Add(label2);
            tabPage146.Controls.Add(cbVLCZeroClockJitter);
            tabPage146.Controls.Add(edVLCCacheSize);
            tabPage146.Controls.Add(label312);
            tabPage146.Location = new System.Drawing.Point(4, 34);
            tabPage146.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage146.Name = "tabPage146";
            tabPage146.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage146.Size = new System.Drawing.Size(736, 487);
            tabPage146.TabIndex = 2;
            tabPage146.Text = "VLC";
            tabPage146.UseVisualStyleBackColor = true;
            // 
            // btVLCAddParameter
            // 
            btVLCAddParameter.Location = new System.Drawing.Point(409, 390);
            btVLCAddParameter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btVLCAddParameter.Name = "btVLCAddParameter";
            btVLCAddParameter.Size = new System.Drawing.Size(91, 43);
            btVLCAddParameter.TabIndex = 83;
            btVLCAddParameter.Text = "Add";
            btVLCAddParameter.UseVisualStyleBackColor = true;
            btVLCAddParameter.Click += (this.btVLCAddParameter_Click);
            // 
            // btVLCClearParameters
            // 
            btVLCClearParameters.Location = new System.Drawing.Point(613, 390);
            btVLCClearParameters.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btVLCClearParameters.Name = "btVLCClearParameters";
            btVLCClearParameters.Size = new System.Drawing.Size(91, 43);
            btVLCClearParameters.TabIndex = 82;
            btVLCClearParameters.Text = "Clear";
            btVLCClearParameters.UseVisualStyleBackColor = true;
            btVLCClearParameters.Click += (this.btVLCClearParameters_Click);
            // 
            // edVLCParameter
            // 
            edVLCParameter.Location = new System.Drawing.Point(33, 393);
            edVLCParameter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edVLCParameter.Name = "edVLCParameter";
            edVLCParameter.Size = new System.Drawing.Size(363, 31);
            edVLCParameter.TabIndex = 81;
            // 
            // lbVLCParameters
            // 
            lbVLCParameters.FormattingEnabled = true;
            lbVLCParameters.ItemHeight = 25;
            lbVLCParameters.Location = new System.Drawing.Point(33, 125);
            lbVLCParameters.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lbVLCParameters.Name = "lbVLCParameters";
            lbVLCParameters.Size = new System.Drawing.Size(668, 254);
            lbVLCParameters.TabIndex = 80;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 93);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(384, 25);
            label2.TabIndex = 79;
            label2.Text = "Custom parameters (same as in command line)";
            // 
            // cbVLCZeroClockJitter
            // 
            cbVLCZeroClockJitter.AutoSize = true;
            cbVLCZeroClockJitter.Location = new System.Drawing.Point(289, 32);
            cbVLCZeroClockJitter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter";
            cbVLCZeroClockJitter.Size = new System.Drawing.Size(212, 29);
            cbVLCZeroClockJitter.TabIndex = 78;
            cbVLCZeroClockJitter.Text = "VLC low latency mode";
            cbVLCZeroClockJitter.UseVisualStyleBackColor = true;
            // 
            // edVLCCacheSize
            // 
            edVLCCacheSize.Location = new System.Drawing.Point(199, 28);
            edVLCCacheSize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edVLCCacheSize.Name = "edVLCCacheSize";
            edVLCCacheSize.Size = new System.Drawing.Size(51, 31);
            edVLCCacheSize.TabIndex = 77;
            edVLCCacheSize.Text = "250";
            // 
            // label312
            // 
            label312.AutoSize = true;
            label312.Location = new System.Drawing.Point(29, 32);
            label312.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label312.Name = "label312";
            label312.Size = new System.Drawing.Size(163, 25);
            label312.TabIndex = 76;
            label312.Text = "VLC cache size (ms)";
            // 
            // tabPage145
            // 
            tabPage145.Controls.Add(edONVIFPassword);
            tabPage145.Controls.Add(label378);
            tabPage145.Controls.Add(edONVIFLogin);
            tabPage145.Controls.Add(label379);
            tabPage145.Controls.Add(edONVIFURL);
            tabPage145.Controls.Add(edONVIFLiveVideoURL);
            tabPage145.Controls.Add(label513);
            tabPage145.Controls.Add(groupBox42);
            tabPage145.Controls.Add(cbONVIFProfile);
            tabPage145.Controls.Add(label510);
            tabPage145.Controls.Add(lbONVIFCameraInfo);
            tabPage145.Controls.Add(btONVIFConnect);
            tabPage145.Location = new System.Drawing.Point(4, 34);
            tabPage145.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage145.Name = "tabPage145";
            tabPage145.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage145.Size = new System.Drawing.Size(736, 487);
            tabPage145.TabIndex = 1;
            tabPage145.Text = "ONVIF";
            tabPage145.UseVisualStyleBackColor = true;
            // 
            // edONVIFPassword
            // 
            edONVIFPassword.Location = new System.Drawing.Point(400, 72);
            edONVIFPassword.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edONVIFPassword.Name = "edONVIFPassword";
            edONVIFPassword.Size = new System.Drawing.Size(164, 31);
            edONVIFPassword.TabIndex = 70;
            // 
            // label378
            // 
            label378.AutoSize = true;
            label378.Location = new System.Drawing.Point(303, 78);
            label378.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label378.Name = "label378";
            label378.Size = new System.Drawing.Size(87, 25);
            label378.TabIndex = 69;
            label378.Text = "Password";
            // 
            // edONVIFLogin
            // 
            edONVIFLogin.Location = new System.Drawing.Point(124, 72);
            edONVIFLogin.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edONVIFLogin.Name = "edONVIFLogin";
            edONVIFLogin.Size = new System.Drawing.Size(164, 31);
            edONVIFLogin.TabIndex = 68;
            // 
            // label379
            // 
            label379.AutoSize = true;
            label379.Location = new System.Drawing.Point(19, 78);
            label379.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label379.Name = "label379";
            label379.Size = new System.Drawing.Size(56, 25);
            label379.TabIndex = 67;
            label379.Text = "Login";
            // 
            // edONVIFURL
            // 
            edONVIFURL.Location = new System.Drawing.Point(23, 15);
            edONVIFURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edONVIFURL.Name = "edONVIFURL";
            edONVIFURL.Size = new System.Drawing.Size(541, 31);
            edONVIFURL.TabIndex = 29;
            edONVIFURL.Text = "http://192.168.1.64/onvif/device_service";
            // 
            // edONVIFLiveVideoURL
            // 
            edONVIFLiveVideoURL.Location = new System.Drawing.Point(124, 212);
            edONVIFLiveVideoURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL";
            edONVIFLiveVideoURL.ReadOnly = true;
            edONVIFLiveVideoURL.Size = new System.Drawing.Size(574, 31);
            edONVIFLiveVideoURL.TabIndex = 28;
            // 
            // label513
            // 
            label513.AutoSize = true;
            label513.Location = new System.Drawing.Point(19, 218);
            label513.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label513.Name = "label513";
            label513.Size = new System.Drawing.Size(94, 25);
            label513.TabIndex = 27;
            label513.Text = "Video URL";
            // 
            // groupBox42
            // 
            groupBox42.Controls.Add(btONVIFPTZSetDefault);
            groupBox42.Controls.Add(btONVIFRight);
            groupBox42.Controls.Add(btONVIFLeft);
            groupBox42.Controls.Add(btONVIFZoomOut);
            groupBox42.Controls.Add(btONVIFZoomIn);
            groupBox42.Controls.Add(btONVIFDown);
            groupBox42.Controls.Add(btONVIFUp);
            groupBox42.Location = new System.Drawing.Point(250, 262);
            groupBox42.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox42.Name = "groupBox42";
            groupBox42.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox42.Size = new System.Drawing.Size(451, 200);
            groupBox42.TabIndex = 26;
            groupBox42.TabStop = false;
            groupBox42.Text = "PTZ";
            // 
            // btONVIFPTZSetDefault
            // 
            btONVIFPTZSetDefault.Location = new System.Drawing.Point(217, 85);
            btONVIFPTZSetDefault.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFPTZSetDefault.Name = "btONVIFPTZSetDefault";
            btONVIFPTZSetDefault.Size = new System.Drawing.Size(193, 43);
            btONVIFPTZSetDefault.TabIndex = 6;
            btONVIFPTZSetDefault.Text = "Set default position";
            btONVIFPTZSetDefault.UseVisualStyleBackColor = true;
            btONVIFPTZSetDefault.Click += (this.btONVIFPTZSetDefault_Click);
            // 
            // btONVIFRight
            // 
            btONVIFRight.Location = new System.Drawing.Point(141, 62);
            btONVIFRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFRight.Name = "btONVIFRight";
            btONVIFRight.Size = new System.Drawing.Size(36, 92);
            btONVIFRight.TabIndex = 5;
            btONVIFRight.Text = "R";
            btONVIFRight.UseVisualStyleBackColor = true;
            btONVIFRight.Click += (this.btONVIFRight_Click);
            // 
            // btONVIFLeft
            // 
            btONVIFLeft.Location = new System.Drawing.Point(21, 62);
            btONVIFLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFLeft.Name = "btONVIFLeft";
            btONVIFLeft.Size = new System.Drawing.Size(36, 92);
            btONVIFLeft.TabIndex = 4;
            btONVIFLeft.Text = "L";
            btONVIFLeft.UseVisualStyleBackColor = true;
            btONVIFLeft.Click += (this.btONVIFLeft_Click);
            // 
            // btONVIFZoomOut
            // 
            btONVIFZoomOut.Location = new System.Drawing.Point(101, 88);
            btONVIFZoomOut.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFZoomOut.Name = "btONVIFZoomOut";
            btONVIFZoomOut.Size = new System.Drawing.Size(39, 43);
            btONVIFZoomOut.TabIndex = 3;
            btONVIFZoomOut.Text = "-";
            btONVIFZoomOut.UseVisualStyleBackColor = true;
            btONVIFZoomOut.Click += (this.btONVIFZoomOut_Click);
            // 
            // btONVIFZoomIn
            // 
            btONVIFZoomIn.Location = new System.Drawing.Point(59, 88);
            btONVIFZoomIn.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFZoomIn.Name = "btONVIFZoomIn";
            btONVIFZoomIn.Size = new System.Drawing.Size(37, 43);
            btONVIFZoomIn.TabIndex = 2;
            btONVIFZoomIn.Text = "+";
            btONVIFZoomIn.UseVisualStyleBackColor = true;
            btONVIFZoomIn.Click += (this.btONVIFZoomIn_Click);
            // 
            // btONVIFDown
            // 
            btONVIFDown.Location = new System.Drawing.Point(57, 132);
            btONVIFDown.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFDown.Name = "btONVIFDown";
            btONVIFDown.Size = new System.Drawing.Size(84, 43);
            btONVIFDown.TabIndex = 1;
            btONVIFDown.Text = "Down";
            btONVIFDown.UseVisualStyleBackColor = true;
            btONVIFDown.Click += (this.btONVIFDown_Click);
            // 
            // btONVIFUp
            // 
            btONVIFUp.Location = new System.Drawing.Point(57, 38);
            btONVIFUp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFUp.Name = "btONVIFUp";
            btONVIFUp.Size = new System.Drawing.Size(84, 43);
            btONVIFUp.TabIndex = 0;
            btONVIFUp.Text = "Up";
            btONVIFUp.UseVisualStyleBackColor = true;
            btONVIFUp.Click += (this.btONVIFUp_Click);
            // 
            // cbONVIFProfile
            // 
            cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbONVIFProfile.FormattingEnabled = true;
            cbONVIFProfile.Location = new System.Drawing.Point(124, 162);
            cbONVIFProfile.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbONVIFProfile.Name = "cbONVIFProfile";
            cbONVIFProfile.Size = new System.Drawing.Size(574, 33);
            cbONVIFProfile.TabIndex = 4;
            // 
            // label510
            // 
            label510.AutoSize = true;
            label510.Location = new System.Drawing.Point(19, 168);
            label510.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label510.Name = "label510";
            label510.Size = new System.Drawing.Size(62, 25);
            label510.TabIndex = 3;
            label510.Text = "Profile";
            // 
            // lbONVIFCameraInfo
            // 
            lbONVIFCameraInfo.AutoSize = true;
            lbONVIFCameraInfo.Location = new System.Drawing.Point(19, 128);
            lbONVIFCameraInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbONVIFCameraInfo.Name = "lbONVIFCameraInfo";
            lbONVIFCameraInfo.Size = new System.Drawing.Size(112, 25);
            lbONVIFCameraInfo.TabIndex = 1;
            lbONVIFCameraInfo.Text = "Status: None";
            // 
            // btONVIFConnect
            // 
            btONVIFConnect.Location = new System.Drawing.Point(577, 12);
            btONVIFConnect.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btONVIFConnect.Name = "btONVIFConnect";
            btONVIFConnect.Size = new System.Drawing.Size(124, 43);
            btONVIFConnect.TabIndex = 0;
            btONVIFConnect.Text = "Connect";
            btONVIFConnect.UseVisualStyleBackColor = true;
            btONVIFConnect.Click += (this.btONVIFConnect_Click);
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(cbDecklinkCaptureVideoFormat);
            tabPage4.Controls.Add(label66);
            tabPage4.Controls.Add(cbDecklinkCaptureDevice);
            tabPage4.Controls.Add(label39);
            tabPage4.Controls.Add(cbDecklinkSourceTimecode);
            tabPage4.Controls.Add(label341);
            tabPage4.Controls.Add(cbDecklinkSourceComponentLevels);
            tabPage4.Controls.Add(label339);
            tabPage4.Controls.Add(cbDecklinkSourceNTSC);
            tabPage4.Controls.Add(label340);
            tabPage4.Controls.Add(cbDecklinkSourceInput);
            tabPage4.Controls.Add(label338);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage4.Size = new System.Drawing.Size(765, 547);
            tabPage4.TabIndex = 11;
            tabPage4.Text = "Decklink";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDecklinkCaptureVideoFormat
            // 
            cbDecklinkCaptureVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkCaptureVideoFormat.FormattingEnabled = true;
            cbDecklinkCaptureVideoFormat.Location = new System.Drawing.Point(33, 148);
            cbDecklinkCaptureVideoFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkCaptureVideoFormat.Name = "cbDecklinkCaptureVideoFormat";
            cbDecklinkCaptureVideoFormat.Size = new System.Drawing.Size(301, 33);
            cbDecklinkCaptureVideoFormat.TabIndex = 27;
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Location = new System.Drawing.Point(29, 118);
            label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label66.Name = "label66";
            label66.Size = new System.Drawing.Size(285, 25);
            label66.TabIndex = 26;
            label66.Text = "Video format (original format first)";
            // 
            // cbDecklinkCaptureDevice
            // 
            cbDecklinkCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkCaptureDevice.FormattingEnabled = true;
            cbDecklinkCaptureDevice.Location = new System.Drawing.Point(33, 62);
            cbDecklinkCaptureDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkCaptureDevice.Name = "cbDecklinkCaptureDevice";
            cbDecklinkCaptureDevice.Size = new System.Drawing.Size(301, 33);
            cbDecklinkCaptureDevice.TabIndex = 25;
            cbDecklinkCaptureDevice.SelectedIndexChanged += (this.cbDecklinkCaptureDevice_SelectedIndexChanged);
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new System.Drawing.Point(29, 32);
            label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(64, 25);
            label39.TabIndex = 24;
            label39.Text = "Device";
            // 
            // cbDecklinkSourceTimecode
            // 
            cbDecklinkSourceTimecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkSourceTimecode.FormattingEnabled = true;
            cbDecklinkSourceTimecode.Items.AddRange(new object[] { "Auto", "VITC", "HANC" });
            cbDecklinkSourceTimecode.Location = new System.Drawing.Point(290, 492);
            cbDecklinkSourceTimecode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkSourceTimecode.Name = "cbDecklinkSourceTimecode";
            cbDecklinkSourceTimecode.Size = new System.Drawing.Size(200, 33);
            cbDecklinkSourceTimecode.TabIndex = 23;
            // 
            // label341
            // 
            label341.AutoSize = true;
            label341.Location = new System.Drawing.Point(284, 462);
            label341.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label341.Name = "label341";
            label341.Size = new System.Drawing.Size(146, 25);
            label341.TabIndex = 22;
            label341.Text = "Timecode source";
            // 
            // cbDecklinkSourceComponentLevels
            // 
            cbDecklinkSourceComponentLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkSourceComponentLevels.FormattingEnabled = true;
            cbDecklinkSourceComponentLevels.Items.AddRange(new object[] { "SMPTE", "Betacam" });
            cbDecklinkSourceComponentLevels.Location = new System.Drawing.Point(543, 492);
            cbDecklinkSourceComponentLevels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkSourceComponentLevels.Name = "cbDecklinkSourceComponentLevels";
            cbDecklinkSourceComponentLevels.Size = new System.Drawing.Size(200, 33);
            cbDecklinkSourceComponentLevels.TabIndex = 21;
            // 
            // label339
            // 
            label339.AutoSize = true;
            label339.Location = new System.Drawing.Point(539, 462);
            label339.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label339.Name = "label339";
            label339.Size = new System.Drawing.Size(155, 25);
            label339.TabIndex = 20;
            label339.Text = "Component levels";
            // 
            // cbDecklinkSourceNTSC
            // 
            cbDecklinkSourceNTSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkSourceNTSC.FormattingEnabled = true;
            cbDecklinkSourceNTSC.Items.AddRange(new object[] { "USA", "Japan" });
            cbDecklinkSourceNTSC.Location = new System.Drawing.Point(543, 407);
            cbDecklinkSourceNTSC.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkSourceNTSC.Name = "cbDecklinkSourceNTSC";
            cbDecklinkSourceNTSC.Size = new System.Drawing.Size(200, 33);
            cbDecklinkSourceNTSC.TabIndex = 19;
            // 
            // label340
            // 
            label340.AutoSize = true;
            label340.Location = new System.Drawing.Point(539, 375);
            label340.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label340.Name = "label340";
            label340.Size = new System.Drawing.Size(130, 25);
            label340.TabIndex = 18;
            label340.Text = "NTSC standard";
            // 
            // cbDecklinkSourceInput
            // 
            cbDecklinkSourceInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDecklinkSourceInput.FormattingEnabled = true;
            cbDecklinkSourceInput.Items.AddRange(new object[] { "Auto", "SDI", "Composite", "Component", "S-Video", "HDMI", "Optical SDI" });
            cbDecklinkSourceInput.Location = new System.Drawing.Point(290, 407);
            cbDecklinkSourceInput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDecklinkSourceInput.Name = "cbDecklinkSourceInput";
            cbDecklinkSourceInput.Size = new System.Drawing.Size(200, 33);
            cbDecklinkSourceInput.TabIndex = 17;
            // 
            // label338
            // 
            label338.AutoSize = true;
            label338.Location = new System.Drawing.Point(284, 375);
            label338.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label338.Name = "label338";
            label338.Size = new System.Drawing.Size(54, 25);
            label338.TabIndex = 16;
            label338.Text = "Input";
            // 
            // tabPage81
            // 
            tabPage81.Controls.Add(tabControl22);
            tabPage81.Location = new System.Drawing.Point(4, 34);
            tabPage81.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage81.Name = "tabPage81";
            tabPage81.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage81.Size = new System.Drawing.Size(765, 547);
            tabPage81.TabIndex = 7;
            tabPage81.Text = "DVB-x / ATSC";
            tabPage81.UseVisualStyleBackColor = true;
            // 
            // tabControl22
            // 
            tabControl22.Controls.Add(tabPage82);
            tabControl22.Controls.Add(tabPage83);
            tabControl22.Controls.Add(tabPage105);
            tabControl22.Location = new System.Drawing.Point(10, 12);
            tabControl22.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl22.Name = "tabControl22";
            tabControl22.SelectedIndex = 0;
            tabControl22.Size = new System.Drawing.Size(744, 525);
            tabControl22.TabIndex = 12;
            // 
            // tabPage82
            // 
            tabPage82.Controls.Add(cbBDADeviceStandard);
            tabPage82.Controls.Add(label129);
            tabPage82.Controls.Add(cbBDAReceiver);
            tabPage82.Controls.Add(label270);
            tabPage82.Controls.Add(cbBDASourceDevice);
            tabPage82.Controls.Add(label272);
            tabPage82.Location = new System.Drawing.Point(4, 34);
            tabPage82.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage82.Name = "tabPage82";
            tabPage82.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage82.Size = new System.Drawing.Size(736, 487);
            tabPage82.TabIndex = 0;
            tabPage82.Text = "Input device";
            tabPage82.UseVisualStyleBackColor = true;
            // 
            // cbBDADeviceStandard
            // 
            cbBDADeviceStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBDADeviceStandard.FormattingEnabled = true;
            cbBDADeviceStandard.Items.AddRange(new object[] { "DVB-T", "DVB-S", "DVB-C", "ATSC (not supported now)" });
            cbBDADeviceStandard.Location = new System.Drawing.Point(23, 250);
            cbBDADeviceStandard.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbBDADeviceStandard.Name = "cbBDADeviceStandard";
            cbBDADeviceStandard.Size = new System.Drawing.Size(445, 33);
            cbBDADeviceStandard.TabIndex = 17;
            // 
            // label129
            // 
            label129.AutoSize = true;
            label129.Location = new System.Drawing.Point(19, 218);
            label129.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label129.Name = "label129";
            label129.Size = new System.Drawing.Size(139, 25);
            label129.TabIndex = 16;
            label129.Text = "Device standard";
            // 
            // cbBDAReceiver
            // 
            cbBDAReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBDAReceiver.FormattingEnabled = true;
            cbBDAReceiver.Items.AddRange(new object[] { "" });
            cbBDAReceiver.Location = new System.Drawing.Point(23, 157);
            cbBDAReceiver.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbBDAReceiver.Name = "cbBDAReceiver";
            cbBDAReceiver.Size = new System.Drawing.Size(445, 33);
            cbBDAReceiver.TabIndex = 15;
            // 
            // label270
            // 
            label270.AutoSize = true;
            label270.Location = new System.Drawing.Point(19, 125);
            label270.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label270.Name = "label270";
            label270.Size = new System.Drawing.Size(254, 25);
            label270.TabIndex = 14;
            label270.Text = "Receiver device (can be empty)";
            // 
            // cbBDASourceDevice
            // 
            cbBDASourceDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBDASourceDevice.FormattingEnabled = true;
            cbBDASourceDevice.Location = new System.Drawing.Point(23, 62);
            cbBDASourceDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbBDASourceDevice.Name = "cbBDASourceDevice";
            cbBDASourceDevice.Size = new System.Drawing.Size(445, 33);
            cbBDASourceDevice.TabIndex = 13;
            // 
            // label272
            // 
            label272.AutoSize = true;
            label272.Location = new System.Drawing.Point(19, 32);
            label272.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label272.Name = "label272";
            label272.Size = new System.Drawing.Size(121, 25);
            label272.TabIndex = 12;
            label272.Text = "Source device";
            // 
            // tabPage83
            // 
            tabPage83.Controls.Add(tabControl23);
            tabPage83.Location = new System.Drawing.Point(4, 34);
            tabPage83.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage83.Name = "tabPage83";
            tabPage83.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage83.Size = new System.Drawing.Size(736, 487);
            tabPage83.TabIndex = 1;
            tabPage83.Text = "Tuning";
            tabPage83.UseVisualStyleBackColor = true;
            // 
            // tabControl23
            // 
            tabControl23.Controls.Add(tabPage84);
            tabControl23.Controls.Add(tabPage85);
            tabControl23.Controls.Add(tabPage86);
            tabControl23.Controls.Add(tabPage87);
            tabControl23.Location = new System.Drawing.Point(10, 8);
            tabControl23.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl23.Name = "tabControl23";
            tabControl23.SelectedIndex = 0;
            tabControl23.Size = new System.Drawing.Size(711, 462);
            tabControl23.TabIndex = 8;
            // 
            // tabPage84
            // 
            tabPage84.Controls.Add(btDVBTTune);
            tabPage84.Controls.Add(edDVBTSID);
            tabPage84.Controls.Add(edDVBTTSID);
            tabPage84.Controls.Add(edDVBTONID);
            tabPage84.Controls.Add(label273);
            tabPage84.Controls.Add(edDVBTFrequency);
            tabPage84.Controls.Add(label274);
            tabPage84.Controls.Add(label275);
            tabPage84.Controls.Add(label276);
            tabPage84.Controls.Add(label277);
            tabPage84.Location = new System.Drawing.Point(4, 34);
            tabPage84.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage84.Name = "tabPage84";
            tabPage84.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage84.Size = new System.Drawing.Size(703, 424);
            tabPage84.TabIndex = 0;
            tabPage84.Text = "DVB-T";
            tabPage84.UseVisualStyleBackColor = true;
            // 
            // btDVBTTune
            // 
            btDVBTTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btDVBTTune.Location = new System.Drawing.Point(10, 357);
            btDVBTTune.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVBTTune.Name = "btDVBTTune";
            btDVBTTune.Size = new System.Drawing.Size(77, 43);
            btDVBTTune.TabIndex = 21;
            btDVBTTune.Text = "Tune";
            btDVBTTune.UseVisualStyleBackColor = true;
            btDVBTTune.Click += (this.btDVBTTune_Click);
            // 
            // edDVBTSID
            // 
            edDVBTSID.Location = new System.Drawing.Point(170, 182);
            edDVBTSID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBTSID.Name = "edDVBTSID";
            edDVBTSID.Size = new System.Drawing.Size(154, 31);
            edDVBTSID.TabIndex = 20;
            edDVBTSID.Text = "1010";
            // 
            // edDVBTTSID
            // 
            edDVBTTSID.Location = new System.Drawing.Point(170, 128);
            edDVBTTSID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBTTSID.Name = "edDVBTTSID";
            edDVBTTSID.Size = new System.Drawing.Size(154, 31);
            edDVBTTSID.TabIndex = 19;
            edDVBTTSID.Text = "-1";
            // 
            // edDVBTONID
            // 
            edDVBTONID.Location = new System.Drawing.Point(170, 72);
            edDVBTONID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBTONID.Name = "edDVBTONID";
            edDVBTONID.Size = new System.Drawing.Size(154, 31);
            edDVBTONID.TabIndex = 18;
            edDVBTONID.Text = "-1";
            // 
            // label273
            // 
            label273.AutoSize = true;
            label273.Location = new System.Drawing.Point(337, 22);
            label273.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label273.Name = "label273";
            label273.Size = new System.Drawing.Size(43, 25);
            label273.TabIndex = 17;
            label273.Text = "KHz";
            // 
            // edDVBTFrequency
            // 
            edDVBTFrequency.Location = new System.Drawing.Point(170, 15);
            edDVBTFrequency.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBTFrequency.Name = "edDVBTFrequency";
            edDVBTFrequency.Size = new System.Drawing.Size(154, 31);
            edDVBTFrequency.TabIndex = 16;
            edDVBTFrequency.Text = "586000";
            // 
            // label274
            // 
            label274.AutoSize = true;
            label274.Location = new System.Drawing.Point(10, 188);
            label274.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label274.Name = "label274";
            label274.Size = new System.Drawing.Size(40, 25);
            label274.TabIndex = 15;
            label274.Text = "SID";
            // 
            // label275
            // 
            label275.AutoSize = true;
            label275.Location = new System.Drawing.Point(10, 132);
            label275.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label275.Name = "label275";
            label275.Size = new System.Drawing.Size(49, 25);
            label275.TabIndex = 14;
            label275.Text = "TSID";
            // 
            // label276
            // 
            label276.AutoSize = true;
            label276.Location = new System.Drawing.Point(10, 78);
            label276.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label276.Name = "label276";
            label276.Size = new System.Drawing.Size(57, 25);
            label276.TabIndex = 13;
            label276.Text = "ONID";
            // 
            // label277
            // 
            label277.AutoSize = true;
            label277.Location = new System.Drawing.Point(10, 22);
            label277.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label277.Name = "label277";
            label277.Size = new System.Drawing.Size(149, 25);
            label277.TabIndex = 12;
            label277.Text = "Carrier Frequency";
            // 
            // tabPage85
            // 
            tabPage85.Controls.Add(cbDVBSPolarisation);
            tabPage85.Controls.Add(label278);
            tabPage85.Controls.Add(edDVBSSymbolRate);
            tabPage85.Controls.Add(label279);
            tabPage85.Controls.Add(btDVBSTune);
            tabPage85.Controls.Add(edDVBSSID);
            tabPage85.Controls.Add(edDVBSTSID);
            tabPage85.Controls.Add(edDVBSONIT);
            tabPage85.Controls.Add(label280);
            tabPage85.Controls.Add(edDVBSFrequency);
            tabPage85.Controls.Add(label281);
            tabPage85.Controls.Add(label282);
            tabPage85.Controls.Add(label283);
            tabPage85.Controls.Add(label284);
            tabPage85.Location = new System.Drawing.Point(4, 34);
            tabPage85.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage85.Name = "tabPage85";
            tabPage85.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage85.Size = new System.Drawing.Size(703, 424);
            tabPage85.TabIndex = 1;
            tabPage85.Text = "DVB-S";
            tabPage85.UseVisualStyleBackColor = true;
            // 
            // cbDVBSPolarisation
            // 
            cbDVBSPolarisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDVBSPolarisation.Items.AddRange(new object[] { "Not Set", "Not Defined", "Linear Horizontal", "Linear Vertical", "Circular Left", "Circular Right", "Max" });
            cbDVBSPolarisation.Location = new System.Drawing.Point(170, 115);
            cbDVBSPolarisation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDVBSPolarisation.Name = "cbDVBSPolarisation";
            cbDVBSPolarisation.Size = new System.Drawing.Size(154, 33);
            cbDVBSPolarisation.TabIndex = 34;
            // 
            // label278
            // 
            label278.AutoSize = true;
            label278.Location = new System.Drawing.Point(10, 122);
            label278.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label278.Name = "label278";
            label278.Size = new System.Drawing.Size(156, 25);
            label278.TabIndex = 33;
            label278.Text = "Signal Polarisation";
            // 
            // edDVBSSymbolRate
            // 
            edDVBSSymbolRate.Location = new System.Drawing.Point(170, 65);
            edDVBSSymbolRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBSSymbolRate.Name = "edDVBSSymbolRate";
            edDVBSSymbolRate.Size = new System.Drawing.Size(154, 31);
            edDVBSSymbolRate.TabIndex = 32;
            edDVBSSymbolRate.Text = "-1";
            // 
            // label279
            // 
            label279.AutoSize = true;
            label279.Location = new System.Drawing.Point(10, 72);
            label279.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label279.Name = "label279";
            label279.Size = new System.Drawing.Size(112, 25);
            label279.TabIndex = 31;
            label279.Text = "Symbol Rate";
            // 
            // btDVBSTune
            // 
            btDVBSTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btDVBSTune.Location = new System.Drawing.Point(10, 357);
            btDVBSTune.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btDVBSTune.Name = "btDVBSTune";
            btDVBSTune.Size = new System.Drawing.Size(77, 43);
            btDVBSTune.TabIndex = 30;
            btDVBSTune.Text = "Tune";
            btDVBSTune.UseVisualStyleBackColor = true;
            // 
            // edDVBSSID
            // 
            edDVBSSID.Location = new System.Drawing.Point(170, 278);
            edDVBSSID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBSSID.Name = "edDVBSSID";
            edDVBSSID.Size = new System.Drawing.Size(154, 31);
            edDVBSSID.TabIndex = 29;
            edDVBSSID.Text = "-1";
            // 
            // edDVBSTSID
            // 
            edDVBSTSID.Location = new System.Drawing.Point(170, 222);
            edDVBSTSID.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBSTSID.Name = "edDVBSTSID";
            edDVBSTSID.Size = new System.Drawing.Size(154, 31);
            edDVBSTSID.TabIndex = 28;
            edDVBSTSID.Text = "-1";
            // 
            // edDVBSONIT
            // 
            edDVBSONIT.Location = new System.Drawing.Point(170, 168);
            edDVBSONIT.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBSONIT.Name = "edDVBSONIT";
            edDVBSONIT.Size = new System.Drawing.Size(154, 31);
            edDVBSONIT.TabIndex = 27;
            edDVBSONIT.Text = "-1";
            // 
            // label280
            // 
            label280.AutoSize = true;
            label280.Location = new System.Drawing.Point(337, 22);
            label280.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label280.Name = "label280";
            label280.Size = new System.Drawing.Size(43, 25);
            label280.TabIndex = 26;
            label280.Text = "KHz";
            // 
            // edDVBSFrequency
            // 
            edDVBSFrequency.Location = new System.Drawing.Point(170, 15);
            edDVBSFrequency.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBSFrequency.Name = "edDVBSFrequency";
            edDVBSFrequency.Size = new System.Drawing.Size(154, 31);
            edDVBSFrequency.TabIndex = 25;
            edDVBSFrequency.Text = "-1";
            // 
            // label281
            // 
            label281.AutoSize = true;
            label281.Location = new System.Drawing.Point(10, 282);
            label281.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label281.Name = "label281";
            label281.Size = new System.Drawing.Size(40, 25);
            label281.TabIndex = 24;
            label281.Text = "SID";
            // 
            // label282
            // 
            label282.AutoSize = true;
            label282.Location = new System.Drawing.Point(10, 228);
            label282.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label282.Name = "label282";
            label282.Size = new System.Drawing.Size(49, 25);
            label282.TabIndex = 23;
            label282.Text = "TSID";
            // 
            // label283
            // 
            label283.AutoSize = true;
            label283.Location = new System.Drawing.Point(10, 172);
            label283.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label283.Name = "label283";
            label283.Size = new System.Drawing.Size(53, 25);
            label283.TabIndex = 22;
            label283.Text = "ONIT";
            // 
            // label284
            // 
            label284.AutoSize = true;
            label284.Location = new System.Drawing.Point(10, 22);
            label284.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label284.Name = "label284";
            label284.Size = new System.Drawing.Size(149, 25);
            label284.TabIndex = 21;
            label284.Text = "Carrier Frequency";
            // 
            // tabPage86
            // 
            tabPage86.Controls.Add(groupBox35);
            tabPage86.Controls.Add(groupBox36);
            tabPage86.Controls.Add(btBDADVBCTune);
            tabPage86.Location = new System.Drawing.Point(4, 34);
            tabPage86.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage86.Name = "tabPage86";
            tabPage86.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage86.Size = new System.Drawing.Size(703, 424);
            tabPage86.TabIndex = 2;
            tabPage86.Text = "DVB-C";
            tabPage86.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            groupBox35.Controls.Add(edDVBCMinorChannel);
            groupBox35.Controls.Add(label285);
            groupBox35.Controls.Add(edDVBCPhysicalChannel);
            groupBox35.Controls.Add(label286);
            groupBox35.Controls.Add(edDVBCVirtualChannel);
            groupBox35.Controls.Add(label287);
            groupBox35.Location = new System.Drawing.Point(387, 18);
            groupBox35.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox35.Name = "groupBox35";
            groupBox35.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox35.Size = new System.Drawing.Size(301, 207);
            groupBox35.TabIndex = 46;
            groupBox35.TabStop = false;
            groupBox35.Text = "Tune request";
            // 
            // edDVBCMinorChannel
            // 
            edDVBCMinorChannel.Location = new System.Drawing.Point(163, 147);
            edDVBCMinorChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCMinorChannel.Name = "edDVBCMinorChannel";
            edDVBCMinorChannel.Size = new System.Drawing.Size(125, 31);
            edDVBCMinorChannel.TabIndex = 57;
            edDVBCMinorChannel.Text = "-1";
            // 
            // label285
            // 
            label285.AutoSize = true;
            label285.Location = new System.Drawing.Point(10, 152);
            label285.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label285.Name = "label285";
            label285.Size = new System.Drawing.Size(124, 25);
            label285.TabIndex = 56;
            label285.Text = "Minor channel";
            // 
            // edDVBCPhysicalChannel
            // 
            edDVBCPhysicalChannel.Location = new System.Drawing.Point(163, 98);
            edDVBCPhysicalChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCPhysicalChannel.Name = "edDVBCPhysicalChannel";
            edDVBCPhysicalChannel.Size = new System.Drawing.Size(125, 31);
            edDVBCPhysicalChannel.TabIndex = 55;
            edDVBCPhysicalChannel.Text = "103";
            // 
            // label286
            // 
            label286.AutoSize = true;
            label286.Location = new System.Drawing.Point(10, 103);
            label286.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label286.Name = "label286";
            label286.Size = new System.Drawing.Size(139, 25);
            label286.TabIndex = 54;
            label286.Text = "Physical channel";
            // 
            // edDVBCVirtualChannel
            // 
            edDVBCVirtualChannel.Location = new System.Drawing.Point(163, 47);
            edDVBCVirtualChannel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCVirtualChannel.Name = "edDVBCVirtualChannel";
            edDVBCVirtualChannel.Size = new System.Drawing.Size(125, 31);
            edDVBCVirtualChannel.TabIndex = 53;
            edDVBCVirtualChannel.Text = "-1";
            // 
            // label287
            // 
            label287.AutoSize = true;
            label287.Location = new System.Drawing.Point(10, 52);
            label287.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label287.Name = "label287";
            label287.Size = new System.Drawing.Size(127, 25);
            label287.TabIndex = 52;
            label287.Text = "Virtual channel";
            // 
            // groupBox36
            // 
            groupBox36.Controls.Add(edDVBCSymbolRate);
            groupBox36.Controls.Add(label288);
            groupBox36.Controls.Add(edDVBCProgramNumber);
            groupBox36.Controls.Add(label289);
            groupBox36.Controls.Add(cbDVBCModulation);
            groupBox36.Controls.Add(label290);
            groupBox36.Controls.Add(label291);
            groupBox36.Controls.Add(edDVBCCarrierFrequency);
            groupBox36.Controls.Add(label292);
            groupBox36.Location = new System.Drawing.Point(10, 18);
            groupBox36.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox36.Name = "groupBox36";
            groupBox36.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox36.Size = new System.Drawing.Size(367, 268);
            groupBox36.TabIndex = 45;
            groupBox36.TabStop = false;
            groupBox36.Text = "Current locator properties";
            // 
            // edDVBCSymbolRate
            // 
            edDVBCSymbolRate.Location = new System.Drawing.Point(177, 200);
            edDVBCSymbolRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCSymbolRate.Name = "edDVBCSymbolRate";
            edDVBCSymbolRate.Size = new System.Drawing.Size(125, 31);
            edDVBCSymbolRate.TabIndex = 53;
            edDVBCSymbolRate.Text = "6875";
            // 
            // label288
            // 
            label288.AutoSize = true;
            label288.Location = new System.Drawing.Point(17, 207);
            label288.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label288.Name = "label288";
            label288.Size = new System.Drawing.Size(107, 25);
            label288.TabIndex = 52;
            label288.Text = "Symbol rate";
            // 
            // edDVBCProgramNumber
            // 
            edDVBCProgramNumber.Location = new System.Drawing.Point(177, 150);
            edDVBCProgramNumber.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCProgramNumber.Name = "edDVBCProgramNumber";
            edDVBCProgramNumber.Size = new System.Drawing.Size(125, 31);
            edDVBCProgramNumber.TabIndex = 51;
            edDVBCProgramNumber.Text = "8";
            // 
            // label289
            // 
            label289.AutoSize = true;
            label289.Location = new System.Drawing.Point(17, 157);
            label289.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label289.Name = "label289";
            label289.Size = new System.Drawing.Size(148, 25);
            label289.TabIndex = 50;
            label289.Text = "Program number";
            // 
            // cbDVBCModulation
            // 
            cbDVBCModulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDVBCModulation.Items.AddRange(new object[] { "ModNotSet", "ModNotDefined", "Mod16Qam", "Mod32Qam", "Mod64Qam", "Mod80Qam", "Mod96Qam", "Mod112Qam", "Mod128Qam", "Mod160Qam", "Mod192Qam", "Mod224Qam", "Mod256Qam", "Mod320Qam", "Mod384Qam", "Mod448Qam", "Mod512Qam", "Mod640Qam", "Mod768Qam", "Mod896Qam", "Mod1024Qam", "ModQpsk", "ModBpsk", "ModOqpsk", "Mod8Vsb", "Mod16Vsb", "ModAnalogAmplitude ", "ModAnalogFrequency ", "Mod8Psk", "ModRF", "Mod16Apsk", "Mod32Apsk", "ModNbcQpsk", "ModNbc8Psk", "ModDirectTv", "ModMax" });
            cbDVBCModulation.Location = new System.Drawing.Point(177, 98);
            cbDVBCModulation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDVBCModulation.Name = "cbDVBCModulation";
            cbDVBCModulation.Size = new System.Drawing.Size(125, 33);
            cbDVBCModulation.TabIndex = 49;
            // 
            // label290
            // 
            label290.AutoSize = true;
            label290.Location = new System.Drawing.Point(17, 103);
            label290.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label290.Name = "label290";
            label290.Size = new System.Drawing.Size(104, 25);
            label290.TabIndex = 48;
            label290.Text = "Modulation";
            // 
            // label291
            // 
            label291.AutoSize = true;
            label291.Location = new System.Drawing.Point(316, 53);
            label291.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label291.Name = "label291";
            label291.Size = new System.Drawing.Size(43, 25);
            label291.TabIndex = 47;
            label291.Text = "KHz";
            // 
            // edDVBCCarrierFrequency
            // 
            edDVBCCarrierFrequency.Location = new System.Drawing.Point(177, 47);
            edDVBCCarrierFrequency.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edDVBCCarrierFrequency.Name = "edDVBCCarrierFrequency";
            edDVBCCarrierFrequency.Size = new System.Drawing.Size(125, 31);
            edDVBCCarrierFrequency.TabIndex = 46;
            edDVBCCarrierFrequency.Text = "303250";
            // 
            // label292
            // 
            label292.AutoSize = true;
            label292.Location = new System.Drawing.Point(17, 52);
            label292.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label292.Name = "label292";
            label292.Size = new System.Drawing.Size(146, 25);
            label292.TabIndex = 45;
            label292.Text = "Carrier frequency";
            // 
            // btBDADVBCTune
            // 
            btBDADVBCTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btBDADVBCTune.Location = new System.Drawing.Point(10, 357);
            btBDADVBCTune.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btBDADVBCTune.Name = "btBDADVBCTune";
            btBDADVBCTune.Size = new System.Drawing.Size(77, 43);
            btBDADVBCTune.TabIndex = 36;
            btBDADVBCTune.Text = "Tune";
            btBDADVBCTune.UseVisualStyleBackColor = true;
            // 
            // tabPage87
            // 
            tabPage87.Controls.Add(label293);
            tabPage87.Location = new System.Drawing.Point(4, 34);
            tabPage87.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage87.Name = "tabPage87";
            tabPage87.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage87.Size = new System.Drawing.Size(703, 424);
            tabPage87.TabIndex = 3;
            tabPage87.Text = "ATSC";
            tabPage87.UseVisualStyleBackColor = true;
            // 
            // label293
            // 
            label293.AutoSize = true;
            label293.Location = new System.Drawing.Point(17, 22);
            label293.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label293.Name = "label293";
            label293.Size = new System.Drawing.Size(178, 25);
            label293.TabIndex = 0;
            label293.Text = "not implemented yet";
            // 
            // tabPage105
            // 
            tabPage105.Controls.Add(btBDAChannelScanningStart);
            tabPage105.Controls.Add(lvBDAChannels);
            tabPage105.Controls.Add(label342);
            tabPage105.Location = new System.Drawing.Point(4, 34);
            tabPage105.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage105.Name = "tabPage105";
            tabPage105.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage105.Size = new System.Drawing.Size(736, 487);
            tabPage105.TabIndex = 2;
            tabPage105.Text = "Channel scanning";
            tabPage105.UseVisualStyleBackColor = true;
            // 
            // btBDAChannelScanningStart
            // 
            btBDAChannelScanningStart.Location = new System.Drawing.Point(607, 403);
            btBDAChannelScanningStart.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btBDAChannelScanningStart.Name = "btBDAChannelScanningStart";
            btBDAChannelScanningStart.Size = new System.Drawing.Size(93, 43);
            btBDAChannelScanningStart.TabIndex = 2;
            btBDAChannelScanningStart.Text = "Start";
            btBDAChannelScanningStart.UseVisualStyleBackColor = true;
            btBDAChannelScanningStart.Click += (this.btBDAChannelScanningStart_Click);
            // 
            // lvBDAChannels
            // 
            lvBDAChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            lvBDAChannels.Location = new System.Drawing.Point(31, 68);
            lvBDAChannels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            lvBDAChannels.Name = "lvBDAChannels";
            lvBDAChannels.Size = new System.Drawing.Size(665, 319);
            lvBDAChannels.TabIndex = 1;
            lvBDAChannels.UseCompatibleStateImageBehavior = false;
            lvBDAChannels.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Frequency";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Audio PID";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Video PID";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "SID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Symbol rate";
            // 
            // label342
            // 
            label342.AutoSize = true;
            label342.Location = new System.Drawing.Point(27, 38);
            label342.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label342.Name = "label342";
            label342.Size = new System.Drawing.Size(489, 25);
            label342.TabIndex = 0;
            label342.Text = "Please tune to a required frequency or other parameters first";
            // 
            // tabPage49
            // 
            tabPage49.Controls.Add(tabControl20);
            tabPage49.Location = new System.Drawing.Point(4, 34);
            tabPage49.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage49.Name = "tabPage49";
            tabPage49.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage49.Size = new System.Drawing.Size(765, 547);
            tabPage49.TabIndex = 3;
            tabPage49.Text = "Picture-In-Picture";
            tabPage49.UseVisualStyleBackColor = true;
            // 
            // tabControl20
            // 
            tabControl20.Controls.Add(tabPage67);
            tabControl20.Controls.Add(tabPage77);
            tabControl20.Controls.Add(tabPage147);
            tabControl20.Location = new System.Drawing.Point(10, 8);
            tabControl20.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl20.Name = "tabControl20";
            tabControl20.SelectedIndex = 0;
            tabControl20.Size = new System.Drawing.Size(750, 528);
            tabControl20.TabIndex = 0;
            // 
            // tabPage67
            // 
            tabPage67.Controls.Add(tabControl21);
            tabPage67.Location = new System.Drawing.Point(4, 34);
            tabPage67.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage67.Name = "tabPage67";
            tabPage67.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage67.Size = new System.Drawing.Size(742, 490);
            tabPage67.TabIndex = 0;
            tabPage67.Text = "Sources";
            tabPage67.UseVisualStyleBackColor = true;
            // 
            // tabControl21
            // 
            tabControl21.Controls.Add(tabPage78);
            tabControl21.Controls.Add(tabPage79);
            tabControl21.Controls.Add(tabPage80);
            tabControl21.Controls.Add(tabPage100);
            tabControl21.Location = new System.Drawing.Point(10, 12);
            tabControl21.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl21.Name = "tabControl21";
            tabControl21.SelectedIndex = 0;
            tabControl21.Size = new System.Drawing.Size(721, 462);
            tabControl21.TabIndex = 0;
            // 
            // tabPage78
            // 
            tabPage78.Controls.Add(btPIPAddDevice);
            tabPage78.Controls.Add(groupBox30);
            tabPage78.Controls.Add(cbPIPInput);
            tabPage78.Controls.Add(label170);
            tabPage78.Controls.Add(cbPIPFrameRate);
            tabPage78.Controls.Add(label128);
            tabPage78.Controls.Add(cbPIPFormatUseBest);
            tabPage78.Controls.Add(cbPIPFormat);
            tabPage78.Controls.Add(label127);
            tabPage78.Controls.Add(label126);
            tabPage78.Controls.Add(cbPIPDevice);
            tabPage78.Controls.Add(label125);
            tabPage78.Location = new System.Drawing.Point(4, 34);
            tabPage78.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage78.Name = "tabPage78";
            tabPage78.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage78.Size = new System.Drawing.Size(713, 424);
            tabPage78.TabIndex = 0;
            tabPage78.Text = "Video capture device";
            tabPage78.UseVisualStyleBackColor = true;
            // 
            // btPIPAddDevice
            // 
            btPIPAddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btPIPAddDevice.Location = new System.Drawing.Point(19, 347);
            btPIPAddDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPAddDevice.Name = "btPIPAddDevice";
            btPIPAddDevice.Size = new System.Drawing.Size(90, 43);
            btPIPAddDevice.TabIndex = 63;
            btPIPAddDevice.Text = "Add";
            btPIPAddDevice.UseVisualStyleBackColor = true;
            btPIPAddDevice.Click += (this.btPIPAddDevice_Click);
            // 
            // groupBox30
            // 
            groupBox30.Controls.Add(edPIPVidCapHeight);
            groupBox30.Controls.Add(label94);
            groupBox30.Controls.Add(edPIPVidCapWidth);
            groupBox30.Controls.Add(label98);
            groupBox30.Controls.Add(edPIPVidCapTop);
            groupBox30.Controls.Add(label99);
            groupBox30.Controls.Add(edPIPVidCapLeft);
            groupBox30.Controls.Add(label100);
            groupBox30.Location = new System.Drawing.Point(359, 262);
            groupBox30.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox30.Name = "groupBox30";
            groupBox30.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox30.Size = new System.Drawing.Size(340, 138);
            groupBox30.TabIndex = 62;
            groupBox30.TabStop = false;
            groupBox30.Text = "Position";
            // 
            // edPIPVidCapHeight
            // 
            edPIPVidCapHeight.Location = new System.Drawing.Point(250, 88);
            edPIPVidCapHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPVidCapHeight.Name = "edPIPVidCapHeight";
            edPIPVidCapHeight.Size = new System.Drawing.Size(63, 31);
            edPIPVidCapHeight.TabIndex = 40;
            edPIPVidCapHeight.Text = "200";
            edPIPVidCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label94
            // 
            label94.AutoSize = true;
            label94.Location = new System.Drawing.Point(187, 92);
            label94.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label94.Name = "label94";
            label94.Size = new System.Drawing.Size(65, 25);
            label94.TabIndex = 39;
            label94.Text = "Height";
            // 
            // edPIPVidCapWidth
            // 
            edPIPVidCapWidth.Location = new System.Drawing.Point(250, 38);
            edPIPVidCapWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPVidCapWidth.Name = "edPIPVidCapWidth";
            edPIPVidCapWidth.Size = new System.Drawing.Size(63, 31);
            edPIPVidCapWidth.TabIndex = 38;
            edPIPVidCapWidth.Text = "300";
            edPIPVidCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label98
            // 
            label98.AutoSize = true;
            label98.Location = new System.Drawing.Point(187, 42);
            label98.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label98.Name = "label98";
            label98.Size = new System.Drawing.Size(60, 25);
            label98.TabIndex = 37;
            label98.Text = "Width";
            // 
            // edPIPVidCapTop
            // 
            edPIPVidCapTop.Location = new System.Drawing.Point(80, 88);
            edPIPVidCapTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPVidCapTop.Name = "edPIPVidCapTop";
            edPIPVidCapTop.Size = new System.Drawing.Size(63, 31);
            edPIPVidCapTop.TabIndex = 36;
            edPIPVidCapTop.Text = "0";
            edPIPVidCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label99
            // 
            label99.AutoSize = true;
            label99.Location = new System.Drawing.Point(24, 92);
            label99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label99.Name = "label99";
            label99.Size = new System.Drawing.Size(41, 25);
            label99.TabIndex = 35;
            label99.Text = "Top";
            // 
            // edPIPVidCapLeft
            // 
            edPIPVidCapLeft.Location = new System.Drawing.Point(80, 38);
            edPIPVidCapLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPVidCapLeft.Name = "edPIPVidCapLeft";
            edPIPVidCapLeft.Size = new System.Drawing.Size(63, 31);
            edPIPVidCapLeft.TabIndex = 34;
            edPIPVidCapLeft.Text = "0";
            edPIPVidCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label100
            // 
            label100.AutoSize = true;
            label100.Location = new System.Drawing.Point(24, 42);
            label100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label100.Name = "label100";
            label100.Size = new System.Drawing.Size(41, 25);
            label100.TabIndex = 33;
            label100.Text = "Left";
            // 
            // cbPIPInput
            // 
            cbPIPInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPInput.FormattingEnabled = true;
            cbPIPInput.Location = new System.Drawing.Point(141, 182);
            cbPIPInput.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPInput.Name = "cbPIPInput";
            cbPIPInput.Size = new System.Drawing.Size(340, 33);
            cbPIPInput.TabIndex = 61;
            // 
            // label170
            // 
            label170.AutoSize = true;
            label170.Location = new System.Drawing.Point(13, 188);
            label170.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label170.Name = "label170";
            label170.Size = new System.Drawing.Size(54, 25);
            label170.TabIndex = 60;
            label170.Text = "Input";
            // 
            // cbPIPFrameRate
            // 
            cbPIPFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPFrameRate.FormattingEnabled = true;
            cbPIPFrameRate.Location = new System.Drawing.Point(141, 232);
            cbPIPFrameRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPFrameRate.Name = "cbPIPFrameRate";
            cbPIPFrameRate.Size = new System.Drawing.Size(121, 33);
            cbPIPFrameRate.TabIndex = 59;
            // 
            // label128
            // 
            label128.AutoSize = true;
            label128.Location = new System.Drawing.Point(13, 237);
            label128.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label128.Name = "label128";
            label128.Size = new System.Drawing.Size(96, 25);
            label128.TabIndex = 58;
            label128.Text = "Frame rate";
            // 
            // cbPIPFormatUseBest
            // 
            cbPIPFormatUseBest.AutoSize = true;
            cbPIPFormatUseBest.Location = new System.Drawing.Point(493, 132);
            cbPIPFormatUseBest.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPFormatUseBest.Name = "cbPIPFormatUseBest";
            cbPIPFormatUseBest.Size = new System.Drawing.Size(106, 29);
            cbPIPFormatUseBest.TabIndex = 57;
            cbPIPFormatUseBest.Text = "Use best";
            cbPIPFormatUseBest.UseVisualStyleBackColor = true;
            cbPIPFormatUseBest.CheckedChanged += (this.cbPIPFormatUseBest_CheckedChanged);
            // 
            // cbPIPFormat
            // 
            cbPIPFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPFormat.FormattingEnabled = true;
            cbPIPFormat.Location = new System.Drawing.Point(141, 128);
            cbPIPFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPFormat.Name = "cbPIPFormat";
            cbPIPFormat.Size = new System.Drawing.Size(340, 33);
            cbPIPFormat.TabIndex = 56;
            cbPIPFormat.SelectedIndexChanged += (this.cbPIPFormat_SelectedIndexChanged);
            // 
            // label127
            // 
            label127.AutoSize = true;
            label127.Location = new System.Drawing.Point(13, 135);
            label127.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label127.Name = "label127";
            label127.Size = new System.Drawing.Size(117, 25);
            label127.TabIndex = 55;
            label127.Text = "Video format";
            // 
            // label126
            // 
            label126.AutoSize = true;
            label126.Location = new System.Drawing.Point(13, 22);
            label126.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label126.Name = "label126";
            label126.Size = new System.Drawing.Size(309, 25);
            label126.TabIndex = 54;
            label126.Text = "Don't add main video capture device!";
            // 
            // cbPIPDevice
            // 
            cbPIPDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPDevice.FormattingEnabled = true;
            cbPIPDevice.Location = new System.Drawing.Point(141, 78);
            cbPIPDevice.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPDevice.Name = "cbPIPDevice";
            cbPIPDevice.Size = new System.Drawing.Size(340, 33);
            cbPIPDevice.TabIndex = 53;
            cbPIPDevice.SelectedIndexChanged += (this.cbPIPDevice_SelectedIndexChanged);
            // 
            // label125
            // 
            label125.AutoSize = true;
            label125.Location = new System.Drawing.Point(13, 82);
            label125.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label125.Name = "label125";
            label125.Size = new System.Drawing.Size(113, 25);
            label125.TabIndex = 52;
            label125.Text = "Device name";
            // 
            // tabPage79
            // 
            tabPage79.Controls.Add(groupBox31);
            tabPage79.Controls.Add(btPIPAddIPCamera);
            tabPage79.Location = new System.Drawing.Point(4, 34);
            tabPage79.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage79.Name = "tabPage79";
            tabPage79.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage79.Size = new System.Drawing.Size(713, 424);
            tabPage79.TabIndex = 1;
            tabPage79.Text = "IP camera";
            tabPage79.UseVisualStyleBackColor = true;
            // 
            // groupBox31
            // 
            groupBox31.Controls.Add(edPIPIPCapHeight);
            groupBox31.Controls.Add(label101);
            groupBox31.Controls.Add(edPIPIPCapWidth);
            groupBox31.Controls.Add(label102);
            groupBox31.Controls.Add(edPIPIPCapTop);
            groupBox31.Controls.Add(label103);
            groupBox31.Controls.Add(edPIPIPCapLeft);
            groupBox31.Controls.Add(label229);
            groupBox31.Location = new System.Drawing.Point(359, 262);
            groupBox31.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox31.Name = "groupBox31";
            groupBox31.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox31.Size = new System.Drawing.Size(340, 138);
            groupBox31.TabIndex = 63;
            groupBox31.TabStop = false;
            groupBox31.Text = "Position";
            // 
            // edPIPIPCapHeight
            // 
            edPIPIPCapHeight.Location = new System.Drawing.Point(250, 88);
            edPIPIPCapHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPIPCapHeight.Name = "edPIPIPCapHeight";
            edPIPIPCapHeight.Size = new System.Drawing.Size(63, 31);
            edPIPIPCapHeight.TabIndex = 40;
            edPIPIPCapHeight.Text = "200";
            edPIPIPCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label101
            // 
            label101.AutoSize = true;
            label101.Location = new System.Drawing.Point(187, 92);
            label101.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label101.Name = "label101";
            label101.Size = new System.Drawing.Size(65, 25);
            label101.TabIndex = 39;
            label101.Text = "Height";
            // 
            // edPIPIPCapWidth
            // 
            edPIPIPCapWidth.Location = new System.Drawing.Point(250, 38);
            edPIPIPCapWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPIPCapWidth.Name = "edPIPIPCapWidth";
            edPIPIPCapWidth.Size = new System.Drawing.Size(63, 31);
            edPIPIPCapWidth.TabIndex = 38;
            edPIPIPCapWidth.Text = "300";
            edPIPIPCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label102
            // 
            label102.AutoSize = true;
            label102.Location = new System.Drawing.Point(187, 42);
            label102.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label102.Name = "label102";
            label102.Size = new System.Drawing.Size(60, 25);
            label102.TabIndex = 37;
            label102.Text = "Width";
            // 
            // edPIPIPCapTop
            // 
            edPIPIPCapTop.Location = new System.Drawing.Point(80, 88);
            edPIPIPCapTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPIPCapTop.Name = "edPIPIPCapTop";
            edPIPIPCapTop.Size = new System.Drawing.Size(63, 31);
            edPIPIPCapTop.TabIndex = 36;
            edPIPIPCapTop.Text = "0";
            edPIPIPCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label103
            // 
            label103.AutoSize = true;
            label103.Location = new System.Drawing.Point(24, 92);
            label103.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label103.Name = "label103";
            label103.Size = new System.Drawing.Size(41, 25);
            label103.TabIndex = 35;
            label103.Text = "Top";
            // 
            // edPIPIPCapLeft
            // 
            edPIPIPCapLeft.Location = new System.Drawing.Point(80, 38);
            edPIPIPCapLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPIPCapLeft.Name = "edPIPIPCapLeft";
            edPIPIPCapLeft.Size = new System.Drawing.Size(63, 31);
            edPIPIPCapLeft.TabIndex = 34;
            edPIPIPCapLeft.Text = "0";
            edPIPIPCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label229
            // 
            label229.AutoSize = true;
            label229.Location = new System.Drawing.Point(24, 42);
            label229.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label229.Name = "label229";
            label229.Size = new System.Drawing.Size(41, 25);
            label229.TabIndex = 33;
            label229.Text = "Left";
            // 
            // btPIPAddIPCamera
            // 
            btPIPAddIPCamera.Location = new System.Drawing.Point(169, 108);
            btPIPAddIPCamera.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPAddIPCamera.Name = "btPIPAddIPCamera";
            btPIPAddIPCamera.Size = new System.Drawing.Size(363, 43);
            btPIPAddIPCamera.TabIndex = 0;
            btPIPAddIPCamera.Text = "Add using settings from IP camera tab";
            btPIPAddIPCamera.UseVisualStyleBackColor = true;
            btPIPAddIPCamera.Click += (this.btPIPAddIPCamera_Click);
            // 
            // tabPage80
            // 
            tabPage80.Controls.Add(groupBox32);
            tabPage80.Controls.Add(btPIPAddScreenCapture);
            tabPage80.Location = new System.Drawing.Point(4, 34);
            tabPage80.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage80.Name = "tabPage80";
            tabPage80.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage80.Size = new System.Drawing.Size(713, 424);
            tabPage80.TabIndex = 2;
            tabPage80.Text = "Screen source";
            tabPage80.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            groupBox32.Controls.Add(edPIPScreenCapHeight);
            groupBox32.Controls.Add(label256);
            groupBox32.Controls.Add(edPIPScreenCapWidth);
            groupBox32.Controls.Add(label260);
            groupBox32.Controls.Add(edPIPScreenCapTop);
            groupBox32.Controls.Add(label266);
            groupBox32.Controls.Add(edPIPScreenCapLeft);
            groupBox32.Controls.Add(label268);
            groupBox32.Location = new System.Drawing.Point(359, 262);
            groupBox32.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox32.Name = "groupBox32";
            groupBox32.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox32.Size = new System.Drawing.Size(340, 138);
            groupBox32.TabIndex = 63;
            groupBox32.TabStop = false;
            groupBox32.Text = "Position";
            // 
            // edPIPScreenCapHeight
            // 
            edPIPScreenCapHeight.Location = new System.Drawing.Point(250, 88);
            edPIPScreenCapHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPScreenCapHeight.Name = "edPIPScreenCapHeight";
            edPIPScreenCapHeight.Size = new System.Drawing.Size(63, 31);
            edPIPScreenCapHeight.TabIndex = 40;
            edPIPScreenCapHeight.Text = "200";
            edPIPScreenCapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label256
            // 
            label256.AutoSize = true;
            label256.Location = new System.Drawing.Point(187, 92);
            label256.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label256.Name = "label256";
            label256.Size = new System.Drawing.Size(65, 25);
            label256.TabIndex = 39;
            label256.Text = "Height";
            // 
            // edPIPScreenCapWidth
            // 
            edPIPScreenCapWidth.Location = new System.Drawing.Point(250, 38);
            edPIPScreenCapWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPScreenCapWidth.Name = "edPIPScreenCapWidth";
            edPIPScreenCapWidth.Size = new System.Drawing.Size(63, 31);
            edPIPScreenCapWidth.TabIndex = 38;
            edPIPScreenCapWidth.Text = "300";
            edPIPScreenCapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label260
            // 
            label260.AutoSize = true;
            label260.Location = new System.Drawing.Point(187, 42);
            label260.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label260.Name = "label260";
            label260.Size = new System.Drawing.Size(60, 25);
            label260.TabIndex = 37;
            label260.Text = "Width";
            // 
            // edPIPScreenCapTop
            // 
            edPIPScreenCapTop.Location = new System.Drawing.Point(80, 88);
            edPIPScreenCapTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPScreenCapTop.Name = "edPIPScreenCapTop";
            edPIPScreenCapTop.Size = new System.Drawing.Size(63, 31);
            edPIPScreenCapTop.TabIndex = 36;
            edPIPScreenCapTop.Text = "0";
            edPIPScreenCapTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label266
            // 
            label266.AutoSize = true;
            label266.Location = new System.Drawing.Point(24, 92);
            label266.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label266.Name = "label266";
            label266.Size = new System.Drawing.Size(41, 25);
            label266.TabIndex = 35;
            label266.Text = "Top";
            // 
            // edPIPScreenCapLeft
            // 
            edPIPScreenCapLeft.Location = new System.Drawing.Point(80, 38);
            edPIPScreenCapLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPScreenCapLeft.Name = "edPIPScreenCapLeft";
            edPIPScreenCapLeft.Size = new System.Drawing.Size(63, 31);
            edPIPScreenCapLeft.TabIndex = 34;
            edPIPScreenCapLeft.Text = "0";
            edPIPScreenCapLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label268
            // 
            label268.AutoSize = true;
            label268.Location = new System.Drawing.Point(24, 42);
            label268.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label268.Name = "label268";
            label268.Size = new System.Drawing.Size(41, 25);
            label268.TabIndex = 33;
            label268.Text = "Left";
            // 
            // btPIPAddScreenCapture
            // 
            btPIPAddScreenCapture.Location = new System.Drawing.Point(169, 108);
            btPIPAddScreenCapture.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPAddScreenCapture.Name = "btPIPAddScreenCapture";
            btPIPAddScreenCapture.Size = new System.Drawing.Size(363, 43);
            btPIPAddScreenCapture.TabIndex = 1;
            btPIPAddScreenCapture.Text = "Add using settings from Screen source tab";
            btPIPAddScreenCapture.UseVisualStyleBackColor = true;
            btPIPAddScreenCapture.Click += (this.btPIPAddScreenCapture_Click);
            // 
            // tabPage100
            // 
            tabPage100.Controls.Add(groupBox44);
            tabPage100.Controls.Add(btPIPFileSourceAdd);
            tabPage100.Controls.Add(btSelectPIPFile);
            tabPage100.Controls.Add(edPIPFileSoureFilename);
            tabPage100.Controls.Add(label320);
            tabPage100.Location = new System.Drawing.Point(4, 34);
            tabPage100.Name = "tabPage100";
            tabPage100.Padding = new System.Windows.Forms.Padding(3);
            tabPage100.Size = new System.Drawing.Size(713, 424);
            tabPage100.TabIndex = 3;
            tabPage100.Text = "Video file";
            tabPage100.UseVisualStyleBackColor = true;
            // 
            // groupBox44
            // 
            groupBox44.Controls.Add(edPIPFileHeight);
            groupBox44.Controls.Add(label321);
            groupBox44.Controls.Add(edPIPFileWidth);
            groupBox44.Controls.Add(label322);
            groupBox44.Controls.Add(edPIPFileTop);
            groupBox44.Controls.Add(label323);
            groupBox44.Controls.Add(edPIPFileLeft);
            groupBox44.Controls.Add(label324);
            groupBox44.Location = new System.Drawing.Point(363, 268);
            groupBox44.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox44.Name = "groupBox44";
            groupBox44.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox44.Size = new System.Drawing.Size(340, 138);
            groupBox44.TabIndex = 64;
            groupBox44.TabStop = false;
            groupBox44.Text = "Position";
            // 
            // edPIPFileHeight
            // 
            edPIPFileHeight.Location = new System.Drawing.Point(250, 88);
            edPIPFileHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPFileHeight.Name = "edPIPFileHeight";
            edPIPFileHeight.Size = new System.Drawing.Size(63, 31);
            edPIPFileHeight.TabIndex = 40;
            edPIPFileHeight.Text = "200";
            edPIPFileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label321
            // 
            label321.AutoSize = true;
            label321.Location = new System.Drawing.Point(187, 92);
            label321.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label321.Name = "label321";
            label321.Size = new System.Drawing.Size(65, 25);
            label321.TabIndex = 39;
            label321.Text = "Height";
            // 
            // edPIPFileWidth
            // 
            edPIPFileWidth.Location = new System.Drawing.Point(250, 38);
            edPIPFileWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPFileWidth.Name = "edPIPFileWidth";
            edPIPFileWidth.Size = new System.Drawing.Size(63, 31);
            edPIPFileWidth.TabIndex = 38;
            edPIPFileWidth.Text = "300";
            edPIPFileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label322
            // 
            label322.AutoSize = true;
            label322.Location = new System.Drawing.Point(187, 42);
            label322.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label322.Name = "label322";
            label322.Size = new System.Drawing.Size(60, 25);
            label322.TabIndex = 37;
            label322.Text = "Width";
            // 
            // edPIPFileTop
            // 
            edPIPFileTop.Location = new System.Drawing.Point(80, 88);
            edPIPFileTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPFileTop.Name = "edPIPFileTop";
            edPIPFileTop.Size = new System.Drawing.Size(63, 31);
            edPIPFileTop.TabIndex = 36;
            edPIPFileTop.Text = "0";
            edPIPFileTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label323
            // 
            label323.AutoSize = true;
            label323.Location = new System.Drawing.Point(24, 92);
            label323.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label323.Name = "label323";
            label323.Size = new System.Drawing.Size(41, 25);
            label323.TabIndex = 35;
            label323.Text = "Top";
            // 
            // edPIPFileLeft
            // 
            edPIPFileLeft.Location = new System.Drawing.Point(80, 38);
            edPIPFileLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPFileLeft.Name = "edPIPFileLeft";
            edPIPFileLeft.Size = new System.Drawing.Size(63, 31);
            edPIPFileLeft.TabIndex = 34;
            edPIPFileLeft.Text = "0";
            edPIPFileLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label324
            // 
            label324.AutoSize = true;
            label324.Location = new System.Drawing.Point(24, 42);
            label324.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label324.Name = "label324";
            label324.Size = new System.Drawing.Size(41, 25);
            label324.TabIndex = 33;
            label324.Text = "Left";
            // 
            // btPIPFileSourceAdd
            // 
            btPIPFileSourceAdd.Location = new System.Drawing.Point(511, 62);
            btPIPFileSourceAdd.Name = "btPIPFileSourceAdd";
            btPIPFileSourceAdd.Size = new System.Drawing.Size(93, 42);
            btPIPFileSourceAdd.TabIndex = 3;
            btPIPFileSourceAdd.Text = "Add";
            btPIPFileSourceAdd.UseVisualStyleBackColor = true;
            btPIPFileSourceAdd.Click += (this.btPIPFileSourceAdd_Click);
            // 
            // btSelectPIPFile
            // 
            btSelectPIPFile.Location = new System.Drawing.Point(467, 62);
            btSelectPIPFile.Name = "btSelectPIPFile";
            btSelectPIPFile.Size = new System.Drawing.Size(37, 42);
            btSelectPIPFile.TabIndex = 2;
            btSelectPIPFile.Text = "...";
            btSelectPIPFile.UseVisualStyleBackColor = true;
            btSelectPIPFile.Click += (this.btSelectPIPFile_Click);
            // 
            // edPIPFileSoureFilename
            // 
            edPIPFileSoureFilename.Location = new System.Drawing.Point(24, 65);
            edPIPFileSoureFilename.Name = "edPIPFileSoureFilename";
            edPIPFileSoureFilename.Size = new System.Drawing.Size(433, 31);
            edPIPFileSoureFilename.TabIndex = 1;
            // 
            // label320
            // 
            label320.AutoSize = true;
            label320.Location = new System.Drawing.Point(21, 35);
            label320.Name = "label320";
            label320.Size = new System.Drawing.Size(87, 25);
            label320.TabIndex = 0;
            label320.Text = "File name";
            // 
            // tabPage77
            // 
            tabPage77.Controls.Add(cbPIPResizeMode);
            tabPage77.Controls.Add(label317);
            tabPage77.Controls.Add(groupBox34);
            tabPage77.Controls.Add(groupBox33);
            tabPage77.Controls.Add(cbPIPDevices);
            tabPage77.Controls.Add(cbPIPMode);
            tabPage77.Controls.Add(label169);
            tabPage77.Controls.Add(btPIPDevicesClear);
            tabPage77.Controls.Add(label134);
            tabPage77.Controls.Add(groupBox20);
            tabPage77.Location = new System.Drawing.Point(4, 34);
            tabPage77.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage77.Name = "tabPage77";
            tabPage77.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage77.Size = new System.Drawing.Size(742, 490);
            tabPage77.TabIndex = 1;
            tabPage77.Text = "Configuration";
            tabPage77.UseVisualStyleBackColor = true;
            // 
            // cbPIPResizeMode
            // 
            cbPIPResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPResizeMode.FormattingEnabled = true;
            cbPIPResizeMode.Items.AddRange(new object[] { "Nearest neighbor", "Linear", "Cubic", "Lanczos" });
            cbPIPResizeMode.Location = new System.Drawing.Point(387, 372);
            cbPIPResizeMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPResizeMode.Name = "cbPIPResizeMode";
            cbPIPResizeMode.Size = new System.Drawing.Size(313, 33);
            cbPIPResizeMode.TabIndex = 54;
            // 
            // label317
            // 
            label317.AutoSize = true;
            label317.Location = new System.Drawing.Point(381, 332);
            label317.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label317.Name = "label317";
            label317.Size = new System.Drawing.Size(100, 25);
            label317.TabIndex = 53;
            label317.Text = "Resize type";
            // 
            // groupBox34
            // 
            groupBox34.Controls.Add(btPIPSet);
            groupBox34.Controls.Add(tbPIPTransparency);
            groupBox34.Location = new System.Drawing.Point(30, 328);
            groupBox34.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox34.Name = "groupBox34";
            groupBox34.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox34.Size = new System.Drawing.Size(340, 140);
            groupBox34.TabIndex = 52;
            groupBox34.TabStop = false;
            groupBox34.Text = "Source transparency";
            // 
            // btPIPSet
            // 
            btPIPSet.Location = new System.Drawing.Point(250, 53);
            btPIPSet.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPSet.Name = "btPIPSet";
            btPIPSet.Size = new System.Drawing.Size(80, 43);
            btPIPSet.TabIndex = 1;
            btPIPSet.Text = "Set";
            btPIPSet.UseVisualStyleBackColor = true;
            btPIPSet.Click += (this.btPIPSet_Click);
            // 
            // tbPIPTransparency
            // 
            tbPIPTransparency.Location = new System.Drawing.Point(19, 38);
            tbPIPTransparency.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbPIPTransparency.Maximum = 255;
            tbPIPTransparency.Name = "tbPIPTransparency";
            tbPIPTransparency.Size = new System.Drawing.Size(204, 69);
            tbPIPTransparency.TabIndex = 0;
            tbPIPTransparency.Value = 255;
            // 
            // groupBox33
            // 
            groupBox33.Controls.Add(btPIPSetOutputSize);
            groupBox33.Controls.Add(edPIPOutputHeight);
            groupBox33.Controls.Add(label269);
            groupBox33.Controls.Add(edPIPOutputWidth);
            groupBox33.Controls.Add(label271);
            groupBox33.Location = new System.Drawing.Point(387, 135);
            groupBox33.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox33.Name = "groupBox33";
            groupBox33.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox33.Size = new System.Drawing.Size(340, 192);
            groupBox33.TabIndex = 51;
            groupBox33.TabStop = false;
            groupBox33.Text = "Set custom output size";
            // 
            // btPIPSetOutputSize
            // 
            btPIPSetOutputSize.Location = new System.Drawing.Point(100, 138);
            btPIPSetOutputSize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPSetOutputSize.Name = "btPIPSetOutputSize";
            btPIPSetOutputSize.Size = new System.Drawing.Size(123, 43);
            btPIPSetOutputSize.TabIndex = 41;
            btPIPSetOutputSize.Text = "Set";
            btPIPSetOutputSize.UseVisualStyleBackColor = true;
            btPIPSetOutputSize.Click += (this.btPIPSetOutputSize_Click);
            // 
            // edPIPOutputHeight
            // 
            edPIPOutputHeight.Location = new System.Drawing.Point(250, 38);
            edPIPOutputHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPOutputHeight.Name = "edPIPOutputHeight";
            edPIPOutputHeight.Size = new System.Drawing.Size(63, 31);
            edPIPOutputHeight.TabIndex = 38;
            edPIPOutputHeight.Text = "600";
            edPIPOutputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label269
            // 
            label269.AutoSize = true;
            label269.Location = new System.Drawing.Point(187, 42);
            label269.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label269.Name = "label269";
            label269.Size = new System.Drawing.Size(65, 25);
            label269.TabIndex = 37;
            label269.Text = "Height";
            // 
            // edPIPOutputWidth
            // 
            edPIPOutputWidth.Location = new System.Drawing.Point(80, 38);
            edPIPOutputWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPOutputWidth.Name = "edPIPOutputWidth";
            edPIPOutputWidth.Size = new System.Drawing.Size(63, 31);
            edPIPOutputWidth.TabIndex = 34;
            edPIPOutputWidth.Text = "800";
            edPIPOutputWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label271
            // 
            label271.AutoSize = true;
            label271.Location = new System.Drawing.Point(24, 42);
            label271.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label271.Name = "label271";
            label271.Size = new System.Drawing.Size(60, 25);
            label271.TabIndex = 33;
            label271.Text = "Width";
            // 
            // cbPIPDevices
            // 
            cbPIPDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPDevices.FormattingEnabled = true;
            cbPIPDevices.Location = new System.Drawing.Point(110, 72);
            cbPIPDevices.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPDevices.Name = "cbPIPDevices";
            cbPIPDevices.Size = new System.Drawing.Size(405, 33);
            cbPIPDevices.TabIndex = 50;
            // 
            // cbPIPMode
            // 
            cbPIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPIPMode.FormattingEnabled = true;
            cbPIPMode.Items.AddRange(new object[] { "Custom (Specify coordinates for each device)", "Horizontal", "Vertical", "2x2", "Multiple video streams (Use WMV, external profile for multiple video streams)", "Chroma-key" });
            cbPIPMode.Location = new System.Drawing.Point(110, 12);
            cbPIPMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbPIPMode.Name = "cbPIPMode";
            cbPIPMode.Size = new System.Drawing.Size(614, 33);
            cbPIPMode.TabIndex = 49;
            // 
            // label169
            // 
            label169.AutoSize = true;
            label169.Location = new System.Drawing.Point(13, 18);
            label169.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label169.Name = "label169";
            label169.Size = new System.Drawing.Size(59, 25);
            label169.TabIndex = 48;
            label169.Text = "Mode";
            // 
            // btPIPDevicesClear
            // 
            btPIPDevicesClear.Location = new System.Drawing.Point(529, 72);
            btPIPDevicesClear.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPDevicesClear.Name = "btPIPDevicesClear";
            btPIPDevicesClear.Size = new System.Drawing.Size(99, 43);
            btPIPDevicesClear.TabIndex = 46;
            btPIPDevicesClear.Text = "Clear";
            btPIPDevicesClear.UseVisualStyleBackColor = true;
            btPIPDevicesClear.Click += (this.btPIPDevicesClear_Click);
            // 
            // label134
            // 
            label134.AutoSize = true;
            label134.Location = new System.Drawing.Point(13, 78);
            label134.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label134.Name = "label134";
            label134.Size = new System.Drawing.Size(72, 25);
            label134.TabIndex = 43;
            label134.Text = "Devices";
            // 
            // groupBox20
            // 
            groupBox20.Controls.Add(btPIPUpdate);
            groupBox20.Controls.Add(edPIPHeight);
            groupBox20.Controls.Add(label132);
            groupBox20.Controls.Add(edPIPWidth);
            groupBox20.Controls.Add(label133);
            groupBox20.Controls.Add(edPIPTop);
            groupBox20.Controls.Add(label130);
            groupBox20.Controls.Add(edPIPLeft);
            groupBox20.Controls.Add(label131);
            groupBox20.Location = new System.Drawing.Point(30, 135);
            groupBox20.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox20.Name = "groupBox20";
            groupBox20.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox20.Size = new System.Drawing.Size(340, 192);
            groupBox20.TabIndex = 42;
            groupBox20.TabStop = false;
            groupBox20.Text = "Position";
            // 
            // btPIPUpdate
            // 
            btPIPUpdate.Location = new System.Drawing.Point(100, 138);
            btPIPUpdate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btPIPUpdate.Name = "btPIPUpdate";
            btPIPUpdate.Size = new System.Drawing.Size(123, 43);
            btPIPUpdate.TabIndex = 41;
            btPIPUpdate.Text = "Update";
            btPIPUpdate.UseVisualStyleBackColor = true;
            btPIPUpdate.Click += (this.btPIPUpdate_Click);
            // 
            // edPIPHeight
            // 
            edPIPHeight.Location = new System.Drawing.Point(250, 88);
            edPIPHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPHeight.Name = "edPIPHeight";
            edPIPHeight.Size = new System.Drawing.Size(63, 31);
            edPIPHeight.TabIndex = 40;
            edPIPHeight.Text = "200";
            edPIPHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label132
            // 
            label132.AutoSize = true;
            label132.Location = new System.Drawing.Point(187, 92);
            label132.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label132.Name = "label132";
            label132.Size = new System.Drawing.Size(65, 25);
            label132.TabIndex = 39;
            label132.Text = "Height";
            // 
            // edPIPWidth
            // 
            edPIPWidth.Location = new System.Drawing.Point(250, 38);
            edPIPWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPWidth.Name = "edPIPWidth";
            edPIPWidth.Size = new System.Drawing.Size(63, 31);
            edPIPWidth.TabIndex = 38;
            edPIPWidth.Text = "300";
            edPIPWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label133
            // 
            label133.AutoSize = true;
            label133.Location = new System.Drawing.Point(187, 42);
            label133.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label133.Name = "label133";
            label133.Size = new System.Drawing.Size(60, 25);
            label133.TabIndex = 37;
            label133.Text = "Width";
            // 
            // edPIPTop
            // 
            edPIPTop.Location = new System.Drawing.Point(80, 88);
            edPIPTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPTop.Name = "edPIPTop";
            edPIPTop.Size = new System.Drawing.Size(63, 31);
            edPIPTop.TabIndex = 36;
            edPIPTop.Text = "0";
            edPIPTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label130
            // 
            label130.AutoSize = true;
            label130.Location = new System.Drawing.Point(24, 92);
            label130.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label130.Name = "label130";
            label130.Size = new System.Drawing.Size(41, 25);
            label130.TabIndex = 35;
            label130.Text = "Top";
            // 
            // edPIPLeft
            // 
            edPIPLeft.Location = new System.Drawing.Point(80, 38);
            edPIPLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edPIPLeft.Name = "edPIPLeft";
            edPIPLeft.Size = new System.Drawing.Size(63, 31);
            edPIPLeft.TabIndex = 34;
            edPIPLeft.Text = "0";
            edPIPLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label131
            // 
            label131.AutoSize = true;
            label131.Location = new System.Drawing.Point(24, 42);
            label131.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label131.Name = "label131";
            label131.Size = new System.Drawing.Size(41, 25);
            label131.TabIndex = 33;
            label131.Text = "Left";
            // 
            // tabPage147
            // 
            tabPage147.Controls.Add(lbPIPChromaKeyTolerance2);
            tabPage147.Controls.Add(label518);
            tabPage147.Controls.Add(tbPIPChromaKeyTolerance2);
            tabPage147.Controls.Add(lbPIPChromaKeyTolerance1);
            tabPage147.Controls.Add(label515);
            tabPage147.Controls.Add(tbPIPChromaKeyTolerance1);
            tabPage147.Controls.Add(pnPIPChromaKeyColor);
            tabPage147.Controls.Add(label514);
            tabPage147.Location = new System.Drawing.Point(4, 34);
            tabPage147.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage147.Name = "tabPage147";
            tabPage147.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage147.Size = new System.Drawing.Size(742, 490);
            tabPage147.TabIndex = 2;
            tabPage147.Text = "Chroma-key";
            tabPage147.UseVisualStyleBackColor = true;
            // 
            // lbPIPChromaKeyTolerance2
            // 
            lbPIPChromaKeyTolerance2.AutoSize = true;
            lbPIPChromaKeyTolerance2.Location = new System.Drawing.Point(639, 168);
            lbPIPChromaKeyTolerance2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbPIPChromaKeyTolerance2.Name = "lbPIPChromaKeyTolerance2";
            lbPIPChromaKeyTolerance2.Size = new System.Drawing.Size(32, 25);
            lbPIPChromaKeyTolerance2.TabIndex = 35;
            lbPIPChromaKeyTolerance2.Text = "30";
            // 
            // label518
            // 
            label518.AutoSize = true;
            label518.Location = new System.Drawing.Point(421, 108);
            label518.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label518.Name = "label518";
            label518.Size = new System.Drawing.Size(100, 25);
            label518.TabIndex = 34;
            label518.Text = "Tolerance 2";
            // 
            // tbPIPChromaKeyTolerance2
            // 
            tbPIPChromaKeyTolerance2.Location = new System.Drawing.Point(427, 138);
            tbPIPChromaKeyTolerance2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbPIPChromaKeyTolerance2.Maximum = 100;
            tbPIPChromaKeyTolerance2.Minimum = 5;
            tbPIPChromaKeyTolerance2.Name = "tbPIPChromaKeyTolerance2";
            tbPIPChromaKeyTolerance2.Size = new System.Drawing.Size(183, 69);
            tbPIPChromaKeyTolerance2.TabIndex = 33;
            tbPIPChromaKeyTolerance2.TickFrequency = 3;
            tbPIPChromaKeyTolerance2.Value = 30;
            tbPIPChromaKeyTolerance2.Scroll += (this.tbPIPChromaKeyTolerance2_Scroll);
            // 
            // lbPIPChromaKeyTolerance1
            // 
            lbPIPChromaKeyTolerance1.AutoSize = true;
            lbPIPChromaKeyTolerance1.Location = new System.Drawing.Point(250, 168);
            lbPIPChromaKeyTolerance1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbPIPChromaKeyTolerance1.Name = "lbPIPChromaKeyTolerance1";
            lbPIPChromaKeyTolerance1.Size = new System.Drawing.Size(32, 25);
            lbPIPChromaKeyTolerance1.TabIndex = 32;
            lbPIPChromaKeyTolerance1.Text = "10";
            // 
            // label515
            // 
            label515.AutoSize = true;
            label515.Location = new System.Drawing.Point(33, 108);
            label515.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label515.Name = "label515";
            label515.Size = new System.Drawing.Size(100, 25);
            label515.TabIndex = 31;
            label515.Text = "Tolerance 1";
            // 
            // tbPIPChromaKeyTolerance1
            // 
            tbPIPChromaKeyTolerance1.Location = new System.Drawing.Point(39, 138);
            tbPIPChromaKeyTolerance1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tbPIPChromaKeyTolerance1.Maximum = 100;
            tbPIPChromaKeyTolerance1.Minimum = 5;
            tbPIPChromaKeyTolerance1.Name = "tbPIPChromaKeyTolerance1";
            tbPIPChromaKeyTolerance1.Size = new System.Drawing.Size(183, 69);
            tbPIPChromaKeyTolerance1.TabIndex = 30;
            tbPIPChromaKeyTolerance1.TickFrequency = 3;
            tbPIPChromaKeyTolerance1.Value = 10;
            tbPIPChromaKeyTolerance1.Scroll += (this.tbPIPChromaKeyTolerance1_Scroll);
            // 
            // pnPIPChromaKeyColor
            // 
            pnPIPChromaKeyColor.BackColor = System.Drawing.Color.ForestGreen;
            pnPIPChromaKeyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnPIPChromaKeyColor.Location = new System.Drawing.Point(256, 38);
            pnPIPChromaKeyColor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnPIPChromaKeyColor.Name = "pnPIPChromaKeyColor";
            pnPIPChromaKeyColor.Size = new System.Drawing.Size(39, 44);
            pnPIPChromaKeyColor.TabIndex = 29;
            pnPIPChromaKeyColor.Click += (this.pnPIPChromaKeyColor_Click);
            // 
            // label514
            // 
            label514.AutoSize = true;
            label514.Location = new System.Drawing.Point(31, 43);
            label514.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label514.Name = "label514";
            label514.Size = new System.Drawing.Size(174, 25);
            label514.TabIndex = 28;
            label514.Text = "Color (click to select)";
            // 
            // tabPage50
            // 
            tabPage50.Controls.Add(cbMultiscreenDrawOnExternalDisplays);
            tabPage50.Controls.Add(cbFlipHorizontal3);
            tabPage50.Controls.Add(cbFlipVertical3);
            tabPage50.Controls.Add(cbStretch3);
            tabPage50.Controls.Add(cbFlipHorizontal2);
            tabPage50.Controls.Add(cbFlipVertical2);
            tabPage50.Controls.Add(cbStretch2);
            tabPage50.Controls.Add(cbFlipHorizontal1);
            tabPage50.Controls.Add(cbFlipVertical1);
            tabPage50.Controls.Add(cbStretch1);
            tabPage50.Controls.Add(pnScreen3);
            tabPage50.Controls.Add(panel3);
            tabPage50.Controls.Add(pnScreen2);
            tabPage50.Controls.Add(panel2);
            tabPage50.Controls.Add(pnScreen1);
            tabPage50.Controls.Add(cbMultiscreenDrawOnPanels);
            tabPage50.Location = new System.Drawing.Point(4, 34);
            tabPage50.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage50.Name = "tabPage50";
            tabPage50.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage50.Size = new System.Drawing.Size(765, 547);
            tabPage50.TabIndex = 4;
            tabPage50.Text = "Multiscreen";
            tabPage50.UseVisualStyleBackColor = true;
            // 
            // cbMultiscreenDrawOnExternalDisplays
            // 
            cbMultiscreenDrawOnExternalDisplays.AutoSize = true;
            cbMultiscreenDrawOnExternalDisplays.Location = new System.Drawing.Point(300, 32);
            cbMultiscreenDrawOnExternalDisplays.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMultiscreenDrawOnExternalDisplays.Name = "cbMultiscreenDrawOnExternalDisplays";
            cbMultiscreenDrawOnExternalDisplays.Size = new System.Drawing.Size(289, 29);
            cbMultiscreenDrawOnExternalDisplays.TabIndex = 15;
            cbMultiscreenDrawOnExternalDisplays.Text = "Draw video on external displays";
            cbMultiscreenDrawOnExternalDisplays.UseVisualStyleBackColor = true;
            // 
            // cbFlipHorizontal3
            // 
            cbFlipHorizontal3.AutoSize = true;
            cbFlipHorizontal3.Location = new System.Drawing.Point(569, 207);
            cbFlipHorizontal3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipHorizontal3.Name = "cbFlipHorizontal3";
            cbFlipHorizontal3.Size = new System.Drawing.Size(150, 29);
            cbFlipHorizontal3.TabIndex = 14;
            cbFlipHorizontal3.Text = "Flip horizontal";
            cbFlipHorizontal3.UseVisualStyleBackColor = true;
            cbFlipHorizontal3.CheckedChanged += (this.cbStretch3_CheckedChanged);
            // 
            // cbFlipVertical3
            // 
            cbFlipVertical3.AutoSize = true;
            cbFlipVertical3.Location = new System.Drawing.Point(569, 162);
            cbFlipVertical3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipVertical3.Name = "cbFlipVertical3";
            cbFlipVertical3.Size = new System.Drawing.Size(126, 29);
            cbFlipVertical3.TabIndex = 13;
            cbFlipVertical3.Text = "Flip vertical";
            cbFlipVertical3.UseVisualStyleBackColor = true;
            cbFlipVertical3.CheckedChanged += (this.cbStretch3_CheckedChanged);
            // 
            // cbStretch3
            // 
            cbStretch3.AutoSize = true;
            cbStretch3.Location = new System.Drawing.Point(569, 118);
            cbStretch3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbStretch3.Name = "cbStretch3";
            cbStretch3.Size = new System.Drawing.Size(92, 29);
            cbStretch3.TabIndex = 12;
            cbStretch3.Text = "Stretch";
            cbStretch3.UseVisualStyleBackColor = true;
            cbStretch3.CheckedChanged += (this.cbStretch3_CheckedChanged);
            // 
            // cbFlipHorizontal2
            // 
            cbFlipHorizontal2.AutoSize = true;
            cbFlipHorizontal2.Location = new System.Drawing.Point(373, 412);
            cbFlipHorizontal2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipHorizontal2.Name = "cbFlipHorizontal2";
            cbFlipHorizontal2.Size = new System.Drawing.Size(150, 29);
            cbFlipHorizontal2.TabIndex = 11;
            cbFlipHorizontal2.Text = "Flip horizontal";
            cbFlipHorizontal2.UseVisualStyleBackColor = true;
            cbFlipHorizontal2.CheckedChanged += (this.cbStretch2_CheckedChanged);
            // 
            // cbFlipVertical2
            // 
            cbFlipVertical2.AutoSize = true;
            cbFlipVertical2.Location = new System.Drawing.Point(373, 375);
            cbFlipVertical2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipVertical2.Name = "cbFlipVertical2";
            cbFlipVertical2.Size = new System.Drawing.Size(126, 29);
            cbFlipVertical2.TabIndex = 10;
            cbFlipVertical2.Text = "Flip vertical";
            cbFlipVertical2.UseVisualStyleBackColor = true;
            cbFlipVertical2.CheckedChanged += (this.cbStretch2_CheckedChanged);
            // 
            // cbStretch2
            // 
            cbStretch2.AutoSize = true;
            cbStretch2.Location = new System.Drawing.Point(244, 375);
            cbStretch2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbStretch2.Name = "cbStretch2";
            cbStretch2.Size = new System.Drawing.Size(92, 29);
            cbStretch2.TabIndex = 9;
            cbStretch2.Text = "Stretch";
            cbStretch2.UseVisualStyleBackColor = true;
            cbStretch2.CheckedChanged += (this.cbStretch2_CheckedChanged);
            // 
            // cbFlipHorizontal1
            // 
            cbFlipHorizontal1.AutoSize = true;
            cbFlipHorizontal1.Location = new System.Drawing.Point(30, 368);
            cbFlipHorizontal1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipHorizontal1.Name = "cbFlipHorizontal1";
            cbFlipHorizontal1.Size = new System.Drawing.Size(150, 29);
            cbFlipHorizontal1.TabIndex = 8;
            cbFlipHorizontal1.Text = "Flip horizontal";
            cbFlipHorizontal1.UseVisualStyleBackColor = true;
            cbFlipHorizontal1.CheckedChanged += (this.cbStretch1_CheckedChanged);
            // 
            // cbFlipVertical1
            // 
            cbFlipVertical1.AutoSize = true;
            cbFlipVertical1.Location = new System.Drawing.Point(30, 325);
            cbFlipVertical1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbFlipVertical1.Name = "cbFlipVertical1";
            cbFlipVertical1.Size = new System.Drawing.Size(126, 29);
            cbFlipVertical1.TabIndex = 7;
            cbFlipVertical1.Text = "Flip vertical";
            cbFlipVertical1.UseVisualStyleBackColor = true;
            cbFlipVertical1.CheckedChanged += (this.cbStretch1_CheckedChanged);
            // 
            // cbStretch1
            // 
            cbStretch1.AutoSize = true;
            cbStretch1.Location = new System.Drawing.Point(30, 282);
            cbStretch1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbStretch1.Name = "cbStretch1";
            cbStretch1.Size = new System.Drawing.Size(92, 29);
            cbStretch1.TabIndex = 6;
            cbStretch1.Text = "Stretch";
            cbStretch1.UseVisualStyleBackColor = true;
            cbStretch1.CheckedChanged += (this.cbStretch1_CheckedChanged);
            // 
            // pnScreen3
            // 
            pnScreen3.BackColor = System.Drawing.Color.Black;
            pnScreen3.Location = new System.Drawing.Point(553, 253);
            pnScreen3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnScreen3.Name = "pnScreen3";
            pnScreen3.Size = new System.Drawing.Size(200, 192);
            pnScreen3.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.DimGray;
            panel3.Location = new System.Drawing.Point(543, 78);
            panel3.Margin = new System.Windows.Forms.Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(4, 378);
            panel3.TabIndex = 4;
            // 
            // pnScreen2
            // 
            pnScreen2.BackColor = System.Drawing.Color.Black;
            pnScreen2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pnScreen2.Location = new System.Drawing.Point(244, 78);
            pnScreen2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnScreen2.Name = "pnScreen2";
            pnScreen2.Size = new System.Drawing.Size(293, 288);
            pnScreen2.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Gray;
            panel2.Location = new System.Drawing.Point(236, 78);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(4, 378);
            panel2.TabIndex = 2;
            // 
            // pnScreen1
            // 
            pnScreen1.BackColor = System.Drawing.Color.Black;
            pnScreen1.Location = new System.Drawing.Point(30, 78);
            pnScreen1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnScreen1.Name = "pnScreen1";
            pnScreen1.Size = new System.Drawing.Size(200, 192);
            pnScreen1.TabIndex = 1;
            // 
            // cbMultiscreenDrawOnPanels
            // 
            cbMultiscreenDrawOnPanels.AutoSize = true;
            cbMultiscreenDrawOnPanels.Location = new System.Drawing.Point(30, 32);
            cbMultiscreenDrawOnPanels.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMultiscreenDrawOnPanels.Name = "cbMultiscreenDrawOnPanels";
            cbMultiscreenDrawOnPanels.Size = new System.Drawing.Size(210, 29);
            cbMultiscreenDrawOnPanels.TabIndex = 0;
            cbMultiscreenDrawOnPanels.Text = "Draw video on panels";
            cbMultiscreenDrawOnPanels.UseVisualStyleBackColor = true;
            // 
            // tabPage51
            // 
            tabPage51.Controls.Add(tabControl26);
            tabPage51.Location = new System.Drawing.Point(4, 34);
            tabPage51.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage51.Name = "tabPage51";
            tabPage51.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage51.Size = new System.Drawing.Size(765, 547);
            tabPage51.TabIndex = 5;
            tabPage51.Text = "Display";
            tabPage51.UseVisualStyleBackColor = true;
            // 
            // tabControl26
            // 
            tabControl26.Controls.Add(tabPage115);
            tabControl26.Controls.Add(tabPage116);
            tabControl26.Location = new System.Drawing.Point(7, 12);
            tabControl26.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl26.Name = "tabControl26";
            tabControl26.SelectedIndex = 0;
            tabControl26.Size = new System.Drawing.Size(753, 528);
            tabControl26.TabIndex = 0;
            // 
            // tabPage115
            // 
            tabPage115.Controls.Add(pnVideoRendererBGColor);
            tabPage115.Controls.Add(label394);
            tabPage115.Controls.Add(btFullScreen);
            tabPage115.Controls.Add(groupBox28);
            tabPage115.Controls.Add(cbScreenFlipVertical);
            tabPage115.Controls.Add(cbScreenFlipHorizontal);
            tabPage115.Controls.Add(cbStretch);
            tabPage115.Controls.Add(groupBox13);
            tabPage115.Location = new System.Drawing.Point(4, 34);
            tabPage115.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage115.Name = "tabPage115";
            tabPage115.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage115.Size = new System.Drawing.Size(745, 490);
            tabPage115.TabIndex = 0;
            tabPage115.Text = "Main";
            tabPage115.UseVisualStyleBackColor = true;
            // 
            // pnVideoRendererBGColor
            // 
            pnVideoRendererBGColor.BackColor = System.Drawing.Color.Black;
            pnVideoRendererBGColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnVideoRendererBGColor.Location = new System.Drawing.Point(200, 278);
            pnVideoRendererBGColor.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            pnVideoRendererBGColor.Name = "pnVideoRendererBGColor";
            pnVideoRendererBGColor.Size = new System.Drawing.Size(39, 44);
            pnVideoRendererBGColor.TabIndex = 28;
            pnVideoRendererBGColor.Click += (this.pnVideoRendererBGColor_Click);
            // 
            // label394
            // 
            label394.AutoSize = true;
            label394.Location = new System.Drawing.Point(21, 287);
            label394.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label394.Name = "label394";
            label394.Size = new System.Drawing.Size(152, 25);
            label394.TabIndex = 27;
            label394.Text = "Background color";
            // 
            // btFullScreen
            // 
            btFullScreen.Location = new System.Drawing.Point(273, 278);
            btFullScreen.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btFullScreen.Name = "btFullScreen";
            btFullScreen.Size = new System.Drawing.Size(199, 43);
            btFullScreen.TabIndex = 26;
            btFullScreen.Text = "Full screen";
            btFullScreen.UseVisualStyleBackColor = true;
            btFullScreen.Click += (this.btFullScreen_Click);
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
            groupBox28.Location = new System.Drawing.Point(499, 190);
            groupBox28.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox28.Name = "groupBox28";
            groupBox28.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox28.Size = new System.Drawing.Size(199, 248);
            groupBox28.TabIndex = 25;
            groupBox28.TabStop = false;
            groupBox28.Text = "Zoom";
            // 
            // btZoomReset
            // 
            btZoomReset.Location = new System.Drawing.Point(57, 188);
            btZoomReset.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomReset.Name = "btZoomReset";
            btZoomReset.Size = new System.Drawing.Size(84, 43);
            btZoomReset.TabIndex = 7;
            btZoomReset.Text = "Reset";
            btZoomReset.UseVisualStyleBackColor = true;
            btZoomReset.Click += (this.btZoomReset_Click);
            // 
            // btZoomShiftRight
            // 
            btZoomShiftRight.Location = new System.Drawing.Point(141, 62);
            btZoomShiftRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomShiftRight.Name = "btZoomShiftRight";
            btZoomShiftRight.Size = new System.Drawing.Size(36, 92);
            btZoomShiftRight.TabIndex = 5;
            btZoomShiftRight.Text = "R";
            btZoomShiftRight.UseVisualStyleBackColor = true;
            btZoomShiftRight.Click += (this.btZoomShiftRight_Click);
            // 
            // btZoomShiftLeft
            // 
            btZoomShiftLeft.Location = new System.Drawing.Point(21, 62);
            btZoomShiftLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomShiftLeft.Name = "btZoomShiftLeft";
            btZoomShiftLeft.Size = new System.Drawing.Size(36, 92);
            btZoomShiftLeft.TabIndex = 4;
            btZoomShiftLeft.Text = "L";
            btZoomShiftLeft.UseVisualStyleBackColor = true;
            btZoomShiftLeft.Click += (this.btZoomShiftLeft_Click);
            // 
            // btZoomOut
            // 
            btZoomOut.Location = new System.Drawing.Point(101, 88);
            btZoomOut.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomOut.Name = "btZoomOut";
            btZoomOut.Size = new System.Drawing.Size(39, 43);
            btZoomOut.TabIndex = 3;
            btZoomOut.Text = "-";
            btZoomOut.UseVisualStyleBackColor = true;
            btZoomOut.Click += (this.btZoomOut_Click);
            // 
            // btZoomIn
            // 
            btZoomIn.Location = new System.Drawing.Point(59, 88);
            btZoomIn.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomIn.Name = "btZoomIn";
            btZoomIn.Size = new System.Drawing.Size(37, 43);
            btZoomIn.TabIndex = 2;
            btZoomIn.Text = "+";
            btZoomIn.UseVisualStyleBackColor = true;
            btZoomIn.Click += (this.btZoomIn_Click);
            // 
            // btZoomShiftDown
            // 
            btZoomShiftDown.Location = new System.Drawing.Point(57, 132);
            btZoomShiftDown.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomShiftDown.Name = "btZoomShiftDown";
            btZoomShiftDown.Size = new System.Drawing.Size(84, 43);
            btZoomShiftDown.TabIndex = 1;
            btZoomShiftDown.Text = "Down";
            btZoomShiftDown.UseVisualStyleBackColor = true;
            btZoomShiftDown.Click += (this.btZoomShiftDown_Click);
            // 
            // btZoomShiftUp
            // 
            btZoomShiftUp.Location = new System.Drawing.Point(57, 38);
            btZoomShiftUp.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btZoomShiftUp.Name = "btZoomShiftUp";
            btZoomShiftUp.Size = new System.Drawing.Size(84, 43);
            btZoomShiftUp.TabIndex = 0;
            btZoomShiftUp.Text = "Up";
            btZoomShiftUp.UseVisualStyleBackColor = true;
            btZoomShiftUp.Click += (this.btZoomShiftUp_Click);
            // 
            // cbScreenFlipVertical
            // 
            cbScreenFlipVertical.AutoSize = true;
            cbScreenFlipVertical.Location = new System.Drawing.Point(499, 90);
            cbScreenFlipVertical.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbScreenFlipVertical.Name = "cbScreenFlipVertical";
            cbScreenFlipVertical.Size = new System.Drawing.Size(126, 29);
            cbScreenFlipVertical.TabIndex = 18;
            cbScreenFlipVertical.Text = "Flip vertical";
            cbScreenFlipVertical.UseVisualStyleBackColor = true;
            cbScreenFlipVertical.CheckedChanged += (this.cbScreenFlipVertical_CheckedChanged);
            // 
            // cbScreenFlipHorizontal
            // 
            cbScreenFlipHorizontal.AutoSize = true;
            cbScreenFlipHorizontal.Location = new System.Drawing.Point(499, 135);
            cbScreenFlipHorizontal.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbScreenFlipHorizontal.Name = "cbScreenFlipHorizontal";
            cbScreenFlipHorizontal.Size = new System.Drawing.Size(150, 29);
            cbScreenFlipHorizontal.TabIndex = 17;
            cbScreenFlipHorizontal.Text = "Flip horizontal";
            cbScreenFlipHorizontal.UseVisualStyleBackColor = true;
            cbScreenFlipHorizontal.CheckedChanged += (this.cbScreenFlipHorizontal_CheckedChanged);
            // 
            // cbStretch
            // 
            cbStretch.AutoSize = true;
            cbStretch.Location = new System.Drawing.Point(499, 42);
            cbStretch.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbStretch.Name = "cbStretch";
            cbStretch.Size = new System.Drawing.Size(141, 29);
            cbStretch.TabIndex = 16;
            cbStretch.Text = "Stretch video";
            cbStretch.UseVisualStyleBackColor = true;
            cbStretch.CheckedChanged += (this.cbStretch_CheckedChanged);
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(rbDirect2D);
            groupBox13.Controls.Add(rbNone);
            groupBox13.Controls.Add(rbEVR);
            groupBox13.Controls.Add(rbVMR9);
            groupBox13.Location = new System.Drawing.Point(27, 32);
            groupBox13.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox13.Size = new System.Drawing.Size(444, 222);
            groupBox13.TabIndex = 15;
            groupBox13.TabStop = false;
            groupBox13.Text = "Video Renderer";
            // 
            // rbDirect2D
            // 
            rbDirect2D.AutoSize = true;
            rbDirect2D.Location = new System.Drawing.Point(19, 135);
            rbDirect2D.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbDirect2D.Name = "rbDirect2D";
            rbDirect2D.Size = new System.Drawing.Size(106, 29);
            rbDirect2D.TabIndex = 4;
            rbDirect2D.Text = "Direct2D";
            rbDirect2D.UseVisualStyleBackColor = true;
            rbDirect2D.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbNone
            // 
            rbNone.AutoSize = true;
            rbNone.Location = new System.Drawing.Point(19, 178);
            rbNone.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbNone.Name = "rbNone";
            rbNone.Size = new System.Drawing.Size(80, 29);
            rbNone.TabIndex = 3;
            rbNone.Text = "None";
            rbNone.UseVisualStyleBackColor = true;
            rbNone.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbEVR
            // 
            rbEVR.AutoSize = true;
            rbEVR.Checked = true;
            rbEVR.Location = new System.Drawing.Point(19, 90);
            rbEVR.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbEVR.Name = "rbEVR";
            rbEVR.Size = new System.Drawing.Size(309, 29);
            rbEVR.TabIndex = 2;
            rbEVR.TabStop = true;
            rbEVR.Text = "Enhanced Video Renderer (default)";
            rbEVR.UseVisualStyleBackColor = true;
            rbEVR.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // rbVMR9
            // 
            rbVMR9.AutoSize = true;
            rbVMR9.Location = new System.Drawing.Point(19, 48);
            rbVMR9.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbVMR9.Name = "rbVMR9";
            rbVMR9.Size = new System.Drawing.Size(231, 29);
            rbVMR9.TabIndex = 1;
            rbVMR9.Text = "Video Mixing Renderer 9";
            rbVMR9.UseVisualStyleBackColor = true;
            rbVMR9.CheckedChanged += (this.rbVR_CheckedChanged);
            // 
            // tabPage116
            // 
            tabPage116.Controls.Add(label393);
            tabPage116.Controls.Add(cbDirect2DRotate);
            tabPage116.Location = new System.Drawing.Point(4, 34);
            tabPage116.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage116.Name = "tabPage116";
            tabPage116.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage116.Size = new System.Drawing.Size(745, 490);
            tabPage116.TabIndex = 1;
            tabPage116.Text = "Advanced";
            tabPage116.UseVisualStyleBackColor = true;
            // 
            // label393
            // 
            label393.AutoSize = true;
            label393.Location = new System.Drawing.Point(27, 32);
            label393.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label393.Name = "label393";
            label393.Size = new System.Drawing.Size(133, 25);
            label393.TabIndex = 26;
            label393.Text = "Direct2D rotate";
            // 
            // cbDirect2DRotate
            // 
            cbDirect2DRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDirect2DRotate.FormattingEnabled = true;
            cbDirect2DRotate.Items.AddRange(new object[] { "0", "90", "180", "270" });
            cbDirect2DRotate.Location = new System.Drawing.Point(31, 62);
            cbDirect2DRotate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDirect2DRotate.Name = "cbDirect2DRotate";
            cbDirect2DRotate.Size = new System.Drawing.Size(214, 33);
            cbDirect2DRotate.TabIndex = 25;
            cbDirect2DRotate.SelectedIndexChanged += (this.cbDirect2DRotate_SelectedIndexChanged);
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(cbSeparateCaptureBridgeEngine);
            tabPage12.Controls.Add(label376);
            tabPage12.Controls.Add(edSeparateCaptureFileSize);
            tabPage12.Controls.Add(label375);
            tabPage12.Controls.Add(label374);
            tabPage12.Controls.Add(edSeparateCaptureDuration);
            tabPage12.Controls.Add(label373);
            tabPage12.Controls.Add(rbSeparateCaptureSplitBySize);
            tabPage12.Controls.Add(rbSeparateCaptureSplitByDuration);
            tabPage12.Controls.Add(rbSeparateCaptureStartManually);
            tabPage12.Controls.Add(btSeparateCaptureResume);
            tabPage12.Controls.Add(btSeparateCapturePause);
            tabPage12.Controls.Add(groupBox8);
            tabPage12.Controls.Add(btSeparateCaptureStop);
            tabPage12.Controls.Add(btSeparateCaptureStart);
            tabPage12.Controls.Add(cbSeparateCaptureEnabled);
            tabPage12.Controls.Add(label83);
            tabPage12.Controls.Add(label82);
            tabPage12.Location = new System.Drawing.Point(4, 34);
            tabPage12.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage12.Name = "tabPage12";
            tabPage12.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage12.Size = new System.Drawing.Size(765, 547);
            tabPage12.TabIndex = 6;
            tabPage12.Text = "Separate capture";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // cbSeparateCaptureBridgeEngine
            // 
            cbSeparateCaptureBridgeEngine.AutoSize = true;
            cbSeparateCaptureBridgeEngine.Location = new System.Drawing.Point(564, 107);
            cbSeparateCaptureBridgeEngine.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbSeparateCaptureBridgeEngine.Name = "cbSeparateCaptureBridgeEngine";
            cbSeparateCaptureBridgeEngine.Size = new System.Drawing.Size(182, 29);
            cbSeparateCaptureBridgeEngine.TabIndex = 19;
            cbSeparateCaptureBridgeEngine.Text = "Use bridge engine";
            cbSeparateCaptureBridgeEngine.UseVisualStyleBackColor = true;
            // 
            // label376
            // 
            label376.AutoSize = true;
            label376.Location = new System.Drawing.Point(619, 472);
            label376.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label376.Name = "label376";
            label376.Size = new System.Drawing.Size(38, 25);
            label376.TabIndex = 18;
            label376.Text = "MB";
            // 
            // edSeparateCaptureFileSize
            // 
            edSeparateCaptureFileSize.Location = new System.Drawing.Point(520, 462);
            edSeparateCaptureFileSize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edSeparateCaptureFileSize.Name = "edSeparateCaptureFileSize";
            edSeparateCaptureFileSize.Size = new System.Drawing.Size(85, 31);
            edSeparateCaptureFileSize.TabIndex = 17;
            edSeparateCaptureFileSize.Text = "50";
            // 
            // label375
            // 
            label375.AutoSize = true;
            label375.Location = new System.Drawing.Point(399, 468);
            label375.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label375.Name = "label375";
            label375.Size = new System.Drawing.Size(72, 25);
            label375.TabIndex = 16;
            label375.Text = "File size";
            // 
            // label374
            // 
            label374.AutoSize = true;
            label374.Location = new System.Drawing.Point(280, 472);
            label374.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label374.Name = "label374";
            label374.Size = new System.Drawing.Size(36, 25);
            label374.TabIndex = 15;
            label374.Text = "ms";
            // 
            // edSeparateCaptureDuration
            // 
            edSeparateCaptureDuration.Location = new System.Drawing.Point(181, 465);
            edSeparateCaptureDuration.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edSeparateCaptureDuration.Name = "edSeparateCaptureDuration";
            edSeparateCaptureDuration.Size = new System.Drawing.Size(85, 31);
            edSeparateCaptureDuration.TabIndex = 14;
            edSeparateCaptureDuration.Text = "20000";
            // 
            // label373
            // 
            label373.AutoSize = true;
            label373.Location = new System.Drawing.Point(60, 472);
            label373.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label373.Name = "label373";
            label373.Size = new System.Drawing.Size(81, 25);
            label373.TabIndex = 13;
            label373.Text = "Duration";
            // 
            // rbSeparateCaptureSplitBySize
            // 
            rbSeparateCaptureSplitBySize.AutoSize = true;
            rbSeparateCaptureSplitBySize.Location = new System.Drawing.Point(370, 422);
            rbSeparateCaptureSplitBySize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbSeparateCaptureSplitBySize.Name = "rbSeparateCaptureSplitBySize";
            rbSeparateCaptureSplitBySize.Size = new System.Drawing.Size(159, 29);
            rbSeparateCaptureSplitBySize.TabIndex = 12;
            rbSeparateCaptureSplitBySize.Text = "Split by file size";
            rbSeparateCaptureSplitBySize.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureSplitByDuration
            // 
            rbSeparateCaptureSplitByDuration.AutoSize = true;
            rbSeparateCaptureSplitByDuration.Location = new System.Drawing.Point(31, 422);
            rbSeparateCaptureSplitByDuration.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbSeparateCaptureSplitByDuration.Name = "rbSeparateCaptureSplitByDuration";
            rbSeparateCaptureSplitByDuration.Size = new System.Drawing.Size(169, 29);
            rbSeparateCaptureSplitByDuration.TabIndex = 11;
            rbSeparateCaptureSplitByDuration.Text = "Split by duration";
            rbSeparateCaptureSplitByDuration.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureStartManually
            // 
            rbSeparateCaptureStartManually.AutoSize = true;
            rbSeparateCaptureStartManually.Checked = true;
            rbSeparateCaptureStartManually.Location = new System.Drawing.Point(31, 172);
            rbSeparateCaptureStartManually.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            rbSeparateCaptureStartManually.Name = "rbSeparateCaptureStartManually";
            rbSeparateCaptureStartManually.Size = new System.Drawing.Size(149, 29);
            rbSeparateCaptureStartManually.TabIndex = 10;
            rbSeparateCaptureStartManually.TabStop = true;
            rbSeparateCaptureStartManually.Text = "Start manually";
            rbSeparateCaptureStartManually.UseVisualStyleBackColor = true;
            // 
            // btSeparateCaptureResume
            // 
            btSeparateCaptureResume.Location = new System.Drawing.Point(397, 218);
            btSeparateCaptureResume.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSeparateCaptureResume.Name = "btSeparateCaptureResume";
            btSeparateCaptureResume.Size = new System.Drawing.Size(159, 43);
            btSeparateCaptureResume.TabIndex = 9;
            btSeparateCaptureResume.Text = "Resume capture";
            btSeparateCaptureResume.UseVisualStyleBackColor = true;
            btSeparateCaptureResume.Click += (this.btSeparateCaptureResume_Click);
            // 
            // btSeparateCapturePause
            // 
            btSeparateCapturePause.Location = new System.Drawing.Point(229, 218);
            btSeparateCapturePause.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSeparateCapturePause.Name = "btSeparateCapturePause";
            btSeparateCapturePause.Size = new System.Drawing.Size(159, 43);
            btSeparateCapturePause.TabIndex = 8;
            btSeparateCapturePause.Text = "Pause capture";
            btSeparateCapturePause.UseVisualStyleBackColor = true;
            btSeparateCapturePause.Click += (this.btSeparateCapturePause_Click);
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(btSeparateCaptureChangeFilename);
            groupBox8.Controls.Add(edNewFilename);
            groupBox8.Controls.Add(label84);
            groupBox8.Location = new System.Drawing.Point(64, 272);
            groupBox8.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            groupBox8.Size = new System.Drawing.Size(653, 107);
            groupBox8.TabIndex = 7;
            groupBox8.TabStop = false;
            groupBox8.Text = "Change file name on the fly";
            // 
            // btSeparateCaptureChangeFilename
            // 
            btSeparateCaptureChangeFilename.Location = new System.Drawing.Point(543, 38);
            btSeparateCaptureChangeFilename.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSeparateCaptureChangeFilename.Name = "btSeparateCaptureChangeFilename";
            btSeparateCaptureChangeFilename.Size = new System.Drawing.Size(100, 43);
            btSeparateCaptureChangeFilename.TabIndex = 9;
            btSeparateCaptureChangeFilename.Text = "Change";
            btSeparateCaptureChangeFilename.UseVisualStyleBackColor = true;
            btSeparateCaptureChangeFilename.Click += (this.btSeparateCaptureChangeFilename_Click);
            // 
            // edNewFilename
            // 
            edNewFilename.Location = new System.Drawing.Point(163, 42);
            edNewFilename.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edNewFilename.Name = "edNewFilename";
            edNewFilename.Size = new System.Drawing.Size(371, 31);
            edNewFilename.TabIndex = 8;
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Location = new System.Drawing.Point(30, 47);
            label84.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label84.Name = "label84";
            label84.Size = new System.Drawing.Size(124, 25);
            label84.TabIndex = 7;
            label84.Text = "New file name";
            // 
            // btSeparateCaptureStop
            // 
            btSeparateCaptureStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btSeparateCaptureStop.Location = new System.Drawing.Point(564, 218);
            btSeparateCaptureStop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSeparateCaptureStop.Name = "btSeparateCaptureStop";
            btSeparateCaptureStop.Size = new System.Drawing.Size(153, 43);
            btSeparateCaptureStop.TabIndex = 4;
            btSeparateCaptureStop.Text = "Stop capture";
            btSeparateCaptureStop.UseVisualStyleBackColor = true;
            btSeparateCaptureStop.Click += (this.btSeparateCaptureStop_Click);
            // 
            // btSeparateCaptureStart
            // 
            btSeparateCaptureStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btSeparateCaptureStart.Location = new System.Drawing.Point(64, 218);
            btSeparateCaptureStart.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSeparateCaptureStart.Name = "btSeparateCaptureStart";
            btSeparateCaptureStart.Size = new System.Drawing.Size(153, 43);
            btSeparateCaptureStart.TabIndex = 3;
            btSeparateCaptureStart.Text = "Start capture";
            btSeparateCaptureStart.UseVisualStyleBackColor = true;
            btSeparateCaptureStart.Click += (this.btSeparateCaptureStart_Click);
            // 
            // cbSeparateCaptureEnabled
            // 
            cbSeparateCaptureEnabled.AutoSize = true;
            cbSeparateCaptureEnabled.Location = new System.Drawing.Point(31, 107);
            cbSeparateCaptureEnabled.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbSeparateCaptureEnabled.Name = "cbSeparateCaptureEnabled";
            cbSeparateCaptureEnabled.Size = new System.Drawing.Size(101, 29);
            cbSeparateCaptureEnabled.TabIndex = 2;
            cbSeparateCaptureEnabled.Text = "Enabled";
            cbSeparateCaptureEnabled.UseVisualStyleBackColor = true;
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Location = new System.Drawing.Point(27, 65);
            label83.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label83.Name = "label83";
            label83.Size = new System.Drawing.Size(515, 25);
            label83.TabIndex = 1;
            label83.Text = "from preview. You must enable it before you press Start button.";
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Location = new System.Drawing.Point(27, 32);
            label82.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label82.Name = "label82";
            label82.Size = new System.Drawing.Size(727, 25);
            label82.TabIndex = 0;
            label82.Text = "\"Separate capture\" option allows you to start and stop video/audio capture independently";
            // 
            // tabPage88
            // 
            tabPage88.Controls.Add(btMPEGDemuxSettings);
            tabPage88.Controls.Add(cbMPEGDemuxer);
            tabPage88.Controls.Add(label315);
            tabPage88.Controls.Add(btMPEGAudDecSettings);
            tabPage88.Controls.Add(cbMPEGAudioDecoder);
            tabPage88.Controls.Add(label121);
            tabPage88.Controls.Add(btMPEGVidDecSetting);
            tabPage88.Controls.Add(cbMPEGVideoDecoder);
            tabPage88.Controls.Add(label120);
            tabPage88.Location = new System.Drawing.Point(4, 34);
            tabPage88.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage88.Name = "tabPage88";
            tabPage88.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage88.Size = new System.Drawing.Size(765, 547);
            tabPage88.TabIndex = 8;
            tabPage88.Text = "MPEG decoding";
            tabPage88.UseVisualStyleBackColor = true;
            // 
            // btMPEGDemuxSettings
            // 
            btMPEGDemuxSettings.Location = new System.Drawing.Point(477, 242);
            btMPEGDemuxSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btMPEGDemuxSettings.Name = "btMPEGDemuxSettings";
            btMPEGDemuxSettings.Size = new System.Drawing.Size(124, 43);
            btMPEGDemuxSettings.TabIndex = 14;
            btMPEGDemuxSettings.Text = "Settings";
            btMPEGDemuxSettings.UseVisualStyleBackColor = true;
            // 
            // cbMPEGDemuxer
            // 
            cbMPEGDemuxer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMPEGDemuxer.FormattingEnabled = true;
            cbMPEGDemuxer.Location = new System.Drawing.Point(30, 247);
            cbMPEGDemuxer.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMPEGDemuxer.Name = "cbMPEGDemuxer";
            cbMPEGDemuxer.Size = new System.Drawing.Size(434, 33);
            cbMPEGDemuxer.TabIndex = 13;
            // 
            // label315
            // 
            label315.AutoSize = true;
            label315.Location = new System.Drawing.Point(24, 215);
            label315.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label315.Name = "label315";
            label315.Size = new System.Drawing.Size(135, 25);
            label315.TabIndex = 12;
            label315.Text = "MPEG Demuxer";
            // 
            // btMPEGAudDecSettings
            // 
            btMPEGAudDecSettings.Location = new System.Drawing.Point(477, 148);
            btMPEGAudDecSettings.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btMPEGAudDecSettings.Name = "btMPEGAudDecSettings";
            btMPEGAudDecSettings.Size = new System.Drawing.Size(124, 43);
            btMPEGAudDecSettings.TabIndex = 11;
            btMPEGAudDecSettings.Text = "Settings";
            btMPEGAudDecSettings.UseVisualStyleBackColor = true;
            btMPEGAudDecSettings.Click += (this.btMPEGAudDecSettings_Click);
            // 
            // cbMPEGAudioDecoder
            // 
            cbMPEGAudioDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMPEGAudioDecoder.FormattingEnabled = true;
            cbMPEGAudioDecoder.Location = new System.Drawing.Point(30, 152);
            cbMPEGAudioDecoder.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMPEGAudioDecoder.Name = "cbMPEGAudioDecoder";
            cbMPEGAudioDecoder.Size = new System.Drawing.Size(434, 33);
            cbMPEGAudioDecoder.TabIndex = 10;
            cbMPEGAudioDecoder.SelectedIndexChanged += (this.cbMPEGAudioDecoder_SelectedIndexChanged);
            // 
            // label121
            // 
            label121.AutoSize = true;
            label121.Location = new System.Drawing.Point(24, 122);
            label121.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label121.Name = "label121";
            label121.Size = new System.Drawing.Size(132, 25);
            label121.TabIndex = 9;
            label121.Text = "Audio Decoder";
            // 
            // btMPEGVidDecSetting
            // 
            btMPEGVidDecSetting.Location = new System.Drawing.Point(477, 62);
            btMPEGVidDecSetting.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btMPEGVidDecSetting.Name = "btMPEGVidDecSetting";
            btMPEGVidDecSetting.Size = new System.Drawing.Size(124, 43);
            btMPEGVidDecSetting.TabIndex = 8;
            btMPEGVidDecSetting.Text = "Settings";
            btMPEGVidDecSetting.UseVisualStyleBackColor = true;
            btMPEGVidDecSetting.Click += (this.btMPEGVidDecSetting_Click);
            // 
            // cbMPEGVideoDecoder
            // 
            cbMPEGVideoDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMPEGVideoDecoder.FormattingEnabled = true;
            cbMPEGVideoDecoder.Location = new System.Drawing.Point(30, 65);
            cbMPEGVideoDecoder.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbMPEGVideoDecoder.Name = "cbMPEGVideoDecoder";
            cbMPEGVideoDecoder.Size = new System.Drawing.Size(434, 33);
            cbMPEGVideoDecoder.TabIndex = 7;
            cbMPEGVideoDecoder.SelectedIndexChanged += (this.cbMPEGVideoDecoder_SelectedIndexChanged);
            // 
            // label120
            // 
            label120.AutoSize = true;
            label120.Location = new System.Drawing.Point(24, 35);
            label120.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label120.Name = "label120";
            label120.Size = new System.Drawing.Size(130, 25);
            label120.TabIndex = 6;
            label120.Text = "Video Decoder";
            // 
            // tabPage124
            // 
            tabPage124.Controls.Add(tabControl28);
            tabPage124.Location = new System.Drawing.Point(4, 34);
            tabPage124.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage124.Name = "tabPage124";
            tabPage124.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage124.Size = new System.Drawing.Size(765, 547);
            tabPage124.TabIndex = 10;
            tabPage124.Text = "Custom source";
            tabPage124.UseVisualStyleBackColor = true;
            // 
            // tabControl28
            // 
            tabControl28.Controls.Add(tabPage125);
            tabControl28.Controls.Add(tabPage126);
            tabControl28.Location = new System.Drawing.Point(10, 12);
            tabControl28.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabControl28.Name = "tabControl28";
            tabControl28.SelectedIndex = 0;
            tabControl28.Size = new System.Drawing.Size(750, 525);
            tabControl28.TabIndex = 6;
            // 
            // tabPage125
            // 
            tabPage125.Controls.Add(edCustomVideoSourceURL);
            tabPage125.Controls.Add(label516);
            tabPage125.Controls.Add(cbCustomVideoSourceFrameRate);
            tabPage125.Controls.Add(label438);
            tabPage125.Controls.Add(label435);
            tabPage125.Controls.Add(cbCustomVideoSourceFormat);
            tabPage125.Controls.Add(label434);
            tabPage125.Controls.Add(cbCustomVideoSourceFilter);
            tabPage125.Controls.Add(cbCustomVideoSourceCategory);
            tabPage125.Controls.Add(label432);
            tabPage125.Location = new System.Drawing.Point(4, 34);
            tabPage125.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage125.Name = "tabPage125";
            tabPage125.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage125.Size = new System.Drawing.Size(742, 487);
            tabPage125.TabIndex = 0;
            tabPage125.Text = "Video source";
            tabPage125.UseVisualStyleBackColor = true;
            // 
            // edCustomVideoSourceURL
            // 
            edCustomVideoSourceURL.Location = new System.Drawing.Point(23, 252);
            edCustomVideoSourceURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCustomVideoSourceURL.Name = "edCustomVideoSourceURL";
            edCustomVideoSourceURL.Size = new System.Drawing.Size(687, 31);
            edCustomVideoSourceURL.TabIndex = 14;
            // 
            // label516
            // 
            label516.AutoSize = true;
            label516.Location = new System.Drawing.Point(19, 218);
            label516.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label516.Name = "label516";
            label516.Size = new System.Drawing.Size(323, 25);
            label516.TabIndex = 13;
            label516.Text = "File name or URL (if supported by filter)";
            // 
            // cbCustomVideoSourceFrameRate
            // 
            cbCustomVideoSourceFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomVideoSourceFrameRate.FormattingEnabled = true;
            cbCustomVideoSourceFrameRate.Location = new System.Drawing.Point(571, 157);
            cbCustomVideoSourceFrameRate.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomVideoSourceFrameRate.Name = "cbCustomVideoSourceFrameRate";
            cbCustomVideoSourceFrameRate.Size = new System.Drawing.Size(140, 33);
            cbCustomVideoSourceFrameRate.TabIndex = 12;
            // 
            // label438
            // 
            label438.AutoSize = true;
            label438.Location = new System.Drawing.Point(567, 122);
            label438.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label438.Name = "label438";
            label438.Size = new System.Drawing.Size(96, 25);
            label438.TabIndex = 11;
            label438.Text = "Frame rate";
            // 
            // label435
            // 
            label435.AutoSize = true;
            label435.Location = new System.Drawing.Point(19, 28);
            label435.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label435.Name = "label435";
            label435.Size = new System.Drawing.Size(84, 25);
            label435.TabIndex = 10;
            label435.Text = "Category";
            // 
            // cbCustomVideoSourceFormat
            // 
            cbCustomVideoSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomVideoSourceFormat.FormattingEnabled = true;
            cbCustomVideoSourceFormat.Location = new System.Drawing.Point(23, 157);
            cbCustomVideoSourceFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomVideoSourceFormat.Name = "cbCustomVideoSourceFormat";
            cbCustomVideoSourceFormat.Size = new System.Drawing.Size(535, 33);
            cbCustomVideoSourceFormat.TabIndex = 9;
            // 
            // label434
            // 
            label434.AutoSize = true;
            label434.Location = new System.Drawing.Point(19, 122);
            label434.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label434.Name = "label434";
            label434.Size = new System.Drawing.Size(69, 25);
            label434.TabIndex = 8;
            label434.Text = "Format";
            // 
            // cbCustomVideoSourceFilter
            // 
            cbCustomVideoSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomVideoSourceFilter.FormattingEnabled = true;
            cbCustomVideoSourceFilter.Location = new System.Drawing.Point(276, 58);
            cbCustomVideoSourceFilter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomVideoSourceFilter.Name = "cbCustomVideoSourceFilter";
            cbCustomVideoSourceFilter.Size = new System.Drawing.Size(435, 33);
            cbCustomVideoSourceFilter.TabIndex = 7;
            cbCustomVideoSourceFilter.SelectedIndexChanged += (this.cbCustomVideoSourceFilter_SelectedIndexChanged);
            // 
            // cbCustomVideoSourceCategory
            // 
            cbCustomVideoSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomVideoSourceCategory.FormattingEnabled = true;
            cbCustomVideoSourceCategory.Items.AddRange(new object[] { "Video capture source", "DirectShow filter" });
            cbCustomVideoSourceCategory.Location = new System.Drawing.Point(23, 58);
            cbCustomVideoSourceCategory.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomVideoSourceCategory.Name = "cbCustomVideoSourceCategory";
            cbCustomVideoSourceCategory.Size = new System.Drawing.Size(220, 33);
            cbCustomVideoSourceCategory.TabIndex = 6;
            cbCustomVideoSourceCategory.SelectedIndexChanged += (this.cbCustomVideoSourceCategory_SelectedIndexChanged);
            // 
            // label432
            // 
            label432.AutoSize = true;
            label432.Location = new System.Drawing.Point(270, 28);
            label432.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label432.Name = "label432";
            label432.Size = new System.Drawing.Size(59, 25);
            label432.TabIndex = 5;
            label432.Text = "Name";
            // 
            // tabPage126
            // 
            tabPage126.Controls.Add(edCustomAudioSourceURL);
            tabPage126.Controls.Add(label517);
            tabPage126.Controls.Add(label437);
            tabPage126.Controls.Add(cbCustomAudioSourceFormat);
            tabPage126.Controls.Add(label436);
            tabPage126.Controls.Add(cbCustomAudioSourceFilter);
            tabPage126.Controls.Add(label433);
            tabPage126.Controls.Add(cbCustomAudioSourceCategory);
            tabPage126.Location = new System.Drawing.Point(4, 34);
            tabPage126.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage126.Name = "tabPage126";
            tabPage126.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            tabPage126.Size = new System.Drawing.Size(742, 487);
            tabPage126.TabIndex = 1;
            tabPage126.Text = "Audio source";
            tabPage126.UseVisualStyleBackColor = true;
            // 
            // edCustomAudioSourceURL
            // 
            edCustomAudioSourceURL.Location = new System.Drawing.Point(23, 252);
            edCustomAudioSourceURL.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edCustomAudioSourceURL.Name = "edCustomAudioSourceURL";
            edCustomAudioSourceURL.Size = new System.Drawing.Size(687, 31);
            edCustomAudioSourceURL.TabIndex = 16;
            // 
            // label517
            // 
            label517.AutoSize = true;
            label517.Location = new System.Drawing.Point(19, 218);
            label517.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label517.Name = "label517";
            label517.Size = new System.Drawing.Size(323, 25);
            label517.TabIndex = 15;
            label517.Text = "File name or URL (if supported by filter)";
            // 
            // label437
            // 
            label437.AutoSize = true;
            label437.Location = new System.Drawing.Point(19, 28);
            label437.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label437.Name = "label437";
            label437.Size = new System.Drawing.Size(84, 25);
            label437.TabIndex = 12;
            label437.Text = "Category";
            // 
            // cbCustomAudioSourceFormat
            // 
            cbCustomAudioSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomAudioSourceFormat.FormattingEnabled = true;
            cbCustomAudioSourceFormat.Location = new System.Drawing.Point(23, 157);
            cbCustomAudioSourceFormat.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomAudioSourceFormat.Name = "cbCustomAudioSourceFormat";
            cbCustomAudioSourceFormat.Size = new System.Drawing.Size(687, 33);
            cbCustomAudioSourceFormat.TabIndex = 11;
            // 
            // label436
            // 
            label436.AutoSize = true;
            label436.Location = new System.Drawing.Point(19, 122);
            label436.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label436.Name = "label436";
            label436.Size = new System.Drawing.Size(69, 25);
            label436.TabIndex = 10;
            label436.Text = "Format";
            // 
            // cbCustomAudioSourceFilter
            // 
            cbCustomAudioSourceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomAudioSourceFilter.FormattingEnabled = true;
            cbCustomAudioSourceFilter.Location = new System.Drawing.Point(276, 58);
            cbCustomAudioSourceFilter.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomAudioSourceFilter.Name = "cbCustomAudioSourceFilter";
            cbCustomAudioSourceFilter.Size = new System.Drawing.Size(435, 33);
            cbCustomAudioSourceFilter.TabIndex = 8;
            cbCustomAudioSourceFilter.SelectedIndexChanged += (this.cbCustomAudioSourceFilter_SelectedIndexChanged);
            // 
            // label433
            // 
            label433.AutoSize = true;
            label433.Location = new System.Drawing.Point(270, 28);
            label433.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label433.Name = "label433";
            label433.Size = new System.Drawing.Size(59, 25);
            label433.TabIndex = 7;
            label433.Text = "Name";
            // 
            // cbCustomAudioSourceCategory
            // 
            cbCustomAudioSourceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCustomAudioSourceCategory.FormattingEnabled = true;
            cbCustomAudioSourceCategory.Items.AddRange(new object[] { "Audio capture source", "DirectShow filter" });
            cbCustomAudioSourceCategory.Location = new System.Drawing.Point(23, 58);
            cbCustomAudioSourceCategory.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbCustomAudioSourceCategory.Name = "cbCustomAudioSourceCategory";
            cbCustomAudioSourceCategory.Size = new System.Drawing.Size(220, 33);
            cbCustomAudioSourceCategory.TabIndex = 6;
            cbCustomAudioSourceCategory.SelectedIndexChanged += (this.cbCustomAudioSourceCategory_SelectedIndexChanged);
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            openFileDialog3.Filter = "VirtualDub filters|*.vdf";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(13, 114);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(125, 17);
            checkBox1.TabIndex = 104;
            checkBox1.Text = "Enable VU meter Pro";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(401, 1003);
            linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(130, 25);
            linkLabel1.TabIndex = 76;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch tutorials";
            linkLabel1.LinkClicked += (this.linkLabel1_LinkClicked);
            // 
            // btSaveScreenshot
            // 
            btSaveScreenshot.Location = new System.Drawing.Point(339, 1190);
            btSaveScreenshot.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            btSaveScreenshot.Name = "btSaveScreenshot";
            btSaveScreenshot.Size = new System.Drawing.Size(193, 43);
            btSaveScreenshot.TabIndex = 78;
            btSaveScreenshot.Text = "Save snapshot";
            btSaveScreenshot.UseVisualStyleBackColor = true;
            btSaveScreenshot.Click += (this.btSaveScreenshot_Click);
            // 
            // lbTimestamp
            // 
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(16, 1200);
            lbTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(209, 25);
            lbTimestamp.TabIndex = 95;
            lbTimestamp.Text = "Recording time: 00:00:00";
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
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(556, 602);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(764, 582);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 96;
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Checked = true;
            cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            cbTelemetry.Location = new System.Drawing.Point(124, 1000);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(113, 29);
            cbTelemetry.TabIndex = 99;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(19, 1000);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 98;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(17, 1045);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(513, 191);
            mmLog.TabIndex = 97;
            // 
            // cbScreenCapture_HighlightMouseCursor
            // 
            cbScreenCapture_HighlightMouseCursor.AutoSize = true;
            cbScreenCapture_HighlightMouseCursor.Location = new System.Drawing.Point(31, 460);
            cbScreenCapture_HighlightMouseCursor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenCapture_HighlightMouseCursor.Name = "cbScreenCapture_HighlightMouseCursor";
            cbScreenCapture_HighlightMouseCursor.Size = new System.Drawing.Size(224, 29);
            cbScreenCapture_HighlightMouseCursor.TabIndex = 96;
            cbScreenCapture_HighlightMouseCursor.Text = "Highlight mouse cursor";
            cbScreenCapture_HighlightMouseCursor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 1268);
            this.Controls.Add(cbTelemetry);
            this.Controls.Add(cbDebugMode);
            this.Controls.Add(mmLog);
            this.Controls.Add(VideoView1);
            this.Controls.Add(tabControl10);
            this.Controls.Add(btResume);
            this.Controls.Add(btPause);
            this.Controls.Add(cbMode);
            this.Controls.Add(label8);
            this.Controls.Add(btStop);
            this.Controls.Add(btStart);
            this.Controls.Add(tabControl1);
            this.Controls.Add(btSaveScreenshot);
            this.Controls.Add(lbTimestamp);
            this.Controls.Add(linkLabel1);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Main Demo";
            this.Load += (this.Form1_Load);
            this.SizeChanged += (this.Form1_SizeChanged);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabControl17.ResumeLayout(false);
            tabPage68.ResumeLayout(false);
            tabPage68.PerformLayout();
            tabControl7.ResumeLayout(false);
            tabPage29.ResumeLayout(false);
            tabPage29.PerformLayout();
            tabPage42.ResumeLayout(false);
            tabPage42.PerformLayout();
            tabPage91.ResumeLayout(false);
            tabPage91.PerformLayout();
            groupBox37.ResumeLayout(false);
            tabPage92.ResumeLayout(false);
            tabPage92.PerformLayout();
            groupBox40.ResumeLayout(false);
            groupBox40.PerformLayout();
            groupBox39.ResumeLayout(false);
            groupBox39.PerformLayout();
            groupBox38.ResumeLayout(false);
            groupBox38.PerformLayout();
            tabPage102.ResumeLayout(false);
            tabPage102.PerformLayout();
            groupBox45.ResumeLayout(false);
            groupBox45.PerformLayout();
            tabPage114.ResumeLayout(false);
            tabPage114.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbLiveRotationAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage69.ResumeLayout(false);
            tabPage69.PerformLayout();
            tabPage59.ResumeLayout(false);
            tabPage59.PerformLayout();
            tabPage20.ResumeLayout(false);
            tabPage20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbGPUBlur).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPULightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGPUSaturation).EndInit();
            tabPage9.ResumeLayout(false);
            tabPage9.PerformLayout();
            tabPage60.ResumeLayout(false);
            tabPage60.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeySmoothing).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbChromaKeyThresholdSensitivity).EndInit();
            tabPage70.ResumeLayout(false);
            tabPage70.PerformLayout();
            tabControl14.ResumeLayout(false);
            tabPage127.ResumeLayout(false);
            tabPage127.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioTimeshift).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioOutputGainL).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainLFE).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainR).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioInputGainL).EndInit();
            tabPage27.ResumeLayout(false);
            tabPage27.PerformLayout();
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
            tabPage93.ResumeLayout(false);
            tabPage93.PerformLayout();
            groupBox41.ResumeLayout(false);
            groupBox41.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioChannelMapperVolume).EndInit();
            tabPage107.ResumeLayout(false);
            tabPage107.PerformLayout();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            tabControl5.ResumeLayout(false);
            tpWMV.ResumeLayout(false);
            tpWMV.PerformLayout();
            tpRTSP.ResumeLayout(false);
            tpRTSP.PerformLayout();
            tpRTMP.ResumeLayout(false);
            tpRTMP.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tpNDI.ResumeLayout(false);
            tpNDI.PerformLayout();
            tpUDP.ResumeLayout(false);
            tpUDP.PerformLayout();
            tpSSF.ResumeLayout(false);
            tpSSF.PerformLayout();
            tpHLS.ResumeLayout(false);
            tpHLS.PerformLayout();
            tpNSExternal.ResumeLayout(false);
            tpNSExternal.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage28.ResumeLayout(false);
            tabPage28.PerformLayout();
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
            tabPage43.ResumeLayout(false);
            tabPage43.PerformLayout();
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
            tabPage26.ResumeLayout(false);
            tabPage26.PerformLayout();
            tabPage25.ResumeLayout(false);
            tabPage25.PerformLayout();
            tabPage101.ResumeLayout(false);
            tabPage101.PerformLayout();
            tabPage103.ResumeLayout(false);
            tabPage103.PerformLayout();
            tabPage141.ResumeLayout(false);
            tabPage141.PerformLayout();
            TabControl32.ResumeLayout(false);
            TabPage142.ResumeLayout(false);
            TabPage142.PerformLayout();
            TabPage143.ResumeLayout(false);
            TabPage143.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgTagCover).EndInit();
            tabControl10.ResumeLayout(false);
            tabPage46.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            tabPage52.ResumeLayout(false);
            tabPage52.PerformLayout();
            tabPage10.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tabPage14.ResumeLayout(false);
            tabPage14.PerformLayout();
            tabPage15.ResumeLayout(false);
            tabPage15.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage21.ResumeLayout(false);
            tabPage21.PerformLayout();
            tabPage11.ResumeLayout(false);
            groupBox21.ResumeLayout(false);
            groupBox21.PerformLayout();
            groupBox2.ResumeLayout(false);
            tabPage57.ResumeLayout(false);
            tabPage57.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAdjSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAdjBrightness).EndInit();
            tabPage66.ResumeLayout(false);
            tabPage66.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbCCFocus).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbCCZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbCCTilt).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbCCPan).EndInit();
            tabPage63.ResumeLayout(false);
            tabControl19.ResumeLayout(false);
            tabPage96.ResumeLayout(false);
            tabPage96.PerformLayout();
            tabPage97.ResumeLayout(false);
            tabPage97.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAudioBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioVolume).EndInit();
            tabPage98.ResumeLayout(false);
            tabPage98.PerformLayout();
            tabPage112.ResumeLayout(false);
            tabPage112.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterBoost).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVUMeterAmplification).EndInit();
            tabPage99.ResumeLayout(false);
            tabPage99.PerformLayout();
            tabPage47.ResumeLayout(false);
            tabPage47.PerformLayout();
            tabPage48.ResumeLayout(false);
            tabControl15.ResumeLayout(false);
            tabPage144.ResumeLayout(false);
            tabPage144.PerformLayout();
            tabPage146.ResumeLayout(false);
            tabPage146.PerformLayout();
            tabPage145.ResumeLayout(false);
            tabPage145.PerformLayout();
            groupBox42.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage81.ResumeLayout(false);
            tabControl22.ResumeLayout(false);
            tabPage82.ResumeLayout(false);
            tabPage82.PerformLayout();
            tabPage83.ResumeLayout(false);
            tabControl23.ResumeLayout(false);
            tabPage84.ResumeLayout(false);
            tabPage84.PerformLayout();
            tabPage85.ResumeLayout(false);
            tabPage85.PerformLayout();
            tabPage86.ResumeLayout(false);
            groupBox35.ResumeLayout(false);
            groupBox35.PerformLayout();
            groupBox36.ResumeLayout(false);
            groupBox36.PerformLayout();
            tabPage87.ResumeLayout(false);
            tabPage87.PerformLayout();
            tabPage105.ResumeLayout(false);
            tabPage105.PerformLayout();
            tabPage49.ResumeLayout(false);
            tabControl20.ResumeLayout(false);
            tabPage67.ResumeLayout(false);
            tabControl21.ResumeLayout(false);
            tabPage78.ResumeLayout(false);
            tabPage78.PerformLayout();
            groupBox30.ResumeLayout(false);
            groupBox30.PerformLayout();
            tabPage79.ResumeLayout(false);
            groupBox31.ResumeLayout(false);
            groupBox31.PerformLayout();
            tabPage80.ResumeLayout(false);
            groupBox32.ResumeLayout(false);
            groupBox32.PerformLayout();
            tabPage100.ResumeLayout(false);
            tabPage100.PerformLayout();
            groupBox44.ResumeLayout(false);
            groupBox44.PerformLayout();
            tabPage77.ResumeLayout(false);
            tabPage77.PerformLayout();
            groupBox34.ResumeLayout(false);
            groupBox34.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPIPTransparency).EndInit();
            groupBox33.ResumeLayout(false);
            groupBox33.PerformLayout();
            groupBox20.ResumeLayout(false);
            groupBox20.PerformLayout();
            tabPage147.ResumeLayout(false);
            tabPage147.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPIPChromaKeyTolerance2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPIPChromaKeyTolerance1).EndInit();
            tabPage50.ResumeLayout(false);
            tabPage50.PerformLayout();
            tabPage51.ResumeLayout(false);
            tabControl26.ResumeLayout(false);
            tabPage115.ResumeLayout(false);
            tabPage115.PerformLayout();
            groupBox28.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            tabPage116.ResumeLayout(false);
            tabPage116.PerformLayout();
            tabPage12.ResumeLayout(false);
            tabPage12.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            tabPage88.ResumeLayout(false);
            tabPage88.PerformLayout();
            tabPage124.ResumeLayout(false);
            tabControl28.ResumeLayout(false);
            tabPage125.ResumeLayout(false);
            tabPage125.PerformLayout();
            tabPage126.ResumeLayout(false);
            tabPage126.PerformLayout();
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
        private VisioForge.Core.UI.WinForms.PeakMeterCtrl peakMeterCtrl1;
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
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGDefault;
        private System.Windows.Forms.RadioButton rbNetworkSSFFMPEGCustom;
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
        private System.Windows.Forms.Button btVirtualCameraRegister;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.LinkLabel llXiphX64;
        private System.Windows.Forms.LinkLabel llXiphX86;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox edIcecastURL;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.CheckBox cbNetworkIcecastFFMPEGUsePipes;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.ComboBox cbDecklinkOutputVideoRenderer;
        private System.Windows.Forms.ComboBox cbDecklinkOutputAudioRenderer;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.CheckBox cbScrollingText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbNetworkRTMPGeneric;
        private System.Windows.Forms.TextBox edNetworkRTMPFacebook;
        private System.Windows.Forms.RadioButton rbNetworkRTMPFacebook;
        private System.Windows.Forms.TextBox edNetworkRTMPYouTube;
        private System.Windows.Forms.RadioButton rbNetworkRTMPYouTube;
        private System.Windows.Forms.TextBox edNetworkRTMPURL;
        private System.Windows.Forms.Label label368;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox edMJPEGPort;
        private System.Windows.Forms.Label label72;
        private global::System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbScreenCapture_HighlightMouseCursor;
    }
}

