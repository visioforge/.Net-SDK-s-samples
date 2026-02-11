using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.GenICam;

namespace GenICam_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private MediaBlock _source;
        private MP4OutputBlock _mp4Output;
        private TeeBlock _videoTee;
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);
        private GenICamCamera _currentCamera;
        private string _currentCameraDeviceId;

        public MainWindow()
        {
            InitializeComponent();
            
            // Set default capture filename
            var defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            if (!Directory.Exists(defaultPath))
            {
                try
                {
                    Directory.CreateDirectory(defaultPath);
                }
                catch
                {
                    defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
            
            tbFilename.Text = Path.Combine(defaultPath, "capture.mp4");
            
            // Update GenTL path display
            UpdateGenTLPathDisplay();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            // Clean up MP4 output
            _mp4Output?.Dispose();
            _mp4Output = null;
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private void UpdateRecordingTime()
        {
            if (_pipeline == null)
            {
                return;
            }

            var elapsed = _pipeline.Position_Get();

            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (_mp4Output != null)
                {
                    // Capture mode - show recording time and filename
                    var filename = Path.GetFileName(tbFilename.Text);
                    lbTimestamp.Text = $"Recording: {elapsed:hh\\:mm\\:ss} | {filename}";
                }
                else
                {
                    // Preview mode - show elapsed time
                    lbTimestamp.Text = $"Preview: {elapsed:hh\\:mm\\:ss}";
                }
            }));
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateEngine();

                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
                _pipeline.Debug_Mode = true;

                var selectedCameraName = cbCamera.Text;
                if (string.IsNullOrEmpty(selectedCameraName))
                {
                    MessageBox.Show("No camera selected!");
                    return;
                }

                // Check if capture mode and validate filename
                bool isCaptureMode = rbCapture.IsChecked == true;
                if (isCaptureMode)
                {
                    string filename = tbFilename.Text.Trim();
                    if (string.IsNullOrEmpty(filename))
                    {
                        MessageBox.Show("Please specify an output filename for MP4 capture!");
                        return;
                    }

                    // Ensure directory exists
                    var directory = Path.GetDirectoryName(filename);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        try
                        {
                            Directory.CreateDirectory(directory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to create directory: {ex.Message}");
                            return;
                        }
                    }
                }

                // Open the camera for streaming if not already open
                if (!string.IsNullOrEmpty(_currentCameraDeviceId) && !GenICamCameraManager.IsCameraOpen(_currentCameraDeviceId))
                {
                    if (!GenICamCameraManager.OpenCamera(_currentCameraDeviceId))
                    {
                        MessageBox.Show("Failed to open camera for streaming!");
                        return;
                    }
                }

                // Create source
                var settings = new GenICamSourceSettings(selectedCameraName);
                _source = new GenICamSourceBlock(settings);

                if (isCaptureMode)
                {
                    // Capture to MP4 mode
                    string filename = tbFilename.Text.Trim();
                    _mp4Output = new MP4OutputBlock(new MP4SinkSettings(filename), H264EncoderBlock.GetDefaultSettings(), aacSettings: null); // Uses default H264 encoders without audio

                    // Create and connect Tee
                    _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                    _pipeline.Connect(_source.Output, _videoTee.Input);

                    // Create video input for MP4 output
                    var videoInput = _mp4Output.CreateNewInput(MediaBlockPadMediaType.Video);

                    // Connect source to MP4 output
                    _pipeline.Connect(_videoTee.Outputs[0], videoInput);

                    // Also add preview if desired
                    _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };
                    _pipeline.Connect(_videoTee.Outputs[1], _videoRenderer.Input);
                }
                else
                {
                    // Preview only mode
                    _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };
                    _pipeline.Connect(_source.Output, _videoRenderer.Input);
                }

                await _pipeline.StartAsync();

                tmRecording.Start();

                // Update UI status
                UpdateConnectionStatus();

                // Update button text and status
                if (isCaptureMode)
                {
                    lbTimestamp.Text = "Recording to: " + Path.GetFileName(tbFilename.Text);
                }
                else
                {
                    lbTimestamp.Text = "Preview mode";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting camera: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tmRecording.Stop();
                await DestroyEngineAsync();

                // Clean up MP4 output
                _mp4Output?.Dispose();
                _mp4Output = null;

                // Close the camera
                if (!string.IsNullOrEmpty(_currentCameraDeviceId))
                {
                    GenICamCameraManager.CloseCamera(_currentCameraDeviceId);
                }

                // Update UI status
                UpdateConnectionStatus();
                lbTimestamp.Text = "Stopped";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping camera: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt refresh click event.
        /// </summary>
        private async void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadCameraList();
                UpdateGenTLPathDisplay();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb camera selection changed.
        /// </summary>
        private async void cbCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbCamera.SelectedItem != null)
                {
                    await LoadCameraInformation(cbCamera.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt update settings click event.
        /// </summary>
        private async void btUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentCamera != null)
                {
                    UpdateCurrentCameraSettings();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt browse click event.
        /// </summary>
        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Select MP4 Output File",
                Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*",
                DefaultExt = "mp4",
                FileName = "capture.mp4"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                tbFilename.Text = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;

                try
                {
                    await VisioForgeX.InitSDKAsync();
                    this.IsEnabled = true;
                    Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                    CreateEngine();

                    Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                    tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

                    await LoadCameraList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing SDK: {ex.Message}");
                    this.IsEnabled = true;
                    Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", " - ERROR");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_currentCameraDeviceId))
                {
                    GenICamCameraManager.CloseCamera(_currentCameraDeviceId);
                }
                GenICamCameraManager.ForceCleanup();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during shutdown: {ex.Message}");
            }
        }

        #region Camera Information Methods

        /// <summary>
        /// Update gen tl path display.
        /// </summary>
        private void UpdateGenTLPathDisplay()
        {
            try
            {
                var genTLPath = Environment.GetEnvironmentVariable("GENICAM_GENTL64_PATH");
                if (!string.IsNullOrEmpty(genTLPath))
                {
                    tbGenTLPath.Text = genTLPath;
                    Debug.WriteLine($"GenTL Path: {genTLPath}");
                }
                else
                {
                    tbGenTLPath.Text = "GENICAM_GENTL64_PATH not set";
                    Debug.WriteLine("GENICAM_GENTL64_PATH environment variable is not set");
                }
            }
            catch (Exception ex)
            {
                tbGenTLPath.Text = $"Error reading GenTL path: {ex.Message}";
                Debug.WriteLine($"Error reading GENICAM_GENTL64_PATH: {ex.Message}");
            }
        }

        /// <summary>
        /// Load camera list.
        /// </summary>
        private async Task LoadCameraList()
        {
            try
            {
                cbCamera.Items.Clear();
                
                // Force device list update to ensure we get the latest cameras
                Debug.WriteLine("Updating camera device list...");
                GenICamCameraManager.UpdateDeviceList();

                var devices = await DeviceEnumerator.Shared.GenICamSourcesAsync();
                Debug.WriteLine($"Found {devices.Length} GenICam devices");
                
                foreach (var device in devices)
                {
                    // Use CameraName or DeviceId as fallback
                    var displayName = !string.IsNullOrEmpty(device.CameraName) ? device.CameraName : device.DeviceId;
                    cbCamera.Items.Add(displayName);
                    Debug.WriteLine($"Added camera to list: {displayName} (DeviceId: {device.DeviceId})");
                }

               // AravisCameraManager.UpdateDeviceList();

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                    Debug.WriteLine($"Selected first camera: {cbCamera.Items[0]}");
                }
                else
                {
                    ClearCameraInformation();
                    Debug.WriteLine("No GenICam cameras found");
                    MessageBox.Show("No GenICam cameras found!\n\nPlease check:\n- Camera is connected and powered\n- Drivers are installed\n- Camera is not being used by another application");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading camera list: {ex.Message}");
                MessageBox.Show($"Error loading camera list: {ex.Message}");
            }
        }

        /// <summary>
        /// Load camera information.
        /// </summary>
        private async Task LoadCameraInformation(string cameraName)
        {
            try
            {
                if (string.IsNullOrEmpty(cameraName))
                {
                    ClearCameraInformation();
                    return;
                }

                // Close previous camera if exists
                if (!string.IsNullOrEmpty(_currentCameraDeviceId) && _currentCamera != null)
                {
                    GenICamCameraManager.CloseCamera(_currentCameraDeviceId);
                }
                _currentCamera = null;

                // Store the current camera device ID
                _currentCameraDeviceId = cameraName;

                // Try to create camera instance for detailed info
                try
                {
                    Debug.WriteLine($"Attempting to connect to camera: '{cameraName}'");

                    try
                    {
                        _currentCamera = GenICamCameraManager.GetCamera(_currentCameraDeviceId);
                        if (_currentCamera != null && GenICamCameraManager.OpenCamera(_currentCameraDeviceId))
                        {
                            Debug.WriteLine($"Successfully opened camera: '{_currentCameraDeviceId}'");
                            
                            // Read all camera information to populate CameraInfo
                            _currentCamera.ReadInfo();
                            Debug.WriteLine("Camera information read successfully");
                        }
                        else
                        {
                            Debug.WriteLine($"Failed to open camera: '{_currentCameraDeviceId}'");
                            _currentCamera = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Failed to get/open camera '{_currentCameraDeviceId}': {ex.Message}");
                        if (!string.IsNullOrEmpty(_currentCameraDeviceId))
                        {
                            GenICamCameraManager.CloseCamera(_currentCameraDeviceId);
                        }
                        _currentCamera = null;
                    }

                    if (_currentCamera != null)
                    {
                        DisplayCameraInformation();
                        UpdateCurrentCameraSettings();

                        // Show advanced camera features in debug output
                        ShowAdvancedCameraFeatures();
                        TestCameraFeatures();
                    }
                    else
                    {
                        Debug.WriteLine("Could not create camera with any identifier");
                        DisplayBasicCameraInformation();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Could not create camera instance: {ex.Message}");
                    DisplayBasicCameraInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading camera information: {ex.Message}");
                ClearCameraInformation();
            }
        }

        /// <summary>
        /// Display camera information.
        /// </summary>
        private void DisplayCameraInformation()
        {
            if (_currentCamera == null) return;

            try
            {
                // Basic Information Tab
                tbVendor.Text = !string.IsNullOrEmpty(_currentCamera.VendorName) ? _currentCamera.VendorName : "-";
                tbModel.Text = !string.IsNullOrEmpty(_currentCamera.ModelName) ? _currentCamera.ModelName : "-";
                tbSerial.Text = !string.IsNullOrEmpty(_currentCamera.SerialNumber) ? _currentCamera.SerialNumber : "-";
                tbDeviceId.Text = !string.IsNullOrEmpty(_currentCamera.DeviceId) ? _currentCamera.DeviceId : (_currentCameraDeviceId ?? "-");
                tbProtocol.Text = !string.IsNullOrEmpty(_currentCamera.Protocol) ? _currentCamera.Protocol : "GenICam";
                tbAddress.Text = !string.IsNullOrEmpty(_currentCamera.Address) ? _currentCamera.Address : (_currentCameraDeviceId ?? "-");
                
                (int Width, int Height) sensorSize;
                if (_currentCamera.SensorSize.Width > 0)
                {
                    sensorSize = _currentCamera.SensorSize;
                }
                else
                {
                    sensorSize = _currentCamera.GetSensorSize();
                }
                tbSensorSize.Text = $"{sensorSize.Width} x {sensorSize.Height}";
                
                tbStatus.Text = _currentCamera.IsConnected ? "Connected" : "Disconnected";

                // Technical Specifications Tab
                DisplayTechnicalSpecifications();

                // Update connection status
                UpdateConnectionStatus();
                
                Debug.WriteLine($"Camera information displayed - Vendor: {tbVendor.Text}, Model: {tbModel.Text}, Serial: {tbSerial.Text}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error displaying camera information: {ex.Message}");
                DisplayBasicCameraInformation();
            }
        }

        /// <summary>
        /// Display basic camera information.
        /// </summary>
        private void DisplayBasicCameraInformation()
        {
            if (string.IsNullOrEmpty(_currentCameraDeviceId)) return;

            // Basic Information Tab - display what we can
            tbVendor.Text = "-";
            tbModel.Text = "-";
            tbSerial.Text = "-";
            tbDeviceId.Text = _currentCameraDeviceId;
            tbProtocol.Text = "GenICam";
            tbAddress.Text = _currentCameraDeviceId;
            tbSensorSize.Text = "-";
            tbStatus.Text = "Available";

            // Technical Specifications Tab (limited info)
            DisplayTechnicalSpecifications();
        }

        /// <summary>
        /// Display technical specifications.
        /// </summary>
        private void DisplayTechnicalSpecifications()
        {
            // Pixel Formats
            lbPixelFormats.Items.Clear();
            
            // If we have camera instance, show available formats from camera directly
            if (_currentCamera != null)
            {
                try
                {
                    var cameraFormats = _currentCamera.AvailablePixelFormats ?? _currentCamera.GetAvailablePixelFormats();
                    var displayNames = _currentCamera.AvailablePixelFormatDisplayNames ?? _currentCamera.GetAvailablePixelFormatDisplayNames();

                    if (cameraFormats != null && displayNames != null)
                    {
                        for (int i = 0; i < Math.Min(cameraFormats.Length, displayNames.Length); i++)
                        {
                            lbPixelFormats.Items.Add($"{displayNames[i]} ({cameraFormats[i]})");
                        }
                    }
                    else if (cameraFormats != null)
                    {
                        foreach (var format in cameraFormats)
                        {
                            lbPixelFormats.Items.Add(format);
                        }
                    }
                    
                    Debug.WriteLine($"Loaded {lbPixelFormats.Items.Count} pixel formats");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting pixel formats from camera: {ex.Message}");
                    lbPixelFormats.Items.Add("Error loading formats");
                }
            }

            // Resolution Capabilities
            if (_currentCamera != null)
            {
                try
                {
                    (int Min, int Max, int Increment) widthBounds;
                    if (_currentCamera.WidthBounds.Min > 0)
                    {
                        widthBounds = _currentCamera.WidthBounds;
                    }
                    else
                    {
                        var bounds = _currentCamera.GetWidthBounds();
                        widthBounds = (bounds.Min, bounds.Max, 1); // Default increment of 1
                    }
                    tbWidthRange.Text = $"{widthBounds.Min} - {widthBounds.Max} (Inc: {widthBounds.Increment})";
                    Debug.WriteLine($"Width bounds: {tbWidthRange.Text}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting width bounds: {ex.Message}");
                    tbWidthRange.Text = "-";
                }

                try
                {
                    (int Min, int Max, int Increment) heightBounds;
                    if (_currentCamera.HeightBounds.Min > 0)
                    {
                        heightBounds = _currentCamera.HeightBounds;
                    }
                    else
                    {
                        var bounds = _currentCamera.GetHeightBounds();
                        heightBounds = (bounds.Min, bounds.Max, 1); // Default increment of 1
                    }
                    tbHeightRange.Text = $"{heightBounds.Min} - {heightBounds.Max} (Inc: {heightBounds.Increment})";
                    Debug.WriteLine($"Height bounds: {tbHeightRange.Text}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting height bounds: {ex.Message}");
                    tbHeightRange.Text = "-";
                }

                try
                {
                    if (_currentCamera.FrameRateAvailable)
                    {
                        (double Min, double Max) frameRateBounds;
                        if (_currentCamera.FrameRateBounds.Min > 0)
                        {
                            frameRateBounds = _currentCamera.FrameRateBounds;
                        }
                        else
                        {
                            frameRateBounds = _currentCamera.GetFrameRateBounds();
                        }
                        tbFrameRate.Text = $"{frameRateBounds.Min:F2} - {frameRateBounds.Max:F2} FPS";
                        Debug.WriteLine($"Frame rate bounds: {tbFrameRate.Text}");
                    }
                    else
                    {
                        tbFrameRate.Text = "Not available";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting frame rate bounds: {ex.Message}");
                    tbFrameRate.Text = "-";
                }
            }
            else
            {
                tbWidthRange.Text = "-";
                tbHeightRange.Text = "-";
                tbFrameRate.Text = "-";
            }

            // Check feature availability
            if (_currentCamera != null)
            {
                try
                {
                    cbExposureAvailable.IsChecked = _currentCamera.ExposureTimeAvailable;
                    cbGainAvailable.IsChecked = _currentCamera.GainAvailable;
                    cbFrameRateAvailable.IsChecked = _currentCamera.FrameRateAvailable;
                    cbBinningAvailable.IsChecked = _currentCamera.BinningAvailable;

                    if (_currentCamera.BinningAvailable)
                    {
                        var binning = _currentCamera.CurrentBinning;
                        tbBinning.Text = $"Current: {binning.Horizontal} x {binning.Vertical}";
                        
                        // Try to get binning bounds
                        try
                        {
                            if (_currentCamera.IsFeatureAvailable("BinningHorizontalMax") && _currentCamera.IsFeatureAvailable("BinningVerticalMax"))
                            {
                                var hMax = _currentCamera.GetIntegerFeature("BinningHorizontalMax");
                                var vMax = _currentCamera.GetIntegerFeature("BinningVerticalMax");
                                tbBinning.Text += $" (Max: {hMax} x {vMax})";
                            }
                        }
                        catch (Exception binningEx)
                        {
                            Debug.WriteLine($"Error getting binning bounds: {binningEx.Message}");
                        }
                    }
                    else
                    {
                        tbBinning.Text = "Not supported";
                    }
                    
                    Debug.WriteLine($"Feature availability - Exposure: {cbExposureAvailable.IsChecked}, Gain: {cbGainAvailable.IsChecked}, FrameRate: {cbFrameRateAvailable.IsChecked}, Binning: {cbBinningAvailable.IsChecked}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error checking camera features: {ex.Message}");
                    cbExposureAvailable.IsChecked = false;
                    cbGainAvailable.IsChecked = false;
                    cbFrameRateAvailable.IsChecked = false;
                    cbBinningAvailable.IsChecked = false;
                    tbBinning.Text = "Unknown";
                }
            }
            else
            {
                cbExposureAvailable.IsChecked = false;
                cbGainAvailable.IsChecked = false;
                cbFrameRateAvailable.IsChecked = false;
                cbBinningAvailable.IsChecked = false;
                tbBinning.Text = "Unknown";
            }
        }

        /// <summary>
        /// Update current camera settings.
        /// </summary>
        private void UpdateCurrentCameraSettings()
        {
            if (_currentCamera == null)
            {
                ClearCurrentSettings();
                return;
            }

            try
            {
                // Current Region
                (int X, int Y, int Width, int Height) region;
                if (_currentCamera.CurrentRegion.Width > 0)
                {
                    region = _currentCamera.CurrentRegion;
                }
                else
                {
                    region = _currentCamera.GetRegion();
                }
                tbCurrentRegion.Text = $"X:{region.X}, Y:{region.Y}, W:{region.Width}, H:{region.Height}";

                // Current Pixel Format
                tbCurrentPixelFormat.Text = !string.IsNullOrEmpty(_currentCamera.PixelFormat) ? _currentCamera.PixelFormat : _currentCamera.GetPixelFormatString();

                // Current Exposure
                if (_currentCamera.ExposureTimeAvailable)
                {
                    var exposure = _currentCamera.CurrentExposureTime > 0 ? _currentCamera.CurrentExposureTime : _currentCamera.GetExposureTime();
                    tbCurrentExposure.Text = $"{exposure:F2} μs";
                    
                    // Show exposure bounds
                    if (_currentCamera.ExposureTimeBounds.Min > 0)
                    {
                        tbCurrentExposure.Text += $" (Range: {_currentCamera.ExposureTimeBounds.Min:F2} - {_currentCamera.ExposureTimeBounds.Max:F2} μs)";
                    }
                }
                else
                {
                    tbCurrentExposure.Text = "Not available";
                }

                // Current Gain
                if (_currentCamera.GainAvailable)
                {
                    var gain = _currentCamera.CurrentGain > 0 ? _currentCamera.CurrentGain : _currentCamera.GetGain();
                    tbCurrentGain.Text = $"{gain:F2} dB";
                    
                    // Show gain bounds
                    if (_currentCamera.GainBounds.Min >= 0)
                    {
                        tbCurrentGain.Text += $" (Range: {_currentCamera.GainBounds.Min:F2} - {_currentCamera.GainBounds.Max:F2} dB)";
                    }
                }
                else
                {
                    tbCurrentGain.Text = "Not available";
                }

                // Current Frame Rate
                if (_currentCamera.FrameRateAvailable)
                {
                    var frameRate = !_currentCamera.CurrentFrameRate.IsEmpty ? _currentCamera.CurrentFrameRate : _currentCamera.GetFrameRate();
                    tbCurrentFrameRate.Text = $"{frameRate:F2} FPS";
                    
                    // Show frame rate bounds
                    if (_currentCamera.FrameRateBounds.Min > 0)
                    {
                        tbCurrentFrameRate.Text += $" (Range: {_currentCamera.FrameRateBounds.Min:F2} - {_currentCamera.FrameRateBounds.Max:F2} FPS)";
                    }
                }
                else
                {
                    tbCurrentFrameRate.Text = "Not available";
                }

                // Current Binning
                if (_currentCamera.BinningAvailable)
                {
                    (int Horizontal, int Vertical) binning;
                    if (_currentCamera.CurrentBinning.Horizontal > 0)
                    {
                        binning = _currentCamera.CurrentBinning;
                    }
                    else
                    {
                        binning = _currentCamera.GetBinning();
                    }
                    tbCurrentBinning.Text = $"{binning.Horizontal} x {binning.Vertical}";
                }
                else
                {
                    tbCurrentBinning.Text = "Not available";
                }

                // Connection Status
                tbConnectionStatus.Text = _currentCamera.IsConnected ? "Connected" : "Disconnected";

                // Acquisition Status
                tbAcquisitionStatus.Text = _pipeline != null && _pipeline.State == VisioForge.Core.Types.PlaybackState.Play ? "Running" : "Stopped";
                
                Debug.WriteLine($"Current settings updated - Region: {tbCurrentRegion.Text}, Format: {tbCurrentPixelFormat.Text}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating current camera settings: {ex.Message}");
                ClearCurrentSettings();
            }
        }

        /// <summary>
        /// Update connection status.
        /// </summary>
        private void UpdateConnectionStatus()
        {
            if (_currentCamera != null)
            {
                tbConnectionStatus.Text = _currentCamera.IsConnected ? "Connected" : "Disconnected";
            }
            else
            {
                tbConnectionStatus.Text = "Not connected";
            }

            tbAcquisitionStatus.Text = _pipeline != null && _pipeline.State == VisioForge.Core.Types.PlaybackState.Play ? "Running" : "Stopped";
        }

        /// <summary>
        /// Clear camera information.
        /// </summary>
        private void ClearCameraInformation()
        {
            // Basic Information
            tbVendor.Text = "-";
            tbModel.Text = "-";
            tbSerial.Text = "-";
            tbDeviceId.Text = "-";
            tbProtocol.Text = "-";
            tbAddress.Text = "-";
            tbSensorSize.Text = "-";
            tbStatus.Text = "-";

            // Technical Specifications
            lbPixelFormats.Items.Clear();
            tbWidthRange.Text = "-";
            tbHeightRange.Text = "-";
            tbFrameRate.Text = "-";
            tbBinning.Text = "-";

            cbExposureAvailable.IsChecked = false;
            cbGainAvailable.IsChecked = false;
            cbFrameRateAvailable.IsChecked = false;
            cbBinningAvailable.IsChecked = false;

            ClearCurrentSettings();
        }

        /// <summary>
        /// Clear current settings.
        /// </summary>
        private void ClearCurrentSettings()
        {
            tbCurrentRegion.Text = "-";
            tbCurrentPixelFormat.Text = "-";
            tbCurrentExposure.Text = "-";
            tbCurrentGain.Text = "-";
            tbCurrentFrameRate.Text = "-";
            tbCurrentBinning.Text = "-";
            tbAcquisitionStatus.Text = "-";
            tbConnectionStatus.Text = "-";
        }

        #endregion

        #region Advanced Camera Information Methods

        /// <summary>
        /// Gets additional camera features and displays them
        /// </summary>
        private void ShowAdvancedCameraFeatures()
        {
            if (_currentCamera == null) return;

            try
            {
                Debug.WriteLine("=== Advanced Camera Features ===");
                Debug.WriteLine($"Camera: {_currentCamera.CameraName} ({_currentCamera.VendorName} {_currentCamera.ModelName})");
                Debug.WriteLine($"Serial Number: {_currentCamera.SerialNumber}");
                Debug.WriteLine($"Protocol: {_currentCamera.Protocol}");
                Debug.WriteLine($"Address: {_currentCamera.Address}");
                Debug.WriteLine($"Last Updated: {_currentCamera.LastUpdated}");

                // Display sensor information
                Debug.WriteLine("\n--- Sensor Information ---");
                Debug.WriteLine($"Sensor Size: {_currentCamera.SensorSize.Width} x {_currentCamera.SensorSize.Height}");
                Debug.WriteLine($"Current Region: X:{_currentCamera.CurrentRegion.X}, Y:{_currentCamera.CurrentRegion.Y}, W:{_currentCamera.CurrentRegion.Width}, H:{_currentCamera.CurrentRegion.Height}");

                // Display resolution capabilities
                Debug.WriteLine("\n--- Resolution Capabilities ---");
                Debug.WriteLine($"Width Range: {_currentCamera.WidthBounds.Min} - {_currentCamera.WidthBounds.Max} (Inc: {_currentCamera.WidthBounds.Increment})");
                Debug.WriteLine($"Height Range: {_currentCamera.HeightBounds.Min} - {_currentCamera.HeightBounds.Max} (Inc: {_currentCamera.HeightBounds.Increment})");
                Debug.WriteLine($"X Offset Range: {_currentCamera.XOffsetBounds.Min} - {_currentCamera.XOffsetBounds.Max} (Inc: {_currentCamera.XOffsetBounds.Increment})");
                Debug.WriteLine($"Y Offset Range: {_currentCamera.YOffsetBounds.Min} - {_currentCamera.YOffsetBounds.Max} (Inc: {_currentCamera.YOffsetBounds.Increment})");

                // Display pixel formats
                Debug.WriteLine("\n--- Pixel Formats ---");
                Debug.WriteLine($"Current Pixel Format: {_currentCamera.PixelFormat}");
                if (_currentCamera.AvailablePixelFormats != null && _currentCamera.AvailablePixelFormats.Length > 0)
                {
                    Debug.WriteLine($"Available Formats ({_currentCamera.AvailablePixelFormats.Length}):");
                    for (int i = 0; i < _currentCamera.AvailablePixelFormats.Length && i < 20; i++) // Limit to first 20
                    {
                        var format = _currentCamera.AvailablePixelFormats[i];
                        var displayName = _currentCamera.AvailablePixelFormatDisplayNames != null && 
                                         i < _currentCamera.AvailablePixelFormatDisplayNames.Length ? 
                                         _currentCamera.AvailablePixelFormatDisplayNames[i] : format;
                        Debug.WriteLine($"  {displayName} ({format})");
                    }
                    if (_currentCamera.AvailablePixelFormats.Length > 20)
                    {
                        Debug.WriteLine($"  ... and {_currentCamera.AvailablePixelFormats.Length - 20} more formats");
                    }
                }

                // Display exposure information
                Debug.WriteLine("\n--- Exposure Control ---");
                Debug.WriteLine($"Exposure Available: {_currentCamera.ExposureTimeAvailable}");
                if (_currentCamera.ExposureTimeAvailable)
                {
                    Debug.WriteLine($"Current Exposure: {_currentCamera.CurrentExposureTime:F2} μs");
                    Debug.WriteLine($"Exposure Range: {_currentCamera.ExposureTimeBounds.Min:F2} - {_currentCamera.ExposureTimeBounds.Max:F2} μs");
                }

                // Display gain information
                Debug.WriteLine("\n--- Gain Control ---");
                Debug.WriteLine($"Gain Available: {_currentCamera.GainAvailable}");
                if (_currentCamera.GainAvailable)
                {
                    Debug.WriteLine($"Current Gain: {_currentCamera.CurrentGain:F2} dB");
                    Debug.WriteLine($"Gain Range: {_currentCamera.GainBounds.Min:F2} - {_currentCamera.GainBounds.Max:F2} dB");
                }

                // Display frame rate information
                Debug.WriteLine("\n--- Frame Rate Control ---");
                Debug.WriteLine($"Frame Rate Available: {_currentCamera.FrameRateAvailable}");
                if (_currentCamera.FrameRateAvailable)
                {
                    Debug.WriteLine($"Current Frame Rate: {_currentCamera.CurrentFrameRate:F2} FPS");
                    Debug.WriteLine($"Frame Rate Range: {_currentCamera.FrameRateBounds.Min:F2} - {_currentCamera.FrameRateBounds.Max:F2} FPS");
                }

                // Display binning information
                Debug.WriteLine("\n--- Binning Control ---");
                Debug.WriteLine($"Binning Available: {_currentCamera.BinningAvailable}");
                if (_currentCamera.BinningAvailable)
                {
                    Debug.WriteLine($"Current Binning: {_currentCamera.CurrentBinning.Horizontal} x {_currentCamera.CurrentBinning.Vertical}");
                }

                // Display acquisition mode
                Debug.WriteLine("\n--- Acquisition Settings ---");
                Debug.WriteLine($"Current Acquisition Mode: {_currentCamera.CurrentAcquisitionMode}");
                Debug.WriteLine($"Is Streaming: {_currentCamera.IsStreaming}");
                Debug.WriteLine($"Is Connected: {_currentCamera.IsConnected}");

                // Check for some common GenICam features
                Debug.WriteLine("\n--- GenICam Feature Availability ---");
                string[] commonFeatures = {
                    "DeviceTemperature", "DeviceVendorName", "DeviceModelName", "DeviceVersion", 
                    "DeviceFirmwareVersion", "DeviceSerialNumber", "SensorWidth", "SensorHeight",
                    "WidthMax", "HeightMax", "PixelSize", "AcquisitionMode", "TriggerMode", 
                    "TriggerSource", "ExposureAuto", "GainAuto", "BalanceWhiteAuto", 
                    "GammaEnable", "BlackLevel", "TestPattern", "UserSetDefault"
                };

                var availableFeatures = new List<string>();
                foreach (var feature in commonFeatures)
                {
                    try
                    {
                        if (_currentCamera.IsFeatureAvailable(feature))
                        {
                            availableFeatures.Add(feature);
                            Debug.WriteLine($"  ✓ {feature}");
                        }
                        else
                        {
                            Debug.WriteLine($"  ✗ {feature}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"  ? {feature}: Error checking - {ex.Message}");
                    }
                }

                Debug.WriteLine($"\nSummary: {availableFeatures.Count}/{commonFeatures.Length} common features available");
                Debug.WriteLine("=== End Advanced Camera Features ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error showing advanced camera features: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests camera feature access
        /// </summary>
        private void TestCameraFeatures()
        {
            if (_currentCamera == null) return;

            try
            {
                Debug.WriteLine("=== Camera Feature Test ===");

                // Test string features
                try
                {
                    if (_currentCamera.IsFeatureAvailable("DeviceVendorName"))
                    {
                        var vendor = _currentCamera.GetStringFeature("DeviceVendorName");
                        Debug.WriteLine($"Device Vendor (direct): {vendor}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting vendor name: {ex.Message}");
                }

                // Test integer features
                try
                {
                    if (_currentCamera.IsFeatureAvailable("WidthMax"))
                    {
                        var widthMax = _currentCamera.GetIntegerFeature("WidthMax");
                        Debug.WriteLine($"Max Width (direct): {widthMax}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting max width: {ex.Message}");
                }

                // Test float features
                try
                {
                    if (_currentCamera.IsFeatureAvailable("DeviceTemperature"))
                    {
                        var temp = _currentCamera.GetFloatFeature("DeviceTemperature");
                        Debug.WriteLine($"Device Temperature: {temp:F1}°C");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting device temperature: {ex.Message}");
                }

                // Test boolean features
                try
                {
                    if (_currentCamera.IsFeatureAvailable("AcquisitionFrameRateEnable"))
                    {
                        var frameRateEnabled = _currentCamera.GetBooleanFeature("AcquisitionFrameRateEnable");
                        Debug.WriteLine($"Frame Rate Control Enabled: {frameRateEnabled}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting frame rate enable status: {ex.Message}");
                }

                Debug.WriteLine("=== End Feature Test ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during camera feature test: {ex.Message}");
            }
        }

        #endregion
    }
}