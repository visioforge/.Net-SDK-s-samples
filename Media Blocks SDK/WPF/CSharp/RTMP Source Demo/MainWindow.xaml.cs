using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace RTMP_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private AudioRendererBlock _audioRenderer;

        private AudioOutputDeviceInfo[] _audioOutputs;

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
            Dispatcher.InvokeAsync(() => lbError.Text = e.Message);
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            try
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            _pipeline.OnError -= Pipeline_OnError;
            _pipeline = null;
            _audioRenderer = null;
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            lbError.Text = string.Empty;

            try
            {
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                // Connects to the server and reads which streams the RTMP feed carries.
                var settings = await RTMPSourceSettings.CreateAsync(new Uri(edURL.Text));
                var source = new RTMPSourceBlock(settings);

                // RTMP outputs are compressed (H.264/H.265, AAC/MP3), so each one goes through a decoder.
                if (source.VideoOutput != null)
                {
                    var videoDecoder = new UniversalDecoderBlock(MediaBlockPadMediaType.Video);
                    var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                    _pipeline.Connect(source.VideoOutput, videoDecoder.Input);
                    _pipeline.Connect(videoDecoder.Output, videoRenderer.Input);
                }

                if (source.AudioOutput != null && cbAudioOutput.SelectedIndex >= 0)
                {
                    var audioDecoder = new UniversalDecoderBlock(MediaBlockPadMediaType.Audio);
                    _audioRenderer = new AudioRendererBlock(_audioOutputs[cbAudioOutput.SelectedIndex]);
                    _audioRenderer.Volume = tbVolume.Value / 100.0;

                    _pipeline.Connect(source.AudioOutput, audioDecoder.Input);
                    _pipeline.Connect(audioDecoder.Output, _audioRenderer.Input);
                }

                await _pipeline.StartAsync();

                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lbError.Text = ex.Message;

                await DestroyEngineAsync();
                btStart.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStop.IsEnabled = false;

            await DestroyEngineAsync();

            btStart.IsEnabled = true;
        }

        /// <summary>
        /// Volume slider changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
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
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                foreach (var device in _audioOutputs)
                {
                    cbAudioOutput.Items.Add(device.DisplayName);
                }

                if (_audioOutputs.Length > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_pipeline == null)
            {
                VisioForgeX.DestroySDK();
                return;
            }

            // Stop the stream first, then close. While Start or Stop is still running, wait for it.
            e.Cancel = true;
            if (!btStop.IsEnabled)
            {
                return;
            }

            btStop.IsEnabled = false;
            await DestroyEngineAsync();
            Close();
        }
    }
}
