using Android;
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
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        private VisioForge.Core.UI.Android.VideoViewGL videoView;

        private ImageButton btStartRecord;

        private ImageButton btSwitchCam;

        private bool _isRecording;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private VideoCaptureCoreX _core;

        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraIndex = 0;

        private bool _previewStarted;

        private bool _busy;

        private string _filename;

        private async Task CreateEngineAsync()
        {
            _core = new VideoCaptureCoreX(videoView);
            _core.OnError += _core_OnError;

            if (_cameras == null)
            {
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            }

            if (_cameras.Length == 0)
            {
                Toast.MakeText(this, "No video sources found", ToastLength.Long).Show();
                await _core.DisposeAsync();
                _core = null;
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
                await _core.DisposeAsync();
                _core = null;
                return;
            }

            Log.Info("SimpleVideoCapture", $"Camera: {device.Name}, API: {device.API}, Formats: {device.VideoFormats?.Count ?? 0}");

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device);
            if (videoSourceSettings.Format == null)
            {
                Toast.MakeText(this, "Unable to configure camera settings", ToastLength.Long).Show();
                await _core.DisposeAsync();
                _core = null;
                return;
            }

            Log.Info("SimpleVideoCapture", $"Selected format: {videoSourceSettings.Format.Width}x{videoSourceSettings.Format.Height} @ {videoSourceSettings.Format.FrameRate}");

            _core.Video_Source = videoSourceSettings;
            _core.Video_Play = true;

            // audio source
            var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();
            if (audioSources.Length > 0)
            {
                _core.Audio_Source = audioSources[0].CreateSourceSettingsVC();
                _core.Audio_Play = false;
                _core.Audio_Record = true;
            }

            // Pre-configure the MP4 output before StartAsync so the output pipeline
            // is materialized. Use autoStart: false so recording only begins when
            // StartCaptureAsync is called.
            // Use placeholder path — actual filename is set in btStartRecord_Click via StartCaptureAsync
            var moviesDir = GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
            moviesDir.Mkdirs();
            _filename = Path.Combine(moviesDir.AbsolutePath, "placeholder.mp4");
            _core.Outputs_Add(new MP4Output(_filename), false);
        }

        private async Task DestroyEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= _core_OnError;

                await _core.DisposeAsync();
                _core = null;
            }
        }

        private void _core_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
        }

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

        private async void btSwitchCam_Click(object sender, EventArgs e)
        {
            if (_busy)
            {
                return;
            }

            _busy = true;
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

                var switched = await Task.Run(() => _core.Video_Source_SwitchCamera(newSettings));
                if (switched)
                {
                    _cameraIndex = newIndex;
                    return;
                }

                // Fallback: full pipeline restart
                Log.Warn("MainActivity", "Live camera switch failed, falling back to full restart.");
                if (_isRecording)
                {
                    await _core.StopCaptureAsync(0);
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(_filename);
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
            finally
            {
                _busy = false;
            }
        }

        private async Task StopAsync()
        {
            if (_core == null)
            {
                return;
            }

            await _core.StopAsync();

            tmPosition.Stop();

            await DestroyEngineAsync();

            RunOnUiThread(() => videoView.Invalidate());
        }

        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync();

            if (_core == null)
            {
                return;
            }

            await _core.StartAsync();

            tmPosition.Start();
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (_core == null) return;

                if (!_isRecording)
                {
                    // Output was already configured in CreateEngineAsync before StartAsync.
                    // Generate a fresh filename for this recording session.
                    var now = DateTime.Now;
                    var moviesDir = GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
                    moviesDir.Mkdirs();
                    _filename = Path.Combine(moviesDir.AbsolutePath, $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
                    await _core.StartCaptureAsync(0, _filename);

                    _isRecording = true;
                    btStartRecord.SetImageResource(Resource.Drawable.ic_stop);
                    btStartRecord.SetBackgroundResource(Resource.Drawable.btn_circle);
                }
                else
                {
                    await _core.StopCaptureAsync(0);
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(_filename);

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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            // Guard: only start preview once, all permission checks on UI thread
            if (_previewStarted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            _previewStarted = true;

            Task.Run(async () =>
            {
                try
                {
                    await StartPreviewAsync();
                }
                catch (Exception ex)
                {
                    Log.Error("MainActivity", ex.ToString());
                }
            });
        }
    }
}
