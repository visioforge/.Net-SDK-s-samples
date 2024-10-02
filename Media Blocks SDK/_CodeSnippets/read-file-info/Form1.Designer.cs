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
            btOpenFile = new System.Windows.Forms.Button();
            mmInfo = new System.Windows.Forms.TextBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            SuspendLayout();
            // 
            // btOpenFile
            // 
            btOpenFile.Location = new System.Drawing.Point(20, 23);
            btOpenFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btOpenFile.Name = "btOpenFile";
            btOpenFile.Size = new System.Drawing.Size(538, 44);
            btOpenFile.TabIndex = 0;
            btOpenFile.Text = "Open file";
            btOpenFile.UseVisualStyleBackColor = true;
            btOpenFile.Click += btOpenFile_Click;
            // 
            // mmInfo
            // 
            mmInfo.Location = new System.Drawing.Point(22, 79);
            mmInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmInfo.Multiline = true;
            mmInfo.Name = "mmInfo";
            mmInfo.Size = new System.Drawing.Size(536, 727);
            mmInfo.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(580, 833);
            Controls.Add(mmInfo);
            Controls.Add(btOpenFile);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Read File Info Code Snippet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox mmInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

