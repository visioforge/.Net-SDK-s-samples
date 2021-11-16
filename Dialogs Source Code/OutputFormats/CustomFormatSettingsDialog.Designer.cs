namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class CustomFormatSettingsDialog
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
            this.cbCustomMuxFilterIsEncoder = new System.Windows.Forms.CheckBox();
            this.btCustomFilewriterSettings = new System.Windows.Forms.Button();
            this.cbCustomFilewriter = new System.Windows.Forms.ComboBox();
            this.cbUseSpecialFilewriter = new System.Windows.Forms.CheckBox();
            this.btCustomMuxerSettings = new System.Windows.Forms.Button();
            this.cbCustomMuxer = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btCustomDSFiltersASettings = new System.Windows.Forms.Button();
            this.cbCustomDSFilterA = new System.Windows.Forms.ComboBox();
            this.rbCustomUseDSFiltersCat = new System.Windows.Forms.RadioButton();
            this.btCustomAudioCodecSettings = new System.Windows.Forms.Button();
            this.cbCustomAudioCodecs = new System.Windows.Forms.ComboBox();
            this.rbCustomUseAudioCodecsCat = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btCustomDSFiltersVSettings = new System.Windows.Forms.Button();
            this.cbCustomDSFilterV = new System.Windows.Forms.ComboBox();
            this.rbCustomUseDSFiltersCap = new System.Windows.Forms.RadioButton();
            this.btCustomVideoCodecSettings = new System.Windows.Forms.Button();
            this.cbCustomVideoCodecs = new System.Windows.Forms.ComboBox();
            this.rbCustomUseVideoCodecsCat = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(241, 385);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 48;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbCustomMuxFilterIsEncoder);
            this.panel1.Controls.Add(this.btCustomFilewriterSettings);
            this.panel1.Controls.Add(this.cbCustomFilewriter);
            this.panel1.Controls.Add(this.cbUseSpecialFilewriter);
            this.panel1.Controls.Add(this.btCustomMuxerSettings);
            this.panel1.Controls.Add(this.cbCustomMuxer);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.groupBox11);
            this.panel1.Controls.Add(this.groupBox12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 379);
            this.panel1.TabIndex = 50;
            // 
            // cbCustomMuxFilterIsEncoder
            // 
            this.cbCustomMuxFilterIsEncoder.AutoSize = true;
            this.cbCustomMuxFilterIsEncoder.Location = new System.Drawing.Point(170, 270);
            this.cbCustomMuxFilterIsEncoder.Name = "cbCustomMuxFilterIsEncoder";
            this.cbCustomMuxFilterIsEncoder.Size = new System.Drawing.Size(120, 17);
            this.cbCustomMuxFilterIsEncoder.TabIndex = 25;
            this.cbCustomMuxFilterIsEncoder.Text = "Mux filter is encoder";
            this.cbCustomMuxFilterIsEncoder.UseVisualStyleBackColor = true;
            // 
            // btCustomFilewriterSettings
            // 
            this.btCustomFilewriterSettings.Enabled = false;
            this.btCustomFilewriterSettings.Location = new System.Drawing.Point(236, 338);
            this.btCustomFilewriterSettings.Name = "btCustomFilewriterSettings";
            this.btCustomFilewriterSettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomFilewriterSettings.TabIndex = 24;
            this.btCustomFilewriterSettings.Text = "Settings";
            this.btCustomFilewriterSettings.UseVisualStyleBackColor = true;
            this.btCustomFilewriterSettings.Click += new System.EventHandler(this.btCustomFilewriterSettings_Click);
            // 
            // cbCustomFilewriter
            // 
            this.cbCustomFilewriter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomFilewriter.Enabled = false;
            this.cbCustomFilewriter.FormattingEnabled = true;
            this.cbCustomFilewriter.Location = new System.Drawing.Point(17, 340);
            this.cbCustomFilewriter.Name = "cbCustomFilewriter";
            this.cbCustomFilewriter.Size = new System.Drawing.Size(213, 21);
            this.cbCustomFilewriter.TabIndex = 23;
            this.cbCustomFilewriter.SelectedIndexChanged += new System.EventHandler(this.cbCustomFilewriter_SelectedIndexChanged);
            // 
            // cbUseSpecialFilewriter
            // 
            this.cbUseSpecialFilewriter.AutoSize = true;
            this.cbUseSpecialFilewriter.Location = new System.Drawing.Point(17, 317);
            this.cbUseSpecialFilewriter.Name = "cbUseSpecialFilewriter";
            this.cbUseSpecialFilewriter.Size = new System.Drawing.Size(150, 17);
            this.cbUseSpecialFilewriter.TabIndex = 22;
            this.cbUseSpecialFilewriter.Text = "Use special FileWriter filter";
            this.cbUseSpecialFilewriter.UseVisualStyleBackColor = true;
            this.cbUseSpecialFilewriter.CheckedChanged += new System.EventHandler(this.cbUseSpecialFilewriter_CheckedChanged);
            // 
            // btCustomMuxerSettings
            // 
            this.btCustomMuxerSettings.Location = new System.Drawing.Point(236, 288);
            this.btCustomMuxerSettings.Name = "btCustomMuxerSettings";
            this.btCustomMuxerSettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomMuxerSettings.TabIndex = 21;
            this.btCustomMuxerSettings.Text = "Settings";
            this.btCustomMuxerSettings.UseVisualStyleBackColor = true;
            this.btCustomMuxerSettings.Click += new System.EventHandler(this.btCustomMuxerSettings_Click);
            // 
            // cbCustomMuxer
            // 
            this.cbCustomMuxer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomMuxer.FormattingEnabled = true;
            this.cbCustomMuxer.Location = new System.Drawing.Point(17, 290);
            this.cbCustomMuxer.Name = "cbCustomMuxer";
            this.cbCustomMuxer.Size = new System.Drawing.Size(213, 21);
            this.cbCustomMuxer.TabIndex = 20;
            this.cbCustomMuxer.SelectedIndexChanged += new System.EventHandler(this.cbCustomMuxer_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 275);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Mux filter";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btCustomDSFiltersASettings);
            this.groupBox11.Controls.Add(this.cbCustomDSFilterA);
            this.groupBox11.Controls.Add(this.rbCustomUseDSFiltersCat);
            this.groupBox11.Controls.Add(this.btCustomAudioCodecSettings);
            this.groupBox11.Controls.Add(this.cbCustomAudioCodecs);
            this.groupBox11.Controls.Add(this.rbCustomUseAudioCodecsCat);
            this.groupBox11.Location = new System.Drawing.Point(11, 147);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(285, 117);
            this.groupBox11.TabIndex = 18;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Audio encoder";
            // 
            // btCustomDSFiltersASettings
            // 
            this.btCustomDSFiltersASettings.Location = new System.Drawing.Point(225, 86);
            this.btCustomDSFiltersASettings.Name = "btCustomDSFiltersASettings";
            this.btCustomDSFiltersASettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomDSFiltersASettings.TabIndex = 5;
            this.btCustomDSFiltersASettings.Text = "Settings";
            this.btCustomDSFiltersASettings.UseVisualStyleBackColor = true;
            this.btCustomDSFiltersASettings.Click += new System.EventHandler(this.btCustomDSFiltersASettings_Click);
            // 
            // cbCustomDSFilterA
            // 
            this.cbCustomDSFilterA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomDSFilterA.FormattingEnabled = true;
            this.cbCustomDSFilterA.Location = new System.Drawing.Point(31, 88);
            this.cbCustomDSFilterA.Name = "cbCustomDSFilterA";
            this.cbCustomDSFilterA.Size = new System.Drawing.Size(188, 21);
            this.cbCustomDSFilterA.TabIndex = 4;
            this.cbCustomDSFilterA.SelectedIndexChanged += new System.EventHandler(this.cbCustomDSFilterA_SelectedIndexChanged);
            // 
            // rbCustomUseDSFiltersCat
            // 
            this.rbCustomUseDSFiltersCat.AutoSize = true;
            this.rbCustomUseDSFiltersCat.Location = new System.Drawing.Point(15, 70);
            this.rbCustomUseDSFiltersCat.Name = "rbCustomUseDSFiltersCat";
            this.rbCustomUseDSFiltersCat.Size = new System.Drawing.Size(186, 17);
            this.rbCustomUseDSFiltersCat.TabIndex = 3;
            this.rbCustomUseDSFiltersCat.Text = "Use \"DirectShow Filters\" category";
            this.rbCustomUseDSFiltersCat.UseVisualStyleBackColor = true;
            // 
            // btCustomAudioCodecSettings
            // 
            this.btCustomAudioCodecSettings.Location = new System.Drawing.Point(225, 37);
            this.btCustomAudioCodecSettings.Name = "btCustomAudioCodecSettings";
            this.btCustomAudioCodecSettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomAudioCodecSettings.TabIndex = 2;
            this.btCustomAudioCodecSettings.Text = "Settings";
            this.btCustomAudioCodecSettings.UseVisualStyleBackColor = true;
            this.btCustomAudioCodecSettings.Click += new System.EventHandler(this.btCustomAudioCodecSettings_Click);
            // 
            // cbCustomAudioCodecs
            // 
            this.cbCustomAudioCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomAudioCodecs.FormattingEnabled = true;
            this.cbCustomAudioCodecs.Location = new System.Drawing.Point(30, 39);
            this.cbCustomAudioCodecs.Name = "cbCustomAudioCodecs";
            this.cbCustomAudioCodecs.Size = new System.Drawing.Size(189, 21);
            this.cbCustomAudioCodecs.TabIndex = 1;
            this.cbCustomAudioCodecs.SelectedIndexChanged += new System.EventHandler(this.cbCustomAudioCodecs_SelectedIndexChanged);
            // 
            // rbCustomUseAudioCodecsCat
            // 
            this.rbCustomUseAudioCodecsCat.AutoSize = true;
            this.rbCustomUseAudioCodecsCat.Checked = true;
            this.rbCustomUseAudioCodecsCat.Location = new System.Drawing.Point(15, 19);
            this.rbCustomUseAudioCodecsCat.Name = "rbCustomUseAudioCodecsCat";
            this.rbCustomUseAudioCodecsCat.Size = new System.Drawing.Size(167, 17);
            this.rbCustomUseAudioCodecsCat.TabIndex = 0;
            this.rbCustomUseAudioCodecsCat.TabStop = true;
            this.rbCustomUseAudioCodecsCat.Text = "Use \"Audio Codecs\" category";
            this.rbCustomUseAudioCodecsCat.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btCustomDSFiltersVSettings);
            this.groupBox12.Controls.Add(this.cbCustomDSFilterV);
            this.groupBox12.Controls.Add(this.rbCustomUseDSFiltersCap);
            this.groupBox12.Controls.Add(this.btCustomVideoCodecSettings);
            this.groupBox12.Controls.Add(this.cbCustomVideoCodecs);
            this.groupBox12.Controls.Add(this.rbCustomUseVideoCodecsCat);
            this.groupBox12.Location = new System.Drawing.Point(11, 13);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(285, 128);
            this.groupBox12.TabIndex = 17;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Video encoder";
            // 
            // btCustomDSFiltersVSettings
            // 
            this.btCustomDSFiltersVSettings.Location = new System.Drawing.Point(225, 91);
            this.btCustomDSFiltersVSettings.Name = "btCustomDSFiltersVSettings";
            this.btCustomDSFiltersVSettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomDSFiltersVSettings.TabIndex = 5;
            this.btCustomDSFiltersVSettings.Text = "Settings";
            this.btCustomDSFiltersVSettings.UseVisualStyleBackColor = true;
            this.btCustomDSFiltersVSettings.Click += new System.EventHandler(this.btCustomDSFiltersVSettings_Click);
            // 
            // cbCustomDSFilterV
            // 
            this.cbCustomDSFilterV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomDSFilterV.FormattingEnabled = true;
            this.cbCustomDSFilterV.Location = new System.Drawing.Point(31, 93);
            this.cbCustomDSFilterV.Name = "cbCustomDSFilterV";
            this.cbCustomDSFilterV.Size = new System.Drawing.Size(188, 21);
            this.cbCustomDSFilterV.TabIndex = 4;
            this.cbCustomDSFilterV.SelectedIndexChanged += new System.EventHandler(this.cbCustomDSFilterV_SelectedIndexChanged);
            // 
            // rbCustomUseDSFiltersCap
            // 
            this.rbCustomUseDSFiltersCap.AutoSize = true;
            this.rbCustomUseDSFiltersCap.Location = new System.Drawing.Point(15, 70);
            this.rbCustomUseDSFiltersCap.Name = "rbCustomUseDSFiltersCap";
            this.rbCustomUseDSFiltersCap.Size = new System.Drawing.Size(186, 17);
            this.rbCustomUseDSFiltersCap.TabIndex = 3;
            this.rbCustomUseDSFiltersCap.Text = "Use \"DirectShow Filters\" category";
            this.rbCustomUseDSFiltersCap.UseVisualStyleBackColor = true;
            // 
            // btCustomVideoCodecSettings
            // 
            this.btCustomVideoCodecSettings.Location = new System.Drawing.Point(225, 40);
            this.btCustomVideoCodecSettings.Name = "btCustomVideoCodecSettings";
            this.btCustomVideoCodecSettings.Size = new System.Drawing.Size(54, 23);
            this.btCustomVideoCodecSettings.TabIndex = 2;
            this.btCustomVideoCodecSettings.Text = "Settings";
            this.btCustomVideoCodecSettings.UseVisualStyleBackColor = true;
            this.btCustomVideoCodecSettings.Click += new System.EventHandler(this.btCustomVideoCodecSettings_Click);
            // 
            // cbCustomVideoCodecs
            // 
            this.cbCustomVideoCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomVideoCodecs.FormattingEnabled = true;
            this.cbCustomVideoCodecs.Location = new System.Drawing.Point(31, 42);
            this.cbCustomVideoCodecs.Name = "cbCustomVideoCodecs";
            this.cbCustomVideoCodecs.Size = new System.Drawing.Size(188, 21);
            this.cbCustomVideoCodecs.TabIndex = 1;
            this.cbCustomVideoCodecs.SelectedIndexChanged += new System.EventHandler(this.cbCustomVideoCodecs_SelectedIndexChanged);
            // 
            // rbCustomUseVideoCodecsCat
            // 
            this.rbCustomUseVideoCodecsCat.AutoSize = true;
            this.rbCustomUseVideoCodecsCat.Checked = true;
            this.rbCustomUseVideoCodecsCat.Location = new System.Drawing.Point(15, 19);
            this.rbCustomUseVideoCodecsCat.Name = "rbCustomUseVideoCodecsCat";
            this.rbCustomUseVideoCodecsCat.Size = new System.Drawing.Size(167, 17);
            this.rbCustomUseVideoCodecsCat.TabIndex = 0;
            this.rbCustomUseVideoCodecsCat.TabStop = true;
            this.rbCustomUseVideoCodecsCat.Text = "Use \"Video Codecs\" category";
            this.rbCustomUseVideoCodecsCat.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 390);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 51;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CustomFormatSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(308, 418);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomFormatSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom format settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbCustomMuxFilterIsEncoder;
        private System.Windows.Forms.Button btCustomFilewriterSettings;
        private System.Windows.Forms.ComboBox cbCustomFilewriter;
        private System.Windows.Forms.CheckBox cbUseSpecialFilewriter;
        private System.Windows.Forms.Button btCustomMuxerSettings;
        private System.Windows.Forms.ComboBox cbCustomMuxer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btCustomDSFiltersASettings;
        private System.Windows.Forms.ComboBox cbCustomDSFilterA;
        private System.Windows.Forms.RadioButton rbCustomUseDSFiltersCat;
        private System.Windows.Forms.Button btCustomAudioCodecSettings;
        private System.Windows.Forms.ComboBox cbCustomAudioCodecs;
        private System.Windows.Forms.RadioButton rbCustomUseAudioCodecsCat;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btCustomDSFiltersVSettings;
        private System.Windows.Forms.ComboBox cbCustomDSFilterV;
        private System.Windows.Forms.RadioButton rbCustomUseDSFiltersCap;
        private System.Windows.Forms.Button btCustomVideoCodecSettings;
        private System.Windows.Forms.ComboBox cbCustomVideoCodecs;
        private System.Windows.Forms.RadioButton rbCustomUseVideoCodecsCat;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}