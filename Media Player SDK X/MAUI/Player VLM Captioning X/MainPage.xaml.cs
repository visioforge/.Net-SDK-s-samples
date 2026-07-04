using System.Diagnostics;
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

namespace Player_VLM_Captioning_X
{
    /// <summary>
    /// Inserts a Florence-2 vision-language model into MediaPlayerCoreX through the X-engine
    /// Video_Processing_AddBlock API. The VLM taps the decoded video, captions / detects / reads text
    /// on a background worker, and raises OnResultGenerated while the engine plays a normal file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;
        private VLMBlock _vlm;

        private string _filePath;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Currently selected Florence-2 task; applied to the block live and used when playback starts.
        private VLMTask _selectedTask = VLMTask.Caption;

        // ---- Florence-2 model download ----
        // The release holds every ONNX asset for the AI demos; the 7 Florence-2 files live under it by name.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models", "vlm");

        // The 7 files a Florence-2 base model needs (names come straight from VLMSettings so they can't drift).
        private static readonly string[] VlmModelFiles =
        {
            VLMSettings.VisionEncoderFileName,
            VLMSettings.EmbedTokensFileName,
            VLMSettings.EncoderFileName,
            VLMSettings.DecoderFileName,
            VLMSettings.VocabFileName,
            VLMSettings.MergesFileName,
            VLMSettings.AddedTokensFileName,
        };

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-VLM-Demo/1.0");
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

                // Populate the task picker with every Florence-2 task.
                pkTask.ItemsSource = Enum.GetNames(typeof(VLMTask));
                pkTask.SelectedIndex = (int)_selectedTask;

                UpdateModelStatus();

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

