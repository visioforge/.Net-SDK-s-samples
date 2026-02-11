using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using static System.Net.Mime.MediaTypeNames;

namespace AlliedVision_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The source.
        /// </summary>
        private MediaBlock _source;

        /// <summary>
        /// The recording timer.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
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

        /// <summary>
        /// Update recording time.
        /// </summary>
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

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var devices = await DeviceEnumerator.Shared.AlliedVisionSourcesAsync();
                var camera = devices.First(x => x.Name == cbCamera.Text);

                //camera.ReadFeatures(out var features);
                //camera.ReadInfo();

                CreateEngine();

                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                _source = new AlliedVisionSourceBlock(new AlliedVisionSourceSettings(camera, 640, 480));
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(_source.Output, _videoRenderer.Input);

                await _pipeline.StartAsync();

                tmRecording.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tmRecording.Stop();

                await DestroyEngineAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                CreateEngine();

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

                var devices = await DeviceEnumerator.Shared.AlliedVisionSourcesAsync();
                foreach (var device in devices)
                {
                    cbCamera.Items.Add(device.Name);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
