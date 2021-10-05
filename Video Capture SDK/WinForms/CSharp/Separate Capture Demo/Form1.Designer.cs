namespace Separate_Capture_Demo
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
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.llVideoTutorials = new System.Windows.Forms.LinkLabel();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbUseAudioInputFromVideoCaptureDevice = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.btVideoCaptureDeviceSettings = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.tbAudioBalance = new System.Windows.Forms.TrackBar();
            this.label54 = new System.Windows.Forms.Label();
            this.tbAudioVolume = new System.Windows.Forms.TrackBar();
            this.cbRecordAudio = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btOutputConfigure = new System.Windows.Forms.Button();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(710, 411);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 116;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(502, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(214, 13);
            this.label34.TabIndex = 113;
            this.label34.Text = "Much more features available in Main Demo";
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
            this.VideoCapture1.CustomRedist_DisableDialog = false;
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
            this.VideoCapture1.Location = new System.Drawing.Point(400, 28);
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
            this.VideoCapture1.Size = new System.Drawing.Size(443, 332);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 112;
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
            // llVideoTutorials
            // 
            this.llVideoTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llVideoTutorials.AutoSize = true;
            this.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llVideoTutorials.Location = new System.Drawing.Point(746, 6);
            this.llVideoTutorials.Name = "llVideoTutorials";
            this.llVideoTutorials.Size = new System.Drawing.Size(98, 13);
            this.llVideoTutorials.TabIndex = 111;
            this.llVideoTutorials.TabStop = true;
            this.llVideoTutorials.Text = "View video tutorials";
            this.llVideoTutorials.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVideoTutorials_LinkClicked);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(468, 404);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 110;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(400, 404);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 109;
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
            this.tcMain.Location = new System.Drawing.Point(4, 6);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(390, 427);
            this.tcMain.TabIndex = 108;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbUseAudioInputFromVideoCaptureDevice);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage1.Controls.Add(this.btVideoCaptureDeviceSettings);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage1.Controls.Add(this.cbVideoInputFormat);
            this.tabPage1.Controls.Add(this.cbVideoInputDevice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label55);
            this.tabPage1.Controls.Add(this.tbAudioBalance);
            this.tabPage1.Controls.Add(this.label54);
            this.tabPage1.Controls.Add(this.tbAudioVolume);
            this.tabPage1.Controls.Add(this.cbRecordAudio);
            this.tabPage1.Controls.Add(this.cbAudioOutputDevice);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage1.Controls.Add(this.btAudioInputDeviceSettings);
            this.tabPage1.Controls.Add(this.cbAudioInputLine);
            this.tabPage1.Controls.Add(this.cbAudioInputFormat);
            this.tabPage1.Controls.Add(this.cbAudioInputDevice);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(382, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Devices";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbUseAudioInputFromVideoCaptureDevice
            // 
            this.cbUseAudioInputFromVideoCaptureDevice.AutoSize = true;
            this.cbUseAudioInputFromVideoCaptureDevice.Location = new System.Drawing.Point(173, 172);
            this.cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice";
            this.cbUseAudioInputFromVideoCaptureDevice.Size = new System.Drawing.Size(187, 17);
            this.cbUseAudioInputFromVideoCaptureDevice.TabIndex = 129;
            this.cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source";
            this.cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true;
            this.cbUseAudioInputFromVideoCaptureDevice.CheckedChanged += new System.EventHandler(this.cbUseAudioInputFromVideoCaptureDevice_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(188, 72);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 127;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestVideoInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestVideoInputFormat_CheckedChanged);
            // 
            // btVideoCaptureDeviceSettings
            // 
            this.btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(269, 34);
            this.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            this.btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(66, 23);
            this.btVideoCaptureDeviceSettings.TabIndex = 126;
            this.btVideoCaptureDeviceSettings.Text = "Settings";
            this.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            this.btVideoCaptureDeviceSettings.Click += new System.EventHandler(this.btVideoCaptureDeviceSettings_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(266, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(269, 89);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(65, 21);
            this.cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(9, 89);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(247, 21);
            this.cbVideoInputFormat.TabIndex = 123;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(9, 36);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(247, 21);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 121;
            this.label13.Text = "Video input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 120;
            this.label11.Text = "Video input device";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(198, 358);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 13);
            this.label55.TabIndex = 90;
            this.label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            this.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioBalance.Location = new System.Drawing.Point(249, 353);
            this.tbAudioBalance.Maximum = 100;
            this.tbAudioBalance.Minimum = -100;
            this.tbAudioBalance.Name = "tbAudioBalance";
            this.tbAudioBalance.Size = new System.Drawing.Size(114, 45);
            this.tbAudioBalance.TabIndex = 89;
            this.tbAudioBalance.TickFrequency = 5;
            this.tbAudioBalance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudioBalance.Scroll += new System.EventHandler(this.tbAudioBalance_Scroll);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(7, 358);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 88;
            this.label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            this.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioVolume.Location = new System.Drawing.Point(54, 353);
            this.tbAudioVolume.Maximum = 100;
            this.tbAudioVolume.Minimum = 20;
            this.tbAudioVolume.Name = "tbAudioVolume";
            this.tbAudioVolume.Size = new System.Drawing.Size(116, 45);
            this.tbAudioVolume.TabIndex = 87;
            this.tbAudioVolume.TickFrequency = 10;
            this.tbAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudioVolume.Value = 80;
            this.tbAudioVolume.Scroll += new System.EventHandler(this.tbAudioVolume_Scroll);
            // 
            // cbRecordAudio
            // 
            this.cbRecordAudio.AutoSize = true;
            this.cbRecordAudio.Checked = true;
            this.cbRecordAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecordAudio.Location = new System.Drawing.Point(253, 309);
            this.cbRecordAudio.Name = "cbRecordAudio";
            this.cbRecordAudio.Size = new System.Drawing.Size(115, 17);
            this.cbRecordAudio.TabIndex = 86;
            this.cbRecordAudio.Text = "Play/Record audio";
            this.cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(9, 326);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(354, 21);
            this.cbAudioOutputDevice.TabIndex = 85;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 310);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 84;
            this.label15.Text = "Audio output device";
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(307, 227);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestAudioInputFormat.TabIndex = 83;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestAudioInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestAudioInputFormat_CheckedChanged);
            // 
            // btAudioInputDeviceSettings
            // 
            this.btAudioInputDeviceSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAudioInputDeviceSettings.Location = new System.Drawing.Point(299, 195);
            this.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            this.btAudioInputDeviceSettings.Size = new System.Drawing.Size(76, 23);
            this.btAudioInputDeviceSettings.TabIndex = 82;
            this.btAudioInputDeviceSettings.Text = "Settings";
            this.btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            this.btAudioInputDeviceSettings.Click += new System.EventHandler(this.btAudioInputDeviceSettings_Click);
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(9, 251);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(161, 21);
            this.cbAudioInputLine.TabIndex = 81;
            this.cbAudioInputLine.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputLine_SelectedIndexChanged);
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(183, 250);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(192, 21);
            this.cbAudioInputFormat.TabIndex = 80;
            this.cbAudioInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputFormat_SelectedIndexChanged);
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(9, 197);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(284, 21);
            this.cbAudioInputDevice.TabIndex = 79;
            this.cbAudioInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 229);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 78;
            this.label22.Text = "Audio input line";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 173);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 13);
            this.label23.TabIndex = 77;
            this.label23.Text = "Audio input device";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(180, 227);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 76;
            this.label25.Text = "Input format";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label376);
            this.tabPage2.Controls.Add(this.edSeparateCaptureFileSize);
            this.tabPage2.Controls.Add(this.label375);
            this.tabPage2.Controls.Add(this.label374);
            this.tabPage2.Controls.Add(this.edSeparateCaptureDuration);
            this.tabPage2.Controls.Add(this.label373);
            this.tabPage2.Controls.Add(this.rbSeparateCaptureSplitBySize);
            this.tabPage2.Controls.Add(this.rbSeparateCaptureSplitByDuration);
            this.tabPage2.Controls.Add(this.rbSeparateCaptureStartManually);
            this.tabPage2.Controls.Add(this.btSeparateCaptureResume);
            this.tabPage2.Controls.Add(this.btSeparateCapturePause);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.btSeparateCaptureStop);
            this.tabPage2.Controls.Add(this.btSeparateCaptureStart);
            this.tabPage2.Controls.Add(this.label83);
            this.tabPage2.Controls.Add(this.label82);
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
            this.tabPage2.Size = new System.Drawing.Size(382, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label376
            // 
            this.label376.AutoSize = true;
            this.label376.Location = new System.Drawing.Point(346, 370);
            this.label376.Name = "label376";
            this.label376.Size = new System.Drawing.Size(23, 13);
            this.label376.TabIndex = 142;
            this.label376.Text = "MB";
            // 
            // edSeparateCaptureFileSize
            // 
            this.edSeparateCaptureFileSize.Location = new System.Drawing.Point(287, 366);
            this.edSeparateCaptureFileSize.Name = "edSeparateCaptureFileSize";
            this.edSeparateCaptureFileSize.Size = new System.Drawing.Size(53, 20);
            this.edSeparateCaptureFileSize.TabIndex = 141;
            this.edSeparateCaptureFileSize.Text = "50";
            // 
            // label375
            // 
            this.label375.AutoSize = true;
            this.label375.Location = new System.Drawing.Point(214, 369);
            this.label375.Name = "label375";
            this.label375.Size = new System.Drawing.Size(44, 13);
            this.label375.TabIndex = 140;
            this.label375.Text = "File size";
            // 
            // label374
            // 
            this.label374.AutoSize = true;
            this.label374.Location = new System.Drawing.Point(160, 369);
            this.label374.Name = "label374";
            this.label374.Size = new System.Drawing.Size(20, 13);
            this.label374.TabIndex = 139;
            this.label374.Text = "ms";
            // 
            // edSeparateCaptureDuration
            // 
            this.edSeparateCaptureDuration.Location = new System.Drawing.Point(101, 366);
            this.edSeparateCaptureDuration.Name = "edSeparateCaptureDuration";
            this.edSeparateCaptureDuration.Size = new System.Drawing.Size(53, 20);
            this.edSeparateCaptureDuration.TabIndex = 138;
            this.edSeparateCaptureDuration.Text = "10000";
            // 
            // label373
            // 
            this.label373.AutoSize = true;
            this.label373.Location = new System.Drawing.Point(28, 369);
            this.label373.Name = "label373";
            this.label373.Size = new System.Drawing.Size(47, 13);
            this.label373.TabIndex = 137;
            this.label373.Text = "Duration";
            // 
            // rbSeparateCaptureSplitBySize
            // 
            this.rbSeparateCaptureSplitBySize.AutoSize = true;
            this.rbSeparateCaptureSplitBySize.Location = new System.Drawing.Point(197, 345);
            this.rbSeparateCaptureSplitBySize.Name = "rbSeparateCaptureSplitBySize";
            this.rbSeparateCaptureSplitBySize.Size = new System.Drawing.Size(96, 17);
            this.rbSeparateCaptureSplitBySize.TabIndex = 136;
            this.rbSeparateCaptureSplitBySize.Text = "Split by file size";
            this.rbSeparateCaptureSplitBySize.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureSplitByDuration
            // 
            this.rbSeparateCaptureSplitByDuration.AutoSize = true;
            this.rbSeparateCaptureSplitByDuration.Location = new System.Drawing.Point(11, 344);
            this.rbSeparateCaptureSplitByDuration.Name = "rbSeparateCaptureSplitByDuration";
            this.rbSeparateCaptureSplitByDuration.Size = new System.Drawing.Size(100, 17);
            this.rbSeparateCaptureSplitByDuration.TabIndex = 135;
            this.rbSeparateCaptureSplitByDuration.Text = "Split by duration";
            this.rbSeparateCaptureSplitByDuration.UseVisualStyleBackColor = true;
            // 
            // rbSeparateCaptureStartManually
            // 
            this.rbSeparateCaptureStartManually.AutoSize = true;
            this.rbSeparateCaptureStartManually.Checked = true;
            this.rbSeparateCaptureStartManually.Location = new System.Drawing.Point(11, 213);
            this.rbSeparateCaptureStartManually.Name = "rbSeparateCaptureStartManually";
            this.rbSeparateCaptureStartManually.Size = new System.Drawing.Size(91, 17);
            this.rbSeparateCaptureStartManually.TabIndex = 134;
            this.rbSeparateCaptureStartManually.TabStop = true;
            this.rbSeparateCaptureStartManually.Text = "Start manually";
            this.rbSeparateCaptureStartManually.UseVisualStyleBackColor = true;
            // 
            // btSeparateCaptureResume
            // 
            this.btSeparateCaptureResume.Location = new System.Drawing.Point(159, 237);
            this.btSeparateCaptureResume.Name = "btSeparateCaptureResume";
            this.btSeparateCaptureResume.Size = new System.Drawing.Size(58, 23);
            this.btSeparateCaptureResume.TabIndex = 133;
            this.btSeparateCaptureResume.Text = "Resume";
            this.btSeparateCaptureResume.UseVisualStyleBackColor = true;
            this.btSeparateCaptureResume.Click += new System.EventHandler(this.btSeparateCaptureResume_Click);
            // 
            // btSeparateCapturePause
            // 
            this.btSeparateCapturePause.Location = new System.Drawing.Point(95, 237);
            this.btSeparateCapturePause.Name = "btSeparateCapturePause";
            this.btSeparateCapturePause.Size = new System.Drawing.Size(58, 23);
            this.btSeparateCapturePause.TabIndex = 132;
            this.btSeparateCapturePause.Text = "Pause";
            this.btSeparateCapturePause.UseVisualStyleBackColor = true;
            this.btSeparateCapturePause.Click += new System.EventHandler(this.btSeparateCapturePause_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btSeparateCaptureChangeFilename);
            this.groupBox8.Controls.Add(this.edNewFilename);
            this.groupBox8.Controls.Add(this.label84);
            this.groupBox8.Location = new System.Drawing.Point(31, 266);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(333, 55);
            this.groupBox8.TabIndex = 131;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Change file name on the fly";
            // 
            // btSeparateCaptureChangeFilename
            // 
            this.btSeparateCaptureChangeFilename.Location = new System.Drawing.Point(256, 20);
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
            this.edNewFilename.Size = new System.Drawing.Size(152, 20);
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
            this.btSeparateCaptureStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSeparateCaptureStop.Location = new System.Drawing.Point(223, 237);
            this.btSeparateCaptureStop.Name = "btSeparateCaptureStop";
            this.btSeparateCaptureStop.Size = new System.Drawing.Size(58, 23);
            this.btSeparateCaptureStop.TabIndex = 130;
            this.btSeparateCaptureStop.Text = "Stop";
            this.btSeparateCaptureStop.UseVisualStyleBackColor = true;
            this.btSeparateCaptureStop.Click += new System.EventHandler(this.btSeparateCaptureStop_Click);
            // 
            // btSeparateCaptureStart
            // 
            this.btSeparateCaptureStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSeparateCaptureStart.Location = new System.Drawing.Point(31, 237);
            this.btSeparateCaptureStart.Name = "btSeparateCaptureStart";
            this.btSeparateCaptureStart.Size = new System.Drawing.Size(58, 23);
            this.btSeparateCaptureStart.TabIndex = 129;
            this.btSeparateCaptureStart.Text = "Start";
            this.btSeparateCaptureStart.UseVisualStyleBackColor = true;
            this.btSeparateCaptureStart.Click += new System.EventHandler(this.btSeparateCaptureStart_Click);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(13, 186);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(178, 13);
            this.label83.TabIndex = 128;
            this.label83.Text = "capture independently from preview.";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(13, 168);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(322, 13);
            this.label82.TabIndex = 127;
            this.label82.Text = "\"Separate capture\" option allows you to start and stop video/audio";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(340, 126);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 126;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(16, 128);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(318, 20);
            this.edOutput.TabIndex = 125;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(13, 61);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 124;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            this.btOutputConfigure.Location = new System.Drawing.Point(16, 77);
            this.btOutputConfigure.Name = "btOutputConfigure";
            this.btOutputConfigure.Size = new System.Drawing.Size(75, 23);
            this.btOutputConfigure.TabIndex = 123;
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
            "MP4 (CPU)",
            "MP4 (GPU: Intel, Nvidia, AMD/ATI)",
            "MPEG-TS",
            "MOV"});
            this.cbOutputFormat.Location = new System.Drawing.Point(16, 33);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(348, 21);
            this.cbOutputFormat.TabIndex = 122;
            this.cbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputFormat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "File name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "Format";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDebugMode);
            this.tabPage4.Controls.Add(this.mmLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(382, 401);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(11, 11);
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
            this.mmLog.Location = new System.Drawing.Point(11, 34);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(358, 359);
            this.mmLog.TabIndex = 77;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 439);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.llVideoTutorials);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.Name = "Form1";
            this.Text = "Separate Capture Demo - Video Capture SDK .Net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Label label34;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbUseAudioInputFromVideoCaptureDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Button btVideoCaptureDeviceSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TrackBar tbAudioBalance;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TrackBar tbAudioVolume;
        private System.Windows.Forms.CheckBox cbRecordAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.Button btAudioInputDeviceSettings;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btOutputConfigure;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label376;
        private System.Windows.Forms.TextBox edSeparateCaptureFileSize;
        private System.Windows.Forms.Label label375;
        private System.Windows.Forms.Label label374;
        private System.Windows.Forms.TextBox edSeparateCaptureDuration;
        private System.Windows.Forms.Label label373;
        private System.Windows.Forms.RadioButton rbSeparateCaptureSplitBySize;
        private System.Windows.Forms.RadioButton rbSeparateCaptureSplitByDuration;
        private System.Windows.Forms.RadioButton rbSeparateCaptureStartManually;
        private System.Windows.Forms.Button btSeparateCaptureResume;
        private System.Windows.Forms.Button btSeparateCapturePause;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btSeparateCaptureChangeFilename;
        private System.Windows.Forms.TextBox edNewFilename;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Button btSeparateCaptureStop;
        private System.Windows.Forms.Button btSeparateCaptureStart;
    }
}

