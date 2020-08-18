using VisioForge.Types;
using System;

namespace multiple_ap_cams
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
            VisioForge.Types.VideoRendererSettingsWinForms videoRendererSettingsWinForms1 = new VisioForge.Types.VideoRendererSettingsWinForms();
            VisioForge.Types.VideoRendererSettingsWinForms videoRendererSettingsWinForms2 = new VisioForge.Types.VideoRendererSettingsWinForms();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.videoCapture1 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.videoCapture2 = new VisioForge.Controls.UI.WinForms.VideoCapture();
            this.btStart1 = new System.Windows.Forms.Button();
            this.btStop1 = new System.Windows.Forms.Button();
            this.btStart2 = new System.Windows.Forms.Button();
            this.btStop2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edURL1 = new System.Windows.Forms.TextBox();
            this.edURL2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTimestamp1 = new System.Windows.Forms.Label();
            this.lbTimestamp2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.mmLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.videoCapture1.Audio_Effects_UseLegacyEffects = false;
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
            this.videoCapture1.CustomRedist_Enabled = false;
            this.videoCapture1.CustomRedist_Path = null;
            this.videoCapture1.Debug_Dir = "";
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
            this.videoCapture1.SeparateCapture_TimeThreshold = TimeSpan.Zero;
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
            videoRendererSettingsWinForms1.Aspect_Ratio_Override = false;
            videoRendererSettingsWinForms1.Aspect_Ratio_X = 16;
            videoRendererSettingsWinForms1.Aspect_Ratio_Y = 9;
            videoRendererSettingsWinForms1.BackgroundColor = System.Drawing.Color.Black;
            videoRendererSettingsWinForms1.Deinterlace_EVR_Mode = VisioForge.Types.EVRDeinterlaceMode.Auto;
            videoRendererSettingsWinForms1.Deinterlace_VMR9_Mode = null;
            videoRendererSettingsWinForms1.Deinterlace_VMR9_UseDefault = true;
            videoRendererSettingsWinForms1.Flip_Horizontal = false;
            videoRendererSettingsWinForms1.Flip_Vertical = false;
            videoRendererSettingsWinForms1.RotationAngle = 0;
            videoRendererSettingsWinForms1.StretchMode = VisioForge.Types.VFVideoRendererStretchMode.Letterbox;
            videoRendererSettingsWinForms1.Video_Renderer = VisioForge.Types.VFVideoRenderer.EVR;
            videoRendererSettingsWinForms1.VideoRendererInternal = VisioForge.Types.VFVideoRendererInternal.EVR;
            videoRendererSettingsWinForms1.Zoom_Ratio = 0;
            videoRendererSettingsWinForms1.Zoom_ShiftX = 0;
            videoRendererSettingsWinForms1.Zoom_ShiftY = 0;
            this.videoCapture1.Video_Renderer = videoRendererSettingsWinForms1;
            this.videoCapture1.Video_Resize = null;
            this.videoCapture1.Video_ResizeOrCrop_Enabled = false;
            this.videoCapture1.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.videoCapture1.Video_Sample_Grabber_Enabled = false;
            this.videoCapture1.Video_Sample_Grabber_UseForVideoEffects = false;
            this.videoCapture1.Video_Still_Frames_Grabber_Enabled = false;
            this.videoCapture1.Virtual_Camera_Output_Enabled = false;
            this.videoCapture1.Virtual_Camera_Output_LicenseKey = null;
            this.videoCapture1.VLC_Path = null;
            this.videoCapture1.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoCapture1OnOnError);
            this.videoCapture1.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.videoCapture1_OnLicenseRequired);
            // 
            // videoCapture2
            // 
            this.videoCapture2.Additional_Audio_CaptureDevice_MixChannels = false;
            this.videoCapture2.Audio_CaptureDevice = "";
            this.videoCapture2.Audio_CaptureDevice_CustomLatency = 0;
            this.videoCapture2.Audio_CaptureDevice_Format = "";
            this.videoCapture2.Audio_CaptureDevice_Format_UseBest = true;
            this.videoCapture2.Audio_CaptureDevice_Line = "";
            this.videoCapture2.Audio_CaptureDevice_MasterDevice = null;
            this.videoCapture2.Audio_CaptureDevice_MasterDevice_Format = null;
            this.videoCapture2.Audio_CaptureDevice_Path = null;
            this.videoCapture2.Audio_CaptureSourceFilter = null;
            this.videoCapture2.Audio_Channel_Mapper = null;
            this.videoCapture2.Audio_Decoder = null;
            this.videoCapture2.Audio_Effects_Enabled = false;
            this.videoCapture2.Audio_Effects_UseLegacyEffects = false;
            this.videoCapture2.Audio_Enhancer_Enabled = false;
            this.videoCapture2.Audio_OutputDevice = "Default DirectSound Device";
            this.videoCapture2.Audio_PCM_Converter = null;
            this.videoCapture2.Audio_PlayAudio = true;
            this.videoCapture2.Audio_RecordAudio = true;
            this.videoCapture2.Audio_Sample_Grabber_Enabled = false;
            this.videoCapture2.Audio_VUMeter_Enabled = false;
            this.videoCapture2.Audio_VUMeter_Pro_Enabled = false;
            this.videoCapture2.Audio_VUMeter_Pro_Volume = 100;
            this.videoCapture2.BackColor = System.Drawing.Color.Black;
            this.videoCapture2.Barcode_Reader_Enabled = false;
            this.videoCapture2.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.Auto;
            this.videoCapture2.BDA_Source = null;
            this.videoCapture2.ChromaKey = null;
            this.videoCapture2.Custom_Source = null;
            this.videoCapture2.CustomRedist_Enabled = false;
            this.videoCapture2.CustomRedist_Path = null;
            this.videoCapture2.Debug_Dir = "";
            this.videoCapture2.Debug_Mode = false;
            this.videoCapture2.Debug_Telemetry = false;
            this.videoCapture2.Decklink_Input = VisioForge.Types.DecklinkInput.Auto;
            this.videoCapture2.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.Auto;
            this.videoCapture2.Decklink_Input_IREUSA = false;
            this.videoCapture2.Decklink_Input_SMPTE = false;
            this.videoCapture2.Decklink_Output = null;
            this.videoCapture2.Decklink_Source = null;
            this.videoCapture2.DirectCapture_Muxer = null;
            this.videoCapture2.DV_Decoder_Video_Resolution = VisioForge.Types.VFDVVideoResolution.Full;
            this.videoCapture2.Face_Tracking = null;
            this.videoCapture2.IP_Camera_Source = null;
            this.videoCapture2.Location = new System.Drawing.Point(331, 12);
            this.videoCapture2.Mode = VisioForge.Types.VFVideoCaptureMode.VideoCapture;
            this.videoCapture2.Motion_Detection = null;
            this.videoCapture2.Motion_DetectionEx = null;
            this.videoCapture2.MPEG_Audio_Decoder = "";
            this.videoCapture2.MPEG_Demuxer = null;
            this.videoCapture2.MPEG_Video_Decoder = "";
            this.videoCapture2.MultiScreen_Enabled = false;
            this.videoCapture2.Name = "videoCapture2";
            this.videoCapture2.Network_Streaming_Audio_Enabled = false;
            this.videoCapture2.Network_Streaming_Enabled = false;
            this.videoCapture2.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV;
            this.videoCapture2.Network_Streaming_Network_Port = 100;
            this.videoCapture2.Network_Streaming_Output = null;
            this.videoCapture2.Network_Streaming_URL = "";
            this.videoCapture2.Network_Streaming_WMV_Maximum_Clients = 10;
            this.videoCapture2.OSD_Enabled = false;
            this.videoCapture2.Output_Filename = "";
            this.videoCapture2.Output_Format = null;
            this.videoCapture2.PIP_AddSampleGrabbers = false;
            this.videoCapture2.PIP_ChromaKeySettings = null;
            this.videoCapture2.PIP_Mode = VisioForge.Types.VFPIPMode.Custom;
            this.videoCapture2.PIP_ResizeQuality = VisioForge.Types.VFPIPResizeQuality.RQ_NN;
            this.videoCapture2.Push_Source = null;
            this.videoCapture2.Screen_Capture_Source = null;
            this.videoCapture2.SeparateCapture_AutostartCapture = false;
            this.videoCapture2.SeparateCapture_Enabled = false;
            this.videoCapture2.SeparateCapture_Filename_Mask = "output %yyyy-%MM-%dd %hh-%mm-%ss.%ext";
            this.videoCapture2.SeparateCapture_FileSizeThreshold = ((long)(0));
            this.videoCapture2.SeparateCapture_GMFMode = true;
            this.videoCapture2.SeparateCapture_Mode = VisioForge.Types.VFSeparateCaptureMode.Normal;
            this.videoCapture2.SeparateCapture_TimeThreshold = TimeSpan.Zero;
            this.videoCapture2.Size = new System.Drawing.Size(295, 228);
            this.videoCapture2.Start_DelayEnabled = false;
            this.videoCapture2.TabIndex = 1;
            this.videoCapture2.Tags = null;
            this.videoCapture2.Timeshift_Settings = null;
            this.videoCapture2.TVTuner_Channel = 0;
            this.videoCapture2.TVTuner_Country = "";
            this.videoCapture2.TVTuner_FM_Tuning_StartFrequency = 80000000;
            this.videoCapture2.TVTuner_FM_Tuning_Step = 160000000;
            this.videoCapture2.TVTuner_FM_Tuning_StopFrequency = 0;
            this.videoCapture2.TVTuner_Frequency = 0;
            this.videoCapture2.TVTuner_InputType = "";
            this.videoCapture2.TVTuner_Mode = VisioForge.Types.VFTVTunerMode.Default;
            this.videoCapture2.TVTuner_Name = "";
            this.videoCapture2.TVTuner_TVFormat = VisioForge.Types.VFTVTunerVideoFormat.PAL_D;
            this.videoCapture2.Video_CaptureDevice = "";
            this.videoCapture2.Video_CaptureDevice_Format = "";
            this.videoCapture2.Video_CaptureDevice_Format_UseBest = true;
            this.videoCapture2.Video_CaptureDevice_FrameRate = 25D;
            this.videoCapture2.Video_CaptureDevice_InternalMPEGEncoder_Name = "";
            this.videoCapture2.Video_CaptureDevice_IsAudioSource = false;
            this.videoCapture2.Video_CaptureDevice_Path = null;
            this.videoCapture2.Video_CaptureDevice_UseClosedCaptions = false;
            this.videoCapture2.Video_CaptureDevice_UseRAWSampleGrabber = false;
            this.videoCapture2.Video_Crop = null;
            this.videoCapture2.Video_Decoder = null;
            this.videoCapture2.Video_Effects_AllowMultipleStreams = false;
            this.videoCapture2.Video_Effects_Enabled = false;
            this.videoCapture2.Video_Effects_GPU_Enabled = false;
            videoRendererSettingsWinForms2.Aspect_Ratio_Override = false;
            videoRendererSettingsWinForms2.Aspect_Ratio_X = 16;
            videoRendererSettingsWinForms2.Aspect_Ratio_Y = 9;
            videoRendererSettingsWinForms2.BackgroundColor = System.Drawing.Color.Black;
            videoRendererSettingsWinForms2.Deinterlace_EVR_Mode = VisioForge.Types.EVRDeinterlaceMode.Auto;
            videoRendererSettingsWinForms2.Deinterlace_VMR9_Mode = null;
            videoRendererSettingsWinForms2.Deinterlace_VMR9_UseDefault = true;
            videoRendererSettingsWinForms2.Flip_Horizontal = false;
            videoRendererSettingsWinForms2.Flip_Vertical = false;
            videoRendererSettingsWinForms2.RotationAngle = 0;
            videoRendererSettingsWinForms2.StretchMode = VisioForge.Types.VFVideoRendererStretchMode.Letterbox;
            videoRendererSettingsWinForms2.Video_Renderer = VisioForge.Types.VFVideoRenderer.EVR;
            videoRendererSettingsWinForms2.VideoRendererInternal = VisioForge.Types.VFVideoRendererInternal.EVR;
            videoRendererSettingsWinForms2.Zoom_Ratio = 0;
            videoRendererSettingsWinForms2.Zoom_ShiftX = 0;
            videoRendererSettingsWinForms2.Zoom_ShiftY = 0;
            this.videoCapture2.Video_Renderer = videoRendererSettingsWinForms2;
            this.videoCapture2.Video_Resize = null;
            this.videoCapture2.Video_ResizeOrCrop_Enabled = false;
            this.videoCapture2.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone;
            this.videoCapture2.Video_Sample_Grabber_Enabled = false;
            this.videoCapture2.Video_Sample_Grabber_UseForVideoEffects = false;
            this.videoCapture2.Video_Still_Frames_Grabber_Enabled = false;
            this.videoCapture2.Virtual_Camera_Output_Enabled = false;
            this.videoCapture2.Virtual_Camera_Output_LicenseKey = null;
            this.videoCapture2.VLC_Path = null;
            this.videoCapture2.OnError += new System.EventHandler<VisioForge.Types.ErrorsEventArgs>(this.VideoCapture2OnOnError);
            this.videoCapture2.OnLicenseRequired += new System.EventHandler<VisioForge.Types.LicenseEventArgs>(this.videoCapture2_OnLicenseRequired);
            // 
            // btStart1
            // 
            this.btStart1.Location = new System.Drawing.Point(15, 272);
            this.btStart1.Name = "btStart1";
            this.btStart1.Size = new System.Drawing.Size(75, 23);
            this.btStart1.TabIndex = 2;
            this.btStart1.Text = "Start";
            this.btStart1.UseVisualStyleBackColor = true;
            this.btStart1.Click += new System.EventHandler(this.btStart1_Click);
            // 
            // btStop1
            // 
            this.btStop1.Location = new System.Drawing.Point(96, 272);
            this.btStop1.Name = "btStop1";
            this.btStop1.Size = new System.Drawing.Size(75, 23);
            this.btStop1.TabIndex = 3;
            this.btStop1.Text = "Stop";
            this.btStop1.UseVisualStyleBackColor = true;
            this.btStop1.Click += new System.EventHandler(this.btStop1_Click);
            // 
            // btStart2
            // 
            this.btStart2.Location = new System.Drawing.Point(331, 272);
            this.btStart2.Name = "btStart2";
            this.btStart2.Size = new System.Drawing.Size(75, 23);
            this.btStart2.TabIndex = 4;
            this.btStart2.Text = "Start";
            this.btStart2.UseVisualStyleBackColor = true;
            this.btStart2.Click += new System.EventHandler(this.btStart2_Click);
            // 
            // btStop2
            // 
            this.btStop2.Location = new System.Drawing.Point(412, 272);
            this.btStop2.Name = "btStop2";
            this.btStop2.Size = new System.Drawing.Size(75, 23);
            this.btStop2.TabIndex = 5;
            this.btStop2.Text = "Stop";
            this.btStop2.UseVisualStyleBackColor = true;
            this.btStop2.Click += new System.EventHandler(this.btStop2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // edURL1
            // 
            this.edURL1.Location = new System.Drawing.Point(47, 246);
            this.edURL1.Name = "edURL1";
            this.edURL1.Size = new System.Drawing.Size(260, 20);
            this.edURL1.TabIndex = 7;
            this.edURL1.Text = "http://212.162.177.75/mjpg/video.mjpg";
            // 
            // edURL2
            // 
            this.edURL2.Location = new System.Drawing.Point(366, 246);
            this.edURL2.Name = "edURL2";
            this.edURL2.Size = new System.Drawing.Size(260, 20);
            this.edURL2.TabIndex = 9;
            this.edURL2.Text = "http://212.162.177.75/mjpg/video.mjpg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "URL";
            // 
            // lbTimestamp1
            // 
            this.lbTimestamp1.AutoSize = true;
            this.lbTimestamp1.Location = new System.Drawing.Point(181, 277);
            this.lbTimestamp1.Name = "lbTimestamp1";
            this.lbTimestamp1.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp1.TabIndex = 103;
            this.lbTimestamp1.Text = "Recording time: 00:00:00";
            // 
            // lbTimestamp2
            // 
            this.lbTimestamp2.AutoSize = true;
            this.lbTimestamp2.Location = new System.Drawing.Point(500, 277);
            this.lbTimestamp2.Name = "lbTimestamp2";
            this.lbTimestamp2.Size = new System.Drawing.Size(126, 13);
            this.lbTimestamp2.TabIndex = 104;
            this.lbTimestamp2.Text = "Recording time: 00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "All settings set to default. You can check IP Capture Demo or Main Demo for more " +
    "options";
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(12, 346);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(87, 17);
            this.cbDebugMode.TabIndex = 108;
            this.cbDebugMode.Text = "Debug mode";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLog.Location = new System.Drawing.Point(12, 369);
            this.mmLog.Multiline = true;
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(614, 177);
            this.mmLog.TabIndex = 107;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 558);
            this.Controls.Add(this.cbDebugMode);
            this.Controls.Add(this.mmLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTimestamp2);
            this.Controls.Add(this.lbTimestamp1);
            this.Controls.Add(this.edURL2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edURL1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStop2);
            this.Controls.Add(this.btStart2);
            this.Controls.Add(this.btStop1);
            this.Controls.Add(this.btStart1);
            this.Controls.Add(this.videoCapture2);
            this.Controls.Add(this.videoCapture1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Capture SDK .Net - Multiple IP cameras";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisioForge.Controls.UI.WinForms.VideoCapture videoCapture1;
        private VisioForge.Controls.UI.WinForms.VideoCapture videoCapture2;
        private System.Windows.Forms.Button btStart1;
        private System.Windows.Forms.Button btStop1;
        private System.Windows.Forms.Button btStart2;
        private System.Windows.Forms.Button btStop2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edURL1;
        private System.Windows.Forms.TextBox edURL2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTimestamp1;
        private System.Windows.Forms.Label lbTimestamp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.TextBox mmLog;
    }
}

