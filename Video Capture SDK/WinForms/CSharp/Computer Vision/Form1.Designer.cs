using System;

namespace Computer_Vision_Demo
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
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.edFilename = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbVideoFile = new System.Windows.Forms.RadioButton();
            this.edIPLogin = new System.Windows.Forms.TextBox();
            this.cbIPCameraONVIF = new System.Windows.Forms.CheckBox();
            this.btShowIPCamDatabase = new System.Windows.Forms.Button();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.cbIPCameraType = new System.Windows.Forms.ComboBox();
            this.edIPPassword = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.edIPUrl = new System.Windows.Forms.TextBox();
            this.label165 = new System.Windows.Forms.Label();
            this.rbIPCamera = new System.Windows.Forms.RadioButton();
            this.rbVideoCaptureDevice = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbFDMosaic = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.edFDMinFaceHeight = new System.Windows.Forms.TextBox();
            this.edFDMinFaceWidth = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbFDEyes = new System.Windows.Forms.CheckBox();
            this.cbFDNose = new System.Windows.Forms.CheckBox();
            this.btFDUpdate = new System.Windows.Forms.Button();
            this.cbFDMouth = new System.Windows.Forms.CheckBox();
            this.cbFDFace = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edFDFaces = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFDScaleFactor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFDScaleFactor = new System.Windows.Forms.TrackBar();
            this.lbFDMinNeighbors = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFDMinNeighbors = new System.Windows.Forms.TrackBar();
            this.lbFDDownscale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFDDownscale = new System.Windows.Forms.TrackBar();
            this.lbFDSkipFrames = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFDSkipFrames = new System.Windows.Forms.TrackBar();
            this.rbFDRectangle = new System.Windows.Forms.RadioButton();
            this.rbFDCircle = new System.Windows.Forms.RadioButton();
            this.cbFDDraw = new System.Windows.Forms.CheckBox();
            this.cbFDEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.edCCDetectedCars = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbCCDraw = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCCEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lbPDSkipFrames = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbPDSkipFrames = new System.Windows.Forms.TrackBar();
            this.lbPDDownscale = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.edPDDetected = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbPDDownscale = new System.Windows.Forms.TrackBar();
            this.cbPDDraw = new System.Windows.Forms.CheckBox();
            this.cbPDEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cbObjectDetector = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.VideoCaptureView = new VisioForge.Core.UI.WinForms.VideoView();
            this.MediaPlayerView = new VisioForge.Core.UI.WinForms.VideoView();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDScaleFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDMinNeighbors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDDownscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDSkipFrames)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDSkipFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDDownscale)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(1329, 565);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(93, 35);
            this.btStop.TabIndex = 79;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(1232, 565);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(93, 35);
            this.btStart.TabIndex = 78;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Controls.Add(this.tabPage5);
            this.tcMain.Controls.Add(this.tabPage6);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Location = new System.Drawing.Point(18, 18);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(690, 1012);
            this.tcMain.TabIndex = 83;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btOpenFile);
            this.tabPage1.Controls.Add(this.edFilename);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.rbVideoFile);
            this.tabPage1.Controls.Add(this.edIPLogin);
            this.tabPage1.Controls.Add(this.cbIPCameraONVIF);
            this.tabPage1.Controls.Add(this.btShowIPCamDatabase);
            this.tabPage1.Controls.Add(this.linkLabel7);
            this.tabPage1.Controls.Add(this.cbIPCameraType);
            this.tabPage1.Controls.Add(this.edIPPassword);
            this.tabPage1.Controls.Add(this.label167);
            this.tabPage1.Controls.Add(this.label166);
            this.tabPage1.Controls.Add(this.label168);
            this.tabPage1.Controls.Add(this.edIPUrl);
            this.tabPage1.Controls.Add(this.label165);
            this.tabPage1.Controls.Add(this.rbIPCamera);
            this.tabPage1.Controls.Add(this.rbVideoCaptureDevice);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage1.Controls.Add(this.cbVideoInputFormat);
            this.tabPage1.Controls.Add(this.cbVideoInputDevice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(682, 979);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(618, 642);
            this.btOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(36, 35);
            this.btOpenFile.TabIndex = 144;
            this.btOpenFile.Text = "...";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // edFilename
            // 
            this.edFilename.Location = new System.Drawing.Point(64, 645);
            this.edFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(542, 26);
            this.edFilename.TabIndex = 143;
            this.edFilename.Text = "c:\\samples\\cv\\highway.mp4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(130, 612);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(391, 20);
            this.label9.TabIndex = 142;
            this.label9.Text = " (using Media Player SDK instead Video Capture SDK)";
            // 
            // rbVideoFile
            // 
            this.rbVideoFile.AutoSize = true;
            this.rbVideoFile.Location = new System.Drawing.Point(27, 609);
            this.rbVideoFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoFile.Name = "rbVideoFile";
            this.rbVideoFile.Size = new System.Drawing.Size(99, 24);
            this.rbVideoFile.TabIndex = 141;
            this.rbVideoFile.Text = "Video file";
            this.rbVideoFile.UseVisualStyleBackColor = true;
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(132, 471);
            this.edIPLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(148, 26);
            this.edIPLogin.TabIndex = 140;
            // 
            // cbIPCameraONVIF
            // 
            this.cbIPCameraONVIF.AutoSize = true;
            this.cbIPCameraONVIF.Location = new System.Drawing.Point(458, 400);
            this.cbIPCameraONVIF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            this.cbIPCameraONVIF.Size = new System.Drawing.Size(141, 24);
            this.cbIPCameraONVIF.TabIndex = 139;
            this.cbIPCameraONVIF.Text = "ONVIF camera";
            this.cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // btShowIPCamDatabase
            // 
            this.btShowIPCamDatabase.Location = new System.Drawing.Point(458, 468);
            this.btShowIPCamDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btShowIPCamDatabase.Name = "btShowIPCamDatabase";
            this.btShowIPCamDatabase.Size = new System.Drawing.Size(196, 35);
            this.btShowIPCamDatabase.TabIndex = 138;
            this.btShowIPCamDatabase.Text = "Show IP cam database";
            this.btShowIPCamDatabase.UseVisualStyleBackColor = true;
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(128, 543);
            this.linkLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(398, 20);
            this.linkLabel7.TabIndex = 137;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Please install VisioForge VLC redist to use VLC engine ";
            // 
            // cbIPCameraType
            // 
            this.cbIPCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPCameraType.FormattingEnabled = true;
            this.cbIPCameraType.Items.AddRange(new object[] {
            "Auto (VLC engine)",
            "Auto (FFMPEG engine)",
            "Auto (LAV engine)",
            "MMS - WMV"});
            this.cbIPCameraType.Location = new System.Drawing.Point(132, 397);
            this.cbIPCameraType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIPCameraType.Name = "cbIPCameraType";
            this.cbIPCameraType.Size = new System.Drawing.Size(314, 28);
            this.cbIPCameraType.TabIndex = 136;
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(298, 471);
            this.edIPPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(148, 26);
            this.edIPPassword.TabIndex = 135;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(294, 445);
            this.label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(78, 20);
            this.label167.TabIndex = 134;
            this.label167.Text = "Password";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(128, 445);
            this.label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(48, 20);
            this.label166.TabIndex = 133;
            this.label166.Text = "Login";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(60, 402);
            this.label168.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(59, 20);
            this.label168.TabIndex = 132;
            this.label168.Text = "Engine";
            // 
            // edIPUrl
            // 
            this.edIPUrl.Location = new System.Drawing.Point(132, 346);
            this.edIPUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edIPUrl.Name = "edIPUrl";
            this.edIPUrl.Size = new System.Drawing.Size(520, 26);
            this.edIPUrl.TabIndex = 131;
            this.edIPUrl.Text = "http://212.162.177.75/mjpg/video.mjpg";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(60, 351);
            this.label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(42, 20);
            this.label165.TabIndex = 130;
            this.label165.Text = "URL";
            // 
            // rbIPCamera
            // 
            this.rbIPCamera.AutoSize = true;
            this.rbIPCamera.Location = new System.Drawing.Point(27, 288);
            this.rbIPCamera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbIPCamera.Name = "rbIPCamera";
            this.rbIPCamera.Size = new System.Drawing.Size(106, 24);
            this.rbIPCamera.TabIndex = 129;
            this.rbIPCamera.Text = "IP camera";
            this.rbIPCamera.UseVisualStyleBackColor = true;
            // 
            // rbVideoCaptureDevice
            // 
            this.rbVideoCaptureDevice.AutoSize = true;
            this.rbVideoCaptureDevice.Checked = true;
            this.rbVideoCaptureDevice.Location = new System.Drawing.Point(27, 26);
            this.rbVideoCaptureDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoCaptureDevice.Name = "rbVideoCaptureDevice";
            this.rbVideoCaptureDevice.Size = new System.Drawing.Size(182, 24);
            this.rbVideoCaptureDevice.TabIndex = 128;
            this.rbVideoCaptureDevice.TabStop = true;
            this.rbVideoCaptureDevice.Text = "Video capture device";
            this.rbVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(492, 228);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 20);
            this.label28.TabIndex = 127;
            this.label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(270, 186);
            this.cbUseBestVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(99, 24);
            this.cbUseBestVideoInputFormat.TabIndex = 126;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(381, 188);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 20);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(386, 220);
            this.cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(96, 28);
            this.cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(64, 220);
            this.cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(310, 28);
            this.cbVideoInputFormat.TabIndex = 123;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(64, 125);
            this.cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(310, 28);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 188);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 121;
            this.label13.Text = "Input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 91);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 120;
            this.label11.Text = "Input device";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbFDMosaic);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.edFDMinFaceHeight);
            this.tabPage2.Controls.Add(this.edFDMinFaceWidth);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.cbFDEyes);
            this.tabPage2.Controls.Add(this.cbFDNose);
            this.tabPage2.Controls.Add(this.btFDUpdate);
            this.tabPage2.Controls.Add(this.cbFDMouth);
            this.tabPage2.Controls.Add(this.cbFDFace);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.edFDFaces);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lbFDScaleFactor);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbFDScaleFactor);
            this.tabPage2.Controls.Add(this.lbFDMinNeighbors);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbFDMinNeighbors);
            this.tabPage2.Controls.Add(this.lbFDDownscale);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbFDDownscale);
            this.tabPage2.Controls.Add(this.lbFDSkipFrames);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbFDSkipFrames);
            this.tabPage2.Controls.Add(this.rbFDRectangle);
            this.tabPage2.Controls.Add(this.rbFDCircle);
            this.tabPage2.Controls.Add(this.cbFDDraw);
            this.tabPage2.Controls.Add(this.cbFDEnabled);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(682, 979);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Face detector";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbFDMosaic
            // 
            this.cbFDMosaic.AutoSize = true;
            this.cbFDMosaic.Location = new System.Drawing.Point(339, 475);
            this.cbFDMosaic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDMosaic.Name = "cbFDMosaic";
            this.cbFDMosaic.Size = new System.Drawing.Size(191, 24);
            this.cbFDMosaic.TabIndex = 156;
            this.cbFDMosaic.Text = "Draw mosaic on faces";
            this.cbFDMosaic.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(398, 360);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 20);
            this.label21.TabIndex = 155;
            this.label21.Text = "x";
            // 
            // edFDMinFaceHeight
            // 
            this.edFDMinFaceHeight.Location = new System.Drawing.Point(417, 355);
            this.edFDMinFaceHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFDMinFaceHeight.Name = "edFDMinFaceHeight";
            this.edFDMinFaceHeight.Size = new System.Drawing.Size(52, 26);
            this.edFDMinFaceHeight.TabIndex = 154;
            this.edFDMinFaceHeight.Text = "100";
            // 
            // edFDMinFaceWidth
            // 
            this.edFDMinFaceWidth.Location = new System.Drawing.Point(339, 355);
            this.edFDMinFaceWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFDMinFaceWidth.Name = "edFDMinFaceWidth";
            this.edFDMinFaceWidth.Size = new System.Drawing.Size(52, 26);
            this.edFDMinFaceWidth.TabIndex = 153;
            this.edFDMinFaceWidth.Text = "100";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(334, 331);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 20);
            this.label20.TabIndex = 152;
            this.label20.Text = "Minimal face size";
            // 
            // cbFDEyes
            // 
            this.cbFDEyes.AutoSize = true;
            this.cbFDEyes.Location = new System.Drawing.Point(417, 88);
            this.cbFDEyes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDEyes.Name = "cbFDEyes";
            this.cbFDEyes.Size = new System.Drawing.Size(70, 24);
            this.cbFDEyes.TabIndex = 151;
            this.cbFDEyes.Text = "Eyes";
            this.cbFDEyes.UseVisualStyleBackColor = true;
            // 
            // cbFDNose
            // 
            this.cbFDNose.AutoSize = true;
            this.cbFDNose.Location = new System.Drawing.Point(297, 88);
            this.cbFDNose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDNose.Name = "cbFDNose";
            this.cbFDNose.Size = new System.Drawing.Size(72, 24);
            this.cbFDNose.TabIndex = 150;
            this.cbFDNose.Text = "Nose";
            this.cbFDNose.UseVisualStyleBackColor = true;
            // 
            // btFDUpdate
            // 
            this.btFDUpdate.Location = new System.Drawing.Point(27, 625);
            this.btFDUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFDUpdate.Name = "btFDUpdate";
            this.btFDUpdate.Size = new System.Drawing.Size(112, 35);
            this.btFDUpdate.TabIndex = 149;
            this.btFDUpdate.Text = "Update";
            this.btFDUpdate.UseVisualStyleBackColor = true;
            this.btFDUpdate.Click += new System.EventHandler(this.btFDUpdate_Click);
            // 
            // cbFDMouth
            // 
            this.cbFDMouth.AutoSize = true;
            this.cbFDMouth.Location = new System.Drawing.Point(159, 88);
            this.cbFDMouth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDMouth.Name = "cbFDMouth";
            this.cbFDMouth.Size = new System.Drawing.Size(80, 24);
            this.cbFDMouth.TabIndex = 148;
            this.cbFDMouth.Text = "Mouth";
            this.cbFDMouth.UseVisualStyleBackColor = true;
            // 
            // cbFDFace
            // 
            this.cbFDFace.AutoSize = true;
            this.cbFDFace.Checked = true;
            this.cbFDFace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFDFace.Location = new System.Drawing.Point(27, 88);
            this.cbFDFace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDFace.Name = "cbFDFace";
            this.cbFDFace.Size = new System.Drawing.Size(71, 24);
            this.cbFDFace.TabIndex = 147;
            this.cbFDFace.Text = "Face";
            this.cbFDFace.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(178, 29);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(334, 20);
            this.label17.TabIndex = 146;
            this.label17.Text = "Face, eyes, nose and mouth tracking available";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 931);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "More settings available using API";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 691);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 144;
            this.label2.Text = "Detected faces";
            // 
            // edFDFaces
            // 
            this.edFDFaces.Location = new System.Drawing.Point(27, 715);
            this.edFDFaces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFDFaces.Multiline = true;
            this.edFDFaces.Name = "edFDFaces";
            this.edFDFaces.Size = new System.Drawing.Size(625, 193);
            this.edFDFaces.TabIndex = 143;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 569);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(490, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Specifying how much the image size is reduced at each image scale.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 429);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(581, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Specifying how many neighbors each candidate rectangle should have to retain it.";
            // 
            // lbFDScaleFactor
            // 
            this.lbFDScaleFactor.AutoSize = true;
            this.lbFDScaleFactor.Location = new System.Drawing.Point(192, 509);
            this.lbFDScaleFactor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFDScaleFactor.Name = "lbFDScaleFactor";
            this.lbFDScaleFactor.Size = new System.Drawing.Size(40, 20);
            this.lbFDScaleFactor.TabIndex = 16;
            this.lbFDScaleFactor.Text = "1.10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 471);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Scale factor";
            // 
            // tbFDScaleFactor
            // 
            this.tbFDScaleFactor.Location = new System.Drawing.Point(27, 495);
            this.tbFDScaleFactor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFDScaleFactor.Maximum = 150;
            this.tbFDScaleFactor.Minimum = 101;
            this.tbFDScaleFactor.Name = "tbFDScaleFactor";
            this.tbFDScaleFactor.Size = new System.Drawing.Size(156, 69);
            this.tbFDScaleFactor.TabIndex = 14;
            this.tbFDScaleFactor.Value = 110;
            this.tbFDScaleFactor.Scroll += new System.EventHandler(this.tbScaleFactor_Scroll);
            // 
            // lbFDMinNeighbors
            // 
            this.lbFDMinNeighbors.AutoSize = true;
            this.lbFDMinNeighbors.Location = new System.Drawing.Point(192, 369);
            this.lbFDMinNeighbors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFDMinNeighbors.Name = "lbFDMinNeighbors";
            this.lbFDMinNeighbors.Size = new System.Drawing.Size(18, 20);
            this.lbFDMinNeighbors.TabIndex = 13;
            this.lbFDMinNeighbors.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 331);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Minimal neighbors count";
            // 
            // tbFDMinNeighbors
            // 
            this.tbFDMinNeighbors.Location = new System.Drawing.Point(27, 355);
            this.tbFDMinNeighbors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFDMinNeighbors.Maximum = 12;
            this.tbFDMinNeighbors.Minimum = 3;
            this.tbFDMinNeighbors.Name = "tbFDMinNeighbors";
            this.tbFDMinNeighbors.Size = new System.Drawing.Size(156, 69);
            this.tbFDMinNeighbors.TabIndex = 11;
            this.tbFDMinNeighbors.Value = 8;
            this.tbFDMinNeighbors.Scroll += new System.EventHandler(this.tbMinNeighbors_Scroll);
            // 
            // lbFDDownscale
            // 
            this.lbFDDownscale.AutoSize = true;
            this.lbFDDownscale.Location = new System.Drawing.Point(504, 242);
            this.lbFDDownscale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFDDownscale.Name = "lbFDDownscale";
            this.lbFDDownscale.Size = new System.Drawing.Size(31, 20);
            this.lbFDDownscale.TabIndex = 10;
            this.lbFDDownscale.Text = "1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Downscale video (improves performance)";
            // 
            // tbFDDownscale
            // 
            this.tbFDDownscale.Location = new System.Drawing.Point(339, 228);
            this.tbFDDownscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFDDownscale.Maximum = 30;
            this.tbFDDownscale.Minimum = 10;
            this.tbFDDownscale.Name = "tbFDDownscale";
            this.tbFDDownscale.Size = new System.Drawing.Size(156, 69);
            this.tbFDDownscale.TabIndex = 8;
            this.tbFDDownscale.Value = 10;
            this.tbFDDownscale.Scroll += new System.EventHandler(this.tbFDDownscale_Scroll);
            // 
            // lbFDSkipFrames
            // 
            this.lbFDSkipFrames.AutoSize = true;
            this.lbFDSkipFrames.Location = new System.Drawing.Point(192, 242);
            this.lbFDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFDSkipFrames.Name = "lbFDSkipFrames";
            this.lbFDSkipFrames.Size = new System.Drawing.Size(18, 20);
            this.lbFDSkipFrames.TabIndex = 7;
            this.lbFDSkipFrames.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Skip frames (improves performance)";
            // 
            // tbFDSkipFrames
            // 
            this.tbFDSkipFrames.Location = new System.Drawing.Point(27, 228);
            this.tbFDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFDSkipFrames.Name = "tbFDSkipFrames";
            this.tbFDSkipFrames.Size = new System.Drawing.Size(156, 69);
            this.tbFDSkipFrames.TabIndex = 5;
            this.tbFDSkipFrames.Value = 5;
            this.tbFDSkipFrames.Scroll += new System.EventHandler(this.tbFDSkipFrames_Scroll);
            // 
            // rbFDRectangle
            // 
            this.rbFDRectangle.AutoSize = true;
            this.rbFDRectangle.Checked = true;
            this.rbFDRectangle.Location = new System.Drawing.Point(210, 158);
            this.rbFDRectangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFDRectangle.Name = "rbFDRectangle";
            this.rbFDRectangle.Size = new System.Drawing.Size(107, 24);
            this.rbFDRectangle.TabIndex = 4;
            this.rbFDRectangle.TabStop = true;
            this.rbFDRectangle.Text = "Rectangle";
            this.rbFDRectangle.UseVisualStyleBackColor = true;
            // 
            // rbFDCircle
            // 
            this.rbFDCircle.AutoSize = true;
            this.rbFDCircle.Location = new System.Drawing.Point(80, 158);
            this.rbFDCircle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFDCircle.Name = "rbFDCircle";
            this.rbFDCircle.Size = new System.Drawing.Size(73, 24);
            this.rbFDCircle.TabIndex = 3;
            this.rbFDCircle.Text = "Circle";
            this.rbFDCircle.UseVisualStyleBackColor = true;
            // 
            // cbFDDraw
            // 
            this.cbFDDraw.AutoSize = true;
            this.cbFDDraw.Checked = true;
            this.cbFDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFDDraw.Location = new System.Drawing.Point(27, 123);
            this.cbFDDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDDraw.Name = "cbFDDraw";
            this.cbFDDraw.Size = new System.Drawing.Size(72, 24);
            this.cbFDDraw.TabIndex = 2;
            this.cbFDDraw.Text = "Draw";
            this.cbFDDraw.UseVisualStyleBackColor = true;
            // 
            // cbFDEnabled
            // 
            this.cbFDEnabled.AutoSize = true;
            this.cbFDEnabled.Location = new System.Drawing.Point(27, 28);
            this.cbFDEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFDEnabled.Name = "cbFDEnabled";
            this.cbFDEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbFDEnabled.TabIndex = 0;
            this.cbFDEnabled.Text = "Enabled";
            this.cbFDEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.edCCDetectedCars);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.cbCCDraw);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.cbCCEnabled);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(682, 979);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cars counter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // edCCDetectedCars
            // 
            this.edCCDetectedCars.Location = new System.Drawing.Point(156, 134);
            this.edCCDetectedCars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCCDetectedCars.Name = "edCCDetectedCars";
            this.edCCDetectedCars.ReadOnly = true;
            this.edCCDetectedCars.Size = new System.Drawing.Size(73, 26);
            this.edCCDetectedCars.TabIndex = 149;
            this.edCCDetectedCars.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 138);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 148;
            this.label12.Text = "Detected cars";
            // 
            // cbCCDraw
            // 
            this.cbCCDraw.AutoSize = true;
            this.cbCCDraw.Location = new System.Drawing.Point(27, 83);
            this.cbCCDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCCDraw.Name = "cbCCDraw";
            this.cbCCDraw.Size = new System.Drawing.Size(72, 24);
            this.cbCCDraw.TabIndex = 147;
            this.cbCCDraw.Text = "Draw";
            this.cbCCDraw.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 931);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(242, 20);
            this.label10.TabIndex = 146;
            this.label10.Text = "More settings available using API";
            // 
            // cbCCEnabled
            // 
            this.cbCCEnabled.AutoSize = true;
            this.cbCCEnabled.Location = new System.Drawing.Point(27, 28);
            this.cbCCEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCCEnabled.Name = "cbCCEnabled";
            this.cbCCEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbCCEnabled.TabIndex = 1;
            this.cbCCEnabled.Text = "Enabled";
            this.cbCCEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lbPDSkipFrames);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.tbPDSkipFrames);
            this.tabPage5.Controls.Add(this.lbPDDownscale);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.edPDDetected);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.tbPDDownscale);
            this.tabPage5.Controls.Add(this.cbPDDraw);
            this.tabPage5.Controls.Add(this.cbPDEnabled);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Size = new System.Drawing.Size(682, 979);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pedestrian detector";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbPDSkipFrames
            // 
            this.lbPDSkipFrames.AutoSize = true;
            this.lbPDSkipFrames.Location = new System.Drawing.Point(192, 195);
            this.lbPDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPDSkipFrames.Name = "lbPDSkipFrames";
            this.lbPDSkipFrames.Size = new System.Drawing.Size(18, 20);
            this.lbPDSkipFrames.TabIndex = 156;
            this.lbPDSkipFrames.Text = "5";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 157);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(264, 20);
            this.label19.TabIndex = 155;
            this.label19.Text = "Skip frames (improves performance)";
            // 
            // tbPDSkipFrames
            // 
            this.tbPDSkipFrames.Location = new System.Drawing.Point(27, 182);
            this.tbPDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPDSkipFrames.Name = "tbPDSkipFrames";
            this.tbPDSkipFrames.Size = new System.Drawing.Size(156, 69);
            this.tbPDSkipFrames.TabIndex = 154;
            this.tbPDSkipFrames.Value = 5;
            this.tbPDSkipFrames.Scroll += new System.EventHandler(this.tbPDSkipFrames_Scroll);
            // 
            // lbPDDownscale
            // 
            this.lbPDDownscale.AutoSize = true;
            this.lbPDDownscale.Location = new System.Drawing.Point(519, 198);
            this.lbPDDownscale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPDDownscale.Name = "lbPDDownscale";
            this.lbPDDownscale.Size = new System.Drawing.Size(31, 20);
            this.lbPDDownscale.TabIndex = 153;
            this.lbPDDownscale.Text = "1.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 931);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(242, 20);
            this.label14.TabIndex = 152;
            this.label14.Text = "More settings available using API";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 691);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(162, 20);
            this.label15.TabIndex = 151;
            this.label15.Text = "Detected pedestrians";
            // 
            // edPDDetected
            // 
            this.edPDDetected.Location = new System.Drawing.Point(27, 715);
            this.edPDDetected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edPDDetected.Multiline = true;
            this.edPDDetected.Name = "edPDDetected";
            this.edPDDetected.Size = new System.Drawing.Size(625, 193);
            this.edPDDetected.TabIndex = 150;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(350, 157);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(299, 20);
            this.label16.TabIndex = 149;
            this.label16.Text = "Downscale video (improves performance)";
            // 
            // tbPDDownscale
            // 
            this.tbPDDownscale.Location = new System.Drawing.Point(354, 182);
            this.tbPDDownscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPDDownscale.Maximum = 30;
            this.tbPDDownscale.Minimum = 10;
            this.tbPDDownscale.Name = "tbPDDownscale";
            this.tbPDDownscale.Size = new System.Drawing.Size(156, 69);
            this.tbPDDownscale.TabIndex = 148;
            this.tbPDDownscale.Value = 10;
            this.tbPDDownscale.Scroll += new System.EventHandler(this.tbPDDownscale_Scroll);
            // 
            // cbPDDraw
            // 
            this.cbPDDraw.AutoSize = true;
            this.cbPDDraw.Checked = true;
            this.cbPDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPDDraw.Location = new System.Drawing.Point(27, 83);
            this.cbPDDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPDDraw.Name = "cbPDDraw";
            this.cbPDDraw.Size = new System.Drawing.Size(72, 24);
            this.cbPDDraw.TabIndex = 147;
            this.cbPDDraw.Text = "Draw";
            this.cbPDDraw.UseVisualStyleBackColor = true;
            // 
            // cbPDEnabled
            // 
            this.cbPDEnabled.AutoSize = true;
            this.cbPDEnabled.Location = new System.Drawing.Point(27, 28);
            this.cbPDEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPDEnabled.Name = "cbPDEnabled";
            this.cbPDEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbPDEnabled.TabIndex = 146;
            this.cbPDEnabled.Text = "Enabled";
            this.cbPDEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cbObjectDetector);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(682, 979);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Object detector";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // cbObjectDetector
            // 
            this.cbObjectDetector.AutoSize = true;
            this.cbObjectDetector.Location = new System.Drawing.Point(27, 28);
            this.cbObjectDetector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbObjectDetector.Name = "cbObjectDetector";
            this.cbObjectDetector.Size = new System.Drawing.Size(94, 24);
            this.cbObjectDetector.TabIndex = 147;
            this.cbObjectDetector.Text = "Enabled";
            this.cbObjectDetector.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(682, 979);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(27, 28);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(127, 24);
            this.cbDebugMode.TabIndex = 75;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(27, 63);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(622, 346);
            this.mmLog.TabIndex = 74;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // VideoCaptureView
            // 
            this.VideoCaptureView.BackColor = System.Drawing.Color.Black;
            this.VideoCaptureView.Location = new System.Drawing.Point(717, 18);
            this.VideoCaptureView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoCaptureView.Name = "VideoCaptureView";
            this.VideoCaptureView.Size = new System.Drawing.Size(705, 535);
            this.VideoCaptureView.StatusOverlay = null;
            this.VideoCaptureView.TabIndex = 85;
            // 
            // MediaPlayerView
            // 
            this.MediaPlayerView.BackColor = System.Drawing.Color.Black;
            this.MediaPlayerView.Location = new System.Drawing.Point(717, 18);
            this.MediaPlayerView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MediaPlayerView.Name = "MediaPlayerView";
            this.MediaPlayerView.Size = new System.Drawing.Size(705, 535);
            this.MediaPlayerView.StatusOverlay = null;
            this.MediaPlayerView.TabIndex = 84;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 1051);
            this.Controls.Add(this.VideoCaptureView);
            this.Controls.Add(this.MediaPlayerView);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Computer Vision Demo - Video Capture SDK .Net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDScaleFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDMinNeighbors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDDownscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFDSkipFrames)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDSkipFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDDownscale)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbVideoCaptureDevice;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edIPUrl;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.RadioButton rbIPCamera;
        private System.Windows.Forms.CheckBox cbIPCameraONVIF;
        private System.Windows.Forms.Button btShowIPCamDatabase;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.ComboBox cbIPCameraType;
        private System.Windows.Forms.TextBox edIPPassword;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.TextBox edIPLogin;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbFDEnabled;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Label lbFDSkipFrames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbFDSkipFrames;
        private System.Windows.Forms.RadioButton rbFDRectangle;
        private System.Windows.Forms.RadioButton rbFDCircle;
        private System.Windows.Forms.CheckBox cbFDDraw;
        private System.Windows.Forms.Label lbFDDownscale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbFDDownscale;
        private System.Windows.Forms.Label lbFDScaleFactor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbFDScaleFactor;
        private System.Windows.Forms.Label lbFDMinNeighbors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbFDMinNeighbors;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edFDFaces;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbVideoFile;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cbCCEnabled;
        private System.Windows.Forms.TextBox edCCDetectedCars;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbCCDraw;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lbPDDownscale;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox edPDDetected;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar tbPDDownscale;
        private System.Windows.Forms.CheckBox cbPDDraw;
        private System.Windows.Forms.CheckBox cbPDEnabled;
        private System.Windows.Forms.Label lbPDSkipFrames;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TrackBar tbPDSkipFrames;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbFDMouth;
        private System.Windows.Forms.CheckBox cbFDFace;
        private System.Windows.Forms.CheckBox cbFDNose;
        private System.Windows.Forms.Button btFDUpdate;
        private System.Windows.Forms.CheckBox cbFDEyes;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox edFDMinFaceHeight;
        private System.Windows.Forms.TextBox edFDMinFaceWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbFDMosaic;
        private VisioForge.Core.UI.WinForms.VideoView MediaPlayerView;
        private VisioForge.Core.UI.WinForms.VideoView VideoCaptureView;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox cbObjectDetector;
    }
}

