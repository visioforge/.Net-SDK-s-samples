using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
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
using VisioForge.Core.Types.X.VideoEncoders;

namespace MobileStreamer
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private H264EncoderBlock _videoEncoder;

        private MediaBlock _audioEncoder;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = 0;

        private AudioCaptureDeviceInfo[] _mics;

        private int _micSelectedIndex = 0;

        private MediaBlock _sink;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            this.BindingContext = this;

            VisioForgeX.InitSDK();
        }

        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            _pipeline?.Dispose();
            _pipeline = null;

            VisioForgeX.DestroySDK();
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            var vv = videoView.GetVideoView();

            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };
            _videoRenderer.IsSync = false;

            _pipeline.OnError += Core_OnError;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
            await RequestCameraPermissionAsync();
            await RequestMicPermissionAsync();
#endif

#if __IOS__ && !__MACCATALYST__
            RequestPhotoPermission();
#endif

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

#if __IOS__ && !__MACCATALYST__
        private void RequestPhotoPermission()
        {
            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    Debug.WriteLine("Photo library access granted.");
                }
            });
        }
#endif

        private async void Window_Destroying(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Core_OnError;
                await _pipeline.StopAsync();

                _pipeline.Dispose();
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

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _videoEncoder?.Dispose();
            _videoEncoder = null;

            _videoSource?.Dispose();
            _videoSource = null;

            _audioSource?.Dispose();
            _audioSource = null;

            _videoTee?.Dispose();
            _videoTee = null;

            _sink?.Dispose();
            _sink = null;

            _audioEncoder?.Dispose();
            _audioEncoder = null;

            _videoRenderer?.Dispose();
            _videoRenderer = null;
        }

        private async void btStop_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();
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

        private async Task ConfigurePreviewAsync()
        {
            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = btCamera.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = _cameras.FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.GetHDVideoFormatAndFrameRate(out var frameRate);
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
                return;
            }

#if __IOS__ && !__MACCATALYST__
            videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
#endif

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = btMic.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device =
                    (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x =>
                        x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.GetDefaultFormat();
                    audioSourceSettings = device.CreateSourceSettings(formatItem);
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
        }

        private void ConfigureCapture()
        {
            // add tee and connect
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);

            // add preview
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            // add video encoder
            _videoEncoder = new H264EncoderBlock();
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

            // add audio encoder
            _audioEncoder = new AACEncoderBlock();
            _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);

            // connect sink
            _pipeline.Connect(_videoEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));
            _pipeline.Connect(_audioEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio));
        }

        private async void btStartYouTube_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();

            CreateEngine();

            await ConfigurePreviewAsync();

            _sink = new YouTubeSinkBlock(new YouTubeSinkSettings(edKey.Text));

            ConfigureCapture();
            
            await _pipeline.StartAsync();
        }

        private async void btStartFacebook_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();

            CreateEngine();

            await ConfigurePreviewAsync();

            _sink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(edKey.Text));

            ConfigureCapture();

            await _pipeline.StartAsync();
        }

        private async void btStartRTMP_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();

            CreateEngine();

            await ConfigurePreviewAsync();

            // streaming to RTMP server
            _sink = new RTMPSinkBlock(new RTMPSinkSettings() { Location = edKey.Text });

            ConfigureCapture();

            await _pipeline.StartAsync();
        }
    }
}
