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
            label1 = new Label();
            edSourceFile = new TextBox();
            btSelectOutput = new Button();
            btSelectInput = new Button();
            label2 = new Label();
            edOutputFile = new TextBox();
            rbReencodeMP3 = new RadioButton();
            rbExtract = new RadioButton();
            rbReencodeM4A = new RadioButton();
            btStart = new Button();
            btStop = new Button();
            OpenDialog1 = new OpenFileDialog();
            SaveDialog1 = new SaveFileDialog();
            pbProgress = new ProgressBar();
            edLog = new TextBox();
            linkLabelDecoders = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 25);
            label1.TabIndex = 0;
            label1.Text = "Source file";
            // 
            // edSourceFile
            // 
            edSourceFile.Location = new System.Drawing.Point(16, 44);
            edSourceFile.Name = "edSourceFile";
            edSourceFile.Size = new System.Drawing.Size(683, 31);
            edSourceFile.TabIndex = 1;
            edSourceFile.Text = "c:\\Samples\\!video.mp4";
            // 
            // btSelectOutput
            // 
            btSelectOutput.Location = new System.Drawing.Point(706, 124);
            btSelectOutput.Margin = new Padding(4, 6, 4, 6);
            btSelectOutput.Name = "btSelectOutput";
            btSelectOutput.Size = new System.Drawing.Size(32, 32);
            btSelectOutput.TabIndex = 32;
            btSelectOutput.Text = "...";
            btSelectOutput.UseVisualStyleBackColor = true;
            btSelectOutput.Click += btSelectOutput_Click;
            // 
            // btSelectInput
            // 
            btSelectInput.Location = new System.Drawing.Point(706, 44);
            btSelectInput.Margin = new Padding(4, 6, 4, 6);
            btSelectInput.Name = "btSelectInput";
            btSelectInput.Size = new System.Drawing.Size(32, 32);
            btSelectInput.TabIndex = 33;
            btSelectInput.Text = "...";
            btSelectInput.UseVisualStyleBackColor = true;
            btSelectInput.Click += btSelectInput_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 97);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(97, 25);
            label2.TabIndex = 34;
            label2.Text = "Output file";
            // 
            // edOutputFile
            // 
            edOutputFile.Location = new System.Drawing.Point(16, 125);
            edOutputFile.Name = "edOutputFile";
            edOutputFile.Size = new System.Drawing.Size(683, 31);
            edOutputFile.TabIndex = 35;
            // 
            // rbReencodeMP3
            // 
            rbReencodeMP3.AutoSize = true;
            rbReencodeMP3.Checked = true;
            rbReencodeMP3.Location = new System.Drawing.Point(16, 189);
            rbReencodeMP3.Name = "rbReencodeMP3";
            rbReencodeMP3.Size = new System.Drawing.Size(177, 29);
            rbReencodeMP3.TabIndex = 36;
            rbReencodeMP3.TabStop = true;
            rbReencodeMP3.Text = "Reencode to MP3";
            rbReencodeMP3.UseVisualStyleBackColor = true;
            // 
            // rbExtract
            // 
            rbExtract.AutoSize = true;
            rbExtract.Location = new System.Drawing.Point(412, 189);
            rbExtract.Name = "rbExtract";
            rbExtract.Size = new System.Drawing.Size(326, 29);
            rbExtract.TabIndex = 37;
            rbExtract.Text = "Extract (specify correct file extension)";
            rbExtract.UseVisualStyleBackColor = true;
            // 
            // rbReencodeM4A
            // 
            rbReencodeM4A.AutoSize = true;
            rbReencodeM4A.Location = new System.Drawing.Point(215, 189);
            rbReencodeM4A.Name = "rbReencodeM4A";
            rbReencodeM4A.Size = new System.Drawing.Size(179, 29);
            rbReencodeM4A.TabIndex = 38;
            rbReencodeM4A.Text = "Reencode to M4A";
            rbReencodeM4A.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(16, 240);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(84, 34);
            btStart.TabIndex = 39;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(106, 240);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(84, 34);
            btStop.TabIndex = 40;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            // 
            // OpenDialog1
            // 
            OpenDialog1.Filter = resources.GetString("OpenDialog1.Filter");
            // 
            // SaveDialog1
            // 
            SaveDialog1.Filter = "MP3| *.mp3|M4A| *.m4a|All files  (*.*)| *.*";
            // 
            // pbProgress
            // 
            pbProgress.Location = new System.Drawing.Point(215, 240);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new System.Drawing.Size(523, 34);
            pbProgress.TabIndex = 41;
            // 
            // edLog
            // 
            edLog.Location = new System.Drawing.Point(16, 306);
            edLog.Multiline = true;
            edLog.Name = "edLog";
            edLog.Size = new System.Drawing.Size(722, 265);
            edLog.TabIndex = 42;
            // 
            // linkLabelDecoders
            // 
            linkLabelDecoders.AutoSize = true;
            linkLabelDecoders.Location = new System.Drawing.Point(106, 593);
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
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(766, 641);
            Controls.Add(linkLabelDecoders);
            Controls.Add(edLog);
            Controls.Add(pbProgress);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(rbReencodeM4A);
            Controls.Add(rbExtract);
            Controls.Add(rbReencodeMP3);
            Controls.Add(edOutputFile);
            Controls.Add(label2);
            Controls.Add(btSelectInput);
            Controls.Add(btSelectOutput);
            Controls.Add(edSourceFile);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Video Edit SDK .Net - Audio Extractor Demo";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private LinkLabel linkLabelDecoders;
    }
}