using Android.Content;
using Android.Content.PM;
using Android.Media.Projection;
using Android.OS;
using Android.Provider;
using Android.Util;
using Android.Widget;
using VisioForge.Core;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Android.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.VideoCaptureX;
using System.Threading;
using Activity = Android.App.Activity;

namespace Audio_Playback_Capture_VCX
{
    /// <summary>
    /// Audio playback capture demo activity built on the VideoCaptureCoreX engine.
    /// Flow: Start button -> start ForegroundService -> request MediaProjection -> capture another app's
    /// audio via AudioPlaybackCapture (Audio_Source) -> encode AAC -> record to .m4a.
    /// </summary>
    // SingleTask + ConfigurationChanges keep a single Activity instance across re-launch and config changes.
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTask,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.KeyboardHidden | ConfigChanges.UiMode | ConfigChanges.SmallestScreenSize | ConfigChanges.ScreenLayout | ConfigChanges.Density,
        ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        private const int REQUEST_MEDIA_PROJECTION = 1001;
        private const int REQUEST_RECORD_AUDIO = 2001;

        private Button btStartRecord;
        private TextView tvStatus;
        private bool _isRecording;

        private VideoCaptureCoreX _core;

        private MediaProjectionManager _projectionManager;
        private MediaProjection _mediaProjection;
        private string _recordingFilename;
        private string _lastSavedLocation;
        private bool _engineStarted;

        // Serialize start vs stop.
        private readonly SemaphoreSlim _captureGate = new(1, 1);
        private Task _startTask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            tvStatus = FindViewById<TextView>(Resource.Id.tvStatus);

            btStartRecord = FindViewById<Button>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            _projectionManager = (MediaProjectionManager)GetSystemService(MediaProjectionService);

