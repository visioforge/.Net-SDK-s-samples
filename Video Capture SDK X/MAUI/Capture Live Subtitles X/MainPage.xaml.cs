using System.Diagnostics;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;
using VisioForge.Core.VideoCaptureX;

namespace Capture_Live_Subtitles_X
{
    /// <summary>
    /// Inserts a Whisper speech-to-text block into VideoCaptureCoreX through the X-engine
    /// Audio_Processing_AddBlock API. The block taps the live microphone audio (passing it through
    /// unchanged) and raises OnSpeechRecognized, which is shown as a live subtitle over the camera
    /// preview. A non-synced null renderer set as Audio_OutputBlock builds the audio chain (where the
    /// speech block is inserted) without a speaker renderer or a recording file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private SpeechToTextBlock _speechToText;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private AudioCaptureDeviceInfo[] _mics;
        private int _micSelectedIndex;

        private string _modelPath;

        // Whisper GGML model presets, cached under ModelsDir; "Custom file…" lets the user pick any local .bin.
        private static readonly string ModelsDir = Path.Combine(FileSystem.AppDataDirectory, "models");
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        private List<ModelPreset> _modelPresets;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

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
            // Re-arm cleanup/guard flags: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;
            _isRunning = false;
            Interlocked.Exchange(ref _cleanupClaimed, 0);
            Interlocked.Exchange(ref _startStopBusy, 0);

            try
            {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
                await RequestMicPermissionAsync();
#endif

                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran, so bail (engine built later in StartAsync).
                if (_isCleanedUp)
                {
                    return;
                }

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    // Reset the index with the button text — MAUI reuses the page instance across sessions.
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
                if (_mics.Length > 0)
                {
                    _micSelectedIndex = 0;
                    btMic.Text = _mics[0].DisplayName;
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

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
            }
        }

        private async Task RequestMicPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Microphone>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Microphone>())
            {
                if (await DisplayAlert("Microphone permission", "You need to allow access to the Microphone to transcribe speech.", "OK", "Cancel"))
                {
                    await RequestMicPermissionAsync();
                }
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
                // Run the download off the UI thread; marshal progress back via the Dispatcher.
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

                            // Reject a truncated download so a partial file is never promoted to the cache.
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

        private void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras == null || _cameras.Length < 2)
            {
                return;
            }

            _cameraSelectedIndex = (_cameraSelectedIndex + 1) % _cameras.Length;
            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
        }

        private void btMic_Clicked(object sender, EventArgs e)
        {
            if (_mics == null || _mics.Length < 2)
            {
                return;
            }

            _micSelectedIndex = (_micSelectedIndex + 1) % _mics.Length;
            btMic.Text = _mics[_micSelectedIndex].DisplayName;
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

            if (_mics == null || _mics.Length == 0)
            {
                await DisplayAlert("No microphone", "No microphone devices were found.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_modelPath) || !File.Exists(_modelPath))
            {
                await DisplayAlert("Model required", "Choose a Whisper model from the list and download it, or pick a custom .bin file first.", "OK");
                return;
            }

            // Build a fresh engine for every session.
            await RecreateEngineAsync();
            if (_core == null || _isCleanedUp)
            {
                return;
            }

            // Camera source (for the preview the subtitle is drawn over).
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

            // Microphone source. A non-synced null renderer as Audio_OutputBlock builds the audio chain (where the
            // speech block is inserted) with no speaker output and no recording file.
            var mic = _mics[_micSelectedIndex];
            var micFormat = mic.GetDefaultFormat();
            if (micFormat == null)
            {
                await DisplayAlert("Error", "Unable to read a microphone format.", "OK");
                return;
            }

            _core.Audio_Source = mic.CreateSourceSettingsVC(micFormat);
            _core.Audio_Play = false;
            _core.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

            // VAD disabled needs only the Whisper model (no Silero); CPU provider keeps it GPU-independent.
            var settings = new SpeechToTextSettings(_modelPath)
            {
                Language = "en",
                Provider = OnnxExecutionProvider.CPU,
                EnableVad = false,
            };

            _speechToText = new SpeechToTextBlock(settings);
            _speechToText.OnSpeechRecognized += SpeechToText_OnSpeechRecognized;
            _core.Audio_Processing_AddBlock(_speechToText);

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
            SetStatus("Transcribing microphone...");
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
            Dispatcher?.Dispatch(() => lbSubtitle.Text = string.Empty);
        }

        private void SpeechToText_OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Segments == null || e.Segments.Length == 0)
            {
                return;
            }

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

        private void Core_OnError(object sender, ErrorsEventArgs e) => Debug.WriteLine(e.Message);

        // Reset the UI when the engine stops on its own (device error, end of stream), not just user STOP.
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
                lbSubtitle.Text = string.Empty;
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
