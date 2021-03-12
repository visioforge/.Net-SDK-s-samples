using System;

namespace VisioForge_SDK_4_IP_Camera_CSharp_Demo
{
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
                
#if !NETCOREAPP
                if (onvifControl != null)
                {
                    onvifControl.Dispose();
                    onvifControl = null;
                }
#endif
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl15 = new System.Windows.Forms.TabControl();
            this.tabPage144 = new System.Windows.Forms.TabPage();
            this.cbIPURL = new System.Windows.Forms.ComboBox();
            this.btListNDISources = new System.Windows.Forms.Button();
            this.lbNDI = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.cbIPCameraONVIF = new System.Windows.Forms.CheckBox();
            this.btShowIPCamDatabase = new System.Windows.Forms.Button();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btOutputConfigure = new System.Windows.Forms.Button();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.cbInvert = new System.Windows.Forms.CheckBox();
            this.cbGreyscale = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.tbDarkness = new System.Windows.Forms.TrackBar();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbLightness = new System.Windows.Forms.TrackBar();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btTextLogoAdd = new System.Windows.Forms.Button();
            this.btLogoRemove = new System.Windows.Forms.Button();
            this.btLogoEdit = new System.Windows.Forms.Button();
            this.lbLogos = new System.Windows.Forms.ListBox();
            this.btImageLogoAdd = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.rbCapture = new System.Windows.Forms.RadioButton();
            this.rbPreview = new System.Windows.Forms.RadioButton();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.llVideoTutorials = new System.Windows.Forms.LinkLabel();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.label2 = new System.Windows.Forms.Label();
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl15.SuspendLayout();
            this.tabPage144.SuspendLayout();
            this.tabPage146.SuspendLayout();
            this.tabPage145.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage7);
            this.tcMain.Location = new System.Drawing.Point(3, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(471, 376);
            this.tcMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl15);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl15
            // 
            this.tabControl15.Controls.Add(this.tabPage144);
            this.tabControl15.Controls.Add(this.tabPage146);
            this.tabControl15.Controls.Add(this.tabPage145);
            this.tabControl15.Location = new System.Drawing.Point(8, 6);
            this.tabControl15.Name = "tabControl15";
            this.tabControl15.SelectedIndex = 0;
            this.tabControl15.Size = new System.Drawing.Size(447, 314);
            this.tabControl15.TabIndex = 65;
            // 
            // tabPage144
            // 
            this.tabPage144.Controls.Add(this.cbIPURL);
            this.tabPage144.Controls.Add(this.btListNDISources);
            this.tabPage144.Controls.Add(this.lbNDI);
            this.tabPage144.Controls.Add(this.label6);
            this.tabPage144.Controls.Add(this.linkLabel1);
            this.tabPage144.Controls.Add(this.label1);
            this.tabPage144.Controls.Add(this.label165);
            this.tabPage144.Controls.Add(this.cbIPCameraONVIF);
            this.tabPage144.Controls.Add(this.btShowIPCamDatabase);
            this.tabPage144.Controls.Add(this.linkLabel7);
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
            this.tabPage144.Size = new System.Drawing.Size(439, 288);
            this.tabPage144.TabIndex = 0;
            this.tabPage144.Text = "Main";
            this.tabPage144.UseVisualStyleBackColor = true;
            // 
            // cbIPURL
            // 
            this.cbIPURL.FormattingEnabled = true;
            this.cbIPURL.Location = new System.Drawing.Point(57, 10);
            this.cbIPURL.Name = "cbIPURL";
            this.cbIPURL.Size = new System.Drawing.Size(360, 21);
            this.cbIPURL.TabIndex = 86;
            this.cbIPURL.Text = "rtsp://192.168.1.101:554/stream1";
            // 
            // btListNDISources
            // 
            this.btListNDISources.Location = new System.Drawing.Point(294, 86);
            this.btListNDISources.Name = "btListNDISources";
            this.btListNDISources.Size = new System.Drawing.Size(123, 23);
            this.btListNDISources.TabIndex = 85;
            this.btListNDISources.Text = "List NDI sources";
            this.btListNDISources.UseVisualStyleBackColor = true;
            this.btListNDISources.Click += new System.EventHandler(this.btListNDISources_Click);
            // 
            // lbNDI
            // 
            this.lbNDI.AutoSize = true;
            this.lbNDI.Location = new System.Drawing.Point(260, 220);
            this.lbNDI.Name = "lbNDI";
            this.lbNDI.Size = new System.Drawing.Size(86, 13);
            this.lbNDI.TabIndex = 84;
            this.lbNDI.TabStop = true;
            this.lbNDI.Text = "vendor\'s website";
            this.lbNDI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbNDI_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(374, 198);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(24, 13);
            this.linkLabel1.TabIndex = 82;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "x64";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Please install VLC redist EXE or NuGet package to use VLC engine ";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(11, 13);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(29, 13);
            this.label165.TabIndex = 79;
            this.label165.Text = "URL";
            // 
            // cbIPCameraONVIF
            // 
            this.cbIPCameraONVIF.AutoSize = true;
            this.cbIPCameraONVIF.Location = new System.Drawing.Point(294, 43);
            this.cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            this.cbIPCameraONVIF.Size = new System.Drawing.Size(96, 17);
            this.cbIPCameraONVIF.TabIndex = 78;
            this.cbIPCameraONVIF.Text = "ONVIF camera";
            this.cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // btShowIPCamDatabase
            // 
            this.btShowIPCamDatabase.Location = new System.Drawing.Point(294, 259);
            this.btShowIPCamDatabase.Name = "btShowIPCamDatabase";
            this.btShowIPCamDatabase.Size = new System.Drawing.Size(135, 23);
            this.btShowIPCamDatabase.TabIndex = 77;
            this.btShowIPCamDatabase.Text = "Show IP cam database";
            this.btShowIPCamDatabase.UseVisualStyleBackColor = true;
            this.btShowIPCamDatabase.Click += new System.EventHandler(this.btShowIPCamDatabase_Click);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(344, 198);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(24, 13);
            this.linkLabel7.TabIndex = 76;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "x86";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // cbIPDisconnect
            // 
            this.cbIPDisconnect.AutoSize = true;
            this.cbIPDisconnect.Location = new System.Drawing.Point(15, 158);
            this.cbIPDisconnect.Name = "cbIPDisconnect";
            this.cbIPDisconnect.Size = new System.Drawing.Size(136, 17);
            this.cbIPDisconnect.TabIndex = 75;
            this.cbIPDisconnect.Text = "Notify if connection lost";
            this.cbIPDisconnect.UseVisualStyleBackColor = true;
            // 
            // edIPForcedFramerateID
            // 
            this.edIPForcedFramerateID.Location = new System.Drawing.Point(267, 131);
            this.edIPForcedFramerateID.Margin = new System.Windows.Forms.Padding(2);
            this.edIPForcedFramerateID.Name = "edIPForcedFramerateID";
            this.edIPForcedFramerateID.Size = new System.Drawing.Size(32, 20);
            this.edIPForcedFramerateID.TabIndex = 71;
            this.edIPForcedFramerateID.Text = "0";
            // 
            // label344
            // 
            this.label344.AutoSize = true;
            this.label344.Location = new System.Drawing.Point(165, 133);
            this.label344.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label344.Name = "label344";
            this.label344.Size = new System.Drawing.Size(98, 13);
            this.label344.TabIndex = 70;
            this.label344.Text = "Force frame rate ID";
            // 
            // edIPForcedFramerate
            // 
            this.edIPForcedFramerate.Location = new System.Drawing.Point(114, 131);
            this.edIPForcedFramerate.Margin = new System.Windows.Forms.Padding(2);
            this.edIPForcedFramerate.Name = "edIPForcedFramerate";
            this.edIPForcedFramerate.Size = new System.Drawing.Size(32, 20);
            this.edIPForcedFramerate.TabIndex = 69;
            this.edIPForcedFramerate.Text = "0";
            // 
            // label295
            // 
            this.label295.AutoSize = true;
            this.label295.Location = new System.Drawing.Point(12, 133);
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
            this.cbIPCameraType.Location = new System.Drawing.Point(57, 41);
            this.cbIPCameraType.Name = "cbIPCameraType";
            this.cbIPCameraType.Size = new System.Drawing.Size(227, 21);
            this.cbIPCameraType.TabIndex = 67;
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(168, 89);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(100, 20);
            this.edIPPassword.TabIndex = 66;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(165, 72);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(53, 13);
            this.label167.TabIndex = 65;
            this.label167.Text = "Password";
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(15, 89);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(100, 20);
            this.edIPLogin.TabIndex = 64;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(11, 72);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(33, 13);
            this.label166.TabIndex = 63;
            this.label166.Text = "Login";
            // 
            // cbIPAudioCapture
            // 
            this.cbIPAudioCapture.AutoSize = true;
            this.cbIPAudioCapture.Location = new System.Drawing.Point(168, 158);
            this.cbIPAudioCapture.Name = "cbIPAudioCapture";
            this.cbIPAudioCapture.Size = new System.Drawing.Size(92, 17);
            this.cbIPAudioCapture.TabIndex = 62;
            this.cbIPAudioCapture.Text = "Capture audio";
            this.cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(11, 45);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(40, 13);
            this.label168.TabIndex = 61;
            this.label168.Text = "Engine";
            // 
            // tabPage146
            // 
            this.tabPage146.Controls.Add(this.cbVLCZeroClockJitter);
            this.tabPage146.Controls.Add(this.edVLCCacheSize);
            this.tabPage146.Controls.Add(this.label312);
            this.tabPage146.Location = new System.Drawing.Point(4, 22);
            this.tabPage146.Name = "tabPage146";
            this.tabPage146.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage146.Size = new System.Drawing.Size(439, 288);
            this.tabPage146.TabIndex = 2;
            this.tabPage146.Text = "VLC";
            this.tabPage146.UseVisualStyleBackColor = true;
            // 
            // cbVLCZeroClockJitter
            // 
            this.cbVLCZeroClockJitter.AutoSize = true;
            this.cbVLCZeroClockJitter.Location = new System.Drawing.Point(173, 16);
            this.cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter";
            this.cbVLCZeroClockJitter.Size = new System.Drawing.Size(120, 17);
            this.cbVLCZeroClockJitter.TabIndex = 78;
            this.cbVLCZeroClockJitter.Text = "VLC zero clock jitter";
            this.cbVLCZeroClockJitter.UseVisualStyleBackColor = true;
            // 
            // edVLCCacheSize
            // 
            this.edVLCCacheSize.Location = new System.Drawing.Point(119, 14);
            this.edVLCCacheSize.Name = "edVLCCacheSize";
            this.edVLCCacheSize.Size = new System.Drawing.Size(32, 20);
            this.edVLCCacheSize.TabIndex = 77;
            this.edVLCCacheSize.Text = "1000";
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
            this.tabPage145.Size = new System.Drawing.Size(439, 288);
            this.tabPage145.TabIndex = 1;
            this.tabPage145.Text = "ONVIF";
            this.tabPage145.UseVisualStyleBackColor = true;
            // 
            // edONVIFPassword
            // 
            this.edONVIFPassword.Location = new System.Drawing.Point(244, 42);
            this.edONVIFPassword.Name = "edONVIFPassword";
            this.edONVIFPassword.Size = new System.Drawing.Size(100, 20);
            this.edONVIFPassword.TabIndex = 75;
            // 
            // label378
            // 
            this.label378.AutoSize = true;
            this.label378.Location = new System.Drawing.Point(186, 45);
            this.label378.Name = "label378";
            this.label378.Size = new System.Drawing.Size(53, 13);
            this.label378.TabIndex = 74;
            this.label378.Text = "Password";
            // 
            // edONVIFLogin
            // 
            this.edONVIFLogin.Location = new System.Drawing.Point(79, 42);
            this.edONVIFLogin.Name = "edONVIFLogin";
            this.edONVIFLogin.Size = new System.Drawing.Size(100, 20);
            this.edONVIFLogin.TabIndex = 73;
            // 
            // label379
            // 
            this.label379.AutoSize = true;
            this.label379.Location = new System.Drawing.Point(15, 45);
            this.label379.Name = "label379";
            this.label379.Size = new System.Drawing.Size(33, 13);
            this.label379.TabIndex = 72;
            this.label379.Text = "Login";
            // 
            // edONVIFURL
            // 
            this.edONVIFURL.Location = new System.Drawing.Point(18, 12);
            this.edONVIFURL.Name = "edONVIFURL";
            this.edONVIFURL.Size = new System.Drawing.Size(326, 20);
            this.edONVIFURL.TabIndex = 71;
            this.edONVIFURL.Text = "http://192.168.1.101:2020/onvif/device_service";
            // 
            // edONVIFLiveVideoURL
            // 
            this.edONVIFLiveVideoURL.Location = new System.Drawing.Point(78, 138);
            this.edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL";
            this.edONVIFLiveVideoURL.ReadOnly = true;
            this.edONVIFLiveVideoURL.Size = new System.Drawing.Size(346, 20);
            this.edONVIFLiveVideoURL.TabIndex = 28;
            // 
            // label513
            // 
            this.label513.AutoSize = true;
            this.label513.Location = new System.Drawing.Point(14, 141);
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
            this.groupBox42.Location = new System.Drawing.Point(15, 168);
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
            this.cbONVIFProfile.Location = new System.Drawing.Point(78, 112);
            this.cbONVIFProfile.Name = "cbONVIFProfile";
            this.cbONVIFProfile.Size = new System.Drawing.Size(346, 21);
            this.cbONVIFProfile.TabIndex = 4;
            this.cbONVIFProfile.SelectedIndexChanged += new System.EventHandler(this.cbONVIFProfile_SelectedIndexChanged);
            // 
            // label510
            // 
            this.label510.AutoSize = true;
            this.label510.Location = new System.Drawing.Point(15, 115);
            this.label510.Name = "label510";
            this.label510.Size = new System.Drawing.Size(36, 13);
            this.label510.TabIndex = 3;
            this.label510.Text = "Profile";
            // 
            // lbONVIFCameraInfo
            // 
            this.lbONVIFCameraInfo.AutoSize = true;
            this.lbONVIFCameraInfo.Location = new System.Drawing.Point(14, 85);
            this.lbONVIFCameraInfo.Name = "lbONVIFCameraInfo";
            this.lbONVIFCameraInfo.Size = new System.Drawing.Size(69, 13);
            this.lbONVIFCameraInfo.TabIndex = 1;
            this.lbONVIFCameraInfo.Text = "Status: None";
            // 
            // btONVIFConnect
            // 
            this.btONVIFConnect.Location = new System.Drawing.Point(349, 10);
            this.btONVIFConnect.Name = "btONVIFConnect";
            this.btONVIFConnect.Size = new System.Drawing.Size(75, 23);
            this.btONVIFConnect.TabIndex = 0;
            this.btONVIFConnect.Text = "Connect";
            this.btONVIFConnect.UseVisualStyleBackColor = true;
            this.btONVIFConnect.Click += new System.EventHandler(this.btONVIFConnect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOutput);
            this.tabPage2.Controls.Add(this.edOutput);
            this.tabPage2.Controls.Add(this.lbInfo);
            this.tabPage2.Controls.Add(this.btOutputConfigure);
            this.tabPage2.Controls.Add(this.cbOutputFormat);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(433, 155);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 120;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(12, 157);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(415, 20);
            this.edOutput.TabIndex = 119;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(9, 57);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 118;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            this.btOutputConfigure.Location = new System.Drawing.Point(12, 73);
            this.btOutputConfigure.Name = "btOutputConfigure";
            this.btOutputConfigure.Size = new System.Drawing.Size(75, 23);
            this.btOutputConfigure.TabIndex = 117;
            this.btOutputConfigure.Text = "Configure";
            this.btOutputConfigure.UseVisualStyleBackColor = true;
            this.btOutputConfigure.Click += new System.EventHandler(this.btOutputConfigure_Click);
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "AVI",
            "WMV (Windows Media Video)",
            "MP4 (v10 engine)",
            "MP4 (v11 engine, CPU/GPU)",
            "Animated GIF",
            "MPEG-TS",
            "MOV"});
            this.cbOutputFormat.Location = new System.Drawing.Point(12, 29);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(279, 21);
            this.cbOutputFormat.TabIndex = 116;
            this.cbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputFormat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "File name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "Format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.cbFlipY);
            this.tabPage3.Controls.Add(this.cbFlipX);
            this.tabPage3.Controls.Add(this.cbInvert);
            this.tabPage3.Controls.Add(this.cbGreyscale);
            this.tabPage3.Controls.Add(this.label201);
            this.tabPage3.Controls.Add(this.tbDarkness);
            this.tabPage3.Controls.Add(this.label200);
            this.tabPage3.Controls.Add(this.label199);
            this.tabPage3.Controls.Add(this.label198);
            this.tabPage3.Controls.Add(this.tbContrast);
            this.tabPage3.Controls.Add(this.tbLightness);
            this.tabPage3.Controls.Add(this.tbSaturation);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btTextLogoAdd);
            this.tabPage3.Controls.Add(this.btLogoRemove);
            this.tabPage3.Controls.Add(this.btLogoEdit);
            this.tabPage3.Controls.Add(this.lbLogos);
            this.tabPage3.Controls.Add(this.btImageLogoAdd);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(463, 350);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Video effects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "More effects and settings available in Main Demo";
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(220, 288);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(52, 17);
            this.cbFlipY.TabIndex = 122;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(162, 288);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(52, 17);
            this.cbFlipX.TabIndex = 121;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            this.cbFlipX.CheckedChanged += new System.EventHandler(this.cbFlipX_CheckedChanged);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = true;
            this.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbInvert.Location = new System.Drawing.Point(100, 288);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.Size = new System.Drawing.Size(53, 17);
            this.cbInvert.TabIndex = 120;
            this.cbInvert.Text = "Invert";
            this.cbInvert.UseVisualStyleBackColor = true;
            this.cbInvert.CheckedChanged += new System.EventHandler(this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(20, 288);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbGreyscale.TabIndex = 119;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            this.cbGreyscale.CheckedChanged += new System.EventHandler(this.cbGreyscale_CheckedChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(154, 218);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(52, 13);
            this.label201.TabIndex = 118;
            this.label201.Text = "Darkness";
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbDarkness.Location = new System.Drawing.Point(154, 237);
            this.tbDarkness.Maximum = 255;
            this.tbDarkness.Name = "tbDarkness";
            this.tbDarkness.Size = new System.Drawing.Size(130, 45);
            this.tbDarkness.TabIndex = 117;
            this.tbDarkness.Scroll += new System.EventHandler(this.tbDarkness_Scroll);
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(18, 218);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(46, 13);
            this.label200.TabIndex = 116;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(154, 166);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(55, 13);
            this.label199.TabIndex = 115;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(18, 166);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(52, 13);
            this.label198.TabIndex = 114;
            this.label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(14, 237);
            this.tbContrast.Maximum = 255;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(130, 45);
            this.tbContrast.TabIndex = 113;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbLightness.Location = new System.Drawing.Point(14, 181);
            this.tbLightness.Maximum = 255;
            this.tbLightness.Name = "tbLightness";
            this.tbLightness.Size = new System.Drawing.Size(130, 45);
            this.tbLightness.TabIndex = 112;
            this.tbLightness.Scroll += new System.EventHandler(this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(154, 181);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(130, 45);
            this.tbSaturation.TabIndex = 111;
            this.tbSaturation.Value = 255;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = new System.Drawing.Point(120, 129);
            this.btTextLogoAdd.Name = "btTextLogoAdd";
            this.btTextLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btTextLogoAdd.TabIndex = 109;
            this.btTextLogoAdd.Text = "Add text logo";
            this.btTextLogoAdd.UseVisualStyleBackColor = true;
            this.btTextLogoAdd.Click += new System.EventHandler(this.btTextLogoAdd_Click);
            // 
            // btLogoRemove
            // 
            this.btLogoRemove.Location = new System.Drawing.Point(388, 129);
            this.btLogoRemove.Name = "btLogoRemove";
            this.btLogoRemove.Size = new System.Drawing.Size(59, 23);
            this.btLogoRemove.TabIndex = 108;
            this.btLogoRemove.Text = "Remove";
            this.btLogoRemove.UseVisualStyleBackColor = true;
            this.btLogoRemove.Click += new System.EventHandler(this.btLogoRemove_Click);
            // 
            // btLogoEdit
            // 
            this.btLogoEdit.Location = new System.Drawing.Point(324, 129);
            this.btLogoEdit.Name = "btLogoEdit";
            this.btLogoEdit.Size = new System.Drawing.Size(59, 23);
            this.btLogoEdit.TabIndex = 107;
            this.btLogoEdit.Text = "Edit";
            this.btLogoEdit.UseVisualStyleBackColor = true;
            this.btLogoEdit.Click += new System.EventHandler(this.btLogoEdit_Click);
            // 
            // lbLogos
            // 
            this.lbLogos.FormattingEnabled = true;
            this.lbLogos.Location = new System.Drawing.Point(14, 28);
            this.lbLogos.Name = "lbLogos";
            this.lbLogos.Size = new System.Drawing.Size(435, 95);
            this.lbLogos.TabIndex = 106;
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = new System.Drawing.Point(14, 129);
            this.btImageLogoAdd.Name = "btImageLogoAdd";
            this.btImageLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btImageLogoAdd.TabIndex = 105;
            this.btImageLogoAdd.Text = "Add image logo";
            this.btImageLogoAdd.UseVisualStyleBackColor = true;
            this.btImageLogoAdd.Click += new System.EventHandler(this.btImageLogoAdd_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbDebugMode);
            this.tabPage7.Controls.Add(this.mmLog);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(463, 350);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Log";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(12, 10);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 78;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(12, 33);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(445, 311);
            this.mmLog.TabIndex = 77;
            // 
            // rbCapture
            // 
            this.rbCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbCapture.AutoSize = true;
            this.rbCapture.Location = new System.Drawing.Point(76, 388);
            this.rbCapture.Name = "rbCapture";
            this.rbCapture.Size = new System.Drawing.Size(62, 17);
            this.rbCapture.TabIndex = 52;
            this.rbCapture.Text = "Capture";
            this.rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            this.rbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPreview.AutoSize = true;
            this.rbPreview.Checked = true;
            this.rbPreview.Location = new System.Drawing.Point(7, 388);
            this.rbPreview.Name = "rbPreview";
            this.rbPreview.Size = new System.Drawing.Size(63, 17);
            this.rbPreview.TabIndex = 51;
            this.rbPreview.TabStop = true;
            this.rbPreview.Text = "Preview";
            this.rbPreview.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(544, 385);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 50;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(479, 385);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 49;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // llVideoTutorials
            // 
            this.llVideoTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llVideoTutorials.AutoSize = true;
            this.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llVideoTutorials.Location = new System.Drawing.Point(841, 3);
            this.llVideoTutorials.Name = "llVideoTutorials";
            this.llVideoTutorials.Size = new System.Drawing.Size(68, 13);
            this.llVideoTutorials.TabIndex = 92;
            this.llVideoTutorials.TabStop = true;
            this.llVideoTutorials.Text = "Video tutorial";
            this.llVideoTutorials.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVideoTutorials_LinkClicked_1);
            // 
            // VideoCapture1
            // 
            this.VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = false;
            this.VideoCapture1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.VideoCapture1.Location = new System.Drawing.Point(479, 25);
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
            this.VideoCapture1.Size = new System.Drawing.Size(429, 354);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 93;
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
            this.VideoCapture1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.VideoCapture1_OnLicenseRequired);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Much more features available in Main Demo";
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(698, 385);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 100;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(637, 385);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 99;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScreenshot.Location = new System.Drawing.Point(781, 385);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(127, 23);
            this.btSaveScreenshot.TabIndex = 101;
            this.btSaveScreenshot.Text = "Save snapshot";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(187, 390);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 102;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 420);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.btSaveScreenshot);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.llVideoTutorials);
            this.Controls.Add(this.rbCapture);
            this.Controls.Add(this.rbPreview);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP Capture Demo - Video Capture SDK .Net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl15.ResumeLayout(false);
            this.tabPage144.ResumeLayout(false);
            this.tabPage144.PerformLayout();
            this.tabPage146.ResumeLayout(false);
            this.tabPage146.PerformLayout();
            this.tabPage145.ResumeLayout(false);
            this.tabPage145.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbCapture;
        private System.Windows.Forms.RadioButton rbPreview;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.TabControl tabControl15;
        private System.Windows.Forms.TabPage tabPage144;
        private System.Windows.Forms.CheckBox cbIPCameraONVIF;
        private System.Windows.Forms.Button btShowIPCamDatabase;
        private System.Windows.Forms.LinkLabel linkLabel7;
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
        private System.Windows.Forms.TextBox edONVIFLiveVideoURL;
        private System.Windows.Forms.Label label513;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.Button btONVIFPTZSetDefault;
        private System.Windows.Forms.Button btONVIFRight;
        private System.Windows.Forms.Button btONVIFLeft;
        private System.Windows.Forms.Button btONVIFZoomOut;
        private System.Windows.Forms.Button btONVIFZoomIn;
        private System.Windows.Forms.Button btONVIFDown;
        private System.Windows.Forms.Button btONVIFUp;
        private System.Windows.Forms.ComboBox cbONVIFProfile;
        private System.Windows.Forms.Label label510;
        private System.Windows.Forms.Label lbONVIFCameraInfo;
        private System.Windows.Forms.Button btONVIFConnect;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.TextBox edONVIFPassword;
        private System.Windows.Forms.Label label378;
        private System.Windows.Forms.TextBox edONVIFLogin;
        private System.Windows.Forms.Label label379;
        private System.Windows.Forms.TextBox edONVIFURL;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btOutputConfigure;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.CheckBox cbFlipX;
        private System.Windows.Forms.CheckBox cbInvert;
        private System.Windows.Forms.CheckBox cbGreyscale;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.TrackBar tbDarkness;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.TrackBar tbLightness;
        private System.Windows.Forms.TrackBar tbSaturation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.Button btLogoRemove;
        private System.Windows.Forms.Button btLogoEdit;
        private System.Windows.Forms.ListBox lbLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lbNDI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btListNDISources;
        private System.Windows.Forms.ComboBox cbIPURL;
    }
}

