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
            components = new System.ComponentModel.Container();
            btStart = new System.Windows.Forms.Button();
            btStop = new System.Windows.Forms.Button();
            edURL = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            lbTime = new System.Windows.Forms.Label();
            tbTimeline = new System.Windows.Forms.TrackBar();
            mmLog = new System.Windows.Forms.TextBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            btReadFormats = new System.Windows.Forms.Button();
            cbVideoStream = new System.Windows.Forms.ComboBox();
            cbAudioStream = new System.Windows.Forms.ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            cbAudioOutput = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            SuspendLayout();
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(193, 98);
            btStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(125, 44);
            btStart.TabIndex = 0;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += BtStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new System.Drawing.Point(328, 98);
            btStop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btStop.Name = "btStop";
            btStop.Size = new System.Drawing.Size(125, 44);
            btStop.TabIndex = 1;
            btStop.Text = "Stop";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += BtStop_Click;
            // 
            // edURL
            // 
            edURL.Location = new System.Drawing.Point(20, 48);
            edURL.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            edURL.Name = "edURL";
            edURL.Size = new System.Drawing.Size(908, 31);
            edURL.TabIndex = 2;
            edURL.Text = "https://www.youtube.com/watch?v=d2smz_1L2_0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 17);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 25);
            label1.TabIndex = 3;
            label1.Text = "URL";
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Location = new System.Drawing.Point(773, 108);
            lbTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(155, 25);
            lbTime.TabIndex = 6;
            lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Location = new System.Drawing.Point(503, 98);
            tbTimeline.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(260, 69);
            tbTimeline.TabIndex = 5;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // mmLog
            // 
            mmLog.Location = new System.Drawing.Point(20, 954);
            mmLog.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmLog.Multiline = true;
            mmLog.Name = "mmLog";
            mmLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmLog.Size = new System.Drawing.Size(908, 114);
            mmLog.TabIndex = 8;
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Location = new System.Drawing.Point(20, 909);
            cbDebugMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(144, 29);
            cbDebugMode.TabIndex = 7;
            cbDebugMode.Text = "Debug mode";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 163);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(145, 25);
            label2.TabIndex = 9;
            label2.Text = "Selected streams";
            // 
            // btReadFormats
            // 
            btReadFormats.Location = new System.Drawing.Point(20, 98);
            btReadFormats.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btReadFormats.Name = "btReadFormats";
            btReadFormats.Size = new System.Drawing.Size(163, 44);
            btReadFormats.TabIndex = 11;
            btReadFormats.Text = "Read formats";
            btReadFormats.UseVisualStyleBackColor = true;
            btReadFormats.Click += BtReadFormats_Click;
            // 
            // cbVideoStream
            // 
            cbVideoStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoStream.FormattingEnabled = true;
            cbVideoStream.Location = new System.Drawing.Point(193, 160);
            cbVideoStream.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbVideoStream.Name = "cbVideoStream";
            cbVideoStream.Size = new System.Drawing.Size(354, 33);
            cbVideoStream.TabIndex = 12;
            // 
            // cbAudioStream
            // 
            cbAudioStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioStream.FormattingEnabled = true;
            cbAudioStream.Location = new System.Drawing.Point(577, 160);
            cbAudioStream.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbAudioStream.Name = "cbAudioStream";
            cbAudioStream.Size = new System.Drawing.Size(354, 33);
            cbAudioStream.TabIndex = 13;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // VideoView1
            // 
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(20, 279);
            VideoView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(908, 605);
            VideoView1.StatusOverlay = null;
            VideoView1.TabIndex = 14;
            // 
            // cbAudioOutput
            // 
            cbAudioOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAudioOutput.FormattingEnabled = true;
            cbAudioOutput.Location = new System.Drawing.Point(193, 217);
            cbAudioOutput.Name = "cbAudioOutput";
            cbAudioOutput.Size = new System.Drawing.Size(735, 33);
            cbAudioOutput.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 220);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(119, 25);
            label4.TabIndex = 18;
            label4.Text = "Audio output";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(958, 1098);
            Controls.Add(cbAudioOutput);
            Controls.Add(label4);
            Controls.Add(VideoView1);
            Controls.Add(cbAudioStream);
            Controls.Add(cbVideoStream);
            Controls.Add(btReadFormats);
            Controls.Add(label2);
            Controls.Add(mmLog);
            Controls.Add(cbDebugMode);
            Controls.Add(lbTime);
            Controls.Add(tbTimeline);
            Controls.Add(label1);
            Controls.Add(edURL);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Media Player SDK .Net - YouTube Player Demo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.Label label4;
    }
}

