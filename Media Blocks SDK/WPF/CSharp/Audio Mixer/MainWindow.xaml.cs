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

    public partial class MainWindow : Window
    {
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private bool disposedValue;

        private MediaBlocksPipeline _pipeline;

        private SystemAudioSourceBlock _audioSource1;

        private SystemAudioSourceBlock _audioSource2;

        private AudioMixerBlock _audioMixer;

        private AudioRendererBlock _audioRenderer;

        private TeeBlock _tee;

        private MP3OutputBlock _mp3Output;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void CreatePipeline()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        private async Task DestroyPipelineAsync()
        {
            if ( _pipeline == null )
            {
                return;
            }

            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

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

        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer == null)
            {
                return;
            }

            _audioRenderer.Volume = tbAudioVolume.Value / 100.0;
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
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

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            tmRecording.Stop();

            await _pipeline.StopAsync();

            await DestroyPipelineAsync();
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
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private void llVideoTutorials_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void Pipeline_OnStop(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: 00:00:00";
            }));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyPipelineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}

// ReSharper restore InconsistentNaming