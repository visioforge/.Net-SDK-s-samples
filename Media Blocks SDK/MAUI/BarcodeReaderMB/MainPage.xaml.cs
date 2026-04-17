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
        private ConcurrentDictionary<string, DateTime> _recentDetections = new();
        private TimeSpan _deduplicationWindow = TimeSpan.FromSeconds(2);
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

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
                    await _pipeline.StopAsync().ConfigureAwait(false);

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

            if (_recentDetections.TryGetValue(key, out var lastTime))
            {
                if (DateTime.Now - lastTime < _deduplicationWindow)
                {
                    return; // Skip duplicate
                }
            }

            _recentDetections[key] = DateTime.Now;

            Debug.WriteLine($"Detected barcode: {e.BarcodeType} = {e.Value}");

            var count = Interlocked.Increment(ref _detectionCount);

            Dispatcher.Dispatch(() =>
            {
                lbBarcodeType.Text = $"Type: {e.BarcodeType}";
                lbBarcodeValue.Text = $"Value: {e.Value}";
                lbDetectionCount.Text = $"Detected: {count}";
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
                await StopScanningAsync(updateUI: false).ConfigureAwait(false);
            }

            _pipeline?.Dispose();
            _pipeline = null;

            VisioForgeX.DestroySDK();
        }
    }
}
