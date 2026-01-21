using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioRenderers;

namespace NDI_Source_Demo
{
    /// <summary>
    /// Interaction logic for the NDI Source Demo WPF demo's MainWindow.
    /// Demonstrates how to discover and receive NDI streams using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private NDISourceInfo[] _ndiSources;

        private AudioOutputDeviceInfo[] _audioOutputDevices;

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
        /// Asynchronously updates the recording duration displayed in the UI.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine for the selected NDI source and starts the stream.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
            if (ndiSettings == null || !ndiSettings.IsValid())
            {
                MessageBox.Show("Selected NDI source is not valid.");
                return;
            }

            _videoCapture.Video_Source = ndiSettings;

            // Set audio output device if one is selected
            if (ndiSettings.GetInfo().AudioStreams.Count > 0 && cbAudioOutputDevices.SelectedIndex >= 0 && _audioOutputDevices != null && _audioOutputDevices.Length > cbAudioOutputDevices.SelectedIndex)
            {
                var audioOutputSettings = new AudioRendererSettings(_audioOutputDevices[cbAudioOutputDevices.SelectedIndex]);
                _videoCapture.Audio_OutputDevice = audioOutputSettings;

              //  _videoCapture.Audio_Source = ndiSettings;
                _videoCapture.Audio_Play = true;
            }

            await _videoCapture.StartAsync();

            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the stream and disposes of the engine instance.
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
        /// Handles the Loaded event of the Window control.
        /// Initializes the SDK and prepares the UI.
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

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            // Load audio output devices
            await LoadAudioOutputDevicesAsync();
        }

        /// <summary>
        /// Asynchronously enumerates and populates the audio output devices list.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task LoadAudioOutputDevicesAsync()
        {
            try
            {
                _audioOutputDevices = await DeviceEnumerator.Shared.AudioOutputsAsync();

                cbAudioOutputDevices.Items.Clear();

                foreach (var audioDevice in _audioOutputDevices)
                {
                    cbAudioOutputDevices.Items.Add(audioDevice.DisplayName);
                }

                if (cbAudioOutputDevices.Items.Count > 0)
                {
                    cbAudioOutputDevices.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading audio output devices: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the Click event of the btListNDISources control.
        /// Asynchronously discovers available NDI sources on the network and populates the list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// Ensures resources are released and the SDK is destroyed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
