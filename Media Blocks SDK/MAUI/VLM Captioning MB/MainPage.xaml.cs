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
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace VlmCaptioningMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private VLMBlock _vlm;
        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Currently selected Florence-2 task; applied to the block live and used when the pipeline starts.
        private VLMTask _selectedTask = VLMTask.Caption;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // Re-entrancy guard for the START/STOP button (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown so a user STOP and page-close cleanup dispose the pipeline exactly once.
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

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

                // Populate the task picker with every Florence-2 task.
                pkTask.ItemsSource = Enum.GetNames(typeof(VLMTask));
                pkTask.SelectedIndex = (int)_selectedTask;

                // Get available cameras
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    // Reset selection so a reused page can't keep a stale device.
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
                pbDownload.IsVisible = false;
                UpdateModelStatus();
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
                                        pbDownload.Progress = percent / 100.0;
                                        lbModelPath.Text = $"Downloading {fileName} ({fileIndex}/{fileCount})... {percent}%  ({readMB} / {totalMB} MB)";
                                    });
                                }
                            }
                            else
                            {
                                var readMB = readTotal / 1024 / 1024;
                                Dispatcher?.Dispatch(() => lbModelPath.Text = $"Downloading {fileName} ({fileIndex}/{fileCount})... {readMB} MB");
                            }
                        }

                        // Reject a truncated download so a partial file is never cached as complete.
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

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to caption video", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
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

            // The task can be changed while the pipeline runs; it takes effect on the next inference.
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

            if (!AreModelsPresent())
            {
                await DisplayAlert("Models required",
                    "The Florence-2 models are not downloaded yet. Tap DOWNLOAD first.",
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

                // Create the Florence-2 VLM block from the downloaded model folder.
                var vlmSettings = new VLMSettings(ModelsCacheDir)
                {
                    Task = _selectedTask,
                    TextInput = enTextInput.Text
                };

                _vlm = new VLMBlock(vlmSettings);
                _vlm.OnResultGenerated += Vlm_OnResultGenerated;

                // Create video renderer
                IVideoView vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

                // Connect pipeline
                _pipeline.Connect(_videoSource.Output, _vlm.Input);
                _pipeline.Connect(_vlm.Output, _videoRenderer.Input);

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
                lbStatus.Text = "Running — Florence-2 on CPU is seconds per frame.";
                btStartStop.Text = "STOP";
                btStartStop.BackgroundColor = Colors.Red;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");

                // Cleanup resources on failure
                if (_vlm != null)
                {
                    _vlm.OnResultGenerated -= Vlm_OnResultGenerated;
                    _vlm.Dispose();
                    _vlm = null;
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
                    if (_vlm != null)
                    {
                        _vlm.OnResultGenerated -= Vlm_OnResultGenerated;
                    }

                    // DisposeAsync disposes every connected block; do NOT ClearBlocks first.
                    _pipeline.OnError -= Pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;

                    _vlm = null;
                    _videoRenderer = null;
                    _videoSource = null;

                    _isRunning = false;
                }

                if (updateUI)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        lbStatus.Text = "Idle";
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

        private void Vlm_OnResultGenerated(object sender, VLMResultGeneratedEventArgs e)
        {
            var task = e.Task;
            var text = e.Text;
            var regionCount = e.Regions?.Length ?? 0;
            var inferenceMs = e.InferenceTimeMs;

            Debug.WriteLine($"VLM {task}: '{text}' regions={regionCount} in {inferenceMs:F0} ms");

            Dispatcher.Dispatch(() =>
            {
                // Events can arrive after teardown; bail if we've stopped or cleaned up.
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                try
                {
                    lbCaption.Text = string.IsNullOrEmpty(text) ? $"{task}: (no text)" : $"{task}: {text}";
                    lbStatus.Text = $"{regionCount} region(s)  |  {inferenceMs:F0} ms";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"VLM UI update failed: {ex.Message}");
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
