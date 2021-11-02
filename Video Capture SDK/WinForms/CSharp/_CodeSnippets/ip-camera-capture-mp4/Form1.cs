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

using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.Output;
using VisioForge.Types.VideoCapture;

namespace ip_camera_capture_mp4
{
    public partial class Form1 : Form
    {
        private VideoCaptureCore videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // Several engines are available. We'll use LAV as the most compatible. For low latency RTSP playback, use the RTSP Low Latency engine.
            videoCapture1.IP_Camera_Source = new IPCameraSourceSettings()
            {
                URL = "http://192.168.233.129:8000/camera/mjpeg"
            };

            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;
            videoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            videoCapture1.Output_Format = new MP4Output(); //using MP4 output with default settings
            videoCapture1.Mode = VideoCaptureMode.IPCapture;

            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();
        }
    }
}
