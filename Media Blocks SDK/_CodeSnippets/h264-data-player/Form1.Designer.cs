namespace media_player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            edFilename = new System.Windows.Forms.TextBox();
            btOpenFile = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            lbTimestamp = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(19, 34);
            VideoView1.Margin = new System.Windows.Forms.Padding(4);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(747, 397);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 0;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(19, 439);
            btStart.Margin = new System.Windows.Forms.Padding(4);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(88, 26);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(113, 439);
            btStop.Margin = new System.Windows.Forms.Padding(4);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(88, 26);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(19, 12);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(127, 15);
            label1.TabIndex = 3;
            label1.Text = "File name or HTTP URL";
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(150, 9);
            edFilename.Margin = new System.Windows.Forms.Padding(2);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(587, 23);
            edFilename.TabIndex = 4;
            edFilename.Text = "c:\\samples\\video.h264";
            // 
            // btOpenFile
            // 
            btOpenFile.Location = new System.Drawing.Point(740, 9);
            btOpenFile.Margin = new System.Windows.Forms.Padding(2);
            btOpenFile.Name = "btOpenFile";
            btOpenFile.Size = new System.Drawing.Size(26, 20);
            btOpenFile.TabIndex = 5;
            btOpenFile.Text = "...";
            btOpenFile.UseVisualStyleBackColor = true;
            btOpenFile.Click += btOpenFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbTimestamp
            // 
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(717, 445);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(49, 15);
            lbTimestamp.TabIndex = 7;
            lbTimestamp.Text = "00:00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(786, 482);
            Controls.Add(lbTimestamp);
            Controls.Add(btOpenFile);
            Controls.Add(edFilename);
            Controls.Add(label1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - H264 player code snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
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
        private System.Windows.Forms.Label lbTimestamp;
    }
}
