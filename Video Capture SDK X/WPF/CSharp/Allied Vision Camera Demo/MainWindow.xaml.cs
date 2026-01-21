using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;
using VisioForge.Core.VideoCaptureX;

namespace AlliedVision_Camera_Demo
{
    /// <summary>
    /// Interaction logic for the Allied Vision Camera Demo WPF demo's MainWindow.
    /// Demonstrates how to discover and capture from Allied Vision industrial cameras using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// Handles the OnError event of the video capture engine.
        /// Outputs error messages to the debug console.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Creates a new instance of the video capture engine and configures event handlers.
        /// </summary>
        private void CreateEngine()
        {
            _core = new VideoCaptureCoreX(VideoView1);
            _core.OnError += Core_OnError;
        }

        /// <summary>
        /// Asynchronously stops and disposes of the video capture engine.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
                _core.OnError -= Core_OnError;

                await _core.DisposeAsync();
                _core = null;
            }
        }

        /// <summary>
        /// Asynchronously updates the recording duration displayed in the UI.
        /// </summary>
        private void UpdateRecordingTime()
        {
            var ts = _core.Duration();

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
        /// Handles the Click event of the btStart control.
        /// Configures the engine for the selected Allied Vision camera and starts the preview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            _core.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var device = (await DeviceEnumerator.Shared.AlliedVisionSourcesAsync()).First(x => x.Name == cbCamera.Text);
            _core.Video_Source = new AlliedVisionSourceSettings(device);

            await _core.StartAsync();

            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the stream and cleans up engine resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await DestroyEngineAsync();
        }

        /// <summary>
        /// Handles the Loaded event of the window.
        /// Initializes the SDK and enumerates available Allied Vision cameras.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

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

        /// <summary>
        /// Handles the Closing event of the window.
        /// Ensures SDK resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
