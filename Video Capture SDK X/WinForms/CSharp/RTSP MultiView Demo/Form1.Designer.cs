namespace MediaBlocks_RTSP_MultiView_Demo
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
            label1 = new System.Windows.Forms.Label();
            edURL = new System.Windows.Forms.TextBox();
            edLogin = new System.Windows.Forms.TextBox();
            edPassword = new System.Windows.Forms.TextBox();
            cbCameraIndex = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            cbAudioEnabled = new System.Windows.Forms.CheckBox();
            cbUseMJPEG = new System.Windows.Forms.CheckBox();
            cbUseGPU = new System.Windows.Forms.CheckBox();
            cbLowLatencyMode = new System.Windows.Forms.CheckBox();
            cbGPUDecoder = new System.Windows.Forms.ComboBox();
            edLog = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            btReadInfo = new System.Windows.Forms.Button();
            videoView9 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView8 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView7 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView6 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView5 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView4 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView3 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView2 = new VisioForge.Core.UI.WinForms.VideoView();
            videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            edFilename = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            btONVIF = new System.Windows.Forms.Button();
            cbCapture = new System.Windows.Forms.CheckBox();
            cbCompatibilityMode = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(1648, 20);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(119, 25);
            label1.TabIndex = 8;
            label1.Text = "Camera index";
            // 
            // edURL
            // 
            edURL.Location = new System.Drawing.Point(1652, 95);
            edURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            edURL.Name = "edURL";
            edURL.Size = new System.Drawing.Size(456, 31);
            edURL.TabIndex = 9;
            edURL.Text = "rtsp://";
            // 
            // edLogin
            // 
            edLogin.Location = new System.Drawing.Point(1652, 178);
            edLogin.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            edLogin.Name = "edLogin";
            edLogin.Size = new System.Drawing.Size(135, 31);
            edLogin.TabIndex = 11;
            // 
            // edPassword
            // 
            edPassword.Location = new System.Drawing.Point(1794, 178);
            edPassword.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            edPassword.Name = "edPassword";
            edPassword.Size = new System.Drawing.Size(135, 31);
            edPassword.TabIndex = 12;
            // 
            // cbCameraIndex
            // 
            cbCameraIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCameraIndex.FormattingEnabled = true;
            cbCameraIndex.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            cbCameraIndex.Location = new System.Drawing.Point(1794, 16);
            cbCameraIndex.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbCameraIndex.Name = "cbCameraIndex";
            cbCameraIndex.Size = new System.Drawing.Size(88, 33);
            cbCameraIndex.TabIndex = 13;
            cbCameraIndex.SelectedIndexChanged += cbCameraIndex_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(1648, 66);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 25);
            label2.TabIndex = 14;
            label2.Text = "URL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(1648, 146);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 25);
            label3.TabIndex = 15;
            label3.Text = "Login";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(1790, 146);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(87, 25);
            label4.TabIndex = 16;
            label4.Text = "Password";
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(1786, 474);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(124, 44);
            btStop.TabIndex = 19;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(1652, 474);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(124, 44);
            btStart.TabIndex = 18;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // cbAudioEnabled
            // 
            cbAudioEnabled.AutoSize = true;
            cbAudioEnabled.Checked = true;
            cbAudioEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            cbAudioEnabled.Location = new System.Drawing.Point(1652, 232);
            cbAudioEnabled.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbAudioEnabled.Name = "cbAudioEnabled";
            cbAudioEnabled.Size = new System.Drawing.Size(140, 29);
            cbAudioEnabled.TabIndex = 20;
            cbAudioEnabled.Text = "Enable audio";
            cbAudioEnabled.UseVisualStyleBackColor = true;
            // 
            // cbUseMJPEG
            // 
            cbUseMJPEG.AutoSize = true;
            cbUseMJPEG.Location = new System.Drawing.Point(1652, 308);
            cbUseMJPEG.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbUseMJPEG.Name = "cbUseMJPEG";
            cbUseMJPEG.Size = new System.Drawing.Size(228, 29);
            cbUseMJPEG.TabIndex = 22;
            cbUseMJPEG.Text = "Use HTTP MJPEG source";
            cbUseMJPEG.UseVisualStyleBackColor = true;
            // 
            // cbUseGPU
            // 
            cbUseGPU.AutoSize = true;
            cbUseGPU.Enabled = false;
            cbUseGPU.Location = new System.Drawing.Point(1652, 345);
            cbUseGPU.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbUseGPU.Name = "cbUseGPU";
            cbUseGPU.Size = new System.Drawing.Size(250, 29);
            cbUseGPU.TabIndex = 23;
            cbUseGPU.Text = "Use custom video decoder";
            cbUseGPU.UseVisualStyleBackColor = true;
            // 
            // cbLowLatencyMode
            // 
            cbLowLatencyMode.AutoSize = true;
            cbLowLatencyMode.Location = new System.Drawing.Point(1652, 270);
            cbLowLatencyMode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbLowLatencyMode.Name = "cbLowLatencyMode";
            cbLowLatencyMode.Size = new System.Drawing.Size(182, 29);
            cbLowLatencyMode.TabIndex = 21;
            cbLowLatencyMode.Text = "Low latency mode";
            cbLowLatencyMode.UseVisualStyleBackColor = true;
            // 
            // cbGPUDecoder
            // 
            cbGPUDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbGPUDecoder.Enabled = false;
            cbGPUDecoder.FormattingEnabled = true;
            cbGPUDecoder.Location = new System.Drawing.Point(1682, 382);
            cbGPUDecoder.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbGPUDecoder.Name = "cbGPUDecoder";
            cbGPUDecoder.Size = new System.Drawing.Size(426, 33);
            cbGPUDecoder.TabIndex = 24;
            // 
            // edLog
            // 
            edLog.Location = new System.Drawing.Point(1652, 688);
            edLog.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            edLog.Multiline = true;
            edLog.Name = "edLog";
            edLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            edLog.Size = new System.Drawing.Size(456, 539);
            edLog.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(1652, 659);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(129, 25);
            label5.TabIndex = 26;
            label5.Text = "Error / info log";
            // 
            // btReadInfo
            // 
            btReadInfo.Location = new System.Drawing.Point(1959, 171);
            btReadInfo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            btReadInfo.Name = "btReadInfo";
            btReadInfo.Size = new System.Drawing.Size(151, 45);
            btReadInfo.TabIndex = 28;
            btReadInfo.Text = "Read info";
            btReadInfo.UseVisualStyleBackColor = true;
            btReadInfo.Click += btReadInfo_Click;
            // 
            // videoView9
            // 
            videoView9.BackColor = System.Drawing.Color.Black;
            videoView9.Location = new System.Drawing.Point(1092, 830);
            videoView9.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView9.Name = "videoView9";
            videoView9.Size = new System.Drawing.Size(532, 400);
            videoView9.TabIndex = 7;
            // 
            // videoView8
            // 
            videoView8.BackColor = System.Drawing.Color.Black;
            videoView8.Location = new System.Drawing.Point(552, 830);
            videoView8.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView8.Name = "videoView8";
            videoView8.Size = new System.Drawing.Size(532, 400);
            videoView8.TabIndex = 6;
            // 
            // videoView7
            // 
            videoView7.BackColor = System.Drawing.Color.Black;
            videoView7.Location = new System.Drawing.Point(12, 830);
            videoView7.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView7.Name = "videoView7";
            videoView7.Size = new System.Drawing.Size(532, 400);
            videoView7.TabIndex = 1;
            // 
            // videoView6
            // 
            videoView6.BackColor = System.Drawing.Color.Black;
            videoView6.Location = new System.Drawing.Point(1092, 422);
            videoView6.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView6.Name = "videoView6";
            videoView6.Size = new System.Drawing.Size(532, 400);
            videoView6.TabIndex = 5;
            // 
            // videoView5
            // 
            videoView5.BackColor = System.Drawing.Color.Black;
            videoView5.Location = new System.Drawing.Point(552, 422);
            videoView5.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView5.Name = "videoView5";
            videoView5.Size = new System.Drawing.Size(532, 400);
            videoView5.TabIndex = 4;
            // 
            // videoView4
            // 
            videoView4.BackColor = System.Drawing.Color.Black;
            videoView4.Location = new System.Drawing.Point(12, 422);
            videoView4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView4.Name = "videoView4";
            videoView4.Size = new System.Drawing.Size(532, 400);
            videoView4.TabIndex = 3;
            // 
            // videoView3
            // 
            videoView3.BackColor = System.Drawing.Color.Black;
            videoView3.Location = new System.Drawing.Point(1092, 15);
            videoView3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView3.Name = "videoView3";
            videoView3.Size = new System.Drawing.Size(532, 400);
            videoView3.TabIndex = 2;
            // 
            // videoView2
            // 
            videoView2.BackColor = System.Drawing.Color.Black;
            videoView2.Location = new System.Drawing.Point(552, 15);
            videoView2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView2.Name = "videoView2";
            videoView2.Size = new System.Drawing.Size(532, 400);
            videoView2.TabIndex = 1;
            // 
            // videoView1
            // 
            videoView1.BackColor = System.Drawing.Color.Black;
            videoView1.Location = new System.Drawing.Point(12, 15);
            videoView1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            videoView1.Name = "videoView1";
            videoView1.Size = new System.Drawing.Size(532, 400);
            videoView1.TabIndex = 0;
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(1652, 585);
            edFilename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(412, 31);
            edFilename.TabIndex = 32;
            edFilename.Text = "c:\\vf\\_ipcamoutput.mp4";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(2071, 545);
            button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(39, 44);
            button1.TabIndex = 33;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "ts";
            saveFileDialog1.Filter = "MPEG-TS files|*.ts";
            // 
            // btONVIF
            // 
            btONVIF.Location = new System.Drawing.Point(1959, 8);
            btONVIF.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            btONVIF.Name = "btONVIF";
            btONVIF.Size = new System.Drawing.Size(151, 80);
            btONVIF.TabIndex = 38;
            btONVIF.Text = "ONVIF discovery";
            btONVIF.UseVisualStyleBackColor = true;
            btONVIF.Click += btONVIF_Click;
            // 
            // cbCapture
            // 
            cbCapture.AutoSize = true;
            cbCapture.Location = new System.Drawing.Point(1652, 547);
            cbCapture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            cbCapture.Name = "cbCapture";
            cbCapture.Size = new System.Drawing.Size(191, 29);
            cbCapture.TabIndex = 39;
            cbCapture.Text = "Capture to MP4 file";
            cbCapture.UseVisualStyleBackColor = true;
            // 
            // cbCompatibilityMode
            // 
            cbCompatibilityMode.AutoSize = true;
            cbCompatibilityMode.Location = new System.Drawing.Point(1652, 434);
            cbCompatibilityMode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            cbCompatibilityMode.Name = "cbCompatibilityMode";
            cbCompatibilityMode.Size = new System.Drawing.Size(196, 29);
            cbCompatibilityMode.TabIndex = 27;
            cbCompatibilityMode.Text = "Compatibility mode";
            cbCompatibilityMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2131, 1242);
            Controls.Add(cbCapture);
            Controls.Add(btONVIF);
            Controls.Add(button1);
            Controls.Add(edFilename);
            Controls.Add(btReadInfo);
            Controls.Add(cbCompatibilityMode);
            Controls.Add(label5);
            Controls.Add(edLog);
            Controls.Add(cbGPUDecoder);
            Controls.Add(cbUseGPU);
            Controls.Add(cbUseMJPEG);
            Controls.Add(cbLowLatencyMode);
            Controls.Add(cbAudioEnabled);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbCameraIndex);
            Controls.Add(edPassword);
            Controls.Add(edLogin);
            Controls.Add(edURL);
            Controls.Add(label1);
            Controls.Add(videoView9);
            Controls.Add(videoView8);
            Controls.Add(videoView7);
            Controls.Add(videoView6);
            Controls.Add(videoView5);
            Controls.Add(videoView4);
            Controls.Add(videoView3);
            Controls.Add(videoView2);
            Controls.Add(videoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            Name = "Form1";
            Text = "Video Capture SDK .Net - RTSP MultiView Demo (cross-platform)";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private VisioForge.Core.UI.WinForms.VideoView videoView2;
        private VisioForge.Core.UI.WinForms.VideoView videoView3;
        private VisioForge.Core.UI.WinForms.VideoView videoView4;
        private VisioForge.Core.UI.WinForms.VideoView videoView5;
        private VisioForge.Core.UI.WinForms.VideoView videoView6;
        private VisioForge.Core.UI.WinForms.VideoView videoView7;
        private VisioForge.Core.UI.WinForms.VideoView videoView8;
        private VisioForge.Core.UI.WinForms.VideoView videoView9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edURL;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.ComboBox cbCameraIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.CheckBox cbAudioEnabled;
        private System.Windows.Forms.CheckBox cbUseMJPEG;
        private System.Windows.Forms.CheckBox cbUseGPU;
        private System.Windows.Forms.CheckBox cbLowLatencyMode;
        private System.Windows.Forms.ComboBox cbGPUDecoder;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btReadInfo;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btONVIF;
        private System.Windows.Forms.CheckBox cbCapture;
        private System.Windows.Forms.CheckBox cbCompatibilityMode;
    }
}

