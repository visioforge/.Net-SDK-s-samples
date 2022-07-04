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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edInputFile = new System.Windows.Forms.TextBox();
            this.btInputFile = new System.Windows.Forms.Button();
            this.btOutputFile = new System.Windows.Forms.Button();
            this.edOutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.edLog = new System.Windows.Forms.TextBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.edKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmProgress = new System.Windows.Forms.Timer(this.components);
            this.cbForceRecompress = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File will be encrypted without reencoding for H264 video and AAC audio, otherwise" +
    " file will be reencoded.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input file";
            // 
            // edInputFile
            // 
            this.edInputFile.Location = new System.Drawing.Point(30, 95);
            this.edInputFile.Name = "edInputFile";
            this.edInputFile.Size = new System.Drawing.Size(698, 26);
            this.edInputFile.TabIndex = 2;
            // 
            // btInputFile
            // 
            this.btInputFile.Location = new System.Drawing.Point(734, 92);
            this.btInputFile.Name = "btInputFile";
            this.btInputFile.Size = new System.Drawing.Size(32, 32);
            this.btInputFile.TabIndex = 3;
            this.btInputFile.Text = "...";
            this.btInputFile.UseVisualStyleBackColor = true;
            this.btInputFile.Click += new System.EventHandler(this.btInputFile_Click);
            // 
            // btOutputFile
            // 
            this.btOutputFile.Location = new System.Drawing.Point(734, 165);
            this.btOutputFile.Name = "btOutputFile";
            this.btOutputFile.Size = new System.Drawing.Size(32, 32);
            this.btOutputFile.TabIndex = 6;
            this.btOutputFile.Text = "...";
            this.btOutputFile.UseVisualStyleBackColor = true;
            this.btOutputFile.Click += new System.EventHandler(this.btOutputFile_Click);
            // 
            // edOutputFile
            // 
            this.edOutputFile.Location = new System.Drawing.Point(30, 168);
            this.edOutputFile.Name = "edOutputFile";
            this.edOutputFile.Size = new System.Drawing.Size(698, 26);
            this.edOutputFile.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output file";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(566, 555);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(97, 41);
            this.btStart.TabIndex = 7;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(669, 555);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(97, 41);
            this.btStop.TabIndex = 8;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Log";
            // 
            // edLog
            // 
            this.edLog.Location = new System.Drawing.Point(30, 240);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.Size = new System.Drawing.Size(348, 356);
            this.edLog.TabIndex = 10;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(395, 564);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(151, 23);
            this.pbProgress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Key";
            // 
            // edKey
            // 
            this.edKey.Location = new System.Drawing.Point(395, 240);
            this.edKey.Name = "edKey";
            this.edKey.Size = new System.Drawing.Size(371, 26);
            this.edKey.TabIndex = 13;
            this.edKey.Text = "somepassword";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Also, you can use the binary key or file.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tmProgress
            // 
            this.tmProgress.Interval = 500;
            this.tmProgress.Tick += new System.EventHandler(this.tmProgress_Tick);
            // 
            // cbForceRecompress
            // 
            this.cbForceRecompress.AutoSize = true;
            this.cbForceRecompress.Location = new System.Drawing.Point(395, 325);
            this.cbForceRecompress.Name = "cbForceRecompress";
            this.cbForceRecompress.Size = new System.Drawing.Size(163, 24);
            this.cbForceRecompress.TabIndex = 15;
            this.cbForceRecompress.Text = "Force recompress";
            this.cbForceRecompress.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 608);
            this.Controls.Add(this.cbForceRecompress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btOutputFile);
            this.Controls.Add(this.edOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btInputFile);
            this.Controls.Add(this.edInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Encryptor Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}