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

namespace Player_Open_Vocabulary_Detection_X
{
    /// <summary>
    /// Inserts an OpenVocabularyDetectorBlock (OWLv2 / Grounding DINO) into MediaPlayerCoreX through the
    /// X-engine Video_Processing_AddBlock API. The detector taps the decoded video of a playing file, draws
    /// boxes for the free-text prompts, and raises OnObjectsDetected. Prompts can be edited while it plays.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;
        private OpenVocabularyDetectorBlock _detector;

        private string _filePath;

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
                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran DestroySDK; bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // Drop any copied source videos left in the cache by a previous run.
                try
                {
                    foreach (var stale in Directory.EnumerateFiles(FileSystem.CacheDirectory, "source_*"))
                    {
                        try { File.Delete(stale); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex); }

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
                                if (_isCleanedUp) { break; }

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
                                            if (_isCleanedUp) return;
                                            pbDownload.Progress = percent / 100.0;
                                            lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {percent}%  ({readMB} / {totalMB} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var readMB = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => { if (_isCleanedUp) return; lbModelPath.Text = $"[{fileIndex}/{fileCount}] {fileName}  {readMB} MB"; });
                                }
                            }

                            // Reject a truncated download so a partial file is never cached as complete.
                            if (_isCleanedUp) { return; }

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

        private async void btFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync();
                if (pick != null)
                {
                    // Copy to a stable local path (Android content URIs aren't openable by the demuxer); GUID name avoids collisions.
                    Directory.CreateDirectory(FileSystem.CacheDirectory);
                    var dest = Path.Combine(FileSystem.CacheDirectory, $"source_{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                    using (var src = await pick.OpenReadAsync())
                    using (var dst = File.Create(dest))
                    {
                        await src.CopyToAsync(dst);
                    }

                    // Switch to the new copy only after it succeeds, then drop the previous one so caches don't accumulate.
                    var previous = _filePath;
                    _filePath = dest;
                    SetStatus("File: " + pick.FileName);
                    if (!string.IsNullOrEmpty(previous))
                    {
                        try { if (File.Exists(previous)) File.Delete(previous); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }
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

            var preset = _selectedPreset;
            if (preset == null || !AreFilesPresent(preset))
            {
                await DisplayAlert("Model required",
                    "The selected model is not downloaded yet. Tap DOWNLOAD first.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a video file first.", "OK");
                return;
            }

            // Make sure the prompts reflect what is currently typed in the Entry.
            var parsed = ParsePrompts(enPrompts.Text);
            if (parsed.Length > 0)
            {
                _prompts = parsed;
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
                if (outputs != null && outputs.Length > 0)
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

            // Build the open-vocabulary detector for the selected model family; DrawDetections renders the boxes.
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

            // Drop the copied source video from the cache so large files don't linger after teardown.
            if (!string.IsNullOrEmpty(_filePath))
            {
                try { if (File.Exists(_filePath)) File.Delete(_filePath); } catch (Exception ex) { Debug.WriteLine(ex); }
                _filePath = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
