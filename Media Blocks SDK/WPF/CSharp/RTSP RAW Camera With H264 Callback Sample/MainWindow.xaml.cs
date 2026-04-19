using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Parsers;
using VisioForge.Core.MediaBlocks.VideoDecoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_RAW_Camera_Sample
{
    /// <summary>
    /// RTSP RAW Camera Sample - Two Pipeline Architecture
    ///
    /// Pipeline 1 (Grabber):
    ///   RTSPRAWSourceBlock -> BufferSinkBlock -> OnDataFrame event
    ///   Captures raw H264 data from RTSP camera
    ///
    /// Pipeline 2 (Player):
    ///   H264PushSourceBlock -> H264ParseBlock -> H264DecoderBlock -> VideoRendererBlock
    ///   Receives H264 data via PushData(), parses, and decodes for display
    /// </summary>
    public partial class MainWindow : Window
    {
        // Pipeline 1: RTSP Grabber - captures raw H264 data
        private MediaBlocksPipeline _grabberPipeline;
        private RTSPRAWSourceBlock _rtspSource;
        private BufferSinkBlock _bufferSink;

        // Pipeline 2: H264 Player - decodes and renders
        private MediaBlocksPipeline _playerPipeline;
        private H264PushSourceBlock _h264Source;
        private H264ParseBlock _h264Parse;
        private H264DecoderBlock _h264Decoder;
        private VideoRendererBlock _videoRenderer;

        // Statistics
        private long _frameCount;
        private long _totalBytes;
        private DateTime _startTime;
        private DispatcherTimer _statsTimer;

        private bool _isRunning;

        // Signal for first frame received
        private TaskCompletionSource<bool> _firstFrameReceived;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded - initialize SDK.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
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

            // Setup statistics timer
            _statsTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            _statsTimer.Tick += StatsTimer_Tick;

            LogMessage("SDK initialized. Ready to connect.");
        }

        /// <summary>
        /// Update statistics display.
        /// </summary>
        private void StatsTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = DateTime.Now - _startTime;
            lbFrameCount.Text = _frameCount.ToString("N0");
            lbTotalBytes.Text = FormatBytes(_totalBytes);

            if (elapsed.TotalSeconds > 0)
            {
                lbFPS.Text = (_frameCount / elapsed.TotalSeconds).ToString("F1");
                lbBitrate.Text = $"{(_totalBytes * 8 / elapsed.TotalSeconds / 1000):F1} kbps";
            }
        }

        /// <summary>
        /// Format bytes to human readable string.
        /// </summary>
        private static string FormatBytes(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024):F1} MB";
            return $"{bytes / (1024.0 * 1024 * 1024):F2} GB";
        }

        /// <summary>
        /// Log message to the log panel.
        /// </summary>
        private void LogMessage(string message)
        {
            mmLog.Text += $"[{DateTime.Now:HH:mm:ss}] {message}\n";
            mmLog.ScrollToEnd();
        }

        /// <summary>
        /// Start button click - starts both pipelines.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            try
            {
                btStart.IsEnabled = false;
                lbStatus.Text = "Status: Connecting...";
                LogMessage("Starting pipelines...");

                await StartPipelinesAsync();

                _isRunning = true;
                btStop.IsEnabled = true;
                lbStatus.Text = "Status: Running";
                _statsTimer.Start();
                LogMessage("Both pipelines started successfully!");
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
                MessageBox.Show($"Failed to start: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                await CleanupAsync();
                btStart.IsEnabled = true;
                lbStatus.Text = "Status: Error";
            }
        }

        /// <summary>
        /// Stop button click - stops both pipelines.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRunning)
            {
                return;
            }

            btStop.IsEnabled = false;
            lbStatus.Text = "Status: Stopping...";
            _statsTimer.Stop();

            await CleanupAsync();

            _isRunning = false;
            btStart.IsEnabled = true;
            lbStatus.Text = "Status: Stopped";
            LogMessage("Pipelines stopped.");
        }

        /// <summary>
        /// Starts both pipelines - grabber and player.
        /// </summary>
        private async Task StartPipelinesAsync()
        {
            // Reset statistics
            _frameCount = 0;
            _totalBytes = 0;
            lbFrameCount.Text = "0";
            lbTotalBytes.Text = "0";
            lbFPS.Text = "0";
            lbBitrate.Text = "0 kbps";

            // Create RTSP RAW source settings
            var rtspSettings = await RTSPRAWSourceSettings.CreateAsync(
                new Uri(edURL.Text),
                edLogin.Text,
                edPassword.Password,
                audioEnabled: false);

            // Configure RTSP settings
            rtspSettings.Latency = 50;
            rtspSettings.AllowedProtocols = RTSPSourceProtocol.TCP;
            rtspSettings.DoRTCP = true;
            rtspSettings.WaitForKeyframe = true;

            // Get media info and validate codec
            var mediaInfo = rtspSettings.GetInfo();

            if (mediaInfo?.VideoStreams.Count > 0)
            {
                var video = mediaInfo.VideoStreams[0];
                var codec = video.Codec?.ToUpperInvariant() ?? "";
                LogMessage($"Stream: {video.Codec} {video.Width}x{video.Height} @ {video.FrameRate:F2} fps");

                if (!codec.Contains("H264") && !codec.Contains("H.264") && !codec.Contains("AVC"))
                {
                    throw new NotSupportedException(
                        $"This demo only supports H.264 streams. Detected codec: {video.Codec}. " +
                        "For H.265/HEVC streams, use H265DecoderBlock instead.");
                }
            }
            else
            {
                LogMessage("Warning: Could not detect stream codec. Assuming H.264.");
            }

            // ============================================
            // PIPELINE 2: Player Pipeline (create first)
            // ============================================
            _playerPipeline = new MediaBlocksPipeline();
            _playerPipeline.OnError += PlayerPipeline_OnError;

            _h264Source = new H264PushSourceBlock();
            _h264Parse = new H264ParseBlock();
            _h264Decoder = new H264DecoderBlock(new VisioForge.Core.Types.X.VideoDecoders.FFMPEGH264DecoderSettings());
            _videoRenderer = new VideoRendererBlock(_playerPipeline, VideoView1) { IsSync = true };

            // H264Source -> H264Parse -> H264Decoder -> Renderer
            _playerPipeline.Connect(_h264Source, _h264Parse);
            _playerPipeline.Connect(_h264Parse, _h264Decoder);
            _playerPipeline.Connect(_h264Decoder, _videoRenderer);

            // Preload player pipeline (Build() is called during preload)
            await _playerPipeline.StartAsync(onlyPreload: true);

            // =============================================
            // PIPELINE 1: Grabber Pipeline
            // =============================================
            _grabberPipeline = new MediaBlocksPipeline();
            _grabberPipeline.OnError += GrabberPipeline_OnError;

            _rtspSource = new RTSPRAWSourceBlock(rtspSettings);
            _grabberPipeline.AddBlock(_rtspSource);

            _bufferSink = new BufferSinkBlock
            {
                IsSync = false,
                AllowFrameDrop = false
            };
            _bufferSink.OnDataFrameBuffer += BufferSink_OnDataFrame;
            _grabberPipeline.AddBlock(_bufferSink);

            _grabberPipeline.Connect(_rtspSource.VideoOutput, _bufferSink.Input);

            // Start grabber pipeline - data will start flowing
            _firstFrameReceived = new TaskCompletionSource<bool>();
            _startTime = DateTime.Now;
            await _grabberPipeline.StartAsync();

            // Wait for first frame to arrive (with 5s timeout fallback)
            var timeoutTask = Task.Delay(5000);
            var completedTask = await Task.WhenAny(_firstFrameReceived.Task, timeoutTask);
            if (completedTask == timeoutTask)
            {
                LogMessage("WARNING: Timeout waiting for first frame, resuming anyway.");
            }

            // Resume player pipeline
            await _playerPipeline.ResumeAsync();
        }

        /// <summary>
        /// Handles raw H264 data frames from the grabber pipeline.
        /// </summary>
        private void BufferSink_OnDataFrame(object sender, DataFrameEventArgs e)
        {
            _frameCount++;
            _totalBytes += e.Frame.DataSize;

            // Signal first frame received
            _firstFrameReceived?.TrySetResult(true);

            // Copy raw H264 data and push to player pipeline
            var data = new byte[e.Frame.DataSize];
            Marshal.Copy(e.Frame.Data, data, 0, e.Frame.DataSize);

            _h264Source?.PushData(data, data.Length, e.Frame.Timestamp);
        }

        /// <summary>
        /// Cleanup both pipelines.
        /// </summary>
        private async Task CleanupAsync()
        {
            if (_grabberPipeline != null)
            {
                _grabberPipeline.OnError -= GrabberPipeline_OnError;
                await _grabberPipeline.StopAsync();
                await _grabberPipeline.DisposeAsync();
                _grabberPipeline = null;
            }

            if (_bufferSink != null)
            {
                _bufferSink.OnDataFrameBuffer -= BufferSink_OnDataFrame;
                _bufferSink.Dispose();
                _bufferSink = null;
            }

            _rtspSource?.Dispose();
            _rtspSource = null;

            if (_playerPipeline != null)
            {
                _h264Source?.SendEOS();
                _playerPipeline.OnError -= PlayerPipeline_OnError;
                await _playerPipeline.StopAsync();
                await _playerPipeline.DisposeAsync();
                _playerPipeline = null;
            }

            _videoRenderer?.Dispose();
            _videoRenderer = null;

            _h264Decoder?.Dispose();
            _h264Decoder = null;

            _h264Parse?.Dispose();
            _h264Parse = null;

            _h264Source?.Dispose();
            _h264Source = null;
        }

        /// <summary>
        /// Grabber pipeline error handler.
        /// </summary>
        private void GrabberPipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                LogMessage($"[Grabber Error] {e.Message}");
            });
        }

        /// <summary>
        /// Player pipeline error handler.
        /// </summary>
        private void PlayerPipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                LogMessage($"[Player Error] {e.Message}");
            });
        }

        /// <summary>
        /// Window closing - cleanup resources.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _statsTimer?.Stop();
            await CleanupAsync();
            VisioForgeX.DestroySDK();
        }
    }
}
