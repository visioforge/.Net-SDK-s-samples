namespace Memory_Stream_Demo
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

            _memoryStream?.Dispose();
            _memoryStream = null;

            _fileStream?.Dispose();
            _fileStream = null;

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
            cbLoop = new System.Windows.Forms.CheckBox();
            btNextFrame = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            tbSpeed = new System.Windows.Forms.TrackBar();
            label16 = new System.Windows.Forms.Label();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btSelectFile = new System.Windows.Forms.Button();
            edFilename = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox3 = new System.Windows.Forms.GroupBox();
            rbStreamTypeMemory = new System.Windows.Forms.RadioButton();
            rbSTreamTypeFile = new System.Windows.Forms.RadioButton();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(tbBalance1);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tbVolume1);
            groupBox4.Location = new System.Drawing.Point(596, 14);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Size = new System.Drawing.Size(287, 165);
            groupBox4.TabIndex = 41;
            groupBox4.TabStop = false;
            groupBox4.Text = "Audio output";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(145, 43);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 20);
            label7.TabIndex = 11;
            label7.Text = "Balance";
            // 
            // tbBalance1
            // 
            tbBalance1.BackColor = System.Drawing.SystemColors.Window;
            tbBalance1.Location = new System.Drawing.Point(149, 68);
            tbBalance1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbBalance1.Maximum = 100;
            tbBalance1.Minimum = -100;
            tbBalance1.Name = "tbBalance1";
            tbBalance1.Size = new System.Drawing.Size(113, 56);
            tbBalance1.TabIndex = 10;
            tbBalance1.Scroll += tbBalance1_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(21, 43);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(59, 20);
            label6.TabIndex = 9;
            label6.Text = "Volume";
            // 
            // tbVolume1
            // 
            tbVolume1.BackColor = System.Drawing.SystemColors.Window;
            tbVolume1.Location = new System.Drawing.Point(25, 68);
            tbVolume1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbVolume1.Maximum = 100;
            tbVolume1.Minimum = 20;
            tbVolume1.Name = "tbVolume1";
            tbVolume1.Size = new System.Drawing.Size(113, 56);
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
            groupBox1.Location = new System.Drawing.Point(596, 320);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Size = new System.Drawing.Size(287, 414);
            groupBox1.TabIndex = 40;
            groupBox1.TabStop = false;
            groupBox1.Text = "Errors and warnings";
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(141, 29);
            cbLicensing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(122, 24);
            cbLicensing.TabIndex = 4;
            cbLicensing.Text = "Licensing info";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmError
            // 
            mmError.Location = new System.Drawing.Point(8, 65);
            mmError.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmError.Size = new System.Drawing.Size(269, 334);
            mmError.TabIndex = 3;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(8, 29);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(119, 24);
            cbDebugMode.TabIndex = 2;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(111, 702);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(338, 17);
            label1.TabIndex = 39;
            label1.Text = "Much more features are shown in Main Demo!";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox2.Controls.Add(cbLoop);
            groupBox2.Controls.Add(btNextFrame);
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(tbSpeed);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(lbTime);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(16, 537);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Size = new System.Drawing.Size(555, 138);
            groupBox2.TabIndex = 38;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // cbLoop
            // 
            cbLoop.AutoSize = true;
            cbLoop.Location = new System.Drawing.Point(449, 95);
            cbLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbLoop.Name = "cbLoop";
            cbLoop.Size = new System.Drawing.Size(65, 24);
            cbLoop.TabIndex = 10;
            cbLoop.Text = "Loop";
            cbLoop.UseVisualStyleBackColor = true;
            // 
            // btNextFrame
            // 
            btNextFrame.Location = new System.Drawing.Point(332, 89);
            btNextFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btNextFrame.Name = "btNextFrame";
            btNextFrame.Size = new System.Drawing.Size(100, 35);
            btNextFrame.TabIndex = 8;
            btNextFrame.Text = "Next frame";
            btNextFrame.UseVisualStyleBackColor = true;
            btNextFrame.Click += btNextFrame_Click;
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(240, 89);
            btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(61, 35);
            btStop.TabIndex = 7;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(163, 89);
            btPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(69, 35);
            btPause.TabIndex = 6;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(73, 89);
            btResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(81, 35);
            btResume.TabIndex = 5;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(8, 89);
            btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(57, 35);
            btStart.TabIndex = 4;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new System.Drawing.Point(428, 42);
            tbSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbSpeed.Maximum = 25;
            tbSpeed.Minimum = 5;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new System.Drawing.Size(119, 56);
            tbSpeed.TabIndex = 3;
            tbSpeed.Value = 10;
            tbSpeed.Scroll += tbSpeed_Scroll;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(429, 17);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(51, 20);
            label16.TabIndex = 2;
            label16.Text = "Speed";
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(292, 42);
            lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(123, 20);
            lbTime.TabIndex = 1;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Location = new System.Drawing.Point(8, 29);
            tbTimeline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(276, 56);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(425, 14);
            linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(153, 20);
            linkLabel1.TabIndex = 37;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btSelectFile
            // 
            btSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btSelectFile.Location = new System.Drawing.Point(541, 40);
            btSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(31, 35);
            btSelectFile.TabIndex = 36;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // edFilename
            // 
            edFilename.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            edFilename.Location = new System.Drawing.Point(16, 43);
            edFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(516, 27);
            edFilename.TabIndex = 35;
            edFilename.Text = "C:\\Samples\\!video.avi";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(12, 18);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(73, 20);
            label14.TabIndex = 34;
            label14.Text = "File name";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(rbStreamTypeMemory);
            groupBox3.Controls.Add(rbSTreamTypeFile);
            groupBox3.Location = new System.Drawing.Point(596, 188);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(287, 125);
            groupBox3.TabIndex = 47;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stream type";
            // 
            // rbStreamTypeMemory
            // 
            rbStreamTypeMemory.AutoSize = true;
            rbStreamTypeMemory.Location = new System.Drawing.Point(16, 75);
            rbStreamTypeMemory.Name = "rbStreamTypeMemory";
            rbStreamTypeMemory.Size = new System.Drawing.Size(219, 24);
            rbStreamTypeMemory.TabIndex = 1;
            rbStreamTypeMemory.Text = "Load entire file into memory";
            rbStreamTypeMemory.UseVisualStyleBackColor = true;
            // 
            // rbSTreamTypeFile
            // 
            rbSTreamTypeFile.AutoSize = true;
            rbSTreamTypeFile.Checked = true;
            rbSTreamTypeFile.Location = new System.Drawing.Point(16, 32);
            rbSTreamTypeFile.Name = "rbSTreamTypeFile";
            rbSTreamTypeFile.Size = new System.Drawing.Size(128, 24);
            rbSTreamTypeFile.TabIndex = 0;
            rbSTreamTypeFile.TabStop = true;
            rbSTreamTypeFile.Text = "Use file stream";
            rbSTreamTypeFile.UseVisualStyleBackColor = true;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(16, 85);
            VideoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(556, 432);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 48;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(891, 748);
            Controls.Add(VideoView1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(linkLabel1);
            Controls.Add(btSelectFile);
            Controls.Add(edFilename);
            Controls.Add(label14);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Media Player SDK .Net - Memory Playback Demo";
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
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbStreamTypeMemory;
        private System.Windows.Forms.RadioButton rbSTreamTypeFile;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

