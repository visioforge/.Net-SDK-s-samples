namespace Main_Demo
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

            _player?.Dispose();
            _player = null;

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
            this.tmPosition = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbTimeline = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.edFilenameOrURL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.cbSubtitlesCustomSettings = new System.Windows.Forms.CheckBox();
            this.cbSubtitlesEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.cbRTSPProtocol = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.lbRTSPLatency = new System.Windows.Forms.Label();
            this.tbRTSPLatency = new System.Windows.Forms.TrackBar();
            this.label53 = new System.Windows.Forms.Label();
            this.lbRTSPUDPBufferSize = new System.Windows.Forms.Label();
            this.tbRTSPUDPBufferSize = new System.Windows.Forms.TrackBar();
            this.label52 = new System.Windows.Forms.Label();
            this.lbRTSPRTPBlockSize = new System.Windows.Forms.Label();
            this.tbRTSPRTPBlockSize = new System.Windows.Forms.TrackBar();
            this.label49 = new System.Windows.Forms.Label();
            this.edRTSPPassword = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.edRTSPUserName = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btReadInfo = new System.Windows.Forms.Button();
            this.mmInfo = new System.Windows.Forms.TextBox();
            this.btReadTags = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbAudioStream = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.cbPlayAudio = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.tabControl18 = new System.Windows.Forms.TabControl();
            this.tabPage71 = new System.Windows.Forms.TabPage();
            this.label231 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.tbAudAmplifyAmp = new System.Windows.Forms.TrackBar();
            this.label95 = new System.Windows.Forms.Label();
            this.cbAudAmplifyEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage72 = new System.Windows.Forms.TabPage();
            this.btAudEqUpdate = new System.Windows.Forms.Button();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAudBalanceLevel = new System.Windows.Forms.TrackBar();
            this.cbAudBalanceEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lbAudEchoFeedback = new System.Windows.Forms.Label();
            this.tbAudEchoFeedback = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.lbAudEchoIntensity = new System.Windows.Forms.Label();
            this.tbAudEchoIntensity = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.lbAudEchoDelay = new System.Windows.Forms.Label();
            this.tbAudEchoDelay = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAudEchoEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.cbResizeMethod = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbResizeLetterbox = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.edResizeHeight = new System.Windows.Forms.TextBox();
            this.edResizeWidth = new System.Windows.Forms.TextBox();
            this.cbResizeEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label201 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tbVideoContrast = new System.Windows.Forms.TrackBar();
            this.tbVideoHue = new System.Windows.Forms.TrackBar();
            this.tbVideoBrightness = new System.Windows.Forms.TrackBar();
            this.tbVideoSaturation = new System.Windows.Forms.TrackBar();
            this.cbVideoBalanceEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.btTextOverlayUpdate = new System.Windows.Forms.Button();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.tbTextOverlayY = new System.Windows.Forms.TrackBar();
            this.label42 = new System.Windows.Forms.Label();
            this.tbTextOverlayX = new System.Windows.Forms.TrackBar();
            this.label41 = new System.Windows.Forms.Label();
            this.cbTextOverlayLineAlign = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cbTextOverlayHAlign = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbTextOverlayVAlign = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.edTextOverlayText = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cbTextOverlayMode = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.cbTextOverlayFontWeight = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnTextOverlayColor = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.cbTextOverlayAutosize = new System.Windows.Forms.CheckBox();
            this.cbTextOverlayFontStyle = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cbTextOverlayFontWrapMode = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cbTextOverlayFontSize = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cbTextOverlayFontName = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cbTextOverlayEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.tbImageOverlayAlpha = new System.Windows.Forms.TrackBar();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.edImageOverlayY = new System.Windows.Forms.TextBox();
            this.edImageOverlayX = new System.Windows.Forms.TextBox();
            this.btImageOverlayOpen = new System.Windows.Forms.Button();
            this.edImageOverlayFilename = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.cbImageOverlayEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.cbColorEffect = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbColorEffectEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.cbFlipRotate = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbFlipRotateEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.cbDeinterlaceDropOrphans = new System.Windows.Forms.CheckBox();
            this.cbDeinterlaceIgnoreObscure = new System.Windows.Forms.CheckBox();
            this.cbDeinterlaceLocking = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbDeinterlaceMode = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbDeinterlaceFieldLayout = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbDeinterlaceFields = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbDeinterlaceMethod = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbDeinterlaceEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.tbGaussianBlur = new System.Windows.Forms.TrackBar();
            this.cbGaussianBlurEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.cbFishEyeEnabled = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label505 = new System.Windows.Forms.Label();
            this.rbMotionDetectionProcessor = new System.Windows.Forms.ComboBox();
            this.label389 = new System.Windows.Forms.Label();
            this.rbMotionDetectionDetector = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.pbAFMotionLevel = new System.Windows.Forms.ProgressBar();
            this.cbMotionDetection = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.edBarcodeMetadata = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.cbBarcodeType = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.btBarcodeReset = new System.Windows.Forms.Button();
            this.edBarcode = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.cbBarcodeDetectionEnabled = new System.Windows.Forms.CheckBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btSaveSnapshot = new System.Windows.Forms.Button();
            this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.volumeMeter2 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.volumeMeter1 = new VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter();
            this.btPrevFrame = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage24.SuspendLayout();
            this.tabPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPLatency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPUDPBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPRTPBlockSize)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudBalanceLevel)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoDelay)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoSaturation)).BeginInit();
            this.tabPage17.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTextOverlayY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTextOverlayX)).BeginInit();
            this.tabPage19.SuspendLayout();
            this.tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageOverlayAlpha)).BeginInit();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGaussianBlur)).BeginInit();
            this.tabPage16.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmPosition
            // 
            this.tmPosition.Interval = 500;
            this.tmPosition.Tick += new System.EventHandler(this.tmPosition_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btPrevFrame);
            this.groupBox2.Controls.Add(this.btNextFrame);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.lbSpeed);
            this.groupBox2.Controls.Add(this.lbTimeline);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(612, 798);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(759, 166);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = new System.Drawing.Point(595, 107);
            this.btNextFrame.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btNextFrame.Name = "btNextFrame";
            this.btNextFrame.Size = new System.Drawing.Size(137, 42);
            this.btNextFrame.TabIndex = 8;
            this.btNextFrame.Text = "Next frame";
            this.btNextFrame.UseVisualStyleBackColor = true;
            this.btNextFrame.Click += new System.EventHandler(this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(330, 107);
            this.btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(84, 42);
            this.btStop.TabIndex = 7;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(224, 107);
            this.btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(95, 42);
            this.btPause.TabIndex = 6;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(100, 107);
            this.btResume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(112, 42);
            this.btResume.TabIndex = 5;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(11, 107);
            this.btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(78, 42);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(589, 50);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbSpeed.Maximum = 35;
            this.tbSpeed.Minimum = -25;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(164, 80);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(590, 20);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(108, 25);
            this.lbSpeed.TabIndex = 2;
            this.lbSpeed.Text = "Speed: 1.0";
            // 
            // lbTimeline
            // 
            this.lbTimeline.AutoSize = true;
            this.lbTimeline.Location = new System.Drawing.Point(401, 50);
            this.lbTimeline.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTimeline.Name = "lbTimeline";
            this.lbTimeline.Size = new System.Drawing.Size(174, 25);
            this.lbTimeline.TabIndex = 1;
            this.lbTimeline.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(11, 35);
            this.tbTimeline.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(379, 80);
            this.tbTimeline.TabIndex = 0;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Location = new System.Drawing.Point(612, 46);
            this.edFilenameOrURL.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edFilenameOrURL.Name = "edFilenameOrURL";
            this.edFilenameOrURL.Size = new System.Drawing.Size(703, 29);
            this.edFilenameOrURL.TabIndex = 19;
            this.edFilenameOrURL.Text = "c:\\samples\\!video_with_pts.mp4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(606, 17);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 25);
            this.label14.TabIndex = 18;
            this.label14.Text = "File name or URL";
            // 
            // btSelectFile
            // 
            this.btSelectFile.Location = new System.Drawing.Point(1330, 42);
            this.btSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(42, 42);
            this.btSelectFile.TabIndex = 23;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage21);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Location = new System.Drawing.Point(22, 22);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 960);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.tabControl6);
            this.tabPage21.Location = new System.Drawing.Point(4, 33);
            this.tabPage21.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage21.Size = new System.Drawing.Size(566, 923);
            this.tabPage21.TabIndex = 4;
            this.tabPage21.Text = "Source settings";
            this.tabPage21.UseVisualStyleBackColor = true;
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage24);
            this.tabControl6.Controls.Add(this.tabPage22);
            this.tabControl6.Controls.Add(this.tabPage23);
            this.tabControl6.Location = new System.Drawing.Point(11, 11);
            this.tabControl6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(538, 890);
            this.tabControl6.TabIndex = 0;
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.cbSubtitlesCustomSettings);
            this.tabPage24.Controls.Add(this.cbSubtitlesEnabled);
            this.tabPage24.Location = new System.Drawing.Point(4, 33);
            this.tabPage24.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage24.Size = new System.Drawing.Size(530, 853);
            this.tabPage24.TabIndex = 2;
            this.tabPage24.Text = "Subtitles";
            this.tabPage24.UseVisualStyleBackColor = true;
            // 
            // cbSubtitlesCustomSettings
            // 
            this.cbSubtitlesCustomSettings.AutoSize = true;
            this.cbSubtitlesCustomSettings.Location = new System.Drawing.Point(29, 72);
            this.cbSubtitlesCustomSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbSubtitlesCustomSettings.Name = "cbSubtitlesCustomSettings";
            this.cbSubtitlesCustomSettings.Size = new System.Drawing.Size(469, 29);
            this.cbSubtitlesCustomSettings.TabIndex = 1;
            this.cbSubtitlesCustomSettings.Text = "Use custom font settings from the Text overlay tab";
            this.cbSubtitlesCustomSettings.UseVisualStyleBackColor = true;
            this.cbSubtitlesCustomSettings.CheckedChanged += new System.EventHandler(this.cbSubtitlesCustomSettings_CheckedChanged);
            // 
            // cbSubtitlesEnabled
            // 
            this.cbSubtitlesEnabled.AutoSize = true;
            this.cbSubtitlesEnabled.Checked = true;
            this.cbSubtitlesEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubtitlesEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbSubtitlesEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbSubtitlesEnabled.Name = "cbSubtitlesEnabled";
            this.cbSubtitlesEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbSubtitlesEnabled.TabIndex = 0;
            this.cbSubtitlesEnabled.Text = "Enabled";
            this.cbSubtitlesEnabled.UseVisualStyleBackColor = true;
            this.cbSubtitlesEnabled.CheckedChanged += new System.EventHandler(this.cbSubtitlesEnabled_CheckedChanged);
            // 
            // tabPage22
            // 
            this.tabPage22.Controls.Add(this.cbRTSPProtocol);
            this.tabPage22.Controls.Add(this.label50);
            this.tabPage22.Controls.Add(this.lbRTSPLatency);
            this.tabPage22.Controls.Add(this.tbRTSPLatency);
            this.tabPage22.Controls.Add(this.label53);
            this.tabPage22.Controls.Add(this.lbRTSPUDPBufferSize);
            this.tabPage22.Controls.Add(this.tbRTSPUDPBufferSize);
            this.tabPage22.Controls.Add(this.label52);
            this.tabPage22.Controls.Add(this.lbRTSPRTPBlockSize);
            this.tabPage22.Controls.Add(this.tbRTSPRTPBlockSize);
            this.tabPage22.Controls.Add(this.label49);
            this.tabPage22.Controls.Add(this.edRTSPPassword);
            this.tabPage22.Controls.Add(this.label48);
            this.tabPage22.Controls.Add(this.edRTSPUserName);
            this.tabPage22.Controls.Add(this.label47);
            this.tabPage22.Location = new System.Drawing.Point(4, 33);
            this.tabPage22.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage22.Size = new System.Drawing.Size(530, 853);
            this.tabPage22.TabIndex = 0;
            this.tabPage22.Text = "RTSP";
            this.tabPage22.UseVisualStyleBackColor = true;
            // 
            // cbRTSPProtocol
            // 
            this.cbRTSPProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRTSPProtocol.FormattingEnabled = true;
            this.cbRTSPProtocol.Items.AddRange(new object[] {
            "Auto",
            "TCP",
            "UDP",
            "HTTP over RTSP"});
            this.cbRTSPProtocol.Location = new System.Drawing.Point(29, 644);
            this.cbRTSPProtocol.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbRTSPProtocol.Name = "cbRTSPProtocol";
            this.cbRTSPProtocol.Size = new System.Drawing.Size(459, 32);
            this.cbRTSPProtocol.TabIndex = 14;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(24, 614);
            this.label50.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(93, 25);
            this.label50.TabIndex = 13;
            this.label50.Text = "Protocols";
            // 
            // lbRTSPLatency
            // 
            this.lbRTSPLatency.AutoSize = true;
            this.lbRTSPLatency.Location = new System.Drawing.Point(392, 476);
            this.lbRTSPLatency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRTSPLatency.Name = "lbRTSPLatency";
            this.lbRTSPLatency.Size = new System.Drawing.Size(45, 25);
            this.lbRTSPLatency.TabIndex = 12;
            this.lbRTSPLatency.Text = "200";
            // 
            // tbRTSPLatency
            // 
            this.tbRTSPLatency.Location = new System.Drawing.Point(29, 506);
            this.tbRTSPLatency.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbRTSPLatency.Maximum = 2000;
            this.tbRTSPLatency.Name = "tbRTSPLatency";
            this.tbRTSPLatency.Size = new System.Drawing.Size(462, 80);
            this.tbRTSPLatency.TabIndex = 11;
            this.tbRTSPLatency.TickFrequency = 20;
            this.tbRTSPLatency.Value = 200;
            this.tbRTSPLatency.Scroll += new System.EventHandler(this.tbRTSPLatency_Scroll);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(24, 476);
            this.label53.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(126, 25);
            this.label53.TabIndex = 10;
            this.label53.Text = "Latency (ms)";
            // 
            // lbRTSPUDPBufferSize
            // 
            this.lbRTSPUDPBufferSize.AutoSize = true;
            this.lbRTSPUDPBufferSize.Location = new System.Drawing.Point(392, 336);
            this.lbRTSPUDPBufferSize.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRTSPUDPBufferSize.Name = "lbRTSPUDPBufferSize";
            this.lbRTSPUDPBufferSize.Size = new System.Drawing.Size(45, 25);
            this.lbRTSPUDPBufferSize.TabIndex = 9;
            this.lbRTSPUDPBufferSize.Text = "512";
            // 
            // tbRTSPUDPBufferSize
            // 
            this.tbRTSPUDPBufferSize.Location = new System.Drawing.Point(29, 366);
            this.tbRTSPUDPBufferSize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbRTSPUDPBufferSize.Maximum = 512;
            this.tbRTSPUDPBufferSize.Name = "tbRTSPUDPBufferSize";
            this.tbRTSPUDPBufferSize.Size = new System.Drawing.Size(462, 80);
            this.tbRTSPUDPBufferSize.SmallChange = 4;
            this.tbRTSPUDPBufferSize.TabIndex = 8;
            this.tbRTSPUDPBufferSize.TickFrequency = 10;
            this.tbRTSPUDPBufferSize.Value = 512;
            this.tbRTSPUDPBufferSize.Scroll += new System.EventHandler(this.tbRTSPUDPBufferSize_Scroll);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(24, 336);
            this.label52.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(193, 25);
            this.label52.TabIndex = 7;
            this.label52.Text = "UDP buffer size (KB)";
            // 
            // lbRTSPRTPBlockSize
            // 
            this.lbRTSPRTPBlockSize.AutoSize = true;
            this.lbRTSPRTPBlockSize.Location = new System.Drawing.Point(392, 198);
            this.lbRTSPRTPBlockSize.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRTSPRTPBlockSize.Name = "lbRTSPRTPBlockSize";
            this.lbRTSPRTPBlockSize.Size = new System.Drawing.Size(23, 25);
            this.lbRTSPRTPBlockSize.TabIndex = 6;
            this.lbRTSPRTPBlockSize.Text = "0";
            // 
            // tbRTSPRTPBlockSize
            // 
            this.tbRTSPRTPBlockSize.Location = new System.Drawing.Point(29, 227);
            this.tbRTSPRTPBlockSize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbRTSPRTPBlockSize.Maximum = 64;
            this.tbRTSPRTPBlockSize.Name = "tbRTSPRTPBlockSize";
            this.tbRTSPRTPBlockSize.Size = new System.Drawing.Size(462, 80);
            this.tbRTSPRTPBlockSize.SmallChange = 4;
            this.tbRTSPRTPBlockSize.TabIndex = 5;
            this.tbRTSPRTPBlockSize.TickFrequency = 4;
            this.tbRTSPRTPBlockSize.Scroll += new System.EventHandler(this.tbRTSPRTPBlockSize_Scroll);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(24, 198);
            this.label49.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(271, 25);
            this.label49.TabIndex = 4;
            this.label49.Text = "RTP block size (KB, 0 is auto)";
            // 
            // edRTSPPassword
            // 
            this.edRTSPPassword.Location = new System.Drawing.Point(29, 138);
            this.edRTSPPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edRTSPPassword.Name = "edRTSPPassword";
            this.edRTSPPassword.Size = new System.Drawing.Size(459, 29);
            this.edRTSPPassword.TabIndex = 3;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(24, 109);
            this.label48.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(98, 25);
            this.label48.TabIndex = 2;
            this.label48.Text = "Password";
            // 
            // edRTSPUserName
            // 
            this.edRTSPUserName.Location = new System.Drawing.Point(29, 54);
            this.edRTSPUserName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edRTSPUserName.Name = "edRTSPUserName";
            this.edRTSPUserName.Size = new System.Drawing.Size(459, 29);
            this.edRTSPUserName.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(24, 24);
            this.label47.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(107, 25);
            this.label47.TabIndex = 0;
            this.label47.Text = "User name";
            // 
            // tabPage23
            // 
            this.tabPage23.Location = new System.Drawing.Point(4, 33);
            this.tabPage23.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage23.Name = "tabPage23";
            this.tabPage23.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage23.Size = new System.Drawing.Size(530, 853);
            this.tabPage23.TabIndex = 1;
            this.tabPage23.Text = "Other";
            this.tabPage23.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btReadInfo);
            this.tabPage1.Controls.Add(this.mmInfo);
            this.tabPage1.Controls.Add(this.btReadTags);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage1.Size = new System.Drawing.Size(566, 923);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Media info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btReadInfo
            // 
            this.btReadInfo.Location = new System.Drawing.Point(29, 552);
            this.btReadInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btReadInfo.Name = "btReadInfo";
            this.btReadInfo.Size = new System.Drawing.Size(137, 42);
            this.btReadInfo.TabIndex = 5;
            this.btReadInfo.Text = "Read info";
            this.btReadInfo.UseVisualStyleBackColor = true;
            this.btReadInfo.Click += new System.EventHandler(this.btReadInfo_Click);
            // 
            // mmInfo
            // 
            this.mmInfo.Location = new System.Drawing.Point(29, 34);
            this.mmInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mmInfo.Multiline = true;
            this.mmInfo.Name = "mmInfo";
            this.mmInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmInfo.Size = new System.Drawing.Size(493, 504);
            this.mmInfo.TabIndex = 4;
            // 
            // btReadTags
            // 
            this.btReadTags.Location = new System.Drawing.Point(178, 552);
            this.btReadTags.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btReadTags.Name = "btReadTags";
            this.btReadTags.Size = new System.Drawing.Size(137, 42);
            this.btReadTags.TabIndex = 3;
            this.btReadTags.Text = "Read tags";
            this.btReadTags.UseVisualStyleBackColor = true;
            this.btReadTags.Click += new System.EventHandler(this.btReadTags_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbAudioStream);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbVolume1);
            this.tabPage2.Controls.Add(this.cbPlayAudio);
            this.tabPage2.Controls.Add(this.cbAudioOutputDevice);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.volumeMeter2);
            this.tabPage2.Controls.Add(this.volumeMeter1);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage2.Size = new System.Drawing.Size(566, 923);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Audio output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbAudioStream
            // 
            this.cbAudioStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioStream.FormattingEnabled = true;
            this.cbAudioStream.Location = new System.Drawing.Point(29, 194);
            this.cbAudioStream.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioStream.Name = "cbAudioStream";
            this.cbAudioStream.Size = new System.Drawing.Size(251, 32);
            this.cbAudioStream.TabIndex = 32;
            this.cbAudioStream.SelectedIndexChanged += new System.EventHandler(this.cbAudioStream_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Stream";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 28;
            this.label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume1.Location = new System.Drawing.Point(332, 194);
            this.tbVolume1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbVolume1.Maximum = 100;
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(156, 80);
            this.tbVolume1.TabIndex = 27;
            this.tbVolume1.Value = 85;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = true;
            this.cbPlayAudio.Checked = true;
            this.cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlayAudio.Location = new System.Drawing.Point(29, 94);
            this.cbPlayAudio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbPlayAudio.Name = "cbPlayAudio";
            this.cbPlayAudio.Size = new System.Drawing.Size(129, 29);
            this.cbPlayAudio.TabIndex = 25;
            this.cbPlayAudio.Text = "Play audio";
            this.cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(29, 44);
            this.cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(477, 32);
            this.cbAudioOutputDevice.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Audio output";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.tabControl18);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage3.Size = new System.Drawing.Size(566, 923);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Audio processing";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 24);
            this.label31.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(529, 25);
            this.label31.TabIndex = 7;
            this.label31.Text = "Enable effects before Start. More effects available using API";
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage4);
            this.tabControl18.Controls.Add(this.tabPage5);
            this.tabControl18.Location = new System.Drawing.Point(22, 65);
            this.tabControl18.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl18.Name = "tabControl18";
            this.tabControl18.SelectedIndex = 0;
            this.tabControl18.Size = new System.Drawing.Size(518, 816);
            this.tabControl18.TabIndex = 6;
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.label231);
            this.tabPage71.Controls.Add(this.label230);
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = new System.Drawing.Point(4, 33);
            this.tabPage71.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage71.Name = "tabPage71";
            this.tabPage71.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage71.Size = new System.Drawing.Size(510, 779);
            this.tabPage71.TabIndex = 0;
            this.tabPage71.Text = "Amplify";
            this.tabPage71.UseVisualStyleBackColor = true;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Location = new System.Drawing.Point(391, 98);
            this.label231.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(63, 25);
            this.label231.TabIndex = 5;
            this.label231.Text = "400%";
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(125, 98);
            this.label230.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(63, 25);
            this.label230.TabIndex = 4;
            this.label230.Text = "100%";
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAmplifyAmp.Location = new System.Drawing.Point(29, 127);
            this.tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudAmplifyAmp.Maximum = 400;
            this.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            this.tbAudAmplifyAmp.Size = new System.Drawing.Size(422, 80);
            this.tbAudAmplifyAmp.TabIndex = 3;
            this.tbAudAmplifyAmp.TickFrequency = 50;
            this.tbAudAmplifyAmp.Value = 100;
            this.tbAudAmplifyAmp.Scroll += new System.EventHandler(this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(24, 98);
            this.label95.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(104, 25);
            this.label95.TabIndex = 2;
            this.label95.Text = "Boost ratio";
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = true;
            this.cbAudAmplifyEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbAudAmplifyEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            this.cbAudAmplifyEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbAudAmplifyEnabled.TabIndex = 1;
            this.cbAudAmplifyEnabled.Text = "Enabled";
            this.cbAudAmplifyEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage72
            // 
            this.tabPage72.Controls.Add(this.btAudEqUpdate);
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
            this.tabPage72.Location = new System.Drawing.Point(4, 33);
            this.tabPage72.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage72.Name = "tabPage72";
            this.tabPage72.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage72.Size = new System.Drawing.Size(510, 779);
            this.tabPage72.TabIndex = 1;
            this.tabPage72.Text = "Equalizer";
            this.tabPage72.UseVisualStyleBackColor = true;
            // 
            // btAudEqUpdate
            // 
            this.btAudEqUpdate.Location = new System.Drawing.Point(320, 354);
            this.btAudEqUpdate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btAudEqUpdate.Name = "btAudEqUpdate";
            this.btAudEqUpdate.Size = new System.Drawing.Size(137, 42);
            this.btAudEqUpdate.TabIndex = 26;
            this.btAudEqUpdate.Text = "Update";
            this.btAudEqUpdate.UseVisualStyleBackColor = true;
            this.btAudEqUpdate.Click += new System.EventHandler(this.btAudEqUpdate_Click);
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(386, 288);
            this.label242.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(48, 25);
            this.label242.TabIndex = 23;
            this.label242.Text = "15K";
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(341, 288);
            this.label241.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(56, 25);
            this.label241.TabIndex = 22;
            this.label241.Text = "7523";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(296, 288);
            this.label240.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(56, 25);
            this.label240.TabIndex = 21;
            this.label240.Text = "3770";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(246, 288);
            this.label239.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(56, 25);
            this.label239.TabIndex = 20;
            this.label239.Text = "1889";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(210, 288);
            this.label238.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(45, 25);
            this.label238.TabIndex = 19;
            this.label238.Text = "947";
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(172, 288);
            this.label237.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(45, 25);
            this.label237.TabIndex = 18;
            this.label237.Text = "474";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(134, 288);
            this.label236.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(45, 25);
            this.label236.TabIndex = 17;
            this.label236.Text = "237";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(95, 288);
            this.label235.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(45, 25);
            this.label235.TabIndex = 16;
            this.label235.Text = "119";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(66, 288);
            this.label234.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(34, 25);
            this.label234.TabIndex = 15;
            this.label234.Text = "59";
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(33, 288);
            this.label233.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(34, 25);
            this.label233.TabIndex = 14;
            this.label233.Text = "29";
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Location = new System.Drawing.Point(216, 61);
            this.label232.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(23, 25);
            this.label232.TabIndex = 13;
            this.label232.Text = "0";
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq9.Location = new System.Drawing.Point(376, 90);
            this.tbAudEq9.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq9.Maximum = 12;
            this.tbAudEq9.Minimum = -24;
            this.tbAudEq9.Name = "tbAudEq9";
            this.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq9.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq9.TabIndex = 12;
            this.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq8.Location = new System.Drawing.Point(337, 90);
            this.tbAudEq8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq8.Maximum = 12;
            this.tbAudEq8.Minimum = -24;
            this.tbAudEq8.Name = "tbAudEq8";
            this.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq8.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq8.TabIndex = 11;
            this.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq7.Location = new System.Drawing.Point(297, 90);
            this.tbAudEq7.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq7.Maximum = 12;
            this.tbAudEq7.Minimum = -24;
            this.tbAudEq7.Name = "tbAudEq7";
            this.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq7.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq7.TabIndex = 10;
            this.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq6.Location = new System.Drawing.Point(259, 90);
            this.tbAudEq6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq6.Maximum = 12;
            this.tbAudEq6.Minimum = -24;
            this.tbAudEq6.Name = "tbAudEq6";
            this.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq6.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq6.TabIndex = 9;
            this.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq5.Location = new System.Drawing.Point(220, 90);
            this.tbAudEq5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq5.Maximum = 12;
            this.tbAudEq5.Minimum = -24;
            this.tbAudEq5.Name = "tbAudEq5";
            this.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq5.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq5.TabIndex = 8;
            this.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq4.Location = new System.Drawing.Point(183, 90);
            this.tbAudEq4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq4.Maximum = 12;
            this.tbAudEq4.Minimum = -24;
            this.tbAudEq4.Name = "tbAudEq4";
            this.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq4.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq4.TabIndex = 7;
            this.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq3.Location = new System.Drawing.Point(144, 90);
            this.tbAudEq3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq3.Maximum = 12;
            this.tbAudEq3.Minimum = -24;
            this.tbAudEq3.Name = "tbAudEq3";
            this.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq3.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq3.TabIndex = 6;
            this.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq2.Location = new System.Drawing.Point(106, 90);
            this.tbAudEq2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq2.Maximum = 12;
            this.tbAudEq2.Minimum = -24;
            this.tbAudEq2.Name = "tbAudEq2";
            this.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq2.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq2.TabIndex = 5;
            this.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq1.Location = new System.Drawing.Point(68, 90);
            this.tbAudEq1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq1.Maximum = 12;
            this.tbAudEq1.Minimum = -24;
            this.tbAudEq1.Name = "tbAudEq1";
            this.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq1.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq1.TabIndex = 4;
            this.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq0.Location = new System.Drawing.Point(32, 90);
            this.tbAudEq0.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEq0.Maximum = 12;
            this.tbAudEq0.Minimum = -24;
            this.tbAudEq0.Name = "tbAudEq0";
            this.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq0.Size = new System.Drawing.Size(80, 192);
            this.tbAudEq0.TabIndex = 3;
            this.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = true;
            this.cbAudEqualizerEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbAudEqualizerEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            this.cbAudEqualizerEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbAudEqualizerEnabled.TabIndex = 2;
            this.cbAudEqualizerEnabled.Text = "Enabled";
            this.cbAudEqualizerEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.tbAudBalanceLevel);
            this.tabPage4.Controls.Add(this.cbAudBalanceEnabled);
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage4.Size = new System.Drawing.Size(510, 779);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Balance";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Left";
            // 
            // tbAudBalanceLevel
            // 
            this.tbAudBalanceLevel.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudBalanceLevel.Location = new System.Drawing.Point(29, 122);
            this.tbAudBalanceLevel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudBalanceLevel.Minimum = -10;
            this.tbAudBalanceLevel.Name = "tbAudBalanceLevel";
            this.tbAudBalanceLevel.Size = new System.Drawing.Size(422, 80);
            this.tbAudBalanceLevel.TabIndex = 7;
            this.tbAudBalanceLevel.Scroll += new System.EventHandler(this.tbAudBalanceLevel_Scroll);
            // 
            // cbAudBalanceEnabled
            // 
            this.cbAudBalanceEnabled.AutoSize = true;
            this.cbAudBalanceEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbAudBalanceEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudBalanceEnabled.Name = "cbAudBalanceEnabled";
            this.cbAudBalanceEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbAudBalanceEnabled.TabIndex = 3;
            this.cbAudBalanceEnabled.Text = "Enabled";
            this.cbAudBalanceEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lbAudEchoFeedback);
            this.tabPage5.Controls.Add(this.tbAudEchoFeedback);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.lbAudEchoIntensity);
            this.tabPage5.Controls.Add(this.tbAudEchoIntensity);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.lbAudEchoDelay);
            this.tabPage5.Controls.Add(this.tbAudEchoDelay);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.cbAudEchoEnabled);
            this.tabPage5.Location = new System.Drawing.Point(4, 33);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage5.Size = new System.Drawing.Size(510, 779);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Echo";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbAudEchoFeedback
            // 
            this.lbAudEchoFeedback.AutoSize = true;
            this.lbAudEchoFeedback.Location = new System.Drawing.Point(391, 281);
            this.lbAudEchoFeedback.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAudEchoFeedback.Name = "lbAudEchoFeedback";
            this.lbAudEchoFeedback.Size = new System.Drawing.Size(23, 25);
            this.lbAudEchoFeedback.TabIndex = 14;
            this.lbAudEchoFeedback.Text = "0";
            // 
            // tbAudEchoFeedback
            // 
            this.tbAudEchoFeedback.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEchoFeedback.Location = new System.Drawing.Point(29, 310);
            this.tbAudEchoFeedback.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEchoFeedback.Maximum = 100;
            this.tbAudEchoFeedback.Name = "tbAudEchoFeedback";
            this.tbAudEchoFeedback.Size = new System.Drawing.Size(422, 80);
            this.tbAudEchoFeedback.TabIndex = 13;
            this.tbAudEchoFeedback.Scroll += new System.EventHandler(this.tbAudEchoFeedback_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 281);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 25);
            this.label19.TabIndex = 12;
            this.label19.Text = "Feedback";
            // 
            // lbAudEchoIntensity
            // 
            this.lbAudEchoIntensity.AutoSize = true;
            this.lbAudEchoIntensity.Location = new System.Drawing.Point(391, 186);
            this.lbAudEchoIntensity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAudEchoIntensity.Name = "lbAudEchoIntensity";
            this.lbAudEchoIntensity.Size = new System.Drawing.Size(39, 25);
            this.lbAudEchoIntensity.TabIndex = 11;
            this.lbAudEchoIntensity.Text = "0.8";
            // 
            // tbAudEchoIntensity
            // 
            this.tbAudEchoIntensity.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEchoIntensity.Location = new System.Drawing.Point(29, 216);
            this.tbAudEchoIntensity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEchoIntensity.Maximum = 100;
            this.tbAudEchoIntensity.Name = "tbAudEchoIntensity";
            this.tbAudEchoIntensity.Size = new System.Drawing.Size(422, 80);
            this.tbAudEchoIntensity.TabIndex = 10;
            this.tbAudEchoIntensity.Value = 80;
            this.tbAudEchoIntensity.Scroll += new System.EventHandler(this.tbAudEchoIntensity_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 186);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 25);
            this.label17.TabIndex = 9;
            this.label17.Text = "Intensity";
            // 
            // lbAudEchoDelay
            // 
            this.lbAudEchoDelay.AutoSize = true;
            this.lbAudEchoDelay.Location = new System.Drawing.Point(391, 92);
            this.lbAudEchoDelay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAudEchoDelay.Name = "lbAudEchoDelay";
            this.lbAudEchoDelay.Size = new System.Drawing.Size(45, 25);
            this.lbAudEchoDelay.TabIndex = 8;
            this.lbAudEchoDelay.Text = "500";
            // 
            // tbAudEchoDelay
            // 
            this.tbAudEchoDelay.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEchoDelay.Location = new System.Drawing.Point(29, 122);
            this.tbAudEchoDelay.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudEchoDelay.Maximum = 1500;
            this.tbAudEchoDelay.Minimum = 100;
            this.tbAudEchoDelay.Name = "tbAudEchoDelay";
            this.tbAudEchoDelay.Size = new System.Drawing.Size(422, 80);
            this.tbAudEchoDelay.TabIndex = 7;
            this.tbAudEchoDelay.TickFrequency = 50;
            this.tbAudEchoDelay.Value = 500;
            this.tbAudEchoDelay.Scroll += new System.EventHandler(this.tbAudEchoDelay_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Delay (ms)";
            // 
            // cbAudEchoEnabled
            // 
            this.cbAudEchoEnabled.AutoSize = true;
            this.cbAudEchoEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbAudEchoEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudEchoEnabled.Name = "cbAudEchoEnabled";
            this.cbAudEchoEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbAudEchoEnabled.TabIndex = 3;
            this.cbAudEchoEnabled.Text = "Enabled";
            this.cbAudEchoEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl4);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Location = new System.Drawing.Point(4, 33);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage7.Size = new System.Drawing.Size(566, 923);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Video processing";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage8);
            this.tabControl4.Controls.Add(this.tabPage11);
            this.tabControl4.Controls.Add(this.tabPage17);
            this.tabControl4.Controls.Add(this.tabPage20);
            this.tabControl4.Controls.Add(this.tabPage12);
            this.tabControl4.Controls.Add(this.tabPage13);
            this.tabControl4.Controls.Add(this.tabPage14);
            this.tabControl4.Controls.Add(this.tabPage15);
            this.tabControl4.Controls.Add(this.tabPage16);
            this.tabControl4.Location = new System.Drawing.Point(17, 72);
            this.tabControl4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(528, 829);
            this.tabControl4.TabIndex = 9;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label27);
            this.tabPage8.Controls.Add(this.cbResizeMethod);
            this.tabPage8.Controls.Add(this.label18);
            this.tabPage8.Controls.Add(this.cbResizeLetterbox);
            this.tabPage8.Controls.Add(this.label15);
            this.tabPage8.Controls.Add(this.edResizeHeight);
            this.tabPage8.Controls.Add(this.edResizeWidth);
            this.tabPage8.Controls.Add(this.cbResizeEnabled);
            this.tabPage8.Location = new System.Drawing.Point(4, 33);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage8.Size = new System.Drawing.Size(520, 792);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Resize";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 92);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(103, 25);
            this.label27.TabIndex = 7;
            this.label27.Text = "Resolution";
            // 
            // cbResizeMethod
            // 
            this.cbResizeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResizeMethod.FormattingEnabled = true;
            this.cbResizeMethod.Items.AddRange(new object[] {
            "Nearest neighbour scaling (fast and low quality)",
            "Bilinear 2-tap scaling (slow, middle quality)",
            "4-tap sinc filter for scaling (slow)",
            "Lanczos filter for scaling (slow, high quality)",
            "Bilinear multitap filter",
            "Multitap sinc filter",
            "Multitap bicubic Hermite filter",
            "Multitap bicubic spline filter",
            "Multitap bicubic Catmull-Rom filter",
            "Multitap bicubic Mitchell filter"});
            this.cbResizeMethod.Location = new System.Drawing.Point(29, 220);
            this.cbResizeMethod.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbResizeMethod.Name = "cbResizeMethod";
            this.cbResizeMethod.Size = new System.Drawing.Size(434, 32);
            this.cbResizeMethod.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 190);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 25);
            this.label18.TabIndex = 5;
            this.label18.Text = "Method";
            // 
            // cbResizeLetterbox
            // 
            this.cbResizeLetterbox.AutoSize = true;
            this.cbResizeLetterbox.Location = new System.Drawing.Point(257, 126);
            this.cbResizeLetterbox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbResizeLetterbox.Name = "cbResizeLetterbox";
            this.cbResizeLetterbox.Size = new System.Drawing.Size(119, 29);
            this.cbResizeLetterbox.TabIndex = 4;
            this.cbResizeLetterbox.Text = "Letterbox";
            this.cbResizeLetterbox.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(115, 127);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 25);
            this.label15.TabIndex = 3;
            this.label15.Text = "x";
            // 
            // edResizeHeight
            // 
            this.edResizeHeight.Location = new System.Drawing.Point(147, 122);
            this.edResizeHeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edResizeHeight.Name = "edResizeHeight";
            this.edResizeHeight.Size = new System.Drawing.Size(72, 29);
            this.edResizeHeight.TabIndex = 2;
            this.edResizeHeight.Text = "480";
            // 
            // edResizeWidth
            // 
            this.edResizeWidth.Location = new System.Drawing.Point(29, 122);
            this.edResizeWidth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edResizeWidth.Name = "edResizeWidth";
            this.edResizeWidth.Size = new System.Drawing.Size(72, 29);
            this.edResizeWidth.TabIndex = 1;
            this.edResizeWidth.Text = "640";
            // 
            // cbResizeEnabled
            // 
            this.cbResizeEnabled.AutoSize = true;
            this.cbResizeEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbResizeEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbResizeEnabled.Name = "cbResizeEnabled";
            this.cbResizeEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbResizeEnabled.TabIndex = 0;
            this.cbResizeEnabled.Text = "Enabled";
            this.cbResizeEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label201);
            this.tabPage11.Controls.Add(this.label200);
            this.tabPage11.Controls.Add(this.label199);
            this.tabPage11.Controls.Add(this.label198);
            this.tabPage11.Controls.Add(this.tbVideoContrast);
            this.tabPage11.Controls.Add(this.tbVideoHue);
            this.tabPage11.Controls.Add(this.tbVideoBrightness);
            this.tabPage11.Controls.Add(this.tbVideoSaturation);
            this.tabPage11.Controls.Add(this.cbVideoBalanceEnabled);
            this.tabPage11.Location = new System.Drawing.Point(4, 33);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage11.Size = new System.Drawing.Size(520, 792);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "Color balance";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(259, 168);
            this.label201.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(48, 25);
            this.label201.TabIndex = 74;
            this.label201.Text = "Hue";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(10, 168);
            this.label200.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(86, 25);
            this.label200.TabIndex = 73;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(259, 72);
            this.label199.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(101, 25);
            this.label199.TabIndex = 72;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(10, 72);
            this.label198.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(104, 25);
            this.label198.TabIndex = 71;
            this.label198.Text = "Brightness";
            // 
            // tbVideoContrast
            // 
            this.tbVideoContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbVideoContrast.Location = new System.Drawing.Point(4, 203);
            this.tbVideoContrast.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbVideoContrast.Maximum = 200;
            this.tbVideoContrast.Name = "tbVideoContrast";
            this.tbVideoContrast.Size = new System.Drawing.Size(238, 80);
            this.tbVideoContrast.TabIndex = 70;
            this.tbVideoContrast.Value = 100;
            this.tbVideoContrast.Scroll += new System.EventHandler(this.tbVideoContrast_Scroll);
            // 
            // tbVideoHue
            // 
            this.tbVideoHue.BackColor = System.Drawing.SystemColors.Window;
            this.tbVideoHue.Location = new System.Drawing.Point(259, 203);
            this.tbVideoHue.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbVideoHue.Maximum = 100;
            this.tbVideoHue.Minimum = -100;
            this.tbVideoHue.Name = "tbVideoHue";
            this.tbVideoHue.Size = new System.Drawing.Size(238, 80);
            this.tbVideoHue.TabIndex = 69;
            this.tbVideoHue.Scroll += new System.EventHandler(this.tbVideoHue_Scroll);
            // 
            // tbVideoBrightness
            // 
            this.tbVideoBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbVideoBrightness.Location = new System.Drawing.Point(4, 100);
            this.tbVideoBrightness.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbVideoBrightness.Maximum = 100;
            this.tbVideoBrightness.Minimum = -100;
            this.tbVideoBrightness.Name = "tbVideoBrightness";
            this.tbVideoBrightness.Size = new System.Drawing.Size(238, 80);
            this.tbVideoBrightness.TabIndex = 68;
            this.tbVideoBrightness.Scroll += new System.EventHandler(this.tbVideoBrightness_Scroll);
            // 
            // tbVideoSaturation
            // 
            this.tbVideoSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbVideoSaturation.Location = new System.Drawing.Point(259, 100);
            this.tbVideoSaturation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbVideoSaturation.Maximum = 200;
            this.tbVideoSaturation.Name = "tbVideoSaturation";
            this.tbVideoSaturation.Size = new System.Drawing.Size(238, 80);
            this.tbVideoSaturation.TabIndex = 67;
            this.tbVideoSaturation.Value = 200;
            this.tbVideoSaturation.Scroll += new System.EventHandler(this.tbVideoSaturation_Scroll);
            // 
            // cbVideoBalanceEnabled
            // 
            this.cbVideoBalanceEnabled.AutoSize = true;
            this.cbVideoBalanceEnabled.Location = new System.Drawing.Point(12, 20);
            this.cbVideoBalanceEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbVideoBalanceEnabled.Name = "cbVideoBalanceEnabled";
            this.cbVideoBalanceEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbVideoBalanceEnabled.TabIndex = 64;
            this.cbVideoBalanceEnabled.Text = "Enabled";
            this.cbVideoBalanceEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.btTextOverlayUpdate);
            this.tabPage17.Controls.Add(this.tabControl5);
            this.tabPage17.Controls.Add(this.cbTextOverlayEnabled);
            this.tabPage17.Location = new System.Drawing.Point(4, 33);
            this.tabPage17.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage17.Size = new System.Drawing.Size(520, 792);
            this.tabPage17.TabIndex = 7;
            this.tabPage17.Text = "Text overlay";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // btTextOverlayUpdate
            // 
            this.btTextOverlayUpdate.Location = new System.Drawing.Point(357, 22);
            this.btTextOverlayUpdate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btTextOverlayUpdate.Name = "btTextOverlayUpdate";
            this.btTextOverlayUpdate.Size = new System.Drawing.Size(137, 42);
            this.btTextOverlayUpdate.TabIndex = 9;
            this.btTextOverlayUpdate.Text = "Update";
            this.btTextOverlayUpdate.UseVisualStyleBackColor = true;
            this.btTextOverlayUpdate.Click += new System.EventHandler(this.btTextOverlayUpdate_Click);
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage18);
            this.tabControl5.Controls.Add(this.tabPage19);
            this.tabControl5.Location = new System.Drawing.Point(17, 72);
            this.tabControl5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(486, 696);
            this.tabControl5.TabIndex = 8;
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.tbTextOverlayY);
            this.tabPage18.Controls.Add(this.label42);
            this.tabPage18.Controls.Add(this.tbTextOverlayX);
            this.tabPage18.Controls.Add(this.label41);
            this.tabPage18.Controls.Add(this.cbTextOverlayLineAlign);
            this.tabPage18.Controls.Add(this.label37);
            this.tabPage18.Controls.Add(this.cbTextOverlayHAlign);
            this.tabPage18.Controls.Add(this.label33);
            this.tabPage18.Controls.Add(this.cbTextOverlayVAlign);
            this.tabPage18.Controls.Add(this.label32);
            this.tabPage18.Controls.Add(this.edTextOverlayText);
            this.tabPage18.Controls.Add(this.label29);
            this.tabPage18.Controls.Add(this.cbTextOverlayMode);
            this.tabPage18.Controls.Add(this.label28);
            this.tabPage18.Location = new System.Drawing.Point(4, 33);
            this.tabPage18.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage18.Size = new System.Drawing.Size(478, 659);
            this.tabPage18.TabIndex = 0;
            this.tabPage18.Text = "Main";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // tbTextOverlayY
            // 
            this.tbTextOverlayY.Location = new System.Drawing.Point(253, 510);
            this.tbTextOverlayY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbTextOverlayY.Maximum = 100;
            this.tbTextOverlayY.Name = "tbTextOverlayY";
            this.tbTextOverlayY.Size = new System.Drawing.Size(191, 80);
            this.tbTextOverlayY.TabIndex = 23;
            this.tbTextOverlayY.Value = 20;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(247, 474);
            this.label42.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(144, 25);
            this.label42.TabIndex = 22;
            this.label42.Text = "Custom Y align";
            // 
            // tbTextOverlayX
            // 
            this.tbTextOverlayX.Location = new System.Drawing.Point(26, 510);
            this.tbTextOverlayX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbTextOverlayX.Maximum = 100;
            this.tbTextOverlayX.Name = "tbTextOverlayX";
            this.tbTextOverlayX.Size = new System.Drawing.Size(191, 80);
            this.tbTextOverlayX.TabIndex = 21;
            this.tbTextOverlayX.Value = 20;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(20, 474);
            this.label41.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(145, 25);
            this.label41.TabIndex = 20;
            this.label41.Text = "Custom X align";
            // 
            // cbTextOverlayLineAlign
            // 
            this.cbTextOverlayLineAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayLineAlign.FormattingEnabled = true;
            this.cbTextOverlayLineAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.cbTextOverlayLineAlign.Location = new System.Drawing.Point(26, 412);
            this.cbTextOverlayLineAlign.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayLineAlign.Name = "cbTextOverlayLineAlign";
            this.cbTextOverlayLineAlign.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayLineAlign.TabIndex = 19;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(20, 382);
            this.label37.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(95, 25);
            this.label37.TabIndex = 18;
            this.label37.Text = "Line align";
            // 
            // cbTextOverlayHAlign
            // 
            this.cbTextOverlayHAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayHAlign.FormattingEnabled = true;
            this.cbTextOverlayHAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right",
            "Custom"});
            this.cbTextOverlayHAlign.Location = new System.Drawing.Point(26, 319);
            this.cbTextOverlayHAlign.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayHAlign.Name = "cbTextOverlayHAlign";
            this.cbTextOverlayHAlign.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayHAlign.TabIndex = 15;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(20, 290);
            this.label33.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(178, 25);
            this.label33.TabIndex = 14;
            this.label33.Text = "Horizontal align (X)";
            // 
            // cbTextOverlayVAlign
            // 
            this.cbTextOverlayVAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayVAlign.FormattingEnabled = true;
            this.cbTextOverlayVAlign.Items.AddRange(new object[] {
            "Baseline",
            "Bottom",
            "Top",
            "Custom",
            "Center"});
            this.cbTextOverlayVAlign.Location = new System.Drawing.Point(26, 226);
            this.cbTextOverlayVAlign.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayVAlign.Name = "cbTextOverlayVAlign";
            this.cbTextOverlayVAlign.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayVAlign.TabIndex = 13;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 196);
            this.label32.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(155, 25);
            this.label32.TabIndex = 12;
            this.label32.Text = "Vertical align (Y)";
            // 
            // edTextOverlayText
            // 
            this.edTextOverlayText.Location = new System.Drawing.Point(26, 140);
            this.edTextOverlayText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edTextOverlayText.Name = "edTextOverlayText";
            this.edTextOverlayText.Size = new System.Drawing.Size(415, 29);
            this.edTextOverlayText.TabIndex = 11;
            this.edTextOverlayText.Text = "Hello!";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(20, 110);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 25);
            this.label29.TabIndex = 10;
            this.label29.Text = "Text";
            // 
            // cbTextOverlayMode
            // 
            this.cbTextOverlayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayMode.FormattingEnabled = true;
            this.cbTextOverlayMode.Items.AddRange(new object[] {
            "Custom text",
            "Timestamp",
            "System time"});
            this.cbTextOverlayMode.Location = new System.Drawing.Point(26, 50);
            this.cbTextOverlayMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayMode.Name = "cbTextOverlayMode";
            this.cbTextOverlayMode.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayMode.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(20, 20);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 25);
            this.label28.TabIndex = 8;
            this.label28.Text = "Mode";
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.cbTextOverlayFontWeight);
            this.tabPage19.Controls.Add(this.label7);
            this.tabPage19.Controls.Add(this.pnTextOverlayColor);
            this.tabPage19.Controls.Add(this.label40);
            this.tabPage19.Controls.Add(this.cbTextOverlayAutosize);
            this.tabPage19.Controls.Add(this.cbTextOverlayFontStyle);
            this.tabPage19.Controls.Add(this.label39);
            this.tabPage19.Controls.Add(this.cbTextOverlayFontWrapMode);
            this.tabPage19.Controls.Add(this.label36);
            this.tabPage19.Controls.Add(this.cbTextOverlayFontSize);
            this.tabPage19.Controls.Add(this.label35);
            this.tabPage19.Controls.Add(this.cbTextOverlayFontName);
            this.tabPage19.Controls.Add(this.label34);
            this.tabPage19.Location = new System.Drawing.Point(4, 33);
            this.tabPage19.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage19.Size = new System.Drawing.Size(478, 659);
            this.tabPage19.TabIndex = 1;
            this.tabPage19.Text = "Font";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // cbTextOverlayFontWeight
            // 
            this.cbTextOverlayFontWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayFontWeight.FormattingEnabled = true;
            this.cbTextOverlayFontWeight.Items.AddRange(new object[] {
            "Thin",
            "UltraLight",
            "Light",
            "SemiLight",
            "Book",
            "Normal",
            "Medium",
            "SemiBold",
            "Bold",
            "UltraBold",
            "Heavy",
            "UltraHeavy"});
            this.cbTextOverlayFontWeight.Location = new System.Drawing.Point(26, 306);
            this.cbTextOverlayFontWeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayFontWeight.Name = "cbTextOverlayFontWeight";
            this.cbTextOverlayFontWeight.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayFontWeight.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Weight";
            // 
            // pnTextOverlayColor
            // 
            this.pnTextOverlayColor.BackColor = System.Drawing.Color.Green;
            this.pnTextOverlayColor.Location = new System.Drawing.Point(121, 454);
            this.pnTextOverlayColor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnTextOverlayColor.Name = "pnTextOverlayColor";
            this.pnTextOverlayColor.Size = new System.Drawing.Size(62, 62);
            this.pnTextOverlayColor.TabIndex = 22;
            this.pnTextOverlayColor.Click += new System.EventHandler(this.pnTextOverlayColor_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(20, 473);
            this.label40.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 25);
            this.label40.TabIndex = 21;
            this.label40.Text = "Color";
            // 
            // cbTextOverlayAutosize
            // 
            this.cbTextOverlayAutosize.AutoSize = true;
            this.cbTextOverlayAutosize.Location = new System.Drawing.Point(26, 380);
            this.cbTextOverlayAutosize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayAutosize.Name = "cbTextOverlayAutosize";
            this.cbTextOverlayAutosize.Size = new System.Drawing.Size(114, 29);
            this.cbTextOverlayAutosize.TabIndex = 20;
            this.cbTextOverlayAutosize.Text = "Autosize";
            this.cbTextOverlayAutosize.UseVisualStyleBackColor = true;
            // 
            // cbTextOverlayFontStyle
            // 
            this.cbTextOverlayFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayFontStyle.FormattingEnabled = true;
            this.cbTextOverlayFontStyle.Items.AddRange(new object[] {
            "Normal",
            "Oblique",
            "Italic"});
            this.cbTextOverlayFontStyle.Location = new System.Drawing.Point(26, 137);
            this.cbTextOverlayFontStyle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayFontStyle.Name = "cbTextOverlayFontStyle";
            this.cbTextOverlayFontStyle.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayFontStyle.TabIndex = 19;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(20, 107);
            this.label39.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 25);
            this.label39.TabIndex = 18;
            this.label39.Text = "Style";
            // 
            // cbTextOverlayFontWrapMode
            // 
            this.cbTextOverlayFontWrapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayFontWrapMode.FormattingEnabled = true;
            this.cbTextOverlayFontWrapMode.Items.AddRange(new object[] {
            "None",
            "Word",
            "Char",
            "Word and char"});
            this.cbTextOverlayFontWrapMode.Location = new System.Drawing.Point(26, 222);
            this.cbTextOverlayFontWrapMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayFontWrapMode.Name = "cbTextOverlayFontWrapMode";
            this.cbTextOverlayFontWrapMode.Size = new System.Drawing.Size(415, 32);
            this.cbTextOverlayFontWrapMode.TabIndex = 15;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(20, 192);
            this.label36.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(114, 25);
            this.label36.TabIndex = 14;
            this.label36.Text = "Wrap mode";
            // 
            // cbTextOverlayFontSize
            // 
            this.cbTextOverlayFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayFontSize.FormattingEnabled = true;
            this.cbTextOverlayFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cbTextOverlayFontSize.Location = new System.Drawing.Point(354, 50);
            this.cbTextOverlayFontSize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayFontSize.Name = "cbTextOverlayFontSize";
            this.cbTextOverlayFontSize.Size = new System.Drawing.Size(87, 32);
            this.cbTextOverlayFontSize.TabIndex = 13;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(348, 20);
            this.label35.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(51, 25);
            this.label35.TabIndex = 12;
            this.label35.Text = "Size";
            // 
            // cbTextOverlayFontName
            // 
            this.cbTextOverlayFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextOverlayFontName.FormattingEnabled = true;
            this.cbTextOverlayFontName.Location = new System.Drawing.Point(26, 50);
            this.cbTextOverlayFontName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayFontName.Name = "cbTextOverlayFontName";
            this.cbTextOverlayFontName.Size = new System.Drawing.Size(314, 32);
            this.cbTextOverlayFontName.TabIndex = 11;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(20, 20);
            this.label34.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 25);
            this.label34.TabIndex = 10;
            this.label34.Text = "Name";
            // 
            // cbTextOverlayEnabled
            // 
            this.cbTextOverlayEnabled.AutoSize = true;
            this.cbTextOverlayEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbTextOverlayEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbTextOverlayEnabled.Name = "cbTextOverlayEnabled";
            this.cbTextOverlayEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbTextOverlayEnabled.TabIndex = 1;
            this.cbTextOverlayEnabled.Text = "Enabled";
            this.cbTextOverlayEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.tbImageOverlayAlpha);
            this.tabPage20.Controls.Add(this.label46);
            this.tabPage20.Controls.Add(this.label45);
            this.tabPage20.Controls.Add(this.label44);
            this.tabPage20.Controls.Add(this.edImageOverlayY);
            this.tabPage20.Controls.Add(this.edImageOverlayX);
            this.tabPage20.Controls.Add(this.btImageOverlayOpen);
            this.tabPage20.Controls.Add(this.edImageOverlayFilename);
            this.tabPage20.Controls.Add(this.label43);
            this.tabPage20.Controls.Add(this.cbImageOverlayEnabled);
            this.tabPage20.Location = new System.Drawing.Point(4, 33);
            this.tabPage20.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage20.Size = new System.Drawing.Size(520, 792);
            this.tabPage20.TabIndex = 8;
            this.tabPage20.Text = "Image overlay";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // tbImageOverlayAlpha
            // 
            this.tbImageOverlayAlpha.Location = new System.Drawing.Point(29, 302);
            this.tbImageOverlayAlpha.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbImageOverlayAlpha.Maximum = 100;
            this.tbImageOverlayAlpha.Name = "tbImageOverlayAlpha";
            this.tbImageOverlayAlpha.Size = new System.Drawing.Size(191, 80);
            this.tbImageOverlayAlpha.TabIndex = 23;
            this.tbImageOverlayAlpha.Value = 100;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(24, 268);
            this.label46.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 25);
            this.label46.TabIndex = 22;
            this.label46.Text = "Alpha";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(24, 174);
            this.label45.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(81, 25);
            this.label45.TabIndex = 9;
            this.label45.Text = "Position";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(90, 209);
            this.label44.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(22, 25);
            this.label44.TabIndex = 8;
            this.label44.Text = "x";
            // 
            // edImageOverlayY
            // 
            this.edImageOverlayY.Location = new System.Drawing.Point(115, 203);
            this.edImageOverlayY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edImageOverlayY.Name = "edImageOverlayY";
            this.edImageOverlayY.Size = new System.Drawing.Size(50, 29);
            this.edImageOverlayY.TabIndex = 7;
            this.edImageOverlayY.Text = "50";
            // 
            // edImageOverlayX
            // 
            this.edImageOverlayX.Location = new System.Drawing.Point(29, 203);
            this.edImageOverlayX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edImageOverlayX.Name = "edImageOverlayX";
            this.edImageOverlayX.Size = new System.Drawing.Size(50, 29);
            this.edImageOverlayX.TabIndex = 6;
            this.edImageOverlayX.Text = "50";
            // 
            // btImageOverlayOpen
            // 
            this.btImageOverlayOpen.Location = new System.Drawing.Point(447, 110);
            this.btImageOverlayOpen.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btImageOverlayOpen.Name = "btImageOverlayOpen";
            this.btImageOverlayOpen.Size = new System.Drawing.Size(42, 42);
            this.btImageOverlayOpen.TabIndex = 5;
            this.btImageOverlayOpen.Text = "...";
            this.btImageOverlayOpen.UseVisualStyleBackColor = true;
            this.btImageOverlayOpen.Click += new System.EventHandler(this.btImageOverlayOpen_Click);
            // 
            // edImageOverlayFilename
            // 
            this.edImageOverlayFilename.Location = new System.Drawing.Point(29, 114);
            this.edImageOverlayFilename.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edImageOverlayFilename.Name = "edImageOverlayFilename";
            this.edImageOverlayFilename.Size = new System.Drawing.Size(404, 29);
            this.edImageOverlayFilename.TabIndex = 4;
            this.edImageOverlayFilename.Text = "c:\\samples\\icon.png";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(24, 85);
            this.label43.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(97, 25);
            this.label43.TabIndex = 3;
            this.label43.Text = "File name";
            // 
            // cbImageOverlayEnabled
            // 
            this.cbImageOverlayEnabled.AutoSize = true;
            this.cbImageOverlayEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbImageOverlayEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbImageOverlayEnabled.Name = "cbImageOverlayEnabled";
            this.cbImageOverlayEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbImageOverlayEnabled.TabIndex = 2;
            this.cbImageOverlayEnabled.Text = "Enabled";
            this.cbImageOverlayEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.cbColorEffect);
            this.tabPage12.Controls.Add(this.label20);
            this.tabPage12.Controls.Add(this.cbColorEffectEnabled);
            this.tabPage12.Location = new System.Drawing.Point(4, 33);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage12.Size = new System.Drawing.Size(520, 792);
            this.tabPage12.TabIndex = 2;
            this.tabPage12.Text = "Color effect";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // cbColorEffect
            // 
            this.cbColorEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorEffect.FormattingEnabled = true;
            this.cbColorEffect.Items.AddRange(new object[] {
            "None",
            "Heat",
            "Sepia",
            "X-ray",
            "X-pro",
            "Yellow-blue"});
            this.cbColorEffect.Location = new System.Drawing.Point(29, 114);
            this.cbColorEffect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbColorEffect.Name = "cbColorEffect";
            this.cbColorEffect.Size = new System.Drawing.Size(434, 32);
            this.cbColorEffect.TabIndex = 9;
            this.cbColorEffect.SelectedIndexChanged += new System.EventHandler(this.cbColorEffect_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 85);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 25);
            this.label20.TabIndex = 8;
            this.label20.Text = "Effect";
            // 
            // cbColorEffectEnabled
            // 
            this.cbColorEffectEnabled.AutoSize = true;
            this.cbColorEffectEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbColorEffectEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbColorEffectEnabled.Name = "cbColorEffectEnabled";
            this.cbColorEffectEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbColorEffectEnabled.TabIndex = 7;
            this.cbColorEffectEnabled.Text = "Enabled";
            this.cbColorEffectEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.cbFlipRotate);
            this.tabPage13.Controls.Add(this.label21);
            this.tabPage13.Controls.Add(this.cbFlipRotateEnabled);
            this.tabPage13.Location = new System.Drawing.Point(4, 33);
            this.tabPage13.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage13.Size = new System.Drawing.Size(520, 792);
            this.tabPage13.TabIndex = 3;
            this.tabPage13.Text = "Flip / rotate";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // cbFlipRotate
            // 
            this.cbFlipRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlipRotate.FormattingEnabled = true;
            this.cbFlipRotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180,",
            "-90",
            "Horizontal flip",
            "Vertical flip"});
            this.cbFlipRotate.Location = new System.Drawing.Point(29, 114);
            this.cbFlipRotate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbFlipRotate.Name = "cbFlipRotate";
            this.cbFlipRotate.Size = new System.Drawing.Size(434, 32);
            this.cbFlipRotate.TabIndex = 12;
            this.cbFlipRotate.SelectedIndexChanged += new System.EventHandler(this.cbFlipRotate_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 85);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 25);
            this.label21.TabIndex = 11;
            this.label21.Text = "Method";
            // 
            // cbFlipRotateEnabled
            // 
            this.cbFlipRotateEnabled.AutoSize = true;
            this.cbFlipRotateEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbFlipRotateEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbFlipRotateEnabled.Name = "cbFlipRotateEnabled";
            this.cbFlipRotateEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbFlipRotateEnabled.TabIndex = 10;
            this.cbFlipRotateEnabled.Text = "Enabled";
            this.cbFlipRotateEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.cbDeinterlaceDropOrphans);
            this.tabPage14.Controls.Add(this.cbDeinterlaceIgnoreObscure);
            this.tabPage14.Controls.Add(this.cbDeinterlaceLocking);
            this.tabPage14.Controls.Add(this.label26);
            this.tabPage14.Controls.Add(this.cbDeinterlaceMode);
            this.tabPage14.Controls.Add(this.label25);
            this.tabPage14.Controls.Add(this.cbDeinterlaceFieldLayout);
            this.tabPage14.Controls.Add(this.label24);
            this.tabPage14.Controls.Add(this.cbDeinterlaceFields);
            this.tabPage14.Controls.Add(this.label23);
            this.tabPage14.Controls.Add(this.cbDeinterlaceMethod);
            this.tabPage14.Controls.Add(this.label22);
            this.tabPage14.Controls.Add(this.cbDeinterlaceEnabled);
            this.tabPage14.Location = new System.Drawing.Point(4, 33);
            this.tabPage14.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage14.Size = new System.Drawing.Size(520, 792);
            this.tabPage14.TabIndex = 4;
            this.tabPage14.Text = "Deinterlace";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlaceDropOrphans
            // 
            this.cbDeinterlaceDropOrphans.AutoSize = true;
            this.cbDeinterlaceDropOrphans.Checked = true;
            this.cbDeinterlaceDropOrphans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeinterlaceDropOrphans.Location = new System.Drawing.Point(29, 587);
            this.cbDeinterlaceDropOrphans.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceDropOrphans.Name = "cbDeinterlaceDropOrphans";
            this.cbDeinterlaceDropOrphans.Size = new System.Drawing.Size(156, 29);
            this.cbDeinterlaceDropOrphans.TabIndex = 25;
            this.cbDeinterlaceDropOrphans.Text = "Drop orphans";
            this.cbDeinterlaceDropOrphans.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlaceIgnoreObscure
            // 
            this.cbDeinterlaceIgnoreObscure.AutoSize = true;
            this.cbDeinterlaceIgnoreObscure.Checked = true;
            this.cbDeinterlaceIgnoreObscure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeinterlaceIgnoreObscure.Location = new System.Drawing.Point(29, 545);
            this.cbDeinterlaceIgnoreObscure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceIgnoreObscure.Name = "cbDeinterlaceIgnoreObscure";
            this.cbDeinterlaceIgnoreObscure.Size = new System.Drawing.Size(168, 29);
            this.cbDeinterlaceIgnoreObscure.TabIndex = 24;
            this.cbDeinterlaceIgnoreObscure.Text = "Ignore obscure";
            this.cbDeinterlaceIgnoreObscure.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlaceLocking
            // 
            this.cbDeinterlaceLocking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeinterlaceLocking.FormattingEnabled = true;
            this.cbDeinterlaceLocking.Items.AddRange(new object[] {
            "None",
            "Auto",
            "Active",
            "Passive"});
            this.cbDeinterlaceLocking.Location = new System.Drawing.Point(29, 470);
            this.cbDeinterlaceLocking.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceLocking.Name = "cbDeinterlaceLocking";
            this.cbDeinterlaceLocking.Size = new System.Drawing.Size(434, 32);
            this.cbDeinterlaceLocking.TabIndex = 23;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(24, 442);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 25);
            this.label26.TabIndex = 22;
            this.label26.Text = "Locking";
            // 
            // cbDeinterlaceMode
            // 
            this.cbDeinterlaceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeinterlaceMode.FormattingEnabled = true;
            this.cbDeinterlaceMode.Items.AddRange(new object[] {
            "Auto",
            "Interlaced",
            "Disabled",
            "Auto (strict)"});
            this.cbDeinterlaceMode.Location = new System.Drawing.Point(29, 380);
            this.cbDeinterlaceMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceMode.Name = "cbDeinterlaceMode";
            this.cbDeinterlaceMode.Size = new System.Drawing.Size(434, 32);
            this.cbDeinterlaceMode.TabIndex = 21;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 350);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 25);
            this.label25.TabIndex = 20;
            this.label25.Text = "Mode";
            // 
            // cbDeinterlaceFieldLayout
            // 
            this.cbDeinterlaceFieldLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeinterlaceFieldLayout.FormattingEnabled = true;
            this.cbDeinterlaceFieldLayout.Items.AddRange(new object[] {
            "Automatically detect",
            "Top fields first",
            "Bottom fields first"});
            this.cbDeinterlaceFieldLayout.Location = new System.Drawing.Point(29, 292);
            this.cbDeinterlaceFieldLayout.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceFieldLayout.Name = "cbDeinterlaceFieldLayout";
            this.cbDeinterlaceFieldLayout.Size = new System.Drawing.Size(434, 32);
            this.cbDeinterlaceFieldLayout.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 262);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 25);
            this.label24.TabIndex = 18;
            this.label24.Text = "Field layout";
            // 
            // cbDeinterlaceFields
            // 
            this.cbDeinterlaceFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeinterlaceFields.FormattingEnabled = true;
            this.cbDeinterlaceFields.Items.AddRange(new object[] {
            "All",
            "Top fields only",
            "Bottom fields only",
            "Automatically detect"});
            this.cbDeinterlaceFields.Location = new System.Drawing.Point(29, 202);
            this.cbDeinterlaceFields.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceFields.Name = "cbDeinterlaceFields";
            this.cbDeinterlaceFields.Size = new System.Drawing.Size(434, 32);
            this.cbDeinterlaceFields.TabIndex = 17;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 172);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 25);
            this.label23.TabIndex = 16;
            this.label23.Text = "Fields";
            // 
            // cbDeinterlaceMethod
            // 
            this.cbDeinterlaceMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeinterlaceMethod.FormattingEnabled = true;
            this.cbDeinterlaceMethod.Items.AddRange(new object[] {
            "Motion adaptive: motion search",
            "Motion adaptive: advanced detection",
            "Motion adaptive: simple detection",
            "Blur vertical",
            "Linear interpolation",
            "Linear interpolation in time domain (Low quality)",
            "Double lines"});
            this.cbDeinterlaceMethod.Location = new System.Drawing.Point(29, 114);
            this.cbDeinterlaceMethod.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceMethod.Name = "cbDeinterlaceMethod";
            this.cbDeinterlaceMethod.Size = new System.Drawing.Size(434, 32);
            this.cbDeinterlaceMethod.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 85);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 25);
            this.label22.TabIndex = 14;
            this.label22.Text = "Method";
            // 
            // cbDeinterlaceEnabled
            // 
            this.cbDeinterlaceEnabled.AutoSize = true;
            this.cbDeinterlaceEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbDeinterlaceEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDeinterlaceEnabled.Name = "cbDeinterlaceEnabled";
            this.cbDeinterlaceEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbDeinterlaceEnabled.TabIndex = 13;
            this.cbDeinterlaceEnabled.Text = "Enabled";
            this.cbDeinterlaceEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.tbGaussianBlur);
            this.tabPage15.Controls.Add(this.cbGaussianBlurEnabled);
            this.tabPage15.Location = new System.Drawing.Point(4, 33);
            this.tabPage15.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage15.Size = new System.Drawing.Size(520, 792);
            this.tabPage15.TabIndex = 5;
            this.tabPage15.Text = "Blur / sharpen";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // tbGaussianBlur
            // 
            this.tbGaussianBlur.Location = new System.Drawing.Point(29, 72);
            this.tbGaussianBlur.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbGaussianBlur.Maximum = 200;
            this.tbGaussianBlur.Minimum = -200;
            this.tbGaussianBlur.Name = "tbGaussianBlur";
            this.tbGaussianBlur.Size = new System.Drawing.Size(460, 80);
            this.tbGaussianBlur.TabIndex = 1;
            this.tbGaussianBlur.Value = 12;
            this.tbGaussianBlur.Scroll += new System.EventHandler(this.tbGaussianBlur_Scroll);
            // 
            // cbGaussianBlurEnabled
            // 
            this.cbGaussianBlurEnabled.AutoSize = true;
            this.cbGaussianBlurEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbGaussianBlurEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbGaussianBlurEnabled.Name = "cbGaussianBlurEnabled";
            this.cbGaussianBlurEnabled.Size = new System.Drawing.Size(158, 29);
            this.cbGaussianBlurEnabled.TabIndex = 0;
            this.cbGaussianBlurEnabled.Text = "Gaussian blur";
            this.cbGaussianBlurEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.cbFishEyeEnabled);
            this.tabPage16.Location = new System.Drawing.Point(4, 33);
            this.tabPage16.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage16.Size = new System.Drawing.Size(520, 792);
            this.tabPage16.TabIndex = 6;
            this.tabPage16.Text = "Other";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // cbFishEyeEnabled
            // 
            this.cbFishEyeEnabled.AutoSize = true;
            this.cbFishEyeEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbFishEyeEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbFishEyeEnabled.Name = "cbFishEyeEnabled";
            this.cbFishEyeEnabled.Size = new System.Drawing.Size(112, 29);
            this.cbFishEyeEnabled.TabIndex = 0;
            this.cbFishEyeEnabled.Text = "Fish eye";
            this.cbFishEyeEnabled.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(529, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enable effects before Start. More effects available using API";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label505);
            this.tabPage6.Controls.Add(this.rbMotionDetectionProcessor);
            this.tabPage6.Controls.Add(this.label389);
            this.tabPage6.Controls.Add(this.rbMotionDetectionDetector);
            this.tabPage6.Controls.Add(this.label65);
            this.tabPage6.Controls.Add(this.pbAFMotionLevel);
            this.tabPage6.Controls.Add(this.cbMotionDetection);
            this.tabPage6.Location = new System.Drawing.Point(4, 33);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage6.Size = new System.Drawing.Size(566, 923);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Motion detection";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label505
            // 
            this.label505.AutoSize = true;
            this.label505.Location = new System.Drawing.Point(24, 192);
            this.label505.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label505.Name = "label505";
            this.label505.Size = new System.Drawing.Size(100, 25);
            this.label505.TabIndex = 37;
            this.label505.Text = "Processor";
            // 
            // rbMotionDetectionProcessor
            // 
            this.rbMotionDetectionProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rbMotionDetectionProcessor.FormattingEnabled = true;
            this.rbMotionDetectionProcessor.Items.AddRange(new object[] {
            "None",
            "Blob counting objects",
            "GridMotionAreaProcessing",
            "Motion area highlighting",
            "Motion border highlighting"});
            this.rbMotionDetectionProcessor.Location = new System.Drawing.Point(24, 222);
            this.rbMotionDetectionProcessor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rbMotionDetectionProcessor.Name = "rbMotionDetectionProcessor";
            this.rbMotionDetectionProcessor.Size = new System.Drawing.Size(470, 32);
            this.rbMotionDetectionProcessor.TabIndex = 36;
            // 
            // label389
            // 
            this.label389.AutoSize = true;
            this.label389.Location = new System.Drawing.Point(24, 100);
            this.label389.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label389.Name = "label389";
            this.label389.Size = new System.Drawing.Size(85, 25);
            this.label389.TabIndex = 35;
            this.label389.Text = "Detector";
            // 
            // rbMotionDetectionDetector
            // 
            this.rbMotionDetectionDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rbMotionDetectionDetector.FormattingEnabled = true;
            this.rbMotionDetectionDetector.Items.AddRange(new object[] {
            "Custom frame difference",
            "Simple background modeling",
            "Two frames difference"});
            this.rbMotionDetectionDetector.Location = new System.Drawing.Point(24, 130);
            this.rbMotionDetectionDetector.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rbMotionDetectionDetector.Name = "rbMotionDetectionDetector";
            this.rbMotionDetectionDetector.Size = new System.Drawing.Size(470, 32);
            this.rbMotionDetectionDetector.TabIndex = 34;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(24, 299);
            this.label65.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(116, 25);
            this.label65.TabIndex = 33;
            this.label65.Text = "Motion level";
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = new System.Drawing.Point(24, 329);
            this.pbAFMotionLevel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pbAFMotionLevel.Name = "pbAFMotionLevel";
            this.pbAFMotionLevel.Size = new System.Drawing.Size(473, 42);
            this.pbAFMotionLevel.TabIndex = 32;
            // 
            // cbMotionDetection
            // 
            this.cbMotionDetection.AutoSize = true;
            this.cbMotionDetection.Location = new System.Drawing.Point(29, 30);
            this.cbMotionDetection.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbMotionDetection.Name = "cbMotionDetection";
            this.cbMotionDetection.Size = new System.Drawing.Size(110, 29);
            this.cbMotionDetection.TabIndex = 0;
            this.cbMotionDetection.Text = "Enabled";
            this.cbMotionDetection.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.edBarcodeMetadata);
            this.tabPage9.Controls.Add(this.label91);
            this.tabPage9.Controls.Add(this.cbBarcodeType);
            this.tabPage9.Controls.Add(this.label90);
            this.tabPage9.Controls.Add(this.btBarcodeReset);
            this.tabPage9.Controls.Add(this.edBarcode);
            this.tabPage9.Controls.Add(this.label89);
            this.tabPage9.Controls.Add(this.cbBarcodeDetectionEnabled);
            this.tabPage9.Location = new System.Drawing.Point(4, 33);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage9.Size = new System.Drawing.Size(566, 923);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "Barcode reader";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = new System.Drawing.Point(29, 295);
            this.edBarcodeMetadata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edBarcodeMetadata.Multiline = true;
            this.edBarcodeMetadata.Name = "edBarcodeMetadata";
            this.edBarcodeMetadata.Size = new System.Drawing.Size(495, 174);
            this.edBarcodeMetadata.TabIndex = 24;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(26, 260);
            this.label91.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(94, 25);
            this.label91.TabIndex = 23;
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
            this.cbBarcodeType.Location = new System.Drawing.Point(29, 118);
            this.cbBarcodeType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBarcodeType.Name = "cbBarcodeType";
            this.cbBarcodeType.Size = new System.Drawing.Size(290, 32);
            this.cbBarcodeType.TabIndex = 22;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(26, 89);
            this.label90.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(127, 25);
            this.label90.TabIndex = 21;
            this.label90.Text = "Barcode type";
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = new System.Drawing.Point(29, 494);
            this.btBarcodeReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btBarcodeReset.Name = "btBarcodeReset";
            this.btBarcodeReset.Size = new System.Drawing.Size(114, 42);
            this.btBarcodeReset.TabIndex = 20;
            this.btBarcodeReset.Text = "Restart";
            this.btBarcodeReset.UseVisualStyleBackColor = true;
            // 
            // edBarcode
            // 
            this.edBarcode.Location = new System.Drawing.Point(29, 206);
            this.edBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edBarcode.Name = "edBarcode";
            this.edBarcode.Size = new System.Drawing.Size(495, 29);
            this.edBarcode.TabIndex = 19;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(26, 178);
            this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(166, 25);
            this.label89.TabIndex = 18;
            this.label89.Text = "Detected barcode";
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = true;
            this.cbBarcodeDetectionEnabled.Location = new System.Drawing.Point(29, 30);
            this.cbBarcodeDetectionEnabled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbBarcodeDetectionEnabled.Name = "cbBarcodeDetectionEnabled";
            this.cbBarcodeDetectionEnabled.Size = new System.Drawing.Size(110, 29);
            this.cbBarcodeDetectionEnabled.TabIndex = 17;
            this.cbBarcodeDetectionEnabled.Text = "Enabled";
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Location = new System.Drawing.Point(22, 994);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(567, 281);
            this.tabControl3.TabIndex = 26;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.mmLog);
            this.tabPage10.Controls.Add(this.cbDebugMode);
            this.tabPage10.Location = new System.Drawing.Point(4, 33);
            this.tabPage10.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage10.Size = new System.Drawing.Size(559, 244);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Debug";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(29, 66);
            this.mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(481, 141);
            this.mmLog.TabIndex = 1;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(29, 24);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(150, 29);
            this.cbDebugMode.TabIndex = 0;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // btSaveSnapshot
            // 
            this.btSaveSnapshot.Location = new System.Drawing.Point(612, 974);
            this.btSaveSnapshot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSaveSnapshot.Name = "btSaveSnapshot";
            this.btSaveSnapshot.Size = new System.Drawing.Size(213, 42);
            this.btSaveSnapshot.TabIndex = 38;
            this.btSaveSnapshot.Text = "Save snapshot";
            this.btSaveSnapshot.UseVisualStyleBackColor = true;
            this.btSaveSnapshot.Click += new System.EventHandler(this.btSaveSnapshot_Click);
            // 
            // dlgOpenImage
            // 
            this.dlgOpenImage.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(612, 94);
            this.videoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(759, 550);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 39;
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = -60F;
            this.volumeMeter2.BackColor = System.Drawing.Color.Gainsboro;
            this.volumeMeter2.Boost = 1F;
            this.volumeMeter2.Location = new System.Drawing.Point(98, 583);
            this.volumeMeter2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.volumeMeter2.MaxDb = 18F;
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Size = new System.Drawing.Size(42, 270);
            this.volumeMeter2.TabIndex = 30;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = -60F;
            this.volumeMeter1.BackColor = System.Drawing.Color.Gainsboro;
            this.volumeMeter1.Boost = 1F;
            this.volumeMeter1.Location = new System.Drawing.Point(44, 583);
            this.volumeMeter1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Size = new System.Drawing.Size(42, 270);
            this.volumeMeter1.TabIndex = 29;
            // 
            // btPrevFrame
            // 
            this.btPrevFrame.Location = new System.Drawing.Point(450, 107);
            this.btPrevFrame.Name = "btPrevFrame";
            this.btPrevFrame.Size = new System.Drawing.Size(137, 42);
            this.btPrevFrame.TabIndex = 42;
            this.btPrevFrame.Text = "Prev frame";
            this.btPrevFrame.UseVisualStyleBackColor = true;
            this.btPrevFrame.Click += new System.EventHandler(this.btPrevFrame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 1282);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.btSaveSnapshot);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net (Cross-platform) - Main Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabPage24.ResumeLayout(false);
            this.tabPage24.PerformLayout();
            this.tabPage22.ResumeLayout(false);
            this.tabPage22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPLatency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPUDPBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRTSPRTPBlockSize)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudBalanceLevel)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEchoDelay)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoSaturation)).EndInit();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTextOverlayY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTextOverlayX)).EndInit();
            this.tabPage19.ResumeLayout(false);
            this.tabPage19.PerformLayout();
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageOverlayAlpha)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGaussianBlur)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmPosition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbTimeline;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.TextBox edFilenameOrURL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbPlayAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabControl tabControl18;
        private System.Windows.Forms.TabPage tabPage71;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.TrackBar tbAudAmplifyAmp;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.CheckBox cbAudAmplifyEnabled;
        private System.Windows.Forms.TabPage tabPage72;
        private System.Windows.Forms.Button btAudEqUpdate;
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox cbAudBalanceEnabled;
        private System.Windows.Forms.CheckBox cbAudEchoEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbAudBalanceLevel;
        private System.Windows.Forms.Label lbAudEchoFeedback;
        private System.Windows.Forms.TrackBar tbAudEchoFeedback;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbAudEchoIntensity;
        private System.Windows.Forms.TrackBar tbAudEchoIntensity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbAudEchoDelay;
        private System.Windows.Forms.TrackBar tbAudEchoDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ComboBox cbResizeMethod;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox cbResizeLetterbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox edResizeHeight;
        private System.Windows.Forms.TextBox edResizeWidth;
        private System.Windows.Forms.CheckBox cbResizeEnabled;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TrackBar tbVideoContrast;
        private System.Windows.Forms.TrackBar tbVideoHue;
        private System.Windows.Forms.TrackBar tbVideoBrightness;
        private System.Windows.Forms.TrackBar tbVideoSaturation;
        private System.Windows.Forms.CheckBox cbVideoBalanceEnabled;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.ComboBox cbColorEffect;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbColorEffectEnabled;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.ComboBox cbFlipRotate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbFlipRotateEnabled;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.ComboBox cbDeinterlaceMethod;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbDeinterlaceEnabled;
        private System.Windows.Forms.ComboBox cbDeinterlaceLocking;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cbDeinterlaceMode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbDeinterlaceFieldLayout;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbDeinterlaceFields;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox cbDeinterlaceDropOrphans;
        private System.Windows.Forms.CheckBox cbDeinterlaceIgnoreObscure;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TrackBar tbGaussianBlur;
        private System.Windows.Forms.CheckBox cbGaussianBlurEnabled;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.CheckBox cbFishEyeEnabled;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.CheckBox cbTextOverlayEnabled;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage18;
        private System.Windows.Forms.ComboBox cbTextOverlayHAlign;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cbTextOverlayVAlign;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox edTextOverlayText;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbTextOverlayMode;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage tabPage19;
        private System.Windows.Forms.CheckBox cbTextOverlayAutosize;
        private System.Windows.Forms.ComboBox cbTextOverlayFontStyle;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cbTextOverlayFontWrapMode;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cbTextOverlayFontSize;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cbTextOverlayFontName;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cbTextOverlayLineAlign;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btTextOverlayUpdate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pnTextOverlayColor;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TrackBar tbTextOverlayY;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TrackBar tbTextOverlayX;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TabPage tabPage20;
        private System.Windows.Forms.TrackBar tbImageOverlayAlpha;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox edImageOverlayY;
        private System.Windows.Forms.TextBox edImageOverlayX;
        private System.Windows.Forms.Button btImageOverlayOpen;
        private System.Windows.Forms.TextBox edImageOverlayFilename;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckBox cbImageOverlayEnabled;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage22;
        private System.Windows.Forms.TextBox edRTSPPassword;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox edRTSPUserName;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TabPage tabPage23;
        private System.Windows.Forms.Label lbRTSPUDPBufferSize;
        private System.Windows.Forms.TrackBar tbRTSPUDPBufferSize;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label lbRTSPRTPBlockSize;
        private System.Windows.Forms.TrackBar tbRTSPRTPBlockSize;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TrackBar tbRTSPLatency;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lbRTSPLatency;
        private System.Windows.Forms.ComboBox cbRTSPProtocol;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.Button btReadInfo;
        private System.Windows.Forms.TextBox mmInfo;
        private System.Windows.Forms.Button btReadTags;
        private System.Windows.Forms.ComboBox cbTextOverlayFontWeight;
        private System.Windows.Forms.Label label7;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter2;
        private VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter volumeMeter1;
        private System.Windows.Forms.Button btSaveSnapshot;
        private System.Windows.Forms.ComboBox cbAudioStream;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox cbMotionDetection;
        private System.Windows.Forms.Label label505;
        private System.Windows.Forms.ComboBox rbMotionDetectionProcessor;
        private System.Windows.Forms.Label label389;
        private System.Windows.Forms.ComboBox rbMotionDetectionDetector;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ProgressBar pbAFMotionLevel;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox edBarcodeMetadata;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.ComboBox cbBarcodeType;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Button btBarcodeReset;
        private System.Windows.Forms.TextBox edBarcode;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.CheckBox cbBarcodeDetectionEnabled;
        private System.Windows.Forms.TabPage tabPage24;
        private System.Windows.Forms.CheckBox cbSubtitlesEnabled;
        private System.Windows.Forms.CheckBox cbSubtitlesCustomSettings;
        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.OpenFileDialog dlgOpenImage;
        private System.Windows.Forms.Button btPrevFrame;
    }
}

