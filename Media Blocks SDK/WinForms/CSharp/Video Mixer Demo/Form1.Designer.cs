namespace MediaBlocks_Video_Mixer_Demo
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
            this.edFile1 = new System.Windows.Forms.TextBox();
            this.btOpenFile1 = new System.Windows.Forms.Button();
            this.btOpenFile2 = new System.Windows.Forms.Button();
            this.edFile2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edX1 = new System.Windows.Forms.TextBox();
            this.edY1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edHeight1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edWidth1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.edHeight2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edWidth2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edY2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edX2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.edLog = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rbCPU = new System.Windows.Forms.RadioButton();
            this.rbDX11 = new System.Windows.Forms.RadioButton();
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File 1";
            // 
            // edFile1
            // 
            this.edFile1.Location = new System.Drawing.Point(20, 39);
            this.edFile1.Name = "edFile1";
            this.edFile1.Size = new System.Drawing.Size(438, 26);
            this.edFile1.TabIndex = 1;
            this.edFile1.Text = "c:\\Samples\\!video.mp4";
            // 
            // btOpenFile1
            // 
            this.btOpenFile1.Location = new System.Drawing.Point(464, 34);
            this.btOpenFile1.Name = "btOpenFile1";
            this.btOpenFile1.Size = new System.Drawing.Size(36, 36);
            this.btOpenFile1.TabIndex = 2;
            this.btOpenFile1.Text = "...";
            this.btOpenFile1.UseVisualStyleBackColor = true;
            this.btOpenFile1.Click += new System.EventHandler(this.btOpenFile1_Click);
            // 
            // btOpenFile2
            // 
            this.btOpenFile2.Location = new System.Drawing.Point(464, 96);
            this.btOpenFile2.Name = "btOpenFile2";
            this.btOpenFile2.Size = new System.Drawing.Size(36, 36);
            this.btOpenFile2.TabIndex = 5;
            this.btOpenFile2.Text = "...";
            this.btOpenFile2.UseVisualStyleBackColor = true;
            this.btOpenFile2.Click += new System.EventHandler(this.btOpenFile2_Click);
            // 
            // edFile2
            // 
            this.edFile2.Location = new System.Drawing.Point(20, 101);
            this.edFile2.Name = "edFile2";
            this.edFile2.Size = new System.Drawing.Size(438, 26);
            this.edFile2.TabIndex = 4;
            this.edFile2.Text = "c:\\Samples\\!video.avi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "File 2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "First stream position and size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "X";
            // 
            // edX1
            // 
            this.edX1.Location = new System.Drawing.Point(76, 181);
            this.edX1.Name = "edX1";
            this.edX1.Size = new System.Drawing.Size(46, 26);
            this.edX1.TabIndex = 9;
            this.edX1.Text = "0";
            // 
            // edY1
            // 
            this.edY1.Location = new System.Drawing.Point(76, 216);
            this.edY1.Name = "edY1";
            this.edY1.Size = new System.Drawing.Size(46, 26);
            this.edY1.TabIndex = 11;
            this.edY1.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y";
            // 
            // edHeight1
            // 
            this.edHeight1.Location = new System.Drawing.Point(198, 216);
            this.edHeight1.Name = "edHeight1";
            this.edHeight1.Size = new System.Drawing.Size(46, 26);
            this.edHeight1.TabIndex = 15;
            this.edHeight1.Text = "720";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Height";
            // 
            // edWidth1
            // 
            this.edWidth1.Location = new System.Drawing.Point(198, 184);
            this.edWidth1.Name = "edWidth1";
            this.edWidth1.Size = new System.Drawing.Size(46, 26);
            this.edWidth1.TabIndex = 13;
            this.edWidth1.Text = "1280";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Width";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(1044, 513);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(93, 36);
            this.btStart.TabIndex = 16;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(1143, 513);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(93, 36);
            this.btStop.TabIndex = 17;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // edHeight2
            // 
            this.edHeight2.Location = new System.Drawing.Point(443, 216);
            this.edHeight2.Name = "edHeight2";
            this.edHeight2.Size = new System.Drawing.Size(46, 26);
            this.edHeight2.TabIndex = 26;
            this.edHeight2.Text = "240";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Height";
            // 
            // edWidth2
            // 
            this.edWidth2.Location = new System.Drawing.Point(443, 184);
            this.edWidth2.Name = "edWidth2";
            this.edWidth2.Size = new System.Drawing.Size(46, 26);
            this.edWidth2.TabIndex = 24;
            this.edWidth2.Text = "320";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(384, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Width";
            // 
            // edY2
            // 
            this.edY2.Location = new System.Drawing.Point(321, 216);
            this.edY2.Name = "edY2";
            this.edY2.Size = new System.Drawing.Size(46, 26);
            this.edY2.TabIndex = 22;
            this.edY2.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Y";
            // 
            // edX2
            // 
            this.edX2.Location = new System.Drawing.Point(321, 181);
            this.edX2.Name = "edX2";
            this.edX2.Size = new System.Drawing.Size(46, 26);
            this.edX2.TabIndex = 20;
            this.edX2.Text = "100";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(282, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(239, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Second stream position and size";
            // 
            // edLog
            // 
            this.edLog.Location = new System.Drawing.Point(20, 388);
            this.edLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edLog.Size = new System.Drawing.Size(480, 108);
            this.edLog.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(461, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Also, you can configure the transparency level, background color";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 311);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "and z-order.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 363);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Log";
            // 
            // rbCPU
            // 
            this.rbCPU.AutoSize = true;
            this.rbCPU.Location = new System.Drawing.Point(516, 519);
            this.rbCPU.Name = "rbCPU";
            this.rbCPU.Size = new System.Drawing.Size(100, 24);
            this.rbCPU.TabIndex = 31;
            this.rbCPU.Text = "Use CPU";
            this.rbCPU.UseVisualStyleBackColor = true;
            // 
            // rbDX11
            // 
            this.rbDX11.AutoSize = true;
            this.rbDX11.Checked = true;
            this.rbDX11.Location = new System.Drawing.Point(622, 519);
            this.rbDX11.Name = "rbDX11";
            this.rbDX11.Size = new System.Drawing.Size(168, 24);
            this.rbDX11.TabIndex = 32;
            this.rbDX11.TabStop = true;
            this.rbDX11.Text = "GPU (Direct3D 11)";
            this.rbDX11.UseVisualStyleBackColor = true;
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(516, 16);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(720, 480);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 562);
            this.Controls.Add(this.rbDX11);
            this.Controls.Add(this.rbCPU);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.edHeight2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.edWidth2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.edY2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.edX2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.edHeight1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edWidth1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edY1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edX1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.btOpenFile2);
            this.Controls.Add(this.edFile2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOpenFile1);
            this.Controls.Add(this.edFile1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "MediaBlocks Video Mixer Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edFile1;
        private System.Windows.Forms.Button btOpenFile1;
        private System.Windows.Forms.Button btOpenFile2;
        private System.Windows.Forms.TextBox edFile2;
        private System.Windows.Forms.Label label2;
        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edX1;
        private System.Windows.Forms.TextBox edY1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edHeight1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edWidth1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.TextBox edHeight2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edWidth2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edY2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edX2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbCPU;
        private System.Windows.Forms.RadioButton rbDX11;
    }
}