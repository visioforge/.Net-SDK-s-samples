using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoProcessing;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.PreEventRecording;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.UI;
using VisioForge.Core.UI.Avalonia;
using VisioForge.Core.VideoCaptureX;

namespace PreEventRecordingDemoVCXA
{
    public partial class MainWindow : Window, IDisposable
    {
        private bool _initialized;
        private bool _disposedValue;

        private VideoCaptureCoreX VideoCapture1;

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
#if DEBUG
            this.AttachDevTools();
#endif

            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            // Wire control events
            cbVideoDevice.ItemsSource = VideoDevices;
            cbVideoDevice.SelectionChanged += CbVideoDevice_SelectionChanged;

            cbVideoFormat.ItemsSource = VideoFormats;

            cbAudioDevice.ItemsSource = AudioDevices;

            slPreEvent.PropertyChanged += (s, e) =>
            {
                if (e.Property.Name == "Value")
                    lbPreEvent.Text = ((int)slPreEvent.Value).ToString();
            };
            slPostEvent.PropertyChanged += (s, e) =>
            {
                if (e.Property.Name == "Value")
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

            Activated += MainWindow_Activated;

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
            pnlCamera.IsVisible = !isRtsp;
            pnlRTSP.IsVisible = isRtsp;
            pnlAudioDevice.IsVisible = !isRtsp;
        }

        private async void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    VideoDevices.Add(e.DisplayName);
                    if (cbVideoDevice.ItemCount == 1)
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

