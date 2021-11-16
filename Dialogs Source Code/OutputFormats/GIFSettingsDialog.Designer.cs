namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    partial class GIFSettingsDialog
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
            this.label504 = new System.Windows.Forms.Label();
            this.edGIFHeight = new System.Windows.Forms.TextBox();
            this.edGIFWidth = new System.Windows.Forms.TextBox();
            this.label252 = new System.Windows.Forms.Label();
            this.edGIFFrameRate = new System.Windows.Forms.TextBox();
            this.label251 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(163, 154);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(55, 23);
            this.btClose.TabIndex = 56;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label504);
            this.panel1.Controls.Add(this.edGIFHeight);
            this.panel1.Controls.Add(this.edGIFWidth);
            this.panel1.Controls.Add(this.label252);
            this.panel1.Controls.Add(this.edGIFFrameRate);
            this.panel1.Controls.Add(this.label251);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 148);
            this.panel1.TabIndex = 58;
            // 
            // label504
            // 
            this.label504.AutoSize = true;
            this.label504.Location = new System.Drawing.Point(54, 81);
            this.label504.Name = "label504";
            this.label504.Size = new System.Drawing.Size(12, 13);
            this.label504.TabIndex = 11;
            this.label504.Text = "x";
            // 
            // edGIFHeight
            // 
            this.edGIFHeight.Location = new System.Drawing.Point(68, 78);
            this.edGIFHeight.Name = "edGIFHeight";
            this.edGIFHeight.Size = new System.Drawing.Size(36, 20);
            this.edGIFHeight.TabIndex = 10;
            this.edGIFHeight.Text = "0";
            // 
            // edGIFWidth
            // 
            this.edGIFWidth.Location = new System.Drawing.Point(17, 78);
            this.edGIFWidth.Name = "edGIFWidth";
            this.edGIFWidth.Size = new System.Drawing.Size(35, 20);
            this.edGIFWidth.TabIndex = 9;
            this.edGIFWidth.Text = "0";
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Location = new System.Drawing.Point(14, 62);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(90, 13);
            this.label252.TabIndex = 8;
            this.label252.Text = "Custom resolution";
            // 
            // edGIFFrameRate
            // 
            this.edGIFFrameRate.Location = new System.Drawing.Point(17, 29);
            this.edGIFFrameRate.Name = "edGIFFrameRate";
            this.edGIFFrameRate.Size = new System.Drawing.Size(87, 20);
            this.edGIFFrameRate.TabIndex = 7;
            this.edGIFFrameRate.Text = "3";
            // 
            // label251
            // 
            this.label251.AutoSize = true;
            this.label251.Location = new System.Drawing.Point(14, 13);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(57, 13);
            this.label251.TabIndex = 6;
            this.label251.Text = "Frame rate";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 159);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 59;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // GIFSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(230, 187);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GIFSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GIF settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label504;
        private System.Windows.Forms.TextBox edGIFHeight;
        private System.Windows.Forms.TextBox edGIFWidth;
        private System.Windows.Forms.Label label252;
        private System.Windows.Forms.TextBox edGIFFrameRate;
        private System.Windows.Forms.Label label251;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}