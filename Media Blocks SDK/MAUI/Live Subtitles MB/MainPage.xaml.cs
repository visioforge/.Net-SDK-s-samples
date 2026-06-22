using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

using Whisper.net.Ggml;

namespace LiveSubtitlesMB
{
    public partial class MainPage : ContentPage
    {
        // Official Silero VAD v5 ONNX model (MIT).
        private const string SileroVadUrl =
            "https://github.com/snakers4/silero-vad/raw/master/src/silero_vad/data/silero_vad.onnx";

        // Shared client for the one-shot model downloads — avoids per-call socket churn.
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        private MediaBlocksPipeline _pipeline;
        private UniversalSourceBlock _source;
        private SpeechToTextBlock _stt;

        // A non-synced null sink: transcription runs as fast as Whisper allows instead of
        // playing the audio in real time (an AudioRendererBlock would clock the pipeline to 1x).
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

        // Serializes teardown: the EOS handler, a user STOP, and page-close cleanup can all land here;
        // the gate lets the first fully tear down while the others await, so DestroySDK never races it.
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
            // Download the models on first run (Whisper base is ~150 MB).
            ShowBusy(true);
            try
            {
                SetStatus("Downloading model (first run, ~150 MB)...");
                _whisperModelPath ??= await EnsureWhisperModelAsync(GgmlType.Base);
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
                    // File transcription: never drop audio. Backpressure paces the source to Whisper, so
                    // the whole file is transcribed losslessly and as fast as the CPU allows.
                    BackpressureWhenBusy = true,
                };
                settings.Vad.ModelPath = _sileroModelPath;

                var sourceSettings = await UniversalSourceSettings.CreateAsync(pick.FullPath, renderVideo: false, renderAudio: true);

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
                Dispatcher.Dispatch(() => lbSubtitles.Text = string.Empty);

                if (_isCleanedUp)
                {
                    await TeardownPipelineAsync();
                    return;
                }

                // Mark running BEFORE starting: for a very short/empty file EOS (OnStop) can fire as soon as
                // the pipeline reaches PLAYING, and Pipeline_OnStop only tears down when _isRunning is set.
                _isRunning = true;
                await _pipeline.StartAsync();

                // Bail if the page was torn down, or EOS already stopped+disposed the pipeline during startup
                // (StopAsync from OnStop has already reset the UI in that case).
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
            // Serialize teardown so DestroySDK (from CleanupAsync) never races an in-flight EOS/STOP
            // teardown: the first caller tears the pipeline down while the others await the gate.
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
                    Dispatcher.Dispatch(() =>
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
                // DisposeAsync disposes every connected block; do NOT ClearBlocks first
                // or the block list is emptied before disposal.
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

            Dispatcher.Dispatch(async () =>
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
            Dispatcher.Dispatch(() => lbStatus.Text = text);
        }

        private void ShowBusy(bool busy)
        {
            Dispatcher.Dispatch(() =>
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
            Dispatcher.Dispatch(() =>
            {
                if (_progressTimer != null)
                {
                    _progressTimer.Stop();
                    _progressTimer.Tick -= ProgressTimer_Tick;
                    _progressTimer = null;
                }

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

        /// <summary>Downloads the Whisper GGML model into AppDataDirectory if it is not already present.</summary>
        private static async Task<string> EnsureWhisperModelAsync(GgmlType type)
        {
            var dest = Path.Combine(FileSystem.AppDataDirectory, $"ggml-{type.ToString().ToLowerInvariant()}.bin");
            if (File.Exists(dest))
            {
                return dest;
            }

            Directory.CreateDirectory(FileSystem.AppDataDirectory);
            var temp = dest + ".part";
            using (var modelStream = await WhisperGgmlDownloader.Default.GetGgmlModelAsync(type))
            using (var fileStream = File.Create(temp))
            {
                await modelStream.CopyToAsync(fileStream);
            }

            File.Move(temp, dest, overwrite: true);
            return dest;
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
            using (var response = await _http.GetAsync(SileroVadUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                using (var fileStream = File.Create(temp))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }

            File.Move(temp, dest, overwrite: true);
            return dest;
        }
    }
}
