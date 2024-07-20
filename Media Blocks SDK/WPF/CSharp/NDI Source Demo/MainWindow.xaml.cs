using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace NDI_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private NDISourceBlock _ndiSource;

        private NDISourceInfo[] _ndiSources;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void UpdateRecordingTime()
        {
            var ts = await _pipeline.Position_GetAsync();

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

            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var ndiSettings = await NDISourceSettings.CreateAsync(_pipeline.GetContext(), _ndiSources[cbNDISources.SelectedIndex]); 

            _ndiSource = new NDISourceBlock(ndiSettings);
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            _pipeline.Connect(_ndiSource.VideoOutput, _videoRenderer.Input);

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _pipeline.StopAsync();

            await DestroyEngineAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }

        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            _ndiSources = await DeviceEnumerator.Shared.NDISourcesAsync();

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
            tmRecording?.Stop();

            Thread.Sleep(500);

            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
