using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.VideoCaptureX;

namespace SimpleCapture
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private VideoCaptureCoreX _core;

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

            VisioForgeX.DestroySDK();
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__
            await RequestCameraPermissionAsync();
            await RequestMicPermissionAsync();
#endif

//#if __ANDROID__
//            var handler = (VisioForge.Core.UI.MAUI.VideoViewXHandler)videoView.Handler;
//            _core = new VideoCaptureCoreX(handler.VideoView);
//#else
            _core = new VideoCaptureCoreX(videoView);
//#endif

            _core.OnError += Core_OnError;       

            // cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {                
                btCamera.Text = _cameras[0].DisplayName;
            }

            // mics
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            if (_mics.Length > 0)
            {      
                btMic.Text = _mics[0].DisplayName;
            }

            // audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(null);
            if (_speakers.Length > 0)
            {                
                btSpeakers.Text = _speakers[0].DisplayName;
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

        private async Task RequestMicPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Microphone>();

            // Check result from permission request. If it is allowed by the user, connect to scanner
            if (result == PermissionStatus.Granted)
            {
            }
            else
            {
                if (Permissions.ShouldShowRationale<Permissions.Microphone>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Microphone", "OK", "Cancel"))
                        await RequestMicPermissionAsync();
                }
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

            btStartPreview.Text = "PREVIEW";
            btStartCapture.Text = "CAPTURE";
        }

        private void btCamera_Clicked(object sender, System.EventArgs e)
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

        private void btMic_Clicked(object sender, System.EventArgs e)
        {
            if (_mics == null || _mics.Length == 0)
            {
                return;
            }

            _micSelectedIndex++;

            if (_micSelectedIndex >= _mics.Length)
            {
                _micSelectedIndex = 0;
            }

            btMic.Text = _mics[_micSelectedIndex].DisplayName;
        }

        private void btSpeakers_Clicked(object sender, System.EventArgs e)
        {
            if (_speakers == null || _speakers.Length == 0)
            {
                return;
            }

            _speakerSelectedIndex++;

            if (_speakerSelectedIndex >= _speakers.Length)
            {
                _speakerSelectedIndex = 0;
            }

            btSpeakers.Text = _speakers[_speakerSelectedIndex].DisplayName;
        }

        private async Task ConfigurePreviewAsync()
        {
            // audio output
            _core.Audio_OutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == btSpeakers.Text).First();
            _core.Audio_Play = true;

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
                await DisplayAlert("Error", "Unable to configure camera settings", "OK");
            }

            // audio source
            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

            deviceName = btMic.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.GetDefaultFormat();
                    audioSourceSettings = device.CreateSourceSettingsVC(formatItem);
                }
            }

            _core.Audio_Source = audioSourceSettings;
        }

        private void ConfigureCapture()
        {
            var now = DateTime.Now;

#if __ANDROID__
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif

            _core.Outputs_Add(new MP4Output(filename), true);
        }

        private async void btStartPreview_Clicked(object sender, EventArgs e)
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

                        btStartPreview.Text = "PREVIEW";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _core.ResumeAsync();

                        btStartPreview.Text = "PAUSE";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        await ConfigurePreviewAsync();

                        // start
                        await _core.StartAsync();

                        _tmPosition.Start();

                        btStartPreview.Text = "PAUSE";
                    }

                    break;
                default:
                    break;
            }
        }

        private async void btStartCapture_Clicked(object sender, EventArgs e)
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

                        btStartCapture.Text = "CAPTURE";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _core.ResumeAsync();

                        btStartCapture.Text = "PAUSE";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        await ConfigurePreviewAsync();

                        ConfigureCapture();

                        //Gst.Debug.SetDefaultThreshold(Gst.DebugLevel.Debug);

                        // start
                        await _core.StartAsync();                       

                        _tmPosition.Start();

                        btStartCapture.Text = "PAUSE";
                    }

                    break;
                default:
                    break;
            }
        }
    }
}