using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.Core;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System.Display;
using Windows.UI.Core;

namespace PhotoCapture
{
    /// <summary>
    /// Interaction logic for the WinUI Photo Capture demo's MainWindow.
    /// Demonstrates how to capture photos, manage camera settings (resolution, zoom, flash), and display a preview.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MediaCapture _mediaCapture;
        private bool _isInitialized;
        private bool _isPreviewing;
        private DisplayRequest _displayRequest = new DisplayRequest();
        
        // Frame timer for preview
        private DispatcherTimer _frameTimer;
        
        // Store camera device information
        private List<DeviceInformation> _cameraDevices;
        private DeviceInformation _currentCamera;
        
        // Store available resolutions
        private List<VideoEncodingProperties> _availableResolutions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets up the frame timer for UI preview updates and initiates camera enumeration.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            
            // Initialize frame timer
            _frameTimer = new DispatcherTimer();
            _frameTimer.Interval = TimeSpan.FromMilliseconds(33); // ~30 FPS
            _frameTimer.Tick += FrameTimer_Tick;
            
            _ = EnumerateCamerasAsync();
        }

        /// <summary>
        /// Asynchronously enumerates available video capture devices and populates the camera selection UI.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task EnumerateCamerasAsync()
        {
            try
            {
                var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
                _cameraDevices = devices.ToList();

                CameraComboBox.Items.Clear();
                foreach (var device in _cameraDevices)
                {
                    CameraComboBox.Items.Add(device.Name);
                }

                if (_cameraDevices.Count > 0)
                {
                    CameraComboBox.SelectedIndex = 0;
                }
                else
                {
                    StatusTextBlock.Text = "No cameras found";
                    StartCameraButton.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAsync($"Failed to enumerate cameras: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the CameraComboBox.
        /// Updates the currently selected camera and restarts the preview if it is running.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void CameraComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CameraComboBox.SelectedIndex >= 0 && _cameraDevices != null)
            {
                _currentCamera = _cameraDevices[CameraComboBox.SelectedIndex];
                
                // If camera is running, restart with new camera
                if (_isPreviewing)
                {
                    await StopCameraAsync();
                    await StartCameraAsync();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Start Camera button.
        /// Initializes and starts the camera preview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void StartCameraButton_Click(object sender, RoutedEventArgs e)
        {
            await StartCameraAsync();
        }

        /// <summary>
        /// Handles the Click event of the Stop Camera button.
        /// Stops the camera preview and releases resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void StopCameraButton_Click(object sender, RoutedEventArgs e)
        {
            await StopCameraAsync();
        }

        /// <summary>
        /// Initializes the media capture object, starts lighting the frame source, and updates UI controls.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StartCameraAsync()
        {
            try
            {
                if (_currentCamera == null)
                {
                    StatusTextBlock.Text = "Please select a camera";
                    return;
                }

                StatusTextBlock.Text = "Starting camera...";

                _mediaCapture = new MediaCapture();
                var settings = new MediaCaptureInitializationSettings
                {
                    VideoDeviceId = _currentCamera.Id,
                    StreamingCaptureMode = StreamingCaptureMode.Video,
                    PhotoCaptureSource = PhotoCaptureSource.VideoPreview
                };

                await _mediaCapture.InitializeAsync(settings);
                _isInitialized = true;

                // Wire up events
                _mediaCapture.Failed += MediaCapture_Failed;

                // Start frame timer for preview
                _frameTimer.Start();
                _isPreviewing = true;

                // Prevent the device from sleeping while the preview is running
                _displayRequest.RequestActive();

                // Update UI
                StatusTextBlock.Text = "";
                StartCameraButton.IsEnabled = false;
                StopCameraButton.IsEnabled = true;
                TakePhotoButton.IsEnabled = true;

                // Load available resolutions
                await LoadResolutionsAsync();

                // Update zoom controls
                UpdateZoomControls();

                // Update flash controls
                UpdateFlashControls();
            }
            catch (UnauthorizedAccessException)
            {
                await ShowErrorAsync("Access to the camera was denied. Please check your privacy settings.");
            }
            catch (Exception ex)
            {
                await ShowErrorAsync($"Failed to start camera: {ex.Message}");
            }
        }

        /// <summary>
        /// Stops the camera preview, disposes of the media capture object, and resets UI controls.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StopCameraAsync()
        {
            try
            {
                _frameTimer.Stop();
                _isPreviewing = false;

                if (_isInitialized)
                {
                    PreviewImage.Source = null;
                    _mediaCapture.Failed -= MediaCapture_Failed;
                    _mediaCapture.Dispose();
                    _mediaCapture = null;
                    _isInitialized = false;
                }

                // Allow the device to sleep again
                _displayRequest.RequestRelease();

                // Update UI
                StatusTextBlock.Text = "Click 'Start Camera' to begin";
                StartCameraButton.IsEnabled = true;
                StopCameraButton.IsEnabled = false;
                TakePhotoButton.IsEnabled = false;
                ZoomSlider.IsEnabled = false;
                ResolutionComboBox.Items.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping camera: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the Tick event of the frame timer.
        /// Captures a preview frame and processes it for display.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private async void FrameTimer_Tick(object sender, object e)
        {
            if (_mediaCapture != null && _isPreviewing)
            {
                try
                {
                    // Get preview frame
                    using (var previewFrame = await _mediaCapture.GetPreviewFrameAsync())
                    {
                        if (previewFrame != null)
                        {
                            await ProcessFrameAsync(previewFrame);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting preview frame: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Processes a video frame by converting it to a displayable format and updating the Image control.
        /// </summary>
        /// <param name="videoFrame">The video frame to process.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ProcessFrameAsync(VideoFrame videoFrame)
        {
            var softwareBitmap = videoFrame.SoftwareBitmap;
            
            if (softwareBitmap != null)
            {
                if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
                    softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
                {
                    softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, 
                        BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                }

                var source = new SoftwareBitmapSource();
                await source.SetBitmapAsync(softwareBitmap);
                
                // Update the Image control
                PreviewImage.Source = source;
            }
        }

        /// <summary>
        /// Load resolutions async.
        /// </summary>
        private async Task LoadResolutionsAsync()
        {
            try
            {
                ResolutionComboBox.Items.Clear();
                
                var resolutions = _mediaCapture.VideoDeviceController
                    .GetAvailableMediaStreamProperties(MediaStreamType.Photo)
                    .OfType<VideoEncodingProperties>()
                    .ToList();

                _availableResolutions = resolutions
                    .Where(r => r.Width > 0 && r.Height > 0)
                    .OrderByDescending(r => r.Width * r.Height)
                    .ToList();

                foreach (var resolution in _availableResolutions)
                {
                    ResolutionComboBox.Items.Add($"{resolution.Width} x {resolution.Height}");
                }

                if (ResolutionComboBox.Items.Count > 0)
                {
                    ResolutionComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading resolutions: {ex.Message}");
            }
        }

        /// <summary>
        /// Resolution combo box selection changed.
        /// </summary>
        private async void ResolutionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResolutionComboBox.SelectedIndex >= 0 && _availableResolutions != null && _mediaCapture != null)
            {
                try
                {
                    var selectedResolution = _availableResolutions[ResolutionComboBox.SelectedIndex];
                    await _mediaCapture.VideoDeviceController.SetMediaStreamPropertiesAsync(
                        MediaStreamType.Photo, selectedResolution);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error setting resolution: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates the zoom slider based on the current camera's capabilities and settings.
        /// </summary>
        private void UpdateZoomControls()
        {
            if (_mediaCapture?.VideoDeviceController?.ZoomControl?.Supported == true)
            {
                var zoomControl = _mediaCapture.VideoDeviceController.ZoomControl;
                ZoomSlider.Minimum = zoomControl.Min;
                ZoomSlider.Maximum = zoomControl.Max;
                ZoomSlider.Value = zoomControl.Value;
                ZoomSlider.IsEnabled = true;
                ZoomValueTextBlock.Text = $"{zoomControl.Value:F1}x";
            }
            else
            {
                ZoomSlider.IsEnabled = false;
                ZoomValueTextBlock.Text = "N/A";
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the ZoomSlider.
        /// Adjusts the camera zoom level.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs"/> instance containing the event data.</param>
        private void ZoomSlider_ValueChanged(object sender, Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (_mediaCapture?.VideoDeviceController?.ZoomControl?.Supported == true)
            {
                _mediaCapture.VideoDeviceController.ZoomControl.Value = (float)e.NewValue;
                ZoomValueTextBlock.Text = $"{e.NewValue:F1}x";
            }
        }

        /// <summary>
        /// Updates the flash combo box based on the current camera's capabilities.
        /// </summary>
        private void UpdateFlashControls()
        {
            if (_mediaCapture?.VideoDeviceController?.FlashControl?.Supported == true)
            {
                FlashComboBox.IsEnabled = true;
            }
            else
            {
                FlashComboBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the FlashComboBox.
        /// Configures the camera's flash mode (Auto, On, Off).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void FlashComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_mediaCapture?.VideoDeviceController?.FlashControl?.Supported == true && 
                FlashComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var flashControl = _mediaCapture.VideoDeviceController.FlashControl;
                var flashMode = selectedItem.Tag?.ToString();

                switch (flashMode)
                {
                    case "Auto":
                        flashControl.Auto = true;
                        flashControl.Enabled = true;
                        break;
                    case "On":
                        flashControl.Auto = false;
                        flashControl.Enabled = true;
                        break;
                    case "Off":
                        flashControl.Auto = false;
                        flashControl.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Take Photo button.
        /// Initiates the photo capture process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void TakePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            await TakePhotoAsync();
        }

        /// <summary>
        /// Captures a photo using the current settings and saves it to the Pictures library.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task TakePhotoAsync()
        {
            try
            {
                TakePhotoButton.IsEnabled = false;
                
                // Create a file in the Pictures library
                var picturesFolder = KnownFolders.PicturesLibrary;
                var photoFile = await picturesFolder.CreateFileAsync(
                    $"Photo_{DateTime.Now:yyyyMMdd_HHmmss}.jpg", 
                    CreationCollisionOption.GenerateUniqueName);

                // Capture photo using stream
                var encodingProperties = ImageEncodingProperties.CreateJpeg();
                
                // Set the resolution if one is selected
                if (ResolutionComboBox.SelectedIndex >= 0 && _availableResolutions != null)
                {
                    var resolution = _availableResolutions[ResolutionComboBox.SelectedIndex];
                    encodingProperties.Width = resolution.Width;
                    encodingProperties.Height = resolution.Height;
                }

                using (var stream = await photoFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await _mediaCapture.CapturePhotoToStreamAsync(encodingProperties, stream);
                }

                // Show success message
                StatusTextBlock.Text = $"Photo saved to: {photoFile.Path}";
                
                // Clear the message after 3 seconds
                var timer = DispatcherQueue.CreateTimer();
                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Tick += (s, args) =>
                {
                    StatusTextBlock.Text = "";
                    timer.Stop();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                await ShowErrorAsync($"Failed to take photo: {ex.Message}");
            }
            finally
            {
                TakePhotoButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the Failed event of the MediaCapture object.
        /// Displays an error message and stops the camera.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="errorEventArgs">The <see cref="MediaCaptureFailedEventArgs"/> instance containing the error information.</param>
        private async void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            await ShowErrorAsync($"Camera error: {errorEventArgs.Message}");
            await StopCameraAsync();
        }

        /// <summary>
        /// Displays an error message using a content dialog.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ShowErrorAsync(string message)
        {
            var dialog = new ContentDialog
            {
                Title = "Error",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };
            await dialog.ShowAsync();
        }
    }
}