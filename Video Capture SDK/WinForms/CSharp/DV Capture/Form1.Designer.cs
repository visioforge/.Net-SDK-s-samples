using System;

namespace VisioForge_SDK_4_DV_Capture_CSharp_Demo
{
    using VisioForge.Types;

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
            this.rbCapture = new System.Windows.Forms.RadioButton();
            this.rbPreview = new System.Windows.Forms.RadioButton();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.rbDVResDC = new System.Windows.Forms.RadioButton();
            this.rbDVResQuarter = new System.Windows.Forms.RadioButton();
            this.rbDVResHalf = new System.Windows.Forms.RadioButton();
            this.rbDVResFull = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btDVStepFWD = new System.Windows.Forms.Button();
            this.btDVStepRev = new System.Windows.Forms.Button();
            this.btDVFF = new System.Windows.Forms.Button();
            this.btDVStop = new System.Windows.Forms.Button();
            this.btDVPause = new System.Windows.Forms.Button();
            this.btDVPlay = new System.Windows.Forms.Button();
            this.btDVRewind = new System.Windows.Forms.Button();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btOutputConfigure = new System.Windows.Forms.Button();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbDeinterlaceCAVT = new System.Windows.Forms.CheckBox();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.cbInvert = new System.Windows.Forms.CheckBox();
            this.cbGreyscale = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.tbDarkness = new System.Windows.Forms.TrackBar();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbLightness = new System.Windows.Forms.TrackBar();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btTextLogoAdd = new System.Windows.Forms.Button();
            this.btLogoRemove = new System.Windows.Forms.Button();
            this.btLogoEdit = new System.Windows.Forms.Button();
            this.lbLogos = new System.Windows.Forms.ListBox();
            this.btImageLogoAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.llVideoTutorials = new System.Windows.Forms.LinkLabel();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbCapture
            // 
            this.rbCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbCapture.AutoSize = true;
            this.rbCapture.Location = new System.Drawing.Point(459, 381);
            this.rbCapture.Name = "rbCapture";
            this.rbCapture.Size = new System.Drawing.Size(62, 17);
            this.rbCapture.TabIndex = 64;
            this.rbCapture.Text = "Capture";
            this.rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            this.rbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPreview.AutoSize = true;
            this.rbPreview.Checked = true;
            this.rbPreview.Location = new System.Drawing.Point(390, 381);
            this.rbPreview.Name = "rbPreview";
            this.rbPreview.Size = new System.Drawing.Size(63, 17);
            this.rbPreview.TabIndex = 63;
            this.rbPreview.TabStop = true;
            this.rbPreview.Text = "Preview";
            this.rbPreview.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(751, 378);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 62;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(686, 378);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 61;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Location = new System.Drawing.Point(3, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(378, 395);
            this.tcMain.TabIndex = 57;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox21);
            this.tabPage1.Controls.Add(this.groupBox3);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.rbDVResDC);
            this.groupBox21.Controls.Add(this.rbDVResQuarter);
            this.groupBox21.Controls.Add(this.rbDVResHalf);
            this.groupBox21.Controls.Add(this.rbDVResFull);
            this.groupBox21.Location = new System.Drawing.Point(5, 116);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(361, 45);
            this.groupBox21.TabIndex = 130;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Resolution";
            // 
            // rbDVResDC
            // 
            this.rbDVResDC.AutoSize = true;
            this.rbDVResDC.Location = new System.Drawing.Point(279, 19);
            this.rbDVResDC.Name = "rbDVResDC";
            this.rbDVResDC.Size = new System.Drawing.Size(40, 17);
            this.rbDVResDC.TabIndex = 3;
            this.rbDVResDC.Text = "DC";
            this.rbDVResDC.UseVisualStyleBackColor = true;
            // 
            // rbDVResQuarter
            // 
            this.rbDVResQuarter.AutoSize = true;
            this.rbDVResQuarter.Location = new System.Drawing.Point(183, 19);
            this.rbDVResQuarter.Name = "rbDVResQuarter";
            this.rbDVResQuarter.Size = new System.Drawing.Size(60, 17);
            this.rbDVResQuarter.TabIndex = 2;
            this.rbDVResQuarter.Text = "Quarter";
            this.rbDVResQuarter.UseVisualStyleBackColor = true;
            // 
            // rbDVResHalf
            // 
            this.rbDVResHalf.AutoSize = true;
            this.rbDVResHalf.Location = new System.Drawing.Point(104, 19);
            this.rbDVResHalf.Name = "rbDVResHalf";
            this.rbDVResHalf.Size = new System.Drawing.Size(44, 17);
            this.rbDVResHalf.TabIndex = 1;
            this.rbDVResHalf.Text = "Half";
            this.rbDVResHalf.UseVisualStyleBackColor = true;
            // 
            // rbDVResFull
            // 
            this.rbDVResFull.AutoSize = true;
            this.rbDVResFull.Checked = true;
            this.rbDVResFull.Location = new System.Drawing.Point(22, 19);
            this.rbDVResFull.Name = "rbDVResFull";
            this.rbDVResFull.Size = new System.Drawing.Size(41, 17);
            this.rbDVResFull.TabIndex = 0;
            this.rbDVResFull.TabStop = true;
            this.rbDVResFull.Text = "Full";
            this.rbDVResFull.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btDVStepFWD);
            this.groupBox3.Controls.Add(this.btDVStepRev);
            this.groupBox3.Controls.Add(this.btDVFF);
            this.groupBox3.Controls.Add(this.btDVStop);
            this.groupBox3.Controls.Add(this.btDVPause);
            this.groupBox3.Controls.Add(this.btDVPlay);
            this.groupBox3.Controls.Add(this.btDVRewind);
            this.groupBox3.Location = new System.Drawing.Point(5, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 100);
            this.groupBox3.TabIndex = 129;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls";
            // 
            // btDVStepFWD
            // 
            this.btDVStepFWD.Location = new System.Drawing.Point(251, 58);
            this.btDVStepFWD.Name = "btDVStepFWD";
            this.btDVStepFWD.Size = new System.Drawing.Size(68, 23);
            this.btDVStepFWD.TabIndex = 6;
            this.btDVStepFWD.Text = "Step FWD";
            this.btDVStepFWD.UseVisualStyleBackColor = true;
            this.btDVStepFWD.Click += new System.EventHandler(this.btDVStepFWD_Click);
            // 
            // btDVStepRev
            // 
            this.btDVStepRev.Location = new System.Drawing.Point(52, 58);
            this.btDVStepRev.Name = "btDVStepRev";
            this.btDVStepRev.Size = new System.Drawing.Size(68, 23);
            this.btDVStepRev.TabIndex = 5;
            this.btDVStepRev.Text = "Step REV";
            this.btDVStepRev.UseVisualStyleBackColor = true;
            this.btDVStepRev.Click += new System.EventHandler(this.btDVStepRev_Click);
            // 
            // btDVFF
            // 
            this.btDVFF.Location = new System.Drawing.Point(286, 23);
            this.btDVFF.Name = "btDVFF";
            this.btDVFF.Size = new System.Drawing.Size(60, 23);
            this.btDVFF.TabIndex = 4;
            this.btDVFF.Text = "F.F.";
            this.btDVFF.UseVisualStyleBackColor = true;
            this.btDVFF.Click += new System.EventHandler(this.btDVFF_Click);
            // 
            // btDVStop
            // 
            this.btDVStop.Location = new System.Drawing.Point(220, 23);
            this.btDVStop.Name = "btDVStop";
            this.btDVStop.Size = new System.Drawing.Size(60, 23);
            this.btDVStop.TabIndex = 3;
            this.btDVStop.Text = "Stop";
            this.btDVStop.UseVisualStyleBackColor = true;
            this.btDVStop.Click += new System.EventHandler(this.btDVStop_Click);
            // 
            // btDVPause
            // 
            this.btDVPause.Location = new System.Drawing.Point(154, 23);
            this.btDVPause.Name = "btDVPause";
            this.btDVPause.Size = new System.Drawing.Size(60, 23);
            this.btDVPause.TabIndex = 2;
            this.btDVPause.Text = "Pause";
            this.btDVPause.UseVisualStyleBackColor = true;
            this.btDVPause.Click += new System.EventHandler(this.btDVPause_Click);
            // 
            // btDVPlay
            // 
            this.btDVPlay.Location = new System.Drawing.Point(88, 23);
            this.btDVPlay.Name = "btDVPlay";
            this.btDVPlay.Size = new System.Drawing.Size(60, 23);
            this.btDVPlay.TabIndex = 1;
            this.btDVPlay.Text = "Play";
            this.btDVPlay.UseVisualStyleBackColor = true;
            this.btDVPlay.Click += new System.EventHandler(this.btDVPlay_Click);
            // 
            // btDVRewind
            // 
            this.btDVRewind.Location = new System.Drawing.Point(22, 23);
            this.btDVRewind.Name = "btDVRewind";
            this.btDVRewind.Size = new System.Drawing.Size(60, 23);
            this.btDVRewind.TabIndex = 0;
            this.btDVRewind.Text = "Rewind";
            this.btDVRewind.UseVisualStyleBackColor = true;
            this.btDVRewind.Click += new System.EventHandler(this.btDVRewind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "fps";
            // 
            // cbUseBestVideoInputFormat
            // 
            this.cbUseBestVideoInputFormat.AutoSize = true;
            this.cbUseBestVideoInputFormat.Location = new System.Drawing.Point(188, 72);
            this.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat";
            this.cbUseBestVideoInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestVideoInputFormat.TabIndex = 127;
            this.cbUseBestVideoInputFormat.Text = "Use best";
            this.cbUseBestVideoInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestVideoInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestVideoInputFormat_CheckedChanged);
            // 
            // btVideoCaptureDeviceSettings
            // 
            this.btVideoCaptureDeviceSettings.Location = new System.Drawing.Point(269, 34);
            this.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings";
            this.btVideoCaptureDeviceSettings.Size = new System.Drawing.Size(66, 23);
            this.btVideoCaptureDeviceSettings.TabIndex = 126;
            this.btVideoCaptureDeviceSettings.Text = "Settings";
            this.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = true;
            this.btVideoCaptureDeviceSettings.Click += new System.EventHandler(this.btVideoCaptureDeviceSettings_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(266, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 125;
            this.label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            this.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFrameRate.FormattingEnabled = true;
            this.cbVideoInputFrameRate.Location = new System.Drawing.Point(269, 89);
            this.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            this.cbVideoInputFrameRate.Size = new System.Drawing.Size(65, 21);
            this.cbVideoInputFrameRate.TabIndex = 124;
            // 
            // cbVideoInputFormat
            // 
            this.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat.FormattingEnabled = true;
            this.cbVideoInputFormat.Location = new System.Drawing.Point(9, 89);
            this.cbVideoInputFormat.Name = "cbVideoInputFormat";
            this.cbVideoInputFormat.Size = new System.Drawing.Size(247, 21);
            this.cbVideoInputFormat.TabIndex = 123;
            this.cbVideoInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat_SelectedIndexChanged);
            // 
            // cbVideoInputDevice
            // 
            this.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputDevice.FormattingEnabled = true;
            this.cbVideoInputDevice.Location = new System.Drawing.Point(9, 36);
            this.cbVideoInputDevice.Name = "cbVideoInputDevice";
            this.cbVideoInputDevice.Size = new System.Drawing.Size(247, 21);
            this.cbVideoInputDevice.TabIndex = 122;
            this.cbVideoInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputDevice_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 121;
            this.label13.Text = "Video input format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 120;
            this.label11.Text = "Video input device";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(197, 221);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 13);
            this.label55.TabIndex = 90;
            this.label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            this.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioBalance.Location = new System.Drawing.Point(248, 216);
            this.tbAudioBalance.Maximum = 100;
            this.tbAudioBalance.Minimum = -100;
            this.tbAudioBalance.Name = "tbAudioBalance";
            this.tbAudioBalance.Size = new System.Drawing.Size(114, 45);
            this.tbAudioBalance.TabIndex = 89;
            this.tbAudioBalance.TickFrequency = 5;
            this.tbAudioBalance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAudioBalance.Scroll += new System.EventHandler(this.tbAudioBalance_Scroll);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 221);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 88;
            this.label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            this.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudioVolume.Location = new System.Drawing.Point(53, 216);
            this.tbAudioVolume.Maximum = 100;
            this.tbAudioVolume.Minimum = 20;
            this.tbAudioVolume.Name = "tbAudioVolume";
            this.tbAudioVolume.Size = new System.Drawing.Size(116, 45);
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
            this.cbRecordAudio.Location = new System.Drawing.Point(252, 172);
            this.cbRecordAudio.Name = "cbRecordAudio";
            this.cbRecordAudio.Size = new System.Drawing.Size(115, 17);
            this.cbRecordAudio.TabIndex = 86;
            this.cbRecordAudio.Text = "Play/Record audio";
            this.cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(8, 189);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(354, 21);
            this.cbAudioOutputDevice.TabIndex = 85;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 84;
            this.label15.Text = "Audio output device";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOutput);
            this.tabPage2.Controls.Add(this.edOutput);
            this.tabPage2.Controls.Add(this.lbInfo);
            this.tabPage2.Controls.Add(this.btOutputConfigure);
            this.tabPage2.Controls.Add(this.cbOutputFormat);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(340, 156);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 113;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(12, 158);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(322, 20);
            this.edOutput.TabIndex = 112;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(9, 58);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 111;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            this.btOutputConfigure.Location = new System.Drawing.Point(12, 74);
            this.btOutputConfigure.Name = "btOutputConfigure";
            this.btOutputConfigure.Size = new System.Drawing.Size(75, 23);
            this.btOutputConfigure.TabIndex = 110;
            this.btOutputConfigure.Text = "Configure";
            this.btOutputConfigure.UseVisualStyleBackColor = true;
            this.btOutputConfigure.Click += new System.EventHandler(this.btOutputConfigure_Click);
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "DV",
            "DV (Without reencoding)",
            "AVI",
            "WMV (Windows Media Video)",
            "MP4 (CPU)",
            "MP4 (GPU: Intel, Nvidia, AMD/ATI)",
            "Animated GIF",
            "MPEG-TS",
            "MOV"});
            this.cbOutputFormat.Location = new System.Drawing.Point(12, 30);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(279, 21);
            this.cbOutputFormat.TabIndex = 109;
            this.cbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputFormat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "File name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbDeinterlaceCAVT);
            this.tabPage3.Controls.Add(this.cbFlipY);
            this.tabPage3.Controls.Add(this.cbFlipX);
            this.tabPage3.Controls.Add(this.cbInvert);
            this.tabPage3.Controls.Add(this.cbGreyscale);
            this.tabPage3.Controls.Add(this.label201);
            this.tabPage3.Controls.Add(this.tbDarkness);
            this.tabPage3.Controls.Add(this.label200);
            this.tabPage3.Controls.Add(this.label199);
            this.tabPage3.Controls.Add(this.label198);
            this.tabPage3.Controls.Add(this.tbContrast);
            this.tabPage3.Controls.Add(this.tbLightness);
            this.tabPage3.Controls.Add(this.tbSaturation);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btTextLogoAdd);
            this.tabPage3.Controls.Add(this.btLogoRemove);
            this.tabPage3.Controls.Add(this.btLogoEdit);
            this.tabPage3.Controls.Add(this.lbLogos);
            this.tabPage3.Controls.Add(this.btImageLogoAdd);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(370, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Video effects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlaceCAVT
            // 
            this.cbDeinterlaceCAVT.AutoSize = true;
            this.cbDeinterlaceCAVT.Checked = true;
            this.cbDeinterlaceCAVT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeinterlaceCAVT.Location = new System.Drawing.Point(19, 318);
            this.cbDeinterlaceCAVT.Margin = new System.Windows.Forms.Padding(2);
            this.cbDeinterlaceCAVT.Name = "cbDeinterlaceCAVT";
            this.cbDeinterlaceCAVT.Size = new System.Drawing.Size(117, 17);
            this.cbDeinterlaceCAVT.TabIndex = 105;
            this.cbDeinterlaceCAVT.Text = "Deinterlace (CAVT)";
            this.cbDeinterlaceCAVT.UseVisualStyleBackColor = true;
            this.cbDeinterlaceCAVT.CheckedChanged += new System.EventHandler(this.cbDeinterlaceCAVT_CheckedChanged);
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(219, 289);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(52, 17);
            this.cbFlipY.TabIndex = 104;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(160, 289);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(52, 17);
            this.cbFlipX.TabIndex = 103;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            this.cbFlipX.CheckedChanged += new System.EventHandler(this.cbFlipX_CheckedChanged);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = true;
            this.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbInvert.Location = new System.Drawing.Point(99, 289);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.Size = new System.Drawing.Size(53, 17);
            this.cbInvert.TabIndex = 102;
            this.cbInvert.Text = "Invert";
            this.cbInvert.UseVisualStyleBackColor = true;
            this.cbInvert.CheckedChanged += new System.EventHandler(this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(19, 289);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbGreyscale.TabIndex = 101;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            this.cbGreyscale.CheckedChanged += new System.EventHandler(this.cbGreyscale_CheckedChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(152, 218);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(52, 13);
            this.label201.TabIndex = 100;
            this.label201.Text = "Darkness";
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbDarkness.Location = new System.Drawing.Point(152, 238);
            this.tbDarkness.Maximum = 255;
            this.tbDarkness.Name = "tbDarkness";
            this.tbDarkness.Size = new System.Drawing.Size(130, 45);
            this.tbDarkness.TabIndex = 99;
            this.tbDarkness.Scroll += new System.EventHandler(this.tbDarkness_Scroll);
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(16, 218);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(46, 13);
            this.label200.TabIndex = 98;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(152, 166);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(55, 13);
            this.label199.TabIndex = 97;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(16, 166);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(52, 13);
            this.label198.TabIndex = 96;
            this.label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(13, 238);
            this.tbContrast.Maximum = 255;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(130, 45);
            this.tbContrast.TabIndex = 95;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbLightness.Location = new System.Drawing.Point(13, 181);
            this.tbLightness.Maximum = 255;
            this.tbLightness.Name = "tbLightness";
            this.tbLightness.Size = new System.Drawing.Size(130, 45);
            this.tbLightness.TabIndex = 94;
            this.tbLightness.Scroll += new System.EventHandler(this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(152, 181);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(130, 45);
            this.tbSaturation.TabIndex = 93;
            this.tbSaturation.Value = 255;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = new System.Drawing.Point(118, 129);
            this.btTextLogoAdd.Name = "btTextLogoAdd";
            this.btTextLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btTextLogoAdd.TabIndex = 91;
            this.btTextLogoAdd.Text = "Add text logo";
            this.btTextLogoAdd.UseVisualStyleBackColor = true;
            this.btTextLogoAdd.Click += new System.EventHandler(this.btTextLogoAdd_Click);
            // 
            // btLogoRemove
            // 
            this.btLogoRemove.Location = new System.Drawing.Point(299, 129);
            this.btLogoRemove.Name = "btLogoRemove";
            this.btLogoRemove.Size = new System.Drawing.Size(59, 23);
            this.btLogoRemove.TabIndex = 90;
            this.btLogoRemove.Text = "Remove";
            this.btLogoRemove.UseVisualStyleBackColor = true;
            this.btLogoRemove.Click += new System.EventHandler(this.btLogoRemove_Click);
            // 
            // btLogoEdit
            // 
            this.btLogoEdit.Location = new System.Drawing.Point(234, 129);
            this.btLogoEdit.Name = "btLogoEdit";
            this.btLogoEdit.Size = new System.Drawing.Size(59, 23);
            this.btLogoEdit.TabIndex = 89;
            this.btLogoEdit.Text = "Edit";
            this.btLogoEdit.UseVisualStyleBackColor = true;
            this.btLogoEdit.Click += new System.EventHandler(this.btLogoEdit_Click);
            // 
            // lbLogos
            // 
            this.lbLogos.FormattingEnabled = true;
            this.lbLogos.Location = new System.Drawing.Point(13, 29);
            this.lbLogos.Name = "lbLogos";
            this.lbLogos.Size = new System.Drawing.Size(345, 95);
            this.lbLogos.TabIndex = 88;
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = new System.Drawing.Point(13, 129);
            this.btImageLogoAdd.Name = "btImageLogoAdd";
            this.btImageLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btImageLogoAdd.TabIndex = 87;
            this.btImageLogoAdd.Text = "Add image logo";
            this.btImageLogoAdd.UseVisualStyleBackColor = true;
            this.btImageLogoAdd.Click += new System.EventHandler(this.btImageLogoAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "More effects and settings available in Main Demo";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDebugMode);
            this.tabPage4.Controls.Add(this.mmLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(370, 369);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(8, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 78;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(8, 29);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(356, 334);
            this.mmLog.TabIndex = 77;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // llVideoTutorials
            // 
            this.llVideoTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llVideoTutorials.AutoSize = true;
            this.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llVideoTutorials.Location = new System.Drawing.Point(744, 9);
            this.llVideoTutorials.Name = "llVideoTutorials";
            this.llVideoTutorials.Size = new System.Drawing.Size(68, 13);
            this.llVideoTutorials.TabIndex = 92;
            this.llVideoTutorials.TabStop = true;
            this.llVideoTutorials.Text = "Video tutorial";
            this.llVideoTutorials.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVideoTutorials_LinkClicked);
            // 
            // VideoCapture1
            // 
            this.VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = false;
            this.VideoCapture1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoCapture1.Audio_CaptureDevice = "";
            this.VideoCapture1.Audio_CaptureDevice_CustomLatency = 0;
            this.VideoCapture1.Audio_CaptureDevice_Format = "";
            this.VideoCapture1.Audio_CaptureDevice_Format_UseBest = true;
            this.VideoCapture1.Audio_CaptureDevice_Line = "";
            this.VideoCapture1.Audio_CaptureDevice_MasterDevice = null;
            this.VideoCapture1.Audio_CaptureDevice_MasterDevice_Format = null;
            this.VideoCapture1.Audio_CaptureDevice_Path = null;
            this.VideoCapture1.Audio_CaptureSourceFilter = null;
            this.VideoCapture1.Audio_Channel_Mapper = null;
            this.VideoCapture1.Audio_Decoder = null;
            this.VideoCapture1.Audio_Effects_Enabled = false;
            this.VideoCapture1.Audio_Enhancer_Enabled = false;
            this.VideoCapture1.Audio_OutputDevice = "Default DirectSound Device";
            this.VideoCapture1.Audio_PCM_Converter = null;
            this.VideoCapture1.Audio_PlayAudio = true;
            this.VideoCapture1.Audio_RecordAudio = true;
            this.VideoCapture1.Audio_Sample_Grabber_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Pro_Enabled = false;
            this.VideoCapture1.Audio_VUMeter_Pro_Volume = 100;
            this.VideoCapture1.BackColor = System.Drawing.Color.Black;
            this.VideoCapture1.Barcode_Reader_Enabled = false;
            this.VideoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.VideoCapture1.BDA_Source = null;
            this.VideoCapture1.ChromaKey = null;
            this.VideoCapture1.Custom_Source = null;
            this.VideoCapture1.CustomRedist_Auto = true;
            this.VideoCapture1.CustomRedist_DisableDialog = false;
            this.VideoCapture1.CustomRedist_Path = null;
            this.VideoCapture1.Debug_Dir = "";
            this.VideoCapture1.Debug_DisableMessageDialogs = false;
            this.VideoCapture1.Debug_Mode = false;
            this.VideoCapture1.Debug_Telemetry = false;
            this.VideoCapture1.Decklink_Input = VisioForge.Types.DecklinkInput.Auto;
            this.VideoCapture1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.Auto;
            this.VideoCapture1.Decklink_Input_IREUSA = false;
            this.VideoCapture1.Decklink_Input_SMPTE = false;
            this.VideoCapture1.Decklink_Output = null;
            this.VideoCapture1.Decklink_Source = null;
            this.VideoCapture1.DirectCapture_Muxer = null;
            this.VideoCapture1.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full;
            this.VideoCapture1.Face_Tracking = null;
            this.VideoCapture1.IP_Camera_Source = null;
            this.VideoCapture1.Location = new System.Drawing.Point(390, 25);
            this.VideoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture;
            this.VideoCapture1.Motion_Detection = null;
            this.VideoCapture1.Motion_DetectionEx = null;
            this.VideoCapture1.MPEG_Audio_Decoder = "";
            this.VideoCapture1.MPEG_Demuxer = null;
            this.VideoCapture1.MPEG_Video_Decoder = "";
            this.VideoCapture1.MultiScreen_Enabled = false;
            this.VideoCapture1.Name = "VideoCapture1";
            this.VideoCapture1.Network_Streaming_Audio_Enabled = false;
            this.VideoCapture1.Network_Streaming_Enabled = false;
            this.VideoCapture1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV;
            this.VideoCapture1.Network_Streaming_Network_Port = 10;
            this.VideoCapture1.Network_Streaming_Output = null;
            this.VideoCapture1.Network_Streaming_URL = "";
            this.VideoCapture1.Network_Streaming_WMV_Maximum_Clients = 10;
            this.VideoCapture1.OSD_Enabled = false;
            this.VideoCapture1.Output_Filename = "";
            this.VideoCapture1.Output_Format = null;
            this.VideoCapture1.PIP_AddSampleGrabbers = false;
            this.VideoCapture1.PIP_ChromaKeySettings = null;
            this.VideoCapture1.PIP_Mode = VisioForge.Types.VFPIPMode.Custom;
            this.VideoCapture1.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN;
            this.VideoCapture1.Push_Source = null;
            this.VideoCapture1.Screen_Capture_Source = null;
            this.VideoCapture1.SeparateCapture_AutostartCapture = false;
            this.VideoCapture1.SeparateCapture_Enabled = false;
            this.VideoCapture1.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext";
            this.VideoCapture1.SeparateCapture_FileSizeThreshold = ((long)(0));
            this.VideoCapture1.SeparateCapture_GMFMode = true;
            this.VideoCapture1.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal;
            this.VideoCapture1.SeparateCapture_TimeThreshold = System.TimeSpan.Parse("00:00:00");
            this.VideoCapture1.Size = new System.Drawing.Size(422, 318);
            this.VideoCapture1.Start_DelayEnabled = false;
            this.VideoCapture1.TabIndex = 93;
            this.VideoCapture1.Tags = null;
            this.VideoCapture1.Timeshift_Settings = null;
            this.VideoCapture1.TVTuner_Channel = 0;
            this.VideoCapture1.TVTuner_Country = "";
            this.VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 80000000;
            this.VideoCapture1.TVTuner_FM_Tuning_Step = 160000000;
            this.VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 0;
            this.VideoCapture1.TVTuner_Frequency = 0;
            this.VideoCapture1.TVTuner_InputType = "";
            this.VideoCapture1.TVTuner_Mode = VisioForge.Types.VFTVTunerMode.Default;
            this.VideoCapture1.TVTuner_Name = "";
            this.VideoCapture1.TVTuner_TVFormat = VisioForge.Types.VFTVTunerVideoFormat.PAL_D;
            this.VideoCapture1.Video_CaptureDevice = "";
            this.VideoCapture1.Video_CaptureDevice_Format = "";
            this.VideoCapture1.Video_CaptureDevice_Format_UseBest = true;
            this.VideoCapture1.Video_CaptureDevice_FrameRate = 0D;
            this.VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = "";
            this.VideoCapture1.Video_CaptureDevice_IsAudioSource = false;
            this.VideoCapture1.Video_CaptureDevice_Path = null;
            this.VideoCapture1.Video_CaptureDevice_UseClosedCaptions = false;
            this.VideoCapture1.Video_CaptureDevice_UseRAWSampleGrabber = false;
            this.VideoCapture1.Video_Crop = null;
            this.VideoCapture1.Video_Decoder = null;
            this.VideoCapture1.Video_Effects_AllowMultipleStreams = false;
            this.VideoCapture1.Video_Effects_Enabled = false;
            this.VideoCapture1.Video_Effects_GPU_Enabled = false;
            this.VideoCapture1.Video_Effects_MergeImageLogos = false;
            this.VideoCapture1.Video_Effects_MergeTextLogos = false;
            this.VideoCapture1.Video_Resize = null;
            this.VideoCapture1.Video_ResizeOrCrop_Enabled = false;
            this.VideoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.VideoCapture1.Video_Sample_Grabber_Enabled = false;
            this.VideoCapture1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.VideoCapture1.Video_Still_Frames_Grabber_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_Enabled = false;
            this.VideoCapture1.Virtual_Camera_Output_LicenseKey = null;
            this.VideoCapture1.VLC_Path = null;
            this.VideoCapture1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoCapture1_OnError);
            this.VideoCapture1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.VideoCapture1_OnLicenseRequired);
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(387, 356);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 96;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScreenshot.Location = new System.Drawing.Point(686, 349);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(127, 23);
            this.btSaveScreenshot.TabIndex = 99;
            this.btSaveScreenshot.Text = "Save snapshot";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(616, 378);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 98;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(555, 378);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 97;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "Much more features available in Main Demo";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.White;
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 405);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSaveScreenshot);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.llVideoTutorials);
            this.Controls.Add(this.rbCapture);
            this.Controls.Add(this.rbPreview);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DV Capture Demo - Video Capture SDK .Net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCapture;
        private System.Windows.Forms.RadioButton rbPreview;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbUseBestVideoInputFormat;
        private System.Windows.Forms.Button btVideoCaptureDeviceSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TrackBar tbAudioBalance;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TrackBar tbAudioVolume;
        private System.Windows.Forms.CheckBox cbRecordAudio;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.RadioButton rbDVResDC;
        private System.Windows.Forms.RadioButton rbDVResQuarter;
        private System.Windows.Forms.RadioButton rbDVResHalf;
        private System.Windows.Forms.RadioButton rbDVResFull;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btDVStepFWD;
        private System.Windows.Forms.Button btDVStepRev;
        private System.Windows.Forms.Button btDVFF;
        private System.Windows.Forms.Button btDVStop;
        private System.Windows.Forms.Button btDVPause;
        private System.Windows.Forms.Button btDVPlay;
        private System.Windows.Forms.Button btDVRewind;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btOutputConfigure;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.CheckBox cbFlipX;
        private System.Windows.Forms.CheckBox cbInvert;
        private System.Windows.Forms.CheckBox cbGreyscale;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.TrackBar tbDarkness;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.TrackBar tbLightness;
        private System.Windows.Forms.TrackBar tbSaturation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.Button btLogoRemove;
        private System.Windows.Forms.Button btLogoEdit;
        private System.Windows.Forms.ListBox lbLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbDeinterlaceCAVT;
    }
}