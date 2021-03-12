namespace DVD_Player_Demo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edFilename = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btDVDControlRootMenu = new System.Windows.Forms.Button();
            this.btDVDControlTitleMenu = new System.Windows.Forms.Button();
            this.cbDVDControlSubtitles = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbDVDControlAudio = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbDVDControlChapter = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbDVDControlTitle = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLicensing = new System.Windows.Forms.CheckBox();
            this.mmError = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBalance1 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MediaPlayer1 = new VisioForge.Controls.UI.WinForms.MediaPlayer();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(318, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(405, 23);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(23, 23);
            this.btSelectFile.TabIndex = 18;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edFilename
            // 
            this.edFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFilename.Location = new System.Drawing.Point(12, 25);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(387, 20);
            this.edFilename.TabIndex = 17;
            this.edFilename.Text = "D:\\VIDEO_TS\\VIDEO_TS.IFO";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "DVD IFO file name";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btDVDControlRootMenu);
            this.groupBox3.Controls.Add(this.btDVDControlTitleMenu);
            this.groupBox3.Controls.Add(this.cbDVDControlSubtitles);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cbDVDControlAudio);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbDVDControlChapter);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cbDVDControlTitle);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(12, 462);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 78);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DVD";
            // 
            // btDVDControlRootMenu
            // 
            this.btDVDControlRootMenu.Location = new System.Drawing.Point(335, 48);
            this.btDVDControlRootMenu.Name = "btDVDControlRootMenu";
            this.btDVDControlRootMenu.Size = new System.Drawing.Size(75, 23);
            this.btDVDControlRootMenu.TabIndex = 9;
            this.btDVDControlRootMenu.Text = "Root menu";
            this.btDVDControlRootMenu.UseVisualStyleBackColor = true;
            this.btDVDControlRootMenu.Click += new System.EventHandler(this.btDVDControlRootMenu_Click);
            // 
            // btDVDControlTitleMenu
            // 
            this.btDVDControlTitleMenu.Location = new System.Drawing.Point(335, 21);
            this.btDVDControlTitleMenu.Name = "btDVDControlTitleMenu";
            this.btDVDControlTitleMenu.Size = new System.Drawing.Size(75, 23);
            this.btDVDControlTitleMenu.TabIndex = 8;
            this.btDVDControlTitleMenu.Text = "Title menu";
            this.btDVDControlTitleMenu.UseVisualStyleBackColor = true;
            this.btDVDControlTitleMenu.Click += new System.EventHandler(this.btDVDControlTitleMenu_Click);
            // 
            // cbDVDControlSubtitles
            // 
            this.cbDVDControlSubtitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlSubtitles.FormattingEnabled = true;
            this.cbDVDControlSubtitles.Location = new System.Drawing.Point(217, 50);
            this.cbDVDControlSubtitles.Name = "cbDVDControlSubtitles";
            this.cbDVDControlSubtitles.Size = new System.Drawing.Size(112, 21);
            this.cbDVDControlSubtitles.TabIndex = 7;
            this.cbDVDControlSubtitles.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlSubtitles_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(168, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Subtitles";
            // 
            // cbDVDControlAudio
            // 
            this.cbDVDControlAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlAudio.FormattingEnabled = true;
            this.cbDVDControlAudio.Location = new System.Drawing.Point(217, 23);
            this.cbDVDControlAudio.Name = "cbDVDControlAudio";
            this.cbDVDControlAudio.Size = new System.Drawing.Size(112, 21);
            this.cbDVDControlAudio.TabIndex = 5;
            this.cbDVDControlAudio.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlAudio_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(168, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Audio";
            // 
            // cbDVDControlChapter
            // 
            this.cbDVDControlChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlChapter.FormattingEnabled = true;
            this.cbDVDControlChapter.Location = new System.Drawing.Point(55, 50);
            this.cbDVDControlChapter.Name = "cbDVDControlChapter";
            this.cbDVDControlChapter.Size = new System.Drawing.Size(98, 21);
            this.cbDVDControlChapter.TabIndex = 3;
            this.cbDVDControlChapter.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlChapter_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Chapter";
            // 
            // cbDVDControlTitle
            // 
            this.cbDVDControlTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDControlTitle.FormattingEnabled = true;
            this.cbDVDControlTitle.Location = new System.Drawing.Point(55, 23);
            this.cbDVDControlTitle.Name = "cbDVDControlTitle";
            this.cbDVDControlTitle.Size = new System.Drawing.Size(98, 21);
            this.cbDVDControlTitle.TabIndex = 1;
            this.cbDVDControlTitle.SelectedIndexChanged += new System.EventHandler(this.cbDVDControlTitle_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Title";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbLoop);
            this.groupBox2.Controls.Add(this.btNextFrame);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbTime);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(12, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 90);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(330, 62);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(50, 17);
            this.cbLoop.TabIndex = 9;
            this.cbLoop.Text = "Loop";
            this.cbLoop.UseVisualStyleBackColor = true;
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = new System.Drawing.Point(249, 58);
            this.btNextFrame.Name = "btNextFrame";
            this.btNextFrame.Size = new System.Drawing.Size(75, 23);
            this.btNextFrame.TabIndex = 8;
            this.btNextFrame.Text = "Next frame";
            this.btNextFrame.UseVisualStyleBackColor = true;
            this.btNextFrame.Click += new System.EventHandler(this.btNextFrame_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(180, 58);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(46, 23);
            this.btStop.TabIndex = 7;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(122, 58);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(52, 23);
            this.btPause.TabIndex = 6;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(55, 58);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(61, 23);
            this.btResume.TabIndex = 5;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(6, 58);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(43, 23);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(321, 27);
            this.tbSpeed.Maximum = 25;
            this.tbSpeed.Minimum = 5;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(89, 45);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(322, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Speed";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(219, 27);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(96, 13);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(6, 19);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(207, 45);
            this.tbTimeline.TabIndex = 0;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Much more features shown in Main Demo!";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbLicensing);
            this.groupBox1.Controls.Add(this.mmError);
            this.groupBox1.Controls.Add(this.cbDebugMode);
            this.groupBox1.Location = new System.Drawing.Point(434, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 126);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Errors and warnings";
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(106, 19);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(91, 17);
            this.cbLicensing.TabIndex = 4;
            this.cbLicensing.Text = "Licensing info";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmError
            // 
            this.mmError.Location = new System.Drawing.Point(6, 42);
            this.mmError.Multiline = true;
            this.mmError.Name = "mmError";
            this.mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmError.Size = new System.Drawing.Size(209, 78);
            this.mmError.TabIndex = 3;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(6, 19);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 2;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbBalance1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbVolume1);
            this.groupBox4.Location = new System.Drawing.Point(434, 144);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 107);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio output";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            this.tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance1.Location = new System.Drawing.Point(112, 44);
            this.tbBalance1.Maximum = 100;
            this.tbBalance1.Minimum = -100;
            this.tbBalance1.Name = "tbBalance1";
            this.tbBalance1.Size = new System.Drawing.Size(85, 45);
            this.tbBalance1.TabIndex = 10;
            this.tbBalance1.Scroll += new System.EventHandler(this.tbBalance1_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume1.Location = new System.Drawing.Point(19, 44);
            this.tbVolume1.Maximum = 100;
            this.tbVolume1.Minimum = 20;
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(85, 45);
            this.tbVolume1.TabIndex = 8;
            this.tbVolume1.Value = 80;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MediaPlayer1
            // 
            this.MediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MediaPlayer1.Audio_Channel_Mapper = null;
            this.MediaPlayer1.Audio_Effects_Enabled = false;
            this.MediaPlayer1.Audio_Effects_UseLegacyEffects = false;
            this.MediaPlayer1.Audio_Enhancer_Enabled = false;
            this.MediaPlayer1.Audio_OutputDevice = "";
            this.MediaPlayer1.Audio_PlayAudio = true;
            this.MediaPlayer1.Audio_Sample_Grabber_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Pro_Enabled = false;
            this.MediaPlayer1.Audio_VUMeter_Pro_Volume = 0;
            this.MediaPlayer1.BackColor = System.Drawing.Color.Black;
            this.MediaPlayer1.Barcode_Reader_Enabled = false;
            this.MediaPlayer1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.MediaPlayer1.ChromaKey = null;
            this.MediaPlayer1.Custom_Audio_Decoder = null;
            this.MediaPlayer1.Custom_Splitter = null;
            this.MediaPlayer1.Custom_Video_Decoder = null;
            this.MediaPlayer1.Debug_DeepCleanUp = false;
            this.MediaPlayer1.Debug_Dir = null;
            this.MediaPlayer1.Debug_Mode = false;
            this.MediaPlayer1.Encryption_Key = "";
            this.MediaPlayer1.Encryption_KeyType = VisioForge.Types.VFEncryptionKeyType.String;
            this.MediaPlayer1.Face_Tracking = null;
            this.MediaPlayer1.Info_UseLibMediaInfo = false;
            this.MediaPlayer1.Location = new System.Drawing.Point(12, 54);
            this.MediaPlayer1.Loop = false;
            this.MediaPlayer1.Loop_DoNotSeekToBeginning = false;
            this.MediaPlayer1.MaximalSpeedPlayback = false;
            this.MediaPlayer1.Motion_Detection = null;
            this.MediaPlayer1.Motion_DetectionEx = null;
            this.MediaPlayer1.MultiScreen_Enabled = false;
            this.MediaPlayer1.Name = "MediaPlayer1";
            this.MediaPlayer1.ReversePlayback_CacheSize = 0;
            this.MediaPlayer1.ReversePlayback_Enabled = false;
            this.MediaPlayer1.Selection_Active = false;
            this.MediaPlayer1.Selection_Start = 0;
            this.MediaPlayer1.Selection_Stop = 0;
            this.MediaPlayer1.Size = new System.Drawing.Size(415, 302);
            this.MediaPlayer1.Source_Custom_CLSID = null;
            this.MediaPlayer1.Source_Mode = VisioForge.Types.VFMediaPlayerSource.File_DS;
            this.MediaPlayer1.Source_Stream = null;
            this.MediaPlayer1.Source_Stream_AudioPresent = true;
            this.MediaPlayer1.Source_Stream_Size = ((long)(0));
            this.MediaPlayer1.Source_Stream_VideoPresent = true;
            this.MediaPlayer1.Play_DelayEnabled = false;
            this.MediaPlayer1.TabIndex = 25;
            this.MediaPlayer1.Video_Effects_Enabled = false;
            this.MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.MediaPlayer1.Video_Stream_Index = 0;
            this.MediaPlayer1.OnDVDPlaybackError += new System.EventHandler<VisioForge.Types.DVDEventArgs>(this.MediaPlayer1_OnDVDPlaybackError);
            this.MediaPlayer1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.MediaPlayer1_OnError);
            this.MediaPlayer1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.MediaPlayer1_OnLicenseRequired);
            this.MediaPlayer1.OnStop += new System.EventHandler<VisioForge.Types.MediaPlayerStopEventArgs>(this.MediaPlayer1_OnStop);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 578);
            this.Controls.Add(this.MediaPlayer1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilename);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net - DVD Player Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btDVDControlRootMenu;
        private System.Windows.Forms.Button btDVDControlTitleMenu;
        private System.Windows.Forms.ComboBox cbDVDControlSubtitles;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbDVDControlAudio;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbDVDControlChapter;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbDVDControlTitle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbBalance1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private VisioForge.Controls.UI.WinForms.MediaPlayer MediaPlayer1;
        private System.Windows.Forms.CheckBox cbLicensing;
    }
}

