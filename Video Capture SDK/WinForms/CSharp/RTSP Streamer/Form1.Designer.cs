namespace RTSP_Streamer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            lbTimestamp = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            llVideoTutorials = new System.Windows.Forms.LinkLabel();
            fontDialog1 = new System.Windows.Forms.FontDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            btVideoCaptureDeviceSettings = new System.Windows.Forms.Button();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            btStart = new System.Windows.Forms.Button();
            tcMain = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            label11 = new System.Windows.Forms.Label();
            btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            cbAudioInputLine = new System.Windows.Forms.ComboBox();
            cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            edNetworkUDPURL = new System.Windows.Forms.TextBox();
            label372 = new System.Windows.Forms.Label();
            btStop = new System.Windows.Forms.Button();
            tabPage4.SuspendLayout();
            tcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(650, 52);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(747, 650);
            VideoView1.TabIndex = 121;
            // 
            // lbTimestamp
            // 
            lbTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(1190, 796);
            lbTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(209, 25);
            lbTimestamp.TabIndex = 117;
            lbTimestamp.Text = "Streaming time: 00:00:00";
            // 
            // label34
            // 
            label34.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(839, 11);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(361, 25);
            label34.TabIndex = 114;
            label34.Text = "Much more features available in Main Demo";
            // 
            // llVideoTutorials
            // 
            llVideoTutorials.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            llVideoTutorials.AutoSize = true;
            llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            llVideoTutorials.Location = new System.Drawing.Point(1246, 11);
            llVideoTutorials.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llVideoTutorials.Name = "llVideoTutorials";
            llVideoTutorials.Size = new System.Drawing.Size(167, 25);
            llVideoTutorials.TabIndex = 113;
            llVideoTutorials.TabStop = true;
            llVideoTutorials.Text = "View video tutorials";
            llVideoTutorials.LinkClicked += llVideoTutorials_LinkClicked;
            // 
            // fontDialog1
            // 
            fontDialog1.Color = System.Drawing.Color.White;
            fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            fontDialog1.FontMustExist = true;
            fontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(18, 21);
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
            mmLog.Location = new System.Drawing.Point(18, 65);
            mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmLog.Size = new System.Drawing.Size(574, 686);
            mmLog.TabIndex = 77;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(cbDebugMode);
            tabPage4.Controls.Add(mmLog);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage4.Size = new System.Drawing.Size(622, 783);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(564, 178);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 25);
            label1.TabIndex = 128;
            label1.Text = "fps";
            // 
            // btVideoCaptureDeviceSettings
            // 
            btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(449, 65);
            btVideoCaptureDeviceSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(110, 44);
            btVideoCaptureDeviceSettings.TabIndex = 126;
            btVideoCaptureDeviceSettings.Text = "Settings";
            btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            btVideoCaptureDeviceSettings.Click += btVideoCaptureDeviceSettings_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(443, 140);
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
            cbVideoInputFrameRate.Location = new System.Drawing.Point(449, 171);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(16, 171);
            cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputFormat.Name = "cbVideoInputFormat";
            cbVideoInputFormat.Size = new System.Drawing.Size(408, 33);
            cbVideoInputFormat.TabIndex = 123;
            cbVideoInputFormat.SelectedIndexChanged += cbVideoInputFormat_SelectedIndexChanged;
            // 
            // cbVideoInputDevice
            // 
            cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputDevice.FormattingEnabled = true;
            cbVideoInputDevice.Location = new System.Drawing.Point(16, 69);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(408, 33);
            cbVideoInputDevice.TabIndex = 122;
            cbVideoInputDevice.SelectedIndexChanged += cbVideoInputDevice_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(9, 140);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(163, 25);
            label13.TabIndex = 121;
            label13.Text = "Video input format";
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStart.Location = new System.Drawing.Point(650, 788);
            btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 111;
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
            tcMain.Location = new System.Drawing.Point(8, 11);
            tcMain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new System.Drawing.Size(630, 821);
            tcMain.TabIndex = 110;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btVideoCaptureDeviceSettings);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(cbVideoInputFrameRate);
            tabPage1.Controls.Add(cbVideoInputFormat);
            tabPage1.Controls.Add(cbVideoInputDevice);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(btAudioInputDeviceSettings);
            tabPage1.Controls.Add(cbAudioInputLine);
            tabPage1.Controls.Add(cbAudioInputFormat);
            tabPage1.Controls.Add(cbAudioInputDevice);
            tabPage1.Controls.Add(label22);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(label25);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage1.Size = new System.Drawing.Size(622, 783);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Devices";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(10, 39);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(159, 25);
            label11.TabIndex = 120;
            label11.Text = "Video input device";
            // 
            // btAudioInputDeviceSettings
            // 
            btAudioInputDeviceSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btAudioInputDeviceSettings.Location = new System.Drawing.Point(478, 360);
            btAudioInputDeviceSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            btAudioInputDeviceSettings.Size = new System.Drawing.Size(127, 44);
            btAudioInputDeviceSettings.TabIndex = 82;
            btAudioInputDeviceSettings.Text = "Settings";
            btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            btAudioInputDeviceSettings.Click += btAudioInputDeviceSettings_Click;
            // 
            // cbAudioInputLine
            // 
            cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputLine.FormattingEnabled = true;
            cbAudioInputLine.Location = new System.Drawing.Point(13, 471);
            cbAudioInputLine.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioInputLine.Name = "cbAudioInputLine";
            cbAudioInputLine.Size = new System.Drawing.Size(266, 33);
            cbAudioInputLine.TabIndex = 81;
            // 
            // cbAudioInputFormat
            // 
            cbAudioInputFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputFormat.FormattingEnabled = true;
            cbAudioInputFormat.Location = new System.Drawing.Point(304, 471);
            cbAudioInputFormat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioInputFormat.Name = "cbAudioInputFormat";
            cbAudioInputFormat.Size = new System.Drawing.Size(297, 33);
            cbAudioInputFormat.TabIndex = 80;
            // 
            // cbAudioInputDevice
            // 
            cbAudioInputDevice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputDevice.FormattingEnabled = true;
            cbAudioInputDevice.Location = new System.Drawing.Point(13, 364);
            cbAudioInputDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cbAudioInputDevice.Name = "cbAudioInputDevice";
            cbAudioInputDevice.Size = new System.Drawing.Size(451, 33);
            cbAudioInputDevice.TabIndex = 79;
            cbAudioInputDevice.SelectedIndexChanged += cbAudioInputDevice_SelectedIndexChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(10, 440);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(138, 25);
            label22.TabIndex = 78;
            label22.Text = "Audio input line";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(10, 332);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(161, 25);
            label23.TabIndex = 77;
            label23.Text = "Audio input device";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(300, 436);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(113, 25);
            label25.TabIndex = 76;
            label25.Text = "Input format";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(edNetworkUDPURL);
            tabPage2.Controls.Add(label372);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tabPage2.Size = new System.Drawing.Size(622, 783);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // edNetworkUDPURL
            // 
            edNetworkUDPURL.Location = new System.Drawing.Point(26, 58);
            edNetworkUDPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edNetworkUDPURL.Name = "edNetworkUDPURL";
            edNetworkUDPURL.Size = new System.Drawing.Size(556, 31);
            edNetworkUDPURL.TabIndex = 21;
            edNetworkUDPURL.Text = "rtsp://127.0.0.1:7777/test";
            // 
            // label372
            // 
            label372.AutoSize = true;
            label372.Location = new System.Drawing.Point(26, 27);
            label372.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label372.Name = "label372";
            label372.Size = new System.Drawing.Size(43, 25);
            label372.TabIndex = 20;
            label372.Text = "URL";
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStop.Location = new System.Drawing.Point(763, 788);
            btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 112;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1413, 844);
            Controls.Add(VideoView1);
            Controls.Add(lbTimestamp);
            Controls.Add(label34);
            Controls.Add(llVideoTutorials);
            Controls.Add(btStart);
            Controls.Add(tcMain);
            Controls.Add(btStop);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "RTSP Streamer Demo - Video Capture SDK .Net";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Label label34;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btVideoCaptureDeviceSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btAudioInputDeviceSettings;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.TextBox edNetworkUDPURL;
        private System.Windows.Forms.Label label372;
    }
}
