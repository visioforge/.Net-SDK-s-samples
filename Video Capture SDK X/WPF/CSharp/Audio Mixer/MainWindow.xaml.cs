using VisioForge.Core.UI;

namespace Audio_Mixer_MB
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.MediaBlocks.Sinks;
    using VisioForge.Core.Types.X.AudioEncoders;
    using System.Threading.Tasks;
    using VisioForge.Core.MediaBlocks.AudioProcessing;
    using VisioForge.Core.Types.X.AudioEffects;
    using VisioForge.Core.VideoCaptureX;
    using VisioForge.Core.Types.X.AudioRenderers;

    /// <summary>
    /// Interaction logic for the Audio Mixer WPF demo's MainWindow.
    /// Demonstrates how to mix multiple audio sources (mic, loopback) and optionally record the result to MP3 using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private bool disposedValue;

        private VideoCaptureCoreX _core;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// Creates a new instance of the video capture engine and configures event handlers.
        /// </summary>
        private void CreatePipeline()
        {
            _core = new VideoCaptureCoreX();
            _core.OnError += Pipeline_OnError;
            _core.OnStop += Pipeline_OnStop;
        }

        /// <summary>
        /// Asynchronously disposes of the video capture engine and unsubscribes from events.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DestroyPipelineAsync()
        {
            if ( _core == null )
            {
                return;
            }

            await _core.DisposeAsync();
            _core = null;
        }

        /// <summary>
        /// Handles the Loaded event of the window.
        /// Initializes the SDK, prepares the UI, and enumerates available audio sources and outputs.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            cbMode.SelectedIndex = 0;

            // enumerate audio sources
            var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();

            foreach (var source in audioSources)
            {
                cbAudioInputDevice1.Items.Add(source.DisplayName);
                cbAudioInputDevice2.Items.Add(source.DisplayName);

                if (cbAudioInputDevice1.Items.Count == 1)
                {
                    cbAudioInputDevice1.SelectedIndex = 0;
                }

                if (cbAudioInputDevice2.Items.Count == 1)
                {
                    cbAudioInputDevice2.SelectedIndex = 0;
                }
            }

            // enumerate audio sinks
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var sink in audioSinks)
            {
                cbAudioOutputDevice.Items.Add(sink.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }

                if (sink.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioLoopbackDevice1.Items.Add(sink.Name);
                    cbAudioLoopbackDevice2.Items.Add(sink.Name);

                    if (cbAudioLoopbackDevice1.Items.Count == 1)
                    {
                        cbAudioLoopbackDevice1.SelectedIndex = 0;
                    }

                    if (cbAudioLoopbackDevice2.Items.Count == 1)
                    {
                        cbAudioLoopbackDevice2.SelectedIndex = 0;
                    }
                }
            }

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp3");
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbAudioInputDevice1 control.
        /// Populates available formats for the first selected audio device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioInputDevice1_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInputDevice1.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat1.Items.Clear();

                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }
             
                foreach (var format in deviceItem.Formats)
                {
                    cbAudioInputFormat1.Items.Add(format.Name);
                }

                if (cbAudioInputFormat1.Items.Count > 0)
                {
                    cbAudioInputFormat1.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbAudioInputDevice2 control.
        /// Populates available formats for the second selected audio device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioInputDevice2_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInputDevice2.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat2.Items.Clear();

                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.Formats)
                {
                    cbAudioInputFormat2.Items.Add(format.Name);
                }

                if (cbAudioInputFormat2.Items.Count > 0)
                {
                    cbAudioInputFormat2.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioVolume control.
        /// Updates the output device volume.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_core == null)
            {
                return;
            }

            _core.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0;
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a save file dialog to select the MP3 recording output path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the audio mixer with selected inputs, sets up the output device (and optional MP3 recording), and starts the engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            CreatePipeline();

            _core.Debug_Mode = cbDebugMode.IsChecked == true;
            _core.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // audio output
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.Text).First();
            _core.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            // audio mixer
            var audioMixer = new AudioMixerSourceSettings();

            // audio input 1
            if (rbSystemAudio1.IsChecked == true)
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == cbAudioInputDevice1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                AudioCaptureDeviceFormat format = null;
                var formats1 = deviceItem.Formats.Where(fmt => fmt.Name == cbAudioInputFormat1.Text).ToList();
                if (formats1.Count > 0)
                {
                    format = formats1[0].ToFormat();
                }

                var audioSource = deviceItem.CreateSourceSettingsVC(format);
                audioMixer.Inputs.Add(audioSource);
            }
            else
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
                audioMixer.Inputs.Add(audioSource);
            }

            // audio input 2
            if (rbSystemAudio2.IsChecked == true)
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == cbAudioInputDevice2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                AudioCaptureDeviceFormat format = null;
                var formats2 = deviceItem.Formats.Where(fmt => fmt.Name == cbAudioInputFormat2.Text).ToList();
                if (formats2.Count > 0)
                {
                    format = formats2[0].ToFormat();
                }

                var audioSource = deviceItem.CreateSourceSettingsVC(format);
                audioMixer.Inputs.Add(audioSource);
            }
            else
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
                audioMixer.Inputs.Add(audioSource);
            }

            _core.Audio_Source = audioMixer;

            // MP3 capture?
            if (cbMode.SelectedIndex == 1)
            {
                var mp3Output = new MP3Output(edOutput.Text);
                _core.Outputs_Add(mp3Output);
            }

            await _core.StartAsync();

            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the engine and cleans up resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            tmRecording.Stop();

            await _core.StopAsync();

            await DestroyPipelineAsync();
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
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the MouseDown event of the llVideoTutorials control.
        /// Opens the video tutorials URL in the default browser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void llVideoTutorials_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Logs a message to the UI log window.
        /// </summary>
        /// <param name="txt">The message to log.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
        }

        /// <summary>
        /// Handles the OnError event of the video capture engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the OnStop event of the video capture engine.
        /// Resets the recording timer display.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnStop(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: 00:00:00";
            }));
        }

        /// <summary>
        /// Handles the Closing event of the window.
        /// Ensures the engine is stopped and SDK resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyPipelineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}

