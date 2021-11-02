namespace webcam_preview
{
    using System;

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

            VideoCapture1?.Dispose();
            VideoCapture1 = null;

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
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.VideoView1 = new VisioForge.Controls.UI.WinForms.VideoView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(335, 290);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 76;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(274, 290);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 75;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(77, 290);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 74;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(12, 290);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 73;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 272);
            this.tabControl1.TabIndex = 77;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage1.Controls.Add(this.cbVideoInputFormat);
            this.tabPage1.Controls.Add(this.cbVideoInputDevice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Video input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(301, 88);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 127;
            this.label28.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(156, 68);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 126;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(227, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(230, 85);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(65, 21);
            this.cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(19, 85);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(205, 21);
            this.cbVideoInputFormat.TabIndex = 123;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(19, 32);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(205, 21);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 121;
            this.label13.Text = "Input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 120;
            this.label11.Text = "Input device";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage2.Controls.Add(this.cbAudioInputLine);
            this.tabPage2.Controls.Add(this.cbAudioInputFormat);
            this.tabPage2.Controls.Add(this.cbAudioInputDevice);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(375, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Audio input";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(296, 68);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestAudioInputFormat.TabIndex = 101;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(19, 85);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(168, 21);
            this.cbAudioInputLine.TabIndex = 99;
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(196, 85);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(168, 21);
            this.cbAudioInputFormat.TabIndex = 98;
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(19, 32);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(345, 21);
            this.cbAudioInputDevice.TabIndex = 97;
            this.cbAudioInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 96;
            this.label14.Text = "Input line";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 95;
            this.label12.Text = "Input device";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Input format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbTelemetry);
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(375, 246);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug/Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(76, 14);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(72, 17);
            this.cbTelemetry.TabIndex = 81;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(12, 14);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(58, 17);
            this.cbDebugMode.TabIndex = 79;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(12, 37);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(352, 200);
            this.mmLog.TabIndex = 78;
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(401, 12);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(400, 301);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 78;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 325);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WebCam Preview Code Snippet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private VisioForge.Controls.UI.WinForms.VideoView VideoView1;
    }
}

