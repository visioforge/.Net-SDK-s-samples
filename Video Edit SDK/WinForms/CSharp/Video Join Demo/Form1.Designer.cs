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
            this.lbInfo = new System.Windows.Forms.Label();
            this.btConfigure = new System.Windows.Forms.Button();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cbOutputVideoFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.cbLicensing = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.btClearList = new System.Windows.Forms.Button();
            this.btAddInputFile = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.VideoEdit1 = new VisioForge.Controls.UI.WinForms.VideoEdit();
            this.OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbFrameRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edHeight = new System.Windows.Forms.TextBox();
            this.edWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(11, 209);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 99;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btConfigure
            // 
            this.btConfigure.Location = new System.Drawing.Point(344, 177);
            this.btConfigure.Name = "btConfigure";
            this.btConfigure.Size = new System.Drawing.Size(61, 23);
            this.btConfigure.TabIndex = 95;
            this.btConfigure.Text = "Configure";
            this.btConfigure.UseVisualStyleBackColor = true;
            this.btConfigure.Click += new System.EventHandler(this.BtConfigure_Click);
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(379, 259);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(26, 23);
            this.btSelectOutput.TabIndex = 94;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.BtSelectOutput_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 92;
            this.label15.Text = "File name";
            // 
            // cbOutputVideoFormat
            // 
            this.cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputVideoFormat.FormattingEnabled = true;
            this.cbOutputVideoFormat.Items.AddRange(new object[] {
            "AVI",
            "MKV (Matroska)",
            "WMV (Windows Media Video)",
            "DV",
            "PCM/ACM",
            "MP3",
            "M4A (AAC)",
            "WMA (Windows Media Audio)",
            "Ogg Vorbis",
            "FLAC",
            "Speex",
            "Custom format",
            "WebM",
            "FFMPEG (DLL)",
            "FFMPEG (external exe) (BETA)",
            "MP4 v8/v10",
            "MP4 v11",
            "Animated GIF",
            "Encrypted video"});
            this.cbOutputVideoFormat.Location = new System.Drawing.Point(14, 179);
            this.cbOutputVideoFormat.Name = "cbOutputVideoFormat";
            this.cbOutputVideoFormat.Size = new System.Drawing.Size(321, 21);
            this.cbOutputVideoFormat.TabIndex = 91;
            this.cbOutputVideoFormat.SelectedIndexChanged += new System.EventHandler(this.CbOutputVideoFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Output format";
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(155, 301);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(72, 17);
            this.cbTelemetry.TabIndex = 104;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(14, 261);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(359, 20);
            this.edOutput.TabIndex = 93;
            this.edOutput.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(78, 301);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(71, 17);
            this.cbLicensing.TabIndex = 103;
            this.cbLicensing.Text = "Licensing";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(14, 324);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(391, 45);
            this.mmLog.TabIndex = 101;
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(796, 337);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(58, 23);
            this.btStop.TabIndex = 89;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(729, 337);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(58, 23);
            this.btStart.TabIndex = 88;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.BtStart_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(422, 337);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(301, 22);
            this.ProgressBar1.TabIndex = 87;
            // 
            // btClearList
            // 
            this.btClearList.Location = new System.Drawing.Point(341, 59);
            this.btClearList.Name = "btClearList";
            this.btClearList.Size = new System.Drawing.Size(64, 23);
            this.btClearList.TabIndex = 100;
            this.btClearList.Text = "Clear";
            this.btClearList.UseVisualStyleBackColor = true;
            this.btClearList.Click += new System.EventHandler(this.BtClearList_Click);
            // 
            // btAddInputFile
            // 
            this.btAddInputFile.Location = new System.Drawing.Point(341, 30);
            this.btAddInputFile.Name = "btAddInputFile";
            this.btAddInputFile.Size = new System.Drawing.Size(64, 23);
            this.btAddInputFile.TabIndex = 98;
            this.btAddInputFile.Text = "Add";
            this.btAddInputFile.UseVisualStyleBackColor = true;
            this.btAddInputFile.Click += new System.EventHandler(this.BtAddInputFile_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(14, 30);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(321, 56);
            this.lbFiles.TabIndex = 97;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(14, 301);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(58, 17);
            this.cbDebugMode.TabIndex = 102;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "Input files";
            // 
            // VideoEdit1
            // 
            this.VideoEdit1.Audio_Channel_Mapper = null;
            this.VideoEdit1.Audio_Effects_Enabled = false;
            this.VideoEdit1.Audio_Effects_UseLegacyEffects = false;
            this.VideoEdit1.Audio_Enhancer_Enabled = false;
            this.VideoEdit1.Audio_Preview_Enabled = false;
            this.VideoEdit1.Audio_VUMeter_Enabled = false;
            this.VideoEdit1.Audio_VUMeter_Pro_Enabled = false;
            this.VideoEdit1.Audio_VUMeter_Pro_Volume = 0;
            this.VideoEdit1.BackColor = System.Drawing.Color.Black;
            this.VideoEdit1.Barcode_Reader_Enabled = false;
            this.VideoEdit1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.VideoEdit1.ChromaKey = null;
            this.VideoEdit1.CustomRedist_Auto = true;
            this.VideoEdit1.CustomRedist_Enabled = false;
            this.VideoEdit1.CustomRedist_Path = null;
            this.VideoEdit1.Debug_Dir = "";
            this.VideoEdit1.Debug_Mode = false;
            this.VideoEdit1.Debug_Telemetry = false;
            this.VideoEdit1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.Auto;
            this.VideoEdit1.Decklink_Output = null;
            this.VideoEdit1.Dynamic_Reconnection = false;
            this.VideoEdit1.Location = new System.Drawing.Point(422, 12);
            this.VideoEdit1.Loop = false;
            this.VideoEdit1.Mode = VisioForge.Types.VFVideoEditMode.Convert;
            this.VideoEdit1.Motion_Detection = null;
            this.VideoEdit1.Motion_DetectionEx = null;
            this.VideoEdit1.Name = "VideoEdit1";
            this.VideoEdit1.Network_Streaming_Audio_Enabled = false;
            this.VideoEdit1.Network_Streaming_Enabled = false;
            this.VideoEdit1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV;
            this.VideoEdit1.Network_Streaming_Network_Port = 0;
            this.VideoEdit1.Network_Streaming_Output = null;
            this.VideoEdit1.Network_Streaming_URL = null;
            this.VideoEdit1.Network_Streaming_WMV_Maximum_Clients = 0;
            this.VideoEdit1.Output_Filename = "c:\\output.avi";
            this.VideoEdit1.Output_Format = null;
            this.VideoEdit1.Size = new System.Drawing.Size(433, 319);
            this.VideoEdit1.Start_DelayEnabled = false;
            this.VideoEdit1.TabIndex = 105;
            this.VideoEdit1.Tags = null;
            this.VideoEdit1.UseLibMediaInfo = false;
            this.VideoEdit1.Video_Crop = null;
            this.VideoEdit1.Video_Custom_Resizer_CLSID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.VideoEdit1.Video_Effects_AllowMultipleStreams = false;
            this.VideoEdit1.Video_Effects_Enabled = false;
            this.VideoEdit1.Video_Effects_GPU_Enabled = false;
            this.VideoEdit1.Video_FrameRate = 25D;
            this.VideoEdit1.Video_Preview_Enabled = true;
            this.VideoEdit1.Video_Resize = false;
            this.VideoEdit1.Video_Resize_Height = 480;
            this.VideoEdit1.Video_Resize_Width = 640;
            this.VideoEdit1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.VideoEdit1.Video_Subtitles = null;
            this.VideoEdit1.Virtual_Camera_Output_Enabled = false;
            this.VideoEdit1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoEdit1_OnError);
            this.VideoEdit1.OnProgress += new System.EventHandler<VisioForge.Types.ProgressEventArgs>(this.VideoEdit1_OnProgress);
            this.VideoEdit1.OnStop += new System.EventHandler<VisioForge.Types.VideoEditStopEventArgs>(this.VideoEdit1_OnStop);
            // 
            // OpenDialog1
            // 
            this.OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            this.SaveDialog1.Filter = "AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|" +
    "All files  (*.*)| *.*";
            // 
            // cbFrameRate
            // 
            this.cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrameRate.FormattingEnabled = true;
            this.cbFrameRate.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "5",
            "10",
            "12",
            "15",
            "20",
            "25",
            "30"});
            this.cbFrameRate.Location = new System.Drawing.Point(309, 126);
            this.cbFrameRate.Name = "cbFrameRate";
            this.cbFrameRate.Size = new System.Drawing.Size(96, 21);
            this.cbFrameRate.TabIndex = 169;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 13);
            this.label3.TabIndex = 168;
            this.label3.Text = "Frame rate (Use 0 to have original, set before adding files)";
            // 
            // edHeight
            // 
            this.edHeight.Location = new System.Drawing.Point(160, 96);
            this.edHeight.Name = "edHeight";
            this.edHeight.Size = new System.Drawing.Size(48, 20);
            this.edHeight.TabIndex = 167;
            this.edHeight.Text = "576";
            // 
            // edWidth
            // 
            this.edWidth.Location = new System.Drawing.Point(88, 96);
            this.edWidth.Name = "edWidth";
            this.edWidth.Size = new System.Drawing.Size(48, 20);
            this.edWidth.TabIndex = 166;
            this.edWidth.Text = "768";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 165;
            this.label2.Text = "x";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Location = new System.Drawing.Point(15, 98);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(58, 17);
            this.cbResize.TabIndex = 164;
            this.cbResize.Text = "Resize";
            this.cbResize.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 379);
            this.Controls.Add(this.cbFrameRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edHeight);
            this.Controls.Add(this.edWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbResize);
            this.Controls.Add(this.VideoEdit1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btConfigure);
            this.Controls.Add(this.btSelectOutput);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbOutputVideoFormat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTelemetry);
            this.Controls.Add(this.edOutput);
            this.Controls.Add(this.cbLicensing);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.btClearList);
            this.Controls.Add(this.btAddInputFile);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "VisioForge Video Edit SDK .Net - Video Join Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private VisioForge.Controls.UI.WinForms.VideoEdit VideoEdit1;
        private System.Windows.Forms.OpenFileDialog OpenDialog1;
        private System.Windows.Forms.SaveFileDialog SaveDialog1;
        private System.Windows.Forms.ComboBox cbFrameRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbResize;
    }
}

