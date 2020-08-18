namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class MP3SettingsDialog
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
            this.btClose = new System.Windows.Forms.Button();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.label71 = new System.Windows.Forms.Label();
            this.tbLameEncodingQuality = new System.Windows.Forms.TrackBar();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.cbLameSampleRate = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbLameMono = new System.Windows.Forms.RadioButton();
            this.rbLameDualChannels = new System.Windows.Forms.RadioButton();
            this.rbLameJointStereo = new System.Windows.Forms.RadioButton();
            this.rbLameStandardStereo = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label74 = new System.Windows.Forms.Label();
            this.tbLameVBRQuality = new System.Windows.Forms.TrackBar();
            this.cbLameVBRMax = new System.Windows.Forms.ComboBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.cbLameVBRMin = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.cbLameCBRBitrate = new System.Windows.Forms.ComboBox();
            this.rbLameVBR = new System.Windows.Forms.RadioButton();
            this.rbLameCBR = new System.Windows.Forms.RadioButton();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.cbLameVoiceEncodingMode = new System.Windows.Forms.CheckBox();
            this.cbLameModeFixed = new System.Windows.Forms.CheckBox();
            this.cbLameEnableXingVBRTag = new System.Windows.Forms.CheckBox();
            this.cbLameDisableShortBlocks = new System.Windows.Forms.CheckBox();
            this.cbLameStrictISOCompilance = new System.Windows.Forms.CheckBox();
            this.cbLameKeepAllFrequences = new System.Windows.Forms.CheckBox();
            this.cbLameStrictlyEnforceVBRMinBitrate = new System.Windows.Forms.CheckBox();
            this.cbLameForceMono = new System.Windows.Forms.CheckBox();
            this.cbLameCRCProtected = new System.Windows.Forms.CheckBox();
            this.cbLameOriginal = new System.Windows.Forms.CheckBox();
            this.cbLameCopyright = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl4.SuspendLayout();
            this.tabPage17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLameEncodingQuality)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLameVBRQuality)).BeginInit();
            this.tabPage18.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(234, 397);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 48;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage17);
            this.tabControl4.Controls.Add(this.tabPage18);
            this.tabControl4.Location = new System.Drawing.Point(12, 8);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(281, 383);
            this.tabControl4.TabIndex = 50;
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.label71);
            this.tabPage17.Controls.Add(this.tbLameEncodingQuality);
            this.tabPage17.Controls.Add(this.label72);
            this.tabPage17.Controls.Add(this.label73);
            this.tabPage17.Controls.Add(this.cbLameSampleRate);
            this.tabPage17.Controls.Add(this.groupBox9);
            this.tabPage17.Controls.Add(this.groupBox10);
            this.tabPage17.Location = new System.Drawing.Point(4, 22);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(273, 357);
            this.tabPage17.TabIndex = 0;
            this.tabPage17.Text = "Main";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(19, 285);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(85, 13);
            this.label71.TabIndex = 27;
            this.label71.Text = "Encoding quality";
            // 
            // tbLameEncodingQuality
            // 
            this.tbLameEncodingQuality.BackColor = System.Drawing.SystemColors.Window;
            this.tbLameEncodingQuality.Location = new System.Drawing.Point(129, 285);
            this.tbLameEncodingQuality.Maximum = 8;
            this.tbLameEncodingQuality.Minimum = 1;
            this.tbLameEncodingQuality.Name = "tbLameEncodingQuality";
            this.tbLameEncodingQuality.Size = new System.Drawing.Size(107, 45);
            this.tbLameEncodingQuality.TabIndex = 26;
            this.tbLameEncodingQuality.Value = 7;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(201, 252);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(20, 13);
            this.label72.TabIndex = 22;
            this.label72.Text = "Hz";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(19, 252);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(63, 13);
            this.label73.TabIndex = 21;
            this.label73.Text = "Sample rate";
            // 
            // cbLameSampleRate
            // 
            this.cbLameSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLameSampleRate.FormattingEnabled = true;
            this.cbLameSampleRate.Items.AddRange(new object[] {
            "48000",
            "44100",
            "32000",
            "22050",
            "16000",
            "11025",
            "8000"});
            this.cbLameSampleRate.Location = new System.Drawing.Point(129, 249);
            this.cbLameSampleRate.Name = "cbLameSampleRate";
            this.cbLameSampleRate.Size = new System.Drawing.Size(66, 21);
            this.cbLameSampleRate.TabIndex = 20;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbLameMono);
            this.groupBox9.Controls.Add(this.rbLameDualChannels);
            this.groupBox9.Controls.Add(this.rbLameJointStereo);
            this.groupBox9.Controls.Add(this.rbLameStandardStereo);
            this.groupBox9.Location = new System.Drawing.Point(16, 177);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(220, 65);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Channels";
            // 
            // rbLameMono
            // 
            this.rbLameMono.AutoSize = true;
            this.rbLameMono.Location = new System.Drawing.Point(117, 42);
            this.rbLameMono.Name = "rbLameMono";
            this.rbLameMono.Size = new System.Drawing.Size(52, 17);
            this.rbLameMono.TabIndex = 3;
            this.rbLameMono.Text = "Mono";
            this.rbLameMono.UseVisualStyleBackColor = true;
            // 
            // rbLameDualChannels
            // 
            this.rbLameDualChannels.AutoSize = true;
            this.rbLameDualChannels.Location = new System.Drawing.Point(117, 19);
            this.rbLameDualChannels.Name = "rbLameDualChannels";
            this.rbLameDualChannels.Size = new System.Drawing.Size(93, 17);
            this.rbLameDualChannels.TabIndex = 2;
            this.rbLameDualChannels.Text = "Dual channels";
            this.rbLameDualChannels.UseVisualStyleBackColor = true;
            // 
            // rbLameJointStereo
            // 
            this.rbLameJointStereo.AutoSize = true;
            this.rbLameJointStereo.Location = new System.Drawing.Point(11, 42);
            this.rbLameJointStereo.Name = "rbLameJointStereo";
            this.rbLameJointStereo.Size = new System.Drawing.Size(79, 17);
            this.rbLameJointStereo.TabIndex = 1;
            this.rbLameJointStereo.Text = "Joint stereo";
            this.rbLameJointStereo.UseVisualStyleBackColor = true;
            // 
            // rbLameStandardStereo
            // 
            this.rbLameStandardStereo.AutoSize = true;
            this.rbLameStandardStereo.Checked = true;
            this.rbLameStandardStereo.Location = new System.Drawing.Point(11, 19);
            this.rbLameStandardStereo.Name = "rbLameStandardStereo";
            this.rbLameStandardStereo.Size = new System.Drawing.Size(100, 17);
            this.rbLameStandardStereo.TabIndex = 0;
            this.rbLameStandardStereo.TabStop = true;
            this.rbLameStandardStereo.Text = "Standard stereo";
            this.rbLameStandardStereo.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label74);
            this.groupBox10.Controls.Add(this.tbLameVBRQuality);
            this.groupBox10.Controls.Add(this.cbLameVBRMax);
            this.groupBox10.Controls.Add(this.label75);
            this.groupBox10.Controls.Add(this.label76);
            this.groupBox10.Controls.Add(this.cbLameVBRMin);
            this.groupBox10.Controls.Add(this.label77);
            this.groupBox10.Controls.Add(this.label78);
            this.groupBox10.Controls.Add(this.cbLameCBRBitrate);
            this.groupBox10.Controls.Add(this.rbLameVBR);
            this.groupBox10.Controls.Add(this.rbLameCBR);
            this.groupBox10.Location = new System.Drawing.Point(16, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(220, 165);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Mode";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(34, 134);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(39, 13);
            this.label74.TabIndex = 26;
            this.label74.Text = "Quality";
            // 
            // tbLameVBRQuality
            // 
            this.tbLameVBRQuality.BackColor = System.Drawing.SystemColors.Window;
            this.tbLameVBRQuality.Location = new System.Drawing.Point(92, 116);
            this.tbLameVBRQuality.Maximum = 9;
            this.tbLameVBRQuality.Name = "tbLameVBRQuality";
            this.tbLameVBRQuality.Size = new System.Drawing.Size(118, 45);
            this.tbLameVBRQuality.TabIndex = 25;
            this.tbLameVBRQuality.Value = 7;
            // 
            // cbLameVBRMax
            // 
            this.cbLameVBRMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLameVBRMax.FormattingEnabled = true;
            this.cbLameVBRMax.Items.AddRange(new object[] {
            "32",
            "40",
            "48",
            "56",
            "64",
            "80",
            "96",
            "112",
            "128",
            "160",
            "192",
            "224",
            "256",
            "320"});
            this.cbLameVBRMax.Location = new System.Drawing.Point(156, 89);
            this.cbLameVBRMax.Name = "cbLameVBRMax";
            this.cbLameVBRMax.Size = new System.Drawing.Size(54, 21);
            this.cbLameVBRMax.TabIndex = 24;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(127, 92);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(27, 13);
            this.label75.TabIndex = 23;
            this.label75.Text = "Max";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(34, 92);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(24, 13);
            this.label76.TabIndex = 21;
            this.label76.Text = "Min";
            // 
            // cbLameVBRMin
            // 
            this.cbLameVBRMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLameVBRMin.FormattingEnabled = true;
            this.cbLameVBRMin.Items.AddRange(new object[] {
            "32",
            "40",
            "48",
            "56",
            "64",
            "80",
            "96",
            "112",
            "128",
            "160",
            "192",
            "224",
            "256",
            "320"});
            this.cbLameVBRMin.Location = new System.Drawing.Point(64, 89);
            this.cbLameVBRMin.Name = "cbLameVBRMin";
            this.cbLameVBRMin.Size = new System.Drawing.Size(54, 21);
            this.cbLameVBRMin.TabIndex = 20;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(177, 45);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(31, 13);
            this.label77.TabIndex = 19;
            this.label77.Text = "Kbps";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(34, 45);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(40, 13);
            this.label78.TabIndex = 18;
            this.label78.Text = "Bit rate";
            // 
            // cbLameCBRBitrate
            // 
            this.cbLameCBRBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLameCBRBitrate.FormattingEnabled = true;
            this.cbLameCBRBitrate.Items.AddRange(new object[] {
            "32",
            "40",
            "48",
            "56",
            "64",
            "80",
            "96",
            "112",
            "128",
            "160",
            "192",
            "224",
            "256",
            "320"});
            this.cbLameCBRBitrate.Location = new System.Drawing.Point(113, 42);
            this.cbLameCBRBitrate.Name = "cbLameCBRBitrate";
            this.cbLameCBRBitrate.Size = new System.Drawing.Size(58, 21);
            this.cbLameCBRBitrate.TabIndex = 17;
            // 
            // rbLameVBR
            // 
            this.rbLameVBR.AutoSize = true;
            this.rbLameVBR.Location = new System.Drawing.Point(17, 66);
            this.rbLameVBR.Name = "rbLameVBR";
            this.rbLameVBR.Size = new System.Drawing.Size(104, 17);
            this.rbLameVBR.TabIndex = 1;
            this.rbLameVBR.Text = "Variable Bit Rate";
            this.rbLameVBR.UseVisualStyleBackColor = true;
            // 
            // rbLameCBR
            // 
            this.rbLameCBR.AutoSize = true;
            this.rbLameCBR.Checked = true;
            this.rbLameCBR.Location = new System.Drawing.Point(17, 19);
            this.rbLameCBR.Name = "rbLameCBR";
            this.rbLameCBR.Size = new System.Drawing.Size(108, 17);
            this.rbLameCBR.TabIndex = 0;
            this.rbLameCBR.TabStop = true;
            this.rbLameCBR.Text = "Constant Bit Rate";
            this.rbLameCBR.UseVisualStyleBackColor = true;
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.cbLameVoiceEncodingMode);
            this.tabPage18.Controls.Add(this.cbLameModeFixed);
            this.tabPage18.Controls.Add(this.cbLameEnableXingVBRTag);
            this.tabPage18.Controls.Add(this.cbLameDisableShortBlocks);
            this.tabPage18.Controls.Add(this.cbLameStrictISOCompilance);
            this.tabPage18.Controls.Add(this.cbLameKeepAllFrequences);
            this.tabPage18.Controls.Add(this.cbLameStrictlyEnforceVBRMinBitrate);
            this.tabPage18.Controls.Add(this.cbLameForceMono);
            this.tabPage18.Controls.Add(this.cbLameCRCProtected);
            this.tabPage18.Controls.Add(this.cbLameOriginal);
            this.tabPage18.Controls.Add(this.cbLameCopyright);
            this.tabPage18.Location = new System.Drawing.Point(4, 22);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage18.Size = new System.Drawing.Size(273, 357);
            this.tabPage18.TabIndex = 1;
            this.tabPage18.Text = "Other";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // cbLameVoiceEncodingMode
            // 
            this.cbLameVoiceEncodingMode.AutoSize = true;
            this.cbLameVoiceEncodingMode.Location = new System.Drawing.Point(26, 177);
            this.cbLameVoiceEncodingMode.Name = "cbLameVoiceEncodingMode";
            this.cbLameVoiceEncodingMode.Size = new System.Drawing.Size(129, 17);
            this.cbLameVoiceEncodingMode.TabIndex = 10;
            this.cbLameVoiceEncodingMode.Text = "Voice encoding mode";
            this.cbLameVoiceEncodingMode.UseVisualStyleBackColor = true;
            // 
            // cbLameModeFixed
            // 
            this.cbLameModeFixed.AutoSize = true;
            this.cbLameModeFixed.Location = new System.Drawing.Point(26, 285);
            this.cbLameModeFixed.Name = "cbLameModeFixed";
            this.cbLameModeFixed.Size = new System.Drawing.Size(88, 17);
            this.cbLameModeFixed.TabIndex = 9;
            this.cbLameModeFixed.Text = "\"Mode fixed\"";
            this.cbLameModeFixed.UseVisualStyleBackColor = true;
            // 
            // cbLameEnableXingVBRTag
            // 
            this.cbLameEnableXingVBRTag.AutoSize = true;
            this.cbLameEnableXingVBRTag.Location = new System.Drawing.Point(26, 258);
            this.cbLameEnableXingVBRTag.Name = "cbLameEnableXingVBRTag";
            this.cbLameEnableXingVBRTag.Size = new System.Drawing.Size(126, 17);
            this.cbLameEnableXingVBRTag.TabIndex = 8;
            this.cbLameEnableXingVBRTag.Text = "Enable Xing VBR tag";
            this.cbLameEnableXingVBRTag.UseVisualStyleBackColor = true;
            // 
            // cbLameDisableShortBlocks
            // 
            this.cbLameDisableShortBlocks.AutoSize = true;
            this.cbLameDisableShortBlocks.Location = new System.Drawing.Point(26, 231);
            this.cbLameDisableShortBlocks.Name = "cbLameDisableShortBlocks";
            this.cbLameDisableShortBlocks.Size = new System.Drawing.Size(121, 17);
            this.cbLameDisableShortBlocks.TabIndex = 7;
            this.cbLameDisableShortBlocks.Text = "Disable short blocks";
            this.cbLameDisableShortBlocks.UseVisualStyleBackColor = true;
            // 
            // cbLameStrictISOCompilance
            // 
            this.cbLameStrictISOCompilance.AutoSize = true;
            this.cbLameStrictISOCompilance.Location = new System.Drawing.Point(26, 204);
            this.cbLameStrictISOCompilance.Name = "cbLameStrictISOCompilance";
            this.cbLameStrictISOCompilance.Size = new System.Drawing.Size(128, 17);
            this.cbLameStrictISOCompilance.TabIndex = 6;
            this.cbLameStrictISOCompilance.Text = "Strict ISO compilance";
            this.cbLameStrictISOCompilance.UseVisualStyleBackColor = true;
            // 
            // cbLameKeepAllFrequences
            // 
            this.cbLameKeepAllFrequences.AutoSize = true;
            this.cbLameKeepAllFrequences.Location = new System.Drawing.Point(26, 150);
            this.cbLameKeepAllFrequences.Name = "cbLameKeepAllFrequences";
            this.cbLameKeepAllFrequences.Size = new System.Drawing.Size(120, 17);
            this.cbLameKeepAllFrequences.TabIndex = 5;
            this.cbLameKeepAllFrequences.Text = "Keep all frequences";
            this.cbLameKeepAllFrequences.UseVisualStyleBackColor = true;
            // 
            // cbLameStrictlyEnforceVBRMinBitrate
            // 
            this.cbLameStrictlyEnforceVBRMinBitrate.AutoSize = true;
            this.cbLameStrictlyEnforceVBRMinBitrate.Location = new System.Drawing.Point(26, 123);
            this.cbLameStrictlyEnforceVBRMinBitrate.Name = "cbLameStrictlyEnforceVBRMinBitrate";
            this.cbLameStrictlyEnforceVBRMinBitrate.Size = new System.Drawing.Size(175, 17);
            this.cbLameStrictlyEnforceVBRMinBitrate.TabIndex = 4;
            this.cbLameStrictlyEnforceVBRMinBitrate.Text = "Strictly enforce VBR min bit rate";
            this.cbLameStrictlyEnforceVBRMinBitrate.UseVisualStyleBackColor = true;
            // 
            // cbLameForceMono
            // 
            this.cbLameForceMono.AutoSize = true;
            this.cbLameForceMono.Location = new System.Drawing.Point(26, 96);
            this.cbLameForceMono.Name = "cbLameForceMono";
            this.cbLameForceMono.Size = new System.Drawing.Size(82, 17);
            this.cbLameForceMono.TabIndex = 3;
            this.cbLameForceMono.Text = "Force mono";
            this.cbLameForceMono.UseVisualStyleBackColor = true;
            // 
            // cbLameCRCProtected
            // 
            this.cbLameCRCProtected.AutoSize = true;
            this.cbLameCRCProtected.Location = new System.Drawing.Point(26, 69);
            this.cbLameCRCProtected.Name = "cbLameCRCProtected";
            this.cbLameCRCProtected.Size = new System.Drawing.Size(96, 17);
            this.cbLameCRCProtected.TabIndex = 2;
            this.cbLameCRCProtected.Text = "CRC protected";
            this.cbLameCRCProtected.UseVisualStyleBackColor = true;
            // 
            // cbLameOriginal
            // 
            this.cbLameOriginal.AutoSize = true;
            this.cbLameOriginal.Location = new System.Drawing.Point(26, 42);
            this.cbLameOriginal.Name = "cbLameOriginal";
            this.cbLameOriginal.Size = new System.Drawing.Size(96, 17);
            this.cbLameOriginal.TabIndex = 1;
            this.cbLameOriginal.Text = "Original / Copy";
            this.cbLameOriginal.UseVisualStyleBackColor = true;
            // 
            // cbLameCopyright
            // 
            this.cbLameCopyright.AutoSize = true;
            this.cbLameCopyright.Location = new System.Drawing.Point(26, 15);
            this.cbLameCopyright.Name = "cbLameCopyright";
            this.cbLameCopyright.Size = new System.Drawing.Size(70, 17);
            this.cbLameCopyright.TabIndex = 0;
            this.cbLameCopyright.Text = "Copyright";
            this.cbLameCopyright.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 402);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 51;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MP3SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(300, 430);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MP3SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MP3 settings";
            this.tabControl4.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLameEncodingQuality)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLameVBRQuality)).EndInit();
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TrackBar tbLameEncodingQuality;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox cbLameSampleRate;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbLameMono;
        private System.Windows.Forms.RadioButton rbLameDualChannels;
        private System.Windows.Forms.RadioButton rbLameJointStereo;
        private System.Windows.Forms.RadioButton rbLameStandardStereo;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TrackBar tbLameVBRQuality;
        private System.Windows.Forms.ComboBox cbLameVBRMax;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.ComboBox cbLameVBRMin;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.ComboBox cbLameCBRBitrate;
        private System.Windows.Forms.RadioButton rbLameVBR;
        private System.Windows.Forms.RadioButton rbLameCBR;
        private System.Windows.Forms.TabPage tabPage18;
        private System.Windows.Forms.CheckBox cbLameVoiceEncodingMode;
        private System.Windows.Forms.CheckBox cbLameModeFixed;
        private System.Windows.Forms.CheckBox cbLameEnableXingVBRTag;
        private System.Windows.Forms.CheckBox cbLameDisableShortBlocks;
        private System.Windows.Forms.CheckBox cbLameStrictISOCompilance;
        private System.Windows.Forms.CheckBox cbLameKeepAllFrequences;
        private System.Windows.Forms.CheckBox cbLameStrictlyEnforceVBRMinBitrate;
        private System.Windows.Forms.CheckBox cbLameForceMono;
        private System.Windows.Forms.CheckBox cbLameCRCProtected;
        private System.Windows.Forms.CheckBox cbLameOriginal;
        private System.Windows.Forms.CheckBox cbLameCopyright;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}