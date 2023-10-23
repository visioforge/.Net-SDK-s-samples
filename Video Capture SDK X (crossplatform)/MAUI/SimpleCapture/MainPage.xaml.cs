using System.Diagnostics;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace SimpleCapture
{
    public partial class MainPage : ContentPage
    {
        private VideoCaptureCoreX _core;

        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureDeviceInfo[] _cameras;

        private AudioCaptureDeviceInfo[] _mics;

        private AudioOutputDeviceInfo[] _speakers;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            _tmPosition.Elapsed += tmPosition_Elapsed;
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

            // cameras
            _cameras = await _deviceEnumerator.VideoSourcesAsync();
            pkCamera.ItemsSource = _cameras.Select(x => x.DisplayName).ToList();

            if (_cameras.Length > 0)
            {                
                pkCamera.SelectedIndex = 0;
            }

            // mics
            _mics = await _deviceEnumerator.AudioSourcesAsync(null);
            pkMic.ItemsSource = _mics.Select(x => x.DisplayName).ToList();

            if (_mics.Length > 0)
            {                
                pkMic.SelectedIndex = 0;
            }

            // audio outputs
            _speakers = await _deviceEnumerator.AudioOutputsAsync(null);
            pkSpeakers.ItemsSource = _speakers.Select(x => x.DisplayName).ToList();

            if (_speakers.Length > 0)
            {                
                pkSpeakers.SelectedIndex = 0;
            }

            Window.Destroying += Window_Destroying;
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

                        _tmPosition.Start();

                        btPlayPause.Text = "PAUSE";
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

                _core.Dispose();
                _core = null;
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

            _tmPosition.Stop();

            if (_core != null)
            {
                await _core.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            //var pos = await _core.Position_GetAsync();
            //var progress = (int)pos.TotalMilliseconds;

            //try
            //{
            //    MainThread.BeginInvokeOnMainThread(() =>
            //    {
            //        if (_player == null)
            //        {
            //            return;
            //        }

            //        _isTimerUpdate = true;

            //        if (progress > slSeeking.Maximum)
            //        {
            //            slSeeking.Value = slSeeking.Maximum;
            //        }
            //        else
            //        {
            //            slSeeking.Value = progress;
            //        }

            //        // This is where the received data is passed
            //        lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
            //        lbDuration.Text = $"{_player.Duration().ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

            //        _isTimerUpdate = false;
            //    });
            //}
            //catch (Exception exception)
            //{
            //    System.Diagnostics.Debug.WriteLine(exception);
            //}
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