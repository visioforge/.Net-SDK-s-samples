using VisioForge.Core.Types;
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
            this.label1 = new System.Windows.Forms.Label();
            this.edURL1 = new System.Windows.Forms.TextBox();
            this.edURL2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTimestamp1 = new System.Windows.Forms.Label();
            this.lbTimestamp2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.VideoView2 = new VisioForge.Core.UI.WinForms.VideoView();
            this.edPassword1 = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.edLogin1 = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.edPassword2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edLogin2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btStart1
            // 
            this.btStart1.Location = new System.Drawing.Point(12, 336);
            this.btStart1.Name = "btStart1";
            this.btStart1.Size = new System.Drawing.Size(75, 23);
            this.btStart1.TabIndex = 2;
            this.btStart1.Text = "Start";
            this.btStart1.UseVisualStyleBackColor = true;
            this.btStart1.Click += new System.EventHandler(this.btStart1_Click);
            // 
            // btStop1
            // 
            this.btStop1.Location = new System.Drawing.Point(93, 336);
            this.btStop1.Name = "btStop1";
            this.btStop1.Size = new System.Drawing.Size(75, 23);
            this.btStop1.TabIndex = 3;
            this.btStop1.Text = "Stop";
            this.btStop1.UseVisualStyleBackColor = true;
            this.btStop1.Click += new System.EventHandler(this.btStop1_Click);
            // 
            // btStart2
            // 
            this.btStart2.Location = new System.Drawing.Point(334, 336);
            this.btStart2.Name = "btStart2";
            this.btStart2.Size = new System.Drawing.Size(75, 23);
            this.btStart2.TabIndex = 4;
            this.btStart2.Text = "Start";
            this.btStart2.UseVisualStyleBackColor = true;
            this.btStart2.Click += new System.EventHandler(this.btStart2_Click);
            // 
            // btStop2
            // 
            this.btStop2.Location = new System.Drawing.Point(415, 336);
            this.btStop2.Name = "btStop2";
            this.btStop2.Size = new System.Drawing.Size(75, 23);
            this.btStop2.TabIndex = 5;
            this.btStop2.Text = "Stop";
            this.btStop2.UseVisualStyleBackColor = true;
            this.btStop2.Click += new System.EventHandler(this.btStop2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // edURL1
            // 
            this.edURL1.Location = new System.Drawing.Point(47, 246);
            this.edURL1.Name = "edURL1";
            this.edURL1.Size = new System.Drawing.Size(260, 20);
            this.edURL1.TabIndex = 7;
            this.edURL1.Text = "http://192.168.1.22/onvif/device_service";
            // 
            // edURL2
            // 
            this.edURL2.Location = new System.Drawing.Point(366, 246);
            this.edURL2.Name = "edURL2";
            this.edURL2.Size = new System.Drawing.Size(260, 20);
            this.edURL2.TabIndex = 9;
            this.edURL2.Text = "http://192.168.1.22/onvif/device_service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "URL";
            // 
            // lbTimestamp1
            // 
            this.lbTimestamp1.AutoSize = true;
            this.lbTimestamp1.Location = new System.Drawing.Point(178, 341);
            this.lbTimestamp1.Name = "lbTimestamp1";
            this.lbTimestamp1.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp1.TabIndex = 103;
            this.lbTimestamp1.Text = "Recording time: 00:00:00";
            // 
            // lbTimestamp2
            // 
            this.lbTimestamp2.AutoSize = true;
            this.lbTimestamp2.Location = new System.Drawing.Point(503, 341);
            this.lbTimestamp2.Name = "lbTimestamp2";
            this.lbTimestamp2.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp2.TabIndex = 104;
            this.lbTimestamp2.Text = "Recording time: 00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "All settings set to default. You can check IP Capture Demo or Main Demo for more " +
    "options";
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(12, 418);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 108;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(12, 441);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(614, 105);
            this.mmLog.TabIndex = 107;
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(12, 12);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(295, 218);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 109;
            // 
            // VideoView2
            // 
            this.VideoView2.BackColor = System.Drawing.Color.Black;
            this.VideoView2.Location = new System.Drawing.Point(334, 12);
            this.VideoView2.Name = "VideoView2";
            this.VideoView2.Size = new System.Drawing.Size(292, 218);
            this.VideoView2.StatusOverlay = null;
            this.VideoView2.TabIndex = 110;
            // 
            // edPassword1
            // 
            this.edPassword1.Location = new System.Drawing.Point(168, 297);
            this.edPassword1.Name = "edPassword1";
            this.edPassword1.Size = new System.Drawing.Size(100, 20);
            this.edPassword1.TabIndex = 118;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(165, 280);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(53, 13);
            this.label167.TabIndex = 117;
            this.label167.Text = "Password";
            // 
            // edLogin1
            // 
            this.edLogin1.Location = new System.Drawing.Point(15, 297);
            this.edLogin1.Name = "edLogin1";
            this.edLogin1.Size = new System.Drawing.Size(100, 20);
            this.edLogin1.TabIndex = 116;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(11, 280);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(33, 13);
            this.label166.TabIndex = 115;
            this.label166.Text = "Login";
            // 
            // edPassword2
            // 
            this.edPassword2.Location = new System.Drawing.Point(487, 297);
            this.edPassword2.Name = "edPassword2";
            this.edPassword2.Size = new System.Drawing.Size(100, 20);
            this.edPassword2.TabIndex = 122;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Password";
            // 
            // edLogin2
            // 
            this.edLogin2.Location = new System.Drawing.Point(334, 297);
            this.edLogin2.Name = "edLogin2";
            this.edLogin2.Size = new System.Drawing.Size(100, 20);
            this.edLogin2.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "Login";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 558);
            this.Controls.Add(this.edPassword2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edLogin2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edPassword1);
            this.Controls.Add(this.label167);
            this.Controls.Add(this.edLogin1);
            this.Controls.Add(this.label166);
            this.Controls.Add(this.VideoView2);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTimestamp2);
            this.Controls.Add(this.lbTimestamp1);
            this.Controls.Add(this.edURL2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edURL1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStop2);
            this.Controls.Add(this.btStart2);
            this.Controls.Add(this.btStop1);
            this.Controls.Add(this.btStart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Multiple IP cameras";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edURL1;
        private System.Windows.Forms.TextBox edURL2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTimestamp1;
        private System.Windows.Forms.Label lbTimestamp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private VisioForge.Core.UI.WinForms.VideoView VideoView2;
        private System.Windows.Forms.TextBox edPassword1;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.TextBox edLogin1;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.TextBox edPassword2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edLogin2;
        private System.Windows.Forms.Label label5;
    }
}

