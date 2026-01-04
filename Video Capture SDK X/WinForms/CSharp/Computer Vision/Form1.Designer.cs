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
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tcMain = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            btOpenFile = new System.Windows.Forms.Button();
            edFilename = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            rbVideoFile = new System.Windows.Forms.RadioButton();
            edIPLogin = new System.Windows.Forms.TextBox();
            edIPPassword = new System.Windows.Forms.TextBox();
            label167 = new System.Windows.Forms.Label();
            label166 = new System.Windows.Forms.Label();
            edIPUrl = new System.Windows.Forms.TextBox();
            label165 = new System.Windows.Forms.Label();
            rbIPCamera = new System.Windows.Forms.RadioButton();
            rbVideoCaptureDevice = new System.Windows.Forms.RadioButton();
            label28 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            cbFDMosaic = new System.Windows.Forms.CheckBox();
            label21 = new System.Windows.Forms.Label();
            edFDMinFaceHeight = new System.Windows.Forms.TextBox();
            edFDMinFaceWidth = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            btFDUpdate = new System.Windows.Forms.Button();
            cbFDFace = new System.Windows.Forms.CheckBox();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            edFDFaces = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            lbFDScaleFactor = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tbFDScaleFactor = new System.Windows.Forms.TrackBar();
            lbFDMinNeighbors = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            tbFDMinNeighbors = new System.Windows.Forms.TrackBar();
            lbFDDownscale = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tbFDDownscale = new System.Windows.Forms.TrackBar();
            lbFDSkipFrames = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tbFDSkipFrames = new System.Windows.Forms.TrackBar();
            rbFDRectangle = new System.Windows.Forms.RadioButton();
            rbFDCircle = new System.Windows.Forms.RadioButton();
            cbFDDraw = new System.Windows.Forms.CheckBox();
            cbFDEnabled = new System.Windows.Forms.CheckBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            edCCDetectedCars = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            cbCCDraw = new System.Windows.Forms.CheckBox();
            label10 = new System.Windows.Forms.Label();
            cbCCEnabled = new System.Windows.Forms.CheckBox();
            tabPage5 = new System.Windows.Forms.TabPage();
            lbPDSkipFrames = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            tbPDSkipFrames = new System.Windows.Forms.TrackBar();
            lbPDDownscale = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            edPDDetected = new System.Windows.Forms.TextBox();
            label16 = new System.Windows.Forms.Label();
            tbPDDownscale = new System.Windows.Forms.TrackBar();
            cbPDDraw = new System.Windows.Forms.CheckBox();
            cbPDEnabled = new System.Windows.Forms.CheckBox();
            tabPage3 = new System.Windows.Forms.TabPage();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            VideoCaptureView = new VisioForge.Core.UI.WinForms.VideoView();
            MediaPlayerView = new VisioForge.Core.UI.WinForms.VideoView();
            tcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbFDScaleFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbFDMinNeighbors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbFDDownscale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbFDSkipFrames).BeginInit();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPDSkipFrames).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPDDownscale).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStop.Location = new System.Drawing.Point(1477, 555);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 79;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(1369, 555);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 78;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // tcMain
            // 
            tcMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tcMain.Controls.Add(tabPage1);
            tcMain.Controls.Add(tabPage2);
            tcMain.Controls.Add(tabPage4);
            tcMain.Controls.Add(tabPage5);
            tcMain.Controls.Add(tabPage3);
            tcMain.Location = new System.Drawing.Point(22, 22);
            tcMain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new System.Drawing.Size(767, 1094);
            tcMain.TabIndex = 83;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btOpenFile);
            tabPage1.Controls.Add(edFilename);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(rbVideoFile);
            tabPage1.Controls.Add(edIPLogin);
            tabPage1.Controls.Add(edIPPassword);
            tabPage1.Controls.Add(label167);
            tabPage1.Controls.Add(label166);
            tabPage1.Controls.Add(edIPUrl);
            tabPage1.Controls.Add(label165);
            tabPage1.Controls.Add(rbIPCamera);
            tabPage1.Controls.Add(rbVideoCaptureDevice);
            tabPage1.Controls.Add(label28);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(cbVideoInputFrameRate);
            tabPage1.Controls.Add(cbVideoInputFormat);
            tabPage1.Controls.Add(cbVideoInputDevice);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label11);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Size = new System.Drawing.Size(759, 1056);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Source";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btOpenFile
            // 
            btOpenFile.Location = new System.Drawing.Point(684, 657);
            btOpenFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOpenFile.Name = "btOpenFile";
            btOpenFile.Size = new System.Drawing.Size(40, 44);
            btOpenFile.TabIndex = 144;
            btOpenFile.Text = "...";
            btOpenFile.UseVisualStyleBackColor = true;
            btOpenFile.Click += btOpenFile_Click;
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(71, 664);
            edFilename.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(602, 31);
            edFilename.TabIndex = 143;
            edFilename.Text = "c:\\samples\\cv\\highway.mp4";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Gray;
            label9.Location = new System.Drawing.Point(149, 613);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(454, 25);
            label9.TabIndex = 142;
            label9.Text = " (using Media Player SDK instead of Video Capture SDK)";
            // 
            // rbVideoFile
            // 
            rbVideoFile.AutoSize = true;
            rbVideoFile.Location = new System.Drawing.Point(30, 611);
            rbVideoFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoFile.Name = "rbVideoFile";
            rbVideoFile.Size = new System.Drawing.Size(111, 29);
            rbVideoFile.TabIndex = 141;
            rbVideoFile.Text = "Video file";
            rbVideoFile.UseVisualStyleBackColor = true;
            // 
            // edIPLogin
            // 
            edIPLogin.Location = new System.Drawing.Point(147, 524);
            edIPLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edIPLogin.Name = "edIPLogin";
            edIPLogin.Size = new System.Drawing.Size(164, 31);
            edIPLogin.TabIndex = 140;
            // 
            // edIPPassword
            // 
            edIPPassword.Location = new System.Drawing.Point(332, 524);
            edIPPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edIPPassword.Name = "edIPPassword";
            edIPPassword.Size = new System.Drawing.Size(164, 31);
            edIPPassword.TabIndex = 135;
            // 
            // label167
            // 
            label167.AutoSize = true;
            label167.Location = new System.Drawing.Point(332, 491);
            label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label167.Name = "label167";
            label167.Size = new System.Drawing.Size(87, 25);
            label167.TabIndex = 134;
            label167.Text = "Password";
            // 
            // label166
            // 
            label166.AutoSize = true;
            label166.Location = new System.Drawing.Point(147, 491);
            label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label166.Name = "label166";
            label166.Size = new System.Drawing.Size(56, 25);
            label166.TabIndex = 133;
            label166.Text = "Login";
            // 
            // edIPUrl
            // 
            edIPUrl.Location = new System.Drawing.Point(147, 432);
            edIPUrl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edIPUrl.Name = "edIPUrl";
            edIPUrl.Size = new System.Drawing.Size(577, 31);
            edIPUrl.TabIndex = 131;
            edIPUrl.Text = "http://212.162.177.75/mjpg/video.mjpg";
            // 
            // label165
            // 
            label165.AutoSize = true;
            label165.Location = new System.Drawing.Point(67, 439);
            label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label165.Name = "label165";
            label165.Size = new System.Drawing.Size(43, 25);
            label165.TabIndex = 130;
            label165.Text = "URL";
            // 
            // rbIPCamera
            // 
            rbIPCamera.AutoSize = true;
            rbIPCamera.Location = new System.Drawing.Point(30, 360);
            rbIPCamera.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbIPCamera.Name = "rbIPCamera";
            rbIPCamera.Size = new System.Drawing.Size(217, 29);
            rbIPCamera.TabIndex = 129;
            rbIPCamera.Text = "RTSP/ONVIF IP camera";
            rbIPCamera.UseVisualStyleBackColor = true;
            // 
            // rbVideoCaptureDevice
            // 
            rbVideoCaptureDevice.AutoSize = true;
            rbVideoCaptureDevice.Checked = true;
            rbVideoCaptureDevice.Location = new System.Drawing.Point(30, 32);
            rbVideoCaptureDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbVideoCaptureDevice.Name = "rbVideoCaptureDevice";
            rbVideoCaptureDevice.Size = new System.Drawing.Size(202, 29);
            rbVideoCaptureDevice.TabIndex = 128;
            rbVideoCaptureDevice.TabStop = true;
            rbVideoCaptureDevice.Text = "Video capture device";
            rbVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(547, 258);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(37, 25);
            label28.TabIndex = 127;
            label28.Text = "fps";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(423, 208);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(96, 25);
            label18.TabIndex = 125;
            label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFrameRate.FormattingEnabled = true;
            cbVideoInputFrameRate.Location = new System.Drawing.Point(429, 248);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(71, 248);
            cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputFormat.Name = "cbVideoInputFormat";
            cbVideoInputFormat.Size = new System.Drawing.Size(344, 33);
            cbVideoInputFormat.TabIndex = 123;
            cbVideoInputFormat.SelectedIndexChanged += cbVideoInputFormat_SelectedIndexChanged;
            // 
            // cbVideoInputDevice
            // 
            cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputDevice.FormattingEnabled = true;
            cbVideoInputDevice.Location = new System.Drawing.Point(71, 156);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(344, 33);
            cbVideoInputDevice.TabIndex = 122;
            cbVideoInputDevice.SelectedIndexChanged += cbVideoInputDevice_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(67, 208);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 25);
            label13.TabIndex = 121;
            label13.Text = "Input format";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(67, 114);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(109, 25);
            label11.TabIndex = 120;
            label11.Text = "Input device";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbFDMosaic);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(edFDMinFaceHeight);
            tabPage2.Controls.Add(edFDMinFaceWidth);
            tabPage2.Controls.Add(label20);
            tabPage2.Controls.Add(btFDUpdate);
            tabPage2.Controls.Add(cbFDFace);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(edFDFaces);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(lbFDScaleFactor);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(tbFDScaleFactor);
            tabPage2.Controls.Add(lbFDMinNeighbors);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(tbFDMinNeighbors);
            tabPage2.Controls.Add(lbFDDownscale);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(tbFDDownscale);
            tabPage2.Controls.Add(lbFDSkipFrames);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(tbFDSkipFrames);
            tabPage2.Controls.Add(rbFDRectangle);
            tabPage2.Controls.Add(rbFDCircle);
            tabPage2.Controls.Add(cbFDDraw);
            tabPage2.Controls.Add(cbFDEnabled);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Size = new System.Drawing.Size(759, 1056);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Face detector";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbFDMosaic
            // 
            cbFDMosaic.AutoSize = true;
            cbFDMosaic.Location = new System.Drawing.Point(377, 523);
            cbFDMosaic.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFDMosaic.Name = "cbFDMosaic";
            cbFDMosaic.Size = new System.Drawing.Size(211, 29);
            cbFDMosaic.TabIndex = 156;
            cbFDMosaic.Text = "Draw mosaic on faces";
            cbFDMosaic.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(442, 396);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(20, 25);
            label21.TabIndex = 155;
            label21.Text = "x";
            // 
            // edFDMinFaceHeight
            // 
            edFDMinFaceHeight.Location = new System.Drawing.Point(463, 390);
            edFDMinFaceHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFDMinFaceHeight.Name = "edFDMinFaceHeight";
            edFDMinFaceHeight.Size = new System.Drawing.Size(57, 31);
            edFDMinFaceHeight.TabIndex = 154;
            edFDMinFaceHeight.Text = "100";
            // 
            // edFDMinFaceWidth
            // 
            edFDMinFaceWidth.Location = new System.Drawing.Point(377, 390);
            edFDMinFaceWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFDMinFaceWidth.Name = "edFDMinFaceWidth";
            edFDMinFaceWidth.Size = new System.Drawing.Size(57, 31);
            edFDMinFaceWidth.TabIndex = 153;
            edFDMinFaceWidth.Text = "100";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(371, 360);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(146, 25);
            label20.TabIndex = 152;
            label20.Text = "Minimal face size";
            // 
            // btFDUpdate
            // 
            btFDUpdate.Location = new System.Drawing.Point(30, 710);
            btFDUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btFDUpdate.Name = "btFDUpdate";
            btFDUpdate.Size = new System.Drawing.Size(124, 44);
            btFDUpdate.TabIndex = 149;
            btFDUpdate.Text = "Update";
            btFDUpdate.UseVisualStyleBackColor = true;
            btFDUpdate.Click += btFDUpdate_Click;
            // 
            // cbFDFace
            // 
            cbFDFace.AutoSize = true;
            cbFDFace.Checked = true;
            cbFDFace.CheckState = System.Windows.Forms.CheckState.Checked;
            cbFDFace.Location = new System.Drawing.Point(30, 110);
            cbFDFace.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFDFace.Name = "cbFDFace";
            cbFDFace.Size = new System.Drawing.Size(72, 29);
            cbFDFace.TabIndex = 147;
            cbFDFace.Text = "Face";
            cbFDFace.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(198, 1004);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(274, 25);
            label5.TabIndex = 145;
            label5.Text = "More settings available using API";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 793);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 25);
            label2.TabIndex = 144;
            label2.Text = "Detected faces";
            // 
            // edFDFaces
            // 
            edFDFaces.Location = new System.Drawing.Point(30, 823);
            edFDFaces.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edFDFaces.Multiline = true;
            edFDFaces.Name = "edFDFaces";
            edFDFaces.Size = new System.Drawing.Size(694, 165);
            edFDFaces.TabIndex = 143;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(24, 640);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(548, 25);
            label8.TabIndex = 18;
            label8.Text = "Specifying how much the image size is reduced at each image scale.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(24, 465);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(658, 25);
            label7.TabIndex = 17;
            label7.Text = "Specifying how many neighbors each candidate rectangle should have to retain it.";
            // 
            // lbFDScaleFactor
            // 
            lbFDScaleFactor.AutoSize = true;
            lbFDScaleFactor.Location = new System.Drawing.Point(213, 565);
            lbFDScaleFactor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbFDScaleFactor.Name = "lbFDScaleFactor";
            lbFDScaleFactor.Size = new System.Drawing.Size(46, 25);
            lbFDScaleFactor.TabIndex = 16;
            lbFDScaleFactor.Text = "1.10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 518);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(103, 25);
            label3.TabIndex = 15;
            label3.Text = "Scale factor";
            // 
            // tbFDScaleFactor
            // 
            tbFDScaleFactor.Location = new System.Drawing.Point(30, 548);
            tbFDScaleFactor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbFDScaleFactor.Maximum = 150;
            tbFDScaleFactor.Minimum = 101;
            tbFDScaleFactor.Name = "tbFDScaleFactor";
            tbFDScaleFactor.Size = new System.Drawing.Size(173, 69);
            tbFDScaleFactor.TabIndex = 14;
            tbFDScaleFactor.Value = 110;
            tbFDScaleFactor.Scroll += tbScaleFactor_Scroll;
            // 
            // lbFDMinNeighbors
            // 
            lbFDMinNeighbors.AutoSize = true;
            lbFDMinNeighbors.Location = new System.Drawing.Point(213, 407);
            lbFDMinNeighbors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbFDMinNeighbors.Name = "lbFDMinNeighbors";
            lbFDMinNeighbors.Size = new System.Drawing.Size(22, 25);
            lbFDMinNeighbors.TabIndex = 13;
            lbFDMinNeighbors.Text = "8";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(24, 360);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(210, 25);
            label6.TabIndex = 12;
            label6.Text = "Minimal neighbors count";
            // 
            // tbFDMinNeighbors
            // 
            tbFDMinNeighbors.Location = new System.Drawing.Point(30, 390);
            tbFDMinNeighbors.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbFDMinNeighbors.Maximum = 12;
            tbFDMinNeighbors.Minimum = 3;
            tbFDMinNeighbors.Name = "tbFDMinNeighbors";
            tbFDMinNeighbors.Size = new System.Drawing.Size(173, 69);
            tbFDMinNeighbors.TabIndex = 11;
            tbFDMinNeighbors.Value = 8;
            tbFDMinNeighbors.Scroll += tbMinNeighbors_Scroll;
            // 
            // lbFDDownscale
            // 
            lbFDDownscale.AutoSize = true;
            lbFDDownscale.Location = new System.Drawing.Point(560, 302);
            lbFDDownscale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbFDDownscale.Name = "lbFDDownscale";
            lbFDDownscale.Size = new System.Drawing.Size(36, 25);
            lbFDDownscale.TabIndex = 10;
            lbFDDownscale.Text = "1.0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(371, 254);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(341, 25);
            label4.TabIndex = 9;
            label4.Text = "Downscale video (improves performance)";
            // 
            // tbFDDownscale
            // 
            tbFDDownscale.Location = new System.Drawing.Point(377, 285);
            tbFDDownscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbFDDownscale.Maximum = 30;
            tbFDDownscale.Minimum = 10;
            tbFDDownscale.Name = "tbFDDownscale";
            tbFDDownscale.Size = new System.Drawing.Size(173, 69);
            tbFDDownscale.TabIndex = 8;
            tbFDDownscale.Value = 10;
            tbFDDownscale.Scroll += tbFDDownscale_Scroll;
            // 
            // lbFDSkipFrames
            // 
            lbFDSkipFrames.AutoSize = true;
            lbFDSkipFrames.Location = new System.Drawing.Point(213, 302);
            lbFDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbFDSkipFrames.Name = "lbFDSkipFrames";
            lbFDSkipFrames.Size = new System.Drawing.Size(22, 25);
            lbFDSkipFrames.TabIndex = 7;
            lbFDSkipFrames.Text = "5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 254);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(300, 25);
            label1.TabIndex = 6;
            label1.Text = "Skip frames (improves performance)";
            // 
            // tbFDSkipFrames
            // 
            tbFDSkipFrames.Location = new System.Drawing.Point(30, 285);
            tbFDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbFDSkipFrames.Name = "tbFDSkipFrames";
            tbFDSkipFrames.Size = new System.Drawing.Size(173, 69);
            tbFDSkipFrames.TabIndex = 5;
            tbFDSkipFrames.Value = 5;
            tbFDSkipFrames.Scroll += tbFDSkipFrames_Scroll;
            // 
            // rbFDRectangle
            // 
            rbFDRectangle.AutoSize = true;
            rbFDRectangle.Checked = true;
            rbFDRectangle.Location = new System.Drawing.Point(233, 198);
            rbFDRectangle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbFDRectangle.Name = "rbFDRectangle";
            rbFDRectangle.Size = new System.Drawing.Size(113, 29);
            rbFDRectangle.TabIndex = 4;
            rbFDRectangle.TabStop = true;
            rbFDRectangle.Text = "Rectangle";
            rbFDRectangle.UseVisualStyleBackColor = true;
            // 
            // rbFDCircle
            // 
            rbFDCircle.AutoSize = true;
            rbFDCircle.Location = new System.Drawing.Point(89, 198);
            rbFDCircle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbFDCircle.Name = "rbFDCircle";
            rbFDCircle.Size = new System.Drawing.Size(79, 29);
            rbFDCircle.TabIndex = 3;
            rbFDCircle.Text = "Circle";
            rbFDCircle.UseVisualStyleBackColor = true;
            // 
            // cbFDDraw
            // 
            cbFDDraw.AutoSize = true;
            cbFDDraw.Checked = true;
            cbFDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            cbFDDraw.Location = new System.Drawing.Point(30, 154);
            cbFDDraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFDDraw.Name = "cbFDDraw";
            cbFDDraw.Size = new System.Drawing.Size(79, 29);
            cbFDDraw.TabIndex = 2;
            cbFDDraw.Text = "Draw";
            cbFDDraw.UseVisualStyleBackColor = true;
            // 
            // cbFDEnabled
            // 
            cbFDEnabled.AutoSize = true;
            cbFDEnabled.Location = new System.Drawing.Point(30, 35);
            cbFDEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFDEnabled.Name = "cbFDEnabled";
            cbFDEnabled.Size = new System.Drawing.Size(101, 29);
            cbFDEnabled.TabIndex = 0;
            cbFDEnabled.Text = "Enabled";
            cbFDEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(edCCDetectedCars);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(cbCCDraw);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(cbCCEnabled);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Size = new System.Drawing.Size(759, 1056);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Cars counter";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // edCCDetectedCars
            // 
            edCCDetectedCars.Location = new System.Drawing.Point(173, 168);
            edCCDetectedCars.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edCCDetectedCars.Name = "edCCDetectedCars";
            edCCDetectedCars.ReadOnly = true;
            edCCDetectedCars.Size = new System.Drawing.Size(81, 31);
            edCCDetectedCars.TabIndex = 149;
            edCCDetectedCars.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(24, 172);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(119, 25);
            label12.TabIndex = 148;
            label12.Text = "Detected cars";
            // 
            // cbCCDraw
            // 
            cbCCDraw.AutoSize = true;
            cbCCDraw.Location = new System.Drawing.Point(30, 104);
            cbCCDraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCCDraw.Name = "cbCCDraw";
            cbCCDraw.Size = new System.Drawing.Size(79, 29);
            cbCCDraw.TabIndex = 147;
            cbCCDraw.Text = "Draw";
            cbCCDraw.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(221, 457);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(274, 25);
            label10.TabIndex = 146;
            label10.Text = "More settings available using API";
            // 
            // cbCCEnabled
            // 
            cbCCEnabled.AutoSize = true;
            cbCCEnabled.Location = new System.Drawing.Point(30, 35);
            cbCCEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbCCEnabled.Name = "cbCCEnabled";
            cbCCEnabled.Size = new System.Drawing.Size(101, 29);
            cbCCEnabled.TabIndex = 1;
            cbCCEnabled.Text = "Enabled";
            cbCCEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(lbPDSkipFrames);
            tabPage5.Controls.Add(label19);
            tabPage5.Controls.Add(tbPDSkipFrames);
            tabPage5.Controls.Add(lbPDDownscale);
            tabPage5.Controls.Add(label14);
            tabPage5.Controls.Add(label15);
            tabPage5.Controls.Add(edPDDetected);
            tabPage5.Controls.Add(label16);
            tabPage5.Controls.Add(tbPDDownscale);
            tabPage5.Controls.Add(cbPDDraw);
            tabPage5.Controls.Add(cbPDEnabled);
            tabPage5.Location = new System.Drawing.Point(4, 34);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage5.Size = new System.Drawing.Size(759, 1056);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Pedestrian detector";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbPDSkipFrames
            // 
            lbPDSkipFrames.AutoSize = true;
            lbPDSkipFrames.Location = new System.Drawing.Point(213, 244);
            lbPDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbPDSkipFrames.Name = "lbPDSkipFrames";
            lbPDSkipFrames.Size = new System.Drawing.Size(22, 25);
            lbPDSkipFrames.TabIndex = 156;
            lbPDSkipFrames.Text = "5";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(24, 196);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(300, 25);
            label19.TabIndex = 155;
            label19.Text = "Skip frames (improves performance)";
            // 
            // tbPDSkipFrames
            // 
            tbPDSkipFrames.Location = new System.Drawing.Point(30, 228);
            tbPDSkipFrames.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbPDSkipFrames.Name = "tbPDSkipFrames";
            tbPDSkipFrames.Size = new System.Drawing.Size(173, 69);
            tbPDSkipFrames.TabIndex = 154;
            tbPDSkipFrames.Value = 5;
            tbPDSkipFrames.Scroll += tbPDSkipFrames_Scroll;
            // 
            // lbPDDownscale
            // 
            lbPDDownscale.AutoSize = true;
            lbPDDownscale.Location = new System.Drawing.Point(577, 248);
            lbPDDownscale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbPDDownscale.Name = "lbPDDownscale";
            lbPDDownscale.Size = new System.Drawing.Size(36, 25);
            lbPDDownscale.TabIndex = 153;
            lbPDDownscale.Text = "1.0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(213, 695);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(274, 25);
            label14.TabIndex = 152;
            label14.Text = "More settings available using API";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(30, 382);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(179, 25);
            label15.TabIndex = 151;
            label15.Text = "Detected pedestrians";
            // 
            // edPDDetected
            // 
            edPDDetected.Location = new System.Drawing.Point(30, 413);
            edPDDetected.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edPDDetected.Multiline = true;
            edPDDetected.Name = "edPDDetected";
            edPDDetected.Size = new System.Drawing.Size(694, 240);
            edPDDetected.TabIndex = 150;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(389, 196);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(341, 25);
            label16.TabIndex = 149;
            label16.Text = "Downscale video (improves performance)";
            // 
            // tbPDDownscale
            // 
            tbPDDownscale.Location = new System.Drawing.Point(393, 228);
            tbPDDownscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbPDDownscale.Maximum = 30;
            tbPDDownscale.Minimum = 10;
            tbPDDownscale.Name = "tbPDDownscale";
            tbPDDownscale.Size = new System.Drawing.Size(173, 69);
            tbPDDownscale.TabIndex = 148;
            tbPDDownscale.Value = 10;
            tbPDDownscale.Scroll += tbPDDownscale_Scroll;
            // 
            // cbPDDraw
            // 
            cbPDDraw.AutoSize = true;
            cbPDDraw.Checked = true;
            cbPDDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            cbPDDraw.Location = new System.Drawing.Point(30, 104);
            cbPDDraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbPDDraw.Name = "cbPDDraw";
            cbPDDraw.Size = new System.Drawing.Size(79, 29);
            cbPDDraw.TabIndex = 147;
            cbPDDraw.Text = "Draw";
            cbPDDraw.UseVisualStyleBackColor = true;
            // 
            // cbPDEnabled
            // 
            cbPDEnabled.AutoSize = true;
            cbPDEnabled.Location = new System.Drawing.Point(30, 35);
            cbPDEnabled.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbPDEnabled.Name = "cbPDEnabled";
            cbPDEnabled.Size = new System.Drawing.Size(101, 29);
            cbPDEnabled.TabIndex = 146;
            cbPDEnabled.Text = "Enabled";
            cbPDEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(cbDebugMode);
            tabPage3.Controls.Add(mmLog);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage3.Size = new System.Drawing.Size(759, 1056);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Debug";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(30, 35);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 75;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(30, 79);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(691, 432);
            mmLog.TabIndex = 74;
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.FileName = "openFileDialog1";
            // 
            // VideoCaptureView
            // 
            VideoCaptureView.BackColor = System.Drawing.Color.Black;
            VideoCaptureView.Location = new System.Drawing.Point(797, 22);
            VideoCaptureView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            VideoCaptureView.Name = "VideoCaptureView";
            VideoCaptureView.Size = new System.Drawing.Size(783, 516);
            VideoCaptureView.TabIndex = 85;
            // 
            // MediaPlayerView
            // 
            MediaPlayerView.BackColor = System.Drawing.Color.Black;
            MediaPlayerView.Location = new System.Drawing.Point(797, 22);
            MediaPlayerView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            MediaPlayerView.Name = "MediaPlayerView";
            MediaPlayerView.Size = new System.Drawing.Size(783, 516);
            MediaPlayerView.TabIndex = 84;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1600, 1147);
            Controls.Add(VideoCaptureView);
            Controls.Add(MediaPlayerView);
            Controls.Add(tcMain);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "Form1";
            Text = "Computer Vision Demo - Video Capture SDK .Net (Cross-platform engine)";
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbFDScaleFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbFDMinNeighbors).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbFDDownscale).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbFDSkipFrames).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPDSkipFrames).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPDDownscale).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbVideoCaptureDevice;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edIPUrl;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.RadioButton rbIPCamera;
        private System.Windows.Forms.TextBox edIPPassword;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label166;
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
        private System.Windows.Forms.CheckBox cbFDFace;
        private System.Windows.Forms.Button btFDUpdate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox edFDMinFaceHeight;
        private System.Windows.Forms.TextBox edFDMinFaceWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbFDMosaic;
        private VisioForge.Core.UI.WinForms.VideoView MediaPlayerView;
        private VisioForge.Core.UI.WinForms.VideoView VideoCaptureView;
    }
}

