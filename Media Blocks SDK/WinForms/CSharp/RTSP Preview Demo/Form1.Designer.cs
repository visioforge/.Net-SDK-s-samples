namespace RTSP_Preview_WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tcMain = new System.Windows.Forms.TabControl();
            tabInput = new System.Windows.Forms.TabPage();
            tcInput = new System.Windows.Forms.TabControl();
            tabMain = new System.Windows.Forms.TabPage();
            btListONVIFSources = new System.Windows.Forms.Button();
            cbLowLatencyMode = new System.Windows.Forms.CheckBox();
            cbIPAudioCapture = new System.Windows.Forms.CheckBox();
            edIPPassword = new System.Windows.Forms.TextBox();
            label222 = new System.Windows.Forms.Label();
            edIPLogin = new System.Windows.Forms.TextBox();
            label221 = new System.Windows.Forms.Label();
            cbIPURL = new System.Windows.Forms.ComboBox();
            label220 = new System.Windows.Forms.Label();
            tabONVIF = new System.Windows.Forms.TabPage();
            edONVIFPassword = new System.Windows.Forms.TextBox();
            label222_Copy = new System.Windows.Forms.Label();
            edONVIFLogin = new System.Windows.Forms.TextBox();
            label221_Copy = new System.Windows.Forms.Label();
            edONVIFURL = new System.Windows.Forms.TextBox();
            edONVIFLiveVideoURL = new System.Windows.Forms.TextBox();
            labelVideoURL = new System.Windows.Forms.Label();
            cbONVIFProfile = new System.Windows.Forms.ComboBox();
            labelProfile = new System.Windows.Forms.Label();
            lbONVIFCameraInfo = new System.Windows.Forms.Label();
            btONVIFConnect = new System.Windows.Forms.Button();
            tabLog = new System.Windows.Forms.TabPage();
            mmLog = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            llVideoTutorials = new System.Windows.Forms.LinkLabel();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            label1 = new System.Windows.Forms.Label();
            lbTimestamp = new System.Windows.Forms.Label();
            btResume = new System.Windows.Forms.Button();
            btPause = new System.Windows.Forms.Button();
            tcMain.SuspendLayout();
            tabInput.SuspendLayout();
            tcInput.SuspendLayout();
            tabMain.SuspendLayout();
            tabONVIF.SuspendLayout();
            tabLog.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tabInput);
            tcMain.Controls.Add(tabLog);
            tcMain.Location = new System.Drawing.Point(12, 12);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new System.Drawing.Size(540, 379);
            tcMain.TabIndex = 0;
            // 
            // tabInput
            // 
            tabInput.Controls.Add(tcInput);
            tabInput.Location = new System.Drawing.Point(4, 29);
            tabInput.Name = "tabInput";
            tabInput.Padding = new System.Windows.Forms.Padding(3);
            tabInput.Size = new System.Drawing.Size(532, 346);
            tabInput.TabIndex = 0;
            tabInput.Text = "Input";
            tabInput.UseVisualStyleBackColor = true;
            // 
            // tcInput
            // 
            tcInput.Controls.Add(tabMain);
            tcInput.Controls.Add(tabONVIF);
            tcInput.Location = new System.Drawing.Point(10, 10);
            tcInput.Name = "tcInput";
            tcInput.SelectedIndex = 0;
            tcInput.Size = new System.Drawing.Size(514, 331);
            tcInput.TabIndex = 0;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(btListONVIFSources);
            tabMain.Controls.Add(cbLowLatencyMode);
            tabMain.Controls.Add(cbIPAudioCapture);
            tabMain.Controls.Add(edIPPassword);
            tabMain.Controls.Add(label222);
            tabMain.Controls.Add(edIPLogin);
            tabMain.Controls.Add(label221);
            tabMain.Controls.Add(cbIPURL);
            tabMain.Controls.Add(label220);
            tabMain.Location = new System.Drawing.Point(4, 29);
            tabMain.Name = "tabMain";
            tabMain.Padding = new System.Windows.Forms.Padding(3);
            tabMain.Size = new System.Drawing.Size(506, 298);
            tabMain.TabIndex = 0;
            tabMain.Text = "Main";
            tabMain.UseVisualStyleBackColor = true;
            // 
            // btListONVIFSources
            // 
            btListONVIFSources.Location = new System.Drawing.Point(351, 98);
            btListONVIFSources.Name = "btListONVIFSources";
            btListONVIFSources.Size = new System.Drawing.Size(147, 29);
            btListONVIFSources.TabIndex = 8;
            btListONVIFSources.Text = "List ONVIF sources";
            btListONVIFSources.UseVisualStyleBackColor = true;
            btListONVIFSources.Click += btListONVIFSources_Click;
            // 
            // cbLowLatencyMode
            // 
            cbLowLatencyMode.AutoSize = true;
            cbLowLatencyMode.Location = new System.Drawing.Point(143, 70);
            cbLowLatencyMode.Name = "cbLowLatencyMode";
            cbLowLatencyMode.Size = new System.Drawing.Size(158, 24);
            cbLowLatencyMode.TabIndex = 7;
            cbLowLatencyMode.Text = "Low latency mode";
            cbLowLatencyMode.UseVisualStyleBackColor = true;
            // 
            // cbIPAudioCapture
            // 
            cbIPAudioCapture.AutoSize = true;
            cbIPAudioCapture.Checked = true;
            cbIPAudioCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            cbIPAudioCapture.Location = new System.Drawing.Point(20, 70);
            cbIPAudioCapture.Name = "cbIPAudioCapture";
            cbIPAudioCapture.Size = new System.Drawing.Size(125, 24);
            cbIPAudioCapture.TabIndex = 6;
            cbIPAudioCapture.Text = "Capture audio";
            cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // edIPPassword
            // 
            edIPPassword.Location = new System.Drawing.Point(186, 98);
            edIPPassword.Name = "edIPPassword";
            edIPPassword.Size = new System.Drawing.Size(150, 27);
            edIPPassword.TabIndex = 5;
            // 
            // label222
            // 
            label222.AutoSize = true;
            label222.Location = new System.Drawing.Point(186, 74);
            label222.Name = "label222";
            label222.Size = new System.Drawing.Size(70, 20);
            label222.TabIndex = 4;
            label222.Text = "Password";
            // 
            // edIPLogin
            // 
            edIPLogin.Location = new System.Drawing.Point(20, 98);
            edIPLogin.Name = "edIPLogin";
            edIPLogin.Size = new System.Drawing.Size(150, 27);
            edIPLogin.TabIndex = 3;
            // 
            // label221
            // 
            label221.AutoSize = true;
            label221.Location = new System.Drawing.Point(20, 74);
            label221.Name = "label221";
            label221.Size = new System.Drawing.Size(46, 20);
            label221.TabIndex = 2;
            label221.Text = "Login";
            // 
            // cbIPURL
            // 
            cbIPURL.FormattingEnabled = true;
            cbIPURL.Location = new System.Drawing.Point(20, 38);
            cbIPURL.Name = "cbIPURL";
            cbIPURL.Size = new System.Drawing.Size(477, 28);
            cbIPURL.TabIndex = 1;
            cbIPURL.Text = "rtsp://";
            // 
            // label220
            // 
            label220.AutoSize = true;
            label220.Location = new System.Drawing.Point(16, 10);
            label220.Name = "label220";
            label220.Size = new System.Drawing.Size(35, 20);
            label220.TabIndex = 0;
            label220.Text = "URL";
            // 
            // tabONVIF
            // 
            tabONVIF.Controls.Add(edONVIFPassword);
            tabONVIF.Controls.Add(label222_Copy);
            tabONVIF.Controls.Add(edONVIFLogin);
            tabONVIF.Controls.Add(label221_Copy);
            tabONVIF.Controls.Add(edONVIFURL);
            tabONVIF.Controls.Add(edONVIFLiveVideoURL);
            tabONVIF.Controls.Add(labelVideoURL);
            tabONVIF.Controls.Add(cbONVIFProfile);
            tabONVIF.Controls.Add(labelProfile);
            tabONVIF.Controls.Add(lbONVIFCameraInfo);
            tabONVIF.Controls.Add(btONVIFConnect);
            tabONVIF.Location = new System.Drawing.Point(4, 29);
            tabONVIF.Name = "tabONVIF";
            tabONVIF.Padding = new System.Windows.Forms.Padding(3);
            tabONVIF.Size = new System.Drawing.Size(506, 298);
            tabONVIF.TabIndex = 1;
            tabONVIF.Text = "ONVIF";
            tabONVIF.UseVisualStyleBackColor = true;
            // 
            // edONVIFPassword
            // 
            edONVIFPassword.Location = new System.Drawing.Point(348, 43);
            edONVIFPassword.Name = "edONVIFPassword";
            edONVIFPassword.Size = new System.Drawing.Size(150, 27);
            edONVIFPassword.TabIndex = 10;
            // 
            // label222_Copy
            // 
            label222_Copy.AutoSize = true;
            label222_Copy.Location = new System.Drawing.Point(283, 38);
            label222_Copy.Name = "label222_Copy";
            label222_Copy.Size = new System.Drawing.Size(70, 20);
            label222_Copy.TabIndex = 9;
            label222_Copy.Text = "Password";
            // 
            // edONVIFLogin
            // 
            edONVIFLogin.Location = new System.Drawing.Point(80, 43);
            edONVIFLogin.Name = "edONVIFLogin";
            edONVIFLogin.Size = new System.Drawing.Size(150, 27);
            edONVIFLogin.TabIndex = 8;
            // 
            // label221_Copy
            // 
            label221_Copy.AutoSize = true;
            label221_Copy.Location = new System.Drawing.Point(10, 38);
            label221_Copy.Name = "label221_Copy";
            label221_Copy.Size = new System.Drawing.Size(46, 20);
            label221_Copy.TabIndex = 7;
            label221_Copy.Text = "Login";
            // 
            // edONVIFURL
            // 
            edONVIFURL.Location = new System.Drawing.Point(10, 10);
            edONVIFURL.Name = "edONVIFURL";
            edONVIFURL.Size = new System.Drawing.Size(408, 27);
            edONVIFURL.TabIndex = 6;
            edONVIFURL.Text = "http://192.168.1.22/onvif/device_service";
            // 
            // edONVIFLiveVideoURL
            // 
            edONVIFLiveVideoURL.Location = new System.Drawing.Point(80, 135);
            edONVIFLiveVideoURL.Name = "edONVIFLiveVideoURL";
            edONVIFLiveVideoURL.Size = new System.Drawing.Size(418, 27);
            edONVIFLiveVideoURL.TabIndex = 5;
            // 
            // labelVideoURL
            // 
            labelVideoURL.AutoSize = true;
            labelVideoURL.Location = new System.Drawing.Point(10, 131);
            labelVideoURL.Name = "labelVideoURL";
            labelVideoURL.Size = new System.Drawing.Size(76, 20);
            labelVideoURL.TabIndex = 4;
            labelVideoURL.Text = "Video URL";
            // 
            // cbONVIFProfile
            // 
            cbONVIFProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbONVIFProfile.FormattingEnabled = true;
            cbONVIFProfile.Location = new System.Drawing.Point(80, 104);
            cbONVIFProfile.Name = "cbONVIFProfile";
            cbONVIFProfile.Size = new System.Drawing.Size(418, 28);
            cbONVIFProfile.TabIndex = 3;
            // 
            // labelProfile
            // 
            labelProfile.AutoSize = true;
            labelProfile.Location = new System.Drawing.Point(10, 100);
            labelProfile.Name = "labelProfile";
            labelProfile.Size = new System.Drawing.Size(53, 20);
            labelProfile.TabIndex = 2;
            labelProfile.Text = "Profile";
            // 
            // lbONVIFCameraInfo
            // 
            lbONVIFCameraInfo.AutoSize = true;
            lbONVIFCameraInfo.Location = new System.Drawing.Point(10, 71);
            lbONVIFCameraInfo.Name = "lbONVIFCameraInfo";
            lbONVIFCameraInfo.Size = new System.Drawing.Size(94, 20);
            lbONVIFCameraInfo.TabIndex = 1;
            lbONVIFCameraInfo.Text = "Status: None";
            // 
            // btONVIFConnect
            // 
            btONVIFConnect.Location = new System.Drawing.Point(423, 10);
            btONVIFConnect.Name = "btONVIFConnect";
            btONVIFConnect.Size = new System.Drawing.Size(75, 29);
            btONVIFConnect.TabIndex = 0;
            btONVIFConnect.Text = "Connect";
            btONVIFConnect.UseVisualStyleBackColor = true;
            btONVIFConnect.Click += btONVIFConnect_Click;
            // 
            // tabLog
            // 
            tabLog.Controls.Add(mmLog);
            tabLog.Controls.Add(cbDebugMode);
            tabLog.Location = new System.Drawing.Point(4, 29);
            tabLog.Name = "tabLog";
            tabLog.Padding = new System.Windows.Forms.Padding(3);
            tabLog.Size = new System.Drawing.Size(532, 346);
            tabLog.TabIndex = 1;
            tabLog.Text = "Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(10, 31);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmLog.Size = new System.Drawing.Size(512, 310);
            mmLog.TabIndex = 1;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(10, 10);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(119, 24);
            cbDebugMode.TabIndex = 0;
            cbDebugMode.Text = "Debug Mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStart.Location = new System.Drawing.Point(642, 397);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(75, 29);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btStop.Location = new System.Drawing.Point(722, 397);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(75, 29);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // llVideoTutorials
            // 
            llVideoTutorials.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            llVideoTutorials.AutoSize = true;
            llVideoTutorials.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            llVideoTutorials.Location = new System.Drawing.Point(927, 9);
            llVideoTutorials.Name = "llVideoTutorials";
            llVideoTutorials.Size = new System.Drawing.Size(107, 20);
            llVideoTutorials.TabIndex = 3;
            llVideoTutorials.TabStop = true;
            llVideoTutorials.Text = "Video tutorial";
            llVideoTutorials.LinkClicked += llVideoTutorials_LinkClicked;
            // 
            // VideoView1
            // 
            VideoView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(560, 31);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(474, 360);
            VideoView1.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(721, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(313, 20);
            label1.TabIndex = 5;
            label1.Text = "Much more features available in Main Demo";
            // 
            // lbTimestamp
            // 
            lbTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbTimestamp.AutoSize = true;
            lbTimestamp.Location = new System.Drawing.Point(445, 401);
            lbTimestamp.Name = "lbTimestamp";
            lbTimestamp.Size = new System.Drawing.Size(135, 20);
            lbTimestamp.TabIndex = 6;
            lbTimestamp.Text = "Duration: 00:00:00";
            // 
            // btResume
            // 
            btResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btResume.Location = new System.Drawing.Point(876, 397);
            btResume.Name = "btResume";
            btResume.Size = new System.Drawing.Size(75, 29);
            btResume.TabIndex = 7;
            btResume.Text = "Resume";
            btResume.UseVisualStyleBackColor = true;
            btResume.Click += btResume_Click;
            // 
            // btPause
            // 
            btPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btPause.Location = new System.Drawing.Point(803, 397);
            btPause.Name = "btPause";
            btPause.Size = new System.Drawing.Size(67, 29);
            btPause.TabIndex = 8;
            btPause.Text = "Pause";
            btPause.UseVisualStyleBackColor = true;
            btPause.Click += btPause_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1041, 431);
            Controls.Add(btPause);
            Controls.Add(btResume);
            Controls.Add(lbTimestamp);
            Controls.Add(label1);
            Controls.Add(VideoView1);
            Controls.Add(llVideoTutorials);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(tcMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "RTSP Preview Demo - Media Blocks SDK .Net";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            tabInput.ResumeLayout(false);
            tcInput.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            tabMain.PerformLayout();
            tabONVIF.ResumeLayout(false);
            tabONVIF.PerformLayout();
            tabLog.ResumeLayout(false);
            tabLog.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.TabControl tcInput;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabONVIF;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.ComboBox cbIPURL;
        private System.Windows.Forms.TextBox edIPLogin;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.TextBox edIPPassword;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.CheckBox cbIPAudioCapture;
        private System.Windows.Forms.CheckBox cbLowLatencyMode;
        private System.Windows.Forms.Button btListONVIFSources;
        private System.Windows.Forms.Button btONVIFConnect;
        private System.Windows.Forms.Label lbONVIFCameraInfo;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.ComboBox cbONVIFProfile;
        private System.Windows.Forms.Label labelVideoURL;
        private System.Windows.Forms.TextBox edONVIFLiveVideoURL;
        private System.Windows.Forms.TextBox edONVIFURL;
        private System.Windows.Forms.TextBox edONVIFLogin;
        private System.Windows.Forms.Label label221_Copy;
        private System.Windows.Forms.TextBox edONVIFPassword;
        private System.Windows.Forms.Label label222_Copy;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.LinkLabel llVideoTutorials;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btPause;
    }
}
