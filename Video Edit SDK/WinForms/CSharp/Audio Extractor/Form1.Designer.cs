using System.Windows.Forms;

namespace Audio_Extractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.edSourceFile = new System.Windows.Forms.TextBox();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.btSelectInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edOutputFile = new System.Windows.Forms.TextBox();
            this.rbReencodeMP3 = new System.Windows.Forms.RadioButton();
            this.rbExtract = new System.Windows.Forms.RadioButton();
            this.rbReencodeM4A = new System.Windows.Forms.RadioButton();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.OpenDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.edLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source file";
            // 
            // edSourceFile
            // 
            this.edSourceFile.Location = new System.Drawing.Point(16, 44);
            this.edSourceFile.Name = "edSourceFile";
            this.edSourceFile.Size = new System.Drawing.Size(683, 31);
            this.edSourceFile.TabIndex = 1;
            this.edSourceFile.Text = "c:\\Samples\\!video.mp4";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(706, 124);
            this.btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(32, 32);
            this.btSelectOutput.TabIndex = 32;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // btSelectInput
            // 
            this.btSelectInput.Location = new System.Drawing.Point(706, 44);
            this.btSelectInput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSelectInput.Name = "btSelectInput";
            this.btSelectInput.Size = new System.Drawing.Size(32, 32);
            this.btSelectInput.TabIndex = 33;
            this.btSelectInput.Text = "...";
            this.btSelectInput.UseVisualStyleBackColor = true;
            this.btSelectInput.Click += new System.EventHandler(this.btSelectInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Output file";
            // 
            // edOutputFile
            // 
            this.edOutputFile.Location = new System.Drawing.Point(16, 125);
            this.edOutputFile.Name = "edOutputFile";
            this.edOutputFile.Size = new System.Drawing.Size(683, 31);
            this.edOutputFile.TabIndex = 35;
            // 
            // rbReencodeMP3
            // 
            this.rbReencodeMP3.AutoSize = true;
            this.rbReencodeMP3.Checked = true;
            this.rbReencodeMP3.Location = new System.Drawing.Point(16, 189);
            this.rbReencodeMP3.Name = "rbReencodeMP3";
            this.rbReencodeMP3.Size = new System.Drawing.Size(177, 29);
            this.rbReencodeMP3.TabIndex = 36;
            this.rbReencodeMP3.TabStop = true;
            this.rbReencodeMP3.Text = "Reencode to MP3";
            this.rbReencodeMP3.UseVisualStyleBackColor = true;
            // 
            // rbExtract
            // 
            this.rbExtract.AutoSize = true;
            this.rbExtract.Location = new System.Drawing.Point(412, 189);
            this.rbExtract.Name = "rbExtract";
            this.rbExtract.Size = new System.Drawing.Size(326, 29);
            this.rbExtract.TabIndex = 37;
            this.rbExtract.Text = "Extract (specify correct file extension)";
            this.rbExtract.UseVisualStyleBackColor = true;
            // 
            // rbReencodeM4A
            // 
            this.rbReencodeM4A.AutoSize = true;
            this.rbReencodeM4A.Location = new System.Drawing.Point(215, 189);
            this.rbReencodeM4A.Name = "rbReencodeM4A";
            this.rbReencodeM4A.Size = new System.Drawing.Size(179, 29);
            this.rbReencodeM4A.TabIndex = 38;
            this.rbReencodeM4A.Text = "Reencode to M4A";
            this.rbReencodeM4A.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(16, 240);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(84, 34);
            this.btStart.TabIndex = 39;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(106, 240);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(84, 34);
            this.btStop.TabIndex = 40;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // OpenDialog1
            // 
            this.OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            this.SaveDialog1.Filter = "MP3| *.mp3|M4A| *.m4a|All files  (*.*)| *.*";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(215, 240);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(523, 34);
            this.pbProgress.TabIndex = 41;
            // 
            // edLog
            // 
            this.edLog.Location = new System.Drawing.Point(16, 306);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.Size = new System.Drawing.Size(722, 265);
            this.edLog.TabIndex = 42;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 596);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.rbReencodeM4A);
            this.Controls.Add(this.rbExtract);
            this.Controls.Add(this.rbReencodeMP3);
            this.Controls.Add(this.edOutputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSelectInput);
            this.Controls.Add(this.btSelectOutput);
            this.Controls.Add(this.edSourceFile);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Edit SDK .Net - Audio Extractor Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox edSourceFile;
        private Button btSelectOutput;
        private Button btSelectInput;
        private Label label2;
        private TextBox edOutputFile;
        private RadioButton rbReencodeMP3;
        private RadioButton rbExtract;
        private RadioButton rbReencodeM4A;
        private Button btStart;
        private Button btStop;
        private OpenFileDialog OpenDialog1;
        private SaveFileDialog SaveDialog1;
        private ProgressBar pbProgress;
        private TextBox edLog;
    }
}