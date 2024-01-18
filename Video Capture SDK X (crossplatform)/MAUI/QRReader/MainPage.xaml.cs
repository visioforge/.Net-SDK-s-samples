using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace QRReader
{
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;

        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = 0;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            _core?.Dispose();
            _core = null;

            _deviceEnumerator?.Dispose();
            _deviceEnumerator = null;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__
            await RequestCameraPermissionAsync();
#endif

            _deviceEnumerator = new DeviceEnumerator(
#if __ANDROID__
                Microsoft.Maui.ApplicationModel.Platform.CurrentActivity
#endif
                );

#if __ANDROID__
            _core = new VideoCaptureCoreX(videoView, Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);
#elif __MACCATALYST__ || __IOS__
            _core = new VideoCaptureCoreX(videoView);
#else
            var handler = videoView.Handler as VisioForge.Core.UI.MAUI.VideoViewXHandler;
            _core = new VideoCaptureCoreX(handler.VideoView);            
#endif

            _core.OnError += Core_OnError;
            _core.OnBarcodeDetected += Core_OnBarcodeDetected;
            //_core.Barcode_Reader_Enabled = true;

            // cameras
            _cameras = await _deviceEnumerator.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {
                btCamera.Text = _cameras[0].DisplayName;
            }

            Window.Destroying += Window_Destroying;
        }

        private void Core_OnBarcodeDetected(object sender, BarcodeDetectorEventArgs e)
        {
            Debug.WriteLine($"Detected barcode: {e.Value}");

            Dispatcher.Dispatch(() =>
            {
                lbBarcode.Text = $"BARCODE: {e.Value}";
            });
        }

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
                    if (await DisplayAlert(null, "You need to allow access to the Camera", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        private async void btPlayStop_Clicked(object sender, EventArgs e)
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
                            var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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
                            await DisplayAlert("Error", "Unable to configure camera settings", "OK");
                        }

                        await _core.StartAsync();

                        btPlayStop.Text = "STOP";
                    }

                    break;
                default:
                    break;
            }
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                await _core.StopAsync();

                _core?.Dispose();
                _core = null;
            }
        }

        private void Core_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
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
    }
}