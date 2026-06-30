using System.Diagnostics;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;

namespace Player_Live_Subtitles_X
{
    /// <summary>
    /// Inserts a Whisper speech-to-text block into MediaPlayerCoreX through the X-engine
    /// Audio_Processing_AddBlock API. The block taps the decoded audio (passing it through to the
    /// speakers unchanged) and raises OnSpeechRecognized, which is shown as a live subtitle while
    /// the engine plays a normal file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;
        private SpeechToTextBlock _speechToText;

        private string _modelPath;
        private string _filePath;

        // Whisper GGML model presets, downloaded with a progress bar and cached under ModelsDir.
        private static readonly string ModelsDir = Path.Combine(FileSystem.AppDataDirectory, "models");

        // Picked media is copied here; AppDataDirectory is writable and accessible by the native engine on every platform.
        private static readonly string OpenedMediaDir = Path.Combine(FileSystem.AppDataDirectory, "opened_media");
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        private List<ModelPreset> _modelPresets;

        private bool _isRunning;
        private bool _isCleanedUp;
        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

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
                await VisioForgeX.InitSDKAsync();

                // Page was torn down during the await — bail without creating an undisposed player.
                if (_isCleanedUp)
                {
                    return;
                }

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }

                BuildModelPresets();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Init error: " + ex.Message);
            }
        }

        private sealed class ModelPreset
        {
            public string Name;
            public string FileName;   // cache file name (e.g. ggml-base.bin); null for the custom-file entry
            public string Url;        // download URL; null for the custom-file entry
            public bool IsCustom;
        }

        // Builds the model dropdown: a few downloadable Whisper sizes plus a "Custom file…" entry.
        private void BuildModelPresets()
        {
            _modelPresets = new List<ModelPreset>
            {
                new ModelPreset { Name = "Whisper Tiny (~74 MB)", FileName = "ggml-tiny.bin", Url = "https://huggingface.co/ggerganov/whisper.cpp/resolve/main/ggml-tiny.bin" },
                new ModelPreset { Name = "Whisper Base (~141 MB)", FileName = "ggml-base.bin", Url = "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1/ggml-base.bin" },
                new ModelPreset { Name = "Whisper Small (~465 MB)", FileName = "ggml-small.bin", Url = "https://huggingface.co/ggerganov/whisper.cpp/resolve/main/ggml-small.bin" },
                new ModelPreset { Name = "Custom file…", IsCustom = true },
            };

            pkModel.Items.Clear();
            foreach (var p in _modelPresets)
            {
                pkModel.Items.Add(p.Name);
            }

            pkModel.SelectedIndex = 1; // default to Base
        }

        private ModelPreset SelectedPreset()
            => (_modelPresets != null && pkModel.SelectedIndex >= 0 && pkModel.SelectedIndex < _modelPresets.Count)
                ? _modelPresets[pkModel.SelectedIndex]
                : null;

        // Reflects the picked preset in the UI: cached preset -> ready; downloadable -> show Download; custom -> Browse.
        private void pkModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var p = SelectedPreset();
            if (p == null)
            {
                return;
            }

            pbDownload.IsVisible = false;
            pbDownload.Progress = 0;

            if (p.IsCustom)
            {
                btDownloadModel.IsVisible = false;
                btBrowseModel.IsVisible = true;
                _modelPath = null;
                SetStatus("Tap Browse… and pick a Whisper GGML .bin file.");
                return;
            }

            btBrowseModel.IsVisible = false;
            var cache = Path.Combine(ModelsDir, p.FileName);
            if (File.Exists(cache))
            {
                _modelPath = cache;
                btDownloadModel.IsVisible = false;
                SetStatus($"Model ready: {p.Name}.");
            }
            else
            {
                _modelPath = null;
                btDownloadModel.IsVisible = true;
                SetStatus($"Tap Download to fetch {p.Name}.");
            }
        }

        private async void btDownloadModel_Clicked(object sender, EventArgs e)
        {
            var p = SelectedPreset();
            if (p == null || p.IsCustom)
            {
                return;
            }

            var dest = Path.Combine(ModelsDir, p.FileName);
            btDownloadModel.IsEnabled = false;
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;
            SetStatus($"Downloading {p.Name}...");

            try
            {
                await DownloadModelWithProgressAsync(p.Url, dest);
                _modelPath = dest;
                btDownloadModel.IsVisible = false;
                SetStatus($"Model ready: {p.Name}.");
            }
            catch (Exception ex)
            {
                _modelPath = null;
                SetStatus("Model download failed.");
                await DisplayAlert("Download failed", ex.Message, "OK");
            }
            finally
            {
                pbDownload.IsVisible = false;
                btDownloadModel.IsEnabled = true;
            }
        }

        // Streams the model to a .part file, reporting progress via the bar, then moves it into place.
        private async Task DownloadModelWithProgressAsync(string url, string dest)
        {
            Directory.CreateDirectory(ModelsDir);
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

                        using (var source = await response.Content.ReadAsStreamAsync())
                        using (var file = File.Create(temp))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int read;
                            int lastPercent = -1;
                            while ((read = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await file.WriteAsync(buffer, 0, read);
                                readTotal += read;
                                if (total > 0)
                                {
                                    // Throttle UI updates to whole-percent steps.
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var fraction = (double)readTotal / total;
                                        Dispatcher?.Dispatch(() => pbDownload.Progress = fraction);
                                    }
                                }
                            }

                            // Reject a truncated download so a corrupt .bin is never promoted to the cache.
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
                if (pick != null)
                {
                    // iOS/Mac picker paths are security-scoped — copy the model into the writable cache.
                    Directory.CreateDirectory(ModelsDir);
                    var local = Path.Combine(ModelsDir, $"{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                    using (var src = await pick.OpenReadAsync())
                    using (var dst = File.Create(local))
                    {
                        await src.CopyToAsync(dst);
                    }

                    _modelPath = local;
                    SetStatus("Model: " + pick.FileName);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
            }
        }

        private async void btFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync();
                if (pick != null)
                {
                    // iOS/Mac picker paths are security-scoped — copy the stream to app-data and play from there.
                    Directory.CreateDirectory(OpenedMediaDir);
                    if (!string.IsNullOrEmpty(_filePath))
                    {
                        try { File.Delete(_filePath); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }

                    var local = Path.Combine(OpenedMediaDir, $"{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                    using (var src = await pick.OpenReadAsync())
                    using (var dst = File.Create(local))
                    {
                        await src.CopyToAsync(dst);
                    }

                    _filePath = local;
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

            if (string.IsNullOrEmpty(_modelPath) || !File.Exists(_modelPath))
            {
                await DisplayAlert("Model required", "Choose a Whisper model from the list and download it, or pick a custom .bin file first.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a media file first.", "OK");
                return;
            }

            // Build the engine from scratch for every session.
            await RecreatePlayerAsync();
            if (_player == null || _isCleanedUp)
            {
                return;
            }

            // Route audio to a non-synced null renderer so the speech-to-text block runs at full speed, not real time.
            _player.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

            // Build the source before registering the block so a CreateAsync failure can't strand one.
            // On iOS the SDK exposes only the NSUrl overload; other platforms use the string overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filePath), renderVideo: true, renderAudio: true);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filePath, renderVideo: true, renderAudio: true);
#endif

            // VAD disabled keeps the dependency to the Whisper model only; CPU keeps it GPU-independent.
            var settings = new SpeechToTextSettings(_modelPath)
            {
                Language = "en",
                Provider = OnnxExecutionProvider.CPU,
                EnableVad = false,
            };

            _speechToText = new SpeechToTextBlock(settings);
            _speechToText.OnSpeechRecognized += SpeechToText_OnSpeechRecognized;
            _player.Audio_Processing_AddBlock(_speechToText);

            _player.Video_Play = true;
            _player.Audio_Play = true;

            try
            {
                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    // Start failed: tear the player down so an opened-but-not-playing pipeline isn't leaked.
                    await StopAsync();
                    SetStatus("Error: failed to open or play the source.");
                    return;
                }
            }
            catch
            {
                // A failed build disposes the registered block inside the engine; drop our stale reference.
                DetachBlock();
                throw;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Transcribing...");
        }

        private async Task StopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachBlock();
            _isRunning = false;
            btStartStop.Text = "START";
            btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
            Dispatcher?.Dispatch(() => lbSubtitle.Text = string.Empty);
        }

        private void SpeechToText_OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Segments == null || e.Segments.Length == 0)
            {
                return;
            }

            // Show the most recent non-empty segment as the current subtitle line.
            string line = null;
            foreach (var segment in e.Segments)
            {
                var text = segment?.Text?.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    line = text;
                }
            }

            if (line == null)
            {
                return;
            }

            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                lbSubtitle.Text = line;
            });
        }

        /// <summary>
        /// The engine disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh block.
        /// </summary>
        private void DetachBlock()
        {
            if (_speechToText != null)
            {
                _speechToText.OnSpeechRecognized -= SpeechToText_OnSpeechRecognized;
                _speechToText = null;
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

                // Ignore a stale Stop from a previous session while a start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
                {
                    return;
                }

                DetachBlock();
                _isRunning = false;
                btStartStop.Text = "START";
                btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
                lbSubtitle.Text = string.Empty;
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

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await _player.StopAsync();
                await _player.DisposeAsync();
                _player = null;
            }

            DetachBlock();

            VisioForgeX.DestroySDK();
        }
    }
}
