using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace VNC_Source_Demo
{
    /// <summary>
    /// Interaction logic for the VNC Source Demo WPF demo's MainWindow.
    /// Demonstrates how to connect to and capture from a VNC server using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// Handles the OnError event of the _videoCapture control.
        /// Outputs error messages to the debug console.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Creates a new instance of the video capture engine and subscribes to error events.
        /// </summary>
        private void CreateEngine()
        {
            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;
        }

        /// <summary>
        /// Asynchronously disposes of the video capture engine and unsubscribes from events.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (_videoCapture != null)
            {
                _videoCapture.OnError -= VideoCapture_OnError;

                await _videoCapture.DisposeAsync();
                _videoCapture = null;
            }
        }

        /// <summary>
        /// Updates the recording duration in the UI.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine with VNC server settings and starts the stream.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the VNC stream and cleans up the engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _videoCapture.StopAsync();

            await DestroyEngineAsync();
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the SDK and prepares the engine.
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
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// Ensures the engine is stopped and resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tmRecording.Stop();

            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
