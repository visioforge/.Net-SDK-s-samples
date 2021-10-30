// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600

namespace Video_Capture_Snippets_Demo
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.Output;
    using VisioForge.Types.VideoCapture;

    public partial class Form1 : Form
    {       
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired += VideoCapture1_OnLicenseRequired;
        }

        private void DestroyEngine()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired -= VideoCapture1_OnLicenseRequired;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();
                        
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            switch (cbSnippet.SelectedIndex)
            {
                case 0:
                    IPCameraPreviewSnippet();
                    break;
                case 1:
                    IPCameraCaptureToMP4Snippet();
                    break;
                case 2:
                    ScreenCaptureToMP4Snippet();
                    break;
                case 3:
                    ScreenCaptureToWMVSnippet();
                    break;
                case 4:
                    VideoPreviewSnippet();
                    break;
                case 5:
                    VideoCaptureToMP4Snippet();
                    break;
                case 6:
                    VideoCaptureToWMVSnippet();
                    break;
                case 7:
                    VideoCaptureToAVISnippet();
                    break;
                default:
                    throw new Exception("Snippet is not implemented.");
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }
        
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version})";

            VideoCapture1.Video_Renderer_SetAuto();

            foreach (var device in VideoCapture1.Video_CaptureDevices)
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            foreach (var device in VideoCapture1.Audio_CaptureDevices)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
            }

            cbSnippet.SelectedIndex = 0;
        }

        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
        }

        private void IPCameraPreviewSnippet()
        {
            // several engines available, we'll use LAV as the most compatible. for low latency RTSP playback use RTSP Low Latency engine.
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings() { 
                URL = edIPCameraURL.Text, 
                Type = IPSourceEngine.Auto_LAV,
                Login = edIPCameraLogin.Text,
                Password = edIPCameraPassword.Text
            };

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Mode = VideoCaptureMode.IPPreview;
        }

        private void IPCameraCaptureToMP4Snippet()
        {
            // several engines available, we'll use LAV as the most compatible. for low latency RTSP playback use RTSP Low Latency engine.
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings()
            {
                URL = edIPCameraURL.Text,
                Type = IPSourceEngine.Auto_LAV,
                Login = edIPCameraLogin.Text,
                Password = edIPCameraPassword.Text
            };

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Mode = VideoCaptureMode.IPCapture;

            VideoCapture1.Output_Format = new MP4Output();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void ScreenCaptureToMP4Snippet()
        {
            VideoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };
            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;
            VideoCapture1.Output_Format = new MP4Output();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void ScreenCaptureToWMVSnippet()
        {
            VideoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };
            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;

            VideoCapture1.Output_Format = new WMVOutput();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void VideoPreviewSnippet()
        {
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
        }

        private void VideoCaptureToMP4Snippet()
        {
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture;

            VideoCapture1.Output_Format = new MP4Output();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void VideoCaptureToWMVSnippet()
        {
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture;

            VideoCapture1.Output_Format = new WMVOutput();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void VideoCaptureToAVISnippet()
        {
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);

            VideoCapture1.Audio_PlayAudio = VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture;

            VideoCapture1.Output_Format = new AVIOutput();
            VideoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), edOutputFile.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming
