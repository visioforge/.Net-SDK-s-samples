namespace WebrtcWhip;

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
        lbCamera = new Label();
        cbCamera = new ComboBox();
        lbWhip = new Label();
        edWhipUrl = new TextBox();
        btStart = new Button();
        btStop = new Button();
        lbStatus = new Label();
        SuspendLayout();
        //
        // lbCamera
        //
        lbCamera.AutoSize = true;
        lbCamera.Location = new Point(20, 21);
        lbCamera.Name = "lbCamera";
        lbCamera.Size = new Size(51, 15);
        lbCamera.TabIndex = 0;
        lbCamera.Text = "Camera";
        //
        // cbCamera
        //
        cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        cbCamera.Location = new Point(20, 45);
        cbCamera.Name = "cbCamera";
        cbCamera.Size = new Size(520, 23);
        cbCamera.TabIndex = 1;
        //
        // lbWhip
        //
        lbWhip.AutoSize = true;
        lbWhip.Location = new Point(20, 87);
        lbWhip.Name = "lbWhip";
        lbWhip.Size = new Size(210, 15);
        lbWhip.TabIndex = 2;
        lbWhip.Text = "WHIP URL of a media server (optional)";
        //
        // edWhipUrl
        //
        edWhipUrl.Location = new Point(20, 111);
        edWhipUrl.Name = "edWhipUrl";
        edWhipUrl.Size = new Size(520, 23);
        edWhipUrl.TabIndex = 3;
        //
        // btStart
        //
        btStart.Enabled = false;
        btStart.Location = new Point(20, 155);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 4;
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
        btStop.TabIndex = 5;
        btStop.Text = "Stop";
        btStop.UseVisualStyleBackColor = true;
        btStop.Click += btStop_Click;
        //
        // lbStatus
        //
        lbStatus.AutoSize = true;
        lbStatus.Font = new Font("Segoe UI", 14F);
        lbStatus.Location = new Point(20, 215);
        lbStatus.Name = "lbStatus";
        lbStatus.Size = new Size(0, 25);
        lbStatus.TabIndex = 6;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(560, 320);
        Enabled = false;
        Font = new Font("Segoe UI", 12F);
        Controls.Add(lbStatus);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(edWhipUrl);
        Controls.Add(lbWhip);
        Controls.Add(cbCamera);
        Controls.Add(lbCamera);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Camera to browsers over WebRTC";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbCamera;
    private ComboBox cbCamera;
    private Label lbWhip;
    private TextBox edWhipUrl;
    private Button btStart;
    private Button btStop;
    private Label lbStatus;
}
