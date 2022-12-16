using VisioForge.Core.Types;
using System;

namespace Virtual_Camera_Streamer_Demo
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
            
            screenshotSaveDialog?.Dispose();
            screenshotSaveDialog = null;
            
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
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUseBestVideoInputFormat = new System.Windows.Forms.CheckBox();
            this.btVideoCaptureDeviceSettings = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            this.cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.tbAudioBalance = new System.Windows.Forms.TrackBar();
            this.label54 = new System.Windows.Forms.Label();
            this.tbAudioVolume = new System.Windows.Forms.TrackBar();
            this.cbRecordAudio = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.llVideoTutorials = new System.Windows.Forms.LinkLabel();
            this.label34 = new System.Windows.Forms.Label();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btStop.Location = new System.Drawing.Point(760, 783);
            this.btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(103, 44);
            this.btStop.TabIndex = 54;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btStart.Location = new System.Drawing.Point(647, 783);
            this.btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(103, 44);
            this.btStart.TabIndex = 53;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Location = new System.Drawing.Point(5, 6);
            this.tcMain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(630, 821);
            this.tcMain.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbUseBestVideoInputFormat);
            this.tabPage1.Controls.Add(this.btVideoCaptureDeviceSettings);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cbVideoInputFrameRate);
            this.tabPage1.Controls.Add(this.cbVideoInputFormat);
            this.tabPage1.Controls.Add(this.cbVideoInputDevice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label55);
            this.tabPage1.Controls.Add(this.tbAudioBalance);
            this.tabPage1.Controls.Add(this.label54);
            this.tabPage1.Controls.Add(this.tbAudioVolume);
            this.tabPage1.Controls.Add(this.cbRecordAudio);
            this.tabPage1.Controls.Add(this.cbAudioOutputDevice);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage1.Controls.Add(this.btAudioInputDeviceSettings);
            this.tabPage1.Controls.Add(this.cbAudioInputLine);
            this.tabPage1.Controls.Add(this.cbAudioInputFormat);
            this.tabPage1.Controls.Add(this.cbAudioInputDevice);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage1.Size = new System.Drawing.Size(622, 783);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Devices";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 128;
            this.label1.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(313, 138);
            this.cbUseBestVideoInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(106, 29);
            this.cbUseBestVideoInputFormat.TabIndex = 127;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestVideoInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestVideoInputFormat_CheckedChanged);
            // 
            // btVideoCaptureDeviceSettings
            // 
            this.btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(448, 65);
            this.btVideoCaptureDeviceSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            this.btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(110, 44);
            this.btVideoCaptureDeviceSettings.TabIndex = 126;
            this.btVideoCaptureDeviceSettings.Text = "Settings";
            this.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            this.btVideoCaptureDeviceSettings.Click += new System.EventHandler(this.btVideoCaptureDeviceSettings_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(443, 140);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 25);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(448, 171);
            this.cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            this.cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(15, 171);
            this.cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(409, 33);
            this.cbVideoInputFormat.TabIndex = 123;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(15, 69);
            this.cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(409, 33);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 140);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 25);
            this.label13.TabIndex = 121;
            this.label13.Text = "Video input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 25);
            this.label11.TabIndex = 120;
            this.label11.Text = "Video input device";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(330, 688);
            this.label55.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(71, 25);
            this.label55.TabIndex = 90;
            this.label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            this.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioBalance.Location = new System.Drawing.Point(415, 679);
            this.tbAudioBalance.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudioBalance.Maximum = 100;
            this.tbAudioBalance.Minimum = -100;
            this.tbAudioBalance.Name = "tbAudioBalance";
            this.tbAudioBalance.Size = new System.Drawing.Size(190, 69);
            this.tbAudioBalance.TabIndex = 89;
            this.tbAudioBalance.TickFrequency = 5;
            this.tbAudioBalance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudioBalance.Scroll += new System.EventHandler(this.tbAudioBalance_Scroll);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(12, 688);
            this.label54.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(72, 25);
            this.label54.TabIndex = 88;
            this.label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            this.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioVolume.Location = new System.Drawing.Point(90, 679);
            this.tbAudioVolume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbAudioVolume.Maximum = 100;
            this.tbAudioVolume.Minimum = 20;
            this.tbAudioVolume.Name = "tbAudioVolume";
            this.tbAudioVolume.Size = new System.Drawing.Size(193, 69);
            this.tbAudioVolume.TabIndex = 87;
            this.tbAudioVolume.TickFrequency = 10;
            this.tbAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudioVolume.Value = 80;
            this.tbAudioVolume.Scroll += new System.EventHandler(this.tbAudioVolume_Scroll);
            // 
            // cbRecordAudio
            // 
            this.cbRecordAudio.AutoSize = true;
            this.cbRecordAudio.Checked = true;
            this.cbRecordAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecordAudio.Location = new System.Drawing.Point(422, 594);
            this.cbRecordAudio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbRecordAudio.Name = "cbRecordAudio";
            this.cbRecordAudio.Size = new System.Drawing.Size(182, 29);
            this.cbRecordAudio.TabIndex = 86;
            this.cbRecordAudio.Text = "Play/Record audio";
            this.cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(15, 627);
            this.cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(587, 33);
            this.cbAudioOutputDevice.TabIndex = 85;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 596);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 25);
            this.label15.TabIndex = 84;
            this.label15.Text = "Audio output device";
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(499, 437);
            this.cbUseBestAudioInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(106, 29);
            this.cbUseBestAudioInputFormat.TabIndex = 83;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestAudioInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestAudioInputFormat_CheckedChanged);
            // 
            // btAudioInputDeviceSettings
            // 
            this.btAudioInputDeviceSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAudioInputDeviceSettings.Location = new System.Drawing.Point(478, 360);
            this.btAudioInputDeviceSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            this.btAudioInputDeviceSettings.Size = new System.Drawing.Size(127, 44);
            this.btAudioInputDeviceSettings.TabIndex = 82;
            this.btAudioInputDeviceSettings.Text = "Settings";
            this.btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            this.btAudioInputDeviceSettings.Click += new System.EventHandler(this.btAudioInputDeviceSettings_Click);
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(13, 471);
            this.cbAudioInputLine.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(266, 33);
            this.cbAudioInputLine.TabIndex = 81;
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(305, 471);
            this.cbAudioInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(297, 33);
            this.cbAudioInputFormat.TabIndex = 80;
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(13, 363);
            this.cbAudioInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(451, 33);
            this.cbAudioInputDevice.TabIndex = 79;
            this.cbAudioInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 440);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 25);
            this.label22.TabIndex = 78;
            this.label22.Text = "Audio input line";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 333);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(161, 25);
            this.label23.TabIndex = 77;
            this.label23.Text = "Audio input device";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(300, 437);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(113, 25);
            this.label25.TabIndex = 76;
            this.label25.Text = "Input format";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDebugMode);
            this.tabPage4.Controls.Add(this.mmLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage4.Size = new System.Drawing.Size(622, 783);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(18, 21);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(144, 29);
            this.cbDebugMode.TabIndex = 78;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(18, 65);
            this.mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(574, 687);
            this.mmLog.TabIndex = 77;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.White;
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // llVideoTutorials
            // 
            this.llVideoTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llVideoTutorials.AutoSize = true;
            this.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llVideoTutorials.Location = new System.Drawing.Point(1242, 6);
            this.llVideoTutorials.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.llVideoTutorials.Name = "llVideoTutorials";
            this.llVideoTutorials.Size = new System.Drawing.Size(167, 25);
            this.llVideoTutorials.TabIndex = 92;
            this.llVideoTutorials.TabStop = true;
            this.llVideoTutorials.Text = "View video tutorials";
            this.llVideoTutorials.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVideoTutorials_LinkClicked);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(835, 6);
            this.label34.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(361, 25);
            this.label34.TabIndex = 97;
            this.label34.Text = "Much more features available in Main Demo";
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScreenshot.Location = new System.Drawing.Point(1220, 783);
            this.btSaveScreenshot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(173, 44);
            this.btSaveScreenshot.TabIndex = 108;
            this.btSaveScreenshot.Text = "Save snapshot";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(1055, 783);
            this.btResume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(92, 44);
            this.btResume.TabIndex = 107;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(953, 783);
            this.btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(92, 44);
            this.btPause.TabIndex = 106;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(647, 48);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(747, 650);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 109;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 844);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.btSaveScreenshot);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.llVideoTutorials);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Virtual Camera Streamer Demo - Video Capture SDK .Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.Button btAudioInputDeviceSettings;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TrackBar tbAudioBalance;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TrackBar tbAudioVolume;
        private System.Windows.Forms.CheckBox cbRecordAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Button btVideoCaptureDeviceSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