        private async void MainWindow_Activated(object sender, EventArgs e)
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
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                edLog.Text += txt + Environment.NewLine;
            });
        }

        private async void BtStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VideoCapture1 != null)
                {
                    Log("Capture is already running.");
                    return;
                }

                edLog.Text = string.Empty;

                bool isRtsp = rbRTSP.IsChecked == true;

                // Validate inputs before creating capture
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

                _outputFolder = outputFolder;

                VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);
                VideoCapture1.OnError += VideoCapture1_OnError;

                // Video source
                if (isRtsp)
                {
                    var url = edRtspUrl.Text?.Trim();
                    bool audioEnabled = cbRecordAudio.IsChecked == true;
                    var rtspSettings = await RTSPSourceSettings.CreateAsync(
                        new Uri(url),
                        edRtspLogin.Text,
                        edRtspPassword.Text,
                        audioEnabled);

                    VideoCapture1.Video_Source = rtspSettings;
                    VideoCapture1.Audio_Record = audioEnabled;
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

                    VideoCapture1.Video_Source = videoSourceSettings;

                    // Audio source (local device)
                    bool audioEnabled = cbRecordAudio.IsChecked == true;
                    if (audioEnabled && cbAudioDevice.SelectedIndex >= 0)
                    {
                        var audioDeviceName = cbAudioDevice.SelectedItem.ToString();
                        var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync())
                            .FirstOrDefault(x => x.DisplayName == audioDeviceName);

                        if (audioDevice != null)
                        {
                            var audioSourceSettings = audioDevice.CreateSourceSettingsVC(null);
                            VideoCapture1.Audio_Source = audioSourceSettings;
                            VideoCapture1.Audio_Record = true;
                        }
                    }
                }

                // Motion detection
                VideoCapture1.Motion_Detection = new MotionDetectionExSettings
                {
                    ProcessorType = MotionProcessorType.None,
                    DetectorType = MotionDetectorType.TwoFramesDifference,
                    DifferenceThreshold = 15,
                    SuppressNoise = true
                };
                VideoCapture1.OnMotionDetection += VideoCapture1_OnMotionDetection;

                // Pre-event recording output
                var preEventSettings = new PreEventRecordingSettings
                {
                    PreEventDuration = TimeSpan.FromSeconds((int)slPreEvent.Value),
                    PostEventDuration = TimeSpan.FromSeconds((int)slPostEvent.Value)
                };

                var preEventOutput = new PreEventRecordingOutput(
                    settings: preEventSettings,
                    videoEnc: new OpenH264EncoderSettings(),
                    audioEnc: new VOAACEncoderSettings()
                );

                VideoCapture1.Outputs_Add(preEventOutput);

                // Wire events
                VideoCapture1.OnPreEventRecordingStarted += (s, args) =>
                {
                    Log($"Recording started: {args.Filename}");
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        lbRecFile.Text = $"File: {args.Filename}";
                    });
                };

                VideoCapture1.OnPreEventRecordingStopped += (s, args) =>
                {
                    Log($"Recording stopped: {args.Filename}");
                };

                await VideoCapture1.StartAsync();

                // Start status timer
                _statusTimer = new System.Timers.Timer(500);
                _statusTimer.Elapsed += (s, args) => UpdateStatus();
                _statusTimer.Start();

                Log("Started. Buffering...");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log($"[Error] {e.Message}");
        }

        private void VideoCapture1_OnMotionDetection(object sender, MotionDetectionExEventArgs e)
        {
            if (VideoCapture1 == null) return;

            bool isMotion = e.LevelPercent >= 5;

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                lbMotion.Text = isMotion ? $"Motion: detected ({e.LevelPercent}%)" : $"Motion: idle ({e.LevelPercent}%)";
            });

            if (!isMotion)
            {
                return;
            }

            bool motionTriggerEnabled = false;
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                motionTriggerEnabled = cbMotionTrigger.IsChecked == true;
            }).GetAwaiter().GetResult();

            if (!motionTriggerEnabled)
            {
                return;
            }

            var state = VideoCapture1.GetPreEventRecordingState(0);
            if (state == PreEventRecordingState.Buffering)
            {
                var filename = Path.Combine(_outputFolder,
                    $"motion_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");
                VideoCapture1.TriggerPreEventRecording(0, filename);
                Log($"Motion triggered recording: {filename}");
            }
            else if (state == PreEventRecordingState.Recording ||
                     state == PreEventRecordingState.PostEventRecording)
            {
                VideoCapture1.ExtendPreEventRecording(0);
            }
        }

        private void UpdateStatus()
        {
            if (VideoCapture1 == null) return;

            try
            {
                var state = VideoCapture1.GetPreEventRecordingState(0);

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    lbState.Text = $"State: {state}";
                });
            }
            catch
            {
                // Ignore status errors
            }
        }

        private void BtTrigger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VideoCapture1 == null)
                {
                    Log("Not running.");
                    return;
                }

                var outputFolder = edOutputFolder.Text;
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                var filename = Path.Combine(outputFolder,
                    $"event_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");

                VideoCapture1.TriggerPreEventRecording(0, filename);
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
                if (VideoCapture1 == null) return;
                VideoCapture1.StopPreEventRecording(0);
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
                if (VideoCapture1 == null) return;
                VideoCapture1.ExtendPreEventRecording(0);
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

                if (VideoCapture1 != null)
                {
                    VideoCapture1.OnMotionDetection -= VideoCapture1_OnMotionDetection;
                    await VideoCapture1.StopAsync();
                    VideoCapture1.OnError -= VideoCapture1_OnError;
                    await VideoCapture1.DisposeAsync();
                    VideoCapture1 = null;
                }

                lbState.Text = "State: Idle";
                lbRecFile.Text = "File: —";
                lbMotion.Text = "Motion: —";

                Log("Stopped.");
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

            if (VideoCapture1 != null)
            {
                VideoCapture1.OnMotionDetection -= VideoCapture1_OnMotionDetection;
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.DisposeAsync().GetAwaiter().GetResult();
                VideoCapture1 = null;
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

                    if (VideoCapture1 != null)
                    {
                        VideoCapture1.OnMotionDetection -= VideoCapture1_OnMotionDetection;
                        VideoCapture1.OnError -= VideoCapture1_OnError;
                        VideoCapture1.DisposeAsync().GetAwaiter().GetResult();
                        VideoCapture1 = null;
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
