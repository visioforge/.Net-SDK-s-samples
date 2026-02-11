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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The save file dialog.
        /// </summary>
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();

        /// <summary>
        /// The recording timer.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The audio source 1.
        /// </summary>
        private SystemAudioSourceBlock _audioSource1;

        /// <summary>
        /// The audio source 2.
        /// </summary>
        private SystemAudioSourceBlock _audioSource2;

        /// <summary>
        /// The audio mixer.
        /// </summary>
        private AudioMixerBlock _audioMixer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The tee.
        /// </summary>
        private TeeBlock _tee;

        /// <summary>
        /// The MP3 output.
        /// </summary>
        private MP3OutputBlock _mp3Output;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Create pipeline.
        /// </summary>
        private void CreatePipeline()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        /// <summary>
        /// Destroy pipeline async.
        /// </summary>
        private async Task DestroyPipelineAsync()
        {
            if ( _pipeline == null )
            {
                return;
            }

            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

        /// <summary>
        /// Form 1 load.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb audio input device 1 selected index changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioInputDevice1_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb audio input device 2 selected index changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioInputDevice2_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the tb audio volume scroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer == null)
            {
                return;
            }

            _audioRenderer.Volume = tbAudioVolume.Value / 100.0;
        }

        /// <summary>
        /// Handles the bt select output click event.
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
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mmLog.Clear();

                CreatePipeline();

                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                // audio output
                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.Text).First();
                _audioRenderer = new AudioRendererBlock(audioOutputDevice) { IsSync = false };

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

                    var audioSource = deviceItem.CreateSourceSettings(format);
                    _audioSource1 = new SystemAudioSourceBlock(audioSource);
                }
                else
                {
                    var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice1.Text);
                    if (deviceItem == null)
                    {
                        return;
                    }

                    var audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
                    _audioSource1 = new SystemAudioSourceBlock(audioSource);
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

                    var audioSource = deviceItem.CreateSourceSettings(format);
                    _audioSource2 = new SystemAudioSourceBlock(audioSource);
                }
                else
                {
                    var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice2.Text);
                    if (deviceItem == null)
                    {
                        return;
                    }

                    var audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
                    _audioSource2 = new SystemAudioSourceBlock(audioSource);
                }

                // audio mixer
                _audioMixer = new AudioMixerBlock(new AudioMixerSettings());
                _pipeline.Connect(_audioSource1.Output, _audioMixer.CreateNewInput());
                _pipeline.Connect(_audioSource2.Output, _audioMixer.CreateNewInput());

                if (cbMode.SelectedIndex == 0)
                {
                    _pipeline.Connect(_audioMixer.Output, _audioRenderer.Input);
                }
                else
                {
                    _tee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                    _mp3Output = new MP3OutputBlock(edOutput.Text, new MP3EncoderSettings());

                    _pipeline.Connect(_audioMixer.Output, _tee.Input);
                    _pipeline.Connect(_tee.Outputs[0], _audioRenderer.Input);
                    _pipeline.Connect(_tee.Outputs[1], _mp3Output.Input);
                }

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
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                tmRecording.Stop();

                await _pipeline.StopAsync();

                await DestroyPipelineAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Ll video tutorials mouse down.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void llVideoTutorials_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">The text.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the pipeline on stop event.
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
        /// Window closing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                await DestroyPipelineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

