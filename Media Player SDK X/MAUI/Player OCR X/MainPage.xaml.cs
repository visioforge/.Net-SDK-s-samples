using System.Diagnostics;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;

namespace Player_OCR_X
{
    /// <summary>
    /// Inserts a PaddleOCR text recognizer into MediaPlayerCoreX through the X-engine
    /// Video_Processing_AddBlock API. The OCR block taps the decoded video, draws recognized
    /// text regions into the rendered frame, and raises OnTextDetected while the engine plays a file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;
        private OcrBlock _ocr;

        // Local app-data copy of the picked file (iOS/Mac picker paths are security-scoped — play from this copy).
        private string _filePath;

        // Picked media is copied here; AppDataDirectory is writable and engine-accessible on every platform.
        private static string OpenedMediaDir => Path.Combine(FileSystem.AppDataDirectory, "opened_media");

        // Bundled PP-OCRv5 mobile models copied to app-data on first run (ONNX needs a real path).
        private string _detModelPath;
        private string _recModelPath;
        private string _clsModelPath;
        private string _dictPath;

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
                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await: CleanupAsync already ran, so bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // The engine is created fresh per session in StartAsync (RecreatePlayerAsync).

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

                // Drop stale copied media from previous runs (no file in use yet).
                try { if (string.IsNullOrEmpty(_filePath) && Directory.Exists(OpenedMediaDir)) Directory.Delete(OpenedMediaDir, true); } catch (Exception ex) { Debug.WriteLine(ex); }

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

                // Copy to a unique temp file, then move into place (per-copy GUID avoids concurrent copies colliding).
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

            // The models are copied out of the app package on Loaded; they may not be ready yet on a cold start.
            if (string.IsNullOrEmpty(_detModelPath) || string.IsNullOrEmpty(_recModelPath)
                || string.IsNullOrEmpty(_dictPath) || string.IsNullOrEmpty(_clsModelPath))
            {
                await DisplayAlert("Please wait", "The models are still being prepared.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a media file first.", "OK");
                return;
            }

            await RecreatePlayerAsync();
            if (_player == null || _isCleanedUp)
            {
                return;
            }

            // Build the source first (a CreateAsync failure must not strand a registered block).
            // iOS exposes only the NSUrl overload; other platforms use the string overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filePath), renderVideo: true, renderAudio: false);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filePath, renderVideo: true, renderAudio: false);
#endif

            // Build the OCR block; DrawResults renders recognized text regions into the displayed frame.
            var settings = new OcrSettings(_detModelPath, _recModelPath, _dictPath, _clsModelPath)
            {
                DrawResults = true,
                FramesToSkip = 5,
            };

            _ocr = new OcrBlock(settings);
            _ocr.OnTextDetected += Ocr_OnTextDetected;
            _player.Video_Processing_AddBlock(_ocr);

            _player.Video_Play = true;
            _player.Audio_Play = false;

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
            SetStatus("Recognizing...");
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

            // Always dispatch (even on a no-text frame) so the status resets instead of keeping stale text.
            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                SetStatus(firstText != null ? $"Text: {firstText}  |  regions: {count}" : "Recognizing...");
            });
        }

        /// <summary>
        /// The engine disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves). The next START re-creates a fresh block.
        /// </summary>
        private void DetachBlock()
        {
            if (_ocr != null)
            {
                _ocr.OnTextDetected -= Ocr_OnTextDetected;
                _ocr = null;
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

                // Ignore a stale Stop from a previous session (explicit Stop -> Start) so it can't reset the live UI.
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
            });
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
            Dispatcher?.Dispatch(() => SetStatus("Engine error: " + e.Message));
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
