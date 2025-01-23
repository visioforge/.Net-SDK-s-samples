﻿// ReSharper disable InconsistentNaming

namespace MultipleWebCameras
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using System.Threading.Tasks;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IDisposable
    {
        private VideoCaptureCore VideoCapture1;

        private VideoCaptureCore VideoCapture2;

        private bool disposedValue;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);
            VideoCapture1.OnError += VideoCapture1_OnError;

            VideoCapture2 = await VideoCaptureCore.CreateAsync(VideoView2 as IVideoView);
            VideoCapture2.OnError += VideoCapture2_OnError;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }

            if (VideoCapture2 != null)
            {
                VideoCapture2.OnError -= VideoCapture2_OnError;
                VideoCapture2.Dispose();
                VideoCapture2 = null;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await CreateEngineAsync();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

            foreach (var device in VideoCapture1.Video_CaptureDevices())
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
            if (string.IsNullOrEmpty(cbCamera1.Text))
            {
                return;
            }

            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera1.Text);
            VideoCapture1.Video_CaptureDevice.Format_UseBest = true;

            var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
            if (deviceItem == null)
            {
                return;
            }

            var videoFormat = deviceItem.VideoFormats.FirstOrDefault();
            if (videoFormat == null)
            {
                return;
            }

            if (videoFormat.FrameRates.Count > 0)
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = videoFormat.FrameRates[videoFormat.FrameRates.Count - 1];
            }

            // VideoCapture1.OnError += VideoCapture1OnOnError;
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture1.Audio_PlayAudio = false;

            await VideoCapture1.StartAsync();
        }

        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbCamera2.Text))
            {
                return;
            }

            VideoCapture2.Video_CaptureDevice = new VideoCaptureSource(cbCamera2.Text);
            VideoCapture2.Video_CaptureDevice.Format_UseBest = true;

            var deviceItem = VideoCapture2.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
            if (deviceItem == null)
            {
                return;
            }

            var videoFormat = deviceItem.VideoFormats.FirstOrDefault();
            if (videoFormat == null)
            {
                return;
            }

            if (videoFormat.FrameRates.Count > 0)
            {
                VideoCapture2.Video_CaptureDevice.FrameRate = videoFormat.FrameRates[videoFormat.FrameRates.Count - 1];
            }

            // VideoCapture2.OnError += VideoCapture2OnOnError;
            VideoCapture2.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture2.Audio_PlayAudio = false;
            await VideoCapture2.StartAsync();
        }

        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture2.StopAsync();
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM1: " + e.Message);
        }

        private void VideoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM2: " + e.Message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    VideoCapture1?.Dispose();
                    VideoCapture1 = null;

                    VideoCapture2?.Dispose();
                    VideoCapture2 = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MainWindow()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

// ReSharper restore InconsistentNaming