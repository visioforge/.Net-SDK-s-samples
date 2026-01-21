using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace QRReader
{
    /// <summary>
    /// Interaction logic for the MAUI QR Reader demo's MainPage.
    /// Demonstrates how to configure the video capture SDK to detect barcodes using the camera.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        /// <summary>
        /// Handles the Unloaded event of the MainPage.
        /// Disposes of the video capture engine and destroys the SDK.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainPage_Unloaded(object? sender, EventArgs e)
        {
            _core?.Dispose();
            _core = null;

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the Loaded event of the MainPage.
        /// Requests permission, initializes the capture core with the video view, and sets up event handlers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__
            await RequestCameraPermissionAsync();
#endif

            IVideoView vv = videoView.GetVideoView();

            _core = new VideoCaptureCoreX(vv);     

            _core.OnError += Core_OnError;
            _core.OnBarcodeDetected += Core_OnBarcodeDetected;
            //_core.Barcode_Reader_Enabled = true;

            // cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {
                btCamera.Text = _cameras[0].DisplayName;
            }

            Window.Destroying += Window_Destroying;
        }

        /// <summary>
        /// Handles the OnBarcodeDetected event of the video capture core.
        /// Updates the UI with the value of the detected barcode.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="BarcodeDetectorEventArgs"/> instance containing the detection data.</param>
        private void Core_OnBarcodeDetected(object? sender, BarcodeDetectorEventArgs e)
        {
            Debug.WriteLine($"Detected barcode: {e.Value}");

            Dispatcher.Dispatch(() =>
            {
                lbBarcode.Text = $"BARCODE: {e.Value}";
            });
        }

        /// <summary>
        /// Asynchronously requests camera access permissions from the user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            // Check result from permission request. If it is allowed by the user, connect to scanner
            if (result == PermissionStatus.Granted)
            {
            }
            else
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlertAsync(null, "You need to allow access to the Camera", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Play/Stop button.
        /// Starts or stops the video capture based on the current state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btPlayStop_Clicked(object? sender, EventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            switch (_core.State)
            {
                case PlaybackState.Play:
                case PlaybackState.Pause:
                    {
                        await _core.StopAsync();

                        btPlayStop.Text = "START";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        // video source
                        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                        var deviceName = btCamera.Text;
                        if (!string.IsNullOrEmpty(deviceName))
                        {
                            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                            if (device != null)
                            {
                                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
                                if (formatItem != null)
                                {
                                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                                    {
                                        Format = formatItem.ToFormat()
                                    };

                                    videoSourceSettings.Format.FrameRate = frameRate;
                                }
                            }
                        }

                        _core.Video_Source = videoSourceSettings;

                        if (videoSourceSettings == null)
                        {
                            await DisplayAlertAsync("Error", "Unable to configure camera settings", "OK");
                        }

                        await _core.StartAsync();

                        btPlayStop.Text = "STOP";
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the Destroying event of the Window.
        /// Stops and disposes of the video capture core properly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                await _core.StopAsync();

                _core?.Dispose();
                _core = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the OnError event of the video capture core.
        /// Logs error messages to the debug output.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the error information.</param>
        private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Handles the Click event of the Camera button.
        /// Cycles through the available video capture devices.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btCamera_Clicked(object? sender, EventArgs e)
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
    }
}
