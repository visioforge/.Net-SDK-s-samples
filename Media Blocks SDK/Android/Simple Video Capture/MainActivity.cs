using Android;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.OpenGL;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.OpenGL;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Special;
using Activity = Android.App.Activity;

namespace Simple_Video_Capture
{
    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// The video view.
        /// </summary>
        private VisioForge.Core.UI.Android.VideoViewGL videoView;

        /// <summary>
        /// The record/stop toggle button.
        /// </summary>
        private ImageButton btStartRecord;

        /// <summary>
        /// The switch camera button.
        /// </summary>
        private ImageButton btSwitchCam;

        /// <summary>
        /// Indicates whether recording is active.
        /// </summary>
        private bool _isRecording;

        /// <summary>
        /// The position timer.
        /// </summary>
        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private SystemVideoSourceBlock _videoSource;

        /// <summary>
        /// The audio source.
        /// </summary>
        private SystemAudioSourceBlock _audioSource;

        /// <summary>
        /// The video encoder.
        /// </summary>
        private MediaBlock _videoEncoder;

        /// <summary>
        /// The audio encoder.
        /// </summary>
        private MediaBlock _audioEncoder;

        /// <summary>
        /// The MP4 sink.
        /// </summary>
        private MP4SinkBlock _sink;

        /// <summary>
        /// The filename of the current recording, stored when the sink is created.
        /// </summary>
        private string _recordingFilename;

        /// <summary>
        /// The video tee.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee.
        /// </summary>
        private TeeBlock _audioTee;

        /// <summary>
        /// The current camera index.
        /// </summary>
        private int _cameraIndex = 1;

        /// <summary>
        /// The available cameras.
        /// </summary>
        private VideoCaptureDeviceInfo[] _cameras;

        private int _previewStarted;

        /// <summary>
        /// Asynchronously creates the media blocks engine pipeline and initializes blocks.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            // video source (Camera2 API)
            if (_cameras == null)
            {
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            }

            if (_cameras.Length == 0)
            {
                Toast.MakeText(this, "No video sources found", ToastLength.Long).Show();
                await _pipeline.DisposeAsync();
                _pipeline = null;
                return;
            }

            if (_cameraIndex >= _cameras.Length)
            {
                _cameraIndex = 0;
            }

            var device = _cameras[_cameraIndex];
            if (device == null)
            {
                Toast.MakeText(this, "Camera device is null", ToastLength.Long).Show();
                await _pipeline.DisposeAsync();
                _pipeline = null;
                return;
            }

            Log.Info("SimpleVideoCapture", $"Camera: {device.Name}, API: {device.API}, Formats: {device.VideoFormats?.Count ?? 0}");
            if (device.VideoFormats != null)
            {
                foreach (var f in device.VideoFormats)
                {
                    Log.Info("SimpleVideoCapture", $"  Format: {f.Width}x{f.Height}, FPS: {string.Join(",", f.FrameRateList)}");
                }
            }

            var formatItem = device.GetVideoFormatAndFrameRate(1920, 1080, out var framerate);
            VideoCaptureDeviceSourceSettings videoSourceSettings;
            if (formatItem != null)
            {
                videoSourceSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                videoSourceSettings.Format.FrameRate = framerate;
            }
            else
            {
                videoSourceSettings = new VideoCaptureDeviceSourceSettings(device);
            }

            if (videoSourceSettings.Format == null)
            {
                Toast.MakeText(this, "Unable to configure camera settings", ToastLength.Long).Show();
                await _pipeline.DisposeAsync();
                _pipeline = null;
                return;
            }

            Log.Info("SimpleVideoCapture", $"Selected format: {videoSourceSettings.Format.Width}x{videoSourceSettings.Format.Height} @ {videoSourceSettings.Format.FrameRate}");

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            // audio source
            _audioSource = new SystemAudioSourceBlock(new AndroidAudioSourceSettings());

            // audio renderer
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            if (audioSinks.Length == 0)
            {
                throw new InvalidOperationException("No audio output devices found.");
            }

