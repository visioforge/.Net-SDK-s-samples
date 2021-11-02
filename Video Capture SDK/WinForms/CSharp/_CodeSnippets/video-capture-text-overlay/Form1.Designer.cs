namespace video_capture_text_overlay
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
            this.VideoView1 = new VisioForge.Controls.UI.WinForms.VideoView();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
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
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(16, 380);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(97, 380);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 418);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.VideoView1);
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Video capture webcam with text overlay code snippet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisioForge.Controls.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
    }
}
