using System.Globalization;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sinks;

#if __ANDROID__
using Android.Content;
using Android.Media.Projection;
using Android.OS;
using Android.Provider;
using Android.Util;
using VisioForge.Core.Types.X.Android.Sources;
#endif

namespace ScreenCaptureMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private ScreenSourceBlock _source;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private MP4SinkBlock _mp4Sink;

        private H264EncoderBlock _h264Encoder;

        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

#if __ANDROID__
        private MediaProjection _mediaProjection;
        private string _recordingFilename;
#endif

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;

            _tmPosition.Elapsed += tmPosition_Elapsed;
        }

        private string GenerateFilename()
        {
            DateTime now = DateTime.Now;
#if __ANDROID__
            string filename;
            var context = Android.App.Application.Context;
            var moviesDir = context.GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);

            if (moviesDir != null && !moviesDir.Exists())
            {
                moviesDir.Mkdirs();
            }

            filename = Path.Combine(moviesDir?.AbsolutePath ?? context.FilesDir.AbsolutePath,
                $"screen_{now:yyyyMMdd_HHmmss}.mp4");
#elif __IOS__ && !__MACCATALYST__
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __MACCATALYST__
            var filename = Path.Combine("/tmp", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif

            return filename;
        }

#if __ANDROID__
        /// <summary>
        /// Request MediaProjection permission from the user, start foreground service,
        /// and obtain the MediaProjection instance.
        /// </summary>
        private async Task<MediaProjection> RequestMediaProjectionAsync()
        {
            var activity = Platform.CurrentActivity;
            var projectionManager = (MediaProjectionManager)activity.GetSystemService(Android.Content.Context.MediaProjectionService);

            // Set up TCS for the activity result
            MainActivity.MediaProjectionResult = new TaskCompletionSource<(Android.App.Result, Intent)>();

            // Launch the screen capture consent dialog
            activity.StartActivityForResult(projectionManager.CreateScreenCaptureIntent(), MainActivity.RequestMediaProjection);

            // Wait for user consent (or denial)
            var (resultCode, data) = await MainActivity.MediaProjectionResult.Task;

            if (resultCode != Android.App.Result.Ok || data == null)
            {
                return null;
            }

            // Start foreground service AFTER user grants permission
            var fgsTcs = new TaskCompletionSource<bool>();
            ScreenCaptureService.ForegroundStarted = fgsTcs;

            var serviceIntent = new Intent(activity, typeof(ScreenCaptureService));
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                activity.StartForegroundService(serviceIntent);
            }
            else
            {
                activity.StartService(serviceIntent);
            }

            // Wait for StartForeground() with timeout
            var completed = await Task.WhenAny(fgsTcs.Task, Task.Delay(5000));
            if (completed != fgsTcs.Task)
            {
                activity.StopService(serviceIntent);
                throw new TimeoutException("Foreground service did not start within 5 seconds.");
            }

            return projectionManager.GetMediaProjection((int)resultCode, data);
        }

        private async Task CreateEngineAndroidAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            // Request MediaProjection
            _mediaProjection = await RequestMediaProjectionAsync();
            if (_mediaProjection == null)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    DisplayAlert("Permission Denied", "Screen capture permission was denied.", "OK");
                });
                return;
            }

            // Get screen dimensions
            var activity = Platform.CurrentActivity;
            var dm = activity.Resources.DisplayMetrics;
            int screenWidth = dm.WidthPixels;
            int screenHeight = dm.HeightPixels;
            int screenDpi = (int)dm.DensityDpi;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _player_OnError;

            // Screen source with MediaProjection
            var settings = new AndroidScreenCaptureSourceSettings
            {
                MediaProjection = _mediaProjection,
                FrameRate = new VideoFrameRate(30),
                Width = screenWidth,
                Height = screenHeight,
                Dpi = screenDpi
            };

            _source = new ScreenSourceBlock(settings);
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            _recordingFilename = GenerateFilename();
            lbFilename.Text = $"FILENAME: {_recordingFilename}";
            lbFilename.IsVisible = true;
            _mp4Sink = new MP4SinkBlock(new MP4SinkSettings(_recordingFilename));
            _h264Encoder = new H264EncoderBlock();

            IVideoView vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

            _pipeline.Connect(_source.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
            _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
        }

        private void CopyToGallery(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return;
            }

            var fileName = Path.GetFileName(filePath);
            var context = Platform.CurrentActivity;

            var values = new ContentValues();
            values.Put(MediaStore.Video.Media.InterfaceConsts.DisplayName, fileName);
            values.Put(MediaStore.Video.Media.InterfaceConsts.MimeType, "video/mp4");
            values.Put(MediaStore.Video.Media.InterfaceConsts.RelativePath, Android.OS.Environment.DirectoryMovies);

            var uri = context.ContentResolver.Insert(MediaStore.Video.Media.ExternalContentUri, values);
            if (uri == null)
            {
                System.Diagnostics.Debug.WriteLine("Failed to create MediaStore entry");
                return;
            }

            try
            {
                using var output = context.ContentResolver.OpenOutputStream(uri);
                if (output == null)
                {
                    context.ContentResolver.Delete(uri, null, null);
                    System.Diagnostics.Debug.WriteLine("Failed to open MediaStore output stream");
                    return;
                }

                using var input = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                input.CopyTo(output);
                output.Flush();
            }
            catch
            {
                context.ContentResolver.Delete(uri, null, null);
                throw;
            }

            System.Diagnostics.Debug.WriteLine($"Recording saved to gallery: {fileName}");
            File.Delete(filePath);
        }

        private void StopAndroidCapture()
        {
            try
            {
                if (_recordingFilename != null && File.Exists(_recordingFilename))
                {
                    CopyToGallery(_recordingFilename);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to copy to gallery: {ex}");
            }

            _recordingFilename = null;
            _mediaProjection?.Stop();
            _mediaProjection = null;

            var activity = Platform.CurrentActivity;
            activity?.StopService(new Intent(activity, typeof(ScreenCaptureService)));
        }
#endif

        private async Task CreateEngineAsync()
        {
#if __ANDROID__
            await CreateEngineAndroidAsync();
#else
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _player_OnError;

            _source = new ScreenSourceBlock();
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            var filename = GenerateFilename();
            lbFilename.Text = $"FILENAME: {filename}";
            lbFilename.IsVisible = true;
            _mp4Sink = new MP4SinkBlock(new MP4SinkSettings(filename));
            _h264Encoder = new H264EncoderBlock();

            IVideoView vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

            _pipeline.Connect(_source.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
            _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
#endif
        }

#if __IOS__ && !__MACCATALYST__
        private void RequestPhotoPermission()
        {
            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    System.Diagnostics.Debug.WriteLine("Photo library access granted.");
                }
            });
        }
