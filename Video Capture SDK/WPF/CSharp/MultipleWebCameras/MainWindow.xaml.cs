

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
        /// <summary>
        /// The video capture 1.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The video capture 2.
        /// </summary>
        private VideoCaptureCore VideoCapture2;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);
            VideoCapture1.OnError += VideoCapture1_OnError;

            VideoCapture2 = await VideoCaptureCore.CreateAsync(VideoView2 as IVideoView);
            VideoCapture2.OnError += VideoCapture2_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
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

        /// <summary>
        /// Window loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt start 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt stop 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the bt start 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt stop 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture2.StopAsync();
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM1: " + e.Message);
        }

        /// <summary>
        /// Video capture 2 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("CAM2: " + e.Message);
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

