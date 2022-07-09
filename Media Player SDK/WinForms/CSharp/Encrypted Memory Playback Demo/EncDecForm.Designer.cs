namespace Encrypted_Memory_Playback_Demo
{
    partial class EncDecForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncDecForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.edSourceFile = new System.Windows.Forms.TextBox();
            this.btSaveFile = new System.Windows.Forms.Button();
            this.edDestFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.edKey = new System.Windows.Forms.TextBox();
            this.btEncrypt = new System.Windows.Forms.Button();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source file";
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(601, 46);
            this.btSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(34, 35);
            this.btSelectFile.TabIndex = 54;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // edSourceFile
            // 
            this.edSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edSourceFile.Location = new System.Drawing.Point(26, 50);
            this.edSourceFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edSourceFile.Name = "edSourceFile";
            this.edSourceFile.Size = new System.Drawing.Size(567, 26);
            this.edSourceFile.TabIndex = 53;
            this.edSourceFile.Text = "C:\\Samples\\!video.avi";
            // 
            // btSaveFile
            // 
            this.btSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveFile.Location = new System.Drawing.Point(601, 115);
            this.btSaveFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSaveFile.Name = "btSaveFile";
            this.btSaveFile.Size = new System.Drawing.Size(34, 35);
            this.btSaveFile.TabIndex = 57;
            this.btSaveFile.Text = "...";
            this.btSaveFile.UseVisualStyleBackColor = true;
            this.btSaveFile.Click += new System.EventHandler(this.btSaveFile_Click);
            // 
            // edDestFile
            // 
            this.edDestFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edDestFile.Location = new System.Drawing.Point(26, 119);
            this.edDestFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edDestFile.Name = "edDestFile";
            this.edDestFile.Size = new System.Drawing.Size(567, 26);
            this.edDestFile.TabIndex = 56;
            this.edDestFile.Text = "C:\\Samples\\!video.avi.enc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "Destination file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Key";
            // 
            // edKey
            // 
            this.edKey.Location = new System.Drawing.Point(26, 187);
            this.edKey.Name = "edKey";
            this.edKey.Size = new System.Drawing.Size(236, 26);
            this.edKey.TabIndex = 59;
            this.edKey.Text = "1234554321123450";
            // 
            // btEncrypt
            // 
            this.btEncrypt.Location = new System.Drawing.Point(26, 242);
            this.btEncrypt.Name = "btEncrypt";
            this.btEncrypt.Size = new System.Drawing.Size(99, 32);
            this.btEncrypt.TabIndex = 60;
            this.btEncrypt.Text = "Encrypt";
            this.btEncrypt.UseVisualStyleBackColor = true;
            this.btEncrypt.Click += new System.EventHandler(this.btEncrypt_Click);
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(131, 242);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(99, 32);
            this.btDecrypt.TabIndex = 61;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(258, 246);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(377, 23);
            this.pbProgress.TabIndex = 62;
            // 
            // EncDecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 299);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.btEncrypt);
            this.Controls.Add(this.edKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSaveFile);
            this.Controls.Add(this.edDestFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edSourceFile);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EncDecForm";
            this.Text = "Encryptor / Decryptor";
            this.Load += new System.EventHandler(this.EncDecForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox edSourceFile;
        private System.Windows.Forms.Button btSaveFile;
        private System.Windows.Forms.TextBox edDestFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edKey;
        private System.Windows.Forms.Button btEncrypt;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}