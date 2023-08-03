using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace QRReader
{
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;

        private DeviceEnumerator _deviceEnumerator = new DeviceEnumerator();

        private VideoCaptureDeviceInfo[] _cameras;

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
#if __ANDROID__
            await RequestCameraPermissionAsync();
#endif

#if ANDROID
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity; 
            _core = new VideoCaptureCoreX(videoView, activity, VisioForge.Core.Types.PlatformType.Android);
#else
            _core = new VideoCaptureCoreX(videoView);
#endif
            _core.OnError += Core_OnError;
            _core.OnBarcodeDetected += Core_OnBarcodeDetected;
            _core.Barcode_Reader_Enabled = true;            

            // cameras
            _cameras = await _deviceEnumerator.VideoSourcesAsync();
            pkCamera.ItemsSource = _cameras.Select(x => x.DisplayName).ToList();

            if (_cameras.Length > 0)
            {                
                pkCamera.SelectedIndex = 0;
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

        private async void btPlayPause_Clicked(object sender, EventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            switch (_core.State)
            {
                case PlaybackState.Play:
                    {
                        await _core.PauseAsync();

                        btPlayPause.Text = "PLAY";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _core.ResumeAsync();

                        btPlayPause.Text = "PAUSE";
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

                        var deviceName = pkCamera.SelectedItem.ToString();
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

                        btPlayPause.Text = "PAUSE";
                    }

                    break;
                default:
                    break;
            }
        }

        private void Window_Destroying(object sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.Stop();

                _core.Dispose();
                _core = null;
            }
        }

        private void OnStop(object sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.Stop();
            }
        }

        private void Core_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_core == null)
            {
                return;
            }

            if (_core != null)
            {
                await _core.StopAsync();
            }
        }

        private void slVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_core != null)
            {
                _core.Audio_OutputDevice_Volume = e.NewValue / 100.0;
            }
        }

        private async void btStop_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();

            btPlayPause.Text = "PLAY";
        }
    }    
}