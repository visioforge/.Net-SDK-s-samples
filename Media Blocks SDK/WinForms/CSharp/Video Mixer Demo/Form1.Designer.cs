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
            label1 = new System.Windows.Forms.Label();
            edFile1 = new System.Windows.Forms.TextBox();
            btOpenFile1 = new System.Windows.Forms.Button();
            btOpenFile2 = new System.Windows.Forms.Button();
            edFile2 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            edX1 = new System.Windows.Forms.TextBox();
            edY1 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            edHeight1 = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            edWidth1 = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            edHeight2 = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            edWidth2 = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            edY2 = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            edX2 = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            edLog = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            rbCPU = new System.Windows.Forms.RadioButton();
            rbDX11 = new System.Windows.Forms.RadioButton();
            videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 25);
            label1.TabIndex = 0;
            label1.Text = "File 1";
            // 
            // edFile1
            // 
            edFile1.Location = new System.Drawing.Point(22, 49);
            edFile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edFile1.Name = "edFile1";
            edFile1.Size = new System.Drawing.Size(486, 31);
            edFile1.TabIndex = 1;
            edFile1.Text = "c:\\Samples\\!video.mp4";
            // 
            // btOpenFile1
            // 
            btOpenFile1.Location = new System.Drawing.Point(516, 42);
            btOpenFile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btOpenFile1.Name = "btOpenFile1";
            btOpenFile1.Size = new System.Drawing.Size(40, 45);
            btOpenFile1.TabIndex = 2;
            btOpenFile1.Text = "...";
            btOpenFile1.UseVisualStyleBackColor = true;
            btOpenFile1.Click += btOpenFile1_Click;
            // 
            // btOpenFile2
            // 
            btOpenFile2.Location = new System.Drawing.Point(516, 120);
            btOpenFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btOpenFile2.Name = "btOpenFile2";
            btOpenFile2.Size = new System.Drawing.Size(40, 45);
            btOpenFile2.TabIndex = 5;
            btOpenFile2.Text = "...";
            btOpenFile2.UseVisualStyleBackColor = true;
            btOpenFile2.Click += btOpenFile2_Click;
            // 
            // edFile2
            // 
            edFile2.Location = new System.Drawing.Point(22, 126);
            edFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edFile2.Name = "edFile2";
            edFile2.Size = new System.Drawing.Size(486, 31);
            edFile2.TabIndex = 4;
            edFile2.Text = "c:\\Samples\\!video.avi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 25);
            label2.TabIndex = 3;
            label2.Text = "File 2";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 198);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(243, 25);
            label3.TabIndex = 7;
            label3.Text = "First stream position and size";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(41, 234);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(23, 25);
            label4.TabIndex = 8;
            label4.Text = "X";
            // 
            // edX1
            // 
            edX1.Location = new System.Drawing.Point(84, 226);
            edX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edX1.Name = "edX1";
            edX1.Size = new System.Drawing.Size(51, 31);
            edX1.TabIndex = 9;
            edX1.Text = "0";
            // 
            // edY1
            // 
            edY1.Location = new System.Drawing.Point(84, 270);
            edY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edY1.Name = "edY1";
            edY1.Size = new System.Drawing.Size(51, 31);
            edY1.TabIndex = 11;
            edY1.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(41, 274);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(22, 25);
            label5.TabIndex = 10;
            label5.Text = "Y";
            // 
            // edHeight1
            // 
            edHeight1.Location = new System.Drawing.Point(220, 270);
            edHeight1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edHeight1.Name = "edHeight1";
            edHeight1.Size = new System.Drawing.Size(51, 31);
            edHeight1.TabIndex = 15;
            edHeight1.Text = "720";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(154, 274);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 25);
            label6.TabIndex = 14;
            label6.Text = "Height";
            // 
            // edWidth1
            // 
            edWidth1.Location = new System.Drawing.Point(220, 230);
            edWidth1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edWidth1.Name = "edWidth1";
            edWidth1.Size = new System.Drawing.Size(51, 31);
            edWidth1.TabIndex = 13;
            edWidth1.Text = "1280";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(154, 234);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(60, 25);
            label7.TabIndex = 12;
            label7.Text = "Width";
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(1160, 641);
            btStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 45);
            btStart.TabIndex = 16;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(1270, 641);
            btStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 45);
            btStop.TabIndex = 17;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // edHeight2
            // 
            edHeight2.Location = new System.Drawing.Point(492, 270);
            edHeight2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edHeight2.Name = "edHeight2";
            edHeight2.Size = new System.Drawing.Size(51, 31);
            edHeight2.TabIndex = 26;
            edHeight2.Text = "240";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(427, 274);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(65, 25);
            label8.TabIndex = 25;
            label8.Text = "Height";
            // 
            // edWidth2
            // 
            edWidth2.Location = new System.Drawing.Point(492, 230);
            edWidth2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edWidth2.Name = "edWidth2";
            edWidth2.Size = new System.Drawing.Size(51, 31);
            edWidth2.TabIndex = 24;
            edWidth2.Text = "320";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(427, 234);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(60, 25);
            label9.TabIndex = 23;
            label9.Text = "Width";
            // 
            // edY2
            // 
            edY2.Location = new System.Drawing.Point(357, 270);
            edY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edY2.Name = "edY2";
            edY2.Size = new System.Drawing.Size(51, 31);
            edY2.TabIndex = 22;
            edY2.Text = "100";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(313, 274);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(22, 25);
            label10.TabIndex = 21;
            label10.Text = "Y";
            // 
            // edX2
            // 
            edX2.Location = new System.Drawing.Point(357, 226);
            edX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            edX2.Name = "edX2";
            edX2.Size = new System.Drawing.Size(51, 31);
            edX2.TabIndex = 20;
            edX2.Text = "100";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(313, 234);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(23, 25);
            label11.TabIndex = 19;
            label11.Text = "X";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(290, 198);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(269, 25);
            label12.TabIndex = 18;
            label12.Text = "Second stream position and size";
            // 
            // edLog
            // 
            edLog.Location = new System.Drawing.Point(22, 485);
            edLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            edLog.Multiline = true;
            edLog.Name = "edLog";
            edLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            edLog.Size = new System.Drawing.Size(533, 134);
            edLog.TabIndex = 27;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(18, 364);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(524, 25);
            label13.TabIndex = 28;
            label13.Text = "Also, you can configure the transparency level, background color";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(18, 389);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(109, 25);
            label14.TabIndex = 29;
            label14.Text = "and z-order.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(18, 454);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(42, 25);
            label15.TabIndex = 30;
            label15.Text = "Log";
            // 
            // rbCPU
            // 
            rbCPU.AutoSize = true;
            rbCPU.Location = new System.Drawing.Point(573, 649);
            rbCPU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rbCPU.Name = "rbCPU";
            rbCPU.Size = new System.Drawing.Size(104, 29);
            rbCPU.TabIndex = 31;
            rbCPU.Text = "Use CPU";
            rbCPU.UseVisualStyleBackColor = true;
            // 
            // rbDX11
            // 
            rbDX11.AutoSize = true;
            rbDX11.Checked = true;
            rbDX11.Location = new System.Drawing.Point(691, 649);
            rbDX11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rbDX11.Name = "rbDX11";
            rbDX11.Size = new System.Drawing.Size(180, 29);
            rbDX11.TabIndex = 32;
            rbDX11.TabStop = true;
            rbDX11.Text = "GPU (Direct3D 11)";
            rbDX11.UseVisualStyleBackColor = true;
            // 
            // videoView1
            // 
            videoView1.BackColor = System.Drawing.Color.Black;
            videoView1.Location = new System.Drawing.Point(573, 20);
            videoView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            videoView1.Name = "videoView1";
            videoView1.Size = new System.Drawing.Size(800, 600);
            videoView1.StatusOverlay = null;
            videoView1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1398, 702);
            Controls.Add(rbDX11);
            Controls.Add(rbCPU);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(edLog);
            Controls.Add(edHeight2);
            Controls.Add(label8);
            Controls.Add(edWidth2);
            Controls.Add(label9);
            Controls.Add(edY2);
            Controls.Add(label10);
            Controls.Add(edX2);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(edHeight1);
            Controls.Add(label6);
            Controls.Add(edWidth1);
            Controls.Add(label7);
            Controls.Add(edY1);
            Controls.Add(label5);
            Controls.Add(edX1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(videoView1);
            Controls.Add(btOpenFile2);
            Controls.Add(edFile2);
            Controls.Add(label2);
            Controls.Add(btOpenFile1);
            Controls.Add(edFile1);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "MediaBlocks Video Mixer Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
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