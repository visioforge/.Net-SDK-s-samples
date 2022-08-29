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
            this.lbInfo = new System.Windows.Forms.Label();
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
            this.OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbFrameRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edHeight = new System.Windows.Forms.TextBox();
            this.edWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.rbPreview = new System.Windows.Forms.RadioButton();
            this.rbConvert = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(16, 322);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(326, 20);
            this.lbInfo.TabIndex = 99;
            this.lbInfo.Text = "You can use API to configure format settings";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(568, 398);
            this.btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(39, 35);
            this.btSelectOutput.TabIndex = 94;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 374);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 20);
            this.label15.TabIndex = 92;
            this.label15.Text = "File name";
            // 
            // cbOutputVideoFormat
            // 
            this.cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputVideoFormat.FormattingEnabled = true;
            this.cbOutputVideoFormat.Items.AddRange(new object[] {
            "MP4",
            "WebM",
            "AVI",
            "MKV (Matroska)",
            "WMV (Windows Media Video)",
            "PCM",
            "MP3",
            "M4A (AAC)",
            "WMA (Windows Media Audio)",
            "Ogg Vorbis",
            "FLAC",
            "Speex"});
            this.cbOutputVideoFormat.Location = new System.Drawing.Point(21, 275);
            this.cbOutputVideoFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOutputVideoFormat.Name = "cbOutputVideoFormat";
            this.cbOutputVideoFormat.Size = new System.Drawing.Size(480, 28);
            this.cbOutputVideoFormat.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 248);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 90;
            this.label9.Text = "Output format";
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(232, 463);
            this.cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(104, 24);
            this.cbTelemetry.TabIndex = 104;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(21, 402);
            this.edOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(536, 26);
            this.edOutput.TabIndex = 93;
            this.edOutput.Text = "output.mp4";
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(117, 463);
            this.cbLicensing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(102, 24);
            this.cbLicensing.TabIndex = 103;
            this.cbLicensing.Text = "Licensing";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(21, 498);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(584, 67);
            this.mmLog.TabIndex = 101;
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(1194, 518);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(87, 35);
            this.btStop.TabIndex = 89;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(1094, 518);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(87, 35);
            this.btStart.TabIndex = 88;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(813, 518);
            this.ProgressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(272, 34);
            this.ProgressBar1.TabIndex = 87;
            // 
            // btClearList
            // 
            this.btClearList.Location = new System.Drawing.Point(512, 91);
            this.btClearList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btClearList.Name = "btClearList";
            this.btClearList.Size = new System.Drawing.Size(96, 35);
            this.btClearList.TabIndex = 100;
            this.btClearList.Text = "Clear";
            this.btClearList.UseVisualStyleBackColor = true;
            this.btClearList.Click += new System.EventHandler(this.btClearList_Click);
            // 
            // btAddInputFile
            // 
            this.btAddInputFile.Location = new System.Drawing.Point(512, 46);
            this.btAddInputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAddInputFile.Name = "btAddInputFile";
            this.btAddInputFile.Size = new System.Drawing.Size(96, 35);
            this.btAddInputFile.TabIndex = 98;
            this.btAddInputFile.Text = "Add";
            this.btAddInputFile.UseVisualStyleBackColor = true;
            this.btAddInputFile.Click += new System.EventHandler(this.btAddInputFile_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 20;
            this.lbFiles.Location = new System.Drawing.Point(21, 46);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(480, 84);
            this.lbFiles.TabIndex = 97;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(21, 463);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(83, 24);
            this.cbDebugMode.TabIndex = 102;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 96;
            this.label10.Text = "Input files";
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
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.cbFrameRate.Location = new System.Drawing.Point(431, 148);
            this.cbFrameRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFrameRate.Name = "cbFrameRate";
            this.cbFrameRate.Size = new System.Drawing.Size(70, 28);
            this.cbFrameRate.TabIndex = 169;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 168;
            this.label3.Text = "Frame rate";
            // 
            // edHeight
            // 
            this.edHeight.Location = new System.Drawing.Point(240, 148);
            this.edHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edHeight.Name = "edHeight";
            this.edHeight.Size = new System.Drawing.Size(70, 26);
            this.edHeight.TabIndex = 167;
            this.edHeight.Text = "720";
            // 
            // edWidth
            // 
            this.edWidth.Location = new System.Drawing.Point(132, 148);
            this.edWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edWidth.Name = "edWidth";
            this.edWidth.Size = new System.Drawing.Size(70, 26);
            this.edWidth.TabIndex = 166;
            this.edWidth.Text = "1280";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 165;
            this.label2.Text = "x";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Location = new System.Drawing.Point(21, 148);
            this.cbResize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(84, 24);
            this.cbResize.TabIndex = 164;
            this.cbResize.Text = "Resize";
            this.cbResize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 171;
            this.label1.Text = "Set video size and frame rate before adding files";
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(633, 18);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(648, 471);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 170;
            // 
            // rbPreview
            // 
            this.rbPreview.AutoSize = true;
            this.rbPreview.Checked = true;
            this.rbPreview.Location = new System.Drawing.Point(633, 511);
            this.rbPreview.Name = "rbPreview";
            this.rbPreview.Size = new System.Drawing.Size(88, 24);
            this.rbPreview.TabIndex = 172;
            this.rbPreview.TabStop = true;
            this.rbPreview.Text = "Preview";
            this.rbPreview.UseVisualStyleBackColor = true;
            // 
            // rbConvert
            // 
            this.rbConvert.AutoSize = true;
            this.rbConvert.Location = new System.Drawing.Point(633, 541);
            this.rbConvert.Name = "rbConvert";
            this.rbConvert.Size = new System.Drawing.Size(89, 24);
            this.rbConvert.TabIndex = 173;
            this.rbConvert.Text = "Convert";
            this.rbConvert.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 583);
            this.Controls.Add(this.rbConvert);
            this.Controls.Add(this.rbPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.cbFrameRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edHeight);
            this.Controls.Add(this.edWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbResize);
            this.Controls.Add(this.lbInfo);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Video Edit SDK .Net - Video Join Demo X (Crossplatform)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPreview;
        private System.Windows.Forms.RadioButton rbConvert;
    }
}

