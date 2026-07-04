using System.Diagnostics;
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

namespace Capture_VLM_Captioning_X
{
    /// <summary>
    /// Inserts a Florence-2 VLM captioning block into VideoCaptureCoreX through the X-engine
    /// Video_Processing_AddBlock API. The block taps the live camera frames, optionally draws the
    /// results into the preview, and raises OnResultGenerated while the engine previews the camera.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private VLMBlock _vlm;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Currently selected Florence-2 task; applied to the block live and used when capture starts.
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

                // Populate the task picker with every Florence-2 task.
                pkTask.ItemsSource = Enum.GetNames(typeof(VLMTask));
                pkTask.SelectedIndex = (int)_selectedTask;

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras != null && _cameras.Length > 0)
                {
                    // Reset the index alongside the button text (MAUI reuses the page instance).
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

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

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera to caption video.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
            }
        }

        // A model file is considered present only if it exists and is larger than a small floor, so a truncated
        // or zero-byte download is never treated as complete. ONNX weights are large; the tokenizer assets are small.
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
            var originalText = btDownloadModel.Text;
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

            // The task can be changed while capture runs; it takes effect on the next inference.
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

            if (!AreModelsPresent())
            {
                await DisplayAlert("Models required",
                    "The Florence-2 models are not downloaded yet. Tap DOWNLOAD first.", "OK");
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

            // Build the Florence-2 VLM block and insert it as a video processing block. DrawResults renders
            // the captions/regions straight into the preview frame.
            var settings = new VLMSettings(ModelsCacheDir)
            {
                Task = _selectedTask,
                TextInput = enTextInput.Text ?? string.Empty,
                DrawResults = true,
            };

            _vlm = new VLMBlock(settings);
            _vlm.OnResultGenerated += Vlm_OnResultGenerated;
            _core.Video_Processing_AddBlock(_vlm);

            if (!await _core.StartAsync())
            {
                // Start failed: drop our block reference and leave the UI in the stopped state.
                DetachBlock();
                SetStatus("Error: failed to start capture.");
                return;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Running — Florence-2 on CPU is seconds per frame.");
        }

        private async Task StopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
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
                lbStatus.Text = $"{regionCount} region(s)  |  {inferenceMs:F0} ms";
            });
        }

        /// <summary>
        /// The engine disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh block.
        /// </summary>
        private void DetachBlock()
        {
            if (_vlm != null)
            {
                _vlm.OnResultGenerated -= Vlm_OnResultGenerated;
                _vlm = null;
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

                DetachBlock();
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

            DetachBlock();

            VisioForgeX.DestroySDK();
        }
    }
}
