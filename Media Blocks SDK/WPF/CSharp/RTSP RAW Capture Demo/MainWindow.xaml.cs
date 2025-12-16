using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_RAW_Capture_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Preview pipeline (with decoding for display)
        private MediaBlocksPipeline _previewPipeline;
        private RTSPSourceBlock _previewSource;
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;

        // Recording pipeline (RAW - no video decoding, optional audio re-encoding)
        private MediaBlocksPipeline _recordPipeline;
        private RTSPRAWSourceBlock _recordSource;
        private DecodeBinBlock _decodeBin;
        private AACEncoderBlock _audioEncoder;
        private MediaBlock _muxer;

        private bool _isPreviewStarted = false;
        private bool _isRecordingStarted = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize SDK
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

            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            LogMessage("SDK initialized successfully.");
        }

        private void LogMessage(string message)
        {
            mmLog.Text += $"[{DateTime.Now:HH:mm:ss}] {message}\n";
            mmLog.ScrollToEnd();
        }

        private async void btStartPreview_Click(object sender, RoutedEventArgs e)
        {
            if (_isPreviewStarted)
            {
                LogMessage("Preview is already started.");
                return;
            }

            try
            {
                LogMessage("Starting preview...");

                // Create pipeline
                _previewPipeline = new MediaBlocksPipeline();
                _previewPipeline.OnError += Pipeline_OnError;

                // Create RTSP source with decoding for preview
                var rtspSettings = await RTSPSourceSettings.CreateAsync(
                    new Uri(edURL.Text),
                    edLogin.Text,
                    edPassword.Password,
                    cbAudioEnabled.IsChecked == true);

                _previewSource = new RTSPSourceBlock(rtspSettings);

                // Create video renderer for preview
                _videoRenderer = new VideoRendererBlock(_previewPipeline, VideoView1);
                _previewPipeline.Connect(_previewSource.VideoOutput, _videoRenderer.Input);

                // Create audio renderer if audio is enabled
                if (cbAudioEnabled.IsChecked == true)
                {
                    _audioRenderer = new AudioRendererBlock();
                    _previewPipeline.Connect(_previewSource.AudioOutput, _audioRenderer.Input);
                }

                // Start pipeline
                var result = await _previewPipeline.StartAsync();
                if (result)
                {
                    _isPreviewStarted = true;
                    lbStatus.Text = "Status: Preview Running";
                    LogMessage("Preview started successfully.");
                }
                else
                {
                    LogMessage("Failed to start preview.");
                    await CleanupPreviewAsync();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting preview: {ex.Message}");
                MessageBox.Show($"Failed to start preview: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                await CleanupPreviewAsync();
            }
        }

        private async void btStopPreview_Click(object sender, RoutedEventArgs e)
        {
            if (!_isPreviewStarted)
            {
                LogMessage("Preview is not running.");
                return;
            }

            LogMessage("Stopping preview...");
            await CleanupPreviewAsync();
            lbStatus.Text = "Status: Preview Stopped";
            LogMessage("Preview stopped.");
        }

        private async Task CleanupPreviewAsync()
        {
            if (_previewPipeline != null)
            {
                _previewPipeline.OnError -= Pipeline_OnError;
                await _previewPipeline.StopAsync();
                await _previewPipeline.DisposeAsync();
                _previewPipeline = null;
            }

            _videoRenderer?.Dispose();
            _videoRenderer = null;

            _audioRenderer?.Dispose();
            _audioRenderer = null;

            _previewSource?.Dispose();
            _previewSource = null;

            _isPreviewStarted = false;
        }

        private async void btStartRecord_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecordingStarted)
            {
                LogMessage("Recording is already started.");
                return;
            }

            try
            {
                LogMessage("Starting recording...");

                // Create pipeline
                _recordPipeline = new MediaBlocksPipeline();
                _recordPipeline.OnError += Pipeline_OnError;

                // Create RTSP RAW source (no video decoding)
                RTSPRAWSourceSettings rtspSettings;
                try
                {
                    rtspSettings = await RTSPRAWSourceSettings.CreateAsync(
                        new Uri(edURL.Text),
                        edLogin.Text,
                        edPassword.Password,
                        cbAudioEnabled.IsChecked == true);
                }
                catch (Exception ex)
                {
                    LogMessage($"Failed to connect to RTSP stream: {ex.Message}");
                    MessageBox.Show($"Failed to connect to RTSP stream: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    await CleanupRecordingAsync();
                    return;
                }

                _recordSource = new RTSPRAWSourceBlock(rtspSettings);

                // Create muxer based on output format
                bool isMP4 = rbMP4Output.IsChecked == true;
                if (isMP4)
                {
                    _muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));
                    LogMessage("Using MP4 muxer.");
                }
                else
                {
                    _muxer = new MPEGTSSinkBlock(new MPEGTSSinkSettings(edFilename.Text));
                    LogMessage("Using MPEG-TS muxer.");
                }

                // Connect video (no re-encoding, RAW)
                var inputVideoPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video);
                _recordPipeline.Connect(_recordSource.VideoOutput, inputVideoPad);
                LogMessage("Video connected (no re-encoding).");

                // Connect audio
                if (rtspSettings.AudioEnabled)
                {
                    var inputAudioPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio);

                    if (cbReencodeAudio.IsChecked == true)
                    {
                        // Re-encode audio to AAC
                        _decodeBin = new DecodeBinBlock(false, true, false)
                        {
                            DisableAudioConverter = true
                        };

                        _audioEncoder = new AACEncoderBlock(new AVENCAACEncoderSettings());

                        _recordPipeline.Connect(_recordSource.AudioOutput, _decodeBin.Input);
                        _recordPipeline.Connect(_decodeBin.AudioOutput, _audioEncoder.Input);
                        _recordPipeline.Connect(_audioEncoder.Output, inputAudioPad);
                        LogMessage("Audio connected (with AAC re-encoding).");
                    }
                    else
                    {
                        // No audio re-encoding
                        _recordPipeline.Connect(_recordSource.AudioOutput, inputAudioPad);
                        LogMessage("Audio connected (no re-encoding).");
                    }
                }

                // Start recording
                var result = await _recordPipeline.StartAsync();
                if (result)
                {
                    _isRecordingStarted = true;
                    lbStatus.Text = "Status: Recording";
                    LogMessage($"Recording started to: {edFilename.Text}");
                }
                else
                {
                    LogMessage("Failed to start recording.");
                    await CleanupRecordingAsync();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting recording: {ex.Message}");
                MessageBox.Show($"Failed to start recording: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                await CleanupRecordingAsync();
            }
        }

        private async void btStopRecord_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRecordingStarted)
            {
                LogMessage("Recording is not running.");
                return;
            }

            LogMessage("Stopping recording...");
            await CleanupRecordingAsync();
            lbStatus.Text = "Status: Recording Stopped";
            LogMessage("Recording stopped.");
        }

        private async Task CleanupRecordingAsync()
        {
            if (_recordPipeline != null)
            {
                _recordPipeline.OnError -= Pipeline_OnError;
                await _recordPipeline.StopAsync();
                await _recordPipeline.DisposeAsync();
                _recordPipeline = null;
            }

            (_muxer as IDisposable)?.Dispose();
            _muxer = null;

            _recordSource?.Dispose();
            _recordSource = null;

            _decodeBin?.Dispose();
            _decodeBin = null;

            _audioEncoder?.Dispose();
            _audioEncoder = null;

            _isRecordingStarted = false;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                LogMessage($"Pipeline error: {e.Message}");
            });
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            
            if (rbMP4Output.IsChecked == true)
            {
                saveFileDialog.Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = ".mp4";
            }
            else
            {
                saveFileDialog.Filter = "MPEG-TS files (*.ts)|*.ts|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = ".ts";
            }

            saveFileDialog.FileName = edFilename.Text;

            if (saveFileDialog.ShowDialog() == true)
            {
                edFilename.Text = saveFileDialog.FileName;
            }
        }

        private void lbVideoTutorial_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.visioforge.com/video-tutorials",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                LogMessage($"Failed to open video tutorial: {ex.Message}");
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Stop and cleanup preview
            await CleanupPreviewAsync();

            // Stop and cleanup recording
            await CleanupRecordingAsync();

            // Cleanup SDK
            VisioForgeX.DestroySDK();
        }
    }
}
