using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace VNC_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;
        }

        private void DestroyEngine()
        {
            if (_videoCapture != null)
            {
                _videoCapture.OnError -= VideoCapture_OnError;

                _videoCapture.Dispose();
                _videoCapture = null;
            }
        }

        private void UpdateRecordingTime()
        {            
            //var ts = _pipeline.Duration();

            //if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            //{
            //    return;
            //}

            //Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            //}));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            //_pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _videoCapture.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var vncSettings = new VNCSourceSettings(); ;
            if (rbHost.IsChecked == true)
            {
                vncSettings.Host = edHost.Text;
                vncSettings.Port = Convert.ToInt32(edPort.Text);
            }
            else
            {
                vncSettings.Uri = edURL.Text;
            }

            
            vncSettings.Password = edPassword.Text;

            _videoCapture.Video_Source = vncSettings;

            await _videoCapture.StartAsync();

            //_pipeline.SavePipeline("ndi_source");

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _videoCapture.StopAsync();

            DestroyEngine();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }
    }
}
