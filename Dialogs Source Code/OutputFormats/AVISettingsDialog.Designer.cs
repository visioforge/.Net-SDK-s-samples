namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class AVISettingsDialog
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
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUncAudio = new System.Windows.Forms.CheckBox();
            this.cbDecodeToRGB = new System.Windows.Forms.CheckBox();
            this.cbUncVideo = new System.Windows.Forms.CheckBox();
            this.cbUseMP3InAVI = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAudioSettings = new System.Windows.Forms.Button();
            this.btVideoSettings = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChannels = new System.Windows.Forms.ComboBox();
            this.cbBPS = new System.Windows.Forms.ComboBox();
            this.cbAudioCodecs = new System.Windows.Forms.ComboBox();
            this.cbSampleRate = new System.Windows.Forms.ComboBox();
            this.cbVideoCodecs = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(214, 308);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 44;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbUncAudio);
            this.panel1.Controls.Add(this.cbDecodeToRGB);
            this.panel1.Controls.Add(this.cbUncVideo);
            this.panel1.Controls.Add(this.cbUseMP3InAVI);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btAudioSettings);
            this.panel1.Controls.Add(this.btVideoSettings);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbChannels);
            this.panel1.Controls.Add(this.cbBPS);
            this.panel1.Controls.Add(this.cbAudioCodecs);
            this.panel1.Controls.Add(this.cbSampleRate);
            this.panel1.Controls.Add(this.cbVideoCodecs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 301);
            this.panel1.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "(Can be configured in LAME dialog)";
            // 
            // cbUncAudio
            // 
            this.cbUncAudio.AutoSize = true;
            this.cbUncAudio.Location = new System.Drawing.Point(16, 150);
            this.cbUncAudio.Name = "cbUncAudio";
            this.cbUncAudio.Size = new System.Drawing.Size(126, 17);
            this.cbUncAudio.TabIndex = 59;
            this.cbUncAudio.Text = "Uncompressed audio";
            this.cbUncAudio.UseVisualStyleBackColor = true;
            // 
            // cbDecodeToRGB
            // 
            this.cbDecodeToRGB.AutoSize = true;
            this.cbDecodeToRGB.Location = new System.Drawing.Point(39, 76);
            this.cbDecodeToRGB.Name = "cbDecodeToRGB";
            this.cbDecodeToRGB.Size = new System.Drawing.Size(102, 17);
            this.cbDecodeToRGB.TabIndex = 58;
            this.cbDecodeToRGB.Text = "Decode to RGB";
            this.cbDecodeToRGB.UseVisualStyleBackColor = true;
            // 
            // cbUncVideo
            // 
            this.cbUncVideo.AutoSize = true;
            this.cbUncVideo.Location = new System.Drawing.Point(16, 55);
            this.cbUncVideo.Name = "cbUncVideo";
            this.cbUncVideo.Size = new System.Drawing.Size(126, 17);
            this.cbUncVideo.TabIndex = 57;
            this.cbUncVideo.Text = "Uncompressed video";
            this.cbUncVideo.UseVisualStyleBackColor = true;
            this.cbUncVideo.CheckedChanged += new System.EventHandler(this.cbUncVideo_CheckedChanged);
            // 
            // cbUseMP3InAVI
            // 
            this.cbUseMP3InAVI.AutoSize = true;
            this.cbUseMP3InAVI.Location = new System.Drawing.Point(16, 256);
            this.cbUseMP3InAVI.Name = "cbUseMP3InAVI";
            this.cbUseMP3InAVI.Size = new System.Drawing.Size(168, 17);
            this.cbUseMP3InAVI.TabIndex = 56;
            this.cbUseMP3InAVI.Text = "Use LAME for audio encoding";
            this.cbUseMP3InAVI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Audio codec";
            // 
            // btAudioSettings
            // 
            this.btAudioSettings.Location = new System.Drawing.Point(204, 121);
            this.btAudioSettings.Name = "btAudioSettings";
            this.btAudioSettings.Size = new System.Drawing.Size(62, 23);
            this.btAudioSettings.TabIndex = 54;
            this.btAudioSettings.Text = "Settings";
            this.btAudioSettings.UseVisualStyleBackColor = true;
            this.btAudioSettings.Click += new System.EventHandler(this.btAudioSettings_Click);
            // 
            // btVideoSettings
            // 
            this.btVideoSettings.Location = new System.Drawing.Point(204, 26);
            this.btVideoSettings.Name = "btVideoSettings";
            this.btVideoSettings.Size = new System.Drawing.Size(62, 23);
            this.btVideoSettings.TabIndex = 53;
            this.btVideoSettings.Text = "Settings";
            this.btVideoSettings.UseVisualStyleBackColor = true;
            this.btVideoSettings.Click += new System.EventHandler(this.btVideoSettings_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Sample rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "BPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Channels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Video codec";
            // 
            // cbChannels
            // 
            this.cbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannels.FormattingEnabled = true;
            this.cbChannels.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbChannels.Location = new System.Drawing.Point(90, 181);
            this.cbChannels.Name = "cbChannels";
            this.cbChannels.Size = new System.Drawing.Size(62, 21);
            this.cbChannels.TabIndex = 48;
            // 
            // cbBPS
            // 
            this.cbBPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBPS.FormattingEnabled = true;
            this.cbBPS.Items.AddRange(new object[] {
            "8",
            "16"});
            this.cbBPS.Location = new System.Drawing.Point(204, 181);
            this.cbBPS.Name = "cbBPS";
            this.cbBPS.Size = new System.Drawing.Size(62, 21);
            this.cbBPS.TabIndex = 47;
            // 
            // cbAudioCodecs
            // 
            this.cbAudioCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioCodecs.FormattingEnabled = true;
            this.cbAudioCodecs.Location = new System.Drawing.Point(16, 123);
            this.cbAudioCodecs.Name = "cbAudioCodecs";
            this.cbAudioCodecs.Size = new System.Drawing.Size(182, 21);
            this.cbAudioCodecs.TabIndex = 46;
            this.cbAudioCodecs.SelectedIndexChanged += new System.EventHandler(this.cbAudioCodecs_SelectedIndexChanged);
            // 
            // cbSampleRate
            // 
            this.cbSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSampleRate.FormattingEnabled = true;
            this.cbSampleRate.Items.AddRange(new object[] {
            "48000",
            "44100",
            "32000",
            "24000",
            "22050",
            "16000",
            "12000",
            "11025",
            "8000"});
            this.cbSampleRate.Location = new System.Drawing.Point(90, 213);
            this.cbSampleRate.Name = "cbSampleRate";
            this.cbSampleRate.Size = new System.Drawing.Size(62, 21);
            this.cbSampleRate.TabIndex = 45;
            // 
            // cbVideoCodecs
            // 
            this.cbVideoCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoCodecs.FormattingEnabled = true;
            this.cbVideoCodecs.Location = new System.Drawing.Point(16, 28);
            this.cbVideoCodecs.Name = "cbVideoCodecs";
            this.cbVideoCodecs.Size = new System.Drawing.Size(182, 21);
            this.cbVideoCodecs.TabIndex = 44;
            this.cbVideoCodecs.SelectedIndexChanged += new System.EventHandler(this.cbVideoCodecs_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 313);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 47;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AVISettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(281, 341);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AVISettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AVI / MKV settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbUncAudio;
        private System.Windows.Forms.CheckBox cbDecodeToRGB;
        private System.Windows.Forms.CheckBox cbUncVideo;
        private System.Windows.Forms.CheckBox cbUseMP3InAVI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAudioSettings;
        private System.Windows.Forms.Button btVideoSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChannels;
        private System.Windows.Forms.ComboBox cbBPS;
        private System.Windows.Forms.ComboBox cbAudioCodecs;
        private System.Windows.Forms.ComboBox cbSampleRate;
        private System.Windows.Forms.ComboBox cbVideoCodecs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}