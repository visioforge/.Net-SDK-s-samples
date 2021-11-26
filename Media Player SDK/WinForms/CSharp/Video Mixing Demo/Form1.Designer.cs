namespace Video_Mixing_Demo
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

            MediaPlayer1?.Dispose();
            MediaPlayer1 = null;

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
            this.btAddFileToPlaylist = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.lbSourceFiles = new System.Windows.Forms.ListBox();
            this.cbSourceMode = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.cbLicensing = new System.Windows.Forms.CheckBox();
            this.btTest = new System.Windows.Forms.Button();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabControl13 = new System.Windows.Forms.TabControl();
            this.tabPage54 = new System.Windows.Forms.TabPage();
            this.cbImageType = new System.Windows.Forms.ComboBox();
            this.lbJPEGQuality = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.btSaveScreenshot = new System.Windows.Forms.Button();
            this.btSelectScreenshotsFolder = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.edScreenshotsFolder = new System.Windows.Forms.TextBox();
            this.tbJPEGQuality = new System.Windows.Forms.TrackBar();
            this.tabPage55 = new System.Windows.Forms.TabPage();
            this.edScreenshotHeight = new System.Windows.Forms.TextBox();
            this.label176 = new System.Windows.Forms.Label();
            this.edScreenshotWidth = new System.Windows.Forms.TextBox();
            this.label177 = new System.Windows.Forms.Label();
            this.cbScreenshotResize = new System.Windows.Forms.CheckBox();
            this.tabPage25 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edFilenameOrURL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.edPIPFileHeight = new System.Windows.Forms.TextBox();
            this.label321 = new System.Windows.Forms.Label();
            this.edPIPFileWidth = new System.Windows.Forms.TextBox();
            this.label322 = new System.Windows.Forms.Label();
            this.edPIPFileTop = new System.Windows.Forms.TextBox();
            this.label323 = new System.Windows.Forms.Label();
            this.edPIPFileLeft = new System.Windows.Forms.TextBox();
            this.label324 = new System.Windows.Forms.Label();
            this.btUpdateRect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edZOrder = new System.Windows.Forms.TextBox();
            this.tbStreamTransparency = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStreamTransparency = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.tabControl3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabControl13.SuspendLayout();
            this.tabPage54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).BeginInit();
            this.tabPage55.SuspendLayout();
            this.tabPage25.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.groupBox44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStreamTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(634, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btAddFileToPlaylist
            // 
            this.btAddFileToPlaylist.Location = new System.Drawing.Point(680, 28);
            this.btAddFileToPlaylist.Margin = new System.Windows.Forms.Padding(2);
            this.btAddFileToPlaylist.Name = "btAddFileToPlaylist";
            this.btAddFileToPlaylist.Size = new System.Drawing.Size(38, 22);
            this.btAddFileToPlaylist.TabIndex = 30;
            this.btAddFileToPlaylist.Text = "Add";
            this.btAddFileToPlaylist.UseVisualStyleBackColor = true;
            this.btAddFileToPlaylist.Click += new System.EventHandler(this.btAddFileToPlaylist_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(326, 50);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 29;
            this.label30.Text = "Playlist";
            // 
            // lbSourceFiles
            // 
            this.lbSourceFiles.FormattingEnabled = true;
            this.lbSourceFiles.Location = new System.Drawing.Point(328, 66);
            this.lbSourceFiles.Margin = new System.Windows.Forms.Padding(2);
            this.lbSourceFiles.Name = "lbSourceFiles";
            this.lbSourceFiles.Size = new System.Drawing.Size(416, 56);
            this.lbSourceFiles.TabIndex = 28;
            this.lbSourceFiles.SelectedIndexChanged += new System.EventHandler(this.lbSourceFiles_SelectedIndexChanged);
            // 
            // cbSourceMode
            // 
            this.cbSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceMode.FormattingEnabled = true;
            this.cbSourceMode.Items.AddRange(new object[] {
            "File / Network stream (decode using LAV) ",
            "File (decode using FFMPEG)",
            "File (decode using DirectShow)",
            "File (decode using VLC)"});
            this.cbSourceMode.Location = new System.Drawing.Point(430, 126);
            this.cbSourceMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbSourceMode.Name = "cbSourceMode";
            this.cbSourceMode.Size = new System.Drawing.Size(314, 21);
            this.cbSourceMode.TabIndex = 27;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(325, 129);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 13);
            this.label29.TabIndex = 26;
            this.label29.Text = "Source mode";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage25);
            this.tabControl3.Location = new System.Drawing.Point(10, 479);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(309, 146);
            this.tabControl3.TabIndex = 25;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.cbLicensing);
            this.tabPage10.Controls.Add(this.btTest);
            this.tabPage10.Controls.Add(this.mmLog);
            this.tabPage10.Controls.Add(this.cbDebugMode);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(301, 120);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Debug";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(109, 13);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(91, 17);
            this.cbLicensing.TabIndex = 3;
            this.cbLicensing.Text = "Licensing info";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(205, 9);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 21);
            this.btTest.TabIndex = 2;
            this.btTest.Text = "Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(16, 36);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(264, 78);
            this.mmLog.TabIndex = 1;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(16, 13);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 0;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.tabControl13);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(301, 120);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Snapshot";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabControl13
            // 
            this.tabControl13.Controls.Add(this.tabPage54);
            this.tabControl13.Controls.Add(this.tabPage55);
            this.tabControl13.Location = new System.Drawing.Point(3, 3);
            this.tabControl13.Name = "tabControl13";
            this.tabControl13.SelectedIndex = 0;
            this.tabControl13.Size = new System.Drawing.Size(293, 111);
            this.tabControl13.TabIndex = 27;
            // 
            // tabPage54
            // 
            this.tabPage54.Controls.Add(this.cbImageType);
            this.tabPage54.Controls.Add(this.lbJPEGQuality);
            this.tabPage54.Controls.Add(this.label38);
            this.tabPage54.Controls.Add(this.btSaveScreenshot);
            this.tabPage54.Controls.Add(this.btSelectScreenshotsFolder);
            this.tabPage54.Controls.Add(this.label63);
            this.tabPage54.Controls.Add(this.edScreenshotsFolder);
            this.tabPage54.Controls.Add(this.tbJPEGQuality);
            this.tabPage54.Location = new System.Drawing.Point(4, 22);
            this.tabPage54.Name = "tabPage54";
            this.tabPage54.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage54.Size = new System.Drawing.Size(285, 85);
            this.tabPage54.TabIndex = 0;
            this.tabPage54.Text = "Main";
            this.tabPage54.UseVisualStyleBackColor = true;
            // 
            // cbImageType
            // 
            this.cbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageType.FormattingEnabled = true;
            this.cbImageType.Items.AddRange(new object[] {
            "BMP",
            "JPEG",
            "GIF",
            "PNG",
            "TIFF"});
            this.cbImageType.Location = new System.Drawing.Point(11, 59);
            this.cbImageType.Name = "cbImageType";
            this.cbImageType.Size = new System.Drawing.Size(73, 21);
            this.cbImageType.TabIndex = 33;
            // 
            // lbJPEGQuality
            // 
            this.lbJPEGQuality.AutoSize = true;
            this.lbJPEGQuality.Location = new System.Drawing.Point(261, 62);
            this.lbJPEGQuality.Name = "lbJPEGQuality";
            this.lbJPEGQuality.Size = new System.Drawing.Size(19, 13);
            this.lbJPEGQuality.TabIndex = 32;
            this.lbJPEGQuality.Text = "85";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(119, 62);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(67, 13);
            this.label38.TabIndex = 31;
            this.label38.Text = "JPEG quality";
            // 
            // btSaveScreenshot
            // 
            this.btSaveScreenshot.Location = new System.Drawing.Point(227, 14);
            this.btSaveScreenshot.Name = "btSaveScreenshot";
            this.btSaveScreenshot.Size = new System.Drawing.Size(56, 23);
            this.btSaveScreenshot.TabIndex = 29;
            this.btSaveScreenshot.Text = "Save";
            this.btSaveScreenshot.UseVisualStyleBackColor = true;
            // 
            // btSelectScreenshotsFolder
            // 
            this.btSelectScreenshotsFolder.Location = new System.Drawing.Point(198, 14);
            this.btSelectScreenshotsFolder.Name = "btSelectScreenshotsFolder";
            this.btSelectScreenshotsFolder.Size = new System.Drawing.Size(23, 23);
            this.btSelectScreenshotsFolder.TabIndex = 28;
            this.btSelectScreenshotsFolder.Text = "...";
            this.btSelectScreenshotsFolder.UseVisualStyleBackColor = true;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(8, 19);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(36, 13);
            this.label63.TabIndex = 27;
            this.label63.Text = "Folder";
            // 
            // edScreenshotsFolder
            // 
            this.edScreenshotsFolder.Location = new System.Drawing.Point(53, 16);
            this.edScreenshotsFolder.Name = "edScreenshotsFolder";
            this.edScreenshotsFolder.Size = new System.Drawing.Size(139, 20);
            this.edScreenshotsFolder.TabIndex = 26;
            this.edScreenshotsFolder.Text = "c:\\";
            // 
            // tbJPEGQuality
            // 
            this.tbJPEGQuality.BackColor = System.Drawing.SystemColors.Window;
            this.tbJPEGQuality.Location = new System.Drawing.Point(192, 48);
            this.tbJPEGQuality.Maximum = 100;
            this.tbJPEGQuality.Name = "tbJPEGQuality";
            this.tbJPEGQuality.Size = new System.Drawing.Size(64, 45);
            this.tbJPEGQuality.TabIndex = 30;
            this.tbJPEGQuality.TickFrequency = 5;
            this.tbJPEGQuality.Value = 85;
            // 
            // tabPage55
            // 
            this.tabPage55.Controls.Add(this.edScreenshotHeight);
            this.tabPage55.Controls.Add(this.label176);
            this.tabPage55.Controls.Add(this.edScreenshotWidth);
            this.tabPage55.Controls.Add(this.label177);
            this.tabPage55.Controls.Add(this.cbScreenshotResize);
            this.tabPage55.Location = new System.Drawing.Point(4, 22);
            this.tabPage55.Name = "tabPage55";
            this.tabPage55.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage55.Size = new System.Drawing.Size(285, 85);
            this.tabPage55.TabIndex = 1;
            this.tabPage55.Text = "Resize";
            this.tabPage55.UseVisualStyleBackColor = true;
            // 
            // edScreenshotHeight
            // 
            this.edScreenshotHeight.Location = new System.Drawing.Point(163, 44);
            this.edScreenshotHeight.Name = "edScreenshotHeight";
            this.edScreenshotHeight.Size = new System.Drawing.Size(36, 20);
            this.edScreenshotHeight.TabIndex = 128;
            this.edScreenshotHeight.Text = "576";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(116, 47);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(38, 13);
            this.label176.TabIndex = 127;
            this.label176.Text = "Height";
            // 
            // edScreenshotWidth
            // 
            this.edScreenshotWidth.Location = new System.Drawing.Point(74, 44);
            this.edScreenshotWidth.Name = "edScreenshotWidth";
            this.edScreenshotWidth.Size = new System.Drawing.Size(36, 20);
            this.edScreenshotWidth.TabIndex = 126;
            this.edScreenshotWidth.Text = "768";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(32, 47);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(35, 13);
            this.label177.TabIndex = 125;
            this.label177.Text = "Width";
            // 
            // cbScreenshotResize
            // 
            this.cbScreenshotResize.AutoSize = true;
            this.cbScreenshotResize.Location = new System.Drawing.Point(16, 18);
            this.cbScreenshotResize.Name = "cbScreenshotResize";
            this.cbScreenshotResize.Size = new System.Drawing.Size(65, 17);
            this.cbScreenshotResize.TabIndex = 0;
            this.cbScreenshotResize.Text = "Enabled";
            this.cbScreenshotResize.UseVisualStyleBackColor = true;
            // 
            // tabPage25
            // 
            this.tabPage25.Controls.Add(this.linkLabel2);
            this.tabPage25.Location = new System.Drawing.Point(4, 22);
            this.tabPage25.Name = "tabPage25";
            this.tabPage25.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage25.Size = new System.Drawing.Size(301, 120);
            this.tabPage25.TabIndex = 3;
            this.tabPage25.Text = "VLC engine";
            this.tabPage25.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(20, 17);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(264, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Please install VisioForge VLC redist to use VLC engine ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPause);
            this.groupBox2.Controls.Add(this.btResume);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbTime);
            this.groupBox2.Controls.Add(this.tbTimeline);
            this.groupBox2.Location = new System.Drawing.Point(328, 479);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 90);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
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
            // btSelectFile
            // 
            this.btSelectFile.Location = new System.Drawing.Point(721, 27);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(23, 23);
            this.btSelectFile.TabIndex = 23;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edFilenameOrURL
            // 
            this.edFilenameOrURL.Location = new System.Drawing.Point(328, 29);
            this.edFilenameOrURL.Name = "edFilenameOrURL";
            this.edFilenameOrURL.Size = new System.Drawing.Size(348, 20);
            this.edFilenameOrURL.TabIndex = 22;
            this.edFilenameOrURL.Text = "c:\\Samples\\!video.avi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(325, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "File name or URL";
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.edPIPFileHeight);
            this.groupBox44.Controls.Add(this.label321);
            this.groupBox44.Controls.Add(this.edPIPFileWidth);
            this.groupBox44.Controls.Add(this.label322);
            this.groupBox44.Controls.Add(this.edPIPFileTop);
            this.groupBox44.Controls.Add(this.label323);
            this.groupBox44.Controls.Add(this.edPIPFileLeft);
            this.groupBox44.Controls.Add(this.label324);
            this.groupBox44.Location = new System.Drawing.Point(14, 13);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(204, 78);
            this.groupBox44.TabIndex = 65;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Position";
            // 
            // edPIPFileHeight
            // 
            this.edPIPFileHeight.Location = new System.Drawing.Point(150, 45);
            this.edPIPFileHeight.Name = "edPIPFileHeight";
            this.edPIPFileHeight.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileHeight.TabIndex = 40;
            this.edPIPFileHeight.Text = "200";
            this.edPIPFileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label321
            // 
            this.label321.AutoSize = true;
            this.label321.Location = new System.Drawing.Point(112, 48);
            this.label321.Name = "label321";
            this.label321.Size = new System.Drawing.Size(38, 13);
            this.label321.TabIndex = 39;
            this.label321.Text = "Height";
            // 
            // edPIPFileWidth
            // 
            this.edPIPFileWidth.Location = new System.Drawing.Point(150, 19);
            this.edPIPFileWidth.Name = "edPIPFileWidth";
            this.edPIPFileWidth.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileWidth.TabIndex = 38;
            this.edPIPFileWidth.Text = "300";
            this.edPIPFileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label322
            // 
            this.label322.AutoSize = true;
            this.label322.Location = new System.Drawing.Point(112, 22);
            this.label322.Name = "label322";
            this.label322.Size = new System.Drawing.Size(35, 13);
            this.label322.TabIndex = 37;
            this.label322.Text = "Width";
            // 
            // edPIPFileTop
            // 
            this.edPIPFileTop.Location = new System.Drawing.Point(48, 45);
            this.edPIPFileTop.Name = "edPIPFileTop";
            this.edPIPFileTop.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileTop.TabIndex = 36;
            this.edPIPFileTop.Text = "0";
            this.edPIPFileTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label323
            // 
            this.label323.AutoSize = true;
            this.label323.Location = new System.Drawing.Point(15, 48);
            this.label323.Name = "label323";
            this.label323.Size = new System.Drawing.Size(26, 13);
            this.label323.TabIndex = 35;
            this.label323.Text = "Top";
            // 
            // edPIPFileLeft
            // 
            this.edPIPFileLeft.Location = new System.Drawing.Point(48, 19);
            this.edPIPFileLeft.Name = "edPIPFileLeft";
            this.edPIPFileLeft.Size = new System.Drawing.Size(39, 20);
            this.edPIPFileLeft.TabIndex = 34;
            this.edPIPFileLeft.Text = "0";
            this.edPIPFileLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label324
            // 
            this.label324.AutoSize = true;
            this.label324.Location = new System.Drawing.Point(15, 22);
            this.label324.Name = "label324";
            this.label324.Size = new System.Drawing.Size(25, 13);
            this.label324.TabIndex = 33;
            this.label324.Text = "Left";
            // 
            // btUpdateRect
            // 
            this.btUpdateRect.Location = new System.Drawing.Point(129, 209);
            this.btUpdateRect.Name = "btUpdateRect";
            this.btUpdateRect.Size = new System.Drawing.Size(75, 23);
            this.btUpdateRect.TabIndex = 66;
            this.btUpdateRect.Text = "Update";
            this.btUpdateRect.UseVisualStyleBackColor = true;
            this.btUpdateRect.Click += new System.EventHandler(this.btUpdateRect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "If all values are 0 - entire screen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Z-order";
            // 
            // edZOrder
            // 
            this.edZOrder.Location = new System.Drawing.Point(246, 58);
            this.edZOrder.Name = "edZOrder";
            this.edZOrder.Size = new System.Drawing.Size(39, 20);
            this.edZOrder.TabIndex = 69;
            this.edZOrder.Text = "0";
            this.edZOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbStreamTransparency
            // 
            this.tbStreamTransparency.Location = new System.Drawing.Point(17, 148);
            this.tbStreamTransparency.Maximum = 100;
            this.tbStreamTransparency.Name = "tbStreamTransparency";
            this.tbStreamTransparency.Size = new System.Drawing.Size(201, 45);
            this.tbStreamTransparency.TabIndex = 70;
            this.tbStreamTransparency.Value = 100;
            this.tbStreamTransparency.Scroll += new System.EventHandler(this.tbStreamTransparency_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Stream transparency";
            // 
            // lbStreamTransparency
            // 
            this.lbStreamTransparency.AutoSize = true;
            this.lbStreamTransparency.Location = new System.Drawing.Point(183, 132);
            this.lbStreamTransparency.Name = "lbStreamTransparency";
            this.lbStreamTransparency.Size = new System.Drawing.Size(25, 13);
            this.lbStreamTransparency.TabIndex = 72;
            this.lbStreamTransparency.Text = "100";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 73;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Transparent;
            this.textBox1.Location = new System.Drawing.Point(14, 242);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(305, 113);
            this.textBox1.TabIndex = 74;
            this.textBox1.Text = "First file will cover entire screen by default. You can set position for each str" +
    "eam independently.";
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(328, 163);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(416, 310);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 75;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 637);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbStreamTransparency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStreamTransparency);
            this.Controls.Add(this.edZOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btUpdateRect);
            this.Controls.Add(this.groupBox44);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btAddFileToPlaylist);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lbSourceFiles);
            this.Controls.Add(this.cbSourceMode);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilenameOrURL);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net - Video Mixing Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl3.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabControl13.ResumeLayout(false);
            this.tabPage54.ResumeLayout(false);
            this.tabPage54.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbJPEGQuality)).EndInit();
            this.tabPage55.ResumeLayout(false);
            this.tabPage55.PerformLayout();
            this.tabPage25.ResumeLayout(false);
            this.tabPage25.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStreamTransparency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btAddFileToPlaylist;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ListBox lbSourceFiles;
        private System.Windows.Forms.ComboBox cbSourceMode;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabControl tabControl13;
        private System.Windows.Forms.TabPage tabPage54;
        private System.Windows.Forms.ComboBox cbImageType;
        private System.Windows.Forms.Label lbJPEGQuality;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btSaveScreenshot;
        private System.Windows.Forms.Button btSelectScreenshotsFolder;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox edScreenshotsFolder;
        private System.Windows.Forms.TrackBar tbJPEGQuality;
        private System.Windows.Forms.TabPage tabPage55;
        private System.Windows.Forms.TextBox edScreenshotHeight;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.TextBox edScreenshotWidth;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.CheckBox cbScreenshotResize;
        private System.Windows.Forms.TabPage tabPage25;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilenameOrURL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox44;
        private System.Windows.Forms.TextBox edPIPFileHeight;
        private System.Windows.Forms.Label label321;
        private System.Windows.Forms.TextBox edPIPFileWidth;
        private System.Windows.Forms.Label label322;
        private System.Windows.Forms.TextBox edPIPFileTop;
        private System.Windows.Forms.Label label323;
        private System.Windows.Forms.TextBox edPIPFileLeft;
        private System.Windows.Forms.Label label324;
        private System.Windows.Forms.Button btUpdateRect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edZOrder;
        private System.Windows.Forms.TrackBar tbStreamTransparency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStreamTransparency;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

