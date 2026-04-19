using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
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
    /// <summary>
    /// Interaction logic for MainWindow.axaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline? _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock? _videoRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private SystemVideoSourceBlock? _videoSource;

        /// <summary>
        /// The barcode detector.
        /// </summary>
        private BarcodeDetectorBlock? _barcodeDetector;

        /// <summary>
        /// The detection count.
        /// </summary>
        private int _detectionCount = 0;

        /// <summary>
        /// The recent detections.
        /// </summary>
        private ConcurrentDictionary<string, DateTime> _recentDetections = new();

        /// <summary>
        /// The deduplication window.
        /// </summary>
        private TimeSpan _deduplicationWindow = TimeSpan.FromSeconds(2);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private async void MainWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize SDK
                Title += " [INITIALIZING SDK...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [INITIALIZING SDK...]", "");

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                // Enumerate video sources
                DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object? sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.UIThread.Post(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);

                if (cbVideoInput.Items.Count == 1)
                {
                    cbVideoInput.SelectedIndex = 0;
                }
            });
        }

        private async void cbVideoInput_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex < 0)
                    return;

                cbVideoFormat.Items.Clear();

                var deviceName = cbVideoInput.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(deviceName))
                    return;

                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                    .FirstOrDefault(x => x.DisplayName == deviceName);

                if (device != null)
                {
                    foreach (var format in device.VideoFormats)
                    {
                        cbVideoFormat.Items.Add(format.Name);
                    }

                    if (cbVideoFormat.Items.Count > 0)
                    {
                        cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void cbVideoFormat_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Format selected, ready to start
        }

        private async void btStart_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex < 0)
                {
                    Debug.WriteLine("Please select a video input device");
                    return;
                }

                try
                {
                    // Create pipeline
                    _pipeline = new MediaBlocksPipeline();
                    _pipeline.OnError += Pipeline_OnError;

                    // Configure video source
                    var deviceName = cbVideoInput.SelectedItem?.ToString();
                    var formatName = cbVideoFormat.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(formatName))
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        _pipeline.Dispose();
                        _pipeline = null;
                        Debug.WriteLine("Please select device and format");
                        return;
                    }

                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                        .FirstOrDefault(x => x.DisplayName == deviceName);

                    if (device == null)
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        _pipeline.Dispose();
                        _pipeline = null;
                        Debug.WriteLine("Device not found");
                        return;
                    }

                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == formatName);
                    if (formatItem == null)
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        _pipeline.Dispose();
                        _pipeline = null;
                        Debug.WriteLine("Format not found");
                        return;
                    }

                    var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };

                    // Default frame rate
                    videoSourceSettings.Format.FrameRate = new VideoFrameRate(30);

                    _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                    // Create barcode detector block
                    _barcodeDetector = new BarcodeDetectorBlock(BarcodeDetectorMode.InputOutput);
                    _barcodeDetector.OnBarcodeDetected += BarcodeDetector_OnBarcodeDetected;

                    // Create video renderer
                    _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

                    // Connect pipeline
                    _pipeline.Connect(_videoSource.Output, _barcodeDetector.Input);
                    _pipeline.Connect(_barcodeDetector.Output, _videoRenderer.Input);

                    // Start
                    await _pipeline.StartAsync();

                    btStart.IsEnabled = false;
                    btStop.IsEnabled = true;
                    cbVideoInput.IsEnabled = false;
                    cbVideoFormat.IsEnabled = false;
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
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStop_Click(object? sender, RoutedEventArgs e)
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

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                cbVideoInput.IsEnabled = true;
                cbVideoFormat.IsEnabled = true;

                videoView.InvalidateVisual();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping: {ex.Message}");
            }
        }

        private void BarcodeDetector_OnBarcodeDetected(object? sender, BarcodeDetectorEventArgs e)
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

            Dispatcher.UIThread.Post(() =>
            {
                lbBarcodeType.Text = e.BarcodeType;
                lbBarcodeValue.Text = e.Value;
                lbDetectionCount.Text = $"Detected: {count}";
            });
        }

        private void Pipeline_OnError(object? sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        private async void MainWindow_Closing(object? sender, WindowClosingEventArgs e)
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

                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.ClearBlocks();
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                DeviceEnumerator.Shared.OnVideoSourceAdded -= DeviceEnumerator_OnVideoSourceAdded;

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
