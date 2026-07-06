using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace LiveSubtitlesMB
{
    public partial class MainPage : ContentPage
    {
        // Silero VAD v5 ONNX model (MIT), hosted on the samples GitHub release alongside the other models.
        private const string SileroVadUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1/silero_vad.onnx";

        // Shared client for the one-shot model downloads — avoids per-call socket churn.
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        // Whisper GGML model cache + presets (downloaded with a progress bar, or a custom .bin via Browse).
        private static readonly string ModelsDir = Path.Combine(FileSystem.AppDataDirectory, "models");
        private List<ModelPreset> _modelPresets;

        private MediaBlocksPipeline _pipeline;
        private UniversalSourceBlock _source;
        private SpeechToTextBlock _stt;

        // Non-synced null sink: transcription runs as fast as Whisper allows, not at 1x playback speed.
        private NullRendererBlock _audioSink;

        private string _whisperModelPath;
        private string _sileroModelPath;

        private readonly StringBuilder _subtitles = new();

        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // Re-entrancy guard for the transcribe button (0 = free, 1 = busy).
        private int _busy;

        // Serializes teardown so EOS, user STOP, and page-close cleanup don't race each other.
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

        // Polls the pipeline position/duration to drive the transcription progress bar.
        private IDispatcherTimer _progressTimer;
        private TimeSpan _mediaDuration;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            try
            {
                await VisioForgeX.InitSDKAsync();

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
                _whisperModelPath = null;
                SetStatus("Tap Browse… and pick a Whisper GGML .bin file.");
                return;
            }

            btBrowseModel.IsVisible = false;
            var cache = Path.Combine(ModelsDir, p.FileName);
            if (File.Exists(cache))
            {
                _whisperModelPath = cache;
                btDownloadModel.IsVisible = false;
                SetStatus($"Model ready: {p.Name}. Pick a file to transcribe.");
            }
            else
            {
                _whisperModelPath = null;
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
                _whisperModelPath = dest;
                btDownloadModel.IsVisible = false;
                SetStatus($"Model ready: {p.Name}. Pick a file to transcribe.");
            }
            catch (Exception ex)
            {
                _whisperModelPath = null;
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
                                    // Throttle progress updates to whole-percent steps.
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var fraction = (double)readTotal / total;
                                        Dispatcher?.Dispatch(() => pbDownload.Progress = fraction);
                                    }
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
                    _whisperModelPath = pick.FullPath;
                    SetStatus("Model: " + Path.GetFileName(pick.FullPath) + ". Pick a file to transcribe.");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
            }
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

        private async void btTranscribe_Clicked(object sender, EventArgs e)
        {
            if (Interlocked.CompareExchange(ref _busy, 1, 0) != 0)
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
                Interlocked.Exchange(ref _busy, 0);
            }
        }

        private async Task StartAsync()
        {
            // A Whisper model must be selected (downloaded from the list or browsed) before transcribing.
            if (string.IsNullOrEmpty(_whisperModelPath) || !File.Exists(_whisperModelPath))
            {
                await DisplayAlert("Model required", "Choose a Whisper model from the list and download it, or pick a custom .bin file first.", "OK");
                return;
            }

            // Silero VAD (small) is fetched automatically on first run.
            ShowBusy(true);
            try
            {
                SetStatus("Preparing VAD model...");
                _sileroModelPath ??= await EnsureSileroModelAsync();
            }
            catch (Exception ex)
            {
                SetStatus("Pick a media file to transcribe on-device with Whisper.");
                await DisplayAlert("Model download failed", ex.Message, "OK");
                return;
            }
            finally
            {
                ShowBusy(false);
            }

            // Let the user pick a media file to subtitle.
            FileResult pick;
            try
            {
                pick = await FilePicker.Default.PickAsync();
            }
            catch (Exception ex)
            {
                SetStatus("Pick a media file to transcribe on-device with Whisper.");
                await DisplayAlert("Error", $"Could not open the file picker: {ex.Message}", "OK");
                return;
            }

            if (pick?.FullPath == null)
            {
                SetStatus("No file selected.");
                return;
            }

            try
            {
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                var settings = new SpeechToTextSettings(_whisperModelPath)
                {
                    Language = "auto",
                    Provider = OnnxExecutionProvider.Auto, // GPU when available, else CPU
                    EnableVad = true,
                };
                settings.Vad.ModelPath = _sileroModelPath;

                // On iOS the SDK exposes only the NSUrl overload, so wrap the picked path.
#if IOS && !MACCATALYST
                var sourceSettings = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(pick.FullPath), renderVideo: false, renderAudio: true);
#else
                var sourceSettings = await UniversalSourceSettings.CreateAsync(pick.FullPath, renderVideo: false, renderAudio: true);
#endif

                // The page may be torn down during the await; bail before touching the pipeline.
                if (_isCleanedUp)
                {
                    return;
                }

                _source = new UniversalSourceBlock(sourceSettings);

                var audioPad = _source.AudioOutput;
                if (audioPad == null)
                {
                    await TeardownPipelineAsync();
                    await DisplayAlert("No audio", "The selected file has no audio track to transcribe.", "OK");
                    SetStatus("Pick a media file to transcribe on-device with Whisper.");
                    return;
                }

                _stt = new SpeechToTextBlock(settings);
                _stt.OnSpeechRecognized += Stt_OnSpeechRecognized;

                _audioSink = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

                if (!_pipeline.Connect(audioPad, _stt.Input) || !_pipeline.Connect(_stt.Output, _audioSink.Input))
                {
                    await TeardownPipelineAsync();
                    SetStatus("Pick a media file to transcribe on-device with Whisper.");
                    await DisplayAlert("Error", "Failed to build the audio pipeline.", "OK");
                    return;
                }

                _subtitles.Clear();
                Dispatcher?.Dispatch(() => lbSubtitles.Text = string.Empty);

                if (_isCleanedUp)
                {
                    await TeardownPipelineAsync();
                    return;
                }

                // Mark running BEFORE starting: a short/empty file can fire EOS before StartAsync returns.
                _isRunning = true;
                await _pipeline.StartAsync();

                // Bail if the page was torn down or EOS already stopped+disposed the pipeline during startup.
                if (_isCleanedUp || _pipeline == null)
                {
                    return;
                }

                SetStatus($"Transcribing {Path.GetFileName(pick.FullPath)}...");
                btTranscribe.Text = "STOP";
                btTranscribe.BackgroundColor = Colors.Red;
                StartProgressTimer();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");
                _isRunning = false;
                await TeardownPipelineAsync();
                await DisplayAlert("Error", $"Failed to start: {ex.Message}", "OK");
                SetStatus("Pick a media file to transcribe on-device with Whisper.");
            }
        }

        private async Task StopAsync(bool updateUI = true)
        {
            // Serialize teardown so DestroySDK never races an in-flight EOS/STOP teardown.
            await _teardownGate.WaitAsync();
            try
            {
                // A prior caller (EOS, user STOP, or page-close cleanup) already tore down — run once.
                if (_pipeline == null)
                {
                    return;
                }

                // Guarantee teardown even if StopAsync throws.
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
                    await TeardownPipelineAsync();
                    _isRunning = false;
                }

                if (updateUI)
                {
                    Dispatcher?.Dispatch(() =>
                    {
                        btTranscribe.Text = "PICK FILE & TRANSCRIBE";
                        btTranscribe.BackgroundColor = Color.FromRgb(76, 175, 80);
                        SetStatus("Done. Pick another file to transcribe.");
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

        private async Task TeardownPipelineAsync()
        {
            StopProgressTimer();

            if (_stt != null)
            {
                _stt.OnSpeechRecognized -= Stt_OnSpeechRecognized;
            }

            if (_pipeline != null)
            {
                // DisposeAsync disposes every connected block; do NOT ClearBlocks first.
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _stt?.Dispose();
            _stt = null;

            _source?.Dispose();
            _source = null;

            _audioSink?.Dispose();
            _audioSink = null;
        }

        private void Stt_OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Raised off the UI thread — accumulate this event's lines, then marshal a single UI update.
            if (e?.Segments == null)
            {
                return;
            }

            var newLines = new List<string>();
            foreach (var seg in e.Segments)
            {
                if (string.IsNullOrWhiteSpace(seg?.Text))
                {
                    continue;
                }

                newLines.Add($"[{seg.StartTime:hh\\:mm\\:ss}] {seg.Text.Trim()}");
            }

            if (newLines.Count == 0)
            {
                return;
            }

            Dispatcher?.Dispatch(async () =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                try
                {
                    foreach (var line in newLines)
                    {
                        _subtitles.AppendLine(line);
                    }

                    lbSubtitles.Text = _subtitles.ToString();
                    await svSubtitles.ScrollToAsync(lbSubtitles, ScrollToPosition.End, false);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Subtitle UI update failed: {ex.Message}");
                }
            });
        }

        private async void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            // The file finished (EOS) — tear down and reset the UI.
            try
            {
                // Ignore a stale Stop from a previous session while a start/stop is in flight.
                if (Volatile.Read(ref _busy) != 0)
                {
                    return;
                }

                var pipeline = _pipeline;
                if (pipeline != null && pipeline.State != PlaybackState.Free)
                {
                    return;
                }

                if (_isRunning)
                {
                    await StopAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        private void SetStatus(string text)
        {
            Dispatcher?.Dispatch(() => lbStatus.Text = text);
        }

        private void ShowBusy(bool busy)
        {
            Dispatcher?.Dispatch(() =>
            {
                aiBusy.IsRunning = busy;
                aiBusy.IsVisible = busy;
            });
        }

        // Starts polling the pipeline position to drive the transcription progress bar.
        private void StartProgressTimer()
        {
            _mediaDuration = TimeSpan.Zero;
            pbProgress.Progress = 0;
            pbProgress.IsVisible = true;
            lbTime.IsVisible = true;
            lbTime.Text = "00:00:00";

            _progressTimer = Dispatcher.CreateTimer();
            _progressTimer.Interval = TimeSpan.FromMilliseconds(500);
            _progressTimer.Tick += ProgressTimer_Tick;
            _progressTimer.Start();
        }

        private void StopProgressTimer()
        {
            // Stop/unsubscribe the timer outside the dispatch so it runs even when Dispatcher is null.
            var timer = _progressTimer;
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= ProgressTimer_Tick;
                _progressTimer = null;
            }

            Dispatcher?.Dispatch(() =>
            {
                pbProgress.IsVisible = false;
                lbTime.IsVisible = false;
            });
        }

        private async void ProgressTimer_Tick(object sender, EventArgs e)
        {
            var pipeline = _pipeline;
            if (pipeline == null)
            {
                return;
            }

            try
            {
                // Duration becomes known a moment after start; cache it once resolved.
                if (_mediaDuration <= TimeSpan.Zero)
                {
                    _mediaDuration = await pipeline.DurationAsync();
                }

                var pos = await pipeline.Position_GetAsync();

                if (_mediaDuration > TimeSpan.Zero)
                {
                    var fraction = pos.TotalSeconds / _mediaDuration.TotalSeconds;
                    pbProgress.Progress = Math.Max(0, Math.Min(1, fraction));
                    lbTime.Text = $"{pos:hh\\:mm\\:ss} / {_mediaDuration:hh\\:mm\\:ss}";
                }
                else
                {
                    lbTime.Text = $"{pos:hh\\:mm\\:ss}";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Progress update failed: {ex.Message}");
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

            if (_isRunning)
            {
                await StopAsync(updateUI: false);
            }

            await TeardownPipelineAsync();

            VisioForgeX.DestroySDK();
        }

        /// <summary>Downloads the Silero VAD ONNX model into AppDataDirectory if it is not already present.</summary>
        private static async Task<string> EnsureSileroModelAsync()
        {
            var dest = Path.Combine(FileSystem.AppDataDirectory, "silero_vad.onnx");
            if (File.Exists(dest))
            {
                return dest;
            }

            Directory.CreateDirectory(FileSystem.AppDataDirectory);
            var temp = dest + ".part";
            try
            {
                using (var response = await _http.GetAsync(SileroVadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    var total = response.Content.Headers.ContentLength ?? -1L;

                    using (var fileStream = File.Create(temp))
                    {
                        await response.Content.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();

                        // Reject a truncated download so a partial .onnx is never cached as complete.
                        if (total > 0 && fileStream.Length != total)
                        {
                            throw new IOException($"Incomplete download: received {fileStream.Length} of {total} bytes.");
                        }
                    }
                }

                File.Move(temp, dest, overwrite: true);
            }
            catch
            {
                // Best-effort cleanup of the partial file so a failed/cancelled download doesn't orphan it.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }

            return dest;
        }
    }
}
