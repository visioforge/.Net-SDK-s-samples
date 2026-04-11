using Android.Content;
using Android.Media.Projection;
using Android.OS;
using Android.Provider;
using Android.Util;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Android.Sources;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Special;
using System.Threading;
using Activity = Android.App.Activity;

namespace Screen_Capture
{
    /// <summary>
    /// Screen capture demo activity.
    /// Flow: Start button -> start ForegroundService -> request MediaProjection -> capture screen -> record to MP4.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        private const int REQUEST_MEDIA_PROJECTION = 1001;

        private VisioForge.Core.UI.Android.VideoViewGL videoView;
        private Button btStartRecord;
        private bool _isRecording;

        private MediaBlocksPipeline _pipeline;
        private ScreenSourceBlock _screenSource;
        private VideoRendererBlock _videoRenderer;
        private H264EncoderBlock _videoEncoder;
        private MP4SinkBlock _sink;
        private TeeBlock _videoTee;

        private MediaProjectionManager _projectionManager;
        private MediaProjection _mediaProjection;
        private string _recordingFilename;

        // Screen metrics (detected on UI thread)
        private int _screenWidth;
        private int _screenHeight;
        private int _screenDpi;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);

            btStartRecord = FindViewById<Button>(Resource.Id.btStartRecord);
            btStartRecord.Click += btStartRecord_Click;

            _projectionManager = (MediaProjectionManager)GetSystemService(MediaProjectionService);

            // Detect real screen dimensions
            var dm = Resources.DisplayMetrics;
            _screenWidth = dm.WidthPixels;
            _screenHeight = dm.HeightPixels;
            _screenDpi = (int)dm.DensityDpi;
            Log.Info("ScreenCapture", $"Screen: {_screenWidth}x{_screenHeight} @ {_screenDpi}dpi");
        }

        protected override async void OnDestroy()
        {
            try
            {
                await StopCaptureAsync();
            }
            catch (Exception ex)
            {
                Log.Error("ScreenCapture", ex.ToString());
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
                    btStartRecord.Enabled = false;

                    try
                    {
                        // Request screen capture permission first;
                        // the foreground service will be started after the user grants permission
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
                    _isRecording = false;
                    btStartRecord.Text = "Start Screen Capture";

                    try { await StopCaptureAsync(); }
                    catch (Exception ex) { Log.Error("ScreenCapture", ex.ToString()); }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ScreenCapture", ex.ToString());
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
                    // Save result for use after the foreground service starts
                    var projResultCode = (int)resultCode;
                    var projData = data;

                    // Prepare TCS so we know when StartForeground() has been called
                    var fgsTcs = new TaskCompletionSource<bool>();
                    ScreenCaptureService.ForegroundStarted = fgsTcs;

                    // Start the foreground service AFTER user grants media projection permission
                    // (required on Android 14+ / targetSDK 34+)
                    var serviceIntent = new Intent(this, typeof(ScreenCaptureService));
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    {
                        StartForegroundService(serviceIntent);
                    }
                    else
                    {
                        StartService(serviceIntent);
                    }

                    // GetMediaProjection must be called AFTER the FGS is in foreground state,
                    // so we do it on a background thread after waiting for the service callback
                    Task.Run(async () =>
                    {
                        try
                        {
                            // Wait for StartForeground() to complete in the service (with timeout)
                            var completed = await Task.WhenAny(
                                fgsTcs.Task,
                                Task.Delay(5000));

                            if (completed != fgsTcs.Task)
                            {
                                RunOnUiThread(() =>
                                {
                                    btStartRecord.Enabled = true;
                                    Android.Widget.Toast.MakeText(this, "Foreground service failed to start in time", Android.Widget.ToastLength.Long).Show();
                                });
                                StopService(new Intent(this, typeof(ScreenCaptureService)));
                                return;
                            }

                            _mediaProjection = _projectionManager.GetMediaProjection(projResultCode, projData);

                            await StartCaptureAsync();

                            RunOnUiThread(() =>
                            {
                                _isRecording = true;
                                btStartRecord.Text = "Stop Screen Capture";
                                btStartRecord.Enabled = true;
                            });
                        }
                        catch (Exception ex)
                        {
                            Log.Error("ScreenCapture", ex.ToString());
                            _mediaProjection?.Stop();
                            _mediaProjection = null;
                            StopService(new Intent(this, typeof(ScreenCaptureService)));
                            RunOnUiThread(() =>
                            {
                                btStartRecord.Enabled = true;
                                Android.Widget.Toast.MakeText(this, $"Screen capture failed: {ex.Message}", Android.Widget.ToastLength.Long).Show();
                            });
                        }
                    });
                }
                else
                {
                    btStartRecord.Enabled = true;
                    Android.Widget.Toast.MakeText(this, "Screen capture permission denied", Android.Widget.ToastLength.Short).Show();
                }
            }
        }

        private async Task StartCaptureAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            // Validate screen dimensions (may be 0 on some devices before layout)
            if (_screenWidth <= 0 || _screenHeight <= 0)
            {
                throw new InvalidOperationException("Could not detect screen dimensions");
            }

            // Screen source with MediaProjection (dimensions detected in OnCreate)
            var settings = new AndroidScreenCaptureSourceSettings
            {
                MediaProjection = _mediaProjection,
                FrameRate = new VideoFrameRate(30),
                Width = _screenWidth,
                Height = _screenHeight,
                Dpi = _screenDpi
            };

            _screenSource = new ScreenSourceBlock(settings);

            // Video renderer (preview)
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            // Tee to split: preview + recording
            var teeSettings = new TeeQueueSettings
            {
                MaxSizeBuffers = 3,
                Leaky = TeeQueueLeaky.Downstream
            };
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video, teeSettings);

            _pipeline.Connect(_screenSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            // H264 encoder + MP4 sink
            _videoEncoder = new H264EncoderBlock();

            var now = DateTime.Now;
            var moviesDir = GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
            if (moviesDir == null)
            {
                throw new InvalidOperationException("External storage not available");
            }

            moviesDir.Mkdirs();
            _recordingFilename = Path.Combine(moviesDir.AbsolutePath, $"screen_{now:yyyyMMdd_HHmmss}.mp4");
            _sink = new MP4SinkBlock(new MP4SinkSettings(_recordingFilename));

            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
            _pipeline.Connect(_videoEncoder.Output, (_sink as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));

            await _pipeline.StartAsync();
        }

        private async Task StopCaptureAsync()
        {
            var pipeline = Interlocked.Exchange(ref _pipeline, null);
            if (pipeline != null)
            {
                pipeline.OnError -= Pipeline_OnError;
                await pipeline.StopAsync(force: false);
                await pipeline.DisposeAsync();
            }

            // Copy the recording to the gallery via MediaStore
            var filename = Interlocked.Exchange(ref _recordingFilename, null);
            if (filename != null && File.Exists(filename))
            {
                try
                {
                    CopyToGallery(filename);
                }
                catch (Exception ex)
                {
                    Log.Error("ScreenCapture", $"Failed to copy to gallery: {ex}");
                }
            }

            _screenSource = null;
            _videoRenderer = null;
            _videoEncoder = null;
            _sink = null;
            _videoTee = null;
            _mediaProjection?.Stop();
            _mediaProjection = null;

            // Stop the foreground service
            StopService(new Intent(this, typeof(ScreenCaptureService)));

            if (!IsFinishing && !IsDestroyed)
            {
                RunOnUiThread(() => videoView?.Invalidate());
            }
        }

        private void CopyToGallery(string filePath)
        {
            var fileName = System.IO.Path.GetFileName(filePath);

            var values = new ContentValues();
            values.Put(MediaStore.Video.Media.InterfaceConsts.DisplayName, fileName);
            values.Put(MediaStore.Video.Media.InterfaceConsts.MimeType, "video/mp4");
            values.Put(MediaStore.Video.Media.InterfaceConsts.RelativePath, Android.OS.Environment.DirectoryMovies);

            var uri = ContentResolver.Insert(MediaStore.Video.Media.ExternalContentUri, values);
            if (uri == null)
            {
                Log.Error("ScreenCapture", "Failed to create MediaStore entry");
                return;
            }

            using var output = ContentResolver.OpenOutputStream(uri);
            if (output == null)
            {
                Log.Error("ScreenCapture", "Failed to open output stream for MediaStore entry");
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

            Log.Info("ScreenCapture", $"Recording saved to gallery: {fileName}");

            // Delete the temp file
            File.Delete(filePath);
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("ScreenCapture", e.Message);
        }
    }
}
