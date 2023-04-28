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
            SuspendLayout();
            // 
            // btOpen
            // 
            btOpen.Location = new Point(12, 400);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 463);
            Controls.Add(videoView1);
            Controls.Add(btOpen);
            Name = "Form1";
            Text = "Media Player SDK .Net - Memory Playback code snippet";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btOpen;
        private VisioForge.Core.UI.WinForms.VideoView videoView1;
    }
}