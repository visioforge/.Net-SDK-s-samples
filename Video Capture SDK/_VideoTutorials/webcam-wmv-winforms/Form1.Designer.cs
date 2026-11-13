namespace WebcamWmv;

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
        lbCamera = new Label();
        cbCamera = new ComboBox();
        lbFormat = new Label();
        cbFormat = new ComboBox();
        lbFrameRate = new Label();
        cbFrameRate = new ComboBox();
        lbMicrophone = new Label();
        cbMicrophone = new ComboBox();
        lbVideoCodec = new Label();
        cbVideoCodec = new ComboBox();
        lbAudioCodec = new Label();
        cbAudioCodec = new ComboBox();
        lbAudioFormat = new Label();
        cbAudioFormat = new ComboBox();
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
        // lbCamera
        // 
        lbCamera.AutoSize = true;
        lbCamera.Location = new Point(20, 21);
        lbCamera.Name = "lbCamera";
        lbCamera.Size = new Size(48, 15);
        lbCamera.TabIndex = 1;
        lbCamera.Text = "Camera";
        // 
        // cbCamera
        // 
        cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        cbCamera.FormattingEnabled = true;
        cbCamera.Location = new Point(20, 45);
        cbCamera.Name = "cbCamera";
        cbCamera.Size = new Size(300, 23);
        cbCamera.TabIndex = 2;
        cbCamera.SelectedIndexChanged += cbCamera_SelectedIndexChanged;
        // 
        // lbFormat
        // 
        lbFormat.AutoSize = true;
        lbFormat.Location = new Point(20, 87);
        lbFormat.Name = "lbFormat";
        lbFormat.Size = new Size(45, 15);
        lbFormat.TabIndex = 3;
        lbFormat.Text = "Format";
        // 
        // cbFormat
        // 
        cbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        cbFormat.FormattingEnabled = true;
        cbFormat.Location = new Point(20, 111);
        cbFormat.Name = "cbFormat";
        cbFormat.Size = new Size(300, 23);
        cbFormat.TabIndex = 4;
        cbFormat.SelectedIndexChanged += cbFormat_SelectedIndexChanged;
        // 
        // lbFrameRate
        // 
        lbFrameRate.AutoSize = true;
        lbFrameRate.Location = new Point(20, 153);
        lbFrameRate.Name = "lbFrameRate";
        lbFrameRate.Size = new Size(63, 15);
        lbFrameRate.TabIndex = 5;
        lbFrameRate.Text = "Frame rate";
        // 
        // cbFrameRate
        // 
        cbFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
        cbFrameRate.FormattingEnabled = true;
        cbFrameRate.Location = new Point(20, 177);
        cbFrameRate.Name = "cbFrameRate";
        cbFrameRate.Size = new Size(300, 23);
        cbFrameRate.TabIndex = 6;
        // 
        // lbMicrophone
        // 
        lbMicrophone.AutoSize = true;
        lbMicrophone.Location = new Point(20, 219);
        lbMicrophone.Name = "lbMicrophone";
        lbMicrophone.Size = new Size(72, 15);
        lbMicrophone.TabIndex = 7;
        lbMicrophone.Text = "Microphone";
        // 
        // cbMicrophone
        // 
        cbMicrophone.DropDownStyle = ComboBoxStyle.DropDownList;
        cbMicrophone.FormattingEnabled = true;
        cbMicrophone.Location = new Point(20, 243);
        cbMicrophone.Name = "cbMicrophone";
        cbMicrophone.Size = new Size(300, 23);
        cbMicrophone.TabIndex = 8;
        // 
        // lbVideoCodec
        // 
        lbVideoCodec.AutoSize = true;
        lbVideoCodec.Location = new Point(20, 285);
        lbVideoCodec.Name = "lbVideoCodec";
        lbVideoCodec.Size = new Size(72, 15);
        lbVideoCodec.TabIndex = 9;
        lbVideoCodec.Text = "Video codec";
        // 
        // cbVideoCodec
        // 
        cbVideoCodec.DropDownStyle = ComboBoxStyle.DropDownList;
        cbVideoCodec.FormattingEnabled = true;
        cbVideoCodec.Location = new Point(20, 309);
        cbVideoCodec.Name = "cbVideoCodec";
        cbVideoCodec.Size = new Size(300, 23);
        cbVideoCodec.TabIndex = 10;
        // 
        // lbAudioCodec
        // 
        lbAudioCodec.AutoSize = true;
        lbAudioCodec.Location = new Point(20, 351);
        lbAudioCodec.Name = "lbAudioCodec";
        lbAudioCodec.Size = new Size(73, 15);
        lbAudioCodec.TabIndex = 11;
        lbAudioCodec.Text = "Audio codec";
        // 
        // cbAudioCodec
        // 
        cbAudioCodec.DropDownStyle = ComboBoxStyle.DropDownList;
        cbAudioCodec.FormattingEnabled = true;
        cbAudioCodec.Location = new Point(20, 375);
        cbAudioCodec.Name = "cbAudioCodec";
        cbAudioCodec.Size = new Size(300, 23);
        cbAudioCodec.TabIndex = 12;
        cbAudioCodec.SelectedIndexChanged += cbAudioCodec_SelectedIndexChanged;
        // 
        // lbAudioFormat
        // 
        lbAudioFormat.AutoSize = true;
        lbAudioFormat.Location = new Point(20, 417);
        lbAudioFormat.Name = "lbAudioFormat";
        lbAudioFormat.Size = new Size(77, 15);
        lbAudioFormat.TabIndex = 13;
        lbAudioFormat.Text = "Audio format";
        // 
        // cbAudioFormat
        // 
        cbAudioFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        cbAudioFormat.FormattingEnabled = true;
        cbAudioFormat.Location = new Point(20, 441);
        cbAudioFormat.Name = "cbAudioFormat";
        cbAudioFormat.Size = new Size(300, 23);
        cbAudioFormat.TabIndex = 14;
        // 
        // btStart
        // 
        btStart.Location = new Point(20, 485);
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
        btStop.Location = new Point(180, 485);
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
        ClientSize = new Size(1004, 546);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(cbAudioFormat);
        Controls.Add(lbAudioFormat);
        Controls.Add(cbAudioCodec);
        Controls.Add(lbAudioCodec);
        Controls.Add(cbVideoCodec);
        Controls.Add(lbVideoCodec);
        Controls.Add(cbMicrophone);
        Controls.Add(lbMicrophone);
        Controls.Add(cbFrameRate);
        Controls.Add(lbFrameRate);
        Controls.Add(cbFormat);
        Controls.Add(lbFormat);
        Controls.Add(cbCamera);
        Controls.Add(lbCamera);
        Controls.Add(VideoView1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Webcam to WMV";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    private Label lbCamera;
    private ComboBox cbCamera;
    private Label lbFormat;
    private ComboBox cbFormat;
    private Label lbFrameRate;
    private ComboBox cbFrameRate;
    private Label lbMicrophone;
    private ComboBox cbMicrophone;
    private Label lbVideoCodec;
    private ComboBox cbVideoCodec;
    private Label lbAudioCodec;
    private ComboBox cbAudioCodec;
    private Label lbAudioFormat;
    private ComboBox cbAudioFormat;
    private Button btStart;
    private Button btStop;
}
