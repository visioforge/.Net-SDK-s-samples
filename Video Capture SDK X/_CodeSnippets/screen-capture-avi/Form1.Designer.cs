namespace screen_capture_avi
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

            videoCapture1?.Dispose();
            videoCapture1 = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
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
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(27, 731);
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
            btStop.Location = new System.Drawing.Point(162, 731);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(125, 44);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 804);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Video Capture SDK .Net - Screen capture to AVI code snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
    }
}