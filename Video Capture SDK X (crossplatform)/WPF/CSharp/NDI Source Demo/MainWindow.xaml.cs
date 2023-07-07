using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
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
        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureCoreX _videoCapture;

        private NDISourceInfo[] _ndiSources;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _deviceEnumerator = new DeviceEnumerator();
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

        private async Task DestroyEngineAsync()
        {
            if (_videoCapture != null)
            {
                _videoCapture.OnError -= VideoCapture_OnError;

                await _videoCapture.DisposeAsync();
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

            var ndiSettings = await NDISourceSettings.CreateAsync(_videoCapture.GetContext(), _ndiSources[cbNDISources.SelectedIndex]); 
            _videoCapture.Video_Source = ndiSettings;

            await _videoCapture.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _videoCapture.StopAsync();

            await DestroyEngineAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }

        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            _ndiSources = await _deviceEnumerator.NDISourcesAsync();

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

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            _deviceEnumerator.Dispose();
        }
    }
}
