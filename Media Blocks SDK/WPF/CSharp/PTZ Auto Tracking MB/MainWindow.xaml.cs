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
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.ONVIFX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

using Size = System.Drawing.Size;

namespace PTZ_Auto_Tracking_MB
{
    /// <summary>
    /// Follows a detected object with an ONVIF PTZ camera using the low-level Media Blocks pipeline:
    /// an RTSP source runs through ObjectAnalyticsBlock (detection + tracking overlays) into a VideoRendererBlock,
    /// and PTZAutoTrackingController turns the tracked box position into continuous pan/tilt/zoom commands
    /// sent to the camera over ONVIF. The controller is engine-agnostic — it attaches to the same analytics
    /// block whether the pipeline is built by hand (here) or by VideoCaptureCoreX.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private RTSPSourceBlock _source;
        private ObjectAnalyticsBlock _analytics;
        private VideoRendererBlock _videoRenderer;
        private ONVIFClientX _onvif;
        private PTZAutoTrackingController _controller;
        private bool _isClosing;
        private bool _readyToClose;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Cancels the in-flight model download when the window is closing.
        private CancellationTokenSource _downloadCts;

        // Models are hosted on the samples GitHub release and cached under %USERPROFILE%/VisioForge/models.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2), // honour DNS changes despite the static client
        })
        {
            Timeout = TimeSpan.FromMinutes(5),
        };

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
            // Accept both '.' and ',' decimal separators: try invariant first, then the user's current culture,
            // so a comma-decimal locale (e.g. "40,5") isn't silently rejected down to the default.
            if (float.TryParse(edConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var percent) ||
                float.TryParse(edConfidence.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out percent))
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

            // Cancel any in-flight download for the previously selected model so its completion can't
            // update the UI for the wrong model or leave this button disabled. Only cancel — the owning
            // download task disposes its own CTS in its finally, so we never dispose one whose token a
            // background read/write might still be touching.
            if (_downloadCts != null)
            {
                _downloadCts.Cancel();
                _downloadCts = null;
            }

            _selectedPreset = GetSelectedPreset();
            var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
            var isCustom = _selectedPreset.Tag == "custom";
            btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
            btDownloadModel.IsEnabled = true;
            btDownloadModel.Content = "Download";
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

            var destPath = Path.Combine(ModelsCacheDir, preset.FileName);
            // Unique per-download temp name: a cancelled download's background task may still hold its .part
            // (FileShare.None) when the user re-downloads the same model, which a fixed name would collide on.
            var tempPath = destPath + "." + Guid.NewGuid().ToString("N") + ".part";

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            Log($"Downloading {preset.Name}...");

            // Cancellable so closing the window (or switching model) aborts the HTTP request and file writes.
            // Only cancel the prior CTS here; its owning task disposes it in its finally (disposing it now,
            // while a background read/write may still touch its token, would risk an ObjectDisposedException).
            var cts = new CancellationTokenSource();
            _downloadCts?.Cancel();
            _downloadCts = cts;
            var token = cts.Token;

            try
            {
                // Inside the try so a failed directory creation (permissions / invalid path) is logged, not fatal.
                Directory.CreateDirectory(ModelsCacheDir);

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

                    // overwrite:true is more robust on Windows than Delete+Move (no pending-deletion race).
                    File.Move(tempPath, destPath, overwrite: true);
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
                // A cancelled download (window closing, or the model switched — which disposes the CTS) can
                // surface as ObjectDisposedException here, not OperationCanceledException; treat it as expected.
                if (_isClosing || token.IsCancellationRequested)
                {
                    return;
                }

                Log("download failed: " + ex.Message);
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {preset.DownloadUrl}", "Download error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                // Only the current download owns/resets state — an obsolete/cancelled one must not clobber a
                // newer download that replaced _downloadCts.
                if (_downloadCts == cts)
                {
                    // Clear the shared ref before disposing so no canceller touches a disposed CTS.
                    _downloadCts = null;
                    if (!_isClosing)
                    {
                        btDownloadModel.IsEnabled = true;
                        btDownloadModel.Content = "Download";
                    }
                }

                // The task owns this CTS; safe to dispose now that the task (and all token use) has completed.
                cts.Dispose();
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
            _ = Dispatcher.InvokeAsync(() => mmLog.AppendText(text + Environment.NewLine));
        }

        private void SetStatus(string text)
        {
            if (_isClosing)
            {
                return;
            }

            _ = Dispatcher.InvokeAsync(() => txtStatus.Text = text);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                cbTarget.Items.Add("Largest object");
                cbTarget.Items.Add("person");
                cbTarget.Items.Add("car");
                cbTarget.Items.Add("dog");
                cbTarget.SelectedIndex = 1;

                RefreshModelList();

                Log($"SDK v{MediaBlocksPipeline.SDK_Version} ready.");
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

            return text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
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

            if (_pipeline == null)
            {
                MessageBox.Show(this, "SDK failed to initialize.");
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

                // Tear down any previous run's blocks before building a fresh graph on the reused pipeline.
                await _pipeline.StopAsync();
                _pipeline.ClearBlocks();
                await CleanupControllerAndOnvifAsync();
                CleanupBlocks();

                // Validate the URL up front so a malformed entry gives a clear message instead of a UriFormatException.
                if (!Uri.TryCreate(edRtspUrl.Text, UriKind.Absolute, out var rtspUri))
                {
                    MessageBox.Show(this, "Invalid RTSP camera URL format.");
                    btStart.IsEnabled = true;
                    return;
                }

                // Build the RTSP source and read its resolution (needed to normalize detection boxes for tracking).
                var rtsp = await RTSPSourceSettings.CreateAsync(rtspUri, edUser.Text, edPassword.Text, audioEnabled: false);
                if (_isClosing)
                {
                    return; // window closed during the probe — Window_Closing handles teardown
                }

                var videoInfo = rtsp.GetInfo()?.GetVideoInfo();
                if (videoInfo == null || videoInfo.Width <= 0 || videoInfo.Height <= 0)
                {
                    MessageBox.Show(this, "Could not read the camera video resolution.");
                    btStart.IsEnabled = true;
                    return;
                }

                var frameSize = new Size(videoInfo.Width, videoInfo.Height);
                Log($"Camera resolution: {frameSize.Width}x{frameSize.Height}");

                // Build the pipeline: RTSP source -> object analytics (detection + tracking) -> video renderer.
                _source = new RTSPSourceBlock(rtsp);

                var detectorSettings = new YoloDetectorSettings(edModel.Text)
                {
                    Model = SelectedModelFamily(),
                    ConfidenceThreshold = ReadConfidenceThreshold(),
                    DrawDetections = true,
                };
                _analytics = new ObjectAnalyticsBlock(new ObjectAnalyticsSettings(detectorSettings));

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(_source.VideoOutput, _analytics.Input);
                _pipeline.Connect(_analytics.Output, _videoRenderer.Input);

                // Connect ONVIF PTZ and wire the auto-tracking controller to the analytics block.
                await ConnectPtzAsync(frameSize);
                if (_isClosing)
                {
                    return; // window closed during ONVIF connect — Window_Closing handles teardown
                }

                await _pipeline.StartAsync();
                Log($"Provider: {_analytics.ActiveProvider}");

                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { /* best-effort */ }
                await CleanupControllerAndOnvifAsync();
                CleanupBlocks();
                btStart.IsEnabled = true;
            }
            finally
            {
                // Enable only when it is actionable: pipeline stopped (set preference before start) or a PTZ
                // controller is active. A running pipeline without PTZ leaves the checkbox disabled.
                chkTracking.IsEnabled = !btStop.IsEnabled || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        // Connects to the ONVIF device and, when PTZ is supported, attaches the controller to the analytics block.
        private async Task ConnectPtzAsync(Size frameSize)
        {
            // No ONVIF URL means the user only wants the RTSP preview — skip the connection (and its error log).
            if (string.IsNullOrWhiteSpace(edOnvifUrl.Text))
            {
                Log("ONVIF URL is empty — running preview without PTZ.");
                return;
            }

            try
            {
                _onvif = new ONVIFClientX();
                var connected = await _onvif.ConnectAsync(edOnvifUrl.Text, edUser.Text, edPassword.Text);
                if (!connected)
                {
                    // No PTZ this session — release the ONVIF client now instead of holding an idle
                    // connection open until teardown.
                    Log("ONVIF: could not connect — running preview without PTZ.");
                    DisposeOnvif();
                    return;
                }

                // Robust PTZ probe: IsPTZSupported() reads only the cached ONVIF service list, which some
                // cameras (e.g. Dahua) leave empty after connect; IsPTZSupportedAsync falls back to a
                // media-profile PTZConfiguration probe.
                if (!await OnvifPTZMoveTransport.IsPTZSupportedAsync(_onvif))
                {
                    Log("ONVIF: device does not support PTZ — running preview without PTZ.");
                    DisposeOnvif();
                    return;
                }

                var transport = await OnvifPTZMoveTransport.CreateAsync(_onvif);
                if (transport == null)
                {
                    Log("ONVIF: no media profile available — running preview without PTZ.");
                    DisposeOnvif();
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
                // A throw from AttachTo/Start may leave a live controller behind, so tear down both the
                // controller and the ONVIF client — not just the ONVIF client.
                Log("ONVIF error: " + ex.Message);
                await CleanupControllerAndOnvifAsync();
            }
        }

        // Disposes the ONVIF client if present. Idempotent — safe to call from ConnectPtzAsync's
        // no-PTZ paths and from the shared teardown.
        private void DisposeOnvif()
        {
            if (_onvif != null)
            {
                _onvif.Dispose();
                _onvif = null;
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
            // IsChecked="True" in XAML raises Checked during InitializeComponent, before btStop exists;
            // bail until the window is initialized so the finally below never touches a null control.
            if (!IsInitialized)
            {
                return;
            }

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
            catch (Exception ex)
            {
                Log("tracking toggle error: " + ex.Message);
            }
            finally
            {
                // Enable only when it is actionable: pipeline stopped (set preference before start) or a PTZ
                // controller is active. A running pipeline without PTZ leaves the checkbox disabled.
                chkTracking.IsEnabled = !btStop.IsEnabled || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            // An unexpected stop (RTSP disconnect / network error) reaches here with the busy guard free.
            // Do a full cleanup so the controller sends a final camera-stop and nothing leaks. A user Stop/Close
            // already holds the guard (or set _isClosing), so it is skipped here.
            _ = Dispatcher.InvokeAsync(async () =>
            {
                if (_isClosing)
                {
                    return;
                }

                if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
                {
                    return;
                }

                try
                {
                    await CleanupAfterStopAsync();
                }
                catch (Exception ex)
                {
                    Log("unexpected stop cleanup error: " + ex.Message);
                }
                finally
                {
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    // Same actionable-state rule as the other handlers: with the pipeline stopped the user may
                    // set the tracking preference again before the next start.
                    chkTracking.IsEnabled = !btStop.IsEnabled || _controller != null;
                    SetStatus("Idle");
                    Interlocked.Exchange(ref _startStopBusy, 0);
                }
            });
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
                chkTracking.IsEnabled = !btStop.IsEnabled || _controller != null;
                Interlocked.Exchange(ref _startStopBusy, 0);
            }

            btStart.IsEnabled = true;
            SetStatus("Idle");
        }

        // Stops the controller first (detaches from analytics + halts the camera), then the pipeline, then blocks.
        private async Task CleanupAfterStopAsync()
        {
            try
            {
                await CleanupControllerAndOnvifAsync();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }
            }
            finally
            {
                // Dispose the blocks even if StopAsync/ClearBlocks threw, so they never leak.
                CleanupBlocks();
                VideoView1.CallRefresh();
            }
        }

        // Stops+disposes the controller (which detaches it from the analytics block) and then the ONVIF client.
        // Order matters: the controller drives the camera through the ONVIF transport, so it must stop first.
        // Shared by every teardown path (Start reuse, Start error, Stop, Close) so the ONVIF client never leaks.
        private async Task CleanupControllerAndOnvifAsync()
        {
            try
            {
                if (_controller != null)
                {
                    try
                    {
                        await _controller.StopAsync();
                    }
                    catch (Exception ex)
                    {
                        // A camera/network failure while stopping the controller must not propagate: it would
                        // bypass the pipeline stop below, so the blocks would be disposed while still running.
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                    finally
                    {
                        // Dispose even if StopAsync threw (network/camera failure), so the controller never leaks.
                        _controller.Dispose();
                    }
                }
            }
            finally
            {
                // Always clear the reference and release the ONVIF client, whatever happened above.
                _controller = null;
                DisposeOnvif();
            }
        }

        // The MB pipeline does not own the blocks we `new`; dispose them ourselves after ClearBlocks.
        private void CleanupBlocks()
        {
            _analytics?.Dispose();
            _analytics = null;
            _source?.Dispose();
            _source = null;
            _videoRenderer?.Dispose();
            _videoRenderer = null;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_readyToClose)
            {
                return; // our own programmatic Close() after teardown — let it through
            }

            if (_isClosing)
            {
                // Teardown is still running (the title-bar close button stays live while IsEnabled = false);
                // block this repeated close so the window can't vanish before DestroySDK() runs.
                e.Cancel = true;
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
                await CleanupControllerAndOnvifAsync();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                CleanupBlocks();
                // The download was cancelled at the top of this method; its owning task disposes its own CTS,
                // so we only drop our reference (disposing here could race a background token read).
                _downloadCts = null;
                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                // Always tear the SDK down, even if a cleanup step above threw, so the process exits cleanly.
                VisioForgeX.DestroySDK();
            }

            _readyToClose = true;
            _ = Dispatcher.InvokeAsync(() => Close());
        }
    }
}
