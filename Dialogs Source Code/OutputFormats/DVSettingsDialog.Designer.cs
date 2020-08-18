namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class DVSettingsDialog
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbDVType2 = new System.Windows.Forms.RadioButton();
            this.rbDVType1 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbDVNTSC = new System.Windows.Forms.RadioButton();
            this.rbDVPAL = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cbDVChannels = new System.Windows.Forms.ComboBox();
            this.cbDVSampleRate = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(197, 250);
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
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 244);
            this.panel1.TabIndex = 48;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbDVType2);
            this.groupBox6.Controls.Add(this.rbDVType1);
            this.groupBox6.Location = new System.Drawing.Point(14, 172);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(238, 58);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "File format";
            // 
            // rbDVType2
            // 
            this.rbDVType2.AutoSize = true;
            this.rbDVType2.Location = new System.Drawing.Point(117, 25);
            this.rbDVType2.Name = "rbDVType2";
            this.rbDVType2.Size = new System.Drawing.Size(76, 17);
            this.rbDVType2.TabIndex = 1;
            this.rbDVType2.Text = "Type-2 DV";
            this.rbDVType2.UseVisualStyleBackColor = true;
            // 
            // rbDVType1
            // 
            this.rbDVType1.AutoSize = true;
            this.rbDVType1.Checked = true;
            this.rbDVType1.Location = new System.Drawing.Point(19, 25);
            this.rbDVType1.Name = "rbDVType1";
            this.rbDVType1.Size = new System.Drawing.Size(76, 17);
            this.rbDVType1.TabIndex = 0;
            this.rbDVType1.TabStop = true;
            this.rbDVType1.Text = "Type-1 DV";
            this.rbDVType1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbDVNTSC);
            this.groupBox5.Controls.Add(this.rbDVPAL);
            this.groupBox5.Location = new System.Drawing.Point(14, 108);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 58);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Video format";
            // 
            // rbDVNTSC
            // 
            this.rbDVNTSC.AutoSize = true;
            this.rbDVNTSC.Location = new System.Drawing.Point(117, 25);
            this.rbDVNTSC.Name = "rbDVNTSC";
            this.rbDVNTSC.Size = new System.Drawing.Size(54, 17);
            this.rbDVNTSC.TabIndex = 1;
            this.rbDVNTSC.Text = "NTSC";
            this.rbDVNTSC.UseVisualStyleBackColor = true;
            // 
            // rbDVPAL
            // 
            this.rbDVPAL.AutoSize = true;
            this.rbDVPAL.Checked = true;
            this.rbDVPAL.Location = new System.Drawing.Point(19, 25);
            this.rbDVPAL.Name = "rbDVPAL";
            this.rbDVPAL.Size = new System.Drawing.Size(45, 17);
            this.rbDVPAL.TabIndex = 0;
            this.rbDVPAL.TabStop = true;
            this.rbDVPAL.Text = "PAL";
            this.rbDVPAL.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.cbDVChannels);
            this.groupBox4.Controls.Add(this.cbDVSampleRate);
            this.groupBox4.Location = new System.Drawing.Point(14, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 88);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio settings";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 59);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 28;
            this.label30.Text = "Sample rate";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(51, 13);
            this.label31.TabIndex = 27;
            this.label31.Text = "Channels";
            // 
            // cbDVChannels
            // 
            this.cbDVChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVChannels.FormattingEnabled = true;
            this.cbDVChannels.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbDVChannels.Location = new System.Drawing.Point(85, 24);
            this.cbDVChannels.Name = "cbDVChannels";
            this.cbDVChannels.Size = new System.Drawing.Size(63, 21);
            this.cbDVChannels.TabIndex = 26;
            // 
            // cbDVSampleRate
            // 
            this.cbDVSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVSampleRate.FormattingEnabled = true;
            this.cbDVSampleRate.Items.AddRange(new object[] {
            "48000",
            "44100",
            "32000",
            "24000",
            "22050",
            "16000",
            "12000",
            "11025",
            "8000"});
            this.cbDVSampleRate.Location = new System.Drawing.Point(85, 56);
            this.cbDVSampleRate.Name = "cbDVSampleRate";
            this.cbDVSampleRate.Size = new System.Drawing.Size(63, 21);
            this.cbDVSampleRate.TabIndex = 25;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 255);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 49;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // DVSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(264, 282);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DVSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DV settings";
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbDVType2;
        private System.Windows.Forms.RadioButton rbDVType1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbDVNTSC;
        private System.Windows.Forms.RadioButton rbDVPAL;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cbDVChannels;
        private System.Windows.Forms.ComboBox cbDVSampleRate;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}