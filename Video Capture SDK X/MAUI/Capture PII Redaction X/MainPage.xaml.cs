using System.Diagnostics;
using System.Net.Http;
using System.Threading;

using SkiaSharp;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;
using VisioForge.Core.VideoCaptureX;

namespace Capture_PII_Redaction_X
{
    /// <summary>
    /// Redacts PII (faces, license plates, on-screen text) on the live VideoCaptureCoreX preview.
    /// The PIIRedactionBlock is inserted through the X-engine Video_Processing_AddBlock API: it taps the
    /// camera frames, blurs/pixelates/fills the detected regions in place, and raises OnRegionsRedacted.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private PIIRedactionBlock _redaction;

        // Shared with the running block; category switches, style, and sliders mutate it live.
        private PIIRedactionSettings _settings;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Cancels an in-flight model download when the page is torn down.
        private CancellationTokenSource _downloadCts;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // ---- Models are hosted on the samples GitHub release and downloaded into the writable app-data
        //      cache on demand. Weights are NOT shipped with the SDK. ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string FaceModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string PlateModelFile = "yolo-v9-t-640-license-plates-end2end.onnx"; // FastALPR (MIT)
        private const string TextDetModelFile = "ch_PP-OCRv5_mobile_det.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextRecModelFile = "latin_PP-OCRv5_rec_mobile_infer.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextDictFile = "ppocrv5_latin_dict.txt";

        // AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        // All models are downloaded into the writable cache on demand.
        private static readonly string[] AllModelFiles =
        {
            FaceModelFile, PlateModelFile, TextDetModelFile, TextRecModelFile, TextDictFile,
        };

        // Optional custom face model chosen via Browse (overrides the cached download).

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
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

            pkStyle.SelectedIndex = 0;
            pkFillColor.SelectedIndex = 0;

            try
            {
#if ANDROID || IOS || MACCATALYST
                await RequestCameraPermissionAsync();
#endif

                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran, so bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // The engine is created fresh per session in StartAsync (RecreateEngineAsync).

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                if (_cameras.Length > 0)
                {
                    // Reset the index alongside the button text (MAUI reuses the page instance).
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                RefreshModelUi();

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
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera to redact the preview.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
            }
        }

        private string CachePath(string fileName) => Path.Combine(ModelsCacheDir, fileName);

        private static bool IsCached(string fileName) => File.Exists(Path.Combine(ModelsCacheDir, fileName));

        private void RefreshModelUi()
        {
            // Category_Toggled can fire during XAML init, before these later-declared controls exist.
            if (btDownloadModels == null || lbFaceModel == null)
            {
                return;
            }

            var anyMissing = AllModelFiles.Any(f => !IsCached(f));
            btDownloadModels.IsVisible = anyMissing;
            lbFaceModel.Text = anyMissing
                ? "Models: tap 'Download models'."
                : "Models ready.";
        }

        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            var missing = AllModelFiles.Where(f => !IsCached(f)).ToList();
            if (missing.Count == 0)
            {
                RefreshModelUi();
                return;
            }

