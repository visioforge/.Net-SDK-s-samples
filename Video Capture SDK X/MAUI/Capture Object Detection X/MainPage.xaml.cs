using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;
using VisioForge.Core.VideoCaptureX;

namespace Capture_Object_Detection_X
{
    /// <summary>
    /// Inserts a YOLO object detector into VideoCaptureCoreX through the X-engine
    /// Video_Processing_AddBlock API. The detector taps the live camera frames, draws bounding boxes
    /// into the preview, and raises OnObjectsDetected while the engine previews the camera.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private YOLOObjectDetectorBlock _detector;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;
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
            // Re-arm the cleanup flag: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;

            try
            {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
#endif

                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran, so bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // The engine is created fresh per session in StartAsync (RecreateEngineAsync).

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    // Reset the index alongside the button text (MAUI reuses the page instance).
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
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

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera to detect objects.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
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

            try
            {
                await DownloadModelWithProgressAsync(_selectedPreset.DownloadUrl, dest);
                pbDownload.Progress = 1;
                RefreshModelList();
            }
            catch (Exception ex)
            {
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

        // Streams the model to a .part file off the UI thread with progress, then moves it into place.
        private async Task DownloadModelWithProgressAsync(string url, string dest)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var temp = dest + ".part";

            try
            {
                // Run the network + disk loop off the UI thread so a large download can't freeze the window.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
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

                                // Throttle UI updates to whole-percent steps so the bar doesn't flood the dispatcher.
                                if (total > 0)
                                {
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var fraction = percent / 100.0;
                                        var doneMb = readTotal / 1024 / 1024;
                                        var totalMb = total / 1024 / 1024;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            pbDownload.Progress = fraction;
                                            lbModelPath.Text = $"Downloading... {percent}%  ({doneMb} / {totalMb} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var doneMb = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModelPath.Text = $"Downloading... {doneMb} MB");
                                }
                            }

                            // Reject a truncated download so a partial file is never cached as a complete model.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });
            }
            catch
            {
                // Best-effort cleanup of the partial file so a failed/cancelled download doesn't orphan it.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
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

        private void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras == null || _cameras.Length < 2)
            {
                return;
            }

            _cameraSelectedIndex = (_cameraSelectedIndex + 1) % _cameras.Length;
            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
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

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                try { await _core.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _core.DisposeAsync();
                _core = null;
            }

            if (_isCleanedUp)
            {
                return;
            }

            _core = new VideoCaptureCoreX(videoView.GetVideoView());
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async Task StartAsync()
        {
            if (_isCleanedUp)
            {
                return;
            }

            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("No camera", "No camera devices were found.", "OK");
                return;
            }

            var modelPath = ResolveModelPath();
            if (string.IsNullOrEmpty(modelPath) || !File.Exists(modelPath))
            {
                await DisplayAlert("Model required",
                    "Select a model first: tap Download for a model, or Browse to pick a local .onnx file.", "OK");
                return;
            }

            // Build the engine from scratch for every session.
            await RecreateEngineAsync();
            if (_core == null || _isCleanedUp)
            {
                return;
            }

            // Configure the camera source at an HD (or best available) format.
            var device = _cameras[_cameraSelectedIndex];
            var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
            if (formatItem == null)
            {
                await DisplayAlert("Error", "Unable to read a camera format.", "OK");
                return;
            }

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
            {
                Format = formatItem.ToFormat()
            };
            videoSourceSettings.Format.FrameRate = frameRate;
            _core.Video_Source = videoSourceSettings;
            _core.Audio_Play = false;

            // Build the detector and insert it as a video processing block. DrawDetections renders
            // the boxes straight into the preview frame.
            var settings = new YoloDetectorSettings(modelPath)
            {
                Model = _selectedPreset.Family,
                ConfidenceThreshold = 0.6f,
                DrawDetections = true,
            };

            _detector = new YOLOObjectDetectorBlock(settings);
            _detector.OnObjectsDetected += Detector_OnObjectsDetected;
            _core.Video_Processing_AddBlock(_detector);

            if (!await _core.StartAsync())
            {
                // Start failed: drop our block reference and leave the UI in the stopped state.
                DetachDetector();
                SetStatus("Error: failed to start capture.");
                return;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Detecting...");
        }

        private async Task StopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
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
        /// The engine disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh detector.
        /// </summary>
        private void DetachDetector()
        {
            if (_detector != null)
            {
                _detector.OnObjectsDetected -= Detector_OnObjectsDetected;
                _detector = null;
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e) => Debug.WriteLine(e.Message);

        // Reset the UI when the engine stops on its own (device error, end of stream, etc.).
        private async void Core_OnStop(object sender, StopEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session while a start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                DetachDetector();
                _isRunning = false;
                btStartStop.Text = "START";
                btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
            });
        }

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

            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                await _core.StopAsync();
                _core.Dispose();
                _core = null;
            }

            DetachDetector();

            VisioForgeX.DestroySDK();
        }
    }
}
