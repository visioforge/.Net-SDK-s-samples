namespace File_Encryptor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            edInputFile = new System.Windows.Forms.TextBox();
            btInputFile = new System.Windows.Forms.Button();
            btOutputFile = new System.Windows.Forms.Button();
            edOutputFile = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            edLog = new System.Windows.Forms.TextBox();
            pbProgress = new System.Windows.Forms.ProgressBar();
            label5 = new System.Windows.Forms.Label();
            edKey = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            tmProgress = new System.Windows.Forms.Timer(components);
            cbForceRecompress = new System.Windows.Forms.CheckBox();
            linkLabelDecoders = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(847, 25);
            label1.TabIndex = 0;
            label1.Text = "File will be encrypted without reencoding for H264 video and AAC audio, otherwise file will be reencoded.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 25);
            label2.TabIndex = 1;
            label2.Text = "Input file";
            // 
            // edInputFile
            // 
            edInputFile.Location = new System.Drawing.Point(33, 119);
            edInputFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edInputFile.Name = "edInputFile";
            edInputFile.Size = new System.Drawing.Size(775, 31);
            edInputFile.TabIndex = 2;
            // 
            // btInputFile
            // 
            btInputFile.Location = new System.Drawing.Point(816, 115);
            btInputFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btInputFile.Name = "btInputFile";
            btInputFile.Size = new System.Drawing.Size(36, 40);
            btInputFile.TabIndex = 3;
            btInputFile.Text = "...";
            btInputFile.UseVisualStyleBackColor = true;
            btInputFile.Click += btInputFile_Click;
            // 
            // btOutputFile
            // 
            btOutputFile.Location = new System.Drawing.Point(816, 206);
            btOutputFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btOutputFile.Name = "btOutputFile";
            btOutputFile.Size = new System.Drawing.Size(36, 40);
            btOutputFile.TabIndex = 6;
            btOutputFile.Text = "...";
            btOutputFile.UseVisualStyleBackColor = true;
            btOutputFile.Click += btOutputFile_Click;
            // 
            // edOutputFile
            // 
            edOutputFile.Location = new System.Drawing.Point(33, 210);
            edOutputFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edOutputFile.Name = "edOutputFile";
            edOutputFile.Size = new System.Drawing.Size(775, 31);
            edOutputFile.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(29, 181);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(97, 25);
            label3.TabIndex = 4;
            label3.Text = "Output file";
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(629, 694);
            btStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(108, 51);
            btStart.TabIndex = 7;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(743, 694);
            btStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(108, 51);
            btStop.TabIndex = 8;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 271);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 25);
            label4.TabIndex = 9;
            label4.Text = "Log";
            // 
            // edLog
            // 
            edLog.Location = new System.Drawing.Point(33, 300);
            edLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edLog.Multiline = true;
            edLog.Name = "edLog";
            edLog.Size = new System.Drawing.Size(386, 444);
            edLog.TabIndex = 10;
            // 
            // pbProgress
            // 
            pbProgress.Location = new System.Drawing.Point(439, 705);
            pbProgress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new System.Drawing.Size(168, 29);
            pbProgress.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(434, 271);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(40, 25);
            label5.TabIndex = 12;
            label5.Text = "Key";
            // 
            // edKey
            // 
            edKey.Location = new System.Drawing.Point(439, 300);
            edKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edKey.Name = "edKey";
            edKey.Size = new System.Drawing.Size(412, 31);
            edKey.TabIndex = 13;
            edKey.Text = "somepassword";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(434, 352);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(320, 25);
            label6.TabIndex = 14;
            label6.Text = "Also, you can use the binary key or file.";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tmProgress
            // 
            tmProgress.Interval = 500;
            tmProgress.Tick += tmProgress_Tick;
            // 
            // cbForceRecompress
            // 
            cbForceRecompress.AutoSize = true;
            cbForceRecompress.Location = new System.Drawing.Point(439, 406);
            cbForceRecompress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbForceRecompress.Name = "cbForceRecompress";
            cbForceRecompress.Size = new System.Drawing.Size(178, 29);
            cbForceRecompress.TabIndex = 15;
            cbForceRecompress.Text = "Force recompress";
            cbForceRecompress.UseVisualStyleBackColor = true;
            // 
            // linkLabelDecoders
            // 
            linkLabelDecoders.AutoSize = true;
            linkLabelDecoders.Location = new System.Drawing.Point(305, 86);
            linkLabelDecoders.Name = "linkLabelDecoders";
            linkLabelDecoders.Size = new System.Drawing.Size(546, 25);
            linkLabelDecoders.TabIndex = 58;
            linkLabelDecoders.TabStop = true;
            linkLabelDecoders.Text = "[NuGet only] Install decoders if you can see errors while adding files";
            linkLabelDecoders.LinkClicked += linkLabelDecoders_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(880, 760);
            Controls.Add(linkLabelDecoders);
            Controls.Add(cbForceRecompress);
            Controls.Add(label6);
            Controls.Add(edKey);
            Controls.Add(label5);
            Controls.Add(pbProgress);
            Controls.Add(edLog);
            Controls.Add(label4);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(btOutputFile);
            Controls.Add(edOutputFile);
            Controls.Add(label3);
            Controls.Add(btInputFile);
            Controls.Add(edInputFile);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Video Encryptor Demo";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edInputFile;
        private System.Windows.Forms.Button btInputFile;
        private System.Windows.Forms.Button btOutputFile;
        private System.Windows.Forms.TextBox edOutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer tmProgress;
        private System.Windows.Forms.CheckBox cbForceRecompress;
        private System.Windows.Forms.LinkLabel linkLabelDecoders;
    }
}