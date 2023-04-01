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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btAddFileToPlaylist = new System.Windows.Forms.Button();
            label30 = new System.Windows.Forms.Label();
            lbSourceFiles = new System.Windows.Forms.ListBox();
            cbSourceMode = new System.Windows.Forms.ComboBox();
            label29 = new System.Windows.Forms.Label();
            tabControl3 = new System.Windows.Forms.TabControl();
            tabPage10 = new System.Windows.Forms.TabPage();
            cbLicensing = new System.Windows.Forms.CheckBox();
            btTest = new System.Windows.Forms.Button();
            mmLog = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            tabPage9 = new System.Windows.Forms.TabPage();
            tabControl13 = new System.Windows.Forms.TabControl();
            tabPage54 = new System.Windows.Forms.TabPage();
            cbImageType = new System.Windows.Forms.ComboBox();
            lbJPEGQuality = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            btSaveScreenshot = new System.Windows.Forms.Button();
            btSelectScreenshotsFolder = new System.Windows.Forms.Button();
            label63 = new System.Windows.Forms.Label();
            edScreenshotsFolder = new System.Windows.Forms.TextBox();
            tbJPEGQuality = new System.Windows.Forms.TrackBar();
            tabPage55 = new System.Windows.Forms.TabPage();
            edScreenshotHeight = new System.Windows.Forms.TextBox();
            label176 = new System.Windows.Forms.Label();
            edScreenshotWidth = new System.Windows.Forms.TextBox();
            label177 = new System.Windows.Forms.Label();
            cbScreenshotResize = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tbSpeed = new System.Windows.Forms.TrackBar();
            label16 = new System.Windows.Forms.Label();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            btSelectFile = new System.Windows.Forms.Button();
            edFilenameOrURL = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            groupBox44 = new System.Windows.Forms.GroupBox();
            edPIPFileHeight = new System.Windows.Forms.TextBox();
            label321 = new System.Windows.Forms.Label();
            edPIPFileWidth = new System.Windows.Forms.TextBox();
            label322 = new System.Windows.Forms.Label();
            edPIPFileTop = new System.Windows.Forms.TextBox();
            label323 = new System.Windows.Forms.Label();
            edPIPFileLeft = new System.Windows.Forms.TextBox();
            label324 = new System.Windows.Forms.Label();
            btUpdateRect = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            edZOrder = new System.Windows.Forms.TextBox();
            tbStreamTransparency = new System.Windows.Forms.TrackBar();
            label3 = new System.Windows.Forms.Label();
            lbStreamTransparency = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            tabControl3.SuspendLayout();
            tabPage10.SuspendLayout();
            tabPage9.SuspendLayout();
            tabControl13.SuspendLayout();
            tabPage54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbJPEGQuality).BeginInit();
            tabPage55.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            groupBox44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbStreamTransparency).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(1057, 19);
            linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(184, 25);
            linkLabel1.TabIndex = 31;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btAddFileToPlaylist
            // 
            btAddFileToPlaylist.Location = new System.Drawing.Point(1133, 54);
            btAddFileToPlaylist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btAddFileToPlaylist.Name = "btAddFileToPlaylist";
            btAddFileToPlaylist.Size = new System.Drawing.Size(63, 42);
            btAddFileToPlaylist.TabIndex = 30;
            btAddFileToPlaylist.Text = "Add";
            btAddFileToPlaylist.UseVisualStyleBackColor = true;
            btAddFileToPlaylist.Click += btAddFileToPlaylist_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(543, 96);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(66, 25);
            label30.TabIndex = 29;
            label30.Text = "Playlist";
            // 
            // lbSourceFiles
            // 
            lbSourceFiles.FormattingEnabled = true;
            lbSourceFiles.ItemHeight = 25;
            lbSourceFiles.Location = new System.Drawing.Point(547, 127);
            lbSourceFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lbSourceFiles.Name = "lbSourceFiles";
            lbSourceFiles.Size = new System.Drawing.Size(691, 104);
            lbSourceFiles.TabIndex = 28;
            lbSourceFiles.SelectedIndexChanged += lbSourceFiles_SelectedIndexChanged;
            // 
            // cbSourceMode
            // 
            cbSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSourceMode.FormattingEnabled = true;
            cbSourceMode.Items.AddRange(new object[] { "File / Network stream (decode using LAV) ", "File (decode using FFMPEG)", "File (decode using DirectShow)", "File (decode using VLC)" });
            cbSourceMode.Location = new System.Drawing.Point(717, 242);
            cbSourceMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbSourceMode.Name = "cbSourceMode";
            cbSourceMode.Size = new System.Drawing.Size(521, 33);
            cbSourceMode.TabIndex = 27;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(542, 248);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(118, 25);
            label29.TabIndex = 26;
            label29.Text = "Source mode";
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage10);
            tabControl3.Controls.Add(tabPage9);
            tabControl3.Location = new System.Drawing.Point(17, 921);
            tabControl3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new System.Drawing.Size(515, 281);
            tabControl3.TabIndex = 25;
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(cbLicensing);
            tabPage10.Controls.Add(btTest);
            tabPage10.Controls.Add(mmLog);
            tabPage10.Controls.Add(cbDebugMode);
            tabPage10.Location = new System.Drawing.Point(4, 34);
            tabPage10.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage10.Size = new System.Drawing.Size(507, 243);
            tabPage10.TabIndex = 2;
            tabPage10.Text = "Debug";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(182, 25);
            cbLicensing.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(146, 29);
            cbLicensing.TabIndex = 3;
            cbLicensing.Text = "Licensing info";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // btTest
            // 
            btTest.Location = new System.Drawing.Point(342, 17);
            btTest.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btTest.Name = "btTest";
            btTest.Size = new System.Drawing.Size(125, 40);
            btTest.TabIndex = 2;
            btTest.Text = "Test";
            btTest.UseVisualStyleBackColor = true;
            btTest.Click += btTest_Click;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(27, 69);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmLog.Size = new System.Drawing.Size(437, 146);
            mmLog.TabIndex = 1;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(27, 25);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 0;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(tabControl13);
            tabPage9.Location = new System.Drawing.Point(4, 34);
            tabPage9.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage9.Size = new System.Drawing.Size(507, 243);
            tabPage9.TabIndex = 1;
            tabPage9.Text = "Snapshot";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabControl13
            // 
            tabControl13.Controls.Add(tabPage54);
            tabControl13.Controls.Add(tabPage55);
            tabControl13.Location = new System.Drawing.Point(5, 6);
            tabControl13.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabControl13.Name = "tabControl13";
            tabControl13.SelectedIndex = 0;
            tabControl13.Size = new System.Drawing.Size(488, 213);
            tabControl13.TabIndex = 27;
            // 
            // tabPage54
            // 
            tabPage54.Controls.Add(cbImageType);
            tabPage54.Controls.Add(lbJPEGQuality);
            tabPage54.Controls.Add(label38);
            tabPage54.Controls.Add(btSaveScreenshot);
            tabPage54.Controls.Add(btSelectScreenshotsFolder);
            tabPage54.Controls.Add(label63);
            tabPage54.Controls.Add(edScreenshotsFolder);
            tabPage54.Controls.Add(tbJPEGQuality);
            tabPage54.Location = new System.Drawing.Point(4, 34);
            tabPage54.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage54.Name = "tabPage54";
            tabPage54.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage54.Size = new System.Drawing.Size(480, 175);
            tabPage54.TabIndex = 0;
            tabPage54.Text = "Main";
            tabPage54.UseVisualStyleBackColor = true;
            // 
            // cbImageType
            // 
            cbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbImageType.FormattingEnabled = true;
            cbImageType.Items.AddRange(new object[] { "BMP", "JPEG", "GIF", "PNG", "TIFF" });
            cbImageType.Location = new System.Drawing.Point(18, 113);
            cbImageType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbImageType.Name = "cbImageType";
            cbImageType.Size = new System.Drawing.Size(119, 33);
            cbImageType.TabIndex = 33;
            // 
            // lbJPEGQuality
            // 
            lbJPEGQuality.AutoSize = true;
            lbJPEGQuality.Location = new System.Drawing.Point(435, 119);
            lbJPEGQuality.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbJPEGQuality.Name = "lbJPEGQuality";
            lbJPEGQuality.Size = new System.Drawing.Size(32, 25);
            lbJPEGQuality.TabIndex = 32;
            lbJPEGQuality.Text = "85";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new System.Drawing.Point(198, 119);
            label38.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(107, 25);
            label38.TabIndex = 31;
            label38.Text = "JPEG quality";
            // 
            // btSaveScreenshot
            // 
            btSaveScreenshot.Location = new System.Drawing.Point(378, 27);
            btSaveScreenshot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSaveScreenshot.Name = "btSaveScreenshot";
            btSaveScreenshot.Size = new System.Drawing.Size(93, 44);
            btSaveScreenshot.TabIndex = 29;
            btSaveScreenshot.Text = "Save";
            btSaveScreenshot.UseVisualStyleBackColor = true;
            // 
            // btSelectScreenshotsFolder
            // 
            btSelectScreenshotsFolder.Location = new System.Drawing.Point(330, 27);
            btSelectScreenshotsFolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectScreenshotsFolder.Name = "btSelectScreenshotsFolder";
            btSelectScreenshotsFolder.Size = new System.Drawing.Size(38, 44);
            btSelectScreenshotsFolder.TabIndex = 28;
            btSelectScreenshotsFolder.Text = "...";
            btSelectScreenshotsFolder.UseVisualStyleBackColor = true;
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Location = new System.Drawing.Point(13, 37);
            label63.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label63.Name = "label63";
            label63.Size = new System.Drawing.Size(62, 25);
            label63.TabIndex = 27;
            label63.Text = "Folder";
            // 
            // edScreenshotsFolder
            // 
            edScreenshotsFolder.Location = new System.Drawing.Point(88, 31);
            edScreenshotsFolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenshotsFolder.Name = "edScreenshotsFolder";
            edScreenshotsFolder.Size = new System.Drawing.Size(229, 31);
            edScreenshotsFolder.TabIndex = 26;
            edScreenshotsFolder.Text = "c:\\";
            // 
            // tbJPEGQuality
            // 
            tbJPEGQuality.BackColor = System.Drawing.SystemColors.Window;
            tbJPEGQuality.Location = new System.Drawing.Point(320, 92);
            tbJPEGQuality.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbJPEGQuality.Maximum = 100;
            tbJPEGQuality.Name = "tbJPEGQuality";
            tbJPEGQuality.Size = new System.Drawing.Size(107, 69);
            tbJPEGQuality.TabIndex = 30;
            tbJPEGQuality.TickFrequency = 5;
            tbJPEGQuality.Value = 85;
            // 
            // tabPage55
            // 
            tabPage55.Controls.Add(edScreenshotHeight);
            tabPage55.Controls.Add(label176);
            tabPage55.Controls.Add(edScreenshotWidth);
            tabPage55.Controls.Add(label177);
            tabPage55.Controls.Add(cbScreenshotResize);
            tabPage55.Location = new System.Drawing.Point(4, 34);
            tabPage55.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage55.Name = "tabPage55";
            tabPage55.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage55.Size = new System.Drawing.Size(480, 175);
            tabPage55.TabIndex = 1;
            tabPage55.Text = "Resize";
            tabPage55.UseVisualStyleBackColor = true;
            // 
            // edScreenshotHeight
            // 
            edScreenshotHeight.Location = new System.Drawing.Point(272, 85);
            edScreenshotHeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenshotHeight.Name = "edScreenshotHeight";
            edScreenshotHeight.Size = new System.Drawing.Size(57, 31);
            edScreenshotHeight.TabIndex = 128;
            edScreenshotHeight.Text = "576";
            // 
            // label176
            // 
            label176.AutoSize = true;
            label176.Location = new System.Drawing.Point(193, 90);
            label176.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label176.Name = "label176";
            label176.Size = new System.Drawing.Size(65, 25);
            label176.TabIndex = 127;
            label176.Text = "Height";
            // 
            // edScreenshotWidth
            // 
            edScreenshotWidth.Location = new System.Drawing.Point(123, 85);
            edScreenshotWidth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edScreenshotWidth.Name = "edScreenshotWidth";
            edScreenshotWidth.Size = new System.Drawing.Size(57, 31);
            edScreenshotWidth.TabIndex = 126;
            edScreenshotWidth.Text = "768";
            // 
            // label177
            // 
            label177.AutoSize = true;
            label177.Location = new System.Drawing.Point(53, 90);
            label177.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label177.Name = "label177";
            label177.Size = new System.Drawing.Size(60, 25);
            label177.TabIndex = 125;
            label177.Text = "Width";
            // 
            // cbScreenshotResize
            // 
            cbScreenshotResize.AutoSize = true;
            cbScreenshotResize.Location = new System.Drawing.Point(27, 35);
            cbScreenshotResize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbScreenshotResize.Name = "cbScreenshotResize";
            cbScreenshotResize.Size = new System.Drawing.Size(101, 29);
            cbScreenshotResize.TabIndex = 0;
            cbScreenshotResize.Text = "Enabled";
            cbScreenshotResize.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(tbSpeed);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(lbTime);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(547, 921);
            groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Size = new System.Drawing.Size(690, 173);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(300, 112);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(77, 44);
            btStop.TabIndex = 7;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(203, 112);
            btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(87, 44);
            btPause.TabIndex = 6;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(92, 112);
            btResume.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(102, 44);
            btResume.TabIndex = 5;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(10, 112);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(72, 44);
            btStart.TabIndex = 4;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new System.Drawing.Point(535, 52);
            tbSpeed.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbSpeed.Maximum = 25;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new System.Drawing.Size(148, 69);
            tbSpeed.TabIndex = 3;
            tbSpeed.Value = 10;
            tbSpeed.Scroll += tbSpeed_Scroll;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(537, 21);
            label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(62, 25);
            label16.TabIndex = 2;
            label16.Text = "Speed";
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(365, 52);
            lbTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(155, 25);
            lbTime.TabIndex = 1;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Location = new System.Drawing.Point(10, 37);
            tbTimeline.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(345, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // btSelectFile
            // 
            btSelectFile.Location = new System.Drawing.Point(1202, 52);
            btSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(38, 44);
            btSelectFile.TabIndex = 23;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // edFilenameOrURL
            // 
            edFilenameOrURL.Location = new System.Drawing.Point(547, 56);
            edFilenameOrURL.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edFilenameOrURL.Name = "edFilenameOrURL";
            edFilenameOrURL.Size = new System.Drawing.Size(577, 31);
            edFilenameOrURL.TabIndex = 22;
            edFilenameOrURL.Text = "c:\\Samples\\!video.avi";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(542, 25);
            label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(145, 25);
            label14.TabIndex = 21;
            label14.Text = "File name or URL";
            // 
            // groupBox44
            // 
            groupBox44.Controls.Add(edPIPFileHeight);
            groupBox44.Controls.Add(label321);
            groupBox44.Controls.Add(edPIPFileWidth);
            groupBox44.Controls.Add(label322);
            groupBox44.Controls.Add(edPIPFileTop);
            groupBox44.Controls.Add(label323);
            groupBox44.Controls.Add(edPIPFileLeft);
            groupBox44.Controls.Add(label324);
            groupBox44.Location = new System.Drawing.Point(23, 25);
            groupBox44.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox44.Name = "groupBox44";
            groupBox44.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox44.Size = new System.Drawing.Size(340, 150);
            groupBox44.TabIndex = 65;
            groupBox44.TabStop = false;
            groupBox44.Text = "Position";
            // 
            // edPIPFileHeight
            // 
            edPIPFileHeight.Location = new System.Drawing.Point(250, 87);
            edPIPFileHeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edPIPFileHeight.Name = "edPIPFileHeight";
            edPIPFileHeight.Size = new System.Drawing.Size(62, 31);
            edPIPFileHeight.TabIndex = 40;
            edPIPFileHeight.Text = "200";
            edPIPFileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label321
            // 
            label321.AutoSize = true;
            label321.Location = new System.Drawing.Point(187, 92);
            label321.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label321.Name = "label321";
            label321.Size = new System.Drawing.Size(65, 25);
            label321.TabIndex = 39;
            label321.Text = "Height";
            // 
            // edPIPFileWidth
            // 
            edPIPFileWidth.Location = new System.Drawing.Point(250, 37);
            edPIPFileWidth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edPIPFileWidth.Name = "edPIPFileWidth";
            edPIPFileWidth.Size = new System.Drawing.Size(62, 31);
            edPIPFileWidth.TabIndex = 38;
            edPIPFileWidth.Text = "300";
            edPIPFileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label322
            // 
            label322.AutoSize = true;
            label322.Location = new System.Drawing.Point(187, 42);
            label322.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label322.Name = "label322";
            label322.Size = new System.Drawing.Size(60, 25);
            label322.TabIndex = 37;
            label322.Text = "Width";
            // 
            // edPIPFileTop
            // 
            edPIPFileTop.Location = new System.Drawing.Point(80, 87);
            edPIPFileTop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edPIPFileTop.Name = "edPIPFileTop";
            edPIPFileTop.Size = new System.Drawing.Size(62, 31);
            edPIPFileTop.TabIndex = 36;
            edPIPFileTop.Text = "0";
            edPIPFileTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label323
            // 
            label323.AutoSize = true;
            label323.Location = new System.Drawing.Point(25, 92);
            label323.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label323.Name = "label323";
            label323.Size = new System.Drawing.Size(41, 25);
            label323.TabIndex = 35;
            label323.Text = "Top";
            // 
            // edPIPFileLeft
            // 
            edPIPFileLeft.Location = new System.Drawing.Point(80, 37);
            edPIPFileLeft.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edPIPFileLeft.Name = "edPIPFileLeft";
            edPIPFileLeft.Size = new System.Drawing.Size(62, 31);
            edPIPFileLeft.TabIndex = 34;
            edPIPFileLeft.Text = "0";
            edPIPFileLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label324
            // 
            label324.AutoSize = true;
            label324.Location = new System.Drawing.Point(25, 42);
            label324.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label324.Name = "label324";
            label324.Size = new System.Drawing.Size(41, 25);
            label324.TabIndex = 33;
            label324.Text = "Left";
            // 
            // btUpdateRect
            // 
            btUpdateRect.Location = new System.Drawing.Point(215, 402);
            btUpdateRect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btUpdateRect.Name = "btUpdateRect";
            btUpdateRect.Size = new System.Drawing.Size(125, 44);
            btUpdateRect.TabIndex = 66;
            btUpdateRect.Text = "Update";
            btUpdateRect.UseVisualStyleBackColor = true;
            btUpdateRect.Click += btUpdateRect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(77, 181);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(259, 25);
            label1.TabIndex = 67;
            label1.Text = "If all values are 0 - entire screen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(407, 67);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 25);
            label2.TabIndex = 68;
            label2.Text = "Z-order";
            // 
            // edZOrder
            // 
            edZOrder.Location = new System.Drawing.Point(410, 112);
            edZOrder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edZOrder.Name = "edZOrder";
            edZOrder.Size = new System.Drawing.Size(62, 31);
            edZOrder.TabIndex = 69;
            edZOrder.Text = "0";
            edZOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbStreamTransparency
            // 
            tbStreamTransparency.Location = new System.Drawing.Point(28, 285);
            tbStreamTransparency.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbStreamTransparency.Maximum = 100;
            tbStreamTransparency.Name = "tbStreamTransparency";
            tbStreamTransparency.Size = new System.Drawing.Size(335, 69);
            tbStreamTransparency.TabIndex = 70;
            tbStreamTransparency.Value = 100;
            tbStreamTransparency.Scroll += tbStreamTransparency_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 254);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(173, 25);
            label3.TabIndex = 71;
            label3.Text = "Stream transparency";
            // 
            // lbStreamTransparency
            // 
            lbStreamTransparency.AutoSize = true;
            lbStreamTransparency.Location = new System.Drawing.Point(305, 254);
            lbStreamTransparency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbStreamTransparency.Name = "lbStreamTransparency";
            lbStreamTransparency.Size = new System.Drawing.Size(42, 25);
            lbStreamTransparency.TabIndex = 72;
            lbStreamTransparency.Text = "100";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(18, 504);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(0, 25);
            label4.TabIndex = 73;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.ForeColor = System.Drawing.Color.Transparent;
            textBox1.Location = new System.Drawing.Point(23, 465);
            textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(508, 217);
            textBox1.TabIndex = 74;
            textBox1.Text = "First file will cover entire screen by default. You can set position for each stream independently.";
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(547, 313);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(693, 596);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 75;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1258, 1225);
            Controls.Add(VideoView1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(lbStreamTransparency);
            Controls.Add(label3);
            Controls.Add(tbStreamTransparency);
            Controls.Add(edZOrder);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btUpdateRect);
            Controls.Add(groupBox44);
            Controls.Add(linkLabel1);
            Controls.Add(btAddFileToPlaylist);
            Controls.Add(label30);
            Controls.Add(lbSourceFiles);
            Controls.Add(cbSourceMode);
            Controls.Add(label29);
            Controls.Add(tabControl3);
            Controls.Add(groupBox2);
            Controls.Add(btSelectFile);
            Controls.Add(edFilenameOrURL);
            Controls.Add(label14);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Player SDK .Net - Video Mixing Demo";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Shown += Form1_Shown;
            tabControl3.ResumeLayout(false);
            tabPage10.ResumeLayout(false);
            tabPage10.PerformLayout();
            tabPage9.ResumeLayout(false);
            tabControl13.ResumeLayout(false);
            tabPage54.ResumeLayout(false);
            tabPage54.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbJPEGQuality).EndInit();
            tabPage55.ResumeLayout(false);
            tabPage55.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            groupBox44.ResumeLayout(false);
            groupBox44.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbStreamTransparency).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

