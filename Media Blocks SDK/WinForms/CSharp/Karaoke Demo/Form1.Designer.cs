namespace Karaoke_Demo
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
            mmError = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            tbVolume1 = new System.Windows.Forms.TrackBar();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            btSelectFile = new System.Windows.Forms.Button();
            edFilename = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            cbAudioOutputDevice = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            tbPitch = new System.Windows.Forms.TrackBar();
            lbPitch = new System.Windows.Forms.Label();
            rbZipMode = new System.Windows.Forms.RadioButton();
            rbSeparateFilesMode = new System.Windows.Forms.RadioButton();
            edAudioFilename = new System.Windows.Forms.TextBox();
            btSelectAudioFile = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPitch).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(1185, 725);
            linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(184, 25);
            linkLabel1.TabIndex = 30;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // mmError
            // 
            mmError.Location = new System.Drawing.Point(18, 602);
            mmError.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmError.Size = new System.Drawing.Size(616, 146);
            mmError.TabIndex = 29;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(489, 560);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 28;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 458);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 25);
            label6.TabIndex = 25;
            label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            tbVolume1.Location = new System.Drawing.Point(18, 489);
            tbVolume1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbVolume1.Maximum = 100;
            tbVolume1.Minimum = 20;
            tbVolume1.Name = "tbVolume1";
            tbVolume1.Size = new System.Drawing.Size(142, 69);
            tbVolume1.TabIndex = 24;
            tbVolume1.Value = 80;
            tbVolume1.Scroll += tbVolume1_Scroll;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(lbTime);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(22, 194);
            groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Size = new System.Drawing.Size(612, 172);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(300, 112);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(78, 44);
            btStop.TabIndex = 7;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(202, 112);
            btPause.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(88, 44);
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
            tbTimeline.Location = new System.Drawing.Point(10, 38);
            tbTimeline.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(345, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // btSelectFile
            // 
            btSelectFile.Location = new System.Drawing.Point(600, 90);
            btSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(38, 44);
            btSelectFile.TabIndex = 22;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(122, 96);
            edFilename.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(466, 31);
            edFilename.TabIndex = 21;
            edFilename.Text = "c:\\1.zip";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(18, 21);
            label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(115, 25);
            label14.TabIndex = 20;
            label14.Text = "Input Mode:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(670, 21);
            VideoView1.Margin = new System.Windows.Forms.Padding(2);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(699, 518);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 32;
            // 
            // cbAudioOutputDevice
            // 
            cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutputDevice.FormattingEnabled = true;
            cbAudioOutputDevice.Location = new System.Drawing.Point(18, 404);
            cbAudioOutputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioOutputDevice.Name = "cbAudioOutputDevice";
            cbAudioOutputDevice.Size = new System.Drawing.Size(616, 33);
            cbAudioOutputDevice.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(14, 376);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(119, 25);
            label5.TabIndex = 33;
            label5.Text = "Audio output";
            // 
            // tbPitch
            // 
            tbPitch.BackColor = System.Drawing.SystemColors.Window;
            tbPitch.Location = new System.Drawing.Point(180, 489);
            tbPitch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbPitch.Maximum = 200;
            tbPitch.Minimum = 50;
            tbPitch.Name = "tbPitch";
            tbPitch.Size = new System.Drawing.Size(142, 69);
            tbPitch.TabIndex = 35;
            tbPitch.Value = 100;
            tbPitch.Scroll += tbPitch_Scroll;
            // 
            // lbPitch
            // 
            lbPitch.AutoSize = true;
            lbPitch.Location = new System.Drawing.Point(180, 458);
            lbPitch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbPitch.Name = "lbPitch";
            lbPitch.Size = new System.Drawing.Size(89, 25);
            lbPitch.TabIndex = 36;
            lbPitch.Text = "Rate: 1.00";
            // 
            // rbZipMode
            // 
            rbZipMode.AutoSize = true;
            rbZipMode.Checked = true;
            rbZipMode.Location = new System.Drawing.Point(148, 21);
            rbZipMode.Name = "rbZipMode";
            rbZipMode.Size = new System.Drawing.Size(230, 29);
            rbZipMode.TabIndex = 37;
            rbZipMode.TabStop = true;
            rbZipMode.Text = "ZIP (CDG + Audio inside)";
            rbZipMode.UseVisualStyleBackColor = true;
            rbZipMode.CheckedChanged += rbInputMode_CheckedChanged;
            // 
            // rbSeparateFilesMode
            // 
            rbSeparateFilesMode.AutoSize = true;
            rbSeparateFilesMode.Location = new System.Drawing.Point(400, 21);
            rbSeparateFilesMode.Name = "rbSeparateFilesMode";
            rbSeparateFilesMode.Size = new System.Drawing.Size(209, 29);
            rbSeparateFilesMode.TabIndex = 38;
            rbSeparateFilesMode.Text = "Separate CDG + Audio";
            rbSeparateFilesMode.UseVisualStyleBackColor = true;
            rbSeparateFilesMode.CheckedChanged += rbInputMode_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 64);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 25);
            label1.TabIndex = 39;
            label1.Text = "ZIP File:";
            // 
            // edAudioFilename
            // 
            edAudioFilename.Enabled = false;
            edAudioFilename.Location = new System.Drawing.Point(122, 146);
            edAudioFilename.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edAudioFilename.Name = "edAudioFilename";
            edAudioFilename.Size = new System.Drawing.Size(466, 31);
            edAudioFilename.TabIndex = 40;
            // 
            // btSelectAudioFile
            // 
            btSelectAudioFile.Enabled = false;
            btSelectAudioFile.Location = new System.Drawing.Point(600, 140);
            btSelectAudioFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectAudioFile.Name = "btSelectAudioFile";
            btSelectAudioFile.Size = new System.Drawing.Size(38, 44);
            btSelectAudioFile.TabIndex = 41;
            btSelectAudioFile.Text = "...";
            btSelectAudioFile.UseVisualStyleBackColor = true;
            btSelectAudioFile.Click += btSelectAudioFile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 152);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 25);
            label2.TabIndex = 42;
            label2.Text = "Audio File:";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1398, 768);
            Controls.Add(label2);
            Controls.Add(btSelectAudioFile);
            Controls.Add(edAudioFilename);
            Controls.Add(label1);
            Controls.Add(rbSeparateFilesMode);
            Controls.Add(rbZipMode);
            Controls.Add(lbPitch);
            Controls.Add(tbPitch);
            Controls.Add(cbAudioOutputDevice);
            Controls.Add(label5);
            Controls.Add(VideoView1);
            Controls.Add(linkLabel1);
            Controls.Add(mmError);
            Controls.Add(cbDebugMode);
            Controls.Add(label6);
            Controls.Add(tbVolume1);
            Controls.Add(groupBox2);
            Controls.Add(btSelectFile);
            Controls.Add(edFilename);
            Controls.Add(label14);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - Karaoke Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tbVolume1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPitch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.ComboBox cbAudioOutputDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbPitch;
        private System.Windows.Forms.Label lbPitch;
        private System.Windows.Forms.RadioButton rbZipMode;
        private System.Windows.Forms.RadioButton rbSeparateFilesMode;
        private System.Windows.Forms.TextBox edAudioFilename;
        private System.Windows.Forms.Button btSelectAudioFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

