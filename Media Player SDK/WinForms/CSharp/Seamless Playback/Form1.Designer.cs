namespace SeamlessPlaybackDemo
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btAddFileToPlaylist = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.lbSourceFiles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edFilenameOrURL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.MediaPlayer1 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MediaPlayer2 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(761, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // btAddFileToPlaylist
            // 
            this.btAddFileToPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddFileToPlaylist.Location = new System.Drawing.Point(800, 24);
            this.btAddFileToPlaylist.Margin = new System.Windows.Forms.Padding(2);
            this.btAddFileToPlaylist.Name = "btAddFileToPlaylist";
            this.btAddFileToPlaylist.Size = new System.Drawing.Size(38, 23);
            this.btAddFileToPlaylist.TabIndex = 28;
            this.btAddFileToPlaylist.Text = "Add";
            this.btAddFileToPlaylist.UseVisualStyleBackColor = true;
            this.btAddFileToPlaylist.Click += new System.EventHandler(this.btAddFileToPlaylist_Click);
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(446, 46);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 27;
            this.label30.Text = "Playlist";
            // 
            // lbSourceFiles
            // 
            this.lbSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceFiles.FormattingEnabled = true;
            this.lbSourceFiles.Location = new System.Drawing.Point(448, 62);
            this.lbSourceFiles.Margin = new System.Windows.Forms.Padding(2);
            this.lbSourceFiles.Name = "lbSourceFiles";
            this.lbSourceFiles.Size = new System.Drawing.Size(418, 56);
            this.lbSourceFiles.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbLoop);
            this.groupBox2.Controls.Add(this.btNextFrame);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbTime);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(12, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 90);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(330, 62);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(50, 17);
            this.cbLoop.TabIndex = 9;
            this.cbLoop.Text = "Loop";
            this.cbLoop.UseVisualStyleBackColor = true;
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = new System.Drawing.Point(249, 58);
            this.btNextFrame.Name = "btNextFrame";
            this.btNextFrame.Size = new System.Drawing.Size(75, 23);
            this.btNextFrame.TabIndex = 8;
            this.btNextFrame.Text = "Next frame";
            this.btNextFrame.UseVisualStyleBackColor = true;
            this.btNextFrame.Click += new System.EventHandler(this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(180, 58);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(46, 23);
            this.btStop.TabIndex = 7;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(122, 58);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(52, 23);
            this.btPause.TabIndex = 6;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(55, 58);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(61, 23);
            this.btResume.TabIndex = 5;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(6, 58);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(43, 23);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(321, 27);
            this.tbSpeed.Maximum = 25;
            this.tbSpeed.Minimum = -25;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(89, 45);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(322, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Speed";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(219, 27);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(96, 13);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(6, 19);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(207, 45);
            this.tbTimeline.TabIndex = 0;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(843, 24);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(23, 23);
            this.btSelectFile.TabIndex = 23;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edFilenameOrURL.Location = new System.Drawing.Point(448, 25);
            this.edFilenameOrURL.Name = "edFilenameOrURL";
            this.edFilenameOrURL.Size = new System.Drawing.Size(348, 20);
            this.edFilenameOrURL.TabIndex = 22;
            this.edFilenameOrURL.Text = "c:\\Samples\\!video.avi";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(446, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "File name or URL";
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(448, 342);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(418, 78);
            this.mmLog.TabIndex = 32;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(449, 319);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 31;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
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
            this.MediaPlayer1.Audio_PlayAudio = true;
            this.MediaPlayer1.Audio_Sample_Grabber_Enabled = true;
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
            this.MediaPlayer1.CustomRedist_Enabled = false;
            this.MediaPlayer1.CustomRedist_Path = null;
            this.MediaPlayer1.Debug_DeepCleanUp = false;
            this.MediaPlayer1.Debug_Dir = null;
            this.MediaPlayer1.Debug_Mode = false;
            this.MediaPlayer1.Debug_Telemetry = false;
            this.MediaPlayer1.Encryption_Key = "";
            this.MediaPlayer1.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer1.Face_Tracking = null;
            this.MediaPlayer1.Info_UseLibMediaInfo = false;
            this.MediaPlayer1.Location = new System.Drawing.Point(14, 8);
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
            this.MediaPlayer1.Size = new System.Drawing.Size(418, 312);
            this.MediaPlayer1.Source_Custom_CLSID = null;
            this.MediaPlayer1.Source_GPU_Mode = VisioForge.Types.VFMediaPlayerSourceGPUDecoder.nVidiaCUVID;
            this.MediaPlayer1.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer1.Source_Stream = null;
            this.MediaPlayer1.Source_Stream_AudioPresent = false;
            this.MediaPlayer1.Source_Stream_Size = ((long)(0));
            this.MediaPlayer1.Source_Stream_VideoPresent = false;
            this.MediaPlayer1.TabIndex = 30;
            this.MediaPlayer1.Video_Effects_Enabled = false;
            this.MediaPlayer1.Video_Effects_GPU_Enabled = false;
            this.MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer1.Video_Stream_Index = 0;
            this.MediaPlayer1.Virtual_Camera_Output_Enabled = false;
            this.MediaPlayer1.Virtual_Camera_Output_LicenseKey = null;
            this.MediaPlayer1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.MediaPlayer1_OnError);
            this.MediaPlayer1.OnStop += new System.EventHandler<VisioForge.Types.MediaPlayerStopEventArgs>(this.MediaPlayer1_OnStop);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MediaPlayer2
            // 
            this.MediaPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MediaPlayer2.Audio_Channel_Mapper = null;
            this.MediaPlayer2.Audio_Effects_Enabled = false;
            this.MediaPlayer2.Audio_Effects_UseLegacyEffects = false;
            this.MediaPlayer2.Audio_Enhancer_Enabled = false;
            this.MediaPlayer2.Audio_OutputDevice = "";
            this.MediaPlayer2.Audio_PlayAudio = true;
            this.MediaPlayer2.Audio_Sample_Grabber_Enabled = true;
            this.MediaPlayer2.Audio_VUMeter_Enabled = false;
            this.MediaPlayer2.Audio_VUMeter_Pro_Enabled = false;
            this.MediaPlayer2.Audio_VUMeter_Pro_Volume = 0;
            this.MediaPlayer2.BackColor = System.Drawing.Color.Black;
            this.MediaPlayer2.Barcode_Reader_Enabled = false;
            this.MediaPlayer2.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.MediaPlayer2.ChromaKey = null;
            this.MediaPlayer2.Custom_Audio_Decoder = null;
            this.MediaPlayer2.Custom_Splitter = null;
            this.MediaPlayer2.Custom_Video_Decoder = null;
            this.MediaPlayer2.CustomRedist_Enabled = false;
            this.MediaPlayer2.CustomRedist_Path = null;
            this.MediaPlayer2.Debug_DeepCleanUp = false;
            this.MediaPlayer2.Debug_Dir = null;
            this.MediaPlayer2.Debug_Mode = false;
            this.MediaPlayer2.Debug_Telemetry = false;
            this.MediaPlayer2.Encryption_Key = "";
            this.MediaPlayer2.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer2.Face_Tracking = null;
            this.MediaPlayer2.Info_UseLibMediaInfo = false;
            this.MediaPlayer2.Location = new System.Drawing.Point(14, 8);
            this.MediaPlayer2.Loop = false;
            this.MediaPlayer2.Loop_DoNotSeekToBeginning = false;
            this.MediaPlayer2.MaximalSpeedPlayback = false;
            this.MediaPlayer2.MIDI_Renderer = null;
            this.MediaPlayer2.Motion_Detection = null;
            this.MediaPlayer2.Motion_DetectionEx = null;
            this.MediaPlayer2.MultiScreen_Enabled = false;
            this.MediaPlayer2.Name = "MediaPlayer2";
            this.MediaPlayer2.OSD_Enabled = false;
            this.MediaPlayer2.Play_DelayEnabled = false;
            this.MediaPlayer2.Play_PauseAtFirstFrame = false;
            this.MediaPlayer2.ReversePlayback_CacheSize = 0;
            this.MediaPlayer2.ReversePlayback_Enabled = false;
            this.MediaPlayer2.Selection_Active = false;
            this.MediaPlayer2.Selection_Start = 0;
            this.MediaPlayer2.Selection_Stop = 0;
            this.MediaPlayer2.Size = new System.Drawing.Size(418, 312);
            this.MediaPlayer2.Source_Custom_CLSID = null;
            this.MediaPlayer2.Source_GPU_Mode = VisioForge.Types.VFMediaPlayerSourceGPUDecoder.nVidiaCUVID;
            this.MediaPlayer2.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer2.Source_Stream = null;
            this.MediaPlayer2.Source_Stream_AudioPresent = false;
            this.MediaPlayer2.Source_Stream_Size = ((long)(0));
            this.MediaPlayer2.Source_Stream_VideoPresent = false;
            this.MediaPlayer2.TabIndex = 33;
            this.MediaPlayer2.Video_Effects_Enabled = false;
            this.MediaPlayer2.Video_Effects_GPU_Enabled = false;
            this.MediaPlayer2.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer2.Video_Stream_Index = 0;
            this.MediaPlayer2.Virtual_Camera_Output_Enabled = false;
            this.MediaPlayer2.Virtual_Camera_Output_LicenseKey = null;
            this.MediaPlayer2.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.MediaPlayer2_OnError);
            this.MediaPlayer2.OnStop += new System.EventHandler<VisioForge.Types.MediaPlayerStopEventArgs>(this.MediaPlayer2_OnStop);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 431);
            this.Controls.Add(this.MediaPlayer2);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.MediaPlayer1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btAddFileToPlaylist);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lbSourceFiles);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Seamless Playback Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btAddFileToPlaylist;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ListBox lbSourceFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilenameOrURL;
        private System.Windows.Forms.Label label14;
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer1;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer2;
    }
}

