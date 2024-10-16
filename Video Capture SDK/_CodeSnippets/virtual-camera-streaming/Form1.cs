using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using System.Security.Principal;

namespace video_capture_text_overlay
{
    public partial class Form1 : Form
    {
        private VideoCaptureCore videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            videoCapture1.Video_CaptureDevice = new VideoCaptureSource(videoCapture1.Video_CaptureDevices()[cbVideoSource.SelectedIndex].Name);
            videoCapture1.Audio_CaptureDevice = new AudioCaptureSource(videoCapture1.Audio_CaptureDevices()[cbAudioSource.SelectedIndex].Name);
            videoCapture1.Mode = VideoCaptureMode.VideoPreview;

            videoCapture1.Virtual_Camera_Output_Enabled = true;

            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            foreach (var device in videoCapture1.Video_CaptureDevices())
            {
                cbVideoSource.Items.Add(device.Name);
            }

            if (cbVideoSource.Items.Count > 0)
            {
                cbVideoSource.SelectedIndex = 0;
            }

            foreach (var device in videoCapture1.Audio_CaptureDevices())
            {
                cbAudioSource.Items.Add(device.Name);
            }

            if (cbAudioSource.Items.Count > 0)
            {
                cbAudioSource.SelectedIndex = 0;
            }

            var virtualCameraAvailable = videoCapture1.Virtual_Camera_Output_IsAvailable();
            if (!virtualCameraAvailable)
            {
                MessageBox.Show("The virtual camera is not yet registered. Admin rights are required to register the camera to be visible in external applications. Please click the Register Camera button.");
            }
        }

        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void btRegisterCamera_Click(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("Admin rights are required to register the camera. App will restart.");
            }

            videoCapture1.Virtual_Camera_Output_RegisterAsAdmin(allowAppRestart: true);
        }
    }
}
