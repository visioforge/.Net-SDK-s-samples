using System.Diagnostics;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;
using VisioForge.Core.VideoCaptureX;

namespace Capture_OCR_X
{
    /// <summary>
    /// Inserts a PaddleOCR text recognizer into VideoCaptureCoreX through the X-engine
    /// Video_Processing_AddBlock API. The OCR block taps the live camera frames, draws recognized
    /// text into the preview, and raises OnTextDetected while the engine previews the camera.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;
        private OcrBlock _ocr;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Bundled PP-OCRv5 mobile models copied to app-data on first run (ONNX needs a real path).
        private string _detModelPath;
        private string _recModelPath;
        private string _clsModelPath;
        private string _dictPath;

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
                    // Reset the index with the button text — MAUI reuses the page instance across sessions.
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // Copy bundled OCR models to app-data (ONNX needs a real path); run concurrently.
                var detTask = EnsureAssetAsync("ch_PP-OCRv5_mobile_det.onnx");
                var recTask = EnsureAssetAsync("latin_PP-OCRv5_rec_mobile_infer.onnx");
                var clsTask = EnsureAssetAsync("ch_ppocr_mobile_v2.0_cls_infer.onnx");
                var dictTask = EnsureAssetAsync("ppocrv5_latin_dict.txt");
                await Task.WhenAll(detTask, recTask, clsTask, dictTask);

                // Page torn down while assets copied: don't touch Window/controls.
                if (_isCleanedUp)
                {
                    return;
                }

                _detModelPath = await detTask;
                _recModelPath = await recTask;
                _clsModelPath = await clsTask;
                _dictPath = await dictTask;

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

        // Copy a bundled Resources\Raw asset to app-data once so APIs that need a file path can read it.
        private static async Task<string> EnsureAssetAsync(string fileName)
        {
            var dest = Path.Combine(FileSystem.AppDataDirectory, fileName);
            if (!File.Exists(dest))
            {
                Directory.CreateDirectory(FileSystem.AppDataDirectory);

                // Copy to a unique temp file, then move into place (GUID name avoids concurrent-copy collisions).
                var temp = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid():N}.part");
                try
                {
                    using (var src = await FileSystem.OpenAppPackageFileAsync(fileName))
                    using (var dst = File.Create(temp))
                    {
                        await src.CopyToAsync(dst);
                    }

                    File.Move(temp, dest, overwrite: true);
                }
                catch
                {
                    try { if (File.Exists(temp)) File.Delete(temp); } catch { }

                    // Another instance won the copy race and produced dest — treat as success.
                    if (File.Exists(dest))
                    {
                        return dest;
                    }

                    throw;
                }
            }
            return dest;
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera to recognize text.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
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

            // Models are copied to app-data on Loaded; guard against a cold start where they aren't ready yet.
            if (string.IsNullOrEmpty(_detModelPath) || string.IsNullOrEmpty(_recModelPath)
                || string.IsNullOrEmpty(_dictPath) || string.IsNullOrEmpty(_clsModelPath))
            {
                await DisplayAlert("Please wait", "The models are still being prepared.", "OK");
                return;
            }

            await RecreateEngineAsync();
            if (_core == null || _isCleanedUp)
            {
                return;
            }

            // The camera list can change (e.g. USB unplug) between page load and Start, so re-validate the index.
            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("No camera", "No camera is available. Connect a camera and try again.", "OK");
                return;
            }

            _cameraSelectedIndex = Math.Max(0, Math.Min(_cameras.Length - 1, _cameraSelectedIndex));

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

            // Build the OCR block from the bundled PP-OCRv5 models; DrawResults renders text into the preview.
            var settings = new OcrSettings(_detModelPath, _recModelPath, _dictPath, _clsModelPath)
            {
                DrawResults = true,
                FramesToSkip = 5,
            };

            _ocr = new OcrBlock(settings);
            _ocr.OnTextDetected += Ocr_OnTextDetected;
            _core.Video_Processing_AddBlock(_ocr);

            if (!await _core.StartAsync())
            {
                // Start failed — stop the engine, drop the block, leave the UI stopped.
                await _core.StopAsync();
                DetachBlock();
                SetStatus("Error: failed to start capture.");
                return;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus("Recognizing...");
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

        private void Ocr_OnTextDetected(object sender, OcrTextDetectedEventArgs e)
        {
            var regions = e.Regions;
            var count = regions?.Length ?? 0;

            // Use the first non-empty recognized line for the status label.
            string firstText = null;
            if (regions != null)
            {
                foreach (var region in regions)
                {
                    if (region != null && !string.IsNullOrWhiteSpace(region.Text))
                    {
                        firstText = region.Text;
                        break;
                    }
                }
            }

            // Always dispatch (even on a no-text frame) so the labels reset instead of showing stale values.
            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                SetStatus(firstText != null ? $"Text: {firstText}  |  regions: {count}" : "Recognizing...");
                lbCount.Text = $"Regions: {count}";
            });
        }

        /// <summary>
        /// The engine disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh OCR block.
        /// </summary>
        private void DetachBlock()
        {
            if (_ocr != null)
            {
                _ocr.OnTextDetected -= Ocr_OnTextDetected;
                _ocr = null;
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
            Dispatcher?.Dispatch(() => SetStatus("Engine error: " + e.Message));
        }

        // Reset the UI when the engine stops on its own (device error, end of stream).
        private async void Core_OnStop(object sender, StopEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session so it can't reset the live UI.
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

            // Drain any in-flight Start/Stop and claim the guard before tearing the engine down.
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