            _audioRenderer = new AudioRendererBlock(audioSinks[0]) { IsSync = false };
        }

        /// <summary>
        /// Asynchronously destroys the media blocks engine pipeline and releases resources.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the OnError event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        /// <summary>
        /// Called when the activity is starting.
        /// </summary>
        /// <param name="savedInstanceState">If the activity is being re-initialized after previously being shut down then this Bundle contains the data it most recently supplied in <see cref="M:Android.App.Activity.OnSaveInstanceState(Android.OS.Bundle)"/>.  <format type="text/html"><a href="https://developer.android.com/reference/android/app/Activity.html#onCreate(android.os.Bundle)" target="_blank">[C# document]</a></format></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestPermissions(
               new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.ModifyAudioSettings
               }, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);

            btStartRecord = FindViewById<ImageButton>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            btSwitchCam = FindViewById<ImageButton>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            // Don't start here — OnRequestPermissionsResult will handle it.
        }

        /// <summary>
        /// Called when the activity is being destroyed.
        /// </summary>
        protected override async void OnDestroy()
        {
            try
            {
                tmPosition.Stop();
                await DestroyEngineAsync();
            }
            catch (Exception ex)
            {
                Log.Error("MainActivity", ex.ToString());
            }

            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        /// <summary>
        /// Checks the permissions and starts the preview if granted.
        /// </summary>
        private void CheckPermissionsAndStartPreview()
        {
            if (Interlocked.CompareExchange(ref _previewStarted, 1, 0) != 0)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                Interlocked.Exchange(ref _previewStarted, 0);
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                Interlocked.Exchange(ref _previewStarted, 0);
                return;
            }

            Task.Run(async () =>
            {
                try
                {
                    await StartPreviewAsync();
                }
                catch (Exception ex)
                {
                    Android.Util.Log.Error("SimpleVideoCapture", ex.ToString());
                }
            });
        }

        /// <summary>
        /// Handles the Click event of the btSwitchCam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt switch cam click event.
        /// </summary>
        private async void btSwitchCam_Click(object sender, EventArgs e)
        {
            try
            {
                var newIndex = (_cameraIndex == 0) ? 1 : 0;
                if (newIndex >= _cameras.Length)
                {
                    return;
                }

                // Try live switch — must match current resolution and fps
                var newDevice = _cameras[newIndex];
                var formatItem = newDevice.GetVideoFormatAndFrameRate(1920, 1080, out var framerate);
                if (formatItem == null)
                {
                    formatItem = newDevice.GetVideoFormatAndFrameRate(1280, 720, out framerate);
                }

                VideoCaptureDeviceSourceSettings newSettings;
                if (formatItem != null)
                {
                    newSettings = new VideoCaptureDeviceSourceSettings(newDevice, formatItem.ToFormat());
                    newSettings.Format.FrameRate = framerate;
                }
                else
                {
                    newSettings = new VideoCaptureDeviceSourceSettings(newDevice);
                }

                var switched = await Task.Run(() => _videoSource.SwitchCamera(newSettings));
                if (switched)
                {
                    _cameraIndex = newIndex;
                    return;
                }

                // Fallback: full pipeline restart (stops recording if active)
                Log.Warn("MainActivity", "Live camera switch failed, falling back to full restart.");
                if (_isRecording)
                {
                    _isRecording = false;
                    btStartRecord.SetImageResource(Resource.Drawable.ic_record);
                    btStartRecord.SetBackgroundResource(Resource.Drawable.btn_record);
                }

                await StopAsync();
                _cameraIndex = newIndex;
                await StartPreviewAsync();
            }
            catch (Exception ex)
            {
                Log.Error("MainActivity", ex.ToString());
            }
        }

        /// <summary>
        /// Asynchronously stops the pipeline and destroys the engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StopAsync(bool force = true)
        {
            Interlocked.Exchange(ref _previewStarted, 0);

            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync(force);

            tmPosition.Stop();

            await DestroyEngineAsync();

            RunOnUiThread(() => videoView.Invalidate());
        }

        /// <summary>
        /// Handles the Click event of the btStopRecord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt stop record click event.
        /// </summary>
        /// <summary>
        /// Asynchronously starts the preview.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync();

            // connect directly: source → renderer (no tee needed for preview)
            _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
            _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);

            await _pipeline.StartAsync();

            tmPosition.Start();
        }

        /// <summary>
        /// Handles the record/stop toggle button click.
        /// </summary>
        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isRecording)
                {
                    // start recording
                    await StopAsync();
                    await CreateEngineAsync();

                    if (_pipeline == null)
                    {
                        // Engine creation failed (e.g. no camera found), fall back to preview
                        await StartPreviewAsync();
                        return;
                    }

                    // create tees to split source → renderer + encoder
                    var teeSettings = new TeeQueueSettings
                    {
                        MaxSizeBuffers = 3,
                        Leaky = TeeQueueLeaky.Downstream
                    };
                    _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video, teeSettings);
                    _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio, teeSettings);

                    _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                    _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                    _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                    _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);

                    _videoEncoder = new H264EncoderBlock();

                    var now = DateTime.Now;
                    var moviesDir = GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
                    moviesDir.Mkdirs();
                    _recordingFilename = Path.Combine(moviesDir.AbsolutePath, $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
                    _sink = new MP4SinkBlock(new MP4SinkSettings(_recordingFilename));

                    _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
                    _pipeline.Connect(_videoEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));

                    _audioEncoder = new AACEncoderBlock();
                    _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
                    _pipeline.Connect(_audioEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio));

                    await _pipeline.StartAsync();

                    _isRecording = true;
                    btStartRecord.SetImageResource(Resource.Drawable.ic_stop);
                    btStartRecord.SetBackgroundResource(Resource.Drawable.btn_circle);
                }
                else
                {
                    // stop recording
                    await StopAsync(force: false);
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(_recordingFilename);
                    await StartPreviewAsync();

                    _isRecording = false;
                    btStartRecord.SetImageResource(Resource.Drawable.ic_record);
                    btStartRecord.SetBackgroundResource(Resource.Drawable.btn_record);
                }
            }
            catch (Exception ex)
            {
                Log.Error("MainActivity", ex.ToString());
            }
        }

        /// <summary>
        /// Called when the activity has detected the user's query for the result from a permission request.
        /// </summary>
        /// <param name="requestCode">The request code passed in <see cref="M:Android.App.Activity.RequestPermissions(System.String[],System.Int32)" />.</param>
        /// <param name="permissions">The requested permissions. Never null.</param>
        /// <param name="grantResults">The grant results for the corresponding permissions which is either <see cref="F:Android.Content.PM.Permission.Granted" /> or <see cref="F:Android.Content.PM.Permission.Denied" />. Never null.</param>
        /// <summary>
        /// On request permissions result.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            CheckPermissionsAndStartPreview();
        }
    }
}
