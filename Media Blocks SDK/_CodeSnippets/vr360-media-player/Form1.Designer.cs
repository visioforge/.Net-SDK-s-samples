namespace vr360_media_player
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
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            edFilename = new System.Windows.Forms.TextBox();
            btOpenFile = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            btZoomOut = new System.Windows.Forms.Button();
            btZoomIn = new System.Windows.Forms.Button();
            bt360Right = new System.Windows.Forms.Button();
            bt360Left = new System.Windows.Forms.Button();
            bt360Down = new System.Windows.Forms.Button();
            bt360Up = new System.Windows.Forms.Button();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            label2 = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(27, 57);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(1067, 680);
            VideoView1.TabIndex = 0;
            VideoView1.MouseDown += VideoView1_MouseDown;
            VideoView1.MouseMove += VideoView1_MouseMove;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btStart.Location = new System.Drawing.Point(27, 763);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(125, 44);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btStop.Location = new System.Drawing.Point(162, 763);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(125, 44);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 25);
            label1.TabIndex = 3;
            label1.Text = "File name";
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(137, 17);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(914, 31);
            edFilename.TabIndex = 4;
            edFilename.Text = "c:\\Samples\\360\\equirectangular4.MP4";
            // 
            // btOpenFile
            // 
            btOpenFile.Location = new System.Drawing.Point(1057, 15);
            btOpenFile.Name = "btOpenFile";
            btOpenFile.Size = new System.Drawing.Size(37, 34);
            btOpenFile.TabIndex = 5;
            btOpenFile.Text = "...";
            btOpenFile.UseVisualStyleBackColor = true;
            btOpenFile.Click += btOpenFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btZoomOut
            // 
            btZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btZoomOut.Location = new System.Drawing.Point(1212, 105);
            btZoomOut.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btZoomOut.Name = "btZoomOut";
            btZoomOut.Size = new System.Drawing.Size(38, 44);
            btZoomOut.TabIndex = 76;
            btZoomOut.Text = "-";
            btZoomOut.UseVisualStyleBackColor = true;
            btZoomOut.Click += btZoomOut_Click;
            // 
            // btZoomIn
            // 
            btZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btZoomIn.Location = new System.Drawing.Point(1165, 105);
            btZoomIn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btZoomIn.Name = "btZoomIn";
            btZoomIn.Size = new System.Drawing.Size(37, 44);
            btZoomIn.TabIndex = 75;
            btZoomIn.Text = "+";
            btZoomIn.UseVisualStyleBackColor = true;
            btZoomIn.Click += btZoomIn_Click;
            // 
            // bt360Right
            // 
            bt360Right.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Right.Location = new System.Drawing.Point(1250, 82);
            bt360Right.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Right.Name = "bt360Right";
            bt360Right.Size = new System.Drawing.Size(35, 92);
            bt360Right.TabIndex = 74;
            bt360Right.Text = "R";
            bt360Right.UseVisualStyleBackColor = true;
            bt360Right.Click += bt360Right_Click;
            // 
            // bt360Left
            // 
            bt360Left.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Left.Location = new System.Drawing.Point(1130, 80);
            bt360Left.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Left.Name = "bt360Left";
            bt360Left.Size = new System.Drawing.Size(35, 92);
            bt360Left.TabIndex = 73;
            bt360Left.Text = "L";
            bt360Left.UseVisualStyleBackColor = true;
            bt360Left.Click += bt360Left_Click;
            // 
            // bt360Down
            // 
            bt360Down.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Down.Location = new System.Drawing.Point(1165, 153);
            bt360Down.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Down.Name = "bt360Down";
            bt360Down.Size = new System.Drawing.Size(85, 44);
            bt360Down.TabIndex = 72;
            bt360Down.Text = "Down";
            bt360Down.UseVisualStyleBackColor = true;
            bt360Down.Click += bt360Down_Click;
            // 
            // bt360Up
            // 
            bt360Up.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt360Up.Location = new System.Drawing.Point(1165, 57);
            bt360Up.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bt360Up.Name = "bt360Up";
            bt360Up.Size = new System.Drawing.Size(85, 44);
            bt360Up.TabIndex = 71;
            bt360Up.Text = "Up";
            bt360Up.UseVisualStyleBackColor = true;
            bt360Up.Click += bt360Up_Click;
            // 
            // lbTime
            // 
            lbTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(939, 763);
            lbTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(155, 25);
            lbTime.TabIndex = 78;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            tbTimeline.Location = new System.Drawing.Point(584, 749);
            tbTimeline.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(345, 69);
            tbTimeline.TabIndex = 77;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(305, 773);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(271, 25);
            label2.TabIndex = 79;
            label2.Text = "Equirectangular video supported";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1311, 822);
            Controls.Add(label2);
            Controls.Add(lbTime);
            Controls.Add(tbTimeline);
            Controls.Add(btZoomOut);
            Controls.Add(btZoomIn);
            Controls.Add(bt360Right);
            Controls.Add(bt360Left);
            Controls.Add(bt360Down);
            Controls.Add(bt360Up);
            Controls.Add(btOpenFile);
            Controls.Add(edFilename);
            Controls.Add(label1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - VR 360 sample";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btZoomOut;
        private System.Windows.Forms.Button btZoomIn;
        private System.Windows.Forms.Button bt360Right;
        private System.Windows.Forms.Button bt360Left;
        private System.Windows.Forms.Button bt360Down;
        private System.Windows.Forms.Button bt360Up;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}
