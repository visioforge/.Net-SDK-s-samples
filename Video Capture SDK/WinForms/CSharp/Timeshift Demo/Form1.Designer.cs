﻿using System;

namespace VC_Timeshift_Demo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbIPCamera = new System.Windows.Forms.RadioButton();
            this.rbVideoCaptureDevice = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.cbUseAudioInputFromVideoCaptureDevice = new System.Windows.Forms.CheckBox();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cbIPCameraType = new System.Windows.Forms.ComboBox();
            this.label168 = new System.Windows.Forms.Label();
            this.cbIPAudioCapture = new System.Windows.Forms.CheckBox();
            this.cbIPURL = new System.Windows.Forms.ComboBox();
            this.label165 = new System.Windows.Forms.Label();
            this.edIPPassword = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.edIPLogin = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MediaPlayer1 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.cbPlayerPlayAudio = new System.Windows.Forms.CheckBox();
            this.lbPostion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.btPlayerResume = new System.Windows.Forms.Button();
            this.btPlayerPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbIPCamera);
            this.groupBox1.Controls.Add(this.rbVideoCaptureDevice);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.VideoCapture1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 631);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Source";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rbIPCamera
            // 
            this.rbIPCamera.AutoSize = true;
            this.rbIPCamera.Location = new System.Drawing.Point(207, 286);
            this.rbIPCamera.Name = "rbIPCamera";
            this.rbIPCamera.Size = new System.Drawing.Size(73, 17);
            this.rbIPCamera.TabIndex = 4;
            this.rbIPCamera.Text = "IP camera";
            this.rbIPCamera.UseVisualStyleBackColor = true;
            // 
            // rbVideoCaptureDevice
            // 
            this.rbVideoCaptureDevice.AutoSize = true;
            this.rbVideoCaptureDevice.Checked = true;
            this.rbVideoCaptureDevice.Location = new System.Drawing.Point(66, 286);
            this.rbVideoCaptureDevice.Name = "rbVideoCaptureDevice";
            this.rbVideoCaptureDevice.Size = new System.Drawing.Size(126, 17);
            this.rbVideoCaptureDevice.TabIndex = 3;
            this.rbVideoCaptureDevice.TabStop = true;
            this.rbVideoCaptureDevice.Text = "Video capture device";
            this.rbVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 257);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.cbOutputFormat);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.btSelectOutput);
            this.tabPage4.Controls.Add(this.edOutput);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(435, 231);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Output";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Default format settings used";
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "Do not record",
            "AVI",
            "MP4",
            "WebM"});
            this.cbOutputFormat.Location = new System.Drawing.Point(18, 28);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(202, 21);
            this.cbOutputFormat.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Output format";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(405, 75);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 48;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(18, 77);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(381, 20);
            this.edOutput.TabIndex = 47;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "File name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(435, 231);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(6, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 74;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(6, 24);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(423, 201);
            this.mmLog.TabIndex = 73;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage5.Controls.Add(this.cbUseAudioInputFromVideoCaptureDevice);
            this.tabPage5.Controls.Add(this.cbAudioInputLine);
            this.tabPage5.Controls.Add(this.cbAudioInputFormat);
            this.tabPage5.Controls.Add(this.cbAudioInputDevice);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label28);
            this.tabPage5.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage5.Controls.Add(this.cbVideoInputFormat);
            this.tabPage5.Controls.Add(this.cbVideoInputDevice);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(435, 231);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Video capture device source";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(353, 174);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestAudioInputFormat.TabIndex = 143;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            // 
            // cbUseAudioInputFromVideoCaptureDevice
            // 
            this.cbUseAudioInputFromVideoCaptureDevice.AutoSize = true;
            this.cbUseAudioInputFromVideoCaptureDevice.Location = new System.Drawing.Point(232, 126);
            this.cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice";
            this.cbUseAudioInputFromVideoCaptureDevice.Size = new System.Drawing.Size(187, 17);
            this.cbUseAudioInputFromVideoCaptureDevice.TabIndex = 142;
            this.cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source";
            this.cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(16, 192);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(190, 21);
            this.cbAudioInputLine.TabIndex = 141;
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(232, 192);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(190, 21);
            this.cbAudioInputFormat.TabIndex = 140;
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(16, 144);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(406, 21);
            this.cbAudioInputDevice.TabIndex = 139;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 138;
            this.label14.Text = "Audio input line";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 137;
            this.label12.Text = "Audio input device";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Audio input format";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(303, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 135;
            this.label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(153, 64);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 134;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(229, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 133;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(232, 81);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(65, 21);
            this.cbVideoInputFrameRate.TabIndex = 132;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(16, 81);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(208, 21);
            this.cbVideoInputFormat.TabIndex = 131;
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(16, 32);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(406, 21);
            this.cbVideoInputDevice.TabIndex = 130;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 129;
            this.label13.Text = "Video input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 128;
            this.label11.Text = "Video input device";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cbIPCameraType);
            this.tabPage6.Controls.Add(this.label168);
            this.tabPage6.Controls.Add(this.cbIPAudioCapture);
            this.tabPage6.Controls.Add(this.cbIPURL);
            this.tabPage6.Controls.Add(this.label165);
            this.tabPage6.Controls.Add(this.edIPPassword);
            this.tabPage6.Controls.Add(this.label167);
            this.tabPage6.Controls.Add(this.edIPLogin);
            this.tabPage6.Controls.Add(this.label166);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(435, 231);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "IP camera source";
            this.tabPage6.UseVisualStyleBackColor = true;
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
            this.cbIPCameraType.Location = new System.Drawing.Point(56, 116);
            this.cbIPCameraType.Name = "cbIPCameraType";
            this.cbIPCameraType.Size = new System.Drawing.Size(188, 21);
            this.cbIPCameraType.TabIndex = 95;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(10, 119);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(40, 13);
            this.label168.TabIndex = 94;
            this.label168.Text = "Engine";
            // 
            // cbIPAudioCapture
            // 
            this.cbIPAudioCapture.AutoSize = true;
            this.cbIPAudioCapture.Location = new System.Drawing.Point(274, 76);
            this.cbIPAudioCapture.Name = "cbIPAudioCapture";
            this.cbIPAudioCapture.Size = new System.Drawing.Size(92, 17);
            this.cbIPAudioCapture.TabIndex = 93;
            this.cbIPAudioCapture.Text = "Capture audio";
            this.cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // cbIPURL
            // 
            this.cbIPURL.FormattingEnabled = true;
            this.cbIPURL.Location = new System.Drawing.Point(56, 18);
            this.cbIPURL.Name = "cbIPURL";
            this.cbIPURL.Size = new System.Drawing.Size(360, 21);
            this.cbIPURL.TabIndex = 92;
            this.cbIPURL.Text = "rtsp://192.168.1.101:554/stream1";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(10, 21);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(29, 13);
            this.label165.TabIndex = 91;
            this.label165.Text = "URL";
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(144, 74);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(100, 20);
            this.edIPPassword.TabIndex = 90;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(141, 57);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(53, 13);
            this.label167.TabIndex = 89;
            this.label167.Text = "Password";
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(13, 74);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(100, 20);
            this.edIPLogin.TabIndex = 88;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(10, 57);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(33, 13);
            this.label166.TabIndex = 87;
            this.label166.Text = "Login";
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
            this.VideoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.VideoCapture1.BDA_Source = null;
            this.VideoCapture1.ChromaKey = null;
            this.VideoCapture1.Custom_Source = null;
            this.VideoCapture1.CustomRedist_Auto = true;
            this.VideoCapture1.CustomRedist_Enabled = false;
            this.VideoCapture1.CustomRedist_Path = null;
            this.VideoCapture1.Debug_Dir = "";
            this.VideoCapture1.Debug_DisableMessageDialogs = false;
            this.VideoCapture1.Debug_Mode = false;
            this.VideoCapture1.Debug_Telemetry = true;
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
            this.VideoCapture1.Location = new System.Drawing.Point(6, 319);
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
            this.VideoCapture1.Network_Streaming_Network_Port = 100;
            this.VideoCapture1.Network_Streaming_Output = null;
            this.VideoCapture1.Network_Streaming_URL = "";
            this.VideoCapture1.Network_Streaming_WMV_Maximum_Clients = 10;
            this.VideoCapture1.OSD_Enabled = false;
            this.VideoCapture1.Output_Filename = "C:\\Users\\roman\\Documents\\VisioForge\\output.avi";
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
            this.VideoCapture1.Size = new System.Drawing.Size(439, 298);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 1;
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
            this.VideoCapture1.Video_CaptureDevice_FrameRate = 25D;
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
            this.VideoCapture1.Video_Sample_Grabber_Enabled = true;
            this.VideoCapture1.Video_Sample_Grabber_UseForVideoEffects = true;
            this.VideoCapture1.Video_Still_Frames_Grabber_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_LicenseKey = null;
            this.VideoCapture1.VLC_Path = null;
            this.VideoCapture1.OnTimeshiftFileCreated += new System.EventHandler<VisioForge.Types.TimeshiftFileEventArgs>(this.VideoCapture1_OnTimeshiftFileCreated);
            this.VideoCapture1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoCapture1_OnError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MediaPlayer1);
            this.groupBox2.Controls.Add(this.cbPlayerPlayAudio);
            this.groupBox2.Controls.Add(this.lbPostion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbDuration);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Controls.Add(this.btPlayerResume);
            this.groupBox2.Controls.Add(this.btPlayerPause);
            this.groupBox2.Location = new System.Drawing.Point(471, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 481);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player";
            // 
            // MediaPlayer1
            // 
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
            this.MediaPlayer1.Debug_Telemetry = true;
            this.MediaPlayer1.Encryption_Key = "";
            this.MediaPlayer1.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer1.Face_Tracking = null;
            this.MediaPlayer1.Info_UseLibMediaInfo = false;
            this.MediaPlayer1.Location = new System.Drawing.Point(6, 73);
            this.MediaPlayer1.Loop = false;
            this.MediaPlayer1.Loop_DoNotSeekToBeginning = false;
            this.MediaPlayer1.MaximalSpeedPlayback = false;
            this.MediaPlayer1.MIDI_Renderer = null;
            this.MediaPlayer1.Motion_Detection = null;
            this.MediaPlayer1.Motion_DetectionEx = null;
            this.MediaPlayer1.MultiScreen_Enabled = false;
            this.MediaPlayer1.Name = "MediaPlayer1";
            this.MediaPlayer1.NDI_Output = null;
            this.MediaPlayer1.OSD_Enabled = false;
            this.MediaPlayer1.Play_DelayEnabled = false;
            this.MediaPlayer1.Play_PauseAtFirstFrame = false;
            this.MediaPlayer1.ReversePlayback_CacheSize = 0;
            this.MediaPlayer1.ReversePlayback_Enabled = false;
            this.MediaPlayer1.Selection_Active = false;
            this.MediaPlayer1.Selection_Start = 0;
            this.MediaPlayer1.Selection_Stop = 0;
            this.MediaPlayer1.Size = new System.Drawing.Size(441, 303);
            this.MediaPlayer1.Source_Custom_CLSID = null;
            this.MediaPlayer1.Source_GPU_Mode = VisioForge.Types.VFMediaPlayerSourceGPUDecoder.nVidiaCUVID;
            this.MediaPlayer1.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer1.Source_Stream = null;
            this.MediaPlayer1.Source_Stream_AudioPresent = true;
            this.MediaPlayer1.Source_Stream_Size = ((long)(0));
            this.MediaPlayer1.Source_Stream_VideoPresent = true;
            this.MediaPlayer1.TabIndex = 8;
            this.MediaPlayer1.Video_Effects_Enabled = false;
            this.MediaPlayer1.Video_Effects_GPU_Enabled = false;
            this.MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer1.Video_Stream_Index = 0;
            this.MediaPlayer1.Virtual_Camera_Output_Enabled = false;
            this.MediaPlayer1.Virtual_Camera_Output_LicenseKey = null;
            this.MediaPlayer1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.MediaPlayer1_OnError);
            // 
            // cbPlayerPlayAudio
            // 
            this.cbPlayerPlayAudio.AutoSize = true;
            this.cbPlayerPlayAudio.Location = new System.Drawing.Point(6, 19);
            this.cbPlayerPlayAudio.Name = "cbPlayerPlayAudio";
            this.cbPlayerPlayAudio.Size = new System.Drawing.Size(75, 17);
            this.cbPlayerPlayAudio.TabIndex = 7;
            this.cbPlayerPlayAudio.Text = "Play audio";
            this.cbPlayerPlayAudio.UseVisualStyleBackColor = true;
            // 
            // lbPostion
            // 
            this.lbPostion.AutoSize = true;
            this.lbPostion.Location = new System.Drawing.Point(330, 398);
            this.lbPostion.Name = "lbPostion";
            this.lbPostion.Size = new System.Drawing.Size(49, 13);
            this.lbPostion.TabIndex = 6;
            this.lbPostion.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "/";
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.Location = new System.Drawing.Point(391, 398);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(49, 13);
            this.lbDuration.TabIndex = 4;
            this.lbDuration.Text = "00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(6, 422);
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(434, 45);
            this.tbTimeline.TabIndex = 3;
            this.tbTimeline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbTimeline_MouseDown);
            this.tbTimeline.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbTimeline_MouseUp);
            // 
            // btPlayerResume
            // 
            this.btPlayerResume.Location = new System.Drawing.Point(87, 393);
            this.btPlayerResume.Name = "btPlayerResume";
            this.btPlayerResume.Size = new System.Drawing.Size(75, 23);
            this.btPlayerResume.TabIndex = 2;
            this.btPlayerResume.Text = "Resume";
            this.btPlayerResume.UseVisualStyleBackColor = true;
            this.btPlayerResume.Click += new System.EventHandler(this.btPlayerResume_Click);
            // 
            // btPlayerPause
            // 
            this.btPlayerPause.Location = new System.Drawing.Point(6, 393);
            this.btPlayerPause.Name = "btPlayerPause";
            this.btPlayerPause.Size = new System.Drawing.Size(75, 23);
            this.btPlayerPause.TabIndex = 1;
            this.btPlayerPause.Text = "Pause";
            this.btPlayerPause.UseVisualStyleBackColor = true;
            this.btPlayerPause.Click += new System.EventHandler(this.btPlayerPause_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(80, 649);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 44;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(12, 649);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 43;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 684);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Capture SDK .Net - Timeshift Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Button btPlayerResume;
        private System.Windows.Forms.Button btPlayerPause;
        private System.Windows.Forms.Label lbPostion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbPlayerPlayAudio;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.CheckBox cbUseAudioInputFromVideoCaptureDevice;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbIPCamera;
        private System.Windows.Forms.RadioButton rbVideoCaptureDevice;
        private System.Windows.Forms.ComboBox cbIPURL;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.TextBox edIPPassword;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.TextBox edIPLogin;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.CheckBox cbIPAudioCapture;
        private System.Windows.Forms.ComboBox cbIPCameraType;
        private System.Windows.Forms.Label label168;
    }
}

