using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace NDI_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private NDISourceInfo[] _ndiSources;

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

        private async void UpdateRecordingTime()
        {
            var ts = await _videoCapture.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            await Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbNDISources.SelectedIndex == -1)
            {
                MessageBox.Show("Please select NDI source");
                return;
            }

            CreateEngine();

            _videoCapture.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var ndiSettings = new NDISourceSettings(_ndiSources[cbNDISources.SelectedIndex]); 
            _videoCapture.Video_Source = ndiSettings;

            await _videoCapture.StartAsync();

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

        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            _ndiSources = await DeviceEnumerator.NDISourcesAsync();

            cbNDISources.Items.Clear();

            foreach (var ndiSource in _ndiSources)
            {
                cbNDISources.Items.Add(ndiSource.Name);
            }

            if (cbNDISources.Items.Count > 0)
            {
                cbNDISources.SelectedIndex = 0;
            }
        }
    }
}
