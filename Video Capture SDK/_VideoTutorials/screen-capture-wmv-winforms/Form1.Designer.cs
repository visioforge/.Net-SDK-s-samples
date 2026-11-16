namespace ScreenCaptureWmv;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
        lbMonitor = new Label();
        cbMonitor = new ComboBox();
        lbFrameRate = new Label();
        cbFrameRate = new ComboBox();
        lbSound = new Label();
        cbSound = new ComboBox();
        lbVideoCodec = new Label();
        cbVideoCodec = new ComboBox();
        lbAudioCodec = new Label();
        cbAudioCodec = new ComboBox();
        lbAudioFormat = new Label();
        cbAudioFormat = new ComboBox();
        cbCursor = new CheckBox();
        cbRecordSound = new CheckBox();
        btStart = new Button();
        btStop = new Button();
        SuspendLayout();
        // 
        // VideoView1
        // 
        VideoView1.BackColor = Color.Black;
        VideoView1.Location = new Point(344, 21);
        VideoView1.Name = "VideoView1";
        VideoView1.Size = new Size(640, 360);
        VideoView1.TabIndex = 0;
        // 
        // lbMonitor
        // 
        lbMonitor.AutoSize = true;
        lbMonitor.Location = new Point(20, 21);
        lbMonitor.Name = "lbMonitor";
        lbMonitor.Size = new Size(51, 15);
        lbMonitor.TabIndex = 1;
        lbMonitor.Text = "Monitor";
        // 
        // cbMonitor
        // 
        cbMonitor.DropDownStyle = ComboBoxStyle.DropDownList;
        cbMonitor.FormattingEnabled = true;
        cbMonitor.Location = new Point(20, 45);
        cbMonitor.Name = "cbMonitor";
        cbMonitor.Size = new Size(300, 23);
        cbMonitor.TabIndex = 2;
        // 
        // lbFrameRate
        // 
        lbFrameRate.AutoSize = true;
        lbFrameRate.Location = new Point(20, 87);
        lbFrameRate.Name = "lbFrameRate";
        lbFrameRate.Size = new Size(63, 15);
        lbFrameRate.TabIndex = 3;
        lbFrameRate.Text = "Frame rate";
        // 
        // cbFrameRate
        // 
        cbFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
        cbFrameRate.FormattingEnabled = true;
        cbFrameRate.Location = new Point(20, 111);
        cbFrameRate.Name = "cbFrameRate";
        cbFrameRate.Size = new Size(300, 23);
        cbFrameRate.TabIndex = 4;
        // 
        // lbSound
        // 
        lbSound.AutoSize = true;
        lbSound.Location = new Point(20, 153);
        lbSound.Name = "lbSound";
        lbSound.Size = new Size(41, 15);
        lbSound.TabIndex = 5;
        lbSound.Text = "Sound";
        // 
        // cbSound
        // 
        cbSound.DropDownStyle = ComboBoxStyle.DropDownList;
        cbSound.FormattingEnabled = true;
        cbSound.Location = new Point(20, 177);
        cbSound.Name = "cbSound";
        cbSound.Size = new Size(300, 23);
        cbSound.TabIndex = 6;
        // 
        // lbVideoCodec
        // 
        lbVideoCodec.AutoSize = true;
        lbVideoCodec.Location = new Point(20, 219);
        lbVideoCodec.Name = "lbVideoCodec";
        lbVideoCodec.Size = new Size(72, 15);
        lbVideoCodec.TabIndex = 7;
        lbVideoCodec.Text = "Video codec";
        // 
        // cbVideoCodec
        // 
        cbVideoCodec.DropDownStyle = ComboBoxStyle.DropDownList;
        cbVideoCodec.FormattingEnabled = true;
        cbVideoCodec.Location = new Point(20, 243);
        cbVideoCodec.Name = "cbVideoCodec";
        cbVideoCodec.Size = new Size(300, 23);
        cbVideoCodec.TabIndex = 8;
        // 
        // lbAudioCodec
        // 
        lbAudioCodec.AutoSize = true;
        lbAudioCodec.Location = new Point(20, 285);
        lbAudioCodec.Name = "lbAudioCodec";
        lbAudioCodec.Size = new Size(73, 15);
        lbAudioCodec.TabIndex = 9;
        lbAudioCodec.Text = "Audio codec";
        // 
        // cbAudioCodec
        // 
        cbAudioCodec.DropDownStyle = ComboBoxStyle.DropDownList;
        cbAudioCodec.FormattingEnabled = true;
        cbAudioCodec.Location = new Point(20, 309);
        cbAudioCodec.Name = "cbAudioCodec";
        cbAudioCodec.Size = new Size(300, 23);
        cbAudioCodec.TabIndex = 10;
        cbAudioCodec.SelectedIndexChanged += cbAudioCodec_SelectedIndexChanged;
        // 
        // lbAudioFormat
        // 
        lbAudioFormat.AutoSize = true;
        lbAudioFormat.Location = new Point(20, 351);
        lbAudioFormat.Name = "lbAudioFormat";
        lbAudioFormat.Size = new Size(78, 15);
        lbAudioFormat.TabIndex = 11;
        lbAudioFormat.Text = "Audio format";
        // 
        // cbAudioFormat
        // 
        cbAudioFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        cbAudioFormat.FormattingEnabled = true;
        cbAudioFormat.Location = new Point(20, 375);
        cbAudioFormat.Name = "cbAudioFormat";
        cbAudioFormat.Size = new Size(300, 23);
        cbAudioFormat.TabIndex = 12;
        // 
        // cbCursor
        // 
        cbCursor.AutoSize = true;
        cbCursor.Checked = true;
        cbCursor.CheckState = CheckState.Checked;
        cbCursor.Location = new Point(20, 417);
        cbCursor.Name = "cbCursor";
        cbCursor.Size = new Size(96, 19);
        cbCursor.TabIndex = 13;
        cbCursor.Text = "Mouse cursor";
        cbCursor.UseVisualStyleBackColor = true;
        // 
        // cbRecordSound
        // 
        cbRecordSound.AutoSize = true;
        cbRecordSound.Checked = true;
        cbRecordSound.CheckState = CheckState.Checked;
        cbRecordSound.Location = new Point(20, 447);
        cbRecordSound.Name = "cbRecordSound";
        cbRecordSound.Size = new Size(94, 19);
        cbRecordSound.TabIndex = 14;
        cbRecordSound.Text = "Record sound";
        cbRecordSound.UseVisualStyleBackColor = true;
        // 
        // btStart
        // 
        btStart.Location = new Point(20, 497);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 15;
        btStart.Text = "Start";
        btStart.UseVisualStyleBackColor = true;
        btStart.Click += btStart_Click;
        // 
        // btStop
        // 
        btStop.Enabled = false;
        btStop.Location = new Point(180, 497);
        btStop.Name = "btStop";
        btStop.Size = new Size(140, 40);
        btStop.TabIndex = 16;
        btStop.Text = "Stop";
        btStop.UseVisualStyleBackColor = true;
        btStop.Click += btStop_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1004, 558);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(cbRecordSound);
        Controls.Add(cbCursor);
        Controls.Add(cbAudioFormat);
        Controls.Add(lbAudioFormat);
        Controls.Add(cbAudioCodec);
        Controls.Add(lbAudioCodec);
        Controls.Add(cbVideoCodec);
        Controls.Add(lbVideoCodec);
        Controls.Add(cbSound);
        Controls.Add(lbSound);
        Controls.Add(cbFrameRate);
        Controls.Add(lbFrameRate);
        Controls.Add(cbMonitor);
        Controls.Add(lbMonitor);
        Controls.Add(VideoView1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Screen to WMV";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    private Label lbMonitor;
    private ComboBox cbMonitor;
    private Label lbFrameRate;
    private ComboBox cbFrameRate;
    private Label lbSound;
    private ComboBox cbSound;
    private Label lbVideoCodec;
    private ComboBox cbVideoCodec;
    private Label lbAudioCodec;
    private ComboBox cbAudioCodec;
    private Label lbAudioFormat;
    private ComboBox cbAudioFormat;
    private CheckBox cbCursor;
    private CheckBox cbRecordSound;
    private Button btStart;
    private Button btStop;
}
