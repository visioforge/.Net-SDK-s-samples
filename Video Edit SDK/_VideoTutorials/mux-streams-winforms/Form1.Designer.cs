namespace MuxStreams;

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
        lbVideo = new Label();
        edVideo = new TextBox();
        btVideo = new Button();
        lbAudio = new Label();
        edAudio = new TextBox();
        btAudio = new Button();
        lbOutput = new Label();
        edOutput = new TextBox();
        cbShortest = new CheckBox();
        btStart = new Button();
        openFileDialog1 = new OpenFileDialog();
        SuspendLayout();
        // 
        // lbVideo
        // 
        lbVideo.AutoSize = true;
        lbVideo.Location = new Point(20, 21);
        lbVideo.Name = "lbVideo";
        lbVideo.Size = new Size(70, 15);
        lbVideo.TabIndex = 0;
        lbVideo.Text = "Video from";
        // 
        // edVideo
        // 
        edVideo.Location = new Point(20, 45);
        edVideo.Name = "edVideo";
        edVideo.Size = new Size(460, 23);
        edVideo.TabIndex = 1;
        // 
        // btVideo
        // 
        btVideo.Location = new Point(490, 44);
        btVideo.Name = "btVideo";
        btVideo.Size = new Size(40, 25);
        btVideo.TabIndex = 2;
        btVideo.Text = "...";
        btVideo.UseVisualStyleBackColor = true;
        btVideo.Click += btVideo_Click;
        // 
        // lbAudio
        // 
        lbAudio.AutoSize = true;
        lbAudio.Location = new Point(20, 87);
        lbAudio.Name = "lbAudio";
        lbAudio.Size = new Size(70, 15);
        lbAudio.TabIndex = 3;
        lbAudio.Text = "Audio from";
        // 
        // edAudio
        // 
        edAudio.Location = new Point(20, 111);
        edAudio.Name = "edAudio";
        edAudio.Size = new Size(460, 23);
        edAudio.TabIndex = 4;
        // 
        // btAudio
        // 
        btAudio.Location = new Point(490, 110);
        btAudio.Name = "btAudio";
        btAudio.Size = new Size(40, 25);
        btAudio.TabIndex = 5;
        btAudio.Text = "...";
        btAudio.UseVisualStyleBackColor = true;
        btAudio.Click += btAudio_Click;
        // 
        // lbOutput
        // 
        lbOutput.AutoSize = true;
        lbOutput.Location = new Point(20, 153);
        lbOutput.Name = "lbOutput";
        lbOutput.Size = new Size(70, 15);
        lbOutput.TabIndex = 6;
        lbOutput.Text = "Output file";
        // 
        // edOutput
        // 
        edOutput.Location = new Point(20, 177);
        edOutput.Name = "edOutput";
        edOutput.Size = new Size(510, 23);
        edOutput.TabIndex = 7;
        // 
        // cbShortest
        // 
        cbShortest.AutoSize = true;
        cbShortest.Checked = true;
        cbShortest.CheckState = CheckState.Checked;
        cbShortest.Location = new Point(20, 219);
        cbShortest.Name = "cbShortest";
        cbShortest.Size = new Size(229, 19);
        cbShortest.TabIndex = 8;
        cbShortest.Text = "Stop at the end of the shortest stream";
        cbShortest.UseVisualStyleBackColor = true;
        // 
        // btStart
        // 
        btStart.Location = new Point(20, 257);
        btStart.Name = "btStart";
        btStart.Size = new Size(140, 40);
        btStart.TabIndex = 9;
        btStart.Text = "Start";
        btStart.UseVisualStyleBackColor = true;
        btStart.Click += btStart_Click;
        // 
        // openFileDialog1
        // 
        openFileDialog1.Filter = "Media files|*.mp4;*.mkv;*.mov;*.avi;*.m4a;*.mp3;*.aac|All files|*.*";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(550, 317);
        Controls.Add(btStart);
        Controls.Add(cbShortest);
        Controls.Add(edOutput);
        Controls.Add(lbOutput);
        Controls.Add(btAudio);
        Controls.Add(edAudio);
        Controls.Add(lbAudio);
        Controls.Add(btVideo);
        Controls.Add(edVideo);
        Controls.Add(lbVideo);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Mux streams";
        Load += Form1_Load;
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbVideo;
    private TextBox edVideo;
    private Button btVideo;
    private Label lbAudio;
    private TextBox edAudio;
    private Button btAudio;
    private Label lbOutput;
    private TextBox edOutput;
    private CheckBox cbShortest;
    private Button btStart;
    private OpenFileDialog openFileDialog1;
}
