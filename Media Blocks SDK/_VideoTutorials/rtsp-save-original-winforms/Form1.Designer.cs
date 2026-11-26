namespace RtspSaveOriginal;

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
        components = new System.ComponentModel.Container();
        lbURL = new Label();
        edURL = new TextBox();
        lbLogin = new Label();
        edLogin = new TextBox();
        lbPassword = new Label();
        edPassword = new TextBox();
        btStart = new Button();
        btStop = new Button();
        lbStatus = new Label();
        timer1 = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        //
        // lbURL
        //
        lbURL.AutoSize = true;
        lbURL.Location = new Point(20, 21);
        lbURL.Name = "lbURL";
        lbURL.Size = new Size(70, 15);
        lbURL.TabIndex = 0;
        lbURL.Text = "Camera URL";
        //
        // edURL
        //
        edURL.Location = new Point(20, 45);
        edURL.Name = "edURL";
        edURL.Size = new Size(480, 23);
        edURL.TabIndex = 1;
        //
        // lbLogin
        //
        lbLogin.AutoSize = true;
        lbLogin.Location = new Point(20, 87);
        lbLogin.Name = "lbLogin";
        lbLogin.Size = new Size(37, 15);
        lbLogin.TabIndex = 2;
        lbLogin.Text = "Login";
        //
        // edLogin
        //
        edLogin.UseSystemPasswordChar = true;
        edLogin.Location = new Point(20, 111);
        edLogin.Name = "edLogin";
        edLogin.Size = new Size(230, 23);
        edLogin.TabIndex = 3;
        //
        // lbPassword
        //
        lbPassword.AutoSize = true;
        lbPassword.Location = new Point(270, 87);
        lbPassword.Name = "lbPassword";
        lbPassword.Size = new Size(57, 15);
        lbPassword.TabIndex = 4;
        lbPassword.Text = "Password";
        //
        // edPassword
        //
        edPassword.UseSystemPasswordChar = true;
        edPassword.Location = new Point(270, 111);
        edPassword.Name = "edPassword";
        edPassword.Size = new Size(230, 23);
        edPassword.TabIndex = 5;
        //
        // btStart
        //
        btStart.Enabled = false;
        btStart.Location = new Point(20, 155);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 6;
        btStart.Text = "Start";
        btStart.UseVisualStyleBackColor = true;
        btStart.Click += btStart_Click;
        //
        // btStop
        //
        btStop.Enabled = false;
        btStop.Location = new Point(180, 155);
        btStop.Name = "btStop";
        btStop.Size = new Size(140, 40);
        btStop.TabIndex = 7;
        btStop.Text = "Stop";
        btStop.UseVisualStyleBackColor = true;
        btStop.Click += btStop_Click;
        //
        // lbStatus
        //
        lbStatus.AutoSize = true;
        lbStatus.Font = new Font("Segoe UI", 16F);
        lbStatus.Location = new Point(20, 215);
        lbStatus.Name = "lbStatus";
        lbStatus.Size = new Size(0, 25);
        lbStatus.TabIndex = 8;
        //
        // timer1
        //
        timer1.Interval = 1000;
        timer1.Tick += timer1_Tick;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 265);
        Font = new Font("Segoe UI", 12F);
        Controls.Add(lbStatus);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(edPassword);
        Controls.Add(lbPassword);
        Controls.Add(edLogin);
        Controls.Add(lbLogin);
        Controls.Add(edURL);
        Controls.Add(lbURL);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Save RTSP to MP4 without re-encoding";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbURL;
    private TextBox edURL;
    private Label lbLogin;
    private TextBox edLogin;
    private Label lbPassword;
    private TextBox edPassword;
    private Button btStart;
    private Button btStop;
    private Label lbStatus;
    private System.Windows.Forms.Timer timer1;
}
