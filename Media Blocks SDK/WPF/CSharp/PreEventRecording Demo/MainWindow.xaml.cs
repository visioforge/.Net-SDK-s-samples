using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.PreEventRecording;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace PreEventRecordingDemoMBWPF
{
    public partial class MainWindow : Window, IDisposable
    {
        private bool _initialized;
        private bool _disposedValue;

        // Pipeline blocks
        private MediaBlocksPipeline _pipeline;
        private MediaBlock _videoSource;
        private MediaBlock _audioSource;
        private TeeBlock _videoTee;
        private TeeBlock _audioTee;
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private H264EncoderBlock _h264Encoder;
        private AACEncoderBlock _aacEncoder;
        private PreEventRecordingBlock _preEventBlock;
        private MotionDetectionBlock _motionDetector;
        private MotionDetectionBlockSettings _motionSettings;

        // Cached output folder for use from background threads
        private string _outputFolder;

        // Status timer
        private System.Timers.Timer _statusTimer;

        public ObservableCollection<string> VideoDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoFormats { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioDevices { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            // Wire control events
            cbVideoDevice.ItemsSource = VideoDevices;
            cbVideoDevice.SelectionChanged += CbVideoDevice_SelectionChanged;

            cbVideoFormat.ItemsSource = VideoFormats;

            cbAudioDevice.ItemsSource = AudioDevices;

            slPreEvent.ValueChanged += (s, e) =>
            {
                lbPreEvent.Text = ((int)slPreEvent.Value).ToString();
            };
            slPostEvent.ValueChanged += (s, e) =>
            {
                lbPostEvent.Text = ((int)slPostEvent.Value).ToString();
            };

            edOutputFolder.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                "PreEventRecording");

            btStart.Click += BtStart_Click;
            btStop.Click += BtStop_Click;
            btTrigger.Click += BtTrigger_Click;
            btStopRec.Click += BtStopRec_Click;
            btExtend.Click += BtExtend_Click;

            Loaded += MainWindow_Loaded;

            UpdateSourceTypeUI();

            DataContext = this;
        }

        private void RbSourceType_Changed(object sender, RoutedEventArgs e)
        {
            UpdateSourceTypeUI();
        }

        private void UpdateSourceTypeUI()
        {
            if (pnlCamera == null) return;

            bool isRtsp = rbRTSP.IsChecked == true;
            pnlCamera.Visibility = isRtsp ? Visibility.Collapsed : Visibility.Visible;
            pnlRTSP.Visibility = isRtsp ? Visibility.Visible : Visibility.Collapsed;
            pnlAudioDevice.Visibility = isRtsp ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    VideoDevices.Add(e.DisplayName);
                    if (cbVideoDevice.Items.Count == 1)
                    {
                        cbVideoDevice.SelectedIndex = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_initialized) return;
                _initialized = true;

                Closing += Window_Closing;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

                var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
                foreach (var device in audioInputs)
                {
                    AudioDevices.Add(device.DisplayName);
                }

                if (AudioDevices.Count > 0)
                {
                    cbAudioDevice.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void CbVideoDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoDevice.SelectedIndex != -1 && e?.AddedItems.Count > 0)
                {
                    VideoFormats.Clear();

                    var deviceItem = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                        .FirstOrDefault(d => d.DisplayName == e.AddedItems[0].ToString());
                    if (deviceItem == null) return;

                    foreach (var format in deviceItem.VideoFormats)
                    {
                        VideoFormats.Add(format.Name);
                    }

                    if (VideoFormats.Count > 0)
                    {
                        cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text += txt + Environment.NewLine;
                edLog.ScrollToEnd();
            });
        }

        private async void BtStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    Log("Pipeline is already running.");
                    return;
                }

                edLog.Text = string.Empty;

                // Audio enabled
                bool audioEnabled = cbRecordAudio.IsChecked == true;
                bool isRtsp = rbRTSP.IsChecked == true;

                // Validate inputs before creating pipeline
                if (isRtsp)
                {
                    if (string.IsNullOrEmpty(edRtspUrl.Text?.Trim()))
                    {
                        Log("Please enter an RTSP URL.");
                        return;
                    }
                }
                else
                {
                    if (cbVideoDevice.SelectedIndex < 0)
                    {
                        Log("Please select a video device.");
                        return;
                    }
                }

                // Ensure output folder exists
                var outputFolder = edOutputFolder.Text;
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                // Video source
                RTSPSourceBlock rtspSource = null;

                if (isRtsp)
                {
                    var url = edRtspUrl.Text?.Trim();

                    var rtspSettings = await RTSPSourceSettings.CreateAsync(
                        new Uri(url),
                        edRtspLogin.Text,
                        edRtspPassword.Password,
                        audioEnabled);

                    rtspSource = new RTSPSourceBlock(rtspSettings);
                    _videoSource = rtspSource;
                }
                else
                {
                    var deviceName = cbVideoDevice.SelectedItem.ToString();
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                        .FirstOrDefault(x => x.DisplayName == deviceName);

                    VideoCaptureDeviceSourceSettings videoSourceSettings = null;
                    if (device != null)
                    {
                        var formatName = cbVideoFormat.SelectedItem?.ToString();
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == formatName);
                        if (formatItem != null)
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                        }
                        else
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device);
                        }
                    }

                    _videoSource = new SystemVideoSourceBlock(videoSourceSettings);
                }

                // Motion detection (frame differencing, no OpenCV required)
                _motionSettings = new MotionDetectionBlockSettings
                {
                    MotionThreshold = 5,
                    CompareGreyscale = true,
                    GridWidth = 8,
                    GridHeight = 8
                };
                _motionDetector = new MotionDetectionBlock(_motionSettings);
                _motionDetector.OnMotionDetected += OnMotionDetected;

                // Video tee: preview + encoder
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                // Video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // H264 encoder
                _h264Encoder = new H264EncoderBlock();

                // Pre-event recording block
                var preEventSettings = new PreEventRecordingSettings
                {
                    PreEventDuration = TimeSpan.FromSeconds((int)slPreEvent.Value),
                    PostEventDuration = TimeSpan.FromSeconds((int)slPostEvent.Value)
                };
                _preEventBlock = new PreEventRecordingBlock(preEventSettings, "mp4mux");
                _preEventBlock.AudioEnabled = audioEnabled;

                _preEventBlock.OnRecordingStarted += (s, args) =>
                {
                    Log($"Recording started: {args.Filename}");
                    Dispatcher.Invoke(() =>
                    {
                        lbRecFile.Text = $"File: {args.Filename}";
                    });
                };

                _preEventBlock.OnRecordingStopped += (s, args) =>
                {
                    Log($"Recording stopped: {args.Filename}");
                };

                _preEventBlock.OnStateChanged += (s, args) =>
                {
                    Log($"State changed: {args.State}");
                };

                _outputFolder = outputFolder;

                // Connect video: source -> motionDetector -> tee -> [renderer, encoder -> preEvent]
                _pipeline.Connect(_videoSource, _motionDetector);
                _pipeline.Connect(_motionDetector, _videoTee);
                _pipeline.Connect(_videoTee, _videoRenderer);
                _pipeline.Connect(_videoTee, _h264Encoder);
                _pipeline.Connect(_h264Encoder.Output, _preEventBlock.VideoInput);

                // Audio path
                if (audioEnabled)
                {
                    _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                    _audioRenderer = new AudioRendererBlock();
                    _aacEncoder = new AACEncoderBlock();

                    if (isRtsp)
                    {
                        // Audio comes from RTSP source
                        _pipeline.Connect(rtspSource.AudioOutput, _audioTee.Input);
                    }
                    else if (cbAudioDevice.SelectedIndex >= 0)
                    {
                        var audioDeviceName = cbAudioDevice.SelectedItem.ToString();
                        var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync())
                            .FirstOrDefault(x => x.DisplayName == audioDeviceName);

                        if (audioDevice != null)
                        {
                            var audioSourceSettings = audioDevice.CreateSourceSettings(null);
                            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
                            _pipeline.Connect(_audioSource, _audioTee);
                        }
                    }

                    _pipeline.Connect(_audioTee, _audioRenderer);
                    _pipeline.Connect(_audioTee, _aacEncoder);
                    _pipeline.Connect(_aacEncoder.Output, _preEventBlock.AudioInput);
                }

                await _pipeline.StartAsync();

                // Start status timer
                _statusTimer = new System.Timers.Timer(500);
                _statusTimer.Elapsed += (s, args) => UpdateStatus();
                _statusTimer.Start();

                Log("Pipeline started. Buffering...");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log($"[Error] {e.Message}");
        }

        private void UpdateStatus()
        {
            if (_preEventBlock == null) return;

            var state = _preEventBlock.State;
            var totalBytes = _preEventBlock.BufferTotalBytes;
            var duration = _preEventBlock.BufferedDuration;

            Dispatcher.Invoke(() =>
            {
                lbState.Text = $"State: {state}";
                lbBufferStats.Text = $"Buffer: {totalBytes / 1024.0:F1} KB, {duration.TotalSeconds:F1}s";
            });
        }

        private void OnMotionDetected(object sender, MotionDetectionEventArgs e)
        {
            if (_preEventBlock == null)
            {
                return;
            }

            bool isMotion = e.Level >= _motionSettings.MotionThreshold;

            Dispatcher.BeginInvoke(() =>
            {
                lbMotion.Text = isMotion ? $"Motion: detected ({e.Level})" : $"Motion: idle ({e.Level})";
            });

            if (!isMotion || cbMotionTrigger.Dispatcher.Invoke(() => cbMotionTrigger.IsChecked != true))
            {
                return;
            }

            var state = _preEventBlock.State;
            if (state == PreEventRecordingState.Buffering)
            {
                var filename = Path.Combine(_outputFolder,
                    $"motion_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");
                _preEventBlock.TriggerRecording(filename);
                Log($"Motion triggered recording: {filename}");
            }
            else if (state == PreEventRecordingState.Recording ||
                     state == PreEventRecordingState.PostEventRecording)
            {
                _preEventBlock.ExtendRecording();
            }
        }

        private void BtTrigger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_preEventBlock == null)
                {
                    Log("Pipeline not running.");
                    return;
                }

                var outputFolder = edOutputFolder.Text;
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                var filename = Path.Combine(outputFolder,
                    $"event_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");

                _preEventBlock.TriggerRecording(filename);
                Log($"Trigger recording: {filename}");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private void BtStopRec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_preEventBlock == null) return;
                _preEventBlock.StopRecording();
                Log("Recording stopped manually.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private void BtExtend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_preEventBlock == null) return;
                _preEventBlock.ExtendRecording();
                Log("Post-event timer extended.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private async void BtStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _statusTimer?.Stop();
                _statusTimer?.Dispose();
                _statusTimer = null;

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                if (_motionDetector != null)
                {
                    _motionDetector.OnMotionDetected -= OnMotionDetected;
                    _motionDetector = null;
                }

                _preEventBlock = null;
                _videoSource = null;
                _videoTee = null;
                _audioTee = null;
                _videoRenderer = null;
                _audioRenderer = null;
                _h264Encoder = null;
                _aacEncoder = null;
                _audioSource = null;

                lbState.Text = "State: Idle";
                lbBufferStats.Text = "Buffer: 0 KB, 0.0s";
                lbRecFile.Text = "File: —";
                lbMotion.Text = "Motion: —";

                Log("Pipeline stopped.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DeviceEnumerator.Shared.OnVideoSourceAdded -= DeviceEnumerator_OnVideoSourceAdded;

            _statusTimer?.Stop();
            _statusTimer?.Dispose();

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _statusTimer?.Dispose();
                    _statusTimer = null;

                    if (_pipeline != null)
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        _pipeline.Dispose();
                        _pipeline = null;
                    }

                    VideoView1?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
