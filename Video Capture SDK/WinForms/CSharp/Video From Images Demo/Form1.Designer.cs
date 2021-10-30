using System;

namespace Video_From_Images_Demo
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

            VideoCapture1?.Dispose();
            VideoCapture1 = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edVideoWidth = new System.Windows.Forms.TextBox();
            this.edVideoHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edVideoFrameRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edInputFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btSelectFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.edOutputFile = new System.Windows.Forms.TextBox();
            this.btSelectOutputFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.edLog = new System.Windows.Forms.TextBox();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edImageDuration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.VideoView1 = new VisioForge.Controls.UI.WinForms.VideoView();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(15, 349);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(96, 349);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Video resolution and frame rate";
            // 
            // edVideoWidth
            // 
            this.edVideoWidth.Location = new System.Drawing.Point(15, 28);
            this.edVideoWidth.Name = "edVideoWidth";
            this.edVideoWidth.Size = new System.Drawing.Size(37, 20);
            this.edVideoWidth.TabIndex = 4;
            this.edVideoWidth.Text = "1280";
            // 
            // edVideoHeight
            // 
            this.edVideoHeight.Location = new System.Drawing.Point(58, 28);
            this.edVideoHeight.Name = "edVideoHeight";
            this.edVideoHeight.Size = new System.Drawing.Size(37, 20);
            this.edVideoHeight.TabIndex = 5;
            this.edVideoHeight.Text = "720";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "at";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "fps";
            // 
            // edVideoFrameRate
            // 
            this.edVideoFrameRate.Location = new System.Drawing.Point(123, 28);
            this.edVideoFrameRate.Name = "edVideoFrameRate";
            this.edVideoFrameRate.Size = new System.Drawing.Size(23, 20);
            this.edVideoFrameRate.TabIndex = 8;
            this.edVideoFrameRate.Text = "25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Folder with images (*.jpg;*.jpeg;*.png;*.bmp will be loaded) ";
            // 
            // edInputFolder
            // 
            this.edInputFolder.Location = new System.Drawing.Point(15, 82);
            this.edInputFolder.Name = "edInputFolder";
            this.edInputFolder.Size = new System.Drawing.Size(249, 20);
            this.edInputFolder.TabIndex = 10;
            this.edInputFolder.Text = "c:\\Samples\\pics\\";
            // 
            // btSelectFolder
            // 
            this.btSelectFolder.Location = new System.Drawing.Point(270, 80);
            this.btSelectFolder.Name = "btSelectFolder";
            this.btSelectFolder.Size = new System.Drawing.Size(22, 23);
            this.btSelectFolder.TabIndex = 11;
            this.btSelectFolder.Text = "...";
            this.btSelectFolder.UseVisualStyleBackColor = true;
            this.btSelectFolder.Click += new System.EventHandler(this.btSelectFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Output file (MP4 format will be used)";
            // 
            // edOutputFile
            // 
            this.edOutputFile.Location = new System.Drawing.Point(15, 134);
            this.edOutputFile.Name = "edOutputFile";
            this.edOutputFile.Size = new System.Drawing.Size(249, 20);
            this.edOutputFile.TabIndex = 13;
            // 
            // btSelectOutputFile
            // 
            this.btSelectOutputFile.Location = new System.Drawing.Point(270, 132);
            this.btSelectOutputFile.Name = "btSelectOutputFile";
            this.btSelectOutputFile.Size = new System.Drawing.Size(22, 23);
            this.btSelectOutputFile.TabIndex = 14;
            this.btSelectOutputFile.Text = "...";
            this.btSelectOutputFile.UseVisualStyleBackColor = true;
            this.btSelectOutputFile.Click += new System.EventHandler(this.btSelectOutputFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "mp4";
            this.saveFileDialog1.Filter = "*.mp4|MP4 file";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Log";
            // 
            // edLog
            // 
            this.edLog.Location = new System.Drawing.Point(15, 185);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.Size = new System.Drawing.Size(277, 158);
            this.edLog.TabIndex = 16;
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Location = new System.Drawing.Point(231, 168);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(61, 17);
            this.cbDebug.TabIndex = 17;
            this.cbDebug.Text = "Debug ";
            this.cbDebug.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Image duration";
            // 
            // edImageDuration
            // 
            this.edImageDuration.Location = new System.Drawing.Point(203, 28);
            this.edImageDuration.Name = "edImageDuration";
            this.edImageDuration.Size = new System.Drawing.Size(35, 20);
            this.edImageDuration.TabIndex = 20;
            this.edImageDuration.Text = "1000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "ms";
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(300, 12);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(640, 360);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 386);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.edImageDuration);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbDebug);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSelectOutputFile);
            this.Controls.Add(this.edOutputFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btSelectFolder);
            this.Controls.Add(this.edInputFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edVideoFrameRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edVideoHeight);
            this.Controls.Add(this.edVideoWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video From Images Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edVideoWidth;
        private System.Windows.Forms.TextBox edVideoHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edVideoFrameRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edInputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btSelectFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edOutputFile;
        private System.Windows.Forms.Button btSelectOutputFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edImageDuration;
        private System.Windows.Forms.Label label8;
        private VisioForge.Controls.UI.WinForms.VideoView VideoView1;
    }
}

