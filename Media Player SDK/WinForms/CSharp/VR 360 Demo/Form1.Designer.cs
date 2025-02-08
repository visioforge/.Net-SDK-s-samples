namespace VR_360_Demo
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
            groupBox3 = new System.Windows.Forms.GroupBox();
            rbVRCubemap = new System.Windows.Forms.RadioButton();
            rbVREquire = new System.Windows.Forms.RadioButton();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            bt360Right = new System.Windows.Forms.Button();
            bt360Left = new System.Windows.Forms.Button();
            bt360Down = new System.Windows.Forms.Button();
            bt360Up = new System.Windows.Forms.Button();
            btZoomOut = new System.Windows.Forms.Button();
            btZoomIn = new System.Windows.Forms.Button();
            tbRoll = new System.Windows.Forms.TrackBar();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBalance1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVolume1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbRoll).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(tbBalance1);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tbVolume1);
            groupBox4.Location = new System.Drawing.Point(725, 283);
            groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Size = new System.Drawing.Size(368, 206);
            groupBox4.TabIndex = 59;
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
            groupBox1.Location = new System.Drawing.Point(725, 29);
            groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Size = new System.Drawing.Size(368, 242);
            groupBox1.TabIndex = 58;
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
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(140, 915);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(397, 20);
            label1.TabIndex = 57;
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
            groupBox2.Location = new System.Drawing.Point(22, 710);
            groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Size = new System.Drawing.Size(693, 173);
            groupBox2.TabIndex = 56;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
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
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
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
            lbTime.Location = new System.Drawing.Point(510, 62);
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
            tbTimeline.Size = new System.Drawing.Size(490, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(532, 17);
            linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(184, 25);
            linkLabel1.TabIndex = 55;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Watch video tutorials!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btSelectFile
            // 
            btSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btSelectFile.Location = new System.Drawing.Point(677, 50);
            btSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(38, 44);
            btSelectFile.TabIndex = 54;
            btSelectFile.Text = "...";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // edFilename
            // 
            edFilename.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            edFilename.Location = new System.Drawing.Point(22, 54);
            edFilename.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(642, 31);
            edFilename.TabIndex = 53;
            edFilename.Text = "c:\\Samples\\360\\equirectangular4.MP4";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(17, 23);
            label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(87, 25);
            label14.TabIndex = 52;
            label14.Text = "File name";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(rbVRCubemap);
            groupBox3.Controls.Add(rbVREquire);
            groupBox3.Location = new System.Drawing.Point(725, 506);
            groupBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox3.Size = new System.Drawing.Size(368, 119);
            groupBox3.TabIndex = 63;
            groupBox3.TabStop = false;
            groupBox3.Text = "VR type";
            // 
            // rbVRCubemap
            // 
            rbVRCubemap.AutoSize = true;
            rbVRCubemap.Location = new System.Drawing.Point(212, 50);
            rbVRCubemap.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbVRCubemap.Name = "rbVRCubemap";
            rbVRCubemap.Size = new System.Drawing.Size(114, 29);
            rbVRCubemap.TabIndex = 1;
            rbVRCubemap.Text = "Cubemap";
            rbVRCubemap.UseVisualStyleBackColor = true;
            // 
            // rbVREquire
            // 
            rbVREquire.AutoSize = true;
            rbVREquire.Checked = true;
            rbVREquire.Location = new System.Drawing.Point(27, 50);
            rbVREquire.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            rbVREquire.Name = "rbVREquire";
            rbVREquire.Size = new System.Drawing.Size(159, 29);
            rbVREquire.TabIndex = 0;
            rbVREquire.TabStop = true;
            rbVREquire.Text = "Equirectangular";
            rbVREquire.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // bt360Right
            // 
            bt360Right.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Right.Location = new System.Drawing.Point(948, 679);
            bt360Right.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Right.Name = "bt360Right";
            bt360Right.Size = new System.Drawing.Size(35, 92);
            bt360Right.TabIndex = 67;
            bt360Right.Text = "R";
            bt360Right.UseVisualStyleBackColor = true;
            bt360Right.Click += bt360Right_Click;
            // 
            // bt360Left
            // 
            bt360Left.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Left.Location = new System.Drawing.Point(828, 677);
            bt360Left.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Left.Name = "bt360Left";
            bt360Left.Size = new System.Drawing.Size(35, 92);
            bt360Left.TabIndex = 66;
            bt360Left.Text = "L";
            bt360Left.UseVisualStyleBackColor = true;
            bt360Left.Click += bt360Left_Click;
            // 
            // bt360Down
            // 
            bt360Down.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Down.Location = new System.Drawing.Point(863, 750);
            bt360Down.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Down.Name = "bt360Down";
            bt360Down.Size = new System.Drawing.Size(85, 44);
            bt360Down.TabIndex = 65;
            bt360Down.Text = "Down";
            bt360Down.UseVisualStyleBackColor = true;
            bt360Down.Click += bt360Down_Click;
            // 
            // bt360Up
            // 
            bt360Up.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Up.Location = new System.Drawing.Point(863, 654);
            bt360Up.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Up.Name = "bt360Up";
            bt360Up.Size = new System.Drawing.Size(85, 44);
            bt360Up.TabIndex = 64;
            bt360Up.Text = "Up";
            bt360Up.UseVisualStyleBackColor = true;
            bt360Up.Click += bt360Up_Click;
            // 
            // btZoomOut
            // 
            btZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btZoomOut.Location = new System.Drawing.Point(910, 702);
            btZoomOut.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btZoomOut.Name = "btZoomOut";
            btZoomOut.Size = new System.Drawing.Size(38, 44);
            btZoomOut.TabIndex = 69;
            btZoomOut.Text = "-";
            btZoomOut.UseVisualStyleBackColor = true;
            btZoomOut.Click += btZoomOut_Click;
            // 
            // btZoomIn
            // 
            btZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btZoomIn.Location = new System.Drawing.Point(863, 702);
            btZoomIn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btZoomIn.Name = "btZoomIn";
            btZoomIn.Size = new System.Drawing.Size(37, 44);
            btZoomIn.TabIndex = 68;
            btZoomIn.Text = "+";
            btZoomIn.UseVisualStyleBackColor = true;
            btZoomIn.Click += btZoomIn_Click;
            // 
            // tbRoll
            // 
            tbRoll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbRoll.Location = new System.Drawing.Point(828, 806);
            tbRoll.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbRoll.Maximum = 180;
            tbRoll.Minimum = -180;
            tbRoll.Name = "tbRoll";
            tbRoll.Size = new System.Drawing.Size(155, 69);
            tbRoll.TabIndex = 70;
            tbRoll.Scroll += tbRoll_Scroll;
            // 
            // VideoView1
            // 
            VideoView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(22, 110);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(693, 588);
            VideoView1.TabIndex = 71;
            VideoView1.MouseDown += VideoView1_MouseDown;
            VideoView1.MouseMove += VideoView1_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1110, 960);
            Controls.Add(VideoView1);
            Controls.Add(tbRoll);
            Controls.Add(btZoomOut);
            Controls.Add(btZoomIn);
            Controls.Add(bt360Right);
            Controls.Add(bt360Left);
            Controls.Add(bt360Down);
            Controls.Add(bt360Up);
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
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Player SDK .Net - VR 360 Demo";
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbRoll).EndInit();
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
        private System.Windows.Forms.CheckBox cbLicensing;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbVRCubemap;
        private System.Windows.Forms.RadioButton rbVREquire;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt360Right;
        private System.Windows.Forms.Button bt360Left;
        private System.Windows.Forms.Button bt360Down;
        private System.Windows.Forms.Button bt360Up;
        private System.Windows.Forms.Button btZoomOut;
        private System.Windows.Forms.Button btZoomIn;
        private System.Windows.Forms.TrackBar tbRoll;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

