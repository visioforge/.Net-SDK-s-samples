namespace screen_capture_mp4
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
            btStartWithAudio = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            btStartWithoutAudio = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(27, 27);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(1067, 692);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 0;
            // 
            // btStartWithAudio
            // 
            btStartWithAudio.Location = new System.Drawing.Point(27, 731);
            btStartWithAudio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStartWithAudio.Name = "btStartWithAudio";
            btStartWithAudio.Size = new System.Drawing.Size(167, 44);
            btStartWithAudio.TabIndex = 1;
            btStartWithAudio.Text = "Start with audio";
            btStartWithAudio.UseVisualStyleBackColor = true;
            btStartWithAudio.Click += btStartWithAudio_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(425, 731);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(125, 44);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStartWithoutAudio
            // 
            btStartWithoutAudio.Location = new System.Drawing.Point(203, 731);
            btStartWithoutAudio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStartWithoutAudio.Name = "btStartWithoutAudio";
            btStartWithoutAudio.Size = new System.Drawing.Size(212, 44);
            btStartWithoutAudio.TabIndex = 3;
            btStartWithoutAudio.Text = "Start without audio";
            btStartWithoutAudio.UseVisualStyleBackColor = true;
            btStartWithoutAudio.Click += btStartWithoutAudio_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 804);
            Controls.Add(btStartWithoutAudio);
            Controls.Add(btStop);
            Controls.Add(btStartWithAudio);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - Screen capture to MP4 code snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStartWithAudio;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStartWithoutAudio;
    }
}
