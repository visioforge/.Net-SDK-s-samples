namespace Multiple_Video_Streams_Demo
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
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edFilenameOrURL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.MediaPlayer1 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.pnScreen1 = new System.Windows.Forms.Panel();
            this.pnScreen3 = new System.Windows.Forms.Panel();
            this.pnScreen2 = new System.Windows.Forms.Panel();
            this.pnScreen4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // btSelectFile
            // 
            this.btSelectFile.Location = new System.Drawing.Point(406, 23);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(23, 23);
            this.btSelectFile.TabIndex = 7;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Location = new System.Drawing.Point(15, 25);
            this.edFilenameOrURL.Name = "edFilenameOrURL";
            this.edFilenameOrURL.Size = new System.Drawing.Size(385, 20);
            this.edFilenameOrURL.TabIndex = 6;
            this.edFilenameOrURL.Text = "c:\\Samples\\3_video_streams.asf";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(251, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "File name (file should contain several video streams)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btNextFrame);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.lbTime);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(15, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
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
            this.MediaPlayer1.Debug_DeepCleanUp = false;
            this.MediaPlayer1.Debug_Dir = null;
            this.MediaPlayer1.Debug_Mode = false;
            this.MediaPlayer1.Encryption_Key = "";
            this.MediaPlayer1.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer1.Face_Tracking = null;
            this.MediaPlayer1.Info_UseLibMediaInfo = false;
            this.MediaPlayer1.Location = new System.Drawing.Point(15, 52);
            this.MediaPlayer1.Loop = false;
            this.MediaPlayer1.Loop_DoNotSeekToBeginning = false;
            this.MediaPlayer1.MaximalSpeedPlayback = false;
            this.MediaPlayer1.Motion_Detection = null;
            this.MediaPlayer1.Motion_DetectionEx = null;
            this.MediaPlayer1.MultiScreen_Enabled = false;
            this.MediaPlayer1.Name = "MediaPlayer1";
            this.MediaPlayer1.ReversePlayback_CacheSize = 0;
            this.MediaPlayer1.ReversePlayback_Enabled = false;
            this.MediaPlayer1.Selection_Active = false;
            this.MediaPlayer1.Selection_Start = 0;
            this.MediaPlayer1.Selection_Stop = 0;
            this.MediaPlayer1.Size = new System.Drawing.Size(414, 280);
            this.MediaPlayer1.Source_Custom_CLSID = null;
            this.MediaPlayer1.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer1.Source_Stream = null;
            this.MediaPlayer1.Source_Stream_AudioPresent = true;
            this.MediaPlayer1.Source_Stream_Size = ((long)(0));
            this.MediaPlayer1.Source_Stream_VideoPresent = true;
            this.MediaPlayer1.Play_DelayEnabled = false;
            this.MediaPlayer1.TabIndex = 9;
            this.MediaPlayer1.Video_Effects_Enabled = false;
            this.MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer1.Video_Stream_Index = 0;
            this.MediaPlayer1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.MediaPlayer1_OnError);
            this.MediaPlayer1.OnStop += new System.EventHandler<VisioForge.Types.MediaPlayerStopEventArgs>(this.MediaPlayer1_OnStop);
            // 
            // pnScreen1
            // 
            this.pnScreen1.BackColor = System.Drawing.Color.Black;
            this.pnScreen1.Location = new System.Drawing.Point(468, 25);
            this.pnScreen1.Name = "pnScreen1";
            this.pnScreen1.Size = new System.Drawing.Size(320, 240);
            this.pnScreen1.TabIndex = 10;
            // 
            // pnScreen3
            // 
            this.pnScreen3.BackColor = System.Drawing.Color.Black;
            this.pnScreen3.Location = new System.Drawing.Point(468, 271);
            this.pnScreen3.Name = "pnScreen3";
            this.pnScreen3.Size = new System.Drawing.Size(320, 240);
            this.pnScreen3.TabIndex = 11;
            // 
            // pnScreen2
            // 
            this.pnScreen2.BackColor = System.Drawing.Color.Black;
            this.pnScreen2.Location = new System.Drawing.Point(794, 25);
            this.pnScreen2.Name = "pnScreen2";
            this.pnScreen2.Size = new System.Drawing.Size(320, 240);
            this.pnScreen2.TabIndex = 12;
            // 
            // pnScreen4
            // 
            this.pnScreen4.BackColor = System.Drawing.Color.Black;
            this.pnScreen4.Location = new System.Drawing.Point(794, 271);
            this.pnScreen4.Name = "pnScreen4";
            this.pnScreen4.Size = new System.Drawing.Size(320, 240);
            this.pnScreen4.TabIndex = 13;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(15, 457);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(414, 54);
            this.mmLog.TabIndex = 15;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(15, 434);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 14;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 527);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.pnScreen4);
            this.Controls.Add(this.pnScreen2);
            this.Controls.Add(this.pnScreen3);
            this.Controls.Add(this.pnScreen1);
            this.Controls.Add(this.MediaPlayer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Multiple Video Streams Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilenameOrURL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer1;
        private System.Windows.Forms.Panel pnScreen1;
        private System.Windows.Forms.Panel pnScreen3;
        private System.Windows.Forms.Panel pnScreen2;
        private System.Windows.Forms.Panel pnScreen4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Timer timer1;
    }
}

