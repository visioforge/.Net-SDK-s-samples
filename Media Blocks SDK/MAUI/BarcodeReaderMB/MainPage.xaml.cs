using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace BarcodeReaderMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private BarcodeDetectorBlock _barcodeDetector;
        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private int _detectionCount = 0;
        private ConcurrentDictionary<string, long> _recentDetections = new();
        private const long DeduplicationWindowMs = 2000;
        // Prune stale _recentDetections entries once the dictionary crosses this threshold.
        // Without the prune a long scanning session with many unique codes would accumulate
        // entries forever — the dedup check above only keeps entries 'warm' within
        // DeduplicationWindowMs, older ones are dead weight.
        private const int PruneThreshold = 256;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Interlocked re-entrancy guard for btStartStop_Clicked. async void handlers can be
        // tapped again before the previous invocation's first await completes — and because
        // _isRunning only flips true after StartAsync returns (line ~164), the second tap
        // would see false and re-enter StartScanningAsync, overwriting _pipeline and leaking
        // the first attempt's blocks. 0 = free, 1 = busy; cleared in a finally.
        private int _startStopBusy;

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

                Window.Destroying += Window_Destroying;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to scan barcodes", "OK", "Cancel"))
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
                    await StopScanningAsync();
                }
                else
                {
                    await StartScanningAsync();
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

        private async Task StartScanningAsync()
        {
            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("Error", "No cameras available", "OK");
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
                    _pipeline.Dispose();
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

                // Create barcode detector block
                _barcodeDetector = new BarcodeDetectorBlock(BarcodeDetectorMode.InputOutput);
                _barcodeDetector.OnBarcodeDetected += BarcodeDetector_OnBarcodeDetected;

                // Create video renderer
                IVideoView vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

                // Connect pipeline
                _pipeline.Connect(_videoSource.Output, _barcodeDetector.Input);
                _pipeline.Connect(_barcodeDetector.Output, _videoRenderer.Input);

                // Start
                await _pipeline.StartAsync();

                _isRunning = true;
                btStartStop.Text = "STOP";
                btStartStop.BackgroundColor = Colors.Red;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");

                // Cleanup resources on failure
                if (_barcodeDetector != null)
                {
                    _barcodeDetector.OnBarcodeDetected -= BarcodeDetector_OnBarcodeDetected;
                    _barcodeDetector.Dispose();
                    _barcodeDetector = null;
                }

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _videoSource?.Dispose();
                _videoSource = null;

                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                await DisplayAlert("Error", $"Failed to start: {ex.Message}", "OK");
            }
        }

        private async Task StopScanningAsync(bool updateUI = true)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();

                    if (_barcodeDetector != null)
                    {
                        _barcodeDetector.OnBarcodeDetected -= BarcodeDetector_OnBarcodeDetected;
                    }

                    _pipeline.ClearBlocks();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                _isRunning = false;

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
        }

        private void BarcodeDetector_OnBarcodeDetected(object sender, BarcodeDetectorEventArgs e)
        {
            // Implement duplicate detection
            string key = $"{e.BarcodeType}:{e.Value}";

            var now = Environment.TickCount64;

            // AddOrUpdate atomically resolves read+update in one step. The separate
            // TryGetValue→indexer pattern let two concurrent detections for the same key
            // both observe an older timestamp, both pass the dedup check, and both fire the
            // UI update — the ConcurrentDictionary's internal bucket lock closes that window.
            bool isDuplicate = false;
            _recentDetections.AddOrUpdate(
                key,
                _ => now,
                (_, existing) =>
                {
                    if (now - existing < DeduplicationWindowMs)
                    {
                        isDuplicate = true;
                        return existing; // keep the older timestamp; suppress this detection
                    }
                    return now;
                });

            if (isDuplicate)
            {
                return;
            }

            // Lazy prune: once the dictionary grows past the threshold, drop every entry that
            // couldn't possibly still dedupe a future detection (older than the dedup window).
            // ConcurrentDictionary iteration is snapshot-safe; TryRemove ignores entries that
            // were already updated by another thread between the read and the remove.
            if (_recentDetections.Count > PruneThreshold)
            {
                var cutoff = now - DeduplicationWindowMs;
                foreach (var kvp in _recentDetections)
                {
                    if (kvp.Value < cutoff)
                    {
                        _recentDetections.TryRemove(kvp);
                    }
                }
            }

            Debug.WriteLine($"Detected barcode: {e.BarcodeType} = {e.Value}");

            var count = Interlocked.Increment(ref _detectionCount);

            Dispatcher.Dispatch(() =>
            {
                // Detection events can arrive after Stop unhooks the handler if GStreamer
                // fired the event between StopAsync and the unhook (or between the unhook
                // and the Dispatcher callback). Bail out if we've torn down — touching the
                // labels after Unloaded throws on MAUI iOS. try/catch as belt-and-braces
                // for any other transient UI-state edge cases.
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                try
                {
                    lbBarcodeType.Text = $"Type: {e.BarcodeType}";
                    lbBarcodeValue.Text = $"Value: {e.Value}";
                    lbDetectionCount.Text = $"Detected: {count}";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"BarcodeDetector UI update failed: {ex.Message}");
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

            if (_isRunning)
            {
                await StopScanningAsync(updateUI: false);
            }

            _pipeline?.Dispose();
            _pipeline = null;

            VisioForgeX.DestroySDK();
        }
    }
}
