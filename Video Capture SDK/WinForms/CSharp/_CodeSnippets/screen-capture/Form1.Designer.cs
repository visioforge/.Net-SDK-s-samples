namespace screen_capture
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbAudioCapture = new System.Windows.Forms.CheckBox();
            this.cbScreenCapture_DesktopDuplication = new System.Windows.Forms.CheckBox();
            this.cbScreenCaptureDisplayIndex = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.btScreenCaptureUpdate = new System.Windows.Forms.Button();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.cbScreenCapture_GrabMouseCursor = new System.Windows.Forms.CheckBox();
            this.label79 = new System.Windows.Forms.Label();
            this.edScreenFrameRate = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.edScreenBottom = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.edScreenRight = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.edScreenTop = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.edScreenLeft = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.rbScreenCustomArea = new System.Windows.Forms.RadioButton();
            this.rbScreenFullScreen = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCapture = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 289);
            this.tabControl1.TabIndex = 83;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbAudioCapture);
            this.tabPage1.Controls.Add(this.cbScreenCapture_DesktopDuplication);
            this.tabPage1.Controls.Add(this.cbScreenCaptureDisplayIndex);
            this.tabPage1.Controls.Add(this.label93);
            this.tabPage1.Controls.Add(this.btScreenCaptureUpdate);
            this.tabPage1.Controls.Add(this.label124);
            this.tabPage1.Controls.Add(this.label123);
            this.tabPage1.Controls.Add(this.label122);
            this.tabPage1.Controls.Add(this.cbScreenCapture_GrabMouseCursor);
            this.tabPage1.Controls.Add(this.label79);
            this.tabPage1.Controls.Add(this.edScreenFrameRate);
            this.tabPage1.Controls.Add(this.label43);
            this.tabPage1.Controls.Add(this.edScreenBottom);
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.edScreenRight);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.edScreenTop);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.edScreenLeft);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.rbScreenCustomArea);
            this.tabPage1.Controls.Add(this.rbScreenFullScreen);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 263);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Screen source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbAudioCapture
            // 
            this.cbAudioCapture.AutoSize = true;
            this.cbAudioCapture.Location = new System.Drawing.Point(234, 212);
            this.cbAudioCapture.Name = "cbAudioCapture";
            this.cbAudioCapture.Size = new System.Drawing.Size(185, 17);
            this.cbAudioCapture.TabIndex = 80;
            this.cbAudioCapture.Text = "Capture audio from default device";
            this.cbAudioCapture.UseVisualStyleBackColor = true;
            // 
            // cbScreenCapture_DesktopDuplication
            // 
            this.cbScreenCapture_DesktopDuplication.AutoSize = true;
            this.cbScreenCapture_DesktopDuplication.Location = new System.Drawing.Point(11, 235);
            this.cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication";
            this.cbScreenCapture_DesktopDuplication.Size = new System.Drawing.Size(225, 17);
            this.cbScreenCapture_DesktopDuplication.TabIndex = 79;
            this.cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage (Win 8+)";
            this.cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptureDisplayIndex
            // 
            this.cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScreenCaptureDisplayIndex.FormattingEnabled = true;
            this.cbScreenCaptureDisplayIndex.Location = new System.Drawing.Point(80, 179);
            this.cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex";
            this.cbScreenCaptureDisplayIndex.Size = new System.Drawing.Size(44, 21);
            this.cbScreenCaptureDisplayIndex.TabIndex = 74;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label93.Location = new System.Drawing.Point(8, 182);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(65, 13);
            this.label93.TabIndex = 73;
            this.label93.Text = "Display ID";
            // 
            // btScreenCaptureUpdate
            // 
            this.btScreenCaptureUpdate.Location = new System.Drawing.Point(306, 90);
            this.btScreenCaptureUpdate.Name = "btScreenCaptureUpdate";
            this.btScreenCaptureUpdate.Size = new System.Drawing.Size(75, 23);
            this.btScreenCaptureUpdate.TabIndex = 72;
            this.btScreenCaptureUpdate.Text = "Update";
            this.btScreenCaptureUpdate.UseVisualStyleBackColor = true;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(260, 59);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(50, 13);
            this.label124.TabIndex = 71;
            this.label124.Text = "on-the-fly";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(260, 35);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(141, 13);
            this.label123.TabIndex = 70;
            this.label123.Text = "and mouse cursor  capturing";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(260, 15);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(159, 13);
            this.label122.TabIndex = 69;
            this.label122.Text = "You can update left/top position";
            // 
            // cbScreenCapture_GrabMouseCursor
            // 
            this.cbScreenCapture_GrabMouseCursor.AutoSize = true;
            this.cbScreenCapture_GrabMouseCursor.Location = new System.Drawing.Point(11, 212);
            this.cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor";
            this.cbScreenCapture_GrabMouseCursor.Size = new System.Drawing.Size(129, 17);
            this.cbScreenCapture_GrabMouseCursor.TabIndex = 68;
            this.cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor";
            this.cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(129, 154);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(21, 13);
            this.label79.TabIndex = 67;
            this.label79.Text = "fps";
            // 
            // edScreenFrameRate
            // 
            this.edScreenFrameRate.Location = new System.Drawing.Point(80, 151);
            this.edScreenFrameRate.Name = "edScreenFrameRate";
            this.edScreenFrameRate.Size = new System.Drawing.Size(44, 20);
            this.edScreenFrameRate.TabIndex = 66;
            this.edScreenFrameRate.Text = "5";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label43.Location = new System.Drawing.Point(8, 154);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 65;
            this.label43.Text = "Frame rate";
            // 
            // edScreenBottom
            // 
            this.edScreenBottom.Location = new System.Drawing.Point(196, 113);
            this.edScreenBottom.Name = "edScreenBottom";
            this.edScreenBottom.Size = new System.Drawing.Size(44, 20);
            this.edScreenBottom.TabIndex = 64;
            this.edScreenBottom.Text = "480";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(153, 116);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 13);
            this.label42.TabIndex = 63;
            this.label42.Text = "Bottom";
            // 
            // edScreenRight
            // 
            this.edScreenRight.Location = new System.Drawing.Point(80, 113);
            this.edScreenRight.Name = "edScreenRight";
            this.edScreenRight.Size = new System.Drawing.Size(44, 20);
            this.edScreenRight.TabIndex = 62;
            this.edScreenRight.Text = "640";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(39, 116);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(32, 13);
            this.label40.TabIndex = 61;
            this.label40.Text = "Right";
            // 
            // edScreenTop
            // 
            this.edScreenTop.Location = new System.Drawing.Point(196, 73);
            this.edScreenTop.Name = "edScreenTop";
            this.edScreenTop.Size = new System.Drawing.Size(44, 20);
            this.edScreenTop.TabIndex = 60;
            this.edScreenTop.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(153, 76);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 59;
            this.label26.Text = "Top";
            // 
            // edScreenLeft
            // 
            this.edScreenLeft.Location = new System.Drawing.Point(80, 73);
            this.edScreenLeft.Name = "edScreenLeft";
            this.edScreenLeft.Size = new System.Drawing.Size(44, 20);
            this.edScreenLeft.TabIndex = 58;
            this.edScreenLeft.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(39, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 57;
            this.label24.Text = "Left";
            // 
            // rbScreenCustomArea
            // 
            this.rbScreenCustomArea.AutoSize = true;
            this.rbScreenCustomArea.Location = new System.Drawing.Point(11, 35);
            this.rbScreenCustomArea.Name = "rbScreenCustomArea";
            this.rbScreenCustomArea.Size = new System.Drawing.Size(84, 17);
            this.rbScreenCustomArea.TabIndex = 56;
            this.rbScreenCustomArea.Text = "Custom area";
            this.rbScreenCustomArea.UseVisualStyleBackColor = true;
            // 
            // rbScreenFullScreen
            // 
            this.rbScreenFullScreen.AutoSize = true;
            this.rbScreenFullScreen.Checked = true;
            this.rbScreenFullScreen.Location = new System.Drawing.Point(11, 11);
            this.rbScreenFullScreen.Name = "rbScreenFullScreen";
            this.rbScreenFullScreen.Size = new System.Drawing.Size(76, 17);
            this.rbScreenFullScreen.TabIndex = 55;
            this.rbScreenFullScreen.TabStop = true;
            this.rbScreenFullScreen.Text = "Full screen";
            this.rbScreenFullScreen.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOutput);
            this.tabPage2.Controls.Add(this.edOutput);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cbCapture);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(390, 60);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 44;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(18, 62);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(366, 20);
            this.edOutput.TabIndex = 43;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "File name";
            // 
            // cbCapture
            // 
            this.cbCapture.AutoSize = true;
            this.cbCapture.Location = new System.Drawing.Point(18, 18);
            this.cbCapture.Name = "cbCapture";
            this.cbCapture.Size = new System.Drawing.Size(212, 17);
            this.cbCapture.TabIndex = 0;
            this.cbCapture.Text = "Capture to MP4 file with default settings";
            this.cbCapture.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbTelemetry);
            this.tabPage3.Controls.Add(this.cbDebugMode);
            this.tabPage3.Controls.Add(this.mmLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(431, 263);
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
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(238, 307);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 82;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(177, 307);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 81;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(77, 307);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 80;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(12, 307);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 79;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(456, 12);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(480, 315);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 84;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 339);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Screen Capture Code Snippet";
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.CheckBox cbScreenCapture_DesktopDuplication;
        private System.Windows.Forms.ComboBox cbScreenCaptureDisplayIndex;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Button btScreenCaptureUpdate;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.CheckBox cbScreenCapture_GrabMouseCursor;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox edScreenFrameRate;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox edScreenBottom;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox edScreenRight;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox edScreenTop;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox edScreenLeft;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton rbScreenCustomArea;
        private System.Windows.Forms.RadioButton rbScreenFullScreen;
        private System.Windows.Forms.CheckBox cbCapture;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cbAudioCapture;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

