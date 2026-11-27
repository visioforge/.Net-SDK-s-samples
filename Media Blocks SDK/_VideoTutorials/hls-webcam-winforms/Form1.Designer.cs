namespace HlsWebcam;

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
        lbMicrophone = new Label();
        cbMicrophone = new ComboBox();
        lbPort = new Label();
        edPort = new NumericUpDown();
        btStart = new Button();
        btStop = new Button();
        lbStatus = new Label();
        ((System.ComponentModel.ISupportInitialize)edPort).BeginInit();
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
        lbCamera.Size = new Size(51, 15);
        lbCamera.TabIndex = 1;
        lbCamera.Text = "Camera";
        //
        // cbCamera
        //
        cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        cbCamera.Location = new Point(20, 45);
        cbCamera.Name = "cbCamera";
        cbCamera.Size = new Size(300, 23);
        cbCamera.TabIndex = 2;
        //
        // lbMicrophone
        //
        lbMicrophone.AutoSize = true;
        lbMicrophone.Location = new Point(20, 87);
        lbMicrophone.Name = "lbMicrophone";
        lbMicrophone.Size = new Size(72, 15);
        lbMicrophone.TabIndex = 3;
        lbMicrophone.Text = "Microphone";
        //
        // cbMicrophone
        //
        cbMicrophone.DropDownStyle = ComboBoxStyle.DropDownList;
        cbMicrophone.Location = new Point(20, 111);
        cbMicrophone.Name = "cbMicrophone";
        cbMicrophone.Size = new Size(300, 23);
        cbMicrophone.TabIndex = 4;
        //
        // lbPort
        //
        lbPort.AutoSize = true;
        lbPort.Location = new Point(20, 153);
        lbPort.Name = "lbPort";
        lbPort.Size = new Size(98, 15);
        lbPort.TabIndex = 5;
        lbPort.Text = "HTTP server port";
        //
        // edPort
        //
        edPort.Location = new Point(20, 177);
        edPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        edPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
        edPort.Name = "edPort";
        edPort.Size = new Size(120, 23);
        edPort.TabIndex = 6;
        edPort.Value = new decimal(new int[] { 8088, 0, 0, 0 });
        //
        // btStart
        //
        btStart.Enabled = false;
        btStart.Location = new Point(20, 221);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 7;
        btStart.Text = "Start";
        btStart.UseVisualStyleBackColor = true;
        btStart.Click += btStart_Click;
        //
        // btStop
        //
        btStop.Enabled = false;
        btStop.Location = new Point(180, 221);
        btStop.Name = "btStop";
        btStop.Size = new Size(140, 40);
        btStop.TabIndex = 8;
        btStop.Text = "Stop";
        btStop.UseVisualStyleBackColor = true;
        btStop.Click += btStop_Click;
        //
        // lbStatus
        //
        lbStatus.Location = new Point(20, 281);
        lbStatus.Name = "lbStatus";
        lbStatus.Size = new Size(300, 100);
        lbStatus.TabIndex = 9;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1004, 402);
        Controls.Add(lbStatus);
        Controls.Add(btStop);
        Controls.Add(btStart);
        Controls.Add(edPort);
        Controls.Add(lbPort);
        Controls.Add(cbMicrophone);
        Controls.Add(lbMicrophone);
        Controls.Add(cbCamera);
        Controls.Add(lbCamera);
        Controls.Add(VideoView1);
        Enabled = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Webcam to HLS";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ((System.ComponentModel.ISupportInitialize)edPort).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private VisioForge.Core.UI.WinForms.VideoView VideoView1;
    private Label lbCamera;
    private ComboBox cbCamera;
    private Label lbMicrophone;
    private ComboBox cbMicrophone;
    private Label lbPort;
    private NumericUpDown edPort;
    private Button btStart;
    private Button btStop;
    private Label lbStatus;
}
