using System.Windows.Forms;

namespace NDI_Source
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.edOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.VideoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbCapture = new System.Windows.Forms.RadioButton();
            this.rbPreview = new System.Windows.Forms.RadioButton();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbIPURL = new System.Windows.Forms.ComboBox();
            this.btListNDISources = new System.Windows.Forms.Button();
            this.lbNDI = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.edIPPassword = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.edIPLogin = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.cbIPAudioCapture = new System.Windows.Forms.CheckBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(20, 94);
            this.edOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(688, 31);
            this.edOutput.TabIndex = 119;
            this.edOutput.Text = "c:\\capture.mp4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 115;
            this.label4.Text = "File name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 25);
            this.label7.TabIndex = 114;
            this.label7.Text = "MP4 output with default parameters";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOutput);
            this.tabPage2.Controls.Add(this.edOutput);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage2.Size = new System.Drawing.Size(776, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(716, 87);
            this.btSelectOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(40, 44);
            this.btSelectOutput.TabIndex = 120;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // VideoView1
            // 
            this.VideoView1.BackColor = System.Drawing.Color.Black;
            this.VideoView1.Location = new System.Drawing.Point(802, 49);
            this.VideoView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.VideoView1.Name = "VideoView1";
            this.VideoView1.Size = new System.Drawing.Size(716, 525);
            this.VideoView1.StatusOverlay = null;
            this.VideoView1.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(957, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 25);
            this.label2.TabIndex = 110;
            this.label2.Text = "Much more features available in Main Demo";
            // 
            // rbCapture
            // 
            this.rbCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbCapture.AutoSize = true;
            this.rbCapture.Location = new System.Drawing.Point(907, 595);
            this.rbCapture.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rbCapture.Name = "rbCapture";
            this.rbCapture.Size = new System.Drawing.Size(99, 29);
            this.rbCapture.TabIndex = 108;
            this.rbCapture.Text = "Capture";
            this.rbCapture.UseVisualStyleBackColor = true;
            // 
            // rbPreview
            // 
            this.rbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPreview.AutoSize = true;
            this.rbPreview.Checked = true;
            this.rbPreview.Location = new System.Drawing.Point(802, 595);
            this.rbPreview.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rbPreview.Name = "rbPreview";
            this.rbPreview.Size = new System.Drawing.Size(97, 29);
            this.rbPreview.TabIndex = 107;
            this.rbPreview.TabStop = true;
            this.rbPreview.Text = "Preview";
            this.rbPreview.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btStop.Location = new System.Drawing.Point(1415, 589);
            this.btStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(103, 44);
            this.btStop.TabIndex = 106;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btStart.Location = new System.Drawing.Point(1306, 589);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(103, 44);
            this.btStart.TabIndex = 105;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(24, 25);
            this.cbDebugMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(144, 29);
            this.cbDebugMode.TabIndex = 78;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(24, 70);
            this.mmLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(724, 490);
            this.mmLog.TabIndex = 77;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbDebugMode);
            this.tabPage7.Controls.Add(this.mmLog);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage7.Size = new System.Drawing.Size(776, 586);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Log";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbIPURL);
            this.tabPage1.Controls.Add(this.btListNDISources);
            this.tabPage1.Controls.Add(this.lbNDI);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label165);
            this.tabPage1.Controls.Add(this.edIPPassword);
            this.tabPage1.Controls.Add(this.label167);
            this.tabPage1.Controls.Add(this.edIPLogin);
            this.tabPage1.Controls.Add(this.label166);
            this.tabPage1.Controls.Add(this.cbIPAudioCapture);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabPage1.Size = new System.Drawing.Size(776, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbIPURL
            // 
            this.cbIPURL.FormattingEnabled = true;
            this.cbIPURL.Location = new System.Drawing.Point(96, 34);
            this.cbIPURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbIPURL.Name = "cbIPURL";
            this.cbIPURL.Size = new System.Drawing.Size(476, 33);
            this.cbIPURL.TabIndex = 97;
            this.cbIPURL.Text = "http://192.168.1.22/onvif/device_service";
            // 
            // btListNDISources
            // 
            this.btListNDISources.Location = new System.Drawing.Point(580, 27);
            this.btListNDISources.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btListNDISources.Name = "btListNDISources";
            this.btListNDISources.Size = new System.Drawing.Size(178, 44);
            this.btListNDISources.TabIndex = 96;
            this.btListNDISources.Text = "List NDI sources";
            this.btListNDISources.UseVisualStyleBackColor = true;
            this.btListNDISources.Click += new System.EventHandler(this.btListNDISources_Click);
            // 
            // lbNDI
            // 
            this.lbNDI.AutoSize = true;
            this.lbNDI.Location = new System.Drawing.Point(440, 201);
            this.lbNDI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNDI.Name = "lbNDI";
            this.lbNDI.Size = new System.Drawing.Size(145, 25);
            this.lbNDI.TabIndex = 95;
            this.lbNDI.TabStop = true;
            this.lbNDI.Text = "vendor\'s website";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 25);
            this.label6.TabIndex = 94;
            this.label6.Text = "To use NDI please install NDI SDK for Windows from";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(22, 37);
            this.label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(43, 25);
            this.label165.TabIndex = 93;
            this.label165.Text = "URL";
            // 
            // edIPPassword
            // 
            this.edIPPassword.Location = new System.Drawing.Point(209, 121);
            this.edIPPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.edIPPassword.Name = "edIPPassword";
            this.edIPPassword.Size = new System.Drawing.Size(164, 31);
            this.edIPPassword.TabIndex = 91;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(209, 95);
            this.label167.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(87, 25);
            this.label167.TabIndex = 90;
            this.label167.Text = "Password";
            // 
            // edIPLogin
            // 
            this.edIPLogin.Location = new System.Drawing.Point(22, 121);
            this.edIPLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.edIPLogin.Name = "edIPLogin";
            this.edIPLogin.Size = new System.Drawing.Size(164, 31);
            this.edIPLogin.TabIndex = 89;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(20, 95);
            this.label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(56, 25);
            this.label166.TabIndex = 88;
            this.label166.Text = "Login";
            // 
            // cbIPAudioCapture
            // 
            this.cbIPAudioCapture.AutoSize = true;
            this.cbIPAudioCapture.Location = new System.Drawing.Point(422, 111);
            this.cbIPAudioCapture.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbIPAudioCapture.Name = "cbIPAudioCapture";
            this.cbIPAudioCapture.Size = new System.Drawing.Size(150, 29);
            this.cbIPAudioCapture.TabIndex = 87;
            this.cbIPAudioCapture.Text = "Capture audio";
            this.cbIPAudioCapture.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage7);
            this.tcMain.Location = new System.Drawing.Point(8, 15);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(784, 624);
            this.tcMain.TabIndex = 104;
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(1035, 597);
            this.lbTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(209, 25);
            this.lbTimestamp.TabIndex = 114;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 648);
            this.Controls.Add(this.VideoView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbCapture);
            this.Controls.Add(this.rbPreview);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.lbTimestamp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NDI Source Demo - Video Capture SDK .Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox edOutput;
        private Label label4;
        private Label label7;
        private TabPage tabPage2;
        private Button btSelectOutput;
        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private Label label2;
        private SaveFileDialog saveFileDialog1;
        private RadioButton rbCapture;
        private RadioButton rbPreview;
        private Button btStop;
        private Button btStart;
        private CheckBox cbDebugMode;
        private TextBox mmLog;
        private TabPage tabPage7;
        private TabPage tabPage1;
        private ComboBox cbIPURL;
        private Button btListNDISources;
        private LinkLabel lbNDI;
        private Label label6;
        private Label label165;
        private TextBox edIPPassword;
        private Label label167;
        private TextBox edIPLogin;
        private Label label166;
        private CheckBox cbIPAudioCapture;
        private TabControl tcMain;
        private Label lbTimestamp;
        private SaveFileDialog saveFileDialog2;
    }
}