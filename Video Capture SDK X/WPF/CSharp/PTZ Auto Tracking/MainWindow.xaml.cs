using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.AI.PTZ;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.ONVIFX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoProcessing;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

using Size = System.Drawing.Size;

namespace PTZ_Auto_Tracking
{
    /// <summary>
    /// Follows a detected object with an ONVIF PTZ camera: an RTSP preview runs through ObjectAnalyticsBlock
    /// (detection + tracking overlays), and PTZAutoTrackingController converts the tracked box position into
    /// continuous pan/tilt/zoom commands sent to the camera over ONVIF.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;
        private ObjectAnalyticsBlock _analytics;
        private ONVIFClientX _onvif;
        private PTZAutoTrackingController _controller;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Cancels the in-flight model download when the window is closing.
        private CancellationTokenSource _downloadCts;

        // Models are hosted on the samples GitHub release and cached under %USERPROFILE%/VisioForge/models.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private sealed class ModelPreset
        {
            public string Name;
            public string Tag;
            public ObjectDetectorModel Family;
            public string DownloadUrl;
            public string FileName;
            public bool IsLocal;
            public string LocalPath;
        }

        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();
            AddDownloadable(list, "YOLOX Nano", "yolox", "yolox_nano.onnx", ObjectDetectorModel.YOLOX);
            AddDownloadable(list, "RT-DETR R18vd", "rtdetr", "rtdetr_r18vd_fp16.onnx", ObjectDetectorModel.RTDETR);
            list.Add(new ModelPreset { Name = "Custom model...", Tag = "custom", Family = ObjectDetectorModel.YOLOX });
            return list;
        }

        private void AddDownloadable(List<ModelPreset> list, string name, string tag, string fileName, ObjectDetectorModel family)
        {
            var cachePath = Path.Combine(ModelsCacheDir, fileName);
            var isCached = File.Exists(cachePath);
            list.Add(new ModelPreset
            {
                Name = name,
                Tag = tag,
                Family = family,
                DownloadUrl = ModelsReleaseUrl + "/" + fileName,
                FileName = fileName,
                IsLocal = isCached,
                LocalPath = isCached ? cachePath : null,
            });
        }

        private void RefreshModelList()
        {
            var selTag = _selectedPreset?.Tag;
            _modelPresets = BuildModelList();
            cbModel.Items.Clear();
            var selIdx = 0;
            for (var i = 0; i < _modelPresets.Count; i++)
            {
                cbModel.Items.Add(new ComboBoxItem { Content = _modelPresets[i].Name, Tag = _modelPresets[i].Tag });
                if (_modelPresets[i].Tag == selTag)
                {
                    selIdx = i;
                }
            }

            cbModel.SelectedIndex = selIdx;
        }

        private ModelPreset GetSelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "yolox";
            return _modelPresets.Find(p => p.Tag == tag) ?? _modelPresets[0];
        }

        private ObjectDetectorModel SelectedModelFamily() => _selectedPreset?.Family ?? ObjectDetectorModel.YOLOX;

        // Reads the "Min confidence %" field (0-100) as a 0..1 detector threshold; defaults to 0.4 on a bad value.
        private float ReadConfidenceThreshold()
        {
            if (float.TryParse(edConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var percent))
            {
                return Math.Max(0f, Math.Min(1f, percent / 100f));
            }

            return 0.4f;
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized || cbModel.SelectedItem == null || _modelPresets == null)
            {
                return;
            }

            _selectedPreset = GetSelectedPreset();
            var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
            var isCustom = _selectedPreset.Tag == "custom";
            btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
            btSelectModel.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
            edModel.Text = _selectedPreset.IsLocal && _selectedPreset.LocalPath != null ? _selectedPreset.LocalPath : string.Empty;
        }

        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            // Snapshot the selection: the user can change the model combo (updating _selectedPreset on the UI
            // thread) while this download runs, which would otherwise mix one preset's URL with another's filename.
            var preset = _selectedPreset;
            if (preset?.DownloadUrl == null)
            {
                return;
            }

            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, preset.FileName);
            var tempPath = destPath + ".part";

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            Log($"Downloading {preset.Name}...");

            // Cancellable so closing the window aborts the HTTP request and file writes instead of leaking them.
            _downloadCts?.Dispose();
            _downloadCts = new CancellationTokenSource();
            var token = _downloadCts.Token;

            try
            {
                // Stream to a .part temp off the UI thread, then move into place so a failed download leaves no corrupt cache.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(preset.DownloadUrl, HttpCompletionOption.ResponseHeadersRead, token))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;

                        using (var source = await response.Content.ReadAsStreamAsync(token))
                        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int read;
                            while ((read = await source.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read, token);
                                readTotal += read;
                            }

                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    if (File.Exists(destPath)) { File.Delete(destPath); }
                    File.Move(tempPath, destPath);
                }, token);

                // The window may have been closed while the download ran; don't touch disposed controls.
                if (_isClosing)
                {
                    return;
                }

                edModel.Text = destPath;
                Log($"Saved to {ModelsCacheDir} ({new FileInfo(destPath).Length / 1024 / 1024} MB).");
                RefreshModelList();
            }
            catch (OperationCanceledException)
            {
                // Cancelled by the window closing; discard the partial file quietly.
                TryDeleteTemp(tempPath);
            }
            catch (Exception ex)
            {
                TryDeleteTemp(tempPath);
                if (_isClosing)
                {
                    return;
                }

                Log("download failed: " + ex.Message);
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {preset.DownloadUrl}", "Download error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (!_isClosing)
                {
                    btDownloadModel.IsEnabled = true;
                    btDownloadModel.Content = "Download";
                }
            }
        }

        private static void TryDeleteTemp(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); }
            catch { /* best-effort cleanup */ }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // Analytics/PTZ callbacks fire on background threads; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private void SetStatus(string text)
        {
            if (_isClosing)
            {
                return;
            }

            _ = Dispatcher.BeginInvoke(new Action(() => txtStatus.Text = text));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                cbTarget.Items.Add("Largest object");
                cbTarget.Items.Add("person");
                cbTarget.Items.Add("car");
                cbTarget.Items.Add("dog");
                cbTarget.SelectedIndex = 1;

                RefreshModelList();

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
                Log("Connect an ONVIF PTZ camera, pick a model, then press Start.");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edModel.Text = dialog.FileName;
            }
        }

        // Builds the tracking settings from the target combo (largest object, or a specific class label).
        private PTZAutoTrackingSettings BuildTrackingSettings()
        {
            var settings = new PTZAutoTrackingSettings
            {
                MaxSpeed = 0.5f,
                Gain = 1.2f,
                DeadZone = 0.12f,
            };

            var target = cbTarget.SelectedItem as string;
            if (!string.IsNullOrEmpty(target) && target != "Largest object")
            {
                settings.TargetSelection = PTZTargetSelection.ByClassLabel;
                settings.ClassLabelFilter = target;
            }
            else
            {
                settings.TargetSelection = PTZTargetSelection.Largest;
            }

            // Optional idle patrol: cycle the given ONVIF preset tokens when no target reappears.
            if (chkPatrol.IsChecked == true)
            {
                var tokens = ParsePatrolPresets(edPatrolPresets.Text);
                if (tokens.Length > 0)
                {
                    settings.PatrolPresetTokens = tokens;
                }
            }

            return settings;
        }

        // Splits the comma-separated patrol preset field into trimmed, non-empty tokens.
        private static string[] ParsePatrolPresets(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return Array.Empty<string>();
            }

            var parts = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<string>(parts.Length);
            foreach (var part in parts)
            {
                var token = part.Trim();
                if (token.Length > 0)
                {
                    list.Add(token);
                }
            }

            return list.ToArray();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edRtspUrl.Text))
            {
                MessageBox.Show(this, "Enter the RTSP camera URL.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edModel.Text))
            {
                MessageBox.Show(this, "Pick a model and press Download (or choose Custom and browse).");
                return;
            }

            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            // Lock the tracking toggle during startup so it cannot desync with the controller mid-transition.
            chkTracking.IsEnabled = false;
            try
            {
                btStart.IsEnabled = false;
                mmLog.Clear();

                // Build the RTSP source and read its resolution (needed to normalize detection boxes for tracking).
                var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(edRtspUrl.Text), edUser.Text, edPassword.Text, audioEnabled: false);
                var videoInfo = rtsp.GetInfo()?.GetVideoInfo();
                if (videoInfo == null || videoInfo.Width <= 0 || videoInfo.Height <= 0)
                {
                    MessageBox.Show(this, "Could not read the camera video resolution.");
                    btStart.IsEnabled = true;
                    return;
                }

                var frameSize = new Size(videoInfo.Width, videoInfo.Height);
                Log($"Camera resolution: {frameSize.Width}x{frameSize.Height}");

                _core = new VideoCaptureCoreX(VideoView1);
                _core.OnError += Core_OnError;
                _core.OnStop += Core_OnStop;
                _core.Video_Source = rtsp;
                _core.Audio_Play = false;

                // Detection + tracking with overlays drawn into the preview.
                var detectorSettings = new YoloDetectorSettings(edModel.Text)
                {
                    Model = SelectedModelFamily(),
                    ConfidenceThreshold = ReadConfidenceThreshold(),
                    DrawDetections = true,
                };
                var analyticsSettings = new ObjectAnalyticsSettings(detectorSettings);

                _analytics = new ObjectAnalyticsBlock(analyticsSettings);
                _core.Video_Processing_AddBlock(_analytics);

                // Connect ONVIF PTZ and wire the auto-tracking controller.
                await ConnectPtzAsync(frameSize);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
            }
            finally
            {
                // Enable only when it is actionable: pipeline stopped (set preference before start) or a PTZ
                // controller is active. A running pipeline without PTZ leaves the checkbox disabled.
                chkTracking.IsEnabled = _core == null || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        // Connects to the ONVIF device and, when PTZ is supported, attaches the controller to the analytics block.
        private async Task ConnectPtzAsync(Size frameSize)
        {
            try
            {
                _onvif = new ONVIFClientX();
                var connected = await _onvif.ConnectAsync(edOnvifUrl.Text, edUser.Text, edPassword.Text);
                if (!connected)
                {
                    Log("ONVIF: could not connect — running preview without PTZ.");
                    return;
                }

                // Robust PTZ probe: IsPTZSupported() reads only the cached ONVIF service list, which some
                // cameras (e.g. Dahua) leave empty after connect; IsPTZSupportedAsync falls back to a
                // media-profile PTZConfiguration probe.
                if (!await OnvifPTZMoveTransport.IsPTZSupportedAsync(_onvif))
                {
                    Log("ONVIF: device does not support PTZ — running preview without PTZ.");
                    return;
                }

                var transport = await OnvifPTZMoveTransport.CreateAsync(_onvif);
                if (transport == null)
                {
                    Log("ONVIF: no media profile available — running preview without PTZ.");
                    return;
                }

                _controller = new PTZAutoTrackingController(BuildTrackingSettings(), transport);
                _controller.OnTargetAcquired += (s, d) => Log($"Target acquired: {d.Label} #{d.TrackerId}");
                _controller.OnTargetLost += (s, ev) => Log("Target lost.");
                _controller.OnMoveCommand += Controller_OnMoveCommand;
                _controller.OnPatrolPreset += (s, token) => SetStatus($"Patrol: preset {token}");
                _controller.AttachTo(_analytics, frameSize);

                if (chkTracking.IsChecked == true)
                {
                    _controller.Start();
                    Log("PTZ auto-tracking enabled.");
                }
                else
                {
                    Log("PTZ connected; tracking is currently disabled.");
                }
            }
            catch (Exception ex)
            {
                Log("ONVIF error: " + ex.Message);
            }
        }

        private void Controller_OnMoveCommand(object sender, PTZMoveCommandEventArgs e)
        {
            SetStatus(e.IsStop
                ? "PTZ: stop"
                : $"PTZ: pan={e.Pan:+0.00;-0.00} tilt={e.Tilt:+0.00;-0.00} zoom={e.Zoom:+0.00;-0.00}");
        }

        private async void chkTracking_Changed(object sender, RoutedEventArgs e)
        {
            // Serialize with START/STOP: a fire-and-forget StopAsync here could overlap a Start()/Stop() that
            // disposes _controller/_onvif while the trailing ONVIF call is still using them.
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            // Lock the checkbox during the transition so it cannot be toggled again mid-flight (which the busy
            // guard would swallow, leaving the visual state out of sync with the controller).
            chkTracking.IsEnabled = false;
            try
            {
                if (_controller == null)
                {
                    return;
                }

                if (chkTracking.IsChecked == true)
                {
                    _controller.Start();
                    Log("PTZ auto-tracking enabled.");
                }
                else
                {
                    await _controller.StopAsync(); // halts the camera and drains the worker
                    Log("PTZ auto-tracking disabled.");
                    SetStatus("Idle");
                }
            }
            finally
            {
                // Enable only when it is actionable: pipeline stopped (set preference before start) or a PTZ
                // controller is active. A running pipeline without PTZ leaves the checkbox disabled.
                chkTracking.IsEnabled = _core == null || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            btStop.IsEnabled = false;

            // Lock the tracking toggle during teardown so it cannot desync with the controller mid-transition.
            chkTracking.IsEnabled = false;
            try
            {
                await CleanupAfterStopAsync();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }
            finally
            {
                // Enable only when it is actionable: pipeline stopped (set preference before start) or a PTZ
                // controller is active. A running pipeline without PTZ leaves the checkbox disabled.
                chkTracking.IsEnabled = _core == null || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }

            btStart.IsEnabled = true;
            SetStatus("Idle");
        }

        private async Task CleanupAfterStopAsync()
        {
            if (_controller != null)
            {
                await _controller.StopAsync();
                _controller.Dispose();
                _controller = null;
            }

            if (_onvif != null)
            {
                _onvif.Dispose();
                _onvif = null;
            }

            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                await _core.StopAsync();
                await _core.DisposeAsync();
                _core = null;
            }

            // The engine owns and disposes the inserted block; drop our reference.
            _analytics = null;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            // Abort any in-flight model download so its HTTP request / file writes don't outlive the window.
            _downloadCts?.Cancel();

            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                await CleanupAfterStopAsync();
                _downloadCts?.Dispose();
                _downloadCts = null;
                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
