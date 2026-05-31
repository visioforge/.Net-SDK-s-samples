using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace UDP_RAW_Capture_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private UDPRAWSourceBlock _source;
        private TeeBlock _videoTee;
        private MP4SinkBlock _recorder;
        private DecodeBinBlock _previewDecoder;
        private VideoRendererBlock _videoRenderer;

        private bool _isStarted;

        // Guard for the two-phase Window_Closing pattern. Because CleanupAsync/DestroySDK are
        // async, the first close is cancelled, teardown is awaited, then Close() is re-invoked;
        // this flag lets the second invocation fall through without cancelling again.
        private bool _isClosing;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [INITIALIZING SDK...]";
                IsEnabled = false;

                try
                {
                    await VisioForgeX.InitSDKAsync();
                    Title = Title.Replace(" [INITIALIZING SDK...]", "");
                    Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to initialize SDK: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                    return;
                }
                finally
                {
                    IsEnabled = true;
                }

                edFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

                LogMessage("SDK initialized successfully.");
                UpdateControlState(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Log message.
        /// </summary>
        private void LogMessage(string message)
        {
            mmLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");

            // Cap the log buffer so a long-running capture does not grow it without bound.
            if (mmLog.Text.Length > 20000)
            {
                mmLog.Text = mmLog.Text.Substring(mmLog.Text.Length - 16000);
            }

            mmLog.ScrollToEnd();
        }

        /// <summary>
        /// Enables/disables the buttons and input controls according to the running state.
        /// While a capture is running the input controls are locked so settings cannot be
        /// changed under the live pipeline.
        /// </summary>
        private void UpdateControlState(bool running)
        {
            btStart.IsEnabled = !running;
            btStop.IsEnabled = running;

            edUrl.IsEnabled = !running;
            cbMode.IsEnabled = !running;
            cbCodec.IsEnabled = !running;
            edPayload.IsEnabled = !running;
            edFolder.IsEnabled = !running;
            btBrowse.IsEnabled = !running;
            edPattern.IsEnabled = !running;
            edSplitSeconds.IsEnabled = !running;
            edMaxFiles.IsEnabled = !running;
        }

        /// <summary>
        /// Builds the source settings from the UI.
        /// </summary>
        private UDPRAWSourceSettings BuildSourceSettings()
        {
            var settings = new UDPRAWSourceSettings(new Uri(edUrl.Text.Trim()))
            {
                Mode = (UDPRAWSourceMode)cbMode.SelectedIndex,
                VideoCodec = cbCodec.SelectedIndex == 1 ? UDPRAWVideoCodec.H265 : UDPRAWVideoCodec.H264,
                RTPPayloadType = int.TryParse(edPayload.Text, out var pt) ? pt : 96,

                // This demo records a video-only feed, so no audio output is exposed.
                AudioEnabled = false
            };

            return settings;
        }

        /// <summary>
        /// Start.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_isStarted)
            {
                LogMessage("Already started.");
                return;
            }

            // Disable both buttons for the whole start sequence so a second click while the
            // first StartAsync is still awaiting cannot build a second pipeline (the _isStarted
            // guard is only set after the await, leaving a re-entrancy window).
            btStart.IsEnabled = false;
            btStop.IsEnabled = false;

            try
            {
                var folder = edFolder.Text.Trim();
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var pattern = string.IsNullOrWhiteSpace(edPattern.Text) ? "capture_%05d.mp4" : edPattern.Text.Trim();
                var locationPattern = Path.Combine(folder, pattern);

                var seconds = double.TryParse(edSplitSeconds.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var s) && s > 0 ? s : 10;
                var maxFiles = uint.TryParse(edMaxFiles.Text, out var mf) ? mf : 0;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                // 1. UDP RAW source (encoded H264/H265, no decoding).
                _source = new UDPRAWSourceBlock(BuildSourceSettings());

                // 2. Tee the encoded video into a recording branch and a preview branch.
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                // 3. Recording branch: split MP4 sink (no re-encoding, splits on key-frames).
                var splitSettings = new MP4SplitSinkSettings(locationPattern)
                {
                    SplitDuration = TimeSpan.FromSeconds(seconds),
                    SplitMaxFiles = maxFiles
                };
                _recorder = new MP4SinkBlock(splitSettings);
                var recVideoInput = (_recorder as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video);

                // 4. Preview branch: decode for display only.
                _previewDecoder = new DecodeBinBlock(renderVideo: true, renderAudio: false, renderSubtitle: false);
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // Connect: source -> tee -> [recorder] + [decode -> renderer]
                _pipeline.Connect(_source.VideoOutput, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], recVideoInput);
                _pipeline.Connect(_videoTee.Outputs[1], _previewDecoder.Input);
                _pipeline.Connect(_previewDecoder.VideoOutput, _videoRenderer.Input);

                var result = await _pipeline.StartAsync();
                if (result)
                {
                    _isStarted = true;
                    lbStatus.Text = "Status: Running";
                    LogMessage($"Started. Recording to: {locationPattern} (new file every {seconds} sec).");
                    UpdateControlState(true);
                }
                else
                {
                    LogMessage("Failed to start the pipeline.");
                    await CleanupAsync();
                    UpdateControlState(false);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting: {ex.Message}");
                MessageBox.Show($"Failed to start: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                await CleanupAsync();
                UpdateControlState(false);
            }
        }

        /// <summary>
        /// Stop.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (!_isStarted)
            {
                LogMessage("Not running.");
                return;
            }

            try
            {
                LogMessage("Stopping...");
                await CleanupAsync();
                lbStatus.Text = "Status: Stopped";
                LogMessage("Stopped.");
                UpdateControlState(false);
            }
            catch (Exception ex)
            {
                // async void: an unhandled teardown exception would crash the app.
                LogMessage($"Error stopping: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cleanup.
        /// </summary>
        private async Task CleanupAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _videoRenderer?.Dispose();
            _videoRenderer = null;

            _previewDecoder?.Dispose();
            _previewDecoder = null;

            (_recorder as IDisposable)?.Dispose();
            _recorder = null;

            _videoTee?.Dispose();
            _videoTee = null;

            _source?.Dispose();
            _source = null;

            _isStarted = false;
        }

        /// <summary>
        /// Pipeline error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => LogMessage($"Pipeline error: {e.Message}")));
        }

        /// <summary>
        /// Browse output folder.
        /// </summary>
        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog();
            if (Directory.Exists(edFolder.Text))
            {
                dlg.InitialDirectory = edFolder.Text;
            }

            if (dlg.ShowDialog() == true)
            {
                edFolder.Text = dlg.FolderName;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // async void + Close() race: WPF does not await this handler, so the window could tear
            // down mid-await of CleanupAsync/DestroySDK. Cancel the initial close, tear down
            // asynchronously, then re-invoke Close(); the second invocation sees _isClosing == true
            // and falls through so the window actually closes.
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            try
            {
                await CleanupAsync();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                // Never block shutdown on a teardown failure — the user wants out.
                Debug.WriteLine(ex);
            }

            try
            {
                Dispatcher.BeginInvoke(new Action(() => Close()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                // If BeginInvoke failed, the second Close() never fires; reset the flag and
                // re-enable the window so the user can try again (teardown is already done).
                _isClosing = false;
                IsEnabled = true;
            }
        }
    }
}
