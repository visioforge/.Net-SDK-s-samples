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
using VisioForge.Core.VideoCaptureX;

namespace Capture_Open_Vocabulary_Detection_X
{
    /// <summary>
    /// Inserts an OpenVocabularyDetectorBlock (OWLv2 / Grounding DINO) into VideoCaptureCoreX through the
    /// X-engine Video_Processing_AddBlock API. The detector taps the live camera frames, draws boxes for
    /// the comma-separated text prompts, and raises OnObjectsDetected while the engine previews the camera.
    /// Prompts can be edited while capture runs (applied live via SetPrompts).
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private OpenVocabularyDetectorBlock _detector;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Current free-text detection prompts (comma-separated in the Entry). Applied live via SetPrompts.
        private string[] _prompts = { "a person", "a car" };

        // ---- Model selection / download ----
        // Open-vocabulary weights are NOT shipped with the SDK; hosted on the samples GitHub release.
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

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            // Re-arm cleanup/guard flags: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;
            _isRunning = false;
            Interlocked.Exchange(ref _cleanupClaimed, 0);
            Interlocked.Exchange(ref _startStopBusy, 0);

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
                if (_cameras != null && _cameras.Length > 0)
                {
                    // Reset the index alongside the button text (MAUI reuses the page instance).
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

            // Default to Grounding DINO (its score scale suits the default confidence; OWLv2 scores lower).
            var selIdx = _modelPresets.FindIndex(p => p.Model == OpenVocabularyModel.GroundingDINO);
            if (selIdx < 0)
            {
                selIdx = 0;
            }

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
                    await DownloadFileAsync(url, dest, fileName, i + 1, files.Count);
                }

                pbDownload.Progress = 1;
                RefreshModelList();
            }
            catch (Exception ex)
            {
                lbModelPath.Text = "Download failed.";
                await DisplayAlert("Download failed", $"{ex.Message}\n\nModel: {preset.Name}", "OK");
            }
            finally
            {
                if (!_isCleanedUp)
                {
                    pbDownload.IsVisible = false;
                    btDownloadModel.IsEnabled = true;
                    btDownloadModel.Text = originalText;
                }
            }
        }

        // Streams a single file to a .part temp then atomically moves it into place.
        private async Task DownloadFileAsync(string url, string dest, string fileName, int fileIndex, int fileCount)
        {
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
                                        var doneMb = readTotal / 1024 / 1024;
                                        var totalMb = total / 1024 / 1024;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            if (_isCleanedUp) return;
                                            pbDownload.Progress = percent / 100.0;
                                            lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {percent}%  ({doneMb} / {totalMb} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var doneMb = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => { if (_isCleanedUp) return; lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {doneMb} MB"; });
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

        // Live threshold sliders — the detector reads the shared settings per frame, so the new value
        // takes effect on the next frame without rebuilding the pipeline.
        private void slConfidence_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lbConfidence != null)
            {
                lbConfidence.Text = e.NewValue.ToString("F2");
            }

            _detector?.SetConfidenceThreshold((float)e.NewValue);
        }

        private void slIoU_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lbIoU != null)
            {
                lbIoU.Text = e.NewValue.ToString("F2");
            }

            _detector?.SetIoUThreshold((float)e.NewValue);
        }

        private void btApplyPrompts_Clicked(object sender, EventArgs e)
        {
            var parsed = ParsePrompts(enPrompts.Text);
            if (parsed.Length == 0)
            {
                SetStatus("Enter at least one prompt.");
                return;
            }

            _prompts = parsed;

            // Apply live if the detector is running; otherwise the next Start picks up _prompts.
            _detector?.SetPrompts(_prompts);

            SetStatus($"Prompts: {string.Join(", ", _prompts)}");
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

            // Build the open-vocabulary detector for the selected model family and insert it as a video
            // processing block. DrawDetections renders the boxes straight into the preview frame.
            var modelPath = Path.Combine(ModelsCacheDir, preset.ModelFile);
            var vocabPath = Path.Combine(ModelsCacheDir, preset.VocabFile);
            var mergesPath = preset.MergesFile != null ? Path.Combine(ModelsCacheDir, preset.MergesFile) : null;

            var settings = new OpenVocabularyDetectorSettings(modelPath, vocabPath, mergesPath, _prompts)
            {
                Model = preset.Model,
                ConfidenceThreshold = (float)slConfidence.Value,
                IoUThreshold = (float)slIoU.Value,
                DrawDetections = true,
            };

            _detector = new OpenVocabularyDetectorBlock(settings);
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
            SetStatus($"Detecting: {string.Join(", ", _prompts)}");
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

            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                await _core.StopAsync();
                await _core.DisposeAsync();
                _core = null;
            }

            DetachDetector();

            VisioForgeX.DestroySDK();
        }
    }
}
