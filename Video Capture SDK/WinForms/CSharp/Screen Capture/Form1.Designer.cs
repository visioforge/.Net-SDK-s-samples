using System;

namespace VisioForge_SDK_Screen_Capture_Demo
{
    using VisioForge.Core.Types;

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

            mpegTSSettingsDialog?.Dispose();
            mpegTSSettingsDialog = null;

            mp4SettingsDialog?.Dispose();
            mp4SettingsDialog = null;

            mp4HWSettingsDialog?.Dispose();
            mp4HWSettingsDialog = null;

            movSettingsDialog?.Dispose();
            movSettingsDialog = null;

            gifSettingsDialog?.Dispose();
            gifSettingsDialog = null;

            aviSettingsDialog?.Dispose();
            aviSettingsDialog = null;

            wmvSettingsDialog?.Dispose();
            wmvSettingsDialog = null;

            windowCaptureForm?.Dispose();
            windowCaptureForm = null;

            screenshotSaveDialog?.Dispose();
            screenshotSaveDialog = null;

            tmRecording?.Dispose();
            tmRecording = null;

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
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            fontDialog1 = new System.Windows.Forms.FontDialog();
            tcMain = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            cbScreenCapture_HighlightMouseCursor = new System.Windows.Forms.CheckBox();
            lbScreenSourceWindowText = new System.Windows.Forms.Label();
            btScreenSourceWindowSelect = new System.Windows.Forms.Button();
            rbScreenCaptureWindow = new System.Windows.Forms.RadioButton();
            textBox2 = new System.Windows.Forms.TextBox();
            cbScreenCapture_DesktopDuplication = new System.Windows.Forms.CheckBox();
            cbScreenCaptureDisplayIndex = new System.Windows.Forms.ComboBox();
            label93 = new System.Windows.Forms.Label();
            cbUseBestAudioInputFormat = new System.Windows.Forms.CheckBox();
            btAudioInputDeviceSettings = new System.Windows.Forms.Button();
            cbAudioInputLine = new System.Windows.Forms.ComboBox();
            cbAudioInputFormat = new System.Windows.Forms.ComboBox();
            cbAudioInputDevice = new System.Windows.Forms.ComboBox();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            cbRecordAudio = new System.Windows.Forms.CheckBox();
            btScreenCaptureUpdate = new System.Windows.Forms.Button();
            cbScreenCapture_GrabMouseCursor = new System.Windows.Forms.CheckBox();
            label79 = new System.Windows.Forms.Label();
            edScreenFrameRate = new System.Windows.Forms.TextBox();
            label43 = new System.Windows.Forms.Label();
            edScreenBottom = new System.Windows.Forms.TextBox();
            label42 = new System.Windows.Forms.Label();
            edScreenRight = new System.Windows.Forms.TextBox();
            label40 = new System.Windows.Forms.Label();
            edScreenTop = new System.Windows.Forms.TextBox();
            label26 = new System.Windows.Forms.Label();
            edScreenLeft = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            rbScreenCustomArea = new System.Windows.Forms.RadioButton();
            rbScreenFullScreen = new System.Windows.Forms.RadioButton();
            tabPage2 = new System.Windows.Forms.TabPage();
            btSelectOutput = new System.Windows.Forms.Button();
            edOutput = new System.Windows.Forms.TextBox();
            lbInfo = new System.Windows.Forms.Label();
            btOutputConfigure = new System.Windows.Forms.Button();
            cbOutputFormat = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            label29 = new System.Windows.Forms.Label();
            cbFlipY = new System.Windows.Forms.CheckBox();
            cbFlipX = new System.Windows.Forms.CheckBox();
            cbInvert = new System.Windows.Forms.CheckBox();
            cbGreyscale = new System.Windows.Forms.CheckBox();
            label201 = new System.Windows.Forms.Label();
            tbDarkness = new System.Windows.Forms.TrackBar();
            label200 = new System.Windows.Forms.Label();
            label199 = new System.Windows.Forms.Label();
            label198 = new System.Windows.Forms.Label();
            tbContrast = new System.Windows.Forms.TrackBar();
            tbLightness = new System.Windows.Forms.TrackBar();
            tbSaturation = new System.Windows.Forms.TrackBar();
            label28 = new System.Windows.Forms.Label();
            btTextLogoAdd = new System.Windows.Forms.Button();
            btLogoRemove = new System.Windows.Forms.Button();
            btLogoEdit = new System.Windows.Forms.Button();
            lbLogos = new System.Windows.Forms.ListBox();
            btImageLogoAdd = new System.Windows.Forms.Button();
            tabPage4 = new System.Windows.Forms.TabPage();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            cbUncAudio = new System.Windows.Forms.CheckBox();
            cbDecodeToRGB = new System.Windows.Forms.CheckBox();
            cbUncVideo = new System.Windows.Forms.CheckBox();
            cbUseLameInAVI = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            pbVUMeter2 = new System.Windows.Forms.PictureBox();
            pbVUMeter1 = new System.Windows.Forms.PictureBox();
            edVUMeterValues = new System.Windows.Forms.TextBox();
            cbVUMeters = new System.Windows.Forms.CheckBox();
            label55 = new System.Windows.Forms.Label();
            tbAudioBalance = new System.Windows.Forms.TrackBar();
            label54 = new System.Windows.Forms.Label();
            tbAudioVolume = new System.Windows.Forms.TrackBar();
            cbPlayAudio = new System.Windows.Forms.CheckBox();
            cbUseAudioInputFromVideoCaptureDevice = new System.Windows.Forms.CheckBox();
            cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            label15 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            textBox1 = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            llVideoTutorials = new System.Windows.Forms.LinkLabel();
            label34 = new System.Windows.Forms.Label();
            lbTimestamp = new System.Windows.Forms.Label();
            btSaveScreenshot = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            rbCapture = new System.Windows.Forms.RadioButton();
            rbPreview = new System.Windows.Forms.RadioButton();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            tcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbVUMeter2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVUMeter1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // fontDialog1
            // 
            fontDialog1.Color = System.Drawing.Color.White;
            fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            fontDialog1.FontMustExist = true;
            fontDialog1.ShowColor = true;
            // 
            // tcMain
            // 
            tcMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tcMain.Controls.Add(tabPage1);
            tcMain.Controls.Add(tabPage2);
            tcMain.Controls.Add(tabPage3);
            tcMain.Controls.Add(tabPage4);
            tcMain.Location = new System.Drawing.Point(5, 8);
            tcMain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new System.Drawing.Size(625, 835);
            tcMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbScreenCapture_HighlightMouseCursor);
            tabPage1.Controls.Add(lbScreenSourceWindowText);
            tabPage1.Controls.Add(btScreenSourceWindowSelect);
            tabPage1.Controls.Add(rbScreenCaptureWindow);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(cbScreenCapture_DesktopDuplication);
            tabPage1.Controls.Add(cbScreenCaptureDisplayIndex);
            tabPage1.Controls.Add(label93);
            tabPage1.Controls.Add(cbUseBestAudioInputFormat);
            tabPage1.Controls.Add(btAudioInputDeviceSettings);
            tabPage1.Controls.Add(cbAudioInputLine);
            tabPage1.Controls.Add(cbAudioInputFormat);
            tabPage1.Controls.Add(cbAudioInputDevice);
            tabPage1.Controls.Add(label22);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(label25);
            tabPage1.Controls.Add(cbRecordAudio);
            tabPage1.Controls.Add(btScreenCaptureUpdate);
            tabPage1.Controls.Add(cbScreenCapture_GrabMouseCursor);
            tabPage1.Controls.Add(label79);
            tabPage1.Controls.Add(edScreenFrameRate);
            tabPage1.Controls.Add(label43);
            tabPage1.Controls.Add(edScreenBottom);
            tabPage1.Controls.Add(label42);
            tabPage1.Controls.Add(edScreenRight);
            tabPage1.Controls.Add(label40);
            tabPage1.Controls.Add(edScreenTop);
            tabPage1.Controls.Add(label26);
            tabPage1.Controls.Add(edScreenLeft);
            tabPage1.Controls.Add(label24);
            tabPage1.Controls.Add(rbScreenCustomArea);
            tabPage1.Controls.Add(rbScreenFullScreen);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Size = new System.Drawing.Size(617, 797);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Input";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbScreenCapture_HighlightMouseCursor
            // 
            cbScreenCapture_HighlightMouseCursor.AutoSize = true;
            cbScreenCapture_HighlightMouseCursor.Location = new System.Drawing.Point(17, 385);
            cbScreenCapture_HighlightMouseCursor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenCapture_HighlightMouseCursor.Name = "cbScreenCapture_HighlightMouseCursor";
            cbScreenCapture_HighlightMouseCursor.Size = new System.Drawing.Size(224, 29);
            cbScreenCapture_HighlightMouseCursor.TabIndex = 95;
            cbScreenCapture_HighlightMouseCursor.Text = "Highlight mouse cursor";
            cbScreenCapture_HighlightMouseCursor.UseVisualStyleBackColor = true;
            // 
            // lbScreenSourceWindowText
            // 
            lbScreenSourceWindowText.AutoSize = true;
            lbScreenSourceWindowText.Location = new System.Drawing.Point(382, 257);
            lbScreenSourceWindowText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbScreenSourceWindowText.Name = "lbScreenSourceWindowText";
            lbScreenSourceWindowText.Size = new System.Drawing.Size(179, 25);
            lbScreenSourceWindowText.TabIndex = 94;
            lbScreenSourceWindowText.Text = "(no window selected)";
            // 
            // btScreenSourceWindowSelect
            // 
            btScreenSourceWindowSelect.Location = new System.Drawing.Point(520, 288);
            btScreenSourceWindowSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btScreenSourceWindowSelect.Name = "btScreenSourceWindowSelect";
            btScreenSourceWindowSelect.Size = new System.Drawing.Size(82, 44);
            btScreenSourceWindowSelect.TabIndex = 93;
            btScreenSourceWindowSelect.Text = "Select";
            btScreenSourceWindowSelect.UseVisualStyleBackColor = true;
            btScreenSourceWindowSelect.Click += btScreenSourceWindowSelect_Click;
            // 
            // rbScreenCaptureWindow
            // 
            rbScreenCaptureWindow.AutoSize = true;
            rbScreenCaptureWindow.Location = new System.Drawing.Point(342, 294);
            rbScreenCaptureWindow.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbScreenCaptureWindow.Name = "rbScreenCaptureWindow";
            rbScreenCaptureWindow.Size = new System.Drawing.Size(166, 29);
            rbScreenCaptureWindow.TabIndex = 91;
            rbScreenCaptureWindow.TabStop = true;
            rbScreenCaptureWindow.Text = "Capture window";
            rbScreenCaptureWindow.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.Color.White;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Location = new System.Drawing.Point(323, 19);
            textBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(278, 87);
            textBox2.TabIndex = 90;
            textBox2.Text = "You can update left/top position and mouse cursor capturing on-the-fly";
            // 
            // cbScreenCapture_DesktopDuplication
            // 
            cbScreenCapture_DesktopDuplication.AutoSize = true;
            cbScreenCapture_DesktopDuplication.Location = new System.Drawing.Point(17, 426);
            cbScreenCapture_DesktopDuplication.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenCapture_DesktopDuplication.Name = "cbScreenCapture_DesktopDuplication";
            cbScreenCapture_DesktopDuplication.Size = new System.Drawing.Size(301, 29);
            cbScreenCapture_DesktopDuplication.TabIndex = 89;
            cbScreenCapture_DesktopDuplication.Text = "Allow Desktop Duplication usage";
            cbScreenCapture_DesktopDuplication.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptureDisplayIndex
            // 
            cbScreenCaptureDisplayIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbScreenCaptureDisplayIndex.FormattingEnabled = true;
            cbScreenCaptureDisplayIndex.Location = new System.Drawing.Point(133, 296);
            cbScreenCaptureDisplayIndex.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenCaptureDisplayIndex.Name = "cbScreenCaptureDisplayIndex";
            cbScreenCaptureDisplayIndex.Size = new System.Drawing.Size(131, 33);
            cbScreenCaptureDisplayIndex.TabIndex = 85;
            // 
            // label93
            // 
            label93.AutoSize = true;
            label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label93.Location = new System.Drawing.Point(12, 302);
            label93.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label93.Name = "label93";
            label93.Size = new System.Drawing.Size(97, 20);
            label93.TabIndex = 84;
            label93.Text = "Display ID";
            // 
            // cbUseBestAudioInputFormat
            // 
            cbUseBestAudioInputFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbUseBestAudioInputFormat.AutoSize = true;
            cbUseBestAudioInputFormat.Location = new System.Drawing.Point(496, 594);
            cbUseBestAudioInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat";
            cbUseBestAudioInputFormat.Size = new System.Drawing.Size(106, 29);
            cbUseBestAudioInputFormat.TabIndex = 83;
            cbUseBestAudioInputFormat.Text = "Use best";
            cbUseBestAudioInputFormat.UseVisualStyleBackColor = true;
            cbUseBestAudioInputFormat.CheckedChanged += cbUseBestAudioInputFormat_CheckedChanged;
            // 
            // btAudioInputDeviceSettings
            // 
            btAudioInputDeviceSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btAudioInputDeviceSettings.Location = new System.Drawing.Point(475, 533);
            btAudioInputDeviceSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings";
            btAudioInputDeviceSettings.Size = new System.Drawing.Size(127, 44);
            btAudioInputDeviceSettings.TabIndex = 82;
            btAudioInputDeviceSettings.Text = "Settings";
            btAudioInputDeviceSettings.UseVisualStyleBackColor = true;
            btAudioInputDeviceSettings.Click += btAudioInputDeviceSettings_Click;
            // 
            // cbAudioInputLine
            // 
            cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputLine.FormattingEnabled = true;
            cbAudioInputLine.Location = new System.Drawing.Point(17, 629);
            cbAudioInputLine.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioInputLine.Name = "cbAudioInputLine";
            cbAudioInputLine.Size = new System.Drawing.Size(266, 33);
            cbAudioInputLine.TabIndex = 81;
            // 
            // cbAudioInputFormat
            // 
            cbAudioInputFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputFormat.FormattingEnabled = true;
            cbAudioInputFormat.Location = new System.Drawing.Point(307, 627);
            cbAudioInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioInputFormat.Name = "cbAudioInputFormat";
            cbAudioInputFormat.Size = new System.Drawing.Size(292, 33);
            cbAudioInputFormat.TabIndex = 80;
            // 
            // cbAudioInputDevice
            // 
            cbAudioInputDevice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioInputDevice.FormattingEnabled = true;
            cbAudioInputDevice.Location = new System.Drawing.Point(17, 537);
            cbAudioInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioInputDevice.Name = "cbAudioInputDevice";
            cbAudioInputDevice.Size = new System.Drawing.Size(446, 33);
            cbAudioInputDevice.TabIndex = 79;
            cbAudioInputDevice.SelectedIndexChanged += cbAudioInputDevice_SelectedIndexChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(12, 598);
            label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(86, 25);
            label22.TabIndex = 78;
            label22.Text = "Input line";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(12, 502);
            label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(109, 25);
            label23.TabIndex = 77;
            label23.Text = "Input device";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(302, 594);
            label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(113, 25);
            label25.TabIndex = 76;
            label25.Text = "Input format";
            // 
            // cbRecordAudio
            // 
            cbRecordAudio.AutoSize = true;
            cbRecordAudio.Location = new System.Drawing.Point(17, 467);
            cbRecordAudio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbRecordAudio.Name = "cbRecordAudio";
            cbRecordAudio.Size = new System.Drawing.Size(143, 29);
            cbRecordAudio.TabIndex = 66;
            cbRecordAudio.Text = "Record audio";
            cbRecordAudio.UseVisualStyleBackColor = true;
            // 
            // btScreenCaptureUpdate
            // 
            btScreenCaptureUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btScreenCaptureUpdate.Location = new System.Drawing.Point(415, 117);
            btScreenCaptureUpdate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btScreenCaptureUpdate.Name = "btScreenCaptureUpdate";
            btScreenCaptureUpdate.Size = new System.Drawing.Size(125, 44);
            btScreenCaptureUpdate.TabIndex = 65;
            btScreenCaptureUpdate.Text = "Update";
            btScreenCaptureUpdate.UseVisualStyleBackColor = true;
            btScreenCaptureUpdate.Click += btScreenCaptureUpdate_Click;
            // 
            // cbScreenCapture_GrabMouseCursor
            // 
            cbScreenCapture_GrabMouseCursor.AutoSize = true;
            cbScreenCapture_GrabMouseCursor.Location = new System.Drawing.Point(17, 348);
            cbScreenCapture_GrabMouseCursor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenCapture_GrabMouseCursor.Name = "cbScreenCapture_GrabMouseCursor";
            cbScreenCapture_GrabMouseCursor.Size = new System.Drawing.Size(213, 29);
            cbScreenCapture_GrabMouseCursor.TabIndex = 61;
            cbScreenCapture_GrabMouseCursor.Text = "Capture mouse cursor";
            cbScreenCapture_GrabMouseCursor.UseVisualStyleBackColor = true;
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Location = new System.Drawing.Point(218, 252);
            label79.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(37, 25);
            label79.TabIndex = 60;
            label79.Text = "fps";
            // 
            // edScreenFrameRate
            // 
            edScreenFrameRate.Location = new System.Drawing.Point(133, 246);
            edScreenFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenFrameRate.Name = "edScreenFrameRate";
            edScreenFrameRate.Size = new System.Drawing.Size(72, 31);
            edScreenFrameRate.TabIndex = 59;
            edScreenFrameRate.Text = "5";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label43.Location = new System.Drawing.Point(12, 252);
            label43.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(101, 20);
            label43.TabIndex = 58;
            label43.Text = "Frame rate";
            // 
            // edScreenBottom
            // 
            edScreenBottom.Location = new System.Drawing.Point(290, 171);
            edScreenBottom.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenBottom.Name = "edScreenBottom";
            edScreenBottom.Size = new System.Drawing.Size(71, 31);
            edScreenBottom.TabIndex = 57;
            edScreenBottom.Text = "480";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(218, 177);
            label42.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(72, 25);
            label42.TabIndex = 56;
            label42.Text = "Bottom";
            // 
            // edScreenRight
            // 
            edScreenRight.Location = new System.Drawing.Point(117, 171);
            edScreenRight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenRight.Name = "edScreenRight";
            edScreenRight.Size = new System.Drawing.Size(71, 31);
            edScreenRight.TabIndex = 55;
            edScreenRight.Text = "640";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(48, 177);
            label40.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(54, 25);
            label40.TabIndex = 54;
            label40.Text = "Right";
            // 
            // edScreenTop
            // 
            edScreenTop.Location = new System.Drawing.Point(290, 121);
            edScreenTop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenTop.Name = "edScreenTop";
            edScreenTop.Size = new System.Drawing.Size(71, 31);
            edScreenTop.TabIndex = 53;
            edScreenTop.Text = "0";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label26.Location = new System.Drawing.Point(218, 127);
            label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(40, 20);
            label26.TabIndex = 52;
            label26.Text = "Top";
            // 
            // edScreenLeft
            // 
            edScreenLeft.Location = new System.Drawing.Point(117, 121);
            edScreenLeft.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenLeft.Name = "edScreenLeft";
            edScreenLeft.Size = new System.Drawing.Size(71, 31);
            edScreenLeft.TabIndex = 51;
            edScreenLeft.Text = "0";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label24.Location = new System.Drawing.Point(48, 127);
            label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(42, 20);
            label24.TabIndex = 50;
            label24.Text = "Left";
            // 
            // rbScreenCustomArea
            // 
            rbScreenCustomArea.AutoSize = true;
            rbScreenCustomArea.Location = new System.Drawing.Point(17, 69);
            rbScreenCustomArea.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbScreenCustomArea.Name = "rbScreenCustomArea";
            rbScreenCustomArea.Size = new System.Drawing.Size(137, 29);
            rbScreenCustomArea.TabIndex = 49;
            rbScreenCustomArea.Text = "Custom area";
            rbScreenCustomArea.UseVisualStyleBackColor = true;
            // 
            // rbScreenFullScreen
            // 
            rbScreenFullScreen.AutoSize = true;
            rbScreenFullScreen.Checked = true;
            rbScreenFullScreen.Location = new System.Drawing.Point(17, 23);
            rbScreenFullScreen.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbScreenFullScreen.Name = "rbScreenFullScreen";
            rbScreenFullScreen.Size = new System.Drawing.Size(119, 29);
            rbScreenFullScreen.TabIndex = 48;
            rbScreenFullScreen.TabStop = true;
            rbScreenFullScreen.Text = "Full screen";
            rbScreenFullScreen.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btSelectOutput);
            tabPage2.Controls.Add(edOutput);
            tabPage2.Controls.Add(lbInfo);
            tabPage2.Controls.Add(btOutputConfigure);
            tabPage2.Controls.Add(cbOutputFormat);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label27);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Size = new System.Drawing.Size(617, 797);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Output";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(562, 298);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(40, 44);
            btSelectOutput.TabIndex = 127;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(18, 302);
            edOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(531, 31);
            edOutput.TabIndex = 126;
            edOutput.Text = "c:\\capture.avi";
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(13, 110);
            lbInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 125;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btOutputConfigure
            // 
            btOutputConfigure.Location = new System.Drawing.Point(18, 140);
            btOutputConfigure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btOutputConfigure.Name = "btOutputConfigure";
            btOutputConfigure.Size = new System.Drawing.Size(125, 44);
            btOutputConfigure.TabIndex = 124;
            btOutputConfigure.Text = "Configure";
            btOutputConfigure.UseVisualStyleBackColor = true;
            btOutputConfigure.Click += btOutputConfigure_Click;
            // 
            // cbOutputFormat
            // 
            cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputFormat.FormattingEnabled = true;
            cbOutputFormat.Items.AddRange(new object[] { "AVI", "WMV (Windows Media Video)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "MPEG-TS", "MOV" });
            cbOutputFormat.Location = new System.Drawing.Point(18, 56);
            cbOutputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbOutputFormat.Name = "cbOutputFormat";
            cbOutputFormat.Size = new System.Drawing.Size(581, 33);
            cbOutputFormat.TabIndex = 123;
            cbOutputFormat.SelectedIndexChanged += cbOutputFormat_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(13, 271);
            label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 25);
            label9.TabIndex = 122;
            label9.Text = "File name";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(13, 23);
            label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(69, 25);
            label27.TabIndex = 121;
            label27.Text = "Format";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label29);
            tabPage3.Controls.Add(cbFlipY);
            tabPage3.Controls.Add(cbFlipX);
            tabPage3.Controls.Add(cbInvert);
            tabPage3.Controls.Add(cbGreyscale);
            tabPage3.Controls.Add(label201);
            tabPage3.Controls.Add(tbDarkness);
            tabPage3.Controls.Add(label200);
            tabPage3.Controls.Add(label199);
            tabPage3.Controls.Add(label198);
            tabPage3.Controls.Add(tbContrast);
            tabPage3.Controls.Add(tbLightness);
            tabPage3.Controls.Add(tbSaturation);
            tabPage3.Controls.Add(label28);
            tabPage3.Controls.Add(btTextLogoAdd);
            tabPage3.Controls.Add(btLogoRemove);
            tabPage3.Controls.Add(btLogoEdit);
            tabPage3.Controls.Add(lbLogos);
            tabPage3.Controls.Add(btImageLogoAdd);
            tabPage3.Location = new System.Drawing.Point(4, 34);
            tabPage3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage3.Size = new System.Drawing.Size(617, 797);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Video effects";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(93, 731);
            label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(403, 25);
            label29.TabIndex = 104;
            label29.Text = "More effects and settings available in Main Demo";
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(363, 554);
            cbFlipY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFlipY.Name = "cbFlipY";
            cbFlipY.Size = new System.Drawing.Size(81, 29);
            cbFlipY.TabIndex = 103;
            cbFlipY.Text = "Flip Y";
            cbFlipY.UseVisualStyleBackColor = true;
            cbFlipY.CheckedChanged += cbFlipY_CheckedChanged;
            // 
            // cbFlipX
            // 
            cbFlipX.AutoSize = true;
            cbFlipX.Location = new System.Drawing.Point(263, 554);
            cbFlipX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFlipX.Name = "cbFlipX";
            cbFlipX.Size = new System.Drawing.Size(82, 29);
            cbFlipX.TabIndex = 102;
            cbFlipX.Text = "Flip X";
            cbFlipX.UseVisualStyleBackColor = true;
            cbFlipX.CheckedChanged += cbFlipX_CheckedChanged;
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(163, 554);
            cbInvert.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbInvert.Name = "cbInvert";
            cbInvert.Size = new System.Drawing.Size(83, 29);
            cbInvert.TabIndex = 101;
            cbInvert.Text = "Invert";
            cbInvert.UseVisualStyleBackColor = true;
            cbInvert.CheckedChanged += cbInvert_CheckedChanged;
            // 
            // cbGreyscale
            // 
            cbGreyscale.AutoSize = true;
            cbGreyscale.Location = new System.Drawing.Point(30, 554);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 100;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += cbGreyscale_CheckedChanged;
            // 
            // label201
            // 
            label201.AutoSize = true;
            label201.Location = new System.Drawing.Point(253, 417);
            label201.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label201.Name = "label201";
            label201.Size = new System.Drawing.Size(84, 25);
            label201.TabIndex = 99;
            label201.Text = "Darkness";
            // 
            // tbDarkness
            // 
            tbDarkness.BackColor = System.Drawing.SystemColors.Window;
            tbDarkness.Location = new System.Drawing.Point(253, 456);
            tbDarkness.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbDarkness.Maximum = 255;
            tbDarkness.Name = "tbDarkness";
            tbDarkness.Size = new System.Drawing.Size(217, 69);
            tbDarkness.TabIndex = 98;
            tbDarkness.Scroll += tbDarkness_Scroll;
            // 
            // label200
            // 
            label200.AutoSize = true;
            label200.Location = new System.Drawing.Point(27, 417);
            label200.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label200.Name = "label200";
            label200.Size = new System.Drawing.Size(79, 25);
            label200.TabIndex = 97;
            label200.Text = "Contrast";
            // 
            // label199
            // 
            label199.AutoSize = true;
            label199.Location = new System.Drawing.Point(253, 317);
            label199.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label199.Name = "label199";
            label199.Size = new System.Drawing.Size(93, 25);
            label199.TabIndex = 96;
            label199.Text = "Saturation";
            // 
            // label198
            // 
            label198.AutoSize = true;
            label198.Location = new System.Drawing.Point(27, 317);
            label198.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label198.Name = "label198";
            label198.Size = new System.Drawing.Size(86, 25);
            label198.TabIndex = 95;
            label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(20, 456);
            tbContrast.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(217, 69);
            tbContrast.TabIndex = 94;
            tbContrast.Scroll += tbContrast_Scroll;
            // 
            // tbLightness
            // 
            tbLightness.BackColor = System.Drawing.SystemColors.Window;
            tbLightness.Location = new System.Drawing.Point(20, 346);
            tbLightness.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbLightness.Maximum = 255;
            tbLightness.Name = "tbLightness";
            tbLightness.Size = new System.Drawing.Size(217, 69);
            tbLightness.TabIndex = 93;
            tbLightness.Scroll += tbLightness_Scroll;
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(253, 346);
            tbSaturation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(217, 69);
            tbSaturation.TabIndex = 92;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += tbSaturation_Scroll;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(17, 21);
            label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(158, 25);
            label28.TabIndex = 91;
            label28.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(197, 246);
            btTextLogoAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btTextLogoAdd.Name = "btTextLogoAdd";
            btTextLogoAdd.Size = new System.Drawing.Size(165, 44);
            btTextLogoAdd.TabIndex = 90;
            btTextLogoAdd.Text = "Add text logo";
            btTextLogoAdd.UseVisualStyleBackColor = true;
            btTextLogoAdd.Click += btTextLogoAdd_Click;
            // 
            // btLogoRemove
            // 
            btLogoRemove.Location = new System.Drawing.Point(497, 246);
            btLogoRemove.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btLogoRemove.Name = "btLogoRemove";
            btLogoRemove.Size = new System.Drawing.Size(98, 44);
            btLogoRemove.TabIndex = 89;
            btLogoRemove.Text = "Remove";
            btLogoRemove.UseVisualStyleBackColor = true;
            btLogoRemove.Click += btLogoRemove_Click;
            // 
            // btLogoEdit
            // 
            btLogoEdit.Location = new System.Drawing.Point(390, 246);
            btLogoEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btLogoEdit.Name = "btLogoEdit";
            btLogoEdit.Size = new System.Drawing.Size(98, 44);
            btLogoEdit.TabIndex = 88;
            btLogoEdit.Text = "Edit";
            btLogoEdit.UseVisualStyleBackColor = true;
            btLogoEdit.Click += btLogoEdit_Click;
            // 
            // lbLogos
            // 
            lbLogos.FormattingEnabled = true;
            lbLogos.ItemHeight = 25;
            lbLogos.Location = new System.Drawing.Point(20, 54);
            lbLogos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lbLogos.Name = "lbLogos";
            lbLogos.Size = new System.Drawing.Size(572, 179);
            lbLogos.TabIndex = 87;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(20, 246);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(165, 44);
            btImageLogoAdd.TabIndex = 86;
            btImageLogoAdd.Text = "Add image logo";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += btImageLogoAdd_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(cbDebugMode);
            tabPage4.Controls.Add(mmLog);
            tabPage4.Location = new System.Drawing.Point(4, 34);
            tabPage4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage4.Size = new System.Drawing.Size(617, 797);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(18, 21);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 81;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mmLog.Location = new System.Drawing.Point(18, 65);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(576, 700);
            mmLog.TabIndex = 80;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStop.Location = new System.Drawing.Point(1260, 798);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 46;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStart.Location = new System.Drawing.Point(1152, 798);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 45;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // cbUncAudio
            // 
            cbUncAudio.AutoSize = true;
            cbUncAudio.Location = new System.Drawing.Point(13, 157);
            cbUncAudio.Name = "cbUncAudio";
            cbUncAudio.Size = new System.Drawing.Size(126, 17);
            cbUncAudio.TabIndex = 27;
            cbUncAudio.Text = "Uncompressed audio";
            cbUncAudio.UseVisualStyleBackColor = true;
            // 
            // cbDecodeToRGB
            // 
            cbDecodeToRGB.AutoSize = true;
            cbDecodeToRGB.Location = new System.Drawing.Point(36, 83);
            cbDecodeToRGB.Name = "cbDecodeToRGB";
            cbDecodeToRGB.Size = new System.Drawing.Size(102, 17);
            cbDecodeToRGB.TabIndex = 26;
            cbDecodeToRGB.Text = "Decode to RGB";
            cbDecodeToRGB.UseVisualStyleBackColor = true;
            // 
            // cbUncVideo
            // 
            cbUncVideo.AutoSize = true;
            cbUncVideo.Location = new System.Drawing.Point(13, 62);
            cbUncVideo.Name = "cbUncVideo";
            cbUncVideo.Size = new System.Drawing.Size(126, 17);
            cbUncVideo.TabIndex = 25;
            cbUncVideo.Text = "Uncompressed video";
            cbUncVideo.UseVisualStyleBackColor = true;
            // 
            // cbUseLameInAVI
            // 
            cbUseLameInAVI.AutoSize = true;
            cbUseLameInAVI.Location = new System.Drawing.Point(13, 263);
            cbUseLameInAVI.Name = "cbUseLameInAVI";
            cbUseLameInAVI.Size = new System.Drawing.Size(168, 17);
            cbUseLameInAVI.TabIndex = 24;
            cbUseLameInAVI.Text = "Use LAME for audio encoding";
            cbUseLameInAVI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 114);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 13);
            label3.TabIndex = 23;
            label3.Text = "Audio codec";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 223);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 13);
            label5.TabIndex = 20;
            label5.Text = "Sample rate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(155, 191);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(28, 13);
            label4.TabIndex = 19;
            label4.Text = "BPS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 191);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 13);
            label2.TabIndex = 18;
            label2.Text = "Channels";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 13);
            label1.TabIndex = 17;
            label1.Text = "Video codec";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(23, 67);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(50, 13);
            label14.TabIndex = 66;
            label14.Text = "Input line";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(23, 17);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(66, 13);
            label12.TabIndex = 65;
            label12.Text = "Input device";
            // 
            // pbVUMeter2
            // 
            pbVUMeter2.BackColor = System.Drawing.Color.WhiteSmoke;
            pbVUMeter2.Location = new System.Drawing.Point(313, 187);
            pbVUMeter2.Name = "pbVUMeter2";
            pbVUMeter2.Size = new System.Drawing.Size(119, 53);
            pbVUMeter2.TabIndex = 84;
            pbVUMeter2.TabStop = false;
            // 
            // pbVUMeter1
            // 
            pbVUMeter1.BackColor = System.Drawing.Color.WhiteSmoke;
            pbVUMeter1.Location = new System.Drawing.Point(183, 187);
            pbVUMeter1.Name = "pbVUMeter1";
            pbVUMeter1.Size = new System.Drawing.Size(119, 53);
            pbVUMeter1.TabIndex = 83;
            pbVUMeter1.TabStop = false;
            // 
            // edVUMeterValues
            // 
            edVUMeterValues.Location = new System.Drawing.Point(34, 210);
            edVUMeterValues.Name = "edVUMeterValues";
            edVUMeterValues.Size = new System.Drawing.Size(110, 31);
            edVUMeterValues.TabIndex = 82;
            // 
            // cbVUMeters
            // 
            cbVUMeters.AutoSize = true;
            cbVUMeters.Location = new System.Drawing.Point(26, 187);
            cbVUMeters.Name = "cbVUMeters";
            cbVUMeters.Size = new System.Drawing.Size(107, 17);
            cbVUMeters.TabIndex = 81;
            cbVUMeters.Text = "Enable VU Meter";
            cbVUMeters.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new System.Drawing.Point(347, 114);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(46, 13);
            label55.TabIndex = 80;
            label55.Text = "Balance";
            // 
            // tbAudioBalance
            // 
            tbAudioBalance.Location = new System.Drawing.Point(350, 128);
            tbAudioBalance.Maximum = 100;
            tbAudioBalance.Minimum = -100;
            tbAudioBalance.Name = "tbAudioBalance";
            tbAudioBalance.Size = new System.Drawing.Size(82, 69);
            tbAudioBalance.TabIndex = 79;
            tbAudioBalance.TickFrequency = 5;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new System.Drawing.Point(239, 114);
            label54.Name = "label54";
            label54.Size = new System.Drawing.Size(42, 13);
            label54.TabIndex = 78;
            label54.Text = "Volume";
            // 
            // tbAudioVolume
            // 
            tbAudioVolume.Location = new System.Drawing.Point(241, 128);
            tbAudioVolume.Maximum = 1000;
            tbAudioVolume.Minimum = 600;
            tbAudioVolume.Name = "tbAudioVolume";
            tbAudioVolume.Size = new System.Drawing.Size(82, 69);
            tbAudioVolume.TabIndex = 77;
            tbAudioVolume.TickFrequency = 10;
            tbAudioVolume.Value = 700;
            // 
            // cbPlayAudio
            // 
            cbPlayAudio.AutoSize = true;
            cbPlayAudio.Checked = true;
            cbPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            cbPlayAudio.Location = new System.Drawing.Point(141, 113);
            cbPlayAudio.Name = "cbPlayAudio";
            cbPlayAudio.Size = new System.Drawing.Size(75, 17);
            cbPlayAudio.TabIndex = 76;
            cbPlayAudio.Text = "Play audio";
            cbPlayAudio.UseVisualStyleBackColor = true;
            // 
            // cbUseAudioInputFromVideoCaptureDevice
            // 
            cbUseAudioInputFromVideoCaptureDevice.AutoSize = true;
            cbUseAudioInputFromVideoCaptureDevice.Location = new System.Drawing.Point(251, 16);
            cbUseAudioInputFromVideoCaptureDevice.Name = "cbUseAudioInputFromVideoCaptureDevice";
            cbUseAudioInputFromVideoCaptureDevice.Size = new System.Drawing.Size(187, 17);
            cbUseAudioInputFromVideoCaptureDevice.TabIndex = 74;
            cbUseAudioInputFromVideoCaptureDevice.Text = "Use audio input from video source";
            cbUseAudioInputFromVideoCaptureDevice.UseVisualStyleBackColor = true;
            // 
            // cbAudioOutputDevice
            // 
            cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutputDevice.FormattingEnabled = true;
            cbAudioOutputDevice.Location = new System.Drawing.Point(26, 130);
            cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            cbAudioOutputDevice.Size = new System.Drawing.Size(190, 33);
            cbAudioOutputDevice.TabIndex = 72;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(23, 114);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(74, 13);
            label15.TabIndex = 71;
            label15.Text = "Output device";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(239, 67);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 64;
            label10.Text = "Input format";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 114);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 13);
            label6.TabIndex = 23;
            label6.Text = "Audio codec";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 223);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 13);
            label7.TabIndex = 20;
            label7.Text = "Sample rate";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(155, 191);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(28, 13);
            label8.TabIndex = 19;
            label8.Text = "BPS";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(10, 191);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(51, 13);
            label11.TabIndex = 18;
            label11.Text = "Channels";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(10, 20);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(67, 13);
            label13.TabIndex = 17;
            label13.Text = "Video codec";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(23, 67);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(50, 13);
            label16.TabIndex = 66;
            label16.Text = "Input line";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(23, 17);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(66, 13);
            label17.TabIndex = 65;
            label17.Text = "Input device";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            pictureBox1.Location = new System.Drawing.Point(313, 187);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(119, 53);
            pictureBox1.TabIndex = 84;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            pictureBox2.Location = new System.Drawing.Point(183, 187);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(119, 53);
            pictureBox2.TabIndex = 83;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(34, 210);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(110, 31);
            textBox1.TabIndex = 82;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(347, 114);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(46, 13);
            label18.TabIndex = 80;
            label18.Text = "Balance";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(239, 114);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(42, 13);
            label19.TabIndex = 78;
            label19.Text = "Volume";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(23, 114);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(74, 13);
            label20.TabIndex = 71;
            label20.Text = "Output device";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(239, 67);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(63, 13);
            label21.TabIndex = 64;
            label21.Text = "Input format";
            // 
            // llVideoTutorials
            // 
            llVideoTutorials.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            llVideoTutorials.AutoSize = true;
            llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            llVideoTutorials.Location = new System.Drawing.Point(1248, 17);
            llVideoTutorials.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            llVideoTutorials.Name = "llVideoTutorials";
            llVideoTutorials.Size = new System.Drawing.Size(119, 25);
            llVideoTutorials.TabIndex = 92;
            llVideoTutorials.TabStop = true;
            llVideoTutorials.Text = "Video tutorial";
            llVideoTutorials.LinkClicked += llVideoTutorials_LinkClicked;
            // 
            // label34
            // 
            label34.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(813, 17);
            label34.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(361, 25);
            label34.TabIndex = 96;
            label34.Text = "Much more features available in Main Demo";
            // 
            // lbTimestamp
            // 
            lbTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(640, 738);
            lbTimestamp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(209, 25);
            lbTimestamp.TabIndex = 103;
            lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // btSaveScreenshot
            // 
            btSaveScreenshot.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btSaveScreenshot.Location = new System.Drawing.Point(1150, 729);
            btSaveScreenshot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSaveScreenshot.Name = "btSaveScreenshot";
            btSaveScreenshot.Size = new System.Drawing.Size(212, 44);
            btSaveScreenshot.TabIndex = 104;
            btSaveScreenshot.Text = "Save snapshot";
            btSaveScreenshot.UseVisualStyleBackColor = true;
            btSaveScreenshot.Click += btSaveScreenshot_Click;
            // 
            // btResume
            // 
            btResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btResume.Location = new System.Drawing.Point(1050, 798);
            btResume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(92, 44);
            btResume.TabIndex = 106;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btPause
            // 
            btPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btPause.Location = new System.Drawing.Point(948, 798);
            btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(92, 44);
            btPause.TabIndex = 105;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // rbCapture
            // 
            rbCapture.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rbCapture.AutoSize = true;
            rbCapture.Location = new System.Drawing.Point(764, 808);
            rbCapture.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbCapture.Name = "rbCapture";
            rbCapture.Size = new System.Drawing.Size(99, 29);
            rbCapture.TabIndex = 108;
            rbCapture.Text = "Capture";
            rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            rbPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rbPreview.AutoSize = true;
            rbPreview.Checked = true;
            rbPreview.Location = new System.Drawing.Point(653, 808);
            rbPreview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbPreview.Name = "rbPreview";
            rbPreview.Size = new System.Drawing.Size(97, 29);
            rbPreview.TabIndex = 107;
            rbPreview.TabStop = true;
            rbPreview.Text = "Preview";
            rbPreview.UseVisualStyleBackColor = true;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(645, 50);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(717, 644);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 109;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1383, 860);
            Controls.Add(VideoView1);
            Controls.Add(rbCapture);
            Controls.Add(rbPreview);
            Controls.Add(btResume);
            Controls.Add(btPause);
            Controls.Add(btSaveScreenshot);
            Controls.Add(lbTimestamp);
            Controls.Add(label34);
            Controls.Add(llVideoTutorials);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(tcMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Screen Capture Demo - Video Capture SDK .Net";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbVUMeter2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVUMeter1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAudioVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.CheckBox cbScreenCapture_HighlightMouseCursor;
    }
}

