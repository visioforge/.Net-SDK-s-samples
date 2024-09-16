namespace ip_camera_capture_mp4
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
            cbAudioStream = new System.Windows.Forms.CheckBox();
            edPassword = new System.Windows.Forms.TextBox();
            edLogin = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            edURL = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(27, 117);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(1067, 602);
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
            // cbAudioStream
            // 
            cbAudioStream.AutoSize = true;
            cbAudioStream.Location = new System.Drawing.Point(650, 70);
            cbAudioStream.Name = "cbAudioStream";
            cbAudioStream.Size = new System.Drawing.Size(159, 29);
            cbAudioStream.TabIndex = 16;
            cbAudioStream.Text = "Audio available";
            cbAudioStream.UseVisualStyleBackColor = true;
            // 
            // edPassword
            // 
            edPassword.Location = new System.Drawing.Point(450, 68);
            edPassword.Name = "edPassword";
            edPassword.Size = new System.Drawing.Size(150, 31);
            edPassword.TabIndex = 15;
            // 
            // edLogin
            // 
            edLogin.Location = new System.Drawing.Point(135, 68);
            edLogin.Name = "edLogin";
            edLogin.Size = new System.Drawing.Size(150, 31);
            edLogin.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(341, 71);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 25);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 25);
            label2.TabIndex = 12;
            label2.Text = "Login";
            // 
            // edURL
            // 
            edURL.Location = new System.Drawing.Point(137, 21);
            edURL.Name = "edURL";
            edURL.Size = new System.Drawing.Size(957, 31);
            edURL.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 25);
            label1.TabIndex = 10;
            label1.Text = "RTSP URL";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 804);
            Controls.Add(cbAudioStream);
            Controls.Add(edPassword);
            Controls.Add(edLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(edURL);
            Controls.Add(label1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - IP camera capture to MP4 code snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.CheckBox cbAudioStream;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edURL;
        private System.Windows.Forms.Label label1;
    }
}
