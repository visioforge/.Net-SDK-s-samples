namespace Video_Join_Demo
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

            mp4SettingsDialog?.Dispose();
            mp4SettingsDialog = null;

            mp4HWSettingsDialog?.Dispose();
            mp4HWSettingsDialog = null;

            mp3SettingsDialog?.Dispose();
            mp3SettingsDialog = null;

            m4aSettingsDialog?.Dispose();
            m4aSettingsDialog = null;

            gifSettingsDialog?.Dispose();
            gifSettingsDialog = null;

            flacSettingsDialog?.Dispose();
            flacSettingsDialog = null;

            ffmpegSettingsDialog?.Dispose();
            ffmpegSettingsDialog = null;

            ffmpegEXESettingsDialog?.Dispose();
            ffmpegEXESettingsDialog = null;

            dvSettingsDialog?.Dispose();
            dvSettingsDialog = null;

            aviSettingsDialog?.Dispose();
            aviSettingsDialog = null;

            customFormatSettingsDialog?.Dispose();
            customFormatSettingsDialog = null;

            wmvSettingsDialog?.Dispose();
            wmvSettingsDialog = null;

            webmSettingsDialog?.Dispose();
            webmSettingsDialog = null;

            speexSettingsDialog?.Dispose();
            speexSettingsDialog = null;

            pcmSettingsDialog?.Dispose();
            pcmSettingsDialog = null;

            oggVorbisSettingsDialog?.Dispose();
            oggVorbisSettingsDialog = null;

            VideoEdit1?.Dispose();
            VideoEdit1 = null;

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
            lbInfo = new System.Windows.Forms.Label();
            btConfigure = new System.Windows.Forms.Button();
            btSelectOutput = new System.Windows.Forms.Button();
            label15 = new System.Windows.Forms.Label();
            cbOutputVideoFormat = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            edOutput = new System.Windows.Forms.TextBox();
            cbLicensing = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            ProgressBar1 = new System.Windows.Forms.ProgressBar();
            btClearList = new System.Windows.Forms.Button();
            btAddInputFile = new System.Windows.Forms.Button();
            lbFiles = new System.Windows.Forms.ListBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            label10 = new System.Windows.Forms.Label();
            OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            cbFrameRate = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            edHeight = new System.Windows.Forms.TextBox();
            edWidth = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            cbResize = new System.Windows.Forms.CheckBox();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            linkLabelDecoders = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(18, 402);
            lbInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 99;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btConfigure
            // 
            btConfigure.Location = new System.Drawing.Point(573, 340);
            btConfigure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btConfigure.Name = "btConfigure";
            btConfigure.Size = new System.Drawing.Size(102, 44);
            btConfigure.TabIndex = 95;
            btConfigure.Text = "Configure";
            btConfigure.UseVisualStyleBackColor = true;
            btConfigure.Click += BtConfigure_Click;
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(632, 498);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(43, 44);
            btSelectOutput.TabIndex = 94;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += BtSelectOutput_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(18, 467);
            label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(87, 25);
            label15.TabIndex = 92;
            label15.Text = "File name";
            // 
            // cbOutputVideoFormat
            // 
            cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputVideoFormat.FormattingEnabled = true;
            cbOutputVideoFormat.Items.AddRange(new object[] { "AVI", "MKV (Matroska)", "WMV (Windows Media Video)", "DV", "PCM/ACM", "MP3", "M4A (AAC)", "WMA (Windows Media Audio)", "Ogg Vorbis", "FLAC", "Speex", "Custom format", "WebM", "FFMPEG (DLL)", "FFMPEG (external exe) (BETA)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video" });
            cbOutputVideoFormat.Location = new System.Drawing.Point(23, 344);
            cbOutputVideoFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbOutputVideoFormat.Name = "cbOutputVideoFormat";
            cbOutputVideoFormat.Size = new System.Drawing.Size(532, 33);
            cbOutputVideoFormat.TabIndex = 91;
            cbOutputVideoFormat.SelectedIndexChanged += CbOutputVideoFormat_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(18, 310);
            label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(128, 25);
            label9.TabIndex = 90;
            label9.Text = "Output format";
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Checked = true;
            cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            cbTelemetry.Location = new System.Drawing.Point(258, 579);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(113, 29);
            cbTelemetry.TabIndex = 104;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(23, 502);
            edOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(596, 31);
            edOutput.TabIndex = 93;
            edOutput.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(130, 579);
            cbLicensing.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(110, 29);
            cbLicensing.TabIndex = 103;
            cbLicensing.Text = "Licensing";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(23, 623);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmLog.Size = new System.Drawing.Size(649, 83);
            mmLog.TabIndex = 101;
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(1327, 648);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(97, 44);
            btStop.TabIndex = 89;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += BtStop_Click;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(1215, 648);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(97, 44);
            btStart.TabIndex = 88;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += BtStart_Click;
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new System.Drawing.Point(703, 648);
            ProgressBar1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new System.Drawing.Size(502, 42);
            ProgressBar1.TabIndex = 87;
            // 
            // btClearList
            // 
            btClearList.Location = new System.Drawing.Point(568, 113);
            btClearList.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btClearList.Name = "btClearList";
            btClearList.Size = new System.Drawing.Size(107, 44);
            btClearList.TabIndex = 100;
            btClearList.Text = "Clear";
            btClearList.UseVisualStyleBackColor = true;
            btClearList.Click += BtClearList_Click;
            // 
            // btAddInputFile
            // 
            btAddInputFile.Location = new System.Drawing.Point(568, 58);
            btAddInputFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btAddInputFile.Name = "btAddInputFile";
            btAddInputFile.Size = new System.Drawing.Size(107, 44);
            btAddInputFile.TabIndex = 98;
            btAddInputFile.Text = "Add";
            btAddInputFile.UseVisualStyleBackColor = true;
            btAddInputFile.Click += BtAddInputFile_Click;
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 25;
            lbFiles.Location = new System.Drawing.Point(23, 58);
            lbFiles.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new System.Drawing.Size(532, 104);
            lbFiles.TabIndex = 97;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(23, 579);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 102;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(18, 23);
            label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(90, 25);
            label10.TabIndex = 96;
            label10.Text = "Input files";
            // 
            // OpenDialog1
            // 
            OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            SaveDialog1.Filter = "AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|All files  (*.*)| *.*";
            // 
            // cbFrameRate
            // 
            cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFrameRate.FormattingEnabled = true;
            cbFrameRate.Items.AddRange(new object[] { "0", "1", "2", "5", "10", "12", "15", "20", "25", "30" });
            cbFrameRate.Location = new System.Drawing.Point(515, 242);
            cbFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFrameRate.Name = "cbFrameRate";
            cbFrameRate.Size = new System.Drawing.Size(157, 33);
            cbFrameRate.TabIndex = 169;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 248);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(469, 25);
            label3.TabIndex = 168;
            label3.Text = "Frame rate (Use 0 to have original, set before adding files)";
            // 
            // edHeight
            // 
            edHeight.Location = new System.Drawing.Point(267, 185);
            edHeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edHeight.Name = "edHeight";
            edHeight.Size = new System.Drawing.Size(77, 31);
            edHeight.TabIndex = 167;
            edHeight.Text = "576";
            // 
            // edWidth
            // 
            edWidth.Location = new System.Drawing.Point(147, 185);
            edWidth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edWidth.Name = "edWidth";
            edWidth.Size = new System.Drawing.Size(77, 31);
            edWidth.TabIndex = 166;
            edWidth.Text = "768";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(237, 188);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 25);
            label2.TabIndex = 165;
            label2.Text = "x";
            // 
            // cbResize
            // 
            cbResize.AutoSize = true;
            cbResize.Location = new System.Drawing.Point(25, 188);
            cbResize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbResize.Name = "cbResize";
            cbResize.Size = new System.Drawing.Size(86, 29);
            cbResize.TabIndex = 164;
            cbResize.Text = "Resize";
            cbResize.UseVisualStyleBackColor = true;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(703, 23);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(720, 588);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 170;
            // 
            // linkLabelDecoders
            // 
            linkLabelDecoders.AutoSize = true;
            linkLabelDecoders.Location = new System.Drawing.Point(129, 23);
            linkLabelDecoders.Name = "linkLabelDecoders";
            linkLabelDecoders.Size = new System.Drawing.Size(546, 25);
            linkLabelDecoders.TabIndex = 171;
            linkLabelDecoders.TabStop = true;
            linkLabelDecoders.Text = "[NuGet only] Install decoders if you can see errors while adding files";
            linkLabelDecoders.LinkClicked += linkLabelDecoders_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1443, 729);
            Controls.Add(linkLabelDecoders);
            Controls.Add(VideoView1);
            Controls.Add(cbFrameRate);
            Controls.Add(label3);
            Controls.Add(edHeight);
            Controls.Add(edWidth);
            Controls.Add(label2);
            Controls.Add(cbResize);
            Controls.Add(lbInfo);
            Controls.Add(btConfigure);
            Controls.Add(btSelectOutput);
            Controls.Add(label15);
            Controls.Add(cbOutputVideoFormat);
            Controls.Add(label9);
            Controls.Add(cbTelemetry);
            Controls.Add(edOutput);
            Controls.Add(cbLicensing);
            Controls.Add(mmLog);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(ProgressBar1);
            Controls.Add(btClearList);
            Controls.Add(btAddInputFile);
            Controls.Add(lbFiles);
            Controls.Add(cbDebugMode);
            Controls.Add(label10);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "VisioForge Video Edit SDK .Net - Video Join Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btConfigure;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbOutputVideoFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button btClearList;
        private System.Windows.Forms.Button btAddInputFile;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog OpenDialog1;
        private System.Windows.Forms.SaveFileDialog SaveDialog1;
        private System.Windows.Forms.ComboBox cbFrameRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbResize;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.LinkLabel linkLabelDecoders;
    }
}

