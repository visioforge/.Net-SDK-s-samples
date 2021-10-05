using System;

namespace VisioForge_SDK_Screen_Capture_Demo
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbScreenSourceWindowText = new System.Windows.Forms.Label();
            this.btScreenSourceWindowSelect = new System.Windows.Forms.Button();
            this.rbScreenCaptureWindow = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbScreenCapture_DesktopDuplication = new System.Windows.Forms.CheckBox();
            this.cbScreenCaptureDisplayIndex = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            this.btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            this.cbAudioInputLine = new System.Windows.Forms.ComboBox();
            this.cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cbRecordAudio = new System.Windows.Forms.CheckBox();
            this.btScreenCaptureUpdate = new System.Windows.Forms.Button();
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
            this.lbInfo = new System.Windows.Forms.Label();
            this.btOutputConfigure = new System.Windows.Forms.Button();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
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
            this.label28 = new System.Windows.Forms.Label();
            this.btTextLogoAdd = new System.Windows.Forms.Button();
            this.btLogoRemove = new System.Windows.Forms.Button();
            this.btLogoEdit = new System.Windows.Forms.Button();
            this.lbLogos = new System.Windows.Forms.ListBox();
            this.btImageLogoAdd = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.cbUncAudio = new System.Windows.Forms.CheckBox();
            this.cbDecodeToRGB = new System.Windows.Forms.CheckBox();
            this.cbUncVideo = new System.Windows.Forms.CheckBox();
            this.cbUseLameInAVI = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbVUMeter2 = new System.Windows.Forms.PictureBox();
            this.pbVUMeter1 = new System.Windows.Forms.PictureBox();
            this.edVUMeterValues = new System.Windows.Forms.TextBox();
            this.cbVUMeters = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tbAudioBalance = new System.Windows.Forms.TrackBar();
            this.label54 = new System.Windows.Forms.Label();
            this.tbAudioVolume = new System.Windows.Forms.TrackBar();
            this.cbPlayAudio = new System.Windows.Forms.CheckBox();
            this.cbUseAudioInputFromVideoCaptureDevice = new System.Windows.Forms.CheckBox();
            this.cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.llVideoTutorials = new System.Windows.Forms.LinkLabel();
            this.VideoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.label34 = new System.Windows.Forms.Label();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.rbCapture = new System.Windows.Forms.RadioButton();
            this.rbPreview = new System.Windows.Forms.RadioButton();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVUMeter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVUMeter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.White;
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Location = new System.Drawing.Point(3, 4);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(375, 434);
            this.tcMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbScreenSourceWindowText);
            this.tabPage1.Controls.Add(this.btScreenSourceWindowSelect);
            this.tabPage1.Controls.Add(this.rbScreenCaptureWindow);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.cbScreenCapture_DesktopDuplication);
            this.tabPage1.Controls.Add(this.cbScreenCaptureDisplayIndex);
            this.tabPage1.Controls.Add(this.label93);
            this.tabPage1.Controls.Add(this.cbUseBestAudioInputFormat);
            this.tabPage1.Controls.Add(this.btAudioInputDeviceSettings);
            this.tabPage1.Controls.Add(this.cbAudioInputLine);
            this.tabPage1.Controls.Add(this.cbAudioInputFormat);
            this.tabPage1.Controls.Add(this.cbAudioInputDevice);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.cbRecordAudio);
            this.tabPage1.Controls.Add(this.btScreenCaptureUpdate);
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
            this.tabPage1.Size = new System.Drawing.Size(367, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbScreenSourceWindowText
            // 
            this.lbScreenSourceWindowText.AutoSize = true;
            this.lbScreenSourceWindowText.Location = new System.Drawing.Point(220, 183);
            this.lbScreenSourceWindowText.Name = "lbScreenSourceWindowText";
            this.lbScreenSourceWindowText.Size = new System.Drawing.Size(107, 13);
            this.lbScreenSourceWindowText.TabIndex = 94;
            this.lbScreenSourceWindowText.Text = "(no window selected)";
            // 
            // btScreenSourceWindowSelect
            // 
            this.btScreenSourceWindowSelect.Location = new System.Drawing.Point(312, 150);
            this.btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect";
            this.btScreenSourceWindowSelect.Size = new System.Drawing.Size(49, 23);
            this.btScreenSourceWindowSelect.TabIndex = 93;
            this.btScreenSourceWindowSelect.Text = "Select";
            this.btScreenSourceWindowSelect.UseVisualStyleBackColor = true;
            this.btScreenSourceWindowSelect.Click += new System.EventHandler(this.btScreenSourceWindowSelect_Click);
            // 
            // rbScreenCaptureWindow
            // 
            this.rbScreenCaptureWindow.AutoSize = true;
            this.rbScreenCaptureWindow.Location = new System.Drawing.Point(205, 153);
            this.rbScreenCaptureWindow.Name = "rbScreenCaptureWindow";
            this.rbScreenCaptureWindow.Size = new System.Drawing.Size(101, 17);
            this.rbScreenCaptureWindow.TabIndex = 91;
            this.rbScreenCaptureWindow.TabStop = true;
            this.rbScreenCaptureWindow.Text = "Capture window";
            this.rbScreenCaptureWindow.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(194, 10);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(167, 45);
            this.textBox2.TabIndex = 90;
            this.textBox2.Text = "You can update left/top position and mouse cursor capturing on-the-fly";
            // 
            // cbScreenCapture_DesktopDuplication
            // 
            this.cbScreenCapture_DesktopDuplication.AutoSize = true;
            this.cbScreenCapture_DesktopDuplication.Location = new System.Drawing.Point(10, 204);
            this.cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication";
            this.cbScreenCapture_DesktopDuplication.Size = new System.Drawing.Size(182, 17);
            this.cbScreenCapture_DesktopDuplication.TabIndex = 89;
            this.cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage";
            this.cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptureDisplayIndex
            // 
            this.cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScreenCaptureDisplayIndex.FormattingEnabled = true;
            this.cbScreenCaptureDisplayIndex.Location = new System.Drawing.Point(80, 154);
            this.cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex";
            this.cbScreenCaptureDisplayIndex.Size = new System.Drawing.Size(80, 21);
            this.cbScreenCaptureDisplayIndex.TabIndex = 85;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label93.Location = new System.Drawing.Point(7, 157);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(65, 13);
            this.label93.TabIndex = 84;
            this.label93.Text = "Display ID";
            // 
            // cbUseBestAudioInputFormat
            // 
            this.cbUseBestAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseBestAudioInputFormat.AutoSize = true;
            this.cbUseBestAudioInputFormat.Location = new System.Drawing.Point(293, 309);
            this.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            this.cbUseBestAudioInputFormat.Size = new System.Drawing.Size(68, 17);
            this.cbUseBestAudioInputFormat.TabIndex = 83;
            this.cbUseBestAudioInputFormat.Text = "Use best";
            this.cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            this.cbUseBestAudioInputFormat.CheckedChanged += new System.EventHandler(this.cbUseBestAudioInputFormat_CheckedChanged);
            // 
            // btAudioInputDeviceSettings
            // 
            this.btAudioInputDeviceSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAudioInputDeviceSettings.Location = new System.Drawing.Point(285, 277);
            this.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            this.btAudioInputDeviceSettings.Size = new System.Drawing.Size(76, 23);
            this.btAudioInputDeviceSettings.TabIndex = 82;
            this.btAudioInputDeviceSettings.Text = "Settings";
            this.btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            this.btAudioInputDeviceSettings.Click += new System.EventHandler(this.btAudioInputDeviceSettings_Click);
            // 
            // cbAudioInputLine
            // 
            this.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputLine.FormattingEnabled = true;
            this.cbAudioInputLine.Location = new System.Drawing.Point(10, 327);
            this.cbAudioInputLine.Name = "cbAudioInputLine";
            this.cbAudioInputLine.Size = new System.Drawing.Size(161, 21);
            this.cbAudioInputLine.TabIndex = 81;
            this.cbAudioInputLine.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputLine_SelectedIndexChanged);
            // 
            // cbAudioInputFormat
            // 
            this.cbAudioInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputFormat.FormattingEnabled = true;
            this.cbAudioInputFormat.Location = new System.Drawing.Point(184, 326);
            this.cbAudioInputFormat.Name = "cbAudioInputFormat";
            this.cbAudioInputFormat.Size = new System.Drawing.Size(177, 21);
            this.cbAudioInputFormat.TabIndex = 80;
            this.cbAudioInputFormat.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputFormat_SelectedIndexChanged);
            // 
            // cbAudioInputDevice
            // 
            this.cbAudioInputDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioInputDevice.FormattingEnabled = true;
            this.cbAudioInputDevice.Location = new System.Drawing.Point(10, 279);
            this.cbAudioInputDevice.Name = "cbAudioInputDevice";
            this.cbAudioInputDevice.Size = new System.Drawing.Size(269, 21);
            this.cbAudioInputDevice.TabIndex = 79;
            this.cbAudioInputDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioInputDevice_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 311);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 13);
            this.label22.TabIndex = 78;
            this.label22.Text = "Input line";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 261);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 77;
            this.label23.Text = "Input device";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(181, 309);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 76;
            this.label25.Text = "Input format";
            // 
            // cbRecordAudio
            // 
            this.cbRecordAudio.AutoSize = true;
            this.cbRecordAudio.Location = new System.Drawing.Point(10, 234);
            this.cbRecordAudio.Name = "cbRecordAudio";
            this.cbRecordAudio.Size = new System.Drawing.Size(90, 17);
            this.cbRecordAudio.TabIndex = 66;
            this.cbRecordAudio.Text = "Record audio";
            this.cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // btScreenCaptureUpdate
            // 
            this.btScreenCaptureUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btScreenCaptureUpdate.Location = new System.Drawing.Point(249, 61);
            this.btScreenCaptureUpdate.Name = "btScreenCaptureUpdate";
            this.btScreenCaptureUpdate.Size = new System.Drawing.Size(75, 23);
            this.btScreenCaptureUpdate.TabIndex = 65;
            this.btScreenCaptureUpdate.Text = "Update";
            this.btScreenCaptureUpdate.UseVisualStyleBackColor = true;
            this.btScreenCaptureUpdate.Click += new System.EventHandler(this.btScreenCaptureUpdate_Click);
            // 
            // cbScreenCapture_GrabMouseCursor
            // 
            this.cbScreenCapture_GrabMouseCursor.AutoSize = true;
            this.cbScreenCapture_GrabMouseCursor.Location = new System.Drawing.Point(10, 181);
            this.cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor";
            this.cbScreenCapture_GrabMouseCursor.Size = new System.Drawing.Size(129, 17);
            this.cbScreenCapture_GrabMouseCursor.TabIndex = 61;
            this.cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor";
            this.cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(131, 131);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(21, 13);
            this.label79.TabIndex = 60;
            this.label79.Text = "fps";
            // 
            // edScreenFrameRate
            // 
            this.edScreenFrameRate.Location = new System.Drawing.Point(80, 128);
            this.edScreenFrameRate.Name = "edScreenFrameRate";
            this.edScreenFrameRate.Size = new System.Drawing.Size(45, 20);
            this.edScreenFrameRate.TabIndex = 59;
            this.edScreenFrameRate.Text = "5";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label43.Location = new System.Drawing.Point(7, 131);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 58;
            this.label43.Text = "Frame rate";
            // 
            // edScreenBottom
            // 
            this.edScreenBottom.Location = new System.Drawing.Point(174, 89);
            this.edScreenBottom.Name = "edScreenBottom";
            this.edScreenBottom.Size = new System.Drawing.Size(44, 20);
            this.edScreenBottom.TabIndex = 57;
            this.edScreenBottom.Text = "480";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(131, 92);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 13);
            this.label42.TabIndex = 56;
            this.label42.Text = "Bottom";
            // 
            // edScreenRight
            // 
            this.edScreenRight.Location = new System.Drawing.Point(70, 89);
            this.edScreenRight.Name = "edScreenRight";
            this.edScreenRight.Size = new System.Drawing.Size(44, 20);
            this.edScreenRight.TabIndex = 55;
            this.edScreenRight.Text = "640";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(29, 92);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(32, 13);
            this.label40.TabIndex = 54;
            this.label40.Text = "Right";
            // 
            // edScreenTop
            // 
            this.edScreenTop.Location = new System.Drawing.Point(174, 63);
            this.edScreenTop.Name = "edScreenTop";
            this.edScreenTop.Size = new System.Drawing.Size(44, 20);
            this.edScreenTop.TabIndex = 53;
            this.edScreenTop.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(131, 66);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 52;
            this.label26.Text = "Top";
            // 
            // edScreenLeft
            // 
            this.edScreenLeft.Location = new System.Drawing.Point(70, 63);
            this.edScreenLeft.Name = "edScreenLeft";
            this.edScreenLeft.Size = new System.Drawing.Size(44, 20);
            this.edScreenLeft.TabIndex = 51;
            this.edScreenLeft.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(29, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 50;
            this.label24.Text = "Left";
            // 
            // rbScreenCustomArea
            // 
            this.rbScreenCustomArea.AutoSize = true;
            this.rbScreenCustomArea.Location = new System.Drawing.Point(10, 36);
            this.rbScreenCustomArea.Name = "rbScreenCustomArea";
            this.rbScreenCustomArea.Size = new System.Drawing.Size(84, 17);
            this.rbScreenCustomArea.TabIndex = 49;
            this.rbScreenCustomArea.Text = "Custom area";
            this.rbScreenCustomArea.UseVisualStyleBackColor = true;
            // 
            // rbScreenFullScreen
            // 
            this.rbScreenFullScreen.AutoSize = true;
            this.rbScreenFullScreen.Checked = true;
            this.rbScreenFullScreen.Location = new System.Drawing.Point(10, 12);
            this.rbScreenFullScreen.Name = "rbScreenFullScreen";
            this.rbScreenFullScreen.Size = new System.Drawing.Size(76, 17);
            this.rbScreenFullScreen.TabIndex = 48;
            this.rbScreenFullScreen.TabStop = true;
            this.rbScreenFullScreen.Text = "Full screen";
            this.rbScreenFullScreen.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOutput);
            this.tabPage2.Controls.Add(this.edOutput);
            this.tabPage2.Controls.Add(this.lbInfo);
            this.tabPage2.Controls.Add(this.btOutputConfigure);
            this.tabPage2.Controls.Add(this.cbOutputFormat);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(367, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(337, 155);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 127;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(11, 157);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(320, 20);
            this.edOutput.TabIndex = 126;
            this.edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(8, 57);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 13);
            this.lbInfo.TabIndex = 125;
            this.lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            this.btOutputConfigure.Location = new System.Drawing.Point(11, 73);
            this.btOutputConfigure.Name = "btOutputConfigure";
            this.btOutputConfigure.Size = new System.Drawing.Size(75, 23);
            this.btOutputConfigure.TabIndex = 124;
            this.btOutputConfigure.Text = "Configure";
            this.btOutputConfigure.UseVisualStyleBackColor = true;
            this.btOutputConfigure.Click += new System.EventHandler(this.btOutputConfigure_Click);
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "AVI",
            "WMV (Windows Media Video)",
            "MP4 (CPU)",
            "MP4 (GPU: Intel, Nvidia, AMD/ATI)",
            "Animated GIF",
            "MPEG-TS",
            "MOV"});
            this.cbOutputFormat.Location = new System.Drawing.Point(11, 29);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(350, 21);
            this.cbOutputFormat.TabIndex = 123;
            this.cbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 122;
            this.label9.Text = "File name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(39, 13);
            this.label27.TabIndex = 121;
            this.label27.Text = "Format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label29);
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
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Controls.Add(this.btTextLogoAdd);
            this.tabPage3.Controls.Add(this.btLogoRemove);
            this.tabPage3.Controls.Add(this.btLogoEdit);
            this.tabPage3.Controls.Add(this.lbLogos);
            this.tabPage3.Controls.Add(this.btImageLogoAdd);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(367, 408);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Video effects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(56, 380);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(239, 13);
            this.label29.TabIndex = 104;
            this.label29.Text = "More effects and settings available in Main Demo";
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(218, 288);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(52, 17);
            this.cbFlipY.TabIndex = 103;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(158, 288);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(52, 17);
            this.cbFlipX.TabIndex = 102;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            this.cbFlipX.CheckedChanged += new System.EventHandler(this.cbFlipX_CheckedChanged);
            // 
            // cbInvert
            // 
            this.cbInvert.AutoSize = true;
            this.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbInvert.Location = new System.Drawing.Point(98, 288);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.Size = new System.Drawing.Size(53, 17);
            this.cbInvert.TabIndex = 101;
            this.cbInvert.Text = "Invert";
            this.cbInvert.UseVisualStyleBackColor = true;
            this.cbInvert.CheckedChanged += new System.EventHandler(this.cbInvert_CheckedChanged);
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(18, 288);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cbGreyscale.TabIndex = 100;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            this.cbGreyscale.CheckedChanged += new System.EventHandler(this.cbGreyscale_CheckedChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(152, 217);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(52, 13);
            this.label201.TabIndex = 99;
            this.label201.Text = "Darkness";
            // 
            // tbDarkness
            // 
            this.tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            this.tbDarkness.Location = new System.Drawing.Point(152, 237);
            this.tbDarkness.Maximum = 255;
            this.tbDarkness.Name = "tbDarkness";
            this.tbDarkness.Size = new System.Drawing.Size(130, 45);
            this.tbDarkness.TabIndex = 98;
            this.tbDarkness.Scroll += new System.EventHandler(this.tbDarkness_Scroll);
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(16, 217);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(46, 13);
            this.label200.TabIndex = 97;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(152, 165);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(55, 13);
            this.label199.TabIndex = 96;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(16, 165);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(52, 13);
            this.label198.TabIndex = 95;
            this.label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(12, 237);
            this.tbContrast.Maximum = 255;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(130, 45);
            this.tbContrast.TabIndex = 94;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbLightness
            // 
            this.tbLightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbLightness.Location = new System.Drawing.Point(12, 180);
            this.tbLightness.Maximum = 255;
            this.tbLightness.Name = "tbLightness";
            this.tbLightness.Size = new System.Drawing.Size(130, 45);
            this.tbLightness.TabIndex = 93;
            this.tbLightness.Scroll += new System.EventHandler(this.tbLightness_Scroll);
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(152, 180);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(130, 45);
            this.tbSaturation.TabIndex = 92;
            this.tbSaturation.Value = 255;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(95, 13);
            this.label28.TabIndex = 91;
            this.label28.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            this.btTextLogoAdd.Location = new System.Drawing.Point(118, 128);
            this.btTextLogoAdd.Name = "btTextLogoAdd";
            this.btTextLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btTextLogoAdd.TabIndex = 90;
            this.btTextLogoAdd.Text = "Add text logo";
            this.btTextLogoAdd.UseVisualStyleBackColor = true;
            this.btTextLogoAdd.Click += new System.EventHandler(this.btTextLogoAdd_Click);
            // 
            // btLogoRemove
            // 
            this.btLogoRemove.Location = new System.Drawing.Point(298, 128);
            this.btLogoRemove.Name = "btLogoRemove";
            this.btLogoRemove.Size = new System.Drawing.Size(59, 23);
            this.btLogoRemove.TabIndex = 89;
            this.btLogoRemove.Text = "Remove";
            this.btLogoRemove.UseVisualStyleBackColor = true;
            this.btLogoRemove.Click += new System.EventHandler(this.btLogoRemove_Click);
            // 
            // btLogoEdit
            // 
            this.btLogoEdit.Location = new System.Drawing.Point(234, 128);
            this.btLogoEdit.Name = "btLogoEdit";
            this.btLogoEdit.Size = new System.Drawing.Size(59, 23);
            this.btLogoEdit.TabIndex = 88;
            this.btLogoEdit.Text = "Edit";
            this.btLogoEdit.UseVisualStyleBackColor = true;
            this.btLogoEdit.Click += new System.EventHandler(this.btLogoEdit_Click);
            // 
            // lbLogos
            // 
            this.lbLogos.FormattingEnabled = true;
            this.lbLogos.Location = new System.Drawing.Point(12, 28);
            this.lbLogos.Name = "lbLogos";
            this.lbLogos.Size = new System.Drawing.Size(345, 95);
            this.lbLogos.TabIndex = 87;
            // 
            // btImageLogoAdd
            // 
            this.btImageLogoAdd.Location = new System.Drawing.Point(12, 128);
            this.btImageLogoAdd.Name = "btImageLogoAdd";
            this.btImageLogoAdd.Size = new System.Drawing.Size(99, 23);
            this.btImageLogoAdd.TabIndex = 86;
            this.btImageLogoAdd.Text = "Add image logo";
            this.btImageLogoAdd.UseVisualStyleBackColor = true;
            this.btImageLogoAdd.Click += new System.EventHandler(this.btImageLogoAdd_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDebugMode);
            this.tabPage4.Controls.Add(this.mmLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(367, 408);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(11, 11);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 81;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(11, 34);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(347, 366);
            this.mmLog.TabIndex = 80;
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(756, 415);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 46;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(691, 415);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 45;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cbUncAudio
            // 
            this.cbUncAudio.AutoSize = true;
            this.cbUncAudio.Location = new System.Drawing.Point(13, 157);
            this.cbUncAudio.Name = "cbUncAudio";
            this.cbUncAudio.Size = new System.Drawing.Size(126, 17);
            this.cbUncAudio.TabIndex = 27;
            this.cbUncAudio.Text = "Uncompressed audio";
            this.cbUncAudio.UseVisualStyleBackColor = true;
            // 
            // cbDecodeToRGB
            // 
            this.cbDecodeToRGB.AutoSize = true;
            this.cbDecodeToRGB.Location = new System.Drawing.Point(36, 83);
            this.cbDecodeToRGB.Name = "cbDecodeToRGB";
            this.cbDecodeToRGB.Size = new System.Drawing.Size(102, 17);
            this.cbDecodeToRGB.TabIndex = 26;
            this.cbDecodeToRGB.Text = "Decode to RGB";
            this.cbDecodeToRGB.UseVisualStyleBackColor = true;
            // 
            // cbUncVideo
            // 
            this.cbUncVideo.AutoSize = true;
            this.cbUncVideo.Location = new System.Drawing.Point(13, 62);
            this.cbUncVideo.Name = "cbUncVideo";
            this.cbUncVideo.Size = new System.Drawing.Size(126, 17);
            this.cbUncVideo.TabIndex = 25;
            this.cbUncVideo.Text = "Uncompressed video";
            this.cbUncVideo.UseVisualStyleBackColor = true;
            // 
            // cbUseLameInAVI
            // 
            this.cbUseLameInAVI.AutoSize = true;
            this.cbUseLameInAVI.Location = new System.Drawing.Point(13, 263);
            this.cbUseLameInAVI.Name = "cbUseLameInAVI";
            this.cbUseLameInAVI.Size = new System.Drawing.Size(168, 17);
            this.cbUseLameInAVI.TabIndex = 24;
            this.cbUseLameInAVI.Text = "Use LAME for audio encoding";
            this.cbUseLameInAVI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Audio codec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Sample rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "BPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Channels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Video codec";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "Input line";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Input device";
            // 
            // pbVUMeter2
            // 
            this.pbVUMeter2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbVUMeter2.Location = new System.Drawing.Point(313, 187);
            this.pbVUMeter2.Name = "pbVUMeter2";
            this.pbVUMeter2.Size = new System.Drawing.Size(119, 53);
            this.pbVUMeter2.TabIndex = 84;
            this.pbVUMeter2.TabStop = false;
            // 
            // pbVUMeter1
            // 
            this.pbVUMeter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbVUMeter1.Location = new System.Drawing.Point(183, 187);
            this.pbVUMeter1.Name = "pbVUMeter1";
            this.pbVUMeter1.Size = new System.Drawing.Size(119, 53);
            this.pbVUMeter1.TabIndex = 83;
            this.pbVUMeter1.TabStop = false;
            // 
            // edVUMeterValues
            // 
            this.edVUMeterValues.Location = new System.Drawing.Point(34, 210);
            this.edVUMeterValues.Name = "edVUMeterValues";
            this.edVUMeterValues.Size = new System.Drawing.Size(110, 20);
            this.edVUMeterValues.TabIndex = 82;
            // 
            // cbVUMeters
            // 
            this.cbVUMeters.AutoSize = true;
            this.cbVUMeters.Location = new System.Drawing.Point(26, 187);
            this.cbVUMeters.Name = "cbVUMeters";
            this.cbVUMeters.Size = new System.Drawing.Size(107, 17);
            this.cbVUMeters.TabIndex = 81;
            this.cbVUMeters.Text = "Enable VU Meter";
            this.cbVUMeters.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(347, 114);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 13);
            this.label55.TabIndex = 80;
            this.label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            this.tbAudioBalance.Location = new System.Drawing.Point(350, 128);
            this.tbAudioBalance.Maximum = 100;
            this.tbAudioBalance.Minimum = -100;
            this.tbAudioBalance.Name = "tbAudioBalance";
            this.tbAudioBalance.Size = new System.Drawing.Size(82, 45);
            this.tbAudioBalance.TabIndex = 79;
            this.tbAudioBalance.TickFrequency = 5;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(239, 114);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 78;
            this.label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            this.tbAudioVolume.Location = new System.Drawing.Point(241, 128);
            this.tbAudioVolume.Maximum = 1000;
            this.tbAudioVolume.Minimum = 600;
            this.tbAudioVolume.Name = "tbAudioVolume";
            this.tbAudioVolume.Size = new System.Drawing.Size(82, 45);
            this.tbAudioVolume.TabIndex = 77;
            this.tbAudioVolume.TickFrequency = 10;
            this.tbAudioVolume.Value = 700;
            // 
            // cbPlayAudio
            // 
            this.cbPlayAudio.AutoSize = true;
            this.cbPlayAudio.Checked = true;
            this.cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlayAudio.Location = new System.Drawing.Point(141, 113);
            this.cbPlayAudio.Name = "cbPlayAudio";
            this.cbPlayAudio.Size = new System.Drawing.Size(75, 17);
            this.cbPlayAudio.TabIndex = 76;
            this.cbPlayAudio.Text = "Play audio";
            this.cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbUseAudioInputFromVideoCaptureDevice
            // 
            this.cbUseAudioInputFromVideoCaptureDevice.AutoSize = true;
            this.cbUseAudioInputFromVideoCaptureDevice.Location = new System.Drawing.Point(251, 16);
            this.cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice";
            this.cbUseAudioInputFromVideoCaptureDevice.Size = new System.Drawing.Size(187, 17);
            this.cbUseAudioInputFromVideoCaptureDevice.TabIndex = 74;
            this.cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source";
            this.cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            this.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutputDevice.FormattingEnabled = true;
            this.cbAudioOutputDevice.Location = new System.Drawing.Point(26, 130);
            this.cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            this.cbAudioOutputDevice.Size = new System.Drawing.Size(190, 21);
            this.cbAudioOutputDevice.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 71;
            this.label15.Text = "Output device";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Input format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Audio codec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Sample rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "BPS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Channels";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Video codec";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 66;
            this.label16.Text = "Input line";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Input device";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(313, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 53);
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Location = new System.Drawing.Point(183, 187);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 53);
            this.pictureBox2.TabIndex = 83;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 82;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(347, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 80;
            this.label18.Text = "Balance";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(239, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 78;
            this.label19.Text = "Volume";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 71;
            this.label20.Text = "Output device";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(239, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "Input format";
            // 
            // llVideoTutorials
            // 
            this.llVideoTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llVideoTutorials.AutoSize = true;
            this.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llVideoTutorials.Location = new System.Drawing.Point(749, 9);
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
            this.VideoCapture1.Location = new System.Drawing.Point(387, 26);
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
            this.VideoCapture1.Size = new System.Drawing.Size(430, 311);
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
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(488, 9);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(214, 13);
            this.label34.TabIndex = 96;
            this.label34.Text = "Much more features available in Main Demo";
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(384, 384);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 103;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScreenshot.Location = new System.Drawing.Point(690, 379);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(127, 23);
            this.btSaveScreenshot.TabIndex = 104;
            this.btSaveScreenshot.Text = "Save snapshot";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            this.btSaveScreenshot.Click += new System.EventHandler(this.btSaveScreenshot_Click);
            // 
            // btResume
            // 
            this.btResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btResume.Location = new System.Drawing.Point(630, 415);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(55, 23);
            this.btResume.TabIndex = 106;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.Location = new System.Drawing.Point(569, 415);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(55, 23);
            this.btPause.TabIndex = 105;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // rbCapture
            // 
            this.rbCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCapture.AutoSize = true;
            this.rbCapture.Location = new System.Drawing.Point(456, 418);
            this.rbCapture.Name = "rbCapture";
            this.rbCapture.Size = new System.Drawing.Size(62, 17);
            this.rbCapture.TabIndex = 108;
            this.rbCapture.Text = "Capture";
            this.rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            this.rbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPreview.AutoSize = true;
            this.rbPreview.Checked = true;
            this.rbPreview.Location = new System.Drawing.Point(387, 418);
            this.rbPreview.Name = "rbPreview";
            this.rbPreview.Size = new System.Drawing.Size(63, 17);
            this.rbPreview.TabIndex = 107;
            this.rbPreview.TabStop = true;
            this.rbPreview.Text = "Preview";
            this.rbPreview.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 447);
            this.Controls.Add(this.rbCapture);
            this.Controls.Add(this.rbPreview);
            this.Controls.Add(this.btResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btSaveScreenshot);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.VideoCapture1);
            this.Controls.Add(this.llVideoTutorials);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Screen Capture Demo - Video Capture SDK .Net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbVUMeter2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVUMeter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudioVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btScreenCaptureUpdate;
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
        private System.Windows.Forms.CheckBox cbRecordAudio;
        private System.Windows.Forms.CheckBox cbUncAudio;
        private System.Windows.Forms.CheckBox cbDecodeToRGB;
        private System.Windows.Forms.CheckBox cbUncVideo;
        private System.Windows.Forms.CheckBox cbUseLameInAVI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbVUMeter2;
        private System.Windows.Forms.PictureBox pbVUMeter1;
        private System.Windows.Forms.TextBox edVUMeterValues;
        private System.Windows.Forms.CheckBox cbVUMeters;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TrackBar tbAudioBalance;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TrackBar tbAudioVolume;
        private System.Windows.Forms.CheckBox cbPlayAudio;
        private System.Windows.Forms.CheckBox cbUseAudioInputFromVideoCaptureDevice;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbUseBestAudioInputFormat;
        private System.Windows.Forms.Button btAudioInputDeviceSettings;
        private System.Windows.Forms.ComboBox cbAudioInputLine;
        private System.Windows.Forms.ComboBox cbAudioInputFormat;
        private System.Windows.Forms.ComboBox cbAudioInputDevice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        internal System.Windows.Forms.LinkLabel llVideoTutorials;
        private VisioForge.Controls.UI.WinForms.VideoCapture VideoCapture1;
        private System.Windows.Forms.ComboBox cbScreenCaptureDisplayIndex;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox cbScreenCapture_DesktopDuplication;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btOutputConfigure;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.RadioButton rbCapture;
        private System.Windows.Forms.RadioButton rbPreview;
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
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.Button btLogoRemove;
        private System.Windows.Forms.Button btLogoEdit;
        private System.Windows.Forms.ListBox lbLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbScreenSourceWindowText;
        private System.Windows.Forms.Button btScreenSourceWindowSelect;
        private System.Windows.Forms.RadioButton rbScreenCaptureWindow;
    }
}

