namespace IpCameraCaptureMp4;

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
        lbURL = new Label();
        edURL = new TextBox();
        lbLogin = new Label();
        edLogin = new TextBox();
        lbPassword = new Label();
        edPassword = new TextBox();
        cbRecordAudio = new CheckBox();
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
        // lbURL
        //
        lbURL.AutoSize = true;
        lbURL.Location = new Point(20, 21);
        lbURL.Name = "lbURL";
        lbURL.Size = new Size(70, 15);
        lbURL.TabIndex = 1;
        lbURL.Text = "Camera URL";
        //
        // edURL
        //
        edURL.Location = new Point(20, 45);
        edURL.Name = "edURL";
        edURL.Size = new Size(300, 23);
        edURL.TabIndex = 2;
        //
        // lbLogin
        //
        lbLogin.AutoSize = true;
        lbLogin.Location = new Point(20, 87);
        lbLogin.Name = "lbLogin";
        lbLogin.Size = new Size(37, 15);
        lbLogin.TabIndex = 3;
        lbLogin.Text = "Login";
        //
        // edLogin
        //
        edLogin.Location = new Point(20, 111);
        edLogin.Name = "edLogin";
        edLogin.Size = new Size(300, 23);
        edLogin.TabIndex = 4;
        //
        // lbPassword
        //
        lbPassword.AutoSize = true;
        lbPassword.Location = new Point(20, 153);
        lbPassword.Name = "lbPassword";
        lbPassword.Size = new Size(57, 15);
        lbPassword.TabIndex = 5;
        lbPassword.Text = "Password";
        //
        // edPassword
        //
        edPassword.UseSystemPasswordChar = true;
        edPassword.Location = new Point(20, 177);
        edPassword.Name = "edPassword";
        edPassword.Size = new Size(300, 23);
        edPassword.TabIndex = 6;
        //
        // cbRecordAudio
        //
        cbRecordAudio.AutoSize = true;
        cbRecordAudio.Checked = true;
        cbRecordAudio.CheckState = CheckState.Checked;
        cbRecordAudio.Location = new Point(20, 219);
        cbRecordAudio.Name = "cbRecordAudio";
        cbRecordAudio.Size = new Size(94, 19);
        cbRecordAudio.TabIndex = 7;
        cbRecordAudio.Text = "Record audio";
        cbRecordAudio.UseVisualStyleBackColor = true;
        //
        // btStart
        //
        btStart.Enabled = false;
        btStart.Location = new Point(20, 255);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 8;
        btStart.Text = "Start";
        btStart.UseVisualStyleBackColor = true;
        btStart.Click += btStart_Click;
        //
        // btStop
        //
        btStop.Enabled = false;
        btStop.Location = new Point(180, 255);
        btStop.Name = "btStop";
        btStop.Size = new Size(140, 40);
        btStop.TabIndex = 9;
        btStop.Text = "Stop";
        btStop.UseVisualStyleBackColor = true;
        btStop.Click += btStop_Click;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1004, 400);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(cbRecordAudio);
        Controls.Add(edPassword);
        Controls.Add(lbPassword);
        Controls.Add(edLogin);
        Controls.Add(lbLogin);
        Controls.Add(edURL);
        Controls.Add(lbURL);
        Controls.Add(VideoView1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "IP camera to MP4";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    private Label lbURL;
    private TextBox edURL;
    private Label lbLogin;
    private TextBox edLogin;
    private Label lbPassword;
    private TextBox edPassword;
    private CheckBox cbRecordAudio;
    private Button btStart;
    private Button btStop;
}
