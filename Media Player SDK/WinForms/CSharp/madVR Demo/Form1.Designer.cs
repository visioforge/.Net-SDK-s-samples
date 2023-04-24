namespace madVR_Player_Demo
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
            groupBox4 = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            tbBalance1 = new System.Windows.Forms.TrackBar();
            label6 = new System.Windows.Forms.Label();
            tbVolume1 = new System.Windows.Forms.TrackBar();
            groupBox1 = new System.Windows.Forms.GroupBox();
            cbLicensing = new System.Windows.Forms.CheckBox();
            mmError = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btSelectFile = new System.Windows.Forms.Button();
            edFilename = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            Label2 = new System.Windows.Forms.Label();
            cbSourceMode = new System.Windows.Forms.ComboBox();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(tbBalance1);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tbVolume1);
            groupBox4.Location = new System.Drawing.Point(723, 281);
            groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Size = new System.Drawing.Size(368, 206);
            groupBox4.TabIndex = 33;
            groupBox4.TabStop = false;
            groupBox4.Text = "Audio output";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(182, 54);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(71, 25);
            label7.TabIndex = 11;
            label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            tbBalance1.Location = new System.Drawing.Point(187, 85);
            tbBalance1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbBalance1.Maximum = 100;
            tbBalance1.Minimum = -100;
            tbBalance1.Name = "tbBalance1";
            tbBalance1.Size = new System.Drawing.Size(142, 69);
            tbBalance1.TabIndex = 10;
            tbBalance1.Scroll += tbBalance1_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(27, 54);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 25);
            label6.TabIndex = 9;
            label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            tbVolume1.Location = new System.Drawing.Point(32, 85);
            tbVolume1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbVolume1.Maximum = 100;
            tbVolume1.Name = "tbVolume1";
            tbVolume1.Size = new System.Drawing.Size(142, 69);
            tbVolume1.TabIndex = 8;
            tbVolume1.Value = 80;
            tbVolume1.Scroll += tbVolume1_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(cbLicensing);
            groupBox1.Controls.Add(mmError);
            groupBox1.Controls.Add(cbDebugMode);
            groupBox1.Location = new System.Drawing.Point(723, 27);
            groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Size = new System.Drawing.Size(368, 242);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Errors and warnings";
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(165, 37);
            cbLicensing.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(146, 29);
            cbLicensing.TabIndex = 4;
            cbLicensing.Text = "Licensing info";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmError
            // 
            mmError.Location = new System.Drawing.Point(10, 81);
            mmError.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmError.Size = new System.Drawing.Size(346, 146);
            mmError.TabIndex = 3;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(10, 37);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 2;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(144, 776);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(397, 20);
            label1.TabIndex = 31;
            label1.Text = "Much more features are shown in Main Demo!";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(lbTime);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(21, 586);
            groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Size = new System.Drawing.Size(693, 173);
            groupBox2.TabIndex = 30;
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
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(519, 120);
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
            tbTimeline.Size = new System.Drawing.Size(664, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(530, 15);
            linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(184, 25);
            linkLabel1.TabIndex = 29;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btSelectFile
            // 
            btSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btSelectFile.Location = new System.Drawing.Point(675, 48);
            btSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(38, 44);
            btSelectFile.TabIndex = 28;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // edFilename
            // 
            edFilename.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            edFilename.Location = new System.Drawing.Point(20, 52);
            edFilename.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(642, 31);
            edFilename.TabIndex = 27;
            edFilename.Text = "C:\\samples\\!video.mp4";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(15, 21);
            label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(87, 25);
            label14.TabIndex = 26;
            label14.Text = "File name";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Label2
            // 
            Label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(718, 506);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(121, 25);
            Label2.TabIndex = 47;
            Label2.Text = "Decode using";
            // 
            // cbSourceMode
            // 
            cbSourceMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSourceMode.FormattingEnabled = true;
            cbSourceMode.Items.AddRange(new object[] { "LAV", "DirectShow (System codecs)", "FFMPEG", "VLC" });
            cbSourceMode.Location = new System.Drawing.Point(723, 535);
            cbSourceMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbSourceMode.Name = "cbSourceMode";
            cbSourceMode.Size = new System.Drawing.Size(366, 33);
            cbSourceMode.TabIndex = 51;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(20, 108);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(694, 460);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 90;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1110, 817);
            Controls.Add(VideoView1);
            Controls.Add(cbSourceMode);
            Controls.Add(Label2);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(linkLabel1);
            Controls.Add(btSelectFile);
            Controls.Add(edFilename);
            Controls.Add(label14);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Player SDK .Net - Simple Video Player Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbBalance1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cbSourceMode;
        private System.Windows.Forms.CheckBox cbLicensing;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

