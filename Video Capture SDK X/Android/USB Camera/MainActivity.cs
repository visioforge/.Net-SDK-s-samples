using System.Linq;
using Android;
using Android.Content;
using Android.Hardware.Usb;
using Android.OS;
using Android.Util;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Android.UVC;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources.AndroidUVC;
using VisioForge.Core.VideoCaptureX;
using Activity = Android.App.Activity;

namespace USB_Camera
{
    /// <summary>
    /// Previews a USB (UVC) camera attached over OTG and records it to MP4 using VideoCaptureCoreX.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        private const string TAG = "USBCameraX";

        private const int PermissionRequest = 1004;

        private VisioForge.Core.UI.Android.VideoViewGL _videoView;

        private TextView _tbStatus;

        private ImageButton _btStartRecord;

        private VideoCaptureCoreX _core;

        private UsbDevice _camera;

        private UsbDetachReceiver _detachReceiver;

        private bool _isRecording;

        private bool _recorded;

        private string _filename;

        private string _moviesDir;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            // Android refuses to hand a USB video device to an app without the camera permission,
            // even though the Camera2 API is not used at all.
            RequestPermissions(new[] { Manifest.Permission.Camera }, PermissionRequest);

            _videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);
            _tbStatus = FindViewById<TextView>(Resource.Id.tbStatus);

            _btStartRecord = FindViewById<ImageButton>(Resource.Id.btStartRecord);
            _btStartRecord.Click += btStartRecord_Click;
        }

        /// <summary>
        /// Enables or disables the record button. The dimming matters: the button keeps its own
        /// background drawable, so a disabled one is indistinguishable from a live one without it.
        /// </summary>
        private void SetRecordEnabled(bool enabled)
        {
            _btStartRecord.Enabled = enabled;
            _btStartRecord.Alpha = enabled ? 1f : 0.4f;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode != PermissionRequest)
            {
                return;
            }

            if (!AndroidUVCDevices.HasCameraPermission())
            {
                SetStatus("Camera permission is required to use a USB camera.");
                return;
            }

            _ = StartPreviewAsync();
        }

        /// <summary>
        /// The app's movies folder, or null when external storage is unavailable.
        /// </summary>
        private string GetMoviesDirectory()
        {
            var dir = GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
            if (dir == null)
            {
                return null;
            }

            dir.Mkdirs();
            return dir.AbsolutePath;
        }

        private void SetStatus(string text)
        {
            Log.Info(TAG, text);
            RunOnUiThread(() => _tbStatus.Text = text);
        }

        private async Task StartPreviewAsync()
        {
            try
            {
                await StartPreviewCoreAsync();
            }
            catch (Exception ex)
            {
                // Nothing awaits this method, so an escaping exception would be lost.
                SetStatus(ex.Message);
            }
        }

        private async Task StartPreviewCoreAsync()
        {
            var cameras = AndroidUVCDevices.FindCameras();
            if (cameras.Count == 0)
            {
                // This demo looks for the camera once, at startup. A production app would also watch
                // for ACTION_USB_DEVICE_ATTACHED and start then.
                SetStatus("No USB camera found. Connect one over OTG and restart the app.");
                return;
            }

            _camera = cameras[0];
            SetStatus($"Found {_camera.ProductName}. Requesting access...");

            if (!await AndroidUVCDevices.RequestPermissionAsync(_camera))
            {
                SetStatus("Access to the USB camera was denied.");
                return;
            }

            // That dialog waits up to two minutes, and nothing awaits this method - so the activity
            // may be gone by now. Building the engine anyway would claim the camera on a dead view
            // with nothing left to dispose it, and the next launch would find the device busy.
            if (IsFinishing || IsDestroyed)
            {
                return;
            }

            // The camera decides which resolutions exist, so read them instead of guessing. Asking
            // for a mode the camera does not advertise is not an error - the nearest one is used.
            // Off the UI thread: reading the modes opens the USB device and walks its descriptors.
            var modes = await Task.Run(() => AndroidUVCDevices.GetModes(_camera));
            foreach (var mode in modes)
            {
                Log.Info(TAG, $"Available mode: {mode}");
            }

            _core = new VideoCaptureCoreX(_videoView);
            _core.OnError += Core_OnError;

            // A live camera has nothing to sync the recording branch to, and leaving it synced makes
            // that branch wait on the clock until its queue fills and stalls the preview with it.
            // A capture with audio would set Audio_Output_IsSync the same way; this one has none.
            _core.Video_Output_IsSync = false;

            _core.Video_Source = new AndroidUVCSourceSettings
            {
                Device = _camera,
                Width = 1280,
                Height = 720,
                FrameRate = new VideoFrameRate(30),
            };

            _core.Video_Play = true;

            // The recording is video-only. A UVC video interface carries no audio, and the phone
            // microphone is not a substitute here: a webcam with a built-in mic also registers as a
            // USB audio input, which Android then prefers for recording - and that input cannot be
            // opened while this camera is being streamed, so adding audio fails the whole pipeline.

            // Null when external storage is unavailable, in which case there is nowhere to record -
            // preview still works, so carry on without the output and leave the button disabled.
            _moviesDir = GetMoviesDirectory();
            if (_moviesDir != null)
            {
                // Registered before StartAsync so the recording branch of the pipeline exists;
                // autoStart is false so nothing is written until the record button is pressed.
                _filename = Path.Combine(_moviesDir, "placeholder.mp4");
                _core.Outputs_Add(new MP4Output(_filename), false);
            }

            if (!await _core.StartAsync())
            {
                SetStatus("Unable to start. Another app may be using the camera - check the log.");

                // The camera was already claimed while building, so hand it back before returning.
                await DisposeEngineAsync();
                return;
            }

            // The SDK reports a vanished camera through OnError, but only after the stream has been
            // silent for a few seconds. Android's detach broadcast arrives the moment the cable
            // comes out, which is what a recording app wants.
            _detachReceiver = new UsbDetachReceiver(OnUsbDetached);
            RegisterReceiver(_detachReceiver, new IntentFilter(UsbManager.ActionUsbDeviceDetached), ReceiverFlags.NotExported);

            RunOnUiThread(() => SetRecordEnabled(_moviesDir != null));
            SetStatus(_moviesDir != null
                ? $"Streaming from {_camera.ProductName}"
                : $"Streaming from {_camera.ProductName} - no external storage, so recording is off.");
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            // Starting and stopping a capture both take a moment, and a second tap in between would
            // run the other branch concurrently on the same output index.
            SetRecordEnabled(false);

            try
            {
                if (!_isRecording)
                {
                    // The output was configured before StartAsync; only the file name is new.
                    // Dated and zero-padded so a recording made at the same clock time on another
                    // day does not overwrite the earlier one.
                    var now = DateTime.Now;
                    _filename = Path.Combine(_moviesDir, $"visioforge_{now:yyyy-MM-dd_HH-mm-ss}.mp4");

                    // Checked, because a failure here is silent otherwise and the button would
                    // switch to "stop" over a recording that was never started.
                    if (!await _core.StartCaptureAsync(0, _filename))
                    {
                        SetStatus("Unable to start recording - check the log.");
                        return;
                    }

                    _isRecording = true;

                    _btStartRecord.SetImageResource(Resource.Drawable.ic_stop);
                    _btStartRecord.SetBackgroundResource(Resource.Drawable.btn_circle);
                    SetStatus("Recording...");
                }
                else
                {
                    // Before the stop, not after: this output has had its one recording either way,
                    // and a stop that throws would otherwise leave the button live over a session
                    // that can only produce a silent no-op recording.
                    _recorded = true;

                    await StopRecordingAsync();

                    SetStatus(File.Exists(_filename)
                        ? $"Saved {Path.GetFileName(_filename)}. Restart the app to record again."
                        : "Recording stopped, but no file was written - check the log.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.ToString());
                SetStatus(ex.Message);
            }
            finally
            {
                // Stays disabled once a recording has been made - see StopRecordingAsync.
                SetRecordEnabled(!_recorded);
            }
        }

        private async Task StopRecordingAsync()
        {
            if (!_isRecording)
            {
                return;
            }

            _isRecording = false;

            try
            {
                await _core.StopCaptureAsync(0);

                // Only when there is something to publish: a recording cut short by the camera being
                // unplugged can leave no file at all, and the gallery helper throws on a missing one.
                if (File.Exists(_filename))
                {
                    try
                    {
                        await PhotoGalleryHelper.AddVideoToGalleryAsync(_filename);
                    }
                    catch (Exception ex)
                    {
                        // The recording itself is already safe on disk. Publishing it can still fail
                        // - a full volume, a MediaStore entry that cannot be opened - and letting
                        // that escape would skip the engine teardown in the caller.
                        Log.Error(TAG, ex.ToString());
                    }
                }
            }
            finally
            {
                // In a finally so a failed stop cannot leave the stop icon over a state that is no
                // longer recording - the next tap would then start a recording from a "stop" button.
                RunOnUiThread(() =>
                {
                    _btStartRecord.SetImageResource(Resource.Drawable.ic_record);
                    _btStartRecord.SetBackgroundResource(Resource.Drawable.btn_record);
                });
            }
        }

        /// <summary>
        /// Called on a system thread whenever any USB device is detached.
        /// </summary>
        private async void OnUsbDetached()
        {
            try
            {
                if (_core == null || _camera == null)
                {
                    return;
                }

                // The broadcast carries no usable device on current Android levels, but a camera
                // that has been unplugged stops being enumerated - so ignore other devices.
                if (AndroidUVCDevices.FindCameras().Any(c => c.DeviceName == _camera.DeviceName))
                {
                    return;
                }

                SetStatus("The camera was disconnected.");
                RunOnUiThread(() => SetRecordEnabled(false));

                // Finish the recording so the file is playable, then release the pipeline.
                await StopRecordingAsync();
                await _core.StopAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.ToString());
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            SetStatus(e.Message);
        }

        private async Task DisposeEngineAsync()
        {
            if (_detachReceiver != null)
            {
                UnregisterReceiver(_detachReceiver);
                _detachReceiver = null;
            }

            if (_core == null)
            {
                return;
            }

            _core.OnError -= Core_OnError;

            await _core.DisposeAsync();
            _core = null;
        }

        protected override async void OnDestroy()
        {
            // FIRST, before anything that can await. Android checks that the base implementation ran
            // by the time this method returns, and an await returns to the runtime early - putting
            // this at the end throws SuperNotCalledException and kills the process.
            base.OnDestroy();

            try
            {
                // Closes an in-flight recording first. Disposing the engine tears the output
                // pipeline down without an end-of-stream, so leaving the app mid-recording would
                // otherwise leave an unfinalized MP4 on disk. No-op when nothing is recording.
                await StopRecordingAsync();

                await DisposeEngineAsync();
            }
            catch (Exception ex)
            {
                // A teardown failure must not stop DestroySDK from running.
                Log.Error(TAG, ex.ToString());
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Forwards Android's USB detach broadcast to the activity.
        /// </summary>
        private class UsbDetachReceiver : BroadcastReceiver
        {
            private readonly Action _onDetached;

            public UsbDetachReceiver(Action onDetached)
            {
                _onDetached = onDetached;
            }

            public override void OnReceive(Context context, Intent intent)
            {
                _onDetached();
            }
        }
    }
}
