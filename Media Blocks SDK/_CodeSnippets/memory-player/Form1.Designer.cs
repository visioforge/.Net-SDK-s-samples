﻿namespace media_player
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
            VideoView1.Location = new System.Drawing.Point(27, 57);
            VideoView1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(1067, 662);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 0;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(27, 732);
            btStart.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(126, 43);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(161, 732);
            btStop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(126, 43);
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
            label1.Size = new System.Drawing.Size(191, 25);
            label1.TabIndex = 3;
            label1.Text = "File name or HTTP URL";
            // 
            // edFilename
            // 
            edFilename.Location = new System.Drawing.Point(214, 15);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(837, 31);
            edFilename.TabIndex = 4;
            edFilename.Text = "c:\\samples\\!video.mp4";
            // 
            // btOpenFile
            // 
            btOpenFile.Location = new System.Drawing.Point(1057, 15);
            btOpenFile.Name = "btOpenFile";
            btOpenFile.Size = new System.Drawing.Size(37, 33);
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
            lbTimestamp.Location = new System.Drawing.Point(1024, 742);
            lbTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(80, 25);
            lbTimestamp.TabIndex = 7;
            lbTimestamp.Text = "00:00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 803);
            Controls.Add(lbTimestamp);
            Controls.Add(btOpenFile);
            Controls.Add(edFilename);
            Controls.Add(label1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - Memory player code snippet";
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