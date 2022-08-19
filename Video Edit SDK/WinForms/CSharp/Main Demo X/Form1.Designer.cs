using VisioForge.Core.Types;

namespace VideoEdit_CS_Demo
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

            DestroyEngine();

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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbOutputVideoFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage48 = new System.Windows.Forms.TabPage();
            this.edCropRight = new System.Windows.Forms.TextBox();
            this.label176 = new System.Windows.Forms.Label();
            this.edCropBottom = new System.Windows.Forms.TextBox();
            this.label252 = new System.Windows.Forms.Label();
            this.edCropLeft = new System.Windows.Forms.TextBox();
            this.label270 = new System.Windows.Forms.Label();
            this.edCropTop = new System.Windows.Forms.TextBox();
            this.label272 = new System.Windows.Forms.Label();
            this.cbCrop = new System.Windows.Forms.CheckBox();
            this.label92 = new System.Windows.Forms.Label();
            this.cbRotate = new System.Windows.Forms.ComboBox();
            this.cbFrameRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edHeight = new System.Windows.Forms.TextBox();
            this.edWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.tabControl17 = new System.Windows.Forms.TabControl();
            this.tabPage68 = new System.Windows.Forms.TabPage();
            this.cbDenoise = new System.Windows.Forms.CheckBox();
            this.cbDeinterlace = new System.Windows.Forms.CheckBox();
            this.cbImageOverlay = new System.Windows.Forms.CheckBox();
            this.cbTextOverlay = new System.Windows.Forms.CheckBox();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbHue = new System.Windows.Forms.TrackBar();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.cbSepia = new System.Windows.Forms.CheckBox();
            this.cbGreyscale = new System.Windows.Forms.CheckBox();
            this.cbEffects = new System.Windows.Forms.CheckBox();
            this.tabPage82 = new System.Windows.Forms.TabPage();
            this.label177 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.btSubtitlesSelectFile = new System.Windows.Forms.Button();
            this.edSubtitlesFilename = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.cbSubtitlesEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.edTransStopTime = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.edTransStartTime = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.btAddTransition = new System.Windows.Forms.Button();
            this.cbTransitionName = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.lbTransitions = new System.Windows.Forms.ListBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label133 = new System.Windows.Forms.Label();
            this.tabControl18 = new System.Windows.Forms.TabControl();
            this.tabPage71 = new System.Windows.Forms.TabPage();
            this.tbAudAmplifyAmp = new System.Windows.Forms.TrackBar();
            this.label95 = new System.Windows.Forms.Label();
            this.cbAudAmplifyEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage72 = new System.Windows.Forms.TabPage();
            this.label242 = new System.Windows.Forms.Label();
            this.label241 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.label239 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.label237 = new System.Windows.Forms.Label();
            this.label236 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.label234 = new System.Windows.Forms.Label();
            this.label233 = new System.Windows.Forms.Label();
            this.tbAudEq9 = new System.Windows.Forms.TrackBar();
            this.tbAudEq8 = new System.Windows.Forms.TrackBar();
            this.tbAudEq7 = new System.Windows.Forms.TrackBar();
            this.tbAudEq6 = new System.Windows.Forms.TrackBar();
            this.tbAudEq5 = new System.Windows.Forms.TrackBar();
            this.tbAudEq4 = new System.Windows.Forms.TrackBar();
            this.tbAudEq3 = new System.Windows.Forms.TrackBar();
            this.tbAudEq2 = new System.Windows.Forms.TrackBar();
            this.tbAudEq1 = new System.Windows.Forms.TrackBar();
            this.tbAudEq0 = new System.Windows.Forms.TrackBar();
            this.cbAudEqualizerEnabled = new System.Windows.Forms.CheckBox();
            this.cbAudioEffectsEnabled = new System.Windows.Forms.CheckBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tbSeeking = new System.Windows.Forms.TrackBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label130 = new System.Windows.Forms.Label();
            this.openFileDialogSubtitles = new System.Windows.Forms.OpenFileDialog();
            this.cbTelemetry = new System.Windows.Forms.CheckBox();
            this.cbLicensing = new System.Windows.Forms.CheckBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label72 = new System.Windows.Forms.Label();
            this.edInsertTime = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.cbInsertAfterPreviousFile = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.edStopTime = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.edStartTime = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cbAddFullFile = new System.Windows.Forms.CheckBox();
            this.btClearList = new System.Windows.Forms.Button();
            this.btAddInputFile = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage48.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabControl17.SuspendLayout();
            this.tabPage68.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            this.tabPage82.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl18.SuspendLayout();
            this.tabPage71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).BeginInit();
            this.tabPage72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeeking)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage31);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(457, 767);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage30);
            this.tabControl2.Controls.Add(this.tabPage48);
            this.tabControl2.Location = new System.Drawing.Point(6, 9);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(438, 742);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPage30
            // 
            this.tabPage30.Controls.Add(this.lbInfo);
            this.tabPage30.Controls.Add(this.btSelectOutput);
            this.tabPage30.Controls.Add(this.edOutput);
            this.tabPage30.Controls.Add(this.label15);
            this.tabPage30.Controls.Add(this.cbOutputVideoFormat);
            this.tabPage30.Controls.Add(this.label9);
            this.tabPage30.Location = new System.Drawing.Point(4, 29);
            this.tabPage30.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage30.Size = new System.Drawing.Size(430, 709);
            this.tabPage30.TabIndex = 6;
            this.tabPage30.Text = "Main";
            this.tabPage30.UseVisualStyleBackColor = true;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(12, 98);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(326, 20);
            this.lbInfo.TabIndex = 52;
            this.lbInfo.Text = "You can use API to configure format settings";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(366, 232);
            this.btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(39, 35);
            this.btSelectOutput.TabIndex = 31;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(16, 235);
            this.edOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(338, 26);
            this.edOutput.TabIndex = 30;
            this.edOutput.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 208);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "File name";
            // 
            // cbOutputVideoFormat
            // 
            this.cbOutputVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputVideoFormat.FormattingEnabled = true;
            this.cbOutputVideoFormat.Items.AddRange(new object[] {
            "MP4",
            "WebM",
            "AVI",
            "MKV (Matroska)",
            "WMV (Windows Media Video)",
            "PCM",
            "MP3",
            "M4A (AAC)",
            "WMA (Windows Media Audio)",
            "Ogg Vorbis",
            "FLAC",
            "Speex"});
            this.cbOutputVideoFormat.Location = new System.Drawing.Point(16, 52);
            this.cbOutputVideoFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOutputVideoFormat.Name = "cbOutputVideoFormat";
            this.cbOutputVideoFormat.Size = new System.Drawing.Size(386, 28);
            this.cbOutputVideoFormat.TabIndex = 28;
            this.cbOutputVideoFormat.SelectedIndexChanged += new System.EventHandler(this.cbOutputVideoFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Format";
            // 
            // tabPage48
            // 
            this.tabPage48.Controls.Add(this.edCropRight);
            this.tabPage48.Controls.Add(this.label176);
            this.tabPage48.Controls.Add(this.edCropBottom);
            this.tabPage48.Controls.Add(this.label252);
            this.tabPage48.Controls.Add(this.edCropLeft);
            this.tabPage48.Controls.Add(this.label270);
            this.tabPage48.Controls.Add(this.edCropTop);
            this.tabPage48.Controls.Add(this.label272);
            this.tabPage48.Controls.Add(this.cbCrop);
            this.tabPage48.Controls.Add(this.label92);
            this.tabPage48.Controls.Add(this.cbRotate);
            this.tabPage48.Controls.Add(this.cbFrameRate);
            this.tabPage48.Controls.Add(this.label3);
            this.tabPage48.Controls.Add(this.edHeight);
            this.tabPage48.Controls.Add(this.edWidth);
            this.tabPage48.Controls.Add(this.label2);
            this.tabPage48.Controls.Add(this.cbResize);
            this.tabPage48.Location = new System.Drawing.Point(4, 29);
            this.tabPage48.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage48.Name = "tabPage48";
            this.tabPage48.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage48.Size = new System.Drawing.Size(430, 709);
            this.tabPage48.TabIndex = 14;
            this.tabPage48.Text = "Resolution / frame rate";
            this.tabPage48.UseVisualStyleBackColor = true;
            // 
            // edCropRight
            // 
            this.edCropRight.Location = new System.Drawing.Point(273, 337);
            this.edCropRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCropRight.Name = "edCropRight";
            this.edCropRight.Size = new System.Drawing.Size(52, 26);
            this.edCropRight.TabIndex = 174;
            this.edCropRight.Text = "0";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(212, 343);
            this.label176.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(47, 20);
            this.label176.TabIndex = 173;
            this.label176.Text = "Right";
            // 
            // edCropBottom
            // 
            this.edCropBottom.Location = new System.Drawing.Point(130, 337);
            this.edCropBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCropBottom.Name = "edCropBottom";
            this.edCropBottom.Size = new System.Drawing.Size(52, 26);
            this.edCropBottom.TabIndex = 172;
            this.edCropBottom.Text = "0";
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Location = new System.Drawing.Point(62, 343);
            this.label252.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(61, 20);
            this.label252.TabIndex = 171;
            this.label252.Text = "Bottom";
            // 
            // edCropLeft
            // 
            this.edCropLeft.Location = new System.Drawing.Point(273, 297);
            this.edCropLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCropLeft.Name = "edCropLeft";
            this.edCropLeft.Size = new System.Drawing.Size(52, 26);
            this.edCropLeft.TabIndex = 170;
            this.edCropLeft.Text = "0";
            // 
            // label270
            // 
            this.label270.AutoSize = true;
            this.label270.Location = new System.Drawing.Point(212, 303);
            this.label270.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(37, 20);
            this.label270.TabIndex = 169;
            this.label270.Text = "Left";
            // 
            // edCropTop
            // 
            this.edCropTop.Location = new System.Drawing.Point(130, 297);
            this.edCropTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edCropTop.Name = "edCropTop";
            this.edCropTop.Size = new System.Drawing.Size(52, 26);
            this.edCropTop.TabIndex = 168;
            this.edCropTop.Text = "0";
            // 
            // label272
            // 
            this.label272.AutoSize = true;
            this.label272.Location = new System.Drawing.Point(62, 303);
            this.label272.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label272.Name = "label272";
            this.label272.Size = new System.Drawing.Size(36, 20);
            this.label272.TabIndex = 167;
            this.label272.Text = "Top";
            // 
            // cbCrop
            // 
            this.cbCrop.AutoSize = true;
            this.cbCrop.Location = new System.Drawing.Point(21, 263);
            this.cbCrop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCrop.Name = "cbCrop";
            this.cbCrop.Size = new System.Drawing.Size(69, 24);
            this.cbCrop.TabIndex = 166;
            this.cbCrop.Text = "Crop";
            this.cbCrop.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(16, 215);
            this.label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(58, 20);
            this.label92.TabIndex = 165;
            this.label92.Text = "Rotate";
            // 
            // cbRotate
            // 
            this.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotate.FormattingEnabled = true;
            this.cbRotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbRotate.Location = new System.Drawing.Point(130, 211);
            this.cbRotate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(178, 28);
            this.cbRotate.TabIndex = 164;
            // 
            // cbFrameRate
            // 
            this.cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrameRate.FormattingEnabled = true;
            this.cbFrameRate.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "5",
            "10",
            "12",
            "15",
            "20",
            "25",
            "30"});
            this.cbFrameRate.Location = new System.Drawing.Point(21, 97);
            this.cbFrameRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFrameRate.Name = "cbFrameRate";
            this.cbFrameRate.Size = new System.Drawing.Size(85, 28);
            this.cbFrameRate.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 20);
            this.label3.TabIndex = 162;
            this.label3.Text = "Frame rate (Use 0 to have original, set before adding files)";
            // 
            // edHeight
            // 
            this.edHeight.Location = new System.Drawing.Point(238, 20);
            this.edHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edHeight.Name = "edHeight";
            this.edHeight.Size = new System.Drawing.Size(70, 26);
            this.edHeight.TabIndex = 161;
            this.edHeight.Text = "576";
            // 
            // edWidth
            // 
            this.edWidth.Location = new System.Drawing.Point(130, 20);
            this.edWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edWidth.Name = "edWidth";
            this.edWidth.Size = new System.Drawing.Size(70, 26);
            this.edWidth.TabIndex = 160;
            this.edWidth.Text = "768";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 159;
            this.label2.Text = "x";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Location = new System.Drawing.Point(21, 25);
            this.cbResize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(84, 24);
            this.cbResize.TabIndex = 158;
            this.cbResize.Text = "Resize";
            this.cbResize.UseVisualStyleBackColor = true;
            // 
            // tabPage31
            // 
            this.tabPage31.Controls.Add(this.tabControl17);
            this.tabPage31.Location = new System.Drawing.Point(4, 29);
            this.tabPage31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage31.Size = new System.Drawing.Size(457, 767);
            this.tabPage31.TabIndex = 4;
            this.tabPage31.Text = "Video processing";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // tabControl17
            // 
            this.tabControl17.Controls.Add(this.tabPage68);
            this.tabControl17.Controls.Add(this.tabPage82);
            this.tabControl17.Location = new System.Drawing.Point(2, 9);
            this.tabControl17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl17.Name = "tabControl17";
            this.tabControl17.SelectedIndex = 0;
            this.tabControl17.Size = new System.Drawing.Size(447, 746);
            this.tabControl17.TabIndex = 37;
            // 
            // tabPage68
            // 
            this.tabPage68.Controls.Add(this.cbDenoise);
            this.tabPage68.Controls.Add(this.cbDeinterlace);
            this.tabPage68.Controls.Add(this.cbImageOverlay);
            this.tabPage68.Controls.Add(this.cbTextOverlay);
            this.tabPage68.Controls.Add(this.cbFlipY);
            this.tabPage68.Controls.Add(this.cbFlipX);
            this.tabPage68.Controls.Add(this.label201);
            this.tabPage68.Controls.Add(this.label200);
            this.tabPage68.Controls.Add(this.label199);
            this.tabPage68.Controls.Add(this.label198);
            this.tabPage68.Controls.Add(this.tbContrast);
            this.tabPage68.Controls.Add(this.tbHue);
            this.tabPage68.Controls.Add(this.tbBrightness);
            this.tabPage68.Controls.Add(this.tbSaturation);
            this.tabPage68.Controls.Add(this.cbSepia);
            this.tabPage68.Controls.Add(this.cbGreyscale);
            this.tabPage68.Controls.Add(this.cbEffects);
            this.tabPage68.Location = new System.Drawing.Point(4, 29);
            this.tabPage68.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage68.Name = "tabPage68";
            this.tabPage68.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage68.Size = new System.Drawing.Size(439, 713);
            this.tabPage68.TabIndex = 0;
            this.tabPage68.Text = "Effects";
            this.tabPage68.UseVisualStyleBackColor = true;
            // 
            // cbDenoise
            // 
            this.cbDenoise.AutoSize = true;
            this.cbDenoise.Location = new System.Drawing.Point(225, 370);
            this.cbDenoise.Name = "cbDenoise";
            this.cbDenoise.Size = new System.Drawing.Size(94, 24);
            this.cbDenoise.TabIndex = 73;
            this.cbDenoise.Text = "Denoise";
            this.cbDenoise.UseVisualStyleBackColor = true;
            // 
            // cbDeinterlace
            // 
            this.cbDeinterlace.AutoSize = true;
            this.cbDeinterlace.Location = new System.Drawing.Point(14, 370);
            this.cbDeinterlace.Name = "cbDeinterlace";
            this.cbDeinterlace.Size = new System.Drawing.Size(116, 24);
            this.cbDeinterlace.TabIndex = 72;
            this.cbDeinterlace.Text = "Deinterlace";
            this.cbDeinterlace.UseVisualStyleBackColor = true;
            // 
            // cbImageOverlay
            // 
            this.cbImageOverlay.AutoSize = true;
            this.cbImageOverlay.Location = new System.Drawing.Point(225, 307);
            this.cbImageOverlay.Name = "cbImageOverlay";
            this.cbImageOverlay.Size = new System.Drawing.Size(189, 24);
            this.cbImageOverlay.TabIndex = 71;
            this.cbImageOverlay.Text = "Sample image overlay";
            this.cbImageOverlay.UseVisualStyleBackColor = true;
            // 
            // cbTextOverlay
            // 
            this.cbTextOverlay.AutoSize = true;
            this.cbTextOverlay.Location = new System.Drawing.Point(14, 307);
            this.cbTextOverlay.Name = "cbTextOverlay";
            this.cbTextOverlay.Size = new System.Drawing.Size(172, 24);
            this.cbTextOverlay.TabIndex = 70;
            this.cbTextOverlay.Text = "Sample text overlay";
            this.cbTextOverlay.UseVisualStyleBackColor = true;
            // 
            // cbFlipY
            // 
            this.cbFlipY.AutoSize = true;
            this.cbFlipY.Location = new System.Drawing.Point(315, 243);
            this.cbFlipY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(75, 24);
            this.cbFlipY.TabIndex = 69;
            this.cbFlipY.Text = "Flip Y";
            this.cbFlipY.UseVisualStyleBackColor = true;
            // 
            // cbFlipX
            // 
            this.cbFlipX.AutoSize = true;
            this.cbFlipX.Location = new System.Drawing.Point(225, 243);
            this.cbFlipX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(75, 24);
            this.cbFlipX.TabIndex = 68;
            this.cbFlipX.Text = "Flip X";
            this.cbFlipX.UseVisualStyleBackColor = true;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(213, 135);
            this.label201.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(39, 20);
            this.label201.TabIndex = 63;
            this.label201.Text = "Hue";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(9, 135);
            this.label200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(70, 20);
            this.label200.TabIndex = 62;
            this.label200.Text = "Contrast";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(213, 55);
            this.label199.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(83, 20);
            this.label199.TabIndex = 61;
            this.label199.Text = "Saturation";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(9, 55);
            this.label198.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(85, 20);
            this.label198.TabIndex = 60;
            this.label198.Text = "Brightness";
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tbContrast.Location = new System.Drawing.Point(4, 165);
            this.tbContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContrast.Maximum = 200;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(195, 69);
            this.tbContrast.TabIndex = 49;
            this.tbContrast.Value = 100;
            // 
            // tbHue
            // 
            this.tbHue.BackColor = System.Drawing.SystemColors.Window;
            this.tbHue.Location = new System.Drawing.Point(213, 165);
            this.tbHue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbHue.Maximum = 100;
            this.tbHue.Minimum = -100;
            this.tbHue.Name = "tbHue";
            this.tbHue.Size = new System.Drawing.Size(195, 69);
            this.tbHue.TabIndex = 46;
            // 
            // tbBrightness
            // 
            this.tbBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.tbBrightness.Location = new System.Drawing.Point(4, 78);
            this.tbBrightness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(195, 69);
            this.tbBrightness.TabIndex = 45;
            // 
            // tbSaturation
            // 
            this.tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.tbSaturation.Location = new System.Drawing.Point(213, 78);
            this.tbSaturation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSaturation.Maximum = 200;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(195, 69);
            this.tbSaturation.TabIndex = 43;
            this.tbSaturation.Value = 100;
            // 
            // cbSepia
            // 
            this.cbSepia.AutoSize = true;
            this.cbSepia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbSepia.Location = new System.Drawing.Point(135, 243);
            this.cbSepia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSepia.Name = "cbSepia";
            this.cbSepia.Size = new System.Drawing.Size(76, 24);
            this.cbSepia.TabIndex = 41;
            this.cbSepia.Text = "Sepia";
            this.cbSepia.UseVisualStyleBackColor = true;
            // 
            // cbGreyscale
            // 
            this.cbGreyscale.AutoSize = true;
            this.cbGreyscale.Location = new System.Drawing.Point(14, 243);
            this.cbGreyscale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGreyscale.Name = "cbGreyscale";
            this.cbGreyscale.Size = new System.Drawing.Size(106, 24);
            this.cbGreyscale.TabIndex = 39;
            this.cbGreyscale.Text = "Greyscale";
            this.cbGreyscale.UseVisualStyleBackColor = true;
            // 
            // cbEffects
            // 
            this.cbEffects.AutoSize = true;
            this.cbEffects.Checked = true;
            this.cbEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEffects.Location = new System.Drawing.Point(12, 12);
            this.cbEffects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEffects.Name = "cbEffects";
            this.cbEffects.Size = new System.Drawing.Size(94, 24);
            this.cbEffects.TabIndex = 37;
            this.cbEffects.Text = "Enabled";
            this.cbEffects.UseVisualStyleBackColor = true;
            // 
            // tabPage82
            // 
            this.tabPage82.Controls.Add(this.label177);
            this.tabPage82.Controls.Add(this.label129);
            this.tabPage82.Controls.Add(this.btSubtitlesSelectFile);
            this.tabPage82.Controls.Add(this.edSubtitlesFilename);
            this.tabPage82.Controls.Add(this.label114);
            this.tabPage82.Controls.Add(this.cbSubtitlesEnabled);
            this.tabPage82.Location = new System.Drawing.Point(4, 29);
            this.tabPage82.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage82.Name = "tabPage82";
            this.tabPage82.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage82.Size = new System.Drawing.Size(439, 713);
            this.tabPage82.TabIndex = 7;
            this.tabPage82.Text = "Subtitles";
            this.tabPage82.UseVisualStyleBackColor = true;
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(16, 162);
            this.label177.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(121, 20);
            this.label177.TabIndex = 5;
            this.label177.Text = " using interface.";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(16, 132);
            this.label129.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(364, 20);
            this.label129.TabIndex = 4;
            this.label129.Text = "Use OnSubtitleSettings event to set other settings";
            // 
            // btSubtitlesSelectFile
            // 
            this.btSubtitlesSelectFile.Location = new System.Drawing.Point(376, 86);
            this.btSubtitlesSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSubtitlesSelectFile.Name = "btSubtitlesSelectFile";
            this.btSubtitlesSelectFile.Size = new System.Drawing.Size(34, 35);
            this.btSubtitlesSelectFile.TabIndex = 3;
            this.btSubtitlesSelectFile.Text = "...";
            this.btSubtitlesSelectFile.UseVisualStyleBackColor = true;
            this.btSubtitlesSelectFile.Click += new System.EventHandler(this.btSubtitlesSelectFile_Click);
            // 
            // edSubtitlesFilename
            // 
            this.edSubtitlesFilename.Location = new System.Drawing.Point(21, 89);
            this.edSubtitlesFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edSubtitlesFilename.Name = "edSubtitlesFilename";
            this.edSubtitlesFilename.Size = new System.Drawing.Size(346, 26);
            this.edSubtitlesFilename.TabIndex = 2;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(16, 65);
            this.label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(78, 20);
            this.label114.TabIndex = 1;
            this.label114.Text = "File name";
            // 
            // cbSubtitlesEnabled
            // 
            this.cbSubtitlesEnabled.AutoSize = true;
            this.cbSubtitlesEnabled.Location = new System.Drawing.Point(21, 26);
            this.cbSubtitlesEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSubtitlesEnabled.Name = "cbSubtitlesEnabled";
            this.cbSubtitlesEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbSubtitlesEnabled.TabIndex = 0;
            this.cbSubtitlesEnabled.Text = "Enabled";
            this.cbSubtitlesEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox5);
            this.tabPage9.Controls.Add(this.lbTransitions);
            this.tabPage9.Controls.Add(this.label43);
            this.tabPage9.Location = new System.Drawing.Point(4, 29);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage9.Size = new System.Drawing.Size(457, 767);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Transitions";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Controls.Add(this.edTransStopTime);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.edTransStartTime);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Controls.Add(this.btAddTransition);
            this.groupBox5.Controls.Add(this.cbTransitionName);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Location = new System.Drawing.Point(30, 189);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(397, 222);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Add transition";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(200, 169);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(30, 20);
            this.label47.TabIndex = 8;
            this.label47.Text = "ms";
            // 
            // edTransStopTime
            // 
            this.edTransStopTime.Location = new System.Drawing.Point(126, 165);
            this.edTransStopTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edTransStopTime.Name = "edTransStopTime";
            this.edTransStopTime.Size = new System.Drawing.Size(62, 26);
            this.edTransStopTime.TabIndex = 7;
            this.edTransStopTime.Text = "5000";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(18, 169);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(77, 20);
            this.label48.TabIndex = 6;
            this.label48.Text = "Stop time";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(200, 129);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(30, 20);
            this.label46.TabIndex = 5;
            this.label46.Text = "ms";
            // 
            // edTransStartTime
            // 
            this.edTransStartTime.Location = new System.Drawing.Point(126, 125);
            this.edTransStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edTransStartTime.Name = "edTransStartTime";
            this.edTransStartTime.Size = new System.Drawing.Size(62, 26);
            this.edTransStartTime.TabIndex = 4;
            this.edTransStartTime.Text = "4000";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(18, 129);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(78, 20);
            this.label45.TabIndex = 3;
            this.label45.Text = "Start time";
            // 
            // btAddTransition
            // 
            this.btAddTransition.Location = new System.Drawing.Point(304, 65);
            this.btAddTransition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAddTransition.Name = "btAddTransition";
            this.btAddTransition.Size = new System.Drawing.Size(63, 35);
            this.btAddTransition.TabIndex = 2;
            this.btAddTransition.Text = "Add";
            this.btAddTransition.UseVisualStyleBackColor = true;
            this.btAddTransition.Click += new System.EventHandler(this.btAddTransition_Click);
            // 
            // cbTransitionName
            // 
            this.cbTransitionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransitionName.FormattingEnabled = true;
            this.cbTransitionName.Location = new System.Drawing.Point(22, 68);
            this.cbTransitionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTransitionName.Name = "cbTransitionName";
            this.cbTransitionName.Size = new System.Drawing.Size(271, 28);
            this.cbTransitionName.TabIndex = 1;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(18, 43);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(51, 20);
            this.label44.TabIndex = 0;
            this.label44.Text = "Name";
            // 
            // lbTransitions
            // 
            this.lbTransitions.FormattingEnabled = true;
            this.lbTransitions.ItemHeight = 20;
            this.lbTransitions.Location = new System.Drawing.Point(30, 54);
            this.lbTransitions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbTransitions.Name = "lbTransitions";
            this.lbTransitions.Size = new System.Drawing.Size(397, 124);
            this.lbTransitions.TabIndex = 1;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(26, 29);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(72, 20);
            this.label43.TabIndex = 0;
            this.label43.Text = "Selected";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label133);
            this.tabPage3.Controls.Add(this.tabControl18);
            this.tabPage3.Controls.Add(this.cbAudioEffectsEnabled);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(457, 767);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Audio effects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(152, 25);
            this.label133.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(278, 20);
            this.label133.TabIndex = 4;
            this.label133.Text = "Much more effects available using API";
            // 
            // tabControl18
            // 
            this.tabControl18.Controls.Add(this.tabPage71);
            this.tabControl18.Controls.Add(this.tabPage72);
            this.tabControl18.Location = new System.Drawing.Point(15, 58);
            this.tabControl18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl18.Name = "tabControl18";
            this.tabControl18.SelectedIndex = 0;
            this.tabControl18.Size = new System.Drawing.Size(424, 680);
            this.tabControl18.TabIndex = 3;
            // 
            // tabPage71
            // 
            this.tabPage71.Controls.Add(this.tbAudAmplifyAmp);
            this.tabPage71.Controls.Add(this.label95);
            this.tabPage71.Controls.Add(this.cbAudAmplifyEnabled);
            this.tabPage71.Location = new System.Drawing.Point(4, 29);
            this.tabPage71.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage71.Name = "tabPage71";
            this.tabPage71.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage71.Size = new System.Drawing.Size(416, 647);
            this.tabPage71.TabIndex = 0;
            this.tabPage71.Text = "Amplify";
            this.tabPage71.UseVisualStyleBackColor = true;
            // 
            // tbAudAmplifyAmp
            // 
            this.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudAmplifyAmp.Location = new System.Drawing.Point(24, 106);
            this.tbAudAmplifyAmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudAmplifyAmp.Maximum = 1000;
            this.tbAudAmplifyAmp.Minimum = 100;
            this.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp";
            this.tbAudAmplifyAmp.Size = new System.Drawing.Size(345, 69);
            this.tbAudAmplifyAmp.TabIndex = 3;
            this.tbAudAmplifyAmp.TickFrequency = 50;
            this.tbAudAmplifyAmp.Value = 100;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(20, 82);
            this.label95.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(63, 20);
            this.label95.TabIndex = 2;
            this.label95.Text = "Volume";
            // 
            // cbAudAmplifyEnabled
            // 
            this.cbAudAmplifyEnabled.AutoSize = true;
            this.cbAudAmplifyEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudAmplifyEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled";
            this.cbAudAmplifyEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudAmplifyEnabled.TabIndex = 1;
            this.cbAudAmplifyEnabled.Text = "Enabled";
            this.cbAudAmplifyEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage72
            // 
            this.tabPage72.Controls.Add(this.label242);
            this.tabPage72.Controls.Add(this.label241);
            this.tabPage72.Controls.Add(this.label240);
            this.tabPage72.Controls.Add(this.label239);
            this.tabPage72.Controls.Add(this.label238);
            this.tabPage72.Controls.Add(this.label237);
            this.tabPage72.Controls.Add(this.label236);
            this.tabPage72.Controls.Add(this.label235);
            this.tabPage72.Controls.Add(this.label234);
            this.tabPage72.Controls.Add(this.label233);
            this.tabPage72.Controls.Add(this.tbAudEq9);
            this.tabPage72.Controls.Add(this.tbAudEq8);
            this.tabPage72.Controls.Add(this.tbAudEq7);
            this.tabPage72.Controls.Add(this.tbAudEq6);
            this.tabPage72.Controls.Add(this.tbAudEq5);
            this.tabPage72.Controls.Add(this.tbAudEq4);
            this.tabPage72.Controls.Add(this.tbAudEq3);
            this.tabPage72.Controls.Add(this.tbAudEq2);
            this.tabPage72.Controls.Add(this.tbAudEq1);
            this.tabPage72.Controls.Add(this.tbAudEq0);
            this.tabPage72.Controls.Add(this.cbAudEqualizerEnabled);
            this.tabPage72.Location = new System.Drawing.Point(4, 29);
            this.tabPage72.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage72.Name = "tabPage72";
            this.tabPage72.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage72.Size = new System.Drawing.Size(416, 647);
            this.tabPage72.TabIndex = 1;
            this.tabPage72.Text = "Equalizer";
            this.tabPage72.UseVisualStyleBackColor = true;
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(309, 240);
            this.label242.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(37, 20);
            this.label242.TabIndex = 23;
            this.label242.Text = "16K";
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(276, 240);
            this.label241.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(37, 20);
            this.label241.TabIndex = 22;
            this.label241.Text = "14K";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(243, 240);
            this.label240.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(37, 20);
            this.label240.TabIndex = 21;
            this.label240.Text = "12K";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(214, 240);
            this.label239.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(28, 20);
            this.label239.TabIndex = 20;
            this.label239.Text = "6K";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(182, 240);
            this.label238.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(28, 20);
            this.label238.TabIndex = 19;
            this.label238.Text = "3K";
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(153, 240);
            this.label237.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(28, 20);
            this.label237.TabIndex = 18;
            this.label237.Text = "1K";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(120, 240);
            this.label236.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(36, 20);
            this.label236.TabIndex = 17;
            this.label236.Text = "600";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(87, 240);
            this.label235.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(36, 20);
            this.label235.TabIndex = 16;
            this.label235.Text = "310";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(54, 240);
            this.label234.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(36, 20);
            this.label234.TabIndex = 15;
            this.label234.Text = "170";
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(27, 240);
            this.label233.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(27, 20);
            this.label233.TabIndex = 14;
            this.label233.Text = "60";
            // 
            // tbAudEq9
            // 
            this.tbAudEq9.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq9.Location = new System.Drawing.Point(308, 75);
            this.tbAudEq9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq9.Maximum = 12;
            this.tbAudEq9.Minimum = -24;
            this.tbAudEq9.Name = "tbAudEq9";
            this.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq9.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq9.TabIndex = 12;
            this.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq8
            // 
            this.tbAudEq8.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq8.Location = new System.Drawing.Point(276, 75);
            this.tbAudEq8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq8.Maximum = 12;
            this.tbAudEq8.Minimum = -24;
            this.tbAudEq8.Name = "tbAudEq8";
            this.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq8.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq8.TabIndex = 11;
            this.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq7
            // 
            this.tbAudEq7.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq7.Location = new System.Drawing.Point(243, 75);
            this.tbAudEq7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq7.Maximum = 12;
            this.tbAudEq7.Minimum = -24;
            this.tbAudEq7.Name = "tbAudEq7";
            this.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq7.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq7.TabIndex = 10;
            this.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq6
            // 
            this.tbAudEq6.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq6.Location = new System.Drawing.Point(212, 75);
            this.tbAudEq6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq6.Maximum = 12;
            this.tbAudEq6.Minimum = -24;
            this.tbAudEq6.Name = "tbAudEq6";
            this.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq6.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq6.TabIndex = 9;
            this.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq5
            // 
            this.tbAudEq5.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq5.Location = new System.Drawing.Point(180, 75);
            this.tbAudEq5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq5.Maximum = 12;
            this.tbAudEq5.Minimum = -24;
            this.tbAudEq5.Name = "tbAudEq5";
            this.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq5.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq5.TabIndex = 8;
            this.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq4
            // 
            this.tbAudEq4.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq4.Location = new System.Drawing.Point(150, 75);
            this.tbAudEq4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq4.Maximum = 12;
            this.tbAudEq4.Minimum = -24;
            this.tbAudEq4.Name = "tbAudEq4";
            this.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq4.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq4.TabIndex = 7;
            this.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq3
            // 
            this.tbAudEq3.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq3.Location = new System.Drawing.Point(118, 75);
            this.tbAudEq3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq3.Maximum = 12;
            this.tbAudEq3.Minimum = -24;
            this.tbAudEq3.Name = "tbAudEq3";
            this.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq3.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq3.TabIndex = 6;
            this.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq2
            // 
            this.tbAudEq2.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq2.Location = new System.Drawing.Point(87, 75);
            this.tbAudEq2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq2.Maximum = 12;
            this.tbAudEq2.Minimum = -24;
            this.tbAudEq2.Name = "tbAudEq2";
            this.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq2.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq2.TabIndex = 5;
            this.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq1
            // 
            this.tbAudEq1.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq1.Location = new System.Drawing.Point(56, 75);
            this.tbAudEq1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq1.Maximum = 12;
            this.tbAudEq1.Minimum = -24;
            this.tbAudEq1.Name = "tbAudEq1";
            this.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq1.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq1.TabIndex = 4;
            this.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAudEq0
            // 
            this.tbAudEq0.BackColor = System.Drawing.SystemColors.Window;
            this.tbAudEq0.Location = new System.Drawing.Point(26, 75);
            this.tbAudEq0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAudEq0.Maximum = 12;
            this.tbAudEq0.Minimum = -24;
            this.tbAudEq0.Name = "tbAudEq0";
            this.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAudEq0.Size = new System.Drawing.Size(69, 160);
            this.tbAudEq0.TabIndex = 3;
            this.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // cbAudEqualizerEnabled
            // 
            this.cbAudEqualizerEnabled.AutoSize = true;
            this.cbAudEqualizerEnabled.Location = new System.Drawing.Point(24, 25);
            this.cbAudEqualizerEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled";
            this.cbAudEqualizerEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudEqualizerEnabled.TabIndex = 2;
            this.cbAudEqualizerEnabled.Text = "Enabled";
            this.cbAudEqualizerEnabled.UseVisualStyleBackColor = true;
            // 
            // cbAudioEffectsEnabled
            // 
            this.cbAudioEffectsEnabled.AutoSize = true;
            this.cbAudioEffectsEnabled.Location = new System.Drawing.Point(15, 23);
            this.cbAudioEffectsEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAudioEffectsEnabled.Name = "cbAudioEffectsEnabled";
            this.cbAudioEffectsEnabled.Size = new System.Drawing.Size(94, 24);
            this.cbAudioEffectsEnabled.TabIndex = 2;
            this.cbAudioEffectsEnabled.Text = "Enabled";
            this.cbAudioEffectsEnabled.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(958, 957);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(87, 35);
            this.btStart.TabIndex = 25;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(1059, 957);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(87, 35);
            this.btStop.TabIndex = 26;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // OpenDialog1
            // 
            this.OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            this.SaveDialog1.Filter = "AVI  (*.avi) | *.avi|Windows Media Video (*.wmv)| *.wmv|Matroska  (*.mkv)| *.mkv|" +
    "All files  (*.*)| *.*";
            // 
            // FontDialog1
            // 
            this.FontDialog1.Color = System.Drawing.Color.White;
            this.FontDialog1.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // tbSeeking
            // 
            this.tbSeeking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSeeking.Location = new System.Drawing.Point(501, 957);
            this.tbSeeking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSeeking.Name = "tbSeeking";
            this.tbSeeking.Size = new System.Drawing.Size(202, 69);
            this.tbSeeking.TabIndex = 46;
            this.tbSeeking.Scroll += new System.EventHandler(this.tbSeeking_Scroll);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(366, 835);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 20);
            this.linkLabel1.TabIndex = 77;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch tutorials";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            this.openFileDialog3.Filter = "Windows Media profile|*.prx";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.Location = new System.Drawing.Point(712, 957);
            this.ProgressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(237, 34);
            this.ProgressBar1.TabIndex = 9;
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Convert",
            "Preview"});
            this.cbMode.Location = new System.Drawing.Point(80, 831);
            this.cbMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(276, 28);
            this.cbMode.TabIndex = 81;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(14, 835);
            this.label130.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(49, 20);
            this.label130.TabIndex = 82;
            this.label130.Text = "Mode";
            // 
            // openFileDialogSubtitles
            // 
            this.openFileDialogSubtitles.FileName = "openFileDialog4";
            this.openFileDialogSubtitles.Filter = "Subtitle files|*.srt;*.ssa;*.ass;*.sub|All files|*.*";
            // 
            // cbTelemetry
            // 
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Checked = true;
            this.cbTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTelemetry.Location = new System.Drawing.Point(230, 882);
            this.cbTelemetry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new System.Drawing.Size(104, 24);
            this.cbTelemetry.TabIndex = 86;
            this.cbTelemetry.Text = "Telemetry";
            this.cbTelemetry.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(114, 882);
            this.cbLicensing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(102, 24);
            this.cbLicensing.TabIndex = 85;
            this.cbLicensing.Text = "Licensing";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(18, 882);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(83, 24);
            this.cbDebugMode.TabIndex = 84;
            this.cbDebugMode.Text = "Debug";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(18, 917);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mmLog.Size = new System.Drawing.Size(457, 67);
            this.mmLog.TabIndex = 83;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label72);
            this.groupBox7.Controls.Add(this.edInsertTime);
            this.groupBox7.Controls.Add(this.label73);
            this.groupBox7.Controls.Add(this.cbInsertAfterPreviousFile);
            this.groupBox7.Location = new System.Drawing.Point(862, 189);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(284, 212);
            this.groupBox7.TabIndex = 94;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Timeline";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(174, 69);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(30, 20);
            this.label72.TabIndex = 42;
            this.label72.Text = "ms";
            // 
            // edInsertTime
            // 
            this.edInsertTime.Location = new System.Drawing.Point(114, 65);
            this.edInsertTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edInsertTime.Name = "edInsertTime";
            this.edInsertTime.Size = new System.Drawing.Size(49, 26);
            this.edInsertTime.TabIndex = 41;
            this.edInsertTime.Text = "4000";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(18, 69);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(84, 20);
            this.label73.TabIndex = 40;
            this.label73.Text = "Insert time";
            // 
            // cbInsertAfterPreviousFile
            // 
            this.cbInsertAfterPreviousFile.AutoSize = true;
            this.cbInsertAfterPreviousFile.Checked = true;
            this.cbInsertAfterPreviousFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInsertAfterPreviousFile.Location = new System.Drawing.Point(18, 29);
            this.cbInsertAfterPreviousFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbInsertAfterPreviousFile.Name = "cbInsertAfterPreviousFile";
            this.cbInsertAfterPreviousFile.Size = new System.Drawing.Size(200, 24);
            this.cbInsertAfterPreviousFile.TabIndex = 39;
            this.cbInsertAfterPreviousFile.Text = "Insert after previous file";
            this.cbInsertAfterPreviousFile.UseVisualStyleBackColor = true;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(491, 156);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(378, 20);
            this.label50.TabIndex = 93;
            this.label50.Text = "You must set this parameters before you add the file";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.edStopTime);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.edStartTime);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.cbAddFullFile);
            this.groupBox6.Location = new System.Drawing.Point(496, 189);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(357, 212);
            this.groupBox6.TabIndex = 92;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input file";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(327, 69);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(30, 20);
            this.label37.TabIndex = 41;
            this.label37.Text = "ms";
            // 
            // edStopTime
            // 
            this.edStopTime.Location = new System.Drawing.Point(262, 65);
            this.edStopTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edStopTime.Name = "edStopTime";
            this.edStopTime.Size = new System.Drawing.Size(58, 26);
            this.edStopTime.TabIndex = 40;
            this.edStopTime.Text = "5000";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(186, 69);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 20);
            this.label38.TabIndex = 39;
            this.label38.Text = "Stop time";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(158, 69);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(30, 20);
            this.label36.TabIndex = 38;
            this.label36.Text = "ms";
            // 
            // edStartTime
            // 
            this.edStartTime.Location = new System.Drawing.Point(94, 65);
            this.edStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edStartTime.Name = "edStartTime";
            this.edStartTime.Size = new System.Drawing.Size(58, 26);
            this.edStartTime.TabIndex = 37;
            this.edStartTime.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 69);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(78, 20);
            this.label35.TabIndex = 36;
            this.label35.Text = "Start time";
            // 
            // cbAddFullFile
            // 
            this.cbAddFullFile.AutoSize = true;
            this.cbAddFullFile.Checked = true;
            this.cbAddFullFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddFullFile.Location = new System.Drawing.Point(18, 29);
            this.cbAddFullFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAddFullFile.Name = "cbAddFullFile";
            this.cbAddFullFile.Size = new System.Drawing.Size(112, 24);
            this.cbAddFullFile.TabIndex = 35;
            this.cbAddFullFile.Text = "Add full file";
            this.cbAddFullFile.UseVisualStyleBackColor = true;
            // 
            // btClearList
            // 
            this.btClearList.Location = new System.Drawing.Point(1050, 100);
            this.btClearList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btClearList.Name = "btClearList";
            this.btClearList.Size = new System.Drawing.Size(96, 35);
            this.btClearList.TabIndex = 91;
            this.btClearList.Text = "Clear";
            this.btClearList.UseVisualStyleBackColor = true;
            this.btClearList.Click += new System.EventHandler(this.btClearList_Click);
            // 
            // btAddInputFile
            // 
            this.btAddInputFile.Location = new System.Drawing.Point(1050, 56);
            this.btAddInputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAddInputFile.Name = "btAddInputFile";
            this.btAddInputFile.Size = new System.Drawing.Size(96, 35);
            this.btAddInputFile.TabIndex = 90;
            this.btAddInputFile.Text = "Add";
            this.btAddInputFile.UseVisualStyleBackColor = true;
            this.btAddInputFile.Click += new System.EventHandler(this.btAddInputFile_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 20;
            this.lbFiles.Location = new System.Drawing.Point(496, 56);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(546, 84);
            this.lbFiles.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 88;
            this.label10.Text = "Input files";
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(496, 495);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(650, 445);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 87;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 59);
            this.button1.TabIndex = 95;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 1005);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btClearList);
            this.Controls.Add(this.btAddInputFile);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbSeeking);
            this.Controls.Add(this.cbTelemetry);
            this.Controls.Add(this.cbLicensing);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.label130);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "VisioForge Video Edit SDK .Net - Main Demo X (Crossplatform)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.tabPage30.PerformLayout();
            this.tabPage48.ResumeLayout(false);
            this.tabPage48.PerformLayout();
            this.tabPage31.ResumeLayout(false);
            this.tabControl17.ResumeLayout(false);
            this.tabPage68.ResumeLayout(false);
            this.tabPage68.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            this.tabPage82.ResumeLayout(false);
            this.tabPage82.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl18.ResumeLayout(false);
            this.tabPage71.ResumeLayout(false);
            this.tabPage71.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudAmplifyAmp)).EndInit();
            this.tabPage72.ResumeLayout(false);
            this.tabPage72.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudEq0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeeking)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.OpenFileDialog OpenDialog1;
        private System.Windows.Forms.SaveFileDialog SaveDialog1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lbTransitions;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox edTransStartTime;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btAddTransition;
        private System.Windows.Forms.ComboBox cbTransitionName;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox edTransStopTime;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.FontDialog FontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl17;
        private System.Windows.Forms.TabPage tabPage68;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.TrackBar tbHue;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TrackBar tbSaturation;
        private System.Windows.Forms.CheckBox cbSepia;
        private System.Windows.Forms.CheckBox cbGreyscale;
        private System.Windows.Forms.CheckBox cbEffects;
        private System.Windows.Forms.TabControl tabControl18;
        private System.Windows.Forms.TabPage tabPage71;
        private System.Windows.Forms.TrackBar tbAudAmplifyAmp;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.CheckBox cbAudAmplifyEnabled;
        private System.Windows.Forms.TabPage tabPage72;
        private System.Windows.Forms.Label label242;
        private System.Windows.Forms.Label label241;
        private System.Windows.Forms.Label label240;
        private System.Windows.Forms.Label label239;
        private System.Windows.Forms.Label label238;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.Label label235;
        private System.Windows.Forms.Label label234;
        private System.Windows.Forms.Label label233;
        private System.Windows.Forms.TrackBar tbAudEq9;
        private System.Windows.Forms.TrackBar tbAudEq8;
        private System.Windows.Forms.TrackBar tbAudEq7;
        private System.Windows.Forms.TrackBar tbAudEq6;
        private System.Windows.Forms.TrackBar tbAudEq5;
        private System.Windows.Forms.TrackBar tbAudEq4;
        private System.Windows.Forms.TrackBar tbAudEq3;
        private System.Windows.Forms.TrackBar tbAudEq2;
        private System.Windows.Forms.TrackBar tbAudEq1;
        private System.Windows.Forms.TrackBar tbAudEq0;
        private System.Windows.Forms.CheckBox cbAudEqualizerEnabled;
        private System.Windows.Forms.CheckBox cbAudioEffectsEnabled;
        private System.Windows.Forms.TrackBar tbSeeking;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage48;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.TabPage tabPage82;
        private System.Windows.Forms.Button btSubtitlesSelectFile;
        private System.Windows.Forms.TextBox edSubtitlesFilename;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.CheckBox cbSubtitlesEnabled;
        private System.Windows.Forms.OpenFileDialog openFileDialogSubtitles;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TextBox edCropRight;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.TextBox edCropBottom;
        private System.Windows.Forms.Label label252;
        private System.Windows.Forms.TextBox edCropLeft;
        private System.Windows.Forms.Label label270;
        private System.Windows.Forms.TextBox edCropTop;
        private System.Windows.Forms.Label label272;
        private System.Windows.Forms.CheckBox cbCrop;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox cbRotate;
        private System.Windows.Forms.ComboBox cbFrameRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbOutputVideoFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.CheckBox cbFlipX;
        private System.Windows.Forms.CheckBox cbTelemetry;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox edInsertTime;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.CheckBox cbInsertAfterPreviousFile;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox edStopTime;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox edStartTime;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox cbAddFullFile;
        private System.Windows.Forms.Button btClearList;
        private System.Windows.Forms.Button btAddInputFile;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbImageOverlay;
        private System.Windows.Forms.CheckBox cbTextOverlay;
        private System.Windows.Forms.CheckBox cbDenoise;
        private System.Windows.Forms.CheckBox cbDeinterlace;
        private System.Windows.Forms.Button button1;
    }
}