            // RECORD_AUDIO is required to build an AudioRecord for playback capture.
            if (CheckSelfPermission(Android.Manifest.Permission.RecordAudio) != Permission.Granted)
            {
                RequestPermissions(new[] { Android.Manifest.Permission.RecordAudio }, REQUEST_RECORD_AUDIO);
            }
        }

        protected override async void OnDestroy()
        {
            // Wait for any in-flight start before tearing down.
            var startTask = _startTask;
            if (startTask != null)
            {
                try { await startTask; }
                catch (Exception ex) { Log.Error("AudioCapture", ex.ToString()); }
            }

            try
            {
                await StopCaptureAsync();
            }
            catch (Exception ex)
            {
                Log.Error("AudioCapture", ex.ToString());
            }

            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isRecording)
                {
                    if (CheckSelfPermission(Android.Manifest.Permission.RecordAudio) != Permission.Granted)
                    {
                        RequestPermissions(new[] { Android.Manifest.Permission.RecordAudio }, REQUEST_RECORD_AUDIO);
                        return;
                    }

                    btStartRecord.Enabled = false;

                    try
                    {
                        // Request capture permission first; the foreground service starts after the user grants it.
                        StartActivityForResult(_projectionManager.CreateScreenCaptureIntent(), REQUEST_MEDIA_PROJECTION);
                    }
                    catch
                    {
                        btStartRecord.Enabled = true;
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        await StopCaptureAsync();

                        // Flip the UI to idle only after the stop actually completed.
                        _isRecording = false;
                        btStartRecord.Text = "Start Audio Capture";
                        tvStatus.Text = _lastSavedLocation != null
                            ? $"Saved to {_lastSavedLocation}"
                            : "Saved recording.";
                    }
                    catch (Exception ex)
                    {
                        Log.Error("AudioCapture", ex.ToString());
                        tvStatus.Text = "Failed to stop capture.";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("AudioCapture", ex.ToString());
                btStartRecord.Enabled = true;
            }
        }

        protected override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_MEDIA_PROJECTION)
            {
                if (resultCode == Android.App.Result.Ok && data != null)
                {
                    var projResultCode = (int)resultCode;
                    var projData = data;

                    // Prepare TCS so we know when StartForeground() has been called.
                    var fgsTcs = new TaskCompletionSource<bool>();
                    AudioCaptureService.ForegroundStarted = fgsTcs;

                    // Start the foreground service AFTER the user grants media projection permission
                    // (required on Android 14+ / targetSDK 34+).
                    var serviceIntent = new Intent(this, typeof(AudioCaptureService));
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    {
                        StartForegroundService(serviceIntent);
                    }
                    else
                    {
                        StartService(serviceIntent);
                    }

                    // GetMediaProjection must be called AFTER the FGS is in foreground state.
                    // Store the task so OnDestroy can await it before tearing down / destroying the SDK.
                    _startTask = Task.Run(async () =>
                    {
                        try
                        {
                            var completed = await Task.WhenAny(fgsTcs.Task, Task.Delay(5000));

                            if (completed != fgsTcs.Task)
                            {
                                RunOnUiThread(() =>
                                {
                                    if (IsDestroyed || IsFinishing) return;
                                    btStartRecord.Enabled = true;
                                    Toast.MakeText(this, "Foreground service failed to start in time", ToastLength.Long).Show();
                                });
                                StopService(new Intent(this, typeof(AudioCaptureService)));

                                // Clear the static TCS this attempt owns so it does not dangle for the process lifetime.
                                if (ReferenceEquals(AudioCaptureService.ForegroundStarted, fgsTcs))
                                {
                                    AudioCaptureService.ForegroundStarted = null;
                                }

                                fgsTcs.TrySetResult(false);
                                return;
                            }

                            _mediaProjection = _projectionManager.GetMediaProjection(projResultCode, projData);

                            await StartCaptureAsync();

                            RunOnUiThread(() =>
                            {
                                if (IsDestroyed || IsFinishing) return;
                                _isRecording = true;
                                btStartRecord.Text = "Stop Audio Capture";
                                btStartRecord.Enabled = true;
                                tvStatus.Text = "Recording app audio...";
                            });
                        }
                        catch (Exception ex)
                        {
                            Log.Error("AudioCapture", ex.ToString());

                            // Tear down the partially-built engine before stopping the service.
                            try { await StopCaptureAsync(); }
                            catch (Exception stopEx) { Log.Error("AudioCapture", stopEx.ToString()); }

                            RunOnUiThread(() =>
                            {
                                if (IsDestroyed || IsFinishing) return;
                                btStartRecord.Enabled = true;
                                Toast.MakeText(this, $"Audio capture failed: {ex.Message}", ToastLength.Long).Show();
                            });
                        }
                    });
                }
                else
                {
                    btStartRecord.Enabled = true;
                    Toast.MakeText(this, "Audio capture permission denied", ToastLength.Short).Show();
                }
            }
        }

        private async Task StartCaptureAsync()
        {
            await _captureGate.WaitAsync();
            try
            {
                await StartCaptureCoreAsync();
            }
            finally
            {
                _captureGate.Release();
            }
        }

        private async Task StartCaptureCoreAsync()
        {
            // Audio-only capture: no VideoView, no video source.
            _core = new VideoCaptureCoreX();
            _core.OnError += Core_OnError;

            // Audio playback capture source (records the audio of other apps via MediaProjection).
            _core.Audio_Source = new AndroidAudioPlaybackCaptureSourceSettings(_mediaProjection);
            _core.Audio_Play = false;
            _core.Audio_Record = true;

            var now = DateTime.Now;
            var musicDir = GetExternalFilesDir(Android.OS.Environment.DirectoryMusic);
            if (musicDir == null)
            {
                throw new InvalidOperationException("External storage not available");
            }

            musicDir.Mkdirs();
            _recordingFilename = Path.Combine(musicDir.AbsolutePath, $"appaudio_{now:yyyyMMdd_HHmmss}.m4a");

            // M4A (AAC) audio-only output. autostart: true -> recording begins with StartAsync.
            _core.Outputs_Add(new M4AOutput(_recordingFilename), true);

            await _core.StartAsync();

            // Only after a successful start does the SDK own the projection and stop it on dispose.
            _engineStarted = true;
        }

        private async Task StopCaptureAsync()
        {
            await _captureGate.WaitAsync();
            try
            {
                await StopCaptureCoreAsync();
            }
            finally
            {
                _captureGate.Release();
            }
        }

        private async Task StopCaptureCoreAsync()
        {
            var core = Interlocked.Exchange(ref _core, null);
            var engineStarted = _engineStarted;
            _engineStarted = false;
            if (core != null)
            {
                core.OnError -= Core_OnError;
                await core.StopAsync();
                await core.DisposeAsync();
            }

            // Copy the recording to the device library via MediaStore.
            _lastSavedLocation = null;
            var filename = Interlocked.Exchange(ref _recordingFilename, null);
            if (filename != null && File.Exists(filename))
            {
                try
                {
                    CopyToLibrary(filename);
                }
                catch (Exception ex)
                {
                    Log.Error("AudioCapture", $"Failed to copy to library: {ex}");
                }
            }

            // The SDK stops the projection on dispose only once capture actually started.
            // If start never succeeded, release the consent token here so it is not left dangling.
            if (!engineStarted)
            {
                _mediaProjection?.Stop();
            }

            _mediaProjection = null;

            // Stop the foreground service.
            StopService(new Intent(this, typeof(AudioCaptureService)));
        }

        private void CopyToLibrary(string filePath)
        {
            var fileName = System.IO.Path.GetFileName(filePath);

            var values = new ContentValues();
            values.Put(MediaStore.Audio.Media.InterfaceConsts.DisplayName, fileName);
            values.Put(MediaStore.Audio.Media.InterfaceConsts.MimeType, "audio/mp4");
            values.Put(MediaStore.Audio.Media.InterfaceConsts.RelativePath, Android.OS.Environment.DirectoryMusic);

            var uri = ContentResolver.Insert(MediaStore.Audio.Media.ExternalContentUri, values);
            if (uri == null)
            {
                Log.Error("AudioCapture", "Failed to create MediaStore entry");
                return;
            }

            using var output = ContentResolver.OpenOutputStream(uri);
            if (output == null)
            {
                Log.Error("AudioCapture", "Failed to open output stream for MediaStore entry");
                ContentResolver.Delete(uri, null, null);
                return;
            }

            try
            {
                using var input = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                input.CopyTo(output);
                output.Flush();
            }
            catch
            {
                ContentResolver.Delete(uri, null, null);
                throw;
            }

            _lastSavedLocation = $"Music/{fileName}";
            Log.Info("AudioCapture", $"Recording saved to library: {_lastSavedLocation}");
            RunOnUiThread(() =>
            {
                if (IsDestroyed || IsFinishing) return;
                Toast.MakeText(this, $"Saved to {_lastSavedLocation}", ToastLength.Long).Show();
            });

            File.Delete(filePath);
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("AudioCapture", e.Message);

            // Surface the failure so the recording does not silently die behind a "Recording..." label.
            RunOnUiThread(() =>
            {
                if (IsDestroyed || IsFinishing) return;
                tvStatus.Text = "Capture error - tap to stop.";
                Toast.MakeText(this, $"Capture error: {e.Message}", ToastLength.Long).Show();
            });
        }
    }
}
