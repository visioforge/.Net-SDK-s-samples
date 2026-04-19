namespace opengl_shader
{
    using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btStop = new System.Windows.Forms.Button();
            btStart = new System.Windows.Forms.Button();
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            label28 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            cbVideoInputFrameRate = new System.Windows.Forms.ComboBox();
            cbVideoInputFormat = new System.Windows.Forms.ComboBox();
            cbVideoInputDevice = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            rbNone = new System.Windows.Forms.RadioButton();
            rbGrayscale = new System.Windows.Forms.RadioButton();
            rbInvert = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btStop
            // 
            btStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStop.Location = new System.Drawing.Point(128, 458);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(103, 44);
            btStop.TabIndex = 74;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btStart.Location = new System.Drawing.Point(20, 458);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(103, 44);
            btStart.TabIndex = 73;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // VideoView1
            // 
            VideoView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(668, 23);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(667, 479);
            VideoView1.TabIndex = 78;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(495, 161);
            label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(37, 25);
            label28.TabIndex = 134;
            label28.Text = "fps";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(371, 125);
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
            cbVideoInputFrameRate.Location = new System.Drawing.Point(376, 155);
            cbVideoInputFrameRate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputFrameRate.Name = "cbVideoInputFrameRate";
            cbVideoInputFrameRate.Size = new System.Drawing.Size(106, 33);
            cbVideoInputFrameRate.TabIndex = 132;
            // 
            // cbVideoInputFormat
            // 
            cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoInputFormat.FormattingEnabled = true;
            cbVideoInputFormat.Location = new System.Drawing.Point(25, 155);
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
            cbVideoInputDevice.Location = new System.Drawing.Point(25, 54);
            cbVideoInputDevice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoInputDevice.Name = "cbVideoInputDevice";
            cbVideoInputDevice.Size = new System.Drawing.Size(339, 33);
            cbVideoInputDevice.TabIndex = 130;
            cbVideoInputDevice.SelectedIndexChanged += cbVideoInputDevice_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(20, 125);
            label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 25);
            label13.TabIndex = 129;
            label13.Text = "Input format";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(20, 23);
            label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(109, 25);
            label11.TabIndex = 128;
            label11.Text = "Input device";
            // 
            // rbNone
            // 
            rbNone.AutoSize = true;
            rbNone.Checked = true;
            rbNone.Location = new System.Drawing.Point(25, 225);
            rbNone.Name = "rbNone";
            rbNone.Size = new System.Drawing.Size(80, 29);
            rbNone.TabIndex = 135;
            rbNone.TabStop = true;
            rbNone.Text = "None";
            rbNone.UseVisualStyleBackColor = true;
            rbNone.CheckedChanged += rbShader_CheckedChanged;
            // 
            // rbGrayscale
            // 
            rbGrayscale.AutoSize = true;
            rbGrayscale.Location = new System.Drawing.Point(139, 225);
            rbGrayscale.Name = "rbGrayscale";
            rbGrayscale.Size = new System.Drawing.Size(111, 29);
            rbGrayscale.TabIndex = 136;
            rbGrayscale.Text = "Grayscale";
            rbGrayscale.UseVisualStyleBackColor = true;
            rbGrayscale.CheckedChanged += rbShader_CheckedChanged;
            // 
            // rbInvert
            // 
            rbInvert.AutoSize = true;
            rbInvert.Location = new System.Drawing.Point(283, 225);
            rbInvert.Name = "rbInvert";
            rbInvert.Size = new System.Drawing.Size(82, 29);
            rbInvert.TabIndex = 137;
            rbInvert.Text = "Invert";
            rbInvert.UseVisualStyleBackColor = true;
            rbInvert.CheckedChanged += rbShader_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 299);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(565, 25);
            label1.TabIndex = 138;
            label1.Text = "You can apply your own custom OpenGL shaders to the video stream.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1355, 525);
            Controls.Add(label1);
            Controls.Add(rbInvert);
            Controls.Add(rbGrayscale);
            Controls.Add(rbNone);
            Controls.Add(label28);
            Controls.Add(label18);
            Controls.Add(cbVideoInputFrameRate);
            Controls.Add(cbVideoInputFormat);
            Controls.Add(cbVideoInputDevice);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(VideoView1);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Blocks SDK .Net - Sample OpenGL Shader Code Snippet";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbVideoInputFrameRate;
        private System.Windows.Forms.ComboBox cbVideoInputFormat;
        private System.Windows.Forms.ComboBox cbVideoInputDevice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbGrayscale;
        private System.Windows.Forms.RadioButton rbInvert;
        private System.Windows.Forms.Label label1;
    }
}

