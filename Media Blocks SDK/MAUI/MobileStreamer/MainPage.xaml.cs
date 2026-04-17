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

        private bool _isSRT;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            this.BindingContext = this;

            VisioForgeX.InitSDK();
        }

        /// <summary>
        /// Main page unloaded.
        /// </summary>
        private void MainPage_Unloaded(object? sender, EventArgs e)
        {
            _pipeline?.Dispose();
            _pipeline = null;

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            var vv = videoView.GetVideoView();

            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };
            _videoRenderer.IsSync = false;

            _pipeline.OnError += Core_OnError;
        }

        /// <summary>
        /// Main page loaded.
        /// </summary>
        private void Log(string msg)
        {
            var line = $"[{DateTime.Now:HH:mm:ss.fff}] {msg}";
            Console.WriteLine("[MobileStreamer] " + line);
            Debug.WriteLine("[MobileStreamer] " + line);
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            try
            {
                Log("MainPage_Loaded: start");

    #if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                Log("Requesting camera permission...");
                await RequestCameraPermissionAsync();
                Log($"Camera permission: {await Permissions.CheckStatusAsync<Permissions.Camera>()}");

                Log("Requesting mic permission...");
                await RequestMicPermissionAsync();
                Log($"Mic permission: {await Permissions.CheckStatusAsync<Permissions.Microphone>()}");
    #endif

    #if __IOS__ && !__MACCATALYST__
                RequestPhotoPermission();

                // iOS requires an active AVAudioSession in PlayAndRecord for the AVF audio
                // queue to deliver samples; without SetActive(true) the input queue starves
                // and the audio source errors with "Internal data stream error".
                try
                {
                    AVFoundation.AVAudioSession.SharedInstance().SetCategory(
                        AVFoundation.AVAudioSessionCategory.PlayAndRecord);
                    AVFoundation.AVAudioSession.SharedInstance().SetActive(true, out var audioErr);
                    if (audioErr != null)
                    {
                        Log($"AVAudioSession.SetActive error: {audioErr.LocalizedDescription}");
                    }
                    else
                    {
                        Log("AVAudioSession activated (PlayAndRecord)");
                    }
                }
                catch (Exception ax)
                {
                    Log($"AVAudioSession init failed: {ax.Message}");
                }
    #endif

                // cameras
                Log("Enumerating video sources...");
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                Log($"Video sources: count={_cameras?.Length ?? -1}");
                if (_cameras != null)
                {
                    for (int i = 0; i < _cameras.Length; i++)
                    {
                        Log($"  cam[{i}]: {_cameras[i].DisplayName}");
                    }
                }
                if (_cameras != null && _cameras.Length > 0)
                {
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // mics
                Log("Enumerating audio sources...");
                _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
                Log($"Audio sources: count={_mics?.Length ?? -1}");
                if (_mics != null)
                {
                    for (int i = 0; i < _mics.Length; i++)
                    {
                        Log($"  mic[{i}]: {_mics[i].DisplayName}");
                    }
                }
                if (_mics != null && _mics.Length > 0)
                {
                    btMic.Text = _mics[0].DisplayName;
                }

                Window.Destroying += Window_Destroying;

                Log("MainPage_Loaded: done");
            }
            catch (Exception ex)
            {
                Log($"EXC in MainPage_Loaded: {ex.GetType().Name}: {ex.Message}");
                Log(ex.StackTrace ?? "(no stack)");
            }
        }

        /// <summary>
        /// Request camera permission async.
        /// </summary>
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
        /// Request mic permission async.
        /// </summary>
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
                    if (await DisplayAlertAsync(null, "You need to allow access to the Microphone", "OK", "Cancel"))
                        await RequestMicPermissionAsync();
                }
            }
        }

