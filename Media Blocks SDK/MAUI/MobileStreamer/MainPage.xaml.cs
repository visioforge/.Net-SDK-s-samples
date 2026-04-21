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

        // Re-entrancy guard for start handlers. async void handlers can be triggered
        // again before the previous invocation's await completes, which otherwise races
        // on _pipeline / _sink. Interlocked flip so the check is safe even if the MAUI
        // dispatcher marshals clicks across threads.
        private int _operationInProgress;

        // Separate re-entrancy guard for the stop handler. Stop must be able to preempt
        // a hung Start (the whole point of a stop button), so it can't share the start
        // guard — but two simultaneous stop taps would still race on _pipeline disposal.
        private int _stopInProgress;

        // Guards against rapid-taps on btCamera/btMic: both handlers await a device
        // enumeration; without the guard the second tap would re-enumerate and reset
        // the selected-index in parallel, producing IndexOutOfRange after the await.
        private int _cameraPickerBusy;
        private int _micPickerBusy;

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

#if __IOS__ && !__MACCATALYST__
            // Release the shared AVAudioSession we claimed in MainPage_Loaded — otherwise the
            // PlayAndRecord category stays latched for the rest of the app lifetime, routing
            // audio through the earpiece on phones and permanently ducking other apps.
            try
            {
                AVFoundation.AVAudioSession.SharedInstance().SetActive(
                    false,
                    AVFoundation.AVAudioSessionSetActiveOptions.NotifyOthersOnDeactivation,
                    out var deactivateErr);
                if (deactivateErr != null)
                {
                    Log($"AVAudioSession.SetActive(false) error: {deactivateErr.LocalizedDescription}");
                }
            }
            catch (Exception ax)
            {
                Log($"AVAudioSession deactivate failed: {ax.Message}");
            }