#endif

#if __IOS__ && !__MACCATALYST__
        private void AddVideoToPhotosLibrary(string filePath)
        {
            var fileUrl = Foundation.NSUrl.FromFilename(filePath);

            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    Photos.PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
                    {
                        Photos.PHAssetChangeRequest.FromVideo(fileUrl);
                    }, (success, error) =>
                    {
                        if (success)
                        {
                            System.Diagnostics.Debug.WriteLine("Video saved to Photos library.");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Error saving video: {error?.LocalizedDescription}");
                        }
                    });
                }
            });
        }
#endif

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;

#if __MACCATALYST__
            ScreenSourceBlock.AskPermissions();
#endif

#if __IOS__ && !__MACCATALYST__
            RequestPhotoPermission();
#endif
        }

        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    _pipeline.OnError -= _player_OnError;
                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    _pipeline = null;
                }

#if __ANDROID__
                StopAndroidCapture();
#endif

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void _player_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
        }

        private async void tmPosition_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    lbDuration.Text = $"{(await _pipeline.Position_GetAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private async void btStart_Clicked(object? sender, EventArgs e)
        {
            try
            {
                btStart.IsEnabled = false;

                await CreateEngineAsync();

                if (_pipeline == null)
                {
                    // Android: user denied permission
                    btStart.IsEnabled = true;
                    return;
                }

                await _pipeline.StartAsync();

                _tmPosition.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                btStart.IsEnabled = true;

#if __ANDROID__
                StopAndroidCapture();
#endif
            }
        }

        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
#if __IOS__ && !__MACCATALYST__
                var filename = _mp4Sink.GetFilenameOrURL();
#endif

                await StopAllAsync();

#if __IOS__ && !__MACCATALYST__
                AddVideoToPhotosLibrary(filename);
#endif

#if __ANDROID__
                StopAndroidCapture();
#endif

                lbFilename.IsVisible = false;
                btStart.IsEnabled = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
