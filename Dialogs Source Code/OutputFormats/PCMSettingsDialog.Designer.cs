namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class PCMSettingsDialog
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
            this.btAudioSettings2 = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.cbAudioCodecs2 = new System.Windows.Forms.ComboBox();
            this.cbSampleRate2 = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.cbBPS2 = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.cbChannels2 = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(208, 152);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 46;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btAudioSettings2);
            this.panel1.Controls.Add(this.label67);
            this.panel1.Controls.Add(this.cbAudioCodecs2);
            this.panel1.Controls.Add(this.cbSampleRate2);
            this.panel1.Controls.Add(this.label68);
            this.panel1.Controls.Add(this.cbBPS2);
            this.panel1.Controls.Add(this.label69);
            this.panel1.Controls.Add(this.cbChannels2);
            this.panel1.Controls.Add(this.label70);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 146);
            this.panel1.TabIndex = 48;
            // 
            // btAudioSettings2
            // 
            this.btAudioSettings2.Location = new System.Drawing.Point(198, 109);
            this.btAudioSettings2.Name = "btAudioSettings2";
            this.btAudioSettings2.Size = new System.Drawing.Size(65, 23);
            this.btAudioSettings2.TabIndex = 52;
            this.btAudioSettings2.Text = "Settings";
            this.btAudioSettings2.UseVisualStyleBackColor = true;
            this.btAudioSettings2.Click += new System.EventHandler(this.btAudioSettings2_Click);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(12, 91);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(38, 13);
            this.label67.TabIndex = 51;
            this.label67.Text = "Codec";
            // 
            // cbAudioCodecs2
            // 
            this.cbAudioCodecs2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioCodecs2.FormattingEnabled = true;
            this.cbAudioCodecs2.Location = new System.Drawing.Point(15, 109);
            this.cbAudioCodecs2.Name = "cbAudioCodecs2";
            this.cbAudioCodecs2.Size = new System.Drawing.Size(177, 21);
            this.cbAudioCodecs2.TabIndex = 50;
            this.cbAudioCodecs2.SelectedIndexChanged += new System.EventHandler(this.cbAudioCodecs2_SelectedIndexChanged);
            // 
            // cbSampleRate2
            // 
            this.cbSampleRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSampleRate2.FormattingEnabled = true;
            this.cbSampleRate2.Items.AddRange(new object[] {
            "48000",
            "44100",
            "32000",
            "22050",
            "16000",
            "11025",
            "8000"});
            this.cbSampleRate2.Location = new System.Drawing.Point(81, 50);
            this.cbSampleRate2.Name = "cbSampleRate2";
            this.cbSampleRate2.Size = new System.Drawing.Size(65, 21);
            this.cbSampleRate2.TabIndex = 49;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(12, 53);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(63, 13);
            this.label68.TabIndex = 48;
            this.label68.Text = "Sample rate";
            // 
            // cbBPS2
            // 
            this.cbBPS2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBPS2.FormattingEnabled = true;
            this.cbBPS2.Items.AddRange(new object[] {
            "16",
            "8"});
            this.cbBPS2.Location = new System.Drawing.Point(198, 13);
            this.cbBPS2.Name = "cbBPS2";
            this.cbBPS2.Size = new System.Drawing.Size(65, 21);
            this.cbBPS2.TabIndex = 47;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(164, 16);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(28, 13);
            this.label69.TabIndex = 46;
            this.label69.Text = "BPS";
            // 
            // cbChannels2
            // 
            this.cbChannels2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannels2.FormattingEnabled = true;
            this.cbChannels2.Items.AddRange(new object[] {
            "2",
            "1"});
            this.cbChannels2.Location = new System.Drawing.Point(81, 13);
            this.cbChannels2.Name = "cbChannels2";
            this.cbChannels2.Size = new System.Drawing.Size(65, 21);
            this.cbChannels2.TabIndex = 45;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(12, 16);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(51, 13);
            this.label70.TabIndex = 44;
            this.label70.Text = "Channels";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 157);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 49;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PCMSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(274, 184);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PCMSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PCM / ACM settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAudioSettings2;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.ComboBox cbAudioCodecs2;
        private System.Windows.Forms.ComboBox cbSampleRate2;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.ComboBox cbBPS2;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ComboBox cbChannels2;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}