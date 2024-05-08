using System;

namespace VisioForge_SDK_4_IP_Camera_CSharp_Demo
{
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

                if (onvifDeviceX != null)
                {
                    onvifDeviceX.Dispose();
                    onvifDeviceX = null;
                }

                mpegTSSettingsDialog?.Dispose();
                mpegTSSettingsDialog = null;

                mp4SettingsDialog?.Dispose();
                mp4SettingsDialog = null;

                mp4HWSettingsDialog?.Dispose();
                mp4HWSettingsDialog = null;

                movSettingsDialog?.Dispose();
                movSettingsDialog = null;

                gifSettingsDialog?.Dispose();
                gifSettingsDialog = null;

                aviSettingsDialog?.Dispose();
                aviSettingsDialog = null;

                wmvSettingsDialog?.Dispose();
                wmvSettingsDialog = null;

                screenshotSaveDialog?.Dispose();
                screenshotSaveDialog = null;

                tmRecording?.Dispose();
                tmRecording = null;

                VideoCapture1?.Dispose();
                VideoCapture1 = null;
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
            tcMain = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabControl15 = new System.Windows.Forms.TabControl();
            tabPage144 = new System.Windows.Forms.TabPage();
            btListONVIFSources = new System.Windows.Forms.Button();
            cbIPURL = new System.Windows.Forms.ComboBox();
            btListNDISources = new System.Windows.Forms.Button();
            lbNDI = new System.Windows.Forms.LinkLabel();
            label6 = new System.Windows.Forms.Label();
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
            tabPage2 = new System.Windows.Forms.TabPage();
            btSelectOutput = new System.Windows.Forms.Button();
            edOutput = new System.Windows.Forms.TextBox();
            lbInfo = new System.Windows.Forms.Label();
            btOutputConfigure = new System.Windows.Forms.Button();
            cbOutputFormat = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            label5 = new System.Windows.Forms.Label();
            cbFlipY = new System.Windows.Forms.CheckBox();
            cbFlipX = new System.Windows.Forms.CheckBox();
            cbInvert = new System.Windows.Forms.CheckBox();
            cbGreyscale = new System.Windows.Forms.CheckBox();
            label201 = new System.Windows.Forms.Label();
            tbDarkness = new System.Windows.Forms.TrackBar();
            label200 = new System.Windows.Forms.Label();
            label199 = new System.Windows.Forms.Label();
            label198 = new System.Windows.Forms.Label();
            tbContrast = new System.Windows.Forms.TrackBar();
            tbLightness = new System.Windows.Forms.TrackBar();
            tbSaturation = new System.Windows.Forms.TrackBar();
            label3 = new System.Windows.Forms.Label();
            btTextLogoAdd = new System.Windows.Forms.Button();
            btLogoRemove = new System.Windows.Forms.Button();
            btLogoEdit = new System.Windows.Forms.Button();
            lbLogos = new System.Windows.Forms.ListBox();
            btImageLogoAdd = new System.Windows.Forms.Button();
            tabPage7 = new System.Windows.Forms.TabPage();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            rbCapture = new System.Windows.Forms.RadioButton();
            rbPreview = new System.Windows.Forms.RadioButton();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            llVideoTutorials = new System.Windows.Forms.LinkLabel();
            label2 = new System.Windows.Forms.Label();
            btResume = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btSaveScreenshot = new System.Windows.Forms.Button();
            lbTimestamp = new System.Windows.Forms.Label();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            tcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl15.SuspendLayout();
            tabPage144.SuspendLayout();
            tabPage146.SuspendLayout();
            tabPage145.SuspendLayout();
            groupBox42.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage7.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tabPage1);
            tcMain.Controls.Add(tabPage2);
            tcMain.Controls.Add(tabPage3);
            tcMain.Controls.Add(tabPage7);
            tcMain.Location = new System.Drawing.Point(4, 6);
            tcMain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new System.Drawing.Size(784, 722);
            tcMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabControl15);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Size = new System.Drawing.Size(776, 684);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Input";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl15
            // 
            tabControl15.Controls.Add(tabPage144);
            tabControl15.Controls.Add(tabPage146);
            tabControl15.Controls.Add(tabPage145);
            tabControl15.Location = new System.Drawing.Point(13, 11);
            tabControl15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabControl15.Name = "tabControl15";
            tabControl15.SelectedIndex = 0;
            tabControl15.Size = new System.Drawing.Size(744, 604);
            tabControl15.TabIndex = 65;
            // 
            // tabPage144
            // 
            tabPage144.Controls.Add(btListONVIFSources);
            tabPage144.Controls.Add(cbIPURL);
            tabPage144.Controls.Add(btListNDISources);
            tabPage144.Controls.Add(lbNDI);
            tabPage144.Controls.Add(label6);
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
            tabPage144.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage144.Name = "tabPage144";
            tabPage144.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage144.Size = new System.Drawing.Size(736, 566);
            tabPage144.TabIndex = 0;
            tabPage144.Text = "Main";
            tabPage144.UseVisualStyleBackColor = true;
            // 
            // btListONVIFSources
            // 
            btListONVIFSources.Location = new System.Drawing.Point(490, 139);
            btListONVIFSources.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btListONVIFSources.Name = "btListONVIFSources";
            btListONVIFSources.Size = new System.Drawing.Size(204, 44);
            btListONVIFSources.TabIndex = 87;
            btListONVIFSources.Text = "List ONVIF sources";
            btListONVIFSources.UseVisualStyleBackColor = true;
            btListONVIFSources.Click += btListONVIFSources_Click;
            // 
            // cbIPURL
            // 
            cbIPURL.FormattingEnabled = true;
            cbIPURL.Location = new System.Drawing.Point(96, 19);
            cbIPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbIPURL.Name = "cbIPURL";
            cbIPURL.Size = new System.Drawing.Size(597, 33);
            cbIPURL.TabIndex = 86;
            cbIPURL.Text = "udp://239.1.1.140:1234";
            // 
            // btListNDISources
            // 
            btListNDISources.Location = new System.Drawing.Point(490, 186);
            btListNDISources.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btListNDISources.Name = "btListNDISources";
            btListNDISources.Size = new System.Drawing.Size(204, 44);
            btListNDISources.TabIndex = 85;
            btListNDISources.Text = "List NDI sources";
            btListNDISources.UseVisualStyleBackColor = true;
            btListNDISources.Click += btListNDISources_Click;
            // 
            // lbNDI
            // 
            lbNDI.AutoSize = true;
            lbNDI.Location = new System.Drawing.Point(433, 422);
            lbNDI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbNDI.Name = "lbNDI";
            lbNDI.Size = new System.Drawing.Size(145, 25);
            lbNDI.TabIndex = 84;
            lbNDI.TabStop = true;
            lbNDI.Text = "vendor's website";
            lbNDI.LinkClicked += lbNDI_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(18, 422);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(428, 25);
            label6.TabIndex = 83;
            label6.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label165
            // 
            label165.AutoSize = true;
            label165.Location = new System.Drawing.Point(18, 25);
            label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label165.Name = "label165";
            label165.Size = new System.Drawing.Size(43, 25);
            label165.TabIndex = 79;
            label165.Text = "URL";
            // 
            // cbIPCameraONVIF
            // 
            cbIPCameraONVIF.AutoSize = true;
            cbIPCameraONVIF.Location = new System.Drawing.Point(490, 82);
            cbIPCameraONVIF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbIPCameraONVIF.Name = "cbIPCameraONVIF";
            cbIPCameraONVIF.Size = new System.Drawing.Size(152, 29);
            cbIPCameraONVIF.TabIndex = 78;
            cbIPCameraONVIF.Text = "ONVIF camera";
            cbIPCameraONVIF.UseVisualStyleBackColor = true;
            // 
            // cbIPDisconnect
            // 
            cbIPDisconnect.AutoSize = true;
            cbIPDisconnect.Location = new System.Drawing.Point(24, 304);
            cbIPDisconnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbIPDisconnect.Name = "cbIPDisconnect";
            cbIPDisconnect.Size = new System.Drawing.Size(228, 29);
            cbIPDisconnect.TabIndex = 75;
            cbIPDisconnect.Text = "Notify if connection lost";
            cbIPDisconnect.UseVisualStyleBackColor = true;
            // 
            // edIPForcedFramerateID
            // 
            edIPForcedFramerateID.Location = new System.Drawing.Point(444, 252);
            edIPForcedFramerateID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edIPForcedFramerateID.Name = "edIPForcedFramerateID";
            edIPForcedFramerateID.Size = new System.Drawing.Size(51, 31);
            edIPForcedFramerateID.TabIndex = 71;
            edIPForcedFramerateID.Text = "0";
            // 
            // label344
            // 
            label344.AutoSize = true;
            label344.Location = new System.Drawing.Point(276, 256);
            label344.Name = "label344";
            label344.Size = new System.Drawing.Size(164, 25);
            label344.TabIndex = 70;
            label344.Text = "Force frame rate ID";
            // 
            // edIPForcedFramerate
            // 
            edIPForcedFramerate.Location = new System.Drawing.Point(190, 252);
            edIPForcedFramerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edIPForcedFramerate.Name = "edIPForcedFramerate";
            edIPForcedFramerate.Size = new System.Drawing.Size(51, 31);
            edIPForcedFramerate.TabIndex = 69;
            edIPForcedFramerate.Text = "0";
            // 
            // label295
            // 
            label295.AutoSize = true;
            label295.Location = new System.Drawing.Point(20, 256);
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
            cbIPCameraType.Location = new System.Drawing.Point(96, 79);
            cbIPCameraType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbIPCameraType.Name = "cbIPCameraType";
            cbIPCameraType.Size = new System.Drawing.Size(375, 33);
            cbIPCameraType.TabIndex = 67;
            // 
            // edIPPassword
            // 
            edIPPassword.Location = new System.Drawing.Point(280, 171);
            edIPPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edIPPassword.Name = "edIPPassword";
            edIPPassword.Size = new System.Drawing.Size(164, 31);
            edIPPassword.TabIndex = 66;
            // 
            // label167
            // 
            label167.AutoSize = true;
            label167.Location = new System.Drawing.Point(276, 139);
            label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label167.Name = "label167";
            label167.Size = new System.Drawing.Size(87, 25);
            label167.TabIndex = 65;
            label167.Text = "Password";
            // 
            // edIPLogin
            // 
            edIPLogin.Location = new System.Drawing.Point(24, 171);
            edIPLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edIPLogin.Name = "edIPLogin";
            edIPLogin.Size = new System.Drawing.Size(164, 31);
            edIPLogin.TabIndex = 64;
            // 
            // label166
            // 
            label166.AutoSize = true;
            label166.Location = new System.Drawing.Point(18, 139);
            label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label166.Name = "label166";
            label166.Size = new System.Drawing.Size(56, 25);
            label166.TabIndex = 63;
            label166.Text = "Login";
            // 
            // cbIPAudioCapture
            // 
            cbIPAudioCapture.AutoSize = true;
            cbIPAudioCapture.Location = new System.Drawing.Point(280, 304);
            cbIPAudioCapture.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbIPAudioCapture.Name = "cbIPAudioCapture";
            cbIPAudioCapture.Size = new System.Drawing.Size(150, 29);
            cbIPAudioCapture.TabIndex = 62;
            cbIPAudioCapture.Text = "Capture audio";
            cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // label168
            // 
            label168.AutoSize = true;
            label168.Location = new System.Drawing.Point(18, 86);
            label168.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label168.Name = "label168";
            label168.Size = new System.Drawing.Size(65, 25);
            label168.TabIndex = 61;
            label168.Text = "Engine";
            // 
            // tabPage146
            // 
            tabPage146.Controls.Add(cbVLCZeroClockJitter);
            tabPage146.Controls.Add(edVLCCacheSize);
            tabPage146.Controls.Add(label312);
            tabPage146.Location = new System.Drawing.Point(4, 34);
            tabPage146.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage146.Name = "tabPage146";
            tabPage146.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage146.Size = new System.Drawing.Size(736, 566);
            tabPage146.TabIndex = 2;
            tabPage146.Text = "VLC";
            tabPage146.UseVisualStyleBackColor = true;
            // 
            // cbVLCZeroClockJitter
            // 
            cbVLCZeroClockJitter.AutoSize = true;
            cbVLCZeroClockJitter.Location = new System.Drawing.Point(289, 31);
            cbVLCZeroClockJitter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVLCZeroClockJitter.Name = "cbVLCZeroClockJitter";
            cbVLCZeroClockJitter.Size = new System.Drawing.Size(191, 29);
            cbVLCZeroClockJitter.TabIndex = 78;
            cbVLCZeroClockJitter.Text = "VLC zero clock jitter";
            cbVLCZeroClockJitter.UseVisualStyleBackColor = true;
            // 
            // edVLCCacheSize
            // 
            edVLCCacheSize.Location = new System.Drawing.Point(198, 28);
            edVLCCacheSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edVLCCacheSize.Name = "edVLCCacheSize";
            edVLCCacheSize.Size = new System.Drawing.Size(51, 31);
            edVLCCacheSize.TabIndex = 77;
            edVLCCacheSize.Text = "1000";
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
            tabPage145.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage145.Name = "tabPage145";
            tabPage145.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage145.Size = new System.Drawing.Size(736, 566);
            tabPage145.TabIndex = 1;
            tabPage145.Text = "ONVIF";
            tabPage145.UseVisualStyleBackColor = true;
            // 
            // edONVIFPassword
            // 
            edONVIFPassword.Location = new System.Drawing.Point(407, 81);
            edONVIFPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edONVIFPassword.Name = "edONVIFPassword";
            edONVIFPassword.Size = new System.Drawing.Size(164, 31);
            edONVIFPassword.TabIndex = 75;
            // 
            // label378
            // 
            label378.AutoSize = true;
            label378.Location = new System.Drawing.Point(310, 86);
            label378.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label378.Name = "label378";
            label378.Size = new System.Drawing.Size(87, 25);
            label378.TabIndex = 74;
            label378.Text = "Password";
            // 
            // edONVIFLogin
            // 
            edONVIFLogin.Location = new System.Drawing.Point(131, 81);
            edONVIFLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edONVIFLogin.Name = "edONVIFLogin";
            edONVIFLogin.Size = new System.Drawing.Size(164, 31);
            edONVIFLogin.TabIndex = 73;
            // 
            // label379
            // 
            label379.AutoSize = true;
            label379.Location = new System.Drawing.Point(24, 86);
            label379.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label379.Name = "label379";
            label379.Size = new System.Drawing.Size(56, 25);
            label379.TabIndex = 72;
            label379.Text = "Login";
            // 
            // edONVIFURL
            // 
            edONVIFURL.Location = new System.Drawing.Point(30, 22);
            edONVIFURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edONVIFURL.Name = "edONVIFURL";
            edONVIFURL.Size = new System.Drawing.Size(541, 31);
            edONVIFURL.TabIndex = 71;
            edONVIFURL.Text = "http://192.168.1.101:2020/onvif/device_service";
            // 
            // edONVIFLiveVideoURL
            // 
            edONVIFLiveVideoURL.Location = new System.Drawing.Point(130, 265);
            edONVIFLiveVideoURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL";
            edONVIFLiveVideoURL.ReadOnly = true;
            edONVIFLiveVideoURL.Size = new System.Drawing.Size(574, 31);
            edONVIFLiveVideoURL.TabIndex = 28;
            // 
            // label513
            // 
            label513.AutoSize = true;
            label513.Location = new System.Drawing.Point(23, 271);
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
            groupBox42.Location = new System.Drawing.Point(24, 322);
            groupBox42.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox42.Name = "groupBox42";
            groupBox42.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox42.Size = new System.Drawing.Size(451, 200);
            groupBox42.TabIndex = 26;
            groupBox42.TabStop = false;
            groupBox42.Text = "PTZ";
            // 
            // btONVIFPTZSetDefault
            // 
            btONVIFPTZSetDefault.Location = new System.Drawing.Point(217, 85);
            btONVIFPTZSetDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFPTZSetDefault.Name = "btONVIFPTZSetDefault";
            btONVIFPTZSetDefault.Size = new System.Drawing.Size(193, 44);
            btONVIFPTZSetDefault.TabIndex = 6;
            btONVIFPTZSetDefault.Text = "Set default position";
            btONVIFPTZSetDefault.UseVisualStyleBackColor = true;
            btONVIFPTZSetDefault.Click += btONVIFPTZSetDefault_Click;
            // 
            // btONVIFRight
            // 
            btONVIFRight.Location = new System.Drawing.Point(142, 64);
            btONVIFRight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFRight.Name = "btONVIFRight";
            btONVIFRight.Size = new System.Drawing.Size(36, 92);
            btONVIFRight.TabIndex = 5;
            btONVIFRight.Text = "R";
            btONVIFRight.UseVisualStyleBackColor = true;
            btONVIFRight.Click += btONVIFRight_Click;
            // 
            // btONVIFLeft
            // 
            btONVIFLeft.Location = new System.Drawing.Point(22, 61);
            btONVIFLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFLeft.Name = "btONVIFLeft";
            btONVIFLeft.Size = new System.Drawing.Size(36, 92);
            btONVIFLeft.TabIndex = 4;
            btONVIFLeft.Text = "L";
            btONVIFLeft.UseVisualStyleBackColor = true;
            btONVIFLeft.Click += btONVIFLeft_Click;
            // 
            // btONVIFZoomOut
            // 
            btONVIFZoomOut.Location = new System.Drawing.Point(102, 86);
            btONVIFZoomOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFZoomOut.Name = "btONVIFZoomOut";
            btONVIFZoomOut.Size = new System.Drawing.Size(38, 44);
            btONVIFZoomOut.TabIndex = 3;
            btONVIFZoomOut.Text = "-";
            btONVIFZoomOut.UseVisualStyleBackColor = true;
            btONVIFZoomOut.Click += btONVIFZoomOut_Click;
            // 
            // btONVIFZoomIn
            // 
            btONVIFZoomIn.Location = new System.Drawing.Point(58, 86);
            btONVIFZoomIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFZoomIn.Name = "btONVIFZoomIn";
            btONVIFZoomIn.Size = new System.Drawing.Size(37, 44);
            btONVIFZoomIn.TabIndex = 2;
            btONVIFZoomIn.Text = "+";
            btONVIFZoomIn.UseVisualStyleBackColor = true;
            btONVIFZoomIn.Click += btONVIFZoomIn_Click;
            // 
            // btONVIFDown
            // 
            btONVIFDown.Location = new System.Drawing.Point(57, 132);
            btONVIFDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFDown.Name = "btONVIFDown";
            btONVIFDown.Size = new System.Drawing.Size(84, 44);
            btONVIFDown.TabIndex = 1;
            btONVIFDown.Text = "Down";
            btONVIFDown.UseVisualStyleBackColor = true;
            btONVIFDown.Click += btONVIFDown_Click;
            // 
            // btONVIFUp
            // 
            btONVIFUp.Location = new System.Drawing.Point(57, 39);
            btONVIFUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFUp.Name = "btONVIFUp";
            btONVIFUp.Size = new System.Drawing.Size(84, 44);
            btONVIFUp.TabIndex = 0;
            btONVIFUp.Text = "Up";
            btONVIFUp.UseVisualStyleBackColor = true;
            btONVIFUp.Click += btONVIFUp_Click;
            // 
            // cbONVIFProfile
            // 
            cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbONVIFProfile.FormattingEnabled = true;
            cbONVIFProfile.Location = new System.Drawing.Point(130, 215);
            cbONVIFProfile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbONVIFProfile.Name = "cbONVIFProfile";
            cbONVIFProfile.Size = new System.Drawing.Size(574, 33);
            cbONVIFProfile.TabIndex = 4;
            cbONVIFProfile.SelectedIndexChanged += cbONVIFProfile_SelectedIndexChanged;
            // 
            // label510
            // 
            label510.AutoSize = true;
            label510.Location = new System.Drawing.Point(24, 221);
            label510.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label510.Name = "label510";
            label510.Size = new System.Drawing.Size(62, 25);
            label510.TabIndex = 3;
            label510.Text = "Profile";
            // 
            // lbONVIFCameraInfo
            // 
            lbONVIFCameraInfo.AutoSize = true;
            lbONVIFCameraInfo.Location = new System.Drawing.Point(23, 164);
            lbONVIFCameraInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbONVIFCameraInfo.Name = "lbONVIFCameraInfo";
            lbONVIFCameraInfo.Size = new System.Drawing.Size(112, 25);
            lbONVIFCameraInfo.TabIndex = 1;
            lbONVIFCameraInfo.Text = "Status: None";
            // 
            // btONVIFConnect
            // 
            btONVIFConnect.Location = new System.Drawing.Point(582, 19);
            btONVIFConnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btONVIFConnect.Name = "btONVIFConnect";
            btONVIFConnect.Size = new System.Drawing.Size(124, 44);
            btONVIFConnect.TabIndex = 0;
            btONVIFConnect.Text = "Connect";
            btONVIFConnect.UseVisualStyleBackColor = true;
            btONVIFConnect.Click += btONVIFConnect_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btSelectOutput);
            tabPage2.Controls.Add(edOutput);
            tabPage2.Controls.Add(lbInfo);
            tabPage2.Controls.Add(btOutputConfigure);
            tabPage2.Controls.Add(cbOutputFormat);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Size = new System.Drawing.Size(776, 684);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(722, 298);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(40, 44);
            btSelectOutput.TabIndex = 120;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(20, 302);
            edOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(688, 31);
            edOutput.TabIndex = 119;
            edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(16, 110);
            lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 118;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            btOutputConfigure.Location = new System.Drawing.Point(20, 140);
            btOutputConfigure.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btOutputConfigure.Name = "btOutputConfigure";
            btOutputConfigure.Size = new System.Drawing.Size(124, 44);
            btOutputConfigure.TabIndex = 117;
            btOutputConfigure.Text = "Configure";
            btOutputConfigure.UseVisualStyleBackColor = true;
            btOutputConfigure.Click += btOutputConfigure_Click;
            // 
            // cbOutputFormat
            // 
            cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputFormat.FormattingEnabled = true;
            cbOutputFormat.Items.AddRange(new object[] { "AVI", "WMV (Windows Media Video)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "MPEG-TS", "MOV" });
            cbOutputFormat.Location = new System.Drawing.Point(20, 56);
            cbOutputFormat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbOutputFormat.Name = "cbOutputFormat";
            cbOutputFormat.Size = new System.Drawing.Size(462, 33);
            cbOutputFormat.TabIndex = 116;
            cbOutputFormat.SelectedIndexChanged += cbOutputFormat_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 271);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(87, 25);
            label4.TabIndex = 115;
            label4.Text = "File name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(16, 22);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 25);
            label7.TabIndex = 114;
            label7.Text = "Format";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(cbFlipY);
            tabPage3.Controls.Add(cbFlipX);
            tabPage3.Controls.Add(cbInvert);
            tabPage3.Controls.Add(cbGreyscale);
            tabPage3.Controls.Add(label201);
            tabPage3.Controls.Add(tbDarkness);
            tabPage3.Controls.Add(label200);
            tabPage3.Controls.Add(label199);
            tabPage3.Controls.Add(label198);
            tabPage3.Controls.Add(tbContrast);
            tabPage3.Controls.Add(tbLightness);
            tabPage3.Controls.Add(tbSaturation);
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(btTextLogoAdd);
            tabPage3.Controls.Add(btLogoRemove);
            tabPage3.Controls.Add(btLogoEdit);
            tabPage3.Controls.Add(lbLogos);
            tabPage3.Controls.Add(btImageLogoAdd);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage3.Size = new System.Drawing.Size(776, 684);
            tabPage3.TabIndex = 4;
            tabPage3.Text = "Video effects";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(177, 611);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(403, 25);
            label5.TabIndex = 123;
            label5.Text = "More effects and settings available in Main Demo";
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(367, 554);
            cbFlipY.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipY.Name = "cbFlipY";
            cbFlipY.Size = new System.Drawing.Size(81, 29);
            cbFlipY.TabIndex = 122;
            cbFlipY.Text = "Flip Y";
            cbFlipY.UseVisualStyleBackColor = true;
            cbFlipY.CheckedChanged += cbFlipY_CheckedChanged;
            // 
            // cbFlipX
            // 
            cbFlipX.AutoSize = true;
            cbFlipX.Location = new System.Drawing.Point(270, 554);
            cbFlipX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbFlipX.Name = "cbFlipX";
            cbFlipX.Size = new System.Drawing.Size(82, 29);
            cbFlipX.TabIndex = 121;
            cbFlipX.Text = "Flip X";
            cbFlipX.UseVisualStyleBackColor = true;
            cbFlipX.CheckedChanged += cbFlipX_CheckedChanged;
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(167, 554);
            cbInvert.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbInvert.Name = "cbInvert";
            cbInvert.Size = new System.Drawing.Size(83, 29);
            cbInvert.TabIndex = 120;
            cbInvert.Text = "Invert";
            cbInvert.UseVisualStyleBackColor = true;
            cbInvert.CheckedChanged += cbInvert_CheckedChanged;
            // 
            // cbGreyscale
            // 
            cbGreyscale.AutoSize = true;
            cbGreyscale.Location = new System.Drawing.Point(33, 554);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 119;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += cbGreyscale_CheckedChanged;
            // 
            // label201
            // 
            label201.AutoSize = true;
            label201.Location = new System.Drawing.Point(257, 419);
            label201.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label201.Name = "label201";
            label201.Size = new System.Drawing.Size(84, 25);
            label201.TabIndex = 118;
            label201.Text = "Darkness";
            // 
            // tbDarkness
            // 
            tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbDarkness.Location = new System.Drawing.Point(257, 456);
            tbDarkness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbDarkness.Maximum = 255;
            tbDarkness.Name = "tbDarkness";
            tbDarkness.Size = new System.Drawing.Size(217, 69);
            tbDarkness.TabIndex = 117;
            tbDarkness.Scroll += tbDarkness_Scroll;
            // 
            // label200
            // 
            label200.AutoSize = true;
            label200.Location = new System.Drawing.Point(30, 419);
            label200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label200.Name = "label200";
            label200.Size = new System.Drawing.Size(79, 25);
            label200.TabIndex = 116;
            label200.Text = "Contrast";
            // 
            // label199
            // 
            label199.AutoSize = true;
            label199.Location = new System.Drawing.Point(257, 319);
            label199.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label199.Name = "label199";
            label199.Size = new System.Drawing.Size(93, 25);
            label199.TabIndex = 115;
            label199.Text = "Saturation";
            // 
            // label198
            // 
            label198.AutoSize = true;
            label198.Location = new System.Drawing.Point(30, 319);
            label198.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label198.Name = "label198";
            label198.Size = new System.Drawing.Size(86, 25);
            label198.TabIndex = 114;
            label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(23, 456);
            tbContrast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(217, 69);
            tbContrast.TabIndex = 113;
            tbContrast.Scroll += tbContrast_Scroll;
            // 
            // tbLightness
            // 
            tbLightness.BackColor = System.Drawing.SystemColors.Window;
            tbLightness.Location = new System.Drawing.Point(23, 348);
            tbLightness.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbLightness.Maximum = 255;
            tbLightness.Name = "tbLightness";
            tbLightness.Size = new System.Drawing.Size(217, 69);
            tbLightness.TabIndex = 112;
            tbLightness.Scroll += tbLightness_Scroll;
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(257, 348);
            tbSaturation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(217, 69);
            tbSaturation.TabIndex = 111;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += tbSaturation_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 22);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(158, 25);
            label3.TabIndex = 110;
            label3.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(200, 248);
            btTextLogoAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btTextLogoAdd.Name = "btTextLogoAdd";
            btTextLogoAdd.Size = new System.Drawing.Size(164, 44);
            btTextLogoAdd.TabIndex = 109;
            btTextLogoAdd.Text = "Add text logo";
            btTextLogoAdd.UseVisualStyleBackColor = true;
            btTextLogoAdd.Click += btTextLogoAdd_Click;
            // 
            // btLogoRemove
            // 
            btLogoRemove.Location = new System.Drawing.Point(647, 248);
            btLogoRemove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btLogoRemove.Name = "btLogoRemove";
            btLogoRemove.Size = new System.Drawing.Size(98, 44);
            btLogoRemove.TabIndex = 108;
            btLogoRemove.Text = "Remove";
            btLogoRemove.UseVisualStyleBackColor = true;
            btLogoRemove.Click += btLogoRemove_Click;
            // 
            // btLogoEdit
            // 
            btLogoEdit.Location = new System.Drawing.Point(540, 248);
            btLogoEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btLogoEdit.Name = "btLogoEdit";
            btLogoEdit.Size = new System.Drawing.Size(98, 44);
            btLogoEdit.TabIndex = 107;
            btLogoEdit.Text = "Edit";
            btLogoEdit.UseVisualStyleBackColor = true;
            btLogoEdit.Click += btLogoEdit_Click;
            // 
            // lbLogos
            // 
            lbLogos.FormattingEnabled = true;
            lbLogos.ItemHeight = 25;
            lbLogos.Location = new System.Drawing.Point(23, 54);
            lbLogos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lbLogos.Name = "lbLogos";
            lbLogos.Size = new System.Drawing.Size(722, 179);
            lbLogos.TabIndex = 106;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(23, 248);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(164, 44);
            btImageLogoAdd.TabIndex = 105;
            btImageLogoAdd.Text = "Add image logo";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += btImageLogoAdd_Click;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(cbDebugMode);
            tabPage7.Controls.Add(mmLog);
            tabPage7.Location = new System.Drawing.Point(4, 34);
            tabPage7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage7.Size = new System.Drawing.Size(776, 684);
            tabPage7.TabIndex = 3;
            tabPage7.Text = "Log";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(20, 19);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 78;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mmLog.Location = new System.Drawing.Point(20, 64);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(740, 594);
            mmLog.TabIndex = 77;
            // 
            // rbCapture
            // 
            rbCapture.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbCapture.AutoSize = true;
            rbCapture.Location = new System.Drawing.Point(127, 750);
            rbCapture.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbCapture.Name = "rbCapture";
            rbCapture.Size = new System.Drawing.Size(99, 29);
            rbCapture.TabIndex = 52;
            rbCapture.Text = "Capture";
            rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            rbPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbPreview.AutoSize = true;
            rbPreview.Checked = true;
            rbPreview.Location = new System.Drawing.Point(11, 750);
            rbPreview.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            rbPreview.Name = "rbPreview";
            rbPreview.Size = new System.Drawing.Size(97, 29);
            rbPreview.TabIndex = 51;
            rbPreview.TabStop = true;
            rbPreview.Text = "Preview";
            rbPreview.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStop.Location = new System.Drawing.Point(907, 740);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 50;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(798, 740);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 49;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // llVideoTutorials
            // 
            llVideoTutorials.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            llVideoTutorials.AutoSize = true;
            llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            llVideoTutorials.Location = new System.Drawing.Point(1402, 6);
            llVideoTutorials.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llVideoTutorials.Name = "llVideoTutorials";
            llVideoTutorials.Size = new System.Drawing.Size(119, 25);
            llVideoTutorials.TabIndex = 92;
            llVideoTutorials.TabStop = true;
            llVideoTutorials.Text = "Video tutorial";
            llVideoTutorials.LinkClicked += llVideoTutorials_LinkClicked_1;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(953, 6);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(361, 25);
            label2.TabIndex = 95;
            label2.Text = "Much more features available in Main Demo";
            // 
            // btResume
            // 
            btResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btResume.Location = new System.Drawing.Point(1163, 740);
            btResume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(91, 44);
            btResume.TabIndex = 100;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btPause
            // 
            btPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btPause.Location = new System.Drawing.Point(1062, 740);
            btPause.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(91, 44);
            btPause.TabIndex = 99;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btSaveScreenshot
            // 
            btSaveScreenshot.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btSaveScreenshot.Location = new System.Drawing.Point(1343, 740);
            btSaveScreenshot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btSaveScreenshot.Name = "btSaveScreenshot";
            btSaveScreenshot.Size = new System.Drawing.Size(170, 44);
            btSaveScreenshot.TabIndex = 101;
            btSaveScreenshot.Text = "Save snapshot";
            btSaveScreenshot.UseVisualStyleBackColor = true;
            btSaveScreenshot.Click += btSaveScreenshot_Click;
            // 
            // lbTimestamp
            // 
            lbTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(311, 750);
            lbTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(209, 25);
            lbTimestamp.TabIndex = 102;
            lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(798, 48);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(716, 517);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 103;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1533, 808);
            Controls.Add(VideoView1);
            Controls.Add(lbTimestamp);
            Controls.Add(btSaveScreenshot);
            Controls.Add(btResume);
            Controls.Add(btPause);
            Controls.Add(label2);
            Controls.Add(llVideoTutorials);
            Controls.Add(rbCapture);
            Controls.Add(rbPreview);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(tcMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "IP Capture Demo - Video Capture SDK .Net";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl15.ResumeLayout(false);
            tabPage144.ResumeLayout(false);
            tabPage144.PerformLayout();
            tabPage146.ResumeLayout(false);
            tabPage146.PerformLayout();
            tabPage145.ResumeLayout(false);
            tabPage145.PerformLayout();
            groupBox42.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.TabControl tabControl15;
        private System.Windows.Forms.TabPage tabPage144;
        private System.Windows.Forms.CheckBox cbIPCameraONVIF;
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
        private System.Windows.Forms.LinkLabel lbNDI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btListNDISources;
        private System.Windows.Forms.ComboBox cbIPURL;
        private System.Windows.Forms.Button btListONVIFSources;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

