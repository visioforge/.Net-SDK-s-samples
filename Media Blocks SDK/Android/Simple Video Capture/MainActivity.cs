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

namespace Simple_Video_Capture
{
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        private Button btStartRecord;

        private Button btStopRecord;

        private Button btSwitchCam;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private MediaBlock _videoEncoder;

        private MediaBlock _audioEncoder;

        private MP4SinkBlock _sink;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private int _cameraIndex = 1;

        private VideoCaptureDeviceInfo[] _cameras;

        private bool _isPreview;

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

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

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

        protected override void OnDestroy()
        {
            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

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

        private async void btStopRecord_Click(object sender, EventArgs e)
        {
            await StopAsync();

            await PhotoGalleryHelper.AddVideoToGalleryAsync(_sink.GetFilenameOrURL());

            await StartPreviewAsync();
        }

        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync();

            await _pipeline.StartAsync();

            tmPosition.Start();
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            // stop preview
            await StopAsync();

            // create engine
            await CreateEngineAsync();

            // video encoder
             _videoEncoder = new H264EncoderBlock();

            // create MP4 muxer
            var now = DateTime.Now;
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            CheckPermissionsAndStartPreview();
        }
    }
}