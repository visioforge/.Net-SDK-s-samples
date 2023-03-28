namespace Video_From_Images
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

            _mp4SettingsDialog?.Dispose();
            _mp4SettingsDialog = null;

            _mp4HWSettingsDialog?.Dispose();
            _mp4HWSettingsDialog = null;

            _webmSettingsDialog?.Dispose();
            _webmSettingsDialog = null;

            _mp3SettingsDialog?.Dispose();
            _mp3SettingsDialog = null;

            _aviSettingsDialog?.Dispose();
            _aviSettingsDialog = null;

            _wmvSettingsDialog?.Dispose();
            _wmvSettingsDialog = null;

            _gifSettingsDialog?.Dispose();
            _gifSettingsDialog = null;

            _ffmpegEXESettingsDialog?.Dispose();
            _ffmpegEXESettingsDialog = null;

            _ffmpegSettingsDialog?.Dispose();
            _ffmpegSettingsDialog = null;

            _dvSettingsDialog?.Dispose();
            _dvSettingsDialog = null;

            _loadedImage?.Dispose();
            _loadedImage = null;

            VideoEdit1?.Dispose();
            VideoEdit1 = null;

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
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            rbPreview = new System.Windows.Forms.RadioButton();
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            ProgressBar1 = new System.Windows.Forms.ProgressBar();
            rbConvert = new System.Windows.Forms.RadioButton();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            label6 = new System.Windows.Forms.Label();
            btSelectImagesFolder = new System.Windows.Forms.Button();
            edImagesFolder = new System.Windows.Forms.TextBox();
            rbImagesFolder = new System.Windows.Forms.RadioButton();
            rbImagesPredefined = new System.Windows.Forms.RadioButton();
            cbOutputFormat = new System.Windows.Forms.ComboBox();
            lbInfo = new System.Windows.Forms.Label();
            btConfigure = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            btSelectOutput = new System.Windows.Forms.Button();
            edOutput = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cbFrameRate = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            edHeight = new System.Windows.Forms.TextBox();
            edWidth = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            cbResize = new System.Windows.Forms.CheckBox();
            tabPage5 = new System.Windows.Forms.TabPage();
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
            label4 = new System.Windows.Forms.Label();
            btTextLogoAdd = new System.Windows.Forms.Button();
            btLogoRemove = new System.Windows.Forms.Button();
            btLogoEdit = new System.Windows.Forms.Button();
            lbLogos = new System.Windows.Forms.ListBox();
            btImageLogoAdd = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            cbLicensing = new System.Windows.Forms.CheckBox();
            mmLog = new System.Windows.Forms.TextBox();
            label120 = new System.Windows.Forms.Label();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            fontDialog1 = new System.Windows.Forms.FontDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            linkLabelDecoders = new System.Windows.Forms.LinkLabel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(1142, 23);
            linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(130, 25);
            linkLabel1.TabIndex = 90;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch tutorials";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // rbPreview
            // 
            rbPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbPreview.AutoSize = true;
            rbPreview.Checked = true;
            rbPreview.Location = new System.Drawing.Point(757, 602);
            rbPreview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbPreview.Name = "rbPreview";
            rbPreview.Size = new System.Drawing.Size(97, 29);
            rbPreview.TabIndex = 86;
            rbPreview.TabStop = true;
            rbPreview.Text = "Preview";
            rbPreview.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(1175, 592);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(97, 44);
            btStop.TabIndex = 85;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(1063, 592);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(97, 44);
            btStart.TabIndex = 84;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(575, 23);
            label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(278, 25);
            label10.TabIndex = 80;
            label10.Text = "Input images located in resources";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ProgressBar1.Location = new System.Drawing.Point(580, 648);
            ProgressBar1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new System.Drawing.Size(692, 44);
            ProgressBar1.TabIndex = 79;
            // 
            // rbConvert
            // 
            rbConvert.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbConvert.AutoSize = true;
            rbConvert.Location = new System.Drawing.Point(580, 602);
            rbConvert.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbConvert.Name = "rbConvert";
            rbConvert.Size = new System.Drawing.Size(148, 29);
            rbConvert.TabIndex = 78;
            rbConvert.Text = "Convert video";
            rbConvert.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(20, 23);
            tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(550, 773);
            tabControl1.TabIndex = 92;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(btSelectImagesFolder);
            tabPage1.Controls.Add(edImagesFolder);
            tabPage1.Controls.Add(rbImagesFolder);
            tabPage1.Controls.Add(rbImagesPredefined);
            tabPage1.Controls.Add(cbOutputFormat);
            tabPage1.Controls.Add(lbInfo);
            tabPage1.Controls.Add(btConfigure);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(btSelectOutput);
            tabPage1.Controls.Add(edOutput);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cbFrameRate);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(edHeight);
            tabPage1.Controls.Add(edWidth);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(cbResize);
            tabPage1.Location = new System.Drawing.Point(4, 34);
            tabPage1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage1.Size = new System.Drawing.Size(542, 735);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Output";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(40, 298);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(344, 25);
            label6.TabIndex = 128;
            label6.Text = "Resolution from resize option will be used";
            // 
            // btSelectImagesFolder
            // 
            btSelectImagesFolder.Location = new System.Drawing.Point(465, 250);
            btSelectImagesFolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectImagesFolder.Name = "btSelectImagesFolder";
            btSelectImagesFolder.Size = new System.Drawing.Size(43, 44);
            btSelectImagesFolder.TabIndex = 127;
            btSelectImagesFolder.Text = "...";
            btSelectImagesFolder.UseVisualStyleBackColor = true;
            btSelectImagesFolder.Click += btSelectImagesFolder_Click;
            // 
            // edImagesFolder
            // 
            edImagesFolder.Location = new System.Drawing.Point(45, 254);
            edImagesFolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edImagesFolder.Name = "edImagesFolder";
            edImagesFolder.Size = new System.Drawing.Size(407, 31);
            edImagesFolder.TabIndex = 126;
            edImagesFolder.Text = "c:\\Samples\\pics_test\\";
            // 
            // rbImagesFolder
            // 
            rbImagesFolder.AutoSize = true;
            rbImagesFolder.Location = new System.Drawing.Point(27, 210);
            rbImagesFolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbImagesFolder.Name = "rbImagesFolder";
            rbImagesFolder.Size = new System.Drawing.Size(191, 29);
            rbImagesFolder.TabIndex = 125;
            rbImagesFolder.Text = "Images from folder";
            rbImagesFolder.UseVisualStyleBackColor = true;
            // 
            // rbImagesPredefined
            // 
            rbImagesPredefined.AutoSize = true;
            rbImagesPredefined.Checked = true;
            rbImagesPredefined.Location = new System.Drawing.Point(27, 165);
            rbImagesPredefined.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbImagesPredefined.Name = "rbImagesPredefined";
            rbImagesPredefined.Size = new System.Drawing.Size(204, 29);
            rbImagesPredefined.TabIndex = 124;
            rbImagesPredefined.TabStop = true;
            rbImagesPredefined.Text = "Predefined image set";
            rbImagesPredefined.UseVisualStyleBackColor = true;
            // 
            // cbOutputFormat
            // 
            cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputFormat.FormattingEnabled = true;
            cbOutputFormat.Items.AddRange(new object[] { "AVI", "MKV (Matroska)", "WMV (Windows Media Video)", "DV", "WebM", "FFMPEG (DLL)", "FFMPEG (external exe) (BETA)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "Encrypted video" });
            cbOutputFormat.Location = new System.Drawing.Point(27, 423);
            cbOutputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbOutputFormat.Name = "cbOutputFormat";
            cbOutputFormat.Size = new System.Drawing.Size(479, 33);
            cbOutputFormat.TabIndex = 123;
            cbOutputFormat.SelectedIndexChanged += cbOutputFormat_SelectedIndexChanged;
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new System.Drawing.Point(22, 485);
            lbInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new System.Drawing.Size(454, 25);
            lbInfo.TabIndex = 62;
            lbInfo.Text = "You can use dialog or code to configure format settings";
            // 
            // btConfigure
            // 
            btConfigure.Location = new System.Drawing.Point(27, 527);
            btConfigure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btConfigure.Name = "btConfigure";
            btConfigure.Size = new System.Drawing.Size(102, 44);
            btConfigure.TabIndex = 61;
            btConfigure.Text = "Configure";
            btConfigure.UseVisualStyleBackColor = true;
            btConfigure.Click += btConfigure_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(22, 392);
            label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(69, 25);
            label9.TabIndex = 59;
            label9.Text = "Format";
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(465, 663);
            btSelectOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(43, 44);
            btSelectOutput.TabIndex = 58;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // edOutput
            // 
            edOutput.Location = new System.Drawing.Point(123, 667);
            edOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edOutput.Name = "edOutput";
            edOutput.Size = new System.Drawing.Size(329, 31);
            edOutput.TabIndex = 57;
            edOutput.Text = "c:\\vf\\video_edit_output.avi";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(22, 673);
            label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(97, 25);
            label15.TabIndex = 56;
            label15.Text = "Output file";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 610);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(370, 25);
            label1.TabIndex = 55;
            label1.Text = "More output formats available in Main Demo";
            // 
            // cbFrameRate
            // 
            cbFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFrameRate.FormattingEnabled = true;
            cbFrameRate.Items.AddRange(new object[] { "1", "2", "5", "10", "12", "15", "20", "25", "30" });
            cbFrameRate.Location = new System.Drawing.Point(148, 85);
            cbFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFrameRate.Name = "cbFrameRate";
            cbFrameRate.Size = new System.Drawing.Size(77, 33);
            cbFrameRate.TabIndex = 51;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(22, 92);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 25);
            label3.TabIndex = 50;
            label3.Text = "Frame rate:";
            // 
            // edHeight
            // 
            edHeight.Location = new System.Drawing.Point(268, 27);
            edHeight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edHeight.Name = "edHeight";
            edHeight.Size = new System.Drawing.Size(77, 31);
            edHeight.TabIndex = 49;
            edHeight.Text = "576";
            // 
            // edWidth
            // 
            edWidth.Location = new System.Drawing.Point(148, 27);
            edWidth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edWidth.Name = "edWidth";
            edWidth.Size = new System.Drawing.Size(77, 31);
            edWidth.TabIndex = 48;
            edWidth.Text = "768";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(238, 33);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 25);
            label2.TabIndex = 47;
            label2.Text = "x";
            // 
            // cbResize
            // 
            cbResize.AutoSize = true;
            cbResize.Location = new System.Drawing.Point(27, 33);
            cbResize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbResize.Name = "cbResize";
            cbResize.Size = new System.Drawing.Size(86, 29);
            cbResize.TabIndex = 46;
            cbResize.Text = "Resize";
            cbResize.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(cbFlipY);
            tabPage5.Controls.Add(cbFlipX);
            tabPage5.Controls.Add(cbInvert);
            tabPage5.Controls.Add(cbGreyscale);
            tabPage5.Controls.Add(label201);
            tabPage5.Controls.Add(tbDarkness);
            tabPage5.Controls.Add(label200);
            tabPage5.Controls.Add(label199);
            tabPage5.Controls.Add(label198);
            tabPage5.Controls.Add(tbContrast);
            tabPage5.Controls.Add(tbLightness);
            tabPage5.Controls.Add(tbSaturation);
            tabPage5.Controls.Add(label4);
            tabPage5.Controls.Add(btTextLogoAdd);
            tabPage5.Controls.Add(btLogoRemove);
            tabPage5.Controls.Add(btLogoEdit);
            tabPage5.Controls.Add(lbLogos);
            tabPage5.Controls.Add(btImageLogoAdd);
            tabPage5.Controls.Add(label5);
            tabPage5.Location = new System.Drawing.Point(4, 34);
            tabPage5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage5.Size = new System.Drawing.Size(542, 735);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Video processing";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // cbFlipY
            // 
            cbFlipY.AutoSize = true;
            cbFlipY.Location = new System.Drawing.Point(367, 554);
            cbFlipY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFlipY.Name = "cbFlipY";
            cbFlipY.Size = new System.Drawing.Size(81, 29);
            cbFlipY.TabIndex = 123;
            cbFlipY.Text = "Flip Y";
            cbFlipY.UseVisualStyleBackColor = true;
            cbFlipY.CheckedChanged += cbFlipY_CheckedChanged;
            // 
            // cbFlipX
            // 
            cbFlipX.AutoSize = true;
            cbFlipX.Location = new System.Drawing.Point(267, 554);
            cbFlipX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbFlipX.Name = "cbFlipX";
            cbFlipX.Size = new System.Drawing.Size(82, 29);
            cbFlipX.TabIndex = 122;
            cbFlipX.Text = "Flip X";
            cbFlipX.UseVisualStyleBackColor = true;
            cbFlipX.CheckedChanged += cbFlipX_CheckedChanged;
            // 
            // cbInvert
            // 
            cbInvert.AutoSize = true;
            cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cbInvert.Location = new System.Drawing.Point(167, 554);
            cbInvert.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbInvert.Name = "cbInvert";
            cbInvert.Size = new System.Drawing.Size(83, 29);
            cbInvert.TabIndex = 121;
            cbInvert.Text = "Invert";
            cbInvert.UseVisualStyleBackColor = true;
            cbInvert.CheckedChanged += cbInvert_CheckedChanged;
            // 
            // cbGreyscale
            // 
            cbGreyscale.AutoSize = true;
            cbGreyscale.Location = new System.Drawing.Point(33, 554);
            cbGreyscale.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbGreyscale.Name = "cbGreyscale";
            cbGreyscale.Size = new System.Drawing.Size(112, 29);
            cbGreyscale.TabIndex = 120;
            cbGreyscale.Text = "Greyscale";
            cbGreyscale.UseVisualStyleBackColor = true;
            cbGreyscale.CheckedChanged += cbGreyscale_CheckedChanged;
            // 
            // label201
            // 
            label201.AutoSize = true;
            label201.Location = new System.Drawing.Point(253, 419);
            label201.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label201.Name = "label201";
            label201.Size = new System.Drawing.Size(84, 25);
            label201.TabIndex = 119;
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
            tbDarkness.TabIndex = 118;
            tbDarkness.Scroll += tbDarkness_Scroll;
            // 
            // label200
            // 
            label200.AutoSize = true;
            label200.Location = new System.Drawing.Point(27, 419);
            label200.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label200.Name = "label200";
            label200.Size = new System.Drawing.Size(79, 25);
            label200.TabIndex = 117;
            label200.Text = "Contrast";
            // 
            // label199
            // 
            label199.AutoSize = true;
            label199.Location = new System.Drawing.Point(253, 319);
            label199.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label199.Name = "label199";
            label199.Size = new System.Drawing.Size(93, 25);
            label199.TabIndex = 116;
            label199.Text = "Saturation";
            // 
            // label198
            // 
            label198.AutoSize = true;
            label198.Location = new System.Drawing.Point(27, 319);
            label198.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label198.Name = "label198";
            label198.Size = new System.Drawing.Size(86, 25);
            label198.TabIndex = 115;
            label198.Text = "Lightness";
            // 
            // tbContrast
            // 
            tbContrast.BackColor = System.Drawing.SystemColors.Window;
            tbContrast.Location = new System.Drawing.Point(23, 456);
            tbContrast.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbContrast.Maximum = 255;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new System.Drawing.Size(217, 69);
            tbContrast.TabIndex = 114;
            tbContrast.Scroll += tbContrast_Scroll;
            // 
            // tbLightness
            // 
            tbLightness.BackColor = System.Drawing.SystemColors.Window;
            tbLightness.Location = new System.Drawing.Point(23, 348);
            tbLightness.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbLightness.Maximum = 255;
            tbLightness.Name = "tbLightness";
            tbLightness.Size = new System.Drawing.Size(217, 69);
            tbLightness.TabIndex = 113;
            tbLightness.Scroll += tbLightness_Scroll;
            // 
            // tbSaturation
            // 
            tbSaturation.BackColor = System.Drawing.SystemColors.Window;
            tbSaturation.Location = new System.Drawing.Point(253, 348);
            tbSaturation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbSaturation.Maximum = 255;
            tbSaturation.Name = "tbSaturation";
            tbSaturation.Size = new System.Drawing.Size(217, 69);
            tbSaturation.TabIndex = 112;
            tbSaturation.Value = 255;
            tbSaturation.Scroll += tbSaturation_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 23);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(158, 25);
            label4.TabIndex = 111;
            label4.Text = "Text / image logos";
            // 
            // btTextLogoAdd
            // 
            btTextLogoAdd.Location = new System.Drawing.Point(183, 248);
            btTextLogoAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btTextLogoAdd.Name = "btTextLogoAdd";
            btTextLogoAdd.Size = new System.Drawing.Size(142, 44);
            btTextLogoAdd.TabIndex = 110;
            btTextLogoAdd.Text = "Add text logo";
            btTextLogoAdd.UseVisualStyleBackColor = true;
            btTextLogoAdd.Click += btTextLogoAdd_Click;
            // 
            // btLogoRemove
            // 
            btLogoRemove.Location = new System.Drawing.Point(433, 248);
            btLogoRemove.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btLogoRemove.Name = "btLogoRemove";
            btLogoRemove.Size = new System.Drawing.Size(83, 44);
            btLogoRemove.TabIndex = 109;
            btLogoRemove.Text = "Remove";
            btLogoRemove.UseVisualStyleBackColor = true;
            btLogoRemove.Click += btLogoRemove_Click;
            // 
            // btLogoEdit
            // 
            btLogoEdit.Location = new System.Drawing.Point(340, 248);
            btLogoEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btLogoEdit.Name = "btLogoEdit";
            btLogoEdit.Size = new System.Drawing.Size(83, 44);
            btLogoEdit.TabIndex = 108;
            btLogoEdit.Text = "Edit";
            btLogoEdit.UseVisualStyleBackColor = true;
            btLogoEdit.Click += btLogoEdit_Click;
            // 
            // lbLogos
            // 
            lbLogos.FormattingEnabled = true;
            lbLogos.ItemHeight = 25;
            lbLogos.Location = new System.Drawing.Point(23, 54);
            lbLogos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lbLogos.Name = "lbLogos";
            lbLogos.Size = new System.Drawing.Size(494, 179);
            lbLogos.TabIndex = 107;
            // 
            // btImageLogoAdd
            // 
            btImageLogoAdd.Location = new System.Drawing.Point(23, 248);
            btImageLogoAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btImageLogoAdd.Name = "btImageLogoAdd";
            btImageLogoAdd.Size = new System.Drawing.Size(150, 44);
            btImageLogoAdd.TabIndex = 106;
            btImageLogoAdd.Text = "Add image logo";
            btImageLogoAdd.UseVisualStyleBackColor = true;
            btImageLogoAdd.Click += btImageLogoAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(67, 654);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(403, 25);
            label5.TabIndex = 105;
            label5.Text = "More effects and settings available in Main Demo";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbLicensing);
            tabPage2.Controls.Add(mmLog);
            tabPage2.Controls.Add(label120);
            tabPage2.Controls.Add(cbDebugMode);
            tabPage2.Location = new System.Drawing.Point(4, 34);
            tabPage2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabPage2.Size = new System.Drawing.Size(542, 735);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Log";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(182, 31);
            cbLicensing.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(146, 29);
            cbLicensing.TabIndex = 97;
            cbLicensing.Text = "Licensing info";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(27, 119);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.Size = new System.Drawing.Size(489, 577);
            mmLog.TabIndex = 96;
            // 
            // label120
            // 
            label120.AutoSize = true;
            label120.Location = new System.Drawing.Point(22, 88);
            label120.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label120.Name = "label120";
            label120.Size = new System.Drawing.Size(169, 25);
            label120.TabIndex = 95;
            label120.Text = "Errors and warnings";
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(27, 31);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 94;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // OpenDialog1
            // 
            OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // fontDialog1
            // 
            fontDialog1.Color = System.Drawing.Color.White;
            fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            fontDialog1.FontMustExist = true;
            fontDialog1.ShowColor = true;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(580, 65);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(690, 502);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 93;
            // 
            // linkLabelDecoders
            // 
            linkLabelDecoders.AutoSize = true;
            linkLabelDecoders.Location = new System.Drawing.Point(658, 767);
            linkLabelDecoders.Name = "linkLabelDecoders";
            linkLabelDecoders.Size = new System.Drawing.Size(546, 25);
            linkLabelDecoders.TabIndex = 173;
            linkLabelDecoders.TabStop = true;
            linkLabelDecoders.Text = "[NuGet only] Install decoders if you can see errors while adding files";
            linkLabelDecoders.LinkClicked += linkLabelDecoders_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1290, 808);
            Controls.Add(linkLabelDecoders);
            Controls.Add(VideoView1);
            Controls.Add(tabControl1);
            Controls.Add(linkLabel1);
            Controls.Add(rbPreview);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(label10);
            Controls.Add(ProgressBar1);
            Controls.Add(rbConvert);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "VisioForge Video Edit SDK .Net - Video From Images In Memory";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbDarkness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSaturation).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton rbPreview;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.RadioButton rbConvert;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbFrameRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenDialog1;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btConfigure;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.CheckBox cbDebugMode;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btTextLogoAdd;
        private System.Windows.Forms.Button btLogoRemove;
        private System.Windows.Forms.Button btLogoEdit;
        private System.Windows.Forms.ListBox lbLogos;
        private System.Windows.Forms.Button btImageLogoAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbImagesFolder;
        private System.Windows.Forms.RadioButton rbImagesPredefined;
        private System.Windows.Forms.Button btSelectImagesFolder;
        private System.Windows.Forms.TextBox edImagesFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label6;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.LinkLabel linkLabelDecoders;
    }
}

