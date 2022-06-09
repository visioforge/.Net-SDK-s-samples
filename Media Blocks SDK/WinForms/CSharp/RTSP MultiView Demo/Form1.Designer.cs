namespace MediaBlocks_RTSP_MultiView_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.edURL = new System.Windows.Forms.TextBox();
            this.edLogin = new System.Windows.Forms.TextBox();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.cbCameraIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.videoView9 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView8 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView7 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView6 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView5 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView4 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView3 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView2 = new VisioForge.Core.UI.WinForms.VideoView();
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.cbAudioEnabled = new System.Windows.Forms.CheckBox();
            this.cbUseMJPEG = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1470, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Camera index";
            // 
            // edURL
            // 
            this.edURL.Location = new System.Drawing.Point(1474, 77);
            this.edURL.Name = "edURL";
            this.edURL.Size = new System.Drawing.Size(412, 26);
            this.edURL.TabIndex = 9;
            this.edURL.Text = "rtsp://admin:dancer23@192.168.50.64:554/Streaming/Channels/101?transportmode=unic" +
    "ast&profile=Profile_1";
            // 
            // edLogin
            // 
            this.edLogin.Location = new System.Drawing.Point(1474, 141);
            this.edLogin.Name = "edLogin";
            this.edLogin.Size = new System.Drawing.Size(122, 26);
            this.edLogin.TabIndex = 11;
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(1602, 143);
            this.edPassword.Name = "edPassword";
            this.edPassword.Size = new System.Drawing.Size(122, 26);
            this.edPassword.TabIndex = 12;
            // 
            // cbCameraIndex
            // 
            this.cbCameraIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraIndex.FormattingEnabled = true;
            this.cbCameraIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbCameraIndex.Location = new System.Drawing.Point(1602, 14);
            this.cbCameraIndex.Name = "cbCameraIndex";
            this.cbCameraIndex.Size = new System.Drawing.Size(80, 28);
            this.cbCameraIndex.TabIndex = 13;
            this.cbCameraIndex.SelectedIndexChanged += new System.EventHandler(this.cbCameraIndex_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1470, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1470, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1598, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password";
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(1594, 949);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(112, 35);
            this.btStop.TabIndex = 19;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(1474, 949);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(112, 35);
            this.btStart.TabIndex = 18;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // videoView9
            // 
            this.videoView9.BackColor = System.Drawing.Color.Black;
            this.videoView9.Location = new System.Drawing.Point(984, 664);
            this.videoView9.Name = "videoView9";
            this.videoView9.Size = new System.Drawing.Size(480, 320);
            this.videoView9.StatusOverlay = null;
            this.videoView9.TabIndex = 7;
            // 
            // videoView8
            // 
            this.videoView8.BackColor = System.Drawing.Color.Black;
            this.videoView8.Location = new System.Drawing.Point(498, 664);
            this.videoView8.Name = "videoView8";
            this.videoView8.Size = new System.Drawing.Size(480, 320);
            this.videoView8.StatusOverlay = null;
            this.videoView8.TabIndex = 6;
            // 
            // videoView7
            // 
            this.videoView7.BackColor = System.Drawing.Color.Black;
            this.videoView7.Location = new System.Drawing.Point(12, 664);
            this.videoView7.Name = "videoView7";
            this.videoView7.Size = new System.Drawing.Size(480, 320);
            this.videoView7.StatusOverlay = null;
            this.videoView7.TabIndex = 1;
            // 
            // videoView6
            // 
            this.videoView6.BackColor = System.Drawing.Color.Black;
            this.videoView6.Location = new System.Drawing.Point(984, 338);
            this.videoView6.Name = "videoView6";
            this.videoView6.Size = new System.Drawing.Size(480, 320);
            this.videoView6.StatusOverlay = null;
            this.videoView6.TabIndex = 5;
            // 
            // videoView5
            // 
            this.videoView5.BackColor = System.Drawing.Color.Black;
            this.videoView5.Location = new System.Drawing.Point(498, 338);
            this.videoView5.Name = "videoView5";
            this.videoView5.Size = new System.Drawing.Size(480, 320);
            this.videoView5.StatusOverlay = null;
            this.videoView5.TabIndex = 4;
            // 
            // videoView4
            // 
            this.videoView4.BackColor = System.Drawing.Color.Black;
            this.videoView4.Location = new System.Drawing.Point(12, 338);
            this.videoView4.Name = "videoView4";
            this.videoView4.Size = new System.Drawing.Size(480, 320);
            this.videoView4.StatusOverlay = null;
            this.videoView4.TabIndex = 3;
            // 
            // videoView3
            // 
            this.videoView3.BackColor = System.Drawing.Color.Black;
            this.videoView3.Location = new System.Drawing.Point(984, 12);
            this.videoView3.Name = "videoView3";
            this.videoView3.Size = new System.Drawing.Size(480, 320);
            this.videoView3.StatusOverlay = null;
            this.videoView3.TabIndex = 2;
            // 
            // videoView2
            // 
            this.videoView2.BackColor = System.Drawing.Color.Black;
            this.videoView2.Location = new System.Drawing.Point(498, 12);
            this.videoView2.Name = "videoView2";
            this.videoView2.Size = new System.Drawing.Size(480, 320);
            this.videoView2.StatusOverlay = null;
            this.videoView2.TabIndex = 1;
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(12, 12);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(480, 320);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 0;
            // 
            // cbAudioEnabled
            // 
            this.cbAudioEnabled.AutoSize = true;
            this.cbAudioEnabled.Location = new System.Drawing.Point(1758, 143);
            this.cbAudioEnabled.Name = "cbAudioEnabled";
            this.cbAudioEnabled.Size = new System.Drawing.Size(128, 24);
            this.cbAudioEnabled.TabIndex = 20;
            this.cbAudioEnabled.Text = "Enable audio";
            this.cbAudioEnabled.UseVisualStyleBackColor = true;
            // 
            // cbUseMJPEG
            // 
            this.cbUseMJPEG.AutoSize = true;
            this.cbUseMJPEG.Location = new System.Drawing.Point(1667, 53);
            this.cbUseMJPEG.Name = "cbUseMJPEG";
            this.cbUseMJPEG.Size = new System.Drawing.Size(219, 24);
            this.cbUseMJPEG.TabIndex = 21;
            this.cbUseMJPEG.Text = "Use HTTP MJPEG source";
            this.cbUseMJPEG.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 994);
            this.Controls.Add(this.cbUseMJPEG);
            this.Controls.Add(this.cbAudioEnabled);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCameraIndex);
            this.Controls.Add(this.edPassword);
            this.Controls.Add(this.edLogin);
            this.Controls.Add(this.edURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoView9);
            this.Controls.Add(this.videoView8);
            this.Controls.Add(this.videoView7);
            this.Controls.Add(this.videoView6);
            this.Controls.Add(this.videoView5);
            this.Controls.Add(this.videoView4);
            this.Controls.Add(this.videoView3);
            this.Controls.Add(this.videoView2);
            this.Controls.Add(this.videoView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RTSP MultiView Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private VisioForge.Core.UI.WinForms.VideoView videoView2;
        private VisioForge.Core.UI.WinForms.VideoView videoView3;
        private VisioForge.Core.UI.WinForms.VideoView videoView4;
        private VisioForge.Core.UI.WinForms.VideoView videoView5;
        private VisioForge.Core.UI.WinForms.VideoView videoView6;
        private VisioForge.Core.UI.WinForms.VideoView videoView7;
        private VisioForge.Core.UI.WinForms.VideoView videoView8;
        private VisioForge.Core.UI.WinForms.VideoView videoView9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edURL;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.ComboBox cbCameraIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.CheckBox cbAudioEnabled;
        private System.Windows.Forms.CheckBox cbUseMJPEG;
    }
}

