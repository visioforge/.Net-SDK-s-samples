using VisioForge.Types;
using System;

namespace multiple_ap_cams
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

            VideoCapture2?.Dispose();
            VideoCapture2 = null;

            tmRecording1?.Dispose();
            tmRecording1 = null;

            tmRecording2?.Dispose();
            tmRecording2 = null;

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
            this.btStart1 = new System.Windows.Forms.Button();
            this.btStop1 = new System.Windows.Forms.Button();
            this.btStart2 = new System.Windows.Forms.Button();
            this.btStop2 = new System.Windows.Forms.Button();
            this.cbCamera1 = new System.Windows.Forms.ComboBox();
            this.cbCamera2 = new System.Windows.Forms.ComboBox();
            this.lbTimestamp1 = new System.Windows.Forms.Label();
            this.lbTimestamp2 = new System.Windows.Forms.Label();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cbFrameRate1 = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFrameRate2 = new System.Windows.Forms.ComboBox();
            this.cbVideoInputFormat2 = new System.Windows.Forms.ComboBox();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.VideoView2 = new VisioForge.Core.UI.WinForms.VideoView();
            this.SuspendLayout();
            // 
            // btStart1
            // 
            this.btStart1.Location = new System.Drawing.Point(12, 318);
            this.btStart1.Name = "btStart1";
            this.btStart1.Size = new System.Drawing.Size(75, 23);
            this.btStart1.TabIndex = 2;
            this.btStart1.Text = "Start";
            this.btStart1.UseVisualStyleBackColor = true;
            this.btStart1.Click += new System.EventHandler(this.btStart1_Click);
            // 
            // btStop1
            // 
            this.btStop1.Location = new System.Drawing.Point(93, 318);
            this.btStop1.Name = "btStop1";
            this.btStop1.Size = new System.Drawing.Size(75, 23);
            this.btStop1.TabIndex = 3;
            this.btStop1.Text = "Stop";
            this.btStop1.UseVisualStyleBackColor = true;
            this.btStop1.Click += new System.EventHandler(this.btStop1_Click);
            // 
            // btStart2
            // 
            this.btStart2.Location = new System.Drawing.Point(331, 318);
            this.btStart2.Name = "btStart2";
            this.btStart2.Size = new System.Drawing.Size(75, 23);
            this.btStart2.TabIndex = 4;
            this.btStart2.Text = "Start";
            this.btStart2.UseVisualStyleBackColor = true;
            this.btStart2.Click += new System.EventHandler(this.btStart2_Click);
            // 
            // btStop2
            // 
            this.btStop2.Location = new System.Drawing.Point(412, 318);
            this.btStop2.Name = "btStop2";
            this.btStop2.Size = new System.Drawing.Size(75, 23);
            this.btStop2.TabIndex = 5;
            this.btStop2.Text = "Stop";
            this.btStop2.UseVisualStyleBackColor = true;
            this.btStop2.Click += new System.EventHandler(this.btStop2_Click);
            // 
            // cbCamera1
            // 
            this.cbCamera1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera1.FormattingEnabled = true;
            this.cbCamera1.Location = new System.Drawing.Point(12, 246);
            this.cbCamera1.Name = "cbCamera1";
            this.cbCamera1.Size = new System.Drawing.Size(295, 21);
            this.cbCamera1.TabIndex = 6;
            this.cbCamera1.SelectedIndexChanged += new System.EventHandler(this.cbCamera1_SelectedIndexChanged);
            // 
            // cbCamera2
            // 
            this.cbCamera2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera2.FormattingEnabled = true;
            this.cbCamera2.Location = new System.Drawing.Point(331, 246);
            this.cbCamera2.Name = "cbCamera2";
            this.cbCamera2.Size = new System.Drawing.Size(295, 21);
            this.cbCamera2.TabIndex = 7;
            this.cbCamera2.SelectedIndexChanged += new System.EventHandler(this.cbCamera2_SelectedIndexChanged);
            // 
            // lbTimestamp1
            // 
            this.lbTimestamp1.AutoSize = true;
            this.lbTimestamp1.Location = new System.Drawing.Point(181, 323);
            this.lbTimestamp1.Name = "lbTimestamp1";
            this.lbTimestamp1.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp1.TabIndex = 103;
            this.lbTimestamp1.Text = "Recording time: 00:00:00";
            // 
            // lbTimestamp2
            // 
            this.lbTimestamp2.AutoSize = true;
            this.lbTimestamp2.Location = new System.Drawing.Point(500, 323);
            this.lbTimestamp2.Name = "lbTimestamp2";
            this.lbTimestamp2.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp2.TabIndex = 104;
            this.lbTimestamp2.Text = "Recording time: 00:00:00";
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(12, 383);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 112;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(12, 406);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(619, 191);
            this.mmLog.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "All settings set to default. You can check Main Demo for more options";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(286, 276);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 124;
            this.label28.Text = "fps";
            // 
            // cbFrameRate1
            // 
            this.cbFrameRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrameRate1.FormattingEnabled = true;
            this.cbFrameRate1.Location = new System.Drawing.Point(215, 273);
            this.cbFrameRate1.Name = "cbFrameRate1";
            this.cbFrameRate1.Size = new System.Drawing.Size(65, 21);
            this.cbFrameRate1.TabIndex = 122;
            // 
            // cbVideoInputFormat1
            // 
            this.cbVideoInputFormat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat1.FormattingEnabled = true;
            this.cbVideoInputFormat1.Location = new System.Drawing.Point(12, 273);
            this.cbVideoInputFormat1.Name = "cbVideoInputFormat1";
            this.cbVideoInputFormat1.Size = new System.Drawing.Size(197, 21);
            this.cbVideoInputFormat1.TabIndex = 121;
            this.cbVideoInputFormat1.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "fps";
            // 
            // cbFrameRate2
            // 
            this.cbFrameRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrameRate2.FormattingEnabled = true;
            this.cbFrameRate2.Location = new System.Drawing.Point(534, 273);
            this.cbFrameRate2.Name = "cbFrameRate2";
            this.cbFrameRate2.Size = new System.Drawing.Size(65, 21);
            this.cbFrameRate2.TabIndex = 126;
            // 
            // cbVideoInputFormat2
            // 
            this.cbVideoInputFormat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoInputFormat2.FormattingEnabled = true;
            this.cbVideoInputFormat2.Location = new System.Drawing.Point(331, 273);
            this.cbVideoInputFormat2.Name = "cbVideoInputFormat2";
            this.cbVideoInputFormat2.Size = new System.Drawing.Size(197, 21);
            this.cbVideoInputFormat2.TabIndex = 125;
            this.cbVideoInputFormat2.SelectedIndexChanged += new System.EventHandler(this.cbVideoInputFormat2_SelectedIndexChanged);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(12, 12);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(295, 217);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 128;
            // 
            // VideoView2
            // 
            this.VideoView2.BackColor = System.Drawing.Color.Black;
            this.VideoView2.Location = new System.Drawing.Point(331, 12);
            this.VideoView2.Name = "VideoView2";
            this.VideoView2.Size = new System.Drawing.Size(295, 217);
            this.VideoView2.StatusOverlay = null;
            this.VideoView2.TabIndex = 129;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 609);
            this.Controls.Add(this.VideoView2);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFrameRate2);
            this.Controls.Add(this.cbVideoInputFormat2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cbFrameRate1);
            this.Controls.Add(this.cbVideoInputFormat1);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTimestamp2);
            this.Controls.Add(this.lbTimestamp1);
            this.Controls.Add(this.cbCamera2);
            this.Controls.Add(this.cbCamera1);
            this.Controls.Add(this.btStop2);
            this.Controls.Add(this.btStart2);
            this.Controls.Add(this.btStop1);
            this.Controls.Add(this.btStart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Multiple web cameras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart1;
        private System.Windows.Forms.Button btStop1;
        private System.Windows.Forms.Button btStart2;
        private System.Windows.Forms.Button btStop2;
        private System.Windows.Forms.ComboBox cbCamera1;
        private System.Windows.Forms.ComboBox cbCamera2;
        private System.Windows.Forms.Label lbTimestamp1;
        private System.Windows.Forms.Label lbTimestamp2;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cbFrameRate1;
        private System.Windows.Forms.ComboBox cbVideoInputFormat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFrameRate2;
        private System.Windows.Forms.ComboBox cbVideoInputFormat2;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private VisioForge.Core.UI.WinForms.VideoView VideoView2;
    }
}