#endif

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

        /// <summary>
        /// Acquires the start/stop re-entrancy guard and disables start buttons.
        /// Returns false if another operation is already running (caller should bail out).
        /// </summary>
        private async Task<bool> BeginOperationAsync()
        {
            if (System.Threading.Interlocked.CompareExchange(ref _operationInProgress, 1, 0) != 0)
            {
                return false;
            }

            await SetStartButtonsEnabledAsync(false);
            return true;
        }

        /// <summary>
        /// Releases the start/stop re-entrancy guard and re-enables start buttons.
        /// </summary>
        private async Task EndOperationAsync()
        {
            await SetStartButtonsEnabledAsync(true);
            System.Threading.Interlocked.Exchange(ref _operationInProgress, 0);
        }

        /// <summary>
        /// Applies the start-buttons enabled state on the main thread, returning only after
        /// the state has actually flipped. Previously this used BeginInvokeOnMainThread,
        /// which queued the update and returned immediately — so BeginOperation flipped
        /// _operationInProgress to busy while the buttons still showed enabled, letting the
        /// user fire a second tap before the dispatcher round-tripped.
        /// </summary>
        private Task SetStartButtonsEnabledAsync(bool enabled)
        {
            if (MainThread.IsMainThread)
            {
                ApplyStartButtonsEnabled(enabled);
                return Task.CompletedTask;
            }

            return MainThread.InvokeOnMainThreadAsync(() => ApplyStartButtonsEnabled(enabled));
        }

        private void ApplyStartButtonsEnabled(bool enabled)
        {
            btStartYouTube.IsEnabled = enabled;
            btStartFacebook.IsEnabled = enabled;
            btStartRTMP.IsEnabled = enabled;
            btStartSRT.IsEnabled = enabled;
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
                //
                // Options: DefaultToSpeaker so playback routes to the main speaker (not the
                // earpiece) on phones even while PlayAndRecord is active; AllowBluetooth to
                // allow BT headsets as mic/output; MixWithOthers so we don't permanently
                // duck other apps just by opening the MobileStreamer page.
                try
                {
                    // DefaultToSpeaker + MixWithOthers is Apple-undefined — with the mix
                    // flag set, the route override is ignored on recent iOS and audio
                    // actually comes out of the earpiece. Drop DefaultToSpeaker from the
                    // options and instead call OverrideOutputAudioPort after activation,
                    // which is the documented way to force the main speaker while staying
                    // non-disruptive to other audio sessions.
                    //
                    // We also capture the SetCategory error explicitly: the void overload
                    // silently swallowed the real failure and let SetActive fail with a
                    // misleading "activation" error instead.
                    AVFoundation.AVAudioSession.SharedInstance().SetCategory(
                        AVFoundation.AVAudioSessionCategory.PlayAndRecord,
                        AVFoundation.AVAudioSessionCategoryOptions.AllowBluetooth |
                        AVFoundation.AVAudioSessionCategoryOptions.MixWithOthers,
                        out var categoryErr);
                    if (categoryErr != null)
                    {
                        Log($"AVAudioSession.SetCategory error: {categoryErr.LocalizedDescription}");
                    }
                    else
                    {
                        AVFoundation.AVAudioSession.SharedInstance().SetActive(true, out var audioErr);
                        if (audioErr != null)
                        {
                            Log($"AVAudioSession.SetActive error: {audioErr.LocalizedDescription}");
                        }
                        else
                        {
                            // Route to the main speaker (PlayAndRecord defaults to the
                            // earpiece on phones). Safe to ignore the return value —
                            // failure here only affects routing, not capture.
                            AVFoundation.AVAudioSession.SharedInstance().OverrideOutputAudioPort(
                                AVFoundation.AVAudioSessionPortOverride.Speaker,
                                out _);
                            Log("AVAudioSession activated (PlayAndRecord)");
                        }
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
            // Wait for any in-flight start/stop handler to finish before tearing the pipeline
            // down — otherwise CreateEngine/StartAsync races with Dispose here.
            var waitStarted = DateTime.UtcNow;
            while (System.Threading.Interlocked.CompareExchange(ref _operationInProgress, 1, 0) != 0)
            {
                if (DateTime.UtcNow - waitStarted > TimeSpan.FromSeconds(10))
                {
                    Log("Window_Destroying: timeout waiting for in-flight operation; proceeding anyway");
                    break;
                }

                await Task.Delay(50);
            }

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
            finally
            {
                System.Threading.Interlocked.Exchange(ref _operationInProgress, 0);
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

            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
            _pipeline = null;

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

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            // Do NOT gate Stop on BeginOperation — that's the start-side guard. If a Start
            // handler is hanging (SRT connect, blocked encoder), the user must still be able to
            // Stop, which is exactly what unblocks Start. Re-entrancy on Stop itself is
            // serialised by a dedicated flag so two simultaneous taps don't double-dispose.
            if (System.Threading.Interlocked.CompareExchange(ref _stopInProgress, 1, 0) != 0)
            {
                return;
            }

            try
            {
                await StopAllAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                // Force-release the start guard too: Stop is the recovery path for a hung Start
                // and must hand the UI back to the user even if BeginOperation never reached
                // its EndOperation. Re-enable the start buttons unconditionally.
                System.Threading.Interlocked.Exchange(ref _operationInProgress, 0);
                await SetStartButtonsEnabledAsync(true);
                System.Threading.Interlocked.Exchange(ref _stopInProgress, 0);
            }
        }

        /// <summary>
        /// Handles the bt camera clicked event.
        /// </summary>
        private async void btCamera_Clicked(object? sender, System.EventArgs e)
        {
            if (System.Threading.Interlocked.CompareExchange(ref _cameraPickerBusy, 1, 0) != 0)
            {
                return;
            }

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
            finally
            {
                System.Threading.Interlocked.Exchange(ref _cameraPickerBusy, 0);
            }
        }

        /// <summary>
        /// Handles the bt mic clicked event.
        /// </summary>
        private async void btMic_Clicked(object? sender, System.EventArgs e)
        {
            if (System.Threading.Interlocked.CompareExchange(ref _micPickerBusy, 1, 0) != 0)
            {
                return;
            }

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
            finally
            {
                System.Threading.Interlocked.Exchange(ref _micPickerBusy, 0);
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
            var url = edUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                await DisplayAlertAsync("YouTube", "Please set the YouTube ingest URL", "OK");
                return;
            }

            if (!await BeginOperationAsync())
            {
                return;
            }

            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                _sink = new YouTubeSinkBlock(new YouTubeSinkSettings(url));

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await EndOperationAsync();
            }
        }

        /// <summary>
        /// Handles the bt start facebook clicked event.
        /// </summary>
        private async void btStartFacebook_Clicked(object? sender, EventArgs e)
        {
            var url = edUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                await DisplayAlertAsync("Facebook Live", "Please set the Facebook Live ingest URL", "OK");
                return;
            }

            if (!await BeginOperationAsync())
            {
                return;
            }

            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                _sink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(url));

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await EndOperationAsync();
            }
        }

        /// <summary>
        /// Handles the bt start clicked event.
        /// </summary>
        private async void btStartRTMP_Clicked(object? sender, EventArgs e)
        {
            var url = edUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                await DisplayAlertAsync("RTMP", "Please set the RTMP ingest URL", "OK");
                return;
            }

            if (!await BeginOperationAsync())
            {
                return;
            }

            try
            {
                await StopAllAsync();

                CreateEngine();

                await ConfigurePreviewAsync();

                // streaming to RTMP server
                _sink = new RTMPSinkBlock(new RTMPSinkSettings() { Location = url });

                ConfigureCapture();

                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await EndOperationAsync();
            }
        }

        /// <summary>
        /// Handles the bt start SRT clicked event.
        /// </summary>
        private async void btStartSRT_Clicked(object? sender, EventArgs e)
        {
            // Gather URL + dialog input BEFORE BeginOperation: otherwise the guard is held
            // while DisplayPromptAsync/DisplayActionSheet waits on user input, and the Stop
            // button's BeginOperation call is rejected until dialogs close — UI appears
            // deadlocked.
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

            if (!await BeginOperationAsync())
            {
                Log("btStartSRT_Clicked: another operation in progress, ignoring");
                return;
            }

            try
            {
                Log("StopAllAsync...");
                await StopAllAsync();

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
            finally
            {
                await EndOperationAsync();
            }
        }
    }
}
