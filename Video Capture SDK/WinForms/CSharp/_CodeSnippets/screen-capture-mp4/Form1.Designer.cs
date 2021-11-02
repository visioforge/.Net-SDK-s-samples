namespace screen_capture_mp4
{    partial class Form1
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
            this.VideoView1 = new VisioForge.Controls.UI.WinForms.VideoView();
            this.btStartWithAudio = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStartWithoutAudio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(16, 14);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(640, 360);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 0;
            // 
            // btStartWithAudio
            // 
            this.btStartWithAudio.Location = new System.Drawing.Point(16, 380);
            this.btStartWithAudio.Name = "btStartWithAudio";
            this.btStartWithAudio.Size = new System.Drawing.Size(100, 23);
            this.btStartWithAudio.TabIndex = 1;
            this.btStartWithAudio.Text = "Start with audio";
            this.btStartWithAudio.UseVisualStyleBackColor = true;
            this.btStartWithAudio.Click += new System.EventHandler(this.btStartWithAudio_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(255, 380);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStartWithoutAudio
            // 
            this.btStartWithoutAudio.Location = new System.Drawing.Point(122, 380);
            this.btStartWithoutAudio.Name = "btStartWithoutAudio";
            this.btStartWithoutAudio.Size = new System.Drawing.Size(127, 23);
            this.btStartWithoutAudio.TabIndex = 3;
            this.btStartWithoutAudio.Text = "Start without audio";
            this.btStartWithoutAudio.UseVisualStyleBackColor = true;
            this.btStartWithoutAudio.Click += new System.EventHandler(this.btStartWithoutAudio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 418);
            this.Controls.Add(this.btStartWithoutAudio);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStartWithAudio);
            this.Controls.Add(this.VideoView1);
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Screen capture to MP4 code snippet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisioForge.Controls.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStartWithAudio;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStartWithoutAudio;
    }
}
