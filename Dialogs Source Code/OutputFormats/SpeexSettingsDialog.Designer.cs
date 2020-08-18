namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class SpeexSettingsDialog
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
            this.cbSpeexDenoise = new System.Windows.Forms.CheckBox();
            this.cbSpeexAGC = new System.Windows.Forms.CheckBox();
            this.cbSpeexVAD = new System.Windows.Forms.CheckBox();
            this.cbSpeexDTX = new System.Windows.Forms.CheckBox();
            this.tbSpeexComplexity = new System.Windows.Forms.TrackBar();
            this.label409 = new System.Windows.Forms.Label();
            this.tbSpeexMaxBitrate = new System.Windows.Forms.TrackBar();
            this.label410 = new System.Windows.Forms.Label();
            this.tbSpeexBitrate = new System.Windows.Forms.TrackBar();
            this.label411 = new System.Windows.Forms.Label();
            this.tbSpeexQuality = new System.Windows.Forms.TrackBar();
            this.label412 = new System.Windows.Forms.Label();
            this.cbSpeexBitrateControl = new System.Windows.Forms.ComboBox();
            this.label413 = new System.Windows.Forms.Label();
            this.cbSpeexMode = new System.Windows.Forms.ComboBox();
            this.label414 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexComplexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexMaxBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(216, 260);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 52;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbSpeexDenoise);
            this.panel1.Controls.Add(this.cbSpeexAGC);
            this.panel1.Controls.Add(this.cbSpeexVAD);
            this.panel1.Controls.Add(this.cbSpeexDTX);
            this.panel1.Controls.Add(this.tbSpeexComplexity);
            this.panel1.Controls.Add(this.label409);
            this.panel1.Controls.Add(this.tbSpeexMaxBitrate);
            this.panel1.Controls.Add(this.label410);
            this.panel1.Controls.Add(this.tbSpeexBitrate);
            this.panel1.Controls.Add(this.label411);
            this.panel1.Controls.Add(this.tbSpeexQuality);
            this.panel1.Controls.Add(this.label412);
            this.panel1.Controls.Add(this.cbSpeexBitrateControl);
            this.panel1.Controls.Add(this.label413);
            this.panel1.Controls.Add(this.cbSpeexMode);
            this.panel1.Controls.Add(this.label414);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 254);
            this.panel1.TabIndex = 54;
            // 
            // cbSpeexDenoise
            // 
            this.cbSpeexDenoise.AutoSize = true;
            this.cbSpeexDenoise.Location = new System.Drawing.Point(198, 218);
            this.cbSpeexDenoise.Name = "cbSpeexDenoise";
            this.cbSpeexDenoise.Size = new System.Drawing.Size(65, 17);
            this.cbSpeexDenoise.TabIndex = 47;
            this.cbSpeexDenoise.Text = "Denoise";
            this.cbSpeexDenoise.UseVisualStyleBackColor = true;
            // 
            // cbSpeexAGC
            // 
            this.cbSpeexAGC.AutoSize = true;
            this.cbSpeexAGC.Location = new System.Drawing.Point(147, 218);
            this.cbSpeexAGC.Name = "cbSpeexAGC";
            this.cbSpeexAGC.Size = new System.Drawing.Size(48, 17);
            this.cbSpeexAGC.TabIndex = 46;
            this.cbSpeexAGC.Text = "AGC";
            this.cbSpeexAGC.UseVisualStyleBackColor = true;
            // 
            // cbSpeexVAD
            // 
            this.cbSpeexVAD.AutoSize = true;
            this.cbSpeexVAD.Location = new System.Drawing.Point(75, 218);
            this.cbSpeexVAD.Name = "cbSpeexVAD";
            this.cbSpeexVAD.Size = new System.Drawing.Size(48, 17);
            this.cbSpeexVAD.TabIndex = 45;
            this.cbSpeexVAD.Text = "VAD";
            this.cbSpeexVAD.UseVisualStyleBackColor = true;
            // 
            // cbSpeexDTX
            // 
            this.cbSpeexDTX.AutoSize = true;
            this.cbSpeexDTX.Location = new System.Drawing.Point(15, 218);
            this.cbSpeexDTX.Name = "cbSpeexDTX";
            this.cbSpeexDTX.Size = new System.Drawing.Size(48, 17);
            this.cbSpeexDTX.TabIndex = 44;
            this.cbSpeexDTX.Text = "DTX";
            this.cbSpeexDTX.UseVisualStyleBackColor = true;
            // 
            // tbSpeexComplexity
            // 
            this.tbSpeexComplexity.Location = new System.Drawing.Point(147, 154);
            this.tbSpeexComplexity.Minimum = 1;
            this.tbSpeexComplexity.Name = "tbSpeexComplexity";
            this.tbSpeexComplexity.Size = new System.Drawing.Size(121, 45);
            this.tbSpeexComplexity.TabIndex = 43;
            this.tbSpeexComplexity.Value = 3;
            // 
            // label409
            // 
            this.label409.AutoSize = true;
            this.label409.Location = new System.Drawing.Point(144, 138);
            this.label409.Name = "label409";
            this.label409.Size = new System.Drawing.Size(57, 13);
            this.label409.TabIndex = 42;
            this.label409.Text = "Complexity";
            // 
            // tbSpeexMaxBitrate
            // 
            this.tbSpeexMaxBitrate.Location = new System.Drawing.Point(147, 83);
            this.tbSpeexMaxBitrate.Maximum = 96;
            this.tbSpeexMaxBitrate.Minimum = 2;
            this.tbSpeexMaxBitrate.Name = "tbSpeexMaxBitrate";
            this.tbSpeexMaxBitrate.Size = new System.Drawing.Size(121, 45);
            this.tbSpeexMaxBitrate.SmallChange = 2;
            this.tbSpeexMaxBitrate.TabIndex = 41;
            this.tbSpeexMaxBitrate.TickFrequency = 2;
            this.tbSpeexMaxBitrate.Value = 96;
            // 
            // label410
            // 
            this.label410.AutoSize = true;
            this.label410.Location = new System.Drawing.Point(144, 67);
            this.label410.Name = "label410";
            this.label410.Size = new System.Drawing.Size(59, 13);
            this.label410.TabIndex = 40;
            this.label410.Text = "Max bitrate";
            // 
            // tbSpeexBitrate
            // 
            this.tbSpeexBitrate.Location = new System.Drawing.Point(15, 83);
            this.tbSpeexBitrate.Maximum = 96;
            this.tbSpeexBitrate.Minimum = 2;
            this.tbSpeexBitrate.Name = "tbSpeexBitrate";
            this.tbSpeexBitrate.Size = new System.Drawing.Size(121, 45);
            this.tbSpeexBitrate.SmallChange = 2;
            this.tbSpeexBitrate.TabIndex = 39;
            this.tbSpeexBitrate.TickFrequency = 2;
            this.tbSpeexBitrate.Value = 48;
            // 
            // label411
            // 
            this.label411.AutoSize = true;
            this.label411.Location = new System.Drawing.Point(12, 67);
            this.label411.Name = "label411";
            this.label411.Size = new System.Drawing.Size(37, 13);
            this.label411.TabIndex = 38;
            this.label411.Text = "Bitrate";
            // 
            // tbSpeexQuality
            // 
            this.tbSpeexQuality.Location = new System.Drawing.Point(15, 154);
            this.tbSpeexQuality.Minimum = 1;
            this.tbSpeexQuality.Name = "tbSpeexQuality";
            this.tbSpeexQuality.Size = new System.Drawing.Size(121, 45);
            this.tbSpeexQuality.TabIndex = 37;
            this.tbSpeexQuality.Value = 8;
            // 
            // label412
            // 
            this.label412.AutoSize = true;
            this.label412.Location = new System.Drawing.Point(12, 138);
            this.label412.Name = "label412";
            this.label412.Size = new System.Drawing.Size(39, 13);
            this.label412.TabIndex = 36;
            this.label412.Text = "Quality";
            // 
            // cbSpeexBitrateControl
            // 
            this.cbSpeexBitrateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeexBitrateControl.FormattingEnabled = true;
            this.cbSpeexBitrateControl.Items.AddRange(new object[] {
            "VBR quality",
            "VBR bitrate",
            "CBR quality",
            "CBR bitrate",
            "ABR"});
            this.cbSpeexBitrateControl.Location = new System.Drawing.Point(147, 28);
            this.cbSpeexBitrateControl.Name = "cbSpeexBitrateControl";
            this.cbSpeexBitrateControl.Size = new System.Drawing.Size(121, 21);
            this.cbSpeexBitrateControl.TabIndex = 35;
            // 
            // label413
            // 
            this.label413.AutoSize = true;
            this.label413.Location = new System.Drawing.Point(144, 12);
            this.label413.Name = "label413";
            this.label413.Size = new System.Drawing.Size(72, 13);
            this.label413.TabIndex = 34;
            this.label413.Text = "Bitrate control";
            // 
            // cbSpeexMode
            // 
            this.cbSpeexMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeexMode.FormattingEnabled = true;
            this.cbSpeexMode.Items.AddRange(new object[] {
            "Auto",
            "Narrowband",
            "Wideband",
            "Ultra wideband"});
            this.cbSpeexMode.Location = new System.Drawing.Point(15, 28);
            this.cbSpeexMode.Name = "cbSpeexMode";
            this.cbSpeexMode.Size = new System.Drawing.Size(121, 21);
            this.cbSpeexMode.TabIndex = 33;
            // 
            // label414
            // 
            this.label414.AutoSize = true;
            this.label414.Location = new System.Drawing.Point(12, 12);
            this.label414.Name = "label414";
            this.label414.Size = new System.Drawing.Size(34, 13);
            this.label414.TabIndex = 32;
            this.label414.Text = "Mode";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 265);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 55;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SpeexSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(283, 295);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpeexSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Speex settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexComplexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexMaxBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeexQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSpeexDenoise;
        private System.Windows.Forms.CheckBox cbSpeexAGC;
        private System.Windows.Forms.CheckBox cbSpeexVAD;
        private System.Windows.Forms.CheckBox cbSpeexDTX;
        private System.Windows.Forms.TrackBar tbSpeexComplexity;
        private System.Windows.Forms.Label label409;
        private System.Windows.Forms.TrackBar tbSpeexMaxBitrate;
        private System.Windows.Forms.Label label410;
        private System.Windows.Forms.TrackBar tbSpeexBitrate;
        private System.Windows.Forms.Label label411;
        private System.Windows.Forms.TrackBar tbSpeexQuality;
        private System.Windows.Forms.Label label412;
        private System.Windows.Forms.ComboBox cbSpeexBitrateControl;
        private System.Windows.Forms.Label label413;
        private System.Windows.Forms.ComboBox cbSpeexMode;
        private System.Windows.Forms.Label label414;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}