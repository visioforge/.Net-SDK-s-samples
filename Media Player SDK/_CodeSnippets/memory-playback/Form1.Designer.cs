using System.Drawing;
using System.Windows.Forms;

namespace memory_playback
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
            btOpen = new Button();
            videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            rbAudio = new RadioButton();
            rbVideoAudio = new RadioButton();
            rbVideoNoAudio = new RadioButton();
            SuspendLayout();
            // 
            // btOpen
            // 
            btOpen.Location = new Point(12, 452);
            btOpen.Name = "btOpen";
            btOpen.Size = new Size(539, 46);
            btOpen.TabIndex = 1;
            btOpen.Text = "Select file and play";
            btOpen.UseVisualStyleBackColor = true;
            btOpen.Click += btOpen_Click;
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(12, 12);
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(539, 382);
            videoView1.StatusOverlay = null;
            videoView1.TabIndex = 2;
            // 
            // rbAudio
            // 
            rbAudio.AutoSize = true;
            rbAudio.Location = new Point(12, 411);
            rbAudio.Name = "rbAudio";
            rbAudio.Size = new Size(95, 24);
            rbAudio.TabIndex = 3;
            rbAudio.Text = "Audio file";
            rbAudio.UseVisualStyleBackColor = true;
            // 
            // rbVideoAudio
            // 
            rbVideoAudio.AutoSize = true;
            rbVideoAudio.Checked = true;
            rbVideoAudio.Location = new Point(153, 411);
            rbVideoAudio.Name = "rbVideoAudio";
            rbVideoAudio.Size = new Size(168, 24);
            rbVideoAudio.TabIndex = 4;
            rbVideoAudio.TabStop = true;
            rbVideoAudio.Text = "Video file with audio";
            rbVideoAudio.UseVisualStyleBackColor = true;
            // 
            // rbVideoNoAudio
            // 
            rbVideoNoAudio.AutoSize = true;
            rbVideoNoAudio.Location = new Point(361, 411);
            rbVideoNoAudio.Name = "rbVideoNoAudio";
            rbVideoNoAudio.Size = new Size(190, 24);
            rbVideoNoAudio.TabIndex = 5;
            rbVideoNoAudio.Text = "Video file without audio";
            rbVideoNoAudio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 512);
            Controls.Add(rbVideoNoAudio);
            Controls.Add(rbVideoAudio);
            Controls.Add(rbAudio);
            Controls.Add(videoView1);
            Controls.Add(btOpen);
            Name = "Form1";
            Text = "Media Player SDK .Net - Memory Playback code snippet";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOpen;
        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private RadioButton rbAudio;
        private RadioButton rbVideoAudio;
        private RadioButton rbVideoNoAudio;
    }
}