using System.Diagnostics;
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

namespace OcrTextRecognitionMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private OcrBlock _ocr;
        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // Bundled PP-OCRv5 mobile models copied to app-data on first run (ONNX needs a real path).
        private string _detModelPath;
        private string _recModelPath;
        private string _clsModelPath;
        private string _dictPath;

        // Re-entrancy guard for the START/STOP button (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown so a user STOP and page-close cleanup dispose the pipeline exactly once.
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

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

                // Get available cameras
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // Copy the bundled OCR models out of the app package so ONNX can open them by path.
                _detModelPath = await EnsureAssetAsync("ch_PP-OCRv5_mobile_det.onnx");
                _recModelPath = await EnsureAssetAsync("latin_PP-OCRv5_rec_mobile_infer.onnx");
                _clsModelPath = await EnsureAssetAsync("ch_ppocr_mobile_v2.0_cls_infer.onnx");
                _dictPath = await EnsureAssetAsync("ppocrv5_latin_dict.txt");

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

        // Copy a bundled Resources\Raw asset to app-data once so APIs that need a file path can read it.
        private static async Task<string> EnsureAssetAsync(string fileName)
        {
            var dest = Path.Combine(FileSystem.AppDataDirectory, fileName);
            if (!File.Exists(dest))
            {
                Directory.CreateDirectory(FileSystem.AppDataDirectory);

                // Copy to a temp file, then move into place (overwrite-safe against a concurrent first run).
                var temp = dest + ".part";
                using (var src = await FileSystem.OpenAppPackageFileAsync(fileName))
                using (var dst = File.Create(temp))
                {
                    await src.CopyToAsync(dst);
                }

                File.Move(temp, dest, overwrite: true);
            }
            return dest;
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to recognize text", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
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
                    await StopRecognitionAsync();
                }
                else
                {
                    await StartRecognitionAsync();
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

        private async Task StartRecognitionAsync()
        {
            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("Error", "No cameras available", "OK");
                return;
            }

            // The models are copied out of the app package on Loaded; they may not be ready yet on a cold start.
            if (string.IsNullOrEmpty(_detModelPath) || string.IsNullOrEmpty(_recModelPath)
                || string.IsNullOrEmpty(_dictPath) || string.IsNullOrEmpty(_clsModelPath))
            {
                await DisplayAlert("Please wait", "The models are still being prepared.", "OK");
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

                // Create OCR block from the bundled PP-OCRv5 mobile models.
                var ocrSettings = new OcrSettings(_detModelPath, _recModelPath, _dictPath, _clsModelPath)
                {
                    FramesToSkip = 5
                };

                _ocr = new OcrBlock(ocrSettings);
                _ocr.OnTextDetected += Ocr_OnTextDetected;

                // Create video renderer
                IVideoView vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

                // Connect pipeline
                _pipeline.Connect(_videoSource.Output, _ocr.Input);
                _pipeline.Connect(_ocr.Output, _videoRenderer.Input);

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
                btStartStop.Text = "STOP";
                btStartStop.BackgroundColor = Colors.Red;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");

                // Cleanup resources on failure
                if (_ocr != null)
                {
                    _ocr.OnTextDetected -= Ocr_OnTextDetected;
                    _ocr.Dispose();
                    _ocr = null;
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

        private async Task StopRecognitionAsync(bool updateUI = true)
        {
            // Serialize teardown: a user STOP tap and CleanupAsync (page unload / window close) can both
            // reach here. The gate lets the first fully tear down while the second awaits, so the
            // pipeline is disposed exactly once.
            await _teardownGate.WaitAsync();
            try
            {
                // A prior caller (user STOP or page-close cleanup) already tore down — nothing to do.
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
                    if (_ocr != null)
                    {
                        _ocr.OnTextDetected -= Ocr_OnTextDetected;
                    }

                    // DisposeAsync disposes every connected block (camera source, OCR, renderer);
                    // do NOT ClearBlocks first or the block list is emptied before disposal.
                    _pipeline.OnError -= Pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;

                    _ocr = null;
                    _videoRenderer = null;
                    _videoSource = null;

                    _isRunning = false;
                }

                if (updateUI)
                {
                    Dispatcher.Dispatch(() =>
                    {
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

        private void Ocr_OnTextDetected(object sender, OcrTextDetectedEventArgs e)
        {
            var regions = e.Regions;
            var count = regions?.Length ?? 0;

            // Use the first non-empty recognized line for the status label.
            string firstLine = "-";
            if (regions != null)
            {
                foreach (var region in regions)
                {
                    if (region != null && !string.IsNullOrWhiteSpace(region.Text))
                    {
                        firstLine = region.Text;
                        break;
                    }
                }
            }

            Debug.WriteLine($"OCR regions: {count}, first: {firstLine}");

            Dispatcher.Dispatch(() =>
            {
                // Events can arrive after teardown; bail out if we've stopped or cleaned up.
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                try
                {
                    lbStatus.Text = $"Text: {firstLine}";
                    lbCount.Text = $"Regions: {count}";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"OCR UI update failed: {ex.Message}");
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
                await StopRecognitionAsync(updateUI: false);
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
