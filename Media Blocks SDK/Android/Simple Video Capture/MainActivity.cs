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
using static Android.Renderscripts.ScriptGroup;
using System.Diagnostics;
using Activity = Android.App.Activity;

namespace Simple_Video_Capture
{
    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// The video view.
        /// </summary>
        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        /// <summary>
        /// The start record button.
        /// </summary>
        private Button btStartRecord;

        /// <summary>
        /// The stop record button.
        /// </summary>
        private Button btStopRecord;

        /// <summary>
        /// The switch camera button.
        /// </summary>
        private Button btSwitchCam;

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

        /// <summary>
        /// Indicates whether the preview is active.
        /// </summary>
        private bool _isPreview;

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

            btStartRecord = FindViewById<Button>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            btStopRecord = FindViewById<Button>(Resource.Id.btStopRecord);
            btStopRecord.Click += btStopRecord_Click;

            btSwitchCam = FindViewById<Button>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            CheckPermissionsAndStartPreview();
        }

        /// <summary>
        /// Called when the activity is being destroyed.
        /// </summary>
        protected override async void OnDestroy()
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
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
            try
            {
                await StopAsync();

                await PhotoGalleryHelper.AddVideoToGalleryAsync(_sink.GetFilenameOrURL());

                await StartPreviewAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
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
        /// Handles the Click event of the btStartRecord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt start record click event.
        /// </summary>
        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // stop preview
                await StopAsync();

                // create engine
                await CreateEngineAsync();

                // video encoder
                 _videoEncoder = new H264EncoderBlock();

                // create MP4 muxer
                var now = DateTime.Now;
                var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath, "Camera", $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");

                _sink = new MP4SinkBlock(new MP4SinkSettings(filename));

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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
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
