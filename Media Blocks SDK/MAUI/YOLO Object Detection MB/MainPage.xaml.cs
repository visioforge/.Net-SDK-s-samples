using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoProcessing;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace YoloObjectDetectionMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private YOLOObjectDetectorBlock _detector;
        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // Re-entrancy guard for the START/STOP button (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown so a user STOP and page-close cleanup dispose the pipeline exactly once.
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

        // ---- Model selection / download (mirrors the WPF YOLO demo) ----
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
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-YOLO-Demo/1.0");
        }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
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

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            try
            {
    #if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
    #endif

                // Initialize SDK
                await VisioForgeX.InitSDKAsync();

                // Get available cameras
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    // Reset selection so a reused page can't keep a stale device.
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // Populate the model picker (bundled + downloadable + custom).
                await RefreshModelListAsync();

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // Copies a bundled MauiAsset to AppDataDirectory once so APIs that need a file path can read it.
        private static async Task<string> EnsureAssetAsync(string fileName)
        {
            var dest = Path.Combine(FileSystem.AppDataDirectory, fileName);
            if (!File.Exists(dest))
            {
                Directory.CreateDirectory(FileSystem.AppDataDirectory);

                // Copy to a temp file, then move into place (overwrite-safe).
                var temp = dest + ".part";
                using (var src = await FileSystem.OpenAppPackageFileAsync(fileName))
                using (var dst = File.Create(temp))
                {
                    await src.CopyToAsync(dst);
                }

                File.Move(temp, dest, overwrite: true);
            }
            return dest;
        }

        // Builds the model list: bundled YOLOX, downloadable RT-DETR, and a "Custom model..." browse entry.
        private async Task<List<ModelPreset>> BuildModelListAsync()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();

            // Bundled YOLOX Nano — best-effort extraction from the app package.
            string bundledPath = null;
            try
            {
                bundledPath = await EnsureAssetAsync("yolox_nano.onnx");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Bundled model unavailable: {ex.Message}");
            }

            var bundledOk = bundledPath != null && File.Exists(bundledPath);
            list.Add(new ModelPreset
            {
                Name = bundledOk ? "YOLOX Nano (bundled)" : "YOLOX Nano (bundled — unavailable)",
                Tag = "yolox-bundled",
                Family = ObjectDetectorModel.YOLOX,
                IsLocal = bundledOk,
                LocalPath = bundledPath,
                FileName = "yolox_nano.onnx"
            });

            AddDownloadable(list, "RT-DETR R18vd", "rtdetr", "rtdetr_r18vd_fp16.onnx", ObjectDetectorModel.RTDETR);

            list.Add(new ModelPreset
            {
                Name = "Custom model...",
                Tag = "custom",
                Family = ObjectDetectorModel.YOLOX,
                IsLocal = false
            });

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
                LocalPath = isCached ? cachePath : null
            });
        }

        private async Task RefreshModelListAsync()
        {
            var selTag = _selectedPreset?.Tag;
            _modelPresets = await BuildModelListAsync();

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

            pkModel.SelectedIndex = selIdx;

            // SelectedIndexChanged does NOT fire when the index is unchanged (e.g. re-selecting the
            // same preset right after its download completes), so refresh the selection explicitly —
            // otherwise _selectedPreset keeps its stale LocalPath = null and Start can't find the model.
            UpdateModelSelection();
        }

        private void pkModel_SelectedIndexChanged(object sender, EventArgs e) => UpdateModelSelection();

        private void UpdateModelSelection()
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
                lbModelPath.Text = _customModelPath ?? "Tap BROWSE to pick a local .onnx file.";
            }
            else if (_selectedPreset.IsLocal && _selectedPreset.LocalPath != null)
            {
                lbModelPath.Text = _selectedPreset.LocalPath;
            }
            else
            {
                lbModelPath.Text = "Not downloaded — tap DOWNLOAD.";
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
                // Run the download off the UI thread; progress is marshalled back via the Dispatcher.
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
                                        var readMB = readTotal / 1024 / 1024;
                                        var totalMB = total / 1024 / 1024;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            pbDownload.Progress = percent / 100.0;
                                            lbModelPath.Text = $"Downloading... {percent}%  ({readMB} / {totalMB} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var readMB = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModelPath.Text = $"Downloading... {readMB} MB");
                                }
                            }

                            // Reject a truncated download so a partial .onnx is never cached as complete.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });

                pbDownload.Progress = 1;
                await RefreshModelListAsync();
            }
            catch (Exception ex)
            {
                // Best-effort cleanup of the partial file so a retry starts clean.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }

                lbModelPath.Text = "Download failed.";
                await DisplayAlert("Download failed",
                    $"{ex.Message}\n\nURL: {_selectedPreset.DownloadUrl}", "OK");
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
                await DisplayAlert("Error", $"Could not open the file picker: {ex.Message}", "OK");
            }
        }

        // Resolves the on-disk path of the model the user selected.
        private string ResolveModelPath()
        {
            if (_selectedPreset == null)
            {
                return null;
            }

            return _selectedPreset.Tag == "custom" ? _customModelPath : _selectedPreset.LocalPath;
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to detect objects", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
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
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private async Task StartAsync()
        {
            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("Error", "No cameras available", "OK");
                return;
            }

            // Resolve the model the user picked (bundled / downloaded / custom).
            var modelPath = ResolveModelPath();
            if (string.IsNullOrEmpty(modelPath) || !File.Exists(modelPath))
            {
                await DisplayAlert("Model required",
                    "Select a model first. Tap DOWNLOAD for a downloadable model, or BROWSE to pick a local .onnx file.",
                    "OK");
                return;
            }

            try
            {
                // Create pipeline
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                // Configure video source
                var device = _cameras[_cameraSelectedIndex];
                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);

                if (formatItem == null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                    await DisplayAlert("Error", "Unable to get camera format", "OK");
                    return;
                }

                var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };
                videoSourceSettings.Format.FrameRate = frameRate;

                _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                // Create the detector for the selected model family.
                var detectorSettings = new YoloDetectorSettings(modelPath) { Model = _selectedPreset.Family };
                _detector = new YOLOObjectDetectorBlock(detectorSettings);
                _detector.OnObjectsDetected += Detector_OnObjectsDetected;

                // Create video renderer
                IVideoView vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

                // Connect pipeline
                _pipeline.Connect(_videoSource.Output, _detector.Input);
                _pipeline.Connect(_detector.Output, _videoRenderer.Input);

                // Start. The page may be torn down during the awaits above/below; bail if so.
                if (_isCleanedUp)
                {
                    return;
                }

                await _pipeline.StartAsync();

                if (_isCleanedUp)
                {
                    return;
                }

                _isRunning = true;
                btStartStop.Text = "STOP";
                btStartStop.BackgroundColor = Colors.Red;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");

                // Cleanup resources on failure
                if (_detector != null)
                {
                    _detector.OnObjectsDetected -= Detector_OnObjectsDetected;
                    _detector.Dispose();
                    _detector = null;
                }

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _videoSource?.Dispose();
                _videoSource = null;

                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                await DisplayAlert("Error", $"Failed to start: {ex.Message}", "OK");
            }
        }

        private async Task StopAsync(bool updateUI = true)
        {
            // Serialize teardown so a user STOP and page-close cleanup dispose the pipeline exactly once.
            await _teardownGate.WaitAsync();
            try
            {
                // A prior caller already tore down — nothing to do.
                if (_pipeline == null)
                {
                    return;
                }

                // Guarantee block cleanup + disposal even if StopAsync throws.
                try
                {
                    await _pipeline.StopAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error stopping pipeline: {ex.Message}");
                }
                finally
                {
                    if (_detector != null)
                    {
                        _detector.OnObjectsDetected -= Detector_OnObjectsDetected;
                    }

                    // DisposeAsync disposes every connected block; do NOT ClearBlocks first.
                    _pipeline.OnError -= Pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;

                    _isRunning = false;
                }

                if (updateUI)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        btStartStop.Text = "START";
                        btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping: {ex.Message}");
            }
            finally
            {
                _teardownGate.Release();
            }
        }

        private void Detector_OnObjectsDetected(object sender, ObjectsDetectedEventArgs e)
        {
            var objects = e.Objects;
            if (objects == null || objects.Length == 0)
            {
                return;
            }

            // Pick the most confident detection for the headline label (null-safe).
            OnnxDetection top = null;
            foreach (var o in objects)
            {
                if (o != null && (top == null || o.Confidence > top.Confidence))
                {
                    top = o;
                }
            }

            if (top == null)
            {
                return;
            }

            var count = objects.Length;
            var label = top.Label;
            var confidence = top.Confidence;

            Dispatcher.Dispatch(() =>
            {
                // Events can arrive after teardown; bail if we've stopped or cleaned up.
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                try
                {
                    lbStatus.Text = $"Objects: {count}  |  {label} ({confidence:P0})";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Detector UI update failed: {ex.Message}");
                }
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        private void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0)
            {
                return;
            }

            _cameraSelectedIndex++;

            if (_cameraSelectedIndex >= _cameras.Length)
            {
                _cameraSelectedIndex = 0;
            }

            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
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
            if (_isCleanedUp)
            {
                return;
            }

            _isCleanedUp = true;

            if (_window != null)
            {
                _window.Destroying -= Window_Destroying;
                _window = null;
            }

            if (_isRunning)
            {
                await StopAsync(updateUI: false);
            }

            if (_pipeline != null)
            {
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
