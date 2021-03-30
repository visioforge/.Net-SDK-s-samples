// ReSharper disable InconsistentNaming

using System.Globalization;

namespace MultipleWebCameras
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;

    using VisioForge.Types;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += " (SDK v" + videoCapture1.SDK_Version + ", " + videoCapture1.SDK_State + ")";

            foreach (var device in videoCapture1.Video_CaptureDevicesInfo)
            {
                cbCamera1.Items.Add(device.Name);
                cbCamera2.Items.Add(device.Name);
            }

            if (cbCamera1.Items.Count > 0)
            {
                cbCamera1.SelectedIndex = 0;
                cbCamera2.SelectedIndex = 0;
            }
        }

        private async void btStart1_Click(object sender, RoutedEventArgs e)
        {
            videoCapture1.Video_CaptureDevice = cbCamera1.Text;
            videoCapture1.Video_CaptureFormat_UseBest = true;

            var deviceItem = videoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera1.Text);
            if (deviceItem == null)
            {
                return;
            }

            var videoFormat = deviceItem.VideoFormats.FirstOrDefault();
            if (videoFormat == null)
            {
                return;
            }

            videoCapture1.Video_FrameRate = videoFormat.FrameRates[videoFormat.FrameRates.Count - 1];

            // videoCapture1.OnError += VideoCapture1OnOnError;
            videoCapture1.Mode = VFVideoCaptureMode.VideoPreview;
            videoCapture1.Audio_PlayAudio = false;

            await videoCapture1.StartAsync();
        }

        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            videoCapture2.Video_CaptureDevice = cbCamera2.Text;
            videoCapture2.Video_CaptureFormat_UseBest = true;

            var deviceItem = videoCapture2.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera2.Text);
            if (deviceItem == null)
            {
                return;
            }

            var videoFormat = deviceItem.VideoFormats.FirstOrDefault();
            if (videoFormat == null)
            {
                return;
            }

            videoCapture2.Video_FrameRate = videoFormat.FrameRates[videoFormat.FrameRates.Count - 1];

            // videoCapture2.OnError += VideoCapture2OnOnError;
            videoCapture2.Mode = VFVideoCaptureMode.VideoPreview;
            videoCapture2.Audio_PlayAudio = false;
            await videoCapture2.StartAsync();
        }

        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture2.StopAsync();
        }

        private void videoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM1: " + e.Message);
        }

        private void videoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM2: " + e.Message);
        }
    }
}

// ReSharper restore InconsistentNaming