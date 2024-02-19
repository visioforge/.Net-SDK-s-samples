using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Plugins.Spinnaker;
using VisioForge.Plugins.Spinnaker.MediaBlocks.Sources;

namespace USB3V_GigE_Spinnaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private MediaBlock _source;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            //System.Windows.Forms.Application.EnableVisualStyles();

            CreateEngine();        
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private void UpdateRecordingTime()
        {
            var ts = _pipeline.Position_Get();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var sourceInfo = SpinnakerEnumerator.Cameras.ToList().Find(x => x.Name == cbCamera.Text);

            var settings = new SpinnakerSourceSettings(cbCamera.Text, new VisioForge.Core.Types.Rect(0, 0, Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text)), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text))); 
            _source = new SpinnakerSourceBlock(settings);
            
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            _pipeline.Connect(_source.Output, _videoRenderer.Input);

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await DestroyEngineAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            await SpinnakerEnumerator.EnumerateAsync();

            foreach (var device in SpinnakerEnumerator.Cameras)
            {
                cbCamera.Items.Add(device.Name);
            }

            if (cbCamera.Items.Count > 0)
            {
                cbCamera.SelectedIndex = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}