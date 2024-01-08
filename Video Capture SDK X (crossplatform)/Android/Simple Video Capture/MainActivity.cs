using Android;
using Android.Icu.Util;
using Android.Media;
using Android.Runtime;
using Android.Util;
using VisioForge.Core;
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
        private VisioForge.Core.UI.Android.VideoView videoView;

        private Button btStartRecord;

        private Button btStopRecord;

        private Button btSwitchCam;

        private GridLayout pnScreen;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private VideoCaptureCoreX _core;

        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureDeviceInfo[] _cameras;

        private AudioCaptureDeviceInfo[] _mics;

        private AudioOutputDeviceInfo[] _speakers;

        private int _cameraIndex = 0;

        private async Task CreateEngineAsync()
        {
            _deviceEnumerator = new DeviceEnumerator(this);

            _core = new VideoCaptureCoreX(videoView, this);

            // cameras
            _cameras = await _deviceEnumerator.VideoSourcesAsync();

            // mics
            _mics = await _deviceEnumerator.AudioSourcesAsync();

            // audio outputs
            _speakers = await _deviceEnumerator.AudioOutputsAsync();
        }

        private async Task DestroyEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= _pipeline_OnError;
                _core.OnStop -= _pipeline_OnStop;
                _core.OnStart -= _pipeline_OnStart;

                await _core.DisposeAsync();
                _core = null;
            }
        }

        private async void _pipeline_OnStart(object sender, EventArgs e)
        {
            // var duration = await _pipeline.DurationAsync();
            // sbTimeline.Max = (int)duration.TotalMilliseconds;
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            RunOnUiThread(() =>
            {
                // sbTimeline.Progress = 0;
            });
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

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoView>(Resource.Id.videoView);

            //tmPosition.Elapsed += tmPosition_Elapsed;

            btStartRecord = FindViewById<Button>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            btStopRecord = FindViewById<Button>(Resource.Id.btStopRecord);
            btStopRecord.Click += btStopRecord_Click;

            btSwitchCam = FindViewById<Button>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            // lbPosition = FindViewById<TextView>(Resource.Id.lbPosition);
            pnScreen = FindViewById<GridLayout>(Resource.Id.pnScreen);

            Task.Run(async () =>
            {
                await StartAsync();
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

            await StartAsync();
        }

        private async Task StopAsync()
        {
            if (_core == null)
            {
                return;
            }

            tmPosition.Stop();

            await DestroyEngineAsync();

            videoView.Invalidate();

            // clear screen workaround
            pnScreen.RemoveView(videoView);
            pnScreen.AddView(videoView);
        }

        private async void btStopRecord_Click(object sender, EventArgs e)
        {
            await _core.StopCaptureAsync(0);
        }

        private async Task StartAsync()
        {
            await CreateEngineAsync();

            var videoSources = await _deviceEnumerator.VideoSourcesAsync();
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
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
            _core.Outputs_Add(new MP4Output(filename, videoEnc: new OpenH264EncoderSettings()), false);

            await _core.StartAsync();

            tmPosition.Start();
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
            await _core.StartCaptureAsync(0, filename);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}