            btDownloadModels.IsEnabled = false;
            var originalText = btDownloadModels.Text;
            btDownloadModels.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            _downloadCts?.Dispose();
            _downloadCts = new CancellationTokenSource();

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);
                for (int i = 0; i < missing.Count; i++)
                {
                    await DownloadOneAsync(missing[i], i + 1, missing.Count, _downloadCts.Token);
                }

                pbDownload.Progress = 1;
                RefreshModelUi();
            }
            catch (OperationCanceledException)
            {
                // Page torn down mid-download; nothing to surface.
                return;
            }
            catch (Exception ex)
            {
                // Don't touch the UI (or show an alert) if the page was torn down mid-download.
                if (_isCleanedUp)
                {
                    return;
                }

                lbFaceModel.Text = "Download failed.";
                await DisplayAlert("Download failed", $"{ex.Message}\n\nModels come from {ModelsReleaseUrl}", "OK");
            }
            finally
            {
                pbDownload.IsVisible = false;
                btDownloadModels.IsEnabled = true;
                btDownloadModels.Text = originalText;
            }
        }

        // Streams one model to a .part temp file (idle-timeout guarded) then renames it in. Throws to stop the batch.
        private async Task DownloadOneAsync(string fileName, int index, int total, CancellationToken cancellationToken)
        {
            var dest = CachePath(fileName);
            var temp = dest + ".part";
            lbFaceModel.Text = $"Downloading {fileName} ({index}/{total})...";

            try
            {
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        using (var src = await response.Content.ReadAsStreamAsync(cancellationToken))
                        using (var fileStream = File.Create(temp))
                        using (var idleCts = new CancellationTokenSource())
                        using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(idleCts.Token, cancellationToken))
                        {
                            // ResponseHeadersRead means HttpClient.Timeout only bounds the header read, not the
                            // body stream; guard the copy with an idle timeout that resets after each chunk. The
                            // linked token also fires when the page is torn down (cancellationToken).
                            var idleTimeout = TimeSpan.FromSeconds(100);
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            idleCts.CancelAfter(idleTimeout);
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length, linkedCts.Token)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read, linkedCts.Token);
                                idleCts.CancelAfter(idleTimeout);
                                readTotal += read;

                                if (totalBytes > 0)
                                {
                                    var percent = (int)(readTotal * 100 / totalBytes);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            pbDownload.Progress = percent / 100.0;
                                            lbFaceModel.Text = $"Downloading {fileName} ({index}/{total})... {percent}%";
                                        });
                                    }
                                }
                            }

                            if (totalBytes > 0 && readTotal != totalBytes)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {totalBytes} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // Idle timeout fired (not a page teardown): report it as a clear failure instead of a silent cancel.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw new TimeoutException($"Download of {fileName} timed out due to inactivity.");
            }
            catch
            {
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
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
                try { await _core.DisposeAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
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

            var faces = swFaces.IsToggled;
            var plates = swPlates.IsToggled;
            var text = swText.IsToggled;

            if (!faces && !plates && !text)
            {
                await DisplayAlert("Nothing to redact", "Enable at least one category (Faces, Plates, or Text).", "OK");
                return;
            }

            // Every required model must be in the cache (downloaded).
            var missing = new System.Collections.Generic.List<string>();
            if (faces && !IsCached(FaceModelFile)) missing.Add(FaceModelFile);
            if (plates && !IsCached(PlateModelFile)) missing.Add(PlateModelFile);
            if (text)
            {
                if (!IsCached(TextDetModelFile)) missing.Add(TextDetModelFile);
                if (!IsCached(TextRecModelFile)) missing.Add(TextRecModelFile);
                if (!IsCached(TextDictFile)) missing.Add(TextDictFile);
            }

            if (missing.Count > 0)
            {
                await DisplayAlert("Models required",
                    "Tap 'Download models' first, or turn off the categories you don't need.", "OK");
                return;
            }

            // Reject an invalid text-filter regex up front (matches the WPF demo).
            var regexPattern = edRegex.Text?.Trim();
            if (text && !string.IsNullOrEmpty(regexPattern))
            {
                try
                {
                    _ = new System.Text.RegularExpressions.Regex(regexPattern);
                }
                catch (ArgumentException ex)
                {
                    await DisplayAlert("Invalid regex", "Invalid text filter regex: " + ex.Message, "OK");
                    return;
                }
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

            _settings = BuildSettings(faces, plates, text);
            _redaction = new PIIRedactionBlock(_settings);
            _redaction.OnRegionsRedacted += Redaction_OnRegionsRedacted;
            _core.Video_Processing_AddBlock(_redaction);

            try
            {
                if (!await _core.StartAsync())
                {
                    // Start failed: tear the engine down (StopAsync also releases the camera and detaches the block).
                    await StopAsync();
                    SetStatus("Error: failed to start capture.");
                    return;
                }
            }
            catch
            {
                // A failed build disposes the block inside the engine; drop our stale reference.
                DetachBlock();
                throw;
            }

            // The page may have been torn down while StartAsync awaited; don't flip the UI to a running state.
            if (_isCleanedUp)
            {
                return;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Redacting...");
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

        // Reads the current UI into a fresh settings object (used at Start).
        private PIIRedactionSettings BuildSettings(bool faces, bool plates, bool text)
        {
            var settings = new PIIRedactionSettings
            {
                Style = (PIIRedactionStyle)Math.Max(0, pkStyle.SelectedIndex),
                BlurRadius = (float)slBlur.Value,
                PixelateBlockSize = (int)slPixelate.Value,
                FillColor = SelectedFillColor(),
            };

            settings.Faces.Enabled = faces;
            settings.Faces.ModelPath = CachePath(FaceModelFile);
            settings.LicensePlates.Enabled = plates;
            settings.LicensePlates.ModelPath = CachePath(PlateModelFile);
            settings.Text.Enabled = text;
            settings.Text.DetectionModelPath = CachePath(TextDetModelFile);
            settings.Text.RecognitionModelPath = CachePath(TextRecModelFile);
            settings.Text.CharacterDictionaryPath = CachePath(TextDictFile);

            var regex = edRegex.Text?.Trim();
            if (!string.IsNullOrEmpty(regex))
            {
                settings.Text.TextFilterRegex = regex;
            }

            return settings;
        }

        private SKColor SelectedFillColor()
        {
            switch (pkFillColor.SelectedIndex)
            {
                case 1: return SKColors.White;
                case 2: return SKColors.Gray;
                default: return SKColors.Black;
            }
        }

        // Live-updates the shared settings while capture runs; a category off/on toggles live only if it
        // was enabled at Start (its detector is built then). Otherwise it takes effect on the next Start.
        private void Category_Toggled(object sender, ToggledEventArgs e)
        {
            if (_settings != null)
            {
                _settings.Faces.Enabled = swFaces.IsToggled;
                _settings.LicensePlates.Enabled = swPlates.IsToggled;
                _settings.Text.Enabled = swText.IsToggled;
            }

            RefreshModelUi();
        }

        private void pkStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_settings != null && pkStyle.SelectedIndex >= 0)
            {
                _settings.Style = (PIIRedactionStyle)pkStyle.SelectedIndex;
            }
        }

        private void slBlur_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // ValueChanged can fire during XAML init, before lbBlur (declared after the slider) exists.
            if (lbBlur != null)
            {
                lbBlur.Text = ((int)slBlur.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.BlurRadius = (float)slBlur.Value;
            }
        }

        private void slPixelate_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lbPixelate != null)
            {
                lbPixelate.Text = ((int)slPixelate.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.PixelateBlockSize = (int)slPixelate.Value;
            }
        }

        private void Redaction_OnRegionsRedacted(object sender, PIIRegionsRedactedEventArgs e)
        {
            int faces = 0, plates = 0, text = 0;
            foreach (var region in e.Regions)
            {
                switch (region.Category)
                {
                    case PIICategory.Face: faces++; break;
                    case PIICategory.LicensePlate: plates++; break;
                    case PIICategory.Text: text++; break;
                }
            }

            var status = $"Redacted: {faces} face(s), {plates} plate(s), {text} text";

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
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh block.
        /// </summary>
        private void DetachBlock()
        {
            if (_redaction != null)
            {
                _redaction.OnRegionsRedacted -= Redaction_OnRegionsRedacted;
                _redaction = null;
            }

            _settings = null;
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

            // Abort an in-flight model download so it can't keep streaming after teardown, then release it.
            try { _downloadCts?.Cancel(); _downloadCts?.Dispose(); } catch (ObjectDisposedException) { }

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
                // Isolate each step so a throwing StopAsync can't skip DisposeAsync + DestroySDK below.
                try { await _core.StopAsync(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                try { await _core.DisposeAsync(); } catch (Exception disposeEx) { Debug.WriteLine(disposeEx); }
                _core = null;
            }

            DetachBlock();

            VisioForgeX.DestroySDK();
        }
    }
}