        // A model file is present only if it exists and exceeds a small floor, so a truncated or zero-byte
        // download is never treated as complete. ONNX weights are large; the tokenizer assets are small.
        private static bool IsFilePlausible(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                var min = path.EndsWith(".onnx", StringComparison.OrdinalIgnoreCase) ? 1024L * 1024L : 8L;
                return new FileInfo(path).Length >= min;
            }
            catch
            {
                return false;
            }
        }

        private static bool AreModelsPresent()
        {
            foreach (var f in VlmModelFiles)
            {
                if (!IsFilePlausible(Path.Combine(ModelsCacheDir, f)))
                {
                    return false;
                }
            }

            return true;
        }

        private void UpdateModelStatus()
        {
            if (AreModelsPresent())
            {
                lbModelPath.Text = $"Models ready: {ModelsCacheDir}";
                btDownloadModel.IsEnabled = false;
                btDownloadModel.Text = "READY";
            }
            else
            {
                lbModelPath.Text = "Florence-2 models not downloaded — tap DOWNLOAD (~500 MB, one time).";
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Text = "DOWNLOAD";
            }
        }

        private async void btDownloadModel_Clicked(object sender, EventArgs e)
        {
            btDownloadModel.IsEnabled = false;
            btDownloadModel.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                // Download every missing file off the UI thread; progress is marshalled back via the Dispatcher.
                await Task.Run(async () =>
                {
                    for (int i = 0; i < VlmModelFiles.Length; i++)
                    {
                        var fileName = VlmModelFiles[i];
                        var dest = Path.Combine(ModelsCacheDir, fileName);
                        if (IsFilePlausible(dest))
                        {
                            continue;
                        }

                        var fileIndex = i + 1;
                        var url = ModelsReleaseUrl + "/" + fileName;
                        await DownloadFileAsync(url, dest, fileName, fileIndex, VlmModelFiles.Length);
                    }
                });

                pbDownload.Progress = 1;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Download failed", $"{ex.Message}", "OK");
            }
            finally
            {
                if (!_isCleanedUp)
                {
                    pbDownload.IsVisible = false;
                    UpdateModelStatus();
                }
            }
        }

        // Streams one file to a .part temp then moves it into place; rejects a truncated transfer.
        private async Task DownloadFileAsync(string url, string dest, string fileName, int fileIndex, int fileCount)
        {
            var temp = dest + ".part";
            try
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
                                        lbModelPath.Text = $"Downloading {fileName} ({fileIndex}/{fileCount})... {percent}%  ({readMB} / {totalMB} MB)";
                                    });
                                }
                            }
                            else
                            {
                                var readMB = readTotal / 1024 / 1024;
                                Dispatcher?.Dispatch(() => { if (_isCleanedUp) return; lbModelPath.Text = $"Downloading {fileName} ({fileIndex}/{fileCount})... {readMB} MB"; });
                            }
                        }

                        // Reject a truncated download so a partial file is never cached as complete.
                        if (_isCleanedUp) { return; }

                        if (total > 0 && readTotal != total)
                        {
                            throw new IOException($"Incomplete download of {fileName}: received {readTotal} of {total} bytes.");
                        }
                    }
                }

                File.Move(temp, dest, overwrite: true);
            }
            catch
            {
                // Best-effort cleanup of the partial file so a retry starts clean.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }
        }

        private void pkTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pkTask.SelectedIndex < 0)
            {
                return;
            }

            _selectedTask = (VLMTask)pkTask.SelectedIndex;

            // The text input is only meaningful for the Phrase Grounding task.
            enTextInput.IsEnabled = _selectedTask == VLMTask.PhraseGrounding;

            // The task can be changed while playback runs; it takes effect on the next inference.
            if (_vlm != null)
            {
                _vlm.Task = _selectedTask;
            }
        }

        private void enTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TextInput can be changed live; the block reads it on the next inference.
            if (_vlm != null)
            {
                _vlm.TextInput = e.NewTextValue;
            }
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

            if (!AreModelsPresent())
            {
                await DisplayAlert("Models required",
                    "The Florence-2 models are not downloaded yet. Tap DOWNLOAD first.", "OK");
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

            // Best-effort audio output on desktop; the VLM itself only needs the video stream.
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

            // Build the source before registering the VLM. iOS exposes only the NSUrl overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filePath), renderVideo: true, renderAudio: false);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filePath, renderVideo: true, renderAudio: false);
#endif

            // Build the Florence-2 VLM and insert it as a video processing block; DrawResults renders results.
            var settings = new VLMSettings(ModelsCacheDir)
            {
                Task = _selectedTask,
                TextInput = enTextInput.Text ?? string.Empty,
                DrawResults = true,
                ProcessingInterval = TimeSpan.FromSeconds(1),
                MaxNewTokens = 256,
            };

            _vlm = new VLMBlock(settings);
            _vlm.OnResultGenerated += Vlm_OnResultGenerated;
            _player.Video_Processing_AddBlock(_vlm);

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
                DetachVlm();
                throw;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Running — Florence-2 on CPU is seconds per frame.");
        }

        private async Task StopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachVlm();
            _isRunning = false;
            btStartStop.Text = "START";
            btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
        }

        private void Vlm_OnResultGenerated(object sender, VLMResultGeneratedEventArgs e)
        {
            var task = e.Task;
            var text = e.Text;
            var regionCount = e.Regions?.Length ?? 0;
            var inferenceMs = e.InferenceTimeMs;

            Debug.WriteLine($"VLM {task}: '{text}' regions={regionCount} in {inferenceMs:F0} ms");

            Dispatcher?.Dispatch(() =>
            {
                // Events can arrive after teardown; bail if we've stopped or cleaned up.
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                lbCaption.Text = string.IsNullOrEmpty(text) ? $"{task}: (no text)" : $"{task}: {text}";
                SetStatus($"{task}  |  {regionCount} region(s)  |  {inferenceMs:F0} ms");
            });
        }

        /// <summary>
        /// Detaches the handler and drops the reference; the engine disposes the block itself on stop.
        /// </summary>
        private void DetachVlm()
        {
            if (_vlm != null)
            {
                _vlm.OnResultGenerated -= Vlm_OnResultGenerated;
                _vlm = null;
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

                DetachVlm();
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

            DetachVlm();

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
