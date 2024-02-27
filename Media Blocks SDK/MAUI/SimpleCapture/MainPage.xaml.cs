using System;
using System.ComponentModel;
using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace SimpleCapture
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private MediaBlocksPipeline _pipeline;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private AudioRendererBlock _audioOutput;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private MP4SinkBlock _mp4Sink;

        private H264EncoderBlock _h264Encoder;

        private MP3EncoderBlock _mp3Encoder;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = 0;

        private AudioCaptureDeviceInfo[] _mics;

        private int _micSelectedIndex = 0;

        private AudioOutputDeviceInfo[] _speakers;

        private int _speakerSelectedIndex = 0;

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

            VisioForgeX.InitSDK();
        }

        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            _pipeline?.Dispose();
            _pipeline = null;

            VisioForgeX.DestroySDK();
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
            await RequestCameraPermissionAsync();
            await RequestMicPermissionAsync();
#endif

            _pipeline = new MediaBlocksPipeline(live: true);
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            _pipeline.OnError += Core_OnError;       

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
            if (_pipeline != null)
            {
                _pipeline.OnError -= Core_OnError;
                await _pipeline.StopAsync();

                _pipeline?.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private void Core_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null)
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
            if (_audioOutput != null)
            {
                _audioOutput.Volume = e.NewValue / 100.0;
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

        private async Task ConfigurePreviewAsync(bool connect)
        {
            // audio output
            _audioOutput = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == btSpeakers.Text).First());

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

            if (videoSourceSettings == null)
            {
                await DisplayAlert("Error", "Unable to configure camera settings", "OK");
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = btMic.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.GetDefaultFormat();
                    audioSourceSettings = device.CreateSourceSettings(formatItem);
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            if (connect)
            {
                _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
                _pipeline.Connect(_audioSource.Output, _audioOutput.Input);
            }
        }

        private void ConfigureCapture()
        {
            // add tee and connect
            _videoTee = new TeeBlock(2);
            _audioTee = new TeeBlock(2);

            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_audioSource.Output, _audioTee.Input);

            // add preview
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipeline.Connect(_audioTee.Outputs[0], _audioOutput.Input);

            // add video encoder
            _h264Encoder = new H264EncoderBlock(H264EncoderBlock.GetDefaultSettings());
            _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

            // add audio encoder
            _mp3Encoder = new MP3EncoderBlock(new MP3EncoderSettings());
            _pipeline.Connect(_audioTee.Outputs[1], _mp3Encoder.Input);

            // add sink
            var now = DateTime.Now;

#if __ANDROID__
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif
            var sinkSettings = new MP4SinkSettings(filename);
            _mp4Sink = new MP4SinkBlock(sinkSettings);
            
            _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
            _pipeline.Connect(_mp3Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
        }

        private async void btStartPreview_Clicked(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            switch (_pipeline.State)
            {
                case PlaybackState.Play:
                    {
                        await _pipeline.PauseAsync();

                        btStartPreview.Text = "PREVIEW";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _pipeline.ResumeAsync();

                        btStartPreview.Text = "PAUSE";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_pipeline.State == PlaybackState.Play || _pipeline.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        await ConfigurePreviewAsync(true);

                        // start
                        await _pipeline.StartAsync();

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
            if (_pipeline == null)
            {
                return;
            }

            switch (_pipeline.State)
            {
                case PlaybackState.Play:
                    {
                        await _pipeline.PauseAsync();

                        btStartCapture.Text = "CAPTURE";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _pipeline.ResumeAsync();

                        btStartCapture.Text = "PAUSE";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_pipeline.State == PlaybackState.Play || _pipeline.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        await ConfigurePreviewAsync(false);

                        ConfigureCapture();

                        //Gst.Debug.SetDefaultThreshold(Gst.DebugLevel.Debug);

                        // start
                        await _pipeline.StartAsync();                       

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