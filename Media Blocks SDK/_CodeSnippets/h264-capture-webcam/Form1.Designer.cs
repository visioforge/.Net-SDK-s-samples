namespace h264_capture_webcam
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
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            label28 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            edOutputFile = new System.Windows.Forms.TextBox();
            btSelectOutputFile = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(565, 29);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(711, 482);
            VideoView1.TabIndex = 0;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(32, 467);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(125, 44);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(167, 467);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(125, 44);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(502, 167);
            label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(37, 25);
            label28.TabIndex = 135;
            label28.Text = "fps";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(378, 131);
            label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(96, 25);
            label18.TabIndex = 133;
            label18.Text = "Frame rate";
            // 
            // cbVideoInputFrameRate
            // 
            cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFrameRate.FormattingEnabled = true;
            cbVideoInputFrameRate.Location = new System.Drawing.Point(383, 161);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            cbVideoInputFrameRate.TabIndex = 132;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(32, 161);
            cbVideoInputFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputFormat.Name = "cbVideoInputFormat";
            cbVideoInputFormat.Size = new System.Drawing.Size(339, 33);
            cbVideoInputFormat.TabIndex = 131;
            cbVideoInputFormat.SelectedIndexChanged += cbVideoInputFormat_SelectedIndexChanged;
            // 
            // cbVideoInputDevice
            // 
            cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputDevice.FormattingEnabled = true;
            cbVideoInputDevice.Location = new System.Drawing.Point(32, 60);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(339, 33);
            cbVideoInputDevice.TabIndex = 130;
            cbVideoInputDevice.SelectedIndexChanged += cbVideoInputDevice_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(27, 131);
            label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 25);
            label13.TabIndex = 129;
            label13.Text = "Input format";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(27, 29);
            label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(109, 25);
            label11.TabIndex = 128;
            label11.Text = "Input device";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 252);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(138, 25);
            label1.TabIndex = 136;
            label1.Text = "Output MP4 file";
            // 
            // edOutputFile
            // 
            edOutputFile.Location = new System.Drawing.Point(32, 280);
            edOutputFile.Name = "edOutputFile";
            edOutputFile.Size = new System.Drawing.Size(457, 31);
            edOutputFile.TabIndex = 137;
            // 
            // btSelectOutputFile
            // 
            btSelectOutputFile.Location = new System.Drawing.Point(502, 278);
            btSelectOutputFile.Name = "btSelectOutputFile";
            btSelectOutputFile.Size = new System.Drawing.Size(37, 34);
            btSelectOutputFile.TabIndex = 138;
            btSelectOutputFile.Text = "...";
            btSelectOutputFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1303, 545);
            Controls.Add(btSelectOutputFile);
            Controls.Add(edOutputFile);
            Controls.Add(label1);
            Controls.Add(label28);
            Controls.Add(label18);
            Controls.Add(cbVideoInputFrameRate);
            Controls.Add(cbVideoInputFormat);
            Controls.Add(cbVideoInputDevice);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - H264 webcam capture code snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edOutputFile;
        private System.Windows.Forms.Button btSelectOutputFile;
    }
}
