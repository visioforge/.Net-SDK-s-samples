namespace video_capture_text_overlay
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

            videoCapture1?.Dispose();
            videoCapture1 = null;

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
            btRegisterCamera = new System.Windows.Forms.Button();
            cbVideoSource = new System.Windows.Forms.ComboBox();
            cbAudioSource = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(19, 42);
            VideoView1.Margin = new System.Windows.Forms.Padding(4);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(747, 429);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 0;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(19, 479);
            btStart.Margin = new System.Windows.Forms.Padding(4);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(88, 26);
            btStart.TabIndex = 1;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(113, 479);
            btStop.Margin = new System.Windows.Forms.Padding(4);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(88, 26);
            btStop.TabIndex = 2;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // btRegisterCamera
            // 
            btRegisterCamera.Location = new System.Drawing.Point(644, 479);
            btRegisterCamera.Margin = new System.Windows.Forms.Padding(2);
            btRegisterCamera.Name = "btRegisterCamera";
            btRegisterCamera.Size = new System.Drawing.Size(122, 26);
            btRegisterCamera.TabIndex = 3;
            btRegisterCamera.Text = "Register Camera";
            btRegisterCamera.UseVisualStyleBackColor = true;
            btRegisterCamera.Click += btRegisterCamera_Click;
            // 
            // cbVideoSource
            // 
            cbVideoSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoSource.FormattingEnabled = true;
            cbVideoSource.Location = new System.Drawing.Point(19, 12);
            cbVideoSource.Name = "cbVideoSource";
            cbVideoSource.Size = new System.Drawing.Size(300, 23);
            cbVideoSource.TabIndex = 4;
            // 
            // cbAudioSource
            // 
            cbAudioSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioSource.FormattingEnabled = true;
            cbAudioSource.Location = new System.Drawing.Point(325, 12);
            cbAudioSource.Name = "cbAudioSource";
            cbAudioSource.Size = new System.Drawing.Size(300, 23);
            cbAudioSource.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(786, 516);
            Controls.Add(cbAudioSource);
            Controls.Add(cbVideoSource);
            Controls.Add(btRegisterCamera);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Controls.Add(VideoView1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Text = "Video Capture SDK .Net - Video preview with streaming to Virtual Camera";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btRegisterCamera;
        private System.Windows.Forms.ComboBox cbVideoSource;
        private System.Windows.Forms.ComboBox cbAudioSource;
    }
}
