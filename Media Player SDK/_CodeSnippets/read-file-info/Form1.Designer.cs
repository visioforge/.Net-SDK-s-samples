namespace read_file_info
{
    partial class Form1
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
            this.btOpenFile = new System.Windows.Forms.Button();
            this.mmInfo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbIsPlayable = new System.Windows.Forms.CheckBox();
            this.cbReadInfo = new System.Windows.Forms.CheckBox();
            this.cbReadTags = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(323, 23);
            this.btOpenFile.TabIndex = 0;
            this.btOpenFile.Text = "Open file";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // mmInfo
            // 
            this.mmInfo.Location = new System.Drawing.Point(13, 66);
            this.mmInfo.Multiline = true;
            this.mmInfo.Name = "mmInfo";
            this.mmInfo.Size = new System.Drawing.Size(323, 355);
            this.mmInfo.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbIsPlayable
            // 
            this.cbIsPlayable.AutoSize = true;
            this.cbIsPlayable.Checked = true;
            this.cbIsPlayable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsPlayable.Location = new System.Drawing.Point(13, 43);
            this.cbIsPlayable.Name = "cbIsPlayable";
            this.cbIsPlayable.Size = new System.Drawing.Size(76, 17);
            this.cbIsPlayable.TabIndex = 2;
            this.cbIsPlayable.Text = "Is playable";
            this.cbIsPlayable.UseVisualStyleBackColor = true;
            // 
            // cbReadInfo
            // 
            this.cbReadInfo.AutoSize = true;
            this.cbReadInfo.Checked = true;
            this.cbReadInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReadInfo.Location = new System.Drawing.Point(120, 43);
            this.cbReadInfo.Name = "cbReadInfo";
            this.cbReadInfo.Size = new System.Drawing.Size(72, 17);
            this.cbReadInfo.TabIndex = 3;
            this.cbReadInfo.Text = "Read info";
            this.cbReadInfo.UseVisualStyleBackColor = true;
            // 
            // cbReadTags
            // 
            this.cbReadTags.AutoSize = true;
            this.cbReadTags.Checked = true;
            this.cbReadTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReadTags.Location = new System.Drawing.Point(223, 43);
            this.cbReadTags.Name = "cbReadTags";
            this.cbReadTags.Size = new System.Drawing.Size(75, 17);
            this.cbReadTags.TabIndex = 4;
            this.cbReadTags.Text = "Read tags";
            this.cbReadTags.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 433);
            this.Controls.Add(this.cbReadTags);
            this.Controls.Add(this.cbReadInfo);
            this.Controls.Add(this.cbIsPlayable);
            this.Controls.Add(this.mmInfo);
            this.Controls.Add(this.btOpenFile);
            this.Name = "Form1";
            this.Text = "Read File Info Code Snippet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox mmInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbIsPlayable;
        private System.Windows.Forms.CheckBox cbReadInfo;
        private System.Windows.Forms.CheckBox cbReadTags;
    }
}

