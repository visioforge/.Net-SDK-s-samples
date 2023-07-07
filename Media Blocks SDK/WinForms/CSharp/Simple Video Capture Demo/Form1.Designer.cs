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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label2 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            lbTime = new System.Windows.Forms.Label();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            cbAudioFormat = new System.Windows.Forms.ComboBox();
            cbAudioInput = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cbVideoFrameRate = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbVideoFormat = new System.Windows.Forms.ComboBox();
            cbVideoInput = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            tabPage4 = new System.Windows.Forms.TabPage();
            label6 = new System.Windows.Forms.Label();
            tbVolume = new System.Windows.Forms.TrackBar();
            cbAudioOutput = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            btSelectOutput = new System.Windows.Forms.Button();
            edFilename = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            mmLog = new System.Windows.Forms.TextBox();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            cbCapture = new System.Windows.Forms.CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(395, -238);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(338, 17);
            label2.TabIndex = 95;
            label2.Text = "Much more features are shown in Main Demo!";
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(611, 14);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(153, 20);
            linkLabel1.TabIndex = 93;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(658, 468);
            btStop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(80, 35);
            btStop.TabIndex = 104;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(572, 468);
            btPause.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(80, 35);
            btPause.TabIndex = 103;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(486, 468);
            btResume.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(80, 35);
            btResume.TabIndex = 102;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(399, 468);
            btStart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(80, 35);
            btStart.TabIndex = 101;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(825, 475);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(123, 20);
            lbTime.TabIndex = 100;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(10, 14);
            tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(370, 632);
            tabControl1.TabIndex = 105;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbAudioFormat);
            tabPage1.Controls.Add(cbAudioInput);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(cbVideoFrameRate);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(cbVideoFormat);
            tabPage1.Controls.Add(cbVideoInput);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new System.Drawing.Point(4, 29);
            tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage1.Size = new System.Drawing.Size(362, 599);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Source";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbAudioFormat
            // 
            cbAudioFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioFormat.FormattingEnabled = true;
            cbAudioFormat.Location = new System.Drawing.Point(22, 183);
            cbAudioFormat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbAudioFormat.Name = "cbAudioFormat";
            cbAudioFormat.Size = new System.Drawing.Size(315, 28);
            cbAudioFormat.TabIndex = 114;
            // 
            // cbAudioInput
            // 
            cbAudioInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInput.FormattingEnabled = true;
            cbAudioInput.Location = new System.Drawing.Point(22, 149);
            cbAudioInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbAudioInput.Name = "cbAudioInput";
            cbAudioInput.Size = new System.Drawing.Size(315, 28);
            cbAudioInput.TabIndex = 113;
            cbAudioInput.SelectedIndexChanged += cbAudioInput_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(18, 126);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(134, 20);
            label4.TabIndex = 112;
            label4.Text = "Audio input device";
            // 
            // cbVideoFrameRate
            // 
            cbVideoFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoFrameRate.FormattingEnabled = true;
            cbVideoFrameRate.Location = new System.Drawing.Point(239, 81);
            cbVideoFrameRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbVideoFrameRate.Name = "cbVideoFrameRate";
            cbVideoFrameRate.Size = new System.Drawing.Size(65, 28);
            cbVideoFrameRate.TabIndex = 111;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(309, 84);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 20);
            label3.TabIndex = 110;
            label3.Text = "fps";
            // 
            // cbVideoFormat
            // 
            cbVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoFormat.FormattingEnabled = true;
            cbVideoFormat.Location = new System.Drawing.Point(22, 81);
            cbVideoFormat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbVideoFormat.Name = "cbVideoFormat";
            cbVideoFormat.Size = new System.Drawing.Size(213, 28);
            cbVideoFormat.TabIndex = 109;
            cbVideoFormat.SelectedIndexChanged += cbVideoFormat_SelectedIndexChanged;
            // 
            // cbVideoInput
            // 
            cbVideoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInput.FormattingEnabled = true;
            cbVideoInput.Location = new System.Drawing.Point(22, 47);
            cbVideoInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbVideoInput.Name = "cbVideoInput";
            cbVideoInput.Size = new System.Drawing.Size(315, 28);
            cbVideoInput.TabIndex = 108;
            cbVideoInput.SelectedIndexChanged += cbVideoInput_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 24);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 20);
            label1.TabIndex = 107;
            label1.Text = "Video input device";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(tbVolume);
            tabPage4.Controls.Add(cbAudioOutput);
            tabPage4.Controls.Add(label5);
            tabPage4.Location = new System.Drawing.Point(4, 29);
            tabPage4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage4.Size = new System.Drawing.Size(362, 599);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Audio renderer";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(54, 90);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(59, 20);
            label6.TabIndex = 122;
            label6.Text = "Volume";
            // 
            // tbVolume
            // 
            tbVolume.BackColor = System.Drawing.SystemColors.Window;
            tbVolume.Location = new System.Drawing.Point(57, 115);
            tbVolume.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            tbVolume.Maximum = 100;
            tbVolume.Name = "tbVolume";
            tbVolume.Size = new System.Drawing.Size(279, 56);
            tbVolume.TabIndex = 121;
            tbVolume.Value = 80;
            tbVolume.Scroll += tbVolume1_Scroll;
            // 
            // cbAudioOutput
            // 
            cbAudioOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutput.FormattingEnabled = true;
            cbAudioOutput.Location = new System.Drawing.Point(22, 47);
            cbAudioOutput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cbAudioOutput.Name = "cbAudioOutput";
            cbAudioOutput.Size = new System.Drawing.Size(315, 28);
            cbAudioOutput.TabIndex = 120;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(18, 24);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(144, 20);
            label5.TabIndex = 119;
            label5.Text = "Audio output device";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbCapture);
            tabPage2.Controls.Add(btSelectOutput);
            tabPage2.Controls.Add(edFilename);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage2.Size = new System.Drawing.Size(362, 599);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(310, 112);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(26, 26);
            btSelectOutput.TabIndex = 42;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(22, 112);
            edFilename.Margin = new System.Windows.Forms.Padding(2);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(284, 27);
            edFilename.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(18, 90);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(80, 20);
            label8.TabIndex = 2;
            label8.Text = "Output file";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(22, 48);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(273, 20);
            label7.TabIndex = 0;
            label7.Text = "MP4 output format with default settings";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(mmLog);
            tabPage3.Controls.Add(cbTelemetry);
            tabPage3.Controls.Add(cbDebugMode);
            tabPage3.Location = new System.Drawing.Point(4, 29);
            tabPage3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(362, 599);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Log";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(15, 57);
            mmLog.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmLog.Size = new System.Drawing.Size(331, 525);
            mmLog.TabIndex = 8;
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Location = new System.Drawing.Point(138, 22);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(96, 24);
            cbTelemetry.TabIndex = 7;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(15, 22);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(119, 24);
            cbDebugMode.TabIndex = 6;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(399, 43);
            VideoView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(553, 415);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 97;
            // 
            // cbCapture
            // 
            cbCapture.AutoSize = true;
            cbCapture.Location = new System.Drawing.Point(22, 21);
            cbCapture.Name = "cbCapture";
            cbCapture.Size = new System.Drawing.Size(85, 24);
            cbCapture.TabIndex = 107;
            cbCapture.Text = "Enabled";
            cbCapture.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(969, 661);
            Controls.Add(tabControl1);
            Controls.Add(btStop);
            Controls.Add(btPause);
            Controls.Add(btResume);
            Controls.Add(btStart);
            Controls.Add(lbTime);
            Controls.Add(VideoView1);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - Simple Video Capture Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.CheckBox cbCapture;
    }
}
