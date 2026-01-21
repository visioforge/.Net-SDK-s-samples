using System;
using System.Threading.Tasks;
using System.Windows;

namespace Multiple_IP_Cameras_Demo_WPF
{
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        /// <summary>
        /// The mp4 output.
        /// </summary>
        private MP4Output mp4Output = new MP4Output();

        /// <summary>
        /// The video capture 1.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The video capture 2.
        /// </summary>
        private VideoCaptureCore VideoCapture2;

        /// <summary>
        /// The video capture 3.
        /// </summary>
        private VideoCaptureCore VideoCapture3;

        /// <summary>
        /// The video capture 4.
        /// </summary>
        private VideoCaptureCore VideoCapture4;

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
            VideoCapture1.OnError += VideoCapture_OnError;

            VideoCapture2 = await VideoCaptureCore.CreateAsync(VideoView2 as IVideoView);
            VideoCapture2.OnError += VideoCapture_OnError;

            VideoCapture3 = await VideoCaptureCore.CreateAsync(VideoView3 as IVideoView);
            VideoCapture3.OnError += VideoCapture_OnError;

            VideoCapture4 = await VideoCaptureCore.CreateAsync(VideoView4 as IVideoView);
            VideoCapture4.OnError += VideoCapture_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture_OnError;
                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }

            if (VideoCapture2 != null)
            {
                VideoCapture2.OnError -= VideoCapture_OnError;
                VideoCapture2.Dispose();
                VideoCapture2 = null;
            }

            if (VideoCapture3 != null)
            {
                VideoCapture3.OnError -= VideoCapture_OnError;
                VideoCapture3.Dispose();
                VideoCapture3 = null;
            }

            if (VideoCapture4 != null)
            {
                VideoCapture4.OnError -= VideoCapture_OnError;
                VideoCapture4.Dispose();
                VideoCapture4 = null;
            }
        }

        /// <summary>
        /// Start camera.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="preview">If set to <c>true</c> [preview].</param>
        /// <param name="videoCapture">The video capture.</param>
        /// <param name="index">The index.</param>
        /// <param name="onvif">If set to <c>true</c> [onvif].</param>
        private Task StartCamera(string url, bool preview, VideoCaptureCore videoCapture, int index, bool onvif)
        {
            // source
            videoCapture.IP_Camera_Source = new IPCameraSourceSettings { URL = new Uri(url), ONVIF_Source = onvif };

            switch (cbEngine.SelectedIndex)
            {
                case 0:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.Auto_VLC;
                    break;
                case 1:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.Auto_FFMPEG;
                    break;
                case 2:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV;
                    videoCapture.IP_Camera_Source.LAV_GPU_Use = false;
                    break;
                case 3:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV;
                    videoCapture.IP_Camera_Source.LAV_GPU_Use = true;
                    videoCapture.IP_Camera_Source.LAV_GPU_Mode = LAVGPUDecoder.DXVA2Native;
                    break;
                case 4:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.MMS_WMV;
                    break;
                case 5:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.HTTP_MJPEG_LowLatency;
                    break;
                case 6:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency;
                    videoCapture.IP_Camera_Source.RTSP_LowLatency_UseUDP = false;
                    break;
                case 7:
                    videoCapture.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency;
                    videoCapture.IP_Camera_Source.RTSP_LowLatency_UseUDP = true;
                    break;
            }

            videoCapture.Audio_RecordAudio = false;
            videoCapture.Audio_PlayAudio = false;

            if (preview)
            {
                videoCapture.Mode = VideoCaptureMode.IPPreview;
            }
            else
            {
                videoCapture.Mode = VideoCaptureMode.IPCapture;

                videoCapture.Output_Filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $@"VisioForge\output_{DateTime.Now:yy-MM-dd hh_mm_ss}_{index}.mp4");
                videoCapture.Output_Format = mp4Output;
            }

            videoCapture.Debug_Mode = cbDebug.IsChecked == true;
            if (cbDebug.IsChecked == true)
            {
                videoCapture.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $@"VisioForge\cam_{index}\");
            }

            return videoCapture.StartAsync();
        }

        /// <summary>
        /// Handles the bt start 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart1_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL1.Text, rbPreview1.IsChecked == true, VideoCapture1, 1, cbONVIF1.IsChecked == true);
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
        /// Video capture on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
                                                   {
                                                       edLog.Text += e.Message + Environment.NewLine;
                                                   }));
        }

        /// <summary>
        /// Handles the bt start 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL2.Text, rbPreview2.IsChecked == true, VideoCapture2, 2, cbONVIF2.IsChecked == true);
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
        /// Handles the bt start 3 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart3_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL3.Text, rbPreview3.IsChecked == true, VideoCapture3, 3, cbONVIF3.IsChecked == true);
        }

        /// <summary>
        /// Handles the bt stop 3 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop3_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture3.StopAsync();
        }

        /// <summary>
        /// Handles the bt start 4 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart4_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL4.Text, rbPreview4.IsChecked == true, VideoCapture4, 4, cbONVIF4.IsChecked == true);
        }

        /// <summary>
        /// Handles the bt stop 4 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop4_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture4.StopAsync();
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

                    VideoCapture3?.Dispose();
                    VideoCapture3 = null;

                    VideoCapture4?.Dispose();
                    VideoCapture4 = null;
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
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
