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
            btResume = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            label28 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            cbTelemetry = new System.Windows.Forms.CheckBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // btResume
            // 
            btResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btResume.Location = new System.Drawing.Point(558, 558);
            btResume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(92, 44);
            btResume.TabIndex = 76;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btPause
            // 
            btPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btPause.Location = new System.Drawing.Point(457, 558);
            btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(92, 44);
            btPause.TabIndex = 75;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStop.Location = new System.Drawing.Point(128, 558);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 74;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStart.Location = new System.Drawing.Point(20, 558);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 73;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(20, 23);
            tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(638, 523);
            tabControl1.TabIndex = 77;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label28);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(cbVideoInputFrameRate);
            tabPage1.Controls.Add(cbVideoInputFormat);
            tabPage1.Controls.Add(cbVideoInputDevice);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label11);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Size = new System.Drawing.Size(630, 485);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Video input";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(502, 169);
            label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(37, 25);
            label28.TabIndex = 127;
            label28.Text = "fps";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(378, 133);
            label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(96, 25);
            label18.TabIndex = 125;
            label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFrameRate.FormattingEnabled = true;
            cbVideoInputFrameRate.Location = new System.Drawing.Point(383, 163);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(32, 163);
            cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputFormat.Name = "cbVideoInputFormat";
            cbVideoInputFormat.Size = new System.Drawing.Size(339, 33);
            cbVideoInputFormat.TabIndex = 123;
            cbVideoInputFormat.SelectedIndexChanged += cbVideoInputFormat_SelectedIndexChanged;
            // 
            // cbVideoInputDevice
            // 
            cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputDevice.FormattingEnabled = true;
            cbVideoInputDevice.Location = new System.Drawing.Point(32, 62);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(339, 33);
            cbVideoInputDevice.TabIndex = 122;
            cbVideoInputDevice.SelectedIndexChanged += cbVideoInputDevice_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(27, 133);
            label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 25);
            label13.TabIndex = 121;
            label13.Text = "Input format";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(27, 31);
            label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(109, 25);
            label11.TabIndex = 120;
            label11.Text = "Input device";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbAudioOutputDevice);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(cbAudioInputFormat);
            tabPage2.Controls.Add(cbAudioInputDevice);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label10);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Size = new System.Drawing.Size(630, 485);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Audio input/output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutputDevice.FormattingEnabled = true;
            cbAudioOutputDevice.Location = new System.Drawing.Point(32, 278);
            cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            cbAudioOutputDevice.Size = new System.Drawing.Size(572, 33);
            cbAudioOutputDevice.TabIndex = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 247);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 25);
            label1.TabIndex = 99;
            label1.Text = "Output device";
            // 
            // cbAudioInputFormat
            // 
            cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputFormat.FormattingEnabled = true;
            cbAudioInputFormat.Location = new System.Drawing.Point(32, 159);
            cbAudioInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioInputFormat.Name = "cbAudioInputFormat";
            cbAudioInputFormat.Size = new System.Drawing.Size(277, 33);
            cbAudioInputFormat.TabIndex = 98;
            // 
            // cbAudioInputDevice
            // 
            cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputDevice.FormattingEnabled = true;
            cbAudioInputDevice.Location = new System.Drawing.Point(32, 62);
            cbAudioInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioInputDevice.Name = "cbAudioInputDevice";
            cbAudioInputDevice.Size = new System.Drawing.Size(572, 33);
            cbAudioInputDevice.TabIndex = 97;
            cbAudioInputDevice.SelectedIndexChanged += cbAudioInputDevice_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(32, 31);
            label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(109, 25);
            label12.TabIndex = 95;
            label12.Text = "Input device";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(32, 128);
            label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(113, 25);
            label10.TabIndex = 94;
            label10.Text = "Input format";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(cbTelemetry);
            tabPage3.Controls.Add(cbDebugMode);
            tabPage3.Controls.Add(mmLog);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage3.Size = new System.Drawing.Size(630, 485);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Debug/Log";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbTelemetry
            // 
            cbTelemetry.AutoSize = true;
            cbTelemetry.Checked = true;
            cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            cbTelemetry.Location = new System.Drawing.Point(127, 27);
            cbTelemetry.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbTelemetry.Name = "cbTelemetry";
            cbTelemetry.Size = new System.Drawing.Size(113, 29);
            cbTelemetry.TabIndex = 81;
            cbTelemetry.Text = "Telemetry";
            cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(20, 27);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 79;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(20, 71);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(584, 381);
            mmLog.TabIndex = 78;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(668, 23);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(667, 579);
            VideoView1.TabIndex = 78;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1355, 625);
            Controls.Add(VideoView1);
            Controls.Add(tabControl1);
            Controls.Add(btResume);
            Controls.Add(btPause);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - WebCam Preview Code Snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label1;
    }
}

