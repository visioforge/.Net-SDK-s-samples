namespace youtube_player
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

            MediaPlayer1?.Dispose();
            MediaPlayer1 = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.edURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btReadFormats = new System.Windows.Forms.Button();
            this.cbVideoStream = new System.Windows.Forms.ComboBox();
            this.cbAudioStream = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(116, 51);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.BtStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(197, 51);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // edURL
            // 
            this.edURL.Location = new System.Drawing.Point(15, 25);
            this.edURL.Name = "edURL";
            this.edURL.Size = new System.Drawing.Size(545, 20);
            this.edURL.TabIndex = 2;
            this.edURL.Text = "https://www.youtube.com/watch?v=d2smz_1L2_0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(464, 64);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(96, 13);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(302, 51);
            this.tbTimeline.Maximum = 100;
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(156, 45);
            this.tbTimeline.TabIndex = 5;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // mmLog
            // 
            this.mmLog.Location = new System.Drawing.Point(15, 565);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmLog.Size = new System.Drawing.Size(545, 61);
            this.mmLog.TabIndex = 8;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(15, 542);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 7;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Selected streams";
            // 
            // btReadFormats
            // 
            this.btReadFormats.Location = new System.Drawing.Point(15, 51);
            this.btReadFormats.Name = "btReadFormats";
            this.btReadFormats.Size = new System.Drawing.Size(95, 23);
            this.btReadFormats.TabIndex = 11;
            this.btReadFormats.Text = "Read formats";
            this.btReadFormats.UseVisualStyleBackColor = true;
            this.btReadFormats.Click += new System.EventHandler(this.BtReadFormats_Click);
            // 
            // cbVideoStream
            // 
            this.cbVideoStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoStream.FormattingEnabled = true;
            this.cbVideoStream.Location = new System.Drawing.Point(116, 83);
            this.cbVideoStream.Name = "cbVideoStream";
            this.cbVideoStream.Size = new System.Drawing.Size(214, 21);
            this.cbVideoStream.TabIndex = 12;
            // 
            // cbAudioStream
            // 
            this.cbAudioStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioStream.FormattingEnabled = true;
            this.cbAudioStream.Location = new System.Drawing.Point(346, 83);
            this.cbAudioStream.Name = "cbAudioStream";
            this.cbAudioStream.Size = new System.Drawing.Size(214, 21);
            this.cbAudioStream.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(15, 120);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(545, 406);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 642);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.cbAudioStream);
            this.Controls.Add(this.cbVideoStream);
            this.Controls.Add(this.btReadFormats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.tbTimeline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edURL);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Name = "Form1";
            this.Text = "Media Player SDK .Net - YouTube Player Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.TextBox edURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.TextBox mmLog;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btReadFormats;
        private System.Windows.Forms.ComboBox cbVideoStream;
        private System.Windows.Forms.ComboBox cbAudioStream;
        private System.Windows.Forms.Timer timer1;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    }
}

