namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class M4ASettingsDialog
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
            this.label485 = new System.Windows.Forms.Label();
            this.cbM4AOutput = new System.Windows.Forms.ComboBox();
            this.label486 = new System.Windows.Forms.Label();
            this.cbM4ABitrate = new System.Windows.Forms.ComboBox();
            this.label487 = new System.Windows.Forms.Label();
            this.cbM4AObjectType = new System.Windows.Forms.ComboBox();
            this.label488 = new System.Windows.Forms.Label();
            this.cbM4AVersion = new System.Windows.Forms.ComboBox();
            this.label489 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(212, 168);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 54;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label485);
            this.panel1.Controls.Add(this.cbM4AOutput);
            this.panel1.Controls.Add(this.label486);
            this.panel1.Controls.Add(this.cbM4ABitrate);
            this.panel1.Controls.Add(this.label487);
            this.panel1.Controls.Add(this.cbM4AObjectType);
            this.panel1.Controls.Add(this.label488);
            this.panel1.Controls.Add(this.cbM4AVersion);
            this.panel1.Controls.Add(this.label489);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 162);
            this.panel1.TabIndex = 56;
            // 
            // label485
            // 
            this.label485.AutoSize = true;
            this.label485.Location = new System.Drawing.Point(231, 87);
            this.label485.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label485.Name = "label485";
            this.label485.Size = new System.Drawing.Size(31, 13);
            this.label485.TabIndex = 26;
            this.label485.Text = "Kbps";
            // 
            // cbM4AOutput
            // 
            this.cbM4AOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbM4AOutput.FormattingEnabled = true;
            this.cbM4AOutput.Items.AddRange(new object[] {
            "RAW",
            "ADTS"});
            this.cbM4AOutput.Location = new System.Drawing.Point(106, 123);
            this.cbM4AOutput.Margin = new System.Windows.Forms.Padding(2);
            this.cbM4AOutput.Name = "cbM4AOutput";
            this.cbM4AOutput.Size = new System.Drawing.Size(156, 21);
            this.cbM4AOutput.TabIndex = 25;
            // 
            // label486
            // 
            this.label486.AutoSize = true;
            this.label486.Location = new System.Drawing.Point(13, 125);
            this.label486.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label486.Name = "label486";
            this.label486.Size = new System.Drawing.Size(39, 13);
            this.label486.TabIndex = 24;
            this.label486.Text = "Output";
            // 
            // cbM4ABitrate
            // 
            this.cbM4ABitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbM4ABitrate.FormattingEnabled = true;
            this.cbM4ABitrate.Items.AddRange(new object[] {
            "32",
            "40",
            "48",
            "56",
            "64",
            "72",
            "80",
            "88",
            "96",
            "104",
            "112",
            "120",
            "128",
            "140",
            "160",
            "192",
            "224",
            "256"});
            this.cbM4ABitrate.Location = new System.Drawing.Point(106, 85);
            this.cbM4ABitrate.Margin = new System.Windows.Forms.Padding(2);
            this.cbM4ABitrate.Name = "cbM4ABitrate";
            this.cbM4ABitrate.Size = new System.Drawing.Size(121, 21);
            this.cbM4ABitrate.TabIndex = 23;
            // 
            // label487
            // 
            this.label487.AutoSize = true;
            this.label487.Location = new System.Drawing.Point(13, 87);
            this.label487.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label487.Name = "label487";
            this.label487.Size = new System.Drawing.Size(37, 13);
            this.label487.TabIndex = 22;
            this.label487.Text = "Bitrate";
            // 
            // cbM4AObjectType
            // 
            this.cbM4AObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbM4AObjectType.FormattingEnabled = true;
            this.cbM4AObjectType.Items.AddRange(new object[] {
            "Main",
            "Low complexity",
            "Scalable Sampling Rate",
            "Long Term Predictor"});
            this.cbM4AObjectType.Location = new System.Drawing.Point(106, 49);
            this.cbM4AObjectType.Margin = new System.Windows.Forms.Padding(2);
            this.cbM4AObjectType.Name = "cbM4AObjectType";
            this.cbM4AObjectType.Size = new System.Drawing.Size(156, 21);
            this.cbM4AObjectType.TabIndex = 21;
            // 
            // label488
            // 
            this.label488.AutoSize = true;
            this.label488.Location = new System.Drawing.Point(13, 51);
            this.label488.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label488.Name = "label488";
            this.label488.Size = new System.Drawing.Size(61, 13);
            this.label488.TabIndex = 20;
            this.label488.Text = "Object type";
            // 
            // cbM4AVersion
            // 
            this.cbM4AVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbM4AVersion.FormattingEnabled = true;
            this.cbM4AVersion.Items.AddRange(new object[] {
            "MPEG-4",
            "MPEG-2"});
            this.cbM4AVersion.Location = new System.Drawing.Point(106, 14);
            this.cbM4AVersion.Margin = new System.Windows.Forms.Padding(2);
            this.cbM4AVersion.Name = "cbM4AVersion";
            this.cbM4AVersion.Size = new System.Drawing.Size(156, 21);
            this.cbM4AVersion.TabIndex = 19;
            // 
            // label489
            // 
            this.label489.AutoSize = true;
            this.label489.Location = new System.Drawing.Point(13, 17);
            this.label489.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label489.Name = "label489";
            this.label489.Size = new System.Drawing.Size(75, 13);
            this.label489.TabIndex = 18;
            this.label489.Text = "MPEG version";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 173);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 57;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // M4ASettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(279, 202);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "M4ASettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "M4A (AAC) settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label485;
        private System.Windows.Forms.ComboBox cbM4AOutput;
        private System.Windows.Forms.Label label486;
        private System.Windows.Forms.ComboBox cbM4ABitrate;
        private System.Windows.Forms.Label label487;
        private System.Windows.Forms.ComboBox cbM4AObjectType;
        private System.Windows.Forms.Label label488;
        private System.Windows.Forms.ComboBox cbM4AVersion;
        private System.Windows.Forms.Label label489;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}