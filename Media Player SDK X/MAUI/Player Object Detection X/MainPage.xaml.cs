using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;

namespace Player_Object_Detection_X
{
    /// <summary>
    /// Inserts a YOLO object detector into MediaPlayerCoreX through the X-engine
    /// Video_Processing_AddBlock API. The detector taps the decoded video, draws bounding boxes
    /// into the rendered frame, and raises OnObjectsDetected while the engine plays a normal file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;
        private YOLOObjectDetectorBlock _detector;

        private string _filePath;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // ---- Model selection / download (mirrors the WPF Object Detection demo) ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

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

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;
        private string _customModelPath;

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            // Re-arm cleanup/guard flags: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;
            _isRunning = false;
            Interlocked.Exchange(ref _cleanupClaimed, 0);
            Interlocked.Exchange(ref _startStopBusy, 0);

            try
            {
                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran DestroySDK; bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // Populate the model picker (downloadable presets + custom).
                RefreshModelList();

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Init error: " + ex.Message);
            }
        }

        // Builds the model list: two downloadable detectors plus a "Custom model..." browse entry.
        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();
            AddDownloadable(list, "YOLOX Nano", "yolox", "yolox_nano.onnx", ObjectDetectorModel.YOLOX);
            AddDownloadable(list, "RT-DETR R18vd", "rtdetr", "rtdetr_r18vd_fp16.onnx", ObjectDetectorModel.RTDETR);
            list.Add(new ModelPreset { Name = "Custom model...", Tag = "custom", Family = ObjectDetectorModel.YOLOX });
            return list;
        }

        private static void AddDownloadable(List<ModelPreset> list, string name, string tag,
            string fileName, ObjectDetectorModel family)
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

            pkModel.ItemsSource = _modelPresets.Select(p => p.Name).ToList();

            var selIdx = 0;
            for (int i = 0; i < _modelPresets.Count; i++)
            {
                if (_modelPresets[i].Tag == selTag)
                {
                    selIdx = i;
                    break;
                }
            }

            // Setting SelectedIndex raises SelectedIndexChanged, which updates the buttons/label.
            pkModel.SelectedIndex = selIdx;
        }

        private void pkModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modelPresets == null || pkModel.SelectedIndex < 0 || pkModel.SelectedIndex >= _modelPresets.Count)
            {
                return;
            }

            _selectedPreset = _modelPresets[pkModel.SelectedIndex];

            var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
            var isCustom = _selectedPreset.Tag == "custom";

            btDownloadModel.IsVisible = needsDownload;
            btBrowseModel.IsVisible = isCustom;

            if (isCustom)
            {
                lbModelPath.Text = _customModelPath ?? "Tap Browse to pick a local .onnx file.";
            }
            else if (_selectedPreset.IsLocal && _selectedPreset.LocalPath != null)
            {
                lbModelPath.Text = _selectedPreset.LocalPath;
            }
            else
            {
                lbModelPath.Text = "Not downloaded — tap Download.";
            }
        }

        private async void btDownloadModel_Clicked(object sender, EventArgs e)
        {
            if (_selectedPreset?.DownloadUrl == null)
            {
                return;
            }

            Directory.CreateDirectory(ModelsCacheDir);
            var dest = Path.Combine(ModelsCacheDir, _selectedPreset.FileName);

            btDownloadModel.IsEnabled = false;
            var originalText = btDownloadModel.Text;
            btDownloadModel.Text = "Downloading...";
            lbModelPath.Text = $"Downloading {_selectedPreset.Name}...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            var temp = dest + ".part";
            try
            {
                // Download off the UI thread; progress is marshalled back via the Dispatcher.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(_selectedPreset.DownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var total = response.Content.Headers.ContentLength ?? -1L;
                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(temp))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                                readTotal += read;

                                // Throttle UI updates to whole-percent steps.
                                if (total > 0)
                                {
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var readMb = readTotal / 1024 / 1024;
                                        var totalMb = total / 1024 / 1024;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            pbDownload.Progress = percent / 100.0;
                                            lbModelPath.Text = $"Downloading... {percent}%  ({readMb} / {totalMb} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var readMb = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModelPath.Text = $"Downloading... {readMb} MB");
                                }
                            }

                            // Reject a truncated download so a partial file is never cached as complete.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });

                pbDownload.Progress = 1;
                RefreshModelList();
            }
            catch (Exception ex)
            {
                // Best-effort cleanup of the partial file so a retry starts clean.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }

                lbModelPath.Text = "Download failed.";
                await DisplayAlert("Download failed", $"{ex.Message}\n\nURL: {_selectedPreset.DownloadUrl}", "OK");
            }
            finally
            {
                pbDownload.IsVisible = false;
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Text = originalText;
            }
        }

        private async void btBrowseModel_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync();
                if (pick?.FullPath != null)
                {
                    _customModelPath = pick.FullPath;
                    lbModelPath.Text = pick.FullPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
            }
        }

        // Resolves the on-disk path of the model the user selected (downloaded preset or custom file).
        private string ResolveModelPath()
        {
            if (_selectedPreset == null)
            {
                return null;
            }

            return _selectedPreset.Tag == "custom" ? _customModelPath : _selectedPreset.LocalPath;
        }

        private async void btFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync();
                if (pick?.FullPath != null)
                {
                    _filePath = pick.FullPath;
                    SetStatus("File: " + pick.FileName);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
            }
        }

        private async void btStartStop_Clicked(object sender, EventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            try
            {
                if (_isRunning)
                {
                    await StopAsync();
                }
                else
                {
                    await StartAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Error: " + ex.Message);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isCleanedUp)
            {
                return;
            }

            _player = new MediaPlayerCoreX(videoView.GetVideoView());
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async Task StartAsync()
        {
            if (_isCleanedUp)
            {
                return;
            }

            var modelPath = ResolveModelPath();
            if (string.IsNullOrEmpty(modelPath) || !File.Exists(modelPath))
            {
                await DisplayAlert("Model required",
                    "Select a model first: tap Download for a model, or Browse to pick a local .onnx file.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a media file first.", "OK");
                return;
            }

            // Build a fresh engine for every session.
            await RecreatePlayerAsync();
            if (_player == null || _isCleanedUp)
            {
                return;
            }

            // Best-effort audio output on desktop; the detector itself only needs the video stream.
            try
            {
                var outputs = await _player.Audio_OutputDevicesAsync();
                if (outputs.Length > 0)
                {
                    _player.Audio_OutputDevice = new AudioRendererSettings(outputs[0]);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            // Build the source before registering the detector. iOS exposes only the NSUrl overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filePath), renderVideo: true, renderAudio: false);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filePath, renderVideo: true, renderAudio: false);
#endif

            // Build the detector and insert it as a video processing block; DrawDetections renders the boxes.
            var settings = new YoloDetectorSettings(modelPath)
            {
                Model = _selectedPreset.Family,
                ConfidenceThreshold = 0.6f,
                DrawDetections = true,
            };

            _detector = new YOLOObjectDetectorBlock(settings);
            _detector.OnObjectsDetected += Detector_OnObjectsDetected;
            _player.Video_Processing_AddBlock(_detector);

            _player.Video_Play = true;
            _player.Audio_Play = false;

            try
            {
                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    // Start failed: tear the player down (StopAsync also detaches the block), then surface it.
                    await StopAsync();
                    SetStatus("Error: failed to open or play the source.");
                    return;
                }
            }
            catch
            {
                // A failed build disposes the block inside the engine; drop our stale reference.
                DetachDetector();
                throw;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Detecting...");
        }

        private async Task StopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachDetector();
            _isRunning = false;
            btStartStop.Text = "START";
            btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
        }

        private void Detector_OnObjectsDetected(object sender, ObjectsDetectedEventArgs e)
        {
            // Headline the most confident detection plus the total count; reset to idle when none.
            var objects = e.Objects;
            var count = objects?.Length ?? 0;
            string topLabel = null;
            var topConfidence = 0f;
            if (objects != null)
            {
                foreach (var o in objects)
                {
                    if (o != null && o.Confidence > topConfidence)
                    {
                        topLabel = o.Label;
                        topConfidence = o.Confidence;
                    }
                }
            }

            var status = topLabel == null ? "Detecting..." : $"Objects: {count}  |  {topLabel} ({topConfidence:P0})";

            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                SetStatus(status);
            });
        }

        /// <summary>
        /// Detaches the handler and drops the reference; the engine disposes the block itself on stop.
        /// </summary>
        private void DetachDetector()
        {
            if (_detector != null)
            {
                _detector.OnObjectsDetected -= Detector_OnObjectsDetected;
                _detector = null;
            }
        }

        private async void Player_OnStop(object sender, StopEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session if a start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
                {
                    return;
                }

                DetachDetector();
                _isRunning = false;
                btStartStop.Text = "START";
                btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
            });
        }

        private void Player_OnError(object sender, ErrorsEventArgs e) => Debug.WriteLine(e.Message);

        private void SetStatus(string text)
        {
            if (_isCleanedUp)
            {
                return;
            }

            lbStatus.Text = text;
        }

        private async void MainPage_Unloaded(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task CleanupAsync()
        {
            // Atomically claim teardown so Unloaded and Window.Destroying can't both run it.
            if (Interlocked.Exchange(ref _cleanupClaimed, 1) == 1)
            {
                return;
            }

            _isCleanedUp = true;

            // Drain and claim the Start/Stop guard before disposing the engine, so teardown can't race a live StartAsync.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            if (_window != null)
            {
                _window.Destroying -= Window_Destroying;
                _window = null;
            }

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await _player.StopAsync();
                await _player.DisposeAsync();
                _player = null;
            }

            DetachDetector();

            VisioForgeX.DestroySDK();
        }
    }
}
