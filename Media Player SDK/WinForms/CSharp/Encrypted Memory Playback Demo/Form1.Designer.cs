namespace Encrypted_Memory_Playback_Demo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rbAudioFile = new System.Windows.Forms.RadioButton();
            this.rbVideoWithoutAudio = new System.Windows.Forms.RadioButton();
            this.rbVideoWithAudio = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBalance1 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOpenEncDec = new System.Windows.Forms.Button();
            this.cbLicensing = new System.Windows.Forms.CheckBox();
            this.mmError = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edFilename = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.edKey = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // rbAudioFile
            // 
            this.rbAudioFile.AutoSize = true;
            this.rbAudioFile.Location = new System.Drawing.Point(427, 84);
            this.rbAudioFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAudioFile.Name = "rbAudioFile";
            this.rbAudioFile.Size = new System.Drawing.Size(99, 24);
            this.rbAudioFile.TabIndex = 60;
            this.rbAudioFile.Text = "Audio file";
            this.rbAudioFile.UseVisualStyleBackColor = true;
            // 
            // rbVideoWithoutAudio
            // 
            this.rbVideoWithoutAudio.AutoSize = true;
            this.rbVideoWithoutAudio.Location = new System.Drawing.Point(208, 84);
            this.rbVideoWithoutAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoWithoutAudio.Name = "rbVideoWithoutAudio";
            this.rbVideoWithoutAudio.Size = new System.Drawing.Size(207, 24);
            this.rbVideoWithoutAudio.TabIndex = 59;
            this.rbVideoWithoutAudio.Text = "Video file (without audio)";
            this.rbVideoWithoutAudio.UseVisualStyleBackColor = true;
            // 
            // rbVideoWithAudio
            // 
            this.rbVideoWithAudio.AutoSize = true;
            this.rbVideoWithAudio.Checked = true;
            this.rbVideoWithAudio.Location = new System.Drawing.Point(16, 84);
            this.rbVideoWithAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVideoWithAudio.Name = "rbVideoWithAudio";
            this.rbVideoWithAudio.Size = new System.Drawing.Size(184, 24);
            this.rbVideoWithAudio.TabIndex = 58;
            this.rbVideoWithAudio.TabStop = true;
            this.rbVideoWithAudio.Text = "Video file (with audio)";
            this.rbVideoWithAudio.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbBalance1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbVolume1);
            this.groupBox4.Location = new System.Drawing.Point(668, 118);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(322, 165);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio output";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            this.tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            this.tbBalance1.Location = new System.Drawing.Point(168, 68);
            this.tbBalance1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBalance1.Maximum = 100;
            this.tbBalance1.Minimum = -100;
            this.tbBalance1.Name = "tbBalance1";
            this.tbBalance1.Size = new System.Drawing.Size(128, 69);
            this.tbBalance1.TabIndex = 10;
            this.tbBalance1.Scroll += new System.EventHandler(this.tbBalance1_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            this.tbVolume1.Location = new System.Drawing.Point(28, 68);
            this.tbVolume1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume1.Maximum = 100;
            this.tbVolume1.Minimum = 20;
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(128, 69);
            this.tbVolume1.TabIndex = 8;
            this.tbVolume1.Value = 80;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btOpenEncDec);
            this.groupBox1.Controls.Add(this.cbLicensing);
            this.groupBox1.Controls.Add(this.mmError);
            this.groupBox1.Controls.Add(this.cbDebugMode);
            this.groupBox1.Location = new System.Drawing.Point(668, 315);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(322, 445);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Errors and warnings";
            // 
            // btOpenEncDec
            // 
            this.btOpenEncDec.Location = new System.Drawing.Point(9, 313);
            this.btOpenEncDec.Name = "btOpenEncDec";
            this.btOpenEncDec.Size = new System.Drawing.Size(313, 74);
            this.btOpenEncDec.TabIndex = 65;
            this.btOpenEncDec.Text = "Open Encryptor/Decryptor window";
            this.btOpenEncDec.UseVisualStyleBackColor = true;
            this.btOpenEncDec.Click += new System.EventHandler(this.btOpenEncDec_Click);
            // 
            // cbLicensing
            // 
            this.cbLicensing.AutoSize = true;
            this.cbLicensing.Location = new System.Drawing.Point(159, 29);
            this.cbLicensing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLicensing.Name = "cbLicensing";
            this.cbLicensing.Size = new System.Drawing.Size(132, 24);
            this.cbLicensing.TabIndex = 4;
            this.cbLicensing.Text = "Licensing info";
            this.cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmError
            // 
            this.mmError.Location = new System.Drawing.Point(9, 65);
            this.mmError.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mmError.Multiline = true;
            this.mmError.Name = "mmError";
            this.mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmError.Size = new System.Drawing.Size(302, 235);
            this.mmError.TabIndex = 3;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(9, 29);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(127, 24);
            this.cbDebugMode.TabIndex = 2;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 791);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(785, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Demo to play encrypted files created using VisioForge.Core.VideoEncryption.VideoE" +
    "ncryptor";
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
            this.groupBox2.Location = new System.Drawing.Point(16, 622);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(624, 138);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(270, 89);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(69, 35);
            this.btStop.TabIndex = 7;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(183, 89);
            this.btPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(78, 35);
            this.btPause.TabIndex = 6;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(82, 89);
            this.btResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(92, 35);
            this.btResume.TabIndex = 5;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(9, 89);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(64, 35);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(482, 42);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSpeed.Maximum = 25;
            this.tbSpeed.Minimum = 5;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(134, 69);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(483, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Speed";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(328, 42);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(137, 20);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(9, 29);
            this.tbTimeline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(310, 69);
            this.tbTimeline.TabIndex = 0;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(476, 10);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(160, 20);
            this.linkLabel1.TabIndex = 53;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Watch video tutorials!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(607, 36);
            this.btSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(34, 35);
            this.btSelectFile.TabIndex = 52;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edFilename
            // 
            this.edFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFilename.Location = new System.Drawing.Point(16, 39);
            this.edFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(580, 26);
            this.edFilename.TabIndex = 51;
            this.edFilename.Text = "C:\\Samples\\!video.avi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 14);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 50;
            this.label14.Text = "File name";
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(16, 118);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(626, 480);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 62;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(673, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Key";
            // 
            // edKey
            // 
            this.edKey.Location = new System.Drawing.Point(677, 36);
            this.edKey.Name = "edKey";
            this.edKey.Size = new System.Drawing.Size(313, 26);
            this.edKey.TabIndex = 64;
            this.edKey.Text = "1234554321123450";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 837);
            this.Controls.Add(this.edKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.rbAudioFile);
            this.Controls.Add(this.rbVideoWithoutAudio);
            this.Controls.Add(this.rbVideoWithAudio);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilename);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net - Encrypted (New) Playback Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBalance1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbAudioFile;
        private System.Windows.Forms.RadioButton rbVideoWithoutAudio;
        private System.Windows.Forms.RadioButton rbVideoWithAudio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbBalance1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label14;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edKey;
        private System.Windows.Forms.Button btOpenEncDec;
    }
}
