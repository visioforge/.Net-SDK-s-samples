using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using Android;
using VisioForge.Core.Types.Events;
using Android.Util;
using Android.Runtime;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.Types;

namespace Mobile_Streamer
{
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private string STREAMING_KEY = "";

        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        private Button btStartStreaming;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private MediaBlock _videoSource;

        private MediaBlock _audioSource;

        private H264EncoderBlock _videoEncoder;

        private MediaBlock _audioEncoder;

        private MediaBlock _sink;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private int _cameraIndex = 1;

        private VideoCaptureDeviceInfo[] _cameras;

        private Button btStart;

        private Button btSwitchCam;

        private bool _isPreview;

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
                        Manifest.Permission.ModifyAudioSettings,
                        Manifest.Permission.ReadExternalStorage,
                        Manifest.Permission.WriteExternalStorage
               }, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(Resource.Id.videoView);

            btStart = FindViewById<Button>(Resource.Id.btStart);
            btStart.Click += btStartRecord_Click;

            btSwitchCam = FindViewById<Button>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            CheckPermissionsAndStartPreview();
        }

        /// <summary>
        /// Called when the activity is being destroyed.
        /// </summary>
        protected override void OnDestroy()
        {
            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        /// <summary>
        /// Checks the permissions and starts the preview if granted.
        /// </summary>
        private void CheckPermissionsAndStartPreview()
        {
            if (CheckSelfPermission(Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            Task.Run(async () =>
            {
                if (_isPreview)
                {
                    return;
                }

                _isPreview = true;

                await StartPreviewAsync();
            });
        }

        /// <summary>
        /// Asynchronously creates the media blocks engine pipeline and initializes blocks.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            // video source
            if (_cameras == null)
            {
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            }

            if (_cameras.Length == 0)
            {
                Toast.MakeText(this, "No video sources found", ToastLength.Long).Show();
                return;
            }

            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            if (_cameraIndex >= _cameras.Length)
            {
                _cameraIndex = 0;
            }

            var device = _cameras[_cameraIndex];
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

            if (videoSourceSettings == null)
            {
                Toast.MakeText(this, "Unable to configure camera settings", ToastLength.Long).Show();
                return;
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // create video tee
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            // connect video pads
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            // audio source
            _audioSource = new SystemAudioSourceBlock(new AndroidAudioSourceSettings());

            // create audio tee
            _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

            // audio renderer
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            _audioRenderer = new AudioRendererBlock(audioSinks[0]) { IsSync = false };

            // connect audio pads
            _pipeline.Connect(_audioSource.Output, _audioTee.Input);
            _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
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
        /// Handles the Click event of the btSwitchCam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt switch cam click event.
        /// </summary>
        private async void btSwitchCam_Click(object sender, EventArgs e)
        {
            await StopAsync();

            if (_cameraIndex == 0)
            {
                _cameraIndex = 1;
            }
            else
            {
                _cameraIndex = 0;
            }

            await StartPreviewAsync();
        }

        /// <summary>
        /// Asynchronously stops the pipeline and destroys the engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StopAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            tmPosition.Stop();

            await DestroyEngineAsync();

            videoView.Invalidate();
        }

        /// <summary>
        /// Handles the Click event of the btStopRecord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt stop record click event.
        /// </summary>
        private async void btStopRecord_Click(object sender, EventArgs e)
        {
            await StopAsync();

            await StartPreviewAsync();
        }

        /// <summary>
        /// Asynchronously starts the preview.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync();

            await _pipeline.StartAsync();

            tmPosition.Start();
        }

        /// <summary>
        /// Asynchronously starts the streaming record.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StartRecordAsync()
        {
            if (string.IsNullOrEmpty(STREAMING_KEY))
            {
                Toast.MakeText(this, "Please set the streaming key", ToastLength.Long).Show();
                return;
            }

            // stop preview
            await StopAsync();

            // create engine
            await CreateEngineAsync();

            // video encoder
            _videoEncoder = new H264EncoderBlock();
            _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders

            // create sink
            if (STREAMING_KEY.StartsWith("FB-"))
            {
                // Facebook Live
                var sinkSettings = new FacebookLiveSinkSettings(STREAMING_KEY);
                _sink = new FacebookLiveSinkBlock(sinkSettings);
            } 
            else
            {
                // YouTube
                var sinkSettings = new YouTubeSinkSettings(STREAMING_KEY);
                _sink = new YouTubeSinkBlock(sinkSettings);
            }

            // connect video pads
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
            _pipeline.Connect(_videoEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));

            // create audio encoder
            _audioEncoder = new AACEncoderBlock();

            // connect audio pads
            _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
            _pipeline.Connect(_audioEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio));

            // start pipeline
            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStartRecord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt start record click event.
        /// </summary>
        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            await StartRecordAsync();
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