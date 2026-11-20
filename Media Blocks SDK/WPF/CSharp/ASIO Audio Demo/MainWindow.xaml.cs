namespace ASIO_Audio_Demo_MB
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sinks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Sources;

    /// <summary>
    /// Routes an ASIO input to an ASIO output, optionally recording it to a WAV file.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            IsEnabled = true;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "asio.wav");

            // ASIO devices come from the regular device enumerator, filtered by API.
            foreach (var device in await ASIOSourceBlock.GetDevicesAsync())
            {
                cbInputDevice.Items.Add(device.DisplayName);
            }

            foreach (var device in await ASIOSinkBlock.GetDevicesAsync())
            {
                cbOutputDevice.Items.Add(device.DisplayName);
            }

            cbInputDevice.SelectedIndex = cbInputDevice.Items.Count > 0 ? 0 : -1;
            cbOutputDevice.SelectedIndex = cbOutputDevice.Items.Count > 0 ? 0 : -1;

            if (cbInputDevice.Items.Count == 0 || cbOutputDevice.Items.Count == 0)
            {
                Log("No ASIO input or output device found. Install the device's ASIO driver, or FlexASIO / ASIO4ALL.");
                btStart.IsEnabled = false;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();
            btStart.IsEnabled = false;

            try
            {
                var bufferSize = uint.Parse(edBufferSize.Text);

                var inputDevice = (await ASIOSourceBlock.GetDevicesAsync()).First(d => d.DisplayName == cbInputDevice.Text);
                var source = new ASIOSourceBlock(new ASIOSourceSettings(inputDevice)
                {
                    Channels = ParseChannels(edInputChannels.Text),
                    BufferSize = bufferSize,
                });

                var outputDevice = (await ASIOSinkBlock.GetDevicesAsync()).First(d => d.DisplayName == cbOutputDevice.Text);
                var sink = new ASIOSinkBlock(new ASIOSinkSettings(outputDevice)
                {
                    Channels = ParseChannels(edOutputChannels.Text),
                    BufferSize = bufferSize,
                });

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                if (cbRecord.IsChecked == true)
                {
                    // The tee sends the same audio to the output device and to the file.
                    var tee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                    var wav = new WAVSinkBlock(edOutputFile.Text);
                    _pipeline.Connect(source.Output, tee.Input);
                    _pipeline.Connect(tee.Outputs[0], sink.Input);
                    _pipeline.Connect(tee.Outputs[1], wav.Input);
                }
                else
                {
                    _pipeline.Connect(source.Output, sink.Input);
                }

                if (await _pipeline.StartAsync())
                {
                    btStop.IsEnabled = true;
                    return;
                }

                await DestroyPipelineAsync();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                await DestroyPipelineAsync();
            }

            btStart.IsEnabled = true;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStop.IsEnabled = false;
            await _pipeline.StopAsync();
            await DestroyPipelineAsync();
            btStart.IsEnabled = true;
        }

        /// <summary>
        /// "0,1" to { 0, 1 }; an empty text selects every channel.
        /// </summary>
        private static int[] ParseChannels(string text)
        {
            return text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        }

        private async System.Threading.Tasks.Task DestroyPipelineAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _pipeline.OnError -= Pipeline_OnError;
            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void Log(string text)
        {
            Dispatcher.Invoke(() => mmLog.AppendText(text + Environment.NewLine));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_pipeline == null)
            {
                VisioForgeX.DestroySDK();
                return;
            }

            // Keep the window open until a graceful stop has finished the WAV file, then close again.
            e.Cancel = true;
            if (!IsEnabled)
            {
                return;
            }

            IsEnabled = false;
            await _pipeline.StopAsync();
            await DestroyPipelineAsync();
            // Deferred: WPF throws if Close() runs while this Closing call is still on the stack.
            _ = Dispatcher.BeginInvoke(new Action(Close));
        }
    }
}
