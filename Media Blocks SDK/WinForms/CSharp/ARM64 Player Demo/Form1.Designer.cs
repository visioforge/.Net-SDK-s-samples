namespace MediaBlocks_ARM64_Player_Demo
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
            components = new System.ComponentModel.Container();
            label14 = new System.Windows.Forms.Label();
            edFilename = new System.Windows.Forms.TextBox();
            btSelectFile = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            lbArch = new System.Windows.Forms.Label();
            mmError = new System.Windows.Forms.TextBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            SuspendLayout();
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(16, 16);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(60, 20);
            label14.TabIndex = 0;
            label14.Text = "File name";
            // 
            // edFilename
            // 
            edFilename.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            edFilename.Location = new System.Drawing.Point(20, 42);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(512, 27);
            edFilename.TabIndex = 1;
            // 
            // btSelectFile
            // 
            btSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btSelectFile.Location = new System.Drawing.Point(540, 40);
            btSelectFile.Name = "btSelectFile";
            btSelectFile.Size = new System.Drawing.Size(90, 31);
            btSelectFile.TabIndex = 2;
            btSelectFile.Text = "Browse";
            btSelectFile.UseVisualStyleBackColor = true;
            btSelectFile.Click += btSelectFile_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btStart.Location = new System.Drawing.Point(652, 40);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(110, 31);
            btStart.TabIndex = 3;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btStop.Enabled = false;
            btStop.Location = new System.Drawing.Point(770, 40);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(110, 31);
            btStop.TabIndex = 4;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // VideoView1
            // 
            VideoView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(20, 86);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(860, 442);
            VideoView1.TabIndex = 5;
            // 
            // lbArch
            // 
            lbArch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbArch.AutoSize = true;
            lbArch.Location = new System.Drawing.Point(20, 540);
            lbArch.Name = "lbArch";
            lbArch.Size = new System.Drawing.Size(60, 20);
            lbArch.TabIndex = 6;
            lbArch.Text = "ARM64";
            // 
            // mmError
            // 
            mmError.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mmError.Location = new System.Drawing.Point(20, 564);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ReadOnly = true;
            mmError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            mmError.Size = new System.Drawing.Size(860, 80);
            mmError.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.ts;*.webm;*.wmv|All files|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 660);
            Controls.Add(mmError);
            Controls.Add(lbArch);
            Controls.Add(VideoView1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(btSelectFile);
            Controls.Add(edFilename);
            Controls.Add(label14);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - ARM64 Player Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Label lbArch;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
