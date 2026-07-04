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

namespace OpenVocabularyDetectionMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private OpenVocabularyDetectorBlock _detector;
        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // Current free-text detection prompts (comma-separated in the Entry). Applied live via SetPrompts.
        private string[] _prompts = { "a person", "a car" };

        // Re-entrancy guard for the START/STOP button (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown so a user STOP and page-close cleanup dispose the pipeline exactly once.
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

        // ---- Model selection / download ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        // Downloaded model files are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models", "openvocab");

        // A file below this size is treated as a truncated/placeholder download and re-fetched.
        private const long MinPlausibleBytes = 64 * 1024;

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        // An open-vocabulary model is a SET of files (ONNX weights + tokenizer vocab + optional BPE merges).
        private sealed class ModelPreset
        {
            public string Name;
            public OpenVocabularyModel Model;
            public string ModelFile;   // .onnx weights
            public string VocabFile;   // vocab.json (OWLv2) or vocab.txt (Grounding DINO)
            public string MergesFile;  // merges.txt (OWLv2) or null (Grounding DINO)
        }

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-OpenVocab-Demo/1.0");
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

                // Populate the model picker (OWLv2 + Grounding DINO) and reflect on-disk state.
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
            }
        }

        // Builds the two open-vocabulary model presets.
        private static List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);

            return new List<ModelPreset>
            {
                new ModelPreset
                {
                    Name = "OWLv2 (base, ensemble)",
                    Model = OpenVocabularyModel.OWLv2,
                    ModelFile = "owlv2-base-ensemble.onnx",
                    VocabFile = "owlv2-vocab.json",
                    MergesFile = "owlv2-merges.txt"
                },
                new ModelPreset
                {
                    Name = "Grounding DINO (tiny)",
                    Model = OpenVocabularyModel.GroundingDINO,
                    ModelFile = "grounding-dino-tiny.onnx",
                    VocabFile = "bert-vocab.txt",
                    MergesFile = null
                }
            };
        }

        // Every file a preset needs (skips the null merges file for Grounding DINO).
        private static IEnumerable<string> RequiredFiles(ModelPreset preset)
        {
            yield return preset.ModelFile;
            yield return preset.VocabFile;
            if (preset.MergesFile != null)
            {
                yield return preset.MergesFile;
            }
        }

        // True when every required file is present in the cache with a plausible size.
        private static bool AreFilesPresent(ModelPreset preset)
        {
            foreach (var file in RequiredFiles(preset))
            {
                var path = Path.Combine(ModelsCacheDir, file);
                if (!File.Exists(path))
                {
                    return false;
                }

                // The tokenizer vocab/merges files are small; only gate the heavy ONNX weights on size.
                if (file.EndsWith(".onnx", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        if (new FileInfo(path).Length < MinPlausibleBytes)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void RefreshModelList()
        {
            var selName = _selectedPreset?.Name;
            _modelPresets = BuildModelList();

            pkModel.ItemsSource = _modelPresets.Select(p => p.Name).ToList();

            var selIdx = 0;
            for (int i = 0; i < _modelPresets.Count; i++)
            {
                if (_modelPresets[i].Name == selName)
                {
                    selIdx = i;
                    break;
                }
            }

            pkModel.SelectedIndex = selIdx;

            // SelectedIndexChanged does NOT fire when the index is unchanged (e.g. re-selecting the same
            // model right after its download completes), so refresh the selection explicitly.
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

            var present = AreFilesPresent(_selectedPreset);
            btDownloadModel.IsVisible = !present;

            lbModelPath.Text = present
                ? $"Ready: {string.Join(", ", RequiredFiles(_selectedPreset))}"
                : "Not downloaded — tap DOWNLOAD.";
        }

        private async void btDownloadModel_Clicked(object sender, EventArgs e)
        {
            var preset = _selectedPreset;
            if (preset == null)
            {
                return;
            }

            btDownloadModel.IsEnabled = false;
            var originalText = btDownloadModel.Text;
            btDownloadModel.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                var files = RequiredFiles(preset).ToList();
                for (int i = 0; i < files.Count; i++)
                {
                    var fileName = files[i];
                    var dest = Path.Combine(ModelsCacheDir, fileName);

                    // Skip a file that is already present with a plausible size.
                    if (File.Exists(dest) &&
                        (!fileName.EndsWith(".onnx", StringComparison.OrdinalIgnoreCase) ||
                         new FileInfo(dest).Length >= MinPlausibleBytes))
                    {
                        continue;
                    }

                    var url = ModelsReleaseUrl + "/" + fileName;
                    var fileIndex = i + 1;
                    var fileCount = files.Count;

                    await DownloadFileAsync(url, dest, fileName, fileIndex, fileCount);
                }

                pbDownload.Progress = 1;
                RefreshModelList();
            }
            catch (Exception ex)
            {
                lbModelPath.Text = "Download failed.";
                await DisplayAlert("Download failed",
                    $"{ex.Message}\n\nModel: {preset.Name}", "OK");
            }
            finally
            {
                pbDownload.IsVisible = false;
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Text = originalText;
            }
        }

        // Streams a single file to a .part temp then atomically moves it into place.
        private async Task DownloadFileAsync(string url, string dest, string fileName, int fileIndex, int fileCount)
        {
            var temp = dest + ".part";
            try
            {
                // Run the download off the UI thread; progress is marshalled back via the Dispatcher.
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
                                            lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {percent}%  ({readMB} / {totalMB} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var readMB = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {readMB} MB");
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
            }
            catch
            {
                // Best-effort cleanup of the partial file so a retry starts clean.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }
        }

        private void btApplyPrompts_Clicked(object sender, EventArgs e)
        {
            var parsed = ParsePrompts(enPrompts.Text);
            if (parsed.Length == 0)
            {
                lbStatus.Text = "Enter at least one prompt.";
                return;
            }

            _prompts = parsed;

            // Apply live if the detector is running; otherwise the next Start picks up _prompts.
            _detector?.SetPrompts(_prompts);

            lbStatus.Text = $"Prompts: {string.Join(", ", _prompts)}";
        }

        // Splits the comma-separated Entry into trimmed, non-empty prompt strings.
        private static string[] ParsePrompts(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return Array.Empty<string>();
            }

            return text.Split(',')
                .Select(p => p.Trim())
                .Where(p => p.Length > 0)
                .ToArray();
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

            var preset = _selectedPreset;
            if (preset == null || !AreFilesPresent(preset))
            {
                await DisplayAlert("Model required",
                    "The selected model is not downloaded yet. Tap DOWNLOAD first.", "OK");
                return;
            }

            // Make sure the prompts reflect what is currently typed in the Entry.
            var parsed = ParsePrompts(enPrompts.Text);
            if (parsed.Length > 0)
            {
                _prompts = parsed;
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

                // Create the open-vocabulary detector for the selected model family.
                var modelPath = Path.Combine(ModelsCacheDir, preset.ModelFile);
                var vocabPath = Path.Combine(ModelsCacheDir, preset.VocabFile);
                var mergesPath = preset.MergesFile != null ? Path.Combine(ModelsCacheDir, preset.MergesFile) : null;

                var detectorSettings = new OpenVocabularyDetectorSettings(modelPath, vocabPath, mergesPath, _prompts)
                {
                    Model = preset.Model
                };

                _detector = new OpenVocabularyDetectorBlock(detectorSettings);
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

                    _detector = null;
                    _videoRenderer = null;
                    _videoSource = null;

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
