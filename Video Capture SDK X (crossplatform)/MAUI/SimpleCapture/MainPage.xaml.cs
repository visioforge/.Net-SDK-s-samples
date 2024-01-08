using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.VideoCaptureX;

namespace SimpleCapture
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private VideoCaptureCoreX _core;

        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = -1;

        private AudioCaptureDeviceInfo[] _mics;

        private int _micSelectedIndex = -1;

        private AudioOutputDeviceInfo[] _speakers;

        private int _speakerSelectedIndex = -1;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            this.BindingContext = this;

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
            if (_cameras.Length > 0)
            {                
                lbCamera.Text = _cameras[0].DisplayName;
            }

            // mics
            _mics = await _deviceEnumerator.AudioSourcesAsync(null);
            if (_mics.Length > 0)
            {      
                lbMic.Text = _mics[0].DisplayName;
            }

            // audio outputs
            _speakers = await _deviceEnumerator.AudioOutputsAsync(null);
            if (_speakers.Length > 0)
            {                
                lbSpeakers.Text = _speakers[0].DisplayName;
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

                        // audio output
                        _core.Audio_OutputDevice = (await _deviceEnumerator.AudioOutputsAsync()).Where(device => device.DisplayName == lbSpeakers.Text).First();
                        _core.Audio_Play = true;

                        // video source
                        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                        var deviceName = lbCamera.Text;
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

                        // audio source
                        IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

                        deviceName = lbMic.Text;
                        if (!string.IsNullOrEmpty(deviceName))
                        {
                            var device = (await _deviceEnumerator.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                            if (device != null)
                            {
                                var formatItem = device.GetDefaultFormat();
                                if (formatItem != null)
                                {
                                    audioSourceSettings = device.CreateSourceSettingsVC(formatItem);
                                }
                            }
                        }

                        _core.Audio_Source = audioSourceSettings;

                        // start
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

                _core?.Dispose();
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

        private void btPrevCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras.Length == 0)
            {
                return;
            }

            _cameraSelectedIndex--;

            if (_cameraSelectedIndex < 0)
            {
                _cameraSelectedIndex = _cameras.Length - 1;
            }

            lbCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
        }

        private void btNextCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras.Length == 0)
            {
                return;
            }

            _cameraSelectedIndex++;

            if (_cameraSelectedIndex >= _cameras.Length)
            {
                _cameraSelectedIndex = 0;
            }

            lbCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
        }

        private void btNextMic_Clicked(object sender, EventArgs e)
        {
            if (_mics.Length == 0)
            {
                return;
            }

            _micSelectedIndex++;

            if (_micSelectedIndex >= _mics.Length)
            {
                _micSelectedIndex = 0;
            }

            lbMic.Text = _mics[_micSelectedIndex].DisplayName;
        }

        private void btPrevMic_Clicked(object sender, EventArgs e)
        {
            if (_mics.Length == 0)
            {
                return;
            }

            _micSelectedIndex--;

            if (_micSelectedIndex < 0)
            {
                _micSelectedIndex = _mics.Length - 1;
            }

            lbMic.Text = _mics[_micSelectedIndex].DisplayName;
        }

        private void btPrevSpeakers_Clicked(object sender, EventArgs e)
        {
            if (_speakers.Length == 0)
            {
                return;
            }

            _speakerSelectedIndex--;

            if (_speakerSelectedIndex < 0)
            {
                _speakerSelectedIndex = _speakers.Length - 1;
            }

            lbSpeakers.Text = _speakers[_speakerSelectedIndex].DisplayName;
        }

        private void btNextSpeakers_Clicked(object sender, EventArgs e)
        {
            if (_speakers.Length == 0)
            {
                return;
            }

            _speakerSelectedIndex++;

            if (_speakerSelectedIndex >= _speakers.Length)
            {
                _speakerSelectedIndex = 0;
            }

            lbSpeakers.Text = _speakers[_speakerSelectedIndex].DisplayName;
        }
    }
}