namespace MediaBlocks_Simple_Video_Capture_Demo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbAudioFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInput = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVideoFrameRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVideoFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInput = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.cbAudioOutput = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(445, -238);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Much more features are shown in Main Demo!";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(688, 14);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(160, 20);
            this.linkLabel1.TabIndex = 93;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(710, 468);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(69, 35);
            this.btStop.TabIndex = 104;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(623, 468);
            this.btPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(78, 35);
            this.btPause.TabIndex = 103;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(522, 468);
            this.btResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(92, 35);
            this.btResume.TabIndex = 102;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(449, 468);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(64, 35);
            this.btStart.TabIndex = 101;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(928, 475);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(137, 20);
            this.lbTime.TabIndex = 100;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 632);
            this.tabControl1.TabIndex = 105;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbAudioFormat);
            this.tabPage1.Controls.Add(this.cbAudioInput);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbVideoFrameRate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbVideoFormat);
            this.tabPage1.Controls.Add(this.cbVideoInput);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbAudioFormat
            // 
            this.cbAudioFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioFormat.FormattingEnabled = true;
            this.cbAudioFormat.Location = new System.Drawing.Point(24, 183);
            this.cbAudioFormat.Name = "cbAudioFormat";
            this.cbAudioFormat.Size = new System.Drawing.Size(354, 28);
            this.cbAudioFormat.TabIndex = 114;
            // 
            // cbAudioInput
            // 
            this.cbAudioInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInput.FormattingEnabled = true;
            this.cbAudioInput.Location = new System.Drawing.Point(24, 149);
            this.cbAudioInput.Name = "cbAudioInput";
            this.cbAudioInput.Size = new System.Drawing.Size(354, 28);
            this.cbAudioInput.TabIndex = 113;
            this.cbAudioInput.SelectedIndexChanged += new System.EventHandler(this.cbAudioInput_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "Audio input device";
            // 
            // cbVideoFrameRate
            // 
            this.cbVideoFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFrameRate.FormattingEnabled = true;
            this.cbVideoFrameRate.Location = new System.Drawing.Point(269, 81);
            this.cbVideoFrameRate.Name = "cbVideoFrameRate";
            this.cbVideoFrameRate.Size = new System.Drawing.Size(72, 28);
            this.cbVideoFrameRate.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 110;
            this.label3.Text = "fps";
            // 
            // cbVideoFormat
            // 
            this.cbVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFormat.FormattingEnabled = true;
            this.cbVideoFormat.Location = new System.Drawing.Point(24, 81);
            this.cbVideoFormat.Name = "cbVideoFormat";
            this.cbVideoFormat.Size = new System.Drawing.Size(239, 28);
            this.cbVideoFormat.TabIndex = 109;
            this.cbVideoFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoFormat_SelectedIndexChanged);
            // 
            // cbVideoInput
            // 
            this.cbVideoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInput.FormattingEnabled = true;
            this.cbVideoInput.Location = new System.Drawing.Point(24, 47);
            this.cbVideoInput.Name = "cbVideoInput";
            this.cbVideoInput.Size = new System.Drawing.Size(354, 28);
            this.cbVideoInput.TabIndex = 108;
            this.cbVideoInput.SelectedIndexChanged += new System.EventHandler(this.cbVideoInput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 107;
            this.label1.Text = "Video input device";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.tbVolume1);
            this.tabPage4.Controls.Add(this.cbAudioOutput);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(409, 599);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Audio renderer";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 122;
            this.label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume1.Location = new System.Drawing.Point(64, 115);
            this.tbVolume1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume1.Maximum = 100;
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(314, 69);
            this.tbVolume1.TabIndex = 121;
            this.tbVolume1.Value = 80;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // cbAudioOutput
            // 
            this.cbAudioOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutput.FormattingEnabled = true;
            this.cbAudioOutput.Location = new System.Drawing.Point(24, 47);
            this.cbAudioOutput.Name = "cbAudioOutput";
            this.cbAudioOutput.Size = new System.Drawing.Size(354, 28);
            this.cbAudioOutput.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 119;
            this.label5.Text = "Audio output device";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbOutputFormat);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "None",
            "MP4",
            "WebM"});
            this.cbOutputFormat.Location = new System.Drawing.Point(24, 47);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(354, 28);
            this.cbOutputFormat.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Output format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Controls.Add(this.cbTelemetry);
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(409, 599);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(17, 57);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(372, 525);
            this.mmLog.TabIndex = 8;
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Location = new System.Drawing.Point(156, 22);
            this.cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(104, 24);
            this.cbTelemetry.TabIndex = 7;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(17, 22);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(127, 24);
            this.cbDebugMode.TabIndex = 6;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(449, 43);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(622, 415);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 97;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Blocks SDK .Net - Simple Video Capture Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbVideoInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVideoFormat;
        private System.Windows.Forms.ComboBox cbVideoFrameRate;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbAudioFormat;
        private System.Windows.Forms.ComboBox cbAudioInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label7;
    }
}
