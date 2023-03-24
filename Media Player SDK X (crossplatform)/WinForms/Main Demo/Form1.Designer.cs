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
            this.components = (new global::System.ComponentModel.Container());
            global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Main_Demo.Form1));
            this.tmPosition = (new global::System.Windows.Forms.Timer(this.components));
            this.groupBox2 = (new global::System.Windows.Forms.GroupBox());
            this.btPrevFrame = (new global::System.Windows.Forms.Button());
            this.btNextFrame = (new global::System.Windows.Forms.Button());
            this.btStop = (new global::System.Windows.Forms.Button());
            this.btPause = (new global::System.Windows.Forms.Button());
            this.btResume = (new global::System.Windows.Forms.Button());
            this.btStart = (new global::System.Windows.Forms.Button());
            this.tbSpeed = (new global::System.Windows.Forms.TrackBar());
            this.lbSpeed = (new global::System.Windows.Forms.Label());
            this.lbTimeline = (new global::System.Windows.Forms.Label());
            this.tbTimeline = (new global::System.Windows.Forms.TrackBar());
            this.edFilenameOrURL = (new global::System.Windows.Forms.TextBox());
            this.label14 = (new global::System.Windows.Forms.Label());
            this.btSelectFile = (new global::System.Windows.Forms.Button());
            this.openFileDialog1 = (new global::System.Windows.Forms.OpenFileDialog());
            this.tabControl1 = (new global::System.Windows.Forms.TabControl());
            this.tabPage21 = (new global::System.Windows.Forms.TabPage());
            this.tabControl6 = (new global::System.Windows.Forms.TabControl());
            this.tabPage24 = (new global::System.Windows.Forms.TabPage());
            this.cbSubtitlesCustomSettings = (new global::System.Windows.Forms.CheckBox());
            this.cbSubtitlesEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage22 = (new global::System.Windows.Forms.TabPage());
            this.cbRTSPProtocol = (new global::System.Windows.Forms.ComboBox());
            this.label50 = (new global::System.Windows.Forms.Label());
            this.lbRTSPLatency = (new global::System.Windows.Forms.Label());
            this.tbRTSPLatency = (new global::System.Windows.Forms.TrackBar());
            this.label53 = (new global::System.Windows.Forms.Label());
            this.lbRTSPUDPBufferSize = (new global::System.Windows.Forms.Label());
            this.tbRTSPUDPBufferSize = (new global::System.Windows.Forms.TrackBar());
            this.label52 = (new global::System.Windows.Forms.Label());
            this.lbRTSPRTPBlockSize = (new global::System.Windows.Forms.Label());
            this.tbRTSPRTPBlockSize = (new global::System.Windows.Forms.TrackBar());
            this.label49 = (new global::System.Windows.Forms.Label());
            this.edRTSPPassword = (new global::System.Windows.Forms.TextBox());
            this.label48 = (new global::System.Windows.Forms.Label());
            this.edRTSPUserName = (new global::System.Windows.Forms.TextBox());
            this.label47 = (new global::System.Windows.Forms.Label());
            this.tabPage23 = (new global::System.Windows.Forms.TabPage());
            this.tabPage1 = (new global::System.Windows.Forms.TabPage());
            this.btReadInfo = (new global::System.Windows.Forms.Button());
            this.mmInfo = (new global::System.Windows.Forms.TextBox());
            this.btReadTags = (new global::System.Windows.Forms.Button());
            this.tabPage2 = (new global::System.Windows.Forms.TabPage());
            this.cbAudioStream = (new global::System.Windows.Forms.ComboBox());
            this.label8 = (new global::System.Windows.Forms.Label());
            this.label6 = (new global::System.Windows.Forms.Label());
            this.tbVolume1 = (new global::System.Windows.Forms.TrackBar());
            this.cbPlayAudio = (new global::System.Windows.Forms.CheckBox());
            this.cbAudioOutputDevice = (new global::System.Windows.Forms.ComboBox());
            this.label5 = (new global::System.Windows.Forms.Label());
            this.volumeMeter2 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.volumeMeter1 = (new global::VisioForge.Core.UI.WinForms.VolumeMeterPro.VolumeMeter());
            this.tabPage3 = (new global::System.Windows.Forms.TabPage());
            this.label31 = (new global::System.Windows.Forms.Label());
            this.tabControl18 = (new global::System.Windows.Forms.TabControl());
            this.tabPage71 = (new global::System.Windows.Forms.TabPage());
            this.label231 = (new global::System.Windows.Forms.Label());
            this.label230 = (new global::System.Windows.Forms.Label());
            this.tbAudAmplifyAmp = (new global::System.Windows.Forms.TrackBar());
            this.label95 = (new global::System.Windows.Forms.Label());
            this.cbAudAmplifyEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage72 = (new global::System.Windows.Forms.TabPage());
            this.btAudEqUpdate = (new global::System.Windows.Forms.Button());
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
            this.tabPage4 = (new global::System.Windows.Forms.TabPage());
            this.label1 = (new global::System.Windows.Forms.Label());
            this.label2 = (new global::System.Windows.Forms.Label());
            this.tbAudBalanceLevel = (new global::System.Windows.Forms.TrackBar());
            this.cbAudBalanceEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage5 = (new global::System.Windows.Forms.TabPage());
            this.lbAudEchoFeedback = (new global::System.Windows.Forms.Label());
            this.tbAudEchoFeedback = (new global::System.Windows.Forms.TrackBar());
            this.label19 = (new global::System.Windows.Forms.Label());
            this.lbAudEchoIntensity = (new global::System.Windows.Forms.Label());
            this.tbAudEchoIntensity = (new global::System.Windows.Forms.TrackBar());
            this.label17 = (new global::System.Windows.Forms.Label());
            this.lbAudEchoDelay = (new global::System.Windows.Forms.Label());
            this.tbAudEchoDelay = (new global::System.Windows.Forms.TrackBar());
            this.label4 = (new global::System.Windows.Forms.Label());
            this.cbAudEchoEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage7 = (new global::System.Windows.Forms.TabPage());
            this.tabControl4 = (new global::System.Windows.Forms.TabControl());
            this.tabPage8 = (new global::System.Windows.Forms.TabPage());
            this.label27 = (new global::System.Windows.Forms.Label());
            this.cbResizeMethod = (new global::System.Windows.Forms.ComboBox());
            this.label18 = (new global::System.Windows.Forms.Label());
            this.cbResizeLetterbox = (new global::System.Windows.Forms.CheckBox());
            this.label15 = (new global::System.Windows.Forms.Label());
            this.edResizeHeight = (new global::System.Windows.Forms.TextBox());
            this.edResizeWidth = (new global::System.Windows.Forms.TextBox());
            this.cbResizeEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage11 = (new global::System.Windows.Forms.TabPage());
            this.label201 = (new global::System.Windows.Forms.Label());
            this.label200 = (new global::System.Windows.Forms.Label());
            this.label199 = (new global::System.Windows.Forms.Label());
            this.label198 = (new global::System.Windows.Forms.Label());
            this.tbVideoContrast = (new global::System.Windows.Forms.TrackBar());
            this.tbVideoHue = (new global::System.Windows.Forms.TrackBar());
            this.tbVideoBrightness = (new global::System.Windows.Forms.TrackBar());
            this.tbVideoSaturation = (new global::System.Windows.Forms.TrackBar());
            this.cbVideoBalanceEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage17 = (new global::System.Windows.Forms.TabPage());
            this.btTextOverlayUpdate = (new global::System.Windows.Forms.Button());
            this.tabControl5 = (new global::System.Windows.Forms.TabControl());
            this.tabPage18 = (new global::System.Windows.Forms.TabPage());
            this.tbTextOverlayY = (new global::System.Windows.Forms.TrackBar());
            this.label42 = (new global::System.Windows.Forms.Label());
            this.tbTextOverlayX = (new global::System.Windows.Forms.TrackBar());
            this.label41 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayLineAlign = (new global::System.Windows.Forms.ComboBox());
            this.label37 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayHAlign = (new global::System.Windows.Forms.ComboBox());
            this.label33 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayVAlign = (new global::System.Windows.Forms.ComboBox());
            this.label32 = (new global::System.Windows.Forms.Label());
            this.edTextOverlayText = (new global::System.Windows.Forms.TextBox());
            this.label29 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayMode = (new global::System.Windows.Forms.ComboBox());
            this.label28 = (new global::System.Windows.Forms.Label());
            this.tabPage19 = (new global::System.Windows.Forms.TabPage());
            this.cbTextOverlayFontWeight = (new global::System.Windows.Forms.ComboBox());
            this.label7 = (new global::System.Windows.Forms.Label());
            this.pnTextOverlayColor = (new global::System.Windows.Forms.Panel());
            this.label40 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayAutosize = (new global::System.Windows.Forms.CheckBox());
            this.cbTextOverlayFontStyle = (new global::System.Windows.Forms.ComboBox());
            this.label39 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayFontWrapMode = (new global::System.Windows.Forms.ComboBox());
            this.label36 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayFontSize = (new global::System.Windows.Forms.ComboBox());
            this.label35 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayFontName = (new global::System.Windows.Forms.ComboBox());
            this.label34 = (new global::System.Windows.Forms.Label());
            this.cbTextOverlayEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage20 = (new global::System.Windows.Forms.TabPage());
            this.tbImageOverlayAlpha = (new global::System.Windows.Forms.TrackBar());
            this.label46 = (new global::System.Windows.Forms.Label());
            this.label45 = (new global::System.Windows.Forms.Label());
            this.label44 = (new global::System.Windows.Forms.Label());
            this.edImageOverlayY = (new global::System.Windows.Forms.TextBox());
            this.edImageOverlayX = (new global::System.Windows.Forms.TextBox());
            this.btImageOverlayOpen = (new global::System.Windows.Forms.Button());
            this.edImageOverlayFilename = (new global::System.Windows.Forms.TextBox());
            this.label43 = (new global::System.Windows.Forms.Label());
            this.cbImageOverlayEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage12 = (new global::System.Windows.Forms.TabPage());
            this.cbColorEffect = (new global::System.Windows.Forms.ComboBox());
            this.label20 = (new global::System.Windows.Forms.Label());
            this.cbColorEffectEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage13 = (new global::System.Windows.Forms.TabPage());
            this.cbFlipRotate = (new global::System.Windows.Forms.ComboBox());
            this.label21 = (new global::System.Windows.Forms.Label());
            this.cbFlipRotateEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage14 = (new global::System.Windows.Forms.TabPage());
            this.cbDeinterlaceDropOrphans = (new global::System.Windows.Forms.CheckBox());
            this.cbDeinterlaceIgnoreObscure = (new global::System.Windows.Forms.CheckBox());
            this.cbDeinterlaceLocking = (new global::System.Windows.Forms.ComboBox());
            this.label26 = (new global::System.Windows.Forms.Label());
            this.cbDeinterlaceMode = (new global::System.Windows.Forms.ComboBox());
            this.label25 = (new global::System.Windows.Forms.Label());
            this.cbDeinterlaceFieldLayout = (new global::System.Windows.Forms.ComboBox());
            this.label24 = (new global::System.Windows.Forms.Label());
            this.cbDeinterlaceFields = (new global::System.Windows.Forms.ComboBox());
            this.label23 = (new global::System.Windows.Forms.Label());
            this.cbDeinterlaceMethod = (new global::System.Windows.Forms.ComboBox());
            this.label22 = (new global::System.Windows.Forms.Label());
            this.cbDeinterlaceEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage15 = (new global::System.Windows.Forms.TabPage());
            this.tbGaussianBlur = (new global::System.Windows.Forms.TrackBar());
            this.cbGaussianBlurEnabled = (new global::System.Windows.Forms.CheckBox());
            this.tabPage16 = (new global::System.Windows.Forms.TabPage());
            this.cbFishEyeEnabled = (new global::System.Windows.Forms.CheckBox());
            this.label3 = (new global::System.Windows.Forms.Label());
            this.tabPage6 = (new global::System.Windows.Forms.TabPage());
            this.label505 = (new global::System.Windows.Forms.Label());
            this.rbMotionDetectionProcessor = (new global::System.Windows.Forms.ComboBox());
            this.label389 = (new global::System.Windows.Forms.Label());
            this.rbMotionDetectionDetector = (new global::System.Windows.Forms.ComboBox());
            this.label65 = (new global::System.Windows.Forms.Label());
            this.pbAFMotionLevel = (new global::System.Windows.Forms.ProgressBar());
            this.cbMotionDetection = (new global::System.Windows.Forms.CheckBox());
            this.tabPage9 = (new global::System.Windows.Forms.TabPage());
            this.edBarcodeMetadata = (new global::System.Windows.Forms.TextBox());
            this.label91 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeType = (new global::System.Windows.Forms.ComboBox());
            this.label90 = (new global::System.Windows.Forms.Label());
            this.btBarcodeReset = (new global::System.Windows.Forms.Button());
            this.edBarcode = (new global::System.Windows.Forms.TextBox());
            this.label89 = (new global::System.Windows.Forms.Label());
            this.cbBarcodeDetectionEnabled = (new global::System.Windows.Forms.CheckBox());
            this.colorDialog1 = (new global::System.Windows.Forms.ColorDialog());
            this.btSaveSnapshot = (new global::System.Windows.Forms.Button());
            this.dlgOpenImage = (new global::System.Windows.Forms.OpenFileDialog());
            this.videoView1 = (new global::VisioForge.Core.UI.WinForms.VideoView());
            this.mmLog = (new global::System.Windows.Forms.TextBox());
            this.cbDebugMode = (new global::System.Windows.Forms.CheckBox());
            this.label9 = (new global::System.Windows.Forms.Label());
            this.groupBox2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage24.SuspendLayout();
            this.tabPage22.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPLatency)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPUDPBufferSize)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPRTPBlockSize)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
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
            this.tabPage4.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudBalanceLevel)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoFeedback)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoIntensity)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoDelay)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoContrast)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoHue)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoBrightness)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoSaturation)).BeginInit();
            this.tabPage17.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage18.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTextOverlayY)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTextOverlayX)).BeginInit();
            this.tabPage19.SuspendLayout();
            this.tabPage20.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbImageOverlayAlpha)).BeginInit();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGaussianBlur)).BeginInit();
            this.tabPage16.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmPosition
            // 
            this.tmPosition.Interval = (500);
            this.tmPosition.Tick += (this.tmPosition_Tick);
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
            this.groupBox2.Location = (new global::System.Drawing.Point(556, 591));
            this.groupBox2.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.groupBox2.Name = ("groupBox2");
            this.groupBox2.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.groupBox2.Size = (new global::System.Drawing.Size(690, 173));
            this.groupBox2.TabIndex = (20);
            this.groupBox2.TabStop = (false);
            this.groupBox2.Text = ("Controls");
            // 
            // btPrevFrame
            // 
            this.btPrevFrame.Location = (new global::System.Drawing.Point(409, 112));
            this.btPrevFrame.Name = ("btPrevFrame");
            this.btPrevFrame.Size = (new global::System.Drawing.Size(125, 44));
            this.btPrevFrame.TabIndex = (42);
            this.btPrevFrame.Text = ("Prev frame");
            this.btPrevFrame.UseVisualStyleBackColor = (true);
            this.btPrevFrame.Click += (this.btPrevFrame_Click);
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = (new global::System.Drawing.Point(541, 112));
            this.btNextFrame.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btNextFrame.Name = ("btNextFrame");
            this.btNextFrame.Size = (new global::System.Drawing.Size(125, 44));
            this.btNextFrame.TabIndex = (8);
            this.btNextFrame.Text = ("Next frame");
            this.btNextFrame.UseVisualStyleBackColor = (true);
            this.btNextFrame.Click += (this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = (new global::System.Drawing.Font("Microsoft Sans Serif", 8.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point));
            this.btStop.Location = (new global::System.Drawing.Point(300, 112));
            this.btStop.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btStop.Name = ("btStop");
            this.btStop.Size = (new global::System.Drawing.Size(76, 44));
            this.btStop.TabIndex = (7);
            this.btStop.Text = ("Stop");
            this.btStop.UseVisualStyleBackColor = (true);
            this.btStop.Click += (this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = (new global::System.Drawing.Point(204, 112));
            this.btPause.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btPause.Name = ("btPause");
            this.btPause.Size = (new global::System.Drawing.Size(86, 44));
            this.btPause.TabIndex = (6);
            this.btPause.Text = ("Pause");
            this.btPause.UseVisualStyleBackColor = (true);
            this.btPause.Click += (this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = (new global::System.Drawing.Point(91, 112));
            this.btResume.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
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
            this.btStart.Location = (new global::System.Drawing.Point(10, 112));
            this.btStart.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btStart.Name = ("btStart");
            this.btStart.Size = (new global::System.Drawing.Size(71, 44));
            this.btStart.TabIndex = (4);
            this.btStart.Text = ("Start");
            this.btStart.UseVisualStyleBackColor = (true);
            this.btStart.Click += (this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = (new global::System.Drawing.Point(535, 52));
            this.tbSpeed.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbSpeed.Maximum = (35);
            this.tbSpeed.Minimum = (-25);
            this.tbSpeed.Name = ("tbSpeed");
            this.tbSpeed.Size = (new global::System.Drawing.Size(149, 69));
            this.tbSpeed.TabIndex = (3);
            this.tbSpeed.Value = (10);
            this.tbSpeed.Scroll += (this.tbSpeed_Scroll);
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = (true);
            this.lbSpeed.Location = (new global::System.Drawing.Point(536, 21));
            this.lbSpeed.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbSpeed.Name = ("lbSpeed");
            this.lbSpeed.Size = (new global::System.Drawing.Size(95, 25));
            this.lbSpeed.TabIndex = (2);
            this.lbSpeed.Text = ("Speed: 1.0");
            // 
            // lbTimeline
            // 
            this.lbTimeline.AutoSize = (true);
            this.lbTimeline.Location = (new global::System.Drawing.Point(365, 52));
            this.lbTimeline.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbTimeline.Name = ("lbTimeline");
            this.lbTimeline.Size = (new global::System.Drawing.Size(155, 25));
            this.lbTimeline.TabIndex = (1);
            this.lbTimeline.Text = ("00:00:00/00:00:00");
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = (new global::System.Drawing.Point(10, 37));
            this.tbTimeline.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbTimeline.Maximum = (100);
            this.tbTimeline.Name = ("tbTimeline");
            this.tbTimeline.Size = (new global::System.Drawing.Size(345, 69));
            this.tbTimeline.TabIndex = (0);
            this.tbTimeline.Scroll += (this.tbTimeline_Scroll);
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Location = (new global::System.Drawing.Point(556, 48));
            this.edFilenameOrURL.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edFilenameOrURL.Name = ("edFilenameOrURL");
            this.edFilenameOrURL.Size = (new global::System.Drawing.Size(639, 31));
            this.edFilenameOrURL.TabIndex = (19);
            this.edFilenameOrURL.Text = ("c:\\samples\\!videox.mp4");
            // 
            // label14
            // 
            this.label14.AutoSize = (true);
            this.label14.Location = (new global::System.Drawing.Point(551, 18));
            this.label14.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label14.Name = ("label14");
            this.label14.Size = (new global::System.Drawing.Size(145, 25));
            this.label14.TabIndex = (18);
            this.label14.Text = ("File name or URL");
            // 
            // btSelectFile
            // 
            this.btSelectFile.Location = (new global::System.Drawing.Point(1209, 44));
            this.btSelectFile.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btSelectFile.Name = ("btSelectFile");
            this.btSelectFile.Size = (new global::System.Drawing.Size(38, 44));
            this.btSelectFile.TabIndex = (23);
            this.btSelectFile.Text = ("...");
            this.btSelectFile.UseVisualStyleBackColor = (true);
            this.btSelectFile.Click += (this.btSelectFile_Click);
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
            this.tabControl1.Location = (new global::System.Drawing.Point(20, 23));
            this.tabControl1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabControl1.Name = ("tabControl1");
            this.tabControl1.SelectedIndex = (0);
            this.tabControl1.Size = (new global::System.Drawing.Size(522, 1000));
            this.tabControl1.TabIndex = (25);
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.tabControl6);
            this.tabPage21.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage21.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage21.Name = ("tabPage21");
            this.tabPage21.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage21.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage21.TabIndex = (4);
            this.tabPage21.Text = ("Source settings");
            this.tabPage21.UseVisualStyleBackColor = (true);
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage24);
            this.tabControl6.Controls.Add(this.tabPage22);
            this.tabControl6.Controls.Add(this.tabPage23);
            this.tabControl6.Location = (new global::System.Drawing.Point(10, 12));
            this.tabControl6.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabControl6.Name = ("tabControl6");
            this.tabControl6.SelectedIndex = (0);
            this.tabControl6.Size = (new global::System.Drawing.Size(489, 927));
            this.tabControl6.TabIndex = (0);
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.cbSubtitlesCustomSettings);
            this.tabPage24.Controls.Add(this.cbSubtitlesEnabled);
            this.tabPage24.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage24.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage24.Name = ("tabPage24");
            this.tabPage24.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage24.Size = (new global::System.Drawing.Size(481, 889));
            this.tabPage24.TabIndex = (2);
            this.tabPage24.Text = ("Subtitles");
            this.tabPage24.UseVisualStyleBackColor = (true);
            // 
            // cbSubtitlesCustomSettings
            // 
            this.cbSubtitlesCustomSettings.AutoSize = (true);
            this.cbSubtitlesCustomSettings.Location = (new global::System.Drawing.Point(26, 75));
            this.cbSubtitlesCustomSettings.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbSubtitlesCustomSettings.Name = ("cbSubtitlesCustomSettings");
            this.cbSubtitlesCustomSettings.Size = (new global::System.Drawing.Size(438, 29));
            this.cbSubtitlesCustomSettings.TabIndex = (1);
            this.cbSubtitlesCustomSettings.Text = ("Use custom font settings from the Text overlay tab");
            this.cbSubtitlesCustomSettings.UseVisualStyleBackColor = (true);
            this.cbSubtitlesCustomSettings.CheckedChanged += (this.cbSubtitlesCustomSettings_CheckedChanged);
            // 
            // cbSubtitlesEnabled
            // 
            this.cbSubtitlesEnabled.AutoSize = (true);
            this.cbSubtitlesEnabled.Checked = (true);
            this.cbSubtitlesEnabled.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbSubtitlesEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbSubtitlesEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbSubtitlesEnabled.Name = ("cbSubtitlesEnabled");
            this.cbSubtitlesEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbSubtitlesEnabled.TabIndex = (0);
            this.cbSubtitlesEnabled.Text = ("Enabled");
            this.cbSubtitlesEnabled.UseVisualStyleBackColor = (true);
            this.cbSubtitlesEnabled.CheckedChanged += (this.cbSubtitlesEnabled_CheckedChanged);
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
            this.tabPage22.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage22.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage22.Name = ("tabPage22");
            this.tabPage22.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage22.Size = (new global::System.Drawing.Size(481, 889));
            this.tabPage22.TabIndex = (0);
            this.tabPage22.Text = ("RTSP");
            this.tabPage22.UseVisualStyleBackColor = (true);
            // 
            // cbRTSPProtocol
            // 
            this.cbRTSPProtocol.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbRTSPProtocol.FormattingEnabled = (true);
            this.cbRTSPProtocol.Items.AddRange(new global::System.Object[] { "Auto", "TCP", "UDP", "HTTP over RTSP" });
            this.cbRTSPProtocol.Location = (new global::System.Drawing.Point(26, 671));
            this.cbRTSPProtocol.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbRTSPProtocol.Name = ("cbRTSPProtocol");
            this.cbRTSPProtocol.Size = (new global::System.Drawing.Size(418, 33));
            this.cbRTSPProtocol.TabIndex = (14);
            // 
            // label50
            // 
            this.label50.AutoSize = (true);
            this.label50.Location = (new global::System.Drawing.Point(22, 640));
            this.label50.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label50.Name = ("label50");
            this.label50.Size = (new global::System.Drawing.Size(87, 25));
            this.label50.TabIndex = (13);
            this.label50.Text = ("Protocols");
            // 
            // lbRTSPLatency
            // 
            this.lbRTSPLatency.AutoSize = (true);
            this.lbRTSPLatency.Location = (new global::System.Drawing.Point(356, 496));
            this.lbRTSPLatency.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbRTSPLatency.Name = ("lbRTSPLatency");
            this.lbRTSPLatency.Size = (new global::System.Drawing.Size(42, 25));
            this.lbRTSPLatency.TabIndex = (12);
            this.lbRTSPLatency.Text = ("200");
            // 
            // tbRTSPLatency
            // 
            this.tbRTSPLatency.Location = (new global::System.Drawing.Point(26, 527));
            this.tbRTSPLatency.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbRTSPLatency.Maximum = (2000);
            this.tbRTSPLatency.Name = ("tbRTSPLatency");
            this.tbRTSPLatency.Size = (new global::System.Drawing.Size(420, 69));
            this.tbRTSPLatency.TabIndex = (11);
            this.tbRTSPLatency.TickFrequency = (20);
            this.tbRTSPLatency.Value = (200);
            this.tbRTSPLatency.Scroll += (this.tbRTSPLatency_Scroll);
            // 
            // label53
            // 
            this.label53.AutoSize = (true);
            this.label53.Location = (new global::System.Drawing.Point(22, 496));
            this.label53.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label53.Name = ("label53");
            this.label53.Size = (new global::System.Drawing.Size(110, 25));
            this.label53.TabIndex = (10);
            this.label53.Text = ("Latency (ms)");
            // 
            // lbRTSPUDPBufferSize
            // 
            this.lbRTSPUDPBufferSize.AutoSize = (true);
            this.lbRTSPUDPBufferSize.Location = (new global::System.Drawing.Point(356, 350));
            this.lbRTSPUDPBufferSize.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbRTSPUDPBufferSize.Name = ("lbRTSPUDPBufferSize");
            this.lbRTSPUDPBufferSize.Size = (new global::System.Drawing.Size(42, 25));
            this.lbRTSPUDPBufferSize.TabIndex = (9);
            this.lbRTSPUDPBufferSize.Text = ("512");
            // 
            // tbRTSPUDPBufferSize
            // 
            this.tbRTSPUDPBufferSize.Location = (new global::System.Drawing.Point(26, 381));
            this.tbRTSPUDPBufferSize.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbRTSPUDPBufferSize.Maximum = (512);
            this.tbRTSPUDPBufferSize.Name = ("tbRTSPUDPBufferSize");
            this.tbRTSPUDPBufferSize.Size = (new global::System.Drawing.Size(420, 69));
            this.tbRTSPUDPBufferSize.SmallChange = (4);
            this.tbRTSPUDPBufferSize.TabIndex = (8);
            this.tbRTSPUDPBufferSize.TickFrequency = (10);
            this.tbRTSPUDPBufferSize.Value = (512);
            this.tbRTSPUDPBufferSize.Scroll += (this.tbRTSPUDPBufferSize_Scroll);
            // 
            // label52
            // 
            this.label52.AutoSize = (true);
            this.label52.Location = (new global::System.Drawing.Point(22, 350));
            this.label52.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label52.Name = ("label52");
            this.label52.Size = (new global::System.Drawing.Size(169, 25));
            this.label52.TabIndex = (7);
            this.label52.Text = ("UDP buffer size (KB)");
            // 
            // lbRTSPRTPBlockSize
            // 
            this.lbRTSPRTPBlockSize.AutoSize = (true);
            this.lbRTSPRTPBlockSize.Location = (new global::System.Drawing.Point(356, 206));
            this.lbRTSPRTPBlockSize.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbRTSPRTPBlockSize.Name = ("lbRTSPRTPBlockSize");
            this.lbRTSPRTPBlockSize.Size = (new global::System.Drawing.Size(22, 25));
            this.lbRTSPRTPBlockSize.TabIndex = (6);
            this.lbRTSPRTPBlockSize.Text = ("0");
            // 
            // tbRTSPRTPBlockSize
            // 
            this.tbRTSPRTPBlockSize.Location = (new global::System.Drawing.Point(26, 237));
            this.tbRTSPRTPBlockSize.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbRTSPRTPBlockSize.Maximum = (64);
            this.tbRTSPRTPBlockSize.Name = ("tbRTSPRTPBlockSize");
            this.tbRTSPRTPBlockSize.Size = (new global::System.Drawing.Size(420, 69));
            this.tbRTSPRTPBlockSize.SmallChange = (4);
            this.tbRTSPRTPBlockSize.TabIndex = (5);
            this.tbRTSPRTPBlockSize.TickFrequency = (4);
            this.tbRTSPRTPBlockSize.Scroll += (this.tbRTSPRTPBlockSize_Scroll);
            // 
            // label49
            // 
            this.label49.AutoSize = (true);
            this.label49.Location = (new global::System.Drawing.Point(22, 206));
            this.label49.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label49.Name = ("label49");
            this.label49.Size = (new global::System.Drawing.Size(235, 25));
            this.label49.TabIndex = (4);
            this.label49.Text = ("RTP block size (KB, 0 is auto)");
            // 
            // edRTSPPassword
            // 
            this.edRTSPPassword.Location = (new global::System.Drawing.Point(26, 144));
            this.edRTSPPassword.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edRTSPPassword.Name = ("edRTSPPassword");
            this.edRTSPPassword.Size = (new global::System.Drawing.Size(418, 31));
            this.edRTSPPassword.TabIndex = (3);
            // 
            // label48
            // 
            this.label48.AutoSize = (true);
            this.label48.Location = (new global::System.Drawing.Point(22, 113));
            this.label48.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label48.Name = ("label48");
            this.label48.Size = (new global::System.Drawing.Size(87, 25));
            this.label48.TabIndex = (2);
            this.label48.Text = ("Password");
            // 
            // edRTSPUserName
            // 
            this.edRTSPUserName.Location = (new global::System.Drawing.Point(26, 56));
            this.edRTSPUserName.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edRTSPUserName.Name = ("edRTSPUserName");
            this.edRTSPUserName.Size = (new global::System.Drawing.Size(418, 31));
            this.edRTSPUserName.TabIndex = (1);
            // 
            // label47
            // 
            this.label47.AutoSize = (true);
            this.label47.Location = (new global::System.Drawing.Point(22, 25));
            this.label47.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label47.Name = ("label47");
            this.label47.Size = (new global::System.Drawing.Size(96, 25));
            this.label47.TabIndex = (0);
            this.label47.Text = ("User name");
            // 
            // tabPage23
            // 
            this.tabPage23.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage23.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage23.Name = ("tabPage23");
            this.tabPage23.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage23.Size = (new global::System.Drawing.Size(481, 889));
            this.tabPage23.TabIndex = (1);
            this.tabPage23.Text = ("Other");
            this.tabPage23.UseVisualStyleBackColor = (true);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btReadInfo);
            this.tabPage1.Controls.Add(this.mmInfo);
            this.tabPage1.Controls.Add(this.btReadTags);
            this.tabPage1.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage1.Name = ("tabPage1");
            this.tabPage1.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage1.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage1.TabIndex = (0);
            this.tabPage1.Text = ("Media info");
            this.tabPage1.UseVisualStyleBackColor = (true);
            // 
            // btReadInfo
            // 
            this.btReadInfo.Location = (new global::System.Drawing.Point(26, 575));
            this.btReadInfo.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btReadInfo.Name = ("btReadInfo");
            this.btReadInfo.Size = (new global::System.Drawing.Size(125, 44));
            this.btReadInfo.TabIndex = (5);
            this.btReadInfo.Text = ("Read info");
            this.btReadInfo.UseVisualStyleBackColor = (true);
            this.btReadInfo.Click += (this.btReadInfo_Click);
            // 
            // mmInfo
            // 
            this.mmInfo.Location = (new global::System.Drawing.Point(26, 35));
            this.mmInfo.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.mmInfo.Multiline = (true);
            this.mmInfo.Name = ("mmInfo");
            this.mmInfo.ScrollBars = (global::System.Windows.Forms.ScrollBars.Both);
            this.mmInfo.Size = (new global::System.Drawing.Size(449, 525));
            this.mmInfo.TabIndex = (4);
            // 
            // btReadTags
            // 
            this.btReadTags.Location = (new global::System.Drawing.Point(162, 575));
            this.btReadTags.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btReadTags.Name = ("btReadTags");
            this.btReadTags.Size = (new global::System.Drawing.Size(125, 44));
            this.btReadTags.TabIndex = (3);
            this.btReadTags.Text = ("Read tags");
            this.btReadTags.UseVisualStyleBackColor = (true);
            this.btReadTags.Click += (this.btReadTags_Click);
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
            this.tabPage2.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage2.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage2.Name = ("tabPage2");
            this.tabPage2.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage2.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage2.TabIndex = (1);
            this.tabPage2.Text = ("Audio output");
            this.tabPage2.UseVisualStyleBackColor = (true);
            // 
            // cbAudioStream
            // 
            this.cbAudioStream.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbAudioStream.FormattingEnabled = (true);
            this.cbAudioStream.Location = (new global::System.Drawing.Point(26, 240));
            this.cbAudioStream.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudioStream.Name = ("cbAudioStream");
            this.cbAudioStream.Size = (new global::System.Drawing.Size(434, 33));
            this.cbAudioStream.TabIndex = (32);
            this.cbAudioStream.SelectedIndexChanged += (this.cbAudioStream_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = (true);
            this.label8.Location = (new global::System.Drawing.Point(22, 209));
            this.label8.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label8.Name = ("label8");
            this.label8.Size = (new global::System.Drawing.Size(67, 25));
            this.label8.TabIndex = (31);
            this.label8.Text = ("Stream");
            // 
            // label6
            // 
            this.label6.AutoSize = (true);
            this.label6.Location = (new global::System.Drawing.Point(237, 102));
            this.label6.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label6.Name = ("label6");
            this.label6.Size = (new global::System.Drawing.Size(72, 25));
            this.label6.TabIndex = (28);
            this.label6.Text = ("Volume");
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVolume1.Location = (new global::System.Drawing.Point(237, 133));
            this.tbVolume1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbVolume1.Maximum = (100);
            this.tbVolume1.Name = ("tbVolume1");
            this.tbVolume1.Size = (new global::System.Drawing.Size(142, 69));
            this.tbVolume1.TabIndex = (27);
            this.tbVolume1.Value = (85);
            this.tbVolume1.Scroll += (this.tbVolume1_Scroll);
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = (true);
            this.cbPlayAudio.Checked = (true);
            this.cbPlayAudio.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbPlayAudio.Location = (new global::System.Drawing.Point(26, 98));
            this.cbPlayAudio.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbPlayAudio.Name = ("cbPlayAudio");
            this.cbPlayAudio.Size = (new global::System.Drawing.Size(120, 29));
            this.cbPlayAudio.TabIndex = (25);
            this.cbPlayAudio.Text = ("Play audio");
            this.cbPlayAudio.UseVisualStyleBackColor = (true);
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbAudioOutputDevice.FormattingEnabled = (true);
            this.cbAudioOutputDevice.Location = (new global::System.Drawing.Point(26, 46));
            this.cbAudioOutputDevice.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudioOutputDevice.Name = ("cbAudioOutputDevice");
            this.cbAudioOutputDevice.Size = (new global::System.Drawing.Size(434, 33));
            this.cbAudioOutputDevice.TabIndex = (24);
            // 
            // label5
            // 
            this.label5.AutoSize = (true);
            this.label5.Location = (new global::System.Drawing.Point(22, 19));
            this.label5.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label5.Name = ("label5");
            this.label5.Size = (new global::System.Drawing.Size(119, 25));
            this.label5.TabIndex = (23);
            this.label5.Text = ("Audio output");
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = (-60F);
            this.volumeMeter2.BackColor = (global::System.Drawing.Color.Gainsboro);
            this.volumeMeter2.Boost = (1F);
            this.volumeMeter2.Location = (new global::System.Drawing.Point(89, 607));
            this.volumeMeter2.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.volumeMeter2.MaxDb = (18F);
            this.volumeMeter2.MinDb = (-60F);
            this.volumeMeter2.Name = ("volumeMeter2");
            this.volumeMeter2.Size = (new global::System.Drawing.Size(38, 281));
            this.volumeMeter2.TabIndex = (30);
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = (-60F);
            this.volumeMeter1.BackColor = (global::System.Drawing.Color.Gainsboro);
            this.volumeMeter1.Boost = (1F);
            this.volumeMeter1.Location = (new global::System.Drawing.Point(40, 607));
            this.volumeMeter1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.volumeMeter1.MaxDb = (18F);
            this.volumeMeter1.MinDb = (-60F);
            this.volumeMeter1.Name = ("volumeMeter1");
            this.volumeMeter1.Size = (new global::System.Drawing.Size(38, 281));
            this.volumeMeter1.TabIndex = (29);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.tabControl18);
            this.tabPage3.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage3.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage3.Name = ("tabPage3");
            this.tabPage3.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage3.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage3.TabIndex = (2);
            this.tabPage3.Text = ("Audio processing");
            this.tabPage3.UseVisualStyleBackColor = (true);
            // 
            // label31
            // 
            this.label31.AutoSize = (true);
            this.label31.Location = (new global::System.Drawing.Point(10, 25));
            this.label31.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label31.Name = ("label31");
            this.label31.Size = (new global::System.Drawing.Size(480, 25));
            this.label31.TabIndex = (7);
            this.label31.Text = ("Enable effects before Start. More effects available using API");
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Controls.Add(this.tabPage4);
            this.tabControl18.Controls.Add(this.tabPage5);
            this.tabControl18.Location = (new global::System.Drawing.Point(20, 68));
            this.tabControl18.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabControl18.Name = ("tabControl18");
            this.tabControl18.SelectedIndex = (0);
            this.tabControl18.Size = (new global::System.Drawing.Size(471, 850));
            this.tabControl18.TabIndex = (6);
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.label231);
            this.tabPage71.Controls.Add(this.label230);
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage71.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage71.Name = ("tabPage71");
            this.tabPage71.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage71.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage71.TabIndex = (0);
            this.tabPage71.Text = ("Amplify");
            this.tabPage71.UseVisualStyleBackColor = (true);
            // 
            // label231
            // 
            this.label231.AutoSize = (true);
            this.label231.Location = (new global::System.Drawing.Point(355, 102));
            this.label231.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label231.Name = ("label231");
            this.label231.Size = (new global::System.Drawing.Size(57, 25));
            this.label231.TabIndex = (5);
            this.label231.Text = ("400%");
            // 
            // label230
            // 
            this.label230.AutoSize = (true);
            this.label230.Location = (new global::System.Drawing.Point(114, 102));
            this.label230.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label230.Name = ("label230");
            this.label230.Size = (new global::System.Drawing.Size(57, 25));
            this.label230.TabIndex = (4);
            this.label230.Text = ("100%");
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudAmplifyAmp.Location = (new global::System.Drawing.Point(26, 132));
            this.tbAudAmplifyAmp.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudAmplifyAmp.Maximum = (400);
            this.tbAudAmplifyAmp.Name = ("tbAudAmplifyAmp");
            this.tbAudAmplifyAmp.Size = (new global::System.Drawing.Size(384, 69));
            this.tbAudAmplifyAmp.TabIndex = (3);
            this.tbAudAmplifyAmp.TickFrequency = (50);
            this.tbAudAmplifyAmp.Value = (100);
            this.tbAudAmplifyAmp.Scroll += (this.tbAudAmplifyAmp_Scroll);
            // 
            // label95
            // 
            this.label95.AutoSize = (true);
            this.label95.Location = (new global::System.Drawing.Point(22, 102));
            this.label95.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label95.Name = ("label95");
            this.label95.Size = (new global::System.Drawing.Size(99, 25));
            this.label95.TabIndex = (2);
            this.label95.Text = ("Boost ratio");
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = (true);
            this.cbAudAmplifyEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbAudAmplifyEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudAmplifyEnabled.Name = ("cbAudAmplifyEnabled");
            this.cbAudAmplifyEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudAmplifyEnabled.TabIndex = (1);
            this.cbAudAmplifyEnabled.Text = ("Enabled");
            this.cbAudAmplifyEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage72.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage72.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage72.Name = ("tabPage72");
            this.tabPage72.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage72.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage72.TabIndex = (1);
            this.tabPage72.Text = ("Equalizer");
            this.tabPage72.UseVisualStyleBackColor = (true);
            // 
            // btAudEqUpdate
            // 
            this.btAudEqUpdate.Location = (new global::System.Drawing.Point(291, 369));
            this.btAudEqUpdate.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btAudEqUpdate.Name = ("btAudEqUpdate");
            this.btAudEqUpdate.Size = (new global::System.Drawing.Size(125, 44));
            this.btAudEqUpdate.TabIndex = (26);
            this.btAudEqUpdate.Text = ("Update");
            this.btAudEqUpdate.UseVisualStyleBackColor = (true);
            this.btAudEqUpdate.Click += (this.btAudEqUpdate_Click);
            // 
            // label242
            // 
            this.label242.AutoSize = (true);
            this.label242.Location = (new global::System.Drawing.Point(351, 300));
            this.label242.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label242.Name = ("label242");
            this.label242.Size = (new global::System.Drawing.Size(42, 25));
            this.label242.TabIndex = (23);
            this.label242.Text = ("15K");
            // 
            // label241
            // 
            this.label241.AutoSize = (true);
            this.label241.Location = (new global::System.Drawing.Point(310, 300));
            this.label241.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label241.Name = ("label241");
            this.label241.Size = (new global::System.Drawing.Size(52, 25));
            this.label241.TabIndex = (22);
            this.label241.Text = ("7523");
            // 
            // label240
            // 
            this.label240.AutoSize = (true);
            this.label240.Location = (new global::System.Drawing.Point(269, 300));
            this.label240.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label240.Name = ("label240");
            this.label240.Size = (new global::System.Drawing.Size(52, 25));
            this.label240.TabIndex = (21);
            this.label240.Text = ("3770");
            // 
            // label239
            // 
            this.label239.AutoSize = (true);
            this.label239.Location = (new global::System.Drawing.Point(224, 300));
            this.label239.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label239.Name = ("label239");
            this.label239.Size = (new global::System.Drawing.Size(52, 25));
            this.label239.TabIndex = (20);
            this.label239.Text = ("1889");
            // 
            // label238
            // 
            this.label238.AutoSize = (true);
            this.label238.Location = (new global::System.Drawing.Point(191, 300));
            this.label238.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label238.Name = ("label238");
            this.label238.Size = (new global::System.Drawing.Size(42, 25));
            this.label238.TabIndex = (19);
            this.label238.Text = ("947");
            // 
            // label237
            // 
            this.label237.AutoSize = (true);
            this.label237.Location = (new global::System.Drawing.Point(156, 300));
            this.label237.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label237.Name = ("label237");
            this.label237.Size = (new global::System.Drawing.Size(42, 25));
            this.label237.TabIndex = (18);
            this.label237.Text = ("474");
            // 
            // label236
            // 
            this.label236.AutoSize = (true);
            this.label236.Location = (new global::System.Drawing.Point(122, 300));
            this.label236.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label236.Name = ("label236");
            this.label236.Size = (new global::System.Drawing.Size(42, 25));
            this.label236.TabIndex = (17);
            this.label236.Text = ("237");
            // 
            // label235
            // 
            this.label235.AutoSize = (true);
            this.label235.Location = (new global::System.Drawing.Point(86, 300));
            this.label235.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label235.Name = ("label235");
            this.label235.Size = (new global::System.Drawing.Size(42, 25));
            this.label235.TabIndex = (16);
            this.label235.Text = ("119");
            // 
            // label234
            // 
            this.label234.AutoSize = (true);
            this.label234.Location = (new global::System.Drawing.Point(60, 300));
            this.label234.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label234.Name = ("label234");
            this.label234.Size = (new global::System.Drawing.Size(32, 25));
            this.label234.TabIndex = (15);
            this.label234.Text = ("59");
            // 
            // label233
            // 
            this.label233.AutoSize = (true);
            this.label233.Location = (new global::System.Drawing.Point(30, 300));
            this.label233.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label233.Name = ("label233");
            this.label233.Size = (new global::System.Drawing.Size(32, 25));
            this.label233.TabIndex = (14);
            this.label233.Text = ("29");
            // 
            // label232
            // 
            this.label232.AutoSize = (true);
            this.label232.Location = (new global::System.Drawing.Point(196, 63));
            this.label232.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label232.Name = ("label232");
            this.label232.Size = (new global::System.Drawing.Size(22, 25));
            this.label232.TabIndex = (13);
            this.label232.Text = ("0");
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq9.Location = (new global::System.Drawing.Point(342, 94));
            this.tbAudEq9.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq9.Maximum = (12);
            this.tbAudEq9.Minimum = (-24);
            this.tbAudEq9.Name = ("tbAudEq9");
            this.tbAudEq9.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq9.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq9.TabIndex = (12);
            this.tbAudEq9.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq8.Location = (new global::System.Drawing.Point(306, 94));
            this.tbAudEq8.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq8.Maximum = (12);
            this.tbAudEq8.Minimum = (-24);
            this.tbAudEq8.Name = ("tbAudEq8");
            this.tbAudEq8.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq8.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq8.TabIndex = (11);
            this.tbAudEq8.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq7.Location = (new global::System.Drawing.Point(270, 94));
            this.tbAudEq7.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq7.Maximum = (12);
            this.tbAudEq7.Minimum = (-24);
            this.tbAudEq7.Name = ("tbAudEq7");
            this.tbAudEq7.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq7.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq7.TabIndex = (10);
            this.tbAudEq7.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq6.Location = (new global::System.Drawing.Point(235, 94));
            this.tbAudEq6.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq6.Maximum = (12);
            this.tbAudEq6.Minimum = (-24);
            this.tbAudEq6.Name = ("tbAudEq6");
            this.tbAudEq6.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq6.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq6.TabIndex = (9);
            this.tbAudEq6.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq5.Location = (new global::System.Drawing.Point(200, 94));
            this.tbAudEq5.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq5.Maximum = (12);
            this.tbAudEq5.Minimum = (-24);
            this.tbAudEq5.Name = ("tbAudEq5");
            this.tbAudEq5.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq5.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq5.TabIndex = (8);
            this.tbAudEq5.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq4.Location = (new global::System.Drawing.Point(166, 94));
            this.tbAudEq4.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq4.Maximum = (12);
            this.tbAudEq4.Minimum = (-24);
            this.tbAudEq4.Name = ("tbAudEq4");
            this.tbAudEq4.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq4.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq4.TabIndex = (7);
            this.tbAudEq4.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq3.Location = (new global::System.Drawing.Point(131, 94));
            this.tbAudEq3.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq3.Maximum = (12);
            this.tbAudEq3.Minimum = (-24);
            this.tbAudEq3.Name = ("tbAudEq3");
            this.tbAudEq3.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq3.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq3.TabIndex = (6);
            this.tbAudEq3.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq2.Location = (new global::System.Drawing.Point(96, 94));
            this.tbAudEq2.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq2.Maximum = (12);
            this.tbAudEq2.Minimum = (-24);
            this.tbAudEq2.Name = ("tbAudEq2");
            this.tbAudEq2.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq2.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq2.TabIndex = (5);
            this.tbAudEq2.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq1.Location = (new global::System.Drawing.Point(62, 94));
            this.tbAudEq1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq1.Maximum = (12);
            this.tbAudEq1.Minimum = (-24);
            this.tbAudEq1.Name = ("tbAudEq1");
            this.tbAudEq1.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq1.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq1.TabIndex = (4);
            this.tbAudEq1.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEq0.Location = (new global::System.Drawing.Point(29, 94));
            this.tbAudEq0.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEq0.Maximum = (12);
            this.tbAudEq0.Minimum = (-24);
            this.tbAudEq0.Name = ("tbAudEq0");
            this.tbAudEq0.Orientation = (global::System.Windows.Forms.Orientation.Vertical);
            this.tbAudEq0.Size = (new global::System.Drawing.Size(69, 200));
            this.tbAudEq0.TabIndex = (3);
            this.tbAudEq0.TickStyle = (global::System.Windows.Forms.TickStyle.None);
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = (true);
            this.cbAudEqualizerEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbAudEqualizerEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudEqualizerEnabled.Name = ("cbAudEqualizerEnabled");
            this.cbAudEqualizerEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudEqualizerEnabled.TabIndex = (2);
            this.cbAudEqualizerEnabled.Text = ("Enabled");
            this.cbAudEqualizerEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.tbAudBalanceLevel);
            this.tabPage4.Controls.Add(this.cbAudBalanceEnabled);
            this.tabPage4.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage4.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage4.Name = ("tabPage4");
            this.tabPage4.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage4.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage4.TabIndex = (2);
            this.tabPage4.Text = ("Balance");
            this.tabPage4.UseVisualStyleBackColor = (true);
            // 
            // label1
            // 
            this.label1.AutoSize = (true);
            this.label1.Location = (new global::System.Drawing.Point(356, 96));
            this.label1.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label1.Name = ("label1");
            this.label1.Size = (new global::System.Drawing.Size(54, 25));
            this.label1.TabIndex = (9);
            this.label1.Text = ("Right");
            // 
            // label2
            // 
            this.label2.AutoSize = (true);
            this.label2.Location = (new global::System.Drawing.Point(22, 96));
            this.label2.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label2.Name = ("label2");
            this.label2.Size = (new global::System.Drawing.Size(41, 25));
            this.label2.TabIndex = (8);
            this.label2.Text = ("Left");
            // 
            // tbAudBalanceLevel
            // 
            this.tbAudBalanceLevel.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudBalanceLevel.Location = (new global::System.Drawing.Point(26, 127));
            this.tbAudBalanceLevel.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudBalanceLevel.Minimum = (-10);
            this.tbAudBalanceLevel.Name = ("tbAudBalanceLevel");
            this.tbAudBalanceLevel.Size = (new global::System.Drawing.Size(384, 69));
            this.tbAudBalanceLevel.TabIndex = (7);
            this.tbAudBalanceLevel.Scroll += (this.tbAudBalanceLevel_Scroll);
            // 
            // cbAudBalanceEnabled
            // 
            this.cbAudBalanceEnabled.AutoSize = (true);
            this.cbAudBalanceEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbAudBalanceEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudBalanceEnabled.Name = ("cbAudBalanceEnabled");
            this.cbAudBalanceEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudBalanceEnabled.TabIndex = (3);
            this.cbAudBalanceEnabled.Text = ("Enabled");
            this.cbAudBalanceEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage5.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage5.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage5.Name = ("tabPage5");
            this.tabPage5.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage5.Size = (new global::System.Drawing.Size(463, 812));
            this.tabPage5.TabIndex = (3);
            this.tabPage5.Text = ("Echo");
            this.tabPage5.UseVisualStyleBackColor = (true);
            // 
            // lbAudEchoFeedback
            // 
            this.lbAudEchoFeedback.AutoSize = (true);
            this.lbAudEchoFeedback.Location = (new global::System.Drawing.Point(355, 293));
            this.lbAudEchoFeedback.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbAudEchoFeedback.Name = ("lbAudEchoFeedback");
            this.lbAudEchoFeedback.Size = (new global::System.Drawing.Size(22, 25));
            this.lbAudEchoFeedback.TabIndex = (14);
            this.lbAudEchoFeedback.Text = ("0");
            // 
            // tbAudEchoFeedback
            // 
            this.tbAudEchoFeedback.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEchoFeedback.Location = (new global::System.Drawing.Point(26, 323));
            this.tbAudEchoFeedback.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEchoFeedback.Maximum = (100);
            this.tbAudEchoFeedback.Name = ("tbAudEchoFeedback");
            this.tbAudEchoFeedback.Size = (new global::System.Drawing.Size(384, 69));
            this.tbAudEchoFeedback.TabIndex = (13);
            this.tbAudEchoFeedback.Scroll += (this.tbAudEchoFeedback_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = (true);
            this.label19.Location = (new global::System.Drawing.Point(22, 293));
            this.label19.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label19.Name = ("label19");
            this.label19.Size = (new global::System.Drawing.Size(87, 25));
            this.label19.TabIndex = (12);
            this.label19.Text = ("Feedback");
            // 
            // lbAudEchoIntensity
            // 
            this.lbAudEchoIntensity.AutoSize = (true);
            this.lbAudEchoIntensity.Location = (new global::System.Drawing.Point(355, 194));
            this.lbAudEchoIntensity.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbAudEchoIntensity.Name = ("lbAudEchoIntensity");
            this.lbAudEchoIntensity.Size = (new global::System.Drawing.Size(36, 25));
            this.lbAudEchoIntensity.TabIndex = (11);
            this.lbAudEchoIntensity.Text = ("0.8");
            // 
            // tbAudEchoIntensity
            // 
            this.tbAudEchoIntensity.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEchoIntensity.Location = (new global::System.Drawing.Point(26, 225));
            this.tbAudEchoIntensity.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEchoIntensity.Maximum = (100);
            this.tbAudEchoIntensity.Name = ("tbAudEchoIntensity");
            this.tbAudEchoIntensity.Size = (new global::System.Drawing.Size(384, 69));
            this.tbAudEchoIntensity.TabIndex = (10);
            this.tbAudEchoIntensity.Value = (80);
            this.tbAudEchoIntensity.Scroll += (this.tbAudEchoIntensity_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = (true);
            this.label17.Location = (new global::System.Drawing.Point(22, 194));
            this.label17.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label17.Name = ("label17");
            this.label17.Size = (new global::System.Drawing.Size(79, 25));
            this.label17.TabIndex = (9);
            this.label17.Text = ("Intensity");
            // 
            // lbAudEchoDelay
            // 
            this.lbAudEchoDelay.AutoSize = (true);
            this.lbAudEchoDelay.Location = (new global::System.Drawing.Point(355, 96));
            this.lbAudEchoDelay.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.lbAudEchoDelay.Name = ("lbAudEchoDelay");
            this.lbAudEchoDelay.Size = (new global::System.Drawing.Size(42, 25));
            this.lbAudEchoDelay.TabIndex = (8);
            this.lbAudEchoDelay.Text = ("500");
            // 
            // tbAudEchoDelay
            // 
            this.tbAudEchoDelay.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbAudEchoDelay.Location = (new global::System.Drawing.Point(26, 127));
            this.tbAudEchoDelay.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbAudEchoDelay.Maximum = (1500);
            this.tbAudEchoDelay.Minimum = (100);
            this.tbAudEchoDelay.Name = ("tbAudEchoDelay");
            this.tbAudEchoDelay.Size = (new global::System.Drawing.Size(384, 69));
            this.tbAudEchoDelay.TabIndex = (7);
            this.tbAudEchoDelay.TickFrequency = (50);
            this.tbAudEchoDelay.Value = (500);
            this.tbAudEchoDelay.Scroll += (this.tbAudEchoDelay_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = (true);
            this.label4.Location = (new global::System.Drawing.Point(22, 96));
            this.label4.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label4.Name = ("label4");
            this.label4.Size = (new global::System.Drawing.Size(95, 25));
            this.label4.TabIndex = (6);
            this.label4.Text = ("Delay (ms)");
            // 
            // cbAudEchoEnabled
            // 
            this.cbAudEchoEnabled.AutoSize = (true);
            this.cbAudEchoEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbAudEchoEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbAudEchoEnabled.Name = ("cbAudEchoEnabled");
            this.cbAudEchoEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbAudEchoEnabled.TabIndex = (3);
            this.cbAudEchoEnabled.Text = ("Enabled");
            this.cbAudEchoEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl4);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage7.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage7.Name = ("tabPage7");
            this.tabPage7.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage7.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage7.TabIndex = (3);
            this.tabPage7.Text = ("Video processing");
            this.tabPage7.UseVisualStyleBackColor = (true);
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
            this.tabControl4.Location = (new global::System.Drawing.Point(15, 75));
            this.tabControl4.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabControl4.Name = ("tabControl4");
            this.tabControl4.SelectedIndex = (0);
            this.tabControl4.Size = (new global::System.Drawing.Size(480, 863));
            this.tabControl4.TabIndex = (9);
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
            this.tabPage8.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage8.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage8.Name = ("tabPage8");
            this.tabPage8.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage8.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage8.TabIndex = (0);
            this.tabPage8.Text = ("Resize");
            this.tabPage8.UseVisualStyleBackColor = (true);
            // 
            // label27
            // 
            this.label27.AutoSize = (true);
            this.label27.Location = (new global::System.Drawing.Point(22, 96));
            this.label27.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label27.Name = ("label27");
            this.label27.Size = (new global::System.Drawing.Size(95, 25));
            this.label27.TabIndex = (7);
            this.label27.Text = ("Resolution");
            // 
            // cbResizeMethod
            // 
            this.cbResizeMethod.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbResizeMethod.FormattingEnabled = (true);
            this.cbResizeMethod.Items.AddRange(new global::System.Object[] { "Nearest neighbour scaling (fast and low quality)", "Bilinear 2-tap scaling (slow, middle quality)", "4-tap sinc filter for scaling (slow)", "Lanczos filter for scaling (slow, high quality)", "Bilinear multitap filter", "Multitap sinc filter", "Multitap bicubic Hermite filter", "Multitap bicubic spline filter", "Multitap bicubic Catmull-Rom filter", "Multitap bicubic Mitchell filter" });
            this.cbResizeMethod.Location = (new global::System.Drawing.Point(26, 229));
            this.cbResizeMethod.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbResizeMethod.Name = ("cbResizeMethod");
            this.cbResizeMethod.Size = (new global::System.Drawing.Size(395, 33));
            this.cbResizeMethod.TabIndex = (6);
            // 
            // label18
            // 
            this.label18.AutoSize = (true);
            this.label18.Location = (new global::System.Drawing.Point(22, 198));
            this.label18.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label18.Name = ("label18");
            this.label18.Size = (new global::System.Drawing.Size(75, 25));
            this.label18.TabIndex = (5);
            this.label18.Text = ("Method");
            // 
            // cbResizeLetterbox
            // 
            this.cbResizeLetterbox.AutoSize = (true);
            this.cbResizeLetterbox.Location = (new global::System.Drawing.Point(234, 131));
            this.cbResizeLetterbox.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbResizeLetterbox.Name = ("cbResizeLetterbox");
            this.cbResizeLetterbox.Size = (new global::System.Drawing.Size(112, 29));
            this.cbResizeLetterbox.TabIndex = (4);
            this.cbResizeLetterbox.Text = ("Letterbox");
            this.cbResizeLetterbox.UseVisualStyleBackColor = (true);
            // 
            // label15
            // 
            this.label15.AutoSize = (true);
            this.label15.Location = (new global::System.Drawing.Point(105, 132));
            this.label15.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label15.Name = ("label15");
            this.label15.Size = (new global::System.Drawing.Size(20, 25));
            this.label15.TabIndex = (3);
            this.label15.Text = ("x");
            // 
            // edResizeHeight
            // 
            this.edResizeHeight.Location = (new global::System.Drawing.Point(134, 127));
            this.edResizeHeight.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edResizeHeight.Name = ("edResizeHeight");
            this.edResizeHeight.Size = (new global::System.Drawing.Size(66, 31));
            this.edResizeHeight.TabIndex = (2);
            this.edResizeHeight.Text = ("480");
            // 
            // edResizeWidth
            // 
            this.edResizeWidth.Location = (new global::System.Drawing.Point(26, 127));
            this.edResizeWidth.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edResizeWidth.Name = ("edResizeWidth");
            this.edResizeWidth.Size = (new global::System.Drawing.Size(66, 31));
            this.edResizeWidth.TabIndex = (1);
            this.edResizeWidth.Text = ("640");
            // 
            // cbResizeEnabled
            // 
            this.cbResizeEnabled.AutoSize = (true);
            this.cbResizeEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbResizeEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbResizeEnabled.Name = ("cbResizeEnabled");
            this.cbResizeEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbResizeEnabled.TabIndex = (0);
            this.cbResizeEnabled.Text = ("Enabled");
            this.cbResizeEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage11.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage11.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage11.Name = ("tabPage11");
            this.tabPage11.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage11.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage11.TabIndex = (1);
            this.tabPage11.Text = ("Color balance");
            this.tabPage11.UseVisualStyleBackColor = (true);
            // 
            // label201
            // 
            this.label201.AutoSize = (true);
            this.label201.Location = (new global::System.Drawing.Point(235, 175));
            this.label201.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label201.Name = ("label201");
            this.label201.Size = (new global::System.Drawing.Size(44, 25));
            this.label201.TabIndex = (74);
            this.label201.Text = ("Hue");
            // 
            // label200
            // 
            this.label200.AutoSize = (true);
            this.label200.Location = (new global::System.Drawing.Point(9, 175));
            this.label200.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label200.Name = ("label200");
            this.label200.Size = (new global::System.Drawing.Size(79, 25));
            this.label200.TabIndex = (73);
            this.label200.Text = ("Contrast");
            // 
            // label199
            // 
            this.label199.AutoSize = (true);
            this.label199.Location = (new global::System.Drawing.Point(235, 75));
            this.label199.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label199.Name = ("label199");
            this.label199.Size = (new global::System.Drawing.Size(93, 25));
            this.label199.TabIndex = (72);
            this.label199.Text = ("Saturation");
            // 
            // label198
            // 
            this.label198.AutoSize = (true);
            this.label198.Location = (new global::System.Drawing.Point(9, 75));
            this.label198.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label198.Name = ("label198");
            this.label198.Size = (new global::System.Drawing.Size(94, 25));
            this.label198.TabIndex = (71);
            this.label198.Text = ("Brightness");
            // 
            // tbVideoContrast
            // 
            this.tbVideoContrast.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVideoContrast.Location = (new global::System.Drawing.Point(4, 212));
            this.tbVideoContrast.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbVideoContrast.Maximum = (200);
            this.tbVideoContrast.Name = ("tbVideoContrast");
            this.tbVideoContrast.Size = (new global::System.Drawing.Size(216, 69));
            this.tbVideoContrast.TabIndex = (70);
            this.tbVideoContrast.Value = (100);
            this.tbVideoContrast.Scroll += (this.tbVideoContrast_Scroll);
            // 
            // tbVideoHue
            // 
            this.tbVideoHue.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVideoHue.Location = (new global::System.Drawing.Point(235, 212));
            this.tbVideoHue.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbVideoHue.Maximum = (100);
            this.tbVideoHue.Minimum = (-100);
            this.tbVideoHue.Name = ("tbVideoHue");
            this.tbVideoHue.Size = (new global::System.Drawing.Size(216, 69));
            this.tbVideoHue.TabIndex = (69);
            this.tbVideoHue.Scroll += (this.tbVideoHue_Scroll);
            // 
            // tbVideoBrightness
            // 
            this.tbVideoBrightness.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVideoBrightness.Location = (new global::System.Drawing.Point(4, 104));
            this.tbVideoBrightness.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbVideoBrightness.Maximum = (100);
            this.tbVideoBrightness.Minimum = (-100);
            this.tbVideoBrightness.Name = ("tbVideoBrightness");
            this.tbVideoBrightness.Size = (new global::System.Drawing.Size(216, 69));
            this.tbVideoBrightness.TabIndex = (68);
            this.tbVideoBrightness.Scroll += (this.tbVideoBrightness_Scroll);
            // 
            // tbVideoSaturation
            // 
            this.tbVideoSaturation.BackColor = (global::System.Drawing.SystemColors.Window);
            this.tbVideoSaturation.Location = (new global::System.Drawing.Point(235, 104));
            this.tbVideoSaturation.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbVideoSaturation.Maximum = (200);
            this.tbVideoSaturation.Name = ("tbVideoSaturation");
            this.tbVideoSaturation.Size = (new global::System.Drawing.Size(216, 69));
            this.tbVideoSaturation.TabIndex = (67);
            this.tbVideoSaturation.Value = (200);
            this.tbVideoSaturation.Scroll += (this.tbVideoSaturation_Scroll);
            // 
            // cbVideoBalanceEnabled
            // 
            this.cbVideoBalanceEnabled.AutoSize = (true);
            this.cbVideoBalanceEnabled.Location = (new global::System.Drawing.Point(11, 21));
            this.cbVideoBalanceEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbVideoBalanceEnabled.Name = ("cbVideoBalanceEnabled");
            this.cbVideoBalanceEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbVideoBalanceEnabled.TabIndex = (64);
            this.cbVideoBalanceEnabled.Text = ("Enabled");
            this.cbVideoBalanceEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.btTextOverlayUpdate);
            this.tabPage17.Controls.Add(this.tabControl5);
            this.tabPage17.Controls.Add(this.cbTextOverlayEnabled);
            this.tabPage17.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage17.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage17.Name = ("tabPage17");
            this.tabPage17.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage17.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage17.TabIndex = (7);
            this.tabPage17.Text = ("Text overlay");
            this.tabPage17.UseVisualStyleBackColor = (true);
            // 
            // btTextOverlayUpdate
            // 
            this.btTextOverlayUpdate.Location = (new global::System.Drawing.Point(325, 23));
            this.btTextOverlayUpdate.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btTextOverlayUpdate.Name = ("btTextOverlayUpdate");
            this.btTextOverlayUpdate.Size = (new global::System.Drawing.Size(125, 44));
            this.btTextOverlayUpdate.TabIndex = (9);
            this.btTextOverlayUpdate.Text = ("Update");
            this.btTextOverlayUpdate.UseVisualStyleBackColor = (true);
            this.btTextOverlayUpdate.Click += (this.btTextOverlayUpdate_Click);
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage18);
            this.tabControl5.Controls.Add(this.tabPage19);
            this.tabControl5.Location = (new global::System.Drawing.Point(15, 75));
            this.tabControl5.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabControl5.Name = ("tabControl5");
            this.tabControl5.SelectedIndex = (0);
            this.tabControl5.Size = (new global::System.Drawing.Size(442, 725));
            this.tabControl5.TabIndex = (8);
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
            this.tabPage18.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage18.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage18.Name = ("tabPage18");
            this.tabPage18.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage18.Size = (new global::System.Drawing.Size(434, 687));
            this.tabPage18.TabIndex = (0);
            this.tabPage18.Text = ("Main");
            this.tabPage18.UseVisualStyleBackColor = (true);
            // 
            // tbTextOverlayY
            // 
            this.tbTextOverlayY.Location = (new global::System.Drawing.Point(230, 531));
            this.tbTextOverlayY.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbTextOverlayY.Maximum = (100);
            this.tbTextOverlayY.Name = ("tbTextOverlayY");
            this.tbTextOverlayY.Size = (new global::System.Drawing.Size(174, 69));
            this.tbTextOverlayY.TabIndex = (23);
            this.tbTextOverlayY.Value = (20);
            // 
            // label42
            // 
            this.label42.AutoSize = (true);
            this.label42.Location = (new global::System.Drawing.Point(225, 494));
            this.label42.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label42.Name = ("label42");
            this.label42.Size = (new global::System.Drawing.Size(132, 25));
            this.label42.TabIndex = (22);
            this.label42.Text = ("Custom Y align");
            // 
            // tbTextOverlayX
            // 
            this.tbTextOverlayX.Location = (new global::System.Drawing.Point(24, 531));
            this.tbTextOverlayX.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbTextOverlayX.Maximum = (100);
            this.tbTextOverlayX.Name = ("tbTextOverlayX");
            this.tbTextOverlayX.Size = (new global::System.Drawing.Size(174, 69));
            this.tbTextOverlayX.TabIndex = (21);
            this.tbTextOverlayX.Value = (20);
            // 
            // label41
            // 
            this.label41.AutoSize = (true);
            this.label41.Location = (new global::System.Drawing.Point(18, 494));
            this.label41.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label41.Name = ("label41");
            this.label41.Size = (new global::System.Drawing.Size(133, 25));
            this.label41.TabIndex = (20);
            this.label41.Text = ("Custom X align");
            // 
            // cbTextOverlayLineAlign
            // 
            this.cbTextOverlayLineAlign.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayLineAlign.FormattingEnabled = (true);
            this.cbTextOverlayLineAlign.Items.AddRange(new global::System.Object[] { "Left", "Center", "Right" });
            this.cbTextOverlayLineAlign.Location = (new global::System.Drawing.Point(24, 429));
            this.cbTextOverlayLineAlign.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayLineAlign.Name = ("cbTextOverlayLineAlign");
            this.cbTextOverlayLineAlign.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayLineAlign.TabIndex = (19);
            // 
            // label37
            // 
            this.label37.AutoSize = (true);
            this.label37.Location = (new global::System.Drawing.Point(18, 398));
            this.label37.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label37.Name = ("label37");
            this.label37.Size = (new global::System.Drawing.Size(86, 25));
            this.label37.TabIndex = (18);
            this.label37.Text = ("Line align");
            // 
            // cbTextOverlayHAlign
            // 
            this.cbTextOverlayHAlign.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayHAlign.FormattingEnabled = (true);
            this.cbTextOverlayHAlign.Items.AddRange(new global::System.Object[] { "Left", "Center", "Right", "Custom" });
            this.cbTextOverlayHAlign.Location = (new global::System.Drawing.Point(24, 332));
            this.cbTextOverlayHAlign.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayHAlign.Name = ("cbTextOverlayHAlign");
            this.cbTextOverlayHAlign.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayHAlign.TabIndex = (15);
            // 
            // label33
            // 
            this.label33.AutoSize = (true);
            this.label33.Location = (new global::System.Drawing.Point(18, 302));
            this.label33.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label33.Name = ("label33");
            this.label33.Size = (new global::System.Drawing.Size(163, 25));
            this.label33.TabIndex = (14);
            this.label33.Text = ("Horizontal align (X)");
            // 
            // cbTextOverlayVAlign
            // 
            this.cbTextOverlayVAlign.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayVAlign.FormattingEnabled = (true);
            this.cbTextOverlayVAlign.Items.AddRange(new global::System.Object[] { "Baseline", "Bottom", "Top", "Custom", "Center" });
            this.cbTextOverlayVAlign.Location = (new global::System.Drawing.Point(24, 235));
            this.cbTextOverlayVAlign.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayVAlign.Name = ("cbTextOverlayVAlign");
            this.cbTextOverlayVAlign.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayVAlign.TabIndex = (13);
            // 
            // label32
            // 
            this.label32.AutoSize = (true);
            this.label32.Location = (new global::System.Drawing.Point(18, 204));
            this.label32.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label32.Name = ("label32");
            this.label32.Size = (new global::System.Drawing.Size(136, 25));
            this.label32.TabIndex = (12);
            this.label32.Text = ("Vertical align (Y)");
            // 
            // edTextOverlayText
            // 
            this.edTextOverlayText.Location = (new global::System.Drawing.Point(24, 146));
            this.edTextOverlayText.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edTextOverlayText.Name = ("edTextOverlayText");
            this.edTextOverlayText.Size = (new global::System.Drawing.Size(378, 31));
            this.edTextOverlayText.TabIndex = (11);
            this.edTextOverlayText.Text = ("Hello!");
            // 
            // label29
            // 
            this.label29.AutoSize = (true);
            this.label29.Location = (new global::System.Drawing.Point(18, 115));
            this.label29.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label29.Name = ("label29");
            this.label29.Size = (new global::System.Drawing.Size(42, 25));
            this.label29.TabIndex = (10);
            this.label29.Text = ("Text");
            // 
            // cbTextOverlayMode
            // 
            this.cbTextOverlayMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayMode.FormattingEnabled = (true);
            this.cbTextOverlayMode.Items.AddRange(new global::System.Object[] { "Custom text", "Timestamp", "System time" });
            this.cbTextOverlayMode.Location = (new global::System.Drawing.Point(24, 52));
            this.cbTextOverlayMode.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayMode.Name = ("cbTextOverlayMode");
            this.cbTextOverlayMode.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayMode.TabIndex = (9);
            // 
            // label28
            // 
            this.label28.AutoSize = (true);
            this.label28.Location = (new global::System.Drawing.Point(18, 21));
            this.label28.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label28.Name = ("label28");
            this.label28.Size = (new global::System.Drawing.Size(59, 25));
            this.label28.TabIndex = (8);
            this.label28.Text = ("Mode");
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
            this.tabPage19.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage19.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage19.Name = ("tabPage19");
            this.tabPage19.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage19.Size = (new global::System.Drawing.Size(434, 687));
            this.tabPage19.TabIndex = (1);
            this.tabPage19.Text = ("Font");
            this.tabPage19.UseVisualStyleBackColor = (true);
            // 
            // cbTextOverlayFontWeight
            // 
            this.cbTextOverlayFontWeight.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayFontWeight.FormattingEnabled = (true);
            this.cbTextOverlayFontWeight.Items.AddRange(new global::System.Object[] { "Thin", "UltraLight", "Light", "SemiLight", "Book", "Normal", "Medium", "SemiBold", "Bold", "UltraBold", "Heavy", "UltraHeavy" });
            this.cbTextOverlayFontWeight.Location = (new global::System.Drawing.Point(24, 319));
            this.cbTextOverlayFontWeight.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayFontWeight.Name = ("cbTextOverlayFontWeight");
            this.cbTextOverlayFontWeight.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayFontWeight.TabIndex = (24);
            // 
            // label7
            // 
            this.label7.AutoSize = (true);
            this.label7.Location = (new global::System.Drawing.Point(18, 288));
            this.label7.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label7.Name = ("label7");
            this.label7.Size = (new global::System.Drawing.Size(68, 25));
            this.label7.TabIndex = (23);
            this.label7.Text = ("Weight");
            // 
            // pnTextOverlayColor
            // 
            this.pnTextOverlayColor.BackColor = (global::System.Drawing.Color.Green);
            this.pnTextOverlayColor.Location = (new global::System.Drawing.Point(110, 473));
            this.pnTextOverlayColor.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.pnTextOverlayColor.Name = ("pnTextOverlayColor");
            this.pnTextOverlayColor.Size = (new global::System.Drawing.Size(56, 65));
            this.pnTextOverlayColor.TabIndex = (22);
            this.pnTextOverlayColor.Click += (this.pnTextOverlayColor_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = (true);
            this.label40.Location = (new global::System.Drawing.Point(18, 493));
            this.label40.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label40.Name = ("label40");
            this.label40.Size = (new global::System.Drawing.Size(55, 25));
            this.label40.TabIndex = (21);
            this.label40.Text = ("Color");
            // 
            // cbTextOverlayAutosize
            // 
            this.cbTextOverlayAutosize.AutoSize = (true);
            this.cbTextOverlayAutosize.Location = (new global::System.Drawing.Point(24, 396));
            this.cbTextOverlayAutosize.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayAutosize.Name = ("cbTextOverlayAutosize");
            this.cbTextOverlayAutosize.Size = (new global::System.Drawing.Size(106, 29));
            this.cbTextOverlayAutosize.TabIndex = (20);
            this.cbTextOverlayAutosize.Text = ("Autosize");
            this.cbTextOverlayAutosize.UseVisualStyleBackColor = (true);
            // 
            // cbTextOverlayFontStyle
            // 
            this.cbTextOverlayFontStyle.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayFontStyle.FormattingEnabled = (true);
            this.cbTextOverlayFontStyle.Items.AddRange(new global::System.Object[] { "Normal", "Oblique", "Italic" });
            this.cbTextOverlayFontStyle.Location = (new global::System.Drawing.Point(24, 143));
            this.cbTextOverlayFontStyle.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayFontStyle.Name = ("cbTextOverlayFontStyle");
            this.cbTextOverlayFontStyle.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayFontStyle.TabIndex = (19);
            // 
            // label39
            // 
            this.label39.AutoSize = (true);
            this.label39.Location = (new global::System.Drawing.Point(18, 112));
            this.label39.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label39.Name = ("label39");
            this.label39.Size = (new global::System.Drawing.Size(49, 25));
            this.label39.TabIndex = (18);
            this.label39.Text = ("Style");
            // 
            // cbTextOverlayFontWrapMode
            // 
            this.cbTextOverlayFontWrapMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayFontWrapMode.FormattingEnabled = (true);
            this.cbTextOverlayFontWrapMode.Items.AddRange(new global::System.Object[] { "None", "Word", "Char", "Word and char" });
            this.cbTextOverlayFontWrapMode.Location = (new global::System.Drawing.Point(24, 231));
            this.cbTextOverlayFontWrapMode.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayFontWrapMode.Name = ("cbTextOverlayFontWrapMode");
            this.cbTextOverlayFontWrapMode.Size = (new global::System.Drawing.Size(378, 33));
            this.cbTextOverlayFontWrapMode.TabIndex = (15);
            // 
            // label36
            // 
            this.label36.AutoSize = (true);
            this.label36.Location = (new global::System.Drawing.Point(18, 200));
            this.label36.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label36.Name = ("label36");
            this.label36.Size = (new global::System.Drawing.Size(107, 25));
            this.label36.TabIndex = (14);
            this.label36.Text = ("Wrap mode");
            // 
            // cbTextOverlayFontSize
            // 
            this.cbTextOverlayFontSize.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayFontSize.FormattingEnabled = (true);
            this.cbTextOverlayFontSize.Items.AddRange(new global::System.Object[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" });
            this.cbTextOverlayFontSize.Location = (new global::System.Drawing.Point(322, 52));
            this.cbTextOverlayFontSize.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayFontSize.Name = ("cbTextOverlayFontSize");
            this.cbTextOverlayFontSize.Size = (new global::System.Drawing.Size(79, 33));
            this.cbTextOverlayFontSize.TabIndex = (13);
            // 
            // label35
            // 
            this.label35.AutoSize = (true);
            this.label35.Location = (new global::System.Drawing.Point(316, 21));
            this.label35.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label35.Name = ("label35");
            this.label35.Size = (new global::System.Drawing.Size(43, 25));
            this.label35.TabIndex = (12);
            this.label35.Text = ("Size");
            // 
            // cbTextOverlayFontName
            // 
            this.cbTextOverlayFontName.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbTextOverlayFontName.FormattingEnabled = (true);
            this.cbTextOverlayFontName.Location = (new global::System.Drawing.Point(24, 52));
            this.cbTextOverlayFontName.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayFontName.Name = ("cbTextOverlayFontName");
            this.cbTextOverlayFontName.Size = (new global::System.Drawing.Size(286, 33));
            this.cbTextOverlayFontName.TabIndex = (11);
            // 
            // label34
            // 
            this.label34.AutoSize = (true);
            this.label34.Location = (new global::System.Drawing.Point(18, 21));
            this.label34.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label34.Name = ("label34");
            this.label34.Size = (new global::System.Drawing.Size(59, 25));
            this.label34.TabIndex = (10);
            this.label34.Text = ("Name");
            // 
            // cbTextOverlayEnabled
            // 
            this.cbTextOverlayEnabled.AutoSize = (true);
            this.cbTextOverlayEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbTextOverlayEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbTextOverlayEnabled.Name = ("cbTextOverlayEnabled");
            this.cbTextOverlayEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbTextOverlayEnabled.TabIndex = (1);
            this.cbTextOverlayEnabled.Text = ("Enabled");
            this.cbTextOverlayEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage20.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage20.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage20.Name = ("tabPage20");
            this.tabPage20.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage20.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage20.TabIndex = (8);
            this.tabPage20.Text = ("Image overlay");
            this.tabPage20.UseVisualStyleBackColor = (true);
            // 
            // tbImageOverlayAlpha
            // 
            this.tbImageOverlayAlpha.Location = (new global::System.Drawing.Point(26, 315));
            this.tbImageOverlayAlpha.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbImageOverlayAlpha.Maximum = (100);
            this.tbImageOverlayAlpha.Name = ("tbImageOverlayAlpha");
            this.tbImageOverlayAlpha.Size = (new global::System.Drawing.Size(174, 69));
            this.tbImageOverlayAlpha.TabIndex = (23);
            this.tbImageOverlayAlpha.Value = (100);
            // 
            // label46
            // 
            this.label46.AutoSize = (true);
            this.label46.Location = (new global::System.Drawing.Point(22, 279));
            this.label46.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label46.Name = ("label46");
            this.label46.Size = (new global::System.Drawing.Size(58, 25));
            this.label46.TabIndex = (22);
            this.label46.Text = ("Alpha");
            // 
            // label45
            // 
            this.label45.AutoSize = (true);
            this.label45.Location = (new global::System.Drawing.Point(22, 181));
            this.label45.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label45.Name = ("label45");
            this.label45.Size = (new global::System.Drawing.Size(75, 25));
            this.label45.TabIndex = (9);
            this.label45.Text = ("Position");
            // 
            // label44
            // 
            this.label44.AutoSize = (true);
            this.label44.Location = (new global::System.Drawing.Point(82, 218));
            this.label44.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label44.Name = ("label44");
            this.label44.Size = (new global::System.Drawing.Size(20, 25));
            this.label44.TabIndex = (8);
            this.label44.Text = ("x");
            // 
            // edImageOverlayY
            // 
            this.edImageOverlayY.Location = (new global::System.Drawing.Point(105, 212));
            this.edImageOverlayY.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edImageOverlayY.Name = ("edImageOverlayY");
            this.edImageOverlayY.Size = (new global::System.Drawing.Size(46, 31));
            this.edImageOverlayY.TabIndex = (7);
            this.edImageOverlayY.Text = ("50");
            // 
            // edImageOverlayX
            // 
            this.edImageOverlayX.Location = (new global::System.Drawing.Point(26, 212));
            this.edImageOverlayX.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edImageOverlayX.Name = ("edImageOverlayX");
            this.edImageOverlayX.Size = (new global::System.Drawing.Size(46, 31));
            this.edImageOverlayX.TabIndex = (6);
            this.edImageOverlayX.Text = ("50");
            // 
            // btImageOverlayOpen
            // 
            this.btImageOverlayOpen.Location = (new global::System.Drawing.Point(406, 115));
            this.btImageOverlayOpen.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btImageOverlayOpen.Name = ("btImageOverlayOpen");
            this.btImageOverlayOpen.Size = (new global::System.Drawing.Size(38, 44));
            this.btImageOverlayOpen.TabIndex = (5);
            this.btImageOverlayOpen.Text = ("...");
            this.btImageOverlayOpen.UseVisualStyleBackColor = (true);
            this.btImageOverlayOpen.Click += (this.btImageOverlayOpen_Click);
            // 
            // edImageOverlayFilename
            // 
            this.edImageOverlayFilename.Location = (new global::System.Drawing.Point(26, 119));
            this.edImageOverlayFilename.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.edImageOverlayFilename.Name = ("edImageOverlayFilename");
            this.edImageOverlayFilename.Size = (new global::System.Drawing.Size(368, 31));
            this.edImageOverlayFilename.TabIndex = (4);
            this.edImageOverlayFilename.Text = ("c:\\samples\\icon.png");
            // 
            // label43
            // 
            this.label43.AutoSize = (true);
            this.label43.Location = (new global::System.Drawing.Point(22, 88));
            this.label43.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label43.Name = ("label43");
            this.label43.Size = (new global::System.Drawing.Size(87, 25));
            this.label43.TabIndex = (3);
            this.label43.Text = ("File name");
            // 
            // cbImageOverlayEnabled
            // 
            this.cbImageOverlayEnabled.AutoSize = (true);
            this.cbImageOverlayEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbImageOverlayEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbImageOverlayEnabled.Name = ("cbImageOverlayEnabled");
            this.cbImageOverlayEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbImageOverlayEnabled.TabIndex = (2);
            this.cbImageOverlayEnabled.Text = ("Enabled");
            this.cbImageOverlayEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.cbColorEffect);
            this.tabPage12.Controls.Add(this.label20);
            this.tabPage12.Controls.Add(this.cbColorEffectEnabled);
            this.tabPage12.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage12.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage12.Name = ("tabPage12");
            this.tabPage12.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage12.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage12.TabIndex = (2);
            this.tabPage12.Text = ("Color effect");
            this.tabPage12.UseVisualStyleBackColor = (true);
            // 
            // cbColorEffect
            // 
            this.cbColorEffect.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbColorEffect.FormattingEnabled = (true);
            this.cbColorEffect.Items.AddRange(new global::System.Object[] { "None", "Heat", "Sepia", "X-ray", "X-pro", "Yellow-blue" });
            this.cbColorEffect.Location = (new global::System.Drawing.Point(26, 119));
            this.cbColorEffect.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbColorEffect.Name = ("cbColorEffect");
            this.cbColorEffect.Size = (new global::System.Drawing.Size(395, 33));
            this.cbColorEffect.TabIndex = (9);
            this.cbColorEffect.SelectedIndexChanged += (this.cbColorEffect_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = (true);
            this.label20.Location = (new global::System.Drawing.Point(22, 88));
            this.label20.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label20.Name = ("label20");
            this.label20.Size = (new global::System.Drawing.Size(56, 25));
            this.label20.TabIndex = (8);
            this.label20.Text = ("Effect");
            // 
            // cbColorEffectEnabled
            // 
            this.cbColorEffectEnabled.AutoSize = (true);
            this.cbColorEffectEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbColorEffectEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbColorEffectEnabled.Name = ("cbColorEffectEnabled");
            this.cbColorEffectEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbColorEffectEnabled.TabIndex = (7);
            this.cbColorEffectEnabled.Text = ("Enabled");
            this.cbColorEffectEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.cbFlipRotate);
            this.tabPage13.Controls.Add(this.label21);
            this.tabPage13.Controls.Add(this.cbFlipRotateEnabled);
            this.tabPage13.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage13.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage13.Name = ("tabPage13");
            this.tabPage13.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage13.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage13.TabIndex = (3);
            this.tabPage13.Text = ("Flip / rotate");
            this.tabPage13.UseVisualStyleBackColor = (true);
            // 
            // cbFlipRotate
            // 
            this.cbFlipRotate.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbFlipRotate.FormattingEnabled = (true);
            this.cbFlipRotate.Items.AddRange(new global::System.Object[] { "0", "90", "180,", "-90", "Horizontal flip", "Vertical flip" });
            this.cbFlipRotate.Location = (new global::System.Drawing.Point(26, 119));
            this.cbFlipRotate.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbFlipRotate.Name = ("cbFlipRotate");
            this.cbFlipRotate.Size = (new global::System.Drawing.Size(395, 33));
            this.cbFlipRotate.TabIndex = (12);
            this.cbFlipRotate.SelectedIndexChanged += (this.cbFlipRotate_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = (true);
            this.label21.Location = (new global::System.Drawing.Point(22, 88));
            this.label21.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label21.Name = ("label21");
            this.label21.Size = (new global::System.Drawing.Size(75, 25));
            this.label21.TabIndex = (11);
            this.label21.Text = ("Method");
            // 
            // cbFlipRotateEnabled
            // 
            this.cbFlipRotateEnabled.AutoSize = (true);
            this.cbFlipRotateEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbFlipRotateEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbFlipRotateEnabled.Name = ("cbFlipRotateEnabled");
            this.cbFlipRotateEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbFlipRotateEnabled.TabIndex = (10);
            this.cbFlipRotateEnabled.Text = ("Enabled");
            this.cbFlipRotateEnabled.UseVisualStyleBackColor = (true);
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
            this.tabPage14.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage14.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage14.Name = ("tabPage14");
            this.tabPage14.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage14.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage14.TabIndex = (4);
            this.tabPage14.Text = ("Deinterlace");
            this.tabPage14.UseVisualStyleBackColor = (true);
            // 
            // cbDeinterlaceDropOrphans
            // 
            this.cbDeinterlaceDropOrphans.AutoSize = (true);
            this.cbDeinterlaceDropOrphans.Checked = (true);
            this.cbDeinterlaceDropOrphans.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbDeinterlaceDropOrphans.Location = (new global::System.Drawing.Point(26, 612));
            this.cbDeinterlaceDropOrphans.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceDropOrphans.Name = ("cbDeinterlaceDropOrphans");
            this.cbDeinterlaceDropOrphans.Size = (new global::System.Drawing.Size(149, 29));
            this.cbDeinterlaceDropOrphans.TabIndex = (25);
            this.cbDeinterlaceDropOrphans.Text = ("Drop orphans");
            this.cbDeinterlaceDropOrphans.UseVisualStyleBackColor = (true);
            // 
            // cbDeinterlaceIgnoreObscure
            // 
            this.cbDeinterlaceIgnoreObscure.AutoSize = (true);
            this.cbDeinterlaceIgnoreObscure.Checked = (true);
            this.cbDeinterlaceIgnoreObscure.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.cbDeinterlaceIgnoreObscure.Location = (new global::System.Drawing.Point(26, 568));
            this.cbDeinterlaceIgnoreObscure.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceIgnoreObscure.Name = ("cbDeinterlaceIgnoreObscure");
            this.cbDeinterlaceIgnoreObscure.Size = (new global::System.Drawing.Size(158, 29));
            this.cbDeinterlaceIgnoreObscure.TabIndex = (24);
            this.cbDeinterlaceIgnoreObscure.Text = ("Ignore obscure");
            this.cbDeinterlaceIgnoreObscure.UseVisualStyleBackColor = (true);
            // 
            // cbDeinterlaceLocking
            // 
            this.cbDeinterlaceLocking.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDeinterlaceLocking.FormattingEnabled = (true);
            this.cbDeinterlaceLocking.Items.AddRange(new global::System.Object[] { "None", "Auto", "Active", "Passive" });
            this.cbDeinterlaceLocking.Location = (new global::System.Drawing.Point(26, 490));
            this.cbDeinterlaceLocking.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceLocking.Name = ("cbDeinterlaceLocking");
            this.cbDeinterlaceLocking.Size = (new global::System.Drawing.Size(395, 33));
            this.cbDeinterlaceLocking.TabIndex = (23);
            // 
            // label26
            // 
            this.label26.AutoSize = (true);
            this.label26.Location = (new global::System.Drawing.Point(22, 460));
            this.label26.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label26.Name = ("label26");
            this.label26.Size = (new global::System.Drawing.Size(73, 25));
            this.label26.TabIndex = (22);
            this.label26.Text = ("Locking");
            // 
            // cbDeinterlaceMode
            // 
            this.cbDeinterlaceMode.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDeinterlaceMode.FormattingEnabled = (true);
            this.cbDeinterlaceMode.Items.AddRange(new global::System.Object[] { "Auto", "Interlaced", "Disabled", "Auto (strict)" });
            this.cbDeinterlaceMode.Location = (new global::System.Drawing.Point(26, 396));
            this.cbDeinterlaceMode.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceMode.Name = ("cbDeinterlaceMode");
            this.cbDeinterlaceMode.Size = (new global::System.Drawing.Size(395, 33));
            this.cbDeinterlaceMode.TabIndex = (21);
            // 
            // label25
            // 
            this.label25.AutoSize = (true);
            this.label25.Location = (new global::System.Drawing.Point(22, 365));
            this.label25.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label25.Name = ("label25");
            this.label25.Size = (new global::System.Drawing.Size(59, 25));
            this.label25.TabIndex = (20);
            this.label25.Text = ("Mode");
            // 
            // cbDeinterlaceFieldLayout
            // 
            this.cbDeinterlaceFieldLayout.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDeinterlaceFieldLayout.FormattingEnabled = (true);
            this.cbDeinterlaceFieldLayout.Items.AddRange(new global::System.Object[] { "Automatically detect", "Top fields first", "Bottom fields first" });
            this.cbDeinterlaceFieldLayout.Location = (new global::System.Drawing.Point(26, 304));
            this.cbDeinterlaceFieldLayout.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceFieldLayout.Name = ("cbDeinterlaceFieldLayout");
            this.cbDeinterlaceFieldLayout.Size = (new global::System.Drawing.Size(395, 33));
            this.cbDeinterlaceFieldLayout.TabIndex = (19);
            // 
            // label24
            // 
            this.label24.AutoSize = (true);
            this.label24.Location = (new global::System.Drawing.Point(22, 273));
            this.label24.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label24.Name = ("label24");
            this.label24.Size = (new global::System.Drawing.Size(103, 25));
            this.label24.TabIndex = (18);
            this.label24.Text = ("Field layout");
            // 
            // cbDeinterlaceFields
            // 
            this.cbDeinterlaceFields.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDeinterlaceFields.FormattingEnabled = (true);
            this.cbDeinterlaceFields.Items.AddRange(new global::System.Object[] { "All", "Top fields only", "Bottom fields only", "Automatically detect" });
            this.cbDeinterlaceFields.Location = (new global::System.Drawing.Point(26, 210));
            this.cbDeinterlaceFields.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceFields.Name = ("cbDeinterlaceFields");
            this.cbDeinterlaceFields.Size = (new global::System.Drawing.Size(395, 33));
            this.cbDeinterlaceFields.TabIndex = (17);
            // 
            // label23
            // 
            this.label23.AutoSize = (true);
            this.label23.Location = (new global::System.Drawing.Point(22, 179));
            this.label23.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label23.Name = ("label23");
            this.label23.Size = (new global::System.Drawing.Size(57, 25));
            this.label23.TabIndex = (16);
            this.label23.Text = ("Fields");
            // 
            // cbDeinterlaceMethod
            // 
            this.cbDeinterlaceMethod.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.cbDeinterlaceMethod.FormattingEnabled = (true);
            this.cbDeinterlaceMethod.Items.AddRange(new global::System.Object[] { "Motion adaptive: motion search", "Motion adaptive: advanced detection", "Motion adaptive: simple detection", "Blur vertical", "Linear interpolation", "Linear interpolation in time domain (Low quality)", "Double lines" });
            this.cbDeinterlaceMethod.Location = (new global::System.Drawing.Point(26, 119));
            this.cbDeinterlaceMethod.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceMethod.Name = ("cbDeinterlaceMethod");
            this.cbDeinterlaceMethod.Size = (new global::System.Drawing.Size(395, 33));
            this.cbDeinterlaceMethod.TabIndex = (15);
            // 
            // label22
            // 
            this.label22.AutoSize = (true);
            this.label22.Location = (new global::System.Drawing.Point(22, 88));
            this.label22.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label22.Name = ("label22");
            this.label22.Size = (new global::System.Drawing.Size(75, 25));
            this.label22.TabIndex = (14);
            this.label22.Text = ("Method");
            // 
            // cbDeinterlaceEnabled
            // 
            this.cbDeinterlaceEnabled.AutoSize = (true);
            this.cbDeinterlaceEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbDeinterlaceEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDeinterlaceEnabled.Name = ("cbDeinterlaceEnabled");
            this.cbDeinterlaceEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbDeinterlaceEnabled.TabIndex = (13);
            this.cbDeinterlaceEnabled.Text = ("Enabled");
            this.cbDeinterlaceEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.tbGaussianBlur);
            this.tabPage15.Controls.Add(this.cbGaussianBlurEnabled);
            this.tabPage15.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage15.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage15.Name = ("tabPage15");
            this.tabPage15.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage15.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage15.TabIndex = (5);
            this.tabPage15.Text = ("Blur / sharpen");
            this.tabPage15.UseVisualStyleBackColor = (true);
            // 
            // tbGaussianBlur
            // 
            this.tbGaussianBlur.Location = (new global::System.Drawing.Point(26, 75));
            this.tbGaussianBlur.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tbGaussianBlur.Maximum = (200);
            this.tbGaussianBlur.Minimum = (-200);
            this.tbGaussianBlur.Name = ("tbGaussianBlur");
            this.tbGaussianBlur.Size = (new global::System.Drawing.Size(418, 69));
            this.tbGaussianBlur.TabIndex = (1);
            this.tbGaussianBlur.Value = (12);
            this.tbGaussianBlur.Scroll += (this.tbGaussianBlur_Scroll);
            // 
            // cbGaussianBlurEnabled
            // 
            this.cbGaussianBlurEnabled.AutoSize = (true);
            this.cbGaussianBlurEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbGaussianBlurEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbGaussianBlurEnabled.Name = ("cbGaussianBlurEnabled");
            this.cbGaussianBlurEnabled.Size = (new global::System.Drawing.Size(144, 29));
            this.cbGaussianBlurEnabled.TabIndex = (0);
            this.cbGaussianBlurEnabled.Text = ("Gaussian blur");
            this.cbGaussianBlurEnabled.UseVisualStyleBackColor = (true);
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.cbFishEyeEnabled);
            this.tabPage16.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage16.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage16.Name = ("tabPage16");
            this.tabPage16.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage16.Size = (new global::System.Drawing.Size(472, 825));
            this.tabPage16.TabIndex = (6);
            this.tabPage16.Text = ("Other");
            this.tabPage16.UseVisualStyleBackColor = (true);
            // 
            // cbFishEyeEnabled
            // 
            this.cbFishEyeEnabled.AutoSize = (true);
            this.cbFishEyeEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbFishEyeEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbFishEyeEnabled.Name = ("cbFishEyeEnabled");
            this.cbFishEyeEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbFishEyeEnabled.TabIndex = (0);
            this.cbFishEyeEnabled.Text = ("Fish eye");
            this.cbFishEyeEnabled.UseVisualStyleBackColor = (true);
            // 
            // label3
            // 
            this.label3.AutoSize = (true);
            this.label3.Location = (new global::System.Drawing.Point(10, 25));
            this.label3.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label3.Name = ("label3");
            this.label3.Size = (new global::System.Drawing.Size(480, 25));
            this.label3.TabIndex = (8);
            this.label3.Text = ("Enable effects before Start. More effects available using API");
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
            this.tabPage6.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage6.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage6.Name = ("tabPage6");
            this.tabPage6.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage6.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage6.TabIndex = (5);
            this.tabPage6.Text = ("Motion detection");
            this.tabPage6.UseVisualStyleBackColor = (true);
            // 
            // label505
            // 
            this.label505.AutoSize = (true);
            this.label505.Location = (new global::System.Drawing.Point(22, 200));
            this.label505.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label505.Name = ("label505");
            this.label505.Size = (new global::System.Drawing.Size(89, 25));
            this.label505.TabIndex = (37);
            this.label505.Text = ("Processor");
            // 
            // rbMotionDetectionProcessor
            // 
            this.rbMotionDetectionProcessor.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.rbMotionDetectionProcessor.FormattingEnabled = (true);
            this.rbMotionDetectionProcessor.Items.AddRange(new global::System.Object[] { "None", "Blob counting objects", "GridMotionAreaProcessing", "Motion area highlighting", "Motion border highlighting" });
            this.rbMotionDetectionProcessor.Location = (new global::System.Drawing.Point(22, 231));
            this.rbMotionDetectionProcessor.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.rbMotionDetectionProcessor.Name = ("rbMotionDetectionProcessor");
            this.rbMotionDetectionProcessor.Size = (new global::System.Drawing.Size(428, 33));
            this.rbMotionDetectionProcessor.TabIndex = (36);
            // 
            // label389
            // 
            this.label389.AutoSize = (true);
            this.label389.Location = (new global::System.Drawing.Point(22, 104));
            this.label389.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label389.Name = ("label389");
            this.label389.Size = (new global::System.Drawing.Size(80, 25));
            this.label389.TabIndex = (35);
            this.label389.Text = ("Detector");
            // 
            // rbMotionDetectionDetector
            // 
            this.rbMotionDetectionDetector.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            this.rbMotionDetectionDetector.FormattingEnabled = (true);
            this.rbMotionDetectionDetector.Items.AddRange(new global::System.Object[] { "Custom frame difference", "Simple background modeling", "Two frames difference" });
            this.rbMotionDetectionDetector.Location = (new global::System.Drawing.Point(22, 135));
            this.rbMotionDetectionDetector.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.rbMotionDetectionDetector.Name = ("rbMotionDetectionDetector");
            this.rbMotionDetectionDetector.Size = (new global::System.Drawing.Size(428, 33));
            this.rbMotionDetectionDetector.TabIndex = (34);
            // 
            // label65
            // 
            this.label65.AutoSize = (true);
            this.label65.Location = (new global::System.Drawing.Point(22, 312));
            this.label65.Margin = (new global::System.Windows.Forms.Padding(5, 0, 5, 0));
            this.label65.Name = ("label65");
            this.label65.Size = (new global::System.Drawing.Size(110, 25));
            this.label65.TabIndex = (33);
            this.label65.Text = ("Motion level");
            // 
            // pbAFMotionLevel
            // 
            this.pbAFMotionLevel.Location = (new global::System.Drawing.Point(22, 343));
            this.pbAFMotionLevel.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.pbAFMotionLevel.Name = ("pbAFMotionLevel");
            this.pbAFMotionLevel.Size = (new global::System.Drawing.Size(430, 44));
            this.pbAFMotionLevel.TabIndex = (32);
            // 
            // cbMotionDetection
            // 
            this.cbMotionDetection.AutoSize = (true);
            this.cbMotionDetection.Location = (new global::System.Drawing.Point(26, 31));
            this.cbMotionDetection.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbMotionDetection.Name = ("cbMotionDetection");
            this.cbMotionDetection.Size = (new global::System.Drawing.Size(101, 29));
            this.cbMotionDetection.TabIndex = (0);
            this.cbMotionDetection.Text = ("Enabled");
            this.cbMotionDetection.UseVisualStyleBackColor = (true);
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
            this.tabPage9.Location = (new global::System.Drawing.Point(4, 34));
            this.tabPage9.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage9.Name = ("tabPage9");
            this.tabPage9.Padding = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.tabPage9.Size = (new global::System.Drawing.Size(514, 962));
            this.tabPage9.TabIndex = (6);
            this.tabPage9.Text = ("Barcode reader");
            this.tabPage9.UseVisualStyleBackColor = (true);
            // 
            // edBarcodeMetadata
            // 
            this.edBarcodeMetadata.Location = (new global::System.Drawing.Point(26, 307));
            this.edBarcodeMetadata.Margin = (new global::System.Windows.Forms.Padding(4));
            this.edBarcodeMetadata.Multiline = (true);
            this.edBarcodeMetadata.Name = ("edBarcodeMetadata");
            this.edBarcodeMetadata.Size = (new global::System.Drawing.Size(450, 181));
            this.edBarcodeMetadata.TabIndex = (24);
            // 
            // label91
            // 
            this.label91.AutoSize = (true);
            this.label91.Location = (new global::System.Drawing.Point(24, 271));
            this.label91.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
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
            this.cbBarcodeType.Location = (new global::System.Drawing.Point(26, 123));
            this.cbBarcodeType.Margin = (new global::System.Windows.Forms.Padding(4));
            this.cbBarcodeType.Name = ("cbBarcodeType");
            this.cbBarcodeType.Size = (new global::System.Drawing.Size(264, 33));
            this.cbBarcodeType.TabIndex = (22);
            // 
            // label90
            // 
            this.label90.AutoSize = (true);
            this.label90.Location = (new global::System.Drawing.Point(24, 93));
            this.label90.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label90.Name = ("label90");
            this.label90.Size = (new global::System.Drawing.Size(116, 25));
            this.label90.TabIndex = (21);
            this.label90.Text = ("Barcode type");
            // 
            // btBarcodeReset
            // 
            this.btBarcodeReset.Location = (new global::System.Drawing.Point(26, 515));
            this.btBarcodeReset.Margin = (new global::System.Windows.Forms.Padding(4));
            this.btBarcodeReset.Name = ("btBarcodeReset");
            this.btBarcodeReset.Size = (new global::System.Drawing.Size(104, 44));
            this.btBarcodeReset.TabIndex = (20);
            this.btBarcodeReset.Text = ("Restart");
            this.btBarcodeReset.UseVisualStyleBackColor = (true);
            // 
            // edBarcode
            // 
            this.edBarcode.Location = (new global::System.Drawing.Point(26, 215));
            this.edBarcode.Margin = (new global::System.Windows.Forms.Padding(4));
            this.edBarcode.Name = ("edBarcode");
            this.edBarcode.Size = (new global::System.Drawing.Size(450, 31));
            this.edBarcode.TabIndex = (19);
            // 
            // label89
            // 
            this.label89.AutoSize = (true);
            this.label89.Location = (new global::System.Drawing.Point(24, 185));
            this.label89.Margin = (new global::System.Windows.Forms.Padding(4, 0, 4, 0));
            this.label89.Name = ("label89");
            this.label89.Size = (new global::System.Drawing.Size(153, 25));
            this.label89.TabIndex = (18);
            this.label89.Text = ("Detected barcode");
            // 
            // cbBarcodeDetectionEnabled
            // 
            this.cbBarcodeDetectionEnabled.AutoSize = (true);
            this.cbBarcodeDetectionEnabled.Location = (new global::System.Drawing.Point(26, 31));
            this.cbBarcodeDetectionEnabled.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbBarcodeDetectionEnabled.Name = ("cbBarcodeDetectionEnabled");
            this.cbBarcodeDetectionEnabled.Size = (new global::System.Drawing.Size(101, 29));
            this.cbBarcodeDetectionEnabled.TabIndex = (17);
            this.cbBarcodeDetectionEnabled.Text = ("Enabled");
            this.cbBarcodeDetectionEnabled.UseVisualStyleBackColor = (true);
            // 
            // btSaveSnapshot
            // 
            this.btSaveSnapshot.Location = (new global::System.Drawing.Point(1046, 785));
            this.btSaveSnapshot.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.btSaveSnapshot.Name = ("btSaveSnapshot");
            this.btSaveSnapshot.Size = (new global::System.Drawing.Size(194, 44));
            this.btSaveSnapshot.TabIndex = (38);
            this.btSaveSnapshot.Text = ("Save snapshot");
            this.btSaveSnapshot.UseVisualStyleBackColor = (true);
            this.btSaveSnapshot.Click += (this.btSaveSnapshot_Click);
            // 
            // dlgOpenImage
            // 
            this.dlgOpenImage.Filter = ("Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*");
            // 
            // videoView1
            // 
            this.videoView1.BackColor = (global::System.Drawing.Color.Black);
            this.videoView1.Location = (new global::System.Drawing.Point(556, 98));
            this.videoView1.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.videoView1.Name = ("videoView1");
            this.videoView1.Size = (new global::System.Drawing.Size(690, 472));
            this.videoView1.StatusOverlay = (null);
            this.videoView1.TabIndex = (39);
            // 
            // mmLog
            // 
            this.mmLog.Location = (new global::System.Drawing.Point(556, 841));
            this.mmLog.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.mmLog.Multiline = (true);
            this.mmLog.Name = ("mmLog");
            this.mmLog.ScrollBars = (global::System.Windows.Forms.ScrollBars.Both);
            this.mmLog.Size = (new global::System.Drawing.Size(691, 178));
            this.mmLog.TabIndex = (41);
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = (true);
            this.cbDebugMode.Location = (new global::System.Drawing.Point(625, 810));
            this.cbDebugMode.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.cbDebugMode.Name = ("cbDebugMode");
            this.cbDebugMode.Size = (new global::System.Drawing.Size(144, 29));
            this.cbDebugMode.TabIndex = (40);
            this.cbDebugMode.Text = ("Debug mode");
            this.cbDebugMode.UseVisualStyleBackColor = (true);
            // 
            // label9
            // 
            this.label9.AutoSize = (true);
            this.label9.Location = (new global::System.Drawing.Point(556, 810));
            this.label9.Name = ("label9");
            this.label9.Size = (new global::System.Drawing.Size(42, 25));
            this.label9.TabIndex = (42);
            this.label9.Text = ("Log");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = (new global::System.Drawing.SizeF(10F, 25F));
            this.AutoScaleMode = (global::System.Windows.Forms.AutoScaleMode.Font);
            this.ClientSize = (new global::System.Drawing.Size(1271, 1041));
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.btSaveSnapshot);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Icon = ((global::System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = (new global::System.Windows.Forms.Padding(5, 6, 5, 6));
            this.Name = ("Form1");
            this.Text = ("Media Player SDK .Net (Cross-platform) - Main Demo");
            this.Load += (this.Form1_Load);
            this.Shown += (this.Form1_Shown);
            this.SizeChanged += (this.Form1_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabPage24.ResumeLayout(false);
            this.tabPage24.PerformLayout();
            this.tabPage22.ResumeLayout(false);
            this.tabPage22.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPLatency)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPUDPBufferSize)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbRTSPRTPBlockSize)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudBalanceLevel)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoFeedback)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoIntensity)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbAudEchoDelay)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoContrast)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoHue)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoBrightness)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbVideoSaturation)).EndInit();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTextOverlayY)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbTextOverlayX)).EndInit();
            this.tabPage19.ResumeLayout(false);
            this.tabPage19.PerformLayout();
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbImageOverlayAlpha)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.tbGaussianBlur)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
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
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label9;
    }
}

