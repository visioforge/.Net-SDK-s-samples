namespace Video_Mixer_Player
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            label1 = new System.Windows.Forms.Label();
            btAddFile = new System.Windows.Forms.Button();
            btRemoveFile = new System.Windows.Forms.Button();
            edBottom = new System.Windows.Forms.TextBox();
            label42 = new System.Windows.Forms.Label();
            edRight = new System.Windows.Forms.TextBox();
            label40 = new System.Windows.Forms.Label();
            edTop = new System.Windows.Forms.TextBox();
            label26 = new System.Windows.Forms.Label();
            edLeft = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            edHeight = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            edWidth = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btStop = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            btResume = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            lbTimeline = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            tmPosition = new System.Windows.Forms.Timer(components);
            lbSourceFiles = new System.Windows.Forms.ListBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = System.Drawing.Color.Black;
            videoView1.Location = new System.Drawing.Point(550, 20);
            videoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            videoView1.Name = "videoView1";
            videoView1.Size = new System.Drawing.Size(646, 543);
            videoView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 25);
            label1.TabIndex = 1;
            label1.Text = "Source files";
            // 
            // btAddFile
            // 
            btAddFile.Location = new System.Drawing.Point(17, 187);
            btAddFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btAddFile.Name = "btAddFile";
            btAddFile.Size = new System.Drawing.Size(107, 38);
            btAddFile.TabIndex = 3;
            btAddFile.Text = "Add";
            btAddFile.UseVisualStyleBackColor = true;
            btAddFile.Click += btAddFile_Click;
            // 
            // btRemoveFile
            // 
            btRemoveFile.Location = new System.Drawing.Point(133, 187);
            btRemoveFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btRemoveFile.Name = "btRemoveFile";
            btRemoveFile.Size = new System.Drawing.Size(107, 38);
            btRemoveFile.TabIndex = 4;
            btRemoveFile.Text = "Remove";
            btRemoveFile.UseVisualStyleBackColor = true;
            // 
            // edBottom
            // 
            edBottom.Location = new System.Drawing.Point(365, 397);
            edBottom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edBottom.Name = "edBottom";
            edBottom.Size = new System.Drawing.Size(71, 31);
            edBottom.TabIndex = 47;
            edBottom.Text = "480";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(294, 404);
            label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(72, 25);
            label42.TabIndex = 46;
            label42.Text = "Bottom";
            // 
            // edRight
            // 
            edRight.Location = new System.Drawing.Point(172, 397);
            edRight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edRight.Name = "edRight";
            edRight.Size = new System.Drawing.Size(71, 31);
            edRight.TabIndex = 45;
            edRight.Text = "640";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(104, 404);
            label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(54, 25);
            label40.TabIndex = 44;
            label40.Text = "Right";
            // 
            // edTop
            // 
            edTop.Location = new System.Drawing.Point(365, 321);
            edTop.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edTop.Name = "edTop";
            edTop.Size = new System.Drawing.Size(71, 31);
            edTop.TabIndex = 43;
            edTop.Text = "0";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label26.Location = new System.Drawing.Point(294, 327);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(37, 20);
            label26.TabIndex = 42;
            label26.Text = "Top";
            // 
            // edLeft
            // 
            edLeft.Location = new System.Drawing.Point(172, 321);
            edLeft.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edLeft.Name = "edLeft";
            edLeft.Size = new System.Drawing.Size(71, 31);
            edLeft.TabIndex = 41;
            edLeft.Text = "0";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label24.Location = new System.Drawing.Point(104, 327);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(38, 20);
            label24.TabIndex = 40;
            label24.Text = "Left";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(59, 261);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(446, 25);
            label2.TabIndex = 48;
            label2.Text = "File position (used during adding and during playback)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(189, 474);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(152, 25);
            label3.TabIndex = 49;
            label3.Text = "Output video size";
            // 
            // edHeight
            // 
            edHeight.Location = new System.Drawing.Point(365, 529);
            edHeight.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edHeight.Name = "edHeight";
            edHeight.Size = new System.Drawing.Size(71, 31);
            edHeight.TabIndex = 53;
            edHeight.Text = "1080";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(294, 536);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 25);
            label4.TabIndex = 52;
            label4.Text = "Height";
            // 
            // edWidth
            // 
            edWidth.Location = new System.Drawing.Point(172, 529);
            edWidth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            edWidth.Name = "edWidth";
            edWidth.Size = new System.Drawing.Size(71, 31);
            edWidth.TabIndex = 51;
            edWidth.Text = "1920";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(104, 536);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 25);
            label5.TabIndex = 50;
            label5.Text = "Width";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btStop);
            groupBox2.Controls.Add(btPause);
            groupBox2.Controls.Add(btResume);
            groupBox2.Controls.Add(btStart);
            groupBox2.Controls.Add(lbTimeline);
            groupBox2.Controls.Add(tbTimeline);
            groupBox2.Location = new System.Drawing.Point(550, 575);
            groupBox2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            groupBox2.Size = new System.Drawing.Size(646, 173);
            groupBox2.TabIndex = 54;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btStop
            // 
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStop.Location = new System.Drawing.Point(300, 113);
            btStop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(76, 43);
            btStop.TabIndex = 7;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            // 
            // btPause
            // 
            btPause.Location = new System.Drawing.Point(204, 113);
            btPause.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(86, 43);
            btPause.TabIndex = 6;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            // 
            // btResume
            // 
            btResume.Location = new System.Drawing.Point(91, 113);
            btResume.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(103, 43);
            btResume.TabIndex = 5;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(10, 113);
            btStart.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(71, 43);
            btStart.TabIndex = 4;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // lbTimeline
            // 
            lbTimeline.AutoSize = true;
            lbTimeline.Location = new System.Drawing.Point(477, 57);
            lbTimeline.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lbTimeline.Name = "lbTimeline";
            lbTimeline.Size = new System.Drawing.Size(155, 25);
            lbTimeline.TabIndex = 1;
            lbTimeline.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Location = new System.Drawing.Point(10, 37);
            tbTimeline.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(456, 69);
            tbTimeline.TabIndex = 0;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // tmPosition
            // 
            tmPosition.Interval = 500;
            tmPosition.Tick += tmPosition_Tick;
            // 
            // lbSourceFiles
            // 
            lbSourceFiles.FormattingEnabled = true;
            lbSourceFiles.ItemHeight = 25;
            lbSourceFiles.Location = new System.Drawing.Point(17, 50);
            lbSourceFiles.Name = "lbSourceFiles";
            lbSourceFiles.Size = new System.Drawing.Size(508, 129);
            lbSourceFiles.TabIndex = 55;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1213, 787);
            Controls.Add(lbSourceFiles);
            Controls.Add(groupBox2);
            Controls.Add(edHeight);
            Controls.Add(label4);
            Controls.Add(edWidth);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(edBottom);
            Controls.Add(label42);
            Controls.Add(edRight);
            Controls.Add(label40);
            Controls.Add(edTop);
            Controls.Add(label26);
            Controls.Add(edLeft);
            Controls.Add(label24);
            Controls.Add(btRemoveFile);
            Controls.Add(btAddFile);
            Controls.Add(label1);
            Controls.Add(videoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Media Player SDK .Net (Cross-platform) - Video Mixer Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.Button btRemoveFile;
        private System.Windows.Forms.TextBox edBottom;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox edRight;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox edTop;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox edLeft;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTimeline;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Timer tmPosition;
        private System.Windows.Forms.ListBox lbSourceFiles;
    }
}