#if __IOS__ && !__MACCATALYST__
        /// <summary>
        /// Request photo permission.
        /// </summary>
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

        /// <summary>
        /// Window destroying.
        /// </summary>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Core on error.
        /// </summary>
        private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Log($"pipeline.OnError: {e.Message}");
        }

        /// <summary>
        /// Stop all async.
        /// </summary>
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

            _isSRT = false;
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt camera clicked event.
        /// </summary>
        private async void btCamera_Clicked(object? sender, System.EventArgs e)
        {
            try
            {
                if (_cameras == null || _cameras.Length == 0)
                {
                    _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                    _cameraSelectedIndex = 0;

                    if (_cameras != null && _cameras.Length > 0)
                    {
                        btCamera.Text = _cameras[0].DisplayName;
                    }

                    return;
                }

                _cameraSelectedIndex++;

                if (_cameraSelectedIndex >= _cameras.Length)
                {
                    _cameraSelectedIndex = 0;
                }

                btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt mic clicked event.
        /// </summary>
        private async void btMic_Clicked(object? sender, System.EventArgs e)
        {
            try
            {
                if (_mics == null || _mics.Length == 0)
                {
                    _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
                    _micSelectedIndex = 0;

                    if (_mics != null && _mics.Length > 0)
                    {
                        btMic.Text = _mics[0].DisplayName;
                    }

                    return;
                }

                _micSelectedIndex++;

                if (_micSelectedIndex >= _mics.Length)
                {
                    _micSelectedIndex = 0;
                }

                btMic.Text = _mics[_micSelectedIndex].DisplayName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Configure preview async.
        /// </summary>
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
                await DisplayAlertAsync("Error", "Unable to configure camera settings", "OK");
                return;
            }

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

        /// <summary>
        /// Configure capture.
        /// </summary>
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

        /// <summary>
        /// Handles the bt start you tube clicked event.
        /// </summary>
        private async void btStartYouTube_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                _sink = new YouTubeSinkBlock(new YouTubeSinkSettings(edUrl.Text));

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start facebook clicked event.
        /// </summary>
        private async void btStartFacebook_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                _sink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(edUrl.Text));

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start clicked event.
        /// </summary>
        private async void btStartRTMP_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                // streaming to RTMP server
                _sink = new RTMPSinkBlock(new RTMPSinkSettings() { Location = edUrl.Text });

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start SRT clicked event.
        /// </summary>
        private async void btStartSRT_Clicked(object? sender, EventArgs e)
        {
            try
            {
                Log("btStartSRT_Clicked: enter");

                var uri = edUrl.Text;
                Log($"SRT URI: '{uri}'");
                if (string.IsNullOrWhiteSpace(uri))
                {
                    await DisplayAlertAsync("SRT", "Please set the SRT URI", "OK");
                    return;
                }

                var srtAvailable = SRTMPEGTSSinkBlock.IsAvailable();
                Log($"IsAvailable: SRTMPEGTS={srtAvailable}");

                if (!srtAvailable)
                {
                    Log("srtsink GStreamer element missing — cannot start SRT stream");
                    await DisplayAlertAsync("SRT", "srtsink GStreamer plugin is not available on this platform. SRT streaming cannot start.", "OK");
                    return;
                }

                var latencyStr = await DisplayPromptAsync("SRT Settings", "Latency (ms):", initialValue: "750", keyboard: Keyboard.Numeric);
                if (latencyStr == null)
                    return;

                var latencyMs = int.TryParse(latencyStr, out var lat) ? lat : 750;

                var modeStr = await DisplayActionSheet("SRT Connection Mode", "Cancel", null, "Caller", "Listener", "Rendezvous");
                if (modeStr == null || modeStr == "Cancel")
                    return;

                var mode = modeStr switch
                {
                    "Listener" => SRTConnectionMode.Listener,
                    "Rendezvous" => SRTConnectionMode.Rendezvous,
                    _ => SRTConnectionMode.Caller
                };

                Log($"latencyMs={latencyMs}, mode={mode}");

                Log("StopAllAsync...");
                await StopAllAsync();

                _isSRT = true;

                Log("CreateEngine...");
                CreateEngine();

                Log("ConfigurePreviewAsync...");
                await ConfigurePreviewAsync();

                var srtSettings = new SRTSinkSettings
                {
                    Uri = uri,
                    Latency = TimeSpan.FromMilliseconds(latencyMs),
                    MuxerLatency = TimeSpan.FromMilliseconds(3000),
                    AutoReconnect = true,
                    Mode = mode
                };
                Log($"SRTMPEGTSSinkBlock mode={srtSettings.Mode}");

                _sink = new SRTMPEGTSSinkBlock(srtSettings);

                Log("ConfigureCapture...");
                ConfigureCapture();

                Log("pipeline.StartAsync...");
                await _pipeline.StartAsync();
                Log("pipeline started");
            }
            catch (Exception ex)
            {
                Log($"EXC btStartSRT: {ex.GetType().Name}: {ex.Message}");
                Log(ex.StackTrace ?? "(no stack)");
            }
        }
    }
}
