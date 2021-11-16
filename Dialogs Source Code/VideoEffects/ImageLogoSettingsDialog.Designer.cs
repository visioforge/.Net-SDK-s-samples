namespace VisioForge.Controls.UI.Dialogs.VideoEffects
{
    partial class ImageLogoSettingsDialog
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
            this.btUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.pnImageLogoColorKey = new System.Windows.Forms.Panel();
            this.cbImageLogoUseColorKey = new System.Windows.Forms.CheckBox();
            this.label154 = new System.Windows.Forms.Label();
            this.tbImageLogoTransp = new System.Windows.Forms.TrackBar();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.cbImageLogoShowAlways = new System.Windows.Forms.CheckBox();
            this.edImageLogoStopTime = new System.Windows.Forms.TextBox();
            this.lbGraphicLogoStopTime = new System.Windows.Forms.Label();
            this.edImageLogoStartTime = new System.Windows.Forms.TextBox();
            this.lbGraphicLogoStartTime = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.edImageLogoTop = new System.Windows.Forms.TextBox();
            this.label155 = new System.Windows.Forms.Label();
            this.edImageLogoLeft = new System.Windows.Forms.TextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.btSelectImage = new System.Windows.Forms.Button();
            this.label157 = new System.Windows.Forms.Label();
            this.edImageLogoFilename = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageLogoTransp)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(468, 218);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 66;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(11, 218);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 65;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.imgPreview);
            this.panel1.Controls.Add(this.pnImageLogoColorKey);
            this.panel1.Controls.Add(this.cbImageLogoUseColorKey);
            this.panel1.Controls.Add(this.label154);
            this.panel1.Controls.Add(this.tbImageLogoTransp);
            this.panel1.Controls.Add(this.groupBox22);
            this.panel1.Controls.Add(this.groupBox23);
            this.panel1.Controls.Add(this.btSelectImage);
            this.panel1.Controls.Add(this.label157);
            this.panel1.Controls.Add(this.edImageLogoFilename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 212);
            this.panel1.TabIndex = 67;
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.Black;
            this.imgPreview.Location = new System.Drawing.Point(302, 12);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(241, 182);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPreview.TabIndex = 74;
            this.imgPreview.TabStop = false;
            // 
            // pnImageLogoColorKey
            // 
            this.pnImageLogoColorKey.BackColor = System.Drawing.Color.Fuchsia;
            this.pnImageLogoColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnImageLogoColorKey.Location = new System.Drawing.Point(246, 153);
            this.pnImageLogoColorKey.Name = "pnImageLogoColorKey";
            this.pnImageLogoColorKey.Size = new System.Drawing.Size(24, 24);
            this.pnImageLogoColorKey.TabIndex = 73;
            this.pnImageLogoColorKey.Click += new System.EventHandler(this.pnGraphicLogoColorKey_Click);
            // 
            // cbImageLogoUseColorKey
            // 
            this.cbImageLogoUseColorKey.AutoSize = true;
            this.cbImageLogoUseColorKey.Location = new System.Drawing.Point(132, 158);
            this.cbImageLogoUseColorKey.Name = "cbImageLogoUseColorKey";
            this.cbImageLogoUseColorKey.Size = new System.Drawing.Size(91, 17);
            this.cbImageLogoUseColorKey.TabIndex = 72;
            this.cbImageLogoUseColorKey.Text = "Use color key";
            this.cbImageLogoUseColorKey.UseVisualStyleBackColor = true;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(16, 134);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(72, 13);
            this.label154.TabIndex = 71;
            this.label154.Text = "Transparency";
            // 
            // tbImageLogoTransp
            // 
            this.tbImageLogoTransp.BackColor = System.Drawing.SystemColors.Window;
            this.tbImageLogoTransp.Location = new System.Drawing.Point(11, 149);
            this.tbImageLogoTransp.Maximum = 255;
            this.tbImageLogoTransp.Name = "tbImageLogoTransp";
            this.tbImageLogoTransp.Size = new System.Drawing.Size(104, 45);
            this.tbImageLogoTransp.TabIndex = 70;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.cbImageLogoShowAlways);
            this.groupBox22.Controls.Add(this.edImageLogoStopTime);
            this.groupBox22.Controls.Add(this.lbGraphicLogoStopTime);
            this.groupBox22.Controls.Add(this.edImageLogoStartTime);
            this.groupBox22.Controls.Add(this.lbGraphicLogoStartTime);
            this.groupBox22.Location = new System.Drawing.Point(116, 45);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(173, 76);
            this.groupBox22.TabIndex = 69;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Duration";
            // 
            // cbImageLogoShowAlways
            // 
            this.cbImageLogoShowAlways.AutoSize = true;
            this.cbImageLogoShowAlways.Checked = true;
            this.cbImageLogoShowAlways.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImageLogoShowAlways.Location = new System.Drawing.Point(13, 48);
            this.cbImageLogoShowAlways.Name = "cbImageLogoShowAlways";
            this.cbImageLogoShowAlways.Size = new System.Drawing.Size(88, 17);
            this.cbImageLogoShowAlways.TabIndex = 35;
            this.cbImageLogoShowAlways.Text = "Show always";
            this.cbImageLogoShowAlways.UseVisualStyleBackColor = true;
            this.cbImageLogoShowAlways.CheckedChanged += new System.EventHandler(this.cbImageLogoShowAlways_CheckedChanged);
            // 
            // edImageLogoStopTime
            // 
            this.edImageLogoStopTime.Enabled = false;
            this.edImageLogoStopTime.Location = new System.Drawing.Point(117, 19);
            this.edImageLogoStopTime.Name = "edImageLogoStopTime";
            this.edImageLogoStopTime.Size = new System.Drawing.Size(39, 20);
            this.edImageLogoStopTime.TabIndex = 34;
            this.edImageLogoStopTime.Text = "10000";
            this.edImageLogoStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbGraphicLogoStopTime
            // 
            this.lbGraphicLogoStopTime.AutoSize = true;
            this.lbGraphicLogoStopTime.Enabled = false;
            this.lbGraphicLogoStopTime.Location = new System.Drawing.Point(88, 22);
            this.lbGraphicLogoStopTime.Name = "lbGraphicLogoStopTime";
            this.lbGraphicLogoStopTime.Size = new System.Drawing.Size(29, 13);
            this.lbGraphicLogoStopTime.TabIndex = 33;
            this.lbGraphicLogoStopTime.Text = "Stop";
            // 
            // edImageLogoStartTime
            // 
            this.edImageLogoStartTime.Enabled = false;
            this.edImageLogoStartTime.Location = new System.Drawing.Point(43, 19);
            this.edImageLogoStartTime.Name = "edImageLogoStartTime";
            this.edImageLogoStartTime.Size = new System.Drawing.Size(39, 20);
            this.edImageLogoStartTime.TabIndex = 32;
            this.edImageLogoStartTime.Text = "0";
            this.edImageLogoStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbGraphicLogoStartTime
            // 
            this.lbGraphicLogoStartTime.AutoSize = true;
            this.lbGraphicLogoStartTime.Enabled = false;
            this.lbGraphicLogoStartTime.Location = new System.Drawing.Point(10, 22);
            this.lbGraphicLogoStartTime.Name = "lbGraphicLogoStartTime";
            this.lbGraphicLogoStartTime.Size = new System.Drawing.Size(29, 13);
            this.lbGraphicLogoStartTime.TabIndex = 31;
            this.lbGraphicLogoStartTime.Text = "Start";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.edImageLogoTop);
            this.groupBox23.Controls.Add(this.label155);
            this.groupBox23.Controls.Add(this.edImageLogoLeft);
            this.groupBox23.Controls.Add(this.label156);
            this.groupBox23.Location = new System.Drawing.Point(13, 45);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(97, 76);
            this.groupBox23.TabIndex = 68;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Position";
            // 
            // edImageLogoTop
            // 
            this.edImageLogoTop.Location = new System.Drawing.Point(47, 45);
            this.edImageLogoTop.Name = "edImageLogoTop";
            this.edImageLogoTop.Size = new System.Drawing.Size(39, 20);
            this.edImageLogoTop.TabIndex = 32;
            this.edImageLogoTop.Text = "50";
            this.edImageLogoTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(14, 48);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(26, 13);
            this.label155.TabIndex = 31;
            this.label155.Text = "Top";
            // 
            // edImageLogoLeft
            // 
            this.edImageLogoLeft.Location = new System.Drawing.Point(47, 19);
            this.edImageLogoLeft.Name = "edImageLogoLeft";
            this.edImageLogoLeft.Size = new System.Drawing.Size(39, 20);
            this.edImageLogoLeft.TabIndex = 30;
            this.edImageLogoLeft.Text = "50";
            this.edImageLogoLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(14, 22);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(25, 13);
            this.label156.TabIndex = 29;
            this.label156.Text = "Left";
            // 
            // btSelectImage
            // 
            this.btSelectImage.Location = new System.Drawing.Point(265, 10);
            this.btSelectImage.Name = "btSelectImage";
            this.btSelectImage.Size = new System.Drawing.Size(24, 23);
            this.btSelectImage.TabIndex = 67;
            this.btSelectImage.Text = "...";
            this.btSelectImage.UseVisualStyleBackColor = true;
            this.btSelectImage.Click += new System.EventHandler(this.btSelectImage_Click);
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(12, 15);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(52, 13);
            this.label157.TabIndex = 66;
            this.label157.Text = "File name";
            // 
            // edImageLogoFilename
            // 
            this.edImageLogoFilename.Location = new System.Drawing.Point(70, 12);
            this.edImageLogoFilename.Name = "edImageLogoFilename";
            this.edImageLogoFilename.Size = new System.Drawing.Size(189, 20);
            this.edImageLogoFilename.TabIndex = 65;
            this.edImageLogoFilename.Text = "c:\\samples\\!logo32.png";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(204, 223);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 13);
            this.linkLabel1.TabIndex = 68;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get dialog source code";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ImageLogoSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 253);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageLogoSettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Image logo settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageLogoTransp)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.Panel pnImageLogoColorKey;
        private System.Windows.Forms.CheckBox cbImageLogoUseColorKey;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.TrackBar tbImageLogoTransp;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckBox cbImageLogoShowAlways;
        private System.Windows.Forms.TextBox edImageLogoStopTime;
        private System.Windows.Forms.Label lbGraphicLogoStopTime;
        private System.Windows.Forms.TextBox edImageLogoStartTime;
        private System.Windows.Forms.Label lbGraphicLogoStartTime;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.TextBox edImageLogoTop;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.TextBox edImageLogoLeft;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Button btSelectImage;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.TextBox edImageLogoFilename;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}