using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core;

namespace ip_camera_capture_mp4
{
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // RTSP camera source
            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(edURL.Text), edLogin.Text, edPassword.Text, cbAudioStream.Checked);
            videoCapture1.Video_Source = rtsp;

            // audio output device
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            // configure MP4 output
            var mp4Output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(mp4Output);

            // start
            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
