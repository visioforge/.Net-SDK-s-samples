using Android;
using Android.Icu.Util;
using Android.Media;
using Android.Runtime;
using Android.Util;
using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.VideoCaptureX;

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

        private VideoCaptureCoreX _core;

        private VideoCaptureDeviceInfo[] _cameras;

        private AudioCaptureDeviceInfo[] _mics;

        private AudioOutputDeviceInfo[] _speakers;

        private int _cameraIndex = 0;

        private bool _isPreview = false;

        private string _filename;

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            _core = new VideoCaptureCoreX(videoView);

            // cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();

            // mics
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync();

            // audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync();
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= _pipeline_OnError;

                await _core.DisposeAsync();
                _core = null;
            }
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        /// <summary>
        /// On create.
        /// </summary>
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

            //tmPosition.Elapsed += tmPosition_Elapsed;

            btStartRecord = FindViewById<Button>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            btStopRecord = FindViewById<Button>(Resource.Id.btStopRecord);
            btStopRecord.Click += btStopRecord_Click;

            btSwitchCam = FindViewById<Button>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            CheckPermissionsAndStartPreview();
        }

        /// <summary>
        /// Check permissions and start preview.
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
        /// Start preview async.
        /// </summary>
        private async Task StartPreviewAsync()
        {
            await CreateEngineAsync();

            var videoSources = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (videoSources.Length == 0)
            {
                Toast.MakeText(this, "No video sources found", ToastLength.Long).Show();
                return;
            }

            if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
            {
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;
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
            //  }

            _core.Video_Source = videoSourceSettings;

            if (videoSourceSettings == null)
            {
                Toast.MakeText(this, "Unable to configure camera settings", ToastLength.Long).Show();
            }

            var now = DateTime.Now;
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath, "Camera", $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
            _core.Outputs_Add(new MP4Output(filename, videoEnc: new OpenH264EncoderSettings()), false);

            await _core.StartAsync();

            tmPosition.Start();
        }

        /// <summary>
        /// On destroy.
        /// </summary>
        protected override void OnDestroy()
        {
            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

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

            await StartAsync();
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            if (_core == null)
            {
                return;
            }

            tmPosition.Stop();

            await DestroyEngineAsync();

            videoView.Invalidate();
        }

        /// <summary>
        /// Handles the bt stop record click event.
        /// </summary>
        private async void btStopRecord_Click(object sender, EventArgs e)
        {
            await _core.StopCaptureAsync(0);

            await PhotoGalleryHelper.AddVideoToGalleryAsync(_filename);
        }

        /// <summary>
        /// Start async.
        /// </summary>
        private async Task StartAsync()
        {
            await StartPreviewAsync();
        }

        /// <summary>
        /// Handles the bt start record click event.
        /// </summary>
        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            _filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath, "Camera", $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
            await _core.StartCaptureAsync(0, _filename);
        }

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