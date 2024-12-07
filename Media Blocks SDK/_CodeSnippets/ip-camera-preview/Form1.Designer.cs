namespace ip_camera_preview
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
            edURL = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            edLogin = new System.Windows.Forms.TextBox();
            edPassword = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(27, 110);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(1067, 609);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 25);
            label1.TabIndex = 3;
            label1.Text = "RTSP URL";
            // 
            // edURL
            // 
            edURL.Location = new System.Drawing.Point(137, 17);
            edURL.Name = "edURL";
            edURL.Size = new System.Drawing.Size(957, 31);
            edURL.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 25);
            label2.TabIndex = 5;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(341, 67);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 25);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // edLogin
            // 
            edLogin.Location = new System.Drawing.Point(135, 64);
            edLogin.Name = "edLogin";
            edLogin.Size = new System.Drawing.Size(150, 31);
            edLogin.TabIndex = 7;
            // 
            // edPassword
            // 
            edPassword.Location = new System.Drawing.Point(450, 64);
            edPassword.Name = "edPassword";
            edPassword.Size = new System.Drawing.Size(150, 31);
            edPassword.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 804);
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
            Text = "Media Blocks SDK .Net - IP camera preview code snippet";
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
        private System.Windows.Forms.TextBox edURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edPassword;
    }
}
