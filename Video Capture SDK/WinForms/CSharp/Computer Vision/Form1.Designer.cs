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
            this.cbFramerate = new System.Windows.Forms.ComboBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.MediaPlayer1 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
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
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(886, 367);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 79;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(821, 367);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
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
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(460, 658);
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
            this.tabPage1.Controls.Add(this.cbFramerate);
            this.tabPage1.Controls.Add(this.cbVideoInputFormat);
            this.tabPage1.Controls.Add(this.cbVideoInputDevice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 632);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(412, 417);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(24, 23);
            this.btOpenFile.TabIndex = 144;
            this.btOpenFile.Text = "...";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // edFilename
            // 
            this.edFilename.Location = new System.Drawing.Point(43, 419);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(363, 20);
            this.edFilename.TabIndex = 143;
            this.edFilename.Text = "c:\\samples\\cv\\peoples_walking2.mp4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(87, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = " (using Media Player SDK instead Video Capture SDK)";
            // 
            // rbVideoFile
            // 
            this.rbVideoFile.AutoSize = true;
            this.rbVideoFile.Location = new System.Drawing.Point(18, 396);
            this.rbVideoFile.Name = "rbVideoFile";
            this.rbVideoFile.Size = new System.Drawing.Size(68, 17);
            this.rbVideoFile.TabIndex = 141;
            this.rbVideoFile.Text = "Video file";
            this.rbVideoFile.UseVisualStyleBackColor = true;
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(88, 306);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(100, 20);
            this.edIPLogin.TabIndex = 140;
            // 
            // cbIPCameraONVIF
            // 
            this.cbIPCameraONVIF.AutoSize = true;
            this.cbIPCameraONVIF.Location = new System.Drawing.Point(305, 260);
            this.cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            this.cbIPCameraONVIF.Size = new System.Drawing.Size(96, 17);
            this.cbIPCameraONVIF.TabIndex = 139;
            this.cbIPCameraONVIF.Text = "ONVIF camera";
            this.cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // btShowIPCamDatabase
            // 
            this.btShowIPCamDatabase.Location = new System.Drawing.Point(305, 304);
            this.btShowIPCamDatabase.Name = "btShowIPCamDatabase";
            this.btShowIPCamDatabase.Size = new System.Drawing.Size(131, 23);
            this.btShowIPCamDatabase.TabIndex = 138;
            this.btShowIPCamDatabase.Text = "Show IP cam database";
            this.btShowIPCamDatabase.UseVisualStyleBackColor = true;
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(85, 353);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(264, 13);
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
            "RTSP (Live555 engine)",
            "MMS - WMV"});
            this.cbIPCameraType.Location = new System.Drawing.Point(88, 258);
            this.cbIPCameraType.Name = "cbIPCameraType";
            this.cbIPCameraType.Size = new System.Drawing.Size(211, 21);
            this.cbIPCameraType.TabIndex = 136;
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(199, 306);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(100, 20);
            this.edIPPassword.TabIndex = 135;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(196, 289);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(53, 13);
            this.label167.TabIndex = 134;
            this.label167.Text = "Password";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(85, 289);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(33, 13);
            this.label166.TabIndex = 133;
            this.label166.Text = "Login";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(40, 261);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(40, 13);
            this.label168.TabIndex = 132;
            this.label168.Text = "Engine";
            // 
            // edIPUrl
            // 
            this.edIPUrl.Location = new System.Drawing.Point(88, 225);
            this.edIPUrl.Name = "edIPUrl";
            this.edIPUrl.Size = new System.Drawing.Size(348, 20);
            this.edIPUrl.TabIndex = 131;
            this.edIPUrl.Text = "http://212.162.177.75/mjpg/video.mjpg";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(40, 228);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(29, 13);
            this.label165.TabIndex = 130;
            this.label165.Text = "URL";
            // 
            // rbIPCamera
            // 
            this.rbIPCamera.AutoSize = true;
            this.rbIPCamera.Location = new System.Drawing.Point(18, 187);
            this.rbIPCamera.Name = "rbIPCamera";
            this.rbIPCamera.Size = new System.Drawing.Size(73, 17);
            this.rbIPCamera.TabIndex = 129;
            this.rbIPCamera.Text = "IP camera";
            this.rbIPCamera.UseVisualStyleBackColor = true;
            // 
            // rbVideoCaptureDevice
            // 
            this.rbVideoCaptureDevice.AutoSize = true;
            this.rbVideoCaptureDevice.Checked = true;
            this.rbVideoCaptureDevice.Location = new System.Drawing.Point(18, 17);
            this.rbVideoCaptureDevice.Name = "rbVideoCaptureDevice";
            this.rbVideoCaptureDevice.Size = new System.Drawing.Size(126, 17);
            this.rbVideoCaptureDevice.TabIndex = 128;
            this.rbVideoCaptureDevice.TabStop = true;
            this.rbVideoCaptureDevice.Text = "Video capture device";
            this.rbVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(328, 148);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 127;
            this.label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(180, 121);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 126;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbFramerate
            // 
            this.cbFramerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFramerate.FormattingEnabled = true;
            this.cbFramerate.Location = new System.Drawing.Point(257, 143);
            this.cbFramerate.Name = "cbFramerate";
            this.cbFramerate.Size = new System.Drawing.Size(65, 21);
            this.cbFramerate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(43, 143);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(208, 21);
            this.cbVideoInputFormat.TabIndex = 123;
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(43, 81);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(208, 21);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 121;
            this.label13.Text = "Input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 632);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Face detector";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbFDMosaic
            // 
            this.cbFDMosaic.AutoSize = true;
            this.cbFDMosaic.Location = new System.Drawing.Point(226, 309);
            this.cbFDMosaic.Name = "cbFDMosaic";
            this.cbFDMosaic.Size = new System.Drawing.Size(131, 17);
            this.cbFDMosaic.TabIndex = 156;
            this.cbFDMosaic.Text = "Draw mosaic on faces";
            this.cbFDMosaic.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(265, 234);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 13);
            this.label21.TabIndex = 155;
            this.label21.Text = "x";
            // 
            // edFDMinFaceHeight
            // 
            this.edFDMinFaceHeight.Location = new System.Drawing.Point(278, 231);
            this.edFDMinFaceHeight.Name = "edFDMinFaceHeight";
            this.edFDMinFaceHeight.Size = new System.Drawing.Size(36, 20);
            this.edFDMinFaceHeight.TabIndex = 154;
            this.edFDMinFaceHeight.Text = "100";
            // 
            // edFDMinFaceWidth
            // 
            this.edFDMinFaceWidth.Location = new System.Drawing.Point(226, 231);
            this.edFDMinFaceWidth.Name = "edFDMinFaceWidth";
            this.edFDMinFaceWidth.Size = new System.Drawing.Size(36, 20);
            this.edFDMinFaceWidth.TabIndex = 153;
            this.edFDMinFaceWidth.Text = "100";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(223, 215);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 13);
            this.label20.TabIndex = 152;
            this.label20.Text = "Minimal face size";
            // 
            // cbFDEyes
            // 
            this.cbFDEyes.AutoSize = true;
            this.cbFDEyes.Location = new System.Drawing.Point(278, 57);
            this.cbFDEyes.Name = "cbFDEyes";
            this.cbFDEyes.Size = new System.Drawing.Size(49, 17);
            this.cbFDEyes.TabIndex = 151;
            this.cbFDEyes.Text = "Eyes";
            this.cbFDEyes.UseVisualStyleBackColor = true;
            // 
            // cbFDNose
            // 
            this.cbFDNose.AutoSize = true;
            this.cbFDNose.Location = new System.Drawing.Point(198, 57);
            this.cbFDNose.Name = "cbFDNose";
            this.cbFDNose.Size = new System.Drawing.Size(51, 17);
            this.cbFDNose.TabIndex = 150;
            this.cbFDNose.Text = "Nose";
            this.cbFDNose.UseVisualStyleBackColor = true;
            // 
            // btFDUpdate
            // 
            this.btFDUpdate.Location = new System.Drawing.Point(18, 406);
            this.btFDUpdate.Name = "btFDUpdate";
            this.btFDUpdate.Size = new System.Drawing.Size(75, 23);
            this.btFDUpdate.TabIndex = 149;
            this.btFDUpdate.Text = "Update";
            this.btFDUpdate.UseVisualStyleBackColor = true;
            this.btFDUpdate.Click += new System.EventHandler(this.btFDUpdate_Click);
            // 
            // cbFDMouth
            // 
            this.cbFDMouth.AutoSize = true;
            this.cbFDMouth.Location = new System.Drawing.Point(106, 57);
            this.cbFDMouth.Name = "cbFDMouth";
            this.cbFDMouth.Size = new System.Drawing.Size(56, 17);
            this.cbFDMouth.TabIndex = 148;
            this.cbFDMouth.Text = "Mouth";
            this.cbFDMouth.UseVisualStyleBackColor = true;
            // 
            // cbFDFace
            // 
            this.cbFDFace.AutoSize = true;
            this.cbFDFace.Checked = true;
            this.cbFDFace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFDFace.Location = new System.Drawing.Point(18, 57);
            this.cbFDFace.Name = "cbFDFace";
            this.cbFDFace.Size = new System.Drawing.Size(50, 17);
            this.cbFDFace.TabIndex = 147;
            this.cbFDFace.Text = "Face";
            this.cbFDFace.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(119, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(227, 13);
            this.label17.TabIndex = 146;
            this.label17.Text = "Face, eyes, nose and mouth tracking available";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 605);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 13);
            this.label5.TabIndex = 145;
            this.label5.Text = "More settings available using API";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "Detected faces";
            // 
            // edFDFaces
            // 
            this.edFDFaces.Location = new System.Drawing.Point(18, 465);
            this.edFDFaces.Multiline = true;
            this.edFDFaces.Name = "edFDFaces";
            this.edFDFaces.Size = new System.Drawing.Size(418, 127);
            this.edFDFaces.TabIndex = 143;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(331, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Specifying how much the image size is reduced at each image scale.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(393, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Specifying how many neighbors each candidate rectangle should have to retain it.";
            // 
            // lbFDScaleFactor
            // 
            this.lbFDScaleFactor.AutoSize = true;
            this.lbFDScaleFactor.Location = new System.Drawing.Point(128, 331);
            this.lbFDScaleFactor.Name = "lbFDScaleFactor";
            this.lbFDScaleFactor.Size = new System.Drawing.Size(28, 13);
            this.lbFDScaleFactor.TabIndex = 16;
            this.lbFDScaleFactor.Text = "1.10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Scale factor";
            // 
            // tbFDScaleFactor
            // 
            this.tbFDScaleFactor.Location = new System.Drawing.Point(18, 322);
            this.tbFDScaleFactor.Maximum = 150;
            this.tbFDScaleFactor.Minimum = 101;
            this.tbFDScaleFactor.Name = "tbFDScaleFactor";
            this.tbFDScaleFactor.Size = new System.Drawing.Size(104, 45);
            this.tbFDScaleFactor.TabIndex = 14;
            this.tbFDScaleFactor.Value = 110;
            this.tbFDScaleFactor.Scroll += new System.EventHandler(this.tbScaleFactor_Scroll);
            // 
            // lbFDMinNeighbors
            // 
            this.lbFDMinNeighbors.AutoSize = true;
            this.lbFDMinNeighbors.Location = new System.Drawing.Point(128, 240);
            this.lbFDMinNeighbors.Name = "lbFDMinNeighbors";
            this.lbFDMinNeighbors.Size = new System.Drawing.Size(13, 13);
            this.lbFDMinNeighbors.TabIndex = 13;
            this.lbFDMinNeighbors.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Minimal neighbors count";
            // 
            // tbFDMinNeighbors
            // 
            this.tbFDMinNeighbors.Location = new System.Drawing.Point(18, 231);
            this.tbFDMinNeighbors.Maximum = 12;
            this.tbFDMinNeighbors.Minimum = 3;
            this.tbFDMinNeighbors.Name = "tbFDMinNeighbors";
            this.tbFDMinNeighbors.Size = new System.Drawing.Size(104, 45);
            this.tbFDMinNeighbors.TabIndex = 11;
            this.tbFDMinNeighbors.Value = 8;
            this.tbFDMinNeighbors.Scroll += new System.EventHandler(this.tbMinNeighbors_Scroll);
            // 
            // lbFDDownscale
            // 
            this.lbFDDownscale.AutoSize = true;
            this.lbFDDownscale.Location = new System.Drawing.Point(336, 157);
            this.lbFDDownscale.Name = "lbFDDownscale";
            this.lbFDDownscale.Size = new System.Drawing.Size(22, 13);
            this.lbFDDownscale.TabIndex = 10;
            this.lbFDDownscale.Text = "1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Downscale video (improves performance)";
            // 
            // tbFDDownscale
            // 
            this.tbFDDownscale.Location = new System.Drawing.Point(226, 148);
            this.tbFDDownscale.Maximum = 30;
            this.tbFDDownscale.Minimum = 10;
            this.tbFDDownscale.Name = "tbFDDownscale";
            this.tbFDDownscale.Size = new System.Drawing.Size(104, 45);
            this.tbFDDownscale.TabIndex = 8;
            this.tbFDDownscale.Value = 10;
            this.tbFDDownscale.Scroll += new System.EventHandler(this.tbFDDownscale_Scroll);
            // 
            // lbFDSkipFrames
            // 
            this.lbFDSkipFrames.AutoSize = true;
            this.lbFDSkipFrames.Location = new System.Drawing.Point(128, 157);
            this.lbFDSkipFrames.Name = "lbFDSkipFrames";
            this.lbFDSkipFrames.Size = new System.Drawing.Size(13, 13);
            this.lbFDSkipFrames.TabIndex = 7;
            this.lbFDSkipFrames.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Skip frames (improves performance)";
            // 
            // tbFDSkipFrames
            // 
            this.tbFDSkipFrames.Location = new System.Drawing.Point(18, 148);
            this.tbFDSkipFrames.Name = "tbFDSkipFrames";
            this.tbFDSkipFrames.Size = new System.Drawing.Size(104, 45);
            this.tbFDSkipFrames.TabIndex = 5;
            this.tbFDSkipFrames.Value = 5;
            this.tbFDSkipFrames.Scroll += new System.EventHandler(this.tbFDSkipFrames_Scroll);
            // 
            // rbFDRectangle
            // 
            this.rbFDRectangle.AutoSize = true;
            this.rbFDRectangle.Checked = true;
            this.rbFDRectangle.Location = new System.Drawing.Point(140, 103);
            this.rbFDRectangle.Name = "rbFDRectangle";
            this.rbFDRectangle.Size = new System.Drawing.Size(74, 17);
            this.rbFDRectangle.TabIndex = 4;
            this.rbFDRectangle.TabStop = true;
            this.rbFDRectangle.Text = "Rectangle";
            this.rbFDRectangle.UseVisualStyleBackColor = true;
            // 
            // rbFDCircle
            // 
            this.rbFDCircle.AutoSize = true;
            this.rbFDCircle.Location = new System.Drawing.Point(53, 103);
            this.rbFDCircle.Name = "rbFDCircle";
            this.rbFDCircle.Size = new System.Drawing.Size(51, 17);
            this.rbFDCircle.TabIndex = 3;
            this.rbFDCircle.Text = "Circle";
            this.rbFDCircle.UseVisualStyleBackColor = true;
            // 
            // cbFDDraw
            // 
            this.cbFDDraw.AutoSize = true;
            this.cbFDDraw.Checked = true;
            this.cbFDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFDDraw.Location = new System.Drawing.Point(18, 80);
            this.cbFDDraw.Name = "cbFDDraw";
            this.cbFDDraw.Size = new System.Drawing.Size(51, 17);
            this.cbFDDraw.TabIndex = 2;
            this.cbFDDraw.Text = "Draw";
            this.cbFDDraw.UseVisualStyleBackColor = true;
            // 
            // cbFDEnabled
            // 
            this.cbFDEnabled.AutoSize = true;
            this.cbFDEnabled.Location = new System.Drawing.Point(18, 18);
            this.cbFDEnabled.Name = "cbFDEnabled";
            this.cbFDEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(452, 632);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cars counter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // edCCDetectedCars
            // 
            this.edCCDetectedCars.Location = new System.Drawing.Point(104, 87);
            this.edCCDetectedCars.Name = "edCCDetectedCars";
            this.edCCDetectedCars.ReadOnly = true;
            this.edCCDetectedCars.Size = new System.Drawing.Size(50, 20);
            this.edCCDetectedCars.TabIndex = 149;
            this.edCCDetectedCars.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 148;
            this.label12.Text = "Detected cars";
            // 
            // cbCCDraw
            // 
            this.cbCCDraw.AutoSize = true;
            this.cbCCDraw.Location = new System.Drawing.Point(18, 54);
            this.cbCCDraw.Name = "cbCCDraw";
            this.cbCCDraw.Size = new System.Drawing.Size(51, 17);
            this.cbCCDraw.TabIndex = 147;
            this.cbCCDraw.Text = "Draw";
            this.cbCCDraw.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 605);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 13);
            this.label10.TabIndex = 146;
            this.label10.Text = "More settings available using API";
            // 
            // cbCCEnabled
            // 
            this.cbCCEnabled.AutoSize = true;
            this.cbCCEnabled.Location = new System.Drawing.Point(18, 18);
            this.cbCCEnabled.Name = "cbCCEnabled";
            this.cbCCEnabled.Size = new System.Drawing.Size(65, 17);
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
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(452, 632);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pedestrian detector";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbPDSkipFrames
            // 
            this.lbPDSkipFrames.AutoSize = true;
            this.lbPDSkipFrames.Location = new System.Drawing.Point(128, 127);
            this.lbPDSkipFrames.Name = "lbPDSkipFrames";
            this.lbPDSkipFrames.Size = new System.Drawing.Size(13, 13);
            this.lbPDSkipFrames.TabIndex = 156;
            this.lbPDSkipFrames.Text = "5";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(175, 13);
            this.label19.TabIndex = 155;
            this.label19.Text = "Skip frames (improves performance)";
            // 
            // tbPDSkipFrames
            // 
            this.tbPDSkipFrames.Location = new System.Drawing.Point(18, 118);
            this.tbPDSkipFrames.Name = "tbPDSkipFrames";
            this.tbPDSkipFrames.Size = new System.Drawing.Size(104, 45);
            this.tbPDSkipFrames.TabIndex = 154;
            this.tbPDSkipFrames.Value = 5;
            this.tbPDSkipFrames.Scroll += new System.EventHandler(this.tbPDSkipFrames_Scroll);
            // 
            // lbPDDownscale
            // 
            this.lbPDDownscale.AutoSize = true;
            this.lbPDDownscale.Location = new System.Drawing.Point(346, 129);
            this.lbPDDownscale.Name = "lbPDDownscale";
            this.lbPDDownscale.Size = new System.Drawing.Size(22, 13);
            this.lbPDDownscale.TabIndex = 153;
            this.lbPDDownscale.Text = "1.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 605);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 13);
            this.label14.TabIndex = 152;
            this.label14.Text = "More settings available using API";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 449);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 151;
            this.label15.Text = "Detected pedestrians";
            // 
            // edPDDetected
            // 
            this.edPDDetected.Location = new System.Drawing.Point(18, 465);
            this.edPDDetected.Multiline = true;
            this.edPDDetected.Name = "edPDDetected";
            this.edPDDetected.Size = new System.Drawing.Size(418, 127);
            this.edPDDetected.TabIndex = 150;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(233, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(202, 13);
            this.label16.TabIndex = 149;
            this.label16.Text = "Downscale video (improves performance)";
            // 
            // tbPDDownscale
            // 
            this.tbPDDownscale.Location = new System.Drawing.Point(236, 118);
            this.tbPDDownscale.Maximum = 30;
            this.tbPDDownscale.Minimum = 10;
            this.tbPDDownscale.Name = "tbPDDownscale";
            this.tbPDDownscale.Size = new System.Drawing.Size(104, 45);
            this.tbPDDownscale.TabIndex = 148;
            this.tbPDDownscale.Value = 10;
            this.tbPDDownscale.Scroll += new System.EventHandler(this.tbPDDownscale_Scroll);
            // 
            // cbPDDraw
            // 
            this.cbPDDraw.AutoSize = true;
            this.cbPDDraw.Checked = true;
            this.cbPDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPDDraw.Location = new System.Drawing.Point(18, 54);
            this.cbPDDraw.Name = "cbPDDraw";
            this.cbPDDraw.Size = new System.Drawing.Size(51, 17);
            this.cbPDDraw.TabIndex = 147;
            this.cbPDDraw.Text = "Draw";
            this.cbPDDraw.UseVisualStyleBackColor = true;
            // 
            // cbPDEnabled
            // 
            this.cbPDEnabled.AutoSize = true;
            this.cbPDEnabled.Location = new System.Drawing.Point(18, 18);
            this.cbPDEnabled.Name = "cbPDEnabled";
            this.cbPDEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbPDEnabled.TabIndex = 146;
            this.cbPDEnabled.Text = "Enabled";
            this.cbPDEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(452, 632);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(18, 18);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 75;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(18, 41);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(416, 226);
            this.mmLog.TabIndex = 74;
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
            this.VideoCapture1.Location = new System.Drawing.Point(481, 12);
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
            this.VideoCapture1.Size = new System.Drawing.Size(467, 348);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 82;
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
            this.VideoCapture1.OnVideoFrameBuffer += new System.EventHandler<VisioForge.Types.VideoFrameBufferEventArgs>(this.VideoCapture1_OnVideoFrameBuffer);
            // 
            // MediaPlayer1
            // 
            this.MediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MediaPlayer1.Audio_Channel_Mapper = null;
            this.MediaPlayer1.Audio_Effects_Enabled = false;
            this.MediaPlayer1.Audio_Effects_UseLegacyEffects = false;
            this.MediaPlayer1.Audio_Enhancer_Enabled = false;
            this.MediaPlayer1.Audio_OutputDevice = "";
            this.MediaPlayer1.Audio_PlayAudio = false;
            this.MediaPlayer1.Audio_Sample_Grabber_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Pro_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Pro_Volume = 0;
            this.MediaPlayer1.BackColor = System.Drawing.Color.Black;
            this.MediaPlayer1.Barcode_Reader_Enabled = false;
            this.MediaPlayer1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.MediaPlayer1.ChromaKey = null;
            this.MediaPlayer1.Custom_Audio_Decoder = null;
            this.MediaPlayer1.Custom_Splitter = null;
            this.MediaPlayer1.Custom_Video_Decoder = null;
            this.MediaPlayer1.CustomRedist_Auto = true;
            this.MediaPlayer1.CustomRedist_Enabled = false;
            this.MediaPlayer1.CustomRedist_Path = null;
            this.MediaPlayer1.Debug_DeepCleanUp = false;
            this.MediaPlayer1.Debug_Dir = null;
            this.MediaPlayer1.Debug_DisableMessageDialogs = false;
            this.MediaPlayer1.Debug_Mode = false;
            this.MediaPlayer1.Debug_Telemetry = false;
            this.MediaPlayer1.Encryption_Key = "";
            this.MediaPlayer1.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer1.Face_Tracking = null;
            this.MediaPlayer1.Info_UseLibMediaInfo = false;
            this.MediaPlayer1.Location = new System.Drawing.Point(481, 12);
            this.MediaPlayer1.Loop = false;
            this.MediaPlayer1.Loop_DoNotSeekToBeginning = false;
            this.MediaPlayer1.MaximalSpeedPlayback = false;
            this.MediaPlayer1.MIDI_Renderer = null;
            this.MediaPlayer1.Motion_Detection = null;
            this.MediaPlayer1.Motion_DetectionEx = null;
            this.MediaPlayer1.MultiScreen_Enabled = false;
            this.MediaPlayer1.Name = "MediaPlayer1";
            this.MediaPlayer1.OSD_Enabled = false;
            this.MediaPlayer1.Play_DelayEnabled = false;
            this.MediaPlayer1.Play_PauseAtFirstFrame = false;
            this.MediaPlayer1.ReversePlayback_CacheSize = 0;
            this.MediaPlayer1.ReversePlayback_Enabled = false;
            this.MediaPlayer1.Selection_Active = false;
            this.MediaPlayer1.Selection_Start = 0;
            this.MediaPlayer1.Selection_Stop = 0;
            this.MediaPlayer1.Size = new System.Drawing.Size(467, 348);
            this.MediaPlayer1.Source_Custom_CLSID = null;
            this.MediaPlayer1.Source_GPU_Mode = VisioForge.Types.VFMediaPlayerSourceGPUDecoder.nVidiaCUVID;
            this.MediaPlayer1.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer1.Source_Stream = null;
            this.MediaPlayer1.Source_Stream_AudioPresent = true;
            this.MediaPlayer1.Source_Stream_Size = ((long)(0));
            this.MediaPlayer1.Source_Stream_VideoPresent = true;
            this.MediaPlayer1.TabIndex = 84;
            this.MediaPlayer1.Video_Effects_Enabled = false;
            this.MediaPlayer1.Video_Effects_GPU_Enabled = false;
            this.MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer1.Video_Stream_Index = 0;
            this.MediaPlayer1.Virtual_Camera_Output_Enabled = false;
            this.MediaPlayer1.Virtual_Camera_Output_LicenseKey = null;
            this.MediaPlayer1.OnVideoFrameBuffer += new System.EventHandler<VisioForge.Types.VideoFrameBufferEventArgs>(this.MediaPlayer1_OnVideoFrameBuffer);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 683);
            this.Controls.Add(this.MediaPlayer1);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbVideoCaptureDevice;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbFramerate;
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
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer1;
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
    }
}

