using VisioForge.Types;
using System;

namespace multiple_video_streams
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.cbCamera1 = new System.Windows.Forms.ComboBox();
            this.cbCamera2 = new System.Windows.Forms.ComboBox();
            this.cbVideoFormat1 = new System.Windows.Forms.ComboBox();
            this.cbVideoFrameRate1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVideoFrameRate2 = new System.Windows.Forms.ComboBox();
            this.cbVideoFormat2 = new System.Windows.Forms.ComboBox();
            this.edLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edFilename = new System.Windows.Forms.TextBox();
            this.videoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.videoScreen2 = new System.Windows.Forms.PictureBox();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.btSelectOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoScreen2)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.Location = new System.Drawing.Point(12, 304);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStop.Location = new System.Drawing.Point(93, 304);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 3;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // cbCamera1
            // 
            this.cbCamera1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera1.FormattingEnabled = true;
            this.cbCamera1.Location = new System.Drawing.Point(12, 245);
            this.cbCamera1.Name = "cbCamera1";
            this.cbCamera1.Size = new System.Drawing.Size(295, 21);
            this.cbCamera1.TabIndex = 6;
            this.cbCamera1.SelectedIndexChanged += new System.EventHandler(this.cbCamera1_SelectedIndexChanged);
            // 
            // cbCamera2
            // 
            this.cbCamera2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera2.FormattingEnabled = true;
            this.cbCamera2.Location = new System.Drawing.Point(331, 245);
            this.cbCamera2.Name = "cbCamera2";
            this.cbCamera2.Size = new System.Drawing.Size(295, 21);
            this.cbCamera2.TabIndex = 7;
            this.cbCamera2.SelectedIndexChanged += new System.EventHandler(this.cbCamera2_SelectedIndexChanged);
            // 
            // cbVideoFormat1
            // 
            this.cbVideoFormat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFormat1.FormattingEnabled = true;
            this.cbVideoFormat1.Location = new System.Drawing.Point(12, 277);
            this.cbVideoFormat1.Name = "cbVideoFormat1";
            this.cbVideoFormat1.Size = new System.Drawing.Size(186, 21);
            this.cbVideoFormat1.TabIndex = 9;
            this.cbVideoFormat1.SelectedIndexChanged += new System.EventHandler(this.cbVideoFormat1_SelectedIndexChanged);
            // 
            // cbVideoFrameRate1
            // 
            this.cbVideoFrameRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFrameRate1.FormattingEnabled = true;
            this.cbVideoFrameRate1.Location = new System.Drawing.Point(204, 277);
            this.cbVideoFrameRate1.Name = "cbVideoFrameRate1";
            this.cbVideoFrameRate1.Size = new System.Drawing.Size(76, 21);
            this.cbVideoFrameRate1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "fps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "fps";
            // 
            // cbVideoFrameRate2
            // 
            this.cbVideoFrameRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFrameRate2.FormattingEnabled = true;
            this.cbVideoFrameRate2.Location = new System.Drawing.Point(523, 277);
            this.cbVideoFrameRate2.Name = "cbVideoFrameRate2";
            this.cbVideoFrameRate2.Size = new System.Drawing.Size(76, 21);
            this.cbVideoFrameRate2.TabIndex = 13;
            // 
            // cbVideoFormat2
            // 
            this.cbVideoFormat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoFormat2.FormattingEnabled = true;
            this.cbVideoFormat2.Location = new System.Drawing.Point(331, 277);
            this.cbVideoFormat2.Name = "cbVideoFormat2";
            this.cbVideoFormat2.Size = new System.Drawing.Size(186, 21);
            this.cbVideoFormat2.TabIndex = 12;
            this.cbVideoFormat2.SelectedIndexChanged += new System.EventHandler(this.cbVideoFormat2_SelectedIndexChanged);
            // 
            // edLog
            // 
            this.edLog.Location = new System.Drawing.Point(644, 32);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.Size = new System.Drawing.Size(263, 134);
            this.edLog.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Log";
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(820, 12);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 17;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Output file";
            // 
            // edFilename
            // 
            this.edFilename.Location = new System.Drawing.Point(644, 194);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(233, 20);
            this.edFilename.TabIndex = 19;
            // 
            // videoCapture1
            // 
            this.videoCapture1.Additional_Audio_CaptureDevice_MixChannels = false;
            this.videoCapture1.Audio_CaptureDevice = "";
            this.videoCapture1.Audio_CaptureDevice_CustomLatency = 0;
            this.videoCapture1.Audio_CaptureDevice_Format = "";
            this.videoCapture1.Audio_CaptureDevice_Format_UseBest = true;
            this.videoCapture1.Audio_CaptureDevice_Line = "";
            this.videoCapture1.Audio_CaptureDevice_MasterDevice = null;
            this.videoCapture1.Audio_CaptureDevice_MasterDevice_Format = null;
            this.videoCapture1.Audio_CaptureDevice_Path = null;
            this.videoCapture1.Audio_CaptureSourceFilter = null;
            this.videoCapture1.Audio_Channel_Mapper = null;
            this.videoCapture1.Audio_Decoder = null;
            this.videoCapture1.Audio_Effects_Enabled = false;
            this.videoCapture1.Audio_Enhancer_Enabled = false;
            this.videoCapture1.Audio_OutputDevice = "Default DirectSound Device";
            this.videoCapture1.Audio_PCM_Converter = null;
            this.videoCapture1.Audio_PlayAudio = true;
            this.videoCapture1.Audio_RecordAudio = true;
            this.videoCapture1.Audio_Sample_Grabber_Enabled = false;
            this.videoCapture1.Audio_VUMeter_Enabled = false;
            this.videoCapture1.Audio_VUMeter_Pro_Enabled = false;
            this.videoCapture1.Audio_VUMeter_Pro_Volume = 100;
            this.videoCapture1.BackColor = System.Drawing.Color.Black;
            this.videoCapture1.Barcode_Reader_Enabled = false;
            this.videoCapture1.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.videoCapture1.BDA_Source = null;
            this.videoCapture1.ChromaKey = null;
            this.videoCapture1.Custom_Source = null;
            this.videoCapture1.CustomRedist_Auto = true;
            this.videoCapture1.CustomRedist_Path = null;
            this.videoCapture1.Debug_Dir = "";
            this.videoCapture1.Debug_DisableMessageDialogs = false;
            this.videoCapture1.Debug_Mode = false;
            this.videoCapture1.Debug_Telemetry = false;
            this.videoCapture1.Decklink_Input = VisioForge.Types.DecklinkInput.Auto;
            this.videoCapture1.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.Auto;
            this.videoCapture1.Decklink_Input_IREUSA = false;
            this.videoCapture1.Decklink_Input_SMPTE = false;
            this.videoCapture1.Decklink_Output = null;
            this.videoCapture1.Decklink_Source = null;
            this.videoCapture1.DirectCapture_Muxer = null;
            this.videoCapture1.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full;
            this.videoCapture1.Face_Tracking = null;
            this.videoCapture1.IP_Camera_Source = null;
            this.videoCapture1.Location = new System.Drawing.Point(12, 12);
            this.videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture;
            this.videoCapture1.Motion_Detection = null;
            this.videoCapture1.Motion_DetectionEx = null;
            this.videoCapture1.MPEG_Audio_Decoder = "";
            this.videoCapture1.MPEG_Demuxer = null;
            this.videoCapture1.MPEG_Video_Decoder = "";
            this.videoCapture1.MultiScreen_Enabled = false;
            this.videoCapture1.Name = "videoCapture1";
            this.videoCapture1.Network_Streaming_Audio_Enabled = false;
            this.videoCapture1.Network_Streaming_Enabled = false;
            this.videoCapture1.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV;
            this.videoCapture1.Network_Streaming_Network_Port = 100;
            this.videoCapture1.Network_Streaming_Output = null;
            this.videoCapture1.Network_Streaming_URL = "";
            this.videoCapture1.Network_Streaming_WMV_Maximum_Clients = 10;
            this.videoCapture1.OSD_Enabled = false;
            this.videoCapture1.Output_Filename = "";
            this.videoCapture1.Output_Format = null;
            this.videoCapture1.PIP_AddSampleGrabbers = false;
            this.videoCapture1.PIP_ChromaKeySettings = null;
            this.videoCapture1.PIP_Mode = VisioForge.Types.VFPIPMode.Custom;
            this.videoCapture1.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN;
            this.videoCapture1.Push_Source = null;
            this.videoCapture1.Screen_Capture_Source = null;
            this.videoCapture1.SeparateCapture_AutostartCapture = false;
            this.videoCapture1.SeparateCapture_Enabled = false;
            this.videoCapture1.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext";
            this.videoCapture1.SeparateCapture_FileSizeThreshold = ((long)(0));
            this.videoCapture1.SeparateCapture_GMFMode = true;
            this.videoCapture1.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal;
            this.videoCapture1.SeparateCapture_TimeThreshold = System.TimeSpan.Parse("00:00:00");
            this.videoCapture1.Size = new System.Drawing.Size(295, 228);
            this.videoCapture1.Start_DelayEnabled = false;
            this.videoCapture1.TabIndex = 0;
            this.videoCapture1.Tags = null;
            this.videoCapture1.Timeshift_Settings = null;
            this.videoCapture1.TVTuner_Channel = 0;
            this.videoCapture1.TVTuner_Country = "";
            this.videoCapture1.TVTuner_FM_Tuning_StartFrequency = 80000000;
            this.videoCapture1.TVTuner_FM_Tuning_Step = 160000000;
            this.videoCapture1.TVTuner_FM_Tuning_StopFrequency = 0;
            this.videoCapture1.TVTuner_Frequency = 0;
            this.videoCapture1.TVTuner_InputType = "";
            this.videoCapture1.TVTuner_Mode = VisioForge.Types.VFTVTunerMode.Default;
            this.videoCapture1.TVTuner_Name = "";
            this.videoCapture1.TVTuner_TVFormat = VisioForge.Types.VFTVTunerVideoFormat.PAL_D;
            this.videoCapture1.Video_CaptureDevice = "";
            this.videoCapture1.Video_CaptureDevice_Format = "";
            this.videoCapture1.Video_CaptureDevice_Format_UseBest = true;
            this.videoCapture1.Video_CaptureDevice_FrameRate = 25D;
            this.videoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = "";
            this.videoCapture1.Video_CaptureDevice_IsAudioSource = false;
            this.videoCapture1.Video_CaptureDevice_Path = null;
            this.videoCapture1.Video_CaptureDevice_UseClosedCaptions = false;
            this.videoCapture1.Video_CaptureDevice_UseRAWSampleGrabber = false;
            this.videoCapture1.Video_Crop = null;
            this.videoCapture1.Video_Decoder = null;
            this.videoCapture1.Video_Effects_AllowMultipleStreams = false;
            this.videoCapture1.Video_Effects_Enabled = false;
            this.videoCapture1.Video_Effects_GPU_Enabled = false;
            this.videoCapture1.Video_Effects_MergeImageLogos = false;
            this.videoCapture1.Video_Effects_MergeTextLogos = false;
            this.videoCapture1.Video_Resize = null;
            this.videoCapture1.Video_ResizeOrCrop_Enabled = false;
            this.videoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.videoCapture1.Video_Sample_Grabber_Enabled = false;
            this.videoCapture1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.videoCapture1.Video_Still_Frames_Grabber_Enabled = false;
            this.videoCapture1.Virtual_Camera_Output_Enabled = false;
            this.videoCapture1.Virtual_Camera_Output_LicenseKey = null;
            this.videoCapture1.VLC_Path = null;
            this.videoCapture1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.videoCapture1_OnLicenseRequired);
            this.videoCapture1.OnVideoFrameBitmap += new System.EventHandler<VisioForge.Types.VideoFrameBitmapEventArgs>(this.videoCapture1_OnVideoFrameBitmap);
            // 
            // videoScreen2
            // 
            this.videoScreen2.BackColor = System.Drawing.Color.Black;
            this.videoScreen2.Location = new System.Drawing.Point(331, 12);
            this.videoScreen2.Name = "videoScreen2";
            this.videoScreen2.Size = new System.Drawing.Size(295, 228);
            this.videoScreen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoScreen2.TabIndex = 20;
            this.videoScreen2.TabStop = false;
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.Location = new System.Drawing.Point(181, 309);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp.TabIndex = 103;
            this.lbTimestamp.Text = "Recording time: 00:00:00";
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(883, 192);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(24, 23);
            this.btSelectOutput.TabIndex = 121;
            this.btSelectOutput.Text = "...";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 340);
            this.Controls.Add(this.btSelectOutput);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.videoScreen2);
            this.Controls.Add(this.edFilename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbVideoFrameRate2);
            this.Controls.Add(this.cbVideoFormat2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVideoFrameRate1);
            this.Controls.Add(this.cbVideoFormat1);
            this.Controls.Add(this.cbCamera2);
            this.Controls.Add(this.cbCamera1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.videoCapture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Multiple video streams captured into one file";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoScreen2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisioForge.Controls.UI.WinForms.VideoCapture videoCapture1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.ComboBox cbCamera1;
        private System.Windows.Forms.ComboBox cbCamera2;
        private System.Windows.Forms.ComboBox cbVideoFormat1;
        private System.Windows.Forms.ComboBox cbVideoFrameRate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVideoFrameRate2;
        private System.Windows.Forms.ComboBox cbVideoFormat2;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.PictureBox videoScreen2;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.Button btSelectOutput;
    }
}

